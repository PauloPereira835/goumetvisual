<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgEstorno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgEstorno))
        Me.GridMotivo = New System.Windows.Forms.DataGridView()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbStatusMesa = New System.Windows.Forms.Label()
        Me.lbMesa = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkEstornaMesa = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbPorQuantidade = New System.Windows.Forms.RadioButton()
        Me.rbPorLancamento = New System.Windows.Forms.RadioButton()
        Me.btnSai = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbQuantidade = New System.Windows.Forms.Label()
        Me.tbQtde = New System.Windows.Forms.TextBox()
        Me.tbCodigoProduto = New System.Windows.Forms.TextBox()
        Me.PanelTeclado = New System.Windows.Forms.Panel()
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
        Me.lstProdutos = New System.Windows.Forms.ListBox()
        CType(Me.GridMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelTeclado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridMotivo
        '
        Me.GridMotivo.AllowUserToAddRows = False
        Me.GridMotivo.AllowUserToDeleteRows = False
        Me.GridMotivo.AllowUserToResizeColumns = False
        Me.GridMotivo.AllowUserToResizeRows = False
        Me.GridMotivo.BackgroundColor = System.Drawing.Color.White
        Me.GridMotivo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GridMotivo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridMotivo.ColumnHeadersVisible = False
        Me.GridMotivo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Motivo})
        Me.GridMotivo.DataMember = "DescricaoPedido"
        Me.GridMotivo.Location = New System.Drawing.Point(413, 169)
        Me.GridMotivo.MultiSelect = False
        Me.GridMotivo.Name = "GridMotivo"
        Me.GridMotivo.ReadOnly = True
        Me.GridMotivo.RowHeadersVisible = False
        Me.GridMotivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridMotivo.Size = New System.Drawing.Size(217, 182)
        Me.GridMotivo.TabIndex = 15
        Me.GridMotivo.TabStop = False
        '
        'Motivo
        '
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        Me.Motivo.Width = 200
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(409, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Motivo"
        '
        'lbStatusMesa
        '
        Me.lbStatusMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatusMesa.ForeColor = System.Drawing.Color.Blue
        Me.lbStatusMesa.Location = New System.Drawing.Point(8, 10)
        Me.lbStatusMesa.Name = "lbStatusMesa"
        Me.lbStatusMesa.Size = New System.Drawing.Size(85, 20)
        Me.lbStatusMesa.TabIndex = 18
        Me.lbStatusMesa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbMesa
        '
        Me.lbMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMesa.ForeColor = System.Drawing.Color.Navy
        Me.lbMesa.Location = New System.Drawing.Point(98, 5)
        Me.lbMesa.Name = "lbMesa"
        Me.lbMesa.Size = New System.Drawing.Size(100, 28)
        Me.lbMesa.TabIndex = 19
        Me.lbMesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Produto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(342, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Qtde."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnSai)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(625, 81)
        Me.Panel1.TabIndex = 24
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.chkEstornaMesa)
        Me.Panel4.Location = New System.Drawing.Point(79, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(146, 68)
        Me.Panel4.TabIndex = 30
        '
        'chkEstornaMesa
        '
        Me.chkEstornaMesa.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEstornaMesa.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.chkEstornaMesa.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkEstornaMesa.FlatAppearance.BorderSize = 0
        Me.chkEstornaMesa.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.chkEstornaMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEstornaMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEstornaMesa.ForeColor = System.Drawing.Color.Blue
        Me.chkEstornaMesa.Location = New System.Drawing.Point(13, 5)
        Me.chkEstornaMesa.Name = "chkEstornaMesa"
        Me.chkEstornaMesa.Size = New System.Drawing.Size(116, 51)
        Me.chkEstornaMesa.TabIndex = 0
        Me.chkEstornaMesa.Text = "Estornar Cartão"
        Me.chkEstornaMesa.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkEstornaMesa.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.rbPorQuantidade)
        Me.Panel3.Controls.Add(Me.rbPorLancamento)
        Me.Panel3.Location = New System.Drawing.Point(227, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(188, 68)
        Me.Panel3.TabIndex = 28
        '
        'rbPorQuantidade
        '
        Me.rbPorQuantidade.AutoSize = True
        Me.rbPorQuantidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorQuantidade.ForeColor = System.Drawing.Color.Navy
        Me.rbPorQuantidade.Location = New System.Drawing.Point(3, 35)
        Me.rbPorQuantidade.Name = "rbPorQuantidade"
        Me.rbPorQuantidade.Size = New System.Drawing.Size(174, 28)
        Me.rbPorQuantidade.TabIndex = 29
        Me.rbPorQuantidade.TabStop = True
        Me.rbPorQuantidade.Text = "Por Quantidade"
        Me.rbPorQuantidade.UseVisualStyleBackColor = True
        '
        'rbPorLancamento
        '
        Me.rbPorLancamento.AutoSize = True
        Me.rbPorLancamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorLancamento.ForeColor = System.Drawing.Color.Navy
        Me.rbPorLancamento.Location = New System.Drawing.Point(3, 0)
        Me.rbPorLancamento.Name = "rbPorLancamento"
        Me.rbPorLancamento.Size = New System.Drawing.Size(180, 28)
        Me.rbPorLancamento.TabIndex = 28
        Me.rbPorLancamento.TabStop = True
        Me.rbPorLancamento.Text = "Por Lançamento"
        Me.rbPorLancamento.UseVisualStyleBackColor = True
        '
        'btnSai
        '
        Me.btnSai.BackColor = System.Drawing.Color.White
        Me.btnSai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSai.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSai.FlatAppearance.BorderSize = 2
        Me.btnSai.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSai.ForeColor = System.Drawing.Color.Blue
        Me.btnSai.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnSai.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSai.Location = New System.Drawing.Point(8, 5)
        Me.btnSai.Name = "btnSai"
        Me.btnSai.Size = New System.Drawing.Size(68, 68)
        Me.btnSai.TabIndex = 13
        Me.btnSai.TabStop = False
        Me.btnSai.Text = "Sair"
        Me.btnSai.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSai.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok1
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(428, 5)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(189, 68)
        Me.btnConfirma.TabIndex = 12
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Confirma F7"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lbQuantidade)
        Me.Panel2.Controls.Add(Me.tbQtde)
        Me.Panel2.Controls.Add(Me.lbMesa)
        Me.Panel2.Controls.Add(Me.lbStatusMesa)
        Me.Panel2.Location = New System.Drawing.Point(5, 92)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(625, 49)
        Me.Panel2.TabIndex = 25
        Me.Panel2.TabStop = True
        '
        'lbQuantidade
        '
        Me.lbQuantidade.AutoSize = True
        Me.lbQuantidade.Location = New System.Drawing.Point(463, 17)
        Me.lbQuantidade.Name = "lbQuantidade"
        Me.lbQuantidade.Size = New System.Drawing.Size(62, 13)
        Me.lbQuantidade.TabIndex = 26
        Me.lbQuantidade.Text = "Quantidade"
        '
        'tbQtde
        '
        Me.tbQtde.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbQtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbQtde.Location = New System.Drawing.Point(531, 13)
        Me.tbQtde.Multiline = True
        Me.tbQtde.Name = "tbQtde"
        Me.tbQtde.Size = New System.Drawing.Size(68, 20)
        Me.tbQtde.TabIndex = 25
        Me.tbQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCodigoProduto
        '
        Me.tbCodigoProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCodigoProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigoProduto.Location = New System.Drawing.Point(538, 147)
        Me.tbCodigoProduto.Multiline = True
        Me.tbCodigoProduto.Name = "tbCodigoProduto"
        Me.tbCodigoProduto.Size = New System.Drawing.Size(68, 20)
        Me.tbCodigoProduto.TabIndex = 26
        Me.tbCodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCodigoProduto.Visible = False
        '
        'PanelTeclado
        '
        Me.PanelTeclado.BackColor = System.Drawing.Color.Gainsboro
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
        Me.PanelTeclado.Location = New System.Drawing.Point(413, 352)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(217, 287)
        Me.PanelTeclado.TabIndex = 27
        '
        'Button14
        '
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button14.Location = New System.Drawing.Point(141, 211)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(70, 70)
        Me.Button14.TabIndex = 11
        Me.Button14.TabStop = False
        Me.Button14.Text = ","
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = CType(resources.GetObject("Button11.BackgroundImage"), System.Drawing.Image)
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button11.Location = New System.Drawing.Point(72, 211)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(70, 70)
        Me.Button11.TabIndex = 10
        Me.Button11.TabStop = False
        Me.Button11.Text = "Limpa"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
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
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 70)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "7"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstProdutos
        '
        Me.lstProdutos.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProdutos.FormattingEnabled = True
        Me.lstProdutos.ItemHeight = 16
        Me.lstProdutos.Location = New System.Drawing.Point(5, 168)
        Me.lstProdutos.Name = "lstProdutos"
        Me.lstProdutos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstProdutos.Size = New System.Drawing.Size(402, 468)
        Me.lstProdutos.TabIndex = 28
        '
        'fdlgEstorno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(638, 651)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstProdutos)
        Me.Controls.Add(Me.PanelTeclado)
        Me.Controls.Add(Me.tbCodigoProduto)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridMotivo)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgEstorno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estorno de Produtos"
        CType(Me.GridMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelTeclado.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConfirma As Button
    Friend WithEvents btnSai As Button
    Friend WithEvents GridMotivo As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents lbStatusMesa As Label
    Friend WithEvents lbMesa As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Motivo As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbQtde As TextBox
    Friend WithEvents lbQuantidade As Label
    Friend WithEvents tbCodigoProduto As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PanelTeclado As Panel
    Friend WithEvents Button14 As Button
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
    Friend WithEvents rbPorQuantidade As RadioButton
    Friend WithEvents rbPorLancamento As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents chkEstornaMesa As CheckBox
    Friend WithEvents lstProdutos As ListBox
End Class
