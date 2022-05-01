<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class statSave
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
        Me.statTypeCombobox = New System.Windows.Forms.ComboBox()
        Me.dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dateTo = New System.Windows.Forms.DateTimePicker()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.appendCheckBox = New System.Windows.Forms.CheckBox()
        Me.infoLabel = New System.Windows.Forms.Label()
        Me.countyComboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'statTypeCombobox
        '
        Me.statTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.statTypeCombobox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.statTypeCombobox.FormattingEnabled = True
        Me.statTypeCombobox.Items.AddRange(New Object() {"Haiged Kokku", "Haiged Maakonnas", "Testid Kokku", "Testid Maakonnas", "Vaktsinationid Kokku", "Vaktsinatsionid Maakonnas", "Surnud Kokku", "Patsiendid Haiglas"})
        Me.statTypeCombobox.Location = New System.Drawing.Point(12, 12)
        Me.statTypeCombobox.Name = "statTypeCombobox"
        Me.statTypeCombobox.Size = New System.Drawing.Size(223, 28)
        Me.statTypeCombobox.TabIndex = 0
        '
        'dateFrom
        '
        Me.dateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFrom.Location = New System.Drawing.Point(241, 12)
        Me.dateFrom.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Size = New System.Drawing.Size(200, 26)
        Me.dateFrom.TabIndex = 1
        '
        'dateTo
        '
        Me.dateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTo.Location = New System.Drawing.Point(447, 12)
        Me.dateTo.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Size = New System.Drawing.Size(200, 26)
        Me.dateTo.TabIndex = 2
        '
        'saveButton
        '
        Me.saveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.saveButton.Location = New System.Drawing.Point(653, 12)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(100, 26)
        Me.saveButton.TabIndex = 3
        Me.saveButton.Text = "Salvestada"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'appendCheckBox
        '
        Me.appendCheckBox.AutoSize = True
        Me.appendCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.appendCheckBox.Location = New System.Drawing.Point(759, 12)
        Me.appendCheckBox.Name = "appendCheckBox"
        Me.appendCheckBox.Size = New System.Drawing.Size(118, 24)
        Me.appendCheckBox.TabIndex = 4
        Me.appendCheckBox.Text = "Lisada lõppu"
        Me.appendCheckBox.UseVisualStyleBackColor = True
        '
        'infoLabel
        '
        Me.infoLabel.AutoSize = True
        Me.infoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.infoLabel.Location = New System.Drawing.Point(274, 428)
        Me.infoLabel.Name = "infoLabel"
        Me.infoLabel.Size = New System.Drawing.Size(57, 20)
        Me.infoLabel.TabIndex = 5
        Me.infoLabel.Text = "Label1"
        '
        'countyComboBox
        '
        Me.countyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.countyComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.countyComboBox.FormattingEnabled = True
        Me.countyComboBox.Items.AddRange(New Object() {"Hiiu maakond", "Saare maakond", "Lääne maakond", "Harju maakond", "Rapla maakond", "Pärnu maakond", "Viljandi maakond", "Tartu maakond", "Valga maakond", "Põlva maakond", "Võru maakond", "Jõgeva maakond", "Järva maakond", "Lääne-Viru maakond", "Ida-Viru maakond"})
        Me.countyComboBox.Location = New System.Drawing.Point(12, 46)
        Me.countyComboBox.Name = "countyComboBox"
        Me.countyComboBox.Size = New System.Drawing.Size(223, 28)
        Me.countyComboBox.TabIndex = 6
        '
        'statSave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 509)
        Me.Controls.Add(Me.countyComboBox)
        Me.Controls.Add(Me.infoLabel)
        Me.Controls.Add(Me.appendCheckBox)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.dateTo)
        Me.Controls.Add(Me.dateFrom)
        Me.Controls.Add(Me.statTypeCombobox)
        Me.Name = "statSave"
        Me.Text = "statSave"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents statTypeCombobox As ComboBox
    Friend WithEvents dateFrom As DateTimePicker
    Friend WithEvents dateTo As DateTimePicker
    Friend WithEvents saveButton As Button
    Friend WithEvents appendCheckBox As CheckBox
    Friend WithEvents infoLabel As Label
    Friend WithEvents countyComboBox As ComboBox
End Class
