<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class telegramSettings
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
        Me.onOffButton = New System.Windows.Forms.Button()
        Me.botTokenTextBox = New System.Windows.Forms.TextBox()
        Me.botTokenLabel = New System.Windows.Forms.Label()
        Me.botChatIDLabel = New System.Windows.Forms.Label()
        Me.botChatIDTextBox = New System.Windows.Forms.TextBox()
        Me.helpTokenButton = New System.Windows.Forms.Button()
        Me.helpChatIdButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'onOffButton
        '
        Me.onOffButton.Enabled = False
        Me.onOffButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.onOffButton.Location = New System.Drawing.Point(12, 12)
        Me.onOffButton.Name = "onOffButton"
        Me.onOffButton.Size = New System.Drawing.Size(88, 84)
        Me.onOffButton.TabIndex = 0
        Me.onOffButton.Text = "OFF"
        Me.onOffButton.UseVisualStyleBackColor = True
        '
        'botTokenTextBox
        '
        Me.botTokenTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.botTokenTextBox.Location = New System.Drawing.Point(275, 16)
        Me.botTokenTextBox.Name = "botTokenTextBox"
        Me.botTokenTextBox.Size = New System.Drawing.Size(484, 26)
        Me.botTokenTextBox.TabIndex = 1
        '
        'botTokenLabel
        '
        Me.botTokenLabel.AutoSize = True
        Me.botTokenLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.botTokenLabel.Location = New System.Drawing.Point(106, 22)
        Me.botTokenLabel.Name = "botTokenLabel"
        Me.botTokenLabel.Size = New System.Drawing.Size(163, 20)
        Me.botTokenLabel.TabIndex = 2
        Me.botTokenLabel.Text = "Boti märk (Bot Token)"
        '
        'botChatIDLabel
        '
        Me.botChatIDLabel.AutoSize = True
        Me.botChatIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.botChatIDLabel.Location = New System.Drawing.Point(106, 64)
        Me.botChatIDLabel.Name = "botChatIDLabel"
        Me.botChatIDLabel.Size = New System.Drawing.Size(92, 20)
        Me.botChatIDLabel.TabIndex = 3
        Me.botChatIDLabel.Text = "Vestluse ID"
        '
        'botChatIDTextBox
        '
        Me.botChatIDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.botChatIDTextBox.Location = New System.Drawing.Point(275, 58)
        Me.botChatIDTextBox.Name = "botChatIDTextBox"
        Me.botChatIDTextBox.Size = New System.Drawing.Size(484, 26)
        Me.botChatIDTextBox.TabIndex = 4
        '
        'helpTokenButton
        '
        Me.helpTokenButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.helpTokenButton.Location = New System.Drawing.Point(765, 16)
        Me.helpTokenButton.Name = "helpTokenButton"
        Me.helpTokenButton.Size = New System.Drawing.Size(23, 28)
        Me.helpTokenButton.TabIndex = 5
        Me.helpTokenButton.Text = "?"
        Me.helpTokenButton.UseVisualStyleBackColor = True
        '
        'helpChatIdButton
        '
        Me.helpChatIdButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.helpChatIdButton.Location = New System.Drawing.Point(765, 58)
        Me.helpChatIdButton.Name = "helpChatIdButton"
        Me.helpChatIdButton.Size = New System.Drawing.Size(23, 28)
        Me.helpChatIdButton.TabIndex = 6
        Me.helpChatIdButton.Text = "?"
        Me.helpChatIdButton.UseVisualStyleBackColor = True
        '
        'telegramSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.helpChatIdButton)
        Me.Controls.Add(Me.helpTokenButton)
        Me.Controls.Add(Me.botChatIDTextBox)
        Me.Controls.Add(Me.botChatIDLabel)
        Me.Controls.Add(Me.botTokenLabel)
        Me.Controls.Add(Me.botTokenTextBox)
        Me.Controls.Add(Me.onOffButton)
        Me.Name = "telegramSettings"
        Me.Text = "telegramSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents onOffButton As Button
    Friend WithEvents botTokenTextBox As TextBox
    Friend WithEvents botTokenLabel As Label
    Friend WithEvents botChatIDLabel As Label
    Friend WithEvents botChatIDTextBox As TextBox
    Friend WithEvents helpTokenButton As Button
    Friend WithEvents helpChatIdButton As Button
End Class
