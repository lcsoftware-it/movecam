Imports movecam

Public Class BSpline
    Inherits InjElement
    Implements Serializable


    Private _controlPoints As List(Of ControlPoint)
    Private _clamped As Boolean
    Private _degree As Integer
    Private _nSegment As Integer
    Private _controlColor As Color
    Private _splineColor As Color


    Private needRecalc As Boolean
    Private delta As Integer = 3
    Private knots As List(Of Integer)



    Public Sub New(points As List(Of ControlPoint), degree As Integer, clamped As Boolean, nSegment As Integer, inj As Injector)
        _degree = degree
        _clamped = clamped
        _nSegment = nSegment
        ControlPoints = points
        needRecalc = True
        _inj = inj
        injPoint = New List(Of InjPoint)
    End Sub

    Public Property ControlPoints As List(Of ControlPoint)
        Get
            Return _controlPoints
        End Get
        Set(value As List(Of ControlPoint))
            _controlPoints = value
            needRecalc = True
        End Set
    End Property
    Public ReadOnly Property nPoints As Integer
        Get
            Return _controlPoints.Count
        End Get
    End Property
    Public Overrides Function getSelectedPoint() As xyPoint
        For Each pt In _controlPoints
            If pt.Selected Then
                Return pt
            End If
        Next
        Return Nothing
    End Function
    Public Overrides Function addPoint(p As MousePoint) As Boolean
        Dim cp As ControlPoint
        cp = New ControlPoint(p.p, ControlPoint.PointControlTypeEnum.Control)
        _controlPoints.Add(cp)
        needRecalc = True
        Return True
    End Function

    Public Function insertPointBefore(newPoint As xyPoint, pos As xyPoint) As Integer
        Dim insertIndex As Integer
        insertIndex = _controlPoints.IndexOf(pos)
        If (insertIndex < 0) Then insertIndex = 0
        _controlPoints.Insert(insertIndex, newPoint)
        needRecalc = True
        Return nPoints
    End Function
    Public Function removePoint(p As xyPoint) As Boolean
        needRecalc = True
        Return _controlPoints.Remove(p)
    End Function
    Public Function changePoint(pNew As xyPoint, pOld As xyPoint) As Boolean
        Dim i As Integer
        i = _controlPoints.IndexOf(pOld)
        _controlPoints.Remove(pOld)
        _controlPoints.Insert(i, pNew)
        needRecalc = True
        Return True
    End Function
    Public Property Clamped As Boolean
        Get
            Return _clamped
        End Get
        Set(value As Boolean)
            _clamped = value
            needRecalc = True
        End Set
    End Property

    Public Property Degree As Integer
        Get
            Return _degree
        End Get
        Set(value As Integer)
            _degree = value
            needRecalc = True
        End Set
    End Property

    Public Property NSegment As Integer
        Get
            Return _nSegment
        End Get
        Set(value As Integer)
            _nSegment = value
            needRecalc = True
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

    Public Property SplineColor As Color
        Get
            Return _splineColor
        End Get
        Set(value As Color)
            _splineColor = value
        End Set
    End Property



    Private Sub generateKnots()
        Dim n As Integer = nPoints

        knots = New List(Of Integer)(n + Degree + 1)

        If Clamped Then
            knots.Add(0)
            knots.Add(0)
            knots.Add(0)
            For i = 3 To n + Degree - 2
                knots.Add(i - 2)
            Next
            knots.Add(n + Degree - 4)
            knots.Add(n + Degree - 4)
            knots.Add(n + Degree - 4)
        Else
            For i = 0 To n + Degree
                knots.Add(i)
            Next
        End If
    End Sub


    Public Function getXY(t As Double) As Point

        Dim i, s, l As Integer 'function-scoped iteration variables
        Dim n As Integer = _controlPoints.Count 'points count

        If needRecalc Then
            recalc()
        End If
        'remap t to the domain where the spline Is defined
        Dim low As Integer = knots(Degree)
        Dim high As Integer = knots(knots.Count - 1 - Degree)
        t = t * (high - low) + low

        'find s (the spline segment) for the [t] value provided
        For s = Degree To knots.Count - 1 - Degree - 1
            If (t >= knots(s) And t <= knots(s + 1)) Then
                Exit For
            End If
        Next
        'If s > n - 1 Then s = n - 1

        Dim v As Point()
        ReDim v(n - 1)

        For i = 0 To n - 1
            v(i) = New Point()
            v(i).X = _controlPoints.ElementAt(i).X
            v(i).Y = _controlPoints.ElementAt(i).Y
        Next
        'l (level) goes from 1 to the curve degree + 1
        Dim alpha As Double
        For l = 1 To Degree + 1
            'build level l of the pyramid
            For i = s To s - Degree + l Step -1
                alpha = (t - knots(i)) / (knots(i + Degree + 1 - l) - knots(i))
                v(i).X = (1 - alpha) * v(i - 1).X + alpha * v(i).X
                v(i).Y = (1 - alpha) * v(i - 1).Y + alpha * v(i).Y
                'interpolate each component
            Next
        Next
        Return v(s)
    End Function
    Public Function getXYSegmentStart(segNum As Integer) As Point
        Return getXY(1.0 / NSegment * segNum)
    End Function
    Public Function getXYSegmentEnd(segNum As Integer) As Point
        Return getXY(1.0 / NSegment * (segNum + 1))
    End Function
    Public Overrides Sub draw(gc As GraphicContest)
        Dim cpPen As Pen = New Pen(ControlColor, 1)
        If needRecalc Then
            recalc()
        End If

        Dim i As Integer
        Dim virtInj As Injector = New Injector(Integer.MaxValue)
        If _controlPoints.Count > 1 Then
            cpPen.DashPattern = New Single() {1, 3}
            Dim cp1, cp2 As ControlPoint
            cp1 = _controlPoints.ElementAt(0)
            virtInj.Colore = ControlColor
            cp1.draw(gc, virtInj)
            For i = 1 To nPoints - 1
                cp2 = _controlPoints.ElementAt(i)
                gc.G.DrawLine(cpPen, gc.Zoom.getScreenPoint(cp1.P), gc.Zoom.getScreenPoint(cp2.P))
                cp1 = cp2
                cp1.draw(gc, virtInj)
            Next
            If _controlPoints.Count > 2 Then
                Dim p1, p2 As Point
                cpPen = New Pen(SplineColor, 1)

                Dim t As Double = 0
                p1 = gc.Zoom.getScreenPoint(getXY(t))
                Dim tCounter As Integer = 0
                Dim tratteggioOn As Boolean = True
                Dim l As Double = curveLength()
                Dim ds As Double = 1 / (l)
                For t = ds To 1 Step ds
                    If tCounter < 5 Then
                        tCounter = tCounter + 1
                    Else
                        tCounter = 0
                        tratteggioOn = Not tratteggioOn
                    End If
                    p2 = gc.Zoom.getScreenPoint(getXY(t))
                    If tratteggioOn Then
                        gc.G.DrawLine(cpPen, p1, p2)
                    End If
                    p1 = p2
                Next
                p2 = gc.Zoom.getScreenPoint(getXY(1))
                gc.G.DrawLine(cpPen, p1, p2)
                cpPen = New Pen(_inj.Colore, 1)
                Dim ns As Integer
                If injPoint IsNot Nothing Then
                    injPoint.Clear()
                End If
                p1 = getXYSegmentStart(0)
                Dim pi As InjPoint
                For ns = 0 To NSegment - 1
                    pi = New InjPoint(p1, True, True)
                    injPoint.Add(pi)
                    p1 = getXYSegmentEnd(ns)
                Next
                pi = New InjPoint(p1, True, True)
                injPoint.Add(pi)
                drawInjPath(gc)
            End If
        End If
    End Sub

    Public Overrides Function findPoint(p As MousePoint) As xyPoint
        For Each ptControl In _controlPoints
            If Not ptControl.findPoint(p) Is Nothing Then
                Return ptControl
            End If
        Next
        Return Nothing
    End Function
    Public Function findLine(p As xyPoint)
        Dim pFound As xyPoint = Nothing
        Dim m As Double
        Dim q As Double
        Dim d As Double
        Dim i As Integer
        Dim p1 As xyPoint
        Dim p2 As xyPoint

        For i = 0 To nPoints - 2
            p1 = _controlPoints(i)
            p2 = _controlPoints(i + 1)
            If (Math.Min(p1.X, p2.X) <= p.X And Math.Max(p1.X, p2.X) >= p.X) Then
                If (Math.Min(p1.Y, p2.Y) <= p.Y And Math.Max(p1.Y, p2.Y) >= p.Y) Then
                    m = (p2.Y - p1.Y) / (p2.X - p1.X)
                    q = p1.Y - m * p1.X
                    d = Math.Abs(p.Y - (m * p.X + q)) / (Math.Sqrt(1 + m * m))
                    If d <= delta Then
                        pFound = _controlPoints(i + 1)
                    End If
                End If
            End If
        Next
        Return pFound
    End Function

    Private Function curveLength() As Double
        Dim p1, p2 As Point
        Dim l As Double = 0.0



        Dim t As Double = 0
        p1 = getXY(t)
        For t = 0.02 To 1 Step 0.02
            p2 = getXY(t)
            l = l + Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
            p1 = p2
        Next
        Return l
    End Function
    Private Sub recalc()
        generateKnots()
        needRecalc = False
    End Sub

    Public Overrides Sub moveSelectedPoint(p As MousePoint)
        Throw New NotImplementedException
    End Sub
    Public Sub unSelect()
        _selected = False
    End Sub

    Public Function serialize() As String Implements Serializable.serialize
        Dim s As String

        s = "S1*"
        For Each p As xyPoint In ControlPoints
            s = s + p.serialize() + "*"
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Sub deserialize(strVal As String) Implements Serializable.deserialize
        Throw New NotImplementedException()
    End Sub
End Class
