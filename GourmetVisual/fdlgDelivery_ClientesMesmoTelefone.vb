Imports System.Data.SqlClient

Public Class fdlgDelivery_ClientesMesmoTelefone
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        IDClienteMaisTelefones = 0
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub PreencheClientes()
        Dim QtdItens As Integer = 0
        Dim item As ListViewItem

        lstClientes.Items.Clear()

        strSql = "Select tblClientes.IDCliente, tblClientes.NomeCliente, tblRuas.Logradouro, tblClientes.Numero, tblClientes.Complemento, tblClientes.Referencia, tblClientes.Bairro, tblClientes.CEP, tblClientes.Area, tblClientes.Tel1, tblClientes.Tel2, tblClientes.Origem, tblClientes.DDD1, tblClientes.DDD2, tblClientes.CPF_CNPJ, tblClientes.IDRua, tblClientes.ComplementoTel "
        strSql += "From tblClientes LEFT OUTER Join tblRuas On tblClientes.IDRua = tblRuas.IDRua "
        strSql += "WHERE (tblClientes.Tel1 = '" & NuloString(lbTelefone.Text) & "') AND (tblClientes.DDD1 = '" & NuloString(lbDDD.Text) & "') "
        If NuloString(tbBusca.Text) <> "" Then
            strSql += "AND (tblClientes.NomeCliente like '%" & NuloString(tbBusca.Text) & "%') "
        End If
        strSql += "Order By tblClientes.NomeCliente"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            item = lstClientes.Items.Add(ds.Tables("Ruas").Rows(i).Item("IDCliente"))
            If NuloString(ds.Tables("Ruas").Rows(i).Item("Tel1")) = "" Then
                item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("CPF_CNPJ")))
            Else
                item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Tel1")))
            End If
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("NomeCliente")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Numero")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Complemento")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("CEP")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("ComplementoTel")))
            QtdItens += 1
        Next
        lbQtdeClientes.Text = "Qtde. de clientes com este telefone: " & QtdItens
        dap.Dispose()
        ds.Dispose()


    End Sub
    Private Sub FdlgDelivery_ClientesMesmoTelefone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbDDD.Text = frmDelivery.tbDDD.Text
        lbTelefone.Text = frmDelivery.tbBuscaCliente.Text
        PreencheClientes()

    End Sub

    Private Sub TbBuscaRuas_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaRuas.TextChanged

    End Sub

    Private Sub tbBuscaRuas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBuscaRuas.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If tbBuscaRuas.Text <> "" Then
                If Not IsNumeric(tbBuscaRuas.Text) Then
                    Dim frm As fdlgBuscaRuas = New fdlgBuscaRuas
                    frm.tbBuscaRua.Text = tbBuscaRuas.Text
                    frm.ShowDialog()
                    tbLogradouro.Text = NomeLogradouro
                    tbIDRua.Text = NomeIDRua
                    tbBairro.Text = NomeBairro
                    tbCEP.Text = NomeCEP
                    tbArea.Text = NomeArea
                    lbTaxaEntrega.Text = NomeTaxaEntrega
                    tbBuscaRuas.Text = ""
                    tbNumero.Focus()
                Else
                    fdlgDeliveryCadastroCliente.BuscaPeloCEP()

                End If
            End If

        End If
    End Sub

    Private Sub LstClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClientes.SelectedIndexChanged

    End Sub

    Private Sub lstClientes_DoubleClick(sender As Object, e As EventArgs) Handles lstClientes.DoubleClick
        If lstClientes.SelectedItems.Count > 0 Then
            IDClienteMaisTelefones = NuloInteger(lstClientes.SelectedItems(0).SubItems(0).Text)
            Me.Dispose()
            Me.Close()

        End If

    End Sub

    Private Sub lstClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lstClientes.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            If lstClientes.SelectedItems.Count > 0 Then
                IDClienteMaisTelefones = NuloInteger(lstClientes.SelectedItems(0).SubItems(0).Text)
                Me.Dispose()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheClientes()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim frm As fdlgDeliveryCadastroCliente = New fdlgDeliveryCadastroCliente
        frm.lbStatus.Text = "I"
        frm.lbTelefone.Text = lbTelefone.Text
        frm.lbDDD.Text = lbDDD.Text

        Me.Dispose()
        Me.Close()

        frm.ShowDialog()

    End Sub
End Class