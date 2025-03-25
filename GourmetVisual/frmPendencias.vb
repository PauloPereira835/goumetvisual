Imports System.Data.SqlClient

Public Class frmPendencias
    Public Foco As String
    Private Sub CriaRelatExtrato(IDcli As Integer)
        Dim conS As New SqlConnection()
        Dim drS As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim conexao As String = strConServer
        Dim IDfec As Integer
        Dim vlrTotal As Decimal = 0
        Dim vlrCaixinha As Decimal = 0
        Dim vlrServico As Decimal = 0
        Dim vlrTxEntrega As Decimal = 0
        Dim vlrDesconto As Decimal = 0
        Dim tamanho As Integer


        ' Serviço e Caixinha /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'conS.ConnectionString = conexao
        conS.ConnectionString = strCon
        Dim cmdS As SqlCommand = conS.CreateCommand

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\pendencia.txt", OpenMode.Output)

        strSql = "Select IDVendaRet, IDPendencia, Data, IDCliente, Valor, Descricao, Saldo, IDLoja "
        strSql += "From tblPendenciasLoja "
        strSql += "WHERE (IDCliente = " & IDcli & ") AND (IDLoja = " & IDLoja & ") AND (Data BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        strSql += "ORDER BY tblPendenciasLoja.Data"

        cmdS.CommandText = strSql
        conS.Open()
        drS = cmdS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drS.HasRows Then

            texto = ""
            PrintLine(lngFile, "MOVIMENTACAO NO PERIODO")
            PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, "CLIENTE    : " & lstClientes.SelectedItems(0).SubItems(1).Text)
            PrintLine(lngFile, "Periodo    : " & dtInicio.Value.ToString("dd/MM/yyyy"))
            PrintLine(lngFile, "             " & Format(dtFim.Value, "dd/MM/yyyy"))
            PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, "Data        Descricao             Valor ")
            PrintLine(lngFile, "========================================")
            While drS.Read
                tamanho = NuloInteger(Len(Trim(Strings.Left(drS.Item("Descricao"), 17))))
                texto = drS.Item("Data") & "  "
                texto += Trim(Strings.Left(drS.Item("Descricao"), 17)) & Space(18 - tamanho)
                texto += Space(10 - Len(Format(drS.Item("Valor"), "#0.00"))) & Format(drS.Item("Valor"), "#0.00")
                PrintLine(lngFile, texto)
                vlrTotal += NuloDecimal(drS.Item("Valor"))
            End While
            PrintLine(lngFile, "----------------------------------------")
            texto = "Total                       "
            texto += Space(12 - Len(vlrTotal.ToString("#0.00"))) & vlrTotal.ToString("#0.00")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "========================================")

        End If
        cmdS.Dispose()
        drS.Close()
        conS.Dispose()
        conS.Close()
        'PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")




        strSql = "Select tblPendencias.IDPendencia, tblPendencias.IDCliente, tblPendencias.Data, tblPendencias.IDVendaRet, tblRetVendasMovto.Produto, tblRetVendasMovto.Qtd, tblRetVendasMovto.Venda, tblRetVendas.Desconto, tblRetVendas.Servico, tblRetVendas.Caixinha, tblRetVendas.TaxaEntrega, tblRetVendas.IDLoja "
        strSql += "From tblPendencias INNER Join tblRetVendas On tblPendencias.IDVendaRet = tblRetVendas.IDVendaRet INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet "
        strSql += "WHERE (tblPendencias.IDCliente = " & IDcli & ") AND (tblRetVendas.IDLoja = " & IDLoja & ") AND (tblPendencias.Data BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        strSql += "ORDER BY tblPendencias.Data, tblPendencias.IDVendaRet"

        vlrTotal = 0
        tamanho = 0
        texto = ""

        Dim dap = New SqlDataAdapter(strSql, conexao)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vda")


        Dim DtMovto As Date
        Dim VlrDt As Decimal
        Dim VlrProduto As Decimal
        Dim ID As Integer

        PrintLine(lngFile, "MOVIMENTACAO DE PRODUTOS")
        PrintLine(lngFile, "----------------------------------------")
        PrintLine(lngFile, "Produtos               Qtde       Valor ")
        PrintLine(lngFile, "========================================")
        For i As Integer = 0 To ds.Tables("Vda").Rows.Count - 1
            ID = ds.Tables("Vda").Rows(i).Item("IDVendaRet")
            DtMovto = ds.Tables("Vda").Rows(i).Item("Data")

            vlrCaixinha = NuloDecimal(ds.Tables("Vda").Rows(i).Item("Caixinha"))
            vlrServico = NuloDecimal(ds.Tables("Vda").Rows(i).Item("Servico"))
            vlrTxEntrega = NuloDecimal(ds.Tables("Vda").Rows(i).Item("TaxaEntrega"))
            vlrDesconto = NuloDecimal(ds.Tables("Vda").Rows(i).Item("Desconto"))

            VlrDt = 0
            PrintLine(lngFile, Space(40 - Len(Format(ds.Tables("Vda").Rows(i).Item("Data"), "dd/MM/yyyy"))) & Format(ds.Tables("Vda").Rows(i).Item("Data"), "dd/MM/yyyy"))

            While ID = ds.Tables("Vda").Rows(i).Item("IDVendaRet")
                VlrProduto = NuloDecimal(ds.Tables("Vda").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vda").Rows(i).Item("Venda"))
                tamanho = NuloInteger(Len(Trim(Strings.Left(ds.Tables("Vda").Rows(i).Item("Produto"), 20))))
                texto = Trim(Strings.Left(ds.Tables("Vda").Rows(i).Item("Produto"), 20)) & Space(21 - tamanho)
                texto += Space(6 - Len(Format(ds.Tables("Vda").Rows(i).Item("Qtd"), "#0.000"))) & Format(ds.Tables("Vda").Rows(i).Item("Qtd"), "#0.000")
                texto += Space(13 - Len(Format(VlrProduto, "#0.00"))) & Format(VlrProduto, "#0.00")
                PrintLine(lngFile, texto)
                VlrDt += NuloDecimal(VlrProduto)

                If i + 1 > ds.Tables("Vda").Rows.Count - 1 Then Exit While
                If ID <> ds.Tables("Vda").Rows(i + 1).Item("IDVendaRet") Then Exit While
                i += 1
            End While
            PrintLine(lngFile, "----------------------------------------")
            texto = "Total produtos "
            texto += Space(25 - Len(VlrDt.ToString("#0.00"))) & VlrDt.ToString("#0.00")
            PrintLine(lngFile, texto)
            texto = "Desconto       "
            texto += Space(25 - Len(vlrDesconto.ToString("#0.00"))) & vlrDesconto.ToString("#0.00")
            PrintLine(lngFile, texto)
            texto = "Servico        "
            texto += Space(25 - Len(vlrServico.ToString("#0.00"))) & vlrServico.ToString("#0.00")
            PrintLine(lngFile, texto)
            texto = "Caixinha       "
            texto += Space(25 - Len(vlrCaixinha.ToString("#0.00"))) & vlrCaixinha.ToString("#0.00")
            PrintLine(lngFile, texto)
            texto = "Tx. entrega    "
            texto += Space(25 - Len(vlrTxEntrega.ToString("#0.00"))) & vlrTxEntrega.ToString("#0.00")
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "                             ----------- ")
            VlrDt += vlrCaixinha + vlrServico + vlrTxEntrega - vlrDesconto
            texto = "TOTAL " & DtMovto.ToString("dd/MM/yyyy")
            texto += Space(24 - Len(VlrDt.ToString("#0.00"))) & VlrDt.ToString("#0.00")
            vlrTotal += VlrDt
            PrintLine(lngFile, texto)
            PrintLine(lngFile, " ")

        Next
        texto = "Total                       "
        texto += Space(12 - Len(vlrTotal.ToString("#0.00"))) & vlrTotal.ToString("#0.00")
        PrintLine(lngFile, texto)
        PrintLine(lngFile, "========================================")

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")


        FileClose(lngFile)

    End Sub
    Private Sub PreencheLanctos(IDcli As Integer)

        Dim item As ListViewItem
        Dim QtdeCli As Integer = 0
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select tblPendenciasLoja.IDPendencia, tblPendenciasLoja.IDCliente, tblPendenciasLoja.Data, tblPendenciasLoja.Valor, tblPendenciasLoja.Descricao, tblFormaPagtos_Local.Descricao As FormaPagto, tblPendenciasLoja.Saldo, tblPendenciasLoja.IDVendaRet, tblPendenciasLoja.IDVendaRetPagto, tblPendenciasLoja.Lancado "
        strSql += "From tblPendenciasLoja LEFT OUTER Join tblFormaPagtos_Local On tblPendenciasLoja.IDFormaPagto = tblFormaPagtos_Local.IDFormaPagto "
        strSql += "WHERE (IDCliente = " & IDcli & ") AND (Data BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        strSql += "Order By tblPendenciasLoja.Data, tblPendenciasLoja.IDPendencia"


        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        lstLanctos.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                item = lstLanctos.Items.Add(dr.Item("IDPendencia"))
                item.SubItems.Add(NuloString(Format(dr.Item("Data"), "dd/MM/yyyy")))
                item.SubItems.Add(NuloString(dr.Item("FormaPagto")))
                item.SubItems.Add(NuloString(dr.Item("Descricao")))
                item.SubItems.Add(NuloDecimal(dr.Item("Valor")))
                item.SubItems.Add(NuloDecimal(dr.Item("Saldo")))
                item.SubItems.Add(NuloInteger(dr.Item("IDVendaRet")))
                item.SubItems.Add(NuloInteger(dr.Item("IDVendaRetPagto")))
                item.SubItems.Add(NuloBoolean(dr.Item("Lancado")))
                QtdeCli += 1
            End While
            lstLanctos.Update()
            lstLanctos.EndUpdate()
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
        If QtdeCli <> 0 Then
            lbQtdeLanc.Text = "   (Qtde.: " & QtdeCli & ")"
        Else
            lbQtdeLanc.Text = ""
        End If

    End Sub
    Private Sub PreencheClientes()
        Dim item As ListViewItem
        Dim QtdeCli As Integer = 0
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select IDCliente, NomeCliente, Tel1, SaldoNegativo, SaldoCredito "
        strSql += "From tblClientes "
        If tbBusca.Text <> "" Then
            If Not IsNumeric(tbBusca.Text) Then
                strSql += "WHERE (NomeCliente LIKE '%" & tbBusca.Text & "%') "
            Else
                strSql += "WHERE (Tel1 LIKE '%" & tbBusca.Text & "%') "
            End If
            If chkPermiteSaldoNegativo.Checked = True Then
                strSql += "And (SaldoNegativo=1) "
            Else
                strSql += "And (SaldoNegativo=0) "
            End If
        Else
            If chkPermiteSaldoNegativo.Checked = True Then
                strSql += "WHere (SaldoNegativo=1) "
            Else
                strSql += "Where (SaldoNegativo=0) "
            End If
        End If
        strSql += "Order By NomeCliente"

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        lstClientes.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                item = lstClientes.Items.Add(dr.Item("IDCliente"))
                item.SubItems.Add(NuloString(dr.Item("NomeCliente")))
                item.SubItems.Add(NuloString(dr.Item("Tel1")))
                item.SubItems.Add(NuloBoolean(dr.Item("SaldoNegativo")))
                item.SubItems.Add(NuloDecimal(dr.Item("SaldoCredito")))
                QtdeCli += 1
            End While
            lstClientes.Update()
            lstClientes.EndUpdate()
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
        lbQtdeClientes.Text = QtdeCli
    End Sub
    Private Sub FrmPendencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtInicio.Value = Now.AddDays(-DatePart(DateInterval.Day, Today) + 1)
        dtFim.Value = Now

        chkPermiteSaldoNegativo.Checked = True
        PreencheClientes()

        btnAlterarCliente.Enabled = False
    End Sub

    Private Sub TbCliente_TextChanged(sender As Object, e As EventArgs) Handles tbCliente.TextChanged
        btnAlterarCliente.Enabled = True
    End Sub

    Private Sub TbTel1_TextChanged(sender As Object, e As EventArgs) Handles tbTel1.TextChanged
        btnAlterarCliente.Enabled = True
    End Sub

    Private Sub ChkSaldoNegativo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaldoNegativo.CheckedChanged
        btnAlterarCliente.Enabled = True
    End Sub
    Private Sub CliqueNoBotao(texto As String)

        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Cliente inválido"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            Exit Sub
        End If

        If Foco = "B" Then
            tbBusca.Text &= texto
        End If
        If Foco = "C" Then
            tbCliente.Text &= texto
        End If
        If Foco = "T" Then
            tbTel1.Text &= texto
        End If
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        If btnAlterarCliente.Enabled = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar as alterações"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                Exit Sub
            End If
        End If
        'PreencheClientes()
    End Sub

    Private Sub tbBusca_Enter(sender As Object, e As EventArgs) Handles tbBusca.Enter
        Foco = "B"
    End Sub

    Private Sub tbCliente_Enter(sender As Object, e As EventArgs) Handles tbCliente.Enter
        Foco = "C"
    End Sub

    Private Sub tbTel1_Enter(sender As Object, e As EventArgs) Handles tbTel1.Enter
        Foco = "T"
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

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        CliqueNoBotao("4")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CliqueNoBotao("5")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CliqueNoBotao("6")
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        CliqueNoBotao("9")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        CliqueNoBotao("Q")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CliqueNoBotao("W")
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CliqueNoBotao("E")
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        CliqueNoBotao("R")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CliqueNoBotao("T")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CliqueNoBotao("Y")
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        CliqueNoBotao("U")
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CliqueNoBotao("I")
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        CliqueNoBotao("O")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CliqueNoBotao("P")
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        CliqueNoBotao("A")
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        CliqueNoBotao("S")
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        CliqueNoBotao("D")
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        CliqueNoBotao("F")
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        CliqueNoBotao("G")
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        CliqueNoBotao("H")
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        CliqueNoBotao("J")
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        CliqueNoBotao("K")
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        CliqueNoBotao("L")
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        CliqueNoBotao("Z")
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        CliqueNoBotao("X")
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        CliqueNoBotao("C")
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        CliqueNoBotao("V")
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        CliqueNoBotao("B")
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        CliqueNoBotao("N")
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        CliqueNoBotao("M")
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        CliqueNoBotao(" ")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CliqueNoBotao("-")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Cliente inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            Exit Sub
        End If
        If Foco = "B" Then
            tbBusca.Text = ""
        End If
        If Foco = "C" Then
            tbCliente.Text = ""
        End If
        If Foco = "T" Then
            tbTel1.Text = ""
        End If
    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        If btnAlterarCliente.Enabled = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja sair sem confirmar as alterações"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then Exit Sub
        End If

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BtnIncluirCliente_Click(sender As Object, e As EventArgs) Handles btnIncluirCliente.Click

        If btnAlterarCliente.Enabled = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar as alterações"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub
        End If
        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma a inclusão de um novo cliente"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        strSql = "INSERT tblClientes "
        strSql += "(IDLoja, NomeCliente, IDRua, Numero, Complemento, Referencia, CEP, Area, Cidade, Estado, Tel1, Tel2, ComplementoTel, Origem, DataCadastro, StatusCliente, DataAtualizacao, Responsavel, SaldoCredito, SaldoNegativo, DDD1, DDD2, CPF_CNPJ, IDExterno, Observacao) VALUES ("
        strSql += to_sql(IDLoja) & ","
        strSql += "'',"
        strSql += "0,"
        strSql += "'',"
        strSql += "'',"
        strSql += "'',"
        strSql += "'',"
        strSql += "'',"
        strSql += to_sql(NuloString(UCase(CidadeLoja))) & ","
        strSql += to_sql(NuloString(UCase(EstadoLoja))) & ","
        strSql += "'',"
        strSql += "'',"
        strSql += "'',"
        strSql += "'LOJA',"
        strSql += "'" & Now & "',"
        strSql += "'A',"
        strSql += "'" & Now & "',"
        strSql += to_sql(NuloString(UCase(Operador))) & ","
        strSql += "0,"
        strSql += "0,"
        strSql += to_sql(DDD_Padrao) & ","
        strSql += to_sql(DDD_Padrao) & ","
        strSql += "'',"
        strSql += "'',"
        strSql += "'')"
        ExecutaStr(strSql)

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "PENDENCIA", "INCLUIU CLIENTE")
        End If

        tbIDCliente.Text = NuloInteger(PegaID("IDCliente", "tblClientes", "L"))
        tbCliente.Text = ""
        tbTel1.Text = ""
        lbSaldo.Text = ""
        chkSaldoNegativo.Checked = False

        tbBusca.Text = ""
        PreencheClientes()

        tbCliente.Focus()
    End Sub

    Private Sub BtnAlterarCliente_Click(sender As Object, e As EventArgs) Handles btnAlterarCliente.Click
        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "È necessário selecionar um cliente"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            Exit Sub
        End If

        strSql = "UPDATE tblClientes SET "
        strSql &= "NomeCliente ='" & UCase(NuloString(tbCliente.Text)) & "', "
        strSql &= "Tel1 ='" & UCase(NuloString(Replace(tbTel1.Text, "-", ""))) & "', "
        strSql &= "SaldoNegativo ='" & NuloBoolean(chkSaldoNegativo.Checked) & "', "
        strSql &= "Atualiza=1 "
        strSql &= "WHERE (IDCliente=" & tbIDCliente.Text & ")"
        ExecutaStr(strSql)
        tbCliente.Focus()
        btnAlterarCliente.Enabled = False

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "PENDENCIA", "ALTEROU CLIENTE: " & UCase(NuloString(tbCliente.Text)))
        End If

        PreencheClientes()

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Informações alteradas com sucesso!!!"
        frm.btnNao.Visible = False
        frm.btnSim.Visible = False
        frm.btnOK.Visible = True
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()

    End Sub

    Private Sub LstClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClientes.SelectedIndexChanged

    End Sub

    Private Sub lstClientes_Click(sender As Object, e As EventArgs) Handles lstClientes.Click
        If lstClientes.SelectedItems.Count > 0 Then
            If btnAlterarCliente.Enabled = True Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Deseja continuar sem confirmar as alterações"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = False Then
                    tbBusca.Text = ""
                    lstClientes.SelectedItems.Clear()
                    Exit Sub
                End If
            End If

            tbIDCliente.Text = NuloInteger(lstClientes.SelectedItems(0).SubItems(0).Text)
            tbCliente.Text = NuloString(lstClientes.SelectedItems(0).SubItems(1).Text)
            tbTel1.Text = NuloString(lstClientes.SelectedItems(0).SubItems(2).Text)
            chkSaldoNegativo.Checked = NuloBoolean(lstClientes.SelectedItems(0).SubItems(3).Text)
            lbSaldo.Text = NuloDecimal(lstClientes.SelectedItems(0).SubItems(4).Text)

            PreencheLanctos(NuloInteger(tbIDCliente.Text))

            btnAlterarCliente.Enabled = False
        End If
    End Sub

    Private Sub BtnExcluirCliente_Click(sender As Object, e As EventArgs) Handles btnExcluirCliente.Click
        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "È necessário selecionar um cliente"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            Exit Sub
        End If

        If btnAlterarCliente.Enabled = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar as alterações"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub
        End If
        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma a EXCLUSÃO do cliente"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "PENDENCIA", "EXCLUIU CLIENTE: " & NuloString(tbCliente.Text) & ")")
        End If

        strSql = "DELETE tblClientes "
        strSql &= "WHERE (IDCliente=" & tbIDCliente.Text & ")"
        ExecutaStr(strSql)

        strSql = "DELETE tblPendenciasLoja "
        strSql &= "WHERE (IDCliente=" & tbIDCliente.Text & ")"
        ExecutaStr(strSql)

        tbCliente.Focus()
        btnAlterarCliente.Enabled = False

        tbIDCliente.Text = ""
        tbCliente.Text = ""
        tbTel1.Text = ""
        lbSaldo.Text = ""
        chkSaldoNegativo.Checked = False

        PreencheClientes()
        lstLanctos.Items.Clear()
        btnAlterarCliente.Enabled = False

    End Sub

    Private Sub BtnIncluirLancto_Click(sender As Object, e As EventArgs) Handles btnIncluirLancto.Click


        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "È necessário selecionar um cliente"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm1.ShowDialog()
            Exit Sub
        End If

        fdlgPendencias_LanctoInclusao.ShowDialog()
        PreencheLanctos(NuloInteger(tbIDCliente.Text))
        lbSaldo.Text = NuloDecimal(SaldoPendencia(NuloInteger(tbIDCliente.Text)))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lbSaldo.Text = NuloDecimal(SaldoPendencia(NuloInteger(tbIDCliente.Text)))
        PreencheLanctos(NuloInteger(tbIDCliente.Text))
    End Sub

    Private Sub DtInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio.ValueChanged
        PreencheLanctos(NuloInteger(tbIDCliente.Text))
    End Sub

    Private Sub DtFim_ValueChanged(sender As Object, e As EventArgs) Handles dtFim.ValueChanged
        PreencheLanctos(NuloInteger(tbIDCliente.Text))
    End Sub

    Private Sub BtnExcluirLancto_Click(sender As Object, e As EventArgs) Handles btnExcluirLancto.Click

        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "È necessário selecionar um cliente"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            Exit Sub
        End If

        If lstLanctos.SelectedItems.Count <= 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um lançamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma a EXCLUSÃO do lançamento"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "PENDENCIA", "EXCLUIU LANCTO: " & NuloString(lstLanctos.SelectedItems(0).SubItems(2).Text) & " (" & NuloDecimal(lstLanctos.SelectedItems(0).SubItems(4).Text) & ")")
        End If

        If NuloBoolean(lstLanctos.SelectedItems(0).SubItems(8).Text) = False Then
            strSql = "DELETE tblVendasPagto "
            strSql &= "WHERE (IDVendaPagto=" & NuloInteger(lstLanctos.SelectedItems(0).SubItems(7).Text) & ")"
            ExecutaStr(strSql)
        Else
            strSql = "DELETE tblRetVendasPagto "
            strSql &= "WHERE (IDVendaRetPagto=" & NuloInteger(lstLanctos.SelectedItems(0).SubItems(7).Text) & ")"
            ExecutaStrServidor(strSql)
        End If

        strSql = "DELETE tblPendenciasLoja "
        strSql &= "WHERE (IDPendencia=" & NuloInteger(lstLanctos.SelectedItems(0).SubItems(0).Text) & ")"
        ExecutaStr(strSql)

        PreencheLanctos(NuloInteger(tbIDCliente.Text))
        lbSaldo.Text = NuloDecimal(SaldoPendencia(NuloInteger(tbIDCliente.Text)))



    End Sub

    Private Sub LstLanctos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLanctos.SelectedIndexChanged
        If lstLanctos.SelectedItems.Count > 0 Then
            tbIDVendaRet.Text = NuloInteger(lstLanctos.SelectedItems(0).SubItems(6).Text)
        End If
    End Sub

    Private Sub BtnRelatorios_Click(sender As Object, e As EventArgs) Handles btnRelatorios.Click

        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "È necessário selecionar um cliente"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            Exit Sub
        End If

        CriaRelatExtrato(NuloInteger(tbIDCliente.Text))
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\pendencia.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If

    End Sub

    Private Sub ChkPermiteSaldoNegativo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPermiteSaldoNegativo.CheckedChanged
        PreencheClientes()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PreencheClientes()
    End Sub
End Class