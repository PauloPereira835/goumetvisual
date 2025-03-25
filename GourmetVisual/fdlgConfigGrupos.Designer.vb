<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgConfigGrupos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelGrupos = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbBotao = New System.Windows.Forms.Label()
        Me.btnLimpa = New System.Windows.Forms.Button()
        Me.btnInclui = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridGrupos = New System.Windows.Forms.DataGridView()
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbLinha = New System.Windows.Forms.TextBox()
        Me.tbLinhaBotao = New System.Windows.Forms.TextBox()
        Me.tbCodigoGrupo = New System.Windows.Forms.TextBox()
        Me.tbPagina = New System.Windows.Forms.TextBox()
        Me.btnPagina1 = New System.Windows.Forms.Button()
        Me.btnPagina2 = New System.Windows.Forms.Button()
        Me.btnPagina3 = New System.Windows.Forms.Button()
        Me.btnPagina4 = New System.Windows.Forms.Button()
        CType(Me.GridGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelGrupos
        '
        Me.PanelGrupos.BackColor = System.Drawing.Color.Silver
        Me.PanelGrupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelGrupos.Location = New System.Drawing.Point(245, 44)
        Me.PanelGrupos.Name = "PanelGrupos"
        Me.PanelGrupos.Size = New System.Drawing.Size(683, 492)
        Me.PanelGrupos.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(5, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 34)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Volta"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(269, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 24)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Botão"
        '
        'lbBotao
        '
        Me.lbBotao.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBotao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbBotao.Location = New System.Drawing.Point(397, 10)
        Me.lbBotao.Name = "lbBotao"
        Me.lbBotao.Size = New System.Drawing.Size(221, 24)
        Me.lbBotao.TabIndex = 22
        '
        'btnLimpa
        '
        Me.btnLimpa.Location = New System.Drawing.Point(87, 7)
        Me.btnLimpa.Name = "btnLimpa"
        Me.btnLimpa.Size = New System.Drawing.Size(75, 34)
        Me.btnLimpa.TabIndex = 23
        Me.btnLimpa.Text = "Limpa"
        Me.btnLimpa.UseVisualStyleBackColor = True
        '
        'btnInclui
        '
        Me.btnInclui.Location = New System.Drawing.Point(166, 7)
        Me.btnInclui.Name = "btnInclui"
        Me.btnInclui.Size = New System.Drawing.Size(75, 34)
        Me.btnInclui.TabIndex = 24
        Me.btnInclui.Text = "Inclui Grupo"
        Me.btnInclui.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(9, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Categorias"
        '
        'GridGrupos
        '
        Me.GridGrupos.AllowUserToAddRows = False
        Me.GridGrupos.AllowUserToDeleteRows = False
        Me.GridGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridGrupos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Grupo, Me.CodigoGrupo})
        Me.GridGrupos.Location = New System.Drawing.Point(9, 112)
        Me.GridGrupos.MultiSelect = False
        Me.GridGrupos.Name = "GridGrupos"
        Me.GridGrupos.ReadOnly = True
        Me.GridGrupos.RowHeadersVisible = False
        Me.GridGrupos.Size = New System.Drawing.Size(225, 326)
        Me.GridGrupos.TabIndex = 0
        '
        'Grupo
        '
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 205
        '
        'CodigoGrupo
        '
        Me.CodigoGrupo.HeaderText = "CodigoGrupo"
        Me.CodigoGrupo.Name = "CodigoGrupo"
        Me.CodigoGrupo.ReadOnly = True
        Me.CodigoGrupo.Visible = False
        '
        'tbLinha
        '
        Me.tbLinha.Location = New System.Drawing.Point(205, 89)
        Me.tbLinha.Name = "tbLinha"
        Me.tbLinha.Size = New System.Drawing.Size(29, 20)
        Me.tbLinha.TabIndex = 0
        Me.tbLinha.Visible = False
        '
        'tbLinhaBotao
        '
        Me.tbLinhaBotao.BackColor = System.Drawing.SystemColors.Control
        Me.tbLinhaBotao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbLinhaBotao.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLinhaBotao.ForeColor = System.Drawing.Color.Red
        Me.tbLinhaBotao.Location = New System.Drawing.Point(335, 9)
        Me.tbLinhaBotao.Name = "tbLinhaBotao"
        Me.tbLinhaBotao.Size = New System.Drawing.Size(62, 22)
        Me.tbLinhaBotao.TabIndex = 26
        '
        'tbCodigoGrupo
        '
        Me.tbCodigoGrupo.Location = New System.Drawing.Point(153, 89)
        Me.tbCodigoGrupo.Name = "tbCodigoGrupo"
        Me.tbCodigoGrupo.Size = New System.Drawing.Size(29, 20)
        Me.tbCodigoGrupo.TabIndex = 27
        Me.tbCodigoGrupo.Visible = False
        '
        'tbPagina
        '
        Me.tbPagina.Location = New System.Drawing.Point(101, 89)
        Me.tbPagina.Name = "tbPagina"
        Me.tbPagina.Size = New System.Drawing.Size(29, 20)
        Me.tbPagina.TabIndex = 28
        Me.tbPagina.Visible = False
        '
        'btnPagina1
        '
        Me.btnPagina1.Location = New System.Drawing.Point(683, 7)
        Me.btnPagina1.Name = "btnPagina1"
        Me.btnPagina1.Size = New System.Drawing.Size(47, 34)
        Me.btnPagina1.TabIndex = 53
        Me.btnPagina1.Text = "1"
        Me.btnPagina1.UseVisualStyleBackColor = True
        '
        'btnPagina2
        '
        Me.btnPagina2.Location = New System.Drawing.Point(736, 7)
        Me.btnPagina2.Name = "btnPagina2"
        Me.btnPagina2.Size = New System.Drawing.Size(47, 34)
        Me.btnPagina2.TabIndex = 54
        Me.btnPagina2.Text = "2"
        Me.btnPagina2.UseVisualStyleBackColor = True
        '
        'btnPagina3
        '
        Me.btnPagina3.Location = New System.Drawing.Point(789, 7)
        Me.btnPagina3.Name = "btnPagina3"
        Me.btnPagina3.Size = New System.Drawing.Size(47, 34)
        Me.btnPagina3.TabIndex = 55
        Me.btnPagina3.Text = "3"
        Me.btnPagina3.UseVisualStyleBackColor = True
        '
        'btnPagina4
        '
        Me.btnPagina4.Location = New System.Drawing.Point(842, 7)
        Me.btnPagina4.Name = "btnPagina4"
        Me.btnPagina4.Size = New System.Drawing.Size(47, 34)
        Me.btnPagina4.TabIndex = 56
        Me.btnPagina4.Text = "4"
        Me.btnPagina4.UseVisualStyleBackColor = True
        '
        'fdlgConfigGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPagina4)
        Me.Controls.Add(Me.btnPagina3)
        Me.Controls.Add(Me.btnPagina2)
        Me.Controls.Add(Me.btnPagina1)
        Me.Controls.Add(Me.tbPagina)
        Me.Controls.Add(Me.tbCodigoGrupo)
        Me.Controls.Add(Me.tbLinhaBotao)
        Me.Controls.Add(Me.tbLinha)
        Me.Controls.Add(Me.GridGrupos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnInclui)
        Me.Controls.Add(Me.btnLimpa)
        Me.Controls.Add(Me.lbBotao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PanelGrupos)
        Me.Name = "fdlgConfigGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração  Grupos"
        CType(Me.GridGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelGrupos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbBotao As System.Windows.Forms.Label
    Friend WithEvents btnLimpa As System.Windows.Forms.Button
    Friend WithEvents btnInclui As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridGrupos As System.Windows.Forms.DataGridView
    Friend WithEvents tbLinha As System.Windows.Forms.TextBox
    Friend WithEvents tbLinhaBotao As System.Windows.Forms.TextBox
    Friend WithEvents tbCodigoGrupo As System.Windows.Forms.TextBox
    Friend WithEvents tbPagina As System.Windows.Forms.TextBox
    Friend WithEvents btnPagina1 As System.Windows.Forms.Button
    Friend WithEvents btnPagina2 As System.Windows.Forms.Button
    Friend WithEvents btnPagina3 As System.Windows.Forms.Button
    Friend WithEvents btnPagina4 As System.Windows.Forms.Button
    Friend WithEvents Grupo As DataGridViewTextBoxColumn
    Friend WithEvents CodigoGrupo As DataGridViewTextBoxColumn
End Class
