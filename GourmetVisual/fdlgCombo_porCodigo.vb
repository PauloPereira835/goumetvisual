Imports System.Data.SqlClient

Public Class fdlgCombo_porCodigo
    Private Sub CalculaValor()
        If EGrupoPizza = True Then
            VlrUnitario = 0
        End If
        Dim somaValor As Decimal = VlrUnitario
        Dim ValorReal As Decimal = VlrUnitario
        Dim Sabores As Decimal = 0
        For i As Integer = 0 To Grid.Rows.Count - 1
            If Not IsDBNull(Grid.Rows(i).Cells(8).Value) Then
                If NuloInteger(Grid.Rows(i).Cells(3).Value) > 0 And NuloInteger(Grid.Rows(i).Cells(5).Value) = 0 Then
                    Sabores += 1
                End If
                somaValor += Convert.ToInt32(Grid.Rows(i).Cells(7).Value)
            Else
                If NuloDecimal(Grid.Rows(i).Cells(7).Value) <> 0 Then
                    somaValor += Convert.ToInt32(Grid.Rows(i).Cells(7).Value)
                    ValorReal += Convert.ToInt32(Grid.Rows(i).Cells(7).Value)
                    Sabores += 1
                End If
            End If
        Next

        tbSabores.Text = CType(Sabores, String)

        If AgregaValor = True Then
            If EGrupoPizza = True Then
                If Sabores > 0 Then
                    ' Calculo valor pela media quando pizza
                    tbValor.Text = NuloDecimal(somaValor / Sabores).ToString("F2") 'F2 = 2 Casas Decimais
                    tbValorReal.Text = NuloDecimal(ValorReal / Sabores).ToString("F2") 'F2 = 2 Casas Decimais
                End If
            Else
                ' Calculo agregando valor
                tbValor.Text = NuloDecimal(somaValor).ToString("F2") 'F2 = 2 Casas Decimais
                tbValorReal.Text = NuloDecimal(ValorReal).ToString("F2") 'F2 = 2 Casas Decimais
            End If
        Else

        End If
    End Sub
    Private Sub EnviaProduto(CodProd As Integer)


        If NuloInteger(tbIDFamilia.Text) = 0 Then
            MsgBox("Erro cadastro Familia")
            Exit Sub
        End If

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridProdutos.Rows.Clear()

        SqlStr = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda, tblProdutos_Local.Pesavel, tblGrupos_Local.EPizza, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.IDFamilia, tblGrupos_Local.Grupo, tblProdutos_Local.Categoria "
        SqlStr += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        SqlStr += "Where (CodigoProduto =" & CodProd & ") And (IDFamilia = " & tbIDFamilia.Text & ")"
        cmd.CommandText = SqlStr

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        tbIDProduto.Text = ""
        tbCodigoProduto.Text = ""
        'lbProduto.Text = ""
        'tbEPizza.Text = ""
        'tbIDFamilia.Text = ""
        tbVenda.Text = ""
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If Grid.Rows.Count > 0 Then
            If dr.HasRows Then
                dr.Read()
                If NuloBoolean(dr.Item("ForaLinha")) = False Then
                    tbIDProduto.Text = dr.Item("IDProduto")
                    tbCodigoProduto.Text = dr.Item("CodigoProduto")
                    tbProduto.Text = dr.Item("Produto")
                    'tbIDFamilia.Text = NuloInteger(dr.Item("IDFamilia"))
                    tbVenda.Text = NuloDecimal(dr.Item("Venda"))


                    Grid(4, NuloInteger(tbLinha.Text)).Value = tbProduto.Text
                    Grid(3, NuloInteger(tbLinha.Text)).Value = tbIDProduto.Text
                    Grid(7, NuloInteger(tbLinha.Text)).Value = NuloDecimal(dr.Item("Venda"))


                    If NuloInteger(tbLinha.Text) < NuloInteger(tbQtdeLinhas.Text) - 1 Then
                        tbLinha.Text = NuloInteger(tbLinha.Text) + 1
                    Else
                        tbLinha.Text = NuloInteger(tbQtdeLinhas.Text) - 1
                    End If
                    tbIDFamiliaSel.Text = Grid(1, NuloInteger(tbLinha.Text)).Value
                    Grid.Rows(NuloInteger(tbLinha.Text)).Selected = True

                    CalculaValor()

                Else
                    frm.lbMensagem.Text = "Produto fora de linha"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                End If
            Else
                frm.lbMensagem.Text = "Produto não encontrado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            End If
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

    End Sub

    Public Sub MontaGrid_Combo()

        If NuloInteger(tbIDProdutoSel.Text) = 0 Then Exit Sub

        strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDFamilia, tblProdutos_Local.Venda, tblFamilias_Local.Familia, tblProdutos_Local.IDProduto "
        strSql += "From tblProdutos_Local INNER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto LEFT OUTER Join tblFamilias_Local On tblCombos_Local.IDFamilia = tblFamilias_Local.IDFamilia "
        strSql += "Where (tblProdutos_Local.IDProduto=" & tbIDProdutoSel.Text & ") "
        strSql += "Order By tblCombos_Local.IDCombo"

        Dim dv As New DataView(DataSetGrid.Tables(0))

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        Dim IDGrid As Integer = ds.Tables("Vendas").Rows.Count
        If IDGrid = 0 Then
            Me.Dispose()
            Me.Close()
            Exit Sub
        End If

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            Dim nova_linha As DataRow = DataSetGrid.Tables(0).NewRow()
            nova_linha.ItemArray = New Object() {i, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDFamilia")), Trim(ds.Tables("Vendas").Rows(i).Item("Familia")), 0, String.Empty, 0, String.Empty, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDCombo")), NuloDecimal(0).ToString("F2")}
            DataSetGrid.Tables(0).Rows.Add(nova_linha)
        Next

        If Grid.Rows.Count > 0 Then
            Grid.Rows(0).Selected = True
        End If

        tbIDFamiliaSel.Text = NuloString(Grid.Item(1, Grid.CurrentRow.Index).Value)
        IDFamiliaSel = NuloString(Grid.Item(1, Grid.CurrentRow.Index).Value)
        ID_Grid.Text = NuloString(Grid.Item(0, Grid.CurrentRow.Index).Value)
        tbQtdeLinhas.Text = IDGrid

        'VlrUnitario = 0

        Dim somaValor As Decimal = VlrUnitario
        For i As Integer = 0 To fdlgCombo.Grid.Rows.Count - 1
            somaValor += NuloDecimal(Grid.Rows(i).Cells(8).Value)
        Next
        tbValor.Text = NuloDecimal(somaValor).ToString("F2") 'F2 = 2 Casas Decimais

        StiloGrid()

    End Sub
    Public Sub StiloGrid()
        For i As Integer = 0 To Grid.Rows.Count - 1
            If NuloString(Grid.Rows(i).Cells(2).Value) = "                                   ----->" Then
                Grid.Rows(i).Cells(4).Style.ForeColor = Color.Gray
                Grid.Rows(i).Cells(2).Style.ForeColor = Color.Gray
                Grid.Rows(i).Cells(4).Style.Font = New Font("Tahoma", 10, FontStyle.Italic)
                Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 10, FontStyle.Italic)
            Else
                Grid.Rows(i).Cells(4).Style.ForeColor = Color.ForestGreen
                Grid.Rows(i).Cells(8).Style.ForeColor = Color.ForestGreen
                Grid.Rows(i).Cells(2).Style.ForeColor = Color.Green
                Grid.Rows(i).Cells(4).Style.Font = New Font("Tahoma", 12, FontStyle.Bold)
                Grid.Rows(i).Cells(2).Style.Font = New Font("Tahoma", 10, FontStyle.Regular)
                Grid.Rows(i).Cells(8).Style.Font = New Font("Tahoma", 10, FontStyle.Regular)
            End If
            If NuloDecimal(Grid.Rows(i).Cells(9).Value) = 0 Then
                'Grid.Rows(i).Cells(9).Value = ""
                Grid(9, i).Value = 0
            Else
                Grid(9, i).Value = Format(Grid.Rows(i).Cells(9).Value, "#0.00")

            End If
        Next
    End Sub
    Private Sub MontaDetalhes()

        If NuloInteger(tbIDFamiliaSel.Text) = 0 Then Exit Sub

        Dim n As Integer = 0
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        SqlStr = "Select tblComentarios_Local.IDComentario, tblFamilias_Local.IDFamilia, tblComentarios_Local.Comentario "
        SqlStr += "From tblComentarios_Local INNER Join tblFamilias_Local On tblComentarios_Local.IDFamilia = tblFamilias_Local.IDFamilia "
        SqlStr += "Where (tblFamilias_Local.IDFamilia = " & tbIDFamiliaSel.Text & ") "
        SqlStr += "Order By tblComentarios_Local.Comentario"
        cmd.CommandText = SqlStr

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim myfont As New Font("Sans Serif", 7, FontStyle.Regular)
        Dim btnArrayPro(100) As System.Windows.Forms.Button
        For i As Integer = 0 To 100
            btnArrayPro(i) = New System.Windows.Forms.Button
        Next i

        Me.PanelDetalhes.Controls.Clear()

        If dr.HasRows Then
            While (dr.Read())
                With (btnArrayPro(n))
                    .Tag = dr.GetInt32(0)
                    .Text = dr.GetString(2)
                    .Width = 128
                    .Height = 34
                    .BackColor = Color.PaleGreen
                    .Font = myfont
                    .ForeColor = Color.DarkGreen
                    .Margin = New Padding(0, 0, 0, 0)

                    Me.PanelDetalhes.Controls.Add(btnArrayPro(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Detalhes
                    n += 1
                End With
            End While
        End If
    End Sub
    Private Sub ClickButton_Detalhes(ByVal sender As Object, ByVal e As System.EventArgs)

        If Grid.Rows.Count <= 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um PRODUTO"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        Dim Selecionado As Boolean = False
        For i As Integer = 0 To Grid.Rows.Count - 1
            If Grid.Rows(i).Selected = True Then
                Selecionado = True
            End If
        Next
        If Selecionado = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um PRODUTO"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim btn As Button = CType(sender, Button)

        Dim IDGrid As Integer = NuloInteger(Grid(0, Grid.CurrentRow.Index).Value)
        Dim IDFam As Integer = NuloInteger(Grid(1, Grid.CurrentRow.Index).Value)
        Dim IDProd As Integer = NuloInteger(Grid(3, Grid.CurrentRow.Index).Value)
        Dim IDDetalhe As Integer = NuloInteger(btn.Tag)
        Dim Detalhe As String = Trim(btn.Text)


        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblComentarios_Local.IDComentario, tblComentarios_Local.IDFamilia, tblComentarios_Local.Comentario, tblComentarios_Local.IDProduto, tblProdutos_Local.Venda "
        strSql += "From tblProdutos_Local INNER Join tblComentarios_Local On tblProdutos_Local.IDProduto = tblComentarios_Local.IDProduto "
        strSql += "Where (tblComentarios_Local.IDComentario =" & IDDetalhe & ")"

        cmd.CommandText = strSql

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            If NuloInteger(Grid(5, Grid.CurrentRow.Index).Value) = 0 Then
                Dim nova_linha As DataRow = Me.DataSetGrid.Tables(0).NewRow()
                dr.Read()
                nova_linha.ItemArray = New Object() {IDGrid, IDFam, "                                   ----->", IDProd, Detalhe, IDDetalhe, String.Empty, 0, NuloDecimal(dr.Item("Venda")), NuloInteger(dr.Item("IDProduto"))}
                Me.DataSetGrid.Tables(0).Rows.Add(nova_linha)
            Else
                Grid(5, Grid.CurrentRow.Index).Value = IDDetalhe
                Grid(4, Grid.CurrentRow.Index).Value = Detalhe
            End If

        Else
            If NuloInteger(Grid(5, Grid.CurrentRow.Index).Value) = 0 Then
                Dim nova_linha As DataRow = Me.DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {IDGrid, IDFam, "                                   ----->", IDProd, Detalhe, IDDetalhe, String.Empty}
                Me.DataSetGrid.Tables(0).Rows.Add(nova_linha)
            Else
                Grid(5, Grid.CurrentRow.Index).Value = IDDetalhe
                Grid(4, Grid.CurrentRow.Index).Value = Detalhe
            End If
        End If
        dr.Close()
        con.Dispose()
        con.Close()
        Me.Grid.Sort(Me.Grid.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        StiloGrid()
        CalculaValor()
        tbCodPro.Focus()

    End Sub
    Public Sub AtualizaGridProdutos()

        If NuloInteger(tbIDFamiliaSel.Text) = 0 Then Exit Sub

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridProdutos.Rows.Clear()
        tbIDProduto.Text = ""
        tbCodigoProduto.Text = ""
        tbProduto.Text = ""
        'If NuloBoolean(tbEPizza.Text) = False Then tbIDFamilia.Text = ""
        tbVenda.Text = ""

        SqlStr = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblGrupos_Local.Grupo, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda, tblProdutos_Local.Pesavel, tblGrupos_Local.EPizza, tblProdutos_Local.IDFamilia, tblProdutos_Local.Categoria, tblGrupos_Local.CodigoGrupo "
        SqlStr += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        If Not IsNumeric(tbCodPro.Text) Then
            SqlStr += "Where (tblProdutos_Local.Produto Like '%" & tbCodPro.Text & "%') AND (tblProdutos_Local.IDFamilia = " & tbIDFamiliaSel.Text & ") "
            If NuloBoolean(tbEPizza.Text) = True Then
                SqlStr += "AND (tblProdutos_Local.IDProduto <> " & tbIDProdutoSel.Text & ") "
            End If
            SqlStr += "ORDER BY tblProdutos_Local.Produto"
        Else
            SqlStr += "Where (tblProdutos_Local.CodigoProduto Like '" & tbCodPro.Text & "%') AND (tblProdutos_Local.IDFamilia = '" & tbIDFamiliaSel.Text & "') "
            If NuloBoolean(tbEPizza.Text) = True Then
                SqlStr += "AND (tblProdutos_Local.IDProduto <> " & tbIDProdutoSel.Text & ") "
            End If
            SqlStr += "ORDER BY tblProdutos_Local.CodigoProduto"
        End If
        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read())
                If NuloBoolean(dr.Item("ForaLinha")) = False Then
                    GridProdutos.Rows.Add({dr.Item("IDProduto"), dr.Item("CodigoProduto"), dr.Item("Produto"), NuloDecimal(dr.Item("Venda")), NuloInteger(dr.Item("IDFamilia"))})
                    tbIDProduto.Text = dr.Item("IDProduto")
                    tbCodigoProduto.Text = dr.Item("CodigoProduto")
                    tbProduto.Text = dr.Item("Produto")
                    If NuloBoolean(tbEPizza.Text) = False Then tbIDFamilia.Text = NuloInteger(dr.Item("IDFamilia"))
                    tbVenda.Text = NuloDecimal(dr.Item("Venda"))
                End If
            End While
        End If
        'For i As Integer = 0 To Grid.Rows.Count - 1
        'Grid.Rows(i).Selected = False
        'Next

        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()
        If NuloBoolean(tbEPizza.Text) = False Then MontaDetalhes()


    End Sub
    Private Sub fdlgCombo_porCodigo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Modulo = "D" Then
            lbProduto.Text = frmDelivery.lbProduto.Text
            tbValor.Text = Format(NuloDecimal(0), "#0.00")
            tbEPizza.Text = EGrupoPizza
            tbIDProdutoSel.Text = frmDelivery.tbIDProduto.Text

            If NuloBoolean(tbEPizza.Text) = True Then
                tbIDFamiliaSel.Text = frmDelivery.tbIDFamilia.Text
                tbIDFamilia.Text = frmDelivery.tbIDFamilia.Text
            End If
            MontaGrid_Combo()
            MontaDetalhes()
            AtualizaGridProdutos()
        Else
            lbProduto.Text = frmSalao.LBProduto.Text
            tbValor.Text = Format(NuloDecimal(0), "#0.00")
            tbEPizza.Text = EGrupoPizza
            tbIDProdutoSel.Text = IDProdutoSel

            If NuloBoolean(tbEPizza.Text) = True Then
                tbIDFamiliaSel.Text = IDFamiliaSel
            End If
            MontaGrid_Combo()
            MontaDetalhes()
            AtualizaGridProdutos()
        End If
        CalculaValor()
        ' tbValor.Text = Format(NuloDecimal(0), "#0.00")

        If NuloInteger(CodProIni) <> 0 Then
            tbCodPro.Text = CodProIni
            SendKeys.Send("{ENTER}")
        End If

    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub tbCodPro_TextChanged(sender As Object, e As EventArgs) Handles tbCodPro.TextChanged
        AtualizaGridProdutos()
    End Sub

    Private Sub tbCodPro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodPro.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If IsNumeric(tbCodPro.Text) Then
                EnviaProduto(tbCodPro.Text)
                If NuloBoolean(tbEPizza.Text) = False Then MontaDetalhes()

                tbCodPro.Text = ""
                'tbIDProdutoSel.Text = ""
                AtualizaGridProdutos()
                CalculaValor()
            Else
                GridProdutos.Focus()
            End If
        End If
    End Sub

    Private Sub btnLimpa_Click(sender As Object, e As EventArgs) Handles btnLimpa.Click

        DataSetGrid.Clear()
        MontaGrid_Combo()
        tbCodPro.Focus()
        Grid.ClearSelection()


        'Dim dv As New DataView(DataSetGrid.Tables(0))
        'Dim ID As Integer = NuloInteger(Grid(0, Grid.CurrentRow.Index).Value)
        'dv.Sort = "ID , Produto DESC"
        'Inicio:

        'For i = 0 To dv.Count - 1
        'If ID = dv.Item(i)("ID") Then
        'dv.Item(i).Delete()
        'GoTo Inicio
        'End If
        'Next
        'MontaGrid_Combo()
        'tbCodPro.Focus()
        'Grid.ClearSelection()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dv As New DataView(DataSetGrid.Tables(0))

        'dv.Sort = "ID DESC, Status DESC"
        dv.Sort = "ID , Produto DESC"

        For i = 0 To dv.Count - 1
            MsgBox("1 - ID................" & NuloString(dv.Item(i)("ID")) & vbCrLf &
            "2 - IDFamilia........." & NuloString(dv.Item(i)("IDFamilia")) & vbCrLf &
            "3 - Familia..........." & NuloString(dv.Item(i)("Familia")) & vbCrLf &
            "4 - IDProduto........." & NuloString(dv.Item(i)("IDProduto")) & vbCrLf &
            "5 - Produto..........." & NuloString(dv.Item(i)("Produto")) & vbCrLf &
            "6 - IDDetalhe........." & NuloString(dv.Item(i)("IDDetalhe")) & vbCrLf &
            "7 - Detalhe..........." & NuloString(dv.Item(i)("Detalhe")) & vbCrLf &
            "8 - IDMontagem........" & NuloString(dv.Item(i)("IDMontagem")) & vbCrLf &
            "9 - Valor............." & NuloString(dv.Item(i)("Valor")) & vbCrLf &
            "10- IDProdVinculado..." & NuloString(dv.Item(i)("IDProdutoVinculado")) & vbCrLf &
            "11- QtdeProdVinculado." & NuloString(dv.Item(i)("QtdeProdutoVinculado")) & vbCrLf &
            "12- VlrProdVinculado.." & NuloString(dv.Item(i)("VlrProdutoVinculado")))
        Next
    End Sub

    Private Sub tbTextoLivre_TextChanged(sender As Object, e As EventArgs) Handles tbTextoLivre.TextChanged
        If Len(tbTextoLivre.Text) > 25 Then
            tbTextoLivre.Text = Strings.Left(UCase(tbTextoLivre.Text), 25)
        End If
        lbLetras.Text = 25 - Len(tbTextoLivre.Text)
    End Sub

    Private Sub tbTextoLivre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTextoLivre.KeyPress
        If AscW(e.KeyChar) = 13 Then
            Dim Selecionado As Boolean = False
            For i As Integer = 0 To Grid.Rows.Count - 1
                If Grid.Rows(i).Selected = True Then
                    Selecionado = True
                End If
            Next
            If Selecionado = False Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar um PRODUTO"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If
            If tbTextoLivre.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Texto inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            Dim IDGrid As Integer = NuloInteger(Grid(0, Grid.CurrentRow.Index).Value)
            Dim IDFam As Integer = NuloInteger(Grid(1, Grid.CurrentRow.Index).Value)
            Dim IDProd As Integer = NuloInteger(Grid(3, Grid.CurrentRow.Index).Value)
            Dim Detalhe As String = UCase(tbTextoLivre.Text)

            Dim nova_linha As DataRow = Me.DataSetGrid.Tables(0).NewRow()
            nova_linha.ItemArray = New Object() {IDGrid, IDFam, "                                   ----->", IDProd, Detalhe, 999, String.Empty}
            Me.DataSetGrid.Tables(0).Rows.Add(nova_linha)
            tbTextoLivre.Text = ""
            Me.Grid.Sort(Me.Grid.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            StiloGrid()
            lbLetras.Text = 25
            tbTextoLivre.Text = ""
            tbCodPro.Focus()
        End If


    End Sub

    Private Sub GridProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridProdutos.CellContentClick

    End Sub

    Private Sub GridProdutos_DoubleClick(sender As Object, e As EventArgs) Handles GridProdutos.DoubleClick
        tbIDProduto.Text = ""
        tbCodigoProduto.Text = ""
        tbVenda.Text = ""
        tbIDFamilia.Text = ""
        tbCodPro.Focus()
        If GridProdutos.Rows.Count > 0 Then
            tbIDProduto.Text = NuloInteger(GridProdutos.Item("IDProduto", GridProdutos.CurrentRow.Index).Value)
            tbCodigoProduto.Text = NuloInteger(GridProdutos.Item("CodigoProduto", GridProdutos.CurrentRow.Index).Value)
            tbVenda.Text = NuloDecimal(GridProdutos.Item("Venda", GridProdutos.CurrentRow.Index).Value)
            tbIDFamilia.Text = NuloInteger(GridProdutos.Item("IDFamilia", GridProdutos.CurrentRow.Index).Value)

            EnviaProduto(tbCodigoProduto.Text)
            If NuloBoolean(tbEPizza.Text) = False Then MontaDetalhes()
            tbCodPro.Text = ""
            AtualizaGridProdutos()
            tbCodPro.Focus()
        End If
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        Dim IDGrid_ As Integer
        Dim IDGridComb As Integer
        Dim Qtde As Double
        Dim VlrProd As Decimal
        Dim ContVinc As Integer = 0
        Dim CategoriaCombo As String
        Dim GrupoCombo As String
        Dim CodigoProdutoCombo As String
        Dim dv As New DataView(DataSetGrid.Tables(0))

        Dim IDPVinc(20) As Integer
        For i As Integer = 0 To 20
            IDPVinc(i) = 0
        Next i
        Dim VlrPVinc(20) As Decimal
        For i As Integer = 0 To 20
            VlrPVinc(i) = 0
        Next i
        Dim QtdPVinc(20) As Double
        For i As Integer = 0 To 20
            QtdPVinc(i) = 0
        Next i
        Dim ProVinc(20) As String
        For i As Integer = 0 To 20
            ProVinc(i) = ""
        Next i
        Dim IDGrupoVinc(20) As Integer
        For i As Integer = 0 To 20
            IDGrupoVinc(i) = 0
        Next i
        Dim GrupoVinc(20) As String
        For i As Integer = 0 To 20
            GrupoVinc(i) = ""
        Next i
        Dim CatVinc(20) As String
        For i As Integer = 0 To 20
            CatVinc(i) = ""
        Next i
        Dim CodPVinc(20) As Integer
        For i As Integer = 0 To 20
            CodPVinc(i) = 0
        Next i
        Dim IDFam(20) As Integer
        For i As Integer = 0 To 20
            IDFam(i) = 0
        Next i

        If Modulo = "D" Then
            GrupoCombo = frmDelivery.tbGrupo.Text
            CategoriaCombo = frmDelivery.tbCategoria.Text
            CodigoProdutoCombo = frmDelivery.tbCodigoProduto.Text
            If frmDelivery.DataSetGridDel.Tables(0).Rows.Count = 0 Then
                IDGrid_ = 1
            Else
                For i As Integer = 0 To frmDelivery.DataSetGridDel.Tables(0).Rows.Count - 1
                    If NuloInteger(frmDelivery.DataSetGridDel.Tables(0).Rows(i).Item(4)) > IDGrid_ Then
                        IDGrid_ = NuloInteger(frmDelivery.DataSetGridDel.Tables(0).Rows(i).Item(4))
                    End If
                Next
                IDGrid_ += 1
            End If
        Else
            strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.Categoria "
            strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
            strSql += "Where (tblProdutos_Local.CodigoProduto =" & NuloInteger(frmSalao.tbCodigoProduto.Text) & ")"
            GrupoCombo = NuloString(PegaValorCampo("Grupo", strSql, strCon))
            CategoriaCombo = NuloString(PegaValorCampo("Categoria", strSql, strCon))
            CodigoProdutoCombo = frmSalao.tbCodigoProduto.Text
            If frmSalao.DataSetGrid.Tables(0).Rows.Count = 0 Then
                IDGrid_ = 1
            Else
                For i As Integer = 0 To frmSalao.DataSetGrid.Tables(0).Rows.Count - 1
                    If NuloInteger(frmSalao.DataSetGrid.Tables(0).Rows(i).Item(4)) > IDGrid_ Then
                        IDGrid_ = NuloInteger(frmSalao.DataSetGrid.Tables(0).Rows(i).Item(4))
                    End If
                Next
                IDGrid_ += 1
            End If
        End If

        Dim SeqSabor As Integer = 1
        dv.Sort = "ID"
        IDGridComb = NuloInteger(dv.Item(0)("ID"))

        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo "
        strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
        strSql += "Where (tblProdutos_Local.IDProduto =" & NuloInteger(tbIDProdutoSel.Text) & ")"
        IDGrupo = NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon))
        Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))
        If AgregaValor = True Then
            'IncluiProdGrid(IDGrid_, CodigoProdutoCombo, lbProduto.Text, NuloDecimal(tbValorReal.Text), IDGrupo, NuloInteger(tbIDFamiliaSel.Text), 0, 0, "P", NuloInteger(1), Grupo, CategoriaCombo, tbIDProdutoSel.Text, 0, IDGrid_, False)
            IncluiProdGrid(IDGrid_, CodigoProdutoCombo, lbProduto.Text, NuloDecimal(tbValorReal.Text), IDGrupo, NuloInteger(IDFami), 0, 0, "P", NuloInteger(1), Grupo, CategoriaCombo, tbIDProdutoSel.Text, 0, IDGrid_, False)
        Else
            'IncluiProdGrid(IDGrid_, CodigoProdutoCombo, lbProduto.Text, NuloDecimal(tbValor.Text), IDGrupo, NuloInteger(tbIDFamiliaSel.Text), 0, 0, "P", NuloInteger(1), Grupo, CategoriaCombo, tbIDProdutoSel.Text, 0, IDGrid_, False)
            IncluiProdGrid(IDGrid_, CodigoProdutoCombo, lbProduto.Text, NuloDecimal(tbValor.Text), IDGrupo, NuloInteger(IDFami), 0, 0, "P", NuloInteger(1), Grupo, CategoriaCombo, tbIDProdutoSel.Text, 0, IDGrid_, False)
        End If

        For i = 0 To dv.Count - 1
            If IDGridComb <> NuloInteger(dv.Item(0)("ID")) Then
                IDGridComb = NuloInteger(dv.Item(0)("ID"))
                IDGrid_ += 1
            End If

            If NuloInteger(dv.Item(i)("IDDetalhe")) = 0 Then
                FamiliaSel = Trim(NuloString(dv.Item(i)("Familia")))

                If NuloBoolean(tbEPizza.Text) = True Then
                    Qtde = 1 / NuloInteger(tbSabores.Text)
                    If NuloInteger(tbSabores.Text) = 3 And SeqSabor = 3 Then
                        Qtde = CDbl(Format(Qtde + 0.001, "#0.000"))
                    Else
                        Qtde = CDbl(Format(Qtde, "#0.000"))
                    End If
                    SeqSabor += 1
                Else
                    Qtde = NuloInteger(1)
                End If

                If NuloInteger(dv.Item(i)("IDProduto")) <> 0 Then

                    Dim conV As New SqlConnection()
                    Dim drV As SqlDataReader

                    conV.ConnectionString = strCon
                    Dim cmdV As SqlCommand = conV.CreateCommand
                    cmdV.CommandText = "Select IDProduto, Produto, IDFamilia, Venda, CodigoProduto, Grupo, Categoria, CodigoGrupo From tblProdutos_Local Where (IDProduto = " & NuloInteger(dv.Item(i)("IDProduto")) & ")"

                    conV.Open()
                    drV = cmdV.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

                    If drV.HasRows Then
                        drV.Read()

                        If NuloBoolean(tbEPizza.Text) = True Then
                            VlrProd = NuloDecimal(dv.Item(i)("Valor"))
                        Else
                            If AgregaValor = True Then
                                VlrProd = NuloDecimal(dv.Item(i)("Valor"))
                            Else
                                VlrProd = 0
                            End If
                        End If
                        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.Categoria "
                        strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
                        strSql += "Where (tblProdutos_Local.IDProduto =" & NuloInteger(dv.Item(i)("IDProduto")) & ")"
                        IDGrupo = NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon))
                        Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))
                        CategoriaCombo = NuloString(PegaValorCampo("Categoria", strSql, strCon))
                        IncluiProdGrid(IDGrid_, NuloInteger(drV.Item("IDProduto")), NuloString(dv.Item(i)("Produto")), VlrProd, IDGrupo, NuloInteger(IDFami), 0, NuloInteger(dv.Item(i)("IDMontagem")), "PC", Qtde, Grupo, CategoriaCombo, NuloInteger(dv.Item(i)("IDProduto")), 0, IDGrid_, False)
                    End If

                    drV.Close()
                    cmdV.Dispose()
                    conV.Dispose()
                    conV.Close()
                End If
            Else
                IncluiProdGrid(IDGrid_, 0, NuloString(dv.Item(i)("Produto")), 0, 0, NuloInteger(IDFami), NuloInteger(dv.Item(i)("IDDetalhe")), 0, "MC", 1, "", "", 0, 0, IDGrid_, False)
                If NuloInteger(dv.Item(i)("IDProdutoVinculado")) <> 0 Then
                    Dim conV As New SqlConnection()
                    Dim drV As SqlDataReader

                    conV.ConnectionString = strCon
                    Dim cmdV As SqlCommand = conV.CreateCommand

                    'cmdV.CommandText = "Select IDProduto, Produto, IDFamilia, Venda, CodigoProduto, Grupo, Categoria, CodigoGrupo From tblProdutos_Local Where (IDProduto = " & NuloInteger(dv.Item(i)("IDProdutoVinculado")) & ")"
                    'cmdV.CommandText = "Select IDProduto, Produto, IDFamilia, Venda, CodigoProduto, Grupo, Categoria, CodigoGrupo From tblProdutos_Local Where (IDProduto = " & NuloInteger(dv.Item(i)("IDProdutoVinculado")) & ")"
                    strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.Produto, tblProdutos_Local.Categoria, tblProdutos_Local.Venda, tblProdutos_Local.IDFamilia "
                    strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
                    strSql += "Where (tblProdutos_Local.IDProduto =" & NuloInteger(dv.Item(i)("IDProdutoVinculado")) & ")"
                    cmdV.CommandText = strSql

                    conV.Open()
                    drV = cmdV.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

                    If drV.HasRows Then
                        drV.Read()
                        IDPVinc(ContVinc) = NuloInteger(dv.Item(i)("IDProdutoVinculado"))
                        ProVinc(ContVinc) = NuloString(drV.Item("Produto"))
                        VlrPVinc(ContVinc) = NuloDecimal(drV.Item("Venda"))
                        QtdPVinc(ContVinc) = Qtde
                        IDGrupoVinc(ContVinc) = NuloInteger(drV.Item("CodigoGrupo"))
                        CodPVinc(ContVinc) = NuloInteger(drV.Item("CodigoProduto"))
                        GrupoVinc(ContVinc) = NuloString(drV.Item("Grupo"))
                        CatVinc(ContVinc) = NuloString(drV.Item("Categoria"))
                        IDFam(ContVinc) = NuloInteger(drV.Item("IDFamilia"))
                        ContVinc += 1
                    End If
                    drV.Close()
                    cmdV.Dispose()
                    conV.Dispose()
                    conV.Close()
                End If
            End If
        Next


        For ii As Integer = 0 To 20
            If IDPVinc(ii) <> 0 Then
                If Modulo = "D" Then
                    If frmDelivery.DataSetGridDel.Tables(0).Rows.Count = 0 Then
                        IDGrid_ = 1
                    Else
                        For i As Integer = 0 To frmDelivery.DataSetGridDel.Tables(0).Rows.Count - 1
                            If NuloInteger(frmDelivery.DataSetGridDel.Tables(0).Rows(i).Item(4)) > IDGrid_ Then
                                IDGrid_ = NuloInteger(frmDelivery.DataSetGridDel.Tables(0).Rows(i).Item(4))
                            End If
                        Next
                        IDGrid_ += 1
                    End If
                Else
                    If frmSalao.DataSetGrid.Tables(0).Rows.Count = 0 Then
                        IDGrid_ = 1
                    Else
                        For i As Integer = 0 To frmSalao.DataSetGrid.Tables(0).Rows.Count - 1
                            If NuloInteger(frmSalao.DataSetGrid.Tables(0).Rows(i).Item(4)) > IDGrid_ Then
                                IDGrid_ = NuloInteger(frmSalao.DataSetGrid.Tables(0).Rows(i).Item(4))
                            End If
                        Next
                        IDGrid_ += 1
                    End If
                End If

                IncluiProdGrid(IDGrid_, CodPVinc(ii), ProVinc(ii), VlrPVinc(ii), IDGrupoVinc(ii), 0, 0, 0, "P", QtdPVinc(ii), GrupoVinc(ii), CatVinc(ii), IDPVinc(ii), 0, IDGrid_, False)

            End If
        Next ii

        frmSalao.Enabled = True
        If Not isDebug Then
            ' frmSalao.TopMost = True
        End If

        Try
            frmDelivery.lbProduto.Text = ""
            frmDelivery.lbVenda.Text = ""

        Catch ex As Exception

        End Try



        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub tbCodPro_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCodPro.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Enter
                If tbCodPro.Text = "" Then
                    If NuloInteger(tbQtdeLinhas.Text) - 1 = NuloInteger(tbLinha.Text) Then
                        Me.InvokeOnClick(btnConfirma, e)
                    Else
                        If NuloInteger(tbLinha.Text) < NuloInteger(tbQtdeLinhas.Text) - 1 Then
                            tbLinha.Text = NuloInteger(tbLinha.Text) + 1
                        Else
                            tbLinha.Text = NuloInteger(tbQtdeLinhas.Text) - 1
                        End If
                        tbIDFamiliaSel.Text = Grid(1, NuloInteger(tbLinha.Text)).Value
                        Grid.Rows(NuloInteger(tbLinha.Text)).Selected = True
                        AtualizaGridProdutos()
                    End If
                End If

        End Select
    End Sub

    Private Sub fdlgCombo_porCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode

            Case Keys.KeyCode.F3
                Me.InvokeOnClick(btnLimpa, e)

            Case Keys.KeyCode.F7
                If tbCodPro.Text = "" Then
                    Me.InvokeOnClick(btnConfirma, e)
                End If

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVolta, e)

        End Select
    End Sub

    Private Sub Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellContentClick
        tbCodPro.Focus()
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

        For i As Integer = 0 To Grid.Rows.Count - 1
            If Grid.Rows(i).Selected = True Then
                tbLinha.Text = i
                tbIDFamiliaSel.Text = Grid(1, NuloInteger(tbLinha.Text)).Value
                AtualizaGridProdutos()
            End If
        Next

    End Sub

    Private Sub GridProdutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridProdutos.KeyPress

    End Sub

    Private Sub GridProdutos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridProdutos.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            tbIDProduto.Text = ""
            tbCodigoProduto.Text = ""
            tbVenda.Text = ""
            tbIDFamilia.Text = ""
            tbCodPro.Focus()

            If NuloString(tbCodPro.Text) <> "" Then
                If GridProdutos.Rows.Count > 0 Then
                    tbIDProduto.Text = NuloInteger(GridProdutos.Item("IDProduto", GridProdutos.CurrentRow.Index).Value)
                    tbCodigoProduto.Text = NuloInteger(GridProdutos.Item("CodigoProduto", GridProdutos.CurrentRow.Index).Value)
                    tbVenda.Text = NuloDecimal(GridProdutos.Item("Venda", GridProdutos.CurrentRow.Index).Value)
                    tbIDFamilia.Text = NuloInteger(GridProdutos.Item("IDFamilia", GridProdutos.CurrentRow.Index).Value)

                    EnviaProduto(tbCodigoProduto.Text)
                    If NuloBoolean(tbEPizza.Text) = False Then MontaDetalhes()
                    tbCodPro.Text = ""
                    AtualizaGridProdutos()
                End If
            End If
        End If
    End Sub

End Class