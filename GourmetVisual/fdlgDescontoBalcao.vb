Public Class fdlgDescontoBalcao
    Public Foco As String
    Private Sub TbDescPerc_TextChanged(sender As Object, e As EventArgs) Handles tbDescPerc.TextChanged

    End Sub

    Private Sub tbDescPerc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescPerc.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If tbDescPerc.Text <> "" Then
                Dim VlrD As Decimal = NuloDecimal(tbTotalProdutos.Text) * (NuloDecimal(tbDescPerc.Text) / 100)
                tbDescValor.Text = NuloString(Format(NuloDecimal(VlrD), "#0.00"))
            End If
            tbDescValor.Focus()
        End If
    End Sub

    Private Sub TbDescValor_TextChanged(sender As Object, e As EventArgs) Handles tbDescValor.TextChanged

    End Sub

    Private Sub tbDescValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDescValor.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If tbDescValor.Text <> "" Then
                Dim VlrD As Decimal = NuloDecimal((NuloDecimal(tbDescValor.Text) / NuloDecimal(tbTotalProdutos.Text)) * 100)
                tbDescPerc.Text = NuloString(Format(NuloDecimal(VlrD), "#0.000"))
            End If

            Me.InvokeOnClick(btnConfirma, e)

        End If
    End Sub

    Private Sub tbDescPerc_GotFocus(sender As Object, e As EventArgs) Handles tbDescPerc.GotFocus
        Foco = "P"
    End Sub

    Private Sub tbDescValor_GotFocus(sender As Object, e As EventArgs) Handles tbDescValor.GotFocus
        Foco = "V"
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        Dim VlrD As Decimal
        If tbDescValor.Text <> "" Then
            VlrD = NuloDecimal((NuloDecimal(tbDescValor.Text) / NuloDecimal(tbTotalProdutos.Text)) * 100)

            strSql = "UPDATE tblVendas SET "
            strSql &= "Desconto=" & Replace(tbDescValor.Text, ",", ".") & ", "
            strSql &= "PercDesconto=" & Replace(NuloString(VlrD), ",", ".") & " "
            strSql += "WHERE (IDVenda = " & tbIDVenda.Text & ")"
            ExecutaStr(strSql)
            PercDesconto = NuloDecimal(NuloDecimal(VlrD))
        Else
            If tbDescPerc.Text <> "" Then
                VlrD = NuloDecimal(tbTotalProdutos.Text) * (NuloDecimal(tbDescPerc.Text) / 100)
                strSql = "UPDATE tblVendas SET "
                strSql &= "Desconto=" & Replace(NuloString(VlrD), ",", ".") & ", "
                strSql &= "PercDesconto=" & Replace(tbDescPerc.Text, ",", ".") & " "
                strSql += "WHERE (IDVenda = " & tbIDVenda.Text & ")"

                tbDescValor.Text = NuloString(Format(NuloDecimal(VlrD), "#0.00"))
                ExecutaStr(strSql)
                PercDesconto = NuloDecimal(NuloDecimal(tbDescPerc.Text))
            End If
        End If

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Foco = "P" Then
            tbDescPerc.Text += "0"
        Else
            tbDescValor.Text += "0"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Foco = "P" Then
            tbDescPerc.Text += "9"
        Else
            tbDescValor.Text += "9"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Foco = "P" Then
            tbDescPerc.Text += "8"
        Else
            tbDescValor.Text += "8"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Foco = "P" Then
            tbDescPerc.Text += "7"
        Else
            tbDescValor.Text += "7"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Foco = "P" Then
            tbDescPerc.Text += "6"
        Else
            tbDescValor.Text += "6"
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Foco = "P" Then
            tbDescPerc.Text += "5"
        Else
            tbDescValor.Text += "5"
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Foco = "P" Then
            tbDescPerc.Text += "4"
        Else
            tbDescValor.Text += "4"
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Foco = "P" Then
            tbDescPerc.Text += "3"
        Else
            tbDescValor.Text += "3"
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Foco = "P" Then
            tbDescPerc.Text += "2"
        Else
            tbDescValor.Text += "2"
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If Foco = "P" Then
            tbDescPerc.Text += "1"
        Else
            tbDescValor.Text += "1"
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Foco = "P" Then
            tbDescPerc.Text += "."
        Else
            tbDescValor.Text += "."
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Foco = "P" Then
            tbDescPerc.Text = ""
        Else
            tbDescValor.Text = ""
        End If
    End Sub

    Private Sub FdlgDescontoBalcao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbDescPerc.Focus()
    End Sub

    Private Sub tbDescPerc_Enter(sender As Object, e As EventArgs) Handles tbDescPerc.Enter
        Foco = "P"
    End Sub

    Private Sub tbDescValor_Enter(sender As Object, e As EventArgs) Handles tbDescValor.Enter
        Foco = "V"
    End Sub


End Class