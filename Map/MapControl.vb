' FILENAME: Map.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 25.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: GUI

Imports System.Drawing
Imports System.Math
Public Class MapControl
    Private polygons As New CPolygons(New Size(1920, 1200))
    Public Event Clicked(clickPosition As Point, polygonName As String)
    Private _mapFont As New Font("Times New Roman", 50, FontStyle.Bold Or FontStyle.Italic)
    Private _drawNames As Boolean = True
    Private _defBorderPen As Pen = New Pen(Brushes.Black, 4)
    Private _defGradient As Gradient = (New Gradient()).Green
    Private _defPolygonBackgroundBrush As Brush = Brushes.Gray
    Private _simpleDraw As Boolean = False
    Private _fillPolygons As Boolean = True
    Private _defBackgroundImage As Image = Nothing

    Public ReadOnly Property DefBackgroundImage As Image
        Get
            Return _defBackgroundImage
        End Get
    End Property
    Public Property DefBorderPen As Pen
        Get
            Return _defBorderPen
        End Get
        Set(value As Pen)
            _defBorderPen = value
        End Set
    End Property
    Public Property MapFont As Font
        Get
            Return _mapFont
        End Get
        Set(value As Font)
            _mapFont = value
        End Set
    End Property
    Public Property DrawNames As Boolean
        Get
            Return _drawNames
        End Get
        Set(value As Boolean)
            _drawNames = value
        End Set
    End Property
    Public Property DefGradient As Gradient
        Get
            Return _defGradient
        End Get
        Set(value As Gradient)
            _defGradient = value
        End Set
    End Property
    Public Property DefPolygonBackgroundBrush As Brush
        Get
            Return _defPolygonBackgroundBrush
        End Get
        Set(value As Brush)
            _defPolygonBackgroundBrush = value
        End Set
    End Property
    Public ReadOnly Property MapPolygons As CPolygons
        Get
            Return polygons
        End Get
    End Property
    Public Property SimpleDraw As Boolean
        Get
            Return _simpleDraw
        End Get
        Set(value As Boolean)
            _simpleDraw = value
        End Set
    End Property
    Public Property FillPolygons As Boolean
        Get
            Return _fillPolygons
        End Get
        Set(value As Boolean)
            _fillPolygons = value
        End Set
    End Property
    Private Sub WhenLoaded() Handles Me.Load
        mapPictureBox.Size = Me.Size
        If (_defBackgroundImage IsNot Nothing) Then
            mapPictureBox.Image = _defBackgroundImage
        End If
        polygons.Add(New CPolygon(stringToPoints(
            "280,360,310,370,313,405,365,415,385,433,420,500,385,500,358,524,325,540,305,575,273,580,247,566,
            238,491,220,468,166,475,125,447,126,438,175,433,202,435,222,447,253,398
            "), mapPictureBox, "Hiiumaa", "Hiiu maakond",
                _defGradient.CenterColor,
                _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(299, 471)))
        polygons.Add(New CPolygon(stringToPoints("
            260,605,273,604,287,637,301,636,311,628,323,639,335,615,353,619,365,614,405,632,
            418,650,436,651,441,674,461,677,491,706,481,723,450,710,430,724,418,720,415,737,
            427,747,399,757,383,741,383,750,389,762,378,763,373,785,362,785,353,776,
            341,803,313,794,305,804,321,826,304,833,293,820,293,809,281,809,279,824,246,828,
            237,812,229,826,194,829,174,852,174,877,151,935,157,951,109,989,96,985,91,958,
            111,934,118,904,133,898,140,910,151,908,149,891,162,873,160,857,141,859,119,846,
            109,820,95,806,94,814,70,804,52,791,53,777,69,780,65,761,75,758,86,773,
            85,755,99,756,108,748,65,686,82,668,108,671,126,718,139,719,138,689,151,673,
            162,670,163,652,174,657,173,681,190,685,198,665,187,647,195,639,245,635
            "), mapPictureBox, "Saaremaa", "Saare maakond",
                _defGradient.CenterColor,
                _defGradient.SideColor,, _defBorderPen, New PointF(270, 736)))
        polygons.Add(New CPolygon(stringToPoints("
            453,582,503,606,499,622,520,651,509,663,475,656,464,666,441,635,434,640,419,631,
            418,614,435,617,443,613,437,586
            "), mapPictureBox, "Saaremaa", "Saare maakond",
                _defGradient.CenterColor,
                _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen,, False))
        ' RAW! Rework!
        polygons.Add(New CPolygon(stringToPoints("
        544,299,612,292,662,348,720,370,710,433,745,505,740,550,720,575,666,650,575,660,560,656,
        525,454,450,440,432,398,555,360
        "), mapPictureBox, "Läenemaa", "Lääne maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(598, 415)))
        polygons.Add(New CPolygon(stringToPoints("
        612,292,627,264,701,205,920,115,970,150,1125,130,1110,80,1115,55,1180,55,1200,110,1250,
        260,1195,250,1125,265,1110,270,1100,363,1070,417,1040,366,886,293,710,433,720,370,662,348
        "), mapPictureBox, "Harjumaa", "Harju maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(883, 245)))
        polygons.Add(New CPolygon(stringToPoints("
        886,293,1040,366,1070,417,1040,555,965,600,895,555,807,601,720,575,740,550,745,505,710,433
        "), mapPictureBox, "Raplamaa", "Rapla maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(902, 454)))
        polygons.Add(New CPolygon(stringToPoints("
        575,660,666,650,720,575,807,601,895,555,965,600,1040,555,1060,570,1060,615,1050,640,990,
        675,970,775,1060,810,990,895,1000,927,860,975,820,1020,800,960,830,818,866,790,790,750,
        734,825,615,772        
        "), mapPictureBox, "Pärnumaa", "Pärnu maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(806, 690)))
        polygons.Add(New CPolygon(stringToPoints("
        1060,615,1133,616,1210,575,1200,620,1245,625,1320,690,1330,720,1310,880,1235,870,1160,
        970,1000,927,990,895,1060,810,970,775,990,675,1050,640
        "), mapPictureBox, "Viljandimaa", "Viljandi maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1153, 755)))
        polygons.Add(New CPolygon(stringToPoints("
        1320,690,1619,567,1651,719,1725,722,1715,820,1655,796,1550,805,1465,870,1390,850,1310,880,1330,720
        "), mapPictureBox, "Tartumaa", "Tartu maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1496, 736)))
        polygons.Add(New CPolygon(stringToPoints("
        1160,970,1235,870,1310,880,1390,850,1465,870,1455,960,1400,980,1435,1170,1375,1155
        "), mapPictureBox, "Valgamaa", "Valga maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1320, 929)))
        polygons.Add(New CPolygon(stringToPoints("
        1465,870,1550,805,1655,796,1715,820,1780,920,1790,970,1830,975,1820,1010,1750,1015,
        1660,1010,1690,980,1600,950,1600,980,1455,960
        "), mapPictureBox, "Põlvamaa", "Põlva maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1615, 899)))
        polygons.Add(New CPolygon(stringToPoints("
        1455,960,1600,980,1600,950,1690,980,1660,1010,1750,1015,1695,1185,1560,1130,1480,1195,
        1440,1195,1435,1170,1400,980
        "), mapPictureBox, "Võrumaa", "Võru maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1576, 1063)))
        polygons.Add(New CPolygon(stringToPoints("
        1315,465,1380,470,1475,420,1485,463,1540,469,1550,552,1619,567,1320,690,1245,625,1200,620,1210,575
        "), mapPictureBox, "Jõgevamaa", "Jõgeva maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1393, 566)))
        polygons.Add(New CPolygon(stringToPoints("
        1070,417,1100,363,1110,270,1125,262,1165,305,1265,310,1240,375,1280,380,1315,465,1210,
        575,1133,616,1060,615,1060,570,1040,555
        "), mapPictureBox, "Järvamaa", "Järva maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1204, 458)))
        polygons.Add(New CPolygon(stringToPoints("
        1245,70,1480,135,1530,280,1530,325,1500,410,1475,420,1380,470,1315,465,1280,380,1240,
        375,1265,310,1165,305,1125,265,1195,250,1250,260,1200,110
        "), mapPictureBox, "Läene-Virumaa", "Lääne-Viru maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1355, 213)))
        polygons.Add(New CPolygon(stringToPoints("
        1480,135,1530,160,1780,170,1840,135,1895,180,1820,240,1760,390,1595,410,1540,469,1485,
        463,1475,420,1500,410,1530,325,1530,280
        "), mapPictureBox, "Ida-Virumaa", "Ida-Viru maakond",
            _defGradient.CenterColor,
            _defGradient.SideColor, _defPolygonBackgroundBrush, _defBorderPen, New PointF(1670, 304)))

        polygons.DrawAll(mapPictureBox, _fillPolygons,,, _mapFont, _drawNames, _simpleDraw, _defBackgroundImage)
    End Sub
    Private Sub WhenResized() Handles Me.Resize
        mapPictureBox.Size = Me.Size
    End Sub
    Public Sub _Update()
        polygons.DrawAll(mapPictureBox, _fillPolygons,,, _mapFont, _drawNames, _simpleDraw, _defBackgroundImage)
    End Sub
    Public Sub _UpdatePolygonsWhereName(aimName As String)
        For i As Integer = 0 To polygons.Count - 1
            If (polygons(i).Name = aimName) Then
                polygons(i).Draw(mapPictureBox, _fillPolygons,,,, _simpleDraw)
            End If
        Next
        For i As Integer = 0 To polygons.Count - 1
            polygons(i).DrawPolygonName(mapPictureBox, _mapFont)
        Next
    End Sub
    Public Sub _SetAllPolygonsToDefault(Optional setBorderPen As Boolean = True,
                                        Optional setGradientBrushCenterColor As Boolean = True,
                                        Optional setGradientBrushSideColor As Boolean = True)
        For i As Integer = 0 To polygons.Count - 1
            If (setBorderPen) Then
                polygons(i).BorderPen = _defBorderPen
            End If
            If (setGradientBrushCenterColor) Then
                polygons(i).GradientBrushCenterColor = _defGradient.CenterColor
            End If
            If (setGradientBrushSideColor) Then
                polygons(i).GradientBrushSideColor = _defGradient.SideColor
            End If
        Next
    End Sub
    Public Sub _DrawAllColor(color As Color)
        polygons.DrawAll(mapPictureBox, _fillPolygons, color,, _mapFont, _drawNames, _simpleDraw, _defBackgroundImage)
    End Sub
    Public Sub _DrawAllGradient(gradient As Gradient)
        polygons.DrawAll(mapPictureBox, _fillPolygons, gradient.CenterColor, gradient.SideColor, _mapFont, DrawNames, _simpleDraw, _defBackgroundImage)
    End Sub
    Public Sub _DrawLevelGradient(pair() As KeyValuePair(Of String, Integer),
                             levelGradients As Array,
                             Optional gradientDefault As Gradient = Nothing)
        Dim maxValue As Integer = Integer.MinValue
        Dim minValue As Integer = Integer.MaxValue
        If (gradientDefault IsNot Nothing) Then
            For i As Integer = 0 To polygons.Count - 1
                polygons(i).GradientBrushCenterColor = gradientDefault.CenterColor
                polygons(i).GradientBrushSideColor = gradientDefault.SideColor
            Next
        End If
        For Each item As KeyValuePair(Of String, Integer) In pair
            If (item.Value > maxValue) Then
                maxValue = item.Value
            End If
            If (item.Value < minValue) Then
                minValue = item.Value
            End If
        Next
        If (levelGradients.Length <> 0) Then
            For Each item As KeyValuePair(Of String, Integer) In pair
                Dim n = Min(Round(((minValue + item.Value) / maxValue) * levelGradients.Length), levelGradients.Length - 1)
                polygons.SetGradientWhereKey(item.Key, levelGradients(n))
            Next
        End If
        polygons.DrawAll(mapPictureBox, _fillPolygons,,, _mapFont, _drawNames, _simpleDraw, _defBackgroundImage)
    End Sub
    Private Sub WhenPictureBoxClicked(sender As PictureBox, e As MouseEventArgs) Handles mapPictureBox.Click
        Dim clickPoint As New Point(
        e.X * (mapPictureBox.Image.Width / mapPictureBox.Width),
        e.Y * (mapPictureBox.Image.Height / mapPictureBox.Height))
        Dim clickedPolygonName As String = Nothing
        For i As Integer = 0 To polygons.Count - 1
            If (polygons(i).IsPointInside(clickPoint)) Then
                clickedPolygonName = polygons(i).Name
                Exit For
            End If
        Next
        RaiseEvent Clicked(clickPoint, clickedPolygonName)
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
End Class
