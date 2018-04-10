Public Class JobVector(Of T)
    Inherits List(Of T)

    Private _points As List(Of InjectionPoint)

    Public Function writeToConfig() As String
        Dim result As String

        result = "VSTART" + vbCrLf
        For Each ip As InjectionPoint In _points
            result = result + ip.writeToConfig() + vbCrLf
        Next
        result = result + "VEND"
        Return result
    End Function

    Public Function readFromConfig(row As String) As Boolean
        If row & "" = "" Then
            Return False
        End If
        Dim strPoints() As String = Split(row, vbCrLf)
        Dim i As Integer
        i = 1
        While strPoints(i) <> "VEND"
            Dim injPoint As InjectionPoint = New InjectionPoint
            injPoint.readFromConfig(strPoints(i))
            _points.Add(injPoint)
        End While
        Return True
    End Function
End Class
