Option Explicit On
Imports System.Data.SqlClient

Module Tecnospeed_NFCE
    Public NFCe 'As NFCeX.spdNFCeX
    Public NFCeDataSet 'As NFCeDataSetX.spdNFCeDataSetX
    Public ArqIni As String
    Public CertificadoSelecionado As String

    '******************************************************************************************************
    '
    '          Declaração de funções externas
    '
    '******************************************************************************************************
    'Função para ler arquivos INI usando API window
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal Secao As String, ByVal parametro As Integer, ByVal padrao As String, ByVal variavel As String, ByVal tam As Long, ByVal arquivo As String) As Long

    'Função para gravar arquivos INI usando API windows
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal Secao As String, ByVal parametro As Integer, ByVal valor As Decimal, ByVal arquivo As String) As Long

    'Função para configurar o diretório atual
    Private Declare Function SetCurrentDirectory Lib "kernel32" () 'Alias "SetCurrentDirectoryA" (ByVal lpPathName As String) As Long

    'Função auxiliar para pegar o fuso
    Private Const TIME_ZONE_ID_DAYLIGHT As Long = 2

    'Função auxiliar para pegar o fuso
    Private Structure SYSTEMTIME
        Private wYear As Integer
        Private wMonth As Integer
        Private wDayOfWeek As Integer
        Private wDay As Integer
        Private wHour As Integer
        Private wMinute As Integer
        Private wSecond As Integer
        Private wMilliseconds As Integer
    End Structure
    'Função auxiliar para pegar o fuso
    Public Structure TIME_ZONE_INFORMATION
        Public Bias As Long
        Public StandardName() As Byte  'unicode (0-based)
        Private StandardDate As SYSTEMTIME
        Public StandardBias As Long
        Public DaylightName() As Byte  'unicode (0-based)
        Private DaylightDate As SYSTEMTIME
        Public DaylightBias As Long
    End Structure
    'Função auxiliar para pegar o fuso
    Private Declare Function GetTimeZoneInformation Lib "kernel32.dll" (lpTimeZoneInformation As TIME_ZONE_INFORMATION) As Long

    Private Sub DadosdoNFCe()
        NFCeDataSet.SetCampo("Id_A03=0")
        NFCeDataSet.SetCampo("versao_A02=" + VersaoNFCE)
        NFCeDataSet.SetCampo("cUF_B02=" + EstadoNFCE)
        NFCeDataSet.SetCampo("cNF_B03=5")
        NFCeDataSet.SetCampo("natOp_B04=VENDA MERC.ADQ.REC.TERC")
        NFCeDataSet.SetCampo("mod_B06=65")
        NFCeDataSet.SetCampo("serie_B07=579")
        NFCeDataSet.SetCampo("nNF_B08=5792")
        NFCeDataSet.SetCampo("dhEmi_B09=" + Format(Now, "YYYY-MM-DDTHH:MM:SS") + GetCurrentTimeBias())
        NFCeDataSet.SetCampo("tpNF_B11=1")
        NFCeDataSet.SetCampo("idDest_B11a=1")
        NFCeDataSet.SetCampo("cMunFG_B12=" + NumeroMunicipioNFCE)
        NFCeDataSet.SetCampo("tpImp_B21=4")
        NFCeDataSet.SetCampo("tpEmis_B22=1")
        NFCeDataSet.SetCampo("cDV_B23=0")
        NFCeDataSet.SetCampo("tpAmb_B24=2")
        NFCeDataSet.SetCampo("finNFe_B25=1")
        NFCeDataSet.SetCampo("indFinal_B25a=1")
        NFCeDataSet.SetCampo("indPres_B25b=1")
        NFCeDataSet.SetCampo("procEmi_B26=0")
        NFCeDataSet.SetCampo("verProc_B27=000")
    End Sub
    Public Function GetCurrentTimeBias() As String

        Dim tzi As TIME_ZONE_INFORMATION
        Dim dwBias As Long
        Dim tmp As String

        Select Case GetTimeZoneInformation(tzi)
            Case TIME_ZONE_ID_DAYLIGHT
                dwBias = tzi.Bias + tzi.DaylightBias
            Case Else
                dwBias = tzi.Bias + tzi.StandardBias
        End Select

        tmp = "-0" & CStr(dwBias \ 60) & ":00"

        GetCurrentTimeBias = tmp

    End Function
    Private Sub DadosEmitente()
        NFCeDataSet.SetCampo("CNPJ_C02=" + CnpjNFCE)
        NFCeDataSet.SetCampo("xNome_C03=" + NomeNFCE)
        NFCeDataSet.SetCampo("xFant_C04=" + FantasiaNFCE)
        NFCeDataSet.SetCampo("xLgr_C06=" + EnderecoNFCE)
        NFCeDataSet.SetCampo("nro_C07=" + NumeroNFCE)
        NFCeDataSet.SetCampo("xCpl_C08=" + ComplementoNFCE)
        NFCeDataSet.SetCampo("xBairro_C09=" + BairroNFCE)
        NFCeDataSet.SetCampo("cMun_C10=" + NumeroMunicipioNFCE)
        NFCeDataSet.SetCampo("xMun_C11=" + MunicipioNFCE)
        NFCeDataSet.SetCampo("UF_C12=" + EstadoNFCE)
        NFCeDataSet.SetCampo("CEP_C13=" + CepNFCE)
        NFCeDataSet.SetCampo("cPais_C14=" + NumeroPaisNFCE)
        NFCeDataSet.SetCampo("xPais_C15=" + PaisNFCE)
        NFCeDataSet.SetCampo("indIEDest_E16a=9")
        NFCeDataSet.SetCampo("IE_C17=" + InscricaoEstadualNFCE)
        NFCeDataSet.SetCampo("IEST_C18=")
        NFCeDataSet.SetCampo("CRT_C21=1")
    End Sub
    Private Sub CheckConfig(ClearOutput As Boolean)
        Dim bConfig As Boolean
        If ClearOutput Then
            frmPrincipal.mmXML.Text = ""
        End If

        bConfig = True

        If NFCe.UF = "" Then
            bConfig = False
        End If

        If NFCe.CNPJ = "" Then
            bConfig = False
        End If

        If NFCe.NomeCertificado = "" Then
            bConfig = False
        End If
        If bConfig = False Then
            Err.Raise(vbObjectError + 1, "Form1", "Favor configurar o componente antes de prosseguir (via ini ou via propriedades).")
        End If

    End Sub
    Private Sub ConfiguraNFCeDataSet()
        NFCeDataSet.VersaoEsquema = "pl_009"
        NFCeDataSet.DicionarioXML = NFCe.DiretorioTemplates + "\Conversor\NFCeDataSets.xml"
    End Sub
    Public Function EfetuaVendaNFCE(IDvdaSat As Integer, IDvda As Integer, Cpf_Cnpj As String, TotalAD As Decimal, TotVenda As Decimal, TotCupom As Decimal, TxEntrega As Decimal, STVenda As String, DiaMovto As String, IDVenda As Integer, SatID As Integer, IDPagto As Integer, Local As String)

        If TotVenda <= 0 Then
            MsgBox("Total da venda inválida " & NuloString(NuloDecimal(TotVenda)))
            Exit Function
        End If

        Dim Fator As Double = TotCupom / TotVenda
        If Fator = 0 Then Fator = 1
        Dim txtEnt As String
        Dim Totpro As Decimal
        Dim TotproG As Decimal
        Dim NumItem As Integer = 1
        Dim NumVenda As Integer
        Dim NomeCliente As String = ""
        Dim Local_SAT As String = ""

        If Cpf_Cnpj <> "" Then
            Cpf_Cnpj = Replace(Cpf_Cnpj, ".", "")
            Cpf_Cnpj = Replace(Cpf_Cnpj, "-", "")
            Cpf_Cnpj = Replace(Cpf_Cnpj, "/", "")
        End If

        Dim XXX As String = DatePart("d", DiaMovto)
        If STVenda <> "Delivery" Then
            Call CriaDiretorio(UCase(Format(Convert.ToDateTime(DiaMovto), "MMMM")), Format(Convert.ToDateTime(DiaMovto), "yyyy"), New String("0", 2 - Len(XXX)) & XXX)
        Else
            Call CriaDiretorio(UCase(Format(Convert.ToDateTime(DiaMovto), "MMMM")), Format(Convert.ToDateTime(DiaMovto), "yyyy"), New String("0", 2 - Len(XXX)) & XXX)
        End If

        If Local = "L" Then
            strSql = "Select tblVendasSAT.IDVendaSAT, tblVendas.IDVenda, tblVendas.TotalProdutos, tblVendas.TotalVenda, tblVendas.D_A, tblVendas.Troco, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.Caixinha, tblVendas.FlagFechada, tblVendas.StatusVenda, tblVendas.TaxaEntrega, tblVendas.Dinheiro, tblVendasSAT.Num_SAT, tblVendasSAT.NumSAT, tblVendasSAT.ValorCupom, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Venda, tblVendasMovto.Excluido As ProdutoExcluido, tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoNCM, tblProdutos_Local.CodigoCEST, tblProdutos_Local.CST_PIS, tblProdutos_Local.CST_COFINS, tblProdutos_Local.CST_ICMS, tblProdutos_Local.CFOP, tblProdutos_Local.Aliquota, tblVendas.IDSat, tblProdutos_Local.pPIS, tblProdutos_Local.pCOFINS, tblVendas.NumVenda, tblVendas.NomeCliente, tblVendasCombo.IDVendaMovto As IDVendaMovtoCombo, CASE WHEN AgregaValor = 1 THEN SUM(tblVendasCombo.Qtd) Else tblVendasMovto.Qtd End As QtdeCombo, tblVendasCombo.AgregaValor, tblVendasMovto.Qtd "
            strSql += "From tblVendas INNER Join tblVendasSAT On tblVendas.IDVenda = tblVendasSAT.IDVenda INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
            strSql += "Group By tblVendas.IDVenda, tblVendas.TotalProdutos, tblVendas.TotalVenda, tblVendas.D_A, tblVendas.Troco, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.Caixinha, tblVendas.StatusVenda, tblVendas.TaxaEntrega, tblVendas.Dinheiro, tblVendasSAT.Num_SAT, tblVendasSAT.NumSAT, tblVendasSAT.ValorCupom, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.Excluido, tblVendas.FlagFechada, tblVendasSAT.IDVendaSAT, tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoNCM, tblProdutos_Local.CodigoCEST, tblProdutos_Local.CST_PIS, tblProdutos_Local.CST_COFINS, tblProdutos_Local.CST_ICMS, tblProdutos_Local.CFOP, tblProdutos_Local.Aliquota, tblVendas.IDSat, tblProdutos_Local.pPIS, tblProdutos_Local.pCOFINS, tblVendasSAT.IDVendaSAT, tblVendas.NumVenda, tblVendas.NomeCliente, tblVendasCombo.IDVendaMovto, tblVendasCombo.AgregaValor, tblVendasMovto.Qtd "
            strSql += "HAVING(tblVendasMovto.Excluido = 0) AND (tblVendasSAT.IDVendaSat = " & IDvdaSat & ") "
            If IDPagto = 0 And STVenda <> "Delivery" Then
                strSql += "And (tblVendas.FlagFechada = 1)  "
            End If
            strSql += "ORDER BY tblVendasMovto.Produto"
        Else
            strSql = "Select tblRetVendasSAT.IDVendaRetSAT, tblRetVendas.IDVendaRet, tblRetVendas.TotalProdutos, tblRetVendas.TotalVenda, tblRetVendas.D_A, tblRetVendas.Troco, tblRetVendas.Desconto, tblRetVendas.PercDesconto, tblRetVendas.Servico, tblRetVendas.PercServico, tblRetVendas.Caixinha, tblRetVendas.FlagFechada, tblRetVendas.StatusVenda, tblRetVendas.TaxaEntrega, tblRetVendas.Dinheiro, tblRetVendasSAT.Num_SAT, tblRetVendasSAT.NumSAT, tblRetVendasSAT.ValorCupom, tblRetVendasMovto.Produto, SUM(tblRetVendasMovto.Qtd) As Qtde, tblRetVendasMovto.Venda, tblRetVendasMovto.Excluido As ProdutoExcluido, tblProdutos.IDProduto, tblProdutosLojas.CodigoProduto, tblProdutos.CodigoNCM, tblProdutos.CodigoCEST, tblProdutosLojas.CST_PIS, tblProdutosLojas.CST_COFINS, tblProdutosLojas.CST_ICMS, tblProdutosLojas.CFOP, tblAliquotas.Aliquota, tblRetVendas.IDSat, tblProdutosLojas.pPIS, tblProdutosLojas.pCOFINS, tblRetVendas.NumVenda, tblRetVendas.NomeCliente, tblRetVendasCombo.IDVendaRetMovto As IDVendaMovtoCombo, Case WHEN AgregaValor = 1 THEN SUM(tblRetVendasCombo.Qtd) ELSE tblRetVendasMovto.Qtd END AS QtdeCombo, tblRetVendasCombo.AgregaValor, tblRetVendasMovto.Qtd "
            strSql += "From tblRetVendas INNER Join tblRetVendasSAT On tblRetVendas.IDVendaRet = tblRetVendasSAT.IDVendaRet INNER Join tblRetVendasMovto On tblRetVendas.IDVendaRet = tblRetVendasMovto.IDVendaRet INNER Join tblProdutos On tblRetVendasMovto.IDProduto = tblProdutos.IDProduto INNER Join tblProdutosLojas On tblProdutos.IDProduto = tblProdutosLojas.IDProduto INNER Join tblAliquotas On tblProdutosLojas.IDAliquota = tblAliquotas.IDAliquota LEFT OUTER Join tblRetVendasCombo On tblRetVendasMovto.IDVendaRetMovto = tblRetVendasCombo.IDVendaRetMovto "
            strSql += "Group By tblRetVendas.IDVendaRet, tblRetVendas.TotalProdutos, tblRetVendas.TotalVenda, tblRetVendas.D_A, tblRetVendas.Troco, tblRetVendas.Desconto, tblRetVendas.PercDesconto, tblRetVendas.Servico, tblRetVendas.PercServico, tblRetVendas.Caixinha, tblRetVendas.StatusVenda, tblRetVendas.TaxaEntrega, tblRetVendas.Dinheiro, tblRetVendasSAT.Num_SAT, tblRetVendasSAT.NumSAT, tblRetVendasSAT.ValorCupom, tblRetVendasMovto.Produto, tblRetVendasMovto.Venda, tblRetVendasMovto.Excluido, tblRetVendas.FlagFechada, tblRetVendasSAT.IDVendaRetSAT, tblProdutos.IDProduto, tblProdutosLojas.CodigoProduto, tblProdutos.CodigoNCM, tblProdutos.CodigoCEST, tblProdutosLojas.CST_PIS, tblProdutosLojas.CST_COFINS, tblProdutosLojas.CST_ICMS, tblProdutosLojas.CFOP, tblAliquotas.Aliquota, tblRetVendas.IDSat, tblProdutosLojas.pPIS, tblProdutosLojas.pCOFINS, tblRetVendasSAT.IDVendaRetSAT, tblRetVendas.NumVenda, tblRetVendas.NomeCliente, tblRetVendasCombo.IDVendaRetMovto, tblRetVendasCombo.AgregaValor, tblRetVendasMovto.Qtd "
            strSql += "HAVING(tblRetVendasMovto.Excluido = 0) AND (tblRetVendasSAT.IDVendaRetSat = " & IDvdaSat & ") "
            If IDPagto = 0 And STVenda <> "Delivery" Then
                strSql += "And (tblRetVendas.FlagFechada = 1)  "
            End If
            strSql += "ORDER BY tblRetVendasMovto.Produto"
        End If


        Try

            Dim con As New SqlConnection(strCon)
            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then

                CheckConfig(True)
                ConfiguraNFCeDataSet

                NFCeDataSet.Incluir()
                DadosdoNFCe()
                DadosEmitente()

                VlrNCM = 0
                Dim CodPro As Integer
                Dim Qtde As Decimal
                Dim Venda As Decimal
                Dim Produto As String
                Dim ProdutoCombo As String = ""
                Dim CodNCM As String
                Dim CFOP As String
                Dim CodCEST As String
                Dim CST_ICMS As String
                Dim Aliquota As Decimal
                Dim CST_PIS As String
                Dim CST_COFINS As String
                Dim pPIS As Decimal
                Dim pCOFINS As Decimal
                Dim VlrUnit As Decimal
                While dr.Read()
                    ' Dar um tempo  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    System.Threading.Thread.Sleep(300)
                    ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    spdSAT.ExibirDetalhamento = True
                    'IDmovto = NuloInteger(dr.Item("IDVendaMovto"))
                    NumVenda = NuloInteger(dr.Item("NumVenda"))
                    NomeCliente = NuloString(dr.Item("NomeCliente"))
                    If NuloInteger(dr.Item("IDVendaMovtoCombo")) = 0 Then
                        Qtde = NuloDecimal(dr.Item("Qtde"))
                    Else
                        Qtde = NuloDecimal(dr.Item("Qtd"))
                    End If
                    Venda = NuloDecimal(dr.Item("Venda"))
                    CodPro = NuloInteger(dr.Item("CodigoProduto"))
                    Produto = NuloString(dr.Item("Produto"))
                    CodNCM = NuloString(dr.Item("CodigoNCM"))
                    CFOP = NuloString(dr.Item("CFOP"))
                    CodCEST = NuloString(dr.Item("CodigoNCM"))
                    CST_ICMS = NuloString(dr.Item("CST_ICMS"))
                    Aliquota = NuloDecimal(dr.Item("Aliquota"))
                    CST_PIS = NuloString(dr.Item("CST_PIS"))
                    CST_COFINS = NuloString(dr.Item("CST_COFINS"))
                    pPIS = NuloDecimal(dr.Item("pPIS"))
                    pCOFINS = NuloDecimal(dr.Item("pCOFINS"))
                    ProdutoCombo = ""

                    If NuloString(dr.Item("IDVendaMovtoCombo")) <> "" And NuloBoolean(dr.Item("AgregaValor")) = True Then
                        Produto = Produto & " " & TextoCombo(dr.Item("IDVendaMovtoCombo"))
                    End If

                    Totpro = SemArredondar((Qtde * Venda) * Fator, 3)
                    VlrUnit = SemArredondar(Venda * Fator, 2)
                    TotproG += Totpro

                    NFCeDataSet.IncluirItem()
                    NFCeDataSet.SetCampo("nItem_H02=" + NumItem)
                    NFCeDataSet.SetCampo("cEAN_I03=SEM GTIN")
                    NFCeDataSet.SetCampo("cProd_I02=" + CodPro)
                    NFCeDataSet.SetCampo("xProd_I04=" + Strings.Left(Produto, 35))
                    NFCeDataSet.SetCampo("NCM_I05=" + CodNCM)
                    NFCeDataSet.SetCampo("CEST_I05c=")
                    NFCeDataSet.SetCampo("CFOP_I08=" + CFOP)
                    NFCeDataSet.SetCampo("uCom_I09=UN")
                    txtEnt = Replace(Format(Qtde, "#0.0000"), ",", ".")
                    NFCeDataSet.SetCampo("qCom_I10=" + txtEnt)
                    txtEnt = Replace(Format(VlrUnit, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vUnCom_I10a=" + txtEnt)
                    txtEnt = Replace(Format(VlrUnit * Qtde, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vProd_I11=" + txtEnt)
                    NFCeDataSet.SetCampo("cEANTrib_I12=SEM GTIN")
                    NFCeDataSet.SetCampo("uTrib_I13=UN")
                    txtEnt = Replace(Format(Qtde, "#0.0000"), ",", ".")
                    NFCeDataSet.SetCampo("qTrib_I14=" + txtEnt)
                    txtEnt = Replace(Format(VlrUnit, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vUnTrib_I14a=" + txtEnt)
                    NFCeDataSet.SetCampo("indTot_I17b=1")
                    txtEnt = Replace(Format((Qtde * VlrUnit) * (Aliquota / 100), "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vTotTrib_M02=" + txtEnt)
                    NFCeDataSet.SetCampo("orig_N11=0")
                    NFCeDataSet.SetCampo("CSOSN_N12a=" + CST_ICMS)
                    NFCeDataSet.SetCampo("CST_Q06=" + CST_PIS)
                    NFCeDataSet.SetCampo("CST_S06=" + CST_COFINS)
                    NFCeDataSet.SetCampo("infAdProd_V01=")
                    NFCeDataSet.SalvarItem()

                    NumItem = NumItem + 1
                End While

                ' Taxa ENtrega //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If TxEntrega > 0 Then
                    Totpro = TxEntrega * Fator
                    Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                    TotproG += Totpro

                    NFCeDataSet.IncluirItem()
                    NFCeDataSet.SetCampo("nItem_H02=" + NumItem)
                    NFCeDataSet.SetCampo("cEAN_I03=SEM GTIN")
                    NFCeDataSet.SetCampo("cProd_I02=000000")
                    NFCeDataSet.SetCampo("xProd_I04=TAXA DE ENTREGA")
                    NFCeDataSet.SetCampo("NCM_I05=" + NCM_Servico)
                    NFCeDataSet.SetCampo("CEST_I05c=")
                    NFCeDataSet.SetCampo("CFOP_I08=" + CFOP_Servico)
                    NFCeDataSet.SetCampo("uCom_I09=UN")
                    NFCeDataSet.SetCampo("qCom_I10=1.0000")
                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vUnCom_I10a=" + txtEnt)
                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vProd_I11=" + txtEnt)
                    NFCeDataSet.SetCampo("cEANTrib_I12=SEM GTIN")
                    NFCeDataSet.SetCampo("uTrib_I13=UN")
                    NFCeDataSet.SetCampo("qTrib_I14=1.0000")
                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vUnTrib_I14a=" + txtEnt)
                    NFCeDataSet.SetCampo("indTot_I17b=1")
                    txtEnt = Replace(Format(Totpro * (Aliquota_Servico / 100), "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vTotTrib_M02=" + txtEnt)
                    NFCeDataSet.SetCampo("orig_N11=0")
                    NFCeDataSet.SetCampo("CSOSN_N12a=" + CSTIcms_Servico)
                    NFCeDataSet.SetCampo("CST_Q06=" + CSTPis_Servico)
                    NFCeDataSet.SetCampo("CST_S06=" + CSTCofins_Servico)
                    NFCeDataSet.SetCampo("infAdProd_V01=")
                    NFCeDataSet.SalvarItem()

                    NumItem += 1
                End If



                ' Serviço //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If TotalAD > 0 And Acrescimo_W21 = False Then
                    Totpro = TotalAD * Fator
                    Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                    TotproG += Totpro


                    NFCeDataSet.IncluirItem()
                    NFCeDataSet.SetCampo("nItem_H02=" + NumItem)
                    NFCeDataSet.SetCampo("cEAN_I03=SEM GTIN")
                    NFCeDataSet.SetCampo("cProd_I02=999999")
                    If TextoServicoCupom <> "" Then
                        NFCeDataSet.SetCampo("xProd_I04=" + TextoServicoCupom)
                    Else
                        NFCeDataSet.SetCampo("xProd_I04=" + TextoServico)
                    End If
                    NFCeDataSet.SetCampo("NCM_I05=" + NCM_Servico)
                    NFCeDataSet.SetCampo("CEST_I05c=")
                    NFCeDataSet.SetCampo("CFOP_I08=" + CFOP_Servico)
                    NFCeDataSet.SetCampo("uCom_I09=UN")
                    NFCeDataSet.SetCampo("qCom_I10=1.0000")
                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vUnCom_I10a=" + txtEnt)
                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vProd_I11=" + txtEnt)
                    NFCeDataSet.SetCampo("cEANTrib_I12=SEM GTIN")
                    NFCeDataSet.SetCampo("uTrib_I13=UN")
                    NFCeDataSet.SetCampo("qTrib_I14=1.0000")
                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vUnTrib_I14a=" + txtEnt)
                    NFCeDataSet.SetCampo("indTot_I17b=1")
                    txtEnt = Replace(Format(Totpro * (Aliquota_Servico / 100), "#0.00"), ",", ".")
                    NFCeDataSet.SetCampo("vTotTrib_M02=" + txtEnt)
                    NFCeDataSet.SetCampo("orig_N11=0")
                    NFCeDataSet.SetCampo("CSOSN_N12a=" + CSTIcms_Servico)
                    NFCeDataSet.SetCampo("CST_Q06=" + CSTPis_Servico)
                    NFCeDataSet.SetCampo("CST_S06=" + CSTCofins_Servico)
                    NFCeDataSet.SetCampo("infAdProd_V01=")
                    NFCeDataSet.SalvarItem()

                    NumItem += 1
                End If
                dr.Close()
                cmd.Dispose()
                con.Dispose()
                con.Close()


                'PAGAMENTOS *************************************************************************
                Dim VlrPg As Decimal = 0
                Dim chave As Integer = 0
                Dim VlrPg_ As Decimal = 0

                If IDPagto = 0 Then
                    If Local = "L" Then
                        strSql = "Select tblVendasPagto.IDVenda, tblVendasPagto.IDFormaPagto, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblVendasPagto.Cupom, tblFormaPagtos_Local.CodigoSAT, tblVendasPagto.IDVendaPagto "
                        strSql += "From tblVendasPagto LEFT OUTER Join tblFormaPagtos_Local On tblVendasPagto.IDFormaPagto = tblFormaPagtos_Local.IDFormaPagto "
                        strSql += "Where (tblVendasPagto.Cupom=0) And (tblVendasPagto.IDVenda = " & IDVenda & ") And (tblVendasPagto.ValorPago > 0) "
                        strSql += "Order By tblVendasPagto.Descricao"
                        Dim conPG_ As New SqlConnection(strCon)
                        conPG_.Open()
                        Dim cmdPG_ As New SqlCommand(strSql, conPG_)
                        cmdPG_.CommandType = CommandType.Text

                        Dim drPG_ As SqlDataReader = cmdPG_.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                        If drPG_.HasRows Then
                            While drPG_.Read()
                                If chave = 0 Then
                                    VlrPg_ = drPG_.Item("ValorPago")
                                    chave = 1
                                End If
                                VlrPg += drPG_.Item("ValorPago")
                            End While

                            If (TotproG - VlrPg) < 0 And (TotproG - VlrPg) > -0.1 Then
                                strSql = "UPDATE tblVendasPagto SET "
                                strSql &= "ValorPago = " & Replace(VlrPg_ + (VlrPg - TotproG), ",", ".") & " "
                                strSql &= "WHERE (IDVendaPagto = " & IDVenda & ")"
                                ExecutaStr(strSql)
                            End If
                        End If
                        cmdPG_.Dispose()
                        drPG_.Close()
                        conPG_.Dispose()
                        conPG_.Close()
                    End If
                End If

                If IDPagto = 0 Then
                    If Local = "L" Then
                        strSql = "Select tblVendasPagto.IDVenda, tblVendasPagto.IDFormaPagto, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblVendasPagto.Cupom, tblFormaPagtos_Local.CodigoSAT, tblVendasPagto.IDVendaPagto "
                        strSql += "From tblVendasPagto LEFT OUTER Join tblFormaPagtos_Local On tblVendasPagto.IDFormaPagto = tblFormaPagtos_Local.IDFormaPagto "
                        strSql += "Where (tblVendasPagto.Cupom=0) And (tblVendasPagto.IDVenda = " & IDVenda & ") And (tblVendasPagto.ValorPago > 0) "
                        strSql += "Order By tblVendasPagto.Descricao"
                    Else
                        strSql = "Select tblRetVendasPagto.IDVendaRet, tblRetVendasPagto.IDFormaPagto, tblRetVendasPagto.ValorPago, tblRetVendasPagto.Descricao, tblRetVendasPagto.Cupom, tblFormaPagtosLojas.CodigoSAT, tblRetVendasPagto.IDVendaRetPagto "
                        strSql += "From tblRetVendasPagto INNER Join tblFormaPagtos On tblRetVendasPagto.IDFormaPagto = tblFormaPagtos.IDFormaPagto INNER Join tblFormaPagtosLojas On tblFormaPagtos.IDFormaPagto = tblFormaPagtosLojas.IDFormaPagto "
                        strSql += "Where (tblRetVendasPagto.Cupom=0) And (tblRetVendasPagto.IDVendaRet = " & IDVenda & ") And (tblRetVendasPagto.ValorPago > 0) "
                        strSql += "Order By tblRetVendasPagto.Descricao"
                    End If
                Else
                    strSql = "Select tblVendasPagto.IDVendaPagto, tblVendasPagto.IDFormaPagto, tblVendasPagto.Descricao, tblVendasPagto.ValorPago, tblVendasPagto.Cupom, tblFormaPagtos_Local.CodigoSAT "
                    strSql += "From tblVendasPagto INNER Join tblFormaPagtos_Local On tblVendasPagto.IDFormaPagto = tblFormaPagtos_Local.IDFormaPagto "
                    strSql += "Where (tblVendasPagto.IDVendaPagto = " & IDPagto & ") "
                    strSql += "Order By tblVendasPagto.Descricao"
                End If

                Dim VlrPagto As Decimal = 0
                Dim conPG As New SqlConnection(strCon)
                conPG.Open()
                Dim cmdPG As New SqlCommand(strSql, conPG)
                cmdPG.CommandType = CommandType.Text

                Dim drPG As SqlDataReader = cmdPG.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If drPG.HasRows Then
                    While drPG.Read()
                        System.Threading.Thread.Sleep(300)

                        NFCeDataSet.IncluirParte("YA")
                        NFCeDataSet.SetCampo("tPag_YA02=" + New String("0", 2 - Len(drPG.Item("CodigoSat"))) & drPG.Item("CodigoSat"))
                        VlrPagto += NuloDecimal(drPG.Item("ValorPago"))
                        txtEnt = Replace(Format(drPG.Item("ValorPago"), "####0.00"), ",", ".")
                        NFCeDataSet.SetCampo("vPag_YA03=" + txtEnt)
                        NFCeDataSet.SalvarParte("YA")

                        If Local = "L" Then
                            strSql = "UPDATE tblVendasPagto SET "
                            strSql &= "Cupom = 1 "
                            strSql &= "WHERE (IDVendaPagto = " & drPG.Item("IDVendaPagto") & ")"
                            ExecutaStr(strSql)
                        Else
                            strSql = "UPDATE tblRetVendasPagto SET "
                            strSql &= "Cupom = 1 "
                            strSql &= "WHERE (IDVendaRetPagto = " & drPG.Item("IDVendaRetPagto") & ")"
                            ExecutaStr(strSql)
                        End If
                    End While
                End If

                cmdPG.Dispose()
                drPG.Close()
                conPG.Dispose()
                conPG.Close()

                Dim TextoLivre As String = NumVenda
                If NomeCliente <> "" Then
                    TextoLivre &= " - " & NomeCliente
                End If
                TextoLivre = Strings.Left(TextoLivre, 40)


                Try

                    spdSATDataSet.Salvar()
                    frmPrincipal.tbmmRetorno.Text = spdSATDataSet.LoteCFeSat

                    frmPrincipal.tbEdtUltIDAutorizado.Text = ""
                    Dim aRetorno As String
                    Dim arrRetorno() As String
                    Dim XML_Envio As String = frmPrincipal.tbmmRetorno.Text

                    aRetorno = spdSAT.EnviarDadosVenda(NumeroSessao, XML_Envio)

                    arrRetorno = Split(aRetorno, "|")
                    If (UBound(arrRetorno) > 7) Then
                        frmPrincipal.tbEdtUltIDAutorizado.Text = arrRetorno(8)
                    End If
                    frmPrincipal.tbmmRetorno.Text = aRetorno

                    If Local <> "L" Then
                        ' Gera arquivo XML /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Dim ArqImp As String
                        ArqImp = "AD" & Mid(frmPrincipal.tbEdtUltIDAutorizado.Text, 4, Len(frmPrincipal.tbEdtUltIDAutorizado.Text) - 3)
                        If STVenda <> "Delivery" Then
                            ArqImp = Application.StartupPath & "\NFCE\CopiaSeguranca\" & ArqImp & ".xml"
                        Else
                            ArqImp = Application.StartupPath & "\NFCE\CopiaSeguranca\" & ArqImp & ".xml"
                        End If

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
                        strSql = "UPDATE tblRetVendasSAT SET "
                        strSql &= "Status= 'E', "
                        strSql &= "XML ='" & ArquivoXML & "', "
                        strSql &= "ValorCupom =" & Replace(VlrPagto, ",", ".") & ", "
                        strSql &= "Num_SAT ='" & frmPrincipal.tbEdtUltIDAutorizado.Text & "', "
                        strSql &= "NumSAT ='" & Mid$(frmPrincipal.tbEdtUltIDAutorizado.Text, 26, 9) & "' "
                        strSql &= "WHERE (IDVendaRetSAT=" & IDvdaSat & ")"
                        ExecutaStr(strSql)
                    End If



                Catch ex As Exception

                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = ex.Message
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                End Try
            End If


        Catch ex As Exception
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = ex.Message
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End Try

    End Function
End Module
