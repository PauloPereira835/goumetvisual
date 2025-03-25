Imports System.Data.SqlClient

Public Class fdlgDeliveryEnderecoEntrega
    Private Sub BuscaPeloCEP()

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If Len(Replace(tbBuscaRuas.Text, "-", "")) <> 8 Then
            frm.lbMensagem.Text = "CEP inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If Replace(tbBuscaRuas.Text, "-", "") = "00000000" Then
            frm.lbMensagem.Text = "CEP inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If Not IsNumeric(Replace(tbBuscaRuas.Text, "-", "")) Then
            frm.lbMensagem.Text = "CEP inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If tbBuscaRuas.Text = "" Then
            frm.lbMensagem.Text = "CEP inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        'cbTipoLogradouro.Text = ""
        tbLogradouro.Text = ""
        tbBairro.Text = ""
        tbCidade.Text = ""
        tbEstado.Text = ""
        tbArea.Text = ""
        tbCEP.Text = ""
        lbTaxaEntrega.Text = ""

        strSql = "Select tblRuas.IDRua, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblAreas.TaxaEntrega, tblRuasCep.CEP "
        strSql += "From tblRuas INNER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua LEFT OUTER Join tblAreas On tblRuas.Area = tblAreas.Area "
        strSql += "WHERE (tblRuasCep.CEP = '" & tbBuscaRuas.Text & "')"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            tbLogradouro.Text = NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro"))
            tbBairro.Text = NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro"))
            tbCidade.Text = NuloString(ds.Tables("Ruas").Rows(i).Item("Cidade"))
            tbEstado.Text = NuloString(ds.Tables("Ruas").Rows(i).Item("Estado"))
            tbArea.Text = NuloString(ds.Tables("Ruas").Rows(i).Item("Area"))
            lbTaxaEntrega.Text = NuloDecimal(ds.Tables("Ruas").Rows(i).Item("TaxaEntrega"))
            tbCEP.Text = tbBuscaRuas.Text
            tbIDRua.Text = NuloInteger(ds.Tables("Ruas").Rows(i).Item("IDRua"))
        Next
        dap.Dispose()
        ds.Dispose()

        If tbCEP.Text = "" Then
            Dim Resp As System.Collections.Hashtable = BuscaCep(tbBuscaRuas.Text)
            If Resp.Values(0).ToString() <> "0" Then
                Dim frm1 As fdlgDelivery_CEP_NaoEncontrado = New fdlgDelivery_CEP_NaoEncontrado
                frm1.lbCEP.Text = Strings.Left(tbBuscaRuas.Text, 5) & "-" & Strings.Right(tbBuscaRuas.Text, 3)
                frm1.lbBairro.Text = VerificaTexto(UCase(Resp.Values(5).ToString()))
                frm1.lbCidade.Text = VerificaTexto(UCase(Resp.Values(2).ToString()))
                frm1.lbEstado.Text = UCase(Resp.Values(3).ToString())
                frm1.lbLogradouro.Text = VerificaTexto(UCase(Resp.Values(0).ToString()))
                frm1.lbTipoLogradouro.Text = VerificaTexto(UCase(Resp.Values(1).ToString()))
                frm1.lbDescricao.Text = VerificaTexto(UCase(Resp.Values(0).ToString() & ", " & Resp.Values(1).ToString()))
                frm1.lbStatus.Text = "0"
                frm1.lbMensagem.Visible = True
                frm1.Size = New System.Drawing.Size(700, 310)
                frm1.ShowDialog()
            Else
                frm.lbMensagem.Text = "CEP inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
            End If
            tbBuscaRuas.Focus()
        End If


    End Sub

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub TbBuscaRuas_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaRuas.TextChanged

    End Sub

    Private Sub tbBuscaRuas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBuscaRuas.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbBuscaRuas.Text <> "" Then
                If Not IsNumeric(tbBuscaRuas.Text) Then
                    Dim frm As fdlgBuscaRuas = New fdlgBuscaRuas
                    frm.tbBuscaRua.Text = tbBuscaRuas.Text
                    frm.ShowDialog()
                    tbLogradouro.Text = NomeLogradouro
                    tbIDRua.Text = NomeIDRua
                    tbBairro.Text = NomeBairro
                    tbCEP.Text = NomeCEP
                    tbArea.Text = NomeArea
                    lbTaxaEntrega.Text = NomeTaxaEntrega
                    tbBuscaRuas.Text = ""
                Else
                    BuscaPeloCEP()
                End If
            End If
            tbNumero.Focus()
        End If
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If NuloString(tbLogradouro.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            If tbStatus.Text <> "P" Then
                frm.lbMensagem.Text = "Endereço de entrega inválido"
            Else
                frm.lbMensagem.Text = "Endereço de pagamento inválido"
            End If
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else
            If tbStatus.Text <> "P" Then
                frmDelivery.tbIDRuaEntrega.Text = NuloInteger(tbIDRua.Text)
                frmDelivery.tbLogradouroEntrega.Text = NuloString(UCase(tbLogradouro.Text))
                frmDelivery.tbBairroEntrega.Text = NuloString(UCase(tbBairro.Text))
                frmDelivery.tbCEPEntrega.Text = NuloString(tbCEP.Text)
                frmDelivery.tbAreaEntrega.Text = NuloString(tbArea.Text)
                frmDelivery.lbTaxaEntregaEntrega.Text = NuloString(lbTaxaEntrega.Text)
                frmDelivery.tbNumeroEntrega.Text = NuloString(tbNumero.Text)
                frmDelivery.tbComplementoEntrega.Text = NuloString(UCase(tbComplemento.Text))
                frmDelivery.tbReferenciaEntrega.Text = NuloString(UCase(tbReferencia.Text))
            Else
                frmDelivery.tbRuaPagto.Text = NuloString(UCase(tbLogradouro.Text))
                frmDelivery.tbBairroPagto.Text = NuloString(UCase(tbBairro.Text))
                frmDelivery.tbCepPagto.Text = NuloString(tbCEP.Text)
                frmDelivery.tbNumeroPagto.Text = NuloString(tbNumero.Text)
                frmDelivery.tbComplementoPagto.Text = NuloString(UCase(tbComplemento.Text))
                frmDelivery.tbEnderecoEntregaDiferente.Text = True
                frmDelivery.lbEnderecoPagto.Text = "Endereço de cobrança: " & frmDelivery.tbRuaPagto.Text & ", " & frmDelivery.tbNumeroPagto.Text & "  " & frmDelivery.tbComplementoPagto.Text & " " & frmDelivery.tbBairroPagto.Text & "  " & frmDelivery.tbCepPagto.Text
            End If
            Me.Dispose()
            Me.Close()
        End If

    End Sub

    Private Sub FdlgDeliveryEnderecoEntrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tbStatus.Text <> "P" Then
            lbEndereco.Text = frmDelivery.tbLogradouroEntrega.Text & ", " & frmDelivery.tbNumeroEntrega.Text
            lbBairro.Text = frmDelivery.tbBairroEntrega.Text
        Else
            lbEndereco.Text = frmDelivery.tbRuaPagto.Text & ", " & frmDelivery.tbNumeroPagto.Text & ", " & frmDelivery.tbComplementoPagto.Text
            lbBairro.Text = frmDelivery.tbBairroPagto.Text
            Label1.Text = "Local de pagamento atual"
            Me.Text = "Endereço pagamento  -  Alterar"
        End If

    End Sub

    Private Sub TbNumero_TextChanged(sender As Object, e As EventArgs) Handles tbNumero.TextChanged

    End Sub

    Private Sub tbNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNumero.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbComplemento.Focus()
        End If
    End Sub

    Private Sub TbComplemento_TextChanged(sender As Object, e As EventArgs) Handles tbComplemento.TextChanged

    End Sub

    Private Sub tbComplemento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbComplemento.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbReferencia.Focus()
        End If
    End Sub

    Private Sub TbReferencia_TextChanged(sender As Object, e As EventArgs) Handles tbReferencia.TextChanged

    End Sub

    Private Sub tbReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbReferencia.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbBuscaRuas.Focus()
        End If
    End Sub
End Class