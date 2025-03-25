<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClube
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClube))
        Me.PainelProdutos = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbTerminal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbData_Hora = New System.Windows.Forms.Label()
        Me.lbDataMovimento = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lbCaixa = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbOparedor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.btnAgrupamento = New System.Windows.Forms.Button()
        Me.btnAbreVenda = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'PainelProdutos
        '
        Me.PainelProdutos.AutoScroll = True
        Me.PainelProdutos.BackColor = System.Drawing.Color.White
        Me.PainelProdutos.Location = New System.Drawing.Point(4, 69)
        Me.PainelProdutos.Name = "PainelProdutos"
        Me.PainelProdutos.Size = New System.Drawing.Size(1016, 670)
        Me.PainelProdutos.TabIndex = 3
        '
        'tbBusca
        '
        Me.tbBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBusca.Location = New System.Drawing.Point(219, 19)
        Me.tbBusca.Multiline = True
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(315, 32)
        Me.tbBusca.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(98, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Busca cliente"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Silver
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.lbTerminal)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.lbData_Hora)
        Me.Panel6.Controls.Add(Me.lbDataMovimento)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.lbCaixa)
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Controls.Add(Me.lbOparedor)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Location = New System.Drawing.Point(5, 738)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1014, 26)
        Me.Panel6.TabIndex = 67
        '
        'lbTerminal
        '
        Me.lbTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTerminal.ForeColor = System.Drawing.Color.DimGray
        Me.lbTerminal.Location = New System.Drawing.Point(465, 1)
        Me.lbTerminal.Name = "lbTerminal"
        Me.lbTerminal.Size = New System.Drawing.Size(133, 20)
        Me.lbTerminal.TabIndex = 41
        Me.lbTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(406, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 16)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Terminal"
        '
        'lbData_Hora
        '
        Me.lbData_Hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbData_Hora.ForeColor = System.Drawing.Color.Maroon
        Me.lbData_Hora.Location = New System.Drawing.Point(864, 2)
        Me.lbData_Hora.Name = "lbData_Hora"
        Me.lbData_Hora.Size = New System.Drawing.Size(146, 18)
        Me.lbData_Hora.TabIndex = 40
        Me.lbData_Hora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbDataMovimento
        '
        Me.lbDataMovimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDataMovimento.ForeColor = System.Drawing.Color.DimGray
        Me.lbDataMovimento.Location = New System.Drawing.Point(703, 1)
        Me.lbDataMovimento.Name = "lbDataMovimento"
        Me.lbDataMovimento.Size = New System.Drawing.Size(157, 20)
        Me.lbDataMovimento.TabIndex = 38
        Me.lbDataMovimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(603, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 16)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Data Movimento"
        '
        'lbCaixa
        '
        Me.lbCaixa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaixa.ForeColor = System.Drawing.Color.DimGray
        Me.lbCaixa.Location = New System.Drawing.Point(256, 2)
        Me.lbCaixa.Name = "lbCaixa"
        Me.lbCaixa.Size = New System.Drawing.Size(145, 20)
        Me.lbCaixa.TabIndex = 36
        Me.lbCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(218, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 16)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Caixa"
        '
        'lbOparedor
        '
        Me.lbOparedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOparedor.ForeColor = System.Drawing.Color.DimGray
        Me.lbOparedor.Location = New System.Drawing.Point(66, 2)
        Me.lbOparedor.Name = "lbOparedor"
        Me.lbOparedor.Size = New System.Drawing.Size(146, 20)
        Me.lbOparedor.TabIndex = 33
        Me.lbOparedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Operador"
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 60000
        '
        'btnAgrupamento
        '
        Me.btnAgrupamento.BackColor = System.Drawing.Color.White
        Me.btnAgrupamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAgrupamento.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnAgrupamento.FlatAppearance.BorderSize = 0
        Me.btnAgrupamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgrupamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgrupamento.ForeColor = System.Drawing.Color.Blue
        Me.btnAgrupamento.Image = CType(resources.GetObject("btnAgrupamento.Image"), System.Drawing.Image)
        Me.btnAgrupamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgrupamento.Location = New System.Drawing.Point(643, 5)
        Me.btnAgrupamento.Name = "btnAgrupamento"
        Me.btnAgrupamento.Size = New System.Drawing.Size(182, 59)
        Me.btnAgrupamento.TabIndex = 68
        Me.btnAgrupamento.TabStop = False
        Me.btnAgrupamento.Text = "Agrupamento"
        Me.btnAgrupamento.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAgrupamento.UseVisualStyleBackColor = False
        '
        'btnAbreVenda
        '
        Me.btnAbreVenda.BackColor = System.Drawing.Color.White
        Me.btnAbreVenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAbreVenda.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnAbreVenda.FlatAppearance.BorderSize = 0
        Me.btnAbreVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbreVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbreVenda.ForeColor = System.Drawing.Color.Blue
        Me.btnAbreVenda.Image = CType(resources.GetObject("btnAbreVenda.Image"), System.Drawing.Image)
        Me.btnAbreVenda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAbreVenda.Location = New System.Drawing.Point(832, 5)
        Me.btnAbreVenda.Name = "btnAbreVenda"
        Me.btnAbreVenda.Size = New System.Drawing.Size(182, 59)
        Me.btnAbreVenda.TabIndex = 7
        Me.btnAbreVenda.TabStop = False
        Me.btnAbreVenda.Text = "Abre Venda"
        Me.btnAbreVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAbreVenda.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnVoltar.FlatAppearance.BorderSize = 0
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVoltar.Location = New System.Drawing.Point(6, 5)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(80, 59)
        Me.btnVoltar.TabIndex = 4
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Sair"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'frmClube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAgrupamento)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.btnAbreVenda)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.PainelProdutos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmClube"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmClube"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PainelProdutos As FlowLayoutPanel
    Friend WithEvents btnVoltar As Button
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAbreVenda As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lbTerminal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbData_Hora As Label
    Friend WithEvents lbDataMovimento As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lbCaixa As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbOparedor As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer As Timer
    Friend WithEvents btnAgrupamento As Button
End Class
