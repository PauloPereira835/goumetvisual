Option Explicit On

Module Balanca

    Declare Function PegaPeso Lib "P05.DLL" (ByVal OpcaoEscrita As Integer, ByVal Peso As String, ByVal Diretorio As String) As Integer
    Declare Function AbrePorta Lib "P05.DLL" (ByVal Porta As Integer, ByVal BaudRate As Integer, ByVal DataBits As Integer, ByVal Paridade As Integer) As Integer
    Declare Function FechaPortaBalanca Lib "P05.DLL" () As Integer
    Declare Function FechaPortaP05 Lib "P05.DLL" () As Integer
    Declare Sub VersaoDLLBalanca Lib "P05.DLL" (ByVal Versao As String)
    Declare Function DeterminaUmStopBit Lib "P05.DLL" () As Integer

End Module
