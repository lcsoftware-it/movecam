Public Class Limit
    Private _min As Double
    Private _max As Double

    Public Property Min As Double
        Get
            Return _min
        End Get
        Set(value As Double)
            _min = value
        End Set
    End Property

    Public Property Max As Double
        Get
            Return _max
        End Get
        Set(value As Double)
            _max = value
        End Set
    End Property

    Public Function isInto(v As Double) As Boolean
        Return v >= Min And v <= Max
    End Function

End Class
