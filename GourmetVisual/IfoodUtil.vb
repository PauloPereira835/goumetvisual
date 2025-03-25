Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Public Class IfoodUtil
    Public Class IfoodApiDef
        Public Property tipo As String
        Public Property url As String
        Public Property method As String
    End Class


    Public Shared apis As List(Of IfoodApiDef) = New List(Of IfoodApiDef)() From {
            New IfoodApiDef() With {
                .tipo = "eventspolling",
                .method = "GET",
                .url = "v1.0/events%3Apolling"
            },
            New IfoodApiDef() With {
                .tipo = "orders",
                .method = "GET",
                .url = "v3.0/orders/{{reference}}"
            },
            New IfoodApiDef() With {
                .tipo = "acknowledgment",
                .method = "POST",
                .url = "v1.0/events/acknowledgment"
            },
            New IfoodApiDef() With {
                .tipo = "statuses",
                .method = "POST",
                .url = "/orders/{{reference}}/statuses/{{statuses}}"
            },
            New IfoodApiDef() With {
                .tipo = "ColibriConsultaEstadoResponse",
                .method = "GET",
                .url = "/tickets/?"
            }
        }
    Partial Public Class EventsPooling
        <JsonProperty("code")>
        Public Property Code As String
        <JsonProperty("correlationId")>
        Public Property CorrelationId As String
        <JsonProperty("createdAt")>
        Public Property CreatedAt As DateTimeOffset
        <JsonProperty("id")>
        Public Property Id As String
    End Class

    Partial Public Class EventsPooling
        Public Shared Function FromJson(ByVal json As String) As List(Of EventsPooling)
            Return JsonConvert.DeserializeObject(Of List(Of EventsPooling))(json, QrboxApp.Settings)
        End Function
    End Class

    Private Shared Function DoRequest(Of T)(ByVal UrlBase As String, ByVal req As Object, ByVal resp As T, ByVal log As IfoodRequestLog, ByVal method As String, ByVal url As String, ByVal app As String) As T
        Try
            Dim wc = New WebClient()
            wc.Headers.Add("content-type", "application/json")
            wc.Encoding = System.Text.Encoding.UTF8
            wc.Headers.Add("Authorization", "bearer " & appIfood.token_accessIfood)

            log.url = UrlBase & url
            log.method = method

            Dim jsom As String = NuloString(PegaValorCampo("Json", "SELECT IDVendaExterna, Json FROM tblAppVendas WHERE IDVendaExterna='" & frmAppPedidos.Grid.Item(2, frmAppPedidos.Grid.CurrentRow.Index).Value & "'", strCon))

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
                        'FileUtil.log(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") & " - DoRequest Exception " & url + e)
                    End Try

                    log.response = wc.UploadString(log.url, method, log.request)
                Case "GET"
                    ' log.response = wc.DownloadString(log.url)
                    log.response = NuloString(PegaValorCampo("Json", "SELECT IDVendaExterna, Json FROM tblAppVendas WHERE IDVendaExterna='" & frmAppPedidos.Grid.Item(2, frmAppPedidos.Grid.CurrentRow.Index).Value & "'", strCon))
                Case "DELETE"
                    log.response = wc.UploadString(log.url, method, "")
                Case Else
            End Select

            resp = JsonConvert.DeserializeObject(Of T)(NuloString(PegaValorCampo("Json", "SELECT IDVendaExterna, Json FROM tblAppVendas WHERE IDVendaExterna='" & frmAppPedidos.Grid.Item(2, frmAppPedidos.Grid.CurrentRow.Index).Value & "'", strCon)), appIfood.Settings)
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

    Private Shared Function DoRequestIfood(Of T)(ByVal UrlBase As String, ByVal req As Object, ByVal resp As T, ByVal log As IfoodRequestLog, ByVal method As String, ByVal url As String) As T
        Try
            Dim wc = New WebClient()
            wc.Headers.Add("content-type", "application/json")
            wc.Encoding = System.Text.Encoding.UTF8
            wc.Headers.Add("Authorization", "bearer " & appIfood.token_accessIfood)
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
                        'FileUtil.log(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") & " - DoRequest Exception " & url + e)
                    End Try

                    log.response = wc.UploadString(log.url, method, log.request)
                Case "GET"
                    log.response = wc.DownloadString(log.url)
                Case "DELETE"
                    log.response = wc.UploadString(log.url, method, "")
                Case Else
            End Select

            resp = JsonConvert.DeserializeObject(Of T)(log.response, QrboxApp.Settings)
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


    Public Shared Function Enviar(Of T, T2)(ByVal UrlBase As String, ByVal api As String, ByVal app As String, ByVal req As T, ByVal Optional reference As String = "", ByVal Optional statuses As String = "", ByVal Optional Origem As String = "") As Tuple(Of T2, IfoodRequestLog)
        Dim resp = CType(Activator.CreateInstance(GetType(T2)), T2)
        Dim log = New IfoodRequestLog()
        Dim apiDef = apis.Where(Function(x) x.tipo = api).FirstOrDefault()
        Dim strUrl = apiDef.url
        If Not String.IsNullOrEmpty(reference) Then strUrl = strUrl.Replace("{{reference}}", reference)
        If Not String.IsNullOrEmpty(statuses) Then
            strUrl = strUrl.Replace("{{statuses}}", statuses)
            Dim ver = "v1.0"
            If (statuses = "cancellationRequested") Then
                ver = "v3.0"
            ElseIf (statuses = "readyToDeliver") Then
                ver = "v2.0"
            End If
            strUrl = ver & strUrl

        End If
        If Origem = "0" Then
            resp = DoRequest(Of T2)(UrlBase, NuloString(PegaValorCampo("Json", "SELECT IDVendaExterna, Json FROM tblAppVendas WHERE IDVendaExterna='" & frmAppPedidos.Grid.Item(2, frmAppPedidos.Grid.CurrentRow.Index).Value & "'", strCon)), resp, log, apiDef.method, strUrl, app)
        Else
            resp = DoRequest(Of T2)(UrlBase, req, resp, log, apiDef.method, strUrl, app)
        End If
        Return New Tuple(Of T2, IfoodRequestLog)(resp, log)
    End Function
End Class
