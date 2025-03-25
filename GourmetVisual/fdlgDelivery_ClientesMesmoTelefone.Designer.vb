<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDelivery_ClientesMesmoTelefone
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
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.lstClientes = New System.Windows.Forms.ListView()
        Me.IDCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Logradouro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Numero = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Complemento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bairro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CEP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ComplementoTel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbEstado = New System.Windows.Forms.TextBox()
        Me.tbBuscaRuas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbIDRua = New System.Windows.Forms.TextBox()
        Me.lbTaxaEntrega = New System.Windows.Forms.Label()
        Me.tbArea = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbCidade = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbReferencia = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbCEP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbBairro = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbComplemento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbNumero = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbLogradouro = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbCPF_CNPJ = New System.Windows.Forms.MaskedTextBox()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.tbComplementoTel = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbNomeCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbTelefone = New System.Windows.Forms.Label()
        Me.lbDDD = New System.Windows.Forms.Label()
        Me.lbQtdeClientes = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(6, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(103, 39)
        Me.btnVolta.TabIndex = 18
        Me.btnVolta.Text = "Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstClientes
        '
        Me.lstClientes.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstClientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDCliente, Me.Tel, Me.Nome, Me.Logradouro, Me.Numero, Me.Complemento, Me.Bairro, Me.CEP, Me.ComplementoTel})
        Me.lstClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lstClientes.FullRowSelect = True
        Me.lstClientes.GridLines = True
        Me.lstClientes.HideSelection = False
        Me.lstClientes.Location = New System.Drawing.Point(11, 53)
        Me.lstClientes.MultiSelect = False
        Me.lstClientes.Name = "lstClientes"
        Me.lstClientes.Size = New System.Drawing.Size(999, 349)
        Me.lstClientes.TabIndex = 66
        Me.lstClientes.TabStop = False
        Me.lstClientes.UseCompatibleStateImageBehavior = False
        Me.lstClientes.View = System.Windows.Forms.View.Details
        '
        'IDCliente
        '
        Me.IDCliente.Text = "IDCliente"
        Me.IDCliente.Width = 0
        '
        'Tel
        '
        Me.Tel.DisplayIndex = 8
        Me.Tel.Text = "Telefone"
        Me.Tel.Width = 0
        '
        'Nome
        '
        Me.Nome.Text = "Nome"
        Me.Nome.Width = 200
        '
        'Logradouro
        '
        Me.Logradouro.Text = "Logradouro"
        Me.Logradouro.Width = 230
        '
        'Numero
        '
        Me.Numero.Text = "Numero"
        Me.Numero.Width = 100
        '
        'Complemento
        '
        Me.Complemento.Text = "Complemento"
        Me.Complemento.Width = 330
        '
        'Bairro
        '
        Me.Bairro.Text = "Bairro"
        Me.Bairro.Width = 0
        '
        'CEP
        '
        Me.CEP.Text = "CEP"
        Me.CEP.Width = 0
        '
        'ComplementoTel
        '
        Me.ComplementoTel.DisplayIndex = 1
        Me.ComplementoTel.Text = "Descrição"
        Me.ComplementoTel.Width = 120
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Azure
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tbEstado)
        Me.Panel1.Controls.Add(Me.tbBuscaRuas)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.tbIDRua)
        Me.Panel1.Controls.Add(Me.lbTaxaEntrega)
        Me.Panel1.Controls.Add(Me.tbArea)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.tbCidade)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.tbReferencia)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.tbCEP)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tbBairro)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.tbComplemento)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.tbNumero)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.tbLogradouro)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.tbCPF_CNPJ)
        Me.Panel1.Controls.Add(Me.cbOrigem)
        Me.Panel1.Controls.Add(Me.tbComplementoTel)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.tbNomeCliente)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Location = New System.Drawing.Point(11, 448)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 307)
        Me.Panel1.TabIndex = 67
        '
        'tbEstado
        '
        Me.tbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbEstado.Location = New System.Drawing.Point(259, 277)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.ReadOnly = True
        Me.tbEstado.Size = New System.Drawing.Size(30, 20)
        Me.tbEstado.TabIndex = 94
        Me.tbEstado.Text = "APTO 125"
        Me.tbEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbBuscaRuas
        '
        Me.tbBuscaRuas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaRuas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBuscaRuas.Location = New System.Drawing.Point(250, 113)
        Me.tbBuscaRuas.Name = "tbBuscaRuas"
        Me.tbBuscaRuas.Size = New System.Drawing.Size(242, 26)
        Me.tbBuscaRuas.TabIndex = 100
        Me.tbBuscaRuas.TabStop = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(107, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 20)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Busca pelo nome ou CEP"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbIDRua
        '
        Me.tbIDRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDRua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbIDRua.Location = New System.Drawing.Point(3, 113)
        Me.tbIDRua.Name = "tbIDRua"
        Me.tbIDRua.Size = New System.Drawing.Size(38, 26)
        Me.tbIDRua.TabIndex = 98
        Me.tbIDRua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDRua.Visible = False
        '
        'lbTaxaEntrega
        '
        Me.lbTaxaEntrega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTaxaEntrega.Location = New System.Drawing.Point(256, 149)
        Me.lbTaxaEntrega.Name = "lbTaxaEntrega"
        Me.lbTaxaEntrega.Size = New System.Drawing.Size(41, 15)
        Me.lbTaxaEntrega.TabIndex = 97
        Me.lbTaxaEntrega.Text = "10,00"
        Me.lbTaxaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbArea
        '
        Me.tbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbArea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbArea.Location = New System.Drawing.Point(202, 147)
        Me.tbArea.Name = "tbArea"
        Me.tbArea.ReadOnly = True
        Me.tbArea.Size = New System.Drawing.Size(50, 20)
        Me.tbArea.TabIndex = 96
        Me.tbArea.Text = "01"
        Me.tbArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(-13, 279)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 15)
        Me.Label16.TabIndex = 93
        Me.Label16.Text = "Cidade/Est."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCidade
        '
        Me.tbCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCidade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCidade.Location = New System.Drawing.Point(67, 277)
        Me.tbCidade.Name = "tbCidade"
        Me.tbCidade.ReadOnly = True
        Me.tbCidade.Size = New System.Drawing.Size(181, 20)
        Me.tbCidade.TabIndex = 92
        Me.tbCidade.TabStop = False
        Me.tbCidade.Text = "APTO 125"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(171, 150)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 15)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Área"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(-13, 253)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Referência"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbReferencia
        '
        Me.tbReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbReferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbReferencia.Location = New System.Drawing.Point(67, 251)
        Me.tbReferencia.Name = "tbReferencia"
        Me.tbReferencia.Size = New System.Drawing.Size(425, 20)
        Me.tbReferencia.TabIndex = 80
        Me.tbReferencia.Text = "APTO 125"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(-13, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 15)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "CEP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCEP
        '
        Me.tbCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCEP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCEP.Location = New System.Drawing.Point(67, 147)
        Me.tbCEP.Name = "tbCEP"
        Me.tbCEP.ReadOnly = True
        Me.tbCEP.Size = New System.Drawing.Size(87, 20)
        Me.tbCEP.TabIndex = 88
        Me.tbCEP.TabStop = False
        Me.tbCEP.Text = "04610030"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(-13, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Bairro"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBairro
        '
        Me.tbBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBairro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBairro.Location = New System.Drawing.Point(67, 225)
        Me.tbBairro.Name = "tbBairro"
        Me.tbBairro.ReadOnly = True
        Me.tbBairro.Size = New System.Drawing.Size(425, 20)
        Me.tbBairro.TabIndex = 86
        Me.tbBairro.TabStop = False
        Me.tbBairro.Text = "APTO 125"
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(158, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Complemento"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbComplemento
        '
        Me.tbComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComplemento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComplemento.Location = New System.Drawing.Point(238, 199)
        Me.tbComplemento.Name = "tbComplemento"
        Me.tbComplemento.Size = New System.Drawing.Size(254, 20)
        Me.tbComplemento.TabIndex = 84
        Me.tbComplemento.Text = "APTO 125"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(-13, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Número"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbNumero
        '
        Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNumero.Location = New System.Drawing.Point(67, 199)
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Size = New System.Drawing.Size(87, 20)
        Me.tbNumero.TabIndex = 79
        Me.tbNumero.Text = "RUA"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(-13, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Logradouro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLogradouro
        '
        Me.tbLogradouro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLogradouro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbLogradouro.Location = New System.Drawing.Point(67, 173)
        Me.tbLogradouro.Name = "tbLogradouro"
        Me.tbLogradouro.ReadOnly = True
        Me.tbLogradouro.Size = New System.Drawing.Size(425, 20)
        Me.tbLogradouro.TabIndex = 81
        Me.tbLogradouro.TabStop = False
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(276, 63)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 15)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "CPF/CNPJ"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCPF_CNPJ
        '
        Me.tbCPF_CNPJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCPF_CNPJ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCPF_CNPJ.Location = New System.Drawing.Point(338, 61)
        Me.tbCPF_CNPJ.Name = "tbCPF_CNPJ"
        Me.tbCPF_CNPJ.Size = New System.Drawing.Size(154, 20)
        Me.tbCPF_CNPJ.TabIndex = 71
        '
        'cbOrigem
        '
        Me.cbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.ItemHeight = 13
        Me.cbOrigem.Location = New System.Drawing.Point(338, 36)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(154, 21)
        Me.cbOrigem.TabIndex = 77
        '
        'tbComplementoTel
        '
        Me.tbComplementoTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComplementoTel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComplementoTel.Location = New System.Drawing.Point(73, 61)
        Me.tbComplementoTel.Name = "tbComplementoTel"
        Me.tbComplementoTel.Size = New System.Drawing.Size(201, 20)
        Me.tbComplementoTel.TabIndex = 73
        Me.tbComplementoTel.Text = "JOSE ANTONIO"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(-7, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 27)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Complemento telefone"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(289, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Origem"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbNomeCliente
        '
        Me.tbNomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNomeCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNomeCliente.Location = New System.Drawing.Point(73, 36)
        Me.tbNomeCliente.Name = "tbNomeCliente"
        Me.tbNomeCliente.Size = New System.Drawing.Size(201, 20)
        Me.tbNomeCliente.TabIndex = 72
        Me.tbNomeCliente.Text = "JOSE ANTONIO"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(-4, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Nome "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(408, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 25)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "Incluir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(250, 275)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 20)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "/"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTelefone
        '
        Me.lbTelefone.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTelefone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTelefone.Location = New System.Drawing.Point(642, 14)
        Me.lbTelefone.Name = "lbTelefone"
        Me.lbTelefone.Size = New System.Drawing.Size(155, 23)
        Me.lbTelefone.TabIndex = 68
        Me.lbTelefone.Text = "978000541"
        '
        'lbDDD
        '
        Me.lbDDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDDD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbDDD.Location = New System.Drawing.Point(581, 14)
        Me.lbDDD.Name = "lbDDD"
        Me.lbDDD.Size = New System.Drawing.Size(55, 23)
        Me.lbDDD.TabIndex = 69
        Me.lbDDD.Text = "011"
        Me.lbDDD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbQtdeClientes
        '
        Me.lbQtdeClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbQtdeClientes.Location = New System.Drawing.Point(609, 404)
        Me.lbQtdeClientes.Name = "lbQtdeClientes"
        Me.lbQtdeClientes.Size = New System.Drawing.Size(359, 13)
        Me.lbQtdeClientes.TabIndex = 70
        Me.lbQtdeClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(905, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 39)
        Me.Button2.TabIndex = 71
        Me.Button2.Text = "Incluir novo cliente"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.Location = New System.Drawing.Point(348, 15)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(227, 22)
        Me.tbBusca.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(261, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Busca por nome"
        '
        'fdlgDelivery_ClientesMesmoTelefone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1021, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lbQtdeClientes)
        Me.Controls.Add(Me.lbDDD)
        Me.Controls.Add(Me.lbTelefone)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstClientes)
        Me.Controls.Add(Me.btnVolta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDelivery_ClientesMesmoTelefone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes com o mesmo telefone"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVolta As Button
    Friend WithEvents lstClientes As ListView
    Friend WithEvents IDCliente As ColumnHeader
    Friend WithEvents Tel As ColumnHeader
    Friend WithEvents Nome As ColumnHeader
    Friend WithEvents Logradouro As ColumnHeader
    Friend WithEvents Numero As ColumnHeader
    Friend WithEvents Complemento As ColumnHeader
    Friend WithEvents Bairro As ColumnHeader
    Friend WithEvents CEP As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lbTelefone As Label
    Friend WithEvents lbDDD As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents tbCPF_CNPJ As MaskedTextBox
    Friend WithEvents cbOrigem As ComboBox
    Friend WithEvents tbComplementoTel As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents tbNomeCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbEstado As TextBox
    Friend WithEvents tbBuscaRuas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbIDRua As TextBox
    Friend WithEvents lbTaxaEntrega As Label
    Friend WithEvents tbArea As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tbCidade As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tbReferencia As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbCEP As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbBairro As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbComplemento As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbNumero As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbLogradouro As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents ComplementoTel As ColumnHeader
    Friend WithEvents lbQtdeClientes As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label1 As Label
End Class
