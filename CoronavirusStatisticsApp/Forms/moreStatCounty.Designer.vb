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
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.fromDate = New System.Windows.Forms.DateTimePicker()
        Me.toDate = New System.Windows.Forms.DateTimePicker()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.maakondLabel = New System.Windows.Forms.Label()
        Me.clearBtn = New System.Windows.Forms.Button()
        Me.statypeSelector = New System.Windows.Forms.ComboBox()
        Me.dropDownBtn = New System.Windows.Forms.Button()
        Me.countySelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fromDate
        '
        Me.fromDate.Location = New System.Drawing.Point(184, 28)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(200, 20)
        Me.fromDate.TabIndex = 9
        Me.fromDate.Value = New Date(2020, 1, 1, 0, 0, 0, 0)
        '
        'toDate
        '
        Me.toDate.Location = New System.Drawing.Point(525, 28)
        Me.toDate.Name = "toDate"
        Me.toDate.Size = New System.Drawing.Size(200, 20)
        Me.toDate.TabIndex = 10
        '
        'Chart1
        '
        ChartArea4.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend4)
        Me.Chart1.Location = New System.Drawing.Point(12, 67)
        Me.Chart1.Name = "Chart1"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Size = New System.Drawing.Size(965, 403)
        Me.Chart1.TabIndex = 11
        Me.Chart1.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.countySelector)
        Me.Panel1.Controls.Add(Me.dropDownBtn)
        Me.Panel1.Controls.Add(Me.statypeSelector)
        Me.Panel1.Controls.Add(Me.clearBtn)
        Me.Panel1.Controls.Add(Me.maakondLabel)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Controls.Add(Me.toDate)
        Me.Panel1.Controls.Add(Me.fromDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 482)
        Me.Panel1.TabIndex = 0
        '
        'maakondLabel
        '
        Me.maakondLabel.AutoSize = True
        Me.maakondLabel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maakondLabel.Location = New System.Drawing.Point(12, 28)
        Me.maakondLabel.Name = "maakondLabel"
        Me.maakondLabel.Size = New System.Drawing.Size(62, 18)
        Me.maakondLabel.TabIndex = 12
        Me.maakondLabel.Text = "Label1"
        '
        'clearBtn
        '
        Me.clearBtn.BackColor = System.Drawing.Color.Firebrick
        Me.clearBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearBtn.Location = New System.Drawing.Point(828, 418)
        Me.clearBtn.Name = "clearBtn"
        Me.clearBtn.Size = New System.Drawing.Size(75, 23)
        Me.clearBtn.TabIndex = 13
        Me.clearBtn.Text = "Eemalda"
        Me.clearBtn.UseVisualStyleBackColor = False
        '
        'statypeSelector
        '
        Me.statypeSelector.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statypeSelector.FormattingEnabled = True
        Me.statypeSelector.Items.AddRange(New Object() {"Testid kokku", "Nakatanud kokku", "Vaktsineeritud kokku"})
        Me.statypeSelector.Location = New System.Drawing.Point(828, 322)
        Me.statypeSelector.Name = "statypeSelector"
        Me.statypeSelector.Size = New System.Drawing.Size(121, 22)
        Me.statypeSelector.TabIndex = 14
        '
        'dropDownBtn
        '
        Me.dropDownBtn.BackColor = System.Drawing.Color.ForestGreen
        Me.dropDownBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dropDownBtn.Location = New System.Drawing.Point(828, 267)
        Me.dropDownBtn.Name = "dropDownBtn"
        Me.dropDownBtn.Size = New System.Drawing.Size(75, 23)
        Me.dropDownBtn.TabIndex = 15
        Me.dropDownBtn.Text = "Lisa"
        Me.dropDownBtn.UseVisualStyleBackColor = False
        '
        'countySelector
        '
        Me.countySelector.AutoCompleteCustomSource.AddRange(New String() {"Harju maakond", "Ida-Viru maakond", "Lääne-Viru maakond", "Järva maakond", "Jõgeva maakond", "Võru maakond", "Põlva maakond", "Valga maakond", "Tartu maakond", "Pärnu maakond", "Rapla maakond", "Lääne maakond", "Saare maakond", "Hiiu maakond", "Viljandi maakond"})
        Me.countySelector.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countySelector.FormattingEnabled = True
        Me.countySelector.Items.AddRange(New Object() {"Harju maakond", "Ida-Viru maakond", "Lääne-Viru maakond", "Järva maakond", "Jõgeva maakond", "Võru maakond", "Põlva maakond", "Valga maakond", "Tartu maakond", "Pärnu maakond", "Rapla maakond", "Lääne maakond", "Saare maakond", "Hiiu maakond", "Viljandi maakond"""})
        Me.countySelector.Location = New System.Drawing.Point(828, 378)
        Me.countySelector.Name = "countySelector"
        Me.countySelector.Size = New System.Drawing.Size(121, 22)
        Me.countySelector.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkGray
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(828, 303)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Statistika tüüpi valik"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DarkGray
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(828, 361)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Maakonna valik"
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
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fromDate As DateTimePicker
    Friend WithEvents toDate As DateTimePicker
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents maakondLabel As Label
    Friend WithEvents dropDownBtn As Button
    Friend WithEvents statypeSelector As ComboBox
    Friend WithEvents clearBtn As Button
    Friend WithEvents countySelector As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
