Module GUICommonUtility

    Public Enum incrementDirection
        up
        down
    End Enum
    Public Sub txtBoxIncrement(txtVal As TextBox, key As Keys, direction As incrementDirection)
        Dim increment As Double
        Select Case key
            Case Keys.Shift
                increment = 0.01
            Case Keys.Control
                increment = 0.05
            Case Keys.Alt
                increment = 0.1
            Case Else
                increment = 0.5
        End Select
        If txtVal.Text = "" Then
            txtVal.Text = "0"
        End If
        If direction = incrementDirection.up Then

            txtVal.Text = CStr(Double.Parse(txtVal.Text) + increment)
        Else
            txtVal.Text = CStr(Double.Parse(txtVal.Text) - increment)
        End If
    End Sub
End Module
