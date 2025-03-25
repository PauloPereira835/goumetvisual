Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail

Public Class frmCaixa
    Public Foco As String
    Public TextoEmail As String
    Public DeliveryRelatorio As Boolean
    Dim IDVdaRet As Integer
    Dim IDfecRet As Integer
    Function ClientesNovos(IDfec As Integer) As Integer

        strSql = "Select tblClientes.DataCadastro, tblRetVendas.IDfechamento "
        strSql += "From tblClientes INNER Join tblRetVendas On tblClientes.IDCliente = tblRetVendas.IDCliente "
        strSql += "Where (tblRetVendas.IDfechamento = " & IDfec & ")"
        Dim DiaMovto As String
        Dim QtdeCli As Integer = 0
        Dim conP As New SqlConnection()
        Dim drP As SqlDataReader
        Dim cmdP As SqlCommand = conP.CreateCommand
        conP.ConnectionString = strConServer
        cmdP.CommandText = strSql
        conP.Open()
        drP = cmdP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drP.HasRows Then
            strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
            strSql += "From tblFechamentos "
            strSql += "Where (IDFechamento = " & IDfec & ")"
            DiaMovto = CType(PegaValorCampo("DiaMovimento", strSql, strConServer), Date).ToString("dd/MM/yyyy")

            Do While drP.Read()
                If CType(drP.Item("DataCadastro"), Date).ToString("dd/MM/yyyy") = DiaMovto Then
                    QtdeCli += 1
                End If
            Loop
        End If
        cmdP.Dispose()
        drP.Close()
        conP.Dispose()
        conP.Close()

        Return QtdeCli

    End Function
    Private Sub ZeraContadorImpressao()
        strSql = "Select * From tblCategorias_Local"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                strSql = "UPDATE tblCategorias_Local SET Pedidos=0 WHERE IDCategoria=" & dr.Item("IDCategoria")
                ExecutaStr(strSql)
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub CriaRelatReciboDespesas()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\financeiro.txt", OpenMode.Output)

        texto = ""
        PrintLine(lngFile, "              R E C I B O")
        PrintLine(lngFile, "Movimentacao no Caixa")
        PrintLine(lngFile, "========================================")
        PrintLine(lngFile, "Movimento   : " & NuloString(tbDiaMovto.Text))
        PrintLine(lngFile, "Responsavel : " & NuloString(Operador))
        PrintLine(lngFile, " ")
        PrintLine(lngFile, "Descricao                         Valor ")
        PrintLine(lngFile, "----------------------------------------")
        PrintLine(lngFile, " ")
        Dim Conta As String = NuloString(Trim(Strings.Left(cbPlano3.Text, 50)))
        PrintLine(lngFile, Conta)
        texto = UCase(tbDescricaPlano.Text)
        If Len(texto) < 30 Then
            texto += Space(30 - Len(texto))
        Else
            texto = Trim(Strings.Left(texto, 30))
        End If
        texto += Space(10 - Len(NuloDecimal(tbVlrPlano.Text).ToString("#0.00"))) & NuloDecimal(tbVlrPlano.Text).ToString("#0.00")
        PrintLine(lngFile, texto)
        PrintLine(lngFile, " ")
        PrintLine(lngFile, "========================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")

        FileClose(lngFile)


    End Sub
    Private Sub PreenchePlano1()
        strSql = "Select IDPlanoConta, PlanoConta, Tipo "
        strSql += "From tblPlanoContas "
        strSql += "Order By PlanoConta"

        Try

            Dim con As New SqlConnection(strConServer)
            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            cbPlano1.Items.Clear()

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                cbPlano1.Items.Add("")
                While (dr.Read)
                    cbPlano1.Items.Add(dr.Item("PlanoConta") & Space(100) & dr.Item("IDPlanoConta"))
                End While
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

        Catch ex As Exception
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "ATENÇÃO: Erro ao conectar com IRIS Gestão, não será possivel encerrar o caixa"
            frm1.lbMensagem.ForeColor = Color.Blue
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End Try

        tbIDPlano1.Text = ""
        tbIDPlano2.Text = ""
        tbIDPlano3.Text = ""

        'cbPlano1.Items.Clear()
        cbPlano2.Items.Clear()
        cbPlano3.Items.Clear()

    End Sub
    Private Sub PreenchePlano2()

        strSql = "Select IDSubConta, IDPlanoConta, SubConta "
        strSql += "From tblPlanoContas_SubConta "
        strSql += "Where (IDPlanoConta = " & NuloInteger(tbIDPlano1.Text) & ") "
        strSql += "Order By SubConta"


        Dim con As New SqlConnection(strConServer)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbPlano2.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbPlano2.Items.Add("")
            While (dr.Read)
                cbPlano2.Items.Add(dr.Item("SubConta") & Space(100) & dr.Item("IDSubConta"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        tbIDPlano2.Text = ""
        tbIDPlano3.Text = ""
        'cbPlano2.Items.Clear()
        cbPlano3.Items.Clear()

    End Sub
    Private Sub PreenchePlano3()

        strSql = "Select IDConta, IDSubConta, Conta "
        strSql += "From tblPlanoContas_Conta "
        strSql += "Where (IDSubConta = " & NuloInteger(tbIDPlano2.Text) & ") "
        strSql += "Order By Conta"

        Dim con As New SqlConnection(strConServer)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbPlano3.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbPlano3.Items.Add("")
            While (dr.Read)
                cbPlano3.Items.Add(dr.Item("Conta") & Space(100) & dr.Item("IDConta"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        tbIDPlano3.Text = ""
        'cbPlano3.Items.Clear()
    End Sub
    Public Sub EnviaEmail()

        Dim Origem As String
        Dim Senha As String
        Dim Porta As String
        Dim Smtp As String
        Dim Assunto As String
        Dim nome_ini As String = Application.StartupPath & "\EnvioEmail.ini"

        If Not File.Exists(nome_arquivo_ini) Then
            MsgBox("Falta arquivo INI (EnvioEmail.ini)", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim Num As Integer = 0
        Dim EmailDestino(10) As String

        Origem = "gourmet@iristecnologia.com.br"
        Senha = "x79jr&"
        Porta = "587"
        Smtp = "smtp.iristecnologia.com.br"
        Assunto = "Movto vendas loja " & NomeLoja

        EmailDestino(0) = LeArquivoINI(nome_ini, "Geral", "EmailDestino", "")
        EmailDestino(1) = LeArquivoINI(nome_ini, "Geral", "EmailDestino2", "")
        EmailDestino(2) = LeArquivoINI(nome_ini, "Geral", "EmailDestino3", "")
        EmailDestino(3) = LeArquivoINI(nome_ini, "Geral", "EmailDestino4", "")
        EmailDestino(4) = LeArquivoINI(nome_ini, "Geral", "EmailDestino5", "")
        EmailDestino(5) = LeArquivoINI(nome_ini, "Geral", "EmailDestino6", "")
        EmailDestino(6) = LeArquivoINI(nome_ini, "Geral", "EmailDestino7", "")
        EmailDestino(7) = LeArquivoINI(nome_ini, "Geral", "EmailDestino8", "")
        EmailDestino(8) = LeArquivoINI(nome_ini, "Geral", "EmailDestino9", "")
        EmailDestino(9) = LeArquivoINI(nome_ini, "Geral", "EmailDestino10", "")

        Try

            Dim Smtp_Server As SmtpClient
            Dim e_mail As New MailMessage()

            Smtp_Server = New SmtpClient
            Smtp_Server.UseDefaultCredentials = False

            Smtp_Server.Credentials = New Net.NetworkCredential(NuloString(Origem), NuloString(Senha))
            Smtp_Server.Port = NuloString(Porta)
            Smtp_Server.EnableSsl = False
            Smtp_Server.Host = NuloString(Smtp)

            Do While Num <= 10
                If EmailDestino(Num) <> "" Then
                    e_mail = New MailMessage()
                    e_mail.From = New MailAddress(NuloString(Origem))
                    e_mail.To.Add(EmailDestino(NuloString(Num)))
                    e_mail.Subject = NuloString(Assunto)
                    e_mail.IsBodyHtml = False
                    e_mail.Body = NuloString(TextoEmail)
                    e_mail.Attachments.Add(New Attachment(Application.StartupPath & "/impressao/Financeiro.txt"))
                    e_mail.Attachments.Add(New Attachment(Application.StartupPath & "/impressao/Produtos.txt"))
                    e_mail.Attachments.Add(New Attachment(Application.StartupPath & "/impressao/Servico.txt"))
                    e_mail.Attachments.Add(New Attachment(Application.StartupPath & "/impressao/Estorno.txt"))
                    If DeliveryRelatorio = True Then
                        e_mail.Attachments.Add(New Attachment(Application.StartupPath & "/impressao/delivery.txt"))
                    End If
                    Smtp_Server.Send(e_mail)
                    System.Threading.Thread.Sleep(1000)
                End If
                Num += 1
            Loop

        Catch ex As Exception
            MsgBox("ERRO (ENvido de email): " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Envio Email")
        End Try

    End Sub
    Private Sub LerArquivo(NomeArq As String)
        Dim fluxoTexto As IO.StreamReader
        Dim linhaTexto As String
        TextoEmail = ""
        If IO.File.Exists(Application.StartupPath & "/impressao/" & NomeArq & ".txt") Then
            fluxoTexto = New IO.StreamReader(Application.StartupPath & "/impressao/" & NomeArq & ".txt")
            linhaTexto = fluxoTexto.ReadLine

            While linhaTexto <> Nothing
                TextoEmail &= linhaTexto & vbCrLf
                linhaTexto = fluxoTexto.ReadLine
            End While
            fluxoTexto.Close()
        Else
            MessageBox.Show("Arquivo " & NomeArq & ".txt não existe")
        End If
    End Sub

    Private Sub IncluiVendasDescricaoFechamento(IDFecGou_ As Integer, IDFecRet_ As Integer)

        Dim conP As New SqlConnection(strCon)
        'conP.ConnectionString = strCon
        Dim cmdP As SqlCommand = conP.CreateCommand
        cmdP.CommandText = "SELECT * FROM tblFechamentosDescricao_Local WHERE (IDFechamento=" & IDFecGou_ & ")"

        conP.Open()
        Dim drP As SqlDataReader
        drP = cmdP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        While drP.Read
            strSql = "INSERT tblFechamentosDescricao (IDFechamento, IDFormaPagto, IDContaCorrente, IDConta, IDConta_Taxa, IDConta_ContraPartida, DataTransferencia, DataContaReceber, Tipo, Descricao, DescricaoContraPartida, ValorBruto, ValorLiquido, Diferenca) VALUES ("
            strSql += to_sql(IDFecRet_) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDFormaPagto"))) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDContaCorrente"))) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDConta"))) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDConta_Taxa"))) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDConta_ContraPartida"))) & ", "
            'strSql += to_sql(NuloString(drP.Item("DataTransferencia"))) & ", "
            strSql += to_sqlDATA(drP.Item("DataTransferencia"), "datahora", "R") & ", "

            'strSql += to_sql(NuloString(drP.Item("DataContaReceber"))) & ", "
            strSql += to_sqlDATA(drP.Item("DataContaReceber"), "datahora", "R") & ", "

            strSql += to_sql(NuloString(drP.Item("Tipo"))) & ", "
            strSql += to_sql(NuloString(drP.Item("Descricao"))) & ", "
            strSql += to_sql(NuloString(drP.Item("DescricaoContraPartida"))) & ", "
            strSql += to_sql(Replace(NuloDecimal(drP.Item("ValorBruto")), ",", ".")) & ", "
            strSql += to_sql(Replace(NuloDecimal(drP.Item("ValorLiquido")), ",", ".")) & ", "
            strSql += to_sql(Replace(NuloDecimal(drP.Item("Diferenca")), ",", ".")) & ")"
            ExecutaStrServidor(strSql)
        End While
        cmdP.Dispose()
        drP.Close()
        conP.Dispose()
        conP.Close()


    End Sub
    Private Sub CriaRelatEstornosTransferencias(IDfec As Integer)
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim conexao As String = strConServer

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\estorno.txt", OpenMode.Output)

        strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
        strSql += "From tblFechamentos "
        strSql += "Where (IDFechamento = " & IDfec & ")"

        texto = ""
        PrintLine(lngFile, "FECHAMENTO CAIXA")
        PrintLine(lngFile, "(Estornos / Transferencias)")
        PrintLine(lngFile, "----------------------------------------")
        PrintLine(lngFile, "Periodo    : " & NuloString(PegaValorCampo("Turno", strSql, conexao)))
        PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataAbertura", strSql, conexao)))
        If ckbMovtoAnterior.Checked = True Then
            PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataFechamento", strSql, conexao)))
        End If
        PrintLine(lngFile, "Responsavel: " & NuloString(PegaValorCampo("Caixa", strSql, conexao)))
        PrintLine(lngFile, "---------------------------->> " & IDfec)
        PrintLine(lngFile, " ")


        Dim TipoVenda As String
        Dim NumVenda As Integer
        Dim Qtde As String

        ' Vendas estornadas ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.NumVenda, tblRetVendas.NumMesa, tblRetVendasMovto.IDProduto, tblRetVendas.Excluido, tblRetVendasMovto.MotivoEstorno, tblRetVendasMovto.Qtd, tblProdutos.Produto, tblRetVendasMovto.Atendente, tblRetVendas.StatusVenda, tblRetVendas.Status "
        strSql += "From tblRetVendasMovto INNER Join tblProdutos On tblRetVendasMovto.IDProduto = tblProdutos.IDProduto INNER Join tblRetVendas On tblRetVendasMovto.IDVendaRet = tblRetVendas.IDVendaRet "
        strSql += "Where (tblRetVendas.IDfechamento = " & IDfec & ") And (tblRetVendas.Excluido = 1) And (tblRetVendas.Status = '' OR tblRetVendas.Status Is NULL) "
        strSql += "Order By tblRetVendas.NumVenda"

        Dim dapV = New SqlDataAdapter(strSql, conexao)
        dapV.SelectCommand.CommandType = CommandType.Text
        Dim dsV As New DataSet()
        dapV.Fill(dsV, "Vendas")

        PrintLine(lngFile, "Vendas estornadas")
        PrintLine(lngFile, "========================================")

        For i As Integer = 0 To dsV.Tables("Vendas").Rows.Count - 1
            NumVenda = NuloInteger(dsV.Tables("Vendas").Rows(i).Item("NumVenda"))

            texto = NuloInteger(dsV.Tables("Vendas").Rows(i).Item("NumVenda"))
            PrintLine(lngFile, "Venda       " & texto)
            If NuloString(dsV.Tables("Vendas").Rows(i).Item("StatusVenda")) = "S" Then
                TipoVenda = "Salao"
            Else
                If NuloString(dsV.Tables("Vendas").Rows(i).Item("StatusVenda")) = "B" Then
                    TipoVenda = "Balcao"
                Else
                    TipoVenda = "Delivery"
                End If
            End If
            PrintLine(lngFile, "Modulo      " & TipoVenda)
            If TipoVenda = "Salao" Then
                texto = dsV.Tables("Vendas").Rows(i).Item("NumMesa")
                PrintLine(lngFile, "Mesa/Cartao " & texto)
            End If
            PrintLine(lngFile, "----------------------------------------")
            Do While NumVenda = NuloInteger(dsV.Tables("Vendas").Rows(i).Item("NumVenda"))
                texto = Strings.Left(NuloString(dsV.Tables("Vendas").Rows(i).Item("Produto")), 25)
                If Len(texto) < 25 Then
                    texto += Space(25 - Len(texto))
                End If
                Qtde = dsV.Tables("Vendas").Rows(i).Item("Qtd").ToString
                texto += Space(15 - Len(Qtde)) & Qtde
                PrintLine(lngFile, texto)

                texto = NuloString(dsV.Tables("Vendas").Rows(i).Item("Atendente"))
                PrintLine(lngFile, "Atendente: " & texto)

                texto = NuloString(dsV.Tables("Vendas").Rows(i).Item("MotivoEstorno"))
                PrintLine(lngFile, texto)

                PrintLine(lngFile, " ")
                i += 1
                If i > dsV.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
        Next
        PrintLine(lngFile, "========================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        dapV.Dispose()
        dsV.Dispose()


        ' Estorno de produtos ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.NumVenda, tblRetVendas.NumMesa, tblRetVendasMovto.IDProduto, tblRetVendasMovto.Excluido, tblRetVendas.Excluido As ExcluidoVenda, tblRetVendasMovto.MotivoEstorno, tblRetVendasMovto.Qtd, tblProdutos.Produto, tblRetVendasMovto.Atendente, tblRetVendas.StatusVenda, tblRetVendas.Status, tblRetVendasMovto.HoraPedido "
        strSql += "From tblRetVendasMovto INNER Join tblProdutos On tblRetVendasMovto.IDProduto = tblProdutos.IDProduto INNER Join tblRetVendas On tblRetVendasMovto.IDVendaRet = tblRetVendas.IDVendaRet "
        strSql += "Where (tblRetVendas.IDfechamento = " & IDfec & ") And (tblRetVendasMovto.Excluido = 1) And (tblRetVendas.Excluido = 0) And (tblRetVendas.Status = '' OR tblRetVendas.Status Is NULL) "
        strSql += "Order By tblRetVendas.NumVenda"

        Dim dap = New SqlDataAdapter(strSql, conexao)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        PrintLine(lngFile, "Produtos estornados")
        PrintLine(lngFile, "========================================")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            NumVenda = NuloInteger(ds.Tables("Vendas").Rows(i).Item("NumVenda"))

            texto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("NumVenda"))
            PrintLine(lngFile, "Venda       " & texto)
            If NuloString(ds.Tables("Vendas").Rows(i).Item("StatusVenda")) = "S" Then
                TipoVenda = "Salao"
            Else
                If NuloString(ds.Tables("Vendas").Rows(i).Item("StatusVenda")) = "B" Then
                    TipoVenda = "Balcao"
                Else
                    TipoVenda = "Delivery"
                End If
            End If
            PrintLine(lngFile, "Modulo      " & TipoVenda)
            If TipoVenda = "Salao" Then
                texto = ds.Tables("Vendas").Rows(i).Item("NumMesa")
                PrintLine(lngFile, "Mesa/Cartao " & texto)
            End If
            PrintLine(lngFile, "----------------------------------------")
            Do While NumVenda = NuloInteger(ds.Tables("Vendas").Rows(i).Item("NumVenda"))
                texto = Strings.Left(NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), 25)
                If Len(texto) < 25 Then
                    texto += Space(25 - Len(texto))
                End If
                Qtde = ds.Tables("Vendas").Rows(i).Item("Qtd").ToString
                texto += Space(15 - Len(Qtde)) & Qtde
                PrintLine(lngFile, texto)

                texto = NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente"))
                PrintLine(lngFile, "Atendente: " & texto)

                texto = NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido"))
                PrintLine(lngFile, "Hora     : " & texto)

                texto = NuloString(ds.Tables("Vendas").Rows(i).Item("MotivoEstorno"))
                PrintLine(lngFile, "Motivo   : " & texto)

                PrintLine(lngFile, " ")

                i += 1
                If i > ds.Tables("Vendas").Rows.Count - 1 Then
                    Exit Do
                Else
                    If NumVenda <> NuloInteger(ds.Tables("Vendas").Rows(i).Item("NumVenda")) Then
                        PrintLine(lngFile, "========================================")
                    End If
                End If
            Loop
            PrintLine(lngFile, " ")
        Next
        PrintLine(lngFile, "========================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        dap.Dispose()
        ds.Dispose()


        ' Vendas transferidas ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'If ckbMovtoAnterior.Checked = False Then
        'strSql = "Select tblVendas.IDfechamento, tblVendas.NumVenda, tblVendas.NumMesa, tblVendasMovto.IDProduto, tblVendas.Excluido, tblVendasMovto.MotivoEstorno, tblVendasMovto.Qtd, tblProdutos_Local.Produto, tblVendasMovto.Atendente, tblVendas.StatusVenda, tblVendas.Status "
        'strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto RIGHT OUTER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        'strSql += "Where (tblVendas.IDfechamento = " & IDfec & ") And (tblVendas.Status <> '') AND (tblVendas.Excluido = 1) "
        'strSql += "ORDER BY tblVendas.NumVenda"
        'Else
        strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.NumVenda, tblRetVendas.NumMesa, tblRetVendasMovto.IDProduto, tblRetVendas.Excluido, tblRetVendasMovto.MotivoEstorno, tblRetVendasMovto.Qtd, tblProdutos.Produto, tblRetVendasMovto.Atendente, tblRetVendas.StatusVenda, tblRetVendas.Status "
        strSql += "From tblRetVendasMovto INNER Join tblProdutos On tblRetVendasMovto.IDProduto = tblProdutos.IDProduto RIGHT OUTER Join tblRetVendas On tblRetVendasMovto.IDVendaRet = tblRetVendas.IDVendaRet "
        strSql += "Where (tblRetVendas.IDfechamento = " & IDfec & ") And (tblRetVendas.Status <> '') AND (tblRetVendas.Excluido = 1) "
        strSql += "ORDER BY tblRetVendas.NumVenda"
        'End If
        Dim dapTV = New SqlDataAdapter(strSql, conexao)
        dapTV.SelectCommand.CommandType = CommandType.Text
        Dim dsTV As New DataSet()
        dapTV.Fill(dsTV, "Vendas")

        PrintLine(lngFile, "Vendas transferidas")
        PrintLine(lngFile, "========================================")
        For i As Integer = 0 To dsTV.Tables("Vendas").Rows.Count - 1
            NumVenda = NuloInteger(dsTV.Tables("Vendas").Rows(i).Item("NumVenda"))

            texto = NuloInteger(dsTV.Tables("Vendas").Rows(i).Item("NumVenda"))
            PrintLine(lngFile, "Venda       " & texto)
            If NuloString(dsTV.Tables("Vendas").Rows(i).Item("StatusVenda")) = "S" Then
                TipoVenda = "Salao"
            Else
                If NuloString(dsTV.Tables("Vendas").Rows(i).Item("StatusVenda")) = "B" Then
                    TipoVenda = "Balcao"
                Else
                    TipoVenda = "Delivery"
                End If
            End If
            PrintLine(lngFile, "Modulo      " & TipoVenda & "  /  " & dsTV.Tables("Vendas").Rows(i).Item("Status"))
            'If TipoVenda = "Salao" Then
            '    PrintLine(lngFile, "            " & dsTV.Tables("Vendas").Rows(i).Item("Status"))
            'End If
            'PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, " ")
        Next
        PrintLine(lngFile, "========================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        dapTV.Dispose()
        dsTV.Dispose()



        ' Produtos transferidos ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'If ckbMovtoAnterior.Checked = False Then
        'strSql = "Select tblVendas.IDfechamento, tblVendas.NumVenda, tblVendas.NumMesa, tblVendasMovto.IDProduto, tblVendas.Excluido, tblVendasMovto.MotivoEstorno, tblVendasMovto.Qtd, tblProdutos_Local.Produto, tblVendasMovto.Atendente, tblVendas.StatusVenda, tblVendas.Status, tblVendasMovto.StatusTransf "
        'strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto RIGHT OUTER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        'strSql += "Where (tblVendas.IDfechamento = " & IDfec & ") And (tblVendasMovto.StatusTransf <> '') "
        'strSql += "ORDER BY tblVendas.NumVenda"
        'Else
        strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.NumVenda, tblRetVendas.NumMesa, tblRetVendasMovto.IDProduto, tblRetVendas.Excluido, tblRetVendasMovto.MotivoEstorno, tblRetVendasMovto.Qtd, tblProdutos.Produto, tblRetVendasMovto.Atendente, tblRetVendas.StatusVenda, tblRetVendas.Status, tblRetVendasMovto.StatusTransf "
        strSql += "From tblRetVendasMovto INNER Join tblProdutos On tblRetVendasMovto.IDProduto = tblProdutos.IDProduto RIGHT OUTER Join tblRetVendas On tblRetVendasMovto.IDVendaRet = tblRetVendas.IDVendaRet "
        strSql += "Where (tblRetVendas.IDfechamento = " & IDfec & ") And (tblRetVendasMovto.StatusTransf <> '') "
        strSql += "ORDER BY tblRetVendas.NumVenda"
        'End If

        Dim dapTP = New SqlDataAdapter(strSql, conexao)
        dapTP.SelectCommand.CommandType = CommandType.Text
        Dim dsTP As New DataSet()
        dapTP.Fill(dsTP, "Vendas")

        PrintLine(lngFile, "Produtos transferidos")
        PrintLine(lngFile, "========================================")

        For i As Integer = 0 To dsTP.Tables("Vendas").Rows.Count - 1
            NumVenda = NuloInteger(dsTP.Tables("Vendas").Rows(i).Item("NumVenda"))

            texto = NuloInteger(dsTP.Tables("Vendas").Rows(i).Item("NumVenda"))
            PrintLine(lngFile, "Venda       " & texto)
            If NuloString(dsTP.Tables("Vendas").Rows(i).Item("StatusVenda")) = "S" Then
                TipoVenda = "Salao"
            Else
                If NuloString(dsTP.Tables("Vendas").Rows(i).Item("StatusVenda")) = "B" Then
                    TipoVenda = "Balcao"
                Else
                    TipoVenda = "Delivery"
                End If
            End If
            PrintLine(lngFile, "Modulo      " & TipoVenda)
            If TipoVenda = "Salao" Then
                texto = dsTP.Tables("Vendas").Rows(i).Item("NumMesa")
                PrintLine(lngFile, "Mesa/Cartao " & texto)
            End If
            PrintLine(lngFile, "----------------------------------------")
            Do While NumVenda = NuloInteger(dsTP.Tables("Vendas").Rows(i).Item("NumVenda"))
                texto = Strings.Left(NuloString(dsTP.Tables("Vendas").Rows(i).Item("Produto")), 25)
                If Len(texto) < 25 Then
                    texto += Space(25 - Len(texto))
                End If
                Qtde = dsTP.Tables("Vendas").Rows(i).Item("Qtd").ToString
                texto += Space(15 - Len(Qtde)) & Qtde
                PrintLine(lngFile, texto)

                texto = NuloString(dsTP.Tables("Vendas").Rows(i).Item("Atendente"))
                PrintLine(lngFile, "Atendente: " & texto)

                texto = NuloString(dsTP.Tables("Vendas").Rows(i).Item("MotivoEstorno"))
                PrintLine(lngFile, texto)

                texto = NuloString(dsTP.Tables("Vendas").Rows(i).Item("StatusTransf"))
                PrintLine(lngFile, texto)
                PrintLine(lngFile, " ")
                i += 1
                If i > dsTP.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "----------------------------------------")
        Next
        PrintLine(lngFile, "========================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        dapTP.Dispose()
        dsTP.Dispose()


        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")

        FileClose(lngFile)

    End Sub
    Private Sub CriaRelatDelivery(IDfec As Integer)

        Dim conS As New SqlConnection()
        Dim drS As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim conexao As String = strConServer


        ' Serviço e Caixinha /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        conS.ConnectionString = conexao
        Dim cmdS As SqlCommand = conS.CreateCommand


        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\delivery.txt", OpenMode.Output)

        strSql = "Select tblRetVendas.IDVenda, tblRetVendas.NumVendaD, tblRetVendas.StatusVenda, tblRetVendas.IDCliente, tblRetVendas.NomeCliente, tblClientes.Tel1, tblRetVendas.HoraAbertura, tblRetVendas.HoraProducao, tblRetVendas.HoraFechamento, tblRetVendas.Atendente, tblRetVendas.Excluido, tblRetVendas.Entregador, tblRetVendas.TotalVenda, tblRetVendas.Caixinha, tblRetVendas.TaxaEntrega, tblRetVendas.IDfechamento "
        strSql += "From tblRetVendas LEFT OUTER Join tblClientes On tblRetVendas.IDCliente = tblClientes.IDCliente "
        strSql += "Where (tblRetVendas.StatusVenda = 'D') AND (IDFechamento=" & IDfec & ") AND (tblRetVendas.Excluido=0) "
        strSql += "ORDER BY tblRetVendas.HoraFechamento, tblRetVendas.IDVenda DESC"

        cmdS.CommandText = strSql
        conS.Open()
        drS = cmdS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drS.HasRows Then
            DeliveryRelatorio = True
            Dim MaiorValor As Decimal = 0
            Dim MenorValor As Decimal = 500000

            Dim TempoProducao As String
            Dim TempoEntrega As String
            Dim TempoPedido As String

            Dim TotalProducao As Integer = 0
            Dim TotalEntrega As Integer = 0
            Dim TotalPedido As Integer = 0

            Dim Tproducao As Integer = 0
            Dim Tpedido As Integer = 0
            Do While drS.Read()
                If Not IsDBNull(drS.Item("HoraProducao")) Then
                    TotalProducao += Math.Abs(DateDiff(DateInterval.Second, drS.Item("HoraProducao"), drS.Item("HoraAbertura")))
                    Tproducao += 1
                End If

                If Not IsDBNull(drS.Item("HoraFechamento")) Then
                    TotalEntrega += Math.Abs(DateDiff(DateInterval.Second, drS.Item("HoraProducao"), drS.Item("HoraFechamento")))
                    Tpedido += 1

                    TotalPedido += Math.Abs(DateDiff(DateInterval.Second, drS.Item("HoraAbertura"), drS.Item("HoraFechamento")))
                End If
                If NuloDecimal(drS.Item("TotalVenda")) > MaiorValor Then
                    MaiorValor = NuloDecimal(drS.Item("TotalVenda"))
                End If
                If NuloDecimal(drS.Item("TotalVenda")) < MenorValor And NuloDecimal(drS.Item("TotalVenda")) > 0 Then
                    MenorValor = NuloDecimal(drS.Item("TotalVenda"))
                End If
            Loop

            If Tproducao = 0 Then Tproducao = 1
            Dim Hcorr As Integer
            Hcorr = CType((TotalProducao / Tproducao), Integer) / 60 / 60
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoProducao = Hcorr.ToString("00")

            Hcorr = CType((TotalProducao / Tproducao), Integer) / 60
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoProducao += ":" & Hcorr.ToString("00")
            Hcorr = CType(TotalProducao / Tproducao, Integer)
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoProducao += ":" & Hcorr.ToString("00")
            ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            If Tpedido = 0 Then Tpedido = 1
            Hcorr = CType((TotalEntrega / Tpedido), Integer) / 60 / 60
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoEntrega = Hcorr.ToString("00")

            Hcorr = CType((TotalEntrega / Tpedido), Integer) / 60
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoEntrega += ":" & Hcorr.ToString("00")

            Hcorr = CType(TotalEntrega / Tpedido, Integer)
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoEntrega += ":" & Hcorr.ToString("00")
            ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Hcorr = CType((TotalPedido / Tpedido), Integer) / 60 / 60
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoPedido = Hcorr.ToString("00")

            Hcorr = CType((TotalPedido / Tpedido), Integer) / 60
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoPedido += ":" & Hcorr.ToString("00")

            Hcorr = CType(TotalPedido / Tpedido, Integer)
            While Hcorr >= 60
                Hcorr -= 60
            End While
            TempoPedido += ":" & Hcorr.ToString("00")



            strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
            strSql += "From tblFechamentos "
            strSql += "Where (IDFechamento = " & IDfec & ")"

            texto = ""
            PrintLine(lngFile, "FECHAMENTO CAIXA")
            PrintLine(lngFile, "(Delivery)")
            PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, "Periodo    : " & NuloString(PegaValorCampo("DataAbertura", strSql, conexao)))
            If ckbMovtoAnterior.Checked = True Then
                PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataFechamento", strSql, conexao)))
            End If
            PrintLine(lngFile, "========================================")
            'PrintLine(lngFile, " ")
            PrintLine(lngFile, "<<< Tempo medio >>>")
            PrintLine(lngFile, "Producao    " & TempoProducao)
            PrintLine(lngFile, "Entrega     " & TempoEntrega)
            PrintLine(lngFile, "         ----------------")
            PrintLine(lngFile, "Pedido      " & TempoPedido)
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "<<<   Pedidos   >>>")
            PrintLine(lngFile, "Maior valor     " & Format(MaiorValor, "#0.00"))
            PrintLine(lngFile, "Menor valor     " & Format(MenorValor, "#0.00"))
            PrintLine(lngFile, "Clientes novos  " & NuloInteger(ClientesNovos(IDfec)))
            PrintLine(lngFile, " ")

            strSql = "Select tblRetVendas.StatusVenda, COUNT(tblRetVendas.IDVendaRet) As Qtde, tblRetVendas.Excluido, SUM(tblRetVendas.TotalVenda) As Valor, tblClientes.Origem, tblRetVendas.IDFechamento "
            strSql += "From tblRetVendas INNER Join tblClientes On tblRetVendas.IDCliente = tblClientes.IDCliente "
            strSql += "Group By tblRetVendas.StatusVenda, tblRetVendas.Excluido, tblClientes.Origem, tblRetVendas.IDFechamento "
            strSql += "HAVING(tblRetVendas.StatusVenda = 'D') AND (tblRetVendas.Excluido = 0) AND (tblRetVendas.IDFechamento=" & IDfec & ") "
            strSql += "ORDER BY Valor DESC"
            Dim conP As New SqlConnection()
            Dim drP As SqlDataReader
            Dim cmdP As SqlCommand = conP.CreateCommand
            conP.ConnectionString = conexao
            cmdP.CommandText = strSql
            conP.Open()
            drP = cmdP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drP.HasRows Then

                strSql = "Select tblRetVendas.StatusVenda, tblRetVendas.Excluido, SUM(tblRetVendas.TotalVenda) As Valor, tblRetVendas.IDFechamento "
                strSql += "From tblRetVendas INNER Join tblClientes On tblRetVendas.IDCliente = tblClientes.IDCliente "
                strSql += "Group By tblRetVendas.StatusVenda, tblRetVendas.Excluido, tblRetVendas.IDFechamento  "
                strSql += "HAVING(tblRetVendas.StatusVenda = 'D') AND (tblRetVendas.Excluido = 0) AND (IDFechamento=" & IDfec & ") "
                Dim ValorTotal As Decimal = NuloDecimal(PegaValorCampo("Valor", strSql, conexao))
                Dim Origem As String
                Dim Qtde As Integer
                Dim Valor As Decimal
                Dim PercValor As Decimal
                Dim Txt As String
                'PrintLine(lngFile, "========================================")
                'PrintLine(lngFile, " ")
                PrintLine(lngFile, "<<<  por Origem  >>>")
                PrintLine(lngFile, "               Qtde        Valor")
                Do While drP.Read()
                    If NuloString(drP.Item("Origem")) <> "" Then
                        Origem = drP.Item("Origem")
                    Else
                        Origem = "Nao informado"
                    End If
                    If Len(Origem) < 15 Then
                        Origem &= Space(15 - Len(Origem))
                    Else
                        Origem &= Strings.Left(Origem, 15)
                    End If
                    texto = Origem

                    texto += Space(5 - Len(NuloInteger(drP.Item("Qtde")))) & NuloInteger(drP.Item("Qtde"))
                    Qtde += NuloInteger(drP.Item("Qtde"))

                    texto += Space(15 - Len(Format(NuloDecimal(drP.Item("Valor")), "#0.00"))) & Format(NuloDecimal(drP.Item("Valor")), "#0.00")

                    PercValor = (NuloDecimal(drP.Item("Valor")) / ValorTotal) * 100
                    texto += Space(7 - Len(Format(PercValor, "#0.0"))) & Format(PercValor, "#0.0") & "%"
                    PrintLine(lngFile, texto)
                Loop
                PrintLine(lngFile, "              -------------------")
                texto = Space(19 - Len(Qtde)) & Qtde
                texto += Space(15 - Len(Format(ValorTotal, "#0.00"))) & Format(ValorTotal, "#0.00") & "  (" & Format(ValorTotal / Qtde, "#0.00") & ")"
                PrintLine(lngFile, texto)
            End If

            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

            cmdP.Dispose()
            drP.Close()
            conP.Dispose()
            conP.Close()


            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

            FileClose(lngFile)

            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\delivery.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If
        cmdS.Dispose()
        drS.Close()
        conS.Dispose()
        conS.Close()




    End Sub
    Private Sub CriaRelatServicoCaixinha(IDfec As Integer)
        Dim conS As New SqlConnection()
        Dim drS As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim conexao As String = strConServer


        ' Serviço e Caixinha /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        conS.ConnectionString = conexao
        Dim cmdS As SqlCommand = conS.CreateCommand

        'strSql = "Select IDFechamento, SUM(TotalProdutos) As vlrProd, SUM(QtdPessoas) As QtdePes, Excluido, SUM(Servico) As vlrServico, SUM(Caixinha) As vlrCaixinha, Atendente "
        'strSql += "From tblRetVendas "
        'strSql += "Group By IDFechamento, Excluido, Atendente "
        'strSql += "HAVING (Excluido = 0) And (IDfechamento = " & IDfec & ") "
        'strSql += "ORDER BY Atendente"

        'strSql = "Select IDFechamento, SUM(TotalProdutos) As vlrProd, SUM(QtdPessoas) As QtdePes, Excluido, SUM(Servico) As vlrServico, SUM(Caixinha) As vlrCaixinha, Case WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END AS Funcionario, StatusVenda "
        'strSql += "From tblRetVendas "
        'strSql += "Group By IDFechamento, Excluido, CASE WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END, StatusVenda "

        strSql = "Select IDFechamento, SUM(TotalProdutos) As vlrProd, SUM(QtdPessoas) As QtdePes, Excluido, SUM(Servico) As vlrServico, SUM(Caixinha) As vlrCaixinha, Case WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END AS Funcionario, StatusVenda, COUNT(IDVendaRet) AS QtdeVdas "
        strSql += "From tblRetVendas "
        strSql += "Group By IDFechamento, Excluido, CASE WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END, StatusVenda "
        strSql += "HAVING(Excluido = 0) And (IDfechamento = " & IDfec & ") "
        strSql += "ORDER BY StatusVenda, vlrProd DESC"

        cmdS.CommandText = strSql
        conS.Open()
        drS = cmdS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim TotalProd As Decimal
        Dim VlrPro As Decimal
        TotalProd = 0

        If drS.HasRows Then
            FileClose(lngFile)
            FileOpen(lngFile, Application.StartupPath & "\Impressao\servico.txt", OpenMode.Output)


            Dim vlrServ As Decimal
            Dim vlrCaix As Decimal
            Dim vlrServAj As Decimal
            Dim totServ As Decimal = 0
            Dim totCaix As Decimal = 0
            Dim totServAj As Decimal = 0
            Dim qtdePes As Integer
            Dim qtdePesTot As Integer
            Dim VlrEntr As Decimal = 0
            Dim VlrEntrAcm As Decimal = 0

            PrintLine(lngFile, " ")
            PrintLine(lngFile, "                        Servico/Caixinha")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                PrintLine(lngFile, "Fun Vlr Pro Serv Ajust Caixinha Qtd       ")
            Else
                PrintLine(lngFile, "Func.   Vlr Pro    Servico  Caixinha   Qtd")
            End If
            PrintLine(lngFile, "==========================================")
            While drS.Read
                VlrPro = NuloDecimal(drS.Item("vlrProd"))
                vlrServ = NuloDecimal(drS.Item("vlrServico"))
                vlrServAj = NuloDecimal(NuloDecimal(drS.Item("vlrServico")) * ((100 - FatorAjusteServico) / 100))
                vlrCaix = NuloDecimal(drS.Item("vlrCaixinha"))

                If NuloString(MediaQtdeVdas) = "False" Or NuloString(MediaQtdeVdas) = "Não" Then
                    qtdePes = NuloInteger(drS.Item("QTdePes"))
                Else
                    qtdePes = NuloInteger(drS.Item("QtdeVdas"))
                End If

                VlrEntr = 7.5 * qtdePes
                VlrEntrAcm += 7.5 * qtdePes

                qtdePesTot += qtdePes

                totServ += vlrServ.ToString("#0.00")
                totCaix += vlrCaix.ToString("#0.00")
                totServAj += vlrServAj.ToString("#0.00")
                TotalProd += VlrPro.ToString("#0.00")


                If NuloInteger(FatorAjusteServico) <> 0 Then
                    texto = Trim(Strings.Left(drS.Item("Funcionario"), 3))
                    If Len(texto) < 3 Then
                        texto += Space(3 - Len(texto))
                    End If
                Else
                    texto = Trim(Strings.Left(drS.Item("Funcionario"), 8))
                    If Len(texto) < 8 Then
                        texto += Space(8 - Len(texto))
                    End If
                End If


                texto += Space(8 - Len(VlrPro.ToString("#0.00"))) & VlrPro.ToString("#0.00")
                texto += Space(10 - Len(vlrServAj.ToString("#0.00"))) & vlrServAj.ToString("#0.00")
                texto += Space(10 - Len(vlrCaix.ToString("#0.00"))) & vlrCaix.ToString("#0.00")
                texto += Space(5 - Len(qtdePes.ToString("#0"))) & qtdePes.ToString("#0")

                If NuloInteger(FatorAjusteServico) <> 0 Then
                    texto += Space(7 - Len(VlrEntr.ToString("#0.00"))) & VlrEntr.ToString("#0.00")
                End If


                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "------------------------------------------")

            If NuloInteger(FatorAjusteServico) <> 0 Then
                texto = "   "
            Else
                texto = "TOTAL "
            End If

            texto += Space(8 - Len(TotalProd.ToString("#0.00"))) & TotalProd.ToString("#0.00")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                texto += Space(10 - Len(totServAj.ToString("#0.00"))) & totServAj.ToString("#0.00")
            Else
                texto += Space(10 - Len(totServ.ToString("#0.00"))) & totServ.ToString("#0.00")
            End If
            texto += Space(10 - Len(totCaix.ToString("#0.00"))) & totCaix.ToString("0.00")
            texto += Space(5 - Len(qtdePesTot.ToString("#0"))) & qtdePesTot.ToString("#0")

            If NuloInteger(FatorAjusteServico) <> 0 Then
                texto += Space(7 - Len(VlrEntrAcm.ToString("#0.00"))) & VlrEntrAcm.ToString("0.00")
            End If


            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                Dim ServicoAj As Decimal = totServ - totServAj
                PrintLine(lngFile, "*Servico ajustado:  " & FatorAjusteServico & "%    (" & ServicoAj.ToString("#0.00") & ")")
            End If
        End If
        cmdS.Dispose()
        drS.Close()
        conS.Dispose()
        conS.Close()

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")

        FileClose(lngFile)

    End Sub

    Private Sub Fechamento_Conciliacao(IDFGou As Integer)

        Dim conN As New SqlConnection(strCon)
        strSql = "Select * "
        strSql += "From tblFechamentosDescricao_Local "
        strSql += "Where (IDFechamento =" & IDFGou & ")"
        conN.Open()
        Dim cmd As New SqlCommand(strSql, conN)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read
                strSql = "INSERT tblFechamentosDescricao "
                strSql += "(IDFechamento, IDFormaPagto, IDContaCorrente, IDConta, IDConta_Taxa, IDConta_ContraPartida, DataTransferencia, DataContaReceber, Tipo, Descricao, DescricaoContraPartida, ValorBruto, ValorLiquido, Diferenca) VALUES ("
                strSql += to_sql(idfecret) & ", "
                strSql += to_sql(dr.Item("IDFormaPagto")) & ", "
                strSql += "0, "
                strSql += to_sql(dr.Item("IDConta")) & ", "
                strSql += to_sql(dr.Item("IDConta_Taxa")) & ", "
                strSql += to_sql(dr.Item("IDConta_ContraPartida")) & ", "
                strSql += to_sqlDATA(dr.Item("DataTransferencia"), "data", "R") & ", "
                strSql += to_sqlDATA(dr.Item("DataContaReceber"), "data", "R") & ", "
                strSql += to_sql(dr.Item("Tipo")) & ", "
                strSql += to_sql(dr.Item("Descricao")) & ", "
                strSql += to_sql(dr.Item("DescricaoContraPartida")) & ", "
                strSql += to_sql(Replace(dr.Item("ValorBruto"), ",", ".")) & ", "
                strSql += to_sql(Replace(dr.Item("ValorLiquido"), ",", ".")) & ", "
                strSql += to_sql(Replace(dr.Item("Diferenca"), ",", ".")) & ")"
                ExecutaStrServidor(strSql)
            End While
        End If

        dr.Close()
        cmd.Dispose()
        conN.Dispose()
        conN.Close()
    End Sub
    Private Sub IncluiVendaSAT(IDVdaGou As Integer, IDVdaRet_ As Integer)

        Dim conP As New SqlConnection(strCon)
        'conP.ConnectionString = strCon
        Dim cmdP As SqlCommand = conP.CreateCommand
        cmdP.CommandText = "SELECT * FROM tblVendasSAT WHERE (IDVenda=" & IDVdaGou & ")"

        conP.Open()
        Dim drP As SqlDataReader
        drP = cmdP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        While drP.Read
            strSql = "INSERT tblRetVendasSAT (IDVendaRet,NumSAT,Num_SAT,XML,ValorCupom) VALUES ("
            strSql += to_sql(IDVdaRet_) & ", "
            strSql += to_sql(NuloString(drP.Item("NumSAT"))) & ", "
            strSql += to_sql(NuloString(drP.Item("Num_SAT"))) & ", "
            strSql += to_sql(NuloString(drP.Item("XML"))) & ", "
            strSql += to_sql(Replace(drP.Item("ValorCupom"), ",", ".")) & ")"
            ExecutaStrServidor(strSql)
        End While
        cmdP.Dispose()
        drP.Close()
        conP.Dispose()
        conP.Close()

    End Sub

    Private Sub IncluiVendaPagto(IDVdaGou As Integer, IDVdaRet_ As Integer)

        Dim conP As New SqlConnection(strCon)
        'conP.ConnectionString = strCon
        Dim cmdP As SqlCommand = conP.CreateCommand
        cmdP.CommandText = "SELECT * FROM tblVendasPagto WHERE (IDVenda=" & IDVdaGou & ")"

        conP.Open()
        Dim drP As SqlDataReader
        drP = cmdP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        While drP.Read
            strSql = "INSERT tblRetVendasPagto (IDVendaRet,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom,IDCliente,IDPendencia) VALUES ("
            strSql += to_sql(IDVdaRet_) & ", "
            strSql += to_sql(drP.Item("IDFormaPagto")) & ", "
            strSql += to_sql(drP.Item("Descricao")) & ", "
            strSql += to_sql(Replace(drP.Item("ValorPago"), ",", ".")) & ", "
            strSql += to_sql(drP.Item("ECartao")) & ", "
            strSql += to_sql(Replace(NuloDecimal(drP.Item("TaxaCartao")), ",", ".")) & ", "
            strSql += to_sql(NuloString(drP.Item("Tipo"))) & ", "
            strSql += to_sql(NuloBoolean(drP.Item("Cupom"))) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDCliente"))) & ", "
            strSql += to_sql(NuloInteger(drP.Item("IDPendencia"))) & ")"
            ExecutaStrServidor(strSql)
        End While
        cmdP.Dispose()
        drP.Close()
        conP.Dispose()
        conP.Close()

    End Sub
    Private Sub IncluiVendaMovto(IDVdaGou As Integer)

        Dim conVdaM As New SqlConnection(strCon)
        Dim IDVdaMovtoGou As Integer
        Dim IDVdaMovtoRet As Integer
        Dim EPizz As Boolean
        Dim cmdVdaM As SqlCommand = conVdaM.CreateCommand

        strSql = "SELECT * FROM tblVendasMovto WHERE (IDVenda=" & IDVdaGou & ")"
        conVdaM.Open()
        cmdVdaM.CommandText = strSql
        Dim drVdaM As SqlDataReader
        drVdaM = cmdVdaM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drVdaM.HasRows Then
            While drVdaM.Read
                IDVdaMovtoGou = drVdaM.Item("IDVendaMovto")

                strSql = "SELECT CodigoGrupo, EPizza FROM tblGrupos_Local WHERE CodigoGrupo=" & drVdaM.Item("IDGrupo")
                EPizz = NuloBoolean(PegaValorCampo("EPizza", strSql, strCon))

                strSql = "INSERT tblRetVendasMovto (IDVendaRet,IDProduto,Produto,Qtd,Venda,VendaServico,Excluido,HoraPedido,Comanda,Categoria,IDFuncionario,Atendente,MesaCartao,IDGrupo,Grupo,StatusTransf,IDVendaRetMovto_Gou,MotivoEstorno,EPizza) VALUES ("
                strSql += to_sql(IDVdaRet) & ", "
                strSql += to_sql(drVdaM.Item("IDProduto")) & ", "
                strSql += to_sql(drVdaM.Item("Produto")) & ", "
                strSql += to_sql(Replace(drVdaM.Item("Qtd"), ",", ".")) & ", "
                strSql += to_sql(Replace(drVdaM.Item("Venda"), ",", ".")) & ", "
                strSql += to_sql(Replace(drVdaM.Item("VendaServico"), ",", ".")) & ", "
                strSql += to_sql(drVdaM.Item("Excluido")) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("HoraPedido"))) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("Comanda"))) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("Categoria"))) & ", "
                strSql += to_sql(NuloInteger(drVdaM.Item("IDFuncionario"))) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("Atendente"))) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("MesaCartao"))) & ", "
                strSql += to_sql(NuloInteger(drVdaM.Item("IDGrupo"))) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("Grupo"))) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("StatusTransf"))) & ", "
                strSql += to_sql(IDVdaGou) & ", "
                strSql += to_sql(NuloString(drVdaM.Item("MotivoEstorno"))) & ", "
                strSql += to_sql(EPizz) & ")"
                ExecutaStrServidor(strSql)

                IDVdaMovtoRet = PegaID("IDVendaRetMovto", "tblRetVendasMovto", "S")

                ' Inclui vendas Combo no Retaguarda  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IncluiVendaCombo(IDVdaMovtoGou, IDVdaMovtoRet)

                ' Inclui Comentarios movto  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IncluiComentMovto(IDVdaMovtoGou, IDVdaMovtoRet, "M")
            End While
        End If
        cmdVdaM.Dispose()
        drVdaM.Close()
        conVdaM.Dispose()
        conVdaM.Close()
    End Sub
    Private Sub IncluiComentMovto(IDVdaGou As Integer, IDVdaRet_ As Integer, Status As String)

        Dim conVdaC As New SqlConnection(strCon)
        Dim cmdVdaC As SqlCommand = conVdaC.CreateCommand

        If Status = "M" Then
            strSql = "SELECT * FROM tblVendasComent WHERE (IDVendaMovto=" & IDVdaGou & ")"
        Else
            strSql = "SELECT * FROM tblVendasComent WHERE (IDVendaCombo=" & IDVdaGou & ")"
        End If

        conVdaC.Open()
        cmdVdaC.CommandText = strSql
        Dim drVdaC As SqlDataReader
        drVdaC = cmdVdaC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drVdaC.HasRows Then
            While drVdaC.Read
                strSql = "INSERT tblRetVendasComent (IDRetVenda,IDRetVendaMovto,IDRetVendaCombo,Coment,IDProdutoVinculado) VALUES ("
                strSql += to_sql(IDVdaRet) & ", "
                If Status = "M" Then
                    strSql += to_sql(IDVdaRet_) & ", "
                    strSql += "0, "
                Else
                    strSql += "0, "
                    strSql += to_sql(IDVdaRet_) & ", "
                End If
                strSql += to_sql(NuloString(drVdaC.Item("Coment"))) & ", "
                strSql += to_sql(NuloInteger(drVdaC.Item("IDProdutoVinculado"))) & ")"
                ExecutaStrServidor(strSql)
            End While
        End If
        cmdVdaC.Dispose()
        drVdaC.Close()
        conVdaC.Dispose()
        conVdaC.Close()
    End Sub
    Private Sub IncluiVendaCombo(IDVdaMGou As Integer, IDVdaMRet As Integer)

        Dim conVdaC As New SqlConnection(strCon)
        Dim cmdVdaC As SqlCommand = conVdaC.CreateCommand
        Dim IDVdaCombo As Integer
        Dim IDVdaComboRet As Integer
        Dim Venda As Decimal

        strSql = "SELECT * FROM tblVendasCombo WHERE (IDVendaMovto=" & IDVdaMGou & ")"

        conVdaC.Open()
        cmdVdaC.CommandText = strSql
        Dim drVdaC As SqlDataReader
        drVdaC = cmdVdaC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drVdaC.HasRows Then
            While drVdaC.Read
                IDVdaCombo = drVdaC.Item("IDVendaCombo")

                strSql = "SELECT IDProduto, Venda FROM tblProdutos_Local WHERE IDProduto=" & drVdaC.Item("IDProduto")
                Venda = NuloDecimal(PegaValorCampo("Venda", strSql, strCon))

                strSql = "INSERT tblRetVendasCombo (IDVendaRetMovto,IDProduto,Produto,Qtd,Venda,VendaServico,Categoria,IDGrupo,Grupo) VALUES ("
                strSql += to_sql(IDVdaMRet) & ", "
                strSql += to_sql(drVdaC.Item("IDProduto")) & ", "
                strSql += to_sql(drVdaC.Item("Produto")) & ", "
                strSql += to_sql(Replace(drVdaC.Item("Qtd"), ",", ".")) & ", "
                strSql += to_sql(Replace(Venda, ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVdaC.Item("VendaServico")), ",", ".")) & ", "
                strSql += to_sql(NuloString(drVdaC.Item("Categoria"))) & ", "
                strSql += to_sql(NuloInteger(drVdaC.Item("IDGrupo"))) & ", "
                strSql += to_sql(NuloString(drVdaC.Item("Grupo"))) & ")"
                ExecutaStrServidor(strSql)

                IDVdaComboRet = PegaID("IDVendaRetCombo", "tblRetVendasCombo", "S")

                ' Inclui Comentarios Combo  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IncluiComentMovto(IDVdaCombo, IDVdaComboRet, "C")
            End While
        End If
        cmdVdaC.Dispose()
        drVdaC.Close()
        conVdaC.Dispose()
        conVdaC.Close()
    End Sub
    Public Sub AtualizaRuas()

inicioRuas:

        strSql = "Select tblRuas.IDRua, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuas.Atualiza, tblRuasCEP.CEP "
        strSql += "From tblRuas LEFT OUTER Join tblRuasCEP On tblRuas.IDRua = tblRuasCEP.IDRua "
        strSql += "Where (tblRuas.Atualiza Is NULL) Or (tblRuas.Atualiza = 1) "
        strSql += "Order By tblRuas.IDRua"

        Dim num As Integer = 0
        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        Dim IDrua As Integer
        Dim IDruaServ As Integer
        Dim TipoLogradouro As String
        Dim Logradouro As String
        Dim Bairro As String
        Dim Cidade As String
        Dim Estado As String
        Dim Area As String

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            IDrua = NuloInteger(ds.Tables("Ruas").Rows(i).Item("IDRua"))
            TipoLogradouro = NuloString(ds.Tables("Ruas").Rows(i).Item("TipoLogradouro"))
            Logradouro = Replace(VerificaTexto(NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro"))), "'", " ")
            Bairro = Replace(VerificaTexto(NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro"))), "'", " ")
            Cidade = NuloString(ds.Tables("Ruas").Rows(i).Item("Cidade"))
            Estado = NuloString(ds.Tables("Ruas").Rows(i).Item("Estado"))
            Area = NuloString(ds.Tables("Ruas").Rows(i).Item("Area"))

            strSql = "Select IDRua, IDRuaLoja, IDLoja FROM tblRuasLojas WHERE (IDRua=" & IDrua & ") And (IDLoja=" & IDLoja & ")"
            If NuloInteger(PegaValorCampo("IDRua", strSql, strConServer)) = 0 Then
                strSql = "INSERT INTO tblRuasLojas (IDRua,IDLoja,TipoLogradouro,Logradouro,Bairro,Cidade,Estado,Area) VALUES ("
                strSql += IDrua & ","
                strSql += IDLoja & ","
                strSql += "'" & TipoLogradouro & "',"
                strSql += "'" & Logradouro & "',"
                strSql += "'" & Bairro & "',"
                strSql += "'" & Cidade & "',"
                strSql += "'" & Estado & "',"
                strSql += "'" & Area & "')"
                ExecutaStrServidor(strSql)
                IDruaServ = PegaID("IDRuaLoja", "tblRuasLojas", "S")

                While IDrua = NuloInteger(ds.Tables("Ruas").Rows(i).Item("IDRua"))
                    strSql = "Select IDRuaCEP, IDRuaLoja, CEP FROM tblRuasCEPLojas WHERE (IDRua=" & IDrua & ") And (CEP=" & NuloString(ds.Tables("Ruas").Rows(i).Item("CEP")) & ")"
                    If NuloInteger(PegaValorCampo("IDRuaCEP", strSql, strConServer)) = 0 Then
                        strSql = "INSERT INTO tblRuasCEPLojas (IDRuaLoja, IDRua, CEP) VALUES ("
                        strSql += IDruaServ & ","
                        strSql += IDrua & ","
                        strSql += "'" & NuloString(ds.Tables("Ruas").Rows(i).Item("CEP")) & "')"
                        ExecutaStrServidor(strSql)
                    End If

                    If i + 1 > ds.Tables("Ruas").Rows.Count - 1 Then Exit While
                    If IDrua <> NuloInteger(ds.Tables("Ruas").Rows(i + 1).Item("IDRua")) Then Exit While
                    i += 1
                End While
            Else
                strSql = "Update tblRuasLojas Set "
                strSql += "IDLoja=" & IDLoja & ","
                strSql += "TipoLogradouro='" & TipoLogradouro & "',"
                strSql += "Logradouro='" & Logradouro & "',"
                strSql += "Bairro='" & Bairro & "',"
                strSql += "Cidade='" & Cidade & "',"
                strSql += "Estado='" & Estado & "',"
                strSql += "Area='" & Area & "' "
                strSql += "WHERE (IDRua=" & IDrua & ") And (IDLoja=" & IDLoja & ")"
                ExecutaStrServidor(strSql)

                strSql = "Select IDRua, IDRuaLoja, IDLoja FROM tblRuasLojas WHERE (IDRua=" & IDrua & ") And (IDLoja=" & IDLoja & ")"
                IDruaServ = PegaValorCampo("IDRuaLoja", strSql, strConServer)

                While IDrua = NuloInteger(ds.Tables("Ruas").Rows(i).Item("IDRua"))
                    strSql = "Select IDRuaCEP, IDRuaLoja, CEP FROM tblRuasCEPLojas WHERE (IDRuaLoja=" & IDruaServ & ") And (CEP=" & NuloString(ds.Tables("Ruas").Rows(i).Item("CEP")) & ")"
                    If NuloInteger(PegaValorCampo("IDRuaCEP", strSql, strConServer)) = 0 Then
                        strSql = "INSERT INTO tblRuasCEPLojas (IDRua, IDRuaLoja, CEP) VALUES ("
                        strSql += IDrua & ","
                        strSql += IDruaServ & ","
                        strSql += "'" & NuloString(ds.Tables("Ruas").Rows(i).Item("CEP")) & "')"
                        ExecutaStrServidor(strSql)
                    End If

                    If i + 1 > ds.Tables("Ruas").Rows.Count - 1 Then Exit While
                    i += 1
                End While

            End If

            strSql = "Update tblRuas Set "
            strSql += "Atualiza=0 "
            strSql += "WHERE (IDRua = " & IDrua & ")"
            ExecutaStr(strSql)
            num += 1

            If num > 500 Then
                GoTo inicioRuas
            End If

        Next
    End Sub
    Public Sub AtualizaClientes()

inicio:

        Dim num As Integer = 0
        Dim con As New SqlConnection(strCon)
        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select * FROM tblClientes WHERE (Atualiza Is NULL) Or (Atualiza = 1)"
        con.Open()
        cmd.CommandText = strSql
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read
                strSql = "Select IDCliente, IDClienteLoja, IDLoja FROM tblClientesLojas WHERE (IDClienteLoja=" & dr.Item("IDCliente") & ") And (IDLoja=" & dr.Item("IDLoja") & ")"
                If NuloInteger(PegaValorCampo("IDCliente", strSql, strConServer)) = 0 Then
                    strSql = "INSERT INTO tblClientesLojas (IDClienteLoja,IDLoja,CodigoCliente,NomeCliente,Numero,Complemento,Referencia,Bairro,CEP,Area,Cidade,Estado,IDExterno,Tel1,Tel2,ComplementoTel,Origem,DataNascimento,DataCadastro,StatusCliente,DataAtualizacao,Responsavel,Sexo,SaldoCredito,Credito,CartaoPref,DDD1,DDD2,CPF_CNPJ,IDRua,SaldoNegativo,Observacao,DataUltimaVenda,IDVendaUltimaVenda,QtdVendas,Pontos,Email) VALUES ("
                    strSql += NuloInteger(dr.Item("IDCliente")) & ","
                    strSql += NuloInteger(dr.Item("IDLoja")) & ","
                    strSql += NuloInteger(dr.Item("CodigoCliente")) & ","
                    strSql += "'" & Replace(VerificaTexto(NuloString(dr.Item("NomeCliente"))), "'", " ") & "',"
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Numero"))) & "',"
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Complemento"))) & "',"
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Referencia"))) & "',"
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Bairro"))) & "',"
                    strSql += "'" & NuloString(dr.Item("CEP")) & "',"
                    strSql += "'" & NuloString(dr.Item("Area")) & "',"
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Cidade"))) & "',"
                    strSql += "'" & NuloString(dr.Item("Estado")) & "',"
                    strSql += "'" & NuloString(dr.Item("IDExterno")) & "',"
                    strSql += "'" & NuloString(dr.Item("Tel1")) & "',"
                    strSql += "'" & NuloString(dr.Item("Tel2")) & "',"
                    strSql += "'" & NuloString(VerificaTexto(NuloString(dr.Item("ComplementoTel")))) & "',"
                    strSql += "'" & NuloString(dr.Item("Origem")) & "',"
                    If NuloString(dr.Item("DataNascimento")) = "" Then
                        strSql += "NULL, "
                    Else
                        strSql += to_sqlDATA(NuloString(dr.Item("DataNascimento")), "datahora", "R") & ", "
                    End If
                    If NuloString(dr.Item("DataCadastro")) = "" Then
                        strSql += "NULL, "
                    Else
                        strSql += to_sqlDATA(NuloString(dr.Item("DataCadastro")), "datahora", "R") & ", "
                    End If
                    strSql += "'" & NuloString(dr.Item("StatusCliente")) & "',"
                    If NuloString(dr.Item("DataAtualizacao")) = "" Then
                        strSql += to_sqlDATA(Now, "datahora", "R") & ", "
                    Else
                        strSql += to_sqlDATA(NuloString(dr.Item("DataAtualizacao")), "datahora", "R") & ", "
                    End If
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Responsavel"))) & "',"
                    strSql += "'" & NuloString(dr.Item("Sexo")) & "',"
                    strSql += Replace(NuloDecimal(dr.Item("SaldoCredito")), ",", ".") & ","
                    strSql += Replace(NuloDecimal(dr.Item("Credito")), ",", ".") & ","
                    strSql += "'" & NuloString(dr.Item("CartaoPref")) & "',"
                    strSql += "'" & NuloString(dr.Item("DDD1")) & "',"
                    strSql += "'" & NuloString(dr.Item("DDD2")) & "',"
                    strSql += "'" & NuloString(dr.Item("CPF_CNPJ")) & "',"
                    strSql += NuloInteger(dr.Item("IDRua")) & ","
                    strSql += "'" & NuloBoolean(dr.Item("SaldoNegativo")) & "',"
                    strSql += "'" & VerificaTexto(NuloString(dr.Item("Observacao"))) & "', "
                    strSql += to_sqlDATA(NuloString(dr.Item("DataUltimaVenda")), "datahora", "R") & ", "
                    strSql += NuloInteger(dr.Item("IDVendaUltimaVenda")) & ", "
                    strSql += NuloInteger(dr.Item("QtdVendas")) & ", "
                    strSql += Replace(NuloDecimal(dr.Item("Pontos")), ",", ".") & ", "
                    strSql += "'" & NuloString(dr.Item("Email")) & "')"
                Else
                    strSql = "Update tblClientesLojas Set "
                    strSql += "IDClienteLoja = " & NuloInteger(dr.Item("IDCliente")) & ","
                    strSql += "IDLoja=" & dr.Item("IDLoja") & ","
                    strSql += "CodigoCliente = " & NuloInteger(dr.Item("CodigoCliente")) & ","
                    strSql += "NomeCliente='" & Replace(VerificaTexto(NuloString(dr.Item("NomeCliente"))), "'", " ") & "',"
                    strSql += "Numero='" & NuloString(dr.Item("Numero")) & "',"
                    strSql += "Complemento='" & VerificaTexto(NuloString(dr.Item("Complemento"))) & "',"
                    strSql += "Referencia='" & VerificaTexto(NuloString(dr.Item("Referencia"))) & "',"
                    strSql += "Bairro='" & VerificaTexto(NuloString(dr.Item("Bairro"))) & "',"
                    strSql += "CEP='" & NuloString(dr.Item("CEP")) & "',"
                    strSql += "Area='" & NuloString(dr.Item("Area")) & "',"
                    strSql += "Cidade='" & VerificaTexto(NuloString(dr.Item("Cidade"))) & "',"
                    strSql += "Estado='" & NuloString(dr.Item("Estado")) & "',"
                    strSql += "IDExterno='" & NuloString(dr.Item("IDExterno")) & "',"
                    strSql += "Tel1='" & NuloString(dr.Item("Tel1")) & "',"
                    strSql += "Tel2='" & NuloString(dr.Item("Tel2")) & "',"
                    strSql += "ComplementoTel='" & VerificaTexto(NuloString(dr.Item("ComplementoTel"))) & "',"
                    strSql += "Origem='" & NuloString(dr.Item("Origem")) & "',"
                    If NuloString(dr.Item("DataNascimento")) = "" Then
                        strSql += "DataNascimento=NULL,"
                    Else
                        strSql += "DataNascimento=" & to_sqlDATA(NuloString(dr.Item("DataNascimento")), "datahora", "R") & ","
                    End If
                    If NuloString(dr.Item("DataCadastro")) = "" Then
                        strSql += "DataCadastro=NULL,"
                    Else
                        strSql += "DataCadastro=" & to_sqlDATA(NuloString(dr.Item("DataCadastro")), "datahora", "R") & ","
                    End If
                    strSql += "StatusCliente='" & NuloString(dr.Item("StatusCliente")) & "',"
                    strSql += "DataAtualizacao=" & to_sqlDATA(NuloString(dr.Item("DataAtualizacao")), "datahora", "R") & ","
                    strSql += "Responsavel='" & VerificaTexto(NuloString(dr.Item("Responsavel"))) & "',"
                    strSql += "Sexo='" & NuloString(dr.Item("Sexo")) & "',"
                    strSql += "SaldoCredito=" & Replace(NuloDecimal(dr.Item("SaldoCredito")), ",", ".") & ","
                    strSql += "Credito='" & Replace(NuloDecimal(dr.Item("Credito")), ",", ".") & "',"
                    strSql += "CartaoPref='" & NuloString(dr.Item("CartaoPref")) & "',"
                    strSql += "DDD1='" & NuloString(dr.Item("DDD1")) & "',"
                    strSql += "DDD2='" & NuloString(dr.Item("DDD2")) & "',"
                    strSql += "CPF_CNPJ='" & NuloString(dr.Item("CPF_CNPJ")) & "',"
                    strSql += "IDRua=" & NuloInteger(dr.Item("IDRua")) & ","
                    strSql += "SaldoNegativo='" & NuloBoolean(dr.Item("Credito")) & "',"
                    strSql += "Observacao='" & VerificaTexto(NuloString(dr.Item("Observacao"))) & "', "
                    strSql += "DataUltimaVenda=" & to_sqlDATA(NuloString(dr.Item("DataUltimaVenda")), "datahora", "R") & ", "
                    strSql += "IDVendaUltimaVenda=" & NuloInteger(dr.Item("IDVendaUltimaVenda")) & ", "
                    strSql += "QtdVendas=" & NuloInteger(dr.Item("QtdVendas")) & ", "
                    strSql += "Pontos=" & Replace(NuloDecimal(dr.Item("Pontos")), ",", ".") & ", "
                    strSql += "Email='" & NuloString(dr.Item("Email")) & "' "
                    strSql += "WHERE (IDClienteLoja=" & dr.Item("IDCliente") & ") And (IDLoja=" & dr.Item("IDLoja") & ")"
                End If
                ExecutaStrServidor(strSql)

                strSql = "Update tblClientes Set "
                strSql += "Atualiza=0 "
                strSql += "WHERE (IDCliente = " & dr.Item("IDCliente") & ")"
                ExecutaStr(strSql)
                num += 1

                If num > 500 Then
                    cmd.Dispose()
                    dr.Close()
                    con.Dispose()
                    con.Close()
                    GoTo inicio
                End If


            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub LancamentoPendenciasNaoVinculadas()
        Dim strSql_ As String
        Dim con As New SqlConnection(strCon)
        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select * FROM tblPendenciasLoja WHERE (Lancado=0)"
        con.Open()
        cmd.CommandText = strSql
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read
                strSql_ = "Select * FROM tblPendenciasLoja WHERE (IDPendencia=" & dr.Item("IDPendencia") & ")"

                strSql = "INSERT tblPendencias (IDLoja,IDFechamento,IDCliente,IDVendaRet,IDFormaPagto,Data,Descricao,Valor,Saldo,IDVendaRetPagto,Lancado) VALUES ("
                strSql += to_sql(IDLoja) & ", "
                strSql += to_sql(NuloInteger(PegaValorCampo("IDFechamento", strSql_, strCon))) & ", "
                strSql += to_sql(NuloInteger(PegaValorCampo("IDCliente", strSql_, strCon))) & ", "
                strSql += to_sql(NuloInteger(PegaValorCampo("IDVendaRet", strSql_, strCon))) & ", "
                strSql += to_sql(NuloInteger(PegaValorCampo("IDFormaPagto", strSql_, strCon))) & ", "
                strSql += to_sqlDATA(NuloString(PegaValorCampo("Data", strSql_, strCon)), "datahora", "R") & ", "
                strSql += to_sql(PegaValorCampo("Descricao", strSql_, strCon)) & ", "
                strSql += to_sql(Replace(NuloDecimal(PegaValorCampo("Valor", strSql_, strCon)), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(PegaValorCampo("Saldo", strSql_, strCon)), ",", ".")) & ", "
                strSql += to_sql(NuloInteger(PegaValorCampo("IDVendaRetPagto", strSql_, strCon))) & ", "
                strSql += "1)"
                ExecutaStrServidor(strSql)

                strSql = "UPDATE tblPendenciasLoja Set Lancado=1 WHERE (IDPendencia=" & dr.Item("IDPendencia") & ")"
                ExecutaStr(strSql)
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

    End Sub
    Private Sub IncluiVendas(IDFecGou As Integer, IDFecRet As Integer)

        Dim conGou As New SqlConnection(strCon)
        Dim IDVdaGou As Integer
        Dim IDCliGou As Integer
        Dim IDpend As Integer
        Dim IDCliIRIS As Integer = 0
        Dim Desc As String

        Dim cmdVda As SqlCommand = conGou.CreateCommand
        strSql = "Select * FROM tblVendas WHERE (IDFechamento=" & IDFecGou & ")"
        conGou.Open()
        cmdVda.CommandText = strSql
        Dim drVda As SqlDataReader
        drVda = cmdVda.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drVda.HasRows Then
            While drVda.Read
                IDCliIRIS = 0
                IDCliGou = NuloInteger(drVda.Item("IDCliente"))
                If IDCliGou <> 0 Then
                    ' Aqui atualiza dados do cliente no servidor ///////////////////////////////////////////////////////////////////////////////////////////////////////
                    'IDCliIRIS = AtualizaCliente(IDCliGou)
                End If

                IDVdaGou = drVda.Item("IDVenda")
                strSql = "INSERT tblRetVendas (IDLoja,IDFechamento,NumVenda,NumMesa,IDCliente,Cartao,DataVenda,TotalProdutos,TotalVenda,Dinheiro,D_A,Desconto,PercDesconto,Servico,Caixinha,QtdPessoas,FlagFechada,HoraAbertura,HoraFechamento,TipoLancto,ValorEstacionamento,Status,StatusVenda,PercServico,Caixa,Troco,Atendente,Excluido,ContraVale,TaxaEntrega,PreNota,IDVendaRet_Gou,IDFuncionarioAtendente,MotivoEstorno,IDSat,IDRuaEntrega,CepEntrega,NumeroEntrega,AreaEntrega,ComplementoEntrega,ReferenciaEntrega,NumVendaD,ComentProducao,ComentExpedicao,Entregador,HoraProducao,App) VALUES ("
                strSql += to_sql(IDLoja) & ", "
                strSql += to_sql(IDFecRet) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("NumVenda"))) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("NumMesa"))) & ", "
                strSql += to_sql(IDCliGou) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("Cartao"))) & ", "
                strSql += to_sqlDATA(NuloString(drVda.Item("DataVenda")), "datahora", "R") & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("TotalProdutos")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("TotalVenda")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("Dinheiro")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("D_A")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("Desconto")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("PercDesconto")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("Servico")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("Caixinha")), ",", ".")) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("QtdPessoas"))) & ", "
                strSql += to_sql(NuloBoolean(drVda.Item("FlagFechada"))) & ", "
                strSql += to_sqlDATA(NuloString(drVda.Item("HoraAbertura")), "datahora", "R") & ", "
                If Not IsDBNull(drVda.Item("HoraFechamento")) Then
                    strSql += to_sqlDATA(NuloString(drVda.Item("HoraFechamento")), "datahora", "R") & ", "
                Else
                    strSql += to_sqlDATA(Now, "datahora", "R") & ", "
                End If
                strSql += to_sql(NuloBoolean(drVda.Item("TipoLancto"))) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("ValorEstacionamento")), ",", ".")) & ", "
                strSql += to_sql(NuloString(drVda.Item("Status"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("StatusVenda"))) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("PercServico")), ",", ".")) & ", "
                strSql += to_sql(NuloString(drVda.Item("Caixa"))) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("Troco")), ",", ".")) & ", "
                strSql += to_sql(NuloString(drVda.Item("Atendente"))) & ", "
                strSql += to_sql(NuloBoolean(drVda.Item("Excluido"))) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("ContraVale")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(drVda.Item("TaxaEntrega")), ",", ".")) & ", "
                strSql += to_sql(NuloBoolean(drVda.Item("PreNota"))) & ", "
                strSql += to_sql(IDVdaGou) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("IDFuncionarioAtendente"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("MotivoEstorno"))) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("IDSat"))) & ", "
                strSql += to_sql(NuloInteger(drVda.Item("IDRuaEntrega"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("CepEntrega"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("NumeroEntrega"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("AreaEntrega"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("ComplementoEntrega"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("ReferenciaEntrega"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("NumVendaD"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("ComentProducao"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("ComentExpedicao"))) & ", "
                strSql += to_sql(NuloString(drVda.Item("Entregador"))) & ", "
                If NuloString(drVda.Item("HoraProducao")) = "" Then
                    strSql += "'',"
                Else
                    strSql += to_sqlDATA(NuloString(drVda.Item("HoraProducao")), "datahora", "R") & ","
                End If
                strSql += to_sql(NuloString(drVda.Item("App"))) & ")"
                ExecutaStrServidor(strSql)

                ' Acha IDVenda no Retaguarda  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IDVdaRet = PegaID("IDVendaRet", "tblRetVendas", "S")


                ' Atualiza/Verifica Pendencias  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                strSql = "SELECT IDPendencia, IDVendaRet,IDVendaRetPagto,Descricao FROM tblPendenciasLoja WHERE (IDVenda=" & IDVdaGou & ")"
                IDpend = NuloInteger(PegaValorCampo("IDPendencia", strSql, strCon))
                If IDpend <> 0 Then
                    ' MsgBox("OK")

                    System.Threading.Thread.Sleep(500)

                    Dim strSql_ As String
                    If NuloInteger(PegaValorCampo("IDVendaRetPagto", "SELECT IDPendencia, IDVendaRet, IDVendaRetPagto FROM tblPendenciasLoja WHERE (IDPendencia=" & IDpend & ")", strCon)) <> 0 Then

                        Desc = NuloString(PegaValorCampo("Descricao", "SELECT IDPendencia, Descricao FROM tblPendenciasLoja WHERE (IDPendencia=" & IDpend & ")", strCon))
                        Desc = Strings.Left(Desc, 40)

                        strSql = "UPDATE tblPendenciasLoja SET IDVendaRet=" & IDVdaRet & ", IDFechamento=" & IDFecRet & ", Lancado=1, Descricao='" & Desc & " (" & IDFecRet & ")' WHERE IDPendencia=" & IDpend
                        ExecutaStr(strSql)

                        strSql_ = "SELECT * FROM tblPendenciasLoja WHERE (IDPendencia=" & IDpend & ")"

                        strSql = "INSERT tblPendencias (IDLoja,IDFechamento,IDCliente,IDVendaRet,IDFormaPagto,Data,Descricao,Valor,Saldo,IDVendaRetPagto,Lancado) VALUES ("
                        strSql += to_sql(IDLoja) & ", "
                        strSql += to_sql(IDFecRet) & ", "
                        strSql += to_sql(NuloInteger(PegaValorCampo("IDCliente", strSql_, strCon))) & ", "
                        strSql += to_sql(IDVdaRet) & ", "
                        strSql += to_sql(NuloInteger(PegaValorCampo("IDFormaPagto", strSql_, strCon))) & ", "
                        strSql += to_sqlDATA(NuloString(PegaValorCampo("Data", strSql_, strCon)), "datahora", "R") & ", "
                        strSql += to_sql(Strings.Left(PegaValorCampo("Descricao", strSql_, strCon), 50)) & ", "
                        strSql += to_sql(Replace(NuloDecimal(PegaValorCampo("Valor", strSql_, strCon)), ",", ".")) & ", "
                        strSql += to_sql(Replace(NuloDecimal(PegaValorCampo("Saldo", strSql_, strCon)), ",", ".")) & ", "
                        strSql += to_sql(NuloInteger(PegaValorCampo("IDVendaRetPagto", strSql_, strCon))) & ", "
                        strSql += "1)"
                        ExecutaStrServidor(strSql)

                    Else
                        Desc = NuloString(PegaValorCampo("Descricao", strSql, strCon))

                        'strSql = "Select IDVendaRet, NumVenda "
                        'strSql += "From tblRetVendas "
                        'strSql += "WHERE (IDVendaRet=" & IDVdaRet & ")"
                        'Desc += " (" & NuloString(PegaValorCampo("NumVenda", strSql, strConServer)) & ")"

                        strSql = "UPDATE tblPendenciasLoja SET IDVendaRet=" & IDVdaRet & ", IDFechamento=" & IDFecRet & ", Lancado=1, Descricao='" & Desc & "' WHERE IDPendencia=" & IDpend
                        ExecutaStr(strSql)

                        strSql_ = "SELECT * FROM tblPendenciasLoja WHERE (IDPendencia=" & IDpend & ")"

                        strSql = "INSERT tblPendencias (IDLoja,IDFechamento,IDCliente,IDVendaRet,IDFormaPagto,Data,Descricao,Valor,Saldo,IDVendaRetPagto,Lancado) VALUES ("
                        strSql += to_sql(IDLoja) & ", "
                        strSql += to_sql(IDFecRet) & ", "
                        strSql += to_sql(NuloInteger(PegaValorCampo("IDCliente", strSql_, strCon))) & ", "
                        strSql += to_sql(IDVdaRet) & ", "
                        strSql += to_sql(NuloInteger(PegaValorCampo("IDFormaPagto", strSql_, strCon))) & ", "
                        strSql += to_sqlDATA(NuloString(PegaValorCampo("Data", strSql_, strCon)), "datahora", "R") & ", "
                        strSql += to_sql(Strings.Left(PegaValorCampo("Descricao", strSql_, strCon), 50)) & ", "
                        strSql += to_sql(Replace(NuloDecimal(PegaValorCampo("Valor", strSql_, strCon)), ",", ".")) & ", "
                        strSql += to_sql(Replace(NuloDecimal(PegaValorCampo("Saldo", strSql_, strCon)), ",", ".")) & ", "
                        strSql += to_sql(NuloInteger(PegaValorCampo("IDVendaRetPagto", strSql_, strCon))) & ", "
                        strSql += "1)"
                        ExecutaStrServidor(strSql)

                    End If
                End If

                ' Envia Produtos da Venda para Retaguarda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IncluiVendaMovto(IDVdaGou)

                ' Envia Pagamento da Venda para Retaguarda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IncluiVendaPagto(IDVdaGou, IDVdaRet)

                ' Envia Vendas SAT para Retaguarda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                IncluiVendaSAT(IDVdaGou, IDVdaRet)

                ' Envia Vales para Retaguarda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'IncluiVales(IDVdaGou)

            End While

            'MsgBox("OK")

        End If
        cmdVda.Dispose()
        drVda.Close()
        conGou.Dispose()
        conGou.Close()

        'Fechamento_Conciliacao(IDFecGou)

    End Sub
    Private Sub ConfirmaCaixa(IDfecGou As Integer)


        frmSplash.lbAndamento.Text = "Verificando movimento..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 5
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)

        Dim Retorno As String
        strSql = "Select * from tblFechamentos WHERE (IDFechamentoLoja=" & IDfecGou & ") And (IDLoja=" & IDLoja & ") And (DiaMovimento=" & to_sqlDATA(tbDiaMovto.Text, "datahora", "R") & ")"
        Retorno = PegaValorCampo("IDFechamento", strSql, strConServer)
        If Retorno = "ERRO" Then
            frmSplash.Dispose()
            frmSplash.Close()
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "ATENÇÃO: Erro ao conectar com IRIS Gestão, não será possivel encerrar o caixa"
            frm1.lbMensagem.ForeColor = Color.Blue
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            Exit Sub
        End If
        IDfecRet = NuloInteger(Retorno)

        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select * from tblFechamentos_Local WHERE IDFechamento=" & IDfecGou
        cmd.CommandText = strSql
        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            If IDfecRet = 0 Then
                strSql = "INSERT tblFechamentos (IDLoja,Caixa,DiaMovimento,DataAbertura,DataFechamento,Turno,Confirmado,FundoCaixa,SaldoCaixa,IDFechamentoLoja) VALUES ("
                strSql += to_sql(IDLoja) & ", "
                strSql += to_sql(dr.Item("Caixa")) & ", "
                strSql += to_sqlDATA(dr.Item("DiaMovimento"), "datahora", "R") & ", "
                strSql += to_sqlDATA(dr.Item("DataAbertura"), "datahora", "R") & ", "
                strSql += to_sqlDATA(Now, "datahora", "R") & ", "
                strSql += to_sql(dr.Item("Turno")) & ", "
                strSql += "1, "
                If Not IsDBNull(dr.Item("FundoCaixa")) Then
                    strSql += to_sql(Replace(dr.Item("FundoCaixa"), ",", ".")) & ", "
                Else
                    strSql += "0, "
                End If
                If Not IsDBNull(dr.Item("SaldoCaixa")) Then
                    strSql += to_sql(Replace(dr.Item("SaldoCaixa"), ",", ".")) & ", "
                Else
                    strSql += "0, "
                End If
                strSql += to_sql(IDfecGou) & ") "
                ExecutaStrServidor(strSql)

                IDfecRet = NuloInteger(PegaID("IDFechamento", "tblFechamentos", "S"))
            Else
                strSql = "UPDATE tblFechamentos SET "
                strSql += "Caixa='" & dr.Item("Caixa") & "', "
                strSql += "DataFechamento='" & to_sqlDATA(Now, "datahora", "R") & " "
                strSql += "WHERE (IDFechamento=" & IDfecRet & ")"
                LimpaVendasServidor(IDfecRet)
            End If

            TextoEmail = "Em anexo arquivos referete ao " & vbCrLf
            TextoEmail &= "movimento de vendas" & vbCrLf
            TextoEmail &= " " & vbCrLf
            TextoEmail &= "LOJA         " & UCase(NomeLoja) & vbCrLf
            TextoEmail &= "Dia          " & NuloString(dr.Item("DiaMovimento")) & vbCrLf
            TextoEmail &= "Abertura     " & NuloString(dr.Item("DataAbertura")) & vbCrLf
            TextoEmail &= "Encerramento " & Now & vbCrLf
            TextoEmail &= "Turno        " & NuloString(dr.Item("Turno")) & vbCrLf
            TextoEmail &= "Responsavel  " & NuloString(dr.Item("Caixa")) & vbCrLf

            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

            If ModulosIRIS = "D" And FechamentoDeliveryCamelo = True Then
                strSql = "UPDATE tblDeliveryEspecial SET IDFechamento = " & IDfecRet & " WHERE IDFechamentoLocal = " & IDfecGou
                ExecutaStrServidor(strSql)
            End If
        End If

        frmSplash.lbAndamento.Text = "Incluindo vendas..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 10
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)
        IncluiVendas(IDfecGou, IDfecRet)


        frmSplash.lbAndamento.Text = "Baixando itens nos estoques..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 45
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)
        BaixaEstoque(IDfecRet)


        frmSplash.lbAndamento.Text = "Conciliando os pagamentos..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 60
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)
        Fechamento_Conciliacao(IDfecGou)


        frmSplash.lbAndamento.Text = "Atualizando clientes..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 65
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)
        AtualizaClientes()


        frmSplash.lbAndamento.Text = "Imprimindo os relatórios..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 70
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(200)

        ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")

        If ModulosIRIS = "D" And FechamentoDeliveryCamelo = True Then
            CriaRelatFinanceiroDelivery(IDfecRet)
        Else
            CriaRelatFinanceiro(IDfecRet)
        End If

        If cbxFinanceiro.Checked = True Then
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\financeiro.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        If cbxProdutos.Checked = True Then
            CriaRelatProdutos(IDfecRet)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\produtos.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        If cbxServico_Caixinha.Checked = True Then
            CriaRelatServicoCaixinha(IDfecRet)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\servico.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        If chkEstornos_Transferencias.Checked = True Then
            CriaRelatEstornosTransferencias(IDfecRet)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\estorno.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        strSql = "Select IDVenda, IDFechamento, StatusVenda, Excluido "
        strSql += "From tblRetVendas "
        strSql += "Where (StatusVenda = 'D') AND (IDFechamento=" & IDfecRet & ") AND (Excluido=0)"
        If NuloInteger(PegaValorCampo("IDVenda", strSql, strConServer)) > 0 Then
            DeliveryRelatorio = True
            CriaRelatDelivery(IDfecRet)
        Else
            DeliveryRelatorio = False
        End If

        ' Email  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If EnviaEmailFechamento = True Then
            frmSplash.lbAndamento.Text = "Enviando eMails..."
            frmSplash.lbAndamento.Refresh()
            frmSplash.ProgressBar.Value = 90
            frmSplash.ProgressBar.Refresh()
            frmSplash.Refresh()
            EnviaEmail()
        End If


        ' atualiza Ruas ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        frmSplash.lbAndamento.Text = "Atualizando endereços..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 93
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)
        AtualizaRuas()


        ' Lança pendencias não vinculadas ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        frmSplash.lbAndamento.Text = "Atualizando pendências..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 95
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)
        LancamentoPendenciasNaoVinculadas()


        ' Limpando vendas/registros ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        frmSplash.lbAndamento.Text = "Limpando registros..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 98
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)

        ' Apaga vendas banco local ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        LimpaBancoLocal(IDfecGou)

        strSql = "Delete From tblFechamentos_Local WHERE IDFechamento=" & IDfecGou
        ExecutaStr(strSql)

        strSql = "Delete From tblFechamentosDescricao_Local WHERE IDFechamento=" & IDfecGou
        ExecutaStr(strSql)

        ' Limpa contator de impressão (categorias) ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "SELECT IDFechamento, Confirmado FROM tblFechamentos_Local WHERE Confirmado=0"
        If NuloInteger(PegaValorCampo("IDFechamento", strSql, strCon)) = 0 Then

            ZeraContadorImpressao()

            strSql = "UPDATE tblCategorias_Local SET Pedidos=0"
            ExecutaStr(strSql)

            strSql = "TRUNCATE table tblAppVendas"
            ExecutaStr(strSql)

            strSql = "TRUNCATE table tblAppVendasMovto"
            ExecutaStr(strSql)

            strSql = "TRUNCATE table tblAppVendasCombo"
            ExecutaStr(strSql)

            strSql = "TRUNCATE table tblAppVendasComent"
            ExecutaStr(strSql)

            strSql = "TRUNCATE table tblAppVendasPagto"
            ExecutaStr(strSql)


            '' Vendas local
            ApagaVendas()
            VerificaMesas()
        End If


        frmSplash.lbAndamento.Text = "Atualizando movimento..."
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 99
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)

        strSql = "UPDATE tblFechamentos_Local SET "
        strSql += "Confirmado=1, "
        strSql += "Transferido=1, "
        strSql += "DataFechamento=" & to_sqlDATA(Now, "datahora", "L") & " "
        strSql += "WHERE (IDFechamento=" & IDfecGou & ")"
        ExecutaStr(strSql)


        frmSplash.lbAndamento.Text = ""
        frmSplash.lbAndamento.Refresh()
        frmSplash.ProgressBar.Value = 100
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)

        frmSplash.Dispose()
        frmSplash.Close()

        Me.Close()
        Me.Dispose()



    End Sub
    Private Sub DadosRelatProdutos(IDfec As Integer)

        ExecutaStrServidor("TRUNCATE TABLE tblRelatorioProdutos")

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim conexao As String = strConServer

        con.ConnectionString = conexao
        Dim cmd As SqlCommand = con.CreateCommand

        'strSql = "Select tblRetVendas.Excluido, tblRetVendasMovto.Excluido As Expr1, Case When tblRetVendasCombo.Produto Is NULL Then tblRetVendasMovto.Produto Else tblRetVendasCombo.Produto End As Prod, Case WHEN tblRetVendasCombo.Produto Is NULL THEN SUM(tblRetVendasMovto.Qtd) ELSE SUM(tblRetVendasCombo.Qtd) END AS Qtde, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN SUM(tblRetVendasMovto.Venda * tblRetVendasMovto.Qtd) ELSE SUM(tblRetVendasCombo.Venda * tblRetVendasCombo.Qtd) END AS Valor, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN tblRetVendasMovto.Grupo ELSE tblRetVendasCombo.Grupo END AS Grup, tblRetVendasCombo.Produto, tblRetVendas.IDLoja, tblRetVendasMovto.Venda, tblRetVendasCombo.Venda AS VendaCombo "
        'strSql += "From tblRetVendasCombo RIGHT OUTER Join tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet ON tblRetVendasCombo.IDVendaRetMovto = tblRetVendasMovto.IDVendaRetMovto LEFT OUTER Join tblFechamentos On tblRetVendas.IDfechamento = tblFechamentos.IDFechamento "
        'strSql += "Group By tblRetVendasCombo.Produto, tblRetVendas.IDLoja, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN tblRetVendasMovto.Produto ELSE tblRetVendasCombo.Produto END, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN tblRetVendasMovto.Grupo ELSE tblRetVendasCombo.Grupo END, tblRetVendasMovto.Excluido, tblRetVendas.Excluido, tblRetVendas.FlagFechada, tblRetVendas.IDfechamento, tblRetVendasMovto.Venda, tblRetVendasCombo.Venda "
        'strSql += "HAVING(tblRetVendasMovto.Excluido = 0) And (tblRetVendas.Excluido = 0) And (tblRetVendas.FlagFechada = 1) And (tblRetVendas.IDfechamento = " & IDfec & ") "
        'strSql += "ORDER BY Grup, Valor DESC"

        'strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.Excluido, tblRetVendasMovto.Excluido As Expr1, Case When tblRetVendasCombo.Produto Is NULL Then tblRetVendasMovto.Produto Else tblRetVendasCombo.Produto End As Prod, Case WHEN tblRetVendasCombo.Produto Is NULL THEN SUM(tblRetVendasMovto.Qtd) ELSE SUM(tblRetVendasCombo.Qtd) END AS Qtde, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN SUM(tblRetVendasMovto.Venda * tblRetVendasMovto.Qtd) ELSE SUM(tblRetVendasCombo.Venda * tblRetVendasCombo.Qtd) END AS Valor, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN tblRetVendasMovto.Grupo ELSE tblRetVendasCombo.Grupo END AS Grup, tblRetVendasCombo.Produto, tblRetVendasMovto.Venda, tblRetVendasCombo.Venda AS VendaCombo, tblFechamentos.DiaMovimento "
        'strSql += "From tblRetVendasCombo RIGHT OUTER Join tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet ON tblRetVendasCombo.IDVendaRetMovto = tblRetVendasMovto.IDVendaRetMovto LEFT OUTER Join tblFechamentos On tblRetVendas.IDfechamento = tblFechamentos.IDFechamento "
        'strSql += "Group By tblRetVendas.IDfechamento, tblRetVendasCombo.Produto, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN tblRetVendasMovto.Produto ELSE tblRetVendasCombo.Produto END, CASE WHEN tblRetVendasCombo.Produto Is NULL THEN tblRetVendasMovto.Grupo ELSE tblRetVendasCombo.Grupo END, tblRetVendasMovto.Excluido, tblRetVendas.Excluido, tblRetVendas.FlagFechada, tblRetVendas.IDfechamento, tblRetVendasMovto.Venda, tblRetVendasCombo.Venda, tblFechamentos.DiaMovimento "
        'strSql += "HAVING(tblRetVendasMovto.Excluido = 0) And (tblRetVendas.Excluido = 0) And (tblRetVendas.FlagFechada = 1) And (tblRetVendas.IDfechamento = " & IDfec & ") AND (NOT (tblRetVendasCombo.Produto IS NULL)) "
        'strSql += "ORDER BY Grup, Valor DESC"

        strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.Excluido, tblRetVendasMovto.Excluido As Expr1, tblRetVendasCombo.Produto As Prod, SUM(tblRetVendasCombo.Qtd) As Qtde, SUM(tblRetVendasCombo.Venda * tblRetVendasCombo.Qtd) As Valor, tblRetVendasCombo.Grupo AS Grup, tblRetVendasCombo.Produto, tblRetVendasMovto.Venda, tblFechamentos.DiaMovimento, tblRetVendasMovto.EPizza "
        strSql += "From tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet LEFT OUTER Join tblRetVendasCombo On tblRetVendasMovto.IDVendaRetMovto = tblRetVendasCombo.IDVendaRetMovto LEFT OUTER Join tblFechamentos On tblRetVendas.IDfechamento = tblFechamentos.IDFechamento "
        strSql += "Group By tblRetVendas.IDfechamento, tblRetVendasCombo.Produto, tblRetVendasCombo.Grupo, tblRetVendasMovto.Excluido, tblRetVendas.Excluido, tblRetVendas.FlagFechada, tblRetVendasMovto.Venda, tblFechamentos.DiaMovimento, tblRetVendasMovto.EPizza "
        strSql += "HAVING(tblRetVendasMovto.Excluido = 0) And (tblRetVendas.Excluido = 0) And (tblRetVendas.FlagFechada = 1) And (tblRetVendas.IDfechamento = " & IDfec & ") AND (NOT (tblRetVendasCombo.Produto IS NULL)) AND (tblRetVendasMovto.EPizza = 1) "
        strSql += "ORDER BY tblRetVendasCombo.Grupo, SUM(tblRetVendasCombo.Venda * tblRetVendasCombo.Qtd) DESC"

        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Venda As Decimal = 0
        If dr.HasRows Then
            While dr.Read
                'If NuloString(dr.Item("Produto")) = "" Then
                Venda = NuloDecimal(dr.Item("Venda"))
                'Else
                'Venda = NuloDecimal(dr.Item("VendaCombo"))
                'End If

                strSql = "INSERT tblRelatorioProdutos "
                strSql += "(Grupo, Produto, Qtde, Venda, Valor) VALUES ("
                strSql += to_sql(NuloString(dr.Item("Grup"))) & ", "
                strSql += to_sql(NuloString(dr.Item("Prod"))) & ", "
                strSql += to_sql(Replace(NuloDecimal(dr.Item("Qtde")), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloString(Venda), ",", ".")) & ", "
                strSql += to_sql(Replace(NuloDecimal(dr.Item("Valor")), ",", ".")) & ")"
                ExecutaStrServidor(strSql)

            End While
        End If

        'strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.Excluido, tblRetVendasMovto.Excluido As Expr1, tblRetVendasMovto.Produto As Prod, tblRetVendasMovto.Qtd As Qtde, tblRetVendasMovto.Qtd * tblRetVendasMovto.Venda As Valor, tblRetVendasMovto.Grupo AS Grup, tblRetVendasMovto.Venda, tblFechamentos.DiaMovimento, tblRetVendasCombo.IDProduto "
        'strSql += "From tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet LEFT OUTER Join tblRetVendasCombo On tblRetVendasMovto.IDVendaRetMovto = tblRetVendasCombo.IDVendaRetMovto LEFT OUTER Join tblFechamentos On tblRetVendas.IDfechamento = tblFechamentos.IDFechamento "
        'strSql += "Group By tblRetVendas.IDfechamento, tblRetVendasMovto.Produto, tblRetVendasMovto.Grupo, tblRetVendasMovto.Excluido, tblRetVendas.Excluido, tblRetVendas.FlagFechada, tblRetVendas.IDfechamento, tblRetVendasMovto.Venda, tblFechamentos.DiaMovimento, tblRetVendasMovto.Qtd, tblRetVendasMovto.Qtd * tblRetVendasMovto.Venda, tblRetVendasCombo.IDProduto "
        'strSql += "HAVING(tblRetVendasMovto.Excluido = 0) And (tblRetVendas.Excluido = 0) And (tblRetVendas.FlagFechada = 1) And (tblRetVendas.IDfechamento = " & IDfec & ") AND (tblRetVendasCombo.IDProduto Is NULL) "
        'strSql += "ORDER BY tblRetVendasMovto.Grupo, tblRetVendasMovto.Qtd * tblRetVendasMovto.Venda DESC"

        strSql = "Select tblRetVendas.IDfechamento, tblRetVendasMovto.IDProduto, tblRetVendasMovto.Produto As Prod, SUM(tblRetVendasMovto.Qtd) As Qtde, SUM(tblRetVendasMovto.Qtd * tblRetVendasMovto.Venda) As Valor, tblRetVendasMovto.Grupo As Grup, tblRetVendasMovto.Venda, tblFechamentos.DiaMovimento, tblRetVendasMovto.Excluido, tblRetVendas.Excluido As Expr1, tblRetVendasMovto.EPizza "
        strSql += "From tblRetVendasMovto INNER Join tblRetVendas On tblRetVendasMovto.IDVendaRet = tblRetVendas.IDVendaRet INNER Join tblFechamentos On tblRetVendas.IDfechamento = tblFechamentos.IDFechamento "
        strSql += "Group By tblRetVendas.IDfechamento, tblRetVendasMovto.IDProduto, tblRetVendasMovto.Produto, tblRetVendasMovto.Grupo, tblRetVendas.FlagFechada, tblRetVendasMovto.Venda, tblFechamentos.DiaMovimento, tblRetVendasMovto.Excluido, tblRetVendas.Excluido, tblRetVendasMovto.EPizza "
        strSql += "HAVING(tblRetVendasMovto.Excluido = 0) And (tblRetVendas.Excluido = 0) And (tblRetVendas.FlagFechada = 1) And (tblRetVendas.IDfechamento = " & IDfec & ") AND (tblRetVendasMovto.EPizza = 0) "
        strSql += "ORDER BY Grup, SUM(tblRetVendasMovto.Qtd * tblRetVendasMovto.Venda) DESC"

        Dim dap = New SqlDataAdapter(strSql, conexao)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        Dim Pro As String
        Dim Gru As String
        Dim Vlr As Decimal
        Dim Qtde As Decimal
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            Pro = NuloString(ds.Tables("Vendas").Rows(i).Item("Prod"))
            Gru = NuloString(ds.Tables("Vendas").Rows(i).Item("Grup"))
            Vlr = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Valor"))
            Qtde = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
            Venda = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))

            strSql = "INSERT tblRelatorioProdutos "
            strSql += "(Grupo, Produto, Qtde, Venda, Valor) VALUES ("
            strSql += to_sql(Gru) & ", "
            strSql += to_sql(Pro) & ", "
            strSql += to_sql(Replace(NuloDecimal(Qtde), ",", ".")) & ", "
            strSql += to_sql(Replace(NuloDecimal(Venda), ",", ".")) & ", "
            strSql += to_sql(Replace(NuloDecimal(Vlr), ",", ".")) & ")"
            ExecutaStr(strSql)
        Next

        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

    End Sub
    Private Sub CriaRelatProdutos(IDfec As Integer)

        DadosRelatProdutos(IDfec)

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim conexao As String = strConServer

        con.ConnectionString = conexao
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select Grupo, Produto, SUM(Qtde) As Qtde, Venda, SUM(Valor) As Valor "
        strSql += "From tblRelatorioProdutos "
        strSql += "Group By Grupo, Produto, Venda "
        strSql += "Order By Grupo, SUM(Valor) DESC"

        Try
            FileClose(lngFile)
            FileOpen(lngFile, Application.StartupPath & "\Impressao\produtos.txt", OpenMode.Output)

1:
            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then

                strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
                strSql += "From tblFechamentos "
                strSql += "Where (IDFechamento = " & IDfec & ")"

                texto = ""
                PrintLine(lngFile, "FECHAMENTO CAIXA")
                PrintLine(lngFile, "(Produtos)")
                PrintLine(lngFile, "----------------------------------------")
                PrintLine(lngFile, "Periodo    : " & NuloString(PegaValorCampo("Turno", strSql, conexao)))
                PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataAbertura", strSql, conexao)))
                If ckbMovtoAnterior.Checked = True Then
                    PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataFechamento", strSql, conexao)))
                End If

                PrintLine(lngFile, "Responsavel: " & NuloString(PegaValorCampo("Caixa", strSql, conexao)))
                PrintLine(lngFile, "---------------------------->> " & IDfec)
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")

                Dim Grupo As String
                Dim vlrtotGrupo As Decimal = 0
                Dim vlrtotGeral As Decimal = 0
                Dim qtdtotGrupo As Decimal = 0
                Dim qtdtotGeral As Decimal = 0
                Dim NovoGrupo As Boolean = True

                PrintLine(lngFile, "Produtos          Qtde     Unit    Valor ")
                PrintLine(lngFile, "=========================================")
                While dr.Read
                    If NovoGrupo = True Or Grupo <> dr.Item("Grupo") Then
                        If vlrtotGrupo <> 0 And qtdtotGrupo <> 0 Then
                            PrintLine(lngFile, "-----------------------------------------")
                            texto = "Total Grupo"
                            texto += Space(13 - Len(Format(qtdtotGrupo, "#0.000"))) & Format(qtdtotGrupo, "#0.000")
                            texto += Space(18 - Len(Format(vlrtotGrupo, "#0.00"))) & Format(vlrtotGrupo, "#0.00")
                            PrintLine(lngFile, texto)
                            PrintLine(lngFile, " ")
                        End If

                        PrintLine(lngFile, " ")
                        PrintLine(lngFile, dr.Item("Grupo"))
                        PrintLine(lngFile, "-----------------------------------------")
                        NovoGrupo = False
                        Grupo = dr.Item("Grupo")
                        qtdtotGrupo = 0
                        vlrtotGrupo = 0
                    End If

                    If Grupo = dr.Item("Grupo") Then
                        texto = Strings.Left(dr.Item("Produto"), 13) & Space(17 - Len(Strings.Left(dr.Item("Produto"), 13)))
                        texto += Space(7 - Len(NuloDecimal(dr.Item("Qtde")).ToString("#0.000"))) & NuloDecimal(dr.Item("Qtde")).ToString("#0.000")
                        texto += Space(8 - Len(NuloDecimal(dr.Item("Venda")).ToString("#0.00"))) & NuloDecimal(dr.Item("Venda")).ToString("#0.00")
                        texto += Space(10 - Len(NuloDecimal(dr.Item("Valor")).ToString("#0.00"))) & NuloDecimal(dr.Item("Valor")).ToString("#0.00")
                        PrintLine(lngFile, texto)

                        vlrtotGeral += dr.Item("Valor")
                        vlrtotGrupo += dr.Item("Valor")
                        qtdtotGeral += dr.Item("Qtde")
                        qtdtotGrupo += dr.Item("Qtde")
                    Else
                        NovoGrupo = True
                    End If


                End While
                PrintLine(lngFile, "-----------------------------------------")
                texto = "Total Grupo"
                texto += Space(13 - Len(Format(qtdtotGrupo, "#0.000"))) & Format(qtdtotGrupo, "#0.000")
                texto += Space(18 - Len(Format(vlrtotGrupo, "#0.00"))) & Format(vlrtotGrupo, "#0.00")
                PrintLine(lngFile, texto)
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, "-----------------------------------------")
                texto = "Total Geral"
                texto += Space(13 - Len(Format(qtdtotGeral, "#0.000"))) & Format(qtdtotGeral, "#0.000")
                texto += Space(18 - Len(Format(vlrtotGeral, "#0.00"))) & Format(vlrtotGeral, "#0.00")
                PrintLine(lngFile, texto)
                PrintLine(lngFile, "=========================================")
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

            FileClose(lngFile)




        Catch ex As Exception
            If InStr(1, ex.Message, "localizar") > 0 Then
                Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\financeiro.txt")
                fs.Close()
                GoTo 1
            Else
                MsgBox(ex.Message)
            End If

        End Try


    End Sub
    Private Sub CriaRelatFinanceiroDelivery(IDfec As Integer)
        Dim con As New SqlConnection()
        Dim conM As New SqlConnection()

        Dim dr As SqlDataReader
        Dim drM As SqlDataReader

        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Cabec As Boolean = True

        Dim vlrReal As Decimal
        Dim vlrSistema As Decimal
        Dim vlrDif As Decimal = 0
        Dim TotalReal As Decimal = 0
        Dim TotalSistema As Decimal = 0
        Dim TotalDif As Decimal = 0
        Dim TotalVirtual As Decimal = 0
        Dim TotalLiquido As Decimal = 0
        Dim FundoCaixa As Decimal = 0
        Dim conexao As String = strConServer
        Dim Qtde_Vdas As Integer = 0

        con.ConnectionString = conexao
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblFormaPagtos.IDFormaPagto, tblFormaPagtos.Descricao As DescricaoPagto, tblFormaPagtosLojas.IDLoja, tblFormaPagtosLojas.Tipo "
        strSql += "From tblFormaPagtos INNER Join tblFormaPagtosLojas On tblFormaPagtos.IDFormaPagto = tblFormaPagtosLojas.IDFormaPagto "
        strSql += "Where (tblFormaPagtosLojas.IDLoja = " & IDLoja & ") "
        strSql += "Order By DescricaoPagto"

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\financeiro.txt", OpenMode.Output)

1:

        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        strSql = "Select IDFechamento, SUM(ValorBruto) As VlrTotal "
        strSql += "From tblFechamentosDescricao "
        strSql += "Where (Tipo = 'LD' OR Tipo = 'LR') "
        strSql += "GROUP BY IDFechamento "
        strSql += "HAVING(IDFechamento = " & IDfec & ")"
        Dim vlrMC_Total As Decimal = NuloDecimal(PegaValorCampo("VlrTotal", strSql, conexao))

        If dr.HasRows Then
            strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
            strSql += "From tblFechamentos "
            strSql += "Where (IDFechamento = " & IDfec & ")"

            texto = ""
            PrintLine(lngFile, "FECHAMENTO CAIXA")
            PrintLine(lngFile, "(Financeiro)")
            PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, "Periodo    : " & NuloString(PegaValorCampo("Turno", strSql, conexao)))
            PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataAbertura", strSql, conexao)))
            PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataFechamento", strSql, conexao)))
            PrintLine(lngFile, "Responsavel: " & NuloString(PegaValorCampo("Caixa", strSql, conexao)))
            PrintLine(lngFile, "---------------------------->> " & IDfec)
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "               Sistema     Real    Dif.")
            PrintLine(lngFile, "========================================")


            strSql = "Select IDFechamento, FundoCaixa "
            strSql += "From tblFechamentos "
            strSql += "Where (IDFechamento = " & IDfec & ")"
            FundoCaixa = NuloDecimal(PegaValorCampo("FundoCaixa", strSql, conexao))


            While (dr.Read())
                If dr.Item("Tipo") = "R" Then
                    texto = Strings.Left(dr.Item("DescricaoPagto"), 14)
                Else
                    texto = "* " & Strings.Left(dr.Item("DescricaoPagto"), 14)
                End If

                strSql = "Select tblRetVendasPagto.IDFormaPagto, SUM(tblRetVendasPagto.ValorPago) As Soma, tblRetVendas.IDfechamento "
                strSql += "From tblRetVendasPagto INNER Join tblRetVendas On tblRetVendasPagto.IDVendaRet = tblRetVendas.IDVendaRet "
                strSql += "Group By tblRetVendasPagto.IDFormaPagto, tblRetVendas.IDfechamento "
                strSql += "HAVING(tblRetVendas.IDfechamento = " & IDfec & ") And (tblRetVendasPagto.IDFormaPagto = " & dr.Item("IDFormaPagto") & ")"
                vlrSistema = NuloDecimal(PegaValorCampo("Soma", strSql, conexao))
                texto += Space(23 - Len(texto) - Len(NuloDecimal(vlrSistema).ToString("#0.00"))) & NuloDecimal(vlrSistema).ToString("#0.00")



                strSql = "Select IDFechamento, IDFormaPagto, SUM(ValorBruto) As ValorBruto "
                strSql += "From tblFechamentosDescricao "
                strSql += "Group By IDFechamento, IDFormaPagto "
                strSql += "HAVING(IDFechamento = " & IDfec & ") And (IDFormaPagto = " & dr.Item("IDFormaPagto") & ")"
                vlrReal = NuloDecimal(PegaValorCampo("ValorBruto", strSql, conexao))
                If UCase(texto) <> "DINHEIRO" Then
                    texto += Space(9 - Len(vlrReal.ToString("#0.00"))) & vlrReal.ToString("#0.00")
                Else
                    vlrReal += vlrMC_Total
                    If IncluiFundoCaixa = True Then
                        vlrReal += FundoCaixa
                    End If
                    texto += Space(9 - Len(vlrReal.ToString("#0.00"))) & vlrReal.ToString("#0.00")
                End If


                vlrDif = vlrReal - vlrSistema
                texto += Space(10 - Len(vlrDif.ToString("#0.00"))) & vlrDif.ToString("#0.00")

                PrintLine(lngFile, texto)

                TotalSistema += vlrSistema
                If dr.Item("Tipo") = "V" Then
                    TotalVirtual += vlrSistema
                End If

                TotalReal += vlrReal
                TotalDif += vlrDif
            End While

            PrintLine(lngFile, "------------------------------------------")
            texto = "TOTAL "
            texto &= Space(23 - Len(texto) - Len(TotalSistema.ToString("#0.00"))) & TotalSistema.ToString("#0.00")
            texto &= Space(9 - Len(TotalReal.ToString("#0.00"))) & TotalReal.ToString("#0.00")
            texto &= Space(10 - Len(TotalDif.ToString("#0.00"))) & TotalDif.ToString("#0.00")
            PrintLine(lngFile, texto)

            '' Verifica Virtual //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'If TotalVirtual <> 0 Then

            'texto = "* Virtual "
            'texto &= Space(23 - Len(texto) - Len(TotalVirtual.ToString("#0.00"))) & TotalVirtual.ToString("#0.00")
            'PrintLine(lngFile, texto)

            'PrintLine(lngFile, "------------------------------------------")
            'texto = "Liquido "
            'TotalLiquido = TotalSistema - TotalVirtual
            'texto &= Space(23 - Len(texto) - Len(TotalLiquido.ToString("#0.00"))) & TotalLiquido.ToString("#0.00")
            'PrintLine(lngFile, texto)
            'End If

            Dim Caixinha As Decimal = 0
            Dim Desconto As Decimal = 0
            Dim Liquido As Decimal = 0
            strSql = "Select IDFechamento, SUM(Caixinha) As Caixinha "
            strSql += "From tblRetVendas "
            strSql += "Group By IDFechamento "

            strSql = "Select IDFechamento, SUM(Caixinha) As Caixinha, SUM(Desconto) As Desconto "
            strSql += "From tblRetVendas "
            strSql += "Group By IDFechamento "
            strSql += "HAVING (IDFechamento = " & IDfec & ")"
            Caixinha = NuloDecimal(PegaValorCampo("Caixinha", strSql, conexao))
            Desconto = NuloDecimal(PegaValorCampo("Desconto", strSql, conexao))

            texto = "Caixinha(-) "
            texto &= Space(23 - Len(texto) - Len(Caixinha.ToString("#0.00"))) & Caixinha.ToString("#0.00")
            PrintLine(lngFile, texto)

            texto = "Desconto(+) "
            texto &= Space(23 - Len(texto) - Len(Desconto.ToString("#0.00"))) & Desconto.ToString("#0.00")
            PrintLine(lngFile, texto)

            PrintLine(lngFile, "           -------------")

            Liquido = TotalSistema - Caixinha + Desconto
            texto = "Liquido "
            texto &= Space(23 - Len(texto) - Len(Liquido.ToString("#0.00"))) & Liquido.ToString("#0.00")
            PrintLine(lngFile, texto)

            PrintLine(lngFile, "==========================================")

            Dim vlrTmp As Decimal = 0
            strSql = "SELECT IDfechamento, count(IDVendaRet) AS VlrTxEnt, Excluido "
            strSql += "FROM tblRetVendas "
            strSql += "GROUP BY IDfechamento, Excluido "
            strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"
            vlrTmp = NuloDecimal(PegaValorCampo("VlrTxEnt", strSql, conexao))
            Qtde_Vdas = vlrTmp
            texto = "Quantidade de vendas : "
            texto += Space(19 - Len(vlrTmp.ToString("#0"))) & vlrTmp.ToString("#0")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")

            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

        End If

        dr.Close()
        con.Dispose()
        con.Close()




        conM.ConnectionString = conexao
        Dim cmdM As SqlCommand = conM.CreateCommand
        Dim Func As String
        Dim Diaria As Decimal
        Dim Caixi As Decimal
        Dim FA As Decimal
        Dim OnLine As Decimal
        Dim Total As Decimal
        Dim TotalDiaria As Decimal = 0
        Dim TotalCaixi As Decimal = 0
        Dim TotalFA As Decimal = 0
        Dim TotalOnLine As Decimal = 0
        Dim TotalGeral As Decimal = 0

        strSql = "Select IDFechamento, CAST(Funcionario As INT) As Funcionario_, Caixinha, Diaria, ForaArea, OnLine "
        strSql += "From tblDeliveryEspecial "
        strSql += "Where (IDFechamento = " & IDfec & ") "
        strSql += "Order By CAST(Funcionario As INT)"

        cmdM.CommandText = strSql
        conM.Open()
        drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drM.HasRows Then
            PrintLine(lngFile, "                    Pagamento entregadores")
            PrintLine(lngFile, "Entr   Caixi Diaria    FA  OnLine    TOTAL")
            PrintLine(lngFile, "==========================================")
            While (drM.Read())
                Func = Strings.Left(drM.Item("Funcionario_"), 6)
                Diaria = NuloDecimal(drM.Item("Diaria"))
                TotalDiaria += Diaria
                Caixi = Format(NuloDecimal(drM.Item("Caixinha")), "#0.00")
                TotalCaixi += Caixi
                FA = NuloDecimal(drM.Item("ForaArea"))
                TotalFA += FA
                OnLine = NuloDecimal(drM.Item("OnLine"))
                TotalOnLine += OnLine
                Total = NuloDecimal(Diaria + Caixi + FA + OnLine)
                TotalGeral += Total

                texto = Func + Space(5 - Len(Func))
                texto += Space(7 - Len(Strings.Left(Caixi, 7))) + Strings.Left(Caixi, 7)
                texto += Space(7 - Len(Strings.Left(Diaria, 7))) + Strings.Left(Diaria, 7)
                texto += Space(7 - Len(Strings.Left(FA, 7))) + Strings.Left(FA, 7)
                texto += Space(7 - Len(Strings.Left(OnLine, 7))) + Strings.Left(OnLine, 7)
                texto += Space(9 - Len(Strings.Left(Total, 9))) + Strings.Left(Total, 9)
                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "==========================================")
            texto = Space(7 - Len(Strings.Left(TotalCaixi, 7))) + Strings.Left(Format(TotalCaixi, "#0.00"), 7)
            texto += Space(7 - Len(Strings.Left(TotalDiaria, 7))) + Strings.Left(Format(TotalDiaria, "#0.00"), 7)
            texto += Space(7 - Len(Strings.Left(TotalFA, 7))) + Strings.Left(Format(TotalFA, "#0.00"), 7)
            texto += Space(7 - Len(Strings.Left(TotalOnLine, 7))) + Strings.Left(Format(TotalOnLine, "#0.00"), 7)
            texto += Space(9 - Len(Strings.Left(TotalGeral, 9))) + Strings.Left(Format(TotalGeral, "#0.00"), 9)
            PrintLine(lngFile, "TOTAL" + texto)
        End If
        drM.Close()
        conM.Dispose()
        conM.Close()

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        FileClose(lngFile)

    End Sub
    Private Sub CriaRelatFinanceiro(IDfec As Integer)
        Dim con As New SqlConnection()
        Dim conM As New SqlConnection()
        Dim conS As New SqlConnection()
        Dim conAV As New SqlConnection()
        Dim conAP As New SqlConnection()
        Dim conPen As New SqlConnection()
        Dim conPenP As New SqlConnection()
        Dim dr As SqlDataReader
        Dim drM As SqlDataReader
        Dim drS As SqlDataReader
        Dim drAV As SqlDataReader
        Dim drAP As SqlDataReader
        Dim drPen As SqlDataReader
        Dim drPenP As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Cabec As Boolean = True
        Dim vlrTmp As Decimal
        Dim vlrReal As Decimal
        Dim vlrSistema As Decimal
        Dim vlrDif As Decimal = 0
        Dim TotalReal As Decimal = 0
        Dim TotalSistema As Decimal = 0
        Dim TotalDif As Decimal = 0
        Dim TotalVirtual As Decimal = 0
        Dim TotalLiquido As Decimal = 0
        Dim FundoCaixa As Decimal = 0
        Dim conexao As String = strConServer
        'Dim QtdVdas As String
        Dim Qtde_Vdas As Integer = 0

        con.ConnectionString = conexao
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblFormaPagtos.IDFormaPagto, tblFormaPagtos.Descricao As DescricaoPagto, tblFormaPagtosLojas.IDLoja, tblFormaPagtosLojas.Tipo "
        strSql += "From tblFormaPagtos INNER Join tblFormaPagtosLojas On tblFormaPagtos.IDFormaPagto = tblFormaPagtosLojas.IDFormaPagto "
        strSql += "Where (tblFormaPagtosLojas.IDLoja = " & IDLoja & ") "
        strSql += "Order By DescricaoPagto"

        ' Try
        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\financeiro.txt", OpenMode.Output)

1:

        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        strSql = "Select IDFechamento, SUM(ValorBruto) As VlrTotal "
        strSql += "From tblFechamentosDescricao "
        strSql += "Where (Tipo = 'LD' OR Tipo = 'LR') "
        strSql += "GROUP BY IDFechamento "
        strSql += "HAVING(IDFechamento = " & IDfec & ")"
        Dim vlrMC_Total As Decimal = NuloDecimal(PegaValorCampo("VlrTotal", strSql, conexao))

        If dr.HasRows Then
            strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
            strSql += "From tblFechamentos "
            strSql += "Where (IDFechamento = " & IDfec & ")"

            texto = ""
            PrintLine(lngFile, "FECHAMENTO CAIXA")
            PrintLine(lngFile, "(Financeiro)")
            PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, "Periodo    : " & NuloString(PegaValorCampo("Turno", strSql, conexao)))
            PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataAbertura", strSql, conexao)))
            PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataFechamento", strSql, conexao)))
            PrintLine(lngFile, "Responsavel: " & NuloString(PegaValorCampo("Caixa", strSql, conexao)))
            PrintLine(lngFile, "---------------------------->> " & IDfec)
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "               Sistema     Real    Dif.")
            PrintLine(lngFile, "========================================")


            strSql = "Select IDFechamento, FundoCaixa "
            strSql += "From tblFechamentos "
            strSql += "Where (IDFechamento = " & IDfec & ")"
            FundoCaixa = NuloDecimal(PegaValorCampo("FundoCaixa", strSql, conexao))


            While (dr.Read())
                If dr.Item("Tipo") = "R" Then
                    texto = Strings.Left(NuloString(dr.Item("DescricaoPagto")), 14)
                Else
                    texto = "* " & Strings.Left(NuloString(dr.Item("DescricaoPagto")), 14)
                End If

                strSql = "Select tblRetVendasPagto.IDFormaPagto, SUM(tblRetVendasPagto.ValorPago) As Soma, tblRetVendas.IDfechamento "
                strSql += "From tblRetVendasPagto INNER Join tblRetVendas On tblRetVendasPagto.IDVendaRet = tblRetVendas.IDVendaRet "
                strSql += "Group By tblRetVendasPagto.IDFormaPagto, tblRetVendas.IDfechamento "
                strSql += "HAVING(tblRetVendas.IDfechamento = " & IDfec & ") And (tblRetVendasPagto.IDFormaPagto = " & dr.Item("IDFormaPagto") & ")"
                vlrSistema = NuloDecimal(PegaValorCampo("Soma", strSql, conexao))
                texto += Space(23 - Len(texto) - Len(NuloDecimal(vlrSistema).ToString("#0.00"))) & NuloDecimal(vlrSistema).ToString("#0.00")



                strSql = "Select IDFechamento, IDFormaPagto, SUM(ValorBruto) As ValorBruto "
                strSql += "From tblFechamentosDescricao "
                strSql += "Group By IDFechamento, IDFormaPagto "
                strSql += "HAVING(IDFechamento = " & IDfec & ") And (IDFormaPagto = " & dr.Item("IDFormaPagto") & ")"
                vlrReal = NuloDecimal(PegaValorCampo("ValorBruto", strSql, conexao))
                If UCase(texto) <> "DINHEIRO" Then
                    texto += Space(9 - Len(vlrReal.ToString("#0.00"))) & vlrReal.ToString("#0.00")
                Else
                    vlrReal += vlrMC_Total
                    If IncluiFundoCaixa = True Then
                        vlrReal += FundoCaixa
                    End If
                    texto += Space(9 - Len(vlrReal.ToString("#0.00"))) & vlrReal.ToString("#0.00")
                End If


                vlrDif = vlrReal - vlrSistema
                texto += Space(10 - Len(vlrDif.ToString("#0.00"))) & vlrDif.ToString("#0.00")

                PrintLine(lngFile, texto)

                TotalSistema += vlrSistema
                If dr.Item("Tipo") = "V" Then
                    TotalVirtual += vlrSistema
                End If

                TotalReal += vlrReal
                TotalDif += vlrDif
            End While

            PrintLine(lngFile, "------------------------------------------")
            texto = "TOTAL "
            texto &= Space(23 - Len(texto) - Len(TotalSistema.ToString("#0.00"))) & TotalSistema.ToString("#0.00")
            texto &= Space(9 - Len(TotalReal.ToString("#0.00"))) & TotalReal.ToString("#0.00")
            texto &= Space(10 - Len(TotalDif.ToString("#0.00"))) & TotalDif.ToString("#0.00")
            PrintLine(lngFile, texto)

            ' Verifica Virtual //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If TotalVirtual <> 0 Then

                texto = "* Virtual "
                texto &= Space(23 - Len(texto) - Len(TotalVirtual.ToString("#0.00"))) & TotalVirtual.ToString("#0.00")
                PrintLine(lngFile, texto)

                PrintLine(lngFile, "------------------------------------------")
                texto = "Liquido "
                TotalLiquido = TotalSistema - TotalVirtual
                texto &= Space(23 - Len(texto) - Len(TotalLiquido.ToString("#0.00"))) & TotalLiquido.ToString("#0.00")
                PrintLine(lngFile, texto)
            End If
            PrintLine(lngFile, "==========================================")
            If IncluiFundoCaixa = True Then
                PrintLine(lngFile, "(Fundo de caixa incluso no dinheiro)")
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
        End If

        dr.Close()
        con.Dispose()
        con.Close()

        PrintLine(lngFile, "                  Apontamentos do Caixa")
        PrintLine(lngFile, "==========================================")
        vlrTmp = NuloDecimal(FundoCaixa)
        texto = "Fundo de Caixa     :"
        texto += Space(20 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
        PrintLine(lngFile, texto)

        strSql = "SELECT IDfechamento, SUM(Desconto) AS VlrDesc, SUM(Servico) AS VlrServ, SUM(Caixinha) AS VlrCaix, SUM(QtdPessoas) AS QtdePes, Excluido "
        strSql += "FROM tblRetVendas "
        strSql += "GROUP BY IDfechamento, Excluido "
        strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"
        vlrTmp = NuloDecimal(PegaValorCampo("VlrServ", strSql, conexao))
        texto = "Servico            : "
        texto += Space(19 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
        PrintLine(lngFile, texto)

        strSql = "SELECT IDfechamento, SUM(Desconto) AS VlrDesc, SUM(Servico) AS VlrServ, SUM(Caixinha) AS VlrCaix, SUM(QtdPessoas) AS QtdePes, Excluido "
        strSql += "FROM tblRetVendas "
        strSql += "GROUP BY IDfechamento, Excluido "
        strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"
        vlrTmp = NuloDecimal(PegaValorCampo("VlrCaix", strSql, conexao))
        texto = "Caixinha/Repique   : "
        texto += Space(19 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
        PrintLine(lngFile, texto)

        strSql = "SELECT IDfechamento, SUM(Desconto) AS VlrDesc, SUM(Servico) AS VlrServ, SUM(Caixinha) AS VlrCaix, SUM(QtdPessoas) AS QtdePes, Excluido "
        strSql += "FROM tblRetVendas "
        strSql += "GROUP BY IDfechamento, Excluido "
        strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"
        vlrTmp = NuloDecimal(PegaValorCampo("VlrDesc", strSql, conexao))
        texto = "Descontos          : "
        texto += Space(19 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
        PrintLine(lngFile, texto)

        strSql = "SELECT tblRetVendas.IDfechamento, tblRetVendas.Excluido, SUM(tblVales.Valor) AS VlrVales "
        strSql += "FROM tblRetVendas INNER JOIN tblVales ON tblRetVendas.IDVendaRet = tblVales.IDVendaRet "
        strSql += "GROUP BY tblRetVendas.IDfechamento, tblRetVendas.Excluido "
        strSql += "HAVING (tblRetVendas.IDfechamento = " & IDfec & ") AND (tblRetVendas.Excluido = 0)"
        vlrTmp = NuloDecimal(PegaValorCampo("VlrVales", strSql, conexao))
        texto = "Vales emitidos     : "
        texto += Space(19 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
        PrintLine(lngFile, texto)

        strSql = "SELECT IDfechamento, SUM(TaxaEntrega) AS VlrTxEnt, Excluido "
        strSql += "FROM tblRetVendas "
        strSql += "GROUP BY IDfechamento, Excluido "
        strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"

        vlrTmp = NuloDecimal(PegaValorCampo("VlrTxEnt", strSql, conexao))
        texto = "Taxa de Entrega    : "
        texto += Space(19 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
        PrintLine(lngFile, texto)

        If vlrMC_Total <> 0 Then
            TotalSistema += vlrMC_Total
            texto = "Movto no caixa     : "
            texto += Space(19 - Len(NuloDecimal(vlrMC_Total).ToString("#0.00"))) & NuloDecimal(vlrMC_Total).ToString("#0.00")
            PrintLine(lngFile, texto)
        End If

        strSql = "SELECT IDfechamento, SUM(QtdPessoas) AS VlrTxEnt, Excluido "
        strSql += "FROM tblRetVendas "
        strSql += "GROUP BY IDfechamento, Excluido "
        strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"
        vlrTmp = NuloDecimal(PegaValorCampo("VlrTxEnt", strSql, conexao))
        texto = "Qtde. de pessoas   : "
        texto += Space(19 - Len(vlrTmp.ToString("#0"))) & vlrTmp.ToString("#0")
        PrintLine(lngFile, texto)

        strSql = "SELECT IDfechamento, count(IDVendaRet) AS VlrTxEnt, Excluido "
        strSql += "FROM tblRetVendas "
        strSql += "GROUP BY IDfechamento, Excluido "
        strSql += "HAVING (IDfechamento = " & IDfec & ") AND (Excluido = 0)"
        vlrTmp = NuloDecimal(PegaValorCampo("VlrTxEnt", strSql, conexao))
        Qtde_Vdas = vlrTmp
        texto = "Qtde. de vendas    : "
        texto += Space(19 - Len(vlrTmp.ToString("#0"))) & vlrTmp.ToString("#0")
        PrintLine(lngFile, texto)

        PrintLine(lngFile, "==========================================")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")



        ' Vendas por módulo ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        conM.ConnectionString = conexao
        Dim cmdM As SqlCommand = conM.CreateCommand

        strSql = "Select IDFechamento, SUM(TotalProdutos) As vlrProd, SUM(TotalVenda) As vlrVenda, SUM(QtdPessoas) As QtdePes, StatusVenda, Excluido, SUM(Caixinha) As Caixi, SUM(Desconto) As Descont, SUM(TaxaEntrega) As TxEntrega, COUNT(IDVendaRet) As QtdeVda, SUM(Servico) AS Serv "
        strSql += "From tblRetVendas "
        strSql += "Group By IDFechamento, StatusVenda, Excluido "
        strSql += "HAVING (Excluido = 0) And (IDfechamento = " & IDfec & ") "
        strSql += "ORDER BY StatusVenda DESC"

        cmdM.CommandText = strSql
        conM.Open()
        drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Totalprod As Decimal = 0
        Dim vlrPro As Decimal = 0
        If drM.HasRows Then
            strSql = "SELECT IDfechamento, SUM(TotalProdutos) AS vlrProd, Excluido "
            strSql += "From tblRetVendas "
            strSql += "Group By IDFechamento, Excluido "
            strSql += "HAVING(Excluido = 0) And (IDfechamento = " & IDfec & ") "

            Dim totProds As Decimal = NuloDecimal(PegaValorCampo("vlrProd", strSql, conexao))
            Dim Qtde As Integer
            Dim QtdeTot As Integer
            Dim Media As Decimal
            Dim Perc As Decimal


            TotalSistema = 0
            PrintLine(lngFile, "                       Venda por modulo")
            PrintLine(lngFile, "Modulos      V Pro    V Vda   Qtde     TM")
            PrintLine(lngFile, "==========================================")
            While drM.Read
                If NuloDecimal(totProds) > 0 Then
                    Perc = (drM.Item("vlrprod") / totProds) * 100
                Else
                    Perc = 0
                End If

                If drM.Item("StatusVenda") = "D" Then
                    texto = "Deliv  "
                Else
                    If drM.Item("StatusVenda") = "B" Then
                        texto = "Balcao "
                    Else
                        texto = "Salao  "
                    End If
                End If

                texto += Perc.ToString("#0") & "%"
                If Len(texto) < 11 Then
                    texto += Space(11 - Len(texto))
                End If

                vlrPro = NuloDecimal(drM.Item("vlrProd"))

                If CameloTambore = False Then
                    vlrTmp = (NuloDecimal(drM.Item("vlrProd")) + NuloDecimal(drM.Item("TxEntrega")) + NuloDecimal(drM.Item("Serv")) + NuloDecimal(drM.Item("Caixi"))) - NuloDecimal(drM.Item("Descont"))
                Else
                    vlrTmp = (NuloDecimal(drM.Item("vlrProd")) + NuloDecimal(drM.Item("TxEntrega")) + NuloDecimal(drM.Item("Serv")) + NuloDecimal(drM.Item("Caixi"))) - NuloDecimal(drM.Item("Descont"))
                End If


                TotalSistema += vlrTmp
                Totalprod += vlrPro

                If NuloString(MediaQtdeVdas) = "True" Or NuloString(MediaQtdeVdas) = "Sim" Then
                    Qtde = NuloInteger(drM.Item("QtdeVda"))
                Else
                    Qtde = NuloInteger(drM.Item("QtdePes"))
                End If

                QtdeTot += Qtde
                If Qtde > 0 Then
                    Media = vlrPro / Qtde
                Else
                    Media = vlrPro
                End If

                texto += Space(9 - Len(vlrPro.ToString("#0.00"))) & vlrPro.ToString("#0.00")
                texto += Space(9 - Len(vlrTmp.ToString("#0.00"))) & vlrTmp.ToString("#0.00")
                texto += Space(5 - Len(Qtde.ToString("#0"))) & Qtde.ToString("0")
                texto += Space(8 - Len(Media.ToString("#0.00"))) & Media.ToString("#0.00")
                PrintLine(lngFile, texto)
            End While

            PrintLine(lngFile, "------------------------------------------")
            texto = "Total      "
            texto += Space(9 - Len(Totalprod.ToString("#0.00"))) & Totalprod.ToString("#0.00")
            texto += Space(9 - Len(TotalSistema.ToString("#0.00"))) & TotalSistema.ToString("#0.00")
            texto += Space(5 - Len(QtdeTot.ToString("#0"))) & QtdeTot.ToString("0")
            If QtdeTot > 0 Then
                Media = TotalSistema / QtdeTot
            Else
                Media = TotalSistema
            End If
            texto += Space(8 - Len(Media.ToString("#0.00"))) & Media.ToString("#0.00")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")

            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

        End If
        cmdM.Dispose()
        drM.Close()
        conM.Dispose()
        conM.Close()



        ' Serviço e Caixinha /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        conS.ConnectionString = conexao
        Dim cmdS As SqlCommand = conS.CreateCommand

        strSql = "Select IDFechamento, SUM(TotalProdutos) As vlrProd, Count(IDVendaRet) As QtdePes, Excluido, SUM(Servico) As vlrServico, SUM(Caixinha) As vlrCaixinha, Case WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END AS Funcionario, StatusVenda "
        strSql += "From tblRetVendas "
        strSql += "Group By IDFechamento, Excluido, CASE WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END, StatusVenda "
        strSql += "HAVING(Excluido = 0) And (IDfechamento = " & IDfec & ") "
        strSql += "ORDER BY StatusVenda, vlrProd DESC"

        cmdS.CommandText = strSql
        conS.Open()
        drS = cmdS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Totalprod = 0

        If drS.HasRows Then
            Dim vlrServ As Decimal
            Dim vlrCaix As Decimal
            Dim vlrServAj As Decimal
            Dim totServ As Decimal = 0
            Dim totCaix As Decimal = 0
            Dim totServAj As Decimal = 0
            Dim qtdePes As Integer
            Dim qtdePesTot As Integer

            PrintLine(lngFile, " ")
            PrintLine(lngFile, "                        Servico/Caixinha")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                PrintLine(lngFile, "Func.   Vlr Pro  Serv Ajust Caixinha   Qtd")
            Else
                PrintLine(lngFile, "Func.   Vlr Pro    Servico  Caixinha   Qtd")
            End If
            PrintLine(lngFile, "==========================================")
            While drS.Read
                vlrPro = NuloDecimal(drS.Item("vlrProd"))
                vlrServ = NuloDecimal(drS.Item("vlrServico"))
                vlrServAj = NuloDecimal(NuloDecimal(drS.Item("vlrServico")) * ((100 - FatorAjusteServico) / 100))
                vlrCaix = NuloDecimal(drS.Item("vlrCaixinha"))
                qtdePes = NuloInteger(drS.Item("QTdePes"))
                qtdePesTot += qtdePes

                totServ += vlrServ.ToString("#0.00")
                totCaix += vlrCaix.ToString("#0.00")
                totServAj += vlrServAj.ToString("#0.00")
                Totalprod += vlrPro.ToString("#0.00")

                texto = Trim(Strings.Left(drS.Item("Funcionario"), 8))
                If Len(texto) < 8 Then
                    texto += Space(8 - Len(texto))
                End If
                texto += Space(8 - Len(vlrPro.ToString("#0.00"))) & vlrPro.ToString("#0.00")
                If NuloInteger(FatorAjusteServico) <> 0 Then
                    texto += Space(10 - Len(vlrServAj.ToString("#0.00"))) & vlrServAj.ToString("#0.00")
                Else
                    texto += Space(10 - Len(vlrServ.ToString("#0.00"))) & vlrServ.ToString("#0.00")
                End If
                texto += Space(10 - Len(vlrCaix.ToString("#0.00"))) & vlrCaix.ToString("#0.00")
                texto += Space(5 - Len(qtdePes.ToString("#0"))) & qtdePes.ToString("#0")
                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "------------------------------------------")
            texto = "Total   "
            texto += Space(9 - Len(Totalprod.ToString("#0.00"))) & Totalprod.ToString("#0.00")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                texto += Space(10 - Len(totServAj.ToString("#0.00"))) & totServAj.ToString("#0.00")
            Else
                texto += Space(10 - Len(totServ.ToString("#0.00"))) & totServ.ToString("#0.00")
            End If
            texto += Space(10 - Len(totCaix.ToString("#0.00"))) & totCaix.ToString("0.00")
            texto += Space(5 - Len(qtdePesTot.ToString("#0"))) & qtdePesTot.ToString("#0")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                Dim ServicoAj As Decimal = totServ - totServAj
                PrintLine(lngFile, "*Servico ajustado:  " & FatorAjusteServico & "%    (" & ServicoAj.ToString("#0.00") & ")")
            End If
        End If
        cmdS.Dispose()
        drS.Close()
        conS.Dispose()
        conS.Close()

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")



        ' Movimentação no caixa /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim conMC As New SqlConnection()
        conMC.ConnectionString = conexao
        Dim cmdMC As SqlCommand = conMC.CreateCommand

        strSql = "Select tblFechamentosDescricao.IDFechamentoDescricao, tblFechamentosDescricao.IDFechamento, tblFechamentosDescricao.IDConta, tblFechamentosDescricao.Tipo, tblFechamentosDescricao.Descricao, tblFechamentosDescricao.ValorBruto, tblPlanoContas_Conta.Conta "
        strSql += "From tblFechamentosDescricao INNER Join tblPlanoContas_Conta On tblFechamentosDescricao.IDConta = tblPlanoContas_Conta.IDConta "
        strSql += "Where (tblFechamentosDescricao.IDFechamento = " & IDfec & ") And (tblFechamentosDescricao.Tipo = 'LD' OR tblFechamentosDescricao.Tipo = 'LR') "
        strSql += "ORDER BY tblFechamentosDescricao.Descricao"

        cmdMC.CommandText = strSql
        conMC.Open()
        Dim drMC As SqlDataReader
        drMC = cmdMC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drMC.HasRows Then
            Dim vlrMC As Decimal = 0
            Dim vlrTotalMC As Decimal = 0

            PrintLine(lngFile, "                   Movimentacao no Caixa")
            PrintLine(lngFile, "Descricao                         Valor ")
            PrintLine(lngFile, "========================================")
            While drMC.Read
                If NuloDecimal(drMC.Item("ValorBruto")) < 0 Then
                    vlrMC = NuloDecimal(drMC.Item("ValorBruto")) * -1
                Else
                    vlrMC = NuloDecimal(drMC.Item("ValorBruto"))
                End If
                vlrTotalMC += vlrMC

                texto = Strings.Left(NuloString(drMC.Item("Conta")), 14) & " " & Strings.Left(NuloString(drMC.Item("Descricao")), 15)
                If Len(texto) < 30 Then
                    texto += Space(30 - Len(texto))
                Else
                    texto = Strings.Left(texto, 30)
                End If
                texto += Space(10 - Len(vlrMC.ToString("#0.00"))) & vlrMC.ToString("#0.00")
                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "----------------------------------------")
            texto = "Total                         "
            texto += Space(10 - Len(vlrTotalMC.ToString("#0.00"))) & vlrTotalMC.ToString("#0.00")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "========================================")
        End If

        cmdMC.Dispose()
        drMC.Close()
        conMC.Dispose()
        conMC.Close()

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")


        ' Pendencias ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        conPen.ConnectionString = strConServer
        Dim cmdPen As SqlCommand = conPen.CreateCommand

        strSql = "Select tblPendencias.IDPendencia, tblPendencias.IDFechamento, tblPendencias.IDCliente, tblClientesLojas.NomeCliente, tblPendencias.Data, tblPendencias.Descricao, tblPendencias.IDFormaPagto, tblFormaPagtos.Descricao AS DescPagto, tblPendencias.Valor, tblPendencias.IDVendaRetPagto, tblPendencias.IDVendaRet "
        strSql += "From tblFormaPagtos INNER Join tblPendencias On tblFormaPagtos.IDFormaPagto = tblPendencias.IDFormaPagto INNER Join tblClientesLojas On tblPendencias.IDCliente = tblClientesLojas.IDClienteLoja "
        strSql += "Where (tblPendencias.IDFechamento = " & IDfec & ") And (tblPendencias.Valor > 0)"

        cmdPen.CommandText = strSql
        conPen.Open()
        drPen = cmdPen.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drPen.HasRows Then
            Dim vlrPenPg As Decimal = 0
            Dim vlrTotalPenPg As Decimal = 0

            PrintLine(lngFile, "                        Pendencias pagas")
            PrintLine(lngFile, "Cliente/Descricao/Pagto.          Valor ")
            PrintLine(lngFile, "========================================")
            While drPen.Read

                vlrPenPg = NuloDecimal(drPen.Item("Valor"))
                vlrTotalPenPg += vlrPenPg

                texto = Strings.Left(NuloString(drPen.Item("NomeCliente")), 19) & " / " & Strings.Left(NuloString(drPen.Item("Descricao")), 19)
                PrintLine(lngFile, texto)

                texto = Strings.Left(NuloString(drPen.Item("DescPagto")), 30)
                If Len(texto) < 30 Then
                    texto += Space(30 - Len(texto))
                Else
                    texto = Strings.Left(texto, 30)
                End If
                texto += Space(10 - Len(vlrPenPg.ToString("#0.00"))) & vlrPenPg.ToString("#0.00")
                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "----------------------------------------")
            texto = "Total                         "
            texto += Space(10 - Len(vlrTotalPenPg.ToString("#0.00"))) & vlrTotalPenPg.ToString("#0.00")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "========================================")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
        End If

        cmdPen.Dispose()
        drPen.Close()
        conPen.Dispose()
        conPen.Close()

        conPenP.ConnectionString = strConServer
        Dim cmdPenP As SqlCommand = conPenP.CreateCommand

        strSql = "Select tblPendencias.IDPendencia, tblPendencias.IDFechamento, tblPendencias.IDCliente, tblClientesLojas.NomeCliente, tblPendencias.Data, tblPendencias.Descricao, tblPendencias.IDFormaPagto, tblFormaPagtos.Descricao AS DescPagto, tblPendencias.Valor, tblPendencias.IDVendaRetPagto, tblPendencias.IDVendaRet "
        strSql += "From tblFormaPagtos INNER Join tblPendencias On tblFormaPagtos.IDFormaPagto = tblPendencias.IDFormaPagto INNER Join tblClientesLojas On tblPendencias.IDCliente = tblClientesLojas.IDClienteLoja "
        strSql += "Where (tblPendencias.IDFechamento = " & IDfec & ") And (tblPendencias.Valor < 0)"

        cmdPenP.CommandText = strSql
        conPenP.Open()
        drPenP = cmdPenP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drPenP.HasRows Then
            Dim vlrPenPgP As Decimal = 0
            Dim vlrTotalPenPgP As Decimal = 0

            PrintLine(lngFile, "                    Pendencias efetuadas")
            PrintLine(lngFile, "Cliente/Descricao/Pagto.          Valor ")
            PrintLine(lngFile, "========================================")
            While drPenP.Read

                vlrPenPgP = NuloDecimal(drPenP.Item("Valor") * -1)
                vlrTotalPenPgP += vlrPenPgP

                texto = Strings.Left(NuloString(drPenP.Item("NomeCliente")), 19) & " / " & Strings.Left(NuloString(drPenP.Item("Descricao")), 19)
                PrintLine(lngFile, texto)

                texto = Strings.Left(NuloString(drPenP.Item("DescPagto")), 30)
                If Len(texto) < 30 Then
                    texto += Space(30 - Len(texto))
                Else
                    texto = Strings.Left(texto, 30)
                End If
                texto += Space(10 - Len(vlrPenPgP.ToString("#0.00"))) & vlrPenPgP.ToString("#0.00")
                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "----------------------------------------")
            texto = "Total                         "
            texto += Space(10 - Len(vlrTotalPenPgP.ToString("#0.00"))) & vlrTotalPenPgP.ToString("#0.00")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "========================================")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
        End If
        cmdPenP.Dispose()
        drPenP.Close()
        conPenP.Dispose()
        conPenP.Close()


        ' Resumo Delivery ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.StatusVenda, tblRetVendas.Excluido, tblClientesLojas.Origem, COUNT(tblRetVendas.IDVendaRet) As QtdVdas "
        strSql += "From tblRetVendas LEFT OUTER Join tblClientesLojas On tblRetVendas.IDCliente = tblClientesLojas.IDCliente And tblRetVendas.IDLoja = tblClientesLojas.IDLoja "
        strSql += "Group By tblRetVendas.IDfechamento, tblRetVendas.StatusVenda, tblClientesLojas.Origem, tblRetVendas.Excluido "
        strSql += "HAVING(tblRetVendas.IDfechamento =" & IDfec & ") And (tblRetVendas.StatusVenda = 'D') AND (tblRetVendas.Excluido = 0) "
        strSql += "ORDER BY QtdVdas DESC"

        Dim dap = New SqlDataAdapter(strSql, strConServer)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim dsDD As New DataSet()
        dap.Fill(dsDD, "Vendas")
        If dsDD.Tables("Vendas").Rows.Count > 0 Then
            strSql = "Select tblRetVendas.IDfechamento, tblRetVendas.StatusVenda, tblRetVendas.Excluido, COUNT(tblRetVendas.IDVendaRet) As QtdVdas "
            strSql += "From tblRetVendas LEFT OUTER Join tblClientesLojas On tblRetVendas.IDCliente = tblClientesLojas.IDCliente And tblRetVendas.IDLoja = tblClientesLojas.IDLoja "
            strSql += "Group By tblRetVendas.IDfechamento, tblRetVendas.StatusVenda, tblRetVendas.Excluido "
            strSql += "HAVING(tblRetVendas.IDfechamento =" & IDfec & ") And (tblRetVendas.StatusVenda = 'D') AND (tblRetVendas.Excluido = 0) "
            strSql += "ORDER BY QtdVdas DESC"
            Dim TotVdas As Integer = NuloInteger(PegaValorCampo("QtdVdas", strSql, strConServer))
            Dim Perc As String
            PrintLine(lngFile, "                  Resumo vendas Delivery")
            PrintLine(lngFile, "POR ORIGEM")
            PrintLine(lngFile, "========================================")
            PrintLine(lngFile, "Origem                Qtde     %")
            PrintLine(lngFile, "----------------------------------------")
            For i As Integer = 0 To dsDD.Tables("Vendas").Rows.Count - 1
                Perc = ((NuloDecimal(dsDD.Tables("Vendas").Rows(i).Item("QtdVdas")) / TotVdas) * 100).ToString("#0.0")

                If NuloString(dsDD.Tables("Vendas").Rows(i).Item("Origem")) <> "" Then
                    texto = Strings.Left(dsDD.Tables("Vendas").Rows(i).Item("Origem"), 20) & Space(20 - Len(dsDD.Tables("Vendas").Rows(i).Item("Origem"))) & Space(9 - Len(dsDD.Tables("Vendas").Rows(i).Item("QtdVdas"))) & dsDD.Tables("Vendas").Rows(i).Item("QtdVdas") & Space(7 - Len(Perc)) & Perc
                Else
                    texto = "NAO INFORMADO       " & Space(9 - Len(dsDD.Tables("Vendas").Rows(i).Item("QtdVdas"))) & dsDD.Tables("Vendas").Rows(i).Item("QtdVdas") & Space(7 - Len(Perc)) & Perc
                End If
                PrintLine(lngFile, texto)
            Next
            PrintLine(lngFile, "----------------------------------------")
            texto = Space(20) & Space(9 - Len(TotVdas)) & TotVdas
            PrintLine(lngFile, texto)
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")




            strSql = "Select IDFechamento, StatusVenda, Excluido, COUNT(IDVendaRet) As QtdVdas, SUM(TotalProdutos) As Valor, App "
            strSql += "From tblRetVendas "
            strSql += "Group By IDFechamento, StatusVenda, Excluido, App "
            strSql += "HAVING(tblRetVendas.IDfechamento =" & IDfec & ") And (tblRetVendas.StatusVenda = 'D') AND (tblRetVendas.Excluido = 0) "
            strSql += "ORDER BY QtdVdas DESC"
            Dim dapD = New SqlDataAdapter(strSql, strConServer)
            dapD.SelectCommand.CommandType = CommandType.Text
            Dim dsDDD As New DataSet()
            dapD.Fill(dsDDD, "Vendas")
            If dsDDD.Tables("Vendas").Rows.Count > 1 Then
                strSql = "Select IDFechamento, StatusVenda, Excluido, COUNT(IDVendaRet) As QtdVdas, SUM(TotalProdutos) As Valor "
                strSql += "From tblRetVendas "
                strSql += "Group By IDFechamento, StatusVenda, Excluido "
                strSql += "HAVING(tblRetVendas.IDfechamento =" & IDfec & ") And (tblRetVendas.StatusVenda = 'D') AND (tblRetVendas.Excluido = 0) "
                strSql += "ORDER BY QtdVdas DESC"
                Dim VlrMed As Decimal
                Dim VlrVdasD As Decimal = NuloDecimal(PegaValorCampo("Valor", strSql, strConServer))
                Dim TotVdasD As Integer = NuloInteger(PegaValorCampo("QtdVdas", strSql, strConServer))
                Dim PercD As String
                Dim DescApp As String
                PrintLine(lngFile, "POR APLICATIVO")
                PrintLine(lngFile, "========================================")
                PrintLine(lngFile, "Aplicativo   Qtde    Valor    TM/V    %")
                PrintLine(lngFile, "----------------------------------------")
                For i As Integer = 0 To dsDDD.Tables("Vendas").Rows.Count - 1
                    PercD = ((NuloDecimal(dsDDD.Tables("Vendas").Rows(i).Item("Valor")) / VlrVdasD) * 100).ToString("#0.0")
                    VlrMed = NuloDecimal(dsDDD.Tables("Vendas").Rows(i).Item("Valor")) / NuloDecimal(dsDDD.Tables("Vendas").Rows(i).Item("QtdVdas"))
                    If NuloString(dsDDD.Tables("Vendas").Rows(i).Item("App")) <> "" Then
                        DescApp = Strings.Left(dsDDD.Tables("Vendas").Rows(i).Item("App"), 12)
                    Else
                        DescApp = "POR TELEFONE"
                    End If
                    texto = DescApp & Space(12 - Len(DescApp)) & Space(8 - Len(dsDDD.Tables("Vendas").Rows(i).Item("QtdVdas"))) & dsDDD.Tables("Vendas").Rows(i).Item("QtdVdas") & Space(9 - Len(Format(dsDDD.Tables("Vendas").Rows(i).Item("Valor"), "#0.00"))) & Format(dsDDD.Tables("Vendas").Rows(i).Item("Valor"), "#0.00") & Space(8 - Len(Format(VlrMed, "#0.00"))) & Format(VlrMed, "#0.00") & Space(6 - Len(PercD)) & PercD
                    PrintLine(lngFile, texto)
                Next
                PrintLine(lngFile, "----------------------------------------")
                texto = Space(26 - Len(Format(VlrVdasD, "#0.00"))) & Format(VlrVdasD, "#0.00")
                PrintLine(lngFile, texto)
            End If

            PrintLine(lngFile, "========================================")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")

        End If

        If ckbMovtoAnterior.Checked = False And Clube = False Then
            ' Vendas em aberto  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            conAV.ConnectionString = strCon
            Dim cmdAV As SqlCommand = conAV.CreateCommand

            strSql = "Select IDVenda, NumVenda, NumMesa, DataVenda, FlagFechada, StatusVenda, Excluido, IDfechamento, Atendente "
            strSql += "From tblVendas "
            strSql += "Where (FlagFechada = 0) And (Excluido = 0) "
            strSql += "Order By DataVenda"

            cmdAV.CommandText = strSql
            conAV.Open()
            drAV = cmdAV.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If drAV.HasRows Then
                Dim MesVda As String
                Dim Hora As String
                PrintLine(lngFile, "     V E N D A S   E M   A B E R T O    ")
                PrintLine(lngFile, "========================================")
                PrintLine(lngFile, "Modulo   Atendente       Mesa/Vda   Hora")
                PrintLine(lngFile, "----------------------------------------")
                While drAV.Read
                    If drAV.Item("StatusVenda") = "S" Then
                        MesVda = drAV.Item("NumMesa")
                        texto = "Salao  "
                    ElseIf drAV.Item("StatusVenda") = "B" Then
                        MesVda = drAV.Item("NumVenda")
                        texto = "Balcao "
                    Else
                        MesVda = drAV.Item("NumVenda")
                        texto = "Delivery "
                    End If
                    Hora = Format(drAV.Item("DataVenda"), "HH:MM")
                    texto += Strings.Left(drAV.Item("Atendente"), 15) & Space(17 - Len(Strings.Left(drAV.Item("Atendente"), 15)))
                    texto += Space(8 - Len(MesVda)) & MesVda
                    texto += Space(8 - Len(Hora)) & Hora
                    PrintLine(lngFile, texto)
                End While
                PrintLine(lngFile, "----------------------------------------")
            End If
            cmdAV.Dispose()
            drAV.Close()
            conAV.Dispose()
            conAV.Close()

            conAP.ConnectionString = strCon
            Dim cmdAP As SqlCommand = conAP.CreateCommand

            strSql = "Select tblVendas.FlagFechada, tblVendas.Excluido, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Venda, tblVendasMovto.Excluido As Expr1 "
            strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
            strSql += "Group By tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendas.Excluido, tblVendas.FlagFechada, tblVendasMovto.Excluido "
            strSql += "HAVING(tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 0) And (tblVendasMovto.Excluido = 0) "
            strSql += "ORDER BY tblVendasMovto.Produto"

            cmdAP.CommandText = strSql
            conAP.Open()
            drAP = cmdAP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If drAP.HasRows Then
                Dim vlrProd As Decimal
                Dim totProd As Decimal = 0
                PrintLine(lngFile, "Produtos                                ")
                PrintLine(lngFile, "========================================")
                While drAP.Read
                    texto = Strings.Left(drAP.Item("Produto"), 13) & Space(17 - Len(Strings.Left(drAP.Item("Produto"), 13)))
                    vlrProd = NuloDecimal(drAP.Item("Qtde")) * NuloDecimal(drAP.Item("Venda"))
                    texto &= Trim(drAP.Item("Qtde"))
                    texto += Space(8 - Len(NuloDecimal(drAP.Item("Venda")).ToString("#0.00"))) & NuloDecimal(drAP.Item("Venda")).ToString("#0.00")
                    texto += Space(10 - Len(vlrProd.ToString("#0.00"))) & vlrProd.ToString("#0.00")
                    PrintLine(lngFile, texto)
                    totProd += vlrProd
                End While
                PrintLine(lngFile, "----------------------------------------")
                texto = "Total"
                texto += Space(35 - Len(totProd.ToString("#0.00"))) & totProd.ToString("#0.00")
                PrintLine(lngFile, texto)
                PrintLine(lngFile, "========================================")
            End If
            cmdAP.Dispose()
            drAP.Close()
            conAP.Dispose()
            conAP.Close()

        End If

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        FileClose(lngFile)

    End Sub

    Private Sub ConfirmaMovto(IDfecLocal As Integer)

        ' Limpa movtos //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Delete From tblRetVendas WHERE (IDFechamento = " & IDfecLocal & ")"
        ExecutaStrServidor(strSql)

        strSql = "Delete From tblFechamentos WHERE (IDFechamentoLoja = " & IDfecLocal & ")"
        ExecutaStrServidor(strSql)


        ' Cria Fechamento //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Select * "
        strSql += "From tblFechamentos_Local "
        strSql += "WHERE IDFechamento=" & IDfecLocal

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            strSql = "INSERT tblFechamentos "
            strSql += "(IDLoja, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, FundoCaixa, IDFechamentoLoja, IDFuncionario) VALUES ("
            strSql += to_sql(IDLoja) & ","
            strSql &= to_sql(NuloString(Operador)) & ", "
            strSql += to_sql(NuloString(dr.Item("DiaMovimento"))) & ", "
            strSql += to_sql(NuloString(dr.Item("DataAbertura"))) & ", "
            strSql += to_sql(NuloString(Now)) & ", "
            strSql += to_sql(NuloString(dr.Item("Turno"))) & ", "
            strSql += to_sql(NuloDecimal(dr.Item("FundoCaixa"))) & ", "
            strSql += to_sql(IDfecLocal) & ", "
            strSql += to_sql(IDOperador) & ")"
            ExecutaStrServidor(strSql)
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()
        IDfecRet = PegaID("IDFechamento", "tblFechamentos", "S")


    End Sub
    Private Sub PreencheVendas()

        strSql = "Select IDFechamento, SUM(TotalProdutos) As VlrProdutos, SUM(TotalVenda) As VlrTotal, SUM(QtdPessoas) As QtdePessoas, FlagFechada, Excluido "
        strSql += "From tblVendas "
        strSql += "Group By IDFechamento, FlagFechada, Excluido "
        strSql += "HAVING(FlagFechada = 1) And (Excluido = 0) "
        If cbMovto.Text <> "" Then
            strSql += "And (IDfechamento = " & Val(Strings.Right(cbMovto.Text, 8)) & ")"
        End If

        Dim VlrTotal As Decimal = 0
        Dim VlrProd As Decimal = 0
        Dim QtdePess As Integer = 0
        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                VlrTotal += dr.Item("VlrTotal")
                VlrProd += dr.Item("VlrProdutos")
                QtdePess = dr.Item("QtdePessoas")
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        If QtdePess = 0 Then QtdePess = 1

        ' lbVlrProdutos.Text = Format(VlrProd, "#0.00")
        ' lbVlrTot.Text = Format(VlrTotal, "#0.00")
        ' lbQtdePess.Text = Format(QtdePess, "#0")
        ' lbMedia.Text = Format(VlrTotal / QtdePess, "#0.00")

    End Sub
    Private Sub PreenchePagtos()
        strSql = "Select IDFormaPagto, CodigoFormaPagto, CodigoFiscal, ECartao, TrocoPadrao, AcionaGaveta, Descricao, CodigoSAT "
        strSql += "From tblFormaPagtos_Local "
        strSql += "Order By Descricao"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbPagtos.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbPagtos.Items.Add("")
            While (dr.Read)
                cbPagtos.Items.Add(dr.Item("Descricao") & Space(100) & dr.Item("IDFormaPagto"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheMovto()

        Dim conexao As String
        If ckbMovtoAnterior.Checked = False Then
            strSql = "Select IDFechamento, IDFuncionario, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido "
            strSql += "From tblFechamentos_Local "
            strSql += "Where (Confirmado = 0) "
            strSql += "Order By IDFechamento, Turno"
            conexao = strCon
        Else
            strSql = "Select IDFechamento, IDFuncionario, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDLoja "
            strSql += "From tblFechamentos "
            strSql += "Where (Confirmado = 1) AND (IDLoja=" & IDLoja & ")"
            strSql += "Order By DiaMovimento DESC, Turno"
            conexao = strConServer
        End If

        cbMovto.Items.Clear()

        Dim con As New SqlConnection(conexao)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbMovto.Items.Add("")
            While (dr.Read)
                cbMovto.Items.Add(dr.Item("Turno") & " (" & dr.Item("DiaMovimento") & ") - " & Strings.Left(dr.Item("Caixa"), 20) & Space(100) & dr.Item("IDFechamento"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub AchaPagto(IDfor As Integer)
        strSql = "Select * "
        strSql += "From tblFormaPagtos_Local "
        strSql += "Where (IDFormaPagto =" & IDfor & ")"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            lbAbertura.Text = dr.Item("DataAbertura")
            lbIDFechamento.Text = dr.Item("IDFechamento")
            tbFundoCaixa.Text = Convert.ToDecimal(dr.Item("FundoCaixa"))
        Else
            lbAbertura.Text = ""
            lbIDFechamento.Text = ""
            tbFundoCaixa.Text = Convert.ToDecimal(0)
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub AchaMovto(IDmovto As Integer)
        Dim conexao As String
        strSql = "Select IDFechamento, IDFuncionario, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido "
        If ckbMovtoAnterior.Checked = False Then
            strSql += "From tblFechamentos_Local "
            conexao = strCon
        Else
            strSql += "From tblFechamentos "
            conexao = strConServer
        End If
        strSql += "Where (IDFechamento =" & IDmovto & ")"

        Dim con As New SqlConnection(conexao)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            If Operador <> dr.Item("Caixa") And ckbMovtoAnterior.Checked = False And Operador <> "OPERADOR MASTER" And NivelFuncionario < 3 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Operador (" & Operador & ") para ver este movimento"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                lbAbertura.Text = ""
                lbIDFechamento.Text = ""
                tbFundoCaixa.Text = Convert.ToDecimal(0)
                tbDiaMovto.Text = ""
            Else
                If NivelFuncionario >= 3 Or Operador = dr.Item("Caixa") Then
                    lbAbertura.Text = dr.Item("DataAbertura")
                    lbIDFechamento.Text = dr.Item("IDFechamento")
                    tbFundoCaixa.Text = Convert.ToDecimal(dr.Item("FundoCaixa"))
                    tbDiaMovto.Text = dr.Item("DiaMovimento")
                    'Else
                    ' If ckbMovtoAnterior.Checked = False Then
                    'lbAbertura.Text = dr.Item("DataAbertura")
                    'lbIDFechamento.Text = dr.Item("IDFechamento")
                    'tbFundoCaixa.Text = Convert.ToDecimal(dr.Item("FundoCaixa"))
                    'tbDiaMovto.Text = dr.Item("DiaMovimento")
                Else
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Operador (" & Operador & ") para ver este movimento"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                End If

                'End If
            End If
        Else
            lbAbertura.Text = ""
            lbIDFechamento.Text = ""
            tbFundoCaixa.Text = Convert.ToDecimal(0)
            tbDiaMovto.Text = ""
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheLista(IDfec As Integer)
        Dim item As ListViewItem
        Dim Vlr As Decimal = 0
        Dim conexao As String

        If ckbMovtoAnterior.Checked = False Then
            strSql = "Select IDFechamentoDescricaoLocal, IDFechamento, DataTransferencia, Descricao, ValorBruto, IDContaCorrente, IDFormaPagto, Tipo "
            strSql += "From tblFechamentosDescricao_Local "
            conexao = strCon
        Else
            strSql = "Select IDFechamentoDescricao, IDFechamento, DataTransferencia, Descricao, ValorBruto, IDContaCorrente, IDFormaPagto, Tipo "
            strSql += "From tblFechamentosDescricao "
            conexao = strConServer
        End If
        strSql += "Where (IDFechamento = " & IDfec & ") "
        strSql += "Order By Descricao"

        Dim conA As New SqlConnection(conexao)
        conA.Open()
        Dim cmdA As New SqlCommand(strSql, conA)
        cmdA.CommandType = CommandType.Text

        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstLanctos.Items.Clear()

        If drA.HasRows Then
            While drA.Read()
                If ckbMovtoAnterior.Checked = False Then
                    item = lstLanctos.Items.Add(drA.Item("IDFechamentoDescricaoLocal"))
                Else
                    item = lstLanctos.Items.Add(drA.Item("IDFechamentoDescricao"))
                End If
                item.SubItems.Add(drA.Item("IDFormaPagto"))
                item.SubItems.Add(drA.Item("Descricao"))
                item.SubItems.Add(Convert.ToDecimal(drA.Item("ValorBruto")))
                item.SubItems.Add(drA.Item("Tipo"))

                'If drA.Item("Tipo") <> "LD" Then
                Vlr += drA.Item("ValorBruto")
                'Else
                'Vlr -= drA.Item("ValorBruto")
                'End If
            End While
            lstLanctos.Update()
            lstLanctos.EndUpdate()
        End If
        lbVlrTotal.Text = Convert.ToDecimal(Vlr).ToString("C")
        drA.Close()
        cmdA.Dispose()
        conA.Dispose()
        conA.Close()

        Colorir()
        PreencheVendas()

    End Sub
    Private Sub Colorir()
        For i As Integer = 0 To lstLanctos.Items.Count - 1

            'lstLanctos.Items(i).Selected = True
            'If lstLanctos.SelectedItems(i).SubItems(4).Text = "LD" Then
            If NuloString(lstLanctos.Items(i).SubItems(4).Text) = "LD" Then
                lstLanctos.Items(i).ForeColor = Color.Red
            End If
            'lstLanctos.Items(i).Selected = False
        Next
    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ModoFiscal = "SAT" Then
            fdlgModuloFiscal_SAT.ShowDialog()
        Else
            fdlgModuloFiscal_NFCE.ShowDialog()
        End If

    End Sub

    Private Sub frmCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If NuloBoolean(PegaValorCampo("EncerraCaixa", "Select IDFuncionario, AbreCaixa, EncerraCaixa From tblFuncionarios_Local Where (IDFuncionario = " & IDOperador & ")", strCon)) = False And Operador <> "OPERADOR MASTER" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Operador (" & Operador & ") sem permissão"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "CAIXA")
        End If

        Foco = "P"
        lbAbertura.Text = ""
        lbIDFechamento.Text = ""
        tbFundoCaixa.Text = Convert.ToDecimal(0)
        tbVlrPagto.Text = ""
        lbVlrTotal.Text = Convert.ToDecimal(0)
        cbxFinanceiro.Checked = True

        PreencheMovto()
        PreenchePagtos()
        PreencheVendas()
        PreenchePlano1()


        If TodosRelatorios = True Then
            cbxFinanceiro.Checked = True
            cbxProdutos.Checked = True
            cbxServico_Caixinha.Checked = True
            chkEstornos_Transferencias.Checked = True
        Else
            cbxFinanceiro.Checked = True
            If InStr(NuloString(RelatFechamento), "P") > 0 Then
                cbxProdutos.Checked = True
            Else
                cbxProdutos.Checked = False
                picRelatProdutos.Visible = False
            End If

            If InStr(NuloString(RelatFechamento), "S") > 0 Then
                cbxServico_Caixinha.Checked = True
            Else
                cbxServico_Caixinha.Checked = False
                picRelatServico.Visible = False
            End If

            If InStr(NuloString(RelatFechamento), "E") > 0 Then
                chkEstornos_Transferencias.Checked = True
            Else
                chkEstornos_Transferencias.Checked = False
                picRelatEstornos.Visible = False
            End If
        End If

        If NuloInteger(NivelFuncionario) >= 4 Or Operador = "OPERADOR MASTER" Then
            btnManutencao.Visible = True
        Else
            btnManutencao.Visible = False
        End If


    End Sub


    Private Sub cbMovto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMovto.SelectedIndexChanged
        AchaMovto(Val(Strings.Right(cbMovto.Text, 8)))
        PreencheLista(Val(Strings.Right(cbMovto.Text, 8)))

        If NuloInteger(lbIDFechamento.Text) <> 0 Then
            Panel2.Visible = True
            Panel3.Visible = True
            Panel5.Visible = True

            If ModulosIRIS = "D" And FechamentoDeliveryCamelo = True Then
                btnFechamentoDelivery.Visible = True
            End If
        Else
            Panel2.Visible = False
            Panel3.Visible = False
            Panel5.Visible = False
        End If
    End Sub

    Private Sub btnIncluiPagto_Click(sender As Object, e As EventArgs) Handles btnIncluiPagto.Click
        Dim txtSql As String
        If cbMovto.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um movimento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If tbVlrPagto.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If tbVlrPagto.Text = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If cbPagtos.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Forma de pagamento inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbPagtos.Focus()
            Exit Sub
        End If


        txtSql = "Select * "
        txtSql += "From tblFormaPagtos_Local "
        txtSql += "Where (IDFormaPagto = " & Val(Strings.Right(cbPagtos.Text, 8)) & ")"
        Dim conA As New SqlConnection(strCon)
        conA.Open()
        Dim cmdA As New SqlCommand(txtSql, conA)
        cmdA.CommandType = CommandType.Text
        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drA.HasRows Then
            drA.Read()

            Dim Taxa As Decimal = drA.Item("Taxa")
            Dim Periodo As Decimal = drA.Item("Periodo")
            Dim ValorTaxa As Decimal = tbVlrPagto.Text * (Taxa / 100)
            Dim ValorBruto As Decimal = tbVlrPagto.Text
            Dim ValorLiquido As Decimal = ValorBruto - ValorTaxa

            strSql = "INSERT tblFechamentosDescricao_Local "
            strSql += "(IDFechamento,IDFormaPagto,Descricao,ValorBruto,IDContaCorrente,IDConta,DataTransferencia,Tipo,ValorLiquido,Diferenca,DataContaReceber,IDConta_Taxa,IDConta_ContraPartida,DescricaoContraPartida) VALUES ("
            strSql += to_sql(lbIDFechamento.Text) & ","
            strSql += to_sql(NuloInteger(Val(Strings.Right(cbPagtos.Text, 8)))) & ","
            strSql += to_sql(NuloString(Trim(Strings.Left(cbPagtos.Text, 30)))) & ","
            strSql += to_sql(Replace(tbVlrPagto.Text, ",", ".")) & ","
            strSql += "0,"
            If drA.Item("Tipo") = "R" And drA.Item("ECartao") = True Then
                ' Conta Receber ///////////////////////////////////////////////////////////////////////////////////////////
                '(IDConta,DataTransferencia,ValorLiquido,Diferenca,DataContaReceber,IDConta_Taxa)
                strSql += to_sql(NuloInteger(drA.Item("IDConta"))) & ", "
                strSql += to_sqlDATA(tbDiaMovto.Text, "data", "L") & ", "
                strSql += "'CR', "
                strSql += to_sql(Replace(ValorLiquido, ",", ".")) & ", "
                strSql += to_sql(Replace(ValorTaxa, ",", ".")) & ", "
                strSql += to_sqlDATA(DateAdd(DateInterval.Day, Periodo, Convert.ToDateTime(tbDiaMovto.Text)), "data", "L") & ", "
                strSql += to_sql(NuloInteger(drA.Item("IDConta_TaxaCartao"))) & ","
                strSql += "0, "
                strSql += "'')"
            End If
            If drA.Item("Tipo") = "R" And drA.Item("ECartao") = False Then
                ' A vista ///////////////////////////////////////////////////////////////////////////////////////////
                '(IDConta,DataTransferencia,ValorLiquido,Diferenca,DataContaReceber,IDConta_Taxa)
                strSql += "0, "
                strSql += to_sqlDATA(tbDiaMovto.Text, "data", "L") & ", "
                strSql += "'DH', "
                strSql += to_sql(Replace(tbVlrPagto.Text, ",", ".")) & ","
                strSql += "0, "
                strSql += to_sqlDATA(tbDiaMovto.Text, "data", "L") & ", "
                strSql += "'',"
                strSql += "0, "
                strSql += "'')"
            End If
            If drA.Item("Tipo") = "V" Then
                ' Plano de Contas ///////////////////////////////////////////////////////////////////////////////////////////
                '(IDConta,DataTransferencia,Tipo,ValorLiquido,Diferenca,IDConta_ContraPartida,DescricaoContraPartida)
                strSql += to_sql(NuloInteger(drA.Item("IDConta"))) & ", "
                strSql += to_sqlDATA(tbDiaMovto.Text, "data", "L") & ", "
                strSql += "'VI', "
                strSql += to_sql(Replace(ValorBruto, ",", ".")) & ", "
                strSql += "0, "
                strSql += "'', "
                strSql += "0, "
                strSql += to_sql(NuloInteger(drA.Item("IDConta_ContraPartida"))) & ", "
                strSql += to_sql(NuloString(Trim(Strings.Left(cbPagtos.Text, 30)))) & ")"
            End If
            ExecutaStr(strSql)
        End If
        cmdA.Dispose()
        drA.Close()
        conA.Dispose()
        conA.Close()

        cbPagtos.Text = ""
        tbVlrPagto.Text = ""
        PreencheLista(Val(Strings.Right(cbMovto.Text, 8)))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Deseja excluir a forma de pagamento"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        cbPagtos.Focus()
        If RetornoMsg = False Then
            Exit Sub
        End If

        For i As Integer = 0 To lstLanctos.Items.Count - 1
            If lstLanctos.Items(i).Selected = True Then
                strSql = "Delete From tblFechamentosDescricao_Local WHERE ( IDFechamentoDescricaoLocal=" & lstLanctos.Items(i).SubItems(0).Text & ")"
                ExecutaStr(strSql)
                Exit For
            End If
        Next
        PreencheLista(Val(Strings.Right(cbMovto.Text, 8)))

    End Sub

    Private Sub tbVlrPagto_TextChanged(sender As Object, e As EventArgs) Handles tbVlrPagto.TextChanged

    End Sub

    Private Sub tbVlrPagto_Enter(sender As Object, e As EventArgs) Handles tbVlrPagto.Enter
        Foco = "P"
    End Sub

    Private Sub tbFundoCaixa_TextChanged(sender As Object, e As EventArgs) Handles tbFundoCaixa.TextChanged

    End Sub

    Private Sub tbFundoCaixa_Enter(sender As Object, e As EventArgs) Handles tbFundoCaixa.Enter
        Foco = "C"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "7"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "7"
            Else
                tbVlrPlano.Text &= "7"
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "0"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "0"
            Else
                tbVlrPlano.Text &= "0"
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "1"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "1"
            Else
                tbVlrPlano.Text &= "1"
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "2"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "2"
            Else
                tbVlrPlano.Text &= "2"
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "3"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "3"
            Else
                tbVlrPlano.Text &= "3"
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "4"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "4"
            Else
                tbVlrPlano.Text &= "4"
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "5"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "5"
            Else
                tbVlrPlano.Text &= "5"
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "6"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "6"
            Else
                tbVlrPlano.Text &= "6"
            End If
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "8"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "8"
            Else
                tbVlrPlano.Text &= "8"
            End If
        End If



    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "9"
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "9"
            Else
                tbVlrPlano.Text &= "9"
            End If
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Foco = "P" Then
            tbVlrPagto.Text &= "."
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text &= "."
            Else
                tbVlrPlano.Text &= "."
            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Foco = "P" Then
            tbVlrPagto.Text = ""
        Else
            If Foco = "C" Then
                tbFundoCaixa.Text = ""
            Else
                tbVlrPlano.Text = ""
            End If
        End If
    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If cbMovto.Text = "" Then

            frm.lbMensagem.Text = "É necessário selecionar um movimento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        If NaoEncerraVendasAberto = True And Clube = False Then
            strSql = "SELECT COUNT(IDFechamento) AS Qtde FROM tblFechamentos_Local"
            If PegaValorCampo("Qtde", strSql, strCon) = 1 Then
                strSql = "Select StatusVenda, IDfechamento From tblVendas Where (IDFechamento Is NULL) Or (IDFechamento = 0)"
                Dim Status As String = NuloString(PegaValorCampo("StatusVenda", strSql, strCon))
                If Status <> "" Then
                    frmSplash.Dispose()
                    frmSplash.Close()
                    If Status = "S" Then Status = "Salão"
                    If Status = "B" Then Status = "Balcão"
                    If Status = "D" Then Status = "Delivery"
                    Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                    frm1.lbMensagem.Text = "Existe venda em aberto no" & vbCrLf & Status
                    frm1.btnNao.Visible = False
                    frm1.btnSim.Visible = False
                    frm1.btnOK.Visible = True
                    frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm1.ShowDialog()
                    Exit Sub
                End If
            End If
        Else

VerificaVendasBalcao:

            strSql = "SELECT COUNT(IDFechamento) AS Qtde FROM tblFechamentos_Local WHERE Confirmado=0"
            If PegaValorCampo("Qtde", strSql, strCon) = 1 And Clube = False Then

                strSql = "Select IDVenda, FlagFechada, StatusVenda, Excluido "
                strSql += "From tblVendas "
                strSql += "Where (Excluido = 0) And (StatusVenda = 'B') AND (FlagFechada = 0)"

                If NuloInteger(PegaValorCampo("IDVenda", strSql, strCon)) <> 0 Then

                    strSql = "Select tblVendas.IDVenda, tblVendas.FlagFechada, tblVendas.StatusVenda, tblVendas.Excluido, tblVendasMovto.Produto, tblVendasMovto.Excluido As Expr1 "
                    strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
                    strSql += "Where (tblVendasMovto.Excluido = 0) And (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 0) And (tblVendas.StatusVenda = 'B')"
                    If NuloInteger(PegaValorCampo("IDVenda", strSql, strCon)) <> 0 Then

                        frmSplash.Dispose()
                        frmSplash.Close()
                        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                        frm1.lbMensagem.Text = "Existe venda em aberto no Balcão" & vbCrLf & vbCrLf & "Será necessário finalizar ou estornar essa venda para continuar"
                        frm1.btnNao.Visible = False
                        frm1.btnSim.Visible = False
                        frm1.btnOK.Visible = True
                        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm1.ShowDialog()
                        Exit Sub
                    Else
                        strSql = "Select IDVenda, FlagFechada, StatusVenda, Excluido "
                        strSql += "From tblVendas "
                        strSql += "Where (Excluido = 0) And (StatusVenda = 'B') AND (FlagFechada = 0)"

                        Dim IDvdaB As Integer = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))
                        If IDvdaB <> 0 Then
                            strSql = "DELETE FROM tblVendas Where (IDVenda = " & IDvdaB & ")"
                            ExecutaStr(strSql)

                            GoTo VerificaVendasBalcao
                        End If
                    End If
                Else

                    strSql = "Select IDVenda, FlagFechada, StatusVenda, Excluido "
                    strSql += "From tblVendas "
                    strSql += "Where (Excluido = 0) And (StatusVenda = 'B') AND (FlagFechada = 0)"

                    Dim IDvdaB As Integer = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))
                    If IDvdaB <> 0 Then
                        strSql = "DELETE FROM tblVendas Where (IDVenda = " & IDvdaB & ")"
                        ExecutaStr(strSql)

                        GoTo VerificaVendasBalcao
                    End If
                End If
            End If
        End If

        frm.lbMensagem.Text = "Confirma o encerramento do movimento"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub


        frmSplash.Show()
        frmSplash.lbDescricao.Text = "Aguarde... Finalizando o movimento"
        frmSplash.lbDescricao.Refresh()
        frmSplash.PictureBox1.Refresh()
        frmSplash.ProgressBar.Value = 0
        frmSplash.ProgressBar.Refresh()
        frmSplash.Refresh()
        System.Threading.Thread.Sleep(100)


        ConfirmaCaixa(Val(Strings.Right(cbMovto.Text, 10)))


        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ENCERRAMENTO DO MOVTO", Trim(Strings.Left(cbMovto.Text, 51)))
        End If

    End Sub

    Private Sub ckbMovtoAnterior_CheckedChanged(sender As Object, e As EventArgs) Handles ckbMovtoAnterior.CheckedChanged
        If ckbMovtoAnterior.Checked = True Then
            btnRelatorios.Visible = True
            btnConfirma.Enabled = False
            btnVisualizaMovto.Visible = False
            Panel4.Visible = False
            Panel7.Visible = False
            Button1.Visible = False
            tbFundoCaixa.ReadOnly = True
            ckbMovtoAnterior.Text = "Movimento atual"
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "VER MOVTO ATUAL", "")
            End If
        Else
            btnRelatorios.Visible = False
            btnConfirma.Enabled = True
            btnVisualizaMovto.Visible = True
            Panel4.Visible = True
            Panel7.Visible = True
            Button1.Visible = True
            tbFundoCaixa.ReadOnly = False
            ckbMovtoAnterior.Text = "Movimentos anteriores"
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "VER MOVTO ANTERIORES", "")
            End If
        End If
        PreencheMovto()
        PreenchePagtos()
        PreencheVendas()
        If cbMovto.Text <> "" Then
            Panel2.Visible = True
            Panel3.Visible = True
            Panel5.Visible = True
        Else
            Panel2.Visible = False
            Panel3.Visible = False
            Panel5.Visible = False
        End If

    End Sub

    Private Sub btnRelatorios_Click(sender As Object, e As EventArgs) Handles btnRelatorios.Click

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "IMPRIMIU MOVTO", Trim(Strings.Left(cbMovto.Text, 51)))
        End If

        If cbxFinanceiro.Checked = True Then
            CriaRelatFinanceiro(Val(Strings.Right(cbMovto.Text, 10)))
            If ModulosIRIS = "D" And FechamentoDeliveryCamelo = True Then
                CriaRelatFinanceiroDelivery(Val(Strings.Right(cbMovto.Text, 10)))
            Else
                CriaRelatFinanceiro(Val(Strings.Right(cbMovto.Text, 10)))
            End If
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\financeiro.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

            If cbxProdutos.Checked = True Then
            CriaRelatProdutos(Val(Strings.Right(cbMovto.Text, 10)))
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\produtos.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        If cbxServico_Caixinha.Checked = True Then
            CriaRelatServicoCaixinha(Val(Strings.Right(cbMovto.Text, 10)))
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\servico.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        If chkEstornos_Transferencias.Checked = True Then
            CriaRelatEstornosTransferencias(Val(Strings.Right(cbMovto.Text, 10)))
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\estorno.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        ' CriaRelatDelivery(Val(Strings.Right(cbMovto.Text, 10)))


    End Sub

    Private Sub btnVisualizaMovto_Click(sender As Object, e As EventArgs) Handles btnVisualizaMovto.Click
        If OperadorVisualizaVendas = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Sem permissão"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else
            fdlgVisualizaVendas.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click




    End Sub

    Private Sub CbPagtos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPagtos.SelectedIndexChanged
        tbVlrPagto.Focus()
    End Sub

    Private Sub tbVlrPagto_KeyDown(sender As Object, e As KeyEventArgs) Handles tbVlrPagto.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Enter
                Me.InvokeOnClick(btnIncluiPagto, e)

        End Select
    End Sub

    Private Sub TbVlrPlano_TextChanged(sender As Object, e As EventArgs) Handles tbVlrPlano.TextChanged

    End Sub

    Private Sub tbVlrPlano_GotFocus(sender As Object, e As EventArgs) Handles tbVlrPlano.GotFocus
        Foco = "VRC"
    End Sub

    Private Sub tbVlrPlano_Enter(sender As Object, e As EventArgs) Handles tbVlrPlano.Enter
        Foco = "VRC"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        tbDescricaPlano.Text &= "Q"
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        tbDescricaPlano.Text &= "W"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        tbDescricaPlano.Text &= "E"
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        tbDescricaPlano.Text &= "R"
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        tbDescricaPlano.Text &= "T"
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        tbDescricaPlano.Text &= "Y"
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        tbDescricaPlano.Text &= "U"
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        tbDescricaPlano.Text &= "I"
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        tbDescricaPlano.Text &= "O"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        tbDescricaPlano.Text &= "P"
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        tbDescricaPlano.Text &= "A"
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        tbDescricaPlano.Text &= "S"
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        tbDescricaPlano.Text &= "D"
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        tbDescricaPlano.Text &= "F"
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        tbDescricaPlano.Text &= "G"
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        tbDescricaPlano.Text &= "H"
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        tbDescricaPlano.Text &= "J"
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        tbDescricaPlano.Text &= "K"
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        tbDescricaPlano.Text &= "L"
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        tbDescricaPlano.Text = ""
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        tbDescricaPlano.Text &= "Z"
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        tbDescricaPlano.Text &= "X"
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        tbDescricaPlano.Text &= "C"
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        tbDescricaPlano.Text &= "V"
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        tbDescricaPlano.Text &= "B"
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        tbDescricaPlano.Text &= "N"
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        tbDescricaPlano.Text &= "M"
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        tbDescricaPlano.Text &= " "
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        tbDescricaPlano.Text &= "/"
    End Sub

    Private Sub BtnIncluiPlano_Click(sender As Object, e As EventArgs) Handles btnIncluiPlano.Click
        Dim txtSql As String
        If cbMovto.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um movimento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If tbVlrPlano.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If tbVlrPlano.Text = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If Not IsNumeric(tbVlrPlano.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbVlrPagto.Focus()
            Exit Sub
        End If
        If NuloInteger(tbIDPlano1.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Plano de contas 1 inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbPlano1.Focus()
            Exit Sub
        End If
        If NuloInteger(tbIDPlano2.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Plano de contas 2 inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbPlano2.Focus()
            Exit Sub
        End If
        If NuloInteger(tbIDPlano3.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Plano de contas 3 inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbPlano3.Focus()
            Exit Sub
        End If
        If NuloString(tbDescricaPlano.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Descrição inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbPlano3.Focus()
            Exit Sub
        End If

        txtSql = "Select * "
        txtSql += "From tblFormaPagtos_Local "
        txtSql += "Where (Descricao = 'DINHEIRO')"
        Dim conA As New SqlConnection(strCon)
        conA.Open()
        Dim cmdA As New SqlCommand(txtSql, conA)
        cmdA.CommandType = CommandType.Text
        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drA.HasRows Then
            drA.Read()

            Dim ValorBruto As Decimal = NuloDecimal(tbVlrPagto.Text)
            Dim ValorLiquido As Decimal = NuloDecimal(tbVlrPagto.Text)

            strSql = "INSERT tblFechamentosDescricao_Local "
            strSql += "(IDFechamento,IDFormaPagto,Descricao,ValorBruto,IDContaCorrente,IDConta,DataTransferencia,Tipo,ValorLiquido,Diferenca,DataContaReceber,IDConta_Taxa,IDConta_ContraPartida,DescricaoContraPartida) VALUES ("
            strSql += to_sql(NuloInteger(lbIDFechamento.Text)) & ","
            strSql += to_sql(drA.Item("IDFormaPagto")) & ","
            strSql += to_sql(NuloString(Strings.Left(UCase(tbDescricaPlano.Text), 30))) & ","
            strSql += to_sql(Replace(NuloDecimal(tbVlrPlano.Text), ",", ".")) & ","
            strSql += "0,"
            strSql += to_sql(NuloInteger(tbIDPlano3.Text)) & ","
            strSql += to_sqlDATA(tbDiaMovto.Text, "data", "L") & ", "
            If tbTipoPlano.Text = "D" Then
                strSql += "'LD', "
            Else
                strSql += "'LR', "
            End If
            strSql += to_sql(Replace(NuloDecimal(tbVlrPagto.Text), ",", ".")) & ","
            strSql += "0, "
            strSql += to_sqlDATA(tbDiaMovto.Text, "data", "L") & ", "
            strSql += "0,"
            strSql += "0, "
            strSql += "'')"
            ExecutaStr(strSql)
        End If
        cmdA.Dispose()
        drA.Close()
        conA.Dispose()
        conA.Close()


        ' Imprime recibo  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        CriaRelatReciboDespesas()
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\financeiro.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If



        tbVlrPlano.Text = ""
        tbDescricaPlano.Text = ""
        PreencheLista(Val(Strings.Right(cbMovto.Text, 8)))
    End Sub

    Private Sub CbPlano1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlano1.SelectedIndexChanged
        tbIDPlano1.Text = NuloInteger(Strings.Right(NuloString(cbPlano1.Text), 8))

        strSql = "Select IDPlanoConta, Tipo "
        strSql += "From tblPlanoContas "
        strSql += "Where (IDPlanoConta = " & NuloInteger(tbIDPlano1.Text) & ") "
        tbTipoPlano.Text = NuloString(PegaValorCampo("Tipo", strSql, strConServer))
        PreenchePlano2()
    End Sub

    Private Sub CbPlano2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlano2.SelectedIndexChanged
        tbIDPlano2.Text = NuloInteger(Strings.Right(NuloString(cbPlano2.Text), 8))
        PreenchePlano3()
    End Sub

    Private Sub CbPlano3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlano3.SelectedIndexChanged
        tbIDPlano3.Text = NuloInteger(Strings.Right(NuloString(cbPlano3.Text), 8))

    End Sub

    Private Sub cbPagtos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbPagtos.KeyPress

    End Sub

    Private Sub TbDescricaPlano_TextChanged(sender As Object, e As EventArgs) Handles tbDescricaPlano.TextChanged

    End Sub

    Private Sub tbDescricaPlano_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescricaPlano.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbVlrPlano.Focus()
        End If

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        frmPendencias.ShowDialog()
    End Sub

    Private Sub LstLanctos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLanctos.SelectedIndexChanged

    End Sub

    Private Sub CbxFinanceiro_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFinanceiro.CheckedChanged
        cbxFinanceiro.Checked = True
    End Sub

    Private Sub ChkEstornos_Transferencias_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstornos_Transferencias.CheckedChanged
        If picRelatEstornos.Visible = True Then
            chkEstornos_Transferencias.Checked = True
        End If
    End Sub

    Private Sub CbxServico_Caixinha_CheckedChanged(sender As Object, e As EventArgs) Handles cbxServico_Caixinha.CheckedChanged
        If picRelatServico.Visible = True Then
            cbxServico_Caixinha.Checked = True
        End If
    End Sub

    Private Sub CbxProdutos_CheckedChanged(sender As Object, e As EventArgs) Handles cbxProdutos.CheckedChanged
        If picRelatProdutos.Visible = True Then
            cbxProdutos.Checked = True
        End If
    End Sub

    Private Sub btnFechamentoDelivery_Click(sender As Object, e As EventArgs) Handles btnFechamentoDelivery.Click

        If NuloString(lbIDFechamento.Text) <> "" Then
            fdlgDeliveryEspecial.ShowDialog()
        End If

    End Sub

    Private Sub btnManutencao_Click(sender As Object, e As EventArgs) Handles btnManutencao.Click
        fdlgManutencaoCaixa.ShowDialog()
    End Sub
End Class