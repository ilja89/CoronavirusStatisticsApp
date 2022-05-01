<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
        Me.labelCSVExporterSettings = New System.Windows.Forms.Label()
        Me.textBoxDelimiter = New System.Windows.Forms.TextBox()
        Me.labelDelimiter = New System.Windows.Forms.Label()
        Me.labelTextQualifier = New System.Windows.Forms.Label()
        Me.textBoxTextQualifier = New System.Windows.Forms.TextBox()
        Me.labelGeneralAppSettings = New System.Windows.Forms.Label()
        Me.labelCachePath = New System.Windows.Forms.Label()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.richTextBoxCachePath = New System.Windows.Forms.RichTextBox()
        Me.buttonCachePathChange = New System.Windows.Forms.Button()
        Me.buttonCachePathReset = New System.Windows.Forms.Button()
        Me.labelApplicationColors = New System.Windows.Forms.Label()
        Me.buttonChangeApplicationColors = New System.Windows.Forms.Button()
        Me.buttonResetApplicationColors = New System.Windows.Forms.Button()
        Me.listBoxApplicationElement = New System.Windows.Forms.ListBox()
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.SuspendLayout()
        '
        'labelCSVExporterSettings
        '
        Me.labelCSVExporterSettings.AutoEllipsis = True
        Me.labelCSVExporterSettings.AutoSize = True
        Me.labelCSVExporterSettings.BackColor = System.Drawing.Color.DarkGray
        Me.labelCSVExporterSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelCSVExporterSettings.Location = New System.Drawing.Point(12, 9)
        Me.labelCSVExporterSettings.Name = "labelCSVExporterSettings"
        Me.labelCSVExporterSettings.Size = New System.Drawing.Size(294, 29)
        Me.labelCSVExporterSettings.TabIndex = 0
        Me.labelCSVExporterSettings.Text = "CSV Eksportimise seaded"
        '
        'textBoxDelimiter
        '
        Me.textBoxDelimiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.textBoxDelimiter.Location = New System.Drawing.Point(163, 44)
        Me.textBoxDelimiter.Name = "textBoxDelimiter"
        Me.textBoxDelimiter.Size = New System.Drawing.Size(100, 29)
        Me.textBoxDelimiter.TabIndex = 1
        '
        'labelDelimiter
        '
        Me.labelDelimiter.AutoEllipsis = True
        Me.labelDelimiter.AutoSize = True
        Me.labelDelimiter.BackColor = System.Drawing.Color.DarkGray
        Me.labelDelimiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelDelimiter.Location = New System.Drawing.Point(12, 49)
        Me.labelDelimiter.Name = "labelDelimiter"
        Me.labelDelimiter.Size = New System.Drawing.Size(141, 24)
        Me.labelDelimiter.TabIndex = 2
        Me.labelDelimiter.Text = "Eraldus sümbol"
        '
        'labelTextQualifier
        '
        Me.labelTextQualifier.AutoEllipsis = True
        Me.labelTextQualifier.AutoSize = True
        Me.labelTextQualifier.BackColor = System.Drawing.Color.DarkGray
        Me.labelTextQualifier.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelTextQualifier.Location = New System.Drawing.Point(12, 84)
        Me.labelTextQualifier.Name = "labelTextQualifier"
        Me.labelTextQualifier.Size = New System.Drawing.Size(100, 24)
        Me.labelTextQualifier.TabIndex = 3
        Me.labelTextQualifier.Text = "Teksti valik"
        '
        'textBoxTextQualifier
        '
        Me.textBoxTextQualifier.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.textBoxTextQualifier.Location = New System.Drawing.Point(163, 79)
        Me.textBoxTextQualifier.Name = "textBoxTextQualifier"
        Me.textBoxTextQualifier.Size = New System.Drawing.Size(100, 29)
        Me.textBoxTextQualifier.TabIndex = 4
        '
        'labelGeneralAppSettings
        '
        Me.labelGeneralAppSettings.AutoEllipsis = True
        Me.labelGeneralAppSettings.AutoSize = True
        Me.labelGeneralAppSettings.BackColor = System.Drawing.Color.DarkGray
        Me.labelGeneralAppSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelGeneralAppSettings.Location = New System.Drawing.Point(11, 118)
        Me.labelGeneralAppSettings.Name = "labelGeneralAppSettings"
        Me.labelGeneralAppSettings.Size = New System.Drawing.Size(183, 29)
        Me.labelGeneralAppSettings.TabIndex = 7
        Me.labelGeneralAppSettings.Text = "Üldised seaded"
        '
        'labelCachePath
        '
        Me.labelCachePath.AutoEllipsis = True
        Me.labelCachePath.AutoSize = True
        Me.labelCachePath.BackColor = System.Drawing.Color.DarkGray
        Me.labelCachePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelCachePath.Location = New System.Drawing.Point(12, 155)
        Me.labelCachePath.Name = "labelCachePath"
        Me.labelCachePath.Size = New System.Drawing.Size(167, 24)
        Me.labelCachePath.TabIndex = 5
        Me.labelCachePath.Text = "Äppi vahemälu tee"
        '
        'richTextBoxCachePath
        '
        Me.richTextBoxCachePath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.richTextBoxCachePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.richTextBoxCachePath.Location = New System.Drawing.Point(12, 182)
        Me.richTextBoxCachePath.Name = "richTextBoxCachePath"
        Me.richTextBoxCachePath.ReadOnly = True
        Me.richTextBoxCachePath.Size = New System.Drawing.Size(388, 44)
        Me.richTextBoxCachePath.TabIndex = 8
        Me.richTextBoxCachePath.Text = ""
        '
        'buttonCachePathChange
        '
        Me.buttonCachePathChange.Location = New System.Drawing.Point(12, 232)
        Me.buttonCachePathChange.Name = "buttonCachePathChange"
        Me.buttonCachePathChange.Size = New System.Drawing.Size(194, 23)
        Me.buttonCachePathChange.TabIndex = 9
        Me.buttonCachePathChange.Text = "Muuta"
        Me.buttonCachePathChange.UseVisualStyleBackColor = True
        '
        'buttonCachePathReset
        '
        Me.buttonCachePathReset.BackColor = System.Drawing.Color.Transparent
        Me.buttonCachePathReset.Location = New System.Drawing.Point(212, 232)
        Me.buttonCachePathReset.Name = "buttonCachePathReset"
        Me.buttonCachePathReset.Size = New System.Drawing.Size(188, 23)
        Me.buttonCachePathReset.TabIndex = 10
        Me.buttonCachePathReset.Text = "Vaikimisi"
        Me.buttonCachePathReset.UseVisualStyleBackColor = False
        '
        'labelApplicationColors
        '
        Me.labelApplicationColors.AutoEllipsis = True
        Me.labelApplicationColors.AutoSize = True
        Me.labelApplicationColors.BackColor = System.Drawing.Color.DarkGray
        Me.labelApplicationColors.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.labelApplicationColors.Location = New System.Drawing.Point(13, 258)
        Me.labelApplicationColors.Name = "labelApplicationColors"
        Me.labelApplicationColors.Size = New System.Drawing.Size(103, 24)
        Me.labelApplicationColors.TabIndex = 11
        Me.labelApplicationColors.Text = "Äppi värvid"
        '
        'buttonChangeApplicationColors
        '
        Me.buttonChangeApplicationColors.Location = New System.Drawing.Point(296, 285)
        Me.buttonChangeApplicationColors.Name = "buttonChangeApplicationColors"
        Me.buttonChangeApplicationColors.Size = New System.Drawing.Size(110, 23)
        Me.buttonChangeApplicationColors.TabIndex = 13
        Me.buttonChangeApplicationColors.Text = "Muuta"
        Me.buttonChangeApplicationColors.UseVisualStyleBackColor = True
        '
        'buttonResetApplicationColors
        '
        Me.buttonResetApplicationColors.BackColor = System.Drawing.Color.Transparent
        Me.buttonResetApplicationColors.Location = New System.Drawing.Point(296, 314)
        Me.buttonResetApplicationColors.Name = "buttonResetApplicationColors"
        Me.buttonResetApplicationColors.Size = New System.Drawing.Size(110, 23)
        Me.buttonResetApplicationColors.TabIndex = 14
        Me.buttonResetApplicationColors.Text = "Vaikimisi"
        Me.buttonResetApplicationColors.UseVisualStyleBackColor = False
        '
        'listBoxApplicationElement
        '
        Me.listBoxApplicationElement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listBoxApplicationElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.listBoxApplicationElement.FormattingEnabled = True
        Me.listBoxApplicationElement.ItemHeight = 16
        Me.listBoxApplicationElement.Items.AddRange(New Object() {"Main Color", "Secondary Color", "Map Button Color", "Statistics Button Color", "Telegram Button Color", "Settings Button Color", "Exit Button Color", "Map Popup Color Main", "Map Popup Color Secondary"})
        Me.listBoxApplicationElement.Location = New System.Drawing.Point(12, 285)
        Me.listBoxApplicationElement.Name = "listBoxApplicationElement"
        Me.listBoxApplicationElement.ScrollAlwaysVisible = True
        Me.listBoxApplicationElement.Size = New System.Drawing.Size(278, 148)
        Me.listBoxApplicationElement.TabIndex = 15
        '
        'colorDialog1
        '
        Me.colorDialog1.AnyColor = True
        Me.colorDialog1.FullOpen = True
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.listBoxApplicationElement)
        Me.Controls.Add(Me.buttonResetApplicationColors)
        Me.Controls.Add(Me.buttonChangeApplicationColors)
        Me.Controls.Add(Me.labelApplicationColors)
        Me.Controls.Add(Me.buttonCachePathReset)
        Me.Controls.Add(Me.buttonCachePathChange)
        Me.Controls.Add(Me.richTextBoxCachePath)
        Me.Controls.Add(Me.labelGeneralAppSettings)
        Me.Controls.Add(Me.labelCachePath)
        Me.Controls.Add(Me.textBoxTextQualifier)
        Me.Controls.Add(Me.labelTextQualifier)
        Me.Controls.Add(Me.labelDelimiter)
        Me.Controls.Add(Me.textBoxDelimiter)
        Me.Controls.Add(Me.labelCSVExporterSettings)
        Me.Name = "settings"
        Me.Text = "settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents labelCSVExporterSettings As Label
    Friend WithEvents textBoxDelimiter As TextBox
    Friend WithEvents labelDelimiter As Label
    Friend WithEvents labelTextQualifier As Label
    Friend WithEvents textBoxTextQualifier As TextBox
    Friend WithEvents labelGeneralAppSettings As Label
    Friend WithEvents labelCachePath As Label
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents richTextBoxCachePath As RichTextBox
    Friend WithEvents buttonCachePathChange As Button
    Friend WithEvents buttonCachePathReset As Button
    Friend WithEvents labelApplicationColors As Label
    Friend WithEvents buttonChangeApplicationColors As Button
    Friend WithEvents buttonResetApplicationColors As Button
    Friend WithEvents listBoxApplicationElement As ListBox
    Friend WithEvents colorDialog1 As ColorDialog
End Class
