Imports System.Data.SqlClient

Public Class fdlgBuscaProduto
    Private Sub FdlgBuscaProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CodigoProdutoBusca = 0
        PreencheProduto()
    End Sub
    Private Sub PreencheProduto()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)
        Dim item As ListViewItem

        strSql = "Select Produto, CodigoProduto, Venda From tblProdutos_Local "
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


        lsvProdutos.Items.Clear()

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While (dr.Read())
                item = lsvProdutos.Items.Add(NuloString(dr.Item("Produto")))
                item.SubItems.Add(NuloString(dr.Item("CodigoProduto")))
                item.SubItems.Add(NuloString(Format(dr.Item("Venda"), "#0.00")))
            End While
        End If
        comandoLJS.Dispose()
        con.Dispose()
        con.Close()


    End Sub
    Private Sub fdlgBuscaProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheProduto()
    End Sub

    Private Sub tbBusca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBusca.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            lsvProdutos.Focus()

        End If
    End Sub

    Private Sub LsvProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProdutos.SelectedIndexChanged

    End Sub

    Private Sub lsvProdutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvProdutos.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If lsvProdutos.SelectedItems.Count > 0 Then
                For i As Integer = 0 To lsvProdutos.Items.Count - 1
                    If lsvProdutos.Items(i).Selected = True Then
                        CodigoProdutoBusca = NuloInteger(lsvProdutos.Items(i).SubItems(1).Text)
                    End If
                Next i

                If CodigoProdutoBusca <> 0 Then
                    Me.Dispose()
                    Me.Close()
                End If
            End If

        End If
    End Sub
End Class