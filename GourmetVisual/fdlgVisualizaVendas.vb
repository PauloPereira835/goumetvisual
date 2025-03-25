Imports System.Data.SqlClient

Public Class fdlgVisualizaVendas

    Private mDataSet As DataSet
    Private Sub porModulo()

        Dim con As New SqlConnection(strCon)
        Dim total As Decimal = 0
        Dim yColuna(2) As Decimal
        Dim xLinha(2) As String
        Dim VlrVenda(2) As Decimal
        Dim Modulo(2) As String
        Dim Seq As Integer = 0
        Dim TotSal As Integer = 0
        Dim TotBal As Integer = 0
        Dim TotDel As Integer = 0

        strSql = "Select DATEPART(HH, tblVendasMovto.HoraPedido) AS HORA, tblVendas.Excluido, SUM(tblVendasMovto.Qtd * tblVendasMovto.Venda) AS VlrVenda, tblVendasMovto.HoraPedido "
        strSql += "From tblVendas INNER Join tblFechamentos_Local On tblVendas.IDfechamento = tblFechamentos_Local.IDFechamento INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
        strSql += "Where (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 1) "
        strSql += "GROUP BY tblVendas.Excluido, tblVendasMovto.Excluido, tblVendasMovto.HoraPedido, tblVendas.FlagFechada "
        strSql += "HAVING (tblVendas.Excluido = 0) AND (tblVendasMovto.Excluido = 0)"

        strSql = "Select SUM(TotalProdutos) As ValorVendas, SUM(QtdPessoas) As QtdeVendas, StatusVenda "
        strSql += "From tblVendas "
        strSql += "Where (FlagFechada = 1) And (Excluido = 0) "
        strSql += "Group By StatusVenda "
        strSql += "Order By QtdeVendas DESC"

        strSql = "Select SUM(TotalProdutos) As ValorVendas, SUM(QtdPessoas) As QtdeVendas, Case When StatusVenda = 'D' THEN 'D' WHEN StatusVenda = 'D' THEN 'D' ELSE 'S' END AS StatusVenda "
        strSql += "From tblVendas "
        strSql += "Where (FlagFechada = 1) And (Excluido = 0) "
        strSql += "Group By CASE WHEN StatusVenda = 'D' THEN 'D' WHEN StatusVenda = 'D' THEN 'D' ELSE 'S' END "
        strSql += "Order By QtdeVendas DESC"

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            'chtModulos.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            chtModulos.Series(0).Font = New Font("Arial", 8, FontStyle.Regular)
            'chtModulos.ChartAreas(0).AxisY.IsInterlaced = True
            'chtModulos.ChartAreas(0).Axes(1).IsInterlaced = True

            'define o tipo de gráfico
            chtModulos.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            'define o titulo do gráfico
            ''''chtModulos.Titles.Add("Venda por Mõdulos")
            'habilita a visão em 3D
            chtModulos.ChartAreas(0).Area3DStyle.Enable3D = True
            'define inclinação, rotação e perspectiva
            chtModulos.ChartAreas(0).Area3DStyle.Inclination = 20
            chtModulos.ChartAreas(0).Area3DStyle.Rotation = 50
            chtModulos.ChartAreas(0).Area3DStyle.Perspective = 10
            'define o estilo da linha
            '''   chtModulos.ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Realistic
            'define a paleta
            '''   chtModulos.Palette = ChartColorPalette.BrightPastel
            'vincula os dados ao gráfico
            '''  chtModulos.Series(0).Points.DataBindXY(xPaises, yPopulacao)
            'exibe os valores no eixo do gráfico
            chtModulos.Series(0).IsValueShownAsLabel = False
            chtModulos.Series(0).IsVisibleInLegend = False


            While (dr.Read())
                VlrVenda(Seq) = NuloDecimal(dr.Item("ValorVendas"))
                total += NuloDecimal(dr.Item("ValorVendas"))
                If dr.Item("StatusVenda") = "D" Then
                    Modulo(Seq) = "DELIVERY"
                Else
                    If dr.Item("StatusVenda") = "B" Then
                        Modulo(Seq) = "BALCÃO"
                    Else
                        Modulo(Seq) = "SALÃO"
                    End If
                End If
                Seq+=1
            End While
        End If

        If total = 0 Then total = 1

        For i = 0 To 2
            yColuna(i) = Format(VlrVenda(i), "#0.00")
            xLinha(i) = Modulo(i) & "  " & Format(((VlrVenda(i) / total) * 100), "#0") & "%  (" & VlrVenda(i).ToString("C") & ")"
        Next

        'chtHora.Series(0).Points.DataBindXY(xLinha, yColuna)
        chtModulos.Series(0).Points.DataBindXY(xLinha, yColuna)

        strSql = "Select COUNT(IDVenda) As TotVda, Excluido, FlagFechada, StatusVenda "
        strSql += "From tblVendas "
        strSql += "Group By Excluido, FlagFechada, StatusVenda "
        strSql += "HAVING(Excluido = 0) And (FlagFechada = 1) And (StatusVenda='S')"
        TotSal = NuloInteger(PegaValorCampo("TotVda", strSql, strCon))

        strSql = "Select COUNT(IDVenda) As TotVda, Excluido, FlagFechada, StatusVenda "
        strSql += "From tblVendas "
        strSql += "Group By Excluido, FlagFechada, StatusVenda "
        strSql += "HAVING(Excluido = 0) And (FlagFechada = 1) And (StatusVenda='B')"
        TotBal = NuloInteger(PegaValorCampo("TotVda", strSql, strCon))

        strSql = "Select COUNT(IDVenda) As TotVda, Excluido, FlagFechada, StatusVenda "
        strSql += "From tblVendas "
        strSql += "Group By Excluido, FlagFechada, StatusVenda "
        strSql += "HAVING(Excluido = 0) And (FlagFechada = 1) And (StatusVenda='D')"
        TotDel = NuloInteger(PegaValorCampo("TotVda", strSql, strCon))

        lbTotal.Text = TotSal + TotBal + TotDel
        lbTotSalao.Text = TotSal
        lbTotBalcao.Text = TotBal
        lbTotDelivery.Text = TotDel

        comandoLJS.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

    End Sub

    Private Sub CriaRelatServicoCaixinha(IDfec As Integer)
        Dim conS As New SqlConnection()
        Dim drS As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        'Dim conexao As String = strConServer
        Dim conexao As String = strCon

        ' Serviço e Caixinha /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        conS.ConnectionString = conexao
        Dim cmdS As SqlCommand = conS.CreateCommand


        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\servico.txt", OpenMode.Output)

        If IDfec = 0 Then
            strSql = "Select SUM(TotalProdutos) As vlrProd, SUM(QtdPessoas) As QtdePes, Excluido, SUM(Servico) As vlrServico, SUM(Caixinha) As vlrCaixinha, Case When StatusVenda = 'D' THEN Entregador ELSE Atendente END AS Atendente "
            strSql += "From tblVendas "
            strSql += "Group By Excluido, CASE WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END HAVING(Excluido = 0) And (Case When StatusVenda = 'D' THEN Entregador ELSE Atendente END IS NOT NULL) "
        Else
            strSql = "Select IDFechamento, SUM(TotalProdutos) As vlrProd, SUM(QtdPessoas) As QtdePes, Excluido, SUM(Servico) As vlrServico, SUM(Caixinha) As vlrCaixinha, Atendente "
            strSql += "From tblVendas "
            strSql += "Group By IDFechamento, Excluido, Atendente "
            strSql += "HAVING(Excluido = 0) And (IDfechamento = " & IDfec & ") "
        End If
        strSql += "ORDER BY vlrServico"

        cmdS.CommandText = strSql
        conS.Open()
        drS = cmdS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        ' If drS.HasRows Then
        texto = ""
        PrintLine(lngFile, "Servico/Caixinha")
        PrintLine(lngFile, "----------------------------------------")
        If IDfec = 0 Then
            PrintLine(lngFile, "Todos os movimentos")
        Else
            strSql = "Select IDFechamento, Caixa, DiaMovimento, DataAbertura, DataFechamento, Turno, Confirmado, FundoCaixa, SaldoCaixa, Transferido, IDFuncionario "
            strSql += "From tblFechamentos_Local "
            strSql += "Where (IDFechamento = " & IDfec & ")"
            PrintLine(lngFile, "Periodo    : " & NuloString(PegaValorCampo("Turno", strSql, conexao)))
            PrintLine(lngFile, "             " & NuloString(PegaValorCampo("DataAbertura", strSql, conexao)))
            PrintLine(lngFile, "Responsavel: " & NuloString(PegaValorCampo("Caixa", strSql, conexao)))
        End If
        PrintLine(lngFile, "----------------------------------------")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")

        Dim vlrServ As Decimal
        Dim vlrCaix As Decimal
        Dim vlrServAj As Decimal
        Dim totServ As Decimal = 0
        Dim totCaix As Decimal = 0
        Dim totServAj As Decimal = 0

        If NuloInteger(FatorAjusteServico) <> 0 Then
            PrintLine(lngFile, "Atendente      Servico Ajustado Caixinha")
        Else
            PrintLine(lngFile, "Atendente      Servico          Caixinha")
        End If

        PrintLine(lngFile, "========================================")
        While drS.Read
            vlrServ = NuloDecimal(drS.Item("vlrServico"))
            vlrServAj = NuloDecimal(NuloDecimal(drS.Item("vlrServico")) * ((100 - FatorAjusteServico) / 100))
            vlrCaix = NuloDecimal(drS.Item("vlrCaixinha"))

            totServ += vlrServ.ToString("#0.00")
            totCaix += vlrCaix.ToString("#0.00")
            totServAj += vlrServAj.ToString("#0.00")

            texto = Strings.Left(drS.Item("Atendente"), 15)
            If Len(texto) < 15 Then
                texto += Space(15 - Len(texto))
            End If
            texto += Space(7 - Len(vlrServ.ToString("#0.00"))) & vlrServ.ToString("#0.00")
            If NuloInteger(FatorAjusteServico) <> 0 Then
                texto += Space(9 - Len(vlrServAj.ToString("#0.00"))) & vlrServAj.ToString("#0.00")
            Else
                texto += Space(9)
            End If
            texto += Space(9 - Len(vlrCaix.ToString("#0.00"))) & vlrCaix.ToString("#0.00")
            PrintLine(lngFile, texto)
        End While

        PrintLine(lngFile, "----------------------------------------")
        texto = "Total          "
        texto += Space(7 - Len(totServ.ToString("#0.00"))) & totServ.ToString("#0.00")
        If NuloInteger(FatorAjusteServico) <> 0 Then
            texto += Space(9 - Len(totServAj.ToString("#0.00"))) & totServAj.ToString("#0.00")
        Else
            texto += Space(9)
        End If
        texto += Space(9 - Len(totCaix.ToString("#0.00"))) & totCaix.ToString("0.00")
        PrintLine(lngFile, texto)
        PrintLine(lngFile, "========================================")
        If NuloInteger(FatorAjusteServico) <> 0 Then
            Dim ServicoAj As Decimal = totServ - totServAj
            PrintLine(lngFile, "*Servico ajustado:  " & FatorAjusteServico & "%    (" & ServicoAj.ToString("#0.00") & ")")
        End If

        'End If
        cmdS.Dispose()
        drS.Close()
        conS.Dispose()
        conS.Close()
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")

        FileClose(lngFile)

    End Sub
    Private Sub PreencheListaProdutos()
        Dim item As ListViewItem
        Dim CodGru As Integer = NuloInteger(Strings.Right(cbGrupos.Text, 9))
        Dim Vendas As New DataTable("Vendas")
        mDataSet = New DataSet("VendasProdutos")
        mDataSet.Tables.Add(Vendas)

        Vendas.Columns.Add("IDGrupo", GetType(Integer))
        Vendas.Columns.Add("Grupo", GetType(String))
        Vendas.Columns.Add("Produto", GetType(String))
        Vendas.Columns.Add("Qtde", GetType(Decimal))
        Vendas.Columns.Add("Valor", GetType(Decimal))

        lstProdutos.Items.Clear()

        strSql = "Select tblVendasMovto.Excluido, tblVendas.Excluido As VendaExcluida, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.IDProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd * tblVendasMovto.Venda) As ValorVenda, SUM(tblVendasMovto.Qtd) As Qtde "
        strSql += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        strSql += "Group By tblVendasMovto.Excluido, tblVendas.FlagFechada, tblVendasMovto.IDGrupo, tblVendasMovto.Grupo, tblVendasMovto.Produto, tblVendas.Excluido, tblVendasMovto.IDProduto "
        strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 1)"
        If CodGru <> 0 Then
            strSql += " And (tblVendasMovto.IDGrupo=" & CodGru & ")"
        End If

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Prods")

        Dim VlrProds As Decimal = 0
        Dim QtdeProds As Decimal = 0
        Dim IDcombo As Integer
        Dim AgregaValor As Boolean = False
        For i As Integer = 0 To ds.Tables("Prods").Rows.Count - 1

            strSql = "Select IDCombo, IDProduto, IDFamilia, AgregaValor, Sequencia "
            strSql += "From tblCombos_Local "
            strSql += "Where (IDProduto = " & ds.Tables("Prods").Rows(i).Item("IDProduto") & ")"
            IDcombo = NuloInteger(PegaValorCampo("IDCombo", strSql, strCon))
            If NuloInteger(IDcombo) = 0 Then
                Vendas.Rows.Add(ds.Tables("Prods").Rows(i).Item("IDGrupo"), ds.Tables("Prods").Rows(i).Item("Grupo"), ds.Tables("Prods").Rows(i).Item("Produto"), ds.Tables("Prods").Rows(i).Item("Qtde"), ds.Tables("Prods").Rows(i).Item("ValorVenda"))
                QtdeProds += ds.Tables("Prods").Rows(i).Item("Qtde")
                VlrProds += ds.Tables("Prods").Rows(i).Item("ValorVenda")
            Else
                strSql = "Select tblProdutos_Local.IDProduto, tblCombos_Local.AgregaValor "
                strSql += "From tblProdutos_Local INNER Join tblCombos_Local On tblProdutos_Local.IDProduto = tblCombos_Local.IDProduto "
                strSql += "Where (tblProdutos_Local.IDProduto = " & ds.Tables("Prods").Rows(i).Item("IDProduto") & ")"
                AgregaValor = NuloBoolean(PegaValorCampo("AgregaValor", strSql, strCon))
                If AgregaValor = False Then
                    Vendas.Rows.Add(ds.Tables("Prods").Rows(i).Item("IDGrupo"), ds.Tables("Prods").Rows(i).Item("Grupo"), ds.Tables("Prods").Rows(i).Item("Produto"), ds.Tables("Prods").Rows(i).Item("Qtde"), ds.Tables("Prods").Rows(i).Item("ValorVenda"))
                    QtdeProds += ds.Tables("Prods").Rows(i).Item("Qtde")
                    VlrProds += ds.Tables("Prods").Rows(i).Item("ValorVenda")
                Else
                    Vendas.Rows.Add(ds.Tables("Prods").Rows(i).Item("IDGrupo"), ds.Tables("Prods").Rows(i).Item("Grupo"), ds.Tables("Prods").Rows(i).Item("Produto"), ds.Tables("Prods").Rows(i).Item("Qtde"), 0)
                    QtdeProds += ds.Tables("Prods").Rows(i).Item("Qtde")
                End If
            End If
        Next



        strSql = "SELECT tblVendasCombo.IDProduto, tblVendasCombo.Produto, SUM(tblVendasCombo.Qtd) AS Qtde, SUM(tblVendasCombo.Qtd * tblVendasCombo.Venda) AS ValorVenda, tblVendasCombo.IDGrupo, tblVendasCombo.Grupo, tblVendas.Excluido, tblVendasMovto.Excluido AS ExclidoProd "
        strSql += "FROM tblVendasCombo INNER JOIN tblVendasMovto ON tblVendasCombo.IDVendaMovto = tblVendasMovto.IDVendaMovto INNER JOIN  tblVendas ON tblVendasMovto.IDVenda = tblVendas.IDVenda "
        strSql += "WHERE (tblVendas.FlagFechada = 1) "
        strSql += "GROUP BY tblVendasCombo.IDProduto, tblVendasCombo.Produto, tblVendasCombo.IDGrupo, tblVendasCombo.Grupo, tblVendas.Excluido, tblVendasMovto.Excluido "
        strSql += "HAVING (tblVendas.Excluido = 0) AND (tblVendasMovto.Excluido = 0)"
        If CodGru <> 0 Then
            strSql += " And (tblVendasCombo.IDGrupo=" & CodGru & ")"
        End If

        Dim dapP = New SqlDataAdapter(strSql, strCon)
        dapP.SelectCommand.CommandType = CommandType.Text
        Dim dsP As New DataSet()
        dapP.Fill(dsP, "Combo")

        For i As Integer = 0 To dsP.Tables("Combo").Rows.Count - 1
            Vendas.Rows.Add(dsP.Tables("Combo").Rows(i).Item("IDGrupo"), dsP.Tables("Combo").Rows(i).Item("Grupo"), dsP.Tables("Combo").Rows(i).Item("Produto"), dsP.Tables("Combo").Rows(i).Item("Qtde"), dsP.Tables("Combo").Rows(i).Item("ValorVenda"))
            If CodGru <> 0 Then
                QtdeProds += dsP.Tables("Combo").Rows(i).Item("Qtde")
            End If
            VlrProds += dsP.Tables("Combo").Rows(i).Item("ValorVenda")
        Next



        Dim dv As New DataView
        dv = mDataSet.Tables("Vendas").DefaultView
        dv.Sort = "Valor DESC"

        For i As Integer = 0 To dv.Count - 1
            item = lstProdutos.Items.Add(NuloString(dv.Item(i).Item(0)))
            item.SubItems.Add(NuloString(dv.Item(i).Item(1)))
            item.SubItems.Add(NuloString(dv.Item(i).Item(2)))
            item.SubItems.Add(Format(NuloDecimal(dv.Item(i).Item(3)), "#0.000"))
            item.SubItems.Add(Format(NuloDecimal(dv.Item(i).Item(3)), "#0.000"))
            item.SubItems.Add(Format(NuloDecimal(dv.Item(i).Item(3)), "#0.000"))
            item.SubItems.Add(Format(NuloDecimal(dv.Item(i).Item(4)), "#0.00"))
        Next
        lstProdutos.Update()
        lstProdutos.EndUpdate()

        lbVlrTotalProdutos.Text = Format(VlrProds, "#0.00")
        lbQtdeTotalProdutos.Text = Format(QtdeProds, "#0.000")

    End Sub
    Private Sub Colorir()
        For i As Integer = 0 To lstServicoCaixinha.Items.Count - 1
            lstServicoCaixinha.Items(i).UseItemStyleForSubItems = False
            lstServicoCaixinha.Items(i).SubItems(2).ForeColor = Color.DodgerBlue
            lstServicoCaixinha.Items(i).SubItems(3).ForeColor = Color.DodgerBlue
            lstServicoCaixinha.Items(i).SubItems(4).ForeColor = Color.DodgerBlue
            lstServicoCaixinha.Items(i).SubItems(5).ForeColor = Color.DodgerBlue
            lstServicoCaixinha.Items(i).SubItems(5).Font = New Font(lstServicoCaixinha.Items(i).SubItems(5).Font, FontStyle.Bold)
        Next

    End Sub
    Private Sub porHora()

        Dim con As New SqlConnection(strCon)
        'Dim IDg As Integer = DateDiff(DateInterval.Day, tbInicio.Value, tbFim.Value) + 2
        Dim VlrHoras(23)
        Dim yColuna(23)
        Dim xLinha(23) As String

        For i = 0 To 23
            VlrHoras(i) = 0
        Next

        strSql = "Select DATEPART(HH, tblVendasMovto.HoraPedido) AS HORA, tblVendas.Excluido, SUM(tblVendasMovto.Qtd * tblVendasMovto.Venda) AS VlrVenda, tblVendasMovto.HoraPedido "
        strSql += "From tblVendas INNER Join tblFechamentos_Local On tblVendas.IDfechamento = tblFechamentos_Local.IDFechamento INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
        strSql += "Where (tblVendas.Excluido = 0) And (tblVendas.FlagFechada = 1) "
        strSql += "GROUP BY tblVendas.Excluido, tblVendasMovto.Excluido, tblVendasMovto.HoraPedido, tblVendas.FlagFechada "
        strSql += "HAVING (tblVendas.Excluido = 0) AND (tblVendasMovto.Excluido = 0)"


        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            chtHora.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            'chtHora.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            'chtHora.Palette = ChartColorPalette.Bright
            chtHora.Series(0).Font = New Font("Arial", 8, FontStyle.Regular)
            chtHora.Series(1).Font = New Font("Arial", 8, FontStyle.Regular)
            chtHora.ChartAreas(0).AxisY.IsInterlaced = True
            chtHora.ChartAreas(0).Axes(1).IsInterlaced = True

            While (dr.Read())
                If dr.Item("Hora") = 0 Then
                    VlrHoras(0) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 1 Then
                    VlrHoras(1) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 2 Then
                    VlrHoras(2) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 3 Then
                    VlrHoras(3) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 4 Then
                    VlrHoras(4) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 5 Then
                    VlrHoras(5) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 6 Then
                    VlrHoras(6) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 7 Then
                    VlrHoras(7) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 8 Then
                    VlrHoras(8) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 9 Then
                    VlrHoras(9) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 10 Then
                    VlrHoras(10) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 11 Then
                    VlrHoras(11) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 12 Then
                    VlrHoras(12) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 13 Then
                    VlrHoras(13) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 14 Then
                    VlrHoras(14) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 15 Then
                    VlrHoras(15) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 16 Then
                    VlrHoras(16) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 17 Then
                    VlrHoras(17) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 18 Then
                    VlrHoras(18) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 19 Then
                    VlrHoras(19) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 20 Then
                    VlrHoras(20) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 21 Then
                    VlrHoras(21) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 22 Then
                    VlrHoras(22) += dr.Item("VlrVenda")
                End If
                If dr.Item("Hora") = 23 Then
                    VlrHoras(23) += dr.Item("VlrVenda")
                End If
            End While
        End If

        For i = 0 To 23
            xLinha(i) = i & "h"
            yColuna(i) = VlrHoras(i)
        Next

        chtHora.Series(0).Points.DataBindXY(xLinha, yColuna)
        'chtSemanal.Series(1).Points.DataBindXY(xLinha, yColunaPes)

        comandoLJS.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()





        ' ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim conQ As New SqlConnection(strCon)
        'Dim IDg As Integer = DateDiff(DateInterval.Day, tbInicio.Value, tbFim.Value) + 2
        Dim VlrHorasQ(23)
        Dim yColunaQ(23)
        Dim xLinhaQ(23) As String
        Dim QtdePess As Integer = 0
        For i = 0 To 23
            VlrHorasQ(i) = 0
        Next

        strSql = "Select DatePart(HH, HoraAbertura) As HORA, count(IDVenda) As QtdePessoas "
        strSql += "From tblVendas "
        strSql += "Where (Excluido = 0) And (FlagFechada = 1) "
        strSql += "Group By DatePart(HH, HoraAbertura) "
        strSql += "Order By HORA"

        conQ.Open()
        Dim cmd As New SqlCommand(strSql, conQ)
        cmd.CommandType = CommandType.Text
        Dim drQ As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drQ.HasRows Then
            While (drQ.Read())
                If drQ.Item("Hora") = 0 Then
                    VlrHorasQ(0) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 1 Then
                    VlrHorasQ(1) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 2 Then
                    VlrHorasQ(2) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 3 Then
                    VlrHorasQ(3) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 4 Then
                    VlrHorasQ(4) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 5 Then
                    VlrHorasQ(5) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 6 Then
                    VlrHorasQ(6) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 7 Then
                    VlrHorasQ(7) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 8 Then
                    VlrHorasQ(8) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 9 Then
                    VlrHorasQ(9) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 10 Then
                    VlrHorasQ(10) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 11 Then
                    VlrHorasQ(11) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 12 Then
                    VlrHorasQ(12) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 13 Then
                    VlrHorasQ(13) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 14 Then
                    VlrHorasQ(14) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 15 Then
                    VlrHorasQ(15) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 16 Then
                    VlrHorasQ(16) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 17 Then
                    VlrHorasQ(17) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 18 Then
                    VlrHorasQ(18) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 19 Then
                    VlrHorasQ(19) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 20 Then
                    VlrHorasQ(20) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 21 Then
                    VlrHorasQ(21) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 22 Then
                    VlrHorasQ(22) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
                If drQ.Item("Hora") = 23 Then
                    VlrHorasQ(23) += drQ.Item("QtdePessoas")
                    QtdePess += drQ.Item("QtdePessoas")
                End If
            End While
        End If

        For i = 0 To 23
            xLinhaQ(i) = i & "h"
            yColunaQ(i) = VlrHorasQ(i)
        Next

        chtHora.Series(1).Points.DataBindXY(xLinhaQ, yColunaQ)
        'chtSemanal.Series(1).Points.DataBindXY(xLinha, yColunaPes)

        cmd.Dispose()
        drQ.Close()
        conQ.Dispose()
        conQ.Close()

        lbQtdePess.Text = QtdePess

    End Sub
    Private Sub PreencheListaServico()
        Dim item As ListViewItem
        Dim VlrVendas As Decimal = 0
        Dim VlrTotal As Decimal = 0
        Dim VlrServico As Decimal = 0
        Dim VlrServicoAjustado As Decimal = 0
        Dim VlrTaxaEntrega As Decimal = 0
        Dim VlrCaixinha As Decimal = 0
        Dim Qtde As Integer = 0

        If NuloString(frmCaixa.lbIDFechamento.Text) = "" Then
            strSql = "Select SUM(tblVendas.TotalProdutos) As Vendas, SUM(tblVendas.Servico) As Servico, SUM(tblVendas.Caixinha) As Caixinha, tblFuncionarios_Local.Funcionario, SUM(tblVendas.TaxaEntrega) AS TXEntrega, COUNT(tblVendas.IDVenda) AS Qtde, tblVendas.Excluido "
            strSql += "From tblVendas INNER Join tblFuncionarios_Local On tblVendas.IDFuncionarioAtendente = tblFuncionarios_Local.IDFuncionario "
            strSql += "Where (tblVendas.Excluido=0) "
            strSql += "Group By tblFuncionarios_Local.Funcionario, tblVendas.Excluido "
            strSql += "Order By Vendas DESC"
        Else
            strSql = "Select SUM(tblVendas.TotalProdutos) As Vendas, SUM(tblVendas.Servico) As Servico, SUM(tblVendas.Caixinha) As Caixinha, tblFuncionarios_Local.Funcionario, SUM(tblVendas.TaxaEntrega) AS TXEntrega, COUNT(tblVendas.IDVenda) AS Qtde, tblVendas.Excluido "
            strSql += "From tblVendas INNER Join tblFuncionarios_Local On tblVendas.IDFuncionarioAtendente = tblFuncionarios_Local.IDFuncionario "
            strSql += "Where (tblVendas.IDfechamento = " & frmCaixa.lbIDFechamento.Text & ") AND (tblVendas.Excluido=0) "
            strSql += "Group By tblFuncionarios_Local.Funcionario, tblVendas.Excluido "
            strSql += "Order By Vendas DESC"
        End If


        If NuloString(frmCaixa.lbIDFechamento.Text) = "" Then
            strSql = "Select SUM(TotalProdutos) As Vendas, SUM(QtdPessoas) As Qtde, Excluido, SUM(Servico) As Servico, SUM(Caixinha) As Caixinha, Case When StatusVenda = 'D' THEN Entregador ELSE Atendente END AS Funcionario, SUM(TaxaEntrega) As TXEntrega "
            strSql += "From tblVendas "
            strSql += "Group By Excluido, CASE WHEN StatusVenda = 'D' THEN Entregador ELSE Atendente END HAVING(Excluido = 0) And (Case When StatusVenda = 'D' THEN Entregador ELSE Atendente END IS NOT NULL) "
        Else
            strSql = "Select IDFechamento, SUM(TotalProdutos) As Vendas, SUM(QtdPessoas) As Qtde, Excluido, SUM(Servico) As Servico, SUM(Caixinha) As Caixinha, Atendente as Funcionario, SUM(TaxaEntrega) As TXEntrega "
            strSql += "From tblVendas "
            strSql += "Group By IDFechamento, Excluido, Atendente "
            strSql += "HAVING(Excluido = 0) And (IDfechamento = " & frmCaixa.lbIDFechamento.Text & ") "
        End If
        strSql += "ORDER BY Servico"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstServicoCaixinha.Items.Clear()
        Dim Fator As Decimal
        Dim Total As Decimal
        If dr.HasRows Then
            While dr.Read()
                Total = 0
                Fator = 0
                item = lstServicoCaixinha.Items.Add(dr.Item("Funcionario"))

                item.SubItems.Add(Format(NuloDecimal(dr.Item("Servico")), "#0.00"))
                VlrServico += NuloDecimal(dr.Item("Servico"))

                Fator = Format(NuloDecimal(dr.Item("Servico")) - (NuloDecimal(dr.Item("Servico")) * ((FatorAjusteServico) / 100)), "#0.00")
                item.SubItems.Add(Format(NuloDecimal(Fator), "#0.00"))
                VlrServicoAjustado += NuloDecimal(Fator)

                item.SubItems.Add(Format(NuloDecimal(dr.Item("Caixinha")), "#0.00"))
                VlrCaixinha += NuloDecimal(dr.Item("Caixinha"))

                item.SubItems.Add(Format(NuloDecimal(dr.Item("TXEntrega")), "#0.00"))
                VlrTaxaEntrega += NuloDecimal(dr.Item("TXEntrega"))

                Total = Fator + NuloDecimal(dr.Item("Caixinha")) + NuloDecimal(dr.Item("TXEntrega"))
                item.SubItems.Add(Format(Total, "#0.00"))
                VlrTotal += Total

                item.SubItems.Add(Format(NuloDecimal(dr.Item("Vendas")), "#0.00"))
                VlrVendas += NuloDecimal(dr.Item("Vendas"))

                item.SubItems.Add(Format(NuloDecimal(dr.Item("Qtde")), "#0"))
                Qtde += NuloDecimal(dr.Item("Qtde"))



            End While
            lstVendas.Update()
            lstVendas.EndUpdate()
        End If

        lbVlrVendas.Text = Format(VlrVendas, "#0.00")
        lbVlrServico.Text = Format(VlrServico, "#0.00")
        lbVlrServicoAjustado.Text = Format(VlrServicoAjustado, "#0.00")
        lbVlrCaixinha.Text = Format(VlrCaixinha, "#0.00")
        lbVlrTxEntrega.Text = Format(VlrTaxaEntrega, "#0.00")
        lbVlrTotal.Text = Format(VlrTaxaEntrega + VlrCaixinha + VlrServicoAjustado, "#0.00")
        lbQtde.Text = Format(Qtde, "#0")

        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        Colorir()

    End Sub
    Private Sub PreencheListaVendas()
        Dim item As ListViewItem
        Dim Vlr As Decimal = 0

        If NuloString(frmCaixa.lbIDFechamento.Text) = "" Then
            strSql = "Select SUM(ValorPago) As Valor "
            strSql += "From tblVendasPagto "
        Else
            strSql = "Select SUM(tblVendasPagto.ValorPago) As Valor, tblVendas.IDfechamento "
            strSql += "From tblVendasPagto INNER Join tblVendas On tblVendasPagto.IDVenda = tblVendas.IDVenda "
            strSql += "Group By tblVendas.IDfechamento "
            strSql += "HAVING(tblVendas.IDfechamento = " & NuloInteger(frmCaixa.lbIDFechamento.Text) & ")"
        End If
        Vlr = NuloDecimal(PegaValorCampo("Valor", strSql, strCon))

        If NuloString(frmCaixa.lbIDFechamento.Text) = "" Then
            strSql = "Select Descricao, SUM(ValorPago) As Valor "
            strSql += "From tblVendasPagto "
            strSql += "Group By Descricao "
            strSql += "Order By Valor DESC"
        Else
            strSql = "Select tblVendasPagto.Descricao, SUM(tblVendasPagto.ValorPago) As Valor, tblVendas.IDfechamento "
            strSql += "From tblVendasPagto INNER Join tblVendas On tblVendasPagto.IDVenda = tblVendas.IDVenda "
            strSql += "Group By tblVendasPagto.Descricao, tblVendas.IDfechamento "
            strSql += "HAVING(tblVendas.IDfechamento = " & NuloInteger(frmCaixa.lbIDFechamento.Text) & ")"
            strSql += "ORDER BY Valor DESC"
        End If

        Dim Percent As Integer
        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstVendas.Items.Clear()

        If dr.HasRows Then
            While dr.Read()
                Percent = (NuloDecimal(dr.Item("Valor")) / Vlr) * 100
                item = lstVendas.Items.Add(dr.Item("Descricao"))
                item.SubItems.Add(NuloDecimal(dr.Item("Valor")))
                item.SubItems.Add(Percent)
            End While
            lstVendas.Update()
            lstVendas.EndUpdate()
        End If
        lbTotalVenda.Text = Format(Vlr, "#0.00")
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()



        lbServico.Text = "0.00"
        lbDesconto.Text = "0.00"
        lbCaixainha.Text = "0.00"
        lbTaxaEntrega.Text = "0.00"


        strSql = "Select FlagFechada, Excluido, SUM(TotalVenda) As TotalVenda, SUM(Servico) As Servico, SUM(Caixinha) As Caixinha, SUM(TaxaEntrega) As TaxaEntrega, SUM(QtdPessoas) As QtdePessoas, SUM(Desconto) As Descontos "
        If NuloString(frmCaixa.lbIDFechamento.Text) <> "" Then
            strSql += ", IDfechamento "
        End If
        strSql += "From tblVendas "
        strSql += "Group By FlagFechada, Excluido "
        If NuloString(frmCaixa.lbIDFechamento.Text) <> "" Then
            strSql += ", IDfechamento "
        End If
        strSql += "HAVING (FlagFechada = 1) And (Excluido = 0)"
        If NuloString(frmCaixa.lbIDFechamento.Text) <> "" Then
            strSql += "And (IDfechamento = " & NuloInteger(frmCaixa.lbIDFechamento.Text) & ")"
        End If


        Dim conV As New SqlConnection(strCon)
        conV.Open()
        Dim cmdV As New SqlCommand(strSql, conV)
        cmdV.CommandType = CommandType.Text
        Dim drV As SqlDataReader = cmdV.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drV.HasRows Then
            drV.Read()
            lbServico.Text = Format(NuloDecimal(drV.Item("Servico")), "#0.00")
            lbCaixainha.Text = Format(NuloDecimal(drV.Item("Caixinha")), "#0.00")
            lbTaxaEntrega.Text = Format(NuloDecimal(drV.Item("TaxaEntrega")), "#0.00")
            lbDesconto.Text = Format(NuloDecimal(drV.Item("Descontos")), "#0.00")
        End If

        lbVendaLiquida.Text = Format(lbTotalVenda.Text - lbServico.Text - lbCaixainha.Text - lbTaxaEntrega.Text + lbDesconto.Text, "#0.00")

        strSql = "Select SUM(tblVendasMovto.Qtd * tblVendasMovto.Venda) As VendaAberta, tblVendasMovto.Excluido "
        strSql += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        strSql += "Group By tblVendasMovto.Excluido, tblVendas.FlagFechada "
        strSql += "HAVING(tblVendas.FlagFechada = 0) And (tblVendasMovto.Excluido = 0)"
        lbVendasAberto.Text = Format(NuloDecimal(PegaValorCampo("VendaAberta", strSql, strCon)), "#0.00")
        lbVendaTotal.Text = Format(NuloDecimal(lbVendaLiquida.Text) + NuloDecimal(lbVendasAberto.Text), "#0.00")
        lbVlrTot.Text = Format(NuloDecimal(lbVendaLiquida.Text) + NuloDecimal(lbVendasAberto.Text), "#0.00")

        drV.Close()
        cmdV.Dispose()
        conV.Dispose()
        conV.Close()

    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgVisualizaVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If NuloString(frmCaixa.cbMovto.Text) = "" Then
            lbMovto.Text = "TODOS"
        Else
            lbMovto.Text = Trim(Strings.Left(NuloString(frmCaixa.cbMovto.Text), 60))
        End If

        PreencheListaVendas()
        porHora()
        porModulo()
        PreencheListaServico()
        PreencheListaProdutos()
        PreecheGrupos()
        If NuloInteger(lbQtdePess.Text) > 0 Then
            lbMedia.Text = Format(NuloDecimal(lbVlrTot.Text) / NuloInteger(lbQtdePess.Text), "#0.00")
        Else
            lbMedia.Text = ""
        End If

        rbPorHora.Checked = True
        chtHora.Visible = True
        chtModulos.Visible = False
    End Sub
    Private Sub PreecheGrupos()
        strSql = "Select Grupo, CodigoGrupo FROM tblGrupos_Local ORDER BY Grupo"
        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim comandoCat As New SqlCommand(strSql, con)
        comandoCat.CommandType = CommandType.Text

        Dim drLinha As SqlDataReader = comandoCat.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Tipos As New ArrayList()
        With drLinha
            If .HasRows Then
                Tipos.Add("")
                While (.Read())
                    Tipos.Add(.GetString(0) & Space(100) & .GetInt32(1))
                End While

            End If
            cbGrupos.DataSource = Tipos
            .Close()
        End With
        con.Close()
    End Sub

    Private Sub CbGrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrupos.SelectedIndexChanged
        PreencheListaProdutos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CriaRelatServicoCaixinha(NuloInteger(frmCaixa.lbIDFechamento.Text))
        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\servico.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If
    End Sub

    Private Sub chtModulos_Click(sender As Object, e As EventArgs) Handles chtModulos.Click

    End Sub

    Private Sub rbPorHora_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorHora.CheckedChanged
        If rbPorHora.Checked = False Then
            chtHora.Visible = False
            chtModulos.Visible = True
            Panel7.Visible = False
            Panel4.Visible = True
        Else
            chtHora.Visible = True
            chtModulos.Visible = False
            Panel7.Visible = True
            Panel4.Visible = False
        End If
    End Sub

    Private Sub rbPorModulo_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorModulo.CheckedChanged
        If rbPorHora.Checked = False Then
            chtHora.Visible = False
            chtModulos.Visible = True
            Panel7.Visible = False
            Panel4.Visible = True
        Else
            chtHora.Visible = True
            chtModulos.Visible = False
            Panel7.Visible = True
            Panel4.Visible = False
        End If
    End Sub
End Class