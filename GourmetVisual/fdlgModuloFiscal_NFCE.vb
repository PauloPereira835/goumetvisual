Public Class fdlgModuloFiscal_NFCE
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fdlgNFCE.ShowDialog()
    End Sub
End Class