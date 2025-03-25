Imports System.Data.SqlClient

Public Class fdlgDelivery_Ruas
    Private Sub PreencheAreas()

        cbArea.Items.Clear()

        Dim Area As String

        strSql = "Select Area, TaxaEntrega "
        strSql += "From tblAreas "
        strSql += "Order By Area"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Areas")
        cbArea.Items.Add("")
        For i As Integer = 0 To ds.Tables("Areas").Rows.Count - 1
            Area = ds.Tables("Areas").Rows(i).Item("Area") & "  -  " & Format(ds.Tables("Areas").Rows(i).Item("TaxaEntrega"), "#0.00") & Space(100) & ds.Tables("Areas").Rows(i).Item("Area")
            cbArea.Items.Add(Area)
        Next
        dap.Dispose()
        ds.Dispose()


    End Sub
    Private Sub PreencheRuas()
        Dim QtdItens As Integer = 0
        Dim item As ListViewItem

        lstRuas.Items.Clear()


        strSql = "Select IDRua, Logradouro, Bairro, Cidade, Estado, Area "
        strSql += "From tblRuas "
        If tbBusca.Text <> "" Then
            strSql += "WHERE (tblRuas.Logradouro LIKE '%" & tbBusca.Text & "%') "
        End If
        strSql += "Order By tblRuas.Logradouro"

        If IsNumeric(tbBusca.Text) Then
            strSql = "Select tblRuas.IDRua, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuasCep.CEP "
            strSql += "From tblRuas INNER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
            strSql += "Where (tblRuasCep.CEP = '" & tbBusca.Text & "')"
        End If

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            item = lstRuas.Items.Add(ds.Tables("Ruas").Rows(i).Item("IDRua"))
            'item.SubItems.Add(ds.Tables("Ruas").Rows(i).Item("TipoLogradouro"))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Cidade")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Estado")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Area")))
            QtdItens += 1
        Next
        dap.Dispose()
        ds.Dispose()
        lbQtdeRuas.Text = "Qtde. de logradouros  " & QtdItens
        lstCEPs.Items.Clear()
        tbResultado.Text = ""

    End Sub
    Private Sub PreenchaCeps()
        Dim item As ListViewItem
        lstCEPs.Items.Clear()

        If lstRuas.SelectedItems.Count > 0 Then
            Dim cep As String

            strSql = "Select CEP, IDRua "
            strSql += "From tblRuasCep "
            strSql += "WHERE(IDRua=" & NuloInteger(lstRuas.SelectedItems(0).SubItems(0).Text) & ") "


            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Ceps")

            For i As Integer = 0 To ds.Tables("Ceps").Rows.Count - 1
                item = lstCEPs.Items.Add(ds.Tables("Ceps").Rows(i).Item("IDRua"))
                cep = Trim(Replace(ds.Tables("Ceps").Rows(i).Item("Cep"), "-", ""))
                cep = Strings.Left(cep, 5) & "-" & Strings.Right(cep, 3)
                item.SubItems.Add(cep)
            Next
            dap.Dispose()
            ds.Dispose()
        End If


    End Sub
    Private Sub fdlgDelivery_Ruas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheAreas()
        PreencheRuas()

        frmPagamento.carregaVisualComponente(btnVolta, 10, 10)
        frmPagamento.carregaVisualComponente(btnInserir, 10, 10)
        frmPagamento.carregaVisualComponente(btnExcluir, 10, 10)
        frmPagamento.carregaVisualComponente(Button1, 10, 10)
        frmPagamento.carregaVisualComponente(btnConsultaRua, 10, 10)
        frmPagamento.carregaVisualComponente(btnGoogle, 10, 10)
        tbBusca.Focus()

        tbCidade.Text = NuloString(CidadeLoja)
        tbEstado.Text = NuloString(EstadoLoja)

        btnInserir.Enabled = True
        lbTempo.Text = ""
        lbDistancia.Text = ""

    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        If NuloString(cbArea.Text) = "" And NuloString(tbLogradouro.Text) <> "" Then
            If NuloString(cbArea.Text) = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Lougradouro sem área cadastrada. Deseja realmente sair"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = False Then Exit Sub
            End If
            fdlgBuscaRuas.tbBuscaRua.Text = tbBairro.Text
        End If

        Me.Dispose()
        Me.Close()

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

            'cbTipoLogradouro.Text = ""
            tbLogradouro.Text = ""
            tbBairro.Text = ""
            tbCidade.Text = ""
            tbEstado.Text = ""
            cbArea.Text = ""


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
                    PreencheRuas()

                Catch ex As Exception
                    Dim frmM As fdlgMensagemBox = New fdlgMensagemBox
                    frmM.lbMensagem.Text = ex.Message
                    frmM.btnNao.Visible = False
                    frmM.btnSim.Visible = False
                    frmM.btnOK.Visible = True
                    frmM.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frmM.ShowDialog()
                    tbCEP.Text = ""
                End Try
            End If

        End If
    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click

        strSql = "Select tblRuas.IDRua, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuasCep.CEP "
        strSql += "From tblRuas LEFT OUTER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
        strSql += "WHERE (tblRuas.Logradouro = '" & UCase(tbLogradouro.Text) & "')"

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If NuloInteger(PegaValorCampo("IDRua", strSql, strCon)) <> 0 Then
            frm.lbMensagem.Text = "Logradouro já cadastrado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If tbLogradouro.Text = "" Then
            frm.lbMensagem.Text = "Logradouro inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloString(cbArea.Text) = "" Then
            frm.lbMensagem.Text = "Você não selecionou uma area" & vbCrLf & "Deseja continuar mesmo assim"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub
        End If

        If tbCEP.Text <> "" Then
            strSql = "Select tblRuas.IDRua, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuasCep.CEP "
            strSql += "From tblRuas LEFT OUTER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
            strSql += "WHERE (tblRuasCep.CEP = '" & UCase(Replace(tbCEP.Text, "-", "")) & "')"
            Dim txtRuaCEP As String = NuloString(PegaValorCampo("Logradouro", strSql, strCon))
            If txtRuaCEP <> "" Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "CEP já cadastrado (" & txtRuaCEP & ")"
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm1.ShowDialog()
                Exit Sub
            End If
        End If


        Dim frm11 As fdlgMensagemBox = New fdlgMensagemBox
        frm11.lbMensagem.Text = "Deseja realmente cadastrar o logradouro " & vbCrLf & UCase(tbLogradouro.Text)
        frm11.btnNao.Visible = True
        frm11.btnSim.Visible = True
        frm11.btnOK.Visible = False
        frm11.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm11.ShowDialog()
        If RetornoMsg = False Then Exit Sub


        strSql = "INSERT tblRuas "
        strSql += "(Logradouro, Bairro, Cidade, Estado, Area, Atualiza) VALUES ("
        strSql += to_sql(UCase(tbLogradouro.Text)) & ","
        strSql += to_sql(UCase(tbBairro.Text)) & ","
        strSql += to_sql(UCase(tbCidade.Text)) & ","
        strSql += to_sql(UCase(tbEstado.Text)) & ","
        strSql += to_sql(NuloString(Trim(Strings.Right(cbArea.Text, 8)))) & ", "
        strSql += "1)"
        ExecutaStr(strSql)

        If NuloString(tbCEP.Text) <> "" Then
            strSql = "INSERT tblRuasCep "
            strSql += "(IDRua,CEP) VALUES ("
            strSql += to_sql(NuloInteger(PegaValorCampo("ID", "Select MAX(IDRua) As ID From tblRuas WITH (TABLOCKX)", strCon))) & ","
            strSql += to_sql(NuloString(Replace(tbCEP.Text, "-", ""))) & ")"
            ExecutaStr(strSql)
        End If


        'cbTipoLogradouro.Text = ""
        tbLogradouro.Text = ""
        tbBairro.Text = ""
        tbCidade.Text = NuloString(CidadeLoja)
        tbEstado.Text = NuloString(EstadoLoja)
        cbArea.Text = ""

        PreencheRuas()
        PreenchaCeps()

        If tbOrigem.Text = "C" Then
            fdlgBuscaRuas.tbBuscaRua.Text = UCase(tbLogradouro.Text)
            Me.Dispose()
            Me.Close()
        End If

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Len(Replace(tbCEP.Text, "-", "")) <> 8 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "CEP inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If Replace(tbCEP.Text, "-", "") = "00000000" Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "CEP inválido"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            Exit Sub
        End If
        If Not IsNumeric(Replace(tbCEP.Text, "-", "")) Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "CEP inválido"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm2.ShowDialog()
            Exit Sub
        End If
        If tbCEP.Text = "" Then
            Dim frm3 As fdlgMensagemBox = New fdlgMensagemBox
            frm3.lbMensagem.Text = "CEP inválido"
            frm3.btnNao.Visible = False
            frm3.btnSim.Visible = False
            frm3.btnOK.Visible = True
            frm3.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm3.ShowDialog()
            Exit Sub
        End If


        strSql = "Select tblRuas.IDRua, tblRuas.TipoLogradouro, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Cidade, tblRuas.Estado, tblRuas.Area, tblRuasCep.CEP "
        strSql += "From tblRuas LEFT OUTER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
        strSql += "WHERE(tblRuasCep.CEP = '" & tbCEP.Text & "')"
        Dim RetornoCep As String = NuloString(PegaValorCampo("Logradouro", strSql, strCon))
        If RetornoCep <> "" Then
            Dim frm4 As fdlgMensagemBox = New fdlgMensagemBox
            frm4.lbMensagem.Text = "CEP já cadastrado no logradouro" & vbCrLf & RetornoCep
            frm4.btnNao.Visible = False
            frm4.btnSim.Visible = False
            frm4.btnOK.Visible = True
            frm4.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm4.ShowDialog()
            Exit Sub
        End If

        Dim frm5 As fdlgMensagemBox = New fdlgMensagemBox
        frm5.lbMensagem.Text = "Deseja cadastrar o CEP " & tbCEP.Text & " no logradouro" & vbCrLf & tbLogradouro.Text
        frm5.btnNao.Visible = True
        frm5.btnSim.Visible = True
        frm5.btnOK.Visible = False
        frm5.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm5.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        tbCEP.Text = Replace(tbCEP.Text, "-", "")

        strSql = "Select IDRua, Logradouro From tblRuas WHERE (Logradouro = '" & tbLogradouro.Text & "')"
        Dim IDrua As Integer = NuloInteger(PegaValorCampo("IDRua", strSql, strCon))

        If NuloInteger(IDrua) <> 0 Then
            strSql = "INSERT tblRuasCep "
            strSql += "(IDRua,CEP) VALUES ("
            strSql += to_sql(NuloInteger(IDrua)) & ","
            strSql += to_sql(NuloString(tbCEP.Text)) & ")"
            ExecutaStr(strSql)
        Else
            Dim frm6 As fdlgMensagemBox = New fdlgMensagemBox
            frm6.lbMensagem.Text = "ERRO ao cadastrar o CEP no logradouro" & vbCrLf & RetornoCep
            frm6.btnNao.Visible = False
            frm6.btnSim.Visible = False
            frm6.btnOK.Visible = True
            frm6.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm6.ShowDialog()
            Exit Sub
        End If

        PreenchaCeps()

    End Sub

    Private Sub tbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged

        'cbTipoLogradouro.Text = ""
        tbLogradouro.Text = ""
        tbBairro.Text = ""
        'tbCidade.Text = ""
        'tbEstado.Text = ""
        cbArea.Text = ""
        tbCEP.Text = ""
        tbResultado.Text = ""

        PreencheRuas()

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If tbLogradouro.Text = "" Then
            frm.lbMensagem.Text = "Logradouro inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        strSql = "Select COUNT(IDCliente) As Clientes, IDRua "
        strSql += "From tblClientes "
        strSql += "Group By IDRua "
        strSql += "HAVING(IDRua = " & NuloInteger(lstRuas.SelectedItems(0).Text) & ")"
        Dim Clientes As Integer = NuloInteger(PegaValorCampo("Clientes", strSql, strCon))
        If Clientes <> 0 Then
            frm.lbMensagem.Text = "Impossível excluir este logradouro" & vbCrLf & "existem " & Clientes & " clientes vinculados a ele"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        frm.lbMensagem.Text = "Deseja excluir o logradouro" & vbCrLf & tbLogradouro.Text
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        ExecutaStr("DELETE from tblRuas WHERE IDRua=" & NuloInteger(lstRuas.SelectedItems(0).Text))
        ExecutaStr("DELETE from tblRuasCep WHERE IDRua=" & NuloInteger(lstRuas.SelectedItems(0).Text))

        ExecutaStrServidor("DELETE from tblRuasLojas WHERE IDRua=" & NuloInteger(lstRuas.SelectedItems(0).Text) & " AND IDLoja=" & IDLoja)
        ExecutaStrServidor("DELETE from tblRuasCEPLojas WHERE IDRua=" & NuloInteger(lstRuas.SelectedItems(0).Text))

        tbLogradouro.Text = ""
        tbBairro.Text = ""
        tbCidade.Text = ""
        tbEstado.Text = ""
        cbArea.Text = ""
        tbCEP.Text = ""
        PreencheRuas()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If lstCEPs.SelectedItems.Count > 0 Then

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja excluir o CEP" & vbCrLf & tbCEP.Text
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub

            ExecutaStr("DELETE from tblRuasCep WHERE Cep='" & Replace(lstCEPs.SelectedItems(0).SubItems(1).Text, "-", "") & "'")
            PreenchaCeps()


        End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If lstRuas.SelectedItems.Count > 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja alterar o logradouro" & vbCrLf & tbLogradouro.Text
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub

            If NuloString(cbArea.Text) = "" Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "Você não selecionou uma area" & vbCrLf & "Deseja continuar mesmo assim"
                frm1.btnNao.Visible = True
                frm1.btnSim.Visible = True
                frm1.btnOK.Visible = False
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm1.ShowDialog()
                If RetornoMsg = False Then Exit Sub
            End If


            strSql = "UPDATE tblRuas SET "
            strSql &= "Logradouro='" & UCase(NuloString(tbLogradouro.Text)) & "',"
            strSql &= "Bairro='" & UCase(NuloString(tbBairro.Text)) & "',"
            strSql &= "Cidade='" & UCase(NuloString(tbCidade.Text)) & "',"
            strSql &= "Estado='" & UCase(NuloString(tbEstado.Text)) & "',"
            strSql &= "Area='" & NuloString(Trim(Strings.Right(cbArea.Text, 8))) & "',"
            strSql &= "Atualiza=1 "
            strSql &= "WHERE (IDRua=" & lstRuas.SelectedItems(0).Text & ")"
            ExecutaStr(strSql)
        Else
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "É necessário selecionar um logradouro"
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm2.ShowDialog()
        End If
        PreencheRuas()

    End Sub

    Private Sub lstRuas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRuas.SelectedIndexChanged
        If lstRuas.SelectedItems.Count > 0 Then
            PreenchaCeps()
            'cbTipoLogradouro.Text = lstRuas.SelectedItems(0).SubItems(1).Text
            tbLogradouro.Text = lstRuas.SelectedItems(0).SubItems(1).Text
            tbBairro.Text = lstRuas.SelectedItems(0).SubItems(2).Text
            tbCidade.Text = lstRuas.SelectedItems(0).SubItems(3).Text
            tbEstado.Text = lstRuas.SelectedItems(0).SubItems(4).Text
            cbArea.Text = ""
            'Dim ItemSel As Integer
            For I = 1 To cbArea.Items.Count - 1
                If NuloString(Trim(Strings.Right(cbArea.Items(I), 8))) = lstRuas.SelectedItems(0).SubItems(5).Text Then
                    cbArea.SelectedIndex = I
                    I = 9999
                End If
                'ItemSel += 1
            Next
            tbCEP.Text = ""

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fdlgDelivery_Areas.ShowDialog()
        PreencheAreas()
    End Sub

    Private Sub btnConsultaRua_Click(sender As Object, e As EventArgs) Handles btnConsultaRua.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If NuloString(tbCidade.Text) = "" Then
            frm.lbMensagem.Text = "É necessário informar uma cidade"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCidade.Focus()
            Exit Sub
        End If
        If NuloString(tbEstado.Text) = "" Then
            frm.lbMensagem.Text = "É necessário informar um estado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbEstado.Focus()
            Exit Sub
        End If
        If NuloString(tbBusca.Text) = "" Then
            frm.lbMensagem.Text = "É necessário informar um lougradouro"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbBusca.Focus()
            Exit Sub
        End If

        tbCidade.Text = UCase(tbCidade.Text)
        tbEstado.Text = UCase(tbEstado.Text)
        tbCEP.Text = ""
        tbLogradouro.Text = ""
        tbBairro.Text = ""
        lbDistancia.Text = ""
        lbTempo.Text = ""

        Dim Resp As System.Collections.Hashtable = BuscaCEPGoogle(tbBusca.Text, tbCidade.Text, tbEstado.Text)
        For i = 0 To Resp.Count - 1
            If Resp.Keys(i).ToString = "Status" Then
                If Resp.Keys(i).ToString = "0" Then
                    Exit For
                End If
            End If
            If Resp.Keys(i).ToString = "CEP" Then
                tbCEP.Text = Resp.Values(i).ToString
            End If
            If Resp.Keys(i).ToString = "Logradouro" Then
                tbLogradouro.Text = Resp.Values(i).ToString
            End If
            If Resp.Keys(i).ToString = "Bairro" Then
                tbBairro.Text = Resp.Values(i).ToString
            End If
        Next
        If NuloString(tbLogradouro.Text) <> "" And NuloString(tbBusca.Text) <> "" Then
            Dim resultado As Decimal = CalculaProbaLogradouro(UCase(tbLogradouro.Text), UCase(tbBusca.Text))
            tbResultado.Text = resultado & "% de probabilidade em ser logradouro correto"
            If NuloInteger(resultado) <= 30 Then
                tbResultado.ForeColor = Color.Red
            Else
                If NuloInteger(resultado) <= 60 Then
                    tbResultado.ForeColor = Color.Chocolate
                Else
                    tbResultado.ForeColor = Color.ForestGreen
                End If
            End If

        End If

        Dim RespKM As System.Collections.Hashtable = CalcKm(CEPLoja, tbBusca.Text)
        For i = 0 To RespKM.Count - 1
            If RespKM.Keys(i).ToString = "DISTANCIA" Then
                lbDistancia.Text = RespKM.Values(i).ToString
            End If
            If RespKM.Keys(i).ToString = "TEMPO" Then
                lbTempo.Text = RespKM.Values(i).ToString
            End If
        Next


    End Sub

    Private Sub TbLogradouro_TextChanged(sender As Object, e As EventArgs) Handles tbLogradouro.TextChanged

    End Sub

    Private Sub tbLogradouro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLogradouro.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbBairro.Focus()
        End If
    End Sub

    Private Sub TbBairro_TextChanged(sender As Object, e As EventArgs) Handles tbBairro.TextChanged

    End Sub

    Private Sub tbBairro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBairro.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCidade.Focus()
        End If
    End Sub

    Private Sub TbEstado_TextChanged(sender As Object, e As EventArgs) Handles tbEstado.TextChanged

    End Sub

    Private Sub TbCidade_TextChanged(sender As Object, e As EventArgs) Handles tbCidade.TextChanged

    End Sub

    Private Sub tbCidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCidade.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbEstado.Focus()
        End If
    End Sub

    Private Sub tbEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEstado.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            cbArea.Focus()
        End If
    End Sub

    Private Sub BtnGoogle_Click(sender As Object, e As EventArgs) Handles btnGoogle.Click
        If lstRuas.SelectedItems.Count > 0 Then

            Dim frm As fdlgGoogleMaps = New fdlgGoogleMaps
            frm.lbLogradouro.Text = tbLogradouro.Text
            frm.lbNumero.Text = ""
            frm.lbCEP.Text = ""
            frm.lbComplemento.Text = ""
            frm.lbBairro.Text = tbBairro.Text
            frm.ShowDialog()

        Else
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "É necessário selecionar um endereço"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub cbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArea.SelectedIndexChanged

    End Sub
End Class