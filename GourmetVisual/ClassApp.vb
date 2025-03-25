Imports Newtonsoft.Json
Imports System.Runtime.CompilerServices

Namespace QrboxApp
    'Public Class ClassApp

    Partial Public Class QrboxPedidoResponse
      <JsonProperty("id", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Id As String
        <JsonProperty("reference", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Reference As String
        <JsonProperty("shortReference", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ShortReference As String
        <JsonProperty("createdAt", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property CreatedAt As DateTimeOffset?
        <JsonProperty("type", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Type As String
        <JsonProperty("merchant", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Merchant As Merchant
        <JsonProperty("payments", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Payments As Payment()
        <JsonProperty("customer", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Customer As Customer
        <JsonProperty("items", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Items As Item()
        <JsonProperty("subTotal", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property SubTotal As Double?
        <JsonProperty("totalPrice", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property TotalPrice As Double?
        <JsonProperty("deliveryFee", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryFee As Double?
        <JsonProperty("deliveryAddress", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryAddress As DeliveryAddress
        <JsonProperty("deliveryMethod", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property deliveryMethod As deliveryMethod
        Public Property DeliveryDateTime As DateTimeOffset?
        <JsonProperty("preparationTimeInSeconds", NullValueHandling:=NullValueHandling.Ignore)>
        <JsonConverter(GetType(PurpleParseStringConverter))>
        Public Property PreparationTimeInSeconds As Long?
    End Class

    Partial Public Class deliveryMethod
        <JsonProperty("id", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property id As String
        <JsonProperty("mode", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property mode As String

    End Class
    Partial Public Class Customer
            <JsonProperty("id", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property id As String
            <JsonProperty("name", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Name As String = ""
            <JsonProperty("taxPayerIdentificationNumber", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property TaxPayerIdentificationNumber As String
            <JsonProperty("phone", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Phone As String
            <JsonProperty("email", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Email As String
        End Class


        Partial Public Class DeliveryAddress
            <JsonProperty("formattedAddress", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property FormattedAddress As String
            <JsonProperty("country", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Country As String
            <JsonProperty("state", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property State As String
            <JsonProperty("city", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property City As String
            <JsonProperty("coordinates", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Coordinates As Coordinates
            <JsonProperty("neighborhood", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Neighborhood As String
            <JsonProperty("streetName", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property StreetName As String
            <JsonProperty("streetNumber", NullValueHandling:=NullValueHandling.Ignore)>
            <JsonConverter(GetType(PurpleParseStringConverter))>
            Public Property StreetNumber As Long?
            <JsonProperty("postalCode", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property PostalCode As String
            <JsonProperty("reference", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Reference As String
            <JsonProperty("complement", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Complement As String
        End Class


        Partial Public Class Coordinates
            <JsonProperty("latitude", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Latitude As String
            <JsonProperty("longitude", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Longitude As String
        End Class


        Partial Public Class Item
            <JsonProperty("id", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Id As String
            <JsonProperty("name", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Name As String = ""
            <JsonProperty("quantity", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Quantity As Long?
            <JsonProperty("price", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Price As Long?
            <JsonProperty("subItemsPrice", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property SubItemsPrice As Long?
            <JsonProperty("totalPrice", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property TotalPrice As Long?
            <JsonProperty("discount", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Discount As Long?
            <JsonProperty("addition", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Addition As Long?
            <JsonProperty("externalCode", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property ExternalCode As String
            <JsonProperty("observations", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Observations As String
            <JsonProperty("subItems", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property SubItems As Object()
            <JsonProperty("index", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property index As Long?

        End Class


        Partial Public Class Merchant
            <JsonProperty("id", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Id As String
            <JsonProperty("name", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Name As String = ""
            <JsonProperty("phones", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Phones As Object()
            <JsonProperty("address", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Address As Address
        End Class


        Partial Public Class Address
            <JsonProperty("formattedAddress", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property FormattedAddress As String
            <JsonProperty("country", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Country As String
            <JsonProperty("state", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property State As String
            <JsonProperty("city", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property City As String
            <JsonProperty("neighborhood", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Neighborhood As String
            <JsonProperty("streetName", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property StreetName As String
            <JsonProperty("streetNumber", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property StreetNumber As String
            <JsonProperty("postalCode", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property PostalCode As String
        End Class


        Partial Public Class Payment
            <JsonProperty("name", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Name As String = ""
            <JsonProperty("code", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Code As String
            <JsonProperty("value", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Value As Double?
            <JsonProperty("prepaid", NullValueHandling:=NullValueHandling.Ignore)>
            <JsonConverter(GetType(FluffyParseStringConverter))>
            Public Property Prepaid As Boolean?
            <JsonProperty("issuer", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property Issuer As String
            <JsonProperty("changeFor", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property ChangeFor As Long?
            <JsonProperty("externalCode", NullValueHandling:=NullValueHandling.Ignore)>
            Public Property ExternalCode As String
        End Class


        Partial Public Class QrboxPedidoResponse
            Public Shared Function FromJson(ByVal json As String) As QrboxPedidoResponse
                Return JsonConvert.DeserializeObject(Of QrboxPedidoResponse)(json, Settings)
            End Function
        End Class


        Public Module Serialize
            Public Function ToJson(ByVal self As QrboxPedidoResponse) As String
                Return JsonConvert.SerializeObject(self, Settings)
            End Function
        End Module


        Friend Module Converter
            Public ReadOnly Settings As JsonSerializerSettings = New JsonSerializerSettings With {
                .MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                .DateParseHandling = DateParseHandling.None
            }
        End Module


        Friend Class PurpleParseStringConverter
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

                Dim value = CLng(untypedValue)
                serializer.Serialize(writer, value.ToString())
                Return
            End Sub


            Public Shared ReadOnly Singleton As PurpleParseStringConverter = New PurpleParseStringConverter()
        End Class

        Friend Class FluffyParseStringConverter
            Inherits JsonConverter

            Public Overrides Function CanConvert(ByVal t As Type) As Boolean
                Return t Is GetType(Boolean) OrElse t Is GetType(Boolean?)
            End Function

            Public Overrides Function ReadJson(ByVal reader As JsonReader, ByVal t As Type, ByVal existingValue As Object, ByVal serializer As JsonSerializer) As Object
                If reader.TokenType = JsonToken.Null Then Return Nothing
                Dim value = serializer.Deserialize(Of String)(reader)
                Dim b As Boolean

                If Boolean.TryParse(value, b) Then
                    Return b
                End If

                Throw New Exception("Cannot unmarshal type bool")
            End Function

            Public Overrides Sub WriteJson(ByVal writer As JsonWriter, ByVal untypedValue As Object, ByVal serializer As JsonSerializer)
                If untypedValue Is Nothing Then
                    serializer.Serialize(writer, Nothing)
                    Return
                End If

                Dim value = CBool(untypedValue)
                Dim boolString = If(value, "true", "false")
                serializer.Serialize(writer, boolString)
                Return
            End Sub

            Public Shared ReadOnly Singleton As FluffyParseStringConverter = New FluffyParseStringConverter()
        End Class

    'End Class

End Namespace
