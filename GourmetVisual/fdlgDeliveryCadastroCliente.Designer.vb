<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgDeliveryCadastroCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgDeliveryCadastroCliente))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbObservacao = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbIDExterno = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbTel1 = New System.Windows.Forms.TextBox()
        Me.tbDataCadastro = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbIDCliente = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.chkPermiteSaldoNegativo = New System.Windows.Forms.CheckBox()
        Me.tbBuscaRuas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbCPF_CNPJ = New System.Windows.Forms.MaskedTextBox()
        Me.tbIDRua = New System.Windows.Forms.TextBox()
        Me.lbTaxaEntrega = New System.Windows.Forms.Label()
        Me.tbArea = New System.Windows.Forms.TextBox()
        Me.btnOrigem = New System.Windows.Forms.Button()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbEstado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbCidade = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbComplementoTel = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbReferencia = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbTel2 = New System.Windows.Forms.TextBox()
        Me.tbDDD2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbNomeCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbDDD1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.lbTelefone = New System.Windows.Forms.Label()
        Me.lbDDD = New System.Windows.Forms.Label()
        Me.btnLocaliza = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.btnGrava = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.lstClientes = New System.Windows.Forms.ListView()
        Me.IDCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Logradouro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Numero = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Complemento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bairro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CEP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDExterno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbTotalClientes = New System.Windows.Forms.Label()
        Me.tbBuscaEndereco = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnBusca = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbBuscaNumero = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbBuscaCli = New System.Windows.Forms.TextBox()
        Me.lbTextoObs = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lbTextoObs)
        Me.Panel1.Controls.Add(Me.tbObservacao)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.tbDataCadastro)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.tbIDCliente)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.tbBuscaRuas)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.tbCPF_CNPJ)
        Me.Panel1.Controls.Add(Me.tbIDRua)
        Me.Panel1.Controls.Add(Me.lbTaxaEntrega)
        Me.Panel1.Controls.Add(Me.tbArea)
        Me.Panel1.Controls.Add(Me.btnOrigem)
        Me.Panel1.Controls.Add(Me.cbOrigem)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.tbEstado)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.tbCidade)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.tbComplementoTel)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.tbReferencia)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.tbTel2)
        Me.Panel1.Controls.Add(Me.tbDDD2)
        Me.Panel1.Controls.Add(Me.Label10)
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
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.tbNomeCliente)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbDDD1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(5, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 560)
        Me.Panel1.TabIndex = 40
        '
        'tbObservacao
        '
        Me.tbObservacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservacao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbObservacao.Location = New System.Drawing.Point(78, 125)
        Me.tbObservacao.Multiline = True
        Me.tbObservacao.Name = "tbObservacao"
        Me.tbObservacao.Size = New System.Drawing.Size(449, 47)
        Me.tbObservacao.TabIndex = 71
        '
        'Label23
        '
        Me.Label23.ForeColor = System.Drawing.Color.Maroon
        Me.Label23.Location = New System.Drawing.Point(5, 131)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 15)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "Observação"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.tbIDExterno)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.tbTel1)
        Me.Panel3.Location = New System.Drawing.Point(119, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(411, 35)
        Me.Panel3.TabIndex = 0
        '
        'tbIDExterno
        '
        Me.tbIDExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDExterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbIDExterno.Location = New System.Drawing.Point(265, 4)
        Me.tbIDExterno.Name = "tbIDExterno"
        Me.tbIDExterno.Size = New System.Drawing.Size(142, 26)
        Me.tbIDExterno.TabIndex = 71
        Me.tbIDExterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.Color.Maroon
        Me.Label22.Location = New System.Drawing.Point(184, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 15)
        Me.Label22.TabIndex = 70
        Me.Label22.Text = "Código externo"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbTel1
        '
        Me.tbTel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbTel1.Location = New System.Drawing.Point(3, 4)
        Me.tbTel1.Name = "tbTel1"
        Me.tbTel1.Size = New System.Drawing.Size(146, 26)
        Me.tbTel1.TabIndex = 0
        Me.tbTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbDataCadastro
        '
        Me.tbDataCadastro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDataCadastro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbDataCadastro.Location = New System.Drawing.Point(78, 528)
        Me.tbDataCadastro.Name = "tbDataCadastro"
        Me.tbDataCadastro.ReadOnly = True
        Me.tbDataCadastro.Size = New System.Drawing.Size(184, 26)
        Me.tbDataCadastro.TabIndex = 67
        Me.tbDataCadastro.TabStop = False
        Me.tbDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(0, 533)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Data Cadastro"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(298, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 15)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "CPF/CNPJ"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbIDCliente
        '
        Me.tbIDCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbIDCliente.Location = New System.Drawing.Point(330, 192)
        Me.tbIDCliente.Name = "tbIDCliente"
        Me.tbIDCliente.Size = New System.Drawing.Size(70, 26)
        Me.tbIDCliente.TabIndex = 65
        Me.tbIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDCliente.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.chkPermiteSaldoNegativo)
        Me.Panel2.Location = New System.Drawing.Point(287, 500)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(239, 51)
        Me.Panel2.TabIndex = 64
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Maroon
        Me.Label19.Location = New System.Drawing.Point(-2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 16)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "Financeiro"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button6.Location = New System.Drawing.Point(3, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(30, 33)
        Me.Button6.TabIndex = 63
        Me.Button6.TabStop = False
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = False
        '
        'chkPermiteSaldoNegativo
        '
        Me.chkPermiteSaldoNegativo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.chkPermiteSaldoNegativo.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkPermiteSaldoNegativo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkPermiteSaldoNegativo.ForeColor = System.Drawing.Color.Maroon
        Me.chkPermiteSaldoNegativo.Location = New System.Drawing.Point(92, 26)
        Me.chkPermiteSaldoNegativo.Name = "chkPermiteSaldoNegativo"
        Me.chkPermiteSaldoNegativo.Size = New System.Drawing.Size(140, 18)
        Me.chkPermiteSaldoNegativo.TabIndex = 9
        Me.chkPermiteSaldoNegativo.Text = "Permite Saldo Negativo"
        Me.chkPermiteSaldoNegativo.UseVisualStyleBackColor = False
        '
        'tbBuscaRuas
        '
        Me.tbBuscaRuas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaRuas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBuscaRuas.Location = New System.Drawing.Point(264, 226)
        Me.tbBuscaRuas.Name = "tbBuscaRuas"
        Me.tbBuscaRuas.Size = New System.Drawing.Size(263, 26)
        Me.tbBuscaRuas.TabIndex = 63
        Me.tbBuscaRuas.TabStop = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(121, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 20)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Busca pelo nome ou CEP"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCPF_CNPJ
        '
        Me.tbCPF_CNPJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCPF_CNPJ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCPF_CNPJ.Location = New System.Drawing.Point(361, 96)
        Me.tbCPF_CNPJ.Name = "tbCPF_CNPJ"
        Me.tbCPF_CNPJ.Size = New System.Drawing.Size(166, 26)
        Me.tbCPF_CNPJ.TabIndex = 1
        '
        'tbIDRua
        '
        Me.tbIDRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDRua.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbIDRua.Location = New System.Drawing.Point(473, 259)
        Me.tbIDRua.Name = "tbIDRua"
        Me.tbIDRua.Size = New System.Drawing.Size(38, 26)
        Me.tbIDRua.TabIndex = 57
        Me.tbIDRua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbIDRua.Visible = False
        '
        'lbTaxaEntrega
        '
        Me.lbTaxaEntrega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTaxaEntrega.Location = New System.Drawing.Point(262, 266)
        Me.lbTaxaEntrega.Name = "lbTaxaEntrega"
        Me.lbTaxaEntrega.Size = New System.Drawing.Size(41, 15)
        Me.lbTaxaEntrega.TabIndex = 56
        Me.lbTaxaEntrega.Text = "10,00"
        Me.lbTaxaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbArea
        '
        Me.tbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbArea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbArea.Location = New System.Drawing.Point(208, 262)
        Me.tbArea.Name = "tbArea"
        Me.tbArea.ReadOnly = True
        Me.tbArea.Size = New System.Drawing.Size(52, 22)
        Me.tbArea.TabIndex = 55
        Me.tbArea.Text = "01"
        Me.tbArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOrigem
        '
        Me.btnOrigem.BackColor = System.Drawing.SystemColors.Control
        Me.btnOrigem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOrigem.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnOrigem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrigem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrigem.ForeColor = System.Drawing.Color.Blue
        Me.btnOrigem.Image = Global.GourmetVisual.My.Resources.Resources.Plus
        Me.btnOrigem.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnOrigem.Location = New System.Drawing.Point(268, 94)
        Me.btnOrigem.Name = "btnOrigem"
        Me.btnOrigem.Size = New System.Drawing.Size(23, 25)
        Me.btnOrigem.TabIndex = 53
        Me.btnOrigem.TabStop = False
        Me.btnOrigem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOrigem.UseVisualStyleBackColor = False
        '
        'cbOrigem
        '
        Me.cbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.ItemHeight = 13
        Me.cbOrigem.Location = New System.Drawing.Point(78, 98)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(190, 21)
        Me.cbOrigem.TabIndex = 51
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(479, 456)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(14, 20)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "/"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbEstado
        '
        Me.tbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbEstado.Location = New System.Drawing.Point(496, 453)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.ReadOnly = True
        Me.tbEstado.Size = New System.Drawing.Size(30, 26)
        Me.tbEstado.TabIndex = 49
        Me.tbEstado.Text = "APTO 125"
        Me.tbEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(1, 460)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 15)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "Cidade/Estado"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCidade
        '
        Me.tbCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCidade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCidade.Location = New System.Drawing.Point(81, 453)
        Me.tbCidade.Name = "tbCidade"
        Me.tbCidade.ReadOnly = True
        Me.tbCidade.Size = New System.Drawing.Size(395, 26)
        Me.tbCidade.TabIndex = 47
        Me.tbCidade.TabStop = False
        Me.tbCidade.Text = "APTO 125"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(142, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 38)
        Me.Button1.TabIndex = 41
        Me.Button1.TabStop = False
        Me.Button1.Text = "Cadastro de Lougradouros"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(175, 266)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 15)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Área"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbComplementoTel
        '
        Me.tbComplementoTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComplementoTel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComplementoTel.Location = New System.Drawing.Point(78, 67)
        Me.tbComplementoTel.Name = "tbComplementoTel"
        Me.tbComplementoTel.Size = New System.Drawing.Size(449, 26)
        Me.tbComplementoTel.TabIndex = 3
        Me.tbComplementoTel.Text = "JOSE ANTONIO"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(-3, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 27)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Complemento telefone"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(0, 428)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Referência"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbReferencia
        '
        Me.tbReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbReferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbReferencia.Location = New System.Drawing.Point(81, 421)
        Me.tbReferencia.Name = "tbReferencia"
        Me.tbReferencia.Size = New System.Drawing.Size(446, 26)
        Me.tbReferencia.TabIndex = 6
        Me.tbReferencia.Text = "APTO 125"
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(0, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 15)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Origem"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbTel2
        '
        Me.tbTel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbTel2.Location = New System.Drawing.Point(121, 498)
        Me.tbTel2.Name = "tbTel2"
        Me.tbTel2.Size = New System.Drawing.Size(141, 26)
        Me.tbTel2.TabIndex = 7
        Me.tbTel2.Text = "978000541"
        Me.tbTel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbDDD2
        '
        Me.tbDDD2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDDD2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbDDD2.Location = New System.Drawing.Point(78, 498)
        Me.tbDDD2.Name = "tbDDD2"
        Me.tbDDD2.Size = New System.Drawing.Size(38, 26)
        Me.tbDDD2.TabIndex = 19
        Me.tbDDD2.TabStop = False
        Me.tbDDD2.Text = "011"
        Me.tbDDD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(0, 503)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 15)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Telefone (2)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(0, 267)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "CEP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCEP
        '
        Me.tbCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCEP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCEP.Location = New System.Drawing.Point(81, 260)
        Me.tbCEP.Name = "tbCEP"
        Me.tbCEP.ReadOnly = True
        Me.tbCEP.Size = New System.Drawing.Size(87, 26)
        Me.tbCEP.TabIndex = 16
        Me.tbCEP.TabStop = False
        Me.tbCEP.Text = "04610030"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(0, 396)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Bairro"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBairro
        '
        Me.tbBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBairro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBairro.Location = New System.Drawing.Point(81, 389)
        Me.tbBairro.Name = "tbBairro"
        Me.tbBairro.ReadOnly = True
        Me.tbBairro.Size = New System.Drawing.Size(446, 26)
        Me.tbBairro.TabIndex = 14
        Me.tbBairro.TabStop = False
        Me.tbBairro.Text = "APTO 125"
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(0, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Complemento"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbComplemento
        '
        Me.tbComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComplemento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComplemento.Location = New System.Drawing.Point(81, 357)
        Me.tbComplemento.Name = "tbComplemento"
        Me.tbComplemento.Size = New System.Drawing.Size(446, 26)
        Me.tbComplemento.TabIndex = 12
        Me.tbComplemento.Text = "APTO 125"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(0, 332)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Número"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbNumero
        '
        Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNumero.Location = New System.Drawing.Point(81, 325)
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Size = New System.Drawing.Size(446, 26)
        Me.tbNumero.TabIndex = 5
        Me.tbNumero.Text = "RUA"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(0, 299)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Logradouro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbLogradouro
        '
        Me.tbLogradouro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLogradouro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbLogradouro.Location = New System.Drawing.Point(81, 293)
        Me.tbLogradouro.Name = "tbLogradouro"
        Me.tbLogradouro.ReadOnly = True
        Me.tbLogradouro.Size = New System.Drawing.Size(446, 26)
        Me.tbLogradouro.TabIndex = 8
        Me.tbLogradouro.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(10, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 31)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Endereço"
        '
        'tbNomeCliente
        '
        Me.tbNomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNomeCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNomeCliente.Location = New System.Drawing.Point(78, 37)
        Me.tbNomeCliente.Name = "tbNomeCliente"
        Me.tbNomeCliente.Size = New System.Drawing.Size(449, 26)
        Me.tbNomeCliente.TabIndex = 2
        Me.tbNomeCliente.Text = "JOSE ANTONIO"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(0, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nome "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbDDD1
        '
        Me.tbDDD1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDDD1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbDDD1.Location = New System.Drawing.Point(78, 3)
        Me.tbDDD1.Name = "tbDDD1"
        Me.tbDDD1.Size = New System.Drawing.Size(38, 26)
        Me.tbDDD1.TabIndex = 1
        Me.tbDDD1.TabStop = False
        Me.tbDDD1.Text = "011"
        Me.tbDDD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(0, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Telefone"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbStatus
        '
        Me.lbStatus.BackColor = System.Drawing.Color.White
        Me.lbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbStatus.Location = New System.Drawing.Point(672, 603)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(31, 15)
        Me.lbStatus.TabIndex = 58
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbStatus.Visible = False
        '
        'lbTelefone
        '
        Me.lbTelefone.BackColor = System.Drawing.Color.White
        Me.lbTelefone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTelefone.Location = New System.Drawing.Point(635, 603)
        Me.lbTelefone.Name = "lbTelefone"
        Me.lbTelefone.Size = New System.Drawing.Size(31, 15)
        Me.lbTelefone.TabIndex = 59
        Me.lbTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTelefone.Visible = False
        '
        'lbDDD
        '
        Me.lbDDD.BackColor = System.Drawing.Color.White
        Me.lbDDD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbDDD.Location = New System.Drawing.Point(598, 603)
        Me.lbDDD.Name = "lbDDD"
        Me.lbDDD.Size = New System.Drawing.Size(31, 15)
        Me.lbDDD.TabIndex = 60
        Me.lbDDD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbDDD.Visible = False
        '
        'btnLocaliza
        '
        Me.btnLocaliza.BackColor = System.Drawing.Color.White
        Me.btnLocaliza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLocaliza.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnLocaliza.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocaliza.ForeColor = System.Drawing.Color.Blue
        Me.btnLocaliza.Image = CType(resources.GetObject("btnLocaliza.Image"), System.Drawing.Image)
        Me.btnLocaliza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLocaliza.Location = New System.Drawing.Point(96, 5)
        Me.btnLocaliza.Name = "btnLocaliza"
        Me.btnLocaliza.Size = New System.Drawing.Size(112, 48)
        Me.btnLocaliza.TabIndex = 64
        Me.btnLocaliza.TabStop = False
        Me.btnLocaliza.Text = "Localizar  "
        Me.btnLocaliza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLocaliza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLocaliza.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.White
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnExcluir.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Blue
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash2
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(207, 5)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(112, 48)
        Me.btnExcluir.TabIndex = 63
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Text = "Excluir    "
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'btnIncluir
        '
        Me.btnIncluir.BackColor = System.Drawing.Color.White
        Me.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIncluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnIncluir.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluir.ForeColor = System.Drawing.Color.Blue
        Me.btnIncluir.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.Location = New System.Drawing.Point(318, 5)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(112, 48)
        Me.btnIncluir.TabIndex = 62
        Me.btnIncluir.TabStop = False
        Me.btnIncluir.Text = "Incluir     "
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'btnGrava
        '
        Me.btnGrava.BackColor = System.Drawing.Color.White
        Me.btnGrava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGrava.Enabled = False
        Me.btnGrava.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnGrava.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrava.ForeColor = System.Drawing.Color.Blue
        Me.btnGrava.Image = Global.GourmetVisual.My.Resources.Resources.Save1
        Me.btnGrava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrava.Location = New System.Drawing.Point(429, 5)
        Me.btnGrava.Name = "btnGrava"
        Me.btnGrava.Size = New System.Drawing.Size(112, 48)
        Me.btnGrava.TabIndex = 41
        Me.btnGrava.TabStop = False
        Me.btnGrava.Text = "Gravar   "
        Me.btnGrava.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrava.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGrava.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnVoltar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(5, 5)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(92, 48)
        Me.btnVoltar.TabIndex = 39
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'lstClientes
        '
        Me.lstClientes.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstClientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDCliente, Me.Tel, Me.Nome, Me.Logradouro, Me.Numero, Me.Complemento, Me.Bairro, Me.CEP, Me.IDExterno})
        Me.lstClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lstClientes.FullRowSelect = True
        Me.lstClientes.GridLines = True
        Me.lstClientes.HideSelection = False
        Me.lstClientes.Location = New System.Drawing.Point(552, 38)
        Me.lstClientes.MultiSelect = False
        Me.lstClientes.Name = "lstClientes"
        Me.lstClientes.Size = New System.Drawing.Size(699, 555)
        Me.lstClientes.TabIndex = 65
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
        Me.Tel.Text = "Telefone/CPF"
        Me.Tel.Width = 69
        '
        'Nome
        '
        Me.Nome.Text = "Nome"
        Me.Nome.Width = 128
        '
        'Logradouro
        '
        Me.Logradouro.Text = "Logradouro"
        Me.Logradouro.Width = 200
        '
        'Numero
        '
        Me.Numero.Text = "Numero"
        Me.Numero.Width = 55
        '
        'Complemento
        '
        Me.Complemento.Text = "Complemento"
        Me.Complemento.Width = 80
        '
        'Bairro
        '
        Me.Bairro.Text = "Bairro"
        Me.Bairro.Width = 90
        '
        'CEP
        '
        Me.CEP.Text = "CEP"
        '
        'IDExterno
        '
        Me.IDExterno.Text = "Externo"
        Me.IDExterno.Width = 0
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(550, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 24)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Busca"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalClientes
        '
        Me.lbTotalClientes.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalClientes.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalClientes.Location = New System.Drawing.Point(833, 601)
        Me.lbTotalClientes.Name = "lbTotalClientes"
        Me.lbTotalClientes.Size = New System.Drawing.Size(399, 19)
        Me.lbTotalClientes.TabIndex = 69
        Me.lbTotalClientes.Text = "999"
        Me.lbTotalClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBuscaEndereco
        '
        Me.tbBuscaEndereco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaEndereco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBuscaEndereco.Location = New System.Drawing.Point(956, 6)
        Me.tbBuscaEndereco.Multiline = True
        Me.tbBuscaEndereco.Name = "tbBuscaEndereco"
        Me.tbBuscaEndereco.Size = New System.Drawing.Size(159, 24)
        Me.tbBuscaEndereco.TabIndex = 71
        Me.tbBuscaEndereco.TabStop = False
        Me.tbBuscaEndereco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(858, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 17)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "pelo endereço ou CEP"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBusca
        '
        Me.btnBusca.BackColor = System.Drawing.Color.Transparent
        Me.btnBusca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBusca.Enabled = False
        Me.btnBusca.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBusca.FlatAppearance.BorderSize = 0
        Me.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBusca.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusca.ForeColor = System.Drawing.Color.Blue
        Me.btnBusca.Image = CType(resources.GetObject("btnBusca.Image"), System.Drawing.Image)
        Me.btnBusca.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnBusca.Location = New System.Drawing.Point(1218, 1)
        Me.btnBusca.Name = "btnBusca"
        Me.btnBusca.Size = New System.Drawing.Size(30, 29)
        Me.btnBusca.TabIndex = 64
        Me.btnBusca.TabStop = False
        Me.btnBusca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBusca.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(590, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(92, 17)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "por nome ou telefone"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBuscaNumero
        '
        Me.tbBuscaNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBuscaNumero.Location = New System.Drawing.Point(1154, 5)
        Me.tbBuscaNumero.Multiline = True
        Me.tbBuscaNumero.Name = "tbBuscaNumero"
        Me.tbBuscaNumero.Size = New System.Drawing.Size(43, 24)
        Me.tbBuscaNumero.TabIndex = 74
        Me.tbBuscaNumero.TabStop = False
        Me.tbBuscaNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(1115, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 17)
        Me.Label25.TabIndex = 73
        Me.Label25.Text = "Número"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBuscaCli
        '
        Me.tbBuscaCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscaCli.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBuscaCli.Location = New System.Drawing.Point(684, 6)
        Me.tbBuscaCli.Multiline = True
        Me.tbBuscaCli.Name = "tbBuscaCli"
        Me.tbBuscaCli.Size = New System.Drawing.Size(154, 24)
        Me.tbBuscaCli.TabIndex = 75
        Me.tbBuscaCli.TabStop = False
        Me.tbBuscaCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbTextoObs
        '
        Me.lbTextoObs.ForeColor = System.Drawing.Color.Maroon
        Me.lbTextoObs.Location = New System.Drawing.Point(5, 155)
        Me.lbTextoObs.Name = "lbTextoObs"
        Me.lbTextoObs.Size = New System.Drawing.Size(70, 15)
        Me.lbTextoObs.TabIndex = 72
        Me.lbTextoObs.Text = "0 de 60"
        Me.lbTextoObs.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fdlgDeliveryCadastroCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1259, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbBuscaCli)
        Me.Controls.Add(Me.tbBuscaNumero)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.btnBusca)
        Me.Controls.Add(Me.tbBuscaEndereco)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lbTotalClientes)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lstClientes)
        Me.Controls.Add(Me.btnLocaliza)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnIncluir)
        Me.Controls.Add(Me.lbDDD)
        Me.Controls.Add(Me.lbTelefone)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.btnGrava)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVoltar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDeliveryCadastroCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Cliente"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVoltar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbTel2 As TextBox
    Friend WithEvents tbDDD2 As TextBox
    Friend WithEvents Label10 As Label
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
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNomeCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbTel1 As TextBox
    Friend WithEvents tbDDD1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents tbEstado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tbCidade As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents tbComplementoTel As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tbReferencia As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbOrigem As ComboBox
    Friend WithEvents btnOrigem As Button
    Friend WithEvents tbArea As TextBox
    Friend WithEvents lbTaxaEntrega As Label
    Friend WithEvents btnGrava As Button
    Friend WithEvents tbIDRua As TextBox
    Friend WithEvents lbStatus As Label
    Friend WithEvents lbTelefone As Label
    Friend WithEvents lbDDD As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents tbCPF_CNPJ As MaskedTextBox
    Friend WithEvents chkPermiteSaldoNegativo As CheckBox
    Friend WithEvents tbBuscaRuas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnIncluir As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents btnLocaliza As Button
    Friend WithEvents tbIDCliente As TextBox
    Friend WithEvents tbDataCadastro As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lstClientes As ListView
    Friend WithEvents IDCliente As ColumnHeader
    Friend WithEvents Tel As ColumnHeader
    Friend WithEvents Nome As ColumnHeader
    Friend WithEvents Logradouro As ColumnHeader
    Friend WithEvents Numero As ColumnHeader
    Friend WithEvents Complemento As ColumnHeader
    Friend WithEvents Label20 As Label
    Friend WithEvents lbTotalClientes As Label
    Friend WithEvents IDExterno As ColumnHeader
    Friend WithEvents tbBuscaEndereco As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Bairro As ColumnHeader
    Friend WithEvents CEP As ColumnHeader
    Friend WithEvents btnBusca As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents tbIDExterno As TextBox
    Friend WithEvents tbObservacao As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents tbBuscaNumero As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents tbBuscaCli As TextBox
    Friend WithEvents lbTextoObs As Label
End Class
