<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class moreStatCounty
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SolidGauge1 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge2 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge3 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge4 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge5 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge6 = New LiveCharts.WinForms.SolidGauge()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.SolidGauge6)
        Me.Panel1.Controls.Add(Me.SolidGauge5)
        Me.Panel1.Controls.Add(Me.SolidGauge4)
        Me.Panel1.Controls.Add(Me.SolidGauge3)
        Me.Panel1.Controls.Add(Me.SolidGauge2)
        Me.Panel1.Controls.Add(Me.SolidGauge1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 450)
        Me.Panel1.TabIndex = 0
        '
        'SolidGauge1
        '
        Me.SolidGauge1.Location = New System.Drawing.Point(66, 71)
        Me.SolidGauge1.Name = "SolidGauge1"
        Me.SolidGauge1.Size = New System.Drawing.Size(219, 100)
        Me.SolidGauge1.TabIndex = 0
        Me.SolidGauge1.Text = "SolidGauge1"
        '
        'SolidGauge2
        '
        Me.SolidGauge2.Location = New System.Drawing.Point(66, 225)
        Me.SolidGauge2.Name = "SolidGauge2"
        Me.SolidGauge2.Size = New System.Drawing.Size(219, 100)
        Me.SolidGauge2.TabIndex = 1
        Me.SolidGauge2.Text = "SolidGauge2"
        '
        'SolidGauge3
        '
        Me.SolidGauge3.Location = New System.Drawing.Point(291, 71)
        Me.SolidGauge3.Name = "SolidGauge3"
        Me.SolidGauge3.Size = New System.Drawing.Size(219, 100)
        Me.SolidGauge3.TabIndex = 2
        Me.SolidGauge3.Text = "SolidGauge3"
        '
        'SolidGauge4
        '
        Me.SolidGauge4.Location = New System.Drawing.Point(534, 71)
        Me.SolidGauge4.Name = "SolidGauge4"
        Me.SolidGauge4.Size = New System.Drawing.Size(219, 100)
        Me.SolidGauge4.TabIndex = 3
        Me.SolidGauge4.Text = "SolidGauge4"
        '
        'SolidGauge5
        '
        Me.SolidGauge5.Location = New System.Drawing.Point(291, 225)
        Me.SolidGauge5.Name = "SolidGauge5"
        Me.SolidGauge5.Size = New System.Drawing.Size(219, 100)
        Me.SolidGauge5.TabIndex = 4
        Me.SolidGauge5.Text = "SolidGauge5"
        '
        'SolidGauge6
        '
        Me.SolidGauge6.Location = New System.Drawing.Point(534, 225)
        Me.SolidGauge6.Name = "SolidGauge6"
        Me.SolidGauge6.Size = New System.Drawing.Size(219, 100)
        Me.SolidGauge6.TabIndex = 5
        Me.SolidGauge6.Text = "SolidGauge6"
        '
        'moreStatCounty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "moreStatCounty"
        Me.Text = "Maakonna statistika"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents SolidGauge1 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge6 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge5 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge4 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge3 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge2 As LiveCharts.WinForms.SolidGauge
End Class
