Imports System.Data.SqlClient

Public Class frmClube
    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frmClube_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If NuloInteger(IDFechamento) = 0 Then
            Dim frm1 As fdlgMensagemBox = New fdlgMensagemBox
            frm1.lbMensagem.Text = "Caixa não aberto. Será necessário abrir"
            frm1.btnNao.Visible = False
            frm1.btnSim.Visible = False
            frm1.btnOK.Visible = True
            frm1.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm1.ShowDialog()
            Me.Dispose()
            Me.Close()
        End If

        Timer.Enabled = True
        Timer.Start()

        lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)
        lbDataMovimento.Text = DiaMovto
        lbOparedor.Text = Operador
        lbCaixa.Text = Caixa
        lbTerminal.Text = NomeTerminal

        ContadorClube = 0

        MontaClientes()

    End Sub
    Public Sub MontaClientes()

        Dim n As Integer = 0

        strSql = "Select IDVenda, NumVenda, NomeCliente, DataVenda "
        strSql += "From tblVendas "
        strSql += "WHERE (NomeCliente Like '" & tbBusca.Text & "%') AND (FlagFechada=0) "
        strSql += "Order By NomeCliente"

        Dim con As New SqlConnection()
        Dim dr As SqlDataReader

        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand
        cmd.CommandText = strSql

        'Try
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        Dim myfont As New Font("Sans Serif", 9, FontStyle.Regular)
        Dim btnArray(400) As System.Windows.Forms.Button
        For i As Integer = 0 To 400
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        Me.PainelProdutos.Controls.Clear()

        If dr.HasRows Then
            While (dr.Read())
                With (btnArray(n))
                    .Tag = NuloInteger(dr(0))
                    .Text = NuloString(dr(2))
                    .ForeColor = Color.Blue
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Width = 160
                    .Height = 50
                    .BackColor = Color.Beige
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderSize = 1
                    .Font = myfont

                    Me.PainelProdutos.Controls.Add(btnArray(n))

                    AddHandler .Click, AddressOf Me.ClickButton_Clientes
                    n += 1
                End With
            End While
        End If
        con.Close()
        con.Dispose()

    End Sub
    Private Sub ClickButton_Clientes(ByVal sender As Object, ByVal e As System.EventArgs)
        With CType(sender, Button)

            Dim frm As fdlgAbreVenda_Clube = New fdlgAbreVenda_Clube
            frm.tbIDVenda.Text = .Tag
            frm.ShowDialog()
            MontaClientes()

        End With
    End Sub
    Private Sub btnAbreVenda_Click(sender As Object, e As EventArgs) Handles btnAbreVenda.Click

        fdlgNovaVenda_Clube.ShowDialog()
        MontaClientes()

    End Sub

    Private Sub tbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        MontaClientes()
    End Sub

    Private Sub btnAgrupamento_Click(sender As Object, e As EventArgs) Handles btnAgrupamento.Click

        fdlgAgrupamento_Clube.ShowDialog()
        MontaClientes()

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick

        lbData_Hora.Text = FormatDateTime(Now, DateFormat.ShortDate) & " - " & FormatDateTime(Now, DateFormat.ShortTime)

        ContadorClube += 1
        If ContadorClube > 29 Then
            MontaClientes()
            ContadorClube = 0
        End If
    End Sub

    Private Sub tbBusca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBusca.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            PainelProdutos.Focus()
        End If
    End Sub
End Class