Imports System.Data.SqlClient

Public Class fdlgPracas
    Private Sub PreenchelstLista()
        Dim item As ListViewItem
        Dim con As New SqlConnection()
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblPracas.IDPraca, tblPracas.Praca, tblPracas.IDFuncionario, tblFuncionarios_Local.Funcionario "
        strSql += "From tblPracas INNER Join tblFuncionarios_Local On tblPracas.IDFuncionario = tblFuncionarios_Local.IDFuncionario "
        strSql += "Order By tblPracas.Praca, tblFuncionarios_Local.Funcionario"

        cmd.CommandText = strSql

        lstPracas.Items.Clear()

        con.Open()
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            Do While dr.Read()
                item = lstPracas.Items.Add(dr.Item("IDPraca"))
                item.SubItems.Add(dr.Item("Praca"))
                item.SubItems.Add(dr.Item("Funcionario"))
                item.SubItems.Add(dr.Item("IDFuncionario"))
            Loop
        End If
        dr.Close()
        cmd.Dispose()
        con.Close()

    End Sub
    Private Sub PreencheFuncionarios()
        Dim Dados As New ArrayList()
        Dim conC As New SqlConnection()
        strSql = "Select IDFuncionario, Funcionario "
        strSql += "From tblFuncionarios_Local "
        strSql += "Order By Funcionario"

        Dim drC As SqlDataReader
        conC.ConnectionString = strCon
        Dim cmdC As SqlCommand = conC.CreateCommand
        cmdC.CommandText = strSql
        conC.Open()
        drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drC.HasRows Then
            Dados.Add("")
            While drC.Read()
                Dados.Add(drC.Item("Funcionario") & Space(100) & drC.Item("IDFuncionario"))
            End While
            cbFuncionarios.DataSource = Dados
        End If
        Dados.Clear()
        drC.Close()
        cmdC.Dispose()
        conC.Dispose()
        conC.Close()
    End Sub
    Private Sub FdlgPracas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheFuncionarios()
        PreenchelstLista()
    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub LstPracas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPracas.SelectedIndexChanged

    End Sub

    Private Sub lstPracas_Click(sender As Object, e As EventArgs) Handles lstPracas.Click
        If lstPracas.SelectedItems.Count > 0 Then

            tbIDPraca.Text = NuloInteger(lstPracas.SelectedItems(0).SubItems(0).Text)
            tbIDFuncionario.Text = NuloInteger(lstPracas.SelectedItems(0).SubItems(3).Text)
            tbPraca.Text = NuloString(lstPracas.SelectedItems(0).SubItems(1).Text)

            Dim Sel As String
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            For I = 1 To cbFuncionarios.Items.Count
                cbFuncionarios.SelectedIndex = ItemSel
                Sel = Val(Trim(Strings.Right(cbFuncionarios.Text, 10)))
                cbFuncionarios.SelectedIndex = ItemSel
                If Sel = lstPracas.SelectedItems(0).SubItems(3).Text Then
                    I = 9999
                End If
                ItemSel += 1
            Next



        End If
    End Sub

    Private Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click

        If NuloString(tbPraca.Text) = "" Then
            MsgBox("Praça inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If NuloString(cbFuncionarios.Text) = "" Then
            MsgBox("Funcionário inválido", MsgBoxStyle.Information)
            Exit Sub
        End If


        strSql = "SELECT Praca FROM tblPracas WHERE (Praca=" & tbPraca.Text & ") AND (IDFuncionario=" & NuloInteger(Strings.Right(cbFuncionarios.Text, 8)) & ")"
        If NuloString(PegaValorCampo("Praca", strSql, strCon)) <> "" Then
            MsgBox("Funcionário ja cadastrado nesta praça", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Deseja incluir a praça " & tbPraca.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        strSql = "INSERT tblPracas "
        strSql += "(Praca, IDFuncionario) VALUES ("
        strSql += tbPraca.Text & ", "
        strSql += Val(NuloInteger(Strings.Right(cbFuncionarios.Text, 8))) & ")"
        ExecutaStr(strSql)
        PreenchelstLista()

    End Sub

    Private Sub BtnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click

        If NuloString(tbPraca.Text) = "" Then
            MsgBox("Praça inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If NuloString(cbFuncionarios.Text) = "" Then
            MsgBox("Funcionário inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If NuloInteger(tbIDPraca.Text) = 0 Then
            MsgBox("Praça inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        strSql = "SELECT Praca FROM tblPracas WHERE (Praca=" & tbPraca.Text & ") AND (IDFuncionario=" & NuloInteger(Strings.Right(cbFuncionarios.Text, 8)) & ")"
        If NuloString(PegaValorCampo("Praca", strSql, strCon)) <> "" Then
            MsgBox("Funcionário ja cadastrado nesta praça", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Deseja alterar a praça " & tbPraca.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        strSql = "UPDATE tblPracas SET "
        strSql += "IDFuncionario=" & Val(Strings.Right(cbFuncionarios.Text, 8)) & ", "
        strSql += "Praca='" & tbPraca.Text & "' "
        strSql += "WHERE (IDPraca = " & Val(tbIDPraca.Text) & ")"
        ExecutaStr(strSql)
        PreenchelstLista()

    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click


        If NuloString(tbPraca.Text) = "" Then
            MsgBox("Praça inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If NuloString(cbFuncionarios.Text) = "" Then
            MsgBox("Funcionário inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If NuloInteger(tbIDPraca.Text) = 0 Then
            MsgBox("Praça inválida", MsgBoxStyle.Information)
            Exit Sub
        End If


        strSql = "Delete From tblPracas WHERE (IDPraca= " & Val(tbIDPraca.Text) & ")"
        ExecutaStr(strSql)
        PreenchelstLista()

    End Sub
End Class