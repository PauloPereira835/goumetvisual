<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgConta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgConta))
        Me.PanelTeclado = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbQtdePessoas = New System.Windows.Forms.TextBox()
        Me.PanelDesc = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDescValor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDescPerc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbTotalProdutos = New System.Windows.Forms.TextBox()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.PanelConta = New System.Windows.Forms.Panel()
        Me.tbConta = New System.Windows.Forms.TextBox()
        Me.tbPercServico = New System.Windows.Forms.TextBox()
        Me.tbServico = New System.Windows.Forms.TextBox()
        Me.lbTextoMesa = New System.Windows.Forms.Label()
        Me.tbMesa = New System.Windows.Forms.TextBox()
        Me.lbTotalVenda = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGrid = New System.Windows.Forms.DataGridView()
        Me.btnConfirmaImpressao = New System.Windows.Forms.Button()
        Me.btnConsumo = New System.Windows.Forms.Button()
        Me.btnPix = New System.Windows.Forms.Button()
        Me.btnVerifica = New System.Windows.Forms.Button()
        Me.btnServico = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
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
        Me.IDVendaMovto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImprimeImpressora = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Qtd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelTeclado.SuspendLayout()
        Me.PanelDesc.SuspendLayout()
        Me.PanelConta.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTeclado
        '
        Me.PanelTeclado.BackColor = System.Drawing.SystemColors.Control
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
        Me.PanelTeclado.Location = New System.Drawing.Point(3, 9)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(216, 358)
        Me.PanelTeclado.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(232, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 18)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Quantidade Pessoas"
        '
        'tbQtdePessoas
        '
        Me.tbQtdePessoas.BackColor = System.Drawing.SystemColors.Control
        Me.tbQtdePessoas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbQtdePessoas.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbQtdePessoas.Location = New System.Drawing.Point(249, 124)
        Me.tbQtdePessoas.Name = "tbQtdePessoas"
        Me.tbQtdePessoas.Size = New System.Drawing.Size(104, 33)
        Me.tbQtdePessoas.TabIndex = 1
        Me.tbQtdePessoas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PanelDesc
        '
        Me.PanelDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelDesc.Controls.Add(Me.Label4)
        Me.PanelDesc.Controls.Add(Me.tbDescValor)
        Me.PanelDesc.Controls.Add(Me.Label3)
        Me.PanelDesc.Controls.Add(Me.tbDescPerc)
        Me.PanelDesc.Controls.Add(Me.Label2)
        Me.PanelDesc.Location = New System.Drawing.Point(223, 273)
        Me.PanelDesc.Name = "PanelDesc"
        Me.PanelDesc.Size = New System.Drawing.Size(155, 96)
        Me.PanelDesc.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(2, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 18)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Valor (R$)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbDescValor
        '
        Me.tbDescValor.BackColor = System.Drawing.SystemColors.Control
        Me.tbDescValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDescValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescValor.Location = New System.Drawing.Point(79, 65)
        Me.tbDescValor.Name = "tbDescValor"
        Me.tbDescValor.Size = New System.Drawing.Size(68, 22)
        Me.tbDescValor.TabIndex = 3
        Me.tbDescValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(2, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 18)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Percentual (%)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbDescPerc
        '
        Me.tbDescPerc.BackColor = System.Drawing.SystemColors.Control
        Me.tbDescPerc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDescPerc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescPerc.Location = New System.Drawing.Point(79, 30)
        Me.tbDescPerc.Name = "tbDescPerc"
        Me.tbDescPerc.Size = New System.Drawing.Size(68, 22)
        Me.tbDescPerc.TabIndex = 2
        Me.tbDescPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 18)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Desconto"
        '
        'tbTotalProdutos
        '
        Me.tbTotalProdutos.BackColor = System.Drawing.SystemColors.Control
        Me.tbTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTotalProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalProdutos.Location = New System.Drawing.Point(225, 197)
        Me.tbTotalProdutos.Name = "tbTotalProdutos"
        Me.tbTotalProdutos.Size = New System.Drawing.Size(37, 13)
        Me.tbTotalProdutos.TabIndex = 21
        Me.tbTotalProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbTotalProdutos.Visible = False
        '
        'tbIDVenda
        '
        Me.tbIDVenda.BackColor = System.Drawing.SystemColors.Control
        Me.tbIDVenda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbIDVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDVenda.Location = New System.Drawing.Point(312, 197)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(62, 13)
        Me.tbIDVenda.TabIndex = 22
        Me.tbIDVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDVenda.Visible = False
        '
        'PanelConta
        '
        Me.PanelConta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelConta.Controls.Add(Me.tbConta)
        Me.PanelConta.Location = New System.Drawing.Point(683, 4)
        Me.PanelConta.Name = "PanelConta"
        Me.PanelConta.Size = New System.Drawing.Size(324, 572)
        Me.PanelConta.TabIndex = 23
        '
        'tbConta
        '
        Me.tbConta.BackColor = System.Drawing.SystemColors.Control
        Me.tbConta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbConta.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbConta.Location = New System.Drawing.Point(3, 3)
        Me.tbConta.Multiline = True
        Me.tbConta.Name = "tbConta"
        Me.tbConta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbConta.Size = New System.Drawing.Size(315, 562)
        Me.tbConta.TabIndex = 1
        Me.tbConta.TabStop = False
        '
        'tbPercServico
        '
        Me.tbPercServico.BackColor = System.Drawing.SystemColors.Control
        Me.tbPercServico.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbPercServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPercServico.Location = New System.Drawing.Point(312, 178)
        Me.tbPercServico.Name = "tbPercServico"
        Me.tbPercServico.Size = New System.Drawing.Size(62, 13)
        Me.tbPercServico.TabIndex = 25
        Me.tbPercServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbPercServico.Visible = False
        '
        'tbServico
        '
        Me.tbServico.BackColor = System.Drawing.SystemColors.Control
        Me.tbServico.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbServico.Location = New System.Drawing.Point(225, 178)
        Me.tbServico.Name = "tbServico"
        Me.tbServico.Size = New System.Drawing.Size(79, 13)
        Me.tbServico.TabIndex = 26
        Me.tbServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbServico.Visible = False
        '
        'lbTextoMesa
        '
        Me.lbTextoMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTextoMesa.Location = New System.Drawing.Point(231, 9)
        Me.lbTextoMesa.Name = "lbTextoMesa"
        Me.lbTextoMesa.Size = New System.Drawing.Size(138, 18)
        Me.lbTextoMesa.TabIndex = 28
        Me.lbTextoMesa.Text = "MESA"
        Me.lbTextoMesa.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbMesa
        '
        Me.tbMesa.BackColor = System.Drawing.SystemColors.Control
        Me.tbMesa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMesa.Location = New System.Drawing.Point(249, 30)
        Me.tbMesa.Name = "tbMesa"
        Me.tbMesa.Size = New System.Drawing.Size(104, 33)
        Me.tbMesa.TabIndex = 0
        Me.tbMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbTotalVenda
        '
        Me.lbTotalVenda.BackColor = System.Drawing.SystemColors.Control
        Me.lbTotalVenda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbTotalVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalVenda.Location = New System.Drawing.Point(267, 197)
        Me.lbTotalVenda.Name = "lbTotalVenda"
        Me.lbTotalVenda.Size = New System.Drawing.Size(37, 13)
        Me.lbTotalVenda.TabIndex = 31
        Me.lbTotalVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lbTotalVenda.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnConfirmaImpressao)
        Me.Panel1.Controls.Add(Me.DataGrid)
        Me.Panel1.Location = New System.Drawing.Point(382, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 511)
        Me.Panel1.TabIndex = 34
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToDeleteRows = False
        Me.DataGrid.AllowUserToResizeColumns = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDVendaMovto, Me.ImprimeImpressora, Me.Qtd, Me.Produto})
        Me.DataGrid.EnableHeadersVisualStyles = False
        Me.DataGrid.Location = New System.Drawing.Point(3, 42)
        Me.DataGrid.MultiSelect = False
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.RowHeadersVisible = False
        Me.DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGrid.Size = New System.Drawing.Size(286, 462)
        Me.DataGrid.TabIndex = 0
        '
        'btnConfirmaImpressao
        '
        Me.btnConfirmaImpressao.BackColor = System.Drawing.Color.White
        Me.btnConfirmaImpressao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirmaImpressao.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnConfirmaImpressao.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmaImpressao.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirmaImpressao.Image = Global.GourmetVisual.My.Resources.Resources.Ok2
        Me.btnConfirmaImpressao.Location = New System.Drawing.Point(191, 3)
        Me.btnConfirmaImpressao.Name = "btnConfirmaImpressao"
        Me.btnConfirmaImpressao.Size = New System.Drawing.Size(96, 35)
        Me.btnConfirmaImpressao.TabIndex = 35
        Me.btnConfirmaImpressao.TabStop = False
        Me.btnConfirmaImpressao.Text = "Confirma"
        Me.btnConfirmaImpressao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirmaImpressao.UseVisualStyleBackColor = False
        Me.btnConfirmaImpressao.Visible = False
        '
        'btnConsumo
        '
        Me.btnConsumo.BackColor = System.Drawing.Color.White
        Me.btnConsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConsumo.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnConsumo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsumo.ForeColor = System.Drawing.Color.Blue
        Me.btnConsumo.Image = Global.GourmetVisual.My.Resources.Resources.Clipboard_Paste
        Me.btnConsumo.Location = New System.Drawing.Point(251, 523)
        Me.btnConsumo.Name = "btnConsumo"
        Me.btnConsumo.Size = New System.Drawing.Size(123, 52)
        Me.btnConsumo.TabIndex = 33
        Me.btnConsumo.TabStop = False
        Me.btnConsumo.Text = "Consumo"
        Me.btnConsumo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsumo.UseVisualStyleBackColor = False
        '
        'btnPix
        '
        Me.btnPix.BackColor = System.Drawing.Color.White
        Me.btnPix.BackgroundImage = Global.GourmetVisual.My.Resources.Resources.Pix_botao
        Me.btnPix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPix.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnPix.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPix.ForeColor = System.Drawing.Color.Blue
        Me.btnPix.Location = New System.Drawing.Point(6, 469)
        Me.btnPix.Name = "btnPix"
        Me.btnPix.Size = New System.Drawing.Size(104, 43)
        Me.btnPix.TabIndex = 30
        Me.btnPix.TabStop = False
        Me.btnPix.UseVisualStyleBackColor = False
        Me.btnPix.Visible = False
        '
        'btnVerifica
        '
        Me.btnVerifica.BackColor = System.Drawing.Color.White
        Me.btnVerifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerifica.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnVerifica.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerifica.ForeColor = System.Drawing.Color.Blue
        Me.btnVerifica.Image = Global.GourmetVisual.My.Resources.Resources.Clipboard_Paste
        Me.btnVerifica.Location = New System.Drawing.Point(128, 523)
        Me.btnVerifica.Name = "btnVerifica"
        Me.btnVerifica.Size = New System.Drawing.Size(123, 52)
        Me.btnVerifica.TabIndex = 29
        Me.btnVerifica.TabStop = False
        Me.btnVerifica.Text = "Verifica Produtos"
        Me.btnVerifica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerifica.UseVisualStyleBackColor = False
        '
        'btnServico
        '
        Me.btnServico.BackColor = System.Drawing.Color.White
        Me.btnServico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnServico.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnServico.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnServico.ForeColor = System.Drawing.Color.Blue
        Me.btnServico.Image = Global.GourmetVisual.My.Resources.Resources.Clipboard_Paste
        Me.btnServico.Location = New System.Drawing.Point(374, 523)
        Me.btnServico.Name = "btnServico"
        Me.btnServico.Size = New System.Drawing.Size(139, 52)
        Me.btnServico.TabIndex = 24
        Me.btnServico.TabStop = False
        Me.btnServico.Text = "Retira Serviço F10"
        Me.btnServico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnServico.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnVoltar.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.Location = New System.Drawing.Point(6, 523)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(122, 52)
        Me.btnVoltar.TabIndex = 14
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnConfirma.Location = New System.Drawing.Point(513, 523)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(163, 52)
        Me.btnConfirma.TabIndex = 4
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Imprime F7"
        Me.btnConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button14.Location = New System.Drawing.Point(3, 282)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(208, 70)
        Me.Button14.TabIndex = 12
        Me.Button14.TabStop = False
        Me.Button14.Text = "Enter"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = CType(resources.GetObject("Button11.BackgroundImage"), System.Drawing.Image)
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button11.Location = New System.Drawing.Point(72, 211)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(139, 70)
        Me.Button11.TabIndex = 10
        Me.Button11.TabStop = False
        Me.Button11.Text = "Limpa"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
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
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.BackgroundImage = Global.GourmetVisual.My.Resources.Resources.Botao_Ret_Laranja2
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 70)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "7"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'IDVendaMovto
        '
        Me.IDVendaMovto.HeaderText = "IDVendaMovto"
        Me.IDVendaMovto.Name = "IDVendaMovto"
        Me.IDVendaMovto.ReadOnly = True
        Me.IDVendaMovto.Visible = False
        '
        'ImprimeImpressora
        '
        Me.ImprimeImpressora.HeaderText = "Imprime"
        Me.ImprimeImpressora.Name = "ImprimeImpressora"
        Me.ImprimeImpressora.ReadOnly = True
        '
        'Qtd
        '
        Me.Qtd.HeaderText = "Qtde"
        Me.Qtd.Name = "Qtd"
        Me.Qtd.ReadOnly = True
        '
        'Produto
        '
        Me.Produto.HeaderText = "Produto"
        Me.Produto.Name = "Produto"
        Me.Produto.ReadOnly = True
        '
        'fdlgConta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1012, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnConsumo)
        Me.Controls.Add(Me.lbTotalVenda)
        Me.Controls.Add(Me.btnPix)
        Me.Controls.Add(Me.btnVerifica)
        Me.Controls.Add(Me.lbTextoMesa)
        Me.Controls.Add(Me.tbMesa)
        Me.Controls.Add(Me.tbServico)
        Me.Controls.Add(Me.tbPercServico)
        Me.Controls.Add(Me.btnServico)
        Me.Controls.Add(Me.PanelConta)
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.tbTotalProdutos)
        Me.Controls.Add(Me.PanelDesc)
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbQtdePessoas)
        Me.Controls.Add(Me.btnConfirma)
        Me.Controls.Add(Me.PanelTeclado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgConta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conferencia de Mesa"
        Me.PanelTeclado.ResumeLayout(False)
        Me.PanelDesc.ResumeLayout(False)
        Me.PanelDesc.PerformLayout()
        Me.PanelConta.ResumeLayout(False)
        Me.PanelConta.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelTeclado As System.Windows.Forms.Panel
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnConfirma As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbQtdePessoas As System.Windows.Forms.TextBox
    Friend WithEvents btnVoltar As System.Windows.Forms.Button
    Friend WithEvents PanelDesc As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents tbDescValor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbDescPerc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button14 As Button
    Friend WithEvents tbTotalProdutos As TextBox
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents PanelConta As Panel
    Friend WithEvents tbConta As TextBox
    Friend WithEvents btnServico As Button
    Friend WithEvents tbPercServico As TextBox
    Friend WithEvents tbServico As TextBox
    Friend WithEvents lbTextoMesa As Label
    Friend WithEvents tbMesa As TextBox
    Friend WithEvents btnVerifica As Button
    Friend WithEvents btnPix As Button
    Friend WithEvents lbTotalVenda As TextBox
    Friend WithEvents btnConsumo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGrid As DataGridView
    Friend WithEvents btnConfirmaImpressao As Button
    Friend WithEvents IDVendaMovto As DataGridViewTextBoxColumn
    Friend WithEvents ImprimeImpressora As DataGridViewCheckBoxColumn
    Friend WithEvents Qtd As DataGridViewTextBoxColumn
    Friend WithEvents Produto As DataGridViewTextBoxColumn
End Class
