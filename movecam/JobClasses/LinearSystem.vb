Public Class LinearSystem
    Private _A As Matrix
    Private _b As Single()


    Public Sub New(A As Matrix, b As Single())
        Me._A = A
        Me._b = b
    End Sub

    Public Sub New(A As Single(,), b As Single())
        Me.New(New Matrix(A), b)
    End Sub

    Public Function solve() As Single()
        Dim x As Single()

        ReDim x(UBound(_b))
        Dim i As Integer
        Dim denom As Single

        denom = _A.determinant()
        For i = 0 To UBound(_b)
            Dim Ax As Matrix
            Ax = New Matrix(_A.replaceColumn(_b, i))

            x(i) = Ax.determinant() / denom
        Next
        solve = x
    End Function

End Class
