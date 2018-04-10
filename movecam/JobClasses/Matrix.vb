Public Class Matrix
    Private _a(,) As Single

    Public Property Value() As Single(,)
        Get
            Return Me._a
        End Get
        Set(ByVal value As Single(,))
            Me._a = value
        End Set
    End Property
    Public Sub New(value As Single(,))
        Dim i As Integer
        Dim j As Integer

        ReDim _a(UBound(value, 1), UBound(value, 2))
        For i = 0 To UBound(value, 1)
            For j = 0 To UBound(value, 2)
                _a(i, j) = value(i, j)
            Next
        Next
    End Sub
    Public Function complement(r As Integer, c As Integer) As Single(,)
        Dim v As Single(,)
        Dim righe As Integer
        Dim colonne As Integer

        righe = UBound(_a, 1)
        colonne = UBound(_a, 2)
        ReDim v(righe - 1, colonne - 1)
        Dim i As Integer
        Dim j As Integer
        Dim i1 As Integer
        Dim j1 As Integer

        For i = 0 To righe - 1
            If (i < r) Then
                i1 = i
            Else
                i1 = i + 1
            End If
            For j = 0 To colonne - 1
                If (j < c) Then
                    j1 = j
                Else
                    j1 = j + 1
                End If
                v(i, j) = _a(i1, j1)
            Next
        Next
        complement = v
    End Function
    Public Function replaceColumn(val As Single(), c As Integer) As Single(,)
        Dim v As Single(,)
        Dim righe As Integer
        Dim colonne As Integer

        righe = UBound(_a, 1)
        colonne = UBound(_a, 2)
        ReDim v(righe, colonne)
        Dim i As Integer
        Dim j As Integer

        For i = 0 To righe
            For j = 0 To colonne
                If (j = c) Then
                    v(i, j) = val(i)
                Else
                    v(i, j) = _a(i, j)
                End If
            Next
        Next
        replaceColumn = v
    End Function

    Public Function determinant() As Single
        Dim righe As Integer
        Dim colonne As Integer
        righe = UBound(_a, 1)
        colonne = UBound(_a, 2)
        If (righe <> colonne) Then
            determinant = 0
            Exit Function
        End If
        If (righe = 0) Then
            determinant = _a(0, 0)
        ElseIf (righe = 1) Then
            determinant = _a(0, 0) * _a(1, 1) - _a(0, 1) * _a(1, 0)
            Exit Function
        Else
            Dim i As Integer
            Dim det As Single
            det = 0
            For i = 0 To righe
                Dim m As New Matrix(Me.complement(i, 0))
                Dim k As Single
                k = m.determinant()
                Dim c As Integer
                If (i Mod 2 = 0) Then
                    c = 1
                Else
                    c = -1
                End If
                det = det + c * _a(i, 0) * k
            Next
            determinant = det
        End If
    End Function
End Class
