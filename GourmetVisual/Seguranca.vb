Imports System.Management
Module Seguranca

    Public mo_HD As ManagementObject

    Function DiscoInfo(ByVal strDrive As String) As ManagementObject
        'Verifica se a letra do drive foi informada. O padrão é a letra C
        If strDrive = "" OrElse strDrive Is Nothing Then
            strDrive = "C"
        End If
        Try
            'Usa Win32_LogicalDisk para obter as propriedades do HD
            Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + strDrive + ":""")
            Return moHD
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function NumeroSerial(ByVal strDrive As String) As String
        'Public Shared Function NumeroSerial(ByVal strDrive As String) As String
        Try
            mo_HD = DiscoInfo(strDrive)
            mo_HD.Get()
            'Pega o Serial
            Return mo_HD("VolumeSerialNumber").ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function

End Module
