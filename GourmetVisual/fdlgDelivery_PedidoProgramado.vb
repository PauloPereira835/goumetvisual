Public Class fdlgDelivery_PedidoProgramado
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgDelivery_PedidoProgramado_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub ChkPedidoProgAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chkPedidoProgAutomatico.CheckedChanged

        If chkPedidoProgAutomatico.Checked = True Then
            Label2.Visible = True
            DtTime.Visible = True
        Else
            Label2.Visible = False
            DtTime.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If DtTime.Value < Now And chkPedidoProgAutomatico.Checked = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Horário inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        strSql = "UPDATE tblVendas SET "
        If chkPedidoProgAutomatico.Checked = False Then
            strSql += "PedidoProgAutomatico=0, PedidoProgEnvioAs=NULL "
        Else
            strSql += "PedidoProgAutomatico=1, "
            strSql += "PedidoProgEnvioAs = '" & DtTime.Value & "' "
        End If
        strSql &= "WHERE (IDVenda=" & IDVenda & ")"
        ExecutaStr(strSql)

        Me.Dispose()
        Me.Close()
    End Sub
End Class