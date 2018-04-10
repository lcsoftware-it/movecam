Imports movecam

Public Class SinglePoint
    Inherits InjElement
    Implements Serializable

    Private _iPoint As InjPoint

    Public Sub New(point As xyPoint, inj As Injector)
        _iPoint = point
        _inj = inj
    End Sub


    Public Overrides Sub draw(gc As GraphicContest)
        Dim cpPen As Pen = New Pen(Inj.Colore)
        Dim b As Brush = New SolidBrush(Inj.Colore)
        Dim P As InjPoint = _iPoint
        Dim diameter As Integer = 2 * P.Radius

        P.setStartInj()
        P.draw(gc, Inj)
        gc.G.DrawLine(cpPen, gc.Zoom.getXScreen(P.X) - diameter, gc.Zoom.getYScreen(P.Y) - diameter, gc.Zoom.getXScreen(P.X) + diameter, gc.Zoom.getYScreen(P.Y) + diameter)
        gc.G.DrawLine(cpPen, gc.Zoom.getXScreen(P.X) - diameter, gc.Zoom.getYScreen(P.Y) + diameter, gc.Zoom.getXScreen(P.X) + diameter, gc.Zoom.getYScreen(P.Y) - diameter)

        Dim drawFont As System.Drawing.Font
        drawFont = New System.Drawing.Font("Arial", 16)
        Dim drawBrush As System.Drawing.SolidBrush
        drawBrush = New System.Drawing.SolidBrush(System.Drawing.Color.Black)
        Dim drawFormat As System.Drawing.StringFormat
        drawFormat = New System.Drawing.StringFormat()
        gc.G.DrawString("P", drawFont, drawBrush, gc.Zoom.getXScreen(P.X), gc.Zoom.getYScreen(P.Y), drawFormat)
        drawFont.Dispose()
        drawBrush.Dispose()

    End Sub

    Public Overrides Function getSelectedPoint() As xyPoint
        If _iPoint.Selected Then
            Return _iPoint
        End If
        Return Nothing
    End Function

    Public Overrides Sub moveSelectedPoint(p As MousePoint)
        If _iPoint.Selected Then
            _iPoint.X = p.X
            _iPoint.Y = p.Y
        End If
    End Sub

    Public Overrides Function findPoint(p As MousePoint) As xyPoint
        Return _iPoint.findPoint(p)
    End Function
    Public Overrides Function addPoint(p As MousePoint) As Boolean

        _iPoint = New InjPoint(p.p, True, True)
        Return True
    End Function
    Public Sub deserialize(strVal As String) Implements Serializable.deserialize
        Throw New NotImplementedException()
    End Sub

    Public Function serialize() As String Implements Serializable.serialize
        Throw New NotImplementedException()
    End Function
End Class
