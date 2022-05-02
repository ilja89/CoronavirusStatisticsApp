<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class moreStatGeneral
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.toDate = New System.Windows.Forms.DateTimePicker()
        Me.fromDate = New System.Windows.Forms.DateTimePicker()
        Me.saveStatBtn = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(27, 62)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(965, 403)
        Me.Chart1.TabIndex = 14
        Me.Chart1.Text = "Chart1"
        '
        'toDate
        '
        Me.toDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.toDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.toDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.toDate.Location = New System.Drawing.Point(540, 23)
        Me.toDate.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.toDate.Name = "toDate"
        Me.toDate.Size = New System.Drawing.Size(200, 26)
        Me.toDate.TabIndex = 13
        '
        'fromDate
        '
        Me.fromDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fromDate.Location = New System.Drawing.Point(199, 23)
        Me.fromDate.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(200, 26)
        Me.fromDate.TabIndex = 12
        Me.fromDate.Value = New Date(2020, 1, 1, 0, 0, 0, 0)
        '
        'saveStatBtn
        '
        Me.saveStatBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveStatBtn.Location = New System.Drawing.Point(762, 3)
        Me.saveStatBtn.Name = "saveStatBtn"
        Me.saveStatBtn.Size = New System.Drawing.Size(147, 23)
        Me.saveStatBtn.TabIndex = 30
        Me.saveStatBtn.Text = "Salvesta statistikat"
        Me.saveStatBtn.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(762, 34)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(131, 22)
        Me.CheckBox1.TabIndex = 29
        Me.CheckBox1.Text = "Lisada lõppu"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'moreStatGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 481)
        Me.Controls.Add(Me.saveStatBtn)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.toDate)
        Me.Controls.Add(Me.fromDate)
        Me.MinimumSize = New System.Drawing.Size(1033, 520)
        Me.Name = "moreStatGeneral"
        Me.Text = "moreStatGeneral"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents toDate As DateTimePicker
    Friend WithEvents fromDate As DateTimePicker
    Friend WithEvents saveStatBtn As Button
    Friend WithEvents CheckBox1 As CheckBox
End Class
