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
        Me.totalVact.Location = New System.Drawing.Point(400, 278)
        Me.totalVact.Name = "totalVact"
        Me.totalVact.Size = New System.Drawing.Size(251, 180)
        Me.totalVact.TabIndex = 1
        Me.totalVact.Text = "SolidGauge2"
        '
        'totalPos
        '
        Me.totalPos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalPos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPos.Location = New System.Drawing.Point(739, 278)
        Me.totalPos.Name = "totalPos"
        Me.totalPos.Size = New System.Drawing.Size(251, 180)
        Me.totalPos.TabIndex = 2
        Me.totalPos.Text = "SolidGauge3"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
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
        Me.Panel1.Size = New System.Drawing.Size(1042, 495)
        Me.Panel1.TabIndex = 3
        '
        'totalHospitalized
        '
        Me.totalHospitalized.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalHospitalized.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalHospitalized.Location = New System.Drawing.Point(50, 12)
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
        Me.Label4.Location = New System.Drawing.Point(805, 205)
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
        Me.Label5.Location = New System.Drawing.Point(453, 205)
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
        Me.Label6.Location = New System.Drawing.Point(79, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Hospitaliseeritud kokku"
        '
        'totalDied
        '
        Me.totalDied.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalDied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalDied.Location = New System.Drawing.Point(739, 12)
        Me.totalDied.Name = "totalDied"
        Me.totalDied.Size = New System.Drawing.Size(251, 180)
        Me.totalDied.TabIndex = 8
        Me.totalDied.Text = "SolidGauge3"
        '
        'hospitalizedCurrent
        '
        Me.hospitalizedCurrent.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.hospitalizedCurrent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hospitalizedCurrent.Location = New System.Drawing.Point(400, 12)
        Me.hospitalizedCurrent.Name = "hospitalizedCurrent"
        Me.hospitalizedCurrent.Size = New System.Drawing.Size(251, 180)
        Me.hospitalizedCurrent.TabIndex = 7
        Me.hospitalizedCurrent.Text = "SolidGauge2"
        '
        'totalSick
        '
        Me.totalSick.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalSick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalSick.Location = New System.Drawing.Point(50, 278)
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
        Me.Label3.Location = New System.Drawing.Point(759, 471)
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
        Me.Label2.Location = New System.Drawing.Point(437, 471)
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
        Me.Label1.Location = New System.Drawing.Point(120, 471)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Kokku haige"
        '
        'statGraphs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 495)
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
End Class
