Imports movecam

Public Class ControlPoint
    Inherits xyPoint

    Enum PointControlTypeEnum
        Control
        ControlAngular
        Center
    End Enum

    Private _controlType As PointControlTypeEnum

    Public Property ControlType As PointControlTypeEnum
        Get
            Return _controlType
        End Get
        Set(value As PointControlTypeEnum)
            _controlType = value
        End Set
    End Property

    Public Sub New(p As Point, controlType As PointControlTypeEnum)
        MyBase.New(p)
        Me.ControlType = controlType
    End Sub

    Public Overrides Sub draw(gc As GraphicContest, inj As Injector)
        Dim cpPen As Pen = New Pen(inj.Colore, 1)
        gc.G.DrawRectangle(cpPen, gc.Zoom.getXScreen(P.X) - _radius, gc.Zoom.getYScreen(P.Y) - _radius, 2 * _radius, 2 * _radius)
    End Sub

    Public Function toMousePoint() As MousePoint
        Return toMousePoint(New Injector(99))
    End Function

    Public Function toMousePoint(inj As Injector) As MousePoint
        Return New MousePoint(Me.P, inj)
    End Function

    Public Function toInjPoint() As InjPoint
        Return toInjPoint(True, True)
    End Function

    Public Function toInjPoint(bStart As Boolean, bStop As Boolean) As InjPoint
        Return New InjPoint(Me.P, bStart, bStop)
    End Function

    Public Shared Function toMousePointList(l As List(Of ControlPoint)) As List(Of MousePoint)
        Dim mousePlist = New List(Of MousePoint)
        For Each cp As ControlPoint In l
            mousePlist.Add(cp.toMousePoint())
        Next
        Return mousePlist
    End Function

    Public Shared Function toInjPointList(l As List(Of ControlPoint)) As List(Of InjPoint)
        Dim injPlist = New List(Of InjPoint)
        For Each cp As ControlPoint In l
            injPlist.Add(cp.toInjPoint())
        Next
        Return injPlist
    End Function
End Class
