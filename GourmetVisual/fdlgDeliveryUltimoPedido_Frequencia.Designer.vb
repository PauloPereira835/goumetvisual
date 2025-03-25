<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDeliveryUltimoPedido_Frequencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgDeliveryUltimoPedido_Frequencia))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnRepete = New System.Windows.Forms.Button()
        Me.tbUltVlrTaxaEntrega = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbIDVendaRet = New System.Windows.Forms.TextBox()
        Me.tbUltVlrVenda = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.tbUltVlrCaixinha = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.tbUltVlrDesconto = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.tbUltVlrProdutos = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.GridUltPedido = New System.Windows.Forms.DataGridView()
        Me.GrdProduto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrdQtde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrdVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrdTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbUltimoPedido = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.GridProdutosPedidos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel13.SuspendLayout()
        CType(Me.GridUltPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        CType(Me.GridProdutosPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(5, 4)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(91, 43)
        Me.btnVolta.TabIndex = 2
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel13.Controls.Add(Me.btnRepete)
        Me.Panel13.Controls.Add(Me.tbUltVlrTaxaEntrega)
        Me.Panel13.Controls.Add(Me.Label22)
        Me.Panel13.Controls.Add(Me.tbIDVendaRet)
        Me.Panel13.Controls.Add(Me.tbUltVlrVenda)
        Me.Panel13.Controls.Add(Me.Label62)
        Me.Panel13.Controls.Add(Me.tbUltVlrCaixinha)
        Me.Panel13.Controls.Add(Me.Label61)
        Me.Panel13.Controls.Add(Me.tbUltVlrDesconto)
        Me.Panel13.Controls.Add(Me.Label60)
        Me.Panel13.Controls.Add(Me.tbUltVlrProdutos)
        Me.Panel13.Controls.Add(Me.Label59)
        Me.Panel13.Controls.Add(Me.GridUltPedido)
        Me.Panel13.Controls.Add(Me.lbUltimoPedido)
        Me.Panel13.Location = New System.Drawing.Point(5, 53)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(452, 250)
        Me.Panel13.TabIndex = 36
        '
        'btnRepete
        '
        Me.btnRepete.BackColor = System.Drawing.Color.White
        Me.btnRepete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRepete.FlatAppearance.BorderSize = 0
        Me.btnRepete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRepete.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepete.ForeColor = System.Drawing.Color.Blue
        Me.btnRepete.Image = CType(resources.GetObject("btnRepete.Image"), System.Drawing.Image)
        Me.btnRepete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRepete.Location = New System.Drawing.Point(6, 168)
        Me.btnRepete.Name = "btnRepete"
        Me.btnRepete.Size = New System.Drawing.Size(96, 32)
        Me.btnRepete.TabIndex = 66
        Me.btnRepete.TabStop = False
        Me.btnRepete.Text = "Repetir pedido"
        Me.btnRepete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRepete.UseVisualStyleBackColor = False
        Me.btnRepete.Visible = False
        '
        'tbUltVlrTaxaEntrega
        '
        Me.tbUltVlrTaxaEntrega.BackColor = System.Drawing.Color.LightGray
        Me.tbUltVlrTaxaEntrega.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbUltVlrTaxaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUltVlrTaxaEntrega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbUltVlrTaxaEntrega.Location = New System.Drawing.Point(353, 213)
        Me.tbUltVlrTaxaEntrega.Multiline = True
        Me.tbUltVlrTaxaEntrega.Name = "tbUltVlrTaxaEntrega"
        Me.tbUltVlrTaxaEntrega.ReadOnly = True
        Me.tbUltVlrTaxaEntrega.Size = New System.Drawing.Size(68, 16)
        Me.tbUltVlrTaxaEntrega.TabIndex = 65
        Me.tbUltVlrTaxaEntrega.TabStop = False
        Me.tbUltVlrTaxaEntrega.Text = "0,00"
        Me.tbUltVlrTaxaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label22.Location = New System.Drawing.Point(219, 213)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 13)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "Taxa entrega"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbIDVendaRet
        '
        Me.tbIDVendaRet.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbIDVendaRet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbIDVendaRet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDVendaRet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbIDVendaRet.Location = New System.Drawing.Point(5, 205)
        Me.tbIDVendaRet.Name = "tbIDVendaRet"
        Me.tbIDVendaRet.Size = New System.Drawing.Size(44, 13)
        Me.tbIDVendaRet.TabIndex = 63
        Me.tbIDVendaRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDVendaRet.Visible = False
        '
        'tbUltVlrVenda
        '
        Me.tbUltVlrVenda.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tbUltVlrVenda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbUltVlrVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUltVlrVenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbUltVlrVenda.Location = New System.Drawing.Point(353, 229)
        Me.tbUltVlrVenda.Multiline = True
        Me.tbUltVlrVenda.Name = "tbUltVlrVenda"
        Me.tbUltVlrVenda.ReadOnly = True
        Me.tbUltVlrVenda.Size = New System.Drawing.Size(68, 16)
        Me.tbUltVlrVenda.TabIndex = 53
        Me.tbUltVlrVenda.TabStop = False
        Me.tbUltVlrVenda.Text = "0,00"
        Me.tbUltVlrVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label62
        '
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Navy
        Me.Label62.Location = New System.Drawing.Point(219, 229)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(131, 13)
        Me.Label62.TabIndex = 52
        Me.Label62.Text = "Total"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbUltVlrCaixinha
        '
        Me.tbUltVlrCaixinha.BackColor = System.Drawing.Color.LightGray
        Me.tbUltVlrCaixinha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbUltVlrCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUltVlrCaixinha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbUltVlrCaixinha.Location = New System.Drawing.Point(353, 197)
        Me.tbUltVlrCaixinha.Multiline = True
        Me.tbUltVlrCaixinha.Name = "tbUltVlrCaixinha"
        Me.tbUltVlrCaixinha.ReadOnly = True
        Me.tbUltVlrCaixinha.Size = New System.Drawing.Size(68, 16)
        Me.tbUltVlrCaixinha.TabIndex = 51
        Me.tbUltVlrCaixinha.TabStop = False
        Me.tbUltVlrCaixinha.Text = "0,00"
        Me.tbUltVlrCaixinha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label61.Location = New System.Drawing.Point(219, 197)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(131, 13)
        Me.Label61.TabIndex = 50
        Me.Label61.Text = "Caixinha"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbUltVlrDesconto
        '
        Me.tbUltVlrDesconto.BackColor = System.Drawing.Color.LightGray
        Me.tbUltVlrDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbUltVlrDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUltVlrDesconto.ForeColor = System.Drawing.Color.Maroon
        Me.tbUltVlrDesconto.Location = New System.Drawing.Point(353, 181)
        Me.tbUltVlrDesconto.Multiline = True
        Me.tbUltVlrDesconto.Name = "tbUltVlrDesconto"
        Me.tbUltVlrDesconto.ReadOnly = True
        Me.tbUltVlrDesconto.Size = New System.Drawing.Size(68, 16)
        Me.tbUltVlrDesconto.TabIndex = 49
        Me.tbUltVlrDesconto.TabStop = False
        Me.tbUltVlrDesconto.Text = "0,00"
        Me.tbUltVlrDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label60.Location = New System.Drawing.Point(219, 181)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(131, 13)
        Me.Label60.TabIndex = 48
        Me.Label60.Text = "Desconto"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbUltVlrProdutos
        '
        Me.tbUltVlrProdutos.BackColor = System.Drawing.Color.LightGray
        Me.tbUltVlrProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbUltVlrProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUltVlrProdutos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbUltVlrProdutos.Location = New System.Drawing.Point(353, 165)
        Me.tbUltVlrProdutos.Multiline = True
        Me.tbUltVlrProdutos.Name = "tbUltVlrProdutos"
        Me.tbUltVlrProdutos.ReadOnly = True
        Me.tbUltVlrProdutos.Size = New System.Drawing.Size(68, 16)
        Me.tbUltVlrProdutos.TabIndex = 47
        Me.tbUltVlrProdutos.TabStop = False
        Me.tbUltVlrProdutos.Text = "0,00"
        Me.tbUltVlrProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label59.Location = New System.Drawing.Point(219, 165)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(131, 13)
        Me.Label59.TabIndex = 46
        Me.Label59.Text = "Produtos"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GridUltPedido
        '
        Me.GridUltPedido.AllowUserToAddRows = False
        Me.GridUltPedido.AllowUserToDeleteRows = False
        Me.GridUltPedido.AllowUserToResizeColumns = False
        Me.GridUltPedido.AllowUserToResizeRows = False
        Me.GridUltPedido.BackgroundColor = System.Drawing.Color.LightGray
        Me.GridUltPedido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridUltPedido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridUltPedido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridUltPedido.ColumnHeadersVisible = False
        Me.GridUltPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GrdProduto, Me.GrdQtde, Me.GrdVenda, Me.GrdTotal})
        Me.GridUltPedido.DataMember = "DescricaoPedido"
        Me.GridUltPedido.Location = New System.Drawing.Point(6, 17)
        Me.GridUltPedido.MultiSelect = False
        Me.GridUltPedido.Name = "GridUltPedido"
        Me.GridUltPedido.ReadOnly = True
        Me.GridUltPedido.RowHeadersVisible = False
        Me.GridUltPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridUltPedido.Size = New System.Drawing.Size(436, 146)
        Me.GridUltPedido.TabIndex = 38
        Me.GridUltPedido.TabStop = False
        '
        'GrdProduto
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Navy
        Me.GrdProduto.DefaultCellStyle = DataGridViewCellStyle13
        Me.GrdProduto.HeaderText = "Produto"
        Me.GrdProduto.Name = "GrdProduto"
        Me.GrdProduto.ReadOnly = True
        Me.GrdProduto.Width = 238
        '
        'GrdQtde
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Navy
        Me.GrdQtde.DefaultCellStyle = DataGridViewCellStyle14
        Me.GrdQtde.HeaderText = "Qtde"
        Me.GrdQtde.Name = "GrdQtde"
        Me.GrdQtde.ReadOnly = True
        Me.GrdQtde.Width = 60
        '
        'GrdVenda
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Navy
        Me.GrdVenda.DefaultCellStyle = DataGridViewCellStyle15
        Me.GrdVenda.HeaderText = "Venda"
        Me.GrdVenda.Name = "GrdVenda"
        Me.GrdVenda.ReadOnly = True
        Me.GrdVenda.Width = 60
        '
        'GrdTotal
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Navy
        Me.GrdTotal.DefaultCellStyle = DataGridViewCellStyle16
        Me.GrdTotal.HeaderText = "Total"
        Me.GrdTotal.Name = "GrdTotal"
        Me.GrdTotal.ReadOnly = True
        Me.GrdTotal.Width = 60
        '
        'lbUltimoPedido
        '
        Me.lbUltimoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUltimoPedido.ForeColor = System.Drawing.Color.Purple
        Me.lbUltimoPedido.Location = New System.Drawing.Point(-2, 1)
        Me.lbUltimoPedido.Name = "lbUltimoPedido"
        Me.lbUltimoPedido.Size = New System.Drawing.Size(352, 13)
        Me.lbUltimoPedido.TabIndex = 37
        Me.lbUltimoPedido.Text = "Último pedido"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel14.Controls.Add(Me.GridProdutosPedidos)
        Me.Panel14.Controls.Add(Me.Label49)
        Me.Panel14.Location = New System.Drawing.Point(463, 53)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(348, 250)
        Me.Panel14.TabIndex = 37
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Purple
        Me.Label49.Location = New System.Drawing.Point(-2, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(131, 13)
        Me.Label49.TabIndex = 38
        Me.Label49.Text = "Produtos pedidos"
        '
        'GridProdutosPedidos
        '
        Me.GridProdutosPedidos.AllowUserToAddRows = False
        Me.GridProdutosPedidos.AllowUserToDeleteRows = False
        Me.GridProdutosPedidos.AllowUserToResizeColumns = False
        Me.GridProdutosPedidos.AllowUserToResizeRows = False
        Me.GridProdutosPedidos.BackgroundColor = System.Drawing.Color.LightGray
        Me.GridProdutosPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridProdutosPedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridProdutosPedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridProdutosPedidos.ColumnHeadersVisible = False
        Me.GridProdutosPedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.GridProdutosPedidos.DataMember = "DescricaoPedido"
        Me.GridProdutosPedidos.Location = New System.Drawing.Point(3, 17)
        Me.GridProdutosPedidos.MultiSelect = False
        Me.GridProdutosPedidos.Name = "GridProdutosPedidos"
        Me.GridProdutosPedidos.ReadOnly = True
        Me.GridProdutosPedidos.RowHeadersVisible = False
        Me.GridProdutosPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridProdutosPedidos.Size = New System.Drawing.Size(338, 226)
        Me.GridProdutosPedidos.TabIndex = 39
        Me.GridProdutosPedidos.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Navy
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn1.HeaderText = "Produto"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 220
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Navy
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn2.HeaderText = "Qtde"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'fdlgDeliveryUltimoPedido_Frequencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(818, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.btnVolta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDeliveryUltimoPedido_Frequencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Último pedido e Produtos pedidos"
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        CType(Me.GridUltPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        CType(Me.GridProdutosPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVolta As Button
    Friend WithEvents Panel13 As Panel
    Friend WithEvents btnRepete As Button
    Friend WithEvents tbUltVlrTaxaEntrega As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents tbIDVendaRet As TextBox
    Friend WithEvents tbUltVlrVenda As TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents tbUltVlrCaixinha As TextBox
    Friend WithEvents Label61 As Label
    Friend WithEvents tbUltVlrDesconto As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents tbUltVlrProdutos As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents GridUltPedido As DataGridView
    Friend WithEvents GrdProduto As DataGridViewTextBoxColumn
    Friend WithEvents GrdQtde As DataGridViewTextBoxColumn
    Friend WithEvents GrdVenda As DataGridViewTextBoxColumn
    Friend WithEvents GrdTotal As DataGridViewTextBoxColumn
    Friend WithEvents lbUltimoPedido As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label49 As Label
    Friend WithEvents GridProdutosPedidos As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
