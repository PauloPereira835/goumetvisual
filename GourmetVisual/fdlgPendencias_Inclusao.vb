Imports System.Data.SqlClient

Public Class fdlgPendencias_Inclusao
    Private Sub PreencheClientes()
        Dim item As ListViewItem
        Dim QtdeCli As Integer = 0
        Dim con As New SqlConnection(strCon)
        con.Open()

        strSql = "Select IDCliente, NomeCliente, Tel1, SaldoNegativo, SaldoCredito "
        strSql += "From tblClientes "
        If tbBusca.Text <> "" Then
            If Not IsNumeric(tbBusca.Text) Then
                strSql += "WHERE (NomeCliente LIKE '%" & tbBusca.Text & "%') "
            Else
                strSql += "WHERE (Tel1 LIKE '%" & tbBusca.Text & "%') "
            End If
            If chkPermiteSaldoNegativo.Checked = True Then
                strSql += "And (SaldoNegativo=1) "
            Else
                strSql += "And (SaldoNegativo=0) "
            End If
        Else
            If chkPermiteSaldoNegativo.Checked = True Then
                strSql += "WHere (SaldoNegativo=1) "
            Else
                strSql += "Where (SaldoNegativo=0) "
            End If
        End If
        strSql += "Order By NomeCliente"

        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        lstClientes.Items.Clear()

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If dr.HasRows Then
            While (dr.Read)
                item = lstClientes.Items.Add(dr.Item("IDCliente"))
                item.SubItems.Add(NuloString(dr.Item("NomeCliente")))
                item.SubItems.Add(NuloString(dr.Item("Tel1")))
                item.SubItems.Add(NuloBoolean(dr.Item("SaldoNegativo")))
                item.SubItems.Add(NuloDecimal(dr.Item("SaldoCredito")))
                QtdeCli += 1
            End While
            lstClientes.Update()
            lstClientes.EndUpdate()
        End If
        cmd.Dispose()
        dr.Close()
        con.Dispose()
        con.Close()
        lbTotalClientes.Text = QtdeCli
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tbBusca.Text = "1"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tbBusca.Text = "2"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        tbBusca.Text = "3"
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        tbBusca.Text = "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        tbBusca.Text = "5"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tbBusca.Text = "6"
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        tbBusca.Text = "7"
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        tbBusca.Text = "8"
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        tbBusca.Text = "9"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tbBusca.Text = "0"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tbBusca.Text = "Q"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tbBusca.Text = "W"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tbBusca.Text = "E"
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        tbBusca.Text = "R"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        tbBusca.Text = "T"
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        tbBusca.Text = "Y"
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        tbBusca.Text = "U"
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        tbBusca.Text = "I"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        tbBusca.Text = "O"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        tbBusca.Text = "P"
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        tbBusca.Text = "A"
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        tbBusca.Text = "S"
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        tbBusca.Text = "D"
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        tbBusca.Text = "F"
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        tbBusca.Text = "G"
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        tbBusca.Text = "H"
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        tbBusca.Text = "J"
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        tbBusca.Text = "K"
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        tbBusca.Text = "L"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        tbBusca.Text = ""
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        tbBusca.Text = "Z"
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        tbBusca.Text = "X"
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        tbBusca.Text = "C"
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        tbBusca.Text = "V"
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        tbBusca.Text = "B"
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        tbBusca.Text = "N"
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        tbBusca.Text = "M"
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        tbBusca.Text = " "
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        tbBusca.Text = "-"
    End Sub

    Private Sub FdlgPendencias_Inclusao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkPermiteSaldoNegativo.Checked = True
        PreencheClientes()
        lbValor.Text = CType(lbValor.Text, Decimal).ToString("#0.00")
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged

    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        RetornoPendenciaInclusaoIDPendencia = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BtnIncluirCliente_Click(sender As Object, e As EventArgs) Handles btnIncluirCliente.Click

        If NuloInteger(tbIDCliente.Text) = 0 Then
            Dim frm As fdlgMensagemBox = New fdlgMensagemBox
            frm.lbMensagem.Text = "É necessário selecionar um cliente"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        If NuloBoolean(tbSaldoNegativo.Text) = False Then
            If NuloDecimal(lbValor.Text) > NuloDecimal(tbSaldo.Text) Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Saldo (" & NuloDecimal(tbSaldo.Text) & ") do cliente insuficiente"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If
        End If

        Dim Saldo As Decimal = SaldoPendencia(NuloInteger(tbIDCliente.Text))
        Saldo -= NuloDecimal(lbValor.Text)
        strSql = "INSERT tblPendenciasLoja "
        strSql += "(IDLoja, IDFechamento, IDCliente, IDVenda, IDFormaPagto, Data, Descricao, Valor, Saldo, Lancado) VALUES ("
        strSql += to_sql(IDLoja) & ", "
        strSql += to_sql(IDFechamento) & ", "
        strSql += to_sql(NuloInteger(tbIDCliente.Text)) & ", "
        strSql += to_sql(NuloInteger(IDVenda)) & ", "
        strSql += to_sql(NuloInteger(tbIDpagto.Text)) & ", "
        strSql += to_sqlDATA(Now, "data", "L") & ", "
        strSql += "'VENDA', "
        strSql += Replace(lbValor.Text * -1, ",", ".") & ", "
        strSql += Replace(Saldo.ToString, ",", ".") & ", "
        strSql += "0)"
        ExecutaStr(strSql)

        RetornoPendenciaInclusaoIDPendencia = NuloInteger(PegaID("IDPendencia", "tblPendenciasLoja", "L"))
        RetornoPendenciaInclusaoIDCliente = tbIDCliente.Text
        RetornoPendenciaInclusaoCliente = tbCliente.Text

        strSql = "UPDATE tblClientes SET "
        strSql += "SaldoCredito=" & Replace(NuloDecimal(Saldo), ",", ".") & " "
        strSql += "WHERE (IDCliente=" & NuloInteger(tbIDCliente.Text) & ")"
        ExecutaStr(strSql)

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub LstClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClientes.SelectedIndexChanged

    End Sub

    Private Sub lstClientes_Click(sender As Object, e As EventArgs) Handles lstClientes.Click
        If lstClientes.SelectedItems.Count > 0 Then

            tbIDCliente.Text = NuloInteger(lstClientes.SelectedItems(0).SubItems(0).Text)
            tbCliente.Text = NuloString(lstClientes.SelectedItems(0).SubItems(1).Text)
            tbSaldoNegativo.Text = NuloBoolean(lstClientes.SelectedItems(0).SubItems(3).Text)
            tbSaldo.Text = NuloDecimal(lstClientes.SelectedItems(0).SubItems(4).Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreencheClientes()
    End Sub
End Class