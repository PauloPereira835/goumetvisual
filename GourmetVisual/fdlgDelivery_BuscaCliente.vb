Imports System.Data.SqlClient

Public Class fdlgDelivery_BuscaCliente
    Private Sub BuscaCliente()
        Dim QtdItens As Integer = 0

        GridClientes.Rows.Clear()

        strSql = "Select tblClientes.IDCliente, tblClientes.IDLoja, tblClientes.NomeCliente, tblClientes.IDRua, tblClientes.Numero, tblClientes.Complemento, tblRuas.Bairro, tblRuas.Logradouro, tblClientes.Tel1, tblClientes.Tel2, tblClientes.CEP, tblClientes.CPF_CNPJ "
        strSql += "From tblRuas RIGHT OUTER Join tblClientes On tblRuas.IDRua = tblClientes.IDRua "
        If tbBusca.Text <> "" Then
            If Not IsNumeric(tbBusca.Text) Then
                strSql += "Where (tblClientes.NomeCliente LIKE '%" & tbBusca.Text & "%') "
            Else
                If Len(tbBusca.Text) < 11 Then
                    strSql += "WHERE (tblClientes.Tel1 LIKE '%" & tbBusca.Text & "%') OR (tblClientes.Tel2 LIKE '%" & tbBusca.Text & "%') "
                Else
                    strSql += "WHERE (tblClientes.CPF_CNPJ = '" & tbBusca.Text & "') "
                End If
            End If
        End If
        strSql += "ORDER BY tblClientes.NomeCliente"



        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Clientes")

        For i As Integer = 0 To ds.Tables("Clientes").Rows.Count - 1
            GridClientes.Rows.Add({ds.Tables("Clientes").Rows(i).Item("IDCliente"), ds.Tables("Clientes").Rows(i).Item("NomeCliente"), ds.Tables("Clientes").Rows(i).Item("Tel1"), ds.Tables("Clientes").Rows(i).Item("Tel2"), ds.Tables("Clientes").Rows(i).Item("CPF_CNPJ"), ds.Tables("Clientes").Rows(i).Item("Logradouro") & ", " & ds.Tables("Clientes").Rows(i).Item("Numero") & "  " & ds.Tables("Clientes").Rows(i).Item("Complemento"), ds.Tables("Clientes").Rows(i).Item("CEP"), ds.Tables("Clientes").Rows(i).Item("Bairro")})
            QtdItens += 1
        Next
        lbQtdeClientes.Text = "Qtde. de clientes: " & QtdItens



    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
        frmDelivery.tbBuscaCliente.Text = ""
        frmDelivery.tbBuscaCliente.Focus()
    End Sub

    Private Sub fdlgDeliveryClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscaCliente()
    End Sub

    Private Sub tbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        BuscaCliente()
        frmPagamento.carregaVisualComponente(btnVolta, 10, 10)
    End Sub

    Private Sub GridClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridClientes.CellContentClick

    End Sub

    Private Sub GridClientes_DoubleClick(sender As Object, e As EventArgs) Handles GridClientes.DoubleClick
        If GridClientes.Rows.Count > 0 Then
            If NuloString(GridClientes.Item(2, GridClientes.CurrentRow.Index).Value) <> "" Then
                frmDelivery.tbBuscaCliente.Text = NuloString(GridClientes.Item(2, GridClientes.CurrentRow.Index).Value)
                Me.Dispose()
                Me.Close()
            Else
                If NuloString(GridClientes.Item(3, GridClientes.CurrentRow.Index).Value) <> "" Then
                    frmDelivery.tbBuscaCliente.Text = NuloString(GridClientes.Item(3, GridClientes.CurrentRow.Index).Value)
                    Me.Dispose()
                    Me.Close()
                Else
                    If NuloString(GridClientes.Item(4, GridClientes.CurrentRow.Index).Value) <> "" Then
                        frmDelivery.tbBuscaCliente.Text = NuloString(GridClientes.Item(4, GridClientes.CurrentRow.Index).Value)
                        Me.Dispose()
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles GridClientes.KeyDown

        If e.KeyCode = 13 Then
            If GridClientes.Rows.Count > 0 Then
                If NuloString(GridClientes.Item(2, GridClientes.CurrentRow.Index).Value) <> "" Then
                    frmDelivery.tbBuscaCliente.Text = NuloString(GridClientes.Item(2, GridClientes.CurrentRow.Index).Value)
                    Me.Dispose()
                    Me.Close()
                Else
                    If NuloString(GridClientes.Item(3, GridClientes.CurrentRow.Index).Value) <> "" Then
                        frmDelivery.tbBuscaCliente.Text = NuloString(GridClientes.Item(3, GridClientes.CurrentRow.Index).Value)
                        Me.Dispose()
                        Me.Close()
                    Else
                        If NuloString(GridClientes.Item(4, GridClientes.CurrentRow.Index).Value) <> "" Then
                            frmDelivery.tbBuscaCliente.Text = NuloString(GridClientes.Item(4, GridClientes.CurrentRow.Index).Value)
                            Me.Dispose()
                            Me.Close()
                        End If
                    End If
                End If
            End If
        End If

    End Sub
End Class