<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendencias))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRelatorios = New System.Windows.Forms.Button()
        Me.btnAlterarCliente = New System.Windows.Forms.Button()
        Me.btnExcluirCliente = New System.Windows.Forms.Button()
        Me.btnIncluirCliente = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbQtdeClientes = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.lbTotalProdutos = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lstClientes = New System.Windows.Forms.ListView()
        Me.IDCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tel1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SaldoNegativo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Saldo_ = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelTeclado = New System.Windows.Forms.Panel()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.Button34 = New System.Windows.Forms.Button()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.Button36 = New System.Windows.Forms.Button()
        Me.Button37 = New System.Windows.Forms.Button()
        Me.Button38 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button30 = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Button32 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button39 = New System.Windows.Forms.Button()
        Me.Button40 = New System.Windows.Forms.Button()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.Button43 = New System.Windows.Forms.Button()
        Me.lstLanctos = New System.Windows.Forms.ListView()
        Me.IDPendencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Data = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Pagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Saldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDRetVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDVendaRetPagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lancado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbIDVendaRet = New System.Windows.Forms.TextBox()
        Me.lbSaldo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbIDCliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbTel1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkSaldoNegativo = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtFim = New System.Windows.Forms.DateTimePicker()
        Me.btnExcluirLancto = New System.Windows.Forms.Button()
        Me.btnIncluirLancto = New System.Windows.Forms.Button()
        Me.lbQtdeLanc = New System.Windows.Forms.Label()
        Me.chkPermiteSaldoNegativo = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelTeclado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnRelatorios)
        Me.Panel1.Controls.Add(Me.btnAlterarCliente)
        Me.Panel1.Controls.Add(Me.btnExcluirCliente)
        Me.Panel1.Controls.Add(Me.btnIncluirCliente)
        Me.Panel1.Controls.Add(Me.btnSair)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(773, 68)
        Me.Panel1.TabIndex = 25
        '
        'btnRelatorios
        '
        Me.btnRelatorios.BackColor = System.Drawing.Color.White
        Me.btnRelatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRelatorios.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnRelatorios.FlatAppearance.BorderSize = 0
        Me.btnRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelatorios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelatorios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRelatorios.Image = CType(resources.GetObject("btnRelatorios.Image"), System.Drawing.Image)
        Me.btnRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRelatorios.Location = New System.Drawing.Point(635, 4)
        Me.btnRelatorios.Name = "btnRelatorios"
        Me.btnRelatorios.Size = New System.Drawing.Size(130, 57)
        Me.btnRelatorios.TabIndex = 202
        Me.btnRelatorios.TabStop = False
        Me.btnRelatorios.Text = "Relatório"
        Me.btnRelatorios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRelatorios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRelatorios.UseVisualStyleBackColor = False
        '
        'btnAlterarCliente
        '
        Me.btnAlterarCliente.BackColor = System.Drawing.Color.White
        Me.btnAlterarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAlterarCliente.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAlterarCliente.FlatAppearance.BorderSize = 0
        Me.btnAlterarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlterarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlterarCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAlterarCliente.Image = CType(resources.GetObject("btnAlterarCliente.Image"), System.Drawing.Image)
        Me.btnAlterarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterarCliente.Location = New System.Drawing.Point(501, 4)
        Me.btnAlterarCliente.Name = "btnAlterarCliente"
        Me.btnAlterarCliente.Size = New System.Drawing.Size(130, 57)
        Me.btnAlterarCliente.TabIndex = 201
        Me.btnAlterarCliente.TabStop = False
        Me.btnAlterarCliente.Text = "Altera/Grava Cliente"
        Me.btnAlterarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlterarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAlterarCliente.UseVisualStyleBackColor = False
        '
        'btnExcluirCliente
        '
        Me.btnExcluirCliente.BackColor = System.Drawing.Color.White
        Me.btnExcluirCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluirCliente.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluirCliente.FlatAppearance.BorderSize = 0
        Me.btnExcluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluirCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluirCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnExcluirCliente.Image = CType(resources.GetObject("btnExcluirCliente.Image"), System.Drawing.Image)
        Me.btnExcluirCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluirCliente.Location = New System.Drawing.Point(367, 4)
        Me.btnExcluirCliente.Name = "btnExcluirCliente"
        Me.btnExcluirCliente.Size = New System.Drawing.Size(130, 57)
        Me.btnExcluirCliente.TabIndex = 200
        Me.btnExcluirCliente.TabStop = False
        Me.btnExcluirCliente.Text = "Exclui Cliente"
        Me.btnExcluirCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluirCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluirCliente.UseVisualStyleBackColor = False
        '
        'btnIncluirCliente
        '
        Me.btnIncluirCliente.BackColor = System.Drawing.Color.White
        Me.btnIncluirCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluirCliente.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluirCliente.FlatAppearance.BorderSize = 0
        Me.btnIncluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluirCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluirCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnIncluirCliente.Image = CType(resources.GetObject("btnIncluirCliente.Image"), System.Drawing.Image)
        Me.btnIncluirCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluirCliente.Location = New System.Drawing.Point(233, 4)
        Me.btnIncluirCliente.Name = "btnIncluirCliente"
        Me.btnIncluirCliente.Size = New System.Drawing.Size(130, 57)
        Me.btnIncluirCliente.TabIndex = 199
        Me.btnIncluirCliente.TabStop = False
        Me.btnIncluirCliente.Text = "Incluir Cliente"
        Me.btnIncluirCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIncluirCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluirCliente.UseVisualStyleBackColor = False
        '
        'btnSair
        '
        Me.btnSair.BackColor = System.Drawing.Color.White
        Me.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSair.FlatAppearance.BorderSize = 0
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSair.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSair.Image = Global.GourmetVisual.My.Resources.Resources.Back2
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSair.Location = New System.Drawing.Point(5, 4)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(130, 57)
        Me.btnSair.TabIndex = 198
        Me.btnSair.TabStop = False
        Me.btnSair.Text = "Sair"
        Me.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSair.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.chkPermiteSaldoNegativo)
        Me.Panel2.Controls.Add(Me.lbQtdeClientes)
        Me.Panel2.Controls.Add(Me.tbBusca)
        Me.Panel2.Controls.Add(Me.lbTotalProdutos)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.lstClientes)
        Me.Panel2.Location = New System.Drawing.Point(496, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(281, 325)
        Me.Panel2.TabIndex = 182
        '
        'lbQtdeClientes
        '
        Me.lbQtdeClientes.ForeColor = System.Drawing.Color.Green
        Me.lbQtdeClientes.Location = New System.Drawing.Point(139, 307)
        Me.lbQtdeClientes.Name = "lbQtdeClientes"
        Me.lbQtdeClientes.Size = New System.Drawing.Size(129, 13)
        Me.lbQtdeClientes.TabIndex = 194
        Me.lbQtdeClientes.Text = "0"
        Me.lbQtdeClientes.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.Location = New System.Drawing.Point(44, 7)
        Me.tbBusca.Multiline = True
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(194, 24)
        Me.tbBusca.TabIndex = 171
        Me.tbBusca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbTotalProdutos
        '
        Me.lbTotalProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalProdutos.ForeColor = System.Drawing.Color.Navy
        Me.lbTotalProdutos.Location = New System.Drawing.Point(178, 544)
        Me.lbTotalProdutos.Name = "lbTotalProdutos"
        Me.lbTotalProdutos.Size = New System.Drawing.Size(73, 22)
        Me.lbTotalProdutos.TabIndex = 179
        Me.lbTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Navy
        Me.Label25.Location = New System.Drawing.Point(4, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 16)
        Me.Label25.TabIndex = 180
        Me.Label25.Text = "Busca"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstClientes
        '
        Me.lstClientes.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDCliente, Me.Cliente, Me.Tel1, Me.SaldoNegativo, Me.Saldo_})
        Me.lstClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstClientes.FullRowSelect = True
        Me.lstClientes.GridLines = True
        Me.lstClientes.HideSelection = False
        Me.lstClientes.Location = New System.Drawing.Point(4, 56)
        Me.lstClientes.MultiSelect = False
        Me.lstClientes.Name = "lstClientes"
        Me.lstClientes.Size = New System.Drawing.Size(268, 247)
        Me.lstClientes.TabIndex = 178
        Me.lstClientes.UseCompatibleStateImageBehavior = False
        Me.lstClientes.View = System.Windows.Forms.View.Details
        '
        'IDCliente
        '
        Me.IDCliente.Text = "IDCliente"
        Me.IDCliente.Width = 0
        '
        'Cliente
        '
        Me.Cliente.Text = "Clientes"
        Me.Cliente.Width = 245
        '
        'Tel1
        '
        Me.Tel1.Text = "Tel1"
        Me.Tel1.Width = 0
        '
        'SaldoNegativo
        '
        Me.SaldoNegativo.Text = "SaldoNegativo"
        Me.SaldoNegativo.Width = 0
        '
        'Saldo_
        '
        Me.Saldo_.Text = "Saldo"
        Me.Saldo_.Width = 0
        '
        'PanelTeclado
        '
        Me.PanelTeclado.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PanelTeclado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTeclado.Controls.Add(Me.Button33)
        Me.PanelTeclado.Controls.Add(Me.Button34)
        Me.PanelTeclado.Controls.Add(Me.Button35)
        Me.PanelTeclado.Controls.Add(Me.Button36)
        Me.PanelTeclado.Controls.Add(Me.Button37)
        Me.PanelTeclado.Controls.Add(Me.Button38)
        Me.PanelTeclado.Controls.Add(Me.Button41)
        Me.PanelTeclado.Controls.Add(Me.Button23)
        Me.PanelTeclado.Controls.Add(Me.Button24)
        Me.PanelTeclado.Controls.Add(Me.Button25)
        Me.PanelTeclado.Controls.Add(Me.Button26)
        Me.PanelTeclado.Controls.Add(Me.Button27)
        Me.PanelTeclado.Controls.Add(Me.Button28)
        Me.PanelTeclado.Controls.Add(Me.Button29)
        Me.PanelTeclado.Controls.Add(Me.Button30)
        Me.PanelTeclado.Controls.Add(Me.Button31)
        Me.PanelTeclado.Controls.Add(Me.Button32)
        Me.PanelTeclado.Controls.Add(Me.Button13)
        Me.PanelTeclado.Controls.Add(Me.Button14)
        Me.PanelTeclado.Controls.Add(Me.Button15)
        Me.PanelTeclado.Controls.Add(Me.Button16)
        Me.PanelTeclado.Controls.Add(Me.Button17)
        Me.PanelTeclado.Controls.Add(Me.Button18)
        Me.PanelTeclado.Controls.Add(Me.Button19)
        Me.PanelTeclado.Controls.Add(Me.Button20)
        Me.PanelTeclado.Controls.Add(Me.Button21)
        Me.PanelTeclado.Controls.Add(Me.Button22)
        Me.PanelTeclado.Controls.Add(Me.Button12)
        Me.PanelTeclado.Controls.Add(Me.Button11)
        Me.PanelTeclado.Controls.Add(Me.Button10)
        Me.PanelTeclado.Controls.Add(Me.Button7)
        Me.PanelTeclado.Controls.Add(Me.Button8)
        Me.PanelTeclado.Controls.Add(Me.Button9)
        Me.PanelTeclado.Controls.Add(Me.Button5)
        Me.PanelTeclado.Controls.Add(Me.Button6)
        Me.PanelTeclado.Controls.Add(Me.Button39)
        Me.PanelTeclado.Controls.Add(Me.Button40)
        Me.PanelTeclado.Controls.Add(Me.Button42)
        Me.PanelTeclado.Controls.Add(Me.Button43)
        Me.PanelTeclado.Location = New System.Drawing.Point(4, 80)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(486, 175)
        Me.PanelTeclado.TabIndex = 183
        '
        'Button33
        '
        Me.Button33.BackgroundImage = CType(resources.GetObject("Button33.BackgroundImage"), System.Drawing.Image)
        Me.Button33.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button33.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button33.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button33.Location = New System.Drawing.Point(103, 128)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(46, 42)
        Me.Button33.TabIndex = 40
        Me.Button33.Text = "C"
        Me.Button33.UseVisualStyleBackColor = True
        '
        'Button34
        '
        Me.Button34.BackgroundImage = CType(resources.GetObject("Button34.BackgroundImage"), System.Drawing.Image)
        Me.Button34.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button34.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button34.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button34.Location = New System.Drawing.Point(57, 128)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(46, 42)
        Me.Button34.TabIndex = 39
        Me.Button34.Text = "X"
        Me.Button34.UseVisualStyleBackColor = True
        '
        'Button35
        '
        Me.Button35.BackgroundImage = CType(resources.GetObject("Button35.BackgroundImage"), System.Drawing.Image)
        Me.Button35.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button35.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button35.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button35.Location = New System.Drawing.Point(11, 128)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(46, 42)
        Me.Button35.TabIndex = 38
        Me.Button35.Text = "Z"
        Me.Button35.UseVisualStyleBackColor = True
        '
        'Button36
        '
        Me.Button36.BackgroundImage = CType(resources.GetObject("Button36.BackgroundImage"), System.Drawing.Image)
        Me.Button36.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button36.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button36.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button36.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button36.Location = New System.Drawing.Point(241, 128)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(46, 42)
        Me.Button36.TabIndex = 37
        Me.Button36.Text = "N"
        Me.Button36.UseVisualStyleBackColor = True
        '
        'Button37
        '
        Me.Button37.BackgroundImage = CType(resources.GetObject("Button37.BackgroundImage"), System.Drawing.Image)
        Me.Button37.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button37.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button37.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button37.Location = New System.Drawing.Point(195, 128)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(46, 42)
        Me.Button37.TabIndex = 36
        Me.Button37.Text = "B"
        Me.Button37.UseVisualStyleBackColor = True
        '
        'Button38
        '
        Me.Button38.BackgroundImage = CType(resources.GetObject("Button38.BackgroundImage"), System.Drawing.Image)
        Me.Button38.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button38.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button38.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button38.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button38.Location = New System.Drawing.Point(149, 128)
        Me.Button38.Name = "Button38"
        Me.Button38.Size = New System.Drawing.Size(46, 42)
        Me.Button38.TabIndex = 35
        Me.Button38.Text = "V"
        Me.Button38.UseVisualStyleBackColor = True
        '
        'Button41
        '
        Me.Button41.BackgroundImage = CType(resources.GetObject("Button41.BackgroundImage"), System.Drawing.Image)
        Me.Button41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button41.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button41.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button41.Location = New System.Drawing.Point(287, 128)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(46, 42)
        Me.Button41.TabIndex = 32
        Me.Button41.Text = "M"
        Me.Button41.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.BackgroundImage = CType(resources.GetObject("Button23.BackgroundImage"), System.Drawing.Image)
        Me.Button23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button23.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button23.Location = New System.Drawing.Point(333, 128)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(92, 42)
        Me.Button23.TabIndex = 31
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.BackgroundImage = CType(resources.GetObject("Button24.BackgroundImage"), System.Drawing.Image)
        Me.Button24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button24.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button24.Location = New System.Drawing.Point(103, 86)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(46, 42)
        Me.Button24.TabIndex = 30
        Me.Button24.Text = "D"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'Button25
        '
        Me.Button25.BackgroundImage = CType(resources.GetObject("Button25.BackgroundImage"), System.Drawing.Image)
        Me.Button25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button25.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button25.Location = New System.Drawing.Point(57, 86)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(46, 42)
        Me.Button25.TabIndex = 29
        Me.Button25.Text = "S"
        Me.Button25.UseVisualStyleBackColor = True
        '
        'Button26
        '
        Me.Button26.BackgroundImage = CType(resources.GetObject("Button26.BackgroundImage"), System.Drawing.Image)
        Me.Button26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button26.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button26.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button26.Location = New System.Drawing.Point(11, 86)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(46, 42)
        Me.Button26.TabIndex = 28
        Me.Button26.Text = "A"
        Me.Button26.UseVisualStyleBackColor = True
        '
        'Button27
        '
        Me.Button27.BackgroundImage = CType(resources.GetObject("Button27.BackgroundImage"), System.Drawing.Image)
        Me.Button27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button27.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button27.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button27.Location = New System.Drawing.Point(241, 86)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(46, 42)
        Me.Button27.TabIndex = 27
        Me.Button27.Text = "H"
        Me.Button27.UseVisualStyleBackColor = True
        '
        'Button28
        '
        Me.Button28.BackgroundImage = CType(resources.GetObject("Button28.BackgroundImage"), System.Drawing.Image)
        Me.Button28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button28.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button28.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button28.Location = New System.Drawing.Point(195, 86)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(46, 42)
        Me.Button28.TabIndex = 26
        Me.Button28.Text = "G"
        Me.Button28.UseVisualStyleBackColor = True
        '
        'Button29
        '
        Me.Button29.BackgroundImage = CType(resources.GetObject("Button29.BackgroundImage"), System.Drawing.Image)
        Me.Button29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button29.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button29.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button29.Location = New System.Drawing.Point(149, 86)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(46, 42)
        Me.Button29.TabIndex = 25
        Me.Button29.Text = "F"
        Me.Button29.UseVisualStyleBackColor = True
        '
        'Button30
        '
        Me.Button30.BackgroundImage = CType(resources.GetObject("Button30.BackgroundImage"), System.Drawing.Image)
        Me.Button30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button30.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button30.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button30.Location = New System.Drawing.Point(379, 86)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(46, 42)
        Me.Button30.TabIndex = 24
        Me.Button30.Text = "L"
        Me.Button30.UseVisualStyleBackColor = True
        '
        'Button31
        '
        Me.Button31.BackgroundImage = CType(resources.GetObject("Button31.BackgroundImage"), System.Drawing.Image)
        Me.Button31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button31.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button31.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button31.Location = New System.Drawing.Point(333, 86)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(46, 42)
        Me.Button31.TabIndex = 23
        Me.Button31.Text = "K"
        Me.Button31.UseVisualStyleBackColor = True
        '
        'Button32
        '
        Me.Button32.BackgroundImage = CType(resources.GetObject("Button32.BackgroundImage"), System.Drawing.Image)
        Me.Button32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button32.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button32.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button32.Location = New System.Drawing.Point(287, 86)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(46, 42)
        Me.Button32.TabIndex = 22
        Me.Button32.Text = "J"
        Me.Button32.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.BackgroundImage = CType(resources.GetObject("Button13.BackgroundImage"), System.Drawing.Image)
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button13.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button13.Location = New System.Drawing.Point(425, 44)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(46, 42)
        Me.Button13.TabIndex = 21
        Me.Button13.Text = "P"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button14.Location = New System.Drawing.Point(103, 44)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(46, 42)
        Me.Button14.TabIndex = 20
        Me.Button14.Text = "E"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.BackgroundImage = CType(resources.GetObject("Button15.BackgroundImage"), System.Drawing.Image)
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button15.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button15.Location = New System.Drawing.Point(57, 44)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(46, 42)
        Me.Button15.TabIndex = 19
        Me.Button15.Text = "W"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.BackgroundImage = CType(resources.GetObject("Button16.BackgroundImage"), System.Drawing.Image)
        Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button16.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button16.Location = New System.Drawing.Point(11, 44)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(46, 42)
        Me.Button16.TabIndex = 18
        Me.Button16.Text = "Q"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.BackgroundImage = CType(resources.GetObject("Button17.BackgroundImage"), System.Drawing.Image)
        Me.Button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button17.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button17.Location = New System.Drawing.Point(241, 44)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(46, 42)
        Me.Button17.TabIndex = 17
        Me.Button17.Text = "Y"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.BackgroundImage = CType(resources.GetObject("Button18.BackgroundImage"), System.Drawing.Image)
        Me.Button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button18.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button18.Location = New System.Drawing.Point(195, 44)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(46, 42)
        Me.Button18.TabIndex = 16
        Me.Button18.Text = "T"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.BackgroundImage = CType(resources.GetObject("Button19.BackgroundImage"), System.Drawing.Image)
        Me.Button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button19.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button19.Location = New System.Drawing.Point(149, 44)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(46, 42)
        Me.Button19.TabIndex = 15
        Me.Button19.Text = "R"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.BackgroundImage = CType(resources.GetObject("Button20.BackgroundImage"), System.Drawing.Image)
        Me.Button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button20.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button20.Location = New System.Drawing.Point(379, 44)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(46, 42)
        Me.Button20.TabIndex = 14
        Me.Button20.Text = "O"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.BackgroundImage = CType(resources.GetObject("Button21.BackgroundImage"), System.Drawing.Image)
        Me.Button21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button21.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button21.Location = New System.Drawing.Point(333, 44)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(46, 42)
        Me.Button21.TabIndex = 13
        Me.Button21.Text = "I"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.BackgroundImage = CType(resources.GetObject("Button22.BackgroundImage"), System.Drawing.Image)
        Me.Button22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button22.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button22.Location = New System.Drawing.Point(287, 44)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(46, 42)
        Me.Button22.TabIndex = 12
        Me.Button22.Text = "U"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button12.Location = New System.Drawing.Point(425, 128)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(46, 42)
        Me.Button12.TabIndex = 11
        Me.Button12.Text = "-"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = CType(resources.GetObject("Button11.BackgroundImage"), System.Drawing.Image)
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button11.Location = New System.Drawing.Point(425, 86)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(46, 42)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "Limpa"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button10.Location = New System.Drawing.Point(425, 2)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(46, 42)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "0"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.Location = New System.Drawing.Point(103, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(46, 42)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "3"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"), System.Drawing.Image)
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button8.Location = New System.Drawing.Point(57, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(46, 42)
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "2"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button9.Location = New System.Drawing.Point(11, 2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(46, 42)
        Me.Button9.TabIndex = 6
        Me.Button9.Text = "1"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(241, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(46, 42)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "6"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button6.Location = New System.Drawing.Point(195, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(46, 42)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "5"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button39
        '
        Me.Button39.BackgroundImage = CType(resources.GetObject("Button39.BackgroundImage"), System.Drawing.Image)
        Me.Button39.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button39.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button39.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button39.Location = New System.Drawing.Point(149, 2)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(46, 42)
        Me.Button39.TabIndex = 3
        Me.Button39.Text = "4"
        Me.Button39.UseVisualStyleBackColor = True
        '
        'Button40
        '
        Me.Button40.BackgroundImage = CType(resources.GetObject("Button40.BackgroundImage"), System.Drawing.Image)
        Me.Button40.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button40.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button40.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button40.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button40.Location = New System.Drawing.Point(379, 2)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(46, 42)
        Me.Button40.TabIndex = 2
        Me.Button40.Text = "9"
        Me.Button40.UseVisualStyleBackColor = True
        '
        'Button42
        '
        Me.Button42.BackgroundImage = CType(resources.GetObject("Button42.BackgroundImage"), System.Drawing.Image)
        Me.Button42.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button42.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button42.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button42.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button42.Location = New System.Drawing.Point(333, 2)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(46, 42)
        Me.Button42.TabIndex = 1
        Me.Button42.Text = "8"
        Me.Button42.UseVisualStyleBackColor = True
        '
        'Button43
        '
        Me.Button43.BackgroundImage = CType(resources.GetObject("Button43.BackgroundImage"), System.Drawing.Image)
        Me.Button43.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button43.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button43.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button43.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button43.Location = New System.Drawing.Point(287, 2)
        Me.Button43.Name = "Button43"
        Me.Button43.Size = New System.Drawing.Size(46, 42)
        Me.Button43.TabIndex = 0
        Me.Button43.Text = "7"
        Me.Button43.UseVisualStyleBackColor = True
        '
        'lstLanctos
        '
        Me.lstLanctos.BackColor = System.Drawing.SystemColors.Control
        Me.lstLanctos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDPendencia, Me.Data, Me.Pagto, Me.Descricao, Me.Valor, Me.Saldo, Me.IDRetVenda, Me.IDVendaRetPagto, Me.Lancado})
        Me.lstLanctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLanctos.FullRowSelect = True
        Me.lstLanctos.GridLines = True
        Me.lstLanctos.HideSelection = False
        Me.lstLanctos.Location = New System.Drawing.Point(4, 304)
        Me.lstLanctos.MultiSelect = False
        Me.lstLanctos.Name = "lstLanctos"
        Me.lstLanctos.Size = New System.Drawing.Size(486, 251)
        Me.lstLanctos.TabIndex = 184
        Me.lstLanctos.UseCompatibleStateImageBehavior = False
        Me.lstLanctos.View = System.Windows.Forms.View.Details
        '
        'IDPendencia
        '
        Me.IDPendencia.Text = "ID"
        Me.IDPendencia.Width = 0
        '
        'Data
        '
        Me.Data.Text = "Data"
        '
        'Pagto
        '
        Me.Pagto.Text = "Pagto."
        Me.Pagto.Width = 120
        '
        'Descricao
        '
        Me.Descricao.Text = "Descrição"
        Me.Descricao.Width = 153
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Saldo
        '
        Me.Saldo.Text = "Saldo"
        Me.Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Saldo.Width = 70
        '
        'IDRetVenda
        '
        Me.IDRetVenda.Text = "IDVendaRet"
        Me.IDRetVenda.Width = 0
        '
        'IDVendaRetPagto
        '
        Me.IDVendaRetPagto.Text = "IDVendaRetPagto"
        Me.IDVendaRetPagto.Width = 0
        '
        'Lancado
        '
        Me.Lancado.Text = "Lancado"
        Me.Lancado.Width = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.tbIDVendaRet)
        Me.Panel3.Controls.Add(Me.lbSaldo)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.tbIDCliente)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.tbTel1)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.chkSaldoNegativo)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.tbCliente)
        Me.Panel3.Location = New System.Drawing.Point(496, 408)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(281, 145)
        Me.Panel3.TabIndex = 26
        '
        'tbIDVendaRet
        '
        Me.tbIDVendaRet.Location = New System.Drawing.Point(129, 56)
        Me.tbIDVendaRet.Name = "tbIDVendaRet"
        Me.tbIDVendaRet.Size = New System.Drawing.Size(48, 20)
        Me.tbIDVendaRet.TabIndex = 203
        Me.tbIDVendaRet.Visible = False
        '
        'lbSaldo
        '
        Me.lbSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSaldo.ForeColor = System.Drawing.Color.Maroon
        Me.lbSaldo.Location = New System.Drawing.Point(205, 116)
        Me.lbSaldo.Name = "lbSaldo"
        Me.lbSaldo.Size = New System.Drawing.Size(69, 13)
        Me.lbSaldo.TabIndex = 202
        Me.lbSaldo.Text = "0,00"
        Me.lbSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(174, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 201
        Me.Label9.Text = "Saldo"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(183, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 25)
        Me.Button1.TabIndex = 199
        Me.Button1.TabStop = False
        Me.Button1.Text = "Atualiza Saldo"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(6, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 13)
        Me.Label8.TabIndex = 198
        Me.Label8.Text = "Permite saldo negativo"
        '
        'tbIDCliente
        '
        Me.tbIDCliente.Location = New System.Drawing.Point(75, 56)
        Me.tbIDCliente.Name = "tbIDCliente"
        Me.tbIDCliente.Size = New System.Drawing.Size(48, 20)
        Me.tbIDCliente.TabIndex = 197
        Me.tbIDCliente.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(2, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 196
        Me.Label7.Text = "Telefone"
        '
        'tbTel1
        '
        Me.tbTel1.Location = New System.Drawing.Point(7, 79)
        Me.tbTel1.Name = "tbTel1"
        Me.tbTel1.Size = New System.Drawing.Size(211, 20)
        Me.tbTel1.TabIndex = 195
        Me.tbTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(1, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Cliente"
        '
        'chkSaldoNegativo
        '
        Me.chkSaldoNegativo.AutoSize = True
        Me.chkSaldoNegativo.ForeColor = System.Drawing.Color.Maroon
        Me.chkSaldoNegativo.Location = New System.Drawing.Point(121, 115)
        Me.chkSaldoNegativo.Name = "chkSaldoNegativo"
        Me.chkSaldoNegativo.Size = New System.Drawing.Size(15, 14)
        Me.chkSaldoNegativo.TabIndex = 194
        Me.chkSaldoNegativo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(2, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 193
        Me.Label6.Text = "Nome"
        '
        'tbCliente
        '
        Me.tbCliente.Location = New System.Drawing.Point(7, 34)
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.Size = New System.Drawing.Size(211, 20)
        Me.tbCliente.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 284)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 188
        Me.Label1.Text = "Período: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(46, 284)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Início"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(181, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = "Fim"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(4, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "Lançamentos"
        '
        'dtInicio
        '
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(77, 281)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtInicio.TabIndex = 196
        Me.dtInicio.Value = New Date(2015, 9, 4, 0, 0, 0, 0)
        '
        'dtFim
        '
        Me.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFim.Location = New System.Drawing.Point(204, 281)
        Me.dtFim.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtFim.Name = "dtFim"
        Me.dtFim.Size = New System.Drawing.Size(97, 20)
        Me.dtFim.TabIndex = 197
        Me.dtFim.Value = New Date(2015, 9, 4, 0, 0, 0, 0)
        '
        'btnExcluirLancto
        '
        Me.btnExcluirLancto.BackColor = System.Drawing.Color.White
        Me.btnExcluirLancto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluirLancto.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluirLancto.FlatAppearance.BorderSize = 0
        Me.btnExcluirLancto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluirLancto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluirLancto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnExcluirLancto.Image = Global.GourmetVisual.My.Resources.Resources.Trash
        Me.btnExcluirLancto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluirLancto.Location = New System.Drawing.Point(410, 266)
        Me.btnExcluirLancto.Name = "btnExcluirLancto"
        Me.btnExcluirLancto.Size = New System.Drawing.Size(78, 34)
        Me.btnExcluirLancto.TabIndex = 194
        Me.btnExcluirLancto.TabStop = False
        Me.btnExcluirLancto.Text = "Excluir"
        Me.btnExcluirLancto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluirLancto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluirLancto.UseVisualStyleBackColor = False
        '
        'btnIncluirLancto
        '
        Me.btnIncluirLancto.BackColor = System.Drawing.Color.White
        Me.btnIncluirLancto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluirLancto.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluirLancto.FlatAppearance.BorderSize = 0
        Me.btnIncluirLancto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluirLancto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluirLancto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnIncluirLancto.Image = CType(resources.GetObject("btnIncluirLancto.Image"), System.Drawing.Image)
        Me.btnIncluirLancto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluirLancto.Location = New System.Drawing.Point(326, 266)
        Me.btnIncluirLancto.Name = "btnIncluirLancto"
        Me.btnIncluirLancto.Size = New System.Drawing.Size(79, 34)
        Me.btnIncluirLancto.TabIndex = 193
        Me.btnIncluirLancto.TabStop = False
        Me.btnIncluirLancto.Text = "Lançto."
        Me.btnIncluirLancto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIncluirLancto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluirLancto.UseVisualStyleBackColor = False
        '
        'lbQtdeLanc
        '
        Me.lbQtdeLanc.AutoSize = True
        Me.lbQtdeLanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeLanc.ForeColor = System.Drawing.Color.Blue
        Me.lbQtdeLanc.Location = New System.Drawing.Point(104, 262)
        Me.lbQtdeLanc.Name = "lbQtdeLanc"
        Me.lbQtdeLanc.Size = New System.Drawing.Size(0, 13)
        Me.lbQtdeLanc.TabIndex = 198
        '
        'chkPermiteSaldoNegativo
        '
        Me.chkPermiteSaldoNegativo.AutoSize = True
        Me.chkPermiteSaldoNegativo.Location = New System.Drawing.Point(136, 35)
        Me.chkPermiteSaldoNegativo.Name = "chkPermiteSaldoNegativo"
        Me.chkPermiteSaldoNegativo.Size = New System.Drawing.Size(133, 17)
        Me.chkPermiteSaldoNegativo.TabIndex = 204
        Me.chkPermiteSaldoNegativo.Text = "Permite saldo negativo"
        Me.chkPermiteSaldoNegativo.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(241, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 30)
        Me.Button2.TabIndex = 205
        Me.Button2.TabStop = False
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmPendencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 564)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbQtdeLanc)
        Me.Controls.Add(Me.dtInicio)
        Me.Controls.Add(Me.dtFim)
        Me.Controls.Add(Me.btnExcluirLancto)
        Me.Controls.Add(Me.btnIncluirLancto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lstLanctos)
        Me.Controls.Add(Me.PanelTeclado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmPendencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pendências"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelTeclado.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents lbTotalProdutos As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lstClientes As ListView
    Friend WithEvents IDCliente As ColumnHeader
    Friend WithEvents Cliente As ColumnHeader
    Friend WithEvents PanelTeclado As Panel
    Friend WithEvents Button33 As Button
    Friend WithEvents Button34 As Button
    Friend WithEvents Button35 As Button
    Friend WithEvents Button36 As Button
    Friend WithEvents Button37 As Button
    Friend WithEvents Button38 As Button
    Friend WithEvents Button41 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button24 As Button
    Friend WithEvents Button25 As Button
    Friend WithEvents Button26 As Button
    Friend WithEvents Button27 As Button
    Friend WithEvents Button28 As Button
    Friend WithEvents Button29 As Button
    Friend WithEvents Button30 As Button
    Friend WithEvents Button31 As Button
    Friend WithEvents Button32 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button21 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button39 As Button
    Friend WithEvents Button40 As Button
    Friend WithEvents Button42 As Button
    Friend WithEvents Button43 As Button
    Friend WithEvents lstLanctos As ListView
    Friend WithEvents IDPendencia As ColumnHeader
    Friend WithEvents Data As ColumnHeader
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents tbTel1 As TextBox
    Friend WithEvents chkSaldoNegativo As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbCliente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Pagto As ColumnHeader
    Friend WithEvents Descricao As ColumnHeader
    Friend WithEvents Valor As ColumnHeader
    Friend WithEvents Saldo As ColumnHeader
    Friend WithEvents btnExcluirLancto As Button
    Friend WithEvents btnIncluirLancto As Button
    Friend WithEvents dtInicio As DateTimePicker
    Friend WithEvents dtFim As DateTimePicker
    Friend WithEvents lbQtdeClientes As Label
    Friend WithEvents btnSair As Button
    Friend WithEvents btnRelatorios As Button
    Friend WithEvents btnAlterarCliente As Button
    Friend WithEvents btnExcluirCliente As Button
    Friend WithEvents btnIncluirCliente As Button
    Friend WithEvents Tel1 As ColumnHeader
    Friend WithEvents SaldoNegativo As ColumnHeader
    Friend WithEvents tbIDCliente As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lbQtdeLanc As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lbSaldo As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Saldo_ As ColumnHeader
    Friend WithEvents IDRetVenda As ColumnHeader
    Friend WithEvents tbIDVendaRet As TextBox
    Friend WithEvents IDVendaRetPagto As ColumnHeader
    Friend WithEvents Lancado As ColumnHeader
    Friend WithEvents chkPermiteSaldoNegativo As CheckBox
    Friend WithEvents Button2 As Button
End Class
