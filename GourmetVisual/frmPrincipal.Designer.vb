<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.PanelTeclado = New System.Windows.Forms.Panel()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.lblSenha = New System.Windows.Forms.TextBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lbFuncionario = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Garcon = New System.Windows.Forms.Label()
        Me.lbPainel = New System.Windows.Forms.Label()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.IDFuncionario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Funcionario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PanelFuncionarios = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbIDFuncionario = New System.Windows.Forms.Label()
        Me.lbSenhaFuncionario = New System.Windows.Forms.Label()
        Me.tbEdtUltimaSessao = New System.Windows.Forms.TextBox()
        Me.tbmmRetorno = New System.Windows.Forms.TextBox()
        Me.tbEdtUltIDAutorizado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TimerSAT = New System.Windows.Forms.Timer(Me.components)
        Me.TimerData = New System.Windows.Forms.Timer(Me.components)
        Me.lbDataHora = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbEmpresa = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbLoja = New System.Windows.Forms.Label()
        Me.tbDiaMovto = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btnGerenciadorImpressao = New System.Windows.Forms.Button()
        Me.btnSalao_Balcao = New System.Windows.Forms.Button()
        Me.pbIRIS = New System.Windows.Forms.PictureBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnDelivery = New System.Windows.Forms.Button()
        Me.btnBalcao = New System.Windows.Forms.Button()
        Me.btnSalao = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.lbChat = New System.Windows.Forms.Label()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TimerBackupCupomFiscal = New System.Windows.Forms.Timer(Me.components)
        Me.mmXML = New System.Windows.Forms.TextBox()
        Me.lbVersao = New System.Windows.Forms.Label()
        Me.btnClube = New System.Windows.Forms.Button()
        Me.PanelTeclado.SuspendLayout()
        CType(Me.pbIRIS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTeclado
        '
        Me.PanelTeclado.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelTeclado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTeclado.Controls.Add(Me.Button12)
        Me.PanelTeclado.Controls.Add(Me.lblSenha)
        Me.PanelTeclado.Controls.Add(Me.Button10)
        Me.PanelTeclado.Controls.Add(Me.btnBack)
        Me.PanelTeclado.Controls.Add(Me.lbFuncionario)
        Me.PanelTeclado.Controls.Add(Me.Button7)
        Me.PanelTeclado.Controls.Add(Me.Button8)
        Me.PanelTeclado.Controls.Add(Me.Button9)
        Me.PanelTeclado.Controls.Add(Me.Button4)
        Me.PanelTeclado.Controls.Add(Me.Button5)
        Me.PanelTeclado.Controls.Add(Me.Button6)
        Me.PanelTeclado.Controls.Add(Me.btnConfirma)
        Me.PanelTeclado.Controls.Add(Me.Button3)
        Me.PanelTeclado.Controls.Add(Me.Button2)
        Me.PanelTeclado.Controls.Add(Me.Button1)
        Me.PanelTeclado.Location = New System.Drawing.Point(351, 129)
        Me.PanelTeclado.Name = "PanelTeclado"
        Me.PanelTeclado.Size = New System.Drawing.Size(234, 549)
        Me.PanelTeclado.TabIndex = 0
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button12.Location = New System.Drawing.Point(150, 284)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(70, 70)
        Me.Button12.TabIndex = 29
        Me.Button12.TabStop = False
        Me.Button12.Text = "Limpa"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'lblSenha
        '
        Me.lblSenha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSenha.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSenha.Location = New System.Drawing.Point(10, 359)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(210, 37)
        Me.lblSenha.TabIndex = 27
        Me.lblSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lblSenha.UseSystemPasswordChar = True
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.BackgroundImage = CType(resources.GetObject("Button10.BackgroundImage"), System.Drawing.Image)
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button10.Location = New System.Drawing.Point(80, 283)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(70, 70)
        Me.Button10.TabIndex = 9
        Me.Button10.TabStop = False
        Me.Button10.Text = "0"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.White
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(10, 283)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(70, 70)
        Me.btnBack.TabIndex = 11
        Me.btnBack.TabStop = False
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'lbFuncionario
        '
        Me.lbFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFuncionario.ForeColor = System.Drawing.Color.Maroon
        Me.lbFuncionario.Location = New System.Drawing.Point(2, 29)
        Me.lbFuncionario.Name = "lbFuncionario"
        Me.lbFuncionario.Size = New System.Drawing.Size(225, 53)
        Me.lbFuncionario.TabIndex = 28
        Me.lbFuncionario.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.Location = New System.Drawing.Point(150, 216)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(70, 70)
        Me.Button7.TabIndex = 8
        Me.Button7.TabStop = False
        Me.Button7.Text = "3"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"), System.Drawing.Image)
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button8.Location = New System.Drawing.Point(80, 216)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(70, 70)
        Me.Button8.TabIndex = 7
        Me.Button8.TabStop = False
        Me.Button8.Text = "2"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button9.Location = New System.Drawing.Point(10, 216)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(70, 70)
        Me.Button9.TabIndex = 6
        Me.Button9.TabStop = False
        Me.Button9.Text = "1"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(150, 150)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(70, 70)
        Me.Button4.TabIndex = 5
        Me.Button4.TabStop = False
        Me.Button4.Text = "6"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(80, 150)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(70, 70)
        Me.Button5.TabIndex = 4
        Me.Button5.TabStop = False
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button6.Location = New System.Drawing.Point(10, 150)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(70, 70)
        Me.Button6.TabIndex = 3
        Me.Button6.TabStop = False
        Me.Button6.Text = "4"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConfirma.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Blue
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok1
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(10, 449)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(210, 89)
        Me.btnConfirma.TabIndex = 11
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(150, 84)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 70)
        Me.Button3.TabIndex = 2
        Me.Button3.TabStop = False
        Me.Button3.Text = "9"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(80, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 70)
        Me.Button2.TabIndex = 1
        Me.Button2.TabStop = False
        Me.Button2.Text = "8"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(10, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 70)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "7"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Garcon
        '
        Me.Garcon.AutoSize = True
        Me.Garcon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Garcon.ForeColor = System.Drawing.Color.Blue
        Me.Garcon.Location = New System.Drawing.Point(14, 561)
        Me.Garcon.Name = "Garcon"
        Me.Garcon.Size = New System.Drawing.Size(0, 24)
        Me.Garcon.TabIndex = 16
        Me.Garcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPainel
        '
        Me.lbPainel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPainel.ForeColor = System.Drawing.Color.Navy
        Me.lbPainel.Location = New System.Drawing.Point(138, 81)
        Me.lbPainel.Name = "lbPainel"
        Me.lbPainel.Size = New System.Drawing.Size(434, 22)
        Me.lbPainel.TabIndex = 18
        Me.lbPainel.Text = "Selecione um operador e digite a senha"
        Me.lbPainel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(270, 33)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(122, 27)
        Me.Button14.TabIndex = 0
        Me.Button14.Text = "Button14"
        Me.Button14.UseVisualStyleBackColor = True
        Me.Button14.Visible = False
        '
        'IDFuncionario
        '
        Me.IDFuncionario.Text = "IDFuncionario"
        Me.IDFuncionario.Width = 0
        '
        'Funcionario
        '
        Me.Funcionario.Text = "Funcionário"
        Me.Funcionario.Width = 300
        '
        'PanelFuncionarios
        '
        Me.PanelFuncionarios.BackColor = System.Drawing.Color.Silver
        Me.PanelFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelFuncionarios.Location = New System.Drawing.Point(9, 129)
        Me.PanelFuncionarios.Name = "PanelFuncionarios"
        Me.PanelFuncionarios.Size = New System.Drawing.Size(336, 549)
        Me.PanelFuncionarios.TabIndex = 27
        '
        'lbIDFuncionario
        '
        Me.lbIDFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIDFuncionario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbIDFuncionario.Location = New System.Drawing.Point(149, 63)
        Me.lbIDFuncionario.Name = "lbIDFuncionario"
        Me.lbIDFuncionario.Size = New System.Drawing.Size(66, 10)
        Me.lbIDFuncionario.TabIndex = 29
        Me.lbIDFuncionario.Visible = False
        '
        'lbSenhaFuncionario
        '
        Me.lbSenhaFuncionario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSenhaFuncionario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbSenhaFuncionario.Location = New System.Drawing.Point(371, 52)
        Me.lbSenhaFuncionario.Name = "lbSenhaFuncionario"
        Me.lbSenhaFuncionario.Size = New System.Drawing.Size(44, 34)
        Me.lbSenhaFuncionario.TabIndex = 30
        Me.lbSenhaFuncionario.Visible = False
        '
        'tbEdtUltimaSessao
        '
        Me.tbEdtUltimaSessao.Location = New System.Drawing.Point(153, 11)
        Me.tbEdtUltimaSessao.Name = "tbEdtUltimaSessao"
        Me.tbEdtUltimaSessao.Size = New System.Drawing.Size(97, 20)
        Me.tbEdtUltimaSessao.TabIndex = 33
        Me.tbEdtUltimaSessao.Visible = False
        '
        'tbmmRetorno
        '
        Me.tbmmRetorno.Location = New System.Drawing.Point(353, 11)
        Me.tbmmRetorno.Name = "tbmmRetorno"
        Me.tbmmRetorno.Size = New System.Drawing.Size(97, 20)
        Me.tbmmRetorno.TabIndex = 34
        Me.tbmmRetorno.Visible = False
        '
        'tbEdtUltIDAutorizado
        '
        Me.tbEdtUltIDAutorizado.Location = New System.Drawing.Point(253, 11)
        Me.tbEdtUltIDAutorizado.Name = "tbEdtUltIDAutorizado"
        Me.tbEdtUltIDAutorizado.Size = New System.Drawing.Size(97, 20)
        Me.tbEdtUltIDAutorizado.TabIndex = 35
        Me.tbEdtUltIDAutorizado.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(-2, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 25)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Todos direitos reservados para IRIS Tecnologia  1997 - 2024"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TimerSAT
        '
        Me.TimerSAT.Interval = 1000
        '
        'TimerData
        '
        Me.TimerData.Interval = 1000
        '
        'lbDataHora
        '
        Me.lbDataHora.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDataHora.ForeColor = System.Drawing.Color.Green
        Me.lbDataHora.Location = New System.Drawing.Point(134, 62)
        Me.lbDataHora.Name = "lbDataHora"
        Me.lbDataHora.Size = New System.Drawing.Size(443, 18)
        Me.lbDataHora.TabIndex = 40
        Me.lbDataHora.Text = "Selecione um operador e digite a senha"
        Me.lbDataHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label1.Location = New System.Drawing.Point(8, 680)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Este software esta licenciado para uso exclusivo da empresa:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbEmpresa
        '
        Me.lbEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEmpresa.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbEmpresa.Location = New System.Drawing.Point(265, 680)
        Me.lbEmpresa.Name = "lbEmpresa"
        Me.lbEmpresa.Size = New System.Drawing.Size(251, 13)
        Me.lbEmpresa.TabIndex = 42
        Me.lbEmpresa.Text = "JHGJHGJHGJHKGJHG"
        Me.lbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label2.Location = New System.Drawing.Point(520, 680)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Loja:"
        '
        'lbLoja
        '
        Me.lbLoja.BackColor = System.Drawing.Color.Transparent
        Me.lbLoja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLoja.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbLoja.Location = New System.Drawing.Point(544, 680)
        Me.lbLoja.Name = "lbLoja"
        Me.lbLoja.Size = New System.Drawing.Size(199, 13)
        Me.lbLoja.TabIndex = 44
        Me.lbLoja.Text = "JHGJHGJHGJHKGJHG"
        Me.lbLoja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbDiaMovto
        '
        Me.tbDiaMovto.Location = New System.Drawing.Point(453, 11)
        Me.tbDiaMovto.Name = "tbDiaMovto"
        Me.tbDiaMovto.Size = New System.Drawing.Size(97, 20)
        Me.tbDiaMovto.TabIndex = 45
        Me.tbDiaMovto.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Yellow
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 107)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel1.TabIndex = 46
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Atualizações"
        '
        'btnGerenciadorImpressao
        '
        Me.btnGerenciadorImpressao.BackColor = System.Drawing.Color.White
        Me.btnGerenciadorImpressao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGerenciadorImpressao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGerenciadorImpressao.FlatAppearance.BorderSize = 0
        Me.btnGerenciadorImpressao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGerenciadorImpressao.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGerenciadorImpressao.ForeColor = System.Drawing.Color.Blue
        Me.btnGerenciadorImpressao.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnGerenciadorImpressao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGerenciadorImpressao.Location = New System.Drawing.Point(592, 487)
        Me.btnGerenciadorImpressao.Name = "btnGerenciadorImpressao"
        Me.btnGerenciadorImpressao.Size = New System.Drawing.Size(149, 44)
        Me.btnGerenciadorImpressao.TabIndex = 39
        Me.btnGerenciadorImpressao.TabStop = False
        Me.btnGerenciadorImpressao.Text = "Gerenciador de Impressão"
        Me.btnGerenciadorImpressao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGerenciadorImpressao.UseVisualStyleBackColor = False
        Me.btnGerenciadorImpressao.Visible = False
        '
        'btnSalao_Balcao
        '
        Me.btnSalao_Balcao.BackColor = System.Drawing.Color.White
        Me.btnSalao_Balcao.BackgroundImage = CType(resources.GetObject("btnSalao_Balcao.BackgroundImage"), System.Drawing.Image)
        Me.btnSalao_Balcao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalao_Balcao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSalao_Balcao.FlatAppearance.BorderSize = 0
        Me.btnSalao_Balcao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalao_Balcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalao_Balcao.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalao_Balcao.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnSalao_Balcao.Location = New System.Drawing.Point(591, 116)
        Me.btnSalao_Balcao.Name = "btnSalao_Balcao"
        Me.btnSalao_Balcao.Size = New System.Drawing.Size(150, 145)
        Me.btnSalao_Balcao.TabIndex = 38
        Me.btnSalao_Balcao.TabStop = False
        Me.btnSalao_Balcao.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalao_Balcao.UseVisualStyleBackColor = False
        Me.btnSalao_Balcao.Visible = False
        '
        'pbIRIS
        '
        Me.pbIRIS.Image = Global.GourmetVisual.My.Resources.Resources.Logo_IRIS_menu
        Me.pbIRIS.Location = New System.Drawing.Point(601, 11)
        Me.pbIRIS.Name = "pbIRIS"
        Me.pbIRIS.Size = New System.Drawing.Size(68, 82)
        Me.pbIRIS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIRIS.TabIndex = 36
        Me.pbIRIS.TabStop = False
        Me.pbIRIS.Visible = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.Blue
        Me.Button11.Image = Global.GourmetVisual.My.Resources.Resources.Currency_Dollar
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(591, 585)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(150, 43)
        Me.Button11.TabIndex = 32
        Me.Button11.TabStop = False
        Me.Button11.Text = "Caixa"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.GourmetVisual.My.Resources.Resources.Logo_Gourmet_menu_menor
        Me.PictureBox1.Location = New System.Drawing.Point(3, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(130, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'btnDelivery
        '
        Me.btnDelivery.BackColor = System.Drawing.Color.White
        Me.btnDelivery.BackgroundImage = CType(resources.GetObject("btnDelivery.BackgroundImage"), System.Drawing.Image)
        Me.btnDelivery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelivery.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelivery.FlatAppearance.BorderSize = 0
        Me.btnDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelivery.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelivery.ForeColor = System.Drawing.Color.Maroon
        Me.btnDelivery.Location = New System.Drawing.Point(591, 268)
        Me.btnDelivery.Name = "btnDelivery"
        Me.btnDelivery.Size = New System.Drawing.Size(150, 145)
        Me.btnDelivery.TabIndex = 25
        Me.btnDelivery.TabStop = False
        Me.btnDelivery.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelivery.UseVisualStyleBackColor = False
        Me.btnDelivery.Visible = False
        '
        'btnBalcao
        '
        Me.btnBalcao.BackColor = System.Drawing.Color.White
        Me.btnBalcao.BackgroundImage = CType(resources.GetObject("btnBalcao.BackgroundImage"), System.Drawing.Image)
        Me.btnBalcao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBalcao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBalcao.FlatAppearance.BorderSize = 0
        Me.btnBalcao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBalcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBalcao.ForeColor = System.Drawing.Color.Maroon
        Me.btnBalcao.Location = New System.Drawing.Point(591, 116)
        Me.btnBalcao.Name = "btnBalcao"
        Me.btnBalcao.Size = New System.Drawing.Size(150, 145)
        Me.btnBalcao.TabIndex = 24
        Me.btnBalcao.TabStop = False
        Me.btnBalcao.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnBalcao.UseVisualStyleBackColor = False
        Me.btnBalcao.Visible = False
        '
        'btnSalao
        '
        Me.btnSalao.BackColor = System.Drawing.Color.White
        Me.btnSalao.BackgroundImage = CType(resources.GetObject("btnSalao.BackgroundImage"), System.Drawing.Image)
        Me.btnSalao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSalao.FlatAppearance.BorderSize = 0
        Me.btnSalao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalao.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalao.ForeColor = System.Drawing.Color.Maroon
        Me.btnSalao.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnSalao.Location = New System.Drawing.Point(591, 114)
        Me.btnSalao.Name = "btnSalao"
        Me.btnSalao.Size = New System.Drawing.Size(150, 145)
        Me.btnSalao.TabIndex = 23
        Me.btnSalao.TabStop = False
        Me.btnSalao.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalao.UseVisualStyleBackColor = False
        Me.btnSalao.Visible = False
        '
        'btnSair
        '
        Me.btnSair.BackColor = System.Drawing.Color.White
        Me.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSair.FlatAppearance.BorderSize = 0
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSair.ForeColor = System.Drawing.Color.Maroon
        Me.btnSair.Image = Global.GourmetVisual.My.Resources.Resources.Standby
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSair.Location = New System.Drawing.Point(591, 633)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(150, 43)
        Me.btnSair.TabIndex = 21
        Me.btnSair.TabStop = False
        Me.btnSair.Text = "Sair/Finalizar"
        Me.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSair.UseVisualStyleBackColor = False
        '
        'btnConfig
        '
        Me.btnConfig.BackColor = System.Drawing.Color.White
        Me.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnConfig.FlatAppearance.BorderSize = 0
        Me.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfig.ForeColor = System.Drawing.Color.Blue
        Me.btnConfig.Image = Global.GourmetVisual.My.Resources.Resources.Tool
        Me.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfig.Location = New System.Drawing.Point(591, 536)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(150, 44)
        Me.btnConfig.TabIndex = 19
        Me.btnConfig.TabStop = False
        Me.btnConfig.Text = "Configuração"
        Me.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfig.UseVisualStyleBackColor = False
        Me.btnConfig.Visible = False
        '
        'lbChat
        '
        Me.lbChat.Location = New System.Drawing.Point(735, -8)
        Me.lbChat.Name = "lbChat"
        Me.lbChat.Size = New System.Drawing.Size(100, 23)
        Me.lbChat.TabIndex = 47
        '
        'btnMinimizar
        '
        Me.btnMinimizar.FlatAppearance.BorderSize = 0
        Me.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimizar.Image = CType(resources.GetObject("btnMinimizar.Image"), System.Drawing.Image)
        Me.btnMinimizar.Location = New System.Drawing.Point(719, 11)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(18, 18)
        Me.btnMinimizar.TabIndex = 90
        Me.btnMinimizar.UseVisualStyleBackColor = True
        Me.btnMinimizar.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(131, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 12)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "©"
        '
        'TimerBackupCupomFiscal
        '
        Me.TimerBackupCupomFiscal.Interval = 30000
        '
        'mmXML
        '
        Me.mmXML.Location = New System.Drawing.Point(153, 33)
        Me.mmXML.Name = "mmXML"
        Me.mmXML.Size = New System.Drawing.Size(97, 20)
        Me.mmXML.TabIndex = 92
        Me.mmXML.Visible = False
        '
        'lbVersao
        '
        Me.lbVersao.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersao.ForeColor = System.Drawing.Color.Navy
        Me.lbVersao.Location = New System.Drawing.Point(76, 108)
        Me.lbVersao.Name = "lbVersao"
        Me.lbVersao.Size = New System.Drawing.Size(57, 13)
        Me.lbVersao.TabIndex = 93
        Me.lbVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClube
        '
        Me.btnClube.BackColor = System.Drawing.Color.White
        Me.btnClube.BackgroundImage = CType(resources.GetObject("btnClube.BackgroundImage"), System.Drawing.Image)
        Me.btnClube.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClube.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClube.FlatAppearance.BorderSize = 0
        Me.btnClube.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClube.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClube.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClube.Location = New System.Drawing.Point(591, 206)
        Me.btnClube.Name = "btnClube"
        Me.btnClube.Size = New System.Drawing.Size(150, 145)
        Me.btnClube.TabIndex = 94
        Me.btnClube.TabStop = False
        Me.btnClube.Text = "Clube"
        Me.btnClube.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClube.UseVisualStyleBackColor = False
        Me.btnClube.Visible = False
        '
        'frmPrincipal
        '
        Me.AcceptButton = Me.btnConfirma
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(747, 696)
        Me.Controls.Add(Me.btnClube)
        Me.Controls.Add(Me.lbVersao)
        Me.Controls.Add(Me.mmXML)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnMinimizar)
        Me.Controls.Add(Me.lbChat)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.tbDiaMovto)
        Me.Controls.Add(Me.lbLoja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbEmpresa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbDataHora)
        Me.Controls.Add(Me.btnGerenciadorImpressao)
        Me.Controls.Add(Me.btnSalao_Balcao)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pbIRIS)
        Me.Controls.Add(Me.tbEdtUltIDAutorizado)
        Me.Controls.Add(Me.tbmmRetorno)
        Me.Controls.Add(Me.tbEdtUltimaSessao)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.lbSenhaFuncionario)
        Me.Controls.Add(Me.lbIDFuncionario)
        Me.Controls.Add(Me.PanelFuncionarios)
        Me.Controls.Add(Me.btnDelivery)
        Me.Controls.Add(Me.btnBalcao)
        Me.Controls.Add(Me.btnSalao)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.lbPainel)
        Me.Controls.Add(Me.Garcon)
        Me.Controls.Add(Me.PanelTeclado)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmPrincipal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gourmet Visual"
        Me.PanelTeclado.ResumeLayout(False)
        Me.PanelTeclado.PerformLayout()
        CType(Me.pbIRIS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelTeclado As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnConfirma As System.Windows.Forms.Button
    Friend WithEvents Garcon As System.Windows.Forms.Label
    Friend WithEvents lbPainel As System.Windows.Forms.Label
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnSair As Button
    Friend WithEvents IDFuncionario As ColumnHeader
    Friend WithEvents Funcionario As ColumnHeader
    Friend WithEvents btnSalao As Button
    Friend WithEvents btnBalcao As Button
    Friend WithEvents btnDelivery As Button
    Friend WithEvents lblSenha As TextBox
    Friend WithEvents PanelFuncionarios As FlowLayoutPanel
    Friend WithEvents lbFuncionario As Label
    Friend WithEvents lbIDFuncionario As Label
    Friend WithEvents lbSenhaFuncionario As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button11 As Button
    Friend WithEvents tbEdtUltimaSessao As TextBox
    Friend WithEvents tbmmRetorno As TextBox
    Friend WithEvents tbEdtUltIDAutorizado As TextBox
    Friend WithEvents pbIRIS As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSalao_Balcao As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents TimerSAT As Timer
    Friend WithEvents btnGerenciadorImpressao As Button
    Friend WithEvents TimerData As Timer
    Friend WithEvents lbDataHora As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbEmpresa As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbLoja As Label
    Friend WithEvents tbDiaMovto As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents lbChat As Label
    Friend WithEvents btnMinimizar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TimerBackupCupomFiscal As Timer
    Friend WithEvents mmXML As TextBox
    Friend WithEvents lbVersao As Label
    Friend WithEvents btnClube As Button
End Class
