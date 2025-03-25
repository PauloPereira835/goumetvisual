<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgAbreVenda_Clube
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgAbreVenda_Clube))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFicha = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.btnImprime = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDinheiro = New System.Windows.Forms.Button()
        Me.btnCartaoDebito = New System.Windows.Forms.Button()
        Me.btnCartaoCredito = New System.Windows.Forms.Button()
        Me.lstProdutos = New System.Windows.Forms.ListView()
        Me.IDProduto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoProduto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Produto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Quantidade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ValorUnit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalProd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Data = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDVendaMovto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel = New System.Windows.Forms.Panel()
        Me.tbIDProduto = New System.Windows.Forms.TextBox()
        Me.tbQtde = New System.Windows.Forms.TextBox()
        Me.GridProdutos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Venda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbCodPro = New System.Windows.Forms.TextBox()
        Me.btnInclui = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExclui = New System.Windows.Forms.Button()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbDataVenda = New System.Windows.Forms.Label()
        Me.lbNomeCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbLimiteCredito = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbObs = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbValorDesconto = New System.Windows.Forms.TextBox()
        Me.DataSetGridDel = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.GridProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataSetGridDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.btnFicha)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.tbIDVenda)
        Me.Panel1.Controls.Add(Me.btnImprime)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 54)
        Me.Panel1.TabIndex = 35
        '
        'btnFicha
        '
        Me.btnFicha.BackColor = System.Drawing.Color.White
        Me.btnFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFicha.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnFicha.FlatAppearance.BorderSize = 0
        Me.btnFicha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFicha.ForeColor = System.Drawing.Color.Navy
        Me.btnFicha.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnFicha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFicha.Location = New System.Drawing.Point(577, 7)
        Me.btnFicha.Name = "btnFicha"
        Me.btnFicha.Size = New System.Drawing.Size(100, 41)
        Me.btnFicha.TabIndex = 5
        Me.btnFicha.TabStop = False
        Me.btnFicha.Text = "Ficha"
        Me.btnFicha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFicha.UseVisualStyleBackColor = False
        Me.btnFicha.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(226, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(311, 41)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Abre Venda"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(96, 18)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(56, 20)
        Me.tbIDVenda.TabIndex = 3
        Me.tbIDVenda.TabStop = False
        Me.tbIDVenda.Visible = False
        '
        'btnImprime
        '
        Me.btnImprime.BackColor = System.Drawing.Color.White
        Me.btnImprime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprime.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnImprime.FlatAppearance.BorderSize = 0
        Me.btnImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprime.ForeColor = System.Drawing.Color.Navy
        Me.btnImprime.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnImprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprime.Location = New System.Drawing.Point(683, 7)
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(100, 41)
        Me.btnImprime.TabIndex = 2
        Me.btnImprime.TabStop = False
        Me.btnImprime.Text = "Conta"
        Me.btnImprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprime.UseVisualStyleBackColor = False
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
        Me.btnVolta.Location = New System.Drawing.Point(9, 7)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(77, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.btnDinheiro)
        Me.Panel2.Controls.Add(Me.btnCartaoDebito)
        Me.Panel2.Controls.Add(Me.btnCartaoCredito)
        Me.Panel2.Location = New System.Drawing.Point(0, 706)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(797, 54)
        Me.Panel2.TabIndex = 55
        '
        'btnDinheiro
        '
        Me.btnDinheiro.BackColor = System.Drawing.Color.White
        Me.btnDinheiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDinheiro.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnDinheiro.FlatAppearance.BorderSize = 0
        Me.btnDinheiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDinheiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDinheiro.ForeColor = System.Drawing.Color.Navy
        Me.btnDinheiro.Image = CType(resources.GetObject("btnDinheiro.Image"), System.Drawing.Image)
        Me.btnDinheiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDinheiro.Location = New System.Drawing.Point(613, 7)
        Me.btnDinheiro.Name = "btnDinheiro"
        Me.btnDinheiro.Size = New System.Drawing.Size(174, 41)
        Me.btnDinheiro.TabIndex = 3
        Me.btnDinheiro.TabStop = False
        Me.btnDinheiro.Text = "Dinheiro"
        Me.btnDinheiro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDinheiro.UseVisualStyleBackColor = False
        '
        'btnCartaoDebito
        '
        Me.btnCartaoDebito.BackColor = System.Drawing.Color.White
        Me.btnCartaoDebito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCartaoDebito.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCartaoDebito.FlatAppearance.BorderSize = 0
        Me.btnCartaoDebito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCartaoDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCartaoDebito.ForeColor = System.Drawing.Color.Navy
        Me.btnCartaoDebito.Image = CType(resources.GetObject("btnCartaoDebito.Image"), System.Drawing.Image)
        Me.btnCartaoDebito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCartaoDebito.Location = New System.Drawing.Point(307, 7)
        Me.btnCartaoDebito.Name = "btnCartaoDebito"
        Me.btnCartaoDebito.Size = New System.Drawing.Size(174, 41)
        Me.btnCartaoDebito.TabIndex = 2
        Me.btnCartaoDebito.TabStop = False
        Me.btnCartaoDebito.Text = "Cartão de Dédito"
        Me.btnCartaoDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCartaoDebito.UseVisualStyleBackColor = False
        '
        'btnCartaoCredito
        '
        Me.btnCartaoCredito.BackColor = System.Drawing.Color.White
        Me.btnCartaoCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCartaoCredito.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCartaoCredito.FlatAppearance.BorderSize = 0
        Me.btnCartaoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCartaoCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCartaoCredito.ForeColor = System.Drawing.Color.Navy
        Me.btnCartaoCredito.Image = CType(resources.GetObject("btnCartaoCredito.Image"), System.Drawing.Image)
        Me.btnCartaoCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCartaoCredito.Location = New System.Drawing.Point(9, 7)
        Me.btnCartaoCredito.Name = "btnCartaoCredito"
        Me.btnCartaoCredito.Size = New System.Drawing.Size(174, 41)
        Me.btnCartaoCredito.TabIndex = 1
        Me.btnCartaoCredito.TabStop = False
        Me.btnCartaoCredito.Text = "Cartão de Crédito"
        Me.btnCartaoCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCartaoCredito.UseVisualStyleBackColor = False
        '
        'lstProdutos
        '
        Me.lstProdutos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstProdutos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDProduto, Me.CodigoProduto, Me.Produto, Me.Quantidade, Me.ValorUnit, Me.TotalProd, Me.Data, Me.IDVendaMovto})
        Me.lstProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProdutos.ForeColor = System.Drawing.Color.Blue
        Me.lstProdutos.FullRowSelect = True
        Me.lstProdutos.GridLines = True
        Me.lstProdutos.HideSelection = False
        Me.lstProdutos.Location = New System.Drawing.Point(50, 282)
        Me.lstProdutos.MultiSelect = False
        Me.lstProdutos.Name = "lstProdutos"
        Me.lstProdutos.Size = New System.Drawing.Size(693, 344)
        Me.lstProdutos.TabIndex = 185
        Me.lstProdutos.TabStop = False
        Me.lstProdutos.UseCompatibleStateImageBehavior = False
        Me.lstProdutos.View = System.Windows.Forms.View.Details
        '
        'IDProduto
        '
        Me.IDProduto.Width = 0
        '
        'CodigoProduto
        '
        Me.CodigoProduto.DisplayIndex = 2
        Me.CodigoProduto.Text = "Codigo"
        Me.CodigoProduto.Width = 70
        '
        'Produto
        '
        Me.Produto.DisplayIndex = 3
        Me.Produto.Text = "Produto"
        Me.Produto.Width = 235
        '
        'Quantidade
        '
        Me.Quantidade.DisplayIndex = 4
        Me.Quantidade.Text = "Quantidade"
        Me.Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Quantidade.Width = 95
        '
        'ValorUnit
        '
        Me.ValorUnit.DisplayIndex = 5
        Me.ValorUnit.Text = "Valor Unitário"
        Me.ValorUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValorUnit.Width = 95
        '
        'TotalProd
        '
        Me.TotalProd.DisplayIndex = 6
        Me.TotalProd.Text = "Total"
        Me.TotalProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotalProd.Width = 95
        '
        'Data
        '
        Me.Data.DisplayIndex = 1
        Me.Data.Text = "Data"
        Me.Data.Width = 80
        '
        'IDVendaMovto
        '
        Me.IDVendaMovto.Text = "IDVendaMovto"
        Me.IDVendaMovto.Width = 0
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.tbIDProduto)
        Me.Panel.Controls.Add(Me.tbQtde)
        Me.Panel.Controls.Add(Me.GridProdutos)
        Me.Panel.Controls.Add(Me.tbCodPro)
        Me.Panel.Controls.Add(Me.btnInclui)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Location = New System.Drawing.Point(50, 63)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(693, 177)
        Me.Panel.TabIndex = 186
        '
        'tbIDProduto
        '
        Me.tbIDProduto.Location = New System.Drawing.Point(47, 86)
        Me.tbIDProduto.Name = "tbIDProduto"
        Me.tbIDProduto.Size = New System.Drawing.Size(56, 20)
        Me.tbIDProduto.TabIndex = 4
        Me.tbIDProduto.Visible = False
        '
        'tbQtde
        '
        Me.tbQtde.BackColor = System.Drawing.Color.AliceBlue
        Me.tbQtde.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbQtde.ForeColor = System.Drawing.Color.Navy
        Me.tbQtde.Location = New System.Drawing.Point(393, 9)
        Me.tbQtde.Multiline = True
        Me.tbQtde.Name = "tbQtde"
        Me.tbQtde.Size = New System.Drawing.Size(90, 30)
        Me.tbQtde.TabIndex = 75
        Me.tbQtde.TabStop = False
        Me.tbQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GridProdutos
        '
        Me.GridProdutos.AllowUserToAddRows = False
        Me.GridProdutos.AllowUserToDeleteRows = False
        Me.GridProdutos.AllowUserToResizeColumns = False
        Me.GridProdutos.AllowUserToResizeRows = False
        Me.GridProdutos.BackgroundColor = System.Drawing.Color.Lavender
        Me.GridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridProdutos.ColumnHeadersVisible = False
        Me.GridProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Venda})
        Me.GridProdutos.DataMember = "DescricaoPedido"
        Me.GridProdutos.Location = New System.Drawing.Point(142, 41)
        Me.GridProdutos.MultiSelect = False
        Me.GridProdutos.Name = "GridProdutos"
        Me.GridProdutos.ReadOnly = True
        Me.GridProdutos.RowHeadersVisible = False
        Me.GridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridProdutos.Size = New System.Drawing.Size(435, 129)
        Me.GridProdutos.TabIndex = 38
        Me.GridProdutos.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDProduto"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn2.HeaderText = "Código Produto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Produto"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'Venda
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Venda.DefaultCellStyle = DataGridViewCellStyle3
        Me.Venda.HeaderText = "Venda"
        Me.Venda.Name = "Venda"
        Me.Venda.ReadOnly = True
        '
        'tbCodPro
        '
        Me.tbCodPro.BackColor = System.Drawing.Color.AliceBlue
        Me.tbCodPro.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodPro.ForeColor = System.Drawing.Color.Navy
        Me.tbCodPro.Location = New System.Drawing.Point(142, 9)
        Me.tbCodPro.Name = "tbCodPro"
        Me.tbCodPro.Size = New System.Drawing.Size(247, 30)
        Me.tbCodPro.TabIndex = 0
        Me.tbCodPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnInclui
        '
        Me.btnInclui.BackColor = System.Drawing.Color.White
        Me.btnInclui.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnInclui.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnInclui.FlatAppearance.BorderSize = 0
        Me.btnInclui.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInclui.ForeColor = System.Drawing.Color.Navy
        Me.btnInclui.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnInclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInclui.Location = New System.Drawing.Point(589, 9)
        Me.btnInclui.Name = "btnInclui"
        Me.btnInclui.Size = New System.Drawing.Size(94, 41)
        Me.btnInclui.TabIndex = 3
        Me.btnInclui.TabStop = False
        Me.btnInclui.Text = "Incluir"
        Me.btnInclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInclui.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(2, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Busca Produto"
        '
        'btnExclui
        '
        Me.btnExclui.BackColor = System.Drawing.Color.White
        Me.btnExclui.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExclui.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExclui.FlatAppearance.BorderSize = 0
        Me.btnExclui.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExclui.ForeColor = System.Drawing.Color.Navy
        Me.btnExclui.Image = Global.GourmetVisual.My.Resources.Resources.Trash
        Me.btnExclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExclui.Location = New System.Drawing.Point(50, 631)
        Me.btnExclui.Name = "btnExclui"
        Me.btnExclui.Size = New System.Drawing.Size(88, 31)
        Me.btnExclui.TabIndex = 187
        Me.btnExclui.TabStop = False
        Me.btnExclui.Text = "Excluir"
        Me.btnExclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExclui.UseVisualStyleBackColor = False
        '
        'lbTotal
        '
        Me.lbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.ForeColor = System.Drawing.Color.Blue
        Me.lbTotal.Location = New System.Drawing.Point(544, 660)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(179, 37)
        Me.lbTotal.TabIndex = 188
        Me.lbTotal.Text = "0,00"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.lbDataVenda)
        Me.Panel3.Controls.Add(Me.lbNomeCliente)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(50, 241)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(693, 39)
        Me.Panel3.TabIndex = 189
        '
        'lbDataVenda
        '
        Me.lbDataVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDataVenda.ForeColor = System.Drawing.Color.Red
        Me.lbDataVenda.Location = New System.Drawing.Point(535, 3)
        Me.lbDataVenda.Name = "lbDataVenda"
        Me.lbDataVenda.Size = New System.Drawing.Size(151, 29)
        Me.lbDataVenda.TabIndex = 4
        Me.lbDataVenda.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbNomeCliente
        '
        Me.lbNomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNomeCliente.ForeColor = System.Drawing.Color.Red
        Me.lbNomeCliente.Location = New System.Drawing.Point(140, 3)
        Me.lbNomeCliente.Name = "lbNomeCliente"
        Me.lbNomeCliente.Size = New System.Drawing.Size(389, 29)
        Me.lbNomeCliente.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nome Cliente"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.tbLimiteCredito)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.tbObs)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.tbValorDesconto)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.lbTotal)
        Me.Panel4.Controls.Add(Me.lstProdutos)
        Me.Panel4.Controls.Add(Me.btnExclui)
        Me.Panel4.Controls.Add(Me.Panel)
        Me.Panel4.Location = New System.Drawing.Point(-1, 1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(797, 761)
        Me.Panel4.TabIndex = 190
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(38, 677)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 19)
        Me.Label6.TabIndex = 195
        Me.Label6.Text = "Limite crédito"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLimiteCredito
        '
        Me.tbLimiteCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLimiteCredito.Location = New System.Drawing.Point(132, 677)
        Me.tbLimiteCredito.Name = "tbLimiteCredito"
        Me.tbLimiteCredito.Size = New System.Drawing.Size(78, 20)
        Me.tbLimiteCredito.TabIndex = 194
        Me.tbLimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(150, 634)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 19)
        Me.Label4.TabIndex = 193
        Me.Label4.Text = "Observação"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbObs
        '
        Me.tbObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbObs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObs.ForeColor = System.Drawing.Color.Red
        Me.tbObs.Location = New System.Drawing.Point(219, 633)
        Me.tbObs.Multiline = True
        Me.tbObs.Name = "tbObs"
        Me.tbObs.Size = New System.Drawing.Size(321, 64)
        Me.tbObs.TabIndex = 192
        Me.tbObs.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(541, 636)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Desconto"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbValorDesconto
        '
        Me.tbValorDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValorDesconto.Location = New System.Drawing.Point(623, 634)
        Me.tbValorDesconto.Multiline = True
        Me.tbValorDesconto.Name = "tbValorDesconto"
        Me.tbValorDesconto.Size = New System.Drawing.Size(91, 20)
        Me.tbValorDesconto.TabIndex = 190
        Me.tbValorDesconto.Text = "0.00"
        Me.tbValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataSetGridDel
        '
        Me.DataSetGridDel.DataSetName = "NewDataSet"
        Me.DataSetGridDel.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn10})
        Me.DataTable1.TableName = "DescricaoPedido"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "IDProduto"
        Me.DataColumn1.DataType = GetType(Integer)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "CodigoProduto"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Produto"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "Venda"
        '
        'fdlgAbreVenda_Clube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(795, 761)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fdlgAbreVenda_Clube"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Venda"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.GridProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DataSetGridDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnImprime As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnDinheiro As Button
    Friend WithEvents btnCartaoDebito As Button
    Friend WithEvents btnCartaoCredito As Button
    Friend WithEvents lstProdutos As ListView
    Friend WithEvents IDProduto As ColumnHeader
    Friend WithEvents CodigoProduto As ColumnHeader
    Friend WithEvents Produto As ColumnHeader
    Friend WithEvents Quantidade As ColumnHeader
    Friend WithEvents ValorUnit As ColumnHeader
    Friend WithEvents TotalProd As ColumnHeader
    Friend WithEvents Panel As Panel
    Friend WithEvents btnInclui As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExclui As Button
    Friend WithEvents lbTotal As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GridProdutos As DataGridView
    Friend WithEvents tbCodPro As TextBox
    Friend WithEvents DataSetGridDel As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents DataColumn10 As DataColumn
    Friend WithEvents tbQtde As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Venda As DataGridViewTextBoxColumn
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents tbIDProduto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbValorDesconto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbObs As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lbNomeCliente As Label
    Friend WithEvents lbDataVenda As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbLimiteCredito As TextBox
    Friend WithEvents Data As ColumnHeader
    Friend WithEvents btnFicha As Button
    Friend WithEvents IDVendaMovto As ColumnHeader
End Class
