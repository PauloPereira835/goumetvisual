Imports System.Data.SqlClient
Imports System.IO

Public Class fdlgEstornoDelivery
    Private Sub CriaCupomEstorno()
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        Dim lngFile As Integer = FreeFile()
        Dim texto As String
        Dim campo As String
        Dim Motivo As String
        Dim Cabec As Boolean = True

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        strSql = "Select tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, SUM(tblVendasMovto.Qtd) As Qtde, tblVendasMovto.Excluido, tblVendasMovto.MotivoEstorno, tblVendasMovto.Impresso, tblVendasMovto.IDProduto, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.StatusVenda "
        strSql += "From tblVendasMovto INNER Join tblProdutos_Local On tblVendasMovto.IDProduto = tblProdutos_Local.IDProduto INNER Join tblVendas On tblVendasMovto.IDVenda = tblVendas.IDVenda "
        strSql += "Group By tblVendasMovto.IDVenda, tblProdutos_Local.CodigoProduto, tblVendasMovto.Produto, tblVendasMovto.MotivoEstorno, tblVendasMovto.IDProduto, tblVendasMovto.Excluido, tblVendasMovto.Impresso, tblVendas.NumVenda, tblVendas.NumMesa, tblVendas.StatusVenda "
        strSql += "HAVING(tblVendasMovto.Excluido = 1) And (tblVendasMovto.Impresso = 0) And (tblVendasMovto.IDVenda = " & IDVenda & ") "
        strSql += "ORDER BY tblVendasMovto.MotivoEstorno, tblVendasMovto.Produto"

        Try
1:

            FileClose(lngFile)
            FileOpen(lngFile, Application.StartupPath & "\Impressao\estorno.txt", OpenMode.Output)

            texto = Chr(14) & "PRODUTOS ESTORNADOS" & Chr(27) & Chr(14)
            PrintLine(lngFile, texto)
            texto = "-------------------------------------------------"
            PrintLine(lngFile, texto)
            texto = "Operador:  " & Operador
            PrintLine(lngFile, texto)
            texto = Now.ToString
            PrintLine(lngFile, texto)


            cmd.CommandText = strSql
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                While (dr.Read())
                    If Cabec = True Then
                        If dr.Item("StatusVenda") = "S" Then
                            texto = "ORIGEM: Salao    MESA: " & dr.Item("NumMesa") & "    VENDA: " & dr.Item("NumVenda")
                        Else
                            If dr.Item("StatusVenda") = "B" Then
                                texto = "ORIGEM: Balcao       VENDA: " & dr.Item("NumVenda")
                            Else
                                texto = "ORIGEM: Delivery     VENDA: " & dr.Item("NumVenda")
                            End If
                        End If

                        PrintLine(lngFile, texto)
                        texto = "=================================================="
                        PrintLine(lngFile, texto)
                        Cabec = False
                    End If
                    Motivo = dr.Item("MotivoEstorno")
                    PrintLine(lngFile, ">>> " & Motivo & " <<<")
                    While Motivo = dr.Item("MotivoEstorno")
                        campo = Space(6 - Len(dr.Item("CodigoProduto").ToString)) & dr.Item("CodigoProduto")
                        campo &= " " & dr.Item("Produto") & Space(30 - Len(Trim(dr.Item("Produto"))))
                        campo &= " " & Format(dr.Item("Qtde"), "#0.000")
                        texto = campo
                        PrintLine(lngFile, texto)
                        If dr.Read() = False Then
                            Exit While
                        End If
                    End While
                    PrintLine(lngFile, " ")
                End While

                PrintLine(lngFile, "==================================================")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")
                PrintLine(lngFile, " ")

                FileClose(lngFile)


            End If
            dr.Close()
            con.Dispose()
            con.Close()

        Catch ex As Exception
            If InStr(1, ex.Message, "localizar") > 0 Then
                Dim fs As FileStream = File.Create(Application.StartupPath & "\Impressao\estorno.txt")
                fs.Close()
                GoTo 1
            Else
                MsgBox(ex.Message)
            End If

        End Try


    End Sub
    Public Sub AtualizaGridMotivos()

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        cmd.CommandText = "Select Motivo From tblMotivosEstorno WHERE EstornoProduto=1 Order By Motivo"
        GridMotivo.Rows.Clear()

        Try
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

            If dr.HasRows Then
                While (dr.Read())
                    GridMotivo.Rows.Add({NuloString(dr.Item("Motivo"))})
                End While
            End If


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub
    Private Sub BtnSai_Click(sender As Object, e As EventArgs) Handles btnSai.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgEstornoDelivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AtualizaGridMotivos()
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        Dim Motivo As String = ""
        Dim ID As Integer = NuloInteger(tbIDMovto.Text)
        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If GridMotivo.SelectedRows.Count > 0 Then
            Dim drc As DataGridViewSelectedRowCollection = GridMotivo.SelectedRows
            For i As Integer = 0 To drc.Count - 1
                Dim Produto As String = drc(i).Cells(0).Value
                Motivo = (Produto)
            Next
        Else
            frm.lbMensagem.Text = "É necessário selecionar o motivo"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If


        If NuloString(tbIDVenda.Text) = "" Then
            frm.lbMensagem.Text = "Confirma o estono deste lançamento"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then
                Exit Sub
            End If

            strSql = "UPDATE tblVendasMovto Set "
            strSql &= "Excluido=1, "
            strSql &= "Venda=0, "
            strSql &= "VendaServico=0, "
            strSql &= "HoraPedido='" & Now & "', "
            strSql &= "MotivoEstorno='" & Motivo & "' "
            strSql &= "WHERE (IDVendaMovto=" & ID & ")"
            ExecutaStr(strSql)

            If ImpEstorno = True Then
                CriaCupomEstorno()
                ClassPrint.RawPrinterHelper.SendFileToPrinter(ImpCaixa, Application.StartupPath & "\Impressao\estorno.txt")
                If GuilhotinaImpCaixa = True Then
                    ClassPrint.RawPrinterHelper.SendStringToPrinter(ImpCaixa, Chr(27) & Chr(109))
                End If
                strSql = "UPDATE tblVendasMovto Set "
                strSql &= "Impresso=1 "
                strSql += "WHERE (IDVenda=" & IDVenda & ") AND (Excluido=1)"
                ExecutaStr(strSql)
            End If
        Else
            frm.lbMensagem.Text = "Confirma o estono desta venda"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
            frm.ShowDialog()
            If RetornoMsg = False Then
                Exit Sub
            End If

            If IDFechamento = 0 Then
                strSql = "SELECT IDFechamento, IDFuncionario, Caixa, Confirmado FROM tblFechamentos_Local WHERE (Confirmado = 0) AND (IDFuncionario = " & IDFuncionarioAutorizado & ")"
                IDFechamento = NuloInteger(PegaValorCampo("IDFechamento", strSql, strCon))
            End If
            If IDFechamento = 0 Then
                strSql = "SELECT IDFechamento, IDFuncionario, Caixa, Confirmado FROM tblFechamentos_Local WHERE (Confirmado = 0)"
                IDFechamento = NuloInteger(PegaValorCampo("IDFechamento", strSql, strCon))
            End If
            If IDFechamento = 0 Then
                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "É necessário ter o caixa aberto"
                frm1.btnNao.Visible = False
                frm1.btnSim.Visible = False
                frm1.btnOK.Visible = True
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm1.ShowDialog()
                Exit Sub
            End If

            strSql = "UPDATE tblVendas Set "
            strSql &= "IDFechamento=" & IDFechamento & ", "
            strSql &= "FlagFechada=1, "
            strSql &= "Excluido=1, "
            strSql &= "TaxaEntrega=0, "
            strSql &= "Caixinha=0, "
            strSql &= "TotalVenda=0, "
            strSql &= "TotalProdutos=0, "
            strSql &= "IDFuncionarioAtendente=" & IDOperador & ", "
            strSql &= "Atendente='" & Operador & "', "
            strSql &= "MotivoEstorno='" & GridMotivo.Text & "' "
            strSql &= "WHERE (IDVenda=" & NuloInteger(tbIDVenda.Text) & ")"
            ExecutaStr(strSql)

            strSql = "UPDATE tblVendasMovto Set "
            strSql &= "Excluido=1, "
            strSql &= "Venda=0, "
            strSql &= "HoraPedido='" & Now & "', "
            strSql &= "VendaServico=0, "
            strSql &= "MotivoEstorno='" & GridMotivo.Text & "' "
            strSql &= "WHERE (IDVenda=" & NuloInteger(tbIDVenda.Text) & ")"
            ExecutaStr(strSql)

            strSql = "DELETE FROM tblVendasPagto WHERE (IDVenda=" & NuloInteger(tbIDVenda.Text) & ")"
            ExecutaStr(strSql)

            strSql = "DELETE FROM tblVendasSAT WHERE (IDVenda=" & NuloInteger(tbIDVenda.Text) & ")"
            ExecutaStr(strSql)
        End If

        Me.Dispose()
        Me.Close()


    End Sub

    Private Sub fdlgEstornoDelivery_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.F7
                Me.InvokeOnClick(btnConfirma, e)

            Case Keys.KeyCode.Escape
                Me.InvokeOnClick(btnSai, e)

        End Select
    End Sub
End Class