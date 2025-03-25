<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgVendasDetalhe
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
        Me.lstVendas = New System.Windows.Forms.ListView()
        Me.IDVendaRet = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ID_Loja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IDFechamento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NomeLoja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NumVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NumMesa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DataVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Caixa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.QtdPessoas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HoraAbertura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HoraFechamento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PreNota = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.XML = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstProdutos = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstVendas
        '
        Me.lstVendas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstVendas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDVendaRet, Me.ID_Loja, Me.IDFechamento, Me.NomeLoja, Me.NumVenda, Me.NumMesa, Me.DataVenda, Me.TotalVenda, Me.StatusVenda, Me.Caixa, Me.Cliente, Me.QtdPessoas, Me.HoraAbertura, Me.HoraFechamento, Me.PreNota, Me.XML})
        Me.lstVendas.FullRowSelect = True
        Me.lstVendas.GridLines = True
        Me.lstVendas.HideSelection = False
        Me.lstVendas.Location = New System.Drawing.Point(12, 12)
        Me.lstVendas.MultiSelect = False
        Me.lstVendas.Name = "lstVendas"
        Me.lstVendas.Size = New System.Drawing.Size(747, 252)
        Me.lstVendas.TabIndex = 18
        Me.lstVendas.UseCompatibleStateImageBehavior = False
        Me.lstVendas.View = System.Windows.Forms.View.Details
        '
        'IDVendaRet
        '
        Me.IDVendaRet.Text = "IDVendaRet"
        Me.IDVendaRet.Width = 0
        '
        'ID_Loja
        '
        Me.ID_Loja.Text = "IDLoja"
        Me.ID_Loja.Width = 0
        '
        'IDFechamento
        '
        Me.IDFechamento.Text = "IDFechamento"
        Me.IDFechamento.Width = 0
        '
        'NomeLoja
        '
        Me.NomeLoja.Text = "Loja"
        Me.NomeLoja.Width = 100
        '
        'NumVenda
        '
        Me.NumVenda.Text = "Venda"
        Me.NumVenda.Width = 50
        '
        'NumMesa
        '
        Me.NumMesa.Text = "Mesa"
        Me.NumMesa.Width = 50
        '
        'DataVenda
        '
        Me.DataVenda.Text = "Data"
        Me.DataVenda.Width = 125
        '
        'TotalVenda
        '
        Me.TotalVenda.Text = "Valor"
        Me.TotalVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusVenda
        '
        Me.StatusVenda.Text = "Módulo"
        '
        'Caixa
        '
        Me.Caixa.Text = "Caixa"
        Me.Caixa.Width = 100
        '
        'Cliente
        '
        Me.Cliente.Text = "Cliente"
        '
        'QtdPessoas
        '
        Me.QtdPessoas.Text = "Qtd_Pessoas"
        '
        'HoraAbertura
        '
        Me.HoraAbertura.Text = "Abertura"
        '
        'HoraFechamento
        '
        Me.HoraFechamento.Text = "Fechamento"
        '
        'PreNota
        '
        Me.PreNota.Text = "Pré Nota"
        '
        'XML
        '
        Me.XML.Text = "XML"
        '
        'lstProdutos
        '
        Me.lstProdutos.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstProdutos.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProdutos.FormattingEnabled = True
        Me.lstProdutos.ItemHeight = 16
        Me.lstProdutos.Location = New System.Drawing.Point(12, 270)
        Me.lstProdutos.Name = "lstProdutos"
        Me.lstProdutos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstProdutos.Size = New System.Drawing.Size(462, 276)
        Me.lstProdutos.TabIndex = 29
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ListBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(553, 334)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox1.Size = New System.Drawing.Size(206, 148)
        Me.ListBox1.TabIndex = 30
        '
        'fdlgVendasDetalhe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(770, 555)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lstProdutos)
        Me.Controls.Add(Me.lstVendas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgVendasDetalhe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendas"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstVendas As ListView
    Friend WithEvents IDVendaRet As ColumnHeader
    Friend WithEvents ID_Loja As ColumnHeader
    Friend WithEvents IDFechamento As ColumnHeader
    Friend WithEvents NomeLoja As ColumnHeader
    Friend WithEvents NumVenda As ColumnHeader
    Friend WithEvents NumMesa As ColumnHeader
    Friend WithEvents DataVenda As ColumnHeader
    Friend WithEvents TotalVenda As ColumnHeader
    Friend WithEvents StatusVenda As ColumnHeader
    Friend WithEvents Caixa As ColumnHeader
    Friend WithEvents Cliente As ColumnHeader
    Friend WithEvents QtdPessoas As ColumnHeader
    Friend WithEvents HoraAbertura As ColumnHeader
    Friend WithEvents HoraFechamento As ColumnHeader
    Friend WithEvents PreNota As ColumnHeader
    Friend WithEvents XML As ColumnHeader
    Friend WithEvents lstProdutos As ListBox
    Friend WithEvents ListBox1 As ListBox
End Class
