'Imports System.Security.Cryptography
'Imports System.IO
Imports System.Text

Module ArquivoINI
    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Public Function LeArquivoINI(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String

        Const MAX_LENGTH As Integer = 500
        Dim string_builder As New StringBuilder(MAX_LENGTH)

        GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)

        Return string_builder.ToString()

    End Function

    Public Function EscreveINI(ByVal Sessao As String, ByVal Campo As String, ByVal Dado As String, ByVal Arquivo As String) As Boolean
        Dim retorno As Boolean = False

        WritePrivateProfileString(Sessao, Campo, Dado, Arquivo)

        Return retorno
    End Function
End Module