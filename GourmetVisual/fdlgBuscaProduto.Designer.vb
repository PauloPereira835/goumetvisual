<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgBuscaProduto
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.lsvProdutos = New System.Windows.Forms.ListView()
        Me.Produto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Venda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'tbBusca
        '
        Me.tbBusca.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.ForeColor = System.Drawing.Color.Maroon
        Me.tbBusca.Location = New System.Drawing.Point(8, 7)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(593, 40)
        Me.tbBusca.TabIndex = 0
        '
        'lsvProdutos
        '
        Me.lsvProdutos.BackColor = System.Drawing.SystemColors.Control
        Me.lsvProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvProdutos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Produto, Me.Codigo, Me.Venda})
        Me.lsvProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvProdutos.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lsvProdutos.FullRowSelect = True
        Me.lsvProdutos.Location = New System.Drawing.Point(8, 50)
        Me.lsvProdutos.MultiSelect = False
        Me.lsvProdutos.Name = "lsvProdutos"
        Me.lsvProdutos.Size = New System.Drawing.Size(593, 397)
        Me.lsvProdutos.TabIndex = 32
        Me.lsvProdutos.UseCompatibleStateImageBehavior = False
        Me.lsvProdutos.View = System.Windows.Forms.View.Details
        '
        'Produto
        '
        Me.Produto.Text = "Produto"
        Me.Produto.Width = 370
        '
        'Codigo
        '
        Me.Codigo.Text = "Código"
        Me.Codigo.Width = 80
        '
        'Venda
        '
        Me.Venda.Text = "Venda"
        Me.Venda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Venda.Width = 120
        '
        'fdlgBuscaProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(610, 455)
        Me.Controls.Add(Me.lsvProdutos)
        Me.Controls.Add(Me.tbBusca)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fdlgBuscaProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fdlgBuscaProduto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents lsvProdutos As ListView
    Friend WithEvents Produto As ColumnHeader
    Friend WithEvents Codigo As ColumnHeader
    Friend WithEvents Venda As ColumnHeader
End Class
