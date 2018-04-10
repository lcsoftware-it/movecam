Public Enum injectionPointType
    startPoint
    endPoint
    middlePoint
    singlePoint
End Enum

Public Class InjectionPoint


    Private _x As Double
    Private _y As Double
    Private _z As Double
    Private _waitTime As Integer 'centesimi di secondo
    Private _inject As Boolean
    Private _speed As Integer
    Private _pType As injectionPointType

    Private Const SEP As String = ";"

    Public Property X As Double
        Get
            Return _x
        End Get
        Set(value As Double)
            _x = value
        End Set
    End Property

    Public Property Y As Double
        Get
            Return _y
        End Get
        Set(value As Double)
            _y = value
        End Set
    End Property

    Public Property Z As Double
        Get
            Return _z
        End Get
        Set(value As Double)
            _z = value
        End Set
    End Property

    Public Property WaitTime As Integer
        Get
            Return _waitTime
        End Get
        Set(value As Integer)
            _waitTime = value
        End Set
    End Property

    Public Property Inject As Boolean
        Get
            Return _inject
        End Get
        Set(value As Boolean)
            _inject = value
        End Set
    End Property

    Public Property Speed As Integer
        Get
            Return _speed
        End Get
        Set(value As Integer)
            _speed = value
        End Set
    End Property

    Public Property pointType As injectionPointType
        Get
            Return _pType
        End Get
        Set(value As injectionPointType)
            _pType = value
        End Set
    End Property

    Public Function cfgX() As String
        Return Format(X, "0.00")
    End Function
    Public Function cfgInject() As String
        If (Inject) Then
            Return "TRUE"
        Else
            Return "FALSE"
        End If
    End Function
    Public Function cfgSpeed() As String
        Return Format(Speed, "0")
    End Function
    Public Function cfgWaitTime() As String
        Return Format(WaitTime, "0")
    End Function
    Public Function cfgY() As String
        Return Format(Y, "0.00")
    End Function
    Public Function cfgZ() As String
        Return Format(Z, "0.00")
    End Function
    Public Function cfgPointType() As String
        Return pointType.ToString
    End Function
    Public Function enumPointTypeFromConfig(str As String) As injectionPointType
        Select Case str
            Case "startPoint"
                Return injectionPointType.startPoint
            Case "endPoint"
                Return injectionPointType.endPoint
            Case "middlePoint"
                Return injectionPointType.middlePoint
            Case "singlePoint"
                Return injectionPointType.singlePoint
        End Select
        Return injectionPointType.middlePoint
    End Function
    Public Function writeToConfig() As String
        Return cfgPointType() + SEP _
             + cfgX() + SEP _
             + cfgY() + SEP _
             + cfgZ() + SEP _
             + cfgInject() + SEP _
             + cfgSpeed() + SEP _
             + cfgWaitTime()
    End Function

    Public Function readFromConfig(row As String) As Boolean
        If row & "" = "" Then
            Return False
        End If
        Dim pointValues() As String = Split(row, SEP)
        pointType = enumPointTypeFromConfig(pointValues(0))
        X = doubleFromConfig(pointValues(1))
        Y = doubleFromConfig(pointValues(2))
        Z = doubleFromConfig(pointValues(3))
        Inject = doubleFromConfig(pointValues(4))
        Speed = doubleFromConfig(pointValues(5))
        WaitTime = doubleFromConfig(pointValues(6))
        Return True
    End Function
End Class
