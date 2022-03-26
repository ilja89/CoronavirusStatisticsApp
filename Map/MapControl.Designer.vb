<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MapControl
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mapPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.mapPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mapPictureBox
        '
        Me.mapPictureBox.Image = Global.Map.My.Resources.Resources.EsoniaPointsMapRaw
        Me.mapPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.mapPictureBox.Name = "mapPictureBox"
        Me.mapPictureBox.Size = New System.Drawing.Size(1920, 1200)
        Me.mapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mapPictureBox.TabIndex = 0
        Me.mapPictureBox.TabStop = False
        '
        'MapControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.mapPictureBox)
        Me.Name = "MapControl"
        Me.Size = New System.Drawing.Size(1920, 1200)
        CType(Me.mapPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents mapPictureBox As PictureBox
End Class
