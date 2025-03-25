<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fdlgConsultaCEP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgConsultaCEP))
        Me.btnVolta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbLogradouro = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbBairro = New System.Windows.Forms.TextBox()
        Me.btnAtualiza = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbCidade = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbEstado = New System.Windows.Forms.TextBox()
        Me.lstRuas = New System.Windows.Forms.ListView()
        Me.IDRua = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Logradouro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Complemento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bairro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CEP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbTotalCEP = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCadastrar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.btnVolta.Image = Global.GourmetVisual.My.Resources.Resources.Back
        Me.btnVolta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolta.Location = New System.Drawing.Point(7, 6)
        Me.btnVolta.Name = "btnVolta"
        Me.btnVolta.Size = New System.Drawing.Size(92, 41)
        Me.btnVolta.TabIndex = 2
        Me.btnVolta.TabStop = False
        Me.btnVolta.Text = "&Voltar"
        Me.btnVolta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVolta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVolta.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Busca Lougradouro"
        '
        'tbLogradouro
        '
        Me.tbLogradouro.Location = New System.Drawing.Point(115, 9)
        Me.tbLogradouro.Name = "tbLogradouro"
        Me.tbLogradouro.Size = New System.Drawing.Size(285, 20)
        Me.tbLogradouro.TabIndex = 0
        Me.tbLogradouro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Resultado"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel1.Controls.Add(Me.tbBairro)
        Me.Panel1.Controls.Add(Me.btnAtualiza)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.lstRuas)
        Me.Panel1.Controls.Add(Me.lbTotalCEP)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnCadastrar)
        Me.Panel1.Controls.Add(Me.btnVolta)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(5, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 576)
        Me.Panel1.TabIndex = 15
        Me.Panel1.TabStop = True
        '
        'tbBairro
        '
        Me.tbBairro.Location = New System.Drawing.Point(712, 56)
        Me.tbBairro.Name = "tbBairro"
        Me.tbBairro.Size = New System.Drawing.Size(29, 20)
        Me.tbBairro.TabIndex = 24
        Me.tbBairro.TabStop = False
        Me.tbBairro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbBairro.Visible = False
        '
        'btnAtualiza
        '
        Me.btnAtualiza.BackColor = System.Drawing.Color.White
        Me.btnAtualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAtualiza.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAtualiza.FlatAppearance.BorderSize = 0
        Me.btnAtualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtualiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtualiza.ForeColor = System.Drawing.Color.Black
        Me.btnAtualiza.Image = CType(resources.GetObject("btnAtualiza.Image"), System.Drawing.Image)
        Me.btnAtualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtualiza.Location = New System.Drawing.Point(712, 6)
        Me.btnAtualiza.Name = "btnAtualiza"
        Me.btnAtualiza.Size = New System.Drawing.Size(92, 41)
        Me.btnAtualiza.TabIndex = 68
        Me.btnAtualiza.TabStop = False
        Me.btnAtualiza.Text = "Atualizar"
        Me.btnAtualiza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAtualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAtualiza.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.tbLogradouro)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.tbCidade)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.btnConsulta)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.tbEstado)
        Me.Panel3.Location = New System.Drawing.Point(189, 8)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(510, 68)
        Me.Panel3.TabIndex = 67
        Me.Panel3.TabStop = True
        '
        'tbCidade
        '
        Me.tbCidade.Location = New System.Drawing.Point(115, 35)
        Me.tbCidade.Name = "tbCidade"
        Me.tbCidade.Size = New System.Drawing.Size(240, 20)
        Me.tbCidade.TabIndex = 20
        Me.tbCidade.TabStop = False
        Me.tbCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(9, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Cidade/Estado"
        '
        'btnConsulta
        '
        Me.btnConsulta.BackColor = System.Drawing.Color.White
        Me.btnConsulta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConsulta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.ForeColor = System.Drawing.Color.Black
        Me.btnConsulta.Image = CType(resources.GetObject("btnConsulta.Image"), System.Drawing.Image)
        Me.btnConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsulta.Location = New System.Drawing.Point(406, 8)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(92, 48)
        Me.btnConsulta.TabIndex = 23
        Me.btnConsulta.TabStop = False
        Me.btnConsulta.Text = "Consultar"
        Me.btnConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsulta.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(357, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "/"
        '
        'tbEstado
        '
        Me.tbEstado.Location = New System.Drawing.Point(371, 36)
        Me.tbEstado.Name = "tbEstado"
        Me.tbEstado.Size = New System.Drawing.Size(29, 20)
        Me.tbEstado.TabIndex = 22
        Me.tbEstado.TabStop = False
        Me.tbEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstRuas
        '
        Me.lstRuas.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstRuas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstRuas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDRua, Me.Logradouro, Me.Complemento, Me.Bairro, Me.CEP})
        Me.lstRuas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRuas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lstRuas.FullRowSelect = True
        Me.lstRuas.GridLines = True
        Me.lstRuas.HideSelection = False
        Me.lstRuas.Location = New System.Drawing.Point(17, 116)
        Me.lstRuas.MultiSelect = False
        Me.lstRuas.Name = "lstRuas"
        Me.lstRuas.Size = New System.Drawing.Size(879, 445)
        Me.lstRuas.TabIndex = 65
        Me.lstRuas.TabStop = False
        Me.lstRuas.UseCompatibleStateImageBehavior = False
        Me.lstRuas.View = System.Windows.Forms.View.Details
        '
        'IDRua
        '
        Me.IDRua.Text = "IDRua"
        Me.IDRua.Width = 0
        '
        'Logradouro
        '
        Me.Logradouro.Text = "Logradouro"
        Me.Logradouro.Width = 320
        '
        'Complemento
        '
        Me.Complemento.Text = "Complemento"
        Me.Complemento.Width = 240
        '
        'Bairro
        '
        Me.Bairro.Text = "Bairro"
        Me.Bairro.Width = 195
        '
        'CEP
        '
        Me.CEP.Text = "CEP"
        Me.CEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CEP.Width = 100
        '
        'lbTotalCEP
        '
        Me.lbTotalCEP.BackColor = System.Drawing.Color.Transparent
        Me.lbTotalCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalCEP.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalCEP.Location = New System.Drawing.Point(807, 99)
        Me.lbTotalCEP.Name = "lbTotalCEP"
        Me.lbTotalCEP.Size = New System.Drawing.Size(89, 14)
        Me.lbTotalCEP.TabIndex = 64
        Me.lbTotalCEP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(17, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(879, 3)
        Me.Panel2.TabIndex = 16
        '
        'btnCadastrar
        '
        Me.btnCadastrar.BackColor = System.Drawing.Color.White
        Me.btnCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCadastrar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCadastrar.FlatAppearance.BorderSize = 0
        Me.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCadastrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCadastrar.ForeColor = System.Drawing.Color.Black
        Me.btnCadastrar.Image = Global.GourmetVisual.My.Resources.Resources.Plus1
        Me.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCadastrar.Location = New System.Drawing.Point(815, 6)
        Me.btnCadastrar.Name = "btnCadastrar"
        Me.btnCadastrar.Size = New System.Drawing.Size(92, 41)
        Me.btnCadastrar.TabIndex = 15
        Me.btnCadastrar.TabStop = False
        Me.btnCadastrar.Text = "Cadastrar"
        Me.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCadastrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCadastrar.UseVisualStyleBackColor = False
        '
        'fdlgConsultaCEP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaGreen
        Me.ClientSize = New System.Drawing.Size(927, 587)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fdlgConsultaCEP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta CEP"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVolta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tbLogradouro As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnConsulta As Button
    Friend WithEvents tbEstado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tbCidade As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbTotalCEP As Label
    Friend WithEvents lstRuas As ListView
    Friend WithEvents IDRua As ColumnHeader
    Friend WithEvents Logradouro As ColumnHeader
    Friend WithEvents Complemento As ColumnHeader
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Bairro As ColumnHeader
    Friend WithEvents CEP As ColumnHeader
    Friend WithEvents btnAtualiza As Button
    Friend WithEvents btnCadastrar As Button
    Friend WithEvents tbBairro As TextBox
End Class
