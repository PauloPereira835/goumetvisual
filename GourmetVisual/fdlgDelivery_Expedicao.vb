Imports System.Data.SqlClient

Public Class fdlgDelivery_Expedicao
    Private Sub MontaBotoes()

        Dim n As Integer = 0
        Dim con_bt As New SqlConnection()
        Dim dr_bt As SqlDataReader

        con_bt.ConnectionString = strCon
        Dim cmd_bt As SqlCommand = con_bt.CreateCommand

        strSql = "Select CASE WHEN ISNUMERIC(Funcionario) = 1 THEN CAST(Funcionario AS int) ELSE 0 END AS Sequencia, IDFuncionario, Funcionario, Funcao "
        strSql += "From tblFuncionarios_Local "
        strSql += "Where (Funcao = 'ENTREGADOR') "
        strSql += "ORDER BY Sequencia"


        cmd_bt.CommandText = strSql
        con_bt.Open()
        dr_bt = cmd_bt.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)


        Dim myfont As New Font("Sans Serif", 9, FontStyle.Bold)
        Dim btnArray(100) As System.Windows.Forms.Button
        For i As Integer = 0 To 100
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        PanelCat.Controls.Clear()

        If dr_bt.HasRows Then
            While (dr_bt.Read())
                With (btnArray(n))
                    .Tag = NuloInteger(dr_bt.Item("IDFuncionario"))
                    .Text = NuloString(dr_bt.Item("Funcionario"))
                    .Width = 142
                    .Height = 40
                    If NuloInteger(tbIDFuncionario.Text) = NuloInteger(dr_bt.Item("IDFuncionario")) Then
                        .BackColor = Color.LawnGreen
                        .ForeColor = Color.Gray
                    Else
                        .BackColor = Color.Gray
                        .ForeColor = Color.Lime
                    End If

                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0

                    .Font = myfont
                    .Margin = New Padding(0, 0, 0, 0)

                    frmPagamento.carregaVisualComponente(btnArray(n), 20, 20)

                    Me.PanelCat.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton

                    n += 1
                End With
            End While
        End If

        con_bt.Close()
        con_bt.Dispose()

    End Sub
    Private Sub ClickButton(ByVal sender As Object, ByVal e As System.EventArgs)

        With CType(sender, Button)
            Dim Loc As Integer = InStr(NuloString(.Tag), "/")
            Dim Texto As String = NuloString(.Tag)
            Dim IDComent As Integer = NuloInteger(Strings.Left(NuloString(Texto), Len(NuloString(Texto)) - Loc - 1))
            Dim IDProd As Integer = NuloInteger(Strings.Right(NuloString(.Tag), Len(NuloString(.Tag)) - InStr(NuloString(.Tag), "/")))
            Dim nova_linha As DataRow = DataSetEntregadores.Tables(0).NewRow()

            tbIDFuncionario.Text = NuloInteger(.Tag)
            tbEntregador.Text = NuloString(.Text)

            If .BackColor = Color.Gray Then
                .BackColor = Color.LawnGreen
                .ForeColor = Color.Gray

                Dim IDGrid As Integer = 0
                If DataSetEntregadores.Tables(0).Rows.Count = 0 Then
                    IDGrid = 1
                Else
                    IDGrid = DataSetEntregadores.Tables(0).Rows.Count + 1
                End If

                nova_linha.ItemArray = New Object() {IDGrid, IDComent, .Text, IDProd, 0}
                DataSetEntregadores.Tables(0).Rows.Add(nova_linha)

            Else
                .BackColor = Color.Gray
                .ForeColor = Color.Lime

                If DataSetEntregadores.Tables(0).Rows.Count > 0 Then
                    Dim i As Integer = 0
                    Dim ii As Integer = DataSetEntregadores.Tables(0).Rows.Count
                    While i < ii
                        If DataSetEntregadores.Tables(0).Rows(i).Item(2).ToString = .Text Then
                            DataSetEntregadores.Tables(0).Rows(i).Delete()
                            i -= 1
                            ii -= 1
                        End If
                        i += 1
                    End While
                End If
            End If

        End With
        MontaBotoes()

        tbVenda.Focus()

    End Sub
    Private Sub Confirma()

        strSql = "UPDATE tblVendas SET "
        strSql += "Entregador='" & tbEntregador.Text & "', "
        strSql += "HoraProducao='" & Now & "' "
        'strSql += "TotalVenda=" & Replace(lbValor.Text, ",", ".") & " "
        strSql += "WHERE IDVenda=" & tbIDVenda.Text
        ExecutaStr(strSql)

        If NuloString(lbIDVendaExterna.Text) <> "" Then
            Dim App As String = NuloString(PegaValorCampo("App", "SELECT App, IDVendaExterna FROM tblVendas WHERE (IDVendaExterna='" & lbIDVendaExterna.Text & "')", strCon))
            If IntegracaoIfood = True And App = "IFOOD" Then
                If NuloString(token_accessIfood) = "" Then
                    PegaTokenIfood()
                End If
                If token_accessIfood <> "" Then
                    If DateDiff(DateInterval.Minute, Now, DateAdd(DateInterval.Minute, -5, token_DataHoraFim_Ifood)) < 0 Then
                        PegaTokenIfood()
                    End If
                    MudarStatus(lbIDVendaExterna.Text, "confirmation", App)
                    MudarStatus(lbIDVendaExterna.Text, "dispatch", App)
                End If
            End If
            If IntegracaoQRbox = True And App = "QRBOX" Then
                If NuloString(token_accessQRbox) = "" Then
                    PegaToken_QRbox()
                End If
                If token_accessQRbox <> "" Then
                    If DateDiff(DateInterval.Minute, Now, DateAdd(DateInterval.Minute, -5, token_DataHoraFim_QRbox)) < 0 Then
                        PegaToken_QRbox()
                    End If
                    MudarStatus(lbIDVendaExterna.Text, "confirmation", App)
                    MudarStatus(lbIDVendaExterna.Text, "dispatch", App)

                End If
            End If

            If IntegracaoRappi = True And App = "RAPPI" Then
                Dim api As New ApisRappi(IDLoja_Rappi, Client_Secret_Rappi, Audience_Rappi)
                api.OrderReadyForPickup(lbIDVendaExterna.Text)
            End If
        End If

        tbEntregador.Text = ""
        tbIDFuncionario.Text = ""
        MontaBotoes()

        lbIDVendaExterna.Text = ""
        lbNumVenda.Text = ""
        lbTel_CPF.Text = ""
        lbCliente.Text = ""
        lbValor.Text = ""
        lbPagamento.Text = ""
        lbTroco.Visible = True
        lbLevarTroco.Visible = True
        lbTroco.Text = ""
        lbRua.Text = ""
        lbNumero.Text = ""
        lbComplemento.Text = ""
        lbBairro.Text = ""
        lbCEP.Text = ""
        lbReferencia.Text = ""
        lbEntregador.Text = ""
        lbComentExpedicao.Text = ""



    End Sub
    Private Sub AchaVenda()
        If tbVenda.Text = "" Then Exit Sub

        Dim con As New SqlConnection()
        strSql = "Select tblVendas.IDVenda, tblVendas.NumVendaD, tblVendas.Troco, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblClientes.Tel1, tblClientes.DDD1, tblClientes.CPF_CNPJ, tblRuas.Logradouro, tblClientes.NomeCliente, tblClientes.Numero, tblClientes.Complemento, tblClientes.Referencia, tblClientes.CEP, tblVendas.FlagFechada, tblRuas.IDRua, tblVendas.CepEntrega, tblVendas.NumeroEntrega, tblVendas.ComplementoEntrega, tblVendas.ReferenciaEntrega, tblRuas.Bairro, tblVendas.Entregador, tblVendas.ComentExpedicao, tblVendas.TaxaEntrega, tblVendas.Servico, tblVendas.Desconto, tblVendas.TotalVenda, tblVendas.Caixinha, tblVendas.Excluido, tblVendas.IDVendaExterna "
        strSql += "From tblVendas INNER Join tblClientes On tblVendas.IDCliente = tblClientes.IDCliente INNER Join tblRuas On tblVendas.IDRuaEntrega = tblRuas.IDRua LEFT OUTER Join tblVendasPagto On tblVendas.IDVenda = tblVendasPagto.IDVenda "
        strSql += "Where (tblVendas.NumVendaD = " & tbVenda.Text & ")"

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVendaD, tblVendas.Troco, SUM(tblVendasPagto.ValorPago) As ValorPago, tblClientes.Tel1, tblClientes.DDD1, tblClientes.CPF_CNPJ, tblRuas.Logradouro, tblClientes.NomeCliente, tblClientes.Numero, tblClientes.Complemento, tblClientes.Referencia, tblClientes.CEP, tblVendas.FlagFechada, tblRuas.IDRua, tblVendas.CepEntrega, tblVendas.NumeroEntrega, tblVendas.ComplementoEntrega, tblVendas.ReferenciaEntrega, tblRuas.Bairro, tblVendas.Entregador, tblVendas.ComentExpedicao, tblVendas.TaxaEntrega, tblVendas.Servico, tblVendas.Desconto, tblVendas.TotalVenda, tblVendas.Caixinha, tblVendas.Excluido, tblVendas.IDVendaExterna "
        strSql += "From tblVendas INNER Join tblClientes On tblVendas.IDCliente = tblClientes.IDCliente INNER Join tblRuas On tblVendas.IDRuaEntrega = tblRuas.IDRua LEFT OUTER Join tblVendasPagto On tblVendas.IDVenda = tblVendasPagto.IDVenda "
        strSql += "Group By tblVendas.IDVenda, tblVendas.NumVendaD, tblVendas.Troco, tblClientes.Tel1, tblClientes.DDD1, tblClientes.CPF_CNPJ, tblRuas.Logradouro, tblClientes.NomeCliente, tblClientes.Numero, tblClientes.Complemento, tblClientes.Referencia, tblClientes.CEP, tblRuas.IDRua, tblVendas.CepEntrega, tblVendas.NumeroEntrega, tblVendas.ComplementoEntrega, tblVendas.ReferenciaEntrega, tblRuas.Bairro, tblVendas.Entregador, tblVendas.ComentExpedicao, tblVendas.TaxaEntrega, tblVendas.Servico, tblVendas.Desconto, tblVendas.TotalVenda, tblVendas.Caixinha, tblVendas.IDVendaExterna, tblVendas.FlagFechada, tblVendas.Excluido "
        strSql += "HAVING(tblVendas.NumVendaD = " & tbVenda.Text & ")"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        lbIDVendaExterna.Text = ""
        tbIDVenda.Text = ""
        lbNumVenda.Text = ""
        lbTel_CPF.Text = ""
        lbCliente.Text = ""
        lbValor.Text = ""
        lbPagamento.Text = ""
        lbTroco.Visible = True
        lbLevarTroco.Visible = True
        lbTroco.Text = ""
        lbRua.Text = ""
        lbNumero.Text = ""
        lbComplemento.Text = ""
        lbBairro.Text = ""
        lbCEP.Text = ""
        lbReferencia.Text = ""
        lbEntregador.Text = ""
        lbComentExpedicao.Text = ""

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            If NuloBoolean(dr.Item("FlagFechada")) = True Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                If NuloBoolean(dr.Item("Excluido")) = False Then
                    frm.lbMensagem.Text = "Venda " & tbVenda.Text & " já recebida"
                Else
                    frm.lbMensagem.Text = "Venda " & tbVenda.Text & " foi estornada"
                End If
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            Else
                lbIDVendaExterna.Text = NuloString(dr.Item("IDVendaExterna"))
                tbIDVenda.Text = NuloInteger(dr.Item("IDVenda"))
                lbNumVenda.Text = NuloInteger(dr.Item("NumVendaD"))
                lbTel_CPF.Text = NuloString(dr.Item("DDD1")) & " " & NuloString(dr.Item("Tel1")) & "    " & NuloString(dr.Item("CPF_CNPJ"))
                lbCliente.Text = NuloString(dr.Item("NomeCliente"))
                lbValor.Text = Format(NuloDecimal(dr.Item("ValorPago")), "#0.00")
                ' lbPagamento.Text = NuloString(dr.Item("Descricao"))
                If NuloDecimal(dr.Item("Troco")) <> 0 Then
                    lbTroco.Visible = True
                    lbLevarTroco.Visible = True
                    lbTroco.Text = Format(NuloDecimal(dr.Item("ValorPago")), "#0.00") & " / " & Format(NuloDecimal(dr.Item("ValorPago")) - NuloDecimal(dr.Item("Troco")), "#0.00")
                Else
                    lbTroco.Visible = False
                    lbLevarTroco.Visible = False
                End If
                If NuloDecimal(dr.Item("Caixinha")) <> 0 Then
                    lbCaixinhaTxt.Visible = True
                    lbCaixinha.Visible = True
                    lbCaixinha.Text = Format(NuloDecimal(dr.Item("Caixinha")), "#0.00")
                Else
                    lbCaixinhaTxt.Visible = False
                    lbCaixinha.Visible = False
                End If
                lbRua.Text = NuloString(dr.Item("Logradouro"))
                lbNumero.Text = NuloString(dr.Item("NumeroEntrega"))
                lbComplemento.Text = NuloString(dr.Item("ComplementoEntrega"))
                lbBairro.Text = NuloString(dr.Item("Bairro"))
                lbCEP.Text = NuloString(dr.Item("CepEntrega"))
                lbReferencia.Text = NuloString(dr.Item("ReferenciaEntrega"))
                lbEntregador.Text = NuloString(dr.Item("Entregador"))
                lbComentExpedicao.Text = NuloString(dr.Item("ComentExpedicao"))
                tbTaxaEntrega.Text = NuloDecimal(dr.Item("TaxaEntrega"))
                tbValorDesconto.Text = NuloDecimal(dr.Item("Desconto"))
                tbValorAcrescimo.Text = NuloDecimal(dr.Item("Servico"))
                tbValorVenda.Text = NuloDecimal(dr.Item("ValorPago"))

                strSql = "Select IDVendaPagto, IDVenda FROM tblVendasPagto WHERE IDVenda=" & NuloInteger(dr.Item("IDVenda"))
                tbIDVendaPagto.Text = NuloInteger(PegaValorCampo("IDVendaPagto", strSql, strCon))

                strSql = "Select IDVenda, NumSAT FROM tblVendasSAT WHERE IDVenda=" & NuloInteger(dr.Item("IDVenda"))
                If NuloString(PegaValorCampo("NumSAT", strSql, strCon)) <> "" Then

                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Cupom já emitido para esta venda " & tbVenda.Text & vbCrLf & "não será possivel confirmar"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    btnConfirma.Enabled = False
                Else
                    btnConfirma.Enabled = True
                End If

            End If
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Venda " & tbVenda.Text & " não encontrada"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        tbVenda.Text = ""
        tbVenda.Focus()


    End Sub
    Private Sub FdlgDelivery_Expedicao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MontaBotoes()
        AchaVenda()

    End Sub

    Private Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        If NuloInteger(tbIDFuncionario.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um entregador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloInteger(tbIDVenda.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVenda.Focus()
            Exit Sub
        End If

        strSql = "Select IDVendaPagto, IDVenda, ValorPago FROM tblVendasPagto WHERE IDVenda=" & tbIDVenda.Text
        If NuloDecimal(PegaValorCampo("ValorPago", strSql, strCon)) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Forma de pagamento inválida" & vbCrLf & "É necessário informar o pagamento deste pedido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVenda.Focus()
            Exit Sub
        End If

        Dim ValorVenda As Decimal = NuloDecimal(lbValor.Text)

        Confirma()

        If ModoFiscal = "SAT" Then

            strSql = "UPDATE tblVendas SET "
            strSql += "IDSat=" & EquipamentoSAT & " "
            strSql += "WHERE IDVenda=" & tbIDVenda.Text
            ExecutaStr(strSql)

            Dim IDvdaSAT As Integer

            strSql = "SELECT IDVenda, CpfCnpj FROM tblVendas WHERE IDVenda=" & tbIDVenda.Text
            Dim Cpf_CNPJ As String = NuloString(PegaValorCampo("CpfCnpj", strSql, strCon))


            strSql = "SELECT IDVenda FROM tblVendasSAT WHERE IDVenda=" & tbIDVenda.Text
            If NuloInteger(PegaValorCampo("IDVenda", strSql, strCon)) = 0 Then
                strSql = "INSERT tblVendasSAT "
                strSql += "(IDVenda, ValorCupom) VALUES ("
                strSql += to_sql(tbIDVenda.Text) & ","
                strSql += to_sql(Replace(NuloDecimal(ValorVenda), ",", ".")) & ")"
                ExecutaStr(strSql)
            Else
                strSql = "UPDATE tblVendasSAT SET "
                strSql += "ValorCupom=" & Replace(NuloDecimal(ValorVenda), ",", ".") & " "
                strSql += "WHERE IDVenda=" & tbIDVenda.Text
                ExecutaStr(strSql)
            End If

            Dim frm As fdlgCpf_Cnpj = New fdlgCpf_Cnpj
            frm.tbIDVendaSAT.Text = PegaID("IDVendaSAT", "tblVendasSAT", "L")
            frm.tbIDVenda.Text = tbIDVenda.Text
            frm.tbTotalAD.Text = (tbValorAcrescimo.Text - tbValorDesconto.Text)
            frm.tbTotVenda.Text = tbValorVenda.Text
            frm.tbTotCupom.Text = NuloDecimal(tbValorVenda.Text)
            If IsDBNull(tbTaxaEntrega.Text) Then
                frm.tbTxEntrega.Text = 0
            Else
                frm.tbTxEntrega.Text = tbTaxaEntrega.Text
            End If

            If Modulo = "S" Then
                frm.tbStVenda.Text = "Salão"
            Else
                If Modulo = "B" Then
                    frm.tbStVenda.Text = "Balcão"
                Else
                    frm.tbStVenda.Text = "Delivery"
                End If
            End If


            strSql = "SELECT IDFechamento, DiaMovimento FROM tblFechamentos_Local WHERE IDFechamento=" & IDFechamento
            frm.tbDiaMovto.Text = PegaValorCampo("DiaMovimento", strSql, strCon)
            frm.tbIDSat.Text = EquipamentoSAT
            frm.tbIDVendaPagto.Text = tbIDVendaPagto.Text
            frm.tbCpfCnpj.Text = Cpf_CNPJ
            frm.ShowDialog()
        End If


        'If TerminalExpedicao = False Then
        'If tbOrigem.Text <> "" Then
        EntregadorVenda = NuloString(tbEntregador.Text)
        Me.Dispose()
        Me.Close()
        '    End If
        'End If
    End Sub
End Class