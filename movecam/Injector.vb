Public Class Injector

    Private _position As Integer
    Private _offsetX As Double
    Private _offsetY As Double
    Private _valvola As Integer
    Private _cilindro As Integer
    Private _colore As Color
    Private _needle As Needle
    Private _pressure As Double


    Public Sub New(posizione As Integer, valvola As Integer, cilindro As Integer)
        Me.Position = posizione
        Me.Valvola = valvola
        Me.Cilindro = cilindro
        Me.Needle = New Needle("")
    End Sub

    Public Sub New(posizione As Integer)
        Me.Position = posizione
    End Sub

    Public Property Position As Integer
        Get
            Return _position
        End Get
        Set(value As Integer)
            _position = value
        End Set
    End Property

    Public Property InjectorName As String
        Get
            Return Format$(_position, "00")
        End Get
        Set(str As String)
            _position = CInt(str)
        End Set
    End Property


    Public Property OffsetX As Double
        Get
            Return _offsetX
        End Get
        Set(value As Double)
            _offsetX = value
        End Set
    End Property

    Public Property OffsetY As Double
        Get
            Return _offsetY
        End Get
        Set(value As Double)
            _offsetY = value
        End Set
    End Property

    Public Property Valvola As Integer
        Get
            Return _valvola
        End Get
        Set(value As Integer)
            _valvola = value
        End Set
    End Property

    Public Property Cilindro As Integer
        Get
            Return _cilindro
        End Get
        Set(value As Integer)
            _cilindro = value
        End Set
    End Property

    Public Property Colore As Color
        Get
            Return _colore
        End Get
        Set(value As Color)
            _colore = value
        End Set
    End Property

    Public Property Needle As Needle
        Get
            Return _needle
        End Get
        Set(value As Needle)
            _needle = value
        End Set
    End Property

    Public Property Pressure As Double
        Get
            Return _pressure
        End Get
        Set(value As Double)
            _pressure = value
        End Set
    End Property

    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
            Return False
        End If

        Dim i As Injector = CType(obj, Injector)
        Return i.Position = Me.Position
    End Function

    Public Overrides Function getHashCode() As Integer
        Return Me.Position
    End Function
    Public Function cfgOffsetXName() As String
        Return cfgMainName() & ".offsetX"
    End Function
    Public Function cfgOffsetYName() As String
        Return cfgMainName() & ".offsetY"
    End Function
    Public Function cfgValvolaName() As String
        Return cfgMainName() & ".valvola"
    End Function
    Public Function cfgCilindroName() As String
        Return cfgMainName() & ".cilindro"
    End Function
    Public Function cfgColoreName() As String
        Return cfgMainName() & ".colore"
    End Function
    Public Function cfgOffsetX() As String
        Return cfgOffsetXName() & "=" & Format(OffsetX, "0.00")
    End Function
    Public Function cfgOffsetY() As String
        Return cfgOffsetYName() & "=" & Format(OffsetY, "0.00")
    End Function
    Public Function cfgValvola() As String
        Return cfgValvolaName() & "=" & Format(Valvola, "0")
    End Function
    Public Function cfgCilindro() As String
        Return cfgCilindroName() & "=" & Format(Cilindro, "0")
    End Function
    Public Function cfgColore() As String
        Return cfgColoreName() & "=" & Format(Colore.R) & "," & Format(Colore.G) & "," & Format(Colore.B)
    End Function
    Public Function cfgMainName() As String
        Return "iniettore" & InjectorName
    End Function
    Public Function writeToConfig() As String
        Return cfgOffsetX() + vbCrLf _
             + cfgOffsetY() + vbCrLf _
             + cfgValvola() + vbCrLf _
             + cfgCilindro() + vbCrLf _
             + cfgColore()
    End Function

    Public Function readFromConfig(row As String) As Boolean
        If row & "" = "" Then
            Return False
        End If

        If row Like cfgOffsetXName() & "*" Then
            OffsetX = doubleFromConfig(row)
            Return True
        ElseIf row Like cfgOffsetYName() & "*" Then
            OffsetY = doubleFromConfig(row)
            Return True
        ElseIf row Like cfgValvolaName() & "*" Then
            Valvola = intFromConfig(row)
            Return True
        ElseIf row Like cfgCilindroName() & "*" Then
            Cilindro = intFromConfig(row)
            Return True
        ElseIf row Like cfgColoreName() & "*" Then
            Colore = colorFromConfig(row)
            Return True
        End If
        Return False
    End Function


End Class
