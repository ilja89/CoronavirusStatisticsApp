Imports CoronaStatisticsGetter
Imports FontAwesome.Sharp


Public Class Main
    'Details declaration
    Public saveLoad As New CStatSaveLoad
    Public request As CRequest

    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form

    Private countyStat As CStatList
    Public covidTest As CStatList
    Public covidVact As CStatList
    Public covidSick As CStatList
    Public covidTestPosGen As CStatList
    Public covidVactGen As CStatList
    Public covidSickGen As CStatList
    Public covidTestPositiveCounty As CStatList
    Private _lastButtonColor As Color = Color.DarkGray
    Private mouseCoords As Point = New Point(0, 0)
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    'Dim statGraphs As New statWin

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        request = New CRequest(_cachePath)
        MapControlHide()
        OpenChildForm(New homeForm)
        CurrentIconLabel.Text = "Home"
        'StatWin1.Visible = False

        ' Data updating
        If (Await saveLoad.UpdateData(_cachePath)) Then
            covidTest = request.GetTestStatCounty(, False)
            covidVact = request.GetVaccinationStatByCounty
            covidSick = request.GetSickCounty
        End If
        ' After all info getting is finished, call garbage collector to free memory from not needed trash
        ReleaseMemory()
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
        Dim oldChildForm As Form = currentChildForm
        If currentChildForm IsNot Nothing Then
            currentChildForm.Visible = False
        End If
        currentChildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelDesktop.Controls.Add(childForm)
        PanelDesktop.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
        CurrentIconLabel.Text = childForm.Text
        If (oldChildForm IsNot Nothing) Then
            oldChildForm.Dispose()
        End If
    End Sub
    Private Sub CloseChildForm()
        If currentChildForm IsNot Nothing Then
            currentChildForm.Visible = False
            currentChildForm.Dispose()
        End If
    End Sub
    Private Sub BoxLogo_Click(sender As Object, e As EventArgs) Handles BoxLogo.Click
        If MapControl1 IsNot Nothing Then
            MapControlHide()
        End If
        OpenChildForm(New homeForm)
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
        CloseChildForm()
        MapControlShow()
        MapControl1.BringToFront()
        ActivateButton(sender, Color.LawnGreen)
        'StatWin1.Visible = False

    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        If MapControl1 IsNot Nothing Then
            MapControlHide()
        End If
        ActivateButton(sender, Color.Cyan)
        OpenChildForm(New statGraphs)
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

    Private Sub MapControlHide()
        MapControl1.Visible = False
        If (MapControl1.PictureBoxImage IsNot Nothing) Then
            saveLoad.SaveTo(MapControl1.PictureBoxImage, _cachePath, "MapControlImage")
            MapControl1.PictureBoxImage.Dispose()
            MapControl1.PictureBoxImage = Nothing
        End If
    End Sub
    Private Sub MapControlShow()
        MapControl1.PictureBoxImage = saveLoad.LoadFrom(_cachePath, "MapControlImage")
        MapControl1.Visible = True
    End Sub

    Private Sub MapControl1_Click(clickPosition As Point, polygonName As String, polygonKey As String) Handles MapControl1.Clicked
        If (covidTest IsNot Nothing AndAlso covidSick IsNot Nothing AndAlso covidVact IsNot Nothing) Then
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
            popup.Init(covidTest.AsNew.Where("Result", "P").Where("County", polygonKey),
                       covidSick.AsNew.Where("County", polygonKey),
                       covidVact.AsNew.Where("County", polygonKey).Where("Type", "FullyVaccinated"))
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
        End If
        Dim k As PseudoString
        Dim s As New StringClass("12345678 This is string example, but it will be turned into long to save some space, yay!")
        Dim l As Integer = s.str.Length
        k = Converter.ToLong(s)
        Dim back = Converter.ToDefString(k)
    End Sub

    Private Sub ReleaseMemory()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If Environment.OSVersion.Platform = PlatformID.Win32NT Then
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

    Private Sub GarbageTimer_Tick(sender As Object, e As EventArgs) Handles GarbageTimer.Tick
        ReleaseMemory()
    End Sub
End Class

Public Class StringClass
    Public str As String
    Public Sub New(newStr As String)
        str = newStr
    End Sub
End Class

Public Class PseudoString
    Public str() As Long
    Public strLen As Integer
    Public Sub New(newStr() As Long, newStrLen As Integer)
        str = newStr
        strLen = newStrLen
    End Sub
End Class

Public Class Converter
    Public Shared Function ToLong(s As StringClass) As PseudoString
        Dim i As Integer = 0
        Dim c As Integer = 0
        Dim charNum As Integer = 0
        Dim resLen = Math.Floor(s.str.Length / 8)
        Dim result(resLen) As Long
        While (i < resLen)
            While (c < 8)
                If (charNum < s.str.Length) Then
                    result(i) = result(i) Or Asc(s.str(charNum)) << c * 8
                    charNum += 1
                End If
                c += 1
            End While
            If (charNum = s.str.Length) Then
                Exit While
            End If
            c = 0
            i += 1
        End While
        Return New PseudoString(result, charNum)
    End Function

    Public Shared Function ToDefString(s As PseudoString) As String
        Dim i As Integer = 0
        Dim c As Integer = 0
        Dim charNum As Integer = 0
        Dim result(s.strLen) As Char
        While (i < s.str.Length)
            While (c < 8)
                If (charNum < s.strLen) Then
                    result(charNum) = Chr((s.str(i) And 255 << c * 8) >> c * 8)
                    charNum += 1
                End If
                c += 1
            End While
            If (charNum = s.strLen) Then
                Exit While
            End If
            c = 0
            i += 1
        End While
        Return result
    End Function
End Class