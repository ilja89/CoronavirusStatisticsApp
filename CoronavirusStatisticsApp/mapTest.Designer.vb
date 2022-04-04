<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mapTest
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mapTest))
        Dim Gradient1 As Map.Gradient = New Map.Gradient()
        Me.colorComboBox = New System.Windows.Forms.ComboBox()
        Me.simpleCheckBox = New System.Windows.Forms.CheckBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.borderWidthTextBox = New System.Windows.Forms.TextBox()
        Me.applyAllButton = New System.Windows.Forms.Button()
        Me.borderColorButton = New System.Windows.Forms.Button()
        Me.borderWidthButton = New System.Windows.Forms.Button()
        Me.fontButton = New System.Windows.Forms.Button()
        Me.drawEmptyButton = New System.Windows.Forms.Button()
        Me.gradientButton = New System.Windows.Forms.Button()
        Me.MapControl1 = New Map.MapControl()
        Me.SuspendLayout()
        '
        'colorComboBox
        '
        Me.colorComboBox.FormattingEnabled = True
        Me.colorComboBox.Items.AddRange(New Object() {" ", "White", "Black", "Gray", "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "BrightGreen", "BrightBlue"})
        Me.colorComboBox.Location = New System.Drawing.Point(18, 1140)
        Me.colorComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.colorComboBox.Name = "colorComboBox"
        Me.colorComboBox.Size = New System.Drawing.Size(180, 28)
        Me.colorComboBox.TabIndex = 1
        Me.colorComboBox.Text = " "
        '
        'simpleCheckBox
        '
        Me.simpleCheckBox.AutoSize = True
        Me.simpleCheckBox.Checked = True
        Me.simpleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.simpleCheckBox.Location = New System.Drawing.Point(18, 1182)
        Me.simpleCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.simpleCheckBox.Name = "simpleCheckBox"
        Me.simpleCheckBox.Size = New System.Drawing.Size(124, 24)
        Me.simpleCheckBox.TabIndex = 2
        Me.simpleCheckBox.Text = "Draw Simple"
        Me.simpleCheckBox.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(1434, 1140)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(336, 233)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'borderWidthTextBox
        '
        Me.borderWidthTextBox.Location = New System.Drawing.Point(532, 1142)
        Me.borderWidthTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.borderWidthTextBox.Name = "borderWidthTextBox"
        Me.borderWidthTextBox.Size = New System.Drawing.Size(168, 26)
        Me.borderWidthTextBox.TabIndex = 4
        '
        'applyAllButton
        '
        Me.applyAllButton.Location = New System.Drawing.Point(208, 1142)
        Me.applyAllButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.applyAllButton.Name = "applyAllButton"
        Me.applyAllButton.Size = New System.Drawing.Size(112, 35)
        Me.applyAllButton.TabIndex = 5
        Me.applyAllButton.Text = "Apply To All"
        Me.applyAllButton.UseVisualStyleBackColor = True
        '
        'borderColorButton
        '
        Me.borderColorButton.Location = New System.Drawing.Point(330, 1142)
        Me.borderColorButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.borderColorButton.Name = "borderColorButton"
        Me.borderColorButton.Size = New System.Drawing.Size(152, 35)
        Me.borderColorButton.TabIndex = 6
        Me.borderColorButton.Text = "Apply To Border"
        Me.borderColorButton.UseVisualStyleBackColor = True
        '
        'borderWidthButton
        '
        Me.borderWidthButton.Location = New System.Drawing.Point(532, 1182)
        Me.borderWidthButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.borderWidthButton.Name = "borderWidthButton"
        Me.borderWidthButton.Size = New System.Drawing.Size(170, 40)
        Me.borderWidthButton.TabIndex = 7
        Me.borderWidthButton.Text = "Select Border Size"
        Me.borderWidthButton.UseVisualStyleBackColor = True
        '
        'fontButton
        '
        Me.fontButton.Location = New System.Drawing.Point(18, 1471)
        Me.fontButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.fontButton.Name = "fontButton"
        Me.fontButton.Size = New System.Drawing.Size(112, 35)
        Me.fontButton.TabIndex = 8
        Me.fontButton.Text = "Select Font"
        Me.fontButton.UseVisualStyleBackColor = True
        '
        'drawEmptyButton
        '
        Me.drawEmptyButton.Location = New System.Drawing.Point(208, 1186)
        Me.drawEmptyButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.drawEmptyButton.Name = "drawEmptyButton"
        Me.drawEmptyButton.Size = New System.Drawing.Size(112, 35)
        Me.drawEmptyButton.TabIndex = 9
        Me.drawEmptyButton.Text = "Draw Empty"
        Me.drawEmptyButton.UseVisualStyleBackColor = True
        '
        'gradientButton
        '
        Me.gradientButton.Location = New System.Drawing.Point(208, 1231)
        Me.gradientButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gradientButton.Name = "gradientButton"
        Me.gradientButton.Size = New System.Drawing.Size(112, 35)
        Me.gradientButton.TabIndex = 10
        Me.gradientButton.Text = "Gradient"
        Me.gradientButton.UseVisualStyleBackColor = True
        '
        'MapControl1
        '
        Me.MapControl1.BaseImage = CType(resources.GetObject("MapControl1.BaseImage"), System.Drawing.Image)
        Gradient1.CenterColor = System.Drawing.Color.Green
        Gradient1.SideColor = System.Drawing.Color.DarkGreen
        Me.MapControl1.DefGradient = Gradient1
        Me.MapControl1.DrawNames = True
        Me.MapControl1.FillPolygons = True
        Me.MapControl1.Location = New System.Drawing.Point(18, 18)
        Me.MapControl1.MapFont = New System.Drawing.Font("Times New Roman", 50.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.MapControl1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.MapControl1.Name = "MapControl1"
        Me.MapControl1.SimpleDraw = True
        Me.MapControl1.Size = New System.Drawing.Size(1754, 1112)
        Me.MapControl1.TabIndex = 0
        '
        'mapTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1050)
        Me.Controls.Add(Me.gradientButton)
        Me.Controls.Add(Me.drawEmptyButton)
        Me.Controls.Add(Me.fontButton)
        Me.Controls.Add(Me.borderWidthButton)
        Me.Controls.Add(Me.borderColorButton)
        Me.Controls.Add(Me.applyAllButton)
        Me.Controls.Add(Me.borderWidthTextBox)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.simpleCheckBox)
        Me.Controls.Add(Me.colorComboBox)
        Me.Controls.Add(Me.MapControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "mapTest"
        Me.Text = "mapTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents colorComboBox As ComboBox
    Friend WithEvents simpleCheckBox As CheckBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents borderWidthTextBox As TextBox
    Friend WithEvents applyAllButton As Button
    Friend WithEvents borderColorButton As Button
    Friend WithEvents borderWidthButton As Button
    Friend WithEvents fontButton As Button
    Friend WithEvents drawEmptyButton As Button
    Friend WithEvents gradientButton As Button
    Friend WithEvents MapControl1 As Map.MapControl
End Class