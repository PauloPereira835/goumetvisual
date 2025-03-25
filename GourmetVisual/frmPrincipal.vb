Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Net.Mail
Imports System.IO.Compression
Imports Ionic.Zip
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ZipFile = System.IO.Compression.ZipFile

Public Class frmPrincipal
    Inherits System.Windows.Forms.Form
    Public MesaAberta As Boolean = False
    Private AtualizaVdas As Integer = 0
    Private TempoPrincipal As Integer = 0
    Dim IDVendaApp As Integer

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub PegaDadosVenda()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = "SELECT cod_pedido, qtdadePessoas, data_entrada, idGarcom, servico, Desconto FROM tb_Pedido WHERE(cod_pedido = " & IDPedido & ")"

        PercServico = 0
        PercDesconto = 0

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                While (dr.Read())
                    If dr.IsDBNull(4) Then
                        PercServico = 0
                    Else
                        PercServico = dr.GetDecimal(4)
                    End If
                    If dr.IsDBNull(5) Then
                        PercDesconto = 0
                    Else
                        PercDesconto = dr.GetDecimal(5)
                    End If

                    QtdPessoas = dr.GetInt32(1)

                End While
            End If


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub

    Private Sub ClickButton(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btn As PictureBox = sender

        If IDGarcon = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um operador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else
            IDPedido = btn.Tag
            NumMesa = btn.Text

            PedidoVenda = True
            PegaDadosVenda()

            frmSalao.ShowDialog()

            frmSalao.Enabled = True

            Me.Enabled = False

            frmSalao.tbMesa.Text = NumMesa
            frmSalao.lbOparedor.Text = Me.Garcon.Text

        End If

        Me.Focus()

    End Sub

    Private Sub VerificaMesa()
        MesaAberta = False

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        cmd.CommandText = "Select mesa, IDPedido From tb_Pocket_Pedido WHERE (mesa = " & NumMesa & ")"
        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                MesaAberta = True
                dr.Read()
                If dr.IsDBNull(1) Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Módulo Salão não aberto no caixa, não será possivel enviar pedido nesta mesa. Favor abrir o módulo Salão no caixa"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    IDPedido = 0
                Else
                    IDPedido = NuloInteger(dr(1))
                End If
            Else
                MesaAberta = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub

    Private Sub ConsultaMesa(Mesa As Integer)
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        cmd.CommandText = "Select NumMesa FROM tbLMesaS WHERE (NumMesa = " & Mesa & ")"

        Try
            con.Open()

            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                NumMesa = dr.GetValue(0)
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Mesa/Cartão não encontrado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                NumMesa = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub

    Private Sub ConsultaFunc()

        Operador = ""
        IDGarcon = 0
        IDOperador = 0
        OperadorEstorna = False
        OperadorTransfere = False
        Dim SenhaMaster As String = NuloDecimal(Now.Day * Now.Month * Now.Year * 7)

        If lbSenhaFuncionario.Text = lblSenha.Text Then
            Me.Garcon.Text = lbFuncionario.Text
            Operador = lbFuncionario.Text
            If lbIDFuncionario.Text <> "" Then
                IDGarcon = lbIDFuncionario.Text
                IDOperador = lbIDFuncionario.Text

                OperadorEstorna = False
                OperadorTransfere = False
                OperadorVisualizaVendas = False
                NivelFuncionario = 0

                Dim con As New SqlConnection()
                Dim dr As SqlDataReader
                con.ConnectionString = strCon
                Dim cmd As SqlCommand = con.CreateCommand

                cmd.CommandText = "SELECT IDFuncionario, EfetuaEstorno, EfetuaTransferencia, VisualizaMovto, Nivel FROM tblFuncionarios_Local WHERE (IDFuncionario = " & IDOperador & ")"
                con.Open()

                dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If dr.HasRows Then
                    dr.Read()
                    OperadorEstorna = NuloBoolean(dr.Item("EfetuaEstorno"))
                    OperadorTransfere = NuloBoolean(dr.Item("EfetuaTransferencia"))
                    OperadorVisualizaVendas = NuloBoolean(dr.Item("VisualizaMovto"))
                    NivelFuncionario = NuloInteger(dr.Item("Nivel"))
                End If
                dr.Close()
                cmd.Dispose()
                con.Close()
                con.Dispose()

            End If
        Else
            If lblSenha.Text <> SenhaMaster Then
                Me.Garcon.Text = ""
                IDGarcon = 0
                lblSenha.Text = ""
                Operador = ""
                IDOperador = 0
                Operador = ""

                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Senha inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            Else
                OperadorEstorna = True
                OperadorTransfere = True
                OperadorVisualizaVendas = True
                NivelFuncionario = 4
                IDGarcon = 0
                IDOperador = 0
                Operador = "OPERADOR MASTER"
                Me.Garcon.Text = "OPERADOR MASTER"

                btnConfig.Visible = True
            End If
        End If


    End Sub


    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmPagamento.carregaVisualComponente(Me, 20, 20)
        frmInicio.btnConfig.Visible = False

        lbEmpresa.Text = UCase(NomeEmpresa)
        lbLoja.Text = UCase(NomeLoja)
        btnConfirma.Enabled = False
        lbVersao.Text = frmInicio.lbVersao.Text

        MontaFuncionarios()

        frmPagamento.carregaVisualComponente(btnGerenciadorImpressao, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfirma, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfig, 10, 10)
        frmPagamento.carregaVisualComponente(btnSair, 10, 10)
        frmPagamento.carregaVisualComponente(Button11, 10, 10)
        frmPagamento.carregaVisualComponente(btnBalcao, 10, 10)
        frmPagamento.carregaVisualComponente(btnSalao, 10, 10)
        frmPagamento.carregaVisualComponente(btnDelivery, 10, 10)
        frmPagamento.carregaVisualComponente(btnSalao_Balcao, 10, 10)

        If NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "Versao", "")) = "" Then
            EscreveINI("Geral", "Versao", Versao, nome_arquivo_ini)
            EscreveINI("Geral", "MostraAtualizacoes", "1", nome_arquivo_ini)
        Else
            If NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "Versao", "")) <> Versao Then
                EscreveINI("Geral", "Versao", Versao, nome_arquivo_ini)
                EscreveINI("Geral", "MostraAtualizacoes", "1", nome_arquivo_ini)
            End If
        End If

        TimerData.Enabled = True
        TimerData.Start()
        lbDataHora.Text = Now.ToLongDateString

        If TerminalVenda = True Then
            Button11.Visible = False
            btnConfig.Visible = False
        End If
        If GerenciaImpressao = True Then
            btnGerenciadorImpressao.Visible = True
        Else
            btnGerenciadorImpressao.Visible = False
        End If

        If GerenciaSAT = True Then
            TimerSAT.Enabled = True
            TimerBackupCupomFiscal.Enabled = True
        Else
            TimerSAT.Enabled = False
            TimerBackupCupomFiscal.Enabled = False
        End If

        frmInicio.WindowState = FormWindowState.Maximized

        If TerminalExpedicao = True Then
            fdlgExpedicao.ShowDialog()
            btnMinimizar.Visible = False
        End If

        If EnviaEmailNFCE = True Then
            Email_NFCE()
        End If

    End Sub
    Public Sub Email_NFCE()
        Dim DiaAtual As Integer = Format(Now, "dd")

        If DiaAtual >= NuloInteger(DiaNFCE) Then
            Dim Mes As String
            Dim Ano As String
            Dim arquivoOrigem As String
            Dim arquivoDestino As String
            Dim UltimoMes As Integer = NuloInteger(LeArquivoINI(nome_arquivo_ini, "NFCE", "UltimoMes", 0))
            Dim MesAtual As Integer = NuloInteger(Format(Now, "MM")) - 1
            If MesAtual = 0 Then
                MesAtual = 12
            End If
            If UltimoMes <> MesAtual Then
                If MesAtual = 1 Then
                    Mes = "JANEIRO"
                Else
                    If MesAtual = 2 Then
                        Mes = "FEVEREIRO"
                    Else
                        If MesAtual = 3 Then
                            Mes = "MARÇO"
                        Else
                            If MesAtual = 4 Then
                                Mes = "ABRIL"
                            Else
                                If MesAtual = 5 Then
                                    Mes = "MAIO"
                                Else
                                    If MesAtual = 6 Then
                                        Mes = "JUNHO"
                                    Else
                                        If MesAtual = 7 Then
                                            Mes = "JULHO"
                                        Else
                                            If MesAtual = 8 Then
                                                Mes = "AGOSTO"
                                            Else
                                                If MesAtual = 9 Then
                                                    Mes = "SETEMBRO"
                                                Else
                                                    If MesAtual = 10 Then
                                                        Mes = "OUTUBRO"
                                                    Else
                                                        If MesAtual = 11 Then
                                                            Mes = "NOVEMBRO"
                                                        Else
                                                            Mes = "DEZEMBRO"
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                Ano = NuloInteger(Format(Now, "yyyy"))
                If MesAtual = 12 Then
                    Ano = NuloInteger(Format(Now, "yyyy")) - 1
                End If

                arquivoOrigem = Application.StartupPath & "\Movto\" & Mes & "-" & Ano
                arquivoDestino = Application.StartupPath & "\Movto\Arquivos Fiscais " & Mes & "-" & Ano & ".zip"

                compactaArquivo(arquivoOrigem, arquivoDestino)

                EnviaEmail(Mes, Ano, arquivoDestino)

                EscreveINI("NFCE", "UltimoMes", MesAtual, nome_arquivo_ini)

                ExcluirArquivo(arquivoDestino)

            End If

        End If
    End Sub
    Public Sub ExcluirArquivo(Arquivo As String)

        Try

            My.Computer.FileSystem.DeleteFile(Arquivo)

        Catch ex As Exception

        End Try

    End Sub
    Public Sub compactaArquivo(ByVal arquivoOrigem As String, ByVal Destino As String)

        Try

            ZipFile.CreateFromDirectory(arquivoOrigem, Destino)

        Catch ex As Exception

        End Try

    End Sub
    Public Sub EnviaEmail(Mes As String, Ano As String, ArqComp As String)

        Dim Origem As String
        Dim Senha As String
        Dim Porta As String
        Dim Smtp As String
        Dim Assunto As String
        Dim TextoEmail As String

        Origem = "gourmet@iristecnologia.com.br"
        Senha = "x79jr&"
        Porta = "587"
        Smtp = "smtp.iristecnologia.com.br"
        Assunto = "Arquivos fiscais " & NomeLoja & " - " & Mes & "/" & Ano


        Try

            Dim Smtp_Server As SmtpClient
            Dim e_mail As New MailMessage()

            Smtp_Server = New SmtpClient
            Smtp_Server.UseDefaultCredentials = False

            Smtp_Server.Credentials = New Net.NetworkCredential(NuloString(Origem), NuloString(Senha))
            Smtp_Server.Port = NuloString(Porta)
            Smtp_Server.EnableSsl = False
            Smtp_Server.Host = NuloString(Smtp)

            TextoEmail = "Arquivos fiscais referente a loja " & NomeLoja & vbCrLf
            TextoEmail += Mes & "/" & Ano

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(NuloString(Origem))
            e_mail.To.Add(NuloString(EmailNFCE))
            e_mail.Subject = NuloString(Assunto)
            e_mail.IsBodyHtml = False
            e_mail.Body = NuloString(TextoEmail)
            e_mail.Attachments.Add(New Attachment(ArqComp))

            Smtp_Server.Send(e_mail)
            System.Threading.Thread.Sleep(1000)

            Smtp_Server.Dispose()
            e_mail.Dispose()


        Catch ex As Exception
            MsgBox("ERRO (ENvido de email): " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Envio Email")
        End Try

    End Sub
    Public Sub MontaFuncionarios()

        Dim n As Integer = 0
        Dim strSql As String

        If TerminalVenda = False Then
            strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
            strSql += "From tblFuncionarios_Local "
            strSql += "Where (Senha<>'' AND Nivel>=2) "
            strSql += "Order By Funcionario"
        Else
            strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario, NaoMostraTerminalVenda "
            strSql += "From tblFuncionarios_Local "
            strSql += "WHERE (NaoMostraTerminalVenda = 0) And (Senha <> '') OR (NaoMostraTerminalVenda Is NULL) "
            strSql += "ORDER BY Funcionario"
        End If

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim myfont As New Font("Sans Serif", 9, FontStyle.Regular)
        Dim btnArray(42) As System.Windows.Forms.Label
        For i As Integer = 0 To 42
            btnArray(i) = New System.Windows.Forms.Label
        Next i

        Me.PanelFuncionarios.Controls.Clear()

        If dr.HasRows Then
            While (dr.Read())
                With (btnArray(n))
                    .Tag = NuloInteger(dr(0))
                    .Text = NuloString(dr(1))
                    .AccessibleDescription = NuloString(dr(3))
                    .ForeColor = Color.Blue
                    .TextAlign = ContentAlignment.MiddleCenter

                    .Width = 100
                    .Height = 60

                    .BackColor = Color.PeachPuff
                    .Font = myfont
                    .FlatStyle = FlatStyle.Standard
                    '.FlatAppearance.BorderColor = Color.Silver
                    .BackgroundImage = GourmetVisual.My.Resources.Resources.base
                    .BackgroundImageLayout = ImageLayout.Stretch

                    Me.PanelFuncionarios.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Funcionarios

                    n += 1
                End With
            End While
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        con.Close()
        con.Dispose()
        'PanelGrupos.Enabled = True
        'End Try
    End Sub
    Private Sub ClickButton_Funcionarios(ByVal sender As Object, ByVal e As System.EventArgs)

        With CType(sender, Label)

            btnConfirma.Enabled = False
            btnConfig.Visible = False
            btnSalao.Visible = False
            btnBalcao.Visible = False
            btnDelivery.Visible = False
            lbFuncionario.Text = String.Empty
            lbIDFuncionario.Text = String.Empty
            lbSenhaFuncionario.Text = String.Empty
            lblSenha.Text = String.Empty
            If .Text <> String.Empty Then
                lbFuncionario.Text = .Text
                lbIDFuncionario.Text = .Tag
                lbSenhaFuncionario.Text = .AccessibleDescription
            End If
            lblSenha.Focus()

        End With

    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CliqueNoBotao("1")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CliqueNoBotao("2")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CliqueNoBotao("3")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CliqueNoBotao("4")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CliqueNoBotao("5")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CliqueNoBotao("6")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CliqueNoBotao("9")
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If lbIDFuncionario.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Funcionário inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        ConsultaFunc()

        If Operador <> "" Then
            Dim MdSalao As Boolean = False
            Dim MdBalcao As Boolean = False
            Dim MdDelivery As Boolean = False

            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "FEZ LOGIN", "")
            End If

            If TerminalVenda = False Then
                btnConfig.Visible = True

                If InStr(ModulosIRIS, "S") > 0 Then
                    MdSalao = True
                End If
                If InStr(ModulosIRIS, "B") > 0 Then
                    MdBalcao = True
                End If

                If MdSalao = True And MdBalcao = True Then
                    btnSalao_Balcao.Visible = True
                    btnSalao_Balcao.Focus()
                Else
                    If MdSalao = True Then
                        btnSalao.Visible = True
                        btnSalao.Focus()
                    End If
                    If MdBalcao = True Then
                        btnBalcao.Visible = True
                        btnBalcao.Focus()
                    End If
                End If
                If InStr(ModulosIRIS, "D") > 0 Then
                    btnDelivery.Visible = True
                    MdDelivery = True
                End If
                If NuloBoolean(Clube) = True Then
                    btnSalao_Balcao.Visible = False
                    btnDelivery.Visible = False
                    btnBalcao.Visible = False
                    btnSalao.Visible = False
                    btnClube.Visible = True
                End If
            Else
                If NuloInteger(lblSenha.Text) <> (Now.Day * Now.Month * Now.Year) * 7 Then
                    strSql = "Select IDFechamento, Turno, Confirmado, IDFuncionario, DiaMovimento, Caixa From tblFechamentos_Local Where (Confirmado=0)"
                    IDFechamento = NuloInteger(PegaValorCampo("IDFechamento", strSql, strCon))
                    If IDFechamento = 0 Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Movimento não iniciado no caixa." & vbCrLf & "Não será possivel iniciar vendas"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        Exit Sub
                    Else
                        frmSalao.ShowDialog()
                    End If
                End If
            End If
        Else
            btnConfirma.Enabled = False
            btnConfig.Visible = False
            btnSalao.Visible = False
            btnBalcao.Visible = False
            btnDelivery.Visible = False
        End If
    End Sub
    Function VerificaCaixa()
        Dim AbreCx As Boolean = NuloBoolean(PegaValorCampo("AbreCaixa", "Select IDFuncionario, AbreCaixa From tblFuncionarios_Local Where (IDFuncionario = " & IDOperador & ")", strCon))
        Dim CaixaIniciado As Boolean = False

        If AbreCx = True Then
            If CaixaIndividualizado = True Then
                strSql = "Select IDFechamento, Turno, Confirmado, IDFuncionario, DiaMovimento, Caixa From tblFechamentos_Local Where (Confirmado=0) And (IDFuncionario = " & IDOperador & ")"
            Else
                strSql = "Select IDFechamento, Turno, Confirmado, IDFuncionario, DiaMovimento, Caixa From tblFechamentos_Local Where (Confirmado=0)"
            End If

            Dim con As New SqlConnection()
            Dim dr As SqlDataReader

            con.ConnectionString = strCon
            Dim cmd As SqlCommand = con.CreateCommand
            cmd.CommandText = strSql

            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                dr.Read()
                IDFechamento = dr.Item("IDFechamento")
                IDCaixa = dr.Item("IDFuncionario")
                Caixa = dr.Item("Caixa")
                DiaMovto = dr.Item("DiaMovimento") & "   (" & dr.Item("IDFechamento") & ")"
                tbDiaMovto.Text = dr.Item("DiaMovimento")

                CaixaIniciado = True
            Else
                CaixaIniciado = True
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Movimento não aberto para o operador " & Operador & ".  Deseja iniciar um movimento"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = True Then
                    fdlgAbreMovimento.ShowDialog()
                End If
            End If
        Else
            IDFechamento = 0
            IDCaixa = 0
            Caixa = ""
            CaixaIniciado = True
        End If

        Return CaixaIniciado

    End Function

    Private Sub btnArray(p1 As Integer)
        Throw New NotImplementedException
    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click


        If NuloInteger(NivelFuncionario) >= 4 Or Operador = "OPERADOR MASTER" Then
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "ACESSOU", "CONFIGURAÇÕES DO SISTEMA")
            End If

            frmConfiguracao.ShowDialog()
            frmInicio.IniciaForm()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Operador sem permissão"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        Form1.Show()

    End Sub

    Private Sub CliqueNoBotao(valor As String)
        If lbFuncionario.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um funcionário"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            Exit Sub
        End If
        lblSenha.Text &= valor
        btnConfirma.Enabled = True
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        If Len(lblSenha.Text) > 0 Then
            lblSenha.Text = Strings.Left(lblSenha.Text, Len(lblSenha.Text) - 1)
        End If
    End Sub

    Private Sub lstFunc_Click(sender As Object, e As EventArgs)
        lblSenha.Focus()
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click

        If TerminalVenda = True Then
            ConsultaFunc()
            If IDGarcon = 0 Then
                Exit Sub
            End If
        End If

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Deseja realmente finalizar o software Gourmet Visual"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()

        If GerenciaSAT = True Then
            BackupCupomFiscal()
        End If

        If RetornoMsg = True Then End

    End Sub

    Private Sub btnSalao_Click(sender As Object, e As EventArgs) Handles btnSalao.Click

        If VerificaCaixa() = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Movimento do dia não iniciado para este operador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        VerificaCaixa()
        Modulo = "S"
        frmSalao.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Operador = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Operador inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        frmCaixa.ShowDialog()
    End Sub

    Private Sub lblSenha_TextChanged(sender As Object, e As EventArgs) Handles lblSenha.TextChanged
        btnConfirma.Enabled = True
    End Sub

    Private Sub btnBalcao_Click(sender As Object, e As EventArgs) Handles btnBalcao.Click

        If VerificaCaixa() = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Movimento do dia não iniciado para este operador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        VerificaCaixa()
        Modulo = "B"
        frmSalao.ShowDialog()
    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        If VerificaCaixa() = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Movimento do dia não iniciado para este operador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        VerificaCaixa()
        frmDelivery.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        fdlgSobre.ShowDialog()

    End Sub

    Private Sub pbIRIS_Click(sender As Object, e As EventArgs) Handles pbIRIS.Click
        fdlgSobre.ShowDialog()
    End Sub

    Private Sub btnSalao_Balcao_Click(sender As Object, e As EventArgs) Handles btnSalao_Balcao.Click
        If VerificaCaixa() = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Movimento do dia não iniciado para este operador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        VerificaCaixa()
        Modulo = "S"
        frmSalao.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        lblSenha.Text = String.Empty
        btnConfirma.Enabled = False
    End Sub

    Private Sub TimerSAT_Tick(sender As Object, e As EventArgs) Handles TimerSAT.Tick

        Dim conTSat As New SqlConnection()
        Dim drTSat As SqlDataReader

        conTSat.ConnectionString = strCon
        Dim cmdTSat As SqlCommand = conTSat.CreateCommand

        strSql = "Select * "
        strSql += "From tblVendasSAT "
        strSql += "Where (Enviado = 1) And (Status = 'A') AND (IDSAT <> 0)"

        cmdTSat.CommandText = strSql
        conTSat.Open()
        drTSat = cmdTSat.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drTSat.HasRows Then

            drTSat.Read()

            If drTSat.Item("IDSat") = EquipamentoSAT Then

                TimerSAT.Stop()

                Dim DiaMovto As String = NuloString(drTSat.Item("DiaMovto"))
                If DiaMovto = "" Then DiaMovto = Now.ToString(FormatoDataLocal)

                If ModoFiscal = "SAT" Then
                    EfetuaVendaSAT(drTSat.Item("IDVendaSAT"), drTSat.Item("IDVenda"), drTSat.Item("CPF_CNPJ"), drTSat.Item("TotalAD"), drTSat.Item("TotalVenda"), drTSat.Item("ValorCupom"), drTSat.Item("TxEntrega"), drTSat.Item("StVenda"), DiaMovto, drTSat.Item("IDVenda"), drTSat.Item("IDSat"), drTSat.Item("IDVdaPagto"), "L")
                    System.Threading.Thread.Sleep(500)

                    If tbEdtUltIDAutorizado.Text <> "" Then
                        ' Gera arquivo XML /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Dim ArqImp As String
                        ArqImp = "AD" & Mid(tbEdtUltIDAutorizado.Text, 4, Len(tbEdtUltIDAutorizado.Text) - 3)
                        ArqImp = Application.StartupPath & "\Sat\CopiaSeguranca\" & ArqImp & ".xml"

                        ' Ler arquivo XML /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Dim fluxoTexto As IO.StreamReader
                        Dim linhaTexto As String
                        Dim ArquivoXML As String = ""
                        fluxoTexto = New IO.StreamReader(ArqImp)
                        linhaTexto = fluxoTexto.ReadLine
                        While linhaTexto <> Nothing
                            ArquivoXML &= linhaTexto & vbCrLf
                            linhaTexto = fluxoTexto.ReadLine
                        End While
                        fluxoTexto.Close()

                        ' Gera Arquivo  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Call CopiaXML(ArqImp, "V", ArqImp)

                        ' Grava no banco de dados /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        strSql = "UPDATE tblVendasSAT SET "
                        strSql &= "Status= 'E', "
                        strSql &= "XML='" & ArquivoXML & "', "
                        strSql &= "ValorCupom=" & Replace(drTSat.Item("ValorCupom"), ",", ".") & ", "
                        strSql &= "Num_SAT='" & tbEdtUltIDAutorizado.Text & "', "
                        strSql &= "NumSAT='" & Mid$(tbEdtUltIDAutorizado.Text, 26, 9) & "', "
                        strSql &= "Bkp=0,"
                        strSql &= "NumeroSessao='" & Numero_Sessao & "' "
                        strSql &= "WHERE (IDVendaSAT=" & drTSat.Item("IDVendaSAT") & ")"
                        ExecutaStr(strSql)

                    Else
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = tbmmRetorno.Text
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()

                        strSql = "UPDATE tblVendasSAT SET "
                        strSql &= "XML ='" & tbmmRetorno.Text & "', "
                        strSql &= "Status= 'ERRO' "
                        strSql &= "WHERE (IDVendaSAT=" & drTSat.Item("IDVendaSAT") & ")"
                        ExecutaStr(strSql)
                    End If
                Else




                End If

                TimerSAT.Start()
            End If
        End If
        cmdTSat.Dispose()
        drTSat.Close()
        conTSat.Dispose()
        conTSat.Close()

    End Sub

    Private Sub btnGerenciadorImpressao_Click(sender As Object, e As EventArgs) Handles btnGerenciadorImpressao.Click

        Try

            System.Diagnostics.Process.Start(Application.StartupPath & "\Gerenciador de Impressao.exe")

            FileOpen(1, Application.StartupPath & "\GI.gou", OpenMode.Output)
            PrintLine(1, 1)
            FileClose(1)

        Catch ex As Exception
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Gerenciador de Impressão não encontrado"
            frm.lbMensagem.ForeColor = Color.Blue
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End Try


    End Sub

    Private Sub TimerData_Tick(sender As Object, e As EventArgs) Handles TimerData.Tick
        lbDataHora.Text = Now.ToLongDateString & "  -  " & Now.ToLongTimeString


        ' Pedidos programados DELIVERY  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If NuloBoolean(GerenciaPedidoProgramado) = True Then frmDelivery.VerificaPedidosProgramados()


        ' Avisa pedidos aplicativos DELIVERY  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If VerificaPedidoAppFora = True Then
            If TempoPrincipal = 30 Or TempoPrincipal = 60 Then

                strSql = "SELECT IDVendaExterna FROM tblAppVendas WHERE (AppConfirmado=0) and (Excluido=0)"
                If NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon)) <> "" Then
                    ExistePedidoApp = True
                Else
                    ExistePedidoApp = False
                End If

                If ExistePedidoApp = True Then
                    If ToqueApp <> "" Then
                        My.Computer.Audio.Play(Application.StartupPath & "\" & ToqueApp & ".wav", AudioPlayMode.Background)
                    End If
                    If frmSalao.btnDelivery.BackColor = Color.DarkOrange Then
                        frmSalao.btnDelivery.BackColor = Color.PeachPuff
                    Else
                        frmSalao.btnDelivery.BackColor = Color.DarkOrange
                    End If
                Else
                    frmSalao.btnDelivery.BackColor = Color.White
                End If

            Else
                If ExistePedidoApp = True Then
                    If frmSalao.btnDelivery.BackColor = Color.DarkOrange Then
                        frmSalao.btnDelivery.BackColor = Color.PeachPuff
                    Else
                        frmSalao.btnDelivery.BackColor = Color.DarkOrange
                    End If
                    If TempoPrincipal = 15 Or TempoPrincipal = 45 Then
                        If ToqueApp <> "" Then
                            My.Computer.Audio.Play(Application.StartupPath & "\" & ToqueApp & ".wav", AudioPlayMode.Background)
                        End If
                    End If
                End If
            End If
        End If

        ' Envia pedidos aplicativos DELIVERY (automatico)  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If NuloBoolean(AceitaPedidoAutomaticoIfood) = True Then
            Dim Verificacao As String
            Dim AppUsado As String
            Dim IDvdaExterna As String

            strSql = "Select IDVendaExterna, NumVendaD, App, AppConfirmado, Excluido, IDReferencia, Status "
            strSql += "From tblAppVendas "
            strSql += "Where (AppConfirmado=0) and (Excluido=0)"

            Dim dapE = New SqlDataAdapter(strSql, strCon)
            dapE.SelectCommand.CommandType = CommandType.Text
            Dim dsE As New DataSet()
            dapE.Fill(dsE, "app")

            For i As Integer = 0 To dsE.Tables("app").Rows.Count - 1
                IDvdaExterna = NuloString(dsE.Tables("app").Rows(i).Item("IDVendaExterna"))

                If IDvdaExterna <> "" And NuloString(dsE.Tables("app").Rows(i).Item("Status")) <> "ERRO" Then
                    AppUsado = NuloString(dsE.Tables("app").Rows(i).Item("App"))

                    ' Verifica inconsistencia produtos  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendas.NumVenda, tblAppVendasMovto.IDAppVendaMovto, tblAppVendasMovto.CodigoProdutoExterno, tblAppVendasMovto.Produto, tblAppVendasMovto.Qtd, tblAppVendasMovto.Venda, tblAppVendasMovto.IDProduto "
                    strSql += "From tblAppVendas INNER Join tblAppVendasMovto On tblAppVendas.IDVendaExterna = tblAppVendasMovto.IDVendaExterna "
                    strSql += "Where (tblAppVendas.IDVendaExterna = '" & IDvdaExterna & "') AND (tblAppVendasMovto.IDProduto = '')"
                    Verificacao = NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon))
                    If Verificacao = "" Then
                        strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendasCombo.IDProduto "
                        strSql += "From tblAppVendas INNER Join tblAppVendasMovto On tblAppVendas.IDVendaExterna = tblAppVendasMovto.IDVendaExterna INNER Join tblAppVendasCombo On tblAppVendasMovto.IDAppVendaMovto = tblAppVendasCombo.IDAppVendaMovto "
                        strSql += "Where (tblAppVendas.IDVendaExterna = '" & IDvdaExterna & "') AND (tblAppVendasCombo.IDProduto = '')"
                        Verificacao = NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon))
                    End If

                    If Verificacao = "" Then
                        ' Verifica inconsistencia cliente  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendas.DataVenda, tblAppVendas.FlagFechada, tblAppVendas.HoraAbertura, tblAppVendas.StatusVenda, tblAppVendas.NomeCliente, tblAppVendas.CepEntrega, tblAppVendas.NumeroEntrega, tblAppVendas.ComplementoEntrega, tblAppVendas.ReferenciaEntrega, tblAppVendas.ComentProducao, tblAppVendas.ComentExpedicao, tblAppVendas.Troco, tblAppVendas.TaxaEntrega, tblAppVendas.Desconto, tblAppVendas.TotalProdutos, tblAppVendas.TotalVenda, tblAppVendas.Caixinha, tblAppVendas.PedidoProg, tblAppVendas.CpfCnpj, tblRuas.Logradouro, tblAppVendasPagto.Descricao, tblAppVendasPagto.ValorPago, tblRuas.Bairro, tblAppVendas.App, tblClientes.Tel1, tblClientes.DDD1, tblAppVendas.IDReferencia "
                        strSql += "From tblAppVendas INNER Join  tblRuas On tblAppVendas.IDRuaEntrega = tblRuas.IDRua INNER Join tblClientes On tblAppVendas.IDCliente = tblClientes.IDCliente INNER Join tblAppVendasPagto On tblAppVendas.IDVendaExterna = tblAppVendasPagto.IDVendaExterna "
                        strSql += "Where (tblAppVendas.IDVendaExterna = '" & IDvdaExterna & "')"
                        Verificacao = NuloString(PegaValorCampo("IDVendaExterna", strSql, strCon))
                        If Verificacao <> "" Then


                            IncluiVendaDeliveryApp(IDvdaExterna)


                            ' Marca tabela do app como confirmado  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            strSql = "UPDATE tblAppVendas SET "
                            strSql &= "NumVendaD=" & NumVendaD & ", "
                            strSql &= "Status='', "
                            strSql &= "AppConfirmado=1 "
                            strSql &= "WHERE (IDVendaExterna='" & IDvdaExterna & "')"
                            ExecutaStr(strSql)

                            ' Avisa para imprimir os pedidos  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            strSql = "UPDATE tblVendasMovto SET "
                            strSql &= "Imprime=1 "
                            strSql &= "WHERE (IDVenda=" & IDVendaApp & ")"
                            ExecutaStr(strSql)


                            ' Imprime expedição  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            frmDelivery.CriaExpedicao(IDVendaApp)
                            ' 1a Impressão   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpressoraExpedicao, Application.StartupPath & "\Impressao\conta.txt")
                            If GuilhotinaImpCaixa = True Then
                                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpressoraExpedicao, Chr(27) & Chr(109))
                            End If
                            If NuloInteger(QtdeImpressaoExpedicao) >= 2 Then
                                ' 2a Impressão   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpressoraExpedicao, Application.StartupPath & "\Impressao\conta.txt")
                                If GuilhotinaImpCaixa = True Then
                                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpressoraExpedicao, Chr(27) & Chr(109))
                                End If
                            End If
                            If NuloInteger(QtdeImpressaoExpedicao) = 3 Then
                                ' 3a Impressão   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpressoraExpedicao, Application.StartupPath & "\Impressao\conta.txt")
                                If GuilhotinaImpCaixa = True Then
                                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpressoraExpedicao, Chr(27) & Chr(109))
                                End If
                            End If

                            ' Altera status do aplicativo para confirmado  //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            System.Threading.Thread.Sleep(300)
                            MudarStatus(IDvdaExterna, "confirmation", "IFOOD")
                            MudarStatus(IDvdaExterna, "dispatch", "IFOOD")

                        Else
                            strSql = "UPDATE tblAppVendas SET Status='ERRO' WHERE IDVendaExterna = '" & IDvdaExterna & "'"
                            ExecutaStr(strSql)
                        End If
                    Else
                        strSql = "UPDATE tblAppVendas SET Status='ERRO' WHERE IDVendaExterna = '" & IDvdaExterna & "'"
                        ExecutaStr(strSql)
                    End If
                End If
            Next
        End If


        ' Monitora contas do tablet  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If TempoPrincipal = 15 Or TempoPrincipal = 30 Or TempoPrincipal = 45 Or TempoPrincipal = 60 Then
            MonitorContaTablet()
        End If


        TempoPrincipal += 1
        If TempoPrincipal > 60 Then TempoPrincipal = 0

    End Sub
    Private Sub IncluiVendaDeliveryApp(IDvdaExt As String)

        Dim PedidoProg As Boolean = False

        strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendas.IDCliente, tblAppVendas.DataVenda, tblAppVendas.FlagFechada, tblAppVendas.HoraAbertura, tblAppVendas.StatusVenda, tblAppVendas.NomeCliente, tblAppVendas.CepEntrega, tblAppVendas.NumeroEntrega, tblAppVendas.ComplementoEntrega, tblAppVendas.ReferenciaEntrega, tblAppVendas.ComentProducao, tblAppVendas.ComentExpedicao, tblAppVendas.Troco, tblAppVendas.TaxaEntrega, tblAppVendas.Desconto, tblAppVendas.TotalProdutos, tblAppVendas.TotalVenda, tblAppVendas.Caixinha, tblAppVendas.PedidoProg, tblAppVendas.CpfCnpj, tblRuas.Logradouro, tblAppVendasPagto.Descricao, tblAppVendasPagto.ValorPago, tblRuas.Bairro, tblAppVendas.App, tblClientes.Tel1, tblClientes.DDD1, tblAppVendas.IDReferencia, tblAppVendas.IDRuaEntrega, tblAppVendas.AreaEntrega, tblAppVendas.IDClienteExterno "
        strSql += "From tblAppVendas LEFT OUTER Join tblAppVendasPagto On tblAppVendas.IDVendaExterna = tblAppVendasPagto.IDVendaExterna LEFT OUTER Join tblClientes On tblAppVendas.IDCliente = tblClientes.IDCliente LEFT OUTER Join tblRuas On tblAppVendas.IDRuaEntrega = tblRuas.IDRua "
        strSql += "Where (tblAppVendas.IDVendaExterna = '" & IDvdaExt & "')"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        If ds.Tables("Vendas").Rows.Count > 0 Then

            strSql = "Select IDVenda, IDVendaExterna "
            strSql += "From tblVendas "
            strSql += "WHERE (IDVendaExterna = '" & IDvdaExt & "')"
            IDVendaApp = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))

            If IDVendaApp = 0 Then
                strSql = "Select tblAppVendas.IDVendaExterna, SUM(tblAppVendasMovto.Venda * tblAppVendasMovto.Qtd) As TotalProd, tblAppVendasMovto.Excluido, tblAppVendasPagto.ValorPago "
                strSql += "From tblAppVendasMovto INNER Join tblAppVendas On tblAppVendasMovto.IDVendaExterna = tblAppVendas.IDVendaExterna INNER Join tblAppVendasPagto On tblAppVendas.IDVendaExterna = tblAppVendasPagto.IDVendaExterna "
                strSql += "Group By tblAppVendas.IDVendaExterna, tblAppVendasMovto.Excluido, tblAppVendasPagto.ValorPago "
                strSql += "HAVING(tblAppVendas.IDVendaExterna = '" & IDvdaExt & "') AND (tblAppVendasMovto.Excluido = 0)"
                Dim TotProd As Decimal = NuloDecimal(PegaValorCampo("TotalProd", strSql, strCon))
                Dim TotVda As Decimal = NuloDecimal(PegaValorCampo("ValorPago", strSql, strCon))
                Dim VlrAcresDesc As Decimal = TotVda - TotProd

                AchaNumVenda("D")
                strSql = "INSERT tblVendas "
                strSql &= "(NumVenda, NumVendaD, NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Enviado, Excluido, IDFuncionarioAtendente, "
                strSql &= "IDCliente, NomeCliente, IDRuaEntrega, CepEntrega, NumeroEntrega, AreaEntrega, ComplementoEntrega, ReferenciaEntrega, ComentProducao, ComentExpedicao, Troco, TaxaEntrega, Desconto, TotalProdutos, TotalVenda, Caixinha, PreNota, "
                strSql &= "PedidoProg, PedidoProgAutomatico, PedidoProgEnvioAs, PedidoProgEnviado, TipoLancto, CpfCnpj, CepPagto, NumeroPagto, ComplementoPagto, EnderecoPagtoDiferente, RuaPagto, IDVendaExterna, App, IDReferencia, IDClienteExterno) VALUES ("
                strSql &= to_sql(NumVenda) & ","
                strSql &= to_sql(NumVendaD) & ","
                strSql &= to_sql(0) & ","
                strSql &= "'" & Date.Now & "',"
                strSql &= "0,"
                strSql &= "0,"
                strSql &= "1, "
                strSql &= "0,"
                strSql += "'" & Date.Now & "',"
                strSql &= "'D',"
                strSql &= to_sql(Caixa) & ","
                strSql &= to_sql(Operador) & ","
                strSql &= "0,"
                strSql &= "0,"
                strSql &= to_sql(IDOperador) & ","
                strSql &= to_sql(ds.Tables("Vendas").Rows(0).Item("IDCliente")) & ","
                strSql &= to_sql(ds.Tables("Vendas").Rows(0).Item("NomeCliente")) & ","
                strSql &= to_sql(ds.Tables("Vendas").Rows(0).Item("IDRuaEntrega")) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("CepEntrega"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("NumeroEntrega"))) & ","
                strSql &= to_sql(NuloInteger(ds.Tables("Vendas").Rows(0).Item("AreaEntrega"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("ReferenciaEntrega"))) & ","
                strSql &= to_sql(" ** " & ds.Tables("Vendas").Rows(0).Item("APP") & " ** " & NuloString(ds.Tables("Vendas").Rows(0).Item("IDReferencia"))) & ","
                strSql &= to_sql(" ** " & ds.Tables("Vendas").Rows(0).Item("APP") & " ** " & NuloString(ds.Tables("Vendas").Rows(0).Item("IDReferencia"))) & ","
                strSql &= "0,"
                If VlrAcresDesc >= 0 Then
                    strSql &= to_sql(Replace(NuloString(NuloDecimal(VlrAcresDesc)), ",", ".")) & ","
                    strSql &= "0,"
                Else
                    strSql &= "0,"
                    strSql &= to_sql(Replace(NuloString(NuloDecimal(VlrAcresDesc * -1)), ",", ".")) & ","
                End If
                strSql &= to_sql(Replace(NuloString(NuloDecimal(TotProd)), ",", ".")) & ","
                strSql &= to_sql(Replace(NuloString(NuloDecimal(TotVda)), ",", ".")) & ","
                strSql &= "0,"
                strSql &= "1, "
                If PedidoProg = False Then
                    strSql &= "0, 0, NULL, 0, "
                Else
                    strSql &= "1, 0, NULL, 0, "
                End If
                If NuloString(ds.Tables("Vendas").Rows(0).Item("CpfCnpj")) = "" Then
                    strSql &= "'False',"
                    strSql &= "'',"
                Else
                    strSql &= "'True',"
                    strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("CpfCnpj"))) & ","
                End If
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("CepEntrega"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("NumeroEntrega"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega"))) & ","
                strSql &= "'False',"
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("Logradouro"))) & ","
                strSql &= to_sql(NuloString(IDvdaExt)) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("APP"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("IDReferencia"))) & ","
                strSql &= to_sql(NuloString(ds.Tables("Vendas").Rows(0).Item("IDClienteExterno"))) & ")"
                ExecutaStr(strSql)
                IDVendaApp = PegaID("IDVenda", "tblVendas", "L")
            Else
                strSql = "DELETE tblVendasMovto WHERE IDVenda=" & IDVendaApp
                ExecutaStr(strSql)
                strSql = "DELETE tblVendasCombo WHERE IDVenda=" & IDVendaApp
                ExecutaStr(strSql)
            End If

            Dim IDvdaCombo As Integer
            Dim IDvdaMovtoApp As Integer
            Dim IDvdaMovto As Integer
            Dim Qtde As String
            Dim VlrUnit As String
            strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendas.NumVenda, tblAppVendasMovto.IDAppVendaMovto, tblAppVendasMovto.CodigoProdutoExterno, tblProdutos_Local.CodigoProduto, tblAppVendasMovto.Produto, tblAppVendasMovto.Qtd, tblAppVendasMovto.Venda, tblAppVendasCombo.IDAppVendaCombo, tblAppVendasCombo.Produto As ProdutoCombo, tblAppVendasCombo.Venda As VendaCombo, tblAppVendasCombo.CodigoProdutoExterno AS CodigoProdutoExternoCombo, tblAppVendasCombo.Qtd As QtdCombo, tblProdutos_Local_1.CodigoProduto As CodigoProdutoCombo, tblAppVendasCombo.IDProduto AS IDProdutoCombo, tblAppVendasCombo.CodigoProdutoExterno AS CodigoProdutoExternoCombo, tblAppVendasMovto.IDProduto, tblAppVendasMovto.Categoria, tblAppVendasMovto.IDGrupo, tblAppVendasMovto.Grupo, tblAppVendasCombo.IDGrupo AS IDGrupoCombo, tblAppVendasCombo.Grupo AS GrupoCombo, tblAppVendasCombo.Categoria AS CategoriaCombo "
            strSql += "From tblProdutos_Local As tblProdutos_Local_1 RIGHT OUTER Join tblAppVendasCombo On tblProdutos_Local_1.IDProduto = tblAppVendasCombo.IDProduto RIGHT OUTER Join tblAppVendas INNER Join tblAppVendasMovto On tblAppVendas.IDVendaExterna = tblAppVendasMovto.IDVendaExterna LEFT OUTER Join tblProdutos_Local On tblAppVendasMovto.IDProduto = tblProdutos_Local.IDProduto ON tblAppVendasCombo.IDAppVendaMovto = tblAppVendasMovto.IDAppVendaMovto "
            strSql += "Where (tblAppVendas.IDVendaExterna = '" & IDvdaExt & "')"

            Dim dapP = New SqlDataAdapter(strSql, strCon)
            dapP.SelectCommand.CommandType = CommandType.Text
            Dim dsP As New DataSet()
            dapP.Fill(dsP, "Prod")

            For i As Integer = 0 To dsP.Tables("Prod").Rows.Count - 1
                If NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDAppVendaCombo")) = 0 Then

                    'Imprime = NuloBoolean(PegaValorCampo("ImprimeCategoria", "SELECT IDProduto, ImprimeCategoria FROM tblProdutos_Local WHERE IDProduto=" & NuloInteger(dsP.Tables("Prod").Rows(0).Item("IDProduto")), strCon))
                    Imprime = True

                    InserirItemVenda(IDVendaApp, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDProduto")), NuloString(dsP.Tables("Prod").Rows(i).Item("Produto")), NuloDecimal(dsP.Tables("Prod").Rows(i).Item("Qtd")), True, NuloDecimal(dsP.Tables("Prod").Rows(i).Item("Venda")), NuloDecimal(dsP.Tables("Prod").Rows(i).Item("Venda")), NuloString(dsP.Tables("Prod").Rows(i).Item("Categoria")), Date.Now, IDOperador, Operador, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDGrupo")), NuloString(dsP.Tables("Prod").Rows(i).Item("Grupo")), False, "", False, "", NomeTerminal, Imprime, SetorDelivery, False, True)
                    IDvdaMovto = NuloInteger(PegaID("IDVendaMovto", "tblVendasMovto", "L"))

                    IncluiComentApp(IDVendaApp, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDAppVendaMovto")), 0, IDvdaMovto, 0)
                Else
                    Imprime = False
                    InserirItemVenda(IDVendaApp, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDProduto")), NuloString(dsP.Tables("Prod").Rows(i).Item("Produto")), NuloDecimal(dsP.Tables("Prod").Rows(i).Item("Qtd")), True, NuloDecimal(dsP.Tables("Prod").Rows(i).Item("Venda")), NuloDecimal(dsP.Tables("Prod").Rows(i).Item("Venda")), NuloString(dsP.Tables("Prod").Rows(i).Item("Categoria")), Date.Now, IDOperador, Operador, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDGrupo")), NuloString(dsP.Tables("Prod").Rows(i).Item("Grupo")), False, "", False, "", NomeTerminal, Imprime, SetorDelivery, False, True)
                    IDvdaMovto = NuloInteger(PegaID("IDVendaMovto", "tblVendasMovto", "L"))

                    IDvdaMovtoApp = NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDAppVendaMovto"))
                    While IDvdaMovtoApp = NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDAppVendaMovto"))

                        Qtde = NuloString(dsP.Tables("Prod").Rows(i).Item("QtdCombo"))
                        Qtde = Replace(Qtde, ",", ".")

                        VlrUnit = NuloString(dsP.Tables("Prod").Rows(i).Item("VendaCombo"))
                        VlrUnit = Replace(VlrUnit, ",", ".")

                        strSql = "INSERT tblVendasCombo (IDVendaMovto,IDVenda,IDProduto,Produto,Qtd,Venda,VendaServico,IDGrupo,Grupo,Categoria,AgregaValor) VALUES ("
                        strSql &= to_sql(IDvdaMovto) & ","
                        strSql &= to_sql(IDVendaApp) & ","
                        strSql &= to_sql(NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDProdutoCombo"))) & ","
                        strSql &= to_sql(NuloString(dsP.Tables("Prod").Rows(i).Item("ProdutoCombo"))) & ","
                        strSql &= to_sql(Qtde) & ","
                        strSql &= to_sql(VlrUnit) & ","
                        strSql &= to_sql(VlrUnit) & ","
                        strSql &= to_sql(NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDGrupoCombo"))) & ","
                        strSql &= to_sql(NuloString(dsP.Tables("Prod").Rows(i).Item("GrupoCombo"))) & ","
                        strSql &= to_sql(NuloString(dsP.Tables("Prod").Rows(i).Item("CategoriaCombo"))) & ","
                        strSql &= to_sql(False) & ")"
                        ExecutaStr(strSql)
                        IDvdaCombo = NuloInteger(PegaID("IDVendaCombo", "tblVendasCombo", "L"))

                        'IncluiComentApp(IDVendaApp, 0, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDAppVendaCombo")), 0, IDvdaCombo)
                        IncluiComentApp(IDVendaApp, NuloInteger(dsP.Tables("Prod").Rows(i).Item("IDAppVendaMovto")), 0, IDvdaMovto, 0)

                        If (i + 1) > dsP.Tables("Prod").Rows.Count - 1 Then Exit While
                        If IDvdaMovtoApp <> NuloInteger(dsP.Tables("Prod").Rows(i + 1).Item("IDAppVendaMovto")) Then Exit While
                        i += 1
                    End While
                End If
            Next

            strSql = "Select IDVendaExterna, IDFormaPagto, ValorPago, Descricao "
            strSql += "From tblAppVendasPagto "
            strSql += "WHERE (IDVendaExterna = '" & IDvdaExt & "')"
            Dim IDpagto As Integer = NuloInteger(PegaValorCampo("IDFormaPagto", strSql, strCon))
            Dim Desc As String = NuloString(PegaValorCampo("Descricao", strSql, strCon))
            Dim VlrPagto As Decimal = NuloDecimal(PegaValorCampo("ValorPago", strSql, strCon))
            Dim TpPagto As String = NuloString(PegaValorCampo("Tipo", strSql, strCon))
            Dim Ecart As Boolean = NuloBoolean(PegaValorCampo("ECartao", strSql, strCon))

            strSql = "INSERT tblVendasPagto (IDVenda, IDFormaPagto, Descricao, ValorPago, ECartao, TaxaCartao, Tipo, Cupom, IDPendencia, IDCliente) VALUES ("
            strSql &= to_sql(IDVendaApp) & ","
            strSql &= to_sql(IDpagto) & ","
            strSql &= to_sql(Desc) & ","
            strSql &= to_sql(Replace(NuloString(VlrPagto), ",", ".")) & ","
            strSql &= to_sql(Ecart) & ","
            strSql &= "0,"
            strSql &= to_sql(TpPagto) & ","
            strSql &= "0,0,0)"
            ExecutaStr(strSql)
        End If

    End Sub
    Private Sub IncluiComentApp(IDvda As Integer, IDmovtoApp As Integer, IDcomboApp As Integer, IDmovto As Integer, IDcombo As Integer)

        strSql = "Select IDVendaExterna, IDAppVendaMovto, IDAppVendaCombo, Coment, IDProdutoVinculado "
        strSql += "From tblAppVendasComent "
        If IDmovto <> 0 Then
            strSql += "Where (IDAppVendaMovto = " & IDmovtoApp & ")"
        Else
            strSql += "Where (IDAppVendaCombo = " & IDcomboApp & ")"
        End If

        Dim dapC = New SqlDataAdapter(strSql, strCon)
        dapC.SelectCommand.CommandType = CommandType.Text
        Dim dsC As New DataSet()
        dapC.Fill(dsC, "Coment")

        For i As Integer = 0 To dsC.Tables("Coment").Rows.Count - 1
            strSql = "INSERT tblVendasComent (IDVenda,IDVendaMovto,IDVendaCombo,Coment,IDProdutoVinculado) VALUES ("
            strSql &= to_sql(IDvda) & ","
            strSql &= to_sql(IDmovto) & ","
            strSql &= to_sql(IDcombo) & ","
            strSql &= to_sql(NuloString(dsC.Tables("Coment").Rows(i).Item("Coment"))) & ","
            strSql &= "0)"
            ExecutaStr(strSql)
        Next

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As frmAtualizacoes = New frmAtualizacoes
        frm.tbOrigem.Text = "SOBRE"
        'frm.lbCabec.Text = "Atualizações do software"
        frm.ShowDialog()
    End Sub

    Private Sub lblSenha_DoubleClick(sender As Object, e As EventArgs) Handles lblSenha.DoubleClick
        fdlgAcessoLivre.ShowDialog()

    End Sub

    Private Sub LbChat_Click(sender As Object, e As EventArgs) Handles lbChat.Click

    End Sub

    Private Sub lbChat_DoubleClick(sender As Object, e As EventArgs) Handles lbChat.DoubleClick
        fdlgChat.ShowDialog()
    End Sub

    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click

        frmInicio.Visible = False
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub TimerBackupCupomFiscal_Tick(sender As Object, e As EventArgs) Handles TimerBackupCupomFiscal.Tick

        ' BackupCupomFiscal()

    End Sub

    Private Sub BackupCupomFiscal()

        Dim IDVdaSAT As Integer
        strSql = "Select IDVendaSAT, IDVenda, Num_SAT, NumSAT, XML, IDSat, IDVdaPagto, Enviado, Status, Bkp "
        strSql += "From tblVendasSAT "
        strSql += "Where (Num_SAT Is Not NULL) And (Xml Is Not NULL) And (Bkp = 0)"

        Dim dapC = New SqlDataAdapter(strSql, strCon)
        dapC.SelectCommand.CommandType = CommandType.Text
        Dim dsC As New DataSet()
        dapC.Fill(dsC, "vda")

        Try

            For i As Integer = 0 To dsC.Tables("vda").Rows.Count - 1
                strSql = "INSERT tblBackupCupomFiscal (IDLoja, IDEquipamento, IDVenda, IDSat, Data, Num_SAT, NumSAT, XML) VALUES ("
                strSql += to_sql(IDLoja) & ","
                strSql += to_sql(EquipamentoIRIS) & ","
                strSql += to_sql(NuloInteger(dsC.Tables("vda").Rows(i).Item("IDVenda"))) & ","
                strSql += to_sql(NuloInteger(dsC.Tables("vda").Rows(i).Item("IDSat"))) & ","
                strSql += to_sqlDATA(Now, "datahora", "I") & ","
                strSql += to_sql(NuloString(dsC.Tables("vda").Rows(i).Item("Num_SAT"))) & ","
                strSql += to_sql(NuloString(dsC.Tables("vda").Rows(i).Item("NumSAT"))) & ","
                strSql += to_sql(NuloString(dsC.Tables("vda").Rows(i).Item("XML"))) & ")"
                ExecutaStrIRIS(strSql)

                IDVdaSAT = NuloInteger(dsC.Tables("vda").Rows(i).Item("IDVendaSAT"))
                strSql = "UPDATE tblVendasSAT SET "
                strSql += "Bkp = 1 "
                strSql += "Where (IDVendaSAT = " & IDVdaSAT & ")"
                ExecutaStr(strSql)
            Next

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnClube_Click(sender As Object, e As EventArgs) Handles btnClube.Click
        If VerificaCaixa() = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Movimento do dia não iniciado para este operador"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        VerificaCaixa()
        Modulo = "B"
        frmClube.ShowDialog()
    End Sub
End Class