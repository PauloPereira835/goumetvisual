Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class fdlgComentarioPrincipal

    Public TotalReg As Integer = 0


    Private Sub MontaBotoes(CodFam As Integer)

        Dim n As Integer = 0

        TotalReg = 0

        Dim con_bt As New SqlConnection()
        Dim dr_bt As SqlDataReader

        con_bt.ConnectionString = strCon
        Dim cmd_bt As SqlCommand = con_bt.CreateCommand
        'cmd_bt.CommandText = "Select tblComentariosFamilias.IDComentario, tblComentariosFamilias.IDFamilia, tblComentarios.Comentario, tblComentariosLojas.IDLoja From tblComentariosFamilias INNER Join tblComentarios On tblComentariosFamilias.IDComentario = tblComentarios.IDComentario INNER Join tblComentariosLojas On tblComentarios.IDComentario = tblComentariosLojas.IDComentario Where (tblComentariosLojas.IDLoja = " & IDLoja & ") And (tblComentariosFamilias.IDFamilia = " & CodFam & ") Order By tblComentarios.Comentario"
        cmd_bt.CommandText = "Select IDComentario, IDFamilia, Comentario, IDProduto From tblComentarios_Local WHERE (IDFamilia = " & CodFam & ") Order By Comentario"


        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        'cmd.CommandText = "Select tblComentariosFamilias.IDComentario, tblComentariosFamilias.IDFamilia, tblComentarios.Comentario, tblComentariosLojas.IDLoja From tblComentariosFamilias INNER Join tblComentarios On tblComentariosFamilias.IDComentario = tblComentarios.IDComentario INNER Join tblComentariosLojas On tblComentarios.IDComentario = tblComentariosLojas.IDComentario Where (tblComentariosLojas.IDLoja = " & IDLoja & ") And (tblComentariosFamilias.IDFamilia = " & CodFam & ") Order By tblComentarios.Comentario"
        cmd.CommandText = "Select IDComentario, IDFamilia, Comentario, IDProduto From tblComentarios_Local WHERE (IDFamilia = " & CodFam & ") Order By Comentario"

        'Try
        con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            With dr
                If .HasRows Then
                    While (.Read())
                        TotalReg += 1
                    End While
                End If
            End With

            Dim myfont As New Font("Sans Serif", 9, FontStyle.Bold)
            Dim btnArray(TotalReg) As System.Windows.Forms.Button
            For i As Integer = 0 To TotalReg
                btnArray(i) = New System.Windows.Forms.Button
            Next i

            con_bt.Open()
            dr_bt = cmd_bt.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr_bt.HasRows Then
                While (dr_bt.Read())
                    With (btnArray(n))
                        .Tag = NuloInteger(dr_bt.Item("IDComentario")) & "/" & NuloInteger(dr_bt.Item("IDProduto"))
                        .Text = NuloString(dr_bt.Item("Comentario"))
                        .Width = 139
                        .Height = 55
                        .BackColor = Color.Gray
                        .ForeColor = Color.Lime
                        .FlatStyle = FlatStyle.Standard
                        .Font = myfont

                        Me.PanelCat.Controls.Add(btnArray(n))

                        AddHandler .Click, AddressOf Me.ClickButton_Categorias

                        n += 1
                    End With
                End While
            End If

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        con.Close()
            con.Dispose()
            con_bt.Close()
            con_bt.Dispose()
        'End Try
    End Sub

    Private Sub Inclui_ds(Desc As String, CodProExtra As Integer)

        Dim IDGrid As Integer = 0

        If DataSetComent.Tables(0).Rows.Count = 0 Then
            IDGrid = 1
        Else
            IDGrid = DataSetComent.Tables(0).Rows.Count + 1
        End If
        Dim nova_linha As DataRow = DataSetComent.Tables(0).NewRow()
        nova_linha.ItemArray = New Object() {IDGrid, CodCategoriaSel, Desc, CodProExtra, 0}
        DataSetComent.Tables(0).Rows.Add(nova_linha)

    End Sub

    Private Sub Exclui_ds(Desc As String)

        For i As Integer = 0 To DataSetComent.Tables(0).Rows.Count - 1
            If DataSetComent.Tables(0).Rows(i).Item(2).ToString = Desc Then
                DataSetComent.Tables(0).Rows(i).Delete()
            End If
        Next

    End Sub
    Private Sub IncluiProdutoExtra(CodProd As Integer)

        Dim Valor As Decimal = 0
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim IDGrid As Integer = 0

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = "SELECT IDProduto, Produto, Venda, Categoria, Grupo, CodigoGrupo, CodigoProduto FROM tblProdutos_Local WHERE(IDProduto = " & CodProd & ")"

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            With dr
                If .HasRows Then
                    .Read()
                    Valor = .GetDecimal(2)
                    If Modulo <> "D" Then
                        If frmSalao.DataSetGrid.Tables(0).Rows.Count = 0 Then
                            IDGrid = 1
                        Else
                            IDGrid = frmSalao.DataSetGrid.Tables(0).Rows.Count + 1
                        End If
                    Else
                        If frmDelivery.DataSetGridDel.Tables(0).Rows.Count = 0 Then
                            IDGrid = 1
                        Else
                            IDGrid = frmDelivery.DataSetGridDel.Tables(0).Rows.Count + 1
                        End If
                    End If


                    Dim nova_linha As DataRow
                    If Modulo <> "D" Then
                        nova_linha = frmSalao.DataSetGrid.Tables(0).NewRow()
                    Else
                        nova_linha = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                    End If
                    nova_linha.ItemArray = New Object() {IDGrid, .Item("CodigoProduto"), .GetString(1), Format(1, "#0.000"), IDGrid, "P", .Item("CodigoProduto"), Format(1, "#0.00"), Valor, Format(Valor, "#0.00"), Format(Valor * 1, "#0.00"), Format(Valor * 1, "#0.00"), Operador, Date.Today, 0, 0, 0, 0, .Item("Grupo"), .Item("Categoria"), 0, 0, 0}

                    If Modulo <> "D" Then
                        frmSalao.DataSetGrid.Tables(0).Rows.Add(nova_linha)
                    Else
                        frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha)
                    End If
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Private Sub Confirma()

        Dim IDGrid As Integer = 0
        If Modulo <> "D" Then
            For i = 0 To frmSalao.Grid.Rows.Count - 1
                If frmSalao.Grid.Rows(i).Selected Then
                    IDGrid = NuloInteger(frmSalao.Grid(0, i).Value)
                End If
            Next
            For i As Integer = 0 To DataSetComent.Tables(0).Rows.Count - 1
                If NuloInteger(DataSetComent.Tables(0).Rows(i).Item(3)) <> 0 Then
                    IncluiProdutoExtra(NuloInteger(DataSetComent.Tables(0).Rows(i).Item(3)))
                End If
                Dim nova_linha As DataRow = frmSalao.DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, ">>>>", Trim(DataSetComent.Tables(0).Rows(i).Item(2).ToString), String.Empty, IDGrid, "M", DataSetComent.Tables(0).Rows(i).Item(1), 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0, CodCategoriaSel, DataSetComent.Tables(0).Rows(i).Item(1), 0}
                frmSalao.DataSetGrid.Tables(0).Rows.Add(nova_linha)
            Next
            If NuloString(txtTextoLivre.Text) <> "" Then
                txtTextoLivre.Text = UCase(Strings.Left(txtTextoLivre.Text, 50))
                Dim nova_linha As DataRow = frmSalao.DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, ">>>>", txtTextoLivre.Text, String.Empty, IDGrid, "M", 0, 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0}
                frmSalao.DataSetGrid.Tables(0).Rows.Add(nova_linha)
            End If
            LinhaGrid()
            StiloGrid()
            CalculaTotais()
            frmSalao.Enabled = True
        Else
            For i = 0 To frmDelivery.GridDel.Rows.Count - 1
                If frmDelivery.GridDel.Rows(i).Selected Then
                    IDGrid = NuloInteger(frmDelivery.GridDel(0, i).Value)
                End If
            Next
            For i As Integer = 0 To DataSetComent.Tables(0).Rows.Count - 1
                If NuloInteger(DataSetComent.Tables(0).Rows(i).Item(3)) <> 0 Then
                    IncluiProdutoExtra(NuloInteger(DataSetComent.Tables(0).Rows(i).Item(3)))
                End If
                Dim nova_linha As DataRow = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, ">>>>", Trim(DataSetComent.Tables(0).Rows(i).Item(2).ToString), String.Empty, IDGrid, "M", DataSetComent.Tables(0).Rows(i).Item(1), 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0, CodCategoriaSel, DataSetComent.Tables(0).Rows(i).Item(1), 0}
                frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha)
            Next
            If NuloString(txtTextoLivre.Text) <> "" Then
                txtTextoLivre.Text = UCase(Strings.Left(txtTextoLivre.Text, 50))
                Dim nova_linha As DataRow = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, ">>>>", Strings.Left(txtTextoLivre.Text, 50), String.Empty, IDGrid, "M", 0, 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0}
                frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha)
            End If
            LinhaGridDelivery()
            StiloGridDelivery()
            CalculaTotaisDelivery()
            'frmSalao.Enabled = True
        End If
        Me.Dispose()
        Me.Close()

    End Sub
    Private Sub ClickButton_Categorias(ByVal sender As Object, ByVal e As System.EventArgs)

        With CType(sender, Button)
            If .BackColor = Color.Gray Then
                .BackColor = Color.LawnGreen
                .ForeColor = Color.Gray

                Dim IDGrid As Integer = 0
                If DataSetComent.Tables(0).Rows.Count = 0 Then
                    IDGrid = 1
                Else
                    IDGrid = DataSetComent.Tables(0).Rows.Count + 1
                End If
                Dim Loc As Integer = InStr(NuloString(.Tag), "/")
                Dim Texto As String = NuloString(.Tag)
                Dim IDComent As Integer = NuloInteger(Strings.Left(NuloString(Texto), Len(NuloString(Texto)) - Loc - 1))
                Dim IDProd As Integer = NuloInteger(Strings.Right(NuloString(.Tag), Len(NuloString(.Tag)) - InStr(NuloString(.Tag), "/")))
                Dim nova_linha As DataRow = DataSetComent.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, IDComent, .Text, IDProd, 0}
                DataSetComent.Tables(0).Rows.Add(nova_linha)
            Else
                .BackColor = Color.Gray
                .ForeColor = Color.Lime

                If DataSetComent.Tables(0).Rows.Count > 0 Then
                    Dim i As Integer = 0
                    Dim ii As Integer = DataSetComent.Tables(0).Rows.Count
                    While i < ii
                        If DataSetComent.Tables(0).Rows(i).Item(2).ToString = .Text Then
                            DataSetComent.Tables(0).Rows(i).Delete()
                            i -= 1
                            ii -= 1
                        End If
                        i += 1
                    End While
                End If
            End If
        End With

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

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        CliqueNoBotao("Q")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CliqueNoBotao("W")
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CliqueNoBotao("E")
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        CliqueNoBotao("R")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CliqueNoBotao("T")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CliqueNoBotao("Y")
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        CliqueNoBotao("U")
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CliqueNoBotao("I")
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
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

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        CliqueNoBotao(" ")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CliqueNoBotao("/")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If txtTextoLivre.Text <> String.Empty Then
            txtTextoLivre.Text = Strings.Left(txtTextoLivre.Text, Len(txtTextoLivre.Text) - 1)
            lbLetras.Text = (25 - txtTextoLivre.TextLength).ToString
        End If
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click

        Confirma()

    End Sub

    Private Sub fdlgComentarioPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Modulo <> "D" Then
            frmSalao.TimerTela.Enabled = False
            Me.Text = "Comentar Produto - " & ProdutoSel
            MontaBotoes(IDFami)
        Else
            Me.Text = "Comentar Produto - " & frmDelivery.lbProduto.Text
            MontaBotoes(NuloInteger(frmDelivery.tbIDFamilia.Text))
        End If
        txtTextoLivre.Focus()

    End Sub

    Private Sub CliqueNoBotao(texto As String)
        If txtTextoLivre.TextLength < 25 Then
            txtTextoLivre.Text &= UCase(texto)
            lbLetras.Text = (50 - txtTextoLivre.TextLength).ToString
        End If
    End Sub

    Private Sub fdlgComentarioPrincipal_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub TxtTextoLivre_TextChanged(sender As Object, e As EventArgs) Handles txtTextoLivre.TextChanged

    End Sub

    Private Sub txtTextoLivre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTextoLivre.KeyPress
        If AscW(e.KeyChar) = 13 Then
            Confirma()
        End If
    End Sub
End Class