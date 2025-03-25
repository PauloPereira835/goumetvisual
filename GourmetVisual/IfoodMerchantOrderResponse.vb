Imports System.Runtime.CompilerServices
Imports Newtonsoft.Json
Module IfoodMerchantOrderResponse
    Partial Public Class Order
        <JsonProperty("id", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Id As Guid?
        <JsonProperty("orderTiming", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property OrderTiming As String
        <JsonProperty("orderType", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property OrderType As String
        <JsonProperty("salesChannel", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property SalesChannel As SalesChannel?
        <JsonProperty("delivery", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Delivery As Delivery
        <JsonProperty("displayId", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DisplayId As String
        <JsonProperty("createdAt", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property CreatedAt As DateTimeOffset?
        <JsonProperty("preparationStartDateTime", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property PreparationStartDateTime As DateTimeOffset?
        <JsonProperty("merchant", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Merchant As Merchant
        <JsonProperty("customer", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Customer As Customer
        <JsonProperty("items", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Items As List(Of ItemIfood)
        <JsonProperty("benefits", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Benefits As List(Of Benefit)
        <JsonProperty("additionalFees", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property AdditionalFees As List(Of AdditionalFee)
        <JsonProperty("total", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Total As Total
        <JsonProperty("payments", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Payments As Payments
        <JsonProperty("picking", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Picking As Picking
        <JsonProperty("test", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Test As Boolean?
        <JsonProperty("additionalInfo", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property AdditionalInfo As AdditionalInfo
        <JsonProperty("schedule", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Schedule As Schedule
        <JsonProperty("takeout", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Takeout As Takeout
        <JsonProperty("indoor", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Indoor As Indoor
    End Class

    Partial Public Class AdditionalFee
        <JsonProperty("type", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Type As String
        <JsonProperty("value", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Value As Long?
    End Class

    Partial Public Class AdditionalInfo
        <JsonProperty("metadata", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Metadata As Metadata
    End Class

    Partial Public Class Metadata
        <JsonProperty("codigoInternoPdv", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property CodigoInternoPdv As String
        <JsonProperty("nomeVendedor", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property NomeVendedor As String
    End Class

    Partial Public Class Benefit
        <JsonProperty("value", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Value As Double?
        <JsonProperty("sponsorshipValues", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property SponsorshipValues As List(Of SponsorshipValue)
        <JsonProperty("target", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Target As Target?
        <JsonProperty("targetId", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property TargetId As String
    End Class

    Partial Public Class SponsorshipValue
        <JsonProperty("name", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As SalesChannel?
        <JsonProperty("value", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Value As Double?
    End Class

    Partial Public Class Customer
        <JsonProperty("id", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Id As Guid?
        <JsonProperty("name", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As String
        <JsonProperty("documentNumber", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DocumentNumber As String
        <JsonProperty("phone", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Phone As Phone
        <JsonProperty("ordersCountOnMerchant", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property OrdersCountOnMerchant As Long?
    End Class

    Partial Public Class Phone
        <JsonProperty("number", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Number As String
        <JsonProperty("localizer", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Localizer As String
        <JsonProperty("localizerExpiration", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property LocalizerExpiration As DateTimeOffset?
    End Class

    Partial Public Class Delivery
        <JsonProperty("mode", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Mode As String
        <JsonProperty("deliveredBy", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveredBy As SalesChannel?
        <JsonProperty("deliveryDateTime", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryDateTime As DateTimeOffset?
        <JsonProperty("deliveryAddress", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryAddress As DeliveryAddress
    End Class

    Partial Public Class DeliveryAddress
        <JsonProperty("streetName", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property StreetName As String
        <JsonProperty("streetNumber", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property StreetNumber As String
        <JsonProperty("formattedAddress", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property FormattedAddress As String
        <JsonProperty("neighborhood", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Neighborhood As String
        <JsonProperty("complement", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Complement As String
        <JsonProperty("reference", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Reference As String
        <JsonProperty("postalCode", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property PostalCode As String
        <JsonProperty("city", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property City As String
        <JsonProperty("state", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property State As String
        <JsonProperty("country", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Country As String
        <JsonProperty("coordinates", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Coordinates As Coordinates
    End Class

    Partial Public Class Coordinates
        <JsonProperty("latitude", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Latitude As Double?
        <JsonProperty("longitude", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Longitude As Double?
    End Class

    Partial Public Class Indoor
        <JsonProperty("mode", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Mode As String
        <JsonProperty("table", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Table As String
        <JsonProperty("deliveryDateTime", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryDateTime As DateTimeOffset?
    End Class

    Partial Public Class ItemIfood
        <JsonProperty("index", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Index As Long?
        <JsonProperty("id", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Id As Guid?
        <JsonProperty("name", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As String
        <JsonProperty("imageUrl", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ImageUrl As Uri
        <JsonProperty("externalCode", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ExternalCode As String
        <JsonProperty("ean", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Ean As String
        <JsonProperty("unit", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Unit As String
        <JsonProperty("quantity", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Quantity As Long?
        <JsonProperty("unitPrice", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property UnitPrice As Double?
        <JsonProperty("addition", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Addition As Long?
        <JsonProperty("price", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Price As Double?
        <JsonProperty("optionsPrice", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property OptionsPrice As Double?
        <JsonProperty("totalPrice", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property TotalPrice As Double?
        <JsonProperty("observations", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Observations As String
        <JsonProperty("options", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Options As List(Of [Option])
    End Class

    Partial Public Class [Option]
        <JsonProperty("index", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Index As Long?
        <JsonProperty("id", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Id As Guid?
        <JsonProperty("name", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As String
        <JsonProperty("externalCode", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ExternalCode As String
        <JsonProperty("ean", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Ean As String
        <JsonProperty("unit", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Unit As String
        <JsonProperty("quantity", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Quantity As Long?
        <JsonProperty("unitPrice", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property UnitPrice As Double?
        <JsonProperty("addition", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Addition As Long?
        <JsonProperty("price", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Price As Double?
    End Class

    Partial Public Class Merchant
        <JsonProperty("id", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Id As Guid?
        <JsonProperty("name", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As String
    End Class

    Partial Public Class Payments
        <JsonProperty("prepaid", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Prepaid As Double?
        <JsonProperty("pending", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Pending As Long?
        <JsonProperty("methods", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Methods As List(Of MethodIfood)
    End Class

    Partial Public Class MethodIfood
        <JsonProperty("value", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Value As Double?
        <JsonProperty("currency", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Currency As String
        <JsonProperty("method", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property MethodMethod As String
        <JsonProperty("type", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Type As String
        <JsonProperty("prepaid", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Prepaid As Boolean?
    End Class

    Partial Public Class Picking
        <JsonProperty("picker", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Picker As String
        <JsonProperty("replacementOptions", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ReplacementOptions As String
    End Class

    Partial Public Class Schedule
        <JsonProperty("deliveryDateTimeStart", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryDateTimeStart As DateTimeOffset?
        <JsonProperty("deliveryDateTimeEnd", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryDateTimeEnd As DateTimeOffset?
    End Class

    Partial Public Class Takeout
        <JsonProperty("mode", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Mode As String
        <JsonProperty("takeoutDateTime", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property TakeoutDateTime As DateTimeOffset?
    End Class

    Partial Public Class Total
        <JsonProperty("subTotal", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property SubTotal As Double?
        <JsonProperty("deliveryFee", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryFee As Double?
        <JsonProperty("additionalFees", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property AdditionalFees As Long?
        <JsonProperty("benefits", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Benefits As Double?
        <JsonProperty("orderAmount", Required:=Required.DisallowNull, NullValueHandling:=NullValueHandling.Ignore)>
        Public Property OrderAmount As Double?
    End Class

    Public Enum SalesChannel
        Ifood
        Merchant
    End Enum

    Public Enum Target
        Cart
        DeliveryFee
        Item
    End Enum

    Partial Public Class Order
        Public Shared Function FromJson(ByVal json As String) As List(Of Order)
            Return JsonConvert.DeserializeObject(Of List(Of Order))(json, appIfoodMerchant.Settings)
        End Function
    End Class

    <Extension()>
    Public Function ToJson(ByVal self As List(Of Order)) As String
        Return JsonConvert.SerializeObject(self, appIfoodMerchant.Settings)
    End Function

    Friend Class Converter
        Public ReadOnly Settings As JsonSerializerSettings = New JsonSerializerSettings With {
            .MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            .DateParseHandling = DateParseHandling.None
        }
    End Class

    Friend Class SalesChannelConverter
        Inherits JsonConverter

        Public Overrides Function CanConvert(ByVal t As Type) As Boolean
            Return t Is GetType(SalesChannel) OrElse t Is GetType(SalesChannel?)
        End Function

        Public Overrides Function ReadJson(ByVal reader As JsonReader, ByVal t As Type, ByVal existingValue As Object, ByVal serializer As JsonSerializer) As Object
            If reader.TokenType = JsonToken.Null Then Return Nothing
            Dim value = serializer.Deserialize(Of String)(reader)

            Select Case value
                Case "IFOOD"
                    Return SalesChannel.Ifood
                Case "MERCHANT"
                    Return SalesChannel.Merchant
            End Select

            Throw New Exception("Cannot unmarshal type SalesChannel")
        End Function

        Public Overrides Sub WriteJson(ByVal writer As JsonWriter, ByVal untypedValue As Object, ByVal serializer As JsonSerializer)
            If untypedValue Is Nothing Then
                serializer.Serialize(writer, Nothing)
                Return
            End If

            Dim value = CType(untypedValue, SalesChannel)

            Select Case value
                Case SalesChannel.Ifood
                    serializer.Serialize(writer, "IFOOD")
                    Return
                Case SalesChannel.Merchant
                    serializer.Serialize(writer, "MERCHANT")
                    Return
            End Select

            Throw New Exception("Cannot marshal type SalesChannel")
        End Sub

        Public Shared ReadOnly Singleton As SalesChannelConverter = New SalesChannelConverter()
    End Class

    Friend Class TargetConverter
        Inherits JsonConverter

        Public Overrides Function CanConvert(ByVal t As Type) As Boolean
            Return t Is GetType(Target) OrElse t Is GetType(Target?)
        End Function

        Public Overrides Function ReadJson(ByVal reader As JsonReader, ByVal t As Type, ByVal existingValue As Object, ByVal serializer As JsonSerializer) As Object
            If reader.TokenType = JsonToken.Null Then Return Nothing
            Dim value = serializer.Deserialize(Of String)(reader)

            Select Case value
                Case "CART"
                    Return Target.Cart
                Case "DELIVERY_FEE"
                    Return Target.DeliveryFee
                Case "ITEM"
                    Return Target.Item
            End Select

            Throw New Exception("Cannot unmarshal type Target")
        End Function

        Public Overrides Sub WriteJson(ByVal writer As JsonWriter, ByVal untypedValue As Object, ByVal serializer As JsonSerializer)
            If untypedValue Is Nothing Then
                serializer.Serialize(writer, Nothing)
                Return
            End If

            Dim value = CType(untypedValue, Target)

            Select Case value
                Case Target.Cart
                    serializer.Serialize(writer, "CART")
                    Return
                Case Target.DeliveryFee
                    serializer.Serialize(writer, "DELIVERY_FEE")
                    Return
                Case Target.Item
                    serializer.Serialize(writer, "ITEM")
                    Return
            End Select

            Throw New Exception("Cannot marshal type Target")
        End Sub
    End Class
End Module
