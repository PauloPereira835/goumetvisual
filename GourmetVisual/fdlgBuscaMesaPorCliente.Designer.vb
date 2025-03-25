<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgBuscaMesaPorCliente
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
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.lbQtde = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelMostra = New System.Windows.Forms.Panel()
        Me.rbData = New System.Windows.Forms.RadioButton()
        Me.rbConsumo = New System.Windows.Forms.RadioButton()
        Me.rbNada = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbConsumoTotal = New System.Windows.Forms.Label()
        Me.PanelCat = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.PanelMostra.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.Location = New System.Drawing.Point(55, 61)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(264, 26)
        Me.tbBusca.TabIndex = 0
        '
        'lbQtde
        '
        Me.lbQtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtde.ForeColor = System.Drawing.Color.Green
        Me.lbQtde.Location = New System.Drawing.Point(806, 62)
        Me.lbQtde.Name = "lbQtde"
        Me.lbQtde.Size = New System.Drawing.Size(88, 23)
        Me.lbQtde.TabIndex = 34
        Me.lbQtde.Text = "10"
        Me.lbQtde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button13.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.Blue
        Me.Button13.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button13.Location = New System.Drawing.Point(16, 3)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(105, 46)
        Me.Button13.TabIndex = 35
        Me.Button13.Text = "Volta"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.PanelMostra)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Location = New System.Drawing.Point(-5, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(927, 53)
        Me.Panel1.TabIndex = 37
        '
        'PanelMostra
        '
        Me.PanelMostra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelMostra.Controls.Add(Me.Label2)
        Me.PanelMostra.Controls.Add(Me.rbData)
        Me.PanelMostra.Controls.Add(Me.rbConsumo)
        Me.PanelMostra.Controls.Add(Me.rbNada)
        Me.PanelMostra.Location = New System.Drawing.Point(567, 10)
        Me.PanelMostra.Name = "PanelMostra"
        Me.PanelMostra.Size = New System.Drawing.Size(332, 31)
        Me.PanelMostra.TabIndex = 36
        '
        'rbData
        '
        Me.rbData.AutoSize = True
        Me.rbData.Location = New System.Drawing.Point(234, 5)
        Me.rbData.Name = "rbData"
        Me.rbData.Size = New System.Drawing.Size(96, 17)
        Me.rbData.TabIndex = 2
        Me.rbData.TabStop = True
        Me.rbData.Text = "Inicio consumo"
        Me.rbData.UseVisualStyleBackColor = True
        '
        'rbConsumo
        '
        Me.rbConsumo.AutoSize = True
        Me.rbConsumo.Location = New System.Drawing.Point(152, 5)
        Me.rbConsumo.Name = "rbConsumo"
        Me.rbConsumo.Size = New System.Drawing.Size(69, 17)
        Me.rbConsumo.TabIndex = 1
        Me.rbConsumo.TabStop = True
        Me.rbConsumo.Text = "Consumo"
        Me.rbConsumo.UseVisualStyleBackColor = True
        '
        'rbNada
        '
        Me.rbNada.AutoSize = True
        Me.rbNada.Location = New System.Drawing.Point(83, 5)
        Me.rbNada.Name = "rbNada"
        Me.rbNada.Size = New System.Drawing.Size(51, 17)
        Me.rbNada.TabIndex = 0
        Me.rbNada.TabStop = True
        Me.rbNada.Text = "Nada"
        Me.rbNada.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Busca"
        '
        'lbConsumoTotal
        '
        Me.lbConsumoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbConsumoTotal.ForeColor = System.Drawing.Color.Green
        Me.lbConsumoTotal.Location = New System.Drawing.Point(480, 61)
        Me.lbConsumoTotal.Name = "lbConsumoTotal"
        Me.lbConsumoTotal.Size = New System.Drawing.Size(201, 23)
        Me.lbConsumoTotal.TabIndex = 39
        Me.lbConsumoTotal.Text = "100,99"
        Me.lbConsumoTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelCat
        '
        Me.PanelCat.AutoScroll = True
        Me.PanelCat.BackColor = System.Drawing.Color.Black
        Me.PanelCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelCat.Location = New System.Drawing.Point(6, 94)
        Me.PanelCat.Name = "PanelCat"
        Me.PanelCat.Size = New System.Drawing.Size(893, 575)
        Me.PanelCat.TabIndex = 40
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(337, 64)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(65, 20)
        Me.tbIDVenda.TabIndex = 41
        Me.tbIDVenda.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Mostrar"
        '
        'fdlgBuscaMesaPorCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(906, 677)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.PanelCat)
        Me.Controls.Add(Me.lbConsumoTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbQtde)
        Me.Controls.Add(Me.tbBusca)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgBuscaMesaPorCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acha venda pelo cliente"
        Me.Panel1.ResumeLayout(False)
        Me.PanelMostra.ResumeLayout(False)
        Me.PanelMostra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents lbQtde As Label
    Friend WithEvents Button13 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lbConsumoTotal As Label
    Friend WithEvents PanelCat As FlowLayoutPanel
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents PanelMostra As Panel
    Friend WithEvents rbData As RadioButton
    Friend WithEvents rbConsumo As RadioButton
    Friend WithEvents rbNada As RadioButton
    Friend WithEvents Label2 As Label
End Class
