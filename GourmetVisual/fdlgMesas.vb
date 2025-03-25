Imports System.Data.SqlClient

Public Class fdlgMesas
    Private Sub PreencheMesas()
        Dim item As ListViewItem
        Dim con As New SqlConnection()
        Dim NMesas As Integer = 0
        Dim SeqMesas As Integer = 1

        strSql = "Select tblMesas.NumMesa, tblMesas.Status, tblMesas.Praca, tblMesas.IDSetor, tblSetores.Setor "
        strSql += "From tblMesas INNER Join tblSetores On tblMesas.IDSetor = tblSetores.IDSetor "
        strSql += "Order By tblMesas.NumMesa"

        lstMesas.Items.Clear()

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read()
                item = lstMesas.Items.Add(dr.Item("NumMesa"))

                If dr.Item("NumMesa") <> SeqMesas Then
                    item.ForeColor = Color.Red
                    SeqMesas = dr.Item("NumMesa")
                Else
                    item.ForeColor = Color.Blue
                End If

                If dr.Item("Status") = "M" Then
                    item.SubItems.Add("MESA")
                End If
                If dr.Item("Status") = "B" Then
                    item.SubItems.Add("BALCÃO")
                End If
                item.SubItems.Add(dr.Item("Setor"))
                If IsDBNull(dr.Item("Praca")) Then
                    item.SubItems.Add("")
                Else
                    item.SubItems.Add(UCase(dr.Item("Praca")))
                End If
                SeqMesas += 1
                NMesas += 1
            End While
            lstMesas.Update()
            lstMesas.EndUpdate()
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()
        lbTotal.Text = "Total de Mesas/Cartões: " & NMesas
    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Dados As New ArrayList()
        Dim conC As New SqlConnection()
        strSql = "Select IDSetor, Setor "
        strSql += "From tblSetores "
        strSql += "Order By Setor"

        Dim drC As SqlDataReader
        conC.ConnectionString = strCon
        Dim cmdC As SqlCommand = conC.CreateCommand
        cmdC.CommandText = strSql
        conC.Open()
        drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drC.HasRows Then
            Dados.Add("")
            While drC.Read()
                Dados.Add(drC.Item("Setor") & Space(100) & drC.Item("IDSetor"))
            End While
            cbSetor.DataSource = Dados
        End If
        Dados.Clear()
        drC.Close()
        cmdC.Dispose()
        conC.Dispose()
        conC.Close()



        Dim DadosP As New ArrayList()
        Dim conCP As New SqlConnection()

        strSql = "Select Praca From tblPracas Group By Praca Order By Praca"

        Dim drCP As SqlDataReader
        conCP.ConnectionString = strCon
        Dim cmdCP As SqlCommand = conCP.CreateCommand
        cmdCP.CommandText = strSql
        conCP.Open()
        drCP = cmdCP.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drCP.HasRows Then
            DadosP.Add("")
            While drCP.Read()
                DadosP.Add(drCP.Item("Praca"))
            End While
            cbPraca.DataSource = DadosP
        End If
        DadosP.Clear()
        drCP.Close()
        cmdCP.Dispose()
        conCP.Dispose()
        conCP.Close()



        Dim DadosT As New ArrayList()
        DadosT.Add("")
        DadosT.Add("MESA")
        DadosT.Add("BALCÃO")
        cbStatus.DataSource = DadosT
        DadosT.Clear()


        PreencheMesas()

    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        If tbDe.Text = "" Or tbAte.Text = "" Then
            MsgBox("Sequancia inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not IsNumeric(tbDe.Text) Then
            MsgBox("Valor inicial inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not IsNumeric(tbAte.Text) Then
            MsgBox("Valor final inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Val(tbDe.Text) > Val(tbAte.Text) Then
            MsgBox("Sequencia inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbSetor.Text = "" Then
            MsgBox("É necessário selecionar um setor", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbStatus.Text = "" Then
            MsgBox("É necessário selecionar um tipo", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim inicio As Integer = tbDe.Text
        Dim fim As Integer = tbAte.Text
        Dim Retorno As String = ""

        Do While inicio <= fim

            strSql = "Select NumMesa From tblMesas Where NumMesa =" & inicio
            Retorno = PegaValorCampo("NumMesa", strSql, strCon)
            If Retorno <> "" Then
                MsgBox(TextoMesaPAR & "  " & inicio & "  já cadastrado", MsgBoxStyle.Information)
            Else
                strSql = "INSERT tblMesas "
                strSql &= "(NumMesa, Status, IDSetor, Praca) VALUES ("
                strSql &= inicio & ", "
                If cbStatus.Text = "MESA" Then
                    strSql &= "'M', "
                End If
                If cbStatus.Text = "BALCÃO" Then
                    strSql &= "'B', "
                End If
                strSql &= Val(Strings.Right(cbSetor.Text, 8)) & ", "
                strSql &= "'" & NuloString(cbPraca.Text) & "')"
                ExecutaStr(strSql)
            End If
            inicio += 1
        Loop
        PreencheMesas()

        tbDe.Text = ""
        tbAte.Text = ""

    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If tbDe.Text = "" Or tbAte.Text = "" Then
            MsgBox("Sequancia inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not IsNumeric(tbDe.Text) Then
            MsgBox("Valor inicial inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not IsNumeric(tbAte.Text) Then
            MsgBox("Valor final inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Val(tbDe.Text) > Val(tbAte.Text) Then
            MsgBox("Sequencia inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbSetor.Text = "" Then
            MsgBox("É necessário selecionar um setor", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbStatus.Text = "" Then
            MsgBox("É necessário selecionar um tipo", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim inicio As Integer = tbDe.Text
        Dim fim As Integer = tbAte.Text
        Dim Retorno As String = ""

        Do While inicio <= fim
            strSql = "UPDATE tblMesas SET "
            strSql += "IDSetor=" & Val(Strings.Right(cbSetor.Text, 8)) & ", "
            If cbStatus.Text = "MESA" Then
                strSql += "Status='M', "
            End If
            If cbStatus.Text = "BALCÃO" Then
                strSql += "Status='B', "
            End If
            strSql += "Praca='" & NuloString(cbPraca.Text) & "' "
            strSql += "WHERE (NumMesa = " & inicio & ")"
            ExecutaStr(strSql)
            inicio += 1
        Loop

        PreencheMesas()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If tbDe.Text = "" Or tbAte.Text = "" Then
            MsgBox("Sequancia inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not IsNumeric(tbDe.Text) Then
            MsgBox("Valor inicial inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Not IsNumeric(tbAte.Text) Then
            MsgBox("Valor final inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Val(tbDe.Text) > Val(tbAte.Text) Then
            MsgBox("Sequencia inválida", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Deseja realmente excluir as mesas/cartões", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        strSql = "Delete From tblMesas WHERE (NumMesa >= " & tbDe.Text & ") AND (NumMesa <= " & tbAte.Text & ")"
        ExecutaStr(strSql)
        PreencheMesas()

        tbDe.Text = ""
        tbAte.Text = ""
        cbStatus.Text = ""
        cbSetor.Text = ""

    End Sub
End Class