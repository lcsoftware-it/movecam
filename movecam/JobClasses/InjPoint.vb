Public Class InjPoint
    Inherits xyPoint

    Private _inj_state As Integer
    <FlagsAttribute> Private Enum InjectionState As Integer
        START_INJ = 1
        STOP_INJ = 2
        CONT_INJ = 4
    End Enum



    Public Sub New(p As Point, startInj As Boolean, stopInj As Boolean)
        MyBase.New(p)
        If startInj Then setStartInj() Else resetStartInj()
        If stopInj Then setStopInj() Else resetStopInj()
    End Sub

    Public Function isStartInj()
        Return _inj_state And InjectionState.START_INJ
    End Function
    Public Function isStopInj()
        Return _inj_state And InjectionState.STOP_INJ
    End Function
    Public Function isInjecting()
        Return _inj_state And InjectionState.CONT_INJ
    End Function

    Public Sub setStartInj()
        _inj_state = _inj_state Or InjectionState.START_INJ
    End Sub
    Public Sub setStopInj()
        _inj_state = _inj_state Or InjectionState.STOP_INJ
    End Sub
    Public Sub resetStartInj()
        _inj_state = _inj_state And Not InjectionState.START_INJ
    End Sub
    Public Sub resetStopInj()
        _inj_state = _inj_state And Not InjectionState.STOP_INJ
    End Sub
    Public Sub setInjecting()
        _inj_state = _inj_state Or InjectionState.CONT_INJ
    End Sub
    Public Sub resetInjecting()
        _inj_state = _inj_state And Not InjectionState.CONT_INJ
    End Sub

    Public Overrides Sub draw(gc As GraphicContest, inj As Injector)
        Dim cpPen As Pen = New Pen(inj.Colore, 1)
        Dim b As Brush = New SolidBrush(inj.Colore)

        If isStartInj() Or isInjecting() Then
            gc.G.FillEllipse(b, gc.Zoom.getXScreen(P.X) - _radius, gc.Zoom.getYScreen(P.Y) - _radius, 2 * _radius, 2 * _radius)
        Else
            gc.G.DrawEllipse(cpPen, gc.Zoom.getXScreen(P.X) - _radius, gc.Zoom.getYScreen(P.Y) - _radius, 2 * _radius, 2 * _radius)
        End If
    End Sub

    Public Function toMousePoint() As MousePoint
        Return toMousePoint(New Injector(99))
    End Function

    Public Function toMousePoint(inj As Injector) As MousePoint
        Return New MousePoint(Me.P, inj)
    End Function

    Public Function toControlPoint() As ControlPoint
        Return toControlPoint(ControlPoint.PointControlTypeEnum.Control)
    End Function

    Public Function toControlPoint(cpType As ControlPoint.PointControlTypeEnum) As ControlPoint
        Return New ControlPoint(Me.P, cpType)
    End Function

    Public Shared Function toMousePointList(l As List(Of InjPoint)) As List(Of MousePoint)
        Dim mousePlist = New List(Of MousePoint)
        For Each cp As InjPoint In l
            mousePlist.Add(cp.toMousePoint())
        Next
        Return mousePlist
    End Function

    Public Shared Function toInjPointList(l As List(Of InjPoint)) As List(Of ControlPoint)
        Dim cpList = New List(Of ControlPoint)
        For Each cp As InjPoint In l
            cpList.Add(cp.toControlPoint())
        Next
        Return cpList
    End Function
End Class
