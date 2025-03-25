Imports System.Data.SqlClient

Public Class fdlgAtualizaCadastroRua
    Private Sub PreencheRuas()
        Dim QtdItens As Integer = 0
        Dim item As ListViewItem

        lstRuas.Items.Clear()


        strSql = "Select IDRua, Logradouro, Bairro, Cidade, Estado, Area "
        strSql += "From tblRuas "
        If tbBusca.Text <> "" Then
            strSql += "WHERE (tblRuas.Logradouro LIKE '%" & tbBusca.Text & "%') "
        End If
        strSql += "Order By tblRuas.Logradouro"

        If IsNumeric(tbBusca.Text) Then
            strSql = "Select tblRuas.IDRua, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuasCep.CEP "
            strSql += "From tblRuas INNER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
            strSql += "Where (tblRuasCep.CEP = '" & tbBusca.Text & "')"
        End If

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            item = lstRuas.Items.Add(ds.Tables("Ruas").Rows(i).Item("IDRua"))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Cidade")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Estado")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Area")))
            QtdItens += 1
        Next
        dap.Dispose()
        ds.Dispose()
        lbQtdeRuas.Text = "Qtde. de logradouros  " & QtdItens


    End Sub
    Private Sub FdlgAtualizaCadastroRua_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheRuas()
        lbLogradouro.Text = fdlgConsultaCEP.tbLogradouro.Text
        lbBairro.Text = fdlgConsultaCEP.tbBairro.Text
        lbCidade.Text = fdlgConsultaCEP.tbCidade.Text
        lbEstado.Text = fdlgConsultaCEP.tbEstado.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lstRuas.SelectedItems.Count > 0 Then
            Dim IDRua As Integer = NuloInteger(lstRuas.SelectedItems(0).SubItems(0).Text)

            strSql = "UPDATE tblRuas SET "
            strSql &= "Logradouro='" & VerificaTexto(UCase(NuloString(lbLogradouro.Text))) & "',"
            strSql &= "Atualiza=1,"
            strSql &= "Bairro='" & VerificaTexto(UCase(NuloString(fdlgConsultaCEP.tbBairro.Text))) & "',"
            strSql &= "Cidade='" & UCase(NuloString(lbCidade.Text)) & "',"
            strSql &= "Estado='" & UCase(NuloString(lbEstado.Text)) & "' "
            strSql &= "WHERE (IDRua=" & IDRua & ")"
            ExecutaStr(strSql)

            Me.Dispose()
            Me.Close()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário setecionar um logradouro"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If

    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheRuas()
    End Sub
End Class