<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAtualizacoes
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lstAtualizacoes = New System.Windows.Forms.ListView()
        Me.Descricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnNaoMostrar = New System.Windows.Forms.Button()
        Me.tbOrigem = New System.Windows.Forms.TextBox()
        Me.lbAguarde = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.GourmetVisual.My.Resources.Resources.Logo_NOVO1
        Me.PictureBox1.Location = New System.Drawing.Point(8, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lstAtualizacoes
        '
        Me.lstAtualizacoes.BackColor = System.Drawing.Color.White
        Me.lstAtualizacoes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAtualizacoes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Descricao})
        Me.lstAtualizacoes.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAtualizacoes.ForeColor = System.Drawing.Color.Blue
        Me.lstAtualizacoes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstAtualizacoes.HideSelection = False
        Me.lstAtualizacoes.Location = New System.Drawing.Point(10, 213)
        Me.lstAtualizacoes.MultiSelect = False
        Me.lstAtualizacoes.Name = "lstAtualizacoes"
        Me.lstAtualizacoes.Size = New System.Drawing.Size(545, 427)
        Me.lstAtualizacoes.TabIndex = 90
        Me.lstAtualizacoes.UseCompatibleStateImageBehavior = False
        Me.lstAtualizacoes.View = System.Windows.Forms.View.Details
        '
        'Descricao
        '
        Me.Descricao.Text = "Descrição"
        Me.Descricao.Width = 525
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolta.ForeColor = System.Drawing.Color.Green
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(455, 130)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(100, 38)
        Me.btnVolta.TabIndex = 91
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "Fechar"
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnNaoMostrar
        '
        Me.btnNaoMostrar.BackColor = System.Drawing.Color.White
        Me.btnNaoMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNaoMostrar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNaoMostrar.FlatAppearance.BorderSize = 0
        Me.btnNaoMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNaoMostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNaoMostrar.ForeColor = System.Drawing.Color.Green
        Me.btnNaoMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNaoMostrar.Location = New System.Drawing.Point(10, 130)
        Me.btnNaoMostrar.Name = "btnNaoMostrar"
        Me.btnNaoMostrar.Size = New System.Drawing.Size(130, 38)
        Me.btnNaoMostrar.TabIndex = 92
        Me.btnNaoMostrar.TabStop = False
        Me.btnNaoMostrar.Text = "Não mostrar mais esta tela"
        Me.btnNaoMostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNaoMostrar.UseVisualStyleBackColor = False
        '
        'tbOrigem
        '
        Me.tbOrigem.Location = New System.Drawing.Point(313, 73)
        Me.tbOrigem.Name = "tbOrigem"
        Me.tbOrigem.Size = New System.Drawing.Size(100, 20)
        Me.tbOrigem.TabIndex = 93
        Me.tbOrigem.Visible = False
        '
        'lbAguarde
        '
        Me.lbAguarde.AutoSize = True
        Me.lbAguarde.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAguarde.ForeColor = System.Drawing.Color.Red
        Me.lbAguarde.Location = New System.Drawing.Point(217, 130)
        Me.lbAguarde.Name = "lbAguarde"
        Me.lbAguarde.Size = New System.Drawing.Size(158, 33)
        Me.lbAguarde.TabIndex = 94
        Me.lbAguarde.Text = "Aguarde..."
        Me.lbAguarde.Visible = False
        '
        'frmAtualizacoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ClientSize = New System.Drawing.Size(565, 178)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbAguarde)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tbOrigem)
        Me.Controls.Add(Me.btnNaoMostrar)
        Me.Controls.Add(Me.btnVolta)
        Me.Controls.Add(Me.lstAtualizacoes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAtualizacoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atualizações"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lstAtualizacoes As ListView
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnNaoMostrar As Button
    Friend WithEvents Descricao As ColumnHeader
    Friend WithEvents tbOrigem As TextBox
    Friend WithEvents lbAguarde As Label
End Class
