Imports movecam

Public MustInherit Class xyPoint
    Implements Serializable


    Private _x As Double
    Private _y As Double
    Protected _radius As Integer = 3
    Private _selected As Boolean


    Public Sub New(p As Point)
        Me.New(p.X, p.Y)
    End Sub

    Public Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub
    Public Property P As Point
        Get
            Return New Point(_x, _y)
        End Get
        Set(value As Point)
            _x = value.X
            _y = value.Y
        End Set
    End Property

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

    Public Property Radius As Integer
        Get
            Return _radius
        End Get
        Set(value As Integer)
            _radius = value
        End Set
    End Property


    Public Property Selected As Boolean
        Get
            Return _selected
        End Get
        Set(value As Boolean)
            _selected = value
        End Set
    End Property

    Public Function findPoint(p As MousePoint) As xyPoint
        If Math.Abs(Me.X - p.X) <= GraphicContest.SENSIBILITY Then
            If Math.Abs(Me.Y - p.Y) <= GraphicContest.SENSIBILITY Then
                Return Me
            End If
        End If
        Return Nothing
    End Function

    Public MustOverride Sub draw(gc As GraphicContest, inj As Injector)

    Public Sub move(p As xyPoint)
        X = p.X
        Y = p.Y
    End Sub
    Public Sub unSelect()
        Selected = False
    End Sub
    Public Overloads Overrides Function Equals(obj As Object) As Boolean

        If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
            Return False
        End If

        Dim p As xyPoint = CType(obj, xyPoint)

        Return Me.X = p.X And Me.Y = p.Y
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return X Xor Y
    End Function
    Public Shared Operator =(p1 As xyPoint, p2 As xyPoint) As Boolean
        If Not p1 Is Nothing Then
            Return p1.Equals(p2)
        Else
            Return False
        End If
    End Operator
    Public Shared Operator <>(p1 As xyPoint, p2 As xyPoint) As Boolean
        If Not p1 Is Nothing Then
            Return Not p1.Equals(p2)
        Else
            Return True
        End If
    End Operator

    Public Function serialize() As String Implements Serializable.serialize
        Return String.Format(X) + ";" + String.Format(Y)
    End Function

    Public Sub deserialize(strVal As String) Implements Serializable.deserialize
        Dim strDecimalSep = String.Format(1.1).Substring(1, 1)
        Dim strLocal As String

        strLocal = strVal.Replace(".", strDecimalSep).Replace(",", strDecimalSep)
        Dim val() As String = strLocal.Split(";")
        X = Convert.ToDouble(val(0))
        Y = Convert.ToDouble(val(1))
    End Sub
End Class
