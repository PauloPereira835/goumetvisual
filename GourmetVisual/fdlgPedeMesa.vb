Public Class fdlgPedeMesa
    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        MesaCartao = tbMesa.Text
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbMesa.Text += "0"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbMesa.Text += "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbMesa.Text += "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbMesa.Text += "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbMesa.Text += "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbMesa.Text += "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbMesa.Text += "6"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbMesa.Text += "7"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbMesa.Text += "8"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbMesa.Text += "9"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbMesa.Text = ""
    End Sub

    Private Sub fdlgPedeMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = False
        lbCartao.Text = frmSalao.tbMesa.Text
        tbMesa.Focus()
    End Sub

    Private Sub fdlgPedeMesa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select
    End Sub

    Private Sub tbMesa_TextChanged(sender As Object, e As EventArgs) Handles tbMesa.TextChanged

    End Sub

    Private Sub tbMesa_KeyDown(sender As Object, e As KeyEventArgs) Handles tbMesa.KeyDown

        Select Case e.KeyCode
            Case Keys.KeyCode.Enter
                Me.InvokeOnClick(btnConfirma, e)

        End Select

    End Sub

    Private Sub fdlgPedeMesa_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub


End Class