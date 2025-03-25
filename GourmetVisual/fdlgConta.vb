Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports System.IO
Imports GourmetVisual.classModelsShipay


Public Class fdlgConta
    Dim Foco As String
    Dim Campo As String
    Dim Entrou As Integer = 0
    Dim alterou As Boolean = False
    Private Sub AchaVenda(Busca As Integer)

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada, tblVendasMovto.ImprimeImpressora "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada, tblVendasMovto.ImprimeImpressora "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.NumMesa=" & Busca & ") And (tblVendas.FlagFechada=0) And (tblVendasMovto.ImprimeImpressora=1) "
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        If ds.Tables("Vendas").Rows.Count > 0 And Busca <> 0 Then
            IDVenda = NuloInteger(ds.Tables("Vendas").Rows(0).Item("IDVenda"))
            tbIDVenda.Text = NuloString(NuloInteger(ds.Tables("Vendas").Rows(0).Item("IDVenda")))
            QtdPessoas = NuloInteger(ds.Tables("Vendas").Rows(0).Item("QtdPessoas"))
            tbQtdePessoas.Text = NuloString(NuloInteger(ds.Tables("Vendas").Rows(0).Item("QtdPessoas")))
            tbPercServico.Text = NuloString(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercServico")))
            tbServico.Text = NuloString(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Servico")))

            strSql = "UPDATE tblVendasMovto SET "
            strSql &= "ImprimeImpressora = 'True' "
            strSql += "WHERE (IDVenda = " & NuloInteger(IDVenda) & ")"
            ExecutaStr(strSql)
        Else
            IDVenda = 0
            tbIDVenda.Text = "0"
            QtdPessoas = 0
            tbMesa.Text = ""
            tbQtdePessoas.Text = ""
            tbPercServico.Text = "0"
            tbServico.Text = "0"
            tbTotalProdutos.Text = "0"

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Mesa inválida ou sem produtos"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If
        AtualizaServico(NuloInteger(IDVenda), "C", NuloDecimal(tbPercServico.Text))



        ' Verifica datas na conta ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Try

            strSql = "Select IDVenda, Excluido, CONVERT(VARCHAR(10), HoraPedido, 101) AS Data "
            strSql += "From tblVendasMovto "
            strSql += "Group By IDVenda, CONVERT(VARCHAR(10), HoraPedido, 101), Excluido "
            strSql += "HAVING(IDVenda = " & IDVenda & ") And (Excluido = 0) "

            Dim dapC = New SqlDataAdapter(strSql, strCon)
            dapC.SelectCommand.CommandType = CommandType.Text
            Dim dsC As New DataSet()
            dapC.Fill(dsC, "cta")

        Catch ex As Exception

        End Try
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        CriaImpressaoConta(IDVenda)

    End Sub
    Private Sub CriaVereficaProdutos(IDvda As Integer)
        If IDVenda = 0 Then Exit Sub

        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim IDMovto As Integer

1:

        strSql = "Select tblVendas.IDVenda, tblVendas.NumMesa, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto As ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaMovto "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
        strSql += "Group By tblVendas.IDVenda, tblVendas.NumMesa, tblVendasMovto.Produto, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaMovto "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaMovto"


        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")


        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))


        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1

            PrintLine(lngFile, Chr(27) + Chr(14) & " MESA  " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")) & Chr(27) + Chr(14))
            PrintLine(lngFile, "Descricao                           Qtde. ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1
                IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))

                texto = Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")))
                If Len(texto) <= 30 Then
                    texto = texto & Space(30 - Len(texto))
                Else
                    texto = Strings.Left(texto, 30)
                End If

                If Int(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))) = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) Then
                    texto &= Space(10 - Len(NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde"))))) & NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde")))
                Else
                    texto &= " " & NuloString(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                End If
                PrintLine(lngFile, texto)


                If NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" Then
                    texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                    PrintLine(lngFile, texto)
                    i += 1
                    If i <= ds.Tables("Vendas").Rows.Count - 1 Then

                        Do While NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" And IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                            texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                            PrintLine(lngFile, texto)
                            i += 1
                            If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                        Loop

                    End If
                Else
                    i += 1
                End If
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
        Next
        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()

        'verifica se o nome do arquivo foi informado
        Dim caminho As String = Application.StartupPath & "\Impressao\conta.txt"

        'verifica se o arquivo existe
        If File.Exists(caminho) Then
            Using tr As TextReader = New StreamReader(caminho)
                tbConta.Text = tr.ReadToEnd()
            End Using
        Else
            MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Public Sub CriaImpressaoContaDetalhada(IDvda As Integer)
        If IDVenda = 0 Then Exit Sub

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim VlrDia As Decimal = 0
        Dim VlrDiaTxt As String
        Dim VlrProTxt As String
        Dim VlrSerTxt As String
        Dim VlrDescTxt As String
        Dim SerTxt As String
        Dim DiaVenda As String
        Dim NomeCli As String
        Dim Perma As String
        Dim HoraIni As DateTime
        Dim Hora As Integer
        Dim Minuto As Integer
        Dim IDvdaCombo As Integer
        con.ConnectionString = strCon
1:

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        If NaoMostraProdutosZeroConta = True Then
            strSql += "And (tblVendasMovto.Venda <> 0) "
        End If
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"


        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, CONVERT(VARCHAR(10), tblVendasMovto.HoraPedido, 101) AS DiaPedido, tblVendas.DataVenda, tblVendas.HoraAbertura, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto As ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda AS VendaCombo, tblVendasCombo.VendaServico As VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, CONVERT(VARCHAR(10), tblVendasMovto.HoraPedido, 101), tblVendas.NomeCliente "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda = " & IDvda & ") And (tblVendasMovto.Venda <> 0) "
        strSql += "ORDER BY CONVERT(VARCHAR(10), tblVendasMovto.HoraPedido, 101), tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")


        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))


        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1

            NomeCli = NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente"))

            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, " MESA  " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")))
                If NomeCli <> "" Then
                    PrintLine(lngFile, " " & NomeCli)
                End If
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & " MESA  " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")) & Chr(27) + Chr(14))
                If NomeCli <> "" Then
                    PrintLine(lngFile, Chr(27) + Chr(14) & " " & NomeCli & Chr(27) + Chr(14))
                End If
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, Chr(27) + Chr(14) & NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")) & Chr(27) + Chr(14))
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Endereco"))) & "," & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Numero")))
            PrintLine(lngFile, texto)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("CEP"))) & "  -  " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Telefone")))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "------------------------------------------")

            texto = "Atendente : " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Atendente")))
            PrintLine(lngFile, texto)

            texto = "Periodo   : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("HoraAbertura"), "hh:mm")) & "/" & NuloString(Format(Now, "hh:mm")) & "    " & NuloString(Format(Now, "dd/MM/yyyy"))
            PrintLine(lngFile, texto)

            texto = "Venda     : " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumVenda"))
            PrintLine(lngFile, texto)

            texto = "Controle interno sem valor fiscal"
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, "CONFERENCIA DE CONTA     MESA: " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")))
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & "CONFERENCIA DE CONTA     MESA: " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")) & Chr(27) + Chr(14))
            End If

            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Descricao          Qtde.   Unit.    Total ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1
                DiaVenda = NuloString(ds.Tables("Vendas").Rows(i).Item("DiaPedido"))
                PrintLine(lngFile, DiaVenda)
                'PrintLine(lngFile, "------------------------------------------")
                Do While DiaVenda = NuloString(ds.Tables("Vendas").Rows(i).Item("DiaPedido"))
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
                    VlrDia += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))

                    If NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" Then
                        IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                        texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                        PrintLine(lngFile, texto)
                        i += 1
                        If i <= ds.Tables("Vendas").Rows.Count - 1 Then

                            Do While NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" And IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                                texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                                PrintLine(lngFile, texto)
                                i += 1
                                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                            Loop

                        End If
                    Else
                        i += 1
                    End If

                    If i > ds.Tables("Vendas").Rows.Count - 1 Then
                        PrintLine(lngFile, "------------------------------------------")
                        VlrDiaTxt = Format(NuloDecimal(VlrDia), "#0.00")
                        PrintLine(lngFile, Space(42 - Len(VlrDiaTxt)) & VlrDiaTxt)
                        PrintLine(lngFile, " ")
                        VlrDia = 0
                        Exit Do
                    Else
                        If DiaVenda <> NuloString(ds.Tables("Vendas").Rows(i).Item("DiaPedido")) Then
                            PrintLine(lngFile, "------------------------------------------")
                            VlrDiaTxt = Format(NuloDecimal(VlrDia), "#0.00")
                            PrintLine(lngFile, Space(42 - Len(VlrDiaTxt)) & VlrDiaTxt)
                            PrintLine(lngFile, " ")
                            VlrDia = 0
                        End If
                    End If
                Loop

                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, "==========================================")
            VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")
            tbTotalProdutos.Text = Format(NuloDecimal(VlrPro), "#0.00")
            PrintLine(lngFile, "Sub-total " & Space(32 - Len(VlrProTxt)) & VlrProTxt)

            SerTxt = Format(NuloDecimal(VlrSer) - NuloDecimal(VlrPro), "#0.00")
            If Len(TextoServico) > 25 Then
                texto = TextoServico & Space(5 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            Else
                texto = TextoServico & Space(25 - Len(NuloString(TextoServico))) & Space(17 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            End If

            If NuloDecimal(SerTxt) > 0 Then
                PrintLine(lngFile, texto)
            End If


            tbServico.Text = SerTxt
            tbPercServico.Text = NuloString(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercServico")))

            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercServico")) = 0 Then
                btnServico.Text = "Colocar Serviço F10"
            Else
                btnServico.Text = "Retira Serviço F10"
            End If


            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) > 0 Then
                Dim vlrDesc As Decimal = NuloDecimal(SemArredondar(VlrPro * (NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) / 100), 3))
                VlrDescTxt = Format(NuloDecimal(vlrDesc), "#0.00")

                VlrSer = VlrSer - vlrDesc
                texto = "Desconto  " & Space(32 - Len(VlrDescTxt)) & VlrDescTxt
                PrintLine(lngFile, texto)

                tbDescValor.Text = NuloString(VlrDescTxt)
                tbDescValor.Refresh()
                tbDescPerc.Text = NuloString(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")))
                tbDescPerc.Refresh()
            End If

            PrintLine(lngFile, "                              ------------")
            VlrSerTxt = Format(NuloDecimal(VlrSer), "#0.00")
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, "TOTAL" & Space(37 - Len(VlrSerTxt)) & VlrSerTxt)
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & "TOTAL" & Space(16 - Len(VlrSerTxt)) & VlrSerTxt & Chr(27) + Chr(14))
            End If

            lbTotalVenda.Text = NuloString(VlrSer)

            PrintLine(lngFile, "------------------------------------------")

            HoraIni = Convert.ToDateTime(ds.Tables("Vendas").Rows(0).Item("HoraAbertura"))

            Hora = NuloInteger(Int(DateDiff(DateInterval.Minute, HoraIni, Now) / 60))
            Minuto = NuloInteger(((DateDiff(DateInterval.Minute, HoraIni, Now) / 60) - Hora) * 60)
            If Len(Minuto) = 1 Then
                Perma = Hora & ":" & "0" & Minuto
            Else
                Perma = Hora & ":" & Minuto
            End If

            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("QtdPessoas")) > 1 Then
                texto = "Permanencia      : " & Perma
                PrintLine(lngFile, texto)
                texto = "Qtde. pessoas    : " & NuloString(ds.Tables("Vendas").Rows(0).Item("QtdPessoas"))
                PrintLine(lngFile, texto)
                texto = "Valor por pessoa : " & NuloString(Format(NuloDecimal(VlrSer) / NuloDecimal(ds.Tables("Vendas").Rows(0).Item("QtdPessoas")), "#0.00"))
                PrintLine(lngFile, texto)
            Else
                PrintLine(lngFile, "Permanencia : " & Perma)
            End If
            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
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
        Next
        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()



        'verifica se o nome do arquivo foi informado
        Dim caminho As String = Application.StartupPath & "\Impressao\conta.txt"
        'verifica se o arquivo existe
        If File.Exists(caminho) Then
            Using tr As TextReader = New StreamReader(caminho)
                tbConta.Text = tr.ReadToEnd()
            End Using
        Else
            MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub
    Public Sub CriaImpressaoConta(IDvda As Integer)

        If IDVenda = 0 Then Exit Sub

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim VlrProTxt As String
        Dim VlrSerTxt As String
        Dim VlrDescTxt As String
        Dim NomeCli As String
        Dim SerTxt As String
        Dim Perma As String
        Dim HoraIni As DateTime
        Dim Hora As Integer
        Dim Minuto As Integer
        Dim IDvdaCombo As Integer
        con.ConnectionString = strCon
1:

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente, tblVendasMovto.ImprimeImpressora "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente, tblVendasMovto.ImprimeImpressora "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") AND (tblVendasMovto.ImprimeImpressora = 1) "
        If NaoMostraProdutosZeroConta = True Then
            strSql += "And (tblVendasMovto.Venda <> 0) "
        End If
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"


        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")


        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))


        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            NomeCli = NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente"))
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, " MESA  " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")))
                If NomeCli <> "" Then
                    PrintLine(lngFile, " " & NomeCli)
                End If
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & " MESA  " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")) & Chr(27) + Chr(14))
                If NomeCli <> "" Then
                    PrintLine(lngFile, Chr(27) + Chr(14) & " " & NomeCli & Chr(27) + Chr(14))
                End If
            End If

            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, Chr(27) + Chr(14) & NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")) & Chr(27) + Chr(14))
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Endereco"))) & "," & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Numero")))
            PrintLine(lngFile, texto)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("CEP"))) & "  -  " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Telefone")))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "------------------------------------------")

            texto = "Atendente : " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Atendente")))
            PrintLine(lngFile, texto)

            texto = "Periodo   : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("HoraAbertura"), "HH:mm")) & "/" & NuloString(Format(Now, "HH:mm")) & "    " & NuloString(Format(Now, "dd/MM/yyyy"))
            PrintLine(lngFile, texto)

            texto = "Venda     : " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumVenda"))
            PrintLine(lngFile, texto)

            texto = "Controle interno sem valor fiscal"
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, "CONFERENCIA DE CONTA     MESA: " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")))
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & "CONFERENCIA DE CONTA     MESA: " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")) & Chr(27) + Chr(14))
            End If

            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Descricao          Qtde.   Unit.    Total ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1
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
                    texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                    PrintLine(lngFile, texto)
                    i += 1
                    If i <= ds.Tables("Vendas").Rows.Count - 1 Then

                        Do While NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" And IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                            texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                            PrintLine(lngFile, texto)
                            i += 1
                            If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                        Loop

                    End If
                Else
                    i += 1
                End If
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, "==========================================")
            VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")
            tbTotalProdutos.Text = Format(NuloDecimal(VlrPro), "#0.00")
            PrintLine(lngFile, "Sub-total " & Space(32 - Len(VlrProTxt)) & VlrProTxt)

            SerTxt = Format(NuloDecimal(VlrSer) - NuloDecimal(VlrPro), "#0.00")
            If Len(TextoServico) > 25 Then
                texto = TextoServico & Space(5 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            Else
                texto = TextoServico & Space(25 - Len(NuloString(TextoServico))) & Space(17 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            End If

            If NuloDecimal(SerTxt) > 0 Then
                PrintLine(lngFile, texto)
            End If


            tbServico.Text = SerTxt
            tbPercServico.Text = NuloString(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercServico")))

            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercServico")) = 0 Then
                btnServico.Text = "Colocar Serviço F10"
            Else
                btnServico.Text = "Retira Serviço F10"
            End If


            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) > 0 Then
                Dim vlrDesc As Decimal = NuloDecimal(SemArredondar(VlrPro * (NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) / 100), 3))
                VlrDescTxt = Format(NuloDecimal(vlrDesc), "#0.00")

                VlrSer = VlrSer - vlrDesc
                texto = "Desconto  " & Space(32 - Len(VlrDescTxt)) & VlrDescTxt
                PrintLine(lngFile, texto)

                tbDescValor.Text = NuloString(VlrDescTxt)
                tbDescValor.Refresh()
                tbDescPerc.Text = NuloString(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")))
                tbDescPerc.Refresh()
            End If

            PrintLine(lngFile, "                              ------------")
            VlrSerTxt = Format(NuloDecimal(VlrSer), "#0.00")
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, "TOTAL" & Space(37 - Len(VlrSerTxt)) & VlrSerTxt)
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & "TOTAL" & Space(16 - Len(VlrSerTxt)) & VlrSerTxt & Chr(27) + Chr(14))
            End If

            lbTotalVenda.Text = NuloString(VlrSer)

            PrintLine(lngFile, "------------------------------------------")

            strSql = "Select IDVenda, Descricao, ValorPago "
            strSql += "From tblVendasPagto "
            strSql += "Where (IDVenda=" & IDvda & ") "
            strSql += "Order By Descricao"

            Dim dapP = New SqlDataAdapter(strSql, strCon)
            dapP.SelectCommand.CommandType = CommandType.Text
            Dim dsP As New DataSet()
            dapP.Fill(dsP, "pagto")

            If dsP.Tables("pagto").Rows.Count <> 0 Then
                Dim VlrTotalPagto As Decimal = 0
                PrintLine(lngFile, "PAGAMENTOS EFETUADOS")
                For ii As Integer = 0 To dsP.Tables("pagto").Rows.Count - 1
                    texto = "  - " & Strings.Left(NuloString(dsP.Tables("pagto").Rows(ii).Item("Descricao")), 30) & Space(30 - Len(Strings.Left(NuloString(dsP.Tables("pagto").Rows(ii).Item("Descricao")), 30)))
                    texto += Space(8 - Len(NuloString(Format(NuloDecimal(dsP.Tables("pagto").Rows(ii).Item("ValorPago")), "#0.00")))) & NuloString(Format(NuloDecimal(dsP.Tables("pagto").Rows(ii).Item("ValorPago")), "#0.00"))
                    PrintLine(lngFile, texto)
                    VlrTotalPagto += NuloDecimal(dsP.Tables("pagto").Rows(ii).Item("ValorPago"))
                Next
                PrintLine(lngFile, "                              ------------")
                PrintLine(lngFile, Space(42 - Len(Format(NuloDecimal(VlrTotalPagto), "#0.00"))) & Format(NuloDecimal(VlrTotalPagto), "#0.00"))
                PrintLine(lngFile, " ")
                VlrSer -= VlrTotalPagto
                PrintLine(lngFile, ">>> SALDO" & Space(33 - Len(Format(NuloDecimal(VlrSer), "#0.00"))) & Format(NuloDecimal(VlrSer), "#0.00"))
                PrintLine(lngFile, "------------------------------------------")
            End If


            HoraIni = Convert.ToDateTime(ds.Tables("Vendas").Rows(0).Item("HoraAbertura"))
            Hora = NuloInteger(Int(DateDiff(DateInterval.Minute, HoraIni, Now) / 60))
            Minuto = NuloInteger(((DateDiff(DateInterval.Minute, HoraIni, Now) / 60) - Hora) * 60)
            If Len(Minuto) = 1 Then
                Perma = Hora & ":" & "0" & Minuto
            Else
                Perma = Hora & ":" & Minuto
            End If

            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("QtdPessoas")) > 1 Then
                texto = "Permanencia      : " & Perma
                PrintLine(lngFile, texto)
                texto = "Qtde. pessoas    : " & NuloString(ds.Tables("Vendas").Rows(0).Item("QtdPessoas"))
                PrintLine(lngFile, texto)
                texto = "Valor por pessoa : " & NuloString(Format(NuloDecimal(VlrSer) / NuloDecimal(ds.Tables("Vendas").Rows(0).Item("QtdPessoas")), "#0.00"))
                PrintLine(lngFile, texto)
            Else
                PrintLine(lngFile, "Permanencia : " & Perma)
            End If
            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
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
        Next
        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()



        'verifica se o nome do arquivo foi informado
        Dim caminho As String = Application.StartupPath & "\Impressao\conta.txt"
        'verifica se o arquivo existe
        If File.Exists(caminho) Then
            Using tr As TextReader = New StreamReader(caminho)
                tbConta.Text = tr.ReadToEnd()
            End Using
        Else
            MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




        'Catch ex As Exception
        'If InStr(1, ex.Message, "localizar") > 0 Then
        'Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\pedido.txt")
        'fs.Close()
        'GoTo 1
        'Else
        'MsgBox(ex.Message)
        'End If

        'End Try
    End Sub
    Private Sub AtualizaServico(IDvda As Integer, Tipo As String, PercServ As Decimal)
        Dim VlrServico As Decimal = 0
        Dim VlrProduto As Decimal = 0
        Dim con As New SqlConnection()

        strSql = "Select tblVendas.IDVenda, tblVendas.Servico, tblVendas.PercServico, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasMovto.Qtd As Qtde, tblVendasMovto.Excluido, tblVendasMovto.IDVendaMovto, tblProdutos_Local.ComServico, tblVendasMovto.ComServico AS ComServicoMovto, tblVendasMovto.IDProduto "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
        strSql += "WHERE(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda = " & IDvda & ") "
        strSql += "ORDER BY tblVendasMovto.Produto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")
        Dim vlr As Decimal
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")) <> 0 Then
                VlrProduto += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))
                If Tipo = "R" Then
                    strSql = "UPDATE tblVendasMovto SET "
                    strSql &= "VendaServico=" & Replace(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")), ",", ".") & " "
                    strSql += "WHERE (IDVendaMovto = " & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) & ")"

                    Try
                        ExecutaStr(strSql)
                    Catch ex As Exception

                    End Try

                    VlrServico += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))
                Else
                    vlr = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * ((PercServ / 100) + 1)
                    strSql = "UPDATE tblVendasMovto SET "
                    If NuloString(ds.Tables("Vendas").Rows(i).Item("ComServicoMovto")) = "" Then
                        If NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico")) = True Then
                            strSql &= "VendaServico=" & Replace(NuloString(vlr), ",", ".") & " "
                            VlrServico += NuloDecimal(vlr)
                        Else
                            strSql &= "VendaServico=" & Replace(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")), ",", ".") & " "
                            VlrServico += NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Venda"))
                        End If
                    Else
                        If NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico")) = True And NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServicoMovto")) = True Then
                            strSql &= "VendaServico=" & Replace(NuloString(vlr), ",", ".") & " "
                            VlrServico += NuloDecimal(vlr)
                        Else
                            strSql &= "VendaServico=" & Replace(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")), ",", ".") & " "
                            VlrServico += NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Venda"))
                        End If
                    End If
                    strSql += "WHERE (IDVendaMovto = " & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) & ")"

                    Try
                        ExecutaStr(strSql)
                    Catch ex As Exception

                    End Try

                End If
            Else
                strSql = "DELETE tblVendasMovto WHERE IDVendaMovto=" & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                ExecutaStr(strSql)
            End If
        Next
        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()
        If Tipo = "R" Then
            strSql = "UPDATE tblVendas SET "
            strSql &= "Servico=0, "
            strSql &= "PercServico=0 "
            strSql += "WHERE (IDVenda = " & IDvda & ")"
            ExecutaStr(strSql)
            btnServico.Text = "Colocar Serviço F10"
        Else
            strSql = "UPDATE tblVendas SET "
            strSql &= "Servico=" & Replace(NuloString(VlrServico), ",", ".") & ", "
            strSql &= "PercServico=" & Replace(NuloString(NuloDecimal(PercServ)), ",", ".") & " "
            strSql += "WHERE (IDVenda = " & IDvda & ")"
            ExecutaStr(strSql)
            btnServico.Text = "Retira Serviço F10"
        End If


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CliqueNoBotao("9")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Foco = "Qtd" Then
            tbQtdePessoas.Text = String.Empty
            tbQtdePessoas.Focus()
        End If
        If Foco = "%" Then
            tbDescPerc.Text = String.Empty
            tbDescPerc.Focus()
        End If
        If Foco = "vlr" Then
            tbDescValor.Text = String.Empty
            tbDescValor.Focus()
        End If
        If Foco = "Mesa" Then
            tbMesa.Text = String.Empty
            tbMesa.Focus()
        End If
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If NuloDecimal(tbTotalProdutos.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Venda sem produtos"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If

        If tbQtdePessoas.Text = String.Empty Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Quantidade de pessoas inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbQtdePessoas.Text = NuloString(QtdPessoas)
            tbQtdePessoas.Focus()
            Exit Sub
        End If

        If NuloString(tbMesa.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Mesa inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbMesa.Focus()
            Exit Sub
        End If

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "IMPRESSÃO CONTA", "MESA " & tbMesa.Text)
        End If


        ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\conta.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If

        If btnVerifica.Text = "Verifica Produtos" Then
            If NuloString(tbMesa.Text) <> "" Then
                strSql = "UPDATE tblMesas SET "
                strSql += "Impresso=1 "
                strSql += "WHERE (NumMesa = " & tbMesa.Text & ")"
                ExecutaStr(strSql)

                If TableAtivo = True Then
                    InformaStatusTablet(tbMesa.Text)
                End If
            End If
        End If

        frmSalao.MontaBotoesMesas()
        QtdPessoas = 0
        IDVenda = 0
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub fdlgConta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        frmSalao.Enabled = True
        If Not isDebug Then
            'frmSalao.TopMost = True
        End If

    End Sub

    Private Sub fdlgConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmSalao.TimerTela.Enabled = False
        Me.Text = "Conferencia de " & NuloString(TextoMesaPAR)
        lbTextoMesa.Text = NuloString(TextoMesaPAR)

        If NuloInteger(tbMesa.Text) <> 0 Then
            MesaNova(NuloInteger(tbMesa.Text))
            PreencheDataSet()
            AchaVenda(NuloInteger(tbMesa.Text))
        End If

        If UCase(NuloString(TextoMesaPAR)) = "MESA" Then
            tbQtdePessoas.Focus()
        Else
            tbQtdePessoas.Enabled = False
            tbQtdePessoas.ReadOnly = True
            tbQtdePessoas.TabStop = False
            tbDescPerc.Focus()
        End If

        If AccessKey_Shipay <> "" And SecretKey_Shipay <> "" Then
            strSql = "SELECT Terminal, ClientID, ImpressoraPagtoDigital, Status FROM tblTerminaisPagtoDigital WHERE Terminal = '" & NuloString(NomeTerminal) & "'"
            ClientID_Shipay = NuloString(PegaValorCampo("ClientID", strSql, strCon))
            If ClientID_Shipay <> "" Then
                btnPix.Visible = True
            End If
        End If


        If NuloString(tbMesa.Text) <> "" Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MesaNova(Mesa As Integer)

        strSql = "Select tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendas.FlagFechada, tblVendas.NumMesa, tblVendasMovto.Produto, tblVendasMovto.Excluido, tblVendasMovto.ImprimeImpressora "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
        strSql += "Group By tblVendas.IDVenda, tblVendas.NumMesa, tblVendasMovto.Produto, tblVendasMovto.Excluido, tblVendasMovto.ImprimeImpressora, tblVendasMovto.IDVendaMovto, tblVendas.FlagFechada "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.NumMesa = 1) And (tblVendas.FlagFechada = 0)"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            strSql = "UPDATE tblVendasMovto SET "
            strSql &= "ImprimeImpressora = 'True' "
            strSql += "WHERE (IDVendaMovto = " & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) & ")"
            ExecutaStr(strSql)

            'strSql = "UPDATE tblVendasCombo SET "
            'strSql &= "ImprimeImpressora = 1 "
            'strSql += "WHERE (IDVendaMovto = " & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) & ")"
            'ExecutaStr(strSql)
        Next

    End Sub
    Private Sub PreencheDataSet()

        DataGrid.Rows.Clear()
        If NuloString(tbMesa.Text) = "" Then Exit Sub

        strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasMovto.ImprimeImpressora, tblVendasCombo.ImprimeImpressora As ImprimeImpressoraCombo, tblVendasMovto.Qtd, tblVendasMovto.Produto, tblVendasCombo.Produto AS ProdutoCombo, tblVendas.NumMesa, tblVendas.FlagFechada "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
        strSql += "Group By tblVendasMovto.Qtd, tblVendasMovto.Produto, tblVendasMovto.Excluido, tblVendasMovto.ImprimeImpressora, tblVendasMovto.IDVendaMovto, tblVendas.NumMesa, tblVendas.FlagFechada, tblVendasCombo.Produto, tblVendasCombo.ImprimeImpressora "
        strSql += "HAVING (tblVendasMovto.Excluido = 0) And (tblVendas.NumMesa = " & tbMesa.Text & ") And (tblVendas.FlagFechada = 0)"
        strSql += "Order BY tblVendasMovto.Produto, tblVendasMovto.IDVendaMovto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            DataGrid.Rows.Add(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ImprimeImpressora")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")))

            If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit For
            If NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto")) = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) Then

                Do While i <= ds.Tables("Vendas").Rows.Count - 1
                    DataGrid.Rows.Add(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), True, Nothing, "   - " & NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))

                    If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit For
                    If NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto")) <> NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) Then Exit Do
                    i += 1
                Loop

            End If
        Next

        Dim IDmovto As Integer
        Dim flage As Boolean
        For i = 0 To DataGrid.Rows.Count - 1
            If IDmovto <> NuloInteger(DataGrid.Rows(i).Cells(0).Value) Then
                DataGrid.Rows(i).Cells(1).ReadOnly = False
                flage = NuloBoolean(DataGrid.Rows(i).Cells(1).Value)
                IDmovto = NuloInteger(DataGrid.Rows(i).Cells(0).Value)
            Else
                DataGrid.Rows(i).Cells(1).ReadOnly = True
                DataGrid.Rows(i).Cells(1).Value = flage
            End If
        Next i

        DataGrid.Columns(1).Width = 46
        DataGrid.Columns(2).Width = 50
        DataGrid.Columns(3).Width = 190
        DataGrid.Columns(2).ReadOnly = True
        DataGrid.Columns(3).ReadOnly = True
        DataGrid.ClearSelection()

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CliqueNoBotao(valor As String)

        alterou = True
        If Foco = "Qtd" Then
            tbQtdePessoas.Text &= valor
            tbQtdePessoas.Focus()
        End If
        If Foco = "%" Then
            tbDescPerc.Text &= valor
            tbDescPerc.Focus()
        End If
        If Foco = "vlr" Then
            tbDescValor.Text &= valor
            tbDescValor.Focus()
        End If
        If Foco = "Mesa" Then
            tbMesa.Text &= valor
            tbMesa.Focus()
        End If

        'With tbQtdePessoas
        'If Entrou = 0 Then
        '.Text = valor
        'Entrou = 1
        'Else
        '.Text &= valor
        'End If
        '.Focus()
        'End With
    End Sub

    Private Sub tbQtdePessoas_GotFocus(sender As Object, e As EventArgs) Handles tbQtdePessoas.GotFocus
        If NuloString(tbMesa.Text) = "" Then
            tbMesa.Focus()
            Foco = "Mesa"
        Else
            Foco = "Qtd"
            Campo = tbQtdePessoas.Text
        End If

    End Sub

    Private Sub tbDescPerc_GotFocus(sender As Object, e As EventArgs) Handles tbDescPerc.GotFocus
        Foco = "%"
        Campo = tbDescPerc.Text
    End Sub

    Private Sub tbDescValor_GotFocus(sender As Object, e As EventArgs) Handles tbDescValor.GotFocus
        Foco = "vlr"
        Campo = tbDescValor.Text
    End Sub

    Private Sub tbQtdePessoas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtdePessoas.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If NuloInteger(tbQtdePessoas.Text) = 0 Then tbQtdePessoas.Text = "1"

            If alterou = True Then
                strSql = "UPDATE tblVendas SET "
                strSql &= "QtdPessoas=" & tbQtdePessoas.Text & " "
                strSql += "WHERE (IDVenda = " & tbIDVenda.Text & ")"
                ExecutaStr(strSql)
                CriaImpressaoConta(IDVenda)
                alterou = False
            End If
            tbDescPerc.Focus()
        End If
    End Sub

    Private Sub tbDescValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescValor.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            'If Campo <> tbDescValor.Text Then
            If alterou = True Then
                If tbDescValor.Text <> "" Then

                    If Not IsNumeric(tbDescValor.Text) Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Valor inválido"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbDescValor.Text = ""
                        Exit Sub
                    End If

                    Dim VlrD As Decimal = NuloDecimal((NuloDecimal(tbDescValor.Text) / NuloDecimal(tbTotalProdutos.Text)) * 100)
                    strSql = "UPDATE tblVendas SET "
                    strSql &= "Desconto=" & Replace(tbDescValor.Text, ",", ".") & ", "
                    strSql &= "PercDesconto=" & Replace(NuloString(VlrD), ",", ".") & " "
                    strSql += "WHERE (IDVenda = " & tbIDVenda.Text & ")"

                    tbDescPerc.Text = NuloString(Format(NuloDecimal(VlrD), "#0.000"))
                    ExecutaStr(strSql)
                    CriaImpressaoConta(IDVenda)
                End If
                Campo = tbDescValor.Text
                alterou = False
            End If
            'If e.KeyCode = 13 Then
            Me.InvokeOnClick(btnConfirma, e)
            'End If

            'If UCase(TextoMesaPAR) = "MESA" Then
            'tbQtdePessoas.Focus()
            'Else
            'tbDescPerc.Focus()
            'End If


        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Foco = "Qtd" Then tbQtdePessoas.Focus()
        If Foco = "%" Then tbDescPerc.Focus()
        If Foco = "vlr" Then tbDescValor.Focus()
        If Foco = "Mesa" Then tbMesa.Focus()
        SendKeys.Send("{ENTER}")
    End Sub


    Private Sub tbDescPerc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescPerc.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If alterou = True Then
                If tbDescPerc.Text <> "" Then
                    If Not IsNumeric(tbDescPerc.Text) Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Percentual inválido"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbDescPerc.Text = ""
                        Exit Sub
                    End If

                    Dim VlrD As Decimal = NuloDecimal(tbTotalProdutos.Text) * (NuloDecimal(tbDescPerc.Text) / 100)
                    strSql = "UPDATE tblVendas SET "
                    strSql &= "Desconto=" & Replace(NuloString(VlrD), ",", ".") & ", "
                    strSql &= "PercDesconto=" & Replace(tbDescPerc.Text, ",", ".") & " "
                    strSql += "WHERE (IDVenda = " & tbIDVenda.Text & ")"

                    tbDescValor.Text = NuloString(Format(NuloDecimal(VlrD), "#0.00"))
                    ExecutaStr(strSql)
                    CriaImpressaoConta(IDVenda)
                End If
                Campo = tbDescPerc.Text
                alterou = False
            End If
            tbDescValor.Focus()
        End If
    End Sub

    Private Sub fdlgConta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode

            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.F10
                Me.InvokeOnClick(btnServico, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVoltar, e)

        End Select
    End Sub

    Private Sub btnServico_Click(sender As Object, e As EventArgs) Handles btnServico.Click


        If NivelFuncionario < 3 Then
            IDFuncionarioAutorizado = 0
            FuncionarioAutorizado = ""
            Dim frm1 As fdlgAutorizacao = New fdlgAutorizacao
            frm1.tbTipo.Text = "3"
            frm1.lbTipo.Text = "Autorização para SERVIÇO"
            frm1.ShowDialog()
            If Autorizado = False Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Sem permissão retirar/incluir serviço"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesa.Focus()
                Exit Sub
            End If
        End If



        If btnServico.Text = "Retira Serviço F10" Then
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "RETIROU SERVIÇO", "MESA " & tbMesa.Text)
            End If
            AtualizaServico(NuloInteger(tbIDVenda.Text), "R", 0)
        Else
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "INCLUIU SERVIÇO", "MESA " & tbMesa.Text)
            End If
            AtualizaServico(NuloInteger(tbIDVenda.Text), "C", PercServicoPAR)
        End If
        CriaImpressaoConta(NuloInteger(tbIDVenda.Text))
        tbQtdePessoas.Focus()

    End Sub

    Private Sub fdlgConta_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub tbDescPerc_TextChanged(sender As Object, e As EventArgs) Handles tbDescPerc.TextChanged
        alterou = True
    End Sub

    Private Sub tbDescValor_TextChanged(sender As Object, e As EventArgs) Handles tbDescValor.TextChanged
        alterou = True
    End Sub

    Private Sub tbQtdePessoas_TextChanged(sender As Object, e As EventArgs) Handles tbQtdePessoas.TextChanged
        alterou = True
    End Sub

    Private Sub TbMesa_TextChanged(sender As Object, e As EventArgs) Handles tbMesa.TextChanged
        alterou = True
    End Sub

    Private Sub tbMesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMesa.KeyPress

        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            MesaNova(NuloInteger(tbMesa.Text))
            PreencheDataSet()
            AchaVenda(NuloInteger(tbMesa.Text))
            tbQtdePessoas.Focus()
        End If

    End Sub


    Private Sub tbMesa_GotFocus(sender As Object, e As EventArgs) Handles tbMesa.GotFocus
        Foco = "Mesa"
    End Sub

    Private Sub BtnVerifica_Click(sender As Object, e As EventArgs) Handles btnVerifica.Click

        If NuloInteger(IDVenda) = 0 Then
            tbMesa.Focus()
            Exit Sub
        End If
        If btnVerifica.Text = "Verifica Produtos" Then
            btnVerifica.Text = "Conferencia da mesa"
            CriaVereficaProdutos(IDVenda)
        Else
            btnVerifica.Text = "Verifica Produtos"
            CriaImpressaoConta(IDVenda)
        End If



    End Sub

    Private Sub BtnPix_Click(sender As Object, e As EventArgs) Handles btnPix.Click

        If NuloInteger(tbIDVenda.Text) = 0 Then Exit Sub

        ' MUDAR PARA PIX //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim txtPIX As String = "pix"
        ' MUDAR PARA PIX //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Dim Total As Decimal
        Dim IDpagtoDIgital As Integer
        strSql = "SELECT IDFormaPagto, Descricao FROM tblFormaPagtos_Local WHERE Descricao='PAGAMENTO DIGITAL'"
        IDpagtoDIgital = NuloInteger(PegaValorCampo("IDFormaPagto", strSql, strCon))

        Dim IDvdaPagto As Integer
        strSql = "Select IDVendaPagto, IDVenda, IDFormaPagto, IDPagtoDigital, StatusDigital, Terminal, QRcode "
        strSql += "From tblVendasPagto "
        strSql += "Where (IDFormaPagto = " & IDpagtoDIgital & ") And (StatusDigital <> 'approved') And (IDVenda=" & tbIDVenda.Text & ")"
        IDvdaPagto = NuloInteger(PegaValorCampo("IDVendaPagto", strSql, strCon))
        If IDvdaPagto = 0 Then
            strSql = "INSERT tblVendasPagto "
            strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom,IDCliente,IDPendencia) VALUES ("
            strSql += to_sql(tbIDVenda.Text) & ","
            strSql += to_sql(IDpagtoDIgital) & ","
            strSql += to_sql("PAGAMENTO DIGITAL") & ","
            strSql += to_sql(Replace(lbTotalVenda.Text, ",", ".")) & ","
            strSql += "0,"
            strSql += "0,"
            strSql += "'R', "
            strSql += "0,"
            strSql += "0,"
            strSql += "0)"
            ExecutaStr(strSql)
            IDvdaPagto = NuloInteger(PegaID("IDVendaPagto", "tblVendasPagto", "L"))

            If access_token_Shipay = "" Then
                Dim api As New classShipay()
                api.getToken()
            End If

            Dim order As New ShipayOrderRequest()
            order.Items = New List(Of classModelsShipay.Item)

            Dim buyer As New Buyer
            buyer.Cpf = ""
            buyer.Email = ""
            buyer.FirstName = ""
            buyer.LastName = ""
            buyer.Phone = ""
            order.Buyer = buyer

            strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada "
            strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
            strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada "
            strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & tbIDVenda.Text & ") And (tblVendas.FlagFechada=0) "
            strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"

            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Vendas")
            Total = 0

            For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
                Dim item As New Item
                item.ItemTitle = NuloString(ds.Tables("Vendas").Rows(i).Item("Produto"))
                item.Quantity = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                item.UnitPrice = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                Total += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                order.Items.Add(item)
            Next

            order.OrderRef = tbIDVenda.Text
            order.Total = NuloDecimal(Total)
            order.Wallet = txtPIX

            Dim c As New classShipay()
            Dim ret = c.postOrder(order)
            Dim a = ret.json

            strSql = "UPDATE tblVendasPagto SET "
            strSql += "Descricao = 'PIX', "
            strSql += "IDPagtoDigital = '" & ret.orderResponse.OrderId & "', "
            strSql += "Terminal = '" & NomeTerminal & "', "
            strSql += "QRcode = '" & NuloString(ret.orderResponse.QrCodeText) & "', "
            strSql += "StatusDigital = '" & ret.orderResponse.Status & "', "
            strSql += "ValorPago = " & Replace(NuloString(Total), ",", ".") & " "
            strSql += "WHERE IDVendaPagto=" & IDvdaPagto
            ExecutaStr(strSql)
        Else
            Dim c As New classShipay()
            Dim ret = c.deleteOrder(NuloString(PegaValorCampo("IDPagtoDigital", strSql, strCon)))

            If access_token_Shipay = "" Then
                Dim api As New classShipay()
                api.getToken()
            End If

            Dim order As New ShipayOrderRequest()
            order.Items = New List(Of Item)

            Dim buyer As New Buyer
            buyer.Cpf = ""
            buyer.Email = ""
            buyer.FirstName = ""
            buyer.LastName = ""
            buyer.Phone = ""
            order.Buyer = buyer

            strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada "
            strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
            strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada "
            strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & tbIDVenda.Text & ") And (tblVendas.FlagFechada=0) "
            strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"

            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Vendas")
            Total = 0

            For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
                Dim item As New Item
                item.ItemTitle = NuloString(ds.Tables("Vendas").Rows(i).Item("Produto"))
                item.Quantity = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                item.UnitPrice = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                Total += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                order.Items.Add(item)
            Next

            order.OrderRef = tbIDVenda.Text
            order.Total = NuloDecimal(Total)
            order.Wallet = txtPIX

            Dim cc As New classShipay()
            Dim retC = cc.postOrder(order)
            Dim a = ret.json

            strSql = "UPDATE tblVendasPagto SET "
            strSql += "Descricao = 'PIX', "
            strSql += "IDPagtoDigital = '" & retC.orderResponse.OrderId & "', "
            strSql += "Terminal = '" & NomeTerminal & "', "
            strSql += "QRcode = '" & NuloString(retC.orderResponse.QrCodeText) & "', "
            strSql += "StatusDigital = '" & retC.orderResponse.Status & "', "
            strSql += "ValorPago = " & Replace(NuloString(Total), ",", ".") & " "
            strSql += "WHERE IDVendaPagto=" & IDvdaPagto
            ExecutaStr(strSql)
        End If
        ImprimeQRcode(IDvdaPagto)

    End Sub

    Private Sub RbDetalhado_CheckedChanged(sender As Object, e As EventArgs)
        CriaImpressaoContaDetalhada(IDVenda)
    End Sub

    Private Sub RbConsolidado_CheckedChanged(sender As Object, e As EventArgs)
        CriaImpressaoConta(IDVenda)
    End Sub

    Private Sub btnConsumo_Click(sender As Object, e As EventArgs) Handles btnConsumo.Click

        If NuloInteger(IDVenda) = 0 Then
            tbMesa.Focus()
            Exit Sub
        End If
        If NuloInteger(tbMesa.Text) = 0 Then
            tbMesa.Focus()
            Exit Sub
        End If
        ImpressaoConsumo(IDVenda)
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub DataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid.CellClick

        btnConfirmaImpressao.Visible = True

    End Sub
    Private Sub btnConfirmaImpressao_Click(sender As Object, e As EventArgs) Handles btnConfirmaImpressao.Click
        Dim Imprime As Boolean = True
        Dim IDmovto As Integer

        For i = 0 To DataGrid.Rows.Count - 1
            If IDmovto <> NuloInteger(DataGrid.Rows(i).Cells(0).Value) Then
                strSql = "UPDATE tblVendasMovto SET "
                If NuloBoolean(DataGrid.Rows(i).Cells("ImprimeImpressora").Value) = True Then
                    strSql += "ImprimeImpressora = 1 "
                Else
                    strSql += "ImprimeImpressora = 0 "
                End If
                strSql += "WHERE (IDVendaMovto = " & NuloInteger(DataGrid.Rows(i).Cells(0).Value) & ")"
                ExecutaStr(strSql)

                IDmovto = NuloInteger(DataGrid.Rows(i).Cells(0).Value)
            Else
                strSql = "UPDATE tblVendasCombo SET "
                If NuloBoolean(DataGrid.Rows(i).Cells("ImprimeImpressora").Value) = True Then
                    strSql += "ImprimeImpressora = 1 "
                Else
                    strSql += "ImprimeImpressora = 0 "
                End If
                strSql += "WHERE (IDVendaMovto = " & NuloInteger(DataGrid.Rows(i).Cells(0).Value) & ")"
                ExecutaStr(strSql)
            End If


        Next i
        PreencheDataSet()
        CriaImpressaoConta(IDVenda)
        btnConfirmaImpressao.Visible = False
    End Sub
End Class