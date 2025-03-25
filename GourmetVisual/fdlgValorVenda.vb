Public Class fdlgValorVenda
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbValor.Text &= "0"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        tbValor.Text &= ","
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbValor.Text = ""
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbValor.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbValor.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbValor.Text &= "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbValor.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbValor.Text &= "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbValor.Text &= "6"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbValor.Text &= "7"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbValor.Text &= "8"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbValor.Text &= "9"
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If tbValor.Text = "" Then
            VlrUnitario = 0
        Else
            VlrUnitario = NuloDecimal(tbValor.Text)
        End If

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub fdlgValorVenda_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = False
        lbProduto.Text = ProdutoSel
        tbValor.Focus()
    End Sub

    Private Sub tbValor_TextChanged(sender As Object, e As EventArgs) Handles tbValor.TextChanged

    End Sub

    Private Sub tbValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbValor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnConfirma.Focus()
        End If
    End Sub

    Private Sub btnConfirma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnConfirma.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnConfirma.Focus()
        End If
    End Sub

    Private Sub fdlgValorVenda_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode

            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)


        End Select
    End Sub

    Private Sub btnConfirma_KeyDown(sender As Object, e As KeyEventArgs) Handles btnConfirma.KeyDown
        Select Case e.KeyCode

            Case Keys.KeyCode.Enter
                Me.InvokeOnClick(btnConfirma, e)


        End Select
    End Sub

    Private Sub fdlgValorVenda_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub
End Class