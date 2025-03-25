Imports System.Data.SqlClient

Public Class fdlgMotivoEstorno
    Private Sub PreencheMotivos()
        Dim item As ListViewItem

        strSql = "Select IDMotivoEstorno, Motivo, EstornoProduto, EstornoVenda, Transferencia "
        strSql += "From tblMotivosEstorno "
        strSql += "Order By Motivo"

        Dim conA As New SqlConnection(strCon)
        conA.Open()
        Dim cmdA As New SqlCommand(strSql, conA)
        cmdA.CommandType = CommandType.Text

        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstMotivos.Items.Clear()

        If drA.HasRows Then
            While drA.Read()
                item = lstMotivos.Items.Add(drA.Item("IDMotivoEstorno"))
                item.SubItems.Add(drA.Item("Motivo"))
                If drA.Item("EstornoProduto") = True Then
                    item.SubItems.Add("Sim")
                Else
                    item.SubItems.Add("Não")
                End If
                If drA.Item("EstornoVenda") = True Then
                    item.SubItems.Add("Sim")
                Else
                    item.SubItems.Add("Não")
                End If
                If drA.Item("Transferencia") = True Then
                    item.SubItems.Add("Sim")
                Else
                    item.SubItems.Add("Não")
                End If


            End While
            lstMotivos.Update()
            lstMotivos.EndUpdate()
        End If

        drA.Close()
        cmdA.Dispose()
        conA.Dispose()
        conA.Close()


    End Sub
    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click


        If tbMotivo.Text = "" Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "É necessário digitar um motivo"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            tbMotivo.Focus()
            Exit Sub
        End If

        strSql = "Select * FROM tblMotivosEstorno WHERE Motivo='" & UCase(tbMotivo.Text) & "'"
        If PegaValorCampo("Motivo", strSql, strCon) <> "" Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Motivo já cadastrado"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm2.ShowDialog()
            tbMotivo.Focus()
            Exit Sub
        End If
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Confirma a inclusão"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        tbMotivo.Focus()
        If RetornoMsg = False Then Exit Sub

        strSql = "INSERT tblMotivosEstorno "
        strSql += "(Motivo, EstornoProduto, EstornoVenda, Transferencia) VALUES ("
        strSql += to_sql(UCase(tbMotivo.Text)) & ","
        If chkProduto.Checked = False Then
            strSql += "0,"
        Else
            strSql += "1,"
        End If
        If chkVenda.Checked = False Then
            strSql += "0,"
        Else
            strSql += "1,"
        End If
        If chkTransfere.Checked = False Then
            strSql += "0)"
        Else
            strSql += "1)"
        End If
        ExecutaStr(strSql)

        tbMotivo.Text = ""
        chkProduto.Checked = False
        chkTransfere.Checked = False
        chkVenda.Checked = False
        PreencheMotivos()

    End Sub

    Private Sub fdlgMotivoEstorno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheMotivos()
    End Sub

    Private Sub lstMotivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMotivos.SelectedIndexChanged
        If lstMotivos.SelectedItems.Count > 0 Then
            tbMotivo.Text = lstMotivos.SelectedItems(0).SubItems(1).Text
            If lstMotivos.SelectedItems(0).SubItems(2).Text = "Sim" Then
                chkProduto.Checked = True
            Else
                chkProduto.Checked = False
            End If
            If lstMotivos.SelectedItems(0).SubItems(3).Text = "Sim" Then
                chkVenda.Checked = True
            Else
                chkVenda.Checked = False
            End If
            If lstMotivos.SelectedItems(0).SubItems(4).Text = "Sim" Then
                chkTransfere.Checked = True
            Else
                chkTransfere.Checked = False
            End If
        End If
    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click

        If lstMotivos.SelectedItems.Count = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "È necessário selecionar um motivo"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm2.ShowDialog()
            tbMotivo.Focus()
        End If

        strSql = "UPDATE tblMotivosEstorno SET "
        strSql &= "Motivo='" & UCase(tbMotivo.Text) & "', "
        If chkProduto.Checked = True Then
            strSql &= "EstornoProduto=1, "
        Else
            strSql &= "EstornoProduto=0, "
        End If
        If chkVenda.Checked = True Then
            strSql &= "EstornoVenda=1, "
        Else
            strSql &= "EstornoVenda=0, "
        End If
        If chkTransfere.Checked = True Then
            strSql &= "Transferencia=1 "
        Else
            strSql &= "Transferencia=0 "
        End If
        strSql &= "WHERE (IDMotivoEstorno=" & lstMotivos.SelectedItems(0).SubItems(0).Text & ")"
        ExecutaStr(strSql)
        PreencheMotivos()

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If lstMotivos.SelectedItems.Count = 0 Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "È necessário selecionar um motivo"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm2.ShowDialog()
            tbMotivo.Focus()
        End If
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Confirma a EXCLUSÃO"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        tbMotivo.Focus()
        If RetornoMsg = False Then Exit Sub

        strSql = "DELETE FROM tblMotivosEstorno WHERE (IDMotivoEstorno=" & lstMotivos.SelectedItems(0).SubItems(0).Text & ")"
        ExecutaStr(strSql)
        PreencheMotivos()
        tbMotivo.Text = ""
        chkProduto.Checked = False
        chkTransfere.Checked = False
        chkVenda.Checked = False

    End Sub
End Class