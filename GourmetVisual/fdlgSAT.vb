Imports System.Data.SqlClient
Imports CFeSatDataSetX
Imports CFeSatX

Public Class fdlgSAT
    Private Sub preencheSAT()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        'cbSat.Items.Clear()

        strSql = "SELECT IDSat, NumeroCaixa, Fabricante, Modelo, NumeroSerial FROM tblSAT ORDER BY NumeroCaixa"

        con.Open()

        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Depto As New ArrayList()

        With drLJS
            If .HasRows Then
                While (.Read())
                    Depto.Add(.Item("NumeroCaixa") & " - " & .Item("NumeroSerial") & " - " & .Item("Fabricante") & Space(100) & .Item("IDSat"))
                End While
            End If
            .Close()
        End With
        cbSat.DataSource = Depto
        comandoLJS.Dispose()
        con.Close()

    End Sub
    Private Sub fdlgSAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        preencheSAT()
    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Deseja realmente inserir um novo equipamento SAT"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        strSql = "INSERT tblSAT "
        strSql += "(CNPJSoftwareHouse) VALUES ("
        strSql += to_sql(CNPJSotwareHouse) & ")"
        ExecutaStr(strSql)
        preencheSAT()
        cbSat.Focus()
    End Sub

    Private Sub cbSat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSat.SelectedIndexChanged
        PreencheDados()
    End Sub

    Private Sub PreencheDados()
        Dim strSql As String
        strSql = "SELECT * FROM tblSAT WHERE IDSat=" & Val(Strings.Right(cbSat.Text, 8))

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        btnConsultaSAT.Enabled = False
        btnConsultaSATOper.Enabled = False
        If dr.HasRows Then
            dr.Read()
            tbFabricante.Text = NuloString(dr.Item("Fabricante"))
            tbModelo.Text = NuloString(dr.Item("Modelo"))
            tbNumeroSerial.Text = NuloString(dr.Item("NumeroSerial"))
            tbCNPJSoftwareHouse.Text = NuloString(dr.Item("CNPJSoftwareHouse"))
            tbCNPJCliente.Text = NuloString(dr.Item("CNPJCliente"))
            tbInscricaoEstadual.Text = NuloString(dr.Item("InscricaoEstadual"))
            tbInscricaoMunicipal.Text = NuloString(dr.Item("InscricaoMunicipal"))
            tbNumeroCaixa.Text = NuloString(dr.Item("NumeroCaixa"))
            tbCodigoAtivacao.Text = NuloString(dr.Item("CodigoAtivacao"))
            tbEnderecoDLL.Text = NuloString(dr.Item("EnderecoDLL"))
            tbNomeLogo.Text = NuloString(dr.Item("NomeLogo"))
            tbAssinatura.Text = NuloString(dr.Item("Assinatura"))
            tbVersao.Text = NuloString(dr.Item("Versao"))
            tbLocalSAT.Text = NuloString(dr.Item("LocalSAT"))
            btnConsultaSAT.Enabled = True
            btnConsultaSATOper.Enabled = True
            Panel.Visible = True
        Else
            tbFabricante.Text = ""
            tbModelo.Text = ""
            tbNumeroSerial.Text = ""
            tbCNPJSoftwareHouse.Text = ""
            tbCNPJCliente.Text = ""
            tbInscricaoEstadual.Text = ""
            tbInscricaoMunicipal.Text = ""
            tbNumeroCaixa.Text = ""
            tbCodigoAtivacao.Text = ""
            tbEnderecoDLL.Text = ""
            tbNomeLogo.Text = ""
            tbAssinatura.Text = ""
            tbVersao.Text = ""
            tbLocalSAT.Text = ""
            Panel.Visible = False
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()
        btnGravar.Enabled = False

    End Sub

    Private Sub tbFabricante_TextChanged(sender As Object, e As EventArgs) Handles tbFabricante.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbModelo_TextChanged(sender As Object, e As EventArgs) Handles tbModelo.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbNumeroSerial_TextChanged(sender As Object, e As EventArgs) Handles tbNumeroSerial.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbCNPJCliente_TextChanged(sender As Object, e As EventArgs) Handles tbCNPJCliente.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbInscricaoEstadual_TextChanged(sender As Object, e As EventArgs) Handles tbInscricaoEstadual.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbInscricaoMunicipal_TextChanged(sender As Object, e As EventArgs) Handles tbInscricaoMunicipal.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbNumeroCaixa_TextChanged(sender As Object, e As EventArgs) Handles tbNumeroCaixa.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbCodigoAtivacao_TextChanged(sender As Object, e As EventArgs) Handles tbCodigoAtivacao.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbEnderecoDLL_TextChanged(sender As Object, e As EventArgs) Handles tbEnderecoDLL.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbNomeLogo_TextChanged(sender As Object, e As EventArgs) Handles tbNomeLogo.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub tbAssinatura_TextChanged(sender As Object, e As EventArgs) Handles tbAssinatura.TextChanged
        btnGravar.Enabled = True
    End Sub


    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim teste = 0


        If NuloInteger(PegaValorCampo("qtde", "SELECT LocalSAT, IDSat FROM tblSAT WHERE=" & tbLocalSAT.Text, strCon)) <> 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Existe outro SAT cadastrado no mesmo local"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        strSql = "UPDATE tblSAT SET "
        strSql &= "CNPJSoftwareHouse='" & NuloString(tbCNPJSoftwareHouse.Text) & "',"
        strSql &= "CNPJCliente='" & NuloString(tbCNPJCliente.Text) & "',"
        strSql &= "InscricaoEstadual='" & NuloString(tbInscricaoEstadual.Text) & "',"
        strSql &= "InscricaoMunicipal='" & NuloString(tbInscricaoMunicipal.Text) & "',"
        strSql &= "NumeroCaixa='" & NuloString(tbNumeroCaixa.Text) & "',"
        strSql &= "CodigoAtivacao='" & NuloString(tbCodigoAtivacao.Text) & "',"
        strSql &= "EnderecoDLL='" & NuloString(tbEnderecoDLL.Text) & "',"
        strSql &= "NomeLogo='" & NuloString(tbNomeLogo.Text) & "',"
        strSql &= "Assinatura='" & NuloString(tbAssinatura.Text) & "',"
        strSql &= "Fabricante='" & UCase(NuloString(tbFabricante.Text)) & "',"
        strSql &= "Modelo='" & UCase(NuloString(tbModelo.Text)) & "',"
        strSql &= "Versao='" & UCase(NuloString(tbVersao.Text)) & "',"
        strSql &= "LocalSAT='" & UCase(NuloString(tbLocalSAT.Text)) & "',"
        strSql &= "NumeroSerial='" & NuloString(tbNumeroSerial.Text) & "' "
        strSql &= "WHERE (IDSat=" & Val(Strings.Right(cbSat.Text, 8)) & ")"
        ExecutaStr(strSql)

        Dim local As String = tbLocalSAT.Text
        If NuloString(local) <> "" Then
            local = "\" & tbLocalSAT.Text
        End If

        EscreveINI("CFESAT", "UF", "SP", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "CnpjSoftwareHouse", tbCNPJSoftwareHouse.Text, Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "CnpjContribuinte", tbCNPJCliente.Text, Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "CodigoAtivacao", tbCodigoAtivacao.Text, Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "NomeDLLSat", Application.StartupPath & local & "\" & tbEnderecoDLL.Text, Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "DiretorioEsquemas", Application.StartupPath & local & "\SAT\Esquemas\", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "DiretorioTemplates", Application.StartupPath & local & "\SAT\Templates\", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "DiretorioLog", Application.StartupPath & local & "\SAT\Log\", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "DiretorioCopiaSeguranca", Application.StartupPath & local & "\SAT\CopiaSeguranca\", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "ValidarEsquemaAntesEnvio", "0", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESAT", "NomeCertificado", "CN=PAULO SERGIO PEREIRA EPP:18928448000135, OU=Autenticado por AR Arruda, O=ICP-Brasil, C=BR, S=SP, L=SP, E=", Application.StartupPath & local & "\cfesatConfig.INI")

        EscreveINI("CFESATPRINT", "LogotipoEmitente", "", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESATPRINT", "LineDelimiter", "|", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESATPRINT", "QtdeCopias", "1", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESATPRINT", "ModeloImpressao", Application.StartupPath & local & "\SAT\Templates\Impressao\retrato.rtm", Application.StartupPath & local & "\cfesatConfig.INI")
        EscreveINI("CFESATPRINT", "ParamsAvancados", "", Application.StartupPath & local & "\cfesatConfig.INI")


        preencheSAT()
        btnGravar.Enabled = False

    End Sub
    Private Sub btnConsultaSAT_Click(sender As Object, e As EventArgs) Handles btnConsultaSAT.Click

        Try


            CarregaIni_SatCP()
            'spdSAT = New spdCFeSatX
            'spdSATDataSet = New spdCFeSatDataSetX

            tbmmRetorno.Text = spdSAT.ConsultarSAT(NumeroSessao())

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = tbmmRetorno.Text
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

        Catch ex As Exception
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = ex.Message
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

        End Try



    End Sub

    Private Sub tbVersao_TextChanged(sender As Object, e As EventArgs) Handles tbVersao.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Deseja realmente EXCLUIR este equipamento SAT"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        strSql = "Delete FROM tblSAT WHERE (IDSat=" & Val(Strings.Right(cbSat.Text, 8)) & ")"
        ExecutaStr(strSql)
        preencheSAT()

    End Sub

    Private Sub btnConsultaSATOper_Click(sender As Object, e As EventArgs) Handles btnConsultaSATOper.Click
        fdlgSAT_ConsultaStatus.ShowDialog()
    End Sub

    Private Sub tbCNPJSoftwareHouse_TextChanged(sender As Object, e As EventArgs) Handles tbCNPJSoftwareHouse.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub TbLocalSAT_TextChanged(sender As Object, e As EventArgs) Handles tbLocalSAT.TextChanged
        btnGravar.Enabled = True
    End Sub
End Class