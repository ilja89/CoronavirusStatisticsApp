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
Imports TelegramBotLib

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
    Public covidFullVact As IStatList
    Public covidSick As IStatList
    Public covidTestPosGen As IStatList
    Public covidVactGen As IStatList
    Public covidSickGen As IStatList
    Public covidTestPositiveCounty As IStatList

    Private _lastButtonColor As Color = Color.DarkGray
    Private mouseCoords As Point = New Point(0, 0)
    Private _cachePath As String = AppSettings.CachePath
    Private _threads As New List(Of Threading.Thread)
    Private _popupDate As String = DateTimeToString(DateTime.Now)
    Private _statListForMapDateTracker

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
            If (Await _saveLoad.UpdateData(_cachePath, Sub(progressValue As Integer) setProgress(progressValue))) Then
DataUpdate:     setProgress(60)
                covidTest = request.GetTestStatCounty(, False)
                setProgress(70)
                covidVact = request.GetVaccinationStatByCounty
                covidFullVact = covidVact.AsNew.Where("Type", "FullyVaccinated")
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
        Dim polygons As Map.IPolygons = MapControl1.Polygons
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
        MapControl1.AddPolygon(stringToPoints("600,640,559,622,557,577,570,532,603,520,598,496,570,505,545,507,539,490,551,477,541,434,536,416,577,402,553,386,538,369,538,335,563,324,557,262,607,243,628,249,621,264,621,264,633,277,653,292,675,305,689,307,705,307,728,320,734,337,728,356,719,389,727,419,734,438,736,466,730,489,724,502,721,524,736,537,739,554,710,562,693,565,695,580,693,599,671,593,671,608,677,625,663,625,631,637,615,635
        "), "Läänemaa", "Lääne maakond",
            New PointF(598, 415),
            True)
        MapControl1.AddPolygon(stringToPoints("521,388,500,391,483,389,468,397,455,393,449,371,453,352,471,356,486,361,509,358,520,373
        "), "Läänemaa", "Lääne maakond",
            New PointF(598, 415),
            False)
        MapControl1.AddPolygon(stringToPoints("
            653,215,639,225,621,264,633,277,653,292,675,305,689,307,705,307,728,320,734,337,728,356,719,389,737,373,754,354,
            773,365,787,358,799,331,823,326,841,322,858,320,863,288,869,262,891,256,918,256,940,253,956,253,967,279,973,294,
            995,298,1005,315,1021,322,1039,324,1045,337,1060,359,1077,371,1094,361,1095,348,1100,324,1115,320,1116,301,1116,
            273,1128,256,1125,238,1121,219,1144,221,1162,223,1198,208,1225,202,1240,206,1236,183,1230,146,1218,118,1212,86,
            1202,67,1198,47,1196,34,1190,13,1177,11,1127,7,985,26,911,52,846,52,715,157,690,174,660,180
        "), "Harjumaa", "Harju maakond",
            New PointF(883, 200),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1042,481,1044,519,1021,534,1005,543,988,547,977,560,959,554,940,532,940,532,902,519,894,534,866,
            545,857,530,835,547,828,562,802,565,739,554,736,537,721,524,724,502,730,489,736,466,734,438,727,419,
            719,389,737,373,754,354,773,365,773,365,773,365,799,331,823,326,841,322,858,320,863,288,869,262,891,256,
            918,256,940,253,940,253,940,253,956,253,967,279,973,294,995,298,1005,315,1005,315,1021,322,1039,324,1045,
            337,1060,359,1077,371,1073,397,1070,419,1054,431,1056,447,1060,461
        "), "Raplamaa", "Rapla maakond",
            New PointF(902, 454),
            True)
        MapControl1.AddPolygon(stringToPoints("775,773,749,784,733,803,721,788,710,768,696,760,677,751,657,
            743,653,728,644,741,631,732,619,710,612,681,610,655,600,640,615,635,631,637,663,
            625,677,625,671,608,671,593,693,599,695,580,693,565,710,562,739,554,802,565,828,562,835,547,857,
            530,866,545,894,534,902,519,940,532,950,517,959,554,977,560,988,547,1005,543,1021,534,1048,537,1065,535,
            1066,556,1059,580,1048,607,1027,623,1003,650,989,681,985,717,983,743,992,756,1017,758,1036,769,1059,784,1059,799,
            1062,820,1039,820,1023,842,1014,863,1000,876,1000,897,997,912,989,927,949,938,918,942,903,959,882,962,863,957,843,970,828,1000,807,
            1000,819,966,829,929,846,902,844,871,841,841,847,807,864,784,875,764,872,747,852,728,831,715,814,713,798,717,783,730,784,749        
        "), "Pärnumaa", "Pärnu maakond",
            New PointF(806, 690),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1059,580,1082,593,1106,590,1130,588,1153,577,1180,563,1210,560,1210,575,1224,601,1257,605,1278,625,1286,650,1311,659,1319,676,1319,
            700,1329,719,1329,751,1325,777,1325,790,1319,811,1314,842,1319,859,1292,854,1273,861,1252,842,1239,841,1234,863,1213,884,1201,904,1183,904,1169,
            944,1139,944,1127,925,1110,917,1095,904,1079,885,1071,910,1080,934,1056,930,1051,908,1047,889,997,912,1000,897,1000,876,1014,863,1023,842,1039,
            820,1062,820,1059,799,1059,784,1036,769,1017,758,992,756,983,743,985,717,989,681,1003,650,1027,623,1048,607
        "), "Viljandimaa", "Viljandi maakond",
            New PointF(1160, 730),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1319,859,1314,842,1319,811,1325,790,1325,777,1329,751,1329,719,1319,700,1319,676,1337,659,1363,642,1381,631,1412,637,
            1426,625,1455,637,1474,625,1492,614,1523,612,1523,588,1541,573,1560,578,1573,592,1589,578,1582,562,1595,547,1609,541,
            1618,565,1630,590,1639,618,1639,648,1638,670,1650,691,1665,700,1671,685,1687,693,1696,710,1696,736,1696,754,1705,771,
            1709,784,1707,798,1684,792,1671,786,1656,773,1633,769,1616,769,1603,781,1591,768,1586,792,1570,790,1554,779,1539,790,1535,
            809,1508,816,1492,816,1476,833,1467,846,1447,831,1428,833,1408,833,1385,842,1372,846,1358,852,1338,854
        "), "Tartumaa", "Tartu maakond",
            New PointF(1496, 736),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1218,972,1202,977,1184,968,1169,944,1183,
            904,1183,904,1201,904,1213,884,1234,863,1234,
            863,1239,841,1252,842,1273,861,1292,854,1319,
            859,1338,854,1358,852,1372,846,1385,842,1408,833,
            1428,833,1447,831,1467,846,1458,872,1452,887,1458,
            910,1455,925,1456,944,1440,944,1423,947,1406,947,1400,
            964,1402,979,1406,1000,1409,1018,1415,1035,1435,1041,1432,
            1061,1429,1086,1432,1108,1425,1123,1432,1144,1421,1159,1406,
            1159,1385,1149,1375,1131,1366,1114,1352,1099,1340,1078,1304,1048,
            1308,1024,1310,998,1293,1002,1258,1002,1236,996
        "), "Valgamaa", "Valga maakond",
            New PointF(1320, 929),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1500,949,1479,955,1456,944,1455,925,1458,910,1452,887,1458,872,1476,833,1476,833,1492,816,1508,816,1535,809,1539,790,1554,779,1570,790,1586,792,
            1591,768,1603,781,1616,769,1633,769,1656,773,1671,786,1684,792,1709,784,1719,814,1727,842,1742,863,1752,889,1761,906,1778,912,1780,934,1807,964,1823,970,1816,
            992,1802,994,1766,998,1749,1000,1712,1000,1696,1000,1683,1000,1675,983,1678,964,1660,966,1625,953,1618,934,1601,938,1600,957,1586,960,1570,944,1559,957,1544,957,
            1527,957
        "), "Põlvamaa", "Põlva maakond",
            New PointF(1615, 899),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1482,1185,1468,1187,1450,1181,1432,1144,1425,1123,1432,1108,1429,1086,1432,1061,1435,1041,1415,1035,1409,
            1018,1406,1000,1402,979,1400,964,1406,947,1423,947,1440,944,1456,944,1479,955,1500,949,1527,957,1544,957,1559,
            957,1570,944,1586,960,1600,957,1601,938,1618,934,1625,953,1660,966,1678,964,1675,983,1675,983,1683,1000,1696,1000,
            1712,1000,1749,1000,1746,1020,1728,1030,1742,1063,1722,1065,1709,1082,1696,1091,1701,1110,1707,1123,1692,1136,
            1684,1151,1693,1172,1675,1166,1654,1159,1616,1149,1588,1134,1565,1123,1550,1146,1524,1146,1492,1161
        "), "Võrumaa", "Võru maakond",
            New PointF(1576, 1063),
            True)
        MapControl1.AddPolygon(stringToPoints("
        1573,490,1609,541,1595,547,1582,562,1589,578,1573,592,1560,578,1541,573,1523,588,1523,612,1492,614,1474,625,1455,637,
        1426,625,1412,637,1381,631,1363,642,1337,659,1319,676,1311,659,1286,650,1278,625,1257,605,1224,601,1224,601,1210,575,
        1210,575,1210,560,1210,560,1216,537,1231,519,1249,502,1260,517,1267,498,1272,485,1292,466,1319,457,1319,438,1352,429,
        1367,423,1378,446,1400,427,1411,414,1417,401,1446,395,1471,391,1486,417,1499,429,1523,423,1538,432,1542,451,1547,481
        "), "Jõgevamaa", "Jõgeva maakond",
            New PointF(1393, 550),
            True)
        MapControl1.AddPolygon(stringToPoints("1125,238,1165,264,1195,256,1224,262,1245,262,1264,273,1254,290,1246,307,1246,344,1264,343,1286,346,1286,
            359,1308,374,1320,397,1319,438,1319,457,1292,466,1272,485,1267,498,1260,517,1249,502,1231,519,1216,537,1210,560,1180,563,1153,577,1130,588,
            1106,590,1082,593,1059,580,1066,556,1065,535,1048,537,1021,534,1044,519,1042,481,1060,461,1056,447,1054,431,1070,419,1073,397,1077,371,1094,
            361,1095,348,1100,324,1115,320,1116,301,1116,273,1128,256
        "), "Järvamaa", "Järva maakond",
            New PointF(1204, 458),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1317,47,1278,39,1270,24,1257,24,1258,49,1240,49,1225,56,1212,86,1218,118,1230,146,
            1236,183,1240,206,1225,202,1198,208,1144,221,1144,221,1121,219,1125,238,1165,264,1195,
            256,1224,262,1245,262,1264,273,1254,290,1246,307,1246,344,1264,343,1286,346,1286,359,1308,
            374,1320,397,1319,438,1352,429,1367,423,1378,446,1400,427,1411,414,1417,401,1446,395,1471,391,
            1488,373,1500,337,1500,301,1529,273,1529,247,1505,223,1488,230,1474,217,1477,197,1492,170,1471,167,
            1467,146,1482,127,1486,101,1476,75,1452,67,1438,60,1431,77,1399,82,1375,62
        "), "Lääne-Virumaa", "Lääne-Viru maakond",
            New PointF(1355, 213),
            True)
        MapControl1.AddPolygon(stringToPoints("
            1571,389,1547,481,1542,451,1538,432,1523,423,1499,429,1486,417,1471,391,1488,
            373,1500,337,1500,301,1529,273,1529,247,1505,223,1488,230,1474,217,1477,197,1492,
            170,1471,167,1467,146,1482,127,1486,101,1486,101,1488,88,1505,101,1515,114,1560,120,
            1609,120,1654,107,1686,114,1716,120,1754,120,1786,135,1811,124,1832,103,1852,92,1861,107,
            1881,122,1879,137,1869,155,1866,172,1838,172,1817,193,1807,210,1801,243,1789,266,1783,292,1775,
            320,1766,333,1766,348,1751,344,1709,341,1669,343,1642,352,1606,361,1588,378
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
        _saveLoad.SaveAppSettings()
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        CloseChildForm()
        MapControl1.BringToFront()
        MapShow()
        ActivateButton(sender, AppSettings.ButtonColorMap)
        dataUpdateTimer_Tick()
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
        If MapControl1 IsNot Nothing Then
            MapHide()
        End If
        OpenChildForm(New telegramSettings)
    End Sub

    Private Sub saveStatButton_Click(sender As Object, e As EventArgs) Handles saveStatButton.Click
        If MapControl1 IsNot Nothing Then
            MapHide()
        End If
        ActivateButton(sender, AppSettings.ButtonColorSaveStat)
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
        mapDateTrackBar.Hide()
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
        mapDateTrackBar.Show()
    End Sub

    Private Sub CreateLoadingOverlay()
        Dim loading As New loadingControl
        Controls.Add(loading)
        loading.Picture = Image.FromFile(AppSettings.GetAppPath + "Resources\loading.png")
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
            Dim CovidTestEdited As IStatList = covidTest.AsNew.Where("County", polygonKey).WhereDate(_popupDate)
            Dim CovidSickEdited As IStatList = covidSick.AsNew.Where("County", polygonKey).WhereDate(_popupDate)
            Dim CovidVactEdited As IStatList = covidVact.AsNew.Where("County", polygonKey).WhereDate(_popupDate).
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

    Private Sub SelectedItemChanged() Handles mapStatisticsCombobox.SelectedIndexChanged
        Dim statList As IStatList = {covidFullVact, covidSick, covidTest}(mapStatisticsCombobox.SelectedIndex)
        _statListForMapDateTracker = statList.AsNew.Where("County", "Harju maakond")
        mapDateTrackBar.Enabled = True
        mapDateTrackBar.Minimum = 0
        mapDateTrackBar.Maximum = _statListForMapDateTracker.Count - 1
        mapRedrawHandler()
    End Sub

    Private Sub mapDateTrackBar_Scroll() Handles mapDateTrackBar.MouseClick
        If (mapStatisticsCombobox.SelectedIndex >= 0) Then
            Dim datePieces() As String = _statListForMapDateTracker.GetField(mapDateTrackBar.Value, "Date").Split("-")
            mapDatePicker.Value = New DateTime(datePieces(0), datePieces(1), datePieces(2))
            mapRedrawHandler()
        End If
    End Sub

    Private Sub mapDatePicker_CloseUp() Handles mapDatePicker.CloseUp
        Dim statList As IStatList = {covidFullVact, covidSick, covidTest}(mapStatisticsCombobox.SelectedIndex)
        Dim dateString As String = DateTimeToString(mapDatePicker.Value)
        mapDateTrackBar.Value = _statListForMapDateTracker.GetIndexOfFirstItemWhereDate(dateString, ">=")
        mapRedrawHandler()
    End Sub

    Private Sub mapRedrawHandler() Handles mapGradientCheckBox.CheckedChanged
        If (mapGradientCheckBox.Checked And mapStatisticsCombobox.Text <> Nothing) Then
            _popupDate = DateTimeToString(mapDatePicker.Value)
            Dim statList() As IStatList = {covidFullVact, covidSick, covidTest}
            Dim valueField() As String = {"DailyCount", "Sick", "DailyTests"}
            Dim keyValue() As KeyValuePair(Of String, Double) = {
            New KeyValuePair(Of String, Double)("Harju maakond", -1),
            New KeyValuePair(Of String, Double)("Ida-Viru maakond", -1),
            New KeyValuePair(Of String, Double)("Lääne-Viru maakond", -1),
            New KeyValuePair(Of String, Double)("Järva maakond", -1),
            New KeyValuePair(Of String, Double)("Jõgeva maakond", -1),
            New KeyValuePair(Of String, Double)("Võru maakond", -1),
            New KeyValuePair(Of String, Double)("Põlva maakond", -1),
            New KeyValuePair(Of String, Double)("Valga maakond", -1),
            New KeyValuePair(Of String, Double)("Tartu maakond", -1),
            New KeyValuePair(Of String, Double)("Pärnu maakond", -1),
            New KeyValuePair(Of String, Double)("Rapla maakond", -1),
            New KeyValuePair(Of String, Double)("Lääne maakond", -1),
            New KeyValuePair(Of String, Double)("Saare maakond", -1),
            New KeyValuePair(Of String, Double)("Hiiu maakond", -1),
            New KeyValuePair(Of String, Double)("Viljandi maakond", -1)}
            Dim k = mapStatisticsCombobox.SelectedIndex
            For i As Integer = 0 To keyValue.Length - 1
                Dim countyStat As IStatList = statList(mapStatisticsCombobox.SelectedIndex).AsNew.Where("County", keyValue(i).Key).
                    WhereDate(_popupDate, "<=")
                If (countyStat.Count <> 0) Then
                    keyValue(i) = New KeyValuePair(Of String, Double)(keyValue(i).Key,
                        countyStat.GetField(countyStat.Count - 1, valueField(mapStatisticsCombobox.SelectedIndex)) /
                        AppConstants.GetPopulationByCountyName(keyValue(i).Key))
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

    Private Sub dataUpdateTimer_Tick() Handles dataUpdateTimer.Tick
        Try
            Dim saveLoadInstance As IStatSaveLoad = New CStatSaveLoad
            Dim lastUpdateDate As Date = saveLoadInstance.LoadFrom(AppSettings.CachePath, "lastCheckDate")
            If (Not saveLoadInstance.IsUpToDate(lastUpdateDate)) Then
                If (AppSettings.TelegramBotEnabled = True) Then
                    Dim telegramBot As CTelegramBot = New CTelegramBot("NewBot", AppSettings.TelegramBotToken, AppSettings.TelegramBotChatID)
                    telegramBot.SendTelegramMessage("Application statistics data is updated")
                End If
                saveLoadInstance.UpdateData(AppSettings.CachePath)
            End If
        Catch
            IO.Directory.Delete(AppSettings.AppSettingsCachePath)
        End Try
    End Sub
End Class