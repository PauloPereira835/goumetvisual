Public Class fdlgIfoodConfig
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        appIfoodMerchant.authorizationCode = tbCodigo.Text
        Me.Close()
        Me.Dispose()

    End Sub
End Class