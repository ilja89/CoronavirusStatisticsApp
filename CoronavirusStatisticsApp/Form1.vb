Imports FontAwesome.Sharp

Public Class Form1
    'Details declaration
    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form

    'Constructor
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        leftBorderBtn = New Panel()
        leftBorderBtn.Size = New Size(7, 60)
        MenuPanel.Controls.Add(leftBorderBtn)

    End Sub

    Private Sub ActivateButton(senderBtn As Object, customColor As Color)
        If senderBtn IsNot Nothing Then
            DisabledBtn()
            'Button
            currentBtn = CType(senderBtn, IconButton)
            currentBtn.BackColor = Color.FromArgb(37, 36, 81)
            currentBtn.ForeColor = customColor
            currentBtn.IconColor = customColor
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
            currentBtn.ImageAlign = ContentAlignment.MiddleRight
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage
            'Left side
            leftBorderBtn.BackColor = customColor
            leftBorderBtn.Location = New Point(0, currentBtn.Location.Y)
            leftBorderBtn.Visible = True
            leftBorderBtn.BringToFront()
            'Current form icon
            CurrentIcon.IconChar = currentBtn.IconChar
            CurrentIcon.IconColor = customColor
            CurrentIconLabel.Text = currentBtn.Text

        End If
    End Sub

    Private Sub DisabledBtn()
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = Color.DimGray
            currentBtn.ForeColor = Color.Black
            currentBtn.IconColor = Color.Black
            currentBtn.TextAlign = ContentAlignment.MiddleLeft
            currentBtn.ImageAlign = ContentAlignment.MiddleLeft
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        End If
    End Sub

    Private Sub OpenChildForm(childForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        currentChildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        childForm.BringToFront()
        childForm.Show()
        PanelDesktop.Controls.Add(childForm)
        PanelDesktop.Tag = childForm
        childForm.BringToFront()
        CurrentIconLabel.Text = childForm.Text

    End Sub
    Private Sub BoxLogo_Click(sender As Object, e As EventArgs) Handles BoxLogo.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        Reset()


    End Sub

    Private Sub Reset()
        DisabledBtn()
        leftBorderBtn.Visible = False
        CurrentIcon.IconChar = IconChar.Home
        CurrentIcon.IconColor = Color.Black
        CurrentIconLabel.Text = "Home"

    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ActivateButton(sender, Color.Gray)
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Statistics.Visible = True
    End Sub
End Class
