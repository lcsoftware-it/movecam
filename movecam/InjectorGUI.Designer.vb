<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InjectorGUI
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblNeedle = New System.Windows.Forms.Label()
        Me.injColorDialog = New System.Windows.Forms.ColorDialog()
        Me.cbNeedle = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPressure = New System.Windows.Forms.TextBox()
        Me.pbColor = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnRemoveColor = New System.Windows.Forms.Button()
        Me.txtOffsetX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOfsXdown = New System.Windows.Forms.Button()
        Me.btnOfsXup = New System.Windows.Forms.Button()
        Me.btnOfsYup = New System.Windows.Forms.Button()
        Me.btnOfsYdown = New System.Windows.Forms.Button()
        Me.txtOffsetY = New System.Windows.Forms.TextBox()
        CType(Me.pbColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(232, 268)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(67, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(148, 268)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblNeedle
        '
        Me.lblNeedle.AutoSize = True
        Me.lblNeedle.Location = New System.Drawing.Point(171, 13)
        Me.lblNeedle.Name = "lblNeedle"
        Me.lblNeedle.Size = New System.Drawing.Size(44, 13)
        Me.lblNeedle.TabIndex = 3
        Me.lblNeedle.Text = "Needle:"
        Me.lblNeedle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbNeedle
        '
        Me.cbNeedle.FormattingEnabled = True
        Me.cbNeedle.Location = New System.Drawing.Point(229, 13)
        Me.cbNeedle.Name = "cbNeedle"
        Me.cbNeedle.Size = New System.Drawing.Size(70, 21)
        Me.cbNeedle.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Pressure:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPressure
        '
        Me.txtPressure.Location = New System.Drawing.Point(229, 100)
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.Size = New System.Drawing.Size(70, 20)
        Me.txtPressure.TabIndex = 9
        '
        'pbColor
        '
        Me.pbColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pbColor.Location = New System.Drawing.Point(229, 40)
        Me.pbColor.Name = "pbColor"
        Me.pbColor.Size = New System.Drawing.Size(70, 50)
        Me.pbColor.TabIndex = 5
        Me.pbColor.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.movecam.My.Resources.Resources.Inj_New_Lite
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(125, 279)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'btnRemoveColor
        '
        Me.btnRemoveColor.Location = New System.Drawing.Point(151, 40)
        Me.btnRemoveColor.Name = "btnRemoveColor"
        Me.btnRemoveColor.Size = New System.Drawing.Size(64, 50)
        Me.btnRemoveColor.TabIndex = 10
        Me.btnRemoveColor.Text = "Remove color"
        Me.btnRemoveColor.UseVisualStyleBackColor = True
        '
        'txtOffsetX
        '
        Me.txtOffsetX.Location = New System.Drawing.Point(243, 131)
        Me.txtOffsetX.Name = "txtOffsetX"
        Me.txtOffsetX.Size = New System.Drawing.Size(42, 20)
        Me.txtOffsetX.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(164, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Offset X:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(164, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Offset Y:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOfsXdown
        '
        Me.btnOfsXdown.Location = New System.Drawing.Point(229, 130)
        Me.btnOfsXdown.Name = "btnOfsXdown"
        Me.btnOfsXdown.Size = New System.Drawing.Size(14, 23)
        Me.btnOfsXdown.TabIndex = 15
        Me.btnOfsXdown.Text = "<"
        Me.btnOfsXdown.UseVisualStyleBackColor = True
        '
        'btnOfsXup
        '
        Me.btnOfsXup.Location = New System.Drawing.Point(285, 130)
        Me.btnOfsXup.Name = "btnOfsXup"
        Me.btnOfsXup.Size = New System.Drawing.Size(14, 23)
        Me.btnOfsXup.TabIndex = 16
        Me.btnOfsXup.Text = ">"
        Me.btnOfsXup.UseVisualStyleBackColor = True
        '
        'btnOfsYup
        '
        Me.btnOfsYup.Location = New System.Drawing.Point(285, 158)
        Me.btnOfsYup.Name = "btnOfsYup"
        Me.btnOfsYup.Size = New System.Drawing.Size(14, 23)
        Me.btnOfsYup.TabIndex = 19
        Me.btnOfsYup.Text = ">"
        Me.btnOfsYup.UseVisualStyleBackColor = True
        '
        'btnOfsYdown
        '
        Me.btnOfsYdown.Location = New System.Drawing.Point(229, 158)
        Me.btnOfsYdown.Name = "btnOfsYdown"
        Me.btnOfsYdown.Size = New System.Drawing.Size(14, 23)
        Me.btnOfsYdown.TabIndex = 18
        Me.btnOfsYdown.Text = "<"
        Me.btnOfsYdown.UseVisualStyleBackColor = True
        '
        'txtOffsetY
        '
        Me.txtOffsetY.Location = New System.Drawing.Point(243, 159)
        Me.txtOffsetY.Name = "txtOffsetY"
        Me.txtOffsetY.Size = New System.Drawing.Size(42, 20)
        Me.txtOffsetY.TabIndex = 17
        '
        'InjectorGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 304)
        Me.Controls.Add(Me.btnOfsYup)
        Me.Controls.Add(Me.btnOfsYdown)
        Me.Controls.Add(Me.txtOffsetY)
        Me.Controls.Add(Me.btnOfsXup)
        Me.Controls.Add(Me.btnOfsXdown)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOffsetX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRemoveColor)
        Me.Controls.Add(Me.txtPressure)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbNeedle)
        Me.Controls.Add(Me.pbColor)
        Me.Controls.Add(Me.lblNeedle)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "InjectorGUI"
        Me.Text = "InjectorGUI"
        CType(Me.pbColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblNeedle As Label
    Friend WithEvents pbColor As PictureBox
    Friend WithEvents injColorDialog As ColorDialog
    Friend WithEvents cbNeedle As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPressure As TextBox
    Friend WithEvents btnRemoveColor As Button
    Friend WithEvents txtOffsetX As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOfsXdown As Button
    Friend WithEvents btnOfsXup As Button
    Friend WithEvents btnOfsYup As Button
    Friend WithEvents btnOfsYdown As Button
    Friend WithEvents txtOffsetY As TextBox
End Class
