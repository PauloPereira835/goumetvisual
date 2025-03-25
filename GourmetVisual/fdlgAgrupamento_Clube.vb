Imports System.Data.SqlClient
Imports System.IO
Imports GourmetVisual.IfoodMerchantOrderResponse

Public Class fdlgAgrupamento_Clube
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgAgrupamento_Clube_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MontaAgrupamentos()
        VerificaVendas()


    End Sub
    Private Sub VerificaVendas()

        Dim Retorno As String
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        SqlStr = "Select IDAgrupamento, IDVenda "
        SqlStr += "From tblAgrupamentoDescricao_Clube"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While (dr.Read())
                strSql = "SELECT IDVenda, FlagFechada FROM tblVendas WHERE IDVenda = " & dr.Item("IDVenda")
                Retorno = PegaValorCampo("FlagFechada", strSql, strCon)
                If Retorno = "ERRO" Or Retorno = "" Then
                    ExecutaStr("DELETE FROM tblAgrupamentoDescricao_Clube WHERE (IDVenda = " & dr.Item("IDVenda") & ")")
                End If
                If NuloBoolean(PegaValorCampo("FlagFechada", strSql, strCon)) = True Then
                    ExecutaStr("DELETE FROM tblAgrupamentoDescricao_Clube WHERE (IDVenda = " & dr.Item("IDVenda") & ")")
                End If
            Loop
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

    End Sub
    Private Sub MontaContas()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        lvContas.Items.Clear()

        SqlStr = "Select tblVendas.IDVenda, tblVendas.NomeCliente, tblVendas.FlagFechada, tblVendas.Excluido, tblAgrupamento_Clube.Descricao "
        SqlStr += "From tblAgrupamento_Clube INNER Join tblAgrupamentoDescricao_Clube On tblAgrupamento_Clube.IDAgrupamento = tblAgrupamentoDescricao_Clube.IDAgrupamento RIGHT OUTER Join tblVendas On tblAgrupamentoDescricao_Clube.IDVenda = tblVendas.IDVenda "
        SqlStr += "Where (tblVendas.FlagFechada = 0) And (tblVendas.Excluido = 0) And (Not (tblVendas.NomeCliente Is NULL)) "
        If NuloString(tbBuscaClientes.Text) <> "" Then
            SqlStr += "And (tblVendas.NomeCliente Like '" & tbBuscaClientes.Text & "%') "
        End If
        SqlStr += "Order By tblVendas.NomeCliente"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While (dr.Read())
                If NuloString(dr.Item("Descricao")) = "" Then
                    lvContas.Items.Add(New ListViewItem({dr.Item("IDVenda"), dr.Item("NomeCliente")}))
                End If
            Loop
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        fdlgAgrupamentoNovo_Clube.ShowDialog()
        MontaAgrupamentos()
    End Sub

    Private Sub MontaAgrupamentos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        lvAgrupamentos.Items.Clear()

        SqlStr = "Select IDAgrupamento, Descricao "
        SqlStr += "From tblAgrupamento_Clube "
        SqlStr += "Order By Descricao"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While (dr.Read())
                lvAgrupamentos.Items.Add(New ListViewItem({dr.Item("IDAgrupamento"), dr.Item("Descricao")}))
            Loop
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

    End Sub

    Private Sub lvAgrupamentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvAgrupamentos.SelectedIndexChanged
        If lvAgrupamentos.SelectedItems.Count > 0 Then
            lbIDAgrupamento.Text = lvAgrupamentos.SelectedItems(0).Text
            lbAgrupamento.Text = lvAgrupamentos.SelectedItems(0).SubItems(1).Text

            MontaContas()
            PreencheAgrupamentos()
        End If
    End Sub

    Private Sub btnMais_Click(sender As Object, e As EventArgs) Handles btnMais.Click

        If lvAgrupamentos.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um agrupamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lvAgrupamentos.Focus()
            Exit Sub
        End If
        If lvContas.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma conta"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lvContas.Focus()
            Exit Sub
        End If

        strSql = "INSERT tblAgrupamentoDescricao_Clube "
        strSql += "(IDAgrupamento, IDVenda) VALUES ("
        strSql += to_sql(lbIDAgrupamento.Text) & ", "
        strSql += to_sql(lvContas.SelectedItems(0).Text) & ")"
        ExecutaStr(strSql)

        MontaContas()
        PreencheAgrupamentos()

    End Sub

    Private Sub PreencheAgrupamentos()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        lvAgrupadas.Items.Clear()

        SqlStr = "Select tblAgrupamentoDescricao_Clube.IDAgrupamento, tblAgrupamentoDescricao_Clube.IDVenda, tblVendas.NomeCliente "
        SqlStr += "From tblAgrupamentoDescricao_Clube INNER Join tblVendas On tblAgrupamentoDescricao_Clube.IDVenda = tblVendas.IDVenda "
        SqlStr += "Where (tblAgrupamentoDescricao_Clube.IDAgrupamento = " & lbIDAgrupamento.Text & ")"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While (dr.Read())
                lvAgrupadas.Items.Add(New ListViewItem({dr.Item("IDAgrupamento"), dr.Item("NomeCliente"), dr.Item("IDVenda")}))
            Loop
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()
    End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click

        If lvAgrupamentos.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um agrupamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lvAgrupamentos.Focus()
            Exit Sub
        End If
        If lvAgrupadas.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma conta"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lvAgrupadas.Focus()
            Exit Sub
        End If

        strSql = "DELETE FROM tblAgrupamentoDescricao_Clube WHERE (IDVenda = " & lvAgrupadas.SelectedItems(0).SubItems(2).Text & ")"
        ExecutaStr(strSql)

        MontaContas()
        PreencheAgrupamentos()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        If lvAgrupamentos.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um agrupamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lvAgrupamentos.Focus()
            Exit Sub
        End If

        CriaImpressaoContaAgrupada(lbIDAgrupamento.Text)

    End Sub
    Private Sub CriaImpressaoContaAgrupada(IDagrup As Integer)
        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim VlrPro As Decimal = 0
        Dim VlrProTxt As String
        con.ConnectionString = strCon

        strSql = "Select tblAgrupamentoDescricao_Clube.IDAgrupamento, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Venda, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.CEP, tblLojas_Local.Telefone "
        strSql += "From tblAgrupamentoDescricao_Clube INNER Join tblVendasMovto On tblAgrupamentoDescricao_Clube.IDVenda = tblVendasMovto.IDVenda CROSS Join tblLojas_Local "
        strSql += "Group BY tblAgrupamentoDescricao_Clube.IDAgrupamento, tblVendasMovto.Produto, tblVendasMovto.Venda, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.CEP, tblLojas_Local.Telefone "
        strSql += "HAVING(tblAgrupamentoDescricao_Clube.IDAgrupamento = " & IDagrup & ") "
        strSql += "Order BY tblVendasMovto.Produto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "Agrupamento:  " & Chr(27) + Chr(14) & lbAgrupamento.Text & Chr(27) + Chr(14))
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")))
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Endereco"))) & "," & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Numero")))
            PrintLine(lngFile, texto)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("CEP"))) & "  -  " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Telefone")))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "           CONFERENCIA DE CONTA")
            PrintLine(lngFile, "    Controle interno sem valor fiscal")
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

                i += 1
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, "==========================================")
            VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")
            PrintLine(lngFile, "TOTAL " & Space(36 - Len(VlrProTxt)) & VlrProTxt)
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

        ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\conta.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If lvAgrupamentos.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um agrupamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lvAgrupamentos.Focus()
            Exit Sub
        End If

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma o exclusão deste agrupamento"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then
            Exit Sub
        End If

        strSql = "DELETE FROM tblAgrupamentoDescricao_Clube WHERE (IDAgrupamento = " & lbIDAgrupamento.Text & ")"
        ExecutaStr(strSql)

        strSql = "DELETE FROM tblAgrupamento_Clube WHERE (IDAgrupamento = " & lbIDAgrupamento.Text & ")"
        ExecutaStr(strSql)

        MontaAgrupamentos()
        VerificaVendas()

        lvContas.Items.Clear()
        lvAgrupadas.Items.Clear()
        lbIDAgrupamento.Text = ""
        lbAgrupamento.Text = ""

    End Sub

    Private Sub btnCartaoCredito_Click(sender As Object, e As EventArgs) Handles btnCartaoCredito.Click
        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma o fechamento desta conta"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then
            Exit Sub
        End If
        FechaVenda("CartaoCredito")
    End Sub

    Private Sub FechaVenda(FormaPagto As String)

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        If NuloInteger(IDFechamento) = 0 Then
            frm1.lbMensagem.Text = "É necessário abrir um movimento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            Exit Sub
        End If
        If lvAgrupamentos.SelectedItems.Count = 0 Then
            frm1.lbMensagem.Text = "É necessario selecionar um agrupamento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            Exit Sub
        End If

        Dim IDFormaPagto As Integer = 0
        Dim Descricao As String = ""
        If FormaPagto = "CartaoCredito" Then
            Descricao = "CARTAO CREDITO"
            strSql = "SELECT IDFormaPagto, Descricao FROM tblFormaPagtos_Local WHERE Descricao = 'CARTAO CREDITO'"
            IDFormaPagto = PegaValorCampo("IDFormaPagto", strSql, strCon)
        End If
        If FormaPagto = "CartaoDebito" Then
            Descricao = "CARTAO DEBITO"
            strSql = "SELECT IDFormaPagto, Descricao FROM tblFormaPagtos_Local WHERE Descricao = 'CARTAO DEBITO'"
            IDFormaPagto = PegaValorCampo("IDFormaPagto", strSql, strCon)
        End If
        If FormaPagto = "Dinheiro" Then
            Descricao = "DINHEIRO"
            strSql = "SELECT IDFormaPagto, Descricao FROM tblFormaPagtos_Local WHERE Descricao = 'DINHEIRO'"
            IDFormaPagto = PegaValorCampo("IDFormaPagto", strSql, strCon)
        End If

        Dim IDvda As Integer = 0
        Dim VlrTotal As Decimal = 0
        strSql = "Select IDAgrupamento, IDVenda "
        strSql += "From tblAgrupamentoDescricao_Clube "
        strSql += "Where (IDAgrupamento = " & lbIDAgrupamento.Text & ")"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If i = 0 Then
                IDvda = ds.Tables("Vendas").Rows(i).Item("IDVenda")
            End If

            strSql = "Select Qtd, Venda, IDVenda, Excluido "
            strSql += "From tblVendasMovto "
            strSql += "Where (Excluido = 0) And (IDVenda = " & ds.Tables("Vendas").Rows(i).Item("IDVenda") & ")"

            Dim dapP = New SqlDataAdapter(strSql, strCon)
            dapP.SelectCommand.CommandType = CommandType.Text
            Dim dsP As New DataSet()
            dapP.Fill(dsP, "pro")

            For ii As Integer = 0 To dsP.Tables("pro").Rows.Count - 1
                VlrTotal += NuloDecimal(dsP.Tables("pro").Rows(ii).Item("Qtd")) * NuloDecimal(dsP.Tables("pro").Rows(ii).Item("Venda"))
            Next

            strSql = "UPDATE tblVendasMovto SET "
            strSql += "IDVenda = " & IDvda & " "
            strSql += "WHERE IDVenda = " & ds.Tables("Vendas").Rows(i).Item("IDVenda")
            ExecutaStr(strSql)

            If i <> 0 Then
                ExecutaStr("DELETE FROM tblVendas WHERE (IDVenda = " & ds.Tables("Vendas").Rows(i).Item("IDVenda") & ")")
            End If
        Next

        Dim Desconto As Decimal = 0
        strSql = "UPDATE tblVendas SET "
        strSql += "TotalProdutos=" & Replace(NuloDecimal(VlrTotal), ",", ".") & ", "
        strSql += "TotalVenda=" & Replace(NuloDecimal(VlrTotal), ",", ".") & ", "
        strSql += "Servico=0, "
        strSql += "Caixinha=0, "
        strSql += "Desconto=" & Replace(NuloDecimal(Desconto), ",", ".") & ", "
        strSql += "Troco=0, "
        strSql += "ContraVale=0, "
        strSql += "IDFechamento=" & IDFechamento & ", "
        strSql += "Caixa='" & Caixa & "', "
        strSql += "HoraFechamento='" & Now & "', "
        strSql += "FlagFechada=1, "
        strSql += "IDSat=" & EquipamentoSAT & " "
        strSql += "WHERE IDVenda=" & IDvda
        ExecutaStr(strSql)

        strSql = "INSERT tblVendasPagto "
        strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom,IDCliente,IDPendencia) VALUES ("
        strSql += to_sql(IDvda) & ","
        strSql += to_sql(IDFormaPagto) & ","
        strSql += to_sql(Descricao) & ","
        strSql += to_sql(Replace(VlrTotal, ",", ".")) & ","
        strSql += "0,"
        strSql += "0,"
        strSql += "'C', "
        strSql += "0,"
        strSql += "0,"
        strSql += "0)"
        ExecutaStr(strSql)

        If ImpRecibo = True Then
            frmPagamento.CriaCupomRecibo(IDvda)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\recibo.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        strSql = "SELECT IDVenda FROM tblVendasSAT WHERE IDVdaPagto=0 and IDVenda=" & IDvda
        Dim dapPP = New SqlDataAdapter(strSql, strCon)
        dapPP.SelectCommand.CommandType = CommandType.Text
        Dim dsPP As New DataSet()
        dapPP.Fill(dsPP, "vda")

        If dsPP.Tables("vda").Rows.Count > 0 Then
            strSql = "UPDATE tblVendasSAT SET "
            strSql += "ValorCupom = " & to_sql(Replace(NuloDecimal(VlrTotal), ",", ".")) & " "
            strSql += "WHERE IDVenda = " & IDvda
            ExecutaStr(strSql)
        Else
            strSql = "INSERT tblVendasSAT "
            strSql += "(IDVenda, ValorCupom) VALUES ("
            strSql += to_sql(IDvda) & ","
            strSql += to_sql(Replace(NuloDecimal(VlrTotal), ",", ".")) & ")"
            ExecutaStr(strSql)
        End If

        Dim frm As fdlgCpf_Cnpj = New fdlgCpf_Cnpj
        frm.tbIDVendaSAT.Text = PegaID("IDVendaSAT", "tblVendasSAT", "L")
        frm.tbIDVenda.Text = IDvda
        frm.tbTotalAD.Text = 0
        frm.tbTotVenda.Text = VlrTotal
        frm.tbTotCupom.Text = NuloDecimal(VlrTotal)
        frm.tbTxEntrega.Text = 0
        frm.tbStVenda.Text = "Balcão"
        strSql = "SELECT IDFechamento, DiaMovimento FROM tblFechamentos_Local WHERE IDFechamento=" & IDFechamento
        frm.tbDiaMovto.Text = PegaValorCampo("DiaMovimento", strSql, strCon)
        frm.tbIDSat.Text = EquipamentoSAT
        frm.ShowDialog()

        VendaBalcaoRecebida = True

        strSql = "DELETE FROM tblAgrupamentoDescricao_Clube WHERE (IDAgrupamento = " & lbIDAgrupamento.Text & ")"
        ExecutaStr(strSql)

        strSql = "DELETE FROM tblAgrupamento_Clube WHERE (IDAgrupamento = " & lbIDAgrupamento.Text & ")"
        ExecutaStr(strSql)

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub btnCartaoDebito_Click(sender As Object, e As EventArgs) Handles btnCartaoDebito.Click
        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma o fechamento desta conta"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then
            Exit Sub
        End If
        FechaVenda("CartaoDebito")
    End Sub

    Private Sub btnDinheiro_Click(sender As Object, e As EventArgs) Handles btnDinheiro.Click
        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Confirma o fechamento desta conta"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then
            Exit Sub
        End If
        FechaVenda("Dinheiro")
    End Sub

    Private Sub tbBuscaClientes_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaClientes.TextChanged
        MontaContas()
    End Sub
End Class