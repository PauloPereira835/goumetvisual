Imports System.Data.SqlClient
Imports System.IO

Public Class frmAppPedidos
    Dim IncoProdutos As Boolean = False
    Dim IncoPagtos As Boolean = False
    Private Sub CarregaProdutos(IDvda As String)

        Dim VlrUnit As Double = 0
        Dim IDMovto As Integer
        Dim IDCombo As Integer
        Dim ID As Integer = 0

        frmDelivery.DataSetGridDel.Clear()

        SqlStr = "Select tblAppVendas.IDVendaExterna, tblProdutos_Local.CodigoProduto, tblAppVendasMovto.Produto, tblAppVendasMovto.Qtd, tblAppVendasMovto.Venda, tblAppVendasMovto.Categoria, tblAppVendasMovto.Atendente, tblAppVendasMovto.HoraPedido, tblAppVendasMovto.IDGrupo, tblAppVendasMovto.Grupo, tblAppVendasMovto.IDProduto, tblAppVendasMovto.IDAppVendaMovto, tblAppVendasMovto.Excluido, tblAppVendasCombo.IDAppVendaCombo, tblAppVendasCombo.Produto As ProdutoCombo, tblAppVendasCombo.Qtd As QtdCombo, tblAppVendasCombo.Venda As VendaCombo, tblAppVendasCombo.IDGrupo As IDGrupoCombo, tblAppVendasCombo.Grupo AS GrupoCombo, tblAppVendasCombo.Categoria As CategoriaCombo, tblAppVendasCombo.IDProduto AS IDProdutoCombo "
        SqlStr += "From tblAppVendasMovto INNER Join tblAppVendas On tblAppVendasMovto.IDVendaExterna = tblAppVendas.IDVendaExterna LEFT OUTER Join tblAppVendasCombo On tblAppVendasMovto.IDAppVendaMovto = tblAppVendasCombo.IDAppVendaMovto LEFT OUTER Join tblAppVendasComent On tblAppVendasMovto.IDAppVendaMovto = tblAppVendasComent.IDAppVendaMovto LEFT OUTER Join tblProdutos_Local On tblAppVendasMovto.IDProduto = tblProdutos_Local.IDProduto "
        SqlStr += "Group By tblAppVendas.IDVendaExterna, tblProdutos_Local.CodigoProduto, tblAppVendasMovto.Produto, tblAppVendasMovto.Qtd, tblAppVendasMovto.Venda, tblAppVendasMovto.Categoria, tblAppVendasMovto.Atendente, tblAppVendasMovto.HoraPedido, tblAppVendasMovto.IDGrupo, tblAppVendasMovto.Grupo, tblAppVendasMovto.IDProduto, tblAppVendasMovto.IDAppVendaMovto, tblAppVendasCombo.IDAppVendaCombo, tblAppVendasCombo.Produto, tblAppVendasCombo.Qtd, tblAppVendasCombo.Venda, tblAppVendasCombo.IDGrupo, tblAppVendasCombo.Grupo, tblAppVendasCombo.Categoria, tblAppVendasCombo.IDProduto, tblAppVendasMovto.Excluido "
        SqlStr += "HAVING (tblAppVendas.IDVendaExterna = '" & IDvda & "') "
        SqlStr += "ORDER BY tblAppVendas.IDVendaExterna, tblAppVendasMovto.IDAppVendaMovto, tblAppVendasCombo.IDAppVendaCombo"

        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            If IsDBNull(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo")) Then
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1
                Dim nova_linha As DataRow = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto")), ID, False, NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))}
                frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha)

                ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                InsereComent("M", NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto")), 0, ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))
            Else
                ' Pedido ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ID += 1
                Dim nova_linha As DataRow = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {ID, NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloString(ds.Tables("Vendas").Rows(i).Item("Produto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), ID, "P", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"), NuloString(ds.Tables("Vendas").Rows(i).Item("Atendente")), NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("Grupo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProduto")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto")), ID, False, NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda"))}
                frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha)

                IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto"))
                While IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto"))
                    'ID += 1
                    Dim nova_linha_PCM1 As DataRow = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                    nova_linha_PCM1.ItemArray = New Object() {ID, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo")), String.Empty, ID, "PC", NuloInteger(ds.Tables("Vendas").Rows(i).Item("CodigoProduto")), 0, 0, String.Empty, 0, String.Empty, String.Empty, NuloString(ds.Tables("Vendas").Rows(i).Item("HoraPedido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDGrupoCombo")), 0, 0, 0, NuloString(ds.Tables("Vendas").Rows(i).Item("GrupoCombo")), NuloString(ds.Tables("Vendas").Rows(i).Item("Categoria")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDProdutoCombo")), NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")), NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto")), ID, False, 0}
                    frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linha_PCM1)

                    IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo"))
                    While IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo"))
                        ' Comentário ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        InsereComent("MC", 0, NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo")), ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))

                        If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                        If IDCombo = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDAppVendaCombo")) Then
                            i += 1
                        Else
                            Exit While
                        End If

                    End While
                    If i + 1 > ds.Tables("Vendas").Rows.Count - 1 Then Exit While
                    If IDMovto = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDAppVendaMovto")) Then
                        i += 1
                    Else
                        Exit While
                    End If
                End While
                InsereComent("M", NuloInteger(IDMovto), 0, ID, 0, NuloBoolean(ds.Tables("Vendas").Rows(i).Item("Excluido")))
            End If
        Next

        frmDelivery.GridDel.Refresh()
        LinhaGrid()
        'AtualizaGridDelivery()
        StiloGridDelivery()

        If frmDelivery.DataSetGridDel.Tables(0).Rows.Count <> 0 Then
            frmDelivery.GridDel.Rows(0).Selected = False
        End If

        CalculaTotaisDelivery()




    End Sub

    Private Sub InsereComent(Status As String, IDMovto As Integer, IDcombo As Integer, IDgrid As Integer, IDFam As Integer, Excluido As Boolean)

        Dim conC As New SqlConnection()
        Dim Texto As String
        strSql = "Select IDAppVendaMovto, IDAppVendaCombo, Coment "
        strSql += "From tblAppVendasComent "
        If IDMovto > 0 Then
            strSql += "Where (IDAppVendaMovto = " & IDMovto & ")"
            Texto = ">>>>"
        Else
            strSql += "Where (IDAppVendaCombo = " & IDcombo & ")"
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
                Dim nova_linhaComent As DataRow = frmDelivery.DataSetGridDel.Tables(0).NewRow()
                nova_linhaComent.ItemArray = New Object() {IDgrid, Texto, drC.Item("Coment"), String.Empty, IDgrid, Status, 0, 0, 0, String.Empty, 0, String.Empty, frmPrincipal.Garcon.Text, Date.Today, 0, IDFam, 0, 0, "", 0, 0, Excluido, IDMovto, IDgrid, False}
                frmDelivery.DataSetGridDel.Tables(0).Rows.Add(nova_linhaComent)
            Loop
        End If
        drC.Close()
        cmdC.Dispose()
        conC.Dispose()
        conC.Close()

    End Sub
    Private Sub CarregaDadosVenda(IDvda As String)

        SqlStr = "Select tblAppVendas.IDVendaExterna, tblAppVendas.NumVenda, tblAppVendas.NumVendaD, tblAppVendas.NumMesa, tblAppVendas.DataVenda, tblAppVendas.PercDesconto, tblAppVendas.PercServico, tblAppVendas.QtdPessoas, tblAppVendas.FlagFechada, tblAppVendas.HoraAbertura, tblAppVendas.StatusVenda, tblAppVendas.Caixa, tblAppVendas.Atendente, tblAppVendas.Enviado, tblAppVendas.Excluido, tblAppVendas.IDFuncionarioAtendente, tblAppVendas.IDCliente, tblAppVendas.NomeCliente, tblAppVendas.IDRuaEntrega, tblAppVendas.CepEntrega, tblAppVendas.NumeroEntrega, tblAppVendas.AreaEntrega, tblAppVendas.ComplementoEntrega, tblAppVendas.ReferenciaEntrega, tblAppVendas.ComentProducao, tblAppVendas.ComentExpedicao, tblAppVendas.Troco, tblAppVendas.TaxaEntrega, tblAppVendas.Desconto, tblAppVendas.TotalProdutos, tblAppVendas.TotalVenda, tblAppVendas.Caixinha, tblAppVendas.PreNota, tblAppVendas.PedidoProg, tblAppVendas.PedidoProgAutomatico, tblAppVendas.PedidoProgEnvioAs, tblAppVendas.PedidoProgEnviado, tblAppVendas.TipoLancto, tblAppVendas.CpfCnpj, tblAppVendas.App, tblAppVendas.AppConfirmado, tblRuas.Logradouro, tblAppVendasPagto.IDFormaPagto, tblRuas.Bairro, tblClientes.Tel1, tblClientes.DDD1, tblAppVendasPagto.Descricao, tblAppVendasPagto.ValorPago, tblAppVendas.IDReferencia, tblAppVendas.IDClienteExterno, tblAppVendas.LogradouroEntrega "
        SqlStr += "From tblAppVendas LEFT OUTER Join tblRuas On tblAppVendas.IDRuaEntrega = tblRuas.IDRua LEFT OUTER Join tblAppVendasPagto On tblAppVendas.IDVendaExterna = tblAppVendasPagto.IDVendaExterna LEFT OUTER Join tblClientes On tblAppVendas.IDCliente = tblClientes.IDCliente "
        SqlStr += "Where (tblAppVendas.IDVendaExterna = '" & IDvda & "')"

        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Dados")

        Dim IDcli As Integer = 0
        Dim IDRuaEntrega As Integer = 0
        Dim RuaEntrega As String = ""
        Dim CepEntrega As String = ""
        Dim AreaEntrega As String = ""
        Dim NumeroEntrega As String = ""
        Dim ComplementoEntrega As String = ""
        Dim ReferenciaEntrega As String = ""
        Dim BairroEntrega As String = ""
        Dim TxEntrega As Decimal = 0
        Dim Caixinha As Decimal = 0
        Dim Troco As Decimal = 0
        Dim PercDesconto As Decimal = 0
        Dim Desconto As Decimal = 0
        Dim ComentProducao As String = ""
        Dim ComentExpedicao As String = ""
        Dim IDFormPagto As Integer
        Dim DescricaoPagto As String = ""
        Dim VlrPagto As Decimal = 0
        Dim RuaPagto As String = ""
        Dim cepPagto As String = ""
        Dim numeroPagto As String = ""
        Dim bairroPagto As String = ""
        Dim complementoPagto As String = ""
        Dim PagtoDiferente As Boolean

        If ds.Tables("Dados").Rows.Count > 0 Then
            IDcli = NuloInteger(ds.Tables("Dados").Rows(0).Item("IDCliente"))
            IDRuaEntrega = NuloInteger(ds.Tables("Dados").Rows(0).Item("IDRuaEntrega"))
            IDFormPagto = NuloInteger(ds.Tables("Dados").Rows(0).Item("IDFormaPagto"))
            DescricaoPagto = NuloString(ds.Tables("Dados").Rows(0).Item("Descricao"))
            VlrPagto = NuloDecimal(ds.Tables("Dados").Rows(0).Item("ValorPago"))
            RuaEntrega = UCase(NuloString(ds.Tables("Dados").Rows(0).Item("LogradouroEntrega")))
            CepEntrega = NuloString(ds.Tables("Dados").Rows(0).Item("CepEntrega"))
            AreaEntrega = NuloString(ds.Tables("Dados").Rows(0).Item("AreaEntrega"))
            NumeroEntrega = Strings.Left(NuloString(ds.Tables("Dados").Rows(0).Item("NumeroENtrega")), 50)
            ComplementoEntrega = NuloString(ds.Tables("Dados").Rows(0).Item("ComplementoEntrega"))
            ReferenciaEntrega = NuloString(ds.Tables("Dados").Rows(0).Item("ReferenciaEntrega"))
            BairroEntrega = NuloString(ds.Tables("Dados").Rows(0).Item("Bairro"))
            frmDelivery.chkTipoLancto.Checked = NuloBoolean(ds.Tables("Dados").Rows(0).Item("TipoLancto"))
            frmDelivery.tbCpfCnpj.Text = NuloString(ds.Tables("Dados").Rows(0).Item("CpfCnpj"))
            frmDelivery.tbApp.Text = NuloString(ds.Tables("Dados").Rows(0).Item("App"))
            frmDelivery.tbIDReferencia.Text = NuloString(ds.Tables("Dados").Rows(0).Item("IDReferencia"))
            frmDelivery.tbIDClienteExterno.Text = NuloString(ds.Tables("Dados").Rows(0).Item("IDClienteExterno"))

            ComentExpedicao = "** " & Grid.Item(3, Grid.CurrentRow.Index).Value & " ** " & NuloString(ds.Tables("Dados").Rows(0).Item("IDReferencia"))
            ComentProducao = "** " & Grid.Item(3, Grid.CurrentRow.Index).Value & " ** " & NuloString(ds.Tables("Dados").Rows(0).Item("IDReferencia"))

            RuaPagto = NuloString(ds.Tables("Dados").Rows(0).Item("Logradouro"))
            cepPagto = NuloString(ds.Tables("Dados").Rows(0).Item("CepEntrega"))
            numeroPagto = NuloString(ds.Tables("Dados").Rows(0).Item("NumeroEntrega"))
            complementoPagto = NuloString(ds.Tables("Dados").Rows(0).Item("ComplementoEntrega"))
            bairroPagto = NuloString(ds.Tables("Dados").Rows(0).Item("Bairro"))
            PagtoDiferente = False

            TxEntrega = NuloDecimal(ds.Tables("Dados").Rows(0).Item("TaxaEntrega"))
            If NuloDecimal(ds.Tables("Dados").Rows(0).Item("Troco")) <> NuloDecimal(ds.Tables("Dados").Rows(0).Item("TotalVenda")) Then
                Troco = NuloDecimal(ds.Tables("Dados").Rows(0).Item("Troco"))
            Else
                Troco = 0
            End If
            PercDesconto = NuloDecimal(ds.Tables("Dados").Rows(0).Item("PercDesconto"))
            Desconto = NuloDecimal(ds.Tables("Dados").Rows(0).Item("Desconto"))
            Caixinha = NuloDecimal(ds.Tables("Dados").Rows(0).Item("Caixinha"))

            'frmDelivery.tbPedido.Text = NuloInteger(ds.Tables("Dados").Rows(i).Item("NumVendaD"))
            frmDelivery.tbPedido.Text = ""
            frmDelivery.tbPedidoProgEnviado.Text = NuloBoolean(ds.Tables("Dados").Rows(0).Item("PedidoProgEnviado"))

            frmDelivery.chkPedidoProg.Checked = False
            frmDelivery.lbPedidoProgEnvioAs.Text = ""


            If NuloString(ds.Tables("Dados").Rows(0).Item("Tel1")) <> "" Then
                frmDelivery.tbBuscaCliente.Text = NuloString(ds.Tables("Dados").Rows(0).Item("Tel1"))
                frmDelivery.tbDDD.Text = NuloString(ds.Tables("Dados").Rows(0).Item("DDD1"))
            Else
                frmDelivery.tbBuscaCliente.Text = ""
                frmDelivery.tbDDD.Text = ""
            End If

            frmDelivery.AchaCliente(NuloInteger(IDcli))
        End If

        frmDelivery.PanelPedidoProg.Visible = False

        frmDelivery.tbIDVenda.Text = 0
        frmDelivery.tbIDVendaExterna.Text = IDvda
        frmDelivery.tbIDRuaEntrega.Text = IDRuaEntrega
        frmDelivery.tbLogradouroEntrega.Text = RuaEntrega
        frmDelivery.tbNumeroEntrega.Text = NumeroEntrega
        frmDelivery.tbCEPEntrega.Text = CepEntrega
        frmDelivery.tbAreaEntrega.Text = AreaEntrega
        frmDelivery.lbTaxaEntregaEntrega.Text = Format(NuloDecimal(TxEntrega), "#0.00")
        frmDelivery.txtServico.Text = Format(NuloDecimal(TxEntrega), "#0.00")
        frmDelivery.tbComplementoEntrega.Text = ComplementoEntrega
        frmDelivery.tbBairroEntrega.Text = BairroEntrega
        frmDelivery.tbReferenciaEntrega.Text = ReferenciaEntrega

        frmDelivery.tbRuaPagto.Text = RuaPagto
        frmDelivery.tbNumeroPagto.Text = numeroPagto
        frmDelivery.tbCepPagto.Text = cepPagto
        frmDelivery.tbComplementoPagto.Text = complementoPagto
        frmDelivery.tbBairroPagto.Text = bairroPagto
        frmDelivery.tbEnderecoEntregaDiferente.Text = PagtoDiferente
        frmDelivery.lbEnderecoPagto.Text = "Endereço de cobrança: " & frmDelivery.tbRuaPagto.Text & ", " & frmDelivery.tbNumeroPagto.Text & "  " & frmDelivery.tbComplementoPagto.Text & " " & frmDelivery.tbBairroPagto.Text & "  " & frmDelivery.tbCepPagto.Text

        frmDelivery.tbCaixinha.Text = Format(NuloDecimal(Caixinha), "#0.00")
        frmDelivery.lbCaixinha.Text = Format(NuloDecimal(Caixinha), "#0.00")
        frmDelivery.tbTroco.Text = Format(NuloDecimal(Troco), "#0.00")
        'frmDelivery.tbDescontoPerc.Text = Format(NuloDecimal(PercDesconto), "#0.000")
        frmDelivery.tbDescontoPerc.Text = Format(NuloDecimal(0), "#0.000")
        frmDelivery.tbDescontoValor.Text = Format(NuloDecimal(Desconto), "#0.000")
        frmDelivery.tbDescontoValor.Refresh()
        frmDelivery.tbComentExpedicao.Text = NuloString(ComentExpedicao)
        frmDelivery.tbComentProducao.Text = NuloString(ComentProducao)

        ' frmDelivery.PreencheListaPagto(IDvda)

        Dim item_ As ListViewItem
        frmDelivery.tbTotalPagto.Text = 0
        frmDelivery.lstPagtosVenda.Items.Clear()
        If NuloInteger(IDFormPagto) <> 0 Then
            item_ = frmDelivery.lstPagtosVenda.Items.Add(0)
            item_.SubItems.Add(NuloInteger(IDFormPagto))
            item_.SubItems.Add(NuloString(DescricaoPagto))
            item_.SubItems.Add(Format(VlrPagto, "#0.00"))
            frmDelivery.tbTotalPagto.Text = VlrPagto
        End If

        frmDelivery.tbCaixinha.Text = NuloDecimal(frmDelivery.lbCaixinha.Text)
        frmDelivery.lbCaixinha.Text = Format(NuloDecimal(frmDelivery.lbCaixinha.Text), "#0.00")

        CalculaTotaisDelivery()
    End Sub

    Public Sub MontaGridProdutosBusca(busca As String)

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        Dim item As ListViewItem

        lstProdutos.Items.Clear()

        SqlStr = "Select  IDProduto, CodigoProduto, Produto, Venda "
        SqlStr += "From tblProdutos_Local "
        If NuloString(busca) <> "" Then
            If Not IsNumeric(busca) Then
                SqlStr += "Where(Produto like '%" & busca & "%') "
            Else
                SqlStr += "Where(CodigoProduto = " & busca & ") "
            End If
        End If
        SqlStr += "Order By tblProdutos_Local.Produto"


        cmd.CommandText = SqlStr

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While (dr.Read())
                item = lstProdutos.Items.Add(NuloString(dr.Item("IDProduto")))
                item.SubItems.Add(NuloString(dr.Item("CodigoProduto")))
                item.SubItems.Add(NuloString(dr.Item("Produto")))
                item.SubItems.Add(NuloDecimal(dr.Item("Venda")))
            End While

            lstProdutos.Update()
            lstProdutos.EndUpdate()

        End If
        dr.Close()
        cmd.Dispose()
        con.Close()
        con.Dispose()
        Colorir()

    End Sub
    Public Sub MontaGridProdutos(IDvdaApp As String)
        Dim item As ListViewItem

        lstDescricao.Items.Clear()

        SqlStr = "Select tblAppVendas.IDVendaExterna, tblAppVendas.NumVenda, tblAppVendasMovto.IDAppVendaMovto, tblAppVendasMovto.CodigoProdutoExterno, tblProdutos_Local.CodigoProduto, tblAppVendasMovto.Produto, tblAppVendasMovto.Qtd, tblAppVendasMovto.Venda, tblAppVendasCombo.IDAppVendaCombo, tblAppVendasCombo.Produto As ProdutoCombo, tblAppVendasCombo.Venda As VendaCombo, tblAppVendasCombo.CodigoProdutoExterno AS CodigoProdutoExternoCombo, tblAppVendasCombo.Qtd As QtdCombo, tblProdutos_Local_1.CodigoProduto As CodigoProdutoCombo, tblAppVendasCombo.IDProduto AS IDProdutoCombo, tblAppVendasCombo.CodigoProdutoExterno AS CodigoProdutoExternoCombo "
        SqlStr += "From tblProdutos_Local As tblProdutos_Local_1 RIGHT OUTER Join tblAppVendasCombo On tblProdutos_Local_1.IDProduto = tblAppVendasCombo.IDProduto RIGHT OUTER Join tblAppVendas INNER Join tblAppVendasMovto On tblAppVendas.IDVendaExterna = tblAppVendasMovto.IDVendaExterna LEFT OUTER Join tblProdutos_Local On tblAppVendasMovto.IDProduto = tblProdutos_Local.IDProduto ON tblAppVendasCombo.IDAppVendaMovto = tblAppVendasMovto.IDAppVendaMovto "
        SqlStr += "Where(tblAppVendas.IDVendaExterna = '" & IDvdaApp & "') "
        SqlStr += "ORDER BY tblAppVendasMovto.Produto, tblAppVendasMovto.IDAppVendaMovto, tblProdutos_Local.CodigoProduto"


        Dim dap = New SqlDataAdapter(SqlStr, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        Dim IDmovto As Integer = 0
        Dim Cod As String
        Dim CodEx As String
        Dim Prod As String
        Dim Qtd As String
        Dim Venda As String
        Dim TotStr As String
        Dim Total As Decimal
        Dim TotalAcm As Decimal = 0
        IncoProdutos = False
        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
            IDmovto = NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto"))

            Cod = NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProduto"))
            CodEx = NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExterno"))
            Prod = NuloString(ds.Tables("Vendas").Rows(i).Item("Produto"))
            Qtd = NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd")), "#0.000"))
            Venda = NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")), "#0.00"))
            Total = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Venda")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtd"))
            TotalAcm += Total
            TotStr = Format(Total, "#0.00")

            item = lstDescricao.Items.Add(Cod)
            item.SubItems.Add(Prod)
            item.SubItems.Add(Qtd)
            item.SubItems.Add(Venda)
            item.SubItems.Add(IDmovto)
            item.SubItems.Add("")
            item.SubItems.Add(TotStr)
            item.SubItems.Add(NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExterno")))

            SqlStr = "Select IDVendaExterna, IDAppVendaMovto, IDAppVendaCombo, Coment, IDProdutoVinculado, CodigoProdutoExterno "
            SqlStr += "From tblAppVendasComent "
            SqlStr += "Where (IDAppVendaMovto = '" & IDmovto & "') AND (IDAppVendaCombo = 0)"

            Dim dapC = New SqlDataAdapter(SqlStr, strCon)
            dapC.SelectCommand.CommandType = CommandType.Text
            Dim dsC As New DataSet()
            dapC.Fill(dsC, "Vendas")
            For ic As Integer = 0 To dsC.Tables("Vendas").Rows.Count - 1
                item = lstDescricao.Items.Add("")
                item.SubItems.Add(">>>>>> " & NuloString(dsC.Tables("Vendas").Rows(ic).Item("Coment")))
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add(NuloInteger(dsC.Tables("Vendas").Rows(ic).Item("IDAppVendaMovto")))
                item.SubItems.Add("0")
                item.SubItems.Add("")
                item.SubItems.Add(NuloString(dsC.Tables("Vendas").Rows(ic).Item("CodigoProdutoExterno")))
            Next


            If NuloString(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo")) <> "" Then
                SqlStr = "Select IDProduto, CodigoProduto, CodigoProdutoExterno, Aplicativo From tblProdutosExterno "
                SqlStr += "Where (CodigoProdutoExterno = '" & NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExternoCombo")) & "') AND (Aplicativo = '" & Grid.Item(3, Grid.CurrentRow.Index).Value & "')"
                'Cod = NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoCombo"))

                Cod = NuloString(PegaValorCampo("CodigoProduto", SqlStr, strConServer))

                'If NuloString(PegaValorCampo("IDProduto", SqlStr, strCon)) <> "ERRO" Then
                'Cod = NuloString(PegaValorCampo("IDProduto", SqlStr, strCon))
                'Else
                'Cod = ""
                'End If

                CodEx = NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExternoCombo"))
                Prod = "  - " & NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo"))
                Qtd = NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("QtdCombo")), "#0.000"))
                Venda = NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaCombo")), "#0.00"))
                Total = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaCombo")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("QtdCombo"))
                'TotalAcm += Total
                TotStr = ""

                item = lstDescricao.Items.Add(Cod)
                item.SubItems.Add(Prod)
                item.SubItems.Add(Qtd)
                item.SubItems.Add(Venda)
                item.SubItems.Add(IDmovto)
                item.SubItems.Add(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo")))
                item.SubItems.Add(TotStr)
                item.SubItems.Add(NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExternoCombo")))



                SqlStr = "Select IDVendaExterna, IDAppVendaMovto, IDAppVendaCombo, Coment, IDProdutoVinculado, CodigoProdutoExterno "
                SqlStr += "From tblAppVendasComent "
                SqlStr += "Where (IDVendaExterna = '" & IDvdaApp & "') AND (IDAppVendaCombo = " & ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo") & ")"

                Dim dapCC1 = New SqlDataAdapter(SqlStr, strCon)
                dapCC1.SelectCommand.CommandType = CommandType.Text
                Dim dsCC1 As New DataSet()
                dapCC1.Fill(dsCC1, "Vendas")
                For icc1 As Integer = 0 To dsCC1.Tables("Vendas").Rows.Count - 1
                    item = lstDescricao.Items.Add("")
                    item.SubItems.Add("   ---> " & NuloString(dsCC1.Tables("Vendas").Rows(icc1).Item("Coment")))
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("0")
                    item.SubItems.Add(NuloInteger(ds.Tables("Vendas").Rows(icc1).Item("IDAppVendaCombo")))
                    item.SubItems.Add("")
                    item.SubItems.Add(NuloString(dsCC1.Tables("Vendas").Rows(icc1).Item("CodigoProdutoExterno")))
                Next
            End If
            If (i + 1) <= (ds.Tables("Vendas").Rows.Count - 1) Then
                While IDmovto = NuloInteger(ds.Tables("Vendas").Rows(i + 1).Item("IDAppVendaMovto")) And NuloString(ds.Tables("Vendas").Rows(i + 1).Item("IDAppVendaCombo")) <> ""
                    i += 1
                    Cod = NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoCombo"))
                    CodEx = NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExternoCombo"))
                    Prod = "  - " & NuloString(ds.Tables("Vendas").Rows(i).Item("ProdutoCombo"))
                    Qtd = NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("QtdCombo")), "#0.000"))
                    Venda = NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaCombo")), "#0.00"))
                    Total = NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaCombo")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("QtdCombo"))
                    'TotalAcm += Total
                    TotStr = ""

                    item = lstDescricao.Items.Add(Cod)
                    item.SubItems.Add(Prod)
                    item.SubItems.Add(Qtd)
                    item.SubItems.Add(Venda)
                    item.SubItems.Add(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaMovto")))
                    item.SubItems.Add(NuloInteger(ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo")))
                    item.SubItems.Add(TotStr)
                    item.SubItems.Add(NuloString(ds.Tables("Vendas").Rows(i).Item("CodigoProdutoExternoCombo")))


                    SqlStr = "Select IDVendaExterna, IDAppVendaMovto, IDAppVendaCombo, Coment, IDProdutoVinculado, CodigoProdutoExterno "
                    SqlStr += "From tblAppVendasComent "
                    SqlStr += "Where (IDVendaExterna = '" & IDvdaApp & "') AND (IDAppVendaCombo = " & ds.Tables("Vendas").Rows(i).Item("IDAppVendaCombo") & ")"

                    Dim dapCC2 = New SqlDataAdapter(SqlStr, strCon)
                    dapCC2.SelectCommand.CommandType = CommandType.Text
                    Dim dsCC2 As New DataSet()
                    dapCC2.Fill(dsCC2, "Vendas")
                    For icc2 As Integer = 0 To dsCC2.Tables("Vendas").Rows.Count - 1
                        item = lstDescricao.Items.Add("")
                        item.SubItems.Add("   ---> " & NuloString(dsCC2.Tables("Vendas").Rows(icc2).Item("Coment")))
                        item.SubItems.Add("")
                        item.SubItems.Add("")
                        item.SubItems.Add("0")
                        item.SubItems.Add(NuloInteger(ds.Tables("Vendas").Rows(icc2).Item("IDAppVendaCombo")))
                        item.SubItems.Add("")
                        item.SubItems.Add(NuloString(dsCC2.Tables("Vendas").Rows(icc2).Item("CodigoProdutoExterno")))
                    Next


                    If (i + 1) > (ds.Tables("Vendas").Rows.Count - 1) Then Exit While
                End While
            End If
        Next

        lstDescricao.Update()
        lstDescricao.EndUpdate()

        lbTotalProd.Text = NuloString(Format(NuloDecimal(TotalAcm), "#0.00"))

        Colorir()

    End Sub
    Private Sub Colorir()

        For i As Integer = 0 To lstDescricao.Items.Count - 1
            If NuloString(lstDescricao.Items(i).SubItems(0).Text) = "" And Strings.Left(NuloString(lstDescricao.Items(i).SubItems(1).Text), 8) <> "   ---> " And Strings.Left(NuloString(lstDescricao.Items(i).SubItems(1).Text), 7) <> ">>>>>> " Then
                lstDescricao.Items(i).ForeColor = Color.Red
                IncoProdutos = True
            End If
        Next
    End Sub
    Private Sub MontaPedido(IDpedido As String)
        ' If IDVenda = 0 Then Exit Sub

        Dim con As New SqlConnection()
        Dim lngFile As Integer = FreeFile()

        Dim VlrPro As Decimal = 0
        Dim VlrSer As Decimal = 0
        con.ConnectionString = strCon
1:


        strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendas.DataVenda, tblAppVendas.FlagFechada, tblAppVendas.HoraAbertura, tblAppVendas.StatusVenda, tblAppVendas.NomeCliente, tblAppVendas.CepEntrega, tblAppVendas.NumeroEntrega, tblAppVendas.ComplementoEntrega, tblAppVendas.ReferenciaEntrega, tblAppVendas.ComentProducao, tblAppVendas.ComentExpedicao, tblAppVendas.Troco, tblAppVendas.TaxaEntrega, tblAppVendas.Desconto, tblAppVendas.TotalProdutos, tblAppVendas.TotalVenda, tblAppVendas.Caixinha, tblAppVendas.PedidoProg, tblAppVendas.CpfCnpj, tblRuas.Logradouro, tblAppVendasPagto.Descricao, tblAppVendasPagto.ValorPago, tblRuas.Bairro, tblAppVendas.App, tblClientes.Tel1, tblClientes.DDD1, tblAppVendas.IDReferencia "
        strSql += "From tblAppVendas INNER JOIN tblRuas ON tblAppVendas.IDRuaEntrega = tblRuas.IDRua INNER JOIN tblAppVendasPagto ON tblAppVendas.IDVendaExterna = tblAppVendasPagto.IDVendaExterna INNER JOIN tblClientes ON tblAppVendas.IDCliente = tblClientes.IDCliente "



        strSql = "Select tblAppVendas.IDVendaExterna, tblAppVendas.DataVenda, tblAppVendas.FlagFechada, tblAppVendas.HoraAbertura, tblAppVendas.StatusVenda, tblAppVendas.NomeCliente, tblAppVendas.CepEntrega, tblAppVendas.NumeroEntrega, tblAppVendas.ComplementoEntrega, tblAppVendas.ReferenciaEntrega, tblAppVendas.ComentProducao, tblAppVendas.ComentExpedicao, tblAppVendas.Troco, tblAppVendas.TaxaEntrega, tblAppVendas.Desconto, tblAppVendas.TotalProdutos, tblAppVendas.TotalVenda, tblAppVendas.Caixinha, tblAppVendas.PedidoProg, tblAppVendas.CpfCnpj, tblRuas.Logradouro, tblAppVendasPagto.Descricao, tblAppVendasPagto.ValorPago, tblRuas.Bairro, tblAppVendas.App, tblClientes.Tel1, tblClientes.DDD1, tblAppVendas.IDReferencia "
        strSql += "From tblAppVendas LEFT OUTER Join tblAppVendasPagto On tblAppVendas.IDVendaExterna = tblAppVendasPagto.IDVendaExterna LEFT OUTER Join tblClientes On tblAppVendas.IDCliente = tblClientes.IDCliente LEFT OUTER Join tblRuas On tblAppVendas.IDRuaEntrega = tblRuas.IDRua "
        strSql += "Where (tblAppVendas.IDVendaExterna = '" & IDpedido & "')"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Vendas")

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\pedido.txt", CType(FileMode.Create, OpenMode))

        For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1

            PrintLine(lngFile, " " & NuloString(ds.Tables("Vendas").Rows(0).Item("NomeCliente")))
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "Telefone   : " & NuloString(ds.Tables("Vendas").Rows(0).Item("DDD1")) & " " & NuloString(ds.Tables("Vendas").Rows(0).Item("Tel1")))
            PrintLine(lngFile, "Cpf/CNPJ   : " & NuloString(ds.Tables("Vendas").Rows(0).Item("CpfCnpj")))
            PrintLine(lngFile, "Endereco   : " & NuloString(ds.Tables("Vendas").Rows(0).Item("Logradouro")))
            PrintLine(lngFile, "Numero     : " & NuloString(ds.Tables("Vendas").Rows(0).Item("NumeroEntrega")) & "  " & NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega")))
            PrintLine(lngFile, "Complemento: " & NuloString(ds.Tables("Vendas").Rows(0).Item("ComplementoEntrega")))
            PrintLine(lngFile, "Bairro     : " & NuloString(ds.Tables("Vendas").Rows(0).Item("Bairro")))
            PrintLine(lngFile, "Referencia : " & NuloString(ds.Tables("Vendas").Rows(0).Item("ReferenciaEntrega")))
            PrintLine(lngFile, "------------------------------------------")
            PrintLine(lngFile, "Num pedido : " & NuloString(ds.Tables("Vendas").Rows(0).Item("IDReferencia")))
            PrintLine(lngFile, "Aplicativo : " & NuloString(ds.Tables("Vendas").Rows(0).Item("App")))
            PrintLine(lngFile, "Data/Hora  : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("DataVenda"), "dd/MM/yyyy hh:mm:ss")))
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Valor     : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("TotalVenda"), "#0.00")))
            PrintLine(lngFile, "Tx entrega: " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("TaxaEntrega"), "#0.00")))
            PrintLine(lngFile, "Desconto  : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("Desconto"), "#0.00")))
            PrintLine(lngFile, "Caixinha  : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("Caixinha"), "#0.00")))
            PrintLine(lngFile, "Troco     : " & NuloString(Format(ds.Tables("Vendas").Rows(0).Item("Troco"), "#0.00")))
            PrintLine(lngFile, "==========================================")
            PrintLine(lngFile, "Pagamento : " & NuloString(ds.Tables("Vendas").Rows(0).Item("Descricao")))
            PrintLine(lngFile, "Valor     : " & NuloString(Format(NuloDecimal(ds.Tables("Vendas").Rows(0).Item("ValorPago")), "#0.00")))
            PrintLine(lngFile, "------------------------------------------")
        Next
        FileClose(lngFile)
        ds.Dispose()
        dap.Dispose()
        con.Dispose()
        con.Close()



        'verifica se o nome do arquivo foi informado
        Dim caminho As String = Application.StartupPath & "\Impressao\pedido.txt"
        'verifica se o arquivo existe
        If File.Exists(caminho) Then
            Using tr As TextReader = New StreamReader(caminho)
                'tbDescricao.Text = tr.ReadToEnd()
                tbDescricao.Text = tr.ReadToEnd()
            End Using
        Else
            MessageBox.Show("Arquivo não encontrado ", "Nome do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub PreencheListaPedidos()
        'Dim item As ListViewItem
        Dim Qtd As Integer = 0


        strSql = "Select IDVendaExterna, NumVendaD, App, AppConfirmado, Excluido, IDReferencia "
        strSql += "From tblAppVendas "
        If chkConfirmados.Checked = True Then
            strSql += "Where AppConfirmado=1 and Excluido=0 and IDReferencia like '%" & tbBuscaPedido.Text & "%' "
            strSql += "Order By NumVendaD"
        Else
            If chkRejeitado.Checked = True Then
                strSql += "Where Excluido=1 AND IDReferencia like '%" & tbBuscaPedido.Text & "%' "
                strSql += "Order By NumVendaD"
            Else
                If chkTodos.Checked = True Then
                    strSql += "Where IDReferencia like '%" & tbBuscaPedido.Text & "%' "
                    strSql += "Order By App, IDVendaExterna"
                Else
                    strSql += "Where AppConfirmado=0 and Excluido=0  AND IDReferencia like '%" & tbBuscaPedido.Text & "%' "
                    strSql += "Order By IDVendaExterna"
                End If
            End If
        End If

        Dim status As String
        Dim conA As New SqlConnection(strCon)
        conA.Open()
        Dim cmdA As New SqlCommand(strSql, conA)
        cmdA.CommandType = CommandType.Text

        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)


        DataSetGrid.Tables(0).Clear()
        Grid.Refresh()

        Dim Nvenda As String
        If drA.HasRows Then
            While drA.Read()
                If NuloInteger(drA.Item("NumVendaD")) <> 0 Then
                    Nvenda = NuloString(drA.Item("NumVendaD"))
                Else
                    Nvenda = ""
                End If
                If NuloBoolean(drA.Item("Excluido")) = True Then
                    status = "REJEITADO"
                Else
                    If NuloBoolean(drA.Item("AppConfirmado")) = True Then
                        status = "CONFIRMADO"
                    Else
                        status = ""
                    End If
                End If
                Dim nova_linha As DataRow = DataSetGrid.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() {drA.Item("IDVendaExterna"), NuloString(Nvenda), drA.Item("App"), drA.Item("IDReferencia"), status}
                DataSetGrid.Tables(0).Rows.Add(nova_linha)
                Qtd += 1
            End While
        End If
        lbQtde.Text = "Qtde. de pedidos: " & Qtd
        drA.Close()
        cmdA.Dispose()
        conA.Dispose()
        conA.Close()

        CarregaImagem()

    End Sub
    Private Sub CarregaImagem()
        Dim img As Image

        'If GridDel.Rows.Count > 0 Then
        'If NuloBoolean(GridDel.Item(24, GridDel.CurrentRow.Index).Value) = True Then
        'btnQtde.Enabled = False
        'btnComent.Enabled = False
        'btnLimpaProduto.Text = "ESTORNA produto F3"
        'Else
        'btnQtde.Enabled = True
        'btnComent.Enabled = True
        'btnLimpaProduto.Text = "LIMPA produto F3"
        'End If
        'End If

        For i As Integer = 0 To Grid.Rows.Count - 1
            If NuloString(Grid.Item(3, i).Value) = "RAPPI" Then
                Grid.Rows(i).Cells("image").Value = img.FromFile(Application.StartupPath & "\rappi.png")
            End If
            If NuloString(Grid.Item(3, i).Value) = "IFOOD" Then
                Grid.Rows(i).Cells("image").Value = img.FromFile(Application.StartupPath & "\ifood.png")
            End If
            If NuloString(Grid.Item(3, i).Value) = "QRBOX" Then
                Grid.Rows(i).Cells("image").Value = img.FromFile(Application.StartupPath & "\qrbox.jpg")
            End If
        Next

    End Sub
    Public Class TextAndImageCell
        Inherits DataGridViewTextBoxCell
        Private imageValue As Image
        Private imageSize As Size
        Public Overloads Overrides Function Clone() As Object
            Dim c As TextAndImageCell = TryCast(MyBase.Clone, TextAndImageCell)
            c.imageValue = Me.imageValue
            c.imageSize = Me.imageSize
            Return c
        End Function
        Public Property Image() As Image
            Get
                If Me.OwningColumn Is Nothing OrElse Me.OwningTextAndImageColumn Is Nothing Then
                    Return imageValue
                Else
                    If Not (Me.imageValue Is Nothing) Then
                        Return Me.imageValue
                    Else
                        Return Me.OwningTextAndImageColumn.Image
                    End If
                End If
            End Get
            Set(ByVal value As Image)
                Me.imageValue = value
                Me.imageSize = value.Size
                Dim inheritedPadding As Padding = Me.InheritedStyle.Padding
                Me.Style.Padding = New Padding(imageSize.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom)
            End Set
        End Property
        Protected Overloads Overrides Sub Paint(graphics As Graphics, clipBounds As Rectangle, cellBounds As Rectangle,
                                                rowIndex As Integer, cellState As DataGridViewElementStates, value As Object, formattedValue As Object,
                                                errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle,
                                                paintParts As DataGridViewPaintParts)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
            If Not (Me.Image Is Nothing) Then
                Dim container As System.Drawing.Drawing2D.GraphicsContainer = graphics.BeginContainer
                graphics.SetClip(cellBounds)
                graphics.DrawImageUnscaled(Me.Image, cellBounds.Location)
                graphics.EndContainer(container)
            End If
        End Sub
        Private ReadOnly Property OwningTextAndImageColumn() As TextAndImageColumn
            Get
                Return TryCast(Me.OwningColumn, TextAndImageColumn)
            End Get
        End Property
    End Class
    Public Class TextAndImageColumn
        Inherits DataGridViewTextBoxColumn
        Private imageValue As Image
        Private m_imageSize As Size
        Public Sub New()
            Me.CellTemplate = New TextAndImageCell
        End Sub
        Public Overloads Overrides Function Clone() As Object
            Dim c As TextAndImageColumn = TryCast(MyBase.Clone, TextAndImageColumn)
            c.imageValue = Me.imageValue
            c.m_imageSize = Me.m_imageSize
            Return c
        End Function
        Public Property Image() As Image
            Get
                Return Me.imageValue
            End Get
            Set(ByVal value As Image)
                Me.imageValue = value
                Me.m_imageSize = value.Size
                Dim inheritedPadding As Padding = Me.DefaultCellStyle.Padding
                Me.DefaultCellStyle.Padding = New Padding(ImageSize.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom)
            End Set
        End Property
        Private ReadOnly Property TextAndImageCellTemplate() As TextAndImageCell
            Get
                Return TryCast(Me.CellTemplate, TextAndImageCell)
            End Get
        End Property
        Friend ReadOnly Property ImageSize() As Size
            Get
                Return m_imageSize
            End Get
        End Property
    End Class



    Private Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click

        ExecutaStr("UPDATE tblAppVendas SET TerminalEmUso='' WHERE (TerminalEmUso='" & NomeTerminal & "')")

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FrmAppPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MontaGridProdutosBusca(tbBusca.Text)
        PreencheListaPedidos()
        Grid.ClearSelection()
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged

    End Sub

    Private Sub LstDescricao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDescricao.SelectedIndexChanged
        'If lstDescricao.SelectedItems.Count > 0 Then
        '
        'For i = 0 To lstDescricao.Items.Count - 1
        'If lstDescricao.Items(i).Selected = True Then

        'If NuloString(lstDescricao.Items(i).SubItems(0).Text) = "" And Strings.Left(NuloString(lstDescricao.Items(i).SubItems(1).Text), 8) <> "   ---> " Then
        'PanelProdutos.Visible = True
        'tbBusca.Text = ""
        'Else
        'PanelProdutos.Visible = False
        'End If
        'End If

        'Next

        'End If
    End Sub

    Private Sub ChkConfirmados_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfirmados.CheckedChanged
        chkRejeitado.Checked = False
        chkTodos.Checked = False
        tbDescricao.Text = ""
        lbTotalProd.Text = ""
        DataSetGrid.Tables(0).Clear()
        lstDescricao.Items.Clear()
        PanelProdutos.Visible = False
        'If chkConfirmados.Checked = True Then
        'btnCancelar.Visible = False
        'btnAceitar.Visible = False
        'Else
        'btnCancelar.Visible = True
        'btnAceitar.Visible = True
        'End If
        PreencheListaPedidos()
        Grid.ClearSelection()
    End Sub

    Private Sub BtnAceitar_Click(sender As Object, e As EventArgs) Handles btnAceitar.Click
        If IncoProdutos = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Existe uma inconsistência nos produtos deste pedido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If Grid.Rows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um pedido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(Grid.Item(6, Grid.CurrentRow.Index).Value) <> "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Pedido com Status " & Grid.Item(6, Grid.CurrentRow.Index).Value & vbCrLf & "Não será possivel Aceitar"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        strSql = "SELECT IDVendaExterna, AppConfirmado, TerminalEmUso FROM tblAppVendas WHERE IDVendaExterna='" & Grid.Item(2, Grid.CurrentRow.Index).Value & "'"
        If NuloBoolean(PegaValorCampo("AppConfirmado", strSql, strCon)) = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Pedido já confirmado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        CarregaDadosVenda(Grid.Item(2, Grid.CurrentRow.Index).Value)
        CarregaProdutos(Grid.Item(2, Grid.CurrentRow.Index).Value)

        If Grid.Item(3, Grid.CurrentRow.Index).Value = "IFOOD" Then
            MudarStatus(Grid.Item(2, Grid.CurrentRow.Index).Value, "confirmation", "IFOOD")
        End If

        ExecutaStr("UPDATE tblAppVendas SET TerminalEmUso='' WHERE (TerminalEmUso='" & NomeTerminal & "')")

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub BtnEnvia_Click(sender As Object, e As EventArgs) Handles btnEnvia.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lstDescricao.SelectedItems.Count = 0 Then
            frm.lbMensagem.Text = "È necessário selecionar um produto Rappi"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If lstProdutos.SelectedItems.Count = 0 Then
            frm.lbMensagem.Text = "È necessário selecionar um produto Gourmet Visual"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        'If lstDescricao.SelectedItems(0).SubItems(0).Text = "" Then
        'frm.lbMensagem.Text = "Este lançamento não pode ser convertido em um produto"
        'frm.btnNao.Visible = False
        'frm.btnSim.Visible = False
        'frm.btnOK.Visible = True
        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        'frm.ShowDialog()
        'Exit Sub
        'End If

        frm.lbMensagem.Text = "Confirma o vinculo do produto" & vbCrLf & lstProdutos.SelectedItems(0).SubItems(2).Text
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        If NuloInteger(PegaValorCampo("IDProduto", "Select IDProduto, IDLoja, Aplicativo, CodigoProdutoExterno FROM tblProdutosExterno WHERE (IDLoja=" & IDLoja & ") AND (CodigoProdutoExterno='" & lstDescricao.SelectedItems(0).SubItems(7).Text & "')", strConServer)) = 0 Then
            strSql = "INSERT tblProdutosExterno (IDProduto, CodigoProduto, IDLoja, Aplicativo, ProdutoExterno, CodigoProdutoExterno) VALUES ("
            strSql &= to_sql(lstProdutos.SelectedItems(0).SubItems(0).Text) & ","
            strSql &= to_sql(lstProdutos.SelectedItems(0).SubItems(1).Text) & ","
            strSql &= to_sql(IDLoja) & ","
            strSql &= to_sql(Grid.Item(3, Grid.CurrentRow.Index).Value) & ","
            strSql &= to_sql(Trim(Replace(lstDescricao.SelectedItems(0).SubItems(1).Text, "-", " "))) & ","
            strSql &= to_sql(lstDescricao.SelectedItems(0).SubItems(7).Text) & ")"
        Else
            strSql = "UPDATE tblProdutosExterno SET "
            strSql += "IDProduto=" & lstProdutos.SelectedItems(0).SubItems(0).Text & ", "
            strSql += "CodigoProduto=" & lstProdutos.SelectedItems(0).SubItems(1).Text & " "
            'strSql += "ProdutoExterno='" & Trim(Replace(Replace(lstDescricao.SelectedItems(0).SubItems(1).Text, "-", " "), ">", "")) & " "
            'strSql += "CodigoProdutoExterno='" & lstDescricao.SelectedItems(0).SubItems(7).Text & "' "
            strSql += "WHERE (IDLoja=" & IDLoja & ") AND (CodigoProdutoExterno='" & lstDescricao.SelectedItems(0).SubItems(7).Text & "')"
        End If
        ExecutaStrServidor(strSql)

        AtualizaTabelaProdutosExterno()

        strSql = "Select tblProdutos_Local.IDProduto, tblProdutos_Local.Produto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Categoria, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo "
        strSql += "From tblGrupos_Local INNER Join tblProdutos_Local On tblGrupos_Local.CodigoGrupo = tblProdutos_Local.CodigoGrupo "
        strSql += "Where (IDProduto = " & lstProdutos.SelectedItems(0).SubItems(0).Text & ")"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "prod")

        If NuloString(lstDescricao.SelectedItems(0).SubItems(5).Text) = "" Then
            strSql = "UPDATE tblAppVendasMovto Set "
            strSql &= "Produto='" & ds.Tables("prod").Rows(0).Item("Produto") & "', "
            strSql &= "Imprime=1, "
            strSql &= "IDProduto=" & ds.Tables("prod").Rows(0).Item("IDProduto") & ", "
            strSql &= "Categoria='" & ds.Tables("prod").Rows(0).Item("Categoria") & "', "
            strSql &= "IDGrupo=" & ds.Tables("prod").Rows(0).Item("CodigoGrupo") & ", "
            strSql &= "Grupo='" & ds.Tables("prod").Rows(0).Item("Grupo") & "' "
            strSql &= "Where (IDAppVendaMovto = " & lstDescricao.SelectedItems(0).SubItems(4).Text & ")"
        Else
            strSql = "UPDATE tblAppVendasCombo SET "
            strSql &= "Produto='" & ds.Tables("prod").Rows(0).Item("Produto") & "', "
            'End If
            strSql &= "IDProduto=" & ds.Tables("prod").Rows(0).Item("IDProduto") & ", "
            strSql &= "Categoria='" & ds.Tables("prod").Rows(0).Item("Categoria") & "', "
            strSql &= "IDGrupo=" & ds.Tables("prod").Rows(0).Item("CodigoGrupo") & ", "
            strSql &= "Grupo='" & ds.Tables("prod").Rows(0).Item("Grupo") & "' "
            'If NuloString(lstDescricao.SelectedItems(0).SubItems(5).Text) = "" Then
            'strSql &= "Where (IDAppVendaMovto = " & lstDescricao.SelectedItems(0).SubItems(4).Text & ")"
            'Else
            strSql &= "Where (IDAppVendaCombo = " & lstDescricao.SelectedItems(0).SubItems(5).Text & ")"
        End If
        ExecutaStr(strSql)


        MontaGridProdutos(Grid.Item(2, Grid.CurrentRow.Index).Value)



        PanelProdutos.Visible = True
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click


        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If Grid.SelectedRows.Count = 0 Then
            frm.lbMensagem.Text = "È necessário selecionar um pedido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(Grid.Item(6, Grid.CurrentRow.Index).Value) <> "" Then
            frm.lbMensagem.Text = "Pedido com Status " & Grid.Item(6, Grid.CurrentRow.Index).Value & vbCrLf & "Não será possivel Rejeitar"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Deseja realmente REJEITAR o pedido" & vbCrLf & Grid.Item(2, Grid.CurrentRow.Index).Value
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
        frm1.lbMensagem.Text = "Tem certeza" & vbCrLf & "(" & Grid.Item(2, Grid.CurrentRow.Index).Value & ")"
        frm1.btnNao.Visible = True
        frm1.btnSim.Visible = True
        frm1.btnOK.Visible = False
        frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm1.ShowDialog()
        If RetornoMsg = False Then Exit Sub


        If Grid.Item(3, Grid.CurrentRow.Index).Value = "IFOOD" Then
            MudarStatus(Grid.Item(2, Grid.CurrentRow.Index).Value, "cancellationRequested", Grid.Item(3, Grid.CurrentRow.Index).Value)
        End If
        If Grid.Item(3, Grid.CurrentRow.Index).Value = "RAPPI" Then
            Dim api As New ApisRappi(Cliente_ID_Rappi, Client_Secret_Rappi, Audience_Rappi)
            api.RejectAnOrder(Grid.Item(2, Grid.CurrentRow.Index).Value, "Itens indisponíveis") ' Cancelar pedido
        End If

        ExecutaStr("UPDATE tblAppVendas SET Excluido=1 WHERE (IDVendaExterna='" & Grid.Item(2, Grid.CurrentRow.Index).Value & "')")

        tbDescricao.Text = ""
        lbTotalProd.Text = ""
        lstDescricao.Items.Clear()
        PanelProdutos.Visible = False
        PreencheListaPedidos()

    End Sub

    Private Sub ChkRejeitado_CheckedChanged(sender As Object, e As EventArgs) Handles chkRejeitado.CheckedChanged
        chkConfirmados.Checked = False
        chkTodos.Checked = False
        tbDescricao.Text = ""
        lbTotalProd.Text = ""
        DataSetGrid.Tables(0).Clear()
        lstDescricao.Items.Clear()
        PanelProdutos.Visible = False
        'If chkConfirmados.Checked = True Then
        'btnCancelar.Visible = False
        'btnAceitar.Visible = False
        'Else
        'btnCancelar.Visible = True
        'btnAceitar.Visible = True
        'End If
        PreencheListaPedidos()
        Grid.ClearSelection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'fdlgProdutos_Inclusao.ShowDialog()

        Dim frm As fdlgProdutos_Inclusao = New fdlgProdutos_Inclusao
        frm.tbNCM.Text = NCM_Servico
        frm.tbCST_ICMS.Text = CSTIcms_Servico
        frm.tbCST_PIS.Text = CSTPis_Servico
        frm.tbCST_COFINS.Text = CSTCofins_Servico
        frm.tbCFOP.Text = CFOP_Servico
        If lstDescricao.SelectedItems.Count = 0 Then
            frm.tbVenda.Text = Format(0, "#0.00")
        Else
            frm.tbVenda.Text = Format(NuloDecimal(lstDescricao.SelectedItems(0).SubItems(3).Text), "#0.00")
        End If
        frm.ShowDialog()



        frmInicio.AtualizaTabela("Produtos")
        MontaGridProdutosBusca(tbBusca.Text)

    End Sub

    Private Sub TbBuscaPedido_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaPedido.TextChanged
        PreencheListaPedidos()
        Grid.ClearSelection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lstDescricao.SelectedItems.Count = 0 Then
            frm.lbMensagem.Text = "Produto inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloInteger(lstDescricao.SelectedItems(0).SubItems(0).Text) > 0 Then
            frm.lbMensagem.Text = "Este lançamento não pode ser convertido em um comentário"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloString(PegaValorCampo("IDVendaExterna", strSql = "SELECT IDVendaExterna FROM tblAppVendasComent WHERE (IDAppVendaMovto=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text) & ") And (CodigoProdutoExterno='" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(7).Text) & "')", strCon)) = "" Then

            strSql = "INSERT tblAppVendasComent (IDVendaExterna,IDAppVendaMovto,IDAppVendaCombo,Coment,IDProdutoVinculado,CodigoProdutoExterno) VALUES ("
            strSql &= NuloInteger(Grid.Item(2, Grid.CurrentRow.Index).Value) & ","
            strSql &= NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text) & ","
            strSql &= "0,"
            strSql &= "'" & NuloString(VerificaTexto(Strings.Left(Replace(lstDescricao.SelectedItems(0).SubItems(1).Text, ">", ""), 250))) & "',"
            strSql &= "0,"
            strSql &= "'" & NuloString(VerificaTexto(Strings.Left(lstDescricao.SelectedItems(0).SubItems(7).Text, 100))) & "')"
            ExecutaStr(strSql)

            'strSql = "DELETE tblAppVendasComent WHERE (IDAppVendaMovto=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text) & ") And (CodigoProdutoExterno='" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(7).Text) & "')"
            'ExecutaStr(strSql)

            strSql = "DELETE tblAppVendasCombo WHERE IDAppVendaCombo=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(5).Text)
            ExecutaStr(strSql)
        End If


        MontaGridProdutos(Grid.Item(2, Grid.CurrentRow.Index).Value)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lstDescricao.SelectedItems.Count = 0 Then
            frm.lbMensagem.Text = "Produto inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If lstDescricao.SelectedItems(0).SubItems(0).Text = "" Then
            frm.lbMensagem.Text = "Este lançamento não pode ser convertido em um comentário"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloInteger(lstDescricao.SelectedItems(0).SubItems(0).Text) > 0 Then
            frm.lbMensagem.Text = "Este lançamento já é um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            'frm.ShowDialog()
            'Exit Sub
        End If



        Dim strSql_ As String = "SELECT * FROM tblProdutos_Local WHERE CodigoProduto=" & lstDescricao.SelectedItems(0).SubItems(0).Text
        Dim IDprod As Integer = NuloInteger(PegaValorCampo("IDProduto", strSql_, strCon))

        strSql = "INSERT tblAppVendasMovto "
        strSql += "(IDVendaExterna,IDProduto,Produto,Qtd,Enviado,Venda,VendaServico,Categoria,HoraPedido,IDFuncionario,Atendente,IDGrupo,Grupo,Excluido,MotivoEstorno,Impresso,StatusTransf,Terminal,Imprime,SetorImpressao,MesaCartao,ComServico,EmEspera,CodigoProdutoExterno) VALUES ("
        strSql += to_sql(Grid.Item(2, Grid.CurrentRow.Index).Value) & ","
        strSql += to_sql(IDprod) & ","
        strSql += to_sql(PegaValorCampo("Produto", strSql_, strCon)) & ","
        strSql += to_sql(Replace(lstDescricao.SelectedItems(0).SubItems(2).Text, ",", ".")) & ","
        strSql += to_sql("False") & ","
        strSql += to_sql(Replace(lstDescricao.SelectedItems(0).SubItems(3).Text, ",", ".")) & ","
        strSql += to_sql(Replace(lstDescricao.SelectedItems(0).SubItems(3).Text, ",", ".")) & ","
        strSql += to_sql(PegaValorCampo("Categoria", strSql_, strCon)) & ","
        strSql += to_sql(Date.Now.ToString) & ","
        strSql += to_sql(0) & ","
        strSql += to_sql("APP") & ","
        strSql += to_sql(PegaValorCampo("CodigoGrupo", strSql_, strCon)) & ","
        strSql += to_sql(PegaValorCampo("Grupo", "Select * FROM tblGrupos_Local WHERE CodigoGrupo=" & PegaValorCampo("CodigoGrupo", strSql_, strCon), strCon)) & ","
        strSql += to_sql("False") & ","
        strSql += to_sql("") & ","
        strSql += "0,"
        strSql += to_sql("") & ","
        strSql += to_sql("APP") & ","
        strSql += to_sql(NuloBoolean(PegaValorCampo("ImprimeCategoria", strSql_, strCon))) & ","
        strSql += to_sql(SetorDelivery) & ","
        strSql += to_sql("") & ","
        strSql += to_sql(NuloBoolean(PegaValorCampo("ComServico", strSql_, strCon))) & ","
        strSql += "0,"
        strSql += to_sql(lstDescricao.SelectedItems(0).SubItems(7).Text) & ")"
        ExecutaStr(strSql)
        Dim IDmovto As Integer = NuloInteger(PegaID("IDAppVendaMovto", "tblAppVendasMovto", "L"))

        Dim ComentVinc As String
        ComentVinc = NuloString(PegaValorCampo("Comentario", "SELECT IDComentario, IDFamilia, Comentario, IDProduto FROM tblComentarios_Local WHERE (IDProduto = " & IDprod & ")", strCon))
        If ComentVinc <> "" Then
            strSql = "INSERT tblAppVendasComent (IDVendaExterna,IDAppVendaMovto,IDAppVendaCombo,Coment,IDProdutoVinculado) VALUES ("
            strSql &= NuloInteger(Grid.Item(2, Grid.CurrentRow.Index).Value) & ","
            strSql &= NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text) & ","
            strSql &= "0,"
            strSql &= "'" & NuloString(UCase(VerificaTexto(Strings.Left(ComentVinc, 250)))) & "',"
            strSql &= "0)"
            ExecutaStr(strSql)
        End If



        Dim ValorProd As Decimal = NuloDecimal(PegaValorCampo("Venda", "Select * FROM tblAppVendasMovto WHERE IDAppVendaMovto=" & lstDescricao.SelectedItems(0).SubItems(4).Text, strCon)) - NuloDecimal(lstDescricao.SelectedItems(0).SubItems(3).Text)

        strSql = "UPDATE tblAppVendasMovto SET Venda=" & Replace(ValorProd, ",", ".") & ", VendaServico=" & Replace(ValorProd, ",", ".") & " WHERE IDAppVendaMovto=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text)
        ExecutaStr(strSql)

        strSql = "UPDATE tblAppVendasComent SET IDAppVendaMovto=" & IDmovto & " WHERE IDAppVendaMovto=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text)
        ExecutaStr(strSql)

        'strSql = "DELETE tblAppVendasMovto WHERE IDAppVendaMovto=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(4).Text)
        ' ExecutaStr(strSql)

        strSql = "DELETE tblAppVendasCombo WHERE IDAppVendaCombo=" & NuloInteger(lstDescricao.SelectedItems(0).SubItems(5).Text)
        ExecutaStr(strSql)


        MontaGridProdutos(Grid.Item(2, Grid.CurrentRow.Index).Value)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Grid.SelectedRows.Count > 0 Then
            If Grid.Item(3, Grid.CurrentRow.Index).Value = "RAPPI" Then
                VerificaPedidosRappi()
            Else
                VerificaPedidosIfood(NuloString(PegaValorCampo("Json", "SELECT IDVendaExterna, Json FROM tblAppVendas WHERE IDVendaExterna='" & Grid.Item(2, Grid.CurrentRow.Index).Value & "'", strCon)))
            End If
            MontaPedido(Grid.Item(2, Grid.CurrentRow.Index).Value)
            MontaGridProdutos(Grid.Item(2, Grid.CurrentRow.Index).Value)
        Else

            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "È necessário selecionar um pedido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If

    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        chkRejeitado.Checked = False
        chkConfirmados.Checked = False
        tbDescricao.Text = ""
        lbTotalProd.Text = ""
        DataSetGrid.Tables(0).Clear()
        lstDescricao.Items.Clear()
        PanelProdutos.Visible = False
        'If chkConfirmados.Checked = True Then
        'btnCancelar.Visible = False
        'btnAceitar.Visible = False
        'Else
        'btnCancelar.Visible = True
        'btnAceitar.Visible = True
        'End If
        PreencheListaPedidos()
        Grid.ClearSelection()
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click
        If Grid.Rows.Count > 0 Then
            If NuloString(Grid.Item(3, Grid.CurrentRow.Index).Value) = "RAPPI" Then
                'Button2.Visible = True
                'Button3.Visible = True
                Button4.Visible = True
            Else
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
            End If


            Dim TerminalApp As String = ""

            MontaPedido(Grid.Item(2, Grid.CurrentRow.Index).Value)
            MontaGridProdutos(Grid.Item(2, Grid.CurrentRow.Index).Value)
            PanelProdutos.Visible = True
            tbBusca.Text = ""

            If chkConfirmados.Checked = False Then

                ExecutaStr("UPDATE tblAppVendas SET TerminalEmUso='' WHERE (TerminalEmUso='" & NomeTerminal & "')")

                If chkConfirmados.Checked = False And chkTodos.Checked = False Then

                    If Grid.Item(3, Grid.CurrentRow.Index).Value = "RAPPI" Then
                        VerificaPedidosRappi()
                    End If

                    strSql = "SELECT IDVendaExterna, AppConfirmado, TerminalEmUso FROM tblAppVendas WHERE IDVendaExterna='" & Grid.Item(2, Grid.CurrentRow.Index).Value & "'"
                    If NuloBoolean(PegaValorCampo("AppConfirmado", strSql, strCon)) = True Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Pedido já confirmado"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                    Else
                        TerminalApp = NuloString(PegaValorCampo("TerminalEmUso", strSql, strCon))
                        If TerminalApp = "" Or TerminalApp = NomeTerminal Then
                            ExecutaStr("UPDATE tblAppVendas SET TerminalEmUso='" & NomeTerminal & "' WHERE IDVendaExterna='" & Grid.Item(2, Grid.CurrentRow.Index).Value & "'")
                        Else
                            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                            frm.lbMensagem.Text = "Pedido em uso no terminal " & vbCrLf & TerminalApp
                            frm.btnNao.Visible = False
                            frm.btnSim.Visible = False
                            frm.btnOK.Visible = True
                            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                            frm.ShowDialog()

                            Grid.ClearSelection()

                            lstProdutos.Items.Clear()
                            lstDescricao.Items.Clear()
                            tbDescricao.Text = ""
                            PanelProdutos.Visible = True
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub LstProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProdutos.SelectedIndexChanged

    End Sub

    Private Sub Grid_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles Grid.CellParsing

    End Sub

    Private Sub tbBusca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBusca.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            MontaGridProdutosBusca(tbBusca.Text)

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MontaGridProdutosBusca(tbBusca.Text)
    End Sub
End Class