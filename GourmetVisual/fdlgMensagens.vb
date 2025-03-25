

Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class fdlgMensagens
    Dim NomeImp As String
    Dim CodImp As Integer
    Dim TotalRegImp As Integer = 0
    Private Sub CriaImpressao()
        Dim lngFile As Integer = FreeFile()
        Dim texto As String

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\msg.txt", OpenMode.Output)

        texto = Chr(14) & "  M E N S A G E M" & Chr(27) & Chr(14)
        PrintLine(lngFile, texto)
        texto = "=================================================="
        PrintLine(lngFile, texto)
        texto = "Operador:  " & Operador
        PrintLine(lngFile, texto)
        texto = "Terminal:  " & NomeTerminal
        PrintLine(lngFile, texto)
        texto = Now.ToString
        PrintLine(lngFile, "              " & texto)
        texto = "-------------------------------------------------"
        PrintLine(lngFile, texto)
        PrintLine(lngFile, " MESA " & NumMesa)
        PrintLine(lngFile, "  ")

        For i As Integer = 0 To DataSetMsg.Tables(0).Rows.Count - 1
            If NuloString(DataSetMsg.Tables(0).Rows(i).Item(0)) <> "" Then
                PrintLine(lngFile, DataSetMsg.Tables(0).Rows(i).Item(0))
            End If
        Next
        If txtTextoLivre.Text <> "" Then
            PrintLine(lngFile, txtTextoLivre.Text)
        End If
        PrintLine(lngFile, "==================================================")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        FileClose(lngFile)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgMensagens_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmSalao.Enabled = True
        If Not isDebug Then
            ' frmSalao.TopMost = True
        End If
    End Sub

    Private Sub MontaBotoesImpressoras()

        strSql = "SELECT Categoria, IDCategoria FROM tblCategorias ORDER BY Categoria"

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        GridImpressoras.Rows.Clear()

        If dr.HasRows Then
            While (dr.Read())
                GridImpressoras.Rows.Add({dr.Item("Categoria"), dr.Item("IDCategoria")})
            End While
        End If

        dr.Close()
        con.Dispose()
        con.Close()


    End Sub

    Private Sub MontaMensagens()

        Dim n As Integer = 0
        Dim TotalRegMsg As Integer = 0

        Dim strSql As String

        strSql = "SELECT tblMensagens.Mensagem FROM tblMensagens ORDER BY tblMensagens.Mensagem"

        Dim con_bt As New SqlConnection()
        Dim dr_bt As SqlDataReader

        con_bt.ConnectionString = strCon
        Dim cmd_bt As SqlCommand = con_bt.CreateCommand
        cmd_bt.CommandText = strSql

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        'Try
        con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            With dr
                If .HasRows Then
                    While (.Read())
                        TotalRegMsg += 1
                    End While
                End If
            End With

            Dim myfont As New Font("Sans Serif", 11, FontStyle.Regular)
            Dim btnArray(TotalRegMsg) As System.Windows.Forms.Button
            For i As Integer = 0 To TotalRegMsg
                btnArray(i) = New System.Windows.Forms.Button
            Next i

            con_bt.Open()
            dr_bt = cmd_bt.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr_bt.HasRows Then
            While (dr_bt.Read())
                With (btnArray(n))
                    '.Tag = dr_bt.GetInt32(1)
                    .Text = Trim(dr_bt.GetString(0))
                    .Width = 220
                    .Height = 45

                    '.BackColor = Color.Silver
                    '.ForeColor = Color.Yellow
                    .BackColor = Color.Gray
                    .ForeColor = Color.Lime

                    .FlatStyle = FlatStyle.Standard
                    .Font = myfont
                    .TextAlign = ContentAlignment.MiddleCenter

                    Me.PanelMsg.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Msg

                    n += 1
                End With
            End While
        End If


        'Catch ex As Exception
        'MsgBox(ex.Message + ex.StackTrace)
        'Finally
        con.Close()
            con.Dispose()
            con_bt.Close()
            con_bt.Dispose()
        'End Try

    End Sub

    Private Sub ClickButton_Msg(ByVal sender As Object, ByVal e As System.EventArgs)
        With CType(sender, Button)
            If .BackColor = Color.Gray Then
                .BackColor = Color.LawnGreen
                .ForeColor = Color.Gray

                Dim IDGrid As Integer = 0
                If DataSetMsg.Tables(0).Rows.Count = 0 Then
                    IDGrid = 1
                Else
                    IDGrid = DataSetMsg.Tables(0).Rows.Count + 1
                End If
                Dim nova_linha As DataRow = DataSetMsg.Tables(0).NewRow()
                nova_linha.ItemArray = New Object() { .Text}
                DataSetMsg.Tables(0).Rows.Add(nova_linha)
            Else
                .BackColor = Color.Gray
                .ForeColor = Color.Lime

                If DataSetMsg.Tables(0).Rows.Count > 0 Then
                    Dim i As Integer = 0
                    Dim ii As Integer = DataSetMsg.Tables(0).Rows.Count
                    While i < ii
                        If DataSetMsg.Tables(0).Rows(i).Item(0).ToString = .Text Then
                            DataSetMsg.Tables(0).Rows(i).Delete()
                            i -= 1
                            ii -= 1
                        End If
                        i += 1
                    End While
                End If
            End If
        End With
    End Sub

    Private Sub ClickButton_Impressoras(ByVal sender As Object, ByVal e As System.EventArgs)
        With CType(sender, Button)
            If .BackColor <> Color.Gray Then
                CodImp = 0
                NomeImp = String.Empty
            Else
                CodImp = NuloInteger(.Tag)
                NomeImp = .Text
            End If
            PanelMsg.Controls.Clear()
            'PanelImpressoras.Controls.Clear()
            MontaBotoesImpressoras()
        End With
    End Sub
    Private Sub fdlgMensagens_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = False

        lbMesa.Text = "Mesa: " & NumMesa
        MontaBotoesImpressoras()
        MontaMensagens()
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

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        CliqueNoBotao("7")
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        CliqueNoBotao("8")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CliqueNoBotao("9")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CliqueNoBotao("0")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        CliqueNoBotao("Q")
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CliqueNoBotao("W")
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CliqueNoBotao("E")
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        CliqueNoBotao("R")
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        CliqueNoBotao("T")
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        CliqueNoBotao("Y")
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        CliqueNoBotao("U")
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CliqueNoBotao("I")
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        CliqueNoBotao("O")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        CliqueNoBotao("P")
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        CliqueNoBotao("A")
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        CliqueNoBotao("S")
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        CliqueNoBotao("D")
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        CliqueNoBotao("F")
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        CliqueNoBotao("G")
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        CliqueNoBotao("H")
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        CliqueNoBotao("J")
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        CliqueNoBotao("K")
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        CliqueNoBotao("L")
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        CliqueNoBotao("Z")
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        CliqueNoBotao("X")
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        CliqueNoBotao("C")
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        CliqueNoBotao("V")
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        CliqueNoBotao("B")
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        CliqueNoBotao("N")
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        CliqueNoBotao("M")
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        CliqueNoBotao(" ")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        CliqueNoBotao("/")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        txtTextoLivre.Text = String.Empty
        lbLetras.Text = "25"
    End Sub

    Private Sub CliqueNoBotao(valor As String)
        If txtTextoLivre.TextLength < 25 Then
            txtTextoLivre.Text &= valor
            lbLetras.Text = (25 - txtTextoLivre.TextLength).ToString
        End If


    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If DataSetMsg.Tables(0).Rows.Count = 0 And txtTextoLivre.Text = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar ao menos uma mensagem," & vbCrLf & "ou digitar um texto livre"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If GridImpressoras.SelectedRows.Count = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um local para impressão"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim IDCat As Integer
        For i As Integer = 0 To GridImpressoras.SelectedRows.Count - 1
            IDCat = GridImpressoras.SelectedRows(i).Cells(1).Value
        Next

        strSql = "Select tblMesas.NumMesa, tblSetoresImpressoras.IDSetor, tblSetoresImpressoras.IDCategoria, tblSetoresImpressoras.Modulo, tblSetoresImpressoras.Impressora, tblSetoresImpressoras.Guilhotina, tblCategorias_Local.Categoria, tblCategorias_Local.Pedidos "
        strSql += "From tblSetoresImpressoras INNER Join tblCategorias_Local On tblSetoresImpressoras.IDCategoria = tblCategorias_Local.IDCategoria INNER Join tblMesas On tblSetoresImpressoras.IDSetor = tblMesas.IDSetor "
        strSql += "Where (tblMesas.NumMesa = " & NumMesa & ") And (tblSetoresImpressoras.IDCategoria = " & IDCat & ") And (tblSetoresImpressoras.Modulo = '" & Modulo & "')"

        Dim Impressora As String
        Dim Guilhotina As Boolean
        Dim ds As New DataSet()
        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        dap.Fill(ds, "Impressora")
        ds.Tables("Impressora").Reset()
        dap.Fill(ds, "Impressora")
        For i As Integer = 0 To ds.Tables("Impressora").Rows.Count - 1
            Impressora = NuloString(ds.Tables("Impressora").Rows(i).Item("Impressora"))
            Guilhotina = NuloBoolean(ds.Tables("Impressora").Rows(i).Item("Guilhotina"))
        Next

        CriaImpressao()
        ClassPrint.RawPrinterHelper.SendFileToPrinter(impressora, Application.StartupPath & "\Impressao\msg.txt")
        If Guilhotina = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgMensagens_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If TerminalVenda = True Then frmSalao.TimerTela.Enabled = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


End Class