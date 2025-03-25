<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgTerminaisPagtoDigital
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgTerminaisPagtoDigital))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.lstTerminais = New System.Windows.Forms.ListView()
        Me.lstTerminal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbSecretKey_Shipay = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbAccessKey_Shipay = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbImpressora = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbClientID_Shipay = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbTerminal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbPorta = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnGravar)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-2, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 50)
        Me.Panel1.TabIndex = 16
        '
        'btnGravar
        '
        Me.btnGravar.BackColor = System.Drawing.Color.Transparent
        Me.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGravar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGravar.FlatAppearance.BorderSize = 0
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.ForeColor = System.Drawing.Color.Black
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravar.Location = New System.Drawing.Point(458, 6)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(80, 38)
        Me.btnGravar.TabIndex = 105
        Me.btnGravar.TabStop = False
        Me.btnGravar.Tag = ""
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGravar.UseVisualStyleBackColor = False
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
        Me.btnVolta.Location = New System.Drawing.Point(7, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(80, 38)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstTerminais
        '
        Me.lstTerminais.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstTerminais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstTerminais.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstTerminal})
        Me.lstTerminais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTerminais.ForeColor = System.Drawing.Color.Navy
        Me.lstTerminais.FullRowSelect = True
        Me.lstTerminais.GridLines = True
        Me.lstTerminais.HideSelection = False
        Me.lstTerminais.Location = New System.Drawing.Point(355, 27)
        Me.lstTerminais.MultiSelect = False
        Me.lstTerminais.Name = "lstTerminais"
        Me.lstTerminais.Size = New System.Drawing.Size(168, 131)
        Me.lstTerminais.TabIndex = 93
        Me.lstTerminais.UseCompatibleStateImageBehavior = False
        Me.lstTerminais.View = System.Windows.Forms.View.Details
        '
        'lstTerminal
        '
        Me.lstTerminal.Text = "Terminal (Caixa)"
        Me.lstTerminal.Width = 150
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbSecretKey_Shipay)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.tbAccessKey_Shipay)
        Me.Panel2.Location = New System.Drawing.Point(5, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(531, 73)
        Me.Panel2.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Secret Key"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbSecretKey_Shipay
        '
        Me.tbSecretKey_Shipay.Location = New System.Drawing.Point(76, 29)
        Me.tbSecretKey_Shipay.Multiline = True
        Me.tbSecretKey_Shipay.Name = "tbSecretKey_Shipay"
        Me.tbSecretKey_Shipay.Size = New System.Drawing.Size(447, 34)
        Me.tbSecretKey_Shipay.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Access Key"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbAccessKey_Shipay
        '
        Me.tbAccessKey_Shipay.Location = New System.Drawing.Point(76, 5)
        Me.tbAccessKey_Shipay.Multiline = True
        Me.tbAccessKey_Shipay.Name = "tbAccessKey_Shipay"
        Me.tbAccessKey_Shipay.Size = New System.Drawing.Size(447, 20)
        Me.tbAccessKey_Shipay.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "por terminal (caixa)"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.tbPorta)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cbImpressora)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.tbClientID_Shipay)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.tbTerminal)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lstTerminais)
        Me.Panel3.Location = New System.Drawing.Point(5, 136)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(531, 166)
        Me.Panel3.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Impressora"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbImpressora
        '
        Me.cbImpressora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpressora.FormattingEnabled = True
        Me.cbImpressora.Location = New System.Drawing.Point(54, 125)
        Me.cbImpressora.Name = "cbImpressora"
        Me.cbImpressora.Size = New System.Drawing.Size(131, 21)
        Me.cbImpressora.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(2, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Client ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbClientID_Shipay
        '
        Me.tbClientID_Shipay.Location = New System.Drawing.Point(54, 52)
        Me.tbClientID_Shipay.Multiline = True
        Me.tbClientID_Shipay.Name = "tbClientID_Shipay"
        Me.tbClientID_Shipay.Size = New System.Drawing.Size(295, 67)
        Me.tbClientID_Shipay.TabIndex = 98
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(2, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Terminal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbTerminal
        '
        Me.tbTerminal.Location = New System.Drawing.Point(54, 27)
        Me.tbTerminal.Name = "tbTerminal"
        Me.tbTerminal.ReadOnly = True
        Me.tbTerminal.Size = New System.Drawing.Size(295, 20)
        Me.tbTerminal.TabIndex = 94
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(191, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Porta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbPorta
        '
        Me.tbPorta.Location = New System.Drawing.Point(245, 125)
        Me.tbPorta.Multiline = True
        Me.tbPorta.Name = "tbPorta"
        Me.tbPorta.Size = New System.Drawing.Size(104, 20)
        Me.tbPorta.TabIndex = 102
        '
        'fdlgTerminaisPagtoDigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(542, 308)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgTerminaisPagtoDigital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagamento Digital"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnGravar As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents lstTerminais As ListView
    Friend WithEvents lstTerminal As ColumnHeader
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents tbSecretKey_Shipay As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbAccessKey_Shipay As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents tbClientID_Shipay As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbTerminal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbImpressora As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbPorta As TextBox
End Class
