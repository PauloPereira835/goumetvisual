Option Explicit On
'Option Strict On

Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Xml


Module Codigos

    Public ExistePedidoApp As Boolean = False
    Public VerificaPedidoAppFora As Boolean = True
    Public isDebug As Boolean = True
    Public EGrupoPizza As Boolean
    Public PedidoVenda As Boolean
    Public MesaImpressa As Boolean
    Public ImpEstorno As Boolean
    Public ImpTransferencia As Boolean
    Public GuilhotinaImpCaixa As Boolean
    Public GuilhotinaImpConta As Boolean
    Public ImpRecibo As Boolean
    Public RetornoMsg As Boolean
    Public TerminalVenda As Boolean
    Public TerminalExpedicao As Boolean
    Public VendaBalcaoRecebida As Boolean
    Public RegistroDefinitivo As Boolean
    Public Imprime As Boolean
    Public ObrigaConta As Boolean
    Public DefinicaoReduzida As Boolean = False
    Public conexaIRIS As Boolean = True
    Public FuncaoI As Boolean = True
    Public GavetaCaixa As Boolean
    Public GerenciaSAT As Boolean
    Public PedeMesa As Boolean
    Public GerenciaImpressao As Boolean
    Public GerenciaTable As Boolean
    Public TableAtivo As Boolean
    Public CaixaIndividualizado As Boolean
    Public OperadorEstorna As Boolean = False
    Public OperadorTransfere As Boolean = False
    Public ConfirmaContinua As Boolean = False
    Public OperadorVisualizaVendas As Boolean = False
    Public FixaAbreMesaCartao As Boolean
    Public ValidaCPF_CNPJ As Boolean
    Public AgregaValor As Boolean
    Public NaoEncerraVendasAberto As Boolean
    Public AtualizaVendas As Boolean
    Public FixaTelaPedidos As Boolean
    Public EnviaEmailFechamento As Boolean
    Public InformaClienteBalcao As Boolean
    Public ImpressoraCaixaTexto As Boolean
    Public ImprimeConferenciaBalcao As Boolean
    Public TodosRelatorios As Boolean
    Public Autorizado As Boolean
    Public IncluiFundoCaixa As Boolean
    Public TerminalNaoCobraServico As Boolean
    Public RegistraLog As Boolean
    Public PedidoDeliveryProgramado As Boolean = False
    Public GerenciaPedidoProgramado As Boolean
    Public ExpedicaoPadrao As Boolean
    Public MostraComentExpedicao As Boolean
    Public Acrescimo_W21 As Boolean
    Public NaoMostraProdutosZeroConta As Boolean
    Public TocaCampainhaApp As Boolean
    Public BloqueaMesaAposConta As Boolean
    Public VerificaPagtosDigitais As Boolean
    Public ImprimeConsumo As Boolean
    Public QtdePessoasBalcao As Boolean
    Public ReimprimeComanda As Boolean
    Public FechamentoDeliveryCamelo As Boolean
    Public ImprimeExpandido As Boolean
    Public CameloTambore As Boolean
    Public EnviaEmailNFCE As Boolean
    Public Pos_Controle As Boolean

    Public EndBcoDados As String
    Public DTSource As String
    Public Usuario As String
    Public nome_arquivo_ini As String = Application.StartupPath & "\GV.INI"
    Public nome_arquivo_ini_NFCE As String = Application.StartupPath & "\nfceconfig.INI"
    Public SenhaCon As String
    Public ProdutoSel As String
    Public FamiliaSel As String
    Public ImpConta As String
    Public ImpCaixa As String
    Public Operador As String
    Public strSql As String
    Public Caixa As String
    Public StatusVenda As String
    Public GarconInicial As String
    Public DiaMovto As String
    Public Grupo As String
    Public Categoria As String
    Public Modulo As String
    Public SqlStr As String
    Public NomeTerminal As String
    Public TextoMesaPAR As String
    Public ModoFiscal As String
    Public CNPJSotwareHouse As String
    Public EndBcoDadosIRIS As String
    Public DTSourceIRIS As String
    Public UsuarioIRIS As String
    Public SenhaIRIS As String
    Public strConIRIS As String
    Public ModulosIRIS As String
    Public NumeroHD As String
    Public Versao As String
    Public Cliente As String
    Public loja As String
    Public FormatoDataIRIS As String
    Public FormatoDataLocal As String
    Public FormatoDataRET As String
    Public NomeRep As String
    Public NomeFanRep As String
    Public TelefoneRep As String
    Public ContatoRep As String
    Public EmailRep As String
    Public TextoMsg As String
    Public MesaCartao As String = ""
    Public PortaBalanca As String
    Public DDD_Padrao As String = ""
    Public CidadeLoja As String
    Public EstadoLoja As String
    Public NomeLogradouro As String
    Public NomeCEP As String
    Public NomeIDRua As String
    Public NomeBairro As String
    Public NomeArea As String
    Public NomeTaxaEntrega As String
    Public EntregadorVenda As String
    Public NomeLoja As String
    Public NomeEmpresa As String
    Public FuncionarioAutorizado As String
    Public ImpressoraExpedicao As String
    Public RetornoPendenciaInclusaoIDCliente As String
    Public RetornoPendenciaInclusaoIDPendencia As String
    Public RetornoPendenciaInclusaoCliente As String
    Public CEPLoja As String
    Public EnderecoLoja As String
    Public BairroLoja As String
    Public TelefoneLoja As String
    Public strCon As String = PegaStringConexao()
    Public strConServer As String
    Public TextoServicoCupom As String
    Public RelatFechamento As String
    Public Client_ID_Rappi As String
    Public Grant_Type_Rappi As String
    Public Audience_Rappi As String
    Public IDLoja_Rappi As String
    Public Client_Secret_Rappi As String
    Public CategoriaPropriaDelivery As String
    Public ToqueApp As String
    Public AccessKey_Shipay As String
    Public SecretKey_Shipay As String
    Public access_token_Shipay As String
    Public ClientID_Shipay As String
    Public Foco As String
    Public MediaQtdeVdas As String
    Public Clube As String
    Public CertificadoNFCE As String
    Public EstadoNFCE As String
    Public CnpjNFCE As String
    Public NomeNFCE As String
    Public FantasiaNFCE As String
    Public EnderecoNFCE As String
    Public NumeroNFCE As String
    Public ComplementoNFCE As String
    Public NumeroMunicipioNFCE As String
    Public MunicipioNFCE As String
    Public CepNFCE As String
    Public NumeroPaisNFCE As String
    Public PaisNFCE As String
    Public InscricaoEstadualNFCE As String
    Public BairroNFCE As String
    Public VersaoNFCE As String
    Public IDVendaD As String
    Public EmailNFCE As String
    Public DiaNFCE As String
    Public UserName_PosControle As String
    Public Senha_PosControle As String
    Public Token_PosControle

    Public IDFamiliaSel As Integer
    Public IDGarcon As Integer
    Public IDOperador As Integer
    Public NumMesa As Integer
    Public QtdPessoas As Integer
    Public CodCategoriaSel As Integer
    Public CodProdutoSel As Integer
    Public IDProdutoSel As Integer
    Public IDGridSel As Integer
    Public IDCliente As Integer
    Public IDLoja As Integer
    Public IDFami As Integer
    Public Linha_Grid As Integer
    Public IDFechamento As Integer = 0
    Public IDCaixa As Integer
    Public IDVenda As Integer = 0
    Public IDCombo As Integer
    Public IDGrupo As Integer
    Public TempoLimitePedidosMesa As Integer
    Public TempoLimitePedidosMesaEmEspera As Integer
    Public EquipamentoSAT As Integer
    Public EquipamentoIRIS As Integer
    Public DiasUso As Integer
    Public IDTerminal As Integer
    Public intX As Integer
    Public intY As Integer
    Public IDsVendas(50) As Integer
    Public QtdeVendas As Integer = 0
    Public NivelFuncionario As Integer
    Public TempoLimite As Integer
    Public CodigoProdutoBusca As Integer
    Public NumVenda As Integer
    Public NumVendaD As Integer
    Public IDMovtoGV As Integer
    Public SetorBalcao As Integer
    Public SetorDelivery As Integer
    Public QtdeImpressaoExpedicao As Integer
    Public IDFuncionarioAutorizado As Integer
    Public AtualizaVendasOnLine As Integer
    Public IDClienteMaisTelefones As Integer
    Public CodProIni As Integer
    Public IDFormaPagtoDefaultIfood As Integer
    Public ContadorClube As Integer

    Public IDPedido As Long
    Public IDPedidoPocket As Long

    Public PercDesconto As Decimal
    Public PercServico As Decimal
    Public PercServicoPAR As Decimal
    Public VlrUnitario As Decimal
    Public PesoPego As Decimal
    Public FatorAjusteServico As Decimal

    Public DataLiberado As DateTime
    Public DataTokenPosControle As DateTime
    Function ReduzDefenicao_Delivery()
        frmDelivery.Size = New System.Drawing.Size(1320, 800)

        Dim myfont As New Font("Sans Serif", 9, FontStyle.Regular)
        frmDelivery.tcPedidos.Size = New System.Drawing.Size(785, 709)

        frmDelivery.btnQtde.Size = New System.Drawing.Size(179, 42)
        frmDelivery.btnLimpaProduto.Size = New System.Drawing.Size(179, 42)
        frmDelivery.btnComent.Size = New System.Drawing.Size(179, 42)
        frmDelivery.btnConfirma.Size = New System.Drawing.Size(179, 42)
        frmDelivery.Panel8.Size = New System.Drawing.Size(370, 163)
        frmDelivery.Panel9.Size = New System.Drawing.Size(370, 77)
        frmDelivery.Panel6.Size = New System.Drawing.Size(1310, 26)
        frmDelivery.tbComentExpedicao.Size = New System.Drawing.Size(260, 22)
        frmDelivery.tbComentProducao.Size = New System.Drawing.Size(260, 22)
        frmDelivery.lstPedidos.Size = New System.Drawing.Size(771, 539)

        frmDelivery.lstPedidos.Font = myfont

        frmDelivery.PanelPedidoProg.Location = New Point(270, 5)
        frmDelivery.chkTipoLancto.Location = New Point(302, 101)
        frmDelivery.Label3.Location = New Point(246, 96)
        frmDelivery.Label48.Location = New Point(244, 117)
        frmDelivery.tbCpfCnpj.Location = New Point(242, 132)
        frmDelivery.btnVolta.Location = New Point(1251, 3)
        frmDelivery.btnApp.Location = New Point(1181, 3)
        frmDelivery.Button10.Location = New Point(1111, 3)
        frmDelivery.Button7.Location = New Point(1042, 3)
        frmDelivery.PanelModulos.Location = New Point(905, 1)
        frmDelivery.lbCaracExp.Location = New Point(325, 49)
        frmDelivery.lbCaracProd.Location = New Point(325, 23)

    End Function
    Public Sub ImpressaoConsumo(IDvda As Integer)

        If IDVenda = 0 Then Exit Sub

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim VlrProTxt As String
        Dim VlrSerTxt As String
        Dim VlrDescTxt As String
        Dim NomeCli As String
        Dim SerTxt As String
        Dim IDvdaCombo As Integer
        con.ConnectionString = strCon
1:

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente, tblVendasMovto.IDVendaMovto "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente, tblVendasMovto.IDVendaMovto "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        If NaoMostraProdutosZeroConta = True Then
            strSql += "And (tblVendasMovto.Venda <> 0) "
        End If
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"


        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")


        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))


        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            NomeCli = NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente"))

            PrintLine(lngFile, " CARTAO  " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumMesa")))
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, Chr(27) + Chr(14) & NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")) & Chr(27) + Chr(14))
            PrintLine(lngFile, "------------------------------------------")

            texto = "Controle interno sem valor fiscal"
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Descricao          Qtde.   Unit.    Total ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1
                texto = Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")))
                If Len(texto) <= 18 Then
                    texto = texto & Space(18 - Len(texto))
                Else
                    texto = Strings.Left(texto, 18)
                End If

                If Int(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))) = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) Then
                    texto &= Space(6 - Len(NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde"))))) & NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde")))
                Else
                    texto &= " " & NuloString(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                End If
                texto &= Space(8 - Len(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")))) & NuloString(ds.Tables("Vendas").Rows(i).Item("Venda"))

                Valor = Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")), "#0.00")

                texto &= Space(10 - Len(NuloString(Valor))) & NuloString(Valor)
                PrintLine(lngFile, texto)

                VlrPro += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                VlrSer += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))

                If NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" Then
                    IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                    texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                    PrintLine(lngFile, texto)
                    i += 1
                    If i <= ds.Tables("Vendas").Rows.Count - 1 Then

                        Do While NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" And IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                            texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                            PrintLine(lngFile, texto)
                            i += 1
                            If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                        Loop

                    End If
                Else
                    i += 1
                End If
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, "==========================================")
            VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")
            PrintLine(lngFile, "Sub-total " & Space(32 - Len(VlrProTxt)) & VlrProTxt)

            SerTxt = Format(NuloDecimal(VlrSer) - NuloDecimal(VlrPro), "#0.00")
            If Len(TextoServico) > 25 Then
                texto = TextoServico & Space(5 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            Else
                texto = TextoServico & Space(25 - Len(NuloString(TextoServico))) & Space(17 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            End If

            If NuloDecimal(SerTxt) > 0 Then
                PrintLine(lngFile, texto)
            End If

            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) > 0 Then
                Dim vlrDesc As Decimal = NuloDecimal(SemArredondar(VlrPro * (NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) / 100), 3))
                VlrDescTxt = Format(NuloDecimal(vlrDesc), "#0.00")

                VlrSer = VlrSer - vlrDesc
                texto = "Desconto  " & Space(32 - Len(VlrDescTxt)) & VlrDescTxt
                PrintLine(lngFile, texto)
            End If

            PrintLine(lngFile, "                              ------------")
            VlrSerTxt = Format(NuloDecimal(VlrSer), "#0.00")
            If ImpressoraCaixaTexto = True Then
                PrintLine(lngFile, "TOTAL" & Space(37 - Len(VlrSerTxt)) & VlrSerTxt)
            Else
                PrintLine(lngFile, Chr(27) + Chr(14) & "TOTAL" & Space(16 - Len(VlrSerTxt)) & VlrSerTxt & Chr(27) + Chr(14))
            End If
            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
            If GuilhotinaImpCaixa = False Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
        Next
        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()



        'verifica se o nome do arquivo foi informado
        Dim caminho As String = Application.StartupPath & "\Impressao\conta.txt"
        'verifica se o arquivo existe
        If File.Exists(caminho) Then
            Using tr As TextReader = New StreamReader(caminho)
                '                tbConta.Text = tr.ReadToEnd()
            End Using
        Else
            MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\conta.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If


    End Sub
    Public Sub ApagaVendas()

        strSql = "Select IDVenda, IDfechamento, FlagFechada "
        strSql += "From tblVendas "
        strSql += "Where (FlagFechada = 1)"

        Dim IDvda As Integer
        Dim IDmovto As Integer
        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "vda")
        For i As Integer = 0 To ds.Tables("vda").Rows.Count - 1
            IDvda = ds.Tables("vda").Rows(i).Item("IDVenda")

            strSql = "Delete From tblVendasComent WHERE IDVenda=" & IDvda
            ExecutaStr(strSql)

            strSql = "Select IDVendaMovto, IDVenda "
            strSql += "From tblVendasCombo "
            strSql += "Where (IDVenda = " & IDvda & ")"
            Dim dap1 = New SqlDataAdapter(strSql, strCon)
            dap1.SelectCommand.CommandType = CommandType.Text
            Dim ds1 As New DataSet()
            dap1.Fill(ds1, "combo")
            For ii As Integer = 0 To ds1.Tables("combo").Rows.Count - 1
                IDmovto = ds1.Tables("combo").Rows(ii).Item("IDVendaMovto")

                strSql = "Delete From tblVendasCombo WHERE IDVendaMovto=" & IDmovto
                ExecutaStr(strSql)

                strSql = "Delete From tblVendasComent WHERE IDVendaMovto=" & IDmovto
                ExecutaStr(strSql)
            Next
            strSql = "Delete From tblVendasMovto WHERE IDVenda=" & IDvda
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasPagto WHERE IDVenda=" & IDvda
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasSAT WHERE IDVenda=" & IDvda
            ExecutaStr(strSql)

            strSql = "Delete From tblVendas WHERE IDVenda=" & IDvda
            ExecutaStr(strSql)
        Next
    End Sub
    Public Sub VerificaMesas()

        strSql = "Select NumMesa, Flag "
        strSql += "From tblMesas "
        strSql += "Where (Flag = 1)"

        Dim IDVda As String
        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "vda")
        For i As Integer = 0 To ds.Tables("vda").Rows.Count - 1
            strSql = "Select IDVenda, FlagFechada, NumMesa "
            strSql += "From tblVendas "
            strSql += "Where (FlagFechada = 0) And (NumMesa = " & ds.Tables("vda").Rows(i).Item("NumMesa") & ")"
            IDVda = NuloString(PegaValorCampo("IDVenda", strSql, strCon))
            If IDVda = "" Or IDVda = "ERRO" Then

                strSql = "UPDATE tblMesas SET Flag = 0 WHERE NumMesa = " & ds.Tables("vda").Rows(i).Item("NumMesa")
                ExecutaStr(strSql)

            End If

        Next
    End Sub
    Public Sub ImprimeQRcode(IDVdaPagto As Integer)

        strSql = "Select tblVendasPagto.IDPagtoDigital, tblVendasPagto.StatusDigital, tblVendasPagto.Terminal, tblVendasPagto.IDVendaPagto, tblVendasPagto.QRcode, tblVendas.NumMesa, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblVendas.StatusVenda "
        strSql += "From tblVendasPagto INNER Join tblVendas On tblVendasPagto.IDVenda = tblVendas.IDVenda "
        strSql += "Where (tblVendasPagto.IDVendaPagto = " & IDVdaPagto & ")"

        Dim Texto As String
        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "vda")
        If ds.Tables("vda").Rows.Count > 0 Then
            Dim Resposta
            strSql = "Select Terminal, ClientID, ImpressoraPagtoDigital, Status, PortaImpressora From tblTerminaisPagtoDigital WHERE Terminal='" & NuloString(ds.Tables("vda").Rows(0).Item("Terminal")) & "'"
            Dim TipoImp As String = NuloString(PegaValorCampo("ImpressoraPagtoDigital", strSql, strCon))
            If TipoImp = "BEMATECH" Then
                Resposta = IniciaPorta(NuloString(PegaValorCampo("PortaImpressora", strSql, strCon)))
                If Resposta <= 0 Then
                    MsgBox("Problemas ao abrir a porta (" & NuloString(PegaValorCampo("PortaImpressora", strSql, strCon)) & ") de Comunicação. Verifique.")
                End If
                Dim comando As String
                comando = PrinterReset()

                Dim errorCorrectionLevel As Integer = 1
                Dim moduleSize As Integer
                If Len(NuloString(ds.Tables("vda").Rows(0).Item("QRcode"))) > 400 Then
                    If Len(NuloString(ds.Tables("vda").Rows(0).Item("QRcode"))) > 1000 Then
                        moduleSize = 2
                    Else
                        moduleSize = 4
                    End If
                Else
                    moduleSize = 7
                End If
                Dim codeType As Integer = 0
                Dim QRCodeVersion As Integer = 10
                Dim encodingModes As Integer = 1
                Dim codeQR As String = NuloString(ds.Tables("vda").Rows(0).Item("QRcode"))

                comando = ImprimeCodigoQRCODE(errorCorrectionLevel, moduleSize, codeType, QRCodeVersion, encodingModes, codeQR)
                If NuloString(ds.Tables("vda").Rows(0).Item("StatusVenda")) = "S" Then
                    Texto = TextoMesaPAR + Space(12 - Len(TextoMesaPAR)) + NuloString(ds.Tables("vda").Rows(0).Item("NumMesa")) + Chr(13) + Chr(10)
                Else
                    Texto = "Venda BALCAO" + Chr(13) + Chr(10)
                End If
                Texto += "Valor       " + Format(NuloDecimal(ds.Tables("vda").Rows(0).Item("ValorPago")), "#0.00") + Chr(13) + Chr(10)
                Texto += "Pagamento   " + NuloString(ds.Tables("vda").Rows(0).Item("Descricao")) + Chr(13) + Chr(10)
                Texto += "www.gourmetvisual.com.br" + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                Texto += " " + Chr(13) + Chr(10)
                comando = BematechTX(Texto)

                Resposta = AcionaGuilhotina(1)

                Resposta = FechaPorta()
            End If

        End If



    End Sub
    Function MonitoraPagtosDigitais(Terminal As String)

        If ClientID_Shipay = "" Then
            strSql = "SELECT Terminal, ClientID, ImpressoraPagtoDigital, Status FROM tblTerminaisPagtoDigital WHERE Terminal = '" & NuloString(NomeTerminal) & "'"
            ClientID_Shipay = NuloString(PegaValorCampo("ClientID", strSql, strCon))
        End If
        If access_token_Shipay = "" Then
            Dim api As New classShipay()
            api.getToken()
        End If

        strSql = "Select tblVendas.NumMesa, tblVendas.NumVenda, tblVendasPagto.IDPagtoDigital, tblVendasPagto.StatusDigital, tblVendasPagto.Terminal, tblVendasPagto.IDVendaPagto, tblVendas.StatusVenda "
        strSql += "From tblVendas INNER Join tblVendasPagto On tblVendas.IDVenda = tblVendasPagto.IDVenda "
        strSql += "Where (tblVendasPagto.Terminal = '" & Terminal & "') AND (tblVendasPagto.StatusDigital = 'pending')"

        Dim c As New classShipay()
        Dim ret
        Dim dapPK = New SqlDataAdapter(strSql, strCon)
        dapPK.SelectCommand.CommandType = CommandType.Text
        Dim dsPK As New DataSet()
        dapPK.Fill(dsPK, "vda")
        For i As Integer = 0 To dsPK.Tables("vda").Rows.Count - 1
            ret = c.getStatus(dsPK.Tables("vda").Rows(i).Item("IDPagtoDigital"))
            If ret.statusResponse.Status = "approved" Then

                strSql = "UPDATE tblVendasPagto SET StatusDigital='approved' WHERE IDVendaPagto=" & dsPK.Tables("vda").Rows(i).Item("IDVendaPagto")
                ExecutaStr(strSql)

                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                If dsPK.Tables("vda").Rows(i).Item("StatusVenda") = "S" Then
                    frm.lbMensagem.Text = "Pagamento Aprovado !!!" & vbCrLf & "Venda SALÃO" & vbCrLf & TextoMesaPAR & " " & dsPK.Tables("vda").Rows(i).Item("NumMesa")
                Else
                    frm.lbMensagem.Text = "Pagamento Aprovado !!!" & vbCrLf & "Venda BALCÃO" & vbCrLf & "Venda " & dsPK.Tables("vda").Rows(i).Item("NumVenda")
                End If
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            End If
        Next


    End Function
    Function InserirPagtoVendaApp(IDVenda As String, IDFormaPagto As Integer, Descricao As String, Valor As Decimal, Ecartao As Boolean, TaxaCartao As Decimal, TipoPagto As String, Tipo As Integer) As Boolean

        Dim Executado As Boolean = False
        If Tipo = 0 Then
            strSql = "INSERT tblVendasPagto "
            strSql += "(IDVenda, IDFormaPagto, Descricao, ValorPago, ECartao, TaxaCartao, Tipo, Cupom) VALUES ("
        Else
            strSql = "INSERT tblAppVendasPagto "
            strSql += "(IDVendaExterna, IDFormaPagto, Descricao, ValorPago, ECartao, TaxaCartao, Tipo, Cupom) VALUES ("
        End If
        strSql += to_sql(IDVenda) & ","
        strSql += to_sql(IDFormaPagto) & ","
        strSql += to_sql(Descricao) & ","
        strSql += to_sql(Replace(Valor.ToString, ",", ".")) & ","
        strSql += to_sql(Ecartao) & ","
        strSql += to_sql(Replace(TaxaCartao.ToString, ",", ".")) & ","
        strSql += to_sql(TipoPagto) & ", 0)"
        ExecutaStr(strSql)

        Return Executado

    End Function
    Function IncluiComentarioApp(IDvdaExterna As String, IDMovto As Integer, IDCombo As Integer, Coment As String, IDProdVinc As Integer, CodProEx As String) As String

        Dim conComent As New SqlConnection(strCon)
        strSql = "INSERT tblAppVendasComent (IDVendaExterna,IDAppVendaMovto,IDAppVendaCombo,Coment,IDProdutoVinculado,CodigoProdutoExterno) VALUES ("
        strSql &= to_sql(IDvdaExterna) & ","
        strSql &= to_sql(IDMovto) & ","
        strSql &= to_sql(IDCombo) & ","
        strSql &= to_sql(VerificaTexto(Strings.Left(NuloString(Coment), 250))) & ","
        strSql &= to_sql(IDProdVinc) & ","
        strSql &= to_sql(Strings.Left(NuloString(CodProEx), 100)) & ")"
        ExecutaStr(strSql)

        Return strSql
    End Function
    Function InserirItemVendaApp(IDVenda As String, IDProduto As Integer, Produto As String, Quanti As Decimal, Enviado As Boolean, Venda As Decimal, VendaServico As Decimal, Categoria As String, HoraPedido As DateTime, IDFuncionario As Integer, Atendente As String, IDGrupo As Integer, Grupo As String, Excluido As Boolean, Motiv As String, Impr As Boolean, StTransf As String, Termi As String, NImpr As Boolean, SetImpr As Integer, ComServico As Boolean, Tipo As Integer, CodProExterno As String) As Boolean
        Dim Executado As Boolean = False
        If Tipo = 0 Then
            strSql = "INSERT tblVendasMovto "
            strSql += "(IDVenda,IDProduto,Produto,Qtd,Enviado,Venda,VendaServico,Categoria,HoraPedido,IDFuncionario,Atendente,IDGrupo,Grupo,Excluido,MotivoEstorno,Impresso,StatusTransf,Terminal,Imprime,SetorImpressao,MesaCartao,ComServico,EmEspera) VALUES ("
        Else
            strSql = "INSERT tblAppVendasMovto "
            strSql += "(IDVendaExterna,IDProduto,Produto,Qtd,Enviado,Venda,VendaServico,Categoria,HoraPedido,IDFuncionario,Atendente,IDGrupo,Grupo,Excluido,MotivoEstorno,Impresso,StatusTransf,Terminal,Imprime,SetorImpressao,MesaCartao,ComServico,EmEspera,CodigoProdutoExterno) VALUES ("
        End If
        strSql += to_sql(IDVenda) & ","
        strSql += to_sql(IDProduto) & ","
        strSql += to_sql(Produto) & ","
        strSql += to_sql(Replace(Quanti.ToString, ",", ".")) & ","
        strSql += to_sql(Enviado) & ","
        strSql += to_sql(Replace(Venda.ToString, ",", ".")) & ","
        strSql += to_sql(Replace(VendaServico.ToString, ",", ".")) & ","
        strSql += to_sql(Categoria) & ","
        strSql += to_sql(HoraPedido.ToString) & ","
        strSql += to_sql(IDFuncionario) & ","
        strSql += to_sql(Atendente) & ","
        strSql += to_sql(IDGrupo) & ","
        strSql += to_sql(Grupo) & ","
        strSql += to_sql(Excluido) & ","
        strSql += to_sql(Motiv) & ","
        strSql += "0,"
        strSql += to_sql(StTransf) & ","
        strSql += to_sql(Termi) & ","
        strSql += to_sql(NImpr) & ","
        strSql += to_sql(SetImpr) & ","
        strSql += to_sql("") & ","
        strSql += to_sql(ComServico) & ","
        If Tipo = 0 Then
            strSql += "0)"
        Else
            strSql += "0,"
            strSql += to_sql(CodProExterno) & ")"
        End If
        ExecutaStr(strSql)

        Return Executado

    End Function
    Function InserirItemComboVendaApp(IDVendaMovto As Integer, IDVenda As String, IDProduto As Integer, Produto As String, Quanti As Decimal, Venda As Decimal, VendaServico As Decimal, idGrupo As Integer, Grup As String, Categoria As String, Agrega As Boolean, Tipo As Integer, CodProExterno As String) As Boolean

        Dim Executado As Boolean = False
        If Tipo = 0 Then
            strSql = "INSERT tblVendasCombo "
            strSql += "(IDVendaMovto,IDVenda,IDProduto,Produto,Qtd,Venda,VendaServico,IDGrupo,Grupo,Categoria,AgregaValor) VALUES ("
        Else
            strSql = "INSERT tblAppVendasCombo "
            strSql += "(IDAppVendaMovto,IDVendaExterna,IDProduto,Produto,Qtd,Venda,VendaServico,IDGrupo,Grupo,Categoria,AgregaValor,CodigoProdutoExterno) VALUES ("
        End If
        strSql += to_sql(IDVendaMovto) & ","
        strSql += to_sql(IDVenda) & ","
        strSql += to_sql(IDProduto) & ","
        strSql += to_sql(Produto) & ","
        strSql += to_sql(Replace(Quanti.ToString, ",", ".")) & ","
        strSql += to_sql(Replace(Venda.ToString, ",", ".")) & ","
        strSql += to_sql(Replace(VendaServico.ToString, ",", ".")) & ","
        strSql += to_sql(idGrupo) & ","
        strSql += to_sql(Grup) & ","
        strSql += to_sql(Categoria) & ","
        If Tipo = 0 Then
            strSql += to_sql(Agrega) & ")"
        Else
            strSql += to_sql(Agrega) & ","
            strSql += to_sql(CodProExterno) & ")"
        End If
        ExecutaStr(strSql)

        Return Executado

    End Function
    Private Sub resolveEndereco(CEP As String, nomeRua As String, Bairro_ As String, CEP_ As String, Refere As String, Comple As String, City As String, State As String, txEntrega As Decimal)

        strSql = "SELECT IDRuaCEP, IDRua, CEP  FROM tblRuasCEP WHERE (CEP='" & CEP & "')"
        IDRuaApp = NuloInteger(PegaValorCampo("IDRua", strSql, strCon))
        Dim Area As String = ""
        If IDRuaApp = 0 Then

            strSql = "SELECT IDArea, Area, TaxaEntrega FROM tblAreas WHERE (TaxaEntrega=" & Replace(txEntrega, ",", ".") & ")"
            Area = NuloString(PegaValorCampo("Area", strSql, strCon))

            strSql = "Insert tblRuas "
            strSql &= "(Logradouro, Bairro, Cidade, Estado, Area) Values ("
            strSql &= to_sql(nomeRua) & ", "
            strSql &= to_sql(Bairro_) & ", "
            strSql &= to_sql(VerificaTexto(City)) & ", "
            strSql &= to_sql(State) & ", "
            strSql &= to_sql(Area) & ")"
            ExecutaStr(strSql)
            IDRuaApp = NuloInteger(PegaID("IDRua", "tblRuas", "L"))

            strSql = "Insert tblRuasCEP "
            strSql &= "(IDRua, CEP) Values ("
            strSql &= to_sql(IDRuaApp) & ", "
            strSql &= to_sql(CEP_) & ")"
            ExecutaStr(strSql)
        End If

        If Area = "" Then
            strSql = "SELECT IDArea, Area, TaxaEntrega FROM tblAreas WHERE (TaxaEntrega=" & Replace(txEntrega, ",", ".") & ")"
            Area = NuloString(PegaValorCampo("Area", strSql, strCon))
            strSql = "UPDATE tblRuas SET Area='" & Area & "' WHERE IDRua=" & IDRuaApp
            ExecutaStr(strSql)
        End If
        AreaEntregaApp = Area

    End Sub
    Public Sub resolveCliente(NomeCli As String, Tel As String, Email As String, nomeRua As String, numRua As String, Bairro_ As String, CEP_ As String, Refere As String, Comple As String, City As String, State As String, txEntrega As Decimal, app As String, IDext As String)
        IDClienteApp = 0
        IDRuaApp = 0

        NumeroLograApp = NuloString(numRua)
        BairroApp = NuloString(Bairro_)
        CEPApp = NuloString(Replace(CEP_, "-", ""))
        ReferenciaApp = NuloString(Refere)
        ComplementoApp = NuloString(Comple)
        CidadeApp = NuloString(City)
        EstadoApp = NuloString(State)
        LogradouroApp = NuloString(nomeRua)
        DDDApp = ""

        If app = "IFOOD" Then
            Tel = Replace(Strings.Left(Tel, 13), " ", "")
        Else
            If Len(Tel) >= 11 Then
                DDDApp = Strings.Left(Tel, 2)
                Tel = Trim(Strings.Right(Tel, Len(Tel) - 2))
            End If
        End If

        If IDext <> "" Then
            strSql = "SELECT IDCliente, NomeCliente, Tel1, DDD1, IDExterno FROM tblClientes WHERE (IDExterno='" & IDext & "')"
            IDClienteApp = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If IDClienteApp = 0 Then
            strSql = "SELECT IDCliente, NomeCliente, Tel1, DDD1, IDExterno FROM tblClientes WHERE (DDD1='" & DDDApp & "') And (Tel1='" & Tel & "')"
            IDClienteApp = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
            If IDClienteApp = 0 Then
                strSql = "SELECT IDCliente, NomeCliente, Tel1, DDD1, IDExterno FROM tblClientes WHERE (Tel1='" & Tel & "')"
                IDClienteApp = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
            End If
        End If


        If IDClienteApp <> 0 Then
            Dim DDD1 As String
            DDD1 = NuloString(PegaValorCampo("DDD1", strSql, strCon))
            If DDDApp <> DDD1 Then IDClienteApp = 0
        End If

        Tel1App = Tel
        NomeClienteapp = NomeCli
        e_mailapp = Email

        resolveEndereco(CEPApp, LogradouroApp, BairroApp, CEPApp, ReferenciaApp, ComplementoApp, CidadeApp, EstadoApp, txEntrega)

        If IDClienteApp = 0 Then
            strSql = "Insert tblClientes "
            strSql &= "(NomeCliente, Numero, Complemento, Referencia, Cidade, Estado, Tel1, Origem, DataCadastro, StatusCliente, DataAtualizacao, Responsavel, DDD1, IDRua, IDLoja, Atualiza, IDExterno, Email) Values ("
            strSql &= "'" & NomeClienteApp & "', "
            strSql &= "'" & NumeroLograApp & "', "
            strSql &= "'" & ComplementoApp & "', "
            strSql &= "'" & ReferenciaApp & "', "
            strSql &= "'" & CidadeApp & "', "
            strSql &= "'" & EstadoApp & "', "
            strSql &= "'" & Tel1App & "', "
            strSql &= "'APP', "
            strSql &= "'" & Now & "', "
            strSql &= "'A', "
            strSql &= "'" & Now & "', "
            strSql &= "'" & app & "', "
            strSql &= "'" & DDDApp & "', "
            strSql &= IDRuaApp & ", "
            strSql &= IDLoja & ", "
            strSql &= "1, "
            strSql &= "'" & IDext & "', "
            strSql &= "'" & Email & "')"
            ExecutaStr(strSql)
            IDClienteApp = NuloInteger(PegaID("IDCliente", "tblClientes", "L"))
        Else
            strSql = "UPDATE tblClientes SET "
            strSql += "NomeCliente='" & NomeClienteApp & "', "
            strSql += "Numero='" & NumeroLograApp & "', "
            strSql += "Complemento='" & ComplementoApp & "', "
            strSql += "Referencia='" & ReferenciaApp & "', "
            strSql += "Cidade='" & CidadeApp & "', "
            strSql += "Estado='" & EstadoApp & "', "
            strSql += "Tel1='" & Tel1App & "', "
            strSql += "DDD1='" & DDDApp & "', "
            strSql += "IDRua=" & IDRuaApp & ", "
            strSql += "IDLoja=" & IDLoja & ", "
            strSql += "Atualiza=1 "
            strSql += "WHERE (IDCliente=" & IDClienteApp & ")"
            ExecutaStr(strSql)
        End If

    End Sub
    Public Sub MonitorContaTablet()
        Dim NMesa As Integer

        strSql = "Select mesa, IDfuncionario, Qtd_Pessoas, imprimir, fechamesa, MesaAberta, IDPedido, TravaMesa, modulo, Mesa_Cartao, FecharMesa "
        strSql += "From tb_Pocket_Pedido "
        strSql += "Where (FecharMesa = 1)"

        Dim dapPK = New SqlDataAdapter(strSql, strCon)
        dapPK.SelectCommand.CommandType = CommandType.Text
        Dim dsPK As New DataSet()
        dapPK.Fill(dsPK, "VendasPK")
        For i As Integer = 0 To dsPK.Tables("VendasPK").Rows.Count - 1
            'frmPrincipal.TimerVerImpressao.Stop()
            Dim QtdePessoas As Integer = NuloInteger(dsPK.Tables("VendasPK").Rows(i).Item("Qtd_Pessoas"))
            If QtdePessoas = 0 Then QtdePessoas = 1

            NMesa = dsPK.Tables("VendasPK").Rows(i).Item("mesa")
            strSql = "SELECT IDVenda, NumMesa, FlagFechada, Excluido FROM tblVendas WHERE (NumMesa = " & NMesa & ") AND (FlagFechada = 0) AND (Excluido = 0)"
            IDVenda = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))

            strSql = "UPDATE tblVendas SET "
            strSql &= "QtdPessoas=" & QtdePessoas & " "
            strSql &= "WHERE (IDVenda=" & IDVenda & ")"
            ExecutaStr(strSql)




            fdlgConta.CriaImpressaoConta(IDVenda)

            strSql = "Select tblMesas.NumMesa, tblSetores.Setor, tblSetores.ImpressoraConta "
            strSql += "From tblMesas INNER Join tblSetores On tblMesas.IDSetor = tblSetores.IDSetor "
            strSql += "Where (tblMesas.NumMesa = " & NuloString(NMesa) & ")"
            ImpCaixa = PegaValorCampo("ImpressoraConta", strSql, strCon)

            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\conta.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If




            strSql = "UPDATE tblMesas SET "
            strSql &= "Impresso=1 "
            strSql &= "WHERE (NumMesa=" & NMesa & ")"
            ExecutaStr(strSql)

            strSql = "UPDATE tb_Pocket_Pedido SET "
            strSql &= "FecharMesa=0 "
            strSql &= "WHERE (mesa=" & NMesa & ")"
            ExecutaStr(strSql)

        Next
        'frmPrincipal.TimerVerImpressao.Start()

        dapPK.Dispose()
        dsPK.Dispose()


    End Sub
    Function AtualizaTabelaProdutosExterno()
        ExecutaStr("TRUNCATE TABLE tblProdutosExterno_Local")

        strSql = "Select * From tblProdutosExterno"

        Dim dap = New SqlDataAdapter(strSql, strConServer)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "prod")
        For i As Integer = 0 To ds.Tables("prod").Rows.Count - 1
            strSql = "INSERT tblProdutosExterno_Local "
            strSql += "(IDProduto, CodigoProduto, IDLoja, Aplicativo, CodigoProdutoExterno) VALUES ("
            strSql += NuloInteger(ds.Tables("prod").Rows(i).Item("IDProduto")) & ", "
            strSql += NuloInteger(ds.Tables("prod").Rows(i).Item("CodigoProduto")) & ", "
            strSql += NuloInteger(ds.Tables("prod").Rows(i).Item("IDLoja")) & ", "
            strSql += "'" & NuloString(ds.Tables("prod").Rows(i).Item("Aplicativo")) & "', "
            strSql += "'" & NuloString(ds.Tables("prod").Rows(i).Item("CodigoProdutoExterno")) & "')"
            ExecutaStr(strSql)
        Next
    End Function
    Public Sub FixBrowser()
        Try
            Dim regDM As Microsoft.Win32.RegistryKey = Nothing
            Dim is64 As Boolean = Environment.Is64BitOperatingSystem
            Dim KeyPath As String = ""
            If is64 Then
                KeyPath = "SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
            Else
                KeyPath = "SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
            End If

            regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, False)
            If regDM Is Nothing Then
                regDM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath)
            End If

            Dim Sleutel As Microsoft.Win32.RegistryKey = Nothing
            If (regDM IsNot Nothing) Then
                Dim location As String = System.Environment.GetCommandLineArgs()(0)
                Dim appName As String = System.IO.Path.GetFileName(location)
                If regDM.GetValue(appName) Is Nothing Then
                    'Sleutel onbekend
                    regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, True)
                    Sleutel = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

                    'What OS are we using
                    Dim OsVersion As Version = System.Environment.OSVersion.Version

                    If OsVersion.Major = 6 And OsVersion.Minor = 1 Then
                        'WIN 7
                        Sleutel.SetValue(appName, 9000, Microsoft.Win32.RegistryValueKind.DWord)
                    ElseIf OsVersion.Major = 6 And OsVersion.Minor = 2 Then
                        'WIN 8
                        Sleutel.SetValue(appName, 10000, Microsoft.Win32.RegistryValueKind.DWord)
                    ElseIf OsVersion.Major = 5 And OsVersion.Minor = 1 Then
                        'WIN xp
                        Sleutel.SetValue(appName, 8000, Microsoft.Win32.RegistryValueKind.DWord)
                    End If

                    Sleutel.Close()
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Ocorreu um erro!", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Function CalcKm(ByVal origem As String, ByVal destino As String)

        Try

            Dim Dados As Hashtable
            Dados = New Hashtable
            'Faz download do xml para posterior leitura
            Dim ChaveGoogle As String = "?key=AIzaSyAhQhE6pqncTtGtsLBx_GY33u8v0KubiiU"

            Dim linkGoogle As String = "https://maps.googleapis.com/maps/api/directions/xml" & ChaveGoogle & "&origin=" & origem & "&destination=" & destino & "&mode=driving&language=pt-BR&sensor=false"
            My.Computer.Network.DownloadFile(linkGoogle, Application.StartupPath & "\busca.xml")
            '-------------------------------------------------------------------------------------------------------------------/
            Dim oXML As New XmlDocument
            oXML.Load(Application.StartupPath & "\busca.xml")
            Dim status As String = oXML.SelectSingleNode("DirectionsResponse").ChildNodes(0).InnerText
            'Verifica o status da busca



            If status = "OK" Then
                Dim distancia As String = oXML.SelectSingleNode("DirectionsResponse/route/leg/distance").ChildNodes(1).InnerText
                Dim tempo As String = oXML.SelectSingleNode("DirectionsResponse/route/leg/duration").ChildNodes(1).InnerText
                'Exibe resultados
                Dados.Add("DISTANCIA", distancia)
                Dados.Add("TEMPO", tempo)
                'ListBox1.Items.Add("Distância entre pontos: " & distancia)
                'ListBox1.Items.Add("Tempo médio a percorrer: " & tempo)
            Else
                'Pesquisa inválida
                'ListBox1.Items.Add("Google retornou pesquisa inválida")
                Dados.Add("DISTANCIA", "NÃO CALCULADO")
                Dados.Add("TEMPO", "NÃO CALCULADO")
            End If
            'Deleta o xml para nova pesquisa
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\busca.xml")

            Return Dados

        Catch ex As Exception

            Return ""

        End Try



    End Function
    Public Function BuscaCEPGoogle(ByVal address1 As String, ByVal city As String, ByVal state As String) As Hashtable

        Dim enderecoXML As String = String.Empty
        Dim codigoCEP As Hashtable

        Try
            Dim ChaveGoogle As String = "?key=AIzaSyAhQhE6pqncTtGtsLBx_GY33u8v0KubiiU"
            'Cria um objeto do tipo web client
            Dim wsClient As New WebClient()

            'Constroi a URL concatenando os valores dos endereços
            Dim codigoCEPurl As String = ChaveGoogle & "&address={0},+{1},+{2}&sensor=false"

            'Aqui na construção da URL , sensor é obrigatório e eindia se a requisição vem de um dispositivo com localização por sensor

            Dim url As String = "https://maps.googleapis.com/maps/api/geocode/xml" & codigoCEPurl

            url = [String].Format(url, address1.Replace(" ", "+"), city.Replace(" ", "+"), state.Replace(" ", "+"))

            'Download os dados no formato XML como uma string
            enderecoXML = wsClient.DownloadString(url)

            codigoCEP = New Hashtable

            'verifica se o status esta OK e inicia o processamento
            If enderecoXML.Contains("OK") Then

                'Verifica se a seção postal_code existe na string e continua
                If enderecoXML.Contains("postal_code") Then
                    Dim CEPencontrado As String = ""
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.LoadXml(enderecoXML)
                    Dim m_nodelist As XmlNodeList

                    'Obtem a lista de todos os endereço dos nós address_companent nodes 
                    m_nodelist = xmlDoc.SelectNodes("/GeocodeResponse/result/address_component")

                    codigoCEP.Add("Status", "1")

                    'Para cada componente verifica a seção type para obter o cep
                    For Each m_node In m_nodelist
                        'Pega o valor do elemento zipLongName
                        Dim zipLongName = m_node.ChildNodes.Item(0).InnerText
                        'Pega o valor do elemento zipShortName
                        Dim zipShortName = m_node.ChildNodes.Item(1).InnerText
                        'Pega o valor do elemento tipo de cep
                        Dim zipType = m_node.ChildNodes.Item(2).InnerText

                        'Se o tipo do componente for postal_code ou postal_code_prefix pega o CEP como zipLongName
                        If zipType = "postal_code_prefix" Or zipType = "postal_code" Then
                            'codigoCEP.Add("CEP", Replace(zipLongName, "-", ""))
                            CEPencontrado = Replace(zipLongName, "-", "")
                        End If
                        If zipType = "route" Then
                            'codigoCEP.Add("Logradouro", UCase(VerificaTexto(zipLongName)))
                        End If
                        If zipType = "political" Or zipType = "administrative_area_level_4" Then
                            'codigoCEP.Add("Bairro", UCase(VerificaTexto(zipLongName)))
                        End If
                    Next
                    If CEPencontrado <> "" Then
                        Dim Resp As System.Collections.Hashtable = BuscaCep(CEPencontrado)
                        If Resp.Values(0).ToString() <> "0" Then
                            codigoCEP.Add("CEP", CEPencontrado)
                            codigoCEP.Add("Logradouro", VerificaTexto(UCase(Resp.Values(1).ToString())) & " " & VerificaTexto(UCase(Resp.Values(0).ToString())))
                            codigoCEP.Add("Bairro", VerificaTexto(UCase(Resp.Values(5).ToString())))
                        Else
                            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                            frm1.lbMensagem.Text = "CEP inválido"
                            frm1.btnNao.Visible = False
                            frm1.btnSim.Visible = False
                            frm1.btnOK.Visible = True
                            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm1.ShowDialog()
                        End If
                    End If

                Else
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Logradouro não encontrado" & vbCrLf & "Tente informar o número do local"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    codigoCEP.Add("Status", "0")
                End If
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Logradouro não encontrado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                codigoCEP.Add("CEP", "0")
            End If
        Catch ex As WebException
            'MessageBox.Show(ex.Message)
        End Try
        Return codigoCEP
    End Function

    Function BuscaCep(ByVal cep As String) As Hashtable
        Dim ds As DataSet
        Dim _resultado As String
        Dim htht As System.Collections.Hashtable
        Try
            ds = New DataSet()
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace("-", "").Trim() + "&formato=xml")
            If Not IsNothing(ds) Then
                If (ds.Tables(0).Rows.Count > 0) Then
                    _resultado = ds.Tables(0).Rows(0).Item("resultado").ToString()
                    htht = New Hashtable
                    Select Case _resultado
                        Case "1"
                            htht.Add("UF", ds.Tables(0).Rows(0).Item("uf").ToString().Trim())
                            htht.Add("cidade", ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
                            htht.Add("bairro", ds.Tables(0).Rows(0).Item("bairro").ToString().Trim())
                            htht.Add("tipologradouro", ds.Tables(0).Rows(0).Item("tipo_logradouro").ToString().Trim())
                            htht.Add("logradouro", ds.Tables(0).Rows(0).Item("logradouro").ToString().Trim())
                            htht.Add("tipo", 1)

                        Case "2"
                            htht.Add("UF", ds.Tables(0).Rows(0).Item("uf").ToString().Trim())
                            htht.Add("cidade", ds.Tables(0).Rows(0).Item("cidade").ToString().Trim())
                            htht.Add("tipo", 2)
                        Case Else
                            htht.Add("tipo", 0)
                    End Select
                End If
            End If
            Return htht

        Catch ex As Exception
            Throw New Exception("Falha ao Buscar o Cep" & vbCrLf & ex.ToString)
            Return Nothing
        End Try

    End Function

    Function CalculaProbaLogradouro(Texto1 As String, Texto2 As String) As Decimal
        Dim i As Integer = 0 ' percorer o array
        Dim tamanho As Integer ' guarda o tamanha do texto menor
        Dim igual As Integer = 0 'guardar iguais
        Dim TextoBase As String
        Dim TextoProcurar As String
        Dim txtProcurar As String
        Dim inicioProcura As Integer = 1

        Texto1 = Replace(Texto1, "1", "")
        Texto1 = Replace(Texto1, "2", "")
        Texto1 = Replace(Texto1, "3", "")
        Texto1 = Replace(Texto1, "4", "")
        Texto1 = Replace(Texto1, "5", "")
        Texto1 = Replace(Texto1, "6", "")
        Texto1 = Replace(Texto1, "7", "")
        Texto1 = Replace(Texto1, "8", "")
        Texto1 = Replace(Texto1, "9", "")
        Texto1 = Replace(Texto1, "0", "")
        Texto1 = Replace(Texto1, ",", "")

        Texto2 = Replace(Texto2, "1", "")
        Texto2 = Replace(Texto2, "2", "")
        Texto2 = Replace(Texto2, "3", "")
        Texto2 = Replace(Texto2, "4", "")
        Texto2 = Replace(Texto2, "5", "")
        Texto2 = Replace(Texto2, "6", "")
        Texto2 = Replace(Texto2, "7", "")
        Texto2 = Replace(Texto2, "8", "")
        Texto2 = Replace(Texto2, "9", "")
        Texto2 = Replace(Texto2, "0", "")
        Texto2 = Replace(Texto2, ",", "")

        Texto1 = RTrim(Texto1)
        Texto2 = RTrim(Texto2)

        Dim Result As Decimal

        If Texto1.Length < Texto2.Length Then
            tamanho = Texto2.Length
            TextoBase = Texto2
            TextoProcurar = Texto1
        Else
            tamanho = Texto1.Length
            TextoBase = Texto1
            TextoProcurar = Texto2
        End If

        Dim ii As Integer
        While (i < tamanho)
            ii = i
            inicioProcura = i + 1
            txtProcurar = Mid(TextoProcurar, inicioProcura, 3)
            While (ii < tamanho)
                If InStr(inicioProcura, TextoBase, txtProcurar) > 0 And txtProcurar.Length >= 3 Then
                    igual += 1
                    Exit While
                End If
                ii += 1
            End While
            i += 1
        End While

        If (TextoBase.Length - 2) > 0 Then
            Result = Math.Round((igual * 100) / (TextoBase.Length - 2), 2, MidpointRounding.AwayFromZero)
        Else
            Result = 0
        End If

        Return Result
    End Function
    Function VerificaTexto(Texto As String) As String

        Texto = NuloString(UCase(Texto))
        Texto = Replace(Texto, "'", " ")
        Texto = Replace(Texto, "´", " ")
        Texto = Replace(Texto, "`", " ")

        Texto = Replace(Texto, "Ã§", "C")
        Texto = Replace(Texto, "Ã©", "E")
        Texto = Replace(Texto, "Ãª­", "E")

        Texto = Replace(Texto, "Á", "A")
        Texto = Replace(Texto, "À", "A")
        Texto = Replace(Texto, "Ã", "A")

        Texto = Replace(Texto, "É", "E")
        Texto = Replace(Texto, "È", "E")
        Texto = Replace(Texto, "Ê", "E")

        Texto = Replace(Texto, "Í", "I")
        Texto = Replace(Texto, "Ì", "I")

        Texto = Replace(Texto, "Ó", "O")
        Texto = Replace(Texto, "Ò", "O")
        Texto = Replace(Texto, "Õ", "O")

        Texto = Replace(Texto, "Ú", "U")
        Texto = Replace(Texto, "Ù", "U")

        Texto = Replace(Texto, "Ç", "C")

        Return Texto
    End Function
    Public Sub AtualizaUltimaVendaCliente(IDcli As Integer)

        strSql = "SELECT MAX(IDVendaRet) AS UltimaIDVenda, IDCliente, MAX(DataVenda) AS UltimaDataVenda, IDLoja, COUNT(IDVendaRet) AS QtdVendas "
        strSql += "From tblRetVendas "
        strSql += "Group By IDCliente, IDLoja "
        strSql += "HAVING (IDCliente = " & IDcli & ") and (IDLoja=" & IDLoja & ")"
        Dim con As New SqlConnection(strConServer)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            strSql = "UPDATE tblClientes SET "
            strSql &= "IDVendaUltimaVenda=" & NuloInteger(dr.Item("UltimaIDVenda")) & ", "
            strSql &= "QtdVendas=" & NuloInteger(dr.Item("QtdVendas")) & ", "
            strSql &= "DataUltimaVenda='" & NuloString(dr.Item("UltimaDataVenda")) & "', "
            strSql &= "Atualiza=1 "
            strSql &= "WHERE (IDCliente=" & IDcli & ")"
            ExecutaStr(strSql)
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

    End Sub
    Public Sub IncluirLog(Term As String, Oper As String, Acao As String, Desc As String)

        strSql = "INSERT INTO tblLogsEventosGV (Terminal, Operador, DataHora, Acao, Descricao, DataDia) VALUES ("
        strSql += "'" & NuloString(Term) & "',"
        strSql += "'" & NuloString(Oper) & "',"
        strSql += to_sqlDATA(NuloString(Now), "datahora", "L") & ", "
        strSql += "'" & NuloString(Acao) & "',"
        strSql += "'" & NuloString(Desc) & "', "
        strSql += to_sqlDATA(NuloString(Now), "data", "L") & ")"
        ExecutaStr(strSql)

    End Sub
    Public Sub LimpaLogs(DataLimpa As Date)
        strSql = "SELECT MIN(IDLog) AS ID, DataDia FROM tblLogsEventosGV GROUP BY DataDia HAVING (DataDia <= '" & Format(DataLimpa, FormatoDataLocal) & " 00:00:00')"
        Dim IDLimpa As Integer = NuloInteger(PegaValorCampo("ID", strSql, strCon)) - 1

        ExecutaStr("DELETE FROM tblLogsEventosGV WHERE (IDLog < " & IDLimpa & ")")

    End Sub
    Public Sub VerificaServico(IDvda As Integer)
        Dim VlrServico As Decimal = 0
        Dim VlrProduto As Decimal = 0
        Dim PercServ As Decimal
        Dim con As New SqlConnection()

        strSql = "Select tblVendas.IDVenda, tblVendas.Servico, tblVendas.PercServico, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasMovto.Qtd As Qtde, tblVendasMovto.Excluido, tblVendasMovto.IDVendaMovto, tblProdutos_Local.ComServico, tblVendasMovto.ComServico AS ComServicoMovto "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
        strSql += "WHERE(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda = " & IDvda & ") "
        strSql += "ORDER BY tblVendasMovto.Produto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")
        Dim vlr As Decimal
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            VlrProduto += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))
            PercServico = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("PercServico"))

            vlr = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * ((PercServ / 100) + 1)
            strSql = "UPDATE tblVendasMovto SET "
            If NuloString(ds.Tables("Vendas").Rows(i).Item("ComServicoMovto")) = "" Then
                If NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico")) = True Then
                    strSql &= "VendaServico=" & Replace(NuloString(vlr), ",", ".") & " "
                    VlrServico += NuloDecimal(vlr)
                Else
                    strSql &= "VendaServico=" & Replace(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")), ",", ".") & " "
                    VlrServico += NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Venda"))
                End If
            Else
                If NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico")) = True And NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServicoMovto")) = True Then
                    strSql &= "VendaServico=" & Replace(NuloString(vlr), ",", ".") & " "
                    VlrServico += NuloDecimal(vlr)
                Else
                    strSql &= "VendaServico=" & Replace(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")), ",", ".") & " "
                    VlrServico += NuloDecimal(ds.Tables("Vendas").Rows(0).Item("Venda"))
                End If
            End If
            strSql += "WHERE (IDVendaMovto = " & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) & ")"
            ExecutaStr(strSql)

        Next

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Function SaldoPendencia(IDcli As Integer) As Decimal
        Dim strSql As String
        Dim Saldo As Decimal = 0
        Dim con As New SqlConnection(strCon)

        strSql = "SELECT IDPendencia, IDCliente, Data, Valor FROM tblPendenciasLoja WHERE(IDCliente=" & IDcli & ") ORDER BY Data, IDPendencia"

        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                Saldo += NuloDecimal(dr.Item("Valor"))
                strSql = "UPDATE tblPendenciasLoja SET "
                strSql += "Saldo=" & Replace(Saldo.ToString, ",", ".") & " "
                strSql += "WHERE (IDPendencia=" & NuloInteger(dr.Item("IDPendencia")) & ")"
                ExecutaStr(strSql)
            End While
        End If

        strSql = "UPDATE tblClientes SET "
        strSql += "SaldoCredito=" & Replace(Saldo.ToString, ",", ".") & " "
        strSql += "WHERE (IDCliente=" & IDcli & ")"
        ExecutaStr(strSql)

        Return Saldo

        dr.Close()
        cmd.Dispose()
        con.Close()
    End Function


    Public Sub BaixaEstoque(IDfec As Integer)
        strSql = "Select tblRetVendas.IDfechamento, SUM(tblRetVendasMovto.Qtd) As Qtde, tblRetVendasCombo.IDVendaRetMovto, tblFechamentos.DiaMovimento, tblRetVendasMovto.IDProduto, SUM(tblRetVendasCombo.Qtd) As QtdeCombo, tblRetVendas.IDLoja, tblProdutos.BaixaEstoque, tblProdutos.IDFichaTecnica, tblProdutos.Custo, tblProdutos.CustoCMV, tblRetVendasCombo.IDProduto AS IDProdutoCombo "
        strSql += "From tblRetVendas INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet INNER Join tblFechamentos On tblRetVendas.IDfechamento = tblFechamentos.IDFechamento LEFT OUTER Join tblProdutos On tblRetVendasMovto.IDProduto = tblProdutos.IDProduto LEFT OUTER Join tblRetVendasCombo On tblRetVendasMovto.IDVendaRetMovto = tblRetVendasCombo.IDVendaRetMovto "
        strSql += "Where (tblRetVendas.Excluido = 0) And (tblRetVendasMovto.Excluido = 0) "
        strSql += "Group By tblRetVendas.IDfechamento, tblRetVendasCombo.IDVendaRetMovto, tblFechamentos.DiaMovimento, tblRetVendasCombo.IDProduto, tblRetVendasMovto.IDProduto, tblRetVendas.IDLoja, tblProdutos.IDFichaTecnica, tblProdutos.Custo, tblProdutos.CustoCMV, tblProdutos.BaixaEstoque "
        strSql += "HAVING(tblRetVendas.IDfechamento = " & IDfec & ") And (tblProdutos.BaixaEstoque = 1) "
        strSql += "Order BY tblRetVendasCombo.IDVendaRetMovto"

        Dim str_sql As String
        Dim IDult As Integer
        Dim IDmovto As Integer
        Dim Estq As Decimal
        Dim VlrSaldoEstq As Decimal
        Dim dapV = New SqlDataAdapter(strSql, strConServer)
        dapV.SelectCommand.CommandType = CommandType.Text
        Dim dsV As New DataSet()
        dapV.Fill(dsV, "Vendas")

        For i As Integer = 0 To dsV.Tables("Vendas").Rows.Count - 1
            IDmovto = NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDVendaRetMovto"))
            If NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProdutoCombo")) = 0 Then
                ' Baixa ficha tecnica produto simples  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDFichaTecnica")) <> 0 Then
                    BaixaEstoqueFichaTecnica(NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDFichaTecnica")), IDmovto, NuloString(dsV.Tables("Vendas").Rows(i).Item("DiaMovimento")), IDfec, NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde")))
                Else
                    ' Baixa estoque produto simples  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    strSql = "Select IDProduto, EstoqueAtual FROM tblProdutos WHERE (IDProduto=" & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ")"
                    Estq = NuloDecimal(PegaValorCampo("EstoqueAtual", strSql, strConServer))

                    strSql = "UPDATE tblProdutos Set "
                    strSql += "EstoqueAtual=" & Replace(NuloString(Estq - NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde"))), ",", ".") & " "
                    strSql += "WHERE (IDProduto=" & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ")"
                    ExecutaStrServidor(strSql)

                    strSql = "INSERT tblMovimentoEstoque "
                    strSql += "(IDLoja,IDVendaRetMovto,IDProduto,DataLancamento,Status,Descricao,Quantidade,Saldo,ValorLancamento,ValorTotalLancamento,ValorSaldo,ValorTotalSaldo) VALUES ("
                    strSql += NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDLoja")) & ", "
                    strSql += NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDVendaRetMovto")) & ", "
                    strSql += NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ", "
                    strSql += to_sqlDATA(NuloString(dsV.Tables("Vendas").Rows(i).Item("DiaMovimento")), "datahora", "R") & ", "
                    strSql += "'V', "
                    strSql += "'MOVTO - " & NuloString(dsV.Tables("Vendas").Rows(i).Item("IDFechamento")) & "', "
                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde")) * -1), ",", ".") & ", "
                    strSql += Replace(NuloString(Estq - NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde"))), ",", ".") & ", "

                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV"))), ",", ".") & ", "
                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV")) * NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde"))), ",", ".") & ", "
                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV"))), ",", ".") & ", "

                    str_sql = "Select IDLoja, IDProduto, MAX(IDMovimentoEstoque) As IDUltimoLancto "
                    str_sql += "From tblMovimentoEstoque "
                    str_sql += "Group By IDLoja, IDProduto "
                    str_sql += "HAVING (IDProduto = " & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ") And (IDLoja = " & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDLoja")) & ")"
                    IDult = NuloInteger(PegaValorCampo("IDUltimoLancto", str_sql, strConServer))

                    str_sql = "Select IDMovimentoEstoque As IDUltimoLancto, ValorTotalSaldo "
                    str_sql += "From tblMovimentoEstoque "
                    str_sql += "Where (IDMovimentoEstoque = " & IDult & ")"
                    VlrSaldoEstq = NuloDecimal(PegaValorCampo("ValorTotalSaldo", str_sql, strConServer)) - (NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV")) * NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde")))
                    strSql += Replace(NuloString(NuloDecimal(VlrSaldoEstq)), ",", ".") & ")"
                    ExecutaStrServidor(strSql)
                End If
            Else

                If NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDFichaTecnica")) <> 0 Then
                    BaixaEstoqueFichaTecnica(NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDFichaTecnica")), IDmovto, NuloString(dsV.Tables("Vendas").Rows(i).Item("DiaMovimento")), IDfec, NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde")))
                Else
                    ' Baixa estoque produto combo  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    strSql = "Select IDProduto, EstoqueAtual FROM tblProdutos WHERE (IDProduto=" & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ")"
                    Estq = NuloDecimal(PegaValorCampo("EstoqueAtual", strSql, strConServer))

                    strSql = "UPDATE tblProdutos Set "
                    strSql += "EstoqueAtual=" & Replace(NuloString(Estq - NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde"))), ",", ".") & " "
                    strSql += "WHERE (IDProduto=" & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ")"
                    ExecutaStrServidor(strSql)

                    strSql = "INSERT tblMovimentoEstoque "
                    strSql += "(IDLoja,IDVendaRetMovto,IDProduto,DataLancamento,Status,Descricao,Quantidade,Saldo,ValorLancamento,ValorTotalLancamento,ValorSaldo,ValorTotalSaldo) VALUES ("
                    strSql += NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDLoja")) & ", "
                    strSql += NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDVendaRetMovto")) & ", "
                    strSql += NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ", "
                    strSql += to_sqlDATA(NuloString(dsV.Tables("Vendas").Rows(i).Item("DiaMovimento")), "datahora", "R") & ", "
                    strSql += "'V', "
                    strSql += "'MOVTO - " & NuloString(dsV.Tables("Vendas").Rows(i).Item("IDFechamento")) & "', "
                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde")) * -1), ",", ".") & ", "
                    strSql += Replace(NuloString(Estq - NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde"))), ",", ".") & ", "

                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV"))), ",", ".") & ", "
                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV")) * NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde"))), ",", ".") & ", "
                    strSql += Replace(NuloString(NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV"))), ",", ".") & ", "

                    str_sql = "Select IDLoja, IDProduto, MAX(IDMovimentoEstoque) As IDUltimoLancto "
                    str_sql += "From tblMovimentoEstoque "
                    str_sql += "Group By IDLoja, IDProduto "
                    str_sql += "HAVING (IDProduto = " & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDProduto")) & ") And (IDLoja = " & NuloInteger(dsV.Tables("Vendas").Rows(i).Item("IDLoja")) & ")"
                    IDult = NuloInteger(PegaValorCampo("IDUltimoLancto", str_sql, strConServer))

                    str_sql = "Select IDMovimentoEstoque As IDUltimoLancto, ValorTotalSaldo "
                    str_sql += "From tblMovimentoEstoque "
                    str_sql += "Where (IDMovimentoEstoque = " & IDult & ")"
                    VlrSaldoEstq = NuloDecimal(PegaValorCampo("ValorTotalSaldo", str_sql, strConServer)) - (NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("CustoCMV")) * NuloDecimal(dsV.Tables("Vendas").Rows(i).Item("Qtde")))
                    strSql += Replace(NuloString(NuloDecimal(VlrSaldoEstq)), ",", ".") & ")"
                    ExecutaStrServidor(strSql)
                End If


            End If

        Next
        dapV.Dispose()

    End Sub
    Public Sub BaixaEstoqueFichaTecnica(IDficha As Integer, IDmovto As Integer, DiaMovto As String, IDfecha As Integer, QtdeFc As Decimal)

        'strSql = "Select tblFichaTecnicaDescricao.IDFichaTecnica, tblProdutos.IDProduto, tblFichaTecnicaDescricao.Qtde, tblProdutos.IDFichaTecnica As IDFichaTecnicaSub, tblProdutos.Custo, tblFichaTecnica.IDLoja "
        'strSql += "From tblFichaTecnicaDescricao INNER Join tblProdutos On tblFichaTecnicaDescricao.IDProduto = tblProdutos.IDProduto INNER Join tblFichaTecnica On tblFichaTecnicaDescricao.IDFichaTecnica = tblFichaTecnica.IDFichaTecnica "

        strSql = "Select tblFichaTecnicaDescricao.IDFichaTecnica, tblFichaTecnicaDescricao.Qtde, tblProdutos.Custo, tblFichaTecnica.IDLoja, tblFichaTecnicaDescricao.IDProdutoLoja As IDProduto, tblFichaTecnicaDescricao.IDFichaTecnicaProduto "
        strSql += "From tblFichaTecnicaDescricao INNER Join tblFichaTecnica On tblFichaTecnicaDescricao.IDFichaTecnica = tblFichaTecnica.IDFichaTecnica LEFT OUTER Join tblProdutos On tblFichaTecnicaDescricao.IDProduto = tblProdutos.IDProduto "
        strSql += "Where (tblFichaTecnicaDescricao.IDFichaTecnica = " & IDficha & ")"

        Dim str_sql As String
        Dim IDult As Integer
        Dim Estq As Decimal
        Dim QtdeBaixa As Decimal
        Dim VlrSaldoEstq As Decimal
        Dim dapF = New SqlDataAdapter(strSql, strConServer)
        dapF.SelectCommand.CommandType = CommandType.Text
        Dim dsF As New DataSet()
        dapF.Fill(dsF, "Ficha")

        For i As Integer = 0 To dsF.Tables("Ficha").Rows.Count - 1

            strSql = "SELECT IDProduto, EstoqueAtual, Custo FROM tblProdutos WHERE (IDProduto=" & NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDProduto")) & ")"
            Estq = NuloDecimal(PegaValorCampo("EstoqueAtual", strSql, strConServer))

            'If NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDFichaTecnicaSub")) = 0 Then
            'QtdeBaixa = NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Qtde"))
            'Else
            QtdeBaixa = QtdeFc
            'End If

            If NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDFichaTecnicaProduto")) = 0 Then


                strSql = "UPDATE tblProdutos SET "
                strSql += "EstoqueAtual=" & Replace(NuloString(Estq - QtdeBaixa), ",", ".") & " "
                strSql += "WHERE (IDProduto=" & NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDProduto")) & ")"
                ExecutaStrServidor(strSql)

                strSql = "INSERT tblMovimentoEstoque "
                strSql += "(IDLoja,IDVendaRetMovto,IDProduto,DataLancamento,Status,Descricao,Quantidade,Saldo,ValorLancamento,ValorTotalLancamento,ValorSaldo,ValorTotalSaldo) VALUES ("
                strSql += NuloInteger(IDLoja) & ", "
                strSql += NuloInteger(IDmovto) & ", "
                strSql += NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDProduto")) & ", "
                strSql += to_sqlDATA(NuloString(DiaMovto), "datahora", "R") & ", "
                strSql += "'V', "
                strSql += "'MOVTO - " & NuloString(IDfecha) & "', "
                strSql += Replace(NuloString((QtdeBaixa * QtdeFc) * -1), ",", ".") & ", "
                strSql += Replace(NuloString(Estq - (QtdeBaixa * QtdeFc)), ",", ".") & ", "

                strSql += Replace(NuloString(NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Custo"))), ",", ".") & ", "
                strSql += Replace(NuloString(NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Custo")) * NuloDecimal((QtdeBaixa * QtdeFc))), ",", ".") & ", "
                strSql += Replace(NuloString(NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Custo"))), ",", ".") & ", "


                str_sql = "Select IDLoja, IDProduto, MAX(IDMovimentoEstoque) As IDUltimoLancto "
                str_sql += "From tblMovimentoEstoque "
                str_sql += "Group By IDLoja, IDProduto "
                str_sql += "HAVING (IDProduto = " & NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDProduto")) & ")"
                IDult = NuloInteger(PegaValorCampo("IDUltimoLancto", str_sql, strConServer))

                str_sql = "Select IDMovimentoEstoque As IDUltimoLancto, ValorTotalSaldo "
                str_sql += "From tblMovimentoEstoque "
                str_sql += "Where (IDMovimentoEstoque = " & IDult & ")"
                VlrSaldoEstq = NuloDecimal(PegaValorCampo("ValorTotalSaldo", str_sql, strConServer)) - (NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Custo")) * NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Qtde")))
                strSql += Replace(NuloString(NuloDecimal(VlrSaldoEstq)), ",", ".") & ")"
                ExecutaStrServidor(strSql)
            Else
                ' Baixa ficha tecnica produto simples  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                'If NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDFichaTecnicaSub")) <> 0 Then
                BaixaEstoqueFichaTecnicaSub(NuloInteger(dsF.Tables("Ficha").Rows(i).Item("IDFichaTecnicaProduto")), IDmovto, NuloString(DiaMovto), IDfecha, NuloDecimal(dsF.Tables("Ficha").Rows(i).Item("Qtde")))
            End If
        Next
        dapF.Dispose()

    End Sub
    Public Sub BaixaEstoqueFichaTecnicaSub(IDfichaS As Integer, IDmovtoS As Integer, DiaMovtoS As String, IDfechaS As Integer, QtdeFcS As Decimal)

        'strSql = "Select tblFichaTecnicaDescricao.IDFichaTecnica, tblFichaTecnicaDescricao.IDProduto, tblFichaTecnicaDescricao.Qtde, tblProdutos.IDFichaTecnica As IDFichaTecnicaSub, tblProdutos.IDProduto, tblProdutos.Custo "
        'strSql += "From tblFichaTecnicaDescricao INNER Join tblProdutos On tblFichaTecnicaDescricao.IDProduto = tblProdutos.IDProduto "

        strSql = "Select tblFichaTecnicaDescricao.IDFichaTecnica, tblFichaTecnicaDescricao.Qtde, tblProdutos.IDFichaTecnica As IDFichaTecnicaSub, tblProdutos.Custo, tblFichaTecnicaDescricao.IDProdutoLoja As IDProduto "
        strSql += "From tblFichaTecnicaDescricao INNER Join tblProdutos On tblFichaTecnicaDescricao.IDProdutoLoja = tblProdutos.IDProduto "
        strSql += "Where (tblFichaTecnicaDescricao.IDFichaTecnica = " & IDfichaS & ")"

        Dim str_sql As String
        Dim IDult As Integer
        Dim QtdeBaixa As Decimal
        Dim Estq As Decimal
        Dim VlrSaldoEstq As Decimal
        Dim dapFS = New SqlDataAdapter(strSql, strConServer)
        dapFS.SelectCommand.CommandType = CommandType.Text
        Dim dsFS As New DataSet()
        dapFS.Fill(dsFS, "Ficha")

        For i As Integer = 0 To dsFS.Tables("Ficha").Rows.Count - 1

            strSql = "SELECT IDProduto, EstoqueAtual, Custo FROM tblProdutos WHERE (IDProduto=" & NuloInteger(dsFS.Tables("Ficha").Rows(i).Item("IDProduto")) & ")"
            Estq = NuloDecimal(PegaValorCampo("EstoqueAtual", strSql, strConServer))
            'If NuloInteger(dsFS.Tables("Ficha").Rows(i).Item("IDFichaTecnicaSub")) = 0 Then
            QtdeBaixa = NuloDecimal(dsFS.Tables("Ficha").Rows(i).Item("Qtde")) * QtdeFcS
            'Else
            'QtdeBaixa = QtdeFcS
            'End If

            strSql = "UPDATE tblProdutos SET "
            strSql += "EstoqueAtual=" & Replace(NuloString(Estq - QtdeBaixa), ",", ".") & " "
            strSql += "WHERE (IDProduto=" & NuloInteger(dsFS.Tables("Ficha").Rows(i).Item("IDProduto")) & ")"
            ExecutaStrServidor(strSql)

            strSql = "INSERT tblMovimentoEstoque "
            strSql += "(IDLoja,IDVendaRetMovto,IDProduto,DataLancamento,Status,Descricao,Quantidade,Saldo,ValorLancamento,ValorTotalLancamento,ValorSaldo,ValorTotalSaldo) VALUES ("
            strSql += NuloInteger(IDLoja) & ", "
            strSql += NuloInteger(IDmovtoS) & ", "
            strSql += NuloInteger(dsFS.Tables("Ficha").Rows(i).Item("IDProduto")) & ", "
            strSql += to_sqlDATA(NuloString(DiaMovtoS), "datahora", "R") & ", "
            strSql += "'V', "
            strSql += "'MOVTO - " & NuloString(IDfechaS) & "', "
            strSql += Replace(NuloString((QtdeBaixa * QtdeFcS) * -1), ",", ".") & ", "
            strSql += Replace(NuloString(Estq - (QtdeBaixa * QtdeFcS)), ",", ".") & ", "

            strSql += Replace(NuloString(NuloDecimal(dsFS.Tables("Ficha").Rows(i).Item("Custo"))), ",", ".") & ", "
            strSql += Replace(NuloString(NuloDecimal(dsFS.Tables("Ficha").Rows(i).Item("Custo")) * NuloDecimal((QtdeBaixa * QtdeFcS))), ",", ".") & ", "
            strSql += Replace(NuloString(NuloDecimal(dsFS.Tables("Ficha").Rows(i).Item("Custo"))), ",", ".") & ", "

            str_sql = "Select IDLoja, IDProduto, MAX(IDMovimentoEstoque) As IDUltimoLancto "
            str_sql += "From tblMovimentoEstoque "
            str_sql += "Group By IDLoja, IDProduto "
            str_sql += "HAVING (IDProduto = " & NuloInteger(dsFS.Tables("Ficha").Rows(i).Item("IDProduto")) & ")"
            IDult = NuloInteger(PegaValorCampo("IDUltimoLancto", str_sql, strConServer))

            str_sql = "Select IDMovimentoEstoque As IDUltimoLancto, ValorTotalSaldo "
            str_sql += "From tblMovimentoEstoque "
            str_sql += "Where (IDMovimentoEstoque = " & IDult & ")"
            VlrSaldoEstq = NuloDecimal(PegaValorCampo("ValorTotalSaldo", str_sql, strConServer)) - (NuloDecimal(dsFS.Tables("Ficha").Rows(i).Item("Custo")) * NuloDecimal(dsFS.Tables("Ficha").Rows(i).Item("Qtde")))
            strSql += Replace(NuloString(NuloDecimal(VlrSaldoEstq)), ",", ".") & ")"
            ExecutaStrServidor(strSql)

            '' Baixa ficha tecnica produto simples  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            'If NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDFichaTecnica")) <> 0 Then


            'End If
        Next
        dapFS.Dispose()

    End Sub
    Public Sub AcertaServico(IDvda As Integer, PServ As Decimal)

        strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasMovto.IDVenda, tblVendasMovto.Excluido, tblProdutos_Local.IDProduto, tblVendasMovto.Venda, tblProdutos_Local.ComServico "
        strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
        strSql += "Where (tblVendasMovto.IDVenda = " & IDvda & ") And (tblVendasMovto.Excluido = 0)"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")
        Dim VdaSer As Decimal
        Dim Vda As Decimal
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            Vda = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))
            VdaSer = NuloDecimal(Vda) * ((PServ / 100) + 1)

            strSql = "UPDATE tblVendasMovto SET "
            If NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico")) = True Then
                strSql += "VendaServico = " & Replace(NuloString(VdaSer), ",", ".") & " "
            Else
                strSql += "VendaServico = " & Replace(NuloString(Vda), ",", ".") & " "
            End If
            strSql += "WHERE (IDVendaMovto=" & NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")) & ")"
            ExecutaStr(strSql)

        Next
    End Sub

    Public Sub ConferenciaBalcao(IDvda As Integer)

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim Valor As String
        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        Dim VlrProTxt As String
        Dim VlrSerTxt As String
        Dim VlrDescTxt As String
        Dim SerTxt As String
        Dim IDvdaCombo As Integer
        con.ConnectionString = strCon
1:

        strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente  "
        strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
        strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.NomeCliente  "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & IDvda & ") "
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"


        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")


        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\conta.txt", CType(FileMode.Create, OpenMode))


        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            'IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))

            'System.Threading.Thread.Sleep(100)

            If ImpressoraCaixaTexto = False Then
                PrintLine(lngFile, Chr(27) + Chr(14) & " CONFERENCIA BALCAO  " & Chr(27) + Chr(14))
            Else
                PrintLine(lngFile, " CONFERENCIA BALCAO")
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, Chr(27) + Chr(14) & NuloString(ds.Tables("Vendas").Rows(0).Item("Loja")) & Chr(27) + Chr(14))
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Endereco"))) & "," & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Numero")))
            PrintLine(lngFile, texto)
            texto = Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("CEP"))) & "  -  " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Telefone")))
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "------------------------------------------")

            texto = "Atendente : " & Trim(NuloString(ds.Tables("Vendas").Rows(0).Item("Atendente")))
            PrintLine(lngFile, texto)

            texto = "Data      : " & NuloString(Now.ToShortDateString) & " - " & NuloString(Now.ToShortTimeString)
            PrintLine(lngFile, texto)

            texto = "Venda     : " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumVenda"))
            PrintLine(lngFile, texto)

            If NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente")) <> "" Then
                texto = "Cliente   : " & NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente"))
                PrintLine(lngFile, texto)
            End If

            texto = "Controle interno sem valor fiscal"
            PrintLine(lngFile, texto)
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Descricao          Qtde.   Unit.    Total ")
            PrintLine(lngFile, "------------------------------------------")
            Do While i <= ds.Tables("Vendas").Rows.Count - 1
                texto = Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")))
                If Len(texto) <= 18 Then
                    texto = texto & Space(18 - Len(texto))
                Else
                    texto = Strings.Left(texto, 18)
                End If

                If Int(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))) = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) Then
                    texto &= Space(6 - Len(NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde"))))) & NuloString(Int(ds.Tables("Vendas").Rows(i).Item("Qtde")))
                Else
                    texto &= " " & NuloString(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                End If
                texto &= Space(8 - Len(NuloString(ds.Tables("Vendas").Rows(i).Item("Venda")))) & NuloString(ds.Tables("Vendas").Rows(i).Item("Venda"))
                Valor = Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")), "#0.00")
                texto &= Space(10 - Len(NuloString(Valor))) & NuloString(Valor)
                PrintLine(lngFile, texto)

                VlrPro += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                VlrSer += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde"))
                If NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" Then
                    IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                    texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                    PrintLine(lngFile, texto)
                    i += 1
                    If i <= ds.Tables("Vendas").Rows.Count - 1 Then

                        Do While NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) <> "" And IDvdaCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto_Combo"))
                            texto = "  - " & Trim(NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")))
                            PrintLine(lngFile, texto)
                            i += 1
                            If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
                        Loop

                    End If
                Else
                    i += 1
                End If
                If i > ds.Tables("Vendas").Rows.Count - 1 Then Exit Do
            Loop
            PrintLine(lngFile, "==========================================")
            VlrProTxt = Format(NuloDecimal(VlrPro), "#0.00")

            PrintLine(lngFile, "Sub-total " & Space(32 - Len(VlrProTxt)) & VlrProTxt)

            SerTxt = Trim(Format(NuloDecimal(VlrSer) - NuloDecimal(VlrPro), "#0.00"))
            If Len(texto) < 23 Then
                texto = TextoServico & Space(7 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            Else
                texto = TextoServico & Space(23 - Len(NuloString(TextoServico))) & Space(19 - Len(NuloString(SerTxt))) & NuloString(SerTxt)
            End If

            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercServico")) > 0 Then
                PrintLine(lngFile, texto)
            End If


            If NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) > 0 Then
                Dim vlrDesc As Decimal = VlrPro * (NuloDecimal(ds.Tables("Vendas").Rows(0).Item("PercDesconto")) / 100)
                VlrDescTxt = Format(NuloDecimal(vlrDesc), "#0.00")

                VlrSer = VlrSer - vlrDesc
                texto = "Desconto  " & Space(32 - Len(VlrDescTxt)) & VlrDescTxt
                PrintLine(lngFile, texto)

            End If
            PrintLine(lngFile, "                              ------------")
            VlrSerTxt = Format(NuloDecimal(VlrSer), "#0.00")

            If ImpressoraCaixaTexto = False Then
                PrintLine(lngFile, Chr(27) + Chr(14) & "TOTAL" & Space(16 - Len(VlrSerTxt)) & VlrSerTxt & Chr(27) + Chr(14))
            Else
                PrintLine(lngFile, "TOTAL" & Space(37 - Len(VlrSerTxt)) & VlrSerTxt)
            End If

            PrintLine(lngFile, "------------------------------------------")

            SqlStr = "Select IDVenda, Descricao, ValorPago "
            SqlStr += "From tblVendasPagto "
            SqlStr += "Where (IDVenda =" & IDvda & ") "
            SqlStr += "Order By Descricao"

            Dim dap1 = New SqlDataAdapter(SqlStr, strCon)
            dap1.SelectCommand.CommandType = CommandType.Text
            'Dim ds As New DataSet()
            dap1.Fill(ds, "Pagto")
            PrintLine(lngFile, "Pagamento:")
            For ii As Integer = 0 To ds.Tables("Pagto").Rows.Count - 1
                SerTxt = Format(NuloDecimal(ds.Tables("Pagto").Rows(ii).Item("ValorPago")), "#0.00")
                texto = NuloString(ds.Tables("Pagto").Rows(ii).Item("Descricao"))
                texto += Space(23 - Len(NuloString(texto))) & Space(19 - Len(NuloString(SerTxt))) & NuloString(SerTxt)

                PrintLine(lngFile, texto)

            Next
            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Gourmet Visual    www.gourmetvisual.com.br")
            If GuilhotinaImpCaixa = False Then
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
            End If
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, " ")
        Next
        FileClose(lngFile)

        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()



        ''verifica se o nome do arquivo foi informado
        'Dim caminho As String = Application.StartupPath & "\Impressao\conta.txt"
        ''verifica se o arquivo existe
        'If File.Exists(caminho) Then
        ' Using tr As TextReader = New StreamReader(caminho)
        ' tbConta.Text = tr.ReadToEnd()
        'End Using
        'Else
        'MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If




        'Catch ex As Exception
        'If InStr(1, ex.Message, "localizar") > 0 Then
        'Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\pedido.txt")
        'fs.Close()
        'GoTo 1
        'Else
        'MsgBox(ex.Message)
        'End If

        'End Try

    End Sub
    Public Function SemArredondar(ByVal d As Double, ByVal casasDecimais As Integer) As String

        casasDecimais = CType(Math.Pow(10, casasDecimais), Integer)
        'casasDecimais = CType(Math.Round(10, casasDecimais, MidpointRounding.AwayFromZero), Integer)

        Return (Math.Floor(d * casasDecimais) / casasDecimais).ToString()

    End Function
    Public Function Arredondar(ByVal d As Double, ByVal casasDecimais As Integer) As String

        'casasDecimais = CType(Math.Pow(10, casasDecimais), Integer)
        casasDecimais = CType(Math.Round(10, casasDecimais, MidpointRounding.AwayFromZero), Integer)

        Return (Math.Floor(d * casasDecimais) / casasDecimais).ToString()
        'Return CType(Math.Round(d * casasDecimais) / casasDecimais, MidpointRounding.AwayFromZero), Decimal)

    End Function
    Public Sub AchaIDMovto()

        IDMovtoGV = 0

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = "Select MAX(IDVendaMovto) As IDMovto From tblVendasMovto WITH (TABLOCKX)"

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                IDMovtoGV = dr.GetInt32(0)
            End If


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub

    Function IncluiComentario(IDMovto As Integer, IDCombo As Integer, Coment As String, IDProdVinc As Integer) As String


        Dim conComent As New SqlConnection(strCon)
        strSql = "INSERT tblVendasComent (IDVenda,IDVendaMovto,IDVendaCombo,Coment,IDProdutoVinculado) VALUES ("
        strSql &= to_sql(IDVenda) & ","
        strSql &= to_sql(IDMovto) & ","
        strSql &= to_sql(IDCombo) & ","
        strSql &= to_sql(Coment) & ","
        strSql &= to_sql(IDProdVinc) & ")"
        conComent.Open()
        Dim cmdComent As New SqlCommand(strSql, conComent)
        cmdComent.CommandType = CommandType.Text
        cmdComent.ExecuteNonQuery()
        cmdComent.Dispose()
        conComent.Dispose()
        conComent.Close()

        If Coment = "EM ESPERA" Then
            strSql = "UPDATE tblVendasMovto SET "
            strSql += "EmEspera=1 "
            strSql += "WHERE IDVendaMovto=" & IDMovto
            ExecutaStr(strSql)
        End If

        Return strSql

    End Function

    Public Sub AchaIDCombo()
        IDCombo = 0

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = "Select MAX(IDVendaCombo) As IDCombo From tblVendasCombo WITH (TABLOCKX)"

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                IDCombo = dr.GetInt32(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub

    Public Sub AtualizaVendasServidor()

        If NuloInteger(PegaValorCampo("IDVenda", "Select * from tblVendas", strCon)) = 0 Then
            Exit Sub
        End If

        LimpaVendasServidor_OnLine()

        Dim IDVda As Integer
        Dim con As New SqlConnection()
        con.ConnectionString = strCon

        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select * from tblVendas"
        cmd.CommandText = strSql

        Try
            con.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While dr.Read()

                    strSql = "INSERT tblVendas (IDLoja,IDFechamento,NumVenda,NumMesa,IDCliente,Cartao,DataVenda,TotalProdutos,TotalVenda,Dinheiro,D_A,Desconto,PercDesconto,Servico,Caixinha,QtdPessoas,FlagFechada,HoraAbertura,HoraFechamento,TipoLancto,ValorEstacionamento,Status,StatusVenda,PercServico,Caixa,Troco,Atendente,Excluido,ContraVale,TaxaEntrega,PreNota,IDFuncionarioAtendente,MotivoEstorno) VALUES ("
                    strSql += to_sql(IDLoja) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("IDFechamento"))) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("NumVenda"))) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("NumMesa"))) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("IDCliente"))) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("Cartao"))) & ", "
                    strSql += to_sql(CDate(dr.Item("DataVenda")).ToString(FormatoDataRET & " HHH:mm:ss")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("TotalProdutos"))), ",", ".")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("TotalVenda"))), ",", ".")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("Dinheiro"))), ",", ".")) & ", "
                    strSql += "0, "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("Desconto"))), ",", ".")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("PercDesconto"))), ",", ".")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("Servico"))), ",", ".")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("Caixinha"))), ",", ".")) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("QtdPessoas"))) & ", "
                    strSql += to_sql(NuloBoolean(dr.Item("FlagFechada"))) & ", "
                    strSql += to_sql(CDate(dr.Item("HoraAbertura")).ToString(FormatoDataRET & " HHH:mm:ss")) & ", "
                    If Not IsDBNull(dr.Item("HoraFechamento")) Then
                        strSql += to_sql(CDate(dr.Item("HoraFechamento")).ToString(FormatoDataRET & " HHH:mm:ss")) & ", "
                    Else
                        strSql += "'', "
                    End If
                    strSql += to_sql(NuloBoolean(dr.Item("TipoLancto"))) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("ValorEstacionamento"))), ",", ".")) & ", "
                    strSql += to_sql(NuloString(dr.Item("Status"))) & ", "
                    strSql += to_sql(NuloString(dr.Item("StatusVenda"))) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("PercServico"))), ",", ".")) & ", "
                    strSql += to_sql(NuloString(dr.Item("Caixa"))) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("Troco"))), ",", ".")) & ", "
                    strSql += to_sql(NuloString(dr.Item("Atendente"))) & ", "
                    strSql += to_sql(NuloBoolean(dr.Item("Excluido"))) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("ContraVale"))), ",", ".")) & ", "
                    strSql += to_sql(Replace(NuloString(NuloDecimal(dr.Item("TaxaEntrega"))), ",", ".")) & ", "
                    strSql += to_sql(NuloBoolean(dr.Item("PreNota"))) & ", "
                    strSql += to_sql(NuloInteger(dr.Item("IDFuncionarioAtendente"))) & ", "
                    strSql += to_sql(NuloString(dr.Item("MotivoEstorno"))) & ")"
                    ExecutaStrServidor(strSql)
                    IDVda = PegaID("IDVenda", "tblVendas", "S")

                    Dim conVdaM As New SqlConnection(strCon)
                    Dim cmdVdaM As SqlCommand = conVdaM.CreateCommand
                    strSql = "SELECT * FROM tblVendasMovto WHERE (IDVenda=" & NuloInteger(dr.Item("IDVenda")) & ")"
                    conVdaM.Open()
                    cmdVdaM.CommandText = strSql
                    Dim drVdaM As SqlDataReader
                    drVdaM = cmdVdaM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    If drVdaM.HasRows Then
                        While drVdaM.Read
                            strSql = "INSERT tblVendasMovto (IDVenda,IDProduto,Produto,Qtd,Venda,VendaServico,Excluido,HoraPedido,Comanda,Categoria,IDFuncionario,Atendente,MesaCartao,IDGrupo,Grupo,StatusTransf,MotivoEstorno) VALUES ("
                            strSql += to_sql(IDVda) & ", "
                            strSql += to_sql(NuloInteger(drVdaM.Item("IDProduto"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("Produto"))) & ", "
                            strSql += to_sql(Replace(drVdaM.Item("Qtd").ToString, ",", ".")) & ", "
                            strSql += to_sql(Replace(drVdaM.Item("Venda").ToString, ",", ".")) & ", "
                            strSql += to_sql(Replace(drVdaM.Item("VendaServico").ToString, ",", ".")) & ", "
                            strSql += to_sql(NuloBoolean(drVdaM.Item("Excluido"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("HoraPedido"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("Comanda"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("Categoria"))) & ", "
                            strSql += to_sql(NuloInteger(drVdaM.Item("IDFuncionario"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("Atendente"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("MesaCartao"))) & ", "
                            strSql += to_sql(NuloInteger(drVdaM.Item("IDGrupo"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("Grupo"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("StatusTransf"))) & ", "
                            strSql += to_sql(NuloString(drVdaM.Item("MotivoEstorno"))) & ")"
                            ExecutaStrServidor(strSql)

                            '' Inclui vendas Combo no Retaguarda  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            'IncluiVendaCombo(IDVdaMovtoGou, IDVdaMovtoRet)

                            '' Inclui Comentarios movto  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            'IncluiComentMovto(IDVdaMovtoGou, IDVdaMovtoRet, "M")
                        End While
                    End If
                    cmdVdaM.Dispose()
                    drVdaM.Close()
                    conVdaM.Dispose()
                    conVdaM.Close()

                    Dim conP As New SqlConnection(strCon)
                    Dim cmdP As SqlCommand = conP.CreateCommand
                    cmdP.CommandText = "SELECT * FROM tblVendasPagto WHERE (IDVenda=" & NuloInteger(dr.Item("IDVenda")) & ")"

                    conP.Open()
                    Dim drP As SqlDataReader
                    drP = cmdP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    While drP.Read
                        strSql = "INSERT tblVendasPagto (IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom) VALUES ("
                        strSql += to_sql(IDVda) & ", "
                        strSql += to_sql(NuloInteger(drP.Item("IDFormaPagto"))) & ", "
                        strSql += to_sql(NuloString(drP.Item("Descricao"))) & ", "
                        strSql += to_sql(Replace(drP.Item("ValorPago").ToString, ",", ".")) & ", "
                        strSql += to_sql(NuloBoolean(drP.Item("ECartao"))) & ", "
                        strSql += to_sql(Replace(drP.Item("TaxaCartao").ToString, ",", ".")) & ", "
                        strSql += to_sql(NuloString(drP.Item("Tipo"))) & ", "
                        strSql += to_sql(NuloBoolean(drP.Item("Cupom"))) & ")"
                        ExecutaStrServidor(strSql)
                    End While
                    cmdP.Dispose()
                    drP.Close()
                    conP.Dispose()
                    conP.Close()

                End While
            Else
                strSql = "INSERT tblVendas (IDLoja,IDFechamento,NumVenda,NumMesa,IDCliente,Cartao,DataVenda,TotalProdutos,TotalVenda,Dinheiro,D_A,Desconto,PercDesconto,Servico,Caixinha,QtdPessoas,FlagFechada,HoraAbertura,HoraFechamento,TipoLancto,ValorEstacionamento,Status,StatusVenda,PercServico,Caixa,Troco,Atendente,Excluido,ContraVale,TaxaEntrega,PreNota,IDFuncionarioAtendente,MotivoEstorno) VALUES ("
                strSql += to_sql(IDLoja) & ", "
                strSql += "1, "
                strSql += "1, "
                strSql += "1, "
                strSql += "0, "
                strSql += "0, "
                strSql += to_sql(CDate(Now).ToString(FormatoDataRET & " HHH:mm:ss")) & ", "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += to_sql(CDate(Now).ToString(FormatoDataRET & " HHH:mm:ss")) & ", "
                strSql += "'', "
                strSql += "0, "
                strSql += "0, "
                strSql += "'', "
                strSql += "'SEM VENDAS', "
                strSql += "0, "
                strSql += "'', "
                strSql += "0, "
                strSql += "'', "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "'')"
                ExecutaStrServidor(strSql)
                IDVda = PegaID("IDVenda", "tblVendas", "S")

                strSql = "INSERT tblVendasMovto (IDVenda,IDProduto,Produto,Qtd,Venda,VendaServico,Excluido,HoraPedido,Comanda,Categoria,IDFuncionario,Atendente,MesaCartao,IDGrupo,Grupo,StatusTransf,MotivoEstorno) VALUES ("
                strSql += to_sql(IDVda) & ", "
                strSql += "0, "
                strSql += "'SEM VENDA', "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "'', "
                strSql += "'', "
                strSql += "'', "
                strSql += "0, "
                strSql += "'', "
                strSql += "'', "
                strSql += "0, "
                strSql += "'', "
                strSql += "'', "
                strSql += "'')"
                ExecutaStrServidor(strSql)

                strSql = "INSERT tblVendasPagto (IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom) VALUES ("
                strSql += to_sql(IDVda) & ", "
                strSql += "'', "
                strSql += "'SEM VENDA', "
                strSql += "0, "
                strSql += "0, "
                strSql += "0, "
                strSql += "'', "
                strSql += "0)"
                ExecutaStrServidor(strSql)
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

        Catch ex As Exception

        End Try

    End Sub
    Public Sub LimpaVendasServidor_OnLine()

        Dim con As New SqlConnection()
        con.ConnectionString = strConServer

        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select * from tblVendas WHERE (IDLoja=" & IDLoja & ")"
        cmd.CommandText = strSql

        Try

            con.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While dr.Read()

                    Dim conM As New SqlConnection()
                    conM.ConnectionString = strConServer
                    Dim cmdM As SqlCommand = conM.CreateCommand
                    strSql = "Select * from tblVendasMovto WHERE IDVenda=" & NuloInteger(dr.Item("IDVenda"))
                    cmdM.CommandText = strSql
                    conM.Open()
                    Dim drM As SqlDataReader
                    drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    If drM.HasRows Then
                        While drM.Read()
                            strSql = "Delete From tblVendasCombo WHERE (IDVendaMovto = " & NuloInteger(drM.Item("IDVendaMovto")) & ")"
                            ExecutaStrServidor(strSql)

                            strSql = "Delete From tblVendasComent WHERE (IDVendaMovto = " & NuloInteger(drM.Item("IDVendaMovto")) & ")"
                            ExecutaStrServidor(strSql)
                        End While
                    End If

                    strSql = "Delete From tblVendasMovto WHERE (IDVenda = " & NuloInteger(dr.Item("IDVenda")) & ")"
                    ExecutaStrServidor(strSql)

                    strSql = "Delete From tblVendasPagto WHERE (IDVenda = " & NuloInteger(dr.Item("IDVenda")) & ")"
                    ExecutaStrServidor(strSql)

                    strSql = "Delete From tblVendasSAT WHERE (IDVenda = " & NuloInteger(dr.Item("IDVenda")) & ")"
                    ExecutaStrServidor(strSql)

                    cmdM.Dispose()
                    drM.Close()
                    conM.Dispose()
                    conM.Close()
                End While
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

            strSql = "Delete From tblVendas WHERE (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)

        Catch ex As Exception

        End Try

    End Sub
    Public Sub LimpaVendasServidor(IDFec As Integer)

        Dim con As New SqlConnection()
        con.ConnectionString = strConServer

        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select * from tblRetVendas WHERE (IDLoja=" & IDLoja & ") AND (IDFechamento=" & IDFec & ")"
        cmd.CommandText = strSql

        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read()
                Dim conM As New SqlConnection()
                conM.ConnectionString = strConServer
                Dim cmdM As SqlCommand = conM.CreateCommand
                strSql = "Select * from tblRetVendasMovto WHERE IDVendaRet=" & NuloInteger(dr.Item("IDVendaRet"))
                cmdM.CommandText = strSql
                conM.Open()
                Dim drM As SqlDataReader
                drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If drM.HasRows Then
                    While drM.Read()
                        strSql = "Delete From tblRetVendasCombo WHERE (IDVendaRetMovto = " & NuloInteger(drM.Item("IDVendaRetMovto")) & ")"
                        ExecutaStrServidor(strSql)

                        strSql = "Delete From tblRetVendasComent WHERE (IDRetVendaMovto = " & NuloInteger(drM.Item("IDVendaRetMovto")) & ")"
                        ExecutaStrServidor(strSql)
                    End While
                End If

                strSql = "Delete From tblRetVendasMovto WHERE (IDVendaRet = " & NuloInteger(dr.Item("IDVendaRet")) & ")"
                ExecutaStrServidor(strSql)

                strSql = "Delete From tblRetVendasPagto WHERE (IDVendaRet = " & NuloInteger(dr.Item("IDVendaRet")) & ")"
                ExecutaStrServidor(strSql)

                strSql = "Delete From tblRetVendasSAT WHERE (IDVendaRet = " & NuloInteger(dr.Item("IDVendaRet")) & ")"
                ExecutaStrServidor(strSql)

                strSql = "Delete From tblPendencias WHERE (IDVendaRet = " & NuloInteger(dr.Item("IDVendaRet")) & ")"
                ExecutaStrServidor(strSql)

                cmdM.Dispose()
                drM.Close()
                conM.Dispose()
                conM.Close()
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        strSql = "Delete From tblRetVendas WHERE (IDLoja=" & IDLoja & ") AND (IDFechamento=" & IDFec & ")"
        ExecutaStrServidor(strSql)

    End Sub
    Public Sub LimpaBancoLocal(IDFec As Integer)
        '1 - Todas as vendas (IDFec = 0)
        '2 - De um determinado fechamento (IDFec <> 0)

        If IDFec <> 0 Then
            Dim con As New SqlConnection()
            con.ConnectionString = strCon
            Dim cmd As SqlCommand = con.CreateCommand
            strSql = "Select * from tblVendas "
            strSql += "WHERE IDFechamento=" & IDFec
            cmd.CommandText = strSql
            con.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While dr.Read()
                    Dim conM As New SqlConnection()
                    conM.ConnectionString = strCon
                    Dim cmdM As SqlCommand = conM.CreateCommand
                    strSql = "Select * from tblVendasMovto WHERE IDVenda=" & NuloInteger(dr.Item("IDVenda"))
                    cmdM.CommandText = strSql
                    conM.Open()
                    Dim drM As SqlDataReader
                    drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    If drM.HasRows Then
                        While drM.Read()
                            strSql = "Delete From tblVendasComent WHERE (IDVendaMovto = " & NuloInteger(drM.Item("IDVendaMovto")) & ")"
                            ExecutaStr(strSql)

                            Dim conC As New SqlConnection()
                            conC.ConnectionString = strCon
                            Dim cmdC As SqlCommand = conC.CreateCommand
                            strSql = "Select * from tblVendasCombo WHERE IDVendaMovto=" & NuloInteger(drM.Item("IDVendaMovto"))
                            cmdC.CommandText = strSql
                            conC.Open()
                            Dim drc As SqlDataReader
                            drc = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                            If drc.HasRows Then
                                While drc.Read()
                                    strSql = "Delete From tblVendasComent WHERE (IDVendaCombo = " & NuloInteger(drc.Item("IDVendaCombo")) & ")"
                                    ExecutaStr(strSql)
                                End While
                            End If
                            cmdC.Dispose()
                            drc.Close()
                            conC.Dispose()
                            conC.Close()

                            strSql = "Delete From tblVendasCombo WHERE (IDVendaMovto = " & NuloInteger(drM.Item("IDVendaMovto")) & ")"
                            ExecutaStr(strSql)

                        End While

                        strSql = "Delete From tblVendasMovto WHERE (IDVenda = " & NuloInteger(dr.Item("IDVenda")) & ")"
                        ExecutaStr(strSql)

                        strSql = "Delete From tblVendasPagto WHERE (IDVenda = " & NuloInteger(dr.Item("IDVenda")) & ")"
                        ExecutaStr(strSql)

                        strSql = "Delete From tblVendasSAT WHERE (IDVenda = " & NuloInteger(dr.Item("IDVenda")) & ")"
                        ExecutaStr(strSql)
                    End If
                    cmdM.Dispose()
                    drM.Close()
                    conM.Dispose()
                    conM.Close()
                End While

                strSql = "Delete From tblVendas WHERE (IDFechamento=" & IDFec & ")"
                ExecutaStr(strSql)

            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()
        Else
            strSql = "Delete From tblVendas"
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasMovto"
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasCombo"
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasComent"
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasPagto"
            ExecutaStr(strSql)

            strSql = "Delete From tblVendasSAT"
            ExecutaStr(strSql)

        End If

    End Sub
    Public Sub InformaStatusTablet(MsgTablet As String)

        strSql = "INSERT tblStatusTablet (StatusTablet) VALUES (" & MsgTablet & ")"
        ExecutaStr(strSql)

    End Sub
    Public Sub AbreVenda(NumMesa As Integer, PDesconto As Decimal, PServico As Decimal, Garcon As String, IDFunc As Integer, QtdePess As Integer, StatusMesa As String)
        AchaNumVenda(StatusMesa)
        strSql = "INSERT tblVendas "
        strSql &= "(NumVenda,  NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Enviado, Excluido, IDFuncionarioAtendente) VALUES ("
        strSql &= to_sql(NumVenda) & ","
        strSql &= to_sql(NumMesa) & ","
        strSql += "'" & Date.Now & "',"
        strSql &= to_sql(Replace(NuloString(NuloDecimal(PDesconto)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(PServico)), ",", ".")) & ","
        strSql &= to_sql(QtdePess) & ","
        strSql &= to_sql(0) & ","
        strSql += "'" & Date.Now & "',"
        strSql &= to_sql(StatusMesa) & ","
        strSql &= to_sql(Caixa) & ","
        strSql &= to_sql(Garcon) & ","
        strSql &= "0,"
        strSql &= "0,"
        strSql &= to_sql(IDFunc) & ")"
        PercServico = PServico
        ExecutaStr(strSql)

        IDVenda = PegaID("IDVenda", "tblVendas", "L")

    End Sub

    Public Sub AbreVendaDelivery(PDesconto As Decimal, PServico As Decimal, Atendent As String, IDFunc As Integer, IDCli As Integer, IDRuaEnt As Integer, CepEnt As String, NumeroEnt As String, AreaEnt As String, ComplementoEnt As String, ReferenciaEnt As String, ComentProd As String, ComentExp As String, NomeCli As String, Troco As Decimal, PedidoProg As Boolean, IDvdaExt As String, LogradouroEnt As String)

        Dim txEntrega As Decimal
        'strSql = "SELECT Area, TaxaEntrega FROM tblAreas WHERE Area=" & AreaEnt
        'txEntrega = NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon))
        txEntrega = NuloDecimal(frmDelivery.lbTaxaEntregaEntrega.Text)

        AchaNumVenda("D")
        strSql = "INSERT tblVendas "
        strSql &= "(NumVenda, NumVendaD, NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Enviado, Excluido, IDFuncionarioAtendente, "
        strSql &= "IDCliente, NomeCliente, IDRuaEntrega, CepEntrega, NumeroEntrega, AreaEntrega, ComplementoEntrega, ReferenciaEntrega, ComentProducao, ComentExpedicao, Troco, TaxaEntrega, Desconto, TotalProdutos, TotalVenda, Caixinha, PreNota, "
        strSql &= "PedidoProg, PedidoProgAutomatico, PedidoProgEnvioAs, PedidoProgEnviado, TipoLancto, CpfCnpj, CepPagto, NumeroPagto, ComplementoPagto, EnderecoPagtoDiferente, RuaPagto, IDVendaExterna, App, IDReferencia, IDClienteExterno, LogradouroEntrega) VALUES ("
        strSql &= to_sql(NumVenda) & ","
        strSql &= to_sql(NumVendaD) & ","
        strSql &= to_sql(0) & ","
        strSql &= "'" & Date.Now & "',"
        strSql &= to_sql(Replace(NuloString(NuloDecimal(PDesconto)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(PServico)), ",", ".")) & ","
        strSql &= "1, "
        strSql &= to_sql(0) & ","
        strSql += "'" & Date.Now & "',"
        strSql &= "'D',"
        strSql &= to_sql(Caixa) & ","
        strSql &= to_sql(Atendent) & ","
        strSql &= "0,"
        strSql &= "0,"
        strSql &= to_sql(IDFunc) & ","
        strSql &= to_sql(IDCli) & ","
        strSql &= to_sql(NomeCli) & ","
        strSql &= to_sql(IDRuaEnt) & ","
        strSql &= to_sql(CepEnt) & ","
        strSql &= to_sql(NumeroEnt) & ","
        strSql &= to_sql(AreaEnt) & ","
        strSql &= to_sql(ComplementoEnt) & ","
        strSql &= to_sql(ReferenciaEnt) & ","
        strSql &= to_sql(ComentProd) & ","
        strSql &= to_sql(ComentExp) & ", "
        strSql &= to_sql(Replace(NuloString(NuloDecimal(Troco)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(txEntrega)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(frmDelivery.txtDesconto.Text)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(frmDelivery.txtProdutos.Text)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(frmDelivery.txtTotal.Text)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(frmDelivery.lbCaixinha.Text)), ",", ".")) & ","
        strSql &= "1, "
        If PedidoProg = False Then
            strSql &= "0, 0, NULL, 0, "
        Else
            strSql &= "1, 0, NULL, 0, "
        End If
        strSql &= to_sql(NuloBoolean(frmDelivery.chkTipoLancto.Checked)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbCpfCnpj.Text)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbCepPagto.Text)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbNumeroPagto.Text)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbComplementoPagto.Text)) & ","
        strSql &= to_sql(NuloBoolean(frmDelivery.tbEnderecoEntregaDiferente.Text)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbRuaPagto.Text)) & ","
        strSql &= to_sql(NuloString(IDvdaExt)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbApp.Text)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbIDReferencia.Text)) & ","
        strSql &= to_sql(NuloString(frmDelivery.tbIDClienteExterno.Text)) & ","
        strSql &= to_sql(NuloString(LogradouroEnt)) & ")"
        'PercServico = PServico
        ExecutaStr(strSql)

        IDVenda = PegaID("IDVenda", "tblVendas", "L")
    End Sub

    Public Sub EditaVendaDelivery(PDesconto As Decimal, PServico As Decimal, Atendent As String, IDFunc As Integer, IDCli As Integer, IDRuaEnt As Integer, CepEnt As String, NumeroEnt As String, AreaEnt As String, ComplementoEnt As String, ReferenciaEnt As String, ComentProd As String, ComentExp As String, NomeCli As String, Troco As Decimal, PedidoProg As Boolean, IDvdaExt As String, LogradouroEnt As String)

        Dim txEntrega As Decimal
        'strSql = "SELECT Area, TaxaEntrega FROM tblAreas WHERE Area=" & AreaEnt
        'txEntrega = NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon))
        txEntrega = NuloDecimal(frmDelivery.lbTaxaEntregaEntrega.Text)

        Dim PNota As Integer
        strSql = "SELECT IDVenda, PreNota FROM tblVendas WHERE IDVenda=" & IDVenda
        PNota = NuloInteger(PegaValorCampo("Prenota", strSql, strCon)) + 1

        strSql = "UPDATE tblVendas SET "
        strSql &= "PercDesconto=" & Replace(NuloString(NuloDecimal(PDesconto)), ",", ".") & ","
        strSql &= "PercServico=" & Replace(NuloString(NuloDecimal(PServico)), ",", ".") & ","
        strSql &= "Atendente='" & Atendent & "',"
        strSql &= "IDFuncionarioAtendente=" & NuloInteger(IDFunc) & ","
        strSql &= "Caixa='" & Caixa & "', "
        strSql &= "IDCliente=" & IDCli & ", "
        strSql &= "IDRuaEntrega=" & IDRuaEnt & ", "
        strSql &= "CepEntrega='" & CepEnt & "', "
        strSql &= "NumeroEntrega='" & NumeroEnt & "', "
        strSql &= "AreaEntrega='" & AreaEnt & "', "
        strSql &= "ComplementoEntrega='" & ComplementoEnt & "', "
        strSql &= "ReferenciaEntrega='" & ReferenciaEnt & "', "
        strSql &= "ComentProducao='" & ComentProd & "', "
        strSql &= "ComentExpedicao='" & ComentExp & "', "
        strSql &= "NomeCliente='" & NomeCli & "', "
        strSql &= "Troco=" & Replace(NuloString(NuloDecimal(Troco)), ",", ".") & ", "
        strSql &= "TaxaEntrega=" & Replace(NuloString(NuloDecimal(txEntrega)), ",", ".") & ", "
        strSql &= "Desconto=" & Replace(NuloString(NuloDecimal(frmDelivery.txtDesconto.Text)), ",", ".") & ", "
        strSql &= "TotalProdutos=" & Replace(NuloString(NuloDecimal(frmDelivery.txtProdutos.Text)), ",", ".") & ", "
        strSql &= "TotalVenda=" & Replace(NuloString(NuloDecimal(frmDelivery.txtTotal.Text)), ",", ".") & ", "
        strSql &= "PreNota=" & NuloInteger(PNota) & ","
        strSql &= "Caixinha=" & Replace(NuloString(NuloDecimal(frmDelivery.lbCaixinha.Text)), ",", ".") & ", "
        If PedidoProg = False Then
            strSql &= "PedidoProg=0, PedidoProgAutomatico=0, PedidoProgEnvioAs=NULL,"
        Else
            strSql &= "PedidoProg=1,"
        End If
        strSql &= "TipoLancto='" & NuloBoolean(frmDelivery.chkTipoLancto.Checked) & "', "
        strSql &= "CpfCnpj='" & NuloString(frmDelivery.tbCpfCnpj.Text) & "', "
        strSql &= "CepPagto='" & NuloString(frmDelivery.tbCepPagto.Text) & "', "
        strSql &= "NumeroPagto='" & NuloString(frmDelivery.tbNumeroPagto.Text) & "', "
        strSql &= "ComplementoPagto='" & NuloString(frmDelivery.tbComplementoPagto.Text) & "', "
        strSql &= "RuaPagto='" & NuloString(frmDelivery.tbRuaPagto.Text) & "', "
        strSql &= "BairroPagto='" & NuloString(frmDelivery.tbBairroPagto.Text) & "', "
        strSql &= "EnderecoPagtoDiferente='" & NuloBoolean(frmDelivery.tbEnderecoEntregaDiferente.Text) & "',"
        strSql &= "IDVendaExterna='" & NuloString(IDvdaExt) & "',"
        strSql &= "App='" & NuloString(frmDelivery.tbApp.Text) & "', "
        strSql &= "LogradouroEntrega='" & NuloString(LogradouroEnt) & "' "
        strSql &= "WHERE (IDVenda=" & IDVenda & ")"

        ExecutaStr(strSql)
        PercServico = PServico

    End Sub

    Public Sub EditaVenda(PDesconto As Decimal, PServico As Decimal, Garcon As String, IDFunc As Integer, QtdePess As Integer, StVenda As String)

        strSql = "UPDATE tblVendas SET "
        strSql &= "PercDesconto=" & Replace(NuloString(NuloDecimal(PDesconto)), ",", ".") & ","
        strSql &= "PercServico=" & Replace(NuloString(NuloDecimal(PServico)), ",", ".") & ","
        strSql &= "QtdPessoas=" & QtdePess & ","
        strSql &= "Atendente='" & Garcon & "',"
        strSql &= "IDFuncionarioAtendente=" & NuloInteger(IDFunc) & ","
        If StVenda <> "B" And StVenda <> "S" And StVenda <> "D" And StVenda <> "P" Then
            strSql &= "StatusVenda='S', "
        Else
            strSql &= "StatusVenda='" & StVenda & "', "
        End If
        strSql &= "Caixa='" & Caixa & "' "
        strSql &= "WHERE (IDVenda=" & IDVenda & ")"
        ExecutaStr(strSql)
        PercServico = PServico

        AcertaServico(IDVenda, PServico)
    End Sub
    Public Sub StiloGrid()
        For i As Integer = 0 To frmSalao.Grid.Rows.Count - 1
            If PedidoVenda = False Then
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "M" Then
                    frmSalao.Grid.Rows(i).Cells(1).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(2).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                    frmSalao.Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                End If
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "MC" Then
                    frmSalao.Grid.Rows(i).Cells(1).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(2).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                    frmSalao.Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                End If
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "PC" Then
                    frmSalao.Grid.Rows(i).Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Regular)
                    frmSalao.Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 8, FontStyle.Regular)
                End If
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "P" Then
                    frmSalao.Grid.Rows(i).Cells(0).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(1).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(2).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(3).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(4).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(5).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(6).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(7).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(8).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(9).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(10).Style.BackColor = Color.PeachPuff
                    frmSalao.Grid.Rows(i).Cells(11).Style.BackColor = Color.PeachPuff
                End If
            Else
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "M" Then
                    frmSalao.Grid.Rows(i).Cells(1).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(2).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                    frmSalao.Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                End If
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "MC" Then
                    frmSalao.Grid.Rows(i).Cells(1).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(2).Style.ForeColor = Color.Gray
                    frmSalao.Grid.Rows(i).Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                    frmSalao.Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 8, FontStyle.Italic)
                End If
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "PC" Then
                    frmSalao.Grid.Rows(i).Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Regular)
                    frmSalao.Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 8, FontStyle.Regular)
                End If
                If NuloString(frmSalao.Grid.Rows(i).Cells(5).Value) = "P" Then
                    frmSalao.Grid.Rows(i).Cells(0).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(1).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(2).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(3).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(4).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(5).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(6).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(7).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(8).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(9).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(10).Style.BackColor = Color.SandyBrown
                    frmSalao.Grid.Rows(i).Cells(11).Style.BackColor = Color.SandyBrown
                End If
            End If
        Next
    End Sub

    Public Sub StiloGridDelivery()
        Dim ID As Integer = 0
        Dim TipoLinha As Integer = 0
        For i As Integer = 0 To frmDelivery.GridDel.Rows.Count - 1
            If NuloInteger(frmDelivery.GridDel.Item(0, i).Value) <> ID Then
                If TipoLinha = 0 Then
                    TipoLinha = 1
                Else
                    TipoLinha = 0
                End If
                ID = NuloInteger(frmDelivery.GridDel.Item(0, i).Value)
            End If

            'If PedidoVenda = False Then
            If NuloBoolean(frmDelivery.GridDel.Item(24, i).Value) = True Then
                If NuloInteger(frmDelivery.GridDel.Item(1, i).Value) <> 0 Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.ForeColor = Color.DarkBlue
                Else
                    If NuloString(frmDelivery.GridDel.Item(5, i).Value) = "MC" Or NuloString(frmDelivery.GridDel.Item(5, i).Value) = "M" Then
                        frmDelivery.GridDel.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    Else
                        frmDelivery.GridDel.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    End If
                End If
                If TipoLinha = 0 Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.BackColor = Color.SeaGreen
                Else
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.BackColor = Color.MediumSeaGreen
                End If


                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "M" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Bold)
                End If
                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "MC" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Italic)
                End If
                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "PC" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Italic)
                End If
                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "P" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                End If

            Else
                If NuloInteger(frmDelivery.GridDel.Item(1, i).Value) <> 0 Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.ForeColor = Color.DarkBlue
                Else
                    If NuloString(frmDelivery.GridDel.Item(5, i).Value) = "MC" Or NuloString(frmDelivery.GridDel.Item(5, i).Value) = "M" Then
                        frmDelivery.GridDel.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    Else
                        frmDelivery.GridDel.Rows(i).DefaultCellStyle.ForeColor = Color.SlateBlue
                    End If
                End If
                If TipoLinha = 0 Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.BackColor = Color.Silver
                Else
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                End If

                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "M" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Bold)
                End If

                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "MC" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Italic)
                End If

                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "PC" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 7, FontStyle.Italic)
                End If

                If NuloString(frmDelivery.GridDel.Rows(i).Cells(5).Value) = "P" Then
                    frmDelivery.GridDel.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                End If

            End If
        Next
    End Sub

    Public Sub PaginaTeste(Impress As String, Categ As String, Modu As String, Guilho As Boolean)
        Dim lngFile As Integer = FreeFile()

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\pedido.txt", OpenMode.Output)

        PrintLine(lngFile, "TESTE DE IMPRESSAO")
        PrintLine(lngFile, "==========================================")
        'PrintLine(lngFile, ChrW(27) + ChrW(14) + ChrW(27) + ChrW(86) + "Impressora : " & Impress)
        PrintLine(lngFile, "Impressora : " & Impress)
        PrintLine(lngFile, "Categoria  : " & Categ)
        PrintLine(lngFile, "Modulo     : " & Modu)
        PrintLine(lngFile, "==========================================")
        PrintLine(lngFile, "TESTE")
        PrintLine(lngFile, "TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE TESTE TESTE  TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE TESTE")
        PrintLine(lngFile, "TESTE TESTE")
        PrintLine(lngFile, "TESTE")
        PrintLine(lngFile, "==========================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        FileClose(lngFile)

        If ClassPrint.RawPrinterHelper.SendFileToPrinter(Impress, Application.StartupPath & "\Impressao\pedido.txt") = True Then
            If Guilho = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(Impress, Chr(27) & Chr(109))
            End If
            MsgBox("Pagina teste enviada com 'SUCESSO'", MsgBoxStyle.Information)
        Else
            MsgBox("'FALHA' na impressão da pagina teste", MsgBoxStyle.Information)
        End If

    End Sub
    Public Sub AcionaGaveta()

        Dim lngFile As Integer = FreeFile()

        'Try

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\estorno.txt", OpenMode.Output)

        PrintLine(lngFile, Chr(27) & "p")
        PrintLine(lngFile, Chr(27) & "v")


        FileClose(lngFile)
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\estorno.txt")

        'Catch ex As Exception
        ''MsgBox(ex.Message)
        'End Try
    End Sub

    Function VerificaPermissaoModulos() As String
        Dim DataUltAcess As DateTime
        Dim DataUltAcessTxt As String
        Dim con As New SqlConnection()

        strSql = "Select iris.tblEquipamentos.Salao, iris.tblEquipamentos.Balcao, iris.tblEquipamentos.Delivery, iris.tblEquipamentos.EquipamentoID, iris.tblEquipamentos.Definitivo, iris.tblEquipamentos.TerminalVenda, iris.tblEquipamentos.Descricao, iris.tblEquipamentos.LojaID, MAX(iris.tblLiberacoes.DataLiberadoAte) As LiberadoAte, iris.tblEquipamentos.HD, iris.tblEquipamentos.FuncaoI, iris.tblEquipamentos.VersaoProtec, iris.tblEquipamentos.Registro, iris.tblEquipamentos.DataUltimoAcesso, iris.tblEquipamentos.TerminalExpedicao "
        strSql += "From iris.tblEquipamentos LEFT OUTER Join iris.tblLiberacoes ON iris.tblEquipamentos.EquipamentoID = iris.tblLiberacoes.EquipamentoID "
        strSql += "Group By iris.tblEquipamentos.EquipamentoID, iris.tblEquipamentos.Descricao, iris.tblEquipamentos.LojaID, iris.tblEquipamentos.Salao, iris.tblEquipamentos.Balcao, iris.tblEquipamentos.Delivery, iris.tblEquipamentos.Definitivo, iris.tblEquipamentos.TerminalVenda, iris.tblEquipamentos.HD, iris.tblEquipamentos.VersaoProtec, iris.tblEquipamentos.FuncaoI, iris.tblEquipamentos.Registro, iris.tblEquipamentos.DataUltimoAcesso, iris.tblEquipamentos.TerminalExpedicao "
        strSql += "HAVING(iris.tblEquipamentos.EquipamentoID=" & EquipamentoIRIS & ") AND (iris.tblEquipamentos.LojaID=" & IDLoja & ")"


        ModulosIRIS = ""

        Dim dr As SqlDataReader
        con.ConnectionString = strConIRIS
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()

            'MsgBox(NuloBoolean(dr.Item("TerminalVenda")))

            If NuloBoolean(dr.Item("Salao")) = True Then
                ModulosIRIS = "S"
            End If
            If NuloBoolean(dr.Item("Balcao")) = True Then
                ModulosIRIS += "B"
            End If
            If NuloBoolean(dr.Item("Delivery")) = True Then
                ModulosIRIS += "D"
            End If
            If NuloBoolean(dr.Item("TerminalVenda")) = True Then
                TerminalVenda = True
                EscreveINI("Geral", "TerminalVenda", "1", nome_arquivo_ini)
            Else
                TerminalVenda = False
                EscreveINI("Geral", "TerminalVenda", "0", nome_arquivo_ini)
            End If
            If NuloBoolean(dr.Item("TerminalExpedicao")) = True Then
                TerminalExpedicao = True
                EscreveINI("Geral", "TerminalExpedicao", "1", nome_arquivo_ini)
            Else
                TerminalExpedicao = False
                EscreveINI("Geral", "TerminalExpedicao", "0", nome_arquivo_ini)
            End If
            RegistroDefinitivo = NuloBoolean(dr.Item("Definitivo"))
            If NuloBoolean(dr.Item("Definitivo")) = True Then
                EscreveINI("Geral", "ModulosD", "1", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "ModulosD", "0", nome_arquivo_ini)
            End If
            NomeTerminal = NuloString(dr.Item("Descricao"))
            EscreveINI("Geral", "NomeTerminal", NomeTerminal, nome_arquivo_ini)

            IDTerminal = NuloInteger(dr.Item("EquipamentoID"))
            FuncaoI = NuloBoolean(dr.Item("FuncaoI"))
            EscreveINI("Geral", "Modulos", ModulosIRIS, nome_arquivo_ini)


            If RegistroDefinitivo = False Then
                If Not IsDBNull(dr.Item("DataUltimoAcesso")) And NuloString(dr.Item("DataUltimoAcesso")) <> "" Then
                    DataUltAcess = CDate(dr.Item("DataUltimoAcesso"))
                    DataUltAcessTxt = CDate(dr.Item("DataUltimoAcesso")).ToString
                    DataLiberado = CDate(dr.Item("LiberadoAte"))
                    If Now < DataUltAcess Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "A data do ultimo acesso foi " & vbCrLf & DataUltAcessTxt & vbCrLf & "superior a data atual do sistema" & vbCrLf & Now & vbCrLf & "Será necessário ajustar a data do sistema" & vbCrLf & "O software Gourmet Visual será abortado"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        End
                    End If
                End If
            End If
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "ERRO ao identificar o terminal " & vbCrLf & vbCrLf & "Equipamento=" & EquipamentoIRIS & vbCrLf & "Loja=" & IDLoja
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            End
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Return ModulosIRIS

    End Function

    Function AbreVendaBalcao() As Boolean
        Dim Retorno As Boolean = False
        Dim con As New SqlConnection(strCon)

        NumMesa = AchaNumVenda("B")

        strSql = "INSERT tblVendas "
        strSql &= "(NumVenda, NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Enviado, Excluido, IDFuncionarioAtendente) VALUES ("
        strSql &= to_sql(NumMesa) & ","
        strSql &= "0,"
        strSql &= "'" & Date.Now & "',"
        strSql &= "0,"
        strSql &= "0,"
        strSql &= "1,"
        strSql &= "0,"
        strSql &= "'" & Date.Now & "',"
        strSql &= to_sql(Modulo) & ","
        strSql &= to_sql(Caixa) & ","
        strSql &= to_sql(Operador) & ","
        strSql &= "0,"
        strSql &= "0,"
        strSql &= to_sql(IDOperador) & ")"
        PercServico = 0
        Try
            con.Open()
            Dim comando As New SqlCommand(strSql, con)
            comando.CommandType = CommandType.Text
            comando.ExecuteNonQuery()
            comando.Dispose()
            Retorno = True

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Dispose()
            con.Close()
        End Try

        Return Retorno

    End Function
    Function VerificaVendaBalcao() As Integer

        Dim Retorno As Integer
        Dim con As New SqlConnection()
        strSql = "Select * From tblVendas WHERE (StatusVenda='B') AND (FlagFechada=0) AND (Excluido=0) AND (IDFuncionarioAtendente=" & IDOperador & ")"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            Retorno = NuloInteger(dr.Item("NumVenda"))
            NumMesa = NuloInteger(dr.Item("NumVenda"))
            frmSalao.tbMesa.Text = NumMesa.ToString
            IDVenda = NuloInteger(dr.Item("IDVenda"))
            PercDesconto = NuloDecimal(dr.Item("PercDesconto"))
            PercServico = NuloDecimal(dr.Item("PercServico"))
        Else
            Retorno = 0
            IDVenda = 0
            NumMesa = 0
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Return Retorno

    End Function
    Function AchaNumVenda(stVenda As String) As Integer

        Dim NVenda As Integer
        Dim NVendaD As Integer
        Dim con As New SqlConnection()

        strSql = "Select MAX(NumVenda) As NVenda, MAX(NumVendaD) As NVendaD From tblVendas WITH (TABLOCKX)"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            NVenda = NuloInteger(dr.Item("NVenda")) + 1
            If stVenda = "D" Then
                NVendaD = NuloInteger(dr.Item("NVendaD")) + 1
            End If
        Else
            NVenda = 1
            If stVenda = "D then" Then
                NVendaD = 1
            Else
                NVendaD = 0
            End If
            NVendaD = 1
        End If

        NumVenda = NVenda
        NumVendaD = NVendaD

        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Return NumVenda

    End Function
    Function InserirItemVenda(IDVenda As Integer, IDProduto As Integer, Produto As String, Quanti As Decimal, Enviado As Boolean, Venda As Decimal, VendaServico As Decimal, Categoria As String, HoraPedido As DateTime, IDFuncionario As Integer, Atendente As String, IDGrupo As Integer, Grupo As String, Excluido As Boolean, Motiv As String, Impr As Boolean, StTransf As String, Termi As String, NImpr As Boolean, SetImpr As Integer, ComServico As Boolean, ImpImp As Boolean) As Boolean
        Dim Executado As Boolean = False

        strSql = "INSERT tblVendasMovto "
        strSql += "(IDVenda,IDProduto,Produto,Qtd,Enviado,Venda,VendaServico,Categoria,HoraPedido,IDFuncionario,Atendente,IDGrupo,Grupo,Excluido,MotivoEstorno,Impresso,StatusTransf,Terminal,Imprime,SetorImpressao,MesaCartao,ComServico,EmEspera,ImprimeImpressora) VALUES ("
        strSql += to_sql(IDVenda) & ","
        strSql += to_sql(IDProduto) & ","
        strSql += to_sql(Produto) & ","
        strSql += to_sql(Replace(Quanti.ToString, ",", ".")) & ","
        strSql += to_sql(Enviado) & ","
        strSql += to_sql(Replace(Venda.ToString, ",", ".")) & ","
        strSql += to_sql(Replace(VendaServico.ToString, ",", ".")) & ","
        strSql += to_sql(Categoria) & ","
        strSql += to_sql(HoraPedido.ToString) & ","
        strSql += to_sql(IDFuncionario) & ","
        strSql += to_sql(Atendente) & ","
        strSql += to_sql(IDGrupo) & ","
        strSql += to_sql(Grupo) & ","
        strSql += to_sql(Excluido) & ","
        strSql += to_sql(Motiv) & ","
        If PedidoDeliveryProgramado = False Then
            strSql += "0,"
        Else
            strSql += "1,"
        End If
        strSql += to_sql(StTransf) & ","
        strSql += to_sql(Termi) & ","
        strSql += to_sql(NImpr) & ","
        strSql += to_sql(SetImpr) & ","
        strSql += to_sql(MesaCartao) & ","
        strSql += to_sql(ComServico) & ","
        strSql += "0,"
        strSql += "1)"
        ExecutaStr(strSql)

        Return Executado

    End Function
    Function PegaValorCampo(Campo As String, str_Sql As String, str_con As String) As String

        Dim conPega As New SqlConnection()
        Dim Retorno As String

        Dim drPega As SqlDataReader
        conPega.ConnectionString = str_con
        Dim cmdPega As SqlCommand = conPega.CreateCommand
        cmdPega.CommandText = str_Sql

        Try

            conPega.Open()
            drPega = cmdPega.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drPega.HasRows Then
                drPega.Read()
                Retorno = NuloString(drPega.Item(Campo))
            Else
                Retorno = ""
            End If
            drPega.Close()
            cmdPega.Dispose()
            conPega.Dispose()
            conPega.Close()

        Catch ex As Exception
            Retorno = "ERRO"
        End Try

        Return Retorno
    End Function
    Function PegaID(Campo As String, Tabela As String, Local As String) As Integer


        Dim conPgID As New SqlConnection()
        Dim Retorno As Integer

        strSql = "Select MAX(" & Campo & ") As ID From " & Tabela & " WITH (TABLOCKX)"

        Dim drPgID As SqlDataReader
        If Local = "L" Then
            conPgID.ConnectionString = strCon
        Else
            conPgID.ConnectionString = strConServer
        End If

        Dim cmdPgID As SqlCommand = conPgID.CreateCommand
        cmdPgID.CommandText = strSql
        conPgID.Open()
        drPgID = cmdPgID.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drPgID.HasRows Then
            drPgID.Read()
            Retorno = NuloInteger(drPgID.GetInt32(0))
        Else
            Retorno = 1
        End If
        drPgID.Close()
        cmdPgID.Dispose()
        conPgID.Dispose()
        conPgID.Close()

        Return Retorno

    End Function
    Function ExecutaStr(str_Sql As String) As Boolean

        'Dim drExe As SqlDataReader
        Dim conAtu As New SqlConnection(strCon)
        Dim Executado As Boolean = False
        'Try
        conAtu.Open()
        Dim cmdAtu As New SqlCommand(str_Sql, conAtu)
        cmdAtu.CommandType = CommandType.Text
        cmdAtu.ExecuteNonQuery()
        'drExe = cmdAtu.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        'If drExe.HasRows Then
        Executado = True
        'End If
        cmdAtu.Dispose()
        'drExe.Close()
        conAtu.Dispose()
        conAtu.Close()

        'Catch ex As Exception
        'MsgBox(ex.Message)

        'Finally

        'End Try
        Return Executado


    End Function
    Function ExecutaStrServidor(str_Sql As String) As Boolean

        System.Threading.Thread.Sleep(100)

        Dim conAtuServer As New SqlConnection(strConServer)
        Dim Executado As Boolean = False
        'Try
        conAtuServer.Open()
        Dim cmdAtu As New SqlCommand(str_Sql, conAtuServer)
        cmdAtu.CommandType = CommandType.Text
        cmdAtu.ExecuteNonQuery()
        cmdAtu.Dispose()
        Executado = True

        'Catch ex As Exception
        'MsgBox(ex.Message)

        'Finally
        conAtuServer.Dispose()
        conAtuServer.Close()
        'End Try
        Return Executado


    End Function

    Function ExecutaStrIRIS(str_Sql As String) As Integer

        Dim conAtu As New SqlConnection(strConIRIS)
        Dim Executado As Boolean = False
        Dim RegistrosAfetados As Integer = 0
        Try
            conAtu.Open()
            Dim cmdAtu As New SqlCommand(str_Sql, conAtu)
            cmdAtu.CommandType = CommandType.Text
            RegistrosAfetados = cmdAtu.ExecuteNonQuery()
            cmdAtu.Dispose()
            Executado = True


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            conAtu.Dispose()
            conAtu.Close()
        End Try
        Return RegistrosAfetados


    End Function
    Public Sub MontaGrid_Combo()

        Dim IDGrid As Integer = 0
        Dim Coluna As Integer = 0

        Using con As New SqlConnection
            Dim dr As SqlDataReader

            con.ConnectionString = strCon
            Dim cmd As SqlCommand = con.CreateCommand

            strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDFamilia, tblProdutos_Local.Venda, tblFamilias_Local.Familia, tblProdutos_Local.IDProduto, tblCombos_Local.Sequencia "
            strSql += "From tblProdutos_Local INNER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto LEFT OUTER Join tblFamilias_Local On tblCombos_Local.IDFamilia = tblFamilias_Local.IDFamilia "
            strSql += "Where (tblProdutos_Local.IDProduto=" & IDProdutoSel & ") "
            strSql += "Order By tblCombos_Local.Sequencia"
            cmd.CommandText = strSql

            IDGrid = 1

            'Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            While (dr.Read())
                Dim nova_linha As DataRow = fdlgCombo.DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, NuloInteger(dr.Item("IDFamilia")), Trim(NuloString(dr.Item("Familia"))), 0, String.Empty, 0, String.Empty, NuloInteger(dr(0)), NuloDecimal(0).ToString("F2")}
                fdlgCombo.DataSetGrid.Tables(0).Rows.Add(nova_linha)

                IDGrid += 1
            End While

            fdlgCombo.tbQtdeGrid.Text = NuloString(NuloInteger(IDGrid - 2))
            fdlgCombo.Grid.Rows(0).Selected = True
            fdlgCombo.IDFamiliaSel.Text = NuloString(fdlgCombo.Grid.Item(1, fdlgCombo.Grid.CurrentRow.Index).Value)
            fdlgCombo.ID_Grid.Text = NuloString(fdlgCombo.Grid.Item(0, fdlgCombo.Grid.CurrentRow.Index).Value)


            Dim somaValor As Decimal = VlrUnitario
            For i As Integer = 0 To fdlgCombo.Grid.Rows.Count - 1
                somaValor += NuloDecimal(fdlgCombo.Grid.Rows(i).Cells(8).Value)
            Next
            fdlgCombo.tbValor.Text = NuloDecimal(somaValor).ToString("F2") 'F2 = 2 Casas Decimais


            'Catch ex As Exception
            'MsgBox(ex.Message + ex.StackTrace)
            'Finally

            con.Dispose()
            con.Close()
            'End Try
            fdlgCombo.StiloGrid()
        End Using

    End Sub
    Public Sub IncluiProdGrid(IDGrid As Integer, CodProd As Integer, Prod As String, Valor As Decimal, IDCat As Integer, IDFam As Integer, IDDet As Integer, IDMont As Integer, Sta As String, Quantidade As Double, Grupo As String, Categoria As String, IDProd As Integer, Excluido As Integer, IDPai As Integer, Confirmado As Boolean)

        Dim nova_linha As DataRow
        If Modulo = "D" Then
            nova_linha = frmDelivery.DataSetGridDel.Tables(0).NewRow()
        Else
            nova_linha = frmSalao.DataSetGrid.Tables(0).NewRow()
        End If

        Dim ComServico As Boolean
        Dim Totpro As Decimal
        Dim TotproServ As Decimal
        Totpro = NuloDecimal(SemArredondar(Valor * Quantidade, 3))

        strSql = "SELECT CodigoProduto, ComServico FROM tblProdutos_Local WHERE CodigoProduto=" & CodProd
        If NuloBoolean(PegaValorCampo("ComServico", strSql, strCon)) = True And TerminalNaoCobraServico = False Then
            TotproServ = NuloDecimal(SemArredondar(Valor * ((PercServico / 100) + 1), 3))
            ComServico = True
        Else
            TotproServ = NuloDecimal(Valor)
            ComServico = False
        End If

        ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Sta = "P" Then
            nova_linha.ItemArray = New Object() {IDGrid, CodProd, Trim(Prod), Format(Quantidade, "#0.000"), IDGrid, Sta, CodProd, Format(Quantidade, "#0.000"), Valor, Format(Valor, "#0.00"), Format(Totpro, "#0.00"), Format(Totpro, "#0.00"), Operador, Date.Today, IDCat, IDFam, IDDet, IDMont, Grupo, Categoria, IDProd, Excluido, 0, IDPai, Confirmado, TotproServ, ComServico}
        End If

        ' Pedido COMBO ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Sta = "PC" Then
            nova_linha.ItemArray = New Object() {IDGrid, FamiliaSel, Trim(Prod), String.Empty, IDGrid, Sta, CodProd, Format(Quantidade, "#0.000"), Valor, String.Empty, Valor, String.Empty, frmPrincipal.Garcon.Text, Date.Today, IDCat, IDFam, IDDet, IDMont, Grupo, Categoria, CodProd, Excluido, 0, IDPai, Confirmado, TotproServ, ComServico}
        End If

        ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If Sta = "MC" Then
            nova_linha.ItemArray = New Object() {IDGrid, "---->", Trim(Prod), String.Empty, IDGrid, Sta, CodProd, 1, Valor, String.Empty, Valor, String.Empty, frmPrincipal.Garcon.Text, Date.Today, IDCat, IDFam, IDDet, IDMont, Grupo, Categoria, 0, Excluido, 0, IDPai, Confirmado, Valor, ComServico}
        End If

        If Modulo = "D" Then
            frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha)
        Else
            frmSalao.DataSetGrid.Tables(0).Rows.Add(nova_linha)
        End If

        If Modulo = "D" Then
            LinhaGridDelivery()
            'AtualizaGridDelivery()
            frmDelivery.GridDel.Rows(0).Selected = True
            CalculaTotaisDelivery()
            StiloGridDelivery()
            'frmDelivery.ColorirGrid()
        Else
            LinhaGrid()
            AtualizaGrid()
            frmSalao.Grid.Rows(0).Selected = True
            CalculaTotais()
            StiloGrid()
        End If


    End Sub

    Public Sub CalculaTotais()

        Dim TotalProd As Decimal
        Dim TotalDesc As Decimal
        Dim TotalServ As Decimal
        Dim VlrPrincipal As Decimal
        Dim VlrPrincipalServico As Decimal
        Dim dv As New DataView(frmSalao.DataSetGrid.Tables(0))
        Dim TotProd As Decimal
        Dim TotProdServico As Decimal

        With frmSalao
            If .DataSetGrid.Tables(0).Rows.Count <> 0 Then
                Dim St As String
                Dim i As Integer = 0
                Dim pro As String
                For i = 0 To dv.Count - 1
                    St = NuloString(dv.Item(i)("Status"))
                    pro = NuloString(dv.Item(i)("Produto"))
                    If St = "P" Then
                        TotProd = NuloDecimal(dv.Item(i)("VlrUnit")) * NuloDecimal(dv.Item(i)("Qtde"))
                        VlrPrincipal += NuloDecimal(TotProd)

                        TotProdServico = NuloDecimal(dv.Item(i)("VlrUnitServico")) * NuloDecimal(dv.Item(i)("Qtde"))
                        VlrPrincipalServico += NuloDecimal(TotProdServico)
                    End If
                Next

                TotalProd = NuloDecimal(Format(VlrPrincipal, "#0.00"))
                TotalDesc = NuloDecimal(Format(VlrPrincipal * (PercDesconto / 100), "#0.00"))
                TotalServ = NuloDecimal(Format(VlrPrincipalServico - VlrPrincipal, "#0.00"))
                If TotalServ < 0 Then
                    TotalServ = TotalServ * -1
                End If
            End If

            .txtProdutos.Text = Format(TotalProd, "#0.00")
            .txtDesconto.Text = Format(TotalDesc, "#0.00")
            .txtServico.Text = Format(TotalServ, "#0.00")
            .txtTotal.Text = Format(NuloDecimal(VlrPrincipal - TotalDesc + TotalServ), "#0.00")
            '.txtTotal.Text = Format(NuloDecimal(VlrPrincipalServico - TotalDesc), "#0.00")
        End With

    End Sub
    Public Sub CalculaTotaisDelivery()

        Dim TotalProd As Decimal
        Dim TotalDesc As Decimal
        Dim VlrCaixinha As Decimal
        Dim TotalServ As Decimal = NuloDecimal(frmDelivery.lbTaxaEntregaEntrega.Text)
        Dim PercDesc As Decimal = NuloDecimal(frmDelivery.tbDescontoPerc.Text)
        Dim VlrPrincipal As Decimal
        Dim dv As New DataView(frmDelivery.DataSetGridDel.Tables(0))

        frmDelivery.tbDescontoValor.Refresh()

        With frmDelivery
            VlrCaixinha = NuloDecimal(.tbCaixinha.Text)
            If .DataSetGridDel.Tables(0).Rows.Count <> 0 Then
                'VlrPrincipal = NuloDecimal(.DataSetGrid.Tables(0).Compute("SUM(VlrTotal)", String.Empty))
                Dim St As String
                Dim i As Integer = 0
                For i = 0 To dv.Count - 1
                    St = NuloString(dv.Item(i)("Status"))
                    If St = "P" Then
                        VlrPrincipal += NuloDecimal(CDec(dv.Item(i)("VlrUnit")) * CDbl(dv.Item(i)("Qtde")))
                    End If
                Next


                TotalProd = VlrPrincipal
                If NuloDecimal(frmDelivery.tbDescontoValor.Text) <> 0 Then
                    TotalDesc = NuloDecimal(frmDelivery.tbDescontoValor.Text)
                    PercDesc = (TotalDesc / VlrPrincipal) * 100
                    frmDelivery.tbDescontoPerc.Text = Format(PercDesc, "#0.000")
                End If
                TotalDesc = VlrPrincipal * (PercDesc / 100)
                'TotalServ = VlrPrincipal * (PercServico / 100)
            End If

            .txtProdutos.Text = Format(TotalProd, "#0.00")
            .txtDesconto.Text = Format(TotalDesc, "#0.00")
            .txtServico.Text = Format(TotalServ, "#0.00")
            .lbCaixinha.Text = Format(VlrCaixinha, "#0.00")
            .txtTotal.Text = Format(VlrPrincipal - TotalDesc + TotalServ + VlrCaixinha, "#0.00")
        End With

    End Sub
    Public Sub AtualizaGrid()
        If PedidoVenda = True Then
            frmSalao.Panel1.BackColor = Color.DarkCyan
            frmSalao.Panel4.BackColor = Color.DarkCyan
            frmSalao.txtTotal.BackColor = Color.DarkCyan
            frmSalao.txtProdutos.BackColor = Color.DarkCyan
            frmSalao.txtDesconto.BackColor = Color.DarkCyan
            frmSalao.txtServico.BackColor = Color.DarkCyan
        Else
            frmSalao.Panel1.BackColor = Color.Maroon
            frmSalao.Panel4.BackColor = Color.Maroon
            frmSalao.txtTotal.BackColor = Color.Maroon
            frmSalao.txtProdutos.BackColor = Color.Maroon
            frmSalao.txtDesconto.BackColor = Color.Maroon
            frmSalao.txtServico.BackColor = Color.Maroon
        End If
    End Sub
    'Public Sub AtualizaGridDelivery()
    'If PedidoVenda = True Then
    '       frmDelivery.Panel10.BackColor = Color.DarkCyan
    '       frmDelivery.Panel7.BackColor = Color.DarkCyan
    '      frmDelivery.txtTotal.BackColor = Color.DarkCyan
    '      frmDelivery.txtProdutos.BackColor = Color.DarkCyan
    '      frmDelivery.txtDesconto.BackColor = Color.DarkCyan
    '      frmDelivery.txtServico.BackColor = Color.DarkCyan
    ' Else
    '         frmDelivery.Panel10.BackColor = Color.Maroon
    '         frmDelivery.Panel4.BackColor = Color.Maroon
    '         frmDelivery.txtTotal.BackColor = Color.Maroon
    '         frmDelivery.txtProdutos.BackColor = Color.Maroon
    '         frmDelivery.txtDesconto.BackColor = Color.Maroon
    '         frmDelivery.txtServico.BackColor = Color.Maroon
    ' End If
    ' End Sub
    Public Sub LinhaGrid()

        Dim TotalLinhas As Integer
        TotalLinhas = frmSalao.DataSetGrid.Tables(0).Rows.Count

        Dim ID As String = "0"
        Dim ID_pro As String = "0"
        Dim fontProd As New Font("Sans Serif", 8, FontStyle.Bold)
        Dim fontCom As New Font("Sans Serif", 8, FontStyle.Regular)
        Dim fontDet As New Font("Sans Serif", 8, FontStyle.Italic)

        With frmSalao.Grid
            If TotalLinhas = 0 Then
                If PedidoVenda = True Then
                    .BackgroundColor = Color.Linen
                Else
                    .BackgroundColor = Color.Linen
                End If
                frmSalao.Panel4.BackColor = Color.DarkCyan
                frmSalao.txtTotal.BackColor = Color.DarkCyan
                Exit Sub
            End If
            .Sort(frmSalao.Grid.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            If TotalLinhas <> 0 Then
                ID = NuloString(.Item(0, 0).Value)

                If PedidoVenda = True Then
                    .BackgroundColor = Color.Linen
                Else
                    .BackgroundColor = Color.Linen
                End If

                For i As Integer = 0 To TotalLinhas - 1
                    If ID <> ID_pro Then
                        .Rows(i).DefaultCellStyle.Font = fontProd
                        If PedidoVenda = True Then
                            .Rows(i).DefaultCellStyle.BackColor = Color.AntiqueWhite
                        Else
                            .Rows(i).DefaultCellStyle.BackColor = Color.AntiqueWhite
                        End If
                    Else
                        .Rows(i).DefaultCellStyle.Font = fontCom
                        If PedidoVenda = True Then
                            .Rows(i).DefaultCellStyle.BackColor = Color.Linen
                        Else
                            .Rows(i).DefaultCellStyle.BackColor = Color.Linen
                        End If
                        .Rows(i).DefaultCellStyle.Font = fontCom
                        If InStr(1, NuloString(.Item(7, i).Value), "M") <> 0 Then
                            .Rows(i).DefaultCellStyle.Font = fontDet
                            .Rows(i).DefaultCellStyle.ForeColor = Color.SaddleBrown
                        End If
                    End If

                    If NuloString(.Item(2, i).Value) = ">>>>>>" Then
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    End If

                    ID = NuloString(.Item(0, i).Value)
                    If i + 1 < TotalLinhas Then
                        ID_pro = NuloString(.Item(0, i + 1).Value)
                    Else
                        ID_pro = NuloString(.Item(0, i).Value)
                    End If

                    If NuloBoolean(.Item(20, i).Value) = True Then
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next i
            Else
                With frmSalao
                    .txtProdutos.Text = "0,00"
                    .txtDesconto.Text = "0,00"
                    .txtServico.Text = "0,00"
                    .txtTotal.Text = "0,00"
                    .DataSetGrid.Clear()
                End With
            End If
        End With
    End Sub
    Public Sub LinhaGridDelivery()
        Dim TotalLinhas As Integer
        TotalLinhas = frmDelivery.DataSetGridDel.Tables(0).Rows.Count

        Dim ID As String = "0"
        Dim ID_pro As String = "0"
        Dim fontProd As New Font("Sans Serif", 8, FontStyle.Bold)
        Dim fontCom As New Font("Sans Serif", 8, FontStyle.Regular)
        Dim fontDet As New Font("Sans Serif", 8, FontStyle.Italic)

        With frmDelivery.GridDel
            If TotalLinhas = 0 Then
                If PedidoVenda = True Then
                    .BackgroundColor = Color.Linen
                Else
                    .BackgroundColor = Color.Linen
                End If
                frmDelivery.Panel7.BackColor = Color.DarkCyan
                frmDelivery.txtTotal.BackColor = Color.DarkCyan
                Exit Sub
            End If
            .Sort(frmDelivery.GridDel.Columns(0), System.ComponentModel.ListSortDirection.Descending)

            If TotalLinhas <> 0 Then
                ID = NuloString(.Item(0, 0).Value)

                If PedidoVenda = True Then
                    .BackgroundColor = Color.Linen
                Else
                    .BackgroundColor = Color.Linen
                End If

                For i As Integer = 0 To TotalLinhas - 1
                    If ID <> ID_pro Then
                        .Rows(i).DefaultCellStyle.Font = fontProd
                        If PedidoVenda = True Then
                            .Rows(i).DefaultCellStyle.BackColor = Color.AntiqueWhite
                        Else
                            .Rows(i).DefaultCellStyle.BackColor = Color.AntiqueWhite
                        End If
                    Else
                        .Rows(i).DefaultCellStyle.Font = fontCom
                        If PedidoVenda = True Then
                            .Rows(i).DefaultCellStyle.BackColor = Color.Linen
                        Else
                            .Rows(i).DefaultCellStyle.BackColor = Color.Linen
                        End If
                        .Rows(i).DefaultCellStyle.Font = fontCom
                        If InStr(1, NuloString(.Item(7, i).Value), "M") <> 0 Then
                            .Rows(i).DefaultCellStyle.Font = fontDet
                            .Rows(i).DefaultCellStyle.ForeColor = Color.SaddleBrown
                        End If
                    End If

                    If NuloString(.Item(2, i).Value) = ">>>>>>" Then
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    End If

                    ID = NuloString(.Item(0, i).Value)
                    If i + 1 < TotalLinhas Then
                        ID_pro = NuloString(.Item(0, i + 1).Value)
                    Else
                        ID_pro = NuloString(.Item(0, i).Value)
                    End If

                    If NuloBoolean(.Item(20, i).Value) = True Then
                        .Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next i
            Else
                With frmDelivery
                    .txtProdutos.Text = "0,00"
                    .txtDesconto.Text = "0,00"
                    .txtServico.Text = "0,00"
                    .txtTotal.Text = "0,00"
                    .DataSetGridDel.Clear()
                End With
            End If
        End With
    End Sub

    Public Function to_sql(ByVal value As Boolean) As Integer
        If value Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Function to_sql(ByVal value As Integer) As Integer
        'If DataType = "number" Then
        'Aqui eu fiquei em dúvida, verifique se deu certo...
        to_sql = value
        'Else
        'to_sql = "NULL"
        'to_sql = "" & "'" & Replace(value, "'", "''") & "'"
        'End If
        Return value
    End Function
    Function to_sql(ByVal value As Decimal) As Decimal

        to_sql = value
        'to_sql = Replace(value, ",", ".")

        'Else
        'to_sql = "NULL"
        'to_sql = "" & "'" & Replace(value, "'", "''") & "'"
        'End If
        Return value
    End Function

    Public Function to_sql(ByVal value As String) As String
        Return String.Empty & "'" & Replace(value, "'", "''") & "'"
    End Function
    Public Function to_sql(ByVal value As DateTime) As DateTime
        to_sql = value
        'If DataType = "datahora" Then
        'to_sql = "'" & CDate(value).ToString(FormatoData & " HHH:mm:ss") & "'"
        'Else
        'to_sql = "" & "'" & Replace(value, "'", "''") & "'"
        'End If
        Return value
    End Function
    Public Function to_sqlDATA(ByVal value As String, ByVal DataType As String, Local As String) As String

        If value <> "" Then
            If DataType = "data" Then
                If Local = "I" Then
                    to_sqlDATA = "'" & CDate(value).ToString(FormatoDataIRIS & " 00:00:00") & "'"
                Else
                    If Local = "R" Then
                        to_sqlDATA = "'" & CDate(value).ToString(FormatoDataRET & " 00:00:00") & "'"
                    Else
                        to_sqlDATA = "'" & CDate(value).ToString(FormatoDataLocal & " 00:00:00") & "'"
                    End If
                End If
            End If
            If DataType = "datahora" Then
                If Local = "I" Then
                    to_sqlDATA = "'" & CDate(value).ToString(FormatoDataIRIS & " HHH:mm:ss") & "'"
                Else
                    If Local = "R" Then
                        to_sqlDATA = "'" & CDate(value).ToString(FormatoDataRET & " HHH:mm:ss") & "'"
                    Else
                        to_sqlDATA = "'" & CDate(value).ToString(FormatoDataLocal & " HHH:mm:ss") & "'"
                    End If
                End If
            End If

            If DataType = "hora" Then
                to_sqlDATA = "'" & CDate(value).ToString("HHH:mm:ss") & "'"
                'Else
                'to_sqlDATA = "" & "'" & Replace(value, "'", "''") & "'"
            End If
        Else
            to_sqlDATA = "''"
        End If



    End Function

    Public Function DesmontaSenha(txtSenha As String) As String
        Dim Letra As String = ""
        Dim Tamanho As Integer = Len(txtSenha)
        Dim Maiuscula As Boolean = False

        SenhaCon = ""
        For i As Integer = 1 To Tamanho
            If UCase(Mid(txtSenha, i, 1)) = Mid(txtSenha, i, 1) Then
                Maiuscula = True
            Else
                Maiuscula = False
            End If
            If Not IsNumeric(Mid(txtSenha, i, 1)) Then
                If UCase(Mid(txtSenha, i, 1)) = "A" Then Letra = "00"
                If UCase(Mid(txtSenha, i, 1)) = "B" Then Letra = "01"
                If UCase(Mid(txtSenha, i, 1)) = "C" Then Letra = "02"
                If UCase(Mid(txtSenha, i, 1)) = "D" Then Letra = "03"
                If UCase(Mid(txtSenha, i, 1)) = "E" Then Letra = "04"
                If UCase(Mid(txtSenha, i, 1)) = "F" Then Letra = "05"
                If UCase(Mid(txtSenha, i, 1)) = "G" Then Letra = "06"
                If UCase(Mid(txtSenha, i, 1)) = "H" Then Letra = "07"
                If UCase(Mid(txtSenha, i, 1)) = "I" Then Letra = "08"
                If UCase(Mid(txtSenha, i, 1)) = "J" Then Letra = "09"
                If UCase(Mid(txtSenha, i, 1)) = "K" Then Letra = "10"
                If UCase(Mid(txtSenha, i, 1)) = "L" Then Letra = "11"
                If UCase(Mid(txtSenha, i, 1)) = "M" Then Letra = "12"
                If UCase(Mid(txtSenha, i, 1)) = "N" Then Letra = "13"
                If UCase(Mid(txtSenha, i, 1)) = "O" Then Letra = "14"
                If UCase(Mid(txtSenha, i, 1)) = "P" Then Letra = "15"
                If UCase(Mid(txtSenha, i, 1)) = "Q" Then Letra = "16"
                If UCase(Mid(txtSenha, i, 1)) = "R" Then Letra = "17"
                If UCase(Mid(txtSenha, i, 1)) = "S" Then Letra = "18"
                If UCase(Mid(txtSenha, i, 1)) = "T" Then Letra = "19"
                If UCase(Mid(txtSenha, i, 1)) = "U" Then Letra = "20"
                If UCase(Mid(txtSenha, i, 1)) = "V" Then Letra = "21"
                If UCase(Mid(txtSenha, i, 1)) = "W" Then Letra = "22"
                If UCase(Mid(txtSenha, i, 1)) = "X" Then Letra = "23"
                If UCase(Mid(txtSenha, i, 1)) = "Y" Then Letra = "24"
                If UCase(Mid(txtSenha, i, 1)) = "Z" Then Letra = "25"

                If UCase(Mid(txtSenha, i, 1)) = "&" Then Letra = "89"
                If UCase(Mid(txtSenha, i, 1)) = "=" Then Letra = "90"
                If UCase(Mid(txtSenha, i, 1)) = "/" Then Letra = "91"
                If UCase(Mid(txtSenha, i, 1)) = "\" Then Letra = "92"
                If UCase(Mid(txtSenha, i, 1)) = "@" Then Letra = "93"
                If UCase(Mid(txtSenha, i, 1)) = ":" Then Letra = "94"
                If UCase(Mid(txtSenha, i, 1)) = "-" Then Letra = "95"
                If UCase(Mid(txtSenha, i, 1)) = "_" Then Letra = "96"
                If UCase(Mid(txtSenha, i, 1)) = "?" Then Letra = "97"
                If UCase(Mid(txtSenha, i, 1)) = "," Then Letra = "98"
                If UCase(Mid(txtSenha, i, 1)) = "." Then Letra = "99"


                If Maiuscula = True Then
                    SenhaCon = SenhaCon & "+" & Letra
                Else
                    SenhaCon = SenhaCon & Letra
                End If
            Else
                If Val(Mid(txtSenha, i, 1)) = 0 Then Letra = "a"
                If Val(Mid(txtSenha, i, 1)) = 1 Then Letra = "b"
                If Val(Mid(txtSenha, i, 1)) = 2 Then Letra = "c"
                If Val(Mid(txtSenha, i, 1)) = 3 Then Letra = "d"
                If Val(Mid(txtSenha, i, 1)) = 4 Then Letra = "e"
                If Val(Mid(txtSenha, i, 1)) = 5 Then Letra = "f"
                If Val(Mid(txtSenha, i, 1)) = 6 Then Letra = "g"
                If Val(Mid(txtSenha, i, 1)) = 7 Then Letra = "h"
                If Val(Mid(txtSenha, i, 1)) = 8 Then Letra = "i"
                If Val(Mid(txtSenha, i, 1)) = 9 Then Letra = "j"
                'If Val(Mid(txtSenha, i, 1)) = 10 Then Letra = "k"

                SenhaCon = SenhaCon & Letra
            End If

        Next i
        Return SenhaCon

    End Function
    Public Function MontaSenha(txtSenha As String) As String
        Dim Letra As String = ""
        Dim Tamanho As Integer = Len(txtSenha)
        Dim Maiuscula As Boolean = False

        SenhaCon = ""
        For i As Integer = 1 To Tamanho
            If Mid(txtSenha, i, 1) = "+" Then
                Maiuscula = True
                i = i + 1
            Else
                Maiuscula = False
            End If
            If IsNumeric(Mid(txtSenha, i, 2)) Then
                If Val(Mid(txtSenha, i, 2)) = 0 Then Letra = "a"
                If Val(Mid(txtSenha, i, 2)) = 1 Then Letra = "b"
                If Val(Mid(txtSenha, i, 2)) = 2 Then Letra = "c"
                If Val(Mid(txtSenha, i, 2)) = 3 Then Letra = "d"
                If Val(Mid(txtSenha, i, 2)) = 4 Then Letra = "e"
                If Val(Mid(txtSenha, i, 2)) = 5 Then Letra = "f"
                If Val(Mid(txtSenha, i, 2)) = 6 Then Letra = "g"
                If Val(Mid(txtSenha, i, 2)) = 7 Then Letra = "h"
                If Val(Mid(txtSenha, i, 2)) = 8 Then Letra = "i"
                If Val(Mid(txtSenha, i, 2)) = 9 Then Letra = "j"
                If Val(Mid(txtSenha, i, 2)) = 10 Then Letra = "k"
                If Val(Mid(txtSenha, i, 2)) = 11 Then Letra = "l"
                If Val(Mid(txtSenha, i, 2)) = 12 Then Letra = "m"
                If Val(Mid(txtSenha, i, 2)) = 13 Then Letra = "n"
                If Val(Mid(txtSenha, i, 2)) = 14 Then Letra = "o"
                If Val(Mid(txtSenha, i, 2)) = 15 Then Letra = "p"
                If Val(Mid(txtSenha, i, 2)) = 16 Then Letra = "q"
                If Val(Mid(txtSenha, i, 2)) = 17 Then Letra = "r"
                If Val(Mid(txtSenha, i, 2)) = 18 Then Letra = "s"
                If Val(Mid(txtSenha, i, 2)) = 19 Then Letra = "t"
                If Val(Mid(txtSenha, i, 2)) = 20 Then Letra = "u"
                If Val(Mid(txtSenha, i, 2)) = 21 Then Letra = "v"
                If Val(Mid(txtSenha, i, 2)) = 22 Then Letra = "w"
                If Val(Mid(txtSenha, i, 2)) = 23 Then Letra = "x"
                If Val(Mid(txtSenha, i, 2)) = 24 Then Letra = "y"
                If Val(Mid(txtSenha, i, 2)) = 25 Then Letra = "z"

                If Val(Mid(txtSenha, i, 2)) = 89 Then Letra = "&"
                If Val(Mid(txtSenha, i, 2)) = 90 Then Letra = "="
                If Val(Mid(txtSenha, i, 2)) = 91 Then Letra = "/"
                If Val(Mid(txtSenha, i, 2)) = 92 Then Letra = "\"
                If Val(Mid(txtSenha, i, 2)) = 93 Then Letra = "@"
                If Val(Mid(txtSenha, i, 2)) = 94 Then Letra = ":"
                If Val(Mid(txtSenha, i, 2)) = 95 Then Letra = "-"
                If Val(Mid(txtSenha, i, 2)) = 96 Then Letra = "_"
                If Val(Mid(txtSenha, i, 2)) = 97 Then Letra = "?"
                If Val(Mid(txtSenha, i, 2)) = 98 Then Letra = ","
                If Val(Mid(txtSenha, i, 2)) = 99 Then Letra = "."


                If Maiuscula = True Then
                    SenhaCon = SenhaCon & UCase(Letra)
                Else
                    SenhaCon = SenhaCon & Letra
                End If

                i = i + 1
            Else
                If Mid(txtSenha, i, 1) = "a" Then Letra = "0"
                If Mid(txtSenha, i, 1) = "b" Then Letra = "1"
                If Mid(txtSenha, i, 1) = "c" Then Letra = "2"
                If Mid(txtSenha, i, 1) = "d" Then Letra = "3"
                If Mid(txtSenha, i, 1) = "e" Then Letra = "4"
                If Mid(txtSenha, i, 1) = "f" Then Letra = "5"
                If Mid(txtSenha, i, 1) = "g" Then Letra = "6"
                If Mid(txtSenha, i, 1) = "h" Then Letra = "7"
                If Mid(txtSenha, i, 1) = "i" Then Letra = "8"
                If Mid(txtSenha, i, 1) = "j" Then Letra = "9"

                SenhaCon = SenhaCon & Letra
            End If

        Next i
        Return SenhaCon
    End Function


#Region "FUNÇÕES DE CONVERSÃO"
    Private cultura_padrao As String = System.Globalization.CultureInfo.CurrentCulture.ToString

    Public Function NuloInteger(ByVal objeto As Object) As Integer

        Dim info As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name)
        Threading.Thread.CurrentThread.CurrentCulture = info
        Threading.Thread.CurrentThread.CurrentUICulture = info
        Dim style As Globalization.NumberStyles = Globalization.NumberStyles.Number Or Globalization.NumberStyles.AllowDecimalPoint Or Globalization.NumberStyles.AllowThousands

        Dim valor As Integer = 0
        If objeto Is Nothing Then Return 0

        Integer.TryParse(objeto.ToString, style, info, valor)

        info = New System.Globalization.CultureInfo(cultura_padrao)
        Threading.Thread.CurrentThread.CurrentCulture = info
        Threading.Thread.CurrentThread.CurrentUICulture = info

        Return valor

    End Function

    Public Function NuloShort(ByVal objeto As Object) As Short
        If Not IsDBNull(objeto) AndAlso Not objeto Is Nothing AndAlso objeto.ToString <> String.Empty Then
            Return CType(objeto.ToString, Short)
        Else
            Return 0
        End If
    End Function

    Public Function NuloDouble(ByVal objeto As Object) As Double
        If Not IsDBNull(objeto) AndAlso Not objeto Is Nothing AndAlso objeto.ToString <> String.Empty Then
            Return CType(objeto.ToString, Double)
        Else
            Return 0
        End If
    End Function

    Public Function NuloDecimal(ByVal objeto As Object, Optional ByVal formato As String = "") As Decimal

        If formato = String.Empty Then
            formato = System.Globalization.CultureInfo.CurrentCulture.Name
        End If

        Dim info As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(formato)
        Threading.Thread.CurrentThread.CurrentCulture = info
        Threading.Thread.CurrentThread.CurrentUICulture = info
        Dim style As Globalization.NumberStyles = Globalization.NumberStyles.Number Or Globalization.NumberStyles.AllowDecimalPoint Or Globalization.NumberStyles.AllowThousands

        Dim valor As Decimal = 0
        If objeto Is Nothing Then Return 0

        'Decimal.TryParse(objeto.ToString, valor)
        Decimal.TryParse(objeto.ToString, style, info, valor)

        info = New System.Globalization.CultureInfo(cultura_padrao)
        Threading.Thread.CurrentThread.CurrentCulture = info
        Threading.Thread.CurrentThread.CurrentUICulture = info

        'Return valor.ToString("D02", BRCulture)
        Return valor
    End Function

    Public Function NuloString(ByVal objeto As Object) As String
        If Not IsDBNull(objeto) AndAlso Not objeto Is Nothing Then
            Return CType(objeto.ToString, String)
        Else
            Return String.Empty
        End If
    End Function

    Public Function NuloBoolean(ByVal objeto As Object) As Boolean
        If Not IsDBNull(objeto) AndAlso Not objeto Is Nothing Then

            Dim retorno As Boolean
            If Boolean.TryParse(objeto.ToString, retorno) Then
                Return retorno
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
#End Region

    Public Function PegaStringConexao() As String
        Dim conexao As String

        strCon = "Server=" & EndBcoDados & ";Database=" & DTSource & ";User id=" & Usuario & ";Password =" & SenhaCon
        '"Password=Passw0rd;Persist Security Info=True;User ID=sa;Initial Catalog=restaurante;Data Source=localhost;Connect Timeout=8"

        'conexao = "Password=Passw0rd;Persist Security Info=True;User ID=linkedsystems;Initial Catalog=linkedsystems;Data Source=mssql.linkedsystems.com.br;Connect Timeout=60"
        conexao = strCon

        Return conexao
    End Function

    Public Sub DrawStringOnPictureBox(ByRef p As DrawStringOnPictureBoxParams, Optional pintura As PictureBox = Nothing)

        'we start with a new bitmap (width, height, pixelformat)
        Dim i As Bitmap

        If pintura Is Nothing Then
            i = New Bitmap(p.PictureBox.Width, p.PictureBox.Height, p.PixelFormat)
        Else
            i = New Bitmap(pintura.BackgroundImage)
        End If

        'we get a Graphics object from that image
        Dim g As Graphics = Graphics.FromImage(i)

        'this is how you set the background color of the image
        'g.Clear(p.bgColor)

        'Set the drawing font
        Dim f As Font = New Font(p.Font, p.MaxSize, FontStyle.Regular, GraphicsUnit.World)

        'Measure the text (text, font, layoutsize, stringformat)
        Dim fSize As SizeF = g.MeasureString(p.Text, f, p.LayoutSizeF, p.StringFormat)

        'Loop until the text width is less than the picturebox width (plus the border)
        Do While fSize.Width > (p.PictureBox.Width - p.BorderSize)
            'if it is wider then we decriminate the text size by one and try again
            p.MaxSize -= 1
            f = New Font(p.Font, p.MaxSize, FontStyle.Regular, GraphicsUnit.World)
            fSize = g.MeasureString(p.Text, f, p.LayoutSizeF, p.StringFormat)
        Loop

        'Loop until the text height is less than the picturebox height (plus the border)
        Do While fSize.Height > (p.PictureBox.Height - p.BorderSize)
            'if it is heigher then we decriminate the text size again my one
            p.MaxSize -= 1
            f = New Font(p.Font, p.MaxSize, FontStyle.Regular, GraphicsUnit.World)
            fSize = g.MeasureString(p.Text, f, p.LayoutSizeF, p.StringFormat)
        Loop

        'This is the DrawString method that draws the text onto the image
        'DrawString(text, font, fontsize, fontsyle, graphicsunit, Brush, XPos, YPos, StringFormat)
        g.DrawString(p.Text, f, New SolidBrush(p.foreColor), p.X, p.Y, p.StringFormat)

        'set the Image of our Picturebox to the bitmap
        p.PictureBox.Image = i

        'cleanup
        g.Dispose()
    End Sub



End Module
