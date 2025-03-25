<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDelivery_Expedicao
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
        Me.PanelCat = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbIDVendaExterna = New System.Windows.Forms.Label()
        Me.lbCaixinha = New System.Windows.Forms.Label()
        Me.lbCaixinhaTxt = New System.Windows.Forms.Label()
        Me.lbComentExpedicao = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbEntregador = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbTroco = New System.Windows.Forms.Label()
        Me.lbLevarTroco = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbTel_CPF = New System.Windows.Forms.Label()
        Me.SombraLabel2 = New GourmetVisual.SombraLabel()
        Me.lbReferencia = New System.Windows.Forms.Label()
        Me.lbBairro = New System.Windows.Forms.Label()
        Me.lbCEP = New System.Windows.Forms.Label()
        Me.lbComplemento = New System.Windows.Forms.Label()
        Me.lbNumero = New System.Windows.Forms.Label()
        Me.lbRua = New System.Windows.Forms.Label()
        Me.lbPagamento = New System.Windows.Forms.Label()
        Me.lbValor = New System.Windows.Forms.Label()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbNumVenda = New System.Windows.Forms.Label()
        Me.tbIDVendaPagto = New System.Windows.Forms.TextBox()
        Me.tbValorVenda = New System.Windows.Forms.TextBox()
        Me.tbValorDesconto = New System.Windows.Forms.TextBox()
        Me.tbValorAcrescimo = New System.Windows.Forms.TextBox()
        Me.tbTaxaEntrega = New System.Windows.Forms.TextBox()
        Me.tbOrigem = New System.Windows.Forms.TextBox()
        Me.tbEntregador = New System.Windows.Forms.TextBox()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.tbIDFuncionario = New System.Windows.Forms.TextBox()
        Me.tbVenda = New System.Windows.Forms.TextBox()
        Me.DataSetEntregadores = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.DataSetEntregadores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelCat
        '
        Me.PanelCat.AutoScroll = True
        Me.PanelCat.BackColor = System.Drawing.Color.Black
        Me.PanelCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelCat.Location = New System.Drawing.Point(4, 315)
        Me.PanelCat.Name = "PanelCat"
        Me.PanelCat.Size = New System.Drawing.Size(521, 207)
        Me.PanelCat.TabIndex = 22
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(407, 4)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(118, 40)
        Me.btnConfirma.TabIndex = 23
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnVoltar.FlatAppearance.BorderSize = 0
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(4, 4)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(103, 40)
        Me.btnVoltar.TabIndex = 21
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lbIDVendaExterna)
        Me.Panel2.Controls.Add(Me.lbCaixinha)
        Me.Panel2.Controls.Add(Me.lbCaixinhaTxt)
        Me.Panel2.Controls.Add(Me.lbComentExpedicao)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.lbEntregador)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.lbTroco)
        Me.Panel2.Controls.Add(Me.lbLevarTroco)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.lbTel_CPF)
        Me.Panel2.Controls.Add(Me.SombraLabel2)
        Me.Panel2.Controls.Add(Me.lbReferencia)
        Me.Panel2.Controls.Add(Me.lbBairro)
        Me.Panel2.Controls.Add(Me.lbCEP)
        Me.Panel2.Controls.Add(Me.lbComplemento)
        Me.Panel2.Controls.Add(Me.lbNumero)
        Me.Panel2.Controls.Add(Me.lbRua)
        Me.Panel2.Controls.Add(Me.lbPagamento)
        Me.Panel2.Controls.Add(Me.lbValor)
        Me.Panel2.Controls.Add(Me.lbCliente)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lbNumVenda)
        Me.Panel2.Location = New System.Drawing.Point(4, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(521, 263)
        Me.Panel2.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(282, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Código externo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbIDVendaExterna
        '
        Me.lbIDVendaExterna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIDVendaExterna.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbIDVendaExterna.Location = New System.Drawing.Point(380, 27)
        Me.lbIDVendaExterna.Name = "lbIDVendaExterna"
        Me.lbIDVendaExterna.Size = New System.Drawing.Size(132, 16)
        Me.lbIDVendaExterna.TabIndex = 47
        Me.lbIDVendaExterna.Text = "Dados da venda"
        '
        'lbCaixinha
        '
        Me.lbCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaixinha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCaixinha.Location = New System.Drawing.Point(385, 110)
        Me.lbCaixinha.Name = "lbCaixinha"
        Me.lbCaixinha.Size = New System.Drawing.Size(127, 16)
        Me.lbCaixinha.TabIndex = 45
        Me.lbCaixinha.Text = "200,00"
        '
        'lbCaixinhaTxt
        '
        Me.lbCaixinhaTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaixinhaTxt.ForeColor = System.Drawing.Color.White
        Me.lbCaixinhaTxt.Location = New System.Drawing.Point(316, 110)
        Me.lbCaixinhaTxt.Name = "lbCaixinhaTxt"
        Me.lbCaixinhaTxt.Size = New System.Drawing.Size(69, 16)
        Me.lbCaixinhaTxt.TabIndex = 44
        Me.lbCaixinhaTxt.Text = "Caixinha"
        Me.lbCaixinhaTxt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbComentExpedicao
        '
        Me.lbComentExpedicao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbComentExpedicao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbComentExpedicao.Location = New System.Drawing.Point(72, 233)
        Me.lbComentExpedicao.Name = "lbComentExpedicao"
        Me.lbComentExpedicao.Size = New System.Drawing.Size(442, 18)
        Me.lbComentExpedicao.TabIndex = 43
        Me.lbComentExpedicao.Text = "Dados da venda"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(4, 235)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 16)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Comentário"
        '
        'lbEntregador
        '
        Me.lbEntregador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEntregador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbEntregador.Location = New System.Drawing.Point(72, 217)
        Me.lbEntregador.Name = "lbEntregador"
        Me.lbEntregador.Size = New System.Drawing.Size(327, 16)
        Me.lbEntregador.TabIndex = 41
        Me.lbEntregador.Text = "Dados da venda"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(4, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 16)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Entregador"
        '
        'lbTroco
        '
        Me.lbTroco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTroco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTroco.Location = New System.Drawing.Point(385, 94)
        Me.lbTroco.Name = "lbTroco"
        Me.lbTroco.Size = New System.Drawing.Size(127, 16)
        Me.lbTroco.TabIndex = 39
        Me.lbTroco.Text = "1000,00 / 200,00"
        '
        'lbLevarTroco
        '
        Me.lbLevarTroco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLevarTroco.ForeColor = System.Drawing.Color.White
        Me.lbLevarTroco.Location = New System.Drawing.Point(316, 94)
        Me.lbLevarTroco.Name = "lbLevarTroco"
        Me.lbLevarTroco.Size = New System.Drawing.Size(69, 16)
        Me.lbLevarTroco.TabIndex = 38
        Me.lbLevarTroco.Text = "Levar troco"
        Me.lbLevarTroco.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(2, 53)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 16)
        Me.Label22.TabIndex = 37
        Me.Label22.Text = "Tel./CPF"
        '
        'lbTel_CPF
        '
        Me.lbTel_CPF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTel_CPF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTel_CPF.Location = New System.Drawing.Point(71, 53)
        Me.lbTel_CPF.Name = "lbTel_CPF"
        Me.lbTel_CPF.Size = New System.Drawing.Size(327, 16)
        Me.lbTel_CPF.TabIndex = 36
        Me.lbTel_CPF.Text = "Dados da venda"
        '
        'SombraLabel2
        '
        Me.SombraLabel2.AutoSize = True
        Me.SombraLabel2.BackColor = System.Drawing.Color.Transparent
        Me.SombraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SombraLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SombraLabel2.ForeColorBack = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SombraLabel2.ForeColorFront = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SombraLabel2.Location = New System.Drawing.Point(-1, -2)
        Me.SombraLabel2.Name = "SombraLabel2"
        Me.SombraLabel2.Size = New System.Drawing.Size(169, 25)
        Me.SombraLabel2.TabIndex = 35
        Me.SombraLabel2.Text = "Dados da venda"
        '
        'lbReferencia
        '
        Me.lbReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbReferencia.Location = New System.Drawing.Point(71, 198)
        Me.lbReferencia.Name = "lbReferencia"
        Me.lbReferencia.Size = New System.Drawing.Size(327, 16)
        Me.lbReferencia.TabIndex = 34
        Me.lbReferencia.Text = "Dados da venda"
        '
        'lbBairro
        '
        Me.lbBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBairro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbBairro.Location = New System.Drawing.Point(72, 178)
        Me.lbBairro.Name = "lbBairro"
        Me.lbBairro.Size = New System.Drawing.Size(191, 16)
        Me.lbBairro.TabIndex = 33
        Me.lbBairro.Text = "Dados da venda"
        '
        'lbCEP
        '
        Me.lbCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCEP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCEP.Location = New System.Drawing.Point(382, 178)
        Me.lbCEP.Name = "lbCEP"
        Me.lbCEP.Size = New System.Drawing.Size(130, 16)
        Me.lbCEP.TabIndex = 32
        Me.lbCEP.Text = "Dados da venda"
        '
        'lbComplemento
        '
        Me.lbComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbComplemento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbComplemento.Location = New System.Drawing.Point(382, 159)
        Me.lbComplemento.Name = "lbComplemento"
        Me.lbComplemento.Size = New System.Drawing.Size(130, 16)
        Me.lbComplemento.TabIndex = 31
        Me.lbComplemento.Text = "Dados da venda"
        '
        'lbNumero
        '
        Me.lbNumero.BackColor = System.Drawing.Color.Transparent
        Me.lbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbNumero.Location = New System.Drawing.Point(71, 159)
        Me.lbNumero.Name = "lbNumero"
        Me.lbNumero.Size = New System.Drawing.Size(116, 16)
        Me.lbNumero.TabIndex = 30
        Me.lbNumero.Text = "Dados da venda"
        '
        'lbRua
        '
        Me.lbRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbRua.Location = New System.Drawing.Point(71, 140)
        Me.lbRua.Name = "lbRua"
        Me.lbRua.Size = New System.Drawing.Size(327, 16)
        Me.lbRua.TabIndex = 29
        Me.lbRua.Text = "Dados da venda"
        '
        'lbPagamento
        '
        Me.lbPagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPagamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbPagamento.Location = New System.Drawing.Point(72, 110)
        Me.lbPagamento.Name = "lbPagamento"
        Me.lbPagamento.Size = New System.Drawing.Size(327, 16)
        Me.lbPagamento.TabIndex = 28
        Me.lbPagamento.Text = "Dados da venda"
        '
        'lbValor
        '
        Me.lbValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbValor.Location = New System.Drawing.Point(72, 91)
        Me.lbValor.Name = "lbValor"
        Me.lbValor.Size = New System.Drawing.Size(132, 16)
        Me.lbValor.TabIndex = 27
        Me.lbValor.Text = "Dados da venda"
        '
        'lbCliente
        '
        Me.lbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCliente.Location = New System.Drawing.Point(71, 72)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(327, 16)
        Me.lbCliente.TabIndex = 26
        Me.lbCliente.Text = "Dados da venda"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(3, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 16)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Referência"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(356, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "CEP"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Bairro"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(313, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Complemento"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Número"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Logradouro"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Forma pagto."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Valor"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(2, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Venda"
        '
        'lbNumVenda
        '
        Me.lbNumVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumVenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbNumVenda.Location = New System.Drawing.Point(71, 27)
        Me.lbNumVenda.Name = "lbNumVenda"
        Me.lbNumVenda.Size = New System.Drawing.Size(116, 16)
        Me.lbNumVenda.TabIndex = 15
        Me.lbNumVenda.Text = "Dados da venda"
        '
        'tbIDVendaPagto
        '
        Me.tbIDVendaPagto.Location = New System.Drawing.Point(318, 4)
        Me.tbIDVendaPagto.Name = "tbIDVendaPagto"
        Me.tbIDVendaPagto.Size = New System.Drawing.Size(40, 20)
        Me.tbIDVendaPagto.TabIndex = 51
        Me.tbIDVendaPagto.Visible = False
        '
        'tbValorVenda
        '
        Me.tbValorVenda.Location = New System.Drawing.Point(272, 30)
        Me.tbValorVenda.Name = "tbValorVenda"
        Me.tbValorVenda.Size = New System.Drawing.Size(40, 20)
        Me.tbValorVenda.TabIndex = 50
        Me.tbValorVenda.Visible = False
        '
        'tbValorDesconto
        '
        Me.tbValorDesconto.Location = New System.Drawing.Point(272, 4)
        Me.tbValorDesconto.Name = "tbValorDesconto"
        Me.tbValorDesconto.Size = New System.Drawing.Size(40, 20)
        Me.tbValorDesconto.TabIndex = 49
        Me.tbValorDesconto.Visible = False
        '
        'tbValorAcrescimo
        '
        Me.tbValorAcrescimo.Location = New System.Drawing.Point(226, 30)
        Me.tbValorAcrescimo.Name = "tbValorAcrescimo"
        Me.tbValorAcrescimo.Size = New System.Drawing.Size(40, 20)
        Me.tbValorAcrescimo.TabIndex = 48
        Me.tbValorAcrescimo.Visible = False
        '
        'tbTaxaEntrega
        '
        Me.tbTaxaEntrega.Location = New System.Drawing.Point(226, 4)
        Me.tbTaxaEntrega.Name = "tbTaxaEntrega"
        Me.tbTaxaEntrega.Size = New System.Drawing.Size(40, 20)
        Me.tbTaxaEntrega.TabIndex = 47
        Me.tbTaxaEntrega.Visible = False
        '
        'tbOrigem
        '
        Me.tbOrigem.Location = New System.Drawing.Point(180, 30)
        Me.tbOrigem.Name = "tbOrigem"
        Me.tbOrigem.Size = New System.Drawing.Size(40, 20)
        Me.tbOrigem.TabIndex = 46
        Me.tbOrigem.Visible = False
        '
        'tbEntregador
        '
        Me.tbEntregador.Location = New System.Drawing.Point(134, 4)
        Me.tbEntregador.Name = "tbEntregador"
        Me.tbEntregador.Size = New System.Drawing.Size(40, 20)
        Me.tbEntregador.TabIndex = 45
        Me.tbEntregador.Visible = False
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(180, 4)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(40, 20)
        Me.tbIDVenda.TabIndex = 44
        Me.tbIDVenda.Visible = False
        '
        'tbIDFuncionario
        '
        Me.tbIDFuncionario.Location = New System.Drawing.Point(134, 30)
        Me.tbIDFuncionario.Name = "tbIDFuncionario"
        Me.tbIDFuncionario.Size = New System.Drawing.Size(40, 20)
        Me.tbIDFuncionario.TabIndex = 43
        Me.tbIDFuncionario.Visible = False
        '
        'tbVenda
        '
        Me.tbVenda.Location = New System.Drawing.Point(318, 30)
        Me.tbVenda.Name = "tbVenda"
        Me.tbVenda.Size = New System.Drawing.Size(40, 20)
        Me.tbVenda.TabIndex = 52
        Me.tbVenda.Visible = False
        '
        'DataSetEntregadores
        '
        Me.DataSetEntregadores.DataSetName = "NewDataSet"
        Me.DataSetEntregadores.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5})
        Me.DataTable1.TableName = "Table1"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        Me.DataColumn1.DataType = GetType(Short)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "IDFamilia"
        Me.DataColumn2.DataType = GetType(Double)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Descricao"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "IDProduto"
        Me.DataColumn4.DataType = GetType(Short)
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "Valor"
        Me.DataColumn5.DataType = GetType(Decimal)
        '
        'fdlgDelivery_Expedicao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(534, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbVenda)
        Me.Controls.Add(Me.tbIDVendaPagto)
        Me.Controls.Add(Me.tbValorVenda)
        Me.Controls.Add(Me.tbValorDesconto)
        Me.Controls.Add(Me.tbValorAcrescimo)
        Me.Controls.Add(Me.tbTaxaEntrega)
        Me.Controls.Add(Me.tbOrigem)
        Me.Controls.Add(Me.tbEntregador)
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.tbIDFuncionario)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnConfirma)
        Me.Controls.Add(Me.PanelCat)
        Me.Controls.Add(Me.btnVoltar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDelivery_Expedicao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expedição de pedidos"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataSetEntregadores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConfirma As Button
    Friend WithEvents PanelCat As FlowLayoutPanel
    Friend WithEvents btnVoltar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lbIDVendaExterna As Label
    Friend WithEvents lbCaixinha As Label
    Friend WithEvents lbCaixinhaTxt As Label
    Friend WithEvents lbComentExpedicao As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbEntregador As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lbTroco As Label
    Friend WithEvents lbLevarTroco As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lbTel_CPF As Label
    Friend WithEvents SombraLabel2 As SombraLabel
    Friend WithEvents lbReferencia As Label
    Friend WithEvents lbBairro As Label
    Friend WithEvents lbCEP As Label
    Friend WithEvents lbComplemento As Label
    Friend WithEvents lbNumero As Label
    Friend WithEvents lbRua As Label
    Friend WithEvents lbPagamento As Label
    Friend WithEvents lbValor As Label
    Friend WithEvents lbCliente As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbNumVenda As Label
    Friend WithEvents tbIDVendaPagto As TextBox
    Friend WithEvents tbValorVenda As TextBox
    Friend WithEvents tbValorDesconto As TextBox
    Friend WithEvents tbValorAcrescimo As TextBox
    Friend WithEvents tbTaxaEntrega As TextBox
    Friend WithEvents tbOrigem As TextBox
    Friend WithEvents tbEntregador As TextBox
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents tbIDFuncionario As TextBox
    Friend WithEvents tbVenda As TextBox
    Friend WithEvents DataSetEntregadores As DataSet
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents DataColumn4 As DataColumn
    Friend WithEvents DataColumn5 As DataColumn
End Class
