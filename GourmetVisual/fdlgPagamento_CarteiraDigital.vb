Imports System.Data.SqlClient
Imports GourmetVisual.classModelsShipay

Public Class fdlgPagamento_CarteiraDigital
    Dim cpf As String
    Dim email As String
    Dim FirstName As String
    Dim LastName As String
    Dim phone As String
    Dim ItemTitle As String = "PAGAMENTO DIGITAL"
    Dim Quantity As Decimal
    Dim UnitPrice As Decimal
    Dim OrderRef As String
    Dim Total As Decimal
    Dim Wallet As String

    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click

        If NuloString(tbOrderID.Text) = "" Then
            ExecutaStr("DELETE tblVendasPagto WHERE IDVendaPagto=" & tbIDVendaPagto.Text)
        End If

        Me.Dispose()
        Me.Close()

    End Sub
    Function MontaBotoes() As Boolean
        Dim retorno As Boolean = False
        Dim api As New classShipay()
        Dim ret = api.getCarteiras()
        Dim json = ret.json
        Dim lista = ret.lista
        Dim myfont As New Font("Sans Serif", 9, FontStyle.Bold)
        'Dim TotalReg As Integer = 1

        PanelPagtos.Controls.Clear()

        If Not IsNothing(lista) Then
            retorno = True
            Dim btnArray(lista.Count) As System.Windows.Forms.Button
            For i As Integer = 0 To lista.Count - 1
                btnArray(i) = New System.Windows.Forms.Button
            Next i

            For i = 0 To lista.Count - 1
                With (btnArray(i))
                    .Tag = lista(i).Name

                    Select Case lista(i).Name
                        Case "pix"
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.Pix_botao
                            .BackgroundImageLayout = ImageLayout.Stretch

                        Case "mercadopago"
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.MercadoPago
                            .BackgroundImageLayout = ImageLayout.Stretch

                        Case "ame"
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.ame
                            .BackgroundImageLayout = ImageLayout.Zoom

                        Case "cielo"
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.cielo
                            .BackgroundImageLayout = ImageLayout.Stretch

                        Case "pagseguro"
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.PagSeguro
                            .BackgroundImageLayout = ImageLayout.Stretch

                        Case "picpay"
                            .BackgroundImage = GourmetVisual.My.Resources.Resources.PicPay
                            .BackgroundImageLayout = ImageLayout.Stretch

                        Case Else
                            .Text = UCase(lista(i).Name)
                    End Select


                    .Width = 165
                    .Height = 80
                    .ForeColor = Color.Red
                    .BackColor = Color.White
                    .FlatStyle = FlatStyle.Standard
                    .Font = myfont

                    'carregaVisualComponente(btnArray(n), 20, 20)

                    Me.PanelPagtos.Controls.Add(btnArray(i))

                    AddHandler .Click, AddressOf Me.ClickButton_Pagtos
                    .Margin = New Padding(0, 0, 0, 0)

                End With
            Next
        Else
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Erro de comunicação com a operadora" & vbCrLf & "Verifique sua internet"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(tbIDVendaPagto.Text) & ")"
            ExecutaStr(strSql)

            Me.Dispose()
            Me.Close()
        End If

        Return retorno

    End Function
    Private Sub ClickButton_Pagtos(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim txtDescricao As String = ""
        If CType(sender, Button).BackColor = Color.White Then
            CType(sender, Button).BackColor = Color.LawnGreen
            txtDescricao = UCase(CType(sender, Button).Tag)
        Else
            CType(sender, Button).BackColor = Color.White
            txtDescricao = ""
        End If

        Dim order As New ShipayOrderRequest()
        order.Items = New List(Of Item)

        Dim buyer As New Buyer
        buyer.Cpf = cpf
        buyer.Email = email
        buyer.FirstName = FirstName
        buyer.LastName = LastName
        buyer.Phone = phone
        order.Buyer = buyer

        If NuloBoolean(tbPagtoIntegral.Text) = True Then

            strSql = "Select tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasCombo.Produto AS ProdutoCombo, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto As IDVendaMovto_Combo, tblVendasCombo.Venda As VendaCombo, tblVendasCombo.VendaServico AS VendaServicoCombo, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada "
            strSql += "From tblVendas INNER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda LEFT OUTER Join tblVendasCombo On tblVendasMovto.IDVendaMovto = tblVendasCombo.IDVendaMovto CROSS Join tblLojas_Local "
            strSql += "Group BY tblVendas.IDVenda, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.DataVenda, tblVendas.Desconto, tblVendas.PercDesconto, tblVendas.Servico, tblVendas.PercServico, tblVendas.QtdPessoas, tblVendas.HoraAbertura, tblVendas.ValorEstacionamento, tblVendas.Caixa, tblVendas.Atendente, tblVendasMovto.Produto, tblVendasMovto.Venda, tblVendasMovto.VendaServico, tblVendasCombo.Produto, tblVendasMovto.Excluido, tblVendasCombo.IDVendaCombo, tblVendasCombo.IDVendaMovto, tblVendasCombo.Venda, tblVendasCombo.VendaServico, tblLojas_Local.Loja, tblLojas_Local.Endereco, tblLojas_Local.Numero, tblLojas_Local.Bairro, tblLojas_Local.Cidade, tblLojas_Local.Estado, tblLojas_Local.Telefone, tblLojas_Local.CEP, tblVendas.FlagFechada "
            strSql += "HAVING(tblVendasMovto.Excluido = 0) And (tblVendas.IDVenda=" & tbIDVenda.Text & ") And (tblVendas.FlagFechada=0) "
            strSql += "ORDER BY tblVendasMovto.Produto, tblVendasCombo.IDVendaCombo"

            Dim dap = New SqlDataAdapter(strSql, strCon)
            dap.SelectCommand.CommandType = CommandType.Text
            Dim ds As New DataSet()
            dap.Fill(ds, "Vendas")
            Total = 0

            For i As Integer = 0 To ds.Tables("Vendas").Rows.Count - 1

                Dim item As New Item
                item.ItemTitle = NuloString(ds.Tables("Vendas").Rows(i).Item("Produto"))
                item.Quantity = Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")), "#0.000")
                item.UnitPrice = Format(NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico")), "#0.00")
                Total += NuloDecimal(ds.Tables("Vendas").Rows(i).Item("Qtde")) * NuloDecimal(ds.Tables("Vendas").Rows(i).Item("VendaServico"))
                order.Items.Add(item)
            Next
        Else
            Dim item As New Item
            item.ItemTitle = ItemTitle
            item.Quantity = Quantity
            item.UnitPrice = Format(UnitPrice, "#0.00")
            order.Items.Add(item)
        End If
        Total = Format(NuloDecimal(Total), "#0.00")

        strSql = "SELECT IDVenda, NumVenda FROM tblVendas WHERE IDVenda = " & NuloInteger(tbIDVenda.Text)
        OrderRef = NuloString(PegaValorCampo("NumVenda", strSql, strCon))
        order.OrderRef = OrderRef
        order.Total = Format(NuloDecimal(Total), "#0.00")
        order.Wallet = CType(sender, Button).Tag
        lbDescricaoPagto.Text = UCase(CType(sender, Button).Tag)

        Dim c As New classShipay()
        Dim ret = c.postOrder(order)
        Dim a = ret.json

        If InStr(a, ":400") > 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = a
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        tbOrderID.Text = ret.orderResponse.OrderId


        tbStatus.Text = ret.orderResponse.Status
        tbQRcode.Text = NuloString(ret.orderResponse.QrCodeText)

        If NuloInteger(tbIDVendaPagto.Text) <> 0 Then
            strSql = "UPDATE tblVendasPagto SET "
            strSql += "Descricao = '" & lbDescricaoPagto.Text & "', "
            strSql += "IDPagtoDigital = '" & tbOrderID.Text & "', "
            strSql += "Terminal = '" & NomeTerminal & "', "
            strSql += "QRcode = '" & tbQRcode.Text & "', "
            strSql += "StatusDigital = '" & tbStatus.Text & "' "
            strSql += "WHERE IDVendaPagto=" & tbIDVendaPagto.Text
            ExecutaStr(strSql)
        Else
            strSql = "INSERT tblVendasPagto "
            strSql += "(IDVenda,IDFormaPagto,Descricao,ValorPago,ECartao,TaxaCartao,Tipo,Cupom,IDCliente,IDPendencia,Terminal,QRcode,StatusDigital) VALUES ("
            strSql += to_sql(tbIDVenda.Text) & ","
            strSql += to_sql(tbIDFormaPagto.Text) & ","
            strSql += to_sql(lbDescricaoPagto.Text) & ","
            strSql += to_sql(Replace(Total, ",", ".")) & ","
            strSql += "0,"
            strSql += "0,"
            strSql += "'R', "
            strSql += "0,"
            strSql += "0,"
            strSql += "0,"
            strSql += to_sql(NomeTerminal) & ","
            strSql += to_sql(tbQRcode.Text) & ","
            strSql += to_sql(tbStatus.Text) & ")"
            ExecutaStr(strSql)
            tbIDVendaPagto.Text = NuloInteger(PegaID("IDVendaPagto", "tblVendasPagto", "L"))
        End If


        pbQRCode.Image = GerarQRCode(300, 300, ret.orderResponse.QrCodeText)
        lbStatus.Text = "Aguardando aprovação..."
        Timer.Enabled = True
        Timer.Start()


        PanelPagtos.Visible = False
        Label1.Visible = False
        btnCancelar.Visible = True
        Button1.Visible = True



        'If PanelPagtos.Controls.Count > 0 Then
        'For i As Integer = 0 To PanelPagtos.Controls.Count - 1
        'If PanelPagtos.Controls.Item(i).Text <> txtDescricao Then
        'PanelPagtos.Controls.Item(i).BackColor = Color.White
        'End If
        'Next i
        'End If
    End Sub
    Public Function GerarQRCode(ByVal width As Integer, ByVal height As Integer, ByVal text As String) As Bitmap
        Try
            Dim bw = New ZXing.BarcodeWriter()
            Dim encOptions = New ZXing.Common.EncodingOptions()
            encOptions.Width = width
            encOptions.Height = height
            encOptions.Margin = 0
            bw.Options = encOptions
            bw.Format = ZXing.BarcodeFormat.QR_CODE
            Dim resultado = New Bitmap(bw.Write(text))
            Return resultado
        Catch
            Throw
        End Try
    End Function
    Private Sub FdlgPagamento_CarteiraDigital_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        strSql = "SELECT Terminal, ClientID, ImpressoraPagtoDigital, Status FROM tblTerminaisPagtoDigital WHERE Terminal = '" & NuloString(NomeTerminal) & "'"
        ClientID_Shipay = NuloString(PegaValorCampo("ClientID", strSql, strCon))
        If ClientID_Shipay = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Terminal não configurado para pagamento digital"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(tbIDVendaPagto.Text) & ")"
            ExecutaStr(strSql)

            Me.Dispose()
            Me.Close()
            Exit Sub
        Else
            If access_token_Shipay = "" Then
                Dim api As New classShipay()
                api.getToken()
            End If

            If MontaBotoes() = True Then
                cpf = ""
                email = ""
                FirstName = ""
                LastName = ""
                phone = ""
                Quantity = 1
                UnitPrice = tbValor.Text
                strSql = "SELECT IDVenda, NumVenda FROM tblVendas WHERE IDVenda = " & NuloInteger(tbIDVenda.Text)
                OrderRef = NuloString(PegaValorCampo("NumVenda", strSql, strCon))
                tbValor.Text = Format(NuloDecimal(tbValor.Text), "#0.00")
                Total = tbValor.Text
                Wallet = ""
            End If
        End If

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick


        Dim c As New classShipay()
        Dim ret = c.getStatus(tbOrderID.Text)

        If ret.json <> "" Then
            tbStatus.Text = ret.statusResponse.Status
            If tbStatus.Text = "approved" Then
                strSql = "UPDATE tblVendasPagto SET StatusDigital='approved' WHERE IDVendaPagto=" & tbIDVendaPagto.Text
                ExecutaStr(strSql)

                lbStatus.Text = "Aprovado !!!"
                Timer.Stop()
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Aprovado !!!"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Me.Dispose()
                Me.Close()
            Else
                If tbStatus.Text = "refunded" And NuloString(tbIDVendaPagto.Text) <> "" Then
                    Timer.Stop()
                    lbStatus.Text = "Pagamento devolvido ao comprador"
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "Pagamento devolvido ao comprador" & vbCrLf & "Tente novamente"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()

                    strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(tbIDVendaPagto.Text) & ")"
                    ExecutaStr(strSql)
                    If NuloString(tbOrderID.Text) <> "" Then
                        Dim cc As New classShipay()
                        Dim retC = cc.deleteOrder(NuloString(tbOrderID.Text))
                    End If

                    lbStatus.Text = ""
                    tbIDVendaPagto.Text = ""
                    PanelPagtos.Visible = True
                    Label1.Visible = True
                    btnCancelar.Visible = False
                    Button1.Visible = False
                    MontaBotoes()

                Else
                    If tbStatus.Text = "cancelled" And NuloString(tbIDVendaPagto.Text) <> "" Then
                        Timer.Stop()
                        lbStatus.Text = "Pedido cancelado na carteira digital"
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Pedido cancelado na carteira digital" & vbCrLf & "Tente novamente"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()

                        strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(tbIDVendaPagto.Text) & ")"
                        ExecutaStr(strSql)
                        If NuloString(tbOrderID.Text) <> "" Then
                            Dim ccc As New classShipay()
                            Dim retCC = ccc.deleteOrder(NuloString(tbOrderID.Text))
                        End If

                        lbStatus.Text = ""
                        tbIDVendaPagto.Text = ""
                        PanelPagtos.Visible = True
                        Label1.Visible = True
                        btnCancelar.Visible = False
                        Button1.Visible = False
                        MontaBotoes()
                    End If

                End If

            End If
        Else
            Timer.Stop()
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Erro na comunicação com a operadora" & vbCrLf & "Deseja cancelar a operação"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = True Then
                Dim retC = c.getStatus(tbOrderID.Text)
                If retC.statusResponse.Status <> "approved" Then

                    strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(tbIDVendaPagto.Text) & ")"
                    ExecutaStr(strSql)

                    If NuloString(tbOrderID.Text) <> "" Then
                        Dim ccc As New classShipay()
                        Dim retCC = ccc.deleteOrder(NuloString(tbOrderID.Text))
                    End If

                    lbStatus.Text = ""
                    tbIDVendaPagto.Text = ""
                    PanelPagtos.Visible = True
                    Label1.Visible = True
                    btnCancelar.Visible = False
                    Button1.Visible = False
                    MontaBotoes()
                Else
                    Timer.Start()
                End If
            Else
                Timer.Start()
            End If

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ImprimeQRcode(tbIDVendaPagto.Text)
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If NuloString(tbStatus.Text) = "approved" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Pagamento digital aprovado, não será possivel cancelar"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
        Else
            strSql = "Delete From tblVendasPagto WHERE (IDVendaPagto = " & NuloInteger(tbIDVendaPagto.Text) & ")"
            ExecutaStr(strSql)
            If NuloString(tbOrderID.Text) <> "" Then
                Dim c As New classShipay()
                Dim ret = c.deleteOrder(NuloString(tbOrderID.Text))
            End If

            lbStatus.Text = ""
            tbIDVendaPagto.Text = ""
            PanelPagtos.Visible = True
            Label1.Visible = True
            btnCancelar.Visible = False
            Button1.Visible = False
            MontaBotoes()

        End If

    End Sub
End Class