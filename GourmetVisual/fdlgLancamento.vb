Imports System.Data.SqlClient

Public Class fdlgLancamento
    Private Sub AchaProduto(IDMovto As Integer)

        AchaComent(IDMovto)
        'Dim con As New SqlConnection()
        strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Atendente, tblVendasMovto.HoraPedido, tblVendasMovto.Terminal, tblVendasMovto.Categoria, tblVendasMovto.Comanda, tblVendasMovto.MesaCartao, tblVendasMovto.MotivoEstorno, tblVendasMovto.StatusTransf "
        strSql += "From tblVendasMovto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
        strSql += "Group By tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasMovto.IDVendaMovto, tblVendasMovto.Atendente, tblVendasMovto.HoraPedido, tblVendasMovto.Terminal, tblVendasMovto.Categoria, tblVendasMovto.Comanda, tblVendasMovto.MesaCartao, tblVendasMovto.MotivoEstorno, tblVendasMovto.StatusTransf "
        strSql += "HAVING(tblVendasMovto.IDVendaMovto = " & IDMovto & ") "
        strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Produto")
        For i As Integer = 0 To ds.Tables("Produto").Rows.Count - 1
            lbProduto.Text = NuloString(ds.Tables("Produto").Rows(i).Item("Produto"))
            lbAtendente.Text = NuloString(ds.Tables("Produto").Rows(i).Item("Atendente"))
            lbHoraPedido.Text = NuloString(ds.Tables("Produto").Rows(i).Item("HoraPedido"))
            lbTerminal.Text = NuloString(ds.Tables("Produto").Rows(i).Item("Terminal"))
            lbCategoria.Text = NuloString(ds.Tables("Produto").Rows(i).Item("Categoria"))
            lbComanda.Text = NuloString(ds.Tables("Produto").Rows(i).Item("Comanda"))
            lbStatus.Text = NuloString(ds.Tables("Produto").Rows(i).Item("StatusTransf"))
            lbMotivo.Text = NuloString(ds.Tables("Produto").Rows(i).Item("MotivoEstorno"))
            If NuloString(ds.Tables("Produto").Rows(i).Item("MesaCartao")) <> "" Then
                lbMesaCartao.Visible = True
                lbMesaDestino.Visible = True
                lbMesaCartao.Text = NuloString(ds.Tables("Produto").Rows(i).Item("MesaCartao"))
            End If
            If NuloInteger(ds.Tables("Produto").Rows(i).Item("IDVendaCombo")) <> 0 Then
                tbComposicao.Text &= NuloString(ds.Tables("Produto").Rows(i).Item("ProdutoCombo")) & vbCrLf
                AchaComentCombo(NuloInteger(ds.Tables("Produto").Rows(i).Item("IDVendaCombo")))
            End If

        Next


    End Sub
    Private Sub AchaComentCombo(IDMovtoComb As Integer)

        strSql = "Select tblVendasCombo.IDVendaCombo, tblVendasComent.Coment "
        strSql += "From tblVendasComent INNER Join tblVendasCombo On tblVendasComent.IDVendaCombo = tblVendasCombo.IDVendaCombo "
        strSql += "Where (tblVendasCombo.IDVendaCombo = " & IDMovtoComb & ") "
        strSql += "Order By tblVendasComent.Coment"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Coment")
        For i As Integer = 0 To ds.Tables("Coment").Rows.Count - 1
            tbComposicao.Text &= "  > " & NuloString(ds.Tables("Coment").Rows(i).Item("Coment")) & vbCrLf
        Next


    End Sub
    Private Sub AchaComent(IDMovtoCom As Integer)

        strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasComent.Coment "
        strSql += "From tblVendasMovto INNER Join tblVendasComent On tblVendasMovto.IDVendaMovto = tblVendasComent.IDVendaMovto "
        strSql += "Where (tblVendasMovto.IDVendaMovto = " & IDMovtoCom & ") "
        strSql += "Order By tblVendasComent.Coment"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Coment")
        For i As Integer = 0 To ds.Tables("Coment").Rows.Count - 1
            tbComentarios.Text &= NuloString(ds.Tables("Coment").Rows(i).Item("Coment")) & vbCrLf
        Next


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgLancamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ReimprimeComanda = True Then
            btnReimprimir.Visible = True
        End If
        AchaProduto(tbIDVendaMovto.Text)

    End Sub

    Private Sub fdlgLancamento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVoltar, e)


        End Select
    End Sub

    Private Sub BtnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click

        strSql = "UPDATE tblVendasMovto SET "
        strSql &= "Impresso=0 "
        strSql += "WHERE (IDVendaMovto = " & NuloInteger(tbIDVendaMovto.Text) & ")"
        ExecutaStr(strSql)
        Me.Dispose()
        Me.Close()

    End Sub
End Class