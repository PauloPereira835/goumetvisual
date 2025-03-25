Public Class fdlgCalculadoraFormaPagto
    Private Sub FdlgCalculadoraFormaPagto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fdlgCalculadoraFormaPagto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                frmPagamento.tbValor.Text = Format(NuloDecimal(lbTotal.Text), "#0.00")
                Me.Dispose()
                Me.Close()

        End Select
    End Sub

    Private Sub TbMultiplicador_TextChanged(sender As Object, e As EventArgs) Handles tbMultiplicador.TextChanged

    End Sub

    Private Sub tbMultiplicador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMultiplicador.KeyPress

        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If NuloDecimal(tbMultiplicador.Text) = 0 Then
                lbTotal.Text = Format(lbValor.Text, "#0.00")
            Else
                lbTotal.Text = Format(NuloDecimal(lbValor.Text) * NuloDecimal(tbMultiplicador.Text), "#0.00")
            End If
            btnConfirma.Focus()

        End If

    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        frmPagamento.tbValor.Text = Format(NuloDecimal(lbTotal.Text), "#0.00")
                Me.Dispose()
                Me.Close()


    End Sub

    Private Sub btnConfirma_KeyDown(sender As Object, e As KeyEventArgs) Handles btnConfirma.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                frmPagamento.tbValor.Text = Format(NuloDecimal(lbTotal.Text), "#0.00")
                Me.Dispose()
                Me.Close()

        End Select
    End Sub
End Class