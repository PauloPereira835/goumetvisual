Imports System.Data.SqlClient
Imports System.IO

Public Class frmPagamento
    Protected Declare Function CreateRoundRectRgn Lib "Gdi32" (ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer, ByVal X3 As Integer, ByVal Y3 As Integer) As Integer
    Protected regionHandle As IntPtr
    Public VendaInformada As Boolean = False

    Public font_Descvenda As New Font("Tahoma", 18, FontStyle.Bold)
    Public lbl_Txtvenda1 As Label = New Label()
    Public FixaTela As Boolean = False
    Public qtdeTotal As Integer

    Public Sub ReduzDefinicao()
        Me.Size = New System.Drawing.Size(1280, 770)
        Panel1.Location = New Point(15, 102)
        tbValor.Location = New Point(17, 58)
        lbDescricaoPagto.Location = New Point(15, 3)
        PanelTeclado.Size = New System.Drawing.Size(240, 447)
        PanelTeclado.Location = New Point(396, 101)
        PanelLista.Location = New Point(660, 101)
        btnConfirmaVenda.Location = New Point(545, 603)
        btnConfirmaVenda.Size = New System.Drawing.Size(113, 60)
        btnConfirmaVenda.Font = New Font("Tahoma", 12, FontStyle.Regular)
        btnConfirmaVenda.Image = GourmetVisual.My.Resources.Resources.Ok
        btnConfirmaVenda.TextAlign = ContentAlignment.BottomCenter
        btnConfirmaVenda.TextImageRelation = TextImageRelation.ImageAboveText
        btnConfirmaVenda.ImageAlign = ContentAlignment.TopCenter
        btnConfirmaVenda.Text = "F7"
        SombraLabel.Location = New Point(560, -8)
        Panel.Size = New System.Drawing.Size(975, 89)
        lbModulo.Location = New Point(800, 57)
    End Sub

    Public Sub carregaVisualComponente(ByVal componente As Object, X3 As Integer, Y3 As Integer)
        regionHandle = New IntPtr(CreateRoundRectRgn(0, 0, componente.Width, componente.Height, X3, Y3))
        componente.Region = Region.FromHrgn(regionHandle)
        componente.Region.ReleaseHrgn(regionHandle)
    End Sub

    Public Sub RecebeVenda(IDvda As Integer)

        Dim DescAcres As Decimal
        Dim Caixinha As Decimal
        Dim Desconto As Decimal = NuloDecimal(tbValorDesconto.Text)
        Dim ContraVale As Decimal
        Dim Troco As Decimal

        If btnTroco.BackColor = Color.LawnGreen Then
            DescAcres = 0
            Caixinha = 0
            ContraVale = 0
            Troco = tbTroco.Text
        Else
            If btnCaixinha.BackColor = Color.LawnGreen Then
                DescAcres = 0
                Caixinha = NuloDecimal(tbTroco.Text)
                ContraVale = 0
                Troco = 0
            Else
                DescAcres = 0
                Caixinha = 0
                ContraVale = NuloDecimal(tbTroco.Text)
                Troco = 0

                strSql = "INSERT tblValesLoja "
                strSql += "(IDVenda,Valor) VALUES ("
                strSql += to_sql(IDvda) & ","
                strSql += to_sql(Replace(ContraVale, ",", ".")) & ")"
                ExecutaStr(strSql)
            End If
        End If


        If Modulo = "D" Then
            strSql = "SELECT Entregador, IDVenda FROM tblVendas WHERE IDVenda=" & IDvda
            If NuloString(PegaValorCampo("Entregador", strSql, strCon)) = "" Then

                Dim frmE As fdlgExpedicao = New fdlgExpedicao
                frmE.tbVenda.Text = tbNumVendaD.Text
                frmE.tbOrigem.Text = "P"
                frmE.ShowDialog()

                If NuloString(EntregadorVenda) = "" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário selecionar um entregador para finalizar esta venda"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbValor.Focus()
                    Exit Sub
                End If
            End If
        End If


        strSql = "UPDATE tblVendas SET "
        strSql += "TotalProdutos=" & Replace(NuloDecimal(tbValorProdutos.Text), ",", ".") & ", "
        strSql += "TotalVenda=" & Replace(NuloDecimal(tbValorVenda.Text), ",", ".") & ", "
        strSql += "Servico=" & Replace(NuloDecimal(tbValorAcrescimo.Text), ",", ".") & ", "
        strSql += "Caixinha=" & Replace(NuloDecimal(Caixinha), ",", ".") & ", "
        strSql += "Desconto=" & Replace(NuloDecimal(Desconto), ",", ".") & ", "
        strSql += "Troco=" & Replace(NuloDecimal(Troco), ",", ".") & ", "
        strSql += "ContraVale=" & Replace(NuloDecimal(ContraVale), ",", ".") & ", "
        strSql += "IDFechamento=" & IDFechamento & ", "
        strSql += "Caixa='" & Caixa & "', "
        strSql += "HoraFechamento='" & Now & "', "
        strSql += "FlagFechada=1, "
        strSql += "IDSat=" & EquipamentoSAT & " "
        strSql += "WHERE IDVenda=" & IDvda
        ExecutaStr(strSql)


        Dim TrocoSaldo As Decimal = Troco
        Dim IDPagto As Integer
        For i As Integer = 0 To lstPagtos.Items.Count - 1
            If UCase(lstPagtos.Items(i).SubItems(3).Text) = "DINHEIRO" And TrocoSaldo > 0 Then
                If TrocoSaldo >= Convert.ToDecimal(lstPagtos.Items(i).SubItems(4).Text) Then
                    TrocoSaldo -= Convert.ToDecimal(lstPagtos.Items(i).SubItems(4).Text)
                    IDPagto = lstPagtos.Items(i).SubItems(5).Text
                    strSql = "DELETE tblVendasPagto WHERE (IDVendaPagto = " & IDPagto & ")"
                    ExecutaStr(strSql)
                Else
                    IDPagto = lstPagtos.Items(i).SubItems(5).Text
                    strSql = "UPDATE tblVendasPagto SET ValorPago=" & Replace(Convert.ToDecimal(lstPagtos.Items(i).SubItems(4).Text) - TrocoSaldo, ",", ".") & " WHERE (IDVendaPagto = " & IDPagto & ")"
                    ExecutaStr(strSql)
                    TrocoSaldo -= Convert.ToDecimal(lstPagtos.Items(i).SubItems(4).Text)
                End If
            End If
        Next
        If TrocoSaldo > 0 Then
            strSql = "INSERT tblVendasPagto "
            strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom) VALUES ("
            strSql += to_sql(tbIDVenda.Text) & ","
            strSql += to_sql(AchaDinheiro) & ","
            strSql += "'DINHEIRO',"
            strSql += to_sql(Replace(TrocoSaldo * -1, ",", ".")) & ","
            strSql += "0,"
            strSql += "0,"
            strSql += "'R',"
            strSql += "0)"
            ExecutaStr(strSql)
        End If


        If Modulo = "S" Then
            strSql = "UPDATE tblMesas Set Flag=0,Impresso=0 WHERE (NumMesa=" & tbMesa.Text & ")"
            ExecutaStr(strSql)
        End If


        If ImpRecibo = True Then
            CriaCupomRecibo(IDvda)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\recibo.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        If NuloDecimal(tbValorVenda.Text) - NuloDecimal(tbTotalPagtosCupom.Text) <> 0 Then
            strSql = "SELECT IDVenda FROM tblVendasSAT WHERE IDVdaPagto=0 and IDVenda=" & tbIDVenda.Text
            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "vda")

            If ds.Tables("vda").Rows.Count > 0 Then
                strSql = "UPDATE tblVendasSAT SET "
                strSql += "ValorCupom = " & to_sql(Replace(NuloDecimal(tbValorVenda.Text) - NuloDecimal(tbTotalPagtosCupom.Text), ",", ".")) & " "
                strSql += "WHERE IDVenda = " & tbIDVenda.Text
                ExecutaStr(strSql)
            Else
                strSql = "INSERT tblVendasSAT "
                strSql += "(IDVenda, ValorCupom) VALUES ("
                strSql += to_sql(tbIDVenda.Text) & ","
                strSql += to_sql(Replace(NuloDecimal(tbValorVenda.Text) - NuloDecimal(tbTotalPagtosCupom.Text), ",", ".")) & ")"
                ExecutaStr(strSql)
            End If

            Dim frm As fdlgCpf_Cnpj = New fdlgCpf_Cnpj
            If ds.Tables("vda").Rows.Count > 0 Then
                strSql = "SELECT IDVendaSAT FROM tblVendasSAT WHERE IDVenda = " & tbIDVenda.Text
                frm.tbIDVendaSAT.Text = PegaValorCampo("IDVendaSAT", strSql, strCon)
            Else
                frm.tbIDVendaSAT.Text = PegaID("IDVendaSAT", "tblVendasSAT", "L")
            End If
            frm.tbIDVenda.Text = IDvda
            frm.tbTotalAD.Text = (tbValorAcrescimo.Text - tbValorDesconto.Text)
            frm.tbTotVenda.Text = tbValorVenda.Text
            frm.tbTotCupom.Text = NuloDecimal(tbValorVenda.Text) - NuloDecimal(tbTotalPagtosCupom.Text)
            If IsDBNull(tbValorTaxaEntrega.Text) Then
                frm.tbTxEntrega.Text = 0
            Else
                frm.tbTxEntrega.Text = tbValorTaxaEntrega.Text
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
            frm.ShowDialog()
        End If

        frmSalao.MontaBotoesMesas()
        VendaBalcaoRecebida = True










        If RegistraLog = True Then
            Dim Texto As String
            strSql = "SELECT IDVenda, NumMesa, NumVenda, TotalVenda FROM tblVendas WHERE (IDVenda=" & IDvda & ")"
            If Modulo = "S" Then
                Texto = "SALÃO: MESA " & PegaValorCampo("NumMesa", strSql, strCon) & " (" & NuloDecimal(PegaValorCampo("TotalVenda", strSql, strCon)) & ")"
            Else
                Texto = "BALCÃO: VENDA " & PegaValorCampo("NumMVenda", strSql, strCon) & " (" & NuloDecimal(PegaValorCampo("TotalVenda", strSql, strCon)) & ")"
            End If
            IncluirLog(NomeTerminal, Operador, "VENDA RECEBIDA", Texto)
        End If

        If TableAtivo = True And Modulo = "S" Then
            InformaStatusTablet(tbMesa.Text)
        End If

        If FixaTela = False Then
            VerificaPagtosDigitais = False
            Me.Dispose()
            Me.Close()
        Else
            Inicio()
        End If


    End Sub
    Public Sub CriaCupomRecibo(IDvda As Integer)
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim campo As String
        Dim Cabec As Boolean = True
        Dim Servico As Decimal
        Dim Desconto As Decimal
        Dim TaxaEntrega As Decimal
        Dim TotalPago As Decimal = 0
        Dim Troco As Decimal
        Dim Caixinha As Decimal

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.TotalVenda, tblVendas.D_A, tblVendas.Dinheiro, tblVendas.Troco, tblVendas.Desconto, tblVendas.Servico, tblVendas.Caixinha, tblVendas.QtdPessoas, tblVendas.Caixa, tblVendas.Atendente, tblVendas.TaxaEntrega, tblVendas.StatusVenda, tblVendasPagto.Descricao, tblVendasPagto.ValorPago "
        strSql += "From tblVendas INNER Join tblVendasPagto On tblVendas.IDVenda = tblVendasPagto.IDVenda "
        strSql += "Where (tblVendas.IDVenda=" & IDvda & ")"
        strSql += "Order By tblVendasPagto.Descricao"

        Try
            FileClose(lngFile)
            FileOpen(lngFile, Application.StartupPath & "\Impressao\recibo.txt", OpenMode.Output)

1:

            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then

                While (dr.Read())
                    If Cabec = True Then
                        Desconto = NuloDecimal(dr.Item("Desconto"))
                        Servico = NuloDecimal(dr.Item("Servico"))
                        TaxaEntrega = NuloDecimal(dr.Item("TaxaEntrega"))
                        Troco = NuloDecimal(dr.Item("Troco"))
                        Caixinha = NuloDecimal(dr.Item("Caixinha"))
                        If dr.Item("StatusVenda") = "S" Then
                            texto = "RECIBO VENDA SALAO"
                        Else
                            If dr.Item("StatusVenda") = "B" Then
                                texto = "RECIBO VENDA BALCAO"
                            Else
                                texto = "RECIBO VENDA DELIVERY"
                            End If
                        End If
                        PrintLine(lngFile, texto)
                        PrintLine(lngFile, "==========================================")
                        PrintLine(lngFile, "Data      :  " & Now)
                        If dr.Item("StatusVenda") = "S" Then
                            PrintLine(lngFile, "Mesa      :  " & dr.Item("NumMesa"))
                        End If
                        PrintLine(lngFile, "Venda     :  " & dr.Item("NumVenda"))
                        PrintLine(lngFile, "Atendenter:  " & dr.Item("Atendente"))
                        PrintLine(lngFile, "Operador  :  " & Operador)
                        If dr.Item("StatusVenda") = "S" Then
                            PrintLine(lngFile, "Servico   :  " & Format(Servico, "#0.00"))
                        End If
                        If dr.Item("StatusVenda") = "D" Then
                            PrintLine(lngFile, "Taxa entr.:  " & Format(TaxaEntrega, "#0.00"))
                        End If
                        PrintLine(lngFile, "Desconto  :  " & Format(Desconto, "#0.00"))
                        PrintLine(lngFile, "Vlr venda :  " & Format(dr.Item("TotalVenda"), "#0.00"))
                        If Troco <> 0 Then
                            PrintLine(lngFile, "Troco     :  " & Format(dr.Item("Troco"), "#0.00"))
                        End If
                        If Caixinha <> 0 Then
                            PrintLine(lngFile, "Caixinha  :  " & Format(dr.Item("Caixinha"), "#0.00"))
                        End If
                        PrintLine(lngFile, "------------------------------------------")
                        Cabec = False
                    End If

                    campo = dr.Item("Descricao") & Space(30 - Len(dr.Item("Descricao").ToString))
                    campo &= "    " & Format(dr.Item("ValorPago"), "#0.00")
                    texto = campo
                    PrintLine(lngFile, texto)
                    If dr.Item("Descricao") = "PENDENCIA" Then
                        strSql = "Select tblPendenciasLoja.IDPendencia, tblPendenciasLoja.IDVendaRet, tblClientes.NomeCliente "
                        strSql += "From tblClientes INNER Join tblPendenciasLoja On tblClientes.IDCliente = tblPendenciasLoja.IDCliente "
                        strSql += "Where (tblPendenciasLoja.IDVenda = " & dr.Item("IDVenda") & ")"
                        texto = PegaValorCampo("NomeCliente", strSql, strCon)
                        PrintLine(lngFile, "   -> " & texto)
                        PrintLine(lngFile, " ")
                    End If
                    TotalPago += dr.Item("ValorPago")
                End While
                PrintLine(lngFile, "==========================================")
                campo = "TOTAL RECEBIDO                    " & Format(TotalPago, "#0.00")
                PrintLine(lngFile, campo)

                If GuilhotinaImpCaixa = False Then
                    PrintLine(lngFile, " ")
                    PrintLine(lngFile, " ")
                    PrintLine(lngFile, " ")
                    PrintLine(lngFile, " ")
                End If
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")

                FileClose(lngFile)
            End If
            dr.Close()
            con.Dispose()
            con.Close()

        Catch ex As Exception
            If InStr(1, ex.Message, "localizar") > 0 Then
                Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\recibo.txt")
                fs.Close()
                GoTo 1
            Else
                MsgBox(ex.Message)
            End If

        End Try


    End Sub

    Public Sub Teclado(Tecla As String)

        If tbValor.Text <> "" Then
            If Not IsNumeric(tbIDVenda.Text) Then
                If tbIDVenda.Text = "" Then
                    If Modulo = "S" Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                        frm.ShowDialog()
                    End If
                    tbValor.Text = ""
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub AchaVenda(Vda As Integer)


        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        'strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.NomeCliente, tblVendas.DataVenda, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.StatusVenda, tblVendas.TaxaEntrega, tblVendas.IDCliente, SUM(tblVendasMovto.Qtd * tblVendasMovto.Venda) As TotalProdutos, SUM(tblVendasMovto.Qtd * tblVendasMovto.VendaServico) As TotalProdutosServico, tblVendasMovto.Excluido, tblVendas.QtdPessoas, tblVendas.NumVendaD, tblRuas.Logradouro, tblVendas.NumeroEntrega, tblVendas.CepEntrega, tblRuas.Bairro, tblVendas.ComplementoEntrega "
        'strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblRuas On tblVendas.IDRuaEntrega = tblRuas.IDRua "
        'strSql += "Where (tblVendas.FlagFechada = 0) And (tblVendas.Excluido = 0) And (tblVendasMovto.Excluido = 0) "
        'strSql += "Group By tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.NomeCliente, tblVendas.DataVenda, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.StatusVenda, tblVendas.TaxaEntrega, tblVendas.IDCliente, tblVendasMovto.Excluido, tblVendas.QtdPessoas, tblVendas.NumVendaD, tblRuas.Logradouro, tblVendas.NumeroEntrega, tblVendas.CepEntrega, tblRuas.Bairro, tblVendas.ComplementoEntrega "
        'If Modulo = "S" Then
        'strSql += "HAVING (tblVendas.NumMesa=" & Vda & ")"
        'End If
        'If Modulo = "B" Then
        'strSql += "HAVING (tblVendas.Numvenda=" & Vda & ")"
        'End If
        'If Modulo = "D" Then
        'strSql += "HAVING (tblVendas.NumvendaD=" & Vda & ")"
        'End If


        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.NomeCliente, tblVendas.DataVenda, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.StatusVenda, tblVendas.TaxaEntrega, tblVendas.IDCliente, tblVendasMovto.Qtd * tblVendasMovto.Venda As TotalProdutos, tblVendasMovto.Qtd * tblVendasMovto.VendaServico As TotalProdutosServico, tblVendasMovto.Excluido, tblVendas.QtdPessoas, tblVendas.NumVendaD, tblRuas.Logradouro, tblVendas.NumeroEntrega, tblVendas.CepEntrega, tblRuas.Bairro, tblVendas.ComplementoEntrega "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblRuas On tblVendas.IDRuaEntrega = tblRuas.IDRua "
        strSql += "Where(tblVendas.FlagFechada = 0) And (tblVendas.Excluido = 0) And (tblVendasMovto.Excluido = 0) "
        If Modulo = "S" Then
            strSql += "And (tblVendas.NumMesa=" & Vda & ")"
        End If
        If Modulo = "B" Then
            strSql += "And (tblVendas.Numvenda=" & Vda & ")"
        End If
        If Modulo = "D" Then
            strSql += "And (tblVendas.NumvendaD=" & Vda & ")"
        End If


        cmd.CommandText = strSql

        Dim NomeCli As String = ""
        Dim Endereco As String = ""
        Dim Numero As String = ""
        Dim Complemento As String = ""
        Dim Bairro As String = ""
        Dim CEP As String = ""
        Dim Texto As String = ""
        Dim Totalpro As Decimal = 0
        Dim TotalproSer As Decimal = 0
        Dim vlrTxEntrega As Decimal = 0
        Dim PercDesc As Decimal = 0
        Dim NumeroMesa As Integer

        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read()
                If Modulo = "D" Then
                    NomeCli = NuloString(dr.Item("NomeCliente"))
                    Endereco = NuloString(dr.Item("Logradouro"))
                    Numero = NuloString(dr.Item("NumeroEntrega"))
                    Complemento = NuloString(dr.Item("ComplementoEntrega"))
                    CEP = NuloString(dr.Item("CepEntrega"))
                    Bairro = NuloString(dr.Item("Bairro"))
                    Texto = NomeCli & vbCrLf & Endereco & ", " & Numero & " " & Complemento & " - " & Bairro & " - " & CEP
                End If
                tbNumVenda.Text = NuloInteger(dr.Item("NumVenda"))
                tbNumVendaD.Text = NuloInteger(dr.Item("NumVendaD"))
                tbIDVenda.Text = NuloInteger(dr.Item("IDVenda"))
                IDVenda = NuloInteger(dr.Item("IDVenda"))
                QtdPessoas = NuloInteger(dr.Item("QtdPessoas"))
                tbMesa.Text = NuloInteger(dr.Item("NumMesa"))
                NumeroMesa = NuloInteger(dr.Item("NumMesa"))
                PercDesc = NuloDecimal(dr.Item("PercDesconto"))
                vlrTxEntrega = NuloDecimal(dr.Item("TaxaEntrega"))

                'Totalpro += NuloDecimal(SemArredondar(dr.Item("TotalProdutos"), 2))
                'TotalproSer += NuloDecimal(SemArredondar(dr.Item("TotalProdutosServico"), 2))
                ''TotalproSer += NuloDecimal(Format(dr.Item("TotalProdutosServico"), "#0.00"))

                'Totalpro += NuloDecimal(Format(dr.Item("TotalProdutos"), "#0.00"))
                Totalpro += NuloDecimal(Format(dr.Item("TotalProdutos"), "#0.00"))
                TotalproSer += NuloDecimal(Format(dr.Item("TotalProdutosServico"), "#0.00"))
                'TotalproSer += NuloDecimal(SemArredondar(dr.Item("TotalProdutosServico"), 2))
            End While



            If ObrigaConta = True And Modulo = "S" Then

                strSql = "Select * FROM tblMesas WHERE NumMesa=" & NumeroMesa
                If PegaValorCampo("Impresso", strSql, strCon) = False Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário imprimir a conta desta Mesa/Cartão"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    cmd.Dispose()
                    dr.Close()
                    con.Dispose()
                    con.Close()

                    lbTextoVenda.Controls.Clear()
                    Dim font_Txtvenda_ As New Font("Tahoma", 12, FontStyle.Bold)
                    Dim lbl_Txtvenda_ As Label = New Label()
                    If DefinicaoReduzida = False Then
                        font_Txtvenda_ = New Font("Tahoma", 12, FontStyle.Bold)
                        lbl_Txtvenda_.Width = 525
                        lbl_Txtvenda_.Height = 23
                        lbl_Txtvenda_.TextAlign = ContentAlignment.TopRight
                    Else
                        font_Txtvenda_ = New Font("Tahoma", 9, FontStyle.Bold)
                        lbl_Txtvenda_.Width = 222
                        lbl_Txtvenda_.Height = 23
                        lbl_Txtvenda_.TextAlign = ContentAlignment.TopLeft
                    End If
                    lbl_Txtvenda_.Text = "Informe " & TextoMesaPAR
                    lbl_Txtvenda_.BackColor = Color.Transparent
                    lbl_Txtvenda_.ForeColor = Color.White
                    lbl_Txtvenda_.Font = font_Txtvenda_
                    lbTextoVenda.Controls.Add(lbl_Txtvenda_)
                    lbModulo.Text = "Salão"
                    tbValor.Text = ""

                    Exit Sub
                End If
            End If

            tbValorProdutos.Text = Totalpro
            tbValorAcrescimo.Text = TotalproSer - Totalpro
            tbValorDesconto.Text = SemArredondar(Totalpro * (PercDesc / 100), 3)
            If vlrTxEntrega = 0 Then
                tbValorTaxaEntrega.Text = "0.00"
            Else
                tbValorTaxaEntrega.Text = vlrTxEntrega
            End If

            tbValorVenda.Text = Format(NuloDecimal(TotalproSer) + NuloDecimal(tbValorTaxaEntrega.Text) - NuloDecimal(tbValorDesconto.Text), "#0.00")

            If NuloDecimal(FatorAjusteServico) <> 0 Then
                If NuloDecimal(tbValorAcrescimo.Text) <> 0 Then
                    lbServicoAjustado.Visible = True
                    lbServicoAjustado.Text = "Serviço ajustado:  " & (NuloDecimal(tbValorAcrescimo.Text) - (NuloDecimal(tbValorAcrescimo.Text) * (NuloDecimal(FatorAjusteServico) / 100))).ToString("#0.00")
                End If
            Else
                lbServicoAjustado.Visible = False
            End If


            ' Campo valor Produtos  //////////////////////////////////////////////////////////////////
            lbValorProdutos.Controls.Clear()
            Dim fontValores As New Font("Courier New", 24, FontStyle.Regular)
            Dim lbl_vlr1 As Label = New Label()
            lbl_vlr1.Width = 340
            lbl_vlr1.Height = 50
            lbl_vlr1.Text = Convert.ToDecimal(tbValorProdutos.Text).ToString("0.00")
            lbl_vlr1.BackColor = Color.Transparent
            lbl_vlr1.ForeColor = Color.Yellow
            lbl_vlr1.Font = fontValores
            lbl_vlr1.TextAlign = ContentAlignment.BottomRight
            lbValorProdutos.Controls.Add(lbl_vlr1)

            ' Campo valor Desconto  //////////////////////////////////////////////////////////////////
            lbValorDescontos.Controls.Clear()
            Dim fontValoresAD As New Font("Courier New", 20, FontStyle.Regular)
            Dim lbl_vlr2 As Label = New Label()
            lbl_vlr2.Width = 340
            lbl_vlr2.Height = 50
            lbl_vlr2.Text = Convert.ToDecimal(tbValorDesconto.Text).ToString("0.00")
            lbl_vlr2.BackColor = Color.Transparent
            lbl_vlr2.ForeColor = Color.Yellow
            lbl_vlr2.Font = fontValoresAD
            lbl_vlr2.TextAlign = ContentAlignment.BottomRight
            lbValorDescontos.Controls.Add(lbl_vlr2)

            ' Campo valor Acrescimo  //////////////////////////////////////////////////////////////////
            Dim lbl_vlr3 As Label = New Label()
            lbValorAcrescimos.Controls.Clear()
            lbl_vlr3.Width = 340
            lbl_vlr3.Height = 50
            If tbValorTaxaEntrega.Text = 0 Then
                lbl_vlr3.Text = Convert.ToDecimal(tbValorAcrescimo.Text).ToString("0.00")
            Else
                lbl_vlr3.Text = Convert.ToDecimal(tbValorTaxaEntrega.Text).ToString("0.00") & " / " & Convert.ToDecimal(tbValorAcrescimo.Text).ToString("0.00")
            End If
            lbl_vlr3.BackColor = Color.Transparent
            lbl_vlr3.ForeColor = Color.Yellow
            lbl_vlr3.Font = fontValoresAD
            lbl_vlr3.TextAlign = ContentAlignment.BottomRight
            lbValorAcrescimos.Controls.Add(lbl_vlr3)

            ' Campo valor Venda  //////////////////////////////////////////////////////////////////
            Dim fontValoresV As New Font("Courier New", 24, FontStyle.Bold)
            Dim lbl_vlr4 As Label = New Label()
            lbValorPagar.Controls.Clear()
            lbl_vlr4.Width = 340
            lbl_vlr4.Height = 50
            lbl_vlr4.Text = Convert.ToDecimal(tbValorVenda.Text).ToString("0.00")
            lbl_vlr4.BackColor = Color.Transparent
            lbl_vlr4.ForeColor = Color.Yellow
            lbl_vlr4.Font = fontValoresV
            lbl_vlr4.TextAlign = ContentAlignment.BottomRight
            lbValorPagar.Controls.Add(lbl_vlr4)

            ' Campo Texto Venda  //////////////////////////////////////////////////////////////////
            lbTextoVenda.Controls.Clear()
            Dim font_Txtvenda As New Font("Tahoma", 12, FontStyle.Bold)
            Dim lbl_Txtvenda As Label = New Label()
            If DefinicaoReduzida = False Then
                font_Txtvenda = New Font("Tahoma", 12, FontStyle.Bold)
                lbl_Txtvenda.Width = 525
                lbl_Txtvenda.Height = 23
                lbl_Txtvenda.TextAlign = ContentAlignment.TopRight
            Else
                font_Txtvenda = New Font("Tahoma", 9, FontStyle.Bold)
                lbl_Txtvenda.Width = 222
                lbl_Txtvenda.Height = 23
                lbl_Txtvenda.TextAlign = ContentAlignment.TopLeft
            End If
            lbl_Txtvenda.Text = "Informe o valor do pagamento"
            lbl_Txtvenda.BackColor = Color.Transparent
            lbl_Txtvenda.ForeColor = Color.White
            lbl_Txtvenda.Font = font_Txtvenda
            lbl_Txtvenda.TextAlign = ContentAlignment.TopCenter
            lbTextoVenda.Controls.Add(lbl_Txtvenda)

            ' Campo Descrição Venda  //////////////////////////////////////////////////////////////////
            'Dim font_Descvenda As New Font("Tahoma", 18, FontStyle.Bold)
            'Dim lbl_Txtvenda1 As Label = New Label()
            lbl_Txtvenda1.Location = New Point(375, 550)
            lbl_Txtvenda1.Width = 300
            lbl_Txtvenda1.Height = 47
            If Modulo = "S" Then
                lbl_Txtvenda1.Text = TextoMesaPAR & ":  " & tbMesa.Text
                lbl_Txtvenda1.Font = font_Descvenda
            End If
            If Modulo = "B" Then
                lbl_Txtvenda1.Text = "Venda:  " & IDVenda
                lbl_Txtvenda1.Font = font_Descvenda
            End If
            If Modulo = "D" Then
                lbl_Txtvenda1.Font = New Font("Tahoma", 11, FontStyle.Regular)
                lbl_Txtvenda1.Text = Texto
                lbl_Txtvenda1.Width = 530
                lbl_Txtvenda1.Height = 60
            End If
            lbl_Txtvenda1.BackColor = Color.Transparent
            lbl_Txtvenda1.ForeColor = Color.LightGreen

            Me.Controls.Add(lbl_Txtvenda1)

            tbValor.Text = ""
            VendaInformada = True
            PreenchelstPagto()
            CalculaTroco()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            If Modulo = "S" Then
                frm.lbMensagem.Text = TextoMesaPAR & " inválida ou sem produtos"
            Else
                frm.lbMensagem.Text = "Esta Venda não contém produtos"
            End If
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            'Inicio()
            tbValor.Text = ""


            If FixaTela = False Then
                If Modulo = "B" Then
                    frmSalao.tbCodigoProduto.Focus()
                Else
                    frmSalao.tbMesa.Focus()
                End If
                VerificaPagtosDigitais = False
                Me.Dispose()
                Me.Close()
            Else
                '    Inicio()
            End If


            'Me.Dispose()
            'Me.Close()
        End If
        tbValor.Focus()

        dr.Close()
        cmd.Dispose()
        con.Close()
    End Sub
    Private Sub PreenchelstPagto()
        Dim item As ListViewItem
        Dim IDp As Integer = 0
        Dim NomeCli As String
        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblVendasPagto.IDVenda, tblFormaPagtos_Local.IDFormaPagto, tblFormaPagtos_Local.CodigoFormaPagto, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblVendasPagto.IDVendaPagto, tblVendasPagto.Cupom, tblVendasPagto.IDCliente, tblClientes.NomeCliente, tblVendasPagto.IDPendencia, IDPagtoDigital, StatusDigital, Terminal "
        strSql += "From tblVendasPagto INNER Join tblFormaPagtos_Local On tblVendasPagto.IDFormaPagto = tblFormaPagtos_Local.IDFormaPagto LEFT OUTER Join tblClientes On tblVendasPagto.IDCliente = tblClientes.IDCliente "
        strSql += "Where (tblVendasPagto.IDVenda = " & tbIDVenda.Text & ") "
        strSql += "Order By tblVendasPagto.Descricao"
        cmd.CommandText = strSql

        lstPagtos.Items.Clear()

        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While dr.Read()
                NomeCli = NuloString(dr.Item("NomeCliente"))
                If NomeCli <> "" Then
                    NomeCli = " (" & Strings.Left(NomeCli, 8) & ")"
                End If

                item = lstPagtos.Items.Add(IDp)
                item.SubItems.Add(dr.Item("IDFormaPagto"))
                item.SubItems.Add(dr.Item("CodigoFormaPagto"))
                item.SubItems.Add(dr.Item("Descricao") & NomeCli)
                item.SubItems.Add(Format(Convert.ToDecimal(dr.Item("ValorPago")), "#0.00"))
                item.SubItems.Add(dr.Item("IDVendaPagto"))
                item.SubItems.Add(dr.Item("Cupom"))
                item.SubItems.Add(NuloInteger(dr.Item("IDCliente")))
                item.SubItems.Add(NuloInteger(dr.Item("IDPendencia")))
                item.SubItems.Add(NuloString(dr.Item("IDPagtoDigital")))
                item.SubItems.Add(NuloString(dr.Item("StatusDigital")))
                item.SubItems.Add(NuloString(dr.Item("Terminal")))
                IDp += 1
            Loop
        End If
        dr.Close()
        cmd.Dispose()
        con.Close()

        If IDp <> 0 Then
            lbQtdeTotal.Text = IDp
        Else
            lbQtdeTotal.Text = ""
        End If

    End Sub
    Private Sub EnviaPagto()

        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        Dim IDVendaPagto As Integer
        Dim Descricao As String = ""
        Dim IDFormaPagto As Integer


        strSql = "Select CodigoFormaPagto, CodigoFiscal, TrocoPadrao, AcionaGaveta, Descricao, IDFormaPagto, Tipo "
        strSql += "From tblFormaPagtos_Local "
        strSql += "WHERE CodigoFormaPagto=" & tbCodigoPagto.Text
        cmd.CommandText = strSql

        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            RetornoPendenciaInclusaoIDPendencia = "0"
            RetornoPendenciaInclusaoIDCliente = "0"
            If dr.Item("Descricao") = "PENDENCIA" Then
                RetornoPendenciaInclusaoIDPendencia = ""
                Dim frm As fdlgPendencias_Inclusao = New fdlgPendencias_Inclusao
                frm.lbValor.Text = NuloDecimal(tbValor.Text)
                frm.tbIDpagto.Text = dr.Item("IDFormaPagto")
                frm.ShowDialog()
                If RetornoPendenciaInclusaoIDPendencia = "" Then Exit Sub
            End If

            strSql = "INSERT tblVendasPagto "
            strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom,IDCliente,IDPendencia) VALUES ("
            strSql += to_sql(tbIDVenda.Text) & ","
            strSql += to_sql(dr.Item("IDFormaPagto")) & ","
            strSql += to_sql(dr.Item("Descricao")) & ","
            strSql += to_sql(Replace(tbValor.Text, ",", ".")) & ","
            strSql += "0,"
            strSql += "0,"
            strSql += "'" & NuloString(dr.Item("Tipo")) & "', "
            strSql += "0,"
            strSql += to_sql(NuloInteger(RetornoPendenciaInclusaoIDCliente)) & ","
            strSql += to_sql(NuloInteger(RetornoPendenciaInclusaoIDPendencia)) & ")"
            ExecutaStr(strSql)


            Descricao = dr.Item("Descricao")
            IDFormaPagto = dr.Item("IDFormaPagto")
            IDVendaPagto = NuloInteger(PegaID("IDVendaPagto", "tblVendasPagto", "L"))

            If IsDBNull(dr.Item("TrocoPadrao")) Then
                tbTrocoPadrao.Text = ""
            Else
                tbTrocoPadrao.Text = dr.Item("TrocoPadrao")
            End If

            lbQtdeTotal.Text = NuloInteger(lbQtdeTotal.Text) + 1

        End If
        dr.Close()
        cmd.Dispose()
        con.Close()

        If Descricao = "PAGAMENTO DIGITAL" Then
            Dim frmPD As fdlgPagamento_CarteiraDigital = New fdlgPagamento_CarteiraDigital
            frmPD.tbIDVenda.Text = tbIDVenda.Text
            frmPD.tbIDVendaPagto.Text = IDVendaPagto
            frmPD.tbValor.Text = tbValor.Text
            frmPD.tbIDFormaPagto.Text = IDFormaPagto
            If NuloDecimal(tbValorVenda.Text) = NuloDecimal(tbValor.Text) Then
                frmPD.tbPagtoIntegral.Text = True
            Else
                frmPD.tbPagtoIntegral.Text = False
            End If
            frmPD.ShowDialog()
        End If


        tbValor.Text = ""
        tbCodigoPagto.Text = ""
        tbDescricaoPagto.Text = ""
        lbDescricaoPagto.Controls.Clear()
        If PanelPagtos.Controls.Count > 0 Then
            For i As Integer = 0 To PanelPagtos.Controls.Count - 1
                PanelPagtos.Controls.Item(i).BackColor = Color.White
            Next i
        End If
        PreenchelstPagto()
        CalculaTroco()





    End Sub
    Private Sub CalculaTroco()

        Dim Vlr As Decimal = 0
        Dim VlrCupom As Decimal = 0
        Dim Troco As Decimal = 0
        If lstPagtos.Items.Count > 0 Then
            For i As Integer = 0 To lstPagtos.Items.Count - 1
                Vlr += lstPagtos.Items(i).SubItems(4).Text
                If NuloBoolean(lstPagtos.Items(i).SubItems(6).Text) = True Then
                    lstPagtos.Items(i).ForeColor = Color.Red
                    VlrCupom += lstPagtos.Items(i).SubItems(4).Text
                Else
                    If NuloString(lstPagtos.Items(i).SubItems(9).Text) <> "" Then
                        If NuloString(lstPagtos.Items(i).SubItems(10).Text) <> "approved" Then
                            lstPagtos.Items(i).ForeColor = Color.Orange
                        Else
                            lstPagtos.Items(i).ForeColor = Color.Magenta
                        End If
                    Else
                        lstPagtos.Items(i).ForeColor = Color.Blue
                    End If
                End If
            Next i
        End If
        lbTotalPagtos.Text = Format(Vlr, "#0.00")
        tbTotalPagtosCupom.Text = VlrCupom


        Troco = Vlr - NuloDecimal(tbValorVenda.Text)

        lbDestino.Visible = False
        btnTroco.Visible = False
        btnCaixinha.Visible = False
        btnContaVale.Visible = False

        If Troco < 0 Then
            lbTroco.BackColor = Color.Red
            lbTroco.Text = "Falta"
            lbTroco.Visible = True

            ' Campo Troco  //////////////////////////////////////////////////////////////////
            Dim font As New Font("Courier New", 24, FontStyle.Bold)
            Dim lbl As Label = New Label()
            lbTroco.Controls.Clear()
            lbl.Height = 67
            If DefinicaoReduzida = False Then
                lbl.Width = 600
                lbTroco.Width = 600
            Else
                lbl.Width = 360
                lbTroco.Width = 360
            End If
            lbl.Text = Convert.ToDecimal(Troco).ToString("0.00")
            lbl.BackColor = Color.Transparent
            lbl.ForeColor = Color.Yellow
            lbl.Font = font
            lbl.TextAlign = ContentAlignment.BottomCenter
            lbTroco.Controls.Add(lbl)
        End If

        If Troco > 0 Then
            lbTroco.BackColor = Color.Green
            lbTroco.Text = "Sobra"
            lbTroco.Visible = True

            lbDestino.Visible = True
            btnTroco.Visible = True
            btnCaixinha.Visible = True
            btnContaVale.Visible = True
            If tbTrocoPadrao.Text = "" Or UCase(tbTrocoPadrao.Text) = "TROCO" Then
                btnTroco.BackColor = Color.LawnGreen
                btnCaixinha.BackColor = Color.White
                btnContaVale.BackColor = Color.White
            Else
                If UCase(tbTrocoPadrao.Text) = "CAIXINHA" Then
                    btnTroco.BackColor = Color.White
                    btnCaixinha.BackColor = Color.LawnGreen
                    btnContaVale.BackColor = Color.White
                Else
                    btnTroco.BackColor = Color.White
                    btnCaixinha.BackColor = Color.White
                    btnContaVale.BackColor = Color.LawnGreen
                End If
            End If

            ' Campo Troco  //////////////////////////////////////////////////////////////////
            Dim font As New Font("Courier New", 24, FontStyle.Bold)
            Dim lbl As Label = New Label()
            lbTroco.Controls.Clear()
            lbl.Height = 67
            If DefinicaoReduzida = False Then
                lbl.Width = 600
                lbTroco.Width = 600
            Else
                lbl.Width = 360
                lbTroco.Width = 360
            End If
            lbl.Text = Convert.ToDecimal(Troco).ToString("0.00")
            lbl.BackColor = Color.Transparent
            lbl.ForeColor = Color.Yellow
            lbl.Font = font
            lbl.TextAlign = ContentAlignment.BottomCenter
            lbTroco.Controls.Add(lbl)
        End If


        If NuloDecimal(FatorAjusteServico) <> 0 Then
            Dim texto As String = "Serviço ajustado: "
            Dim VlrAjust As Decimal = (NuloDecimal(tbValorAcrescimo.Text) - (NuloDecimal(tbValorAcrescimo.Text) * (NuloDecimal(FatorAjusteServico) / 100)))
            If btnCaixinha.BackColor = Color.LawnGreen Then
                If NuloDecimal(Troco) > 0 Then
                    VlrAjust += NuloDecimal(Troco)
                    texto = "Serviço ajustado + caixinha: "
                End If
            End If

            If NuloDecimal(tbValorAcrescimo.Text) <> 0 Then
                lbServicoAjustado.Visible = True
                lbServicoAjustado.Text = texto & VlrAjust.ToString("#0.00")
            End If
        Else
            lbServicoAjustado.Visible = False
        End If



        If Troco = 0 Then lbTroco.Visible = False
        tbTroco.Text = Troco
        tbValor.Focus()

    End Sub
    Private Sub MontaBotoes()

        Dim n As Integer = 0
        Dim TotalReg As Integer = 1
        Dim con As New SqlConnection()

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        PanelPagtos.Controls.Clear()

        strSql = "Select CodigoFormaPagto, CodigoFiscal, TrocoPadrao, AcionaGaveta, Descricao, IDFormaPagto "
        strSql += "From tblFormaPagtos_Local "
        strSql += "Order By Descricao"
        cmd.CommandText = strSql

        ' Try
        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        With dr
            If .HasRows Then
                While (.Read())
                    TotalReg += 1
                End While
            End If
        End With
        dr.Close()

        Dim myfont As New Font("Sans Serif", 9, FontStyle.Bold)
        Dim btnArray(TotalReg) As System.Windows.Forms.Button
        For i As Integer = 0 To TotalReg
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        Dim NLetra As Integer = 65
        Dim con_bt As New SqlConnection()
        Dim dr_bt As SqlDataReader
        con_bt.ConnectionString = strCon
        Dim cmd_bt As SqlCommand = con_bt.CreateCommand
        cmd_bt.CommandText = strSql
        con_bt.Open()
        dr_bt = cmd_bt.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr_bt.HasRows Then

            While (dr_bt.Read())
                With (btnArray(n))
                    .Tag = dr_bt.Item("CodigoFormaPagto")
                    .Text = dr_bt.Item("Descricao") & " - [" & CChar(ChrW(NLetra)) & "]"
                    .Width = 165
                    .Height = 50
                    If dr_bt.Item("Descricao") = "PAGAMENTO DIGITAL" Then
                        .ForeColor = Color.Red
                    Else
                        .ForeColor = Color.Blue
                    End If
                    .BackColor = Color.White
                    .FlatStyle = FlatStyle.Standard
                    .Font = myfont

                    carregaVisualComponente(btnArray(n), 20, 20)

                    Me.PanelPagtos.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Pagtos
                    .Margin = New Padding(0, 0, 0, 0)
                    n += 1
                End With
                NLetra += 1
            End While
        End If
        dr_bt.Close()


        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        con.Close()
        con.Dispose()

        'End Try
    End Sub

    Private Sub ClickButton_Pagtos(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim txtDescricao As String = ""
        If CType(sender, Button).BackColor = Color.White Then
            CType(sender, Button).BackColor = Color.LawnGreen
            tbCodigoPagto.Text = CType(sender, Button).Tag
            tbDescricaoPagto.Text = CType(sender, Button).Text
            txtDescricao = CType(sender, Button).Text
        Else
            CType(sender, Button).BackColor = Color.White
            tbCodigoPagto.Text = ""
            tbDescricaoPagto.Text = ""
            txtDescricao = ""
        End If

        lbDescricaoPagto.Controls.Clear()

        Dim fontDesc As New Font("Tahoma", 14, FontStyle.Regular)
        Dim lbl_DescPg As Label = New Label()
        lbl_DescPg.Width = 506
        lbl_DescPg.Height = 24
        If DefinicaoReduzida = False Then
            lbl_DescPg.TextAlign = ContentAlignment.MiddleCenter
        Else
            lbl_DescPg.TextAlign = ContentAlignment.MiddleLeft
        End If

        Dim SS As Integer = InStr(1, CType(sender, Button).Text, "[")
        lbl_DescPg.Text = Mid(CType(sender, Button).Text, 1, SS - 3)
        lbl_DescPg.BackColor = Color.Transparent
        lbl_DescPg.ForeColor = Color.Yellow
        lbl_DescPg.Font = fontDesc
        lbDescricaoPagto.Controls.Add(lbl_DescPg)


        If PanelPagtos.Controls.Count > 0 Then
            For i As Integer = 0 To PanelPagtos.Controls.Count - 1
                If PanelPagtos.Controls.Item(i).Text <> txtDescricao Then
                    PanelPagtos.Controls.Item(i).BackColor = Color.White
                End If
            Next i
        End If
        tbValor.Focus()

        If GavetaCaixa = True Then
            strSql = "select * FROM tblFormaPagtos_Local WHERE CodigoFormaPagto=" & tbCodigoPagto.Text
            If NuloBoolean(PegaValorCampo("AcionaGaveta", strSql, strCon)) = True Then
                AcionaGaveta()
            End If
        End If


    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        VendaBalcaoRecebida = False
        VerificaPagtosDigitais = True
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub Inicio()
        VendaBalcaoRecebida = False

        lstPagtos.Items.Clear()
        lbServicoAjustado.Text = ""
        tbIDVenda.Text = ""
        tbMesa.Text = ""
        tbValorProdutos.Text = ""
        tbValorAcrescimo.Text = ""
        tbValorDesconto.Text = ""
        tbValorTaxaEntrega.Text = ""
        tbValorVenda.Text = ""
        lbTotalPagtos.Text = ""
        lbTroco.Visible = False
        VendaInformada = False
        lbValorProdutos.Controls.Clear()
        lbValorDescontos.Controls.Clear()
        lbValorAcrescimos.Controls.Clear()
        lbValorPagar.Controls.Clear()
        lbTextoVenda.Controls.Clear()


        lbl_Txtvenda1.Location = New Point(375, 550)
        lbl_Txtvenda1.Width = 300
        lbl_Txtvenda1.Height = 47
        lbl_Txtvenda1.Text = ""
        lbl_Txtvenda1.BackColor = Color.Transparent
        lbl_Txtvenda1.ForeColor = Color.LightGreen
        lbl_Txtvenda1.Font = font_Descvenda
        Me.Controls.Add(lbl_Txtvenda1)

        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)

        carregaVisualComponente(PanelPagtos, 20, 20)
        carregaVisualComponente(PanelTeclado, 20, 20)
        carregaVisualComponente(PanelLista, 20, 20)
        carregaVisualComponente(Panel, 20, 20)
        MontaBotoes()

        Dim font_ As New Font("Tahoma", 11, FontStyle.Regular)
        Dim lbl_ As Label = New Label()
        lbl_.Width = 340
        lbl_.Height = 18
        lbl_.Text = "Destino sobra"
        lbl_.BackColor = Color.Transparent
        lbl_.ForeColor = Color.Maroon
        lbl_.Font = font_
        lbl_.TextAlign = ContentAlignment.TopLeft
        lbDestino.Controls.Add(lbl_)

        If Modulo = "S" Then
            lbTextoVenda.Controls.Clear()
            Dim lbl_Txtvenda As Label = New Label()
            Dim font_Txtvenda As Font
            If DefinicaoReduzida = False Then
                font_Txtvenda = New Font("Tahoma", 12, FontStyle.Bold)
                lbl_Txtvenda.Width = 525
                lbl_Txtvenda.Height = 23
                lbl_Txtvenda.TextAlign = ContentAlignment.TopRight
            Else
                font_Txtvenda = New Font("Tahoma", 9, FontStyle.Bold)
                lbl_Txtvenda.Width = 222
                lbl_Txtvenda.Height = 23
                lbl_Txtvenda.TextAlign = ContentAlignment.TopLeft
            End If
            lbl_Txtvenda.Text = "Informe " & TextoMesaPAR
            lbl_Txtvenda.BackColor = Color.Transparent
            lbl_Txtvenda.ForeColor = Color.White
            lbl_Txtvenda.Font = font_Txtvenda
            lbl_Txtvenda.TextAlign = ContentAlignment.TopCenter
            lbTextoVenda.Controls.Add(lbl_Txtvenda)
            lbModulo.Text = "Salão"
        End If
        If Modulo = "B" Then
            lbModulo.Text = "Balcão"
            AchaVenda(NumMesa)
            VendaInformada = True
        End If
        If Modulo = "D" Then
            lbModulo.Text = "Delivery"
        End If
        tbValor.Focus()
    End Sub
    Private Sub frmPagamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Screen.PrimaryScreen.Bounds.Width < 1280 Then
            DefinicaoReduzida = True
            ReduzDefinicao()
        Else
            DefinicaoReduzida = False
        End If
        VerificaPagtosDigitais = False

        Inicio()

    End Sub

    Private Sub frmPagamento_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.MediumBlue, Color.CornflowerBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub PanelPagtos_Paint(sender As Object, e As PaintEventArgs) Handles PanelPagtos.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub PanelTeclado_Paint(sender As Object, e As PaintEventArgs) Handles PanelTeclado.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub PanelLista_Paint(sender As Object, e As PaintEventArgs) Handles PanelLista.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub lbValorProdutostxt_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lbValorProdutostxt_Paint(sender As Object, e As PaintEventArgs)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub SombraLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SombraLabel1_Paint(sender As Object, e As PaintEventArgs)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)

    End Sub

    Private Sub SombraLabel3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SombraLabel3_Paint(sender As Object, e As PaintEventArgs)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)

    End Sub

    Private Sub SombraLabel2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SombraLabel2_Paint(sender As Object, e As PaintEventArgs)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.Blue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)

    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox_Paint(sender As Object, e As PaintEventArgs)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub


    Private Sub lbValorProdutos_Enter(sender As Object, e As EventArgs) Handles lbValorProdutos.Enter

    End Sub

    Private Sub lbValorProdutos_Paint(sender As Object, e As PaintEventArgs) Handles lbValorProdutos.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.Blue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub lbValorProdutos_Click(sender As Object, e As EventArgs) Handles lbValorProdutos.Click

    End Sub

    Private Sub lbValorDescontos_Click(sender As Object, e As EventArgs) Handles lbValorDescontos.Click

    End Sub

    Private Sub lbValorDescontos_Paint(sender As Object, e As PaintEventArgs) Handles lbValorDescontos.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.Blue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub lbValorAcrescimos_Click(sender As Object, e As EventArgs) Handles lbValorAcrescimos.Click

    End Sub

    Private Sub lbValorAcrescimos_Paint(sender As Object, e As PaintEventArgs) Handles lbValorAcrescimos.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.Blue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub lbValorPagar_Click(sender As Object, e As EventArgs) Handles lbValorPagar.Click

    End Sub

    Private Sub lbValorPagar_Paint(sender As Object, e As PaintEventArgs) Handles lbValorPagar.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.Blue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub lbTextoVenda_Click(sender As Object, e As EventArgs) Handles lbTextoVenda.Click

    End Sub

    Private Sub lbTextoVenda_Paint(sender As Object, e As PaintEventArgs) Handles lbTextoVenda.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub
    Private Sub CliqueNoBotao(texto As String)
        tbValor.Text += texto
    End Sub

    Private Sub lbDescricaoPagto_Paint(sender As Object, e As PaintEventArgs) Handles lbDescricaoPagto.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.Blue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CliqueNoBotao(",")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbValor.Text = ""
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CliqueNoBotao("1")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CliqueNoBotao("2")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CliqueNoBotao("3")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CliqueNoBotao("4")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CliqueNoBotao("5")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CliqueNoBotao("6")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CliqueNoBotao("9")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

        If VendaInformada = True Then
            If tbValor.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Valor inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbValor.Focus()
                Exit Sub
            End If
            If tbCodigoPagto.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar uma forma de pagamento"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbValor.Focus()
                Exit Sub
            End If

            If tbCodigoPagto.Text = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar uma forma de pagamento"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbValor.Focus()
                Exit Sub
            End If

            If tbValor.Text = 0 Then
                Dim VlrPago As Decimal = Convert.ToDecimal(lbTotalPagtos.Text)
                Dim vlrPagar As Decimal = Convert.ToDecimal(tbValorVenda.Text)
                tbValor.Text = (vlrPagar - VlrPago)
            End If

            EnviaPagto()
        Else
            If Modulo = "S" Or Modulo = "D" Then
                AchaVenda(tbValor.Text)
            End If
        End If

    End Sub

    Private Sub lbDescricaoVenda_Paint(sender As Object, e As PaintEventArgs)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.MediumBlue, Color.CornflowerBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles Panel.Paint

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles btnLimpaPagto.Click

        If lstPagtos.SelectedItems.Count > 0 Then
            For i As Integer = 0 To lstPagtos.Items.Count - 1
                If lstPagtos.Items(i).Selected = True Then
                    If NuloBoolean(lstPagtos.Items(i).SubItems(6).Text) = True Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Não será possivel excluir, poi já foi emitido o cupom fiscal deste lançamento"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                    Else
                        If NuloString(lstPagtos.Items(i).SubItems(10).Text) = "approved" Then
                            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                            frm.lbMensagem.Text = "Pagamento digital aprovado, não é possivel excluir"
                            frm.btnNao.Visible = False
                            frm.btnSim.Visible = False
                            frm.btnOK.Visible = True
                            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm.ShowDialog()
                        Else
                            If NuloInteger(lstPagtos.Items(i).SubItems(7).Text) <> 0 Then
                                Dim Saldo As Decimal = NuloDecimal(PegaValorCampo("SaldoCredito", "SELECT IDCliente, SaldoCredito FROM tblClientes WHERE (IDCliente=" & NuloInteger(lstPagtos.Items(i).SubItems(7).Text) & ")", strCon))
                                Saldo += NuloDecimal(lstPagtos.Items(i).SubItems(4).Text)

                                strSql = "UPDATE tblClientes Set SaldoCredito=" & Replace(Saldo, ",", ".") & " WHERE (IDCliente = " & NuloInteger(lstPagtos.Items(i).SubItems(7).Text) & ")"
                                ExecutaStr(strSql)

                                strSql = "Delete From tblPendenciasLoja WHERE (IDPendencia = " & NuloInteger(lstPagtos.Items(i).SubItems(8).Text) & ")"
                                ExecutaStr(strSql)
                            End If

                            Dim IDPagto As Integer
                            IDPagto = lstPagtos.Items(i).SubItems(5).Text
                            strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(IDPagto) & ")"
                            ExecutaStr(strSql)

                            If NuloString(lstPagtos.Items(i).SubItems(9).Text) <> "" Then
                                Dim c As New classShipay()
                                Dim ret = c.deleteOrder(NuloString(lstPagtos.Items(i).SubItems(9).Text))
                            End If

                            PreenchelstPagto()
                            CalculaTroco()

                            Exit For
                        End If
                    End If
                End If
            Next i
        End If

    End Sub
    Private Sub tbValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbValor.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If VendaInformada = False Then
                If Modulo = "S" Or Modulo = "D" Then
                    AchaVenda(tbValor.Text)
                End If
            Else
                If tbValor.Text = "" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Valor inválido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    tbValor.Focus()
                    Exit Sub
                End If
                If tbCodigoPagto.Text = "" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário selecionar uma forma de pagamento"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbValor.Focus()
                    Exit Sub
                End If
                If tbCodigoPagto.Text = 0 Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário selecionar uma forma de pagamento"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbValor.Focus()
                    Exit Sub
                End If
                If tbValor.Text = 0 Then
                    Dim VlrPago As Decimal = Convert.ToDecimal(lbTotalPagtos.Text)
                    Dim vlrPagar As Decimal = Convert.ToDecimal(tbValorVenda.Text)
                    tbValor.Text = (vlrPagar - VlrPago)
                End If
                EnviaPagto()
            End If
        End If

        If e.KeyChar = "*" Then
            e.Handled = True


            If NuloDecimal(tbValor.Text) <> 0 And VendaInformada = True And NuloString(tbDescricaoPagto.Text) <> "" Then
                Dim frm As fdlgCalculadoraFormaPagto = New fdlgCalculadoraFormaPagto
                frm.lbFormaPagto.Text = lbDescricaoPagto.Controls.Item(0).Text
                frm.lbValor.Text = Format(NuloDecimal(tbValor.Text), "#0.00")
                frm.tbMultiplicador.Text = "1"
                frm.lbTotal.Text = Format(NuloDecimal(tbValor.Text), "#0.00")
                frm.ShowDialog()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário informar a venda"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbValor.Focus()
            End If

        End If


    End Sub

    Private Sub tbValor_KeyUp(sender As Object, e As KeyEventArgs) Handles tbValor.KeyUp
        If tbValor.Text <> "" Then
            If Not IsNumeric(tbValor.Text) Then
                If tbIDVenda.Text = "" Then
                    If Modulo = "S" Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                    End If
                    tbValor.Text = ""
                    Exit Sub
                Else
                    Dim descPagto As String = ""
                    Dim IDPagto As Integer
                    Dim Numtec As Integer = e.KeyValue - 65
                    If PanelPagtos.Controls.Count > 0 Then
                        For i As Integer = 0 To PanelPagtos.Controls.Count - 1
                            PanelPagtos.Controls.Item(i).BackColor = Color.White
                            If Numtec = i Then
                                descPagto = PanelPagtos.Controls.Item(i).Text
                                IDPagto = PanelPagtos.Controls.Item(i).Tag
                            End If
                        Next i
                    End If

                    tbCodigoPagto.Text = IDPagto
                    tbDescricaoPagto.Text = descPagto

                    lbDescricaoPagto.Controls.Clear()
                    Dim fontDesc As New Font("Tahoma", 14, FontStyle.Regular)
                    Dim lbl_DescPg As Label = New Label()
                    lbl_DescPg.Width = 525
                    lbl_DescPg.Height = 24

                    Dim SS As Integer = InStr(1, descPagto, "[")
                    If SS > 0 Then
                        lbl_DescPg.Text = Mid(descPagto, 1, SS - 3)
                    Else
                        lbl_DescPg.Text = ""
                    End If

                    lbl_DescPg.BackColor = Color.Transparent
                    lbl_DescPg.ForeColor = Color.Yellow
                    lbl_DescPg.Font = fontDesc
                    If DefinicaoReduzida = False Then
                        lbl_DescPg.TextAlign = ContentAlignment.MiddleCenter
                    Else
                        lbl_DescPg.TextAlign = ContentAlignment.MiddleLeft
                    End If
                    lbDescricaoPagto.Controls.Add(lbl_DescPg)

                    If PanelPagtos.Controls.Count > 0 Then
                        For i As Integer = 0 To PanelPagtos.Controls.Count - 1
                            If PanelPagtos.Controls.Item(i).Text = descPagto Then
                                PanelPagtos.Controls.Item(i).BackColor = Color.LawnGreen
                            End If
                        Next i
                    End If
                    tbValor.Text = ""

                End If
            End If
        End If
    End Sub

    Private Sub lbDestino_Paint(sender As Object, e As PaintEventArgs) Handles lbDestino.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.White, Color.MediumBlue, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub btnTroco_Click(sender As Object, e As EventArgs) Handles btnTroco.Click
        btnTroco.BackColor = Color.LawnGreen
        btnCaixinha.BackColor = Color.White
        btnContaVale.BackColor = Color.White
        tbTrocoPadrao.Text = "Troco"
        CalculaTroco()
    End Sub

    Private Sub btnCaixinha_Click(sender As Object, e As EventArgs) Handles btnCaixinha.Click
        btnTroco.BackColor = Color.White
        btnCaixinha.BackColor = Color.LawnGreen
        btnContaVale.BackColor = Color.White
        tbTrocoPadrao.Text = "Caixinha"
        CalculaTroco()
    End Sub

    Private Sub btnContaVale_Click(sender As Object, e As EventArgs) Handles btnContaVale.Click
        btnTroco.BackColor = Color.White
        btnCaixinha.BackColor = Color.White
        btnContaVale.BackColor = Color.LawnGreen
        tbTrocoPadrao.Text = "Contra-Vale"
        CalculaTroco()
    End Sub

    Function AchaDinheiro()
        Dim Retorno As Integer
        Dim conA As New SqlConnection()
        conA.ConnectionString = strCon
        Dim cmdA As SqlCommand = conA.CreateCommand

        strSql = "Select CodigoFormaPagto, CodigoFiscal, TrocoPadrao, AcionaGaveta, Descricao, IDFormaPagto "
        strSql += "From tblFormaPagtos_Local "
        strSql += "WHERE Descricao='DINHEIRO'"
        cmdA.CommandText = strSql

        conA.Open()
        Dim drA As SqlDataReader
        drA = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drA.HasRows Then
            drA.Read()
            Retorno = drA.Item("IDFormaPagto")
        End If
        drA.Close()
        cmdA.Dispose()
        conA.Close()

        Return Retorno
    End Function

    Private Sub btnConfirmaVenda_Click(sender As Object, e As EventArgs) Handles btnConfirmaVenda.Click

        If tbIDVenda.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Venda inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If tbTroco.Text < 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Impossivel receber" & vbCrLf & "faltando  " & NuloDecimal(tbTroco.Text * -1).ToString("C2")
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloString(AccessKey_Shipay) <> "" Or NuloString(SecretKey_Shipay) <> "" Then
            strSql = "Select IDVendaPagto, IDVenda, StatusDigital From tblVendasPagto Where (StatusDigital<>'approved') And (IDVenda = " & tbIDVenda.Text & ")"
            If NuloInteger(PegaValorCampo("IDVendaPagto", strSql, strCon)) <> 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Existe pagamento digital ainda não aprovado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If
        End If

        'If IDFechamento = 0 Then
        strSql = "Select IDFechamento, Turno, Confirmado, IDFuncionario, DiaMovimento, Caixa From tblFechamentos_Local Where (Confirmado=0) And (IDFuncionario = " & IDOperador & ")"
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            IDFechamento = dr.Item("IDFechamento")
            IDCaixa = dr.Item("IDFuncionario")
            Caixa = dr.Item("Caixa")
            DiaMovto = dr.Item("DiaMovimento") & "   (" & dr.Item("IDFechamento") & ")"
            frmPrincipal.tbDiaMovto.Text = dr.Item("DiaMovimento")
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Operador (" & Operador & ") sem permissão ou movimento não aberto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()
        'End If

        strSql = "Select IDFuncionario, ModulosCaixa From tblFuncionarios_Local Where (IDFuncionario = " & IDOperador & ")"
        Dim ModCx As String = NuloString(PegaValorCampo("ModulosCaixa", strSql, strCon))
        If NuloString(ModCx) <> "" Then
            If NuloString(ModCx) <> "T" Then
                If Modulo = "B" Then
                    If InStr(1, NuloString(ModCx), "B") = 0 Then
                        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                        frm1.lbMensagem.Text = "Operador (" & Operador & ") sem permissão para finalizar venda no módulo BALCÃO"
                        frm1.btnNao.Visible = False
                        frm1.btnSim.Visible = False
                        frm1.btnOK.Visible = True
                        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm1.ShowDialog()
                        Exit Sub
                    End If
                End If
                If Modulo = "S" Then
                    If InStr(1, NuloString(ModCx), "S") = 0 Then
                        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                        frm1.lbMensagem.Text = "Operador (" & Operador & ") sem permissão para finalizar venda no módulo SALÃO"
                        frm1.btnNao.Visible = False
                        frm1.btnSim.Visible = False
                        frm1.btnOK.Visible = True
                        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm1.ShowDialog()
                        Exit Sub
                    End If
                End If
            End If
        End If



        RecebeVenda(tbIDVenda.Text)
        VendaBalcaoRecebida = True

        If Modulo = "B" Then
            If ImprimeConferenciaBalcao = True Then
                ConferenciaBalcao(tbIDVenda.Text)
                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\conta.txt")
                If GuilhotinaImpCaixa = True Then
                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
                End If
            End If
        End If

    End Sub


    Private Sub frmPagamento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.KeyCode.F1
                Me.InvokeOnClick(btnTroco, e)

            Case Keys.KeyCode.F2
                Me.InvokeOnClick(btnCaixinha, e)

            Case Keys.KeyCode.F3
                Me.InvokeOnClick(btnContaVale, e)

            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirmaVenda, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVoltar, e)

            Case Keys.KeyCode.G
                AcionaGaveta()

        End Select

    End Sub

    Private Sub btnCupomParcial_Click(sender As Object, e As EventArgs) Handles btnCupomParcial.Click

        If lstPagtos.SelectedItems.Count > 0 Then
            If NuloBoolean(lstPagtos.SelectedItems(0).SubItems(6).Text) = True Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Este pagamento já foi emitido o cupom fiscal"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If



            If IDFechamento = 0 Then
                strSql = "Select IDFechamento, Turno, Confirmado, IDFuncionario, DiaMovimento, Caixa From tblFechamentos_Local Where (Confirmado=0) And (IDFuncionario = " & IDOperador & ")"
                Dim con As New SqlConnection()
                Dim dr As SqlDataReader

                con.ConnectionString = strCon
                Dim cmd As SqlCommand = con.CreateCommand
                cmd.CommandText = strSql

                con.Open()
                dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

                If dr.HasRows Then
                    dr.Read()
                    IDFechamento = dr.Item("IDFechamento")
                    IDCaixa = dr.Item("IDFuncionario")
                    Caixa = dr.Item("Caixa")
                    DiaMovto = dr.Item("DiaMovimento") & "   (" & dr.Item("IDFechamento") & ")"
                    frmPrincipal.tbDiaMovto.Text = dr.Item("DiaMovimento")
                Else
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Operador (" & Operador & ") sem permissão ou movimento não aberto"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    Exit Sub
                End If
                dr.Close()
                cmd.Dispose()
                con.Dispose()
                con.Close()
            End If



            Dim ValorCupom As Decimal = NuloDecimal(lstPagtos.SelectedItems(0).SubItems(4).Text)
            Dim IDFormaPagto As Decimal = NuloInteger(lstPagtos.SelectedItems(0).SubItems(1).Text)
            Dim IDVdaPagto As Decimal = NuloInteger(lstPagtos.SelectedItems(0).SubItems(5).Text)
            Dim IDVdaSat As Decimal = NuloInteger(lstPagtos.SelectedItems(0).SubItems(0).Text)

            If ModoFiscal = "SAT" Then
                strSql = "SELECT IDVendaSAT, IDVdaPagto FROM tblVendasSAT WHERE IDVdaPagto=" & IDVdaPagto
                IDVdaSat = NuloInteger(PegaValorCampo("IDVendaSAT", strSql, strCon))

                If IDVdaSat <> 0 Then
                    strSql = "UPDATE tblVendasSAT SET "
                    strSql += "IDVenda=" & tbIDVenda.Text & ", "
                    strSql += "ValorCupom=" & Replace(tbValorVenda.Text, ",", ".") & " "
                    strSql += "WHERE IDVdaPagto=" & IDVdaPagto
                    ExecutaStr(strSql)
                Else
                    strSql = "INSERT tblVendasSAT "
                    strSql += "(IDVenda, ValorCupom) VALUES ("
                    strSql += to_sql(tbIDVenda.Text) & ","
                    strSql += to_sql(Replace(tbValorVenda.Text, ",", ".")) & ")"
                    ExecutaStr(strSql)
                    IDVdaSat = NuloInteger(PegaID("IDVendaSAT", "tblVendasSAT", "L"))
                End If

                Dim frm As fdlgCpf_Cnpj = New fdlgCpf_Cnpj
                frm.tbIDVendaSAT.Text = IDVdaSat
                frm.tbIDVenda.Text = tbIDVenda.Text
                frm.tbTotalAD.Text = (tbValorAcrescimo.Text - tbValorDesconto.Text)
                frm.tbTotVenda.Text = tbValorVenda.Text
                frm.tbTotCupom.Text = ValorCupom
                frm.tbIDVendaPagto.Text = IDVdaPagto
                If IsDBNull(tbValorTaxaEntrega.Text) Then
                    frm.tbTxEntrega.Text = 0
                Else
                    frm.tbTxEntrega.Text = tbValorTaxaEntrega.Text
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
                frm.ShowDialog()


                strSql = "Select IDVdaPagto, Enviado, Status From tblVendasSAT Where (IDVdaPagto = " & IDVdaPagto & ")"
                If NuloString(PegaValorCampo("Status", strSql, strCon)) = "E" Then
                    strSql = "UPDATE tblVendasPagto SET "
                    strSql += "Cupom=1 "
                    strSql += "WHERE IDVendaPagto=" & IDVdaPagto
                    ExecutaStr(strSql)
                End If

                PreenchelstPagto()
                CalculaTroco()
            End If

        Else
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "É necessário selecionar um pagamento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End If

    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If VendaInformada = False Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = TextoMesaPAR & " não informado"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        Else
            frmSalao.tbMesa.Text = tbMesa.Text
            fdlgConta.ShowDialog()
            If Modulo = "S" Then
                AchaVenda(tbMesa.Text)
            Else
                AchaVenda(tbNumVenda.Text)
            End If

        End If
        tbValor.Focus()


    End Sub

    Private Sub btnFixaTela_Click(sender As Object, e As EventArgs) Handles btnFixaTela.Click
        If FixaTela = False Then
            btnFixaTela.Image = GourmetVisual.My.Resources.Resources.Lock2
            FixaTela = True
        Else
            btnFixaTela.Image = GourmetVisual.My.Resources.Resources.Lock_Open2
            FixaTela = False
        End If
        tbValor.Focus()
    End Sub

    Private Sub btnLimpa_Click(sender As Object, e As EventArgs) Handles btnLimpa.Click
        Inicio()
        tbValor.Focus()
    End Sub

    Private Sub tbValor_TextChanged(sender As Object, e As EventArgs) Handles tbValor.TextChanged

    End Sub

    Private Sub Button16_Click_1(sender As Object, e As EventArgs) Handles Button16.Click
        If OperadorEstorna = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Sem permissão para estorno"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        Else
            If VendaInformada = False Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = TextoMesaPAR & " não informado"
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm1.ShowDialog()
            Else
                fdlgEstorno.ShowDialog()
                If Modulo = "S" Then
                    AchaVenda(tbMesa.Text)
                Else
                    AchaVenda(tbNumVenda.Text)
                End If
            End If
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If OperadorTransfere = False Then
            frm.lbMensagem.Text = "Sem permissão para transferência"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        Else
            If VendaInformada = False Then
                frm.lbMensagem.Text = TextoMesaPAR & " não informado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            Else
                frmSalao.tbMesa.Text = tbMesa.Text
                fdlgTransferencias.ShowDialog()
                If Modulo = "S" Then
                    AchaVenda(tbMesa.Text)
                Else
                    AchaVenda(tbNumVenda.Text)
                End If
            End If
        End If
    End Sub

    Private Sub LstPagtos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPagtos.SelectedIndexChanged

    End Sub

    Private Sub BtnCalculadora_Click(sender As Object, e As EventArgs) Handles btnCalculadora.Click
        System.Diagnostics.Process.Start("calc.exe")
        tbValor.Focus()
    End Sub
End Class
