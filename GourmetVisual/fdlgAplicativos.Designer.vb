<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgAplicativos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgAplicativos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.lstLojasApp = New System.Windows.Forms.ListView()
        Me.lstDescricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstApp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstIDClient = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstUserName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstPassword = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstAudience = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstClient_Secret = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstIDLoja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PainelIfood = New System.Windows.Forms.Panel()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbIDClientIfood = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.tbDescricao = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbApp = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PainelRappi = New System.Windows.Forms.Panel()
        Me.tbIDLoja = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbAudience = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbClientSecret = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbIDClientRappi = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbIDMerchant = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IDMerchant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.PainelIfood.SuspendLayout()
        Me.PainelRappi.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnInserir)
        Me.Panel1.Controls.Add(Me.btnGravar)
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 50)
        Me.Panel1.TabIndex = 15
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
        Me.btnInserir.Location = New System.Drawing.Point(437, 6)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(83, 38)
        Me.btnInserir.TabIndex = 106
        Me.btnInserir.TabStop = False
        Me.btnInserir.Tag = ""
        Me.btnInserir.Text = "Inserir"
        Me.btnInserir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInserir.UseVisualStyleBackColor = False
        '
        'btnGravar
        '
        Me.btnGravar.BackColor = System.Drawing.Color.Transparent
        Me.btnGravar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGravar.Enabled = False
        Me.btnGravar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGravar.FlatAppearance.BorderSize = 0
        Me.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.ForeColor = System.Drawing.Color.Black
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravar.Location = New System.Drawing.Point(535, 6)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(80, 38)
        Me.btnGravar.TabIndex = 105
        Me.btnGravar.TabStop = False
        Me.btnGravar.Tag = ""
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGravar.UseVisualStyleBackColor = False
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
        Me.btnExcluir.Location = New System.Drawing.Point(630, 6)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(80, 38)
        Me.btnExcluir.TabIndex = 104
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Tag = ""
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnVolta.Location = New System.Drawing.Point(6, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(80, 38)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstLojasApp
        '
        Me.lstLojasApp.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstLojasApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstLojasApp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstDescricao, Me.lstApp, Me.lstIDClient, Me.lstUserName, Me.lstPassword, Me.lstAudience, Me.lstClient_Secret, Me.lstIDLoja, Me.IDMerchant})
        Me.lstLojasApp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLojasApp.ForeColor = System.Drawing.Color.Navy
        Me.lstLojasApp.FullRowSelect = True
        Me.lstLojasApp.GridLines = True
        Me.lstLojasApp.HideSelection = False
        Me.lstLojasApp.Location = New System.Drawing.Point(5, 87)
        Me.lstLojasApp.MultiSelect = False
        Me.lstLojasApp.Name = "lstLojasApp"
        Me.lstLojasApp.Size = New System.Drawing.Size(230, 243)
        Me.lstLojasApp.TabIndex = 92
        Me.lstLojasApp.UseCompatibleStateImageBehavior = False
        Me.lstLojasApp.View = System.Windows.Forms.View.Details
        '
        'lstDescricao
        '
        Me.lstDescricao.Text = "Descrição"
        Me.lstDescricao.Width = 150
        '
        'lstApp
        '
        Me.lstApp.Text = "App"
        '
        'lstIDClient
        '
        Me.lstIDClient.Text = "IDClient"
        Me.lstIDClient.Width = 0
        '
        'lstUserName
        '
        Me.lstUserName.Text = "UserName"
        Me.lstUserName.Width = 0
        '
        'lstPassword
        '
        Me.lstPassword.Text = "Password"
        Me.lstPassword.Width = 0
        '
        'lstAudience
        '
        Me.lstAudience.Text = "Audience"
        Me.lstAudience.Width = 0
        '
        'lstClient_Secret
        '
        Me.lstClient_Secret.Text = "Client_Secret"
        Me.lstClient_Secret.Width = 0
        '
        'lstIDLoja
        '
        Me.lstIDLoja.Text = "IDLoja"
        Me.lstIDLoja.Width = 0
        '
        'PainelIfood
        '
        Me.PainelIfood.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PainelIfood.Controls.Add(Me.tbIDMerchant)
        Me.PainelIfood.Controls.Add(Me.Label4)
        Me.PainelIfood.Controls.Add(Me.tbPassword)
        Me.PainelIfood.Controls.Add(Me.Label2)
        Me.PainelIfood.Controls.Add(Me.tbUserName)
        Me.PainelIfood.Controls.Add(Me.Label1)
        Me.PainelIfood.Controls.Add(Me.tbIDClientIfood)
        Me.PainelIfood.Controls.Add(Me.Label87)
        Me.PainelIfood.Location = New System.Drawing.Point(241, 87)
        Me.PainelIfood.Name = "PainelIfood"
        Me.PainelIfood.Size = New System.Drawing.Size(465, 243)
        Me.PainelIfood.TabIndex = 93
        Me.PainelIfood.Visible = False
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(91, 171)
        Me.tbPassword.Multiline = True
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(367, 60)
        Me.tbPassword.TabIndex = 125
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 54)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbUserName
        '
        Me.tbUserName.Location = New System.Drawing.Point(91, 104)
        Me.tbUserName.Multiline = True
        Me.tbUserName.Name = "tbUserName"
        Me.tbUserName.Size = New System.Drawing.Size(367, 60)
        Me.tbUserName.TabIndex = 123
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 54)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "User name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbIDClientIfood
        '
        Me.tbIDClientIfood.Location = New System.Drawing.Point(91, 36)
        Me.tbIDClientIfood.Multiline = True
        Me.tbIDClientIfood.Name = "tbIDClientIfood"
        Me.tbIDClientIfood.Size = New System.Drawing.Size(367, 60)
        Me.tbIDClientIfood.TabIndex = 121
        '
        'Label87
        '
        Me.Label87.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(4, 39)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(84, 54)
        Me.Label87.TabIndex = 120
        Me.Label87.Text = "ID cliente"
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbDescricao
        '
        Me.tbDescricao.Location = New System.Drawing.Point(314, 61)
        Me.tbDescricao.Multiline = True
        Me.tbDescricao.Name = "tbDescricao"
        Me.tbDescricao.Size = New System.Drawing.Size(178, 20)
        Me.tbDescricao.TabIndex = 127
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(239, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Descrição"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbApp
        '
        Me.cbApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbApp.FormattingEnabled = True
        Me.cbApp.Location = New System.Drawing.Point(603, 60)
        Me.cbApp.Name = "cbApp"
        Me.cbApp.Size = New System.Drawing.Size(102, 21)
        Me.cbApp.TabIndex = 37
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(509, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 18)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Aplicativo"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PainelRappi
        '
        Me.PainelRappi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PainelRappi.Controls.Add(Me.tbIDLoja)
        Me.PainelRappi.Controls.Add(Me.Label8)
        Me.PainelRappi.Controls.Add(Me.tbAudience)
        Me.PainelRappi.Controls.Add(Me.Label5)
        Me.PainelRappi.Controls.Add(Me.tbClientSecret)
        Me.PainelRappi.Controls.Add(Me.Label6)
        Me.PainelRappi.Controls.Add(Me.tbIDClientRappi)
        Me.PainelRappi.Controls.Add(Me.Label7)
        Me.PainelRappi.Location = New System.Drawing.Point(242, 87)
        Me.PainelRappi.Name = "PainelRappi"
        Me.PainelRappi.Size = New System.Drawing.Size(465, 243)
        Me.PainelRappi.TabIndex = 94
        Me.PainelRappi.Visible = False
        '
        'tbIDLoja
        '
        Me.tbIDLoja.Location = New System.Drawing.Point(90, 7)
        Me.tbIDLoja.Multiline = True
        Me.tbIDLoja.Name = "tbIDLoja"
        Me.tbIDLoja.Size = New System.Drawing.Size(367, 20)
        Me.tbIDLoja.TabIndex = 129
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "ID loja"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbAudience
        '
        Me.tbAudience.Location = New System.Drawing.Point(90, 174)
        Me.tbAudience.Multiline = True
        Me.tbAudience.Name = "tbAudience"
        Me.tbAudience.Size = New System.Drawing.Size(367, 60)
        Me.tbAudience.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 54)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "Audience"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbClientSecret
        '
        Me.tbClientSecret.Location = New System.Drawing.Point(90, 105)
        Me.tbClientSecret.Multiline = True
        Me.tbClientSecret.Name = "tbClientSecret"
        Me.tbClientSecret.Size = New System.Drawing.Size(367, 60)
        Me.tbClientSecret.TabIndex = 123
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 54)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "Client secret"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbIDClientRappi
        '
        Me.tbIDClientRappi.Location = New System.Drawing.Point(90, 36)
        Me.tbIDClientRappi.Multiline = True
        Me.tbIDClientRappi.Name = "tbIDClientRappi"
        Me.tbIDClientRappi.Size = New System.Drawing.Size(367, 60)
        Me.tbIDClientRappi.TabIndex = 121
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 54)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "ID cliente"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbIDMerchant
        '
        Me.tbIDMerchant.Location = New System.Drawing.Point(91, 7)
        Me.tbIDMerchant.Multiline = True
        Me.tbIDMerchant.Name = "tbIDMerchant"
        Me.tbIDMerchant.Size = New System.Drawing.Size(367, 20)
        Me.tbIDMerchant.TabIndex = 131
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "ID Merchant"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IDMerchant
        '
        Me.IDMerchant.Text = "IDMerchant"
        Me.IDMerchant.Width = 0
        '
        'fdlgAplicativos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(713, 337)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbDescricao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PainelRappi)
        Me.Controls.Add(Me.cbApp)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PainelIfood)
        Me.Controls.Add(Me.lstLojasApp)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgAplicativos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplicativos"
        Me.Panel1.ResumeLayout(False)
        Me.PainelIfood.ResumeLayout(False)
        Me.PainelIfood.PerformLayout()
        Me.PainelRappi.ResumeLayout(False)
        Me.PainelRappi.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnInserir As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents lstLojasApp As ListView
    Friend WithEvents lstDescricao As ColumnHeader
    Friend WithEvents lstApp As ColumnHeader
    Friend WithEvents PainelIfood As Panel
    Friend WithEvents cbApp As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents tbIDClientIfood As TextBox
    Friend WithEvents Label87 As Label
    Friend WithEvents tbUserName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbDescricao As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PainelRappi As Panel
    Friend WithEvents tbAudience As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbClientSecret As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbIDClientRappi As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lstIDClient As ColumnHeader
    Friend WithEvents lstUserName As ColumnHeader
    Friend WithEvents lstPassword As ColumnHeader
    Friend WithEvents lstAudience As ColumnHeader
    Friend WithEvents lstClient_Secret As ColumnHeader
    Friend WithEvents lstIDLoja As ColumnHeader
    Friend WithEvents tbIDLoja As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbIDMerchant As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents IDMerchant As ColumnHeader
End Class
