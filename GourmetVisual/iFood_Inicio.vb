Imports System.IO
Module iFood_Inicio
    Sub Main()

        If Not System.IO.File.Exists("token.txt") Then
            Dim fs As FileStream = File.Create("token.txt")
            fs.Close()
        End If

        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("token.txt", System.Text.Encoding.UTF32)
        If (fileReader = "") Then
            appIfoodMerchant.PegaUserCode_iFood()
            Console.WriteLine("Acesse o portal e insira o código abaixo:")
            Console.WriteLine(appIfoodMerchant.usercode_accessIfood)
            Console.WriteLine(appIfoodMerchant.verificationUrlComplete)

            Try
                Dim psi As New ProcessStartInfo("chrome.exe")
                psi.Arguments = appIfoodMerchant.verificationUrlComplete
                Process.Start(psi)
            Catch ex As Exception

            End Try

            Console.WriteLine("Didite o código recebido no portal")
            Dim code = Console.ReadLine()
            appIfoodMerchant.authorizationCode = code

            appIfoodMerchant.PegaToken_iFood()
            Console.WriteLine(appIfoodMerchant.tokenAccessIfood)
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("token.txt", True)
            file.WriteLine(appIfoodMerchant.tokenAccessIfood)
            file.Close()
        Else
            appIfoodMerchant.tokenAccessIfood = fileReader
        End If
        appIfoodMerchant.VerificaPedidos_Ifood()

        Console.ReadKey()


    End Sub
End Module
