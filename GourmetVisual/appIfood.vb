Imports System.Net.Http
Imports Newtonsoft.Json
Module appIfood
    Public UsernameQRbox As String
    Public PasswordQRbox As String
    'Public SenhaGVQRbox As String = "nkVxhXSU"
    Public SenhaGVQRbox As String = "senhaPdv7"
    'Public client_idQRbox As String = "gourmetvisual"
    Public client_idQRbox As String = "pizza@pizza.com.br"
    Public token_accessQRbox As String
    Public token_typeQRbox As String
    Public token_expires_inQRbox As Integer
    Public token_DataHoraFim_QRbox As Date
    Public token_scopeQRbox As String
    Public IDmerchantQRbox As String
    Public V_EndpointQRbox As String = "v1.0"
    Public GerenciaPedidosQRbox As Boolean
    Public RetFuncaoQRbox As Boolean
    Public AceitaPedidoAutomaticoQRbox As Boolean
    'Public UriQRbox As String = "http://adm-qrbox-rc.azurewebsites.net/bridge/"
    Public UriQRbox As String = "http://adm-qrbox.azurewebsites.net/bridge/"
    Public IntegracaoQRbox As Boolean


    Public UsernameRappi As String
    Public PasswordRappi As String
    Public IDmerchantRappi As String

    Public IntegracaoIfood As Boolean
    Public GerenciaPedidosIfood As Boolean
    Public IntegracaoRappi As Boolean
    Public GerenciaPedidosRappi As Boolean
    Public UsernameIfood As String
    Public PasswordIfood As String
    Public SenhaGVIfood As String = "nkVxhXSU"
    Public client_idIfood As String = "gourmetvisual"
    Public token_accessIfood As String
    Public token_typeIfood As String
    Public token_expires_inIfood As Integer
    Public token_DataHoraFim_Ifood As Date
    Public token_scopeIfood As String
    Public IDmerchantIfood As String
    Public V_EndpointIfood As String = "v1.0"
    Public AceitaPedidoAutomaticoIfood As Boolean
    Public Uri_Ifood As String = "https://pos-api.ifood.com.br/"
    Public Class Abertura_iFood
        Public Property status As String
        Public Property Reason As String
    End Class
    Public Class Credencial_iFood
        Public Property access_token As String
        Public Property expires_in As Integer
        Public Property token_type As String
        Public Property scope As String
    End Class
    Public Class Credencial_QRbox
        Public Property access_token As String
        Public Property expires_in As Integer
        Public Property token_type As String
        Public Property scope As String
    End Class
    Public Sub MudarStatus(ByVal referece As String, ByVal status As String, app As String)
        Dim Statuses

        Statuses = IfoodUtil.Enviar(Of Statuses, Statuses)(appIfood.Uri_Ifood, "statuses", "IFOOD", Nothing, referece, status)


    End Sub

    Function PegaTokenIfood()
        Dim _baseAddress As Uri = New Uri("https://pos-api.ifood.com.br/")
        Dim t = Task.Run(Function() GetURI_TokenIfood(_baseAddress))
        t.Wait()
        Dim tok As Credencial_iFood = t.Result

        token_accessIfood = NuloString(tok.access_token)
        token_typeIfood = NuloString(tok.token_type)
        token_scopeIfood = NuloString(tok.scope)
        token_expires_inIfood = NuloInteger(tok.expires_in)
        token_DataHoraFim_Ifood = DateAdd(DateInterval.Second, token_expires_inIfood, Now)

        Return (tok)
    End Function
    Public ReadOnly Settings As JsonSerializerSettings = New JsonSerializerSettings With {
        .MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        .DateParseHandling = DateParseHandling.None
    }
    Public Async Function GetURI_TokenIfood(ByVal _baseAddress As Uri) As Task(Of Credencial_iFood)
        Dim nota As String = Nothing

        Using client = New HttpClient()
            client.BaseAddress = _baseAddress
            Dim url = "oauth/token?client_id=" & client_idIfood & "&client_secret=" & SenhaGVIfood & "&username=" & UsernameIfood & "&password=" & PasswordIfood & "&grant_type=password"


            Dim result As HttpResponseMessage = Await client.PostAsync(url, Nothing)

            If result.IsSuccessStatusCode Then
                nota = Await result.Content.ReadAsStringAsync()
            End If
        End Using

        Dim jsonSettings = New JsonSerializerSettings With {
            .NullValueHandling = NullValueHandling.Ignore,
            .MissingMemberHandling = MissingMemberHandling.Ignore
        }
        Dim cred As Credencial_iFood = JsonConvert.DeserializeObject(Of Credencial_iFood)(nota, jsonSettings)
        Return cred

    End Function
End Module
