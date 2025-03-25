<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgLogsEventos
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
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtFim = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbAcao = New System.Windows.Forms.ComboBox()
        Me.lstLogs = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Terminal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Operador = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DataHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Acao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTerminal = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbOperador = New System.Windows.Forms.ComboBox()
        Me.lbQTde = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbManterLog = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back1
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(5, 5)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(97, 41)
        Me.btnVolta.TabIndex = 2
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'dtInicio
        '
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(597, 11)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtInicio.TabIndex = 201
        Me.dtInicio.Value = New Date(2015, 9, 4, 0, 0, 0, 0)
        '
        'dtFim
        '
        Me.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFim.Location = New System.Drawing.Point(597, 37)
        Me.dtFim.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtFim.Name = "dtFim"
        Me.dtFim.Size = New System.Drawing.Size(97, 20)
        Me.dtFim.TabIndex = 202
        Me.dtFim.Value = New Date(2015, 9, 4, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(562, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 16)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "Fim"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(556, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Início"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(488, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Período: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(814, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Ação"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAcao
        '
        Me.cbAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAcao.FormattingEnabled = True
        Me.cbAcao.Location = New System.Drawing.Point(856, 7)
        Me.cbAcao.Name = "cbAcao"
        Me.cbAcao.Size = New System.Drawing.Size(273, 21)
        Me.cbAcao.TabIndex = 203
        '
        'lstLogs
        '
        Me.lstLogs.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstLogs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.Terminal, Me.Operador, Me.DataHora, Me.Acao, Me.Descricao})
        Me.lstLogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLogs.FullRowSelect = True
        Me.lstLogs.GridLines = True
        Me.lstLogs.HideSelection = False
        Me.lstLogs.Location = New System.Drawing.Point(8, 95)
        Me.lstLogs.MultiSelect = False
        Me.lstLogs.Name = "lstLogs"
        Me.lstLogs.Size = New System.Drawing.Size(1122, 436)
        Me.lstLogs.TabIndex = 205
        Me.lstLogs.UseCompatibleStateImageBehavior = False
        Me.lstLogs.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 0
        '
        'Terminal
        '
        Me.Terminal.Text = "Terminal"
        Me.Terminal.Width = 160
        '
        'Operador
        '
        Me.Operador.Text = "Operador"
        Me.Operador.Width = 140
        '
        'DataHora
        '
        Me.DataHora.Text = "DataHora"
        Me.DataHora.Width = 140
        '
        'Acao
        '
        Me.Acao.Text = "Ação"
        Me.Acao.Width = 200
        '
        'Descricao
        '
        Me.Descricao.Text = "Descrição"
        Me.Descricao.Width = 460
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(736, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 206
        Me.Label5.Text = "Filtros: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(794, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 16)
        Me.Label6.TabIndex = 208
        Me.Label6.Text = "Terminal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTerminal
        '
        Me.cbTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTerminal.FormattingEnabled = True
        Me.cbTerminal.Location = New System.Drawing.Point(856, 34)
        Me.cbTerminal.Name = "cbTerminal"
        Me.cbTerminal.Size = New System.Drawing.Size(273, 21)
        Me.cbTerminal.TabIndex = 207
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(789, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 16)
        Me.Label7.TabIndex = 210
        Me.Label7.Text = "Operador"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbOperador
        '
        Me.cbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOperador.FormattingEnabled = True
        Me.cbOperador.Location = New System.Drawing.Point(856, 61)
        Me.cbOperador.Name = "cbOperador"
        Me.cbOperador.Size = New System.Drawing.Size(273, 21)
        Me.cbOperador.TabIndex = 209
        '
        'lbQTde
        '
        Me.lbQTde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQTde.ForeColor = System.Drawing.Color.Red
        Me.lbQTde.Location = New System.Drawing.Point(709, 533)
        Me.lbQTde.Name = "lbQTde"
        Me.lbQTde.Size = New System.Drawing.Size(421, 16)
        Me.lbQTde.TabIndex = 211
        Me.lbQTde.Text = "Total ocorrencias: 0"
        Me.lbQTde.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(138, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 214
        Me.Label8.Text = "Manter logs por:"
        '
        'cbManterLog
        '
        Me.cbManterLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbManterLog.FormattingEnabled = True
        Me.cbManterLog.Location = New System.Drawing.Point(260, 8)
        Me.cbManterLog.Name = "cbManterLog"
        Me.cbManterLog.Size = New System.Drawing.Size(177, 21)
        Me.cbManterLog.TabIndex = 212
        '
        'fdlgLogsEventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1146, 552)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbManterLog)
        Me.Controls.Add(Me.lbQTde)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbOperador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbTerminal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstLogs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbAcao)
        Me.Controls.Add(Me.dtInicio)
        Me.Controls.Add(Me.dtFim)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVolta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgLogsEventos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logs de Eventos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVolta As Button
    Friend WithEvents dtInicio As DateTimePicker
    Friend WithEvents dtFim As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbAcao As ComboBox
    Friend WithEvents lstLogs As ListView
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents Terminal As ColumnHeader
    Friend WithEvents Operador As ColumnHeader
    Friend WithEvents DataHora As ColumnHeader
    Friend WithEvents Acao As ColumnHeader
    Friend WithEvents Descricao As ColumnHeader
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbTerminal As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbOperador As ComboBox
    Friend WithEvents lbQTde As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cbManterLog As ComboBox
End Class
