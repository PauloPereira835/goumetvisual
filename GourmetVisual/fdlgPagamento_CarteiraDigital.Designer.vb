<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgPagamento_CarteiraDigital
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
        Me.PanelPagtos = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.tbIDVendaPagto = New System.Windows.Forms.TextBox()
        Me.tbValor = New System.Windows.Forms.TextBox()
        Me.tbIDFormaPagto = New System.Windows.Forms.TextBox()
        Me.lbDescricaoPagto = New System.Windows.Forms.Label()
        Me.tbOrderID = New System.Windows.Forms.TextBox()
        Me.tbStatus = New System.Windows.Forms.TextBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.tbQRcode = New System.Windows.Forms.TextBox()
        Me.tbPagtoIntegral = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.pbQRCode = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelPagtos
        '
        Me.PanelPagtos.AutoScroll = True
        Me.PanelPagtos.BackColor = System.Drawing.Color.AliceBlue
        Me.PanelPagtos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPagtos.Location = New System.Drawing.Point(12, 163)
        Me.PanelPagtos.Name = "PanelPagtos"
        Me.PanelPagtos.Size = New System.Drawing.Size(795, 420)
        Me.PanelPagtos.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(753, 28)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Selecione o meio de pagamento digital"
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(94, 53)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(58, 20)
        Me.tbIDVenda.TabIndex = 44
        Me.tbIDVenda.Visible = False
        '
        'tbIDVendaPagto
        '
        Me.tbIDVendaPagto.Location = New System.Drawing.Point(157, 53)
        Me.tbIDVendaPagto.Name = "tbIDVendaPagto"
        Me.tbIDVendaPagto.Size = New System.Drawing.Size(58, 20)
        Me.tbIDVendaPagto.TabIndex = 45
        Me.tbIDVendaPagto.Visible = False
        '
        'tbValor
        '
        Me.tbValor.BackColor = System.Drawing.Color.AliceBlue
        Me.tbValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 54.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tbValor.Location = New System.Drawing.Point(94, 49)
        Me.tbValor.Multiline = True
        Me.tbValor.Name = "tbValor"
        Me.tbValor.Size = New System.Drawing.Size(614, 79)
        Me.tbValor.TabIndex = 46
        Me.tbValor.Text = "199,66"
        Me.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbIDFormaPagto
        '
        Me.tbIDFormaPagto.Location = New System.Drawing.Point(2, 79)
        Me.tbIDFormaPagto.Name = "tbIDFormaPagto"
        Me.tbIDFormaPagto.Size = New System.Drawing.Size(58, 20)
        Me.tbIDFormaPagto.TabIndex = 47
        Me.tbIDFormaPagto.Visible = False
        '
        'lbDescricaoPagto
        '
        Me.lbDescricaoPagto.BackColor = System.Drawing.Color.Transparent
        Me.lbDescricaoPagto.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescricaoPagto.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbDescricaoPagto.Location = New System.Drawing.Point(12, 130)
        Me.lbDescricaoPagto.Name = "lbDescricaoPagto"
        Me.lbDescricaoPagto.Size = New System.Drawing.Size(795, 31)
        Me.lbDescricaoPagto.TabIndex = 48
        Me.lbDescricaoPagto.Text = "PIX"
        Me.lbDescricaoPagto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbOrderID
        '
        Me.tbOrderID.Location = New System.Drawing.Point(2, 53)
        Me.tbOrderID.Name = "tbOrderID"
        Me.tbOrderID.Size = New System.Drawing.Size(58, 20)
        Me.tbOrderID.TabIndex = 49
        Me.tbOrderID.Visible = False
        '
        'tbStatus
        '
        Me.tbStatus.Location = New System.Drawing.Point(66, 79)
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Size = New System.Drawing.Size(58, 20)
        Me.tbStatus.TabIndex = 50
        Me.tbStatus.Visible = False
        '
        'Timer
        '
        Me.Timer.Interval = 3000
        '
        'lbStatus
        '
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.Orange
        Me.lbStatus.Location = New System.Drawing.Point(12, 585)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(795, 44)
        Me.lbStatus.TabIndex = 51
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbQRcode
        '
        Me.tbQRcode.Location = New System.Drawing.Point(66, 53)
        Me.tbQRcode.Name = "tbQRcode"
        Me.tbQRcode.Size = New System.Drawing.Size(58, 20)
        Me.tbQRcode.TabIndex = 52
        Me.tbQRcode.Visible = False
        '
        'tbPagtoIntegral
        '
        Me.tbPagtoIntegral.Location = New System.Drawing.Point(2, 105)
        Me.tbPagtoIntegral.Name = "tbPagtoIntegral"
        Me.tbPagtoIntegral.Size = New System.Drawing.Size(58, 20)
        Me.tbPagtoIntegral.TabIndex = 53
        Me.tbPagtoIntegral.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(950, 51)
        Me.Panel1.TabIndex = 55
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Image = Global.GourmetVisual.My.Resources.Resources.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(585, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(98, 41)
        Me.btnCancelar.TabIndex = 54
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar operação"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(716, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 41)
        Me.Button1.TabIndex = 43
        Me.Button1.TabStop = False
        Me.Button1.Text = "&Imprimir QRcode"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'btnVolta
        '
        Me.btnVolta.BackColor = System.Drawing.Color.Transparent
        Me.btnVolta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVolta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVolta.FlatAppearance.BorderSize = 0
        Me.btnVolta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVolta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolta.ForeColor = System.Drawing.Color.Black
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(3, 5)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(76, 41)
        Me.btnVolta.TabIndex = 41
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'pbQRCode
        '
        Me.pbQRCode.Location = New System.Drawing.Point(197, 163)
        Me.pbQRCode.Name = "pbQRCode"
        Me.pbQRCode.Size = New System.Drawing.Size(420, 420)
        Me.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbQRCode.TabIndex = 40
        Me.pbQRCode.TabStop = False
        '
        'fdlgPagamento_CarteiraDigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(816, 632)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelPagtos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbPagtoIntegral)
        Me.Controls.Add(Me.tbQRcode)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.tbStatus)
        Me.Controls.Add(Me.tbOrderID)
        Me.Controls.Add(Me.lbDescricaoPagto)
        Me.Controls.Add(Me.tbIDFormaPagto)
        Me.Controls.Add(Me.tbValor)
        Me.Controls.Add(Me.tbIDVendaPagto)
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.pbQRCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgPagamento_CarteiraDigital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagamento Digital"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelPagtos As FlowLayoutPanel
    Friend WithEvents pbQRCode As PictureBox
    Friend WithEvents btnVolta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents tbIDVendaPagto As TextBox
    Friend WithEvents tbValor As TextBox
    Friend WithEvents tbIDFormaPagto As TextBox
    Friend WithEvents lbDescricaoPagto As Label
    Friend WithEvents tbOrderID As TextBox
    Friend WithEvents tbStatus As TextBox
    Friend WithEvents Timer As Timer
    Friend WithEvents lbStatus As Label
    Friend WithEvents tbQRcode As TextBox
    Friend WithEvents tbPagtoIntegral As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Panel1 As Panel
End Class
