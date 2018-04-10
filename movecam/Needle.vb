Public Class Needle

    Private _diameter As String

    Public Sub New(diam As String)
        _diameter = diam
    End Sub

    Public Property Diameter As String
        Get
            Return _diameter
        End Get
        Set(value As String)
            _diameter = value
        End Set
    End Property

    Public Overrides Function toString() As String
        Return Diameter
    End Function

    Public Function screenSize() As Integer
        Dim d As Double

        If Not Double.TryParse(Diameter, d) Then
            d = 0.0
        End If
        Return 10 * d
    End Function
End Class
