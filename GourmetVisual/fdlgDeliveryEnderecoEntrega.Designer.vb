<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDeliveryEnderecoEntrega
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.lbBairro = New System.Windows.Forms.Label()
        Me.lbEndereco = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbIDRua = New System.Windows.Forms.TextBox()
        Me.tbComplemento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbNumero = New System.Windows.Forms.TextBox()
        Me.lbTaxaEntrega = New System.Windows.Forms.Label()
        Me.tbArea = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbCEP = New System.Windows.Forms.TextBox()
        Me.tbReferencia = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbEstado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbCidade = New System.Windows.Forms.TextBox()
        Me.tbBairro = New System.Windows.Forms.TextBox()
        Me.tbLogradouro = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbBuscaRuas = New System.Windows.Forms.TextBox()
        Me.tbStatus = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.tbStatus)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(673, 53)
        Me.Panel1.TabIndex = 27
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
        Me.btnVolta.Location = New System.Drawing.Point(9, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(80, 40)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Black
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(452, 6)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(101, 40)
        Me.btnConfirma.TabIndex = 23
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Tag = ""
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'lbBairro
        '
        Me.lbBairro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbBairro.Location = New System.Drawing.Point(296, 22)
        Me.lbBairro.Name = "lbBairro"
        Me.lbBairro.Size = New System.Drawing.Size(253, 17)
        Me.lbBairro.TabIndex = 30
        '
        'lbEndereco
        '
        Me.lbEndereco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbEndereco.Location = New System.Drawing.Point(3, 22)
        Me.lbEndereco.Name = "lbEndereco"
        Me.lbEndereco.Size = New System.Drawing.Size(278, 27)
        Me.lbEndereco.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Local de entrega atual"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 18)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Alterar para"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lbBairro)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lbEndereco)
        Me.Panel2.Location = New System.Drawing.Point(4, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(554, 56)
        Me.Panel2.TabIndex = 32
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.tbIDRua)
        Me.Panel3.Controls.Add(Me.tbComplemento)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.tbNumero)
        Me.Panel3.Controls.Add(Me.lbTaxaEntrega)
        Me.Panel3.Controls.Add(Me.tbArea)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.tbCEP)
        Me.Panel3.Controls.Add(Me.tbReferencia)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.tbEstado)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.tbCidade)
        Me.Panel3.Controls.Add(Me.tbBairro)
        Me.Panel3.Controls.Add(Me.tbLogradouro)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.tbBuscaRuas)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(4, 127)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(554, 163)
        Me.Panel3.TabIndex = 33
        Me.Panel3.Tag = ""
        '
        'tbIDRua
        '
        Me.tbIDRua.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbIDRua.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbIDRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDRua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbIDRua.Location = New System.Drawing.Point(100, 7)
        Me.tbIDRua.Multiline = True
        Me.tbIDRua.Name = "tbIDRua"
        Me.tbIDRua.ReadOnly = True
        Me.tbIDRua.Size = New System.Drawing.Size(59, 14)
        Me.tbIDRua.TabIndex = 83
        Me.tbIDRua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDRua.Visible = False
        '
        'tbComplemento
        '
        Me.tbComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComplemento.ForeColor = System.Drawing.Color.Blue
        Me.tbComplemento.Location = New System.Drawing.Point(322, 63)
        Me.tbComplemento.Multiline = True
        Me.tbComplemento.Name = "tbComplemento"
        Me.tbComplemento.Size = New System.Drawing.Size(221, 17)
        Me.tbComplemento.TabIndex = 82
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(445, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "CEP"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbNumero
        '
        Me.tbNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumero.ForeColor = System.Drawing.Color.Blue
        Me.tbNumero.Location = New System.Drawing.Point(82, 62)
        Me.tbNumero.Multiline = True
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Size = New System.Drawing.Size(138, 17)
        Me.tbNumero.TabIndex = 80
        '
        'lbTaxaEntrega
        '
        Me.lbTaxaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTaxaEntrega.ForeColor = System.Drawing.Color.Blue
        Me.lbTaxaEntrega.Location = New System.Drawing.Point(506, 88)
        Me.lbTaxaEntrega.Name = "lbTaxaEntrega"
        Me.lbTaxaEntrega.Size = New System.Drawing.Size(35, 13)
        Me.lbTaxaEntrega.TabIndex = 79
        Me.lbTaxaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbArea
        '
        Me.tbArea.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbArea.ForeColor = System.Drawing.Color.Blue
        Me.tbArea.Location = New System.Drawing.Point(484, 87)
        Me.tbArea.Multiline = True
        Me.tbArea.Name = "tbArea"
        Me.tbArea.ReadOnly = True
        Me.tbArea.Size = New System.Drawing.Size(20, 14)
        Me.tbArea.TabIndex = 78
        Me.tbArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(449, 88)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 13)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "Area"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCEP
        '
        Me.tbCEP.BackColor = System.Drawing.Color.SteelBlue
        Me.tbCEP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCEP.ForeColor = System.Drawing.Color.White
        Me.tbCEP.Location = New System.Drawing.Point(476, 38)
        Me.tbCEP.Multiline = True
        Me.tbCEP.Name = "tbCEP"
        Me.tbCEP.ReadOnly = True
        Me.tbCEP.Size = New System.Drawing.Size(67, 18)
        Me.tbCEP.TabIndex = 76
        Me.tbCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbReferencia
        '
        Me.tbReferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbReferencia.ForeColor = System.Drawing.Color.Blue
        Me.tbReferencia.Location = New System.Drawing.Point(82, 86)
        Me.tbReferencia.MaxLength = 50
        Me.tbReferencia.Multiline = True
        Me.tbReferencia.Name = "tbReferencia"
        Me.tbReferencia.Size = New System.Drawing.Size(357, 17)
        Me.tbReferencia.TabIndex = 75
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(-9, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 13)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "Referência"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbEstado
        '
        Me.tbEstado.BackColor = System.Drawing.Color.SteelBlue
        Me.tbEstado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEstado.ForeColor = System.Drawing.Color.White
        Me.tbEstado.Location = New System.Drawing.Point(375, 133)
        Me.tbEstado.Multiline = True
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.ReadOnly = True
        Me.tbEstado.Size = New System.Drawing.Size(23, 17)
        Me.tbEstado.TabIndex = 73
        Me.tbEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(361, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "/"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbCidade
        '
        Me.tbCidade.BackColor = System.Drawing.Color.SteelBlue
        Me.tbCidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCidade.ForeColor = System.Drawing.Color.White
        Me.tbCidade.Location = New System.Drawing.Point(82, 133)
        Me.tbCidade.Multiline = True
        Me.tbCidade.Name = "tbCidade"
        Me.tbCidade.ReadOnly = True
        Me.tbCidade.Size = New System.Drawing.Size(274, 17)
        Me.tbCidade.TabIndex = 71
        '
        'tbBairro
        '
        Me.tbBairro.BackColor = System.Drawing.Color.SteelBlue
        Me.tbBairro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBairro.ForeColor = System.Drawing.Color.White
        Me.tbBairro.Location = New System.Drawing.Point(82, 110)
        Me.tbBairro.Multiline = True
        Me.tbBairro.Name = "tbBairro"
        Me.tbBairro.ReadOnly = True
        Me.tbBairro.Size = New System.Drawing.Size(316, 17)
        Me.tbBairro.TabIndex = 70
        '
        'tbLogradouro
        '
        Me.tbLogradouro.BackColor = System.Drawing.Color.SteelBlue
        Me.tbLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbLogradouro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLogradouro.ForeColor = System.Drawing.Color.White
        Me.tbLogradouro.Location = New System.Drawing.Point(82, 38)
        Me.tbLogradouro.Multiline = True
        Me.tbLogradouro.Name = "tbLogradouro"
        Me.tbLogradouro.ReadOnly = True
        Me.tbLogradouro.Size = New System.Drawing.Size(357, 18)
        Me.tbLogradouro.TabIndex = 67
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(-10, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Cidade/Estado"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(231, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 13)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Complemento"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(3, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Número"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(3, 111)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Bairro"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(3, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Logradouro"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(165, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 15)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Busca logradouro/CEP"
        '
        'tbBuscaRuas
        '
        Me.tbBuscaRuas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbBuscaRuas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaRuas.ForeColor = System.Drawing.Color.Blue
        Me.tbBuscaRuas.Location = New System.Drawing.Point(299, 6)
        Me.tbBuscaRuas.Multiline = True
        Me.tbBuscaRuas.Name = "tbBuscaRuas"
        Me.tbBuscaRuas.Size = New System.Drawing.Size(244, 20)
        Me.tbBuscaRuas.TabIndex = 32
        '
        'tbStatus
        '
        Me.tbStatus.BackColor = System.Drawing.Color.SteelBlue
        Me.tbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStatus.ForeColor = System.Drawing.Color.White
        Me.tbStatus.Location = New System.Drawing.Point(203, 20)
        Me.tbStatus.Multiline = True
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.ReadOnly = True
        Me.tbStatus.Size = New System.Drawing.Size(23, 17)
        Me.tbStatus.TabIndex = 74
        Me.tbStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbStatus.Visible = False
        '
        'fdlgDeliveryEnderecoEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(563, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDeliveryEnderecoEntrega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endereço Entrega  -  Alterar"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents lbBairro As Label
    Friend WithEvents lbEndereco As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents tbBuscaRuas As TextBox
    Friend WithEvents tbComplemento As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbNumero As TextBox
    Friend WithEvents lbTaxaEntrega As Label
    Friend WithEvents tbArea As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents tbCEP As TextBox
    Friend WithEvents tbReferencia As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents tbEstado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tbCidade As TextBox
    Friend WithEvents tbBairro As TextBox
    Friend WithEvents tbLogradouro As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents tbIDRua As TextBox
    Friend WithEvents tbStatus As TextBox
End Class
