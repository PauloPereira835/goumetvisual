Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles
Imports GourmetVisual.WSCorreios

Public Class fdlgAbreVenda_Clube
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click

        If NuloString(lbNomeCliente.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja realmente continuar" & vbCrLf & "Caso continue essa venda será excluida"
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

        strSql = "DELETE FROM tblVendas WHERE (FlagFechada = 0) And (NomeCliente Is NULL)"
        ExecutaStr(strSql)

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub AtualizaGridProdutos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridProdutos.Rows.Clear()
        If NuloString(tbCodPro.Text) = "" Then Exit Sub

        SqlStr = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblGrupos_Local.Grupo, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda, tblProdutos_Local.Pesavel, tblGrupos_Local.EPizza, tblProdutos_Local.IDFamilia, tblProdutos_Local.Categoria, tblGrupos_Local.CodigoGrupo "
        SqlStr += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        SqlStr += "WHERE (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%S%')  "
        If Not IsNumeric(tbCodPro.Text) Then
            SqlStr += "AND (tblProdutos_Local.Produto Like '" & tbCodPro.Text & "%') "
        Else
            SqlStr += "AND (tblProdutos_Local.CodigoProduto Like '" & tbCodPro.Text & "%') "
        End If
        SqlStr += "ORDER BY tblProdutos_Local.Produto"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read())
                If NuloBoolean(dr.Item("ForaLinha")) = False Then
                    GridProdutos.Rows.Add({dr.Item("IDProduto"), dr.Item("CodigoProduto"), dr.Item("Produto"), NuloDecimal(dr.Item("Venda"))})
                End If
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

    End Sub

    Private Sub tbCodPro_TextChanged(sender As Object, e As EventArgs) Handles tbCodPro.TextChanged
        AtualizaGridProdutos()
    End Sub

    Private Sub tbCodPro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodPro.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbQtde.Text = "1"
            GridProdutos.Focus()
        End If
    End Sub
    Private Sub tbQtde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtde.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            btnInclui.Focus()
        End If
    End Sub

    Private Sub GridProdutos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridProdutos.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            tbIDProduto.Text = NuloInteger(GridProdutos.Item(0, GridProdutos.CurrentRow.Index).Value)
            tbQtde.Focus()
        End If
    End Sub

    Private Sub btnInclui_Click(sender As Object, e As EventArgs) Handles btnInclui.Click

        If NuloString(tbCodPro.Text) = "" Then
            tbCodPro.Focus()
            Exit Sub
        End If

        If NuloInteger(GridProdutos.Item(0, GridProdutos.CurrentRow.Index).Value) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Produto não encontrado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodPro.Focus()
            Exit Sub
        End If

        If NuloDecimal(tbQtde.Text) = 0 Then
            tbQtde.Text = 1
        End If

        Dim Venda As Decimal = 0
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        SqlStr = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.CST_COFINS, tblProdutos_Local.CST_ICMS, tblProdutos_Local.CST_PIS, tblProdutos_Local.CFOP, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.Venda, tblGrupos_Local.Grupo, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda "
        SqlStr += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        SqlStr += "Where (tblProdutos_Local.IDProduto = " & NuloInteger(tbIDProduto.Text) & ")"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            If (dr.Read()) Then
                If NuloBoolean(dr.Item("ForaLinha")) = False Then
                    If NuloBoolean(dr.Item("InformaVenda")) = True Then
                        fdlgValorVenda.ShowDialog()
                        Venda = VlrUnitario
                    Else
                        Venda = NuloDecimal(dr.Item("Venda"))
                    End If

                    If NuloDecimal(tbLimiteCredito.Text) > 0 Then
                        Dim VlrVenda As Decimal
                        VlrVenda = NuloDecimal(lbTotal.Text)
                        If VlrVenda + Venda > NuloDecimal(tbLimiteCredito.Text) Then
                            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                            frm.lbMensagem.Text = "Valor total da venda superior ao limite de crédito"
                            frm.btnNao.Visible = False
                            frm.btnSim.Visible = False
                            frm.btnOK.Visible = True
                            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm.ShowDialog()
                            tbCodPro.Focus()
                            Exit Sub
                        End If
                    End If

                    InserirItemVenda(tbIDVenda.Text, dr.Item("IDProduto"), dr.Item("Produto"), tbQtde.Text, True, Venda, NuloDecimal(dr.Item("Venda")), dr.Item("Categoria"), Date.Now, IDOperador, Operador, dr.Item("CodigoGrupo"), dr.Item("Grupo"), False, "", True, "", frmClube.lbTerminal.Text, Imprime, SetorBalcao, True, True)
                End If
            End If
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

        GridProdutos.Rows.Clear()

        MontaProdutos(NuloInteger(tbIDVenda.Text))

        tbCodPro.Text = ""
        tbQtde.Text = ""
        tbIDProduto.Text = ""
        tbCodPro.Focus()


    End Sub

    Private Sub fdlgAbreVenda_Clube_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        strSql = "SELECT NomeCliente FROM tblVendas WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        lbNomeCliente.Text = NuloString(UCase(PegaValorCampo("NomeCliente", strSql, strCon)))
        If NuloString(lbNomeCliente.Text) = "" Then
            btnFicha.Visible = True
        End If

        strSql = "SELECT Desconto FROM tblVendas WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        tbValorDesconto.Text = Format(NuloDecimal(PegaValorCampo("Desconto", strSql, strCon)), "#0.00")

        strSql = "SELECT Obs FROM tblVendas WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        tbObs.Text = NuloString(UCase(PegaValorCampo("Obs", strSql, strCon)))

        strSql = "SELECT DataVenda FROM tblVendas WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        lbDataVenda.Text = NuloString(PegaValorCampo("DataVenda", strSql, strCon))

        strSql = "SELECT LimiteCredito FROM tblVendas WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        tbLimiteCredito.Text = Format(NuloDecimal(PegaValorCampo("LimiteCredito", strSql, strCon)), "#0.00")

        MontaProdutos(NuloInteger(tbIDVenda.Text))
        tbCodPro.Focus()

    End Sub


    Private Sub MontaProdutos(IDvda As Integer)
        Dim item As ListViewItem
        Dim VlrTotal As Decimal = 0
        Dim vlrGeral As Decimal = 0
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        lstProdutos.Items.Clear()

        SqlStr = "Select tblVendasMovto.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasMovto.IDProduto, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasMovto.Venda, tblProdutos_Local.CodigoProduto, tblVendasMovto.HoraPedido "
        SqlStr += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
        SqlStr += "Where (tblVendasMovto.IDVenda = " & IDvda & ") "
        SqlStr += "Order By tblVendasMovto.HoraPedido DESC"

        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While (dr.Read())
                item = lstProdutos.Items.Add(dr.Item("IDProduto"))
                item.SubItems.Add(dr.Item("CodigoProduto"))
                item.SubItems.Add(dr.Item("Produto"))
                item.SubItems.Add(NuloDecimal(dr.Item("Qtd")))
                item.SubItems.Add(NuloDecimal(dr.Item("Venda")))
                VlrTotal = NuloDecimal(dr.Item("Qtd")) * NuloDecimal(dr.Item("Venda"))
                item.SubItems.Add(Format(NuloDecimal(VlrTotal), "#0.00"))
                item.SubItems.Add(Strings.Left(NuloString(dr.Item("HoraPedido")), 10))
                item.SubItems.Add(dr.Item("IDVendaMovto"))

                vlrGeral += VlrTotal
            Loop
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

        lbTotal.Text = Format(vlrGeral - NuloDecimal(tbValorDesconto.Text), "#,##0.00")

    End Sub

    Private Sub tbCodPro_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCodPro.KeyDown

        If e.KeyCode = 40 Then
            e.Handled = True
            tbQtde.Text = "1"
            GridProdutos.Focus()
        End If
    End Sub

    Private Sub btnExclui_Click(sender As Object, e As EventArgs) Handles btnExclui.Click

        If NuloInteger(lstProdutos.SelectedItems.Count) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecinar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodPro.Focus()
            Exit Sub
        End If

        If NuloInteger(lstProdutos.SelectedItems.Count) <> 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Confirma a EXCLUSÃO deste produto"
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

        Dim IDmovto As Integer
        IDmovto = lstProdutos.SelectedItems.Item(0).SubItems(7).Text
        strSql = "DELETE FROM tblVendasMovto WHERE IDVendaMovto = " & IDmovto
        ExecutaStr(strSql)

        MontaProdutos(NuloInteger(tbIDVenda.Text))

        tbCodPro.Text = ""
        tbQtde.Text = ""
        tbIDProduto.Text = ""
        tbCodPro.Focus()

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
            tbCodPro.Focus()
            Exit Sub
        End If
        If NuloDecimal(lbTotal.Text) = 0 Then
            frm1.lbMensagem.Text = "Venda sem produtos"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            tbCodPro.Focus()
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

        Dim Desconto As Decimal = NuloDecimal(tbValorDesconto.Text)

        strSql = "UPDATE tblVendas SET "
        strSql += "TotalProdutos=" & Replace(NuloDecimal(lbTotal.Text), ",", ".") & ", "
        strSql += "TotalVenda=" & Replace(NuloDecimal(lbTotal.Text), ",", ".") & ", "
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
        strSql += "WHERE IDVenda=" & tbIDVenda.Text
        ExecutaStr(strSql)

        strSql = "INSERT tblVendasPagto "
        strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom,IDCliente,IDPendencia) VALUES ("
        strSql += to_sql(tbIDVenda.Text) & ","
        strSql += to_sql(IDFormaPagto) & ","
        strSql += to_sql(Descricao) & ","
        strSql += to_sql(Replace(NuloDecimal(lbTotal.Text), ",", ".")) & ","
        strSql += "0,"
        strSql += "0,"
        strSql += "'C', "
        strSql += "0,"
        strSql += "0,"
        strSql += "0)"
        ExecutaStr(strSql)

        If ImpRecibo = True Then
            frmPagamento.CriaCupomRecibo(tbIDVenda.Text)
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\recibo.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
        End If

        strSql = "SELECT IDVenda FROM tblVendasSAT WHERE IDVdaPagto=0 and IDVenda=" & tbIDVenda.Text
        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "vda")

        If ds.Tables("vda").Rows.Count > 0 Then
            strSql = "UPDATE tblVendasSAT SET "
            strSql += "ValorCupom = " & to_sql(Replace(NuloDecimal(lbTotal.Text), ",", ".")) & " "
            strSql += "WHERE IDVenda = " & tbIDVenda.Text
            ExecutaStr(strSql)
        Else
            strSql = "INSERT tblVendasSAT "
            strSql += "(IDVenda, ValorCupom) VALUES ("
            strSql += to_sql(tbIDVenda.Text) & ","
            strSql += to_sql(Replace(NuloDecimal(lbTotal.Text), ",", ".")) & ")"
            ExecutaStr(strSql)
        End If

        Dim frm As fdlgCpf_Cnpj = New fdlgCpf_Cnpj
        frm.tbIDVendaSAT.Text = PegaID("IDVendaSAT", "tblVendasSAT", "L")
        frm.tbIDVenda.Text = tbIDVenda.Text
        frm.tbTotalAD.Text = 0
        frm.tbTotVenda.Text = lbTotal.Text
        frm.tbTotCupom.Text = NuloDecimal(lbTotal.Text)
        frm.tbTxEntrega.Text = 0
        frm.tbStVenda.Text = "Balcão"
        strSql = "SELECT IDFechamento, DiaMovimento FROM tblFechamentos_Local WHERE IDFechamento=" & IDFechamento
        frm.tbDiaMovto.Text = PegaValorCampo("DiaMovimento", strSql, strCon)
        frm.tbIDSat.Text = EquipamentoSAT
        frm.ShowDialog()

        VendaBalcaoRecebida = True


        Me.Dispose()
        Me.Close()

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

    Private Sub tbDesconto_LostFocus(sender As Object, e As EventArgs) Handles tbValorDesconto.LostFocus
        If NuloDecimal(tbValorDesconto.Text) = 0 Then
            tbValorDesconto.Text = "0.00"
        Else
            tbValorDesconto.Text = Format(NuloDecimal(tbValorDesconto.Text), "#0.00")
        End If

        strSql = "UPDATE tblVendas SET Desconto = " & Replace(tbValorDesconto.Text, ",", ".") & " WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        ExecutaStr(strSql)

        MontaProdutos(NuloInteger(tbIDVenda.Text))
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

    Private Sub tbValorDesconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbValorDesconto.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCodPro.Focus()
        End If
    End Sub

    Private Sub btnImprime_Click(sender As Object, e As EventArgs) Handles btnImprime.Click

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        If NuloDecimal(lbTotal.Text) = 0 Then
            frm1.lbMensagem.Text = "Venda sem produtos"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            tbCodPro.Focus()
            Exit Sub
        End If
        If NuloInteger(IDFechamento) = 0 Then
            frm1.lbMensagem.Text = "É necessário abrir um movimento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            tbCodPro.Focus()
            Exit Sub
        End If

        CriaImpressaoConta(tbIDVenda.Text)

    End Sub

    Public Sub CriaImpressaoConta(IDvda As Integer)

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim VlrProTxt As String
        Dim DataPedido As String
        Dim VlrDescTxt As String
        Dim NomeCli As String

        con.ConnectionString = strCon
1:

        strSql = "Select tblVendas.IDVenda, tblVendas.DataVenda, tblVendasMovto.HoraPedido, tblVendas.Desconto, tblVendas.HoraAbertura, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Excluido, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.HoraAbertura, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.Excluido, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente, tblVendasMovto.HoraPedido "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        strSql += "Order BY tblVendasMovto.HoraPedido"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            NomeCli = Chr(27) + Chr(14) & NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente")) & Chr(27) + Chr(14)
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, ".")
                If NomeCli <> "" Then
                    PrintLine(lngFile, " " & NomeCli)
                End If
            Else
                PrintLine(lngFile, ".")
                If NomeCli <> "" Then
                    PrintLine(lngFile, Chr(27) + Chr(14) & " " & NomeCli & Chr(27) + Chr(14))
                End If
            End If
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
            PrintLine(lngFile, NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")))
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Endereco"))) & "," & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Numero")))
            PrintLine(lngFile, texto)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("CEP"))) & "  -  " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Telefone")))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "          CONFERENCIA DE CONTA")
            PrintLine(lngFile, "    Controle interno sem valor fiscal")
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Descricao          Qtde.   Unit.    Total ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1

                DataPedido = Strings.Left(NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), 10)
                PrintLine(lngFile, ">>> " & DataPedido & " <<<")
                Do While DataPedido = Strings.Left(NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), 10)

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
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                PrintLine(lngFile, ".")
            Loop
            PrintLine(lngFile, "==========================================")

            Dim vlrDesc As Decimal = 0
            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Desconto")) > 0 Then
                VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")
                PrintLine(lngFile, "Sub-total " & Space(32 - Len(VlrProTxt)) & VlrProTxt)

                vlrDesc = NuloDecimal(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Desconto")))
                VlrDescTxt = Format(NuloDecimal(vlrDesc), "#0.00")

                texto = "Desconto  " & Space(32 - Len(VlrDescTxt)) & VlrDescTxt
                PrintLine(lngFile, texto)
                PrintLine(lngFile, "                              ------------")
            End If

            Dim VlrTotal As String
            VlrTotal = Format(NuloDecimal(VlrPro) - NuloDecimal(vlrDesc), "#0.00")
            PrintLine(lngFile, "TOTAL" & Space(37 - Len(VlrTotal)) & VlrTotal)

            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
            If GuilhotinaImpCaixa = False Then
                PrintLine(lngFile, ".")
                PrintLine(lngFile, ".")
                PrintLine(lngFile, ".")
                PrintLine(lngFile, ".")
            End If
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
            PrintLine(lngFile, ".")
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

    Private Sub tbObs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbObs.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCodPro.Focus()
        End If
    End Sub

    Private Sub tbObs_LostFocus(sender As Object, e As EventArgs) Handles tbObs.LostFocus
        Dim Obs As String
        Obs = UCase(Strings.Left(tbObs.Text, 250))

        strSql = "UPDATE tblVendas SET Obs = '" & Obs & "' WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        ExecutaStr(strSql)
    End Sub

    Private Sub tbQtde_LostFocus(sender As Object, e As EventArgs) Handles tbQtde.LostFocus
        If NuloDecimal(tbQtde.Text) = 0 Then
            tbQtde.Text = 1
        End If
    End Sub

    Private Sub GridProdutos_Click(sender As Object, e As EventArgs) Handles GridProdutos.Click

        If NuloString(tbCodPro.Text) = "" Then
            tbCodPro.Focus()
            Exit Sub
        End If

        tbQtde.Text = 1
        tbIDProduto.Text = NuloInteger(GridProdutos.Item(0, GridProdutos.CurrentRow.Index).Value)
    End Sub

    Private Sub GridProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridProdutos.CellContentClick

    End Sub

    Private Sub GridProdutos_Enter(sender As Object, e As EventArgs) Handles GridProdutos.Enter
        If NuloString(tbCodPro.Text) = "" Then tbCodPro.Focus()
    End Sub

    Private Sub tbLimiteCredito_LostFocus(sender As Object, e As EventArgs) Handles tbLimiteCredito.LostFocus
        If NuloDecimal(tbLimiteCredito.Text) = 0 Then
            tbLimiteCredito.Text = "0.00"
        Else
            tbLimiteCredito.Text = Format(NuloDecimal(tbLimiteCredito.Text), "#0.00")
        End If

        strSql = "UPDATE tblVendas SET LimiteCredito = " & Replace(tbLimiteCredito.Text, ",", ".") & " WHERE IDVenda=" & NuloInteger(tbIDVenda.Text)
        ExecutaStr(strSql)
    End Sub

    Private Sub tbLimiteCredito_TextChanged(sender As Object, e As EventArgs) Handles tbLimiteCredito.TextChanged

    End Sub

    Private Sub tbLimiteCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLimiteCredito.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCodPro.Focus()
        End If
    End Sub
    Private Sub btnFicha_Click(sender As Object, e As EventArgs) Handles btnFicha.Click
        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        If NuloDecimal(lbTotal.Text) = 0 Then
            frm1.lbMensagem.Text = "Venda sem produtos"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            tbCodPro.Focus()
            Exit Sub
        End If
        If NuloInteger(IDFechamento) = 0 Then
            frm1.lbMensagem.Text = "É necessário abrir um movimento"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            tbCodPro.Focus()
            Exit Sub
        End If

        CriaImpressaoFicha(tbIDVenda.Text)

        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If
    End Sub
    Private Sub CriaImpressaoFicha(IDvda As Integer)

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim QtdePro As Decimal = 0
        Dim VlrTotal As String

        con.ConnectionString = strCon

        strSql = "Select tblVendas.IDVenda, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.HoraAbertura, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Excluido, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.HoraAbertura, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.Excluido, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente, tblVendasMovto.HoraPedido "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        strSql += "Order BY tblVendasMovto.Produto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            QtdePro = 1
            Do While QtdePro <= NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                PrintLine(lngFile, ".")
                PrintLine(lngFile, NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")))
                PrintLine(lngFile, "==========================================")
                PrintLine(lngFile, "          CONFERENCIA DE CONTA")
                PrintLine(lngFile, "    Controle interno sem valor fiscal")
                PrintLine(lngFile, "==========================================")
                PrintLine(lngFile, "Descricao                      Quantidade ")
                PrintLine(lngFile, "------------------------------------------")

                texto = Chr(27) + Chr(14) & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("Produto"))) & Chr(27) + Chr(14)
                If Len(texto) <= 15 Then
                    ''texto = texto & Space(15 - Len(texto))
                    texto &= "       1"
                Else
                    'texto = Strings.Left(texto, 15)
                    texto &= "    1"
                End If

                PrintLine(lngFile, texto)
                VlrPro += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))
                PrintLine(lngFile, "==========================================")

                PrintLine(lngFile, "")
                PrintLine(lngFile, "")
                PrintLine(lngFile, "")
                PrintLine(lngFile, "")

                QtdePro += 1
            Loop
        Next
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "------------------------------------------")
        VlrTotal = Format(NuloDecimal(VlrPro), "#0.00")
        PrintLine(lngFile, "TOTAL" & Space(37 - Len(VlrTotal)) & VlrTotal)
        PrintLine(lngFile, "------------------------------------------")
        PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
        If GuilhotinaImpCaixa = False Then
            PrintLine(lngFile, "")
            PrintLine(lngFile, "")
            PrintLine(lngFile, "")
            PrintLine(lngFile, "")
        End If
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")
        PrintLine(lngFile, "")

        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()

        ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\conta.txt")

    End Sub

End Class