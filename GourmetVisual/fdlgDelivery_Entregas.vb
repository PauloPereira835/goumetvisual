Imports System.Data.SqlClient

Public Class fdlgDelivery_Entregas
    Private Sub PreencheListaServico()
        Dim item As ListViewItem
        Dim VlrVendas As Decimal = 0
        Dim VlrTotal As Decimal = 0
        Dim VlrTaxaEntrega As Decimal = 0
        Dim VlrCaixinha As Decimal = 0
        Dim Qtde As Integer = 0

        strSql = "Select tblVendas.NumVendaD, SUM(tblVendas.TotalProdutos) As Vendas, SUM(tblVendas.Servico) As Servico, SUM(tblVendas.Caixinha) As Caixinha, tblFuncionarios_Local.Funcionario, SUM(tblVendas.TaxaEntrega) As TXEntrega, SUM(tblVendas.QtdPessoas) As Qtde, tblVendas.Excluido, tblFuncionarios_Local.IDFuncionario "
        strSql += "From tblVendas INNER Join tblFuncionarios_Local On tblVendas.Entregador = tblFuncionarios_Local.Funcionario "
        strSql += "Where (tblVendas.Excluido=0) AND (tblFuncionarios_Local.IDFuncionario=" & fdlgExpedicao.tbIDFuncionario.Text & ") "
        strSql += "Group By tblFuncionarios_Local.Funcionario, tblVendas.Excluido, tblFuncionarios_Local.IDFuncionario, tblVendas.NumVendaD "
        strSql += "Order By NumVendaD"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        lstEntregas.Items.Clear()
        Dim Total As Decimal
        If dr.HasRows Then
            While dr.Read()

                lbEntregador.Text = dr.Item("Funcionario")

                Total = 0

                item = lstEntregas.Items.Add(NuloInteger(dr.Item("NumVendaD")))

                item.SubItems.Add(Format(NuloDecimal(dr.Item("TXEntrega")), "#0.00"))
                VlrTaxaEntrega += NuloDecimal(dr.Item("TXEntrega"))

                item.SubItems.Add(Format(NuloDecimal(dr.Item("Caixinha")), "#0.00"))
                VlrCaixinha += NuloDecimal(dr.Item("Caixinha"))

                Total = NuloDecimal(dr.Item("Caixinha")) + NuloDecimal(dr.Item("TXEntrega"))
                item.SubItems.Add(Format(Total, "#0.00"))
                VlrTotal += Total

                'item.SubItems.Add(Format(NuloDecimal(dr.Item("Vendas")), "#0.00"))
                'VlrVendas += NuloDecimal(dr.Item("Vendas"))

                Qtde += 1

            End While
            lstEntregas.Update()
            lstEntregas.EndUpdate()
        End If

        lbVendas.Text = Format(VlrVendas, "#0.00")
        lbCaixinha.Text = Format(VlrCaixinha, "#0.00")
        lbTxEntrega.Text = Format(VlrTaxaEntrega, "#0.00")
        lbTotal.Text = Format(VlrTotal, "#0.00")
        lbQtdeEntregas.Text = "Qtde. entregas : " & Format(Qtde, "#0")

        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()


    End Sub
    Private Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgDelivery_Entregas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheListaServico()
    End Sub
End Class