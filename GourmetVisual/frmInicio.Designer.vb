<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicio))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarInicio = New System.Windows.Forms.ProgressBar()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbErro1 = New System.Windows.Forms.Label()
        Me.lbErro2 = New System.Windows.Forms.Label()
        Me.lbVersao = New System.Windows.Forms.Label()
        Me.tbFoco = New System.Windows.Forms.TextBox()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(542, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Iniciando o software"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'BarInicio
        '
        Me.BarInicio.Location = New System.Drawing.Point(12, 173)
        Me.BarInicio.Name = "BarInicio"
        Me.BarInicio.Size = New System.Drawing.Size(542, 10)
        Me.BarInicio.TabIndex = 1
        Me.BarInicio.Visible = False
        '
        'lbStatus
        '
        Me.lbStatus.BackColor = System.Drawing.Color.Transparent
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbStatus.Location = New System.Drawing.Point(12, 186)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(542, 23)
        Me.lbStatus.TabIndex = 2
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lbErro1
        '
        Me.lbErro1.BackColor = System.Drawing.Color.Transparent
        Me.lbErro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbErro1.ForeColor = System.Drawing.Color.DarkRed
        Me.lbErro1.Location = New System.Drawing.Point(12, 215)
        Me.lbErro1.Name = "lbErro1"
        Me.lbErro1.Size = New System.Drawing.Size(542, 54)
        Me.lbErro1.TabIndex = 3
        Me.lbErro1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbErro2
        '
        Me.lbErro2.BackColor = System.Drawing.Color.Transparent
        Me.lbErro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbErro2.ForeColor = System.Drawing.Color.Yellow
        Me.lbErro2.Location = New System.Drawing.Point(12, 274)
        Me.lbErro2.Name = "lbErro2"
        Me.lbErro2.Size = New System.Drawing.Size(542, 134)
        Me.lbErro2.TabIndex = 4
        Me.lbErro2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbVersao
        '
        Me.lbVersao.BackColor = System.Drawing.Color.Transparent
        Me.lbVersao.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbVersao.Location = New System.Drawing.Point(400, 408)
        Me.lbVersao.Name = "lbVersao"
        Me.lbVersao.Size = New System.Drawing.Size(163, 19)
        Me.lbVersao.TabIndex = 7
        Me.lbVersao.Text = "3.7.4"
        Me.lbVersao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbFoco
        '
        Me.tbFoco.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.tbFoco.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbFoco.Location = New System.Drawing.Point(4, 48)
        Me.tbFoco.Name = "tbFoco"
        Me.tbFoco.Size = New System.Drawing.Size(0, 13)
        Me.tbFoco.TabIndex = 0
        Me.tbFoco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnConfig
        '
        Me.btnConfig.BackColor = System.Drawing.Color.White
        Me.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfig.ForeColor = System.Drawing.Color.Blue
        Me.btnConfig.Image = Global.GourmetVisual.My.Resources.Resources.Tool
        Me.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfig.Location = New System.Drawing.Point(2, 2)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(41, 40)
        Me.btnConfig.TabIndex = 20
        Me.btnConfig.TabStop = False
        Me.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfig.UseVisualStyleBackColor = False
        Me.btnConfig.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(76, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(418, 129)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label2.Location = New System.Drawing.Point(0, 407)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 19)
        Me.Label2.TabIndex = 21
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'frmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ClientSize = New System.Drawing.Size(566, 428)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.tbFoco)
        Me.Controls.Add(Me.lbVersao)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbErro2)
        Me.Controls.Add(Me.lbErro1)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.BarInicio)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInicio"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BarInicio As ProgressBar
    Friend WithEvents lbStatus As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lbErro1 As Label
    Friend WithEvents lbErro2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbVersao As Label
    Friend WithEvents tbFoco As TextBox
    Friend WithEvents btnConfig As Button
    Friend WithEvents Label2 As Label
End Class
