Public Class fdlgSAT_ConsultaStatus
    Private Sub fdlgSAT_ConsultaStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Call CarregaIni_SatCP()
            Dim Texto As String, Carac As Integer, letra As String, CaracIni As Integer, campo As Integer
            frmPrincipal.tbmmRetorno.Text = spdSAT.ConsultarStatusOperacional(NumeroSessao)

            Texto = frmPrincipal.tbmmRetorno.Text
            lbStatus.Text = frmPrincipal.tbmmRetorno.Text
            Carac = 1
            CaracIni = 1
            campo = 1
            Do While Carac <= Len(Texto)
                letra = Mid(Texto, Carac, 1)
                If letra = "|" Then
                    If campo = 1 Then
                        lbN1.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 2 Then
                        lbN2.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 3 Then
                        lbN3.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 4 Then
                        lbN4.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 5 Then
                        lbN5.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 6 Then
                        lbN6.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 7 Then
                        lbN7.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 8 Then
                        lbN8.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 9 Then
                        lbN9.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 10 Then
                        lbN10.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 11 Then
                        lbN11.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 12 Then
                        lbN12.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 13 Then
                        lbN13.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 14 Then
                        lbN14.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 15 Then
                        lbN15.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 16 Then
                        lbN16.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 17 Then
                        lbN17.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 18 Then
                        lbN18.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 19 Then
                        lbN19.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 20 Then
                        lbN20.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 21 Then
                        lbN21.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 22 Then
                        lbN22.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 23 Then
                        lbN23.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 24 Then
                        lbN24.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 25 Then
                        lbN25.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 26 Then
                        lbN26.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 27 Then
                        lbN27.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    If campo = 28 Then
                        lbN28.Text = Mid(Texto, CaracIni + 1, (Carac - CaracIni) - 1)
                    End If
                    campo = campo + 1
                    CaracIni = Carac
                End If
                Carac = Carac + 1
            Loop

        Catch ex As Exception
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = ex.Message
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

        End Try


    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgSAT_ConsultaStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVolta, e)

        End Select
    End Sub
End Class