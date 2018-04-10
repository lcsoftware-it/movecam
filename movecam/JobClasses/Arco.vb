Imports System.Drawing.Drawing2D
Imports movecam

Public Class Arco
    Inherits InjElement
    Implements Serializable


    Private _nSegments As Integer
    Private _p1 As ControlPoint
    Private _p2 As ControlPoint
    Private _p3 As ControlPoint
    Private _selectedp1 As Boolean
    Private _selectedp2 As Boolean
    Private _selectedp3 As Boolean
    Private _center As ControlPoint
    Private _radius As Single
    Private _startAngle As Single
    Private _endAngle As Single
    Private _centerSelected As Boolean
    Private _orario As Boolean = True



    Public Property nSegments() As Integer
        Get
            Return _nSegments
        End Get
        Set(ByVal value As Integer)
            _nSegments = value
        End Set
    End Property

    Public Property radius() As Single
        Get
            Return _radius
        End Get
        Set(ByVal value As Single)
            _radius = value
        End Set
    End Property
    Public Property Center() As xyPoint
        Get
            Return _center
        End Get
        Set(ByVal value As xyPoint)
            _center = value
        End Set
    End Property
    Public Property P1() As xyPoint
        Get
            Return _p1
        End Get
        Set(ByVal value As xyPoint)
            _p1 = value
        End Set
    End Property

    Public Property P2() As xyPoint
        Get
            Return _p2
        End Get
        Set(ByVal value As xyPoint)
            _p2 = value
        End Set
    End Property

    Public Property P3() As xyPoint
        Get
            Return _p3
        End Get
        Set(ByVal value As xyPoint)
            _p3 = value
        End Set
    End Property

    Public Property StartAngle() As Single
        Get
            Return _startAngle
        End Get
        Set(ByVal value As Single)
            _startAngle = value
        End Set
    End Property

    Public Property EndAngle() As Single
        Get
            Return _endAngle
        End Get
        Set(ByVal value As Single)
            _endAngle = value
        End Set
    End Property
    Public ReadOnly Property selectedP1() As Boolean
        Get
            Return _selectedp1
        End Get
    End Property
    Public ReadOnly Property selectedP2() As Boolean
        Get
            Return _selectedp2
        End Get
    End Property
    Public ReadOnly Property selectedP3() As Boolean
        Get
            Return _selectedp3
        End Get
    End Property

    Public Sub New(ByVal P1 As MousePoint, ByVal P2 As MousePoint, ByVal P3 As MousePoint, inj As Injector)
        _p1 = P1.toControlPoint()
        _p2 = P2.toControlPoint()
        _p3 = P3.toControlPoint()
        _inj = inj
        drawThreePoints()
    End Sub
    Public Overrides Function addPoint(p As MousePoint) As Boolean
        Throw New NotImplementedException
    End Function
    Public Overrides Function getSelectedPoint() As xyPoint
        If selectedP1 Then Return P1
        If selectedP2 Then Return P2
        If selectedP3 Then Return P3
        Return Nothing
    End Function
    Public Overrides Function findPoint(p As MousePoint) As xyPoint
        If Not _p1.findPoint(p) Is Nothing Then
            Return _p1
        End If
        If Not _p2.findPoint(p) Is Nothing Then
            Return _p2
        End If
        If Not _p3.findPoint(p) Is Nothing Then
            Return _p3
        End If
        Return Nothing
    End Function
    Public Sub drawThreePoints()
        solve()
        _radius = Math.Sqrt((_center.X - _p1.X) ^ 2 + (_center.Y - _p1.Y) ^ 2)
        Dim a1 As Double = getAngle(_center.P, _p1.P) * 180 / Math.PI
        Dim a2 As Double = getAngle(_center.P, _p2.P) * 180 / Math.PI
        Dim a3 As Double = getAngle(_center.P, _p3.P) * 180 / Math.PI
        If (a1 < a2 And a2 < a3) Then
            'strCommento = "a1->a2->a3"
            StartAngle = a1
            EndAngle = a3
        End If
        If (a1 < a3 And a3 < a2) Then
            'strCommento = "a1->a3->a2"
            StartAngle = a3
            EndAngle = a1 + 360
        End If
        If (a2 < a1 And a1 < a3) Then
            'strCommento = "a2->a1->a3"
            StartAngle = a3
            EndAngle = a1 + 360
        End If
        If (a2 < a3 And a3 < a1) Then
            'strCommento = "a2->a3->a1"
            StartAngle = a1
            EndAngle = a3 + 360
        End If
        If (a3 < a1 And a1 < a2) Then
            'strCommento = "a3->a1->a2"
            StartAngle = a1
            EndAngle = a3 + 360
        End If
        If (a3 < a2 And a2 < a1) Then
            'strCommento = "a3->a2->a1"
            StartAngle = a3
            EndAngle = a1
        End If
        _nSegments = 12
        injPoint = New List(Of InjPoint)
    End Sub

    Public Sub New(center As MousePoint, radius As Double, inj As Injector)
        _startAngle = 0
        _endAngle = 360
        _center = center.toControlPoint()
        _radius = radius

        nSegments = 12
        injPoint = New List(Of InjPoint)
        segment()
    End Sub

    Private Sub solve()
        Dim d1 As Single
        Dim coeff(2, 2) As Single

        coeff(0, 0) = P1.X
        coeff(0, 1) = P1.Y
        coeff(0, 2) = 1

        coeff(1, 0) = P2.X
        coeff(1, 1) = P2.Y
        coeff(1, 2) = 1

        coeff(2, 0) = P3.X
        coeff(2, 1) = P3.Y
        coeff(2, 2) = 1

        Dim A As Matrix

        A = New Matrix(coeff)

        Dim b(2) As Single

        b(0) = -(P1.X * P1.X + P1.Y * P1.Y)
        b(1) = -(P2.X * P2.X + P2.Y * P2.Y)
        b(2) = -(P3.X * P3.X + P3.Y * P3.Y)

        d1 = A.determinant()

        If (d1 <> 0) Then
            Dim ls As LinearSystem
            Dim x As Single()
            ls = New LinearSystem(A, b)
            x = ls.solve()

            '_center = New xyPoint(New Point(-x(0) / 2, -x(1) / 2), xyPoint.PointInjStateEnum.Inject, xyPoint.PointDrawTypeEnum.Control, Color.Black)
            _center = New ControlPoint(New Point(-x(0) / 2, -x(1) / 2), ControlPoint.PointControlTypeEnum.Center)
            _radius = Math.Sqrt(x(2) - _center.X ^ 2 - Center.Y ^ 2)
        End If

    End Sub
    Private Sub segment()
        Dim i As Integer
        Dim delta As Single
        'If Not _orario Then
        'delta = -(360 - (_endAngle - _startAngle)) / _nSegments
        'Else
        delta = (_endAngle - _startAngle) / _nSegments
        'End If
        If _nSegments <> (injPoint.Count - 1) Then
            injPoint.Clear()
            Dim currentAngle As Single
            For i = 0 To _nSegments
                currentAngle = (StartAngle + delta * i) / 180 * Math.PI
                Dim dp As Point = New Point()

                dp.X = Center.X + radius * Math.Cos(currentAngle)
                dp.Y = Center.Y + radius * Math.Sin(currentAngle)

                injPoint.Add(New InjPoint(dp, True, False))
                'injPoint.Add(New xyPoint(dp, xyPoint.PointInjStateEnum.Inject, xyPoint.PointDrawTypeEnum.Injection, Color.Black))
            Next
            currentAngle = currentAngle * 180 / Math.PI
            If Math.Abs(currentAngle - EndAngle) > 0.05 Then
                currentAngle = currentAngle + 1
            End If

        Else
            For i = 0 To _nSegments
                Dim currentAngle As Single = (StartAngle + delta * i) / 180 * Math.PI
                Dim dp As xyPoint = injPoint(i)

                dp.X = Center.X + radius * Math.Cos(currentAngle)
                dp.Y = Center.Y + radius * Math.Sin(currentAngle)

            Next
        End If

    End Sub
    Public Overrides Sub draw(gc As GraphicContest)
        Dim p As Pen

        Dim rectWidth = 5

        p = New Pen(_inj.Colore, 1)
        If (radius > 0) Then
            Center.draw(gc, _inj)
            Dim lt As Point
            lt.X = Center.X - radius
            lt.Y = Center.Y - radius
            Dim dashValues As Single() = {1, 3}
            p.DashPattern = dashValues

            Dim w As Double
            w = p.Width
            p.Width = 1
            'g.DrawArc(p, lt.X * currentZoom, lt.Y * currentZoom, radius * 2 * currentZoom, radius * 2 * currentZoom, _startAngle, _endAngle - _startAngle)
            gc.G.DrawArc(p, gc.Zoom.getXScreen(lt.X), gc.Zoom.getYScreen(lt.Y), CSng(radius * 2 * gc.Zoom.delta), CSng(radius * 2 * gc.Zoom.delta), _startAngle, _endAngle - _startAngle)

            If (P1.X <> 0 Or P1.Y <> 0) Then
                gc.G.DrawLine(p, gc.Zoom.getScreenPoint(_center.P), gc.Zoom.getScreenPoint(P1.P))
                gc.G.DrawLine(p, gc.Zoom.getScreenPoint(_center.P), gc.Zoom.getScreenPoint(P3.P))
            End If
            segment()
            drawInjPath(gc)
        End If
    End Sub

    Public Function getMaxError() As Double
        Return _radius * (1 - Math.Cos(Math.PI / _nSegments))
    End Function

    Public Function getSegmentsRequired(maxError As Double) As Integer
        If maxError < _radius Then
            Return Math.PI / Math.Acos(1 - maxError / _radius)
        Else
            Return 1
        End If
    End Function

    Private Function getAngle(p1 As Point, p2 As Point) As Double
        Dim angle As Double
        angle = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X)
        While angle < 0
            angle = angle + 2 * Math.PI
        End While
        While angle > 2 * Math.PI
            angle = angle - 2 * Math.PI
        End While

        getAngle = angle
    End Function
    Public Overrides Function getLastInjPoint() As InjPoint
        If injPoint IsNot Nothing Then
            If injPoint.Last().X = P1.X And injPoint.Last().Y = P1.Y Then
                Return injPoint.First()
            Else
                Return injPoint.Last()
            End If

        Else
            Return Nothing
        End If
    End Function
    Public Overrides Sub moveSelectedPoint(p As MousePoint)
        Throw New NotImplementedException
    End Sub
    Public Sub unSelect()
        _selected = False
    End Sub

    Public Function serialize() As String Implements Serializable.serialize

        Dim s As String

        s = "AR*" + P1.serialize() + "*" + P2.serialize() + "*" + P3.serialize() + "*"
        For Each p As xyPoint In injPoint
            s = s + p.serialize() + "*"
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Sub deserialize(strVal As String) Implements Serializable.deserialize
        Dim arr() As String = strVal.Split("*")

        Dim p As Point = New Point(1, 1)
        P1 = New ControlPoint(p, ControlPoint.PointControlTypeEnum.Control)
        P1.deserialize(arr(1))
        P2 = New ControlPoint(p, ControlPoint.PointControlTypeEnum.Control)
        P2.deserialize(arr(2))
        P3 = New ControlPoint(p, ControlPoint.PointControlTypeEnum.Control)
        P3.deserialize(arr(3))
        drawThreePoints()
        nSegments = arr.Length - 4
    End Sub
End Class
