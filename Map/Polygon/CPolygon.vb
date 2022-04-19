' FILENAME: CPolygon.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 01.04.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CPolygons
Imports System.Math
Imports System.Drawing.Drawing2D
Public Class CPolygon
    Private _points As Point()
    Private _minX As Integer
    Private _maxX As Integer
    Private _minY As Integer
    Private _maxY As Integer
    Private _fillGradientBrush As PathGradientBrush = Nothing
    Private _fillGradientBrushPath As GraphicsPath = Nothing
    Private _bgBrush As Brush = Nothing
    Private _borderPen As Pen = Nothing
    Private _polygonName As String = ""
    Private _polygonKey As String = ""
    Private _namePoint As PointF
    Private _drawName As Boolean
    ''' <summary>
    ''' Minimal X coordinate of rectangle built by maximal and minimal X, Y values among polygon points.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MinX As Integer
        Get
            Return _minX
        End Get
    End Property
    ''' <summary>
    ''' Minimal Y coordinate of rectangle built by maximal and minimal X, Y values among polygon points.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MinY As Integer
        Get
            Return _minY
        End Get
    End Property
    ''' <summary>
    ''' Maximal X coordinate of rectangle built by maximal and minimal X, Y values among polygon points.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MaxX As Integer
        Get
            Return _maxX
        End Get
    End Property
    ''' <summary>
    ''' Maximal X coordinate of rectangle built by maximal and minimal X, Y values among polygon points.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MaxY As Integer
        Get
            Return _maxY
        End Get
    End Property
    ''' <summary>
    ''' Border pen what will be used to draw polygon borders.
    ''' </summary>
    ''' <returns></returns>
    Public Property BorderPen As Pen
        Get
            Return _borderPen
        End Get
        Set(value As Pen)
            _borderPen = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets polygon name what will be shown when polygon is drawn on map.
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
        Get
            Return _polygonName
        End Get
        Set(value As String)
            _polygonName = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets coordinates of point where center of drawn polygon name will be located.
    ''' </summary>
    ''' <returns></returns>
    Public Property NamePoint As PointF
        Get
            Return _namePoint
        End Get
        Set(value As PointF)
            _namePoint = value
        End Set
    End Property
    ''' <summary>
    ''' Special polygon indentifier what is used for simplier process of working with statistics.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Key As String
        Get
            Return _polygonKey
        End Get
    End Property
    ''' <summary>
    ''' Property what shows if polygon should draw its name on map. If False, polygon name won't be drawn.
    ''' </summary>
    ''' <returns></returns>
    Public Property DrawName As Boolean
        Get
            Return _drawName
        End Get
        Set(value As Boolean)
            _drawName = value
        End Set
    End Property
    ''' <summary>
    ''' Center color of gradient brush
    ''' </summary>
    ''' <returns></returns>
    Public Property GradientBrushCenterColor As Color
        Get
            Return _fillGradientBrush.CenterColor
        End Get
        Set(value As Color)
            _fillGradientBrush.CenterColor = value
        End Set
    End Property
    ''' <summary>
    ''' Side color of gradient brush
    ''' </summary>
    ''' <returns></returns>
    Public Property GradientBrushSideColor As Color
        Get
            Return _fillGradientBrush.SurroundColors(0)
        End Get
        Set(value As Color)
            Dim colors(_points.Length - 1) As Color
            Dim i As Integer = 0
            While (i < _points.Length)
                colors(i) = value
                i = i + 1
            End While
            _fillGradientBrush.SurroundColors = colors
        End Set
    End Property
    ''' <summary>
    ''' Points using what polygon is built
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Points As Point()
        Get
            Return _points
        End Get
    End Property

    Public Sub New(input_points() As Point, pb As PictureBox,
                   Optional new_polygonName As String = "",
                   Optional new_polygonKey As String = "",
                   Optional new_fillGradientCenterColor As Color = Nothing,
                   Optional new_fillGradientSideColor As Color = Nothing,
                   Optional new_bgBrush As Brush = Nothing,
                   Optional new_borderPen As Pen = Nothing,
                   Optional new_namePoint As PointF = Nothing,
                   Optional new_drawName As Boolean = True)
        Dim i As Integer = 0
        If (new_borderPen Is Nothing) Then
            _borderPen = Pens.Black
        End If
        _points = input_points
        _polygonName = new_polygonName
        If (new_polygonKey = "") Then
            _polygonKey = _polygonName
        Else
            _polygonKey = new_polygonKey
        End If
        If (_borderPen Is Nothing) Then
            _borderPen = New Pen(Brushes.Black, 3)
        End If
        _minX = pb.Width + 1
        _maxX = -1
        _minY = pb.Height + 1
        _maxY = -1
        While (i < input_points.Length)
            _minX = Min(input_points(i).X, _minX)
            _maxX = Max(input_points(i).X, _maxX)
            _minY = Min(input_points(i).Y, _minY)
            _maxY = Max(input_points(i).Y, _maxY)
            i += 1
        End While
        If (new_namePoint = Nothing) Then
            Dim psumX As Single = 0
            Dim psumY As Single = 0
            For Each point As Point In _points
                psumX += point.X
                psumY += point.Y
            Next
            new_namePoint = New PointF(psumX / _points.Length, psumY / _points.Length)
        End If
        _namePoint = new_namePoint
        _drawName = new_drawName

        _fillGradientBrushPath = New GraphicsPath
        _fillGradientBrushPath.AddLines(_points)
        _fillGradientBrush = New PathGradientBrush(_fillGradientBrushPath)
        If (new_fillGradientCenterColor = Nothing) Then
            new_fillGradientCenterColor = Color.Green
        End If
        If (new_fillGradientSideColor = Nothing) Then
            new_fillGradientSideColor = Color.FromArgb(90, 75, 120, 0)
        End If
        _fillGradientBrush.CenterColor = new_fillGradientCenterColor
        i = 0
        Dim colors(_points.Length - 1) As Color
        While (i < _points.Length)
            colors(i) = new_fillGradientSideColor
            i = i + 1
        End While
        If (new_bgBrush Is Nothing) Then
            new_bgBrush = Brushes.Gray
        End If
        _bgBrush = new_bgBrush
        _fillGradientBrush.SurroundColors = colors
    End Sub
    ''' <summary>
    ''' Returns True if <see cref="Point"/> <paramref name="point"/> is inside polygon.
    ''' </summary>
    ''' <param name="point"></param>
    ''' <returns></returns>
    Public Function IsPointInside(point As Point)
        If (point.X < _minX Or point.X > _maxX Or point.Y < _minY Or point.Y > _maxY) Then
            Return False
        End If
        Dim i As Integer = 0
        Dim j As Integer = _points.Count - 1
        Dim result As Boolean = False
        While (i < _points.Count)
            If ((_points(i).Y < point.Y And _points(j).Y >= point.Y Or _points(j).Y < point.Y And _points(i).Y >= point.Y) And
         (_points(i).X + (point.Y - _points(i).Y) / (_points(j).Y - _points(i).Y) * (_points(j).X - _points(i).X) < point.X)) Then
                result = Not result
            End If
            j = i
            i += 1
        End While
        Return result
    End Function
    ''' <summary>
    ''' Draws this polygon in <paramref name="pb"/> <see cref="PictureBox"/> image
    ''' </summary>
    ''' <param name="pb">PictureBox inside what polygon must be draw</param>
    ''' <param name="fill">If True, polygon will be filled with gradient or single color</param>
    ''' <param name="drawBorderPen">Pen what will be used to draw polygon borders</param>
    ''' <param name="withCenterColor">Center color of gradient what will be used to fill polygon</param>
    ''' <param name="withSideColor">Side color of gradient what will be used to fill polygon</param>
    ''' <param name="simpleDraw">If Truem polygon will be drawn with single color instead of gradient</param>
    Public Sub Draw(pb As PictureBox,
                    Optional fill As Boolean = False,
                    Optional drawBorderPen As Pen = Nothing,
                    Optional withCenterColor As Color = Nothing,
                    Optional withSideColor As Color = Nothing,
                    Optional simpleDraw As Boolean = False)
        Dim drawGradient As PathGradientBrush = _fillGradientBrush.Clone
        If pb.Image IsNot Nothing Then
            If (drawBorderPen Is Nothing) Then
                drawBorderPen = _borderPen
            End If
            If (withCenterColor <> Nothing) Then
                drawGradient.CenterColor = withCenterColor
            End If
            If (withSideColor <> Nothing) Then
                Dim i As Integer = 0
                Dim colors(_points.Length - 1) As Color
                While (i < _points.Length)
                    colors(i) = withSideColor
                    i = i + 1
                End While
                drawGradient.SurroundColors = colors
            End If
            Using g As Graphics = Graphics.FromImage(pb.Image)
                Dim i As Integer = 0
                Dim j As Integer = _points.Count - 1

                g.FillPolygon(_bgBrush, _points)
                If (simpleDraw And fill) Then
                    g.FillPolygon(New SolidBrush(drawGradient.CenterColor), _points)
                ElseIf (Not simpleDraw And fill) Then
                    g.FillPath(drawGradient, _fillGradientBrushPath)
                End If
                g.DrawPolygon(drawBorderPen, _points)
            End Using
            pb.Invalidate()
        End If
    End Sub
    ''' <summary>
    ''' Draws polygon name on <paramref name="pb"/> <see cref="PictureBox"/> image
    ''' </summary>
    ''' <param name="pb">PictureBox inside what polygon name must be drawn</param>
    ''' <param name="textFont">Font what will be used to draw polygon name</param>
    Public Sub DrawPolygonName(pb As PictureBox, textFont As Font)
        If (pb.Image IsNot Nothing AndAlso _drawName) Then
            Dim g As Graphics = Graphics.FromImage(pb.Image)
            Dim stringSize As SizeF = g.MeasureString(_polygonName, textFont)
            Dim drawPoint As New PointF(
                _namePoint.X - stringSize.Width / 2,
                _namePoint.Y - stringSize.Height / 2)
            g.DrawString(_polygonName, textFont, Brushes.Black, drawPoint)
        End If
        pb.Invalidate()
    End Sub
End Class