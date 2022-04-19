Imports System.Math
Imports Map
Public Class mapDebug
    Private ps As Size = New Size(1920, 1200)
    Private polygons As New List(Of CPolygon)
    Private curPoints As New List(Of Point)
    Private Sub WhenLoaded() Handles Me.Load
        polygons.Add(New CPolygon(
                     stringToPoints("813,1000,831,856,831,826,864,786,872,760,834,738,792,756,773,803,739,807,699,801,656,779,615,747,600,710,604,646,636,637,674,627,683,586,693,565,719,558,760,565,813,567,831,556,854,532,887,522,908,530,967,517,965,547,992,547,1020,534,1054,541,1073,552,1056,605,1042,625,1023,646,1003,651,983,676,976,704,979,738,1005,754,1059,756,1074,788,1076,809,1044,833,1026,854,1008,872,1003,910,991,925,959,929,926,953,890,953,869,960,852,966"),
                     mpb))
        Redraw()
    End Sub
    Private Sub mpb_Click(sender As Object, e As MouseEventArgs) Handles mpb.Click
        Dim clickCoords As New Point(CInt((e.X * ps.Width / mpb.Width)), CInt((e.Y * ps.Height / mpb.Height)))
        coords.Text = "X " + clickCoords.X.ToString + " Y " + clickCoords.Y.ToString
        If (Not PointOfExistingPolygon(clickCoords, curPoints) And NotNearToExisting(clickCoords)) Then
            curPoints.Add(clickCoords)
        End If
        Redraw()
    End Sub
    Private Sub Redraw()
        mpb.Image = PictureBox1.Image.Clone
        For Each polygon As CPolygon In polygons
            polygon.Draw(mpb, False, New Pen(Brushes.Black, 4))
        Next
        Dim g As Graphics = Graphics.FromImage(mpb.Image)
        If (curPoints.Count - 1 >= 0) Then
            Dim i As Integer = curPoints.Count - 1
            For j As Integer = 0 To curPoints.Count - 1
                g.DrawLine(Pens.Green, curPoints(i), curPoints(j))
                i = j
            Next
            For j As Integer = 0 To curPoints.Count - 1
                g.DrawEllipse(Pens.Red,
                              New RectangleF(curPoints(j) - New Point(4, 4), New SizeF(8, 8)))
            Next
        End If
        For Each p As CPolygon In polygons
            For j As Integer = 0 To p.Points.Length - 1
                g.FillEllipse(Brushes.Red,
                              New RectangleF(p.Points(j) - New Point(4, 4), New SizeF(8, 8)))
            Next
        Next
    End Sub
    Private Function PointOfExistingPolygon(newPoint As Point, ByRef list As List(Of Point))
        For Each p As CPolygon In polygons
            For Each point As Point In p.Points
                If (Abs(point.X - newPoint.X) < 13 AndAlso Abs(point.Y - newPoint.Y) < 13) Then
                    list.Add(point)
                    Return True
                End If
            Next
        Next
        Return False
    End Function
    Private Function NotNearToExisting(newPoint As Point)
        For Each point As Point In curPoints
            If (Abs(point.X - newPoint.X) < 13 AndAlso Abs(point.Y - newPoint.Y) < 13) Then
                Return False
            End If
        Next
        Return True
    End Function
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

    Private Sub outPointsButton_Click(sender As Object, e As EventArgs) Handles outPointsButton.Click
        richTb.Text = ""
        For Each point As Point In curPoints
            richTb.Text += point.X.ToString + "," + point.Y.ToString + ","
        Next
    End Sub

    Private Sub removeLastButton_Click(sender As Object, e As EventArgs) Handles removeLastButton.Click
        If (curPoints.Count > 0) Then
            curPoints.RemoveAt(curPoints.Count - 1)
        End If
        Redraw()
    End Sub
End Class