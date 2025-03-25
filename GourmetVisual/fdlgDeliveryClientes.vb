Imports System.Data.SqlClient

Public Class fdlgDeliveryClientes
    Private Sub BuscaCliente()
        Dim QtdItens As Integer = 0
        Dim Total As Decimal = 0
        Dim ValorItem As Decimal
        Dim NumMesa As Integer
        Dim IDMovto As Integer
        Dim entrou As Integer = 0

        GridProdutos.Rows.Clear()

        strSql = "Select tblClientes.IDCliente, tblClientes.IDLoja, tblClientes.NomeCliente, tblClientes.IDRua, tblClientes.Numero, tblClientes.Complemento, tblClientes.Bairro, REPLACE(REPLACE(REPLACE(tblClientes.Tel1, '-', ''), ' ', ''), '.', '') As Telefone1, REPLACE(REPLACE(REPLACE(tblClientes.Tel2, '-', ''), ' ', ''), '.', '') AS Telefone2, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuasCep.CEP, tblClientes.Tel1, tblClientes.Tel2 "
        strSql += "From tblRuasCep RIGHT OUTER Join tblRuas On tblRuasCep.IDRua = tblRuas.IDRua RIGHT OUTER Join tblClientes On tblRuas.IDRua = tblClientes.IDRua "
        'If tbTipo.Text = 0 Then
        'strSql += "Where (Replace(Replace(Replace(tblClientes.Tel1, '-', ''), ' ', ''), '.', '') LIKE '%" & tbBusca.Text & "%') "
        'Else
        'If tbTipo.Text = 2 Then
        'strSql += "Where (Replace(Replace(Replace(tblClientes.Tel2, '-', ''), ' ', ''), '.', '') LIKE '%" & tbBusca.Text & "%') "
        'Else
        'If IsNumeric(tbBusca.Text) Then
        'strSql += "Where (Replace(Replace(Replace(tblClientes.Tel2, '-', ''), ' ', ''), '.', '') LIKE '%" & tbBusca.Text & "%') "
        'End If
        'End If
        'End If

        strSql += "ORDER BY tblClientes.NomeCliente"



        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            IDMovto = ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")
            'lbMesa.Text = MesaCartao
            'lbTerminal.Text = ds.Tables("Vendas").Rows(i).Item("Terminal")
            'lbAtendente.Text = ds.Tables("Vendas").Rows(i).Item("Atendente")

            NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa")
            ValorItem = ds.Tables("Vendas").Rows(i).Item("Qtd") * ds.Tables("Vendas").Rows(i).Item("Venda")
            If entrou = 0 Then
                GridProdutos.Rows.Add({"", ">>> CARTÃO  " & NumMesa, "", "", ""})
                GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ds.Tables("Vendas").Rows(i).Item("Produto"), ds.Tables("Vendas").Rows(i).Item("Qtd"), ds.Tables("Vendas").Rows(i).Item("Venda"), Format(ValorItem, "#0.00"), "  " & ds.Tables("Vendas").Rows(i).Item("Categoria")})
                entrou = 1
            Else
                GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ds.Tables("Vendas").Rows(i).Item("Produto"), ds.Tables("Vendas").Rows(i).Item("Qtd"), ds.Tables("Vendas").Rows(i).Item("Venda"), Format(ValorItem, "#0.00"), "  " & ds.Tables("Vendas").Rows(i).Item("Categoria")})
            End If
            Total += ValorItem
            QtdItens += 1
            While NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa") And IDMovto = ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")
                While Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("Coment")) And NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa")
                    GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   (" & ds.Tables("Vendas").Rows(i).Item("Coment") & ")", "", "", "", ""})
                    If (i + 1) > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                    If IsDBNull(ds.Tables("Vendas").Rows(i + 1).Item("Coment")) Or NumMesa = ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") Then Exit While
                    i += 1
                End While
                If (i + 1) <= ds.Tables("Vendas").Rows.Count - 1 Then
                    If NumMesa = ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") And Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("Coment")) And IDMovto <> ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto") Then
                        ValorItem = ds.Tables("Vendas").Rows(i + 1).Item("Qtd") * ds.Tables("Vendas").Rows(i + 1).Item("Venda")
                        GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ds.Tables("Vendas").Rows(i + 1).Item("Produto"), ds.Tables("Vendas").Rows(i + 1).Item("Qtd"), ds.Tables("Vendas").Rows(i + 1).Item("Venda"), Format(ValorItem, "#0.00"), "  " & ds.Tables("Vendas").Rows(i + 1).Item("Categoria")})
                        Total += ValorItem
                        QtdItens += 1
                    End If
                    If (i + 1) > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                    If NumMesa <> ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") Then
                        GridProdutos.Rows.Add({"", "", "", "", ""})
                        entrou = 0
                        Exit While
                    End If
                    If IDMovto <> ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto") Then Exit While
                    i += 1
                Else
                    Exit While
                End If
            End While

        Next
        'lbTotalItens.Text = "Qtde. de itens: " & QtdItens
        'lbValorTotal.Text = Format(Total, "#0.00")


    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub fdlgDeliveryClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class