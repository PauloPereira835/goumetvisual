Imports System.Data.SqlClient
Imports System.IO

Public Class fdlgTransferencias
    Public Foco As String
    Public Sub AtualizaGridProdutos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim ID As Integer = 0
        Dim IDMovto As Integer
        Dim Status As String
        Dim HPedido As String
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridProdutos.Rows.Clear()

        If rbPorLancamento.Checked = True Then
            SqlStr = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendasMovto.IDVendaMovto, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasCombo.Produto As ProdutoCombo, tblVendasMovto.HoraPedido "
            SqlStr += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
            SqlStr += "Where(tblVendas.IDVenda = " & IDVenda & ") And (tblVendasMovto.Excluido = 0) "
            SqlStr += "Order By tblVendasMovto.Produto"
        Else
            SqlStr = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtd, tblVendasCombo.Produto As ProdutoCombo, tblVendasCombo.IDVendaMovto "
            SqlStr += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
            SqlStr += "Where (tblVendasMovto.Excluido = 0) "
            SqlStr += "Group By tblVendas.IDVenda, tblVendas.NumVenda, tblVendasMovto.IDProduto, tblVendasMovto.Produto, tblVendasCombo.Produto, tblProdutos_Local.CodigoProduto, tblVendasCombo.IDVendaMovto "
            SqlStr += "HAVING(tblVendas.IDVenda = " & IDVenda & ") "
            SqlStr += "ORDER BY tblVendasCombo.IDVendaMovto, tblVendasMovto.Produto"
        End If

        cmd.CommandText = SqlStr

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            Status = "P"
            While (dr.Read())
                If rbPorQuantidade.Checked = False Then
                    If IDMovto <> NuloInteger(dr.Item("IDVendaMovto")) Then
                        Status = "P"
                    End If
                    IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                    HPedido = NuloString(dr.Item("HoraPedido"))
                Else
                    If IDMovto <> NuloInteger(dr.Item("IDVendaMovto")) Then
                        Status = "P"
                    End If
                    IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                    HPedido = ""
                End If
                If IsDBNull(dr.Item("ProdutoCombo")) Then
                    If rbPorQuantidade.Checked = False Then
                        GridProdutos.Rows.Add({ID, NuloInteger(dr.Item("IDVendaMovto")), NuloInteger(dr.Item("CodigoProduto")), NuloString(dr.Item("Produto")), NuloDecimal(dr.Item("Qtd")), HPedido})
                        ID += 1
                        Status = "P"
                        IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                    Else
                        GridProdutos.Rows.Add({ID, NuloInteger(dr.Item("IDVenda")), NuloInteger(dr.Item("CodigoProduto")), NuloString(dr.Item("Produto")), NuloDecimal(dr.Item("Qtd")), ""})
                        ID += 1
                        Status = "P"
                        IDMovto = NuloInteger(dr.Item("IDVenda"))
                    End If
                Else
                    If Status = "P" Then
                        If rbPorLancamento.Checked = True Then
                            GridProdutos.Rows.Add({ID, NuloInteger(IDMovto), NuloInteger(dr.Item("CodigoProduto")), NuloString(dr.Item("Produto")), NuloDecimal(dr.Item("Qtd")), HPedido})
                            ID += 1
                        Else
                            GridProdutos.Rows.Add({ID, NuloInteger(IDMovto), NuloInteger(dr.Item("CodigoProduto")), NuloString(dr.Item("Produto")), NuloDecimal(dr.Item("Qtd")), HPedido})
                            ID += 1
                        End If
                        GridProdutos.Rows.Add({ID, NuloInteger(IDMovto), "", NuloString(dr.Item("ProdutoCombo")), "", ""})
                        ID += 1
                        Status = "PC"
                        'IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                    Else
                        'If IDMovto = NuloInteger(dr.Item("IDVendaMovto")) Then
                        If rbPorQuantidade.Checked = False Then
                            GridProdutos.Rows.Add({ID, NuloInteger(dr.Item("IDVendaMovto")), "", NuloString(dr.Item("ProdutoCombo")), "", ""})
                            ID += 1
                        Else
                            'GridProdutos.Rows.Add({ID, NuloInteger(IDMovto), NuloInteger(dr.Item("CodigoProduto")), NuloString(dr.Item("Produto")), NuloDecimal(dr.Item("Qtd")), HPedido})
                            GridProdutos.Rows.Add({ID, NuloInteger(IDMovto), "", NuloString(dr.Item("ProdutoCombo")), "", HPedido})
                            ID += 1
                            Status = "PC"
                            '     IDMovto = NuloInteger(dr.Item("IDVendaMovto"))
                        End If
                    End If
                End If
            End While
        End If

        Dim fontSelecionado As New Font("Courier New", 12, FontStyle.Bold)
        Dim fontNSelecionado As New Font("Courier New", 10, FontStyle.Regular)

        If rbPorQuantidade.Checked = True Then
            tbQuantidade.Visible = True
            lbQuantidade.Visible = True
            lbHoraPedido.Visible = False
            chkTransfereMesa.Enabled = False
        Else
            tbQuantidade.Visible = False
            lbQuantidade.Visible = False
            lbHoraPedido.Visible = True
            chkTransfereMesa.Enabled = True
        End If
        LinhaGridProdutos()

    End Sub
    Public Sub AtualizaGridMotivos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        cmd.CommandText = "Select Motivo From tblMotivosEstorno WHERE Transferencia=1 Order By Motivo"

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
    Public Sub LinhaGridProdutos()
        Dim TotalLinhas As Integer = GridProdutos.Rows.Count

        If TotalLinhas = 0 Then Exit Sub

        Dim Status As String
        Dim fontBold As New Font("Sans Serif", 8, FontStyle.Bold)
        Dim fontRegular As New Font("Sans Serif", 8, FontStyle.Regular)
        Dim fontItalic As New Font("Sans Serif", 8, FontStyle.Italic)

        With GridProdutos
            If TotalLinhas <> 0 Then
                For i As Integer = 0 To TotalLinhas - 1
                    Status = NuloString(.Item(2, i).Value)
                    If Status <> "" Then
                        .Rows(i).DefaultCellStyle.Font = fontBold
                    Else
                        .Rows(i).DefaultCellStyle.Font = fontItalic
                    End If

                Next i
            End If

        End With
    End Sub

    Private Sub fdlgTransferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = False
        chkTransfereMesa.Text = "Transfere " & TextoMesaPAR
        tbMesaDestino.Focus()
        rbPorLancamento.Checked = True
        lbMesaOrigem.Text = frmSalao.tbMesa.Text
        AtualizaGridProdutos()
        AtualizaGridMotivos()
        'LinhaGridProdutos()

        If GridProdutos.Rows.Count > 0 Then
            For i As Integer = 0 To GridProdutos.Rows.Count - 1
                If GridProdutos.Rows(i).Selected = True Then
                    GridProdutos.Rows(i).Selected = False
                End If
            Next
        End If
        tbMesaDestino.Focus()

    End Sub

    Private Sub btnSai_Click(sender As Object, e As EventArgs) Handles btnSai.Click
        Me.Dispose()
        Me.Close()
        'frmSalao.Grid.Rows(0).Selected = False
    End Sub


    Function PegaIDVendaDestino() As Integer

        Dim IDVendaDestino As Integer
        Dim con As New SqlConnection()
        strSql = "Select MAX(IDVenda) As NIDVenda From tblVendas WITH (TABLOCKX)"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            IDVendaDestino = NuloInteger(dr.Item("NIDVenda"))
        Else
            IDVendaDestino = 1
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Return IDVendaDestino

    End Function
    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        Dim Motivo As String = ""
        Dim StTransf As String = ""
        Dim ID As Integer
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

        If NuloInteger(lbMesaOrigem.Text) = NuloInteger(tbMesaDestino.Text) Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = TextoMesaPAR & " destino não pode ser igual a origem"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        If rbPorQuantidade.Checked = False Then
            If GridProdutos.SelectedRows.Count = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar ao menos 1 lançamento"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            If IsDBNull(tbIDVendaDestino.Text) Or tbIDVendaDestino.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar a Mesa/Cartão de destino"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesaDestino.Focus()
                Exit Sub
            End If

            If chkTransfereMesa.Checked = True Then
                'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                'frm.lbMensagem.Text = "Confirma a transferência da Mesa/Cartão " & lbMesaOrigem.Text & " para " & tbMesaDestino.Text
                'frm.btnNao.Visible = True
                'frm.btnSim.Visible = True
                'frm.btnOK.Visible = False
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                'frm.ShowDialog()
                'If RetornoMsg = False Then
                ''tbFuga.Focus()
                'Exit Sub
                'End If

                If MsgBox("Confirma a transferência da " & TextoMesaPAR, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If

            Else
                'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                'frm.lbMensagem.Text = "Confirma a transferência dos itens selecionados"
                'frm.btnNao.Visible = True
                'frm.btnSim.Visible = True
                'frm.btnOK.Visible = False
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                'frm.ShowDialog()
                'If RetornoMsg = False Then
                ''tbFuga.Focus()
                'Exit Sub
                'End If
                If MsgBox("Confirma a transferência dos itens selecionados", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            If IsDBNull(Motivo) Or Motivo = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar um motivo"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                GridMotivo.Focus()
                Exit Sub
            End If

            If GridProdutos.SelectedRows.Count > 0 Then
                Dim drc As DataGridViewSelectedRowCollection = GridProdutos.SelectedRows
                For i As Integer = 0 To drc.Count - 1
                    ID = drc(i).Cells(1).Value

                    strSql = "SELECT StatusTransf FROM tblVendasMovto WHERE (IDVendaMovto=" & ID & ")"
                    StTransf = NuloString(PegaValorCampo("StatusTransf", strSql, strCon))

                    strSql = "UPDATE tblVendasMovto Set "
                    strSql += "IDVenda=" & tbIDVendaDestino.Text & ", "
                    If StTransf = "" Then
                        strSql += "StatusTransf='DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text & "', "
                        StTransf = "DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text
                    Else
                        If Len(StTransf & " / DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text & "', ") <= 250 Then
                            StTransf &= " / DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text
                        Else
                            StTransf &= " / DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text
                        End If
                        strSql += "StatusTransf='" & StTransf & "', "
                    End If
                    strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                    strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                    strSql += "MotivoEstorno='" & Motivo & "', "
                    strSql &= "Imprime=0, "
                    strSql &= "Impresso=0 "
                    strSql += "WHERE (IDVendaMovto=" & ID & ")"
                    ExecutaStr(strSql)

                    If RegistraLog = True Then
                        IncluirLog(NomeTerminal, Operador, "TRANSFERÊNCIA DE PRODUTO", "(" & drc(i).Cells(4).Value & ") " & drc(i).Cells(3).Value & " " & StTransf)
                    End If
                Next
            End If

            If chkTransfereMesa.Checked = True Then
                Dim QtdePess As Integer
                strSql = "SELECT QtdPessoas FROM tblVendas WHERE (IDVenda=" & IDVenda & ")"
                QtdePess = NuloInteger(PegaValorCampo("QtdPessoas", strSql, strCon))

                strSql = "SELECT QtdPessoas FROM tblVendas WHERE (IDVenda=" & tbIDVendaDestino.Text & ")"
                QtdePess += NuloInteger(PegaValorCampo("QtdPessoas", strSql, strCon))

                strSql = "UPDATE tblVendas Set "
                strSql &= "IDFechamento=" & IDFechamento & ", "
                strSql &= "Excluido=1, "
                strSql += "FlagFechada=1, "
                strSql += "Status='DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text & "', "
                strSql &= "IDFuncionarioAtendente=" & IDFuncionarioAutorizado & ", "
                strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                strSql &= "MotivoEstorno='" & Motivo & "' "
                strSql &= "WHERE (IDVenda=" & IDVenda & ")"
                ExecutaStr(strSql)

                strSql = "UPDATE tblVendas Set "
                strSql &= "QtdPessoas=" & QtdePess & " "
                strSql &= "WHERE (IDVenda=" & tbIDVendaDestino.Text & ")"
                ExecutaStr(strSql)

                strSql = "UPDATE tblVendasMovto Set "
                strSql &= "IDVenda=" & tbIDVendaDestino.Text & " "
                strSql &= "WHERE (IDVenda=" & IDVenda & ") AND (Excluido=0)"
                ExecutaStr(strSql)

                strSql = "UPDATE tblVendasPagto Set "
                strSql &= "IDVenda=" & tbIDVendaDestino.Text & " "
                strSql &= "WHERE (IDVenda=" & IDVenda & ")"
                ExecutaStr(strSql)


                strSql = "UPDATE tblMesas Set "
                If ImpTransferencia = True Then
                    strSql &= "Flag=0, "
                    strSql &= "Impresso=0 "
                Else
                    strSql &= "Flag=0 "
                End If
                strSql &= "WHERE (NumMesa=" & lbMesaOrigem.Text & ")"
                ExecutaStr(strSql)

                If RegistraLog = True Then
                    IncluirLog(NomeTerminal, Operador, "TRANSFERÊNCIA DE MESA", "DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text)
                End If

                PedidoVenda = True

                IDVenda = 0
                frmSalao.tbMesa.Text = ""
                frmSalao.tbCodigoProduto.Text = ""
                frmSalao.tbQtde.Text = "1,000"
                frmSalao.LBProduto.Text = ""
                QtdPessoas = 1
                MesaImpressa = False
                NumMesa = 0

                frmSalao.tbMesa.Text = ""
                frmSalao.PanelProdutos.Controls.Clear()
                frmSalao.DataSetGrid.Clear()
                frmSalao.btnConfirma.Enabled = True
                frmSalao.btnComent.Enabled = True
                frmSalao.btnQtde.Enabled = True
                frmSalao.btnVerifica.Enabled = True
                frmSalao.btnLimpaProduto.Text = "Limpa Produto   F3"
                frmSalao.MontaBotoesMesas()
                AtualizaGrid()
            End If
        Else
            If GridProdutos.SelectedRows.Count = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar um lançamento"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                Exit Sub
            End If
            If tbCodigoProduto.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar um lançamento"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                Exit Sub
            End If
            If tbQuantidade.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Quantidade inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbQuantidade.Text = ""
                tbQuantidade.Focus()
                Exit Sub
            End If
            If Not IsNumeric(tbQuantidade.Text) Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Quantidade inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbQuantidade.Text = ""
                tbQuantidade.Focus()
                Exit Sub
            End If
            If tbQuantidade.Text = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Quantidade inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbQuantidade.Text = ""
                tbQuantidade.Focus()
                Exit Sub
            End If
            If tbQuantidade.Text > GridProdutos.Item(4, GridProdutos.CurrentRow.Index).Value Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Quantidade superior a permitida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbQuantidade.Text = ""
                tbQuantidade.Focus()
                Exit Sub
            End If

            If IsDBNull(tbIDVendaDestino.Text) Or tbIDVendaDestino.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar a Mesa/Cartão de destino"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesaDestino.Focus()
                Exit Sub
            End If


            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Confirma a transferência do item selecionado"
            frm1.btnNao.Visible = True
            frm1.btnSim.Visible = True
            frm1.btnOK.Visible = False
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm1.ShowDialog()
            If RetornoMsg = False Then Exit Sub


            Dim Quant As Decimal = tbQuantidade.Text
            Dim con As New SqlConnection()
            Dim dr As SqlDataReader

            con.ConnectionString = strCon
            Dim cmd As SqlCommand = con.CreateCommand
            strSql = "Select tblVendasMovto.Qtd, tblVendasMovto.IDVenda, tblVendasMovto.IDProduto, tblProdutos_Local.CodigoProduto, tblVendasMovto.IDVendaMovto, tblVendasMovto.Produto, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.Atendente, tblVendasMovto.IDFuncionario, tblVendasMovto.Categoria, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasMovto.ComServico "
            strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
            strSql += "Where (tblVendasMovto.Excluido = 0) And (tblProdutos_Local.CodigoProduto =" & tbCodigoProduto.Text & ") And (tblVendasMovto.IDVenda =" & IDVenda & ")"
            strSql += "ORDER BY tblVendasMovto.Qtd"

            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While (dr.Read())
                    ID = dr.Item("IDVendaMovto")
                    If Quant > 0 Then
                        If Quant - dr.Item("Qtd") = 0 Then
                            strSql = "UPDATE tblVendasMovto Set "
                            strSql += "IDVenda=" & tbIDVendaDestino.Text & ", "
                            strSql += "StatusTransf='DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text & "', "
                            strSql &= "Imprime=0, "
                            strSql += "Impresso=0, "
                            strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                            strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                            strSql += "MotivoEstorno='" & Motivo & "' "
                            strSql += "WHERE (IDVendaMovto=" & ID & ")"
                            ExecutaStr(strSql)
                            Quant -= dr.Item("Qtd")
                        Else
                            If Quant - dr.Item("Qtd") > 0 Then
                                strSql = "UPDATE tblVendasMovto Set "
                                strSql += "IDVenda=" & tbIDVendaDestino.Text & ", "
                                strSql += "StatusTransf='DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text & "', "
                                strSql &= "Imprime=0, "
                                strSql += "Impresso=0, "
                                strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                                strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                                strSql += "MotivoEstorno='" & Motivo & "' "
                                strSql += "WHERE (IDVendaMovto=" & ID & ")"
                                ExecutaStr(strSql)
                                Quant -= dr.Item("Qtd")
                            Else
                                If Quant - dr.Item("Qtd") < 0 Then
                                    strSql = "UPDATE tblVendasMovto Set "
                                    strSql += "IDVenda=" & tbIDVendaDestino.Text & ", "
                                    strSql += "StatusTransf='DE: " & lbMesaOrigem.Text & "  PARA: " & tbMesaDestino.Text & "', "
                                    strSql &= "Imprime=0, "
                                    strSql += "Impresso=0, "
                                    strSql &= "IDFuncionario=" & IDFuncionarioAutorizado & ", "
                                    strSql &= "Atendente='" & FuncionarioAutorizado & "', "
                                    strSql += "MotivoEstorno='" & Motivo & "', "
                                    strSql += "Qtd=" & Replace(Quant, ",", ".") & " "
                                    strSql += "WHERE (IDVendaMovto=" & ID & ")"
                                    ExecutaStr(strSql)

                                    InserirItemVenda(IDVenda, dr.Item("IDProduto"), dr.Item("Produto"), dr.Item("Qtd") - Quant, 1, dr.Item("Venda"), dr.Item("VendaServico"), dr.Item("Categoria"), Date.Now.ToString, dr.Item("IDFuncionario"), dr.Item("Atendente"), dr.Item("IDGrupo"), dr.Item("Grupo"), 0, "", 1, "", frmSalao.lbTerminal.Text, Imprime, 0, dr.Item("ComServico"), True)

                                    Quant -= dr.Item("Qtd")
                                End If
                            End If
                        End If

                    End If
                End While
            End If
        End If

        If ImpTransferencia = True Then
            CriaCupomTransferencia()
            ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\transferencia.txt")
            If GuilhotinaImpCaixa = True Then
                ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
            End If
            strSql = "UPDATE tblVendasMovto Set "
            strSql &= "Impresso=1 "
            strSql += "WHERE (IDVenda=" & tbIDVendaDestino.Text & ") AND (StatusTransf IS NOT NULL)"
            ExecutaStr(strSql)
        End If

        If TableAtivo = True Then
            InformaStatusTablet(lbMesaOrigem.Text)
            InformaStatusTablet(tbMesaDestino.Text)
        End If

        IDVenda = 0
        frmSalao.tbMesa.Text = ""

        Me.Dispose()
        Me.Close()

        frmSalao.DataSetGrid.Clear()
        frmSalao.Grid.Refresh()
        frmSalao.MontaBotoesMesas()
        CalculaTotais()
        frmSalao.MontaGruposSalao(1)

        frmSalao.tbMesa.Focus()
    End Sub
    Public Sub CriaCupomTransferencia()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim campo As String
        Dim Motivo As String
        Dim Cabec As Boolean = True

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Excluido, tblVendasMovto.MotivoEstorno, tblVendasMovto.Impresso, tblVendasMovto.IDProduto, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.StatusVenda, tblVendasMovto.StatusTransf "
        strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        strSql += "Group By tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.MotivoEstorno, tblVendasMovto.IDProduto, tblVendasMovto.Excluido, tblVendasMovto.Impresso, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.StatusVenda, tblVendasMovto.StatusTransf "
        strSql += "HAVING(tblVendasMovto.Impresso=0) And (tblVendasMovto.IDVenda=" & tbIDVendaDestino.Text & ") And (tblVendasMovto.StatusTransf Is Not NULL) "
        strSql += "ORDER BY tblVendasMovto.MotivoEstorno, tblVendasMovto.Produto"

        Try
1:

            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then

                FileClose(lngFile)
                FileOpen(lngFile, Application.StartupPath & "\Impressao\transferencia.txt", OpenMode.Output)

                texto = Chr(14) & "PRODUTOS TRANFERIDOS" & Chr(27) & Chr(14)
                PrintLine(lngFile, texto)
                texto = "-------------------------------------------------"
                PrintLine(lngFile, texto)
                texto = "Operador:  " & Operador
                PrintLine(lngFile, texto)
                texto = Now.ToString
                PrintLine(lngFile, texto)

                While (dr.Read())
                    If Cabec = True Then
                        PrintLine(lngFile, dr.Item("StatusTransf"))
                        PrintLine(lngFile, "==================================================")
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


    Private Sub GridProdutos_LostFocus(sender As Object, e As EventArgs) Handles GridProdutos.LostFocus
        If chkTransfereMesa.Checked = True Then
            For i As Integer = 0 To GridProdutos.Rows.Count - 1
                If GridProdutos.Rows(i).Selected = False Then
                    GridProdutos.Rows(i).Selected = True
                End If
            Next
        End If
    End Sub

    Private Sub CliqueNoBotao(valor As String)
        If Foco = "Qtde" Then
            tbQuantidade.Text &= valor
            'tbQuantidade.Focus()
        End If
        If Foco = "M" Then
            tbMesaDestino.Text &= valor
            'tbMesaDestino.Focus()
        End If
    End Sub
    Private Sub tbQtde_GotFocus(sender As Object, e As EventArgs)
        If tbMesaDestino.Text = "" Then
            tbMesaDestino.Focus()
            Exit Sub
        End If
        Foco = "Qtde"
    End Sub

    Private Sub tbMesaDestino_GotFocus(sender As Object, e As EventArgs) Handles tbMesaDestino.GotFocus
        Foco = "M"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
            tbQuantidade.Text = ""
            tbQuantidade.Focus()
        End If
        If Foco = "M" Then
            tbMesaDestino.Text = ""
            tbMesaDestino.Focus()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Foco = "Qtde" Then tbQuantidade.Focus()
        If Foco = "M" Then tbMesaDestino.Focus()
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub GridMotivo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridMotivo.CellContentClick
        If tbIDVendaDestino.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "È necessário uma mesa destino"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            For i As Integer = 0 To GridMotivo.Rows.Count - 1
                If GridMotivo.Rows(i).Selected = False Then
                    GridMotivo.Rows(i).Selected = True
                End If
            Next
            tbMesaDestino.Focus()
        Else
            tbQuantidade.Focus()
        End If
    End Sub



    Private Sub GridProdutos_GotFocus(sender As Object, e As EventArgs) Handles GridProdutos.GotFocus
        If tbMesaDestino.Text = "" Then tbMesaDestino.Focus()

    End Sub

    Private Sub GridMotivo_GotFocus(sender As Object, e As EventArgs) Handles GridMotivo.GotFocus
        If tbMesaDestino.Text = "" Then tbMesaDestino.Focus()
    End Sub

    Private Sub fdlgTransferencias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnSai, e)
        End Select
    End Sub
    Private Sub fdlgTransferencias_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub rbPorLancamento_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorLancamento.CheckedChanged
        AtualizaGridProdutos()
        tbCodigoProduto.Text = ""
        If GridProdutos.Rows.Count > 0 Then
            For i As Integer = 0 To GridProdutos.Rows.Count - 1
                If GridProdutos.Rows(i).Selected = True Then
                    GridProdutos.Rows(i).Selected = False
                End If
            Next
        End If
        If tbMesaDestino.Text = "" Then
            tbMesaDestino.Focus()
        Else
            tbQuantidade.Focus()
        End If
    End Sub

    Private Sub rbPorQuantidade_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorQuantidade.CheckedChanged
        AtualizaGridProdutos()
        tbCodigoProduto.Text = ""
        If GridProdutos.Rows.Count > 0 Then
            For i As Integer = 0 To GridProdutos.Rows.Count - 1
                If GridProdutos.Rows(i).Selected = True Then
                    GridProdutos.Rows(i).Selected = False
                End If
            Next
        End If
        If tbMesaDestino.Text = "" Then
            tbMesaDestino.Focus()
        Else
            tbQuantidade.Focus()
        End If
    End Sub

    Private Sub fdlgTransferencias_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tbMesaDestino.Focus()
    End Sub

    Private Sub tbQuantidade_Enter(sender As Object, e As EventArgs) Handles tbQuantidade.Enter
        If tbMesaDestino.Text = "" Then tbMesaDestino.Focus()
        Foco = "Qtde"
    End Sub

    Private Sub tbQuantidade_KeyDown(sender As Object, e As KeyEventArgs) Handles tbQuantidade.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Enter
                GridProdutos.Focus()
                SendKeys.Send("{TAB}")

        End Select
    End Sub

    Private Sub tbMesaDestino_TextChanged(sender As Object, e As EventArgs) Handles tbMesaDestino.TextChanged

    End Sub

    Private Sub chkTransfereMesa_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransfereMesa.CheckedChanged
        If chkTransfereMesa.Checked = True Then
            If GridProdutos.Rows.Count > 0 Then
                For i As Integer = 0 To GridProdutos.Rows.Count - 1
                    If GridProdutos.Rows(i).Selected = False Then
                        GridProdutos.Rows(i).Selected = True
                    End If
                Next
                'btnMarcaItens.Text = "Desmarca todos itens"
            End If
        Else
            If GridProdutos.Rows.Count > 0 Then
                For i As Integer = 0 To GridProdutos.Rows.Count - 1
                    If GridProdutos.Rows(i).Selected = True Then
                        GridProdutos.Rows(i).Selected = False
                    End If
                Next
            End If
            'btnMarcaItens.Text = "Transfere a " & TextoMesaPAR
        End If
        If tbMesaDestino.Text = "" Then
            tbMesaDestino.Focus()
        Else
            tbQuantidade.Focus()
        End If
    End Sub

    Private Sub GridProdutos_Click(sender As Object, e As EventArgs) Handles GridProdutos.Click
        If GridProdutos.Rows.Count > 0 Then

            If tbIDVendaDestino.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "È necessário uma mesa destino"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                For i As Integer = 0 To GridProdutos.Rows.Count - 1
                    If GridProdutos.Rows(i).Selected = False Then
                        GridProdutos.Rows(i).Selected = True
                    End If
                Next
                tbMesaDestino.Focus()
            Else
                tbQuantidade.Focus()
            End If

            If rbPorQuantidade.Checked = True Then
                tbCodigoProduto.Text = NuloInteger(GridProdutos.Item(2, GridProdutos.CurrentRow.Index).Value)
                tbQuantidade.Focus()
            Else
                If chkTransfereMesa.Checked = True Then
                    For i As Integer = 0 To GridProdutos.Rows.Count - 1
                        If GridProdutos.Rows(i).Selected = False Then
                            GridProdutos.Rows(i).Selected = True
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub tbMesaDestino_LostFocus(sender As Object, e As EventArgs) Handles tbMesaDestino.LostFocus

        If tbMesaDestino.Text = "" Then Exit Sub

        Dim con As New SqlConnection()

        strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbMesaDestino.Text & ")"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()
            Dim conM As New SqlConnection()
            Dim drM As SqlDataReader
            strSql = "Select IDVenda, IDfechamento, NumVenda, NumMesa, Cartao, FlagFechada, Excluido, QtdPessoas, PercServico, PercDesconto, Atendente From tblVendas Where (Excluido=0) And (FlagFechada=0) And (NumMesa=" & tbMesaDestino.Text & ")"
            conM.ConnectionString = strCon
            Dim cmdM As SqlCommand = conM.CreateCommand
            cmdM.CommandText = strSql
            conM.Open()
            drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drM.HasRows Then
                drM.Read()
                tbIDVendaDestino.Text = NuloInteger(drM.Item("IDVenda"))
                GridProdutos.Focus()
            Else

                'Dim frm111 As fdlgMensagemBox = New fdlgMensagemBox
                'frm111.lbMensagem.Text = TextoMesaPAR & " não aberta, deseja abrir"
                'frm111.btnNao.Visible = True
                'frm111.btnSim.Visible = True
                'frm111.btnOK.Visible = False
                'frm111.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                'frm111.ShowDialog()
                'If RetornoMsg = True Then
                If MsgBox(TextoMesaPAR & " não aberta, deseja abrir", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    strSql = "INSERT tblVendas "
                    strSql += "(NumVenda, NumMesa, DataVenda, PercDesconto, PercServico, QtdPessoas, FlagFechada, HoraAbertura, StatusVenda, Caixa, Atendente, Excluido) VALUES ("
                    strSql += to_sql(AchaNumVenda("S")) & ","
                    strSql += to_sql(tbMesaDestino.Text) & ","
                    strSql += "'" & Date.Now & "',"
                    strSql += "0,"
                    strSql += to_sql(Replace(NuloString(PercServico), ",", ".")) & ","
                    strSql += "1,"
                    strSql += to_sql(0) & ","
                    strSql += "'" & Date.Now & "',"
                    strSql += "'S',"
                    strSql += to_sql(Caixa) & ","
                    strSql += to_sql(Operador) & ","
                    strSql += to_sql(0) & ")"
                    ExecutaStr(strSql)

                    tbIDVendaDestino.Text = PegaIDVendaDestino()

                    strSql = "UPDATE tblMesas SET "
                    strSql &= "UltimoPedido='" & Now & "', "
                    strSql &= "Flag=1,"
                    strSql &= "Impresso=0 "
                    strSql &= "WHERE (NumMesa=" & tbMesaDestino.Text & ")"
                    ExecutaStr(strSql)
                Else
                    tbIDVendaDestino.Text = ""
                    tbMesaDestino.Text = ""
                End If

            End If
            drM.Close()
            cmdM.Dispose()
            conM.Dispose()
            conM.Close()
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = TextoMesaPAR & " " & tbMesaDestino.Text & " não foi cadastrada"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesaDestino.Text = ""
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        If GridProdutos.Rows.Count > 0 Then
            For i As Integer = 0 To GridProdutos.Rows.Count - 1
                If GridProdutos.Rows(i).Selected = True Then
                    GridProdutos.Rows(i).Selected = False
                End If
            Next
        End If
        tbQuantidade.Focus()

    End Sub

    Private Sub tbMesaDestino_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMesaDestino.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            btnConfirma.Focus()
        End If
    End Sub

    Private Sub TbQuantidade_TextChanged(sender As Object, e As EventArgs) Handles tbQuantidade.TextChanged

    End Sub

    Private Sub tbMesaDestino_Enter(sender As Object, e As EventArgs) Handles tbMesaDestino.Enter
        Foco = "M"
    End Sub
End Class