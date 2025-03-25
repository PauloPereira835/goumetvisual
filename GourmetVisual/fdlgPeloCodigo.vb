Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class fdlgPeloCodigo
    Public IDCate As Integer = 0
    Public IDFam As Integer = 0
    Public VlrPreco As Decimal = 0
    Public CodProduto As Integer = 0

    Private Sub PreencheProduto()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)
        Dim item As ListViewItem

        strSql = "Select Produto, CodigoProduto, Venda From tblProdutos_Local "
        If tbBusca.Text <> "" Then
            If Not IsNumeric(tbBusca.Text) Then
                strSql += "WHERE (Produto LIKE '%" & tbBusca.Text & "%') "
            Else
                strSql += "WHERE (CodigoProduto LIKE '" & tbBusca.Text & "%') "
            End If
        End If
        strSql += "Order By Produto"

        lsvProdutos.Items.Clear()

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While (dr.Read())
                item = lsvProdutos.Items.Add(NuloString(dr.Item("Produto")))
                item.SubItems.Add(NuloString(dr.Item("CodigoProduto")))
                item.SubItems.Add(NuloString(Format(dr.Item("Venda"), "#0.00")))
            End While
        End If
        comandoLJS.Dispose()
        con.Dispose()
        con.Close()


    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        CliqueNoBotao("1")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        CliqueNoBotao("2")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CliqueNoBotao("3")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CliqueNoBotao("4")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CliqueNoBotao("5")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CliqueNoBotao("6")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CliqueNoBotao("9")
    End Sub


    Private Sub fdlgPeloCodigo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        'PreencheProduto()

    End Sub

    Private Sub CliqueNoBotao(valor As String)
        With tbBusca
            .Text &= valor
            .Focus()
        End With
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheProduto()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        CliqueNoBotao("Q")
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        CliqueNoBotao("W")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CliqueNoBotao("E")
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        CliqueNoBotao("R")
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        CliqueNoBotao("T")
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CliqueNoBotao("Y")
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        CliqueNoBotao("U")
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        CliqueNoBotao("I")
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        CliqueNoBotao("O")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CliqueNoBotao("P")
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        CliqueNoBotao("A")
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        CliqueNoBotao("S")
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        CliqueNoBotao("D")
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        CliqueNoBotao("F")
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        CliqueNoBotao("G")
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        CliqueNoBotao("H")
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        CliqueNoBotao("J")
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        CliqueNoBotao("K")
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        CliqueNoBotao("L")
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        CliqueNoBotao("Z")
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        CliqueNoBotao("X")
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        CliqueNoBotao("C")
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        CliqueNoBotao("V")
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        CliqueNoBotao("B")
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        CliqueNoBotao("N")
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        CliqueNoBotao("M")
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        CliqueNoBotao("/")
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        CliqueNoBotao(" ")
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        tbBusca.Text = ""
    End Sub

    Private Sub FdlgPeloCodigo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fdlgPeloCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select
    End Sub

    Private Sub LsvProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProdutos.SelectedIndexChanged

    End Sub

    Private Sub lsvProdutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lsvProdutos.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            CodigoProdutoBusca = 0
            If lsvProdutos.SelectedItems.Count > 0 Then
                For i As Integer = 0 To lsvProdutos.Items.Count - 1
                    If lsvProdutos.Items(i).Selected = True Then
                        CodigoProdutoBusca = NuloInteger(lsvProdutos.Items(i).SubItems(1).Text)
                        Exit For
                    End If
                Next i

                If CodigoProdutoBusca <> 0 Then
                    Me.Dispose()
                    Me.Close()
                End If
            End If

        End If
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        CodigoProdutoBusca = 0
        If lsvProdutos.SelectedItems.Count > 0 Then
            For i As Integer = 0 To lsvProdutos.Items.Count - 1
                If lsvProdutos.Items(i).Selected = True Then
                    CodigoProdutoBusca = NuloInteger(lsvProdutos.Items(i).SubItems(1).Text)
                End If
            Next i

            If CodigoProdutoBusca <> 0 Then
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        CodigoProdutoBusca = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub tbBusca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBusca.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            lsvProdutos.Focus()
        End If

    End Sub

    Private Sub lsvProdutos_DoubleClick(sender As Object, e As EventArgs) Handles lsvProdutos.DoubleClick
        CodigoProdutoBusca = 0
        If lsvProdutos.SelectedItems.Count > 0 Then
            For i As Integer = 0 To lsvProdutos.Items.Count - 1
                If lsvProdutos.Items(i).Selected = True Then
                    CodigoProdutoBusca = NuloInteger(lsvProdutos.Items(i).SubItems(1).Text)
                End If
            Next i

            If CodigoProdutoBusca <> 0 Then
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub
End Class