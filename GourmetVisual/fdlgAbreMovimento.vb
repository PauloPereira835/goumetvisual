Imports System.Collections
Imports System.Data.SqlClient


Public Class fdlgAbreMovimento
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Close()
    End Sub
    Private Sub Confirma()

        Dim con As New SqlConnection(strCon)
        Dim FC As Decimal = tbFundoCaixa.Text

        strSql = "INSERT tblFechamentos_Local "
        strSql &= "(Caixa,DiaMovimento,DataAbertura,Turno,Confirmado,FundoCaixa,IDFuncionario) VALUES ("
        strSql &= to_sql(Operador) & ","
        strSql &= to_sql(NuloString(tbDataMovto.Value)) & ","
        strSql &= to_sql(NuloString(tbDataMovto.Value)) & ","
        strSql &= to_sql(cbTurno.Text) & ","
        strSql &= to_sql(0) & ","
        strSql &= to_sql(Replace(tbFundoCaixa.Text, ",", ".")) & ","
        strSql &= to_sql(IDOperador) & ")"
        con.Open()
        Dim comando As New SqlCommand(strSql, con)
        comando.CommandType = CommandType.Text
        comando.ExecuteNonQuery()
        comando.Dispose()
        con.Dispose()
        con.Close()

        IDFechamento = NuloInteger(PegaID("IDFechamento", "tblFechamentos_Local", "L"))

        If RegistraLog = True Then
            IncluirLog(NomeTerminal, Operador, "ABERTURA DO MOVTO", NuloString(tbDataMovto.Value) & " - " & cbTurno.Text)
        End If

        frmPrincipal.tbDiaMovto.Text = NuloString(tbDataMovto.Value)
        Me.Close()

    End Sub

    Private Sub fdlgAbreMovimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim TiposProd As New ArrayList()
        With TiposProd
            .Add("")
            .Add("MANHA")
            .Add("TARDE")
            .Add("NOITE")
        End With
        cbTurno.DataSource = TiposProd
        cbTurno.SelectedIndex = 0
        lbOperador.Text = Operador
        tbDataMovto.Value = Now
        tbDataMovto.Focus()
    End Sub

    Private Sub tbDataMovto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDataMovto.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            cbTurno.Focus()
        End If
    End Sub
    Private Sub tbFundoCaixa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbFundoCaixa.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbDataMovto.Focus()
        End If
    End Sub
    Private Sub fdlgAbreMovimento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        ' ESC   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If e.KeyCode = 27 Then
            Me.Close()
        End If

        ' F7   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        If e.KeyCode = 118 Then
            If tbDataMovto.Value.Date <> Today Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Data do movimento diferente da data atual, deseja continuar mesmo assim"
                frm.btnNao.Visible = True
                frm.btnSim.Visible = True
                frm.btnOK.Visible = False
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()
                If RetornoMsg = False Then
                    tbDataMovto.Focus()
                    Exit Sub
                End If
            End If
            If cbTurno.Text = "" Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "É necessário selecionar um turno"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm.ShowDialog()

                cbTurno.Focus()
                Exit Sub
            End If
            If tbFundoCaixa.Text = "" Then tbFundoCaixa.Text = 0

            Confirma()
        End If


    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        If tbDataMovto.Value.Date <> Today Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Data do movimento diferente da data atual, deseja continuar mesmo assim"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then
                tbDataMovto.Focus()
                Exit Sub
            End If
        End If
        If cbTurno.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um turno"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()

            cbTurno.Focus()
            Exit Sub
        End If
        If tbFundoCaixa.Text = "" Then tbFundoCaixa.Text = 0

        Confirma()

    End Sub
    Private Sub cbTurno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbTurno.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbFundoCaixa.Focus()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbFundoCaixa.Text &= "0"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbFundoCaixa.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbFundoCaixa.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbFundoCaixa.Text &= "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbFundoCaixa.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbFundoCaixa.Text &= "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbFundoCaixa.Text &= "6"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tbFundoCaixa.Text &= "7"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tbFundoCaixa.Text &= "8"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tbFundoCaixa.Text &= "9"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbFundoCaixa.Text &= ","
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbFundoCaixa.Text = ""
    End Sub
End Class