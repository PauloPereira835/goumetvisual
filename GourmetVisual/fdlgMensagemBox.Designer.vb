<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgMensagemBox
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.lbMensagem = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnSim = New System.Windows.Forms.Button()
        Me.btnNao = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbTempo = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.tbTempoInicio = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox)
        Me.Panel1.Controls.Add(Me.lbMensagem)
        Me.Panel1.Location = New System.Drawing.Point(12, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 162)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox
        '
        Me.PictureBox.Image = Global.GourmetVisual.My.Resources.Resources.exclamacao
        Me.PictureBox.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(120, 120)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 4
        Me.PictureBox.TabStop = False
        '
        'lbMensagem
        '
        Me.lbMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensagem.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbMensagem.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbMensagem.Location = New System.Drawing.Point(127, 3)
        Me.lbMensagem.Name = "lbMensagem"
        Me.lbMensagem.Size = New System.Drawing.Size(267, 152)
        Me.lbMensagem.TabIndex = 0
        Me.lbMensagem.Text = "Label1"
        Me.lbMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.MintCream
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Green
        Me.btnOK.Location = New System.Drawing.Point(250, 221)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(163, 55)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK, entendi"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnSim
        '
        Me.btnSim.BackColor = System.Drawing.Color.Azure
        Me.btnSim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSim.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSim.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSim.ForeColor = System.Drawing.Color.Blue
        Me.btnSim.Location = New System.Drawing.Point(250, 221)
        Me.btnSim.Name = "btnSim"
        Me.btnSim.Size = New System.Drawing.Size(163, 55)
        Me.btnSim.TabIndex = 0
        Me.btnSim.Text = "Sim"
        Me.btnSim.UseVisualStyleBackColor = False
        '
        'btnNao
        '
        Me.btnNao.BackColor = System.Drawing.Color.Snow
        Me.btnNao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNao.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnNao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNao.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNao.Location = New System.Drawing.Point(12, 221)
        Me.btnNao.Name = "btnNao"
        Me.btnNao.Size = New System.Drawing.Size(163, 55)
        Me.btnNao.TabIndex = 2
        Me.btnNao.Text = "Não"
        Me.btnNao.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.GourmetVisual.My.Resources.Resources.Logo_Gourmet_menu_menor
        Me.PictureBox1.Location = New System.Drawing.Point(14, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(103, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'lbTempo
        '
        Me.lbTempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTempo.ForeColor = System.Drawing.Color.Brown
        Me.lbTempo.Location = New System.Drawing.Point(265, -7)
        Me.lbTempo.Name = "lbTempo"
        Me.lbTempo.Size = New System.Drawing.Size(163, 56)
        Me.lbTempo.TabIndex = 4
        Me.lbTempo.Text = "10"
        Me.lbTempo.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbTempo.Visible = False
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'tbTempoInicio
        '
        Me.tbTempoInicio.Location = New System.Drawing.Point(286, 12)
        Me.tbTempoInicio.Name = "tbTempoInicio"
        Me.tbTempoInicio.Size = New System.Drawing.Size(45, 20)
        Me.tbTempoInicio.TabIndex = 5
        Me.tbTempoInicio.Visible = False
        '
        'fdlgMensagemBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(423, 284)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbTempoInicio)
        Me.Controls.Add(Me.lbTempo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnNao)
        Me.Controls.Add(Me.btnSim)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "fdlgMensagemBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbMensagem As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnSim As Button
    Friend WithEvents btnNao As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents lbTempo As Label
    Friend WithEvents Timer As Timer
    Friend WithEvents tbTempoInicio As TextBox
End Class
