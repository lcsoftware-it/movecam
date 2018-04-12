Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic.PowerPacks

Public Class DrawTest
    Private Enum drawingState
        none
        dwPoint
        dwSegment
        dwArc
        dwBspline
        dwBControlSpline
    End Enum

    Dim injpaths As List(Of InjElement) = New List(Of InjElement)
    Dim points As List(Of MousePoint) = New List(Of MousePoint)
    Dim bs As BSpline
    Dim bsc As BControlSpline
    Dim sp As Spezzata
    Dim movingPoint As xyPoint = Nothing
    Dim movingInjElement As InjElement
    Private pbP1Phisical As Point
    Private pbP2Phisical As Point
    Private pbP1Logical As Point
    Private pbP2Logical As Point
    Private currentZoom As Zoom
    Private currentPoint As Point = New Point(0, 0)
    Private pbStartWidth As Integer
    Private pbStartHeight As Integer
    Private a As Arco
    Private inj As Injector
    Private dwState As drawingState
    Private MIN_ZOOM As Double = My.Settings.minZoom
    Private MAX_ZOOM As Double = My.Settings.maxZoom

    Private Sub ProjectArea_Paint(sender As Object, e As PaintEventArgs) Handles ProjectArea.Paint

        MyBase.OnPaint(e)

        Dim myPen As New Pen(Color.Black, 1) 'to set width of pen


        myPen.Dispose()
        Dim gc As GraphicContest = New GraphicContest(e.Graphics, currentZoom, Color.Red)
        For Each path In injpaths
            path.draw(gc)
        Next
        drawGrid(gc)

    End Sub
    Private Sub nsgment_ValueChanged(sender As Object, e As EventArgs) Handles nsgment.ValueChanged
        ProjectArea.Invalidate()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProjectArea.Invalidate()
    End Sub
    Private Sub ProjectArea_MouseDown(sender As Object, e As MouseEventArgs) Handles ProjectArea.MouseDown


        'Dim mp As xyPoint = New xyPoint(currentZoom.getRealPoint(New Point(e.X, e.Y)), xyPoint.PointInjStateEnum.Inject, xyPoint.PointDrawTypeEnum.Injection, inj.Colore)
        Dim mp As MousePoint = New MousePoint(currentZoom.getRealPoint(New Point(e.X, e.Y)), inj)

        Select Case e.Button
            Case MouseButtons.Left
                Select Case dwState
                    Case drawingState.dwPoint
                        createPoint(mp)
                    Case drawingState.dwSegment
                        createLine(mp)
                    Case drawingState.dwArc
                        drawArc(mp)
                    Case drawingState.dwBspline
                        drawSpline(mp)
                    Case drawingState.dwBControlSpline
                        drawControlSpline(mp)
                End Select
            Case MouseButtons.Right
                cmdSelect.PerformClick()
                movingPoint = Nothing
                movingInjElement = Nothing
                For Each injp In injpaths
                    'injp.unSelect()
                    movingPoint = injp.findPoint(mp)
                    If Not movingPoint Is Nothing Then
                        movingPoint.Selected = True
                        movingInjElement = injp
                        Exit For
                    End If
                Next
                'movingPoint = bsc.findPoint(mp)
        End Select

    End Sub

    Private Sub ProjectArea_MouseMove(sender As Object, e As MouseEventArgs) Handles ProjectArea.MouseMove
        'Dim mp As xyPoint = New xyPoint(currentZoom.getRealPoint(New Point(e.X, e.Y)), xyPoint.PointInjStateEnum.Inject, xyPoint.PointDrawTypeEnum.Injection, inj.Colore)
        Dim mp As MousePoint = New MousePoint(currentZoom.getRealPoint(New Point(e.X, e.Y)), inj)

        If Not movingPoint Is Nothing Then
            movingInjElement.moveSelectedPoint(mp)
            'bs.changePoint(mp, movingPoint)
            'bsc.changePoint(mp, movingPoint)
            'movingPoint = mp
            ProjectArea.Invalidate()
        End If
        currentPoint.X = currentZoom.getXReal(e.X)
        currentPoint.Y = currentZoom.getXReal(e.Y)
        aggiornaCaption()
    End Sub
    Private Sub ProjectArea_MouseUp(sender As Object, e As MouseEventArgs) Handles ProjectArea.MouseUp
        If Not movingPoint Is Nothing Then
            movingPoint = Nothing
            ProjectArea.Invalidate()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            inj.Colore = ColorDialog1.Color
            ProjectArea.Invalidate()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            'riattivare per spline
            'bs.SplineColor = ColorDialog1.Color
            ProjectArea.Invalidate()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            'riattivare per spline
            'bs.ControlColor = ColorDialog1.Color
            ProjectArea.Invalidate()
        End If
    End Sub
    Private Sub LoadBitmap(sender As Object, e As EventArgs) Handles btnLoadBitmap.Click
        If OpenFileDialog1.ShowDialog <> DialogResult.Cancel Then
            Dim img As Image = Image.FromFile(OpenFileDialog1.FileName)

            ProjectArea.Width = img.Width
            pbStartWidth = ProjectArea.Width

            ProjectArea.Height = img.Height
            pbStartHeight = ProjectArea.Height

            ProjectArea.Image = img
        End If
    End Sub
    Private Sub DrawTest_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ProjectArea.Width = ProjectAreaPanel.Width - 5
        ProjectArea.Height = ProjectAreaPanel.Height - 5
        pbP1Phisical = New Point(ProjectArea.Left, ProjectArea.Top)
        pbP2Phisical = New Point(ProjectArea.Right, ProjectArea.Bottom)
        pbP1Logical = New Point(0, 0)
        pbP2Logical = New Point(ProjectArea.Right - ProjectArea.Left, ProjectArea.Bottom - ProjectArea.Top)

        inj = New Injector(0)
        inj.Colore = Color.Olive
        currentZoom = New Zoom(New Rectangle(0, 0, Me.ProjectArea.Width, Me.ProjectArea.Height))
        Me.txtZoom.Text = "100"

        Me.McrjSpinControl1.MaxVal = MAX_ZOOM * 100
        Me.McrjSpinControl1.MinVal = MIN_ZOOM * 100
        Me.McrjSpinControl1.CurrentVal = 100
        'dwState = drawingState.none
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Zoom(1)
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Zoom(-1)
    End Sub
    Private Sub Zoom(direction As Integer)
        Dim newDelta As Double


        newDelta = (CDbl(Me.txtZoom.Text) + direction * 10) / 100.0
        If newDelta < 0.1 Then Exit Sub
        If newDelta > 5 Then Exit Sub
        Me.txtZoom.Text = Format(newDelta * 100, "0")
        Me.txtZoom.Update()
        currentZoom.changeZoom(newDelta)
        ProjectArea.Height = pbStartHeight * currentZoom.delta
        ProjectArea.Width = pbStartWidth * currentZoom.delta
        ProjectArea.Invalidate()
        aggiornaCaption()

    End Sub
    Private Function setZoom(newDelta As Double) As Double
        If newDelta < MIN_ZOOM Then newDelta = MIN_ZOOM
        If newDelta > MAX_ZOOM Then newDelta = MAX_ZOOM
        currentZoom.changeZoom(newDelta)
        ProjectArea.Height = pbStartHeight * currentZoom.delta
        ProjectArea.Width = pbStartWidth * currentZoom.delta
        ProjectArea.Invalidate()
        aggiornaCaption()
        Return newDelta
    End Function

    Private Sub aggiornaCaption()
        Dim TipText As String = String.Format("x={0} y={1}, Zoom={2}%", Format(currentPoint.X, "#0.00"), Format(currentPoint.Y, "#0.00"), Format(currentZoom.delta * 100, "#0"))

        Text = TipText
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        MessageBox.Show("1")
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        MessageBox.Show("2")
    End Sub
    Private Sub drawArc(p As MousePoint)
        If points.Count = 0 And bLineeContinue.Checked Then
            Dim pTemp As MousePoint
            pTemp = lastPointClicked()
            If pTemp IsNot Nothing Then
                points.Add(pTemp)
            End If
        End If

        If points.Count < 3 Then
            points.Add(p)
        End If
        If points.Count = 3 Then
            a = New Arco(points.ElementAt(0), points.ElementAt(1), points.ElementAt(2), inj)
            a.nSegments = 10
            injpaths.Add(a)
            a = Nothing
            points.Clear()
        End If
        ProjectArea.Invalidate()
    End Sub
    Private Sub drawSpline(p As MousePoint)
        If points.Count = 0 And bLineeContinue.Checked Then
            Dim pTemp As MousePoint
            pTemp = lastPointClicked()
            If pTemp IsNot Nothing Then
                points.Add(pTemp)
            End If
        End If
        If points.Count < 2 Then
            points.Add(p)
        ElseIf points.Count = 2 Then
            points.Add(p)
            bs = New BSpline(MousePoint.toControlPointList(points), 2, True, 5, inj)
            bs.ControlColor = Color.DarkGray
            bs.SplineColor = Color.Orange
            injpaths.Add(bs)
        Else
            bs.addPoint(p)
        End If
        ProjectArea.Invalidate()
    End Sub
    Private Sub drawControlSpline(p As MousePoint)
        If points.Count = 0 And bLineeContinue.Checked Then
            Dim pTemp As MousePoint
            pTemp = lastPointClicked()
            If pTemp IsNot Nothing Then
                points.Add(pTemp)
            End If
        End If
        If points.Count < 2 Then
            points.Add(p)
        ElseIf points.Count = 2 Then
            points.Add(p)
            bsc = New BControlSpline(MousePoint.toControlPointList(points))
            'bs.ControlColor = Color.DarkGray
            'bs.SplineColor = Color.Orange
            injpaths.Add(bsc)
        Else
            bsc.addPoint(p)
        End If
        ProjectArea.Invalidate()
    End Sub
    Private Sub createLine(p As MousePoint)
        If points.Count = 0 And bLineeContinue.Checked Then
            Dim pTemp As MousePoint
            pTemp = lastPointClicked()
            If pTemp IsNot Nothing Then
                points.Add(pTemp)
            End If
            sp = New Spezzata(MousePoint.toControlPointList(points), inj)
            injpaths.Add(sp)
            points.Add(p)
        Else
            points.Add(p)
            If points.Count = 1 Then
                sp = New Spezzata(MousePoint.toControlPointList(points), inj)
                injpaths.Add(sp)
            Else
                sp.addPoint(p)
            End If

        End If
        ProjectArea.Invalidate()
    End Sub
    Private Sub createPoint(p As MousePoint)
        Dim xyp As xyPoint
        xyp = New InjPoint(p.p, True, True)
        Dim sp As SinglePoint
        sp = New SinglePoint(xyp, inj)
        injpaths.Add(sp)
        ProjectArea.Invalidate()
    End Sub
    Private Function lastPointClicked() As MousePoint
        If injpaths IsNot Nothing And injpaths.Count > 0 Then
            Dim mp As MousePoint = New MousePoint(injpaths.Last().getLastInjPoint().P, inj)
            Return mp
        Else
            Return Nothing
        End If
    End Function
    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles cmdDrawLine.CheckedChanged
        If cmdDrawLine.Checked Then
            dwState = drawingState.dwSegment
            points = New List(Of MousePoint)
        Else
            dwState = drawingState.none
        End If
    End Sub
    Private Sub cmdDrawArc_CheckedChanged(sender As Object, e As EventArgs) Handles cmdDrawArc.CheckedChanged
        If cmdDrawArc.Checked Then
            dwState = drawingState.dwArc
            points = New List(Of MousePoint)
        Else
            dwState = drawingState.none
        End If
    End Sub
    Private Sub cmdDrawSpline_CheckedChanged(sender As Object, e As EventArgs) Handles cmdDrawSpline.CheckedChanged
        If cmdDrawSpline.Checked Then
            dwState = drawingState.dwBspline
            points = New List(Of MousePoint)
        Else
            dwState = drawingState.none
        End If
    End Sub
    Private Sub cmdDrawControlSpline_CheckedChanged(sender As Object, e As EventArgs) Handles cmdDrawControlSpline.CheckedChanged
        If cmdDrawControlSpline.Checked Then
            dwState = drawingState.dwBControlSpline
            points = New List(Of MousePoint)
        Else
            dwState = drawingState.none
        End If

    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Job3|*.job3"
        saveFileDialog1.Title = "Save a Job File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(saveFileDialog1.FileName, False)
            For Each ip In injpaths
                If ip.GetType() = GetType(Arco) Then
                    Dim a As Arco = ip
                    file.WriteLine(a.serialize())
                End If
                If ip.GetType() = GetType(Spezzata) Then
                    Dim sp As Spezzata = ip
                    file.WriteLine(sp.serialize())
                End If
            Next
            file.Close()

            MsgBox("JOB saved")
        End If
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Job3|*.job3"
        openFileDialog1.Title = "Save a Job File"
        openFileDialog1.ShowDialog()

        If openFileDialog1.FileName <> "" Then
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(openFileDialog1.FileName)
            Dim fileRow As String = ""
            While Not fileReader.EndOfStream()
                fileRow = fileReader.ReadLine()
                Select Case fileRow.Substring(0, 2)
                    Case "SP"
                        sp = New Spezzata(New List(Of ControlPoint), New Injector(1))
                        sp.deserialize(fileRow)
                        injpaths.Add(sp)
                    Case "AR"
                        a = New Arco(New MousePoint(currentZoom.getRealPoint(New Point(1, 1)), inj), 10, New Injector(1))
                        a.deserialize(fileRow)
                        injpaths.Add(a)
                End Select

            End While

            MsgBox("The last line of the file is " & fileRow)
            fileReader.Close()

            MsgBox("JOB loaded")
        End If

    End Sub
    Private Sub DrawTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbStartHeight = ProjectArea.Height
        pbStartWidth = ProjectArea.Width
        Me.dimx.Text = pbStartWidth
        Me.dimy.Text = pbStartHeight


    End Sub
    Private Sub InjectorRadioButton_MouseDown(sender As Object, e As MouseEventArgs) Handles injControl1.MouseDown, injControl2.MouseDown, injControl3.MouseDown, injControl4.MouseDown, injControl5.MouseDown, injControl6.MouseDown, injControl7.MouseDown, injControl8.MouseDown, injControl9.MouseDown, injControl10.MouseDown, injControl11.MouseDown, injControl12.MouseDown
        Dim injGui As InjectorGUI
        Dim inj As Injector
        Dim injCtrl As RadioButton

        injCtrl = sender
        inj = Main.robot.Injector(CInt(sender.Name.Substring(10)))
        injGui = New InjectorGUI(inj)
        lblCurrentTool.Text = "INJECTOR " + sender.Name.Substring(10)
        If injGui.ShowDialog() Then
            setInjControl(inj, injCtrl)
        End If
        lblCurrentTool.BackColor = inj.Colore
    End Sub
    Private Function getNeedleCtrlOfInjector(rb As RadioButton) As OvalShape
        Dim shName As String = "needle" + rb.Name.Substring(10)

        For Each sh As Shape In ShapeContainer1.Shapes
            If sh.Name = shName Then
                Return sh
            End If
        Next
        Return Nothing

    End Function
    Private Function getLabelCtrlOfInjector(rb As RadioButton) As Label
        Dim father As Control
        father = rb.Parent
        For Each ctrl As Control In father.Controls
            If ctrl.Name = ("txtNeedle" + rb.Name.Substring(10)) Then
                Return ctrl
            End If
        Next
        Return Nothing
    End Function

    Private Sub setInjControl(inj As Injector, injCtrl As RadioButton)
        Dim needleCtrl As OvalShape
        Dim labelCtrl As Label
        Dim xloc, yloc As Integer

        needleCtrl = getNeedleCtrlOfInjector(injCtrl)
        xloc = needleCtrl.Location.X + needleCtrl.Size.Width / 2
        yloc = needleCtrl.Location.Y + needleCtrl.Size.Height / 2
        labelCtrl = getLabelCtrlOfInjector(injCtrl)

        injCtrl.ForeColor = textColorOnBackground(inj.Colore)

        injCtrl.BackColor = inj.Colore
        If injCtrl.BackColor = Me.BackColor Then
            injCtrl.BackgroundImage = My.Resources.ResourceManager.GetObject("NoColore")
        Else
            injCtrl.BackgroundImage = Nothing
        End If

        If (inj.Needle.Diameter = "") Then
            needleCtrl.Visible = False
            labelCtrl.Text = "---"
        Else
            needleCtrl.Visible = True
            needleCtrl.Size = New Size(inj.Needle.screenSize, inj.Needle.screenSize)
            needleCtrl.Location = New Point(xloc - needleCtrl.Size.Width / 2, yloc - needleCtrl.Size.Height / 2)
            labelCtrl.Text = inj.Needle.Diameter
        End If
    End Sub

    Private Sub DrawTest_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        MyBase.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim ColImage As New DataGridViewImageColumn
        Dim Img1 As New DataGridViewImageCell
        Dim Img2 As New DataGridViewImageCell
        Dim Img3 As New DataGridViewImageCell
        Dim Img4 As New DataGridViewImageCell
        Dim Img5 As New DataGridViewImageCell
        Dim Img6 As New DataGridViewImageCell
        Dim Img7 As New DataGridViewImageCell
        Dim Img8 As New DataGridViewImageCell
        Dim Img9 As New DataGridViewImageCell

        ColImage.Name = "ColImg"

        'Set Header text
        ColImage.HeaderText = "Point Type"

        'Add column to datagridview

        'Set image value
        Img1.Value = My.Resources.StartON
        Img2.Value = My.Resources.StartOff
        Img3.Value = My.Resources.OnMidOn
        Img4.Value = My.Resources.OnMidOff
        Img5.Value = My.Resources.OffMidOn
        Img6.Value = My.Resources.OffMidOff
        Img7.Value = My.Resources.EndOn
        Img8.Value = My.Resources.EndOff
        Img9.Value = My.Resources.InjectSinglePoint

        'Add the image cell to a row
        tablePathData.Columns.Clear()
        tablePathData.Columns.Add("N", "N")
        tablePathData.Columns.Add(ColImage)


        tablePathData.Rows.Clear()
        tablePathData.Rows.Add(1, Img1.Value)
        tablePathData.Rows.Add(2, Img2.Value)
        tablePathData.Rows.Add(3, Img3.Value)
        tablePathData.Rows.Add(4, Img4.Value)
        tablePathData.Rows.Add(5, Img5.Value)
        tablePathData.Rows.Add(6, Img6.Value)
        tablePathData.Rows.Add(7, Img7.Value)
        tablePathData.Rows.Add(8, Img8.Value)
        tablePathData.Rows.Add(9, Img9.Value)




    End Sub

    Private Sub cmdDrawPoint_CheckedChanged(sender As Object, e As EventArgs) Handles cmdDrawPoint.CheckedChanged
        cmdDrawPointExec()
    End Sub

    Private Sub applyDim_Click(sender As Object, e As EventArgs) Handles applyDim.Click
        pbStartHeight = Me.dimy.Text
        pbStartWidth = Me.dimx.Text
        Me.ProjectArea.Width = pbStartWidth
        Me.ProjectArea.Height = pbStartHeight
    End Sub

    Private Sub btnGrid_Click(sender As Object, e As EventArgs) Handles btnGrid.Click
        Dim r As Integer
        Dim c As Integer
        For r = 1 To 100
            For c = 1 To 100
                Dim xyp As xyPoint
                xyp = New InjPoint(New Point(c * CInt(gridSpaceX.Text), r * CInt(gridSpaceY.Text)), True, True)
                Dim sp As SinglePoint
                sp = New SinglePoint(xyp, inj)
                injpaths.Add(sp)
                ProjectArea.Invalidate()
            Next
        Next
    End Sub

    Private Sub cmdDrawPointExec()
        dwState = drawingState.dwPoint
    End Sub

    Private Sub tsbPoint_Click(sender As Object, e As EventArgs) Handles tsbPoint.Click
        cmdDrawPointExec()
    End Sub
    Private Sub drawGrid(gc As GraphicContest)
        Dim x0, x1, y0, y1 As Single
        Dim dx, dy As Single
        Dim c As Single
        dx = 100
        dy = 100

        x0 = currentZoom.getXReal(0)
        y0 = currentZoom.getYReal(0)
        x1 = currentZoom.getXReal(ProjectArea.Width)
        y1 = currentZoom.getYReal(ProjectArea.Height)
        Dim p As Pen
        p = New Pen(Color.Azure)
        Dim drawFont As System.Drawing.Font
        drawFont = New System.Drawing.Font("Arial", 8)
        Dim drawBrush As System.Drawing.SolidBrush
        drawBrush = New System.Drawing.SolidBrush(System.Drawing.Color.Black)
        Dim drawFormat As System.Drawing.StringFormat
        drawFormat = New System.Drawing.StringFormat()


        p.DashStyle = DashStyle.Dash
        Dim cs, x0s, x1s, y0s, y1s As Single

        For c = Int(x0 / dx) * dx To (Int(x1 / dx) + 1) * dx Step dx
            cs = gc.Zoom.getXScreen(c)
            y0s = gc.Zoom.getXScreen(y0)
            y1s = gc.Zoom.getXScreen(y1)
            gc.G.DrawLine(p, cs, y0s, cs, y1s)
            gc.G.DrawString(Format(c / 10, "0"), drawFont, drawBrush, cs, 0, drawFormat)
        Next
        For c = Int(y0 / dy) * dy To (Int(y1 / dy) + 1) * dy Step dy
            cs = gc.Zoom.getXScreen(c)
            x0s = gc.Zoom.getXScreen(x0)
            x1s = gc.Zoom.getXScreen(x1)
            gc.G.DrawLine(p, x0s, cs, x1s, cs)
            gc.G.DrawString(Format(c / 10, "0"), drawFont, drawBrush, 0, cs, drawFormat)
        Next
        drawFormat.Dispose()
        drawBrush.Dispose()
        drawFont.Dispose()
        p.Dispose()

    End Sub

    Private Sub McrjSpinControl1_SpinValueConfirmed(value As Double) Handles McrjSpinControl1.SpinValueConfirmed
        Dim newZoom As Double

        newZoom = setZoom(value / 100) * 100
        McrjSpinControl1.CurrentVal = newZoom

    End Sub

    Private Sub ProjectAreax_MouseWheel(sender As System.Object, e As MouseEventArgs) Handles ProjectArea.MouseWheel
        Dim newZoom As Double

        If e.Delta <> 0 Then
            newZoom = setZoom(Math.Round(McrjSpinControl1.CurrentVal / 100 + e.Delta / 10000, 2)) * 100
            McrjSpinControl1.CurrentVal = newZoom
        End If

    End Sub

    Private Sub ProjectArea_MouseEnter(sender As Object, e As EventArgs) Handles ProjectArea.MouseEnter
        ProjectArea.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim newZoom As Double

        newZoom = setZoom(McrjSpinControl1.CurrentVal / 100 + 0.1) * 100
        McrjSpinControl1.CurrentVal = newZoom
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim newZoom As Double

        newZoom = setZoom(McrjSpinControl1.CurrentVal / 100 - 0.1) * 100

        McrjSpinControl1.CurrentVal = newZoom

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim newZoom As Double

        newZoom = setZoom(1) * 100

        McrjSpinControl1.CurrentVal = newZoom

    End Sub
End Class