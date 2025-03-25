'http://www.vb-helper.com/howto_net_shaped_button.html

Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class frmSalao
    Private paginaAtual As Integer = 0
    Public MsgTXT As String
    Public CodigoGrupo As Integer
    Public TempoTela As Integer = TempoLimite
    Public IDFamilia As Integer

    Dim linhaSelecionada As Integer
    Dim BotaoGrupoAnterior As Button
    Dim BotaoPress As Integer = 0
    Dim nn As Integer = 0
    Dim Incremento As Integer
    Dim nnMesas As Integer = 0
    Dim IncrementoMesas As Integer
    Private Sub IrDelivery()
        VerificaPedidoAppFora = False
        Me.Dispose()
        Me.Close()
        Modulo = "D"
        frmDelivery.ShowDialog()
    End Sub
    Private Sub IrSalao()
        TempoTela = TempoLimite
        Modulo = "S"
        'If PedidoVenda = True Then
        'If Grid.Rows.Count <> 0 Then
        'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        'frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
        'frm.btnNao.Visible = True
        'frm.btnSim.Visible = True
        'frm.btnOK.Visible = False
        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        'frm.ShowDialog()
        'If RetornoMsg = True Then
        'PedidoVenda = True
        'Else
        'tbCodigoProduto.Focus()
        'Exit Sub
        'End If
        'If DefinicaoReduzida = False Then
        'PanelProdutos.Size = New System.Drawing.Size(1267, 173)
        'Else
        'PanelProdutos.Size = New System.Drawing.Size(1010, 173)
        'End If
        'End If

        'DataSetGrid.Clear()
        'LinhaGrid()
        'CalculaTotais()
        'AtualizaGrid()

        'End If
        LinhaGrid()
        PedidoVenda = True
        BotaoPress = 0
        IDVenda = 0
        NumMesa = 0
        tbMesa.Text = ""
        IniciaFrm()
        VerificaMesaGrid()
        AtualizaGrid()
    End Sub
    Private Sub IrBalcao()
        TempoTela = TempoLimite
        Modulo = "B"
        If PedidoVenda = True Then
            If Grid.Rows.Count <> 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = True Then
                    PedidoVenda = True
                Else
                    tbCodigoProduto.Focus()
                    Exit Sub
                End If
            End If

            DataSetGrid.Clear()
            LinhaGrid()
            CalculaTotais()
            AtualizaGrid()
            AtualizaGrid()
        End If
        LinhaGrid()
        PedidoVenda = False
        VerificaVendaBalcao()
        If IDVenda = 0 Then
            PedidoVenda = True
        End If
        BotaoPress = 0
        'TBMesa.Text = ""
        IniciaFrm()
        VerificaMesaGrid()
        AtualizaGrid()
        tbCodigoProduto.Focus()
    End Sub
    Private Sub LimpaVenda()


        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja limpar a venda sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If

        If Modulo = "S" Then
            IDVenda = 0
            tbMesa.Text = ""
            tbMesa.Focus()
        Else
            If NuloString(tbMesa.Text) <> "" Then
                IDVenda = 0
            End If
            tbCodigoProduto.Focus()
        End If
        QtdPessoas = 0
        lbNomeCliente.Text = ""
        tbCodigoProduto.Text = ""
        LBProduto.Text = ""
        tbQtde.Text = "1,000"

        DataSetGrid.Clear()
        LinhaGrid()
        AtualizaGrid()
        'Grid.Rows(0).Selected = True
        CalculaTotais()
        StiloGrid()

    End Sub
    Public Sub ReduzDefinicao()
        Me.Size = New System.Drawing.Size(1280, 770)
        PanelProdutos.Size = New System.Drawing.Size(1010, 130)
        PanelMesas.Size = New System.Drawing.Size(980, 67)
        Panel6.Size = New System.Drawing.Size(1010, 26)
        Panel6.Location = New Point(7, 740)
        PanelModulos.Location = New Point(833, 1)
        PanelModulos.Size = New System.Drawing.Size(133, 58)
        btnVoltar.Location = New Point(965, 1)
        PictureBox.Location = New Point(638, 2)
        lbModulo.Location = New Point(715, 31)

        btnPorCliente.Location = New Point(615, 2)

        tbQtde.Location = New Point(466, 6)
        Label12.Location = New Point(424, 5)
        Panel5.Size = New System.Drawing.Size(556, 57)
        Panel3.Size = New System.Drawing.Size(150, 36)

        btnPagina_1.Size = New System.Drawing.Size(34, 29)
        btnPagina_2.Size = New System.Drawing.Size(34, 29)
        btnPagina_3.Size = New System.Drawing.Size(34, 29)
        btnPagina_4.Size = New System.Drawing.Size(34, 29)
        btnPagina_2.Location = New Point(40, 1)
        btnPagina_3.Location = New Point(76, 1)
        btnPagina_4.Location = New Point(110, 1)
        btnMenos.Location = New Point(980, 494)
        btnMais.Location = New Point(980, 532)

        Dim myfont As New Font("Sans Serif", 9, FontStyle.Regular)
        Panel2.Size = New System.Drawing.Size(149, 381)

        btnComent.Size = New System.Drawing.Size(143, 36)
        btnComent.Font = myfont

        btnQtde.Size = New System.Drawing.Size(143, 38)
        btnQtde.Font = myfont

        btnMensagens.Size = New System.Drawing.Size(143, 38)
        btnMensagens.Font = myfont

        btnLimpaProduto.Size = New System.Drawing.Size(143, 38)
        btnLimpaProduto.Font = myfont

        btnConta.Size = New System.Drawing.Size(143, 38)
        btnConta.Font = myfont

        btnTransferencia.Size = New System.Drawing.Size(143, 36)
        btnTransferencia.Font = myfont
        'btnTransferencia.Location = New Point(2, 193)

        btnPagamento.Size = New System.Drawing.Size(143, 36)
        btnPagamento.Font = myfont
        'btnPagamento.Location = New Point(2, 231)

        btnVerifica.Size = New System.Drawing.Size(143, 36)
        btnVerifica.Font = myfont
        'btnVerifica.Location = New Point(2, 269)

        btnConfirma.Size = New System.Drawing.Size(143, 57)
        btnConfirma.Font = myfont

        PanelGrupos.Location = New Point(567, 61)
        PanelGrupos.Size = New System.Drawing.Size(450, 434)
    End Sub

    Public Sub VerificaMesaGrid()

        Dim IDMovto As Integer
        Dim IDCombo As Integer
        Dim ID As Integer = 0
        Dim Totpro As Decimal
        Dim TotproServ As Decimal
        Dim ComServico As Boolean

        TravaVenda()

        Dim con As New SqlConnection()
        SqlStr = "Select tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo, tblVendas.NumMesa, tblVendas.FlagFechada, tblVendasMovto.IDProduto, tblVendasMovto.Produto, tblVendasMovto.Qtd, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasMovto.Categoria, tblVendasMovto.Excluido, tblVendasMovto.Enviado, tblVendasMovto.IDFuncionario, tblVendasMovto.Atendente, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.HoraPedido, tblProdutos_Local.IDProduto As Expr1, tblProdutos_Local.CodigoProduto, tblVendasCombo.Produto As ProdutoCombo, tblVendasCombo.IDGrupo As IDGrupoCombo, tblVendasCombo.Grupo AS GrupoCombo, tblVendasCombo.IDProduto AS IDProdutoCombo, tblVendasMovto.ComServico "
        SqlStr += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto "
        SqlStr += "Where (tblVendas.FlagFechada = 0) And (tblVendas.IDVenda=" & IDVenda & ") "
        SqlStr += "Order By tblVendas.IDVenda, tblVendasMovto.IDVendaMovto, tblVendasCombo.IDVendaCombo"

        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If IsDBNull(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo")) Then
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1

                Totpro = NuloDecimal(SemArredondar(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), 3))
                TotproServ = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                ComServico = NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico"))

                Dim nova_linha As DataRow = DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(Totpro), Format(NuloDecimal(Totpro), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), ID, 1, NuloDecimal(TotproServ), ComServico}

                DataSetGrid.Tables(0).Rows.Add(nova_linha)

                ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                InsereComent("M", NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), 0, ID, 0)
            Else
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Totpro = NuloDecimal(SemArredondar(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), 3))
                TotproServ = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                ComServico = NuloBoolean(ds.Tables("Vendas").Rows(i).Item("ComServico"))

                ID += 1
                Dim nova_linha As DataRow = DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(Totpro), Format(NuloDecimal(Totpro), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), ID, 1, NuloDecimal(TotproServ), ComServico}

                DataSetGrid.Tables(0).Rows.Add(nova_linha)

                IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                While IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto"))
                    Dim nova_linha_PCM1 As DataRow = DataSetGrid.Tables(0).NewRow()
                    nova_linha_PCM1.ItemArray = New Object() {ID, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")), String.Empty, ID, "PC", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), 0, 0, String.Empty, 0, String.Empty, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupoCombo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("GrupoCombo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProdutoCombo")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")), ID, 1, 0, ComServico}
                    DataSetGrid.Tables(0).Rows.Add(nova_linha_PCM1)

                    IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                    While IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo"))
                        ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        InsereComent("MC", 0, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDVendaCombo")), ID, 0)

                        If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaCombo")) Then
                            i += 1
                        Else
                            Exit While
                        End If

                    End While
                    If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                    If IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto")) Then
                        i += 1
                    Else
                        Exit While
                    End If
                End While
                InsereComent("M", NuloInteger(IDMovto), 0, ID, 0)
            End If
        Next

        Grid.Refresh()
        LinhaGrid()
        AtualizaGrid()
        StiloGrid()

        If DataSetGrid.Tables(0).Rows.Count <> 0 Then
            Grid.Rows(0).Selected = False
        End If

        CalculaTotais()

        con.Close()
        con.Dispose()
    End Sub
    Private Sub InsereComent(Status As String, IDMovto As Integer, IDcombo As Integer, IDgrid As Integer, IDFam As Integer)

        Dim conC As New SqlConnection()
        Dim Texto As String
        strSql = "Select  IDVendaMovto, IDVendaCombo, Coment "
        strSql += "From tblVendasComent "
        If IDMovto > 0 Then
            strSql += "Where (IDVendaMovto = " & IDMovto & ")"
            Texto = ">>>>"
        Else
            strSql += "Where (IDVendaCombo = " & IDcombo & ")"
            Texto = "----->"
        End If

        Dim drC As SqlDataReader
        conC.ConnectionString = strCon
        Dim cmdC As SqlCommand = conC.CreateCommand
        cmdC.CommandText = strSql

        conC.Open()
        drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drC.HasRows Then
            Do While drC.Read()
                Dim nova_linhaComent As DataRow = DataSetGrid.Tables(0).NewRow()
                nova_linhaComent.ItemArray = New Object() {IDgrid, Texto, drC.Item("Coment"), String.Empty, IDgrid, Status, 0, 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0, IDFam, 0, 0, "", 0, 0, IDMovto}
                DataSetGrid.Tables(0).Rows.Add(nova_linhaComent)
            Loop
        End If
        drC.Close()
        cmdC.Dispose()
        conC.Dispose()
        conC.Close()

    End Sub
    Function AchaProduto(CodProd As Integer) As Boolean
        Dim CodBarras As String = CodProd.ToString
        Dim con As New SqlConnection()
        Dim Retorno As Boolean = False

        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.Pesavel, tblProdutos_Local.Tara, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.DescricaoResumida, tblProdutos_Local.CodigoFabricante, tblProdutos_Local.Tipo, tblProdutos_Local.CodigoNCM, tblProdutos_Local.Pizza, tblProdutos_Local.CodigoCEST, tblProdutos_Local.pPIS, tblProdutos_Local.pCOFINS, tblProdutos_Local.CST_COFINS, tblProdutos_Local.CST_ICMS, tblProdutos_Local.CST_PIS, tblProdutos_Local.CFOP, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblProdutos_Local.Pesavel, tblProdutos_Local.[Top], tblProdutos_Local.Modulos, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.BaixaEstoque, tblProdutos_Local.Aliquota,  tblGrupos_Local.Grupo, tblProdutos_Local.InformaVenda, tblGrupos_Local.EPizza "
        strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        strSql += "Where (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%" & Modulo & "%') AND (CodigoProduto = " & CodProd & ")"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                dr.Read()
                tbCodigoProduto.Text = NuloString(dr.Item("CodigoProduto"))
                IDProdutoSel = NuloInteger(dr.Item("IDProduto"))
                LBProduto.Text = NuloString(dr.Item("Produto"))
                ProdutoSel = NuloString(dr.Item("Produto"))
                VlrUnitario = NuloDecimal(dr.Item("Venda"))
                CodigoGrupo = NuloInteger(dr.Item("CodigoGrupo"))
                IDFamilia = NuloInteger(dr.Item("IDFamilia"))
                IDFamiliaSel = NuloInteger(dr.Item("IDFamilia"))
                IDFami = NuloInteger(dr.Item("IDFamilia"))
                Grupo = NuloString(dr.Item("Grupo"))
                Categoria = Trim(NuloString(dr.Item("Categoria")))
                EGrupoPizza = NuloBoolean(dr.Item("EPizza"))

                Retorno = True
                tbQtde.Focus()
                If NuloBoolean(dr.Item("InformaVenda")) = True Then
                    fdlgValorVenda.ShowDialog()
                    If TerminalVenda = True Then
                        SendKeys.Send("{ENTER}")
                    End If
                Else

                    If NuloBoolean(dr.Item("Pesavel")) = True And PortaBalanca <> "" Then
                        PesoPego = 0
                        Dim frmPeso As fdlgPegaPeso = New fdlgPegaPeso
                        frmPeso.tbTara.Text = Format(NuloDecimal(dr.Item("Tara")), "#0.000")
                        frmPeso.tbVenda.Text = Format(VlrUnitario, "#0.00")
                        frmPeso.lbProduto.Text = ProdutoSel
                        frmPeso.ShowDialog()
                        If PesoPego = 0 Then
                            tbCodigoProduto.Focus()
                            'Exit Sub
                        End If
                    End If

                End If
            Else
                If CodProd <> 0 Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Produto inválido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                End If
                tbCodigoProduto.Text = ""
                tbQtde.Text = "1,000"
                LBProduto.Text = ""
                IDProdutoSel = 0
                Retorno = False
            End If

            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()

            Return Retorno

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Public Sub VerificaMesa(NMesa As String)

        If tbMesa.Text = "" Then Exit Sub

        Dim con As New SqlConnection()

        strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa= " & NMesa & ")"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        Try
            PedidoVenda = True
            NumMesa = NuloInteger(NMesa)
            IDVenda = 0
            QtdPessoas = 1
            PercDesconto = 0
            PercServico = PercServicoPAR
            GarconInicial = ""
            MesaImpressa = False
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                Dim conM As New SqlConnection()
                Dim drM As SqlDataReader
                strSql = "Select IDVenda, IDfechamento, NumVenda, NumMesa, Cartao, FlagFechada, Excluido, QtdPessoas, PercServico, PercDesconto, Atendente, NomeCliente, Obs From tblVendas Where (Excluido=0) And (FlagFechada=0) And (NumMesa=" & NMesa & ")"
                conM.ConnectionString = strCon
                Dim cmdM As SqlCommand = conM.CreateCommand
                cmdM.CommandText = strSql
                conM.Open()
                drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If drM.HasRows Then
                    drM.Read()
                    IDVenda = NuloInteger(drM.Item("IDVenda"))
                    QtdPessoas = NuloInteger(drM.Item("QtdPessoas"))
                    PercServico = NuloDecimal(drM.Item("PercServico"))
                    PercDesconto = NuloDecimal(drM.Item("PercDesconto"))
                    GarconInicial = NuloString(drM.Item("Atendente"))
                    lbNomeCliente.Text = NuloString(drM.Item("NomeCliente")) & " / " & NuloString(drM.Item("Obs"))
                    tbCodigoProduto.Text = ""
                    tbQtde.Text = "1,000"
                    LBProduto.Text = ""

                    MesaImpressa = NuloBoolean(dr.Item("Impresso"))

                    If NuloBoolean(dr.Item("Flag")) = False Then

                        fdlgAbreMesa.ShowDialog()

                    Else
                        tbCodigoProduto.Focus()
                    End If

                Else

                    fdlgAbreMesa.ShowDialog()

                    If IDVenda <> 0 Then tbCodigoProduto.Focus()
                End If
                drM.Close()
                cmdM.Dispose()
                conM.Dispose()
                conM.Close()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = TextoMesaPAR & " " & NMesa & " não foi cadastrada"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                lbNomeCliente.Text = ""
                tbMesa.Text = ""
                tbCodigoProduto.Text = ""
                tbQtde.Text = "1,000"
                LBProduto.Text = ""
                QtdPessoas = 1
                MesaImpressa = False
                NumMesa = 0
            End If
            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()

            If PedidoVenda = True And PedeMesa = True And MesaCartao = "" Then

                fdlgPedeMesa.ShowDialog()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub MontaBotoesMesas()

        Dim MesCta As Integer = 0
        Dim MesAbe As Integer = 0
        Dim MesSem As Integer = 0
        Dim MesTot As Integer = 0
        Dim n As Integer = 0
        Dim xPosPic As Integer = 4
        Dim yPosPic As Integer = 6
        Dim TrvMesa As Boolean
        Dim strSql As String
        Dim TextoTag As String

        LBConsumindo.Text = "0"
        LBSemConsumo.Text = "0"
        LBPagando.Text = "0"
        LBTotalMesas.Text = "0"

        If TerminalVenda = False Then
            strSql = "Select tblMesas.NumMesa, tblMesas.Status, tblMesas.Flag, tblMesas.Impresso, tblMesas.Praca, tblMesas.UltimoPedido, tblMesas.Aberturas, tblVendas.HoraAbertura, tblVendas.Atendente, tblVendas.Excluido, tblVendas.FlagFechada "
            strSql += "From tblMesas INNER Join tblVendas On tblMesas.NumMesa = tblVendas.NumMesa "
            strSql += "Where (tblMesas.Flag = 1) And (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 0) "
            strSql += "Order By tblMesas.NumMesa"
        Else
            If NuloString(tbPraca.Text) = "" Then
                strSql = "Select tblMesas.NumMesa, tblMesas.Status, tblMesas.Flag, tblMesas.Impresso, tblMesas.Praca, tblMesas.UltimoPedido, tblMesas.Aberturas, tblVendas.HoraAbertura, tblVendas.Atendente, tblVendas.Excluido, tblVendas.FlagFechada "
                strSql += "From tblMesas INNER Join tblVendas On tblMesas.NumMesa = tblVendas.NumMesa "
                strSql += "Where (tblMesas.Flag = 1) And (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 0) "
                strSql += "Order By tblMesas.NumMesa"
            Else
                strSql = "Select tblMesas.NumMesa, tblMesas.Status, tblMesas.Flag, tblMesas.Impresso, tblMesas.Praca, tblMesas.UltimoPedido, tblMesas.Aberturas, tblVendas.HoraAbertura, tblVendas.Atendente, tblVendas.Excluido, tblVendas.FlagFechada, tblMesas.Praca "
                strSql += "From tblMesas INNER Join tblVendas On tblMesas.NumMesa = tblVendas.NumMesa "
                strSql += "Where (tblMesas.Flag = 1) And (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 0) And (tblMesas.Praca=" & tbPraca.Text & ") "
                strSql += "Order By tblMesas.NumMesa"
            End If
        End If

        Dim con_bt As New SqlConnection()
        Dim dr_bt As SqlDataReader

        con_bt.ConnectionString = strCon
        Dim cmd_bt As SqlCommand = con_bt.CreateCommand
        cmd_bt.CommandText = strSql

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        PanelMesas.Controls.Clear()

        con.Open()

        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read())

                If NuloBoolean(dr.Item("Impresso")) = True Then
                    MesCta += 1
                Else
                    If NuloString(dr.Item("UltimoPedido")) <> "" Then
                        If DateDiff(DateInterval.Minute, CType(dr.Item("UltimoPedido"), DateTime), Now) < TempoLimitePedidosMesa Then
                            MesAbe += 1
                        Else
                            MesSem += 1
                        End If
                    Else
                        MesAbe += 1
                    End If

                End If
                MesTot += 1
            End While
        End If

        LBTotalMesas.Text = NuloString(MesTot)
        LBPagando.Text = NuloString(MesCta)
        LBConsumindo.Text = NuloString(MesAbe)
        LBSemConsumo.Text = NuloString(MesSem)

        Dim myfont As New Font("Sans Serif", 14, FontStyle.Bold)
        Dim btnArray(MesTot) As System.Windows.Forms.Label
        For i As Integer = 0 To MesTot
            btnArray(i) = New System.Windows.Forms.Label
        Next i

        con_bt.Open()
        dr_bt = cmd_bt.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If DefinicaoReduzida = True Then
            IncrementoMesas = 17
        Else
            IncrementoMesas = 20
        End If
        Dim BotMin As Integer = NuloInteger(tbPaginaMesas.Text)
        If BotMin < 0 Then
            tbPaginaMesas.Text = 1.ToString
            BotMin = 1
        End If
        Dim HoraPedEspera As String
        Dim BotMax As Integer = BotMin + IncrementoMesas
        nnMesas = 0
        If dr_bt.HasRows Then

            While (dr_bt.Read())

                TextoTag = NuloString(dr_bt.Item("Atendente")) & " / " & Format(dr_bt.Item("HoraAbertura"), "hh:MM")

                With (btnArray(n))

                    ToolTip1.SetToolTip(btnArray(n), NuloString(TextoTag))

                    If n >= BotMin - 1 And n <= BotMax - 1 Then
                        .Tag = NuloInteger(dr_bt.Item("Impresso"))
                        If DefinicaoReduzida = False Then
                            .Width = 57
                            .Height = 55
                        Else
                            .Width = 53
                            .Height = 55
                        End If

                        .BackgroundImageLayout = ImageLayout.None
                        .Text = NuloString(dr_bt.Item("NumMesa"))
                        .TextAlign = ContentAlignment.BottomCenter
                        .ForeColor = Color.Black
                        .AutoSize = False
                        .Margin = New Padding(2, 2, 2, 2)

                        frmPagamento.carregaVisualComponente(btnArray(n), 5, 5)
                        .FlatStyle = FlatStyle.Standard
                        .Margin = New Padding(2, 3, 2, 3)

                        TrvMesa = NuloBoolean(dr_bt.Item("Impresso"))

                        If NuloBoolean(dr_bt.Item("Impresso")) = True Then
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.Mesa_VerdeOK
                            .ForeColor = Color.White
                        Else
                            If NuloString(dr_bt.Item("UltimoPedido")) <> "" Then
                                .BackColor = Color.LightGray

                                SqlStr = "Select tblVendas.Atendente, tblVendas.Excluido, tblVendas.FlagFechada, tblVendasMovto.EmEspera, tblVendas.IDVenda, tblVendasMovto.HoraPedido "
                                SqlStr += "From tblVendas LEFT OUTER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
                                SqlStr += "WHERE (tblVendas.Excluido = 0) AND (tblVendas.FlagFechada = 0) AND (tblVendasMovto.EmEspera = 1) AND (tblVendas.NumMesa = " & NuloString(dr_bt.Item("NumMesa")) & ")"
                                HoraPedEspera = NuloString(PegaValorCampo("HoraPedido", SqlStr, strCon))
                                'If HoraPedEspera <> "" Then
                                'If DateDiff(DateInterval.Minute, CType(Now.ToString("dd/MM/yyyy") & " " & HoraPedEspera, DateTime), Now) < TempoLimitePedidosMesaEmEspera Then
                                '.BackgroundImage = GourmetVisual.My.Resources.Resources.mesa_marrom
                                'Else
                                '.BackgroundImage = GourmetVisual.My.Resources.Resources.mesa_marrom
                                'End If
                                'Else
                                If DateDiff(DateInterval.Minute, CType(dr_bt.Item("UltimoPedido"), DateTime), Now) < TempoLimitePedidosMesa Then
                                    .BackgroundImage = GourmetVisual.My.Resources.Resources.Mesa_Azul
                                Else
                                    .BackgroundImage = GourmetVisual.My.Resources.Resources.Mesa_Vermelha
                                End If
                                'End If
                            Else
                                .BackgroundImage = GourmetVisual.My.Resources.Resources.Mesa_VerdeOK
                                .ForeColor = Color.White
                            End If

                        End If

                                    .ImageAlign = ContentAlignment.TopCenter
                        .Left = xPosPic
                        .Top = yPosPic
                        .TabStop = False
                        .Enabled = True
                        .Name = "picMesa" & n

                        Me.PanelMesas.Controls.Add(btnArray(n))

                        nnMesas += 1

                        AddHandler .Click, AddressOf Me.ClickButton
                    End If
                    n += 1
                End With
            End While
        End If

        con.Close()
        con.Dispose()
        con_bt.Close()
        con_bt.Dispose()

    End Sub
    Private Sub ClickButton(ByVal sender As Object, ByVal e As System.EventArgs)

        TempoTela = TempoLimite
        If PedidoVenda = True Then
            If Grid.Rows.Count <> 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = True Then
                    PedidoVenda = True
                Else
                    tbCodigoProduto.Focus()
                    Exit Sub
                End If
            End If

            DataSetGrid.Clear()
            LinhaGrid()
            CalculaTotais()
            AtualizaGrid()
        End If


        With CType(sender, Label)
            If PedidoVenda = False Then
                PedidoVenda = True
                DataSetGrid.Clear()
                LinhaGrid()
                TravaVenda()
                CalculaTotais()
                AtualizaGrid()
            End If
            tbMesa.Text = .Text
            tbMesa.Refresh()
            VerificaMesa(.Text)
        End With

    End Sub
    Public Sub IniciaFrm()

        Timer.Start()
        lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)
        lbDataMovimento.Text = DiaMovto
        lbOparedor.Text = Operador
        lbCaixa.Text = Caixa
        lbTerminal.Text = NomeTerminal


        Grid.BackgroundColor = Color.White

        Dim newRectangle As Rectangle = btnPagina_1.ClientRectangle

        newRectangle.Inflate(-4, -4)

        Dim p As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)

        With btnPagina_1
            .Text = "1"
            .BackColor = Color.Lavender
        End With

        With btnPagina_2
            .Text = "2"
            .BackColor = Color.White
        End With

        With btnPagina_3
            .Text = "3"
            .BackColor = Color.White
        End With

        With btnPagina_4
            .Text = "4"
            .BackColor = Color.White
        End With

        p.Dispose()

        If TerminalVenda = False Then
            If InStr(ModulosIRIS, "S") > 0 Then
                btnSalao.Visible = True
                btnSalao.Margin = New Padding(0)
            End If
            If InStr(ModulosIRIS, "B") > 0 Then
                btnBalcao.Visible = True
                btnBalcao.Margin = New Padding(0)
            End If
            If InStr(ModulosIRIS, "D") > 0 Then
                btnDelivery.Visible = True
                btnDelivery.Margin = New Padding(0)
            End If
        End If

        MontaGruposSalao(1)

        If Modulo = "S" Then
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "ACESSOU", "SALÃO")
            End If

            btnTransferencia.Text = "Transferência F5"
            btnTransferencia.Image = GourmetVisual.My.Resources.Resources.Refresh

            lbModulo.Text = "Salão"
            btnSalao.Visible = False

            PanelMesas.Visible = True
            btnSize.Visible = True
            tbMesa.Enabled = True
            lbMesa.Text = TextoMesaPAR

            btnTransferencia.Enabled = True
            btnConta.Enabled = True
            btnMensagens.Enabled = True
            LBConsumindo.Visible = True
            LBSemConsumo.Visible = True
            LBPagando.Visible = True
            LBTotalMesas.Visible = True
            btnMaisMesas.Visible = True
            btnMenosMesas.Visible = True

            MontaBotoesMesas()

            If TerminalVenda = False Then
                VerificaMesaGrid()
                AtualizaGrid()
            End If

            If DefinicaoReduzida = False Then
                PanelProdutos.Size = New System.Drawing.Size(1267 - 40, 173)
            Else
                PanelProdutos.Size = New System.Drawing.Size(1010 - 40, 173)
            End If

            If InformaClienteBalcao = True Then
                btnPorCliente.Visible = True
            Else
                btnPorCliente.Visible = False
            End If

            lbNomeCliente.Visible = True

            tbMesa.Focus()
        Else
            If Modulo = "B" Then
                If RegistraLog = True Then
                    IncluirLog(NomeTerminal, Operador, "ACESSOU", "BALCÃO")
                End If
                btnTransferencia.Text = "Desconto F5"
                btnTransferencia.Image = GourmetVisual.My.Resources.Resources.Minus

                lbModulo.Text = "Balcão"
                btnBalcao.Visible = False
                PanelMesas.Visible = False

                If DefinicaoReduzida = False Then
                    PanelProdutos.Size = New System.Drawing.Size(1267 - 40, 242)
                Else
                    PanelProdutos.Size = New System.Drawing.Size(1010 - 40, 242)
                End If

                tbMesa.Enabled = False
                lbMesa.Text = "Venda"
                btnSize.Visible = False
                btnConta.Enabled = False
                LBConsumindo.Visible = False
                LBSemConsumo.Visible = False
                LBPagando.Visible = False
                LBTotalMesas.Visible = False
                btnMaisMesas.Visible = False
                btnMenosMesas.Visible = False
                btnPorCliente.Visible = False
                btnMensagens.Enabled = False
                lbNomeCliente.Visible = False
                tbCodigoProduto.Focus()
            Else
                lbModulo.Text = "Delivery"
            End If
        End If
        MontaProdutos(0)

        If TerminalVenda = False And IDVenda = 0 Then
            LimpaVenda()
        End If


    End Sub
    Private Sub frmGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnDelivery.BackColor = Color.White

        strSql = "SELECT IDFuncionario, Praca FROM tblPracas WHERE (IDFuncionario = " & IDOperador & ")"
        tbPraca.Text = NuloString(PegaValorCampo("Praca", strSql, strCon))

        lbMesa.Text = TextoMesaPAR
        If UCase(TextoMesaPAR) <> "MESA" And PedeMesa = True Then
            Button3.Visible = True
        Else
            Button3.Visible = False
        End If

        If GavetaCaixa = True Then
            btnGaveta.Visible = True
        Else
            btnGaveta.Visible = False
        End If

        QtdeVendas = 1
        For iii = 0 To 49
            IDsVendas(iii) = 0
        Next iii

        If TerminalVenda = True Then
            Modulo = "S"
            btnMinimizar.Visible = False
            TimerTela.Enabled = True
            lbTempo.Visible = True
        Else
            lbTempo.Visible = False
        End If


        If Modulo = "B" Then
            VerificaVendaBalcao()
            PedidoVenda = True
            If IDVenda = 0 Then
                PedidoVenda = True
            Else
                PedidoVenda = False
                VerificaMesaGrid()
            End If
            'VerificaMesaGrid()
            AtualizaGrid()
            tbCodigoProduto.Focus()
        End If


        If Screen.PrimaryScreen.Bounds.Width < 1280 Then
            DefinicaoReduzida = True
            ReduzDefinicao()
        Else
            DefinicaoReduzida = False
        End If

        If Modulo <> "B" Then PedidoVenda = True

        frmPagamento.carregaVisualComponente(btnComent, 10, 10)
        frmPagamento.carregaVisualComponente(btnQtde, 10, 10)
        frmPagamento.carregaVisualComponente(btnMensagens, 10, 10)
        frmPagamento.carregaVisualComponente(btnLimpaProduto, 10, 10)
        frmPagamento.carregaVisualComponente(btnConta, 10, 10)
        frmPagamento.carregaVisualComponente(btnTransferencia, 10, 10)
        frmPagamento.carregaVisualComponente(btnPagamento, 10, 10)
        frmPagamento.carregaVisualComponente(btnVerifica, 10, 10)
        frmPagamento.carregaVisualComponente(btnConfirma, 10, 10)
        frmPagamento.carregaVisualComponente(btnPagina_1, 10, 10)
        frmPagamento.carregaVisualComponente(btnPagina_2, 10, 10)
        frmPagamento.carregaVisualComponente(btnPagina_3, 10, 10)
        frmPagamento.carregaVisualComponente(btnPagina_4, 10, 10)
        frmPagamento.carregaVisualComponente(btnDelivery, 10, 10)
        frmPagamento.carregaVisualComponente(btnBalcao, 10, 10)
        frmPagamento.carregaVisualComponente(btnSalao, 10, 10)
        frmPagamento.carregaVisualComponente(btnVoltar, 10, 10)

        tbPaginaMesas.Text = 1.ToString

        IniciaFrm()


    End Sub

    Private Sub EnviaPedido()

        Dim IDPedidoGrid As Integer
        Dim ii As Integer
        Dim St As String
        Dim Qtde As String
        Dim QtdeUnit As Double
        Dim VlrUnit As String
        Dim VlrUnitServ As String
        Dim con As New SqlConnection(strCon)
        Dim dv As New DataView(DataSetGrid.Tables(0))
        Dim IDSetor As Integer
        Dim ComServico As Boolean
        Dim IDsMovto(100) As Integer
        Dim iID As Integer = 0
        Dim IDPro As Integer
        For Each iID In IDsMovto
            iID = 0
        Next iID
        iID = 0
        dv.Sort = "ID DESC"


        'Try

        con.Open()

        For i = 0 To dv.Count - 1

            If NuloBoolean(dv.Item(i)("Confirmado")) = False Then

                dv.Item(i)("Confirmado") = True

                IDPedidoGrid = NuloInteger(dv.Item(i)("IDPedido"))

                QtdeUnit = CDbl((dv.Item(i)("Qtde")))
                Qtde = NuloString(dv.Item(i)("Qtde"))
                Qtde = Replace(Qtde, ",", ".")

                VlrUnit = NuloString(dv.Item(i)("VlrUnit"))
                ' VlrUnit = Replace(VlrUnit, ",", ".")

                strSql = "SELECT IDProduto, ComServico, CodigoProduto FROM tblProdutos_Local WHERE CodigoProduto=" & NuloInteger(dv.Item(i)("CodigoProduto"))
                If NuloBoolean(PegaValorCampo("ComServico", strSql, strCon)) = True And TerminalNaoCobraServico = False Then
                    VlrUnitServ = NuloString(NuloDouble(dv.Item(i)("VlrUnit")) * ((PercServico / 100) + 1))
                    ComServico = True
                Else
                    VlrUnitServ = NuloString(NuloDouble(dv.Item(i)("VlrUnit")))
                    ComServico = False
                End If
                IDPro = NuloInteger(PegaValorCampo("IDProduto", strSql, strCon))

                'VlrUnitServ = NuloString(NuloDouble(dv.Item(i)("VlrUnit")) * ((PercServico / 100) + 1))
                'VlrUnitServ = NuloString(dv.Item(i)("VlrUnitServico"))

                Categoria = NuloString(NuloString(dv.Item(i)("Categoria")))

                IDSetor = 0
                If Modulo = "S" Then
                    If TerminalVenda = False Then
                        strSql = "Select NumMesa, IDSetor From tblMesas WHERE NumMesa=" & tbMesa.Text
                    Else
                        If MesaCartao = "" Then
                            strSql = "Select NumMesa, IDSetor From tblMesas WHERE NumMesa=" & tbMesa.Text
                        Else
                            strSql = "Select NumMesa, IDSetor From tblMesas WHERE NumMesa=" & MesaCartao
                        End If
                    End If
                    IDSetor = NuloInteger(PegaValorCampo("IDSetor", strSql, strCon))
                End If
                If Modulo = "B" Then
                    IDSetor = SetorBalcao
                End If
                If Modulo = "D" Then
                    IDSetor = SetorDelivery
                End If


                'InserirItemVenda(IDVenda, NuloInteger(dv.Item(i)("IDProduto")), NuloString(dv.Item(i)("Produto")), NuloDecimal(QtdeUnit), NuloBoolean(True), NuloDecimal(VlrUnit), NuloDecimal(VlrUnitServ), Categoria, Date.Now, IDOperador, Operador, NuloInteger(dv.Item(i)("IDGrupo")), NuloString(dv.Item(i)("Grupo")), NuloBoolean(0), "", NuloBoolean(0), "", lbTerminal.Text, Imprime, IDSetor, ComServico)
                InserirItemVenda(IDVenda, IDPro, NuloString(dv.Item(i)("Produto")), NuloDecimal(QtdeUnit), NuloBoolean(True), NuloDecimal(VlrUnit), NuloDecimal(VlrUnitServ), Categoria, Date.Now, IDOperador, Operador, NuloInteger(dv.Item(i)("IDGrupo")), NuloString(dv.Item(i)("Grupo")), NuloBoolean(0), "", NuloBoolean(0), "", lbTerminal.Text, Imprime, IDSetor, ComServico, True)
                AchaIDMovto()
                IDsMovto(iID) = IDMovtoGV
                iID += 1

                Dim Agrega As Boolean
                strSql = "SELECT IDProduto, AgregaValor "
                strSql += "From tblCombos_Local "
                strSql += "Where (IDProduto =" & NuloInteger(dv.Item(i)("IDProduto")) & ")"
                Agrega = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))

                For ii = (i + 1) To dv.Count - 1
                    If IDPedidoGrid = NuloInteger(dv.Item(ii)("IDPedido")) Then

                        St = Strings.Right(NuloString(dv.Item(ii)("Status")), Len(dv.Item(ii)("Status")) - InStr(1, NuloString(dv.Item(ii)("Status")), NuloString(dv.Item(ii)("ID"))))

                        If St = "M" Then
                            IncluiComentario(IDMovtoGV, 0, NuloString(dv.Item(ii)("Produto")), 0)
                        End If

                        If St = "PC" Then
                            If NuloInteger(dv.Item(ii)("CodigoProduto")) <> 0 Then
                                'Qtde = NuloString(CDbl(dv.Item(ii)("Qtde")) * QtdeUnit)
                                Qtde = NuloString(CDbl(dv.Item(ii)("Qtde")))
                                Qtde = Replace(Qtde, ",", ".")

                                VlrUnit = NuloString(dv.Item(ii)("VlrUnit"))
                                VlrUnit = Replace(VlrUnit, ",", ".")

                                VlrUnitServ = NuloString(NuloDouble(dv.Item(ii)("VlrUnit")) * ((PercServico / 100) + 1))
                                VlrUnitServ = Replace(VlrUnitServ, ",", ".")

                                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.Categoria "
                                strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
                                strSql += "Where (tblProdutos_Local.IDProduto =" & NuloInteger(dv.Item(ii)("CodigoProduto")) & ")"

                                IDGrupo = NuloInteger(PegaValorCampo("CodigoGrupo", strSql, strCon))
                                Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))
                                Categoria = NuloString(PegaValorCampo("Categoria", strSql, strCon))


                                strSql = "INSERT tblVendasCombo (IDVendaMovto,IDVenda,IDProduto,Produto,Qtd,Venda,VendaServico,IDGrupo,Grupo,Categoria,Impresso,AgregaValor) VALUES ("
                                strSql &= to_sql(IDMovtoGV) & ","
                                strSql &= to_sql(IDVenda) & ","
                                strSql &= to_sql(NuloInteger(dv.Item(ii)("CodigoProduto"))) & ","
                                strSql &= to_sql(NuloString(dv.Item(ii)("Produto"))) & ","
                                strSql &= to_sql(Qtde) & ","
                                strSql &= to_sql(VlrUnit) & ","
                                strSql &= to_sql(VlrUnitServ) & ","
                                strSql &= to_sql(IDGrupo) & ","
                                strSql &= to_sql(Grupo) & ","
                                strSql &= to_sql(Categoria) & ","
                                strSql &= "0,"
                                strSql &= to_sql(Agrega) & ")"
                                ExecutaStr(strSql)

                                AchaIDCombo()
                            End If
                        End If

                        If St = "MC" Then
                            IncluiComentario(0, IDCombo, NuloString(dv.Item(ii)("Produto")), 0)
                        End If
                        i = ii
                    End If
                Next
            End If
        Next


        If PedeMesa = False Then
            For iii = 0 To 100
                If IDsMovto(iii) = 0 Then Exit For
                strSql = "UPDATE tblVendasMovto Set "
                strSql &= "Enviado=1 "
                strSql &= "WHERE (IDVendaMovto=" & IDsMovto(iii) & ")"
                ExecutaStr(strSql)
            Next iii
        Else
            If TerminalVenda = True Then
                IDsVendas(QtdeVendas - 1) = IDVenda
                QtdeVendas += 1
            End If
        End If

        strSql = "UPDATE tblMesas Set "
        strSql &= "Impresso=0, "
        strSql &= "UltimoPedido='" & Now & "' "
        strSql &= "WHERE (NumMesa=" & tbMesa.Text & ")"
        ExecutaStr(strSql)

        If TableAtivo = True Then InformaStatusTablet(tbMesa.Text)

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        con.Close()
        con.Dispose()
        'End Try

    End Sub

    Private Sub AchaMsgTXT(IDGrid As Integer)

        Dim dv As New DataView(DataSetGrid.Tables(0))
        MsgTXT = String.Empty
        dv.Sort = "Status DESC"

        For i = 0 To dv.Count - 1
            If IDGrid = NuloInteger(dv.Item(i)("IDPedido")) Then
                If NuloString(dv.Item(i)("Status")) = NuloString(dv.Item(i)("IDPedido")) & "M" Then
                    MsgTXT = NuloString(dv.Item(i)("Produto"))
                End If

            End If
        Next
    End Sub

    Private Sub MontaProdutos(IDGr As Integer)

        TempoTela = TempoLimite
        PanelGrupos.Enabled = False
        PanelProdutos.Enabled = False

        Dim n As Integer = 0
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim StrSql As String

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        StrSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.DescricaoResumida, tblProdutos_Local.CodigoFabricante, tblProdutos_Local.Tipo, tblProdutos_Local.CodigoNCM, tblProdutos_Local.Pizza, tblProdutos_Local.CodigoCEST, tblProdutos_Local.pPIS, tblProdutos_Local.pCOFINS, tblProdutos_Local.CST_COFINS, tblProdutos_Local.CST_ICMS, tblProdutos_Local.CST_PIS, tblProdutos_Local.CFOP, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblProdutos_Local.Pesavel, tblProdutos_Local.[Top], tblProdutos_Local.Modulos, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.BaixaEstoque, tblProdutos_Local.Aliquota, tblCategorias_Local.CorBotao "
        StrSql += "From tblProdutos_Local INNER Join tblCategorias_Local On tblProdutos_Local.Categoria = tblCategorias_Local.Categoria "
        StrSql += "WHERE (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%S%' OR tblProdutos_Local.Modulos Like '%B%') And (tblProdutos_Local.ForaLinha=0) "
        If IDGr <> 0 Then
            StrSql += "AND (tblProdutos_Local.CodigoGrupo = " & IDGr & ") "
        Else
            StrSql += "AND (tblProdutos_Local.[Top] = 1) "
        End If
        StrSql += "Order By tblProdutos_Local.Produto"

        cmd.CommandText = StrSql

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            Dim myfont6 As New Font("Sans Serif", 7, FontStyle.Regular)
            Dim myfont7 As New Font("Sans Serif", 7, FontStyle.Bold)
            Dim btnArrayPro(500) As System.Windows.Forms.Button
            For i As Integer = 0 To 500
                btnArrayPro(i) = New System.Windows.Forms.Button
            Next i

            Me.PanelProdutos.Controls.Clear()


            If PanelMesas.Visible = True Then
                Incremento = 32
            Else
                Incremento = 48
            End If

            Dim BotMin As Integer = NuloInteger(tbPagina.Text)
            If BotMin < 0 Then
                tbPagina.Text = 1.ToString
                BotMin = 1
            End If
            Dim BotMax As Integer = BotMin + Incremento
            nn = 0
            If dr.HasRows Then
                While (dr.Read())
                    If NuloString(dr.Item("DescricaoResumida")) <> "" Then
                        With (btnArrayPro(n))
                            If n >= BotMin - 1 And n <= BotMax - 1 Then

                                .Tag = dr.GetInt32(0)
                                .Text = dr.GetString(3)
                                .AccessibleDescription = NuloString(dr(1))
                                ToolTip1.SetToolTip(btnArrayPro(n), NuloString(NuloDecimal(dr.Item("Venda")).ToString("c")))

                                If DefinicaoReduzida = False Then
                                    .Width = 150
                                    .Height = 36
                                    .Font = myfont7
                                Else
                                    .Width = 118
                                    .Height = 36
                                    .Font = myfont6
                                End If

                                .BackColor = Color.White
                                If Not IsDBNull(dr(27)) Then
                                    If dr.GetInt32(27) = 10936569 Then
                                        .BackColor = Color.MistyRose
                                    End If
                                    If dr.GetInt32(27) = 14348473 Then
                                        .BackColor = Color.LightGoldenrodYellow
                                    End If
                                    If dr.GetInt32(27) = 16114612 Then
                                        .BackColor = Color.Azure
                                    End If
                                    If dr.GetInt32(27) = 15849187 Then
                                        .BackColor = Color.Wheat
                                    End If
                                    If dr.GetInt32(27) = 10547179 Then
                                        .BackColor = Color.YellowGreen
                                    End If
                                End If
                                .FlatAppearance.BorderColor = Color.Silver

                                frmPagamento.carregaVisualComponente(btnArrayPro(n), 20, 20)
                                .FlatStyle = FlatStyle.Flat
                                .FlatAppearance.BorderSize = 0
                                .Margin = New Padding(1, 2, 1, 2)

                                Me.PanelProdutos.Controls.Add(btnArrayPro(n))

                                AddHandler .Click, AddressOf Me.ClickButton_Produtos
                                nn += 1
                            End If

                            n += 1
                        End With
                    End If
                End While
            End If

        Catch ex As Exception
            'MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
            PanelProdutos.Enabled = True
            PanelGrupos.Enabled = True
        End Try

    End Sub

    Private Sub ClickButton_Produtos(ByVal sender As Object, ByVal e As System.EventArgs)
        TempoTela = TempoLimite
        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbMesa.Focus()
            Exit Sub
        End If

        Dim IDPro As Integer = NuloInteger(CType(sender, Button).Tag)

        If PedidoVenda = False Then
            PedidoVenda = True
            DataSetGrid.Clear()
            TravaVenda()
            CalculaTotais()
        End If

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim drMon As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblProdutos_Local.Produto, tblProdutos_Local.DescricaoResumida, tblProdutos_Local.CodigoFabricante, tblProdutos_Local.Tipo, tblProdutos_Local.CodigoNCM, tblProdutos_Local.Pizza, tblProdutos_Local.CodigoCEST, tblProdutos_Local.pPIS, tblProdutos_Local.pCOFINS, tblProdutos_Local.CST_COFINS, tblProdutos_Local.CST_ICMS, tblProdutos_Local.CST_PIS, tblProdutos_Local.CFOP, tblProdutos_Local.Categoria, tblProdutos_Local.ImprimeCategoria, tblProdutos_Local.ComServico, tblProdutos_Local.Pesavel, tblProdutos_Local.[Top], tblProdutos_Local.Modulos, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.BaixaEstoque, tblProdutos_Local.Aliquota, tblProdutos_Local.InformaVenda, tblGrupos_Local.EPizza "
        strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        strSql += "Where(tblProdutos_Local.IDProduto = " & IDPro & ") "
        strSql += "Order By tblProdutos_Local.Produto"
        cmd.CommandText = strSql

        Dim cmdMon As SqlCommand = con.CreateCommand
        strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDProduto, tblCombos_Local.IDFamilia, tblGrupos_Local.EPizza, tblCombos_Local.AgregaValor "
        strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        strSql += "Where (tblCombos_Local.IDProduto = " & IDPro & ")"
        cmdMon.CommandText = strSql

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            Dim InfVda As Boolean = NuloBoolean(dr.Item("InformaVenda"))
            Dim Pesavel As Boolean = NuloBoolean(dr.Item("Pesavel"))
            Dim Tara As Decimal = 0

            VlrUnitario = NuloDecimal(dr.Item("Venda"))
            IDGrupo = NuloInteger(dr.Item("CodigoGrupo"))
            IDFami = NuloInteger(dr.Item("IDFamilia"))
            CodProdutoSel = NuloInteger(dr.Item("CodigoProduto"))
            IDProdutoSel = IDPro
            ProdutoSel = NuloString(dr.Item("Produto"))
            Grupo = NuloString(dr.Item("Grupo"))
            Categoria = Trim(NuloString(dr.Item("Categoria")))
            EGrupoPizza = NuloBoolean(dr.Item("EPizza"))

            dr.Close()
            con.Open()

            If InfVda = True Then
                fdlgValorVenda.ShowDialog()
            Else
                If Pesavel = True And PortaBalanca <> "" Then
                    PesoPego = 0
                    Dim frmPeso As fdlgPegaPeso = New fdlgPegaPeso
                    frmPeso.tbTara.Text = Format(Tara, "#0.000")
                    frmPeso.tbVenda.Text = Format(VlrUnitario, "#0.00")
                    frmPeso.lbProduto.Text = ProdutoSel
                    frmPeso.ShowDialog()
                    If PesoPego = 0 Then
                        tbCodigoProduto.Focus()
                        Exit Sub
                    End If
                End If
            End If

            drMon = cmdMon.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If drMon.HasRows Then

                Me.Enabled = False
                drMon.Read()
                AgregaValor = NuloBoolean(drMon.Item("AgregaValor"))
                EGrupoPizza = NuloBoolean(drMon.Item("EPizza"))
                drMon.Close()

                fdlgCombo.ShowDialog()
            Else
                ' Proximo ID do Grid ////////////////////////////////////////////////////////////////////////////////////////////
                Dim IDGrid_ As Integer
                If Me.DataSetGrid.Tables(0).Rows.Count = 0 Then
                    IDGrid_ = 1
                Else
                    For i As Integer = 0 To Me.DataSetGrid.Tables(0).Rows.Count - 1
                        If NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(4)) > IDGrid_ Then
                            IDGrid_ = NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(4))
                        End If
                    Next
                    IDGrid_ += 1
                End If
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                '.AccessibleDescription = NuloString(dr(5))
                Dim Qtde As Decimal
                If PesoPego = 0 Or Pesavel = False Then
                    Qtde = 1
                Else
                    Qtde = PesoPego
                End If

                IncluiProdGrid(IDGrid_, CodProdutoSel, CType(sender, Button).Text, VlrUnitario, IDGrupo, IDFami, 0, 0, "P", Qtde, Grupo, Categoria, IDPro, 0, IDGrid_, False)
            End If
        End If

        If IDPro = 0 Then
            MontaProdutos(0)
        End If

        tbCodigoProduto.Focus()
        ' Grid.Rows(0).Selected = True
        'Grid.Rows(Grid.CurrentRow.Index).Selected = False



        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        'con.Close()
        'con.Dispose()
        'End Try

    End Sub

    Public Sub MontaGruposSalao(Pag As Integer)
        TempoTela = TempoLimite
        PanelGrupos.Enabled = False
        paginaAtual = Pag
        Dim n As Integer = 0

        If BotaoPress = 0 Then PanelProdutos.Controls.Clear()

        Dim strSql As String

        strSql = "Select tblGruposTouch.Botao, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGrupos_Local.CorBotao, tblGrupos_Local.DescricaoResumida "
        strSql += "From tblGrupos_Local RIGHT OUTER Join tblGruposTouch On tblGrupos_Local.CodigoGrupo = tblGruposTouch.CodigoGrupo "
        If Pag = 1 Then
            strSql += " WHERE (tblGruposTouch.Botao BETWEEN 1 And 42)"
        ElseIf Pag = 2 Then
            strSql += " WHERE (tblGruposTouch.Botao BETWEEN 43 And 84)"
        ElseIf Pag = 3 Then
            strSql += " WHERE (tblGruposTouch.Botao BETWEEN 85 And 126)"
        Else
            strSql += " WHERE (tblGruposTouch.Botao BETWEEN 127 And 168)"
        End If
        strSql += "Group By tblGruposTouch.Botao, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGrupos_Local.CorBotao, tblGrupos_Local.DescricaoResumida "
        strSql += " ORDER BY tblGruposTouch.Botao"

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim myfont As Font
        If DefinicaoReduzida = False Then
            myfont = New Font("Sans Serif", 9, FontStyle.Regular)
        Else
            myfont = New Font("Tahoma", 7, FontStyle.Regular)
        End If

        Dim btnArray(42) As System.Windows.Forms.Button
        For i As Integer = 0 To 42
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        Me.PanelGrupos.Controls.Clear()

        If dr.HasRows Then
            While (dr.Read())
                With (btnArray(n))
                    .TabIndex = dr.GetInt32(0)
                    .Tag = NuloInteger(dr(1))

                    .Text = NuloString(dr.Item("DescricaoResumida"))

                    If DefinicaoReduzida = False Then
                        .Width = 90
                        .Height = 65
                    Else
                        .Width = 63
                        .Height = 61
                        .Margin = New Padding(0, 5, 0, 5)
                    End If

                    .TabStop = False
                    .BackColor = Color.White
                    If Not IsDBNull(dr(3)) And .TabIndex <> BotaoPress Then
                        .ForeColor = Color.Black
                        If dr.GetInt32(3) = 9556525 Then
                            .BackColor = Color.GreenYellow
                        End If
                        If dr.GetInt32(3) = 14986523 Then
                            .BackColor = Color.CornflowerBlue
                        End If
                        If dr.GetInt32(3) = 14986183 Then
                            .BackColor = Color.MediumPurple
                        End If
                        If dr.GetInt32(3) = 1092847 Then
                            .BackColor = Color.Orange
                        End If
                        If dr.GetInt32(3) = 14340022 Then
                            .BackColor = Color.Thistle
                        End If
                    Else
                        .BackColor = Color.White
                        .ForeColor = Color.Red
                    End If

                    frmPagamento.carregaVisualComponente(btnArray(n), 20, 20)
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0
                    .Font = myfont
                    .FlatAppearance.BorderColor = Color.Silver
                    Me.PanelGrupos.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Grupos

                    n += 1

                    If n > 42 Then Exit While

                End With
            End While
        End If

        con.Close()
        con.Dispose()
        PanelGrupos.Enabled = True
        MontaProdutos(0)
    End Sub

    Private Sub ClickButton_Grupos(ByVal sender As Object, ByVal e As System.EventArgs)
        TempoTela = TempoLimite
        If IDVenda = 0 And Modulo = "S" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbMesa.Focus()
            Exit Sub
        End If

        If NuloString(tbMesa.Text) = "" And Modulo = "S" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbMesa.Focus()
            Exit Sub
        End If

        If Modulo = "B" Then
            If VerificaVendaBalcao() = 0 And IDVenda = 0 Then
                AbreVendaBalcao()
                IDVenda = PegaID("IDVenda", "tblVendas", "L")
                tbMesa.Text = NumMesa.ToString
                SendKeys.Send("+{End}")
            End If
        End If

        If Modulo = "S" And MesaImpressa = True Then
            If TerminalVenda = False Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Conta já enviada. É necessário reabrir a Mesa/Cartão (" & tbMesa.Text & ") para continuar. Deseja continuar"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                tbMesa.Focus()
                If RetornoMsg = True Then
                    strSql = "UPDATE tblMesas Set "
                    strSql += "Impresso=0 "
                    strSql += "WHERE (NumMesa = " & tbMesa.Text & ")"
                    ExecutaStr(strSql)
                    MontaBotoesMesas()
                Else
                    Exit Sub
                End If
            Else
                If BloqueaMesaAposConta = True Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Conta já enviada. É necessário reabrir a Mesa/Cartão (" & tbMesa.Text & ") para continuar"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbMesa.Focus()
                    Exit Sub
                Else
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Conta (" & tbMesa.Text & ") já enviada. Deseja continuar"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                    frm.ShowDialog()
                    tbMesa.Focus()
                    If RetornoMsg = False Then Exit Sub
                End If
            End If
        End If


        With CType(sender, Button)
            If PedidoVenda = False Then
                LinhaGrid()
                PedidoVenda = True
                DataSetGrid.Clear()
                TravaVenda()
                CalculaTotais()
            End If
            AtualizaGrid()

            If .Text = String.Empty Then
                Me.PanelProdutos.Controls.Clear()
                BotaoPress = 0
                'MontaProdutos(NuloInteger(.Tag))
            Else
                BotaoPress = NuloInteger(.TabIndex)
                'MontaProdutos(NuloInteger(.Tag))
            End If
            MontaGruposSalao(paginaAtual)
            MontaProdutos(NuloInteger(.Tag))
            tbCondicao.Text = NuloInteger(.Tag).ToString

        End With
        tbPagina.Text = 1.ToString
        nn = 0
        tbCodigoProduto.Focus()


    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        TempoTela = TempoLimite
        TimerTela.Stop()
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        ''If Modulo = "B" Then
        'strSql = "SELECT * FROM tblVendas WHERE StatusVenda='B' AND FlagFechada=0"
        'If NuloInteger(PegaValorCampo("IDVenda", strSql, strCon)) <> 0 Then
        'frm.lbMensagem.Text = "Impossível abandonar com venda em aberto no BALCÃO"
        'frm.btnNao.Visible = False
        'frm.btnSim.Visible = False
        'frm.btnOK.Visible = True
        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        'frm.ShowDialog()
        'Exit Sub
        'End If
        ''End If

        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If

        If PedeMesa = True And TerminalVenda = True Then
            Dim PedidosOK As Boolean = False
            For iii = 0 To 49
                If IDsVendas(iii) <> 0 Then
                    PedidosOK = True
                    Exit For
                End If
            Next iii
            If PedidosOK = True Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "Existem pedidos em abertos e não confirmados" & vbCrLf & "Deseja sair mesmo assim" & vbCrLf & "(esses pedidos serão perdidos)"
                frm1.btnNao.Visible = True
                frm1.btnSim.Visible = True
                frm1.btnOK.Visible = False
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm1.ShowDialog()
                If RetornoMsg = False Then
                    tbCodigoProduto.Focus()
                    Exit Sub
                Else
                    For iii = 0 To 49
                        If IDsVendas(iii) <> 0 Then
                            strSql = "DELETE From tblVendasMovto "
                            strSql &= "WHERE (IDVenda=" & IDsVendas(iii) & ") And (Enviado=0)"
                            ExecutaStr(strSql)
                            IDsVendas(iii) = 0
                        End If
                    Next iii
                End If
            End If
        End If


        tbMesa.Text = String.Empty
        lbOparedor.Text = String.Empty
        MontaGruposSalao(1)

        txtProdutos.Text = "0,00"
        txtDesconto.Text = "0,00"
        txtServico.Text = "0,00"
        txtTotal.Text = "0,00"
        DataSetGrid.Clear()

        frmPrincipal.Enabled = True
        frmPrincipal.lblSenha.Text = String.Empty
        frmPrincipal.btnConfirma.Enabled = False
        frmPrincipal.btnConfig.Visible = False
        frmPrincipal.btnSalao.Visible = False
        frmPrincipal.btnBalcao.Visible = False
        frmPrincipal.btnDelivery.Visible = False
        frmPrincipal.btnSalao_Balcao.Visible = False
        frmPrincipal.lbFuncionario.Text = ""

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub btnLimpaProduto_Click(sender As Object, e As EventArgs) Handles btnLimpaProduto.Click
        TempoTela = TempoLimite
        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If

        If PedidoVenda = True Then
            If Grid.SelectedRows.Count = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar um produto"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesa.Focus()
                Exit Sub
            End If
        End If

        If PedidoVenda = True Then
            If Grid.SelectedRows.Count > 0 Then

                Dim Linha As Integer = -1
                Dim IDMov As Integer = 0
                For i As Integer = 0 To Grid.Rows.Count - 1
                    If Grid.Rows(i).Selected = True Then
                        Linha = i
                        IDMov = NuloInteger(Grid.Item(0, i).Value)
                    End If
                Next

                While Linha >= 0
                    Grid.Rows.RemoveAt(Linha)
                    Linha = -1
                    For i As Integer = 0 To Grid.Rows.Count - 1
                        If IDMov = NuloInteger(Grid.Item(0, i).Value) Then
                            Linha = i
                        End If
                    Next
                End While
            End If
        Else
            If OperadorEstorna = False Then
                IDFuncionarioAutorizado = 0
                FuncionarioAutorizado = ""
                Dim frm1 As fdlgAutorizacao = New fdlgAutorizacao
                frm1.tbTipo.Text = "E"
                frm1.lbTipo.Text = "Autorização para ESTORNO"
                frm1.ShowDialog()
                If Autorizado = False Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Sem permissão para estorno"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbMesa.Focus()
                    Exit Sub
                Else
                    fdlgEstorno.ShowDialog()
                End If
            Else
                IDFuncionarioAutorizado = IDOperador
                FuncionarioAutorizado = NuloString(Operador)


                fdlgEstorno.ShowDialog()

            End If
        End If

        LinhaGrid()
        AtualizaGrid()
        CalculaTotais()

        If Grid.SelectedRows.Count > 0 Then
            For i As Integer = 0 To Grid.Rows.Count - 1
                Grid.Rows(i).Selected = False
            Next
        End If
        BotaoPress = 0
        MontaGruposSalao(paginaAtual)
        tbMesa.Focus()

    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        BotaoConfirma()

    End Sub
    Private Sub BotaoConfirma()
        TempoTela = TempoLimite

        If PedidoVenda = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Impossível executar essa tarefa"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If

        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            If Modulo = "S" Then
                frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            Else
                frm.lbMensagem.Text = "Venda inválida"
            End If
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        Else
            If Modulo = "S" And MesaImpressa = True Then
                If TerminalVenda = False Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Conta já enviada. É necessário reabrir a Mesa/Cartão (" & tbMesa.Text & ") para continuar. Deseja continuar"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                    frm.ShowDialog()
                    tbMesa.Focus()
                    If RetornoMsg = True Then
                        strSql = "UPDATE tblMesas Set "
                        strSql += "Impresso=0 "
                        strSql += "WHERE (NumMesa = " & tbMesa.Text & ")"
                        ExecutaStr(strSql)
                        MontaBotoesMesas()
                    Else
                        Exit Sub
                    End If
                Else
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Conta já enviada. É necessário reabrir a Mesa/Cartão (" & tbMesa.Text & ") para continuar"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbMesa.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Modulo = "B" Then
            If InformaClienteBalcao = True Then
                strSql = "SELECT IDVenda, NomeCliente FROM tblVendas WHERE (IDVenda=" & IDVenda & ")"
                Dim NomeCliente As String = NuloString(PegaValorCampo("NomeCliente", strSql, strCon))

                Dim frmI As fdlgInformaClienteVenda = New fdlgInformaClienteVenda
                frmI.tbIDVenda.Text = NuloString(IDVenda)
                frmI.tbCliente.Text = NomeCliente
                frmI.ShowDialog()
            End If

            If QtdePessoasBalcao = True Then
                strSql = "SELECT IDVenda, QtdPessoas FROM tblVendas WHERE (IDVenda=" & IDVenda & ")"

                Dim frmII As fdlgQtdePessoas_Balcao = New fdlgQtdePessoas_Balcao
                frmII.tbIDVenda.Text = NuloString(IDVenda)
                frmII.tbQtdPessoas.Text = NuloString(PegaValorCampo("QtdPessoas", strSql, strCon))
                frmII.ShowDialog()
            End If

        Else
            strSql = "SELECT IDVenda, StatusVenda FROM tblVendas WHERE (IDVenda=" & IDVenda & ")"
            Dim Status As String = NuloString(PegaValorCampo("StatusVenda", strSql, strCon))
            If Status = "B" And InformaClienteBalcao = True Then
                strSql = "SELECT IDVenda, NomeCliente FROM tblVendas WHERE (IDVenda=" & IDVenda & ")"
                Dim NomeCliente As String = NuloString(PegaValorCampo("NomeCliente", strSql, strCon))

                Dim frmI As fdlgInformaClienteVenda = New fdlgInformaClienteVenda
                frmI.tbIDVenda.Text = NuloString(IDVenda)
                frmI.tbCliente.Text = NomeCliente


                frmI.ShowDialog()

            End If

        End If


        EnviaPedido()


        If ImprimeConsumo = True Then
            ImpressaoConsumo(IDVenda)
        End If


        If Modulo = "S" And TerminalVenda = False Then
            DataSetGrid.Clear()
            Grid.Refresh()
            MontaBotoesMesas()
            CalculaTotais()
            MontaGruposSalao(1)

            tbMesa.Text = String.Empty
            tbMesa.Text = String.Empty
            IDVenda = 0

            If InformaClienteBalcao = True Then
                btnPorCliente.Visible = True
            Else
                btnPorCliente.Visible = False
            End If
        End If
        If Modulo = "B" Then
            PedidoVenda = False
            VerificaMesaGrid()
        End If
        tbCodigoProduto.Text = String.Empty
        tbQtde.Text = "1,000"
        LBProduto.Text = String.Empty
        lbNomeCliente.Text = String.Empty
        QtdPessoas = 1
        MesaImpressa = False

        If TerminalVenda = True Then

            If PedeMesa = True Then

                fdlgOutroCartao.ShowDialog()

                If IDVenda <> 0 Then
                    BotaoPress = 0
                    MontaGruposSalao(paginaAtual)
                    Exit Sub
                Else
                    For iii = 0 To 49
                        If IDsVendas(iii) = 0 Then Exit For

                        strSql = "UPDATE tblVendasMovto Set "
                        strSql &= "Enviado=1 "
                        strSql &= "WHERE (IDVenda=" & IDsVendas(iii) & ") And (Enviado=0)"
                        ExecutaStr(strSql)
                        IDsVendas(iii) = 0
                    Next iii
                    MesaCartao = ""
                End If
            End If

            frmPrincipal.Enabled = True
            frmPrincipal.lblSenha.Text = String.Empty
            frmPrincipal.btnConfirma.Enabled = False
            frmPrincipal.btnConfig.Visible = False
            frmPrincipal.btnSalao.Visible = False
            frmPrincipal.btnBalcao.Visible = False
            frmPrincipal.btnDelivery.Visible = False
            frmPrincipal.lbFuncionario.Text = ""
            QtdeVendas = 1

            If PedeMesa = True Then
                If ConfirmaContinua = False And FixaTelaPedidos = False Then
                    Me.Dispose()
                    Me.Close()
                End If
            Else
                If FixaTelaPedidos = True Then
                    IDVenda = 0
                    QtdPessoas = 0
                    tbCodigoProduto.Text = ""
                    LBProduto.Text = ""
                    tbQtde.Text = "1,000"
                    DataSetGrid.Clear()
                    LinhaGrid()
                    AtualizaGrid()
                    CalculaTotais()
                    StiloGrid()
                    BotaoPress = 0
                    IniciaFrm()
                    LimpaVenda()
                Else
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Deseja efetuar nova venda"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.tbTempoInicio.Text = "15"
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    If RetornoMsg = False Then
                        Me.Dispose()
                        Me.Close()
                    Else
                        IDVenda = 0
                        QtdPessoas = 0
                        tbCodigoProduto.Text = ""
                        LBProduto.Text = ""
                        tbQtde.Text = "1,000"
                        DataSetGrid.Clear()
                        LinhaGrid()
                        AtualizaGrid()
                        CalculaTotais()
                        StiloGrid()
                        BotaoPress = 0
                        IniciaFrm()
                        LimpaVenda()
                    End If
                End If
            End If
        Else
            QtdeVendas = 1
            BotaoPress = 0
            MontaGruposSalao(paginaAtual)
        End If
        MontaProdutos(0)

        If Modulo = "B" Then
            tbCodigoProduto.Focus()
        Else
            tbMesa.Focus()
        End If
    End Sub
    Private Sub btnQtde_Click(sender As Object, e As EventArgs) Handles btnQtde.Click
        TempoTela = TempoLimite
        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If
        If Grid.SelectedRows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodigoProduto.Focus()
            Exit Sub
        End If
        If NuloString(Grid.Item(5, Grid.CurrentRow.Index).Value) <> "P" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Você não selecionou um produto válido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbCodigoProduto.Focus()
            Exit Sub
        End If


        fdlgAlteraQtde.ShowDialog()


        tbCodigoProduto.Focus()

    End Sub

    Private Sub TravaVenda()
        If PedidoVenda = True Then

            PanelProdutos.Controls.Clear()
            DataSetGrid.Clear()

            btnConfirma.Enabled = True
            btnComent.Enabled = True
            btnQtde.Enabled = True
            btnVerifica.Enabled = True
            btnLimpaProduto.Text = "Limpa Produto F3"
            Grid.BackgroundColor = Color.WhiteSmoke
        Else
            PanelProdutos.Controls.Clear()
            DataSetGrid.Clear()

            btnLimpaProduto.Text = "Estorna Produto F3"
            btnComent.Enabled = False
            btnQtde.Enabled = False
            btnConfirma.Enabled = False
            btnVerifica.Enabled = False
        End If
    End Sub

    Private Sub btnVerifica_Click(sender As Object, e As EventArgs) Handles btnVerifica.Click
        TempoTela = TempoLimite

        If PedidoVenda = False Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Impossível executar essa tarefa"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If

        If IDVenda = 0 Then
            If Modulo = "B" And VerificaVendaBalcao() = 0 Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Não existe venda aberta para verificar"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbMesa.Focus()
                Exit Sub
            Else
                If Modulo = "S" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    IDVenda = 0
                    NumMesa = 0
                    tbMesa.Text = ""
                    tbMesa.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Grid.Rows.Count <> 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = True Then
                PedidoVenda = False
                VerificaMesaGrid()
            Else
                tbCodigoProduto.Focus()
            End If
        Else
            PedidoVenda = False
            VerificaMesaGrid()
        End If
        BotaoPress = 0
        MontaGruposSalao(paginaAtual)

    End Sub

    Private Sub btnComent_Click(sender As Object, e As EventArgs) Handles btnComent.Click
        TempoTela = TempoLimite
        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If

        If Grid.SelectedRows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar uma produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If



        fdlgComentarioPrincipal.ShowDialog()

    End Sub

    Private Sub btnMensagens_Click(sender As Object, e As EventArgs) Handles btnMensagens.Click
        TempoTela = TempoLimite
        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm2.btnNao.Visible = True
            frm2.btnSim.Visible = True
            frm2.btnOK.Visible = False
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If
        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbMesa.Focus()
            Exit Sub
        End If


        Me.Enabled = False


        fdlgMensagens.ShowDialog()

    End Sub

    Private Sub btnConta_Click(sender As Object, e As EventArgs) Handles btnConta.Click
        TempoTela = TempoLimite


        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm1.btnNao.Visible = True
            frm1.btnSim.Visible = True
            frm1.btnOK.Visible = False
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm1.ShowDialog()

            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If


        If NuloString(tbMesa.Text) = "" Then
            IDVenda = 0
        End If

        If IDVenda <> 0 Then
            strSql = "UPDATE tblVendasMovto SET "
            strSql &= "ImprimeImpressora = 'true' "
            strSql += "WHERE (IDVenda = " & NuloInteger(IDVenda) & ")"
            ExecutaStr(strSql)
        End If

        Dim frm As fdlgConta = New fdlgConta
        If IDVenda = 0 Then
            frm.tbMesa.Text = ""
            frm.tbQtdePessoas.Text = ""
            frm.tbIDVenda.Text = "0"
        Else
            frm.tbMesa.Text = tbMesa.Text
            frm.tbQtdePessoas.Text = NuloString(QtdPessoas)
            frm.tbIDVenda.Text = NuloString(IDVenda)
        End If
        frm.ShowDialog()

        tbMesa.Focus()

        BotaoPress = 0
        MontaGruposSalao(paginaAtual)
        tbMesa.Focus()

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim dv As New DataView(DataSetGrid.Tables(0))

        'dv.Sort = "ID DESC, Status DESC"
        dv.Sort = "ID DESC"

        For i = 0 To dv.Count - 1
            MsgBox("1 - ID..................." & NuloInteger(dv.Item(i)("ID")) & vbCrLf &
            "2 - CodigoProduto_TXT..." & NuloInteger(dv.Item(i)("CodigoProduto_TXT")) & vbCrLf &
            "3 - Produto............." & NuloString(dv.Item(i)("Produto")) & vbCrLf &
            "4 - Qtde_TXT............" & NuloDecimal(dv.Item(i)("Qtde_TXT")).ToString("F2") & vbCrLf &
            "5 - IDPedido............" & NuloInteger(dv.Item(i)("IDPedido")) & vbCrLf &
            "6 - Status.............." & NuloString(dv.Item(i)("Status")) & vbCrLf &
            "7 - CodigoProduto......." & NuloInteger(dv.Item(i)("CodigoProduto")) & vbCrLf &
            "8 - Qtde................" & NuloDecimal(dv.Item(i)("Qtde")).ToString("F2") & vbCrLf &
            "9 - VlrUni.............." & NuloDecimal(dv.Item(i)("VlrUnit")).ToString("F2") & vbCrLf &
            "10- VlrUnit_TXT........." & NuloDecimal(dv.Item(i)("VlrUnit_TXT")).ToString("F2") & vbCrLf &
            "11- VlrTotal............" & NuloDecimal(dv.Item(i)("VlrTotal")).ToString("F2") & vbCrLf &
            "12- VlrTotal_TXT........" & NuloDecimal(dv.Item(i)("VlrTotal_TXT")).ToString("F2") & vbCrLf &
            "13- Atendente..........." & NuloString(dv.Item(i)("Atendente")) & vbCrLf &
            "14- Hora pedido........." & NuloString(dv.Item(i)("HoraPedido")) & vbCrLf &
            "15- IDGrupo............." & NuloInteger(dv.Item(i)("IDGrupo")) & vbCrLf &
            "16- IDFamilia..........." & NuloInteger(dv.Item(i)("IDFamilia")) & vbCrLf &
            "17- IDDetalhe..........." & NuloInteger(dv.Item(i)("IDDetalhe")) & vbCrLf &
            "18- IDMontagem.........." & NuloInteger(dv.Item(i)("IDMontagem")) & vbCrLf &
            "19- Grupo..............." & NuloString(dv.Item(i)("Grupo")) & vbCrLf &
            "20- Categoria..........." & NuloString(dv.Item(i)("Categoria")) & vbCrLf &
            "21- IDProduto..........." & NuloString(dv.Item(i)("IDProduto")) & vbCrLf &
            "22- Excluido............" & NuloString(dv.Item(i)("Excluido")) & vbCrLf &
            "23- IDMovto............." & NuloString(dv.Item(i)("IDMovto")) & vbCrLf &
            "24- Pai................." & NuloString(dv.Item(i)("Pai")) & vbCrLf &
            "25- Confirmado.........." & NuloBoolean(dv.Item(i)("Confirmado")) & vbCrLf &
            "26- VlrUni (serviço)...." & NuloDecimal(dv.Item(i)("VlrUnitServico")) & vbCrLf &
            "27- Com serviço........." & NuloBoolean(dv.Item(i)("ComServico")))



        Next

    End Sub
    Private Sub Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick

        Try

            If Modulo = "S" Then
                MontaBotoesMesas()
            End If

            lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub TBMesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMesa.KeyPress
        TempoTela = TempoLimite
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If Grid.Rows.Count <> 0 And PedidoVenda = True Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = True Then
                    VerificaMesa(tbMesa.Text)
                    PedidoVenda = False
                    VerificaMesaGrid()
                    MontaProdutos(0)
                Else
                    tbCodigoProduto.Focus()
                End If
            Else
                If Not IsNumeric(tbMesa.Text) Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Mesa/Cartão invalido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbMesa.Text = ""
                    Exit Sub
                End If
                VerificaMesa(tbMesa.Text)
                PedidoVenda = False
                VerificaMesaGrid()
                MontaProdutos(0)
            End If
        End If
    End Sub
    Private Sub TBMesa_Click(sender As Object, e As EventArgs) Handles tbMesa.Click
        TempoTela = TempoLimite
        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If
        If tbMesa.Text = "" Then
            IDVenda = 0
            NumMesa = 0
        End If
        PedidoVenda = True
        CalculaTotais()
        AtualizaGrid()
        TravaVenda()

        If TerminalVenda = True Then
            Dim frm1 As fdlgAbreMesa = New fdlgAbreMesa
            frm1.tbPraca.Text = tbPraca.Text

            frm1.ShowDialog()

        Else

            fdlgAbreMesa.ShowDialog()

        End If


        If IDVenda = 0 Then
            tbMesa.Focus()
        Else
            If PedeMesa = True And MesaCartao = "" Then

                fdlgPedeMesa.ShowDialog()

            End If
        End If


        MontaProdutos(0)

    End Sub
    Private Sub TBCodigoProduto_Enter(sender As Object, e As EventArgs) Handles tbCodigoProduto.Enter
        If Modulo = "S" Then
            If IDVenda = 0 Then tbMesa.Focus()
            If tbMesa.Text = "" Then tbMesa.Focus()
            If PedidoVenda = False Then tbMesa.Focus()
        End If
    End Sub
    Private Sub TBQtde_Enter(sender As Object, e As EventArgs) Handles tbQtde.Enter
        If Modulo = "S" Then
            If IDVenda = 0 Then tbMesa.Focus()
            If tbMesa.Text = "" Then tbMesa.Focus()
            If tbCodigoProduto.Text = "" Then tbCodigoProduto.Focus()
            If PedidoVenda = False Then tbMesa.Focus()
        End If
    End Sub

    Private Sub TBCodigoProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodigoProduto.KeyPress
        TempoTela = TempoLimite

        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If Not IsNumeric(tbCodigoProduto.Text) And tbCodigoProduto.Text <> "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Código do produto inválido"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbCodigoProduto.Text = ""
                Exit Sub
            End If

            Dim teclaMais As Boolean = False
            If PedidoVenda = False Then
                LinhaGrid()
                PedidoVenda = True
                DataSetGrid.Clear()
                TravaVenda()
                CalculaTotais()
            End If

            AtualizaGrid()

            If Len(tbCodigoProduto.Text) > 8 Then
                Dim con1 As New SqlConnection()
                Dim CProd As Integer
                strSql = "Select CodigoProduto, CodigoFabricante From tblProdutos_Local Where (CodigoFabricante = '" & CLng(tbCodigoProduto.Text) & "')"

                Dim dr1 As SqlDataReader
                con1.ConnectionString = strCon
                Dim cmd1 As SqlCommand = con1.CreateCommand
                cmd1.CommandText = strSql

                con1.Open()
                dr1 = cmd1.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If dr1.HasRows Then
                    dr1.Read()
                    CProd = NuloInteger(Trim(dr1.Item("CodigoProduto").ToString))
                End If
                AchaProduto(CProd)
                cmd1.Dispose()
                dr1.Close()
                con1.Dispose()
                con1.Close()
                tbCodigoProduto.Text = CProd.ToString
            End If

            If tbCodigoProduto.Text <> "" Then

                If InStr(tbCodigoProduto.Text, "+") > 0 Then
                    teclaMais = True
                    tbCodigoProduto.Text = Strings.Left(tbCodigoProduto.Text, Len(tbCodigoProduto.Text) - 1)
                Else
                    teclaMais = False
                End If

                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.Venda, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza, tblProdutos_Local_1.IDProduto AS IDProdutoCorreto, tblCombos_Local.AgregaValor "
                strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                strSql += "Where (tblProdutos_Local.Modulos = 'T' OR tblProdutos_Local.Modulos Like '%" & Modulo & "%') AND (tblProdutos_Local.CodigoProduto=" & tbCodigoProduto.Text & ") "

                Dim DescCombo As String = ""
                Dim EPizzaCombo As Boolean = False
                Dim IDfam As Integer = 0
                Dim IDprodCorreto As Integer = 0
                Dim drC As SqlDataReader
                VlrUnitario = 0

                AgregaValor = False

                Dim conC As New SqlConnection()
                conC.ConnectionString = strCon
                Dim cmdC As SqlCommand = conC.CreateCommand
                cmdC.CommandText = strSql
                conC.Open()
                drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If drC.HasRows Then
                    drC.Read()
                    DescCombo = NuloString(drC.Item("ProdCorreto"))
                    IDfam = NuloInteger(drC.Item("IDFamilia"))
                    IDprodCorreto = NuloInteger(drC.Item("IDProdutoCorreto"))
                    AgregaValor = NuloBoolean(drC.Item("AgregaValor"))
                    EPizzaCombo = NuloBoolean(drC.Item("EPizza"))
                    VlrUnitario = NuloDecimal(drC.Item("Venda"))
                End If
                cmdC.Dispose()
                drC.Close()
                conC.Dispose()
                conC.Close()

                CodProIni = 0
                If DescCombo <> "" And EPizzaCombo = True Then

                    LBProduto.Text = DescCombo
                    EGrupoPizza = True
                    IDProdutoSel = IDprodCorreto

                    Dim frmFC As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                    frmFC.tbIDFamiliaSel.Text = NuloString(IDfam)
                    frmFC.tbCodPro.Text = NuloString(NuloInteger(tbCodigoProduto.Text))
                    CodProIni = NuloInteger(tbCodigoProduto.Text)


                    frmFC.ShowDialog()


                    tbCodigoProduto.Text = ""
                    LBProduto.Text = ""
                    tbQtde.Text = ""

                    tbCodigoProduto.Text = ""
                    LBProduto.Text = ""
                    tbQtde.Text = "1,000"

                    Exit Sub
                End If
            Else
                CodProIni = 0
            End If

            If Modulo = "S" Then
                RetornoMsg = True
                If MesaImpressa = True Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Conta já enviada. Deseja reabrir a Mesa/Cartão para continuar"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao

                    frm.ShowDialog()

                    If RetornoMsg = False Then
                        tbCodigoProduto.Text = ""
                        tbMesa.Focus()
                        Exit Sub
                    Else
                        strSql = "UPDATE tblMesas Set "
                        strSql &= "Flag=1,"
                        strSql &= "Impresso=0 "
                        strSql &= "WHERE (NumMesa=" & tbMesa.Text & ")"
                        ExecutaStr(strSql)
                        MesaImpressa = False
                        MontaBotoesMesas()
                    End If
                End If

                If RetornoMsg = True Then

                    If PedidoVenda = True And Grid.Rows.Count > 0 And NuloString(tbCodigoProduto.Text) = "" Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Deseja confirmar este pedido"
                        frm.btnNao.Visible = True
                        frm.btnSim.Visible = True
                        frm.btnOK.Visible = False
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                        frm.ShowDialog()
                        If RetornoMsg = True Then
                            BotaoConfirma()
                        Else
                            tbCodigoProduto.Text = ""
                            tbQtde.Text = "1,000"
                            LBProduto.Text = ""
                            IDProdutoSel = 0
                        End If
                        Exit Sub
                    End If


                    AchaProduto(NuloInteger(tbCodigoProduto.Text))
                    If PesoPego <> 0 Then
                        tbQtde.Text = NuloString(NuloDecimal(PesoPego))
                    End If


                    strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDProduto, tblCombos_Local.IDFamilia, tblGrupos_Local.EPizza, tblCombos_Local.AgregaValor "
                    strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                    strSql += "Where (tblCombos_Local.IDProduto = " & IDProdutoSel & ")"
                    If NuloBoolean(EGrupoPizza) = True Then
                        AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                        Dim frmF As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                        frmF.tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))

                        frmF.ShowDialog()


                        teclaMais = False
                        tbCodigoProduto.Text = ""
                        LBProduto.Text = ""
                        tbQtde.Text = "1,000"
                        tbCodigoProduto.Focus()
                    Else
                        If NuloInteger(PegaValorCampo("IDProduto", strSql, strCon)) <> 0 Then
                            AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                            EGrupoPizza = False


                            fdlgCombo_porCodigo.ShowDialog()


                            teclaMais = False
                            tbCodigoProduto.Text = ""
                            LBProduto.Text = ""
                            tbQtde.Text = "1,000"
                            tbCodigoProduto.Focus()
                        End If
                    End If
                End If
            End If

            If Modulo = "B" Then
                If AchaProduto(NuloInteger(tbCodigoProduto.Text)) = True Then
                    If VerificaVendaBalcao() = 0 Then
                        AbreVendaBalcao()
                        IDVenda = PegaID("IDVenda", "tblVendas", "L")
                        tbMesa.Text = NumMesa.ToString
                        SendKeys.Send("+{END}")
                    End If
                    If PedidoVenda = False Then
                        PanelProdutos.Controls.Clear()
                        DataSetGrid.Clear()
                        btnConfirma.Enabled = True
                        btnComent.Enabled = True
                        btnQtde.Enabled = True
                        btnVerifica.Enabled = True
                        btnLimpaProduto.Text = "Limpa Produto   F3"
                        Grid.BackgroundColor = Color.WhiteSmoke
                    End If
                    PedidoVenda = True

                    strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDProduto, tblCombos_Local.IDFamilia, tblGrupos_Local.EPizza, tblCombos_Local.AgregaValor "
                    strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                    strSql += "Where (tblCombos_Local.IDProduto = " & IDProdutoSel & ")"
                    If NuloBoolean(EGrupoPizza) = True Then
                        AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))

                        Dim frmF As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                        frmF.tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))

                        frmF.ShowDialog()


                        'fdlgCombo_porCodigo.ShowDialog()
                        teclaMais = False
                        tbCodigoProduto.Text = ""
                        LBProduto.Text = ""
                        tbQtde.Text = "1,000"
                        tbCodigoProduto.Focus()
                    Else
                        If NuloInteger(PegaValorCampo("IDProduto", strSql, strCon)) <> 0 Then
                            AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                            EGrupoPizza = False


                            fdlgCombo_porCodigo.ShowDialog()


                            teclaMais = False
                            tbCodigoProduto.Text = ""
                            LBProduto.Text = ""
                            tbQtde.Text = "1,000"
                            tbCodigoProduto.Focus()
                        End If
                    End If
                End If
            End If
        End If


        If e.KeyChar = "+" Then

            If PedidoVenda = False Then
                LinhaGrid()
                PedidoVenda = True
                DataSetGrid.Clear()
                TravaVenda()
                CalculaTotais()
            End If

            AtualizaGrid()

            If tbCodigoProduto.Text <> "" Then
                'tbCodigoProduto.Text = Strings.Left(tbCodigoProduto.Text, Len(tbCodigoProduto.Text) - 1)

                ' Verifica se é produto COMBO   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblCombos_Local.IDFamilia, tblProdutos_Local_1.Produto As ProdCorreto, tblProdutos_Local_1.CodigoProduto As CodCorreto, tblProdutos_Local_1.Produto + ' (' + CAST(tblProdutos_Local_1.CodigoProduto AS VarChar(10)) + ')' AS Descricao, tblGrupos_Local.EPizza "
                strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDFamilia = tblProdutos_Local.IDFamilia INNER Join tblProdutos_Local As tblProdutos_Local_1 On tblCombos_Local.IDProduto = tblProdutos_Local_1.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local_1.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                strSql += "Where tblProdutos_Local.CodigoProduto=" & tbCodigoProduto.Text
                Dim DescCombo As String = ""
                Dim EPizzaCombo As Boolean = False
                Dim drC As SqlDataReader
                Dim conC As New SqlConnection()
                conC.ConnectionString = strCon
                Dim cmdC As SqlCommand = conC.CreateCommand
                cmdC.CommandText = strSql

                conC.Open()
                drC = cmdC.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                If drC.HasRows Then
                    drC.Read()
                    DescCombo = NuloString(drC.Item("Descricao"))
                    EPizzaCombo = NuloBoolean(drC.Item("EPizza"))
                End If
                cmdC.Dispose()
                drC.Close()
                conC.Dispose()
                conC.Close()

                If DescCombo <> "" And EPizzaCombo = True Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Este produto é o sabor de uma pizza" + vbCrLf + "Inicie pelo produto principal" + vbCrLf + "Ex.: " + DescCombo
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    tbCodigoProduto.Text = ""
                    LBProduto.Text = ""
                    tbQtde.Text = "1,000"

                    Exit Sub
                End If
            End If


            If Modulo = "S" Then
                If tbCodigoProduto.Text = "" Then
                    Dim NumMesa As String
                    NumMesa = NuloString(tbMesa.Text)
                    tbMesa.Text = ""
                    tbMesa.Focus()
                    tbMesa.Text = NumMesa
                    SendKeys.Send("+{END}")
                Else
                    If ObrigaConta = True And MesaImpressa = True Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Conta já enviada. É necessário reabrir a Mesa/Cartão para continuar"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbCodigoProduto.Text = ""

                        tbMesa.Focus()
                        Exit Sub
                    Else
                        AchaProduto(NuloInteger(tbCodigoProduto.Text))
                        strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDProduto, tblCombos_Local.IDFamilia, tblGrupos_Local.EPizza, tblCombos_Local.AgregaValor "
                        strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                        strSql += "Where (tblCombos_Local.IDProduto = " & IDProdutoSel & ")"
                        If NuloBoolean(EGrupoPizza) = True Then
                            AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                            Dim frmF As fdlgCombo_porCodigo = New fdlgCombo_porCodigo
                            frmF.tbIDFamilia.Text = NuloString(NuloInteger(PegaValorCampo("IDFamilia", strSql, strCon)))

                            frmF.ShowDialog()


                            tbCodigoProduto.Text = ""
                            LBProduto.Text = ""
                            tbQtde.Text = "1,000"
                            tbCodigoProduto.Focus()
                        Else
                            If NuloInteger(PegaValorCampo("IDProduto", strSql, strCon)) <> 0 Then
                                AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                                EGrupoPizza = False


                                fdlgCombo_porCodigo.ShowDialog()


                                tbCodigoProduto.Text = ""
                                LBProduto.Text = ""
                                tbQtde.Text = "1,000"
                                tbCodigoProduto.Focus()
                            End If
                        End If
                    End If
                End If
            End If

            If Modulo = "B" Then
                If AchaProduto(NuloInteger(tbCodigoProduto.Text)) = True Then
                    If VerificaVendaBalcao() = 0 Then
                        AbreVendaBalcao()
                        IDVenda = PegaID("IDVenda", "tblVendas", "L")
                        tbMesa.Text = NumMesa.ToString
                        SendKeys.Send("+{END}")
                    End If
                    If PedidoVenda = False Then
                        PanelProdutos.Controls.Clear()
                        DataSetGrid.Clear()
                        btnConfirma.Enabled = True
                        btnComent.Enabled = True
                        btnQtde.Enabled = True
                        btnVerifica.Enabled = True
                        btnLimpaProduto.Text = "Limpa Produto   F3"
                        Grid.BackgroundColor = Color.WhiteSmoke
                    End If
                    PedidoVenda = True

                    strSql = "Select tblCombos_Local.IDCombo, tblCombos_Local.IDProduto, tblCombos_Local.IDFamilia, tblGrupos_Local.EPizza, tblCombos_Local.AgregaValor "
                    strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
                    strSql += "Where (tblCombos_Local.IDProduto = " & IDProdutoSel & ")"
                    If NuloBoolean(EGrupoPizza) = True Then
                        AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))


                        fdlgCombo_porCodigo.ShowDialog()


                        tbCodigoProduto.Text = ""
                        LBProduto.Text = ""
                        tbQtde.Text = "1,000"
                        tbCodigoProduto.Focus()
                    Else
                        If NuloInteger(PegaValorCampo("IDProduto", strSql, strCon)) <> 0 Then
                            AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                            EGrupoPizza = False


                            fdlgCombo_porCodigo.ShowDialog()


                            tbCodigoProduto.Text = ""
                            LBProduto.Text = ""
                            tbQtde.Text = "1,000"
                            tbCodigoProduto.Focus()
                        End If
                    End If
                End If
            End If


            If tbCodigoProduto.Text <> "" Then
                If tbQtde.Text = "" Then tbQtde.Text = "1,000"
                If PedidoVenda = False Then
                    tbMesa.Focus()
                    Exit Sub
                End If

                ' Proximo ID do Grid ////////////////////////////////////////////////////////////////////////////////////////////
                Dim IDGrid As Integer

                If Me.DataSetGrid.Tables(0).Rows.Count = 0 Then
                    IDGrid = 1
                Else
                    For i As Integer = 0 To Me.DataSetGrid.Tables(0).Rows.Count - 1
                        If NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(4)) > IDGrid Then
                            IDGrid = NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(4))
                        End If

                    Next
                    IDGrid += 1
                End If
                Dim Qtde As Double = NuloDouble(tbQtde.Text)
                '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                strSql = "Select CodigoGrupo, Grupo From tblGrupos_Local Where (CodigoGrupo =" & NuloInteger(CodigoGrupo) & ")"
                Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))

                IncluiProdGrid(IDGrid, NuloInteger(tbCodigoProduto.Text), LBProduto.Text, VlrUnitario, CodigoGrupo, IDFamilia, 0, 0, "P", Qtde, Grupo, Categoria, IDProdutoSel, 0, IDGrid, False)

                tbCodigoProduto.Text = ""
                LBProduto.Text = ""
                tbQtde.Text = "1,000"
                tbCodigoProduto.Focus()

                If Grid.SelectedRows.Count > 0 Then
                    For i As Integer = 0 To Grid.Rows.Count - 1
                        Grid.Rows(i).Selected = False
                    Next
                End If

                SendKeys.Send("{BACKSPACE}")

            End If

        End If




    End Sub
    Private Sub TBQtde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtde.KeyPress
        TempoTela = TempoLimite



        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If NuloString(tbMesa) = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = TextoMesaPAR & " inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                tbCodigoProduto.Text = ""
                LBProduto.Text = ""
                tbQtde.Text = "1,000"
                tbCodigoProduto.Focus()

                tbMesa.Focus()
                Exit Sub
            End If


            If tbQtde.Text = "" Then tbQtde.Text = "1,000"
            If Not IsNumeric(tbQtde.Text) Then tbQtde.Text = "1,000"

            If PedidoVenda = False Then
                tbMesa.Focus()
                Exit Sub
            End If


            ' Proximo ID do Grid ////////////////////////////////////////////////////////////////////////////////////////////
            Dim IDGrid As Integer

            If Me.DataSetGrid.Tables(0).Rows.Count = 0 Then
                IDGrid = 1
            Else
                For i As Integer = 0 To Me.DataSetGrid.Tables(0).Rows.Count - 1
                    If NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(4)) > IDGrid Then
                        IDGrid = NuloInteger(Me.DataSetGrid.Tables(0).Rows(i).Item(4))
                    End If

                Next
                IDGrid += 1
            End If

            Dim Qtde As Double = NuloDouble(tbQtde.Text)
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            strSql = "Select CodigoGrupo, Grupo From tblGrupos_Local Where (CodigoGrupo =" & NuloInteger(CodigoGrupo) & ")"
            Grupo = NuloString(PegaValorCampo("Grupo", strSql, strCon))

            IncluiProdGrid(IDGrid, NuloInteger(tbCodigoProduto.Text), LBProduto.Text, VlrUnitario, CodigoGrupo, IDFamilia, 0, 0, "P", Qtde, Grupo, Categoria, IDProdutoSel, 0, IDGrid, False)

            tbCodigoProduto.Text = ""
            LBProduto.Text = ""
            tbQtde.Text = "1,000"
            tbCodigoProduto.Focus()

            If Grid.SelectedRows.Count > 0 Then
                For i As Integer = 0 To Grid.Rows.Count - 1
                    Grid.Rows(i).Selected = False
                Next
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Grid.Rows.Count > 0 Then
            For i = 0 To Grid.Rows.Count - 1
                MsgBox("1 - ID..................." & NuloInteger(Grid.Item(0, i).Value) & vbCrLf &
                            "2 - IDPedido............" & NuloInteger(Grid.Item(1, i).Value) & vbCrLf &
                            "3 - CodigoProduto TXT..." & NuloInteger(Grid.Item(2, i).Value) & vbCrLf &
                            "4 - Produto............." & NuloInteger(Grid.Item(3, i).Value) & vbCrLf &
                            "5 - Qtde_TXT............" & NuloDecimal(Grid.Item(4, i).Value).ToString("F2") & vbCrLf &
                            "6 - ValorUnit TXT......." & NuloDecimal(Grid.Item(5, i).Value).ToString("F2") & vbCrLf &
                            "7 - ValorTotal TXT......" & NuloDecimal(Grid.Item(6, i).Value).ToString("F2") & vbCrLf &
                            "8 - Status.............." & NuloString(Grid.Item(7, i).Value) & vbCrLf &
                            "9 - Codigo Produto......" & NuloInteger(Grid.Item(8, i).Value) & vbCrLf &
                            "10- Qtde................" & NuloDecimal(Grid.Item(9, i).Value).ToString("F2") & vbCrLf &
                            "11- ValorUnit..........." & NuloDecimal(Grid.Item(10, i).Value).ToString("F2") & vbCrLf &
                            "12- VlrTotal_TXT........" & NuloDecimal(Grid.Item(11, i).Value).ToString("F2") & vbCrLf &
                            "13- Atendente..........." & NuloString(Grid.Item(12, i).Value) & vbCrLf &
                            "14- Hora Pedido........." & NuloString(Grid.Item(13, i).Value) & vbCrLf &
                            "15- IDGrupo............." & NuloInteger(Grid.Item(14, i).Value) & vbCrLf &
                            "16- IDFamilia..........." & NuloInteger(Grid.Item(15, i).Value) & vbCrLf &
                            "17- IDDetalhe..........." & NuloInteger(Grid.Item(16, i).Value) & vbCrLf &
                            "18- IDMontagem.........." & NuloInteger(Grid.Item(17, i).Value) & vbCrLf &
                            "19- Grupo..............." & NuloString(Grid.Item(18, i).Value) & vbCrLf &
                            "20- IDProduto..........." & NuloInteger(Grid.Item(19, i).Value) & vbCrLf &
                            "21- Excluido............" & NuloBoolean(Grid.Item(20, i).Value) & vbCrLf &
                            "22- IDMovto............." & NuloInteger(Grid.Item(21, i).Value) & vbCrLf &
                            "23- ValorUnit (serviço)." & NuloInteger(Grid.Item(22, i).Value) & vbCrLf &
                            "24- Com Serciço         " & NuloBoolean(Grid.Item(23, i).Value))
            Next
        End If

    End Sub

    Private Sub btnPagina_1_Click(sender As Object, e As EventArgs) Handles btnPagina_1.Click
        TempoTela = TempoLimite
        If paginaAtual <> 1 Then
            btnPagina_1.BackColor = Color.Lavender
            btnPagina_2.BackColor = Color.White
            btnPagina_3.BackColor = Color.White
            btnPagina_4.BackColor = Color.White
            MontaGruposSalao(1)
        End If
        tbMesa.Focus()
    End Sub

    Private Sub btnPagina_2_Click(sender As Object, e As EventArgs) Handles btnPagina_2.Click
        TempoTela = TempoLimite
        If paginaAtual <> 2 Then
            btnPagina_2.BackColor = Color.Lavender
            btnPagina_1.BackColor = Color.White
            btnPagina_3.BackColor = Color.White
            btnPagina_4.BackColor = Color.White
            MontaGruposSalao(2)
        End If
        tbMesa.Focus()
    End Sub

    Private Sub btnPagina_3_Click(sender As Object, e As EventArgs) Handles btnPagina_3.Click
        TempoTela = TempoLimite
        If paginaAtual <> 3 Then
            btnPagina_3.BackColor = Color.Lavender
            btnPagina_2.BackColor = Color.White
            btnPagina_1.BackColor = Color.White
            btnPagina_4.BackColor = Color.White
            MontaGruposSalao(3)
        End If
        tbMesa.Focus()
    End Sub

    Private Sub btnPagina_4_Click(sender As Object, e As EventArgs) Handles btnPagina_4.Click
        TempoTela = TempoLimite
        If paginaAtual <> 4 Then
            btnPagina_4.BackColor = Color.Lavender
            btnPagina_2.BackColor = Color.White
            btnPagina_3.BackColor = Color.White
            btnPagina_1.BackColor = Color.White
            MontaGruposSalao(4)
        End If
        tbMesa.Focus()
    End Sub
    Private Sub btnTransferencia_Click(sender As Object, e As EventArgs) Handles btnTransferencia.Click
        TempoTela = TempoLimite

        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm2.btnNao.Visible = True
            frm2.btnSim.Visible = True
            frm2.btnOK.Visible = False
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If

        If IsDBNull(IDVenda) Or IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar " & TextoMsg
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If Modulo = "S" Then
            If OperadorTransfere = False Then
                IDFuncionarioAutorizado = 0
                FuncionarioAutorizado = ""
                Dim frm1 As fdlgAutorizacao = New fdlgAutorizacao
                frm1.tbTipo.Text = "T"
                frm1.lbTipo.Text = "Autorização para TRANSFERÊNCIA"
                frm1.ShowDialog()
                If Autorizado = False Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Sem permissão para transferência"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbMesa.Focus()
                    Exit Sub
                Else

                    fdlgTransferencias.ShowDialog()

                End If
            Else
                IDFuncionarioAutorizado = IDOperador
                FuncionarioAutorizado = NuloString(Operador)

                fdlgTransferencias.ShowDialog()

            End If
            BotaoPress = 0
            MontaGruposSalao(paginaAtual)
            tbMesa.Focus()
        Else
            'If PedidoVenda = False Then
            Dim frm1 As fdlgDescontoBalcao = New fdlgDescontoBalcao
            frm1.tbIDVenda.Text = NuloString(IDVenda)
            frm1.tbTotalProdutos.Text = NuloString(NuloDecimal(txtProdutos.Text))
            frm1.ShowDialog()
            'IniciaFrm()
            'MontaProdutos(0)
            'VerificaMesaGrid()
            'AtualizaGrid()
            If PedidoVenda = False Then
                LinhaGrid()
                'PedidoVenda = True
                'DataSetGrid.Clear()
                'TravaVenda()
            End If
            CalculaTotais()
            tbCodigoProduto.Focus()

            'End If
        End If


    End Sub

    Private Sub btnPagamento_Click(sender As Object, e As EventArgs) Handles btnPagamento.Click
        TempoTela = TempoLimite
        If TerminalVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Sem permissão para pagamento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbMesa.Focus()
            Exit Sub
        End If



        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If

        tbCodigoProduto.Text = String.Empty
        tbQtde.Text = "1,000"
        LBProduto.Text = String.Empty
        QtdPessoas = 1
        MesaImpressa = False
        tbCodigoProduto.Focus()

        If TerminalVenda = True Then
            frmPrincipal.Enabled = True
            frmPrincipal.lblSenha.Text = String.Empty
            frmPrincipal.btnConfirma.Enabled = False
            frmPrincipal.btnConfig.Visible = False
            frmPrincipal.btnSalao.Visible = False
            frmPrincipal.btnBalcao.Visible = False
            frmPrincipal.btnDelivery.Visible = False
            frmPrincipal.lbFuncionario.Text = ""
            Me.Dispose()
            Me.Close()
        End If


        frmPagamento.ShowDialog()


        If VendaBalcaoRecebida = True Then
            tbMesa.Text = String.Empty
            tbMesa.Text = String.Empty
            IDVenda = 0
            DataSetGrid.Clear()
            Grid.Refresh()
            MontaBotoesMesas()
            CalculaTotais()
            MontaGruposSalao(1)
            PanelProdutos.Controls.Clear()
            btnConfirma.Enabled = True
            btnComent.Enabled = True
            btnQtde.Enabled = True
            btnVerifica.Enabled = True
            btnLimpaProduto.Text = "Limpa Produto   F3"
            Grid.BackgroundColor = Color.WhiteSmoke
        End If

        MontaBotoesMesas()
        PedidoVenda = False
        LBProduto.Text = ""
        tbMesa.Focus()

    End Sub

    Private Sub btnSize_Click(sender As Object, e As EventArgs) Handles btnSize.Click

        If PanelMesas.Visible = True Then
            PanelMesas.Visible = False
            btnMaisMesas.Visible = False
            btnMenosMesas.Visible = False
            If DefinicaoReduzida = False Then
                PanelProdutos.Size = New System.Drawing.Size(1267 - 40, 242)
            Else
                PanelProdutos.Size = New System.Drawing.Size(1010 - 40, 242)
            End If
        Else
            PanelMesas.Visible = True
            btnMaisMesas.Visible = True
            btnMenosMesas.Visible = True
            If DefinicaoReduzida = False Then
                PanelProdutos.Size = New System.Drawing.Size(1267 - 40, 173)
            Else
                PanelProdutos.Size = New System.Drawing.Size(1010 - 40, 173)
            End If
        End If
    End Sub
    Private Sub TBMesa_GotFocus(sender As Object, e As EventArgs) Handles tbMesa.GotFocus
        TempoTela = TempoLimite
        tbCodigoProduto.Focus()

    End Sub

    Private Sub frmSalao_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        TempoTela = TempoLimite
        Select Case e.KeyCode
            Case Keys.KeyCode.F1
                If Modulo <> "B" Then
                    LimpaVenda()
                End If

            Case Keys.KeyCode.F3
                Me.InvokeOnClick(btnLimpaProduto, e)

            Case Keys.KeyCode.F4
                Me.InvokeOnClick(btnConta, e)

            Case Keys.KeyCode.F5
                Me.InvokeOnClick(btnTransferencia, e)

            Case Keys.KeyCode.F8
                Me.InvokeOnClick(btnPagamento, e)

            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.F10
                Me.InvokeOnClick(btnVerifica, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnVoltar, e)

                '  Case Keys.KeyCode.B
                '     If Modulo = "S" Then
                '    If Grid.Rows.Count <> 0 And PedidoVenda = True Then
                '   Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                '  frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                ' frm.btnNao.Visible = True
                'frm.btnSim.Visible = True
                'frm.btnOK.Visible = False
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                'frm.ShowDialog()
                '
                'If RetornoMsg = False Then
                'TimerTela.Start()
                'tbCodigoProduto.Focus()
                'Exit Sub
                'End If
                'tbMesa.Text = ""
                'tbCodigoProduto.Text = ""
                'tbQtde.Text = "1,000"
                'IrBalcao()
                'Else
                'tbMesa.Text = ""
                'tbCodigoProduto.Text = ""
                'tbQtde.Text = "1,000"
                'IrBalcao()
                'End If
                'End If

                'Case Keys.KeyCode.S
                '   If Modulo = "B" Then
                '  If Grid.Rows.Count <> 0 And PedidoVenda = True Then
                ' Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                'frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                'frm.btnNao.Visible = True
                'frm.btnSim.Visible = True
                'frm.btnOK.Visible = False
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                'frm.ShowDialog()
                '
                'If RetornoMsg = False Then
                'TimerTela.Start()
                '  tbCodigoProduto.Focus()
                '   Exit Sub
                'End If
                'tbMesa.Text = ""
                ' tbCodigoProduto.Text = ""
                '  tbQtde.Text = "1,000"
                '   IrSalao()
                'Else
                '   tbMesa.Text = ""
                '    tbCodigoProduto.Text = ""
                '     tbQtde.Text = "1,000"
                '      IrSalao()
                '   End If
                'End If

                'Case Keys.KeyCode.D
                '   IrDelivery()

        End Select


    End Sub

    Private Sub btnSalao_Click(sender As Object, e As EventArgs) Handles btnSalao.Click
        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm2.btnNao.Visible = True
            frm2.btnSim.Visible = True
            frm2.btnOK.Visible = False
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If
        IrSalao()
    End Sub

    Private Sub btnBalcao_Click(sender As Object, e As EventArgs) Handles btnBalcao.Click

        IrBalcao()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnGaveta.Click
        TempoTela = TempoLimite
        AcionaGaveta()
    End Sub

    Private Sub frmSalao_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        IDVenda = 0
        MesaCartao = ""
    End Sub
    Private Sub lbMesaCartao_Click(sender As Object, e As EventArgs)
        TempoTela = TempoLimite
        fdlgPedeMesa.ShowDialog()
    End Sub

    Private Sub btnMesaCartao_Click(sender As Object, e As EventArgs)

        TempoTela = TempoLimite
        TimerTela.Stop()

        Dim frm As fdlgMesaCartao = New fdlgMesaCartao
        frm.tbStatus.Text = ""
        frm.Size = New System.Drawing.Size(689, 541)
        frm.ShowDialog()

        TimerTela.Start()
        tbCodigoProduto.Focus()
    End Sub

    Private Sub TimerTela_Tick(sender As Object, e As EventArgs) Handles TimerTela.Tick

        TempoTela -= 1
        lbTempo.Text = NuloString(TempoTela)
        If TempoTela <= 0 Then
            If TempoLimite > 0 Then
                Me.InvokeOnClick(btnVoltar, e)
            Else
                TempoTela = TempoLimite
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TempoTela = TempoLimite
        TimerTela.Stop()

        Dim frm As fdlgMesaCartao = New fdlgMesaCartao
        frm.tbStatus.Text = "C"
        frm.Label2.Visible = False
        frm.Label4.Visible = False
        frm.lbAtendente.Visible = False
        frm.lbTerminal.Visible = False
        frm.Button1.Visible = False


        frm.ShowDialog()


        TimerTela.Start()
        tbMesa.Focus()

    End Sub

    Private Sub tbMesa_TextChanged(sender As Object, e As EventArgs) Handles tbMesa.TextChanged

    End Sub

    Private Sub TBQtde_TextChanged(sender As Object, e As EventArgs) Handles tbQtde.TextChanged

    End Sub

    Private Sub btnDelivery_Click(sender As Object, e As EventArgs) Handles btnDelivery.Click
        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm2 As fdlgMensagemBox = New fdlgMensagemBox
            frm2.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm2.btnNao.Visible = True
            frm2.btnSim.Visible = True
            frm2.btnOK.Visible = False
            frm2.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm2.ShowDialog()
            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If

        IrDelivery()
    End Sub

    Private Sub tbCodigoProduto_TextChanged(sender As Object, e As EventArgs) Handles tbCodigoProduto.TextChanged

        If tbCodigoProduto.Text = "*" Then
            tbCodigoProduto.Text = ""
            fdlgBuscaProduto.ShowDialog()
            If CodigoProdutoBusca <> 0 Then
                tbCodigoProduto.Text = NuloString(CodigoProdutoBusca)
            End If
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        AtualizaVendasServidor()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick


        If Grid.Rows.Count <> 0 Then
            If PedidoVenda = False Then
                Dim frm As fdlgLancamento = New fdlgLancamento
                frm.tbIDVendaMovto.Text = NuloString(NuloInteger(Grid.Item(21, Grid.CurrentRow.Index).Value))

                frm.ShowDialog()

            End If
        End If
        'fdlgLancamento.ShowDialog()
    End Sub

    Private Sub BtnMais_Click(sender As Object, e As EventArgs) Handles btnMais.Click
        If PanelMesas.Visible = True Then
            Incremento = 32
        Else
            Incremento = 48
        End If
        tbPagina.Text = (NuloInteger(tbPagina.Text) + Incremento).ToString
        MontaProdutos(NuloInteger(tbCondicao.Text))
        If nn = 0 Then
            tbPagina.Text = (NuloInteger(tbPagina.Text) - Incremento).ToString
            MontaProdutos(NuloInteger(tbCondicao.Text))
        End If
        If Modulo = "S" Then
            tbMesa.Focus()
        Else
            tbCodigoProduto.Focus()
        End If
    End Sub

    Private Sub BtnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        If PanelMesas.Visible = True Then
            Incremento = 32
        Else
            Incremento = 48
        End If
        tbPagina.Text = (NuloInteger(tbPagina.Text) - Incremento).ToString
        MontaProdutos(NuloInteger(tbCondicao.Text))
        If Modulo = "S" Then
            tbMesa.Focus()
        Else
            tbCodigoProduto.Focus()
        End If
    End Sub

    Private Sub BtnMenosMesas_Click(sender As Object, e As EventArgs) Handles btnMenosMesas.Click
        If DefinicaoReduzida = True Then
            IncrementoMesas = 17
        Else
            IncrementoMesas = 20
        End If
        tbPaginaMesas.Text = (NuloInteger(tbPaginaMesas.Text) - IncrementoMesas).ToString
        MontaBotoesMesas()
        If Modulo = "S" Then
            tbMesa.Focus()
        Else
            tbCodigoProduto.Focus()
        End If
    End Sub

    Private Sub BtnMaisMesas_Click(sender As Object, e As EventArgs) Handles btnMaisMesas.Click
        If DefinicaoReduzida = True Then
            IncrementoMesas = 17
        Else
            IncrementoMesas = 20
        End If
        tbPaginaMesas.Text = (NuloInteger(tbPaginaMesas.Text) + IncrementoMesas).ToString
        MontaBotoesMesas()
        If nnMesas = 0 Then
            tbPaginaMesas.Text = (NuloInteger(tbPaginaMesas.Text) - IncrementoMesas).ToString
            MontaBotoesMesas()
        End If
        If Modulo = "S" Then
            tbMesa.Focus()
        Else
            tbCodigoProduto.Focus()
        End If
    End Sub

    Private Sub PanelProdutos_Paint(sender As Object, e As PaintEventArgs) Handles PanelProdutos.Paint

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click
        TempoTela = TempoLimite
        Dim ID As Integer
        If Grid.Rows.Count <> 0 Then
            ID = NuloInteger(Grid.Item(0, Grid.CurrentRow.Index).Value)
            ProdutoSel = NuloString(Grid.Item(2, Grid.CurrentRow.Index).Value)
            IDFami = NuloInteger(Grid.Item(15, Grid.CurrentRow.Index).Value)
            'Dim i As Integer = Grid.CurrentRow.Index
            'Linha_Grid = i
            'Do While ID = NuloInteger(Grid.Item(1, i).Value)
            'Linha_Grid = i
            'Grid.Rows(i).Selected = True
            'ProdutoSel = NuloString(Grid.Item(3, i).Value)
            'IDFami = NuloInteger(Grid.Rows(i).Cells(15).Value)

            'i -= 1
            'If i < 0 Then Exit Do
            'Loop

        End If
        Grid.Refresh()
    End Sub

    Private Sub BtnPorCliente_Click(sender As Object, e As EventArgs) Handles btnPorCliente.Click

        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja limpar a venda sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                tbCodigoProduto.Focus()
                Exit Sub
            End If
            PedidoVenda = False
        End If
        LimpaVenda()


        fdlgBuscaMesaPorCliente.ShowDialog()


        VerificaMesa(tbMesa.Text)
        PedidoVenda = False
        VerificaMesaGrid()
        MontaProdutos(0)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Modulo = "S" Then
            If tbMesa.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar uma mesa/cartão"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesa.Focus()
                Exit Sub
            End If
        End If

        tbCodigoProduto.Text = ""


        fdlgPeloCodigo.ShowDialog()


        tbCodigoProduto.Focus()
        If CodigoProdutoBusca <> 0 Then
            tbCodigoProduto.Text = NuloString(CodigoProdutoBusca)
        End If
        SendKeys.Send("{ENTER}")
        If TerminalVenda = True Then
            SendKeys.Send("{ENTER}")
        End If
    End Sub

    Private Sub frmSalao_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        If e.KeyCode = 66 Then  'Ir para balcão
            tbMesa.Text = ""
            tbCodigoProduto.Text = ""
            tbQtde.Text = "1,000"
            If Modulo = "S" Then
                If Grid.Rows.Count <> 0 And PedidoVenda = True Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                    frm.ShowDialog()

                    If RetornoMsg = False Then
                        TimerTela.Start()
                        tbCodigoProduto.Focus()
                        Exit Sub
                    End If
                    IrBalcao()
                Else
                    IrBalcao()
                End If
            End If
        End If


        If e.KeyCode = 83 Then   ' Ir para salão
            tbMesa.Text = ""
            tbCodigoProduto.Text = ""
            tbQtde.Text = "1,000"
            If Modulo = "B" Then
                If Grid.Rows.Count <> 0 And PedidoVenda = True Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
                    frm.btnNao.Visible = True
                    frm.btnSim.Visible = True
                    frm.btnOK.Visible = False
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                    frm.ShowDialog()

                    If RetornoMsg = False Then
                        TimerTela.Start()
                        tbCodigoProduto.Focus()
                        Exit Sub
                    End If
                    IrSalao()
                Else
                    IrSalao()
                End If
            End If
        End If

        If e.KeyCode = 68 Then   ' Ir para delivery
            tbMesa.Text = ""
            tbCodigoProduto.Text = ""
            tbQtde.Text = "1,000"
            IrDelivery()
        End If

    End Sub

    Private Sub LbMesa_Click(sender As Object, e As EventArgs) Handles lbMesa.Click
        TempoTela = TempoLimite
        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then
                tbCodigoProduto.Focus()
                Exit Sub
            End If
        End If
        If tbMesa.Text = "" Then
            IDVenda = 0
            NumMesa = 0
        End If
        PedidoVenda = True
        CalculaTotais()
        AtualizaGrid()
        TravaVenda()

        If TerminalVenda = True Then
            Dim frm1 As fdlgAbreMesa = New fdlgAbreMesa
            frm1.tbPraca.Text = tbPraca.Text
            frm1.ShowDialog()
        Else
            fdlgAbreMesa.ShowDialog()
        End If


        If IDVenda = 0 Then
            tbMesa.Focus()
        Else
            If PedeMesa = True And MesaCartao = "" Then
                fdlgPedeMesa.ShowDialog()
            End If
        End If


        MontaProdutos(0)
    End Sub

    Private Sub tbQtde_KeyDown(sender As Object, e As KeyEventArgs) Handles tbQtde.KeyDown

        If e.KeyCode = 37 Then
            tbQtde.Text = "1,000"
            tbCodigoProduto.Focus()
        End If

    End Sub

    Private Sub tbCodigoProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCodigoProduto.KeyDown
        If e.KeyCode = 37 And Modulo = "S" Then
            tbCodigoProduto.Text = ""
            LBProduto.Text = ""
            tbQtde.Text = "1,000"
            tbMesa.Focus()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click

        If Grid.Rows.Count <> 0 And PedidoVenda = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja continuar sem confirmar o pedido"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then
                TimerTela.Start()
                tbCodigoProduto.Focus()
                Exit Sub
            Else
                LimpaVenda()
            End If
        End If

        'frmInicio.WindowState = FormWindowState.Minimized
        frmPrincipal.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub frmSalao_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        If (Me.WindowState = FormWindowState.Minimized) Then
            'frmInicio.WindowState = FormWindowState.Minimized
            frmPrincipal.WindowState = FormWindowState.Minimized
            Me.WindowState = FormWindowState.Minimized
        End If
        If (Me.WindowState = FormWindowState.Normal) Then
            'frmInicio.WindowState = FormWindowState.Normal
            'frmPrincipal.WindowState = FormWindowState.Normal
            'Me.WindowState = FormWindowState.Minimized
        End If

    End Sub
End Class