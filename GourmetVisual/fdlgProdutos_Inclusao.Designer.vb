<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgProdutos_Inclusao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgProdutos_Inclusao))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.tbProduto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNCM = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.tbCodigoProduto = New System.Windows.Forms.TextBox()
        Me.cbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbVenda = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.lstAliquotas = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.tbCST_ICMS = New System.Windows.Forms.TextBox()
        Me.tbCST_PIS = New System.Windows.Forms.TextBox()
        Me.tbCFOP = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.tbCST_COFINS = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(950, 58)
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
        Me.btnVolta.Location = New System.Drawing.Point(7, 7)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(97, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Black
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(697, 8)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(99, 41)
        Me.btnConfirma.TabIndex = 23
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Tag = ""
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'tbProduto
        '
        Me.tbProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProduto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tbProduto.Location = New System.Drawing.Point(92, 63)
        Me.tbProduto.MaxLength = 25
        Me.tbProduto.Multiline = True
        Me.tbProduto.Name = "tbProduto"
        Me.tbProduto.Size = New System.Drawing.Size(700, 47)
        Me.tbProduto.TabIndex = 0
        Me.tbProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Produto"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbNCM
        '
        Me.tbNCM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNCM.Location = New System.Drawing.Point(148, 216)
        Me.tbNCM.Multiline = True
        Me.tbNCM.Name = "tbNCM"
        Me.tbNCM.Size = New System.Drawing.Size(152, 21)
        Me.tbNCM.TabIndex = 3
        Me.tbNCM.Text = "21069090"
        Me.tbNCM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Navy
        Me.Label22.Location = New System.Drawing.Point(62, 219)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(85, 16)
        Me.Label22.TabIndex = 162
        Me.Label22.Text = "Código NCM"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button10
        '
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button10.FlatAppearance.BorderSize = 2
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = CType(resources.GetObject("Button10.Image"), System.Drawing.Image)
        Me.Button10.Location = New System.Drawing.Point(272, 157)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(28, 26)
        Me.Button10.TabIndex = 184
        Me.Button10.TabStop = False
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Navy
        Me.Label42.Location = New System.Drawing.Point(17, 160)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(130, 19)
        Me.Label42.TabIndex = 183
        Me.Label42.Text = "Código Produto"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCodigoProduto
        '
        Me.tbCodigoProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigoProduto.Location = New System.Drawing.Point(148, 158)
        Me.tbCodigoProduto.Multiline = True
        Me.tbCodigoProduto.Name = "tbCodigoProduto"
        Me.tbCodigoProduto.Size = New System.Drawing.Size(123, 24)
        Me.tbCodigoProduto.TabIndex = 1
        Me.tbCodigoProduto.TabStop = False
        Me.tbCodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbGrupo
        '
        Me.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGrupo.FormattingEnabled = True
        Me.cbGrupo.ItemHeight = 16
        Me.cbGrupo.Location = New System.Drawing.Point(148, 127)
        Me.cbGrupo.Name = "cbGrupo"
        Me.cbGrupo.Size = New System.Drawing.Size(282, 24)
        Me.cbGrupo.TabIndex = 185
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(89, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 16)
        Me.Label10.TabIndex = 186
        Me.Label10.Text = "Grupo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Navy
        Me.Label47.Location = New System.Drawing.Point(10, 189)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(135, 21)
        Me.Label47.TabIndex = 193
        Me.Label47.Text = "Categoria"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbCategoria
        '
        Me.cbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.ItemHeight = 13
        Me.cbCategoria.Location = New System.Drawing.Point(148, 189)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(152, 21)
        Me.cbCategoria.TabIndex = 190
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(44, 253)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(102, 15)
        Me.Label23.TabIndex = 197
        Me.Label23.Text = "Valor de Venda"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbVenda
        '
        Me.tbVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbVenda.Location = New System.Drawing.Point(148, 243)
        Me.tbVenda.Name = "tbVenda"
        Me.tbVenda.Size = New System.Drawing.Size(152, 29)
        Me.tbVenda.TabIndex = 8
        Me.tbVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Navy
        Me.Label51.Location = New System.Drawing.Point(94, 4)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(126, 16)
        Me.Label51.TabIndex = 203
        Me.Label51.Text = "Aliquota de Venda"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstAliquotas
        '
        Me.lstAliquotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstAliquotas.FormattingEnabled = True
        Me.lstAliquotas.ItemHeight = 13
        Me.lstAliquotas.Location = New System.Drawing.Point(222, 3)
        Me.lstAliquotas.Name = "lstAliquotas"
        Me.lstAliquotas.Size = New System.Drawing.Size(96, 21)
        Me.lstAliquotas.TabIndex = 198
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Navy
        Me.Label50.Location = New System.Drawing.Point(151, 33)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(70, 19)
        Me.Label50.TabIndex = 204
        Me.Label50.Text = "CST ICMS"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Navy
        Me.Label49.Location = New System.Drawing.Point(159, 62)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(62, 19)
        Me.Label49.TabIndex = 205
        Me.Label49.Text = "CST PIS"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Navy
        Me.Label48.Location = New System.Drawing.Point(175, 115)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(45, 19)
        Me.Label48.TabIndex = 206
        Me.Label48.Text = "CFOP"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCST_ICMS
        '
        Me.tbCST_ICMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCST_ICMS.Location = New System.Drawing.Point(222, 31)
        Me.tbCST_ICMS.Multiline = True
        Me.tbCST_ICMS.Name = "tbCST_ICMS"
        Me.tbCST_ICMS.Size = New System.Drawing.Size(96, 21)
        Me.tbCST_ICMS.TabIndex = 10
        Me.tbCST_ICMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCST_PIS
        '
        Me.tbCST_PIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCST_PIS.Location = New System.Drawing.Point(222, 61)
        Me.tbCST_PIS.Multiline = True
        Me.tbCST_PIS.Name = "tbCST_PIS"
        Me.tbCST_PIS.Size = New System.Drawing.Size(96, 21)
        Me.tbCST_PIS.TabIndex = 11
        Me.tbCST_PIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCFOP
        '
        Me.tbCFOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCFOP.Location = New System.Drawing.Point(222, 115)
        Me.tbCFOP.Multiline = True
        Me.tbCFOP.Name = "tbCFOP"
        Me.tbCFOP.Size = New System.Drawing.Size(96, 21)
        Me.tbCFOP.TabIndex = 13
        Me.tbCFOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Navy
        Me.Label44.Location = New System.Drawing.Point(133, 89)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(89, 19)
        Me.Label44.TabIndex = 207
        Me.Label44.Text = "CST COFINS"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCST_COFINS
        '
        Me.tbCST_COFINS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCST_COFINS.Location = New System.Drawing.Point(222, 88)
        Me.tbCST_COFINS.Multiline = True
        Me.tbCST_COFINS.Name = "tbCST_COFINS"
        Me.tbCST_COFINS.Size = New System.Drawing.Size(96, 21)
        Me.tbCST_COFINS.TabIndex = 12
        Me.tbCST_COFINS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label48)
        Me.Panel2.Controls.Add(Me.Label49)
        Me.Panel2.Controls.Add(Me.tbCFOP)
        Me.Panel2.Controls.Add(Me.Label50)
        Me.Panel2.Controls.Add(Me.Label44)
        Me.Panel2.Controls.Add(Me.Label51)
        Me.Panel2.Controls.Add(Me.tbCST_COFINS)
        Me.Panel2.Controls.Add(Me.tbCST_PIS)
        Me.Panel2.Controls.Add(Me.lstAliquotas)
        Me.Panel2.Controls.Add(Me.tbCST_ICMS)
        Me.Panel2.Location = New System.Drawing.Point(463, 127)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(325, 145)
        Me.Panel2.TabIndex = 208
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 21)
        Me.Label1.TabIndex = 209
        Me.Label1.Text = "Tributos"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(301, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 21)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "( local de impressão pedidos )"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fdlgProdutos_Inclusao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 281)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.tbVenda)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.cbCategoria)
        Me.Controls.Add(Me.cbGrupo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.tbCodigoProduto)
        Me.Controls.Add(Me.tbNCM)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tbProduto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgProdutos_Inclusao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inclusão de Produto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents tbProduto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbNCM As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Label42 As Label
    Friend WithEvents tbCodigoProduto As TextBox
    Friend WithEvents cbGrupo As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents tbVenda As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents lstAliquotas As ComboBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents tbCST_ICMS As TextBox
    Friend WithEvents tbCST_PIS As TextBox
    Friend WithEvents tbCFOP As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents tbCST_COFINS As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
