Public Class fdlgAcessoLivre
    Dim Status As Integer = 1
    Dim SenhaMaster As Integer = 0
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub tbSenha_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSenha.KeyDown
        If e.KeyCode = 13 Then
            If Status = 1 Then
                SenhaMaster = NuloInteger(tbSenha.Text)
                Status = 2
                tbSenha.Text = ""
                Exit Sub
            End If
            If Status = 2 Then
                SenhaMaster = SenhaMaster * NuloInteger(tbSenha.Text)
                Status = 3
                tbSenha.Text = ""
                Exit Sub
            End If
            If Status = 3 Then
                SenhaMaster = SenhaMaster * NuloInteger(tbSenha.Text)
                Status = 4
                tbSenha.Text = ""
                Exit Sub
            End If
            If Status = 4 Then
                SenhaMaster = SenhaMaster * NuloInteger(tbSenha.Text)
                frmPrincipal.lblSenha.Text = SenhaMaster
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub fdlgAcessoLivre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbSenha.Focus()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbSenha.Text += "0"
        tbSenha.Focus()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbSenha.Text += "1"
        tbSenha.Focus()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbSenha.Text += "2"
        tbSenha.Focus()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbSenha.Text += "3"
        tbSenha.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbSenha.Text += "4"
        tbSenha.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbSenha.Text += "5"
        tbSenha.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbSenha.Text += "6"
        tbSenha.Focus()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tbSenha.Text += "7"
        tbSenha.Focus()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tbSenha.Text += "8"
        tbSenha.Focus()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tbSenha.Text += "9"
        tbSenha.Focus()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbSenha.Text = ""
        tbSenha.Focus()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Status = 1 Then
            SenhaMaster = NuloInteger(tbSenha.Text)
            Status = 2
            tbSenha.Text = ""
            Exit Sub
        End If
        If Status = 2 Then
            SenhaMaster = SenhaMaster * NuloInteger(tbSenha.Text)
            Status = 3
            tbSenha.Text = ""
            Exit Sub
        End If
        If Status = 3 Then
            SenhaMaster = SenhaMaster * NuloInteger(tbSenha.Text)
            Status = 4
            tbSenha.Text = ""
            Exit Sub
        End If
        If Status = 4 Then
            SenhaMaster = SenhaMaster * NuloInteger(tbSenha.Text)
            frmPrincipal.lblSenha.Text = SenhaMaster
            Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class