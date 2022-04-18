<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim CGradient1 As Map.CGradient = New Map.CGradient()
        Me.MenuPanel = New System.Windows.Forms.Panel()
        Me.btnExit = New FontAwesome.Sharp.IconButton()
        Me.btnSettings = New FontAwesome.Sharp.IconButton()
        Me.btnExtra2 = New FontAwesome.Sharp.IconButton()
        Me.btnTelegramm = New FontAwesome.Sharp.IconButton()
        Me.btnStatistics = New FontAwesome.Sharp.IconButton()
        Me.btnMap = New FontAwesome.Sharp.IconButton()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.BoxLogo = New System.Windows.Forms.PictureBox()
        Me.PanelBar = New System.Windows.Forms.Panel()
        Me.CurrentIconLabel = New System.Windows.Forms.Label()
        Me.CurrentIcon = New FontAwesome.Sharp.IconPictureBox()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelDesktop = New System.Windows.Forms.Panel()
        Me.GarbageTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MapControl1 = New Map.MapControl()
        Me.MenuPanel.SuspendLayout()
        Me.PanelLogo.SuspendLayout()
        CType(Me.BoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBar.SuspendLayout()
        CType(Me.CurrentIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDesktop.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPanel
        '
        Me.MenuPanel.BackColor = System.Drawing.Color.DarkGray
        Me.MenuPanel.Controls.Add(Me.btnExit)
        Me.MenuPanel.Controls.Add(Me.btnSettings)
        Me.MenuPanel.Controls.Add(Me.btnExtra2)
        Me.MenuPanel.Controls.Add(Me.btnTelegramm)
        Me.MenuPanel.Controls.Add(Me.btnStatistics)
        Me.MenuPanel.Controls.Add(Me.btnMap)
        Me.MenuPanel.Controls.Add(Me.PanelLogo)
        Me.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuPanel.Location = New System.Drawing.Point(0, 0)
        Me.MenuPanel.Name = "MenuPanel"
        Me.MenuPanel.Size = New System.Drawing.Size(233, 761)
        Me.MenuPanel.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.DarkGray
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft
        Me.btnExit.IconColor = System.Drawing.Color.Black
        Me.btnExit.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnExit.IconSize = 40
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(0, 698)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.btnExit.Size = New System.Drawing.Size(233, 63)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.DarkGray
        Me.btnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.IconChar = FontAwesome.Sharp.IconChar.SlidersH
        Me.btnSettings.IconColor = System.Drawing.Color.Black
        Me.btnSettings.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnSettings.IconSize = 40
        Me.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettings.Location = New System.Drawing.Point(0, 380)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.btnSettings.Size = New System.Drawing.Size(233, 60)
        Me.btnSettings.TabIndex = 5
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnExtra2
        '
        Me.btnExtra2.BackColor = System.Drawing.Color.DarkGray
        Me.btnExtra2.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExtra2.FlatAppearance.BorderSize = 0
        Me.btnExtra2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtra2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtra2.IconChar = FontAwesome.Sharp.IconChar.Question
        Me.btnExtra2.IconColor = System.Drawing.Color.Black
        Me.btnExtra2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnExtra2.IconSize = 40
        Me.btnExtra2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtra2.Location = New System.Drawing.Point(0, 320)
        Me.btnExtra2.Name = "btnExtra2"
        Me.btnExtra2.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.btnExtra2.Size = New System.Drawing.Size(233, 60)
        Me.btnExtra2.TabIndex = 4
        Me.btnExtra2.Text = "Extra Button 2"
        Me.btnExtra2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtra2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExtra2.UseVisualStyleBackColor = False
        '
        'btnTelegramm
        '
        Me.btnTelegramm.BackColor = System.Drawing.Color.DarkGray
        Me.btnTelegramm.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTelegramm.FlatAppearance.BorderSize = 0
        Me.btnTelegramm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTelegramm.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTelegramm.IconChar = FontAwesome.Sharp.IconChar.Telegram
        Me.btnTelegramm.IconColor = System.Drawing.Color.Black
        Me.btnTelegramm.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnTelegramm.IconSize = 40
        Me.btnTelegramm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTelegramm.Location = New System.Drawing.Point(0, 260)
        Me.btnTelegramm.Name = "btnTelegramm"
        Me.btnTelegramm.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.btnTelegramm.Size = New System.Drawing.Size(233, 60)
        Me.btnTelegramm.TabIndex = 3
        Me.btnTelegramm.Text = "Telegram"
        Me.btnTelegramm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTelegramm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTelegramm.UseVisualStyleBackColor = False
        '
        'btnStatistics
        '
        Me.btnStatistics.BackColor = System.Drawing.Color.DarkGray
        Me.btnStatistics.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnStatistics.FlatAppearance.BorderSize = 0
        Me.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStatistics.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatistics.IconChar = FontAwesome.Sharp.IconChar.Database
        Me.btnStatistics.IconColor = System.Drawing.Color.Black
        Me.btnStatistics.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnStatistics.IconSize = 40
        Me.btnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStatistics.Location = New System.Drawing.Point(0, 200)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.btnStatistics.Size = New System.Drawing.Size(233, 60)
        Me.btnStatistics.TabIndex = 2
        Me.btnStatistics.Text = "Statistics"
        Me.btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStatistics.UseVisualStyleBackColor = False
        '
        'btnMap
        '
        Me.btnMap.BackColor = System.Drawing.Color.DarkGray
        Me.btnMap.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMap.FlatAppearance.BorderSize = 0
        Me.btnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMap.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMap.IconChar = FontAwesome.Sharp.IconChar.Map
        Me.btnMap.IconColor = System.Drawing.Color.Black
        Me.btnMap.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnMap.IconSize = 42
        Me.btnMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMap.Location = New System.Drawing.Point(0, 140)
        Me.btnMap.Name = "btnMap"
        Me.btnMap.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.btnMap.Size = New System.Drawing.Size(233, 60)
        Me.btnMap.TabIndex = 1
        Me.btnMap.Text = "Map"
        Me.btnMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMap.UseVisualStyleBackColor = False
        '
        'PanelLogo
        '
        Me.PanelLogo.BackColor = System.Drawing.Color.DarkGray
        Me.PanelLogo.Controls.Add(Me.BoxLogo)
        Me.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLogo.Location = New System.Drawing.Point(0, 0)
        Me.PanelLogo.Name = "PanelLogo"
        Me.PanelLogo.Size = New System.Drawing.Size(233, 140)
        Me.PanelLogo.TabIndex = 0
        '
        'BoxLogo
        '
        Me.BoxLogo.BackColor = System.Drawing.Color.DarkGray
        Me.BoxLogo.BackgroundImage = CType(resources.GetObject("BoxLogo.BackgroundImage"), System.Drawing.Image)
        Me.BoxLogo.Location = New System.Drawing.Point(11, 12)
        Me.BoxLogo.Name = "BoxLogo"
        Me.BoxLogo.Size = New System.Drawing.Size(202, 112)
        Me.BoxLogo.TabIndex = 0
        Me.BoxLogo.TabStop = False
        '
        'PanelBar
        '
        Me.PanelBar.BackColor = System.Drawing.Color.DarkGray
        Me.PanelBar.Controls.Add(Me.CurrentIconLabel)
        Me.PanelBar.Controls.Add(Me.CurrentIcon)
        Me.PanelBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBar.Location = New System.Drawing.Point(233, 0)
        Me.PanelBar.Name = "PanelBar"
        Me.PanelBar.Size = New System.Drawing.Size(1045, 70)
        Me.PanelBar.TabIndex = 1
        '
        'CurrentIconLabel
        '
        Me.CurrentIconLabel.AutoSize = True
        Me.CurrentIconLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentIconLabel.Location = New System.Drawing.Point(57, 33)
        Me.CurrentIconLabel.Name = "CurrentIconLabel"
        Me.CurrentIconLabel.Size = New System.Drawing.Size(43, 16)
        Me.CurrentIconLabel.TabIndex = 1
        Me.CurrentIconLabel.Text = "Home"
        '
        'CurrentIcon
        '
        Me.CurrentIcon.BackColor = System.Drawing.Color.DarkGray
        Me.CurrentIcon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CurrentIcon.IconChar = FontAwesome.Sharp.IconChar.Home
        Me.CurrentIcon.IconColor = System.Drawing.SystemColors.ControlText
        Me.CurrentIcon.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.CurrentIcon.Location = New System.Drawing.Point(19, 23)
        Me.CurrentIcon.Name = "CurrentIcon"
        Me.CurrentIcon.Size = New System.Drawing.Size(32, 32)
        Me.CurrentIcon.TabIndex = 0
        Me.CurrentIcon.TabStop = False
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "LogoCovid3.png")
        '
        'PanelDesktop
        '
        Me.PanelDesktop.BackColor = System.Drawing.Color.Gray
        Me.PanelDesktop.Controls.Add(Me.MapControl1)
        Me.PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDesktop.Location = New System.Drawing.Point(233, 70)
        Me.PanelDesktop.Name = "PanelDesktop"
        Me.PanelDesktop.Size = New System.Drawing.Size(1045, 691)
        Me.PanelDesktop.TabIndex = 2
        '
        'GarbageTimer
        '
        Me.GarbageTimer.Enabled = True
        Me.GarbageTimer.Interval = 30000
        '
        'MapControl1
        '
        Me.MapControl1.BaseImage = Nothing
        Me.MapControl1.DefBgCenterColor = System.Drawing.Color.Gray
        Me.MapControl1.DefBgSideColor = System.Drawing.Color.Gray
        CGradient1.CenterColor = System.Drawing.Color.Green
        CGradient1.SideColor = System.Drawing.Color.DarkGreen
        Me.MapControl1.DefGradient = CGradient1
        Me.MapControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl1.DrawNames = True
        Me.MapControl1.FillPolygons = True
        Me.MapControl1.Location = New System.Drawing.Point(0, 0)
        Me.MapControl1.MapFont = New System.Drawing.Font("Times New Roman", 50.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.MapControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MapControl1.Name = "MapControl1"
        Me.MapControl1.PictureBoxImage = CType(resources.GetObject("MapControl1.PictureBoxImage"), System.Drawing.Image)
        Me.MapControl1.SimpleBackgroundDraw = True
        Me.MapControl1.SimplePolygonsDraw = False
        Me.MapControl1.Size = New System.Drawing.Size(1045, 691)
        Me.MapControl1.TabIndex = 2
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1278, 761)
        Me.Controls.Add(Me.PanelDesktop)
        Me.Controls.Add(Me.PanelBar)
        Me.Controls.Add(Me.MenuPanel)
        Me.MinimumSize = New System.Drawing.Size(1158, 536)
        Me.Name = "Main"
        Me.Text = "CovidTrackr"
        Me.MenuPanel.ResumeLayout(False)
        Me.PanelLogo.ResumeLayout(False)
        CType(Me.BoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBar.ResumeLayout(False)
        Me.PanelBar.PerformLayout()
        CType(Me.CurrentIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDesktop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuPanel As Panel
    Friend WithEvents btnMap As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelLogo As Panel
    Friend WithEvents btnExit As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSettings As FontAwesome.Sharp.IconButton
    Friend WithEvents btnExtra2 As FontAwesome.Sharp.IconButton
    Friend WithEvents btnTelegramm As FontAwesome.Sharp.IconButton
    Friend WithEvents btnStatistics As FontAwesome.Sharp.IconButton
    Friend WithEvents BoxLogo As PictureBox
    Friend WithEvents PanelBar As Panel
    Friend WithEvents ImageList As ImageList
    Friend WithEvents CurrentIconLabel As Label
    Friend WithEvents CurrentIcon As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents PanelDesktop As Panel
    Friend WithEvents GarbageTimer As Timer
    Friend WithEvents MapControl1 As Map.MapControl
End Class
