Public Class fdlgAtualizaTabelas
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnAtualizar_Click(sender As Object, e As EventArgs) Handles btnAtualizar.Click

        pbCategorias.Visible = False
        pbCombos.Visible = False
        pbComentarios.Visible = False
        pbFamilias.Visible = False
        pbFormasPagto.Visible = False
        pbFuncionarios.Visible = False
        pbGrupos.Visible = False
        pbProdutos.Visible = False
        pbTablets.Visible = False

        If chkCategorias.Checked = True Then
            If frmInicio.AtualizaTabela("Categorias") = False Then Exit Sub
            pbCategorias.Visible = True
            pbCategorias.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='Categorias') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If
        If chkComentarios.Checked = True Then
            If frmInicio.AtualizaTabela("Comentarios") = False Then Exit Sub
            pbComentarios.Visible = True
            pbComentarios.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='Comentarios') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If
        If chkCombos.Checked = True Then
            If frmInicio.AtualizaTabela("Combos") = False Then Exit Sub
            pbCombos.Visible = True
            pbCombos.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='Combos') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If
        If chkFamilias.Checked = True Then
            If frmInicio.AtualizaTabela("Familias") = False Then Exit Sub
            pbFamilias.Visible = True
            pbFamilias.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='Familias') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If
        If chkFormasPagto.Checked = True Then
            If frmInicio.AtualizaTabela("FormaPagtos") = False Then Exit Sub
            pbFormasPagto.Visible = True
            pbFormasPagto.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='FormaPagtos') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If
        If chkFuncionarios.Checked = True Then
            If frmInicio.AtualizaTabela("Funcionarios") = False Then Exit Sub
            pbFuncionarios.Visible = True
            pbFuncionarios.Refresh()
            System.Threading.Thread.Sleep(500)
        End If
        If chkGrupos.Checked = True Then
            If frmInicio.AtualizaTabela("Grupos") = False Then Exit Sub
            pbGrupos.Visible = True
            pbGrupos.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='Grupos') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If

        If chkProdutos.Checked = True Then
            If frmInicio.AtualizaTabela("Produtos") = False Then Exit Sub
            pbProdutos.Visible = True
            pbProdutos.Refresh()
            System.Threading.Thread.Sleep(500)

            strSql = "UPDATE tblAtualizaTabelasLojas SET "
            strSql &= "GourmetVisual='" & Now.ToString(FormatoDataRET & " HHH:mm:ss") & "' "
            strSql &= "WHERE (Tabela='Produtos') AND (IDLoja=" & IDLoja & ")"
            ExecutaStrServidor(strSql)
        End If

        If chkTablets.Checked = True Then
            If frmInicio.Atualiza_Tablet() = False Then Exit Sub
            pbTablets.Visible = True
            pbTablets.Refresh()
            System.Threading.Thread.Sleep(500)
        End If


    End Sub

    Private Sub fdlgAtualizaTabelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkCategorias.Checked = True
        chkCombos.Checked = True
        chkComentarios.Checked = True
        chkFamilias.Checked = True
        chkFormasPagto.Checked = True
        chkFuncionarios.Checked = True
        chkGrupos.Checked = True
        chkProdutos.Checked = True
        'If GerenciaTable = True Then
        chkTablets.Checked = True
        'Else
        'chkTablets.Checked = True
        'chkTablets.Visible = False
        'pbTablets.Visible = False
        'End If

    End Sub
End Class