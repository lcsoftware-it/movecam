Module UtilityMix

    Public Sub permutazioni(n As Integer)
        Dim i As Integer


        Console.WriteLine("START")
        Dim k As Long = 1

        Dim l As Long = Fattoriale(n)
        Dim elementi(n) As Integer
        Dim c(n) As Integer
        Dim d(n) As Integer
        For i = 0 To n - 1
            elementi(i) = i + 1
            c(i) = 0
            d(i) = 1
        Next
        Console.Write(k)
        Console.Write(")")
        For i = 0 To n - 1
            Console.Write(elementi(i))
            Console.Write(" ")
        Next
        Console.WriteLine(" ")
        'd(n - 1) = -1
        Dim j As Integer
        Do
            Dim flag As Boolean = True

            j = n - 1
            Dim s As Integer = 0

            Do
                Dim q As Integer = c(j) + d(j)
                If (q = 0 And j = -1) Then Exit Sub
                If (q >= 0 And q <> j + 1) Then
                    Dim t As Integer = elementi(j - c(j) + s)
                    elementi(j - c(j) + s) = elementi(j - q + s)
                    elementi(j - q + s) = t
                    c(j) = q
                    flag = False
                Else
                    If (q = j + 1) Then s = s + 1
                    If (q < 0 Or q = j + 1) Then
                        d(j) = -d(j)
                        j = j - 1
                    End If
                End If
            Loop While flag
            k = k + 1
            Console.Write(k)
            Console.Write(")")
            For i = 0 To n - 1
                Console.Write(elementi(i))
                Console.Write(" ")
            Next
            Console.WriteLine(" ")
        Loop While k < l
    End Sub

    Function Fattoriale(ByVal numero As Long) As Long




        If numero <= 1 Then
            'siamo nel caso base
            Return 1
        Else
            'chiamata ricorsiva
            Return numero * (Fattoriale(numero - 1))
        End If

    End Function

    Function textColorOnBackground(c As Color) As Color
        If (c.R / 3 + c.G / 3 + c.B / 3) <= 128.0 Then
            Return Color.White
        Else
            Return Color.Black
        End If
    End Function
End Module
