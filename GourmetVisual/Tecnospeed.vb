Imports System.Data.SqlClient

Module Tecnospeed
    Public spdSAT As New CFeSatX.spdCFeSatX
    Public spdSATDataSet As CFeSatDataSetX.spdCFeSatDataSetX

    Public ArqIni_SatCP As String = Application.StartupPath & "\cfesatConfig.ini"
    Public CodAtiv_SatCP As String
    Public DLL_SatCP As String

    Public txtCupomFiscal As String
    Public NumCPF As String
    Public ImpressoraNFCe As String
    Public cnpjSW As String
    Public AssAC As String
    Public NumeroCaixa As String
    Public CNPJContribuinte As String
    Public IEContribuinte As String
    Public IMContribuinte As String
    Public LogoCupom As String

    Public DirDestino As String
    Public TextoServico As String

    Public NCM_Servico As String
    Public CSTPis_Servico As String
    Public CSTCofins_Servico As String
    Public CFOP_Servico As String
    Public CSTIcms_Servico As String
    Public Aliquota_Servico As Decimal

    Public VersaoSAT As String

    Public VlrBaseNCM As Double
    Public VlrNCM As Double

    Public Numero_Sessao As Integer
    Public Function CarregaIni_SatCP()

        spdSAT = New CFeSatX.spdCFeSatX
        spdSATDataSet = New CFeSatDataSetX.spdCFeSatDataSetX

        Dim texto As String = Application.StartupPath & "\cfesatConfig.ini"
        spdSAT.LoadConfig(texto)
        spdSAT.DiretorioTemplates = Application.StartupPath & "\Sat\Templates\"
        spdSAT.DiretorioLog = Application.StartupPath & "\Sat\Log\"
        spdSAT.DiretorioLogErro = Application.StartupPath & "\Sat\Log\"
        spdSAT.DiretorioEsquemas = Application.StartupPath & "\Sat\Esquemas\"
        spdSAT.DiretorioCopiaSeguranca = Application.StartupPath & "\Sat\CopiaSeguranca\"
        spdSAT.ModeloImpressao = spdSAT.DiretorioTemplates + "Impressao\retrato.rtm"

    End Function
    Function TextoCombo(IDmovto As Integer) As String
        strSql = "Select IDVendaMovto, Produto From tblVendasCombo Where (IDVendaMovto = " & IDmovto & ") Order By Produto"
        Dim Texto As String = ""

        Dim conSAT As New SqlConnection(strCon)
        conSAT.Open()
        Dim cmdSAT As New SqlCommand(strSql, conSAT)
        cmdSAT.CommandType = CommandType.Text

        Dim drSAT As SqlDataReader = cmdSAT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drSAT.HasRows Then

            While drSAT.Read
                Texto += Trim(Strings.Left(drSAT.Item("Produto"), 9)) & "/"
            End While
        End If
        cmdSAT.Dispose()
        drSAT.Close()
        conSAT.Dispose()
        conSAT.Close()

        Return Texto
    End Function
    Function NumeroSessao() As Double

        Randomize()
        Dim Sessao As Double
        Sessao = Int(Rnd() * (999999 - 100000) + 100000)
        frmPrincipal.tbEdtUltimaSessao.Text = Trim(Str(Sessao))

        Numero_Sessao = Sessao
        Return Sessao

    End Function

    Function PegaDadosSAT(ID As Integer)

        Dim Retorno As Boolean = False

        strSql = "Select * From tblSAT WHERE IDSat = " & ID

        Dim conSAT As New SqlConnection(strCon)
        conSAT.Open()
        Dim cmdSAT As New SqlCommand(strSql, conSAT)
        cmdSAT.CommandType = CommandType.Text



        Dim drSAT As SqlDataReader = cmdSAT.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drSAT.HasRows Then
            drSAT.Read()
            cnpjSW = drSAT.Item("CNPJSoftwareHouse")
            AssAC = drSAT.Item("Assinatura")
            NumeroCaixa = drSAT.Item("NumeroCaixa")
            VersaoSAT = drSAT.Item("Versao")
            CNPJContribuinte = drSAT.Item("CNPJCliente")
            IEContribuinte = drSAT.Item("InscricaoEstadual")
            IMContribuinte = NuloString(drSAT.Item("InscricaoMunicipal"))
            LogoCupom = NuloString(drSAT.Item("NomeLogo"))
            Retorno = True
        End If

        cmdSAT.Dispose()
        drSAT.Close()
        conSAT.Dispose()
        conSAT.Close()

        Return Retorno


    End Function

    Public Function EfetuaVendaSAT(IDvdaSat As Integer, IDvda As Integer, Cpf_Cnpj As String, TotalAD As Decimal, TotVenda As Decimal, TotCupom As Decimal, TxEntrega As Decimal, STVenda As String, DiaMovto As String, IDVenda As Integer, SatID As Integer, IDPagto As Integer, Local As String)

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

                If PegaDadosSAT(SatID) = False Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "SAT não encontrado"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    cmd.Dispose()
                    dr.Close()
                    con.Dispose()
                    con.Close()
                    Exit Function
                End If


                'If STVenda <> "Delivery" Then
                CarregaIni_SatCP()
                System.Threading.Thread.Sleep(500)

                'Else
                'If EquipamentoSAT_Delivery = 0 Then
                'CarregaIni_SatCP()
                'Else
                'CarregaIni_SatCP_Delivery()
                'End If
                'End If




                spdSATDataSet.ArquivoConversorXml = spdSAT.DiretorioTemplates + "Conversor\CFeSatDataSets.xml"

                spdSATDataSet.Incluir()
                spdSATDataSet.SetCampo("versaoDadosEnt_A03=" + VersaoSAT)
                spdSATDataSet.SetCampo("CNPJ_B11=" + cnpjSW)
                spdSATDataSet.SetCampo("signAC_B12=" + AssAC)
                spdSATDataSet.SetCampo("numeroCaixa_B14=" + NumeroCaixa)

                If TotalAD < 0 Then
                    txtEnt = Replace(Format(Math.Abs(TotalAD * Fator), "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vDescSubTot_W20=" & txtEnt)
                    spdSATDataSet.SetCampo("vAcresSubtot_W21=")
                Else
                    If TotalAD > 0 Then
                        txtEnt = Replace(Format(Math.Abs(TotalAD * Fator), "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vDescSubTot_W20=")
                        If Acrescimo_W21 = True Then
                            spdSATDataSet.SetCampo("vAcresSubtot_W21=" & txtEnt)
                        Else
                            spdSATDataSet.SetCampo("vAcresSubtot_W21=")
                        End If
                    End If
                End If

                spdSATDataSet.SetCampo("CNPJ_C02=" + CNPJContribuinte)
                spdSATDataSet.SetCampo("IE_C12=" + IEContribuinte)
                spdSATDataSet.SetCampo("IM_C13=" + IMContribuinte)
                spdSATDataSet.SetCampo("cRegTribISSQN_C15=")
                spdSATDataSet.SetCampo("indRatISSQN_C16=N")

                If Cpf_Cnpj <> "" Then
                    If Len(Cpf_Cnpj) > 11 Then
                        spdSATDataSet.SetCampo("CNPJ_E02=" + Cpf_Cnpj)
                        spdSATDataSet.SetCampo("CPF_E03=")
                    Else
                        spdSATDataSet.SetCampo("CNPJ_E02=")
                        spdSATDataSet.SetCampo("CPF_E03=" + Cpf_Cnpj)
                    End If
                Else
                    spdSATDataSet.SetCampo("CNPJ_E02=")
                    spdSATDataSet.SetCampo("CPF_E03=")
                End If
                spdSATDataSet.SetCampo("xNome_E04=")
                spdSAT.ExibirDetalhamento = True
                If LogoCupom <> "" Then
                    spdSAT.LogotipoEmitente = LogoCupom
                End If
                VlrNCM = 0
                'Dim IDmovto As Integer
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
                    System.Threading.Thread.Sleep(500)
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
                    'Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                    TotproG += Totpro

                    spdSATDataSet.IncluirItem()
                    spdSATDataSet.SetCampo("nItem_H02=" & NumItem)
                    spdSATDataSet.SetCampo("cProd_I02=" & CodPro)
                    spdSATDataSet.SetCampo("cEAN_I03=")
                    spdSATDataSet.SetCampo("xProd_I04=" & Strings.Left(Produto, 35))
                    spdSATDataSet.SetCampo("NCM_I05=" & CodNCM)
                    spdSATDataSet.SetCampo("CFOP_I06=" & CFOP)
                    spdSATDataSet.SetCampo("uCom_I07=UN")

                    txtEnt = Replace(Format(Qtde, "#0.0000"), ",", ".")
                    spdSATDataSet.SetCampo("qCom_I08=" & txtEnt)


                    'txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")

                    txtEnt = Replace(Format(VlrUnit, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vUnCom_I09=" & txtEnt)

                    spdSATDataSet.SetCampo("indRegra_I11=A")
                    spdSATDataSet.SetCampo("vDesc_I12=")
                    spdSATDataSet.SetCampo("vOutro_I13=")

                    Call CalculaNCM_SAT(CodNCM, Totpro)
                    txtEnt = Replace(Format(VlrNCM * Fator, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vItem12741_M02=" & txtEnt)

                    If CodNCM <> "" Then
                        If CodNCM = 0 Then
                            If CodCEST <> "" Then
                                If Not IsDBNull(CodCEST) Then
                                    spdSATDataSet.SetCampo("xCampoDet_I18=Cod. CEST")
                                    spdSATDataSet.SetCampo("xTextoDet_I19=" & CodCEST)
                                End If
                            End If
                        End If
                    End If

                    txtEnt = Replace(Format(VlrNCM, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vCFeLei12741_W22=" & txtEnt)

                    'CST ICMS ///////////////////////////////////////////
                    If Len(CST_ICMS) = 3 Then
                        'spdSATDataSet.SetCampo("Orig_N06=" & Strings.Left(CST_ICMS, 1))
                        spdSATDataSet.SetCampo("Orig_N06=0")
                        'spdSATDataSet.SetCampo("CST_N07=" & Strings.Right(CST_ICMS, 2))
                        spdSATDataSet.SetCampo("CST_N07=")
                        spdSATDataSet.SetCampo("CSOSN_N10=" & CST_ICMS)
                    Else
                        spdSATDataSet.SetCampo("Orig_N06=0")
                        spdSATDataSet.SetCampo("CST_N07=" & CST_ICMS)
                        spdSATDataSet.SetCampo("CSOSN_N10=")
                    End If
                    txtEnt = Replace(Format(Aliquota, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("pICMS_N08=" & txtEnt)


                    ' CST PIS ///////////////////////////////////////////////////////////////////////////////////////////////////
                    spdSATDataSet.SetCampo("CST_Q07=" & CST_PIS)
                    If CST_PIS = "01" Or CST_PIS = "99" Then
                        txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vBC_Q08=" & txtEnt)
                        txtEnt = Replace(Format(NuloDecimal(Replace(pPIS / 1000, ".", ",")), "#0.0000"), ",", ".")
                        spdSATDataSet.SetCampo("pPIS_Q09=" & txtEnt)

                        spdSATDataSet.SetCampo("qBCProd_Q11=")
                        spdSATDataSet.SetCampo("vAliqProd_Q12=")
                    Else
                        spdSATDataSet.SetCampo("vBC_Q08=")
                        spdSATDataSet.SetCampo("pPIS_Q09=")
                        spdSATDataSet.SetCampo("qBCProd_Q11=")
                        spdSATDataSet.SetCampo("vAliqProd_Q12=")
                    End If

                    ' CST COFINS ///////////////////////////////////////////
                    spdSATDataSet.SetCampo("CST_S07=" & CST_COFINS)
                    If CST_COFINS = "01" Or CST_COFINS = "99" Then
                        txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vBC_S08=" & txtEnt)
                        txtEnt = Replace(Format(NuloDecimal(Replace(pCOFINS / 1000, ".", ",")), "#0.0000"), ",", ".")
                        spdSATDataSet.SetCampo("pCOFINS_S09=" & txtEnt)
                        spdSATDataSet.SetCampo("qBCProd_S11=")
                        spdSATDataSet.SetCampo("vAliqProd_S12=")
                    Else
                        spdSATDataSet.SetCampo("vBC_S08=")
                        spdSATDataSet.SetCampo("pCOFINS_S09=")
                        spdSATDataSet.SetCampo("qBCProd_S11=")
                        spdSATDataSet.SetCampo("vAliqProd_S12=")
                    End If

                    spdSATDataSet.SetCampo("vDeducISSQN_U02=")
                    spdSATDataSet.SetCampo("vAliq_U04=")
                    spdSATDataSet.SetCampo("cMunFG_U06=")
                    spdSATDataSet.SetCampo("cListServ_U07=")
                    spdSATDataSet.SetCampo("cServTribMun_U08=")
                    spdSATDataSet.SetCampo("cNatOp_U09=")
                    spdSATDataSet.SetCampo("indIncFisc_U10=")

                    spdSATDataSet.SetCampo("infAdProd_V01=")
                    spdSATDataSet.SalvarItem()

                    NumItem = NumItem + 1
                End While

                ' Taxa ENtrega //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If TxEntrega > 0 Then

                    System.Threading.Thread.Sleep(500)

                    Totpro = TxEntrega * Fator
                    Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                    TotproG += Totpro

                    spdSATDataSet.IncluirItem()
                    spdSATDataSet.SetCampo("nItem_H02=" & NumItem)
                    spdSATDataSet.SetCampo("cProd_I02=000000")
                    spdSATDataSet.SetCampo("cEAN_I03=")
                    spdSATDataSet.SetCampo("xProd_I04=TAXA ENTREGA")
                    spdSATDataSet.SetCampo("NCM_I05=" & NCM_Servico)
                    spdSATDataSet.SetCampo("CFOP_I06=" & CFOP_Servico)
                    spdSATDataSet.SetCampo("uCom_I07=UN")

                    spdSATDataSet.SetCampo("qCom_I08=1.0000")

                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vUnCom_I09=" & txtEnt)

                    spdSATDataSet.SetCampo("indRegra_I11=A")
                    spdSATDataSet.SetCampo("vDesc_I12=")
                    spdSATDataSet.SetCampo("vOutro_I13=")

                    Call CalculaNCM_SAT(NCM_Servico, Totpro)
                    txtEnt = Replace(Format(VlrBaseNCM * Fator, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vItem12741_M02=" & txtEnt)
                    spdSATDataSet.SetCampo("vCFeLei12741_W22=" & txtEnt)

                    ' CST ICMS ///////////////////////////////////////////
                    If Len(CSTIcms_Servico) = 3 Then
                        'spdSATDataSet.SetCampo("Orig_N06=" & Strings.Left(CST_ICMS, 1))
                        spdSATDataSet.SetCampo("Orig_N06=0")
                        'spdSATDataSet.SetCampo("CST_N07=" & Strings.Right(CST_ICMS, 2))
                        spdSATDataSet.SetCampo("CST_N07=")
                        spdSATDataSet.SetCampo("CSOSN_N10=" & CSTIcms_Servico)
                    Else
                        spdSATDataSet.SetCampo("Orig_N06=0")
                        spdSATDataSet.SetCampo("CST_N07=" & CSTIcms_Servico)
                        spdSATDataSet.SetCampo("CSOSN_N10=")
                    End If
                    txtEnt = Replace(Format(Totpro * (Aliquota_Servico / 100), "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("pICMS_N08=" & txtEnt)


                    ' CST PIS ///////////////////////////////////////////////////////////////////////////////////////////////////
                    spdSATDataSet.SetCampo("CST_Q07=" & CSTPis_Servico)
                    If CSTPis_Servico = "01" Or CSTPis_Servico = "99" Then
                        txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vBC_Q08=" & txtEnt)
                        txtEnt = Replace(Format(NuloDecimal(Replace(pPIS / 1000, ".", ",")), "#0.0000"), ",", ".")
                        spdSATDataSet.SetCampo("pPIS_Q09=" & txtEnt)
                        spdSATDataSet.SetCampo("qBCProd_Q11=")
                        spdSATDataSet.SetCampo("vAliqProd_Q12=")
                    Else
                        spdSATDataSet.SetCampo("vBC_Q08=")
                        spdSATDataSet.SetCampo("pPIS_Q09=")
                        spdSATDataSet.SetCampo("qBCProd_Q11=")
                        spdSATDataSet.SetCampo("vAliqProd_Q12=")
                    End If

                    ' CST COFINS ///////////////////////////////////////////
                    spdSATDataSet.SetCampo("CST_S07=" & CSTCofins_Servico)
                    If CSTCofins_Servico = "01" Or CSTCofins_Servico = "99" Then
                        txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vBC_S08=" & txtEnt)
                        txtEnt = Replace(Format(NuloDecimal(Replace(pCOFINS / 1000, ".", ",")), "#0.0000"), ",", ".")
                        spdSATDataSet.SetCampo("pCOFINS_S09=" & txtEnt)
                        spdSATDataSet.SetCampo("qBCProd_S11=")
                        spdSATDataSet.SetCampo("vAliqProd_S12=")
                    Else
                        spdSATDataSet.SetCampo("vBC_S08=")
                        spdSATDataSet.SetCampo("pCOFINS_S09=")
                        spdSATDataSet.SetCampo("qBCProd_S11=")
                        spdSATDataSet.SetCampo("vAliqProd_S12=")
                    End If


                    spdSATDataSet.SetCampo("vDeducISSQN_U02=")
                    spdSATDataSet.SetCampo("vAliq_U04=")
                    spdSATDataSet.SetCampo("cMunFG_U06=")
                    spdSATDataSet.SetCampo("cListServ_U07=")
                    spdSATDataSet.SetCampo("cServTribMun_U08=")
                    spdSATDataSet.SetCampo("cNatOp_U09=")
                    spdSATDataSet.SetCampo("indIncFisc_U10=")

                    spdSATDataSet.SetCampo("infAdProd_V01=")
                    spdSATDataSet.SalvarItem()

                    'VlrDescNCM = VlrDescNCM + Totpro
                    NumItem += 1
                End If



                ' Serviço //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If TotalAD > 0 And Acrescimo_W21 = False Then

                    System.Threading.Thread.Sleep(500)

                    Totpro = TotalAD * Fator
                    Totpro = NuloDecimal(SemArredondar(Totpro, 3))
                    TotproG += Totpro

                    spdSATDataSet.IncluirItem()
                    spdSATDataSet.SetCampo("nItem_H02=" & NumItem)
                    spdSATDataSet.SetCampo("cProd_I02=999999")
                    spdSATDataSet.SetCampo("cEAN_I03=")
                    If TextoServicoCupom <> "" Then
                        spdSATDataSet.SetCampo("xProd_I04=" & TextoServicoCupom)
                    Else
                        spdSATDataSet.SetCampo("xProd_I04=" & TextoServico)
                    End If
                    spdSATDataSet.SetCampo("NCM_I05=" & NCM_Servico)
                    spdSATDataSet.SetCampo("CFOP_I06=" & CFOP_Servico)
                    spdSATDataSet.SetCampo("uCom_I07=UN")

                    spdSATDataSet.SetCampo("qCom_I08=1.0000")

                    txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vUnCom_I09=" & txtEnt)

                    spdSATDataSet.SetCampo("indRegra_I11=A")
                    spdSATDataSet.SetCampo("vDesc_I12=")
                    spdSATDataSet.SetCampo("vOutro_I13=")

                    Call CalculaNCM_SAT(NCM_Servico, Totpro)
                    txtEnt = Replace(Format(VlrNCM * Fator, "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("vItem12741_M02=" & txtEnt)
                    spdSATDataSet.SetCampo("vCFeLei12741_W22=" & txtEnt)

                    ' CST ICMS ///////////////////////////////////////////
                    If Len(CSTIcms_Servico) = 3 Then
                        'spdSATDataSet.SetCampo("Orig_N06=" & Strings.Left(CST_ICMS, 1))
                        spdSATDataSet.SetCampo("Orig_N06=0")
                        'spdSATDataSet.SetCampo("CST_N07=" & Strings.Right(CST_ICMS, 2))
                        spdSATDataSet.SetCampo("CST_N07=")
                        spdSATDataSet.SetCampo("CSOSN_N10=" & CSTIcms_Servico)
                    Else
                        spdSATDataSet.SetCampo("Orig_N06=0")
                        spdSATDataSet.SetCampo("CST_N07=" & CSTIcms_Servico)
                        spdSATDataSet.SetCampo("CSOSN_N10=")
                    End If

                    txtEnt = Replace(Format(Totpro * (Aliquota_Servico / 100), "#0.00"), ",", ".")
                    spdSATDataSet.SetCampo("pICMS_N08=" & txtEnt)


                    ' CST PIS ///////////////////////////////////////////////////////////////////////////////////////////////////
                    spdSATDataSet.SetCampo("CST_Q07=" & CSTPis_Servico)
                    If CSTPis_Servico = "01" Or CSTPis_Servico = "99" Then
                        txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vBC_Q08=" & txtEnt)
                        txtEnt = Replace(Format(NuloDecimal(Replace(pPIS / 1000, ".", ",")), "#0.0000"), ",", ".")
                        spdSATDataSet.SetCampo("pPIS_Q09=" & txtEnt)
                        spdSATDataSet.SetCampo("qBCProd_Q11=")
                        spdSATDataSet.SetCampo("vAliqProd_Q12=")
                    Else
                        spdSATDataSet.SetCampo("vBC_Q08=")
                        spdSATDataSet.SetCampo("pPIS_Q09=")
                        spdSATDataSet.SetCampo("qBCProd_Q11=")
                        spdSATDataSet.SetCampo("vAliqProd_Q12=")
                    End If


                    ' CST COFINS ///////////////////////////////////////////
                    spdSATDataSet.SetCampo("CST_S07=" & CSTCofins_Servico)
                    If CSTCofins_Servico = "01" Or CSTCofins_Servico = "99" Then
                        txtEnt = Replace(Format(Totpro, "#0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vBC_S08=" & txtEnt)
                        txtEnt = Replace(Format(NuloDecimal(Replace(pCOFINS / 1000, ".", ",")), "#0.0000"), ",", ".")
                        spdSATDataSet.SetCampo("pCOFINS_S09=" & txtEnt)
                        spdSATDataSet.SetCampo("qBCProd_S11=")
                        spdSATDataSet.SetCampo("vAliqProd_S12=")
                    Else
                        spdSATDataSet.SetCampo("vBC_S08=")
                        spdSATDataSet.SetCampo("pCOFINS_S09=")
                        spdSATDataSet.SetCampo("qBCProd_S11=")
                        spdSATDataSet.SetCampo("vAliqProd_S12=")
                    End If

                    spdSATDataSet.SetCampo("vDeducISSQN_U02=")
                    spdSATDataSet.SetCampo("vAliq_U04=")
                    spdSATDataSet.SetCampo("cMunFG_U06=")
                    spdSATDataSet.SetCampo("cListServ_U07=")
                    spdSATDataSet.SetCampo("cServTribMun_U08=")
                    spdSATDataSet.SetCampo("cNatOp_U09=")
                    spdSATDataSet.SetCampo("indIncFisc_U10=")

                    spdSATDataSet.SetCampo("infAdProd_V01=")
                    spdSATDataSet.SalvarItem()

                    'VlrDescNCM = VlrDescNCM + Totpro
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

                        strSql = "Select tblVendasPagto.IDVenda, tblVendasPagto.IDFormaPagto, tblVendasPagto.Descricao, SUM(tblVendasPagto.ValorPago) AS ValorPago, tblVendasPagto.Cupom, tblFormaPagtos_Local.CodigoSAT "
                        strSql += "From tblVendasPagto LEFT OUTER Join tblFormaPagtos_Local On tblVendasPagto.IDFormaPagto = tblFormaPagtos_Local.IDFormaPagto "
                        strSql += "Group By tblVendasPagto.IDVenda, tblVendasPagto.IDFormaPagto, tblVendasPagto.Descricao, tblFormaPagtos_Local.CodigoSAT, tblVendasPagto.Cupom "
                        strSql += "HAVING(tblVendasPagto.IDVenda = " & IDVenda & ") And (tblVendasPagto.Cupom = 0) And (SUM(tblVendasPagto.ValorPago) > 0) "
                        strSql += "Order BY tblVendasPagto.Descricao"

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

                        System.Threading.Thread.Sleep(500)

                        Dim pagto_SAT As String = New String("0", 2 - Len(drPG.Item("CodigoSat"))) & drPG.Item("CodigoSat")

                        If NuloString(drPG.Item("CodigoSat")) = "" Then
                            pagto_SAT = "01"
                        End If

                        spdSATDataSet.IncluirParte("PAGAMENTO")
                        spdSATDataSet.SetCampo("cMP_WA03=" & pagto_SAT)
                        VlrPagto += NuloDecimal(drPG.Item("ValorPago"))
                        txtEnt = Replace(Format(drPG.Item("ValorPago"), "####0.00"), ",", ".")
                        spdSATDataSet.SetCampo("vMP_WA04=" & txtEnt)
                        spdSATDataSet.SetCampo("cAdmC_WA05=")
                        spdSATDataSet.SalvarParte("PAGAMENTO")

                        If Local = "L" Then
                            If IDPagto = 0 Then
                                strSql = "UPDATE tblVendasPagto SET "
                                strSql &= "Cupom = 1 "
                                strSql &= "WHERE (IDVenda = " & drPG.Item("IDVenda") & ")"
                                ExecutaStr(strSql)
                            Else
                                strSql = "UPDATE tblVendasPagto SET "
                                strSql &= "Cupom = 1 "
                                strSql &= "WHERE (IDVendaPagto = " & drPG.Item("IDVendaPagto") & ")"
                                ExecutaStr(strSql)
                            End If
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
                'spdSATDataSet.SetCampo("infCpl_Z02=SEQUENCIA: " & TextoLivre)
                'spdSATDataSet.SetCampo("infCpl_Z02=SEQUENCIA: " & "")



                Try

                    spdSATDataSet.Salvar()

                    System.Threading.Thread.Sleep(500)

                    frmPrincipal.tbmmRetorno.Text = spdSATDataSet.LoteCFeSat

                    frmPrincipal.tbEdtUltIDAutorizado.Text = ""
                    Dim aRetorno As String
                    Dim arrRetorno() As String
                    Dim XML_Envio As String = frmPrincipal.tbmmRetorno.Text


                    'CarregaIni_SatCP(Local_SAT)


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
                            ArqImp = Application.StartupPath & "\Sat\CopiaSeguranca\" & ArqImp & ".xml"
                        Else
                            ArqImp = Application.StartupPath & "\Sat\CopiaSeguranca\" & ArqImp & ".xml"
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
                        System.Threading.Thread.Sleep(500)
                        Call CopiaXML(ArqImp, "V", ArqImp)

                        ' Grava no banco de dados /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        System.Threading.Thread.Sleep(500)

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


    Function CopiaXML(Arquivo As String, Tipo As String, ArquivoDestino As String)
        On Error GoTo errCopXML

        Dim Numerr As Integer
        Numerr = 0
Volta:
        If Tipo = "V" Then
            Call My.Computer.FileSystem.CopyFile(Arquivo, DirDestino & "\Enviados\" & Mid(frmPrincipal.tbEdtUltIDAutorizado.Text, 4, Len(frmPrincipal.tbEdtUltIDAutorizado.Text) - 3) & ".xml")
        End If
        If Tipo = "C" Then
            Call My.Computer.FileSystem.CopyFile(DirDestino & "\Enviados\" & Arquivo & ".xml", DirDestino & "\Cancelados\" & "C" & ArquivoDestino)
            Call My.Computer.FileSystem.DeleteFile(DirDestino & "\Enviados\" & Arquivo & ".xml")
        End If


saierrCopXML:
        Exit Function

errCopXML:
        If Err.Number = 53 Then
            If Numerr > 100 Then
                MsgBox("O arquivo  " & Arquivo & "  nao foi localizado", vbInformation)
            Else
                Numerr = Numerr + 1
                Resume Volta
            End If
        Else
            If Err.Number = 58 Then
                MsgBox("O arquivo  " & Arquivo & "  já existe", vbInformation)
            Else
                MsgBox(Err.Description)
                Resume saierrCopXML
            End If
        End If


    End Function
    Function CriaDiretorioSAT_Delivery(Mes As String, Ano As String, Dia As String)
        On Error GoTo errDir

        Dim Diretorio As String
        Diretorio = Trim(Mes) & "-" & Trim(Ano)


        MkDir(Application.StartupPath & "\MovtoDelivery\")
        MkDir(Application.StartupPath & "\MovtoDelivery\" & Diretorio)
        MkDir(Application.StartupPath & "\MovtoDelivery\" & Diretorio & "\" & Trim(Dia))
        MkDir(Application.StartupPath & "\MovtoDelivery\" & Diretorio & "\" & Trim(Dia) & "\Enviados")
        MkDir(Application.StartupPath & "\MovtoDelivery\" & Diretorio & "\" & Trim(Dia) & "\Cancelados")
        DirDestino = Application.StartupPath & "\MovtoDelivery\" & Diretorio & "\" & Trim(Dia)


saierrDir:
        Exit Function

errDir:
        If Err.Number = 75 Then Resume Next
        If Err.Number = 76 Then Resume Next
        If Err.Number = 57 Then Resume Next
        MsgBox(Err.Description & " - " & Err.Number)
        Resume saierrDir

    End Function
    Function CriaDiretorio(Mes As String, Ano As String, Dia As String)
        On Error GoTo errDir

        Dim Diretorio As String
        Diretorio = Trim(Mes) & "-" & Trim(Ano)


        MkDir(Application.StartupPath & "\Movto\")
        MkDir(Application.StartupPath & "\Movto\" & Diretorio)
        MkDir(Application.StartupPath & "\Movto\" & Diretorio & "\" & Trim(Dia))
        MkDir(Application.StartupPath & "\Movto\" & Diretorio & "\" & Trim(Dia) & "\Enviados")
        MkDir(Application.StartupPath & "\Movto\" & Diretorio & "\" & Trim(Dia) & "\Cancelados")
        DirDestino = Application.StartupPath & "\Movto\" & Diretorio & "\" & Trim(Dia)


saierrDir:
        Exit Function

errDir:
        If Err.Number = 75 Then Resume Next
        If Err.Number = 76 Then Resume Next
        If Err.Number = 57 Then Resume Next
        MsgBox(Err.Description & " - " & Err.Number)
        Resume saierrDir

    End Function
    Function CalculaNCM_SAT(CodNCM As String, VlrProd As Decimal)

        Dim Retorno As Boolean = False

        If CodNCM = "" Then Exit Function

        strSql = "Select * From tblTabelaNCM WHERE CodigoNCM = " & CodNCM

        Dim conNCM As New SqlConnection(strCon)
        conNCM.Open()
        Dim cmdNCM As New SqlCommand(strSql, conNCM)
        cmdNCM.CommandType = CommandType.Text

        Dim drNCM As SqlDataReader = cmdNCM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drNCM.HasRows Then
            drNCM.Read()
            VlrBaseNCM = VlrProd * (drNCM.Item("AliquotaNCM") / 100)
            VlrNCM += (VlrProd * (drNCM.Item("AliquotaNCM") / 100))
            Retorno = True
        End If
        drNCM.Close()
        cmdNCM.Dispose()
        conNCM.Dispose()
        conNCM.Close()

        Return Retorno

    End Function


    Function ReadUTF8File(sFile) As String
        Const ForReading = 1
        Dim sPrefix
        With CreateObject("Scripting.FileSystemObject")
            sPrefix = .OpenTextFile(sFile, ForReading, False, False).Read(3)
        End With
        If Left(sPrefix, 3) <> Chr(&HEF) & Chr(&HBB) & Chr(&HBF) Then
            With CreateObject("Scripting.FileSystemObject")
                'pvReadFile = .OpenTextFile(sFile, ForReading, False, Left(sPrefix, 2) = Chr(&HFF) & Chr(&HFE)).ReadAll()
                'ReadUTF8File = pvReadFile

                ReadUTF8File = .OpenTextFile(sFile, ForReading, False, Left(sPrefix, 2) = Chr(&HFF) & Chr(&HFE)).ReadAll()
            End With
        Else
            With CreateObject("ADODB.Stream")
                .Open
                If Left(sPrefix, 2) = Chr(&HFF) & Chr(&HFE) Then
                    .Charset = "Unicode"
                ElseIf Left(sPrefix, 3) = Chr(&HEF) & Chr(&HBB) & Chr(&HBF) Then
                    .Charset = "UTF-8"
                Else
                    .Charset = "_autodetect"
                End If
                .LoadFromFile(sFile)
                'pvReadFile = .ReadText
                'ReadUTF8File = pvReadFile
                ReadUTF8File = .ReadText
            End With
        End If
    End Function

End Module
