<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgBuscaRuas
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
        Me.GridRuas = New System.Windows.Forms.DataGridView()
        Me.IDRua = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Logradouro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bairro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TaxaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbBuscaRua = New System.Windows.Forms.TextBox()
        Me.btnCadastroRuas = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridRuas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridRuas
        '
        Me.GridRuas.AllowUserToAddRows = False
        Me.GridRuas.AllowUserToDeleteRows = False
        Me.GridRuas.AllowUserToResizeColumns = False
        Me.GridRuas.AllowUserToResizeRows = False
        Me.GridRuas.BackgroundColor = System.Drawing.Color.Snow
        Me.GridRuas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridRuas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridRuas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridRuas.ColumnHeadersVisible = False
        Me.GridRuas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDRua, Me.Logradouro, Me.Bairro, Me.CEP, Me.Area, Me.TaxaEntrega})
        Me.GridRuas.DataMember = "DescricaoPedido"
        Me.GridRuas.GridColor = System.Drawing.SystemColors.ControlLight
        Me.GridRuas.Location = New System.Drawing.Point(12, 66)
        Me.GridRuas.Name = "GridRuas"
        Me.GridRuas.ReadOnly = True
        Me.GridRuas.RowHeadersVisible = False
        Me.GridRuas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridRuas.Size = New System.Drawing.Size(718, 372)
        Me.GridRuas.TabIndex = 15
        Me.GridRuas.TabStop = False
        '
        'IDRua
        '
        Me.IDRua.HeaderText = "IDRua"
        Me.IDRua.Name = "IDRua"
        Me.IDRua.ReadOnly = True
        Me.IDRua.Visible = False
        Me.IDRua.Width = 5
        '
        'Logradouro
        '
        Me.Logradouro.HeaderText = "Logradouro"
        Me.Logradouro.Name = "Logradouro"
        Me.Logradouro.ReadOnly = True
        Me.Logradouro.Width = 250
        '
        'Bairro
        '
        Me.Bairro.HeaderText = "Bairro"
        Me.Bairro.Name = "Bairro"
        Me.Bairro.ReadOnly = True
        Me.Bairro.Width = 150
        '
        'CEP
        '
        Me.CEP.HeaderText = "CEP"
        Me.CEP.Name = "CEP"
        Me.CEP.ReadOnly = True
        '
        'Area
        '
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        Me.Area.Width = 50
        '
        'TaxaEntrega
        '
        Me.TaxaEntrega.HeaderText = "Vlr Taxa"
        Me.TaxaEntrega.Name = "TaxaEntrega"
        Me.TaxaEntrega.ReadOnly = True
        Me.TaxaEntrega.Width = 50
        '
        'tbBuscaRua
        '
        Me.tbBuscaRua.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbBuscaRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaRua.Location = New System.Drawing.Point(243, 22)
        Me.tbBuscaRua.Multiline = True
        Me.tbBuscaRua.Name = "tbBuscaRua"
        Me.tbBuscaRua.Size = New System.Drawing.Size(301, 24)
        Me.tbBuscaRua.TabIndex = 26
        Me.tbBuscaRua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCadastroRuas
        '
        Me.btnCadastroRuas.BackColor = System.Drawing.Color.White
        Me.btnCadastroRuas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCadastroRuas.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCadastroRuas.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCadastroRuas.ForeColor = System.Drawing.Color.Blue
        Me.btnCadastroRuas.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnCadastroRuas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCadastroRuas.Location = New System.Drawing.Point(602, 11)
        Me.btnCadastroRuas.Name = "btnCadastroRuas"
        Me.btnCadastroRuas.Size = New System.Drawing.Size(128, 48)
        Me.btnCadastroRuas.TabIndex = 42
        Me.btnCadastroRuas.TabStop = False
        Me.btnCadastroRuas.Text = "Cadastrar Logradouro"
        Me.btnCadastroRuas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCadastroRuas.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnVoltar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(12, 11)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(92, 48)
        Me.btnVoltar.TabIndex = 43
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(152, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Busca logradouro"
        '
        'fdlgBuscaRuas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(742, 451)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.btnCadastroRuas)
        Me.Controls.Add(Me.tbBuscaRua)
        Me.Controls.Add(Me.GridRuas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fdlgBuscaRuas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fdlgBuscaRuas"
        CType(Me.GridRuas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridRuas As DataGridView
    Friend WithEvents tbBuscaRua As TextBox
    Friend WithEvents IDRua As DataGridViewTextBoxColumn
    Friend WithEvents Logradouro As DataGridViewTextBoxColumn
    Friend WithEvents Bairro As DataGridViewTextBoxColumn
    Friend WithEvents CEP As DataGridViewTextBoxColumn
    Friend WithEvents Area As DataGridViewTextBoxColumn
    Friend WithEvents TaxaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents btnCadastroRuas As Button
    Friend WithEvents btnVoltar As Button
    Friend WithEvents Label1 As Label
End Class
