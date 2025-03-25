<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgSetores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgSetores))
        Me.tbIDSetor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbImpressoraConta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbSetor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelImpressoras = New System.Windows.Forms.Panel()
        Me.btnTeste = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbtnDelivery = New System.Windows.Forms.RadioButton()
        Me.rbtnBalcao = New System.Windows.Forms.RadioButton()
        Me.rbtnSalao = New System.Windows.Forms.RadioButton()
        Me.rbtnTodos = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbModulo = New System.Windows.Forms.ComboBox()
        Me.tbIDSetorImpressora = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkGuilhotina = New System.Windows.Forms.CheckBox()
        Me.cbImpressoraCategoria = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGravaImpressora = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.btnExcluiImpressora = New System.Windows.Forms.Button()
        Me.btnIncluiImpressora = New System.Windows.Forms.Button()
        Me.lstImpressoras = New System.Windows.Forms.ListView()
        Me.IDSetorImpressora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDSet = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Impressora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Guilhotina = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Modulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Categoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstSetores = New System.Windows.Forms.ListView()
        Me.IDSetor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Setor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImpressoraConta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnGravaSetor = New System.Windows.Forms.Button()
        Me.btnExcluiSetor = New System.Windows.Forms.Button()
        Me.btnIncluiSetor = New System.Windows.Forms.Button()
        Me.PanelImpressoras.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbIDSetor
        '
        Me.tbIDSetor.Location = New System.Drawing.Point(8, 139)
        Me.tbIDSetor.Name = "tbIDSetor"
        Me.tbIDSetor.Size = New System.Drawing.Size(48, 20)
        Me.tbIDSetor.TabIndex = 62
        Me.tbIDSetor.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(15, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 15)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Setor"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbImpressoraConta
        '
        Me.cbImpressoraConta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpressoraConta.FormattingEnabled = True
        Me.cbImpressoraConta.Location = New System.Drawing.Point(141, 191)
        Me.cbImpressoraConta.Name = "cbImpressoraConta"
        Me.cbImpressoraConta.Size = New System.Drawing.Size(156, 21)
        Me.cbImpressoraConta.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(13, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 31)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Impressora Conta / SAT -  NFCe"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbSetor
        '
        Me.tbSetor.Location = New System.Drawing.Point(141, 159)
        Me.tbSetor.Name = "tbSetor"
        Me.tbSetor.Size = New System.Drawing.Size(156, 20)
        Me.tbSetor.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(323, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Impressoras "
        '
        'PanelImpressoras
        '
        Me.PanelImpressoras.BackColor = System.Drawing.Color.DarkKhaki
        Me.PanelImpressoras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelImpressoras.Controls.Add(Me.btnTeste)
        Me.PanelImpressoras.Controls.Add(Me.Panel4)
        Me.PanelImpressoras.Controls.Add(Me.Label3)
        Me.PanelImpressoras.Controls.Add(Me.cbModulo)
        Me.PanelImpressoras.Controls.Add(Me.tbIDSetorImpressora)
        Me.PanelImpressoras.Controls.Add(Me.Label8)
        Me.PanelImpressoras.Controls.Add(Me.chkGuilhotina)
        Me.PanelImpressoras.Controls.Add(Me.cbImpressoraCategoria)
        Me.PanelImpressoras.Controls.Add(Me.Label6)
        Me.PanelImpressoras.Controls.Add(Me.btnGravaImpressora)
        Me.PanelImpressoras.Controls.Add(Me.Label4)
        Me.PanelImpressoras.Controls.Add(Me.cbCategoria)
        Me.PanelImpressoras.Controls.Add(Me.btnExcluiImpressora)
        Me.PanelImpressoras.Controls.Add(Me.btnIncluiImpressora)
        Me.PanelImpressoras.Controls.Add(Me.lstImpressoras)
        Me.PanelImpressoras.Enabled = False
        Me.PanelImpressoras.Location = New System.Drawing.Point(322, 96)
        Me.PanelImpressoras.Name = "PanelImpressoras"
        Me.PanelImpressoras.Size = New System.Drawing.Size(412, 406)
        Me.PanelImpressoras.TabIndex = 53
        '
        'btnTeste
        '
        Me.btnTeste.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnTeste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnTeste.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnTeste.FlatAppearance.BorderSize = 0
        Me.btnTeste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTeste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTeste.ForeColor = System.Drawing.Color.Black
        Me.btnTeste.Image = CType(resources.GetObject("btnTeste.Image"), System.Drawing.Image)
        Me.btnTeste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTeste.Location = New System.Drawing.Point(339, 138)
        Me.btnTeste.Name = "btnTeste"
        Me.btnTeste.Size = New System.Drawing.Size(59, 22)
        Me.btnTeste.TabIndex = 54
        Me.btnTeste.TabStop = False
        Me.btnTeste.Text = "Teste"
        Me.btnTeste.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTeste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTeste.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.rbtnDelivery)
        Me.Panel4.Controls.Add(Me.rbtnBalcao)
        Me.Panel4.Controls.Add(Me.rbtnSalao)
        Me.Panel4.Controls.Add(Me.rbtnTodos)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Location = New System.Drawing.Point(9, 31)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(391, 28)
        Me.Panel4.TabIndex = 53
        '
        'rbtnDelivery
        '
        Me.rbtnDelivery.AutoSize = True
        Me.rbtnDelivery.Location = New System.Drawing.Point(323, 3)
        Me.rbtnDelivery.Name = "rbtnDelivery"
        Me.rbtnDelivery.Size = New System.Drawing.Size(63, 17)
        Me.rbtnDelivery.TabIndex = 53
        Me.rbtnDelivery.TabStop = True
        Me.rbtnDelivery.Text = "Delivery"
        Me.rbtnDelivery.UseVisualStyleBackColor = True
        '
        'rbtnBalcao
        '
        Me.rbtnBalcao.AutoSize = True
        Me.rbtnBalcao.Location = New System.Drawing.Point(261, 3)
        Me.rbtnBalcao.Name = "rbtnBalcao"
        Me.rbtnBalcao.Size = New System.Drawing.Size(58, 17)
        Me.rbtnBalcao.TabIndex = 52
        Me.rbtnBalcao.TabStop = True
        Me.rbtnBalcao.Text = "Balcão"
        Me.rbtnBalcao.UseVisualStyleBackColor = True
        '
        'rbtnSalao
        '
        Me.rbtnSalao.AutoSize = True
        Me.rbtnSalao.Location = New System.Drawing.Point(205, 3)
        Me.rbtnSalao.Name = "rbtnSalao"
        Me.rbtnSalao.Size = New System.Drawing.Size(52, 17)
        Me.rbtnSalao.TabIndex = 51
        Me.rbtnSalao.TabStop = True
        Me.rbtnSalao.Text = "Salão"
        Me.rbtnSalao.UseVisualStyleBackColor = True
        '
        'rbtnTodos
        '
        Me.rbtnTodos.AutoSize = True
        Me.rbtnTodos.Location = New System.Drawing.Point(145, 3)
        Me.rbtnTodos.Name = "rbtnTodos"
        Me.rbtnTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtnTodos.TabIndex = 50
        Me.rbtnTodos.TabStop = True
        Me.rbtnTodos.Text = "Todos"
        Me.rbtnTodos.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(-1, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 21)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Filtro"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(61, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Módulo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbModulo
        '
        Me.cbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModulo.FormattingEnabled = True
        Me.cbModulo.Location = New System.Drawing.Point(138, 119)
        Me.cbModulo.Name = "cbModulo"
        Me.cbModulo.Size = New System.Drawing.Size(185, 21)
        Me.cbModulo.TabIndex = 51
        '
        'tbIDSetorImpressora
        '
        Me.tbIDSetorImpressora.Location = New System.Drawing.Point(200, 142)
        Me.tbIDSetorImpressora.Name = "tbIDSetorImpressora"
        Me.tbIDSetorImpressora.Size = New System.Drawing.Size(48, 20)
        Me.tbIDSetorImpressora.TabIndex = 50
        Me.tbIDSetorImpressora.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(61, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 15)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Impressora"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkGuilhotina
        '
        Me.chkGuilhotina.AutoSize = True
        Me.chkGuilhotina.Location = New System.Drawing.Point(139, 145)
        Me.chkGuilhotina.Name = "chkGuilhotina"
        Me.chkGuilhotina.Size = New System.Drawing.Size(15, 14)
        Me.chkGuilhotina.TabIndex = 46
        Me.chkGuilhotina.UseVisualStyleBackColor = True
        '
        'cbImpressoraCategoria
        '
        Me.cbImpressoraCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpressoraCategoria.FormattingEnabled = True
        Me.cbImpressoraCategoria.Location = New System.Drawing.Point(138, 94)
        Me.cbImpressoraCategoria.Name = "cbImpressoraCategoria"
        Me.cbImpressoraCategoria.Size = New System.Drawing.Size(185, 21)
        Me.cbImpressoraCategoria.TabIndex = 44
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(64, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Guilhotina"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGravaImpressora
        '
        Me.btnGravaImpressora.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGravaImpressora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGravaImpressora.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGravaImpressora.FlatAppearance.BorderSize = 0
        Me.btnGravaImpressora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGravaImpressora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravaImpressora.ForeColor = System.Drawing.Color.Black
        Me.btnGravaImpressora.Image = Global.GourmetVisual.My.Resources.Resources.Save2
        Me.btnGravaImpressora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravaImpressora.Location = New System.Drawing.Point(240, 1)
        Me.btnGravaImpressora.Name = "btnGravaImpressora"
        Me.btnGravaImpressora.Size = New System.Drawing.Size(63, 27)
        Me.btnGravaImpressora.TabIndex = 41
        Me.btnGravaImpressora.TabStop = False
        Me.btnGravaImpressora.Text = "Gravar"
        Me.btnGravaImpressora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravaImpressora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGravaImpressora.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(61, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Categoria"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbCategoria
        '
        Me.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(138, 68)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(185, 21)
        Me.cbCategoria.TabIndex = 36
        '
        'btnExcluiImpressora
        '
        Me.btnExcluiImpressora.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExcluiImpressora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluiImpressora.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluiImpressora.FlatAppearance.BorderSize = 0
        Me.btnExcluiImpressora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluiImpressora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluiImpressora.ForeColor = System.Drawing.Color.Black
        Me.btnExcluiImpressora.Image = Global.GourmetVisual.My.Resources.Resources.Trash1
        Me.btnExcluiImpressora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluiImpressora.Location = New System.Drawing.Point(174, 1)
        Me.btnExcluiImpressora.Name = "btnExcluiImpressora"
        Me.btnExcluiImpressora.Size = New System.Drawing.Size(63, 27)
        Me.btnExcluiImpressora.TabIndex = 26
        Me.btnExcluiImpressora.TabStop = False
        Me.btnExcluiImpressora.Text = "Excluir"
        Me.btnExcluiImpressora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluiImpressora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluiImpressora.UseVisualStyleBackColor = False
        '
        'btnIncluiImpressora
        '
        Me.btnIncluiImpressora.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIncluiImpressora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluiImpressora.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluiImpressora.FlatAppearance.BorderSize = 0
        Me.btnIncluiImpressora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluiImpressora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluiImpressora.ForeColor = System.Drawing.Color.Black
        Me.btnIncluiImpressora.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.btnIncluiImpressora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluiImpressora.Location = New System.Drawing.Point(107, 1)
        Me.btnIncluiImpressora.Name = "btnIncluiImpressora"
        Me.btnIncluiImpressora.Size = New System.Drawing.Size(63, 27)
        Me.btnIncluiImpressora.TabIndex = 25
        Me.btnIncluiImpressora.TabStop = False
        Me.btnIncluiImpressora.Text = "Incluir "
        Me.btnIncluiImpressora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluiImpressora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluiImpressora.UseVisualStyleBackColor = False
        '
        'lstImpressoras
        '
        Me.lstImpressoras.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lstImpressoras.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDSetorImpressora, Me.IDSet, Me.IDCategoria, Me.Impressora, Me.Guilhotina, Me.Modulo, Me.Categoria})
        Me.lstImpressoras.ForeColor = System.Drawing.Color.Blue
        Me.lstImpressoras.FullRowSelect = True
        Me.lstImpressoras.GridLines = True
        Me.lstImpressoras.HideSelection = False
        Me.lstImpressoras.Location = New System.Drawing.Point(9, 165)
        Me.lstImpressoras.MultiSelect = False
        Me.lstImpressoras.Name = "lstImpressoras"
        Me.lstImpressoras.Size = New System.Drawing.Size(391, 232)
        Me.lstImpressoras.TabIndex = 24
        Me.lstImpressoras.UseCompatibleStateImageBehavior = False
        Me.lstImpressoras.View = System.Windows.Forms.View.Details
        '
        'IDSetorImpressora
        '
        Me.IDSetorImpressora.Text = "IDSetorImpressora"
        Me.IDSetorImpressora.Width = 0
        '
        'IDSet
        '
        Me.IDSet.Text = "IDSet"
        Me.IDSet.Width = 0
        '
        'IDCategoria
        '
        Me.IDCategoria.Text = "IDCategoria"
        Me.IDCategoria.Width = 0
        '
        'Impressora
        '
        Me.Impressora.DisplayIndex = 5
        Me.Impressora.Text = "Impressora"
        Me.Impressora.Width = 150
        '
        'Guilhotina
        '
        Me.Guilhotina.DisplayIndex = 6
        Me.Guilhotina.Text = "Guilhotina"
        Me.Guilhotina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Modulo
        '
        Me.Modulo.DisplayIndex = 3
        Me.Modulo.Text = "Módulo"
        '
        'Categoria
        '
        Me.Categoria.DisplayIndex = 4
        Me.Categoria.Text = "Categoria"
        Me.Categoria.Width = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(7, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Setores"
        '
        'lstSetores
        '
        Me.lstSetores.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstSetores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDSetor, Me.Setor, Me.ImpressoraConta})
        Me.lstSetores.ForeColor = System.Drawing.Color.Blue
        Me.lstSetores.FullRowSelect = True
        Me.lstSetores.GridLines = True
        Me.lstSetores.HideSelection = False
        Me.lstSetores.Location = New System.Drawing.Point(7, 263)
        Me.lstSetores.MultiSelect = False
        Me.lstSetores.Name = "lstSetores"
        Me.lstSetores.Size = New System.Drawing.Size(309, 232)
        Me.lstSetores.TabIndex = 51
        Me.lstSetores.UseCompatibleStateImageBehavior = False
        Me.lstSetores.View = System.Windows.Forms.View.Details
        '
        'IDSetor
        '
        Me.IDSetor.Text = "IDSetor"
        Me.IDSetor.Width = 0
        '
        'Setor
        '
        Me.Setor.Text = "Setor"
        Me.Setor.Width = 135
        '
        'ImpressoraConta
        '
        Me.ImpressoraConta.Text = "Impressora SAT - NCFe"
        Me.ImpressoraConta.Width = 150
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(805, 71)
        Me.Panel1.TabIndex = 50
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back2
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(8, 5)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(128, 61)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnGravaSetor
        '
        Me.btnGravaSetor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGravaSetor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGravaSetor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGravaSetor.FlatAppearance.BorderSize = 0
        Me.btnGravaSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGravaSetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravaSetor.ForeColor = System.Drawing.Color.Black
        Me.btnGravaSetor.Image = Global.GourmetVisual.My.Resources.Resources.Save2
        Me.btnGravaSetor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravaSetor.Location = New System.Drawing.Point(196, 99)
        Me.btnGravaSetor.Name = "btnGravaSetor"
        Me.btnGravaSetor.Size = New System.Drawing.Size(63, 27)
        Me.btnGravaSetor.TabIndex = 57
        Me.btnGravaSetor.TabStop = False
        Me.btnGravaSetor.Text = "Gravar"
        Me.btnGravaSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravaSetor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGravaSetor.UseVisualStyleBackColor = False
        '
        'btnExcluiSetor
        '
        Me.btnExcluiSetor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExcluiSetor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluiSetor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluiSetor.FlatAppearance.BorderSize = 0
        Me.btnExcluiSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluiSetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluiSetor.ForeColor = System.Drawing.Color.Black
        Me.btnExcluiSetor.Image = Global.GourmetVisual.My.Resources.Resources.Trash1
        Me.btnExcluiSetor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluiSetor.Location = New System.Drawing.Point(130, 99)
        Me.btnExcluiSetor.Name = "btnExcluiSetor"
        Me.btnExcluiSetor.Size = New System.Drawing.Size(62, 27)
        Me.btnExcluiSetor.TabIndex = 56
        Me.btnExcluiSetor.TabStop = False
        Me.btnExcluiSetor.Text = "Excluir"
        Me.btnExcluiSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluiSetor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluiSetor.UseVisualStyleBackColor = False
        '
        'btnIncluiSetor
        '
        Me.btnIncluiSetor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnIncluiSetor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluiSetor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluiSetor.FlatAppearance.BorderSize = 0
        Me.btnIncluiSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluiSetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluiSetor.ForeColor = System.Drawing.Color.Black
        Me.btnIncluiSetor.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.btnIncluiSetor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluiSetor.Location = New System.Drawing.Point(67, 99)
        Me.btnIncluiSetor.Name = "btnIncluiSetor"
        Me.btnIncluiSetor.Size = New System.Drawing.Size(59, 27)
        Me.btnIncluiSetor.TabIndex = 55
        Me.btnIncluiSetor.TabStop = False
        Me.btnIncluiSetor.Text = "Incluir "
        Me.btnIncluiSetor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluiSetor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluiSetor.UseVisualStyleBackColor = False
        '
        'fdlgSetores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(742, 509)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbIDSetor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbImpressoraConta)
        Me.Controls.Add(Me.btnGravaSetor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbSetor)
        Me.Controls.Add(Me.btnExcluiSetor)
        Me.Controls.Add(Me.btnIncluiSetor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelImpressoras)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstSetores)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgSetores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setores"
        Me.PanelImpressoras.ResumeLayout(False)
        Me.PanelImpressoras.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbIDSetor As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbImpressoraConta As ComboBox
    Friend WithEvents btnGravaSetor As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents tbSetor As TextBox
    Friend WithEvents btnExcluiSetor As Button
    Friend WithEvents btnIncluiSetor As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelImpressoras As Panel
    Friend WithEvents btnTeste As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rbtnDelivery As RadioButton
    Friend WithEvents rbtnBalcao As RadioButton
    Friend WithEvents rbtnSalao As RadioButton
    Friend WithEvents rbtnTodos As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbModulo As ComboBox
    Friend WithEvents tbIDSetorImpressora As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkGuilhotina As CheckBox
    Friend WithEvents cbImpressoraCategoria As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnGravaImpressora As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents btnExcluiImpressora As Button
    Friend WithEvents btnIncluiImpressora As Button
    Friend WithEvents lstImpressoras As ListView
    Friend WithEvents IDSetorImpressora As ColumnHeader
    Friend WithEvents IDSet As ColumnHeader
    Friend WithEvents IDCategoria As ColumnHeader
    Friend WithEvents Impressora As ColumnHeader
    Friend WithEvents Guilhotina As ColumnHeader
    Friend WithEvents Modulo As ColumnHeader
    Friend WithEvents Categoria As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents lstSetores As ListView
    Friend WithEvents IDSetor As ColumnHeader
    Friend WithEvents Setor As ColumnHeader
    Friend WithEvents ImpressoraConta As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
End Class
