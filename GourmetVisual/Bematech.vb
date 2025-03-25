Imports System.Runtime.InteropServices
Module Bematech

    ''' <summary>
    ''' Esta função tem por objetivo abrir a porta de comunicação, onde a impressora está conectada
    ''' </summary>
    ''' <param name="porta">STRING nome da porta de comunicação</param>
    ''' <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
    <DllImport("MP2032.dll")>
    Public Function IniciaPorta(ByVal porta As [String]) As Integer
    End Function
    ''' <summary>
    ''' Esta função tem por objetivo fechar a porta de comunicação, liberando a porta para outras atividades.
    ''' </summary>
    ''' <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
    <DllImport("MP2032.dll")>
    Public Function FechaPorta() As Integer
    End Function
    ''' <summary>
    ''' Imprime QR Code
    ''' </summary>
    <DllImport("MP2032.dll")>
    Public Function ImprimeCodigoQRCODE(ByVal errorCorrectionLevel As Integer, ByVal moduleSize As Integer, ByVal codeType As Integer, ByVal QRCodeVersion As Integer, ByVal encodingModes As Integer, ByVal codeQr As String) As Integer
    End Function
    ''' <summary>
    ''' Esta função tem por objetivo enviar textos para a impressora, com formatações, informadas pelos parâmetros.
    ''' </summary>
    ''' <param name="texto">STRING texto a ser impresso.</param>
    ''' <param name="TipoLetra">INTEIRO sendo 1 = comprimido, 2 = normal, 3 = elite</param>
    ''' <param name="italico">INTEIRO  0 = desativa modo, 1 = ativa modo.</param>
    ''' <param name="sublinhado">INTEIRO 0 = desativa modo, 1 = ativa modo.</param>
    ''' <param name="expandido">INTEIRO 0 = desativa modo, 1 = ativa modo.</param>
    ''' <param name="enfatizado">INTEIRO 0 = desativa modo, 1 = ativa modo.</param>
    ''' <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
    <DllImport("MP2032.dll")>
    Public Function FormataTX(ByVal texto As [String], ByVal TipoLetra As Integer, ByVal italico As Integer, ByVal sublinhado As Integer, ByVal expandido As Integer, ByVal enfatizado As Integer) As Integer
    End Function
    ''' <summary>
    ''' Reset da impressora
    ''' </summary>
    ''' <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
    <DllImport("MP2032.dll")>
    Public Function PrinterReset() As Integer
    End Function
    ''' <summary>
    ''' Impressão de textos, enviando um conjunto com várias linhas.
    ''' </summary>
    ''' <param name="texto">STRING Texto a ser impresso</param>
    ''' <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
    <DllImport("MP2032.dll")>
    Public Function BematechTX(ByVal texto As [String]) As Integer
    End Function
    ''' <summary>
    ''' Aciona a guilhotina, cortando o papel em modo parcial ou total.
    ''' </summary>
    ''' <param name="parcial_full">INTEIRA 0 = acionamento parcial, 1 = acionamento total.</param>
    ''' <returns>INTEIRO - Indica se a função conseguiu enviar o comando para impressora.</returns>
    <DllImport("MP2032.dll")>
    Public Function AcionaGuilhotina(ByVal parcial_full As Integer) As Integer
    End Function
End Module
