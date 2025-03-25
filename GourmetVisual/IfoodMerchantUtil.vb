Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class IfoodMerchantUtil
    Public Shared apis As List(Of IfoodMerchantApiDef) = New List(Of IfoodMerchantApiDef)() From {
       New IfoodMerchantApiDef() With {
           .tipo = "eventspolling",
           .method = "GET",
           .url = "/order/v1.0/events%3Apolling"
       },
       New IfoodMerchantApiDef() With {
           .tipo = "orders",
           .method = "GET",
           .url = "/order/v1.0/orders/{{reference}}"
       },
       New IfoodMerchantApiDef() With {
           .tipo = "acknowledgment",
           .method = "POST",
           .url = "/order/v1.0/events/acknowledgment"
       },
       New IfoodMerchantApiDef() With {
           .tipo = "statuses",
           .method = "POST",
           .url = "/order/v1.0/orders/{{reference}}/{{statuses}}"
       },
       New IfoodMerchantApiDef() With {
           .tipo = "ColibriConsultaEstadoResponse",
           .method = "GET",
           .url = "/tickets/?"
       }
   }
    Private Shared Function DoRequest(Of T)(ByVal UrlBase As String, ByVal req As Object, ByVal resp As T, ByVal log As IfoodMerchantRequestLog, ByVal method As String, ByVal url As String, ByVal app As String) As T
        Try
            Dim wc = New WebClient()
            wc.Headers.Add("content-type", "application/json")
            wc.Encoding = System.Text.Encoding.UTF8
            wc.Headers.Add("Authorization", "bearer " & appIfoodMerchant.tokenAccessIfood)
            log.url = UrlBase & url
            log.method = method

            Select Case method
                Case "POST"
                    log.request = JsonConvert.SerializeObject(req, New JsonSerializerSettings With {
                        .NullValueHandling = NullValueHandling.Ignore,
                        .Formatting = Formatting.Indented
                    })
                    Dim logOriginal = log.request

                    Try
                        Dim tempBytes As Byte()
                        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(log.request)
                        Dim asciiStr As String = System.Text.Encoding.UTF8.GetString(tempBytes)
                        log.request = asciiStr
                    Catch e As Exception
                        log.request = logOriginal
                    End Try

                    log.response = wc.UploadString(log.url, method, log.request)
                Case "GET"
                    log.response = wc.DownloadString(log.url)
                Case "DELETE"
                    log.response = wc.UploadString(log.url, method, "")
                Case Else
            End Select

            resp = JsonConvert.DeserializeObject(Of T)(log.response, appIfoodMerchant.Settings)

        Catch ex As WebException

            log.response = ex.Message & "|||"

            Try

                Using r As StreamReader = New StreamReader(ex.Response.GetResponseStream(), System.Text.Encoding.UTF8)
                    log.response += r.ReadToEnd()
                End Using

            Catch __unusedException1__ As Exception

            End Try

        Catch e As Exception
            log.response = e.Message & "|||" + log.response
        End Try

        Return resp
    End Function

    Private Shared Function DoRequestIfood(Of T)(ByVal UrlBase As String, ByVal req As Object, ByVal resp As T, ByVal log As IfoodMerchantRequestLog, ByVal method As String, ByVal url As String) As T
        Try
            Dim wc = New WebClient()
            wc.Headers.Add("content-type", "application/json")
            wc.Encoding = System.Text.Encoding.UTF8
            wc.Headers.Add("Authorization", "bearer " & appIfoodMerchant.tokenAccessIfood)
            wc.Headers.Add("Cache-Control", "no-cache")
            log.url = UrlBase & url
            log.method = method

            Select Case method
                Case "POST"
                    log.request = JsonConvert.SerializeObject(req, New JsonSerializerSettings With {
                        .NullValueHandling = NullValueHandling.Ignore,
                        .Formatting = Formatting.Indented
                    })
                    Dim logOriginal = log.request

                    Try
                        Dim tempBytes As Byte()
                        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(log.request)
                        Dim asciiStr As String = System.Text.Encoding.UTF8.GetString(tempBytes)
                        log.request = asciiStr
                    Catch e As Exception
                        log.request = logOriginal
                    End Try

                    log.response = wc.UploadString(log.url, method, log.request)
                Case "GET"
                    log.response = wc.DownloadString(log.url)
                Case "DELETE"
                    log.response = wc.UploadString(log.url, method, "")
                Case Else
            End Select

            resp = JsonConvert.DeserializeObject(Of T)(log.response, appIfoodMerchant.Settings)
        Catch ex As WebException
            log.response = ex.Message & "|||"

            Try

                Using r As StreamReader = New StreamReader(ex.Response.GetResponseStream(), System.Text.Encoding.UTF8)
                    log.response += r.ReadToEnd()
                End Using

            Catch __unusedException1__ As Exception
            End Try

        Catch e As Exception
            log.response = e.Message & "|||" + log.response
        End Try

        Return resp
    End Function

    Public Shared Function Enviar(Of T, T2)(ByVal UrlBase As String, ByVal api As String, ByVal app As String, ByVal req As T, ByVal Optional reference As String = "", ByVal Optional statuses As String = "") As Tuple(Of T2, IfoodMerchantRequestLog)

        UrlBase = UriIfood

        Dim resp = CType(Activator.CreateInstance(GetType(T2)), T2)
        Dim log = New IfoodMerchantRequestLog()
        Dim apiDef = apis.Where(Function(x) x.tipo = api).FirstOrDefault()
        Dim strUrl = apiDef.url
        If Not String.IsNullOrEmpty(reference) Then strUrl = strUrl.Replace("{{reference}}", reference)
        If Not String.IsNullOrEmpty(statuses) Then
            strUrl = strUrl.Replace("{{statuses}}", statuses)
        End If
        resp = DoRequest(Of T2)(UrlBase, req, resp, log, apiDef.method, strUrl, app)
        Return New Tuple(Of T2, IfoodMerchantRequestLog)(resp, log)
    End Function
    Public Shared Function EnviarMudaStatusIfood_Cancelado(Of T, T2)(ByVal UrlBase As String, ByVal req As T, ByVal Optional reference As String = "", ByVal Optional statuses As String = "") As Tuple(Of T2, IfoodMerchantRequestLog)
        Dim resp = CType(Activator.CreateInstance(GetType(T2)), T2)
        Dim log = New IfoodMerchantRequestLog()
        Dim apiDef = apis.Where(Function(x) x.tipo = resp.[GetType]().FullName).FirstOrDefault()
        Dim strUrl = reference & "/statuses/" & statuses
        If Not String.IsNullOrEmpty(reference) Then strUrl = strUrl.Replace("{{reference}}", reference)
        If Not String.IsNullOrEmpty(statuses) Then strUrl = strUrl.Replace("{{statuses}}", statuses)
        resp = DoRequestIfood(Of T2)(UrlBase, req, resp, log, "POST", strUrl)
        Return New Tuple(Of T2, IfoodMerchantRequestLog)(resp, log)
    End Function
    Public Shared Function EnviarOrderIfood(Of T, T2)(ByVal UrlBase As String, ByVal req As T, ByVal Optional reference As String = "", ByVal Optional statuses As String = "") As Tuple(Of T2, IfoodMerchantRequestLog)
        Dim resp = CType(Activator.CreateInstance(GetType(T2)), T2)
        Dim log = New IfoodMerchantRequestLog()
        Dim apiDef = apis.Where(Function(x) x.tipo = resp.[GetType]().FullName).FirstOrDefault()
        Dim strUrl = "orders/" & reference
        If Not String.IsNullOrEmpty(reference) Then strUrl = strUrl.Replace("{{reference}}", reference)
        If Not String.IsNullOrEmpty(statuses) Then strUrl = strUrl.Replace("{{statuses}}", statuses)
        resp = DoRequestIfood(Of T2)(UrlBase, req, resp, log, "GET", strUrl)
        Return New Tuple(Of T2, IfoodMerchantRequestLog)(resp, log)
    End Function
    Public Shared Function EnviarAckIfood(Of T, T2)(ByVal UrlBase As String, ByVal req As T, ByVal Optional reference As String = "", ByVal Optional statuses As String = "") As Tuple(Of T2, IfoodMerchantRequestLog)
        Dim resp = CType(Activator.CreateInstance(GetType(T2)), T2)
        Dim log = New IfoodMerchantRequestLog()
        Dim apiDef = apis.Where(Function(x) x.tipo = resp.[GetType]().FullName).FirstOrDefault()
        Dim strUrl = "events/acknowledgment"
        If Not String.IsNullOrEmpty(reference) Then strUrl = strUrl.Replace("{{reference}}", reference)
        If Not String.IsNullOrEmpty(statuses) Then strUrl = strUrl.Replace("{{statuses}}", statuses)
        resp = DoRequestIfood(Of T2)(UrlBase, req, resp, log, "POST", strUrl)
        Return New Tuple(Of T2, IfoodMerchantRequestLog)(resp, log)
    End Function

    Public Shared Function EnviarPolingIfood(Of T, T2)(ByVal UrlBase As String, ByVal req As T, ByVal Optional reference As String = "", ByVal Optional statuses As String = "") As Tuple(Of T2, IfoodMerchantRequestLog)
        Dim resp = CType(Activator.CreateInstance(GetType(T2)), T2)
        Dim log = New IfoodMerchantRequestLog()
        Dim apiDef = apis.Where(Function(x) x.tipo = resp.[GetType]().FullName).FirstOrDefault()
        Dim strUrl = "events%3Apolling"
        If Not String.IsNullOrEmpty(reference) Then strUrl = strUrl.Replace("{{reference}}", reference)
        If Not String.IsNullOrEmpty(statuses) Then strUrl = strUrl.Replace("{{statuses}}", statuses)
        resp = DoRequestIfood(Of T2)(UrlBase, req, resp, log, "GET", strUrl)
        Return New Tuple(Of T2, IfoodMerchantRequestLog)(resp, log)
    End Function
End Class
