Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Module appQRbox
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
    Public UriQRbox As String = "http://adm-qrbox-rc.azurewebsites.net/bridge/"
    Public Class Abertura_QRbox
        Public Property status As String
        Public Property Reason As String
    End Class
    Public Class Credencial_QRbox
        Public Property access_token As String
        Public Property expires_in As Integer
        Public Property token_type As String
        Public Property scope As String
    End Class







    Public Async Function AtivarLojaQRbox() As Task
        RetFuncaoQRbox = False
        Dim Uri
        Uri = UriQRbox & "https://pos-api.ifood.com.br/" & V_EndpointIfood & "/merchants/" & frmConfiguracao.tbIDMerchantIfood.Text


        Using client = New HttpClient

            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzUxMiJ9.eyJzdWIiOiI5ZjVjY2Y4ZS00MGY3LTRiYjMtYjk2Yy1lYTRhZWU3ZjI1OTciLCJ1c2VyX25hbWUiOiJQT1MtOTY1MzM4MiIsInByb2ZpbGVzIjoiW3tcImlkXCI6XCIyMVwiLFwibmFtZVwiOlwiUE9TXCJ9XSIsImlzcyI6ImlGb29kIiwiY2xpZW50X2lkIjoiZ291cm1ldHZpc3VhbCIsImF1dGhvcml0aWVzIjpbIlJPTEVfQ0xJRU5UIiwiUk9MRV9UUlVTVEVEX0NMSUVOVCJdLCJtdXN0X2NoYW5nZV9wYXNzd29yZCI6ZmFsc2UsImF1ZCI6WyJraXRjaGVuIiwib2F1dGgtc2VydmVyIl0sInVzZXJfbWV0YWRhdGEiOjIyNTQ4NjgsImJhY2tvZmZpY2VzIjoiW3tcImlkXCI6XCIxXCIsXCJuYW1lXCI6XCJPUEJSXCIsXCJkb21haW5cIjpcImlmb29kLmNvbS5iclwiLFwiY29tcGFueUNvZGVzXCI6W1wiQUxLXCIsXCJEVlJcIixcIkZJRlwiLFwiSExGXCIsXCJBUFRcIixcIklGRFwiLFwiSFVUXCIsXCJMRUFcIixcIkxDQlwiLFwiSUxQXCIsXCJNQ0RcIixcIkVTQVwiLFwiQURWXCIsXCJJRk9cIixcIlBQUlwiLFwiQk9CXCIsXCJOQ0tcIixcIkhCUlwiLFwiU0hQXCIsXCJJUEJcIixcIlJXQlwiXX1dIiwicGVybWlzc2lvbnMiOltdLCJzY29wZSI6WyJ0cnVzdCIsIndyaXRlIiwicmVhZCJdLCJ0ZW5hbnRJZCI6IjU4ZDkyMjEwLTQ3NjItMTFlNi1iZWI4LTllNzExMjhjYWU3NyIsIm1lcmNoYW50cyI6Ilt7XCJtZXJjaGFudFV1aWRcIjpcImI5NDFiMzdkLTgxMmItNGFmMC05MDNmLWZhMWY1ZGQwZGQyMVwiLFwibWVyY2hhbnRJZFwiOjExNjMyNzd9XSIsImV4cCI6MTU5NDA1MTc3OCwiaWF0IjoxNTk0MDQ4MTc4fQ.DvhoDiPBNXGLMj-drrUFqOUIcuxFzt8RJSMiO_uTkqY7FQVChkorxDTGQYhNMV_tWHdBSt4bBylYgI6IRDtI6YoiBQVtpymLUSIn6JzOJHRKjoW8KK27YpX6pbSNg1nGRSB4ObGxHjPot519WjAljCwqPf-7NzpxQNpvl8hCFto")

            Using response = Await client.GetAsync(Uri)
                If response.IsSuccessStatusCode Then
                    Dim Retorno = Await response.Content.ReadAsStringAsync()
                    Dim RetornoDaFuncao = JsonConvert.DeserializeObject(Of Abertura_QRbox())(Retorno).ToList()
                    For i = 0 To RetornoDaFuncao.Count - 1
                        RetFuncaoQRbox = True
                    Next
                Else
                    RetFuncaoQRbox = False
                End If

                If RetFuncaoQRbox = False Then
                    Dim motivo As String = ""
                    If response.ReasonPhrase = "Unauthorized" Then
                        motivo = "não autorizado"
                    End If

                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Integração NÃO ativada " & vbCrLf & "Motivo: " & motivo
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    frmConfiguracao.btnQRboxAtivo.Text = "Integração não ativa"
                    frmConfiguracao.btnQRboxAtivo.BackColor = Color.Red
                    frmConfiguracao.tbIDMerchantQRbox.Text = 0
                Else
                    frmConfiguracao.btnQRboxAtivo.Text = "Integração ativa"
                    frmConfiguracao.btnQRboxAtivo.BackColor = Color.Green
                    frmConfiguracao.tbIntegracaoQRboxAtiva.Text = 1
                End If

            End Using
        End Using



    End Function

    Function PegaToken_QRbox() As Task

        Dim url As String = UriQRbox & "/oauth/token"
        Dim request As WebRequest = WebRequest.Create(url)

        request.Method = "POST"
        Dim postData As String = "?client_id=" & UsernameQRbox & "&client_secret=" & SenhaGVQRbox & "&username=" & client_idQRbox & "&password=" & PasswordQRbox & "&grant_type=password"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As WebResponse = request.GetResponse()
        Debug.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Debug.WriteLine(responseFromServer)

        Dim nota As String = Nothing
        nota = responseFromServer

        reader.Close()
        dataStream.Close()
        response.Close()


        Dim jsonSettings = New JsonSerializerSettings With {
            .NullValueHandling = NullValueHandling.Ignore,
            .MissingMemberHandling = MissingMemberHandling.Ignore
        }
        Dim cred As Credencial_QRbox = JsonConvert.DeserializeObject(Of Credencial_QRbox)(nota, jsonSettings)


        token_accessQRbox = NuloString(cred.access_token)
        token_typeQRbox = NuloString(cred.token_type)
        token_expires_inQRbox = NuloInteger(cred.expires_in)
        token_DataHoraFim_QRbox = DateAdd(DateInterval.Second, token_expires_inQRbox, Now)
        token_scopeQRbox = NuloString(cred.scope)


        'Return cred


        'Dim _baseAddress As Uri = New Uri("http://adm-qrbox-rc.azurewebsites.net/oauth/token")
        'Dim t = Task.Run(Function() GetURI_TokenIfood(_baseAddress))
        't.Wait()
        'Dim tok As Credencial_iFood = t.Result
        'Return (tok)
    End Function

    Public Async Function GetURI_TokenIfood(ByVal _baseAddress As Uri) As Task(Of Credencial_QRbox)
        Dim nota As String = Nothing

        Using client = New HttpClient()
            client.BaseAddress = _baseAddress
            Dim url = UriQRbox & "oauth/token?client_id=" & UsernameQRbox & "&client_secret=" & SenhaGVQRbox & "&username=" & client_idQRbox & "&password=" & PasswordQRbox & "&grant_type=password"


            Dim result As HttpResponseMessage = Await client.PostAsync(url, Nothing)

            If result.IsSuccessStatusCode Then
                nota = Await result.Content.ReadAsStringAsync()
            End If
        End Using

        Dim jsonSettings = New JsonSerializerSettings With {
            .NullValueHandling = NullValueHandling.Ignore,
            .MissingMemberHandling = MissingMemberHandling.Ignore
        }
        Dim cred As Credencial_QRbox = JsonConvert.DeserializeObject(Of Credencial_QRbox)(nota, jsonSettings)
        Return cred

    End Function
End Module
