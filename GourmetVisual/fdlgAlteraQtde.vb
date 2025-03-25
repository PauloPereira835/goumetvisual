Option Explicit On
Option Strict On

Public Class fdlgAlteraQtde

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbQtde.Text &= "0"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbQtde.Text = String.Empty
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbQtde.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbQtde.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbQtde.Text &= "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbQtde.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbQtde.Text &= "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbQtde.Text &= "6"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbQtde.Text &= "7"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbQtde.Text &= "8"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbQtde.Text &= "9"
    End Sub

    Private Sub fdlgAlteraQtde_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmSalao.Enabled = True
        If Not isDebug Then
            ' frmSalao.TopMost = True
        End If
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If tbQtde.Text <> "" Then
            Dim QtdeOK As Decimal
            Dim Linha As Integer
            If Modulo <> "D" Then
                Linha = frmSalao.Grid.CurrentRow.Index

                For i As Integer = 0 To frmSalao.Grid.Rows.Count - 1
                    If frmSalao.Grid.Rows(i).Selected = True Then
                        'MsgBox(NuloString(frmSalao.Grid.Item(2, i).Value))
                        Linha = i
                    End If
                Next


            Else
                Linha = frmDelivery.GridDel.CurrentRow.Index
            End If

            If Not IsNumeric(tbQtde.Text) Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Quantidade invalida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbQtde.Text = String.Empty
                Exit Sub
            End If
            QtdeOK = NuloDecimal(tbQtde.Text)

            Dim Totpro As Decimal
            If Modulo <> "D" Then
                frmSalao.Grid(3, Linha).Value = Format(QtdeOK, "#0.000")
                frmSalao.Grid(7, Linha).Value = QtdeOK

                Totpro = QtdeOK * NuloDecimal(frmSalao.Grid(8, Linha).Value)
                Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                frmSalao.Grid(11, Linha).Value = Format(Totpro, "#0.00").ToString
                frmSalao.Grid(10, Linha).Value = Totpro
                CalculaTotais()
            Else
                frmDelivery.GridDel(3, Linha).Value = Format(QtdeOK, "#0.000")
                frmDelivery.GridDel(7, Linha).Value = QtdeOK

                Totpro = QtdeOK * NuloDecimal(frmDelivery.GridDel(8, Linha).Value)
                Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                frmDelivery.GridDel(11, Linha).Value = Format(Totpro, "#0.00").ToString
                frmDelivery.GridDel(10, Linha).Value = Totpro
                CalculaTotaisDelivery()
            End If
        End If
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        tbQtde.Text &= ","
    End Sub

    Private Sub fdlgAlteraQtde_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Modulo <> "D" Then
            frmSalao.TimerTela.Enabled = False

            For i As Integer = 0 To frmSalao.Grid.Rows.Count - 1
                If frmSalao.Grid.Rows(i).Selected = True Then
                    'MsgBox(NuloString(frmSalao.Grid.Item(2, i).Value))
                    ProdutoSel = NuloString(frmSalao.Grid.Item(2, i).Value)
                End If
            Next
            'ProdutoSel = NuloString(frmSalao.Grid.Item(2, frmSalao.Grid.CurrentRow.Index).Value)
        Else

            ProdutoSel = NuloString(frmDelivery.GridDel.Item(2, frmDelivery.GridDel.CurrentRow.Index).Value)
        End If
        lbProduto.Text = ProdutoSel
        tbQtde.Focus()

    End Sub

    Private Sub fdlgAlteraQtde_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub fdlgAlteraQtde_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode

            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select
    End Sub

    Private Sub tbQtde_TextChanged(sender As Object, e As EventArgs) Handles tbQtde.TextChanged

    End Sub

    Private Sub tbQtde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtde.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            btnConfirma.Focus()
        End If

    End Sub
End Class