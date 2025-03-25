Imports System.Data.SqlClient

Public Class fdlgNovaVenda_Clube
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        If NuloString(tbNomeCliente.Text) <> "" Then
            Dim con As New SqlConnection()
            Dim dr As SqlDataReader
            con.ConnectionString = strCon
            Dim cmd As SqlCommand = con.CreateCommand

            SqlStr = "Select NomeCliente, FlagFechada, Excluido "
            SqlStr += "From tblVendas "
            SqlStr += "Where (FlagFechada = 0) And (Excluido = 0) And (NomeCliente = '" & Strings.Left(UCase(NuloString(tbNomeCliente.Text)), 40) & "')"

            cmd.CommandText = SqlStr
            con.Open()
            dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If dr.HasRows Then
                Dim frm As fdlgMensagemBox = New fdlgMensagemBox
                frm.lbMensagem.Text = "Já existe um cliente com esse nome"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                tbNomeCliente.Focus()
            Else
                AbreVendaBalcao()
                IDVenda = PegaID("IDVenda", "tblVendas", "L")

                strSql = "UPDATE tblVendas SET NomeCliente = '" & Strings.Left(UCase(NuloString(tbNomeCliente.Text)), 40) & "' WHERE IDVenda = " & IDVenda
                ExecutaStr(strSql)

                Me.Dispose()
                Me.Close()

                Dim frm As fdlgAbreVenda_Clube = New fdlgAbreVenda_Clube
                frm.tbIDVenda.Text = IDVenda
                frm.ShowDialog()

            End If
            cmd.Dispose()
            dr.Close()
            con.Close()
            con.Dispose()
        Else
            AbreVendaBalcao()
            IDVenda = PegaID("IDVenda", "tblVendas", "L")

            Me.Dispose()
            Me.Close()

            Dim frm As fdlgAbreVenda_Clube = New fdlgAbreVenda_Clube
            frm.tbIDVenda.Text = IDVenda
            frm.ShowDialog()
        End If

    End Sub

    Private Sub tbNomeCliente_TextChanged(sender As Object, e As EventArgs) Handles tbNomeCliente.TextChanged

    End Sub

    Private Sub tbNomeCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNomeCliente.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            btnConfirma.Focus()
        End If
    End Sub
End Class