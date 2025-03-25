Imports System.Data.SqlClient
Imports System.IO

Public Class fdlgEstorno
    Public Foco As String
    Private Sub btnSai_Click(sender As Object, e As EventArgs) Handles btnSai.Click
        Me.Dispose()
        Me.Close()
        'If frmSalao.lstPedido.Items.Count > 0 Then
        'frmSalao.lstPedido.Items(0).Selected = False
        ' End If
    End Sub
    Public Sub AtualizaGridProdutos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim ID As Integer = 0
        Dim IDMovto As Integer
        Dim Status As String
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        If lstProdutos.Items.Count > 0 Then
            lstProdutos.DataSource = Nothing
            lstProdutos.Items.Clear()
        End If


        If rbPorLancamento.Checked = True Then
            SqlStr = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendasMovto.IDVendaMovto, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasCombo.Produto As ProdutoCombo, tblVendasMovto.HoraPedido "
            SqlStr += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
            SqlStr += "Where(tblVendas.IDVenda = " & IDVenda & ") And (tblVendasMovto.Excluido = 0) "
            SqlStr += "Order By tblVendasMovto.Produto"
        Else
            SqlStr = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtd, tblVendasCombo.Produto As ProdutoCombo, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto "
            SqlStr += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
            SqlStr += "Where (tblVendasMovto.Excluido = 0) "
            SqlStr += "Group By tblVendas.IDVenda, tblVendas.NumVenda, tblVendasMovto.IDProduto, tblVendasMovto.Produto, tblVendasCombo.Produto, tblProdutos_Local.CodigoProduto, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto "
            SqlStr += "HAVING(tblVendas.IDVenda = " & IDVenda & ") "
            SqlStr += "ORDER BY tblVendasMovto.Produto"
        End If

        cmd.CommandText = SqlStr

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim Linha As String
        Dim Cod As String
        Dim Prod As String
        Dim Qtd As String
        Dim CodID As String
        Dim Tp As New ArrayList()


        If dr.HasRows Then
            Status = "P"
            While (dr.Read())
                If IsDBNull(dr.Item("ProdutoCombo")) Then
                    If rbPorLancamento.Checked = True Then
                        If Len(NuloString(dr.Item("CodigoProduto"))) <= 6 Then
                            Cod = Space(6 - Len(NuloString(dr.Item("CodigoProduto")))) & NuloInteger(dr.Item("CodigoProduto"))
                        Else
                            Cod = NuloString(dr.Item("CodigoProduto"))
                        End If

                        If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                            Prod = NuloString(dr.Item("Produto")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                        Else
                            Prod = Strings.Left(NuloString(dr.Item("Produto")), 30)
                        End If

                        If Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000")) <= 8 Then
                            Qtd = Space(8 - Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))) & Format(NuloDecimal(dr.Item("Qtd")), "#0.000")
                        Else
                            Qtd = NuloString(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))
                        End If

                        IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                        CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))

                        Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                        Tp.Add(Linha)

                        ID += 1
                        Status = "P"

                    Else
                        If Len(NuloString(dr.Item("CodigoProduto"))) <= 6 Then
                            Cod = Space(6 - Len(NuloString(dr.Item("CodigoProduto")))) & NuloInteger(dr.Item("CodigoProduto"))
                        Else
                            Cod = NuloString(dr.Item("CodigoProduto"))
                        End If

                        If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                            Prod = NuloString(dr.Item("Produto")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                        Else
                            Prod = Strings.Left(NuloString(dr.Item("Produto")), 30)
                        End If

                        If Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000")) <= 8 Then
                            Qtd = Space(8 - Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))) & Format(NuloDecimal(dr.Item("Qtd")), "#0.000")
                        Else
                            Qtd = NuloString(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))
                        End If

                        IDMovto = NuloInteger(dr.Item("IDVenda"))
                        CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))

                        Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                        Tp.Add(Linha)


                        ID += 1
                        Status = "P"

                    End If
                Else
                    If IDMovto <> NuloInteger(dr.Item("IDVendaMovto")) Then
                        Status = "P"
                    End If
                    If Status = "P" Then
                        If rbPorLancamento.Checked = True Then
                            If Len(NuloString(dr.Item("CodigoProduto"))) <= 6 Then
                                Cod = Space(6 - Len(NuloString(dr.Item("CodigoProduto")))) & NuloInteger(dr.Item("CodigoProduto"))
                            Else
                                Cod = NuloString(dr.Item("CodigoProduto"))
                            End If

                            If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                                Prod = NuloString(dr.Item("Produto")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                            Else
                                Prod = Strings.Left(NuloString(dr.Item("Produto")), 30)
                            End If

                            If Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000")) <= 8 Then
                                Qtd = Space(8 - Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))) & Format(NuloDecimal(dr.Item("Qtd")), "#0.000")
                            Else
                                Qtd = NuloString(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))
                            End If

                            CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))
                            Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                            Tp.Add(Linha)

                        Else
                            If Len(NuloString(dr.Item("CodigoProduto"))) <= 6 Then
                                Cod = Space(6 - Len(NuloString(dr.Item("CodigoProduto")))) & NuloInteger(dr.Item("CodigoProduto"))
                            Else
                                Cod = NuloString(dr.Item("CodigoProduto"))
                            End If

                            If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                                Prod = NuloString(dr.Item("Produto")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                            Else
                                Prod = Strings.Left(NuloString(dr.Item("Produto")), 30)
                            End If

                            If Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000")) <= 8 Then
                                Qtd = Space(8 - Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))) & Format(NuloDecimal(dr.Item("Qtd")), "#0.000")
                            Else
                                Qtd = NuloString(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))
                            End If

                            CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))
                            Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                            Tp.Add(Linha)

                        End If
                        ID += 1
                        Cod = Space(6)
                        If Len(NuloString(dr.Item("ProdutoCombo"))) <= 30 Then
                            Prod = "- " & NuloString(dr.Item("ProdutoCombo")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                        Else
                            Prod = "- " & Strings.Left(NuloString(dr.Item("ProdutoCombo")), 30)
                        End If

                        Qtd = Space(8)
                        CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))
                        IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                        Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID

                        Tp.Add(Linha)

                        ID += 1
                        Status = "PC"

                    Else
                        If IDMovto = NuloInteger(dr.Item("IDVendaMovto")) Then
                            Cod = Space(6)
                            If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                                Prod = "- " & NuloString(dr.Item("ProdutoCombo")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                            Else
                                Prod = "- " & Strings.Left(NuloString(dr.Item("ProdutoCombo")), 30)
                            End If
                            Qtd = Space(8)

                            CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))
                            Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                            Tp.Add(Linha)
                            ID += 1
                        Else
                            If rbPorLancamento.Checked = True Then
                                If Len(NuloInteger(dr.Item("CodigoProduto"))) <= 6 Then
                                    Cod = Space(6 - Len(NuloInteger(dr.Item("CodigoProduto")))) & NuloInteger(dr.Item("CodigoProduto"))
                                Else
                                    Cod = NuloInteger(dr.Item("CodigoProduto"))
                                End If

                                If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                                    Prod = NuloString(dr.Item("Produto")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                                Else
                                    Prod = Strings.Left(NuloString(dr.Item("Produto")), 30)
                                End If

                                If Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000")) <= 8 Then
                                    Qtd = Space(8 - Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))) & Format(NuloDecimal(dr.Item("Qtd")), "#0.000")
                                Else
                                    Qtd = NuloString(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))
                                End If

                                CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))
                                Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                                Tp.Add(Linha)

                            Else
                                If Len(NuloInteger(dr.Item("CodigoProduto"))) <= 6 Then
                                    Cod = Space(6 - Len(NuloInteger(dr.Item("CodigoProduto")))) & NuloInteger(dr.Item("CodigoProduto"))
                                Else
                                    Cod = NuloInteger(dr.Item("CodigoProduto"))
                                End If

                                If Len(NuloString(dr.Item("Produto"))) <= 30 Then
                                    Prod = NuloString(dr.Item("Produto")) & Space(30 - Len(NuloString(dr.Item("Produto"))))
                                Else
                                    Prod = Strings.Left(NuloString(dr.Item("Produto")), 30)
                                End If

                                If Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000")) <= 8 Then
                                    Qtd = Space(8 - Len(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))) & Format(NuloDecimal(dr.Item("Qtd")), "#0.000")
                                Else
                                    Qtd = NuloString(Format(NuloDecimal(dr.Item("Qtd")), "#0.000"))
                                End If

                                CodID = NuloInteger(dr.Item("CodigoProduto")) & "_" & NuloInteger(dr.Item("IDVendaMovto"))
                                Linha = Cod & " " & Prod & " " & Qtd & Space(50) & CodID
                                Tp.Add(Linha)

                            End If
                            ID += 1
                            Status = "PC"
                            IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                        End If
                    End If
                End If
            End While

            lstProdutos.DataSource = Tp

        End If

        Dim fontSelecionado As New Font("Courier New", 12, FontStyle.Bold)
        Dim fontNSelecionado As New Font("Courier New", 10, FontStyle.Regular)

        If rbPorLancamento.Checked = False Then
            tbQtde.Visible = True
            lbQuantidade.Visible = True
        Else
            tbQtde.Visible = False
            lbQuantidade.Visible = False
        End If
        con.Close()
        con.Dispose()

    End Sub
    Public Sub AtualizaGridMotivos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        If chkEstornaMesa.Checked = False Then
            cmd.CommandText = "Select Motivo From tblMotivosEstorno WHERE EstornoProduto=1 Order By Motivo"
        Else
            cmd.CommandText = "Select Motivo From tblMotivosEstorno WHERE EstornoVenda=1 Order By Motivo"
        End If

        GridMotivo.Rows.Clear()

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                While (dr.Read())
                    GridMotivo.Rows.Add({NuloString(dr.Item("Motivo"))})
                End While
            End If


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub
    Private Sub fdlgEstorno_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmSalao.TimerTela.Enabled = False

        rbPorLancamento.Checked = True
        lbStatusMesa.Text = TextoMesaPAR
        If Modulo = "S" Then
            chkEstornaMesa.Text = "Estornar " & TextoMesaPAR
        Else
            chkEstornaMesa.Text = "Estornar Venda"
        End If
        lbMesa.Text = frmSalao.tbMesa.Text
        AtualizaGridProdutos()
        AtualizaGridMotivos()


        tbQtde.Focus()
        lstProdutos.ClearSelected()
    End Sub
    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click


        Dim Motivo As String = ""
        Dim ID As Integer
        Dim Campo As String

        If GridMotivo.SelectedRows.Count > 0 Then
            Dim drc As DataGridViewSelectedRowCollection = GridMotivo.SelectedRows
            For i As Integer = 0 To drc.Count - 1
                Dim Produto As String = drc(i).Cells(0).Value
                Motivo = (Produto)
            Next
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar o motivo"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        ' Estornar Mesa/Cartão  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If chkEstornaMesa.Checked = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            If Modulo = "S" Then
                If UCase(TextoMesaPAR) = "MESA" Then
                    frm.lbMensagem.Text = "Confirma o estono da Mesa"
                Else
                    frm.lbMensagem.Text = "Confirma o estono do " & TextoMesaPAR
                End If
            Else
                frm.lbMensagem.Text = "Confirma o estono da venda " & NuloString(frmSalao.tbMesa.Text)
            End If
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then
                Exit Sub
            End If

            If IDFechamento = 0 Then
                strSql = "SELECT IDFechamento, IDFuncionario, Caixa, Confirmado FROM tblFechamentos_Local WHERE (Confirmado = 0) AND (IDFuncionario = " & IDFuncionarioAutorizado & ")"
                IDFechamento = NuloInteger(PegaValorCampo("IDFechamento", strSql, strCon))
            End If
            If IDFechamento = 0 Then
                strSql = "SELECT IDFechamento, IDFuncionario, Caixa, Confirmado FROM tblFechamentos_Local WHERE (Confirmado = 0)"
                IDFechamento = NuloInteger(PegaValorCampo("IDFechamento", strSql, strCon))
            End If
            If IDFechamento = 0 Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "É necessário ter o caixa aberto"
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm1.ShowDialog()
                Exit Sub
            End If

            strSql = "UPDATE tblVendas Set "
            strSql &= "IDFechamento=" & IDFechamento & ", "
            strSql &= "FlagFechada=1, "
            strSql &= "Excluido=1, "
            strSql &= "IDFuncionarioAtendente=" & IDFuncionarioAutorizado & ", "
            strSql &= "Atendente='" & FuncionarioAutorizado & "', "
            strSql &= "MotivoEstorno='" & Motivo & "' "
            strSql &= "WHERE (IDVenda=" & IDVenda & ")"
            ExecutaStr(strSql)

            strSql = "UPDATE tblVendasMovto Set "
            strSql &= "Excluido=1, "
            strSql &= "Venda=0, "
            strSql &= "VendaServico=0, "
            strSql &= "Impresso=0, "
            strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
            strSql &= "Atendente='" & FuncionarioAutorizado & "', "
            strSql &= "MotivoEstorno='" & Motivo & "' "
            strSql &= "WHERE (IDVenda=" & IDVenda & ")"
            ExecutaStr(strSql)

            strSql = "UPDATE tblMesas Set "
            strSql &= "Flag=0, "
            strSql &= "Impresso=0 "
            strSql &= "WHERE (NumMesa=" & lbMesa.Text & ")"
            ExecutaStr(strSql)

            PedidoVenda = True
            IDVenda = 0
            frmSalao.tbMesa.Text = ""
            frmSalao.tbCodigoProduto.Text = ""
            frmSalao.tbQtde.Text = "1,000"
            frmSalao.LBProduto.Text = ""
            QtdPessoas = 1
            MesaImpressa = False
            NumMesa = 0

            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "ESTORNO", "MESA/CARTÃO " & lbMesa.Text)
            End If

            frmSalao.tbMesa.Text = ""
            frmSalao.PanelProdutos.Controls.Clear()
            frmSalao.DataSetGrid.Clear()
            frmSalao.btnConfirma.Enabled = True
            frmSalao.btnComent.Enabled = True
            frmSalao.btnQtde.Enabled = True
            frmSalao.btnVerifica.Enabled = True
            frmSalao.btnLimpaProduto.Text = "Limpa Produto   F3"
            frmSalao.MontaBotoesMesas()
        Else
            If rbPorLancamento.Checked = True Then
                If lstProdutos.SelectedItems.Count = 0 Then
                    Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                    frm1.lbMensagem.Text = "É necessário selecionar ao menos 1 lançamento"
                    frm1.btnNao.Visible = False
                    frm1.btnSim.Visible = False
                    frm1.btnOK.Visible = True
                    frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm1.ShowDialog()
                    Exit Sub
                End If

                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Confirma o estono dos itens selecionados"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = False Then
                    Exit Sub
                End If

                For i = 0 To lstProdutos.SelectedItems.Count - 1
                    Campo = NuloString(Trim(Strings.Right(lstProdutos.SelectedItems(i).ToString, 15)))
                    ID = NuloInteger(Strings.Right(Campo, Len(Campo) - InStr(Campo, "_")))
                    strSql = "UPDATE tblVendasMovto Set "
                    strSql &= "Excluido=1, "
                    strSql &= "Venda=0, "
                    strSql &= "Impresso = 0, "
                    strSql &= "VendaServico=0, "
                    strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                    strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                    strSql &= "HoraPedido='" & Now & "', "
                    strSql &= "MotivoEstorno='" & Motivo & "' "
                    strSql &= "WHERE (IDVendaMovto=" & ID & ")"
                    ExecutaStr(strSql)

                    If RegistraLog = True Then
                        strSql = "SELECT IDVendaMovto, Produto, Qtd FROM tblVendasMovto WHERE (IDVendaMovto=" & ID & ")"
                        IncluirLog(NomeTerminal, Operador, "ESTORNO PRODUTO", "(" & PegaValorCampo("Qtd", strSql, strCon) & ") " & PegaValorCampo("Produto", strSql, strCon))
                    End If

                Next

            Else
                If lstProdutos.SelectedItems.Count = 0 Then
                    Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                    frm1.lbMensagem.Text = "É necessário selecionar 1 lançamento"
                    frm1.btnNao.Visible = False
                    frm1.btnSim.Visible = False
                    frm1.btnOK.Visible = True
                    frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm1.ShowDialog()
                    Exit Sub
                End If
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                'If tbCodigoProduto.Text = "" Then
                'frm.lbMensagem.Text = "É necessário selecionar 1 lançamento"
                'frm.btnNao.Visible = False
                'frm.btnSim.Visible = False
                'frm.btnOK.Visible = True
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                'frm.ShowDialog()
                'Exit Sub
                'End If
                If tbQtde.Text = "" Then
                    frm.lbMensagem.Text = "Quantidade inválida"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbQtde.Text = ""
                    tbQtde.Focus()
                    Exit Sub
                End If
                If Not IsNumeric(tbQtde.Text) Then
                    frm.lbMensagem.Text = "Quantidade inválida"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbQtde.Text = ""
                    tbQtde.Focus()
                    Exit Sub
                End If
                If tbQtde.Text = 0 Then
                    frm.lbMensagem.Text = "Quantidade inválida"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    tbQtde.Text = ""
                    tbQtde.Focus()
                    Exit Sub
                End If

                'Dim qtdeProd As Decimal
                'If tbQtde.Text > GridProdutos.Item(4, GridProdutos.CurrentRow.Index).Value Then
                'frm.lbMensagem.Text = "Quantidade superior a permitida"
                'frm.btnNao.Visible = False
                'frm.btnSim.Visible = False
                'frm.btnOK.Visible = True
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                'frm.ShowDialog()

                'tbQtde.Text = ""
                'tbQtde.Focus()
                'Exit Sub
                'End If

                frm.lbMensagem.Text = "Confirma o estono do item selecionado"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = False Then
                    Exit Sub
                End If
                Dim Quant As Decimal = tbQtde.Text
                Dim Imprime As Integer
                Dim con As New SqlConnection()
                Dim dr As SqlDataReader

                con.ConnectionString = strCon
                Dim cmd As SqlCommand = con.CreateCommand

                Dim qtdeProd As Decimal

                Campo = NuloString(Trim(Strings.Right(lstProdutos.SelectedItem, 15)))
                ID = NuloInteger(Strings.Right(Campo, Len(Campo) - InStr(Campo, "_")))
                If NuloInteger(ID) = 0 Then
                    strSql = "Select SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.IDVenda, tblVendasMovto.IDProduto, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.Atendente, tblVendasMovto.IDFuncionario, tblVendasMovto.Categoria "
                    strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
                    strSql += "Where (tblVendasMovto.Excluido = 0) "
                    strSql += "Group By tblVendasMovto.IDVenda, tblVendasMovto.IDProduto, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.Atendente, tblVendasMovto.IDFuncionario, tblVendasMovto.Categoria "
                    strSql += "HAVING(tblProdutos_Local.CodigoProduto = " & tbCodigoProduto.Text & ") And (tblVendasMovto.IDVenda = " & IDVenda & ") "
                    strSql += "ORDER BY SUM(tblVendasMovto.Qtd)"
                    qtdeProd = NuloDecimal(PegaValorCampo("Qtde", strSql, strCon))

                    strSql = "Select tblVendasMovto.Qtd, tblVendasMovto.IDVenda, tblVendasMovto.IDProduto, tblProdutos_Local.CodigoProduto, tblVendasMovto.IDVendaMovto, tblVendasMovto.Produto, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.Atendente, tblVendasMovto.IDFuncionario, tblVendasMovto.Categoria, tblVendasMovto.ComServico "
                    strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
                    strSql += "Where (tblVendasMovto.Excluido = 0) And (tblProdutos_Local.CodigoProduto =" & tbCodigoProduto.Text & ") AND (tblVendasMovto.IDVenda =" & IDVenda & ") "
                    strSql += "ORDER BY tblVendasMovto.Qtd"
                Else
                    strSql = "Select tblVendasMovto.Qtd, tblVendasMovto.IDVenda, tblVendasMovto.IDProduto, tblProdutos_Local.CodigoProduto, tblVendasMovto.IDVendaMovto, tblVendasMovto.Produto, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.Atendente, tblVendasMovto.IDFuncionario, tblVendasMovto.Categoria, tblVendasMovto.ComServico "
                    strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
                    strSql += "Where (tblVendasMovto.Excluido = 0) And (tblVendasMovto.IDVendaMovto = " & ID & ") And (tblVendasMovto.IDVenda = " & IDVenda & ") "
                    strSql += "Order By tblVendasMovto.Qtd"
                    qtdeProd = NuloDecimal(PegaValorCampo("Qtd", strSql, strCon))
                End If


                If NuloDecimal(tbQtde.Text) > NuloDecimal(qtdeProd) Then
                    Dim frm3 As fdlgMensagemBox = New fdlgMensagemBox
                    frm3.lbMensagem.Text = "Quantidade superior a permitida"
                    frm3.btnNao.Visible = False
                    frm3.btnSim.Visible = False
                    frm3.btnOK.Visible = True
                    frm3.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm3.ShowDialog()

                    tbQtde.Text = ""
                    tbQtde.Focus()
                    Exit Sub
                End If


                cmd.CommandText = strSql
                con.Open()
                dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                Dim entrou As Boolean = False
                If dr.HasRows Then
                    While (dr.Read())
                        ID = dr.Item("IDVendaMovto")

                        If RegistraLog = True And entrou = False Then
                            strSql = "SELECT IDVendaMovto, Produto, Qtd FROM tblVendasMovto WHERE (IDVendaMovto=" & ID & ")"
                            IncluirLog(NomeTerminal, Operador, "ESTORNO PRODUTO", "(" & Quant & ") " & PegaValorCampo("Produto", strSql, strCon))
                            entrou = True
                        End If


                        If Quant > 0 Then
                            If Quant - dr.Item("Qtd") = 0 Then
                                strSql = "UPDATE tblVendasMovto Set "
                                strSql += "Excluido=1, "
                                strSql += "Venda=0, "
                                strSql += "VendaServico=0, "
                                strSql &= "Impresso=0, "
                                'strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                                'strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                                strSql &= "HoraPedido='" & Now & "', "
                                strSql += "MotivoEstorno='" & Motivo & "' "
                                strSql += "WHERE (IDVendaMovto=" & ID & ")"
                                ExecutaStr(strSql)
                                Quant -= dr.Item("Qtd")

                            Else
                                If Quant - dr.Item("Qtd") > 0 Then
                                    strSql = "UPDATE tblVendasMovto Set "
                                    strSql += "Excluido=1, "
                                    strSql += "Venda=0, "
                                    strSql += "VendaServico=0, "
                                    strSql &= "Impresso=0, "
                                    strSql &= "HoraPedido='" & Now & "', "
                                    'strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                                    'strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                                    strSql += "MotivoEstorno='" & Motivo & "' "
                                    strSql += "WHERE (IDVendaMovto=" & ID & ")"
                                    ExecutaStr(strSql)
                                    Quant -= dr.Item("Qtd")
                                Else
                                    If Quant - dr.Item("Qtd") < 0 Then
                                        strSql = "UPDATE tblVendasMovto Set "
                                        strSql += "Qtd=" & Replace(dr.Item("Qtd") - Quant, ",", ".") & " "
                                        strSql += "WHERE (IDVendaMovto=" & ID & ")"
                                        ExecutaStr(strSql)

                                        If ImpEstorno = True Then
                                            Imprime = 0
                                        Else
                                            Imprime = 1
                                        End If
                                        InserirItemVenda(dr.Item("IDVenda"), dr.Item("IDProduto"), dr.Item("Produto"), Quant, 1, 0, 0, dr.Item("Categoria"), Date.Now.ToString, dr.Item("IDFuncionario"), dr.Item("Atendente"), dr.Item("IDGrupo"), dr.Item("Grupo"), 1, Motivo, Imprime, "", frmSalao.lbTerminal.Text, Imprime, 0, dr.Item("ComServico"), True)

                                        Quant -= dr.Item("Qtd")
                                    End If
                                End If
                            End If

                        End If
                    End While
                End If
            End If
        End If

        PedidoVenda = False
        frmSalao.VerificaMesaGrid()
        AtualizaGrid()

        If ImpEstorno = True Then
            CriaCupomEstorno()
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\estorno.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
            strSql = "UPDATE tblVendasMovto Set "
            strSql &= "Impresso=1 "
            strSql += "WHERE (IDVenda=" & IDVenda & ") AND (Excluido=1)"
            ExecutaStr(strSql)
        End If
        If TableAtivo = True Then InformaStatusTablet(lbMesa.Text)

        Me.Dispose()
        Me.Close()
        frmSalao.tbMesa.Focus()

    End Sub


    Private Sub tbQtde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtde.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            btnConfirma.Focus()
        End If
    End Sub

    Private Sub tbQtde_GotFocus(sender As Object, e As EventArgs) Handles tbQtde.GotFocus
        Foco = "Qtde"
    End Sub
    Private Sub CliqueNoBotao(valor As String)
        If Foco = "Qtde" Then
            tbQtde.Text &= valor
            tbQtde.Focus()
        End If
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CliqueNoBotao("9")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Foco = "Qtde" Then
            tbQtde.Text = String.Empty
            tbQtde.Focus()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CliqueNoBotao(",")
    End Sub
    Private Sub CriaCupomEstorno()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim campo As String
        Dim Motivo As String
        Dim Cabec As Boolean = True

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Excluido, tblVendasMovto.MotivoEstorno, tblVendasMovto.Impresso, tblVendasMovto.IDProduto, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.StatusVenda "
        strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        strSql += "Group By tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.MotivoEstorno, tblVendasMovto.IDProduto, tblVendasMovto.Excluido, tblVendasMovto.Impresso, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.StatusVenda "
        strSql += "HAVING(tblVendasMovto.Excluido = 1) And (tblVendasMovto.Impresso = 0) And (tblVendasMovto.IDVenda = " & IDVenda & ") "
        strSql += "ORDER BY tblVendasMovto.MotivoEstorno, tblVendasMovto.Produto"

        Try
1:

            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                FileClose(lngFile)
                FileOpen(lngFile, Application.StartupPath & "\Impressao\estorno.txt", OpenMode.Output)

                texto = Chr(14) & "PRODUTOS ESTORNADOS" & Chr(27) & Chr(14)
                PrintLine(lngFile, texto)
                texto = "-------------------------------------------------"
                PrintLine(lngFile, texto)
                texto = "Operador:  " & Operador
                PrintLine(lngFile, texto)
                texto = Now.ToString
                PrintLine(lngFile, texto)


                While (dr.Read())
                    If Cabec = True Then
                        If dr.Item("StatusVenda") = "S" Then
                            texto = "ORIGEM: Salao    MESA: " & dr.Item("NumMesa") & "    VENDA: " & dr.Item("NumVenda")
                        Else
                            If dr.Item("StatusVenda") = "B" Then
                                texto = "ORIGEM: Balcao       VENDA: " & dr.Item("NumVenda")
                            Else
                                texto = "ORIGEM: Delivery     VENDA: " & dr.Item("NumVenda")
                            End If
                        End If

                        PrintLine(lngFile, texto)
                        texto = "=================================================="
                        PrintLine(lngFile, texto)
                        Cabec = False
                    End If
                    Motivo = dr.Item("MotivoEstorno")
                    PrintLine(lngFile, ">>> " & Motivo & " <<<")
                    While Motivo = dr.Item("MotivoEstorno")
                        campo = Space(6 - Len(dr.Item("CodigoProduto").ToString)) & dr.Item("CodigoProduto")
                        campo &= " " & dr.Item("Produto") & Space(30 - Len(Trim(dr.Item("Produto"))))
                        campo &= " " & Format(dr.Item("Qtde"), "#0.000")
                        texto = campo
                        PrintLine(lngFile, texto)
                        If dr.Read() = False Then
                            Exit While
                        End If
                    End While
                    PrintLine(lngFile, " ")
                End While

                PrintLine(lngFile, "==================================================")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")

                FileClose(lngFile)


            End If
            dr.Close()
            con.Dispose()
            con.Close()

        Catch ex As Exception
            If InStr(1, ex.Message, "localizar") > 0 Then
                Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\estorno.txt")
                fs.Close()
                GoTo 1
            Else
                MsgBox(ex.Message)
            End If

        End Try


    End Sub

    Private Sub fdlgEstorno_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
#Disable Warning BC42025 ' Acesso do membro compartilhado, membro constante, membro enumerado ou tipo aninhado por meio de uma instância
            Case Keys.KeyCode.F7
#Enable Warning BC42025 ' Acesso do membro compartilhado, membro constante, membro enumerado ou tipo aninhado por meio de uma instância
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnSai, e)

        End Select
    End Sub

    Private Sub GridMotivo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridMotivo.CellContentClick
        tbQtde.Focus()
    End Sub

    Private Sub rbPorLancamento_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorLancamento.CheckedChanged
        AtualizaGridProdutos()
        If lstProdutos.SelectedIndex > 0 Then
            lstProdutos.ClearSelected()
        End If
        lstProdutos.SelectionMode = SelectionMode.MultiSimple
        AtualizaGridMotivos()
        lstProdutos.ClearSelected()
    End Sub

    Private Sub rbPorQuantidade_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorQuantidade.CheckedChanged
        AtualizaGridProdutos()
        If lstProdutos.SelectedIndex > 0 Then
            lstProdutos.ClearSelected()
        End If
        AtualizaGridMotivos()
        lstProdutos.SelectionMode = SelectionMode.One
        lstProdutos.ClearSelected()
        tbQtde.Focus()
    End Sub

    Private Sub fdlgEstorno_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub tbQtde_TextChanged(sender As Object, e As EventArgs) Handles tbQtde.TextChanged

    End Sub

    Private Sub chkEstornaMesa_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstornaMesa.CheckedChanged

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If NivelFuncionario < 3 And chkEstornaMesa.Checked = True Then
            frm.lbMensagem.Text = "Operador deve ter permissão de acesso nível Gerência"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            lstProdutos.Focus()
            chkEstornaMesa.Checked = False
            Exit Sub
        End If


        If lstProdutos.SelectedIndex > 0 Then
            lstProdutos.ClearSelected()
        End If
        AtualizaGridMotivos()
    End Sub

    Private Sub LstProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProdutos.SelectedIndexChanged

    End Sub

    Private Sub lstProdutos_Click(sender As Object, e As EventArgs) Handles lstProdutos.Click
        If lstProdutos.Items.Count > 0 Then
            If rbPorQuantidade.Checked = True Then
                tbCodigoProduto.Text = NuloString(Trim(Strings.Right(lstProdutos.SelectedItem, 15)))
                tbCodigoProduto.Text = NuloInteger(Strings.Left(tbCodigoProduto.Text, InStr(tbCodigoProduto.Text, "_") - 1))
                tbQtde.Focus()
            End If
        End If
        tbQtde.Focus()
    End Sub
End Class