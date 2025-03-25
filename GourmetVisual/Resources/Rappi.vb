Imports System.Data.SqlClient
Imports Newtonsoft.Json


Module Rappi
    Public token_accessRappi As String

    Public Cliente_ID_Rappi As String

    Public IDClienteApp As Integer
    Public IDRuaApp As Integer
    Public IDFormaPagtoRappi As Integer
    Public IDClienteDefaultRappi As Integer

    Public NumeroLograApp As String
    Public BairroApp As String
    Public CEPApp As String
    Public ReferenciaApp As String
    Public ComplementoApp As String
    Public CidadeApp As String
    Public EstadoApp As String
    Public LogradouroApp As String
    Public DDDApp As String
    Public Tel1App As String
    Public NomeClienteApp As String
    Public e_mailApp As String
    Public AreaEntregaApp As String
    Public IDVendaD_App As String

    Public token_DataHoraFim_Rappi As Date

    Function VerificaPedidosRappi()

        Dim InfoCliente As Boolean
        Dim api As New ApisRappi(Cliente_ID_Rappi, Client_Secret_Rappi, Audience_Rappi)
        Dim ret As New RetOrders()
        ret.lista = New List(Of ModelsRappi.RappiPedidos)()
        ret.json = NuloString(PegaValorCampo("Json", "SELECT IDVendaExterna, Json FROM tblAppVendas WHERE IDVendaExterna='" & frmAppPedidos.Grid.Item(2, frmAppPedidos.Grid.CurrentRow.Index).Value & "'", strCon))

        Dim MetPagto As String
        Dim TotalParaPagto As Decimal
        Dim lista1 As New List(Of ModelsRappi.RappiPedidos)
        lista1 = JsonConvert.DeserializeObject(Of List(Of ModelsRappi.RappiPedidos))(ret.json)

        ret.lista = lista1

        Dim json = ret.json
        Dim lista = ret.lista
        For i = 0 To lista.Count - 1
            Dim jasonPedido As String = json
            Dim IDreferencia As String = NuloString(lista(i).order_detail.order_id)
            Dim idPedido As String = IDreferencia
            IDVendaD_App = IDreferencia
            MetPagto = UCase(NuloString(lista(i).order_detail.payment_method))
            TotalParaPagto = NuloDecimal(lista(i).order_detail.totals.total_to_pay)

            Dim TipoRetirada As String = ""
            Dim Metodo As String = UCase(NuloString(lista(i).order_detail.delivery_method))
            If Metodo = "DELIVERY" Then
                ' TipoRetirada = NuloString(Pedido.deliveryMethod.id)
            End If

            Dim IDclienteExt As String = ""
            Dim telefone As String = ""
            Dim txEnt As Decimal = 0
            Dim CpfCnpj As String = ""

            Dim NomeCli As String = ""
            Dim Email As String = ""
            Dim NomeRua As String = ""
            Dim NumeroRua As String = ""
            Dim CEPRua As String = ""
            Dim BairroRua As String = ""
            Dim ReferenciaRua As String = ""
            Dim ComplementoRua As String = ""
            Dim Cidade As String = ""
            Dim Estado As String = ""

            InfoCliente = True

            If IsNothing(lista(i).order_detail.delivery_information) Then
                InfoCliente = False
            End If

            If InfoCliente = True And Metodo <> "DELIVERY" Then
                IDclienteExt = ""

                If InfoCliente = True Then
                    NomeCli = UCase(NuloString(lista(i).customer.first_name) & " " & NuloString(lista(i).customer.last_name))
                Else
                    NomeCli = "NAO INFORMADO"
                End If
                If Not IsNothing(lista(i).order_detail.billing_information) Then
                    Email = NuloString(lista(i).order_detail.billing_information.email)
                Else
                    Email = ""
                End If

                NomeRua = NuloString(lista(i).order_detail.delivery_information.street_shorcut) & ", " & NuloString(lista(i).order_detail.delivery_information.street_name)
                If NuloString(lista(i).order_detail.delivery_information.street_shorcut) = "" Then
                    NumeroRua = Strings.Left(NuloString(lista(i).order_detail.delivery_information.complete_address), 100)
                Else
                    NumeroRua = NuloString(lista(i).order_detail.delivery_information.street_number)
                End If
                CEPRua = NuloString(lista(i).order_detail.delivery_information.postal_code)
                BairroRua = NuloString(lista(i).order_detail.delivery_information.neighborhood)
                ComplementoRua = NuloString(lista(i).order_detail.delivery_information.complement)
                'ReferenciaRua = NuloString(lista(i).order_detail.delivery_information.complement)
                ReferenciaRua = ""
                Cidade = NuloString(lista(i).order_detail.delivery_information.city)
                Estado = NuloString(lista(i).order_detail.delivery_information.federal_unit)

                If InfoCliente = True Then
                    telefone = NuloString(lista(i).customer.phone_number)
                Else
                    telefone = ""
                End If
                If telefone = "" Then telefone = "000000000"
                telefone = Replace(telefone, "-", "")
                txEnt = NuloDecimal(lista(i).order_detail.totals.charges.shipping)
                If Not IsNothing(lista(i).order_detail.billing_information) Then
                    CpfCnpj = Replace(Replace(Replace(NuloString(lista(i).order_detail.billing_information.document_number), "-", ""), "/", ""), ".", "")
                Else
                    CpfCnpj = ""
                End If

            Else
                strSql = "SELECT * FROM tblClientes WHERE IDCliente=" & IDClienteDefaultRappi

                Dim IDrua As Integer = NuloInteger(PegaValorCampo("IDRua", strSql, strCon))
                Dim strSqlR As String = "SELECT * FROM tblRuas WHERE IDRua=" & IDrua

                'NomeCli = NuloString(PegaValorCampo("NomeCliente", strSql, strCon))
                NomeCli = UCase(NuloString(lista(i).order_detail.billing_information.name))

                Email = NuloString(PegaValorCampo("Email", strSql, strCon))
                NomeRua = NuloString(PegaValorCampo("Logradouro", strSqlR, strCon))
                NumeroRua = NuloString(PegaValorCampo("Numero", strSql, strCon))
                CEPRua = NuloString(PegaValorCampo("CEP", strSql, strCon))
                BairroRua = NuloString(PegaValorCampo("Bairro", strSqlR, strCon))
                ComplementoRua = NuloString(PegaValorCampo("Complemento", strSql, strCon))
                ReferenciaRua = NuloString(PegaValorCampo("Referencia", strSql, strCon))
                Cidade = NuloString(PegaValorCampo("Cidade", strSql, strCon))
                Estado = NuloString(PegaValorCampo("Estado", strSql, strCon))

                telefone = NuloString(PegaValorCampo("Tel1", strSql, strCon))
                CpfCnpj = Replace(Replace(Replace(NuloString(PegaValorCampo("CPF_CNPJ", strSql, strCon)), "-", ""), "/", ""), ".", "")
            End If

            resolveCliente(UCase(VerificaTexto(NuloString(NomeCli))), telefone, NuloString(Email), UCase(VerificaTexto(NuloString(NomeRua))), NuloString(NumeroRua), UCase(VerificaTexto(NuloString(BairroRua))), NuloString(CEPRua), UCase(NuloString(ReferenciaRua)), UCase(NuloString(ComplementoRua)), UCase(NuloString(Cidade)), UCase(NuloString(Estado)), txEnt, "RAPPI", IDclienteExt)

            Dim vlrTroco As Decimal = 0
            Dim totGeral As Decimal = NuloDecimal(lista(i).order_detail.totals.total_order)
            Dim totProd As Decimal = NuloDecimal(lista(i).order_detail.totals.total_products_without_discount)
            Dim totPagto As Decimal

            Dim vlrDesc As Decimal
            If Not IsNothing(lista(i).order_detail.delivery_discount) Then
                vlrDesc = NuloDecimal(lista(i).order_detail.delivery_discount.total_value_discount)
            Else
                vlrDesc = 0
            End If

            Dim percDesc As Decimal
            If totProd > 0 Then
                percDesc = NuloDecimal((vlrDesc / totGeral) * 100)
            Else
                percDesc = 0
            End If

            Dim vlrCaixinha As Decimal
            If NuloDecimal(totPagto - totGeral) > 0 Then
                vlrCaixinha = NuloDecimal(totPagto - totGeral)
            Else
                vlrCaixinha = 0
            End If

            totPagto = totGeral - vlrDesc

            If IDVendaD_App <> 0 Then
                ' INSERE PRODUTOS  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Dim CodPro As Integer
                Dim CodProExterno As String
                Dim CodProCombo As Integer
                Dim CodPizza As Integer
                Dim Qtde As Decimal
                Dim vlrUnit As Decimal
                Dim IDmovto As Integer
                Dim Enviado As Boolean
                Dim Epizza As Boolean
                Dim ImprimeCategoria As Boolean
                Dim MontaPizza As Boolean
                Dim IDproduto As Integer
                Dim IDprodutoPizza As Integer
                Dim CodGru As Integer
                Dim NomeGrupo As String
                Dim Produto As String
                Dim Categoria As String
                Dim index As Integer = 0
                Dim Item As Integer = 0
                Dim Obs As String = ""
                Dim NomeProdRappi As String

                Dim QtdeCombo As Decimal
                Dim vlrUnitCombo As Decimal
                Dim vlrProduto As Decimal = 0
                Dim vlrProdutos As Decimal = 0
                Dim Agrega As Boolean
                Dim EpizzaCombo As Boolean
                Dim CodProExternoCombo As String
                Dim QtdSubItems As Integer
                Dim IDfamilia As Integer
                Dim ComentVinc As String

                strSql = "DELETE FROM tblAppVendasMovto WHERE (IDVendaExterna='" & NuloString(IDVendaD_App) & "')"
                ExecutaStr(strSql)

                strSql = "DELETE FROM tblAppVendasCombo WHERE (IDVendaExterna='" & NuloString(IDVendaD_App) & "')"
                ExecutaStr(strSql)

                strSql = "DELETE FROM tblAppVendasComent WHERE (IDVendaExterna='" & NuloString(IDVendaD_App) & "')"
                ExecutaStr(strSql)

                strSql = "DELETE FROM tblAppVendasPagto WHERE (IDVendaExterna='" & NuloString(IDVendaD_App) & "')"
                ExecutaStr(strSql)

                For iv = 0 To lista(i).order_detail.items.Count - 1

                    System.Threading.Thread.Sleep(100)

                    Epizza = False
                    CodProExterno = NuloString(lista(i).order_detail.items(iv).id)
                    CodPro = NuloInteger(lista(i).order_detail.items(iv).sku)
                    Qtde = NuloDecimal(lista(i).order_detail.items(iv).quantity)
                    vlrUnit = NuloDecimal(lista(i).order_detail.items(iv).unit_price_with_discount)
                    index = NuloInteger(iv)
                    Obs = UCase(NuloString(lista(i).order_detail.items(iv).comments))

                    If CodPro <> 0 Then
                        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblGrupos_Local.EPizza, tblProdutos_Local.Venda, tblGrupos_Local.Grupo, tblProdutos_Local.ImprimeCategoria "
                        strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                        strSql += "Where (CodigoProduto =" & CodPro & ")"
                    Else
                        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblGrupos_Local.EPizza, tblProdutos_Local.Venda, tblGrupos_Local.Grupo, tblProdutosExterno_Local.CodigoProdutoExterno "
                        strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo INNER Join tblProdutosExterno_Local On tblProdutos_Local.IDProduto = tblProdutosExterno_Local.IDProduto "
                        strSql += "Where (tblProdutosExterno_Local.CodigoProdutoExterno = '" & CodProExterno & "')"
                    End If


                    Dim dap = New SqlDataAdapter(strSql, strCon)
                    Dim ds As New DataSet()

                    dap.SelectCommand.CommandType = CommandType.Text
                    dap.Fill(ds, "Prod")

                    If ds.Tables("Prod").Rows.Count > 0 Then
                        Epizza = NuloBoolean(ds.Tables("Prod").Rows(0).Item("EPizza"))
                        ImprimeCategoria = NuloBoolean(ds.Tables("Prod").Rows(0).Item("ImprimeCategoria"))
                        IDproduto = NuloInteger(ds.Tables("Prod").Rows(0).Item("IDProduto"))
                        CodGru = NuloInteger(ds.Tables("Prod").Rows(0).Item("CodigoGrupo"))
                        NomeGrupo = NuloString(ds.Tables("Prod").Rows(0).Item("Grupo"))
                        Produto = NuloString(ds.Tables("Prod").Rows(0).Item("Produto"))
                        Categoria = NuloString(ds.Tables("Prod").Rows(0).Item("Categoria"))
                        MontaPizza = False
                        IDprodutoPizza = 0

                        If Epizza = True Then
                            strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local_1.CodigoProduto As CodigoPizza, tblProdutos_Local_1.Categoria, tblProdutos_Local_1.ImprimeCategoria, tblProdutos_Local_1.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local_1.IDProduto AS IDProdutoPizza, tblProdutos_Local_1.Produto "
                            strSql += "From tblProdutos_Local INNER Join tblCombos_Local On tblProdutos_Local.IDFamilia = tblCombos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                            strSql += "Where (tblProdutos_Local.IDProduto = " & IDproduto & ")"

                            CodPizza = NuloInteger(PegaValorCampo("CodigoPizza", strSql, strCon))
                            CodPro = NuloInteger(PegaValorCampo("CodigoProduto", strSql, strCon))
                            IDprodutoPizza = NuloInteger(PegaValorCampo("IDprodutoPizza", strSql, strCon))
                            If CodPizza <> CodPro Then
                                MontaPizza = True
                                InserirItemVendaApp(IDVendaD_App, IDprodutoPizza, NuloString(PegaValorCampo("Produto", strSql, strCon)), Qtde, NuloBoolean(Enviado), NuloDecimal(vlrUnit), NuloDecimal(vlrUnit), NuloString(PegaValorCampo("Categoria", strSql, strCon)), Date.Now, 0, "APP", NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon)), NuloString(PegaValorCampo("Grupo", strSql, strCon)), NuloBoolean(0), "", NuloBoolean(0), "", "APP", NuloBoolean(PegaValorCampo("ImprimeCategoria", strSql, strCon)), SetorDelivery, False, 1, CodProExterno)
                                IDmovto = NuloInteger(PegaID("IDAppVendaMovto", "tblAppVendasMovto", "L"))

                                InserirItemComboVendaApp(IDmovto, IDVendaD_App, IDproduto, NuloString(Strings.Left(Produto, 50)), Qtde, vlrUnit, vlrUnit, CodGru, NomeGrupo, Categoria, Agrega, 1, CodProExterno)
                            End If
                        End If
                    Else
                        ImprimeCategoria = False
                        IDproduto = 0
                        CodGru = 0
                        NomeGrupo = ""
                        Produto = Strings.Left(UCase(NuloString(lista(i).order_detail.items(iv).name)), 50)
                        Categoria = ""
                    End If

                    Enviado = False

                    If MontaPizza = False Then
                        InserirItemVendaApp(IDVendaD_App, NuloInteger(IDproduto), NuloString(Strings.Left(Produto, 50)), Qtde, NuloBoolean(Enviado), NuloDecimal(vlrUnit), NuloDecimal(vlrUnit), NuloString(Categoria), Date.Now, 0, "APP", NuloInteger(CodGru), NuloString(NomeGrupo), NuloBoolean(0), "", NuloBoolean(0), "", "APP", NuloBoolean(ImprimeCategoria), SetorDelivery, False, 1, CodProExterno)
                        IDmovto = NuloInteger(PegaID("IDAppVendaMovto", "tblAppVendasMovto", "L"))
                    End If


                    ' VERIFICA COMBO   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    QtdeCombo = 0
                    vlrUnitCombo = 0
                    vlrProduto = 0
                    Agrega = False
                    EpizzaCombo = False
                    CodProExternoCombo = ""
                    QtdSubItems = 0
                    IDfamilia = 0
                    ComentVinc = ""
                    Item = 0
                    If Not IsNothing(lista(i).order_detail.items(iv).subitems) Then
                        QtdSubItems = NuloInteger(lista(i).order_detail.items(iv).subitems.Count - 1)
                        vlrProduto = vlrUnit
                        vlrProdutos += vlrProduto
                        For ii = 0 To QtdSubItems

                            System.Threading.Thread.Sleep(100)

                            CodProExternoCombo = NuloString(lista(i).order_detail.items(iv).subitems(ii).id)
                            CodProCombo = NuloInteger(lista(i).order_detail.items(iv).subitems(ii).sku)
                            QtdeCombo = NuloDecimal(lista(i).order_detail.items(iv).subitems(ii).quantity)
                            vlrUnitCombo = NuloDecimal(lista(i).order_detail.items(iv).subitems(ii).unit_price_with_discount)

                            If CodProCombo <> 0 Then
                                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Pizza, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblCombos_Local.AgregaValor, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblGrupos_Local.Grupo, tblGrupos_Local.EPizza "
                                strSql += "From tblProdutos_Local LEFT OUTER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo LEFT OUTER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto And tblProdutos_Local.IDFamilia = tblCombos_Local.IDFamilia "
                                strSql += "Where (CodigoProduto =" & CodProCombo & ")"
                            Else
                                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Pizza, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblCombos_Local.AgregaValor, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblGrupos_Local.Grupo, tblProdutosExterno_Local.CodigoProdutoExterno, tblGrupos_Local.EPizza "
                                strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo INNER Join tblProdutosExterno_Local On tblProdutos_Local.IDProduto = tblProdutosExterno_Local.IDProduto LEFT OUTER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto And tblProdutos_Local.IDFamilia = tblCombos_Local.IDFamilia "
                                strSql += "Where (tblProdutosExterno_Local.CodigoProdutoExterno = '" & CodProExternoCombo & "')"
                            End If

                            Dim dapS = New SqlDataAdapter(strSql, strCon)
                            Dim dsS As New DataSet()

                            dapS.SelectCommand.CommandType = CommandType.Text
                            dapS.Fill(dsS, "Combo")

                            NomeProdRappi = UCase(NuloString(lista(i).order_detail.items(iv).subitems(ii).name))

                            If dsS.Tables("Combo").Rows.Count > 0 Then
                                IDproduto = NuloInteger(dsS.Tables("Combo").Rows(0).Item("IDProduto"))
                                IDfamilia = NuloInteger(dsS.Tables("Combo").Rows(0).Item("IDFamilia"))
                                Produto = NuloString(dsS.Tables("Combo").Rows(0).Item("Produto"))
                                CodGru = NuloInteger(dsS.Tables("Combo").Rows(0).Item("CodigoGrupo"))
                                NomeGrupo = NuloString(dsS.Tables("Combo").Rows(0).Item("Grupo"))
                                Categoria = NuloString(dsS.Tables("Combo").Rows(0).Item("Categoria"))
                                Agrega = NuloBoolean(dsS.Tables("Combo").Rows(0).Item("AgregaValor"))
                                EpizzaCombo = NuloBoolean(dsS.Tables("Combo").Rows(0).Item("EPizza"))
                                ImprimeCategoria = NuloBoolean(dsS.Tables("Combo").Rows(0).Item("ImprimeCategoria"))
                            Else
                                IDproduto = 0
                                IDfamilia = 0
                                Produto = UCase(NuloString(lista(i).order_detail.items(iv).subitems(ii).name))
                                CodGru = 0
                                NomeGrupo = ""
                                Categoria = ""
                                Agrega = False
                                EpizzaCombo = False
                                ImprimeCategoria = False
                            End If

                            If Epizza = True Then
                                If EpizzaCombo = True Then
                                    If (NomeProdRappi = "GRANDE" Or NomeProdRappi = "MÉDIA" Or NomeProdRappi = "BROTO") Then
                                        strSql = "Select tblProdutos_Local.CodigoProduto As CodigoPizza, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.IDProduto As IDProdutoPizza, tblProdutos_Local.Produto "
                                        strSql += "From tblProdutos_Local As tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                                        strSql += "Where (tblProdutos_Local.IDProduto = " & IDproduto & ")"
                                        ExecutaStr("UPDATE tblAppVendasMovto Set IDProduto=" & NuloInteger(PegaValorCampo("IDprodutoPizza", strSql, strCon)) & ", Produto='" & NuloString(PegaValorCampo("Produto", strSql, strCon)) & "', IDGrupo=" & NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon)) & ", Grupo='" & NuloString(PegaValorCampo("Grupo", strSql, strCon)) & "' WHERE IDAppVendaMovto=" & IDmovto)
                                        vlrProduto += vlrUnitCombo * QtdeCombo
                                        vlrProdutos += vlrProduto
                                    Else
                                        If IDprodutoPizza <> IDproduto Then
                                            InserirItemComboVendaApp(IDmovto, IDVendaD_App, IDproduto, NuloString(Strings.Left(Produto, 50)), QtdeCombo, vlrUnitCombo, vlrUnitCombo, CodGru, NomeGrupo, Categoria, Agrega, 1, CodProExternoCombo)
                                        End If

                                        vlrProduto += vlrUnitCombo * QtdeCombo
                                        vlrProdutos += vlrProduto
                                    End If

                                Else
                                    If vlrUnitCombo <= 0 Then
                                        If IDproduto = 0 Then
                                            If Produto <> "MASSA TRADICIONAL" Then
                                                IncluiComentarioApp(IDVendaD_App, IDmovto, 0, VerificaTexto(NuloString(Strings.Left(Produto, 50))), 0, CodProExternoCombo)
                                            End If
                                        Else
                                            InserirItemVendaApp(IDVendaD_App, NuloInteger(IDproduto), NuloString(Strings.Left(Produto, 50)), QtdeCombo, NuloBoolean(Enviado), NuloDecimal(vlrUnitCombo), NuloDecimal(vlrUnitCombo), NuloString(Categoria), Date.Now, 0, "APP", NuloInteger(CodGru), NuloString(NomeGrupo), NuloBoolean(0), "", NuloBoolean(0), "", "APP", NuloBoolean(ImprimeCategoria), SetorDelivery, False, 1, CodProExternoCombo)
                                            vlrProduto += vlrUnitCombo * QtdeCombo
                                            vlrProdutos += vlrProduto
                                        End If
                                    Else
                                        InserirItemVendaApp(IDVendaD_App, NuloInteger(IDproduto), NuloString(Strings.Left(Produto, 50)), QtdeCombo, NuloBoolean(Enviado), NuloDecimal(vlrUnitCombo), NuloDecimal(vlrUnitCombo), NuloString(Categoria), Date.Now, 0, "APP", NuloInteger(CodGru), NuloString(NomeGrupo), NuloBoolean(0), "", NuloBoolean(0), "", "APP", NuloBoolean(ImprimeCategoria), SetorDelivery, False, 1, CodProExternoCombo)
                                        ComentVinc = NuloString(PegaValorCampo("Comentario", "Select IDComentario, IDfamilia, Comentario, IDproduto FROM tblComentarios_Local WHERE  (IDProduto = " & IDproduto & ")", strCon))
                                        If ComentVinc <> "" Then
                                            IncluiComentarioApp(IDVendaD_App, IDmovto, 0, VerificaTexto(ComentVinc), 0, CodProExternoCombo)
                                        End If
                                    End If
                                End If
                            Else
                                If QtdeCombo > 1 Then
                                    Produto = "(" & QtdeCombo & ") " & Produto
                                End If
                                If Produto <> "MASSA TRADICIONAL" Then
                                    InserirItemComboVendaApp(IDmovto, IDVendaD_App, IDproduto, NuloString(Strings.Left(Produto, 50)), QtdeCombo, vlrUnitCombo, vlrUnitCombo, CodGru, NomeGrupo, Categoria, Agrega, 1, CodProExternoCombo)
                                    vlrProduto += vlrUnitCombo * QtdeCombo
                                    vlrProdutos += vlrProduto
                                End If
                            End If

                            dapS.Dispose()
                            dsS.Clear()
                            dsS.Dispose()

                            Item += 1
                        Next

                        strSql = "UPDATE tblAppVendasMovto Set Venda= " & Replace(vlrProduto, ",", ".") & ",VendaServico=" & Replace(vlrProduto, ",", ".") & "WHERE IDAppVendaMovto=" & IDmovto
                        ExecutaStr(strSql)

                    End If

                    If Obs <> "" Then
                        IncluiComentarioApp(IDVendaD_App, IDmovto, 0, VerificaTexto(UCase(Obs)), 0, CodProExterno)
                    End If
                Next

                If vlrDesc > 0 Then
                    percDesc = NuloDecimal((vlrDesc / totGeral) * 100)
                End If

                strSql = "UPDATE tblAppVendas Set "
                strSql += "PercDesconto = " & Replace(percDesc, ",", ".") & ", "
                strSql += "Desconto =" & Replace(vlrDesc, ",", ".") & ", "
                strSql += "TotalVenda =" & Replace(totGeral, ",", ".") & ", "
                strSql += "TotalProdutos =" & Replace(vlrProdutos, ",", ".") & ", "
                strSql += "AreaEntrega ='" & AreaEntregaApp & "', "
                strSql += "TaxaEntrega =" & Replace(txEnt, ",", ".") & ", "
                strSql += "IDCliente=" & IDClienteApp & ", "
                strSql += "NomeCliente='" & IDClienteApp & "', "
                strSql += "IDRuaEntrega=" & IDRuaApp & ", "
                strSql += "CepEntrega='" & CEPApp & "', "
                strSql += "NumeroEntrega='" & NumeroLograApp & "', "
                strSql += "ComplementoEntrega='" & ComplementoApp & "', "
                strSql += "ReferenciaEntrega='" & ReferenciaApp & "' "
                strSql += "WHERE (IDVendaExterna='" & NuloString(idPedido) & "')"
                ExecutaStr(strSql)

                ' INSERE PAGAMENTO  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                If IDFormaPagtoRappi <> 0 Then
                    If MetPagto = "cash" Or MetPagto = "CASH" Then
                        strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (Descricao LIKE '%DINHEIRO%')"
                        InserirPagtoVendaApp(IDVendaD_App, NuloString(PegaValorCampo("IDFormaPagto", strSql, strCon)), "DINHEIRO", TotalParaPagto, NuloBoolean(PegaValorCampo("ECartao", strSql, strCon)), NuloDecimal(PegaValorCampo("Taxa", strSql, strCon)), NuloString(PegaValorCampo("Tipo", strSql, strCon)), 1)
                        If totPagto - TotalParaPagto > 0 Then
                            strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (IDFormaPagto=" & IDFormaPagtoRappi & ")"
                            InserirPagtoVendaApp(IDVendaD_App, IDFormaPagtoRappi, NuloString(PegaValorCampo("Descricao", strSql, strCon)), (totPagto - TotalParaPagto), NuloBoolean(PegaValorCampo("ECartao", strSql, strCon)), NuloDecimal(PegaValorCampo("Taxa", strSql, strCon)), NuloString(PegaValorCampo("Tipo", strSql, strCon)), 1)
                        End If
                    Else
                        If TotalParaPagto > 0 Then
                            strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (Descricao LIKE '%DINHEIRO%')"
                            InserirPagtoVendaApp(IDVendaD_App, NuloString(PegaValorCampo("IDFormaPagto", strSql, strCon)), "DINHEIRO", TotalParaPagto, NuloBoolean(PegaValorCampo("ECartao", strSql, strCon)), NuloDecimal(PegaValorCampo("Taxa", strSql, strCon)), NuloString(PegaValorCampo("Tipo", strSql, strCon)), 1)
                            If totPagto - TotalParaPagto > 0 Then
                                strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (IDFormaPagto=" & IDFormaPagtoRappi & ")"
                                InserirPagtoVendaApp(IDVendaD_App, IDFormaPagtoRappi, NuloString(PegaValorCampo("Descricao", strSql, strCon)), (totPagto - TotalParaPagto), NuloBoolean(PegaValorCampo("ECartao", strSql, strCon)), NuloDecimal(PegaValorCampo("Taxa", strSql, strCon)), NuloString(PegaValorCampo("Tipo", strSql, strCon)), 1)
                            End If
                        Else
                            strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (IDFormaPagto=" & IDFormaPagtoRappi & ")"
                            InserirPagtoVendaApp(IDVendaD_App, IDFormaPagtoRappi, NuloString(PegaValorCampo("Descricao", strSql, strCon)), totPagto, NuloBoolean(PegaValorCampo("ECartao", strSql, strCon)), NuloDecimal(PegaValorCampo("Taxa", strSql, strCon)), NuloString(PegaValorCampo("Tipo", strSql, strCon)), 1)
                        End If
                    End If
                Else
                    InserirPagtoVendaApp(IDVendaD_App, 0, "", totPagto, False, 0, "", 1)
                End If
            End If
        Next

    End Function
End Module
