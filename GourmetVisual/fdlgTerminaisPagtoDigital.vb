Imports System.Data.SqlClient

Public Class fdlgTerminaisPagtoDigital
    Private Sub MontaTerminais()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        Dim item As ListViewItem

        lstTerminais.Items.Clear()

        SqlStr = "Select IDTerminal, Terminal From tblTerminais Order by Terminal"

        cmd.CommandText = SqlStr

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While (dr.Read())
                item = lstTerminais.Items.Add(NuloString(dr.Item("Terminal")))
            End While
            lstTerminais.Update()
            lstTerminais.EndUpdate()

        End If
        dr.Close()
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub FdlgTerminaisPagtoDigital_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MontaTerminais()
        Dim Dados As New ArrayList()
        With Dados
            .Add("")
            .Add("BEMATECH")
            .Add("DARUMA")
            .Add("EPSON")
        End With
        cbImpressora.DataSource = Dados


        SqlStr = "Select AccessKey_Shipay, SecretKey_Shipay From tblConfig"
        tbAccessKey_Shipay.Text = NuloString(PegaValorCampo("AccessKey_Shipay", SqlStr, strCon))
        tbSecretKey_Shipay.Text = NuloString(PegaValorCampo("SecretKey_Shipay", SqlStr, strCon))


    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click



        strSql = "UPDATE tblConfig SET "
        strSql += "AccessKey_Shipay = '" & NuloString(tbAccessKey_Shipay.Text) & "', "
        strSql += "SecretKey_Shipay = '" & NuloString(tbSecretKey_Shipay.Text) & "'"
        ExecutaStr(strSql)

        If lstTerminais.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um terminal"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        strSql = "SELECT Terminal, ClientID, ImpressoraPagtoDigital, Status FROM tblTerminaisPagtoDigital WHERE Terminal = '" & NuloString(lstTerminais.SelectedItems.Item(0).SubItems(0).Text) & "'"
        If NuloString(PegaValorCampo("Terminal", strSql, strCon)) <> "" Then
            strSql = "UPDATE tblTerminaisPagtoDigital SET "
            strSql += "ClientID = '" & NuloString(tbClientID_Shipay.Text) & "', "
            strSql += "ImpressoraPagtoDigital = '" & NuloString(cbImpressora.Text) & "', "
            strSql += "PortaImpressora = '" & NuloString(tbPorta.Text) & "' "
            strSql += "WHERE Terminal='" & NuloString(lstTerminais.SelectedItems.Item(0).SubItems(0).Text) & "'"
            ExecutaStr(strSql)
        Else
            strSql = "INSERT tblTerminaisPagtoDigital (Terminal, ClientID, ImpressoraPagtoDigital, PortaImpressora) VALUES ("
            strSql += to_sql(NuloString(lstTerminais.SelectedItems.Item(0).SubItems(0).Text)) & ","
            strSql += to_sql(NuloString(tbClientID_Shipay.Text)) & ","
            strSql += to_sql(NuloString(cbImpressora.Text)) & ","
            strSql += to_sql(NuloString(tbPorta.Text)) & ")"
            ExecutaStr(strSql)
        End If

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub LstTerminais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTerminais.SelectedIndexChanged
        If lstTerminais.SelectedItems.Count > 0 Then
            strSql = "SELECT Terminal, ClientID, ImpressoraPagtoDigital, Status, PortaImpressora FROM tblTerminaisPagtoDigital WHERE Terminal = '" & NuloString(lstTerminais.SelectedItems.Item(0).SubItems(0).Text) & "'"
            tbTerminal.Text = NuloString(lstTerminais.SelectedItems(0).SubItems(0).Text)
            tbClientID_Shipay.Text = NuloString(PegaValorCampo("ClientID", strSql, strCon))
            cbImpressora.Text = NuloString(PegaValorCampo("ImpressoraPagtoDigital", strSql, strCon))
            tbPorta.Text = NuloString(PegaValorCampo("PortaImpressora", strSql, strCon))
        End If
    End Sub
End Class