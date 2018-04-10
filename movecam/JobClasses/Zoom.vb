Public Class Zoom
    Private _delta As Double = 1
    Private Pinit As Point = New Point(0, 0)
    Private Pcurrent As Point = New Point(0, 0)
    Private ScreenArea As Rectangle = New Rectangle(0, 0, 100, 100)


    Public Sub New()

    End Sub

    Public Sub New(zoomArea As Rectangle)
        ScreenArea = zoomArea
    End Sub

    Public Sub New(x0 As Integer, y0 As Integer, x1 As Integer, y1 As Integer)
        ScreenArea = New Rectangle(x0, y0, x1, y1)
    End Sub

    Public Property delta As Double
        Get
            Return _delta
        End Get
        Set(value As Double)
            _delta = value
        End Set
    End Property

    Public Property ScreenArea1 As Rectangle
        Get
            Return ScreenArea
        End Get
        Set(value As Rectangle)
            ScreenArea = value
        End Set
    End Property

    Public Sub changeZoom(newDelta As Double)
        Dim kx As Double
        Dim ky As Double

        kx = (2 * ScreenArea.X + ScreenArea.Width) / 2
        ky = (2 * ScreenArea.Y - ScreenArea.Height) / 2
        Pcurrent.X = Pinit.X + (1 - newDelta) * kx
        Pcurrent.Y = Pinit.Y - (1 - newDelta) * ky
        delta = newDelta

    End Sub


    Public Function getXScreen(xReal As Double) As Single
        Return delta * xReal + Pcurrent.X
    End Function
    Public Function getYScreen(yReal As Double) As Single
        Return delta * yReal + Pcurrent.Y
    End Function
    Public Function getScreenPoint(realPoint As Point) As Point

        Return New Point(getXScreen(realPoint.X), getYScreen(realPoint.Y))

    End Function

    Public Function getXReal(xScreen As Double) As Double
        Return (xScreen - Pcurrent.X) / delta
    End Function
    Public Function getYReal(yScreen As Double) As Double
        Return (yScreen - Pcurrent.Y) / delta
    End Function
    Public Function getRealPoint(realPoint As Point) As Point

        Return New Point(getXReal(realPoint.X), getYReal(realPoint.Y))
    End Function

End Class
