Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class fdlgSetores
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub PreencheListaImpressoras()
        Dim item As ListViewItem

        strSql = "SELECT IDSetorImpressora,IDSetor,IDCategoria,Impressora,Guilhotina,Modulo FROM tblSetoresImpressoras "
        strSql += "Where (IDSetor = " & Val(tbIDSetor.Text) & ") "
        If rbtnSalao.Checked = True Then
            strSql += "AND (Modulo = 'S') "
        End If
        If rbtnBalcao.Checked = True Then
            strSql += "AND (Modulo = 'B') "
        End If
        If rbtnDelivery.Checked = True Then
            strSql += "AND (Modulo = 'D') "
        End If
        strSql += "ORDER BY Modulo, IDCategoria"

        lstImpressoras.Items.Clear()

        Dim conI As New SqlConnection()
        Dim drI As SqlDataReader
        conI.ConnectionString = strCon
        Dim cmdI As SqlCommand = conI.CreateCommand
        cmdI.CommandText = strSql
        conI.Open()
        drI = cmdI.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drI.HasRows Then
            While drI.Read()
                item = lstImpressoras.Items.Add(drI.Item("IDSetorImpressora"))
                item.SubItems.Add(UCase(drI.Item("IDSetor")))
                item.SubItems.Add(drI.Item("IDCategoria"))
                item.SubItems.Add(drI.Item("Impressora"))
                If IsDBNull(drI.Item("Guilhotina")) Then
                    item.SubItems.Add("Não")
                Else
                    If drI.Item("Guilhotina") = True Then
                        item.SubItems.Add("Sim")
                    Else
                        item.SubItems.Add("Não")
                    End If
                End If
                If drI.Item("Modulo") = "S" Then
                    item.SubItems.Add("Salão")
                Else
                    If drI.Item("Modulo") = "B" Then
                        item.SubItems.Add("Balcão")
                    Else
                        item.SubItems.Add("Delivery")
                    End If
                End If
                strSql = "SELECT IDCategoria, Categoria FROM tblCategorias_Local Where IDCategoria=" & drI.Item("IDCategoria")
                item.SubItems.Add(Trim(PegaValorCampo("Categoria", strSql, strCon)))

            End While
            lstSetores.Update()
            lstSetores.EndUpdate()
        End If
        drI.Close()
        cmdI.Dispose()
        conI.Dispose()
        conI.Close()
    End Sub
    Private Sub PreencheListaSetores()
        Dim item As ListViewItem
        Dim con As New SqlConnection()
        strSql = "Select IDSetor, Setor, ImpressoraConta FROM tblSetores ORDER BY Setor"

        lstSetores.Items.Clear()

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While dr.Read()
                item = lstSetores.Items.Add(dr.Item("IDSetor"))
                item.SubItems.Add(UCase(dr.Item("Setor")))
                item.SubItems.Add(dr.Item("ImpressoraConta"))
            End While
            lstSetores.Update()
            lstSetores.EndUpdate()
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub fdlgSetores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim v_total, v_cont, v_item As Integer
        Dim pd As PrintDocument = New PrintDocument
        Try
            cbImpressoraCategoria.Items.Add("")
            cbImpressoraConta.Items.Add("")

            v_total = pd.PrinterSettings.InstalledPrinters.Count
            With pd.PrinterSettings.InstalledPrinters
                For v_cont = 0 To v_total - 1
                    cbImpressoraCategoria.Items.Add(.Item(v_cont))
                    cbImpressoraConta.Items.Add(.Item(v_cont))
                Next
            End With
            cbImpressoraCategoria.SelectedIndex = (v_item)
            cbImpressoraConta.SelectedIndex = (v_item)

        Catch ex As Exception
            MessageBox.Show("Erro de Impressão " + ex.Message)
        Finally
            pd.Dispose()
        End Try



        Dim Dados As New ArrayList()
        Dim conC As New SqlConnection()
        strSql = "Select IDCategoria, Categoria "
        strSql += "From tblCategorias_Local "
        strSql += "Order By Categoria"

        Dim drC As SqlDataReader
        conC.ConnectionString = strCon
        Dim cmdC As SqlCommand = conC.CreateCommand
        cmdC.CommandText = strSql
        conC.Open()
        drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drC.HasRows Then
            Dados.Add("")
            While drC.Read()
                Dados.Add(drC.Item("Categoria") & Space(100) & drC.Item("IDCategoria"))
            End While
            cbCategoria.DataSource = Dados
        End If
        Dados.Clear()
        drC.Close()
        cmdC.Dispose()
        conC.Dispose()
        conC.Close()

        Dim DadosM As New ArrayList()
        DadosM.Add("")
        DadosM.Add("Salão")
        DadosM.Add("Balcão")
        DadosM.Add("Delivery")
        cbModulo.DataSource = DadosM

        rbtnTodos.Checked = True

        PreencheListaSetores()
    End Sub

    Private Sub btnIncluiSetor_Click(sender As Object, e As EventArgs) Handles btnIncluiSetor.Click
        If tbSetor.Text = "" Then
            MsgBox("Setor inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbImpressoraConta.Text = "" Then
            MsgBox("Impressora inválido", MsgBoxStyle.Information)
            Exit Sub
        End If

        strSql = "Select Setor From tblSetores Where Setor ='" & tbSetor.Text & "'"
        If NuloString(PegaValorCampo("Setor", strSql, strCon)) <> "" Then
            MsgBox("Setor já cadastrado", MsgBoxStyle.Information)
            Exit Sub
        End If

        strSql = "INSERT tblSetores "
        strSql &= "(Setor, ImpressoraConta) VALUES ("
        strSql &= "'" & UCase(tbSetor.Text) & "',"
        strSql &= "'" & cbImpressoraConta.Text & "')"
        Dim conAtu As New SqlConnection(strCon)
        Dim cmdAtu As New SqlCommand(strSql, conAtu)
        conAtu.Open()
        cmdAtu.CommandType = CommandType.Text
        cmdAtu.ExecuteNonQuery()
        cmdAtu.Dispose()
        conAtu.Dispose()
        conAtu.Close()

        PreencheListaSetores()
        PreencheListaImpressoras()

        cbImpressoraConta.Text = ""
        tbSetor.Text = ""
        tbIDSetor.Text = ""
        PanelImpressoras.Enabled = False
    End Sub

    Private Sub btnExcluiSetor_Click(sender As Object, e As EventArgs) Handles btnExcluiSetor.Click
        If tbSetor.Text = "" Then
            MsgBox("Setor inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Confirma a exclusão do setor " & tbSetor.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        strSql = "Delete From tblSetores WHERE (IDSetor = " & Val(tbIDSetor.Text) & ")"
        ExecutaStr(strSql)
        strSql = "Delete From tblSetoresImpressoras WHERE (IDSetor = " & Val(tbIDSetor.Text) & ")"
        ExecutaStr(strSql)


        PreencheListaSetores()
        PreencheListaImpressoras()

        cbImpressoraConta.Text = ""
        tbSetor.Text = ""
        tbIDSetor.Text = ""
        PanelImpressoras.Enabled = False
    End Sub

    Private Sub btnGravaSetor_Click(sender As Object, e As EventArgs) Handles btnGravaSetor.Click
        If tbSetor.Text = "" Then
            MsgBox("Setor inválido", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Deseja alterar o setor " & tbSetor.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        strSql = "UPDATE tblSetores SET "
        strSql += "Setor='" & UCase(tbSetor.Text) & "', "
        strSql += "ImpressoraConta='" & cbImpressoraConta.Text & "' "
        strSql += "WHERE (IDSetor = " & Val(tbIDSetor.Text) & ")"
        ExecutaStr(strSql)

        PreencheListaSetores()
        PreencheListaImpressoras()

        cbImpressoraConta.Text = ""
        tbSetor.Text = ""
        tbIDSetor.Text = ""
        PanelImpressoras.Enabled = False
    End Sub

    Private Sub lstSetores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSetores.SelectedIndexChanged
        If lstSetores.SelectedItems.Count > 0 Then
            tbIDSetor.Text = lstSetores.SelectedItems(0).Text
            tbSetor.Text = lstSetores.SelectedItems(0).SubItems(1).Text
            cbImpressoraConta.Text = lstSetores.SelectedItems(0).SubItems(2).Text
            PanelImpressoras.Enabled = True
            PreencheListaImpressoras()
        End If
    End Sub

    Private Sub btnIncluiImpressora_Click(sender As Object, e As EventArgs) Handles btnIncluiImpressora.Click

        If tbSetor.Text = "" Then
            MsgBox("É necessário selecionar um Setor", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbImpressoraCategoria.Text = "" Then
            MsgBox("Impressora inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbCategoria.Text = "" Then
            MsgBox("Categoria inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cbModulo.Text = "" Then
            MsgBox("Módulo inválido", MsgBoxStyle.Information)
            Exit Sub
        End If

        strSql = "INSERT tblSetoresImpressoras "
        strSql += "(IDSetor, IDCategoria, Impressora, Guilhotina, Modulo) VALUES ("
        strSql += Val(tbIDSetor.Text) & ", "
        strSql += Val(Strings.Right(cbCategoria.Text, 8)) & ", "
        strSql += "'" & cbImpressoraCategoria.Text & "', "
        If chkGuilhotina.Checked = False Then
            strSql += "0, "
        Else
            strSql += "1, "
        End If
        If cbModulo.Text = "Salão" Then
            strSql += "'S')"
        Else
            If cbModulo.Text = "Balcão" Then
                strSql += "'B')"
            Else
                strSql += "'D')"
            End If
        End If
        Dim conAtu As New SqlConnection(strCon)
        Dim cmdAtu As New SqlCommand(strSql, conAtu)
        conAtu.Open()
        cmdAtu.CommandType = CommandType.Text
        cmdAtu.ExecuteNonQuery()
        cmdAtu.Dispose()
        conAtu.Dispose()
        conAtu.Close()
        ' ExecutaStr(strSql)

        cbImpressoraCategoria.Text = ""
        cbCategoria.Text = ""
        tbIDSetorImpressora.Text = ""
        cbModulo.Text = ""
        chkGuilhotina.Checked = False

        PreencheListaImpressoras()
    End Sub

    Private Sub btnExcluiImpressora_Click(sender As Object, e As EventArgs) Handles btnExcluiImpressora.Click
        If tbIDSetorImpressora.Text = "" Then
            MsgBox("Impressora inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Confirma a exclusão da impressora " & cbImpressoraCategoria.Text & " (" & cbModulo.Text & "/" & Trim(Strings.Left(cbCategoria.Text, 50)) & ")", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        strSql = "Delete From tblSetoresImpressoras WHERE (IDSetorImpressora = " & Val(tbIDSetorImpressora.Text) & ")"
        ExecutaStr(strSql)

        cbImpressoraCategoria.Text = ""
        cbCategoria.Text = ""
        tbIDSetorImpressora.Text = ""
        cbModulo.Text = ""
        chkGuilhotina.Checked = False

        PreencheListaImpressoras()

    End Sub

    Private Sub btnGravaImpressora_Click(sender As Object, e As EventArgs) Handles btnGravaImpressora.Click

        If tbIDSetorImpressora.Text = "" Then
            MsgBox("Impressora inválida", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Deseja alterar a impressora " & cbImpressoraConta.Text & " (" & cbModulo.Text & ")" & tbSetor.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        strSql = "UPDATE tblSetoresImpressoras SET "
        strSql += "IDCategoria=" & Val(Strings.Right(cbCategoria.Text, 8)) & ", "
        strSql += "Impressora='" & cbImpressoraCategoria.Text & "', "
        If cbModulo.Text = "Salão" Then
            strSql += "Modulo='S', "
        Else
            If cbModulo.Text = "Balcão" Then
                strSql += "Modulo='B', "
            Else
                strSql += "Modulo='D', "
            End If
        End If
        If chkGuilhotina.Checked = False Then
            strSql += "Guilhotina=0 "
        Else
            strSql += "Guilhotina=1 "
        End If
        strSql += "WHERE (IDSetorImpressora = " & Val(tbIDSetorImpressora.Text) & ")"
        ExecutaStr(strSql)

        cbImpressoraCategoria.Text = ""
        cbCategoria.Text = ""
        tbIDSetorImpressora.Text = ""
        cbModulo.Text = ""
        chkGuilhotina.Checked = False

        PreencheListaImpressoras()
    End Sub

    Private Sub lstImpressoras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstImpressoras.SelectedIndexChanged
        If lstImpressoras.SelectedItems.Count > 0 Then
            tbIDSetorImpressora.Text = lstImpressoras.SelectedItems(0).Text

            Dim IDSel As Integer
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            For I = 1 To cbCategoria.Items.Count
                cbCategoria.SelectedIndex = ItemSel
                IDSel = Val(Strings.Right(cbCategoria.Text, 8))
                cbCategoria.SelectedIndex = ItemSel
                If IDSel = lstImpressoras.SelectedItems(0).SubItems(2).Text Then
                    I = 9999
                End If
                ItemSel += 1
            Next
            cbImpressoraCategoria.Text = lstImpressoras.SelectedItems(0).SubItems(3).Text
            cbModulo.Text = lstImpressoras.SelectedItems(0).SubItems(5).Text
            If lstImpressoras.SelectedItems(0).SubItems(4).Text = "Sim" Then
                chkGuilhotina.Checked = True
            Else
                chkGuilhotina.Checked = False
            End If

        End If
    End Sub

    Private Sub rbtnTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTodos.CheckedChanged
        PreencheListaImpressoras()
    End Sub

    Private Sub rbtnSalao_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSalao.CheckedChanged
        PreencheListaImpressoras()
    End Sub

    Private Sub rbtnBalcao_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnBalcao.CheckedChanged
        PreencheListaImpressoras()
    End Sub

    Private Sub rbtnDelivery_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDelivery.CheckedChanged
        PreencheListaImpressoras()
    End Sub

    Private Sub btnTeste_Click(sender As Object, e As EventArgs) Handles btnTeste.Click
        If lstImpressoras.SelectedItems.Count > 0 Then
            PaginaTeste(cbImpressoraCategoria.Text, Trim(Strings.Left(cbCategoria.Text, 50)), cbModulo.Text, chkGuilhotina.Checked)
        Else
            MsgBox("É necessário selecionar uma impressora", MsgBoxStyle.Information)
        End If
    End Sub
End Class