Imports FontAwesome.Sharp
Imports CoronaStatisticsGetter
Imports System.Net.WebClient
Imports System.Net
Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Math
Imports Map


Public Class Main
    'Details declaration
    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form
    Private countyStat As CStatList
    Public request As CRequest
    Public covidTest As CStatList
    Public covidVact As CStatList
    Public covidSick As CStatList
    Public covidTestPosGen As CStatList
    Public covidVactGen As CStatList
    Public covidSickGen As CStatList
    Private _lastButtonColor As Color = Color.DarkGray
    Private mouseCoords As Point = New Point(0, 0)
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    'Dim statGraphs As New statWin

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        request = New CRequest(_cachePath)
        MapControl1.Visible = False
        'StatWin1.Visible = False

        ' Data updating
        If (Await CStatSaveLoad.UpdateData(_cachePath)) Then
            covidTest = request.getTestStatCounty
            covidVact = request.getVaccinationStatByCounty
            covidSick = request.getSickCounty
            covidTestPosGen = request.getTestStatPositiveGeneral
            covidVactGen = request.getVaccinationStatGeneral
            covidSickGen = request.getSick
        End If
        Dim k = covidTest.GetIndexOfFirstItemWhere("Date", {})
    End Sub

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
            _lastButtonColor = currentBtn.BackColor
            currentBtn.BackColor = Color.FromArgb(110, 110, 110)
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
            currentBtn.BackColor = _lastButtonColor
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
        If MapControl1 IsNot Nothing Then
            MapControl1.Visible = False
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ActivateButton(sender, Color.Pink)
        Application.Exit()
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        MapControl1.Visible = True
        MapControl1.BringToFront()
        ActivateButton(sender, Color.Green)
        'StatWin1.Visible = False

    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        If MapControl1 IsNot Nothing Then
            MapControl1.Visible = False
        End If
        ActivateButton(sender, Color.Cyan)
        OpenChildForm(New statGraphs)


        'StatWin1.Visible = True


    End Sub

    Private Sub btnTelegramm_Click(sender As Object, e As EventArgs) Handles btnTelegramm.Click
        ActivateButton(sender, Color.MediumVioletRed)

    End Sub

    Private Sub btnExtra2_Click(sender As Object, e As EventArgs) Handles btnExtra2.Click
        ActivateButton(sender, Color.Violet)

    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ActivateButton(sender, Color.FromArgb(205, 205, 13))

    End Sub

    Private Sub MapControl1_Load(sender As Object, e As EventArgs)

    End Sub
    Private Async Sub MapControl1_Click(clickPosition As Point, polygonName As String, polygonKey As String) Handles MapControl1.Clicked
        Dim positions() As KeyValuePair(Of String, Point) = {
            New KeyValuePair(Of String, Point)("Harju maakond", New Point(426, 79)),
            New KeyValuePair(Of String, Point)("Ida-Viru maakond", New Point(801, 87)),
            New KeyValuePair(Of String, Point)("Lääne-Viru maakond", New Point(620, 70)),
            New KeyValuePair(Of String, Point)("Järva maakond", New Point(526, 149)),
            New KeyValuePair(Of String, Point)("Jõgeva maakond", New Point(625, 190)),
            New KeyValuePair(Of String, Point)("Võru maakond", New Point(709, 370)),
            New KeyValuePair(Of String, Point)("Põlva maakond", New Point(742, 310)),
            New KeyValuePair(Of String, Point)("Valga maakond", New Point(593, 329)),
            New KeyValuePair(Of String, Point)("Tartu maakond", New Point(680, 250)),
            New KeyValuePair(Of String, Point)("Pärnu maakond", New Point(366, 239)),
            New KeyValuePair(Of String, Point)("Rapla maakond", New Point(392, 149)),
            New KeyValuePair(Of String, Point)("Lääne maakond", New Point(260, 149)),
            New KeyValuePair(Of String, Point)("Saare maakond", New Point(88, 250)),
            New KeyValuePair(Of String, Point)("Hiiu maakond", New Point(106, 149)),
            New KeyValuePair(Of String, Point)("Viljandi maakond", New Point(106, 149))}

        Dim popup As New popupWin
        Controls.Add(popup)
        popup.Location = mouseCoords
        For Each position As KeyValuePair(Of String, Point) In positions
            If (position.Key = polygonKey) Then
                popup.Location = position.Value
                Exit For
            End If
        Next
        If (polygonName IsNot Nothing) Then
            popup.Name = polygonName
            popup.BringToFront()
        End If
        Dim CovidTestEdited As CStatList = covidTest.AsNew.Where("County", polygonKey)
        Dim CovidSickEdited As CStatList = covidSick.AsNew.Where("County", polygonKey)
        Dim CovidVactEdited As CStatList = covidVact.AsNew.Where("County", polygonKey)

        popup.allTest.Text = CovidTestEdited.GetField(CovidTestEdited.Count - 1, "TotalTests")
        popup.allSick.Text = CovidSickEdited.GetField(CovidSickEdited.Count - 1, "Sick")
        popup.allVact.Text = CovidVactEdited.GetField(CovidVactEdited.Count - 1, "TotalCount")
        popup.countyName.Text = polygonName
    End Sub
End Class
