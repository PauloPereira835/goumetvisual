Imports GourmetVisual.IfoodMerchantOrderResponse

Public Class fdlgAgrupamentoNovo_Clube
    Private Sub btnAgrupamento_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If NuloString(tbNomeAgrupamento.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Nome do agrupamento inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbNomeAgrupamento.Focus()
            Exit Sub
        End If

        Dim Retorno As String
        strSql = "Select IDAgrupamento, Descricao From tblAgrupamento_Clube Where (Descricao = '" & tbNomeAgrupamento.Text & "')"
        Retorno = PegaValorCampo("Descricao", strSql, strCon)
        If Retorno <> "ERRO" And Retorno <> "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Nome do agrupamento já cadastrado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbNomeAgrupamento.Focus()
            Exit Sub
        End If

        strSql = "INSERT tblAgrupamento_Clube "
        strSql += "(Descricao) VALUES ("
        strSql += to_sql(Strings.Left(UCase(tbNomeAgrupamento.Text), 30)) & ")"
        ExecutaStr(strSql)

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub tbNomeAgrupamento_TextChanged(sender As Object, e As EventArgs) Handles tbNomeAgrupamento.TextChanged

    End Sub

    Private Sub tbNomeAgrupamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNomeAgrupamento.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            btnConfirma.Focus()
        End If
    End Sub
End Class