<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgGruposPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgGruposPedidos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSeleciona = New System.Windows.Forms.Button()
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.lstGrupos = New System.Windows.Forms.ListView()
        Me.CodigoGrupo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grupo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstGruposSelecionados = New System.Windows.Forms.ListView()
        Me.IDGrupoPedidos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrupoPedidos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExclui = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 54)
        Me.Panel1.TabIndex = 35
        '
        'btnSeleciona
        '
        Me.btnSeleciona.BackColor = System.Drawing.Color.White
        Me.btnSeleciona.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSeleciona.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSeleciona.FlatAppearance.BorderSize = 0
        Me.btnSeleciona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeleciona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleciona.ForeColor = System.Drawing.Color.Black
        Me.btnSeleciona.Image = CType(resources.GetObject("btnSeleciona.Image"), System.Drawing.Image)
        Me.btnSeleciona.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeleciona.Location = New System.Drawing.Point(243, 144)
        Me.btnSeleciona.Name = "btnSeleciona"
        Me.btnSeleciona.Size = New System.Drawing.Size(43, 41)
        Me.btnSeleciona.TabIndex = 54
        Me.btnSeleciona.TabStop = False
        Me.btnSeleciona.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSeleciona.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSeleciona.UseVisualStyleBackColor = False
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
        Me.btnVolta.Location = New System.Drawing.Point(9, 7)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(100, 41)
        Me.btnVolta.TabIndex = 1
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'lstGrupos
        '
        Me.lstGrupos.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstGrupos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CodigoGrupo, Me.Grupo})
        Me.lstGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGrupos.ForeColor = System.Drawing.Color.Blue
        Me.lstGrupos.FullRowSelect = True
        Me.lstGrupos.GridLines = True
        Me.lstGrupos.HideSelection = False
        Me.lstGrupos.Location = New System.Drawing.Point(8, 102)
        Me.lstGrupos.MultiSelect = False
        Me.lstGrupos.Name = "lstGrupos"
        Me.lstGrupos.Size = New System.Drawing.Size(221, 432)
        Me.lstGrupos.TabIndex = 36
        Me.lstGrupos.UseCompatibleStateImageBehavior = False
        Me.lstGrupos.View = System.Windows.Forms.View.Details
        '
        'CodigoGrupo
        '
        Me.CodigoGrupo.Text = "CodigoGrupo"
        Me.CodigoGrupo.Width = 0
        '
        'Grupo
        '
        Me.Grupo.Text = "Grupo"
        Me.Grupo.Width = 200
        '
        'lstGruposSelecionados
        '
        Me.lstGruposSelecionados.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstGruposSelecionados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstGruposSelecionados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDGrupoPedidos, Me.GrupoPedidos})
        Me.lstGruposSelecionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGruposSelecionados.ForeColor = System.Drawing.Color.Blue
        Me.lstGruposSelecionados.FullRowSelect = True
        Me.lstGruposSelecionados.GridLines = True
        Me.lstGruposSelecionados.HideSelection = False
        Me.lstGruposSelecionados.Location = New System.Drawing.Point(300, 102)
        Me.lstGruposSelecionados.MultiSelect = False
        Me.lstGruposSelecionados.Name = "lstGruposSelecionados"
        Me.lstGruposSelecionados.Size = New System.Drawing.Size(221, 432)
        Me.lstGruposSelecionados.TabIndex = 37
        Me.lstGruposSelecionados.UseCompatibleStateImageBehavior = False
        Me.lstGruposSelecionados.View = System.Windows.Forms.View.Details
        '
        'IDGrupoPedidos
        '
        Me.IDGrupoPedidos.Text = "IDGrupo"
        Me.IDGrupoPedidos.Width = 0
        '
        'GrupoPedidos
        '
        Me.GrupoPedidos.Text = "Grupo"
        Me.GrupoPedidos.Width = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 18)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Grupos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(297, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 18)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Grupos selecionados"
        '
        'btnExclui
        '
        Me.btnExclui.BackColor = System.Drawing.Color.White
        Me.btnExclui.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExclui.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnExclui.FlatAppearance.BorderSize = 0
        Me.btnExclui.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExclui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExclui.ForeColor = System.Drawing.Color.Black
        Me.btnExclui.Image = CType(resources.GetObject("btnExclui.Image"), System.Drawing.Image)
        Me.btnExclui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExclui.Location = New System.Drawing.Point(243, 200)
        Me.btnExclui.Name = "btnExclui"
        Me.btnExclui.Size = New System.Drawing.Size(43, 41)
        Me.btnExclui.TabIndex = 55
        Me.btnExclui.TabStop = False
        Me.btnExclui.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExclui.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnExclui.UseVisualStyleBackColor = False
        '
        'fdlgGruposPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(530, 541)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExclui)
        Me.Controls.Add(Me.btnSeleciona)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstGruposSelecionados)
        Me.Controls.Add(Me.lstGrupos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgGruposPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grupos Pedidos"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSeleciona As Button
    Friend WithEvents btnVolta As Button
    Friend WithEvents lstGrupos As ListView
    Friend WithEvents CodigoGrupo As ColumnHeader
    Friend WithEvents Grupo As ColumnHeader
    Friend WithEvents lstGruposSelecionados As ListView
    Friend WithEvents IDGrupoPedidos As ColumnHeader
    Friend WithEvents GrupoPedidos As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnExclui As Button
End Class
