<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loadingControl
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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
        Me.picturePictureBox = New System.Windows.Forms.PictureBox()
        Me.progress = New System.Windows.Forms.ProgressBar()
        CType(Me.picturePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturePictureBox
        '
        Me.picturePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.picturePictureBox.Location = New System.Drawing.Point(116, 118)
        Me.picturePictureBox.Name = "picturePictureBox"
        Me.picturePictureBox.Size = New System.Drawing.Size(295, 256)
        Me.picturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picturePictureBox.TabIndex = 0
        Me.picturePictureBox.TabStop = False
        '
        'progress
        '
        Me.progress.Location = New System.Drawing.Point(201, 403)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(100, 23)
        Me.progress.TabIndex = 1
        '
        'loadingControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.progress)
        Me.Controls.Add(Me.picturePictureBox)
        Me.Name = "loadingControl"
        Me.Size = New System.Drawing.Size(594, 547)
        CType(Me.picturePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picturePictureBox As PictureBox
    Friend WithEvents progress As ProgressBar
End Class
