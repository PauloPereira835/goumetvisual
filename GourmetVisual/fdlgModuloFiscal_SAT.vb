Imports System.Data.SqlClient

Public Class fdlgModuloFiscal_SAT
    Public SatRespondido As Boolean = False
    Public TempoEspera As Integer = 60
    Public Espera As Integer

    Private Sub PreencheMovto()
        strSql = "Select IDFechamento, IDFuncionario, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido "
        strSql += "From tblFechamentos "
        strSql += "Where (Confirmado <> 0) "
        strSql += "Order By DiaMovimento DESC, Turno"

        Dim con As New SqlConnection(strConServer)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            cbMovto.Items.Add("")
            While (dr.Read)
                cbMovto.Items.Add(dr.Item("Turno") & " (" & dr.Item("DiaMovimento") & ") - " & Strings.Left(dr.Item("Caixa"), 20) & Space(100) & dr.Item("IDFechamento"))
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub PreencheLista()
        Dim item As ListViewItem
        Dim Num As Integer = 0
        Dim Vlr As Decimal = 0

        lstVendas.Items.Clear()

        If chkMovtoAterior.Checked = False Then

            strSql = "Select tblVendasSAT.IDVendaSAT, tblVendasSAT.Num_SAT, tblVendasSAT.ValorCupom, tblVendas.StatusVenda, tblVendas.NumVenda, Case When Statusvenda = 'D' THEN NumVendaD ELSE NumVenda END AS NVenda, tblVendas.DataVenda, tblVendas.IDVenda, tblVendas.TotalVenda, tblVendas.Desconto, tblVendas.Servico, tblVendas.TotalVenda As TotVenda, tblVendas.TaxaEntrega, tblFechamentos_Local.DiaMovimento, tblVendasSAT.IDSat, tblVendas.NumMesa "
            strSql += "From tblVendasSAT INNER Join tblVendas On tblVendasSAT.IDVenda = tblVendas.IDVenda LEFT OUTER Join tblFechamentos_Local On tblVendas.IDfechamento = tblFechamentos_Local.IDFechamento "
            strSql += "Where (CASE WHEN StatusVenda = 'D' THEN 1 ELSE FlagFechada END = 1) "
            If rbRejeitados.Checked = True Then
                strSql += " And (tblVendasSAT.Num_SAT Is NULL) "
            End If
            If rbAutorizados.Checked = True Then
                strSql += "And (Not (tblVendasSAT.Num_SAT Is NULL)) And (LEFT(tblVendasSAT.Num_SAT, 3)<>'CAN') "
            End If
            If rbCancelados.Checked = True Then
                strSql += "And (LEFT(tblVendasSAT.Num_SAT, 3)='CAN') "
            End If
            strSql += "Group By tblVendasSAT.IDVendaSAT, tblVendasSAT.Num_SAT, tblVendasSAT.ValorCupom, tblVendas.StatusVenda, tblVendas.NumVenda, CASE WHEN Statusvenda = 'D' THEN NumVendaD ELSE NumVenda END, tblVendas.DataVenda, tblVendas.IDVenda, tblVendas.TotalVenda, tblVendas.Desconto, tblVendas.Servico, tblVendas.TaxaEntrega, tblFechamentos_Local.DiaMovimento, tblVendasSAT.IDSat, tblVendas.NumMesa "
            If NuloString(tbBusca.Text) <> "" Then
                strSql += "HAVING(CASE WHEN Statusvenda = 'D' THEN NumVendaD ELSE NumVenda END = " & tbBusca.Text & ") OR (CASE WHEN Statusvenda = 'S' THEN NumMesa ELSE '' END = " & tbBusca.Text & ") "
            End If
            strSql += "ORDER BY tblVendas.NumVenda DESC"

        Else
            If cbMovto.Text <> "" Then
                strSql = "Select tblRetVendasSAT.IDVendaRetSAT, tblRetVendasSAT.Num_SAT, tblRetVendasSAT.ValorCupom, tblRetVendas.StatusVenda, tblRetVendas.NumVenda, tblRetVendas.NumMesa as Expr1, tblRetVendas.DataVenda, tblRetVendas.IDVendaRet, tblRetVendas.TotalVenda, tblRetVendas.FlagFechada, tblRetVendas.Desconto, tblRetVendas.Servico, tblRetVendas.TotalVenda As TotVenda, tblRetVendas.TaxaEntrega, tblFechamentos.DiaMovimento, tblFechamentos.IDFechamento, tblRetVendas.NumMesa,  CASE WHEN tblRetVendas.Statusvenda = 'D' THEN tblRetVendas.NumVendaD ELSE tblRetVendas.NumVenda END AS NVenda "
                strSql += "From tblFechamentos INNER Join tblRetVendas On tblFechamentos.IDFechamento = tblRetVendas.IDfechamento INNER JOIN tblRetVendasSAT On tblRetVendas.IDVendaRet = tblRetVendasSAT.IDVendaRet "
                strSql += "Group By tblRetVendasSAT.IDVendaRetSAT, tblRetVendasSAT.Num_SAT, tblRetVendasSAT.ValorCupom, tblRetVendas.StatusVenda, tblRetVendas.NumVenda, tblRetVendas.NumMesa, tblRetVendas.DataVenda, tblRetVendas.IDVendaRet, tblRetVendas.TotalVenda, tblRetVendas.Desconto, tblRetVendas.Servico, tblRetVendas.TaxaEntrega, tblFechamentos.DiaMovimento, tblRetVendas.FlagFechada, tblRetVendas.IDSat, tblFechamentos.IDFechamento, tblRetVendas.NumMesa, CASE WHEN tblRetVendas.Statusvenda = 'D' THEN tblRetVendas.NumVendaD ELSE tblRetVendas.NumVenda END "
                strSql += "HAVING(tblRetVendas.FlagFechada = 1) AND (tblRetVendas.IDSat IS NOT NULL) AND (tblRetVendas.TotalVenda IS NOT NULL) "
                If rbRejeitados.Checked = True Then
                    strSql += "And (tblRetVendasSAT.Num_SAT Is NULL) "
                End If
                If rbAutorizados.Checked = True Then
                    strSql += "And (Not (tblRetVendasSAT.Num_SAT Is NULL)) And (LEFT(tblRetVendasSAT.Num_SAT, 3)<>'CAN') "
                End If
                If rbCancelados.Checked = True Then
                    strSql += "And (LEFT(tblRetVendasSAT.Num_SAT, 3)='CAN') "
                End If
                If cbMovto.Text <> "" Then
                    strSql += "And (tblFechamentos.IDFechamento=" & NuloInteger(Trim(Strings.Right(cbMovto.Text, 12))) & ") "
                End If
                If NuloString(tbBusca.Text) <> "" Then
                    strSql += "and (CASE WHEN Statusvenda = 'D' THEN NumVendaD ELSE NumVenda END = " & tbBusca.Text & ") OR (CASE WHEN Statusvenda = 'S' THEN NumMesa ELSE '' END = " & tbBusca.Text & ") "
                End If
                strSql += "ORDER BY tblRetVendas.NumVenda DESC"
            Else
                Exit Sub
            End If
        End If


        ' Try

        Dim Nconexao As String
            If chkMovtoAterior.Checked = False Then
                Nconexao = strCon
            Else
                Nconexao = strConServer
            End If

            Dim con As New SqlConnection(Nconexao)
            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                If chkMovtoAterior.Checked = False Then
                    item = lstVendas.Items.Add(dr.Item("IDVendaSAT"))
                Else
                    item = lstVendas.Items.Add(dr.Item("IDVendaRetSAT"))
                End If
                If dr.Item("StatusVenda") = "S" Then
                    item.SubItems.Add("Salão")
                Else
                    If dr.Item("StatusVenda") = "B" Then
                        item.SubItems.Add("Balcão")
                    Else
                        item.SubItems.Add("Delivery")
                    End If
                End If
                item.SubItems.Add(dr.Item("NumVenda"))
                If dr.Item("StatusVenda") = "S" Then
                    item.SubItems.Add(dr.Item("NumMesa"))
                Else
                    item.SubItems.Add(dr.Item("NVenda"))
                End If

                'item.SubItems.Add(dr.Item("Expr1"))
                item.SubItems.Add(dr.Item("DataVenda"))

                item.SubItems.Add(dr.Item("ValorCupom"))
                If IsDBNull(dr.Item("Num_SAT")) Then
                    item.SubItems.Add("")
                Else
                    If dr.Item("Num_SAT") = "" Then
                        item.SubItems.Add("")
                    Else
                        If Strings.Left(dr.Item("Num_SAT"), 3) = "CAN" Then
                            item.SubItems.Add("C")
                        Else
                            item.SubItems.Add("*")
                        End If
                    End If
                End If
                If chkMovtoAterior.Checked = False Then
                    item.SubItems.Add(dr.Item("IDVenda"))
                Else
                    item.SubItems.Add(dr.Item("IDVendaRet"))
                End If

                If IsDBNull(dr.Item("Desconto")) Then
                    item.SubItems.Add("0")
                Else
                    item.SubItems.Add(Math.Abs(dr.Item("Desconto")))
                End If
                If IsDBNull(dr.Item("Servico")) Then
                    item.SubItems.Add("0")
                Else
                    item.SubItems.Add(dr.Item("Servico"))
                End If

                If IsDBNull(dr.Item("TotVenda")) Then
                    item.SubItems.Add("0")
                Else
                    item.SubItems.Add(dr.Item("TotVenda"))
                End If

                If IsDBNull(dr.Item("TaxaEntrega")) Then
                    item.SubItems.Add(0)
                Else
                    item.SubItems.Add(dr.Item("TaxaEntrega"))
                End If

                item.SubItems.Add(NuloString(dr.Item("DiaMovimento")))
                'If chkMovtoAterior.Checked = False Then
                'item.SubItems.Add(NuloInteger(dr.Item("IDSat")))
                'Else
                'item.SubItems.Add("")
                'End If
                item.SubItems.Add(EquipamentoSAT)

                Num += 1
                Vlr += dr.Item("ValorCupom")
            End While

            lstVendas.Update()
            lstVendas.EndUpdate()
        End If


        lbQtde.Text = "Quantidade de vendas: " & Num
            lbValorTotal.Text = Vlr

            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()
            Colorir()


        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try


    End Sub
    Private Sub fdlgModuloFiscal_SAT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbMsgValido.Visible = False
        tbCpfCnpj.Visible = False
        rbTodos.Checked = True

        PreencheMovto()
        PreencheLista()
    End Sub
    Private Sub Colorir()
        For i As Integer = 0 To lstVendas.Items.Count - 1
            lstVendas.Items(i).Selected = True
            If lstVendas.SelectedItems(0).SubItems(6).Text = "C" Then
                lstVendas.Items(i).ForeColor = Color.Red
            Else
                If lstVendas.SelectedItems(0).SubItems(6).Text = "" Then
                    lstVendas.Items(i).ForeColor = Color.Blue
                Else
                    lstVendas.Items(i).ForeColor = Color.Green
                End If
            End If
            lstVendas.Items(i).Selected = False
        Next

    End Sub
    Private Sub lstVendas_Click(sender As Object, e As EventArgs) Handles lstVendas.Click
        If lstVendas.SelectedItems.Count > 0 Then
            tbIDVendaSAT.Text = lstVendas.SelectedItems(0).Text
            tbIDVenda.Text = lstVendas.SelectedItems(0).SubItems(7).Text
            If lstVendas.SelectedItems(0).ForeColor = Color.Blue Then
                btnEmite.Enabled = True
                btnVisualiza.Enabled = False
                btnCancela.Enabled = False
                lbMsgValido.Visible = True
                tbCpfCnpj.Visible = True
            Else
                btnEmite.Enabled = False
                btnCancela.Enabled = True
                btnVisualiza.Enabled = True
                lbMsgValido.Visible = False
                tbCpfCnpj.Visible = False
            End If
            If lstVendas.SelectedItems(0).ForeColor = Color.Red Then
                btnCancela.Enabled = False
            End If
        End If

        If chkMovtoAterior.Checked = True Then
            'btnEmite.Enabled = False
            btnCancela.Enabled = False
            lbMsgValido.Visible = False
            tbCpfCnpj.Visible = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fdlgSAT.ShowDialog()

    End Sub

    Private Sub btnEmite_Click(sender As Object, e As EventArgs) Handles btnEmite.Click

        '  Try


        If lstVendas.SelectedItems.Count > 0 Then
            Dim AcresDesc As Decimal = lstVendas.SelectedItems(0).SubItems(9).Text - lstVendas.SelectedItems(0).SubItems(8).Text
            If NuloBoolean(chkMovtoAterior.Checked) = False Then
                strSql = "UPDATE tblVendasSAT SET "
                tbDiaMovto.Text = frmPrincipal.tbDiaMovto.Text
            Else
                strSql = "UPDATE tblRetVendasSAT SET "
                tbDiaMovto.Text = lstVendas.SelectedItems(0).SubItems(12).Text
            End If

            If NuloBoolean(chkMovtoAterior.Checked) = False Then
                strSql &= "IDVenda =" & tbIDVenda.Text & ", "
                strSql &= "Bkp = 1, "
            Else
                strSql &= "IDVendaRet =" & tbIDVenda.Text & ", "
            End If
            strSql &= "ValorCupom =" & Replace(lstVendas.SelectedItems(0).SubItems(5).Text, ",", ".") & ", "
            strSql &= "CPF_CNPJ ='" & tbCpfCnpj.Text & "', "
            strSql &= "TotalAD =" & Replace(AcresDesc, ",", ".") & ", "
            strSql &= "TotalVenda =" & Replace(lstVendas.SelectedItems(0).SubItems(10).Text, ",", ".") & ", "
            strSql &= "TxEntrega =" & Replace(lstVendas.SelectedItems(0).SubItems(11).Text, ",", ".") & ", "
            strSql &= "STVenda ='" & lstVendas.SelectedItems(0).SubItems(1).Text & "', "
            strSql &= "DiaMovto ='" & tbDiaMovto.Text & "', "
            If NuloInteger(lstVendas.SelectedItems(0).SubItems(13).Text) <> 0 Then
                strSql &= "IDSat =" & lstVendas.SelectedItems(0).SubItems(13).Text & ", "
            Else
                strSql &= "IDSat =1, "
            End If
            strSql &= "IDVdaPagto =0, "
            strSql &= "Enviado =1, "
            strSql &= "Status ='A' "
            If NuloBoolean(chkMovtoAterior.Checked) = False Then
                strSql &= "WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
                ExecutaStr(strSql)
            Else
                strSql &= "WHERE (IDVendaRetSAT=" & tbIDVendaSAT.Text & ")"
                ExecutaStrServidor(strSql)
            End If


            If NuloBoolean(chkMovtoAterior.Checked) = False Then
                strSql = "UPDATE tblVendasPagto SET "
                strSql &= "Cupom=0 "
                strSql &= "WHERE (IDVenda=" & tbIDVenda.Text & ")"
                ExecutaStr(strSql)
            Else
                strSql = "UPDATE tblRetVendasPagto SET "
                strSql &= "Cupom=0 "
                strSql &= "WHERE (IDVendaRet=" & tbIDVenda.Text & ")"
                ExecutaStrServidor(strSql)
            End If


            If NuloBoolean(chkMovtoAterior.Checked) = False Then
                TimerAguardandoSAT.Enabled = True
                TimerAguardandoSAT.Start()
            Else
                strSql = "Select * "
                strSql += "From tblRetVendasSAT "
                strSql += "Where (IDVendaRetSAT=" & tbIDVendaSAT.Text & ")"

                EfetuaVendaSAT(PegaValorCampo("IDVendaRetSAT", strSql, strConServer), PegaValorCampo("IDVendaRet", strSql, strConServer), NuloString(PegaValorCampo("CPF_CNPJ", strSql, strConServer)), NuloDecimal(PegaValorCampo("TotalAD", strSql, strConServer)), NuloDecimal(PegaValorCampo("TotalVenda", strSql, strConServer)), NuloDecimal(PegaValorCampo("ValorCupom", strSql, strConServer)), NuloDecimal(PegaValorCampo("TxEntrega", strSql, strConServer)), NuloString(PegaValorCampo("StVenda", strSql, strConServer)), NuloString(PegaValorCampo("DiaMovto", strSql, strConServer)), NuloInteger(PegaValorCampo("IDVendaRet", strSql, strConServer)), NuloInteger(PegaValorCampo("IDSat", strSql, strConServer)), NuloInteger(PegaValorCampo("IDVdaPagto", strSql, strConServer)), "S")

                strSql = "Select * "
                strSql += "From tblRetVendasSAT "
                strSql += "Where (IDVendaRetSAT=" & tbIDVendaSAT.Text & ")"

                If NuloString(PegaValorCampo("Status", strSql, strConServer)) = "E" Then

                    TimerAguardandoSAT.Stop()

                    Dim lngFile As Integer = FreeFile()

                    FileClose(lngFile)
                    FileOpen(lngFile, Application.StartupPath & "\CFeSAT_Emitido\" & NuloString(PegaValorCampo("Num_SAT", strSql, strConServer)) & ".xml", OpenMode.Output)
                    PrintLine(lngFile, NuloString(PegaValorCampo("XML", strSql, strConServer)))
                    FileClose(lngFile)


                    spdSAT.ImprimirCFeSAT(ReadUTF8File(Application.StartupPath & "\CFeSAT_Emitido\" & NuloString(PegaValorCampo("Num_SAT", strSql, strConServer)) & ".xml"), "", ImpCaixa)

                    'TimerAguardandoSAT.Stop()

                    'Me.Dispose()
                    'Me.Close()
                    TimerAguardandoSAT.Enabled = False
                    TimerAguardandoSAT.Stop()
                    PreencheLista()
                    lbMensagem.Text = ""
                    'Else
                    'If dr.Item("Status") = "ERRO" Then
                    'Me.Dispose()
                    'Me.Close()
                    'End If
                    PreencheLista()
                End If
            End If

            'EfetuaVendaSAT(tbIDVendaSAT.Text, tbIDVenda.Text, tbCpfCnpj.Text, AcresDesc, lstVendas.SelectedItems(0).SubItems(10).Text, lstVendas.SelectedItems(0).SubItems(5).Text, lstVendas.SelectedItems(0).SubItems(11).Text, lstVendas.SelectedItems(0).SubItems(1).Text, lstVendas.SelectedItems(0).SubItems(12).Text, lstVendas.SelectedItems(0).SubItems(7).Text, lstVendas.SelectedItems(0).SubItems(13).Text, 0)
            'PreencheLista()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If

        'Catch ex As Exception
        'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        'frm.lbMensagem.Text = ex.Message
        'frm.btnNao.Visible = False
        'frm.btnSim.Visible = False
        'frm.btnOK.Visible = True
        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        'frm.ShowDialog()

        'End Try


    End Sub



    Private Sub btnVisualiza_Click(sender As Object, e As EventArgs) Handles btnVisualiza.Click

        Try

            If lstVendas.SelectedItems.Count = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar uma venda"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            Dim ArqImp As String
            Dim conexcao As String

            If chkMovtoAterior.Checked = False Then
                strSql = "Select * From tblVendasSAT WHERE IDVendaSAT=" & tbIDVendaSAT.Text
                conexcao = strCon
            Else
                strSql = "Select * From tblRetVendasSAT WHERE IDVendaRetSAT=" & tbIDVendaSAT.Text
                conexcao = strConServer
            End If

            Dim con As New SqlConnection(conexcao)

            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                dr.Read()

                Call CarregaIni_SatCP()

                spdSAT.ExibirDetalhamento = True
                If LogoCupom <> "" Then spdSAT.LogotipoEmitente = LogoCupom

                ArqImp = Mid(dr.Item("Num_SAT"), 4, Len(dr.Item("Num_SAT")) - 3)
                ArqImp = Application.StartupPath & "\Sat\CopiaSeguranca\" & ArqImp & ".xml"

                If lstVendas.SelectedItems(0).ForeColor = Color.Green Then
                    'spdSAT.VisualizarCFeSAT(ReadUTF8File(ArqImp), "")
                    spdSAT.VisualizarCFeSAT(dr.Item("XML"), "")
                Else
                    spdSAT.VisualizarCFeSATCancelada("ADC" & Mid(dr.Item("Num_SAT"), 4, Len(dr.Item("Num_SAT")) - 3), "ADC" & Mid(dr.Item("Num_SAT"), 4, Len(dr.Item("Num_SAT")) - 3), "retrato.rtm")
                End If

            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

        Catch ex As Exception
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = ex.Message
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()

        End Try


    End Sub

    Private Sub tbCpf_Cnpj_TextChanged(sender As Object, e As EventArgs) Handles tbCpfCnpj.TextChanged
        If Len(tbCpfCnpj.Text) = 11 Then
            FU_ValidaCPF(tbCpfCnpj.Text)
            If ValidaCPF_CNPJ = True Then
                lbMsgValido.Text = "CPF Válido"
                lbMsgValido.ForeColor = Color.ForestGreen
            Else
                lbMsgValido.Text = "CPF Inválido"
                lbMsgValido.ForeColor = Color.Red
            End If
        Else
            If Len(tbCpfCnpj.Text) = 14 Then
                FU_ValidaCNPJ(tbCpfCnpj.Text)
                If ValidaCPF_CNPJ = True Then
                    lbMsgValido.Text = "CNPJ Válido"
                    lbMsgValido.ForeColor = Color.ForestGreen
                Else
                    lbMsgValido.Text = "CNPJ Inválido"
                    lbMsgValido.ForeColor = Color.Red
                End If
            Else
                lbMsgValido.ForeColor = Color.Blue
                lbMsgValido.Text = "Informe CPF / CNPJ"
            End If
        End If
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        PreencheLista()
    End Sub

    Private Sub rbAutorizados_CheckedChanged(sender As Object, e As EventArgs) Handles rbAutorizados.CheckedChanged
        PreencheLista()
    End Sub

    Private Sub rbRejeitados_CheckedChanged(sender As Object, e As EventArgs) Handles rbRejeitados.CheckedChanged
        PreencheLista()
    End Sub

    Private Sub rbCancelados_CheckedChanged(sender As Object, e As EventArgs) Handles rbCancelados.CheckedChanged
        PreencheLista()
    End Sub

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click

        Try

            If lstVendas.SelectedItems.Count = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar uma venda"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            Dim IDVda As Integer
            Dim ArqImp As String = ""
            Dim Retorno As Boolean = False

            strSql = "Select * From tblVendasSAT WHERE IDVendaSAT=" & tbIDVendaSAT.Text
            Dim con As New SqlConnection(strCon)
            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                dr.Read()

                Call CarregaIni_SatCP()
                PegaDadosSAT(lstVendas.SelectedItems(0).SubItems(13).Text)


                spdSAT.ExibirDetalhamento = True
                If LogoCupom <> "" Then spdSAT.LogotipoEmitente = LogoCupom

                IDVda = dr.Item("IDVenda")
                ArqImp = Mid(dr.Item("Num_SAT"), 4, Len(dr.Item("Num_SAT")) - 3)

                frmPrincipal.tbmmRetorno.Text = spdSAT.CancelarUltimaVenda(NumeroSessao, ArqImp, cnpjSW, "", NumeroCaixa, AssAC)

                If InStr(frmPrincipal.tbmmRetorno.Text, "sucesso") > 0 Then
                    Retorno = True
                End If

                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = frmPrincipal.tbmmRetorno.Text
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm1.ShowDialog()
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()

            If Retorno = True Then
                CopiaXML(ArqImp, "C", ArqImp & ".xml")

                strSql = "UPDATE tblVendasSAT SET "
                strSql &= "Num_SAT ='CAN" & ArqImp & "' "
                strSql &= "WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
                ExecutaStr(strSql)

                strSql = "UPDATE tblVendas Set "
                strSql &= "Excluido=1, "
                strSql &= "MotivoEstorno='CUPOM FISCAL CANCELADO' "
                strSql &= "WHERE (IDVenda=" & IDVda & ")"
                ExecutaStr(strSql)

                strSql = "UPDATE tblVendasMovto Set "
                strSql &= "Excluido=1, "
                strSql &= "Venda=0, "
                strSql &= "VendaServico=0, "
                strSql &= "MotivoEstorno='CUPOM FISCAL CANCELADO' "
                strSql &= "WHERE (IDVenda=" & IDVda & ")"
                ExecutaStr(strSql)


                If AccessKey_Shipay <> "" And SecretKey_Shipay <> "" Then
                    If ClientID_Shipay = "" Then
                        strSql = "SELECT Terminal, ClientID, ImpressoraPagtoDigital, Status FROM tblTerminaisPagtoDigital WHERE Terminal = '" & NuloString(NomeTerminal) & "'"
                        ClientID_Shipay = NuloString(PegaValorCampo("ClientID", strSql, strCon))
                    End If
                    If access_token_Shipay = "" Then
                        Dim api As New classShipay()
                        api.getToken()
                    End If


                    strSql = "Select IDVenda, IDPagtoDigital "
                    strSql += "From tblVendasPagto "
                    strSql += "Where (IDVenda = " & tbIDVenda.Text & ")"

                    Dim dap = New SqlDataAdapter(strSql, strCon)
                    dap.SelectCommand.CommandType = CommandType.Text
                    Dim ds As New DataSet()
                    dap.Fill(ds, "Vendas")
                    For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
                        If NuloString(ds.Tables("Vendas").Rows(i).Item("IDPagtoDigital")) <> "" Then
                            Dim c As New classShipay()
                            Dim ret = c.deleteOrder(NuloString(ds.Tables("Vendas").Rows(i).Item("IDPagtoDigital")))
                        End If
                    Next
                End If

                PreencheLista()
            End If

        Catch ex As Exception
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = ex.Message
            frm2.btnNao.Visible = False
            frm2.btnSim.Visible = False
            frm2.btnOK.Visible = True
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm2.ShowDialog()
        End Try


    End Sub

    Private Sub chkMovtoAterior_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovtoAterior.CheckedChanged

        If chkMovtoAterior.Checked = True Then
            cbMovto.Visible = True
        Else
            cbMovto.Visible = False
            btnEmite.Enabled = False
            btnCancela.Enabled = False
            lbMsgValido.Visible = False
            tbCpfCnpj.Visible = False
        End If
        PreencheLista()

    End Sub

    Private Sub TimerAguardandoSAT_Tick(sender As Object, e As EventArgs) Handles TimerAguardandoSAT.Tick

        lbMensagem.Text = "Aguarde... Imprimindo cupom fiscal (" & TempoEspera & ")"
        TempoEspera -= 1
        lbMensagem.Refresh()


        If TempoEspera = 0 Then
            strSql = "UPDATE tblVendasSAT SET Status='ERRO' WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
            ExecutaStr(strSql)

            TimerAguardandoSAT.Enabled = False
            TimerAguardandoSAT.Stop()
            'Me.Dispose()
            'Me.Close()
        End If


        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select IDVendaSAT, IDVenda, Num_SAT, NumSAT, XML, Enviado, Status "
        strSql += "From tblVendasSAT "
        strSql += "Where (IDVendaSAT = " & tbIDVendaSAT.Text & ") AND (Enviado = 1)"

        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            If dr.Item("Status") = "E" Then

                TimerAguardandoSAT.Stop()

                Dim lngFile As Integer = FreeFile()

                FileClose(lngFile)
                FileOpen(lngFile, Application.StartupPath & "\CFeSAT_Emitido\" & dr.Item("Num_SAT") & ".xml", OpenMode.Output)
                PrintLine(lngFile, NuloString(dr.Item("XML")))
                FileClose(lngFile)


                spdSAT.ImprimirCFeSAT(ReadUTF8File(Application.StartupPath & "\CFeSAT_Emitido\" & dr.Item("Num_SAT") & ".xml"), "", ImpCaixa)

                'TimerAguardandoSAT.Stop()

                'Me.Dispose()
                'Me.Close()
                TimerAguardandoSAT.Enabled = False
                TimerAguardandoSAT.Stop()
                PreencheLista()
                lbMensagem.Text = ""
            Else
                If dr.Item("Status") = "ERRO" Then
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Else
            SatRespondido = False
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        If Espera = 1 Then
            TempoEspera -= 1
            Espera = 0
        Else
            Espera = 1
        End If


    End Sub

    Private Sub CbMovto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMovto.SelectedIndexChanged
        PreencheLista()
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheLista()
    End Sub

    Private Sub btnVisualiza_DoubleClick(sender As Object, e As EventArgs) Handles btnVisualiza.DoubleClick
        If lstVendas.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma venda"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        Else
            fdlgSat_VerificaVenda.ShowDialog()
        End If
    End Sub

    Private Sub lstVendas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstVendas.SelectedIndexChanged

    End Sub

    Private Sub lstVendas_DoubleClick(sender As Object, e As EventArgs) Handles lstVendas.DoubleClick

        'If chkMovtoAterior.Checked = False Then
        If lstVendas.SelectedItems.Count = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar uma venda"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            Else
                Dim frm As fdlgSat_VerificaVenda = New fdlgSat_VerificaVenda
                frm.tbIDVenda.Text = lstVendas.SelectedItems.Item(0).SubItems(7).Text
                frm.ShowDialog()
            End If
        'End If
    End Sub
End Class