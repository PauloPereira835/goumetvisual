Imports System.Data.SqlClient

Public Class fdlgBuscaMesaPorCliente
    Private Sub MontaBotoes()

        Dim TotalReg As Integer = 0
        Dim vlrTotal As Decimal = 0
        Me.PanelCat.Controls.Clear()

        strSql = "Select tblVendas.IDVenda, tblVendas.NumMesa, tblVendas.NomeCliente, tblVendas.Excluido, tblVendas.StatusVenda, tblVendas.FlagFechada, SUM(tblVendasMovto.Qtd * tblVendasMovto.VendaServico) As VlrConsumo, tblVendas.DataVenda "
        strSql += "From tblVendas LEFT OUTER Join tblVendasMovto On tblVendas.IDVenda = tblVendasMovto.IDVenda "
        strSql += "Group By tblVendas.IDVenda, tblVendas.NumMesa, tblVendas.NomeCliente, tblVendas.StatusVenda, tblVendas.FlagFechada, tblVendas.Excluido, tblVendas.DataVenda "
        strSql += "HAVING(tblVendas.StatusVenda = 'B' OR  tblVendas.StatusVenda = 'S') AND (tblVendas.NomeCliente <> '') AND (tblVendas.NumMesa <> 0) AND (tblVendas.FlagFechada = 0) AND (tblVendas.Excluido = 0) "
        If NuloString(tbBusca.Text) <> "" Then
            If Not IsNumeric(NuloString(tbBusca.Text)) Then
                strSql += " And (NomeCliente Like '%" & NuloString(tbBusca.Text) & "%') "
            Else
                strSql += "And (NumMesa=" & tbBusca.Text & ") "
            End If
        End If
        If rbNada.Checked = True Then
            strSql += "ORDER BY tblVendas.NomeCliente"
        Else
            If rbConsumo.Checked = True Then
                strSql += "ORDER BY tblVendas.NomeCliente"
            Else
                strSql += "ORDER BY tblVendas.DataVenda, tblVendas.NomeCliente"
            End If
        End If


        Dim dap = New SqlDataAdapter(Strsql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "cli")

        TotalReg = NuloInteger(ds.Tables("cli").Rows.Count)
        Dim myfont As New Font("Sans Serif", 9, FontStyle.Bold)
        Dim btnArray(TotalReg) As System.Windows.Forms.Button
        For i As Integer = 0 To TotalReg
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        For i As Integer = 0 To ds.Tables("cli").Rows.Count - 1
            With (btnArray(i))
                vlrTotal += NuloDecimal(ds.Tables("cli").Rows(i).Item("VlrConsumo"))
                .Tag = NuloInteger(ds.Tables("cli").Rows(i).Item("IDVenda"))
                If rbNada.Checked = True Then
                    .Text = NuloString(ds.Tables("cli").Rows(i).Item("NomeCliente"))
                Else
                    If rbConsumo.Checked = True Then
                        .Text = NuloString(ds.Tables("cli").Rows(i).Item("NomeCliente")) & " (" & Format(NuloDecimal(ds.Tables("cli").Rows(i).Item("VlrConsumo")), "#0.00") & ")"
                    Else
                        .Text = NuloString(ds.Tables("cli").Rows(i).Item("NomeCliente")) & " (" & Format(ds.Tables("cli").Rows(i).Item("DataVenda"), "dd/MM/yyyy") & ")"
                    End If
                End If
                .Width = 139
                .Height = 55
                .BackColor = Color.Gray
                .ForeColor = Color.Lime
                .FlatStyle = FlatStyle.Standard
                .Font = myfont

                Me.PanelCat.Controls.Add(btnArray(i))

                AddHandler .Click, AddressOf Me.ClickButton_cliente

            End With
        Next
        lbQtde.Text = NuloInteger(TotalReg)
        lbConsumoTotal.Text = Format(NuloDecimal(vlrTotal), "#0.00")
    End Sub
    Private Sub ClickButton_cliente(ByVal sender As Object, ByVal e As System.EventArgs)

        With CType(sender, Button)
            If .BackColor = Color.Gray Then
                .BackColor = Color.LawnGreen
                .ForeColor = Color.Gray
                tbIDVenda.Text = NuloInteger(.Tag)


                If NuloInteger(tbIDVenda.Text) <> 0 Then
                    IDVenda = NuloInteger(tbIDVenda.Text)
                    frmSalao.tbMesa.Text = NuloInteger(PegaValorCampo("NumMesa", "SELECT IDVenda, NumMesa FROM tblVendas WHERE IDVenda=" & NuloInteger(tbIDVenda.Text), strCon))

                    Me.Dispose()
                    Me.Close()
                End If
            End If
        End With

    End Sub

    Private Sub FdlgBuscaMesaPorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbNada.Checked = True
        MontaBotoes()
        tbBusca.Focus()

    End Sub

    Private Sub fdlgBuscaMesaPorCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode

            Case Keys.KeyCode.Escape
                IDVenda = 0
                Me.Dispose()
                Me.Close()

        End Select
    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged

        MontaBotoes()
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub RbNada_CheckedChanged(sender As Object, e As EventArgs) Handles rbNada.CheckedChanged
        MontaBotoes()
        lbConsumoTotal.Visible = False
    End Sub

    Private Sub RbConsumo_CheckedChanged(sender As Object, e As EventArgs) Handles rbConsumo.CheckedChanged
        MontaBotoes()
        lbConsumoTotal.Visible = True
    End Sub

    Private Sub RbData_CheckedChanged(sender As Object, e As EventArgs) Handles rbData.CheckedChanged
        MontaBotoes()
        lbConsumoTotal.Visible = False
    End Sub
End Class