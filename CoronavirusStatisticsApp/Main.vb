' FILENAME: Main.vb
' AUTOR: El Plan - Aleksandr Ivantsov, Ilja Kuznetsov
' CREATED: 16.03.2022
' CHANGED: 01.05.2022
'
' DESCRIPTION: See below
'
' RELATED COMPONENTS: StatisticsObject, CoronavirusStatisticsGetter
Imports CoronaStatisticsGetter
Imports FontAwesome.Sharp
Imports System.Math
Imports StatisticsObject
Imports Map

''' <summary>
''' Main form for application
''' </summary>
Public Class Main
    'Details declaration
    Private _saveLoad As IStatSaveLoad_ForLoadingControl = New CStatSaveLoad_ForLoadingControl
    Public request As IRequest

    Private currentBtn As IconButton
    Private leftBorderBtn As Panel
    Private currentChildForm As Form

    Private countyStat As IStatList
    Public covidTest As IStatList
    Public covidVact As IStatList
    Public covidSick As IStatList
    Public covidTestPosGen As IStatList
    Public covidVactGen As IStatList
    Public covidSickGen As IStatList
    Public covidTestPositiveCounty As IStatList

    Private _lastButtonColor As Color = Color.DarkGray
    Private mouseCoords As Point = New Point(0, 0)
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Private _threads As New List(Of Threading.Thread)
    Private _popupDate As String = DateTimeToString(DateTime.Now)

    Public Property SaveLoad As CStatSaveLoad_ForLoadingControl
        Get
            Return _saveLoad
        End Get
        Set(value As CStatSaveLoad_ForLoadingControl)
            _saveLoad = value
        End Set
    End Property
    'Dim statGraphs As New statWin

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal dwMinimumWorkingSetSize As Int32, ByVal dwMaximumWorkingSetSize As Int32) As Int32
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add event handlers
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler

        ' Initialize components
        request = New CRequest(_cachePath)
        mapDatePicker.MaxDate = DateTime.Now.AddDays(-1)
        InitMap()
        OpenChildForm(New homeForm)
        CurrentIconLabel.Text = "Kodu"

        MapHide()
        CreateLoadingOverlay()

        ' Data updating
        Try
            If (Await SaveLoad.UpdateData(_cachePath, Sub(progressValue As Integer) setProgress(progressValue))) Then
DataUpdate:     setProgress(60)
                covidTest = request.GetTestStatCounty(, False)
                setProgress(70)
                covidVact = request.GetVaccinationStatByCounty
                setProgress(80)
                covidSick = request.GetSickCounty
                setProgress(95)
                DeleteLoadingOverlay()
            End If
        Catch ex As Exception
            If (ex.Source = "mscorlib") Then
                GoTo DataUpdate
            Else
                Dim newRichTextBox As New RichTextBox
                Controls.Add(newRichTextBox)
                newRichTextBox.Text = "Exception: " + ex.Message + vbCrLf + "Try to restart application"
                newRichTextBox.Location = New Point(416, 15)
                newRichTextBox.Font = New Font("Times New Roman", 15, FontStyle.Bold)
                newRichTextBox.Size = New Size(Me.Size.Width / 3, Me.Size.Height / 10)
                newRichTextBox.Refresh()
                newRichTextBox.BringToFront()
                newRichTextBox.Show()
            End If
        End Try
        ' After all info getting is finished, call garbage collector to free memory from not needed trash
        ReleaseMemory()
    End Sub
    Private Sub InitMap()
        Dim polygons As Map.CPolygons = MapControl1.Polygons
        MapControl1.AddPolygon(stringToPoints(
            "280,360,310,370,313,405,365,415,385,433,420,500,385,500,358,524,325,540,305,575,273,580,247,566,
            238,491,220,468,166,475,125,447,126,438,175,433,202,435,222,447,253,398
            "), "Hiiumaa", "Hiiu maakond",
                New PointF(299, 471),
                True)
        MapControl1.AddPolygon(stringToPoints("
            260,605,273,604,287,637,301,636,311,628,323,639,335,615,353,619,365,614,405,632,
            418,650,436,651,441,674,461,677,491,706,481,723,450,710,430,724,418,720,415,737,
            427,747,399,757,383,741,383,750,389,762,378,763,373,785,362,785,353,776,
            341,803,313,794,305,804,321,826,304,833,293,820,293,809,281,809,279,824,246,828,
            237,812,229,826,194,829,174,852,174,877,151,935,157,951,109,989,96,985,91,958,
            111,934,118,904,133,898,140,910,151,908,149,891,162,873,160,857,141,859,119,846,
            109,820,95,806,94,814,70,804,52,791,53,777,69,780,65,761,75,758,86,773,
            85,755,99,756,108,748,65,686,82,668,108,671,126,718,139,719,138,689,151,673,
            162,670,163,652,174,657,173,681,190,685,198,665,187,647,195,639,245,635
            "), "Saaremaa", "Saare maakond",
                New PointF(270, 736),
                True)
        MapControl1.AddPolygon(stringToPoints("
            453,582,503,606,499,622,520,651,509,663,475,656,464,666,441,635,434,640,419,631,
            418,614,435,617,443,613,437,586
            "), "Saaremaa", "Saare maakond",,
            False)
        ' RAW! Rework!
        MapControl1.AddPolygon(stringToPoints("
        544,299,612,292,662,348,720,370,710,433,745,505,740,550,720,575,666,650,575,660,560,656,
        525,454,450,440,432,398,555,360
        "), "Läenemaa", "Lääne maakond",
            New PointF(598, 415),
            True)
        MapControl1.AddPolygon(stringToPoints("
        612,292,627,264,701,205,920,115,970,150,1125,130,1110,80,1115,55,1180,55,1200,110,1250,
        260,1195,250,1125,265,1110,270,1100,363,1070,417,1040,366,886,293,710,433,720,370,662,348
        "), "Harjumaa", "Harju maakond",
            New PointF(883, 245),
            True)
        MapControl1.AddPolygon(stringToPoints("
        886,293,1040,366,1070,417,1040,555,965,600,895,555,807,601,720,575,740,550,745,505,710,433
        "), "Raplamaa", "Rapla maakond",
            New PointF(902, 454),
            True)
        MapControl1.AddPolygon(stringToPoints("
        575,660,666,650,720,575,807,601,895,555,965,600,1040,555,1060,570,1060,615,1050,640,990,
        675,970,775,1060,810,990,895,1000,927,860,975,820,1020,800,960,830,818,866,790,790,750,
        734,825,615,772        
        "), "Pärnumaa", "Pärnu maakond",
            New PointF(806, 690),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1060,615,1133,616,1210,575,1200,620,1245,625,1320,690,1330,720,1310,880,1235,870,1160,
        970,1000,927,990,895,1060,810,970,775,990,675,1050,640
        "), "Viljandimaa", "Viljandi maakond",
            New PointF(1153, 755),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1320,690,1619,567,1651,719,1725,722,1715,820,1655,796,1550,805,1465,870,1390,850,1310,880,1330,720
        "), "Tartumaa", "Tartu maakond",
            New PointF(1496, 736),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1160,970,1235,870,1310,880,1390,850,1465,870,1455,960,1400,980,1435,1170,1375,1155
        "), "Valgamaa", "Valga maakond",
            New PointF(1320, 929),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1465,870,1550,805,1655,796,1715,820,1780,920,1790,970,1830,975,1820,1010,1750,1015,
        1660,1010,1690,980,1600,950,1600,980,1455,960
        "), "Põlvamaa", "Põlva maakond",
            New PointF(1615, 899),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1455,960,1600,980,1600,950,1690,980,1660,1010,1750,1015,1695,1185,1560,1130,1480,1195,
        1440,1195,1435,1170,1400,980
        "), "Võrumaa", "Võru maakond",
            New PointF(1576, 1063),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1315,465,1380,470,1475,420,1485,463,1540,469,1550,552,1619,567,1320,690,1245,625,1200,620,1210,575
        "), "Jõgevamaa", "Jõgeva maakond",
            New PointF(1393, 566),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1070,417,1100,363,1110,270,1125,262,1165,305,1265,310,1240,375,1280,380,1315,465,1210,
        575,1133,616,1060,615,1060,570,1040,555
        "), "Järvamaa", "Järva maakond",
            New PointF(1204, 458),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1245,70,1480,135,1530,280,1530,325,1500,410,1475,420,1380,470,1315,465,1280,380,1240,
        375,1265,310,1165,305,1125,265,1195,250,1250,260,1200,110
        "), "Läene-Virumaa", "Lääne-Viru maakond",
            New PointF(1355, 213),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1480,135,1530,160,1780,170,1840,135,1895,180,1820,240,1760,390,1595,410,1540,469,1485,
        463,1475,420,1500,410,1530,325,1530,280
        "), "Ida-Virumaa", "Ida-Viru maakond",
            New PointF(1670, 304),
            True)
        MapControl1.MapUpdate()
    End Sub

    ' Constructor
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
            With currentBtn
                .BackColor = Color.FromArgb(Min(.BackColor.A + 30, 255),
                                            Min(.BackColor.R + 30, 255),
                                            Min(.BackColor.G + 30, 255),
                                            Min(.BackColor.B + 30, 255))
                .ForeColor = customColor
                .IconColor = customColor
                .TextAlign = ContentAlignment.MiddleCenter
                .ImageAlign = ContentAlignment.MiddleRight
                .TextImageRelation = TextImageRelation.TextBeforeImage
            End With
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

    Private Sub OpenChildForm(childForm)
        If (currentChildForm Is Nothing OrElse
            childForm.GetType <> currentChildForm.GetType) Then
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
            CurrentIconLabel.Text = childForm.FormName
            If (oldChildForm IsNot Nothing) Then
                oldChildForm.Dispose()
            End If
        Else
            childForm.Dispose()
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
            MapHide()
        End If
        OpenChildForm(New homeForm)
        Reset()
    End Sub

    Private Sub Reset()
        DisabledBtn()
        leftBorderBtn.Visible = False
        CurrentIcon.IconChar = IconChar.Home
        CurrentIcon.IconColor = Color.Black
        CurrentIconLabel.Text = "Kodu"

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ActivateButton(sender, AppSettings.ButtonColorExit)
        FormClosingHandler()
        Application.Exit()
    End Sub
    Private Sub FormClosingHandler() Handles MyBase.Closing
        SaveLoad.SaveAppSettings()
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        CloseChildForm()
        MapControl1.BringToFront()
        MapShow()
        ActivateButton(sender, AppSettings.ButtonColorMap)
        'StatWin1.Visible = False
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        If MapControl1 IsNot Nothing Then
            MapHide()
        End If
        ActivateButton(sender, AppSettings.ButtonColorStatistics)
        OpenChildForm(New statGraphs)
    End Sub

    Private Sub btnTelegramm_Click(sender As Object, e As EventArgs) Handles btnTelegramm.Click
        ActivateButton(sender, AppSettings.ButtonColorTelegram)

    End Sub

    Private Sub btnExtra2_Click(sender As Object, e As EventArgs) Handles saveStatButton.Click
        ActivateButton(sender, Color.Violet)
        OpenChildForm(New statSave)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If MapControl1 IsNot Nothing Then
            MapHide()
        End If
        ActivateButton(sender, AppSettings.ButtonColorSettings)
        OpenChildForm(New settings)
    End Sub

    Private Sub MapHide()
        MapControl1.Visible = False
        mapDatePicker.Hide()
        mapStatisticsCombobox.Hide()
        mapGradientCheckBox.Hide()
    End Sub
    Private Sub MapShow()
        MapControl1.Visible = True
        If (currentChildForm IsNot Nothing) Then
            Dim oldCurrentChildForm As Form = currentChildForm
            currentChildForm = Nothing
            oldCurrentChildForm.Dispose()
        End If
        mapDatePicker.Show()
        mapStatisticsCombobox.Show()
        mapGradientCheckBox.Show()
    End Sub

    Private Sub CreateLoadingOverlay()
        Dim loading As New loadingControl
        Controls.Add(loading)
        loading.Picture = Image.FromFile(My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Resources\loading.png")
        loading.Location = MapControl1.Location
        loading.Dock = DockStyle.Fill
        loading.Name = "loadingControl"
        loading.Init()
        loading.BringToFront()
        loading.Show()
        Dim newThread As New Threading.Thread(AddressOf loading.StartRotation)
        newThread.IsBackground = True
        newThread.Priority = Threading.ThreadPriority.Highest
        newThread.Start()
        btnMap.Enabled = False
        btnExit.Enabled = False
        saveStatButton.Enabled = False
        btnSettings.Enabled = False
        btnStatistics.Enabled = False
        btnTelegramm.Enabled = False
    End Sub
    Private Sub DeleteLoadingOverlay()
        Dim loading As loadingControl = Controls.Find("loadingControl", False)(0)
        Controls.Remove(loading)
        loading.Dispose()
        btnMap.Enabled = True
        btnExit.Enabled = True
        saveStatButton.Enabled = True
        btnSettings.Enabled = True
        btnStatistics.Enabled = True
        btnTelegramm.Enabled = True
    End Sub

    Private Function stringToPoints(input As String) As Point()
        Dim pointsList As New List(Of Point)
        Dim splitted = input.Split(",")
        Dim i As Integer = 0
        Dim c As Integer = 0
        Dim points(splitted.Length / 2 - 1) As Point
        If (splitted.Length = 1) Then
            Return points
        End If
        While (i < splitted.Length)
            points(c) = New Point(splitted(i), splitted(i + 1))
            c = c + 1
            i = i + 2
        End While
        Return points
    End Function

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
                       covidVact.AsNew.Where("County", polygonKey).Where("Type", "FullyVaccinated"),
                       New KeyValuePair(Of String, String)(polygonKey, polygonName))
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
            Dim CovidTestEdited As CStatList = covidTest.AsNew.Where("County", polygonKey).WhereDate(_popupDate)
            Dim CovidSickEdited As CStatList = covidSick.AsNew.Where("County", polygonKey).WhereDate(_popupDate)
            Dim CovidVactEdited As CStatList = covidVact.AsNew.Where("County", polygonKey).WhereDate(_popupDate).
                Where("Type", "FullyVaccinated")
            If (CovidTestEdited.Count > 0 And
                CovidSickEdited.Count > 0 And
                CovidVactEdited.Count > 0) Then
                popup.allTest.Text = CovidTestEdited.GetField(CovidTestEdited.Count - 1, "TotalTests")
                popup.allSick.Text = CovidSickEdited.GetField(CovidSickEdited.Count - 1, "Sick")
                popup.allVact.Text = CovidVactEdited.GetField(CovidVactEdited.Count - 1, "TotalCount")
            Else
                CovidTestEdited = covidTest.AsNew.Where("County", polygonKey)
                CovidSickEdited = covidSick.AsNew.Where("County", polygonKey)
                CovidVactEdited = covidVact.AsNew.Where("County", polygonKey)
                popup.allTest.Text = CovidTestEdited.GetField(CovidTestEdited.Count - 1, "TotalTests")
                popup.allSick.Text = CovidSickEdited.GetField(CovidSickEdited.Count - 1, "Sick")
                popup.allVact.Text = CovidVactEdited.GetField(CovidVactEdited.Count - 1, "TotalCount")
            End If
            popup.countyName.Text = polygonName
        End If
    End Sub

    Private Sub ColorSettingsAppliedHandler()
        MapControl1.DefBgCenterColor = MainColor
        MapControl1.DefBgSideColor = SecondaryColor
        MapControl1.MapUpdate()
        PanelBar.BackColor = SecondaryColor
        PanelDesktop.BackColor = SecondaryColor
        PanelLogo.BackColor = SecondaryColor
        MenuPanel.BackColor = SecondaryColor
        BoxLogo.BackColor = SecondaryColor
        btnExit.BackColor = SecondaryColor
        saveStatButton.BackColor = SecondaryColor
        btnMap.BackColor = SecondaryColor
        btnSettings.BackColor = SecondaryColor
        btnStatistics.BackColor = SecondaryColor
        btnTelegramm.BackColor = SecondaryColor
        leftBorderBtn.BackColor = SecondaryColor
        _lastButtonColor = SecondaryColor
    End Sub

    Private Sub setProgress(newStatus As Integer)
        Dim loading As loadingControl = Controls.Find("loadingControl", False)(0)
        loading.Status = newStatus
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

    Private Function DateTimeToString(dateTimeObject As DateTime)
        Return String.Join("-", dateTimeObject.ToString.Split(" ")(0).Split(".").Reverse)
    End Function

    Private Sub GarbageTimer_Tick(sender As Object, e As EventArgs) Handles GarbageTimer.Tick
        ReleaseMemory()
    End Sub

    Private Sub mapRedrawHandler(sender As Object, e As EventArgs) Handles mapGradientCheckBox.CheckedChanged, mapDatePicker.CloseUp, mapStatisticsCombobox.SelectedIndexChanged
        If (mapGradientCheckBox.Checked And mapStatisticsCombobox.Text <> Nothing) Then
            _popupDate = DateTimeToString(mapDatePicker.Value)
            Dim statList() As IStatList = {covidVact, covidSick, covidTest}
            Dim valueField() As String = {"DailyCount", "Sick", "DailyTests"}
            Dim keyValue() As KeyValuePair(Of String, Integer) = {
            New KeyValuePair(Of String, Integer)("Harju maakond", -1),
            New KeyValuePair(Of String, Integer)("Ida-Viru maakond", -1),
            New KeyValuePair(Of String, Integer)("Lääne-Viru maakond", -1),
            New KeyValuePair(Of String, Integer)("Järva maakond", -1),
            New KeyValuePair(Of String, Integer)("Jõgeva maakond", -1),
            New KeyValuePair(Of String, Integer)("Võru maakond", -1),
            New KeyValuePair(Of String, Integer)("Põlva maakond", -1),
            New KeyValuePair(Of String, Integer)("Valga maakond", -1),
            New KeyValuePair(Of String, Integer)("Tartu maakond", -1),
            New KeyValuePair(Of String, Integer)("Pärnu maakond", -1),
            New KeyValuePair(Of String, Integer)("Rapla maakond", -1),
            New KeyValuePair(Of String, Integer)("Lääne maakond", -1),
            New KeyValuePair(Of String, Integer)("Saare maakond", -1),
            New KeyValuePair(Of String, Integer)("Hiiu maakond", -1),
            New KeyValuePair(Of String, Integer)("Viljandi maakond", -1)}
            Dim k = mapStatisticsCombobox.SelectedIndex
            For i As Integer = 0 To keyValue.Length - 1
                Dim countyStat As IStatList = statList(mapStatisticsCombobox.SelectedIndex).AsNew.Where("County", keyValue(i).Key).
                    WhereDate(_popupDate, "<=")
                If (countyStat.Count <> 0) Then
                    keyValue(i) = New KeyValuePair(Of String, Integer)(keyValue(i).Key,
                        countyStat.GetField(countyStat.Count - 1, valueField(mapStatisticsCombobox.SelectedIndex)))
                End If
            Next
            MapControl1.MapDrawLevelGradient(keyValue, {
                CGradient.BrightBlue,
                CGradient.Green,
                CGradient.BrightGreen,
                CGradient.Yellow,
                CGradient.Orange,
                CGradient.Red
                }, CGradient.Gray)
        Else
            _popupDate = DateTimeToString(mapDatePicker.Value)
            MapControl1.MapDrawAllGradient(CGradient.Green)
            MapControl1.Update()
        End If
    End Sub
End Class