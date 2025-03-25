<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgSat_VerificaVenda
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVisualiza = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.lstVenda = New System.Windows.Forms.ListView()
        Me.IDVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoProd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Produto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Qtde = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ValorUnitario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ValorProduto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstPagamento = New System.Windows.Forms.ListView()
        Me.IDVendaPagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.lbQtde = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.lbTotalPagto = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVisualiza)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(691, 54)
        Me.Panel1.TabIndex = 34
        '
        'btnVisualiza
        '
        Me.btnVisualiza.BackColor = System.Drawing.Color.White
        Me.btnVisualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVisualiza.Enabled = False
        Me.btnVisualiza.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVisualiza.FlatAppearance.BorderSize = 0
        Me.btnVisualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVisualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisualiza.ForeColor = System.Drawing.Color.Black
        Me.btnVisualiza.Image = Global.GourmetVisual.My.Resources.Resources.Document
        Me.btnVisualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVisualiza.Location = New System.Drawing.Point(453, 6)
        Me.btnVisualiza.Name = "btnVisualiza"
        Me.btnVisualiza.Size = New System.Drawing.Size(130, 41)
        Me.btnVisualiza.TabIndex = 102
        Me.btnVisualiza.TabStop = False
        Me.btnVisualiza.Tag = ""
        Me.btnVisualiza.Text = "Visualiza CUPOM"
        Me.btnVisualiza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVisualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVisualiza.UseVisualStyleBackColor = False
        Me.btnVisualiza.Visible = False
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolta.ForeColor = System.Drawing.Color.Black
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(6, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(90, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstVenda
        '
        Me.lstVenda.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstVenda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstVenda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDVenda, Me.CodigoProd, Me.Produto, Me.Qtde, Me.ValorUnitario, Me.ValorProduto})
        Me.lstVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstVenda.ForeColor = System.Drawing.Color.Blue
        Me.lstVenda.FullRowSelect = True
        Me.lstVenda.GridLines = True
        Me.lstVenda.HideSelection = False
        Me.lstVenda.Location = New System.Drawing.Point(7, 64)
        Me.lstVenda.MultiSelect = False
        Me.lstVenda.Name = "lstVenda"
        Me.lstVenda.Size = New System.Drawing.Size(572, 337)
        Me.lstVenda.TabIndex = 35
        Me.lstVenda.UseCompatibleStateImageBehavior = False
        Me.lstVenda.View = System.Windows.Forms.View.Details
        '
        'IDVenda
        '
        Me.IDVenda.Text = "IDVenda"
        Me.IDVenda.Width = 0
        '
        'CodigoProd
        '
        Me.CodigoProd.Text = "Código"
        Me.CodigoProd.Width = 70
        '
        'Produto
        '
        Me.Produto.Text = "Produto"
        Me.Produto.Width = 200
        '
        'Qtde
        '
        Me.Qtde.Text = "Qtde"
        Me.Qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Qtde.Width = 80
        '
        'ValorUnitario
        '
        Me.ValorUnitario.Text = "Valor"
        Me.ValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValorUnitario.Width = 100
        '
        'ValorProduto
        '
        Me.ValorProduto.Text = "Total"
        Me.ValorProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValorProduto.Width = 100
        '
        'lstPagamento
        '
        Me.lstPagamento.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstPagamento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstPagamento.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDVendaPagto, Me.Descricao, Me.Valor})
        Me.lstPagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPagamento.ForeColor = System.Drawing.Color.Blue
        Me.lstPagamento.FullRowSelect = True
        Me.lstPagamento.GridLines = True
        Me.lstPagamento.HideSelection = False
        Me.lstPagamento.Location = New System.Drawing.Point(7, 430)
        Me.lstPagamento.MultiSelect = False
        Me.lstPagamento.Name = "lstPagamento"
        Me.lstPagamento.Size = New System.Drawing.Size(289, 121)
        Me.lstPagamento.TabIndex = 36
        Me.lstPagamento.UseCompatibleStateImageBehavior = False
        Me.lstPagamento.View = System.Windows.Forms.View.Details
        '
        'IDVendaPagto
        '
        Me.IDVendaPagto.Text = "IDVendaPagto"
        Me.IDVendaPagto.Width = 0
        '
        'Descricao
        '
        Me.Descricao.Text = "Descrição"
        Me.Descricao.Width = 190
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Valor.Width = 80
        '
        'lbTotal
        '
        Me.lbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.Location = New System.Drawing.Point(416, 404)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(141, 21)
        Me.lbTotal.TabIndex = 37
        Me.lbTotal.Text = "0,00"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQtde
        '
        Me.lbQtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtde.Location = New System.Drawing.Point(12, 404)
        Me.lbQtde.Name = "lbQtde"
        Me.lbQtde.Size = New System.Drawing.Size(405, 21)
        Me.lbQtde.TabIndex = 38
        Me.lbQtde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(381, 484)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(100, 20)
        Me.tbIDVenda.TabIndex = 39
        Me.tbIDVenda.Visible = False
        '
        'lbTotalPagto
        '
        Me.lbTotalPagto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalPagto.Location = New System.Drawing.Point(135, 555)
        Me.lbTotalPagto.Name = "lbTotalPagto"
        Me.lbTotalPagto.Size = New System.Drawing.Size(141, 21)
        Me.lbTotalPagto.TabIndex = 40
        Me.lbTotalPagto.Text = "0,00"
        Me.lbTotalPagto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fdlgSat_VerificaVenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(587, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbTotalPagto)
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.lbQtde)
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.lstPagamento)
        Me.Controls.Add(Me.lstVenda)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgSat_VerificaVenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verifica venda"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVisualiza As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents lstVenda As ListView
    Friend WithEvents IDVenda As ColumnHeader
    Friend WithEvents CodigoProd As ColumnHeader
    Friend WithEvents Produto As ColumnHeader
    Friend WithEvents Qtde As ColumnHeader
    Friend WithEvents ValorUnitario As ColumnHeader
    Friend WithEvents ValorProduto As ColumnHeader
    Friend WithEvents lstPagamento As ListView
    Friend WithEvents IDVendaPagto As ColumnHeader
    Friend WithEvents Descricao As ColumnHeader
    Friend WithEvents Valor As ColumnHeader
    Friend WithEvents lbTotal As Label
    Friend WithEvents lbQtde As Label
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents lbTotalPagto As Label
End Class
