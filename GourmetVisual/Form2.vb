Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.IO
Imports DLL_Sat


Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '' Mensagem BOX ////////////////////////////////////////////////////////
        'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        'frm.lbMensagem.Text = "Teste OK Sim/não"
        'frm.btnNao.Visible = True
        'frm.btnSim.Visible = True
        'frm.btnOK.Visible = False
        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        ''frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        'frm.ShowDialog()


        'Dim DLL As New DLL_Sat.DLL_Sat.Teste
        'Dim msg As String = DLL.ToString
        MsgBox(InStr(TextBox1.Text, "COM"))


        'IsValidaCNPJ(TextBox1.Text)


        'PrintDocument1.PrinterSettings.PrinterName = "Serial"
        'PrintDocument1.Print()
        'ClassPrint.RawPrinterHelper.SendFileToPrinter("Serial", "C:\IRIS_Gestao\GourmetVisual\dados.txt")
        ' ClassPrint.RawPrinterHelper.SendStringToPrinter("Serial", Chr(27) & Chr(109))

    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint

        'e.PrintAction.PrintToPre

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage







        Dim fluxoTexto As IO.StreamReader
        Dim linhaTexto As String
        Dim Linha As Integer = 0

        If IO.File.Exists("C:\IRIS_Gestao\GourmetVisual\dados.txt") Then
            fluxoTexto = New IO.StreamReader("C:\IRIS_Gestao\GourmetVisual\dados.txt")
            linhaTexto = fluxoTexto.ReadLine

            While linhaTexto <> Nothing
                'txtLinhas.Text &= linhaTexto & vbCrLf
                linhaTexto = fluxoTexto.ReadLine
                'e.Graphics.DrawString(linhaTexto, New Font("arial", 12), Brushes.Black, 0, Linha)
                e.Graphics.DrawString(linhaTexto, New Font("arial", 12), Brushes.Black, 0, Linha, New StringFormat())
                Linha += 15
            End While
            fluxoTexto.Close()
        Else
            MessageBox.Show("Arquivo não existe")
        End If


        'ClassPrint.RawPrinterHelper.SendStringToPrinter("Serial", Chr(&H1D) & "V" & Chr(66) & Chr(0))



    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub







End Class