<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgMesas
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
        Me.lstMesas = New System.Windows.Forms.ListView()
        Me.NumMesa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Staus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Setor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Praca = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSetor = New System.Windows.Forms.ComboBox()
        Me.tbAte = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbDe = New System.Windows.Forms.TextBox()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbPraca = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(345, 69)
        Me.Panel1.TabIndex = 15
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
        Me.btnVolta.Size = New System.Drawing.Size(128, 59)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstMesas
        '
        Me.lstMesas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstMesas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NumMesa, Me.Staus, Me.Setor, Me.Praca})
        Me.lstMesas.ForeColor = System.Drawing.Color.Blue
        Me.lstMesas.FullRowSelect = True
        Me.lstMesas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMesas.Location = New System.Drawing.Point(12, 247)
        Me.lstMesas.MultiSelect = False
        Me.lstMesas.Name = "lstMesas"
        Me.lstMesas.Size = New System.Drawing.Size(309, 311)
        Me.lstMesas.TabIndex = 24
        Me.lstMesas.UseCompatibleStateImageBehavior = False
        Me.lstMesas.View = System.Windows.Forms.View.Details
        '
        'NumMesa
        '
        Me.NumMesa.Text = ""
        Me.NumMesa.Width = 80
        '
        'Staus
        '
        Me.Staus.Text = "Tipo"
        '
        'Setor
        '
        Me.Setor.Text = "Setor"
        Me.Setor.Width = 75
        '
        'Praca
        '
        Me.Praca.Text = "Praça"
        Me.Praca.Width = 70
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.Label5)
        Me.Panel.Controls.Add(Me.cbPraca)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.cbStatus)
        Me.Panel.Controls.Add(Me.btnExcluir)
        Me.Panel.Controls.Add(Me.btnAlterar)
        Me.Panel.Controls.Add(Me.btnIncluir)
        Me.Panel.Controls.Add(Me.Label4)
        Me.Panel.Controls.Add(Me.cbSetor)
        Me.Panel.Controls.Add(Me.tbAte)
        Me.Panel.Controls.Add(Me.Label3)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.tbDe)
        Me.Panel.Location = New System.Drawing.Point(12, 74)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(309, 162)
        Me.Panel.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Tipo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(104, 85)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(168, 21)
        Me.cbStatus.TabIndex = 42
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
        Me.btnExcluir.Location = New System.Drawing.Point(231, 126)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(71, 30)
        Me.btnExcluir.TabIndex = 41
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
        Me.btnAlterar.Location = New System.Drawing.Point(116, 126)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(71, 32)
        Me.btnAlterar.TabIndex = 40
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
        Me.btnIncluir.Location = New System.Drawing.Point(2, 126)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(71, 32)
        Me.btnIncluir.TabIndex = 39
        Me.btnIncluir.TabStop = False
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Setor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbSetor
        '
        Me.cbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSetor.FormattingEnabled = True
        Me.cbSetor.Location = New System.Drawing.Point(104, 32)
        Me.cbSetor.Name = "cbSetor"
        Me.cbSetor.Size = New System.Drawing.Size(168, 21)
        Me.cbSetor.TabIndex = 37
        '
        'tbAte
        '
        Me.tbAte.Location = New System.Drawing.Point(203, 6)
        Me.tbAte.Name = "tbAte"
        Me.tbAte.Size = New System.Drawing.Size(69, 20)
        Me.tbAte.TabIndex = 29
        Me.tbAte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "até "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Sequencia:   de"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbDe
        '
        Me.tbDe.Location = New System.Drawing.Point(104, 6)
        Me.tbDe.Name = "tbDe"
        Me.tbDe.Size = New System.Drawing.Size(69, 20)
        Me.tbDe.TabIndex = 0
        Me.tbDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbTotal
        '
        Me.lbTotal.AutoSize = True
        Me.lbTotal.Location = New System.Drawing.Point(11, 563)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(133, 13)
        Me.lbTotal.TabIndex = 26
        Me.lbTotal.Text = "Total de Mesas/Cartões: 0"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Praça"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbPraca
        '
        Me.cbPraca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPraca.FormattingEnabled = True
        Me.cbPraca.Location = New System.Drawing.Point(104, 58)
        Me.cbPraca.Name = "cbPraca"
        Me.cbPraca.Size = New System.Drawing.Size(168, 21)
        Me.cbPraca.TabIndex = 44
        '
        'fdlgMesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(334, 577)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.lstMesas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgMesas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mesas / Cartões"
        Me.Panel1.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents lstMesas As ListView
    Friend WithEvents Panel As Panel
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnIncluir As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cbSetor As ComboBox
    Friend WithEvents tbAte As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbDe As TextBox
    Friend WithEvents lbTotal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents NumMesa As ColumnHeader
    Friend WithEvents Staus As ColumnHeader
    Friend WithEvents Setor As ColumnHeader
    Friend WithEvents Praca As ColumnHeader
    Friend WithEvents Label5 As Label
    Friend WithEvents cbPraca As ComboBox
End Class
