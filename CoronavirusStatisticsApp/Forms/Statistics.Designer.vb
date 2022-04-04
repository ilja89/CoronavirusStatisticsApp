<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Statistics
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.InfectedByAge = New LiveCharts.WinForms.PieChart()
        Me.InfectedBySex = New LiveCharts.WinForms.PieChart()
        Me.Total_Vaccinated = New LiveCharts.WinForms.SolidGauge()
        Me.Total_infected = New LiveCharts.WinForms.SolidGauge()
        Me.VaccinatedBySex = New LiveCharts.WinForms.PieChart()
        Me.PieChart1 = New LiveCharts.WinForms.PieChart()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(123, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nakatunute arv seksi järgi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(556, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nakatunute koguarv"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1139, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 20)
        Me.Label3.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1068, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Nakatunute arv vanuse järgi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(543, 512)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Vaktsineeritute koguarv"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(123, 512)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Vaktsineeritud seksi järgi"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1068, 512)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(199, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Vaktsineeritud vanuse järgi"
        '
        'InfectedByAge
        '
        Me.InfectedByAge.Location = New System.Drawing.Point(1013, 22)
        Me.InfectedByAge.Name = "InfectedByAge"
        Me.InfectedByAge.Size = New System.Drawing.Size(315, 185)
        Me.InfectedByAge.TabIndex = 16
        Me.InfectedByAge.Text = "PieChart1"
        '
        'InfectedBySex
        '
        Me.InfectedBySex.Location = New System.Drawing.Point(29, 22)
        Me.InfectedBySex.Name = "InfectedBySex"
        Me.InfectedBySex.Size = New System.Drawing.Size(345, 195)
        Me.InfectedBySex.TabIndex = 17
        Me.InfectedBySex.Text = "PieChart1"
        '
        'Total_Vaccinated
        '
        Me.Total_Vaccinated.Location = New System.Drawing.Point(547, 310)
        Me.Total_Vaccinated.Name = "Total_Vaccinated"
        Me.Total_Vaccinated.Size = New System.Drawing.Size(238, 170)
        Me.Total_Vaccinated.TabIndex = 18
        Me.Total_Vaccinated.Text = "SolidGauge1"
        '
        'Total_infected
        '
        Me.Total_infected.Location = New System.Drawing.Point(547, 48)
        Me.Total_infected.Name = "Total_infected"
        Me.Total_infected.Size = New System.Drawing.Size(238, 169)
        Me.Total_infected.TabIndex = 19
        Me.Total_infected.Text = "SolidGauge2"
        '
        'VaccinatedBySex
        '
        Me.VaccinatedBySex.Location = New System.Drawing.Point(54, 295)
        Me.VaccinatedBySex.Name = "VaccinatedBySex"
        Me.VaccinatedBySex.Size = New System.Drawing.Size(320, 185)
        Me.VaccinatedBySex.TabIndex = 20
        Me.VaccinatedBySex.Text = "PieChart1"
        '
        'PieChart1
        '
        Me.PieChart1.Location = New System.Drawing.Point(991, 299)
        Me.PieChart1.Name = "PieChart1"
        Me.PieChart1.Size = New System.Drawing.Size(337, 181)
        Me.PieChart1.TabIndex = 21
        Me.PieChart1.Text = "VaccinatedBySex"
        '
        'Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PieChart1)
        Me.Controls.Add(Me.VaccinatedBySex)
        Me.Controls.Add(Me.Total_infected)
        Me.Controls.Add(Me.Total_Vaccinated)
        Me.Controls.Add(Me.InfectedBySex)
        Me.Controls.Add(Me.InfectedByAge)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Statistics"
        Me.Size = New System.Drawing.Size(1379, 658)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents InfectedByAge As LiveCharts.WinForms.PieChart
    Friend WithEvents InfectedBySex As LiveCharts.WinForms.PieChart
    Friend WithEvents Total_Vaccinated As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Total_infected As LiveCharts.WinForms.SolidGauge
    Friend WithEvents VaccinatedBySex As LiveCharts.WinForms.PieChart
    Friend WithEvents PieChart1 As LiveCharts.WinForms.PieChart
End Class
