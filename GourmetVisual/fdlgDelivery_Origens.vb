Imports System.Data.SqlClient

Public Class fdlgDelivery_Origens
    Private Sub PreencheLista()

        strSql = "SELECT Origem FROM tblOrigens ORDER BY Origem"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Tipos As New ArrayList()
        With dr
            If .HasRows Then
                While (.Read())
                    Tipos.Add(.GetString(0))
                End While
                lstOrigens.DataSource = Tipos
                lstOrigens.SelectedIndex = 0
            End If

            .Close()
        End With
        cmd.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub fdlgDelivery_Origens_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheLista()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbOrigem.Text <> "" Then
            strSql = "DELETE From tblOrigens WHERE (Origem='" & UCase(tbOrigem.Text) & "')"
            ExecutaStr(strSql)
            PreencheLista()
            tbOrigem.Text = ""

        Else
            MsgBox("Origem inválida", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        If tbOrigem.Text <> "" Then

            Dim IDSel As String
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            Dim NovaFam As String = UCase(tbOrigem.Text)

            For I = 1 To lstOrigens.Items.Count - 1
                lstOrigens.SelectedIndex = ItemSel
                IDSel = lstOrigens.Items(I)
                lstOrigens.SelectedIndex = ItemSel
                If IDSel = NovaFam Then
                    I = 9999
                End If
                ItemSel += 1
            Next

            If I < 9999 Then
                Dim strSql As String
                Dim conInsert As New SqlConnection(strCon)

                strSql = "INSERT tblOrigens (Origem) VALUES ('" & UCase(NovaFam) & "')"
                ExecutaStr(strSql)
                PreencheLista()
                tbOrigem.Text = ""

            Else
                MsgBox("Origem já cadastrada", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Origem inválida", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub lstOrigens_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrigens.SelectedIndexChanged
        tbOrigem.Text = Trim(lstOrigens.Text)
    End Sub
End Class