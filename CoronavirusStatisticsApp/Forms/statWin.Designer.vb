<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class statWin
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
        Me.totalPositive = New LiveCharts.WinForms.SolidGauge()
        Me.totalVact = New LiveCharts.WinForms.SolidGauge()
        Me.totalSick = New LiveCharts.WinForms.SolidGauge()
        Me.SuspendLayout()
        '
        'totalPositive
        '
        Me.totalPositive.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPositive.Location = New System.Drawing.Point(59, 151)
        Me.totalPositive.Name = "totalPositive"
        Me.totalPositive.Size = New System.Drawing.Size(294, 188)
        Me.totalPositive.TabIndex = 0
        Me.totalPositive.Text = "SolidGauge1"
        '
        'totalVact
        '
        Me.totalVact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalVact.Location = New System.Drawing.Point(388, 151)
        Me.totalVact.Name = "totalVact"
        Me.totalVact.Size = New System.Drawing.Size(294, 188)
        Me.totalVact.TabIndex = 1
        Me.totalVact.Text = "SolidGauge1"
        '
        'totalSick
        '
        Me.totalSick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalSick.Location = New System.Drawing.Point(719, 151)
        Me.totalSick.Name = "totalSick"
        Me.totalSick.Size = New System.Drawing.Size(294, 188)
        Me.totalSick.TabIndex = 2
        Me.totalSick.Text = "SolidGauge1"
        '
        'statWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.totalSick)
        Me.Controls.Add(Me.totalVact)
        Me.Controls.Add(Me.totalPositive)
        Me.Name = "statWin"
        Me.Size = New System.Drawing.Size(1058, 534)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents totalPositive As LiveCharts.WinForms.SolidGauge
    Friend WithEvents totalVact As LiveCharts.WinForms.SolidGauge
    Friend WithEvents totalSick As LiveCharts.WinForms.SolidGauge
End Class
