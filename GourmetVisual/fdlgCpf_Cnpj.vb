Imports System.Data.SqlClient

Public Class fdlgCpf_Cnpj
    Public SatRespondido As Boolean = False
    Public DuploEnter As Boolean = False
    Public TempoEspera As Integer = 60
    Public Espera As Integer
    Private Sub tbCpfCnpj_TextChanged(sender As Object, e As EventArgs) Handles tbCpfCnpj.TextChanged
        If Len(tbCpfCnpj.Text) = 11 Then
            FU_ValidaCPF(tbCpfCnpj.Text)
            If ValidaCPF_CNPJ = True Then
                lbMsgValido.Text = "CPF Válido"
                lbMsgValido.ForeColor = Color.ForestGreen
            Else
                lbMsgValido.Text = "CPF Inválido"
                lbMsgValido.ForeColor = Color.Red
            End If
        Else
            If Len(tbCpfCnpj.Text) = 14 Then
                FU_ValidaCNPJ(tbCpfCnpj.Text)
                If ValidaCPF_CNPJ = True Then
                    lbMsgValido.Text = "CNPJ Válido"
                    lbMsgValido.ForeColor = Color.ForestGreen
                Else
                    lbMsgValido.Text = "CNPJ Inválido"
                    lbMsgValido.ForeColor = Color.Red
                End If
            Else
                lbMsgValido.Text = ""
            End If
        End If
    End Sub

    Private Sub fdlgCpf_Cnpj_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbMsgValido.Text = "Informe o CPF ou CNPJ do cliente"
        TempoEspera = 60
        Espera = 0
        lbMensagem.Text = ""
        tbCpfCnpj.Focus()

        If ModoFiscal = "NFCE" Then
            PictureBoxNFCE.Visible = True
            PictureBox.Visible = False
        End If

    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbCpfCnpj.Text += "0"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbCpfCnpj.Text = ""
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbCpfCnpj.Text += "1"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbCpfCnpj.Text += "2"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbCpfCnpj.Text += "3"
        tbCpfCnpj.Focus()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbCpfCnpj.Text += "4"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbCpfCnpj.Text += "5"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbCpfCnpj.Text += "6"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tbCpfCnpj.Text += "7"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tbCpfCnpj.Text += "8"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tbCpfCnpj.Text += "9"
        tbCpfCnpj.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbCpfCnpj.Focus()
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub tbCpfCnpj_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCpfCnpj.KeyDown
        If e.KeyCode = Keys.S Then
            If FuncaoI = True Then
                strSql = "UPDATE tblVendasSAT SET "
                strSql &= "Status ='I' "
                strSql &= "WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
                ExecutaStr(strSql)
                Me.Dispose()
                Me.Close()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If Replace(tbCpfCnpj.Text, vbCrLf, "") <> "" Then

                If Replace(tbCpfCnpj.Text, vbCrLf, "") = "00" Then
                    If FuncaoI = True Then
                        strSql = "UPDATE tblVendasSAT SET "
                        strSql &= "Status ='I' "
                        strSql &= "WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
                        ExecutaStr(strSql)
                        Me.Dispose()
                        Me.Close()
                        Exit Sub
                    End If
                End If

                If lbMsgValido.Text = "CNPJ Inválido" Or lbMsgValido.Text = "CPF Inválido" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário digitar um CPF ou CNPJ valido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbCpfCnpj.Text = ""
                    Exit Sub
                End If

                If tbCpfCnpj.Text = "" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "É necessário digitar um CPF ou CNPJ valido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbCpfCnpj.Text = ""
                    Exit Sub
                End If

                If Not IsNumeric(tbCpfCnpj.Text) And tbCpfCnpj.Text <> "" Then
                    Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                    frm.lbMensagem.Text = "CPF ou CNPJ valido"
                    frm.btnNao.Visible = False
                    frm.btnSim.Visible = False
                    frm.btnOK.Visible = True
                    frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                    frm.ShowDialog()
                    tbCpfCnpj.Text = ""
                    Exit Sub
                End If
            End If

            Dim CPF_CNPJ As String = tbCpfCnpj.Text
            CPF_CNPJ = Replace(CPF_CNPJ, vbLf, "")
            CPF_CNPJ = Replace(CPF_CNPJ, vbCr, "")
            CPF_CNPJ = Replace(CPF_CNPJ, vbCrLf, "")

            lbMensagem.Text = "Aguarde... Imprimindo cupom fiscal (" & TempoEspera & ")"
            lbMensagem.Refresh()
            If DuploEnter = False Then
                DuploEnter = True
                Dim IDVdaPagto As Integer = NuloInteger(tbIDVendaPagto.Text)


                strSql = "UPDATE tblVendasSAT SET "
                strSql &= "IDVenda =" & tbIDVenda.Text & ", "
                strSql &= "ValorCupom =" & Replace(NuloDecimal(tbTotCupom.Text), ",", ".") & ", "
                strSql &= "CPF_CNPJ ='" & CPF_CNPJ & "', "
                strSql &= "TotalAD =" & Replace(NuloDecimal(tbTotalAD.Text), ",", ".") & ", "
                strSql &= "TotalVenda =" & Replace(NuloDecimal(tbTotVenda.Text), ",", ".") & ", "
                strSql &= "TxEntrega =" & Replace(NuloDecimal(tbTxEntrega.Text), ",", ".") & ", "
                strSql &= "STVenda ='" & tbStVenda.Text & "', "
                strSql &= "DiaMovto ='" & frmPrincipal.tbDiaMovto.Text & "', "
                strSql &= "IDSat = " & EquipamentoSAT & ", "
                strSql &= "IDVdaPagto =" & IDVdaPagto & ", "
                strSql &= "Enviado =1, "
                strSql &= "Status ='A' "
                strSql &= "WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
                ExecutaStr(strSql)


                TimerAguardandoSAT.Enabled = True
                TimerAguardandoSAT.Start()

            End If

        End If
    End Sub

    Private Sub TimerAguardandoSAT_Tick(sender As Object, e As EventArgs) Handles TimerAguardandoSAT.Tick


        lbMensagem.Text = "Aguarde... Imprimindo cupom fiscal (" & TempoEspera & ")"
        lbMensagem.Refresh()


        If TempoEspera = 0 Then
            strSql = "UPDATE tblVendasSAT SET Status='ERRO' WHERE (IDVendaSAT=" & tbIDVendaSAT.Text & ")"
            ExecutaStr(strSql)
            Me.Dispose()
            Me.Close()
        End If


        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        strSql = "Select IDVendaSAT, IDVenda, Num_SAT, NumSAT, XML, Enviado, Status, IDSat "
        strSql += "From tblVendasSAT "
        strSql += "Where (IDVendaSAT = " & tbIDVendaSAT.Text & ") AND (Enviado = 1)"

        cmd.CommandText = strSql
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            If dr.Item("Status") = "E" Then

                TimerAguardandoSAT.Stop()

                Dim lngFile As Integer = FreeFile()

                PegaDadosSAT(dr.Item("IDSat"))

                FileClose(lngFile)
                FileOpen(lngFile, Application.StartupPath & "\CFeSAT_Emitido\" & dr.Item("Num_SAT") & ".xml", OpenMode.Output)
                PrintLine(lngFile, NuloString(dr.Item("XML")))
                FileClose(lngFile)

                spdSAT.ExibirDetalhamento = True
                If LogoCupom <> "" Then
                    spdSAT.LogotipoEmitente = LogoCupom
                End If
                spdSAT.ImprimirCFeSAT(ReadUTF8File(Application.StartupPath & "\CFeSAT_Emitido\" & dr.Item("Num_SAT") & ".xml"), "", ImpCaixa)

                Me.Dispose()
                Me.Close()
            Else
                If dr.Item("Status") = "ERRO" Then
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Else
            SatRespondido = False
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()

        If Espera = 1 Then
            TempoEspera -= 1
            Espera = 0
        Else
            Espera = 1
        End If


    End Sub
End Class