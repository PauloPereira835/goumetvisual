Imports System.Data.SqlClient
Public Class fdlgDelivery_Pagto
    Private Sub CalculaTotais()
        Dim VlrPagto As Decimal = 0
        For i As Integer = 0 To lstPagtos.Items.Count - 1
            VlrPagto += NuloDecimal(lstPagtos.Items(i).SubItems(3).Text)
        Next i
        lbTotalPagto.Text = Format(VlrPagto, "#0.00")

        lbTextoCaixinha.Visible = True
        lbCaixinha.Visible = True
        If NuloDecimal(VlrPagto) > NuloDecimal(lbTotalPagar.Text) Then
            lbTextoCaixinha.Text = "Sobra (caixinha)"
            lbCaixinha.Text = Format(NuloDecimal(VlrPagto) - NuloDecimal(lbTotalPagar.Text), "#0.00")
            lbCaixinha.ForeColor = Color.Maroon
            lbTextoCaixinha.ForeColor = Color.Blue
        Else
            If NuloDecimal(VlrPagto) < NuloDecimal(lbTotalPagar.Text) Then
                lbTextoCaixinha.Text = "FALTA"
                lbCaixinha.Text = Format(NuloDecimal(lbTotalPagar.Text) - NuloDecimal(VlrPagto), "#0.00")
                lbCaixinha.ForeColor = Color.Red
                lbTextoCaixinha.ForeColor = Color.Red
            Else
                lbTextoCaixinha.Visible = False
                lbCaixinha.Visible = False
                lbCaixinha.Text = 0
            End If
        End If



    End Sub

    Private Sub PreencheLista()
        Dim VlrTotal As Integer = 0
        Dim item As ListViewItem
        Dim strSql As String
        lstPagtos.Items.Clear()

        Dim con As New SqlConnection(strCon)

        strSql = "Select IDVendaPagto, IDVenda, IDFormaPagto, Descricao, ValorPago "
        strSql += "From tblVendasPagto "
        strSql += "Where (IDVenda = " & NuloInteger(tbIDVenda.Text) & ") "
        strSql += "Order By Descricao"

        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                item = lstPagtos.Items.Add(dr.Item("IDVendaPagto"))
                item.SubItems.Add(NuloInteger(dr.Item("IDFormaPagto")))
                item.SubItems.Add(NuloString(dr.Item("Descricao")))
                item.SubItems.Add(Format(NuloDecimal(dr.Item("ValorPago")), "#0.00"))
                VlrTotal += NuloDecimal(dr.Item("ValorPago"))
            End While
        Else
            Dim item_ As ListViewItem
            For i As Integer = 0 To frmDelivery.lstPagtosVenda.Items.Count - 1
                item_ = lstPagtos.Items.Add(frmDelivery.lstPagtosVenda.Items(i).SubItems(0).Text)
                item_.SubItems.Add(NuloInteger(frmDelivery.lstPagtosVenda.Items(i).SubItems(1).Text))
                item_.SubItems.Add(NuloString(frmDelivery.lstPagtosVenda.Items(i).SubItems(2).Text))
                item_.SubItems.Add(Format(NuloDecimal(frmDelivery.lstPagtosVenda.Items(i).SubItems(3).Text), "#0.00"))
                VlrTotal += NuloDecimal(frmDelivery.lstPagtosVenda.Items(i).SubItems(3).Text)
            Next i
        End If

        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        lbTotalPagto.Text = Format(NuloDecimal(VlrTotal), "#0.00")


    End Sub
    Private Sub PreenchePagto()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        strSql = "Select Descricao, IDFormaPagto, CodigoFormaPagto From tblFormaPagtos_Local Order By Descricao"

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            cbPagamento.Items.Add("")
            While (dr.Read())
                cbPagamento.Items.Add(NuloString(dr.Item("Descricao")) & Space(100) & NuloString(dr.Item("IDFormaPagto")))
            End While
        End If
        comandoLJS.Dispose()
        con.Dispose()
        con.Close()
        CalculaTotais()

    End Sub
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        Incluir()
    End Sub

    Private Sub Incluir()

        If NuloDecimal(tbValor.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloString(cbPagamento.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma forma de pagamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim item As ListViewItem

        item = lstPagtos.Items.Add(0)
        item.SubItems.Add(NuloInteger(Strings.Right(cbPagamento.Text, 8)))
        item.SubItems.Add(NuloString(Trim(Strings.Left(cbPagamento.Text, 50))))
        item.SubItems.Add(Format(NuloDecimal(tbValor.Text), "#0.00"))
        CalculaTotais()
        cbPagamento.Text = ""
        tbValor.Text = ""
        cbPagamento.Focus()


    End Sub
    Private Sub FdlgDelivery_Pagto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbIDVenda.Text = NuloInteger(frmDelivery.tbIDVenda.Text)
        lbProdutos.Text = Format(NuloDecimal(frmDelivery.txtProdutos.Text), "#0.00")
        lbDesconto.Text = Format(NuloDecimal(frmDelivery.txtDesconto.Text), "#0.00")
        lbTaxaEntrega.Text = Format(NuloDecimal(frmDelivery.txtServico.Text), "#0.00")
        lbTotalPagar.Text = Format(frmDelivery.txtProdutos.Text - frmDelivery.txtDesconto.Text + frmDelivery.txtServico.Text, "#0.00")

        tbValor.Text = Format(NuloDecimal(frmDelivery.txtTotal.Text) - NuloDecimal(frmDelivery.lbCaixinha.Text), "#0.00")

        PreenchePagto()
        PreencheLista()
        CalculaTotais()

    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If NuloDecimal(lbTotalPagto.Text) < NuloDecimal(lbTotalPagar.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Tota pagamento inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim item_ As ListViewItem
        frmDelivery.lstPagtosVenda.Items.Clear()
        For i As Integer = 0 To lstPagtos.Items.Count - 1
            item_ = frmDelivery.lstPagtosVenda.Items.Add(lstPagtos.Items(i).SubItems(0).Text)
            item_.SubItems.Add(NuloInteger(lstPagtos.Items(i).SubItems(1).Text))
            item_.SubItems.Add(NuloString(lstPagtos.Items(i).SubItems(2).Text))
            item_.SubItems.Add(Format(NuloDecimal(lstPagtos.Items(i).SubItems(3).Text), "#0.00"))
        Next i
        frmDelivery.tbCaixinha.Text = NuloDecimal(lbCaixinha.Text)
        frmDelivery.lbCaixinha.Text = Format(NuloDecimal(lbCaixinha.Text), "#0.00")
        frmDelivery.tbTotalPagto.Text = lbTotalPagto.Text

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CbPagamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPagamento.SelectedIndexChanged

        tbValor.Focus()
    End Sub

    Private Sub cbPagamento_Click(sender As Object, e As EventArgs) Handles cbPagamento.Click

    End Sub

    Private Sub TbValor_TextChanged(sender As Object, e As EventArgs) Handles tbValor.TextChanged

    End Sub

    Private Sub tbValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbValor.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            Incluir()

        End If
    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If lstPagtos.SelectedItems.Count > 0 Then
            For i As Integer = 0 To lstPagtos.Items.Count - 1
                If lstPagtos.Items(i).Selected = True Then
                    If NuloInteger(lstPagtos.Items(i).SubItems(0).Text) = 0 Then
                        lstPagtos.Items(i).Remove()
                        Exit For
                    Else
                        ExecutaStr("DELETE FROM tblVendasPagto WHERE IDVendaPagto=" & NuloInteger(lstPagtos.Items(i).SubItems(0).Text))
                        lstPagtos.Items(i).Remove()
                        Exit For
                    End If
                End If
            Next
            CalculaTotais()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um lançamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


    End Sub

    Private Sub fdlgDelivery_Pagto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVolta, e)

        End Select
    End Sub
End Class