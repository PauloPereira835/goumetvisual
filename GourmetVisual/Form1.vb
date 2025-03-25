Imports System.Data.SqlClient
Imports System.Media
Imports System.ComponentModel
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '  If IO.File.Exists(Application.StartupPath & "\App_som.wav") Then
        '  My.Computer.Audio.Play(Application.StartupPath & "\App_som.wav", AudioPlayMode.Background)
        ' Else
        'frmInicio.DownloadViaFTP("ftp://ftp.iristecnologia.com.br/gv/App_som.wav", "iristecnologia", "647Bkzs?")
        'My.Computer.Audio.Play(Application.StartupPath & "\App_som.wav", AudioPlayMode.Background)
        'End If


        Dim CodPro As Integer
        strSql = "Select * From tblProdutosLojas"

        Dim dap = New SqlDataAdapter(strSql, strConServer)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "prod")
        For i As Integer = 0 To ds.Tables("prod").Rows.Count - 1
            If NuloInteger(ds.Tables("prod").Rows(i).Item("CodigoProduto")) > 1000 Then

                CodPro = NuloInteger(Strings.Right(ds.Tables("prod").Rows(i).Item("CodigoProduto"), Len(ds.Tables("prod").Rows(i).Item("CodigoProduto") - 3)))

                strSql = "UPDATE tblProdutosLojas SET CodigoProduto = " & CodPro & ", Obs='' WHERE IDLojaProduto = " & ds.Tables("prod").Rows(i).Item("IDLojaProduto")
                ExecutaStr(strSql)
            End If


        Next

    End Sub

    Public Function ScreenResolution() As String
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width

        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

        Return intX & " X " & intY

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        MainPosControle()

    End Sub
End Class