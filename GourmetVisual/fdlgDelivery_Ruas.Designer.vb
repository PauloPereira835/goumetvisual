<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgDelivery_Ruas
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgDelivery_Ruas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbMensagem = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnInserir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbOrigem = New System.Windows.Forms.TextBox()
        Me.tbCidade = New System.Windows.Forms.TextBox()
        Me.tbEstado = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbArea = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbBairro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbLogradouro = New System.Windows.Forms.TextBox()
        Me.btnConsultaRua = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.tbCEP = New System.Windows.Forms.TextBox()
        Me.lstRuas = New System.Windows.Forms.ListView()
        Me.IDRua = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Logradouro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bairro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cidade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Area = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstCEPs = New System.Windows.Forms.ListView()
        Me.IDRuaCEP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CEP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbQtdeRuas = New System.Windows.Forms.Label()
        Me.btnGoogle = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbTempo = New System.Windows.Forms.Label()
        Me.lbDistancia = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbResultado = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lbMensagem)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnInserir)
        Me.Panel1.Location = New System.Drawing.Point(-1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(684, 50)
        Me.Panel1.TabIndex = 22
        '
        'lbMensagem
        '
        Me.lbMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensagem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMensagem.Location = New System.Drawing.Point(95, 10)
        Me.lbMensagem.Name = "lbMensagem"
        Me.lbMensagem.Size = New System.Drawing.Size(285, 27)
        Me.lbMensagem.TabIndex = 26
        Me.lbMensagem.Text = "Informe a ÁREA deste logradouro, para cobrança da taxa de entrega"
        Me.lbMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbMensagem.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(400, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 41)
        Me.Button1.TabIndex = 25
        Me.Button1.TabStop = False
        Me.Button1.Tag = ""
        Me.Button1.Text = "Alterar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.White
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Black
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash2
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(491, 4)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(84, 41)
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
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolta.ForeColor = System.Drawing.Color.Black
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(5, 4)
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
        Me.btnInserir.BackColor = System.Drawing.Color.White
        Me.btnInserir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnInserir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnInserir.FlatAppearance.BorderSize = 0
        Me.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInserir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInserir.ForeColor = System.Drawing.Color.Black
        Me.btnInserir.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnInserir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInserir.Location = New System.Drawing.Point(581, 4)
        Me.btnInserir.Name = "btnInserir"
        Me.btnInserir.Size = New System.Drawing.Size(81, 41)
        Me.btnInserir.TabIndex = 23
        Me.btnInserir.TabStop = False
        Me.btnInserir.Tag = ""
        Me.btnInserir.Text = "Inserir"
        Me.btnInserir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInserir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInserir.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.tbOrigem)
        Me.Panel2.Controls.Add(Me.tbCidade)
        Me.Panel2.Controls.Add(Me.tbEstado)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.cbArea)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbBairro)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tbLogradouro)
        Me.Panel2.Location = New System.Drawing.Point(3, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(668, 82)
        Me.Panel2.TabIndex = 35
        Me.Panel2.TabStop = True
        '
        'tbOrigem
        '
        Me.tbOrigem.Location = New System.Drawing.Point(338, 41)
        Me.tbOrigem.Name = "tbOrigem"
        Me.tbOrigem.Size = New System.Drawing.Size(22, 20)
        Me.tbOrigem.TabIndex = 54
        Me.tbOrigem.TabStop = False
        Me.tbOrigem.Visible = False
        '
        'tbCidade
        '
        Me.tbCidade.Location = New System.Drawing.Point(89, 41)
        Me.tbCidade.Name = "tbCidade"
        Me.tbCidade.Size = New System.Drawing.Size(203, 20)
        Me.tbCidade.TabIndex = 45
        Me.tbCidade.TabStop = False
        '
        'tbEstado
        '
        Me.tbEstado.Location = New System.Drawing.Point(305, 41)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.Size = New System.Drawing.Size(22, 20)
        Me.tbEstado.TabIndex = 48
        Me.tbEstado.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button2.Location = New System.Drawing.Point(631, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 25)
        Me.Button2.TabIndex = 53
        Me.Button2.TabStop = False
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(383, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Area"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbArea
        '
        Me.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArea.FormattingEnabled = True
        Me.cbArea.Location = New System.Drawing.Point(413, 44)
        Me.cbArea.Name = "cbArea"
        Me.cbArea.Size = New System.Drawing.Size(217, 21)
        Me.cbArea.TabIndex = 49
        Me.cbArea.TabStop = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(297, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 19)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "/"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Cidade/Estado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(335, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Bairro"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBairro
        '
        Me.tbBairro.Location = New System.Drawing.Point(413, 15)
        Me.tbBairro.Name = "tbBairro"
        Me.tbBairro.Size = New System.Drawing.Size(238, 20)
        Me.tbBairro.TabIndex = 41
        Me.tbBairro.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Logradouro"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLogradouro
        '
        Me.tbLogradouro.Location = New System.Drawing.Point(89, 15)
        Me.tbLogradouro.Name = "tbLogradouro"
        Me.tbLogradouro.Size = New System.Drawing.Size(238, 20)
        Me.tbLogradouro.TabIndex = 39
        Me.tbLogradouro.TabStop = False
        '
        'btnConsultaRua
        '
        Me.btnConsultaRua.BackColor = System.Drawing.Color.White
        Me.btnConsultaRua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConsultaRua.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRua.FlatAppearance.BorderSize = 0
        Me.btnConsultaRua.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultaRua.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaRua.ForeColor = System.Drawing.Color.Black
        Me.btnConsultaRua.Image = CType(resources.GetObject("btnConsultaRua.Image"), System.Drawing.Image)
        Me.btnConsultaRua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaRua.Location = New System.Drawing.Point(4, 3)
        Me.btnConsultaRua.Name = "btnConsultaRua"
        Me.btnConsultaRua.Size = New System.Drawing.Size(90, 37)
        Me.btnConsultaRua.TabIndex = 58
        Me.btnConsultaRua.TabStop = False
        Me.btnConsultaRua.Text = "Buscar na Web"
        Me.btnConsultaRua.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultaRua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultaRua.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Procurar logradouro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBusca
        '
        Me.tbBusca.Location = New System.Drawing.Point(100, 28)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(311, 20)
        Me.tbBusca.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Blue
        Me.Button4.Image = Global.GourmetVisual.My.Resources.Resources.Trash1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button4.Location = New System.Drawing.Point(643, 344)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 25)
        Me.Button4.TabIndex = 57
        Me.Button4.TabStop = False
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button3.Location = New System.Drawing.Point(621, 344)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 25)
        Me.Button3.TabIndex = 54
        Me.Button3.TabStop = False
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'tbCEP
        '
        Me.tbCEP.Location = New System.Drawing.Point(558, 347)
        Me.tbCEP.Name = "tbCEP"
        Me.tbCEP.Size = New System.Drawing.Size(61, 20)
        Me.tbCEP.TabIndex = 10
        Me.tbCEP.TabStop = False
        Me.tbCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.lstRuas.Location = New System.Drawing.Point(5, 95)
        Me.lstRuas.MultiSelect = False
        Me.lstRuas.Name = "lstRuas"
        Me.lstRuas.Size = New System.Drawing.Size(543, 367)
        Me.lstRuas.TabIndex = 34
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
        'lstCEPs
        '
        Me.lstCEPs.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstCEPs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstCEPs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDRuaCEP, Me.CEP})
        Me.lstCEPs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCEPs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lstCEPs.FullRowSelect = True
        Me.lstCEPs.GridLines = True
        Me.lstCEPs.HideSelection = False
        Me.lstCEPs.Location = New System.Drawing.Point(558, 95)
        Me.lstCEPs.MultiSelect = False
        Me.lstCEPs.Name = "lstCEPs"
        Me.lstCEPs.Size = New System.Drawing.Size(102, 247)
        Me.lstCEPs.TabIndex = 36
        Me.lstCEPs.TabStop = False
        Me.lstCEPs.UseCompatibleStateImageBehavior = False
        Me.lstCEPs.View = System.Windows.Forms.View.Details
        '
        'IDRuaCEP
        '
        Me.IDRuaCEP.Text = "IDRuaCEP"
        Me.IDRuaCEP.Width = 0
        '
        'CEP
        '
        Me.CEP.Text = "CEPs"
        Me.CEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CEP.Width = 80
        '
        'lbQtdeRuas
        '
        Me.lbQtdeRuas.ForeColor = System.Drawing.Color.Blue
        Me.lbQtdeRuas.Location = New System.Drawing.Point(5, 463)
        Me.lbQtdeRuas.Name = "lbQtdeRuas"
        Me.lbQtdeRuas.Size = New System.Drawing.Size(543, 15)
        Me.lbQtdeRuas.TabIndex = 38
        Me.lbQtdeRuas.Text = "Qtde. Logradouro"
        Me.lbQtdeRuas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGoogle
        '
        Me.btnGoogle.BackColor = System.Drawing.Color.White
        Me.btnGoogle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGoogle.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnGoogle.FlatAppearance.BorderSize = 0
        Me.btnGoogle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGoogle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoogle.ForeColor = System.Drawing.Color.Black
        Me.btnGoogle.Image = CType(resources.GetObject("btnGoogle.Image"), System.Drawing.Image)
        Me.btnGoogle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGoogle.Location = New System.Drawing.Point(570, 399)
        Me.btnGoogle.Name = "btnGoogle"
        Me.btnGoogle.Size = New System.Drawing.Size(83, 67)
        Me.btnGoogle.TabIndex = 58
        Me.btnGoogle.TabStop = False
        Me.btnGoogle.Text = "Ver rua no mapa"
        Me.btnGoogle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGoogle.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.btnGoogle)
        Me.Panel3.Controls.Add(Me.tbBusca)
        Me.Panel3.Controls.Add(Me.lbQtdeRuas)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.lstRuas)
        Me.Panel3.Controls.Add(Me.lstCEPs)
        Me.Panel3.Controls.Add(Me.tbCEP)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Location = New System.Drawing.Point(3, 141)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(670, 484)
        Me.Panel3.TabIndex = 59
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.lbTempo)
        Me.Panel4.Controls.Add(Me.lbDistancia)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.btnConsultaRua)
        Me.Panel4.Controls.Add(Me.tbResultado)
        Me.Panel4.Location = New System.Drawing.Point(420, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 86)
        Me.Panel4.TabIndex = 60
        '
        'lbTempo
        '
        Me.lbTempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTempo.ForeColor = System.Drawing.Color.Green
        Me.lbTempo.Location = New System.Drawing.Point(97, 62)
        Me.lbTempo.Name = "lbTempo"
        Me.lbTempo.Size = New System.Drawing.Size(136, 16)
        Me.lbTempo.TabIndex = 63
        Me.lbTempo.Text = "10 MIN"
        Me.lbTempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDistancia
        '
        Me.lbDistancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDistancia.ForeColor = System.Drawing.Color.Green
        Me.lbDistancia.Location = New System.Drawing.Point(97, 43)
        Me.lbDistancia.Name = "lbDistancia"
        Me.lbDistancia.Size = New System.Drawing.Size(136, 16)
        Me.lbDistancia.TabIndex = 62
        Me.lbDistancia.Text = "6 KM"
        Me.lbDistancia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(2, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Tempo médio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(2, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Distância"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbResultado
        '
        Me.tbResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbResultado.ForeColor = System.Drawing.Color.Red
        Me.tbResultado.Location = New System.Drawing.Point(99, 5)
        Me.tbResultado.Name = "tbResultado"
        Me.tbResultado.Size = New System.Drawing.Size(131, 33)
        Me.tbResultado.TabIndex = 59
        Me.tbResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fdlgDelivery_Ruas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(675, 625)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDelivery_Ruas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Logradouros"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnInserir As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbCEP As TextBox
    Friend WithEvents lstRuas As ListView
    Friend WithEvents tbEstado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbCidade As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbBairro As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbLogradouro As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents cbArea As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents IDRua As ColumnHeader
    Friend WithEvents Logradouro As ColumnHeader
    Friend WithEvents Bairro As ColumnHeader
    Friend WithEvents lstCEPs As ListView
    Friend WithEvents IDRuaCEP As ColumnHeader
    Friend WithEvents CEP As ColumnHeader
    Friend WithEvents lbQtdeRuas As Label
    Friend WithEvents Cidade As ColumnHeader
    Friend WithEvents Estado As ColumnHeader
    Friend WithEvents Label5 As Label
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Area As ColumnHeader
    Friend WithEvents btnConsultaRua As Button
    Friend WithEvents lbMensagem As Label
    Friend WithEvents btnGoogle As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents tbOrigem As TextBox
    Friend WithEvents tbResultado As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lbTempo As Label
    Friend WithEvents lbDistancia As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
End Class
