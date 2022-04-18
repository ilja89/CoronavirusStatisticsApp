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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.fromDate = New System.Windows.Forms.DateTimePicker()
        Me.toDate = New System.Windows.Forms.DateTimePicker()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fromDate
        '
        Me.fromDate.Location = New System.Drawing.Point(134, 28)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(200, 20)
        Me.fromDate.TabIndex = 9
        '
        'toDate
        '
        Me.toDate.Location = New System.Drawing.Point(486, 28)
        Me.toDate.Name = "toDate"
        Me.toDate.Size = New System.Drawing.Size(200, 20)
        Me.toDate.TabIndex = 10
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(12, 67)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(965, 403)
        Me.Chart1.TabIndex = 11
        Me.Chart1.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Controls.Add(Me.toDate)
        Me.Panel1.Controls.Add(Me.fromDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 482)
        Me.Panel1.TabIndex = 0
        '
        'moreStatCounty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 482)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "moreStatCounty"
        Me.Text = "Maakonna statistika"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fromDate As DateTimePicker
    Friend WithEvents toDate As DateTimePicker
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
End Class
