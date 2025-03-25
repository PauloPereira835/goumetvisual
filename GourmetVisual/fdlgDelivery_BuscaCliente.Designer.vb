<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgDelivery_BuscaCliente
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
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.GridClientes = New System.Windows.Forms.DataGridView()
        Me.IDCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefone2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPF_CNPJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Endereco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bairro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbQtdeClientes = New System.Windows.Forms.Label()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(7, 8)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(85, 39)
        Me.btnVolta.TabIndex = 17
        Me.btnVolta.Text = "Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'GridClientes
        '
        Me.GridClientes.AllowUserToAddRows = False
        Me.GridClientes.AllowUserToDeleteRows = False
        Me.GridClientes.AllowUserToResizeColumns = False
        Me.GridClientes.AllowUserToResizeRows = False
        Me.GridClientes.BackgroundColor = System.Drawing.Color.LightBlue
        Me.GridClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCliente, Me.Cliente, Me.Telefone1, Me.Telefone2, Me.CPF_CNPJ, Me.Endereco, Me.CEP, Me.Bairro})
        Me.GridClientes.DataMember = "DescricaoPedido"
        Me.GridClientes.GridColor = System.Drawing.SystemColors.ControlLight
        Me.GridClientes.Location = New System.Drawing.Point(5, 54)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.ReadOnly = True
        Me.GridClientes.RowHeadersVisible = False
        Me.GridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridClientes.Size = New System.Drawing.Size(1008, 534)
        Me.GridClientes.TabIndex = 40
        Me.GridClientes.TabStop = False
        '
        'IDCliente
        '
        Me.IDCliente.HeaderText = "IDCliente"
        Me.IDCliente.Name = "IDCliente"
        Me.IDCliente.ReadOnly = True
        Me.IDCliente.Visible = False
        Me.IDCliente.Width = 5
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 205
        '
        'Telefone1
        '
        Me.Telefone1.HeaderText = "Telefone1"
        Me.Telefone1.Name = "Telefone1"
        Me.Telefone1.ReadOnly = True
        Me.Telefone1.Width = 70
        '
        'Telefone2
        '
        Me.Telefone2.HeaderText = "Telefone2"
        Me.Telefone2.Name = "Telefone2"
        Me.Telefone2.ReadOnly = True
        Me.Telefone2.Width = 70
        '
        'CPF_CNPJ
        '
        Me.CPF_CNPJ.HeaderText = "CPF/CNPJ"
        Me.CPF_CNPJ.Name = "CPF_CNPJ"
        Me.CPF_CNPJ.ReadOnly = True
        Me.CPF_CNPJ.Width = 80
        '
        'Endereco
        '
        Me.Endereco.HeaderText = "Endereço"
        Me.Endereco.Name = "Endereco"
        Me.Endereco.ReadOnly = True
        Me.Endereco.Width = 300
        '
        'CEP
        '
        Me.CEP.HeaderText = "CEP"
        Me.CEP.Name = "CEP"
        Me.CEP.ReadOnly = True
        Me.CEP.Width = 60
        '
        'Bairro
        '
        Me.Bairro.HeaderText = "Bairro"
        Me.Bairro.Name = "Bairro"
        Me.Bairro.ReadOnly = True
        Me.Bairro.Width = 220
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBusca.Location = New System.Drawing.Point(225, 13)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(423, 29)
        Me.tbBusca.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(175, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Busca"
        '
        'lbQtdeClientes
        '
        Me.lbQtdeClientes.BackColor = System.Drawing.Color.CadetBlue
        Me.lbQtdeClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbQtdeClientes.Location = New System.Drawing.Point(640, 593)
        Me.lbQtdeClientes.Name = "lbQtdeClientes"
        Me.lbQtdeClientes.Size = New System.Drawing.Size(373, 16)
        Me.lbQtdeClientes.TabIndex = 43
        Me.lbQtdeClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fdlgDelivery_BuscaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(1018, 614)
        Me.Controls.Add(Me.lbQtdeClientes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.GridClientes)
        Me.Controls.Add(Me.btnVolta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fdlgDelivery_BuscaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fdlgDeliveryClientes"
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVolta As Button
    Friend WithEvents GridClientes As DataGridView
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbQtdeClientes As Label
    Friend WithEvents IDCliente As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Telefone1 As DataGridViewTextBoxColumn
    Friend WithEvents Telefone2 As DataGridViewTextBoxColumn
    Friend WithEvents CPF_CNPJ As DataGridViewTextBoxColumn
    Friend WithEvents Endereco As DataGridViewTextBoxColumn
    Friend WithEvents CEP As DataGridViewTextBoxColumn
    Friend WithEvents Bairro As DataGridViewTextBoxColumn
End Class
