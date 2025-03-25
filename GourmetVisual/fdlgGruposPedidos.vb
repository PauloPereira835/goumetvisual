Imports System.Data.SqlClient

Public Class fdlgGruposPedidos
    Private Sub MontaGrupos()

        strSql = "Select tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGruposPedidos.CodigoGrupo As CodigoGrupoPedidos "
        strSql += "From tblGrupos_Local LEFT OUTER Join tblGruposPedidos On tblGrupos_Local.CodigoGrupo = tblGruposPedidos.CodigoGrupo "
        strSql += "Where (tblGruposPedidos.CodigoGrupo Is NULL) "
        strSql += "Order By tblGrupos_Local.Grupo"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim item As ListViewItem
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstGrupos.Items.Clear()

        If dr.HasRows Then
            While dr.Read()
                item = lstGrupos.Items.Add(dr.Item("CodigoGrupo"))
                item.SubItems.Add(dr.Item("Grupo"))
            End While
        End If

    End Sub
    Private Sub MontaGruposSelecionados()

        strSql = "Select tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGruposPedidos.CodigoGrupo As CodigoGrupoPedidos "
        strSql += "From tblGrupos_Local INNER Join tblGruposPedidos On tblGrupos_Local.CodigoGrupo = tblGruposPedidos.CodigoGrupo "
        strSql += "Order By tblGrupos_Local.Grupo"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim item As ListViewItem
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstGruposSelecionados.Items.Clear()

        If dr.HasRows Then
            While dr.Read()
                item = lstGruposSelecionados.Items.Add(dr.Item("CodigoGrupo"))
                item.SubItems.Add(dr.Item("Grupo"))
            End While
        End If

    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgGruposPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MontaGrupos()
        MontaGruposSelecionados()

    End Sub

    Private Sub btnSeleciona_Click(sender As Object, e As EventArgs) Handles btnSeleciona.Click

        strSql = "INSERT tblGruposPedidos (CodigoGrupo) VALUES ("
        strSql &= to_sql(NuloInteger(lstGrupos.SelectedItems(0).SubItems(0).Text)) & ")"
        ExecutaStr(strSql)

        MontaGrupos()
        MontaGruposSelecionados()

    End Sub

    Private Sub btnExclui_Click(sender As Object, e As EventArgs) Handles btnExclui.Click

        ExecutaStr("DELETE FROM tblGruposPedidos WHERE (CodigoGrupo = " & lstGruposSelecionados.SelectedItems(0).SubItems(0).Text & ")")
        MontaGrupos()
        MontaGruposSelecionados()

    End Sub
End Class