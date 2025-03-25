Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime.Remoting.Messaging
Imports System.Text
Imports System.Web
Imports System.Web.Caching
Imports System.Web.Configuration
Imports Newtonsoft.Json

Module PosControle

    'PORTAL WEB
    'URL: https://sualogomarca.pdv.mobi
    'Login: paulo@iristecnologia.com.br
    'Senha: vNJfE8t3

    Function MainPosControle()
        MakeRequest()
        ' Console.WriteLine("Hit ENTER to exit...")
        ' Console.ReadLine()
    End Function

    Private Async Sub MakeRequest()
        Dim client = New HttpClient()
        Dim queryString = HttpUtility.ParseQueryString("username=" & UserName_PosControle & "&password=" & Senha_PosControle)

        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}")
        'client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "58d8f05b45164a008ef6159b879d89ed")
        '58d8f05b45164a008ef6159b879d89ed
        'client.DefaultRequestHeaders.Add("username", "46363633035235.sualogomarca.pdv.mobi")
        'client.DefaultRequestHeaders.Add("password", "H27JOLF4KE9UCMIR")
        client.DefaultRequestHeaders.Add("jwt", "58d8f05b45164a008ef6159b879d89ed")

        'Dim uri = "https://api.poscontrole.com.br/v2/auth/token?" & NuloString(queryString)
        Dim uri = "https://sualogomarca.pdv.mobi?" & NuloString(queryString)

        Dim response As HttpResponseMessage
        Dim byteData As Byte() = Encoding.UTF8.GetBytes("{body}")

        Using content = New ByteArrayContent(byteData)

            response = Await client.PostAsync(uri, content)

            'Token_PosControle = response.Headers("jwt")
            'Token_PosControle = client.PostAsync(uri, content).Result.Headers("jwt").ToString

            DataTokenPosControle = NuloString(response.Headers.Date.Value.AddHours(0.55))
        End Using
    End Sub


    Function PegaTokenPosControle()
        Dim _baseAddress As Uri = New Uri("https://sualogomarca.pdv.mobi?")
        Dim t = Task.Run(Function() GetURI_TokenPosControle(_baseAddress))
        t.Wait()
        Dim tok As Credencial_PosControle = t.Result

        token_accessIfood = NuloString(tok.access_token)
        token_typeIfood = NuloString(tok.token_type)
        token_scopeIfood = NuloString(tok.scope)
        token_expires_inIfood = NuloInteger(tok.expires_in)
        token_DataHoraFim_Ifood = DateAdd(DateInterval.Second, token_expires_inIfood, Now)

        Return (tok)
    End Function

    Public Async Function GetURI_TokenPosControle(ByVal _baseAddress As Uri) As Task(Of Credencial_PosControle)
        Dim nota As String = Nothing

        Using client = New HttpClient()
            client.BaseAddress = _baseAddress
            Dim url = "username=" & UserName_PosControle & "&password=" & Senha_PosControle

            Dim result As HttpResponseMessage = Await client.PostAsync(url, Nothing)

            If result.IsSuccessStatusCode Then
                nota = Await result.Content.ReadAsStringAsync()
            End If
        End Using

        Dim jsonSettings = New JsonSerializerSettings With {
            .NullValueHandling = NullValueHandling.Ignore,
            .MissingMemberHandling = MissingMemberHandling.Ignore
        }
        Dim cred As Credencial_PosControle = JsonConvert.DeserializeObject(Of Credencial_PosControle)(nota, jsonSettings)
        Return cred

    End Function

    Public Class Credencial_PosControle
        Public Property access_token As String
        Public Property expires_in As Integer
        Public Property token_type As String
        Public Property scope As String
    End Class
End Module





