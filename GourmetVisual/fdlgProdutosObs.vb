Imports System.Data.SqlClient

Public Class fdlgProdutosObs
    Private Sub PreencheProdutos()
        Dim item As ListViewItem
        Dim QtdeCli As Integer = 0
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select IDProduto, CodigoProduto, Produto, Venda, Obs "
        strSql += "From tblProdutos_Local "
        If tbBusca.Text <> "" Then
            If Not IsNumeric(tbBusca.Text) Then
                strSql += "WHERE (Produto LIKE '%" & tbBusca.Text & "%') "
                strSql += "Order By Produto"
            Else
                strSql += "WHERE (CodigoProduto LIKE '" & tbBusca.Text & "%') "
                strSql += "Order By CodigoProduto"
            End If
        Else
            strSql += "Order By Produto"
        End If


        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        lstProduto.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                item = lstProduto.Items.Add(dr.Item("IDProduto"))
                item.SubItems.Add(NuloString(dr.Item("Produto")))
                item.SubItems.Add(NuloDecimal(dr.Item("Venda")))
                item.SubItems.Add(NuloString(dr.Item("Obs")))
                item.SubItems.Add(NuloInteger(dr.Item("CodigoProduto")))
                QtdeCli += 1
            End While
            lstProduto.Update()
            lstProduto.EndUpdate()
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

    End Sub
    Private Sub FdlgProdutosObs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PreencheProdutos()
        tbBusca.Focus()
    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheProdutos()
    End Sub

    Private Sub LstProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProduto.SelectedIndexChanged
        If lstProduto.SelectedItems.Count > 0 Then

            tbObs.Text = NuloString(lstProduto.SelectedItems(0).SubItems(3).Text)

        End If
    End Sub
End Class