Imports System.Data.SqlClient
Imports System.Net
Imports System.Xml
Imports Newtonsoft.Json

Public Class fdlgDeliveryCadastroCliente
    Public TelefoneNovo As String
    Private Sub PreencheClientes()
        Dim QtdItens As Integer = 0
        Dim item As ListViewItem

        lstClientes.Items.Clear()

        strSql = "Select tblClientes.IDCliente, tblClientes.NomeCliente, tblRuas.Logradouro, tblClientes.Numero, tblClientes.Complemento, tblClientes.Referencia, tblClientes.Bairro, tblClientes.CEP, tblClientes.Area, tblClientes.Tel1, tblClientes.Tel2, tblClientes.Origem, tblClientes.DDD1, tblClientes.DDD2, tblClientes.CPF_CNPJ, tblClientes.IDRua, tblClientes.IDExterno "
        strSql += "From tblClientes LEFT OUTER Join tblRuas On tblClientes.IDRua = tblRuas.IDRua "
        If NuloString(tbBuscaCli.Text) <> "" Then
            If IsNumeric(tbBuscaCli.Text) Then
                strSql += "WHERE (tblClientes.Tel1 LIKE '%" & NuloString(tbBuscaCli.Text) & "%') "
            Else
                strSql += "WHERE (tblClientes.NomeCliente LIKE '%" & NuloString(tbBuscaCli.Text) & "%') "
            End If
        End If

        If NuloString(tbBuscaEndereco.Text) <> "" Then
            If Not IsNumeric(tbBuscaEndereco.Text) Then
                If NuloString(tbBuscaNumero.Text) = "" Then
                    strSql += "WHERE (tblRuas.Logradouro LIKE '%" & tbBuscaEndereco.Text & "%') "
                Else
                    strSql += "WHERE (tblRuas.Logradouro LIKE '%" & tbBuscaEndereco.Text & "%') AND (tblClientes.Numero='" & NuloString(tbBuscaNumero.Text) & "') "
                End If
            Else
                strSql += "WHERE (tblClientes.CEP LIKE '%" & tbBuscaEndereco.Text & "%') "
            End If
        End If
        strSql += "Order By tblClientes.NomeCliente"



        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            item = lstClientes.Items.Add(ds.Tables("Ruas").Rows(i).Item("IDCliente"))
            If NuloString(ds.Tables("Ruas").Rows(i).Item("Tel1")) = "" Then
                item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("CPF_CNPJ")))
            Else
                item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Tel1")))
            End If
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("NomeCliente")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Numero")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Complemento")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("CEP")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("IDExterno")))
            QtdItens += 1
        Next
        dap.Dispose()
        ds.Dispose()
        lbTotalClientes.Text = "Total de clientes  " & QtdItens
        btnBusca.Enabled = False

    End Sub
    Private Sub BuscaClientePeloID(IDcli As Integer)

        strSql = "Select tblClientes.IDCliente, tblClientes.NomeCliente, tblClientes.IDRua, tblClientes.Numero, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblClientes.Complemento, tblClientes.Referencia, tblClientes.CEP, tblRuas.Area, tblClientes.Tel1, tblClientes.Tel2, tblClientes.ComplementoTel, tblClientes.Origem, tblClientes.DataCadastro, tblClientes.DDD1, tblClientes.DDD2, tblClientes.CPF_CNPJ, tblClientes.SaldoNegativo "
        strSql += "From tblRuas RIGHT OUTER Join tblClientes On tblRuas.IDRua = tblClientes.IDRua "
        strSql += "Where (tblClientes.IDCliente=" & IDcli & ")"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        tbCPF_CNPJ.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CPF_CNPJ"))
        If Len(tbCPF_CNPJ.Text) = 14 Then
            tbCPF_CNPJ.Mask = "99,999,999/9999-99"
        End If
        If Len(tbCPF_CNPJ.Text) = 11 Then
            tbCPF_CNPJ.Mask = "999,999,999-99"
        End If

        tbIDCliente.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("IDCliente"))
        tbDDD1.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DDD1"))
        tbTel1.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Tel1"))
        tbCPF_CNPJ.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CPF_CNPJ"))
        tbNomeCliente.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("NomeCliente"))
        tbComplementoTel.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("ComplementoTel"))
        tbDDD2.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DDD2"))
        tbTel2.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Tel2"))
        tbReferencia.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Referencia"))
        tbComplemento.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Complemento"))
        tbNumero.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Numero"))
        tbCEP.Text = Strings.Left(NuloString(ds.Tables("Ruas").Rows(0).Item("CEP")), 5) & "-" & Strings.Right(NuloString(ds.Tables("Ruas").Rows(0).Item("CEP")), 3)
        tbIDRua.Text = NuloInteger(ds.Tables("Ruas").Rows(0).Item("IDRua"))
        tbLogradouro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Logradouro"))
        tbBairro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Bairro"))
        tbCidade.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Cidade"))
        tbEstado.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Estado"))
        tbArea.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Area"))
        tbDataCadastro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DataCadastro"))
        chkPermiteSaldoNegativo.Checked = NuloBoolean(ds.Tables("Ruas").Rows(0).Item("SaldoNegativo"))

        strSql = "Select Area, TaxaEntrega From tblAreas WHERE (Area='" & tbArea.Text & "')"
        lbTaxaEntrega.Text = Format(NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon)), "#0.00")

        dap.Dispose()
        ds.Dispose()
    End Sub
    Public Sub BuscaPeloCEP()

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

        If ds.Tables("Ruas").Rows.Count > 0 Then
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
            tbNumero.Focus()
        Else
            Try
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
                    Dim frm7 As fdlgMensagemBox = New fdlgMensagemBox
                    frm7.lbMensagem.Text = "CEP inválido"
                    frm7.btnNao.Visible = False
                    frm7.btnSim.Visible = False
                    frm7.btnOK.Visible = True
                    frm7.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm7.ShowDialog()
                End If

            Catch ex As Exception

            End Try

            tbBuscaRuas.Focus()
        End If

        dap.Dispose()
        ds.Dispose()




    End Sub
    Private Sub AchaCliente()

        Dim ID_Cliente As Integer = 0
        If NuloString(tbTel1.Text) <> "" Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') = '" & tbDDD1.Text & tbTel1.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If ID_Cliente = 0 And NuloString(tbTel1.Text) <> "" Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') = '" & tbDDD1.Text & tbTel1.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If ID_Cliente = 0 And NuloString(tbTel1.Text) <> "" Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') like '%" & tbTel1.Text & "%')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If ID_Cliente = 0 And NuloString(tbTel1.Text) <> "" Then
            strSql = "Select IDCliente, ISNULL(DDD1, '') + REPLACE(REPLACE(REPLACE(Tel1, '-', ''), ' ', ''), '.', '') AS Tele1, ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') AS Tele2 "
            strSql += "From tblClientes "
            strSql += "Where (ISNULL(DDD2, '') + REPLACE(REPLACE(REPLACE(Tel2, '-', ''), ' ', ''), '.', '') like '%" & tbTel1.Text & "%')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If ID_Cliente = 0 And tbCPF_CNPJ.Text <> "" Then
            strSql = "Select IDCliente, CPF_CNPJ "
            strSql += "From tblClientes "
            strSql += "Where (CPF_CNPJ = '" & tbCPF_CNPJ.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If
        If ID_Cliente = 0 And tbIDExterno.Text <> "" Then
            strSql = "Select IDCliente, IDExterno "
            strSql += "From tblClientes "
            strSql += "Where (IDExterno = '" & tbIDExterno.Text & "')"
            ID_Cliente = NuloInteger(PegaValorCampo("IDCliente", strSql, strCon))
        End If


        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lbStatus.Text = "I" Then
            If ID_Cliente <> 0 Then
                frm.lbMensagem.Text = "Cliente já cadastrado" & vbCrLf & "Deseja continuar"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                Limpa()
                If RetornoMsg = False Then
                    Exit Sub
                End If
            End If
        Else
            'If ID_Cliente = 0 And NuloString(tbTel1.Text) <> "" Then
            If ID_Cliente = 0 And tbNomeCliente.Text = "" Then
                frm.lbMensagem.Text = "Cliente não cadastrado" & vbCrLf & "Deseja cadastrar"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                Limpa()
                If RetornoMsg = False Then
                    Exit Sub
                Else
                    Dim Tel As String = tbTel1.Text
                    Dim DDD As String = tbDDD1.Text
                    tbTel1.Text = Tel
                    tbDDD1.Text = DDD
                    lbStatus.Text = "I"
                    Exit Sub
                End If
            Else

                If tbTel1.Text <> TelefoneNovo And tbNomeCliente.Text <> "" Then
                    frm.lbMensagem.Text = "Deseja alterar o telefone desse cliente"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                    frm.ShowDialog()
                    If RetornoMsg = False Then
                        Limpa()
                        tbTel1.Text = ""
                        Exit Sub
                    Else
                        btnGrava.Enabled = True
                    End If
                End If
                If ID_Cliente = 0 Then Exit Sub
            End If
        End If

        strSql = "Select tblClientes.IDCliente, tblClientes.NomeCliente, tblClientes.IDRua, tblClientes.Numero, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblClientes.Complemento, tblClientes.Referencia, tblClientes.CEP, tblRuas.Area, tblClientes.Tel1, tblClientes.Tel2, tblClientes.ComplementoTel, tblClientes.Origem, tblClientes.DataCadastro, tblClientes.DDD1, tblClientes.DDD2, tblClientes.CPF_CNPJ, tblClientes.SaldoNegativo, tblClientes.Observacao "
        strSql += "From tblRuas RIGHT OUTER Join tblClientes On tblRuas.IDRua = tblClientes.IDRua "
        strSql += "Where (tblClientes.IDCliente=" & ID_Cliente & ")"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        tbCPF_CNPJ.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("CPF_CNPJ"))
        If Len(tbCPF_CNPJ.Text) = 14 Then
            tbCPF_CNPJ.Mask = "99,999,999/9999-99"
        End If
        If Len(tbCPF_CNPJ.Text) = 11 Then
            tbCPF_CNPJ.Mask = "999,999,999-99"
        End If

        tbIDCliente.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("IDCliente"))
        tbDDD1.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DDD1"))
        tbNomeCliente.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("NomeCliente"))
        tbComplementoTel.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("ComplementoTel"))
        tbDDD2.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DDD2"))
        tbTel2.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Tel2"))
        tbReferencia.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Referencia"))
        tbComplemento.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Complemento"))
        tbNumero.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Numero"))
        tbCEP.Text = Strings.Left(NuloString(ds.Tables("Ruas").Rows(0).Item("CEP")), 5) & "-" & Strings.Right(NuloString(ds.Tables("Ruas").Rows(0).Item("CEP")), 3)
        tbIDRua.Text = NuloInteger(ds.Tables("Ruas").Rows(0).Item("IDRua"))
        tbLogradouro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Logradouro"))
        tbBairro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Bairro"))
        tbCidade.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Cidade"))
        tbEstado.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Estado"))
        tbArea.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Area"))
        tbDataCadastro.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("DataCadastro"))
        chkPermiteSaldoNegativo.Checked = NuloBoolean(ds.Tables("Ruas").Rows(0).Item("SaldoNegativo"))
        cbOrigem.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Origem"))
        tbObservacao.Text = NuloString(ds.Tables("Ruas").Rows(0).Item("Observacao"))

        strSql = "Select Area, TaxaEntrega From tblAreas WHERE (Area='" & tbArea.Text & "')"
        lbTaxaEntrega.Text = Format(NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon)), "#0.00")

        dap.Dispose()
        ds.Dispose()
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgDeliveryCadastroCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpa()
        PreencheOrigens()

        btnGrava.Enabled = False

        If lbStatus.Text = "A" Then
            tbDDD1.Text = lbDDD.Text
            If Len(lbTelefone.Text) < 11 Then
                tbTel1.Text = lbTelefone.Text
            Else
                tbCPF_CNPJ.Text = lbTelefone.Text
            End If

            Panel3.Focus()
            tbTel1.Focus()
            AchaCliente()
        End If
        If lbStatus.Text = "I" Then
            tbDDD1.Text = lbDDD.Text
            If Len(lbTelefone.Text) < 11 Then
                tbTel1.Text = lbTelefone.Text
                tbTel1.ReadOnly = True
            Else
                If Strings.Left(lbTelefone.Text, 4) = "0800" Then
                    tbTel1.Text = lbTelefone.Text
                    tbTel1.ReadOnly = True
                Else
                    tbCPF_CNPJ.Text = lbTelefone.Text
                    tbCPF_CNPJ.ReadOnly = True
                End If

            End If
            Panel1.Focus()
            tbNomeCliente.Focus()
        End If

        Me.Size = New System.Drawing.Size(560, 670)

    End Sub

    Private Sub tbTel1_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTel1.KeyDown
        If e.KeyCode = 13 Then

            btnGrava.Enabled = False
            If tbTel1.Text <> "" Then AchaCliente()
            tbIDExterno.Focus()

        End If
    End Sub
    Private Sub Limpa()
        Dim ctl As Control
        For Each ctl In Panel1.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
            If TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            End If
        Next
        lbTaxaEntrega.Text = ""
        tbDDD1.Text = DDD_Padrao
        tbDDD2.Text = DDD_Padrao
        tbCPF_CNPJ.Text = ""
        chkPermiteSaldoNegativo.Checked = False
    End Sub
    Private Sub tbCPF_CNPJ_GotFocus(sender As Object, e As EventArgs) Handles tbCPF_CNPJ.GotFocus
        tbCPF_CNPJ.Mask = ""
    End Sub

    Private Sub tbCPF_CNPJ_LostFocus(sender As Object, e As EventArgs) Handles tbCPF_CNPJ.LostFocus
        If Len(tbCPF_CNPJ.Text) = 14 Then
            tbCPF_CNPJ.Mask = "99,999,999/9999-99"
        End If
        If Len(tbCPF_CNPJ.Text) = 11 Then
            tbCPF_CNPJ.Mask = "999,999,999-99"
        End If

    End Sub

    Private Sub tbCPF_CNPJ_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCPF_CNPJ.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            If Len(tbCPF_CNPJ.Text) = 14 Then
                FU_ValidaCNPJ(tbCPF_CNPJ.Text)
                If ValidaCPF_CNPJ = False Then
                    frm.lbMensagem.Text = "CNPJ inválido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbCPF_CNPJ.Text = ""
                Else
                    strSql = "Select IDCliente, CPF_CNPJ "
                    strSql += "From tblClientes "
                    strSql += "Where (CPF_CNPJ = '" & tbCPF_CNPJ.Text & "')"
                    If NuloInteger(PegaValorCampo("IDCliente", strSql, strCon)) <> 0 Then
                        frm.lbMensagem.Text = "CNPJ já cadastrado"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbCPF_CNPJ.Text = ""
                        Exit Sub
                    End If
                    tbObservacao.Focus()
                End If
            End If
            If Len(tbCPF_CNPJ.Text) = 11 Then
                FU_ValidaCPF(tbCPF_CNPJ.Text)
                If ValidaCPF_CNPJ = False Then
                    frm.lbMensagem.Text = "CPF inválido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbCPF_CNPJ.Text = ""
                Else
                    strSql = "Select IDCliente, CPF_CNPJ "
                    strSql += "From tblClientes "
                    strSql += "Where (CPF_CNPJ = '" & tbCPF_CNPJ.Text & "')"
                    If NuloInteger(PegaValorCampo("IDCliente", strSql, strCon)) <> 0 Then
                        frm.lbMensagem.Text = "CPF já cadastrado"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbCPF_CNPJ.Text = ""
                        Exit Sub
                    End If
                    tbObservacao.Focus()
                End If
            End If
            If tbCPF_CNPJ.Text = "" Then
                tbObservacao.Focus()
            End If
        End If
    End Sub
    Private Sub tbNomeCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNomeCliente.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            tbComplementoTel.Focus()
        End If
    End Sub

    Private Sub cbOrigem_KeyDown(sender As Object, e As KeyEventArgs) Handles cbOrigem.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            tbCPF_CNPJ.Focus()
        End If
    End Sub
    Public Sub PreencheOrigens()

        strSql = "SELECT Origem FROM tblOrigens ORDER BY Origem"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        cbOrigem.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        With dr
            If .HasRows Then
                cbOrigem.Items.Add("")
                While (.Read())
                    cbOrigem.Items.Add(.GetString(0))
                End While
                cbOrigem.SelectedIndex = 0
            End If

            .Close()
        End With
        cmd.Dispose()
        con.Dispose()
        con.Close()
    End Sub

    Private Sub tbCEP_TextChanged(sender As Object, e As EventArgs) Handles tbCEP.TextChanged

    End Sub

    Private Sub tbCEP_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCEP.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            If Len(Replace(tbCEP.Text, "-", "")) <> 8 Then
                frm.lbMensagem.Text = "CEP inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            If Replace(tbCEP.Text, "-", "") = "00000000" Then
                frm.lbMensagem.Text = "CEP inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            If Not IsNumeric(Replace(tbCEP.Text, "-", "")) Then
                frm.lbMensagem.Text = "CEP inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            If tbCEP.Text = "" Then
                frm.lbMensagem.Text = "CEP inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            tbLogradouro.Text = ""
            tbBairro.Text = ""
            tbCidade.Text = ""
            tbEstado.Text = ""
            tbArea.Text = ""


            strSql = "Select tblRuas.IDRua, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuasCep.CEP "
            strSql += "From tblRuas LEFT OUTER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
            strSql += "WHERE (tblRuasCep.CEP = '" & tbCEP.Text & "') "

            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Ruas")

            For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
                tbLogradouro.Text = ds.Tables("Ruas").Rows(i).Item("Logradouro")
                tbBairro.Text = ds.Tables("Ruas").Rows(i).Item("Bairro")
                tbCidade.Text = ds.Tables("Ruas").Rows(i).Item("Cidade")
                tbEstado.Text = ds.Tables("Ruas").Rows(i).Item("Estado")
            Next
            dap.Dispose()
            ds.Dispose()


            If tbLogradouro.Text = "" Then
                frm.lbMensagem.Text = "CEP não cadastrado" & vbCrLf & "Deseja procurar na Internet"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()

                If RetornoMsg = False Then Exit Sub


                Try
                    Dim WS = New WSCorreios.AtendeClienteClient()
                    Dim Resposta = WS.consultaCEP(tbCEP.Text)
                    tbLogradouro.Text = Resposta.end
                    tbBairro.Text = Resposta.bairro
                    tbCidade.Text = Resposta.cidade
                    tbEstado.Text = Resposta.uf

                Catch ex As Exception
                    Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                    frm1.lbMensagem.Text = ex.Message
                    frm1.btnNao.Visible = False
                    frm1.btnSim.Visible = False
                    frm1.btnOK.Visible = True
                    frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm1.ShowDialog()
                    tbCEP.Text = ""
                End Try
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'fdlgDelivery_Ruas.ShowDialog()

        Dim frm As fdlgDelivery_Ruas = New fdlgDelivery_Ruas
        If NuloString(tbLogradouro.Text) <> "" Then
            frm.tbBusca.Text = tbLogradouro.Text
        End If
        frm.ShowDialog()

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
                    tbNumero.Focus()
                Else
                    BuscaPeloCEP()

                End If
            End If

        End If
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Deseja incluir um novo cliente"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = True Then
            Limpa()
            tbDDD1.Text = DDD_Padrao
            tbDDD2.Text = DDD_Padrao
            lbStatus.Text = "I"
            btnGrava.Enabled = False
            tbTel1.Focus()
        End If
    End Sub

    Private Sub tbTel1_TextChanged(sender As Object, e As EventArgs) Handles tbTel1.TextChanged
        btnGrava.Enabled = True

    End Sub

    Private Sub tbCPF_CNPJ_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles tbCPF_CNPJ.MaskInputRejected
        btnGrava.Enabled = True
    End Sub

    Private Sub tbDDD1_TextChanged(sender As Object, e As EventArgs) Handles tbDDD1.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbNomeCliente_TextChanged(sender As Object, e As EventArgs) Handles tbNomeCliente.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbComplementoTel_TextChanged(sender As Object, e As EventArgs) Handles tbComplementoTel.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub cbOrigem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOrigem.SelectedIndexChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbNumero_TextChanged(sender As Object, e As EventArgs) Handles tbNumero.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbComplemento_TextChanged(sender As Object, e As EventArgs) Handles tbComplemento.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbLogradouro_TextChanged(sender As Object, e As EventArgs) Handles tbLogradouro.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbReferencia_TextChanged(sender As Object, e As EventArgs) Handles tbReferencia.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbDDD2_TextChanged(sender As Object, e As EventArgs) Handles tbDDD2.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbTel2_TextChanged(sender As Object, e As EventArgs) Handles tbTel2.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub cbDataCadastro_ValueChanged(sender As Object, e As EventArgs)
        btnGrava.Enabled = True
    End Sub

    Private Sub chkPermiteSaldoNegativo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPermiteSaldoNegativo.CheckedChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub btnGrava_Click(sender As Object, e As EventArgs) Handles btnGrava.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If NuloString(cbOrigem.Text) = "" Then
            frm.lbMensagem.Text = "Dados incompletos (Origem)"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            Exit Sub
        End If

        If lbStatus.Text = "I" Then
            'If tbCEP.Text = "" Or tbLogradouro.Text = "" Then
            If tbLogradouro.Text = "" Then
                frm.lbMensagem.Text = "Dados incompletos (endereço)"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                Exit Sub
            End If

            If tbNumero.Text = "" Then
                frm.lbMensagem.Text = "Dados incompletos (número)"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                Exit Sub
            End If

            strSql = "INSERT tblClientes "
            strSql += "(IDLoja, NomeCliente, IDRua, Numero, Complemento, Referencia, CEP, Area, Cidade, Estado, Tel1, Tel2, ComplementoTel, Origem, DataCadastro, StatusCliente, DataAtualizacao, Responsavel, SaldoCredito, SaldoNegativo, DDD1, DDD2, CPF_CNPJ, IDExterno, Observacao) VALUES ("
            strSql += to_sql(IDLoja) & ","
            strSql += to_sql(NuloString(UCase(tbNomeCliente.Text))) & ","
            strSql += to_sql(NuloInteger(tbIDRua.Text)) & ","
            strSql += to_sql(NuloString(UCase(tbNumero.Text))) & ","
            strSql += to_sql(NuloString(UCase(tbComplemento.Text))) & ","
            strSql += to_sql(NuloString(UCase(tbReferencia.Text))) & ","
            strSql += to_sql(NuloString(tbCEP.Text)) & ","
            strSql += to_sql(NuloString(tbArea.Text)) & ","
            strSql += to_sql(NuloString(UCase(tbCidade.Text))) & ","
            strSql += to_sql(NuloString(UCase(tbEstado.Text))) & ","
            strSql += to_sql(NuloString(Trim(tbTel1.Text))) & ","
            strSql += to_sql(NuloString(Trim(tbTel2.Text))) & ","
            strSql += to_sql(NuloString(UCase(tbComplementoTel.Text))) & ","
            strSql += to_sql(NuloString(cbOrigem.Text)) & ","
            strSql += "'" & Now & "',"
            strSql += "'A',"
            strSql += "'" & Now & "',"
            strSql += to_sql(NuloString(UCase(Operador))) & ","
            strSql += "0,"
            strSql += to_sql(NuloBoolean(chkPermiteSaldoNegativo.Checked)) & ","
            strSql += to_sql(NuloString(tbDDD1.Text)) & ","
            strSql += to_sql(NuloString(tbDDD2.Text)) & ","
            strSql += to_sql(NuloString(Replace(Replace(Replace(Replace(tbCPF_CNPJ.Text, ".", ""), "-", ""), "/", ""), ",", ""))) & ","
            strSql += to_sql(NuloString(UCase(tbIDExterno.Text))) & ","
            strSql += to_sql(NuloString(UCase(tbObservacao.Text))) & ")"
            ExecutaStr(strSql)

            IDClienteMaisTelefones = NuloInteger(PegaID("IDCliente", "tblClientes", "L"))
            frmDelivery.AchaCliente(NuloInteger(IDClienteMaisTelefones))

            Me.Dispose()
            Me.Close()

        Else

            strSql = "UPDATE tblClientes SET "
            strSql &= "NomeCliente ='" & UCase(NuloString(tbNomeCliente.Text)) & "', "
            strSql &= "IDRua =" & NuloInteger(tbIDRua.Text) & ", "
            strSql &= "Numero ='" & UCase(NuloString(tbNumero.Text)) & "', "
            strSql &= "Complemento ='" & UCase(NuloString(tbComplemento.Text)) & "', "
            strSql &= "Referencia ='" & UCase(NuloString(tbReferencia.Text)) & "', "
            strSql &= "CEP ='" & UCase(NuloString(Replace(tbCEP.Text, "-", ""))) & "', "
            strSql &= "Area ='" & UCase(NuloString(tbArea.Text)) & "', "
            strSql &= "Cidade ='" & UCase(NuloString(tbCidade.Text)) & "', "
            strSql &= "Estado ='" & UCase(NuloString(tbEstado.Text)) & "', "
            strSql &= "Tel1 ='" & UCase(NuloString(Trim(tbTel1.Text))) & "', "
            strSql &= "Tel2 ='" & UCase(NuloString(Trim(tbTel2.Text))) & "', "
            strSql &= "ComplementoTel ='" & UCase(NuloString(tbComplementoTel.Text)) & "', "
            strSql &= "Origem ='" & UCase(NuloString(cbOrigem.Text)) & "', "
            strSql &= "DataAtualizacao ='" & Now & "', "
            strSql &= "Responsavel ='" & UCase(NuloString(Operador)) & "', "
            strSql &= "DDD1 ='" & UCase(NuloString(tbDDD1.Text)) & "', "
            strSql &= "DDD2 ='" & UCase(NuloString(tbDDD2.Text)) & "', "
            strSql &= "SaldoNegativo ='" & NuloBoolean(chkPermiteSaldoNegativo.Checked) & "', "
            strSql &= "CPF_CNPJ ='" & NuloString(Replace(Replace(Replace(Replace(tbCPF_CNPJ.Text, ".", ""), "-", ""), "/", ""), ",", "")) & "', "
            strSql &= "IDExterno ='" & UCase(NuloString(tbIDExterno.Text)) & "', "
            strSql &= "Observacao ='" & UCase(NuloString(tbObservacao.Text)) & "' "
            strSql &= "WHERE (IDCliente=" & tbIDCliente.Text & ")"
            ExecutaStr(strSql)


            frm.lbMensagem.Text = "Dados gravados com sucesso!!!"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            frmDelivery.AchaCliente(NuloInteger(tbIDCliente.Text))

            Me.Dispose()
            Me.Close()
        End If



        If btnLocaliza.Visible = False Then
            PreencheClientes()
        End If

    End Sub

    Private Sub tbCPF_CNPJ_TextChanged(sender As Object, e As EventArgs) Handles tbCPF_CNPJ.TextChanged
        btnGrava.Enabled = True
        If Len(tbCPF_CNPJ.Text) = 11 Then
            FU_ValidaCPF(tbCPF_CNPJ.Text)
            'If ValidaCPF_CNPJ = True Then
            'lbCpfCnpj.Text = "CPF Válido"
            'lbCpfCnpj.ForeColor = Color.ForestGreen
            'Else
            'lbCpfCnpj.Text = "CPF Inválido"
            'lbCpfCnpj.ForeColor = Color.Red
            'End If
        Else
            If Len(tbCPF_CNPJ.Text) = 14 Then
                FU_ValidaCNPJ(tbCPF_CNPJ.Text)
                'If ValidaCPF_CNPJ = True Then
                'lbCpfCnpj.Text = "CNPJ Válido"
                'lbCpfCnpj.ForeColor = Color.ForestGreen
                'Else
                'lbCpfCnpj.Text = "CNPJ Inválido"
                'lbCpfCnpj.ForeColor = Color.Red
                'End If
                'Else
                'lbCpfCnpj.Text = ""
            End If
        End If
    End Sub

    Private Sub tbComplementoTel_KeyDown(sender As Object, e As KeyEventArgs) Handles tbComplementoTel.KeyDown
        If e.KeyCode = 13 Then
            cbOrigem.Focus()
        End If
    End Sub

    Private Sub tbNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNumero.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            tbComplemento.Focus()
        End If
    End Sub

    Private Sub tbComplemento_KeyDown(sender As Object, e As KeyEventArgs) Handles tbComplemento.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            tbReferencia.Focus()
        End If
    End Sub

    Private Sub tbReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles tbReferencia.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            tbTel2.Focus()
        End If
    End Sub

    Private Sub tbTel2_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTel2.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            chkPermiteSaldoNegativo.Focus()
        End If
    End Sub

    Private Sub cbDataCadastro_KeyDown(sender As Object, e As KeyEventArgs)
        e.Handled = True
        If e.KeyCode = 13 Then
            chkPermiteSaldoNegativo.Focus()
        End If
    End Sub

    Private Sub chkPermiteSaldoNegativo_KeyDown(sender As Object, e As KeyEventArgs) Handles chkPermiteSaldoNegativo.KeyDown
        e.Handled = True
        If e.KeyCode = 13 Then
            tbTel1.Focus()
        End If
    End Sub

    Private Sub tbTel1_GotFocus(sender As Object, e As EventArgs) Handles tbTel1.GotFocus
        If lbStatus.Text = "I" Then
            tbNomeCliente.Focus()
        End If

    End Sub

    Private Sub TbBuscaRuas_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaRuas.TextChanged

    End Sub

    Private Sub BtnOrigem_Click(sender As Object, e As EventArgs) Handles btnOrigem.Click
        fdlgDelivery_Origens.ShowDialog()
        PreencheOrigens()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click


        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        strSql = "Select IDVenda, IDCliente, NumVenda "
        strSql += "From tblVendas "
        strSql += "Where (IDCliente=" & tbIDCliente.Text & ")"
        Dim NVenda As Integer = NuloInteger(PegaValorCampo("NumVenda", strSql, strCon))
        If NVenda <> 0 Then

            frm.lbMensagem.Text = "Impossivel excluir este cliente" & vbCrLf & "pois ele esta vinculado na venda " & NVenda
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Deseja realmente excluir este cliente"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        strSql = "DELETE from tblClientes WHERE IDCliente=" & tbIDCliente.Text
        ExecutaStr(strSql)
        Limpa()
        tbTel1.Text = ""
        tbIDExterno.Text = ""
        If btnLocaliza.Visible = False Then
            PreencheClientes()
        End If


    End Sub

    Private Sub TbBuscaCliente_TextChanged(sender As Object, e As EventArgs)
        tbBuscaCli.Text = ""
        tbBuscaNumero.Text = ""
        btnBusca.Enabled = True
    End Sub

    Private Sub TbBuscaEndereco_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaEndereco.TextChanged
        tbBuscaCli.Text = ""
        tbBuscaNumero.Text = ""
        btnBusca.Enabled = True
    End Sub

    Private Sub BtnLocaliza_Click(sender As Object, e As EventArgs) Handles btnLocaliza.Click

        Me.Size = New System.Drawing.Size(1265, 670)
        Limpa()
        PreencheClientes()
        btnLocaliza.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBusca.Click
        Limpa()
        PreencheClientes()
    End Sub

    Private Sub LstClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClientes.SelectedIndexChanged
        If lstClientes.SelectedItems.Count > 0 Then
            BuscaClientePeloID(NuloInteger(lstClientes.SelectedItems(0).SubItems(0).Text))
        End If
    End Sub


    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)
        btnGrava.Enabled = True
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            AchaCliente()
            tbCPF_CNPJ.Focus()

        End If
    End Sub

    Private Sub TbIDExterno_TextChanged(sender As Object, e As EventArgs) Handles tbIDExterno.TextChanged
        btnGrava.Enabled = True
    End Sub

    Private Sub tbIDExterno_KeyDown(sender As Object, e As KeyEventArgs) Handles tbIDExterno.KeyDown
        If e.KeyCode = 13 Then
            If tbIDExterno.Text <> "" Then
                strSql = "Select IDCliente, IDExterno "
                strSql += "From tblClientes "
                strSql += "Where (IDExterno = '" & tbIDExterno.Text & "')"
                If NuloInteger(PegaValorCampo("IDCliente", strSql, strCon)) <> 0 Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Código externo já cadastrado"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbIDExterno.Text = ""
                    Exit Sub
                End If
                AchaCliente()
            End If
            tbNomeCliente.Focus()
        End If
    End Sub

    Private Sub TbObservacao_TextChanged(sender As Object, e As EventArgs) Handles tbObservacao.TextChanged
        btnGrava.Enabled = True
        If Len(tbObservacao.Text) > 60 Then
            tbObservacao.Text = Strings.Left(tbObservacao.Text, 60)
        End If
        lbTextoObs.Text = Len(tbObservacao.Text) & " de 60"
    End Sub

    Private Sub tbObservacao_KeyDown(sender As Object, e As KeyEventArgs) Handles tbObservacao.KeyDown
        If e.KeyCode = 13 Then
            tbBuscaRuas.Focus()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TbBuscaNumero_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaNumero.TextChanged
        tbBuscaCli.Text = ""
        btnBusca.Enabled = True
    End Sub

    Private Sub TbBuscaCli_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaCli.TextChanged
        tbBuscaEndereco.Text = ""
        tbBuscaNumero.Text = ""
        btnBusca.Enabled = True
    End Sub

    Private Sub tbTel1_Enter(sender As Object, e As EventArgs) Handles tbTel1.Enter
        TelefoneNovo = tbTel1.Text
        'MsgBox("OK")
    End Sub
    Private Sub tbNomeCliente_LostFocus(sender As Object, e As EventArgs) Handles tbNomeCliente.LostFocus
        tbNomeCliente.Text = VerificaTexto(tbNomeCliente.Text)
    End Sub

    Private Sub tbComplementoTel_LostFocus(sender As Object, e As EventArgs) Handles tbComplementoTel.LostFocus
        tbComplementoTel.Text = VerificaTexto(tbComplementoTel.Text)
    End Sub

    Private Sub tbNumero_LostFocus(sender As Object, e As EventArgs) Handles tbNumero.LostFocus
        tbNumero.Text = VerificaTexto(tbNumero.Text)
    End Sub

    Private Sub tbComplemento_LostFocus(sender As Object, e As EventArgs) Handles tbComplemento.LostFocus
        tbComplemento.Text = VerificaTexto(tbComplemento.Text)
    End Sub

    Private Sub tbReferencia_LostFocus(sender As Object, e As EventArgs) Handles tbReferencia.LostFocus
        tbReferencia.Text = VerificaTexto(tbReferencia.Text)
    End Sub
End Class