Public Class InjectorGUI

    Private modifiedInjector As Injector

    Sub New(ByRef inj As Injector)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        For Each n As Needle In Main.needles
            cbNeedle.Items.Add(n)
        Next
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        modifiedInjector = inj
        pbColor.BackColor = inj.Colore
        cbNeedle.Text = inj.Needle.Diameter

        txtPressure.Text = CStr(inj.Pressure)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        modifiedInjector.Colore = pbColor.BackColor
        modifiedInjector.Needle = cbNeedle.SelectedItem
        If txtPressure.Text = "" Then
            modifiedInjector.Pressure = 0
        Else
            modifiedInjector.Pressure = Double.Parse(txtPressure.Text)
        End If
        If txtOffsetX.Text = "" Then
            modifiedInjector.OffsetX = 0
        Else
            modifiedInjector.OffsetX = Double.Parse(txtOffsetX.Text)
        End If
        If txtOffsetY.Text = "" Then
            modifiedInjector.OffsetY = 0
        Else
            modifiedInjector.OffsetY = Double.Parse(txtOffsetY.Text)
        End If

        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles pbColor.Click
        injColorDialog.Color = pbColor.BackColor
        injColorDialog.ShowDialog()
        pbColor.BackColor = injColorDialog.Color
    End Sub


    Private Sub btnRemoveColor_Click(sender As Object, e As EventArgs) Handles btnRemoveColor.Click
        injColorDialog.Color = Me.BackColor
        pbColor.BackColor = Nothing
    End Sub

    Private Sub btnOfsXdown_Click(sender As Object, e As EventArgs) Handles btnOfsXdown.Click
        txtBoxIncrement(txtOffsetX, Control.ModifierKeys, incrementDirection.down)
    End Sub

    Private Sub btnOfsXup_Click(sender As Object, e As EventArgs) Handles btnOfsXup.Click
        txtBoxIncrement(txtOffsetX, Control.ModifierKeys, incrementDirection.up)
    End Sub

    Private Sub btnOfsYup_Click(sender As Object, e As EventArgs) Handles btnOfsYup.Click
        txtBoxIncrement(txtOffsetY, Control.ModifierKeys, incrementDirection.up)
    End Sub

    Private Sub btnOfsYdown_Click(sender As Object, e As EventArgs) Handles btnOfsYdown.Click
        txtBoxIncrement(txtOffsetY, Control.ModifierKeys, incrementDirection.down)
    End Sub
End Class