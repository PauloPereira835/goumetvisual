<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgEstornoDelivery
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
        Me.btnSai = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridMotivo = New System.Windows.Forms.DataGridView()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbProduto = New System.Windows.Forms.Label()
        Me.tbIDMovto = New System.Windows.Forms.TextBox()
        Me.lbComent = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.GridMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnSai)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(625, 71)
        Me.Panel1.TabIndex = 30
        '
        'btnSai
        '
        Me.btnSai.BackColor = System.Drawing.Color.White
        Me.btnSai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSai.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSai.FlatAppearance.BorderSize = 2
        Me.btnSai.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSai.ForeColor = System.Drawing.Color.Blue
        Me.btnSai.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnSai.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSai.Location = New System.Drawing.Point(6, 5)
        Me.btnSai.Name = "btnSai"
        Me.btnSai.Size = New System.Drawing.Size(68, 59)
        Me.btnSai.TabIndex = 13
        Me.btnSai.TabStop = False
        Me.btnSai.Text = "Sair"
        Me.btnSai.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSai.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok1
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(428, 5)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(189, 59)
        Me.btnConfirma.TabIndex = 12
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Confirma F7"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(406, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Motivo"
        '
        'GridMotivo
        '
        Me.GridMotivo.AllowUserToAddRows = False
        Me.GridMotivo.AllowUserToDeleteRows = False
        Me.GridMotivo.AllowUserToResizeColumns = False
        Me.GridMotivo.AllowUserToResizeRows = False
        Me.GridMotivo.BackgroundColor = System.Drawing.Color.White
        Me.GridMotivo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridMotivo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridMotivo.ColumnHeadersVisible = False
        Me.GridMotivo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Motivo})
        Me.GridMotivo.DataMember = "DescricaoPedido"
        Me.GridMotivo.Location = New System.Drawing.Point(408, 97)
        Me.GridMotivo.MultiSelect = False
        Me.GridMotivo.Name = "GridMotivo"
        Me.GridMotivo.ReadOnly = True
        Me.GridMotivo.RowHeadersVisible = False
        Me.GridMotivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridMotivo.Size = New System.Drawing.Size(217, 182)
        Me.GridMotivo.TabIndex = 31
        Me.GridMotivo.TabStop = False
        '
        'Motivo
        '
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        Me.Motivo.Width = 200
        '
        'lbProduto
        '
        Me.lbProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProduto.ForeColor = System.Drawing.Color.Navy
        Me.lbProduto.Location = New System.Drawing.Point(4, 78)
        Me.lbProduto.Name = "lbProduto"
        Me.lbProduto.Size = New System.Drawing.Size(397, 28)
        Me.lbProduto.TabIndex = 33
        '
        'tbIDMovto
        '
        Me.tbIDMovto.Location = New System.Drawing.Point(475, 76)
        Me.tbIDMovto.Name = "tbIDMovto"
        Me.tbIDMovto.Size = New System.Drawing.Size(49, 20)
        Me.tbIDMovto.TabIndex = 34
        Me.tbIDMovto.Visible = False
        '
        'lbComent
        '
        Me.lbComent.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbComent.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbComent.Location = New System.Drawing.Point(12, 106)
        Me.lbComent.Name = "lbComent"
        Me.lbComent.Size = New System.Drawing.Size(388, 173)
        Me.lbComent.TabIndex = 35
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(530, 76)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(49, 20)
        Me.tbIDVenda.TabIndex = 36
        Me.tbIDVenda.Visible = False
        '
        'fdlgEstornoDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(633, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.lbComent)
        Me.Controls.Add(Me.tbIDMovto)
        Me.Controls.Add(Me.lbProduto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridMotivo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgEstornoDelivery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estorno de Produto"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSai As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GridMotivo As DataGridView
    Friend WithEvents Motivo As DataGridViewTextBoxColumn
    Friend WithEvents lbProduto As Label
    Friend WithEvents tbIDMovto As TextBox
    Friend WithEvents lbComent As Label
    Friend WithEvents tbIDVenda As TextBox
End Class
