<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgDeliveryEspecial
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRelatorio = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbOnLine = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbDiaria = New System.Windows.Forms.TextBox()
        Me.btnEnvia = New System.Windows.Forms.Button()
        Me.cbFuncionario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGrid = New System.Windows.Forms.DataGridView()
        Me.DSLista = New System.Data.DataSet()
        Me.DataTable = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.lbTotalFunc = New System.Windows.Forms.Label()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.lbTotalCaixinha = New System.Windows.Forms.Label()
        Me.lbTotalDiaria = New System.Windows.Forms.Label()
        Me.lbTotalOnLine = New System.Windows.Forms.Label()
        Me.lbTotalForaArea = New System.Windows.Forms.Label()
        Me.lbTotalGeral = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnRelatorio)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(914, 58)
        Me.Panel1.TabIndex = 14
        '
        'btnRelatorio
        '
        Me.btnRelatorio.BackColor = System.Drawing.Color.White
        Me.btnRelatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRelatorio.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnRelatorio.FlatAppearance.BorderSize = 0
        Me.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRelatorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelatorio.ForeColor = System.Drawing.Color.Black
        Me.btnRelatorio.Image = Global.GourmetVisual.My.Resources.Resources.Printer
        Me.btnRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRelatorio.Location = New System.Drawing.Point(573, 7)
        Me.btnRelatorio.Name = "btnRelatorio"
        Me.btnRelatorio.Size = New System.Drawing.Size(97, 41)
        Me.btnRelatorio.TabIndex = 2
        Me.btnRelatorio.TabStop = False
        Me.btnRelatorio.Text = "Relatorio"
        Me.btnRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRelatorio.UseVisualStyleBackColor = False
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
        Me.btnVolta.Location = New System.Drawing.Point(7, 7)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(97, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.tbOnLine)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbFA)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tbDiaria)
        Me.Panel2.Controls.Add(Me.btnEnvia)
        Me.Panel2.Controls.Add(Me.cbFuncionario)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(6, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(664, 82)
        Me.Panel2.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(289, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 15)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "OnLine"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbOnLine
        '
        Me.tbOnLine.Location = New System.Drawing.Point(409, 55)
        Me.tbOnLine.Name = "tbOnLine"
        Me.tbOnLine.Size = New System.Drawing.Size(100, 20)
        Me.tbOnLine.TabIndex = 175
        Me.tbOnLine.Text = "0,00"
        Me.tbOnLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(289, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 15)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "Fora de Area"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbFA
        '
        Me.tbFA.Location = New System.Drawing.Point(409, 29)
        Me.tbFA.Name = "tbFA"
        Me.tbFA.Size = New System.Drawing.Size(100, 20)
        Me.tbFA.TabIndex = 173
        Me.tbFA.Text = "0,00"
        Me.tbFA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(289, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "Diaria"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbDiaria
        '
        Me.tbDiaria.Location = New System.Drawing.Point(409, 3)
        Me.tbDiaria.Name = "tbDiaria"
        Me.tbDiaria.Size = New System.Drawing.Size(100, 20)
        Me.tbDiaria.TabIndex = 171
        Me.tbDiaria.Text = "0,00"
        Me.tbDiaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEnvia
        '
        Me.btnEnvia.BackColor = System.Drawing.Color.White
        Me.btnEnvia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEnvia.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEnvia.FlatAppearance.BorderSize = 0
        Me.btnEnvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnvia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnvia.ForeColor = System.Drawing.Color.Black
        Me.btnEnvia.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnEnvia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnvia.Location = New System.Drawing.Point(551, 19)
        Me.btnEnvia.Name = "btnEnvia"
        Me.btnEnvia.Size = New System.Drawing.Size(97, 41)
        Me.btnEnvia.TabIndex = 170
        Me.btnEnvia.TabStop = False
        Me.btnEnvia.Text = "Envia"
        Me.btnEnvia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnvia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnvia.UseVisualStyleBackColor = False
        '
        'cbFuncionario
        '
        Me.cbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFuncionario.FormattingEnabled = True
        Me.cbFuncionario.Location = New System.Drawing.Point(72, 4)
        Me.cbFuncionario.Name = "cbFuncionario"
        Me.cbFuncionario.Size = New System.Drawing.Size(202, 21)
        Me.cbFuncionario.TabIndex = 169
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Funcionario"
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToDeleteRows = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.Location = New System.Drawing.Point(6, 185)
        Me.DataGrid.MultiSelect = False
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGrid.Size = New System.Drawing.Size(664, 444)
        Me.DataGrid.TabIndex = 67
        '
        'DSLista
        '
        Me.DSLista.DataSetName = "NewDataSet"
        Me.DSLista.Tables.AddRange(New System.Data.DataTable() {Me.DataTable})
        '
        'DataTable
        '
        Me.DataTable.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn4, Me.DataColumn3, Me.DataColumn5, Me.DataColumn6})
        Me.DataTable.TableName = "Lista"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "Funcionario"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Caixinha"
        Me.DataColumn2.DataType = GetType(Decimal)
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Diaria"
        Me.DataColumn4.DataType = GetType(Decimal)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "Fora de Area"
        Me.DataColumn3.DataType = GetType(Decimal)
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "OnLine"
        Me.DataColumn5.DataType = GetType(Decimal)
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "Total"
        Me.DataColumn6.DataType = GetType(Decimal)
        '
        'lbTotalFunc
        '
        Me.lbTotalFunc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalFunc.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalFunc.Location = New System.Drawing.Point(8, 632)
        Me.lbTotalFunc.Name = "lbTotalFunc"
        Me.lbTotalFunc.Size = New System.Drawing.Size(232, 18)
        Me.lbTotalFunc.TabIndex = 175
        Me.lbTotalFunc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash1
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(6, 154)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(69, 25)
        Me.btnExcluir.TabIndex = 177
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'lbTotalCaixinha
        '
        Me.lbTotalCaixinha.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalCaixinha.Location = New System.Drawing.Point(260, 635)
        Me.lbTotalCaixinha.Name = "lbTotalCaixinha"
        Me.lbTotalCaixinha.Size = New System.Drawing.Size(68, 15)
        Me.lbTotalCaixinha.TabIndex = 178
        Me.lbTotalCaixinha.Text = "0,00"
        Me.lbTotalCaixinha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalDiaria
        '
        Me.lbTotalDiaria.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalDiaria.Location = New System.Drawing.Point(339, 635)
        Me.lbTotalDiaria.Name = "lbTotalDiaria"
        Me.lbTotalDiaria.Size = New System.Drawing.Size(68, 15)
        Me.lbTotalDiaria.TabIndex = 179
        Me.lbTotalDiaria.Text = "0,00"
        Me.lbTotalDiaria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalOnLine
        '
        Me.lbTotalOnLine.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalOnLine.Location = New System.Drawing.Point(499, 635)
        Me.lbTotalOnLine.Name = "lbTotalOnLine"
        Me.lbTotalOnLine.Size = New System.Drawing.Size(68, 15)
        Me.lbTotalOnLine.TabIndex = 181
        Me.lbTotalOnLine.Text = "0,00"
        Me.lbTotalOnLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalForaArea
        '
        Me.lbTotalForaArea.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalForaArea.Location = New System.Drawing.Point(419, 635)
        Me.lbTotalForaArea.Name = "lbTotalForaArea"
        Me.lbTotalForaArea.Size = New System.Drawing.Size(68, 15)
        Me.lbTotalForaArea.TabIndex = 180
        Me.lbTotalForaArea.Text = "0,00"
        Me.lbTotalForaArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotalGeral
        '
        Me.lbTotalGeral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalGeral.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalGeral.Location = New System.Drawing.Point(577, 635)
        Me.lbTotalGeral.Name = "lbTotalGeral"
        Me.lbTotalGeral.Size = New System.Drawing.Size(68, 15)
        Me.lbTotalGeral.TabIndex = 182
        Me.lbTotalGeral.Text = "0,00"
        Me.lbTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fdlgDeliveryEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(675, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbTotalGeral)
        Me.Controls.Add(Me.lbTotalOnLine)
        Me.Controls.Add(Me.lbTotalForaArea)
        Me.Controls.Add(Me.lbTotalDiaria)
        Me.Controls.Add(Me.lbTotalCaixinha)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.lbTotalFunc)
        Me.Controls.Add(Me.DataGrid)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgDeliveryEspecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informações por Funcionário"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbOnLine As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbFA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbDiaria As TextBox
    Friend WithEvents btnEnvia As Button
    Friend WithEvents cbFuncionario As ComboBox
    Friend WithEvents DataGrid As DataGridView
    Friend WithEvents DSLista As DataSet
    Friend WithEvents DataTable As DataTable
    Friend WithEvents lbTotalFunc As Label
    Friend WithEvents btnExcluir As Button
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn4 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents DataColumn5 As DataColumn
    Friend WithEvents DataColumn6 As DataColumn
    Friend WithEvents lbTotalCaixinha As Label
    Friend WithEvents lbTotalDiaria As Label
    Friend WithEvents lbTotalOnLine As Label
    Friend WithEvents lbTotalForaArea As Label
    Friend WithEvents lbTotalGeral As Label
    Friend WithEvents btnRelatorio As Button
End Class
