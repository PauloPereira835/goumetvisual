Imports Newtonsoft.Json
Imports RestSharp
Public Class RetOrders
    Public json As String
    Public lista As List(Of ModelsRappi.RappiPedidos)

End Class
Public Class ApisRappi
    Private token As ModelsRappi.RappiToken
    Private client_id As String
    Private client_secret As String
    Private audience As String

    'Const URL_MICROSERVICES As String = "microservices.dev.rappi.com"
    Const URL_MICROSERVICES As String = "services.rappi.com.br"

    'Const URL_TOKEN As String = "https://rests-integrations-dev.auth0.com/oauth/token"
    Const URL_TOKEN As String = "https://rests-integrations.auth0.com/oauth/token"


    Public Sub New(client_id As String, client_secret As String, audience As String)
        Me.client_id = client_id
        Me.client_secret = client_secret
        Me.audience = audience
    End Sub

    Public Function getToken()
        Dim client As New RestSharp.RestClient(URL_TOKEN)
        client.Timeout = -1
        Dim request As New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        Dim json = "{
                      ""audience"": """ & Audience_Rappi & """,
                      ""client_id"": """ & Client_ID_Rappi & """,
                      ""client_secret"": """ & Client_Secret_Rappi & """,
                      ""grant_type"": """ & Grant_Type_Rappi & """
                  }"
        request.AddParameter("application/json", json, ParameterType.RequestBody)
        Dim response As IRestResponse = client.Execute(request)
        Try
            token = JsonConvert.DeserializeObject(Of ModelsRappi.RappiToken)(response.Content)
            token_accessRappi = NuloString(token.access_token)
            token_DataHoraFim_Rappi = DateAdd(DateInterval.Second, token.expires_in, Now)

        Catch ex As Exception
            Dim a = ex.Message
        End Try
    End Function

    Function getNewOrders(ByVal idLoja As String) As RetOrders
        Dim ret As New RetOrders()
        ret.lista = New List(Of ModelsRappi.RappiPedidos)()
        ret.json = ""
        Dim lista As New List(Of ModelsRappi.RappiPedidos)
        Dim client As New RestSharp.RestClient("https://" + URL_MICROSERVICES + "/api/v2/restaurants-integrations-public-api/orders?storeId=" + idLoja)
        'Dim client As New RestSharp.RestClient(Audience_Rappi & "/orders?storeId=" + idLoja)

        client.Timeout = -1
        Dim request As New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("x-authorization", "Bearer " & Me.token.access_token)
        'request.AddHeader("x-authorization", "Bearer " & token_accessRappi)
        Dim response As IRestResponse = client.Execute(request)
        ret.json = response.Content
        If (response.StatusCode = Net.HttpStatusCode.OK) Then
            lista = JsonConvert.DeserializeObject(Of List(Of ModelsRappi.RappiPedidos))(response.Content)
            ret.lista = lista
        Else
            Dim a = response.Content
        End If
        Return ret
    End Function

    Public Function TakeAnOrder(ByVal idPedido As String, ByVal tempoDeCozimento As String) As Boolean
        Dim ret As Boolean = False
        Dim client As New RestSharp.RestClient("https://" + URL_MICROSERVICES + "/api/v2/restaurants-integrations-public-api/orders/" + idPedido + "/take/" + tempoDeCozimento)
        client.Timeout = -1
        Dim request As New RestRequest(Method.PUT)
        request.AddHeader("x-authorization", "Bearer " & Me.token.access_token)
        Dim response As IRestResponse = client.Execute(request)
        If (response.ResponseStatus = Net.HttpStatusCode.OK) Then
            ret = True
        End If
        Return ret
    End Function

    Public Function RejectAnOrder(ByVal idPedido As String, ByVal motivo As String) As Boolean
        Dim ret As Boolean = False
        Dim client As New RestSharp.RestClient("https://" + URL_MICROSERVICES + "/api/v2/restaurants-integrations-public-api/orders/" + idPedido + "/reject")
        client.Timeout = -1
        Dim request As New RestRequest(Method.PUT)
        'request.AddHeader("x-authorization", "Bearer " & Me.token.access_token)
        request.AddHeader("x-authorization", "Bearer " & token_accessRappi)
        request.AddHeader("Content-Type", "application/json")

        Dim json As String = "{
            ""reason"": """ + motivo + """
         }"
        request.AddParameter("application/json", json, ParameterType.RequestBody)

        Dim response As IRestResponse = client.Execute(request)
        If (response.ResponseStatus = Net.HttpStatusCode.OK) Then
            ret = True
        End If
        Return ret
    End Function
    Public Function OrderReadyForPickup(ByVal idPedido As String) As Boolean
        Dim ret As Boolean = False
        Dim client As New RestSharp.RestClient("https://" + URL_MICROSERVICES + "/api/v2/restaurants-integrations-public-api/orders/" + idPedido + "/ready-for-pickup")
        client.Timeout = -1
        getToken()
        Dim request As New RestRequest(Method.POST)
        request.AddHeader("x-authorization", "Bearer " & token_accessRappi)
        Dim response As IRestResponse = client.Execute(request)
        If (response.ResponseStatus = Net.HttpStatusCode.OK) Then
            ret = True
        End If
        Return ret
    End Function
End Class
