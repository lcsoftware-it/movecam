Option Explicit On
Imports movecam

Public Class Main

    Public Shared robot As Robot
    Public Shared needles As List(Of Needle)


    Private Sub CMD_EXIT_Click(sender As Object, e As EventArgs) Handles CMD_EXIT.Click
        Dim risp As Integer
        risp = MsgBox("Really do you want to exit?", vbQuestion + vbYesNo, "SYSTEM EXIT")
        If risp = vbYes Then
            End
        End If
    End Sub

    Private Sub CMD_SHUTDOWN_Click(sender As Object, e As EventArgs) Handles CMD_SHUTDOWN.Click
        Dim risp As Integer

        risp = MsgBox("Really do you want to shut down the system?", vbQuestion + vbYesNo, "SYSTEM SHUTDOWN")
        If risp = vbYes Then
            System.Diagnostics.Process.Start("shutdown", "-s -t 00")
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'MessageBox.Show("APP - appName:" + My.Settings.appName)
        'MessageBox.Show("USER - nSerie:" + My.Settings.nSerie)
        'MessageBox.Show("USER - nEsecuzioni:" + CStr(My.Settings.nEsecuzioni))
        'For Each n In My.Settings.needle
        'MessageBox.Show("USER - needle:" + n)
        'Next


        'permutazioni(7)
        RobotInit()
        DrawTest.Show()
        My.Settings.nEsecuzioni += 1
        My.Settings.Save()

    End Sub

    Private Sub RobotInit()
        robot = New Robot(12, 0, 12)
        needles = New List(Of Needle)
        needles.Add(New Needle(""))
        needles.Add(New Needle("0.15"))
        needles.Add(New Needle("0.45"))
        needles.Add(New Needle("0.80"))
        needles.Add(New Needle("1.00"))
        needles.Add(New Needle("1.25"))
        needles.Add(New Needle("1.40"))
        needles.Add(New Needle("1.80"))
        needles.Add(New Needle("2.00"))
        needles.Add(New Needle("2.25"))
        needles.Add(New Needle("2.75"))
        needles.Add(New Needle("3.00"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class