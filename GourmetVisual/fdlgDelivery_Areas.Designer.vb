﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDelivery_Areas
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
        Me.lstAreas = New System.Windows.Forms.ListBox()
        Me.tbArea = New System.Windows.Forms.TextBox()
        Me.tbTaxaEntrega = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnInserir)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 50)
        Me.Panel1.TabIndex = 22
        '
        'lstAreas
        '
        Me.lstAreas.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lstAreas.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAreas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lstAreas.FormattingEnabled = True
        Me.lstAreas.ItemHeight = 21
        Me.lstAreas.Location = New System.Drawing.Point(11, 122)
        Me.lstAreas.Name = "lstAreas"
        Me.lstAreas.Size = New System.Drawing.Size(287, 298)
        Me.lstAreas.TabIndex = 21
        '
        'tbArea
        '
        Me.tbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbArea.Location = New System.Drawing.Point(109, 56)
        Me.tbArea.Name = "tbArea"
        Me.tbArea.Size = New System.Drawing.Size(189, 26)
        Me.tbArea.TabIndex = 20
        Me.tbArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbTaxaEntrega
        '
        Me.tbTaxaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTaxaEntrega.Location = New System.Drawing.Point(109, 88)
        Me.tbTaxaEntrega.Name = "tbTaxaEntrega"
        Me.tbTaxaEntrega.Size = New System.Drawing.Size(189, 26)
        Me.tbTaxaEntrega.TabIndex = 23
        Me.tbTaxaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Area"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Taxa de Entrega"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash2
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(149, 4)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(79, 41)
        Me.btnExcluir.TabIndex = 24
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Tag = ""
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = False
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(4, 4)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(76, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnInserir
        '
        Me.btnInserir.BackColor = System.Drawing.Color.Transparent
        Me.btnInserir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnInserir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnInserir.FlatAppearance.BorderSize = 0
        Me.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInserir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInserir.ForeColor = System.Drawing.Color.Black
        Me.btnInserir.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnInserir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInserir.Location = New System.Drawing.Point(233, 4)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(76, 41)
        Me.btnInserir.TabIndex = 23
        Me.btnInserir.TabStop = False
        Me.btnInserir.Tag = ""
        Me.btnInserir.Text = "Inserir"
        Me.btnInserir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInserir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInserir.UseVisualStyleBackColor = False
        '
        'fdlgDelivery_Areas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(310, 433)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbTaxaEntrega)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstAreas)
        Me.Controls.Add(Me.tbArea)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDelivery_Areas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Areas"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnInserir As Button
    Friend WithEvents lstAreas As ListBox
    Friend WithEvents tbArea As TextBox
    Friend WithEvents tbTaxaEntrega As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
