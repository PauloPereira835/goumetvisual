<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgDelivery_Pagto
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
        Me.lstPagtos = New System.Windows.Forms.ListView()
        Me.lstIDpagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstIDFormaPagto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstDescricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstValor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.cbPagamento = New System.Windows.Forms.ComboBox()
        Me.tbValor = New System.Windows.Forms.TextBox()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbTotalPagto = New System.Windows.Forms.Label()
        Me.lbProdutos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbDesconto = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbTaxaEntrega = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbTotalPagar = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbCaixinha = New System.Windows.Forms.Label()
        Me.lbTextoCaixinha = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstPagtos
        '
        Me.lstPagtos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstPagtos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstPagtos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lstIDpagto, Me.lstIDFormaPagto, Me.lstDescricao, Me.lstValor})
        Me.lstPagtos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPagtos.ForeColor = System.Drawing.Color.Blue
        Me.lstPagtos.FullRowSelect = True
        Me.lstPagtos.GridLines = True
        Me.lstPagtos.HideSelection = False
        Me.lstPagtos.Location = New System.Drawing.Point(11, 158)
        Me.lstPagtos.Name = "lstPagtos"
        Me.lstPagtos.Size = New System.Drawing.Size(342, 187)
        Me.lstPagtos.TabIndex = 33
        Me.lstPagtos.UseCompatibleStateImageBehavior = False
        Me.lstPagtos.View = System.Windows.Forms.View.Details
        '
        'lstIDpagto
        '
        Me.lstIDpagto.Text = "IDpagto"
        Me.lstIDpagto.Width = 0
        '
        'lstIDFormaPagto
        '
        Me.lstIDFormaPagto.Text = "IDFormaPagto"
        Me.lstIDFormaPagto.Width = 0
        '
        'lstDescricao
        '
        Me.lstDescricao.Text = "Descrição"
        Me.lstDescricao.Width = 220
        '
        'lstValor
        '
        Me.lstValor.Text = "Valor"
        Me.lstValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lstValor.Width = 100
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnConfirma)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(373, 53)
        Me.Panel1.TabIndex = 34
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
        Me.btnVolta.Location = New System.Drawing.Point(9, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(99, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'btnConfirma
        '
        Me.btnConfirma.BackColor = System.Drawing.Color.White
        Me.btnConfirma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConfirma.FlatAppearance.BorderSize = 0
        Me.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.ForeColor = System.Drawing.Color.Black
        Me.btnConfirma.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(255, 6)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(104, 41)
        Me.btnConfirma.TabIndex = 23
        Me.btnConfirma.TabStop = False
        Me.btnConfirma.Tag = ""
        Me.btnConfirma.Text = "Confirma F7"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = False
        '
        'cbPagamento
        '
        Me.cbPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPagamento.FormattingEnabled = True
        Me.cbPagamento.ItemHeight = 18
        Me.cbPagamento.Location = New System.Drawing.Point(4, 21)
        Me.cbPagamento.Name = "cbPagamento"
        Me.cbPagamento.Size = New System.Drawing.Size(222, 26)
        Me.cbPagamento.TabIndex = 35
        '
        'tbValor
        '
        Me.tbValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValor.Location = New System.Drawing.Point(232, 21)
        Me.tbValor.Name = "tbValor"
        Me.tbValor.Size = New System.Drawing.Size(101, 26)
        Me.tbValor.TabIndex = 36
        Me.tbValor.Text = "0,00"
        Me.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnIncluir
        '
        Me.btnIncluir.BackColor = System.Drawing.Color.White
        Me.btnIncluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnIncluir.FlatAppearance.BorderSize = 0
        Me.btnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncluir.ForeColor = System.Drawing.Color.Black
        Me.btnIncluir.Image = Global.GourmetVisual.My.Resources.Resources.Plus2
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.Location = New System.Drawing.Point(262, 53)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(71, 29)
        Me.btnIncluir.TabIndex = 24
        Me.btnIncluir.TabStop = False
        Me.btnIncluir.Tag = ""
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIncluir.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.White
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Black
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(6, 53)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(71, 29)
        Me.btnExcluir.TabIndex = 37
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Tag = ""
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(1, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Selecione a forma de pagamento e informe o valor"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(11, 347)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 17)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Valor total pagamento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalPagto
        '
        Me.lbTotalPagto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalPagto.ForeColor = System.Drawing.Color.Maroon
        Me.lbTotalPagto.Location = New System.Drawing.Point(232, 347)
        Me.lbTotalPagto.Name = "lbTotalPagto"
        Me.lbTotalPagto.Size = New System.Drawing.Size(105, 17)
        Me.lbTotalPagto.TabIndex = 40
        Me.lbTotalPagto.Text = "0,00"
        Me.lbTotalPagto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbProdutos
        '
        Me.lbProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProdutos.ForeColor = System.Drawing.Color.Maroon
        Me.lbProdutos.Location = New System.Drawing.Point(232, 372)
        Me.lbProdutos.Name = "lbProdutos"
        Me.lbProdutos.Size = New System.Drawing.Size(105, 17)
        Me.lbProdutos.TabIndex = 42
        Me.lbProdutos.Text = "0,00"
        Me.lbProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(11, 372)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(215, 17)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Produtos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbDesconto
        '
        Me.lbDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesconto.ForeColor = System.Drawing.Color.Maroon
        Me.lbDesconto.Location = New System.Drawing.Point(232, 393)
        Me.lbDesconto.Name = "lbDesconto"
        Me.lbDesconto.Size = New System.Drawing.Size(105, 17)
        Me.lbDesconto.TabIndex = 44
        Me.lbDesconto.Text = "0,00"
        Me.lbDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(11, 393)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(215, 17)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Desconto ( - )"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTaxaEntrega
        '
        Me.lbTaxaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTaxaEntrega.ForeColor = System.Drawing.Color.Maroon
        Me.lbTaxaEntrega.Location = New System.Drawing.Point(232, 414)
        Me.lbTaxaEntrega.Name = "lbTaxaEntrega"
        Me.lbTaxaEntrega.Size = New System.Drawing.Size(105, 17)
        Me.lbTaxaEntrega.TabIndex = 46
        Me.lbTaxaEntrega.Text = "0,00"
        Me.lbTaxaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(11, 414)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(215, 17)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Taxa Entrega"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalPagar
        '
        Me.lbTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalPagar.ForeColor = System.Drawing.Color.Maroon
        Me.lbTotalPagar.Location = New System.Drawing.Point(232, 435)
        Me.lbTotalPagar.Name = "lbTotalPagar"
        Me.lbTotalPagar.Size = New System.Drawing.Size(105, 17)
        Me.lbTotalPagar.TabIndex = 48
        Me.lbTotalPagar.Text = "0,00"
        Me.lbTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(11, 435)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(215, 17)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Total a pagar"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbCaixinha
        '
        Me.lbCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaixinha.ForeColor = System.Drawing.Color.Maroon
        Me.lbCaixinha.Location = New System.Drawing.Point(231, 461)
        Me.lbCaixinha.Name = "lbCaixinha"
        Me.lbCaixinha.Size = New System.Drawing.Size(105, 17)
        Me.lbCaixinha.TabIndex = 50
        Me.lbCaixinha.Text = "0,00"
        Me.lbCaixinha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTextoCaixinha
        '
        Me.lbTextoCaixinha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTextoCaixinha.ForeColor = System.Drawing.Color.Blue
        Me.lbTextoCaixinha.Location = New System.Drawing.Point(10, 461)
        Me.lbTextoCaixinha.Name = "lbTextoCaixinha"
        Me.lbTextoCaixinha.Size = New System.Drawing.Size(215, 17)
        Me.lbTextoCaixinha.TabIndex = 49
        Me.lbTextoCaixinha.Text = "Sobra (caixinha)"
        Me.lbTextoCaixinha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIDVenda.Location = New System.Drawing.Point(7, 454)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(29, 26)
        Me.tbIDVenda.TabIndex = 51
        Me.tbIDVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbIDVenda.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.tbValor)
        Me.Panel2.Controls.Add(Me.cbPagamento)
        Me.Panel2.Controls.Add(Me.btnIncluir)
        Me.Panel2.Controls.Add(Me.btnExcluir)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(9, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 91)
        Me.Panel2.TabIndex = 52
        '
        'fdlgDelivery_Pagto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ClientSize = New System.Drawing.Size(362, 484)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.lbCaixinha)
        Me.Controls.Add(Me.lbTextoCaixinha)
        Me.Controls.Add(Me.lbTotalPagar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbTaxaEntrega)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbDesconto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbProdutos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbTotalPagto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstPagtos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "fdlgDelivery_Pagto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe o pagamento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstPagtos As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents lstIDpagto As ColumnHeader
    Friend WithEvents lstIDFormaPagto As ColumnHeader
    Friend WithEvents lstDescricao As ColumnHeader
    Friend WithEvents lstValor As ColumnHeader
    Friend WithEvents cbPagamento As ComboBox
    Friend WithEvents tbValor As TextBox
    Friend WithEvents btnIncluir As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbTotalPagto As Label
    Friend WithEvents lbProdutos As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbDesconto As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbTaxaEntrega As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbTotalPagar As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbCaixinha As Label
    Friend WithEvents lbTextoCaixinha As Label
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents Panel2 As Panel
End Class
