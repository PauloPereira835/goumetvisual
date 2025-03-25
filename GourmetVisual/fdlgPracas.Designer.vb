<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgPracas
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
        Me.lstPracas = New System.Windows.Forms.ListView()
        Me.IDPraca = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Praca = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Funcionario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDFuncionario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbIDFuncionario = New System.Windows.Forms.TextBox()
        Me.tbIDPraca = New System.Windows.Forms.TextBox()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.cbFuncionarios = New System.Windows.Forms.ComboBox()
        Me.tbPraca = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstPracas
        '
        Me.lstPracas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstPracas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstPracas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDPraca, Me.Praca, Me.Funcionario, Me.IDFuncionario})
        Me.lstPracas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPracas.ForeColor = System.Drawing.Color.Blue
        Me.lstPracas.FullRowSelect = True
        Me.lstPracas.GridLines = True
        Me.lstPracas.HideSelection = False
        Me.lstPracas.Location = New System.Drawing.Point(12, 185)
        Me.lstPracas.MultiSelect = False
        Me.lstPracas.Name = "lstPracas"
        Me.lstPracas.Size = New System.Drawing.Size(281, 282)
        Me.lstPracas.TabIndex = 32
        Me.lstPracas.UseCompatibleStateImageBehavior = False
        Me.lstPracas.View = System.Windows.Forms.View.Details
        '
        'IDPraca
        '
        Me.IDPraca.Text = "IDPraca"
        Me.IDPraca.Width = 0
        '
        'Praca
        '
        Me.Praca.Text = "Praça"
        Me.Praca.Width = 80
        '
        'Funcionario
        '
        Me.Funcionario.Text = "Atendente"
        Me.Funcionario.Width = 180
        '
        'IDFuncionario
        '
        Me.IDFuncionario.Text = "IDFuncionario"
        Me.IDFuncionario.Width = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-2, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 71)
        Me.Panel1.TabIndex = 51
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.Transparent
        Me.btnVolta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolta.ForeColor = System.Drawing.Color.Black
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back2
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(8, 5)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(128, 61)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.tbIDFuncionario)
        Me.Panel2.Controls.Add(Me.tbIDPraca)
        Me.Panel2.Controls.Add(Me.btnExcluir)
        Me.Panel2.Controls.Add(Me.btnAlterar)
        Me.Panel2.Controls.Add(Me.btnIncluir)
        Me.Panel2.Controls.Add(Me.cbFuncionarios)
        Me.Panel2.Controls.Add(Me.tbPraca)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(12, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(281, 103)
        Me.Panel2.TabIndex = 52
        '
        'tbIDFuncionario
        '
        Me.tbIDFuncionario.Location = New System.Drawing.Point(166, 56)
        Me.tbIDFuncionario.Name = "tbIDFuncionario"
        Me.tbIDFuncionario.Size = New System.Drawing.Size(33, 20)
        Me.tbIDFuncionario.TabIndex = 111
        Me.tbIDFuncionario.Visible = False
        '
        'tbIDPraca
        '
        Me.tbIDPraca.Location = New System.Drawing.Point(67, 56)
        Me.tbIDPraca.Name = "tbIDPraca"
        Me.tbIDPraca.Size = New System.Drawing.Size(33, 20)
        Me.tbIDPraca.TabIndex = 110
        Me.tbIDPraca.Visible = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.Transparent
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Black
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(205, 62)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(71, 30)
        Me.btnExcluir.TabIndex = 109
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'btnAlterar
        '
        Me.btnAlterar.BackColor = System.Drawing.Color.Transparent
        Me.btnAlterar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAlterar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAlterar.FlatAppearance.BorderSize = 0
        Me.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlterar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlterar.ForeColor = System.Drawing.Color.Black
        Me.btnAlterar.Image = Global.GourmetVisual.My.Resources.Resources.Save
        Me.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.Location = New System.Drawing.Point(104, 62)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(71, 32)
        Me.btnAlterar.TabIndex = 108
        Me.btnAlterar.TabStop = False
        Me.btnAlterar.Text = "Alterar"
        Me.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlterar.UseVisualStyleBackColor = False
        '
        'btnIncluir
        '
        Me.btnIncluir.BackColor = System.Drawing.Color.Transparent
        Me.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluir.FlatAppearance.BorderSize = 0
        Me.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluir.ForeColor = System.Drawing.Color.Black
        Me.btnIncluir.Image = Global.GourmetVisual.My.Resources.Resources.Plus2
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.Location = New System.Drawing.Point(2, 62)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(71, 32)
        Me.btnIncluir.TabIndex = 107
        Me.btnIncluir.TabStop = False
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'cbFuncionarios
        '
        Me.cbFuncionarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFuncionarios.FormattingEnabled = True
        Me.cbFuncionarios.Location = New System.Drawing.Point(67, 29)
        Me.cbFuncionarios.Name = "cbFuncionarios"
        Me.cbFuncionarios.Size = New System.Drawing.Size(196, 21)
        Me.cbFuncionarios.TabIndex = 106
        '
        'tbPraca
        '
        Me.tbPraca.Location = New System.Drawing.Point(67, 3)
        Me.tbPraca.Name = "tbPraca"
        Me.tbPraca.Size = New System.Drawing.Size(196, 20)
        Me.tbPraca.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Atendente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Praça"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fdlgPracas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(305, 478)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstPracas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgPracas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Praças de Atendimento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstPracas As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbPraca As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbFuncionarios As ComboBox
    Friend WithEvents IDPraca As ColumnHeader
    Friend WithEvents Praca As ColumnHeader
    Friend WithEvents Funcionario As ColumnHeader
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnIncluir As Button
    Friend WithEvents IDFuncionario As ColumnHeader
    Friend WithEvents tbIDFuncionario As TextBox
    Friend WithEvents tbIDPraca As TextBox
End Class
