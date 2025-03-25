Imports System.Data.SqlClient

Public Class fdlgOutroCartao
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbMesa.Text += "7"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbMesa.Text += "8"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbMesa.Text += "9"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbMesa.Text += "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbMesa.Text += "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbMesa.Text += "6"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbMesa.Text += "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbMesa.Text += "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbMesa.Text += "3"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbMesa.Text += "0"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbMesa.Text = ""
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        Dim StMesa As String
        IDVenda = 0
        ConfirmaContinua = False
        If tbMesa.Text <> "" Then
            strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbMesa.Text & ")"
            If PegaValorCampo("NumMesa", strSql, strCon) <> "" Then
                strSql = "Select IDVenda, IDfechamento, NumVenda, NumMesa, Cartao, FlagFechada, Excluido, QtdPessoas, Atendente, IDFuncionarioAtendente, PercDesconto From tblVendas Where (Excluido = 0) And (FlagFechada = 0) And (NumMesa=" & tbMesa.Text & ")"
                IDVenda = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))

                strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbMesa.Text & ")"
                If NuloString(PegaValorCampo("Status", strSql, strCon)) = "B" Then
                    StMesa = "B"
                Else
                    StMesa = "S"
                End If
                If IDVenda = 0 Then
                    AbreVenda(tbMesa.Text, 0, PercServicoPAR, tbGarcon.Text, IDOperador, 1, StMesa)
                    IDVenda = PegaID("IDVenda", "tblVendas", "L")
                Else
                    EditaVenda(0, PercServicoPAR, tbGarcon.Text, IDOperador, 1, StMesa)
                End If

                frmSalao.tbMesa.Text = tbMesa.Text

                'strSql = "UPDATE tblMesas SET "
                'strSql &= "UltimoPedido='" & Now & "', "
                'strSql &= "Flag=1,"
                'strSql &= "Impresso=0 "
                'strSql &= "WHERE (NumMesa=" & tbMesa.Text & ")"
                'ExecutaStr(strSql)
                frmSalao.MontaBotoesMesas()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = TextoMesaPAR & " " & tbMesa.Text & " não cadastrada"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesa.Text = ""
                Exit Sub
            End If
        End If
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

        If MesaCartao = "" Then
            btnMesaCartao.Text = ""
            btnMesaCartao.Visible = False
        Else
            btnMesaCartao.Text = "Mesa destino: " & MesaCartao
            btnMesaCartao.Visible = True
        End If

    End Sub

    Private Sub fdlgOutroCartao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = False
        If TerminalVenda = True Then
            AchaAtendente(IDOperador)
        End If

    End Sub
    Private Sub AchaAtendente(IDFunc As Integer)

        Dim con As New SqlConnection()

        strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
        strSql += "From tblFuncionarios_Local "
        strSql += "Where (IDFuncionario=" & IDFunc & ")"

        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql
        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                dr.Read()
                tbGarcon.Text = NuloString(dr.Item("Funcionario"))
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Atendente/Garçon não cadastrado"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbGarcon.Text = ""
                Me.Dispose()
                Me.Close()
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

    Private Sub btnMesaCartao_Click(sender As Object, e As EventArgs) Handles btnMesaCartao.Click

        Dim frm As fdlgMesaCartao = New fdlgMesaCartao
        frm.tbStatus.Text = ""
        frm.Size = New System.Drawing.Size(689, 541)
        frm.ShowDialog()
        tbMesa.Focus()

    End Sub

    Private Sub tbMesa_KeyDown(sender As Object, e As KeyEventArgs) Handles tbMesa.KeyDown

        Select Case e.KeyCode
            Case Keys.KeyCode.Enter
                Me.InvokeOnClick(btnConfirma, e)

        End Select

    End Sub

    Private Sub fdlgOutroCartao_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim StMesa As String
        IDVenda = 0
        ConfirmaContinua = True
        If tbMesa.Text <> "" Then
            strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbMesa.Text & ")"
            If PegaValorCampo("NumMesa", strSql, strCon) <> "" Then
                strSql = "Select IDVenda, IDfechamento, NumVenda, NumMesa, Cartao, FlagFechada, Excluido, QtdPessoas, Atendente, IDFuncionarioAtendente, PercDesconto From tblVendas Where (Excluido = 0) And (FlagFechada = 0) And (NumMesa=" & tbMesa.Text & ")"
                IDVenda = NuloInteger(PegaValorCampo("IDVenda", strSql, strCon))

                strSql = "Select NumMesa, Status, Flag, Impresso, Praca, UltimoPedido, Aberturas From tblMesas Where (NumMesa=" & tbMesa.Text & ")"
                If NuloString(PegaValorCampo("Status", strSql, strCon)) = "B" Then
                    StMesa = "B"
                Else
                    StMesa = "S"
                End If

                If IDVenda = 0 Then
                    AbreVenda(tbMesa.Text, 0, PercServicoPAR, tbGarcon.Text, IDOperador, 1, StMesa)
                    IDVenda = PegaID("IDVenda", "tblVendas", "L")
                Else
                    EditaVenda(0, PercServicoPAR, tbGarcon.Text, IDOperador, 1, StMesa)
                End If

                frmSalao.tbMesa.Text = tbMesa.Text

                strSql = "UPDATE tblMesas SET "
                strSql &= "UltimoPedido='" & Now & "', "
                strSql &= "Flag=1,"
                strSql &= "Impresso=0 "
                strSql &= "WHERE (NumMesa=" & tbMesa.Text & ")"
                ExecutaStr(strSql)
                frmSalao.MontaBotoesMesas()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = TextoMesaPAR & " " & tbMesa.Text & " não cadastrada"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbMesa.Text = ""
                Exit Sub
            End If
        End If

        Me.Dispose()
        Me.Close()

        'MesaCartao = ""
        'frmSalao.tbMesa.Text = ""
        frmSalao.IniciaFrm()

        'If FixaAbreMesaCartao = True Then
        'Dim frmA As fdlgAbreMesa = New fdlgAbreMesa
        'frmA.tbNMesa.Text = ""
        'frmA.ShowDialog()
        ''fdlgAbreMesa.ShowDialog()
        'End If
    End Sub

    Private Sub fdlgOutroCartao_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub
End Class