<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class statGraphs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.totalVact = New LiveCharts.WinForms.SolidGauge()
        Me.totalPos = New LiveCharts.WinForms.SolidGauge()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.sickBtn = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.hospitalBtn = New System.Windows.Forms.Button()
        Me.testBtn = New System.Windows.Forms.Button()
        Me.vactBtn = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.totalPer100K = New LiveCharts.WinForms.SolidGauge()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.weekHospitalized = New LiveCharts.WinForms.SolidGauge()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.todayHospitalized = New LiveCharts.WinForms.SolidGauge()
        Me.totalHospitalized = New LiveCharts.WinForms.SolidGauge()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.totalDied = New LiveCharts.WinForms.SolidGauge()
        Me.hospitalizedCurrent = New LiveCharts.WinForms.SolidGauge()
        Me.totalSick = New LiveCharts.WinForms.SolidGauge()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'totalVact
        '
        Me.totalVact.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalVact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalVact.Location = New System.Drawing.Point(361, 446)
        Me.totalVact.Name = "totalVact"
        Me.totalVact.Size = New System.Drawing.Size(251, 180)
        Me.totalVact.TabIndex = 1
        Me.totalVact.Text = "SolidGauge2"
        '
        'totalPos
        '
        Me.totalPos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalPos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPos.Location = New System.Drawing.Point(700, 446)
        Me.totalPos.Name = "totalPos"
        Me.totalPos.Size = New System.Drawing.Size(251, 180)
        Me.totalPos.TabIndex = 2
        Me.totalPos.Text = "SolidGauge3"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.sickBtn)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.hospitalBtn)
        Me.Panel1.Controls.Add(Me.testBtn)
        Me.Panel1.Controls.Add(Me.vactBtn)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.totalPer100K)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.weekHospitalized)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.todayHospitalized)
        Me.Panel1.Controls.Add(Me.totalHospitalized)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.totalDied)
        Me.Panel1.Controls.Add(Me.hospitalizedCurrent)
        Me.Panel1.Controls.Add(Me.totalSick)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.totalPos)
        Me.Panel1.Controls.Add(Me.totalVact)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1223, 663)
        Me.Panel1.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1010, 417)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(182, 18)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Haigestumise graafik"
        '
        'sickBtn
        '
        Me.sickBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.sickBtn.BackColor = System.Drawing.Color.Green
        Me.sickBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sickBtn.Location = New System.Drawing.Point(1045, 464)
        Me.sickBtn.Name = "sickBtn"
        Me.sickBtn.Size = New System.Drawing.Size(100, 34)
        Me.sickBtn.TabIndex = 25
        Me.sickBtn.Text = "Kuva rohkem"
        Me.sickBtn.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(990, 565)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(222, 18)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Hospitaliseerimise graafik"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1025, 249)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 18)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Testide graafik"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(992, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(200, 18)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Vaktsineerimise graafik"
        '
        'hospitalBtn
        '
        Me.hospitalBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hospitalBtn.BackColor = System.Drawing.Color.Green
        Me.hospitalBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hospitalBtn.Location = New System.Drawing.Point(1045, 602)
        Me.hospitalBtn.Name = "hospitalBtn"
        Me.hospitalBtn.Size = New System.Drawing.Size(100, 34)
        Me.hospitalBtn.TabIndex = 21
        Me.hospitalBtn.Text = "Kuva rohkem"
        Me.hospitalBtn.UseVisualStyleBackColor = False
        '
        'testBtn
        '
        Me.testBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.testBtn.BackColor = System.Drawing.Color.Green
        Me.testBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testBtn.Location = New System.Drawing.Point(1045, 293)
        Me.testBtn.Name = "testBtn"
        Me.testBtn.Size = New System.Drawing.Size(100, 34)
        Me.testBtn.TabIndex = 20
        Me.testBtn.Text = "Kuva rohkem"
        Me.testBtn.UseVisualStyleBackColor = False
        '
        'vactBtn
        '
        Me.vactBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.vactBtn.BackColor = System.Drawing.Color.Green
        Me.vactBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vactBtn.Location = New System.Drawing.Point(1045, 141)
        Me.vactBtn.Name = "vactBtn"
        Me.vactBtn.Size = New System.Drawing.Size(100, 34)
        Me.vactBtn.TabIndex = 19
        Me.vactBtn.Text = "Kuva rohkem"
        Me.vactBtn.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(707, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(244, 18)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Haiged inimesed 100K kohta"
        '
        'totalPer100K
        '
        Me.totalPer100K.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalPer100K.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPer100K.Location = New System.Drawing.Point(700, 27)
        Me.totalPer100K.Name = "totalPer100K"
        Me.totalPer100K.Size = New System.Drawing.Size(251, 180)
        Me.totalPer100K.TabIndex = 17
        Me.totalPer100K.Text = "SolidGauge2"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(349, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(274, 18)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Nädala jooksul hospitaliseeritud"
        '
        'weekHospitalized
        '
        Me.weekHospitalized.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.weekHospitalized.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weekHospitalized.Location = New System.Drawing.Point(361, 27)
        Me.weekHospitalized.Name = "weekHospitalized"
        Me.weekHospitalized.Size = New System.Drawing.Size(251, 180)
        Me.weekHospitalized.TabIndex = 15
        Me.weekHospitalized.Text = "SolidGauge2"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(260, 18)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Kesk. hospitaliseeritud päevas"
        '
        'todayHospitalized
        '
        Me.todayHospitalized.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.todayHospitalized.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.todayHospitalized.Location = New System.Drawing.Point(12, 27)
        Me.todayHospitalized.Name = "todayHospitalized"
        Me.todayHospitalized.Size = New System.Drawing.Size(251, 180)
        Me.todayHospitalized.TabIndex = 13
        Me.todayHospitalized.Text = "SolidGauge2"
        '
        'totalHospitalized
        '
        Me.totalHospitalized.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalHospitalized.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalHospitalized.Location = New System.Drawing.Point(11, 237)
        Me.totalHospitalized.Name = "totalHospitalized"
        Me.totalHospitalized.Size = New System.Drawing.Size(251, 180)
        Me.totalHospitalized.TabIndex = 12
        Me.totalHospitalized.Text = "SolidGauge2"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(766, 430)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Kokku surnud "
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(414, 430)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Hetkel Haiglaravil"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 430)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Hospitaliseeritud kokku"
        '
        'totalDied
        '
        Me.totalDied.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalDied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalDied.Location = New System.Drawing.Point(700, 237)
        Me.totalDied.Name = "totalDied"
        Me.totalDied.Size = New System.Drawing.Size(251, 180)
        Me.totalDied.TabIndex = 8
        Me.totalDied.Text = "SolidGauge3"
        '
        'hospitalizedCurrent
        '
        Me.hospitalizedCurrent.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hospitalizedCurrent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hospitalizedCurrent.Location = New System.Drawing.Point(361, 237)
        Me.hospitalizedCurrent.Name = "hospitalizedCurrent"
        Me.hospitalizedCurrent.Size = New System.Drawing.Size(251, 180)
        Me.hospitalizedCurrent.TabIndex = 7
        Me.hospitalizedCurrent.Text = "SolidGauge2"
        '
        'totalSick
        '
        Me.totalSick.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalSick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalSick.Location = New System.Drawing.Point(11, 446)
        Me.totalSick.Name = "totalSick"
        Me.totalSick.Size = New System.Drawing.Size(251, 180)
        Me.totalSick.TabIndex = 6
        Me.totalSick.Text = "SolidGauge2"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(720, 639)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(205, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kokku positiivsed testid"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(398, 639)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Kokku vaktsineeritud"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 639)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Kokku haige"
        '
        'statGraphs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 663)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "statGraphs"
        Me.Text = "StatGraphs"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents totalVact As LiveCharts.WinForms.SolidGauge
    Friend WithEvents totalPos As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents totalSick As LiveCharts.WinForms.SolidGauge
    Friend WithEvents totalHospitalized As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents totalDied As LiveCharts.WinForms.SolidGauge
    Friend WithEvents hospitalizedCurrent As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Label8 As Label
    Friend WithEvents weekHospitalized As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Label7 As Label
    Friend WithEvents todayHospitalized As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Label9 As Label
    Friend WithEvents totalPer100K As LiveCharts.WinForms.SolidGauge
    Friend WithEvents hospitalBtn As Button
    Friend WithEvents testBtn As Button
    Friend WithEvents vactBtn As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents sickBtn As Button
End Class
