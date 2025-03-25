<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgManutencaoCaixa
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
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.btnAltera = New System.Windows.Forms.Button()
        Me.lbTotalVendas = New System.Windows.Forms.Label()
        Me.DataGrid = New System.Windows.Forms.DataGridView()
        Me.DSLista = New System.Data.DataSet()
        Me.DataTable = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.btnAltera)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 58)
        Me.Panel1.TabIndex = 14
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
        'btnAltera
        '
        Me.btnAltera.BackColor = System.Drawing.Color.White
        Me.btnAltera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAltera.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAltera.FlatAppearance.BorderSize = 0
        Me.btnAltera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAltera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAltera.ForeColor = System.Drawing.Color.Blue
        Me.btnAltera.Image = Global.GourmetVisual.My.Resources.Resources.Ok
        Me.btnAltera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAltera.Location = New System.Drawing.Point(517, 8)
        Me.btnAltera.Name = "btnAltera"
        Me.btnAltera.Size = New System.Drawing.Size(99, 41)
        Me.btnAltera.TabIndex = 23
        Me.btnAltera.TabStop = False
        Me.btnAltera.Tag = ""
        Me.btnAltera.Text = "Alterar"
        Me.btnAltera.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAltera.UseVisualStyleBackColor = False
        '
        'lbTotalVendas
        '
        Me.lbTotalVendas.Location = New System.Drawing.Point(390, 521)
        Me.lbTotalVendas.Name = "lbTotalVendas"
        Me.lbTotalVendas.Size = New System.Drawing.Size(208, 17)
        Me.lbTotalVendas.TabIndex = 33
        Me.lbTotalVendas.Text = "Total de vendas: 0"
        Me.lbTotalVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToDeleteRows = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.Location = New System.Drawing.Point(12, 64)
        Me.DataGrid.MultiSelect = False
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGrid.Size = New System.Drawing.Size(601, 454)
        Me.DataGrid.TabIndex = 67
        '
        'DSLista
        '
        Me.DSLista.DataSetName = "NewDataSet"
        Me.DSLista.Tables.AddRange(New System.Data.DataTable() {Me.DataTable})
        '
        'DataTable
        '
        Me.DataTable.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8})
        Me.DataTable.TableName = "Lista"
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "IDVenda"
        Me.DataColumn1.ColumnName = "IDVenda"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "Mesa"
        Me.DataColumn2.ColumnName = "Mesa"
        '
        'DataColumn3
        '
        Me.DataColumn3.Caption = "TotalProdutos"
        Me.DataColumn3.ColumnName = "Vlr Produtos"
        Me.DataColumn3.DataType = GetType(Decimal)
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "TotalVenda"
        Me.DataColumn4.ColumnName = "Vlr Venda"
        Me.DataColumn4.DataType = GetType(Decimal)
        '
        'DataColumn5
        '
        Me.DataColumn5.Caption = "QtdePessoas"
        Me.DataColumn5.ColumnName = "Qtde Pessoas"
        Me.DataColumn5.DataType = GetType(Integer)
        '
        'DataColumn6
        '
        Me.DataColumn6.Caption = "Status"
        Me.DataColumn6.ColumnName = "Status"
        '
        'DataColumn7
        '
        Me.DataColumn7.Caption = "Atendente"
        Me.DataColumn7.ColumnName = "Atendente"
        '
        'DataColumn8
        '
        Me.DataColumn8.Caption = "IDFuncionarioAtendente"
        Me.DataColumn8.ColumnName = "IDFuncionarioAtendente"
        Me.DataColumn8.DataType = GetType(Integer)
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.White
        Me.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcluir.ForeColor = System.Drawing.Color.Blue
        Me.btnExcluir.Image = Global.GourmetVisual.My.Resources.Resources.Trash2
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(406, 9)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(99, 41)
        Me.btnExcluir.TabIndex = 24
        Me.btnExcluir.TabStop = False
        Me.btnExcluir.Tag = ""
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'fdlgManutencaoCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(625, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGrid)
        Me.Controls.Add(Me.lbTotalVendas)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgManutencaoCaixa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manutencao do Caixa"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnVolta As Button
    Friend WithEvents btnAltera As Button
    Friend WithEvents lbTotalVendas As Label
    Friend WithEvents DataGrid As DataGridView
    Friend WithEvents DSLista As DataSet
    Friend WithEvents DataTable As DataTable
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents DataColumn4 As DataColumn
    Friend WithEvents DataColumn5 As DataColumn
    Friend WithEvents DataColumn6 As DataColumn
    Friend WithEvents DataColumn7 As DataColumn
    Friend WithEvents DataColumn8 As DataColumn
    Friend WithEvents btnExcluir As Button
End Class
