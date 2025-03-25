<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDelivery_CEP_NaoEncontrado
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
        Me.lbMensagem = New System.Windows.Forms.Label()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.Label = New System.Windows.Forms.Label()
        Me.cbArea = New System.Windows.Forms.ComboBox()
        Me.chkVincular = New System.Windows.Forms.RadioButton()
        Me.chkCadastrar = New System.Windows.Forms.RadioButton()
        Me.lbDescricao = New System.Windows.Forms.Label()
        Me.lbBairro = New System.Windows.Forms.Label()
        Me.lbCEP = New System.Windows.Forms.Label()
        Me.lbCidade = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbEstado = New System.Windows.Forms.Label()
        Me.lbLogradouro = New System.Windows.Forms.Label()
        Me.lbTipoLogradouro = New System.Windows.Forms.Label()
        Me.btnAltera = New System.Windows.Forms.Button()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.lstRuas = New System.Windows.Forms.ListView()
        Me.IDRua = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Logradouro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bairro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cidade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Area = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbIDRua = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbDistancia = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lbMensagem)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(707, 49)
        Me.Panel1.TabIndex = 23
        '
        'lbMensagem
        '
        Me.lbMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensagem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMensagem.Location = New System.Drawing.Point(132, 3)
        Me.lbMensagem.Name = "lbMensagem"
        Me.lbMensagem.Size = New System.Drawing.Size(483, 41)
        Me.lbMensagem.TabIndex = 26
        Me.lbMensagem.Text = "CEP não encontrado no cadastro de logradouros. O que você deseja fazer?"
        Me.lbMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbMensagem.Visible = False
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
        Me.btnVolta.Location = New System.Drawing.Point(7, 4)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(76, 41)
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
        Me.btnConfirma.Location = New System.Drawing.Point(535, 222)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(112, 41)
        Me.btnConfirma.TabIndex = 24
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'Label
        '
        Me.Label.ForeColor = System.Drawing.Color.Black
        Me.Label.Location = New System.Drawing.Point(400, 195)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(29, 15)
        Me.Label.TabIndex = 52
        Me.Label.Text = "Area"
        Me.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbArea
        '
        Me.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArea.FormattingEnabled = True
        Me.cbArea.Location = New System.Drawing.Point(430, 193)
        Me.cbArea.Name = "cbArea"
        Me.cbArea.Size = New System.Drawing.Size(217, 21)
        Me.cbArea.TabIndex = 51
        Me.cbArea.TabStop = False
        '
        'chkVincular
        '
        Me.chkVincular.AutoSize = True
        Me.chkVincular.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVincular.Location = New System.Drawing.Point(19, 232)
        Me.chkVincular.Name = "chkVincular"
        Me.chkVincular.Size = New System.Drawing.Size(446, 24)
        Me.chkVincular.TabIndex = 26
        Me.chkVincular.TabStop = True
        Me.chkVincular.Text = "VINCULAR este CEP a um logradouro já cadastrado"
        Me.chkVincular.UseVisualStyleBackColor = True
        '
        'chkCadastrar
        '
        Me.chkCadastrar.AutoSize = True
        Me.chkCadastrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCadastrar.Location = New System.Drawing.Point(19, 189)
        Me.chkCadastrar.Name = "chkCadastrar"
        Me.chkCadastrar.Size = New System.Drawing.Size(322, 24)
        Me.chkCadastrar.TabIndex = 25
        Me.chkCadastrar.TabStop = True
        Me.chkCadastrar.Text = "CADASTRAR este logradouro + CEP"
        Me.chkCadastrar.UseVisualStyleBackColor = True
        '
        'lbDescricao
        '
        Me.lbDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescricao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbDescricao.Location = New System.Drawing.Point(120, 72)
        Me.lbDescricao.Name = "lbDescricao"
        Me.lbDescricao.Size = New System.Drawing.Size(564, 19)
        Me.lbDescricao.TabIndex = 26
        Me.lbDescricao.Text = "Label1"
        '
        'lbBairro
        '
        Me.lbBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBairro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbBairro.Location = New System.Drawing.Point(120, 97)
        Me.lbBairro.Name = "lbBairro"
        Me.lbBairro.Size = New System.Drawing.Size(564, 19)
        Me.lbBairro.TabIndex = 27
        Me.lbBairro.Text = "Label1"
        '
        'lbCEP
        '
        Me.lbCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCEP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCEP.Location = New System.Drawing.Point(117, 48)
        Me.lbCEP.Name = "lbCEP"
        Me.lbCEP.Size = New System.Drawing.Size(564, 23)
        Me.lbCEP.TabIndex = 28
        Me.lbCEP.Text = "Label1"
        '
        'lbCidade
        '
        Me.lbCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCidade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCidade.Location = New System.Drawing.Point(120, 122)
        Me.lbCidade.Name = "lbCidade"
        Me.lbCidade.Size = New System.Drawing.Size(234, 19)
        Me.lbCidade.TabIndex = 29
        Me.lbCidade.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(352, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 23)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "/"
        '
        'lbEstado
        '
        Me.lbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbEstado.Location = New System.Drawing.Point(367, 122)
        Me.lbEstado.Name = "lbEstado"
        Me.lbEstado.Size = New System.Drawing.Size(65, 19)
        Me.lbEstado.TabIndex = 31
        Me.lbEstado.Text = "SP"
        '
        'lbLogradouro
        '
        Me.lbLogradouro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLogradouro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbLogradouro.Location = New System.Drawing.Point(570, 351)
        Me.lbLogradouro.Name = "lbLogradouro"
        Me.lbLogradouro.Size = New System.Drawing.Size(54, 23)
        Me.lbLogradouro.TabIndex = 32
        Me.lbLogradouro.Text = "Label1"
        Me.lbLogradouro.Visible = False
        '
        'lbTipoLogradouro
        '
        Me.lbTipoLogradouro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipoLogradouro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTipoLogradouro.Location = New System.Drawing.Point(569, 319)
        Me.lbTipoLogradouro.Name = "lbTipoLogradouro"
        Me.lbTipoLogradouro.Size = New System.Drawing.Size(54, 23)
        Me.lbTipoLogradouro.TabIndex = 33
        Me.lbTipoLogradouro.Text = "Label1"
        Me.lbTipoLogradouro.Visible = False
        '
        'btnAltera
        '
        Me.btnAltera.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAltera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAltera.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAltera.FlatAppearance.BorderSize = 0
        Me.btnAltera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAltera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAltera.ForeColor = System.Drawing.Color.Black
        Me.btnAltera.Image = Global.GourmetVisual.My.Resources.Resources.Refresh
        Me.btnAltera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAltera.Location = New System.Drawing.Point(2, 66)
        Me.btnAltera.Name = "btnAltera"
        Me.btnAltera.Size = New System.Drawing.Size(32, 26)
        Me.btnAltera.TabIndex = 27
        Me.btnAltera.TabStop = False
        Me.btnAltera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAltera.UseVisualStyleBackColor = False
        '
        'lbStatus
        '
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbStatus.Location = New System.Drawing.Point(570, 383)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(54, 23)
        Me.lbStatus.TabIndex = 34
        Me.lbStatus.Text = "Label1"
        Me.lbStatus.Visible = False
        '
        'lstRuas
        '
        Me.lstRuas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstRuas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstRuas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDRua, Me.Logradouro, Me.Bairro, Me.Cidade, Me.Estado, Me.Area})
        Me.lstRuas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRuas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lstRuas.FullRowSelect = True
        Me.lstRuas.GridLines = True
        Me.lstRuas.HideSelection = False
        Me.lstRuas.Location = New System.Drawing.Point(19, 307)
        Me.lstRuas.MultiSelect = False
        Me.lstRuas.Name = "lstRuas"
        Me.lstRuas.Size = New System.Drawing.Size(543, 159)
        Me.lstRuas.TabIndex = 35
        Me.lstRuas.TabStop = False
        Me.lstRuas.UseCompatibleStateImageBehavior = False
        Me.lstRuas.View = System.Windows.Forms.View.Details
        '
        'IDRua
        '
        Me.IDRua.Text = "IDRua"
        Me.IDRua.Width = 0
        '
        'Logradouro
        '
        Me.Logradouro.Text = "Logradouro"
        Me.Logradouro.Width = 340
        '
        'Bairro
        '
        Me.Bairro.Text = "Bairro"
        Me.Bairro.Width = 180
        '
        'Cidade
        '
        Me.Cidade.Text = "Cidade"
        Me.Cidade.Width = 0
        '
        'Estado
        '
        Me.Estado.Text = "Estado"
        Me.Estado.Width = 0
        '
        'Area
        '
        Me.Area.Text = "Area"
        Me.Area.Width = 0
        '
        'tbBusca
        '
        Me.tbBusca.Location = New System.Drawing.Point(121, 281)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(314, 20)
        Me.tbBusca.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(15, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 18)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Busca por nome"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbIDRua
        '
        Me.tbIDRua.Location = New System.Drawing.Point(482, 282)
        Me.tbIDRua.Name = "tbIDRua"
        Me.tbIDRua.Size = New System.Drawing.Size(58, 20)
        Me.tbIDRua.TabIndex = 38
        Me.tbIDRua.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(49, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 23)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "CEP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(34, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 23)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Logradouro"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(34, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 23)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Bairro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(6, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 23)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Cidade/Estado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbDistancia
        '
        Me.lbDistancia.BackColor = System.Drawing.Color.Transparent
        Me.lbDistancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDistancia.ForeColor = System.Drawing.Color.Green
        Me.lbDistancia.Location = New System.Drawing.Point(15, 147)
        Me.lbDistancia.Name = "lbDistancia"
        Me.lbDistancia.Size = New System.Drawing.Size(649, 19)
        Me.lbDistancia.TabIndex = 47
        Me.lbDistancia.Text = "Distância: 10 KM  /  Tempo médio: 40 Minutos"
        '
        'fdlgDelivery_CEP_NaoEncontrado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(666, 499)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.lbDistancia)
        Me.Controls.Add(Me.cbArea)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkVincular)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkCadastrar)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnConfirma)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbTipoLogradouro)
        Me.Controls.Add(Me.btnAltera)
        Me.Controls.Add(Me.lstRuas)
        Me.Controls.Add(Me.lbEstado)
        Me.Controls.Add(Me.lbLogradouro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.lbCidade)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbCEP)
        Me.Controls.Add(Me.tbIDRua)
        Me.Controls.Add(Me.lbBairro)
        Me.Controls.Add(Me.lbDescricao)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgDelivery_CEP_NaoEncontrado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CEP não encontrado"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbMensagem As Label
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents chkVincular As RadioButton
    Friend WithEvents chkCadastrar As RadioButton
    Friend WithEvents lbDescricao As Label
    Friend WithEvents lbBairro As Label
    Friend WithEvents lbCEP As Label
    Friend WithEvents lbCidade As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbEstado As Label
    Friend WithEvents lbLogradouro As Label
    Friend WithEvents lbTipoLogradouro As Label
    Friend WithEvents btnAltera As Button
    Friend WithEvents lbStatus As Label
    Friend WithEvents lstRuas As ListView
    Friend WithEvents IDRua As ColumnHeader
    Friend WithEvents Logradouro As ColumnHeader
    Friend WithEvents Bairro As ColumnHeader
    Friend WithEvents Cidade As ColumnHeader
    Friend WithEvents Estado As ColumnHeader
    Friend WithEvents Area As ColumnHeader
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbIDRua As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label As Label
    Friend WithEvents cbArea As ComboBox
    Friend WithEvents lbDistancia As Label
End Class
