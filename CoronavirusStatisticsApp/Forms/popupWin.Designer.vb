<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class popupWin
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.countyName = New System.Windows.Forms.Label()
        Me.closeBtn = New FontAwesome.Sharp.IconButton()
        Me.allTest = New System.Windows.Forms.Label()
        Me.allSick = New System.Windows.Forms.Label()
        Me.allVact = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.openStatBtn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.countyName)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(605, 31)
        Me.Panel1.TabIndex = 0
        '
        'countyName
        '
        Me.countyName.AutoSize = True
        Me.countyName.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.countyName.Location = New System.Drawing.Point(12, 7)
        Me.countyName.Name = "countyName"
        Me.countyName.Size = New System.Drawing.Size(56, 18)
        Me.countyName.TabIndex = 7
        Me.countyName.Text = "Label4"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.DimGray
        Me.closeBtn.ForeColor = System.Drawing.Color.Transparent
        Me.closeBtn.IconChar = FontAwesome.Sharp.IconChar.DoorOpen
        Me.closeBtn.IconColor = System.Drawing.Color.Black
        Me.closeBtn.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.closeBtn.Location = New System.Drawing.Point(576, 3)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(26, 22)
        Me.closeBtn.TabIndex = 0
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'allTest
        '
        Me.allTest.AutoSize = True
        Me.allTest.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allTest.Location = New System.Drawing.Point(215, 22)
        Me.allTest.Name = "allTest"
        Me.allTest.Size = New System.Drawing.Size(62, 18)
        Me.allTest.TabIndex = 1
        Me.allTest.Text = "allTest"
        '
        'allSick
        '
        Me.allSick.AutoSize = True
        Me.allSick.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allSick.Location = New System.Drawing.Point(215, 51)
        Me.allSick.Name = "allSick"
        Me.allSick.Size = New System.Drawing.Size(60, 18)
        Me.allSick.TabIndex = 2
        Me.allSick.Text = "allSick"
        '
        'allVact
        '
        Me.allVact.AutoSize = True
        Me.allVact.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allVact.Location = New System.Drawing.Point(215, 81)
        Me.allVact.Name = "allVact"
        Me.allVact.Size = New System.Drawing.Size(63, 18)
        Me.allVact.TabIndex = 3
        Me.allVact.Text = "allVact"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.openStatBtn)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.allTest)
        Me.Panel2.Controls.Add(Me.allVact)
        Me.Panel2.Controls.Add(Me.allSick)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(605, 272)
        Me.Panel2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Vaktsineeritud kokku"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nakatanud kokku"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Testid kokku:"
        '
        'openStatBtn
        '
        Me.openStatBtn.BackColor = System.Drawing.Color.OliveDrab
        Me.openStatBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.openStatBtn.Location = New System.Drawing.Point(444, 16)
        Me.openStatBtn.Name = "openStatBtn"
        Me.openStatBtn.Size = New System.Drawing.Size(125, 23)
        Me.openStatBtn.TabIndex = 7
        Me.openStatBtn.Text = "Kuva rohkem"
        Me.openStatBtn.UseVisualStyleBackColor = False
        '
        'popupWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(10, 10)
        Me.Name = "popupWin"
        Me.Size = New System.Drawing.Size(605, 303)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents allTest As Label
    Friend WithEvents allSick As Label
    Friend WithEvents allVact As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents closeBtn As FontAwesome.Sharp.IconButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents countyName As Label
    Friend WithEvents openStatBtn As Button
End Class
