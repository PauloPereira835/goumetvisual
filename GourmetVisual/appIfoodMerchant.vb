Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json
Module appIfoodMerchant
    'Public UsernameIfood As String
    'Public PasswordIfood As String
    Public SenhaGVIfood As String = "zd5umskh6bewmz3jcwe8z0ohkt2vb35mpmz7jyga8kvb7e898bot6e6hgxi8mfjx3so7d9s1jfh31orls8jwc70gm4k8ejv896q"
    Public client_idIfood As String = "aaa9bad5-8194-4029-a05a-ee24d3fdbdd6"

    Public usercode_accessIfood As String
    Public authorizationCode As String
    Public authorizationCodeVerifier As String
    Public verificationUrlComplete As String
    Public refreshToken As String

    Public tokenAccessIfood As String
    'Public token_typeIfood As String
    'Public token_expires_inIfood As Integer
    'Public token_DataHoraFim_Ifood As Date
    'Public token_scopeIfood As String
    'Public IDmerchantIfood As String
    'Public V_EndpointIfood As String = "v1.0"
    'Public AceitaPedidoAutomaticoIfood As Boolean
    Public UriIfood As String = "https://merchant-api.ifood.com.br"

    Partial Public Class EventsPoolingIfood
        <JsonProperty("code")>
        Public Property Code As String
        <JsonProperty("fullCode")>
        Public Property fullCode As String
        <JsonProperty("orderId")>
        Public Property OrderId As String
        <JsonProperty("createdAt")>
        Public Property CreatedAt As DateTimeOffset
        <JsonProperty("id")>
        Public Property Id As String
    End Class
    Public ReadOnly Settings As JsonSerializerSettings = New JsonSerializerSettings With {
        .MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        .DateParseHandling = DateParseHandling.None
    }
    Partial Public Class EventsPoolingIfood
        Public Shared Function FromJson(ByVal json As String) As List(Of EventsPoolingIfood)
            Return JsonConvert.DeserializeObject(Of List(Of EventsPoolingIfood))(json, Settings)
        End Function
    End Class
    Public Class EventsPollingResponseIfood
        Public lista As List(Of EventsPoolingIfood)
    End Class
    Public Class Abertura_iFood
        Public Property status As String
        Public Property Reason As String
    End Class
    Public Class Credencial_iFoodMerchant
        Public Property accessToken As String
        Public Property expiresIn As Integer
        Public Property type As String
        Public Property refreshToken As String
    End Class
    Public Class UserCode_iFood
        Public Property userCode As String
        Public Property expiresIn As Integer
        Public Property authorizationCodeVerifier As String
        Public Property verificationUrl As String
        Public Property verificationUrlComplete As String
    End Class

    Partial Public Class AckNowledgmentIfood
        <JsonProperty("id")>
        <JsonConverter(GetType(ParseStringConverter))>
        Public Property Id As String
    End Class
    Friend Class ParseStringConverter
        Inherits JsonConverter
        Public Overrides Function CanConvert(ByVal t As Type) As Boolean
            Return t Is GetType(Long) OrElse t Is GetType(Long?)
        End Function

        Public Overrides Function ReadJson(ByVal reader As JsonReader, ByVal t As Type, ByVal existingValue As Object, ByVal serializer As JsonSerializer) As Object
            If reader.TokenType = JsonToken.Null Then Return Nothing
            Dim value = serializer.Deserialize(Of String)(reader)
            Dim l As Long

            If Long.TryParse(value, l) Then
                Return l
            End If

            Throw New Exception("Cannot unmarshal type long")
        End Function

        Public Overrides Sub WriteJson(ByVal writer As JsonWriter, ByVal untypedValue As Object, ByVal serializer As JsonSerializer)
            If untypedValue Is Nothing Then
                serializer.Serialize(writer, Nothing)
                Return
            End If

            Dim value = untypedValue.ToString
            serializer.Serialize(writer, value.ToString())
            Return
        End Sub

        Public Shared ReadOnly Singleton As ParseStringConverter = New ParseStringConverter()
    End Class

    Partial Public Class AckNowledgmentIfood
        Public Shared Function FromJson(ByVal json As String) As AckNowledgmentIfood()
            Return JsonConvert.DeserializeObject(Of AckNowledgmentIfood())(json, Settings)
        End Function
    End Class
    Partial Public Class Statuses

    End Class
    Public Sub MudarStatusIfood(ByVal referece As String, ByVal status As String)
        Dim Statuses = IfoodMerchantUtil.Enviar(Of Statuses, Statuses)(appIfoodMerchant.UriIfood, "statuses", "IFOOD", Nothing, referece, status)
    End Sub
    Public Async Sub VerificaPedidos_Ifood()
        Dim EventsPooling = IfoodMerchantUtil.Enviar(Of List(Of appIfoodMerchant.EventsPoolingIfood), List(Of appIfoodMerchant.EventsPoolingIfood))(appIfoodMerchant.UriIfood, "eventspolling", "IFOOD", Nothing)
        Dim listaAck_Ifood As New List(Of AckNowledgmentIfood)
        If listaAck_Ifood.Count > 0 Then
            Dim Pedidos = EventsPooling.Item1
            For i = 0 To Pedidos.Count - 1
                If Pedidos(i).Code = "PLC" Then
                    Try
                        Dim idPedido = Pedidos(i).OrderId
                        Dim Order = IfoodMerchantUtil.Enviar(Of IfoodMerchantOrderResponse.Order, IfoodMerchantOrderResponse.Order)(appIfoodMerchant.UriIfood, "orders", "IFOOD", Nothing, idPedido.ToString())
                        Dim Pedido = Order.Item1

                        Dim ack As New AckNowledgmentIfood()
                        ack.Id = Pedidos(i).Id
                        listaAck_Ifood.Add(ack)

                        'MudarStatus(Pedidos(i).CorrelationId, "integration", "IFOOD")
                        Dim referece = Pedidos(i).OrderId
                        Dim status = "confirm"
                        Dim Statuses = IfoodMerchantUtil.Enviar(Of Statuses, Statuses)(appIfoodMerchant.UriIfood, "statuses", "IFOOD", Nothing, referece, status)
                        'continua = True

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Dim ack As New AckNowledgmentIfood()
                    ack.Id = Pedidos(i).Id
                    listaAck_Ifood.Add(ack)
                End If
            Next
        End If

        'If Pedidos.Count > 0 Then
        '    Dim x = FinalizaPedidoPoling_Ifood(listaAck_Ifood
        Dim lista = listaAck_Ifood
        Dim Acknowledgement = IfoodMerchantUtil.Enviar(Of List(Of AckNowledgmentIfood), List(Of AckNowledgmentIfood))(appIfoodMerchant.UriIfood, "acknowledgment", "IFOOD", lista)

        'End If

    End Sub
    Function FinalizaPedidoPoling_Ifood(lista As List(Of AckNowledgmentIfood)) As Task
        Dim Acknowledgement = IfoodMerchantUtil.Enviar(Of List(Of AckNowledgmentIfood), List(Of AckNowledgmentIfood))(appIfoodMerchant.UriIfood, "acknowledgment", "IFOOD", lista)
    End Function
    Function PegaToken_iFood()
        Dim _baseAddress As String = "https://merchant-api.ifood.com.br"
        Try

            Dim t = Task.Run(Function() GetURI_TokenIfood(_baseAddress, "authorization_code"))
            t.Wait()
            Dim tok As Credencial_iFoodMerchant = t.Result

            token_accessIfood = NuloString(tok.accessToken)
            refreshToken = NuloString(tok.refreshToken)
            'token_typeIfood = NuloString(tok.token_type)
            'token_scopeIfood = NuloString(tok.scope)
            'token_expires_inIfood = NuloInteger(tok.expires_in)
            'token_DataHoraFim_Ifood = DateAdd(DateInterval.Second, token_expires_inIfood, Now)

            'strSql = "UPDATE tblLojasApp SET "
            'strSql += "Token='" & token_accessIfood & "', "
            'strSql += "DataHoraExpira='" & token_DataHoraFim_Ifood & "' "
            'strSql += "WHERE Descricao='" & AppDescricao & "'"
            'ExecutaStr(strSql)

        Catch ex As Exception

            'frmPrincipal.lbErro.Text = "Token iFood inválido"
        End Try


    End Function
    Function PegaUserCode_iFood()
        Dim _baseAddress_ As String = "https://merchant-api.ifood.com.br"
        'Try

        Dim t = Task.Run(Function() GetURI_userCodeIfood(_baseAddress_))
        t.Wait()
        Dim tok As UserCode_iFood = t.Result
        usercode_accessIfood = tok.userCode
        verificationUrlComplete = tok.verificationUrlComplete
        authorizationCodeVerifier = tok.authorizationCodeVerifier
        'token_accessIfood = NuloString(tok.access_token)
        'token_typeIfood = NuloString(tok.token_type)
        'token_scopeIfood = NuloString(tok.scope)
        'token_expires_inIfood = NuloInteger(tok.expires_in)
        'token_DataHoraFim_Ifood = DateAdd(DateInterval.Second, token_expires_inIfood, Now)

        'strSql = "UPDATE tblLojasApp SET "
        'strSql += "Token='" & token_accessIfood & "', "
        'strSql += "DataHoraExpira='" & token_DataHoraFim_Ifood & "' "
        'strSql += "WHERE Descricao='" & AppDescricao & "'"
        'ExecutaStr(strSql)

        'Catch ex As Exception

        'frmPrincipal.lbErro.Text = "Token iFood inválido"
        'End Try


    End Function
    'Function NuloString(ByVal objeto As Object) As String
    'If Not IsDBNull(objeto) AndAlso Not objeto Is Nothing Then
    'Return CType(objeto.ToString, String)
    'Else
    'Return String.Empty
    'End If
    'End Function

    Public Async Function GetURI_TokenIfood(ByVal _baseAddress As String, ByVal grantType As String) As Task(Of Credencial_iFoodMerchant)
        Dim nota As String = Nothing

        Using client = New HttpClient()
            Dim url = _baseAddress + "/authentication/v1.0/oauth/token"
            Dim dict = New Dictionary(Of String, String)()
            dict.Add("clientId", client_idIfood)
            dict.Add("clientSecret", SenhaGVIfood)
            dict.Add("authorizationCode", authorizationCode)
            dict.Add("authorizationCodeVerifier", authorizationCodeVerifier)
            dict.Add("grantType", grantType)
            Dim req = New HttpRequestMessage(HttpMethod.Post, url) With {.Content = New FormUrlEncodedContent(dict)}

            Dim result As HttpResponseMessage = Await client.SendAsync(req)

            If result.IsSuccessStatusCode Then
                nota = Await result.Content.ReadAsStringAsync()
            End If
        End Using

        Dim jsonSettings = New JsonSerializerSettings With {
            .NullValueHandling = NullValueHandling.Ignore,
            .MissingMemberHandling = MissingMemberHandling.Ignore
        }
        Dim cred As Credencial_iFoodMerchant = JsonConvert.DeserializeObject(Of Credencial_iFoodMerchant)(nota, jsonSettings)
        Return cred

    End Function
    Public Async Function GetURI_userCodeIfood(ByVal _baseAddress As String) As Task(Of UserCode_iFood)
        Dim nota As String = Nothing
        Dim dict = New Dictionary(Of String, String)()
        dict.Add("clientId", client_idIfood)

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Using client = New HttpClient()
            Dim url = _baseAddress + "/authentication/v1.0/oauth/userCode"
            Dim req = New HttpRequestMessage(HttpMethod.Post, url) With {.Content = New FormUrlEncodedContent(dict)}
            Dim result As HttpResponseMessage = Await client.SendAsync(req)

            If result.IsSuccessStatusCode Then
                nota = Await result.Content.ReadAsStringAsync()
            End If
        End Using

        Dim jsonSettings = New JsonSerializerSettings With {
            .NullValueHandling = NullValueHandling.Ignore,
            .MissingMemberHandling = MissingMemberHandling.Ignore
        }
        Dim cred As UserCode_iFood = JsonConvert.DeserializeObject(Of UserCode_iFood)(nota, jsonSettings)
        Return cred

    End Function
End Module
