Public Class fdlgQtdePessoas_Balcao
    Private Sub Confirma()

        strSql = "UPDATE tblVendas SET QtdPessoas=" & tbQtdPessoas.Text & " WHERE IDVenda=" & tbIDVenda.Text
        ExecutaStr(strSql)

        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbQtdPessoas.Text += "0"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbQtdPessoas.Text += "1"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbQtdPessoas.Text += "2"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbQtdPessoas.Text += "3"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbQtdPessoas.Text += "4"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbQtdPessoas.Text += "5"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbQtdPessoas.Text += "6"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tbQtdPessoas.Text += "7"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tbQtdPessoas.Text += "8"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tbQtdPessoas.Text += "9"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        Confirma()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbQtdPessoas.Text = "1"
        tbQtdPessoas.Focus()
    End Sub

    Private Sub fdlgQtdePessoas_Balcao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbQtdPessoas.Focus()
    End Sub

    Private Sub tbQtdPessoas_TextChanged(sender As Object, e As EventArgs) Handles tbQtdPessoas.TextChanged

    End Sub

    Private Sub tbQtdPessoas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtdPessoas.KeyPress

        If AscW(e.KeyChar) = 13 Then
            Confirma()
        End If
    End Sub
End Class