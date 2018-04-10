Imports movecam

Public Class Robot
    Private _injectors As List(Of Injector)
    Private _serial As String
    Private _controller As Controller
    Private _cam As Cam
    Private _xAxis As Axis
    Private _yAxis As Axis
    Private _zAxis As Axis

    Public Sub New(nInjectors As Integer, bv As Integer, bc As Integer)
        Dim l As New List(Of Injector)
        Dim i As Integer

        For i = 1 To nInjectors
            l.Add(New Injector(i, bv + i, bc + i))
        Next
        Injectors = l
        XAxis = New Axis("X")
        YAxis = New Axis("Y")
        ZAxis = New Axis("Z")

    End Sub
    Public ReadOnly Property Injector(n As Integer) As Injector
        Get
            For Each inj As Injector In Injectors
                If inj.Position = n Then
                    Return inj
                End If
            Next
            Return _injectors.First()
        End Get
    End Property
    Public Property Injectors As List(Of Injector)
        Get
            Return _injectors
        End Get
        Set(value As List(Of Injector))
            _injectors = value
        End Set
    End Property

    Public Property XAxis As Axis
        Get
            Return _xAxis
        End Get
        Set(value As Axis)
            _xAxis = value
        End Set
    End Property

    Public Property YAxis As Axis
        Get
            Return _yAxis
        End Get
        Set(value As Axis)
            _yAxis = value
        End Set
    End Property

    Public Property ZAxis As Axis
        Get
            Return _zAxis
        End Get
        Set(value As Axis)
            _zAxis = value
        End Set
    End Property
End Class
