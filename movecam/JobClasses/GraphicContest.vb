Imports movecam

Public Class GraphicContest

    Public Const SENSIBILITY As Integer = 3

    Private _g As Graphics
    Private _z As Zoom
    Private _selectedColor As Color

    Public Sub New(g_p As Graphics, zoom_p As Zoom, selectedColor_p As Color)
        G = g_p
        Zoom = zoom_p
        SelectedColor = selectedColor_p
    End Sub

    Public Property G As Graphics
        Get
            Return _g
        End Get
        Set(value As Graphics)
            _g = value
        End Set
    End Property

    Public Property Zoom As Zoom
        Get
            Return _z
        End Get
        Set(value As Zoom)
            _z = value
        End Set
    End Property

    Public Property SelectedColor As Color
        Get
            Return _selectedColor
        End Get
        Set(value As Color)
            _selectedColor = value
        End Set
    End Property
End Class
