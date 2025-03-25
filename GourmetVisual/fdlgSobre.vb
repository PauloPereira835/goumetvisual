Public NotInheritable Class fdlgSobre

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbVersao.Text = Versao
        lbEmpresa.Text = Cliente
        lbLoja.Text = loja
        tbNumeroHD.Text = NumeroHD
        If RegistroDefinitivo = True Then
            lbValidade.Text = "DEFINITIVO"
        Else
            lbValidade.Text = CDate(DataLiberado).Date
        End If
        lbNome.Text = NomeRep
        lbNomeFantasia.Text = NomeFanRep
        lbTelefone.Text = TelefoneRep
        lbContato.Text = ContatoRep
        lbEmail.Text = EmailRep

    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub


End Class
