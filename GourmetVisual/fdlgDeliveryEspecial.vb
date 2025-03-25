Imports System.Data.SqlClient

Public Class fdlgDeliveryEspecial
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub PreencheFuncionario()

        Dim con As New SqlConnection(strCon)
        Dim texto As String = ""

        cbFuncionario.Items.Clear()

        strSql = "Select CAST(Funcionario As int) As Funcionario_, Funcao, Diaria, ForaArea, OnLine "
        strSql += "From tblFuncionarios_Local "
        strSql += "Where (Funcao = N'ENTREGADOR') "
        strSql += "Order By Funcionario_"

        con.Open()
        Dim cmdLJS As New SqlCommand(strSql, con)
        cmdLJS.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = cmdLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drLJS.HasRows Then
            cbFuncionario.Items.Add("")
            While (drLJS.Read())
                texto = drLJS.Item("Funcionario_")
                cbFuncionario.Items.Add(texto)
            End While
        End If
        drLJS.Close()
        cmdLJS.Dispose()
        con.Close()
    End Sub
    Private Sub PreencheDataSet()
        Dim con As New SqlConnection(strConServer)
        Dim IDFec As Integer = NuloInteger(frmCaixa.lbIDFechamento.Text)
        Dim Funcionario As String
        Dim VlrDiaria As Decimal
        Dim VlrFA As Decimal
        Dim VlrOnLine As Decimal
        Dim VlrCaixinha As Decimal
        Dim VlrTotal As Decimal
        Dim TotDiaria As Decimal = 0
        Dim TotFA As Decimal = 0
        Dim TotOnLine As Decimal = 0
        Dim TotCaixinha As Decimal = 0
        Dim TotTotal As Decimal = 0
        Dim TotFun As Decimal = 0

        DSLista.Tables(0).Clear()

        strSql = "Select IDFechamentoLocal, CAST(Funcionario As int) As Funcionario_, Diaria, ForaArea, OnLine "
        strSql += "From tblDeliveryEspecial "
        strSql += "Where (IDFechamentoLocal = " & IDFec & ") "
        strSql += "Order By Funcionario_"

        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                TotFun += 1
                Funcionario = NuloString(dr.Item("Funcionario_"))
                VlrDiaria = NuloDecimal(dr.Item("Diaria"))
                VlrFA = NuloDecimal(dr.Item("ForaArea"))
                VlrOnLine = NuloDecimal(dr.Item("OnLine"))

                strSql = "Select IDFechamento, SUM(Caixinha) As Caixinha, Entregador "
                strSql += "From tblVendas "
                strSql += "Group By IDFechamento, Entregador "
                strSql += "HAVING(IDFechamento = " & IDFec & ") And (Entregador = '" & Funcionario & "')"
                VlrCaixinha = NuloDecimal(PegaValorCampo("Caixinha", strSql, strCon))

                VlrTotal = VlrDiaria + VlrFA + VlrOnLine + VlrCaixinha

                TotDiaria += VlrDiaria
                TotFA += VlrFA
                TotOnLine += VlrOnLine
                TotCaixinha += VlrCaixinha
                TotTotal += VlrTotal

                'Obtem um novo registro do formato correto para a tabela
                Dim nova_linha As DataRow = DSLista.Tables(0).NewRow()

                ' Preenche os valores do registro
                nova_linha.ItemArray = New Object() {Funcionario, Format(VlrCaixinha, "#0.00"), Format(VlrDiaria, "#0.00"), Format(VlrFA, "#0.00"), Format(VlrOnLine, "#0.00"), Format(VlrTotal, "#0.00")}

                ' inclui o registro na tabela
                DSLista.Tables(0).Rows.Add(nova_linha)
            End While
        End If
        dr.Close()
        cmd.Dispose()



        strSql = "Select CAST(tblFuncionarios_Local.Funcionario As int) As Funcionario_, tblFuncionarios_Local.Funcao, tblFuncionarios_Local.Diaria, tblFuncionarios_Local.ForaArea, tblFuncionarios_Local.OnLine, tblDeliveryEspecial.Funcionario "
        strSql += "From tblFuncionarios_Local LEFT OUTER Join tblDeliveryEspecial On tblFuncionarios_Local.Funcionario = tblDeliveryEspecial.Funcionario "
        strSql += "Where (tblFuncionarios_Local.Funcao = 'ENTREGADOR') AND (tblDeliveryEspecial.Funcionario IS NULL) "
        strSql += "Order By Funcionario_"

        con = New SqlConnection(strCon)
        con.Open()
        Dim cmdLJS As New SqlCommand(strSql, con)
        cmdLJS.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = cmdLJS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drLJS.HasRows Then
            cbFuncionario.Items.Add("")
            While (drLJS.Read())

                Funcionario = NuloString(drLJS.Item("Funcionario_"))
                VlrDiaria = 0
                VlrFA = 0
                VlrOnLine = 0

                strSql = "Select IDFechamento, SUM(Caixinha) As Caixinha, Entregador "
                strSql += "From tblVendas "
                strSql += "Group By IDFechamento, Entregador "
                strSql += "HAVING(IDFechamento = " & IDFec & ") And (Entregador = '" & Funcionario & "')"
                VlrCaixinha = NuloDecimal(PegaValorCampo("Caixinha", strSql, strCon))

                If VlrCaixinha <> 0 Then
                    TotFun += 1
                    VlrTotal = VlrDiaria + VlrFA + VlrOnLine + VlrCaixinha

                    TotCaixinha += VlrCaixinha
                    TotTotal += VlrTotal

                    Dim nova_linha As DataRow = DSLista.Tables(0).NewRow()
                    nova_linha.ItemArray = New Object() {Funcionario, Format(VlrCaixinha, "#0.00"), Format(VlrDiaria, "#0.00"), Format(VlrFA, "#0.00"), Format(VlrOnLine, "#0.00"), Format(VlrTotal, "#0.00")}
                    DSLista.Tables(0).Rows.Add(nova_linha)

                    strSql = "Delete From tblDeliveryEspecial WHERE IDFechamentoLocal = " & IDFec & " AND Funcionario = '" & Funcionario & "'"
                    ExecutaStrServidor(strSql)

                    strSql = "INSERT tblDeliveryEspecial "
                    strSql += "(IDFechamentoLocal, Funcionario, Diaria, ForaArea, OnLine, Caixinha) VALUES ("
                    strSql += frmCaixa.lbIDFechamento.Text & ", "
                    strSql += "'" & Funcionario & "', "
                    strSql += "0, "
                    strSql += "0, "
                    strSql += "0, "
                    strSql += Replace(NuloDecimal(VlrCaixinha), ",", ".") & ")"
                    ExecutaStrServidor(strSql)
                End If
            End While
        End If
        drLJS.Close()
        cmdLJS.Dispose()
        con.Close()

        lbTotalCaixinha.Text = Format(TotCaixinha, "#0.00")
        lbTotalDiaria.Text = Format(TotDiaria, "#0.00")
        lbTotalForaArea.Text = Format(TotFA, "#0.00")
        lbTotalOnLine.Text = Format(TotOnLine, "#0.00")
        lbTotalGeral.Text = Format(TotTotal, "#0.00")

        DataGrid.DataSource = DSLista
        DataGrid.DataMember = "Lista"
        DataGrid.Refresh()

        DataGrid.Columns(0).Width = 200
        DataGrid.Columns(1).Width = 80
        DataGrid.Columns(2).Width = 80
        DataGrid.Columns(3).Width = 80
        DataGrid.Columns(4).Width = 80
        DataGrid.Columns(5).Width = 80

        DataGrid.Columns(0).ReadOnly = True
        DataGrid.Columns(1).ReadOnly = True
        DataGrid.Columns(2).ReadOnly = True
        DataGrid.Columns(3).ReadOnly = True
        DataGrid.Columns(4).ReadOnly = True
        DataGrid.Columns(5).ReadOnly = True

        DataGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DataGrid.ClearSelection()

        lbTotalFunc.Text = "Total de Funcionarios: " & TotFun
    End Sub
    Private Sub fdlgDeliveryEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If NuloString(frmCaixa.lbIDFechamento.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessario selecionar um movimento"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()

            Me.Dispose()
            Me.Close()
        End If

        PreencheFuncionario()
        PreencheDataSet()

    End Sub

    Private Sub btnEnvia_Click(sender As Object, e As EventArgs) Handles btnEnvia.Click

        If NuloString(cbFuncionario.Text) = "" Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessario selecionar um funcionário"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloDecimal(tbDiaria.Text) = 0 And NuloDecimal(tbFA.Text) = 0 And NuloDecimal(tbOnLine.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "Valor inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        Dim Funcionario As String

        strSql = "Select IDFechamentoLocal, Funcionario, Diaria, ForaArea, OnLine "
        strSql += "From tblDeliveryEspecial "
        strSql += "Where (IDFechamentoLocal = " & frmCaixa.lbIDFechamento.Text & ") AND (Funcionario = " & cbFuncionario.Text & ")"
        Funcionario = PegaValorCampo("Funcionario", strSql, strConServer)

        If Funcionario = "ERRO" Or Funcionario = "" Then
            strSql = "INSERT tblDeliveryEspecial "
            strSql += "(IDFechamentoLocal, Funcionario, Diaria, ForaArea, OnLine) VALUES ("
            strSql += frmCaixa.lbIDFechamento.Text & ", "
            strSql += cbFuncionario.Text & ", "
            strSql += Replace(NuloDecimal(tbDiaria.Text), ",", ".") & ", "
            strSql += Replace(NuloDecimal(tbFA.Text), ",", ".") & ", "
            strSql += Replace(NuloDecimal(tbOnLine.Text), ",", ".") & ")"
            ExecutaStrServidor(strSql)
        Else
            strSql = "UPDATE tblDeliveryEspecial SET "
            strSql += "Diaria = " & Replace(NuloDecimal(tbDiaria.Text), ",", ".") & ", "
            strSql += "ForaArea = " & Replace(NuloDecimal(tbFA.Text), ",", ".") & ", "
            strSql += "OnLine = " & Replace(NuloDecimal(tbOnLine.Text), ",", ".") & " "
            strSql += "Where (IDFechamentoLocal = " & frmCaixa.lbIDFechamento.Text & ") AND (Funcionario = " & cbFuncionario.Text & ")"
            ExecutaStrServidor(strSql)
        End If
        PreencheDataSet()

        cbFuncionario.Text = ""
        tbDiaria.Text = "0,00"
        tbFA.Text = "0,00"
        tbOnLine.Text = "0,00"

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        frm.lbMensagem.Text = "Deseja realmente excluir este registro"
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        Dim Funcionario As String = DataGrid.Rows(DataGrid.CurrentCell.RowIndex).Cells("Funcionario").Value

        strSql = "Delete From tblDeliveryEspecial WHERE IDFechamentoLocal = " & frmCaixa.lbIDFechamento.Text & " AND Funcionario = '" & Funcionario & "'"
        ExecutaStrServidor(strSql)

        DataGrid.Rows.Remove(DataGrid.CurrentRow)
        DataGrid.Refresh()
        PreencheDataSet()
    End Sub

    Private Sub btnRelatorio_Click(sender As Object, e As EventArgs) Handles btnRelatorio.Click

        Dim conM As New SqlConnection()
        conM.ConnectionString = strCon

        Dim drM As SqlDataReader
        Dim cmdM As SqlCommand = conM.CreateCommand
        Dim Func As String
        Dim Diaria As Decimal
        Dim Caixi As Decimal
        Dim FA As Decimal
        Dim OnLine As Decimal
        Dim Total As Decimal
        Dim TotalDiaria As Decimal = 0
        Dim TotalCaixi As Decimal = 0
        Dim TotalFA As Decimal = 0
        Dim TotalOnLine As Decimal = 0
        Dim TotalGeral As Decimal = 0
        Dim lngFile As Integer = FreeFile()
        Dim texto As String

        strSql = "Select IDFechamentoLocal, CAST(Funcionario As INT) As Funcionario_, Caixinha, Diaria, ForaArea, OnLine "
        strSql += "From tblDeliveryEspecial "
        strSql += "Where (IDFechamentoLocal = " & frmCaixa.lbIDFechamento.Text & ") "
        strSql += "Order By CAST(Funcionario As INT)"

        FileClose(lngFile)
        FileOpen(lngFile, Application.StartupPath & "\Impressao\financeiro.txt", OpenMode.Output)

        cmdM.CommandText = strSql
        conM.Open()
        drM = cmdM.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drM.HasRows Then
            PrintLine(lngFile, "PAGAMENTO ENTREGADORES")
            PrintLine(lngFile, "----------------------------------------")
            PrintLine(lngFile, " ")
            PrintLine(lngFile, "Entr   Caixi Diaria    FA  OnLine    TOTAL")
            PrintLine(lngFile, "==========================================")
            While (drM.Read())
                Func = Strings.Left(drM.Item("Funcionario_"), 6)
                Diaria = NuloDecimal(drM.Item("Diaria"))
                TotalDiaria += Diaria
                Caixi = Format(NuloDecimal(drM.Item("Caixinha")), "#0.00")
                TotalCaixi += Caixi
                FA = NuloDecimal(drM.Item("ForaArea"))
                TotalFA += FA
                OnLine = NuloDecimal(drM.Item("OnLine"))
                TotalOnLine += OnLine
                Total = NuloDecimal(Diaria + Caixi + FA + OnLine)
                TotalGeral += Total

                texto = Func + Space(5 - Len(Func))
                texto += Space(7 - Len(Strings.Left(Caixi, 7))) + Strings.Left(Caixi, 7)
                texto += Space(7 - Len(Strings.Left(Diaria, 7))) + Strings.Left(Diaria, 7)
                texto += Space(7 - Len(Strings.Left(FA, 7))) + Strings.Left(FA, 7)
                texto += Space(7 - Len(Strings.Left(OnLine, 7))) + Strings.Left(OnLine, 7)
                texto += Space(9 - Len(Strings.Left(Total, 9))) + Strings.Left(Total, 9)
                PrintLine(lngFile, texto)
            End While
            PrintLine(lngFile, "==========================================")
            texto = Space(7 - Len(Strings.Left(TotalCaixi, 7))) + Strings.Left(Format(TotalCaixi, "#0.00"), 7)
            texto += Space(7 - Len(Strings.Left(TotalDiaria, 7))) + Strings.Left(Format(TotalDiaria, "#0.00"), 7)
            texto += Space(7 - Len(Strings.Left(TotalFA, 7))) + Strings.Left(Format(TotalFA, "#0.00"), 7)
            texto += Space(7 - Len(Strings.Left(TotalOnLine, 7))) + Strings.Left(Format(TotalOnLine, "#0.00"), 7)
            texto += Space(9 - Len(Strings.Left(TotalGeral, 9))) + Strings.Left(Format(TotalGeral, "#0.00"), 9)
            PrintLine(lngFile, "TOTAL" + texto)
        End If
        drM.Close()
        conM.Dispose()
        conM.Close()

        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        PrintLine(lngFile, " ")
        FileClose(lngFile)


        ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\financeiro.txt")
        If GuilhotinaImpCaixa = True Then
            ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
        End If

    End Sub
End Class