<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgTransferencias
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgTransferencias))
        Me.lbHoraPedido = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridMotivo = New System.Windows.Forms.DataGridView()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridProdutos = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDVendaMovto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkTransfereMesa = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbPorQuantidade = New System.Windows.Forms.RadioButton()
        Me.rbPorLancamento = New System.Windows.Forms.RadioButton()
        Me.btnSai = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbQuantidade = New System.Windows.Forms.TextBox()
        Me.tbIDVendaDestino = New System.Windows.Forms.TextBox()
        Me.tbMesaDestino = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbQuantidade = New System.Windows.Forms.Label()
        Me.lbMesaOrigem = New System.Windows.Forms.Label()
        Me.lbStatusMesa = New System.Windows.Forms.Label()
        Me.tbCodigoProduto = New System.Windows.Forms.TextBox()
        Me.PanelTeclado = New System.Windows.Forms.Panel()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.GridMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelTeclado.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbHoraPedido
        '
        Me.lbHoraPedido.AutoSize = True
        Me.lbHoraPedido.Location = New System.Drawing.Point(323, 173)
        Me.lbHoraPedido.Name = "lbHoraPedido"
        Me.lbHoraPedido.Size = New System.Drawing.Size(66, 13)
        Me.lbHoraPedido.TabIndex = 30
        Me.lbHoraPedido.Text = "Hora Pedido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Qtde."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(64, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Produto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Código"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(411, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Motivo"
        '
        'GridMotivo
        '
        Me.GridMotivo.AllowUserToAddRows = False
        Me.GridMotivo.AllowUserToDeleteRows = False
        Me.GridMotivo.AllowUserToResizeColumns = False
        Me.GridMotivo.AllowUserToResizeRows = False
        Me.GridMotivo.BackgroundColor = System.Drawing.Color.White
        Me.GridMotivo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridMotivo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridMotivo.ColumnHeadersVisible = False
        Me.GridMotivo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Motivo})
        Me.GridMotivo.DataMember = "DescricaoPedido"
        Me.GridMotivo.Location = New System.Drawing.Point(415, 189)
        Me.GridMotivo.MultiSelect = False
        Me.GridMotivo.Name = "GridMotivo"
        Me.GridMotivo.ReadOnly = True
        Me.GridMotivo.RowHeadersVisible = False
        Me.GridMotivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridMotivo.Size = New System.Drawing.Size(217, 161)
        Me.GridMotivo.TabIndex = 25
        Me.GridMotivo.TabStop = False
        '
        'Motivo
        '
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        Me.Motivo.Width = 200
        '
        'GridProdutos
        '
        Me.GridProdutos.AllowUserToAddRows = False
        Me.GridProdutos.AllowUserToDeleteRows = False
        Me.GridProdutos.AllowUserToResizeColumns = False
        Me.GridProdutos.AllowUserToResizeRows = False
        Me.GridProdutos.BackgroundColor = System.Drawing.Color.White
        Me.GridProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridProdutos.ColumnHeadersVisible = False
        Me.GridProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.IDVendaMovto, Me.CodigoProduto, Me.Produto, Me.Qtde, Me.Hora})
        Me.GridProdutos.DataMember = "DescricaoPedido"
        Me.GridProdutos.GridColor = System.Drawing.SystemColors.ControlLight
        Me.GridProdutos.Location = New System.Drawing.Point(15, 189)
        Me.GridProdutos.Name = "GridProdutos"
        Me.GridProdutos.ReadOnly = True
        Me.GridProdutos.RowHeadersVisible = False
        Me.GridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridProdutos.Size = New System.Drawing.Size(390, 454)
        Me.GridProdutos.TabIndex = 24
        Me.GridProdutos.TabStop = False
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 5
        '
        'IDVendaMovto
        '
        Me.IDVendaMovto.HeaderText = "IDVendaMovto"
        Me.IDVendaMovto.Name = "IDVendaMovto"
        Me.IDVendaMovto.ReadOnly = True
        Me.IDVendaMovto.Visible = False
        Me.IDVendaMovto.Width = 5
        '
        'CodigoProduto
        '
        Me.CodigoProduto.HeaderText = "CodigoProduto"
        Me.CodigoProduto.Name = "CodigoProduto"
        Me.CodigoProduto.ReadOnly = True
        Me.CodigoProduto.Width = 50
        '
        'Produto
        '
        Me.Produto.HeaderText = "Produto"
        Me.Produto.Name = "Produto"
        Me.Produto.ReadOnly = True
        Me.Produto.Width = 200
        '
        'Qtde
        '
        Me.Qtde.HeaderText = "Qtde"
        Me.Qtde.Name = "Qtde"
        Me.Qtde.ReadOnly = True
        Me.Qtde.Width = 60
        '
        'Hora
        '
        Me.Hora.HeaderText = "Hora"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        Me.Hora.Width = 60
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkTransfereMesa)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnSai)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(7, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(622, 81)
        Me.Panel1.TabIndex = 31
        '
        'chkTransfereMesa
        '
        Me.chkTransfereMesa.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTransfereMesa.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.chkTransfereMesa.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkTransfereMesa.FlatAppearance.BorderSize = 0
        Me.chkTransfereMesa.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.chkTransfereMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTransfereMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTransfereMesa.ForeColor = System.Drawing.Color.Blue
        Me.chkTransfereMesa.Location = New System.Drawing.Point(89, 5)
        Me.chkTransfereMesa.Name = "chkTransfereMesa"
        Me.chkTransfereMesa.Size = New System.Drawing.Size(105, 68)
        Me.chkTransfereMesa.TabIndex = 29
        Me.chkTransfereMesa.Text = "Transfere Mesa"
        Me.chkTransfereMesa.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkTransfereMesa.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.rbPorQuantidade)
        Me.Panel3.Controls.Add(Me.rbPorLancamento)
        Me.Panel3.Location = New System.Drawing.Point(200, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(242, 68)
        Me.Panel3.TabIndex = 28
        '
        'rbPorQuantidade
        '
        Me.rbPorQuantidade.AutoSize = True
        Me.rbPorQuantidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorQuantidade.ForeColor = System.Drawing.Color.Navy
        Me.rbPorQuantidade.Location = New System.Drawing.Point(33, 33)
        Me.rbPorQuantidade.Name = "rbPorQuantidade"
        Me.rbPorQuantidade.Size = New System.Drawing.Size(174, 28)
        Me.rbPorQuantidade.TabIndex = 31
        Me.rbPorQuantidade.Text = "Por Quantidade"
        Me.rbPorQuantidade.UseVisualStyleBackColor = True
        '
        'rbPorLancamento
        '
        Me.rbPorLancamento.AutoSize = True
        Me.rbPorLancamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorLancamento.ForeColor = System.Drawing.Color.Navy
        Me.rbPorLancamento.Location = New System.Drawing.Point(33, 3)
        Me.rbPorLancamento.Name = "rbPorLancamento"
        Me.rbPorLancamento.Size = New System.Drawing.Size(180, 28)
        Me.rbPorLancamento.TabIndex = 30
        Me.rbPorLancamento.Text = "Por Lançamento"
        Me.rbPorLancamento.UseVisualStyleBackColor = True
        '
        'btnSai
        '
        Me.btnSai.BackColor = System.Drawing.Color.White
        Me.btnSai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSai.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSai.FlatAppearance.BorderSize = 0
        Me.btnSai.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSai.ForeColor = System.Drawing.Color.Blue
        Me.btnSai.Location = New System.Drawing.Point(8, 5)
        Me.btnSai.Name = "btnSai"
        Me.btnSai.Size = New System.Drawing.Size(75, 68)
        Me.btnSai.TabIndex = 13
        Me.btnSai.TabStop = False
        Me.btnSai.Text = "Sair"
        Me.btnSai.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirma.Location = New System.Drawing.Point(458, 5)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(154, 68)
        Me.btnConfirma.TabIndex = 12
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Confirma  F7"
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.tbQuantidade)
        Me.Panel2.Controls.Add(Me.tbIDVendaDestino)
        Me.Panel2.Controls.Add(Me.tbMesaDestino)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lbQuantidade)
        Me.Panel2.Controls.Add(Me.lbMesaOrigem)
        Me.Panel2.Controls.Add(Me.lbStatusMesa)
        Me.Panel2.Location = New System.Drawing.Point(7, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(622, 49)
        Me.Panel2.TabIndex = 32
        '
        'tbQuantidade
        '
        Me.tbQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbQuantidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbQuantidade.Location = New System.Drawing.Point(543, 13)
        Me.tbQuantidade.Name = "tbQuantidade"
        Me.tbQuantidade.Size = New System.Drawing.Size(68, 24)
        Me.tbQuantidade.TabIndex = 30
        Me.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbIDVendaDestino
        '
        Me.tbIDVendaDestino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbIDVendaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDVendaDestino.Location = New System.Drawing.Point(360, 11)
        Me.tbIDVendaDestino.Name = "tbIDVendaDestino"
        Me.tbIDVendaDestino.Size = New System.Drawing.Size(36, 24)
        Me.tbIDVendaDestino.TabIndex = 29
        Me.tbIDVendaDestino.TabStop = False
        Me.tbIDVendaDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDVendaDestino.Visible = False
        '
        'tbMesaDestino
        '
        Me.tbMesaDestino.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbMesaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMesaDestino.Location = New System.Drawing.Point(275, 11)
        Me.tbMesaDestino.Name = "tbMesaDestino"
        Me.tbMesaDestino.Size = New System.Drawing.Size(79, 24)
        Me.tbMesaDestino.TabIndex = 0
        Me.tbMesaDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(204, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Destino"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQuantidade
        '
        Me.lbQuantidade.AutoSize = True
        Me.lbQuantidade.ForeColor = System.Drawing.Color.Blue
        Me.lbQuantidade.Location = New System.Drawing.Point(479, 17)
        Me.lbQuantidade.Name = "lbQuantidade"
        Me.lbQuantidade.Size = New System.Drawing.Size(62, 13)
        Me.lbQuantidade.TabIndex = 26
        Me.lbQuantidade.Text = "Quantidade"
        '
        'lbMesaOrigem
        '
        Me.lbMesaOrigem.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbMesaOrigem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbMesaOrigem.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMesaOrigem.ForeColor = System.Drawing.Color.Navy
        Me.lbMesaOrigem.Location = New System.Drawing.Point(73, 9)
        Me.lbMesaOrigem.Name = "lbMesaOrigem"
        Me.lbMesaOrigem.Size = New System.Drawing.Size(79, 28)
        Me.lbMesaOrigem.TabIndex = 19
        Me.lbMesaOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbStatusMesa
        '
        Me.lbStatusMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatusMesa.ForeColor = System.Drawing.Color.Blue
        Me.lbStatusMesa.Location = New System.Drawing.Point(3, 13)
        Me.lbStatusMesa.Name = "lbStatusMesa"
        Me.lbStatusMesa.Size = New System.Drawing.Size(65, 20)
        Me.lbStatusMesa.TabIndex = 18
        Me.lbStatusMesa.Text = "Origem"
        Me.lbStatusMesa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCodigoProduto
        '
        Me.tbCodigoProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCodigoProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigoProduto.Location = New System.Drawing.Point(553, 148)
        Me.tbCodigoProduto.Multiline = True
        Me.tbCodigoProduto.Name = "tbCodigoProduto"
        Me.tbCodigoProduto.Size = New System.Drawing.Size(68, 20)
        Me.tbCodigoProduto.TabIndex = 33
        Me.tbCodigoProduto.TabStop = False
        Me.tbCodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCodigoProduto.Visible = False
        '
        'PanelTeclado
        '
        Me.PanelTeclado.BackColor = System.Drawing.Color.Gainsboro
        Me.PanelTeclado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTeclado.Controls.Add(Me.Button14)
        Me.PanelTeclado.Controls.Add(Me.Button11)
        Me.PanelTeclado.Controls.Add(Me.Button10)
        Me.PanelTeclado.Controls.Add(Me.Button7)
        Me.PanelTeclado.Controls.Add(Me.Button8)
        Me.PanelTeclado.Controls.Add(Me.Button9)
        Me.PanelTeclado.Controls.Add(Me.Button4)
        Me.PanelTeclado.Controls.Add(Me.Button5)
        Me.PanelTeclado.Controls.Add(Me.Button6)
        Me.PanelTeclado.Controls.Add(Me.Button3)
        Me.PanelTeclado.Controls.Add(Me.Button2)
        Me.PanelTeclado.Controls.Add(Me.Button1)
        Me.PanelTeclado.Location = New System.Drawing.Point(415, 356)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(217, 287)
        Me.PanelTeclado.TabIndex = 34
        '
        'Button14
        '
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button14.Location = New System.Drawing.Point(141, 211)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(70, 70)
        Me.Button14.TabIndex = 11
        Me.Button14.TabStop = False
        Me.Button14.Text = "Enter"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = CType(resources.GetObject("Button11.BackgroundImage"), System.Drawing.Image)
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button11.Location = New System.Drawing.Point(72, 211)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(70, 70)
        Me.Button11.TabIndex = 10
        Me.Button11.TabStop = False
        Me.Button11.Text = "Limpa"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button10.Location = New System.Drawing.Point(3, 210)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(70, 70)
        Me.Button10.TabIndex = 9
        Me.Button10.TabStop = False
        Me.Button10.Text = "0"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.Location = New System.Drawing.Point(141, 141)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(70, 70)
        Me.Button7.TabIndex = 8
        Me.Button7.TabStop = False
        Me.Button7.Text = "3"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"), System.Drawing.Image)
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button8.Location = New System.Drawing.Point(72, 141)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(70, 70)
        Me.Button8.TabIndex = 7
        Me.Button8.TabStop = False
        Me.Button8.Text = "2"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button9.Location = New System.Drawing.Point(3, 141)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(70, 70)
        Me.Button9.TabIndex = 6
        Me.Button9.TabStop = False
        Me.Button9.Text = "1"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(141, 72)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(70, 70)
        Me.Button4.TabIndex = 5
        Me.Button4.TabStop = False
        Me.Button4.Text = "6"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(72, 72)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(70, 70)
        Me.Button5.TabIndex = 4
        Me.Button5.TabStop = False
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button6.Location = New System.Drawing.Point(3, 72)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(70, 70)
        Me.Button6.TabIndex = 3
        Me.Button6.TabStop = False
        Me.Button6.Text = "4"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(141, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 70)
        Me.Button3.TabIndex = 2
        Me.Button3.TabStop = False
        Me.Button3.Text = "9"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(72, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 70)
        Me.Button2.TabIndex = 1
        Me.Button2.TabStop = False
        Me.Button2.Text = "8"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 70)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "7"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fdlgTransferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(637, 655)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelTeclado)
        Me.Controls.Add(Me.tbCodigoProduto)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbHoraPedido)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridMotivo)
        Me.Controls.Add(Me.GridProdutos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgTransferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferência de Produtos/Vendas"
        CType(Me.GridMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelTeclado.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbHoraPedido As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GridMotivo As DataGridView
    Friend WithEvents Motivo As DataGridViewTextBoxColumn
    Friend WithEvents GridProdutos As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents IDVendaMovto As DataGridViewTextBoxColumn
    Friend WithEvents CodigoProduto As DataGridViewTextBoxColumn
    Friend WithEvents Produto As DataGridViewTextBoxColumn
    Friend WithEvents Qtde As DataGridViewTextBoxColumn
    Friend WithEvents Hora As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnSai As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbQuantidade As Label
    Friend WithEvents lbMesaOrigem As Label
    Friend WithEvents lbStatusMesa As Label
    Friend WithEvents tbMesaDestino As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbIDVendaDestino As TextBox
    Friend WithEvents tbCodigoProduto As TextBox
    Friend WithEvents PanelTeclado As Panel
    Friend WithEvents Button14 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents rbPorQuantidade As RadioButton
    Friend WithEvents rbPorLancamento As RadioButton
    Friend WithEvents tbQuantidade As TextBox
    Friend WithEvents chkTransfereMesa As CheckBox
End Class
