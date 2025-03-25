Imports System.Data.SqlClient

Public Class fdlgAplicativos
    Dim entrou As Boolean = False
    Private Sub MonteInstalacoes()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        Dim item As ListViewItem

        lstLojasApp.Items.Clear()

        SqlStr = "Select App, IDClient, Descricao, SenhaGV, UserName, Password, Audience, Client_Secret, IDLoja, IDMerchant, Token, DataHoraExpira "
        SqlStr += "From tblLojasApp "
        SqlStr += "Order by Descricao"

        cmd.CommandText = SqlStr

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While (dr.Read())
                item = lstLojasApp.Items.Add(NuloString(dr.Item("Descricao")))
                item.SubItems.Add(NuloString(dr.Item("App")))
                item.SubItems.Add(NuloString(dr.Item("IDClient")))
                item.SubItems.Add(NuloString(dr.Item("UserName")))
                item.SubItems.Add(NuloString(dr.Item("Password")))
                item.SubItems.Add(NuloString(dr.Item("Audience")))
                item.SubItems.Add(NuloString(dr.Item("Client_Secret")))
                item.SubItems.Add(NuloString(dr.Item("IDLoja")))
                item.SubItems.Add(NuloString(dr.Item("IDMerchant")))
            End While

            lstLojasApp.Update()
            lstLojasApp.EndUpdate()

        End If
        dr.Close()
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub LimpaTela()
        cbApp.Text = ""
        tbDescricao.Text = ""
        tbIDLoja.Text = ""
        tbIDClientRappi.Text = ""
        tbIDClientIfood.Text = ""
        tbClientSecret.Text = ""
        tbAudience.Text = ""
        tbUserName.Text = ""
        tbPassword.Text = ""
        tbIDMerchant.Text = ""
        If lstLojasApp.SelectedItems.Count = 0 Then
            lstLojasApp.SelectedItems.Clear()
        End If
    End Sub
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        If btnGravar.Enabled = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja sair sem gravar as informações alteradas"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub
        End If
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgAplicativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Dados As New ArrayList()
        With Dados
            .Add("")
            .Add("IFOOD")
            .Add("RAPPI")
            .Add("QRBOX")
        End With
        cbApp.DataSource = Dados

        MonteInstalacoes()

        entrou = True
    End Sub

    Private Sub BtnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If btnGravar.Enabled = True Then
            frm.lbMensagem.Text = "Deseja continuar sem gravar as informações alteradas"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub
        End If

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Deseja inserir uma nova instalação"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm1.ShowDialog()
        If RetornoMsg = False Then Exit Sub


        LimpaTela()

        strSql = "INSERT tblLojasApp (App, IDClient, Descricao, SenhaGV, UserName, Password, Audience, Client_Secret, IDLoja, Token, DataHoraExpira) VALUES ("
        strSql &= "'','','','','','','','','','','')"
        ExecutaStr(strSql)
        MonteInstalacoes()
        btnGravar.Enabled = False

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles tbDescricao.TextChanged
        If lstLojasApp.SelectedItems.Count = 0 And entrou = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma instalação"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbApp.Text = ""
        End If
        btnGravar.Enabled = True
    End Sub

    Private Sub TbClient_ID_Rappi_TextChanged(sender As Object, e As EventArgs) Handles tbIDClientIfood.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tbUserName.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles tbPassword.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles tbIDLoja.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles tbIDClientRappi.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles tbClientSecret.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles tbAudience.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub LstLojasApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLojasApp.SelectedIndexChanged
        If lstLojasApp.SelectedItems.Count > 0 Then
            If btnGravar.Enabled = True Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Deseja continuar sem gravar as informações alteradas"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = False Then Exit Sub
            End If
            For i = 0 To lstLojasApp.Items.Count - 1
                If lstLojasApp.Items(i).Selected = True Then
                    tbDescricao.Text = NuloString(lstLojasApp.Items(i).SubItems(0).Text)
                    cbApp.Text = NuloString(lstLojasApp.Items(i).SubItems(1).Text)
                    tbIDClientIfood.Text = NuloString(lstLojasApp.Items(i).SubItems(2).Text)
                    tbIDClientRappi.Text = NuloString(lstLojasApp.Items(i).SubItems(2).Text)
                    tbUserName.Text = NuloString(lstLojasApp.Items(i).SubItems(3).Text)
                    tbPassword.Text = NuloString(lstLojasApp.Items(i).SubItems(4).Text)
                    tbAudience.Text = NuloString(lstLojasApp.Items(i).SubItems(5).Text)
                    tbClientSecret.Text = NuloString(lstLojasApp.Items(i).SubItems(6).Text)
                    tbIDLoja.Text = NuloString(lstLojasApp.Items(i).SubItems(7).Text)
                    tbIDMerchant.Text = NuloString(lstLojasApp.Items(i).SubItems(8).Text)
                    btnGravar.Enabled = False
                End If
            Next

        End If

    End Sub

    Private Sub CbApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbApp.SelectedIndexChanged
        If lstLojasApp.SelectedItems.Count = 0 And entrou = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma instalação"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            cbApp.Text = ""
        End If
        If cbApp.Text = "IFOOD" Then
            PainelIfood.Visible = True
        Else
            PainelIfood.Visible = False
        End If
        If cbApp.Text = "RAPPI" Then
            PainelRappi.Visible = True
        Else
            PainelRappi.Visible = False
        End If
    End Sub

    Private Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If tbDescricao.Text = "" Then
            frm.lbMensagem.Text = "Descrição da instalação inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        strSql = "UPDATE tblLojasApp SET "
        strSql += "App='" & cbApp.Text & "', "
        If cbApp.Text = "IFOOD" Then
            strSql += "IDClient='" & NuloString(tbIDClientIfood.Text) & "', "
        End If
        If cbApp.Text = "RAPPI" Then
            strSql += "IDClient='" & NuloString(tbIDClientRappi.Text) & "', "
        End If
        strSql += "Descricao='" & UCase(NuloString(tbDescricao.Text)) & "', "
        strSql += "UserName='" & NuloString(tbUserName.Text) & "', "
        strSql += "Password='" & NuloString(tbPassword.Text) & "', "
        strSql += "Audience='" & NuloString(tbAudience.Text) & "', "
        strSql += "Client_Secret='" & NuloString(tbClientSecret.Text) & "', "
        strSql += "IDLoja='" & NuloString(tbIDLoja.Text) & "', "
        strSql += "IDMerchant='" & NuloString(tbIDMerchant.Text) & "' "
        strSql += "WHERE (Descricao='" & NuloString(lstLojasApp.SelectedItems(0).Text) & "')"
        ExecutaStr(strSql)

        MonteInstalacoes()

        frm.lbMensagem.Text = "Informações gravadas com sucesso"
        frm.btnNao.Visible = False
        frm.btnSim.Visible = False
        frm.btnOK.Visible = True
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm.ShowDialog()


        btnGravar.Enabled = False

    End Sub

    Private Sub TbIDMerchant_TextChanged(sender As Object, e As EventArgs) Handles tbIDMerchant.TextChanged
        btnGravar.Enabled = True
    End Sub
End Class