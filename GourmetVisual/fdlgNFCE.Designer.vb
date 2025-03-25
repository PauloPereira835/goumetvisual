<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgNFCE
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
        Me.btnGrava = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCertificado = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbCepNFCE = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbInscricaoEstadual = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbNumeroPais = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbPais = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbNumeroCidade = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbCidade = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbBairroNFCE = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbComplemento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbNumero = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbEndereco = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbFantasia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbCNPJ = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbEstado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbVersao = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnGrava)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 54)
        Me.Panel1.TabIndex = 35
        '
        'btnGrava
        '
        Me.btnGrava.BackColor = System.Drawing.Color.White
        Me.btnGrava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGrava.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGrava.FlatAppearance.BorderSize = 0
        Me.btnGrava.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrava.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrava.ForeColor = System.Drawing.Color.Black
        Me.btnGrava.Image = Global.GourmetVisual.My.Resources.Resources.Save1
        Me.btnGrava.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrava.Location = New System.Drawing.Point(447, 7)
        Me.btnGrava.Name = "btnGrava"
        Me.btnGrava.Size = New System.Drawing.Size(90, 41)
        Me.btnGrava.TabIndex = 2
        Me.btnGrava.TabStop = False
        Me.btnGrava.Text = "Grava"
        Me.btnGrava.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrava.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGrava.UseVisualStyleBackColor = False
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
        Me.btnVolta.Location = New System.Drawing.Point(6, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(90, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Certificado"
        '
        'cbCertificado
        '
        Me.cbCertificado.FormattingEnabled = True
        Me.cbCertificado.Location = New System.Drawing.Point(64, 64)
        Me.cbCertificado.Name = "cbCertificado"
        Me.cbCertificado.Size = New System.Drawing.Size(470, 21)
        Me.cbCertificado.TabIndex = 37
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.tbVersao)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.tbCepNFCE)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.tbInscricaoEstadual)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.tbNumeroPais)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.tbPais)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.tbNumeroCidade)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.tbCidade)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.tbBairroNFCE)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.tbComplemento)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.tbNumero)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.tbEndereco)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.tbFantasia)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tbNome)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.tbCNPJ)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbEstado)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(28, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(480, 212)
        Me.Panel2.TabIndex = 38
        '
        'tbCepNFCE
        '
        Me.tbCepNFCE.Location = New System.Drawing.Point(407, 28)
        Me.tbCepNFCE.Name = "tbCepNFCE"
        Me.tbCepNFCE.Size = New System.Drawing.Size(66, 20)
        Me.tbCepNFCE.TabIndex = 64
        Me.tbCepNFCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(379, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 16)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "CEP"
        '
        'tbInscricaoEstadual
        '
        Me.tbInscricaoEstadual.Location = New System.Drawing.Point(294, 159)
        Me.tbInscricaoEstadual.Name = "tbInscricaoEstadual"
        Me.tbInscricaoEstadual.Size = New System.Drawing.Size(179, 20)
        Me.tbInscricaoEstadual.TabIndex = 62
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(274, 162)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 16)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "IE"
        '
        'tbNumeroPais
        '
        Me.tbNumeroPais.Location = New System.Drawing.Point(314, 133)
        Me.tbNumeroPais.Name = "tbNumeroPais"
        Me.tbNumeroPais.Size = New System.Drawing.Size(81, 20)
        Me.tbNumeroPais.TabIndex = 60
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(270, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 16)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "Código"
        '
        'tbPais
        '
        Me.tbPais.Location = New System.Drawing.Point(78, 133)
        Me.tbPais.Name = "tbPais"
        Me.tbPais.Size = New System.Drawing.Size(179, 20)
        Me.tbPais.TabIndex = 58
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(2, 136)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 16)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "País"
        '
        'tbNumeroCidade
        '
        Me.tbNumeroCidade.Location = New System.Drawing.Point(392, 106)
        Me.tbNumeroCidade.Name = "tbNumeroCidade"
        Me.tbNumeroCidade.Size = New System.Drawing.Size(81, 20)
        Me.tbNumeroCidade.TabIndex = 56
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(348, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 16)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Código"
        '
        'tbCidade
        '
        Me.tbCidade.Location = New System.Drawing.Point(78, 107)
        Me.tbCidade.Name = "tbCidade"
        Me.tbCidade.Size = New System.Drawing.Size(179, 20)
        Me.tbCidade.TabIndex = 54
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(2, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 16)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Cidade"
        '
        'tbBairroNFCE
        '
        Me.tbBairroNFCE.Location = New System.Drawing.Point(314, 80)
        Me.tbBairroNFCE.Name = "tbBairroNFCE"
        Me.tbBairroNFCE.Size = New System.Drawing.Size(159, 20)
        Me.tbBairroNFCE.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(271, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Bairro"
        '
        'tbComplemento
        '
        Me.tbComplemento.Location = New System.Drawing.Point(78, 81)
        Me.tbComplemento.Name = "tbComplemento"
        Me.tbComplemento.Size = New System.Drawing.Size(179, 20)
        Me.tbComplemento.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(2, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Complemento"
        '
        'tbNumero
        '
        Me.tbNumero.Location = New System.Drawing.Point(424, 55)
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Size = New System.Drawing.Size(49, 20)
        Me.tbNumero.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(379, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 16)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Numero"
        '
        'tbEndereco
        '
        Me.tbEndereco.Location = New System.Drawing.Point(78, 55)
        Me.tbEndereco.Name = "tbEndereco"
        Me.tbEndereco.Size = New System.Drawing.Size(297, 20)
        Me.tbEndereco.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(2, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Endereço"
        '
        'tbFantasia
        '
        Me.tbFantasia.Location = New System.Drawing.Point(78, 29)
        Me.tbFantasia.Name = "tbFantasia"
        Me.tbFantasia.Size = New System.Drawing.Size(297, 20)
        Me.tbFantasia.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(2, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Fantasia"
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(78, 3)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(395, 20)
        Me.tbNome.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(2, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Nome"
        '
        'tbCNPJ
        '
        Me.tbCNPJ.Location = New System.Drawing.Point(78, 159)
        Me.tbCNPJ.Name = "tbCNPJ"
        Me.tbCNPJ.Size = New System.Drawing.Size(179, 20)
        Me.tbCNPJ.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "CNPJ"
        '
        'tbEstado
        '
        Me.tbEstado.Location = New System.Drawing.Point(314, 106)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.Size = New System.Drawing.Size(22, 20)
        Me.tbEstado.TabIndex = 38
        Me.tbEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(271, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Estado"
        '
        'tbVersao
        '
        Me.tbVersao.Location = New System.Drawing.Point(78, 185)
        Me.tbVersao.Name = "tbVersao"
        Me.tbVersao.Size = New System.Drawing.Size(81, 20)
        Me.tbVersao.TabIndex = 66
        Me.tbVersao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(6, 189)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "Versão"
        '
        'fdlgNFCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(542, 326)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cbCertificado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgNFCE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NFCE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCertificado As ComboBox
    Friend WithEvents btnGrava As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbCNPJ As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbEstado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbInscricaoEstadual As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents tbNumeroPais As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tbPais As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tbNumeroCidade As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tbCidade As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents tbBairroNFCE As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbComplemento As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbNumero As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbEndereco As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbFantasia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbNome As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbCepNFCE As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents tbVersao As TextBox
    Friend WithEvents Label16 As Label
End Class
