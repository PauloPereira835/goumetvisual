Imports Newtonsoft.Json
Imports GourmetVisual.classModelsShipay
Imports RestSharp
Public Class classShipay
    Const URL_TOKEN_Shipay As String = "https://api-staging.shipay.com.br/"
    'Const URL_TOKEN_Shipay As String = "https://painel-staging.shipay.com.br/"
    Private token As classModelsShipay.ShipayToken
    Public Sub New()

        'AccessKey_Shipay = frmPrincipal.tbAccessKey_Shipay.Text
        'ClientID_Shipay = frmPrincipal.tbClientID_Shipay.Text
        'SecretKey_Shipay = frmPrincipal.tbSecretKey_Shipay.Text

    End Sub

    Public Class RetCarteiras
        Public json As String
        Public lista As List(Of classModelsShipay.Wallet)

    End Class
    Public Class RetOrder
        Public json As String
        Public orderResponse As classModelsShipay.ShipayOrderResponse
    End Class
    Public Class RetStatus
        Public json As String
        Public statusResponse As classModelsShipay.ShipayStatusResponse
    End Class
    Public Class RetDelete
        Public json As String
        Public deleteResponse As classModelsShipay.ShipayDeleteResponse
    End Class

    Function getCarteiras() As RetCarteiras
        Dim ret As New RetCarteiras()
        ret.json = ""
        Dim obj As New ShipayWallets
        Dim lista As New List(Of classModelsShipay.Wallet)
        Dim client As New RestSharp.RestClient(URL_TOKEN_Shipay & "wallets")

        client.Timeout = -1
        Dim request As New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authorization", "Bearer " & access_token_Shipay)
        Dim response As IRestResponse = client.Execute(request)
        ret.json = response.Content
        If (response.StatusCode = Net.HttpStatusCode.OK) Then
            obj = ShipayWallets.FromJson(response.Content)
            ret.lista = obj.Wallets
        Else
            Dim a = response.Content
        End If
        Return ret
    End Function
    Public Function getToken()

        Dim client As New RestSharp.RestClient(URL_TOKEN_Shipay & "pdvauth")
        client.Timeout = -1
        Dim request As New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        Dim json = "{
                      ""access_key"": """ & AccessKey_Shipay & """,
                      ""client_id"": """ & ClientID_Shipay & """,
                      ""secret_key"": """ & SecretKey_Shipay & """
                    }"
        request.AddParameter("application/json", json, ParameterType.RequestBody)
        Dim response As IRestResponse = client.Execute(request)

        Try
            token = JsonConvert.DeserializeObject(Of classModelsShipay.ShipayToken)(response.Content)
            access_token_Shipay = NuloString(token.access_token)

        Catch ex As Exception
            'MsgBox("Erro para gerar token Pagamento Digital")
            frmPrincipal.lbPainel.Text = "Erro para gerar token Pagamento Digital"
            Dim a = ex.Message
        End Try
    End Function

    Function postOrder(ByVal order As classModelsShipay.ShipayOrderRequest) As RetOrder
        Dim ret As New RetOrder()
        ret.json = ""
        Dim client As New RestSharp.RestClient(URL_TOKEN_Shipay & "order")
        client.Timeout = -1

        Dim request As New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authorization", "Bearer " & access_token_Shipay)
        request.AddParameter("application/json", order.ToJson(), ParameterType.RequestBody)

        Dim response As IRestResponse = client.Execute(request)
        ret.json = response.Content
        If (response.StatusCode = Net.HttpStatusCode.OK) Then
            ret.orderResponse = ShipayOrderResponse.FromJson(response.Content)
        Else
            Dim a = response.Content
        End If
        Return ret
    End Function

    Function getStatus(ByVal orderId As String) As RetStatus
        Dim ret As New RetStatus()
        ret.json = ""
        Dim obj As New ShipayWallets
        Dim lista As New List(Of classModelsShipay.Wallet)
        Dim client As New RestSharp.RestClient(URL_TOKEN_Shipay & "order/" & orderId)

        client.Timeout = -1
        Dim request As New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authorization", "Bearer " & access_token_Shipay)
        Dim response As IRestResponse = client.Execute(request)
        ret.json = response.Content
        If (response.StatusCode = Net.HttpStatusCode.OK) Then
            ret.statusResponse = ShipayStatusResponse.FromJson(response.Content)
        Else
            Dim a = response.Content
        End If
        Return ret
    End Function

    Function deleteOrder(ByVal orderId As String) As RetDelete
        Dim ret As New RetDelete()
        ret.json = ""
        Dim obj As New ShipayWallets
        Dim client As New RestSharp.RestClient(URL_TOKEN_Shipay & "order/" & orderId)

        client.Timeout = -1
        Dim request As New RestRequest(Method.DELETE)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authorization", "Bearer " & access_token_Shipay)
        Dim response As IRestResponse = client.Execute(request)
        ret.json = response.Content
        If (response.StatusCode = Net.HttpStatusCode.OK) Then
            ret.deleteResponse = ShipayDeleteResponse.FromJson(response.Content)
        Else
            Dim a = response.Content
        End If
        Return ret
    End Function
End Class
