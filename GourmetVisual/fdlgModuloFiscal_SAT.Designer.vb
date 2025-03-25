<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgModuloFiscal_SAT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lstVendas = New System.Windows.Forms.ListView()
        Me.IDVendaSAT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NumVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NumMesa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DatHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Valor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Num_SAT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Desconto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Servico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TaxaEntrega = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DataMovto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDSat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnVisualiza = New System.Windows.Forms.Button()
        Me.btnEmite = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.tbIDVendaSAT = New System.Windows.Forms.TextBox()
        Me.lbMsgValido = New System.Windows.Forms.Label()
        Me.tbCpfCnpj = New System.Windows.Forms.TextBox()
        Me.lbValorTotal = New System.Windows.Forms.Label()
        Me.lbQtde = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbMovto = New System.Windows.Forms.ComboBox()
        Me.chkMovtoAterior = New System.Windows.Forms.CheckBox()
        Me.rbCancelados = New System.Windows.Forms.RadioButton()
        Me.rbRejeitados = New System.Windows.Forms.RadioButton()
        Me.rbAutorizados = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbIDVenda = New System.Windows.Forms.TextBox()
        Me.TimerAguardandoSAT = New System.Windows.Forms.Timer(Me.components)
        Me.lbMensagem = New System.Windows.Forms.Label()
        Me.tbDiaMovto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbBusca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstVendas
        '
        Me.lstVendas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstVendas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstVendas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDVendaSAT, Me.StatusVenda, Me.NumVenda, Me.NumMesa, Me.DatHora, Me.Valor, Me.Num_SAT, Me.IDVenda, Me.Desconto, Me.Servico, Me.TotalVenda, Me.TaxaEntrega, Me.DataMovto, Me.IDSat})
        Me.lstVendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstVendas.ForeColor = System.Drawing.Color.Blue
        Me.lstVendas.FullRowSelect = True
        Me.lstVendas.GridLines = True
        Me.lstVendas.HideSelection = False
        Me.lstVendas.Location = New System.Drawing.Point(39, 203)
        Me.lstVendas.MultiSelect = False
        Me.lstVendas.Name = "lstVendas"
        Me.lstVendas.Size = New System.Drawing.Size(607, 384)
        Me.lstVendas.TabIndex = 32
        Me.lstVendas.UseCompatibleStateImageBehavior = False
        Me.lstVendas.View = System.Windows.Forms.View.Details
        '
        'IDVendaSAT
        '
        Me.IDVendaSAT.Text = "IDVendaSAT"
        Me.IDVendaSAT.Width = 0
        '
        'StatusVenda
        '
        Me.StatusVenda.Text = "Status"
        Me.StatusVenda.Width = 90
        '
        'NumVenda
        '
        Me.NumVenda.Text = "Seq. Vda."
        Me.NumVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumVenda.Width = 90
        '
        'NumMesa
        '
        Me.NumMesa.Text = "Mesa ou N.vda"
        Me.NumMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumMesa.Width = 120
        '
        'DatHora
        '
        Me.DatHora.Text = "Data/Hora"
        Me.DatHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DatHora.Width = 170
        '
        'Valor
        '
        Me.Valor.Text = "Valor"
        Me.Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Valor.Width = 100
        '
        'Num_SAT
        '
        Me.Num_SAT.Text = ""
        Me.Num_SAT.Width = 26
        '
        'IDVenda
        '
        Me.IDVenda.Text = "IDVenda"
        Me.IDVenda.Width = 0
        '
        'Desconto
        '
        Me.Desconto.Text = "Desconto"
        Me.Desconto.Width = 0
        '
        'Servico
        '
        Me.Servico.Text = "Servico"
        Me.Servico.Width = 0
        '
        'TotalVenda
        '
        Me.TotalVenda.Text = "TotalVenda"
        Me.TotalVenda.Width = 0
        '
        'TaxaEntrega
        '
        Me.TaxaEntrega.Text = "TaxaEntrega"
        Me.TaxaEntrega.Width = 0
        '
        'DataMovto
        '
        Me.DataMovto.Text = "DataMovto"
        Me.DataMovto.Width = 0
        '
        'IDSat
        '
        Me.IDSat.Text = "IDSat"
        Me.IDSat.Width = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnCancela)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnVisualiza)
        Me.Panel1.Controls.Add(Me.btnEmite)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(691, 54)
        Me.Panel1.TabIndex = 33
        '
        'btnCancela
        '
        Me.btnCancela.BackColor = System.Drawing.Color.White
        Me.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancela.Enabled = False
        Me.btnCancela.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCancela.FlatAppearance.BorderSize = 0
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.ForeColor = System.Drawing.Color.Black
        Me.btnCancela.Image = Global.GourmetVisual.My.Resources.Resources.Cancel
        Me.btnCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancela.Location = New System.Drawing.Point(286, 6)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(130, 41)
        Me.btnCancela.TabIndex = 104
        Me.btnCancela.TabStop = False
        Me.btnCancela.Tag = ""
        Me.btnCancela.Text = "Cancela CUPOM"
        Me.btnCancela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancela.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.GourmetVisual.My.Resources.Resources.Tool
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(164, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 41)
        Me.Button1.TabIndex = 103
        Me.Button1.TabStop = False
        Me.Button1.Text = "Configurações"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnVisualiza
        '
        Me.btnVisualiza.BackColor = System.Drawing.Color.White
        Me.btnVisualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVisualiza.Enabled = False
        Me.btnVisualiza.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVisualiza.FlatAppearance.BorderSize = 0
        Me.btnVisualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVisualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisualiza.ForeColor = System.Drawing.Color.Black
        Me.btnVisualiza.Image = Global.GourmetVisual.My.Resources.Resources.Document
        Me.btnVisualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVisualiza.Location = New System.Drawing.Point(422, 6)
        Me.btnVisualiza.Name = "btnVisualiza"
        Me.btnVisualiza.Size = New System.Drawing.Size(130, 41)
        Me.btnVisualiza.TabIndex = 102
        Me.btnVisualiza.TabStop = False
        Me.btnVisualiza.Tag = ""
        Me.btnVisualiza.Text = "Visualiza CUPOM"
        Me.btnVisualiza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVisualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVisualiza.UseVisualStyleBackColor = False
        '
        'btnEmite
        '
        Me.btnEmite.BackColor = System.Drawing.Color.White
        Me.btnEmite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEmite.Enabled = False
        Me.btnEmite.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEmite.FlatAppearance.BorderSize = 0
        Me.btnEmite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmite.ForeColor = System.Drawing.Color.Black
        Me.btnEmite.Image = Global.GourmetVisual.My.Resources.Resources.Document_New
        Me.btnEmite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmite.Location = New System.Drawing.Point(558, 6)
        Me.btnEmite.Name = "btnEmite"
        Me.btnEmite.Size = New System.Drawing.Size(125, 41)
        Me.btnEmite.TabIndex = 101
        Me.btnEmite.TabStop = False
        Me.btnEmite.Tag = ""
        Me.btnEmite.Text = "Emite CUPOM"
        Me.btnEmite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEmite.UseVisualStyleBackColor = False
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
        'tbIDVendaSAT
        '
        Me.tbIDVendaSAT.Location = New System.Drawing.Point(110, 178)
        Me.tbIDVendaSAT.Name = "tbIDVendaSAT"
        Me.tbIDVendaSAT.Size = New System.Drawing.Size(67, 20)
        Me.tbIDVendaSAT.TabIndex = 34
        Me.tbIDVendaSAT.Visible = False
        '
        'lbMsgValido
        '
        Me.lbMsgValido.ForeColor = System.Drawing.Color.Blue
        Me.lbMsgValido.Location = New System.Drawing.Point(254, 180)
        Me.lbMsgValido.Name = "lbMsgValido"
        Me.lbMsgValido.Size = New System.Drawing.Size(193, 14)
        Me.lbMsgValido.TabIndex = 39
        Me.lbMsgValido.Text = "Informe CPF / CNPJ"
        Me.lbMsgValido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbCpfCnpj
        '
        Me.tbCpfCnpj.Location = New System.Drawing.Point(451, 177)
        Me.tbCpfCnpj.Name = "tbCpfCnpj"
        Me.tbCpfCnpj.Size = New System.Drawing.Size(191, 20)
        Me.tbCpfCnpj.TabIndex = 38
        Me.tbCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbValorTotal
        '
        Me.lbValorTotal.ForeColor = System.Drawing.Color.Blue
        Me.lbValorTotal.Location = New System.Drawing.Point(409, 590)
        Me.lbValorTotal.Name = "lbValorTotal"
        Me.lbValorTotal.Size = New System.Drawing.Size(193, 14)
        Me.lbValorTotal.TabIndex = 40
        Me.lbValorTotal.Text = "0,00"
        Me.lbValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQtde
        '
        Me.lbQtde.ForeColor = System.Drawing.Color.Blue
        Me.lbQtde.Location = New System.Drawing.Point(41, 590)
        Me.lbQtde.Name = "lbQtde"
        Me.lbQtde.Size = New System.Drawing.Size(193, 14)
        Me.lbQtde.TabIndex = 41
        Me.lbQtde.Text = "Quantidade de vendas: 0"
        Me.lbQtde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.cbMovto)
        Me.Panel2.Controls.Add(Me.chkMovtoAterior)
        Me.Panel2.Controls.Add(Me.rbCancelados)
        Me.Panel2.Controls.Add(Me.rbRejeitados)
        Me.Panel2.Controls.Add(Me.rbAutorizados)
        Me.Panel2.Controls.Add(Me.rbTodos)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(44, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(598, 56)
        Me.Panel2.TabIndex = 42
        '
        'cbMovto
        '
        Me.cbMovto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMovto.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovto.FormattingEnabled = True
        Me.cbMovto.Location = New System.Drawing.Point(292, 27)
        Me.cbMovto.Name = "cbMovto"
        Me.cbMovto.Size = New System.Drawing.Size(296, 22)
        Me.cbMovto.TabIndex = 173
        Me.cbMovto.Visible = False
        '
        'chkMovtoAterior
        '
        Me.chkMovtoAterior.AutoSize = True
        Me.chkMovtoAterior.Location = New System.Drawing.Point(175, 29)
        Me.chkMovtoAterior.Name = "chkMovtoAterior"
        Me.chkMovtoAterior.Size = New System.Drawing.Size(116, 17)
        Me.chkMovtoAterior.TabIndex = 45
        Me.chkMovtoAterior.Text = "Outros movimentos"
        Me.chkMovtoAterior.UseVisualStyleBackColor = True
        '
        'rbCancelados
        '
        Me.rbCancelados.AutoSize = True
        Me.rbCancelados.Location = New System.Drawing.Point(507, 2)
        Me.rbCancelados.Name = "rbCancelados"
        Me.rbCancelados.Size = New System.Drawing.Size(81, 17)
        Me.rbCancelados.TabIndex = 44
        Me.rbCancelados.TabStop = True
        Me.rbCancelados.Text = "Cancelados"
        Me.rbCancelados.UseVisualStyleBackColor = True
        '
        'rbRejeitados
        '
        Me.rbRejeitados.AutoSize = True
        Me.rbRejeitados.Location = New System.Drawing.Point(394, 2)
        Me.rbRejeitados.Name = "rbRejeitados"
        Me.rbRejeitados.Size = New System.Drawing.Size(75, 17)
        Me.rbRejeitados.TabIndex = 43
        Me.rbRejeitados.TabStop = True
        Me.rbRejeitados.Text = "Rejeitados"
        Me.rbRejeitados.UseVisualStyleBackColor = True
        '
        'rbAutorizados
        '
        Me.rbAutorizados.AutoSize = True
        Me.rbAutorizados.Location = New System.Drawing.Point(275, 2)
        Me.rbAutorizados.Name = "rbAutorizados"
        Me.rbAutorizados.Size = New System.Drawing.Size(80, 17)
        Me.rbAutorizados.TabIndex = 42
        Me.rbAutorizados.TabStop = True
        Me.rbAutorizados.Text = "Autorizados"
        Me.rbAutorizados.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(175, 2)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 41
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 17)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Critério"
        '
        'tbIDVenda
        '
        Me.tbIDVenda.Location = New System.Drawing.Point(12, 178)
        Me.tbIDVenda.Name = "tbIDVenda"
        Me.tbIDVenda.Size = New System.Drawing.Size(66, 20)
        Me.tbIDVenda.TabIndex = 43
        Me.tbIDVenda.Visible = False
        '
        'TimerAguardandoSAT
        '
        Me.TimerAguardandoSAT.Interval = 500
        '
        'lbMensagem
        '
        Me.lbMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensagem.ForeColor = System.Drawing.Color.Green
        Me.lbMensagem.Location = New System.Drawing.Point(41, 612)
        Me.lbMensagem.Name = "lbMensagem"
        Me.lbMensagem.Size = New System.Drawing.Size(605, 20)
        Me.lbMensagem.TabIndex = 44
        Me.lbMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbDiaMovto
        '
        Me.tbDiaMovto.Location = New System.Drawing.Point(209, 178)
        Me.tbDiaMovto.Name = "tbDiaMovto"
        Me.tbDiaMovto.Size = New System.Drawing.Size(67, 20)
        Me.tbDiaMovto.TabIndex = 45
        Me.tbDiaMovto.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(42, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Busca"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBusca
        '
        Me.tbBusca.Location = New System.Drawing.Point(249, 122)
        Me.tbBusca.Name = "tbBusca"
        Me.tbBusca.Size = New System.Drawing.Size(126, 20)
        Me.tbBusca.TabIndex = 46
        Me.tbBusca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(92, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 14)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "( mesa/cartão ou núm. venda )"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fdlgModuloFiscal_SAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(688, 634)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbBusca)
        Me.Controls.Add(Me.tbDiaMovto)
        Me.Controls.Add(Me.lbMensagem)
        Me.Controls.Add(Me.tbIDVenda)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbQtde)
        Me.Controls.Add(Me.lbValorTotal)
        Me.Controls.Add(Me.lbMsgValido)
        Me.Controls.Add(Me.tbCpfCnpj)
        Me.Controls.Add(Me.tbIDVendaSAT)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstVendas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgModuloFiscal_SAT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulo Fiscal - SAT"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstVendas As ListView
    Friend WithEvents IDVendaSAT As ColumnHeader
    Friend WithEvents StatusVenda As ColumnHeader
    Friend WithEvents NumVenda As ColumnHeader
    Friend WithEvents NumMesa As ColumnHeader
    Friend WithEvents DatHora As ColumnHeader
    Friend WithEvents Valor As ColumnHeader
    Friend WithEvents Num_SAT As ColumnHeader
    Friend WithEvents IDVenda As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVisualiza As Button
    Friend WithEvents btnEmite As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents tbIDVendaSAT As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lbMsgValido As Label
    Friend WithEvents tbCpfCnpj As TextBox
    Friend WithEvents Desconto As ColumnHeader
    Friend WithEvents Servico As ColumnHeader
    Friend WithEvents TotalVenda As ColumnHeader
    Friend WithEvents TaxaEntrega As ColumnHeader
    Friend WithEvents DataMovto As ColumnHeader
    Friend WithEvents IDSat As ColumnHeader
    Friend WithEvents lbValorTotal As Label
    Friend WithEvents lbQtde As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents rbRejeitados As RadioButton
    Friend WithEvents rbAutorizados As RadioButton
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents rbCancelados As RadioButton
    Friend WithEvents btnCancela As Button
    Friend WithEvents tbIDVenda As TextBox
    Friend WithEvents chkMovtoAterior As CheckBox
    Friend WithEvents cbMovto As ComboBox
    Friend WithEvents TimerAguardandoSAT As Timer
    Friend WithEvents lbMensagem As Label
    Friend WithEvents tbDiaMovto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbBusca As TextBox
    Friend WithEvents Label3 As Label
End Class
