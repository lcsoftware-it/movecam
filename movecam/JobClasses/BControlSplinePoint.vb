Imports movecam

Public Class BControlSplinePoint
    Private _P As ControlPoint
    Private _dr As ControlPoint
    Private _dl As ControlPoint

    Private _simmetric As Boolean
    Private _mainColor As Color
    Private _controlColor As Color


    Public Sub New(p1 As Point, inj As Injector)
        _P = New ControlPoint(p1, ControlPoint.PointControlTypeEnum.Control)
        _dr = New ControlPoint(p1, ControlPoint.PointControlTypeEnum.ControlAngular)
        _dl = New ControlPoint(p1, ControlPoint.PointControlTypeEnum.ControlAngular)
        _controlColor = Color.Red
    End Sub

    Public Sub New(p1 As xyPoint)
        _P = p1
        _dr = New ControlPoint(p1.P, ControlPoint.PointControlTypeEnum.ControlAngular)
        _dl = New ControlPoint(p1.P, ControlPoint.PointControlTypeEnum.ControlAngular)
        _controlColor = Color.Red
    End Sub

    Public Property P As xyPoint
        Get
            Return _P
        End Get
        Set(value As xyPoint)
            _P = value
        End Set
    End Property

    Public Property Dr As xyPoint
        Get
            Return _dr
        End Get
        Set(value As xyPoint)
            _dr = value
        End Set
    End Property

    Public Property Dl As xyPoint
        Get
            Return _dl
        End Get
        Set(value As xyPoint)
            _dl = value
        End Set
    End Property

    Public Property LeftSelected As Boolean
        Get
            Return _dl.Selected
        End Get
        Set(value As Boolean)
            _dl.Selected = value
        End Set
    End Property

    Public Property RightSelected As Boolean
        Get
            Return _dr.Selected
        End Get
        Set(value As Boolean)
            _dr.Selected = value
        End Set
    End Property

    Public Property CenterSelected As Boolean
        Get
            Return _P.Selected
        End Get
        Set(value As Boolean)
            _P.Selected = value
        End Set
    End Property

    Public Property MainColor As Color
        Get
            Return _mainColor
        End Get
        Set(value As Color)
            _mainColor = value
        End Set
    End Property

    Public Property ControlColor As Color
        Get
            Return _controlColor
        End Get
        Set(value As Color)
            _controlColor = value
        End Set
    End Property

    Public Property Simmetric As Boolean
        Get
            Return _simmetric
        End Get
        Set(value As Boolean)
            _simmetric = value
        End Set
    End Property

    Public Sub draw(gc As GraphicContest)
        Dim virtualInj As Injector = New Injector(99)
        _P.draw(gc, virtualInj)
        Dim pen As Pen
        pen = New Pen(_controlColor)

        Dim brush As Brush
        brush = New SolidBrush(_controlColor)
        Dim p1 As Point
        p1.X = _P.X - 3
        p1.Y = _P.Y + 3
        Dim p2 As Point
        p2.X = _P.X + 3
        p2.Y = _P.Y - 3
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))

        p1.X = _P.X + 3
        p1.Y = _P.Y + 3
        p2.X = _P.X - 3
        p2.Y = _P.Y - 3
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))

        p1.X = _P.X + _dr.X
        p1.Y = _P.Y + _dr.Y
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(_P.P), gc.Zoom.getScreenPoint(p1))
        If Not Simmetric Then

            gc.G.FillEllipse(brush, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        Else
            gc.G.DrawEllipse(pen, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        End If
        p1.X = _P.X - _dl.X
        p1.Y = _P.Y - _dl.Y
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(_P.P), gc.Zoom.getScreenPoint(p1))
        If Not Simmetric Then
            gc.G.FillEllipse(brush, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        Else
            gc.G.DrawEllipse(pen, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        End If

    End Sub
    Public Sub drawStart(gc As GraphicContest)
        Dim virtualInj As Injector = New Injector(99)
        _P.draw(gc, virtualInj)
        Dim pen As Pen
        pen = New Pen(_controlColor)

        Dim brush As Brush
        brush = New SolidBrush(_controlColor)
        Dim p1 As Point
        p1.X = _P.X - 3
        p1.Y = _P.Y + 3
        Dim p2 As Point
        p2.X = _P.X + 3
        p2.Y = _P.Y - 3
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))

        p1.X = _P.X + 3
        p1.Y = _P.Y + 3
        p2.X = _P.X - 3
        p2.Y = _P.Y - 3
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))

        p1.X = _P.X - _dl.X
        p1.Y = _P.Y - _dl.Y
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(_P.P), gc.Zoom.getScreenPoint(p1))
        If Not Simmetric Then
            gc.G.FillEllipse(brush, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        Else
            gc.G.DrawEllipse(pen, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        End If

    End Sub
    Public Sub drawEnd(gc As GraphicContest)
        Dim virtualInj As Injector = New Injector(99)
        _P.draw(gc, virtualInj)
        Dim pen As Pen
        pen = New Pen(_controlColor)

        Dim brush As Brush
        brush = New SolidBrush(_controlColor)
        Dim p1 As Point
        p1.X = _P.X - 3
        p1.Y = _P.Y + 3
        Dim p2 As Point
        p2.X = _P.X + 3
        p2.Y = _P.Y - 3
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))

        p1.X = _P.X + 3
        p1.Y = _P.Y + 3
        p2.X = _P.X - 3
        p2.Y = _P.Y - 3
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(p1), gc.Zoom.getScreenPoint(p2))

        p1.X = _P.X + _dr.X
        p1.Y = _P.Y + _dr.Y
        gc.G.DrawLine(pen, gc.Zoom.getScreenPoint(_P.P), gc.Zoom.getScreenPoint(p1))
        If Not Simmetric Then
            gc.G.FillEllipse(brush, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        Else
            gc.G.DrawEllipse(pen, gc.Zoom.getXScreen(p1.X) - 3, gc.Zoom.getYScreen(p1.Y) - 3, 6, 6)
        End If

    End Sub

End Class
