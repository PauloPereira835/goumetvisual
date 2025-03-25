Public Class fdlgChat
    Private Sub TbSuporte_TextChanged(sender As Object, e As EventArgs) Handles tbSuporte.TextChanged

    End Sub


    Private Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub tbSuporte_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSuporte.KeyDown
        If e.KeyCode = 45 Then
            tbSuporte.ReadOnly = False
        End If
        If e.KeyCode = 35 Then
            tbSuporte.ReadOnly = True
            tbCliente.Focus()
        End If
    End Sub

    Private Sub FdlgChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tbSuporte.Enabled = False
        tbSuporte.ReadOnly = True
        lbCliente.Text = frmPrincipal.lbLoja.Text
        tbCliente.Focus()
    End Sub

    Private Sub TbCliente_TextChanged(sender As Object, e As EventArgs) Handles tbCliente.TextChanged

    End Sub

    Private Sub tbCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCliente.KeyDown
        If e.KeyCode = 45 Then
            tbSuporte.Enabled = True
        End If
        If e.KeyCode = 35 Then
            tbSuporte.Enabled = False
        End If
    End Sub
End Class