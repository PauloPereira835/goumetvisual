<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgVisualizaVendas
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbMovto = New System.Windows.Forms.Label()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.lstVendas = New System.Windows.Forms.ListView()
        Me.Descricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Percent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chtHora = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbDesconto = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbVendaTotal = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbVendasAberto = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbVendaLiquida = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lbTaxaEntrega = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbCaixainha = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbServico = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbTotalVenda = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbMedia = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbQtdePess = New System.Windows.Forms.Label()
        Me.lbVlrTot = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstServicoCaixinha = New System.Windows.Forms.ListView()
        Me.Funcionario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Servico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ServicoFator = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Caixinha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TXEntrega = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Vendas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Qtd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbVlrServico = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbVlrServicoAjustado = New System.Windows.Forms.Label()
        Me.lbVlrVendas = New System.Windows.Forms.Label()
        Me.lbVlrCaixinha = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lstProdutos = New System.Windows.Forms.ListView()
        Me.IDGrupo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grupo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Produto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Qtde = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ValorProd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbGrupos = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbVlrTxEntrega = New System.Windows.Forms.Label()
        Me.lbVlrTotal = New System.Windows.Forms.Label()
        Me.lbQtde = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lbVlrTotalProdutos = New System.Windows.Forms.Label()
        Me.lbQtdeTotalProdutos = New System.Windows.Forms.Label()
        Me.chtModulos = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbPorModulo = New System.Windows.Forms.RadioButton()
        Me.rbPorHora = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lbTotDelivery = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lbTotBalcao = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lbTotSalao = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.chtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.chtModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.lbMovto)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1105, 54)
        Me.Panel1.TabIndex = 34
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = Global.GourmetVisual.My.Resources.Resources.Clipboard_Paste
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(119, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 41)
        Me.Button2.TabIndex = 54
        Me.Button2.TabStop = False
        Me.Button2.Text = "Detalhada"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'lbMovto
        '
        Me.lbMovto.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMovto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbMovto.Location = New System.Drawing.Point(399, 10)
        Me.lbMovto.Name = "lbMovto"
        Me.lbMovto.Size = New System.Drawing.Size(664, 33)
        Me.lbMovto.TabIndex = 53
        Me.lbMovto.Text = "Total Vendas"
        Me.lbMovto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnVolta.Size = New System.Drawing.Size(100, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstVendas
        '
        Me.lstVendas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstVendas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstVendas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Descricao, Me.Valor, Me.Percent})
        Me.lstVendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstVendas.ForeColor = System.Drawing.Color.Blue
        Me.lstVendas.FullRowSelect = True
        Me.lstVendas.GridLines = True
        Me.lstVendas.HideSelection = False
        Me.lstVendas.Location = New System.Drawing.Point(12, 81)
        Me.lstVendas.MultiSelect = False
        Me.lstVendas.Name = "lstVendas"
        Me.lstVendas.Size = New System.Drawing.Size(273, 195)
        Me.lstVendas.TabIndex = 35
        Me.lstVendas.UseCompatibleStateImageBehavior = False
        Me.lstVendas.View = System.Windows.Forms.View.Details
        '
        'Descricao
        '
        Me.Descricao.Text = "Descrição"
        Me.Descricao.Width = 145
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Valor.Width = 70
        '
        'Percent
        '
        Me.Percent.Text = "%"
        Me.Percent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Percent.Width = 40
        '
        'chtHora
        '
        ChartArea1.Name = "ChartArea1"
        Me.chtHora.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Legend1.Position.Auto = False
        Legend1.Position.Height = 6.61157!
        Legend1.Position.Width = 17.70624!
        Legend1.Position.X = 79.29376!
        Legend1.Position.Y = 3.0!
        Me.chtHora.Legends.Add(Legend1)
        Me.chtHora.Location = New System.Drawing.Point(295, 81)
        Me.chtHora.Name = "chtHora"
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.IsVisibleInLegend = False
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series2.BorderWidth = 10
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series2.IsVisibleInLegend = False
        Series2.Legend = "Legend1"
        Series2.Name = "Series2"
        Series2.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary
        Series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary
        Me.chtHora.Series.Add(Series1)
        Me.chtHora.Series.Add(Series2)
        Me.chtHora.Size = New System.Drawing.Size(379, 330)
        Me.chtHora.TabIndex = 36
        Me.chtHora.Text = "Chart"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel2.Controls.Add(Me.lbDesconto)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.lbVendaTotal)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.lbVendasAberto)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.lbVendaLiquida)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.lbTaxaEntrega)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.lbCaixainha)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.lbServico)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.lbTotalVenda)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(11, 276)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(274, 161)
        Me.Panel2.TabIndex = 37
        '
        'lbDesconto
        '
        Me.lbDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesconto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDesconto.Location = New System.Drawing.Point(120, 38)
        Me.lbDesconto.Name = "lbDesconto"
        Me.lbDesconto.Size = New System.Drawing.Size(102, 15)
        Me.lbDesconto.TabIndex = 54
        Me.lbDesconto.Text = "10000,00"
        Me.lbDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Maroon
        Me.Label22.Location = New System.Drawing.Point(1, 39)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(119, 13)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "Desconto ( + )"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbVendaTotal
        '
        Me.lbVendaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVendaTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVendaTotal.Location = New System.Drawing.Point(120, 143)
        Me.lbVendaTotal.Name = "lbVendaTotal"
        Me.lbVendaTotal.Size = New System.Drawing.Size(102, 15)
        Me.lbVendaTotal.TabIndex = 52
        Me.lbVendaTotal.Text = "10000,00"
        Me.lbVendaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbVendaTotal.Visible = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Maroon
        Me.Label20.Location = New System.Drawing.Point(5, 144)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 13)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "Venda parcial"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label20.Visible = False
        '
        'lbVendasAberto
        '
        Me.lbVendasAberto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVendasAberto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVendasAberto.Location = New System.Drawing.Point(120, 119)
        Me.lbVendasAberto.Name = "lbVendasAberto"
        Me.lbVendasAberto.Size = New System.Drawing.Size(102, 15)
        Me.lbVendasAberto.TabIndex = 50
        Me.lbVendasAberto.Text = "10000,00"
        Me.lbVendasAberto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbVendasAberto.Visible = False
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(5, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 13)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "Vendas em aberto"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label18.Visible = False
        '
        'lbVendaLiquida
        '
        Me.lbVendaLiquida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVendaLiquida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVendaLiquida.Location = New System.Drawing.Point(120, 95)
        Me.lbVendaLiquida.Name = "lbVendaLiquida"
        Me.lbVendaLiquida.Size = New System.Drawing.Size(102, 15)
        Me.lbVendaLiquida.TabIndex = 48
        Me.lbVendaLiquida.Text = "10000,00"
        Me.lbVendaLiquida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(5, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Venda Liquida"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTaxaEntrega
        '
        Me.lbTaxaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTaxaEntrega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTaxaEntrega.Location = New System.Drawing.Point(120, 76)
        Me.lbTaxaEntrega.Name = "lbTaxaEntrega"
        Me.lbTaxaEntrega.Size = New System.Drawing.Size(102, 15)
        Me.lbTaxaEntrega.TabIndex = 46
        Me.lbTaxaEntrega.Text = "10000,00"
        Me.lbTaxaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(1, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Tx entrega ( - )"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbCaixainha
        '
        Me.lbCaixainha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaixainha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCaixainha.Location = New System.Drawing.Point(120, 57)
        Me.lbCaixainha.Name = "lbCaixainha"
        Me.lbCaixainha.Size = New System.Drawing.Size(102, 15)
        Me.lbCaixainha.TabIndex = 44
        Me.lbCaixainha.Text = "10000,00"
        Me.lbCaixainha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(1, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Caixinha ( - )"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbServico
        '
        Me.lbServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbServico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbServico.Location = New System.Drawing.Point(120, 21)
        Me.lbServico.Name = "lbServico"
        Me.lbServico.Size = New System.Drawing.Size(102, 15)
        Me.lbServico.TabIndex = 42
        Me.lbServico.Text = "10000,00"
        Me.lbServico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(1, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Serviço ( - )"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalVenda
        '
        Me.lbTotalVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalVenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalVenda.Location = New System.Drawing.Point(120, 2)
        Me.lbTotalVenda.Name = "lbTotalVenda"
        Me.lbTotalVenda.Size = New System.Drawing.Size(102, 15)
        Me.lbTotalVenda.TabIndex = 40
        Me.lbTotalVenda.Text = "10000,00"
        Me.lbTotalVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(5, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Total Vendas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.lbMedia)
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Controls.Add(Me.lbQtdePess)
        Me.Panel7.Controls.Add(Me.lbVlrTot)
        Me.Panel7.Location = New System.Drawing.Point(295, 413)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(379, 22)
        Me.Panel7.TabIndex = 183
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(151, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 187
        Me.Label7.Text = "Qtde. Vendas"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Goldenrod
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(133, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 9)
        Me.Label10.TabIndex = 186
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(21, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "Vendas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 9)
        Me.Label4.TabIndex = 184
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMedia
        '
        Me.lbMedia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMedia.Location = New System.Drawing.Point(335, 3)
        Me.lbMedia.Name = "lbMedia"
        Me.lbMedia.Size = New System.Drawing.Size(40, 13)
        Me.lbMedia.TabIndex = 183
        Me.lbMedia.Text = "999,00"
        Me.lbMedia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(260, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 182
        Me.Label15.Text = "Média (TM/V)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQtdePess
        '
        Me.lbQtdePess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbQtdePess.Location = New System.Drawing.Point(213, 2)
        Me.lbQtdePess.Name = "lbQtdePess"
        Me.lbQtdePess.Size = New System.Drawing.Size(36, 13)
        Me.lbQtdePess.TabIndex = 181
        Me.lbQtdePess.Text = "999"
        Me.lbQtdePess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbVlrTot
        '
        Me.lbVlrTot.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVlrTot.Location = New System.Drawing.Point(57, 3)
        Me.lbVlrTot.Name = "lbVlrTot"
        Me.lbVlrTot.Size = New System.Drawing.Size(55, 13)
        Me.lbVlrTot.TabIndex = 179
        Me.lbVlrTot.Text = "99999,99"
        Me.lbVlrTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Vendas recebidas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(295, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Vendas"
        '
        'lstServicoCaixinha
        '
        Me.lstServicoCaixinha.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstServicoCaixinha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstServicoCaixinha.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Funcionario, Me.Servico, Me.ServicoFator, Me.Caixinha, Me.TXEntrega, Me.Total, Me.Vendas, Me.Qtd})
        Me.lstServicoCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstServicoCaixinha.ForeColor = System.Drawing.Color.Blue
        Me.lstServicoCaixinha.FullRowSelect = True
        Me.lstServicoCaixinha.GridLines = True
        Me.lstServicoCaixinha.HideSelection = False
        Me.lstServicoCaixinha.Location = New System.Drawing.Point(12, 466)
        Me.lstServicoCaixinha.MultiSelect = False
        Me.lstServicoCaixinha.Name = "lstServicoCaixinha"
        Me.lstServicoCaixinha.Size = New System.Drawing.Size(580, 160)
        Me.lstServicoCaixinha.TabIndex = 184
        Me.lstServicoCaixinha.UseCompatibleStateImageBehavior = False
        Me.lstServicoCaixinha.View = System.Windows.Forms.View.Details
        '
        'Funcionario
        '
        Me.Funcionario.Text = "Funcionário"
        Me.Funcionario.Width = 110
        '
        'Servico
        '
        Me.Servico.Text = "Serviço"
        Me.Servico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Servico.Width = 68
        '
        'ServicoFator
        '
        Me.ServicoFator.Text = "Ajustado"
        Me.ServicoFator.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ServicoFator.Width = 68
        '
        'Caixinha
        '
        Me.Caixinha.Text = "Caixinha"
        Me.Caixinha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Caixinha.Width = 68
        '
        'TXEntrega
        '
        Me.TXEntrega.Text = "Tx. Entrega"
        Me.TXEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXEntrega.Width = 68
        '
        'Total
        '
        Me.Total.Text = "Total"
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Total.Width = 70
        '
        'Vendas
        '
        Me.Vendas.Text = "Vendas"
        Me.Vendas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Vendas.Width = 70
        '
        'Qtd
        '
        Me.Qtd.Text = "Qtde"
        Me.Qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Qtd.Width = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 450)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 16)
        Me.Label8.TabIndex = 185
        Me.Label8.Text = "Serviço/Caixinha"
        '
        'lbVlrServico
        '
        Me.lbVlrServico.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrServico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVlrServico.Location = New System.Drawing.Point(118, 624)
        Me.lbVlrServico.Name = "lbVlrServico"
        Me.lbVlrServico.Size = New System.Drawing.Size(71, 18)
        Me.lbVlrServico.TabIndex = 187
        Me.lbVlrServico.Text = "10000,00"
        Me.lbVlrServico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(12, 625)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(580, 19)
        Me.Label13.TabIndex = 186
        Me.Label13.Text = "TOTAIS"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbVlrServicoAjustado
        '
        Me.lbVlrServicoAjustado.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrServicoAjustado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrServicoAjustado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbVlrServicoAjustado.Location = New System.Drawing.Point(189, 624)
        Me.lbVlrServicoAjustado.Name = "lbVlrServicoAjustado"
        Me.lbVlrServicoAjustado.Size = New System.Drawing.Size(68, 18)
        Me.lbVlrServicoAjustado.TabIndex = 188
        Me.lbVlrServicoAjustado.Text = "10000,00"
        Me.lbVlrServicoAjustado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbVlrVendas
        '
        Me.lbVlrVendas.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrVendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrVendas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVlrVendas.Location = New System.Drawing.Point(466, 625)
        Me.lbVlrVendas.Name = "lbVlrVendas"
        Me.lbVlrVendas.Size = New System.Drawing.Size(67, 18)
        Me.lbVlrVendas.TabIndex = 190
        Me.lbVlrVendas.Text = "10000,00"
        Me.lbVlrVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbVlrCaixinha
        '
        Me.lbVlrCaixinha.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrCaixinha.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbVlrCaixinha.Location = New System.Drawing.Point(255, 625)
        Me.lbVlrCaixinha.Name = "lbVlrCaixinha"
        Me.lbVlrCaixinha.Size = New System.Drawing.Size(71, 18)
        Me.lbVlrCaixinha.TabIndex = 189
        Me.lbVlrCaixinha.Text = "10000,00"
        Me.lbVlrCaixinha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(687, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 193
        Me.Label11.Text = "Produtos"
        '
        'lstProdutos
        '
        Me.lstProdutos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstProdutos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDGrupo, Me.Grupo, Me.Produto, Me.Qtde, Me.ValorProd})
        Me.lstProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProdutos.ForeColor = System.Drawing.Color.Blue
        Me.lstProdutos.FullRowSelect = True
        Me.lstProdutos.GridLines = True
        Me.lstProdutos.HideSelection = False
        Me.lstProdutos.Location = New System.Drawing.Point(687, 88)
        Me.lstProdutos.MultiSelect = False
        Me.lstProdutos.Name = "lstProdutos"
        Me.lstProdutos.Size = New System.Drawing.Size(389, 534)
        Me.lstProdutos.TabIndex = 192
        Me.lstProdutos.UseCompatibleStateImageBehavior = False
        Me.lstProdutos.View = System.Windows.Forms.View.Details
        '
        'IDGrupo
        '
        Me.IDGrupo.Text = "IDGrupo"
        Me.IDGrupo.Width = 0
        '
        'Grupo
        '
        Me.Grupo.Text = "Grupo"
        Me.Grupo.Width = 108
        '
        'Produto
        '
        Me.Produto.Text = "Produto"
        Me.Produto.Width = 128
        '
        'Qtde
        '
        Me.Qtde.Text = "Qtde"
        Me.Qtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ValorProd
        '
        Me.ValorProd.Text = "Valor"
        Me.ValorProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValorProd.Width = 75
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(687, 622)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(389, 23)
        Me.Label14.TabIndex = 194
        Me.Label14.Text = "TOTAIS"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Button1.Image = Global.GourmetVisual.My.Resources.Resources.Printer2
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(598, 466)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 41)
        Me.Button1.TabIndex = 2
        Me.Button1.TabStop = False
        Me.Button1.Text = "Serviço/Caixinha"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cbGrupos
        '
        Me.cbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGrupos.FormattingEnabled = True
        Me.cbGrupos.Location = New System.Drawing.Point(842, 58)
        Me.cbGrupos.Name = "cbGrupos"
        Me.cbGrupos.Size = New System.Drawing.Size(234, 21)
        Me.cbGrupos.TabIndex = 196
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(794, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 28)
        Me.Label17.TabIndex = 195
        Me.Label17.Text = "Grupo"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbVlrTxEntrega
        '
        Me.lbVlrTxEntrega.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrTxEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrTxEntrega.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbVlrTxEntrega.Location = New System.Drawing.Point(326, 626)
        Me.lbVlrTxEntrega.Name = "lbVlrTxEntrega"
        Me.lbVlrTxEntrega.Size = New System.Drawing.Size(67, 18)
        Me.lbVlrTxEntrega.TabIndex = 197
        Me.lbVlrTxEntrega.Text = "10000,00"
        Me.lbVlrTxEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbVlrTotal
        '
        Me.lbVlrTotal.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrTotal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbVlrTotal.Location = New System.Drawing.Point(396, 626)
        Me.lbVlrTotal.Name = "lbVlrTotal"
        Me.lbVlrTotal.Size = New System.Drawing.Size(67, 18)
        Me.lbVlrTotal.TabIndex = 198
        Me.lbVlrTotal.Text = "10000,00"
        Me.lbVlrTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQtde
        '
        Me.lbQtde.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbQtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbQtde.Location = New System.Drawing.Point(537, 625)
        Me.lbQtde.Name = "lbQtde"
        Me.lbQtde.Size = New System.Drawing.Size(36, 18)
        Me.lbQtde.TabIndex = 199
        Me.lbQtde.Text = "100"
        Me.lbQtde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label19.Location = New System.Drawing.Point(353, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 12)
        Me.Label19.TabIndex = 200
        Me.Label19.Text = "(todos os movtos.)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label21.Location = New System.Drawing.Point(687, 70)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 12)
        Me.Label21.TabIndex = 201
        Me.Label21.Text = "(todos os movtos.)"
        '
        'lbVlrTotalProdutos
        '
        Me.lbVlrTotalProdutos.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbVlrTotalProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVlrTotalProdutos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbVlrTotalProdutos.Location = New System.Drawing.Point(982, 626)
        Me.lbVlrTotalProdutos.Name = "lbVlrTotalProdutos"
        Me.lbVlrTotalProdutos.Size = New System.Drawing.Size(79, 18)
        Me.lbVlrTotalProdutos.TabIndex = 202
        Me.lbVlrTotalProdutos.Text = "10000,00"
        Me.lbVlrTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQtdeTotalProdutos
        '
        Me.lbQtdeTotalProdutos.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lbQtdeTotalProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeTotalProdutos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbQtdeTotalProdutos.Location = New System.Drawing.Point(906, 626)
        Me.lbQtdeTotalProdutos.Name = "lbQtdeTotalProdutos"
        Me.lbQtdeTotalProdutos.Size = New System.Drawing.Size(78, 18)
        Me.lbQtdeTotalProdutos.TabIndex = 203
        Me.lbQtdeTotalProdutos.Text = "10000,00"
        Me.lbQtdeTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chtModulos
        '
        ChartArea2.Name = "ChartArea1"
        Me.chtModulos.ChartAreas.Add(ChartArea2)
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.Name = "Legend1"
        Legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall
        Me.chtModulos.Legends.Add(Legend2)
        Me.chtModulos.Location = New System.Drawing.Point(295, 81)
        Me.chtModulos.Name = "chtModulos"
        Series3.BorderWidth = 2
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chtModulos.Series.Add(Series3)
        Me.chtModulos.Size = New System.Drawing.Size(379, 330)
        Me.chtModulos.TabIndex = 204
        Me.chtModulos.Text = "Chart"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbPorModulo)
        Me.Panel3.Controls.Add(Me.rbPorHora)
        Me.Panel3.Location = New System.Drawing.Point(440, 58)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(232, 20)
        Me.Panel3.TabIndex = 205
        '
        'rbPorModulo
        '
        Me.rbPorModulo.AutoSize = True
        Me.rbPorModulo.Location = New System.Drawing.Point(153, 2)
        Me.rbPorModulo.Name = "rbPorModulo"
        Me.rbPorModulo.Size = New System.Drawing.Size(82, 17)
        Me.rbPorModulo.TabIndex = 1
        Me.rbPorModulo.TabStop = True
        Me.rbPorModulo.Text = "por módulos"
        Me.rbPorModulo.UseVisualStyleBackColor = True
        '
        'rbPorHora
        '
        Me.rbPorHora.AutoSize = True
        Me.rbPorHora.Location = New System.Drawing.Point(83, 1)
        Me.rbPorHora.Name = "rbPorHora"
        Me.rbPorHora.Size = New System.Drawing.Size(64, 17)
        Me.rbPorHora.TabIndex = 0
        Me.rbPorHora.TabStop = True
        Me.rbPorHora.Text = "por hora"
        Me.rbPorHora.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Label29)
        Me.Panel4.Controls.Add(Me.lbTotal)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.lbTotDelivery)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Controls.Add(Me.lbTotBalcao)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Controls.Add(Me.lbTotSalao)
        Me.Panel4.Location = New System.Drawing.Point(294, 413)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(379, 22)
        Me.Panel4.TabIndex = 188
        Me.Panel4.Visible = False
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(294, 3)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(40, 13)
        Me.Label29.TabIndex = 193
        Me.Label29.Text = "TOTAL"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTotal
        '
        Me.lbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotal.Location = New System.Drawing.Point(339, 3)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(36, 13)
        Me.lbTotal.TabIndex = 192
        Me.lbTotal.Text = "9999"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(195, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 13)
        Me.Label27.TabIndex = 191
        Me.Label27.Text = "Delivery"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTotDelivery
        '
        Me.lbTotDelivery.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotDelivery.Location = New System.Drawing.Point(240, 3)
        Me.lbTotDelivery.Name = "lbTotDelivery"
        Me.lbTotDelivery.Size = New System.Drawing.Size(32, 13)
        Me.lbTotDelivery.TabIndex = 190
        Me.lbTotDelivery.Text = "9999"
        Me.lbTotDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(97, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 189
        Me.Label25.Text = "Balcão"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTotBalcao
        '
        Me.lbTotBalcao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotBalcao.Location = New System.Drawing.Point(136, 3)
        Me.lbTotBalcao.Name = "lbTotBalcao"
        Me.lbTotBalcao.Size = New System.Drawing.Size(32, 13)
        Me.lbTotBalcao.TabIndex = 188
        Me.lbTotBalcao.Text = "9999"
        Me.lbTotBalcao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(2, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 13)
        Me.Label23.TabIndex = 187
        Me.Label23.Text = "Salão"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTotSalao
        '
        Me.lbTotSalao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotSalao.Location = New System.Drawing.Point(40, 3)
        Me.lbTotSalao.Name = "lbTotSalao"
        Me.lbTotSalao.Size = New System.Drawing.Size(32, 13)
        Me.lbTotSalao.TabIndex = 186
        Me.lbTotSalao.Text = "9999"
        Me.lbTotSalao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fdlgVisualizaVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 647)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.chtModulos)
        Me.Controls.Add(Me.lbQtdeTotalProdutos)
        Me.Controls.Add(Me.lbVlrTotalProdutos)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lbQtde)
        Me.Controls.Add(Me.lbVlrTotal)
        Me.Controls.Add(Me.lbVlrTxEntrega)
        Me.Controls.Add(Me.cbGrupos)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lstProdutos)
        Me.Controls.Add(Me.lbVlrVendas)
        Me.Controls.Add(Me.lbVlrCaixinha)
        Me.Controls.Add(Me.lbVlrServicoAjustado)
        Me.Controls.Add(Me.lbVlrServico)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lstServicoCaixinha)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.chtHora)
        Me.Controls.Add(Me.lstVendas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgVisualizaVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualiza Vendas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.chtHora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.chtModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents lstVendas As ListView
    Friend WithEvents chtHora As DataVisualization.Charting.Chart
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lbMedia As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lbQtdePess As Label
    Friend WithEvents lbVlrTot As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Descricao As ColumnHeader
    Friend WithEvents Valor As ColumnHeader
    Friend WithEvents Percent As ColumnHeader
    Friend WithEvents lbVendaTotal As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lbVendasAberto As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbVendaLiquida As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lbTaxaEntrega As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lbCaixainha As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbServico As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbTotalVenda As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lstServicoCaixinha As ListView
    Friend WithEvents Funcionario As ColumnHeader
    Friend WithEvents Servico As ColumnHeader
    Friend WithEvents ServicoFator As ColumnHeader
    Friend WithEvents Caixinha As ColumnHeader
    Friend WithEvents TXEntrega As ColumnHeader
    Friend WithEvents Label8 As Label
    Friend WithEvents lbVlrServico As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lbVlrServicoAjustado As Label
    Friend WithEvents lbVlrVendas As Label
    Friend WithEvents lbVlrCaixinha As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lstProdutos As ListView
    Friend WithEvents IDGrupo As ColumnHeader
    Friend WithEvents Grupo As ColumnHeader
    Friend WithEvents Produto As ColumnHeader
    Friend WithEvents Qtde As ColumnHeader
    Friend WithEvents ValorProd As ColumnHeader
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Total As ColumnHeader
    Friend WithEvents Vendas As ColumnHeader
    Friend WithEvents Qtd As ColumnHeader
    Friend WithEvents cbGrupos As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents lbVlrTxEntrega As Label
    Friend WithEvents lbVlrTotal As Label
    Friend WithEvents lbQtde As Label
    Friend WithEvents lbMovto As Label
    Friend WithEvents lbDesconto As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lbVlrTotalProdutos As Label
    Friend WithEvents lbQtdeTotalProdutos As Label
    Friend WithEvents chtModulos As DataVisualization.Charting.Chart
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbPorModulo As RadioButton
    Friend WithEvents rbPorHora As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label29 As Label
    Friend WithEvents lbTotal As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents lbTotDelivery As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lbTotBalcao As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lbTotSalao As Label
    Friend WithEvents Button2 As Button
End Class
