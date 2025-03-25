Imports System.Data.SqlClient

Public Class fdlgDelivery_AreaEntrega_Entrega
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
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgDelivery_AreaEntrega_Entrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheLista()
        lbBairro.Text = NuloString(frmDelivery.tbBairroEntrega.Text)
        lbEndereco.Text = NuloString(frmDelivery.tbLogradouroEntrega.Text) & ", " & NuloString(frmDelivery.tbNumeroEntrega.Text)
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        frmDelivery.tbAreaEntrega.Text = NuloString(Trim(Strings.Right(lstAreas.Text, 20)))
        Me.Dispose()
        Me.Close()
    End Sub
End Class