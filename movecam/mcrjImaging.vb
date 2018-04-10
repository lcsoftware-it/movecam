Module mcrjImaging

    Public Function getImageDiff(img1 As Image, img2 As Image, region As Rectangle, offset As Point, Optional limit As Int32 = Int32.MaxValue) As Long
        Dim c1 As Color
        Dim c2 As Color
        Dim b1 As Bitmap
        Dim b2 As Bitmap

        b1 = New Bitmap(img1)
        b2 = New Bitmap(img2)
        Dim diff As Int32 = 0
        For y As Integer = region.Top To region.Top + region.Height - 1
            For x As Integer = region.Left To region.Left + region.Width - 1
                c1 = b1.GetPixel(x, y)
                If (x - offset.X >= 0 And y - offset.Y >= 0) And (x - offset.X < b2.Width And y - offset.Y < b2.Height) Then
                    c2 = b2.GetPixel(x - offset.X, y - offset.Y)
                Else
                    c2 = Color.Black
                End If
                diff += Math.Abs(CInt(c1.R) - CInt(c2.R)) + Math.Abs(CInt(c1.G) - CInt(c2.G)) + Math.Abs(CInt(c1.B) - CInt(c2.B))
                If diff > limit Then
                    Return diff
                End If
            Next
        Next
        Return diff
    End Function

End Module
