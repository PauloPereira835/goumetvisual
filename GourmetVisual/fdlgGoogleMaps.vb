Imports System.Text
Imports Microsoft.Web
Imports Microsoft.Win32

Public Class fdlgGoogleMaps
    Private Function VerificaNavegador() As Boolean
        Dim versaoNavegador As Integer, RegVal As Integer
        Try
            ' obtem a versão instalada do IE
            Using Wb As New WebBrowser()
                versaoNavegador = Wb.Version.Major
            End Using

            ' define a versão do IE
            If versaoNavegador >= 11 Then
                RegVal = 11001
            ElseIf versaoNavegador = 10 Then
                RegVal = 10001
            ElseIf versaoNavegador = 9 Then
                RegVal = 9999
            ElseIf versaoNavegador = 8 Then
                RegVal = 8888
            Else
                RegVal = 7000
            End If

            ' define a chave atual
            Dim Key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", True)
            Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord)
            Key.Close()
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgGoogleMaps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbDistancia.Text = ""
        lbTempo.Text = ""

        If VerificaNavegador() Then
            Try
                Dim rua As String = String.Empty
                Dim consultaEndereco As New StringBuilder()

                consultaEndereco.Append("http://maps.google.com/maps?q=")
                'consultaEndereco.Append("https://www.google.com/maps/")

                ' monta a rua como parte da consulta
                rua = lbLogradouro.Text.Replace(" ", "+") & "," & lbNumero.Text
                consultaEndereco.Append(rua + "," & "+")

                Dim url As New Uri(consultaEndereco.ToString)
                WebView.Source = url


                Try
                    fdlgExpedicao.lbDistancia.Text = "Distância: " & lbDistancia.Text & " / Tempo médio: " & lbTempo.Text
                Catch ex As Exception

                End Try


            Catch ex As Exception

                'MessageBox.Show(ex.Message.ToString(), "Não foi possível obter o Mapa")

            End Try

        Else
            MessageBox.Show("O Naveador usado é incompatível", "Aviso")
        End If
    End Sub


End Class