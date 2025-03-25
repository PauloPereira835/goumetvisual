<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgAgrupamento_Clube
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgAgrupamento_Clube))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDinheiro = New System.Windows.Forms.Button()
        Me.btnCartaoDebito = New System.Windows.Forms.Button()
        Me.btnCartaoCredito = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.lbIDAgrupamento = New System.Windows.Forms.Label()
        Me.lbAgrupamento = New System.Windows.Forms.Label()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.lvAgrupamentos = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnMais = New System.Windows.Forms.Button()
        Me.btnMenos = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvContas = New System.Windows.Forms.ListView()
        Me.IDVenda_Contas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nome_Contas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAgrupadas = New System.Windows.Forms.ListView()
        Me.IDAgrupamento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nome_Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbBuscaClientes = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.tbIDVenda)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 54)
        Me.Panel1.TabIndex = 36
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.White
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnImprimir.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(668, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(110, 41)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.TabStop = False
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(238, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(311, 41)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Agrupamento"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(148, 18)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(56, 20)
        Me.tbIDVenda.TabIndex = 3
        Me.tbIDVenda.TabStop = False
        Me.tbIDVenda.Visible = False
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
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
        Me.Panel2.Location = New System.Drawing.Point(0, 568)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 54)
        Me.Panel2.TabIndex = 56
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
        Me.btnDinheiro.Location = New System.Drawing.Point(604, 7)
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
        Me.btnCartaoDebito.Location = New System.Drawing.Point(303, 7)
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.btnExcluir)
        Me.Panel3.Controls.Add(Me.lbIDAgrupamento)
        Me.Panel3.Controls.Add(Me.lbAgrupamento)
        Me.Panel3.Controls.Add(Me.btnIncluir)
        Me.Panel3.Controls.Add(Me.lvAgrupamentos)
        Me.Panel3.Location = New System.Drawing.Point(69, 61)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(638, 161)
        Me.Panel3.TabIndex = 57
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.White
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(282, 120)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(85, 31)
        Me.btnExcluir.TabIndex = 190
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'lbIDAgrupamento
        '
        Me.lbIDAgrupamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIDAgrupamento.ForeColor = System.Drawing.Color.Green
        Me.lbIDAgrupamento.Location = New System.Drawing.Point(283, 47)
        Me.lbIDAgrupamento.Name = "lbIDAgrupamento"
        Me.lbIDAgrupamento.Size = New System.Drawing.Size(185, 23)
        Me.lbIDAgrupamento.TabIndex = 189
        Me.lbIDAgrupamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbIDAgrupamento.Visible = False
        '
        'lbAgrupamento
        '
        Me.lbAgrupamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAgrupamento.ForeColor = System.Drawing.Color.Green
        Me.lbAgrupamento.Location = New System.Drawing.Point(282, 7)
        Me.lbAgrupamento.Name = "lbAgrupamento"
        Me.lbAgrupamento.Size = New System.Drawing.Size(346, 23)
        Me.lbAgrupamento.TabIndex = 188
        Me.lbAgrupamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnIncluir
        '
        Me.btnIncluir.BackColor = System.Drawing.Color.White
        Me.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluir.FlatAppearance.BorderSize = 0
        Me.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnIncluir.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.Location = New System.Drawing.Point(520, 110)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(108, 41)
        Me.btnIncluir.TabIndex = 187
        Me.btnIncluir.TabStop = False
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'lvAgrupamentos
        '
        Me.lvAgrupamentos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lvAgrupamentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvAgrupamentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.Nome})
        Me.lvAgrupamentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAgrupamentos.ForeColor = System.Drawing.Color.Blue
        Me.lvAgrupamentos.FullRowSelect = True
        Me.lvAgrupamentos.GridLines = True
        Me.lvAgrupamentos.HideSelection = False
        Me.lvAgrupamentos.Location = New System.Drawing.Point(6, 5)
        Me.lvAgrupamentos.MultiSelect = False
        Me.lvAgrupamentos.Name = "lvAgrupamentos"
        Me.lvAgrupamentos.Size = New System.Drawing.Size(270, 146)
        Me.lvAgrupamentos.TabIndex = 186
        Me.lvAgrupamentos.TabStop = False
        Me.lvAgrupamentos.UseCompatibleStateImageBehavior = False
        Me.lvAgrupamentos.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Width = 0
        '
        'Nome
        '
        Me.Nome.Text = "Nome"
        Me.Nome.Width = 250
        '
        'btnMais
        '
        Me.btnMais.BackColor = System.Drawing.Color.White
        Me.btnMais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMais.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMais.FlatAppearance.BorderSize = 0
        Me.btnMais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMais.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMais.Image = CType(resources.GetObject("btnMais.Image"), System.Drawing.Image)
        Me.btnMais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMais.Location = New System.Drawing.Point(322, 305)
        Me.btnMais.Name = "btnMais"
        Me.btnMais.Size = New System.Drawing.Size(139, 41)
        Me.btnMais.TabIndex = 188
        Me.btnMais.TabStop = False
        Me.btnMais.Text = "Agrupar"
        Me.btnMais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMais.UseVisualStyleBackColor = False
        '
        'btnMenos
        '
        Me.btnMenos.BackColor = System.Drawing.Color.White
        Me.btnMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMenos.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnMenos.FlatAppearance.BorderSize = 0
        Me.btnMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMenos.Image = CType(resources.GetObject("btnMenos.Image"), System.Drawing.Image)
        Me.btnMenos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMenos.Location = New System.Drawing.Point(322, 376)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Size = New System.Drawing.Size(139, 41)
        Me.btnMenos.TabIndex = 189
        Me.btnMenos.TabStop = False
        Me.btnMenos.Text = "Desagrupar"
        Me.btnMenos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMenos.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(27, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Contas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(474, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Contas Agrupadas"
        '
        'lvContas
        '
        Me.lvContas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lvContas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvContas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDVenda_Contas, Me.Nome_Contas})
        Me.lvContas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvContas.ForeColor = System.Drawing.Color.Blue
        Me.lvContas.FullRowSelect = True
        Me.lvContas.GridLines = True
        Me.lvContas.HideSelection = False
        Me.lvContas.Location = New System.Drawing.Point(30, 282)
        Me.lvContas.MultiSelect = False
        Me.lvContas.Name = "lvContas"
        Me.lvContas.Size = New System.Drawing.Size(270, 279)
        Me.lvContas.TabIndex = 195
        Me.lvContas.TabStop = False
        Me.lvContas.UseCompatibleStateImageBehavior = False
        Me.lvContas.View = System.Windows.Forms.View.Details
        '
        'IDVenda_Contas
        '
        Me.IDVenda_Contas.Text = "IDVenda"
        Me.IDVenda_Contas.Width = 0
        '
        'Nome_Contas
        '
        Me.Nome_Contas.Text = "Nome"
        Me.Nome_Contas.Width = 250
        '
        'lvAgrupadas
        '
        Me.lvAgrupadas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lvAgrupadas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvAgrupadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDAgrupamento, Me.Nome_Cliente, Me.IDVenda})
        Me.lvAgrupadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAgrupadas.ForeColor = System.Drawing.Color.Blue
        Me.lvAgrupadas.FullRowSelect = True
        Me.lvAgrupadas.GridLines = True
        Me.lvAgrupadas.HideSelection = False
        Me.lvAgrupadas.Location = New System.Drawing.Point(477, 282)
        Me.lvAgrupadas.MultiSelect = False
        Me.lvAgrupadas.Name = "lvAgrupadas"
        Me.lvAgrupadas.Size = New System.Drawing.Size(270, 279)
        Me.lvAgrupadas.TabIndex = 196
        Me.lvAgrupadas.TabStop = False
        Me.lvAgrupadas.UseCompatibleStateImageBehavior = False
        Me.lvAgrupadas.View = System.Windows.Forms.View.Details
        '
        'IDAgrupamento
        '
        Me.IDAgrupamento.Text = "IDAgrupamento"
        Me.IDAgrupamento.Width = 0
        '
        'Nome_Cliente
        '
        Me.Nome_Cliente.Text = "Nome"
        Me.Nome_Cliente.Width = 250
        '
        'IDVenda
        '
        Me.IDVenda.Text = "IDVenda"
        Me.IDVenda.Width = 0
        '
        'tbBuscaClientes
        '
        Me.tbBuscaClientes.Location = New System.Drawing.Point(105, 242)
        Me.tbBuscaClientes.Multiline = True
        Me.tbBuscaClientes.Name = "tbBuscaClientes"
        Me.tbBuscaClientes.Size = New System.Drawing.Size(195, 20)
        Me.tbBuscaClientes.TabIndex = 197
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(27, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 198
        Me.Label3.Text = "Busca clientes"
        '
        'fdlgAgrupamento_Clube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(786, 623)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbBuscaClientes)
        Me.Controls.Add(Me.lvAgrupadas)
        Me.Controls.Add(Me.lvContas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMenos)
        Me.Controls.Add(Me.btnMais)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fdlgAgrupamento_Clube"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agrupamento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents btnVolta As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnDinheiro As Button
    Friend WithEvents btnCartaoDebito As Button
    Friend WithEvents btnCartaoCredito As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnIncluir As Button
    Friend WithEvents lvAgrupamentos As ListView
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents Nome As ColumnHeader
    Friend WithEvents btnMais As Button
    Friend WithEvents btnMenos As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lvContas As ListView
    Friend WithEvents IDVenda_Contas As ColumnHeader
    Friend WithEvents Nome_Contas As ColumnHeader
    Friend WithEvents lvAgrupadas As ListView
    Friend WithEvents IDAgrupamento As ColumnHeader
    Friend WithEvents Nome_Cliente As ColumnHeader
    Friend WithEvents lbAgrupamento As Label
    Friend WithEvents lbIDAgrupamento As Label
    Friend WithEvents IDVenda As ColumnHeader
    Friend WithEvents btnExcluir As Button
    Friend WithEvents tbBuscaClientes As TextBox
    Friend WithEvents Label3 As Label
End Class
