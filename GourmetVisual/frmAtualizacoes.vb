Imports System.Data.SqlClient

Public Class frmAtualizacoes
    Private Sub BtnVolta_Click(sender As Object, e As EventArgs) Handles btnVolta.Click

        lbAguarde.Visible = True
        lbAguarde.Refresh()

        frmInicio.AtualizaTabela("Categorias")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Categorias') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Comentarios")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Comentarios') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Combos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Combos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Familias")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Familias') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("FormaPagtos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='FormaPagtos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Funcionarios")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Funcionarios') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Grupos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Grupos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Produtos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Produtos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)


        frmInicio.Atualiza_Tablet()


        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub LinhaGridProdutos()
        Dim TotalLinhas As Integer = lstAtualizacoes.Items.Count

        If TotalLinhas = 0 Then Exit Sub

        Dim Status As String
        Dim fontBold As New Font("Courier New", 14, FontStyle.Bold)
        Dim fontRegular As New Font("Sans Serif", 8, FontStyle.Regular)
        Dim fontItalic As New Font("Sans Serif", 8, FontStyle.Italic)

        With lstAtualizacoes
            If TotalLinhas <> 0 Then
                For i As Integer = 0 To TotalLinhas - 1
                    Status = NuloString(.Items(i).Text)
                    If Strings.Left(Status, 6) = "Versão" Then
                        .Items(i).Font = fontBold
                    End If

                Next i
            End If

        End With
    End Sub
    Private Sub FrmAtualizacoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If NuloString(tbOrigem.Text) <> "" Then
            btnNaoMostrar.Visible = False
        End If

        Dim conIRIS As New SqlConnection(strConIRIS)
        Dim IDver As Integer
        Dim QtdDesc As Integer
        Dim Versao As String
        Dim DataAt As String
        Dim Descricao As String
        Dim item As ListViewItem

        strSql = "Select tblAtualizacaoGourmetVisual.ID As IDVersao, tblAtualizacaoGourmetVisual_Descricao.IDDescricao, tblAtualizacaoGourmetVisual.Versao, tblAtualizacaoGourmetVisual_Descricao.Descricao, tblAtualizacaoGourmetVisual.Data "
        strSql += "From tblAtualizacaoGourmetVisual INNER Join tblAtualizacaoGourmetVisual_Descricao On tblAtualizacaoGourmetVisual.ID = tblAtualizacaoGourmetVisual_Descricao.ID "
        strSql += "Order By tblAtualizacaoGourmetVisual.ID DESC, tblAtualizacaoGourmetVisual_Descricao.IDDescricao"

        'Try
        conIRIS.Open()
        Dim cmdIRIS As New SqlCommand(strSql, conIRIS)
        cmdIRIS.CommandType = CommandType.Text

        lstAtualizacoes.Items.Clear()

        Dim drIRIS As SqlDataReader = cmdIRIS.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.CloseConnection)
        If drIRIS.HasRows Then
            'drIRIS.Read()
            Versao = ""
            While (drIRIS.Read())
                If Versao = "" Then
                    IDver = NuloInteger(drIRIS.Item("IDVersao"))
                    Versao = NuloString(drIRIS.Item("Versao"))
                    DataAt = NuloString(Format(drIRIS.Item("Data"), "dd/MM/yyyy"))
                    item = lstAtualizacoes.Items.Add("Versão:  " & Versao & "  (" & DataAt & ")")
                End If

                If IDver < NuloInteger(drIRIS.Item("IDVersao")) And NuloString(tbOrigem.Text) = "" Then
                    Exit While
                Else
                    If Versao <> NuloString(drIRIS.Item("Versao")) Then
                        IDver = NuloInteger(drIRIS.Item("IDVersao"))
                        Versao = NuloString(drIRIS.Item("Versao"))
                        item = lstAtualizacoes.Items.Add(" ")
                        DataAt = NuloString(Format(drIRIS.Item("Data"), "dd/MM/yyyy"))
                        item = lstAtualizacoes.Items.Add("Versão:  " & Versao & "  (" & DataAt & ")")
                    End If
                End If

                Descricao = NuloString(drIRIS.Item("Descricao"))
                QtdDesc = Len(Descricao)
                If QtdDesc > 65 Then
                    '     Dim palavras As String()
                    '    Dim palavra As String
                    '   Dim lastNonEmpty As Integer = -1
                    While QtdDesc > 65
                        'palavras = Trim(Mid(Descricao, 1, 64)).Split(New Char() {" "c})

                        'For i As Integer = 0 To palavras.Length - 1
                        ''If palavras(i) <> "" Then
                        ''lastNonEmpty += 1
                        ''palavras(lastNonEmpty) = palavras(i)
                        ''end If
                        'palavra = palavras(i)
                        'Next


                        item = lstAtualizacoes.Items.Add(Trim(Mid(Descricao, 1, 64)))
                        Descricao = Mid(Descricao, 65, Len(Descricao) - 64)
                        QtdDesc = Len(Descricao)

                    End While
                    item = lstAtualizacoes.Items.Add(Trim(Strings.Right(NuloString(drIRIS.Item("Descricao")), QtdDesc)))
                Else
                    item = lstAtualizacoes.Items.Add(Descricao)
                End If
                item = lstAtualizacoes.Items.Add(" ")
            End While
        End If

        lstAtualizacoes.Update()
        lstAtualizacoes.EndUpdate()
        lstAtualizacoes.Refresh()

        cmdIRIS.Dispose()
        drIRIS.Close()

        'Catch ex As Exception
        'Dim frm As fdlgMensagemBox = New fdlgMensagemBox
        'frm.lbMensagem.Text = "Sem conexão com IRIS Tecnologia. Verifique sua conexão com a internet. O sistema continuara com limite de acessos"
        'frm.btnNao.Visible = False
        'frm.btnSim.Visible = False
        'frm.btnOK.Visible = True
        'frm.PictureBox.Image = GourmetVisual.My.Resources.Resources.exclamacao
        'frm.ShowDialog()
        'EscreveINI("Geral", "DU", DesmontaSenha(DiasUso - 1), nome_arquivo_ini)


        'End Try
        conIRIS.Dispose()
        conIRIS.Close()

        LinhaGridProdutos()

    End Sub

    Private Sub BtnNaoMostrar_Click(sender As Object, e As EventArgs) Handles btnNaoMostrar.Click

        lbAguarde.Visible = True
        lbAguarde.Refresh()

        frmInicio.AtualizaTabela("Categorias")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Categorias') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Comentarios")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Comentarios') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Combos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Combos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Familias")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Familias') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("FormaPagtos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='FormaPagtos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Funcionarios")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Funcionarios') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Grupos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Grupos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.AtualizaTabela("Produtos")
        System.Threading.Thread.Sleep(100)
        strSql = "UPDATE tblAtualizaTabelasLojas SET "
        strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
        strSql &= "WHERE (Tabela='Produtos') AND (IDLoja=" & IDLoja & ")"
        ExecutaStrServidor(strSql)

        frmInicio.Atualiza_Tablet()

        EscreveINI("Geral", "MostraAtualizacoes", "0", nome_arquivo_ini)
        Me.Dispose()
        Me.Close()
    End Sub
End Class