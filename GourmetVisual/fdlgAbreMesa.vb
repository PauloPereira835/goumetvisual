Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class fdlgAbreMesa

    Dim AlteraQtd As Boolean = False
    Dim Foco As String
    Private Sub Confirma()

        Dim StMesa As String

        If tbPercDesconto.Text = "" Then tbPercDesconto.Text = NuloString(0)
        QtdPessoas = NuloInteger(tbQtdePessoas.Text)

        If IDVenda = 0 Then
            strSql = "Select IDVenda, NumMesa, FlagFechada, Excluido From tblVendas Where (NumMesa = " & tbNMesa.Text & ") And (FlagFechada = 0) And (Excluido = 0)"
            IDVenda = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))
            If IDVenda = 0 Then
                System.Threading.Thread.Sleep(1000)
                IDVenda = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))
            End If
        End If

        Dim St As String
        If IDVenda = 0 Then
            Dim PercServ As Decimal = 0
            strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas "
            strSql += "From tblMesas "
            strSql += "Where (NumMesa = " & tbNMesa.Text & ")"
            St = NuloString(PegaValorCampo("Status", strSql, strCon))
            If St = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Mesa/Cartão " & tbNMesa.Text & " inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbNMesa.Focus()
                Exit Sub
            Else
                If St = "B" Then
                    StMesa = "B"
                    PercServ = 0
                Else
                    StMesa = "S"
                    PercServ = NuloDecimal(tbServico.Text)
                End If
            End If

            AbreVenda(NuloInteger(tbNMesa.Text), NuloDecimal(tbPercDesconto.Text), NuloDecimal(PercServ), lbGarcon.Text, NuloInteger(tbIDFuncionario.Text), NuloInteger(tbQtdePessoas.Text), StMesa)

            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "ABRIU", "MESA/CARTÃO " & tbNMesa.Text)
            End If
        Else
            If RegistraLog = True Then
                IncluirLog(NomeTerminal, Operador, "EDITOU", "MESA/CARTÃO " & tbNMesa.Text)
            End If

            strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbNMesa.Text & ")"
            St = NuloString(PegaValorCampo("Status", strSql, strCon))
            If TerminalVenda = False Then
                EditaVenda(NuloDecimal(tbPercDesconto.Text), NuloDecimal(tbServico.Text), lbGarcon.Text, NuloInteger(tbIDFuncionario.Text), NuloInteger(tbQtdePessoas.Text), St)
            Else
                strSql = "Select NumMesa, Impresso From tblMesas Where (NumMesa = " & tbNMesa.Text & ")"
                If NuloBoolean(PegaValorCampo("Impresso", strSql, strCon)) = True Then
                    If NivelFuncionario < 3 Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Conta já enviada. É necessário reabri-la"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbNMesa.Text = ""
                        tbNMesa.Focus()
                        Exit Sub
                    Else
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Conta já enviada. Deseja reabri-la"
                        frm.btnNao.Visible = True
                        frm.btnSim.Visible = True
                        frm.btnOK.Visible = False
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                        frm.ShowDialog()
                        If RetornoMsg = False Then
                            tbNMesa.Text = ""
                            tbNMesa.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        strSql = "UPDATE tblMesas Set "
        strSql &= "UltimoPedido='" & Now & "', "
        strSql &= "Flag=1,"
        strSql &= "Impresso=0 "
        strSql &= "WHERE (NumMesa=" & tbNMesa.Text & ")"
        ExecutaStr(strSql)

        If TableAtivo = True Then
            InformaStatusTablet(tbNMesa.Text)
        End If

        strSql = "Select IDVenda, NomeCliente From tblVendas Where (IDVenda=" & IDVenda & ")"
        frmSalao.lbNomeCliente.Text = NuloString(PegaValorCampo("NomeCliente", strSql, strCon))

        MesaImpressa = False

        frmSalao.MontaBotoesMesas()
        frmSalao.tbMesa.Text = tbNMesa.Text
        frmSalao.tbCodigoProduto.Focus()

        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub MontaMesas()

        Dim n As Integer = 0
        Dim strSql As String

        strSql = "Select tblMesas.NumMesa, tblMesas.Flag, tblMesas.Impresso, tblPracas.IDFuncionario "
        strSql += "From tblMesas INNER Join tblPracas On tblMesas.Praca = tblPracas.Praca "
        strSql += "Group By tblMesas.NumMesa, tblMesas.Flag, tblMesas.Impresso, tblPracas.IDFuncionario "
        strSql += "HAVING(tblPracas.IDFuncionario = " & IDOperador & ") "
        strSql += "ORDER BY tblMesas.NumMesa"

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim myfont As Font
        myfont = New Font("Sans Serif", 14, FontStyle.Bold)

        Dim btnArray(40) As System.Windows.Forms.Button
        For i As Integer = 0 To 40
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        Me.PanelMesas.Controls.Clear()

        If dr.HasRows Then
            While (dr.Read())
                With (btnArray(n))
                    ' .TabIndex = dr.GetInt32(0)
                    '.Tag = NuloInteger(dr(1))
                    .Text = NuloString(dr.Item("NumMesa"))
                    .Width = 85
                    .Height = 50
                    .TabStop = False

                    If NuloBoolean(dr.Item("Flag")) = False Then
                        .BackColor = Color.Gold
                        .ForeColor = Color.Black
                    Else
                        .BackColor = Color.DeepSkyBlue
                        .ForeColor = Color.Black
                    End If

                    frmPagamento.carregaVisualComponente(btnArray(n), 20, 20)
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 0
                    .Font = myfont
                    .FlatAppearance.BorderColor = Color.Silver
                    Me.PanelMesas.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Mesas

                    n += 1
                End With
            End While
        End If

        con.Close()
        con.Dispose()



    End Sub
    Private Sub ClickButton_Mesas(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim NumMesa As Integer = NuloInteger(CType(sender, Button).Text)
        tbNMesa.Text = NuloString(NumMesa)




        Dim StMesa As String

        If tbPercDesconto.Text = "" Then tbPercDesconto.Text = NuloString(0)
        QtdPessoas = NuloInteger(tbQtdePessoas.Text)

        If IDVenda = 0 Then
            strSql = "Select IDVenda, NumMesa, FlagFechada, Excluido From tblVendas Where (NumMesa = " & NumMesa & ") And (FlagFechada = 0) And (Excluido = 0)"
            IDVenda = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))
        End If

        If IDVenda = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = TextoMesaPAR & " ( " & NumMesa & " ) não aberta. Deseja realmente abrir"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            If RetornoMsg = False Then Exit Sub

        End If

        strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & NumMesa & ")"
        If NuloString(PegaValorCampo("Status", strSql, strCon)) = "B" Then
            StMesa = "B"
        Else
            StMesa = "S"
        End If
        If IDVenda = 0 Then
            AbreVenda(NuloInteger(NumMesa), NuloDecimal(tbPercDesconto.Text), NuloDecimal(tbServico.Text), lbGarcon.Text, NuloInteger(tbIDFuncionario.Text), NuloInteger(tbQtdePessoas.Text), StMesa)

            strSql = "UPDATE tblMesas SET "
            strSql &= "UltimoPedido='" & Now & "', "
            strSql &= "Flag=1,"
            strSql &= "Impresso=0 "
            strSql &= "WHERE (NumMesa=" & NumMesa & ")"
            ExecutaStr(strSql)
        Else
            EditaVenda(NuloDecimal(tbPercDesconto.Text), NuloDecimal(tbServico.Text), lbGarcon.Text, NuloInteger(tbIDFuncionario.Text), NuloInteger(tbQtdePessoas.Text), StMesa)
        End If

        MesaImpressa = False

        frmSalao.MontaBotoesMesas()
        frmSalao.tbMesa.Text = NuloString(NumMesa)
        frmSalao.tbCodigoProduto.Focus()

        Me.Dispose()
        Me.Close()

    End Sub
    Private Sub BuscaAtendente(CodFunc As Integer)

        Dim con As New SqlConnection()
        strSql = "Select IDFuncionario, Funcionario, CodigoFuncionario From tblFuncionarios_Local Where (CodigoFuncionario=" & CodFunc & ")"
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()

            Dim IDSel As Integer
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            For I = 1 To cbCodigoGarcon.Items.Count
                cbCodigoGarcon.SelectedIndex = ItemSel
                IDSel = NuloInteger(Strings.Right(cbCodigoGarcon.Text, 8))
                cbCodigoGarcon.SelectedIndex = ItemSel
                If IDSel = CodFunc Then
                    I = 9999
                End If
                ItemSel += 1
            Next
        Else
            cbCodigoGarcon.Text = ""
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Atendente/Garçon não cadastrado"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            lbGarcon.Text = ""
            tbCodigoGarcon.Text = ""
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

    End Sub

    Private Sub PreencheGarcon()
        Dim strSql As String
        Dim con As New SqlConnection(strCon)

        strSql = "Select Funcionario, IDFuncionario, CodigoFuncionario From tblFuncionarios_Local Order By Funcionario"

        con.Open()
        Dim comandoLJS As New SqlCommand(strSql, con)
        comandoLJS.CommandType = CommandType.Text
        Dim dr As SqlDataReader = comandoLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            cbCodigoGarcon.Items.Add("")
            While (dr.Read())
                cbCodigoGarcon.Items.Add(NuloString(dr.Item("Funcionario")) & Space(100) & NuloString(dr.Item("CodigoFuncionario")))
                'cbCodigoGarcon.Items.Add(NuloString(dr.Item("Funcionario")))
                'cbCodigoGarcon.Items.Add(NuloString(dr.Item("Funcionario")), dr.Item("CodigoFuncionario"))

            End While
        End If


        comandoLJS.Dispose()
        con.Dispose()
        con.Close()


    End Sub

    Private Sub fdlgAbreMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If tbPraca.Text <> "" Then
            Panel1.Visible = False
            PanelTeclado.Visible = False
            PanelMesas.Location = New Point(145, 23)
            tbNMesa.Visible = False
            Button12.Visible = False
            lbMesa.Visible = False
        End If

        frmSalao.TimerTela.Enabled = False

        Me.Text = "Abre/Altera " & TextoMesaPAR
        lbMesa.Text = frmSalao.lbMesa.Text
        lbStatusCartao.Text = ""
        PreencheGarcon()

        If TerminalVenda = True Then
            tbQtdePessoas.Visible = False
            tbServico.Visible = False
            tbPercDesconto.Visible = False
            tbCodigoGarcon.Visible = False
            cbCodigoGarcon.Visible = False
            lbGarcon.Visible = False
            tbIDFuncionario.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label5.Visible = False
            Label1.Visible = False
        End If

        If NumMesa <> 0 Then
            tbQtdePessoas.Text = NuloString(QtdPessoas)
            tbPercDesconto.Text = NuloString(NuloDecimal(PercDesconto))


            strSql = "Select NumMesa, Status FROM tblMesas WHERE NumMesa=" & NumMesa
            Dim StatusMesa As String = NuloString(PegaValorCampo("Status", strSql, strCon))
            If StatusMesa = "M" Then
                strSql = "Select NumMesa, PercServico, FlagFechada From tblVendas Where (FlagFechada = 0) And (NumMesa = " & NumMesa & ")"
                tbServico.Text = NuloString(Format(NuloDecimal(PegaValorCampo("PercServico", strSql, strCon)), "#0"))
            Else
                tbServico.Text = NuloString(NuloDecimal(0))
            End If

            lbGarcon.Text = GarconInicial

            Dim IDSel As String
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            For I = 1 To cbCodigoGarcon.Items.Count
                cbCodigoGarcon.SelectedIndex = ItemSel
                IDSel = NuloString(Trim(Strings.Left(cbCodigoGarcon.Text, 50)))
                cbCodigoGarcon.SelectedIndex = ItemSel
                If IDSel = GarconInicial Then
                    I = 9999
                End If
                ItemSel += 1
            Next

            If I < 9999 Then
                cbCodigoGarcon.Text = ""
                lbGarcon.Text = ""
                tbCodigoGarcon.Text = ""
            Else
                tbCodigoGarcon.Text = NuloString(NuloInteger(Strings.Right(cbCodigoGarcon.Text, 8)))
            End If

            strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasMovto.IDVenda, tblVendasMovto.EmEspera, tblVendas.NumMesa, tblVendas.Excluido, tblVendasMovto.Excluido As Expr1 "
            strSql += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
            strSql += "Where (tblVendasMovto.EmEspera = 1) And (tblVendas.NumMesa = " & NumMesa & ") And (tblVendas.Excluido = 0) And (tblVendasMovto.Excluido = 0)"
            tbIDVenda.Text = NuloString(NuloInteger(PegaValorCampo("IDVenda", strSql, strCon)))
            If NuloInteger(tbIDVenda.Text) = 0 Then
                btnliberaProdutos.Visible = False
            Else
                btnliberaProdutos.Visible = True
            End If

            tbNMesa.Text = NuloString(NumMesa)
            cbCodigoGarcon.Focus()
            SendKeys.Send("{ENTER}")
        Else
            QtdPessoas = 1
            tbQtdePessoas.Text = "1"
            tbServico.Text = NuloString(NuloInteger(PercServicoPAR))
            tbPercDesconto.Text = "0"
            PercDesconto = 0
            tbCodigoGarcon.Text = IDOperador.ToString
            lbGarcon.Text = Operador
            tbIDFuncionario.Text = IDOperador.ToString
            tbNMesa.Text = ""

            ' If TerminalVenda = True Then
            'AchaAtendente(IDOperador, 0)
            'End If

            tbNMesa.Focus()
        End If

        If InformaClienteBalcao = True Then
            btnNomeCliente.Visible = True
        Else
            btnNomeCliente.Visible = False
        End If

        MontaMesas()

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        IDVenda = 0
        NumMesa = 0
        frmSalao.tbCodigoProduto.Text = ""
        frmSalao.tbQtde.Text = "1,000"
        frmSalao.LBProduto.Text = ""
        QtdPessoas = 1
        MesaImpressa = False
        frmSalao.tbMesa.Text = ""
        frmSalao.tbMesa.Focus()
        frmPrincipal.Enabled = True
        frmPrincipal.lblSenha.Text = String.Empty
        Me.Dispose()
        Me.Close()
        Dispose()
        Close()


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

        If Foco = "M" Then
            tbNMesa.Text = String.Empty
            lbStatusCartao.Text = ""
        End If
        If Foco = "G" Then
            tbCodigoGarcon.Text = String.Empty
        End If
        If Foco = "S" Then
            tbServico.Text = String.Empty
        End If
        If Foco = "Q" Then
            tbQtdePessoas.Text = String.Empty
        End If
        If Foco = "PD" Then
            tbPercDesconto.Text = String.Empty
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        If tbNMesa.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Mesa/Cartão inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbNMesa.Focus()
            Exit Sub
        End If
        If lbGarcon.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Atendente/Garçon inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbCodigoGarcon.Focus()
            Exit Sub
        End If
        If tbServico.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Serviço inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbServico.Focus()
            Exit Sub
        End If
        If tbQtdePessoas.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Quantidade de pessoas inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbQtdePessoas.Focus()
            Exit Sub
        End If

        Confirma()

    End Sub

    Private Sub CliqueNoBotao(valor As String)
        If Foco = "M" Then
            tbNMesa.Text &= valor
            tbNMesa.Focus()
        End If
        If Foco = "G" Then
            tbCodigoGarcon.Text &= valor
            tbCodigoGarcon.Focus()
        End If
        If Foco = "S" Then
            tbServico.Text &= valor
            tbServico.Focus()
        End If
        If Foco = "Q" Then
            tbQtdePessoas.Text &= valor
            tbQtdePessoas.Focus()
        End If
        If Foco = "PD" Then
            tbPercDesconto.Text &= valor
            tbPercDesconto.Focus()
        End If

    End Sub
    Private Sub TBNMesa_Enter(sender As Object, e As EventArgs) Handles tbNMesa.Enter
        Foco = "M"
    End Sub

    Private Sub TBCodigoGarcon_Enter(sender As Object, e As EventArgs) Handles tbCodigoGarcon.Enter
        Foco = "G"
    End Sub

    Private Sub TBServico_Enter(sender As Object, e As EventArgs) Handles tbServico.Enter
        Foco = "S"

        If IsNumeric(cbCodigoGarcon.Text) Then
            BuscaAtendente(NuloInteger(cbCodigoGarcon.Text))
        End If
    End Sub
    Private Sub TBQtdePessoas_Enter(sender As Object, e As EventArgs) Handles tbQtdePessoas.Enter
        Foco = "Q"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Foco = "M" Then tbNMesa.Focus()
        If Foco = "G" Then tbCodigoGarcon.Focus()
        If Foco = "S" Then tbServico.Focus()
        If Foco = "Q" Then tbQtdePessoas.Focus()
        If Foco = "PD" Then tbPercDesconto.Focus()
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub TBNMesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNMesa.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True

            If tbNMesa.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = TextoMesaPAR & " inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            Dim con As New SqlConnection()
            strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbNMesa.Text & ")"
            Dim dr As SqlDataReader
            con.ConnectionString = strCon
            Dim cmd As SqlCommand = con.CreateCommand
            cmd.CommandText = strSql

            'Try
            NumMesa = NuloInteger(tbNMesa.Text)
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                If NuloBoolean(dr.Item("Flag")) = False Then
                    IDVenda = 0
                    QtdPessoas = 1
                    tbQtdePessoas.Text = "1"
                    If NuloString(dr.Item("Status")) = "M" Then
                        tbServico.Text = NuloString(PercServicoPAR)
                    Else
                        tbServico.Text = NuloString(0)
                    End If
                    tbPercDesconto.Text = "0"
                    tbCodigoGarcon.Text = ""
                    lbGarcon.Text = ""
                    tbIDFuncionario.Text = ""
                    MesaImpressa = False
                    lbStatusCartao.Text = "Abrindo " & TextoMesaPAR
                    lbStatusCartao.ForeColor = Color.Green

                    If TerminalVenda = True Then
                        AchaAtendente(IDOperador, 0)
                    End If
                Else
                    If TerminalVenda = True And NuloBoolean(dr.Item("Impresso")) = True Then
                        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                        frm.lbMensagem.Text = "Conta já enviada. É necessário reabrir a Mesa/Cartão (" & tbNMesa.Text & ") para continuar"
                        frm.btnNao.Visible = False
                        frm.btnSim.Visible = False
                        frm.btnOK.Visible = True
                        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                        frm.ShowDialog()
                        tbNMesa.Focus()
                        Exit Sub
                    End If

                    Dim conM As New SqlConnection()
                    Dim drM As SqlDataReader
                    strSql = "Select IDVenda, IDfechamento, NumVenda, NumMesa, Cartao, FlagFechada, Excluido, QtdPessoas, Atendente, IDFuncionarioAtendente, PercDesconto From tblVendas Where (Excluido = 0) And (FlagFechada = 0) And (NumMesa=" & tbNMesa.Text & ")"
                    conM.ConnectionString = strCon
                    Dim cmdM As SqlCommand = conM.CreateCommand
                    cmdM.CommandText = strSql
                    conM.Open()
                    drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
                    If drM.HasRows Then
                        drM.Read()
                        IDVenda = NuloInteger(drM.Item("IDVenda"))
                        QtdPessoas = NuloInteger(drM.Item("QtdPessoas"))
                        tbQtdePessoas.Text = NuloString(drM.Item("QtdPessoas"))
                        tbPercDesconto.Text = NuloDecimal(Convert.ToDecimal(drM.Item("PercDesconto"))).ToString
                        MesaImpressa = NuloBoolean(dr.Item("Impresso"))
                        AchaAtendente(Convert.ToInt32(NuloInteger(drM.Item("IDFuncionarioAtendente"))), 0)

                        lbStatusCartao.Text = TextoMesaPAR & " consumindo"
                        lbStatusCartao.ForeColor = Color.DarkRed
                    Else
                        IDVenda = 0
                        QtdPessoas = 1
                        tbQtdePessoas.Text = "1"
                        If NuloString(dr.Item("Status")) = "M" Then
                            tbServico.Text = NuloString(PercServicoPAR)
                        Else
                            tbServico.Text = NuloString(0)
                        End If

                        tbPercDesconto.Text = "0"
                        tbCodigoGarcon.Text = ""
                        lbGarcon.Text = ""
                        tbIDFuncionario.Text = ""
                        lbStatusCartao.Text = ""
                        MesaImpressa = False
                    End If
                    drM.Close()
                    cmdM.Dispose()
                    conM.Dispose()
                    conM.Close()
                End If
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = TextoMesaPAR & " " & tbNMesa.Text & " não cadastrada"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                lbStatusCartao.Text = ""
                tbNMesa.Text = ""
                QtdPessoas = 1
                tbQtdePessoas.Text = "1"
                tbServico.Text = NuloString(PercServico)
                tbCodigoGarcon.Text = ""
                tbIDFuncionario.Text = ""
                QtdPessoas = 1
                MesaImpressa = False
                lbGarcon.Text = ""
            End If

            dr.Close()
            cmd.Dispose()
            con.Dispose()
            con.Close()

            strSql = "Select tblVendasMovto.IDVendaMovto, tblVendasMovto.IDVenda, tblVendasMovto.EmEspera, tblVendas.NumMesa, tblVendas.Excluido, tblVendasMovto.Excluido As Expr1 "
            strSql += "From tblVendasMovto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
            strSql += "Where (tblVendasMovto.EmEspera = 1) And (tblVendas.NumMesa = " & NumMesa & ") And (tblVendas.Excluido = 0) And (tblVendasMovto.Excluido = 0)"
            tbIDVenda.Text = NuloString(NuloInteger(PegaValorCampo("IDVenda", strSql, strCon)))
            If NuloInteger(tbIDVenda.Text) = 0 Then
                btnliberaProdutos.Visible = False
            Else
                btnliberaProdutos.Visible = True
            End If



            cbCodigoGarcon.Focus()

        End If
    End Sub

    Private Sub TBCodigoGarcon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodigoGarcon.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbCodigoGarcon.Text <> "" Then
                AchaAtendente(0, Convert.ToInt32(tbCodigoGarcon.Text))
            Else
                tbServico.Focus()
            End If

        End If
    End Sub
    Private Sub TBServico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbServico.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbPercDesconto.Focus()
        End If
    End Sub
    Private Sub TBQtdePessoas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbQtdePessoas.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbNMesa.Text <> "" And tbCodigoGarcon.Text <> "" And tbServico.Text <> "" And tbPercDesconto.Text <> "" And tbQtdePessoas.Text <> "" Then
                Button12.Focus()
            Else
                tbNMesa.Focus()
            End If
        End If

    End Sub
    Private Sub TBPercDesconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPercDesconto.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbQtdePessoas.Focus()
        End If
    End Sub
    Private Sub TBValordesconto_KeyPress(sender As Object, e As KeyPressEventArgs)
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbQtdePessoas.Focus()
        End If
    End Sub

    Private Sub TBServico_TextChanged(sender As Object, e As EventArgs) Handles tbServico.TextChanged

    End Sub

    Private Sub TBPercDesconto_Enter(sender As Object, e As EventArgs) Handles tbPercDesconto.Enter
        Foco = "PD"
    End Sub

    Private Sub TBValordesconto_Enter(sender As Object, e As EventArgs)
        Foco = "VD"
    End Sub

    Private Sub fdlgAbreMesa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown


        Select Case e.KeyCode
            Case Keys.KeyCode.F7
                Me.InvokeOnClick(Button12, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(Button13, e)

        End Select



    End Sub

    Private Sub AchaAtendente(IDFunc As Integer, CodFun As Integer)

        Dim con As New SqlConnection()
        If CodFun <> 0 Then
            strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
            strSql += "From tblFuncionarios_Local "
            strSql += "Where (CodigoFuncionario=" & CodFun & ")"
        Else
            strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
            strSql += "From tblFuncionarios_Local "
            strSql += "Where (IDFuncionario=" & IDFunc & ")"
        End If

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                lbGarcon.Text = NuloString(dr.Item("Funcionario"))
                lbGarcon.Refresh()
                tbIDFuncionario.Text = NuloString(dr.Item("IDFuncionario"))
                tbCodigoGarcon.Text = NuloString(dr.Item("CodigoFuncionario"))
                cbCodigoGarcon.Text = NuloString(dr.Item("CodigoFuncionario"))
                tbServico.Focus()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Atendente/Garçon não cadastrado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()

                lbGarcon.Text = ""
                tbCodigoGarcon.Text = ""
            End If
            dr.Close()
            cmd.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            con.Close()
        End Try

    End Sub

    Private Sub TBCodigoGarcon_TextChanged(sender As Object, e As EventArgs) Handles tbCodigoGarcon.TextChanged

    End Sub

    Private Sub TBPercDesconto_TextChanged(sender As Object, e As EventArgs) Handles tbPercDesconto.TextChanged

    End Sub

    Private Sub TBNMesa_TextChanged(sender As Object, e As EventArgs) Handles tbNMesa.TextChanged
        IDVenda = 0
    End Sub

    Private Sub TBQtdePessoas_TextChanged(sender As Object, e As EventArgs) Handles tbQtdePessoas.TextChanged

    End Sub

    Private Sub fdlgAbreMesa_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Dispose()
        Close()
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True

    End Sub

    Private Sub CbCodigoGarcon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCodigoGarcon.SelectedIndexChanged
        tbCodigoGarcon.Text = NuloString(NuloInteger(Strings.Right(cbCodigoGarcon.Text, 8)))
        lbGarcon.Text = NuloString(Trim(Strings.Left(cbCodigoGarcon.Text, 50)))
        tbCodFunc.Text = cbCodigoGarcon.Text

    End Sub

    Private Sub cbCodigoGarcon_KeyDown(sender As Object, e As KeyEventArgs) Handles cbCodigoGarcon.KeyDown


        If e.KeyCode = 13 Then
            e.Handled = True
            'If cbCodigoGarcon.Text <> "" Then
            'AchaAtendente(0, Convert.ToInt32(tbCodigoGarcon.Text))
            'Else
            AchaAtendente(0, NuloInteger(Strings.Right(cbCodigoGarcon.Text, 8)))
            tbServico.Focus()
            'End If

        End If


    End Sub

    Private Sub BtnliberaProdutos_Click(sender As Object, e As EventArgs) Handles btnliberaProdutos.Click

        InserirItemVenda(NuloInteger(tbIDVenda.Text), 99999, "LIBERA PRODUTOS", 0, True, 0, 0, "Categoria", Date.Now, 0, Operador, 0, "Grupo", NuloBoolean(0), "", False, "", "Terminal", True, 1, True, True)
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub BtnNomeCliente_Click(sender As Object, e As EventArgs) Handles btnNomeCliente.Click
        If tbNMesa.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Mesa/Cartão inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbNMesa.Focus()
            Exit Sub
        End If
        If lbGarcon.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Atendente/Garçon inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbCodigoGarcon.Focus()
            Exit Sub
        End If
        If tbServico.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Serviço inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            tbServico.Focus()
            Exit Sub
        End If
        If tbQtdePessoas.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Quantidade de pessoas inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            tbQtdePessoas.Focus()
            Exit Sub
        End If

        Confirma()

        '        Me.Dispose()
        '        Me.Close()


        strSql = "SELECT IDVenda, NomeCliente, Obs FROM tblVendas WHERE (IDVenda=" & IDVenda & ")"
        Dim NomeCliente As String = NuloString(PegaValorCampo("NomeCliente", strSql, strCon))
        Dim Obs As String = NuloString(PegaValorCampo("Obs", strSql, strCon))

        Dim frmI As fdlgInformaClienteVenda = New fdlgInformaClienteVenda
        frmI.tbIDVenda.Text = NuloString(IDVenda)
        frmI.tbCliente.Text = NomeCliente
        frmI.tbObs.Text = Obs
        frmI.ShowDialog()

        strSql = "Select IDVenda, NomeCliente, Obs From tblVendas Where (IDVenda=" & IDVenda & ")"
        frmSalao.lbNomeCliente.Text = NuloString(PegaValorCampo("NomeCliente", strSql, strCon)) & " / " & NuloString(PegaValorCampo("Obs", strSql, strCon))
    End Sub
End Class