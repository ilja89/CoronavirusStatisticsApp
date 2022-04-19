' FILENAME: CPolygons.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 01.04.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CPolygon
Imports System.Drawing.Drawing2D
''' <summary>
''' Used to make a list of <see cref="CPolygon"/> and treat them in more convenient form
''' </summary>
Public Class CPolygons
    Private _polygons As List(Of CPolygon)
    Private _bitmapSize As Size
    Private _bitmapDefaultGradient As CGradient
    ''' <summary>
    ''' Gets or sets polygon under requested <paramref name="index"/>
    ''' </summary>
    ''' <param name="index">Index of aim polygon</param>
    ''' <returns></returns>
    Default Public Property Element(index As Integer) As CPolygon
        Get
            Return _polygons(index)
        End Get
        Set(value As CPolygon)
            _polygons(index) = value
        End Set
    End Property
    ''' <summary>
    ''' Returns number of polygons in list
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Count As Integer
        Get
            Return _polygons.Count
        End Get
    End Property
    ''' <summary>
    ''' Default background gradient. Used in <seealso cref="DrawAll(PictureBox, Boolean, Color, Color, Font, Boolean, Boolean, Boolean, Image)"/> if there are no BaseImage selected
    ''' </summary>
    ''' <returns></returns>
    Public Property DefBgGradient As CGradient
        Get
            Return _bitmapDefaultGradient
        End Get
        Set(value As CGradient)
            If (value.CenterColor <> Nothing) Then
                _bitmapDefaultGradient.CenterColor = value.CenterColor
            End If
            If (value.SideColor <> Nothing) Then
                _bitmapDefaultGradient.SideColor = value.SideColor
            End If
        End Set
    End Property
    ''' <summary>
    ''' Adds new polygon in the end of list
    ''' </summary>
    ''' <param name="newPolygon"></param>
    Public Sub Add(newPolygon As CPolygon)
        _polygons.Add(newPolygon)
    End Sub
    ''' <summary>
    ''' Returns first polygon with requested name
    ''' </summary>
    ''' <param name="aimName">Name of aim polygon</param>
    ''' <returns></returns>
    Public Function GetPolygonWhereName(aimName As String) As CPolygon
        For Each polygon As CPolygon In _polygons
            If (polygon.Name = aimName) Then
                Return polygon
            End If
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' Sets <see cref="CGradient"/> <paramref name="gradient"/> to all polygons in list, what have name <paramref name="aimName"/>
    ''' </summary>
    ''' <param name="aimName">Name of aim polygons</param>
    ''' <param name="gradient">Gradient to use</param>
    Public Sub SetGradientWhereName(aimName As String, gradient As CGradient)
        For Each polygon As CPolygon In _polygons
            If (polygon.Name = aimName) Then
                polygon.GradientBrushCenterColor = gradient.CenterColor
                polygon.GradientBrushSideColor = gradient.SideColor
            End If
        Next
    End Sub
    ''' <summary>
    ''' Sets <see cref="CGradient"/> <paramref name="gradient"/> to all polygons in list, what have key <paramref name="aimKey"/>
    ''' </summary>
    ''' <param name="aimKey">Key of aim polygons</param>
    ''' <param name="gradient">Gradient to use</param>
    Public Sub SetGradientWhereKey(aimKey As String, gradient As CGradient)
        For Each polygon As CPolygon In _polygons
            If (polygon.Key = aimKey) Then
                polygon.GradientBrushCenterColor = gradient.CenterColor
                polygon.GradientBrushSideColor = gradient.SideColor
            End If
        Next
    End Sub
    ''' <summary>
    ''' Draws all polygons on image inside <see cref="PictureBox"/> <paramref name="pb"/>
    ''' </summary>
    ''' <param name="pb">PictureBox inside what polygons will be drawn</param>
    ''' <param name="fill">If True, polygons will be drawn filled</param>
    ''' <param name="newCenterColor">If not Nothing, will set all polygons gradients center colors to this color</param>
    ''' <param name="newSideColor">If not Nothing, will set all polygons gradients side colors to this color</param>
    ''' <param name="textFont">If not Nothing, will set all polygons fonts to this font</param>
    ''' <param name="withNames">If True, polygons will be drawn with their names</param>
    ''' <param name="simplePolygonsDraw">If True, polygons will be filled with single color instead of gradient</param>
    ''' <param name="simpleDefaultBackgroundDraw">If True, background on what polygons will be drawn will be filled with single
    ''' color instead of gradient</param>
    Public Sub DrawAll(pb As PictureBox,
                       Optional fill As Boolean = False,
                       Optional newCenterColor As Color = Nothing,
                       Optional newSideColor As Color = Nothing,
                       Optional textFont As Font = Nothing,
                       Optional withNames As Boolean = True,
                       Optional simplePolygonsDraw As Boolean = False,
                       Optional simpleDefaultBackgroundDraw As Boolean = False,
                       Optional baseImage As Image = Nothing)
        If (((_bitmapSize.Width > 0 AndAlso _bitmapSize.Height > 0) Or baseImage IsNot Nothing) AndAlso _polygons.Count > 0) Then
            Dim bmp As Bitmap
            If (baseImage Is Nothing) Then
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
                bmp = New Bitmap(DirectCast(baseImage.Clone, Image))
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

    Public Sub New(imageSize As Size, Optional backgroundGradient As CGradient = Nothing)
        If (backgroundGradient Is Nothing) Then
            _bitmapDefaultGradient = (New CGradient).Blue
        Else
            _bitmapDefaultGradient = backgroundGradient
        End If
        _polygons = New List(Of CPolygon)
        _bitmapSize = imageSize
    End Sub
End Class
