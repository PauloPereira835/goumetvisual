Public Class ModelsRappi
    'Token
    Public Class RappiToken
        Public Property access_token As String
        Public Property scope As String
        Public Property expires_in As Integer
        Public Property token_type As String
    End Class

    'Pedidos
    Public Class Delivery_discount
        Public Property total_percentage_discount As Decimal
        Public Property total_value_discount As Decimal

    End Class
    Public Class customer
        Public Property first_name As String
        Public Property last_name As String
        Public Property phone_number As String

    End Class
    Public Class billing_information
        Public Property address As String
        Public Property billing_type As String
        Public Property document_number As String
        Public Property document_type As String
        Public Property email As String
        Public Property name As String
        Public Property phone As String

    End Class
    Public Class delivery_information
        Public Property address_tag As String
        Public Property city As String
        Public Property street_shorcut As String
        Public Property complete_address As String
        Public Property federal_unit As String
        Public Property street_number As String
        Public Property address_description As String
        Public Property neighborhood As String
        Public Property complement As String
        Public Property postal_code As String
        Public Property street_name As String

    End Class
    Public Class Charges
        Public Property shipping As Double
        Public Property service_fee As Double
    End Class

    Public Class OtherTotals
        Public Property total_rappi_credits As Double
        Public Property total_rappi_pay As Double
        Public Property tip As Double
    End Class

    Public Class Totals
        Public Property total_products_with_discount As Double
        Public Property total_products_without_discount As Double
        Public Property total_other_discounts As Double
        Public Property total_order As Double
        Public Property total_to_pay As Double
        Public Property charges As Charges
        Public Property other_totals As OtherTotals
    End Class

    Public Class Subitem
        Public Property sku As Object
        Public Property id As String
        Public Property name As String
        Public Property type As String
        Public Property comments As Object
        Public Property unit_price_with_discount As Double
        Public Property unit_price_without_discount As Double
        Public Property percentage_discount As Double
        Public Property quantity As Integer
        Public Property subitems As Object()
    End Class

    Public Class Item
        Public Property sku As Object
        Public Property id As String
        Public Property name As String
        Public Property type As String
        Public Property comments As Object
        Public Property unit_price_with_discount As Double
        Public Property unit_price_without_discount As Double
        Public Property percentage_discount As Double
        Public Property quantity As Integer
        Public Property subitems As Subitem()
    End Class

    Public Class OrderDetail
        Public Property order_id As String
        Public Property cooking_time As Integer
        Public Property min_cooking_time As Integer
        Public Property max_cooking_time As Integer
        Public Property created_at As String
        Public Property delivery_method As String
        Public Property payment_method As String
        Public Property billing_information As billing_information
        Public Property delivery_information As delivery_information
        Public Property totals As Totals
        Public Property items As Item()
        Public Property delivery_discount As Delivery_discount
    End Class

    Public Class Store
        Public Property internal_id As String
        Public Property external_id As String
        Public Property name As String
    End Class

    Public Class RappiPedidos
        Public Property order_detail As OrderDetail
        Public Property customer As customer
        Public Property store As Store
    End Class
End Class
