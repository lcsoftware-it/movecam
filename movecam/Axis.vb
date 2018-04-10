Public Class Axis

    Private _posLimit As Limit = New Limit()
    Private _currentPos As Double
    Private _targetPos As Double

    Private _speedLimit As Limit = New Limit()
    Private _slowSpeed As Double
    Private _highSpeed As Double
    Private _currentSpeed As Double

    Private _axisName As String

    Private _homed As Boolean
    Public Sub New(name As String)
        AxisName = name
    End Sub
    Public Property MinPos As Double
        Get
            Return _posLimit.Min
        End Get
        Set(value As Double)
            _posLimit.Min = value
        End Set
    End Property

    Public Property MaxPos As Double
        Get
            Return _posLimit.Max
        End Get
        Set(value As Double)
            _posLimit.Max = value
        End Set
    End Property

    Public Property CurrentPos As Double
        Get
            Return _currentPos
        End Get
        Set(value As Double)
            _currentPos = value
        End Set
    End Property

    Public Property TargetPos As Double
        Get
            Return _targetPos
        End Get
        Set(value As Double)
            _targetPos = value
        End Set
    End Property

    Public Property MinSpeed As Double
        Get
            Return _speedLimit.Min
        End Get
        Set(value As Double)
            _speedLimit.Min = value
        End Set
    End Property

    Public Property SlowSpeed As Double
        Get
            Return _slowSpeed
        End Get
        Set(value As Double)
            _slowSpeed = value
        End Set
    End Property

    Public Property HighSpeed As Double
        Get
            Return _highSpeed
        End Get
        Set(value As Double)
            _highSpeed = value
        End Set
    End Property

    Public Property MaxSpeed As Double
        Get
            Return _speedLimit.Max
        End Get
        Set(value As Double)
            _speedLimit.Max = value
        End Set
    End Property

    Public Property CurrentSpeed As Double
        Get
            Return _currentSpeed
        End Get
        Set(value As Double)
            _currentSpeed = value
        End Set
    End Property

    Public Property Homed As Boolean
        Get
            Return _homed
        End Get
        Set(value As Boolean)
            _homed = value
        End Set
    End Property

    Public Property AxisName As String
        Get
            Return _axisName
        End Get
        Set(value As String)
            _axisName = value
        End Set
    End Property

    Public Function cfgPosMinName() As String
        Return cfgMainName() & ".posmin"
    End Function
    Public Function cfgPosMAXName() As String
        Return cfgMainName() & ".posMAX"
    End Function
    Public Function cfgSpeedMinName() As String
        Return cfgMainName() & ".velmin"
    End Function
    Public Function cfgSpeedMAXName() As String
        Return cfgMainName() & ".velMAX"
    End Function
    Public Function cfgSpeedWorkName() As String
        Return cfgMainName() & ".velLavoro"
    End Function
    Public Function cfgSpeedMoveName() As String
        Return cfgMainName() & ".velMovimento"
    End Function
    Public Function cfgPosMin() As String
        Return cfgPosMinName() & "=" & Format(MinPos, "0.00")
    End Function
    Public Function cfgPosMAX() As String
        Return cfgPosMAXName() & "=" & Format(MaxPos, "0.00")
    End Function
    Public Function cfgSpeedMin() As String
        Return cfgSpeedMinName() & "=" & Format(MinSpeed, "0")
    End Function
    Public Function cfgSpeedMAX() As String
        Return cfgSpeedMAXName() & "=" & Format(MaxSpeed, "0")
    End Function
    Public Function cfgSpeedWork() As String
        Return cfgSpeedWorkName() & "=" & Format(SlowSpeed, "0")
    End Function
    Public Function cfgSpeedMove() As String
        Return cfgSpeedMoveName() & "=" & Format(HighSpeed, "0")
    End Function

    Public Function cfgMainName() As String
        Return "asse" & AxisName
    End Function
    Public Function writeToConfig() As String
        Return cfgPosMin() + vbCrLf _
             + cfgPosMAX() + vbCrLf _
             + cfgSpeedMin() + vbCrLf _
             + cfgSpeedMAX() + vbCrLf _
             + cfgSpeedWork() + vbCrLf _
             + cfgSpeedMove()
    End Function
    Public Function readFromConfig(row As String) As Boolean
        If row & "" = "" Then
            Return False
        End If

        If row Like cfgPosMinName() & "*" Then
            MinPos = doubleFromConfig(row)
            Return True
        ElseIf row Like cfgPosMAXName() & "*" Then
            MaxPos = doubleFromConfig(row)
            Return True
        ElseIf row Like cfgSpeedMinName() & "*" Then
            MinSpeed = intFromConfig(row)
            Return True
        ElseIf row Like cfgSpeedMAXName() & "*" Then
            MaxSpeed = intFromConfig(row)
            Return True
        ElseIf row Like cfgSpeedWorkName() & "*" Then
            SlowSpeed = intFromConfig(row)
            Return True
        ElseIf row Like cfgSpeedMoveName() & "*" Then
            HighSpeed = intFromConfig(row)
            Return True
        End If
        Return False
    End Function
End Class
