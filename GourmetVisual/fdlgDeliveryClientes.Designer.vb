<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDeliveryClientes
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
        Me.GridProdutos = New System.Windows.Forms.DataGridView()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbQtdeClientes = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbTel1 = New System.Windows.Forms.RadioButton()
        Me.rbTel2 = New System.Windows.Forms.RadioButton()
        Me.IDCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endereco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bairro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GridProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(703, 2)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(85, 46)
        Me.btnVolta.TabIndex = 17
        Me.btnVolta.Text = "Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'GridProdutos
        '
        Me.GridProdutos.AllowUserToAddRows = False
        Me.GridProdutos.AllowUserToDeleteRows = False
        Me.GridProdutos.AllowUserToResizeColumns = False
        Me.GridProdutos.AllowUserToResizeRows = False
        Me.GridProdutos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridProdutos.ColumnHeadersVisible = False
        Me.GridProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCliente, Me.Cliente, Me.Telefone1, Me.Telefone2, Me.Endereco, Me.CEP, Me.Bairro})
        Me.GridProdutos.DataMember = "DescricaoPedido"
        Me.GridProdutos.GridColor = System.Drawing.SystemColors.ControlLight
        Me.GridProdutos.Location = New System.Drawing.Point(12, 54)
        Me.GridProdutos.Name = "GridProdutos"
        Me.GridProdutos.ReadOnly = True
        Me.GridProdutos.RowHeadersVisible = False
        Me.GridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridProdutos.Size = New System.Drawing.Size(776, 534)
        Me.GridProdutos.TabIndex = 40
        Me.GridProdutos.TabStop = False
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBusca.Location = New System.Drawing.Point(64, 13)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(423, 29)
        Me.tbBusca.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Busca"
        '
        'lbQtdeClientes
        '
        Me.lbQtdeClientes.BackColor = System.Drawing.Color.NavajoWhite
        Me.lbQtdeClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbQtdeClientes.Location = New System.Drawing.Point(623, 591)
        Me.lbQtdeClientes.Name = "lbQtdeClientes"
        Me.lbQtdeClientes.Size = New System.Drawing.Size(165, 16)
        Me.lbQtdeClientes.TabIndex = 43
        Me.lbQtdeClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.rbTel2)
        Me.Panel1.Controls.Add(Me.rbTel1)
        Me.Panel1.Location = New System.Drawing.Point(529, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 45)
        Me.Panel1.TabIndex = 44
        '
        'rbTel1
        '
        Me.rbTel1.AutoSize = True
        Me.rbTel1.Location = New System.Drawing.Point(8, 2)
        Me.rbTel1.Name = "rbTel1"
        Me.rbTel1.Size = New System.Drawing.Size(76, 17)
        Me.rbTel1.TabIndex = 0
        Me.rbTel1.TabStop = True
        Me.rbTel1.Text = "Telefone 1"
        Me.rbTel1.UseVisualStyleBackColor = True
        '
        'rbTel2
        '
        Me.rbTel2.AutoSize = True
        Me.rbTel2.Location = New System.Drawing.Point(8, 23)
        Me.rbTel2.Name = "rbTel2"
        Me.rbTel2.Size = New System.Drawing.Size(76, 17)
        Me.rbTel2.TabIndex = 1
        Me.rbTel2.TabStop = True
        Me.rbTel2.Text = "Telefone 2"
        Me.rbTel2.UseVisualStyleBackColor = True
        '
        'IDCliente
        '
        Me.IDCliente.HeaderText = "IDCliente"
        Me.IDCliente.Name = "IDCliente"
        Me.IDCliente.ReadOnly = True
        Me.IDCliente.Visible = False
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Telefone1
        '
        Me.Telefone1.HeaderText = "Telefone1"
        Me.Telefone1.Name = "Telefone1"
        Me.Telefone1.ReadOnly = True
        '
        'Telefone2
        '
        Me.Telefone2.HeaderText = "Telefone2"
        Me.Telefone2.Name = "Telefone2"
        Me.Telefone2.ReadOnly = True
        '
        'Endereco
        '
        Me.Endereco.HeaderText = "Endereço"
        Me.Endereco.Name = "Endereco"
        Me.Endereco.ReadOnly = True
        '
        'CEP
        '
        Me.CEP.HeaderText = "CEP"
        Me.CEP.Name = "CEP"
        Me.CEP.ReadOnly = True
        '
        'Bairro
        '
        Me.Bairro.HeaderText = "Bairro"
        Me.Bairro.Name = "Bairro"
        Me.Bairro.ReadOnly = True
        '
        'fdlgDeliveryClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(800, 614)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbQtdeClientes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.GridProdutos)
        Me.Controls.Add(Me.btnVolta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fdlgDeliveryClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fdlgDeliveryClientes"
        CType(Me.GridProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVolta As Button
    Friend WithEvents GridProdutos As DataGridView
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbQtdeClientes As Label
    Friend WithEvents IDCliente As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Telefone1 As DataGridViewTextBoxColumn
    Friend WithEvents Telefone2 As DataGridViewTextBoxColumn
    Friend WithEvents Endereco As DataGridViewTextBoxColumn
    Friend WithEvents CEP As DataGridViewTextBoxColumn
    Friend WithEvents Bairro As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbTel2 As RadioButton
    Friend WithEvents rbTel1 As RadioButton
End Class
