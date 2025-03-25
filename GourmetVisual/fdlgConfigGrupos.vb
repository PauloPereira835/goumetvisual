Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Public Class fdlgConfigGrupos

    Private Sub fdlgConfig_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'Atualiza os grupos pois pode ter sido incluido ou excluído algum botão de categoria...
        frmSalao.MontaGruposSalao(1)
    End Sub

    Private Sub fdlgConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MontaGrupos(1)

        'With btnPagina1
        '    Dim p As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
        '    p.AddEllipse(4, 4, .Width - 12, .Height - 12)

        '    .Text = String.Empty
        '    .BackColor = Color.PaleGreen
        '    .Region = New Region(p)

        '    p.Dispose()
        'End With

        'With btnPagina2
        '    Dim p As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
        '    p.AddEllipse(4, 4, .Width - 12, .Height - 12)

        '    .Text = String.Empty
        '    .BackColor = Color.Gainsboro
        '    .Region = New Region(p)

        '    p.Dispose()
        'End With

        'With btnPagina3
        '    Dim p As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
        '    p.AddEllipse(4, 4, .Width - 12, .Height - 12)

        '    .Text = String.Empty
        '    .BackColor = Color.Gainsboro
        '    .Region = New Region(p)

        '    p.Dispose()
        'End With

        'With btnPagina4
        '    Dim p As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
        '    p.AddEllipse(4, 4, .Width - 12, .Height - 12)

        '    .Text = String.Empty
        '    .BackColor = Color.Gainsboro
        '    .Region = New Region(p)

        '    p.Dispose()
        'End With

        Dim newRectangle As Rectangle = btnPagina1.ClientRectangle

        'Increase the size of the rectangle to include the border.
        newRectangle.Inflate(-4, -4)

        Dim p As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)

        ' Create a circle within the new rectangle.
        p.AddEllipse(newRectangle)
        Dim circulo = New Region(p)

        With btnPagina1
            .Text = "1"
            .BackColor = Color.PaleGreen
            .Region = circulo
        End With

        With btnPagina2
            .Text = "2"
            .BackColor = Color.Gainsboro
            .Region = circulo
        End With

        With btnPagina3
            .Text = "3"
            .BackColor = Color.Gainsboro
            .Region = circulo
        End With

        With btnPagina4
            .Text = "4"
            .BackColor = Color.Gainsboro
            .Region = circulo
        End With

        p.Dispose()
        circulo.Dispose()

        MontaGrid()

    End Sub

    Private Sub MontaGrid()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        SqlStr ="SELECT tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGruposTouch.CodigoGrupo AS CodTouch "
        SqlStr += "FROM tblGrupos_Local LEFT OUTER JOIN tblGruposTouch ON tblGrupos_Local.CodigoGrupo = tblGruposTouch.CodigoGrupo "
        SqlStr += "WHERE(tblGruposTouch.CodigoGrupo Is NULL) "
        SqlStr += "ORDER BY tblGrupos_Local.Grupo"

        'cmd.CommandText = "SELECT tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGruposTouch.CodigoGrupo AS CodTouch FROM tblGrupos_Local LEFT OUTER JOIN tblGruposTouch ON tblGrupos_Local.CodigoGrupo = tblGruposTouch.CodigoGrupo WHERE(tblGruposTouch.CodigoGrupo Is NULL) ORDER BY tblGrupos_Local.Grupo"
        cmd.CommandText = SqlStr

        GridGrupos.Rows.Clear()

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                'dr.Read()
                While (dr.Read())
                    Me.GridGrupos.Rows.Add({NuloString(dr(1)), NuloInteger(dr(0))})
                End While
            End If

        Catch ex As Exception
            MsgBox("Erro: " & ex.Message)
        End Try

    End Sub
    Private Sub MontaGrupos(Pag As Integer)
        Dim n As Integer = 0

        Dim strSql As String

        btnPagina1.BackColor = Color.Gainsboro
        btnPagina2.BackColor = Color.Gainsboro
        btnPagina3.BackColor = Color.Gainsboro
        btnPagina4.BackColor = Color.Gainsboro

        'strSql = "SELECT tblGruposTouch.Botao, tblGrupos.CodigoGrupo, tblGrupos.Grupo FROM tblGrupos INNER JOIN tblGruposTouch ON tblGrupos.CodigoGrupo = tblGruposTouch.CodigoGrupo"

        'strSql = "Select tblGruposTouch.Botao, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo From tblGrupos_Local RIGHT OUTER Join tblGruposTouch On tblGrupos_Local.CodigoGrupo = tblGruposTouch.CodigoGrupo"
        strSql = "Select tblGruposTouch.Botao, tblGrupos_Local.CodigoGrupo, tblGrupos_Local.Grupo, tblGrupos_Local.CorBotao "
        strSql += "From tblGrupos_Local RIGHT OUTER Join tblGruposTouch On tblGrupos_Local.CodigoGrupo = tblGruposTouch.CodigoGrupo"


        If Pag = 1 Then
            strSql &= " WHERE (tblGruposTouch.Botao BETWEEN 1 AND 42)"
            btnPagina1.BackColor = Color.PaleGreen
            tbPagina.Text = "1"
        ElseIf Pag = 2 Then
            strSql &= " WHERE (tblGruposTouch.Botao BETWEEN 43 AND 84)"
            btnPagina2.BackColor = Color.PaleGreen
            tbPagina.Text = "2"
        ElseIf Pag = 3 Then
            strSql &= " WHERE (tblGruposTouch.Botao BETWEEN 85 AND 126)"
            btnPagina3.BackColor = Color.PaleGreen
            tbPagina.Text = "3"
        Else
            strSql &= " WHERE (tblGruposTouch.Botao BETWEEN 127 AND 168)"
            btnPagina4.BackColor = Color.PaleGreen
            tbPagina.Text = "4"
        End If

        strSql &= " ORDER BY tblGruposTouch.Botao"

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

            Me.PanelGrupos.Controls.Clear()

            If dr.HasRows Then
                While (dr.Read())
                With (btnArray(n))
                    .TabIndex = dr.GetInt32(0)
                    .Tag = NuloInteger(dr(1))
                    .Text = NuloString(dr(2))
                    .ForeColor = Color.Black
                    '                    .Width = 85
                    '                   .Height = 68
                    .Width = 90
                    .Height = 75
                    .FlatStyle = FlatStyle.Standard

                    .BackColor = Color.White
                    If Not IsDBNull(dr(3)) Then
                        If dr.GetInt32(3) = 9556525 Then
                            .BackColor = Color.GreenYellow
                        End If
                        If dr.GetInt32(3) = 14986523 Then
                            .BackColor = Color.CornflowerBlue
                        End If
                        If dr.GetInt32(3) = 14986183 Then
                            .BackColor = Color.MediumPurple
                        End If
                        If dr.GetInt32(3) = 1092847 Then
                            .BackColor = Color.Orange
                        End If
                        If dr.GetInt32(3) = 14340022 Then
                            .BackColor = Color.Thistle
                        End If
                    End If


                    .Font = myfont
                    '.FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderColor = Color.Silver
                    '.BackgroundImage = GourmetVisual.My.Resources.Resources.Botao_Ret_Vermelho
                    '.BackgroundImageLayout = ImageLayout.Stretch

                    Me.PanelGrupos.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Grupos

                    n += 1
                    If n > 42 Then Exit While
                End With
            End While
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message & ex.StackTrace)
        'Finally
        'con.Close()
        'con.Dispose()

        'lbBotao.Text = String.Empty
        'tbLinhaBotao.Text = String.Empty
        'End Try

    End Sub
    Private Sub ClickButton_Grupos(ByVal sender As Object, ByVal e As System.EventArgs)

        With CType(sender, Button)
            If IsNumeric(.Text) Then
                lbBotao.Text = "Vazio"
            Else
                lbBotao.Text = .Text
            End If
            tbLinhaBotao.Text = .TabIndex.ToString
        End With
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not isDebug Then
            ' frmPrincipal.TopMost = True
        End If

        'frmPrincipal.Enabled = True
        '
        'Me.Enabled = False
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub GridCategorias_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridGrupos.CellEnter

        tbLinha.Text = NuloString(e.RowIndex)
        tbCodigoGrupo.Text = NuloString(GridGrupos.Rows(e.RowIndex).Cells(1).Value)

    End Sub

    Private Sub btnLimpa_Click(sender As Object, e As EventArgs) Handles btnLimpa.Click

        If tbLinhaBotao.Text = String.Empty Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um botão"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim con As New SqlConnection(strCon)

        Try
            con.Open()
            Dim comando As New SqlCommand("UPDATE tblGruposTouch SET CodigoGrupo=0 WHERE (Botao = " & tbLinhaBotao.Text & ")", con)
            comando.CommandType = CommandType.Text

            Dim drLinha As SqlDataReader = comando.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            lbBotao.Text = "Vazio"

        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()

            MontaGrupos(NuloInteger(tbPagina.Text))
            MontaGrid()
        End Try

    End Sub

    Private Sub btnInclui_Click(sender As Object, e As EventArgs) Handles btnInclui.Click

        'If tbLinhaBotao.Text = String.Empty Then
        '    MsgBox("É necessário selecionar um botão", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        Dim con As New SqlConnection(strCon)

        Try
            con.Open()

            Dim comando As SqlCommand

            If tbLinhaBotao.Text = String.Empty Then
                'Pega a primeira Linha com IDcategoria = 0 ou Null
                comando = New SqlCommand("UPDATE tblGruposTouch SET CodigoGrupo=" & tbCodigoGrupo.Text & " WHERE Botao = (SELECT TOP 1 Botao FROM tblGruposTouch WHERE Isnull(CodigoGrupo,0)=0)", con)
            Else
                comando = New SqlCommand("UPDATE tblGruposTouch SET CodigoGrupo=" & tbCodigoGrupo.Text & " WHERE Botao = " & tbLinhaBotao.Text, con)
            End If

            comando.CommandType = CommandType.Text

            Dim drLinha As SqlDataReader = comando.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            MontaGrupos(NuloInteger(tbPagina.Text))
            MontaGrid()

        Catch ex As Exception
            MsgBox(ex.Message & ex.StackTrace)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnPagina1_Click(sender As Object, e As EventArgs) Handles btnPagina1.Click
        MontaGrupos(1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPagina2.Click
        MontaGrupos(2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnPagina3.Click
        MontaGrupos(3)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnPagina4.Click
        MontaGrupos(4)
    End Sub

    Private Sub GridGrupos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridGrupos.CellContentClick

    End Sub
End Class