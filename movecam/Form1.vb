Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class Form1
    Dim r As Robot
    Dim ctrlCNC As New Controller

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'IcImagingControl1.MemorySnapImage()
        ' Copy the last grabbed image to the PictureBox control
        'PictureBox1.Image = IcImagingControl1.ImageActiveBuffer().SaveAsJpeg
        createMosaicoTest()

    End Sub

    Private Sub ConvertiFileBmpToFileJpg(ByVal FileBMP As String)

        'Creo un oggetto di tipo Immagine Bitmap che contrrà l'immagine da convertire

        Dim ImgBMP As New Bitmap(FileBMP)

        'Prendo il nome del file cancello le ultime quattro caratteri .bmp e inserisco .jpg

        Dim FileJPG As String = Strings.Left(FileBMP, Len(FileBMP) - 4) & ".jpg"

        'Ora salvo il file JPG

        ImgBMP.Save(FileJPG, System.Drawing.Imaging.ImageFormat.Jpeg)

        'Distruggo lo spazio di memoria occupato in precedenza, Dealloco la memoria dell'oggetto ImgBTMP

        ImgBMP.Dispose()

    End Sub

    Private Sub creaMosaicoImmagini()
        Dim incImage As Image

        incImage = Image.FromFile("myImage.jpg")

        Dim bmpImage As New Bitmap(incImage)
        'Creo la nuova immagine fornendo le dimensioni
        Dim resultImage As New Bitmap(580, 180, PixelFormat.Format32bppArgb)
        'Creo il pennello che mi servirà per il rendering del testo
        Dim pennello As SolidBrush = New SolidBrush(Color.FromArgb(0, 74, 115))
        'Creo l'oggetto Graphics per la nuova imagine
        Dim graphic As Graphics = Graphics.FromImage(resultImage)
        'Pulisco l'immagine e aggiungo l'antialiasing (anche per il testo)
        graphic.Clear(Color.FromArgb(167, 187, 215, 255))
        graphic.DrawImage(incImage, New Point(0, 0))
        resultImage.Save("newImage.jpg")
    End Sub
    Private Sub createMosaicoTest()
        Dim i1, i2 As Image

        i1 = Image.FromFile("foto1.bmp")
        i2 = Image.FromFile("foto2.bmp")
        PictureBox1.Width = i1.Width
        PictureBox1.Height = i1.Height
        PictureBox1.Image = sovrapponi(i1, i2, CInt(xOffset.Text), CInt(yOffset.Text))
        Dim rc As Rectangle
        rc = New Rectangle(260, 10, 220, 220)
        Dim offset As Point
        offset = New Point(CInt(xOffset.Text), CInt(yOffset.Text))
        diff.Text = getImageDiff(i1, i2, rc, offset)

    End Sub

    Private Function creaScansione(nRow As Integer, nCol As Integer, latoQuadratoX As Integer, latoQuadratoY As Integer) As Bitmap
        Return New Bitmap(latoQuadratoX * nCol, latoQuadratoY * nRow, PixelFormat.Format16bppRgb555)
    End Function

    Private Sub appendFotogrammaScansione(nRow As Integer, nCol As Integer, latoQuadratoX As Integer, latoQuadratoY As Integer, scansione As Image, fotogramma As Image)
        Dim graphic As Graphics = Graphics.FromImage(scansione)
        graphic.DrawImage(fotogramma, latoQuadratoX * (nCol - 1), latoQuadratoY * (nRow - 1))
    End Sub
    Private Sub saveImageAsJPG(img As Image, name As String, quality As Integer)
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        myImageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg)
        myEncoder = Encoder.Quality
        myEncoderParameters = New EncoderParameters(1)
        myEncoderParameter = New EncoderParameter(myEncoder, CType(quality, Int32))
        myEncoderParameters.Param(0) = myEncoderParameter
        img.Save(name & ".jpg", myImageCodecInfo, myEncoderParameters)
    End Sub
    Private Function GetEncoderInfo(ByVal format As ImageFormat) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).FormatID = format.Guid Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo

    Private Function sovrapponi(img1 As Image, img2 As Image, x As Integer, y As Integer) As Image

        Dim cm As New Drawing.Imaging.ColorMatrix
        Dim atr As New Drawing.Imaging.ImageAttributes
        Dim g As Graphics = Graphics.FromImage(img1)
        Dim r As New Rectangle(x, y, img1.Width - x, img1.Height - y)
        cm(3, 3) = 0.6   'draw with 60% alpha
        atr.SetColorMatrix(cm)
        g.DrawImage(img2, r, 0, 0, r.Width, r.Height, Drawing.GraphicsUnit.Pixel, atr)
        g.Dispose()
        atr.Dispose()
        Return img1

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        xOffset.Text = CInt(xOffset.Text) - 1
        createMosaicoTest()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        yOffset.Text = CInt(yOffset.Text) - 1
        createMosaicoTest()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        xOffset.Text = CInt(xOffset.Text) + 1
        createMosaicoTest()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        yOffset.Text = CInt(yOffset.Text) + 1
        createMosaicoTest()

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim dmin As Long = Long.MaxValue
        Dim x, y As Integer
        Dim offsetmin As Point
        Dim i1, i2 As Image
        i1 = Image.FromFile("foto1.bmp")
        i2 = Image.FromFile("foto2.bmp")

        offsetmin = New Point(xOffset.Text, yOffset.Text)

        Dim rc As Rectangle

        rc = New Rectangle(260, 10, 220, 220)
        Dim offset As Point

        Dim curdif As Int32 = Int32.MaxValue
        offset = New Point(CInt(xOffset.Text), CInt(yOffset.Text))
        diff.Text = getImageDiff(i1, i1, rc, offset)

        'For x = 225 To 255
        For x = 150 To 290
            xOffset.Text = x
            offset.X = x
            For y = -1 To 1
                yOffset.Text = y
                offset.Y = y
                curdif = getImageDiff(i1, i2, rc, offset, curdif)
                If curdif < dmin Then
                    dmin = curdif
                    offsetmin = offset
                End If
            Next
        Next
        xOffset.Text = offsetmin.X
        yOffset.Text = offsetmin.Y
        createMosaicoTest()
    End Sub

    Private Sub showBN(img As Image)
        Dim cm As New System.Drawing.Imaging.ColorMatrix(New Single()() _
                   {New Single() {0.299, 0.299, 0.299, 0, 0},
                    New Single() {0.587, 0.587, 0.587, 0, 0},
                    New Single() {0.114, 0.114, 0.114, 0, 0},
                    New Single() {0, 0, 0, 1, 0},
                    New Single() {0, 0, 0, 0, 1}})
        Using ia As New System.Drawing.Imaging.ImageAttributes
            ia.SetColorMatrix(cm)
            Dim rc As New Rectangle(0, 0, img.Width, img.Height)
            Using bClone As Bitmap = DirectCast(img.Clone, Bitmap)
                Using g As Graphics = Graphics.FromImage(img)
                    g.Clear(Color.Transparent)
                    g.DrawImage(bClone, rc, 0, 0, bClone.Width, bClone.Height, GraphicsUnit.Pixel, ia)
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PictureBox1.Image = Image.FromFile("i3_480.bmp")
        showBN(PictureBox1.Image)
    End Sub

    Private Sub PictureBox_MouseWheel(sender As System.Object,
                             e As MouseEventArgs) Handles PictureBox1.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If PictureBox1.Width < 500 Then Exit Sub 'minimum 500?
            Else
                If PictureBox1.Width > 2000 Then Exit Sub 'maximum 2000?
            End If

            PictureBox1.Width += CInt(PictureBox1.Width * e.Delta / 1000)
            PictureBox1.Height += CInt(PictureBox1.Height * e.Delta / 1000)
        End If

    End Sub

    Private Sub rotate(degree As Double)
        Dim g As Graphics

        g = Graphics.FromImage(PictureBox1.Image)
        g.RotateTransform(degree)
        g.DrawImage(PictureBox1.Image, New Point(0, 0))
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        rotate(txtRotate.Text)
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim r As Single

        r = CSng(txtRotate.Text)
        If r <> 0 Then
            e.Graphics.TranslateTransform(100.0F, 0.0F)
            e.Graphics.RotateTransform(r)
            e.Graphics.DrawImage(PictureBox1.Image, New Point(0, 0))
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        posX.Text = MousePosition.X + Panel1.HorizontalScroll.Value
        posY.Text = MousePosition.Y + Panel1.VerticalScroll.Value
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim j As Job

        j = New Job("pippo")
        MsgBox(j.FilePath, MsgBoxStyle.OkOnly)


        r = New Robot(10, 10, 20)
        injGrid.DataSource = r.Injectors
        'Dim inj As Injector


        'For Each inj In r.Injectors
        'injGrid.Rows.Add()
        'injGrid.Rows(inj.Position).Cells.Item(0).Value = CStr(inj.Position)
        'MsgBox(CStr(inj.Position) + " " + CStr(inj.Valvola) + " " + CStr(inj.Cilindro))
        'Next
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        r.XAxis.MinPos = xmin.Text
        r.YAxis.MinPos = ymin.Text
        r.ZAxis.MinPos = zmin.Text

        r.XAxis.MaxPos = xMAX.Text
        r.YAxis.MaxPos = yMAX.Text
        r.ZAxis.MaxPos = zMAX.Text

        r.XAxis.MinSpeed = vxmin.Text
        r.YAxis.MinSpeed = vymin.Text
        r.ZAxis.MinSpeed = vzmin.Text

        r.XAxis.MaxSpeed = vxMAX.Text
        r.YAxis.MaxSpeed = vyMAX.Text
        r.ZAxis.MaxSpeed = vzMAX.Text

        r.XAxis.SlowSpeed = vxinj.Text
        r.YAxis.SlowSpeed = vyinj.Text
        r.ZAxis.SlowSpeed = vzinj.Text

        r.XAxis.HighSpeed = vxmove.Text
        r.YAxis.HighSpeed = vymove.Text
        r.ZAxis.HighSpeed = vzmove.Text

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("microiniezione10.ini", False)
        file.WriteLine(r.XAxis.writeToConfig())
        file.WriteLine(r.YAxis.writeToConfig)
        file.WriteLine(r.ZAxis.writeToConfig)
        For Each inj As Injector In r.Injectors
            file.WriteLine(inj.writeToConfig)
        Next
        file.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click


        ctrlCNC.test()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = ctrlCNC.getCoord()
    End Sub
End Class
