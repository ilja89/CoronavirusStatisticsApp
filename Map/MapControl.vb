' FILENAME: Map.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 04.04.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: GUI

Imports System.Drawing
Imports System.Math
''' <summary>
''' Provides interactive Estonia map with separate counties.
''' </summary>
Public Class MapControl
    Private _polygons As New CPolygons(New Size(1920, 1200))
    Public Event Clicked(clickPosition As Point, polygonName As String, polygonKey As String)
    Private _mapFont As New Font("Times New Roman", 50, FontStyle.Bold Or FontStyle.Italic)
    Private _drawNames As Boolean = True
    Private _defBorderPen As Pen = New Pen(Brushes.Black, 4)
    Private _defGradient As CGradient = CGradient.Green
    Private _defPolygonBackgroundBrush As Brush = Brushes.Gray
    Private _simplePolygonsDraw As Boolean = False
    Private _fillPolygons As Boolean = True
    Private _simpleBackgroundDraw As Boolean = False
    Private _lastHoveredPolygonKey As String = Nothing
    Private _baseImage As Image

    Public Property Polygons As CPolygons
        Get
            Return _polygons
        End Get
        Set(value As CPolygons)
            _polygons = value
        End Set
    End Property

    Public Property PictureBoxImage As Image
        Get
            Return mapPictureBox.Image
        End Get
        Set(value As Image)
            mapPictureBox.Image = value
        End Set
    End Property

    ''' <summary>
    ''' Default map background image.<br/>
    ''' If empty, map will automatically draw background using gradient or single color.
    ''' </summary>
    ''' <returns></returns>
    Public Property BaseImage As Image
        Get
            Return _baseImage
        End Get
        Set(value As Image)
            _baseImage = value
        End Set
    End Property
    ''' <summary>
    ''' Default pen used to draw borders
    ''' </summary>
    ''' <returns></returns>
    Public Property DefBorderPen As Pen
        Get
            Return _defBorderPen
        End Get
        Set(value As Pen)
            _defBorderPen = value
        End Set
    End Property
    ''' <summary>
    ''' Map counties names font
    ''' </summary>
    ''' <returns></returns>
    Public Property MapFont As Font
        Get
            Return _mapFont
        End Get
        Set(value As Font)
            _mapFont = value
        End Set
    End Property
    ''' <summary>
    ''' Should map draw counties names or not.
    ''' </summary>
    ''' <returns></returns>
    Public Property DrawNames As Boolean
        Get
            Return _drawNames
        End Get
        Set(value As Boolean)
            _drawNames = value
        End Set
    End Property
    ''' <summary>
    ''' Default gradient used for polygons filling, if they by some reason don't have their own color set.
    ''' </summary>
    ''' <returns></returns>
    Public Property DefGradient As CGradient
        Get
            Return _defGradient
        End Get
        Set(value As CGradient)
            _defGradient = value
        End Set
    End Property
    ''' <summary>
    ''' Default polygon background brush, what will be applied if polygon don't have its own brush.
    ''' It is used to fill polygon with single color, if "SimplePolygonsDraw" property is True.
    ''' </summary>
    ''' <returns></returns>
    Public Property DefPolygonBackgroundBrush As Brush
        Get
            Return _defPolygonBackgroundBrush
        End Get
        Set(value As Brush)
            _defPolygonBackgroundBrush = value
        End Set
    End Property

    ''' <summary>
    ''' If True, polygons will be drawn with no gradient, but with single color.
    ''' </summary>
    ''' <returns></returns>
    Public Property SimplePolygonsDraw As Boolean
        Get
            Return _simplePolygonsDraw
        End Get
        Set(value As Boolean)
            _simplePolygonsDraw = value
        End Set
    End Property
    ''' <summary>
    ''' If true, in case if map has no base image to use as background,
    ''' background will be drawn using single color.
    ''' </summary>
    ''' <returns></returns>
    Public Property SimpleBackgroundDraw As Boolean
        Get
            Return _simpleBackgroundDraw
        End Get
        Set(value As Boolean)
            _simpleBackgroundDraw = value
        End Set
    End Property
    ''' <summary>
    ''' If true, _polygons will be filled when drawing them. If not, they will remain empty.
    ''' </summary>
    ''' <returns></returns>
    Public Property FillPolygons As Boolean
        Get
            Return _fillPolygons
        End Get
        Set(value As Boolean)
            _fillPolygons = value
        End Set
    End Property
    ''' <summary>
    ''' Default center color of background gradient in case if "SimpleBackgroundDraw" property is False.
    ''' </summary>
    ''' <returns></returns>
    Public Property DefBgCenterColor As Color
        Get
            Return _polygons.DefBgGradient.CenterColor
        End Get
        Set(value As Color)
            If (value <> Nothing) Then
                _polygons.DefBgGradient.CenterColor = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' Default side color of background gradient in case if "SimpleBackgroundDraw" property is False.
    ''' </summary>
    ''' <returns></returns>
    Public Property DefBgSideColor As Color
        Get
            Return _polygons.DefBgGradient.SideColor
        End Get
        Set(value As Color)
            If (value <> Nothing) Then
                _polygons.DefBgGradient.SideColor = value
            End If
        End Set
    End Property

    Public Sub AddPolygon(polygonPoints() As Point,
                          newPolygonName As String,
                          newPolygonKey As String,
                          Optional newPolygonNameDrawPoint As PointF = Nothing,
                          Optional newPolygonDrawName As Boolean = False,
                          Optional newPolygonGradientCenterColor As Color = Nothing,
                          Optional newPolygonGradientSideColor As Color = Nothing,
                          Optional newPolygonDefaultBackgroundBrush As Brush = Nothing,
                          Optional newPolygonBorderPen As Pen = Nothing)
        If (newPolygonGradientCenterColor = Nothing) Then
            newPolygonGradientCenterColor = _defGradient.CenterColor
        End If
        If (newPolygonGradientSideColor = Nothing) Then
            newPolygonGradientSideColor = _defGradient.SideColor
        End If
        If (newPolygonDefaultBackgroundBrush Is Nothing) Then
            newPolygonDefaultBackgroundBrush = _defPolygonBackgroundBrush
        End If
        If (newPolygonBorderPen Is Nothing) Then
            newPolygonBorderPen = _defBorderPen
        End If
        _polygons.Add(New CPolygon(polygonPoints,
                         mapPictureBox,
                         newPolygonName,
                         newPolygonKey,
                         newPolygonGradientCenterColor,
                         newPolygonGradientSideColor,
                         newPolygonDefaultBackgroundBrush,
                         newPolygonBorderPen,
                         newPolygonNameDrawPoint,
                         newPolygonDrawName))
    End Sub
    ''' <summary>
    ''' Redraws whole map with updated map and _polygons properties.
    ''' </summary>
    Public Sub MapUpdate()
        BaseImage?.Dispose()
        _polygons.DrawAll(mapPictureBox, _fillPolygons,,, _mapFont, _drawNames, _simplePolygonsDraw, _simpleBackgroundDraw, _baseImage)
    End Sub
    ''' <summary>
    ''' Updates exact polygon, what has name <paramref name="aimName"/>
    ''' </summary>
    ''' <param name="aimName">Name of aim polygon</param>
    Public Sub MapUpdatePolygonsWhereName(aimName As String)
        For i As Integer = 0 To _polygons.Count - 1
            If (Polygons(i).Name = aimName) Then
                _polygons(i).Draw(mapPictureBox, _fillPolygons,,,, _simplePolygonsDraw)
            End If
        Next
        For i As Integer = 0 To _polygons.Count - 1
            _polygons(i).DrawPolygonName(mapPictureBox, _mapFont)
        Next
    End Sub
    ''' <summary>
    ''' Resets all _polygons individual settings to default.
    ''' </summary>
    ''' <param name="setBorderPen"></param>
    ''' <param name="setGradientBrushCenterColor"></param>
    ''' <param name="setGradientBrushSideColor"></param>
    Public Sub MapSetAllPolygonsToDefault(Optional setBorderPen As Boolean = True,
                                        Optional setGradientBrushCenterColor As Boolean = True,
                                        Optional setGradientBrushSideColor As Boolean = True)
        For i As Integer = 0 To _polygons.Count - 1
            If (setBorderPen) Then
                _polygons(i).BorderPen = _defBorderPen
            End If
            If (setGradientBrushCenterColor) Then
                _polygons(i).GradientBrushCenterColor = _defGradient.CenterColor
            End If
            If (setGradientBrushSideColor) Then
                _polygons(i).GradientBrushSideColor = _defGradient.SideColor
            End If
        Next
    End Sub
    ''' <summary>
    ''' Draws all _polygons with color <paramref name="color"/>
    ''' </summary>
    ''' <param name="color">Color what will be used to draw _polygons</param>
    Public Sub MapDrawAllColor(color As Color)
        _polygons.DrawAll(mapPictureBox,
                         _fillPolygons,
                         color,,
                         _mapFont,
                         _drawNames,
                         _simplePolygonsDraw,
                         _simpleBackgroundDraw,
                         _baseImage)
    End Sub
    ''' <summary>
    ''' Draws all _polygons with gradient <paramref name="gradient"/>
    ''' </summary>
    ''' <param name="gradient">Gradient what will be used to draw _polygons</param>
    Public Sub MapDrawAllGradient(gradient As CGradient)
        _polygons.DrawAll(mapPictureBox,
                         _fillPolygons,
                         gradient.CenterColor,
                         gradient.SideColor,
                         _mapFont,
                         DrawNames,
                         _simplePolygonsDraw,
                         _simpleBackgroundDraw,
                         _baseImage)
    End Sub
    ''' <summary>
    ''' Draw _polygons in different color / gradient depending on their relative integer value level.<br/>
    ''' In case if SimplePolygonsDraw is True, for filling _polygons will be used center color of gradient.<br/>
    ''' Uses <paramref name="levelGradients"/> for filling _polygons. First gradient is used for polygon with smallest
    ''' relative value, last for highest. Gradients between are used for intermediate values.
    ''' </summary>
    ''' <param name="pair">KeyValuePair(Of String, Integer) where String is polygon key and Integer is polygon statistics
    ''' value (sick number, vaccinated number etc)</param>
    ''' <param name="levelGradients">Gradients what will be used to fill _polygons depending on their value.
    ''' First is for smallest values _polygons, last for biggest values, gradients between are used for intermediate values</param>
    ''' <param name="gradientDefault">Default gradient what will be used to fill polygon in case if it is not presented
    ''' in "pair" array</param>
    Public Sub MapDrawLevelGradient(pair() As KeyValuePair(Of String, Double),
                             levelGradients As Array,
                             Optional gradientDefault As CGradient = Nothing)
        Dim maxValue As Double = 0
        Dim minValue As Double = Integer.MaxValue
        If (gradientDefault Is Nothing) Then
            gradientDefault = CGradient.Gray
        End If
        For Each item As KeyValuePair(Of String, Double) In pair
            If (item.Value > maxValue) Then
                maxValue = item.Value
            End If
            If (item.Value < minValue And item.Value <> -1) Then
                minValue = item.Value
            End If
        Next
        If (levelGradients.Length <> 0) Then
            For Each item As KeyValuePair(Of String, Double) In pair
                Dim n As Integer = Min(Round(((minValue + item.Value) / maxValue) * levelGradients.Length), levelGradients.Length - 1)
                _polygons.SetGradientWhereKey(item.Key, levelGradients(n))
            Next
        End If
        For Each item As KeyValuePair(Of String, Double) In pair
            If (item.Value = -1) Then
                _polygons.SetGradientWhereKey(item.Key, gradientDefault)
            End If
        Next
        _polygons.DrawAll(mapPictureBox,
                         _fillPolygons,,,
                         _mapFont,
                         _drawNames,
                         _simplePolygonsDraw,
                         _simpleBackgroundDraw,
                         _baseImage)
    End Sub
    ''' <summary>
    ''' Handes picturebox "Click" event. Sends component "Clicked" event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WhenPictureBoxClicked(sender As PictureBox, e As MouseEventArgs) Handles mapPictureBox.Click
        Dim clickPoint As New Point(
        e.X * (mapPictureBox.Image.Width / mapPictureBox.Width),
        e.Y * (mapPictureBox.Image.Height / mapPictureBox.Height))
        Dim clickedPolygonName As String = Nothing
        Dim clickedPolygonKey As String = Nothing
        For i As Integer = 0 To _polygons.Count - 1
            If (polygons(i).IsPointInside(clickPoint)) Then
                clickedPolygonName = _polygons(i).Name
                clickedPolygonKey = _polygons(i).Key
                Exit For
            End If
        Next
        RaiseEvent Clicked(clickPoint, clickedPolygonName, clickedPolygonKey)
    End Sub
    ''' <summary>
    ''' Handles cursor moving over picturebox. Used to highlight polygon where cursor currently is.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WhenPictureBoxHovered(sender As PictureBox, e As MouseEventArgs) Handles mapPictureBox.MouseMove
        Dim hoverPoint As New Point(
        e.X * (mapPictureBox.Image.Width / mapPictureBox.Width),
        e.Y * (mapPictureBox.Image.Height / mapPictureBox.Height))
        Dim hoveredPolygonKey As String = Nothing
        For i As Integer = 0 To _polygons.Count - 1
            If (polygons(i).IsPointInside(hoverPoint)) Then
                hoveredPolygonKey = _polygons(i).Key
                Exit For
            End If
        Next
        If (hoveredPolygonKey <> Nothing AndAlso _lastHoveredPolygonKey <> hoveredPolygonKey) Then
            HighlightPolygonsWithKey(hoveredPolygonKey)
        End If
        If (hoveredPolygonKey = Nothing Or _lastHoveredPolygonKey <> hoveredPolygonKey) Then
            Dim k = _lastHoveredPolygonKey
            For i As Integer = 0 To _polygons.Count - 1
                If (_polygons(i).Key = _lastHoveredPolygonKey) Then
                    _polygons(i).Draw(mapPictureBox, _fillPolygons, _defBorderPen,,, _simplePolygonsDraw)
                End If
            Next
            For i As Integer = 0 To _polygons.Count - 1
                _polygons(i).DrawPolygonName(mapPictureBox, _mapFont)
            Next
            _lastHoveredPolygonKey = hoveredPolygonKey
        End If
    End Sub

    Private Sub HighlightPolygonsWithKey(hoveredPolygonKey As String)
        For i As Integer = 0 To _polygons.Count - 1
            If (_polygons(i).Key = hoveredPolygonKey) Then
                Dim withCenterColor As Color
                Dim withSideColor As Color
                With _polygons(i).GradientBrushCenterColor
                    withCenterColor = Color.FromArgb(
                        Min(255, .A + 20),
                        Min(255, .R + 20),
                        Min(255, .G + 20),
                        Min(255, .B + 20))
                End With
                With _polygons(i).GradientBrushSideColor
                    withSideColor = Color.FromArgb(
                        Min(255, .A + 20),
                        Min(255, .R + 20),
                        Min(255, .G + 20),
                        Min(255, .B + 20))
                End With
                _polygons(i).Draw(mapPictureBox, _fillPolygons, _defBorderPen, withCenterColor, withSideColor, _simplePolygonsDraw)
            End If
        Next
        For i As Integer = 0 To _polygons.Count - 1
            _polygons(i).DrawPolygonName(mapPictureBox, _mapFont)
        Next
    End Sub
    ''' <summary>
    ''' Handles component resize. Resizes internal picturebox component.
    ''' </summary>
    Private Sub WhenResized() Handles Me.Resize
        mapPictureBox.Size = Me.Size
    End Sub
End Class
