Imports movecam

Public Class BControlSpline
    Inherits InjElement
    Implements Serializable

    'vedi
    'http://www.ibiblio.org/e-notes/Splines/b-int.html

    'Private _P() As xyPoint
    'Private _d() As Point
    'Private cr() As Double
    'Private cl() As Double

    Private _p As List(Of BControlSplinePoint)

    Private n As Integer
    Private n1 As Integer
    Private changeD As Boolean = True
    Private pFound As xyPoint = Nothing

    Private Const NDIV As Integer = 40
    Private Shared B0(NDIV) As Double
    Private Shared B1(NDIV) As Double
    Private Shared B2(NDIV) As Double
    Private Shared B3(NDIV) As Double
    Private Shared bInit As Boolean = False


    Public Property P As List(Of BControlSplinePoint)
        Get
            Return _p
        End Get
        Set(value As List(Of BControlSplinePoint))
            _p = value
        End Set
    End Property
    Public Overrides Function getSelectedPoint() As xyPoint
        For Each pt In _p
            If pt.P.Selected Then
                Return pt.P
            End If
        Next
        Return Nothing
    End Function
    Public Sub New(points As List(Of ControlPoint))
        _p = New List(Of BControlSplinePoint)
        For Each P1 In points
            _p.Add(New BControlSplinePoint(P1))
        Next
        n = points.Count
        n1 = n + 1

        If Not bInit Then
            'ReDim _d(n1), a(n1), bi(n1), cr(n1), cl(n1)
            Dim t As Double = 0
            Dim t1, t12, t2 As Double
            Dim i As Integer

            For i = 0 To NDIV - 1
                t1 = 1 - t
                t12 = t1 * t1
                t2 = t * t
                B0(i) = t1 * t12
                B1(i) = 3 * t * t12
                B2(i) = 3 * t2 * t1
                B3(i) = t * t2
                t = t + 1 / NDIV
            Next
            bInit = True
        End If
    End Sub
    Public Overrides Function addPoint(p As MousePoint) As Boolean

        Dim cp As ControlPoint
        cp = New ControlPoint(p.p, ControlPoint.PointControlTypeEnum.Control)
        _p.Add(New BControlSplinePoint(cp))

        n = n + 1
        n1 = n + 1
        changeD = True
        Return True
    End Function

    Sub computePoints()

        Dim p0, p1 As BControlSplinePoint
        Dim a(n - 2) As Point
        Dim bi(n - 2) As Double


        p0 = _p.ElementAt(0)
        p1 = _p.ElementAt(1)

        If changeD Then
            p0.Dr.X = (p1.P.X - p0.P.X) / 3
            p0.Dr.Y = (p1.P.Y - p0.P.Y) / 3
            p0.Dl.X = p0.Dr.X
            p0.Dl.Y = p0.Dr.Y
        End If

        p0 = _p.ElementAt(n - 2)
        p1 = _p.ElementAt(n - 1)
        If changeD Then
            p1.Dr.X = (p1.P.X - p0.P.X) / 3
            p1.Dr.Y = (p1.P.Y - p0.P.Y) / 3
            p1.Dl.X = p1.Dr.X
            p1.Dl.Y = p1.Dr.Y
        End If

        bi(1) = -0.25
        a(1).X = (_p.ElementAt(2).P.X - _p.ElementAt(0).P.X - _p.ElementAt(0).Dr.X) / 4
        a(1).Y = (_p.ElementAt(2).P.Y - _p.ElementAt(0).P.Y - _p.ElementAt(0).Dr.Y) / 4
        Dim i As Integer
        For i = 2 To n - 2
            bi(i) = -1 / (4 + bi(i - 1))
            a(i).X = -(_p.ElementAt(i + 1).P.X - _p.ElementAt(i - 1).P.X - a(i - 1).X) * bi(i)
            a(i).Y = -(_p.ElementAt(i + 1).P.Y - _p.ElementAt(i - 1).P.Y - a(i - 1).Y) * bi(i)
        Next
        If changeD Then
            For i = n - 2 To 1 Step -1
                _p.ElementAt(i).Dr.X = a(i).X + _p.ElementAt(i + 1).Dr.X * bi(i)
                _p.ElementAt(i).Dr.Y = a(i).Y + _p.ElementAt(i + 1).Dr.Y * bi(i)
                _p.ElementAt(i).Dl.X = _p.ElementAt(i).Dr.X
                _p.ElementAt(i).Dl.Y = _p.ElementAt(i).Dr.Y
            Next
        End If
        changeD = False
    End Sub
    Private Function getSegmentLen(p1 As Point, p2 As Point, d1 As Point, d2 As Point) As Double
        Dim l As Double = 0
        Dim x0, y0 As Double
        Dim x1, y1 As Double

        x0 = (p1.X * B0(0) + (p1.X + d1.X) * B1(0) +
                    (p2.X - d2.X) * B2(0) + p2.X * B3(0))
        y0 = (p1.Y * B0(0) + (p1.Y + d1.Y) * B1(0) +
                    (p2.Y - d2.Y) * B2(0) + p2.Y * B3(0))


        For k = 1 To NDIV - 1
            x1 = (p1.X * B0(k) + (p1.X + d1.X) * B1(k) +
                    (p2.X - d2.X) * B2(k) + p2.X * B3(k))
            y1 = (p1.Y * B0(k) + (p1.Y + d1.Y) * B1(k) +
                    (p2.Y - d2.Y) * B2(k) + p2.Y * B3(k))

            l = l + Math.Sqrt((x1 - x0) ^ 2 + (y1 - y0) ^ 2)
            x0 = x1
            y0 = y1
        Next
        x1 = p2.X
        y1 = p2.X
        l = l + Math.Sqrt((x1 - x0) ^ 2 + (y1 - y0) ^ 2)
        Return l

    End Function

    Public Overrides Sub draw(gc As GraphicContest)

        Dim cpPen As Pen = New Pen(Color.Black, 1)
        Dim cpPenControl As Pen = New Pen(Color.Red, 1)

        Dim scP(n) As Point
        Dim scD(n) As Point
        Dim i As Integer

        computePoints()



        _p.ElementAt(0).drawStart(gc)
        For i = 1 To _p.Count - 2
            _p.ElementAt(i).draw(gc)
        Next
        _p.ElementAt(_p.Count - 1).drawEnd(gc)
        For i = 0 To n - 2
            Dim p1, p2 As Point
            cpPen = New Pen(Color.Black, 1)

            Dim t As Double = 0
            p1 = gc.Zoom.getScreenPoint(_p.ElementAt(i).P.P)
            Dim tCounter As Integer = 0
            Dim tratteggioOn As Boolean = True
            Dim k As Integer
            Dim x As Double
            Dim y As Double

            For k = 0 To NDIV - 1
                'x = (P(i).X * B0(k) + (P(i).X + _d(i).X) * B1(k) + (P(i + 1).X - _d(i + 1).X) * B2(k) + P(i + 1).X * B3(k))
                'y = (P(i).Y * B0(k) + (P(i).Y + _d(i).Y) * B1(k) + (P(i + 1).Y - _d(i + 1).Y) * B2(k) + P(i + 1).Y * B3(k))
                x = (_p.ElementAt(i).P.X * B0(k) + (_p.ElementAt(i).P.X + _p.ElementAt(i).Dl.X) * B1(k) + (_p.ElementAt(i + 1).P.X - _p.ElementAt(i + 1).Dr.X) * B2(k) + _p.ElementAt(i + 1).P.X * B3(k))
                y = (_p.ElementAt(i).P.Y * B0(k) + (_p.ElementAt(i).P.Y + _p.ElementAt(i).Dl.Y) * B1(k) + (_p.ElementAt(i + 1).P.Y - _p.ElementAt(i + 1).Dr.Y) * B2(k) + _p.ElementAt(i + 1).P.Y * B3(k))

                p2 = gc.Zoom.getScreenPoint(New Point(x, y))
                gc.G.DrawLine(cpPen, p1, p2)
                p1 = p2
            Next


            p2 = gc.Zoom.getScreenPoint(_p.ElementAt(i + 1).P.P)

            gc.G.DrawLine(cpPen, p1, p2)
        Next


    End Sub
    Public Overrides Function findPoint(p As MousePoint) As xyPoint
        Dim pFound As xyPoint
        For Each point In _p
            With point
                .LeftSelected = False
                .CenterSelected = False
                .RightSelected = False
            End With
        Next
        pFound = findPointBase(p)
        If pFound Is Nothing Then
            pFound = findControlPoint(p)
        End If
        Return pFound
    End Function
    Public Function findPointBase(p As MousePoint) As xyPoint
        pFound = Nothing
        For Each ptControl In _p
            If Math.Abs(ptControl.P.X - p.X) <= GraphicContest.SENSIBILITY Then
                If Math.Abs(ptControl.P.Y - p.Y) <= GraphicContest.SENSIBILITY Then
                    pFound = ptControl.P
                    ptControl.CenterSelected = True
                    Exit For
                End If
            End If
        Next
        Return pFound
    End Function
    Public Function findControlPoint(p As MousePoint) As xyPoint

        pFound = Nothing
        For Each ptControl In _p
            If Math.Abs(ptControl.P.X + ptControl.Dr.X - p.X) <= GraphicContest.SENSIBILITY Then
                If Math.Abs(ptControl.P.Y + ptControl.Dr.Y - p.Y) <= GraphicContest.SENSIBILITY Then
                    pFound = ptControl.P
                    ptControl.RightSelected = True
                    Exit For
                End If
            End If
            If Math.Abs(ptControl.P.X - ptControl.Dl.X - p.X) <= GraphicContest.SENSIBILITY Then
                If Math.Abs(ptControl.P.Y - ptControl.Dl.Y - p.Y) <= GraphicContest.SENSIBILITY Then
                    pFound = ptControl.P
                    ptControl.LeftSelected = True
                    Exit For
                End If
            End If

        Next
        Return pFound

    End Function
    Public Sub unSelect()
        For Each pt In _p
            pt.P.unSelect()
            pt.Dr.unSelect()
            pt.Dl.unSelect()
        Next
    End Sub

    Public Overrides Sub moveSelectedPoint(p As MousePoint)
        For Each ptControl In _p
            If ptControl.CenterSelected And Not (ptControl.RightSelected Or ptControl.LeftSelected) Then
                ptControl.P.X = p.X
                ptControl.P.Y = p.Y
                Exit For
            ElseIf ptControl.RightSelected Then
                ptControl.Dr.X = p.X - ptControl.P.X
                ptControl.Dr.Y = p.Y - ptControl.P.Y
                If ptControl.Simmetric Then
                    ptControl.Dl.X = ptControl.Dr.X
                    ptControl.Dl.Y = ptControl.Dr.Y
                End If
                Exit For
            ElseIf ptControl.LeftSelected Then
                ptControl.Dl.X = -p.X + ptControl.P.X
                ptControl.Dl.Y = -p.Y + ptControl.P.Y
                If ptControl.Simmetric Then
                    ptControl.Dr.X = ptControl.Dl.X
                    ptControl.Dr.Y = ptControl.Dl.Y
                End If
                Exit For
            End If
        Next
        computePoints()
    End Sub
    Public Function changePoint(pNew As xyPoint, pOld As xyPoint) As Boolean

        If Not pFound Is Nothing Then
            For Each ptControl In _p
                'If ptControl.P = pOld Then
                'pFound = ptControl.P

                If ptControl.CenterSelected Then

                    ptControl.P = pNew
                    Exit For
                ElseIf ptControl.RightSelected Then
                    ptControl.Dr.X = pNew.X - ptControl.P.X
                    ptControl.Dr.Y = pNew.Y - ptControl.P.Y
                    If ptControl.Simmetric Then
                        ptControl.Dl.X = ptControl.Dr.X
                        ptControl.Dl.Y = ptControl.Dr.Y
                    End If
                    Exit For
                ElseIf ptControl.LeftSelected Then
                    ptControl.Dl.X = -pNew.X + ptControl.P.X
                    ptControl.Dl.Y = -pNew.Y + ptControl.P.Y
                    If ptControl.Simmetric Then
                        ptControl.Dr.X = ptControl.Dl.X
                        ptControl.Dr.Y = ptControl.Dl.Y
                    End If
                    Exit For
                End If

                'End If
            Next
            computePoints()
        End If
        Return True
    End Function

    Public Function serialize() As String Implements Serializable.serialize
        Dim s As String

        s = "S2*"
        For Each p As BControlSplinePoint In _p
            s = s + p.P.serialize() + "*"
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Sub deserialize(strVal As String) Implements Serializable.deserialize
        Throw New NotImplementedException()
    End Sub
End Class
