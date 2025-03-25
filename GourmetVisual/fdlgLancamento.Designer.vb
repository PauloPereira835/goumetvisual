<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgLancamento
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
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbComposicao = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbComentarios = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbAtendente = New System.Windows.Forms.Label()
        Me.lbHoraPedido = New System.Windows.Forms.Label()
        Me.lbCategoria = New System.Windows.Forms.Label()
        Me.lbTerminal = New System.Windows.Forms.Label()
        Me.lbComanda = New System.Windows.Forms.Label()
        Me.lbMotivo = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.tbIDVendaMovto = New System.Windows.Forms.TextBox()
        Me.lbMesaCartao = New System.Windows.Forms.Label()
        Me.lbMesaDestino = New System.Windows.Forms.Label()
        Me.lbProduto = New GourmetVisual.SombraLabel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(6, 10)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(119, 44)
        Me.btnVoltar.TabIndex = 55
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 19)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Atendente:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label2.Location = New System.Drawing.Point(12, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 19)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Hora pedido:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label3.Location = New System.Drawing.Point(12, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Terminal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label4.Location = New System.Drawing.Point(12, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 19)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Categoria:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label5.Location = New System.Drawing.Point(12, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 19)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Comanda:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label6.Location = New System.Drawing.Point(309, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 19)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Motivo:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.PeachPuff
        Me.Label7.Location = New System.Drawing.Point(309, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 19)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Status:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tbComposicao)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(6, 178)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(290, 260)
        Me.Panel1.TabIndex = 64
        '
        'tbComposicao
        '
        Me.tbComposicao.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbComposicao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbComposicao.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComposicao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComposicao.Location = New System.Drawing.Point(7, 22)
        Me.tbComposicao.Multiline = True
        Me.tbComposicao.Name = "tbComposicao"
        Me.tbComposicao.Size = New System.Drawing.Size(276, 231)
        Me.tbComposicao.TabIndex = 63
        Me.tbComposicao.TabStop = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label8.Location = New System.Drawing.Point(1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 19)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Composição"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.tbComentarios)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(304, 178)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(290, 260)
        Me.Panel2.TabIndex = 65
        '
        'tbComentarios
        '
        Me.tbComentarios.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbComentarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbComentarios.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbComentarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComentarios.Location = New System.Drawing.Point(5, 22)
        Me.tbComentarios.Multiline = True
        Me.tbComentarios.Name = "tbComentarios"
        Me.tbComentarios.Size = New System.Drawing.Size(276, 231)
        Me.tbComentarios.TabIndex = 64
        Me.tbComentarios.TabStop = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label9.Location = New System.Drawing.Point(2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 19)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Comentários"
        '
        'lbAtendente
        '
        Me.lbAtendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAtendente.ForeColor = System.Drawing.Color.SeaShell
        Me.lbAtendente.Location = New System.Drawing.Point(101, 68)
        Me.lbAtendente.Name = "lbAtendente"
        Me.lbAtendente.Size = New System.Drawing.Size(201, 19)
        Me.lbAtendente.TabIndex = 66
        Me.lbAtendente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbHoraPedido
        '
        Me.lbHoraPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHoraPedido.ForeColor = System.Drawing.Color.SeaShell
        Me.lbHoraPedido.Location = New System.Drawing.Point(101, 90)
        Me.lbHoraPedido.Name = "lbHoraPedido"
        Me.lbHoraPedido.Size = New System.Drawing.Size(201, 19)
        Me.lbHoraPedido.TabIndex = 67
        Me.lbHoraPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCategoria
        '
        Me.lbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCategoria.ForeColor = System.Drawing.Color.SeaShell
        Me.lbCategoria.Location = New System.Drawing.Point(101, 134)
        Me.lbCategoria.Name = "lbCategoria"
        Me.lbCategoria.Size = New System.Drawing.Size(201, 19)
        Me.lbCategoria.TabIndex = 69
        Me.lbCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTerminal
        '
        Me.lbTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTerminal.ForeColor = System.Drawing.Color.SeaShell
        Me.lbTerminal.Location = New System.Drawing.Point(101, 112)
        Me.lbTerminal.Name = "lbTerminal"
        Me.lbTerminal.Size = New System.Drawing.Size(201, 19)
        Me.lbTerminal.TabIndex = 68
        Me.lbTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbComanda
        '
        Me.lbComanda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbComanda.ForeColor = System.Drawing.Color.SeaShell
        Me.lbComanda.Location = New System.Drawing.Point(101, 156)
        Me.lbComanda.Name = "lbComanda"
        Me.lbComanda.Size = New System.Drawing.Size(201, 19)
        Me.lbComanda.TabIndex = 70
        Me.lbComanda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMotivo
        '
        Me.lbMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMotivo.ForeColor = System.Drawing.Color.SeaShell
        Me.lbMotivo.Location = New System.Drawing.Point(404, 90)
        Me.lbMotivo.Name = "lbMotivo"
        Me.lbMotivo.Size = New System.Drawing.Size(190, 19)
        Me.lbMotivo.TabIndex = 72
        Me.lbMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbStatus
        '
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.SeaShell
        Me.lbStatus.Location = New System.Drawing.Point(404, 68)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(190, 19)
        Me.lbStatus.TabIndex = 71
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnReimprimir
        '
        Me.btnReimprimir.BackColor = System.Drawing.Color.White
        Me.btnReimprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReimprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReimprimir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.ForeColor = System.Drawing.Color.Blue
        Me.btnReimprimir.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReimprimir.Location = New System.Drawing.Point(475, 135)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(119, 41)
        Me.btnReimprimir.TabIndex = 73
        Me.btnReimprimir.Text = "Reimprimir"
        Me.btnReimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReimprimir.UseVisualStyleBackColor = False
        Me.btnReimprimir.Visible = False
        '
        'tbIDVendaMovto
        '
        Me.tbIDVendaMovto.Location = New System.Drawing.Point(369, 152)
        Me.tbIDVendaMovto.Name = "tbIDVendaMovto"
        Me.tbIDVendaMovto.Size = New System.Drawing.Size(100, 20)
        Me.tbIDVendaMovto.TabIndex = 74
        Me.tbIDVendaMovto.Visible = False
        '
        'lbMesaCartao
        '
        Me.lbMesaCartao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMesaCartao.ForeColor = System.Drawing.Color.SeaShell
        Me.lbMesaCartao.Location = New System.Drawing.Point(404, 112)
        Me.lbMesaCartao.Name = "lbMesaCartao"
        Me.lbMesaCartao.Size = New System.Drawing.Size(190, 19)
        Me.lbMesaCartao.TabIndex = 77
        Me.lbMesaCartao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbMesaCartao.Visible = False
        '
        'lbMesaDestino
        '
        Me.lbMesaDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMesaDestino.ForeColor = System.Drawing.Color.PeachPuff
        Me.lbMesaDestino.Location = New System.Drawing.Point(309, 112)
        Me.lbMesaDestino.Name = "lbMesaDestino"
        Me.lbMesaDestino.Size = New System.Drawing.Size(99, 19)
        Me.lbMesaDestino.TabIndex = 76
        Me.lbMesaDestino.Text = "Mesa destino:"
        Me.lbMesaDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbMesaDestino.Visible = False
        '
        'lbProduto
        '
        Me.lbProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProduto.ForeColor = System.Drawing.Color.Gray
        Me.lbProduto.ForeColorBack = System.Drawing.Color.Gray
        Me.lbProduto.ForeColorFront = System.Drawing.Color.Yellow
        Me.lbProduto.Location = New System.Drawing.Point(131, 12)
        Me.lbProduto.Name = "lbProduto"
        Me.lbProduto.Size = New System.Drawing.Size(459, 44)
        Me.lbProduto.TabIndex = 75
        '
        'fdlgLancamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(602, 444)
        Me.Controls.Add(Me.lbMesaCartao)
        Me.Controls.Add(Me.lbMesaDestino)
        Me.Controls.Add(Me.lbProduto)
        Me.Controls.Add(Me.tbIDVendaMovto)
        Me.Controls.Add(Me.btnReimprimir)
        Me.Controls.Add(Me.lbMotivo)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.lbComanda)
        Me.Controls.Add(Me.lbCategoria)
        Me.Controls.Add(Me.lbTerminal)
        Me.Controls.Add(Me.lbHoraPedido)
        Me.Controls.Add(Me.lbAtendente)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVoltar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fdlgLancamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fdlgLancamento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVoltar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents lbAtendente As Label
    Friend WithEvents lbHoraPedido As Label
    Friend WithEvents lbCategoria As Label
    Friend WithEvents lbTerminal As Label
    Friend WithEvents lbComanda As Label
    Friend WithEvents lbMotivo As Label
    Friend WithEvents lbStatus As Label
    Friend WithEvents btnReimprimir As Button
    Friend WithEvents tbIDVendaMovto As TextBox
    Friend WithEvents tbComposicao As TextBox
    Friend WithEvents tbComentarios As TextBox
    Friend WithEvents lbProduto As SombraLabel
    Friend WithEvents lbMesaCartao As Label
    Friend WithEvents lbMesaDestino As Label
End Class
