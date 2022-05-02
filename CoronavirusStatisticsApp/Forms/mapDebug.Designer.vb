<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mapDebug
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mpb = New System.Windows.Forms.PictureBox()
        Me.coords = New System.Windows.Forms.Label()
        Me.richTb = New System.Windows.Forms.RichTextBox()
        Me.outPointsButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.removeLastButton = New System.Windows.Forms.Button()
        CType(Me.mpb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mpb
        '
        Me.mpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.mpb.Image = Global.CoronavirusStatisticsApp.My.Resources.Resources.mapDebug
        Me.mpb.Location = New System.Drawing.Point(12, 12)
        Me.mpb.Name = "mpb"
        Me.mpb.Size = New System.Drawing.Size(1271, 641)
        Me.mpb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mpb.TabIndex = 0
        Me.mpb.TabStop = False
        '
        'coords
        '
        Me.coords.AutoSize = True
        Me.coords.Location = New System.Drawing.Point(12, 656)
        Me.coords.Name = "coords"
        Me.coords.Size = New System.Drawing.Size(39, 13)
        Me.coords.TabIndex = 1
        Me.coords.Text = "Label1"
        '
        'richTb
        '
        Me.richTb.Location = New System.Drawing.Point(15, 722)
        Me.richTb.Name = "richTb"
        Me.richTb.Size = New System.Drawing.Size(396, 307)
        Me.richTb.TabIndex = 2
        Me.richTb.Text = ""
        '
        'outPointsButton
        '
        Me.outPointsButton.Location = New System.Drawing.Point(15, 693)
        Me.outPointsButton.Name = "outPointsButton"
        Me.outPointsButton.Size = New System.Drawing.Size(75, 23)
        Me.outPointsButton.TabIndex = 3
        Me.outPointsButton.Text = "Output"
        Me.outPointsButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CoronavirusStatisticsApp.My.Resources.Resources.mapDebug
        Me.PictureBox1.Location = New System.Drawing.Point(1447, 1005)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 24)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'removeLastButton
        '
        Me.removeLastButton.Location = New System.Drawing.Point(96, 693)
        Me.removeLastButton.Name = "removeLastButton"
        Me.removeLastButton.Size = New System.Drawing.Size(123, 23)
        Me.removeLastButton.TabIndex = 5
        Me.removeLastButton.Text = "Remove Last"
        Me.removeLastButton.UseVisualStyleBackColor = True
        '
        'mapDebug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.removeLastButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.outPointsButton)
        Me.Controls.Add(Me.richTb)
        Me.Controls.Add(Me.coords)
        Me.Controls.Add(Me.mpb)
        Me.Name = "mapDebug"
        Me.Text = "mapDebug"
        CType(Me.mpb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mpb As PictureBox
    Friend WithEvents coords As Label
    Friend WithEvents richTb As RichTextBox
    Friend WithEvents outPointsButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents removeLastButton As Button
End Class
