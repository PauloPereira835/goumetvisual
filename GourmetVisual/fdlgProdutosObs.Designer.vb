<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgProdutosObs
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
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lstProduto = New System.Windows.Forms.ListView()
        Me.lstIDProduto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstProdut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstObs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 53)
        Me.Panel1.TabIndex = 14
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(7, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(97, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'tbObs
        '
        Me.tbObs.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.ForeColor = System.Drawing.Color.Navy
        Me.tbObs.Location = New System.Drawing.Point(471, 93)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.ReadOnly = True
        Me.tbObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbObs.Size = New System.Drawing.Size(354, 268)
        Me.tbObs.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(473, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Sobre o produto"
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.Location = New System.Drawing.Point(150, 64)
        Me.tbBusca.Multiline = True
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(252, 24)
        Me.tbBusca.TabIndex = 0
        Me.tbBusca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Navy
        Me.Label25.Location = New System.Drawing.Point(12, 69)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(136, 16)
        Me.Label25.TabIndex = 183
        Me.Label25.Text = "Busca por nome ou código"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstProduto
        '
        Me.lstProduto.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstProduto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstIDProduto, Me.lstProdut, Me.lstVenda, Me.lstObs, Me.lstCodigo})
        Me.lstProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProduto.FullRowSelect = True
        Me.lstProduto.GridLines = True
        Me.lstProduto.HideSelection = False
        Me.lstProduto.Location = New System.Drawing.Point(12, 93)
        Me.lstProduto.MultiSelect = False
        Me.lstProduto.Name = "lstProduto"
        Me.lstProduto.Size = New System.Drawing.Size(451, 268)
        Me.lstProduto.TabIndex = 182
        Me.lstProduto.UseCompatibleStateImageBehavior = False
        Me.lstProduto.View = System.Windows.Forms.View.Details
        '
        'lstIDProduto
        '
        Me.lstIDProduto.Text = "IDProduto"
        Me.lstIDProduto.Width = 0
        '
        'lstProdut
        '
        Me.lstProdut.DisplayIndex = 2
        Me.lstProdut.Text = "Produto"
        Me.lstProdut.Width = 270
        '
        'lstVenda
        '
        Me.lstVenda.DisplayIndex = 3
        Me.lstVenda.Text = "Venda"
        Me.lstVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstVenda.Width = 100
        '
        'lstObs
        '
        Me.lstObs.DisplayIndex = 4
        Me.lstObs.Text = "Obs"
        Me.lstObs.Width = 0
        '
        'lstCodigo
        '
        Me.lstCodigo.DisplayIndex = 1
        Me.lstCodigo.Text = "Código"
        '
        'fdlgProdutosObs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(831, 373)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lstProduto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbObs)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgProdutosObs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtos"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents tbObs As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents lstProduto As ListView
    Friend WithEvents lstIDProduto As ColumnHeader
    Friend WithEvents lstProdut As ColumnHeader
    Friend WithEvents lstVenda As ColumnHeader
    Friend WithEvents lstObs As ColumnHeader
    Friend WithEvents lstCodigo As ColumnHeader
End Class
