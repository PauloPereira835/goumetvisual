Imports System.Data.SqlClient

Public Class fdlgSat_VerificaVenda
    Private Sub PreenchePagto()
        Dim item As ListViewItem
        Dim Vlr As Decimal = 0

        lstPagamento.Items.Clear()

        If fdlgModuloFiscal_SAT.chkMovtoAterior.Checked = False Then
            strSql = "Select IDVenda, Descricao, ValorPago "
            strSql += "From tblVendasPagto "
            strSql += "Where (IDVenda = " & tbIDVenda.Text & ") "
            strSql += "Order By Descricao"
        Else
            strSql = "Select IDVendaRet, Descricao, ValorPago "
            strSql += "From tblRetVendasPagto "
            strSql += "Where (IDVendaRet = " & tbIDVenda.Text & ") "
            strSql += "Order By Descricao"
        End If


        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                If fdlgModuloFiscal_SAT.chkMovtoAterior.Checked = False Then
                    item = lstPagamento.Items.Add(dr.Item("IDVenda"))
                Else
                    item = lstPagamento.Items.Add(dr.Item("IDVendaRet"))
                End If
                item.SubItems.Add(dr.Item("Descricao"))
                item.SubItems.Add(Format(dr.Item("ValorPago"), "#0.00"))

                Vlr += dr.Item("ValorPago")
            End While

            lstPagamento.Update()
            lstPagamento.EndUpdate()
        End If

        lbTotalPagto.Text = ""
        lbTotalPagto.Text = Vlr

        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheLista()
        Dim item As ListViewItem
        Dim Num As Integer = 0
        Dim Vlr As Decimal = 0
        Dim Combo As Integer = 0
        Dim IDMovto As Integer
        Dim IDMovto1 As Integer = 0

        lstVenda.Items.Clear()

        If fdlgModuloFiscal_SAT.chkMovtoAterior.Checked = False Then
            strSql = "Select tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Venda As Vda, tblVendasMovto.VendaServico As VdaServico, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.IDVendaMovto "
            strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
            strSql += "Where (tblVendasMovto.Excluido = 0) "
            strSql += "Group By tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.IDVendaMovto "
            strSql += "HAVING (tblVendasMovto.IDVenda = " & tbIDVenda.Text & ") "
            strSql += "ORDER BY tblVendasMovto.Produto, tblVendasMovto.IDVendaMovto"
        Else
            strSql = "Select tblProdutosLojas.CodigoProduto, tblRetVendasMovto.Produto, SUM(tblRetVendasMovto.Qtd) As Qtde, tblRetVendasMovto.Venda As Vda, tblRetVendasMovto.VendaServico As VdaServico, tblRetVendasMovto.IDVendaRet, tblRetVendasCombo.Produto AS ProdutoCombo "
            strSql += "From tblRetVendasCombo RIGHT OUTER Join tblProdutosLojas INNER Join tblRetVendasMovto On tblProdutosLojas.IDProduto = tblRetVendasMovto.IDProduto ON tblRetVendasCombo.IDVendaRetMovto = tblRetVendasMovto.IDVendaRetMovto "
            strSql += "Where (tblRetVendasMovto.Excluido = 0) "
            strSql += "Group By tblProdutosLojas.CodigoProduto, tblRetVendasMovto.Produto, tblRetVendasMovto.Venda, tblRetVendasMovto.VendaServico, tblRetVendasMovto.IDVendaRet, tblRetVendasCombo.Produto "


            strSql = "Select tblProdutosLojas.CodigoProduto, tblRetVendasMovto.Produto, SUM(tblRetVendasMovto.Qtd) As Qtde, tblRetVendasMovto.Venda As Vda, tblRetVendasMovto.VendaServico As VdaServico, tblRetVendasMovto.IDVendaRet, tblRetVendasCombo.Produto AS ProdutoCombo, tblRetVendasMovto.IDVendaRetMovto "
            strSql += "From tblRetVendasCombo RIGHT OUTER Join tblProdutosLojas INNER Join tblRetVendasMovto On tblProdutosLojas.IDProduto = tblRetVendasMovto.IDProduto ON tblRetVendasCombo.IDVendaRetMovto = tblRetVendasMovto.IDVendaRetMovto "
            strSql += "Where (tblRetVendasMovto.Excluido = 0) "
            strSql += "Group By tblProdutosLojas.CodigoProduto, tblRetVendasMovto.Produto, tblRetVendasMovto.Venda, tblRetVendasMovto.VendaServico, tblRetVendasMovto.IDVendaRet, tblRetVendasCombo.Produto, tblRetVendasMovto.IDVendaRetMovto "
            strSql += "HAVING (tblRetVendasMovto.IDVendaRet = " & tbIDVenda.Text & ") "
            strSql += "Order By tblRetVendasMovto.Produto, tblRetVendasMovto.IDVendaRetMovto"
        End If

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                If fdlgModuloFiscal_SAT.chkMovtoAterior.Checked = False Then
                    item = lstVenda.Items.Add(dr.Item("IDVenda"))
                    IDMovto = dr.Item("IDVendaMovto")
                Else
                    item = lstVenda.Items.Add(dr.Item("IDVendaRet"))
                    IDMovto = dr.Item("IDVendaRetMovto")
                End If

                If NuloString(dr.Item("ProdutoCombo")) = "" Then
                    item.SubItems.Add(dr.Item("CodigoProduto"))
                    item.SubItems.Add(dr.Item("Produto"))
                    item.SubItems.Add(Format(dr.Item("Qtde"), "#0.000"))
                    item.SubItems.Add(Format(dr.Item("VdaServico"), "#0.00"))
                    item.SubItems.Add(Format(dr.Item("Qtde") * dr.Item("VdaServico"), "#0.00"))
                    Vlr += NuloDecimal(dr.Item("Qtde")) * NuloDecimal(dr.Item("VdaServico"))
                    Num += 1
                    Combo = 0
                Else
                    If IDMovto <> IDMovto1 Then
                        item.SubItems.Add(dr.Item("CodigoProduto"))
                        item.SubItems.Add(dr.Item("Produto"))
                        item.SubItems.Add(Format(dr.Item("Qtde"), "#0.000"))
                        item.SubItems.Add(Format(dr.Item("VdaServico"), "#0.00"))
                        item.SubItems.Add(Format(dr.Item("Qtde") * dr.Item("VdaServico"), "#0.00"))
                        Vlr += NuloDecimal(dr.Item("Qtde")) * NuloDecimal(dr.Item("VdaServico"))
                        Num += 1
                        Combo = 1
                        If fdlgModuloFiscal_SAT.chkMovtoAterior.Checked = False Then
                            item = lstVenda.Items.Add(dr.Item("IDVenda"))
                            IDMovto1 = dr.Item("IDVendaMovto")
                        Else
                            item = lstVenda.Items.Add(dr.Item("IDVendaRet"))
                            IDMovto1 = dr.Item("IDVendaRetMovto")
                        End If
                    End If

                    item.SubItems.Add("")
                    item.SubItems.Add("  - " & dr.Item("ProdutoCombo"))
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                End If




            End While

            lstVenda.Update()
            lstVenda.EndUpdate()
        End If

        lbQtde.Text = "Quantidade de itens: " & Num
        lbTotal.Text = ""
        lbTotal.Text = Format(Vlr, "#0.00")

        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

    End Sub
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgSat_VerificaVenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheLista()
        PreenchePagto()
    End Sub

    Private Sub lstPagamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPagamento.SelectedIndexChanged

    End Sub
End Class