Imports System.Data.SqlClient

Public Class fdlgAutorizacao
    Public Sub MontaFuncionarios()

        Dim n As Integer = 0
        Dim strSql As String

        If tbTipo.Text = "E" Then
            strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
            strSql += "From tblFuncionarios_Local "
            strSql += "Where (Senha<>'' AND EfetuaEstorno = 1) "
            strSql += "Order By Funcionario"
        Else
            If tbTipo.Text = "E" Then
                strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
                strSql += "From tblFuncionarios_Local "
                strSql += "Where (Senha<>'' AND EfetuaTransferencia = 1) "
                strSql += "ORDER BY Funcionario"
            Else
                strSql = "Select IDFuncionario, Funcionario, Login, Senha, VisualizaMovto, AbreCaixa, EncerraCaixa, EfetuaEstorno, EfetuaTransferencia, Nivel, CodigoFuncionario "
                strSql += "From tblFuncionarios_Local "
                strSql += "Where (Senha<>'' AND Nivel >= " & tbTipo.Text & ") "
                strSql += "ORDER BY Funcionario"
            End If
        End If

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim myfont As New Font("Sans Serif", 9, FontStyle.Regular)
        Dim btnArray(42) As System.Windows.Forms.Button
        For i As Integer = 0 To 42
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        Me.PanelFuncionarios.Controls.Clear()

        If dr.HasRows Then
            While (dr.Read())
                With (btnArray(n))
                    .Tag = NuloInteger(dr(0))
                    .Text = NuloString(dr(1))
                    .AccessibleDescription = NuloString(dr(3))
                    .ForeColor = Color.Blue

                    .Width = 100
                    .Height = 60

                    .BackColor = Color.PeachPuff
                    .Font = myfont
                    .FlatStyle = FlatStyle.Standard
                    .FlatAppearance.BorderColor = Color.Silver
                    .BackgroundImage = GourmetVisual.My.Resources.Resources.base
                    .BackgroundImageLayout = ImageLayout.Stretch

                    Me.PanelFuncionarios.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Funcionarios

                    n += 1
                End With
            End While
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        con.Close()
        con.Dispose()
        'PanelGrupos.Enabled = True
        'End Try
    End Sub
    Private Sub ClickButton_Funcionarios(ByVal sender As Object, ByVal e As System.EventArgs)

        With CType(sender, Button)

            ' btnConfirma.Enabled = False
            lbFuncionario.Text = String.Empty
            tbSenha.Text = String.Empty
            If .Text <> String.Empty Then
                lbFuncionario.Text = .Text
                tbIDFuncionario.Text = .Tag
                tbSenhaFuncionario.Text = .AccessibleDescription
            End If
            tbSenha.Focus()

        End With

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbSenha.Text &= "7"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbSenha.Text &= "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbSenha.Text &= "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbSenha.Text &= "3"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbSenha.Text &= "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbSenha.Text &= "5"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbSenha.Text &= "6"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbSenha.Text &= "8"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbSenha.Text &= "9"
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If Len(tbSenha.Text) > 0 Then
            tbSenha.Text = Strings.Left(tbSenha.Text, Len(tbSenha.Text) - 1)
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbSenha.Text &= "0"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        tbSenha.Text = ""
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If NuloString(tbSenha.Text) = "" Then
            Autorizado = False
            Me.Dispose()
            Me.Close()
        Else
            If NuloString(tbSenha.Text) = NuloString(tbSenhaFuncionario.Text) Then
                IDFuncionarioAutorizado = NuloInteger(tbIDFuncionario.Text)
                FuncionarioAutorizado = NuloString(lbFuncionario.Text)
                Autorizado = True
                Me.Dispose()
                Me.Close()
            Else
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Senha inválida"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                IDFuncionarioAutorizado = 0
                FuncionarioAutorizado = ""
                tbSenha.Text = ""
                Autorizado = False
            End If
        End If
    End Sub

    Private Sub FdlgAutorizacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Autorizado = False
        MontaFuncionarios()
    End Sub
End Class