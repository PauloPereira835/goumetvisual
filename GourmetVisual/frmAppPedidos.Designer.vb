<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAppPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppPedidos))
        Me.lstDescricao = New System.Windows.Forms.ListView()
        Me.lstCodPro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstProduto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstQtde = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstIDmovto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstIDmovtoCombo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodExterno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbDescricao = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbTotalProd = New System.Windows.Forms.Label()
        Me.PanelProdutos = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEnvia = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.lbSelecione = New System.Windows.Forms.Label()
        Me.lstProdutos = New System.Windows.Forms.ListView()
        Me.lstIDProduto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstCodProdutoBusca = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstProdutoBusca = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstVendaBusca = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbQtde = New System.Windows.Forms.Label()
        Me.chkConfirmados = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkRejeitado = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbBuscaPedido = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.image = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDpedidoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDreferenciaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumPedidoVendaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataSetGrid = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.btnAceitar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbDesconto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.PanelProdutos.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstDescricao
        '
        Me.lstDescricao.BackColor = System.Drawing.SystemColors.Control
        Me.lstDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstDescricao.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstCodPro, Me.lstProduto, Me.lstQtde, Me.lstVenda, Me.lstIDmovto, Me.lstIDmovtoCombo, Me.lstTotal, Me.CodExterno})
        Me.lstDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDescricao.ForeColor = System.Drawing.Color.Blue
        Me.lstDescricao.FullRowSelect = True
        Me.lstDescricao.GridLines = True
        Me.lstDescricao.HideSelection = False
        Me.lstDescricao.Location = New System.Drawing.Point(338, 23)
        Me.lstDescricao.MultiSelect = False
        Me.lstDescricao.Name = "lstDescricao"
        Me.lstDescricao.Size = New System.Drawing.Size(511, 611)
        Me.lstDescricao.TabIndex = 87
        Me.lstDescricao.UseCompatibleStateImageBehavior = False
        Me.lstDescricao.View = System.Windows.Forms.View.Details
        '
        'lstCodPro
        '
        Me.lstCodPro.Text = "Código"
        '
        'lstProduto
        '
        Me.lstProduto.Text = "Produto"
        Me.lstProduto.Width = 200
        '
        'lstQtde
        '
        Me.lstQtde.Text = "Qtde"
        Me.lstQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstQtde.Width = 63
        '
        'lstVenda
        '
        Me.lstVenda.Text = "Venda"
        Me.lstVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstVenda.Width = 80
        '
        'lstIDmovto
        '
        Me.lstIDmovto.Text = "IDMovto"
        Me.lstIDmovto.Width = 0
        '
        'lstIDmovtoCombo
        '
        Me.lstIDmovtoCombo.Text = "IDmovtoCombo"
        Me.lstIDmovtoCombo.Width = 0
        '
        'lstTotal
        '
        Me.lstTotal.Text = "Total"
        Me.lstTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstTotal.Width = 85
        '
        'CodExterno
        '
        Me.CodExterno.Text = "CodigoProdutoExterno"
        Me.CodExterno.Width = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tbDescricao)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.lbTotalProd)
        Me.Panel1.Controls.Add(Me.PanelProdutos)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lstDescricao)
        Me.Panel1.Location = New System.Drawing.Point(381, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 683)
        Me.Panel1.TabIndex = 88
        '
        'tbDescricao
        '
        Me.tbDescricao.BackColor = System.Drawing.Color.Transparent
        Me.tbDescricao.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescricao.ForeColor = System.Drawing.Color.DodgerBlue
        Me.tbDescricao.Location = New System.Drawing.Point(9, 22)
        Me.tbDescricao.Name = "tbDescricao"
        Me.tbDescricao.Size = New System.Drawing.Size(314, 373)
        Me.tbDescricao.TabIndex = 100
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(338, 635)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(41, 40)
        Me.Button4.TabIndex = 99
        Me.Button4.TabStop = False
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(385, 635)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(41, 40)
        Me.Button3.TabIndex = 98
        Me.Button3.TabStop = False
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(432, 635)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(41, 40)
        Me.Button2.TabIndex = 97
        Me.Button2.TabStop = False
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'lbTotalProd
        '
        Me.lbTotalProd.BackColor = System.Drawing.Color.Transparent
        Me.lbTotalProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalProd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbTotalProd.Location = New System.Drawing.Point(547, 637)
        Me.lbTotalProd.Name = "lbTotalProd"
        Me.lbTotalProd.Size = New System.Drawing.Size(288, 42)
        Me.lbTotalProd.TabIndex = 93
        Me.lbTotalProd.Text = "0,00"
        Me.lbTotalProd.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelProdutos
        '
        Me.PanelProdutos.BackColor = System.Drawing.Color.Gray
        Me.PanelProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelProdutos.Controls.Add(Me.Button5)
        Me.PanelProdutos.Controls.Add(Me.Button1)
        Me.PanelProdutos.Controls.Add(Me.btnEnvia)
        Me.PanelProdutos.Controls.Add(Me.Label4)
        Me.PanelProdutos.Controls.Add(Me.tbBusca)
        Me.PanelProdutos.Controls.Add(Me.lbSelecione)
        Me.PanelProdutos.Controls.Add(Me.lstProdutos)
        Me.PanelProdutos.Location = New System.Drawing.Point(4, 401)
        Me.PanelProdutos.Name = "PanelProdutos"
        Me.PanelProdutos.Size = New System.Drawing.Size(326, 271)
        Me.PanelProdutos.TabIndex = 91
        Me.PanelProdutos.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(186, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(31, 26)
        Me.Button5.TabIndex = 96
        Me.Button5.TabStop = False
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
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
        Me.Button1.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button1.Location = New System.Drawing.Point(172, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 24)
        Me.Button1.TabIndex = 95
        Me.Button1.TabStop = False
        Me.Button1.Text = "Cadastra novo produto"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnEnvia
        '
        Me.btnEnvia.BackColor = System.Drawing.Color.White
        Me.btnEnvia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEnvia.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEnvia.FlatAppearance.BorderSize = 0
        Me.btnEnvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnvia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnvia.ForeColor = System.Drawing.Color.Black
        Me.btnEnvia.Image = CType(resources.GetObject("btnEnvia.Image"), System.Drawing.Image)
        Me.btnEnvia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnvia.Location = New System.Drawing.Point(234, 3)
        Me.btnEnvia.Name = "btnEnvia"
        Me.btnEnvia.Size = New System.Drawing.Size(83, 33)
        Me.btnEnvia.TabIndex = 94
        Me.btnEnvia.TabStop = False
        Me.btnEnvia.Text = "Enviar"
        Me.btnEnvia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnvia.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Busca"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbBusca
        '
        Me.tbBusca.ForeColor = System.Drawing.Color.Navy
        Me.tbBusca.Location = New System.Drawing.Point(49, 9)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(138, 20)
        Me.tbBusca.TabIndex = 93
        '
        'lbSelecione
        '
        Me.lbSelecione.BackColor = System.Drawing.Color.Gray
        Me.lbSelecione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbSelecione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSelecione.ForeColor = System.Drawing.Color.Gold
        Me.lbSelecione.Location = New System.Drawing.Point(6, 40)
        Me.lbSelecione.Name = "lbSelecione"
        Me.lbSelecione.Size = New System.Drawing.Size(309, 20)
        Me.lbSelecione.TabIndex = 92
        Me.lbSelecione.Text = "Selecione um produto para ser vinculado"
        Me.lbSelecione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstProdutos
        '
        Me.lstProdutos.BackColor = System.Drawing.Color.White
        Me.lstProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstProdutos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstIDProduto, Me.lstCodProdutoBusca, Me.lstProdutoBusca, Me.lstVendaBusca})
        Me.lstProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProdutos.ForeColor = System.Drawing.Color.Navy
        Me.lstProdutos.FullRowSelect = True
        Me.lstProdutos.GridLines = True
        Me.lstProdutos.HideSelection = False
        Me.lstProdutos.Location = New System.Drawing.Point(3, 60)
        Me.lstProdutos.MultiSelect = False
        Me.lstProdutos.Name = "lstProdutos"
        Me.lstProdutos.Size = New System.Drawing.Size(315, 179)
        Me.lstProdutos.TabIndex = 91
        Me.lstProdutos.UseCompatibleStateImageBehavior = False
        Me.lstProdutos.View = System.Windows.Forms.View.Details
        '
        'lstIDProduto
        '
        Me.lstIDProduto.Text = "IDProduto"
        Me.lstIDProduto.Width = 0
        '
        'lstCodProdutoBusca
        '
        Me.lstCodProdutoBusca.Text = "Código"
        Me.lstCodProdutoBusca.Width = 53
        '
        'lstProdutoBusca
        '
        Me.lstProdutoBusca.Text = "Produto"
        Me.lstProdutoBusca.Width = 180
        '
        'lstVendaBusca
        '
        Me.lstVendaBusca.Text = "Venda"
        Me.lstVendaBusca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstVendaBusca.Width = 57
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(335, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 16)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Descrição do pedido"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 16)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Sobre o pedido"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbQtde
        '
        Me.lbQtde.BackColor = System.Drawing.Color.Transparent
        Me.lbQtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtde.ForeColor = System.Drawing.Color.Maroon
        Me.lbQtde.Location = New System.Drawing.Point(6, 618)
        Me.lbQtde.Name = "lbQtde"
        Me.lbQtde.Size = New System.Drawing.Size(365, 13)
        Me.lbQtde.TabIndex = 89
        Me.lbQtde.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkConfirmados
        '
        Me.chkConfirmados.AutoSize = True
        Me.chkConfirmados.Location = New System.Drawing.Point(361, 58)
        Me.chkConfirmados.Name = "chkConfirmados"
        Me.chkConfirmados.Size = New System.Drawing.Size(15, 14)
        Me.chkConfirmados.TabIndex = 91
        Me.chkConfirmados.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(244, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 14)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Pedidos aceitos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(299, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 14)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Rejeitados"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkRejeitado
        '
        Me.chkRejeitado.AutoSize = True
        Me.chkRejeitado.Location = New System.Drawing.Point(361, 38)
        Me.chkRejeitado.Name = "chkRejeitado"
        Me.chkRejeitado.Size = New System.Drawing.Size(15, 14)
        Me.chkRejeitado.TabIndex = 94
        Me.chkRejeitado.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(4, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Busca pedido"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbBuscaPedido
        '
        Me.tbBuscaPedido.ForeColor = System.Drawing.Color.Navy
        Me.tbBuscaPedido.Location = New System.Drawing.Point(80, 72)
        Me.tbBuscaPedido.Name = "tbBuscaPedido"
        Me.tbBuscaPedido.Size = New System.Drawing.Size(125, 20)
        Me.tbBuscaPedido.TabIndex = 96
        Me.tbBuscaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.AutoGenerateColumns = False
        Me.Grid.BackgroundColor = System.Drawing.Color.White
        Me.Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Grid.ColumnHeadersVisible = False
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.image, Me.Column1, Me.IDpedidoDataGridViewTextBoxColumn, Me.AppDataGridViewTextBoxColumn, Me.IDreferenciaDataGridViewTextBoxColumn, Me.NumPedidoVendaDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn})
        Me.Grid.DataMember = "DescricaoPedido"
        Me.Grid.DataSource = Me.DataSetGrid
        Me.Grid.Location = New System.Drawing.Point(5, 129)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(368, 508)
        Me.Grid.TabIndex = 97
        '
        'image
        '
        Me.image.HeaderText = "image"
        Me.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.image.Name = "image"
        Me.image.ReadOnly = True
        Me.image.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.image.Width = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 10
        '
        'IDpedidoDataGridViewTextBoxColumn
        '
        Me.IDpedidoDataGridViewTextBoxColumn.DataPropertyName = "IDpedido"
        Me.IDpedidoDataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.IDpedidoDataGridViewTextBoxColumn.HeaderText = "IDpedido"
        Me.IDpedidoDataGridViewTextBoxColumn.Name = "IDpedidoDataGridViewTextBoxColumn"
        Me.IDpedidoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDpedidoDataGridViewTextBoxColumn.Visible = False
        Me.IDpedidoDataGridViewTextBoxColumn.Width = 150
        '
        'AppDataGridViewTextBoxColumn
        '
        Me.AppDataGridViewTextBoxColumn.DataPropertyName = "App"
        Me.AppDataGridViewTextBoxColumn.HeaderText = "App"
        Me.AppDataGridViewTextBoxColumn.Name = "AppDataGridViewTextBoxColumn"
        Me.AppDataGridViewTextBoxColumn.ReadOnly = True
        Me.AppDataGridViewTextBoxColumn.Visible = False
        Me.AppDataGridViewTextBoxColumn.Width = 5
        '
        'IDreferenciaDataGridViewTextBoxColumn
        '
        Me.IDreferenciaDataGridViewTextBoxColumn.DataPropertyName = "IDreferencia"
        Me.IDreferenciaDataGridViewTextBoxColumn.HeaderText = "IDreferencia"
        Me.IDreferenciaDataGridViewTextBoxColumn.Name = "IDreferenciaDataGridViewTextBoxColumn"
        Me.IDreferenciaDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDreferenciaDataGridViewTextBoxColumn.Width = 150
        '
        'NumPedidoVendaDataGridViewTextBoxColumn
        '
        Me.NumPedidoVendaDataGridViewTextBoxColumn.DataPropertyName = "NumPedidoVenda"
        Me.NumPedidoVendaDataGridViewTextBoxColumn.HeaderText = "NumPedidoVenda"
        Me.NumPedidoVendaDataGridViewTextBoxColumn.Name = "NumPedidoVendaDataGridViewTextBoxColumn"
        Me.NumPedidoVendaDataGridViewTextBoxColumn.ReadOnly = True
        Me.NumPedidoVendaDataGridViewTextBoxColumn.Width = 50
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn.Width = 80
        '
        'DataSetGrid
        '
        Me.DataSetGrid.DataSetName = "NewDataSet"
        Me.DataSetGrid.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5})
        Me.DataTable1.TableName = "DescricaoPedido"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "IDpedido"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "NumPedidoVenda"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "App"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "IDreferencia"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Status"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(5, 642)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 27)
        Me.btnCancelar.TabIndex = 90
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Rejeitar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Black
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(6, 6)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(85, 48)
        Me.btnVoltar.TabIndex = 86
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'btnAceitar
        '
        Me.btnAceitar.BackColor = System.Drawing.Color.White
        Me.btnAceitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAceitar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAceitar.FlatAppearance.BorderSize = 0
        Me.btnAceitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceitar.ForeColor = System.Drawing.Color.Blue
        Me.btnAceitar.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnAceitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceitar.Location = New System.Drawing.Point(269, 641)
        Me.btnAceitar.Name = "btnAceitar"
        Me.btnAceitar.Size = New System.Drawing.Size(104, 50)
        Me.btnAceitar.TabIndex = 79
        Me.btnAceitar.TabStop = False
        Me.btnAceitar.Text = "Aceitar"
        Me.btnAceitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceitar.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Imagem"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Imagem"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'tbDesconto
        '
        Me.tbDesconto.ForeColor = System.Drawing.Color.Navy
        Me.tbDesconto.Location = New System.Drawing.Point(159, 21)
        Me.tbDesconto.Name = "tbDesconto"
        Me.tbDesconto.Size = New System.Drawing.Size(46, 20)
        Me.tbDesconto.TabIndex = 101
        Me.tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDesconto.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(10, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "App"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(67, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Referência"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(212, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 26)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Número Pedido"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(285, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 16)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(244, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 14)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Todos"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(361, 78)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(15, 14)
        Me.chkTodos.TabIndex = 106
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'frmAppPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1245, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkTodos)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbDesconto)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbBuscaPedido)
        Me.Controls.Add(Me.chkRejeitado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkConfirmados)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lbQtde)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.btnAceitar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmAppPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos aplicativo"
        Me.Panel1.ResumeLayout(False)
        Me.PanelProdutos.ResumeLayout(False)
        Me.PanelProdutos.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceitar As Button
    Friend WithEvents btnVoltar As Button
    Friend WithEvents lstDescricao As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbQtde As Label
    Friend WithEvents PanelProdutos As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents lbSelecione As Label
    Friend WithEvents lstProdutos As ListView
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lstCodPro As ColumnHeader
    Friend WithEvents lstProduto As ColumnHeader
    Friend WithEvents lstQtde As ColumnHeader
    Friend WithEvents lstVenda As ColumnHeader
    Friend WithEvents lstIDProduto As ColumnHeader
    Friend WithEvents lstCodProdutoBusca As ColumnHeader
    Friend WithEvents lstProdutoBusca As ColumnHeader
    Friend WithEvents lstVendaBusca As ColumnHeader
    Friend WithEvents lstIDmovto As ColumnHeader
    Friend WithEvents lstIDmovtoCombo As ColumnHeader
    Friend WithEvents btnEnvia As Button
    Friend WithEvents chkConfirmados As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lstTotal As ColumnHeader
    Friend WithEvents lbTotalProd As Label
    Friend WithEvents CodExterno As ColumnHeader
    Friend WithEvents Label6 As Label
    Friend WithEvents chkRejeitado As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents tbBuscaPedido As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Grid As DataGridView
    Friend WithEvents DataSetGrid As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents DataColumn4 As DataColumn
    Friend WithEvents DataColumn5 As DataColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Button4 As Button
    Friend WithEvents tbDesconto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents image As DataGridViewImageColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents IDpedidoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AppDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IDreferenciaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumPedidoVendaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents chkTodos As CheckBox
    Friend WithEvents tbDescricao As Label
    Friend WithEvents Button5 As Button
End Class
