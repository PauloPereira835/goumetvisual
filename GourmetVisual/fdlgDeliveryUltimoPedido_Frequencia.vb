Imports System.Data.SqlClient

Public Class fdlgDeliveryUltimoPedido_Frequencia
    Private Sub ProdutosPedidos(IDcli As Integer)

        strSql = "Select tblRetVendas.IDCliente, tblRetVendasMovto.IDProduto, tblRetVendasMovto.Produto, SUM(tblRetVendasMovto.Qtd) As Qtde, MAX(tblRetVendasCombo.IDVendaRetMovto) As IDcombo, SUM(tblRetVendasCombo.Qtd) AS QtdCombo "
        strSql += "From tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet LEFT OUTER Join tblRetVendasCombo On tblRetVendasMovto.IDVendaRetMovto = tblRetVendasCombo.IDVendaRetMovto "
        strSql += "Group By tblRetVendas.IDCliente, tblRetVendasMovto.Produto, tblRetVendasMovto.IDProduto "
        strSql += "HAVING(tblRetVendas.IDCliente = " & IDcli & ") "
        strSql += "ORDER BY Qtde DESC, tblRetVendasMovto.Produto DESC"

        GridProdutosPedidos.Rows.Clear()

        Dim Linhas As Integer
        Dim Combos As New List(Of String)
        Dim Qtde As Decimal
        Dim dap = New SqlDataAdapter(strSql, strConServer)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")
        Linhas = ds.Tables("Vendas").Rows.Count - 1
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDcombo")) = 0 Then
                Qtde = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
            Else
                Qtde = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("QtdCombo"))
            End If

            GridProdutosPedidos.Rows.Add({NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), Format(NuloDecimal(Qtde), "#0.000")})

            If NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDcombo")) <> 0 Then

                Combos = verCombo(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), IDcli)
                If Combos.Count > 0 Then
                    For ii As Integer = 0 To Combos.Count - 1
                        GridProdutosPedidos.Rows.Add({"   > " & NuloString(Combos(ii)), Format(NuloDecimal(Combos(ii + 1)), "#0.000")})
                        ii += 1
                    Next
                End If
            End If

        Next

        Dim font As New Font("Sans Serif", 8, FontStyle.Bold)
        Dim fontCombo As New Font("Sans Serif", 7, FontStyle.Regular)
        For iii As Integer = 0 To GridProdutosPedidos.Rows.Count - 1
            If Strings.Left(GridProdutosPedidos.Item(0, iii).Value, 5) = "   > " Then
                GridProdutosPedidos.Rows(iii).DefaultCellStyle.Font = fontCombo
            Else
                GridProdutosPedidos.Rows(iii).DefaultCellStyle.Font = font
            End If
        Next

    End Sub
    Function verCombo(idCombo As Integer, idCli As Integer)
        Dim Combo As New List(Of String)
        Dim con As New SqlConnection()

        strSql = "Select tblRetVendas.IDCliente, tblRetVendasMovto.IDProduto, tblRetVendasCombo.Produto, SUM(tblRetVendasCombo.Qtd) As QtdeCombo "
        strSql += "From tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet INNER Join tblRetVendasCombo On tblRetVendasMovto.IDVendaRetMovto = tblRetVendasCombo.IDVendaRetMovto "
        strSql += "Group By tblRetVendas.IDCliente, tblRetVendasCombo.Produto, tblRetVendasMovto.IDProduto "
        strSql += "HAVING(tblRetVendas.IDCliente = " & idCli & ") And (tblRetVendasMovto.IDProduto = " & idCombo & ") "
        strSql += "ORDER BY QtdeCombo DESC"

        Dim dr As SqlDataReader
        con.ConnectionString = strConServer
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read()

                Combo.Add(NuloString(dr.Item("Produto")))
                Combo.Add(NuloString(dr.Item("QtdeCombo")))

            End While

        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Return Combo

    End Function
    Private Sub MontaUltimoPedido(IDvda As Integer, IDcli As Integer)

        strSql = "Select tblRetVendas.IDVendaRet, tblRetVendas.IDVenda, tblRetVendas.IDLoja, tblRetVendas.IDCliente, tblRetVendasMovto.IDVendaRetMovto, tblRetVendasMovto.Produto, tblRetVendasMovto.IDProduto, tblRetVendasMovto.Qtd, tblRetVendasCombo.IDVendaRetCombo, tblRetVendasCombo.IDProduto As IDProdutoCombo, tblRetVendasCombo.Produto As ProdutoCombo, tblRetVendasCombo.Qtd As QtdCombo, tblRetVendasMovto.Venda, tblRetVendas.Caixinha, tblRetVendas.Desconto, tblRetVendas.TaxaEntrega "
        strSql += "From tblRetVendasCombo RIGHT OUTER Join tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet ON tblRetVendasCombo.IDVendaRetMovto = tblRetVendasMovto.IDVendaRetMovto "
        strSql += "Where (tblRetVendas.IDCliente = " & IDcli & ") And (tblRetVendas.IDLoja = " & IDLoja & ") And (tblRetVendas.IDVendaRet = " & IDvda & ") "
        strSql += "Order By tblRetVendasMovto.IDVendaRetMovto, tblRetVendasCombo.IDVendaRetCombo"

        GridUltPedido.Rows.Clear()
        Dim vlrProdutos As Decimal = 0
        Dim vlrProduto As Decimal = 0
        Dim vlrDesconto As Decimal = 0
        Dim vlrCaixinha As Decimal = 0
        Dim vlrTxEntrega As Decimal = 0
        Dim IDProdCombo As Decimal = 0
        Dim IDmovto As Integer
        Dim IDcombo As Integer
        Dim Linhas As Integer
        Dim Comentarios As New List(Of String)

        Dim dap = New SqlDataAdapter(strSql, strConServer)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")
        Linhas = ds.Tables("Vendas").Rows.Count - 1
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            vlrCaixinha = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Caixinha"))
            vlrTxEntrega = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("TaxaEntrega"))
            vlrDesconto = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Desconto"))
            IDmovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaRetMovto"))
            vlrProduto = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))
            vlrProdutos += vlrProduto

            GridUltPedido.Rows.Add({NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), "#0.000"), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), Format(NuloDecimal(vlrProduto), "#0.00")})

            IDcombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaRetCombo"))
            If IDcombo <> 0 Then
                GridUltPedido.Rows.Add({"  + " & NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")), "", "", ""})
                Comentarios = verComent(0, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaRetCombo")))
                If Comentarios.Count > 0 Then
                    For ii As Integer = 0 To Comentarios.Count - 1
                        GridUltPedido.Rows.Add({"----> " & NuloString(Comentarios(ii)), "", "", ""})
                    Next
                End If

                If (i + 1) <= Linhas Then
                    i += 1
                    While IDmovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaRetMovto"))
                        GridUltPedido.Rows.Add({"  + " & NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")), "", "", ""})
                        Comentarios = verComent(0, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaRetCombo")))
                        If Comentarios.Count > 0 Then
                            For ii As Integer = 0 To Comentarios.Count - 1
                                GridUltPedido.Rows.Add({"----> " & NuloString(Comentarios(ii)), "", "", ""})
                            Next
                        End If

                        i += 1
                        If i > Linhas Then
                            Exit While
                        End If
                    End While
                End If
            End If
            Comentarios = verComent(IDmovto, 0)
            If Comentarios.Count > 0 Then
                For ii As Integer = 0 To Comentarios.Count - 1
                    GridUltPedido.Rows.Add({">>>> " & NuloString(Comentarios(ii)), "", "", ""})
                Next
            End If
        Next
        tbUltVlrProdutos.Text = Format(NuloDecimal(vlrProdutos), "#0.00")
        tbUltVlrDesconto.Text = Format(NuloDecimal(vlrDesconto), "#0.00")
        tbUltVlrCaixinha.Text = Format(NuloDecimal(vlrCaixinha), "#0.00")
        tbUltVlrTaxaEntrega.Text = Format(NuloDecimal(vlrTxEntrega), "#0.00")
        tbUltVlrVenda.Text = Format(NuloDecimal(vlrProdutos) + NuloDecimal(vlrTxEntrega) + NuloDecimal(vlrCaixinha) - NuloDecimal(vlrDesconto), "#0.00")

        Dim font As New Font("Sans Serif", 8, FontStyle.Bold)
        Dim fontDet As New Font("Sans Serif", 6, FontStyle.Regular)
        Dim fontCombo As New Font("Sans Serif", 7, FontStyle.Regular)
        For iii As Integer = 0 To GridUltPedido.Rows.Count - 1
            If Strings.Left(GridUltPedido.Item(0, iii).Value, 5) = "---->" Or Strings.Left(GridUltPedido.Item(0, iii).Value, 5) = ">>>> " Then
                GridUltPedido.Rows(iii).DefaultCellStyle.Font = fontDet
            Else
                If Strings.Left(GridUltPedido.Item(0, iii).Value, 4) = "  + " Then
                    GridUltPedido.Rows(iii).DefaultCellStyle.Font = fontCombo
                Else
                    GridUltPedido.Rows(iii).DefaultCellStyle.Font = font
                End If
            End If
        Next


    End Sub
    Function verComent(idMovto As Integer, idCombo As Integer)
        Dim Coments As New List(Of String)
        Dim con As New SqlConnection()

        strSql = "Select IDRetVendaMovto, IDRetVendaCombo, Coment FROM tblRetVendasComent "
        If idMovto <> 0 Then
            strSql += "WHERE (IDRetVendaMovto=" & idMovto & ") "
        Else
            strSql += "WHERE (IDRetVendaCombo=" & idCombo & ") "
        End If
        strSql += "ORDER BY Coment"

        Dim dr As SqlDataReader
        con.ConnectionString = strConServer
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read()

                Coments.Add(NuloString(dr.Item("Coment")))

            End While

        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Return Coments

    End Function
    Private Sub FdlgDeliveryUltimoPedido_Frequencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        strSql = "Select MAX(IDVendaRet) As IDVendaRet_Ultimo From tblRetVendas WHERE IDCliente=" & NuloInteger(frmDelivery.tbIDCliente.Text)
        MontaUltimoPedido(NuloInteger(PegaValorCampo("IDVendaRet_Ultimo", strSql, strConServer)), NuloInteger(frmDelivery.tbIDCliente.Text))
        lbUltimoPedido.Text = frmDelivery.lbDataUltimoPedido.Text
        ProdutosPedidos(NuloInteger(frmDelivery.tbIDCliente.Text))
    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class