Public Class DrawStringOnPictureBoxParams

    Public [Text] As String 'Text displayed on PictureBox
    Public [PictureBox] As PictureBox 'PictureBox to draw to
    Public [MaxSize] As Single 'max font size
    Public [Font] As String 'font string
    Public [bgColor] As Color 'background color of picturebox
    Public [foreColor] As Color 'color of text drawn on picturebox
    Public [PixelFormat] As Drawing.Imaging.PixelFormat 'Pixel format of the image
    Public [StringFormat] As StringFormat 'String format (center and such)
    Public [LayoutSizeF] As SizeF 'Not sure...
    Public [BorderSize] As Single 'space between the text and the edge of the picturebox
    Public [X] As Integer 'x position to place text
    Public [Y] As Integer 'y position to place text

    Private Sub New()
        Me.Text = ""
        Me.PictureBox = Nothing
        Me.MaxSize = 72
        Me.Font = "Comic Sans MS"
        Me.bgColor = Color.Black
        Me.foreColor = Color.Red
        Me.PixelFormat = Drawing.Imaging.PixelFormat.Format24bppRgb
        Me.StringFormat = New StringFormat()
        Me.StringFormat.Alignment = StringAlignment.Center
        Me.StringFormat.LineAlignment = StringAlignment.Center
        Me.LayoutSizeF = New SizeF(1000, 1000)
        Me.BorderSize = 4
        Me.X = 0
        Me.Y = 0
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox)
        Me.New()
        Me.Text = txt
        Me.PictureBox = pb
        Me.X = Me.PictureBox.Width \ 2
        Me.Y = Me.PictureBox.Height \ 2
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single)
        Me.New(txt, pb)
        Me.MaxSize = maxSize
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String)
        Me.New(txt, pb, maxSize)
        Me.Font = font
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String, ByVal bgColour As Color, ByVal foreColour As Color)
        Me.New(txt, pb, maxSize, font)
        Me.bgColor = bgColour
        Me.foreColor = foreColour
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String, ByVal bgColour As Color, ByVal foreColour As Color, ByVal pFormat As Imaging.PixelFormat)
        Me.New(txt, pb, maxSize, font, bgColour, foreColour)
        Me.PixelFormat = pFormat
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String, ByVal bgColour As Color, ByVal foreColour As Color, ByVal pFormat As Imaging.PixelFormat, ByVal sFormat As StringFormat)
        Me.New(txt, pb, maxSize, font, bgColour, foreColour, pFormat)
        Me.StringFormat = sFormat
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String, ByVal bgColour As Color, ByVal foreColour As Color, ByVal pFormat As Imaging.PixelFormat, ByVal sFormat As StringFormat, ByVal layoutSize As SizeF)
        Me.New(txt, pb, maxSize, font, bgColour, foreColour, pFormat, sFormat)
        Me.LayoutSizeF = layoutSize
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String, ByVal bgColour As Color, ByVal foreColour As Color, ByVal pFormat As Imaging.PixelFormat, ByVal sFormat As StringFormat, ByVal layoutSize As SizeF, ByVal borderSize As Single)
        Me.New(txt, pb, maxSize, font, bgColour, foreColour, pFormat, sFormat, layoutSize)
        Me.BorderSize = borderSize
    End Sub

    Public Sub New(ByVal txt As String, ByRef pb As PictureBox, ByVal maxSize As Single, ByVal font As String, ByVal bgColour As Color, ByVal foreColour As Color, ByVal pFormat As Imaging.PixelFormat, ByVal sFormat As StringFormat, ByVal layoutSize As SizeF, ByVal borderSize As Single, ByVal x As Integer, ByVal y As Integer)
        Me.New(txt, pb, maxSize, font, bgColour, foreColour, pFormat, sFormat, layoutSize, borderSize)
        Me.X = x
        Me.Y = y
    End Sub
End Class