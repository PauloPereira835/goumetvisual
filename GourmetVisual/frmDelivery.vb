Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'Imports System.Windows.Forms.VisualStyles.TextShadowType

Public Class frmDelivery
    Dim Tempo As Integer = 0

    Private Sub PreencheListaPagto(IDvda As Integer)
        Dim VlrTotal As Decimal = 0
        Dim item As ListViewItem
        Dim strSql As String
        lstPagtosVenda.Items.Clear()

        Dim con As New SqlConnection(strCon)

        strSql = "Select IDVendaPagto, IDVenda, IDFormaPagto, Descricao, ValorPago "
        strSql += "From tblVendasPagto "
        strSql += "Where (IDVenda = " & IDvda & ") "
        strSql += "Order By Descricao"

        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                item = lstPagtosVenda.Items.Add(dr.Item("IDVendaPagto"))
                item.SubItems.Add(NuloInteger(dr.Item("IDFormaPagto")))
                item.SubItems.Add(NuloString(dr.Item("Descricao")))
                item.SubItems.Add(Format(NuloDecimal(dr.Item("ValorPago")), "#0.00"))
                VlrTotal += NuloDecimal(dr.Item("ValorPago"))
            End While
        End If

        tbTotalPagto.Text = VlrTotal

        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()


    End Sub
    Public Sub VerificaPedidosProgramados()

        strSql = "Select IDVenda, PedidoProg, PedidoProgEnviado, PedidoProgAutomatico, PedidoProgEnvioAs "
        strSql += "From tblVendas "
        strSql += "Where (PedidoProg = 1) And (PedidoProgEnviado = 0 Or PedidoProgEnviado Is NULL) ORDER BY PedidoProgEnvioAs DESC"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If NuloBoolean(ds.Tables("Vendas").Rows(i).Item("PedidoProgAutomatico")) = True Then

                If ds.Tables("Vendas").Rows(i).Item("PedidoProgEnvioAs") < Now Then

                    CriaExpedicao(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVenda")))
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

                    strSql = "UPDATE tblVendasMovto SET Impresso=0 WHERE IDVenda=" & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVenda"))
                    ExecutaStr(strSql)

                    strSql = "UPDATE tblVendas SET PedidoProgEnviado=1 WHERE IDVenda=" & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVenda"))
                    ExecutaStr(strSql)
                End If
            End If
        Next
        dap.Dispose()
        ds.Clear()
        ds.Dispose()


    End Sub
    Public Sub CriaExpedicao(IDvda As Integer)

        If IDvda = 0 Then Exit Sub

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim Troco As String = 0
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim VlrProTxt As String
        Dim ComentExp As String
        Dim VlrDescTxt As String
        Dim SerTxt As String
        Dim IDvdaCombo As Integer
        Dim IDvdaMovtoCombo As Integer
        Dim IDvdaMovto As Integer
        Dim NumVenda As Integer
        Dim PNota As Integer
        Dim TaxaEntrega As Decimal
        Dim Caixinha As Decimal
        Dim FormaPagto As String
        Dim RuaPagto As String
        Dim NumeroPagto As String
        Dim ComplementoPagto As String
        Dim CEPPagto As String
        Dim BairroPagto As String
        Dim PagtoDiferente As Boolean
        con.ConnectionString = strCon
1:

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblVendas.NomeCliente, tblRuas.Logradouro, tblVendas.NumeroEntrega, tblVendas.CepEntrega, tblVendas.ComplementoEntrega, tblVendas.ReferenciaEntrega, tblVendas.Entregador, tblVendas.TaxaEntrega, tblVendas.Caixinha, tblVendas.AreaEntrega, tblVendas.ComentExpedicao, tblVendas.NumVendaD, tblVendas.Troco, tblClientes.IDExterno, tblClientes.Tel1, tblClientes.CPF_CNPJ, tblVendas.PreNota, tblRuas.Bairro, tblVendas.PedidoProgAutomatico, tblVendas.PedidoProgEnvioAs, tblVendas.TipoLancto, tblVendas.CpfCnpj, tblVendasMovto.IDVendaMovto, tblVendas.CepPagto, tblVendas.NumeroPagto, tblVendas.ComplementoPagto, tblVendas.EnderecoPagtoDiferente, tblVendas.RuaPagto, tblVendas.BairroPagto, tblVendas.LogradouroEntrega "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblClientes On tblVendas.IDCliente = tblClientes.IDCliente INNER Join tblRuas On tblVendas.IDRuaEntrega = tblRuas.IDRua LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblVendas.NomeCliente, tblRuas.Logradouro, tblVendas.NumeroEntrega, tblVendas.CepEntrega, tblVendas.ComplementoEntrega, tblVendas.ReferenciaEntrega, tblVendas.Entregador, tblVendas.TaxaEntrega, tblVendas.Caixinha, tblVendas.AreaEntrega, tblVendas.ComentExpedicao, tblVendas.NumVendaD, tblVendas.Troco, tblClientes.IDExterno, tblClientes.Tel1, tblClientes.CPF_CNPJ, tblVendas.PreNota, tblRuas.Bairro, tblVendas.PedidoProgAutomatico, tblVendas.PedidoProgEnvioAs, tblVendas.TipoLancto, tblVendas.CpfCnpj, tblVendasMovto.IDVendaMovto, tblVendas.CepPagto, tblVendas.NumeroPagto, tblVendas.ComplementoPagto, tblVendas.EnderecoPagtoDiferente, tblVendas.RuaPagto, tblVendas.BairroPagto, tblVendas.LogradouroEntrega "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        strSql += "ORDER BY tblVendasCombo.IDVendaCombo, tblVendasMovto.Produto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))


        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            NumVenda = NuloString(ds.Tables("Vendas").Rows(0).Item("NumVendaD"))
            Caixinha = NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Caixinha"))
            TaxaEntrega = NuloDecimal(ds.Tables("Vendas").Rows(0).Item("TaxaEntrega"))
            Troco = NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Troco"))
            ComentExp = NuloString(ds.Tables("Vendas").Rows(0).Item("ComentExpedicao"))

            RuaPagto = NuloString(ds.Tables("Vendas").Rows(0).Item("RuaPagto"))
            NumeroPagto = NuloString(ds.Tables("Vendas").Rows(0).Item("NumeroPagto"))
            ComplementoPagto = NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoPagto"))
            CEPPagto = NuloString(ds.Tables("Vendas").Rows(0).Item("CepPagto"))
            BairroPagto = NuloString(ds.Tables("Vendas").Rows(0).Item("BairroPagto"))
            PagtoDiferente = NuloBoolean(ds.Tables("Vendas").Rows(0).Item("EnderecoPagtoDiferente"))

            Try
                PNota = NuloString(ds.Tables("Vendas").Rows(0).Item("PreNota"))
            Catch ex As Exception
                MsgBox("O campo PreNota na tabela tblVendas não pode ser Boolean e sim Integer")
                Exit Sub
            End Try

            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            'PrintLine(lngFile, Chr(27) + Chr(14) & "DELIVERY" & Chr(27) + Chr(14))
            'PrintLine(lngFile, Chr(27) + Chr(14) & "Pedido " & NumVenda & Chr(27) + Chr(14))
            PrintLine(lngFile, "DELIVERY")
            PrintLine(lngFile, "Pedido " & NumVenda)
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            'PrintLine(lngFile, Chr(27) + Chr(14) & NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")) & Chr(27) + Chr(14))
            PrintLine(lngFile, NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")))
            PrintLine(lngFile, "------------------------------------------")
            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PedidoProgAutomatico")) = True Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, "PEDIDO PROGRAMADO PARA: " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("PedidoProgEnvioAs"), "HH:mm:ss")))
                PrintLine(lngFile, " ")
                PrintLine(lngFile, "------------------------------------------")
            End If
            If PNota > 1 Then
                PrintLine(lngFile, "REIMPRESSAO  " & PNota)
                PrintLine(lngFile, "------------------------------------------")
            End If

            If NuloBoolean(ds.Tables("Vendas").Rows(0).Item("TipoLancto")) = True Then
                PrintLine(lngFile, "          <<< CUPOM FISCAL >>>")
                PrintLine(lngFile, NuloString(ds.Tables("Vendas").Rows(0).Item("CpfCnpj")))
                PrintLine(lngFile, "------------------------------------------")
            End If

            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente")))
            PrintLine(lngFile, texto)
            'texto = Chr(27) + Chr(14) & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("LogradouroEntrega"))) & ", " & Chr(27) + Chr(14)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("LogradouroEntrega"))) & ", "
            PrintLine(lngFile, texto)
            'texto = Chr(27) + Chr(14) & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("NumeroEntrega"))) & Chr(27) + Chr(14)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("NumeroEntrega")))
            PrintLine(lngFile, texto)
            'If Len(texto) <= 22 Then
            ' texto = Chr(27) + Chr(14) & texto & Chr(27) + Chr(14)
            ' PrintLine(lngFile, texto)
            'Else
            'If Len(texto) <= 44 Then
            'texto = Chr(27) + Chr(14) & Strings.Left(texto, 22) & Chr(27) + Chr(14)
            'PrintLine(lngFile, texto)
            'texto = Chr(27) + Chr(14) & Strings.Right(texto, Len(texto) - 24) & Chr(27) + Chr(14)
            'PrintLine(lngFile, texto)
            'Else
            'texto = Chr(27) + Chr(14) & Strings.Left(texto, 22) & Chr(27) + Chr(14)
            'PrintLine(lngFile, texto)
            'texto = Chr(2'7) + Chr(14) & Mid(texto, 23, 22) & Chr(27) + Chr(14)
            'PrintL 'ine(lngFile, texto)

            'texto = Chr(27) + Chr(14) & Strings.Right(texto, Len(texto) - 44) & Chr(27) + Chr(14)
            'PrintLine(lngFile, texto)
            'End If
            'End If

            If NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega")) <> "" Then
                'texto = Chr(27) + Chr(14) & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega"))) & Chr(27) + Chr(14)
                texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega")))
                PrintLine(lngFile, texto)
            End If
            If NuloString(ds.Tables("Vendas").Rows(0).Item("ReferenciaEntrega")) <> "" Then
                'texto = Chr(27) + Chr(14) & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("ReferenciaEntrega"))) & Chr(27) + Chr(14)
                texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("ReferenciaEntrega")))
                PrintLine(lngFile, texto)
            End If
            'texto = Chr(27) + Chr(14) & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Bairro"))) & Chr(27) + Chr(14)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Bairro")))
            PrintLine(lngFile, texto)
            texto = "CEP: " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("CepEntrega")))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "------------------------------------------")
            If NuloString(ds.Tables("Vendas").Rows(0).Item("Tel1")) <> "" Then
                texto = "Telefone       : " & NuloString(ds.Tables("Vendas").Rows(0).Item("Tel1"))
                PrintLine(lngFile, texto)
            End If
            If NuloString(ds.Tables("Vendas").Rows(0).Item("IDExterno")) <> "" Then
                texto = "Codigo Externo : " & NuloString(ds.Tables("Vendas").Rows(0).Item("IDExterno"))
                PrintLine(lngFile, texto)
            End If
            If NuloString(ds.Tables("Vendas").Rows(0).Item("CPF_CNPJ")) <> "" Then
                texto = "Cpf/cnpj       : " & NuloString(ds.Tables("Vendas").Rows(0).Item("CPF_CNPJ"))
                PrintLine(lngFile, texto)
            End If
            PrintLine(lngFile, "------------------------------------------")
            texto = "Atendente : " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Atendente")))
            PrintLine(lngFile, texto)
            'texto = "Periodo   : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("HoraAbertura"), "HH:mm")) & "/" & NuloString(Format(Now, "hh:mm")) & "    " & NuloString(Format(Now, FormatoDataLocal))
            texto = "Data      : " & NuloString(Format(Format(ds.Tables("Vendas").Rows(0).Item("DataVenda"), FormatoDataLocal)) & "  " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("DataVenda"), "HH:mm")))
            PrintLine(lngFile, texto)
            texto = "Venda     : " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumVendaD"))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "------------------------------------------")
            texto = "Controle interno sem valor fiscal"
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Descricao          Qtde.   Unit.    Total ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1
                IDvdaMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                texto = Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")))
                If Len(texto) <= 18 Then
                    texto = texto & Space(18 - Len(texto))
                Else
                    texto = Strings.Left(texto, 18)
                End If

                If Int(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))) = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) Then
                    texto &= Space(6 - Len(NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde"))))) & NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde")))
                Else
                    texto &= " " & NuloString(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                End If
                texto &= Space(8 - Len(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")))) & NuloString(ds.Tables("Vendas").Rows(i).Item("Venda"))
                Valor = Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")), "#0.00")
                texto &= Space(10 - Len(NuloString(Valor))) & NuloString(Valor)
                PrintLine(lngFile, texto)
                VlrPro += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                VlrSer += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))

                If NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" Then
                    IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                    If NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) = "" Then
                        texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                        PrintLine(lngFile, texto)
                    End If

                    If i <= ds.Tables("Vendas").Rows.Count - 1 Then
                        Do While NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" And IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                            texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                            PrintLine(lngFile, texto)

                            If MostraComentExpedicao = True Then
                                IDvdaMovtoCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                                strSql = "Select IDVendaCombo, Coment "
                                strSql += "From tblVendasComent "
                                strSql += "Where (IDVendaCombo = " & IDvdaMovtoCombo & ")"
                                Dim dapCC = New SqlDataAdapter(strSql, strCon)
                                dapCC.SelectCommand.CommandType = CommandType.Text
                                Dim dsCC As New DataSet()
                                dapCC.Fill(dsCC, "Coment")
                                For iCC As Integer = 0 To dsCC.Tables("Coment").Rows.Count - 1
                                    texto = "    ---> " & Trim(NuloString(dsCC.Tables("Coment").Rows(iCC).Item("Coment")))
                                    PrintLine(lngFile, texto)
                                Next
                            End If


                            i += 1
                            If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                        Loop
                    Else
                        i += 1
                    End If
                Else
                    i += 1
                End If

                If MostraComentExpedicao = True Then
                    strSql = "Select IDVendaMovto, Coment "
                    strSql += "From tblVendasComent "
                    strSql += "Where (IDVendaMovto = " & IDvdaMovto & ")"
                    Dim dapCC = New SqlDataAdapter(strSql, strCon)
                    dapCC.SelectCommand.CommandType = CommandType.Text
                    Dim dsCC As New DataSet()
                    dapCC.Fill(dsCC, "Coment")
                    For iCC As Integer = 0 To dsCC.Tables("Coment").Rows.Count - 1
                        texto = ">>>> " & Trim(NuloString(dsCC.Tables("Coment").Rows(iCC).Item("Coment")))
                        PrintLine(lngFile, texto)
                    Next
                End If
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, "==========================================")
            VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")
            PrintLine(lngFile, "Sub-total " & Space(32 - Len(VlrProTxt)) & VlrProTxt)
            SerTxt = Trim(Format(NuloDecimal(TaxaEntrega), "#0.00"))
            texto = "Taxa Entrega"
            texto = texto & Space(23 - Len(NuloString(texto))) & Space(19 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            PrintLine(lngFile, texto)

            If NuloDecimal(Caixinha) > 0 Then
                SerTxt = Trim(Format(NuloDecimal(Caixinha), "#0.00"))
                texto = "Caixinha"
                texto = texto & Space(23 - Len(NuloString(texto))) & Space(19 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
                PrintLine(lngFile, texto)
            End If

            Dim vlrDesc As Decimal = VlrPro * (NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) / 100)
            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) > 0 Then
                VlrDescTxt = Format(NuloDecimal(vlrDesc), "#0.00")
                texto = "Desconto  " & Space(32 - Len(VlrDescTxt)) & VlrDescTxt
                PrintLine(lngFile, texto)
            End If

            PrintLine(lngFile, "                              ------------")
            Dim ValorTotal As Decimal = NuloDecimal(VlrPro) + NuloDecimal(TaxaEntrega) + NuloDecimal(Caixinha) - NuloDecimal(vlrDesc)

            SerTxt = Format(NuloDecimal(ValorTotal), "#0.00")
            PrintLine(lngFile, "TOTAL" & Space(37 - Len(SerTxt)) & SerTxt)
            PrintLine(lngFile, "------------------------------------------")

            strSql = "Select IDVenda, Descricao "
            strSql += "From tblVendasPagto "
            strSql += "Where (IDVenda= " & IDvda & ")"
            strSql += "Order By Descricao"

            Dim dapP = New SqlDataAdapter(strSql, strCon)
            dapP.SelectCommand.CommandType = CommandType.Text
            Dim dsP As New DataSet()
            dapP.Fill(dsP, "Pagto")
            FormaPagto = ""
            For ii As Integer = 0 To dsP.Tables("Pagto").Rows.Count - 1
                FormaPagto += dsP.Tables("Pagto").Rows(ii).Item("Descricao") & " / "
            Next
            If FormaPagto <> "" Then FormaPagto = Strings.Left(FormaPagto, Len(FormaPagto) - 3)
            PrintLine(lngFile, Chr(27) + Chr(14) & "Forma pagamento: " & FormaPagto & Chr(27) + Chr(14))


            If NuloDecimal(Troco) > 0 Then
                PrintLine(lngFile, " ")
                SerTxt = Format(NuloDecimal(Troco - ValorTotal), "#0.00")
                PrintLine(lngFile, "T R O C O       " & SerTxt & "   -   (" & Format(NuloDecimal(Troco), "#0.00") & ")")
                PrintLine(lngFile, " ")
            End If
            If ComentExp <> "" Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, ComentExp)
                PrintLine(lngFile, " ")
            End If
            If PagtoDiferente = True Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, "******************************************")
                PrintLine(lngFile, "           ENDERECO DE COBRANCA")
                PrintLine(lngFile, "------------------------------------------")
                PrintLine(lngFile, RuaPagto & ", " & NumeroPagto)
                PrintLine(lngFile, ComplementoPagto)
                PrintLine(lngFile, BairroPagto & " - " & CEPPagto)
                PrintLine(lngFile, "******************************************")
                PrintLine(lngFile, " ")
            End If
            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            If GuilhotinaImpCaixa = False Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")

                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
            End If
        Next
        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()

        Dim caminho As String = Application.StartupPath & "\Impressao\conta.txt"
        If File.Exists(caminho) Then
            Using tr As TextReader = New StreamReader(caminho)
                'tbConta.Text = tr.ReadToEnd()
            End Using
        Else
            MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FinalizaVenda(IDvda As Integer)

        strSql = "UPDATE tblVendas SET "
        strSql &= "IDFechamento=" & IDFechamento & ", "
        strSql &= "FlagFechada=1, "
        strSql &= "Caixa='" & Caixa & "', "
        strSql &= "HoraFechamento='" & Date.Now & "' "
        strSql &= "WHERE (IDVenda=" & IDvda & ")"
        ExecutaStr(strSql)

        strSql = "SELECT IDVenda, IDCliente FROM tblVendas WHERE (IDVenda=" & IDvda & ")"
        Dim IDcli As Integer = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))

        strSql = "SELECT IDVenda, DataVenda FROM tblVendas WHERE (IDVenda=" & IDvda & ")"
        Dim DtVenda As String = NuloString(PegaValorCampo("DataVenda", strSql, strCon))

        strSql = "SELECT QtdVendas, IDCliente FROM tblClientes WHERE (IDCliente=" & IDcli & ")"
        Dim QtdVda As Integer = NuloInteger(PegaValorCampo("QtdVendas", strSql, strCon))


        strSql = "UPDATE tblClientes SET "
        strSql &= "IDVendaUltimaVenda=" & IDvda & ", "
        strSql &= "DataUltimaVenda='" & DtVenda & "', "
        strSql &= "QtdVendas=" & QtdVda + 1 & ", "
        strSql &= "Atualiza=1 "
        strSql &= "WHERE (IDCliente=" & IDcli & ")"
        ExecutaStr(strSql)

        If ImpRecibo = True Then
            frmPagamento.CriaCupomRecibo(IDvda)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\recibo.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

    End Sub
    Private Sub CarregaDadosVenda(IDvda As Integer)

        SqlStr = "Select tblVendas.IDVenda, tblVendas.NumVendaD, tblVendas.IDCliente, tblVendas.Excluido, tblVendas.IDRuaEntrega, tblVendas.NumeroEntrega, tblVendas.AreaEntrega, tblVendas.CepEntrega, tblVendas.ComplementoEntrega, tblVendas.ReferenciaEntrega, tblRuas.Bairro, tblVendas.ComentProducao, tblVendas.ComentExpedicao, tblVendas.PercDesconto, tblVendas.Desconto, tblVendas.TaxaEntrega, tblVendas.Troco, tblRuas.IDRua, tblRuas.Logradouro, tblClientes.Tel1, tblClientes.DDD1, tblClientes.CPF_CNPJ, tblVendasPagto.IDFormaPagto, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblVendas.Caixinha, tblVendas.PedidoProg, tblVendas.PedidoProgAutomatico, tblVendas.PedidoProgEnvioAs, tblVendas.PedidoProgEnviado, tblVendas.TipoLancto, tblVendas.CpfCnpj, tblVendas.CepPagto, tblVendas.NumeroPagto, tblVendas.ComplementoPagto, tblVendas.EnderecoPagtoDiferente, tblVendas.RuaPagto, tblVendas.BairroPagto, tblVendas.IDVendaExterna, tblVendas.App, tblVendas.IDReferencia, tblVendas.IDClienteExterno, tblVendas.LogradouroEntrega "
        SqlStr += "From tblVendas INNER Join tblRuas On tblVendas.IDRuaEntrega = tblRuas.IDRua INNER Join tblClientes On tblVendas.IDCliente = tblClientes.IDCliente LEFT OUTER Join tblVendasPagto On tblVendas.IDVenda = tblVendasPagto.IDVenda "
        SqlStr += "Where (tblVendas.IDVenda = " & IDvda & ")"

        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Dados")

        Dim IDRuaEntrega As Integer = 0
        Dim IDvdaExterna As String = ""
        Dim RuaEntrega As String = ""
        Dim CepEntrega As String = ""
        Dim AreaEntrega As String = ""
        Dim NumeroEntrega As String = ""
        Dim ComplementoEntrega As String = ""
        Dim ReferenciaEntrega As String = ""
        Dim BairroEntrega As String = ""
        Dim TxEntrega As Decimal = 0
        Dim Caixinha As Decimal = 0
        Dim Troco As Decimal = 0
        Dim PercDesconto As Decimal = 0
        Dim ComentProducao As String = ""
        Dim ComentExpedicao As String = ""
        Dim IDFormPagto As Integer
        Dim RuaPagto As String = ""
        Dim cepPagto As String = ""
        Dim numeroPagto As String = ""
        Dim bairroPagto As String = ""
        Dim complementoPagto As String = ""
        Dim PagtoDiferente As Boolean

        For i As Integer = 0 To ds.Tables("Dados").Rows.Count - 1
            IDvdaExterna = NuloString(ds.Tables("Dados").Rows(i).Item("IDVendaExterna"))
            IDRuaEntrega = NuloInteger(ds.Tables("Dados").Rows(i).Item("IDRua"))
            IDFormPagto = NuloInteger(ds.Tables("Dados").Rows(i).Item("IDFormaPagto"))
            RuaEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("LogradouroEntrega"))
            CepEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("CepEntrega"))
            AreaEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("AreaEntrega"))
            NumeroEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("NumeroENtrega"))
            ComplementoEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("ComplementoEntrega"))
            ReferenciaEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("ReferenciaEntrega"))
            BairroEntrega = NuloString(ds.Tables("Dados").Rows(i).Item("Bairro"))
            chkTipoLancto.Checked = NuloBoolean(ds.Tables("Dados").Rows(i).Item("TipoLancto"))
            tbCpfCnpj.Text = NuloString(ds.Tables("Dados").Rows(i).Item("CpfCnpj"))
            tbApp.Text = NuloString(ds.Tables("Dados").Rows(i).Item("App"))
            tbIDReferencia.Text = NuloString(ds.Tables("Dados").Rows(i).Item("IDReferencia"))
            tbIDClienteExterno.Text = NuloString(ds.Tables("Dados").Rows(i).Item("IDClienteExterno"))

            RuaPagto = NuloString(ds.Tables("Dados").Rows(i).Item("RuaPagto"))
            cepPagto = NuloString(ds.Tables("Dados").Rows(i).Item("CepPagto"))
            numeroPagto = NuloString(ds.Tables("Dados").Rows(i).Item("NumeroPagto"))
            complementoPagto = NuloString(ds.Tables("Dados").Rows(i).Item("ComplementoPagto"))
            bairroPagto = NuloString(ds.Tables("Dados").Rows(i).Item("BairroPagto"))
            PagtoDiferente = NuloBoolean(ds.Tables("Dados").Rows(i).Item("EnderecoPagtoDiferente"))


            TxEntrega = NuloDecimal(ds.Tables("Dados").Rows(i).Item("TaxaEntrega"))
            Troco = NuloDecimal(ds.Tables("Dados").Rows(i).Item("Troco"))
            PercDesconto = NuloDecimal(ds.Tables("Dados").Rows(i).Item("PercDesconto"))
            Caixinha = NuloDecimal(ds.Tables("Dados").Rows(i).Item("Caixinha"))
            ComentProducao = NuloString(ds.Tables("Dados").Rows(i).Item("ComentProducao"))
            ComentExpedicao = NuloString(ds.Tables("Dados").Rows(i).Item("ComentExpedicao"))
            tbPedido.Text = NuloInteger(ds.Tables("Dados").Rows(i).Item("NumVendaD"))
            tbPedidoProgEnviado.Text = NuloBoolean(ds.Tables("Dados").Rows(i).Item("PedidoProgEnviado"))

            If NuloBoolean(ds.Tables("Dados").Rows(i).Item("PedidoProg")) = False Then
                chkPedidoProg.Checked = False
                lbPedidoProgEnvioAs.Text = ""
            Else
                chkPedidoProg.Checked = True
                If NuloBoolean(ds.Tables("Dados").Rows(i).Item("PedidoProgAutomatico")) = False Then
                    lbPedidoProgEnvioAs.Text = ""
                Else
                    lbPedidoProgEnvioAs.Text = Format(ds.Tables("Dados").Rows(i).Item("PedidoProgEnvioAs"), "HH:mm:ss")
                End If
            End If


            If NuloString(ds.Tables("Dados").Rows(i).Item("Tel1")) <> "" Then
                tbBuscaCliente.Text = NuloString(ds.Tables("Dados").Rows(i).Item("Tel1"))
                tbDDD.Text = NuloString(ds.Tables("Dados").Rows(i).Item("DDD1"))
            Else
                tbBuscaCliente.Text = NuloString(ds.Tables("Dados").Rows(i).Item("CPF_CNPJ"))
                tbDDD.Text = ""
            End If
        Next
        AchaCliente(0)

        PanelPedidoProg.Visible = False
        If lbStatus.Text = "Entregando" Then
            lbStatus.BackColor = Color.Green
            lbStatus.ForeColor = Color.White
        End If
        If lbStatus.Text = "Estornado" Then
            lbStatus.BackColor = Color.Red
            lbStatus.ForeColor = Color.White
        End If
        If lbStatus.Text = "Finalizado" Then
            lbStatus.BackColor = Color.BlueViolet
            lbStatus.ForeColor = Color.White
        End If
        If lbStatus.Text = "Em produção" Then
            lbStatus.BackColor = Color.Blue
            lbStatus.ForeColor = Color.White
        End If

        If NuloBoolean(tbPedidoProgEnviado.Text) = False Then
            PanelPedidoProg.Visible = True
        End If

        tbIDVendaExterna.Text = IDvdaExterna
        tbIDVenda.Text = IDvda
        tbIDRuaEntrega.Text = IDRuaEntrega
        tbLogradouroEntrega.Text = RuaEntrega
        tbNumeroEntrega.Text = NumeroEntrega
        tbCEPEntrega.Text = CepEntrega
        tbAreaEntrega.Text = AreaEntrega
        lbTaxaEntregaEntrega.Text = Format(NuloDecimal(TxEntrega), "#0.00")
        txtServico.Text = Format(NuloDecimal(TxEntrega), "#0.00")
        tbComplementoEntrega.Text = ComplementoEntrega
        tbBairroEntrega.Text = BairroEntrega
        tbReferenciaEntrega.Text = ReferenciaEntrega


        tbRuaPagto.Text = RuaPagto
        tbNumeroPagto.Text = numeroPagto
        tbCepPagto.Text = cepPagto
        tbComplementoPagto.Text = complementoPagto
        tbBairroPagto.Text = bairroPagto
        tbEnderecoEntregaDiferente.Text = PagtoDiferente
        lbEnderecoPagto.Text = "Endereço de cobrança: " & tbRuaPagto.Text & ", " & tbNumeroPagto.Text & "  " & tbComplementoPagto.Text & " " & tbBairroPagto.Text & "  " & tbCepPagto.Text


        tbCaixinha.Text = Format(NuloDecimal(Caixinha), "#0.00")
        lbCaixinha.Text = Format(NuloDecimal(Caixinha), "#0.00")
        tbTroco.Text = Format(NuloDecimal(Troco), "#0.00")
        tbDescontoPerc.Text = Format(NuloDecimal(PercDesconto), "#0.000")
        tbComentExpedicao.Text = NuloString(ComentExpedicao)
        tbComentProducao.Text = NuloString(ComentProducao)

        PreencheListaPagto(IDvda)

        CalculaTotaisDelivery()
    End Sub

    Private Sub CarregaProdutos(IDvda As Integer)

        Dim VlrUnit As Double = 0
        Dim IDMovto As Integer
        Dim IDCombo As Integer
        Dim ID As Integer = 0

        DataSetGridDel.Clear()

        SqlStr = "Select tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo, tblVendas.NumMesa, tblVendas.FlagFechada, tblVendasMovto.IDProduto, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasMovto.Categoria, tblVendasMovto.Excluido, tblVendasMovto.Enviado, tblVendasMovto.IDFuncionario, tblVendasMovto.Atendente, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.HoraPedido, tblProdutos_Local.IDProduto As Expr1, tblProdutos_Local.CodigoProduto, tblVendasCombo.Produto As ProdutoCombo, tblVendasCombo.IDGrupo As IDGrupoCombo, tblVendasCombo.Grupo AS GrupoCombo, tblVendasCombo.IDProduto AS IDProdutoCombo "
        SqlStr += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
        SqlStr += "Where (tblVendas.IDVenda=" & IDVenda & ") "
        SqlStr += "Order By tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo"

        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If IsDBNull(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo")) Then
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1
                Dim nova_linha As DataRow = DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), ID, True, NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))}
                DataSetGridDel.Tables(0).Rows.Add(nova_linha)

                ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                InsereComent("M", NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), 0, ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))
            Else
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1
                Dim nova_linha As DataRow = DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), ID, True, NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))}
                DataSetGridDel.Tables(0).Rows.Add(nova_linha)

                IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                While IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                    'ID += 1
                    Dim nova_linha_PCM1 As DataRow = DataSetGridDel.Tables(0).NewRow()
                    nova_linha_PCM1.ItemArray = New Object() {ID, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")), String.Empty, ID, "PC", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), 0, 0, String.Empty, 0, String.Empty, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupoCombo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("GrupoCombo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProdutoCombo")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), ID, True, 0}
                    DataSetGridDel.Tables(0).Rows.Add(nova_linha_PCM1)

                    IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                    While IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                        ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        InsereComent("MC", 0, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo")), ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))

                        If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaCombo")) Then
                            i += 1
                        Else
                            Exit While
                        End If

                    End While
                    If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                    If IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto")) Then
                        i += 1
                    Else
                        Exit While
                    End If
                End While
                InsereComent("M", NuloInteger(IDMovto), 0, ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))
            End If
        Next

        GridDel.Refresh()
        LinhaGrid()
        'AtualizaGridDelivery()
        StiloGridDelivery()

        If DataSetGridDel.Tables(0).Rows.Count <> 0 Then
            GridDel.Rows(0).Selected = False
        End If

        CalculaTotaisDelivery()




    End Sub

    Public Sub PreenchePedidos()

        Dim item As ListViewItem
        Dim Hora As String
        Dim NumPed As Integer = 0
        Dim Producao As Integer = 0
        Dim Final As Integer = 0
        Dim Todos As Integer = 0
        Dim Entregando As Integer = 0
        Dim Excluido As Integer = 0
        Dim VlrCaixinha As Decimal = 0
        Dim VlrTxEntrega As Decimal = 0
        Dim VlrVendas As Decimal = 0
        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVendaD, tblVendas.StatusVenda, tblVendas.IDCliente, tblVendas.NomeCliente, tblClientes.Tel1, tblClientes.CPF_CNPJ, tblVendas.HoraAbertura, tblVendas.HoraProducao, tblVendas.HoraFechamento, tblVendas.Atendente, tblVendas.Excluido, tblVendas.Entregador, tblVendas.TotalVenda, tblVendas.Caixinha, tblVendas.TaxaEntrega, tblClientes.IDExterno, tblVendas.PedidoProg, tblVendas.PedidoProgEnvioAs, tblVendas.PedidoProgAutomatico, tblVendas.PedidoProgEnviado, tblVendas.IDVendaExterna, tblVendas.IDReferencia "
        strSql += "From tblVendas LEFT OUTER Join tblClientes On tblVendas.IDCliente = tblClientes.IDCliente "
        strSql += "Where (tblVendas.StatusVenda = 'D') "
        If chkEntregando.Checked = True Then
            strSql += " And (tblVendas.HoraProducao Is Not NULL) And (tblVendas.HoraFechamento Is NULL) "
        End If
        If chkProducao.Checked = True Then
            strSql += "And (tblVendas.HoraProducao Is NULL) And (tblVendas.HoraFechamento Is NULL) "
        End If
        If chkFinal.Checked = True Then
            strSql += "And (tblVendas.HoraProducao Is Not NULL) And (tblVendas.HoraFechamento Is Not NULL) "
        End If
        If chkExcluido.Checked = True Then
            strSql += "And (tblVendas.Excluido = 1) And (tblVendas.HoraFechamento Is Not NULL) "
        End If
        If NuloString(cbAtendente.Text) <> "" Then
            strSql += " And (tblVendas.Atendente = '" & cbAtendente.Text & "') "
        End If
        If NuloString(cbEntregador.Text) <> "" Then
            strSql += " And (tblVendas.Entregador = '" & cbEntregador.Text & "') "
        End If

        If IsNumeric(tbBusca.Text) Then
            If Len(tbBusca.Text) <= 4 Then
                strSql += " And (tblVendas.NumVendaD = " & tbBusca.Text & ") OR (tblVendas.IDReferencia Like '%" & tbBusca.Text & "%') "
            Else
                strSql += "And (tblClientes.CPF_CNPJ Like '%" & tbBusca.Text & "%') OR (tblClientes.Tel1 Like '%" & tbBusca.Text & "%') OR (tblVendas.IDReferencia Like '%" & tbBusca.Text & "%') "
            End If
        Else
            strSql += "And (tblVendas.NomeCliente Like '%" & tbBusca.Text & "%') "
        End If
        strSql += "ORDER BY tblVendas.HoraFechamento, tblVendas.IDVenda DESC"
        cmd.CommandText = strSql

        lstPedidos.Items.Clear()

        Dim HProducao As String
        Dim HEntrega As String
        Dim HPedido As String
        Dim DescPagto As String = ""
        Dim TotalProducao As Integer = 0
        Dim TotalEntrega As Integer = 0
        Dim TotalPedido As Integer = 0

        Dim Tproducao As Integer = 0
        Dim Tpedido As Integer = 0



        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While dr.Read()
                item = lstPedidos.Items.Add(NuloInteger(dr.Item("IDVenda")))
                item.SubItems.Add(NuloInteger(dr.Item("NumVendaD")))
                item.SubItems.Add(NuloString(dr.Item("NomeCliente")))
                If NuloString(dr.Item("Tel1")) = "" Then
                    If NuloString(dr.Item("IDExterno")) <> "" Then
                        item.SubItems.Add(dr.Item("IDExterno"))
                    Else
                        item.SubItems.Add(NuloString(dr.Item("CPF_CNPJ")))
                    End If
                Else
                    item.SubItems.Add(NuloString(dr.Item("Tel1")))
                End If
                item.SubItems.Add(NuloString(dr.Item("Atendente")))
                Hora = DatePart(DateInterval.Hour, dr.Item("HoraAbertura")).ToString("00") & ":" & DatePart(DateInterval.Minute, dr.Item("HoraAbertura")).ToString("00") & ":" & DatePart(DateInterval.Second, dr.Item("HoraAbertura")).ToString("00")
                item.SubItems.Add(Hora)

                If NuloString(dr.Item("HoraProducao")) <> "" Then
                    Hora = DatePart(DateInterval.Hour, dr.Item("HoraProducao")).ToString("00") & ":" & DatePart(DateInterval.Minute, dr.Item("HoraProducao")).ToString("00") & ":" & DatePart(DateInterval.Second, dr.Item("HoraProducao")).ToString("00")
                    HProducao = Math.Abs(DateDiff(DateInterval.Second, dr.Item("HoraProducao"), dr.Item("HoraAbertura")))
                    TotalProducao += Math.Abs(DateDiff(DateInterval.Second, dr.Item("HoraProducao"), dr.Item("HoraAbertura")))
                    Tproducao += 1
                Else
                    Hora = ""
                    HProducao = "0"
                End If
                item.SubItems.Add(Hora)

                If NuloString(dr.Item("HoraFechamento")) <> "" Then
                    Hora = DatePart(DateInterval.Hour, dr.Item("HoraFechamento")).ToString("00") & ":" & DatePart(DateInterval.Minute, dr.Item("HoraFechamento")).ToString("00") & ":" & DatePart(DateInterval.Second, dr.Item("HoraFechamento")).ToString("00")
                    HEntrega = Math.Abs(DateDiff(DateInterval.Second, dr.Item("HoraProducao"), dr.Item("HoraFechamento")))
                    TotalEntrega += Math.Abs(DateDiff(DateInterval.Second, dr.Item("HoraProducao"), dr.Item("HoraFechamento")))
                    Tpedido += 1
                    HPedido = Math.Abs(DateDiff(DateInterval.Second, dr.Item("HoraAbertura"), dr.Item("HoraFechamento")))
                    TotalPedido += Math.Abs(DateDiff(DateInterval.Second, dr.Item("HoraAbertura"), dr.Item("HoraFechamento")))
                Else
                    Hora = ""
                    HEntrega = "0"
                    HPedido = "0"
                End If
                item.SubItems.Add(Hora)
                item.SubItems.Add(NuloString(dr.Item("Entregador")))

                strSql = "Select IDVenda, Descricao "
                strSql += "From tblVendasPagto "
                strSql += "Where (IDVenda= " & NuloInteger(dr.Item("IDVenda")) & ")"
                strSql += "Order By Descricao"

                Dim dap = New SqlDataAdapter(strSql, strCon)
                dap.SelectCommand.CommandType = CommandType.Text
                Dim ds As New DataSet()
                dap.Fill(ds, "Pagto")
                DescPagto = ""
                For i As Integer = 0 To ds.Tables("Pagto").Rows.Count - 1
                    DescPagto += ds.Tables("Pagto").Rows(i).Item("Descricao") & " / "
                Next
                If DescPagto <> "" Then DescPagto = Strings.Left(DescPagto, Len(DescPagto) - 3)
                item.SubItems.Add(NuloString(DescPagto))


                item.SubItems.Add(NuloDecimal(dr.Item("TotalVenda")).ToString("#0.00"))
                item.SubItems.Add(NuloDecimal(dr.Item("Caixinha")).ToString("#0.00"))
                item.SubItems.Add(NuloBoolean(dr.Item("Excluido")))

                If NuloBoolean(dr.Item("Excluido")) = True Then
                    item.SubItems.Add("X")
                    item.SubItems.Item(0).ForeColor = Color.Red
                    Excluido += 1
                    VlrCaixinha += NuloDecimal(dr.Item("Caixinha"))
                    VlrVendas += NuloDecimal(dr.Item("TotalVenda"))
                Else
                    If NuloString(dr.Item("HoraProducao")) = "" And NuloString(dr.Item("HoraFechamento")) = "" Then
                        item.SubItems.Add("P")
                        Producao += 1
                        VlrCaixinha += NuloDecimal(dr.Item("Caixinha"))
                        VlrVendas += NuloDecimal(dr.Item("TotalVenda"))
                    End If
                    If NuloString(dr.Item("HoraProducao")) <> "" And NuloString(dr.Item("HoraFechamento")) <> "" Then
                        item.SubItems.Add("F")
                        item.SubItems.Item(0).ForeColor = Color.BlueViolet
                        Final += 1
                        VlrCaixinha += NuloDecimal(dr.Item("Caixinha"))
                        VlrVendas += NuloDecimal(dr.Item("TotalVenda"))
                    End If
                    If NuloString(dr.Item("HoraProducao")) <> "" And NuloString(dr.Item("HoraFechamento")) = "" Then
                        item.SubItems.Add("E")
                        item.SubItems.Item(0).ForeColor = Color.Green
                        Entregando += 1
                        VlrCaixinha += NuloDecimal(dr.Item("Caixinha"))
                        VlrVendas += NuloDecimal(dr.Item("TotalVenda"))
                    End If
                End If
                item.SubItems.Add(NuloDecimal(dr.Item("TaxaEntrega")).ToString("#0.00"))
                item.SubItems.Add(HProducao)
                item.SubItems.Add(HEntrega)
                item.SubItems.Add(HPedido)
                If NuloBoolean(dr.Item("PedidoProg")) = True Then
                    item.SubItems.Add(NuloBoolean(dr.Item("PedidoProg")))
                    If NuloBoolean(dr.Item("PedidoProgAutomatico")) = True Then
                        item.SubItems.Add(NuloString(Format(dr.Item("PedidoProgEnvioAs"), "HH:mm:ss")))
                    Else
                        item.SubItems.Add("")
                    End If
                    item.SubItems.Add(NuloBoolean(dr.Item("PedidoProgEnviado")))
                    If NuloBoolean(dr.Item("PedidoProgEnviado")) = False Then
                        item.SubItems.Item(0).ForeColor = Color.Brown
                    End If
                Else
                    item.SubItems.Add(NuloBoolean(dr.Item("PedidoProg")))
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                End If
                item.SubItems.Add(NuloString(dr.Item("IDReferencia")))



                VlrTxEntrega += NuloDecimal(dr.Item("taxaENtrega"))
                NumPed += 1
            Loop
        End If
        dr.Close()
        cmd.Dispose()
        con.Close()

        lbEntregando.Text = Entregando
        lbTotalPedidos.Text = Todos
        lbTotalProducao.Text = Producao
        lbTotalEstornados.Text = Excluido
        lbTotalFinalizado.Text = Final

        lbTotalVendas.Text = VlrVendas.ToString("#0.00")
        lbTotalCaixinha.Text = VlrCaixinha.ToString("#0.00")
        lbTotalTaxaEntrega.Text = VlrTxEntrega.ToString("#0.00")
        lbTotalPedidos.Text = NumPed


        If Tproducao = 0 Then Tproducao = 1
        Dim Hcorr As Integer
        Hcorr = CType((TotalProducao / Tproducao), Integer) / 60 / 60
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoProducao.Text = Hcorr.ToString("00")

        Hcorr = CType((TotalProducao / Tproducao), Integer) / 60
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoProducao.Text += ":" & Hcorr.ToString("00")
        Hcorr = CType(TotalProducao / Tproducao, Integer)
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoProducao.Text += ":" & Hcorr.ToString("00")


        If Tpedido = 0 Then Tpedido = 1

        Hcorr = CType((TotalEntrega / Tpedido), Integer) / 60 / 60
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoEntrega.Text = Hcorr.ToString("00")

        Hcorr = CType((TotalEntrega / Tpedido), Integer) / 60
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoEntrega.Text += ":" & Hcorr.ToString("00")
        Hcorr = CType(TotalEntrega / Tpedido, Integer)
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoEntrega.Text += ":" & Hcorr.ToString("00")

        Hcorr = CType((TotalPedido / Tpedido), Integer) / 60 / 60
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoPedido.Text = Hcorr.ToString("00")

        Hcorr = CType((TotalPedido / Tpedido), Integer) / 60
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoPedido.Text += ":" & Hcorr.ToString("00")
        Hcorr = CType(TotalPedido / Tpedido, Integer)
        While Hcorr >= 60
            Hcorr -= 60
        End While
        lbTempoPedido.Text += ":" & Hcorr.ToString("00")

        lstPedidos.SelectedItems.Clear()
    End Sub

    Private Sub Colorir()
        Dim Producao As Integer = 0
        Dim Final As Integer = 0
        Dim Todos As Integer = 0
        Dim Entregando As Integer = 0
        Dim Excluido As Integer = 0
        Dim VlrCaixinha As Decimal = 0
        Dim VlrVendas As Decimal = 0

        'Try
        For i As Integer = 0 To lstPedidos.Items.Count - 1
            lstPedidos.Items(i).Selected = True
            If NuloString(lstPedidos.SelectedItems(0).SubItems(6).Text) = "" And NuloString(lstPedidos.SelectedItems(0).SubItems(7).Text) = "" Then
                Producao += 1
                VlrCaixinha += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(11).Text)
                VlrVendas += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(10).Text)
            End If
            If NuloString(lstPedidos.SelectedItems(0).SubItems(6).Text) <> "" And NuloString(lstPedidos.SelectedItems(0).SubItems(7).Text) <> "" Then
                lstPedidos.Items(i).ForeColor = Color.BlueViolet
                Final += 1
                VlrCaixinha += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(11).Text)
                VlrVendas += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(10).Text)
            End If
            If NuloString(lstPedidos.SelectedItems(0).SubItems(6).Text) <> "" And NuloString(lstPedidos.SelectedItems(0).SubItems(7).Text) = "" Then
                lstPedidos.Items(i).ForeColor = Color.Green
                Entregando += 1
                VlrCaixinha += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(11).Text)
                VlrVendas += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(10).Text)
            End If
            If NuloBoolean(lstPedidos.SelectedItems(0).SubItems(12).Text) = True Then
                lstPedidos.Items(i).ForeColor = Color.Red
                Excluido += 1
                VlrCaixinha += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(11).Text)
                VlrVendas += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(10).Text)
            End If

            If NuloBoolean(lstPedidos.SelectedItems(0).SubItems(18).Text) = True And NuloBoolean(lstPedidos.SelectedItems(0).SubItems(20).Text) = False Then
                lstPedidos.Items(i).ForeColor = Color.Brown
                '    Excluido += 1
                'VlrCaixinha += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(11).Text)
                'VlrVendas += NuloDecimal(lstPedidos.SelectedItems(0).SubItems(10).Text)
            End If

            lstPedidos.Items(i).Selected = False
            Todos += 1
        Next

        'Catch ex As Exception

        'End Try

        lbEntregando.Text = Entregando
        lbTotalPedidos.Text = Todos
        lbTotalProducao.Text = Producao
        lbTotalEstornados.Text = Excluido
        lbTotalFinalizado.Text = Final

        lbTotalVendas.Text = VlrVendas.ToString("#0.00")
        lbTotalCaixinha.Text = VlrCaixinha.ToString("#0.00")

    End Sub
    Private Sub EnviaPedidoDel(Enviado As Boolean)

        Dim IDPedidoGrid As Integer
        Dim ii As Integer
        Dim St As String
        Dim Qtde As String
        Dim QtdeUnit As Double
        Dim VlrUnit As String
        Dim VlrUnitServ As String
        Dim con As New SqlConnection(strCon)
        Dim dv As New DataView(DataSetGridDel.Tables(0))
        Dim IDSetor As Integer
        Dim IDsMovto(100) As Integer
        Dim iID As Integer = 0
        Dim Cate As String
        For Each iID In IDsMovto
            iID = 0
        Next iID
        iID = 0
        dv.Sort = "ID DESC"


        ' Try

        con.Open()

        For i = 0 To dv.Count - 1
            If NuloBoolean(dv.Item(i)("Confirmado")) = False Then
                IDPedidoGrid = NuloInteger(dv.Item(i)("IDPedido"))

                QtdeUnit = CDbl((dv.Item(i)("Qtde")))
                Qtde = NuloString(dv.Item(i)("Qtde"))
                Qtde = Replace(Qtde, ",", ".")

                VlrUnit = NuloString(dv.Item(i)("VlrUnit"))
                ' VlrUnit = Replace(VlrUnit, ",", ".")

                VlrUnitServ = NuloString(NuloDouble(dv.Item(i)("VlrUnit")) * ((PercServico / 100) + 1))
                '    VlrUnitServ = Replace(VlrUnitServ, ",", ".")

                'Categoria = NuloString(NuloString(dv.Item(i)("Categoria")))
                Cate = NuloString(NuloString(dv.Item(i)("Categoria")))

                IDSetor = 0
                If Modulo = "D" Then
                    IDSetor = SetorDelivery
                End If


                Imprime = NuloBoolean(PegaValorCampo("ImprimeCategoria", "SELECT IDProduto, ImprimeCategoria FROM tblProdutos_Local WHERE IDProduto=" & NuloInteger(dv.Item(i)("IDProduto")), strCon))

                InserirItemVenda(IDVenda, NuloInteger(dv.Item(i)("IDProduto")), NuloString(dv.Item(i)("Produto")), NuloDecimal(QtdeUnit), NuloBoolean(Enviado), NuloDecimal(VlrUnit), NuloDecimal(VlrUnitServ), Cate, Date.Now, IDOperador, Operador, NuloInteger(dv.Item(i)("IDGrupo")), NuloString(dv.Item(i)("Grupo")), NuloBoolean(0), "", NuloBoolean(0), "", lbTerminal.Text, Imprime, IDSetor, False, True)
                AchaIDMovto()
                IDsMovto(iID) = IDMovtoGV
                iID += 1

                Dim NomeGrupo As String
                Dim Agrega As Boolean
                strSql = "SELECT IDProduto, AgregaValor "
                strSql += "From tblCombos_Local "
                strSql += "Where (IDProduto =" & NuloInteger(dv.Item(i)("IDProduto")) & ")"
                Agrega = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))

                For ii = (i + 1) To dv.Count - 1
                    If IDPedidoGrid = NuloInteger(dv.Item(ii)("IDPedido")) Then

                        St = Strings.Right(NuloString(dv.Item(ii)("Status")), Len(dv.Item(ii)("Status")) - InStr(1, NuloString(dv.Item(ii)("Status")), NuloString(dv.Item(ii)("ID"))))

                        If St = "M" Then
                            IncluiComentario(IDMovtoGV, 0, NuloString(dv.Item(ii)("Produto")), 0)
                        End If

                        If St = "PC" Then
                            If NuloInteger(dv.Item(ii)("CodigoProduto")) <> 0 Then
                                Qtde = NuloString(CDbl(dv.Item(ii)("Qtde")) * QtdeUnit)
                                Qtde = Replace(Qtde, ",", ".")

                                VlrUnit = NuloString(dv.Item(ii)("VlrUnit"))
                                VlrUnit = Replace(VlrUnit, ",", ".")

                                VlrUnitServ = NuloString(NuloDouble(dv.Item(ii)("VlrUnit")) * ((PercServico / 100) + 1))
                                VlrUnitServ = Replace(VlrUnitServ, ",", ".")


                                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.Categoria "
                                strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
                                strSql += "Where (tblProdutos_Local.IDProduto =" & NuloInteger(dv.Item(ii)("CodigoProduto")) & ")"

                                IDGrupo = NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon))
                                NomeGrupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))


                                strSql = "INSERT tblVendasCombo (IDVendaMovto,IDVenda,IDProduto,Produto,Qtd,Venda,VendaServico,IDGrupo,Grupo,Categoria,AgregaValor,Impresso) VALUES ("
                                strSql &= to_sql(IDMovtoGV) & ","
                                strSql &= to_sql(IDVenda) & ","
                                strSql &= to_sql(NuloInteger(dv.Item(ii)("IDProduto"))) & ","
                                strSql &= to_sql(NuloString(dv.Item(ii)("Produto"))) & ","
                                strSql &= to_sql(Qtde) & ","
                                strSql &= to_sql(VlrUnit) & ","
                                strSql &= to_sql(VlrUnitServ) & ","
                                strSql &= to_sql(IDGrupo) & ","
                                strSql &= to_sql(NuloString(NomeGrupo)) & ","
                                strSql &= to_sql(Cate) & ","
                                strSql &= to_sql(Agrega) & ","
                                strSql &= "0)"
                                ExecutaStr(strSql)

                                AchaIDCombo()
                            End If
                        End If

                        If St = "MC" Then
                            IncluiComentario(0, IDCombo, NuloString(dv.Item(ii)("Produto")), 0)
                        End If
                        i = ii
                    End If
                Next
            End If
        Next

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        'con.Close()
        'con.Dispose()
        'End Try

    End Sub
    Private Sub PreencheEntregador()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        strSql = "Select Entregador, StatusVenda From tblVendas Group By Entregador, StatusVenda HAVING(StatusVenda = 'D') ORDER BY Entregador"

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        cbEntregador.Items.Clear()

        If dr.HasRows Then
            cbEntregador.Items.Add("")
            While (dr.Read())
                cbEntregador.Items.Add(NuloString(dr.Item("Entregador")))
            End While
        End If
        comandoLJS.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheAtendentes()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        strSql = "Select Atendente, StatusVenda From tblVendas Group By Atendente, StatusVenda HAVING(StatusVenda = 'D') ORDER BY Atendente"

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        cbAtendente.Items.Clear()

        If dr.HasRows Then
            cbAtendente.Items.Add("")
            While (dr.Read())
                cbAtendente.Items.Add(NuloString(dr.Item("Atendente")))
            End While
        End If
        comandoLJS.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Public Sub AchaCliente(ID_Cliente As Integer)

Inicio:

        'Dim ID_Cliente As Integer
        Dim VerificaMaisTelefones As Boolean = False
        If ID_Cliente = 0 Then
            VerificaMaisTelefones = True
        End If
        ' Limpa tela  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim ctl As Control
        For Each ctl In Panel1.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
        Next
        For Each ctl In Panel2.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
        Next
        lbTaxaEntrega.Text = ""
        lbCliente.Text = ""
        lbComplementoTel.Text = ""
        lbCPF_CNPJ.Text = ""
        lbTaxaEntregaEntrega.Text = ""
        lbComplementoTel.Text = ""
        lbOrigem.Text = ""
        lbCPF_CNPJ.Text = ""
        lbDataUltimoPedido.Text = ""
        lbQtdePedidos.Text = ""
        lbEnderecoPagto.Text = "Endereço de cobrança:"
        tbEnderecoEntregaDiferente.Text = ""
        tbRuaPagto.Text = ""
        tbCepPagto.Text = ""
        tbNumeroPagto.Text = ""
        tbComplementoPagto.Text = ""
        tbBairroPagto.Text = ""

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        If ID_Cliente = 0 And tbIDClienteExterno.Text <> "" Then
            strSql = "Select IDCliente, IDExterno "
            strSql += "From tblClientes "
            strSql += "Where (IDExterno = '" & tbIDClienteExterno.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
            If ID_Cliente <> 0 Then VerificaMaisTelefones = False

        End If
        If ID_Cliente = 0 Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') = '" & tbBuscaCliente.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If ID_Cliente = 0 And tbBuscaCliente.Text <> "" Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') = '" & tbDDD.Text & tbBuscaCliente.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If


        If ID_Cliente = 0 And tbBuscaCliente.Text <> "" Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') = '" & tbDDD.Text & tbBuscaCliente.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        'If ID_Cliente = 0 And tbBuscaCliente.Text <> "" Then
        'strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
        'strSql += "From tblClientes "
        'strSql += "Where (ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') like '%" & tbBuscaCliente.Text & "%')"
        'ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        'End If
        If ID_Cliente = 0 And tbBuscaCliente.Text <> "" Then
            strSql = "Select IDCliente, CPF_CNPJ "
            strSql += "From tblClientes "
            strSql += "Where (CPF_CNPJ = '" & tbBuscaCliente.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If


        If ID_Cliente = 0 Then

            If tbBuscaCliente.Text = "" Then Exit Sub

            Dim frm As fdlgDeliveryCadastroCliente = New fdlgDeliveryCadastroCliente
            frm.lbStatus.Text = "I"
            frm.lbTelefone.Text = tbBuscaCliente.Text
            frm.lbDDD.Text = tbDDD.Text

            frm.ShowDialog()

        Else

            strSql = "Select tblClientes.IDCliente, tblClientes.NomeCliente, tblClientes.CPF_CNPJ, tblClientes.IDRua, tblClientes.Numero, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblClientes.Complemento, tblClientes.Referencia, tblClientes.CEP, tblRuas.Area, tblClientes.Tel1, tblClientes.Tel2, tblClientes.ComplementoTel, tblClientes.Origem, tblClientes.DataCadastro, tblClientes.DDD1, tblClientes.DDD2, tblClientes.IDExterno, tblClientes.Observacao, QtdVendas, DataUltimaVenda "
            strSql += "From tblRuas RIGHT OUTER Join tblClientes On tblRuas.IDRua = tblClientes.IDRua "
            strSql += "Where (tblClientes.IDCliente=" & ID_Cliente & ")"

            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Ruas")


            If VerificaMaisTelefones = True And Len(tbBuscaCliente.Text) <> 11 Then
                strSql = "Select IDCliente, Tel1, DDD1 "
                strSql += "From tblClientes "
                strSql += "Where (DDD1='" & NuloString(ds.Tables("Ruas").Rows(0).Item("DDD1")) & "') AND (Tel1='" & NuloString(ds.Tables("Ruas").Rows(0).Item("Tel1")) & "')"

                Dim dap1 = New SqlDataAdapter(strSql, strCon)
                dap1.SelectCommand.CommandType = CommandType.Text
                Dim ds1 As New DataSet()
                dap1.Fill(ds, "Tels")

                If ds.Tables("Tels").Rows.Count > 1 Then

                    fdlgDelivery_ClientesMesmoTelefone.ShowDialog()


                    If IDClienteMaisTelefones <> 0 Then
                        ID_Cliente = IDClienteMaisTelefones
                        GoTo Inicio
                    Else
                        Exit Sub
                    End If
                End If
            End If


            lbCPF_CNPJ.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CPF_CNPJ"))
            If Len(NuloString(ds.Tables("Ruas").Rows(0).Item("CPF_CNPJ"))) >= 14 Then
                lbCPF_CNPJ.Mask = "99.999.999/9999-99"
            End If
            If Len(NuloString(ds.Tables("Ruas").Rows(0).Item("CPF_CNPJ"))) = 11 Then
                lbCPF_CNPJ.Mask = "999.999.999-99"
            End If

            tbDDD.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DDD1"))
            lbCliente.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("NomeCliente"))
            lbOrigem.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Origem"))
            tbIDCliente.Text = NuloInteger(ds.Tables("Ruas").Rows(0).Item("IDCliente"))
            tbBuscaCliente.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Tel1"))
            lbObservacao.Text = Replace(NuloString(ds.Tables("Ruas").Rows(0).Item("Observacao")), vbCrLf, "")
            lbComplementoTel.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("ComplementoTel"))

            tbReferencia.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Referencia"))
            tbReferenciaEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Referencia"))

            tbComplemento.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Complemento"))
            tbComplementoEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Complemento"))
            tbComplementoPagto.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Complemento"))

            tbNumero.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Numero"))
            tbNumeroEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Numero"))
            tbNumeroPagto.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Numero"))

            tbCEP.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CEP"))
            tbCEPEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CEP"))
            tbCepPagto.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CEP"))

            tbIDRua.Text = NuloInteger(ds.Tables("Ruas").Rows(0).Item("IDRua"))
            tbIDRuaEntrega.Text = NuloInteger(ds.Tables("Ruas").Rows(0).Item("IDRua"))

            tbLogradouro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Logradouro"))
            tbLogradouroEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Logradouro"))
            tbRuaPagto.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Logradouro"))

            tbBairro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Bairro"))
            tbBairroEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Bairro"))
            tbBairroPagto.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Bairro"))

            tbEnderecoEntregaDiferente.Text = False

            lbEnderecoPagto.Text = "Endereço de cobrança: " & tbRuaPagto.Text & ", " & tbNumeroPagto.Text & "  " & tbComplementoPagto.Text & " " & tbBairroPagto.Text & "  " & tbCepPagto.Text


            tbCidade.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Cidade"))
            tbCidadeEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Cidade"))

            tbEstado.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Estado"))
            tbEstadoEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Estado"))

            tbArea.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Area"))
            strSql = "Select Area, TaxaEntrega From tblAreas WHERE (Area='" & tbArea.Text & "')"
            lbTaxaEntrega.Text = Format(NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon)), "#0.00")

            tbAreaEntrega.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Area"))
            strSql = "Select Area, TaxaEntrega From tblAreas WHERE (Area='" & tbAreaEntrega.Text & "')"
            lbTaxaEntregaEntrega.Text = Format(NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon)), "#0.00")

            CalculaTotaisDelivery()

            If NuloString(ds.Tables("Ruas").Rows(0).Item("DataUltimaVenda")) = "" Then
                lbDataUltimoPedido.Text = "Data última venda        "
            Else
                lbDataUltimoPedido.Text = "Data última venda        " & Format(ds.Tables("Ruas").Rows(0).Item("DataUltimaVenda"), FormatoDataLocal & " HH:MM")
            End If
            lbQtdePedidos.Text = "Quantidade de vendas   " & NuloInteger(ds.Tables("Ruas").Rows(0).Item("QtdVendas"))
            tbIDVendaRet.Text = 0


            'Dim con As New SqlConnection()
            'strSql = "Select COUNT(IDVendaRet) As QtdPedidos, MAX(IDVendaRet) As IDvda, IDLoja, IDCliente, Excluido, MAX(DataVenda) AS DataVenda "
            'strSql += "From tblRetVendas "
            'strSql += "Group By IDLoja, IDCliente, Excluido "
            'strSql += "HAVING(IDCliente = " & ID_Cliente & ")"

            'Try
            'Dim dr As SqlDataReader
            'con.ConnectionString = strConServer
            'Dim cmd As SqlCommand = con.CreateCommand
            'cmd.CommandText = strSql
            'con.Open()
            'dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            'If dr.HasRows Then
            'dr.Read()
            'lbQtdePedidos.Text = "Qtde. pedidos: " & NuloInteger(dr.Item("QtdPedidos"))
            'tbIDVendaRet.Text = NuloInteger(dr.Item("IDvda"))
            'lbDataUltimoPedido.Text = "Último pedido: " & Format(dr.Item("DataVenda"), FormatoDataRET & " hh:MM")
            'End If
            'dr.Close()
            'cmd.Dispose()


            'Catch ex As Exception
            'lbDataUltimoPedido.Text = "Falha na conexão com servidor IRIS Gestão"
            'lbQtdePedidos.Text = "Falha na conexão com servidor IRIS Gestão"
            'tbIDVendaRet.Text = 0

            'Finally
            'con.Dispose()
            'con.Close()

            'End Try



            ' MontaUltimoPedido(NuloInteger(tbIDVendaRet.Text), ID_Cliente)


            If NuloString(lbObservacao.Text) <> "" Then
                Dim frm17 As fdlgMensagemBox = New fdlgMensagemBox
                frm17.lbMensagem.Text = lbObservacao.Text
                frm17.btnNao.Visible = False
                frm17.btnSim.Visible = False
                frm17.btnOK.Visible = True
                frm17.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm17.ShowDialog()
            End If

            tbCodPro.Focus()
        End If
    End Sub
    Public Sub VerificaGrid()

        Dim VlrUnit As Double = 0
        Dim IDMovto As Integer
        Dim IDCombo As Integer
        Dim ID As Integer = 0


        TravaVenda()

        SqlStr = "Select tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo, tblVendas.NumMesa, tblVendas.FlagFechada, tblVendasMovto.IDProduto, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasMovto.Categoria, tblVendasMovto.Excluido, tblVendasMovto.Enviado, tblVendasMovto.IDFuncionario, tblVendasMovto.Atendente, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.HoraPedido, tblProdutos_Local.IDProduto As Expr1, tblProdutos_Local.CodigoProduto, tblVendasCombo.Produto As ProdutoCombo, tblVendasCombo.IDGrupo As IDGrupoCombo, tblVendasCombo.Grupo AS GrupoCombo, tblVendasCombo.IDProduto AS IDProdutoCombo, tblVendas.NumVenda "
        SqlStr += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
        SqlStr += "Where (tblVendas.FlagFechada = 0) And (tblVendas.IDVenda=" & IDVenda & ") "
        SqlStr += "Order By tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo"

        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        tbPedido.Text = ""

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1

            tbPedido.Text = NuloInteger(ds.Tables("Vendas").Rows(i).Item("NumVenda"))

            If IsDBNull(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo")) Then
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1
                Dim nova_linha As DataRow = DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))}
                DataSetGridDel.Tables(0).Rows.Add(nova_linha)

                ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                InsereComent("M", NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), 0, ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))
            Else
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1
                Dim nova_linha As DataRow = DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))}
                DataSetGridDel.Tables(0).Rows.Add(nova_linha)

                IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                While IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                    'ID += 1
                    Dim nova_linha_PCM1 As DataRow = DataSetGridDel.Tables(0).NewRow()
                    nova_linha_PCM1.ItemArray = New Object() {ID, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")), String.Empty, ID, "PC", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), 0, 0, String.Empty, 0, String.Empty, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupoCombo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("GrupoCombo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProdutoCombo")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))}
                    DataSetGridDel.Tables(0).Rows.Add(nova_linha_PCM1)

                    IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                    While IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                        ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        InsereComent("MC", 0, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo")), ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))

                        If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaCombo")) Then
                            i += 1
                        Else
                            Exit While
                        End If

                    End While
                    If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                    If IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto")) Then
                        i += 1
                    Else
                        Exit While
                    End If
                End While
                InsereComent("M", NuloInteger(IDMovto), 0, ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))
            End If
        Next

        GridDel.Refresh()
        LinhaGridDelivery()
        'LinhaGrid()
        ' AtualizaGridDelivery()
        StiloGridDelivery()

        If DataSetGridDel.Tables(0).Rows.Count <> 0 Then
            GridDel.Rows(0).Selected = False
        End If

        CalculaTotaisDelivery()



    End Sub
    Private Sub InsereComent(Status As String, IDMovto As Integer, IDcombo As Integer, IDgrid As Integer, IDFam As Integer, Excluido As Boolean)

        Dim conC As New SqlConnection()
        Dim Texto As String
        strSql = "Select  IDVendaMovto, IDVendaCombo, Coment "
        strSql += "From tblVendasComent "
        If IDMovto > 0 Then
            strSql += "Where (IDVendaMovto = " & IDMovto & ")"
            Texto = ">>>>"
        Else
            strSql += "Where (IDVendaCombo = " & IDcombo & ")"
            Texto = "----->"
        End If

        Dim drC As SqlDataReader
        conC.ConnectionString = strCon
        Dim cmdC As SqlCommand = conC.CreateCommand
        cmdC.CommandText = strSql

        conC.Open()
        drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drC.HasRows Then
            Do While drC.Read()
                Dim nova_linhaComent As DataRow = DataSetGridDel.Tables(0).NewRow()
                nova_linhaComent.ItemArray = New Object() {IDgrid, Texto, drC.Item("Coment"), String.Empty, IDgrid, Status, 0, 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0, IDFam, 0, 0, "", 0, 0, Excluido, IDMovto, IDgrid, True}
                DataSetGridDel.Tables(0).Rows.Add(nova_linhaComent)
            Loop
        End If
        drC.Close()
        cmdC.Dispose()
        conC.Dispose()
        conC.Close()

    End Sub
    Private Sub TravaVenda()
        If PedidoVenda = True Then
            DataSetGridDel.Clear()

            btnConfirma.Enabled = True
            btnComent.Enabled = True
            btnQtde.Enabled = True
            'btnVerifica.Enabled = True
            btnLimpaProduto.Text = "Limpa Produto   F3"
            GridDel.BackgroundColor = Color.WhiteSmoke
        Else
            DataSetGridDel.Clear()

            btnLimpaProduto.Text = "Estorna Produto F3"
            btnComent.Enabled = False
            btnQtde.Enabled = False
            btnConfirma.Enabled = False
            'btnVerifica.Enabled = False
        End If
    End Sub
    Public Sub PegaProduto(CodProd As Integer)

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridProdutos.Rows.Clear()

        SqlStr = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda, tblProdutos_Local.Pesavel, tblGrupos_Local.EPizza, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.IDFamilia, tblGrupos_Local.Grupo, tblProdutos_Local.Categoria "
        SqlStr += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        SqlStr += "Where (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%D%') AND (CodigoProduto =" & CodProd & ")"
        cmd.CommandText = SqlStr

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        tbIDProduto.Text = ""
        tbCodPro.Text = CodProd
        lbProduto.Text = ""
        lbVenda.Text = ""
        tbInformaVenda.Text = ""
        tbEPizza.Text = ""
        tbCodigoGrupo.Text = ""
        tbGrupo.Text = ""
        tbIDFamilia.Text = ""
        tbCategoria.Text = ""
        tbVenda.Text = ""
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If dr.HasRows Then
            dr.Read()
            If NuloBoolean(dr.Item("ForaLinha")) = False Then

                strSql = "SELECT * FROM tblCombos_Local WHERE IDProduto=" & dr.Item("IDProduto")
                AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))

                tbIDProduto.Text = dr.Item("IDProduto")
                tbCodigoProduto.Text = dr.Item("CodigoProduto")
                lbProduto.Text = dr.Item("Produto")
                lbVenda.Text = NuloDecimal(dr.Item("Venda"))
                tbInformaVenda.Text = NuloBoolean(dr.Item("InformaVenda"))
                tbEPizza.Text = NuloBoolean(dr.Item("EPizza"))
                EGrupoPizza = NuloBoolean(dr.Item("EPizza"))
                tbCodigoGrupo.Text = NuloInteger(dr.Item("CodigoGrupo"))
                tbGrupo.Text = NuloString(dr.Item("Grupo"))
                tbIDFamilia.Text = NuloInteger(dr.Item("IDFamilia"))
                tbCategoria.Text = NuloString(dr.Item("Categoria"))
                tbVenda.Text = NuloDecimal(dr.Item("Venda"))


                If NuloBoolean(dr.Item("InformaVenda")) = True Then
                    fdlgValorVenda.ShowDialog()
                    tbVenda.Text = NuloDecimal(VlrUnitario)
                    VlrUnitario = 0
                End If

                '' Verifica se é produto COMBO   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza "
                'strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                'strSql += "Where tblProdutos_Local.CodigoProduto=" & tbCodigoProduto.Text
                'Dim DescCombo As String = ""
                'Dim EPizzaCombo As Boolean = False
                'Dim drC As SqlDataReader
                'Dim conC As New SqlConnection()
                'conC.ConnectionString = strCon
                'Dim cmdC As SqlCommand = conC.CreateCommand
                'cmdC.CommandText = strSql

                'conC.Open()
                'drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                'If drC.HasRows Then
                'drC.Read()
                'DescCombo = NuloString(drC.Item("Descricao"))
                'EPizzaCombo = NuloBoolean(drC.Item("EPizza"))
                'End If
                'cmdC.Dispose()
                'drC.Close()
                'conC.Dispose()
                'conC.Close()

                'If DescCombo <> "" And EPizzaCombo = True Then
                'Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                'frm1.lbMensagem.Text = "Este produto é o sabor de uma pizza" + vbCrLf + "Inicie pelo produto principal" + vbCrLf + "Ex.: " + DescCombo
                'frm1.btnNao.Visible = False
                'frm1.btnSim.Visible = False
                'frm1.btnOK.Visible = True
                'frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                'frm1.ShowDialog()

                'tbCodPro.Text = ""
                'tbIDProduto.Text = ""
                'tbCodigoProduto.Text = ""
                'lbProduto.Text = ""
                'lbVenda.Text = ""
                'tbInformaVenda.Text = ""
                'tbEPizza.Text = ""
                'tbCodigoGrupo.Text = ""
                'tbGrupo.Text = ""
                'tbIDFamilia.Text = ""
                'tbCategoria.Text = ""
                'tbVenda.Text = ""
                'tbQtde.Text = "1,000"
                'Exit Sub
                'End If


            Else
                frm.lbMensagem.Text = "Produto fora de linha"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbQtde.Text = ""
                tbCodPro.Text = ""
                tbCodPro.Focus()

                cmd.Dispose()
                dr.Close()
                con.Close()
                con.Dispose()
                Exit Sub
            End If
        Else
            frm.lbMensagem.Text = "Produto não encontrado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbQtde.Text = ""
            tbCodPro.Text = ""
            tbCodPro.Focus()

            cmd.Dispose()
            dr.Close()
            con.Close()
            con.Dispose()
            Exit Sub
        End If

        tbQtde.Text = "1,000"
        tbQtde.Focus()
    End Sub

    Public Sub AtualizaGridProdutos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridProdutos.Rows.Clear()
        If NuloString(tbCodPro.Text) = "" Then Exit Sub

        tbIDProduto.Text = ""
        'tbCodigoProduto.Text = ""
        ' lbProduto.Text = ""
        lbVenda.Text = ""
        tbInformaVenda.Text = ""
        ' tbEPizza.Text = ""

        SqlStr = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblGrupos_Local.Grupo, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda, tblProdutos_Local.Pesavel, tblGrupos_Local.EPizza, tblProdutos_Local.IDFamilia, tblProdutos_Local.Categoria, tblGrupos_Local.CodigoGrupo "
        SqlStr += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        SqlStr += "WHERE (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%D%')  "
        If Not IsNumeric(tbCodPro.Text) Then
            SqlStr += "AND (tblProdutos_Local.Produto Like '%" & tbCodPro.Text & "%') "
            SqlStr += "ORDER BY tblProdutos_Local.Produto"
        Else
            SqlStr += "AND (tblProdutos_Local.CodigoProduto Like '" & tbCodPro.Text & "%') "
            SqlStr += "ORDER BY tblProdutos_Local.CodigoProduto"
        End If
        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read())
                If NuloBoolean(dr.Item("ForaLinha")) = False Then
                    GridProdutos.Rows.Add({dr.Item("IDProduto"), dr.Item("CodigoProduto"), dr.Item("Produto"), dr.Item("Grupo"), NuloDecimal(dr.Item("Venda")), NuloBoolean(dr.Item("InformaVenda")), NuloBoolean(dr.Item("Pesavel")), NuloBoolean(dr.Item("EPizza")), NuloInteger(dr.Item("IDFamilia")), NuloInteger(dr.Item("CodigoGrupo")), NuloString(dr.Item("Categoria"))})
                End If
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

    End Sub

    Private Sub Limpa()
        Dim ctl As Control
        For Each ctl In Panel8.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        For Each ctl In Panel9.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        For Each ctl In Panel1.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        For Each ctl In Panel2.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        For Each ctl In Panel5.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        tbIDClienteExterno.Text = ""
        tbApp.Text = ""
        tbIDReferencia.Text = ""
        tbPedidoProgEnviado.Text = ""
        PanelPedidoProg.Visible = True
        tbIDCliente.Text = ""
        PedidoVenda = True
        IDVenda = 0
        lbOrigem.Text = ""
        lbComplementoTel.Text = ""
        lbCliente.Text = ""
        lbCPF_CNPJ.Text = ""
        lbTaxaEntrega.Text = ""
        lbTaxaEntregaEntrega.Text = ""
        tbPedido.Text = ""
        lbStatus.Text = "Novo Pedido"
        lbStatus.BackColor = Color.Transparent
        lbStatus.ForeColor = Color.Blue
        tbDDD.Text = DDD_Padrao
        tbCodPro.Text = ""
        tbQtde.Text = ""
        lbVenda.Text = ""
        lbProduto.Text = ""
        lbQtdePedidos.Text = ""
        lbDataUltimoPedido.Text = ""
        lbObservacao.Text = ""
        tbCaixinha.Text = Format(0, "#0.00")
        chkPedidoProg.Checked = False
        chkTipoLancto.Checked = False
        lbPedidoProgEnvioAs.Text = ""
        tbIDVenda.Text = ""
        tbTotalPagto.Text = ""
        lbEnderecoPagto.Text = "Endereço de cobrança:"
        tbEnderecoEntregaDiferente.Text = ""
        tbRuaPagto.Text = ""
        tbCepPagto.Text = ""
        tbNumeroPagto.Text = ""
        tbComplementoPagto.Text = ""
        tbBairroPagto.Text = ""
        tbIDVendaExterna.Text = ""
        lstPagtosVenda.Items.Clear()
        DataSetGridDel.Clear()
        CalculaTotaisDelivery()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnVolta.Click


        If NuloInteger(tbIDCliente.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodPro.Focus()
                Exit Sub
            End If
        End If

        frmPrincipal.Enabled = True
        frmPrincipal.lblSenha.Text = String.Empty
        frmPrincipal.btnConfirma.Enabled = False
        frmPrincipal.btnConfig.Visible = False
        frmPrincipal.btnSalao.Visible = False
        frmPrincipal.btnBalcao.Visible = False
        frmPrincipal.btnDelivery.Visible = False
        frmPrincipal.btnSalao_Balcao.Visible = False
        frmPrincipal.lbFuncionario.Text = ""
        VerificaPedidoAppFora = True
        Me.Dispose()
        Me.Close()

    End Sub


    Private Sub frmDelivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "DELIVERY")
        End If

        VerificaPedidoAppFora = False

        Timer.Start()
        lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)
        lbDataMovimento.Text = DiaMovto
        lbOparedor.Text = Operador
        lbCaixa.Text = Caixa
        lbTerminal.Text = NomeTerminal
        tbDDD.Text = DDD_Padrao

        Modulo = "D"
        Limpa()
        PedidoVenda = True
        If InStr(ModulosIRIS, "S") > 0 Then
            btnSalao.Visible = True
        End If
        If InStr(ModulosIRIS, "B") > 0 Then
            btnBalcao.Visible = True
        End If
        VerificaGrid()

        If Screen.PrimaryScreen.Bounds.Width > 1280 Then
            DefinicaoReduzida = True
            ReduzDefenicao_Delivery()
        Else
            DefinicaoReduzida = False
        End If

        frmPagamento.carregaVisualComponente(btnComent, 10, 10)
        frmPagamento.carregaVisualComponente(Button8, 10, 10)
        frmPagamento.carregaVisualComponente(Button7, 10, 10)
        frmPagamento.carregaVisualComponente(btnApp, 10, 10)
        frmPagamento.carregaVisualComponente(Button3, 10, 10)
        frmPagamento.carregaVisualComponente(Button5, 10, 10)
        frmPagamento.carregaVisualComponente(Button10, 10, 10)
        frmPagamento.carregaVisualComponente(btnVolta, 10, 10)
        frmPagamento.carregaVisualComponente(btnQtde, 10, 10)
        frmPagamento.carregaVisualComponente(btnLimpaProduto, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfirma, 10, 10)
        frmPagamento.carregaVisualComponente(btnBalcao, 10, 10)
        frmPagamento.carregaVisualComponente(btnSalao, 10, 10)
        frmPagamento.carregaVisualComponente(btnUltimoPedido, 10, 10)
        frmPagamento.carregaVisualComponente(btnInformaPagto, 10, 10)

        lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)

    End Sub

    Private Sub tbBuscaCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBuscaCliente.KeyPress

        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If IsNumeric(tbBuscaCliente.Text) And Len(NuloString(tbBuscaCliente.Text)) >= 8 Then
                AchaCliente(0)
            Else
                If IsNumeric(tbBuscaCliente.Text) Then
                    Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                    frm1.lbMensagem.Text = "Número de telefone inválido"
                    frm1.btnNao.Visible = False
                    frm1.btnSim.Visible = False
                    frm1.btnOK.Visible = True
                    frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm1.ShowDialog()
                    Exit Sub
                End If

                Dim frm As fdlgDelivery_BuscaCliente = New fdlgDelivery_BuscaCliente
                frm.tbBusca.Text = tbBuscaCliente.Text

                frm.ShowDialog()

            End If
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As fdlgDeliveryCadastroCliente = New fdlgDeliveryCadastroCliente
        If tbBuscaCliente.Text <> "" Then
            frm.lbStatus.Text = "A"
            frm.lbTelefone.Text = tbBuscaCliente.Text
            frm.lbDDD.Text = tbDDD.Text
        End If


        frm.ShowDialog()


        'AchaCliente()
        tbBuscaCliente.Focus()
        SendKeys.Send("{ENTER}")

    End Sub

    Private Sub tbValor_TextChanged(sender As Object, e As EventArgs) Handles tbCodPro.TextChanged
        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um cliente"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodPro.Text = ""
            tbBuscaCliente.Focus()
        Else
            AtualizaGridProdutos()
        End If
    End Sub

    Private Sub tbQtde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtde.KeyPress

        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbQtde.Text = "" Or Not IsNumeric(tbQtde.Text) Then tbQtde.Text = "1,000"
            'If PedidoVenda = False Then
            'tbCodPro.Focus()
            'Exit Sub
            'End If

            ' Proximo ID do Grid ////////////////////////////////////////////////////////////////////////////////////////////
            Dim IDGrid As Integer

            If Me.DataSetGridDel.Tables(0).Rows.Count = 0 Then
                IDGrid = 1
            Else
                For i As Integer = 0 To Me.DataSetGridDel.Tables(0).Rows.Count - 1
                    If NuloInteger(Me.DataSetGridDel.Tables(0).Rows(i).Item(4)) > IDGrid Then
                        IDGrid = NuloInteger(Me.DataSetGridDel.Tables(0).Rows(i).Item(4))
                    End If
                Next
                IDGrid += 1
            End If
            Dim Qtde As Double = NuloDouble(tbQtde.Text)
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If NuloString(lbProduto.Text = "") Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Produto inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbQtde.Text = ""
                tbCodPro.Text = ""
                tbCodPro.Focus()
                Exit Sub
            End If


            IncluiProdGrid(IDGrid, NuloInteger(tbCodigoProduto.Text), lbProduto.Text, tbVenda.Text, tbCodigoGrupo.Text, tbIDFamilia.Text, 0, 0, "P", tbQtde.Text, tbGrupo.Text, tbCategoria.Text, tbIDProduto.Text, 0, IDGrid, 0)
            tbCodigoProduto.Text = ""
            tbIDProduto.Text = ""
            lbProduto.Text = ""
            lbVenda.Text = ""
            tbQtde.Text = ""
            tbCodPro.Text = ""
            tbCodPro.Focus()
            GridProdutos.Rows.Clear()

            'AtualizaGridProdutos()
            'VerificaGrid()

            If GridDel.SelectedRows.Count > 0 Then
                For i As Integer = 0 To GridDel.Rows.Count - 1
                    GridDel.Rows(i).Selected = False
                Next
            End If
        End If
    End Sub

    Private Sub tbQtde_KeyDown(sender As Object, e As KeyEventArgs) Handles tbQtde.KeyDown
        If AscW(e.KeyCode) = 51 Then
            tbCodPro.Focus()
            tbCodPro.Text = ""
            tbQtde.Text = ""
            lbProduto.Text = ""
            lbVenda.Text = ""
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        tbPedido.Visible = False
        lbPedido.Visible = False
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        tbPedido.Visible = True
        lbPedido.Visible = True
    End Sub

    Private Sub tbCodPro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodPro.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbCodPro.Text = "" Then
                tbTroco.Focus()
            Else
                If IsNumeric(tbCodPro.Text) Then
                    PegaProduto(tbCodPro.Text)

                    strSql = "Select tblCombos_Local.IDProduto, tblCombos_Local.AgregaValor "
                    strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia "
                    strSql += "WHERE tblCombos_Local.IDProduto=" & tbIDProduto.Text
                    If NuloInteger(PegaValorCampo("IDProduto", strSql, strCon)) <> 0 Then
                        AgregaValor = False
                        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.Venda, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                        strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                        strSql += "WHERE (tblProdutos_Local.CodigoProduto = " & tbCodPro.Text & ")"
                        tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                        CodProIni = tbCodPro.Text

                        If NuloInteger(tbIDFamilia.Text) = 0 Then
                            strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                            strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                            strSql += "WHERE (tblProdutos_Local_1.CodigoProduto = " & tbCodPro.Text & ")"
                            tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                            CodProIni = 0
                        End If

                        IDProdutoSel = NuloString(NuloInteger(PegaValorCampo("IDProdutoCorreto", strSql, strCon)))
                        tbIDProduto.Text = IDProdutoSel
                        tbCodigoProduto.Text = NuloString(NuloInteger(PegaValorCampo("CodCorreto", strSql, strCon)))
                        lbProduto.Text = NuloString(PegaValorCampo("ProdCorreto", strSql, strCon))
                        AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))

                        strSql = "Select IDProduto, Venda, CodigoProduto, Produto "
                        strSql += "From tblProdutos_Local "
                        strSql += "WHERE (tblProdutos_Local.CodigoProduto = " & tbCodPro.Text & ")"
                        VlrUnitario = NuloDecimal(PegaValorCampo("Venda", strSql, strCon))

                        Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                        frmFC.tbIDFamilia.Text = tbIDFamilia.Text
                        frmFC.tbEPizza.Text = True
                        frmFC.ShowDialog()

                        tbCodPro.Text = ""
                        tbCodPro.Focus()
                    Else

                        If tbCodigoProduto.Text <> "" Then
                            strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                            strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                            strSql += "Where tblProdutos_Local.CodigoProduto=" & tbCodigoProduto.Text

                            Dim DescCombo As String = ""
                            Dim EPizzaCombo As Boolean = False
                            Dim IDfam As Integer = 0
                            Dim IDprodCorreto As Integer = 0
                            Dim drC As SqlDataReader

                            AgregaValor = False

                            Dim conC As New SqlConnection()
                            conC.ConnectionString = strCon
                            Dim cmdC As SqlCommand = conC.CreateCommand
                            cmdC.CommandText = strSql
                            conC.Open()
                            drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                            If drC.HasRows Then
                                drC.Read()
                                DescCombo = NuloString(drC.Item("ProdCorreto"))
                                EPizzaCombo = NuloBoolean(drC.Item("EPizza"))
                                IDfam = NuloInteger(drC.Item("IDFamilia"))
                                tbIDFamilia.Text = IDfam
                                IDprodCorreto = NuloInteger(drC.Item("IDProdutoCorreto"))
                                AgregaValor = NuloBoolean(drC.Item("AgregaValor"))
                            End If
                            cmdC.Dispose()
                            drC.Close()
                            conC.Dispose()
                            conC.Close()

                            If DescCombo <> "" And EPizzaCombo = True Then
                                lbProduto.Text = DescCombo
                                tbEPizza.Text = EPizzaCombo
                                tbIDProduto.Text = IDprodCorreto
                                tbIDFamilia.Text = IDfam
                                EGrupoPizza = True

                                Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                                frmFC.tbIDFamiliaSel.Text = IDfam
                                frmFC.tbCodPro.Text = NuloInteger(tbCodigoProduto.Text)
                                CodProIni = NuloInteger(tbCodigoProduto.Text)
                                frmFC.ShowDialog()

                                tbCodigoProduto.Text = ""
                                tbIDProduto.Text = ""
                                lbProduto.Text = ""
                                lbValor.Text = ""
                                tbQtde.Text = ""
                                tbCodPro.Text = ""
                                tbCodPro.Focus()
                            Else
                                tbQtde.Focus()
                            End If
                        Else
                            GridProdutos.Rows.Clear()
                            tbCodigoProduto.Text = ""
                            tbIDProduto.Text = ""
                            lbProduto.Text = ""
                            tbQtde.Text = ""
                            tbCodPro.Text = ""
                            lbValor.Text = ""
                            tbCodPro.Focus()
                        End If
                    End If

                Else
                    GridProdutos.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub tbQtde_TextChanged(sender As Object, e As EventArgs) Handles tbQtde.TextChanged
        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um cliente"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbQtde.Text = ""
            tbBuscaCliente.Focus()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dv As New DataView(DataSetGridDel.Tables(0))

        'dv.Sort = "ID DESC, Status DESC"
        dv.Sort = "ID DESC"

        For i = 0 To dv.Count - 1
            MsgBox("0 - ID..................." & NuloInteger(dv.Item(i)("ID")) & vbCrLf &
            "1 - CodigoProduto_TXT..." & NuloInteger(dv.Item(i)("CodigoProduto_TXT")) & vbCrLf &
            "2 - Produto............." & NuloString(dv.Item(i)("Produto")) & vbCrLf &
            "3- Qtde_TXT............" & NuloDecimal(dv.Item(i)("Qtde_TXT")).ToString("F2") & vbCrLf &
            "4 - IDPedido............" & NuloInteger(dv.Item(i)("IDPedido")) & vbCrLf &
            "5 - Status.............." & NuloString(dv.Item(i)("Status")) & vbCrLf &
            "6 - Codigo Produto......." & NuloInteger(dv.Item(i)("CodigoProduto")) & vbCrLf &
            "7 - Qtde................" & NuloDecimal(dv.Item(i)("Qtde")).ToString("F2") & vbCrLf &
            "8 - VlrUni.............." & NuloDecimal(dv.Item(i)("VlrUnit")).ToString("F2") & vbCrLf &
            "9 - VlrUnit_TXT........." & NuloDecimal(dv.Item(i)("VlrUnit_TXT")).ToString("F2") & vbCrLf &
            "10 - VlrTotal............" & NuloDecimal(dv.Item(i)("VlrTotal")).ToString("F2") & vbCrLf &
            "11- VlrTotal_TXT........" & NuloDecimal(dv.Item(i)("VlrTotal_TXT")).ToString("F2") & vbCrLf &
            "12- Atendente..........." & NuloString(dv.Item(i)("Atendente")) & vbCrLf &
            "13- Hora Pedido........." & NuloString(dv.Item(i)("HoraPedido")) & vbCrLf &
            "14- IDGrupo............." & NuloInteger(dv.Item(i)("IDGrupo")) & vbCrLf &
            "15- IDFamilia..........." & NuloInteger(dv.Item(i)("IDFamilia")) & vbCrLf &
            "16- IDDetalhe..........." & NuloInteger(dv.Item(i)("IDDetalhe")) & vbCrLf &
            "17- IDMontagem.........." & NuloInteger(dv.Item(i)("IDMontagem")) & vbCrLf &
            "18- Grupo..............." & NuloString(dv.Item(i)("Grupo")) & vbCrLf &
            "19- Categoria..........." & NuloString(dv.Item(i)("Categoria")) & vbCrLf &
            "20- IDProduto..........." & NuloInteger(dv.Item(i)("IDProduto")) & vbCrLf &
            "21- Excluido............" & NuloBoolean(dv.Item(i)("Excluido")) & vbCrLf &
            "22- IDMovto............." & NuloInteger(dv.Item(i)("IDMovto")) & vbCrLf &
            "23- Pai................." & NuloInteger(dv.Item(i)("Pai")) & vbCrLf &
            "24- Confirmado.........." & NuloBoolean(dv.Item(i)("Confirmado")) & vbCrLf &
            "25- VlrServiço.........." & NuloDecimal(dv.Item(i)("VlrUnitServico")))


        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GridDel.Rows.Count > 0 Then
            For i = 0 To GridDel.Rows.Count - 1
                MsgBox("0 - ID..................." & NuloInteger(GridDel.Item(0, i).Value) & vbCrLf &
                            "1 - CodigoProduto......." & NuloInteger(GridDel.Item(1, i).Value) & vbCrLf &
                            "2 - Produto............." & NuloString(GridDel.Item(2, i).Value) & vbCrLf &
                            "3 - Qtde................" & NuloDecimal(GridDel.Item(3, i).Value) & vbCrLf &
                            "4 - IDPedido............" & NuloInteger(GridDel.Item(4, i).Value) & vbCrLf &
                            "5 - Status.............." & NuloString(GridDel.Item(5, i).Value) & vbCrLf &
                            "6 - ValorTotal........." & NuloDecimal(GridDel.Item(6, i).Value).ToString("F2") & vbCrLf &
                            "7 - ValorTotal.........." & NuloDecimal(GridDel.Item(6, i).Value).ToString("F2") & vbCrLf &
                            "8 - Codigo Produto......" & NuloInteger(GridDel.Item(8, i).Value) & vbCrLf &
                            "9-  Qtde................" & NuloDecimal(GridDel.Item(9, i).Value).ToString("F2") & vbCrLf &
                            "10- ValorUnit..........." & NuloDecimal(GridDel.Item(10, i).Value).ToString("F2") & vbCrLf &
                            "11- ValorUnit..........." & NuloDecimal(GridDel.Item(11, i).Value).ToString("F2") & vbCrLf &
                            "12- Valor Total........." & NuloDecimal(GridDel.Item(12, i).Value) & vbCrLf &
                            "13- Valor Total........." & NuloDecimal(GridDel.Item(13, i).Value) & vbCrLf &
                            "14- Atendente..........." & NuloString(GridDel.Item(14, i).Value) & vbCrLf &
                            "15- Hora Pedido........." & NuloString(GridDel.Item(15, i).Value) & vbCrLf &
                            "16- IDGrupo............." & NuloInteger(GridDel.Item(16, i).Value) & vbCrLf &
                            "17- IDFamilia..........." & NuloInteger(GridDel.Item(17, i).Value) & vbCrLf &
                            "18- IDDetalhe..........." & NuloInteger(GridDel.Item(18, i).Value) & vbCrLf &
                            "19- IDMontagem.........." & NuloInteger(GridDel.Item(19, i).Value) & vbCrLf &
                            "20- Grupo..............." & NuloString(GridDel.Item(20, i).Value) & vbCrLf &
                            "21- Excluido............" & NuloBoolean(GridDel.Item(21, i).Value) & vbCrLf &
                            "22- IDMovto............." & NuloInteger(GridDel.Item(22, i).Value) & vbCrLf &
                            "23- Excluido............" & NuloBoolean(GridDel.Item(23, i).Value) & vbCrLf &
                            "24- Confirmado.........." & NuloBoolean(GridDel.Item(24, i).Value) & vbCrLf &
                            "25- VlrUnitServiço......" & NuloDecimal(GridDel.Item(25, i).Value))


            Next
        End If
    End Sub

    Private Sub GridProdutos_DoubleClick(sender As Object, e As EventArgs) Handles GridProdutos.DoubleClick
        tbIDProduto.Text = ""
        tbCodigoProduto.Text = ""
        lbProduto.Text = ""
        lbVenda.Text = ""
        tbVenda.Text = ""
        tbInformaVenda.Text = ""
        tbEPizza.Text = ""
        tbCodigoGrupo.Text = ""
        tbGrupo.Text = ""
        tbIDFamilia.Text = ""
        tbCategoria.Text = ""
        tbQtde.Text = ""
        tbCodPro.Focus()
        If GridProdutos.Rows.Count > 0 Then
            tbIDProduto.Text = NuloInteger(GridProdutos.Item("IDProduto", GridProdutos.CurrentRow.Index).Value)
            tbCodigoProduto.Text = NuloInteger(GridProdutos.Item("CodigoProduto", GridProdutos.CurrentRow.Index).Value)
            lbProduto.Text = NuloString(GridProdutos.Item("Produto", GridProdutos.CurrentRow.Index).Value)
            lbVenda.Text = NuloDecimal(GridProdutos.Item("Venda", GridProdutos.CurrentRow.Index).Value)
            tbVenda.Text = NuloDecimal(GridProdutos.Item("Venda", GridProdutos.CurrentRow.Index).Value)
            tbInformaVenda.Text = NuloBoolean(GridProdutos.Item("InformaVenda", GridProdutos.CurrentRow.Index).Value)
            tbEPizza.Text = NuloBoolean(GridProdutos.Item("EPizza", GridProdutos.CurrentRow.Index).Value)
            tbCodigoGrupo.Text = NuloInteger(GridProdutos.Item("CodigoGrupo", GridProdutos.CurrentRow.Index).Value)
            tbGrupo.Text = NuloString(GridProdutos.Item("Grupo", GridProdutos.CurrentRow.Index).Value)
            tbIDFamilia.Text = NuloInteger(GridProdutos.Item("IDFamilia", GridProdutos.CurrentRow.Index).Value)
            tbCategoria.Text = NuloString(GridProdutos.Item("Categoria", GridProdutos.CurrentRow.Index).Value)
            tbQtde.Text = "1,000"
            tbQtde.Focus()
            If NuloBoolean(tbEPizza.Text) = True Then

                AgregaValor = False
                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                strSql += "WHERE (tblProdutos_Local.CodigoProduto = " & tbCodigoProduto.Text & ")"

                tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                IDProdutoSel = NuloString(NuloInteger(PegaValorCampo("IDProdutoCorreto", strSql, strCon)))
                tbIDProduto.Text = IDProdutoSel
                tbCodigoProduto.Text = NuloString(NuloInteger(PegaValorCampo("CodCorreto", strSql, strCon)))
                lbProduto.Text = NuloString(PegaValorCampo("ProdCorreto", strSql, strCon))
                AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))


                Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                CodProIni = NuloInteger(tbCodPro.Text)
                frmFC.tbIDFamilia.Text = tbIDFamilia.Text
                frmFC.tbIDProdutoSel.Text = IDProdutoSel
                frmFC.tbEPizza.Text = True

                frmFC.ShowDialog()


                tbCodPro.Text = ""
                tbCodPro.Focus()

                'fdlgCombo_porCodigo.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnLimpaProduto_Click(sender As Object, e As EventArgs) Handles btnLimpaProduto.Click


        If lbStatus.Text = "Estornado" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Impossivel estornar produto desta venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If lbStatus.Text = "Finalizado" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Impossivel estornar produto desta venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If GridDel.SelectedRows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            GridDel.Focus()
            Exit Sub
        End If
        If NuloBoolean(GridDel.Item(24, GridDel.CurrentRow.Index).Value) = False Then
            If GridDel.SelectedRows.Count > 0 Then
                Dim Linha As Integer = -1
                Dim IDMov As Integer = 0
                For i As Integer = 0 To GridDel.Rows.Count - 1
                    If GridDel.Rows(i).Selected = True Then
                        Linha = i
                        IDMov = NuloInteger(GridDel.Item(0, i).Value)
                    End If
                Next

                While Linha >= 0
                    GridDel.Rows.RemoveAt(Linha)
                    Linha = -1
                    For i As Integer = 0 To GridDel.Rows.Count - 1
                        If IDMov = NuloInteger(GridDel.Item(0, i).Value) Then
                            Linha = i
                        End If
                    Next
                End While
            End If

            LinhaGridDelivery()
            'AtualizaGridDelivery()
            CalculaTotaisDelivery()
            StiloGridDelivery()
        Else

            If OperadorEstorna = False Then
                IDFuncionarioAutorizado = 0
                FuncionarioAutorizado = ""
                Dim frm1 As fdlgAutorizacao = New fdlgAutorizacao
                frm1.tbTipo.Text = "E"
                frm1.lbTipo.Text = "Autorização para ESTORNO"

                frm1.ShowDialog()

                If Autorizado = False Then
                    Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
                    frm2.lbMensagem.Text = "Sem permissão para estorno"
                    frm2.btnNao.Visible = False
                    frm2.btnSim.Visible = False
                    frm2.btnOK.Visible = True
                    frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm2.ShowDialog()
                    tbCodPro.Focus()
                    Exit Sub
                End If
            End If

            Dim IDLan As Integer = NuloInteger(GridDel.Item(0, GridDel.CurrentRow.Index).Value)
            Dim frm As fdlgEstornoDelivery = New fdlgEstornoDelivery
            frm.lbProduto.Text = NuloDecimal(GridDel.Item(3, GridDel.CurrentRow.Index).Value).ToString("#0.000") & " - " & NuloString(GridDel.Item(2, GridDel.CurrentRow.Index).Value)
            frm.tbIDMovto.Text = NuloInteger(GridDel.Item(22, GridDel.CurrentRow.Index).Value)
            For i As Integer = 0 To GridDel.Rows.Count - 1
                If NuloInteger(GridDel.Item(0, i).Value) = IDLan Then
                    If NuloString(GridDel.Item(5, i).Value) = "PC" Then
                        frm.lbComent.Text += NuloString(GridDel.Item(2, i).Value) & vbCrLf
                    End If
                    If NuloString(GridDel.Item(5, i).Value) = "M" Then
                        frm.lbComent.Text += ">>> " & NuloString(GridDel.Item(2, i).Value) & vbCrLf
                    End If
                    If NuloString(GridDel.Item(5, i).Value) = "MC" Then
                        frm.lbComent.Text += "--- " & NuloString(GridDel.Item(2, i).Value) & vbCrLf
                    End If
                End If
            Next

            frm.ShowDialog()

            CarregaProdutos(IDVenda)
        End If
    End Sub
    Private Sub btnQtde_Click(sender As Object, e As EventArgs) Handles btnQtde.Click

        If GridDel.SelectedRows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodigoProduto.Focus()
            Exit Sub
        End If
        If NuloBoolean(GridDel.Item(24, GridDel.CurrentRow.Index).Value) = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Produto já confirmado, não será possivel alterar a quantidade"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodigoProduto.Focus()
            Exit Sub
        End If
        If NuloString(GridDel.Item(5, GridDel.CurrentRow.Index).Value) <> "P" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodigoProduto.Focus()
            Exit Sub
        End If


        fdlgAlteraQtde.ShowDialog()


        tbCodPro.Focus()
    End Sub

    Private Sub btnComent_Click(sender As Object, e As EventArgs) Handles btnComent.Click

        If GridDel.SelectedRows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        fdlgComentarioPrincipal.ShowDialog()


    End Sub

    Private Sub btnSalao_Click(sender As Object, e As EventArgs) Handles btnSalao.Click


        If NuloInteger(tbIDCliente.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodPro.Focus()
                Exit Sub
            End If
        End If

        Limpa()
        VerificaPedidoAppFora = True
        Me.Dispose()
        Me.Close()
        Modulo = "S"
        frmSalao.ShowDialog()

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick

        If Tempo = 30 Or Tempo = 60 Then
            strSql = "SELECT IDVendaExterna FROM tblAppVendas WHERE (AppConfirmado=0) and (Excluido=0)"
            If NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon)) <> "" Then
                ExistePedidoApp = True
            Else
                ExistePedidoApp = False
                My.Computer.Audio.Stop()
            End If

            If ExistePedidoApp = True Then
                If ToqueApp <> "" Then
                    My.Computer.Audio.Play(Application.StartupPath & "\" & ToqueApp & ".wav", AudioPlayMode.Background)
                End If
                If btnApp.BackColor = Color.DarkOrange Then
                    btnApp.BackColor = Color.PeachPuff
                Else
                    btnApp.BackColor = Color.DarkOrange
                End If
            Else
                btnApp.BackColor = Color.White
            End If

        Else
            If ExistePedidoApp = True Then
                If btnApp.BackColor = Color.DarkOrange Then
                    btnApp.BackColor = Color.PeachPuff
                Else
                    btnApp.BackColor = Color.DarkOrange
                End If
                If Tempo = 15 Or Tempo = 45 Then
                    If ToqueApp <> "" Then
                        My.Computer.Audio.Play(Application.StartupPath & "\" & ToqueApp & ".wav", AudioPlayMode.Background)
                    End If
                End If
            Else
                My.Computer.Audio.Stop()
                btnApp.BackColor = Color.White
            End If
        End If


        If Tempo >= 60 Then
            lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)
            If NuloBoolean(GerenciaPedidoProgramado) = True Then VerificaPedidosProgramados()
            Tempo = 0
        End If
        Tempo += 1




    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Limpa()
        tcPedidos.SelectTab(0)
        tbBuscaCliente.Focus()
        TravaVenda()
    End Sub
    Private Sub frmDelivery_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.F2
                Me.InvokeOnClick(btnQtde, e)

            Case Keys.KeyCode.F3
                Me.InvokeOnClick(btnLimpaProduto, e)

            Case Keys.KeyCode.F4
                Me.InvokeOnClick(btnComent, e)

            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.F8
                Me.InvokeOnClick(btnInformaPagto, e)

            Case Keys.KeyCode.Escape
                If NuloInteger(tbIDCliente.Text) <> 0 Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                    frm.ShowDialog()

                    If RetornoMsg = False Then
                        tbCodPro.Focus()
                        Exit Sub
                    End If
                End If
                Me.InvokeOnClick(btnVolta, e)

        End Select

    End Sub


    Private Sub cbPagamento_KeyPress(sender As Object, e As KeyPressEventArgs)
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbTroco.Focus()
        End If
    End Sub
    Private Sub tbTroco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTroco.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbDescontoValor.Focus()
        End If
    End Sub

    Private Sub TbTroco_TextChanged(sender As Object, e As EventArgs) Handles tbTroco.TextChanged


    End Sub

    Private Sub TbDescontoValor_TextChanged(sender As Object, e As EventArgs) Handles tbDescontoValor.TextChanged

        If NuloInteger(tbIDCliente.Text) = 0 Then
            tbDescontoValor.Text = ""
            tbBuscaCliente.Focus()
        End If

    End Sub

    Private Sub tbDescontoValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescontoValor.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbDescontoValor.Text = "" Then
                tbDescontoPerc.Focus()
            Else
                If NuloDecimal(tbDescontoValor.Text) <> 0 Then
                    tbComentProducao.Focus()
                Else
                    tbDescontoPerc.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub TbComentProducao_TextChanged(sender As Object, e As EventArgs) Handles tbComentProducao.TextChanged
        If NuloInteger(tbIDCliente.Text) = 0 Then
            tbComentProducao.Text = ""
            tbBuscaCliente.Focus()
        End If
        lbCaracProd.Text = Len(tbComentProducao.Text) & " / 40"
        If Len(tbComentProducao.Text) >= 40 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Maximo 40 caracteres"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbComentProducao.Text = Strings.Left(tbComentProducao.Text, 40)
        End If
    End Sub

    Private Sub tbComentProducao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbComentProducao.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbComentExpedicao.Focus()
        End If
    End Sub

    Private Sub TbComentExpedicao_TextChanged(sender As Object, e As EventArgs) Handles tbComentExpedicao.TextChanged
        If NuloInteger(tbIDCliente.Text) = 0 Then
            tbComentExpedicao.Text = ""
            tbBuscaCliente.Focus()
        End If
        lbCaracExp.Text = Len(tbComentExpedicao.Text) & " / 40"
        If Len(tbComentExpedicao.Text) >= 40 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Maximo 40 caracteres"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbComentExpedicao.Text = Strings.Left(tbComentExpedicao.Text, 40)
        End If
    End Sub

    Private Sub tbComentExpedicao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbComentExpedicao.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbTroco.Focus()
        End If
    End Sub

    Private Sub TbDescontoPerc_TextChanged(sender As Object, e As EventArgs) Handles tbDescontoPerc.TextChanged

        If NuloInteger(tbIDCliente.Text) = 0 Then
            'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            'frm.lbMensagem.Text = "É necessário selecionar um cliente"
            'frm.btnNao.Visible = False
            'frm.btnSim.Visible = False
            'frm.btnOK.Visible = True
            'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            'frm.ShowDialog()
            tbDescontoPerc.Text = ""
            tbBuscaCliente.Focus()
        End If
    End Sub

    Private Sub tbDescontoPerc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescontoPerc.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbComentProducao.Focus()
        End If
    End Sub

    Private Sub tbComentProducao_LostFocus(sender As Object, e As EventArgs) Handles tbComentProducao.LostFocus
        tbComentProducao.Text = UCase(NuloString(tbComentProducao.Text))
    End Sub

    Private Sub tbComentExpedicao_LostFocus(sender As Object, e As EventArgs) Handles tbComentExpedicao.LostFocus
        tbComentExpedicao.Text = UCase(NuloString(tbComentExpedicao.Text))
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If NuloInteger(tbIDCliente.Text) = 0 Then
            frm.lbMensagem.Text = "Cliente inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            GridDel.Focus()
            Exit Sub
        End If
        If GridDel.Rows.Count <= 0 Then
            frm.lbMensagem.Text = "Não existem produtos nesta venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            GridDel.Focus()
            Exit Sub
        End If
        If NuloDecimal(tbTotalPagto.Text) = 0 Then
            frm.lbMensagem.Text = "É necessário informar o pagamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            GridDel.Focus()
            Exit Sub
        End If
        If NuloDecimal(tbTroco.Text) > 0 Then
            If NuloDecimal(tbTroco.Text) <= NuloDecimal(txtTotal.Text) Then
                frm.lbMensagem.Text = "Valor do troco deve ser maior que o valor da venda"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbTroco.Text = "0,00"
                Exit Sub
            End If
        End If
        If NuloString(tbAreaEntrega.Text) = "" Then
            frm.lbMensagem.Text = "Área não informada no local da entrega"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If lbStatus.Text = "Estornado" Then
            frm.lbMensagem.Text = "Impossivel confirmar venda estornada"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If lbStatus.Text = "Finalizado" Then
            frm.lbMensagem.Text = "Impossivel confirmar uma venda já finalizada"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloString(lbOrigem.Text) = "" Then
            frm.lbMensagem.Text = "Origem do cliente não informado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloDecimal(txtTotal.Text) <> NuloDecimal(tbTotalPagto.Text) Then
            frm.lbMensagem.Text = "O valor total do pagamento deve ser igual ao valor total da venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloString(tbCpfCnpj.Text) <> "" And tbCpfCnpj.ForeColor = Color.Maroon Then
            frm.lbMensagem.Text = "CPF ou CNPJ inválido para emissão Do cuppom fiscal"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Confirma o pedido"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        GridDel.Focus()
        If RetornoMsg = False Then Exit Sub

        If NuloInteger(NuloInteger(tbPedido.Text)) = 0 Then
            AbreVendaDelivery(NuloDecimal(tbDescontoPerc.Text), 0, Operador, IDOperador, NuloInteger(tbIDCliente.Text), NuloInteger(tbIDRuaEntrega.Text), Replace(NuloString(tbCEPEntrega.Text), "-", ""), NuloString(tbNumeroEntrega.Text), NuloString(tbAreaEntrega.Text), NuloString(tbComplementoEntrega.Text), NuloString(tbReferenciaEntrega.Text), NuloString(tbComentProducao.Text), NuloString(tbComentExpedicao.Text), NuloString(lbCliente.Text), NuloDecimal(tbTroco.Text), NuloBoolean(chkPedidoProg.Checked), NuloString(tbIDVendaExterna.Text), NuloString(tbLogradouroEntrega.Text))
        Else
            EditaVendaDelivery(NuloDecimal(tbDescontoPerc.Text), 0, Operador, IDOperador, NuloInteger(tbIDCliente.Text), NuloInteger(tbIDRuaEntrega.Text), Replace(NuloString(tbCEPEntrega.Text), "-", ""), NuloString(tbNumeroEntrega.Text), NuloString(tbAreaEntrega.Text), NuloString(tbComplementoEntrega.Text), NuloString(tbReferenciaEntrega.Text), NuloString(tbComentProducao.Text), NuloString(tbComentExpedicao.Text), NuloString(lbCliente.Text), NuloDecimal(tbTroco.Text), NuloBoolean(chkPedidoProg.Checked), NuloString(tbIDVendaExterna.Text), NuloString(tbLogradouroEntrega.Text))
        End If

        PedidoDeliveryProgramado = False
        Dim PedidoProgAutomatico As Boolean = False
        If chkPedidoProg.Checked = True And NuloBoolean(tbPedidoProgEnviado.Text) = False Then
            PedidoDeliveryProgramado = True
            Dim frmP As fdlgDelivery_PedidoProgramado = New fdlgDelivery_PedidoProgramado
            frmP.tbIDVenda.Text = IDVenda
            strSql = "Select IDVenda, PedidoProgAutomatico, PedidoProgEnvioAs FROM tblVendas WHERE IDVenda=" & IDVenda
            If NuloBoolean(PegaValorCampo("PedidoProgAutomatico", strSql, strCon)) = True Then
                frmP.chkPedidoProgAutomatico.Checked = True
                frmP.DtTime.Value = PegaValorCampo("PedidoProgEnvioAs", strSql, strCon)
                PedidoProgAutomatico = True
            Else
                frmP.chkPedidoProgAutomatico.Checked = False
                frmP.DtTime.Value = Now.Date & " " & Now.TimeOfDay.ToString
                frmP.DtTime.Visible = False
                frmP.Label2.Visible = False
                PedidoProgAutomatico = False
            End If

            frmP.ShowDialog()

        End If


        Dim PNota As Integer
        strSql = "Select IDVenda, PreNota FROM tblVendas WHERE IDVenda=" & IDVenda
        PNota = NuloInteger(PegaValorCampo("PreNota", strSql, strCon))

        Dim ImprimePedidos As Boolean = True
        Dim ImprimeExpedicao As Boolean = True
        If PNota > 1 And PedidoDeliveryProgramado = False Then

            EnviaPedidoDel(False)

            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Imprime expedição"
            frm2.btnNao.Visible = True
            frm2.btnSim.Visible = True
            frm2.btnOK.Visible = False
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            GridDel.Focus()
            If RetornoMsg = False Then ImprimeExpedicao = False


            Dim frm3 As fdlgMensagemBox = New fdlgMensagemBox
            frm3.lbMensagem.Text = "Imprime pedidos"
            frm3.btnNao.Visible = True
            frm3.btnSim.Visible = True
            frm3.btnOK.Visible = False
            frm3.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm3.ShowDialog()
            GridDel.Focus()
            If RetornoMsg = False Then
                ImprimePedidos = False
                '        Envia = True
            Else
                strSql = "UPDATE tblVendasCombo Set "
                strSql &= "Impresso=0 "
                strSql &= "WHERE (IDVenda=" & IDVenda & ")"
                ExecutaStr(strSql)

                strSql = "UPDATE tblVendasMovto Set "
                strSql &= "Enviado=1, "
                strSql &= "Impresso=0 "
                strSql &= "WHERE (IDVenda=" & IDVenda & ")"
                ExecutaStr(strSql)
                '       Envia = False
            End If
        Else
            EnviaPedidoDel(True)
        End If



        '    EnviaPedidoDel(Envia)
        Dim Pagamento As Decimal
        If NuloDecimal(tbTroco.Text) > 0 Then
            Pagamento = NuloDecimal(tbTroco.Text)
        Else
            Pagamento = NuloDecimal(txtTotal.Text)
        End If


        ExecutaStr("DELETE tblVendasPagto WHERE (IDVenda=" & IDVenda & ")")
        ExecutaStr("DELETE tblPendenciasLoja WHERE (IDVendaRet=" & IDVenda & ")")

        For i As Integer = 0 To lstPagtosVenda.Items.Count - 1

            SqlStr = "Select IDFormaPagto, Tipo FROM tblFormaPagtos_Local WHERE (IDFormaPagto=" & NuloInteger(lstPagtosVenda.Items(i).SubItems(1).Text) & ")"

            RetornoPendenciaInclusaoIDPendencia = "0"
            RetornoPendenciaInclusaoIDCliente = tbIDCliente.Text
            If NuloString(lstPagtosVenda.Items(i).SubItems(2).Text) = "PENDENCIA" Then

                RetornoPendenciaInclusaoIDPendencia = ""
                Dim frmP As fdlgPendencias_Inclusao = New fdlgPendencias_Inclusao
                frmP.lbValor.Text = NuloDecimal(lstPagtosVenda.Items(i).SubItems(3).Text)
                frmP.tbIDpagto.Text = NuloInteger(lstPagtosVenda.Items(i).SubItems(1).Text)
                frmP.ShowDialog()
                If RetornoPendenciaInclusaoIDPendencia = "" Then Exit Sub
            End If

            strSql = "INSERT tblVendasPagto (IDVenda, IDFormaPagto, Descricao, ValorPago, ECartao, TaxaCartao, Tipo, Cupom, IDCliente, IDPendencia) VALUES ("
            strSql += to_sql(IDVenda) & ","
            strSql += to_sql(NuloInteger(lstPagtosVenda.Items(i).SubItems(1).Text)) & ","
            strSql += to_sql(NuloString(lstPagtosVenda.Items(i).SubItems(2).Text)) & ","
            strSql += to_sql(Replace(lstPagtosVenda.Items(i).SubItems(3).Text, ",", ".")) & ","
            strSql += "0, 0, '" & NuloString(PegaValorCampo("Tipo", SqlStr, strCon)) & "', 0,"
            strSql += to_sql(NuloInteger(RetornoPendenciaInclusaoIDCliente)) & ","
            strSql += to_sql(NuloInteger(RetornoPendenciaInclusaoIDPendencia)) & ")"
            ExecutaStr(strSql)
        Next


        ' Atualiza App   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If NuloString(tbIDVendaExterna.Text) <> "" And PNota <= 1 Then
            strSql = "UPDATE tblAppVendas SET "
            strSql &= "NumVendaD=" & NumVendaD & ", "
            strSql &= "Status='', "
            strSql &= "AppConfirmado=1 "
            strSql &= "WHERE (IDVendaExterna='" & tbIDVendaExterna.Text & "')"
            ExecutaStr(strSql)

            Dim App As String = NuloString(PegaValorCampo("App", "SELECT App, IDVendaExterna FROM tblVendas WHERE (IDVendaExterna='" & tbIDVendaExterna.Text & "')", strCon))
            If IntegracaoIfood = True And App = "IFOOD" Then
                If NuloString(token_accessIfood) = "" Then
                    PegaToken_iFood()
                End If
                If token_accessIfood <> "" Then
                    If DateDiff(DateInterval.Minute, Now, DateAdd(DateInterval.Minute, -5, token_DataHoraFim_Ifood)) < 0 Then
                        PegaToken_iFood()
                    End If
                    MudarStatus(tbIDVendaExterna.Text, "confirmation", App)
                End If
            End If
            If IntegracaoQRbox = True And App = "QRBOX" Then
                If NuloString(token_accessQRbox) = "" Then
                    PegaToken_QRbox()
                End If
                If token_accessIfood <> "" Then
                    If DateDiff(DateInterval.Minute, Now, DateAdd(DateInterval.Minute, -5, token_DataHoraFim_QRbox)) < 0 Then
                        PegaToken_QRbox()
                    End If
                    MudarStatus(tbIDVendaExterna.Text, "confirmation", App)
                End If
            End If
        End If


        If ImprimeExpedicao = True And PedidoDeliveryProgramado = False Then
            CriaExpedicao(IDVenda)
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



        strSql = "SELECT IDVendaExterna FROM tblAppVendas WHERE (AppConfirmado=0) and (Excluido=0)"
        If NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon)) <> "" Then
            ExistePedidoApp = True
        Else
            ExistePedidoApp = False
            My.Computer.Audio.Stop()

        End If

        tbBuscaCliente.Focus()

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Pedido enviado com sucesso"
        frm1.btnNao.Visible = False
        frm1.btnSim.Visible = False
        frm1.btnOK.Visible = True
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm1.ShowDialog()
        Limpa()



    End Sub

    Private Sub tbTroco_LostFocus(sender As Object, e As EventArgs) Handles tbTroco.LostFocus
        If tbTroco.Text = "" Then
            tbTroco.Text = Format(0, "#0.00")
        Else
            tbTroco.Text = Format(NuloDecimal(tbTroco.Text), "#0.00")
        End If
        If NuloDecimal(tbTroco.Text) > 0 Then
            If NuloDecimal(tbTroco.Text) <= NuloDecimal(txtTotal.Text) Then

                tbTroco.Text = 0.00
                tbTroco.Refresh()

                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Valor do troco deve ser maior que o valor da venda"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If lstPedidos.SelectedItems.Count > 0 Then
            For i As Integer = 0 To lstPedidos.Items.Count - 1
                If lstPedidos.Items(i).Selected = True Then
                    IDVenda = NuloInteger(lstPedidos.Items(i).SubItems(0).Text)
                    tcPedidos.SelectTab(0)
                    CarregaDadosVenda(IDVenda)
                    CarregaProdutos(IDVenda)

                End If
            Next i
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbBusca.Text = ""
        cbAtendente.Text = ""
        cbEntregador.Text = ""
        chkTodos.Checked = True
        PreenchePedidos()
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreenchePedidos()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TerminalExpedicao = True Or ExpedicaoPadrao = True Then

            fdlgExpedicao.ShowDialog()

        Else
            If lstPedidos.SelectedItems.Count > 0 Then
                For i As Integer = 0 To lstPedidos.Items.Count - 1
                    If lstPedidos.Items(i).Selected = True Then
                        If lstPedidos.Items(i).SubItems(13).Text = "P" Or lstPedidos.Items(i).SubItems(13).Text = "E" Then

                            Dim frm As fdlgDelivery_Expedicao = New fdlgDelivery_Expedicao
                            frm.tbVenda.Text = NuloInteger(lstPedidos.Items(i).SubItems(1).Text)
                            frm.ShowDialog()

                        Else
                            Dim Status As String
                            If lstPedidos.Items(i).SubItems(13).Text = "X" Then
                                Status = "estornada"
                            Else
                                If lstPedidos.Items(i).SubItems(13).Text = "F" Then
                                    Status = "finalizada"
                                End If
                            End If
                            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                            frm1.lbMensagem.Text = "Impossivel fazer a expedição do pedido " & lstPedidos.Items(i).SubItems(1).Text & vbCrLf & "Pois encontra-se " & Status
                            frm1.btnNao.Visible = False
                            frm1.btnSim.Visible = False
                            frm1.btnOK.Visible = True
                            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm1.ShowDialog()
                        End If
                    End If
                Next i
            End If
        End If
        PreenchePedidos()

    End Sub

    Private Sub BtnPagamento_Click(sender As Object, e As EventArgs) Handles btnPagamento.Click

        If lstPedidos.SelectedItems.Count > 0 Then

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
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "Operador (" & Operador & ") sem permissão ou movimento não aberto"
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm1.ShowDialog()
                Exit Sub
            End If
            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()


            strSql = "Select IDFuncionario, ModulosCaixa From tblFuncionarios_Local Where (IDFuncionario = " & IDOperador & ")"
            Dim ModCx As String = NuloString(PegaValorCampo("ModulosCaixa", strSql, strCon))
            If NuloString(ModCx) <> "" Then
                If NuloString(ModCx) <> "T" Then
                    If InStr(1, NuloString(ModCx), "D") = 0 Then
                        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                        frm1.lbMensagem.Text = "Operador (" & Operador & ") sem permissão para finalizar venda no módulo DELIVERY"
                        frm1.btnNao.Visible = False
                        frm1.btnSim.Visible = False
                        frm1.btnOK.Visible = True
                        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm1.ShowDialog()
                        Exit Sub
                    End If
                End If
            End If




            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja realmente finalizar as vendas selecionadas"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = True Then
                For i As Integer = 0 To lstPedidos.Items.Count - 1
                    If lstPedidos.Items(i).Selected = True Then
                        If lstPedidos.Items(i).SubItems(13).Text = "E" Then

                            FinalizaVenda(NuloInteger(lstPedidos.Items(i).SubItems(0).Text))

                        Else
                            Dim Status As String
                            If lstPedidos.Items(i).SubItems(13).Text = "X" Then
                                Status = "estornada"
                            Else
                                If lstPedidos.Items(i).SubItems(13).Text = "P" Then
                                    Status = "em produção"
                                Else
                                    If lstPedidos.Items(i).SubItems(13).Text = "F" Then
                                        Status = "finalizada"
                                    End If
                                End If
                            End If
                            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                            frm1.lbMensagem.Text = "Impossivel finalizar a venda " & lstPedidos.Items(i).SubItems(1).Text & vbCrLf & "Pois encontra-se " & Status
                            frm1.btnNao.Visible = False
                            frm1.btnSim.Visible = False
                            frm1.btnOK.Visible = True
                            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm1.ShowDialog()
                        End If
                    End If
                Next i
                PreenchePedidos()
            End If
        Else
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Selecione pelo menos uma venda"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End If

    End Sub

    Private Sub ChkProducao_CheckedChanged(sender As Object, e As EventArgs) Handles chkProducao.CheckedChanged
        PreenchePedidos()
    End Sub

    Private Sub ChkEntregando_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregando.CheckedChanged
        PreenchePedidos()
    End Sub

    Private Sub ChkFinal_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinal.CheckedChanged
        PreenchePedidos()
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        PreenchePedidos()
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        ' chkTodos.Checked = True
        PreenchePedidos()
        PreencheAtendentes()
        PreencheEntregador()
        'MsgBox("OK")
    End Sub

    Private Sub GridProdutos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridProdutos.KeyDown

        If e.KeyValue = 13 Then
            e.Handled = True

            If GridProdutos.Rows.Count = 0 Then
                If NuloString(tbCodPro.Text) <> "" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Produto não encontrado"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbCodPro.Text = ""
                    tbCodPro.Focus()
                End If
                Exit Sub
            End If

            PegaProduto(NuloInteger(GridProdutos.Item("CodigoProduto", GridProdutos.CurrentRow.Index).Value))

            If NuloBoolean(tbEPizza.Text) = True Then
                'Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                ''frmFC.tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                ''frmFC.tbIDFamilia.Text = NuloInteger(IDfam)
                'frmFC.tbIDFamilia.Text = ""
                ''frmFC.tbCodProIni.Text = ""
                'frmFC.ShowDialog()

                tbCodPro.Text = NuloInteger(GridProdutos.Item("CodigoProduto", GridProdutos.CurrentRow.Index).Value)

                AgregaValor = False
                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                strSql += "WHERE (tblProdutos_Local.CodigoProduto = " & tbCodPro.Text & ")"
                tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                CodProIni = tbCodPro.Text

                If NuloInteger(tbIDFamilia.Text) = 0 Then
                    strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                    strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                    strSql += "WHERE (tblProdutos_Local_1.CodigoProduto = " & tbCodPro.Text & ")"
                    tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                    CodProIni = 0
                End If
                IDProdutoSel = NuloString(NuloInteger(PegaValorCampo("IDProdutoCorreto", strSql, strCon)))
                tbIDProduto.Text = IDProdutoSel
                tbCodigoProduto.Text = NuloString(NuloInteger(PegaValorCampo("CodCorreto", strSql, strCon)))
                lbProduto.Text = NuloString(PegaValorCampo("ProdCorreto", strSql, strCon))
                AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))


                Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                frmFC.tbIDFamilia.Text = tbIDFamilia.Text
                frmFC.tbEPizza.Text = True

                frmFC.ShowDialog()


                tbCodPro.Text = ""
                tbCodPro.Focus()






            Else

                If tbCodigoProduto.Text <> "" Then
                    ' Verifica se é produto COMBO   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza "
                    'strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "

                    strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                    strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                    strSql += "Where tblProdutos_Local.CodigoProduto=" & tbCodigoProduto.Text

                    Dim DescCombo As String = ""
                    Dim EPizzaCombo As Boolean = False
                    Dim IDfam As Integer = 0
                    Dim IDprodCorreto As Integer = 0
                    Dim drC As SqlDataReader

                    AgregaValor = False

                    Dim conC As New SqlConnection()
                    conC.ConnectionString = strCon
                    Dim cmdC As SqlCommand = conC.CreateCommand
                    cmdC.CommandText = strSql
                    conC.Open()
                    drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    If drC.HasRows Then
                        drC.Read()
                        DescCombo = NuloString(drC.Item("ProdCorreto"))
                        EPizzaCombo = NuloBoolean(drC.Item("EPizza"))
                        IDfam = NuloInteger(drC.Item("IDFamilia"))
                        IDprodCorreto = NuloInteger(drC.Item("IDProdutoCorreto"))
                        AgregaValor = NuloBoolean(drC.Item("AgregaValor"))
                        'tbCodigoProduto.Text = NuloInteger(drC.Item("CodCorreto"))
                    End If
                    cmdC.Dispose()
                    drC.Close()
                    conC.Dispose()
                    conC.Close()

                    If DescCombo <> "" And EPizzaCombo = True Then
                        lbProduto.Text = DescCombo
                        tbEPizza.Text = EPizzaCombo
                        tbIDProduto.Text = IDprodCorreto
                        tbIDFamilia.Text = IDfam
                        EGrupoPizza = True

                        Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                        frmFC.tbIDFamiliaSel.Text = IDfam
                        frmFC.tbCodPro.Text = NuloInteger(tbCodigoProduto.Text)
                        CodProIni = NuloInteger(tbCodigoProduto.Text)

                        frmFC.ShowDialog()



                        tbCodigoProduto.Text = ""
                        tbIDProduto.Text = ""
                        'lbProduto.Text = ""
                        tbQtde.Text = ""
                        tbCodPro.Text = ""
                        tbCodPro.Focus()

                        'Else
                        'Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                        'frmFC.tbIDFamilia.Text = NuloInteger(IDfam)
                        'frmFC.tbCodProIni.Text = ""
                        'frmFC.ShowDialog()
                    Else
                        tbQtde.Focus()
                    End If

                    'strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDProduto, tblCombos_Local.IDFamilia, tblGrupos_Local.EPizza, tblCombos_Local.AgregaValor "
                    'strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                    'strSql += "Where (tblCombos_Local.IDProduto = " & NuloInteger(tbIDProduto.Text) & ")"

                    'Dim frmF As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                    'frmF.tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))
                    'frmF.ShowDialog()

                    'tbCodigoProduto.Text = ""
                    'tbIDProduto.Text = ""
                    'lbProduto.Text = ""
                    'tbQtde.Text = ""
                    'tbCodPro.Text = ""
                    'tbQtde.Focus()
                Else
                    GridProdutos.Rows.Clear()
                    tbCodigoProduto.Text = ""
                    tbIDProduto.Text = ""
                    lbProduto.Text = ""
                    tbQtde.Text = ""
                    tbCodPro.Text = ""
                    tbCodPro.Focus()
                End If
            End If



            'tbIDProduto.Text = ""
            'tbCodigoProduto.Text = ""
            'lbProduto.Text = ""
            'lbVenda.Text = ""
            'tbVenda.Text = ""
            'tbInformaVenda.Text = ""
            'tbEPizza.Text = ""
            'tbCodigoGrupo.Text = ""
            'tbGrupo.Text = ""
            'tbIDFamilia.Text = ""
            'tbCategoria.Text = ""
            'tbQtde.Text = ""
            'tbCodPro.Focus()
            'If GridProdutos.Rows.Count > 0 Then
            'tbIDProduto.Text = NuloInteger(GridProdutos.Item("IDProduto", GridProdutos.CurrentRow.Index).Value)
            'tbCodigoProduto.Text = NuloInteger(GridProdutos.Item("CodigoProduto", GridProdutos.CurrentRow.Index).Value)
            'lbProduto.Text = NuloString(GridProdutos.Item("Produto", GridProdutos.CurrentRow.Index).Value)
            'lbVenda.Text = NuloDecimal(GridProdutos.Item("Venda", GridProdutos.CurrentRow.Index).Value)
            'tbVenda.Text = NuloDecimal(GridProdutos.Item("Venda", GridProdutos.CurrentRow.Index).Value)
            'tbInformaVenda.Text = NuloBoolean(GridProdutos.Item("InformaVenda", GridProdutos.CurrentRow.Index).Value)
            'tbEPizza.Text = NuloBoolean(GridProdutos.Item("EPizza", GridProdutos.CurrentRow.Index).Value)
            'tbCodigoGrupo.Text = NuloInteger(GridProdutos.Item("CodigoGrupo", GridProdutos.CurrentRow.Index).Value)
            'tbGrupo.Text = NuloString(GridProdutos.Item("Grupo", GridProdutos.CurrentRow.Index).Value)
            'tbIDFamilia.Text = NuloInteger(GridProdutos.Item("IDFamilia", GridProdutos.CurrentRow.Index).Value)
            'tbCategoria.Text = NuloString(GridProdutos.Item("Categoria", GridProdutos.CurrentRow.Index).Value)
            'tbQtde.Text = "1,000"
            'tbQtde.Focus()
            'If NuloBoolean(tbEPizza.Text) = True Then
            'fdlgCombo_porCodigo.ShowDialog()
            'End If
            'End If
        End If
    End Sub
    Private Sub lstPedidos_DoubleClick(sender As Object, e As EventArgs) Handles lstPedidos.DoubleClick
        If lstPedidos.SelectedItems.Count > 0 Then
            For i As Integer = 0 To lstPedidos.Items.Count - 1
                If lstPedidos.Items(i).Selected = True Then
                    IDVenda = NuloInteger(lstPedidos.Items(i).SubItems(0).Text)

                    If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "P" Then
                        lbStatus.Text = "Em produção"
                    End If
                    If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "X" Then
                        lbStatus.Text = "Estornado"
                    End If
                    If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "F" Then
                        lbStatus.Text = "Finalizado"
                    End If
                    If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "E" Then
                        lbStatus.Text = "Entregando"
                    End If

                    tcPedidos.SelectTab(0)
                    CarregaDadosVenda(IDVenda)
                    CarregaProdutos(IDVenda)
                End If
            Next i
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        fdlgDelivery_Ruas.ShowDialog()

        tbBuscaCliente.Focus()
    End Sub

    Private Sub lstPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPedidos.SelectedIndexChanged

    End Sub

    Private Sub lstPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles lstPedidos.KeyDown
        If e.KeyCode = 13 Then
            If lstPedidos.SelectedItems.Count > 0 Then
                For i As Integer = 0 To lstPedidos.Items.Count - 1
                    If lstPedidos.Items(i).Selected = True Then
                        IDVenda = NuloInteger(lstPedidos.Items(i).SubItems(0).Text)

                        If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "P" Then
                            lbStatus.Text = "Em produção"
                        End If
                        If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "X" Then
                            lbStatus.Text = "Estornado"
                        End If
                        If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "F" Then
                            lbStatus.Text = "Finalizado"
                        End If
                        If NuloString(lstPedidos.Items(i).SubItems(13).Text) = "E" Then
                            lbStatus.Text = "Entregando"
                        End If

                        tcPedidos.SelectTab(0)
                        CarregaDadosVenda(IDVenda)
                        CarregaProdutos(IDVenda)

                    End If
                Next i
            End If
        End If
    End Sub

    Private Sub GridDel_Click(sender As Object, e As EventArgs) Handles GridDel.Click
        If GridDel.Rows.Count > 0 Then
            If NuloBoolean(GridDel.Item(24, GridDel.CurrentRow.Index).Value) = True Then
                btnQtde.Enabled = False
                btnComent.Enabled = False
                btnLimpaProduto.Text = "ESTORNA produto F3"
            Else
                btnQtde.Enabled = True
                btnComent.Enabled = True
                btnLimpaProduto.Text = "LIMPA produto F3"
            End If
        End If
    End Sub

    Private Sub BtnTaxaEntrega_Click(sender As Object, e As EventArgs) Handles btnTaxaEntrega.Click
        If NuloString(tbLogradouroEntrega.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Endereço de entrega inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else

            fdlgDelivery_AreaEntrega_Entrega.ShowDialog()

            If NuloString(tbAreaEntrega.Text) <> "" Then
                strSql = "SELECT Area, TaxaEntrega FROM tblAreas WHERE (Area='" & NuloString(tbAreaEntrega.Text) & "')"
                lbTaxaEntregaEntrega.Text = NuloString(NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon)))
                tbBuscaCliente.Focus()
            Else
                tbAreaEntrega.Text = ""
                lbTaxaEntregaEntrega.Text = ""
            End If
            txtServico.Text = Format(NuloDecimal(lbTaxaEntregaEntrega.Text), "#0.00")
            CalculaTotaisDelivery()
            tbCodPro.Focus()
        End If
    End Sub

    Private Sub BtnAlteraEnderecoEntrega_Click(sender As Object, e As EventArgs) Handles btnAlteraEnderecoEntrega.Click
        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um cliente"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else
            '
            fdlgDeliveryEnderecoEntrega.ShowDialog()
            '
            txtServico.Text = Format(NuloDecimal(lbTaxaEntregaEntrega.Text), "#0.00")
            tbCodPro.Focus()

        End If

    End Sub

    Private Sub tbBuscaCliente_GotFocus(sender As Object, e As EventArgs) Handles tbBuscaCliente.GotFocus
        tcPedidos.SelectTab(0)
    End Sub

    Private Sub CbAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAtendente.SelectedIndexChanged
        PreenchePedidos()
    End Sub

    Private Sub CbEntregador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEntregador.SelectedIndexChanged
        PreenchePedidos()
    End Sub

    Private Sub tbCodPro_GotFocus(sender As Object, e As EventArgs) Handles tbCodPro.GotFocus
        If IsNumeric(tbPedido.Text) Then
            PedidoVenda = False
        Else
            PedidoVenda = True
        End If
    End Sub

    Private Sub tbCaixinha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCaixinha.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbDescontoValor.Focus()
        End If
    End Sub

    Private Sub BtnBalcao_Click(sender As Object, e As EventArgs) Handles btnBalcao.Click

        If NuloInteger(tbIDCliente.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodPro.Focus()
                Exit Sub
            End If
        End If

        Limpa()
        VerificaPedidoAppFora = True
        Me.Dispose()
        Me.Close()
        Modulo = "B"
        frmSalao.ShowDialog()
    End Sub

    Private Sub BtnEstornoVenda_Click(sender As Object, e As EventArgs) Handles btnEstornoVenda.Click

        If OperadorEstorna = False Then
            IDFuncionarioAutorizado = 0
            FuncionarioAutorizado = ""
            Dim frm1 As fdlgAutorizacao = New fdlgAutorizacao
            frm1.tbTipo.Text = "E"
            frm1.lbTipo.Text = "Autorização para ESTORNO"

            frm1.ShowDialog()

            If Autorizado = False Then
                Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
                frm2.lbMensagem.Text = "Sem permissão para estorno"
                frm2.btnNao.Visible = False
                frm2.btnSim.Visible = False
                frm2.btnOK.Visible = True
                frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm2.ShowDialog()
                tbCodPro.Focus()
                Exit Sub
            End If
        End If

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lstPedidos.SelectedItems.Count <> 0 Then
            For i As Integer = 0 To lstPedidos.Items.Count - 1
                If lstPedidos.Items(i).Selected = True Then
                    If lstPedidos.Items(i).SubItems(13).Text = "X" Then
                        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                        frm1.lbMensagem.Text = "Venda " & lstPedidos.Items(i).SubItems(1).Text & vbCrLf & "ja foi estornada"
                        frm1.btnNao.Visible = False
                        frm1.btnSim.Visible = False
                        frm1.btnOK.Visible = True
                        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm1.ShowDialog()
                    Else
                        If lstPedidos.Items(i).SubItems(13).Text = "F" Then
                            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                            frm1.lbMensagem.Text = "Venda já finalizada, não será possivel estorna-la"
                            frm1.btnNao.Visible = False
                            frm1.btnSim.Visible = False
                            frm1.btnOK.Visible = True
                            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm1.ShowDialog()
                            Exit Sub
                        End If

                        Dim frm2 As fdlgEstornoDelivery = New fdlgEstornoDelivery
                        frm2.tbIDVenda.Text = NuloInteger(lstPedidos.Items(i).SubItems(0).Text)
                        frm2.lbProduto.Text = "Confirma o estono da venda " & NuloString(lstPedidos.Items(i).SubItems(1).Text)
                        frm2.Text = "Estorno de Venda"

                        frm2.ShowDialog()

                    End If
                End If
            Next
        Else
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Selecione uma venda"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End If
        PreenchePedidos()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        If tbLogradouroEntrega.Text = "" Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Endereço inválido"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        Else
            Dim frm As fdlgGoogleMaps = New fdlgGoogleMaps
            frm.lbLogradouro.Text = tbLogradouroEntrega.Text
            frm.lbNumero.Text = tbNumeroEntrega.Text
            frm.lbCEP.Text = tbCEPEntrega.Text
            frm.lbComplemento.Text = tbComplementoEntrega.Text
            frm.lbBairro.Text = tbBairroEntrega.Text
            frm.ShowDialog()
        End If

    End Sub


    Private Sub BtnUltimoPedido_Click(sender As Object, e As EventArgs) Handles btnUltimoPedido.Click
        If NuloInteger(tbIDCliente.Text) <> 0 Then

            fdlgDeliveryUltimoPedido_Frequencia.ShowDialog()

        Else
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "É necessário selecionar um cliente"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End If
    End Sub


    Private Sub tbDDD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDDD.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbBuscaCliente.Focus()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Dim frm1 As fdlgProdutosObs = New fdlgProdutosObs
        If NuloString(tbCodPro.Text) <> "" Then
            frm1.tbBusca.Text = NuloString(tbCodPro.Text)
        End If

        frm1.ShowDialog()

        tbCodPro.Focus()
    End Sub

    Private Sub TbCaixinha_TextChanged(sender As Object, e As EventArgs) Handles tbCaixinha.TextChanged
        If NuloInteger(tbIDCliente.Text) = 0 Then
            'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            'frm.lbMensagem.Text = "É necessário selecionar um cliente"
            'frm.btnNao.Visible = False
            'frm.btnSim.Visible = False
            'frm.btnOK.Visible = True
            'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            'frm.ShowDialog()
            tbCaixinha.Text = ""
            tbBuscaCliente.Focus()
        End If
    End Sub

    Private Sub tbCaixinha_LostFocus(sender As Object, e As EventArgs) Handles tbCaixinha.LostFocus
        If tbCaixinha.Text = "" Then
            tbCaixinha.Text = Format(0, "#0.00")
        Else
            tbCaixinha.Text = Format(NuloDecimal(tbCaixinha.Text), "#0.00")
        End If
        lbCaixinha.Text = Format(NuloDecimal(tbCaixinha.Text), "#0.00")
        CalculaTotaisDelivery()
    End Sub

    Private Sub tbDescontoValor_LostFocus(sender As Object, e As EventArgs) Handles tbDescontoValor.LostFocus
        If tbDescontoValor.Text = "" Then
            tbDescontoValor.Text = Format(0, "#0.00")
        End If
        tbDescontoValor.Text = Format(NuloDecimal(tbDescontoValor.Text), "#0.00")
        If NuloDecimal(tbDescontoValor.Text) <> 0 Then
            tbDescontoPerc.Text = Format((NuloDecimal(tbDescontoValor.Text) / NuloDecimal(txtProdutos.Text)) * 100, "#0.000")
            txtDesconto.Text = tbDescontoValor.Text
            CalculaTotaisDelivery()
        Else
            tbDescontoPerc.Text = Format(0, "#0.000")
            txtDesconto.Text = tbDescontoValor.Text
            CalculaTotaisDelivery()
        End If

    End Sub

    Private Sub tbDescontoPerc_LostFocus(sender As Object, e As EventArgs) Handles tbDescontoPerc.LostFocus
        If tbDescontoPerc.Text = "" Then
            tbDescontoPerc.Text = Format(0, "#0.00")
        End If
        tbDescontoPerc.Text = Format(NuloDecimal(tbDescontoPerc.Text), "#0.000")
        If NuloDecimal(tbDescontoPerc.Text) <> 0 Then
            tbDescontoValor.Text = Format(NuloDecimal(txtProdutos.Text) * (NuloDecimal(tbDescontoPerc.Text) / 100), "#0.00")
            tbDescontoPerc.Text = Format(NuloDecimal(tbDescontoPerc.Text), "#0.000")
            CalculaTotaisDelivery()
            txtDesconto.Text = tbDescontoValor.Text
        Else
            tbDescontoValor.Text = Format(0, "#0.00")
            tbDescontoPerc.Text = Format(NuloDecimal(tbDescontoPerc.Text), "#0.000")
            CalculaTotaisDelivery()
            txtDesconto.Text = tbDescontoValor.Text
        End If

    End Sub

    Private Sub TbIDVendaRet_TextChanged(sender As Object, e As EventArgs) Handles tbIDVendaRet.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tbIDVenda.TextChanged

    End Sub

    Private Sub BtnInformaPagto_Click(sender As Object, e As EventArgs) Handles btnInformaPagto.Click

        fdlgDelivery_Pagto.ShowDialog()

        CalculaTotaisDelivery()
    End Sub

    Private Sub ChkTipoLancto_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoLancto.CheckedChanged
        If chkTipoLancto.Checked = True Then
            Label48.Visible = True
            tbCpfCnpj.Visible = True
        Else
            Label48.Visible = False
            tbCpfCnpj.Visible = False
            tbCpfCnpj.Text = ""
        End If
    End Sub

    Private Sub TbCpfCnpj_TextChanged(sender As Object, e As EventArgs) Handles tbCpfCnpj.TextChanged
        If Len(tbCpfCnpj.Text) = 11 Then
            FU_ValidaCPF(tbCpfCnpj.Text)
            If ValidaCPF_CNPJ = True Then
                tbCpfCnpj.ForeColor = Color.ForestGreen
            Else
                tbCpfCnpj.ForeColor = Color.Maroon
            End If
        Else
            If Len(tbCpfCnpj.Text) = 14 Then
                FU_ValidaCNPJ(tbCpfCnpj.Text)
                If ValidaCPF_CNPJ = True Then
                    tbCpfCnpj.ForeColor = Color.ForestGreen
                Else
                    tbCpfCnpj.ForeColor = Color.Maroon
                End If
            Else
                tbCpfCnpj.ForeColor = Color.Maroon
            End If
        End If
    End Sub

    Private Sub BtnAlteraEnderecoPagto_Click(sender As Object, e As EventArgs) Handles btnAlteraEnderecoPagto.Click

        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um cliente"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else
            Dim frm As fdlgDeliveryEnderecoEntrega = New fdlgDeliveryEnderecoEntrega
            frm.tbStatus.Text = "P"
            frm.ShowDialog()

            tbCodPro.Focus()
        End If
    End Sub

    Private Sub BtnApp_Click(sender As Object, e As EventArgs) Handles btnApp.Click

        frmAppPedidos.ShowDialog()


        strSql = "SELECT IDVendaExterna FROM tblAppVendas WHERE (AppConfirmado=0) and (Excluido=0)"
        If NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon)) <> "" Then
            ExistePedidoApp = True
        Else
            ExistePedidoApp = False
            btnApp.BackColor = Color.White
        End If

    End Sub

    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click

        If NuloInteger(tbIDCliente.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodPro.Focus()
                Exit Sub
            End If
        End If

        frmInicio.WindowState = FormWindowState.Minimized
        frmPrincipal.WindowState = FormWindowState.Minimized
        'Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub

    Private Sub tbBuscaCliente_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaCliente.TextChanged

    End Sub

    Private Sub GridProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridProdutos.CellContentClick

    End Sub
End Class
