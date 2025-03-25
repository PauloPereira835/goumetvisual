Imports System.Drawing
Imports System.ComponentModel
Public Class SombraLabel
    Inherits Label

#Region "Properties"

    Private m_offsetX As Integer
    Private m_offsetY As Integer
    Private m_ForeColorFront As Color


    ''' <summary> 
    ''' Definição do offset em X 
    ''' </summary> 
    <DefaultValue(0)>
    <Category("Shadow")>
    <Description("Definição do offset em X")>
    Public Property OffsetX() As Integer
        Get
            Return m_offsetX
        End Get
        Set(ByVal value As Integer)
            m_offsetX = value
            Me.Invalidate()
        End Set
    End Property


    ''' <summary> 
    ''' Definição do offset em Y 
    ''' </summary> 
    <DefaultValue(-1)>
    <Category("Shadow")>
    <Description("Definição do offset em Y")>
    Public Property OffsetY() As Integer
        Get
            Return m_offsetY
        End Get
        Set(ByVal value As Integer)
            m_offsetY = value
            Me.Invalidate()
        End Set
    End Property


    ''' <summary> 
    ''' Definição da cor da frente 
    ''' </summary> 
    <DefaultValue(GetType(Color), "RoyalBlue")>
    <Category("Shadow")>
    <Description("Definição da cor da frente")>
    Public Property ForeColorFront() As Color
        Get
            Return m_ForeColorFront
        End Get
        Set(ByVal value As Color)
            m_ForeColorFront = value
            Me.Invalidate()
        End Set
    End Property


    ''' <summary> 
    ''' Definição da cor de sombreado 
    ''' </summary> 
    <DefaultValue(GetType(Color), "White")>
    <Category("Shadow")>
    <Description("Definição da cor de sombreado")>
    Public Property ForeColorBack() As Color
        Get
            Return Me.ForeColor
        End Get
        Set(ByVal value As Color)
            Me.ForeColor = value
            Me.Invalidate()
        End Set
    End Property



    ' Serve apenas para definir que a propriedade ForeColor 
    ' não está disponível para alterar no editor e no design 
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Overrides Property ForeColor() As System.Drawing.Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.ForeColor = value
        End Set
    End Property

#End Region


    ' Define algumas propriedades por defeito 
    Public Sub New()

        ' Definição dos valores iniciais de offset 
        Me.OffsetX = 0
        Me.OffsetY = -1

        ' Definição das cores iniciais do texto 
        Me.ForeColorFront = Color.RoyalBlue
        Me.ForeColorBack = Color.White

    End Sub


    ' No evento Paint desenha o texto 
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        MyBase.OnPaint(e)

        ' Desenha o texto que fica na frente 
        Dim BackBrush As New SolidBrush(Me.ForeColorFront)
        e.Graphics.DrawString(Me.Text, Me.Font, BackBrush, OffsetX, OffsetY, StringFormat.GenericDefault)
        BackBrush.Dispose()

    End Sub
End Class
