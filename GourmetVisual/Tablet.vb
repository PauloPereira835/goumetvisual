Imports System.Data.SqlClient

Module Tablet
    Function AtualizaFamilias()
        Dim conSQL As New SqlConnection
        Dim dr As SqlDataReader
        Dim strSql As String

        strSql = "Truncate table tb_Familia"
        ExecutaStr(strSql)

        strSql = "Truncate table tb_Familia_Detalhe"
        ExecutaStr(strSql)


        conSQL.ConnectionString = strCon
        Dim cmd As SqlCommand = conSQL.CreateCommand
        cmd.CommandText = ("SELECT IDFamilia, Familia FROM tblFamilias_Local;")
        conSQL.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        While dr.Read
            strSql = "INSERT tb_Familia (ID_Familia, Descricao) VALUES ("
            strSql += to_sql(dr.Item("IDFamilia")) & ", "
            strSql += to_sql(UCase(dr.Item("Familia"))) & ")"
            ExecutaStr(strSql)
        End While
        dr.Close()
        cmd.Dispose()
        'conSQL.Dispose()
        'conSQL.Close()

        'conSQL.ConnectionString = strCon
        Dim drD As SqlDataReader
        Dim cmdD As SqlCommand = conSQL.CreateCommand
        cmdD.CommandText = ("SELECT * FROM tblComentarios_Local;")
        conSQL.Open()
        drD = cmdD.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        While drD.Read
            strSql = "INSERT tb_Familia_Detalhe (ID_Familia, Descricao, Valor, ID_Produto) VALUES ("
            strSql += to_sql(drD.Item("IDFamilia")) & ", "
            strSql += to_sql(UCase(drD.Item("Comentario"))) & ", 0, 0)"
            ExecutaStr(strSql)
        End While
        drD.Close()
        cmdD.Dispose()
        conSQL.Dispose()
        conSQL.Close()

    End Function

    Function AtualizaGrupo()
        Dim conSQL As New SqlConnection
        Dim dr As SqlDataReader

        strSql = "Truncate table tb_Categoria"
        ExecutaStr(strSql)

        conSQL.ConnectionString = strCon
        Dim cmd As SqlCommand = conSQL.CreateCommand
        strSql = "Select CodigoGrupo, Grupo, DescricaoResumida, MostraTouch "
        strSql += "From tblGrupos_Local "
        strSql += "Where (DescricaoResumida Is Not NULL) And (MostraMovel = 1) "
        strSql += "Order By DescricaoResumida"
        cmd.CommandText = strSql

        conSQL.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        While dr.Read
            strSql = "INSERT tb_Categoria (Descricao, IDDepartamento, IDCategoria) VALUES ("
            strSql += to_sql(dr.Item("DescricaoResumida")) & ", "
            strSql += "1, "
            strSql += to_sql(dr.Item("CodigoGrupo")) & ")"
            ExecutaStr(strSql)
        End While

        dr.Close()
        conSQL.Dispose()
        conSQL.Close()

        Return IDGrupo
    End Function

    Public Sub AtualizaMontagem()

        Dim CodPro As Integer
        Dim IDComb As Integer
        Dim IDCombM As Integer = 1

        strSql = "Select tblCombos_Local.IDCombo, tblProdutos_Local.CodigoProduto, tblCombos_Local.IDFamilia "
        strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto "
        strSql += "Order By tblCombos_Local.IDCombo, tblProdutos_Local.CodigoProduto"

        'strSql = "Select tblCombos_Local.IDCombo, tblProdutos_Local.CodigoProduto, tblCombos_Local.IDFamilia "
        'strSql += "From tblCombos_Local INNER Join tblProdutos_Local On tblCombos_Local.IDProduto = tblProdutos_Local.IDProduto "
        'strSql += "Group By tblCombos_Local.IDCombo, tblProdutos_Local.CodigoProduto, tblCombos_Local.IDFamilia "
        'strSql += "Order By tblCombos_Local.IDCombo, tblProdutos_Local.CodigoProduto"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Combo")
        For i As Integer = 0 To ds.Tables("Combo").Rows.Count - 1
            CodPro = ds.Tables("Combo").Rows(i).Item("CodigoProduto")
            While CodPro = ds.Tables("Combo").Rows(i).Item("CodigoProduto")
                strSql = "INSERT tb_montagem (IDmontagem, IDproduto) VALUES ("
                strSql += to_sql(ds.Tables("Combo").Rows(i).Item("IDCombo")) & ","
                strSql += to_sql(ds.Tables("Combo").Rows(i).Item("CodigoProduto")) & ")"
                ExecutaStr(strSql)
                IDComb = ds.Tables("Combo").Rows(i).Item("IDCombo")

                strSql = "INSERT tb_montagemDescricao (IDmontagemDescricao, IDmontagem, IDfamilia) VALUES ("
                strSql += to_sql(IDCombM) & ","
                strSql += to_sql(IDComb) & ","
                strSql += to_sql(ds.Tables("Combo").Rows(i).Item("IDFamilia")) & ")"
                ExecutaStr(strSql)
                IDCombM += 1
                If (i + 1) > ds.Tables("Combo").Rows.Count - 1 Then Exit While
                i += 1
                If CodPro <> ds.Tables("Combo").Rows(i).Item("CodigoProduto") Then
                    i -= 1
                    Exit While
                End If

            End While

        Next
        ds.Dispose()
        dap.Dispose()


    End Sub
    Public Sub AtualizaClientes()
        Dim conn As New SqlConnection
        Dim strSql As String

        conn.ConnectionString = strCon
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Select * FROM tblClientes WHERE NomeCliente<>''"
        conn.Open()

        Dim leitor As SqlDataReader = cmd.ExecuteReader()

        Try
            While leitor.Read()

                strSql = "INSERT tb_clientes (ClienteID, Cliente, CartaoPref) VALUES ("
                strSql += to_sql(leitor.Item("IDCliente")) & ","
                strSql += to_sql(Trim(leitor.Item("NomeCliente"))) & ","
                If IsDBNull(leitor.Item("CartaoPref")) Then
                    strSql += "'')"
                Else
                    strSql += to_sql(leitor.Item("CartaoPref")) & ")"
                End If
                ExecutaStr(strSql)
            End While

        Catch erro As Exception
            MsgBox("Erro " & vbCrLf & erro.ToString, MsgBoxStyle.Critical, "Erro")

        Finally
            leitor.Close()
            conn.Close()
            conn.Dispose()
        End Try


    End Sub
    Public Sub AtualizaDescricaoFamilias()
        Dim conn As New SqlConnection

        conn.ConnectionString = strCon
        Dim cmd As SqlCommand = conn.CreateCommand
        strSql = "Select tblComentarios_Local.IDFamilia, tblComentarios_Local.Comentario, tblProdutos_Local.CodigoProduto "
        strSql += "From tblComentarios_Local INNER Join tblFamilias_Local On tblComentarios_Local.IDFamilia = tblFamilias_Local.IDFamilia INNER Join tblProdutos_Local On tblComentarios_Local.IDProduto = tblProdutos_Local.IDProduto"
        cmd.CommandText = strSql

        conn.Open()

        Dim leitor As SqlDataReader = cmd.ExecuteReader()

        Try
            While leitor.Read()
                strSql = "INSERT tb_Familia_Detalhe (ID_Familia, Descricao) VALUES ("
                strSql += to_sql(leitor.Item("IDFamilia")) & ","
                strSql += to_sql(leitor.Item("Comentario")) & ")"
                ExecutaStr(strSql)
            End While

        Catch erro As Exception
            MsgBox("Erro " & vbCrLf & erro.ToString, MsgBoxStyle.Critical, "Erro")

        Finally
            leitor.Close()
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Private Sub MonitoraMesa(NMesa As Integer)
        Dim conSQL As New SqlConnection
        Dim dr As SqlDataReader
        Dim QtdePess As Integer = 1
        Dim strSql As String
        Dim ImpCta As Integer = 0
        Dim DescPro As String = ""
        Dim IDMovto As Integer

        If NMesa < 0 Then
            NMesa = NMesa * -1
            ImpCta = 1
        End If

        Dim conSQLAc1 As New SqlConnection
        Dim connAc1 As New SqlConnection
        connAc1.ConnectionString = strCon
        Dim cmdAc1 As SqlCommand = connAc1.CreateCommand
        cmdAc1.CommandText = "SELECT tblVendas.NumMesa, tblVendas.FlagFechada, tblVendas.QtdPessoas FROM tblVendas WHERE ((tblVendas.NumMesa=" & NMesa & ") AND (tblVendas.FlagFechada=0));"

        connAc1.Open()
        Dim leitorM As SqlDataReader = cmdAc1.ExecuteReader()
        If leitorM.HasRows Then
            leitorM.Read()
            QtdePess = leitorM("QtdPessoas")
        Else
            NMesa = 0
        End If

        cmdAc1.Dispose()
        leitorM.Close()
        connAc1.Dispose()
        connAc1.Close()

        conSQL.ConnectionString = strCon
        Dim cmd As SqlCommand = conSQL.CreateCommand
        cmd.CommandText = "SELECT * FROM tb_Pocket_Pedido WHERE mesa = " & NMesa

        If NMesa <> 0 Then
            conSQL.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                strSql = "UPDATE tb_Pocket_Pedido SET "
                strSql &= "FecharMesa=0, "
                strSql &= "TravaMesa=" & ImpCta & ", "
                strSql &= "Qtd_Pessoas=" & QtdePess
                strSql &= "WHERE (mesa= " & NMesa & ")"
                ExecutaStr(strSql)
            Else
                'Dim con As New SqlConnection(strCon)
                strSql = "Insert tb_Pocket_Pedido (Mesa,  Imprimir, FecharMesa, TravaMesa, Qtd_Pessoas) Values ("
                strSql &= to_sql(NMesa) & ", "
                strSql &= "0, "
                strSql &= "0, "
                If ImpCta = 0 Then
                    strSql &= "0, "
                Else
                    strSql &= "1, "
                End If
                strSql &= to_sql(QtdePess) & ")"
                ExecutaStr(strSql)
            End If

            strSql = "Delete From tb_pocket_pedido_item where mesa=" & NMesa
            ExecutaStr(strSql)



            strSql = "Select tblVendas.IDVenda, tblVendas.NumMesa, tblVendas.FlagFechada, tblVendasMovto.IDVendaMovto, tblProdutos_Local.CodigoProduto, tblProdutos_Local.Produto, tblVendasMovto.Qtd, tblVendasMovto.Venda, tblVendasMovto.Excluido, tblVendasComent.Coment "
            strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto LEFT OUTER Join tblVendasComent On tblVendasMovto.IDVendaMovto = tblVendasComent.IDVendaMovto "
            strSql += "Where (tblVendas.NumMesa = " & NMesa & ") And (tblVendas.FlagFechada = 0) And (tblVendasMovto.Excluido = 0) "
            strSql += "Order By tblProdutos_Local.Produto"

            Dim iOK As Integer
            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Vendas")
            For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
                DescPro = ""
                iOK = i
                If Not IsDBNull(ds.Tables("Vendas").Rows(i).Item("Coment")) Then
                    DescPro = ds.Tables("Vendas").Rows(i).Item("Coment")
                End If
                IDMovto = ds.Tables("Vendas").Rows(i).Item("IDVendaMovto")
                'If (i + 1) <= ds.Tables("Vendas").Rows.Count - 1 Then
                For ii As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1
                    If IsDBNull(ds.Tables("Vendas").Rows(ii).Item("Coment")) And IDMovto = ds.Tables("Vendas").Rows(ii).Item("IDVendaMovto") Then
                        DescPro += " / " & ds.Tables("Vendas").Rows(i).Item("Coment")
                        i += 1
                    End If

                Next
                'While Not IsDBNull(ds.Tables("Vendas").Rows(i + 1).Item("Coment")) And IDMovto = ds.Tables("Vendas").Rows(i + 1).Item("IDVendaMovto")
                'DescPro += " / " & ds.Tables("Vendas").Rows(i).Item("Coment")
                'i += 1
                'End While
                'End If

                strSql = "INSERT tb_Pocket_Pedido_Item (mesa,IDproduto,Qtd_Produto,lancado,impresso, Produto, DescricaoLancto, PrecoVenda) VALUES ("
                    strSql += to_sql(NMesa) & ","
                    strSql += to_sql(ds.Tables("Vendas").Rows(iOK).Item("CodigoProduto")) & ","
                    strSql += to_sql(Replace(ds.Tables("Vendas").Rows(iOK).Item("Qtd"), ",", ".")) & ","
                    strSql += "0,"
                    strSql += "1,"
                    strSql += to_sql(ds.Tables("Vendas").Rows(iOK).Item("Produto")) & ","
                    strSql += to_sql(DescPro) & ","
                    strSql += to_sql(Replace(ds.Tables("Vendas").Rows(iOK).Item("Venda"), ",", ".")) & ")"
                    ExecutaStr(strSql)

                Next
                dap.Dispose()
            ds.Dispose()
        End If

        strSql = "UPDATE tblStatusTablet SET "
        strSql &= "StatusTablet='' "
        ExecutaStr(strSql)


        cmdAc1.Dispose()
        conSQL.Close()
        conSQL.Dispose()


    End Sub
    Public Sub AtualizaMesas()
        Dim connAc As New SqlConnection

        connAc.ConnectionString = strCon
        Dim cmdAc As SqlCommand = connAc.CreateCommand
        cmdAc.CommandText = "SELECT tblMesas.NumMesa, tblMesas.Flag, tblMesas.Impresso FROM tblMesas WHERE ((tblMesas.Flag=1));"
        connAc.Open()

        Dim leitorM As SqlDataReader = cmdAc.ExecuteReader()
        While leitorM.Read()
            If NuloBoolean(leitorM("Impresso")) = False Then
                MonitoraMesa(leitorM("NumMesa"))
            Else
                MonitoraMesa(leitorM("NumMesa") * -1)
            End If
        End While

        leitorM.Close()
        cmdAc.Dispose()
        connAc.Close()
        connAc.Dispose()

    End Sub
    Public Sub AtualizaFunc()
        'Dim conSQL As New SqlConnection
        Dim conn As New SqlConnection

        conn.ConnectionString = strCon
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "SELECT Funcionario, CodigoFuncionario, Senha FROM tblFuncionarios_Local"
        conn.Open()

        Dim leitor As SqlDataReader = cmd.ExecuteReader()

        Try

            While leitor.Read()
                strSql = "INSERT tb_Funcionario (IDFuncionario,Nome,Tablet_Senha,IDCargo) VALUES ("
                strSql += to_sql(leitor.Item("CodigoFuncionario")) & ","
                strSql += to_sql(leitor.Item("Funcionario")) & ","
                If IsDBNull(leitor.Item("Senha")) Then
                    strSql += "'',"
                Else
                    strSql += to_sql(leitor.Item("Senha")) & ","
                End If
                strSql = strSql & "1)"
                ExecutaStr(strSql)
            End While

        Catch erro As Exception
            MsgBox("Erro " & vbCrLf & erro.ToString, MsgBoxStyle.Critical, "Erro")

        Finally
            leitor.Close()
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Public Sub AtualizaProdutos()

        Dim conn As New SqlConnection
        conn.ConnectionString = strCon
        Dim cmd As SqlCommand = conn.CreateCommand

        strSql = "Select tblProdutos_Local.CodigoProduto, tblProdutos_Local.CodigoGrupo, tblProdutos_Local.Produto, tblProdutos_Local.IDFamilia, tblProdutos_Local.Venda, tblProdutos_Local.ForaLinha, tblProdutos_Local.InformaVenda, tblGrupos_Local.MostraMovel, tblProdutos_Local.[Top], tblProdutos_Local.DescricaoResumida "
        strSql += "From tblProdutos_Local INNER Join tblGrupos_Local On tblProdutos_Local.CodigoGrupo = tblGrupos_Local.CodigoGrupo "
        'strSql += "Where (tblProdutos_Local.Produto Is Not NULL) And (tblGrupos_Local.MostraMovel = 1) AND (tblProdutos_Local.Modulos <> 'D') AND (tblProdutos_Local.ForaLinha = 0)"
        strSql += "Where (tblProdutos_Local.Produto Is Not NULL) And (tblProdutos_Local.Modulos <> 'D') AND (tblProdutos_Local.ForaLinha = 0)"
        cmd.CommandText = strSql

        conn.Open()

        Dim leitor As SqlDataReader = cmd.ExecuteReader()

        While leitor.Read()
            strSql = "INSERT tb_Produtos (IDProduto,IDCategoria,Produto,PrecoVenda,IDFamilia,Dis_Cardapio,IDDepartamento,Ativo,produto_top,HoraLimite,MontaCheckListVenda) VALUES ("
            strSql += to_sql(leitor.Item("CodigoProduto")) & ","
            strSql += to_sql(leitor.Item("CodigoGrupo")) & ","
            strSql += to_sql(leitor.Item("Produto")) & ","
            strSql += to_sql(Replace(Replace(leitor.Item("Venda"), ".", ""), ",", ".")) & ","
            strSql += to_sql(leitor.Item("IDFamilia")) & ", "
            strSql += "1, "
            strSql += "1, "
            strSql += "1,"
            If IsDBNull(leitor.Item("Top")) Then
                strSql += "0,"
            Else
                strSql += to_sql(leitor.Item("Top")) & ","
            End If
            strSql += "'',"
            strSql += "0)"
            ExecutaStr(strSql)
        End While

        leitor.Close()
        conn.Close()
        conn.Dispose()


    End Sub
    Public Sub AtualizaCampo()
        Dim NomeCampo As String

        NomeCampo = "MontaCheckListVenda"
        If ExisteCampo("tb_Produtos", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Produtos ADD " & NomeCampo & " bit NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "Mesa_Cartao"
        If ExisteCampo("tb_Pocket_Pedido", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Pocket_Pedido ADD " & NomeCampo & " varchar(10) NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "FecharMesa"
        If ExisteCampo("tb_Pocket_Pedido", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Pocket_Pedido ADD " & NomeCampo & " bit NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "DescricaoLancto"
        If ExisteCampo("tb_Pocket_Pedido_Item", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Pocket_Pedido_Item ADD " & NomeCampo & " varchar(100) NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "ObsMontagem"
        If ExisteCampo("tb_Pocket_Pedido_Item", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Pocket_Pedido_Item ADD " & NomeCampo & " varchar(50) NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "IDcliente"
        If ExisteCampo("tb_Pocket_Pedido_Item", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Pocket_Pedido_Item ADD " & NomeCampo & " int NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "produto_top"
        If ExisteCampo("tb_Produtos", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Produtos ADD " & NomeCampo & " bit NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "HoraLimite"
        If ExisteCampo("tb_Produtos", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Produtos ADD " & NomeCampo & " time NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "IDDepartamento"
        If ExisteCampo("tb_Categoria", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Categoria ADD " & NomeCampo & " int NULL"
            CriaTabela(strSql)
        End If

        NomeCampo = "MostraMovel"
        If ExisteCampo("tb_Categoria", NomeCampo) = False Then
            strSql = "ALTER TABLE tb_Categoria ADD " & NomeCampo & " bit NULL"
            CriaTabela(strSql)
        End If
    End Sub
    Function ExisteCampo(Nome_Tabela As String, Campo As String)

        Dim columna As Data.DataColumn
        Dim i, j As Integer
        Dim nomCol() As String
        Dim comandoSQL = "Select * from " & Nome_Tabela
        Dim Retorno As Boolean = False

        Dim da As New SqlDataAdapter(comandoSQL, strCon)
        Dim dbDataset As New DataSet(Nome_Tabela)

        da.Fill(dbDataset, Nome_Tabela)

        j = dbDataset.Tables(Nome_Tabela).Columns.Count - 1
        ReDim nomCol(j)
        For i = 0 To j
            columna = dbDataset.Tables(Nome_Tabela).Columns(i)
            nomCol(i) = columna.ColumnName

            If UCase(columna.ColumnName) = UCase(Campo) Then
                Return True
            End If
        Next

        Return False

    End Function
    Public Sub Limpa_Cria_TabelasSQL()

        Dim conSQL As New SqlConnection
        Dim conExc As New SqlConnection
        Dim cmdExc As New SqlCommand
        Dim strSql As String

        If ExisteTabela("tb_Produtos") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Produtos"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Produtos("
            strSql &= "IDproduto int NULL,"
            strSql &= "IDdepartamento int NULL,"
            strSql &= "IDcategoria int NULL,"
            strSql &= "IDfamilia int NULL,"
            strSql &= "Ativo bit NULL,"
            strSql &= "Produto varchar(80) NULL,"
            strSql &= "PrecoVenda decimal(18,2) NULL,"
            strSql &= "Dis_Cardapio bit NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_Funcionario") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Funcionario"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Funcionario("
            strSql &= "IDfuncionario int NULL,"
            strSql &= "Nome varchar(50) NULL,"
            strSql &= "Ativo bit NULL,"
            strSql &= "IDcargo int NULL,"
            strSql &= "tablet_senha varchar(50) NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_Categoria") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Categoria"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Categoria("
            strSql &= "IDcategoria int NULL,"
            strSql &= "Descricao varchar(50) NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_Familia") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Familia"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Familia("
            strSql &= "ID_Familia int NULL,"
            strSql &= "Descricao varchar(50) NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_Familia_Detalhe") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Familia_Detalhe"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Familia_Detalhe("
            strSql &= "ID int NOT NULL primary key IDENTITY,"
            strSql &= "ID_Familia int NULL,"
            strSql &= "Descricao varchar(50) NULL,"
            strSql &= "Valor decimal(18,2) NULL,"
            strSql &= "ID_Produto int NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_Pocket_Pedido") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Pocket_Pedido"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Pocket_Pedido("
            strSql &= "mesa int NULL,"
            strSql &= "IDfuncionario int NULL,"
            strSql &= "Qtd_Pessoas decimal(18,2) NULL,"
            strSql &= "imprimir bit NULL,"
            strSql &= "fechamesa bit NULL,"
            strSql &= "MesaAberta bit NULL,"
            strSql &= "IDPedido int NULL,"
            strSql &= "TravaMesa bit NULL,"
            strSql &= "modulo int NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_Pocket_Pedido_Item") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_Pocket_Pedido_Item"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_Pocket_Pedido_Item("
            strSql &= "idItem int NOT NULL primary key IDENTITY,"
            strSql &= "mesa int NULL,"
            strSql &= "IDproduto int NULL,"
            strSql &= "Produto varchar(250) NULL,"
            strSql &= "PrecoVenda decimal(18,2) NULL,"
            strSql &= "Qtd_Produto decimal(18,2) NULL,"
            strSql &= "Obs varchar(500) NULL,"
            strSql &= "Lancado bit NULL,"
            strSql &= "impresso bit NULL,"
            strSql &= "IDPedido int NULL,"
            strSql &= "IDPedidoItem int NULL,"
            strSql &= "IDfuncionario int NULL,"
            strSql &= "Status varchar(1) NULL,"
            strSql &= "ObsMontagem varchar(50) NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_pocket_pedido_item_detalhe") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_pocket_pedido_item_detalhe"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_pocket_pedido_item_detalhe("
            strSql &= "IDDetalheItem int NOT NULL primary key IDENTITY,"
            strSql &= "IDDetalhe int NULL,"
            strSql &= "IDPedidoItem int NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_pocket_pedido_item_Combo") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_pocket_pedido_item_Combo"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_pocket_pedido_item_Combo("
            strSql &= "IDcombo int NOT NULL primary key IDENTITY,"
            strSql &= "IDitem int NULL,"
            strSql &= "IDproduto int NULL,"
            strSql &= "Produto varchar(50) NULL,"
            strSql &= "Obs varchar(50) NULL,"
            strSql &= "Coment1 varchar(50) NULL,"
            strSql &= "Coment2 varchar(50) NULL,"
            strSql &= "Coment3 varchar(50) NULL,"
            strSql &= "Coment4 varchar(50) NULL,"
            strSql &= "Coment5 varchar(50) NULL,"
            strSql &= "Coment6 varchar(50) NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_clientes") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_clientes"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_clientes("
            strSql &= "ClienteID int NULL,"
            strSql &= "Cliente varchar(50) NULL,"
            strSql &= "CartaoPref varchar(50) NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_montagem") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_montagem"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_montagem("
            strSql &= "IDmontagem int NULL,"
            strSql &= "IDproduto int NULL)"
            CriaTabela(strSql)
        End If

        If ExisteTabela("tb_montagemDescricao") = True Then
            conExc.ConnectionString = strCon
            conExc.Open()
            cmdExc.Connection = conExc
            cmdExc.CommandText = "TRUNCATE TABLE tb_montagemDescricao"
            cmdExc.ExecuteNonQuery()
            conExc.Dispose()
            conExc.Close()
        Else
            strSql = "CREATE TABLE tb_montagemDescricao("
            strSql &= "IDmontagemDescricao int NULL,"
            strSql &= "IDmontagem int NULL,"
            strSql &= "IDfamilia int NULL)"
            CriaTabela(strSql)
        End If

    End Sub
    Private Sub CriaTabela(striSql As String)

        Dim cn As SqlConnection = New SqlConnection(strCon)
        Dim cmd As New SqlCommand

        cmd = New SqlCommand(striSql, cn)
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()

    End Sub
    Private Function ExisteTabela(ByVal nomeTabela As String) As Boolean

        Dim tabela As New DataTable
        Dim criterioSQL As String
        criterioSQL = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_TYPE"
        Try
            Dim da As New SqlDataAdapter(criterioSQL, strCon)
            da.Fill(tabela)

            For Each dr As DataRow In tabela.Rows
                If UCase(dr("TABLE_NAME").ToString) = UCase(nomeTabela) Then
                    Return True
                End If
            Next
            Return False

        Catch ex As Exception
            MessageBox.Show("ERRO " & ex.Message, "Verifica tabela")
            Return False
        End Try
    End Function

End Module

