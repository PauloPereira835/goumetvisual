Imports System.Data.SqlClient

Public Class fdlgBuscaRuas
    Private Sub ConfirmaRua()
        If GridRuas.Rows.Count > 0 Then
            NomeIDRua = NuloInteger(GridRuas.Item(0, GridRuas.CurrentRow.Index).Value)
            NomeLogradouro = GridRuas.Item(1, GridRuas.CurrentRow.Index).Value
            NomeBairro = NuloString(GridRuas.Item(2, GridRuas.CurrentRow.Index).Value)
            NomeCEP = NuloString(GridRuas.Item(3, GridRuas.CurrentRow.Index).Value)
            NomeArea = NuloString(GridRuas.Item(4, GridRuas.CurrentRow.Index).Value)
            NomeTaxaEntrega = Format(NuloDecimal(GridRuas.Item(5, GridRuas.CurrentRow.Index).Value), "#0.00")
        End If
    End Sub
    Private Sub PreencheRuas()

        Dim TxEntrega As Decimal
        Dim con As New SqlConnection()
        Dim dr As SqlDataReader
        con.ConnectionString = strCon
        Dim cmd As SqlCommand = con.CreateCommand

        GridRuas.Rows.Clear()

        SqlStr = "Select tblRuas.IDRua, tblRuas.Logradouro, tblRuas.Bairro, tblRuas.Area, tblRuasCep.CEP, tblAreas.TaxaEntrega "
        SqlStr += "From tblRuas LEFT OUTER Join tblAreas On tblRuas.Area = tblAreas.Area LEFT OUTER Join tblRuasCep On tblRuas.IDRua = tblRuasCep.IDRua "
        If Not IsNumeric(tbBuscaRua.Text) Then
            SqlStr += "Where (tblRuas.Logradouro Like '%" & tbBuscaRua.Text & "%') "
        Else
            SqlStr += "Where (tblRuasCep.CEP Like '%" & tbBuscaRua.Text & "') "
        End If
        SqlStr += "ORDER BY tblRuas.Logradouro, tblRuasCep.CEP"
        cmd.CommandText = SqlStr
        con.Open()
        dr = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While (dr.Read())
                TxEntrega = NuloDecimal(dr.Item("TaxaEntrega"))
                GridRuas.Rows.Add({NuloInteger(dr.Item("IDRua")), NuloString(dr.Item("Logradouro")), NuloString(dr.Item("Bairro")), NuloString(dr.Item("CEP")), NuloString(dr.Item("Area")), Format(TxEntrega, "#0.00")})
            End While
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        con.Dispose()

    End Sub
    Private Sub fdlgBuscaRuas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheRuas()
    End Sub

    Private Sub fdlgBuscaRuas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.KeyCode.Escape
                Me.Dispose()
                Me.Close()

        End Select
    End Sub
    Private Sub tbBuscaRua_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaRua.TextChanged
        PreencheRuas()
    End Sub
    Private Sub tbBuscaRua_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBuscaRua.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            GridRuas.Focus()
        End If
    End Sub

    Private Sub GridRuas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridRuas.CellContentClick

    End Sub

    Private Sub GridRuas_DoubleClick(sender As Object, e As EventArgs) Handles GridRuas.DoubleClick
        ConfirmaRua()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub GridRuas_Enter(sender As Object, e As EventArgs) Handles GridRuas.Enter
        'ConfirmaRua()
    End Sub

    Private Sub btnCadastroRuas_Click(sender As Object, e As EventArgs) Handles btnCadastroRuas.Click

        Dim Rua As String = NuloString(tbBuscaRua.Text)

        'Dim frm As fdlgConsultaCEP = New fdlgConsultaCEP
        'frm.tbLogradouro.Text = tbBuscaRua.Text
        'frm.ShowDialog()

        Dim frm1 As fdlgDelivery_Ruas = New fdlgDelivery_Ruas
        frm1.tbBusca.Text = Rua
        frm1.tbOrigem.Text = "C"
        'frm1.btnExcluir.Enabled = False
        'frm1.btnInserir.Enabled = False
        'frm1.btnConsultaRua.Visible = False
        'frm1.tbBusca.ReadOnly = True
        'frm1.lbMensagem.Visible = True
        frm1.ShowDialog()

        PreencheRuas()
        GridRuas.Focus()


    End Sub

    Private Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub GridRuas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridRuas.KeyPress
        If AscW(e.KeyChar) = 13 Then
            ConfirmaRua()
            Me.Dispose()
            Me.Close()
        End If

    End Sub
End Class