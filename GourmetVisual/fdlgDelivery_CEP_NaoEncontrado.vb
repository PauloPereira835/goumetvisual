Imports System.Data.SqlClient

Public Class fdlgDelivery_CEP_NaoEncontrado
    Private Sub PreencheRuas()
        Dim QtdItens As Integer = 0
        Dim item As ListViewItem

        lstRuas.Items.Clear()

        strSql = "Select IDRua, Logradouro, Bairro, Cidade, Estado, Area "
        strSql += "From tblRuas "
        If tbBusca.Text <> "" Then
            strSql += "WHERE (tblRuas.Logradouro LIKE '%" & tbBusca.Text & "%') "
        End If
        strSql += "Order By tblRuas.Logradouro"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Ruas")

        For i As Integer = 0 To ds.Tables("Ruas").Rows.Count - 1
            item = lstRuas.Items.Add(ds.Tables("Ruas").Rows(i).Item("IDRua"))
            'item.SubItems.Add(ds.Tables("Ruas").Rows(i).Item("TipoLogradouro"))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Logradouro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Bairro")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Cidade")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Estado")))
            item.SubItems.Add(NuloString(ds.Tables("Ruas").Rows(i).Item("Area")))
            QtdItens += 1
        Next
        dap.Dispose()
        ds.Dispose()
    End Sub
    Private Sub PreencheAreas()
        cbArea.Items.Clear()
        Dim Area As String

        strSql = "Select Area, TaxaEntrega "
        strSql += "From tblAreas "
        strSql += "Order By Area"

        Dim dap = New SqlDataAdapter(strSql, strCon)
        dap.SelectCommand.CommandType = CommandType.Text
        Dim ds As New DataSet()
        dap.Fill(ds, "Areas")
        cbArea.Items.Add("")
        For i As Integer = 0 To ds.Tables("Areas").Rows.Count - 1
            Area = ds.Tables("Areas").Rows(i).Item("Area") & "  -  " & Format(ds.Tables("Areas").Rows(i).Item("TaxaEntrega"), "#0.00") & Space(100) & ds.Tables("Areas").Rows(i).Item("Area")
            cbArea.Items.Add(Area)
        Next
        dap.Dispose()
        ds.Dispose()
    End Sub
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click

        Try

            fdlgDeliveryEnderecoEntrega.tbBuscaRuas.Text = ""

        Catch ex As Exception

        End Try


        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BtnAltera_Click(sender As Object, e As EventArgs) Handles btnAltera.Click
        If lbStatus.Text = "0" Then
            lbDescricao.Text = lbTipoLogradouro.Text & " " & lbLogradouro.Text
            lbStatus.Text = "1"
        Else
            lbDescricao.Text = lbLogradouro.Text & ", " & lbTipoLogradouro.Text
            lbStatus.Text = "0"
        End If
    End Sub

    Private Sub ChkVincular_CheckedChanged(sender As Object, e As EventArgs) Handles chkVincular.CheckedChanged
        If chkVincular.Checked = True Then
            Me.Size = New System.Drawing.Size(700, 520)
            Label.Visible = False
            cbArea.Visible = False
        Else
            Me.Size = New System.Drawing.Size(700, 310)
            Label.Visible = True
            cbArea.Visible = True
        End If
    End Sub

    Private Sub ChkCadastrar_CheckedChanged(sender As Object, e As EventArgs) Handles chkCadastrar.CheckedChanged
        'If chkVincular.Checked = False Then
        'Me.Size = New System.Drawing.Size(700, 615)
        'Else
        'Me.Size = New System.Drawing.Size(700, 310)
        'End If
    End Sub

    Private Sub FdlgDelivery_CEP_NaoEncontrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PreencheRuas()
        PreencheAreas()

        lbDistancia.Text = ""
        If lbCEP.Text <> "" Then
            FixBrowser()
            Dim Distancia As String
            Dim Tempo As String
            Try
                Dim RespKM As System.Collections.Hashtable = CalcKm(CEPLoja, Replace(lbCEP.Text, "-", ""))
                If RespKM.ToString <> "" Then
                    For i = 0 To RespKM.Count - 1
                        If RespKM.Keys(i).ToString = "DISTANCIA" Then
                            Distancia = RespKM.Values(i).ToString
                        End If
                        If RespKM.Keys(i).ToString = "TEMPO" Then
                            Tempo = RespKM.Values(i).ToString
                        End If
                    Next
                    lbDistancia.Text = "Distância: " & Distancia & " / Tempo médio: " & Tempo
                End If
            Catch ex As Exception

            End Try

        End If


    End Sub

    Private Sub TbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        PreencheRuas()
    End Sub

    Private Sub LstRuas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRuas.SelectedIndexChanged
        If lstRuas.SelectedItems.Count > 0 Then
            tbIDRua.Text = NuloInteger(lstRuas.SelectedItems(0).SubItems(0).Text)
        End If
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click


        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If chkVincular.Checked = True Then
            If lstRuas.SelectedItems.Count = 0 Then
                frm.lbMensagem.Text = "É necessário selecionar um logradouro"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            frm.lbMensagem.Text = "Deseja realmente VINCULAR o CEP " & lbCEP.Text & " ao logradouro " & lstRuas.SelectedItems(0).SubItems(1).Text
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub

            strSql = "INSERT tblRuasCep "
            strSql += "(IDRua,CEP) VALUES ("
            strSql += to_sql(NuloInteger(tbIDRua.Text)) & ","
            strSql += to_sql(NuloString(Replace(lbCEP.Text, "-", ""))) & ")"
            ExecutaStr(strSql)

            strSql = "UPDATE tblRuas SET Atualiza=1 WHERE IDRua=" & NuloInteger(tbIDRua.Text)
            ExecutaStr(strSql)


            Me.Dispose()
            Me.Close()
        End If
        If chkCadastrar.Checked = True Then
            If NuloString(cbArea.Text) = "" Then
                frm.lbMensagem.Text = "É necessário selecionar uma área"
                frm.btnNao.Visible = False
                frm.btnSim.Visible = False
                frm.btnOK.Visible = True
                frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
                frm.ShowDialog()
                Exit Sub
            End If

            frm.lbMensagem.Text = "Deseja realmente CADASTRAR este logradouro com este CEP"
            frm.btnNao.Visible = True
            frm.btnSim.Visible = True
            frm.btnOK.Visible = False
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            If RetornoMsg = False Then Exit Sub

            strSql = "INSERT tblRuas "
            strSql += "(Logradouro, Bairro, Cidade, Estado, Area, Atualiza) VALUES ("
            strSql += to_sql(UCase(lbDescricao.Text)) & ","
            strSql += to_sql(UCase(lbBairro.Text)) & ","
            strSql += to_sql(UCase(lbCidade.Text)) & ","
            strSql += to_sql(UCase(lbEstado.Text)) & ","
            strSql += to_sql(NuloString(Trim(Strings.Right(cbArea.Text, 8)))) & ","
            strSql += "1)"
            ExecutaStr(strSql)

            strSql = "INSERT tblRuasCep "
            strSql += "(IDRua,CEP) VALUES ("
            strSql += to_sql(NuloInteger(PegaValorCampo("ID", "Select MAX(IDRua) As ID From tblRuas WITH (TABLOCKX)", strCon))) & ","
            strSql += to_sql(NuloString(Replace(lbCEP.Text, "-", ""))) & ")"
            ExecutaStr(strSql)

            Me.Dispose()
            Me.Close()
        End If

    End Sub
End Class