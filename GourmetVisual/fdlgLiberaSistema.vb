Public Class fdlgLiberaSistema
    Private Sub fdlgLiberaSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbChaveOK.Text = Int((DatePart("d", Now) * DatePart("m", Now) * DatePart("yyyy", Now)) * 7)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbChave.Text &= "0"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbChave.Text = ""
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbChave.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbChave.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbChave.Text &= "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbChave.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbChave.Text &= "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbChave.Text &= "6"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tbChave.Text &= "7"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tbChave.Text &= "8"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tbChave.Text &= "9"
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        Dim Ch As Integer
        Dim ChOK As Integer = tbChaveOK.Text
        Dim Acessos As Integer



        If tbChave.Text <> "" Then
            Ch = tbChave.Text
            Acessos = Ch / DatePart("d", Now)
            Acessos = Acessos / DatePart("m", Now)
            Acessos = Acessos / DatePart("yyyy", Now)
            Acessos = Int(Acessos / 7)

            If ChOK = (Ch / Acessos) Then

                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Sistema liberado para mais " & Acessos & " acessos"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                EscreveINI("Geral", "DU", DesmontaSenha(Acessos), nome_arquivo_ini)
                Me.Dispose()
                Me.Close()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Chave inválida." & vbCrLf & "O sistema será abortado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                End
            End If
        End If
    End Sub
End Class