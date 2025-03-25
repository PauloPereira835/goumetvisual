Imports System.Data.SqlClient

Public Class fdlgDelivery_Areas
    Private Sub PreencheLista()

        strSql = "SELECT Area, TaxaEntrega FROM tblAreas ORDER BY Area"

        Dim con As New SqlConnection(strCon)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Tipos As New ArrayList()
        Dim Texto As String

        If dr.HasRows Then
            While (dr.Read())
                Texto = dr.Item("Area") & "  -  " & Format(dr.Item("TaxaEntrega"), "#0.00") & Space(100) & dr.Item("Area")
                Tipos.Add(Texto)
            End While
            lstAreas.DataSource = Tipos
            lstAreas.SelectedIndex = 0
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

    End Sub
    Private Sub btnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub fdlgDelivery_Areas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheLista()
    End Sub

    Private Sub lstAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAreas.SelectedIndexChanged
        tbArea.Text = Trim(Strings.Right(lstAreas.Text, 8))
        strSql = "SELECT Area, TaxaEntrega FROM tblAreas WHERE Area='" & tbArea.Text & "'"
        tbTaxaEntrega.Text = NuloDecimal(PegaValorCampo("TaxaEntrega", strSql, strCon))

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If tbArea.Text <> "" Then
            strSql = "DELETE From tblAreas WHERE (Area='" & tbArea.Text & "')"
            ExecutaStr(strSql)
            PreencheLista()
            tbArea.Text = ""
            tbTaxaEntrega.Text = ""
        Else
            MsgBox("Mensagem inválida", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnInserir_Click(sender As Object, e As EventArgs) Handles btnInserir.Click

        If tbArea.Text <> "" And tbTaxaEntrega.Text <> "" Then
            If Not IsNumeric(tbTaxaEntrega.Text) Then
                MsgBox("Taxa de Entrega inválida", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim IDSel As String
            Dim ItemSel As Integer = 0
            Dim I As Integer = 0
            Dim NovaFam As String = UCase(tbArea.Text)
            Dim Tx As Decimal = NuloDecimal(tbTaxaEntrega.Text)

            For I = 1 To lstAreas.Items.Count - 1
                lstAreas.SelectedIndex = ItemSel
                IDSel = Trim(Strings.Right(lstAreas.Items(I), 8))
                lstAreas.SelectedIndex = ItemSel
                If IDSel = NovaFam Then
                    I = 9999
                End If
                ItemSel += 1
            Next

            If I < 9999 Then
                Dim strSql As String
                Dim conInsert As New SqlConnection(strCon)

                strSql = "INSERT tblAreas (Area,TaxaEntrega) VALUES ('" & UCase(NovaFam) & "'," & Replace(Tx, ",", ".") & ")"
                ExecutaStr(strSql)
                PreencheLista()
                tbArea.Text = ""
                tbTaxaEntrega.Text = ""
            Else
                MsgBox("Area já cadastrada", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Area inválida", MsgBoxStyle.Information)
        End If
    End Sub
End Class