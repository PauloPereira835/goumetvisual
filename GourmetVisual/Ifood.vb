Imports System.Data.SqlClient
Imports Newtonsoft.Json

Module Ifood
    Public IDRua As Integer
    Public Logradouro As String
    Public NumeroLogra As String
    Public AreaEntrega As String
    Public Bairro As String
    Public CEP As String
    Public Referencia As String
    Public Complemento As String
    Public Cidade As String
    Public Estado As String
    Public DDD As String
    Public Tel1 As String
    Public NomeCliente As String
    Public e_mail As String
    'Public IDcliente As Integer

    Public IDFormaPagtoIfood As Integer
    Public IDFormaPagtoQRbox As Integer
    Public Sub VerificaPedidosIfood(Json As Object)

        'Dim resp = CType(Activator.CreateInstance(GetType(QrboxApp.QrboxPedidoResponse)), QrboxApp.QrboxPedidoResponse)
        'resp = DoRequest(Of T2)(UrlBase, req, resp, Log, apiDef.method, strUrl, app)
        'resp = JsonConvert.DeserializeObject(Of T)(Log.response, appQRbox.Settings)
        'Dim Order = resp
        'Dim Pedido = resp

        Dim Order = IfoodUtil.Enviar(Of QrboxApp.QrboxPedidoResponse, QrboxApp.QrboxPedidoResponse)(appIfood.Uri_Ifood, "orders", "IFOOD", Nothing, IDPedido.ToString(), "0")
        Dim Pedido = Order.Item1

        'Dim str = "{""id"":""fdb459ae-45ed-4d9d-82ee-ad6bb79a97f7"",""reference"":""7069286697650077"",""shortReference"":""9050"",""scheduled"":false,""isTest"":false,""preparationTimeInSeconds"":780,""takeOutTimeInSeconds"":1800,""createdAt"":""2020-09-18T17:42:33.589127Z"",""preparationStartDateTime"":""2020-09-18T17:42:33.589127Z"",""deliveryDateTime"":""2020-09-18T18:16:33.589127Z"",""customer"":{""id"":""166677643"",""uuid"":""59e77930-015b-450e-9b5f-453ef9d419d0"",""name"":""Eduardo Marenza"",""taxPayerIdentificationNumber"":""29802273821"",""phone"":""0800 007 0110 ID: 45955560"",""ordersCountOnRestaurant"":1},""deliveryAddress"":{""formattedAddress"":""Av. Odila, 574"",""country"":""BR"",""state"":""SP"",""city"":""São Paulo"",""coordinates"":{""latitude"":-23.61039,""longitude"":-46.646498},""neighborhood"":""Planalto Paulista"",""streetName"":""Av. Odila"",""streetNumber"":""574"",""postalCode"":""04066000"",""complement"":""Deixar o pedido no portão da casa/prédio - ""},""payments"":[{""name"":""MASTERCARD"",""code"":""MC"",""value"":162.99,""prepaid"":true,""transaction"":""00000000-0000-0000-0000-000000000000"",""issuer"":""MASTERCARD"",""authorizationCode"":""00""}],""deliveryMethod"":{""id"":""DEFAULT"",""value"":7.99,""minTime"":34,""maxTime"":44,""mode"":""DELIVERY"",""deliveredBy"":""IFOOD""},""merchant"":{""id"":""83f443bd-4317-42ac-9072-a59919b768c3"",""shortId"":""1028992"",""name"":""Agello Cucina"",""address"":{""formattedAddress"":""Rua Sônia Ribeiro"",""country"":""BR"",""state"":""SP"",""city"":""SAO PAULO"",""neighborhood"":""Campo Belo"",""streetName"":""Rua Sônia Ribeiro"",""streetNumber"":""33"",""postalCode"":""04620020""}},""localizer"":{""id"":""45955560""},""items"":[{""id"":""40024f09-0304-4170-8d38-1ae5baefff9f"",""name"":""Fraldinha Alfredo - 200g"",""quantity"":1,""price"":85.00,""subItemsPrice"":0.00,""totalPrice"":85.00,""discount"":0.0,""addition"":0.0,""externalId"":""230798344"",""externalCode"":""709"",""subItems"":[{""id"":""533e6a98-951f-433e-add6-a046e7b4b1d9"",""name"":""Ao ponto"",""quantity"":1,""price"":0.00,""totalPrice"":0.00,""discount"":0.0,""addition"":0.00,""externalCode"":""46""}],""index"":1},{""id"":""c3fb3e9b-75c0-4f22-9959-e4721b807f41"",""name"":""Medalhão de Mignon - 150g, com Purê de Mandioquinha"",""quantity"":1,""price"":70.00,""subItemsPrice"":0.00,""totalPrice"":70.00,""discount"":0.0,""addition"":0.0,""externalId"":""211322550"",""externalCode"":""176"",""subItems"":[{""id"":""88f0f89e-c44c-429b-90d0-398bcaac2a4c"",""name"":""Ao Ponto"",""quantity"":1,""price"":0.00,""totalPrice"":0.00,""discount"":0.0,""addition"":0.00,""externalCode"":""46""}],""index"":3}],""subTotal"":155.00,""totalPrice"":162.99,""deliveryFee"":7.99}"
        'Dim Pedido = QrboxApp.QrboxPedidoResponse.FromJson(str)

        Dim idPed As String = NuloString(Pedido.Id)

        Dim jasonPedido As String = Json
        'Dim jasonPedido As String = str
        Dim IDreferencia As String = NuloString(Pedido.ShortReference)
        Dim IDclienteExt As String = NuloString(Pedido.Customer.id)
        Dim Metodo As String = NuloString(Pedido.deliveryMethod.mode)
        Dim TipoRetirada As String = ""
        If Metodo <> "DELIVERY" Then
            TipoRetirada = NuloString(Pedido.deliveryMethod.id)
        End If

        Dim telefone As String = NuloString(Pedido.Customer.Phone)
        telefone = Replace(telefone, "-", "")
        Dim txEnt As Decimal = NuloDecimal(Pedido.DeliveryFee)
        Dim CpfCnpj As String = Replace(Replace(Replace(NuloString(Pedido.Customer.TaxPayerIdentificationNumber), "-", ""), "/", ""), ".", "")
        Dim LogradouroEntrega As String = UCase(VerificaTexto(NuloString(Pedido.DeliveryAddress.StreetName)))

        ' DADOS DO CLIENTE/ENDEREÇO   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If telefone <> "" And NuloString(Pedido.Customer.Name) <> "" Then
            resolveCliente(UCase(VerificaTexto(NuloString(Pedido.Customer.Name))), telefone, NuloString(Pedido.Customer.Email), LogradouroEntrega, NuloString(Pedido.DeliveryAddress.StreetNumber), UCase(VerificaTexto(NuloString(Pedido.DeliveryAddress.Neighborhood))), NuloString(Pedido.DeliveryAddress.PostalCode), UCase(NuloString(Pedido.DeliveryAddress.Reference)), UCase(NuloString(Pedido.DeliveryAddress.Complement)), UCase(NuloString(Pedido.DeliveryAddress.City)), UCase(NuloString(Pedido.DeliveryAddress.State)), txEnt, "IFOOD", IDclienteExt)
        End If



        Dim vlrTroco As Decimal
        If NuloDecimal(Pedido.Payments.ElementAt(0).ChangeFor) <> 0 Then
            vlrTroco = NuloDecimal(Strings.Left(Pedido.Payments.ElementAt(0).ChangeFor, Len(Pedido.Payments.ElementAt(0).ChangeFor) - 2) & "." & Strings.Right(Pedido.Payments.ElementAt(0).ChangeFor, 2))
        Else
            vlrTroco = 0
        End If
        Dim totGeral As Decimal = NuloDecimal(Pedido.TotalPrice)
        Dim totProd As Decimal = NuloDecimal(Pedido.SubTotal)
        Dim totPagto As Decimal = NuloDecimal(Pedido.Payments.ElementAt(0).Value)
        Dim vlrDesc As Decimal = NuloDecimal(Math.Abs(totProd + txEnt - totPagto))
        Dim percDesc As Decimal
        If totProd > 0 Then
            percDesc = NuloDecimal((vlrDesc / totProd) * 100)
        Else
            percDesc = 0
        End If
        Dim vlrCaixinha As Decimal
        If NuloDecimal(totPagto - totGeral) > 0 Then
            vlrCaixinha = NuloDecimal(totPagto - totGeral)
        Else
            vlrCaixinha = 0
        End If

        ' ABRE VENDA  ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'strSql = "SELECT IDVendaExterna FROM tblAppVendas WHERE (IDVendaExterna='" & idPedido & "')"
        'IDVendaD = NuloInteger(PegaValorCampo("IDVendaExterna", strSql))

        strSql = "DELETE FROM tblAppVendas WHERE (IDVendaExterna='" & NuloString(IDPedido) & "')"
        ExecutaStr(strSql)

        'If IDVendaD = 0 Then
        AbreVendaApp(percDesc, 0, IDCliente, IDRua, CEP, NumeroLogra, Complemento, Referencia, "", "", NomeCliente, vlrTroco, 0, txEnt, vlrDesc, totProd, totGeral, vlrCaixinha, CpfCnpj, idPed, "IFOOD", NuloString(idPed), AreaEntrega, jasonPedido, IDreferencia, IDclienteExt, LogradouroEntrega)
        'End If
        If IDVendaD <> "" Then
            ' INSERE PRODUTOS  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Dim CodPro As Integer
            Dim CodProExterno As String
            Dim CodProCombo As Integer
            Dim Qtde As Decimal
            Dim vlrUnit As Decimal
            Dim IDmovto As Integer
            Dim Enviado As Boolean
            Dim Epizza As Boolean
            Dim ImprimeCategoria As Boolean
            Dim IDproduto As Integer
            Dim CodGru As Integer
            Dim NomeGrupo As String
            Dim Produto As String
            Dim Categoria As String
            Dim index As Integer = 0
            Dim Item As Integer = 0
            Dim Obs As String = ""

            strSql = "DELETE FROM tblAppVendasMovto WHERE (IDVendaExterna='" & NuloString(IDVendaD) & "')"
            ExecutaStr(strSql)

            strSql = "DELETE FROM tblAppVendasCombo WHERE (IDVendaExterna='" & NuloString(IDVendaD) & "')"
            ExecutaStr(strSql)

            For i = 0 To Pedido.Items.Count - 1

                Epizza = False
                CodProExterno = NuloString(Pedido.Items(i).Id)
                CodPro = NuloInteger(Pedido.Items(i).ExternalCode)
                Qtde = NuloDecimal(Pedido.Items(i).Quantity)
                vlrUnit = NuloDecimal(Pedido.Items(i).TotalPrice)
                index = NuloInteger(Pedido.Items(i).index)
                Obs = UCase(NuloString(Pedido.Items(i).Observations))

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
                Else
                    ImprimeCategoria = False
                    IDproduto = 0
                    CodGru = 0
                    NomeGrupo = ""
                    Produto = Strings.Left(UCase(NuloString(Pedido.Items(i).Name)), 50)
                    Categoria = ""
                End If

                If AceitaPedidoAutomaticoIfood = True Then
                    Enviado = True
                Else
                    Enviado = False
                End If

                InserirItemVendaApp(IDVendaD, NuloInteger(IDproduto), NuloString(Produto), Qtde, NuloBoolean(Enviado), NuloDecimal(vlrUnit), NuloDecimal(vlrUnit), NuloString(Categoria), Date.Now, 0, "APP", NuloInteger(CodGru), NuloString(NomeGrupo), NuloBoolean(0), "", NuloBoolean(0), "", "APP", NuloBoolean(ImprimeCategoria), SetorDelivery, False, 1, CodProExterno)
                IDmovto = NuloInteger(PegaID("IDAppVendaMovto", "tblAppVendasMovto", "L"))

                ' VERIFICA COMBO   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Dim QtdeCombo As Decimal
                Dim vlrUnitCombo As Decimal
                Dim Agrega As Boolean
                Dim CodProExternoCombo As String
                Item = 0
                If Not IsNothing(Pedido.Items(i).SubItems) Then
                    For ii = 0 To Pedido.Items(i).SubItems.Count - 1



                        System.Threading.Thread.Sleep(100)




                        If InStr(1, UCase(NuloString(Pedido.Items(i).SubItems.ElementAt(ii)("name"))), "MASSA") > 0 And Item = 0 Then

                            IncluiComentarioApp(IDVendaD, IDmovto, 0, VerificaTexto(Strings.Left(UCase(NuloString(Pedido.Items(i).SubItems.ElementAt(ii)("name"))), 50)), 0, "")

                        Else
                            CodProExternoCombo = NuloInteger(Pedido.Items(i).SubItems.ElementAt(ii)("id"))
                            CodProCombo = NuloInteger(Pedido.Items(i).SubItems.ElementAt(ii)("externalCode"))
                            QtdeCombo = NuloDecimal(Pedido.Items(i).SubItems.ElementAt(ii)("quantity"))
                            vlrUnitCombo = NuloDecimal(Pedido.Items(i).SubItems.ElementAt(ii)("TotalPrice"))

                            If CodProCombo <> 0 Then
                                'strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Pizza, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblCombos_Local.AgregaValor, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblGrupos_Local.Grupo "
                                'strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo LEFT OUTER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto And tblProdutos_Local.IDFamilia = tblCombos_Local.IDFamilia "

                                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Pizza, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblCombos_Local.AgregaValor, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblGrupos_Local.Grupo "
                                strSql += "From tblProdutos_Local LEFT OUTER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo LEFT OUTER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto And tblProdutos_Local.IDFamilia = tblCombos_Local.IDFamilia "
                                strSql += "Where (CodigoProduto =" & CodProCombo & ")"
                            Else
                                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.Pizza, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblCombos_Local.AgregaValor, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblGrupos_Local.Grupo, tblProdutosExterno_Local.CodigoProdutoExterno "
                                strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo INNER Join tblProdutosExterno_Local On tblProdutos_Local.IDProduto = tblProdutosExterno_Local.IDProduto LEFT OUTER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto And tblProdutos_Local.IDFamilia = tblCombos_Local.IDFamilia "
                                strSql += "Where (tblProdutosExterno_Local.CodigoProdutoExterno = '" & CodProExternoCombo & "')"
                            End If

                            Dim dapS = New SqlDataAdapter(strSql, strCon)
                            Dim dsS As New DataSet()

                            dapS.SelectCommand.CommandType = CommandType.Text
                            dapS.Fill(dsS, "Combo")

                            If CodProCombo <> 0 Then
                                IDproduto = NuloInteger(dsS.Tables("Combo").Rows(0).Item("IDProduto"))
                                Produto = NuloString(dsS.Tables("Combo").Rows(0).Item("Produto"))
                                CodGru = NuloInteger(dsS.Tables("Combo").Rows(0).Item("CodigoGrupo"))
                                NomeGrupo = NuloString(dsS.Tables("Combo").Rows(0).Item("Grupo"))
                                Categoria = NuloString(dsS.Tables("Combo").Rows(0).Item("Categoria"))
                                Agrega = NuloBoolean(dsS.Tables("Combo").Rows(0).Item("AgregaValor"))
                            Else
                                IDproduto = 0
                                Produto = UCase(NuloString(Pedido.Items(i).SubItems.ElementAt(ii)("name")))
                                CodGru = 0
                                NomeGrupo = ""
                                Categoria = ""
                                Agrega = False
                            End If
                            CodProExternoCombo = NuloString(Pedido.Items(i).SubItems.ElementAt(ii)("id"))

                            InserirItemComboVendaApp(IDmovto, IDVendaD, IDproduto, Produto, QtdeCombo, vlrUnitCombo, vlrUnitCombo, CodGru, NomeGrupo, Categoria, Agrega, 1, CodProExternoCombo)

                            dapS.Dispose()
                            dsS.Clear()
                            dsS.Dispose()

                        End If
                        Item += 1
                    Next
                End If

                If Obs <> "" Then
                    IncluiComentarioApp(IDVendaD, IDmovto, 0, VerificaTexto(UCase(Obs)), 0, "")
                End If
            Next


            ' INSERE PAGAMENTO  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (CodigoExterno='" & Pedido.Payments.ElementAt(0).Code & "')"
            Dim dapPg = New SqlDataAdapter(strSql, strCon)
            Dim dsPg As New DataSet()

            dapPg.SelectCommand.CommandType = CommandType.Text
            dapPg.Fill(dsPg, "Pagto")

            strSql = "DELETE FROM tblVendasPagto WHERE (IDVenda='" & NuloInteger(IDVendaD) & "')"
            ExecutaStr(strSql)

            If dsPg.Tables("Pagto").Rows.Count = 0 Then
                If IDFormaPagtoIfood <> 0 Then
                    strSql = "SELECT * FROM tblFormaPagtos_Local WHERE (IDFormaPagto=" & IDFormaPagtoIfood & ")"
                    InserirPagtoApp(IDVendaD, IDFormaPagtoIfood, NuloString(PegaValorCampo("Descricao", strSql, strCon)), totPagto, NuloBoolean(PegaValorCampo("ECartao", strSql, strCon)), NuloDecimal(PegaValorCampo("Taxa", strSql, strCon)), NuloString(PegaValorCampo("Tipo", strSql, strCon)), 1)
                Else
                    InserirPagtoApp(IDVendaD, 0, "", totPagto, False, 0, "", 1)
                End If
            End If
            For i As Integer = 0 To dsPg.Tables("Pagto").Rows.Count - 1
                InserirPagtoApp(IDVendaD, NuloInteger(dsPg.Tables("Pagto").Rows(i).Item("IDFormaPagto")), NuloString(dsPg.Tables("Pagto").Rows(i).Item("Descricao")), totPagto, NuloBoolean(dsPg.Tables("Pagto").Rows(i).Item("ECartao")), NuloDecimal(dsPg.Tables("Pagto").Rows(i).Item("Taxa")), NuloString(dsPg.Tables("Pagto").Rows(i).Item("Tipo")), 1)
            Next
        End If
    End Sub
    Private Sub InserirPagtoApp(IDVenda As String, IDFormaPagto As Integer, Descricao As String, Valor As Decimal, Ecartao As Boolean, TaxaCartao As Decimal, TipoPagto As String, Tipo As Integer)
        strSql = "INSERT tblAppVendasPagto "
        strSql += "(IDVendaExterna, IDFormaPagto, Descricao, ValorPago, ECartao, TaxaCartao, Tipo, Cupom) VALUES ("

        strSql += to_sql(IDVenda) & ","
        strSql += to_sql(IDFormaPagto) & ","
        strSql += to_sql(Strings.Left(Descricao, 50)) & ","
        strSql += to_sql(Replace(Valor.ToString, ",", ".")) & ","
        strSql += to_sql(Ecartao) & ","
        strSql += to_sql(Replace(TaxaCartao.ToString, ",", ".")) & ","
        strSql += to_sql(TipoPagto) & ", 0)"
        ExecutaStr(strSql)

    End Sub
    Private Sub InserirItemComboVendaApp(IDVendaMovto As Integer, IDVenda As String, IDProduto As Integer, Produto As String, Quanti As Decimal, Venda As Decimal, VendaServico As Decimal, idGrupo As Integer, Grup As String, Categoria As String, Agrega As Boolean, Tipo As Integer, CodProExterno As String)

        strSql = "INSERT tblAppVendasCombo "
        strSql += "(IDAppVendaMovto,IDVendaExterna,IDProduto,Produto,Qtd,Venda,VendaServico,IDGrupo,Grupo,Categoria,AgregaValor,CodigoProdutoExterno) VALUES ("

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


    End Sub
    Private Sub InserirItemVendaApp(IDVenda As String, IDProduto As Integer, Produto As String, Quanti As Decimal, Enviado As Boolean, Venda As Decimal, VendaServico As Decimal, Categoria As String, HoraPedido As DateTime, IDFuncionario As Integer, Atendente As String, IDGrupo As Integer, Grupo As String, Excluido As Boolean, Motiv As String, Impr As Boolean, StTransf As String, Termi As String, NImpr As Boolean, SetImpr As Integer, ComServico As Boolean, Tipo As Integer, CodProExterno As String)
        Dim Executado As Boolean = False
        strSql = "INSERT tblAppVendasMovto "
        strSql += "(IDVendaExterna,IDProduto,Produto,Qtd,Enviado,Venda,VendaServico,Categoria,HoraPedido,IDFuncionario,Atendente,IDGrupo,Grupo,Excluido,MotivoEstorno,Impresso,StatusTransf,Terminal,Imprime,SetorImpressao,MesaCartao,ComServico,EmEspera,CodigoProdutoExterno) VALUES ("

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


    End Sub
    Private Sub AbreVendaApp(PDesconto As Decimal, PServico As Decimal, IDCli As Integer, IDRuaEnt As Integer, CepEnt As String, NumeroEnt As String, ComplementoEnt As String, ReferenciaEnt As String, ComentProd As String, ComentExp As String, NomeCli As String, Troco As Decimal, PedidoProg As Boolean, txEntrega As Decimal, vlrDesc As Decimal, vlrProd As Decimal, vlrTotal As Decimal, vlrCaixinha As Decimal, cpf_cnpj As String, IDvdaExterna As String, AppOrigem As String, Tipo As String, AreaEntrega As String, Json_Ped As String, IDref As String, IDcliExt As String, LogradouroEnt As String)
        strSql = "INSERT tblAppVendas "
        strSql &= "(NumVenda, NumVendaD, NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Enviado, Excluido, IDFuncionarioAtendente, "
        strSql &= "IDCliente, NomeCliente, IDRuaEntrega, CepEntrega, NumeroEntrega, AreaEntrega, ComplementoEntrega, ReferenciaEntrega, ComentProducao, ComentExpedicao, Troco, TaxaEntrega, Desconto, TotalProdutos, TotalVenda, Caixinha, PreNota, "
        strSql &= "PedidoProg, PedidoProgAutomatico, PedidoProgEnvioAs, PedidoProgEnviado, TipoLancto, CpfCnpj, IDVendaExterna, App, AppConfirmado, Json, IDReferencia, IDClienteExterno, LogradouroEntrega) VALUES ("
        strSql &= "0,0,0,"
        strSql &= "'" & Date.Now & "',"
        strSql &= to_sql(Replace(NuloString(Format(NuloDecimal(PDesconto), "#0.000")), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(PServico)), ",", ".")) & ","
        strSql &= "1, "
        strSql &= to_sql(0) & ","
        strSql += "'" & Date.Now & "',"
        strSql &= "'D',"
        strSql &= to_sql("") & ","
        strSql &= to_sql("") & ","
        strSql &= "0,"
        strSql &= "0,"
        strSql &= "0,"
        strSql &= to_sql(IDCli) & ","
        strSql &= to_sql(NomeCli) & ","
        strSql &= to_sql(IDRuaEnt) & ","
        strSql &= to_sql(CepEnt) & ","
        strSql &= to_sql(NumeroEnt) & ","
        strSql &= to_sql(AreaEntrega) & ","
        strSql &= to_sql(ComplementoEnt) & ","
        strSql &= to_sql(ReferenciaEnt) & ","
        strSql &= to_sql(ComentProd) & ","
        strSql &= to_sql(ComentExp) & ", "
        strSql &= to_sql(Replace(NuloString(NuloDecimal(Troco)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(txEntrega)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(vlrDesc)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(vlrProd)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(vlrTotal)), ",", ".")) & ","
        strSql &= to_sql(Replace(NuloString(NuloDecimal(vlrCaixinha)), ",", ".")) & ","
        strSql &= "1, "
        If PedidoProg = False Then
            strSql &= "0, 0, NULL, 0, "
        Else
            strSql &= "1, 0, NULL, 0, "
        End If
        If cpf_cnpj <> "" Then
            strSql &= "1, "
            strSql &= to_sql(NuloString(cpf_cnpj)) & ", "
        Else
            strSql &= "0,'', "
        End If
        strSql &= to_sql(NuloString(IDvdaExterna)) & ", "
        strSql &= to_sql(NuloString(AppOrigem)) & ", "
        strSql &= "0, "
        strSql &= to_sql(NuloString(Json_Ped)) & ", "
        strSql &= to_sql(NuloString(IDref)) & ", "
        strSql &= to_sql(NuloString(IDcliExt)) & ", "
        strSql &= to_sql(NuloString(LogradouroEnt)) & ")"

        'PercServico = PServico
        ExecutaStr(strSql)
        IDVendaD = Tipo

    End Sub
End Module
