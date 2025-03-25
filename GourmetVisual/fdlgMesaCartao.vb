Imports System.Data.SqlClient

Public Class fdlgMesaCartao
    Private Sub AtualizaProdutos()

        If tbStatus.Text = "" And MesaCartao = "" Then Exit Sub
        If tbStatus.Text <> "" And lbMesa.Text = "" Then Exit Sub

        Dim QtdItens As Integer = 0
        Dim Total As Decimal = 0
        Dim ValorItem As Decimal
        Dim NumMesa As Integer
        Dim IDMovto As Integer
        Dim entrou As Integer = 0
        Dim NMesa As String = lbMesa.Text

        GridProdutos.Rows.Clear()

        strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasMovto.IDVenda, tblVendasMovto.MesaCartao, tblVendas.NumMesa, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasComent_1.Coment, tblVendasMovto.Categoria, tblVendasMovto.Excluido, tblVendasMovto.Impresso, tblVendasMovto.HoraPedido, tblVendasMovto.IDFuncionario, tblVendasMovto.Atendente, tblVendasMovto.StatusTransf, tblVendasMovto.Terminal, tblVendasMovto.Imprime, tblVendasMovto.Enviado, tblVendas.FlagFechada, tblVendasCombo.Produto As ProdutoCombo, tblVendasComent.Coment AS ComentCombo "
        strSql += "From tblVendasComent INNER Join tblVendasCombo On tblVendasComent.IDVendaCombo = tblVendasCombo.IDVendaCombo RIGHT OUTER Join tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda ON tblVendasCombo.IDVendaMovto = tblVendasMovto.IDVendaMovto LEFT OUTER Join tblVendasComent As tblVendasComent_1 On tblVendasMovto.IDVendaMovto = tblVendasComent_1.IDVendaMovto "
        If tbStatus.Text = "" Then
            strSql += "Where (tblVendasMovto.Excluido = 0) And (tblVendasMovto.MesaCartao = " & MesaCartao & ") AND (tblVendasMovto.Enviado = 0) AND (tblVendas.FlagFechada = 0) "
        Else
            strSql += "Where (tblVendasMovto.Excluido = 0) And (tblVendasMovto.MesaCartao = " & lbMesa.Text & ") AND (tblVendasMovto.Enviado = 1) AND (tblVendas.FlagFechada = 0) "
        End If
        strSql += "ORDER BY tblVendas.NumMesa, tblVendasMovto.Produto"


        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            IDMovto = ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")
            lbMesa.Text = MesaCartao
            lbTerminal.Text = ds.Tables("Vendas").Rows(i).Item("Terminal")
            lbAtendente.Text = ds.Tables("Vendas").Rows(i).Item("Atendente")

            NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa")
            ValorItem = ds.Tables("Vendas").Rows(i).Item("Qtd") * ds.Tables("Vendas").Rows(i).Item("Venda")
            If entrou = 0 Then
                GridProdutos.Rows.Add({"", ">>> CARTÃO  " & NumMesa, "", "", ""})
                GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ds.Tables("Vendas").Rows(i).Item("Produto"), ds.Tables("Vendas").Rows(i).Item("Qtd"), ds.Tables("Vendas").Rows(i).Item("Venda"), Format(ValorItem, "#0.00"), "  " & ds.Tables("Vendas").Rows(i).Item("Categoria"), ds.Tables("Vendas").Rows(i).Item("Atendente"), ds.Tables("Vendas").Rows(i).Item("HoraPedido")})
                entrou = 1
            Else
                GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ds.Tables("Vendas").Rows(i).Item("Produto"), ds.Tables("Vendas").Rows(i).Item("Qtd"), ds.Tables("Vendas").Rows(i).Item("Venda"), Format(ValorItem, "#0.00"), "  " & ds.Tables("Vendas").Rows(i).Item("Categoria"), ds.Tables("Vendas").Rows(i).Item("Atendente"), ds.Tables("Vendas").Rows(i).Item("HoraPedido")})
            End If
            Total += ValorItem
            QtdItens += 1
            While NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa") And IDMovto = ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")
                If IsDBNull(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) Then
                    While Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("Coment")) And NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa")
                        GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   (" & ds.Tables("Vendas").Rows(i).Item("Coment") & ")", "", "", "", "", "", ""})
                        If (i + 1) > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If IsDBNull(ds.Tables("Vendas").Rows(i + 1).Item("Coment")) Or NumMesa = ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") Then Exit While
                        i += 1
                    End While
                    If (i + 1) <= ds.Tables("Vendas").Rows.Count - 1 Then
                        If NumMesa = ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") And Not IsDBNull(ds.Tables("Vendas").Rows(i + 1).Item("Coment")) And IDMovto = ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto") Then
                            ValorItem = ds.Tables("Vendas").Rows(i + 1).Item("Qtd") * ds.Tables("Vendas").Rows(i + 1).Item("Venda")
                            GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ds.Tables("Vendas").Rows(i + 1).Item("Produto"), ds.Tables("Vendas").Rows(i + 1).Item("Qtd"), ds.Tables("Vendas").Rows(i + 1).Item("Venda"), Format(ValorItem, "#0.00"), "  " & ds.Tables("Vendas").Rows(i + 1).Item("Categoria"), ds.Tables("Vendas").Rows(i).Item("Atendente"), ds.Tables("Vendas").Rows(i).Item("HoraPedido")})
                            Total += ValorItem
                            QtdItens += 1
                        End If
                        If (i + 1) > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If NumMesa <> ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") Then
                            GridProdutos.Rows.Add({"", "", "", "", "", "", ""})
                            entrou = 0
                            Exit While
                        End If
                        If IDMovto <> ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto") Then Exit While
                        i += 1
                    Else
                        Exit While
                    End If
                Else
                    While Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")) And NumMesa = ds.Tables("Vendas").Rows(i).Item("NumMesa")
                        GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   + " & ds.Tables("Vendas").Rows(i).Item("ProdutoCombo"), "", "", "", "", "", ""})

                        If Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("ComentCombo")) Then
                            GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   (" & ds.Tables("Vendas").Rows(i).Item("ComentCombo") & ")", "", "", "", "", "", ""})
                        End If


                        If (i + 1) > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If IsDBNull(ds.Tables("Vendas").Rows(i + 1).Item("ProdutoCombo")) Or NumMesa = ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") Then Exit While
                        i += 1
                    End While
                    If (i + 1) <= ds.Tables("Vendas").Rows.Count - 1 Then
                        If NumMesa = ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") And ds.Tables("Vendas").Rows(i).Item("ProdutoCombo") <> "" And IDMovto <> ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto") Then
                            GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   + " & ds.Tables("Vendas").Rows(i).Item("ProdutoCombo"), "", "", "", "", "", ""})
                            If Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("ComentCombo")) Then
                                GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   (" & ds.Tables("Vendas").Rows(i).Item("ComentCombo") & ")", "", "", "", "", "", ""})
                            End If
                        End If
                        If (i + 1) > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If NumMesa <> ds.Tables("Vendas").Rows(i + 1).Item("NumMesa") Then
                            GridProdutos.Rows.Add({"", "", "", "", "", "", ""})
                            entrou = 0
                            Exit While
                        End If
                        If IDMovto <> ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto") Then
                            If Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("Coment")) Then
                                GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), "   (" & ds.Tables("Vendas").Rows(i).Item("Coment") & ")", "", "", "", "", "", ""})
                            End If
                            Exit While
                        End If
                        i += 1
                    Else
                        If Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("Coment")) Then
                            GridProdutos.Rows.Add({ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"), ">>>(" & ds.Tables("Vendas").Rows(i).Item("Coment") & ")", "", "", "", "", "", ""})
                        End If
                        Exit While
                    End If
                End If
            End While

        Next
        lbTotalItens.Text = "Qtde. de itens: " & QtdItens
        lbValorTotal.Text = Format(Total, "#0.00")
        Estilo()
        lbMesa.Text = NMesa

    End Sub
    Private Sub Estilo()
        Dim fontCartao As New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        Dim fontComent As New Font("Microsoft Sans Serif", 7, FontStyle.Italic)
        Dim fontRegular As New Font("Microsoft Sans Serif", 10, FontStyle.Regular)

        If GridProdutos.Rows.Count > 0 Then
            For i As Integer = 0 To GridProdutos.Rows.Count - 1
                If NuloString(GridProdutos.Item(0, i).Value) = "" And Strings.Left(GridProdutos.Item(1, i).Value, 3) = ">>>" Then
                    GridProdutos.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    GridProdutos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    GridProdutos.Rows(i).DefaultCellStyle.Font = fontCartao
                Else
                    If Strings.Left(GridProdutos.Item(1, i).Value, 4) = "   (" And NuloString(GridProdutos.Item(2, i).Value) = "" Then
                        GridProdutos.Rows(i).DefaultCellStyle.Font = fontComent
                    End If
                End If
                GridProdutos.Rows(i).Selected = False
            Next

        End If


    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgMesaCartao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AtualizaProdutos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim IDMovto As Integer = NuloInteger(GridProdutos.Item(0, GridProdutos.CurrentRow.Index).Value)

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If IDMovto = 0 Then
            frm.lbMensagem.Text = "Lançamento inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Deseja realmente limpar este produto" & vbCrLf & GridProdutos.Item(2, GridProdutos.CurrentRow.Index).Value
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        ExecutaStr("DELETE From tblVendasMovto WHERE IDVendaMovto=" & IDMovto)
        ExecutaStr("DELETE From tblVendasComent WHERE IDVendaMovto=" & IDMovto)
        ExecutaStr("DELETE From tblVendasCombo WHERE IDVendaMovto=" & IDMovto)
        AtualizaProdutos()

    End Sub

    Private Sub fdlgMesaCartao_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        AtualizaProdutos()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        lbMesa.Text &= "0"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        lbMesa.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        lbMesa.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        lbMesa.Text &= "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        lbMesa.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        lbMesa.Text &= "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lbMesa.Text &= "6"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        lbMesa.Text &= "7"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lbMesa.Text &= "8"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        lbMesa.Text &= "9"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        lbMesa.Text = ""
    End Sub
End Class