<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDelivery_AreaEntrega_Entrega
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
        Me.lstAreas = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbEndereco = New System.Windows.Forms.Label()
        Me.lbBairro = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstAreas
        '
        Me.lstAreas.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lstAreas.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAreas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lstAreas.FormattingEnabled = True
        Me.lstAreas.ItemHeight = 21
        Me.lstAreas.Location = New System.Drawing.Point(12, 135)
        Me.lstAreas.Name = "lstAreas"
        Me.lstAreas.Size = New System.Drawing.Size(287, 298)
        Me.lstAreas.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Local de entrega"
        '
        'lbEndereco
        '
        Me.lbEndereco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbEndereco.Location = New System.Drawing.Point(12, 79)
        Me.lbEndereco.Name = "lbEndereco"
        Me.lbEndereco.Size = New System.Drawing.Size(287, 27)
        Me.lbEndereco.TabIndex = 24
        '
        'lbBairro
        '
        Me.lbBairro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbBairro.Location = New System.Drawing.Point(12, 109)
        Me.lbBairro.Name = "lbBairro"
        Me.lbBairro.Size = New System.Drawing.Size(287, 17)
        Me.lbBairro.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 53)
        Me.Panel1.TabIndex = 26
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(9, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(80, 40)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnConfirma.Location = New System.Drawing.Point(210, 6)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(101, 40)
        Me.btnConfirma.TabIndex = 23
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Tag = ""
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'fdlgDelivery_AreaEntrega_Entrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(314, 445)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbBairro)
        Me.Controls.Add(Me.lbEndereco)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstAreas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDelivery_AreaEntrega_Entrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Área de Entrega  -  Alterar"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstAreas As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbEndereco As Label
    Friend WithEvents lbBairro As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnConfirma As Button
End Class
