Public Class fdlgPegaPeso
    Dim Retorno As Long
    Dim QtdPeso As String
    Dim QtdKilo As String
    Dim QtdGrama As String
    Dim BalancaOK As Boolean
    Dim RetornoBal As Long
    Dim Teclado As Boolean = False
    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click

        FechaPortaP05
        TimerBalanca.Stop()
        TimerBalanca.Enabled = False

        PesoPego = 0
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub fdlgPegaPeso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If PortaBalanca = "" Then Exit Sub
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = False

        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")

        RetornoBal = 1
        RetornoBal = AbrePorta(PortaBalanca, 0, 0, 2)
        ' Paridade.....Par
        ' Bit...........7
        ' Velocidade....2400
        If RetornoBal = 1 Then
            BalancaOK = True

            Try

                Kill(Application.StartupPath & "\PESO.TXT")

            Catch ex As Exception
                'MsgBox(ex.Message)
                ' FechaPortaP05
            End Try
            TimerBalanca.Enabled = True
            TimerBalanca.Interval = 150

            FechaPortaP05

        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Erro ao conectar com a balança!"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            BalancaOK = False
            tbPesoBruto.Text = Format(0, "#0.000")
            tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
            tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
        End If

        '[Tara].Caption = Format(frmGrupos!Tara, "#0.000")
        '[txtProduto].Caption = frmGrupos!Produto
        '[txtValor].Caption = Format(frmGrupos!Venda, "#0.00")

        '[Tara].Refresh
        '[txtProduto].Refresh
        '[txtValor].Refresh



    End Sub

    Private Sub btnConfirmaVenda_Click(sender As Object, e As EventArgs) Handles btnConfirmaVenda.Click

        TimerBalanca.Enabled = False
        FechaPortaP05
        PesoPego = NuloDecimal(tbPesoLiquido.Text)
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub TimerBalanca_Tick(sender As Object, e As EventArgs) Handles TimerBalanca.Tick



        If Teclado = False Then
            RetornoBal = AbrePorta(PortaBalanca, 0, 0, 2)

            QtdPeso = "00000"
            Retorno = PegaPeso(0, QtdPeso, Application.StartupPath & "\")

            If Retorno = 1 Then
                QtdKilo = Strings.Left(QtdPeso, 2)
                If Val(QtdKilo) <= 0 Then
                    QtdKilo = "0"
                Else
                    QtdKilo = Val(Strings.Left(QtdPeso, 2))
                End If
                QtdGrama = Strings.Right(QtdPeso, 3)
                tbPesoBruto.Text = NuloDecimal(QtdKilo & "," & QtdGrama)
            Else
                tbPesoBruto.Text = "ERRO"
            End If

            If UCase(tbPesoBruto.Text) = "ERRO" Then
                tbPesoBruto.Text = Format(0, "#0.000")
                tbPesoLiquido.Text = Format(NuloDecimal(tbPesoBruto.Text) - NuloDecimal(tbTara.Text), "#0.000")
                tbTotal.Text = Format(NuloDecimal(tbVenda.Text) * NuloDecimal(tbPesoLiquido.Text), "#0.00")
                lbErro.Text = "ERRO de leitura !!!"
                lbErro.Visible = True
            Else
                lbErro.Visible = False
                tbPesoLiquido.Text = Format(NuloDecimal(tbPesoBruto.Text) - NuloDecimal(tbTara.Text), "#0.000")
                tbTotal.Text = Format(NuloDecimal(tbVenda.Text) * NuloDecimal(tbPesoLiquido.Text), "#0.00")
            End If
            tbPesoBruto.Refresh()
        End If




    End Sub

    Private Sub fdlgPegaPeso_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Teclado = False Then
            Teclado = True
            FechaPortaP05
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "0"
        tbPesoLiquido.Text = Format(NuloDecimal(tbPesoBruto.Text) - NuloDecimal(tbTara.Text), "#0.000")
        tbTotal.Text = Format(NuloDecimal(tbVenda.Text) * NuloDecimal(tbPesoLiquido.Text), "#0.00")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        If InStr(tbPesoBruto.Text, ",") = 0 And tbPesoBruto.Text <> "" Then
            tbPesoBruto.Text += ","
            tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
            tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "1"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "2"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "3"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "4"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "5"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "6"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "7"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "8"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text += "9"
        tbPesoLiquido.Text = Format(tbPesoBruto.Text - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Teclado = False Then
            Teclado = True
            tbPesoBruto.Text = ""
        End If
        tbPesoBruto.Text = ""
        tbPesoLiquido.Text = Format(0 - tbTara.Text, "#0.000")
        tbTotal.Text = Format(tbVenda.Text * tbPesoLiquido.Text, "#0.00")

    End Sub
End Class