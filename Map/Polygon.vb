Imports System.Math
Public Class Polygon
    Public points As Point()
    Public minX As Integer
    Public maxX As Integer
    Public minY As Integer
    Public maxY As Integer
    Public fillBrush As Brush = Nothing  ' Brush with exact color to fill
    Public borderPen As Pen = Nothing
    Public polygonName As String = ""

    Public Sub New(inputPoints() As Point, pb As PictureBox,
                   Optional newPolygonName As String = "",
                   Optional newFillBrush As Brush = Nothing,
                   Optional newBorderPen As Pen = Nothing)
        Dim i As Integer = 0
        fillBrush = newFillBrush
        borderPen = newBorderPen
        points = inputPoints
        polygonName = newPolygonName
        If (fillBrush Is Nothing) Then
            fillBrush = Brushes.Gray
        End If
        If (borderPen Is Nothing) Then
            borderPen = New Pen(Brushes.Black, 3)
        End If
        minX = pb.Width + 1
        maxX = -1
        minY = pb.Height + 1
        maxY = -1
        While (i < inputPoints.Length)
            minX = Math.Min(inputPoints(i).X, minX)
            maxX = Math.Max(inputPoints(i).X, maxX)
            minY = Math.Min(inputPoints(i).Y, minY)
            maxY = Math.Max(inputPoints(i).Y, maxY)
            i += 1
        End While

    End Sub

    Public Function PointIsInside(point As Point)
        If (point.X < minX Or point.X > maxX Or point.Y < minY Or point.Y > maxY) Then
            Return False
        End If
        Dim i As Integer = 0
        Dim j As Integer = points.Count - 1
        Dim result As Boolean = False
        While (i < points.Count)
            If ((points(i).Y < point.Y And points(j).Y >= point.Y Or points(j).Y < point.Y And points(i).Y >= point.Y) And
         (points(i).X + (point.Y - points(i).Y) / (points(j).Y - points(i).Y) * (points(j).X - points(i).X) < point.X)) Then
                result = Not result
            End If
            j = i
            i += 1
        End While
        Return result
    End Function

    Public Sub Draw(pb As PictureBox,
                           Optional fill As Boolean = False,
                           Optional bmpSize As Size = Nothing)
        If pb.Image Is Nothing Then
            If (bmpSize = Nothing) Then
                bmpSize = New Size(maxX, maxY)
            End If
            Dim bmp As New Bitmap(bmpSize.Width, bmpSize.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            pb.Image = bmp
        End If
        Using g As Graphics = Graphics.FromImage(pb.Image)
            Dim i As Integer = 0
            Dim j As Integer = points.Count - 1
            If (fill) Then
                g.FillPolygon(fillBrush, points)
            End If
            While (i < points.Count)
                Dim point1, point2 As New Point
                Dim moveX1 As Integer = points(i).X / pb.Image.Width + borderPen.Width / 5
                Dim moveX2 As Integer = points(j).X / pb.Image.Width + borderPen.Width / 5
                Dim moveY1 As Integer = points(i).Y / pb.Image.Height + borderPen.Width / 5
                Dim moveY2 As Integer = points(j).Y / pb.Image.Height + borderPen.Width / 5
                If (points(i).X > points(j).X) Then
                    point1.X = points(i).X + Max(1, moveX1)
                    point2.X = points(j).X - Max(1, moveX2)
                Else
                    point1.X = points(i).X - Max(1, moveX1)
                    point2.X = points(j).X + Max(1, moveX2)
                End If
                If (points(i).Y > points(j).Y) Then
                    point1.Y = points(i).Y + Max(1, moveY1)
                    point2.Y = points(j).Y - Max(1, moveY2)
                Else
                    point1.Y = points(i).Y - Max(1, moveY1)
                    point2.Y = points(j).Y + Max(1, moveY2)
                End If
                g.DrawLine(borderPen, point1, point2)
                j = i
                i = i + 1
            End While
        End Using
        pb.Invalidate()
    End Sub
    Public Sub Fill(pb As PictureBox, Optional brush As Brush = Nothing, Optional pen As Pen = Nothing)
        If (brush Is Nothing) Then
            brush = fillBrush
        End If
        If (pen Is Nothing) Then
            pen = borderPen
        End If
        If pb.Image IsNot Nothing Then
            Using g As Graphics = Graphics.FromImage(pb.Image)
                Dim i As Integer = 0
                Dim j As Integer = points.Count - 1
                g.FillPolygon(brush, points)
                While (i < points.Count)
                    Dim point1, point2 As New Point
                    Dim moveX1 As Integer = points(i).X / pb.Image.Width + borderPen.Width / 5
                    Dim moveX2 As Integer = points(j).X / pb.Image.Width + borderPen.Width / 5
                    Dim moveY1 As Integer = points(i).Y / pb.Image.Height + borderPen.Width / 5
                    Dim moveY2 As Integer = points(j).Y / pb.Image.Height + borderPen.Width / 5
                    If (points(i).X > points(j).X) Then
                        point1.X = points(i).X + Max(1, moveX1)
                        point2.X = points(j).X - Max(1, moveX2)
                    Else
                        point1.X = points(i).X - Max(1, moveX1)
                        point2.X = points(j).X + Max(1, moveX2)
                    End If
                    If (points(i).Y > points(j).Y) Then
                        point1.Y = points(i).Y + Max(1, moveY1)
                        point2.Y = points(j).Y - Max(1, moveY2)
                    Else
                        point1.Y = points(i).Y - Max(1, moveY1)
                        point2.Y = points(j).Y + Max(1, moveY2)
                    End If
                    g.DrawLine(borderPen, point1, point2)
                    j = i
                    i = i + 1
                End While
            End Using
            pb.Invalidate()
        End If
    End Sub
End Class