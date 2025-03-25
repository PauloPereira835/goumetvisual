Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Threading
Imports ZXing.OneD

Public Class frmInicio
    Public Segundos As Integer = 0
    Public AtualizaTablet As Boolean = False
    Dim HabilitaHistorico As Boolean = False
    Public senhaINI As String
    Public EndBcoDadosRet As String
    Public DTSourceRET As String
    Public UsuarioRET As String
    Public senhaRET As String
    Public DTAtualizacaoDadosGeral_Local As String = ""
    Public DTAtualizacaoDadosGeral_IRIS As String = ""
    Public DTAtualizacaoDadosTerm_Local As String = ""
    Public DTAtualizacaoDadosTerm_IRIS As String = ""
    Public Sub IniciaForm()
        tbFoco.Focus()

        ' Acha numero HD (chave primária) e o numero da loja ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        TerminalExpedicao = NuloBoolean(LeArquivoINI(nome_arquivo_ini, "Geral", "TerminalExpedicao", 1))

        NumeroHD = NumeroSerial(Strings.Left(Application.StartupPath, 1))
        EscreveINI("Geral", "ChavePrimaria", NumeroHD, nome_arquivo_ini)
        Versao = lbVersao.Text

        If LeArquivoINI(nome_arquivo_ini, "Geral", "IDLoja", "") = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário informar o numero da loja no arquivo GV.ini na seção [Geral] (IDLoja=?)"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If

        If LeArquivoINI(nome_arquivo_ini, "IRIS", "Equipamento", "") = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário informar o numero do terminal no arquivo GV.ini na seção [IRIS] (Equipamento=?)"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If

        IDLoja = LeArquivoINI(nome_arquivo_ini, "Geral", "IDLoja", "")
        DTAtualizacaoDadosTerm_Local = LeArquivoINI(nome_arquivo_ini, "Geral", "DataAtualizacao", Now)

        ' Dados conexão Servidor IRIS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        EndBcoDadosIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "BancoDados", "0817081819040213141114060800"))
        DTSourceIRIS = "138.97.107.160"
        UsuarioIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "Usuario", "08170818c"))
        SenhaIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "Senha", "+15040317140200b"))
        EquipamentoIRIS = LeArquivoINI(nome_arquivo_ini, "IRIS", "Equipamento", 0)
        FormatoDataIRIS = LeArquivoINI(nome_arquivo_ini, "IRIS", "FormatoDataIRIS", "yyyy/MM/dd")

        strConIRIS = "Server=" & DTSourceIRIS & ";Database=" & EndBcoDadosIRIS & ";User id=" & UsuarioIRIS & ";Password =" & SenhaIRIS



        ' Verifica HD (Chave Primaria ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim conPri As New SqlConnection()
        strSql = "Select EquipamentoID, Descricao, HD, TerminalVenda, DataAtualizacao, chkHistoricoHabilitado "
        strSql += "From iris.tblEquipamentos "
        strSql += "Where (LojaID = " & IDLoja & ") And (HD = '" & NumeroHD & "') And (EquipamentoID = " & EquipamentoIRIS & ")"

        Try
            Dim drPri As SqlDataReader

            TerminalVenda = NuloBoolean(LeArquivoINI(nome_arquivo_ini, "Geral", "TerminalVenda", 0))
            TerminalExpedicao = NuloBoolean(LeArquivoINI(nome_arquivo_ini, "Geral", "TerminalExpedicao", 0))

            conPri.ConnectionString = strConIRIS
            Dim cmdPri As SqlCommand = conPri.CreateCommand
            cmdPri.CommandText = strSql
            conPri.Open()
            drPri = cmdPri.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If Not drPri.HasRows Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Equipamento/Terminal não cadastrado." & vbCrLf & "Verifique a chave primária." & vbCrLf & NumeroHD & vbCrLf & "O sistema será abortado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                End
            Else
                drPri.Read()
                TerminalVenda = NuloBoolean(drPri.Item("TerminalVenda"))
                HabilitaHistorico = NuloBoolean(drPri.Item("chkHistoricoHabilitado"))
                DTAtualizacaoDadosTerm_IRIS = NuloString(drPri.Item("DataAtualizacao"))
                If DTAtualizacaoDadosTerm_Local = "" And DTAtualizacaoDadosTerm_IRIS <> "" Then
                    DTAtualizacaoDadosTerm_Local = DateAdd(DateInterval.Minute, -1, CType(DTAtualizacaoDadosTerm_IRIS, DateTime))
                Else
                    If DTAtualizacaoDadosTerm_IRIS = "" And DTAtualizacaoDadosTerm_Local <> "" Then
                        DTAtualizacaoDadosTerm_IRIS = DateAdd(DateInterval.Minute, -1, CType(DTAtualizacaoDadosTerm_Local, DateTime))
                    End If
                End If
            End If

            If TerminalVenda = False Then
                EscreveINI("Geral", "TerminalVenda", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "TerminalVenda", "1", nome_arquivo_ini)
            End If
            cmdPri.Dispose()
            drPri.Close()


        Catch ex As Exception
            DTAtualizacaoDadosTerm_IRIS = DateAdd(DateInterval.Minute, -1, CType(DTAtualizacaoDadosTerm_Local, DateTime))
            'MsgBox(ex.Message)

        Finally
            conPri.Dispose()
            conPri.Close()
        End Try


        ' // Testa conexão com IRIS    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ' Verifica dias de uso ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DiasUso = MontaSenha(LeArquivoINI(nome_arquivo_ini, "Geral", "DU", "jjj"))
        If DiasUso = 999 Then
            EscreveINI("Geral", "DU", DesmontaSenha(15), nome_arquivo_ini)
        End If
        If DiasUso <= 0 Then
            fdlgLiberaSistema.ShowDialog()
            DiasUso = MontaSenha(LeArquivoINI(nome_arquivo_ini, "Geral", "DU", "jjj")) + 1
        End If


        Dim conIRIS As New SqlConnection(strConIRIS)

        strSql = "Select tblRepresentantes.Representante, tblRepresentantes.NomeFantasia, tblRepresentantes.Telefone, tblRepresentantes.Contato, tblRepresentantes.Email, iris.tblLojasGV.LojaID, iris.tblLojasGV.Cidade, iris.tblLojasGV.Estado, iris.tblClientesGV.Cliente, iris.tblLojasGV.Loja, iris.tblLojasGV.DataAtualizacao, iris.tblLojasGV.Endereco, iris.tblLojasGV.Numero, iris.tblLojasGV.Bairro, iris.tblLojasGV.CEP, iris.tblLojasGV.Telefone1, iris.tblLojasGV.DDD, iris.tblLojasGV.Clube "
        strSql += "From iris.tblLojasGV INNER Join iris.tblClientesGV ON iris.tblLojasGV.ClienteID = iris.tblClientesGV.ClienteID LEFT OUTER Join tblRepresentantes On iris.tblLojasGV.IDRepresentante = tblRepresentantes.IDRepresentante "
        strSql += "WHERE (iris.tblLojasGV.LojaID=" & IDLoja & ")"

        conexaIRIS = True
        Try
            conIRIS.Open()
            Dim cmdIRIS As New SqlCommand(strSql, conIRIS)
            cmdIRIS.CommandType = CommandType.Text

            DTAtualizacaoDadosGeral_IRIS = ""
            CidadeLoja = ""
            EstadoLoja = ""
            DDD_Padrao = ""
            CEPLoja = ""
            EnderecoLoja = ""
            BairroLoja = ""
            TelefoneLoja = ""
            NomeLoja = LeArquivoINI(nome_arquivo_ini, "Geral", "NomeLoja", "")
            NomeEmpresa = "SEM CONEXÃO"
            Clube = ""
            Dim drIRIS As SqlDataReader = cmdIRIS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drIRIS.HasRows Then
                drIRIS.Read()
                EscreveINI("Geral", "DU", DesmontaSenha(15), nome_arquivo_ini)
                EscreveINI("Representante", "Nome", NuloString(drIRIS.Item("Representante")), nome_arquivo_ini)
                EscreveINI("Representante", "NomeFantasia", NuloString(drIRIS.Item("NomeFantasia")), nome_arquivo_ini)
                EscreveINI("Representante", "Telefone", NuloString(drIRIS.Item("Telefone")), nome_arquivo_ini)
                EscreveINI("Representante", "Contato", NuloString(drIRIS.Item("Contato")), nome_arquivo_ini)
                EscreveINI("Representante", "Email", NuloString(drIRIS.Item("Email")), nome_arquivo_ini)
                CidadeLoja = NuloString(drIRIS.Item("Cidade"))
                EstadoLoja = NuloString(drIRIS.Item("Estado"))
                NomeLoja = NuloString(drIRIS.Item("Loja"))
                NomeEmpresa = NuloString(drIRIS.Item("Cliente"))
                CEPLoja = Replace(NuloString(drIRIS.Item("CEP")), "-", "")
                DDD_Padrao = NuloString(drIRIS.Item("DDD"))
                EnderecoLoja = NuloString(drIRIS.Item("Endereco")) & " " & NuloString(drIRIS.Item("Numero"))
                BairroLoja = NuloString(drIRIS.Item("Bairro"))
                TelefoneLoja = NuloString(drIRIS.Item("Telefone1"))
                DTAtualizacaoDadosGeral_IRIS = NuloString(drIRIS.Item("DataAtualizacao"))
                Clube = NuloBoolean(drIRIS.Item("Clube"))
                EscreveINI("Geral", "Clube", Clube, nome_arquivo_ini)
            End If
            cmdIRIS.Dispose()
            drIRIS.Close()

        Catch ex As Exception
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Sem conexão com IRIS Tecnologia. Verifique sua conexão com a internet. O sistema continuara com limite de acessos"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            EscreveINI("Geral", "DU", DesmontaSenha(DiasUso - 1), nome_arquivo_ini)
            conexaIRIS = False



        End Try
        conIRIS.Dispose()
        conIRIS.Close()

        If NomeLoja = "" Then
            EscreveINI("Geral", "NomeLoja", "SEM CONEXÃO", nome_arquivo_ini)
            NomeLoja = "SEM CONEXÃO"
        End If



        ' Parametros Representante /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        NomeRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Nome", "")
        NomeFanRep = LeArquivoINI(nome_arquivo_ini, "Representante", "NomeFantasia", "")
        TelefoneRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Telefone", "")
        ContatoRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Contato", "")
        EmailRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Email", "")

        ' Verifica dados config local /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ' Dados conexão Gourmet Visual /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        'If DateDiff(DateInterval.Second, CType(DTAtualizacaoDadosTerm_Local, DateTime), CType(DTAtualizacaoDadosTerm_IRIS, DateTime)) > 0 Then
        'AtualizacaoDadosTerminal("L") ' Atualiza o terminal LOCAL  ////////////////////////////////////
        'Else
        EndBcoDados = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados", "")
        DTSource = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source", "")
        Usuario = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario", "")
        senhaINI = LeArquivoINI(nome_arquivo_ini, "Geral", "Senha", "")
        FormatoDataLocal = NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "FormatoDataLocal", "dd/MM/yyyy"))
        MontaSenha(senhaINI)
        strCon = "Server=" & DTSource & ";Database=" & EndBcoDados & ";User id=" & Usuario & ";Password =" & SenhaCon

        ' Dados conexão IRIS Gestão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        EndBcoDadosRet = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados_server", "")
        DTSourceRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source_server", "")
        UsuarioRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario_server", "")
        senhaRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Senha_server", "")
        FormatoDataRET = NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "FormatoDataRET", "dd/MM/yyyy"))
        MontaSenha(senhaRET)
        strConServer = "Server=" & DTSourceRET & ";Database=" & EndBcoDadosRet & ";User id=" & UsuarioRET & ";Password =" & SenhaCon

        GerenciaImpressao = LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaImpressao", "0")
        GerenciaTable = LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaTablet", "0")
        TableAtivo = LeArquivoINI(nome_arquivo_ini, "Geral", "TabletAtivo", "0")
        ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
        ImpressoraExpedicao = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraExpedicao", "")
        ImpressoraCaixaTexto = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixaTexto", "0")
        GuilhotinaImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "GuilhotinaImpressoraCaixa", "0")
        Imprime = LeArquivoINI(nome_arquivo_ini, "Geral", "Imprime", "0")
        GavetaCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "GavetaEletronica", "0")
        PortaBalanca = UCase(LeArquivoINI(nome_arquivo_ini, "Geral", "PortaBalanca", ""))
        AtualizaVendas = UCase(LeArquivoINI(nome_arquivo_ini, "Geral", "AtualizaVendas", 0))
        RegistraLog = UCase(LeArquivoINI(nome_arquivo_ini, "Geral", "RegistraLog", 0))
        If LeArquivoINI(nome_arquivo_ini, "Geral", "FixaAbreMesaCartao", 0) = False Then
            FixaAbreMesaCartao = False
        Else
            FixaAbreMesaCartao = True
        End If
        NomeTerminal = NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "NomeTerminal", ""))
        ImprimeExpandido = NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "ImprimeExpandido", 0))
        If NuloString(Clube) = "" Then
            Clube = LeArquivoINI(nome_arquivo_ini, "Geral", "Clube", "False")
        Else
            EscreveINI("Geral", "Clube", Clube, nome_arquivo_ini)
        End If
        CameloTambore = NuloBoolean(LeArquivoINI(nome_arquivo_ini, "Geral", "CameloTambore", 0))

        ' Salão ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ImpConta = LeArquivoINI(nome_arquivo_ini, "Salao", "ImpressoraConta", "")
        ImprimeConsumo = LeArquivoINI(nome_arquivo_ini, "Salao", "ImprimeConsumo", 0)
        ReimprimeComanda = LeArquivoINI(nome_arquivo_ini, "Salao", "ReimprimeComanda", False)

        ' Delivery ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        GerenciaPedidoProgramado = LeArquivoINI(nome_arquivo_ini, "Delivery", "GerenciaPedidoProgramado", 0)
        ExpedicaoPadrao = LeArquivoINI(nome_arquivo_ini, "Delivery", "ExpedicaoPadrao", 0)
        FechamentoDeliveryCamelo = LeArquivoINI(nome_arquivo_ini, "Delivery", "FechamentoDeliveryCamelo", 0)

        ' SAT ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        EquipamentoSAT = LeArquivoINI(nome_arquivo_ini, "SAT", "EquipamentoSAT", "0")
        GerenciaSAT = LeArquivoINI(nome_arquivo_ini, "SAT", "GerenciaSAT", "0")

        ' Terminal Venda ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        PedeMesa = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "PedeMesa", "0")
        FixaTelaPedidos = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "FixaTelaPedidos", "0")
        TempoLimite = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "TempoLimite", 0)
        TerminalNaoCobraServico = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "NaoCobraServico", 0)

        ' QRbox ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        GerenciaPedidosQRbox = LeArquivoINI(nome_arquivo_ini, "QRBOX", "GerenciaPedidosQRbox", "0")
        IntegracaoQRbox = NuloInteger(LeArquivoINI(nome_arquivo_ini, "QRBOX", "IntegracaoQRbox", 0))

        ' Ifood ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        GerenciaPedidosIfood = LeArquivoINI(nome_arquivo_ini, "IFOOD", "GerenciaPedidos", "0")
        IntegracaoIfood = NuloInteger(LeArquivoINI(nome_arquivo_ini, "IFOOD", "IntegracaoIfood", 0))

        ' Rappi ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        GerenciaPedidosRappi = LeArquivoINI(nome_arquivo_ini, "RAPPI", "GerenciaPedidos", "0")
        IntegracaoRappi = NuloInteger(LeArquivoINI(nome_arquivo_ini, "RAPPI", "IntegracaoRappi", 0))

        ' NFCE //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        CertificadoNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "NomeCertificado", ""))
        EstadoNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "UF", ""))
        CnpjNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "CNPJ", ""))

        NomeNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Nome", ""))
        FantasiaNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Fantasia", ""))
        EnderecoNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Endereco", ""))
        NumeroNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Numero", ""))
        ComplementoNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Complemento", ""))
        CepNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "CEP", ""))
        BairroNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Bairro", ""))
        MunicipioNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Cidade", ""))
        NumeroMunicipioNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "NumeroMunicipio", ""))
        PaisNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Pais", ""))
        NumeroPaisNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "NumeroPais", ""))
        InscricaoEstadualNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "InscricaoEstadual", ""))
        VersaoNFCE = NuloString(LeArquivoINI(nome_arquivo_ini_NFCE, "NFCE", "Versao", ""))



        EnviaEmailNFCE = NuloBoolean(LeArquivoINI(nome_arquivo_ini, "NFCE", "EnviaEmailNFCE", 0))
        EmailNFCE = NuloString(LeArquivoINI(nome_arquivo_ini, "NFce", "EmailNFCE", ""))
        DiaNFCE = NuloString(LeArquivoINI(nome_arquivo_ini, "NFce", "DiaNFCE", ""))

        If FormatoDataLocal = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Formato da data local inválido. O sistema será abortado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If
        If FormatoDataRET = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Formato da data retaguarda inválido. O sistema será abortado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If


        ' // Testa conexão com banco de dados local    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim conTe As New SqlConnection()
        strSql = "Select * From tblConfig"

        Dim drTe As SqlDataReader
        conTe.ConnectionString = strCon
        Dim cmdTe As SqlCommand = conTe.CreateCommand
        cmdTe.CommandText = strSql

        Try
            conTe.Open()
            drTe = cmdTe.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            drTe.Read()
            '' Parametros Geral /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MostraComentExpedicao = NuloBoolean(drTe.Item("MostraComentExpedicao"))
            ImpEstorno = NuloBoolean(drTe.Item("ImprimeEstorno"))
            ImpTransferencia = NuloBoolean(drTe.Item("ImprimeTransferencia"))
            ImpRecibo = NuloBoolean(drTe.Item("ImprimeRecibo"))
            ModoFiscal = NuloString(drTe.Item("ModoFiscal"))
            CaixaIndividualizado = NuloBoolean(drTe.Item("CaixaIndividualizado"))
            NaoEncerraVendasAberto = NuloBoolean(drTe.Item("NaoEncerraVendasAberto"))
            EnviaEmailFechamento = NuloBoolean(drTe.Item("EnviaEmailFechamento"))
            TodosRelatorios = NuloBoolean(drTe.Item("TodosRelatorios"))
            IncluiFundoCaixa = NuloBoolean(drTe.Item("IncluiFundoCaixa"))
            RegistraLog = NuloBoolean(drTe.Item("RegistraLog"))
            RelatFechamento = NuloString(drTe.Item("RelatFechamento"))
            MediaQtdeVdas = NuloString(drTe.Item("MediaQtdeVdas"))

            ' Parametros Salão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            PercServicoPAR = NuloDecimal(drTe.Item("PercServico"))
            TempoLimitePedidosMesa = NuloInteger(drTe.Item("TempoLimite"))
            TempoLimitePedidosMesaEmEspera = NuloInteger(drTe.Item("TempoLimiteEmEspera"))
            TextoServico = NuloString(drTe.Item("TextoServico"))
            TextoServicoCupom = NuloString(drTe.Item("TextoServicoCupom"))
            ObrigaConta = NuloBoolean(drTe.Item("ObrigaConta"))
            FatorAjusteServico = NuloDecimal(drTe.Item("FatorAjusteServico"))
            TextoMesaPAR = NuloString(drTe.Item("TextoSalao"))
            If UCase(TextoMesaPAR) = "MESA" Then
                TextoMsg = "uma MESA"
            Else
                If UCase(TextoMesaPAR) = "CARTÃO" Then
                    TextoMsg = "um CARTÃO"
                Else
                    TextoMsg = ""
                End If
            End If
            Acrescimo_W21 = NuloBoolean(drTe.Item("Acrescimo_W21"))
            NaoMostraProdutosZeroConta = NuloBoolean(drTe.Item("NaoMostraProdutosZeroConta"))
            TocaCampainhaApp = NuloBoolean(drTe.Item("TocaCampainhaApp"))

            ' Parametros Balcão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SetorBalcao = NuloInteger(drTe.Item("SetorBalcao"))
            InformaClienteBalcao = NuloBoolean(drTe.Item("InformaClienteBalcao"))
            ImprimeConferenciaBalcao = NuloBoolean(drTe.Item("ImprimeConferenciaBalcao"))
            QtdePessoasBalcao = NuloBoolean(drTe.Item("QtdePessoasBalcao"))

            ' Parametros Delivery /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SetorDelivery = NuloInteger(drTe.Item("SetorDelivery"))
            QtdeImpressaoExpedicao = NuloInteger(drTe.Item("QtdeImpressaoExpedicao"))
            CategoriaPropriaDelivery = NuloString(drTe.Item("CategoriaPropriaDelivery"))
            ToqueApp = NuloString(drTe.Item("ToqueApp"))
            If NuloString(drTe.Item("ToqueApp")) = "" Then
                ToqueApp = ""
            Else
                If NuloString(drTe.Item("ToqueApp")) = "Som padão" Then
                    ToqueApp = "toque"
                Else
                    If NuloString(drTe.Item("ToqueApp")) = "Som 01" Then
                        ToqueApp = "toque01"
                    Else
                        If ToqueApp = "Som 02" Then
                            ToqueApp = "toque02"
                        Else
                            If NuloString(drTe.Item("ToqueApp")) = "Som 03" Then
                                ToqueApp = "toque03"
                            Else
                                If NuloString(drTe.Item("ToqueApp")) = "Som 04" Then
                                    ToqueApp = "toque04"
                                Else
                                    If NuloString(drTe.Item("ToqueApp")) = "Som 05" Then
                                        ToqueApp = "toque05"
                                    Else
                                        If NuloString(drTe.Item("ToqueApp")) = "Som 06" Then
                                            ToqueApp = "toque06"
                                        Else
                                            If NuloString(drTe.Item("ToqueApp")) = "Som 07" Then
                                                ToqueApp = "toque07"
                                            Else
                                                If NuloString(drTe.Item("ToqueApp")) = "Som 08" Then
                                                    ToqueApp = "toque08"
                                                Else
                                                    If NuloString(drTe.Item("ToqueApp")) = "Som 09" Then
                                                        ToqueApp = "toque09"
                                                    Else
                                                        ToqueApp = "toque10"
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

            ' Terminal Venda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            BloqueaMesaAposConta = NuloBoolean(drTe.Item("BloqueaMesaAposConta"))

            ' Parametros SAT /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CNPJSotwareHouse = NuloString(drTe.Item("CNPJSoftwareHouse"))
            NCM_Servico = NuloString(drTe.Item("NCM_Servico"))
            CSTPis_Servico = NuloString(drTe.Item("CSTPis_Servico"))
            CSTCofins_Servico = NuloString(drTe.Item("CSTCofins_Servico"))
            CFOP_Servico = NuloString(drTe.Item("CFOP_Servico"))
            CSTIcms_Servico = NuloString(drTe.Item("CSTIcms_Servico"))
            Aliquota_Servico = NuloDecimal(drTe.Item("Aliquota_Servico"))
            DTAtualizacaoDadosGeral_Local = NuloString(drTe.Item("DataAtualizacao"))




            ' IFood /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UsernameIfood = NuloString(drTe.Item("UsernameIfood"))
            PasswordIfood = NuloString(drTe.Item("PasswordIfood"))
            IDmerchantIfood = NuloString(drTe.Item("IDmerchantIfood"))
            AceitaPedidoAutomaticoIfood = NuloBoolean(drTe.Item("AceitaPedidoAutomaticoIfood"))
            IDFormaPagtoDefaultIfood = NuloInteger(drTe.Item("IDFormaPagtoDefaultIfood"))




            ' PosControle /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UserName_PosControle = NuloString(drTe.Item("Username_PosControle"))
            Senha_PosControle = NuloString(drTe.Item("Senha_PosControle"))
            Pos_Controle = NuloBoolean(drTe.Item("PosControle"))

            ' Rappi /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Client_ID_Rappi = NuloString(drTe.Item("Client_ID_Rappi"))
            Grant_Type_Rappi = NuloString(drTe.Item("Grant_Type_Rappi"))
            Audience_Rappi = NuloString(drTe.Item("Audience_Rappi"))
            IDLoja_Rappi = NuloString(drTe.Item("IDLoja_Rappi"))
            Client_Secret_Rappi = NuloString(drTe.Item("Client_Secret_Rappi"))
            IDFormaPagtoRappi = NuloInteger(drTe.Item("IDFormaPagtoDefaultRappi"))
            IDClienteDefaultRappi = NuloInteger(drTe.Item("IDClienteDefaultRappi"))


            ' ShiPay /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            AccessKey_Shipay = NuloString(drTe.Item("AccessKey_Shipay"))
            SecretKey_Shipay = NuloString(drTe.Item("SecretKey_Shipay"))
            VerificaPagtosDigitais = False

            drTe.Close()


        Catch ex As Exception

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = ex.Message
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End

        End Try

        cmdTe.Dispose()
        conTe.Dispose()
        conTe.Close()

        If conexaIRIS = True Then
            strSql = "Delete From tblTerminais"
            ExecutaStr(strSql)

            strSql = "Delete From tblLojas_Local"
            ExecutaStr(strSql)


            Dim con As New SqlConnection()
            strSql = "Select EquipamentoID, Descricao, HD "
            strSql += "From iris.tblEquipamentos "
            strSql += "Where (LojaID = " & IDLoja & ")"

            ' Cadastra terminais  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Dim dr As SqlDataReader
            con.ConnectionString = strConIRIS
            Dim cmd As SqlCommand = con.CreateCommand
            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While dr.Read()
                    strSql = "INSERT tblTerminais "
                    strSql += "(IDTerminal, Terminal) VALUES ("
                    strSql += to_sql(dr.Item("EquipamentoID")) & ","
                    strSql += to_sql(dr.Item("Descricao")) & ")"
                    ExecutaStr(strSql)

                End While
            End If
            dr.Close()
            cmd.Dispose()



            '// Cadastra loja  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql = "Select iris.tblLojasGV.LojaID, iris.tblLojasGV.ClienteID, iris.tblLojasGV.Loja, iris.tblLojasGV.RazaoSocial, iris.tblLojasGV.NomeFantasia, iris.tblLojasGV.Status, iris.tblClientesGV.Cliente, iris.tblLojasGV.Endereco, iris.tblLojasGV.Numero, iris.tblLojasGV.Bairro, iris.tblLojasGV.CEP, iris.tblLojasGV.Cidade, iris.tblLojasGV.Estado, iris.tblLojasGV.Telefone1, iris.tblLojasGV.DDD "
            strSql += "From iris.tblLojasGV INNER Join iris.tblClientesGV ON iris.tblLojasGV.ClienteID = iris.tblClientesGV.ClienteID "
            strSql += "Where (iris.tblLojasGV.LojaID=" & IDLoja & ")"
            Dim drL As SqlDataReader
            con.ConnectionString = strConIRIS
            Dim cmdL As SqlCommand = con.CreateCommand
            cmdL.CommandText = strSql
            con.Open()
            drL = cmdL.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drL.HasRows Then
                drL.Read()

                Cliente = drL.Item("Cliente")
                IDCliente = drL.Item("ClienteID")
                loja = drL.Item("Loja")

                strSql = "INSERT tblLojas_Local "
                strSql += "(IDLoja, Loja, Endereco, Numero, Bairro, Cidade, Estado, CEP, Telefone, DDD) VALUES ("
                strSql += to_sql(drL.Item("LojaID")) & ","
                strSql += to_sql(NuloString(drL.Item("Loja"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Endereco"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Numero"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Bairro"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Cidade"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Estado"))) & ", "
                strSql += to_sql(NuloString(drL.Item("CEP"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Telefone1"))) & ", "
                strSql += to_sql(NuloString(drL.Item("DDD"))) & ")"
                ExecutaStr(strSql)
                DDD_Padrao = NuloString(drL.Item("DDD"))

            End If
            drL.Close()
            cmdL.Dispose()
            con.Dispose()
            con.Close()


            VerificaPermissaoModulos()
        Else
            ModulosIRIS = LeArquivoINI(nome_arquivo_ini, "Geral", "Modulos", "")
            RegistroDefinitivo = LeArquivoINI(nome_arquivo_ini, "Geral", "ModulosD", "0")
        End If


        If RegistroDefinitivo = False Then
            Dim diasRest As Integer = DateDiff(DateInterval.Day, CDate(Now).Date, CDate(DataLiberado).Date)
            If diasRest < 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Uso do sistema expirou" & vbCrLf & vbCrLf & "O sistema será abortado"
                frm.lbMensagem.ForeColor = Color.Red
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                End
            Else
                If diasRest <= 7 Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Até a presente data, não foi efetuado o pagamento mensal que dá direito ao Uso do Software Gourmet Visual" & vbCrLf & "Solicitamos o pagamento imediato a fim de evitar o bloqueio de uso do software" & vbCrLf & "Dias restantes: " & diasRest
                    frm.lbMensagem.ForeColor = Color.Red
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    frmPrincipal.lbPainel.ForeColor = Color.Red
                    If diasRest > 1 Then
                        frmPrincipal.lbPainel.Text = "Restam " & diasRest & " dias de uso do sistema antes do bloqueio"
                    Else
                        frmPrincipal.lbPainel.Text = "Último dia de uso do sistema antes do bloqueio"
                    End If
                End If
            End If
        End If


        '// Atualiza terminal no banco dados IRIS  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim DtAc As DateTime = Now
        strSql = "UPDATE iris.tblEquipamentos SET "
        strSql &= "VersaoProtec='" & Versao & "', "
        strSql &= "DataUltimoAcesso=" & to_sqlDATA(DtAc, "datahora", "I") & " "
        strSql &= "WHERE (EquipamentoID=" & EquipamentoIRIS & ")"
        If conexaIRIS = True Then
            ExecutaStrIRIS(strSql)

            If HabilitaHistorico = True Then
                strSql = "INSERT iris.tblEquipamentoHistorico "
                strSql += "(EquipamentoID,Data) VALUES ("
                strSql += NuloInteger(EquipamentoIRIS) & ", "
                strSql += to_sqlDATA(DtAc, "datahora", "I") & ")"
                ExecutaStrIRIS(strSql)
            End If
        End If

        '// Atualiza Vendas On-Line  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        AtualizaVendasOnLine = NuloInteger(LeArquivoINI(nome_arquivo_ini, "Geral", "AtualizaVendasOnLine", "0"))
        If AtualizaVendasOnLine = 0 Then
            EscreveINI("Geral", "AtualizaVendasOnLine", 300, nome_arquivo_ini)
            AtualizaVendasOnLine = 300
        End If

        '// Limpa Logs  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If RegistraLog = True Then
            strSql = "SELECT PeriodoLog FROM tblConfig"
            Dim DataLimpa As Date
            Dim Periodo As String = NuloString(PegaValorCampo("PeriodoLog", strSql, strCon))
            If Periodo <> "" Then
                If Periodo = "3 MESES" Then
                    DataLimpa = DateAdd(DateInterval.Month, -3, Now)
                    LimpaLogs(DataLimpa)
                End If
            End If
        End If

        Timer1.Enabled = True
        Timer1.Start()

    End Sub
    Public Sub DownloadViaFTP(ByVal arquivoFonte As String, ByVal userName As String, ByVal password As String)

        'Faz o Download do arquivo definido via FTP e 
        'salva em uma pasta da aplicação
        Dim readBuffer(4096) As Byte
        Dim contador As Integer

        Dim arquivoRequisitado As FtpWebRequest
        Dim respostaFTP As FtpWebResponse = Nothing
        Dim respostaStream As Stream = Nothing
        Dim arquivoSaida As FileStream = Nothing
        Dim pastaDestino As String

        ' ----- Obtem local onde irá salvar o arquivo
        Dim arquivo As String = My.Computer.FileSystem.GetName(arquivoFonte)
        'pastaDestino = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, My.Computer.FileSystem.GetName(arquivoFonte))
        pastaDestino = Application.StartupPath



        Dim dir As IO.Directory
        If dir.Exists(pastaDestino) = False Then
            dir.CreateDirectory(pastaDestino)
        End If

        Try
            ' ----- Faz a conexao com o arquivo no site FTP
            arquivoRequisitado = CType(FtpWebRequest.Create(New Uri(arquivoFonte)), FtpWebRequest)
            'arquivoRequisitado.Credentials = New NetworkCredential(userName, password, "ftp.iristecnologia.com.br")
            arquivoRequisitado.Credentials = New NetworkCredential(userName, password)
            arquivoRequisitado.KeepAlive = False
            arquivoRequisitado.UseBinary = True
            arquivoRequisitado.Method = WebRequestMethods.Ftp.DownloadFile
            ' ----- Abre um canal de transmissão para o arquivo
            respostaFTP = CType(arquivoRequisitado.GetResponse, FtpWebResponse)
            respostaStream = respostaFTP.GetResponseStream
            arquivoSaida = New FileStream(pastaDestino & "/" & arquivo, FileMode.OpenOrCreate)
            ' ----- Salva o conteúdo do arquivo de saida bloco a bloco
            Do
                contador = respostaStream.Read(readBuffer, 0, readBuffer.Length)
                arquivoSaida.Write(readBuffer, 0, contador)
            Loop Until contador = 0


        Catch ex As Exception

            System.Threading.Thread.Sleep(10000)
            Return
        End Try

        ' ----- libera recursos.
        respostaStream.Close()
        arquivoSaida.Flush()
        arquivoSaida.Close()
        respostaFTP.Close()

    End Sub
    Public Sub AtualizacaoDadosTerminal(Local As String)
        If Local = "I" Then   ' quando a Data de atualização do IRIS for MENOR que a Data de atualização Terminal
            If conexaIRIS = True Then
                strSql = "UPDATE iris.tblEquipamentos SET "
                strSql &= "DataSourceLocal='" & DTSource & "', "
                strSql &= "BancoDadosLocal='" & EndBcoDados & "', "
                strSql &= "UsuarioLocal='" & Usuario & "', "
                strSql &= "SenhaLocal='" & senhaINI & "', "
                strSql &= "DataSourceRet='" & DTSourceRET & "', "
                strSql &= "BancoDadosRet='" & EndBcoDadosRet & "', "
                strSql &= "UsuarioRet='" & UsuarioRET & "', "
                strSql &= "SenhaRet='" & senhaRET & "', "
                strSql &= "DataSourceIRIS='" & DTSourceRET & "', "
                strSql &= "BancoDadosIRIS='" & EndBcoDadosRet & "', "
                strSql &= "UsuarioIRIS='" & UsuarioRET & "', "
                strSql &= "SenhaIRIS='" & senhaRET & "', "
                If NuloBoolean(GerenciaImpressao) = False Then
                    strSql &= "GerenciaImpressao=0, "
                    strSql &= "GerenciaTablet=0, "
                    strSql &= "TabletAtivo=0, "
                Else
                    If NuloBoolean(TableAtivo) = True Then
                        strSql &= "GerenciaImpressao=1, "
                        strSql &= "GerenciaTablet=1, "
                        strSql &= "TabletAtivo=1, "
                    Else
                        strSql &= "GerenciaImpressao=1, "
                        strSql &= "GerenciaTablet=0, "
                        strSql &= "TabletAtivo=0, "
                    End If
                End If
                strSql &= "ImpressoraCaixa='" & NuloString(ImpCaixa) & "', "
                strSql &= "ImpressoraExpedicao='" & NuloString(ImpressoraExpedicao) & "', "
                strSql &= "ImpressoraCaixaTexto='" & NuloBoolean(ImpressoraCaixaTexto) & "', "
                strSql &= "GuilhotinaImpressoraCaixa='" & NuloBoolean(GuilhotinaImpCaixa) & "', "
                strSql &= "ImprimePedidoVenda='" & NuloBoolean(Imprime) & "', "
                strSql &= "GavetaEletronica='" & NuloBoolean(GavetaCaixa) & "', "
                strSql &= "PortaBalanca='" & NuloString(PortaBalanca) & "', "
                If PortaBalanca <> "" Then
                    If InStr(PortaBalanca, "COM") > 0 Then
                        PortaBalanca = NuloString(Strings.Right(PortaBalanca, Len(PortaBalanca) - 3))
                    End If
                End If
                strSql &= "AtualizaVendas='" & NuloBoolean(AtualizaVendas) & "', "
                strSql &= "ImpressoraConta='" & NuloString(ImpConta) & "', "
                strSql &= "EquipamentoSAT='" & EquipamentoSAT & "', "
                strSql &= "GerenciaSAT='" & NuloBoolean(GerenciaSAT) & "', "
                strSql &= "FixaAbreMesaCartao='" & NuloBoolean(FixaAbreMesaCartao) & "', "
                strSql &= "PedeMesa='" & NuloBoolean(PedeMesa) & "', "
                strSql &= "FixaTelaPedidos='" & NuloBoolean(FixaTelaPedidos) & "', "
                strSql &= "TempoLimiteTerminal=" & NuloInteger(TempoLimite) & ", "
                strSql &= "NaoCobraServico='" & NuloBoolean(TerminalNaoCobraServico) & "', "
                strSql &= "DataAtualizacao=" & to_sqlDATA(DTAtualizacaoDadosTerm_Local, "datahora", "I") & " "
                strSql &= "WHERE (EquipamentoID=" & EquipamentoIRIS & ")"
                ExecutaStrIRIS(strSql)
            End If

        Else
            Dim conIRIS As New SqlConnection(strConIRIS)

            strSql = "Select * From iris.tblEquipamentos "
            strSql += "WHERE (EquipamentoID=" & EquipamentoIRIS & ")"

            conIRIS.Open()
            Dim cmdIRIS As New SqlCommand(strSql, conIRIS)
            cmdIRIS.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmdIRIS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                ' Dados conexão Gourmet Visual /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                EscreveINI("Geral", "BancoDados", NuloString(dr.Item("BancoDadosLocal")), nome_arquivo_ini)
                EndBcoDados = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados", "")
                EscreveINI("Geral", "Data Source", NuloString(dr.Item("DataSourceLocal")), nome_arquivo_ini)
                DTSource = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source", String.Empty)
                EscreveINI("Geral", "Usuario", NuloString(dr.Item("UsuarioLocal")), nome_arquivo_ini)
                Usuario = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario", String.Empty)
                EscreveINI("Geral", "Senha", NuloString(dr.Item("SenhaLocal")), nome_arquivo_ini)
                senhaINI = LeArquivoINI(nome_arquivo_ini, "Geral", "Senha", String.Empty)
                EscreveINI("Geral", "FormatoDataLocal", NuloString(dr.Item("FormatoDataLocal")), nome_arquivo_ini)
                FormatoDataLocal = LeArquivoINI(nome_arquivo_ini, "Geral", "FormatoDataLocal", "dd/MM/yyyy")
                MontaSenha(senhaINI)
                strCon = "Server=" & DTSource & ";Database=" & EndBcoDados & ";User id=" & Usuario & ";Password =" & SenhaCon
                ' Dados conexão IRIS Gestão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                EscreveINI("Geral", "BancoDados_server", NuloString(dr.Item("BancoDadosRet")), nome_arquivo_ini)
                EndBcoDadosRet = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados_server", String.Empty)
                EscreveINI("Geral", "Data Source_server", NuloString(dr.Item("DataSourceRet")), nome_arquivo_ini)
                DTSourceRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source_server", String.Empty)
                EscreveINI("Geral", "Usuario_server", NuloString(dr.Item("UsuarioRet")), nome_arquivo_ini)
                UsuarioRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario_server", String.Empty)
                EscreveINI("Geral", "Senha_server", NuloString(dr.Item("SenhaRet")), nome_arquivo_ini)
                senhaRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Senha_server", String.Empty)
                EscreveINI("Geral", "FormatoDataRET", NuloString(dr.Item("FormatoDataServidor")), nome_arquivo_ini)
                FormatoDataRET = LeArquivoINI(nome_arquivo_ini, "Geral", "FormatoDataRET", "dd/MM/yyyy")
                MontaSenha(senhaRET)
                strConServer = "Server=" & DTSourceRET & ";Database=" & EndBcoDadosRet & ";User id=" & UsuarioRET & ";Password =" & SenhaCon

                EscreveINI("SAT", "EquipamentoSAT", NuloInteger(dr.Item("EquipamentoSAT")), nome_arquivo_ini)
                EquipamentoSAT = LeArquivoINI(nome_arquivo_ini, "SAT", "EquipamentoSAT", "0")
                If NuloBoolean(dr.Item("GerenciaSAT")) = False Then
                    EscreveINI("SAT", "GerenciaSAT", "0", nome_arquivo_ini)
                Else
                    EscreveINI("SAT", "GerenciaSAT", "1", nome_arquivo_ini)
                End If
                GerenciaSAT = LeArquivoINI(nome_arquivo_ini, "SAT", "GerenciaSAT", "0")
                If NuloBoolean(dr.Item("ImprimePedidoVenda")) = False Then
                    EscreveINI("Geral", "Imprime", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "Imprime", "1", nome_arquivo_ini)
                End If
                Imprime = LeArquivoINI(nome_arquivo_ini, "Geral", "Imprime", "0")
                If NuloBoolean(dr.Item("GavetaEletronica")) = False Then
                    EscreveINI("Geral", "GavetaEletronica", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "GavetaEletronica", "1", nome_arquivo_ini)
                End If
                GavetaCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "GavetaEletronica", "0")
                If NuloBoolean(dr.Item("GerenciaImpressao")) = False Then
                    EscreveINI("Geral", "GerenciaImpressao", "0", nome_arquivo_ini)
                    EscreveINI("Geral", "GerenciaTable", "0", nome_arquivo_ini)
                    EscreveINI("Geral", "TableAtivo", "0", nome_arquivo_ini)
                Else
                    If NuloBoolean(dr.Item("TabletAtivo")) = True Then
                        EscreveINI("Geral", "GerenciaImpressao", "1", nome_arquivo_ini)
                        EscreveINI("Geral", "GerenciaTablet", "1", nome_arquivo_ini)
                        EscreveINI("Geral", "TableAtivo", "1", nome_arquivo_ini)
                    Else
                        EscreveINI("Geral", "GerenciaImpressao", "1", nome_arquivo_ini)
                        EscreveINI("Geral", "GerenciaTablet", "0", nome_arquivo_ini)
                        EscreveINI("Geral", "TabletAtivo", "0", nome_arquivo_ini)
                    End If
                End If
                GerenciaImpressao = LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaImpressao", "0")
                GerenciaTable = LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaTablet", "0")
                TableAtivo = LeArquivoINI(nome_arquivo_ini, "Geral", "TabletAtivo", "0")
                EscreveINI("Geral", "PortaBalanca", NuloString(dr.Item("PortaBalanca")), nome_arquivo_ini)
                PortaBalanca = LeArquivoINI(nome_arquivo_ini, "Geral", "PortaBalanca", "")
                EscreveINI("Geral", "ImpressoraExpedicao", NuloString(dr.Item("ImpressoraExpedicao")), nome_arquivo_ini)
                ImpressoraExpedicao = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraExpedicao", "")
                EscreveINI("Geral", "ImpressoraCaixa", NuloString(dr.Item("ImpressoraCaixa")), nome_arquivo_ini)
                ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
                If NuloBoolean(dr.Item("GuilhotinaImpressoraCaixa")) = False Then
                    EscreveINI("Geral", "GuilhotinaImpressoraCaixa", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "GuilhotinaImpressoraCaixa", "1", nome_arquivo_ini)
                End If
                GuilhotinaImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "GuilhotinaImpressoraCaixa", "0")
                If NuloBoolean(dr.Item("ImpressoraCaixaTexto")) = False Then
                    EscreveINI("Geral", "ImpressoraCaixaTexto", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "ImpressoraCaixaTexto", "1", nome_arquivo_ini)
                End If
                ImpressoraCaixaTexto = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixaTexto", "0")
                If NuloBoolean(dr.Item("AtualizaVendas")) = False Then
                    EscreveINI("Geral", "AtualizaVendas", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "AtualizaVendas", "1", nome_arquivo_ini)
                End If
                AtualizaVendas = LeArquivoINI(nome_arquivo_ini, "Geral", "AtualizaVendas", "0")
                EscreveINI("Geral", "ImpressoraConta", NuloString(dr.Item("ImpressoraConta")), nome_arquivo_ini)
                ImpConta = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraConta", "")
                If NuloBoolean(dr.Item("GuilhotinaImpressoraConta")) = False Then
                    EscreveINI("Geral", "GuilhotinaImpressoraConta", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "GuilhotinaImpressoraConta", "1", nome_arquivo_ini)
                End If
                GuilhotinaImpConta = LeArquivoINI(nome_arquivo_ini, "Geral", "GuilhotinaImpressoraConta", "0")
                If NuloBoolean(dr.Item("FixaAbreMesaCartao")) = False Then
                    EscreveINI("Geral", "FixaAbreMesaCartao", "0", nome_arquivo_ini)
                Else
                    EscreveINI("Geral", "FixaAbreMesaCartao", "1", nome_arquivo_ini)
                End If
                FixaAbreMesaCartao = LeArquivoINI(nome_arquivo_ini, "Geral", "FixaAbreMesaCartao", "0")
                If NuloBoolean(dr.Item("PedeMesa")) = False Then
                    EscreveINI("TERMINAL_VENDA", "PedeMesa", "0", nome_arquivo_ini)
                Else
                    EscreveINI("TERMINAL_VENDA", "PedeMesa", "1", nome_arquivo_ini)
                End If
                PedeMesa = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "PedeMesa", "0")
                If NuloBoolean(dr.Item("FixaTelaPedidos")) = False Then
                    EscreveINI("TERMINAL_VENDA", "FixaTelaPedidos", "0", nome_arquivo_ini)
                Else
                    EscreveINI("TERMINAL_VENDA", "FixaTelaPedidos", "1", nome_arquivo_ini)
                End If
                FixaTelaPedidos = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "FixaTelaPedidos", "0")

                If NuloBoolean(dr.Item("NaoCobraServico")) = False Then
                    EscreveINI("TERMINAL_VENDA", "NaoCobraServico", "0", nome_arquivo_ini)
                Else
                    EscreveINI("TERMINAL_VENDA", "NaoCobraServico", "1", nome_arquivo_ini)
                End If
                TerminalNaoCobraServico = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "NaoCobraServico", "0")

                EscreveINI("TERMINAL_VENDA", "TempoLimite", NuloInteger(dr.Item("TempoLimiteTerminal")), nome_arquivo_ini)
                TempoLimite = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "TempoLimite", "0")

                EscreveINI("IFOOD", "IntegracaoIfood", NuloInteger(dr.Item("IntegracaoIfood")), nome_arquivo_ini)
                EscreveINI("QRBOX", "IntegracaoQRbox", NuloInteger(dr.Item("IntegracaoQRbox")), nome_arquivo_ini)

                EscreveINI("Geral", "DataAtualizacao", DTAtualizacaoDadosTerm_IRIS, nome_arquivo_ini)
            End If
        End If

    End Sub
    Public Sub AtualizacaoDadosGeral(Local As String)

        If Local = "I" Then   ' quando a Data de atualização do IRIS for MENOR que a Data de atualização LOCAL
            If conexaIRIS = True Then
                strSql = "UPDATE iris.tblLojasGV SET "
                strSql &= "ImprimeEstorno='" & NuloBoolean(ImpEstorno) & "', "
                strSql &= "ImprimeTransferencia='" & NuloBoolean(ImpTransferencia) & "', "
                strSql &= "ImprimeRecibo ='" & NuloBoolean(ImpRecibo) & "', "
                strSql &= "ModoFiscal='" & ModoFiscal & "', "
                strSql &= "CaixaIndividualizado='" & NuloBoolean(CaixaIndividualizado) & "', "
                strSql &= "NaoEncerraVendasAberto='" & NuloBoolean(NaoEncerraVendasAberto) & "', "
                strSql &= "FatorAjusteServico=" & NuloInteger(FatorAjusteServico) & ", "
                strSql &= "EnviaEmailFechamento='" & NuloBoolean(EnviaEmailFechamento) & "', "
                strSql &= "TextoSalao='" & TextoMesaPAR & "', "
                strSql &= "TextoServico='" & TextoServico & "', "
                strSql &= "PercServico=" & NuloInteger(PercServicoPAR) & ", "
                strSql &= "TempoLimite=" & NuloInteger(TempoLimitePedidosMesa) & ", "
                strSql &= "ObrigaConta='" & NuloBoolean(ObrigaConta) & "', "
                strSql &= "SetorBalcao=" & NuloInteger(SetorBalcao) & ", "
                strSql &= "InformaClienteBalcao='" & NuloBoolean(InformaClienteBalcao) & "', "
                strSql &= "SetorDelivery=" & NuloInteger(SetorDelivery) & ", "
                strSql &= "QtdeImpressaoExpedicao=" & NuloInteger(QtdeImpressaoExpedicao) & ", "
                strSql &= "TodosRelatorios='" & NuloBoolean(TodosRelatorios) & "', "
                strSql &= "ImprimeConferenciaBalcao='" & NuloBoolean(ImprimeConferenciaBalcao) & "', "
                strSql &= "IncluiFundoCaixa='" & NuloBoolean(IncluiFundoCaixa) & "', "
                strSql &= "CNPJSoftwareHouse='" & NuloString(CNPJSotwareHouse) & "', "
                strSql &= "NCM_Servico='" & NuloString(NCM_Servico) & "', "
                strSql &= "CSTPis_Servico='" & NuloString(CSTPis_Servico) & "', "
                strSql &= "CSTCofins_Servico='" & NuloString(CSTCofins_Servico) & "', "
                strSql &= "CFOP_Servico='" & NuloString(CFOP_Servico) & "', "
                strSql &= "CSTIcms_Servico='" & NuloString(CSTIcms_Servico) & "', "
                strSql &= "Aliquota_Servico='" & NuloString(Aliquota_Servico) & "', "
                strSql &= "RegistraLog='" & NuloBoolean(RegistraLog) & "', "
                If DTAtualizacaoDadosGeral_Local <> "" Then
                    strSql &= "DataAtualizacao=" & to_sqlDATA(DTAtualizacaoDadosGeral_Local, "datahora", "I") & " "
                Else
                    strSql &= "DataAtualizacao=" & to_sqlDATA(Now, "datahora", "I") & " "
                End If
                strSql &= "WHERE (LojaID=" & IDLoja & ")"
                ExecutaStrIRIS(strSql)
            End If
        Else
            Dim conIRIS As New SqlConnection(strConIRIS)

            strSql = "Select * From iris.tblLojasGV "
            strSql += "WHERE (iris.tblLojasGV.LojaID=" & IDLoja & ")"

            conIRIS.Open()
            Dim cmdIRIS As New SqlCommand(strSql, conIRIS)
            cmdIRIS.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmdIRIS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                strSql = "UPDATE tblConfig SET "
                strSql &= "ImprimeEstorno='" & NuloBoolean(dr.Item("ImprimeEstorno")) & "', "
                strSql &= "ImprimeTransferencia='" & NuloBoolean(dr.Item("ImprimeTransferencia")) & "', "
                strSql &= "ImprimeRecibo='" & NuloBoolean(dr.Item("ImprimeRecibo")) & "', "
                strSql &= "ModoFiscal='" & dr.Item("ModoFiscal") & "', "
                strSql &= "CaixaIndividualizado='" & NuloBoolean(dr.Item("CaixaIndividualizado")) & "', "
                strSql &= "NaoEncerraVendasAberto='" & NuloBoolean(dr.Item("NaoEncerraVendasAberto")) & "', "
                strSql &= "FatorAjusteServico=" & NuloInteger(dr.Item("FatorAjusteServico")) & ", "
                strSql &= "EnviaEmailFechamento='" & NuloBoolean(dr.Item("EnviaEmailFechamento")) & "', "
                strSql &= "TextoSalao='" & NuloString(dr.Item("TextoSalao")) & "', "
                strSql &= "TextoServico='" & NuloString(dr.Item("TextoServico")) & "', "
                strSql &= "PercServico=" & NuloInteger(dr.Item("PercServico")) & ", "
                strSql &= "TempoLimite=" & NuloInteger(dr.Item("TempoLimite")) & ", "
                strSql &= "ObrigaConta='" & NuloBoolean(dr.Item("ObrigaConta")) & "', "
                strSql &= "SetorBalcao=" & NuloInteger(dr.Item("SetorBalcao")) & ", "
                strSql &= "InformaClienteBalcao='" & NuloBoolean(dr.Item("InformaClienteBalcao")) & "', "
                strSql &= "SetorDelivery=" & NuloInteger(dr.Item("SetorDelivery")) & ", "
                strSql &= "QtdeImpressaoExpedicao=" & NuloInteger(dr.Item("QtdeImpressaoExpedicao")) & ", "
                strSql &= "TodosRelatorios='" & NuloBoolean(dr.Item("TodosRelatorios")) & "', "
                strSql &= "ImprimeConferenciaBalcao='" & NuloBoolean(dr.Item("ImprimeConferenciaBalcao")) & "', "
                strSql &= "IncluiFundoCaixa='" & NuloBoolean(dr.Item("IncluiFundoCaixa")) & "', "
                strSql &= "CNPJSoftwareHouse='" & NuloString(dr.Item("CNPJSoftwareHouse")) & "', "
                strSql &= "NCM_Servico='" & NuloString(dr.Item("NCM_Servico")) & "', "
                strSql &= "CSTPis_Servico='" & NuloString(dr.Item("CSTPis_Servico")) & "', "
                strSql &= "CSTCofins_Servico='" & NuloString(dr.Item("CSTCofins_Servico")) & "', "
                strSql &= "CFOP_Servico='" & NuloString(dr.Item("CFOP_Servico")) & "', "
                strSql &= "CSTIcms_Servico='" & NuloString(dr.Item("CSTIcms_Servico")) & "', "
                strSql &= "Aliquota_Servico='" & NuloString(dr.Item("Aliquota_Servico")) & "', "
                strSql &= "RegistraLog='" & NuloBoolean(dr.Item("RegistraLog")) & "', "
                strSql &= "DataAtualizacao=" & to_sqlDATA(DTAtualizacaoDadosGeral_IRIS, "datahora", "L") & " "
                ExecutaStr(strSql)

                ModoFiscal = dr.Item("ModoFiscal")
                FatorAjusteServico = NuloDecimal(dr.Item("FatorAjusteServico"))
                TodosRelatorios = NuloBoolean(dr.Item("TodosRelatorios"))
                ImprimeConferenciaBalcao = NuloBoolean(dr.Item("ImprimeConferenciaBalcao"))
                EnviaEmailFechamento = NuloBoolean(dr.Item("EnviaEmailFechamento"))
                NaoEncerraVendasAberto = NuloBoolean(dr.Item("NaoEncerraVendasAberto"))
                ImpEstorno = NuloBoolean(dr.Item("ImprimeEstorno"))
                ImpTransferencia = NuloBoolean(dr.Item("ImprimeTransferencia"))
                ImpRecibo = NuloBoolean(dr.Item("ImprimeRecibo"))
                CaixaIndividualizado = NuloBoolean(dr.Item("CaixaIndividualizado"))
                IncluiFundoCaixa = NuloBoolean(dr.Item("IncluiFundoCaixa"))
                RegistraLog = NuloBoolean(dr.Item("RegistraLog"))

                ' Parametros Salão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                TextoMesaPAR = NuloString(dr.Item("TextoSalao"))
                TextoServico = NuloString(dr.Item("TextoServico"))
                PercServico = NuloInteger(dr.Item("PercServico"))
                PercServicoPAR = NuloInteger(dr.Item("PercServico"))
                TempoLimitePedidosMesa = NuloInteger(dr.Item("TempoLimite"))
                ObrigaConta = NuloBoolean(dr.Item("ObrigaConta"))

                ' Parametros Balcão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SetorBalcao = NuloInteger(dr.Item("SetorBalcao"))
                InformaClienteBalcao = NuloBoolean(dr.Item("InformaClienteBalcao"))

                ' Parametros Delivery /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SetorDelivery = NuloInteger(dr.Item("SetorDelivery"))
                QtdeImpressaoExpedicao = NuloInteger(dr.Item("QtdeImpressaoExpedicao"))

            End If
            conIRIS.Dispose()
            conIRIS.Close()
            dr.Close()
            cmdIRIS.Dispose()

        End If
    End Sub
    Public Sub IniciaForm_OLD()
        tbFoco.Focus()




        ' Acha numero HD (chave primária) e o numero da loja ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        NumeroHD = NumeroSerial(Strings.Left(Application.StartupPath, 1))
        EscreveINI("Geral", "ChavePrimaria", NumeroHD, nome_arquivo_ini)
        Versao = lbVersao.Text

        If LeArquivoINI(nome_arquivo_ini, "Geral", "IDLoja", "") = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário informar o numero da loja no arquivo GV.ini na seção [Geral] (IDLoja=?)"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If

        If LeArquivoINI(nome_arquivo_ini, "IRIS", "Equipamento", "") = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário informar o numero do terminal no arquivo GV.ini na seção [IRIS] (Equipamento=?)"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If

        IDLoja = LeArquivoINI(nome_arquivo_ini, "Geral", "IDLoja", "")
        DTAtualizacaoDadosTerm_Local = LeArquivoINI(nome_arquivo_ini, "Geral", "DataAtualizacao", Now)

        ' Dados conexão Servidor IRIS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        EndBcoDadosIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "BancoDados", "0817081819040213141114060800"))
        DTSourceIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "Data Source", "bdi+99jh+99baf+99bef"))
        UsuarioIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "Usuario", "08170818c"))
        SenhaIRIS = MontaSenha(LeArquivoINI(nome_arquivo_ini, "IRIS", "Senha", "+15040317140200b"))
        EquipamentoIRIS = LeArquivoINI(nome_arquivo_ini, "IRIS", "Equipamento", 0)
        FormatoDataIRIS = LeArquivoINI(nome_arquivo_ini, "IRIS", "FormatoDataIRIS", "yyyy/MM/dd")
        strConIRIS = "Server=" & DTSourceIRIS & ";Database=" & EndBcoDadosIRIS & ";User id=" & UsuarioIRIS & ";Password =" & SenhaIRIS

        ' Verifica HD (Chave Primaria ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim conPri As New SqlConnection()
        strSql = "Select EquipamentoID, Descricao, HD, TerminalVenda, DataAtualizacao, chkHistoricoHabilitado "
        strSql += "From iris.tblEquipamentos "
        strSql += "Where (LojaID = " & IDLoja & ") And (HD = '" & NumeroHD & "') And (EquipamentoID = " & EquipamentoIRIS & ")"

        'Try
        Dim drPri As SqlDataReader
        conPri.ConnectionString = strConIRIS
        Dim cmdPri As SqlCommand = conPri.CreateCommand
        cmdPri.CommandText = strSql
        conPri.Open()
        drPri = cmdPri.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        TerminalVenda = False
        If Not drPri.HasRows Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Equipamento/Terminal não cadastrado." & vbCrLf & "Verifique a chave primária." & vbCrLf & NumeroHD & vbCrLf & "O sistema será abortado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        Else
            drPri.Read()
            TerminalVenda = NuloBoolean(drPri.Item("TerminalVenda"))
            HabilitaHistorico = NuloBoolean(drPri.Item("chkHistoricoHabilitado"))
            DTAtualizacaoDadosTerm_IRIS = NuloString(drPri.Item("DataAtualizacao"))
            If DTAtualizacaoDadosTerm_Local = "" And DTAtualizacaoDadosTerm_IRIS <> "" Then
                DTAtualizacaoDadosTerm_Local = DateAdd(DateInterval.Minute, -1, CType(DTAtualizacaoDadosTerm_IRIS, DateTime))
            Else
                If DTAtualizacaoDadosTerm_IRIS = "" And DTAtualizacaoDadosTerm_Local <> "" Then
                    DTAtualizacaoDadosTerm_IRIS = DateAdd(DateInterval.Minute, -1, CType(DTAtualizacaoDadosTerm_Local, DateTime))
                End If
            End If
        End If

        If TerminalVenda = False Then
            EscreveINI("Geral", "TerminalVenda", "0", nome_arquivo_ini)
        Else
            EscreveINI("Geral", "TerminalVenda", "1", nome_arquivo_ini)
        End If
        cmdPri.Dispose()
        drPri.Close()

        'Catch ex As Exception
        'DTAtualizacaoDadosTerm_IRIS = DateAdd(DateInterval.Minute, -1, CType(DTAtualizacaoDadosTerm_Local, DateTime))
        ''MsgBox(ex.Message)

        'Finally
        'conPri.Dispose()
        'conPri.Close()
        'End Try


        ' // Testa conexão com IRIS    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ' Verifica dias de uso ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        DiasUso = MontaSenha(LeArquivoINI(nome_arquivo_ini, "Geral", "DU", "jjj"))
        If DiasUso = 999 Then
            EscreveINI("Geral", "DU", DesmontaSenha(15), nome_arquivo_ini)
        End If
        If DiasUso <= 0 Then
            fdlgLiberaSistema.ShowDialog()
            DiasUso = MontaSenha(LeArquivoINI(nome_arquivo_ini, "Geral", "DU", "jjj")) + 1
        End If


        Dim conIRIS As New SqlConnection(strConIRIS)

        strSql = "Select tblRepresentantes.Representante, tblRepresentantes.NomeFantasia, tblRepresentantes.Telefone, tblRepresentantes.Contato, tblRepresentantes.Email, iris.tblLojasGV.LojaID, iris.tblLojasGV.Cidade, iris.tblLojasGV.Estado, iris.tblClientesGV.Cliente, iris.tblLojasGV.Loja, iris.tblLojasGV.DataAtualizacao, iris.tblLojasGV.Endereco, iris.tblLojasGV.Numero, iris.tblLojasGV.Bairro, iris.tblLojasGV.CEP, iris.tblLojasGV.Telefone1, iris.tblLojasGV.DDD "
        strSql += "From iris.tblLojasGV INNER Join iris.tblClientesGV ON iris.tblLojasGV.ClienteID = iris.tblClientesGV.ClienteID LEFT OUTER Join tblRepresentantes On iris.tblLojasGV.IDRepresentante = tblRepresentantes.IDRepresentante "
        strSql += "WHERE (iris.tblLojasGV.LojaID=" & IDLoja & ")"

        conexaIRIS = True
        Try
            conIRIS.Open()
            Dim cmdIRIS As New SqlCommand(strSql, conIRIS)
            cmdIRIS.CommandType = CommandType.Text

            DTAtualizacaoDadosGeral_IRIS = ""
            CidadeLoja = ""
            EstadoLoja = ""
            DDD_Padrao = ""
            CEPLoja = ""
            EnderecoLoja = ""
            BairroLoja = ""
            TelefoneLoja = ""
            NomeLoja = "SEM CONEXÃO"
            NomeEmpresa = "SEM CONEXÃO"
            Dim drIRIS As SqlDataReader = cmdIRIS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drIRIS.HasRows Then
                drIRIS.Read()
                EscreveINI("Geral", "DU", DesmontaSenha(15), nome_arquivo_ini)
                EscreveINI("Representante", "Nome", NuloString(drIRIS.Item("Representante")), nome_arquivo_ini)
                EscreveINI("Representante", "NomeFantasia", NuloString(drIRIS.Item("NomeFantasia")), nome_arquivo_ini)
                EscreveINI("Representante", "Telefone", NuloString(drIRIS.Item("Telefone")), nome_arquivo_ini)
                EscreveINI("Representante", "Contato", NuloString(drIRIS.Item("Contato")), nome_arquivo_ini)
                EscreveINI("Representante", "Email", NuloString(drIRIS.Item("Email")), nome_arquivo_ini)
                CidadeLoja = NuloString(drIRIS.Item("Cidade"))
                EstadoLoja = NuloString(drIRIS.Item("Estado"))
                NomeLoja = NuloString(drIRIS.Item("Loja"))
                NomeEmpresa = NuloString(drIRIS.Item("Cliente"))
                CEPLoja = Replace(NuloString(drIRIS.Item("CEP")), "-", "")
                DDD_Padrao = NuloString(drIRIS.Item("DDD"))
                EnderecoLoja = NuloString(drIRIS.Item("Endereco")) & " " & NuloString(drIRIS.Item("Numero"))
                BairroLoja = NuloString(drIRIS.Item("Bairro"))
                TelefoneLoja = NuloString(drIRIS.Item("Telefone1"))
                DTAtualizacaoDadosGeral_IRIS = NuloString(drIRIS.Item("DataAtualizacao"))
            End If
            cmdIRIS.Dispose()
            drIRIS.Close()

        Catch ex As Exception
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Sem conexão com IRIS Tecnologia. Verifique sua conexão com a internet. O sistema continuara com limite de acessos"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            EscreveINI("Geral", "DU", DesmontaSenha(DiasUso - 1), nome_arquivo_ini)
            conexaIRIS = False

        End Try
        conIRIS.Dispose()
        conIRIS.Close()

        ' Parametros Representante /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        NomeRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Nome", "")
        NomeFanRep = LeArquivoINI(nome_arquivo_ini, "Representante", "NomeFantasia", "")
        TelefoneRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Telefone", "")
        ContatoRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Contato", "")
        EmailRep = LeArquivoINI(nome_arquivo_ini, "Representante", "Email", "")





        ' Verifica dados config local /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ' Dados conexão Gourmet Visual /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        If DateDiff(DateInterval.Second, CType(DTAtualizacaoDadosTerm_Local, DateTime), CType(DTAtualizacaoDadosTerm_IRIS, DateTime)) > 0 Then
            AtualizacaoDadosTerminal("L") ' Atualiza o terminal LOCAL  ////////////////////////////////////
        Else
            EndBcoDados = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados", "")
            DTSource = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source", "")
            Usuario = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario", "")
            senhaINI = LeArquivoINI(nome_arquivo_ini, "Geral", "Senha", "")
            FormatoDataLocal = NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "FormatoDataLocal", "dd/MM/yyyy"))
            MontaSenha(senhaINI)
            strCon = "Server=" & DTSource & ";Database=" & EndBcoDados & ";User id=" & Usuario & ";Password =" & SenhaCon
            ' Dados conexão IRIS Gestão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            EndBcoDadosRet = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados_server", "")
            DTSourceRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source_server", "")
            UsuarioRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario_server", "")
            senhaRET = LeArquivoINI(nome_arquivo_ini, "Geral", "Senha_server", "")
            FormatoDataRET = NuloString(LeArquivoINI(nome_arquivo_ini, "Geral", "FormatoDataRET", "dd/MM/yyyy"))
            MontaSenha(senhaRET)
            strConServer = "Server=" & DTSourceRET & ";Database=" & EndBcoDadosRet & ";User id=" & UsuarioRET & ";Password =" & SenhaCon
            GerenciaImpressao = LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaImpressao", "0")
            GerenciaTable = LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaTablet", "0")
            TableAtivo = LeArquivoINI(nome_arquivo_ini, "Geral", "TabletAtivo", "0")
            ImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
            ImpressoraExpedicao = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraExpedicao", "")
            ImpressoraCaixaTexto = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixaTexto", "0")
            GuilhotinaImpCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "GuilhotinaImpressoraCaixa", "0")
            Imprime = LeArquivoINI(nome_arquivo_ini, "Geral", "Imprime", "0")
            GavetaCaixa = LeArquivoINI(nome_arquivo_ini, "Geral", "GavetaEletronica", "0")
            PortaBalanca = UCase(LeArquivoINI(nome_arquivo_ini, "Geral", "PortaBalanca", ""))
            AtualizaVendas = UCase(LeArquivoINI(nome_arquivo_ini, "Geral", "AtualizaVendas", 0))
            RegistraLog = UCase(LeArquivoINI(nome_arquivo_ini, "Geral", "RegistraLog", 0))
            If LeArquivoINI(nome_arquivo_ini, "Geral", "FixaAbreMesaCartao", 0) = False Then
                FixaAbreMesaCartao = False
            Else
                FixaAbreMesaCartao = True
            End If

            ' Salão ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ImpConta = LeArquivoINI(nome_arquivo_ini, "Salao", "ImpressoraConta", "")

            ' Delivery ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            GerenciaPedidoProgramado = LeArquivoINI(nome_arquivo_ini, "Delivery", "GerenciaPedidoProgramado", 0)

            ' SAT ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            EquipamentoSAT = LeArquivoINI(nome_arquivo_ini, "SAT", "EquipamentoSAT", "0")
            GerenciaSAT = LeArquivoINI(nome_arquivo_ini, "SAT", "GerenciaSAT", "0")

            ' Terminal Venda ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            PedeMesa = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "PedeMesa", "0")
            FixaTelaPedidos = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "FixaTelaPedidos", "0")
            TempoLimite = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "TempoLimite", 0)
            TerminalNaoCobraServico = LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "NaoCobraServico", 0)

            ' QRbox ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            GerenciaPedidosQRbox = LeArquivoINI(nome_arquivo_ini, "QRBOX", "GerenciaPedidosQRbox", "0")
            IntegracaoQRbox = NuloInteger(LeArquivoINI(nome_arquivo_ini, "QRBOX", "IntegracaoQRbox", 0))

            ' Ifood ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            GerenciaPedidosIfood = LeArquivoINI(nome_arquivo_ini, "IFOOD", "GerenciaPedidos", "0")
            IntegracaoIfood = NuloInteger(LeArquivoINI(nome_arquivo_ini, "IFOOD", "IntegracaoIfood", 0))

        End If



        If FormatoDataLocal = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Formato da data local inválido. O sistema será abortado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If
        If FormatoDataRET = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Formato da data retaguarda inválido. O sistema será abortado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If

        If DTAtualizacaoDadosTerm_IRIS = "" Then
            AtualizacaoDadosTerminal("I") ' Atualiza o terminal IRIS  ////////////////////////////////////
        Else
            If DateDiff(DateInterval.Second, CType(DTAtualizacaoDadosTerm_Local, DateTime), CType(DTAtualizacaoDadosTerm_IRIS, DateTime)) < 0 Then
                AtualizacaoDadosTerminal("I") ' Atualiza o terminal IRIS  ////////////////////////////////////
                'Else
                'If DateDiff(DateInterval.Second, CType(DTAtualizacaoDadosTerm_Local, DateTime), CType(DTAtualizacaoDadosTerm_IRIS, DateTime)) > 0 Then
                'AtualizacaoDadosTerminal("L") ' Atualiza o terminal LOCAL  ////////////////////////////////////
                'End If
            End If
        End If






        ' // Testa conexão com banco de dados local    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim conTe As New SqlConnection()
        strSql = "Select * From tblConfig"

        Dim drTe As SqlDataReader
        conTe.ConnectionString = strCon
        Dim cmdTe As SqlCommand = conTe.CreateCommand
        cmdTe.CommandText = strSql
        Try
            conTe.Open()
            drTe = cmdTe.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            drTe.Read()
            '' Parametros Geral /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MostraComentExpedicao = NuloBoolean(drTe.Item("MostraComentExpedicao"))
            ImpEstorno = NuloBoolean(drTe.Item("ImprimeEstorno"))
            ImpTransferencia = NuloBoolean(drTe.Item("ImprimeTransferencia"))
            ImpRecibo = NuloBoolean(drTe.Item("ImprimeRecibo"))
            ModoFiscal = NuloString(drTe.Item("ModoFiscal"))
            CaixaIndividualizado = NuloBoolean(drTe.Item("CaixaIndividualizado"))
            NaoEncerraVendasAberto = NuloBoolean(drTe.Item("NaoEncerraVendasAberto"))
            EnviaEmailFechamento = NuloBoolean(drTe.Item("EnviaEmailFechamento"))
            TodosRelatorios = NuloBoolean(drTe.Item("TodosRelatorios"))
            IncluiFundoCaixa = NuloBoolean(drTe.Item("IncluiFundoCaixa"))
            RegistraLog = NuloBoolean(drTe.Item("RegistraLog"))

            ' Parametros Salão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            PercServicoPAR = NuloDecimal(drTe.Item("PercServico"))
            TempoLimitePedidosMesa = NuloInteger(drTe.Item("TempoLimite"))
            TempoLimitePedidosMesaEmEspera = NuloInteger(drTe.Item("TempoLimiteEmEspera"))
            TextoServico = NuloString(drTe.Item("TextoServico"))
            ObrigaConta = NuloBoolean(drTe.Item("ObrigaConta"))
            FatorAjusteServico = NuloDecimal(drTe.Item("FatorAjusteServico"))
            TextoMesaPAR = NuloString(drTe.Item("TextoSalao"))
            If UCase(TextoMesaPAR) = "MESA" Then
                TextoMsg = "uma MESA"
            Else
                If UCase(TextoMesaPAR) = "CARTÃO" Then
                    TextoMsg = "um CARTÃO"
                Else
                    TextoMsg = ""
                End If
            End If

            ' Parametros Balcão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SetorBalcao = NuloInteger(drTe.Item("SetorBalcao"))
            InformaClienteBalcao = NuloBoolean(drTe.Item("InformaClienteBalcao"))
            ImprimeConferenciaBalcao = NuloBoolean(drTe.Item("ImprimeConferenciaBalcao"))

            ' Parametros Delivery /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            SetorDelivery = NuloInteger(drTe.Item("SetorDelivery"))
            QtdeImpressaoExpedicao = NuloInteger(drTe.Item("QtdeImpressaoExpedicao"))

            ' Parametros SAT /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            CNPJSotwareHouse = NuloString(drTe.Item("CNPJSoftwareHouse"))
            NCM_Servico = NuloString(drTe.Item("NCM_Servico"))
            CSTPis_Servico = NuloString(drTe.Item("CSTPis_Servico"))
            CSTCofins_Servico = NuloString(drTe.Item("CSTCofins_Servico"))
            CFOP_Servico = NuloString(drTe.Item("CFOP_Servico"))
            CSTIcms_Servico = NuloString(drTe.Item("CSTIcms_Servico"))
            Aliquota_Servico = NuloDecimal(drTe.Item("Aliquota_Servico"))
            DTAtualizacaoDadosGeral_Local = NuloString(drTe.Item("DataAtualizacao"))

            ' IFood /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UsernameIfood = NuloString(drTe.Item("UsernameIfood"))
            PasswordIfood = NuloString(drTe.Item("PasswordIfood"))
            IDmerchantIfood = NuloString(drTe.Item("IDmerchantIfood"))

            ' QRbox /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UsernameQRbox = NuloString(drTe.Item("UsernameQRbox"))
            PasswordQRbox = NuloString(drTe.Item("PasswordQRbox"))
            IDmerchantQRbox = NuloString(drTe.Item("IDmerchantQRbox"))

            drTe.Close()

            If DTAtualizacaoDadosGeral_Local = "" Then
                'DTAtualizacaoDadosGeral_Local = Now
                'strSql = "UPDATE tblConfig SET DataAtualizacao='" & DTAtualizacaoDadosGeral_Local & "'"
                'ExecutaStr(strSql)
            End If


        Catch ex As Exception

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = ex.Message
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End

        End Try
        cmdTe.Dispose()
        conTe.Dispose()
        conTe.Close()

        If DTAtualizacaoDadosGeral_IRIS = "" Then
            ' AtualizacaoDadosGeral("I") ' Atualiza o config IRIS  ////////////////////////////////////
        Else
            If DTAtualizacaoDadosGeral_Local = "" Then
                strSql = "UPDATE tblConfig SET "
                strSql &= "ImprimeEstorno='" & NuloBoolean(ImpEstorno) & "', "
                strSql &= "ImprimeTransferencia='" & NuloBoolean(ImpTransferencia) & "', "
                strSql &= "ImprimeRecibo='" & NuloBoolean(ImpRecibo) & "', "
                strSql &= "ModoFiscal='" & NuloString(ModoFiscal) & "', "
                strSql &= "CaixaIndividualizado='" & NuloBoolean(CaixaIndividualizado) & "', "
                strSql &= "NaoEncerraVendasAberto='" & NuloBoolean(NaoEncerraVendasAberto) & "', "
                strSql &= "FatorAjusteServico=" & NuloInteger(FatorAjusteServico) & ", "
                strSql &= "EnviaEmailFechamento='" & NuloBoolean(EnviaEmailFechamento) & "', "
                strSql &= "TextoSalao='" & NuloString(TextoMesaPAR) & "', "
                strSql &= "TextoServico='" & NuloString(TextoServico) & "', "
                strSql &= "PercServico=" & NuloInteger(PercServico) & ", "
                strSql &= "TempoLimite=" & NuloInteger(TempoLimite) & ", "
                strSql &= "ObrigaConta='" & NuloBoolean(ObrigaConta) & "', "
                strSql &= "SetorBalcao=" & NuloInteger(SetorBalcao) & ", "
                strSql &= "InformaClienteBalcao='" & NuloBoolean(InformaClienteBalcao) & "', "
                strSql &= "SetorDelivery=" & NuloInteger(SetorDelivery) & ", "
                strSql &= "QtdeImpressaoExpedicao=" & NuloInteger(QtdeImpressaoExpedicao) & ", "
                strSql &= "TodosRelatorios='" & NuloBoolean(TodosRelatorios) & "', "
                strSql &= "ImprimeConferenciaBalcao='" & NuloBoolean(ImprimeConferenciaBalcao) & "', "
                strSql &= "DataAtualizacao=" & to_sqlDATA(DTAtualizacaoDadosGeral_IRIS, "datahora", "L") & ", "
                strSql &= "RegistraLog='" & NuloBoolean(RegistraLog) & "' "
                'ExecutaStr(strSql)
            Else
                If DateDiff(DateInterval.Second, CType(DTAtualizacaoDadosGeral_Local, DateTime), CType(DTAtualizacaoDadosGeral_IRIS, DateTime)) < 0 Then
                    ' AtualizacaoDadosGeral("I") ' Atualiza o config IRIS  ////////////////////////////////////
                Else
                    If DateDiff(DateInterval.Second, CType(DTAtualizacaoDadosGeral_Local, DateTime), CType(DTAtualizacaoDadosGeral_IRIS, DateTime)) > 0 Then
                        ' AtualizacaoDadosGeral("L") ' Atualiza o config LOCAL  ////////////////////////////////////
                    End If
                End If
            End If
        End If



        If conexaIRIS = True Then
            strSql = "Delete From tblTerminais"
            ExecutaStr(strSql)

            strSql = "Delete From tblLojas_Local"
            ExecutaStr(strSql)


            Dim con As New SqlConnection()
            strSql = "Select EquipamentoID, Descricao, HD "
            strSql += "From iris.tblEquipamentos "
            strSql += "Where (LojaID = " & IDLoja & ")"

            ' Cadastra terminais  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Dim dr As SqlDataReader
            con.ConnectionString = strConIRIS
            Dim cmd As SqlCommand = con.CreateCommand
            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While dr.Read()

                    strSql = "INSERT tblTerminais "
                    strSql += "(IDTerminal, Terminal) VALUES ("
                    strSql += to_sql(dr.Item("EquipamentoID")) & ","
                    strSql += to_sql(dr.Item("Descricao")) & ")"
                    ExecutaStr(strSql)

                End While
            End If
            dr.Close()
            cmd.Dispose()



            '// Cadastra loja  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql = "Select iris.tblLojasGV.LojaID, iris.tblLojasGV.ClienteID, iris.tblLojasGV.Loja, iris.tblLojasGV.RazaoSocial, iris.tblLojasGV.NomeFantasia, iris.tblLojasGV.Status, iris.tblClientesGV.Cliente, iris.tblLojasGV.Endereco, iris.tblLojasGV.Numero, iris.tblLojasGV.Bairro, iris.tblLojasGV.CEP, iris.tblLojasGV.Cidade, iris.tblLojasGV.Estado, iris.tblLojasGV.Telefone1, iris.tblLojasGV.DDD "
            strSql += "From iris.tblLojasGV INNER Join iris.tblClientesGV ON iris.tblLojasGV.ClienteID = iris.tblClientesGV.ClienteID "
            strSql += "Where (iris.tblLojasGV.LojaID=" & IDLoja & ")"
            Dim drL As SqlDataReader
            con.ConnectionString = strConIRIS
            Dim cmdL As SqlCommand = con.CreateCommand
            cmdL.CommandText = strSql
            con.Open()
            drL = cmdL.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drL.HasRows Then
                drL.Read()

                Cliente = drL.Item("Cliente")
                IDCliente = drL.Item("ClienteID")
                loja = drL.Item("Loja")


                strSql = "INSERT tblLojas_Local "
                strSql += "(IDLoja, Loja, Endereco, Numero, Bairro, Cidade, Estado, CEP, Telefone, DDD) VALUES ("
                strSql += to_sql(drL.Item("LojaID")) & ","
                strSql += to_sql(NuloString(drL.Item("Loja"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Endereco"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Numero"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Bairro"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Cidade"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Estado"))) & ", "
                strSql += to_sql(NuloString(drL.Item("CEP"))) & ", "
                strSql += to_sql(NuloString(drL.Item("Telefone1"))) & ", "
                strSql += to_sql(NuloString(drL.Item("DDD"))) & ")"
                ExecutaStr(strSql)
                DDD_Padrao = NuloString(drL.Item("DDD"))

            End If
            drL.Close()
            cmdL.Dispose()
            con.Dispose()
            con.Close()


            VerificaPermissaoModulos()
        Else
            ModulosIRIS = LeArquivoINI(nome_arquivo_ini, "Geral", "Modulos", "")
            RegistroDefinitivo = LeArquivoINI(nome_arquivo_ini, "Geral", "ModulosD", "0")
        End If


        If RegistroDefinitivo = False Then
            Dim diasRest As Integer = DateDiff(DateInterval.Day, CDate(Now).Date, CDate(DataLiberado).Date)
            If diasRest < 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Uso do sistema expirou" & vbCrLf & vbCrLf & "O sistema será abortado"
                frm.lbMensagem.ForeColor = Color.Red
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                End
            Else
                If diasRest <= 7 Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Até a presente data, não foi efetuado o pagamento mensal que dá direito ao Uso do Software Gourmet Visual" & vbCrLf & "Solicitamos o pagamento imediato a fim de evitar o bloqueio de uso do software" & vbCrLf & "Dias restantes: " & diasRest
                    frm.lbMensagem.ForeColor = Color.Red
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    frmPrincipal.lbPainel.ForeColor = Color.Red
                    If diasRest > 1 Then
                        frmPrincipal.lbPainel.Text = "Restam " & diasRest & " dias de uso do sistema antes do bloqueio"
                    Else
                        frmPrincipal.lbPainel.Text = "Último dia de uso do sistema antes do bloqueio"
                    End If
                End If
            End If
        End If


        '// Atualiza terminal no banco dados IRIS  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim DtAc As DateTime = Now
        strSql = "UPDATE iris.tblEquipamentos SET "
        strSql &= "VersaoProtec='" & Versao & "', "
        strSql &= "DataUltimoAcesso=" & to_sqlDATA(DtAc, "datahora", "I") & " "
        strSql &= "WHERE (EquipamentoID=" & EquipamentoIRIS & ")"
        If conexaIRIS = True Then
            ExecutaStrIRIS(strSql)

            If HabilitaHistorico = True Then
                strSql = "INSERT iris.tblEquipamentoHistorico "
                strSql += "(EquipamentoID,Data) VALUES ("
                strSql += NuloInteger(EquipamentoIRIS) & ", "
                strSql += to_sqlDATA(DtAc, "datahora", "I") & ")"
                ExecutaStrIRIS(strSql)
            End If

        End If



        '// Atualiza Vendas On-Line  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        AtualizaVendasOnLine = NuloInteger(LeArquivoINI(nome_arquivo_ini, "Geral", "AtualizaVendasOnLine", "0"))
        If AtualizaVendasOnLine = 0 Then
            EscreveINI("Geral", "AtualizaVendasOnLine", 300, nome_arquivo_ini)
            AtualizaVendasOnLine = 300
        End If



        '// Limpa Logs  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If RegistraLog = True Then
            strSql = "SELECT PeriodoLog FROM tblConfig"
            Dim DataLimpa As Date
            Dim Periodo As String = NuloString(PegaValorCampo("PeriodoLog", strSql, strCon))
            If Periodo <> "" Then
                If Periodo = "3 MESES" Then
                    DataLimpa = DateAdd(DateInterval.Month, -3, Now)
                    LimpaLogs(DataLimpa)
                End If
            End If
        End If

        Timer1.Enabled = True
        Timer1.Start()

    End Sub
    Private Sub frmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Processo = System.Diagnostics.Process.GetCurrentProcess()
        Dim JaEstaRodando = System.Diagnostics.Process.GetProcessesByName(Processo.ProcessName).Any(Function(P) P.Id <> Processo.Id)
        If (JaEstaRodando) Then End


        Try
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("GV")
            For Each p As Process In pProcess
                p.Kill()
            Next

            If Not IO.File.Exists(Application.StartupPath & "\toque.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque01.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque01.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque02.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque02.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque03.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque03.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque04.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque04.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque05.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque05.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque06.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque06.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque07.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque07.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque08.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque08.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque09.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque09.wav", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\toque10.wav") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/toque10.wav", "iristecnologia", "647Bkzs?")
            End If



            If Not IO.File.Exists(Application.StartupPath & "\Newtonsoft.Json.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Newtonsoft.Json.dll", "iristecnologia", "647Bkzs?")
            End If

            If Not IO.File.Exists(Application.StartupPath & "\Newtonsoft.Json.xml") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Newtonsoft.Json.xml", "iristecnologia", "647Bkzs?")
            End If

            If Not IO.File.Exists(Application.StartupPath & "\RestSharp.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/RestSharp.dll", "iristecnologia", "647Bkzs?")
            End If

            If Not IO.File.Exists(Application.StartupPath & "\RestSharp.xml") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/RestSharp.xml", "iristecnologia", "647Bkzs?")
            End If



            If Not IO.File.Exists(Application.StartupPath & "\ifood.png") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/ifood.png", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\qrbox.jpg") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/qrbox.jpg", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\rappi.png") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/rappi.png", "iristecnologia", "647Bkzs?")
            End If



            ' Bematech ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If Not IO.File.Exists(Application.StartupPath & "\MP2032.chm") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/MP2032.chm", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\mp2032.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/mp2032.dll", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\mp2032.ini") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/mp2032.ini", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\SiUSBXp.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/SiUSBXp.dll", "iristecnologia", "647Bkzs?")
            End If



            If Not IO.File.Exists(Application.StartupPath & "\Microsoft.Web.WebView2.Core.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Microsoft.Web.WebView2.Core.dll", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\Microsoft.Web.WebView2.Core.xml") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Microsoft.Web.WebView2.Core.xml", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\Microsoft.Web.WebView2.WinForms.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Microsoft.Web.WebView2.WinForms.dll", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\Microsoft.Web.WebView2.WinForms.xml") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Microsoft.Web.WebView2.WinForms.xml", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\Microsoft.Web.WebView2.Wpf.dll") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Microsoft.Web.WebView2.Wpf.dll", "iristecnologia", "647Bkzs?")
            End If
            If Not IO.File.Exists(Application.StartupPath & "\Microsoft.Web.WebView2.Wpf.xml") Then
                DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/Microsoft.Web.WebView2.Wpf.xml", "iristecnologia", "647Bkzs?")
            End If



        Catch ex As Exception

        End Try


        IniciaForm()


    End Sub
    Public Sub VerificaTabelaLoja(ID As Integer, NomeTabela As String, IRISGestao As String)

        strSql = "Select ID, IDLoja, Tabela, GourmetVisual From tblAtualizaTabelasLojas WHERE (ID=" & ID & ") AND (IDLoja=" & IDLoja & ")"

        Dim conV As New SqlConnection()
        Dim drV As SqlDataReader

        conV.ConnectionString = strConServer
        Dim cmdV As SqlCommand = conV.CreateCommand
        cmdV.CommandText = strSql


        conV.Open()
        drV = cmdV.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drV.HasRows Then
            drV.Read()
            'If NuloString(drV.Item("GourmetVisual")) < NuloString(IRISGestao) Then

            Dim Data1 As String = Convert.ToDateTime(drV.Item("GourmetVisual"))
            Dim Data2 As String = Convert.ToDateTime(IRISGestao)

            If DateDiff(DateInterval.Minute, CType(Data1, DateTime), CType(Data2, DateTime)) > 0 Then
                lbStatus.Text = "Atualizando " & NomeTabela
                lbStatus.Refresh()
                AtualizaTabela(NomeTabela)

                strSql = "UPDATE tblAtualizaTabelasLojas SET "
                strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
                strSql &= "WHERE (ID=" & ID & ") AND (IDLoja=" & IDLoja & ")"
                ExecutaStrServidor(strSql)
            End If
        Else

            AtualizaTablet = True
            lbStatus.Text = "Atualizando " & NomeTabela
            lbStatus.Refresh()
            AtualizaTabela(NomeTabela)

            strSql = "INSERT tblAtualizaTabelasLojas "
            strSql += "(ID,IDLoja,Tabela,GourmetVisual) VALUES ("
            strSql += NuloInteger(ID) & ", "
            strSql += NuloInteger(IDLoja) & ", "
            strSql += "'" & NuloString(NomeTabela) & "', "
            strSql += "'" & Now.ToString(FormatoDataRET) & "')"
            ExecutaStrServidor(strSql)
        End If
        cmdV.Dispose()
        drV.Close()
        conV.Dispose()
        conV.Close()

        'MsgBox("ok")

    End Sub
    Private Sub Inicia()

        Label1.Visible = True
        Label1.Refresh()
        BarInicio.Visible = True

        Timer1.Enabled = False
        Dim ProgreBar As Double = 100 / 8

        strSql = "Select Tabela, IRISGestao, GourmetVisual, ID From tblAtualizaTabelas Order By Tabela"

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strConServer
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While (dr.Read())

                    If NuloString(dr.Item("IRISGestao")) = "" Then
                        VerificaTabelaLoja(dr.Item("ID"), dr.Item("Tabela"), Now)
                    Else
                        VerificaTabelaLoja(dr.Item("ID"), dr.Item("Tabela"), dr.Item("IRISGestao").ToString)
                    End If

                    If BarInicio.Value + CInt(ProgreBar) < 100 Then BarInicio.Value += CInt(ProgreBar)
                    BarInicio.Refresh()
                    Thread.Sleep(50)
                End While
            End If
            dr.Close()
            cmd.Dispose()

            If AtualizaTablet = True Then
                lbStatus.Text = "Atualizando Tables Tablet"
                lbStatus.Refresh()

                Atualiza_Tablet()

                lbStatus.Text = ""
                lbStatus.Refresh()
            End If

            BarInicio.Value = 100
            BarInicio.Refresh()

            Thread.Sleep(500)
            Application.DoEvents()

            Label1.Visible = False
            lbVersao.Visible = False
            PictureBox1.Visible = False
            BarInicio.Visible = False
            lbErro1.Visible = False
            lbErro2.Visible = False
            lbStatus.Visible = False

        Catch ex As Exception
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "ATENÇÃO: Erro ao conectar com IRIS Gestão, as tabelas não foram atualizadas" & vbCrLf & vbCrLf & ex.Message
            frm1.lbMensagem.ForeColor = Color.Blue
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()

            Label1.Visible = False
            lbVersao.Visible = False
            PictureBox1.Visible = False
            BarInicio.Visible = False
            lbErro1.Visible = False
            lbErro2.Visible = False
            lbStatus.Visible = False
        End Try

        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If GerenciaImpressao = True Then
            Try

                Dim s() As Process
                s = Process.GetProcessesByName("Gerenciador de Impressao")
                If s.Length = 0 Then
                    System.Diagnostics.Process.Start(Application.StartupPath & "\Gerenciador de Impressao.exe")
                End If

            Catch ex As Exception
                frm.lbMensagem.Text = "Gerenciador de Impressão não encontrado"
                frm.lbMensagem.ForeColor = Color.Blue
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            End Try
        End If

        If Application.OpenForms.OfType(Of frmPrincipal)().Count() = 0 Then
            frmPrincipal.ShowDialog()
        Else
            frmPrincipal.Focus()
            frmPrincipal.lblSenha.Focus()
        End If

        con.Dispose()
        con.Close()


    End Sub
    Function Atualiza_Tablet()
        Dim retorno As Boolean = False

        Limpa_Cria_TabelasSQL()
        AtualizaFunc()
        AtualizaMesas()
        AtualizaDescricaoFamilias()
        ' AtualizaClientes()
        AtualizaGrupo()
        AtualizaProdutos()
        AtualizaFamilias()
        AtualizaMontagem()
        AtualizaCampo()

        retorno = True

        Return retorno
    End Function

    Function AtualizaTabela(Tabela As String)
        Dim retorno As Boolean = False

        ' tblComentarios ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Comentarios" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblComentarios_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select tblComentarios.Comentario, tblComentarios.IDProduto, tblComentariosFamilias.IDFamilia, tblComentariosLojas.IDLoja, tblComentarios.IDComentario "
            strSQL += "From tblComentarios INNER Join tblComentariosFamilias On tblComentarios.IDComentario = tblComentariosFamilias.IDComentario INNER Join tblComentariosLojas On tblComentarios.IDComentario = tblComentariosLojas.IDComentario "
            strSQL += "Where (tblComentariosLojas.IDLoja = " & IDLoja & ") "
            strSQL += "Order By tblComentarios.Comentario, tblComentariosFamilias.IDFamilia"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblComentarios_Local "
                    strSQL += "(IDComentario,IDProduto,IDFamilia,Comentario) VALUES ("
                    strSQL += NuloInteger(drT.Item("IDComentario")) & ", "
                    strSQL += NuloInteger(drT.Item("IDProduto")) & ", "
                    strSQL += NuloInteger(drT.Item("IDFamilia")) & ", "
                    strSQL += "'" & Trim(NuloString(drT.Item("Comentario"))) & "')"
                    ExecutaStr(strSQL)
                End While
            End If

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()
        End If


        ' tblCategorias ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Categorias" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblCategorias_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select IDCategoria, Categoria, CorBotao From tblCategorias Order By IDCategoria"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblCategorias_Local "
                    strSQL += "(IDCategoria,CorBotao,Categoria) VALUES ("
                    strSQL += NuloInteger(drT.Item("IDCategoria")) & ", "
                    strSQL += NuloInteger(drT.Item("CorBotao")) & ", "
                    strSQL += "'" & NuloString(Trim(drT.Item("Categoria"))) & "')"
                    ExecutaStr(strSQL)
                End While
            End If

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()
        End If


        ' tblFamilias ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Familias" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblFamilias_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select IDFamilia, Familia From tblFamilias Order By IDFamilia"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblFamilias_Local "
                    strSQL += "(IDFamilia,Familia) VALUES ("
                    strSQL += NuloInteger(drT.Item("IDFamilia")) & ", "
                    strSQL += "'" & Trim(NuloString(drT.Item("Familia"))) & "')"
                    ExecutaStr(strSQL)
                End While
            End If

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()
        End If


        ' tblCombos ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Combos" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblCombos_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select tblCombos.IDCombo, tblCombos.IDLojaProduto, tblCombosDescricao.IDFamilia, tblProdutosLojas.IDProduto, tblCombos.AgregaValor, tblCombosDescricao.IDComboFamilias, tblProdutosLojas.IDLoja "
            strSQL += "From tblCombos INNER Join tblCombosDescricao On tblCombos.IDCombo = tblCombosDescricao.IDCombo INNER Join tblProdutosLojas On tblCombos.IDLojaProduto = tblProdutosLojas.IDLojaProduto "
            strSQL += "Where (tblProdutosLojas.IDLoja = " & IDLoja & ") "
            strSQL += "Order By tblCombos.IDCombo, tblCombos.IDLojaProduto"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblCombos_Local "
                    strSQL += "(IDCombo,IDProduto,IDFamilia,Sequencia,AgregaValor) VALUES ("
                    strSQL += NuloInteger(drT.Item("IDCombo")) & ", "
                    strSQL += NuloInteger(drT.Item("IDProduto")) & ", "
                    strSQL += NuloInteger(drT.Item("IDFamilia")) & ", "
                    strSQL += NuloInteger(drT.Item("IDComboFamilias")) & ", "
                    If NuloBoolean(drT.Item("AgregaValor")) = False Then
                        strSQL += "0)"
                    Else
                        strSQL += "1)"
                    End If
                    ExecutaStr(strSQL)
                End While
            End If

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()
        End If


        ' tblFormaPagtos ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "FormaPagtos" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblFormaPagtos_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select tblFormaPagtosLojas.CodigoFormaPagto, tblFormaPagtosLojas.CodigoFiscal, tblFormaPagtosLojas.ECartao, tblFormaPagtosLojas.TrocoPadrao, tblFormaPagtosLojas.Tipo, tblFormaPagtosLojas.AcionaGaveta, tblFormaPagtos.Descricao, tblFormaPagtosLojas.IDLoja, tblFormaPagtos.IDFormaPagto, tblFormaPagtosLojas.CodigoSAT, tblFormaPagtosLojas.Taxa, tblFormaPagtosLojas.Periodo, tblFormaPagtosLojas.IDConta, tblFormaPagtosLojas.IDConta_TaxaCartao, tblFormaPagtosLojas.IDConta_ContraPartida, tblFormaPagtosLojas.CodigoExterno, tblFormaPagtosLojas.MostraPedidos, tblFormaPagtosLojas.TEF "
            strSQL += "From tblFormaPagtos INNER Join tblFormaPagtosLojas On tblFormaPagtos.IDFormaPagto = tblFormaPagtosLojas.IDFormaPagto "
            strSQL += "Where (tblFormaPagtosLojas.IDLoja = " & IDLoja & ")"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblFormaPagtos_Local "
                    strSQL += "(CodigoFormaPagto, CodigoFiscal, ECartao, TrocoPadrao, AcionaGaveta, Descricao, IDFormaPagto, Tipo, CodigoSAT, Taxa, Periodo, IDConta, IDConta_TaxaCartao, IDConta_ContraPartida, CodigoExterno, MostraPedidos, TEF) VALUES ("
                    strSQL += NuloInteger(drT.Item("CodigoFormaPagto")) & ", "
                    strSQL += "'" & NuloString(drT.Item("CodigoFiscal")) & "', "
                    If NuloBoolean(drT.Item("ECartao")) = False Then
                        strSQL += "0, "
                    Else
                        strSQL += "1, "
                    End If
                    strSQL += "'" & NuloString(drT.Item("TrocoPadrao")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("AcionaGaveta")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Descricao")) & "', "
                    strSQL += NuloInteger(drT.Item("IDFormaPagto")) & ", "
                    strSQL += "'" & NuloString(drT.Item("Tipo")) & "', "
                    strSQL += NuloString(drT.Item("CodigoSAT")) & ", "
                    strSQL += Replace(NuloDecimal(drT.Item("Taxa")), ",", ".") & ", "
                    strSQL += NuloInteger(drT.Item("Periodo")) & ", "
                    strSQL += NuloInteger(drT.Item("IDConta")) & ", "
                    strSQL += NuloInteger(drT.Item("IDConta_TaxaCartao")) & ", "
                    strSQL += NuloInteger(drT.Item("IDConta_ContraPartida")) & ", "
                    strSQL += "'" & NuloString(drT.Item("CodigoExterno")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("MostraPedidos")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("TEF")) & "')"
                    ExecutaStr(strSQL)
                End While
            End If

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()
        End If


        ' tblProdutos ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Produtos" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblProdutos_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select tblProdutosLojas.IDLoja, tblProdutos.IDProduto, tblProdutosLojas.CodigoProduto, tblProdutosLojas.CodigoGrupo, tblProdutos.Produto, tblProdutosLojas.DescricaoResumida, tblProdutos.CodigoFabricante, tblProdutos.Tipo, tblProdutos.Pizza, tblProdutos.CodigoNCM, tblProdutos.CodigoCEST, tblProdutosLojas.pPIS, tblProdutosLojas.pCOFINS, tblProdutosLojas.CST_COFINS, tblProdutosLojas.CST_ICMS, tblProdutosLojas.CST_PIS, tblProdutosLojas.CFOP, tblProdutosLojas.Categoria, tblProdutosLojas.ImprimeCategoria, tblProdutosLojas.ComServico, tblProdutosLojas.Pesavel, tblProdutosLojas.[Top], tblProdutosLojas.Modulos, tblProdutosLojas.IDFamilia, tblProdutosLojas.Venda, tblProdutosLojas.ForaLinha, tblProdutosLojas.BaixaEstoque, tblAliquotas.Aliquota, tblGrupos.Grupo, tblProdutosLojas.InformaVenda, tblProdutosLojas.Obs, tblProdutosLojas.CategoriaDelivery, tblProdutos.FotoProduto "
            strSQL += "From tblGrupos RIGHT OUTER Join tblAliquotas RIGHT OUTER Join tblProdutos INNER Join tblProdutosLojas On tblProdutos.IDProduto = tblProdutosLojas.IDProduto ON tblAliquotas.IDAliquota = tblProdutosLojas.IDAliquota ON tblGrupos.CodigoGrupo = tblProdutos.CodigoGrupo "
            strSQL += "Where (tblProdutosLojas.IDLoja = " & IDLoja & ") And (tblProdutos.Tipo = 'V' OR tblProdutos.Tipo = 'A')"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblProdutos_Local "
                    strSQL += "(IDProduto,CodigoProduto,CodigoGrupo,Grupo,Produto,DescricaoResumida,CodigoFabricante,Tipo,Pizza,CodigoNCM,CodigoCEST,pPIS,pCOFINS,CST_COFINS,CST_ICMS,CST_PIS,CFOP,Categoria,ImprimeCategoria,ComServico,Pesavel,[Top],Modulos,IDFamilia,Venda,BaixaEstoque,Aliquota,EPizza,InformaVenda,Obs,CategoriaDelivery,ForaLinha,FotoProduto) VALUES ("
                    strSQL += NuloInteger(drT.Item("IDProduto")) & ", "
                    strSQL += NuloInteger(drT.Item("CodigoProduto")) & ", "
                    strSQL += NuloInteger(drT.Item("CodigoGrupo")) & ", "
                    strSQL += "'" & NuloString(drT.Item("Grupo")) & "', "
                    strSQL += "'" & Replace(NuloString(drT.Item("Produto")), "'", " ") & "', "
                    strSQL += "'" & Replace(NuloString(drT.Item("DescricaoResumida")), "'", " ") & "', "
                    strSQL += "'" & NuloString(drT.Item("CodigoFabricante")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Tipo")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Pizza")) & "', "
                    strSQL += "'" & NuloString(drT.Item("CodigoNCM")) & "', "
                    strSQL += "'" & NuloString(drT.Item("CodigoCEST")) & "', "
                    strSQL += Replace(NuloDecimal(drT.Item("pPIS")), ",", ".") & ", "
                    strSQL += Replace(NuloDecimal(drT.Item("pCOFINS")), ",", ".") & ", "
                    strSQL += "'" & NuloString(drT.Item("CST_COFINS")) & "', "
                    strSQL += "'" & NuloString(drT.Item("CST_ICMS")) & "', "
                    strSQL += "'" & NuloString(drT.Item("CST_PIS")) & "', "
                    strSQL += "'" & NuloString(drT.Item("CFOP")) & "', "
                    strSQL += "'" & Trim(NuloString(drT.Item("Categoria"))) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("ImprimeCategoria")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("ComServico")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("Pesavel")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("Top")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Modulos")) & "', "
                    strSQL += NuloInteger(drT.Item("IDFamilia")) & ", "
                    strSQL += Replace(NuloDecimal(drT.Item("Venda")), ",", ".") & ", "
                    strSQL += "'" & NuloBoolean(drT.Item("BaixaEstoque")) & "', "
                    strSQL += Replace(NuloDecimal(drT.Item("Aliquota")), ",", ".") & ", "
                    strSQL += "0, "
                    strSQL += "'" & NuloBoolean(drT.Item("InformaVenda")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Obs")) & "', "
                    strSQL += "'" & NuloString(CategoriaPropriaDelivery) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("ForaLinha")) & "', "
                    strSQL += "'" & NuloString(drT.Item("FotoProduto")) & "')"
                    ExecutaStr(strSQL)
                End While
            End If

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()

            AtualizaTabelaProdutosExterno()

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)


            ' Tablet ////////////////////////////////////////////////////////////////////////////////////////////////////
            Atualiza_Tablet()
        End If


        ' tblFuncionarios ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Funcionarios" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblFuncionarios_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select tblFuncionariosLojas.IDLoja, tblFuncionarios.IDFuncionario, tblFuncionarios.Funcionario, tblFuncionarios.Login, tblFuncionarios.Senha, tblFuncionarios.VisualizaMovto, tblFuncionarios.AbreCaixa, tblFuncionarios.EncerraCaixa, tblFuncionarios.EfetuaEstorno, tblFuncionarios.EfetuaTransferencia, tblFuncionarios.Nivel, tblFuncionariosLojas.CodigoFuncionario, tblFuncoes.Funcao, tblFuncionariosLojas.NaoMostraTerminalVenda, tblFuncionariosLojas.ModulosCaixa "
            strSQL += "From tblFuncionarios INNER Join tblFuncionariosLojas On tblFuncionarios.IDFuncionario = tblFuncionariosLojas.IDFuncionario LEFT OUTER Join tblFuncoes On tblFuncionariosLojas.IDFuncao = tblFuncoes.IDFuncao "
            strSQL += "Where(tblFuncionariosLojas.IDLoja = " & IDLoja & ") Order By tblFuncionarios.Funcionario"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblFuncionarios_Local "
                    strSQL += "(IDFuncionario,Funcionario,Login,Senha,VisualizaMovto,AbreCaixa,EncerraCaixa,EfetuaEstorno,EfetuaTransferencia,Nivel,CodigoFuncionario,Funcao,NaoMostraTerminalVenda,ModulosCaixa) VALUES ("
                    strSQL += NuloInteger(drT.Item("IDFuncionario")) & ", "
                    strSQL += "'" & NuloString(drT.Item("Funcionario")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Login")) & "', "
                    strSQL += "'" & NuloString(drT.Item("Senha")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("VisualizaMovto")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("AbreCaixa")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("EncerraCaixa")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("EfetuaEstorno")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("EfetuaTransferencia")) & "', "
                    strSQL += NuloInteger(drT.Item("Nivel")) & ", "
                    strSQL += NuloInteger(drT.Item("CodigoFuncionario")) & ", "
                    strSQL += "'" & NuloString(drT.Item("Funcao")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("NaoMostraTerminalVenda")) & "',"
                    If NuloString(drT.Item("ModulosCaixa")) = "" Then
                        strSQL += "'T')"
                    Else
                        strSQL += "'" & NuloString(drT.Item("ModulosCaixa")) & "')"
                    End If
                    ExecutaStr(strSQL)
                End While
            End If

            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()

            ' Tablet ////////////////////////////////////////////////////////////
            AtualizaFunc()
        End If


        ' tblGrupos ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Tabela = "Grupos" Then
            Dim connSQL As New SqlConnection(strCon)
            Dim strSQL As String = "TRUNCATE TABLE tblGrupos_Local;"
            Dim commSQL As New SqlCommand(strSQL, connSQL)
            commSQL.CommandType = CommandType.Text
            connSQL.Open()
            commSQL.ExecuteNonQuery()
            connSQL.Close()

            strSQL = "Select tblGrupos.CodigoGrupo, tblGrupos.Grupo, tblGruposLojas.MostraTouch, tblGruposLojas.MostraMovel, tblGruposLojas.EPizza, tblGruposLojas.IDLoja, tblGruposLojas.CorBotao, tblGruposLojas.DescricaoGrupo, tblGruposLojas.Sequencia, tblGruposLojas.MostraAutoServico "
            strSQL += "From tblGrupos INNER Join tblGruposLojas On tblGrupos.CodigoGrupo = tblGruposLojas.CodigoGrupo "
            strSQL += "Where (tblGruposLojas.IDLoja = " & IDLoja & ")"

            Dim conT As New SqlConnection()
            Dim drT As SqlDataReader
            conT.ConnectionString = strConServer
            Dim cmdT As SqlCommand = conT.CreateCommand
            cmdT.CommandText = strSQL
            conT.Open()
            drT = cmdT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drT.HasRows Then
                While (drT.Read())
                    strSQL = "INSERT tblGrupos_Local "
                    strSQL += "(CodigoGrupo, Grupo, MostraTouch, MostraMovel, CorBotao, EPizza, DescricaoResumida, Sequencia, MostraAutoServico) VALUES ("
                    strSQL += NuloInteger(drT.Item("CodigoGrupo")) & ", "
                    strSQL += "'" & NuloString(drT.Item("Grupo")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("MostraTouch")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("MostraMovel")) & "', "
                    strSQL += "'" & NuloInteger(drT.Item("CorBotao")) & "', "
                    strSQL += "'" & NuloBoolean(drT.Item("EPizza")) & "', "
                    strSQL += "'" & NuloString(drT.Item("DescricaoGrupo")) & "', "
                    strSQL += NuloInteger(drT.Item("Sequencia")) & ", "
                    strSQL += "'" & NuloBoolean(drT.Item("MostraAutoServico")) & "') "
                    ExecutaStr(strSQL)
                End While
            End If


            strSQL = "UPDATE tblAtualizaTabelas SET "
            strSQL &= "GourmetVisual=" & to_sqlDATA(Now, "datahora", "R") & " "
            strSQL &= "WHERE (Tabela='" & Tabela & "')"
            ExecutaStrServidor(strSQL)

            drT.Close()
            cmdT.Dispose()
            conT.Dispose()
            conT.Close()

            ' Tablet  /////////////////////////////////////////////////////////////////////////////
            AtualizaGrupo()
        End If
        retorno = True

        Return retorno
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Segundos >= 2 Then
            Inicia()
            Segundos = 0
        Else
            Segundos += 1
        End If

    End Sub

    Private Sub tbFoco_KeyDown(sender As Object, e As KeyEventArgs) Handles tbFoco.KeyDown
        If e.KeyCode = 16 Then
            Timer1.Enabled = False
            Timer1.Stop()
            btnConfig.Visible = True
        End If
    End Sub

    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        frmConfiguracao.ShowDialog()
        IniciaForm()
    End Sub

    Private Sub frmInicio_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim oRAngle As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, Color.ForestGreen, Color.DarkSeaGreen, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

End Class