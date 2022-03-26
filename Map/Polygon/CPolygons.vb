' FILENAME: CPolygons.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 25.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CPolygon
Public Class CPolygons
    Private polygons As List(Of CPolygon)
    Private bitmapSize As Size

    Default Public Property Element(index As Integer) As CPolygon
        Get
            Return polygons(index)
        End Get
        Set(value As CPolygon)
            polygons(index) = value
        End Set
    End Property
    Public ReadOnly Property Count As Integer
        Get
            Return polygons.Count
        End Get
    End Property

    Public Sub Add(newPolygon As CPolygon)
        polygons.Add(newPolygon)
    End Sub

    Public Function GetPolygonWhereName(aimName As String) As CPolygon
        For Each polygon As CPolygon In polygons
            If (polygon.Name = aimName) Then
                Return polygon
            End If
        Next
        Return Nothing
    End Function
    Public Sub SetGradientWhereName(aimName As String, gradient As Gradient)
        For Each polygon As CPolygon In polygons
            If (polygon.Name = aimName) Then
                polygon.GradientBrushCenterColor = gradient.CenterColor
                polygon.GradientBrushSideColor = gradient.SideColor
            End If
        Next
    End Sub
    Public Sub DrawAll(pb As PictureBox,
                       Optional fill As Boolean = False,
                       Optional newCenterColor As Color = Nothing,
                       Optional newSideColor As Color = Nothing,
                       Optional textFont As Font = Nothing)
        If (bitmapSize.Width > 0 AndAlso bitmapSize.Height > 0 AndAlso polygons.Count > 0) Then
            Dim bmp As New Bitmap(bitmapSize.Width, bitmapSize.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(Brushes.Gray, 0, 0, bmp.Width, bmp.Height)
            If (textFont Is Nothing) Then
                textFont = New Font("Times New Roman", 50, FontStyle.Bold Or FontStyle.Italic)
            End If
            pb.Image = bmp
            If (newCenterColor <> Nothing) Then
                For Each polygon As CPolygon In polygons
                    polygon.GradientBrushCenterColor = newCenterColor
                Next
            End If
            If (newSideColor <> Nothing) Then
                For Each polygon As CPolygon In polygons
                    polygon.GradientBrushSideColor = newSideColor
                Next
            End If
            For Each polygon As CPolygon In polygons
                polygon.Draw(pb, fill)
            Next
            For Each polygon As CPolygon In polygons
                polygon.DrawPolygonName(pb, textFont)
            Next
        End If
    End Sub

    Public Sub New(imageSize As Size)
        polygons = New List(Of CPolygon)
        bitmapSize = imageSize
    End Sub
End Class
