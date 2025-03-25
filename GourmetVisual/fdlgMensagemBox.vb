Public Class fdlgMensagemBox
    Private Sub btnSim_Click(sender As Object, e As EventArgs) Handles btnSim.Click
        RetornoMsg = True
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnNao_Click(sender As Object, e As EventArgs) Handles btnNao.Click

        RetornoMsg = False
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnSim.KeyPress
        If e.KeyChar = "s" Or e.KeyChar = "S" Then
            RetornoMsg = True
            Me.Dispose()
            Me.Close()
        End If
        If e.KeyChar = "n" Or e.KeyChar = "N" Then
            RetornoMsg = False
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If NuloInteger(lbTempo.Text) > 0 Then
            lbTempo.Text -= 1
            lbTempo.Refresh()
        Else
            RetornoMsg = False
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub FdlgMensagemBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If NuloInteger(tbTempoInicio.Text) <> 0 Then
            lbTempo.Text = NuloInteger(tbTempoInicio.Text)
            lbTempo.Visible = True
            Timer.Enabled = True
            Timer.Start()
        Else
            lbTempo.Visible = False
            lbTempo.Text = 0
            Timer.Enabled = False
            Timer.Stop()
        End If
    End Sub
End Class