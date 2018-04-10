<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.IcImagingControl1 = New TIS.Imaging.ICImagingControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.xOffset = New System.Windows.Forms.TextBox()
        Me.yOffset = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.diff = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtRotate = New System.Windows.Forms.TextBox()
        Me.posX = New System.Windows.Forms.TextBox()
        Me.posY = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.xmin = New System.Windows.Forms.TextBox()
        Me.xMAX = New System.Windows.Forms.TextBox()
        Me.vxmin = New System.Windows.Forms.TextBox()
        Me.vxMAX = New System.Windows.Forms.TextBox()
        Me.vxinj = New System.Windows.Forms.TextBox()
        Me.vxmove = New System.Windows.Forms.TextBox()
        Me.vymove = New System.Windows.Forms.TextBox()
        Me.vyinj = New System.Windows.Forms.TextBox()
        Me.vyMAX = New System.Windows.Forms.TextBox()
        Me.vymin = New System.Windows.Forms.TextBox()
        Me.yMAX = New System.Windows.Forms.TextBox()
        Me.ymin = New System.Windows.Forms.TextBox()
        Me.vzmove = New System.Windows.Forms.TextBox()
        Me.vzinj = New System.Windows.Forms.TextBox()
        Me.vzMAX = New System.Windows.Forms.TextBox()
        Me.vzmin = New System.Windows.Forms.TextBox()
        Me.zMAX = New System.Windows.Forms.TextBox()
        Me.zmin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.injGrid = New System.Windows.Forms.DataGridView()
        Me.N = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cilindro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pistone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OffsetX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OffsetY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloreR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloreG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloreB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.IcImagingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.injGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IcImagingControl1
        '
        Me.IcImagingControl1.BackColor = System.Drawing.Color.White
        Me.IcImagingControl1.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke
        Me.IcImagingControl1.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke
        Me.IcImagingControl1.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded
        Me.IcImagingControl1.LiveDisplayPosition = New System.Drawing.Point(0, 0)
        Me.IcImagingControl1.Location = New System.Drawing.Point(9, 10)
        Me.IcImagingControl1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.IcImagingControl1.Name = "IcImagingControl1"
        Me.IcImagingControl1.Size = New System.Drawing.Size(112, 122)
        Me.IcImagingControl1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(157, 81)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 25)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(214, 147)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'xOffset
        '
        Me.xOffset.Location = New System.Drawing.Point(157, 24)
        Me.xOffset.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.xOffset.Name = "xOffset"
        Me.xOffset.Size = New System.Drawing.Size(76, 20)
        Me.xOffset.TabIndex = 3
        Me.xOffset.Text = "240"
        '
        'yOffset
        '
        Me.yOffset.Location = New System.Drawing.Point(157, 46)
        Me.yOffset.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.yOffset.Name = "yOffset"
        Me.yOffset.Size = New System.Drawing.Size(76, 20)
        Me.yOffset.TabIndex = 4
        Me.yOffset.Text = "0"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(131, 24)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(21, 18)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(131, 46)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(21, 18)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "<"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(236, 24)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(21, 18)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = ">"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(236, 46)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(21, 18)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = ">"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'diff
        '
        Me.diff.Location = New System.Drawing.Point(157, 112)
        Me.diff.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.diff.Name = "diff"
        Me.diff.Size = New System.Drawing.Size(76, 20)
        Me.diff.TabIndex = 9
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(262, 31)
        Me.Button6.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(110, 24)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "Trova allineamento"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(236, 81)
        Me.Button7.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(66, 25)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(9, 153)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(214, 360)
        Me.Panel1.TabIndex = 12
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(461, 46)
        Me.Button8.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(56, 19)
        Me.Button8.TabIndex = 13
        Me.Button8.Text = "Ruota"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txtRotate
        '
        Me.txtRotate.Location = New System.Drawing.Point(461, 24)
        Me.txtRotate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtRotate.Name = "txtRotate"
        Me.txtRotate.Size = New System.Drawing.Size(76, 20)
        Me.txtRotate.TabIndex = 14
        Me.txtRotate.Text = "0"
        '
        'posX
        '
        Me.posX.Location = New System.Drawing.Point(604, 24)
        Me.posX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.posX.Name = "posX"
        Me.posX.Size = New System.Drawing.Size(76, 20)
        Me.posX.TabIndex = 15
        '
        'posY
        '
        Me.posY.Location = New System.Drawing.Point(604, 46)
        Me.posY.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.posY.Name = "posY"
        Me.posY.Size = New System.Drawing.Size(76, 20)
        Me.posY.TabIndex = 16
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(604, 69)
        Me.Button9.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(67, 44)
        Me.Button9.TabIndex = 17
        Me.Button9.Text = "Init"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'xmin
        '
        Me.xmin.Location = New System.Drawing.Point(432, 159)
        Me.xmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.xmin.Name = "xmin"
        Me.xmin.Size = New System.Drawing.Size(39, 20)
        Me.xmin.TabIndex = 18
        '
        'xMAX
        '
        Me.xMAX.Location = New System.Drawing.Point(475, 159)
        Me.xMAX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.xMAX.Name = "xMAX"
        Me.xMAX.Size = New System.Drawing.Size(39, 20)
        Me.xMAX.TabIndex = 19
        '
        'vxmin
        '
        Me.vxmin.Location = New System.Drawing.Point(518, 159)
        Me.vxmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vxmin.Name = "vxmin"
        Me.vxmin.Size = New System.Drawing.Size(39, 20)
        Me.vxmin.TabIndex = 20
        '
        'vxMAX
        '
        Me.vxMAX.Location = New System.Drawing.Point(560, 159)
        Me.vxMAX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vxMAX.Name = "vxMAX"
        Me.vxMAX.Size = New System.Drawing.Size(39, 20)
        Me.vxMAX.TabIndex = 21
        '
        'vxinj
        '
        Me.vxinj.Location = New System.Drawing.Point(603, 159)
        Me.vxinj.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vxinj.Name = "vxinj"
        Me.vxinj.Size = New System.Drawing.Size(39, 20)
        Me.vxinj.TabIndex = 22
        '
        'vxmove
        '
        Me.vxmove.Location = New System.Drawing.Point(646, 159)
        Me.vxmove.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vxmove.Name = "vxmove"
        Me.vxmove.Size = New System.Drawing.Size(39, 20)
        Me.vxmove.TabIndex = 23
        '
        'vymove
        '
        Me.vymove.Location = New System.Drawing.Point(646, 182)
        Me.vymove.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vymove.Name = "vymove"
        Me.vymove.Size = New System.Drawing.Size(39, 20)
        Me.vymove.TabIndex = 29
        '
        'vyinj
        '
        Me.vyinj.Location = New System.Drawing.Point(603, 182)
        Me.vyinj.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vyinj.Name = "vyinj"
        Me.vyinj.Size = New System.Drawing.Size(39, 20)
        Me.vyinj.TabIndex = 28
        '
        'vyMAX
        '
        Me.vyMAX.Location = New System.Drawing.Point(560, 182)
        Me.vyMAX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vyMAX.Name = "vyMAX"
        Me.vyMAX.Size = New System.Drawing.Size(39, 20)
        Me.vyMAX.TabIndex = 27
        '
        'vymin
        '
        Me.vymin.Location = New System.Drawing.Point(518, 182)
        Me.vymin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vymin.Name = "vymin"
        Me.vymin.Size = New System.Drawing.Size(39, 20)
        Me.vymin.TabIndex = 26
        '
        'yMAX
        '
        Me.yMAX.Location = New System.Drawing.Point(475, 182)
        Me.yMAX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.yMAX.Name = "yMAX"
        Me.yMAX.Size = New System.Drawing.Size(39, 20)
        Me.yMAX.TabIndex = 25
        '
        'ymin
        '
        Me.ymin.Location = New System.Drawing.Point(432, 182)
        Me.ymin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ymin.Name = "ymin"
        Me.ymin.Size = New System.Drawing.Size(39, 20)
        Me.ymin.TabIndex = 24
        '
        'vzmove
        '
        Me.vzmove.Location = New System.Drawing.Point(646, 205)
        Me.vzmove.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vzmove.Name = "vzmove"
        Me.vzmove.Size = New System.Drawing.Size(39, 20)
        Me.vzmove.TabIndex = 35
        '
        'vzinj
        '
        Me.vzinj.Location = New System.Drawing.Point(603, 205)
        Me.vzinj.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vzinj.Name = "vzinj"
        Me.vzinj.Size = New System.Drawing.Size(39, 20)
        Me.vzinj.TabIndex = 34
        '
        'vzMAX
        '
        Me.vzMAX.Location = New System.Drawing.Point(560, 205)
        Me.vzMAX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vzMAX.Name = "vzMAX"
        Me.vzMAX.Size = New System.Drawing.Size(39, 20)
        Me.vzMAX.TabIndex = 33
        '
        'vzmin
        '
        Me.vzmin.Location = New System.Drawing.Point(518, 205)
        Me.vzmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.vzmin.Name = "vzmin"
        Me.vzmin.Size = New System.Drawing.Size(39, 20)
        Me.vzmin.TabIndex = 32
        '
        'zMAX
        '
        Me.zMAX.Location = New System.Drawing.Point(475, 205)
        Me.zMAX.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.zMAX.Name = "zMAX"
        Me.zMAX.Size = New System.Drawing.Size(39, 20)
        Me.zMAX.TabIndex = 31
        '
        'zmin
        '
        Me.zmin.Location = New System.Drawing.Point(432, 205)
        Me.zmin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.zmin.Name = "zmin"
        Me.zmin.Size = New System.Drawing.Size(39, 20)
        Me.zmin.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(389, 162)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Axis X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(388, 184)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Asse Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(388, 207)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Asse Z"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(448, 143)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "min"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(485, 143)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "MAX"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(533, 143)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "min"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(571, 143)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "MAX"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(652, 143)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "move"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(625, 143)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "inj"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(453, 129)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Posizione"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(571, 129)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Velocità"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(622, 444)
        Me.Button10.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(99, 35)
        Me.Button10.TabIndex = 47
        Me.Button10.Text = "Salva in microiniezione10"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'injGrid
        '
        Me.injGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.injGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.N, Me.Cilindro, Me.Pistone, Me.OffsetX, Me.OffsetY, Me.coloreR, Me.coloreG, Me.coloreB})
        Me.injGrid.Location = New System.Drawing.Point(251, 228)
        Me.injGrid.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.injGrid.Name = "injGrid"
        Me.injGrid.RowTemplate.Height = 24
        Me.injGrid.Size = New System.Drawing.Size(470, 188)
        Me.injGrid.TabIndex = 48
        '
        'N
        '
        Me.N.HeaderText = "N"
        Me.N.Name = "N"
        Me.N.Width = 30
        '
        'Cilindro
        '
        Me.Cilindro.HeaderText = "Cilindro"
        Me.Cilindro.Name = "Cilindro"
        Me.Cilindro.Width = 70
        '
        'Pistone
        '
        Me.Pistone.HeaderText = "Pistone"
        Me.Pistone.Name = "Pistone"
        Me.Pistone.Width = 70
        '
        'OffsetX
        '
        Me.OffsetX.HeaderText = "Offset X"
        Me.OffsetX.Name = "OffsetX"
        '
        'OffsetY
        '
        Me.OffsetY.HeaderText = "Offset Y"
        Me.OffsetY.Name = "OffsetY"
        '
        'coloreR
        '
        Me.coloreR.HeaderText = "R"
        Me.coloreR.Name = "coloreR"
        '
        'coloreG
        '
        Me.coloreG.HeaderText = "G"
        Me.coloreG.Name = "coloreG"
        '
        'coloreB
        '
        Me.coloreB.HeaderText = "B"
        Me.coloreB.Name = "coloreB"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(226, 129)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 49
        Me.Button11.Text = "Button11"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(730, 591)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.injGrid)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.vzmove)
        Me.Controls.Add(Me.vzinj)
        Me.Controls.Add(Me.vzMAX)
        Me.Controls.Add(Me.vzmin)
        Me.Controls.Add(Me.zMAX)
        Me.Controls.Add(Me.zmin)
        Me.Controls.Add(Me.vymove)
        Me.Controls.Add(Me.vyinj)
        Me.Controls.Add(Me.vyMAX)
        Me.Controls.Add(Me.vymin)
        Me.Controls.Add(Me.yMAX)
        Me.Controls.Add(Me.ymin)
        Me.Controls.Add(Me.vxmove)
        Me.Controls.Add(Me.vxinj)
        Me.Controls.Add(Me.vxMAX)
        Me.Controls.Add(Me.vxmin)
        Me.Controls.Add(Me.xMAX)
        Me.Controls.Add(Me.xmin)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.posY)
        Me.Controls.Add(Me.posX)
        Me.Controls.Add(Me.txtRotate)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.diff)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.yOffset)
        Me.Controls.Add(Me.xOffset)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.IcImagingControl1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.IcImagingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.injGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents IcImagingControl1 As TIS.Imaging.ICImagingControl
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents xOffset As TextBox
    Friend WithEvents yOffset As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents diff As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button8 As Button
    Friend WithEvents txtRotate As TextBox
    Friend WithEvents posX As TextBox
    Friend WithEvents posY As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents xmin As TextBox
    Friend WithEvents xMAX As TextBox
    Friend WithEvents vxmin As TextBox
    Friend WithEvents vxMAX As TextBox
    Friend WithEvents vxinj As TextBox
    Friend WithEvents vxmove As TextBox
    Friend WithEvents vymove As TextBox
    Friend WithEvents vyinj As TextBox
    Friend WithEvents vyMAX As TextBox
    Friend WithEvents vymin As TextBox
    Friend WithEvents yMAX As TextBox
    Friend WithEvents ymin As TextBox
    Friend WithEvents vzmove As TextBox
    Friend WithEvents vzinj As TextBox
    Friend WithEvents vzMAX As TextBox
    Friend WithEvents vzmin As TextBox
    Friend WithEvents zMAX As TextBox
    Friend WithEvents zmin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents injGrid As DataGridView
    Friend WithEvents N As DataGridViewTextBoxColumn
    Friend WithEvents Cilindro As DataGridViewTextBoxColumn
    Friend WithEvents Pistone As DataGridViewTextBoxColumn
    Friend WithEvents OffsetX As DataGridViewTextBoxColumn
    Friend WithEvents OffsetY As DataGridViewTextBoxColumn
    Friend WithEvents coloreR As DataGridViewTextBoxColumn
    Friend WithEvents coloreG As DataGridViewTextBoxColumn
    Friend WithEvents coloreB As DataGridViewTextBoxColumn
    Friend WithEvents Button11 As Button
    Friend WithEvents Timer1 As Timer
End Class
