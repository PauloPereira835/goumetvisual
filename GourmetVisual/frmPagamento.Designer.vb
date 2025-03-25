<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPagamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagamento))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.lbServicoAjustado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelPagtos = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelTeclado = New System.Windows.Forms.Panel()
        Me.tbNumVendaD = New System.Windows.Forms.TextBox()
        Me.tbNumVenda = New System.Windows.Forms.TextBox()
        Me.tbTroco = New System.Windows.Forms.TextBox()
        Me.tbTrocoPadrao = New System.Windows.Forms.TextBox()
        Me.tbValorTaxaEntrega = New System.Windows.Forms.TextBox()
        Me.tbValorVenda = New System.Windows.Forms.TextBox()
        Me.tbValorAcrescimo = New System.Windows.Forms.TextBox()
        Me.tbValorDesconto = New System.Windows.Forms.TextBox()
        Me.tbValorProdutos = New System.Windows.Forms.TextBox()
        Me.tbMesa = New System.Windows.Forms.TextBox()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.tbDescricaoPagto = New System.Windows.Forms.TextBox()
        Me.tbCodigoPagto = New System.Windows.Forms.TextBox()
        Me.tbValor = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
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
        Me.PanelLista = New System.Windows.Forms.Panel()
        Me.btnCalculadora = New System.Windows.Forms.Button()
        Me.btnFixaTela = New System.Windows.Forms.Button()
        Me.btnLimpa = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.tbTotalPagtosCupom = New System.Windows.Forms.TextBox()
        Me.btnContaVale = New System.Windows.Forms.Button()
        Me.btnCaixinha = New System.Windows.Forms.Button()
        Me.btnTroco = New System.Windows.Forms.Button()
        Me.btnLimpaPagto = New System.Windows.Forms.Button()
        Me.btnCupomParcial = New System.Windows.Forms.Button()
        Me.lbTotalPagtos = New System.Windows.Forms.Label()
        Me.lstPagtos = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDFormaPagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoFormaPagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDVendaPagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cupom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDPendencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDPagtoDigital = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusDigital = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Terminal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbTroco = New System.Windows.Forms.Label()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btnConfirmaVenda = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.lbQtdeTotal = New System.Windows.Forms.Label()
        Me.lbValorPagar = New GourmetVisual.SombraLabel()
        Me.lbValorAcrescimos = New GourmetVisual.SombraLabel()
        Me.lbValorDescontos = New GourmetVisual.SombraLabel()
        Me.lbValorProdutos = New GourmetVisual.SombraLabel()
        Me.lbDestino = New GourmetVisual.SombraLabel()
        Me.lbDescricaoPagto = New GourmetVisual.SombraLabel()
        Me.lbTextoVenda = New GourmetVisual.SombraLabel()
        Me.lbModulo = New GourmetVisual.SombraLabel()
        Me.SombraLabel = New GourmetVisual.SombraLabel()
        Me.Panel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTeclado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelLista.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel.Controls.Add(Me.lbServicoAjustado)
        Me.Panel.Controls.Add(Me.lbModulo)
        Me.Panel.Controls.Add(Me.SombraLabel)
        Me.Panel.Controls.Add(Me.PictureBox1)
        Me.Panel.Location = New System.Drawing.Point(26, 8)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(1225, 89)
        Me.Panel.TabIndex = 2
        '
        'lbServicoAjustado
        '
        Me.lbServicoAjustado.BackColor = System.Drawing.Color.Transparent
        Me.lbServicoAjustado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbServicoAjustado.ForeColor = System.Drawing.Color.Green
        Me.lbServicoAjustado.Location = New System.Drawing.Point(248, 65)
        Me.lbServicoAjustado.Name = "lbServicoAjustado"
        Me.lbServicoAjustado.Size = New System.Drawing.Size(344, 21)
        Me.lbServicoAjustado.TabIndex = 50
        Me.lbServicoAjustado.Text = "Serviço ajustado: 99,00"
        Me.lbServicoAjustado.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(185, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PanelPagtos
        '
        Me.PanelPagtos.AutoScroll = True
        Me.PanelPagtos.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PanelPagtos.Location = New System.Drawing.Point(11, 101)
        Me.PanelPagtos.Name = "PanelPagtos"
        Me.PanelPagtos.Size = New System.Drawing.Size(356, 624)
        Me.PanelPagtos.TabIndex = 18
        '
        'PanelTeclado
        '
        Me.PanelTeclado.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PanelTeclado.Controls.Add(Me.tbNumVendaD)
        Me.PanelTeclado.Controls.Add(Me.tbNumVenda)
        Me.PanelTeclado.Controls.Add(Me.tbTroco)
        Me.PanelTeclado.Controls.Add(Me.tbTrocoPadrao)
        Me.PanelTeclado.Controls.Add(Me.tbValorTaxaEntrega)
        Me.PanelTeclado.Controls.Add(Me.tbValorVenda)
        Me.PanelTeclado.Controls.Add(Me.tbValorAcrescimo)
        Me.PanelTeclado.Controls.Add(Me.tbValorDesconto)
        Me.PanelTeclado.Controls.Add(Me.tbValorProdutos)
        Me.PanelTeclado.Controls.Add(Me.tbMesa)
        Me.PanelTeclado.Controls.Add(Me.tbIDVenda)
        Me.PanelTeclado.Controls.Add(Me.tbDescricaoPagto)
        Me.PanelTeclado.Controls.Add(Me.tbCodigoPagto)
        Me.PanelTeclado.Controls.Add(Me.lbDescricaoPagto)
        Me.PanelTeclado.Controls.Add(Me.lbTextoVenda)
        Me.PanelTeclado.Controls.Add(Me.tbValor)
        Me.PanelTeclado.Controls.Add(Me.Panel1)
        Me.PanelTeclado.Location = New System.Drawing.Point(373, 101)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(532, 447)
        Me.PanelTeclado.TabIndex = 0
        '
        'tbNumVendaD
        '
        Me.tbNumVendaD.Location = New System.Drawing.Point(434, 168)
        Me.tbNumVendaD.Name = "tbNumVendaD"
        Me.tbNumVendaD.Size = New System.Drawing.Size(74, 20)
        Me.tbNumVendaD.TabIndex = 48
        Me.tbNumVendaD.Visible = False
        '
        'tbNumVenda
        '
        Me.tbNumVenda.Location = New System.Drawing.Point(434, 142)
        Me.tbNumVenda.Name = "tbNumVenda"
        Me.tbNumVenda.Size = New System.Drawing.Size(74, 20)
        Me.tbNumVenda.TabIndex = 47
        Me.tbNumVenda.Visible = False
        '
        'tbTroco
        '
        Me.tbTroco.Location = New System.Drawing.Point(434, 338)
        Me.tbTroco.Name = "tbTroco"
        Me.tbTroco.Size = New System.Drawing.Size(74, 20)
        Me.tbTroco.TabIndex = 46
        Me.tbTroco.Visible = False
        '
        'tbTrocoPadrao
        '
        Me.tbTrocoPadrao.Location = New System.Drawing.Point(434, 421)
        Me.tbTrocoPadrao.Name = "tbTrocoPadrao"
        Me.tbTrocoPadrao.Size = New System.Drawing.Size(74, 20)
        Me.tbTrocoPadrao.TabIndex = 45
        Me.tbTrocoPadrao.Visible = False
        '
        'tbValorTaxaEntrega
        '
        Me.tbValorTaxaEntrega.Location = New System.Drawing.Point(434, 286)
        Me.tbValorTaxaEntrega.Name = "tbValorTaxaEntrega"
        Me.tbValorTaxaEntrega.Size = New System.Drawing.Size(74, 20)
        Me.tbValorTaxaEntrega.TabIndex = 44
        Me.tbValorTaxaEntrega.Visible = False
        '
        'tbValorVenda
        '
        Me.tbValorVenda.Location = New System.Drawing.Point(434, 312)
        Me.tbValorVenda.Name = "tbValorVenda"
        Me.tbValorVenda.Size = New System.Drawing.Size(74, 20)
        Me.tbValorVenda.TabIndex = 43
        Me.tbValorVenda.Visible = False
        '
        'tbValorAcrescimo
        '
        Me.tbValorAcrescimo.Location = New System.Drawing.Point(434, 260)
        Me.tbValorAcrescimo.Name = "tbValorAcrescimo"
        Me.tbValorAcrescimo.Size = New System.Drawing.Size(74, 20)
        Me.tbValorAcrescimo.TabIndex = 42
        Me.tbValorAcrescimo.Visible = False
        '
        'tbValorDesconto
        '
        Me.tbValorDesconto.Location = New System.Drawing.Point(434, 234)
        Me.tbValorDesconto.Name = "tbValorDesconto"
        Me.tbValorDesconto.Size = New System.Drawing.Size(74, 20)
        Me.tbValorDesconto.TabIndex = 41
        Me.tbValorDesconto.Visible = False
        '
        'tbValorProdutos
        '
        Me.tbValorProdutos.Location = New System.Drawing.Point(434, 208)
        Me.tbValorProdutos.Name = "tbValorProdutos"
        Me.tbValorProdutos.Size = New System.Drawing.Size(74, 20)
        Me.tbValorProdutos.TabIndex = 40
        Me.tbValorProdutos.Visible = False
        '
        'tbMesa
        '
        Me.tbMesa.Location = New System.Drawing.Point(434, 116)
        Me.tbMesa.Name = "tbMesa"
        Me.tbMesa.Size = New System.Drawing.Size(74, 20)
        Me.tbMesa.TabIndex = 39
        Me.tbMesa.Visible = False
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(434, 89)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(74, 20)
        Me.tbIDVenda.TabIndex = 38
        Me.tbIDVenda.Visible = False
        '
        'tbDescricaoPagto
        '
        Me.tbDescricaoPagto.Location = New System.Drawing.Point(434, 395)
        Me.tbDescricaoPagto.Name = "tbDescricaoPagto"
        Me.tbDescricaoPagto.Size = New System.Drawing.Size(74, 20)
        Me.tbDescricaoPagto.TabIndex = 37
        Me.tbDescricaoPagto.Visible = False
        '
        'tbCodigoPagto
        '
        Me.tbCodigoPagto.Location = New System.Drawing.Point(434, 369)
        Me.tbCodigoPagto.Name = "tbCodigoPagto"
        Me.tbCodigoPagto.Size = New System.Drawing.Size(74, 20)
        Me.tbCodigoPagto.TabIndex = 36
        Me.tbCodigoPagto.Visible = False
        '
        'tbValor
        '
        Me.tbValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbValor.Font = New System.Drawing.Font("Courier New", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValor.ForeColor = System.Drawing.Color.Blue
        Me.tbValor.Location = New System.Drawing.Point(174, 58)
        Me.tbValor.Name = "tbValor"
        Me.tbValor.Size = New System.Drawing.Size(208, 42)
        Me.tbValor.TabIndex = 0
        Me.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumBlue
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.Button12)
        Me.Panel1.Controls.Add(Me.Button11)
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(173, 102)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(210, 344)
        Me.Panel1.TabIndex = 4
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.BackgroundImage = Global.GourmetVisual.My.Resources.Resources.Botao_Ret_Laranja
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button13.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.Blue
        Me.Button13.Location = New System.Drawing.Point(2, 278)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(206, 61)
        Me.Button13.TabIndex = 12
        Me.Button13.Text = "Enter"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.Blue
        Me.Button12.Location = New System.Drawing.Point(70, 208)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(70, 70)
        Me.Button12.TabIndex = 11
        Me.Button12.Text = ","
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.BackgroundImage = Global.GourmetVisual.My.Resources.Resources.Botao_Ret_Laranja
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.Blue
        Me.Button11.Location = New System.Drawing.Point(138, 208)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(70, 70)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "Limpa"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.Blue
        Me.Button10.Location = New System.Drawing.Point(2, 208)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(70, 70)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "0"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Blue
        Me.Button7.Location = New System.Drawing.Point(138, 140)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(70, 70)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "3"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"), System.Drawing.Image)
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.Blue
        Me.Button8.Location = New System.Drawing.Point(70, 140)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(70, 70)
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "2"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.Blue
        Me.Button9.Location = New System.Drawing.Point(2, 140)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(70, 70)
        Me.Button9.TabIndex = 6
        Me.Button9.Text = "1"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Blue
        Me.Button4.Location = New System.Drawing.Point(138, 72)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(70, 70)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "6"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Blue
        Me.Button5.Location = New System.Drawing.Point(70, 72)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(70, 70)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Location = New System.Drawing.Point(2, 72)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(70, 70)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "4"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Location = New System.Drawing.Point(138, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 70)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "9"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Location = New System.Drawing.Point(70, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 70)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "8"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(2, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 70)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "7"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PanelLista
        '
        Me.PanelLista.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PanelLista.Controls.Add(Me.lbQtdeTotal)
        Me.PanelLista.Controls.Add(Me.btnCalculadora)
        Me.PanelLista.Controls.Add(Me.btnFixaTela)
        Me.PanelLista.Controls.Add(Me.btnLimpa)
        Me.PanelLista.Controls.Add(Me.btnVoltar)
        Me.PanelLista.Controls.Add(Me.tbTotalPagtosCupom)
        Me.PanelLista.Controls.Add(Me.btnContaVale)
        Me.PanelLista.Controls.Add(Me.btnCaixinha)
        Me.PanelLista.Controls.Add(Me.btnTroco)
        Me.PanelLista.Controls.Add(Me.btnLimpaPagto)
        Me.PanelLista.Controls.Add(Me.btnCupomParcial)
        Me.PanelLista.Controls.Add(Me.lbTotalPagtos)
        Me.PanelLista.Controls.Add(Me.lbValorPagar)
        Me.PanelLista.Controls.Add(Me.lbValorAcrescimos)
        Me.PanelLista.Controls.Add(Me.lbValorDescontos)
        Me.PanelLista.Controls.Add(Me.lbValorProdutos)
        Me.PanelLista.Controls.Add(Me.lstPagtos)
        Me.PanelLista.Controls.Add(Me.Label1)
        Me.PanelLista.Controls.Add(Me.lbDestino)
        Me.PanelLista.Location = New System.Drawing.Point(911, 101)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(356, 625)
        Me.PanelLista.TabIndex = 20
        '
        'btnCalculadora
        '
        Me.btnCalculadora.BackColor = System.Drawing.Color.White
        Me.btnCalculadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCalculadora.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnCalculadora.FlatAppearance.BorderSize = 0
        Me.btnCalculadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculadora.ForeColor = System.Drawing.Color.Blue
        Me.btnCalculadora.Image = CType(resources.GetObject("btnCalculadora.Image"), System.Drawing.Image)
        Me.btnCalculadora.Location = New System.Drawing.Point(132, 277)
        Me.btnCalculadora.Name = "btnCalculadora"
        Me.btnCalculadora.Size = New System.Drawing.Size(40, 40)
        Me.btnCalculadora.TabIndex = 50
        Me.btnCalculadora.UseVisualStyleBackColor = False
        '
        'btnFixaTela
        '
        Me.btnFixaTela.BackColor = System.Drawing.Color.White
        Me.btnFixaTela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnFixaTela.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnFixaTela.FlatAppearance.BorderSize = 0
        Me.btnFixaTela.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFixaTela.ForeColor = System.Drawing.Color.Blue
        Me.btnFixaTela.Image = Global.GourmetVisual.My.Resources.Resources.Lock_Open2
        Me.btnFixaTela.Location = New System.Drawing.Point(172, 277)
        Me.btnFixaTela.Name = "btnFixaTela"
        Me.btnFixaTela.Size = New System.Drawing.Size(40, 40)
        Me.btnFixaTela.TabIndex = 49
        Me.btnFixaTela.UseVisualStyleBackColor = False
        '
        'btnLimpa
        '
        Me.btnLimpa.BackColor = System.Drawing.Color.White
        Me.btnLimpa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpa.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnLimpa.FlatAppearance.BorderSize = 0
        Me.btnLimpa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpa.ForeColor = System.Drawing.Color.Blue
        Me.btnLimpa.Image = CType(resources.GetObject("btnLimpa.Image"), System.Drawing.Image)
        Me.btnLimpa.Location = New System.Drawing.Point(92, 277)
        Me.btnLimpa.Name = "btnLimpa"
        Me.btnLimpa.Size = New System.Drawing.Size(40, 40)
        Me.btnLimpa.TabIndex = 48
        Me.btnLimpa.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVoltar.Location = New System.Drawing.Point(12, 277)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(40, 40)
        Me.btnVoltar.TabIndex = 1
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'tbTotalPagtosCupom
        '
        Me.tbTotalPagtosCupom.Location = New System.Drawing.Point(259, 288)
        Me.tbTotalPagtosCupom.Name = "tbTotalPagtosCupom"
        Me.tbTotalPagtosCupom.Size = New System.Drawing.Size(36, 20)
        Me.tbTotalPagtosCupom.TabIndex = 47
        Me.tbTotalPagtosCupom.Visible = False
        '
        'btnContaVale
        '
        Me.btnContaVale.BackColor = System.Drawing.Color.White
        Me.btnContaVale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnContaVale.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnContaVale.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContaVale.ForeColor = System.Drawing.Color.Blue
        Me.btnContaVale.Location = New System.Drawing.Point(234, 565)
        Me.btnContaVale.Name = "btnContaVale"
        Me.btnContaVale.Size = New System.Drawing.Size(110, 40)
        Me.btnContaVale.TabIndex = 41
        Me.btnContaVale.Text = "Contra Vale  F3"
        Me.btnContaVale.UseVisualStyleBackColor = False
        Me.btnContaVale.Visible = False
        '
        'btnCaixinha
        '
        Me.btnCaixinha.BackColor = System.Drawing.Color.White
        Me.btnCaixinha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCaixinha.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCaixinha.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaixinha.ForeColor = System.Drawing.Color.Blue
        Me.btnCaixinha.Location = New System.Drawing.Point(123, 565)
        Me.btnCaixinha.Name = "btnCaixinha"
        Me.btnCaixinha.Size = New System.Drawing.Size(110, 40)
        Me.btnCaixinha.TabIndex = 40
        Me.btnCaixinha.Text = "Caixinha  F2"
        Me.btnCaixinha.UseVisualStyleBackColor = False
        Me.btnCaixinha.Visible = False
        '
        'btnTroco
        '
        Me.btnTroco.BackColor = System.Drawing.Color.LawnGreen
        Me.btnTroco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTroco.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnTroco.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTroco.ForeColor = System.Drawing.Color.Blue
        Me.btnTroco.Location = New System.Drawing.Point(12, 565)
        Me.btnTroco.Name = "btnTroco"
        Me.btnTroco.Size = New System.Drawing.Size(110, 40)
        Me.btnTroco.TabIndex = 13
        Me.btnTroco.Text = "Troco  F1"
        Me.btnTroco.UseVisualStyleBackColor = False
        Me.btnTroco.Visible = False
        '
        'btnLimpaPagto
        '
        Me.btnLimpaPagto.BackColor = System.Drawing.Color.White
        Me.btnLimpaPagto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpaPagto.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnLimpaPagto.FlatAppearance.BorderSize = 0
        Me.btnLimpaPagto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpaPagto.ForeColor = System.Drawing.Color.Blue
        Me.btnLimpaPagto.Image = Global.GourmetVisual.My.Resources.Resources.Trash2
        Me.btnLimpaPagto.Location = New System.Drawing.Point(52, 277)
        Me.btnLimpaPagto.Name = "btnLimpaPagto"
        Me.btnLimpaPagto.Size = New System.Drawing.Size(40, 40)
        Me.btnLimpaPagto.TabIndex = 39
        Me.btnLimpaPagto.UseVisualStyleBackColor = False
        '
        'btnCupomParcial
        '
        Me.btnCupomParcial.BackColor = System.Drawing.Color.White
        Me.btnCupomParcial.BackgroundImage = Global.GourmetVisual.My.Resources.Resources.Imprimir
        Me.btnCupomParcial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCupomParcial.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnCupomParcial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCupomParcial.ForeColor = System.Drawing.Color.Blue
        Me.btnCupomParcial.Location = New System.Drawing.Point(301, 277)
        Me.btnCupomParcial.Name = "btnCupomParcial"
        Me.btnCupomParcial.Size = New System.Drawing.Size(40, 40)
        Me.btnCupomParcial.TabIndex = 22
        Me.btnCupomParcial.UseVisualStyleBackColor = False
        '
        'lbTotalPagtos
        '
        Me.lbTotalPagtos.BackColor = System.Drawing.Color.White
        Me.lbTotalPagtos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalPagtos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTotalPagtos.Location = New System.Drawing.Point(106, 251)
        Me.lbTotalPagtos.Name = "lbTotalPagtos"
        Me.lbTotalPagtos.Size = New System.Drawing.Size(211, 23)
        Me.lbTotalPagtos.TabIndex = 37
        Me.lbTotalPagtos.Text = "0,00"
        Me.lbTotalPagtos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstPagtos
        '
        Me.lstPagtos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstPagtos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstPagtos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.IDFormaPagto, Me.CodigoFormaPagto, Me.Descricao, Me.Valor, Me.IDVendaPagto, Me.Cupom, Me.IDCliente, Me.IDPendencia, Me.IDPagtoDigital, Me.StatusDigital, Me.Terminal})
        Me.lstPagtos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPagtos.ForeColor = System.Drawing.Color.Blue
        Me.lstPagtos.FullRowSelect = True
        Me.lstPagtos.GridLines = True
        Me.lstPagtos.HideSelection = False
        Me.lstPagtos.Location = New System.Drawing.Point(14, 9)
        Me.lstPagtos.MultiSelect = False
        Me.lstPagtos.Name = "lstPagtos"
        Me.lstPagtos.Size = New System.Drawing.Size(327, 241)
        Me.lstPagtos.TabIndex = 31
        Me.lstPagtos.UseCompatibleStateImageBehavior = False
        Me.lstPagtos.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 0
        '
        'IDFormaPagto
        '
        Me.IDFormaPagto.Text = "IDFormaPagto"
        Me.IDFormaPagto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IDFormaPagto.Width = 0
        '
        'CodigoFormaPagto
        '
        Me.CodigoFormaPagto.Text = "CodigoFormaPagto"
        Me.CodigoFormaPagto.Width = 0
        '
        'Descricao
        '
        Me.Descricao.Text = "Descrição"
        Me.Descricao.Width = 190
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Valor.Width = 110
        '
        'IDVendaPagto
        '
        Me.IDVendaPagto.Text = "IDVendaPagto"
        Me.IDVendaPagto.Width = 0
        '
        'Cupom
        '
        Me.Cupom.Text = "Cupom"
        Me.Cupom.Width = 0
        '
        'IDCliente
        '
        Me.IDCliente.Text = "IDCliente"
        Me.IDCliente.Width = 0
        '
        'IDPendencia
        '
        Me.IDPendencia.Text = "IDPendencia"
        Me.IDPendencia.Width = 0
        '
        'IDPagtoDigital
        '
        Me.IDPagtoDigital.Width = 0
        '
        'StatusDigital
        '
        Me.StatusDigital.Width = 0
        '
        'Terminal
        '
        Me.Terminal.Width = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 251)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 23)
        Me.Label1.TabIndex = 38
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTroco
        '
        Me.lbTroco.BackColor = System.Drawing.Color.Green
        Me.lbTroco.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTroco.ForeColor = System.Drawing.Color.Yellow
        Me.lbTroco.Location = New System.Drawing.Point(343, 663)
        Me.lbTroco.Name = "lbTroco"
        Me.lbTroco.Size = New System.Drawing.Size(600, 62)
        Me.lbTroco.TabIndex = 21
        Me.lbTroco.Text = "Sobra"
        Me.lbTroco.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbTroco.Visible = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button14.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button14.Location = New System.Drawing.Point(427, 603)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(60, 60)
        Me.Button14.TabIndex = 33
        Me.Button14.Text = "F4"
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button14.UseVisualStyleBackColor = False
        '
        'btnConfirmaVenda
        '
        Me.btnConfirmaVenda.BackColor = System.Drawing.Color.White
        Me.btnConfirmaVenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirmaVenda.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConfirmaVenda.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmaVenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfirmaVenda.Image = Global.GourmetVisual.My.Resources.Resources.Ok1
        Me.btnConfirmaVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirmaVenda.Location = New System.Drawing.Point(640, 603)
        Me.btnConfirmaVenda.Name = "btnConfirmaVenda"
        Me.btnConfirmaVenda.Size = New System.Drawing.Size(270, 60)
        Me.btnConfirmaVenda.TabIndex = 32
        Me.btnConfirmaVenda.Text = "Finaliza Venda  F7"
        Me.btnConfirmaVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirmaVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirmaVenda.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button15.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button15.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button15.Image = CType(resources.GetObject("Button15.Image"), System.Drawing.Image)
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button15.Location = New System.Drawing.Point(486, 603)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(60, 60)
        Me.Button15.TabIndex = 34
        Me.Button15.Text = "F5"
        Me.Button15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.White
        Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button16.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button16.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button16.Image = CType(resources.GetObject("Button16.Image"), System.Drawing.Image)
        Me.Button16.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button16.Location = New System.Drawing.Point(368, 603)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(60, 60)
        Me.Button16.TabIndex = 35
        Me.Button16.Text = "F3"
        Me.Button16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button16.UseVisualStyleBackColor = False
        '
        'lbQtdeTotal
        '
        Me.lbQtdeTotal.BackColor = System.Drawing.Color.White
        Me.lbQtdeTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeTotal.ForeColor = System.Drawing.Color.Blue
        Me.lbQtdeTotal.Location = New System.Drawing.Point(15, 251)
        Me.lbQtdeTotal.Name = "lbQtdeTotal"
        Me.lbQtdeTotal.Size = New System.Drawing.Size(93, 23)
        Me.lbQtdeTotal.TabIndex = 51
        Me.lbQtdeTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbValorPagar
        '
        Me.lbValorPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValorPagar.ForeColor = System.Drawing.Color.White
        Me.lbValorPagar.ForeColorFront = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbValorPagar.Location = New System.Drawing.Point(8, 485)
        Me.lbValorPagar.Name = "lbValorPagar"
        Me.lbValorPagar.Size = New System.Drawing.Size(340, 49)
        Me.lbValorPagar.TabIndex = 36
        Me.lbValorPagar.Text = "Valor a pagar"
        '
        'lbValorAcrescimos
        '
        Me.lbValorAcrescimos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValorAcrescimos.ForeColor = System.Drawing.Color.White
        Me.lbValorAcrescimos.ForeColorFront = System.Drawing.Color.White
        Me.lbValorAcrescimos.Location = New System.Drawing.Point(8, 430)
        Me.lbValorAcrescimos.Name = "lbValorAcrescimos"
        Me.lbValorAcrescimos.Size = New System.Drawing.Size(340, 49)
        Me.lbValorAcrescimos.TabIndex = 35
        Me.lbValorAcrescimos.Text = "Acrécimos"
        '
        'lbValorDescontos
        '
        Me.lbValorDescontos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValorDescontos.ForeColor = System.Drawing.Color.White
        Me.lbValorDescontos.ForeColorFront = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbValorDescontos.Location = New System.Drawing.Point(8, 375)
        Me.lbValorDescontos.Name = "lbValorDescontos"
        Me.lbValorDescontos.Size = New System.Drawing.Size(340, 49)
        Me.lbValorDescontos.TabIndex = 34
        Me.lbValorDescontos.Text = "Descontos"
        '
        'lbValorProdutos
        '
        Me.lbValorProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValorProdutos.ForeColor = System.Drawing.Color.White
        Me.lbValorProdutos.ForeColorFront = System.Drawing.Color.White
        Me.lbValorProdutos.Location = New System.Drawing.Point(8, 320)
        Me.lbValorProdutos.Name = "lbValorProdutos"
        Me.lbValorProdutos.Size = New System.Drawing.Size(340, 49)
        Me.lbValorProdutos.TabIndex = 33
        Me.lbValorProdutos.Text = "Produtos"
        '
        'lbDestino
        '
        Me.lbDestino.BackColor = System.Drawing.Color.White
        Me.lbDestino.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDestino.ForeColor = System.Drawing.Color.Transparent
        Me.lbDestino.ForeColorBack = System.Drawing.Color.Transparent
        Me.lbDestino.ForeColorFront = System.Drawing.Color.Maroon
        Me.lbDestino.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lbDestino.Location = New System.Drawing.Point(8, 540)
        Me.lbDestino.Name = "lbDestino"
        Me.lbDestino.Size = New System.Drawing.Size(340, 72)
        Me.lbDestino.TabIndex = 45
        Me.lbDestino.Visible = False
        '
        'lbDescricaoPagto
        '
        Me.lbDescricaoPagto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescricaoPagto.ForeColor = System.Drawing.Color.White
        Me.lbDescricaoPagto.ForeColorFront = System.Drawing.Color.White
        Me.lbDescricaoPagto.Location = New System.Drawing.Point(15, 3)
        Me.lbDescricaoPagto.Name = "lbDescricaoPagto"
        Me.lbDescricaoPagto.Size = New System.Drawing.Size(506, 24)
        Me.lbDescricaoPagto.TabIndex = 35
        Me.lbDescricaoPagto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbTextoVenda
        '
        Me.lbTextoVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTextoVenda.ForeColor = System.Drawing.Color.White
        Me.lbTextoVenda.ForeColorFront = System.Drawing.Color.White
        Me.lbTextoVenda.Location = New System.Drawing.Point(15, 31)
        Me.lbTextoVenda.Name = "lbTextoVenda"
        Me.lbTextoVenda.Size = New System.Drawing.Size(506, 23)
        Me.lbTextoVenda.TabIndex = 34
        Me.lbTextoVenda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbModulo
        '
        Me.lbModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbModulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbModulo.ForeColorBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbModulo.ForeColorFront = System.Drawing.Color.White
        Me.lbModulo.Location = New System.Drawing.Point(1044, 57)
        Me.lbModulo.Name = "lbModulo"
        Me.lbModulo.OffsetX = 3
        Me.lbModulo.OffsetY = -2
        Me.lbModulo.Size = New System.Drawing.Size(172, 40)
        Me.lbModulo.TabIndex = 4
        Me.lbModulo.Text = "Delivery"
        '
        'SombraLabel
        '
        Me.SombraLabel.BackColor = System.Drawing.Color.Transparent
        Me.SombraLabel.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SombraLabel.ForeColor = System.Drawing.Color.MediumBlue
        Me.SombraLabel.ForeColorBack = System.Drawing.Color.MediumBlue
        Me.SombraLabel.ForeColorFront = System.Drawing.Color.White
        Me.SombraLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SombraLabel.Location = New System.Drawing.Point(838, -8)
        Me.SombraLabel.Name = "SombraLabel"
        Me.SombraLabel.OffsetX = 5
        Me.SombraLabel.OffsetY = -3
        Me.SombraLabel.Size = New System.Drawing.Size(416, 83)
        Me.SombraLabel.TabIndex = 3
        Me.SombraLabel.Text = "Pagamento"
        '
        'frmPagamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(1274, 770)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.PanelPagtos)
        Me.Controls.Add(Me.PanelLista)
        Me.Controls.Add(Me.PanelTeclado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.lbTroco)
        Me.Controls.Add(Me.btnConfirmaVenda)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmPagamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPagamento"
        Me.Panel.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTeclado.ResumeLayout(False)
        Me.PanelTeclado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.PanelLista.ResumeLayout(False)
        Me.PanelLista.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVoltar As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents SombraLabel As SombraLabel
    Friend WithEvents PanelPagtos As FlowLayoutPanel
    Friend WithEvents PanelTeclado As Panel
    Friend WithEvents PanelLista As Panel
    Friend WithEvents tbValor As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
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
    Friend WithEvents btnConfirmaVenda As Button
    Friend WithEvents lstPagtos As ListView
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents IDFormaPagto As ColumnHeader
    Friend WithEvents CodigoFormaPagto As ColumnHeader
    Friend WithEvents lbTroco As Label
    Friend WithEvents lbValorProdutos As SombraLabel
    Friend WithEvents lbValorPagar As SombraLabel
    Friend WithEvents lbValorAcrescimos As SombraLabel
    Friend WithEvents lbValorDescontos As SombraLabel
    Friend WithEvents lbTextoVenda As SombraLabel
    Friend WithEvents lbDescricaoPagto As SombraLabel
    Friend WithEvents lbTotalPagtos As Label
    Friend WithEvents Descricao As ColumnHeader
    Friend WithEvents Valor As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents tbDescricaoPagto As TextBox
    Friend WithEvents tbCodigoPagto As TextBox
    Friend WithEvents btnCupomParcial As Button
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents tbMesa As TextBox
    Friend WithEvents tbValorVenda As TextBox
    Friend WithEvents tbValorAcrescimo As TextBox
    Friend WithEvents tbValorDesconto As TextBox
    Friend WithEvents tbValorProdutos As TextBox
    Friend WithEvents tbValorTaxaEntrega As TextBox
    Friend WithEvents lbModulo As SombraLabel
    Friend WithEvents btnLimpaPagto As Button
    Friend WithEvents lbDestino As SombraLabel
    Friend WithEvents btnContaVale As Button
    Friend WithEvents btnCaixinha As Button
    Friend WithEvents btnTroco As Button
    Friend WithEvents tbTrocoPadrao As TextBox
    Friend WithEvents tbTroco As TextBox
    Friend WithEvents IDVendaPagto As ColumnHeader
    Friend WithEvents Cupom As ColumnHeader
    Friend WithEvents tbTotalPagtosCupom As TextBox
    Friend WithEvents Button14 As Button
    Friend WithEvents btnFixaTela As Button
    Friend WithEvents btnLimpa As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents tbNumVenda As TextBox
    Friend WithEvents tbNumVendaD As TextBox
    Friend WithEvents lbServicoAjustado As Label
    Friend WithEvents btnCalculadora As Button
    Friend WithEvents IDCliente As ColumnHeader
    Friend WithEvents IDPendencia As ColumnHeader
    Friend WithEvents IDPagtoDigital As ColumnHeader
    Friend WithEvents StatusDigital As ColumnHeader
    Friend WithEvents Terminal As ColumnHeader
    Friend WithEvents lbQtdeTotal As Label
End Class
