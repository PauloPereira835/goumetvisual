Imports System.Data.SqlClient

Public Class fdlgExpedicao
    Private Sub Confirma()

        strSql = "UPDATE tblVendas SET "
        strSql += "Entregador='" & tbEntregador.Text & "', "
        strSql += "HoraProducao='" & Now & "' "
        strSql += "WHERE IDVenda=" & tbIDVenda.Text
        ExecutaStr(strSql)

        If NuloString(lbIDVendaExterna.Text) <> "" Then
            Dim App As String = NuloString(PegaValorCampo("App", "SELECT App, IDVendaExterna FROM tblVendas WHERE (IDVendaExterna='" & lbIDVendaExterna.Text & "')", strCon))
            If IntegracaoIfood = True And App = "IFOOD" Then
                If NuloString(token_accessIfood) = "" Then
                    PegaToken_iFood()
                End If
                If token_accessIfood <> "" Then
                    If DateDiff(DateInterval.Minute, Now, DateAdd(DateInterval.Minute, -5, token_DataHoraFim_Ifood)) < 0 Then
                        PegaToken_iFood()
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
        lbDistancia.Text = ""
        lbCaixinha.Text = ""

        'If TerminalExpedicao = False Then
        'Me.Dispose()
        'Me.Close()
        'End If



    End Sub

    Private Sub AchaVenda()
        If tbVenda.Text = "" Then Exit Sub

        Dim con As New SqlConnection()

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
        lbCaixinha.Text = ""

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
                'lbPagamento.Text = NuloString(dr.Item("Descricao"))
                If NuloDecimal(dr.Item("Troco")) <> 0 Then
                    lbTroco.Visible = True
                    lbLevarTroco.Visible = True
                    lbTroco.Text = Format(NuloDecimal(dr.Item("ValorPago")), "#0.00") & " / " & Format(NuloDecimal(dr.Item("ValorPago")) - NuloDecimal(dr.Item("Troco")), "#0.00")
                Else
                    lbTroco.Visible = False
                    lbLevarTroco.Visible = False
                End If
                lbCaixinha.Text = Format(NuloDecimal(dr.Item("Caixinha")), "#0.00")
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

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally

        con_bt.Close()
        con_bt.Dispose()
        'End Try
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

    Private Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        If TerminalExpedicao = True Then
            End
        Else
            Me.Dispose()
            Me.Close()
        End If


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        tbVenda.Text &= "0"

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        tbVenda.Text = ""

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        tbVenda.Text &= "1"

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        tbVenda.Text &= "2"

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        tbVenda.Text &= "3"

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        tbVenda.Text &= "4"

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        tbVenda.Text &= "5"

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        tbVenda.Text &= "6"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbVenda.Text &= "7"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        tbVenda.Text &= "8"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        tbVenda.Text &= "9"

    End Sub

    Private Sub FdlgExpedicao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MontaBotoes()

        Foco = "V"

        lbIDVendaExterna.Text = ""
        lbDistancia.Text = ""
        tbIDVenda.Text = ""
        lbNumVenda.Text = ""
        lbTel_CPF.Text = ""
        lbCliente.Text = ""
        lbValor.Text = ""
        lbPagamento.Text = ""
        lbTroco.Visible = True
        lbLevarTroco.Visible = True
        lbCaixinha.Text = ""
        lbTroco.Text = ""
        lbRua.Text = ""
        lbNumero.Text = ""
        lbComplemento.Text = ""
        lbBairro.Text = ""
        lbCEP.Text = ""
        lbReferencia.Text = ""
        lbEntregador.Text = ""
        lbComentExpedicao.Text = ""

        If NuloInteger(tbVenda.Text) <> 0 Then
            Panel1.Visible = False
            AchaVenda()
        End If

        frmPagamento.carregaVisualComponente(btnVoltar, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfirma, 10, 10)
        frmPagamento.carregaVisualComponente(btnGoogle, 10, 10)
        frmPagamento.carregaVisualComponente(Button12, 10, 10)
        frmPagamento.carregaVisualComponente(btnEntregas, 10, 10)


    End Sub

    Private Sub TbVenda_TextChanged(sender As Object, e As EventArgs) Handles tbVenda.TextChanged

    End Sub

    Private Sub tbVenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbVenda.KeyPress

        If AscW(e.KeyChar) = 13 Then
            AchaVenda()
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        AchaVenda()
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

            'strSql = "UPDATE tblVendas SET "
            'strSql += "Caixinha = " & Replace(NuloDecimal(tbCaixinha.Text), ",", ".") & " "
            'strSql += "WHERE IDVenda=" & tbIDVenda.Text
            'ExecutaStr(strSql)


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
            frm.ShowDialog()
        End If

        lbCaixinha.Text = 0.00
        tbVenda.Focus()

        If TerminalExpedicao = False Then
            If tbOrigem.Text <> "" Then
                EntregadorVenda = NuloString(tbEntregador.Text)
                Me.Dispose()
                Me.Close()
            End If
        End If




    End Sub

    Private Sub BtnGoogle_Click(sender As Object, e As EventArgs) Handles btnGoogle.Click
        If lbRua.Text = "" Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Endereço inválido"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        Else
            Dim frm As fdlgGoogleMaps = New fdlgGoogleMaps
            frm.lbLogradouro.Text = lbRua.Text
            frm.lbNumero.Text = lbNumero.Text
            frm.lbCEP.Text = lbCEP.Text
            frm.lbComplemento.Text = lbComplemento.Text
            frm.lbBairro.Text = lbBairro.Text
            frm.ShowDialog()
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
        frm2.lbMensagem.Text = "Imprime expedição"
        frm2.btnNao.Visible = True
        frm2.btnSim.Visible = True
        frm2.btnOK.Visible = False
        frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm2.ShowDialog()
        If RetornoMsg = True Then
            frmDelivery.CriaExpedicao(tbIDVenda.Text)
            ' 1a Impressão   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpressoraExpedicao, Application.StartupPath & "\Impressao\conta.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpressoraExpedicao, Chr(27) & Chr(109))
            End If
            If NuloInteger(QtdeImpressaoExpedicao) >= 2 Then
                ' 2a Impressão   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpressoraExpedicao, Application.StartupPath & "\Impressao\conta.txt")
                If GuilhotinaImpCaixa = True Then
                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpressoraExpedicao, Chr(27) & Chr(109))
                End If
            End If
            If NuloInteger(QtdeImpressaoExpedicao) = 3 Then
                ' 3a Impressão   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpressoraExpedicao, Application.StartupPath & "\Impressao\conta.txt")
                If GuilhotinaImpCaixa = True Then
                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpressoraExpedicao, Chr(27) & Chr(109))
                End If
            End If
        End If

        Dim frm3 As fdlgMensagemBox = New fdlgMensagemBox
        frm3.lbMensagem.Text = "Imprime pedidos"
        frm3.btnNao.Visible = True
        frm3.btnSim.Visible = True
        frm3.btnOK.Visible = False
        frm3.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm3.ShowDialog()
        If RetornoMsg = True Then
            strSql = "UPDATE tblVendasMovto SET "
            strSql &= "Impresso=0 "
            strSql &= "WHERE (IDVenda=" & IDVenda & ") AND (Excluido=0)"
            ExecutaStr(strSql)
        End If
    End Sub

    Private Sub fdlgExpedicao_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.LightGreen, Color.DarkGreen, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub BtnEntregas_Click(sender As Object, e As EventArgs) Handles btnEntregas.Click
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
        fdlgDelivery_Entregas.ShowDialog()
        tbVenda.Focus()
    End Sub
    Private Sub tbVenda_GotFocus(sender As Object, e As EventArgs) Handles tbVenda.GotFocus
        Foco = "V"
    End Sub
End Class