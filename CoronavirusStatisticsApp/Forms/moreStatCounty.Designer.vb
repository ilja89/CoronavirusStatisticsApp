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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.fromDate = New System.Windows.Forms.DateTimePicker()
        Me.toDate = New System.Windows.Forms.DateTimePicker()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.absoluteValueCheckBox = New System.Windows.Forms.CheckBox()
        Me.removeCountyButton = New System.Windows.Forms.Button()
        Me.removeCountyLabel = New System.Windows.Forms.Label()
        Me.selectedCountyListBox = New System.Windows.Forms.ListBox()
        Me.addCountyCombobox = New System.Windows.Forms.ComboBox()
        Me.addCountyLabel = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fromDate
        '
        Me.fromDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fromDate.Location = New System.Drawing.Point(184, 28)
        Me.fromDate.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(200, 26)
        Me.fromDate.TabIndex = 9
        Me.fromDate.Value = New Date(2020, 1, 1, 0, 0, 0, 0)
        '
        'toDate
        '
        Me.toDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.toDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.toDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.toDate.Location = New System.Drawing.Point(525, 28)
        Me.toDate.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.toDate.Name = "toDate"
        Me.toDate.Size = New System.Drawing.Size(200, 26)
        Me.toDate.TabIndex = 10
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(12, 67)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(965, 403)
        Me.Chart1.TabIndex = 11
        Me.Chart1.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.absoluteValueCheckBox)
        Me.Panel1.Controls.Add(Me.removeCountyButton)
        Me.Panel1.Controls.Add(Me.removeCountyLabel)
        Me.Panel1.Controls.Add(Me.selectedCountyListBox)
        Me.Panel1.Controls.Add(Me.addCountyCombobox)
        Me.Panel1.Controls.Add(Me.addCountyLabel)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Controls.Add(Me.toDate)
        Me.Panel1.Controls.Add(Me.fromDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1224, 477)
        Me.Panel1.TabIndex = 0
        '
        'absoluteValueCheckBox
        '
        Me.absoluteValueCheckBox.AutoSize = True
        Me.absoluteValueCheckBox.BackColor = System.Drawing.Color.DarkGray
        Me.absoluteValueCheckBox.Checked = True
        Me.absoluteValueCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.absoluteValueCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.absoluteValueCheckBox.Location = New System.Drawing.Point(983, 67)
        Me.absoluteValueCheckBox.Name = "absoluteValueCheckBox"
        Me.absoluteValueCheckBox.Size = New System.Drawing.Size(143, 24)
        Me.absoluteValueCheckBox.TabIndex = 22
        Me.absoluteValueCheckBox.Text = "Absoluutväärtus"
        Me.absoluteValueCheckBox.UseVisualStyleBackColor = False
        '
        'removeCountyButton
        '
        Me.removeCountyButton.Location = New System.Drawing.Point(983, 352)
        Me.removeCountyButton.Name = "removeCountyButton"
        Me.removeCountyButton.Size = New System.Drawing.Size(207, 25)
        Me.removeCountyButton.TabIndex = 21
        Me.removeCountyButton.Text = "Eemalda"
        Me.removeCountyButton.UseVisualStyleBackColor = True
        '
        'removeCountyLabel
        '
        Me.removeCountyLabel.AutoSize = True
        Me.removeCountyLabel.BackColor = System.Drawing.Color.DarkGray
        Me.removeCountyLabel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.removeCountyLabel.Location = New System.Drawing.Point(983, 161)
        Me.removeCountyLabel.Name = "removeCountyLabel"
        Me.removeCountyLabel.Size = New System.Drawing.Size(158, 18)
        Me.removeCountyLabel.TabIndex = 20
        Me.removeCountyLabel.Text = "Eemalda maakond"
        '
        'selectedCountyListBox
        '
        Me.selectedCountyListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.selectedCountyListBox.FormattingEnabled = True
        Me.selectedCountyListBox.ItemHeight = 20
        Me.selectedCountyListBox.Location = New System.Drawing.Point(983, 182)
        Me.selectedCountyListBox.Name = "selectedCountyListBox"
        Me.selectedCountyListBox.ScrollAlwaysVisible = True
        Me.selectedCountyListBox.Size = New System.Drawing.Size(207, 164)
        Me.selectedCountyListBox.TabIndex = 19
        '
        'addCountyCombobox
        '
        Me.addCountyCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.addCountyCombobox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.addCountyCombobox.FormattingEnabled = True
        Me.addCountyCombobox.Items.AddRange(New Object() {"Hiiu maakond", "Saare maakond", "Lääne maakond", "Harju maakond", "Rapla maakond", "Pärnu maakond", "Viljandi maakond", "Tartu maakond", "Valga maakond", "Põlva maakond", "Võru maakond", "Jõgeva maakond", "Järva maakond", "Lääne-Viru maakond", "Ida-Viru maakond"})
        Me.addCountyCombobox.Location = New System.Drawing.Point(983, 130)
        Me.addCountyCombobox.Name = "addCountyCombobox"
        Me.addCountyCombobox.Size = New System.Drawing.Size(207, 28)
        Me.addCountyCombobox.TabIndex = 18
        '
        'addCountyLabel
        '
        Me.addCountyLabel.AutoSize = True
        Me.addCountyLabel.BackColor = System.Drawing.Color.DarkGray
        Me.addCountyLabel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.addCountyLabel.Location = New System.Drawing.Point(983, 109)
        Me.addCountyLabel.Name = "addCountyLabel"
        Me.addCountyLabel.Size = New System.Drawing.Size(121, 18)
        Me.addCountyLabel.TabIndex = 17
        Me.addCountyLabel.Text = "Lisa maakond"
        '
        'moreStatCounty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 477)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(1240, 516)
        Me.Name = "moreStatCounty"
        Me.Text = "Maakonna statistika"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fromDate As DateTimePicker
    Friend WithEvents toDate As DateTimePicker
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents addCountyLabel As Label
    Friend WithEvents addCountyCombobox As ComboBox
    Friend WithEvents removeCountyButton As Button
    Friend WithEvents removeCountyLabel As Label
    Friend WithEvents selectedCountyListBox As ListBox
    Friend WithEvents absoluteValueCheckBox As CheckBox
End Class
