' FILENAME: CPolygon.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 25.03.2022
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
    Private _borderPen As Pen = Nothing
    Private _polygonName As String = ""
    Private _namePoint As PointF
    Private _drawName As Boolean

    Public ReadOnly Property MinX As Integer
        Get
            Return _minX
        End Get
    End Property
    Public ReadOnly Property MinY As Integer
        Get
            Return _minY
        End Get
    End Property
    Public ReadOnly Property MaxX As Integer
        Get
            Return _maxX
        End Get
    End Property
    Public ReadOnly Property MaxY As Integer
        Get
            Return _maxY
        End Get
    End Property
    Public ReadOnly Property GradientBrush As PathGradientBrush
        Get
            Return _fillGradientBrush
        End Get
    End Property
    Public Property BorderPen As Pen
        Get
            Return _borderPen
        End Get
        Set(value As Pen)
            _borderPen = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return _polygonName
        End Get
        Set(value As String)
            _polygonName = value
        End Set
    End Property
    Public Property NamePoint As PointF
        Get
            Return _namePoint
        End Get
        Set(value As PointF)
            _namePoint = value
        End Set
    End Property
    Public Property DrawName As Boolean
        Get
            Return _drawName
        End Get
        Set(value As Boolean)
            _drawName = value
        End Set
    End Property
    Public Property GradientBrushCenterColor As Color
        Get
            Return _fillGradientBrush.CenterColor
        End Get
        Set(value As Color)
            _fillGradientBrush.CenterColor = value
        End Set
    End Property
    Public Property GradientBrushSideColor As Color
        Get
            Return _fillGradientBrush.SurroundColors(0)
        End Get
        Set(value As Color)
            Dim i As Integer = 0
            While (i < _points.Length)
                _fillGradientBrush.SurroundColors(i) = value
                i = i + 1
            End While
        End Set
    End Property

    Public Sub New(input_points() As Point, pb As PictureBox,
                   Optional new_polygonName As String = "",
                   Optional new_fillGradientCenterColor As Color = Nothing,
                   Optional new_fillGradientSideColor As Color = Nothing,
                   Optional new_borderPen As Pen = Nothing,
                   Optional new_namePoint As PointF = Nothing,
                   Optional new_drawName As Boolean = True)
        Dim i As Integer = 0
        _borderPen = new_borderPen
        _points = input_points
        _polygonName = new_polygonName
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
        _fillGradientBrush.SurroundColors = colors
    End Sub

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

    Public Sub Draw(pb As PictureBox,
                    Optional fill As Boolean = False,
                    Optional drawBorderPen As Pen = Nothing,
                    Optional newCenterColor As Color = Nothing,
                    Optional newSideColor As Color = Nothing)
        If pb.Image IsNot Nothing Then
            If (drawBorderPen Is Nothing) Then
                drawBorderPen = _borderPen
            End If
            If (newCenterColor <> Nothing) Then
                _fillGradientBrush.CenterColor = newCenterColor
            End If
            If (newSideColor <> Nothing) Then
                Dim i As Integer = 0
                While (i < _points.Length)
                    _fillGradientBrush.SurroundColors(i) = newSideColor
                    i = i + 1
                End While
            End If
            Using g As Graphics = Graphics.FromImage(pb.Image)
                    Dim i As Integer = 0
                    Dim j As Integer = _points.Count - 1
                    If (fill) Then
                        g.FillPath(_fillGradientBrush, _fillGradientBrushPath)
                    End If
                    While (i < _points.Count)
                        Dim point1, point2 As New Point
                        Dim moveX1 As Integer = _points(i).X / pb.Image.Width + _borderPen.Width / 5
                        Dim moveX2 As Integer = _points(j).X / pb.Image.Width + _borderPen.Width / 5
                        Dim moveY1 As Integer = _points(i).Y / pb.Image.Height + _borderPen.Width / 5
                        Dim moveY2 As Integer = _points(j).Y / pb.Image.Height + _borderPen.Width / 5
                        If (_points(i).X > _points(j).X) Then
                            point1.X = _points(i).X + Max(1, moveX1)
                            point2.X = _points(j).X - Max(1, moveX2)
                        Else
                            point1.X = _points(i).X - Max(1, moveX1)
                            point2.X = _points(j).X + Max(1, moveX2)
                        End If
                        If (_points(i).Y > _points(j).Y) Then
                            point1.Y = _points(i).Y + Max(1, moveY1)
                            point2.Y = _points(j).Y - Max(1, moveY2)
                        Else
                            point1.Y = _points(i).Y - Max(1, moveY1)
                            point2.Y = _points(j).Y + Max(1, moveY2)
                        End If
                        g.DrawLine(drawBorderPen, point1, point2)
                        j = i
                        i = i + 1
                    End While
                End Using
                pb.Invalidate()
            End If
    End Sub

    Public Sub DrawPolygonName(pb As PictureBox, textFont As Font)
        If (pb.Image IsNot Nothing AndAlso _drawName) Then
            Dim g As Graphics = Graphics.FromImage(pb.Image)
            Dim stringSize As SizeF = g.MeasureString(_polygonName, textFont)
            Dim drawPoint As New PointF(
                _namePoint.X - stringSize.Width / 2,
                _namePoint.Y - stringSize.Height / 2)
            g.DrawString(_polygonName, textFont, Brushes.Black, drawPoint)
        End If
    End Sub
End Class