<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgCpf_Cnpj
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgCpf_Cnpj))
        Me.tbCpfCnpj = New System.Windows.Forms.TextBox()
        Me.lbMsgValido = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBoxNFCE = New System.Windows.Forms.PictureBox()
        Me.tbIDVendaPagto = New System.Windows.Forms.TextBox()
        Me.lbMensagem = New System.Windows.Forms.Label()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.tbIDSat = New System.Windows.Forms.TextBox()
        Me.tbDiaMovto = New System.Windows.Forms.TextBox()
        Me.tbStVenda = New System.Windows.Forms.TextBox()
        Me.tbTotVenda = New System.Windows.Forms.TextBox()
        Me.tbTxEntrega = New System.Windows.Forms.TextBox()
        Me.tbIDVendaSAT = New System.Windows.Forms.TextBox()
        Me.tbTotCupom = New System.Windows.Forms.TextBox()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.tbTotalAD = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.TimerAguardandoSAT = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBoxNFCE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbCpfCnpj
        '
        Me.tbCpfCnpj.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tbCpfCnpj.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbCpfCnpj.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCpfCnpj.ForeColor = System.Drawing.Color.Blue
        Me.tbCpfCnpj.Location = New System.Drawing.Point(45, 294)
        Me.tbCpfCnpj.Multiline = True
        Me.tbCpfCnpj.Name = "tbCpfCnpj"
        Me.tbCpfCnpj.Size = New System.Drawing.Size(286, 36)
        Me.tbCpfCnpj.TabIndex = 0
        Me.tbCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbMsgValido
        '
        Me.lbMsgValido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMsgValido.ForeColor = System.Drawing.Color.Maroon
        Me.lbMsgValido.Location = New System.Drawing.Point(12, 265)
        Me.lbMsgValido.Name = "lbMsgValido"
        Me.lbMsgValido.Size = New System.Drawing.Size(354, 23)
        Me.lbMsgValido.TabIndex = 2
        Me.lbMsgValido.Text = "Informe o CPF ou CNPJ do cliente"
        Me.lbMsgValido.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBoxNFCE)
        Me.Panel1.Controls.Add(Me.tbIDVendaPagto)
        Me.Panel1.Controls.Add(Me.lbMensagem)
        Me.Panel1.Controls.Add(Me.PictureBox)
        Me.Panel1.Controls.Add(Me.tbIDSat)
        Me.Panel1.Controls.Add(Me.tbCpfCnpj)
        Me.Panel1.Controls.Add(Me.tbDiaMovto)
        Me.Panel1.Controls.Add(Me.lbMsgValido)
        Me.Panel1.Controls.Add(Me.tbStVenda)
        Me.Panel1.Controls.Add(Me.tbTotVenda)
        Me.Panel1.Controls.Add(Me.tbTxEntrega)
        Me.Panel1.Controls.Add(Me.tbIDVendaSAT)
        Me.Panel1.Controls.Add(Me.tbTotCupom)
        Me.Panel1.Controls.Add(Me.tbIDVenda)
        Me.Panel1.Controls.Add(Me.tbTotalAD)
        Me.Panel1.Location = New System.Drawing.Point(9, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(381, 353)
        Me.Panel1.TabIndex = 4
        '
        'PictureBoxNFCE
        '
        'Me.PictureBoxNFCE.Image = Global.GourmetVisual.My.Resources.Resources.images
        Me.PictureBoxNFCE.Location = New System.Drawing.Point(126, 5)
        Me.PictureBoxNFCE.Name = "PictureBoxNFCE"
        Me.PictureBoxNFCE.Size = New System.Drawing.Size(124, 114)
        Me.PictureBoxNFCE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxNFCE.TabIndex = 38
        Me.PictureBoxNFCE.TabStop = False
        Me.PictureBoxNFCE.Visible = False
        '
        'tbIDVendaPagto
        '
        Me.tbIDVendaPagto.Enabled = False
        Me.tbIDVendaPagto.Location = New System.Drawing.Point(94, 245)
        Me.tbIDVendaPagto.Name = "tbIDVendaPagto"
        Me.tbIDVendaPagto.Size = New System.Drawing.Size(92, 20)
        Me.tbIDVendaPagto.TabIndex = 37
        Me.tbIDVendaPagto.TabStop = False
        Me.tbIDVendaPagto.Visible = False
        '
        'lbMensagem
        '
        Me.lbMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensagem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMensagem.Location = New System.Drawing.Point(14, 123)
        Me.lbMensagem.Name = "lbMensagem"
        Me.lbMensagem.Size = New System.Drawing.Size(350, 75)
        Me.lbMensagem.TabIndex = 5
        Me.lbMensagem.Text = "Aguarde... Imprimindo cupom fiscal"
        Me.lbMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox
        '
        Me.PictureBox.Image = Global.GourmetVisual.My.Resources.Resources.satOK
        Me.PictureBox.Location = New System.Drawing.Point(125, 22)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(124, 56)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'tbIDSat
        '
        Me.tbIDSat.Enabled = False
        Me.tbIDSat.Location = New System.Drawing.Point(0, 245)
        Me.tbIDSat.Name = "tbIDSat"
        Me.tbIDSat.Size = New System.Drawing.Size(92, 20)
        Me.tbIDSat.TabIndex = 13
        Me.tbIDSat.TabStop = False
        Me.tbIDSat.Visible = False
        '
        'tbDiaMovto
        '
        Me.tbDiaMovto.Enabled = False
        Me.tbDiaMovto.Location = New System.Drawing.Point(282, 219)
        Me.tbDiaMovto.Name = "tbDiaMovto"
        Me.tbDiaMovto.Size = New System.Drawing.Size(92, 20)
        Me.tbDiaMovto.TabIndex = 12
        Me.tbDiaMovto.TabStop = False
        Me.tbDiaMovto.Visible = False
        '
        'tbStVenda
        '
        Me.tbStVenda.Enabled = False
        Me.tbStVenda.Location = New System.Drawing.Point(188, 219)
        Me.tbStVenda.Name = "tbStVenda"
        Me.tbStVenda.Size = New System.Drawing.Size(92, 20)
        Me.tbStVenda.TabIndex = 11
        Me.tbStVenda.TabStop = False
        Me.tbStVenda.Visible = False
        '
        'tbTotVenda
        '
        Me.tbTotVenda.Enabled = False
        Me.tbTotVenda.Location = New System.Drawing.Point(282, 193)
        Me.tbTotVenda.Name = "tbTotVenda"
        Me.tbTotVenda.Size = New System.Drawing.Size(92, 20)
        Me.tbTotVenda.TabIndex = 8
        Me.tbTotVenda.TabStop = False
        Me.tbTotVenda.Visible = False
        '
        'tbTxEntrega
        '
        Me.tbTxEntrega.Enabled = False
        Me.tbTxEntrega.Location = New System.Drawing.Point(94, 219)
        Me.tbTxEntrega.Name = "tbTxEntrega"
        Me.tbTxEntrega.Size = New System.Drawing.Size(92, 20)
        Me.tbTxEntrega.TabIndex = 10
        Me.tbTxEntrega.TabStop = False
        Me.tbTxEntrega.Visible = False
        '
        'tbIDVendaSAT
        '
        Me.tbIDVendaSAT.Enabled = False
        Me.tbIDVendaSAT.Location = New System.Drawing.Point(0, 193)
        Me.tbIDVendaSAT.Name = "tbIDVendaSAT"
        Me.tbIDVendaSAT.Size = New System.Drawing.Size(92, 20)
        Me.tbIDVendaSAT.TabIndex = 5
        Me.tbIDVendaSAT.TabStop = False
        Me.tbIDVendaSAT.Visible = False
        '
        'tbTotCupom
        '
        Me.tbTotCupom.Enabled = False
        Me.tbTotCupom.Location = New System.Drawing.Point(0, 219)
        Me.tbTotCupom.Name = "tbTotCupom"
        Me.tbTotCupom.Size = New System.Drawing.Size(92, 20)
        Me.tbTotCupom.TabIndex = 9
        Me.tbTotCupom.TabStop = False
        Me.tbTotCupom.Visible = False
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Enabled = False
        Me.tbIDVenda.Location = New System.Drawing.Point(94, 193)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(92, 20)
        Me.tbIDVenda.TabIndex = 6
        Me.tbIDVenda.TabStop = False
        Me.tbIDVenda.Visible = False
        '
        'tbTotalAD
        '
        Me.tbTotalAD.Enabled = False
        Me.tbTotalAD.Location = New System.Drawing.Point(188, 193)
        Me.tbTotalAD.Name = "tbTotalAD"
        Me.tbTotalAD.Size = New System.Drawing.Size(92, 20)
        Me.tbTotalAD.TabIndex = 7
        Me.tbTotalAD.TabStop = False
        Me.tbTotalAD.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.Button11)
        Me.Panel6.Controls.Add(Me.Button10)
        Me.Panel6.Controls.Add(Me.Button7)
        Me.Panel6.Controls.Add(Me.Button8)
        Me.Panel6.Controls.Add(Me.Button9)
        Me.Panel6.Controls.Add(Me.Button4)
        Me.Panel6.Controls.Add(Me.Button5)
        Me.Panel6.Controls.Add(Me.Button6)
        Me.Panel6.Controls.Add(Me.Button14)
        Me.Panel6.Controls.Add(Me.Button15)
        Me.Panel6.Controls.Add(Me.Button16)
        Me.Panel6.Location = New System.Drawing.Point(396, 7)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(219, 353)
        Me.Panel6.TabIndex = 36
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.GourmetVisual.My.Resources.Resources.Botao_Ret_Laranja
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(5, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(206, 70)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Enter"
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.Button11.Location = New System.Drawing.Point(141, 208)
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
        Me.Button10.Location = New System.Drawing.Point(5, 208)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(138, 70)
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
        Me.Button7.Location = New System.Drawing.Point(141, 140)
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
        Me.Button8.Location = New System.Drawing.Point(73, 140)
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
        Me.Button9.Location = New System.Drawing.Point(5, 140)
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
        Me.Button4.Location = New System.Drawing.Point(141, 72)
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
        Me.Button5.Location = New System.Drawing.Point(73, 72)
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
        Me.Button6.Location = New System.Drawing.Point(5, 72)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(70, 70)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "4"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.Blue
        Me.Button14.Location = New System.Drawing.Point(141, 4)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(70, 70)
        Me.Button14.TabIndex = 2
        Me.Button14.Text = "9"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.BackgroundImage = CType(resources.GetObject("Button15.BackgroundImage"), System.Drawing.Image)
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button15.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.ForeColor = System.Drawing.Color.Blue
        Me.Button15.Location = New System.Drawing.Point(73, 4)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(70, 70)
        Me.Button15.TabIndex = 1
        Me.Button15.Text = "8"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.Transparent
        Me.Button16.BackgroundImage = CType(resources.GetObject("Button16.BackgroundImage"), System.Drawing.Image)
        Me.Button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button16.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.ForeColor = System.Drawing.Color.Blue
        Me.Button16.Location = New System.Drawing.Point(5, 4)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(70, 70)
        Me.Button16.TabIndex = 0
        Me.Button16.Text = "7"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'TimerAguardandoSAT
        '
        Me.TimerAguardandoSAT.Interval = 500
        '
        'fdlgCpf_Cnpj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 368)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgCpf_Cnpj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressão do cupom fiscal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBoxNFCE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents tbCpfCnpj As TextBox
    Friend WithEvents lbMsgValido As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbMensagem As Label
    Friend WithEvents tbIDVendaSAT As TextBox
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents tbTotVenda As TextBox
    Friend WithEvents tbTotalAD As TextBox
    Friend WithEvents tbDiaMovto As TextBox
    Friend WithEvents tbStVenda As TextBox
    Friend WithEvents tbTxEntrega As TextBox
    Friend WithEvents tbTotCupom As TextBox
    Friend WithEvents tbIDSat As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents tbIDVendaPagto As TextBox
    Friend WithEvents TimerAguardandoSAT As Timer
    Friend WithEvents PictureBoxNFCE As PictureBox
End Class
