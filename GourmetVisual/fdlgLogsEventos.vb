Imports System.Data.SqlClient

Public Class fdlgLogsEventos
    Private Sub PreencheOperador()
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select Operador "
        strSql += "From tblLogsEventosGV "
        strSql += "WHERE (DataDia BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        strSql += "Group By Operador "
        strSql += "Order By Operador"

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbOperador.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbOperador.Items.Add("")
            While (dr.Read)
                cbOperador.Items.Add(NuloString(dr.Item("Operador")))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheTerminais()
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select Terminal "
        strSql += "From tblLogsEventosGV "
        strSql += "WHERE (DataDia BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        strSql += "Group By Terminal "
        strSql += "Order By Terminal"

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbTerminal.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbTerminal.Items.Add("")
            While (dr.Read)
                cbTerminal.Items.Add(NuloString(dr.Item("Terminal")))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheAcao()
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select Acao "
        strSql += "From tblLogsEventosGV "
        strSql += "WHERE (DataDia BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        strSql += "Group By Acao "
        strSql += "Order By Acao"

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbAcao.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbAcao.Items.Add("")
            While (dr.Read)
                cbAcao.Items.Add(NuloString(dr.Item("Acao")))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

    End Sub
    Private Sub PreenchaLogs()
        Dim item As ListViewItem
        Dim Qtde As Integer = 0
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select IDLog, Terminal, Operador, DataHora, Acao, Descricao "
        strSql += "From tblLogsEventosGV "
        strSql += "WHERE (DataDia BETWEEN '" & Format(dtInicio.Value, FormatoDataLocal) & "' AND '" & Format(dtFim.Value, FormatoDataLocal) & "') "
        If cbAcao.Text <> "" Then
            strSql += " AND (Acao='" & cbAcao.Text & "') "
        End If
        If cbOperador.Text <> "" Then
            strSql += " AND (Operador='" & cbOperador.Text & "') "
        End If
        If cbTerminal.Text <> "" Then
            strSql += " AND (Terminal='" & cbTerminal.Text & "') "
        End If
        strSql += "Order By DataHora Desc"

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        lstLogs.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                item = lstLogs.Items.Add(dr.Item("IDLog"))
                item.SubItems.Add(NuloString(dr.Item("Terminal")))
                item.SubItems.Add(NuloString(dr.Item("Operador")))
                item.SubItems.Add(NuloString(dr.Item("DataHora")))
                item.SubItems.Add(NuloString(dr.Item("Acao")))
                item.SubItems.Add(NuloString(dr.Item("Descricao")))
                Qtde += 1
            End While
            lstLogs.Update()
            lstLogs.EndUpdate()
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
        lbQTde.Text = "Qtde de ocorrencias: " & Qtde


    End Sub
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgLogsEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtInicio.Value = Now.AddDays(-DatePart(DateInterval.Day, Today) + 1)
        dtFim.Value = Now
        PreenchaLogs()

        strSql = "Select PeriodoLog FROM tblConfig"
        Dim PeriodoLog As String = NuloString(PegaValorCampo("PeriodoLog", strSql, strCon))
        cbManterLog.Items.Add("3 MESES")
        cbManterLog.Items.Add("6 MESES")
        cbManterLog.Items.Add("1 ANO")

        If PeriodoLog <> "" Then
            cbManterLog.Text = PeriodoLog
        Else
            strSql = "UPDATE tblConfig SET PeriodoLog='3 MESES'"
            ExecutaStr(strSql)
            cbManterLog.Text = "3 MESES"
        End If
        cbManterLog.Refresh()

    End Sub

    Private Sub DtInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio.ValueChanged
        PreenchaLogs()
        PreencheAcao()
        PreencheOperador()
        PreencheTerminais()
    End Sub

    Private Sub DtFim_ValueChanged(sender As Object, e As EventArgs) Handles dtFim.ValueChanged
        PreenchaLogs()
        PreencheAcao()
        PreencheOperador()
        PreencheTerminais()
    End Sub

    Private Sub CbManterLog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbManterLog.SelectedIndexChanged
        strSql = "UPDATE tblConfig SET PeriodoLog='" & NuloString(cbManterLog.Text) & "'"
        ExecutaStr(strSql)

    End Sub

    Private Sub CbAcao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAcao.SelectedIndexChanged
        PreenchaLogs()
    End Sub

    Private Sub CbTerminal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTerminal.SelectedIndexChanged
        PreenchaLogs()
    End Sub

    Private Sub CbOperador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOperador.SelectedIndexChanged
        PreenchaLogs()
    End Sub
End Class