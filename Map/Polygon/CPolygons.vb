' FILENAME: CPolygons.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 25.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CPolygon
Imports System.Drawing.Drawing2D
Public Class CPolygons
    Private _polygons As List(Of CPolygon)
    Private _bitmapSize As Size
    Private _bitmapDefaultGradient As Gradient
    Private _baseImage As Image

    Default Public Property Element(index As Integer) As CPolygon
        Get
            Return _polygons(index)
        End Get
        Set(value As CPolygon)
            _polygons(index) = value
        End Set
    End Property
    Public ReadOnly Property Count As Integer
        Get
            Return _polygons.Count
        End Get
    End Property
    Public Property BaseImage As Image
        Get
            Return _baseImage
        End Get
        Set(value As Image)
            _baseImage = value
        End Set
    End Property
    Public Property DefBgGradient As Gradient
        Get
            Return _bitmapDefaultGradient
        End Get
        Set(value As Gradient)
            If (value.CenterColor <> Nothing) Then
                _bitmapDefaultGradient.CenterColor = value.CenterColor
            End If
            If (value.SideColor <> Nothing) Then
                _bitmapDefaultGradient.SideColor = value.SideColor
            End If
        End Set
    End Property

    Public Sub Add(newPolygon As CPolygon)
        _polygons.Add(newPolygon)
    End Sub
    Public Function GetPolygonWhereName(aimName As String) As CPolygon
        For Each polygon As CPolygon In _polygons
            If (polygon.Name = aimName) Then
                Return polygon
            End If
        Next
        Return Nothing
    End Function
    Public Sub SetGradientWhereName(aimName As String, gradient As Gradient)
        For Each polygon As CPolygon In _polygons
            If (polygon.Name = aimName) Then
                polygon.GradientBrushCenterColor = gradient.CenterColor
                polygon.GradientBrushSideColor = gradient.SideColor
            End If
        Next
    End Sub
    Public Sub SetGradientWhereKey(aimKey As String, gradient As Gradient)
        For Each polygon As CPolygon In _polygons
            If (polygon.Key = aimKey) Then
                polygon.GradientBrushCenterColor = gradient.CenterColor
                polygon.GradientBrushSideColor = gradient.SideColor
            End If
        Next
    End Sub
    Public Sub DrawAll(pb As PictureBox,
                       Optional fill As Boolean = False,
                       Optional newCenterColor As Color = Nothing,
                       Optional newSideColor As Color = Nothing,
                       Optional textFont As Font = Nothing,
                       Optional withNames As Boolean = True,
                       Optional simplePolygonsDraw As Boolean = False,
                       Optional simpleDefaultBackgroundDraw As Boolean = False)
        If (((_bitmapSize.Width > 0 AndAlso _bitmapSize.Height > 0) Or _baseImage IsNot Nothing) AndAlso _polygons.Count > 0) Then
            Dim bmp As Bitmap
            If (_baseImage Is Nothing) Then
                If (simpleDefaultBackgroundDraw) Then
                    bmp = New Bitmap(_bitmapSize.Width, _bitmapSize.Height)
                    Dim g As Graphics = Graphics.FromImage(bmp)
                    g.FillRectangle(
                        New SolidBrush(_bitmapDefaultGradient.CenterColor),
                        New Rectangle(0, 0, bmp.Width, bmp.Height))
                    g.Dispose()
                Else
                    bmp = New Bitmap(_bitmapSize.Width, _bitmapSize.Height)
                    Dim g As Graphics = Graphics.FromImage(bmp)
                    Dim bgPoints As Point() = {New Point(0, 0),
                                                        New Point(0, bmp.Height),
                                                        New Point(bmp.Width, bmp.Height),
                                                        New Point(bmp.Width, 0)}
                    Dim bgGradientBrush As New PathGradientBrush(bgPoints)
                    Dim bgGradientBrushPath As New GraphicsPath
                    bgGradientBrush.CenterColor = _bitmapDefaultGradient.CenterColor
                    bgGradientBrushPath.AddLines(bgPoints)
                    Dim colors(bgPoints.Count - 1) As Color
                    For i As Integer = 0 To bgPoints.Count - 1
                        colors(i) = _bitmapDefaultGradient.SideColor
                    Next
                    bgGradientBrush.SurroundColors = colors
                    g.FillPath(bgGradientBrush, bgGradientBrushPath)
                    g.Dispose()
                End If
            Else
                bmp = New Bitmap(DirectCast(_baseImage.Clone, Image))
            End If

            If (textFont Is Nothing) Then
                textFont = New Font("Times New Roman", 50, FontStyle.Bold Or FontStyle.Italic)
            End If

            If (pb.Image IsNot Nothing) Then
                pb.Image.Dispose()
            End If
            pb.Image = bmp
            If (newCenterColor <> Nothing) Then
                For Each polygon As CPolygon In _polygons
                    polygon.GradientBrushCenterColor = newCenterColor
                Next
            End If
            If (newSideColor <> Nothing) Then
                For Each polygon As CPolygon In _polygons
                    polygon.GradientBrushSideColor = newSideColor
                Next
            End If
            For Each polygon As CPolygon In _polygons
                polygon.Draw(pb, fill,,,, simplePolygonsDraw)
            Next
            If (withNames) Then
                For Each polygon As CPolygon In _polygons
                    polygon.DrawPolygonName(pb, textFont)
                Next
            End If
            pb.Invalidate()
        End If
    End Sub

    Public Sub New(imageSize As Size, Optional backgroundGradient As Gradient = Nothing)
        If (backgroundGradient Is Nothing) Then
            _bitmapDefaultGradient = (New Gradient).Blue
        Else
            _bitmapDefaultGradient = backgroundGradient
        End If
        _polygons = New List(Of CPolygon)
        _bitmapSize = imageSize
    End Sub
End Class
