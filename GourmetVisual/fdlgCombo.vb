Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class fdlgCombo

    Dim SaboresTotal As Integer

    Private Sub CliqueNoBotao(texto As String)
        If tbTextoLivre.TextLength < 25 Then
            tbTextoLivre.Text &= texto
            lbLetras.Text = (25 - tbTextoLivre.TextLength).ToString
        End If
    End Sub
    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        ' Proximo ID do Grid ////////////////////////////////////////////////////////////////////////////////////////////
        Dim IDGrid_ As Integer
        Dim IDGridComb As Integer
        Dim Qtde As Double
        Dim VlrProd As Decimal
        Dim ContVinc As Integer = 0

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
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Dim dv As New DataView(DataSetGrid.Tables(0))
        Dim SeqSabor As Integer = 1
        dv.Sort = "ID"
        IDGridComb = NuloInteger(dv.Item(0)("ID"))

        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo "
        strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
        strSql += "Where (tblProdutos_Local.CodigoProduto =" & NuloInteger(CodProdutoSel) & ")"
        IDGrupo = NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon))
        Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))

        'IncluiProdGrid(IDGrid_, CodProdutoSel, lbProduto.Text, NuloDecimal(tbValor.Text), IDGrupo, NuloInteger(IDFamiliaSel.Text), 0, 0, "P", NuloInteger(TBQtde.Text), Grupo, Categoria, IDProdutoSel, 0, IDGrid_, False)
        IncluiProdGrid(IDGrid_, CodProdutoSel, lbProduto.Text, NuloDecimal(tbValor.Text), IDGrupo, NuloInteger(tbIDFamilia.Text), 0, 0, "P", NuloInteger(TBQtde.Text), Grupo, Categoria, IDProdutoSel, 0, IDGrid_, False)

        If chkPizza.Checked = True Then
            Dim QtdeSabor As Integer = 0
            If Grid.Rows.Count > 0 Then
                For iii = 0 To Grid.Rows.Count - 1
                    If NuloString(Grid.Item(2, iii).Value) <> "                                   ----->" And NuloString(Grid.Item(4, iii).Value) <> "" Then
                        QtdeSabor += 1
                    End If
                Next
            End If
            tbSabores.Text = NuloString(QtdeSabor)
        End If

        For i = 0 To dv.Count - 1
            If IDGridComb <> NuloInteger(dv.Item(0)("ID")) Then
                IDGridComb = NuloInteger(dv.Item(0)("ID"))
                IDGrid_ += 1
            End If

            If NuloInteger(dv.Item(i)("IDDetalhe")) = 0 Then
                FamiliaSel = Trim(NuloString(dv.Item(i)("Familia")))

                If chkPizza.Checked = True Then
                    Qtde = NuloInteger(TBQtde.Text) / NuloInteger(tbSabores.Text)
                    If NuloInteger(tbSabores.Text) = 3 And SeqSabor = 3 Then
                        Qtde = CDbl(Format(Qtde + 0.001, "#0.000"))
                    Else
                        Qtde = CDbl(Format(Qtde, "#0.000"))
                    End If
                    SeqSabor += 1
                Else
                    Qtde = NuloInteger(TBQtde.Text)
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
                        If chkPizza.Checked = True Then
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
                        Categoria = NuloString(PegaValorCampo("Categoria", strSql, strCon))

                        'IncluiProdGrid(IDGrid_, NuloInteger(drV.Item("IDProduto")), NuloString(dv.Item(i)("Produto")), VlrProd, IDGrupo, NuloInteger(dv.Item(i)("IDFamilia")), 0, NuloInteger(dv.Item(i)("IDMontagem")), "PC", Qtde, Grupo, Categoria, NuloInteger(dv.Item(i)("IDProduto")), 0, IDGrid_, False)
                        IncluiProdGrid(IDGrid_, NuloInteger(drV.Item("IDProduto")), NuloString(dv.Item(i)("Produto")), VlrProd, IDGrupo, NuloInteger(tbIDFamilia.Text), 0, NuloInteger(dv.Item(i)("IDMontagem")), "PC", Qtde, Grupo, Categoria, NuloInteger(dv.Item(i)("IDProduto")), 0, IDGrid_, False)

                    End If

                    drV.Close()
                    cmdV.Dispose()
                    conV.Dispose()
                    conV.Close()
                End If
            Else
                IncluiProdGrid(IDGrid_, 0, NuloString(dv.Item(i)("Produto")), 0, 0, NuloInteger(tbIDFamilia.Text), NuloInteger(dv.Item(i)("IDDetalhe")), 0, "MC", 1, "", "", 0, 0, IDGrid_, False)
                If NuloInteger(dv.Item(i)("IDProdutoVinculado")) <> 0 Then
                    Dim conV As New SqlConnection()
                    Dim drV As SqlDataReader

                    conV.ConnectionString = strCon
                    Dim cmdV As SqlCommand = conV.CreateCommand

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
                'strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo "
                'strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
                'strSql += "Where (tblProdutos_Local.CodigoProduto =" & NuloInteger(CodPVinc(ii)) & ")"
                'Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))
                IncluiProdGrid(IDGrid_, CodPVinc(ii), ProVinc(ii), VlrPVinc(ii), IDGrupoVinc(ii), 0, 0, 0, "P", QtdPVinc(ii), GrupoVinc(ii), CatVinc(ii), IDPVinc(ii), 0, IDGrid_, False)
            End If
        Next ii

        frmSalao.Enabled = True
        If Not isDebug Then
            ' frmSalao.TopMost = True
        End If

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub IncluiGrid()

        Dim n As Integer = 0
        Dim IDGrid As Integer = 0
        Dim Coluna As Integer = 0

        Dim con As New SqlConnection()

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        'cmd.CommandText = "Select tblProdutos.CodigoProduto, tblProdutos.Produto, tblFamilias.IDFamilia, tblFamilias.Familia, tblProdutosLojas.IDLoja From tblProdutos INNER Join tblProdutosLojas On tblProdutos.IDProduto = tblProdutosLojas.IDProduto INNER Join tblCombos On tblProdutosLojas.IDLojaProduto = tblCombos.IDLojaProduto INNER Join tblCombosDescricao On tblCombos.IDCombo = tblCombosDescricao.IDCombo INNER Join tblFamilias On tblCombosDescricao.IDFamilia = tblFamilias.IDFamilia Where (tblProdutosLojas.IDLoja = " & IDLoja & ") And (tblProdutos.CodigoProduto = " & CodProdutoSel & ") ORDER BY tblFamilias.Familia"
        cmd.CommandText = "Select tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblFamilias_Local.IDFamilia, tblFamilias_Local.Familia From tblProdutos_Local INNER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto INNER Join tblFamilias_Local On tblCombos_Local.IDFamilia = tblFamilias_Local.IDFamilia Where (tblProdutos_Local.CodigoProduto = " & CodProdutoSel & ") Order By tblFamilias_Local.Familia"


        If Me.DataSetGrid.Tables(0).Rows.Count = 0 Then
            IDGrid = 1
        Else
            For i As Integer = 0 To Me.DataSetGrid.Tables(0).Rows.Count - 1
                If NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(0)) > IDGrid Then
                    IDGrid = NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(0))
                    Exit For
                End If
            Next
            IDGrid += 1
        End If

        Dim nova_linha As DataRow = frmSalao.DataSetGrid.Tables(0).NewRow()

    End Sub

    Private Sub MontaProdutos()
        Dim n As Integer = 0

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        'Dim ValorVenda As String

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select IDProduto, Produto, IDFamilia, Venda "
        strSql += "From tblProdutos_Local "
        strSql += "Where (IDFamilia = " & IDFamiliaSel.Text & ") And (IDProduto <> " & IDProdutoSel & ") And (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%S%' OR tblProdutos_Local.Modulos Like '%B%') "
        strSql += "Order By Produto"

        cmd.CommandText = strSql

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            Dim myfont As New Font("Sans Serif", 7, FontStyle.Bold)
            Dim btnArrayPro(150) As System.Windows.Forms.Button
            For i As Integer = 0 To 150
                btnArrayPro(i) = New System.Windows.Forms.Button
            Next i

            Me.PanelProdutos.Controls.Clear()

            If dr.HasRows Then
                While (dr.Read())
                    With (btnArrayPro(n))
                        .Tag = dr.Item("IDProduto")
                        .Text = dr.Item("Produto").ToString
                        .AccessibleDescription = dr.Item("Venda").ToString
                        .Width = 122
                        .Height = 48
                        '.Height = 34
                        .BackColor = Color.AliceBlue
                        .Font = myfont
                        .ForeColor = Color.Black

                        frmPagamento.carregaVisualComponente(btnArrayPro(n), 20, 20)
                        .FlatStyle = FlatStyle.Flat
                        .FlatAppearance.BorderSize = 0
                        .Margin = New Padding(0, 0, 0, 0)

                        Me.PanelProdutos.Controls.Add(btnArrayPro(n))

                        AddHandler .Click, AddressOf Me.ClickButton_Produtos
                        n += 1
                    End With
                End While
            End If
            'For i As Integer = 0 To Grid.Rows.Count - 1
            'Grid.Rows(i).Selected = False
            'Next

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub
    Private Sub ClickButton_Produtos(ByVal sender As Object, ByVal e As System.EventArgs)

        If NuloInteger(Grid(5, Grid.CurrentRow.Index).Value) > 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Não é possível incluir um PRODUTO nesta Botao"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        Dim LinhaSel As Integer = 999
        For i As Integer = 0 To Grid.Rows.Count - 1
            If Grid.Rows(i).Selected = True Then
                LinhaSel = i
            End If
        Next

        Dim btn As Button = CType(sender, Button)
        Grid(4, LinhaSel).Value = btn.Text
        Grid(3, LinhaSel).Value = btn.Tag
        Grid(8, LinhaSel).Value = btn.AccessibleDescription

        CalculaValor()

        For i As Integer = 0 To Grid.Rows.Count - 1
            If Grid.Rows(i).Selected = True Then
                'MsgBox(NuloString(NuloInteger(Grid.Rows(i).Cells(2).Value)))
                If i < NuloInteger(tbQtdeGrid.Text) And NuloString(Grid.Rows(i).Cells(2).Value) <> "                                   ----->" Then
                    Grid.Rows(i + 1).Selected = True
                    IDFamiliaSel.Text = NuloString(NuloInteger(Grid.Rows(i + 1).Cells(1).Value))
                    'IDProdutoSel = NuloInteger(Grid.Rows(i + 1).Cells(3).Value)
                    Exit For
                End If
            End If
        Next
        MontaProdutos()
        MontaDetalhes()


    End Sub
    Private Sub CalculaValor()
        Dim somaValor As Decimal = VlrUnitario
        Dim ValorReal As Decimal = VlrUnitario
        Dim Sabores As Decimal = 0
        For i As Integer = 0 To Grid.Rows.Count - 1
            If Not IsDBNull(Grid.Rows(i).Cells(9).Value) Then
                If NuloInteger(Grid.Rows(i).Cells(3).Value) > 0 And NuloInteger(Grid.Rows(i).Cells(5).Value) = 0 Then
                    Sabores += 1
                Else
                    Dim con As New SqlConnection()
                    Dim dr As SqlDataReader

                    con.ConnectionString = strCon
                    Dim cmd As SqlCommand = con.CreateCommand
                    cmd.CommandText = "Select IDProduto, Venda From tblProdutos_Local Where (IDProduto = " & NuloString(Grid.Rows(i).Cells(9).Value) & ")"

                    con.Open()
                    dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    If dr.HasRows Then
                        dr.Read()
                        somaValor += NuloDecimal(dr.Item("Venda")) / Sabores
                        ValorReal += NuloDecimal(dr.Item("Venda")) / Sabores
                    End If
                    con.Close()
                    con.Dispose()

                End If
                'somaValor += Convert.ToInt32(Grid.Rows(i).Cells(8).Value)
            Else
                Dim con As New SqlConnection()
                Dim dr As SqlDataReader

                con.ConnectionString = strCon
                Dim cmd As SqlCommand = con.CreateCommand
                cmd.CommandText = "Select IDProduto, Venda From tblProdutos_Local Where (IDProduto = " & NuloString(Grid.Rows(i).Cells(3).Value) & ")"

                con.Open()
                dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If dr.HasRows Then
                    dr.Read()
                    If NuloString(Grid.Rows(i).Cells(5).Value) = "0" Then
                        somaValor += NuloDecimal(dr.Item("Venda"))
                        ValorReal += NuloDecimal(dr.Item("Venda"))
                        Sabores += 1
                    Else
                        somaValor += NuloDecimal(Grid.Rows(i).Cells(11).Value)
                        ValorReal += NuloDecimal(Grid.Rows(i).Cells(11).Value)
                    End If
                End If
                con.Close()
                con.Dispose()

                'If NuloDecimal(Grid.Rows(i).Cells(3).Value) <> 0 Then
                'somaValor += Convert.ToInt32(Grid.Rows(i).Cells(8).Value)
                'ValorReal += Convert.ToInt32(Grid.Rows(i).Cells(8).Value)
                'Sabores += 1
                'End If

            End If
        Next

        tbSabores.Text = CType(Sabores, String)

        If AgregaValor = True Then
            If EGrupoPizza = True Then
                ' Calculo valor pela media quando pizza
                tbValor.Text = NuloDecimal(somaValor / Sabores).ToString("F2") 'F2 = 2 Casas Decimais
                tbValorReal.Text = NuloDecimal(ValorReal / Sabores).ToString("F2") 'F2 = 2 Casas Decimais
            Else
                ' Calculo agregando valor
                tbValor.Text = NuloDecimal(somaValor).ToString("F2") 'F2 = 2 Casas Decimais
                tbValorReal.Text = NuloDecimal(ValorReal).ToString("F2") 'F2 = 2 Casas Decimais
            End If
        End If
    End Sub
    Private Sub MontaDetalhes()
        Dim n As Integer = 0

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        'cmd.CommandText = "Select tblComentarios.IDComentario, tblComentariosFamilias.IDFamilia, tblComentarios.Comentario From tblFamilias INNER Join tblComentariosFamilias On tblFamilias.IDFamilia = tblComentariosFamilias.IDFamilia INNER Join tblComentarios On tblComentariosFamilias.IDComentario = tblComentarios.IDComentario Where (tblComentariosFamilias.IDFamilia = " & IDFamiliaSel.Text & ") Order By tblComentarios.Comentario"
        cmd.CommandText = "Select tblComentarios_Local.IDComentario, tblFamilias_Local.IDFamilia, tblComentarios_Local.Comentario From tblComentarios_Local INNER Join tblFamilias_Local On tblComentarios_Local.IDFamilia = tblFamilias_Local.IDFamilia Where (tblFamilias_Local.IDFamilia = " & IDFamiliaSel.Text & ") Order By tblComentarios_Local.Comentario"

        ' Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim myfont As New Font("Sans Serif", 6, FontStyle.Bold)
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
                    .Width = 110
                    .Height = 30
                    '.BackColor = Color.PaleGreen
                    .BackColor = Color.White
                    .Font = myfont
                    .ForeColor = Color.DarkBlue
                    .Font = myfont

                    frmPagamento.carregaVisualComponente(btnArrayPro(n), 20, 20)
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0
                    .Margin = New Padding(0, 0, 0, 0)

                    Me.PanelDetalhes.Controls.Add(btnArrayPro(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Detalhes
                    n += 1
                End With
            End While
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        'con.Close()
        'con.Dispose()
        'End Try

    End Sub
    Private Sub ClickButton_Detalhes(ByVal sender As Object, ByVal e As System.EventArgs)

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

        If NuloInteger(Grid(3, Grid.CurrentRow.Index).Value) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Produto inválido"
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
                'nova_linha.ItemArray = New Object() {IDGrid, IDFam, "                                   ----->", IDProd, Detalhe, IDDetalhe, String.Empty, 0, 0, dr.Item("IDProduto"), 0, Format(NuloDecimal(dr.Item("Venda"), "#0.00"))}
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

        LimpaSelecao()

        dr.Close()
        con.Dispose()
        con.Close()
        Me.Grid.Sort(Me.Grid.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        StiloGrid()
    End Sub
    Private Sub LimpaSelecao()
        Grid.ClearSelection()
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

            If AgregaValor = True Then
                If NuloDecimal(Grid.Rows(i).Cells(9).Value) = 0 Then
                    'Grid.Rows(i).Cells(9).Value = ""
                    Grid(8, i).Value = 0
                Else
                    Grid(8, i).Value = Format(Grid.Rows(i).Cells(8).Value, "#0.00")
                End If
            Else
                Grid(8, i).Value = 0
            End If

        Next
    End Sub
    Private Sub fdlgCombo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmSalao.TimerTela.Enabled = False
        tbIDFamilia.Text = NuloString(IDFami)

        lbProduto.Text = ProdutoSel
        tbValor.Text = NuloString(VlrUnitario)
        MontaGrid_Combo()
        MontaProdutos()
        MontaDetalhes()
        chkPizza.Checked = EGrupoPizza

        frmPagamento.carregaVisualComponente(Button2, 10, 10)
        frmPagamento.carregaVisualComponente(Button3, 10, 10)
        frmPagamento.carregaVisualComponente(Button4, 10, 10)
        frmPagamento.carregaVisualComponente(Button44, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfirma, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfirma, 10, 10)
        frmPagamento.carregaVisualComponente(btnLimpa, 10, 10)



    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs)
        MontaGrid_Combo()
    End Sub


    Private Sub btnLimpa_Click(sender As Object, e As EventArgs) Handles btnLimpa.Click

        DataSetGrid.Clear()
        Grid.ClearSelection()
        MontaGrid_Combo()

        lbProduto.Text = ProdutoSel
        tbValor.Text = NuloString(VlrUnitario)
        Grid.Rows(0).Selected = True
        IDFamiliaSel.Text = NuloString(NuloInteger(Grid.Rows(0).Cells(1).Value))
        MontaProdutos()
        MontaDetalhes()

        tbSabores.Text = ""

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmSalao.Enabled = True
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        TBQtde.Text = NuloString(NuloInteger(TBQtde.Text) + 1)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        TBQtde.Text = NuloString(NuloInteger(TBQtde.Text) - 1)
        If TBQtde.Text = "0" Then TBQtde.Text = "1"

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

    Private Sub Button39_Click_1(sender As Object, e As EventArgs) Handles Button39.Click
        CliqueNoBotao("4")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CliqueNoBotao("5")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CliqueNoBotao("6")
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
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

    Private Sub Button19_Click_1(sender As Object, e As EventArgs) Handles Button19.Click
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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If tbTextoLivre.Text <> String.Empty Then
            tbTextoLivre.Text = Strings.Left(tbTextoLivre.Text, Len(tbTextoLivre.Text) - 1)
            lbLetras.Text = (25 - tbTextoLivre.TextLength).ToString
        End If
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

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
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
        If NuloInteger(Grid(3, Grid.CurrentRow.Index).Value) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Produto inválido"
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
        Dim Detalhe As String = tbTextoLivre.Text

        Dim nova_linha As DataRow = Me.DataSetGrid.Tables(0).NewRow()
        nova_linha.ItemArray = New Object() {IDGrid, IDFam, "                                   ----->", IDProd, Detalhe, 999, String.Empty}
        Me.DataSetGrid.Tables(0).Rows.Add(nova_linha)
        tbTextoLivre.Text = ""
        Me.Grid.Sort(Me.Grid.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        StiloGrid()

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click
        IDFamiliaSel.Text = NuloString(Grid.Item(1, Grid.CurrentRow.Index).Value)
        ID_Grid.Text = NuloString(Grid.Item(0, Grid.CurrentRow.Index).Value)
        MontaProdutos()
        MontaDetalhes()
    End Sub

    Private Sub fdlgCombo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub



    Private Sub PanelProdutos_Paint(sender As Object, e As PaintEventArgs) Handles PanelProdutos.Paint

    End Sub

    Private Sub Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub

    Private Sub PanelDetalhes_Paint(sender As Object, e As PaintEventArgs) Handles PanelDetalhes.Paint

    End Sub

End Class