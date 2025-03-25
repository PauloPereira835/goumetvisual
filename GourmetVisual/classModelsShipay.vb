Imports Newtonsoft.Json
Imports GourmetVisual.classModelsShipay
Imports System.Runtime.CompilerServices

Public Class classModelsShipay
    Public Class ShipayToken
        Public Property access_token As String
    End Class

    'Shipay Wallets
    Partial Public Class ShipayWallets
        <JsonProperty("wallets")>
        Public Property Wallets As List(Of Wallet)
    End Class

    Partial Public Class Wallet
        <JsonProperty("active")>
        Public Property Active As Boolean
        <JsonProperty("form")>
        Public Property Form As Form
        <JsonProperty("minimum_payment")>
        Public Property MinimumPayment As Double
        <JsonProperty("name")>
        Public Property Name As String
        <JsonProperty("wallet_fee")>
        Public Property WalletFee As Long
    End Class

    Partial Public Class Form
        <JsonProperty("items")>
        Public Property Items As FormItems
        <JsonProperty("order_ref")>
        Public Property OrderRef As OrderRef
        <JsonProperty("total")>
        Public Property Total As OrderRef
        <JsonProperty("wallet")>
        Public Property Wallet As OrderRef
    End Class

    Partial Public Class FormItems
        <JsonProperty("items")>
        Public Property Items As ItemsItems
        <JsonProperty("type")>
        Public Property Type As String
    End Class

    Partial Public Class ItemsItems
        <JsonProperty("item_title")>
        Public Property ItemTitle As OrderRef
        <JsonProperty("quantity")>
        Public Property Quantity As OrderRef
        <JsonProperty("unit_price")>
        Public Property UnitPrice As OrderRef
    End Class

    Partial Public Class OrderRef
        <JsonProperty("regexp")>
        Public Property Regexp As String
        <JsonProperty("type")>
        Public Property Type As String
    End Class

    Partial Public Class ShipayWallets
        Public Shared Function FromJson(ByVal json As String) As ShipayWallets
            Return JsonConvert.DeserializeObject(Of ShipayWallets)(json, Converter.Settings)
        End Function
    End Class
    'Fim Shipay Wallets

    'Shipay Order Request
    Partial Public Class ShipayOrderRequest
        <JsonProperty("buyer")>
        Public Property Buyer As Buyer
        <JsonProperty("callback_url")>
        Public Property CallbackUrl As Uri
        <JsonProperty("items")>
        Public Property Items As List(Of Item)
        <JsonProperty("order_ref")>
        Public Property OrderRef As String
        <JsonProperty("total")>
        Public Property Total As Double
        <JsonProperty("wallet")>
        Public Property Wallet As String
    End Class

    Partial Public Class Buyer
        <JsonProperty("cpf")>
        Public Property Cpf As String
        <JsonProperty("email")>
        Public Property Email As String
        <JsonProperty("first_name")>
        Public Property FirstName As String
        <JsonProperty("last_name")>
        Public Property LastName As String
        <JsonProperty("phone")>
        Public Property Phone As String
    End Class

    Partial Public Class Item
        <JsonProperty("item_title")>
        Public Property ItemTitle As String
        <JsonProperty("quantity")>
        Public Property Quantity As Double
        <JsonProperty("unit_price")>
        Public Property UnitPrice As Double
    End Class
    Partial Public Class ShipayOrderRequest
        Public Shared Function FromJson(ByVal json As String) As ShipayOrderRequest
            Return JsonConvert.DeserializeObject(Of ShipayOrderRequest)(json, Converter.Settings)
        End Function
    End Class

    'Fim Shipay Order Request

    'Shipay Order Response 
    Partial Public Class ShipayOrderResponse
        <JsonProperty("deep_link")>
        Public Property DeepLink As String
        <JsonProperty("order_id")>
        Public Property OrderId As String
        <JsonProperty("qr_code")>
        Public Property QrCode As String
        <JsonProperty("qr_code_text")>
        Public Property QrCodeText As String
        <JsonProperty("status")>
        Public Property Status As String
    End Class

    Partial Public Class ShipayOrderResponse
        Public Shared Function FromJson(ByVal json As String) As ShipayOrderResponse
            Return JsonConvert.DeserializeObject(Of ShipayOrderResponse)(json, Converter.Settings)
        End Function
    End Class
    'Fim Shipay Order Response

    'Shipay Status Response
    Partial Public Class ShipayStatusResponse
        <JsonProperty("buyer_info")>
        Public Property BuyerInfo As BuyerInfo
        <JsonProperty("created_at")>
        Public Property CreatedAt As String
        <JsonProperty("external_id")>
        Public Property ExternalId As String
        <JsonProperty("items")>
        Public Property Items As List(Of StatusItem)
        <JsonProperty("order_id")>
        Public Property OrderId As String
        <JsonProperty("paid_amount")>
        Public Property PaidAmount As Double
        <JsonProperty("status")>
        Public Property Status As String
        <JsonProperty("total_order")>
        Public Property TotalOrder As Double
        <JsonProperty("updated_at")>
        Public Property UpdatedAt As String
        <JsonProperty("wallet")>
        Public Property Wallet As String
    End Class

    Partial Public Class BuyerInfo
        <JsonProperty("address")>
        Public Property Address As String
        <JsonProperty("city")>
        Public Property City As String
        <JsonProperty("document")>
        Public Property Document As String
        <JsonProperty("email")>
        Public Property Email As String
        <JsonProperty("first_name")>
        Public Property FirstName As String
        <JsonProperty("last_name")>
        Public Property LastName As String
        <JsonProperty("phone")>
        Public Property Phone As String
        <JsonProperty("state")>
        Public Property State As String
    End Class

    Partial Public Class StatusItem
        <JsonProperty("name")>
        Public Property Name As String
        <JsonProperty("quantity")>
        Public Property Quantity As Double
        <JsonProperty("unit_price")>
        Public Property UnitPrice As Double
    End Class

    Partial Public Class ShipayStatusResponse
        Public Shared Function FromJson(ByVal json As String) As ShipayStatusResponse
            Return JsonConvert.DeserializeObject(Of ShipayStatusResponse)(json, Converter.Settings)
        End Function
    End Class
    'Fim Shipay Status Response

    'Shipay Delete Response

    Partial Public Class ShipayDeleteResponse
        <JsonProperty("order_id")>
        Public Property OrderId As String
        <JsonProperty("status")>
        Public Property Status As String
    End Class

    Partial Public Class ShipayDeleteResponse
        Public Shared Function FromJson(ByVal json As String) As ShipayDeleteResponse
            Return JsonConvert.DeserializeObject(Of ShipayDeleteResponse)(json, Converter.Settings)
        End Function
    End Class


    'Fim Shipay Delete Response

End Class
Public Module Serialize
    <Extension()>
    Public Function ToJson(ByVal self As ShipayWallets) As String
        Return JsonConvert.SerializeObject(self, Converter.Settings)
    End Function
    <Extension()>
    Public Function ToJson(ByVal self As ShipayOrderRequest) As String
        Return JsonConvert.SerializeObject(self, Converter.Settings)
    End Function
    <Extension()>
    Public Function ToJson(ByVal self As ShipayOrderResponse) As String
        Return JsonConvert.SerializeObject(self, Converter.Settings)
    End Function
    <Extension()>
    Public Function ToJson(ByVal self As ShipayStatusResponse) As String
        Return JsonConvert.SerializeObject(self, Converter.Settings)
    End Function
    <Extension()>
    Public Function ToJson(ByVal self As ShipayDeleteResponse) As String
        Return JsonConvert.SerializeObject(self, Converter.Settings)
    End Function
End Module

Friend Module Converter
    Public ReadOnly Settings As JsonSerializerSettings = New JsonSerializerSettings With {
            .MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            .DateParseHandling = DateParseHandling.None
        }
End Module




