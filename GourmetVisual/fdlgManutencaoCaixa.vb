Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Public Class fdlgManutencaoCaixa
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgManutencaoCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheDataSet()
    End Sub
    Private Sub PreencheDataSet()
        Dim con As New SqlConnection(strCon)
        Dim IDVda As Integer
        Dim VlrProduto As Decimal
        Dim VlrVenda As Decimal
        Dim QtdePess As Integer
        Dim Atendente As String
        Dim Status As String
        Dim Mesa As Integer
        Dim IDFuncAtende As Integer
        Dim TotalVda As Integer = 0

        DSLista.Tables(0).Clear()

        strSql = "Select IDVenda, NumMesa, TotalProdutos, TotalVenda, QtdPessoas, Atendente, IDFuncionarioAtendente, StatusVenda "
        strSql += "From tblVendas "
        strSql += "Order By IDVenda"

        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                TotalVda += 1
                IDVda = NuloInteger(dr.Item("IDVenda"))
                VlrProduto = Format(NuloDecimal(dr.Item("TotalProdutos")), "#0.00")
                VlrVenda = Format(NuloDecimal(dr.Item("TotalVenda")), "#0.00")
                QtdePess = NuloInteger(dr.Item("QtdPessoas"))
                Atendente = NuloString(dr.Item("Atendente"))
                Status = NuloString(dr.Item("StatusVenda"))
                IDFuncAtende = NuloInteger(dr.Item("IDFuncionarioAtendente"))
                Mesa = NuloInteger(dr.Item("NumMesa"))

                'Obtem um novo registro do formato correto para a tabela
                Dim nova_linha As DataRow = DSLista.Tables(0).NewRow()

                ' Preenche os valores do registro
                nova_linha.ItemArray = New Object() {IDVda, Mesa, VlrProduto, VlrVenda, QtdePess, Status, Atendente, IDFuncAtende}

                ' inclui o registro na tabela
                DSLista.Tables(0).Rows.Add(nova_linha)

            End While
        End If

        DataGrid.DataSource = DSLista
        DataGrid.DataMember = "Lista"
        DataGrid.Refresh()

        DataGrid.Columns(0).Visible = False
        DataGrid.Columns(0).Width = 0
        DataGrid.Columns(1).Width = 60
        DataGrid.Columns(2).Width = 80
        DataGrid.Columns(3).Width = 80
        DataGrid.Columns(4).Width = 80
        DataGrid.Columns(5).Width = 80
        DataGrid.Columns(6).Width = 150
        DataGrid.Columns(7).Visible = False
        DataGrid.Columns(7).Width = 0

        DataGrid.Columns(0).ReadOnly = True
        DataGrid.Columns(1).ReadOnly = True
        DataGrid.Columns(2).ReadOnly = True
        DataGrid.Columns(3).ReadOnly = True
        DataGrid.Columns(4).ReadOnly = False
        DataGrid.Columns(5).ReadOnly = False
        DataGrid.Columns(6).ReadOnly = True
        DataGrid.Columns(7).ReadOnly = True

        dr.Close()
        cmd.Dispose()
        con.Close()

        lbTotalVendas.Text = "Total vendas: " & TotalVda
    End Sub

    Private Sub btnAltera_Click(sender As Object, e As EventArgs) Handles btnAltera.Click

        Dim i As Integer = 0
        For i = 0 To DataGrid.Rows.Count - 1
            strSql = "UPDATE tblVendas SET "
            strSql += "QtdPessoas = " & NuloInteger(DataGrid.Rows(i).Cells(4).Value) & ", "
            strSql += "StatusVenda = '" & UCase(NuloString(DataGrid.Rows(i).Cells(5).Value)) & "' "
            strSql += "WHERE (IDVenda = " & DataGrid.Rows(i).Cells(0).Value & ")"
            ExecutaStr(strSql)
        Next i
        PreencheDataSet()

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        Dim i As Integer = 0
        For i = 0 To DataGrid.Rows.Count - 1
            If DataGrid.Rows(i).Selected = True Then

                Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
                frm1.lbMensagem.Text = "Confirma a exclusão deste registro"
                frm1.lbMensagem.ForeColor = Color.Blue
                frm1.btnNao.Visible = True
                frm1.btnSim.Visible = True
                frm1.btnOK.Visible = False
                frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
                frm1.ShowDialog()
                If RetornoMsg = False Then Exit Sub


                strSql = "Delete From tblVendasCombo WHERE IDVenda = " & DataGrid.Rows(i).Cells(0).Value
                ExecutaStr(strSql)

                strSql = "Delete From tblVendasComent WHERE IDVenda = " & DataGrid.Rows(i).Cells(0).Value
                ExecutaStr(strSql)

                strSql = "Delete From tblVendasMovto WHERE IDVenda = " & DataGrid.Rows(i).Cells(0).Value
                ExecutaStr(strSql)

                strSql = "Delete From tblVendasPagto WHERE IDVenda = " & DataGrid.Rows(i).Cells(0).Value
                ExecutaStr(strSql)

                strSql = "Delete From tblVendasSAT WHERE IDVenda = " & DataGrid.Rows(i).Cells(0).Value
                ExecutaStr(strSql)

                strSql = "Delete From tblVendas WHERE IDVenda = " & DataGrid.Rows(i).Cells(0).Value
                ExecutaStr(strSql)
            End If
        Next i
        PreencheDataSet()

    End Sub
End Class