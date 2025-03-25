Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Xml
Imports GourmetVisual.classModelsShipay

Public Class frmConfiguracao
    Dim Atualiza As String = ""
    Private Sub PreenchePagtoApp()

        Dim DadosIF As New ArrayList()
        Dim DadosQR As New ArrayList()
        Dim DadosRA As New ArrayList()

        strSql = "Select IDFormaPagto, Descricao "
        strSql += "From tblFormaPagtos_Local "
        strSql += "Order By Descricao"

        Dim conA As New SqlConnection(strCon)
        conA.Open()
        Dim cmdA As New SqlCommand(strSql, conA)
        cmdA.CommandType = CommandType.Text

        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        cbIDFormaPagtoDefaultRappi.Items.Clear()

        DadosIF.Add("")
        DadosQR.Add("")
        DadosRA.Add("")

        If drA.HasRows Then
            While drA.Read()
                DadosIF.Add(drA.Item("Descricao") & Space(100) & drA.Item("IDFormaPagto"))
                DadosQR.Add(drA.Item("Descricao") & Space(100) & drA.Item("IDFormaPagto"))
                DadosRA.Add(drA.Item("Descricao") & Space(100) & drA.Item("IDFormaPagto"))
            End While
            cbIDFormaPagtoDefaultRappi.DataSource = DadosRA
        End If

        drA.Close()
        cmdA.Dispose()
        conA.Dispose()
        conA.Close()


    End Sub
    Public Sub MontaGridProdutosRappiBusca(busca As String)
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        Dim item As ListViewItem

        lstProdutosBuscaRappi.Items.Clear()

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
                item = lstProdutosBuscaRappi.Items.Add(NuloString(dr.Item("IDProduto")))
                item.SubItems.Add(NuloString(dr.Item("CodigoProduto")))
                item.SubItems.Add(NuloString(dr.Item("Produto")))
                item.SubItems.Add(NuloDecimal(dr.Item("Venda")))
            End While

            lstProdutosBuscaRappi.Update()
            lstProdutosBuscaRappi.EndUpdate()

        End If
        dr.Close()
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub PreencheClientesRappi()

        strSql = "Select IDCliente, NomeCliente "
        strSql += "From tblClientes "
        strSql += "Order By NomeCliente"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Cli As New ArrayList()

        With drLJS
            If .HasRows Then
                Cli.Add("")
                While (.Read())
                    Cli.Add(.Item("NomeCliente") & Space(100) & .Item("IDCliente"))
                End While
            End If
            .Close()
        End With
        cbIDClienteDefaultRappi.DataSource = Cli
        comandoLJS.Dispose()
        con.Close()

    End Sub
    Private Sub PreencheProdutosRappi()
        Dim item As ListViewItem
        Dim Qtd As Integer = 0

        strSql = "Select tblProdutosExterno.IDProduto, tblProdutosExterno.CodigoProduto, tblProdutosExterno.IDLoja, tblProdutosExterno.Aplicativo, tblProdutosExterno.CodigoProdutoExterno, tblProdutos.Produto, tblProdutosExterno.ProdutoExterno, tblProdutos.CodigoGrupo "
        strSql += "From tblProdutosExterno INNER Join tblProdutos On tblProdutosExterno.IDProduto = tblProdutos.IDProduto "
        strSql += "WHERE (tblProdutosExterno.Aplicativo='RAPPI') "
        If NuloString(tbBuscaRappiVinc.Text) <> "" Then
            strSql += "And (tblProdutos.Produto Like '%" & tbBuscaRappiVinc.Text & "%') OR (tblProdutosExterno.Aplicativo = 'RAPPI') AND (tblProdutosExterno.ProdutoExterno LIKE '%" & tbBuscaRappiVinc.Text & "%') "
        End If
        strSql += "Order By tblProdutos.Produto"

        Dim conA As New SqlConnection(strConServer)
        conA.Open()
        Dim cmdA As New SqlCommand(strSql, conA)
        cmdA.CommandType = CommandType.Text

        Dim drA As SqlDataReader = cmdA.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstProdutosRappi.Items.Clear()

        If drA.HasRows Then
            While drA.Read()
                item = lstProdutosRappi.Items.Add(drA.Item("IDProduto"))
                item.SubItems.Add(drA.Item("CodigoProduto"))
                item.SubItems.Add(drA.Item("Produto"))
                item.SubItems.Add(drA.Item("CodigoProdutoExterno"))
                item.SubItems.Add(drA.Item("ProdutoExterno"))
                Qtd += 1
            End While
            lstProdutosRappi.Update()
            lstProdutosRappi.EndUpdate()
        End If
        lbProdutosVinculadosRappi.Text = "Qtde. de produtos :  " & Qtd
        drA.Close()
        cmdA.Dispose()
        conA.Dispose()
        conA.Close()

        'Colorir()
        'PreencheVendas()

    End Sub

    Private Sub preencheSetores()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        strSql = "SELECT IDSetor, Setor FROM tblSetores ORDER BY Setor"

        con.Open()

        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim SetoresBal As New ArrayList()
        Dim SetoresDel As New ArrayList()

        With drLJS
            If .HasRows Then
                SetoresBal.Add(Space(130) & "00")
                SetoresDel.Add(Space(130) & "00")
                While (.Read())
                    SetoresBal.Add(.Item("Setor") & Space(100) & .Item("IDSetor"))
                    SetoresDel.Add(.Item("Setor") & Space(100) & .Item("IDSetor"))
                End While
            End If
            .Close()
        End With
        cbSetorBalcao.DataSource = SetoresBal
        cbSetorDelivery.DataSource = SetoresDel
        comandoLJS.Dispose()
        con.Close()
    End Sub
    Private Sub preencheCategorias()

        Dim con As New SqlConnection(strCon)

        cbCategoriaPropriaDelivery.Items.Clear()

        strSql = "SELECT Categoria FROM tblCategorias_Local ORDER BY Categoria"

        con.Open()

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim cat As New ArrayList()


        If dr.HasRows Then
            cat.Add("")
            While (dr.Read())
                cat.Add(dr.Item("Categoria"))
            End While
        End If
        dr.Close()

        cbCategoriaPropriaDelivery.DataSource = cat

        cmd.Dispose()
        con.Close()
    End Sub
    Private Sub preencheSAT()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        'cbSat.Items.Clear()

        strSql = "SELECT IDSat, NumeroCaixa, Fabricante, Modelo, NumeroSerial FROM tblSAT ORDER BY NumeroCaixa"

        con.Open()

        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Depto As New ArrayList()

        With drLJS
            If .HasRows Then
                Depto.Add(Space(130) & "00")
                While (.Read())
                    Depto.Add(.Item("NumeroCaixa") & " - " & .Item("NumeroSerial") & " - " & .Item("Fabricante") & Space(100) & .Item("IDSat"))
                End While
            End If
            .Close()
        End With
        cbEquipamentoSAT.DataSource = Depto

        comandoLJS.Dispose()
        con.Close()

    End Sub

    Private Sub ExibeImpressoras()

        Dim v_total, v_cont, v_item As Integer
        Dim pd As PrintDocument = New PrintDocument
        Try
            v_total = pd.PrinterSettings.InstalledPrinters.Count
            With pd.PrinterSettings.InstalledPrinters
                For v_cont = 0 To v_total - 1
                    cbImpressoraCaixa.Items.Add(.Item(v_cont))
                    cbImpressoraConta.Items.Add(.Item(v_cont))
                    cbImpressoraExpedicao.Items.Add(.Item(v_cont))
                Next
            End With
            cbImpressoraCaixa.SelectedIndex = (v_item)
            cbImpressoraConta.SelectedIndex = (v_item)
            cbImpressoraExpedicao.SelectedIndex = (v_item)

        Catch ex As Exception
            MessageBox.Show("Erro de Impressão " + ex.Message)
        Finally
            pd.Dispose()
        End Try


    End Sub

    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click

        If btnGravar.Enabled = True Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Deseja sair sem gravar as informações alteradas"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub
        End If
        My.Computer.Audio.Stop()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "CONFIGURAÇÕES DOS BOTÕES GRUPOS DE VENDA")
        End If
        fdlgConfigGrupos.ShowDialog()

    End Sub
    Private Sub MontaTela()

        Dim Dados As New ArrayList()
        With Dados
            .Add("Sim")
            .Add("Não")
        End With
        cbGuilhotina.DataSource = Dados

        Dim Dados2 As New ArrayList()
        With Dados2
            .Add("Sim")
            .Add("Não")
        End With
        cbImprimeEstorno.DataSource = Dados2

        Dim Dados3 As New ArrayList()
        With Dados3
            .Add("Sim")
            .Add("Não")
        End With
        cbImprimeTransferencia.DataSource = Dados3

        Dim Dados4 As New ArrayList()
        With Dados4
            .Add("Sim")
            .Add("Não")
        End With
        cbImprimeRecibo.DataSource = Dados4

        Dim Dados5 As New ArrayList()
        With Dados5
            .Add("Mesa")
            .Add("Cartão")
        End With
        cbTextoSalao.DataSource = Dados5

        Dim Dados6 As New ArrayList()
        With Dados6
            .Add("SAT")
            .Add("NFCE")
        End With
        cbModoFiscal.DataSource = Dados6

        Dim Dados7 As New ArrayList()
        With Dados7
            .Add("Sim")
            .Add("Não")
        End With
        cbImprime.DataSource = Dados7

        Dim Dados8 As New ArrayList()
        With Dados8
            .Add("Sim")
            .Add("Não")
        End With
        cbObrigaConta.DataSource = Dados8

        Dim Dados9 As New ArrayList()
        With Dados9
            .Add("Sim")
            .Add("Não")
        End With
        cbGavetaCaixa.DataSource = Dados9

        Dim Dados10 As New ArrayList()
        With Dados10
            .Add("Sim")
            .Add("Não")
        End With
        cbGerenciaSAT.DataSource = Dados10

        Dim Dados11 As New ArrayList()
        With Dados11
            .Add("Sim")
            .Add("Não")
        End With
        cbPedeMesa.DataSource = Dados11

        Dim Dados12 As New ArrayList()
        With Dados12
            .Add("Não")
            .Add("Somente Impressoras")
            .Add("Impressoras + Tablets")
        End With
        cbGerenciaImpressao.DataSource = Dados12

        Dim Dados13 As New ArrayList()
        With Dados13
            .Add("Sim")
            .Add("Não")
        End With
        cbCaixaIndividualizado.DataSource = Dados13

        Dim Dados14 As New ArrayList()
        With Dados14
            .Add("Sim")
            .Add("Não")
        End With
        cbFixaAbreMesaCartao.DataSource = Dados14

        Dim Dados15 As New ArrayList()
        With Dados15
            .Add("Sim")
            .Add("Não")
        End With
        cbNaoEncerraVendasAberto.DataSource = Dados15

        Dim Dados16 As New ArrayList()
        With Dados16
            .Add("Sim")
            .Add("Não")
        End With
        cbAtualizaVendas.DataSource = Dados16

        Dim Dados17 As New ArrayList()
        With Dados17
            .Add("Sim")
            .Add("Não")
        End With
        cbFixaTelaPedidos.DataSource = Dados17

        Dim Dados18 As New ArrayList()
        With Dados18
            .Add("Sim")
            .Add("Não")
        End With
        cbEnviaEmailFechamento.DataSource = Dados18

        Dim Dados19 As New ArrayList()
        With Dados19
            .Add("Sim")
            .Add("Não")
        End With
        cbInformaClienteBalcao.DataSource = Dados19

        Dim Dados20 As New ArrayList()
        With Dados20
            .Add("1")
            .Add("2")
            .Add("3")
        End With
        cbQtdeImpressaoExpedicao.DataSource = Dados20

        Dim Dados21 As New ArrayList()
        With Dados21
            .Add("Sim")
            .Add("Não")
        End With
        cbImpressoraCaixaTexto.DataSource = Dados21

        Dim Dados22 As New ArrayList()
        With Dados22
            .Add("Sim")
            .Add("Não")
        End With
        cbImprimeConferenciaBalcao.DataSource = Dados22

        Dim Dados24 As New ArrayList()
        With Dados24
            .Add("Sim")
            .Add("Não")
        End With
        cbIncluiFundoCaixa.DataSource = Dados24

        Dim Dados25 As New ArrayList()
        With Dados25
            .Add("Sim")
            .Add("Não")
        End With
        cbNaoCobraServico.DataSource = Dados25

        Dim Dados26 As New ArrayList()
        With Dados26
            .Add("Sim")
            .Add("Não")
        End With
        cbRegistraLog.DataSource = Dados26

        Dim Dados27 As New ArrayList()
        With Dados27
            .Add("Sim")
            .Add("Não")
        End With
        cbVerificaPedidoProgramado.DataSource = Dados27

        Dim Dados28 As New ArrayList()
        With Dados28
            .Add("Sim")
            .Add("Não")
        End With
        cbMostraComentExpedicao.DataSource = Dados28

        Dim Dados31 As New ArrayList()
        With Dados31
            .Add("Sim")
            .Add("Não")
        End With
        cbPosControle.DataSource = Dados31

        Dim Dados33 As New ArrayList()
        With Dados33
            .Add("Sim")
            .Add("Não")
        End With
        cbExpedicaoPadrao.DataSource = Dados33

        Dim Dados35 As New ArrayList()
        With Dados35
            .Add("Sim")
            .Add("Não")
        End With
        cbGerenciaPedidosRappi.DataSource = Dados35

        Dim Dados36 As New ArrayList()
        With Dados36
            .Add("Sim")
            .Add("Não")
        End With
        cbAceitaPedidoAutomaticoRappi.DataSource = Dados36

        Dim Dados37 As New ArrayList()
        With Dados37
            .Add("Sim")
            .Add("Não")
        End With
        cbAcrescimo_W21.DataSource = Dados37

        Dim Dados38 As New ArrayList()
        With Dados38
            .Add("Sim")
            .Add("Não")
        End With
        cbNaoMostraProdutosZeroConta.DataSource = Dados38

        Dim Dados39 As New ArrayList()
        With Dados39
            .Add("")
            .Add("Som padão")
            .Add("Som 01")
            .Add("Som 02")
            .Add("Som 03")
            .Add("Som 04")
            .Add("Som 05")
            .Add("Som 06")
            .Add("Som 07")
            .Add("Som 08")
            .Add("Som 09")
            .Add("Som 10")
        End With
        cbToqueApp.DataSource = Dados39

        Dim Dados40 As New ArrayList()
        With Dados40
            .Add("Sim")
            .Add("Não")
        End With
        cbBloqueaMesaAposConta.DataSource = Dados40

        Dim Dados41 As New ArrayList()
        With Dados41
            .Add("Sim")
            .Add("Não")
        End With
        cbImprimeConsumo.DataSource = Dados41

        Dim Dados42 As New ArrayList()
        With Dados42
            .Add("Sim")
            .Add("Não")
        End With
        cbQtdePessoasBalcao.DataSource = Dados42

        Dim Dados43 As New ArrayList()
        With Dados43
            .Add("Sim")
            .Add("Não")
        End With
        cbReimprimeComanda.DataSource = Dados43

        Dim Dados44 As New ArrayList()
        With Dados44
            .Add("Sim")
            .Add("Não")
            .Add("CAMELO MOEMA")
        End With
        cbMediaQtdeVendas.DataSource = Dados44

        Dim Dados45 As New ArrayList()
        With Dados45
            .Add("Sim")
            .Add("Não")
        End With
        cbFecDeliveryCamelo.DataSource = Dados45

        Dim Dados46 As New ArrayList()
        With Dados46
            .Add("Sim")
            .Add("Não")
        End With
        cbImprimeExpandido.DataSource = Dados46

        ExibeImpressoras()
        preencheSAT()
        preencheSetores()
        btnGravar.Enabled = False
    End Sub

    Private Sub GravaDados()

        If InStr(Atualiza, "G") > 0 Then
            strSql = "UPDATE tblConfig SET "
            strSql &= "CNPJSoftwareHouse='" & NuloString(tbCNPJSoftwareHouse.Text) & "', "
            strSql &= "NCM_Servico='" & NuloString(tbNCM_Servico.Text) & "', "
            strSql &= "CSTPis_Servico='" & NuloString(tbCSTPis_Servico.Text) & "', "
            strSql &= "CSTCofins_Servico='" & NuloString(tbCSTCofins_Servico.Text) & "', "
            strSql &= "CFOP_Servico='" & NuloString(tbCFOP_Servico.Text) & "', "
            strSql &= "CSTIcms_Servico='" & NuloString(tbCSTIcms_Servico.Text) & "', "
            strSql &= "Aliquota_Servico=" & NuloDecimal(tbAliquota_Servico.Text) & ", "
            strSql &= "ModoFiscal='" & NuloString(cbModoFiscal.Text) & "', "
            strSql &= "FatorAjusteServico=" & NuloInteger(tbFatorAjusteServico.Text) & ", "
            If cbRegistraLog.Text = "Não" Then
                strSql &= "RegistraLog=0, "
            Else
                strSql &= "RegistraLog=1, "
            End If
            If cbIncluiFundoCaixa.Text = "Não" Then
                strSql &= "IncluiFundoCaixa=0, "
            Else
                strSql &= "IncluiFundoCaixa=1, "
            End If
            If cbImprimeConferenciaBalcao.Text = "Não" Then
                strSql &= "ImprimeConferenciaBalcao=0, "
            Else
                strSql &= "ImprimeConferenciaBalcao=1, "
            End If
            Dim Relats As String = ""
            If chkRelatProdutos.Checked = True Then
                Relats = "P"
            End If
            If chkRelatServico.Checked = True Then
                Relats += "S"
            End If
            If chkRelatEstorno.Checked = True Then
                Relats += "E"
            End If
            strSql &= "RelatFechamento='" & Relats & "', "

            If cbEnviaEmailFechamento.Text = "Não" Then
                strSql &= "EnviaEmailFechamento=0, "
            Else
                strSql &= "EnviaEmailFechamento=1, "
            End If
            If cbNaoEncerraVendasAberto.Text = "Não" Then
                strSql &= "NaoEncerraVendasAberto=0, "
            Else
                strSql &= "NaoEncerraVendasAberto=1, "
            End If
            If cbImprimeEstorno.Text = "Não" Then
                strSql &= "ImprimeEstorno=0, "
            Else
                strSql &= "ImprimeEstorno=1, "
            End If
            If cbImprimeTransferencia.Text = "Não" Then
                strSql &= "ImprimeTransferencia=0, "
            Else
                strSql &= "ImprimeTransferencia=1, "
            End If
            If cbImprimeRecibo.Text = "Não" Then
                strSql &= "ImprimeRecibo=0, "
            Else
                strSql &= "ImprimeRecibo=1, "
            End If
            If cbCaixaIndividualizado.Text = "Não" Then
                strSql &= "CaixaIndividualizado=0, "
            Else
                strSql &= "CaixaIndividualizado=1, "
            End If
            strSql &= "MediaQtdeVdas='" & cbMediaQtdeVendas.Text & "', "


            ' Parametros Salão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql &= "TextoSalao='" & NuloString(UCase(cbTextoSalao.Text)) & "', "
            strSql &= "TextoServico='" & NuloString(UCase(tbTextoServico.Text)) & "', "
            strSql &= "PercServico=" & NuloInteger(tbPercSalao.Text) & ", "
            strSql &= "TempoLimite=" & NuloInteger(tbTempoLimiteMesa.Text) & ", "
            strSql &= "TempoLimiteEmEspera=" & NuloInteger(tbTempoLimiteMesaEmEspera.Text) & ", "
            If cbObrigaConta.Text = "Não" Then
                strSql &= "ObrigaConta=0, "
            Else
                strSql &= "ObrigaConta=1, "
            End If
            strSql &= "TextoServicoCupom='" & NuloString(UCase(tbTextoServicoCupom.Text)) & "', "
            If cbAcrescimo_W21.Text = "Não" Then
                strSql &= "Acrescimo_W21=0, "
            Else
                strSql &= "Acrescimo_W21=1, "
            End If
            If cbNaoMostraProdutosZeroConta.Text = "Não" Then
                strSql &= "NaoMostraProdutosZeroConta=0, "
            Else
                strSql &= "NaoMostraProdutosZeroConta=1, "
            End If

            ' Parametros Balcão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql &= "SetorBalcao=" & NuloInteger(Val(Strings.Right(cbSetorBalcao.Text, 8))) & ", "
            If cbInformaClienteBalcao.Text = "Não" Then
                strSql &= "InformaClienteBalcao=0, "
            Else
                strSql &= "InformaClienteBalcao=1, "
            End If
            If cbQtdePessoasBalcao.Text = "Não" Then
                strSql &= "QtdePessoasBalcao=0, "
            Else
                strSql &= "QtdePessoasBalcao=1, "
            End If

            ' Parametros Delivery /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql &= "SetorDelivery=" & NuloInteger(Val(Strings.Right(cbSetorDelivery.Text, 8))) & ", "
            strSql &= "QtdeImpressaoExpedicao=" & NuloInteger(cbQtdeImpressaoExpedicao.Text) & ", "
            strSql &= "DataAtualizacao='" & Now & "', "
            If cbMostraComentExpedicao.Text = "Não" Then
                strSql &= "MostraComentExpedicao=0, "
            Else
                strSql &= "MostraComentExpedicao=1, "
            End If
            strSql &= "CategoriaPropriaDelivery='" & NuloString(cbCategoriaPropriaDelivery.Text) & "', "
            strSql &= "ToqueApp='" & NuloString(cbToqueApp.Text) & "', "

            ' Terminal Venda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If cbBloqueaMesaAposConta.Text = "Não" Then
                strSql &= "BloqueaMesaAposConta=0, "
            Else
                strSql &= "BloqueaMesaAposConta=1, "
            End If

            ' PosControle  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql &= "UserName_PosControle = '" & NuloString(tbUserName_PosControle.Text) & "', "
            strSql &= "Senha_PosControle = '" & NuloString(tbSenha_PosControle.Text) & "', "
            'strSql &= "Token_PosControle = '" & NuloString(tbToken_PosControle.Text) & "', "
            If cbPosControle.Text = "Não" Then
                strSql &= "PosControle=0, "
            Else
                strSql &= "PosControle=1, "
            End If

            ' Rappi  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            strSql &= "Grant_Type_Rappi='client_credentials', "
            If NuloInteger(tbIntegracaoRappiAtiva.Text) = 0 Then
                strSql &= "IntegracaoRappi=0, "
                EscreveINI("RAPPI", "IntegracaoRappi", "0", nome_arquivo_ini)
            Else
                strSql &= "IntegracaoRappi=1, "
                EscreveINI("RAPPI", "IntegracaoRappi", "1", nome_arquivo_ini)
            End If
            strSql &= "IDFormaPagtoDefaultRappi=" & NuloInteger(Strings.Right(cbIDFormaPagtoDefaultRappi.Text, 8)) & ", "
            strSql &= "IDClienteDefaultRappi=" & NuloInteger(Strings.Right(cbIDClienteDefaultRappi.Text, 8)) & ", "
        End If

        If InStr(Atualiza, "L") > 0 Then
            EscreveINI("Geral", "BancoDados", tbBancoDadosLocal.Text, nome_arquivo_ini)
            EscreveINI("Geral", "Data Source", tbDataSourceLocal.Text, nome_arquivo_ini)
            EscreveINI("Geral", "Usuario", tbUsuarioLocal.Text, nome_arquivo_ini)
            EscreveINI("Geral", "Senha", DesmontaSenha(tbSenhaLocal.Text), nome_arquivo_ini)
            EscreveINI("Geral", "BancoDados_server", tbBancoDadosRetaguarda.Text, nome_arquivo_ini)
            EscreveINI("Geral", "Data source_server", tbDataSourceRetaguarda.Text, nome_arquivo_ini)
            EscreveINI("Geral", "Usuario_server", tbUsuarioRetaguarda.Text, nome_arquivo_ini)
            EscreveINI("Geral", "Senha_server", DesmontaSenha(tbSenhaRetaguarda.Text), nome_arquivo_ini)
            EscreveINI("Geral", "IDLoja", tbIDLoja.Text, nome_arquivo_ini)
            EscreveINI("IRIS", "Equipamento", tbIDEquipamento.Text, nome_arquivo_ini)
            EscreveINI("Geral", "ImpressoraCaixa", cbImpressoraCaixa.Text, nome_arquivo_ini)
            EscreveINI("Geral", "ImpressoraExpedicao", cbImpressoraExpedicao.Text, nome_arquivo_ini)
            EscreveINI("Geral", "PortaBalanca", tbPortaBalanca.Text, nome_arquivo_ini)
            If cbImpressoraCaixaTexto.Text = "Não" Then
                EscreveINI("Geral", "ImpressoraCaixaTexto", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "ImpressoraCaixaTexto", "1", nome_arquivo_ini)
            End If
            If cbAtualizaVendas.Text = "Não" Then
                EscreveINI("Geral", "AtualizaVendas", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "AtualizaVendas", "1", nome_arquivo_ini)
            End If
            If cbFixaAbreMesaCartao.Text = "Não" Then
                cbFixaAbreMesaCartao.Text = "Não"
                EscreveINI("Geral", "FixaAbreMesaCartao", "0", nome_arquivo_ini)
                frmPrincipal.TimerSAT.Enabled = True
            Else
                EscreveINI("Geral", "FixaAbreMesaCartao", "1", nome_arquivo_ini)
            End If
            If cbGerenciaImpressao.Text = "Não" Then
                cbGerenciaImpressao.Text = "Não"
                EscreveINI("Geral", "GerenciaImpressao", "0", nome_arquivo_ini)
                EscreveINI("Geral", "GerenciaTablet", "0", nome_arquivo_ini)
                EscreveINI("Geral", "TabletAtivo", "0", nome_arquivo_ini)
                GerenciaImpressao = False
                TableAtivo = False
            Else
                If cbGerenciaImpressao.Text = "Somente Impressoras" Then
                    EscreveINI("Geral", "GerenciaImpressao", "1", nome_arquivo_ini)
                    EscreveINI("Geral", "GerenciaTablet", "0", nome_arquivo_ini)
                    EscreveINI("Geral", "TabletAtivo", "0", nome_arquivo_ini)
                    TableAtivo = False
                Else
                    EscreveINI("Geral", "GerenciaImpressao", "1", nome_arquivo_ini)
                    EscreveINI("Geral", "GerenciaTablet", "1", nome_arquivo_ini)
                    EscreveINI("Geral", "TabletAtivo", "1", nome_arquivo_ini)
                    TableAtivo = True
                End If
                GerenciaImpressao = True
            End If
            If cbGerenciaSAT.Text = "Não" Then
                cbGerenciaSAT.Text = "Não"
                EscreveINI("SAT", "GerenciaSAT", "0", nome_arquivo_ini)
                frmPrincipal.TimerSAT.Enabled = True
            Else
                EscreveINI("SAT", "GerenciaSAT", "1", nome_arquivo_ini)
                frmPrincipal.TimerSAT.Enabled = False
            End If
            If cbImprime.Text = "Não" Then
                cbImprime.Text = "Não"
                EscreveINI("Geral", "Imprime", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "Imprime", "1", nome_arquivo_ini)
            End If
            If cbGuilhotina.Text = "Não" Then
                EscreveINI("Geral", "GuilhotinaImpressoraCaixa", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "GuilhotinaImpressoraCaixa", "1", nome_arquivo_ini)
            End If
            If cbGavetaCaixa.Text = "Não" Then
                EscreveINI("Geral", "GavetaEletronica", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "GavetaEletronica", "1", nome_arquivo_ini)
            End If
            If cbImprimeExpandido.Text = "Não" Then
                EscreveINI("Geral", "ImprimeExpandido", "0", nome_arquivo_ini)
            Else
                EscreveINI("Geral", "ImprimeExpandido", "1", nome_arquivo_ini)
            End If


            ' Parametros Salão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            EscreveINI("Salao", "ImpressoraConta", cbImpressoraConta.Text, nome_arquivo_ini)
            If cbImprimeConsumo.Text = "Não" Then
                EscreveINI("Salao", "ImprimeConsumo", "0", nome_arquivo_ini)
            Else
                EscreveINI("Salao", "ImprimeConsumo", "1", nome_arquivo_ini)
            End If
            If cbReimprimeComanda.Text = "Não" Then
                EscreveINI("Salao", "ReimprimeComanda", "0", nome_arquivo_ini)
            Else
                EscreveINI("Salao", "ReimprimeComanda", "1", nome_arquivo_ini)
            End If


            ' Parametros Delivery /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If cbVerificaPedidoProgramado.Text = "Não" Then
                EscreveINI("Delivery", "GerenciaPedidoProgramado", "0", nome_arquivo_ini)
            Else
                EscreveINI("Delivery", "GerenciaPedidoProgramado", "1", nome_arquivo_ini)
            End If
            If cbExpedicaoPadrao.Text = "Não" Then
                EscreveINI("Delivery", "ExpedicaoPadrao", "0", nome_arquivo_ini)
            Else
                EscreveINI("Delivery", "ExpedicaoPadrao", "1", nome_arquivo_ini)
            End If
            If cbFecDeliveryCamelo.Text = "Não" Then
                EscreveINI("Delivery", "FechamentoDeliveryCamelo", "0", nome_arquivo_ini)
            Else
                EscreveINI("Delivery", "FechamentoDeliveryCamelo", "1", nome_arquivo_ini)
            End If


            ' Parametros SAT /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            EscreveINI("SAT", "EquipamentoSAT", Val(Strings.Right(cbEquipamentoSAT.Text, 6)), nome_arquivo_ini)



            ' Terminal Venda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If cbPedeMesa.Text = "Não" Then
                EscreveINI("TERMINAL_VENDA", "PedeMesa", "0", nome_arquivo_ini)
            Else
                EscreveINI("TERMINAL_VENDA", "PedeMesa", "1", nome_arquivo_ini)
            End If
            If cbFixaTelaPedidos.Text = "Não" Then
                EscreveINI("TERMINAL_VENDA", "FixaTelaPedidos", "0", nome_arquivo_ini)
            Else
                EscreveINI("TERMINAL_VENDA", "FixaTelaPedidos", "1", nome_arquivo_ini)
            End If
            If cbNaoCobraServico.Text = "Não" Then
                EscreveINI("TERMINAL_VENDA", "NaoCobraServico", "0", nome_arquivo_ini)
            Else
                EscreveINI("TERMINAL_VENDA", "NaoCobraServico", "1", nome_arquivo_ini)
            End If
            EscreveINI("TERMINAL_VENDA", "TempoLimite", NuloInteger(tbTempoLimite.Text), nome_arquivo_ini)
            EscreveINI("Geral", "DataAtualizacao", NuloString(Now), nome_arquivo_ini)

            ' RAPPI  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If cbGerenciaPedidosRappi.Text = "Não" Then
                EscreveINI("RAPPI", "GerenciaPedidosRappi", "0", nome_arquivo_ini)
            Else
                EscreveINI("RAPPI", "GerenciaPedidosRappi", "1", nome_arquivo_ini)
            End If

            ' NFce  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            EscreveINI("NFCE", "EnviaEmailNFCE", NuloBoolean(chkEnviaEmailNFCE.Checked), nome_arquivo_ini)
            EscreveINI("NFCE", "EmailNFCE", NuloString(tbEmailNFCE.Text), nome_arquivo_ini)
            EscreveINI("NFCE", "DiaNFCE", NuloString(tbDiaNFCE.Text), nome_arquivo_ini)
        End If


    End Sub
    Private Sub Inicio()

        Dim conTe As New SqlConnection()
        strSql = "Select * From tblConfig"

        Dim drTe As SqlDataReader
        conTe.ConnectionString = strCon
        Dim cmdTe As SqlCommand = conTe.CreateCommand
        cmdTe.CommandText = strSql

        conTe.Open()
        drTe = cmdTe.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        drTe.Read()
        tbCNPJSoftwareHouse.Text = NuloString(drTe.Item("CNPJSoftwareHouse"))
        tbNCM_Servico.Text = NuloString(drTe.Item("NCM_Servico"))
        tbCSTPis_Servico.Text = NuloString(drTe.Item("CSTPis_Servico"))
        tbCSTCofins_Servico.Text = NuloString(drTe.Item("CSTCofins_Servico"))
        tbCFOP_Servico.Text = NuloString(drTe.Item("CFOP_Servico"))
        tbCSTIcms_Servico.Text = NuloString(drTe.Item("CSTIcms_Servico"))
        tbAliquota_Servico.Text = NuloDecimal(drTe.Item("Aliquota_Servico"))

        ' Dados conexão Gourmet Visual /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        tbBancoDadosLocal.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados", "")
        tbDataSourceLocal.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source", "")
        tbUsuarioLocal.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario", "")
        tbSenhaLocal.Text = MontaSenha(LeArquivoINI(nome_arquivo_ini, "Geral", "Senha", ""))
        'strCon = "Server=" & DTSource & ";Database=" & EndBcoDados & ";User id=" & Usuario & ";Password =" & SenhaCon

        ' Dados conexão IRIS Gestão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        tbBancoDadosRetaguarda.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "BancoDados_server", "")
        tbDataSourceRetaguarda.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "Data Source_server", "")
        tbUsuarioRetaguarda.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "Usuario_server", "")
        tbSenhaRetaguarda.Text = MontaSenha(LeArquivoINI(nome_arquivo_ini, "Geral", "Senha_server", ""))
        'strConServer = "Server=" & DTSource & ";Database=" & EndBcoDados & ";User id=" & Usuario & ";Password =" & SenhaCon
        ' Parametros Geral /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        tbIDLoja.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "IDLoja", "")
        tbIDEquipamento.Text = LeArquivoINI(nome_arquivo_ini, "IRIS", "Equipamento", "")
        cbImpressoraCaixa.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixa", "")
        tbPortaBalanca.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "PortaBalanca", "")
        cbImpressoraExpedicao.Text = LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraExpedicao", "")

        If NuloBoolean(drTe.Item("RegistraLog")) = False Then
            cbRegistraLog.Text = "Não"
            btnLogEventos.Visible = False
        Else
            cbRegistraLog.Text = "Sim"
            btnLogEventos.Visible = True
        End If

        If NuloBoolean(drTe.Item("IncluiFundoCaixa")) = False Then
            cbIncluiFundoCaixa.Text = "Não"
        Else
            cbIncluiFundoCaixa.Text = "Sim"
        End If

        If InStr(NuloString(drTe.Item("RelatFechamento")), "P") > 0 Then
            chkRelatProdutos.Checked = True
        Else
            chkRelatProdutos.Checked = False
        End If
        If InStr(NuloString(drTe.Item("RelatFechamento")), "S") > 0 Then
            chkRelatServico.Checked = True
        Else
            chkRelatServico.Checked = False
        End If
        If InStr(NuloString(drTe.Item("RelatFechamento")), "E") > 0 Then
            chkRelatEstorno.Checked = True
        Else
            chkRelatEstorno.Checked = False
        End If

        If NuloBoolean(drTe.Item("ImprimeConferenciaBalcao")) = False Then
            cbImprimeConferenciaBalcao.Text = "Não"
            ImprimeConferenciaBalcao = False
        Else
            cbImprimeConferenciaBalcao.Text = "Sim"
            ImprimeConferenciaBalcao = True
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "ImpressoraCaixaTexto", 0) = 0 Then
            cbImpressoraCaixaTexto.Text = "Não"
            ImpressoraCaixaTexto = False
        Else
            cbImpressoraCaixaTexto.Text = "Sim"
            ImpressoraCaixaTexto = True
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaImpressao", 0) = 0 Then
            cbGerenciaImpressao.Text = "Não"
            GerenciaImpressao = False
        Else
            GerenciaImpressao = True
            If LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaImpressao", 0) = 1 And LeArquivoINI(nome_arquivo_ini, "Geral", "GerenciaTablet", 0) = 1 Then
                cbGerenciaImpressao.Text = "Impressoras + Tablets"
                GerenciaTable = True
            Else
                cbGerenciaImpressao.Text = "Somente Impressoras"
                GerenciaTable = False
            End If
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "AtualizaVendas", 0) = 0 Then
            cbAtualizaVendas.Text = "Não"
        Else
            cbAtualizaVendas.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("NaoEncerraVendasAberto")) = False Then
            cbNaoEncerraVendasAberto.Text = "Não"
        Else
            cbNaoEncerraVendasAberto.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "FixaAbreMesaCartao", 0) = 0 Then
            cbFixaAbreMesaCartao.Text = "Não"
        Else
            cbFixaAbreMesaCartao.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("ImprimeEstorno")) = False Then
            cbImprimeEstorno.Text = "Não"
        Else
            cbImprimeEstorno.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("ImprimeTransferencia")) = False Then
            cbImprimeTransferencia.Text = "Não"
        Else
            cbImprimeTransferencia.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "GuilhotinaImpressoraCaixa", 0) = 0 Then
            cbGuilhotina.Text = "Não"
        Else
            cbGuilhotina.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("ImprimeRecibo")) = False Then
            cbImprimeRecibo.Text = "Não"
        Else
            cbImprimeRecibo.Text = "Sim"
        End If

        cbModoFiscal.Text = NuloString(drTe.Item("ModoFiscal"))
        ModoFiscal = NuloString(drTe.Item("ModoFiscal"))

        If LeArquivoINI(nome_arquivo_ini, "Geral", "Imprime", 0) = 0 Then
            cbImprime.Text = "Não"
        Else
            cbImprime.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "GavetaEletronica", "0") = 0 Then
            cbGavetaCaixa.Text = "Não"
        Else
            cbGavetaCaixa.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("CaixaIndividualizado")) = False Then
            cbCaixaIndividualizado.Text = "Não"
        Else
            cbCaixaIndividualizado.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("EnviaEmailFechamento")) = False Then
            cbEnviaEmailFechamento.Text = "Não"
        Else
            cbEnviaEmailFechamento.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "SAT", "GerenciaSAT", "0") = 0 Then
            cbGerenciaSAT.Text = "Não"
        Else
            cbGerenciaSAT.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Salao", "ImprimeConsumo", "0") = 0 Then
            cbImprimeConsumo.Text = "Não"
        Else
            cbImprimeConsumo.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Salao", "ReimprimeComanda", "0") = 0 Then
            cbReimprimeComanda.Text = "Não"
        Else
            cbReimprimeComanda.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Geral", "ImprimeExpandido", 0) = 0 Then
            cbImprimeExpandido.Text = "Não"
        Else
            cbImprimeExpandido.Text = "Sim"
        End If
        tbFatorAjusteServico.Text = NuloDecimal(drTe.Item("FatorAjusteServico"))
        cbMediaQtdeVendas.Text = NuloString(drTe.Item("MediaQtdeVdas"))


        ' Parametros Salão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        cbImpressoraConta.Text = LeArquivoINI(nome_arquivo_ini, "Salao", "ImpressoraConta", String.Empty)
        cbTextoSalao.Text = NuloString(drTe.Item("TextoSalao"))
        tbTextoServico.Text = NuloString(drTe.Item("TextoServico"))
        tbPercSalao.Text = NuloDecimal(drTe.Item("PercServico"))
        tbTempoLimiteMesa.Text = NuloInteger(drTe.Item("TempoLimite"))
        tbTempoLimiteMesaEmEspera.Text = NuloInteger(drTe.Item("TempoLimiteEmEspera"))
        If NuloBoolean(drTe.Item("ObrigaConta")) = False Then
            cbObrigaConta.Text = "Não"
        Else
            cbObrigaConta.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("Acrescimo_W21")) = False Then
            cbAcrescimo_W21.Text = "Não"
        Else
            cbAcrescimo_W21.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("NaoMostraProdutosZeroConta")) = False Then
            cbNaoMostraProdutosZeroConta.Text = "Não"
        Else
            cbNaoMostraProdutosZeroConta.Text = "Sim"
        End If
        tbTextoServicoCupom.Text = NuloString(drTe.Item("TextoServicoCupom"))



        Dim IDSel As Integer
        Dim ItemSel As Integer = 0
        ' Parametros Balcão /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        For I = 1 To cbSetorBalcao.Items.Count
            cbSetorBalcao.SelectedIndex = ItemSel
            IDSel = Val(Strings.Right(cbSetorBalcao.Text, 8))
            cbSetorBalcao.SelectedIndex = ItemSel
            If IDSel = NuloInteger(drTe.Item("SetorBalcao")) Then
                I = 9999
            End If
            ItemSel += 1
        Next
        If NuloBoolean(drTe.Item("InformaClienteBalcao")) = False Then
            cbInformaClienteBalcao.Text = "Não"
        Else
            cbInformaClienteBalcao.Text = "Sim"
        End If
        If NuloBoolean(drTe.Item("QtdePessoasBalcao")) = False Then
            cbQtdePessoasBalcao.Text = "Não"
        Else
            cbQtdePessoasBalcao.Text = "Sim"
        End If
        cbCategoriaPropriaDelivery.Text = NuloString(drTe.Item("CategoriaPropriaDelivery"))



        ' Parametros Delivery /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ItemSel = 0
        For I = 1 To cbSetorDelivery.Items.Count
            cbSetorDelivery.SelectedIndex = ItemSel
            IDSel = Val(Strings.Right(cbSetorDelivery.Text, 8))
            cbSetorDelivery.SelectedIndex = ItemSel
            If IDSel = NuloInteger(drTe.Item("SetorDelivery")) Then
                I = 9999
            End If
            ItemSel += 1
        Next

        If NuloBoolean(drTe.Item("MostraComentExpedicao")) = False Then
            cbMostraComentExpedicao.Text = "Não"
        Else
            cbMostraComentExpedicao.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Delivery", "GerenciaPedidoProgramado", "0") = 0 Then
            cbVerificaPedidoProgramado.Text = "Não"
        Else
            cbVerificaPedidoProgramado.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "Delivery", "ExpedicaoPadrao", "0") = 0 Then
            cbExpedicaoPadrao.Text = "Não"
        Else
            cbExpedicaoPadrao.Text = "Sim"
        End If
        cbToqueApp.Text = NuloString(drTe.Item("ToqueApp"))
        cbQtdeImpressaoExpedicao.Text = NuloInteger(drTe.Item("QtdeImpressaoExpedicao"))

        If LeArquivoINI(nome_arquivo_ini, "Delivery", "FechamentoDeliveryCamelo", "0") = 0 Then
            cbFecDeliveryCamelo.Text = "Não"
        Else
            cbFecDeliveryCamelo.Text = "Sim"
        End If




        ' Parametros SAT /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ItemSel = 0
        For I = 1 To cbEquipamentoSAT.Items.Count
            cbEquipamentoSAT.SelectedIndex = ItemSel
            IDSel = Val(Strings.Right(cbEquipamentoSAT.Text, 5))
            cbEquipamentoSAT.SelectedIndex = ItemSel
            If IDSel = Val(LeArquivoINI(nome_arquivo_ini, "SAT", "EquipamentoSAT", "0")) Then
                I = 9999
            End If
            ItemSel += 1
        Next

        ' Terminal Venda /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "PedeMesa", 0) = 0 Then
            cbPedeMesa.Text = "Não"
        Else
            cbPedeMesa.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "FixaTelaPedidos", 0) = 0 Then
            cbFixaTelaPedidos.Text = "Não"
        Else
            cbFixaTelaPedidos.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "NaoCobraServico", 0) = 0 Then
            cbNaoCobraServico.Text = "Não"
        Else
            cbNaoCobraServico.Text = "Sim"
        End If
        tbTempoLimite.Text = NuloInteger(LeArquivoINI(nome_arquivo_ini, "TERMINAL_VENDA", "TempoLimite", 0))
        If NuloBoolean(drTe.Item("BloqueaMesaAposConta")) = False Then
            cbBloqueaMesaAposConta.Text = "Não"
        Else
            cbBloqueaMesaAposConta.Text = "Sim"
        End If



        ' Rappi  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        'tbClient_ID_Rappi.Text = NuloString(drTe.Item("Client_ID_Rappi"))
        'tbClient_Secret_Rappi.Text = NuloString(drTe.Item("Client_Secret_Rappi"))
        'tbAudience_Rappi.Text = NuloString(drTe.Item("Audience_Rappi"))
        'tbIDLoja_Rappi.Text = NuloString(drTe.Item("IDLoja_Rappi"))
        If NuloBoolean(drTe.Item("IntegracaoRappi")) = True Then
            tbIntegracaoRappiAtiva.Text = 1
        Else
            tbIntegracaoRappiAtiva.Text = 0
        End If
        If NuloBoolean(drTe.Item("AceitaPedidoAutomaticoRappi")) = 0 Then
            cbAceitaPedidoAutomaticoRappi.Text = "Não"
        Else
            cbAceitaPedidoAutomaticoRappi.Text = "Sim"
        End If
        If LeArquivoINI(nome_arquivo_ini, "RAPPI", "GerenciaPedidosRappi", 0) = 0 Then
            cbGerenciaPedidosRappi.Text = "Não"
        Else
            cbGerenciaPedidosRappi.Text = "Sim"
        End If
        ItemSel = 0
        For I = 1 To cbIDFormaPagtoDefaultRappi.Items.Count
            cbIDFormaPagtoDefaultRappi.SelectedIndex = ItemSel
            IDSel = Val(Strings.Right(cbIDFormaPagtoDefaultRappi.Text, 8))
            cbIDFormaPagtoDefaultRappi.SelectedIndex = ItemSel
            If IDSel = NuloInteger(drTe.Item("IDFormaPagtoDefaultRappi")) Then
                I = 9999
            End If
            ItemSel += 1
        Next
        ItemSel = 0
        For I = 1 To cbIDClienteDefaultRappi.Items.Count
            cbIDClienteDefaultRappi.SelectedIndex = ItemSel
            IDSel = Val(Strings.Right(cbIDClienteDefaultRappi.Text, 8))
            cbIDClienteDefaultRappi.SelectedIndex = ItemSel
            If IDSel = NuloInteger(drTe.Item("IDClienteDefaultRappi")) Then
                I = 9999
            End If
            ItemSel += 1
        Next

        If NuloInteger(tbIntegracaoRappiAtiva.Text) = 0 Then
            btnRappiAtivo.Text = "Integração não ativa"
            btnRappiAtivo.BackColor = Color.Red
            tbIntegracaoRappiAtiva.Text = 0
        Else
            btnRappiAtivo.Text = "Integração ativa"
            btnRappiAtivo.BackColor = Color.Green
            tbIntegracaoRappiAtiva.Text = 1
        End If


        ' PosControle  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        tbUserName_PosControle.Text = NuloString(drTe.Item("UserName_PosControle"))
        tbSenha_PosControle.Text = NuloString(drTe.Item("Senha_PosControle"))
        If NuloBoolean(drTe.Item("PosControle")) = 0 Then
            cbPosControle.Text = "Não"
            Label64.Visible = False
            Label71.Visible = False
            tbUserName_PosControle.Visible = False
            tbSenha_PosControle.Visible = False
        Else
            cbPosControle.Text = "Sim"
            Label64.Visible = True
            Label71.Visible = True
            tbUserName_PosControle.Visible = True
            tbSenha_PosControle.Visible = True
        End If


        ' NFce  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        chkEnviaEmailNFCE.Checked = NuloBoolean(LeArquivoINI(nome_arquivo_ini, "NFCE", "EnviaEmailNFCE", 0))
        tbEmailNFCE.Text = NuloString(LeArquivoINI(nome_arquivo_ini, "NFCE", "EmailNFCE", ""))
        tbDiaNFCE.Text = NuloString(LeArquivoINI(nome_arquivo_ini, "NFCE", "DiaNFCE", ""))


        drTe.Close()
        btnGravar.Enabled = False

    End Sub
    Private Sub frmConfiguracao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MontaTela()
        PreenchePagtoApp()

        PreencheProdutosRappi()
        MontaGridProdutosRappiBusca(tbBuscaRappi.Text)

        preencheCategorias()
        'PreencheClientesRappi()
        PreencheListaProdutos()

        Inicio()

    End Sub

    Private Sub PreencheListaProdutos()
        Dim item As ListViewItem

        If tbBuscaProd.Text = "" Then
            strSql = "Select IDProduto, CodigoProduto, Produto "
            strSql += "From tblProdutos_Local "
            strSql += "ORDER BY Produto"
        Else
            strSql = "Select IDProduto, CodigoProduto, Produto "
            strSql += "From tblProdutos_Local "
            strSql += "WHERE (Produto Like '%" & tbBuscaProd.Text & "%') "
            strSql += "ORDER BY Produto"
        End If

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstProdutos.Items.Clear()

        If dr.HasRows Then
            While dr.Read()
                item = lstProdutos.Items.Add(dr.Item("IDProduto"))
                item.SubItems.Add(dr.Item("Produto"))
            End While
            lstProdutos.Update()
            lstProdutos.EndUpdate()
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

    End Sub



    Private Sub tbDataSourceLocal_TextChanged(sender As Object, e As EventArgs) Handles tbDataSourceLocal.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbBancoDadosLocal_TextChanged(sender As Object, e As EventArgs) Handles tbBancoDadosLocal.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbUsuarioLocal_TextChanged(sender As Object, e As EventArgs) Handles tbUsuarioLocal.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbSenhaLocal_TextChanged(sender As Object, e As EventArgs) Handles tbSenhaLocal.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbDataSourceRetaguarda_TextChanged(sender As Object, e As EventArgs) Handles tbDataSourceRetaguarda.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbBancoDadosRetaguarda_TextChanged(sender As Object, e As EventArgs) Handles tbBancoDadosRetaguarda.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbUsuarioRetaguarda_TextChanged(sender As Object, e As EventArgs) Handles tbUsuarioRetaguarda.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbSenhaRetaguarda_TextChanged(sender As Object, e As EventArgs) Handles tbSenhaRetaguarda.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbIDLoja_TextChanged(sender As Object, e As EventArgs) Handles tbIDLoja.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbGuilhotina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGuilhotina.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub
    Private Sub cbImprimeEstorno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprimeEstorno.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbImprimeTransferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprimeTransferencia.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbImprimeRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprimeRecibo.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub
    Private Sub cbTextoSalao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTextoSalao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub tbPercSalao_TextChanged(sender As Object, e As EventArgs) Handles tbPercSalao.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub tbTempoLimiteMesa_TextChanged(sender As Object, e As EventArgs) Handles tbTempoLimiteMesa.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ALTEROU", "CONFIGURAÇÕES DO SISTEMA")
        End If
        GravaDados()
        btnGravar.Enabled = False
    End Sub

    Private Sub cbModoFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModoFiscal.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbImpressoraCaixa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImpressoraCaixa.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub cbEquipamentoSAT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEquipamentoSAT.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub cbImpressoraConta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImpressoraConta.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub cbNaoImprime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprime.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub btnMesas_Click(sender As Object, e As EventArgs) Handles btnMesas.Click
        fdlgMesas.ShowDialog()
    End Sub

    Private Sub cbSetorBalcao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSetorBalcao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbSetorDelivery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSetorDelivery.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbObrigaConta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbObrigaConta.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "MOTIVOS ESTORNOS/TRANSFERÊNCIAS")
        End If
        fdlgMotivoEstorno.ShowDialog()
    End Sub

    Private Sub cbGavetaCaixa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGavetaCaixa.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub btnTesteImpCaixa_Click(sender As Object, e As EventArgs) Handles btnTesteImpCaixa.Click
        If UCase(cbGuilhotina.Text) = "SIM" Then
            PaginaTeste(cbImpressoraCaixa.Text, "IMPRESSORA CAIXA", "GERAL", True)
        Else
            PaginaTeste(cbImpressoraCaixa.Text, "IMPRESSORA CAIXA", "GERAL", False)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If UCase(cbGuilhotina.Text) = "SIM" Then
            PaginaTeste(cbImpressoraConta.Text, "IMPRESSORA CONTA", "GERAL", True)
        Else
            PaginaTeste(cbImpressoraConta.Text, "IMPRESSORA CONTA", "GERAL", False)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "SETORES")
        End If
        fdlgSetores.ShowDialog()
    End Sub

    Private Sub cbGerenciaSAT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGerenciaSAT.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub cbPedeMesa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPedeMesa.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub cbGerenciaImpressao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGerenciaImpressao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "ATUALIZAÇÂO TABELAS")
        End If
        fdlgAtualizaTabelas.ShowDialog()

    End Sub

    Private Sub cbCaixaIndividualizado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCaixaIndividualizado.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub btnMensagens_Click(sender As Object, e As EventArgs) Handles btnMensagens.Click
        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ACESSOU", "MENSAGENS")
        End If
        fdlgMensagensInclusao.ShowDialog()
    End Sub

    Private Sub tbPortaBalanca_TextChanged(sender As Object, e As EventArgs) Handles tbPortaBalanca.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        fdlgDelivery_Ruas.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        fdlgDelivery_Origens.ShowDialog()
    End Sub

    Private Sub cbFixaAbreMesaCartao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFixaAbreMesaCartao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbFixaTelaPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFixaTelaPedidos.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbNaoEncerraVendasAberto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNaoEncerraVendasAberto.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbTempoLimite_TextChanged(sender As Object, e As EventArgs) Handles tbTempoLimite.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbAtualizaVendas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAtualizaVendas.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub TbFatorAjusteServico_TextChanged(sender As Object, e As EventArgs) Handles tbFatorAjusteServico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbEnviaEmailFechamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEnviaEmailFechamento.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbInformaClienteBalcao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInformaClienteBalcao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbQtdeImpressaoExpedicao_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbQtdeImpressaoExpedicao_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbQtdeImpressaoExpedicao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        fdlgPracas.ShowDialog()
    End Sub

    Private Sub TbIDEquipamento_TextChanged(sender As Object, e As EventArgs) Handles tbIDEquipamento.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub TbTextoServico_TextChanged(sender As Object, e As EventArgs) Handles tbTextoServico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbImpressoraCaixaTexto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImpressoraCaixaTexto.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbImprimeConferenciaBalcao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprimeConferenciaBalcao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbTodosRelatorios_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbCNPJSoftwareHouse_TextChanged(sender As Object, e As EventArgs) Handles tbCNPJSoftwareHouse.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbNCM_Servico_TextChanged(sender As Object, e As EventArgs) Handles tbNCM_Servico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbCSTPis_Servico_TextChanged(sender As Object, e As EventArgs) Handles tbCSTPis_Servico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbCSTCofins_Servico_TextChanged(sender As Object, e As EventArgs) Handles tbCSTCofins_Servico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbCFOP_Servico_TextChanged(sender As Object, e As EventArgs) Handles tbCFOP_Servico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbCSTIcms_Servico_TextChanged(sender As Object, e As EventArgs) Handles tbCSTIcms_Servico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbAliquota_Servico_TextChanged(sender As Object, e As EventArgs) Handles tbAliquota_Servico.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbIncluiFundoCaixa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIncluiFundoCaixa.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbImpressoraExpedicao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImpressoraExpedicao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If UCase(cbGuilhotina.Text) = "SIM" Then
            PaginaTeste(cbImpressoraExpedicao.Text, "IMPRESSORA EXPEDICAO", "GERAL", True)
        Else
            PaginaTeste(cbImpressoraExpedicao.Text, "IMPRESSORA EXPEDICAO", "GERAL", False)
        End If
    End Sub

    Private Sub CbNaoCobraServico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNaoCobraServico.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbRegistraLog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegistraLog.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
        If cbRegistraLog.Text = "SIM" Then
            btnLogEventos.Visible = True
        Else
            btnLogEventos.Visible = False
        End If
    End Sub

    Private Sub BtnLogEventos_Click(sender As Object, e As EventArgs) Handles btnLogEventos.Click
        fdlgLogsEventos.ShowDialog()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        frmCaixa.AtualizaRuas()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        frmCaixa.AtualizaClientes()
    End Sub

    Private Sub Label57_Click(sender As Object, e As EventArgs) Handles Label57.Click

    End Sub

    Private Sub CbVerificaPedidoProgramado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVerificaPedidoProgramado.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbMostraComentExpedicao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMostraComentExpedicao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbEquipamentoSAT_Delivery_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub TbTempoLimiteMesaEmEspera_TextChanged(sender As Object, e As EventArgs) Handles tbTempoLimiteMesaEmEspera.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub
    Private Sub TbUserNameIfood_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbPasswordIfood_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbMerchantIDiFood_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbGerenciaPedidosQRbox_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub TbUserNameQRbox_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbPasswordQRbox_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbIDMerchantQRbox_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs)
        'PegaToken_QRbox()
    End Sub

    Private Sub CbAceitaPedidoAutomaticoIfood_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbAceitaPedidoAutomaticoQRbox_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbIDFormaPagtoDefaultQRBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbIDFormaPagtoDefaultIfood_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbExpedicaoPadrao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExpedicaoPadrao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub CbCategoriaPropriaDelivery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoriaPropriaDelivery.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CbGerenciaPedidosRappi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGerenciaPedidosRappi.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"

        If cbGerenciaPedidosRappi.Text = "Sim" Then
            btnRappiAtivo.Visible = True
            Label82.Visible = True
            Label93.Visible = True
            cbIDClienteDefaultRappi.Visible = True
            cbIDFormaPagtoDefaultRappi.Visible = True
        Else
            btnRappiAtivo.Visible = False
            Label82.Visible = False
            Label93.Visible = False
            cbIDClienteDefaultRappi.Visible = False
            cbIDFormaPagtoDefaultRappi.Visible = False
            tbIntegracaoRappiAtiva.Text = 0
            btnRappiAtivo.Text = "Integração não ativa"
            btnRappiAtivo.BackColor = Color.Red
        End If
    End Sub

    Private Sub BtnRappiAtivo_Click(sender As Object, e As EventArgs) Handles btnRappiAtivo.Click
        If NuloInteger(tbIntegracaoRappiAtiva.Text) = 1 Then
            btnRappiAtivo.Text = "Integração não ativa"
            btnRappiAtivo.BackColor = Color.Red
            tbIntegracaoRappiAtiva.Text = 0
        Else
            btnRappiAtivo.Text = "Integração ativa"
            btnRappiAtivo.BackColor = Color.Green
            tbIntegracaoRappiAtiva.Text = 1
        End If
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbUserNameRappi_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbIDMerchantRappi_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbAceitaPedidoAutomaticoRappi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAceitaPedidoAutomaticoRappi.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbIDFormaPagtoDefaultRappi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIDFormaPagtoDefaultRappi.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbAcrescimo_W21_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAcrescimo_W21.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbTextoServicoCupom_TextChanged(sender As Object, e As EventArgs) Handles tbTextoServicoCupom.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbNaoMostraProdutosZeroConta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNaoMostraProdutosZeroConta.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub CbTocaCampainhaApp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbToqueApp.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub ChkRelatProdutos_CheckedChanged(sender As Object, e As EventArgs) Handles chkRelatProdutos.CheckedChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub ChkRelatServico_CheckedChanged(sender As Object, e As EventArgs) Handles chkRelatServico.CheckedChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub ChkRelatEstorno_CheckedChanged(sender As Object, e As EventArgs) Handles chkRelatEstorno.CheckedChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbIDLoja_Rappi_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub TbClient_Secret_Rappi_TextChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click

        If lstProdutosRappi.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "È necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If lstProdutosBuscaRappi.SelectedItems.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "È necessário selecionar um produto Gourmet Visual"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        Dim frm11 As fdlgMensagemBox = New fdlgMensagemBox
        frm11.lbMensagem.Text = "Confirma o vinculo do produto" & vbCrLf & lstProdutosBuscaRappi.SelectedItems(0).SubItems(2).Text
        frm11.btnNao.Visible = True
        frm11.btnSim.Visible = True
        frm11.btnOK.Visible = False
        frm11.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm11.ShowDialog()
        If RetornoMsg = False Then Exit Sub


        strSql = "UPDATE tblProdutosExterno SET "
        strSql &= "IDProduto=" & lstProdutosBuscaRappi.SelectedItems(0).SubItems(0).Text & ", "
        strSql &= "CodigoProduto=" & lstProdutosBuscaRappi.SelectedItems(0).SubItems(1).Text & " "
        strSql &= "WHERE (CodigoProdutoExterno='" & lstProdutosRappi.SelectedItems(0).SubItems(3).Text & "')"
        ExecutaStrServidor(strSql)

        AtualizaTabelaProdutosExterno()

        PreencheProdutosRappi()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lstProdutosRappi.SelectedItems.Count = 0 Then
            frm.lbMensagem.Text = "È necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Deseja realmente desvincular o produto" & vbCrLf & lstProdutosRappi.SelectedItems(0).SubItems(4).Text
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        ExecutaStrServidor("DELETE from tblProdutosExterno WHERE (CodigoProdutoExterno='" & lstProdutosRappi.SelectedItems(0).SubItems(3).Text & "')")

        PreencheProdutosRappi()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        fdlgProdutos_Inclusao.ShowDialog()
        frmInicio.AtualizaTabela("Produtos")
        MontaGridProdutosRappiBusca(tbBuscaRappi.Text)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If lstProdutosBuscaRappi.SelectedItems.Count = 0 Then
            frm.lbMensagem.Text = "È necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbCodProRappi.Text) = "" Then
            frm.lbMensagem.Text = "È necessário informar código do produto Rappi"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Confirma o vinculo do novo produto" & vbCrLf & lstProdutosBuscaRappi.SelectedItems(0).SubItems(2).Text
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub


        strSql = "INSERT tblProdutosExterno (IDProduto, CodigoProduto, IDLoja, Aplicativo, ProdutoExterno, CodigoProdutoExterno) VALUES ("
        strSql &= to_sql(lstProdutosBuscaRappi.SelectedItems(0).SubItems(0).Text) & ","
        strSql &= to_sql(lstProdutosBuscaRappi.SelectedItems(0).SubItems(1).Text) & ","
        strSql &= to_sql(IDLoja) & ","
        strSql &= to_sql("RAPPI") & ","
        strSql &= to_sql(Trim(Replace(lstProdutosBuscaRappi.SelectedItems(0).SubItems(2).Text, "-", " "))) & ","
        strSql &= to_sql(tbCodProRappi.Text) & ")"
        ExecutaStrServidor(strSql)

        PreencheProdutosRappi()
    End Sub

    Private Sub TbBuscaRappi_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaRappi.TextChanged
        MontaGridProdutosRappiBusca(tbBuscaRappi.Text)
    End Sub

    Private Sub CbIDClienteDefaultRappi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIDClienteDefaultRappi.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        If NuloString(cbToqueApp.Text) <> "" Then
            If cbToqueApp.Text = "Som padão" Then
                My.Computer.Audio.Play(Application.StartupPath & "\toque.wav", AudioPlayMode.Background)
            Else
                If cbToqueApp.Text = "Som 01" Then
                    My.Computer.Audio.Play(Application.StartupPath & "\toque01.wav", AudioPlayMode.Background)
                Else
                    If cbToqueApp.Text = "Som 02" Then
                        My.Computer.Audio.Play(Application.StartupPath & "\toque02.wav", AudioPlayMode.Background)
                    Else
                        If cbToqueApp.Text = "Som 03" Then
                            My.Computer.Audio.Play(Application.StartupPath & "\toque03.wav", AudioPlayMode.Background)
                        Else
                            If cbToqueApp.Text = "Som 04" Then
                                My.Computer.Audio.Play(Application.StartupPath & "\toque04.wav", AudioPlayMode.Background)
                            Else
                                If cbToqueApp.Text = "Som 05" Then
                                    My.Computer.Audio.Play(Application.StartupPath & "\toque05.wav", AudioPlayMode.Background)
                                Else
                                    If cbToqueApp.Text = "Som 06" Then
                                        My.Computer.Audio.Play(Application.StartupPath & "\toque06.wav", AudioPlayMode.Background)
                                    Else
                                        If cbToqueApp.Text = "Som 07" Then
                                            My.Computer.Audio.Play(Application.StartupPath & "\toque07.wav", AudioPlayMode.Background)
                                        Else
                                            If cbToqueApp.Text = "Som 08" Then
                                                My.Computer.Audio.Play(Application.StartupPath & "\toque08.wav", AudioPlayMode.Background)
                                            Else
                                                If cbToqueApp.Text = "Som 09" Then
                                                    My.Computer.Audio.Play(Application.StartupPath & "\toque09.wav", AudioPlayMode.Background)
                                                Else
                                                    My.Computer.Audio.Play(Application.StartupPath & "\toque10.wav", AudioPlayMode.Background)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        My.Computer.Audio.Stop()
    End Sub

    Private Sub TbBuscaRappiVinc_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaRappiVinc.TextChanged
        PreencheProdutosRappi()
    End Sub

    Private Sub BtnApp_Click(sender As Object, e As EventArgs) Handles btnApp.Click
        fdlgAplicativos.ShowDialog()
    End Sub

    Private Sub CbBloqueaMesaAposConta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBloqueaMesaAposConta.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        fdlgTerminaisPagtoDigital.ShowDialog()
    End Sub

    Private Sub LstProdutosRappi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProdutosRappi.SelectedIndexChanged

    End Sub

    Private Sub cbBackupCupomFiscal_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub PanelGeral_Paint(sender As Object, e As PaintEventArgs) Handles PanelGeral.Paint

    End Sub

    Private Sub cbImprimeConsumo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprimeConsumo.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbQtdePessoasBalcao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQtdePessoasBalcao.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbReimprimeComanda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbReimprimeComanda.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub cbQtdeVendas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMediaQtdeVendas.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub
    Private Sub cbFecDeliveryCamelo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbFecDeliveryCamelo.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbBuscaProd_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaProd.TextChanged
        PreencheListaProdutos()
    End Sub

    Private Sub btnSelecionaFoto_Click(sender As Object, e As EventArgs) Handles btnSelecionaFoto.Click


        If lstProdutos.SelectedItems.Count > 0 Then
            OpenFileDialog.Title = "Selecionar Foto"
            OpenFileDialog.Filter = "Imagens|*.png;*.jpg;*.bmp;*.gif"
            If OpenFileDialog.ShowDialog = DialogResult.OK Then
                PictureBox.Image = Image.FromFile(OpenFileDialog.FileName)

                strSql = "UPDATE tblProdutos_Local SET "
                strSql += "FotoProduto='" & NuloString(OpenFileDialog.FileName) & "' "
                strSql += "WHERE IDProduto = " & lstProdutos.SelectedItems(0).Text
                ExecutaStr(strSql)

                strSql = "UPDATE tblProdutos SET "
                strSql += "FotoProduto='" & NuloString(OpenFileDialog.FileName) & "' "
                strSql += "WHERE IDProduto = " & lstProdutos.SelectedItems(0).Text
                ExecutaStrServidor(strSql)
            End If
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um produto"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        End If

    End Sub

    Private Sub lstProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProdutos.SelectedIndexChanged
        If lstProdutos.SelectedItems.Count > 0 Then
            strSql = "Select IDProduto, CodigoProduto, Produto, FotoProduto "
            strSql += "From tblProdutos_Local "
            strSql += "WHERE IDProduto = " & lstProdutos.SelectedItems(0).Text

            Dim con As New SqlConnection(strCon)
            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                dr.Read()
                If NuloString(dr.Item("FotoProduto")) <> "" Then
                    PictureBox.Image = Image.FromFile(dr.Item("FotoProduto"))
                Else
                    PictureBox.Image = Nothing
                End If
            Else
                PictureBox.Image = Nothing
            End If
            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()
        End If
    End Sub

    Private Sub lstProdutos_Click(sender As Object, e As EventArgs) Handles lstProdutos.Click
        If lstProdutos.SelectedItems.Count > 0 Then
            strSql = "Select IDProduto, CodigoProduto, Produto, FotoProduto "
            strSql += "From tblProdutos_Local "
            strSql += "WHERE IDProduto = " & lstProdutos.SelectedItems(0).Text

            Dim con As New SqlConnection(strCon)
            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                dr.Read()
                If NuloString(dr.Item("FotoProduto")) <> "" Then
                    PictureBox.Image = Image.FromFile(dr.Item("FotoProduto"))
                Else
                    PictureBox.Image = Nothing
                End If
            Else
                PictureBox.Image = Nothing
            End If
            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()
        End If
    End Sub

    Private Sub cbImprimeExpandido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImprimeExpandido.SelectedIndexChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub btnGrupos_Click(sender As Object, e As EventArgs) Handles btnGrupos.Click
        fdlgGruposPedidos.ShowDialog()
    End Sub

    Private Sub chkEmailNFCE_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnviaEmailNFCE.CheckedChanged
        If chkEnviaEmailNFCE.Checked = False Then
            tbDiaNFCE.Enabled = False
            tbEmailNFCE.Enabled = False
            tbDiaNFCE.Text = ""
            tbEmailNFCE.Text = ""
        Else
            tbDiaNFCE.Enabled = True
            tbEmailNFCE.Enabled = True
        End If
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbEmailNFCE_TextChanged(sender As Object, e As EventArgs) Handles tbEmailNFCE.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbDiaNFCE_TextChanged(sender As Object, e As EventArgs) Handles tbDiaNFCE.TextChanged
        btnGravar.Enabled = True
        Atualiza += "L"
    End Sub

    Private Sub tbUserName_PosControle_TextChanged(sender As Object, e As EventArgs) Handles tbUserName_PosControle.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub tbSenha_PosControle_TextChanged(sender As Object, e As EventArgs) Handles tbSenha_PosControle.TextChanged
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub

    Private Sub cbPosControle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPosControle.SelectedIndexChanged
        If cbPosControle.Text = "Não" Then
            Label64.Visible = False
            Label71.Visible = False
            tbUserName_PosControle.Visible = False
            tbSenha_PosControle.Visible = False
        Else
            Label64.Visible = True
            Label71.Visible = True
            tbUserName_PosControle.Visible = True
            tbSenha_PosControle.Visible = True
        End If
        btnGravar.Enabled = True
        Atualiza += "G"
    End Sub
End Class