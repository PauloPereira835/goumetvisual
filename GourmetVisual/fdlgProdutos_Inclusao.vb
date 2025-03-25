Imports System.Data.SqlClient

Public Class fdlgProdutos_Inclusao
    Dim CampoProduto As String = ""
    Function AchaGrupo_Nome(NomeGrupo As String)
        Dim strSql As String
        Dim Dados As Integer = 0
        Dim con As New SqlConnection(strConServer)

        strSql = "Select tblGrupos.CodigoGrupo, tblGrupos.Grupo, tblGruposLojas.IDLoja "
        strSql += "From tblGrupos INNER Join tblGruposLojas On tblGrupos.IDGrupo = tblGruposLojas.IDGrupo "
        strSql += "WHERE (Grupo='" & NomeGrupo & "') AND (IDLoja=" & IDLoja & ")"

        con.Open()
        Dim comando As New SqlCommand(strSql, con)
        comando.CommandType = CommandType.Text

        Dim dr As SqlDataReader = comando.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            Dados = dr.GetInt32(0)
        End If
        dr.Close()
        con.Dispose()
        con.Close()

        Return Dados

    End Function
    Function AchaAliquota(IDAliq As Integer)

        Dim Dados(1) As String

        strSql = "SELECT IDAliquota, DescricaoAliquota, Aliquota FROM tblAliquotas WHERE(IDAliquota = " & IDAliq & ")"

        Dim con As New SqlConnection(strConServer)

        con.Open()
        Dim comando As New SqlCommand(strSql, con)
        comando.CommandType = CommandType.Text

        Dim drLinha As SqlDataReader = comando.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        With drLinha
            If .HasRows Then
                .Read()
                Dados(0) = .GetDecimal(2)
                Dados(1) = .GetInt32(0)
            Else
                Dados(0) = 0
                Dados(1) = 0
            End If
            .Close()
        End With
        con.Dispose()
        con.Close()


        Return Dados

    End Function
    Private Sub EncontraCodigoDisponivel(IDLj As Integer)

        Dim CodPro As Integer = 1
        Dim CodProuto As Integer

        strSql = "SELECT tblProdutosLojas.CodigoProduto, tblProdutos.Produto, tblProdutos.Tipo, tblProdutosLojas.IDProduto, tblProdutosLojas.IDLoja "
        strSql += "From tblProdutosLojas INNER Join tblProdutos On tblProdutosLojas.IDProduto = tblProdutos.IDProduto "
        strSql += "Where (tblProdutosLojas.CodigoProduto Is Not NULL) And (tblProdutosLojas.IDLoja=" & IDLj & ") "
        strSql += "Order By tblProdutosLojas.CodigoProduto"

        Dim con As New SqlConnection(strConServer)
        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text

        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If dr.HasRows Then
            While dr.Read()
                If Not IsDBNull(dr.Item("CodigoProduto")) Then
                    CodProuto = dr.Item("CodigoProduto")
                    If CodPro <> CodProuto Then
                        Exit While
                    End If
                    CodPro += 1
                End If
            End While
        End If
        dr.Close()
        cmd.Dispose()
        con.Dispose()
        con.Close()

        If MsgBox("Proximo código dispónivel na loja  " & CodPro & "   Deseja utiliza-lo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            tbCodigoProduto.Text = CodPro
        End If


    End Sub
    Private Sub PreencheCB()

        ' CATEGORIAS  /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Select Categoria FROM tblCategorias ORDER BY Categoria"
        Dim con As New SqlConnection(strConServer)
        con.Open()
        Dim comandoCat As New SqlCommand(strSql, con)
        comandoCat.CommandType = CommandType.Text

        Dim drLinha As SqlDataReader = comandoCat.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim Tipos As New ArrayList()
        With drLinha
            If .HasRows Then
                Tipos.Add("")
                While (.Read())
                    Tipos.Add(.GetString(0))
                End While

            End If
            cbCategoria.DataSource = Tipos
            'cbCategoria.SelectedIndex = 0
            .Close()
        End With
        con.Close()



        ' ALIQUOTAS  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Dim texto As String
        strSql = "Select IDAliquota, DescricaoAliquota, Aliquota FROM tblAliquotas ORDER BY Aliquota"
        con.Open()
        Dim comandoAL As New SqlCommand(strSql, con)
        comandoAL.CommandType = CommandType.Text

        Dim drAL As SqlDataReader = comandoAL.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim TpAL As New ArrayList()
        With drAL
            If .HasRows Then
                TpAL.Add("")
                While (.Read())
                    If Len(.GetString(1)) = 1 Then
                        texto = " " & .GetString(1)
                    Else
                        texto = .GetString(1)
                    End If
                    texto = texto & "   -   "
                    If Len(.GetDecimal(2)) <= 12 Then
                        texto = texto & Space(12 - Len(.GetDecimal(2))) & .GetDecimal(2) & Space(100) & .GetInt32(0)
                    End If
                    TpAL.Add(texto)

                End While

            End If
            lstAliquotas.DataSource = TpAL
            'cbFamilia.SelectedIndex = 0
            .Close()
        End With
        comandoAL.Dispose()
        con.Close()


        Dim IDSel As Decimal
        Dim ItemSel As Integer = 0
        For I = 1 To lstAliquotas.Items.Count
            lstAliquotas.SelectedIndex = ItemSel
            IDSel = NuloDecimal(Strings.Left(lstAliquotas.Text, 10))
            lstAliquotas.SelectedIndex = ItemSel
            If IDSel = NuloDecimal(Aliquota_Servico) Then
                I = 9999
            End If
            ItemSel += 1
        Next







        ' GRUPOS  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        strSql = "Select tblGrupos.Grupo, tblGrupos.CodigoGrupo, tblGruposLojas.IDLoja, tblGrupos.IDGrupo "
        strSql += "From tblGrupos INNER Join tblGruposLojas On tblGrupos.IDGrupo = tblGruposLojas.IDGrupo "
        strSql += "Where (tblGruposLojas.IDLoja=" & IDLoja & ") "
        strSql += "Order By tblGrupos.Grupo"

        con.Open()
        Dim comandoGR As New SqlCommand(strSql, con)
        comandoGR.CommandType = CommandType.Text

        Dim drGR As SqlDataReader = comandoGR.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        Dim TpGR As New ArrayList()

        If drGR.HasRows Then
            TpGR.Add("" & Space(100) & "0")
            While (drGR.Read())
                'If IsDBNull(drGR(1)) Then
                'TpGR.Add(drGR.GetString(0) & Space(100) & "0")
                'Else
                TpGR.Add(drGR.Item("Grupo") & Space(100) & drGR.Item("CodigoGrupo"))
                'End If
            End While
        End If
        cbGrupo.DataSource = TpGR
        drGR.Close()
        comandoGR.Dispose()
        con.Close()


    End Sub
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FdlgProdutos_Inclusao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreencheCB()
    End Sub

    Private Sub TbProduto_TextChanged(sender As Object, e As EventArgs) Handles tbProduto.TextChanged

    End Sub

    Private Sub tbProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbProduto.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCodigoProduto.Focus()
        End If
    End Sub

    Private Sub tbProduto_LostFocus(sender As Object, e As EventArgs) Handles tbProduto.LostFocus
        tbProduto.Text = VerificaTexto(tbProduto.Text)
    End Sub

    Private Sub TbCodigoProduto_TextChanged(sender As Object, e As EventArgs) Handles tbCodigoProduto.TextChanged

    End Sub

    Private Sub tbCodigoProduto_LostFocus(sender As Object, e As EventArgs) Handles tbCodigoProduto.LostFocus
        If tbCodigoProduto.Text = CampoProduto Then Exit Sub

        Dim strSql As String
        Dim con As New SqlConnection(strConServer)

        strSql = "Select tblProdutos.IDProduto, tblProdutos.Produto, tblProdutos.CodigoGrupo, tblProdutosLojas.CodigoProduto, tblProdutosLojas.IDLoja "
        strSql += "From tblProdutos INNER Join tblProdutosLojas On tblProdutos.IDProduto = tblProdutosLojas.IDProduto "
        strSql += "Where (tblProdutosLojas.CodigoProduto=" & tbCodigoProduto.Text & ") And (tblProdutosLojas.IDLoja=" & IDLoja & ") "
        strSql += "Order By tblProdutosLojas.CodigoProduto"

        con.Open()
        Dim cmd As New SqlCommand(strSql, con)
        cmd.CommandType = CommandType.Text
        Dim drLJS As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)

        If drLJS.HasRows Then
            drLJS.Read()
            MsgBox("Código já utilizado no produto " & drLJS.Item("Produto") & vbCrLf & "Não será possível utiliza-lo", MsgBoxStyle.Information)
            tbCodigoProduto.Text = CampoProduto
        End If
        cmd.Dispose()
        con.Dispose()
        con.Close()
    End Sub

    Private Sub tbCodigoProduto_GotFocus(sender As Object, e As EventArgs) Handles tbCodigoProduto.GotFocus
        CampoProduto = tbCodigoProduto.Text
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        EncontraCodigoDisponivel(IDLoja)
    End Sub

    Private Sub CbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrupo.SelectedIndexChanged

    End Sub

    Private Sub cbGrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbGrupo.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbNCM.Focus()
        End If
    End Sub

    Private Sub TbNCM_TextChanged(sender As Object, e As EventArgs) Handles tbNCM.TextChanged

    End Sub

    Private Sub tbNCM_LostFocus(sender As Object, e As EventArgs) Handles tbNCM.LostFocus

        If tbNCM.Text = "" Then Exit Sub
        strSql = "SELECT CodigoNCM FROM tblTabelaNCM WHERE (CodigoNCM = '" & tbNCM.Text & "')"

        Dim con As New SqlConnection(strConServer)

        Try

            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If Not dr.HasRows Then
                MsgBox("Código NCM não encontrado", MsgBoxStyle.Information, "Aviso")
                tbNCM.Text = ""
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub TbDescricaoResumida_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub tbDescricaoResumida_KeyPress(sender As Object, e As KeyPressEventArgs)
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            cbCategoria.Focus()
        End If
    End Sub

    Private Sub CbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoria.SelectedIndexChanged

    End Sub

    Private Sub cbkServico_KeyPress(sender As Object, e As KeyPressEventArgs)
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbVenda.Focus()
        End If
    End Sub

    Private Sub TbVenda_TextChanged(sender As Object, e As EventArgs) Handles tbVenda.TextChanged

    End Sub

    Private Sub tbVenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbVenda.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            lstAliquotas.Focus()
        End If
    End Sub

    Private Sub LstAliquotas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAliquotas.SelectedIndexChanged

    End Sub

    Private Sub lstAliquotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lstAliquotas.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCST_ICMS.Focus()
        End If
    End Sub

    Private Sub TbCST_ICMS_TextChanged(sender As Object, e As EventArgs) Handles tbCST_ICMS.TextChanged

    End Sub

    Private Sub tbCST_ICMS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCST_ICMS.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCST_PIS.Focus()
        End If
    End Sub

    Private Sub TbCST_PIS_TextChanged(sender As Object, e As EventArgs) Handles tbCST_PIS.TextChanged

    End Sub

    Private Sub tbCST_PIS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCST_PIS.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCST_COFINS.Focus()
        End If
    End Sub

    Private Sub TbCST_COFINS_TextChanged(sender As Object, e As EventArgs) Handles tbCST_COFINS.TextChanged

    End Sub

    Private Sub tbCST_COFINS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCST_COFINS.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbCFOP.Focus()
        End If
    End Sub

    Private Sub TbCFOP_TextChanged(sender As Object, e As EventArgs) Handles tbCFOP.TextChanged

    End Sub

    Private Sub tbCFOP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCFOP.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            tbProduto.Focus()
        End If
    End Sub

    Private Sub tbCST_ICMS_LostFocus(sender As Object, e As EventArgs) Handles tbCST_ICMS.LostFocus

        If NuloString(tbCST_ICMS.Text) = "" Then Exit Sub

        strSql = "Select CodigoCST_ICMS, Tipo From tblTabelaCST_ICMS  WHERE CodigoCST_ICMS=" & tbCST_ICMS.Text & " ORDER BY CodigoCST_ICMS"
        Dim con As New SqlConnection(strConServer)

        Try

            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If Not dr.HasRows Then
                MsgBox("Código CST_ICMS não encontrado", MsgBoxStyle.Information, "Aviso")
                tbCST_ICMS.Text = ""
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub tbCST_PIS_LostFocus(sender As Object, e As EventArgs) Handles tbCST_PIS.LostFocus

        If NuloString(tbCST_PIS.Text) = "" Then Exit Sub

        strSql = "SELECT CodigoCST_PIS FROM tblTabelaCST_PIS WHERE (CodigoCST_PIS = '" & tbCST_PIS.Text & "')"

        Dim con As New SqlConnection(strConServer)

        Try

            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If Not dr.HasRows Then
                MsgBox("Código CST_PIS não encontrado", MsgBoxStyle.Information, "Aviso")
                tbCST_PIS.Text = ""
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub tbCST_COFINS_LostFocus(sender As Object, e As EventArgs) Handles tbCST_COFINS.LostFocus

        If NuloString(tbCST_COFINS.Text) = "" Then Exit Sub

        strSql = "SELECT CodigoCST_COFINS FROM tblTabelaCST_COFINS WHERE (CodigoCST_COFINS = '" & tbCST_COFINS.Text & "')"

        Dim con As New SqlConnection(strConServer)

        Try

            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If Not dr.HasRows Then
                MsgBox("Código CST_COFINS não encontrado", MsgBoxStyle.Information, "Aviso")
                tbCST_COFINS.Text = ""
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub tbCFOP_LostFocus(sender As Object, e As EventArgs) Handles tbCFOP.LostFocus

        If NuloString(tbCFOP.Text) = "" Then Exit Sub

        strSql = "SELECT CodigoCFOP FROM tblTabelaCFOP WHERE (CodigoCFOP = '" & tbCFOP.Text & "')"

        Dim con As New SqlConnection(strConServer)

        Try

            con.Open()
            Dim cmd As New SqlCommand(strSql, con)
            cmd.CommandType = CommandType.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
            If Not dr.HasRows Then
                MsgBox("Código CFOP não encontrado", MsgBoxStyle.Information, "Aviso")
                tbCFOP.Text = ""
            End If
            cmd.Dispose()
            dr.Close()
            con.Dispose()
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click

        Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        If NuloString(tbProduto.Text) = "" Then
            frm.lbMensagem.Text = "Descrição do produto inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbCodigoProduto.Text) = "" Then
            frm.lbMensagem.Text = "Código do produto inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(cbGrupo.Text) = "" Then
            frm.lbMensagem.Text = "Grupo do produto inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbNCM.Text) = "" Then
            frm.lbMensagem.Text = "Código NCM do produto inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(cbCategoria.Text) = "" Then
            frm.lbMensagem.Text = "Categoria do produto inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbVenda.Text) = "" Then
            frm.lbMensagem.Text = "Venda do produto inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(lstAliquotas.Text) = "" Then
            frm.lbMensagem.Text = "Aliquota de ICMS do produto inválida"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbCST_ICMS.Text) = "" Then
            frm.lbMensagem.Text = "CST do ICMS inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbCST_PIS.Text) = "" Then
            frm.lbMensagem.Text = "CST do PIS inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbCST_COFINS.Text) = "" Then
            frm.lbMensagem.Text = "CST do COFINS inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If
        If NuloString(tbCFOP.Text) = "" Then
            frm.lbMensagem.Text = "CFOP inválido"
            frm.btnNao.Visible = False
            frm.btnSim.Visible = False
            frm.btnOK.Visible = True
            frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
            frm.ShowDialog()
            Exit Sub
        End If

        frm.lbMensagem.Text = "Confirma a inclusão deste produto" & vbCrLf & tbProduto.Text
        frm.btnNao.Visible = True
        frm.btnSim.Visible = True
        frm.btnOK.Visible = False
        frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.interrogacao
        frm.ShowDialog()
        If RetornoMsg = False Then Exit Sub

        strSql = "INSERT tblProdutos (Produto, Tipo, Custo, Unidade, IDConta, CodigoNCM, Pizza, CodigoCest) VALUES ("
        strSql += "'" & tbProduto.Text & "', "
        strSql += "'V', 0, '',0 , "
        strSql += "'" & tbNCM.Text & "', "
        strSql += "'', '')"
        ExecutaStrServidor(strSql)

        Dim IDprod As Integer = NuloInteger(PegaID("IDProduto", "tblProdutos", "S"))

        Dim Ali(1) As String
        Ali = AchaAliquota(Val(Strings.Right(lstAliquotas.Text, 6)))
        Dim IDGrupo As Integer = AchaGrupo_Nome(Trim(Strings.Left(cbGrupo.Text, 50)))

        strSql = "INSERT tblProdutosLojas (IDLoja, EstoqueAtual, IDProduto, InformaVenda, CST_COFINS, pPIS, pCOFINS, CST_ICMS, CST_PIS, CFOP, Categoria, ImprimeCategoria, ComServico, Pesavel, [Top], Modulos, IDFamilia, Tara, Venda, "
        strSql += "EstoqueMinimo, ForaLinha, BaixaEstoque, Fator, IDAliquota, CodigoProduto, CodigoGrupo, DescricaoResumida, IDFichaTecnica, Custo, EstoqueInicial, CustoCMV, Obs, CategoriaDelivery) VALUES ("
        strSql += IDLoja & ", "
        strSql += "0 , "
        strSql += IDprod & ", "
        strSql += "0, "
        strSql += "'" & tbCST_COFINS.Text & "', "
        strSql += "0, 0, "
        strSql += "'" & tbCST_ICMS.Text & "', "
        strSql += "'" & tbCST_PIS.Text & "', "
        strSql += "'" & tbCFOP.Text & "', "
        strSql += "'" & cbCategoria.Text & "', "
        strSql += "1, "
        strSql += "1, "
        strSql += "0, 0,'T',0 ,0,  "
        strSql += Replace(NuloDecimal(tbVenda.Text), ",", ".") & ", "
        strSql += "0, 0, 0, 1, "
        strSql += Ali(1) & ", "
        strSql += tbCodigoProduto.Text & ", "
        strSql += IDGrupo & ", "
        strSql += "'" & Strings.Left(tbProduto.Text, 15) & "', "
        strSql += "0, 0, 0 ,0,'','FORNO')"
        ExecutaStrServidor(strSql)

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub tbCodigoProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodigoProduto.KeyPress
        If AscW(e.KeyChar) = 13 Then
            e.Handled = True
            cbGrupo.Focus()
        End If
    End Sub
End Class