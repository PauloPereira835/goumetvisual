<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgDelivery_Entregas
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
        Me.lstEntregas = New System.Windows.Forms.ListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbQtdeEntregas = New System.Windows.Forms.Label()
        Me.lbEntregador = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbCaixinha = New System.Windows.Forms.Label()
        Me.lbTxEntrega = New System.Windows.Forms.Label()
        Me.lbVendas = New System.Windows.Forms.Label()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.lstVendas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstTxEntrega = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstCaixinha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstSoma = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.White
        Me.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.btnVoltar.FlatAppearance.BorderSize = 0
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.Blue
        Me.btnVoltar.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVoltar.Location = New System.Drawing.Point(8, 9)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(103, 42)
        Me.btnVoltar.TabIndex = 7
        Me.btnVoltar.TabStop = False
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'lstEntregas
        '
        Me.lstEntregas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstEntregas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstEntregas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstVendas, Me.lstTxEntrega, Me.lstCaixinha, Me.lstSoma})
        Me.lstEntregas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstEntregas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstEntregas.ForeColor = System.Drawing.Color.Blue
        Me.lstEntregas.FullRowSelect = True
        Me.lstEntregas.GridLines = True
        Me.lstEntregas.HideSelection = False
        Me.lstEntregas.Location = New System.Drawing.Point(0, 0)
        Me.lstEntregas.MultiSelect = False
        Me.lstEntregas.Name = "lstEntregas"
        Me.lstEntregas.Size = New System.Drawing.Size(503, 444)
        Me.lstEntregas.TabIndex = 185
        Me.lstEntregas.UseCompatibleStateImageBehavior = False
        Me.lstEntregas.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstEntregas)
        Me.Panel1.Location = New System.Drawing.Point(8, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 444)
        Me.Panel1.TabIndex = 186
        '
        'lbQtdeEntregas
        '
        Me.lbQtdeEntregas.BackColor = System.Drawing.Color.Transparent
        Me.lbQtdeEntregas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQtdeEntregas.ForeColor = System.Drawing.Color.LemonChiffon
        Me.lbQtdeEntregas.Location = New System.Drawing.Point(350, 36)
        Me.lbQtdeEntregas.Name = "lbQtdeEntregas"
        Me.lbQtdeEntregas.Size = New System.Drawing.Size(159, 20)
        Me.lbQtdeEntregas.TabIndex = 191
        Me.lbQtdeEntregas.Text = "Qtde. entregas: 99"
        Me.lbQtdeEntregas.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbEntregador
        '
        Me.lbEntregador.BackColor = System.Drawing.Color.Transparent
        Me.lbEntregador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEntregador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbEntregador.Location = New System.Drawing.Point(198, 8)
        Me.lbEntregador.Name = "lbEntregador"
        Me.lbEntregador.Size = New System.Drawing.Size(318, 18)
        Me.lbEntregador.TabIndex = 192
        Me.lbEntregador.Text = "10000,00"
        Me.lbEntregador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(115, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Entregador  :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCaixinha
        '
        Me.lbCaixinha.BackColor = System.Drawing.Color.Transparent
        Me.lbCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaixinha.ForeColor = System.Drawing.Color.LemonChiffon
        Me.lbCaixinha.Location = New System.Drawing.Point(252, 506)
        Me.lbCaixinha.Name = "lbCaixinha"
        Me.lbCaixinha.Size = New System.Drawing.Size(116, 20)
        Me.lbCaixinha.TabIndex = 194
        Me.lbCaixinha.Text = "999,00"
        Me.lbCaixinha.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbTxEntrega
        '
        Me.lbTxEntrega.BackColor = System.Drawing.Color.Transparent
        Me.lbTxEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTxEntrega.ForeColor = System.Drawing.Color.LemonChiffon
        Me.lbTxEntrega.Location = New System.Drawing.Point(132, 506)
        Me.lbTxEntrega.Name = "lbTxEntrega"
        Me.lbTxEntrega.Size = New System.Drawing.Size(116, 20)
        Me.lbTxEntrega.TabIndex = 195
        Me.lbTxEntrega.Text = "999,00"
        Me.lbTxEntrega.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbVendas
        '
        Me.lbVendas.BackColor = System.Drawing.Color.Transparent
        Me.lbVendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVendas.ForeColor = System.Drawing.Color.LemonChiffon
        Me.lbVendas.Location = New System.Drawing.Point(491, 505)
        Me.lbVendas.Name = "lbVendas"
        Me.lbVendas.Size = New System.Drawing.Size(116, 20)
        Me.lbVendas.TabIndex = 196
        Me.lbVendas.Text = "999,00"
        Me.lbVendas.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbTotal
        '
        Me.lbTotal.BackColor = System.Drawing.Color.Transparent
        Me.lbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.ForeColor = System.Drawing.Color.LemonChiffon
        Me.lbTotal.Location = New System.Drawing.Point(370, 505)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(117, 20)
        Me.lbTotal.TabIndex = 197
        Me.lbTotal.Text = "999,00"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lstVendas
        '
        Me.lstVendas.Text = "Vendas"
        Me.lstVendas.Width = 120
        '
        'lstTxEntrega
        '
        Me.lstTxEntrega.Text = "Tx. Entrega"
        Me.lstTxEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstTxEntrega.Width = 120
        '
        'lstCaixinha
        '
        Me.lstCaixinha.Text = "Caixinha"
        Me.lstCaixinha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstCaixinha.Width = 120
        '
        'lstSoma
        '
        Me.lstSoma.Text = "Soma"
        Me.lstSoma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstSoma.Width = 120
        '
        'fdlgDelivery_Entregas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaGreen
        Me.ClientSize = New System.Drawing.Size(519, 529)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.lbVendas)
        Me.Controls.Add(Me.lbTxEntrega)
        Me.Controls.Add(Me.lbCaixinha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbEntregador)
        Me.Controls.Add(Me.lbQtdeEntregas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVoltar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fdlgDelivery_Entregas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fdlgDelivery_Entregas"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVoltar As Button
    Friend WithEvents lstEntregas As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbQtdeEntregas As Label
    Friend WithEvents lbEntregador As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbCaixinha As Label
    Friend WithEvents lbTxEntrega As Label
    Friend WithEvents lbVendas As Label
    Friend WithEvents lbTotal As Label
    Friend WithEvents lstVendas As ColumnHeader
    Friend WithEvents lstTxEntrega As ColumnHeader
    Friend WithEvents lstCaixinha As ColumnHeader
    Friend WithEvents lstSoma As ColumnHeader
End Class
