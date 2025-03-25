<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgChat
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
        Me.tbSuporte = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.tbCliente = New System.Windows.Forms.TextBox()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbSuporte
        '
        Me.tbSuporte.BackColor = System.Drawing.SystemColors.Control
        Me.tbSuporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSuporte.Location = New System.Drawing.Point(12, 79)
        Me.tbSuporte.Multiline = True
        Me.tbSuporte.Name = "tbSuporte"
        Me.tbSuporte.Size = New System.Drawing.Size(438, 152)
        Me.tbSuporte.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Suporte"
        '
        'lbCliente
        '
        Me.lbCliente.Location = New System.Drawing.Point(12, 240)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(367, 15)
        Me.lbCliente.TabIndex = 3
        Me.lbCliente.Text = "Suporte"
        '
        'tbCliente
        '
        Me.tbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCliente.Location = New System.Drawing.Point(12, 256)
        Me.tbCliente.Multiline = True
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.Size = New System.Drawing.Size(438, 152)
        Me.tbCliente.TabIndex = 0
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVoltar.FlatAppearance.BorderSize = 0
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Black
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(13, 9)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(85, 48)
        Me.btnVoltar.TabIndex = 87
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'fdlgChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gold
        Me.ClientSize = New System.Drawing.Size(461, 418)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.tbCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSuporte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgChat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbSuporte As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbCliente As Label
    Friend WithEvents tbCliente As TextBox
    Friend WithEvents btnVoltar As Button
End Class
