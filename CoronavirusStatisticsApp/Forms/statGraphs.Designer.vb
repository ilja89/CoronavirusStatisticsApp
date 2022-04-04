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
        Me.totalSick = New LiveCharts.WinForms.SolidGauge()
        Me.totalVact = New LiveCharts.WinForms.SolidGauge()
        Me.totalPos = New LiveCharts.WinForms.SolidGauge()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'totalSick
        '
        Me.totalSick.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalSick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalSick.Location = New System.Drawing.Point(66, 145)
        Me.totalSick.Name = "totalSick"
        Me.totalSick.Size = New System.Drawing.Size(235, 180)
        Me.totalSick.TabIndex = 0
        Me.totalSick.Text = "SolidGauge1"
        '
        'totalVact
        '
        Me.totalVact.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalVact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalVact.Location = New System.Drawing.Point(413, 145)
        Me.totalVact.Name = "totalVact"
        Me.totalVact.Size = New System.Drawing.Size(235, 180)
        Me.totalVact.TabIndex = 1
        Me.totalVact.Text = "SolidGauge2"
        '
        'totalPos
        '
        Me.totalPos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.totalPos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPos.Location = New System.Drawing.Point(752, 145)
        Me.totalPos.Name = "totalPos"
        Me.totalPos.Size = New System.Drawing.Size(235, 180)
        Me.totalPos.TabIndex = 2
        Me.totalPos.Text = "SolidGauge3"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.totalSick)
        Me.Panel1.Controls.Add(Me.totalPos)
        Me.Panel1.Controls.Add(Me.totalVact)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1042, 495)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(122, 338)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Kokku haige"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(441, 338)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Kokku vaktsineeritud"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(772, 338)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(205, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kokku positiivsed testid"
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

    Friend WithEvents totalSick As LiveCharts.WinForms.SolidGauge
    Friend WithEvents totalVact As LiveCharts.WinForms.SolidGauge
    Friend WithEvents totalPos As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
