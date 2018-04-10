Public Class Spezzata
    Inherits InjElement
    Implements Serializable

    Public Sub New(points As List(Of ControlPoint), inj As Injector)
        injPoint = ControlPoint.toInjPointList(points)
        _inj = inj
    End Sub
    Public ReadOnly Property nPoints As Integer
        Get
            Return injPoint.Count
        End Get
    End Property
    Public Function appendPoint(p As xyPoint) As Integer
        injPoint.Add(p)
        Return nPoints
    End Function
    Public Overrides Function addPoint(p As MousePoint) As Boolean
        Dim _p As InjPoint

        _p = New InjPoint(p.p, True, False)
        appendPoint(_p)
        Return True
    End Function
    Public Function insertPointBefore(newPoint As xyPoint, pos As xyPoint) As Integer
        Dim insertIndex As Integer
        insertIndex = injPoint.IndexOf(pos)
        If (insertIndex < 0) Then insertIndex = 0
        injPoint.Insert(insertIndex, newPoint)
        Return nPoints
    End Function
    Public Function removePoint(p As xyPoint) As Boolean
        Return injPoint.Remove(p)
    End Function
    Public Function changePoint(pNew As xyPoint, pOld As xyPoint) As Boolean
        Dim i As Integer
        i = injPoint.IndexOf(pOld)
        injPoint.Remove(pOld)
        injPoint.Insert(i, pNew)
        Return True
    End Function
    Public Overrides Sub draw(gc As GraphicContest)
        drawInjPath(gc)
    End Sub
    Public Overrides Sub moveSelectedPoint(p As MousePoint)
        For Each pt In injPoint
            If pt.Selected Then
                pt.X = p.X
                pt.Y = p.Y
                Exit Sub
            End If
        Next
    End Sub
    Public Overrides Function getSelectedPoint() As xyPoint
        For Each pt In injPoint
            If pt.Selected Then
                Return pt
            End If
        Next
        Return Nothing
    End Function

    Public Sub unSelect()
        For Each pt In injPoint
            pt.unSelect()
        Next
    End Sub
    Public Overrides Function findPoint(p As MousePoint) As xyPoint
        For Each ptControl In injPoint
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
            p1 = injPoint(i)
            p2 = injPoint(i + 1)
            If (Math.Min(p1.X, p2.X) <= p.X And Math.Max(p1.X, p2.X) >= p.X) Then
                If (Math.Min(p1.Y, p2.Y) <= p.Y And Math.Max(p1.Y, p2.Y) >= p.Y) Then
                    m = (p2.Y - p1.Y) / (p2.X - p1.X)
                    q = p1.Y - m * p1.X
                    d = Math.Abs(p.Y - (m * p.X + q)) / (Math.Sqrt(1 + m * m))
                    If d <= GraphicContest.SENSIBILITY Then
                        pFound = injPoint(i + 1)
                    End If
                End If
            End If
        Next
        Return pFound
    End Function

    Public Function serialize() As String Implements Serializable.serialize
        Dim s As String

        s = "SP*"
        For Each p As xyPoint In injPoint
            s = s + p.serialize() + "*"
        Next
        Return s.Substring(0, s.Length - 1)
    End Function

    Public Sub deserialize(strVal As String) Implements Serializable.deserialize

        Dim arr() As String = strVal.Split("*")
        Dim i As Integer
        injPoint.Clear()

        Dim p As Point = New Point(1, 1)

        For i = 1 To arr.Length - 1 'parte da 1 e non da 0 per saltare il primo pezzo "SP*"
            Dim xyp As InjPoint = New InjPoint(p, True, True)
            xyp.deserialize(arr(i))
            injPoint.Add(xyp)

        Next

    End Sub
End Class
