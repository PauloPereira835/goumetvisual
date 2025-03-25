Imports System.Data.SqlClient

Public Class fdlgMensagensInclusao
    Private Sub PreencheLista()
        Dim strSql As String
        strSql = "SELECT Mensagem FROM tblMensagens ORDER BY Mensagem"

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
                lstMensagens.DataSource = Tipos
                lstMensagens.SelectedIndex = 0
            End If

            .Close()
        End With
        cmd.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub fdlgMensagensInclusao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheLista()
    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click
        If tbMensagem.Text <> "" Then

            Dim IDSel As String
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            Dim NovaFam As String = UCase(tbMensagem.Text)

            For I = 1 To lstMensagens.Items.Count
                lstMensagens.SelectedIndex = ItemSel
                IDSel = Trim(Strings.Left(lstMensagens.Text, 50))
                lstMensagens.SelectedIndex = ItemSel
                If IDSel = NovaFam Then
                    I = 9999
                End If
                ItemSel += 1
            Next

            If I < 9999 Then
                Dim strSql As String
                Dim conInsert As New SqlConnection(strCon)

                strSql = "INSERT tblMensagens (Mensagem) VALUES ('" & UCase(NovaFam) & "')"
                ExecutaStr(strSql)
                PreencheLista()
                tbMensagem.Text = ""
            Else
                MsgBox("Mensagem já cadastrada", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Mensagem inválida", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbMensagem.Text <> "" Then
            strSql = "DELETE From tblMensagens WHERE (Mensagem='" & UCase(tbMensagem.Text) & "')"
            ExecutaStr(strSql)
            PreencheLista()
            tbMensagem.Text = ""
        Else
            MsgBox("Mensagem inválida", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub lstMensagens_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMensagens.SelectedIndexChanged
        tbMensagem.Text = Trim(lstMensagens.Text)
    End Sub
End Class