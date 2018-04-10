Imports movecam

Public Class MousePoint

    Public p As Point
    Public inj As Injector


    Public Sub New(pt As Point, i As Injector)
        p = pt
        inj = i
    End Sub

    Public Property X As Double
        Get
            Return p.X
        End Get
        Set(value As Double)
            p.X = value
        End Set
    End Property

    Public Property Y As Double
        Get
            Return p.Y
        End Get
        Set(value As Double)
            p.Y = value
        End Set
    End Property

    Public Function toControlPoint() As ControlPoint
        Return toControlPoint(ControlPoint.PointControlTypeEnum.Control)
    End Function

    Public Function toControlPoint(cpType As ControlPoint.PointControlTypeEnum) As ControlPoint
        Return New ControlPoint(Me.p, cpType)
    End Function

    Public Function toInjPoint() As InjPoint
        Return toInjPoint(True, True)
    End Function

    Public Function toInjPoint(bStart As Boolean, bStop As Boolean) As InjPoint
        Return New InjPoint(Me.p, bStart, bStop)
    End Function

    Public Shared Function toControlPointList(l As List(Of MousePoint)) As List(Of ControlPoint)
        Dim controlPlist = New List(Of ControlPoint)
        For Each mp As MousePoint In l
            controlPlist.Add(mp.toControlPoint())
        Next
        Return controlPlist
    End Function

    Public Shared Function toInjPointList(l As List(Of MousePoint)) As List(Of InjPoint)
        Dim injPlist = New List(Of InjPoint)
        For Each mp As MousePoint In l
            injPlist.Add(mp.toInjPoint())
        Next
        Return injPlist
    End Function
End Class
