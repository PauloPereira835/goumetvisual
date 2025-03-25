<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgMotivoEstorno
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
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.lstMotivos = New System.Windows.Forms.ListView()
        Me.IDMotivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Motivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Produto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Venda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Transferencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTransfere = New System.Windows.Forms.CheckBox()
        Me.chkVenda = New System.Windows.Forms.CheckBox()
        Me.chkProduto = New System.Windows.Forms.CheckBox()
        Me.tbMotivo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnVolta.Location = New System.Drawing.Point(7, 7)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(80, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnIncluir
        '
        Me.btnIncluir.BackColor = System.Drawing.Color.White
        Me.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluir.FlatAppearance.BorderSize = 0
        Me.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluir.ForeColor = System.Drawing.Color.Black
        Me.btnIncluir.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.Location = New System.Drawing.Point(96, 7)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(80, 41)
        Me.btnIncluir.TabIndex = 26
        Me.btnIncluir.TabStop = False
        Me.btnIncluir.Tag = ""
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnAlterar)
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.btnIncluir)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 55)
        Me.Panel1.TabIndex = 14
        '
        'btnAlterar
        '
        Me.btnAlterar.BackColor = System.Drawing.Color.White
        Me.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAlterar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAlterar.FlatAppearance.BorderSize = 0
        Me.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlterar.ForeColor = System.Drawing.Color.Black
        Me.btnAlterar.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.Location = New System.Drawing.Point(274, 7)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(80, 41)
        Me.btnAlterar.TabIndex = 28
        Me.btnAlterar.TabStop = False
        Me.btnAlterar.Tag = ""
        Me.btnAlterar.Text = "Alterar"
        Me.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlterar.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.White
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Black
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash2
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(185, 7)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(80, 41)
        Me.btnExcluir.TabIndex = 27
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Tag = ""
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'lstMotivos
        '
        Me.lstMotivos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstMotivos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMotivos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDMotivo, Me.Motivo, Me.Produto, Me.Venda, Me.Transferencia})
        Me.lstMotivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMotivos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lstMotivos.FullRowSelect = True
        Me.lstMotivos.GridLines = True
        Me.lstMotivos.HideSelection = False
        Me.lstMotivos.Location = New System.Drawing.Point(13, 137)
        Me.lstMotivos.MultiSelect = False
        Me.lstMotivos.Name = "lstMotivos"
        Me.lstMotivos.Size = New System.Drawing.Size(335, 272)
        Me.lstMotivos.TabIndex = 32
        Me.lstMotivos.UseCompatibleStateImageBehavior = False
        Me.lstMotivos.View = System.Windows.Forms.View.Details
        '
        'IDMotivo
        '
        Me.IDMotivo.Text = "IDMotivo"
        Me.IDMotivo.Width = 0
        '
        'Motivo
        '
        Me.Motivo.Text = "Motivo"
        Me.Motivo.Width = 150
        '
        'Produto
        '
        Me.Produto.Text = "Produto"
        Me.Produto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Produto.Width = 55
        '
        'Venda
        '
        Me.Venda.Text = "Venda"
        Me.Venda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Venda.Width = 55
        '
        'Transferencia
        '
        Me.Transferencia.Text = "Transf."
        Me.Transferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Transferencia.Width = 55
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.chkTransfere)
        Me.Panel2.Controls.Add(Me.chkVenda)
        Me.Panel2.Controls.Add(Me.chkProduto)
        Me.Panel2.Controls.Add(Me.tbMotivo)
        Me.Panel2.Location = New System.Drawing.Point(12, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 64)
        Me.Panel2.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Motivo"
        '
        'chkTransfere
        '
        Me.chkTransfere.AutoSize = True
        Me.chkTransfere.Location = New System.Drawing.Point(238, 38)
        Me.chkTransfere.Name = "chkTransfere"
        Me.chkTransfere.Size = New System.Drawing.Size(91, 17)
        Me.chkTransfere.TabIndex = 3
        Me.chkTransfere.Text = "Transferencia"
        Me.chkTransfere.UseVisualStyleBackColor = True
        '
        'chkVenda
        '
        Me.chkVenda.AutoSize = True
        Me.chkVenda.Location = New System.Drawing.Point(130, 38)
        Me.chkVenda.Name = "chkVenda"
        Me.chkVenda.Size = New System.Drawing.Size(57, 17)
        Me.chkVenda.TabIndex = 2
        Me.chkVenda.Text = "Venda"
        Me.chkVenda.UseVisualStyleBackColor = True
        '
        'chkProduto
        '
        Me.chkProduto.AutoSize = True
        Me.chkProduto.Location = New System.Drawing.Point(12, 38)
        Me.chkProduto.Name = "chkProduto"
        Me.chkProduto.Size = New System.Drawing.Size(63, 17)
        Me.chkProduto.TabIndex = 1
        Me.chkProduto.Text = "Produto"
        Me.chkProduto.UseVisualStyleBackColor = True
        '
        'tbMotivo
        '
        Me.tbMotivo.Location = New System.Drawing.Point(62, 8)
        Me.tbMotivo.Name = "tbMotivo"
        Me.tbMotivo.Size = New System.Drawing.Size(235, 20)
        Me.tbMotivo.TabIndex = 0
        '
        'fdlgMotivoEstorno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(362, 420)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lstMotivos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgMotivoEstorno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivos estorno"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVolta As Button
    Friend WithEvents btnIncluir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents lstMotivos As ListView
    Friend WithEvents IDMotivo As ColumnHeader
    Friend WithEvents Motivo As ColumnHeader
    Friend WithEvents Produto As ColumnHeader
    Friend WithEvents Venda As ColumnHeader
    Friend WithEvents Transferencia As ColumnHeader
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents chkTransfere As CheckBox
    Friend WithEvents chkVenda As CheckBox
    Friend WithEvents chkProduto As CheckBox
    Friend WithEvents tbMotivo As TextBox
End Class
