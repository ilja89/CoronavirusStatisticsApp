Imports System.Drawing
Imports System.Math
Imports Polygon
Public Class Map
    Private polygons As New List(Of Polygon)
    Private Async Sub test2() Handles Me.Load
        Dim sizeRelationW As Double = PictureBox1.Image.Width / PictureBox1.Width
        Dim sizeRelationH As Double = PictureBox1.Image.Height / PictureBox1.Height
        polygons.Add(New Polygon({
                                             New Point(200, 552),
                                             New Point(130, 360),
                                             New Point(200, 130),
                                             New Point(600, 230),
                                             New Point(683, 435),
                                             New Point(520, 560),
                                             New Point(483, 351),
                                             New Point(290, 437)
                                             }, PictureBox1, "Polygon1", Brushes.Red, New Pen(Brushes.Black, 2)))
        polygons.Add(New Polygon({
                                             New Point(200, 552),
                                             New Point(290, 437),
                                             New Point(483, 351),
                                             New Point(520, 560),
                                             New Point(320, 800),
                                             New Point(365, 510),
                                             New Point(260, 780),
                                             New Point(70, 670)
                                             }, PictureBox1, "Polygon2", Brushes.Yellow, New Pen(Brushes.Black, 2)))
        polygons.Add(New Polygon({
                                             New Point(520, 560),
                                             New Point(683, 435),
                                             New Point(750, 770),
                                             New Point(320, 800)
                                             }, PictureBox1, "Polygon3", Brushes.Green, New Pen(Brushes.Black, 2)))
        For Each p As Polygon In polygons
            p.Draw(PictureBox1, True, New Size(900, 900))
        Next

    End Sub

    Private Sub PictureBox1_Click(sender As PictureBox, e As MouseEventArgs) Handles PictureBox1.Click
        Dim clickedPolygon As Polygon = Nothing
        Dim isInside As Boolean = False
        Dim click As New Point(
            e.X * (sender.Image.Width / sender.Width),
            e.Y * (sender.Image.Height / sender.Height)
        )
        For Each p As Polygon In polygons
            If (p.PointIsInside(click)) Then
                isInside = True
                clickedPolygon = p
                Exit For
            End If
        Next
        RichTextBox1.Text = "X: " + click.X.ToString + vbCrLf + "Y: " + click.Y.ToString + vbCrLf + "Inside: " + isInside.ToString
        If (isInside) Then
            RichTextBox1.Text = RichTextBox1.Text + vbCrLf +
            "Max X: " + clickedPolygon.maxX.ToString + vbCrLf +
            "Min X: " + clickedPolygon.minX.ToString + vbCrLf +
            "Max Y: " + clickedPolygon.maxY.ToString + vbCrLf +
            "Min Y: " + clickedPolygon.minY.ToString + vbCrLf +
            "PolygonName: " + clickedPolygon.polygonName
        End If
        polygons(0).Fill(PictureBox1, Brushes.Blue)
    End Sub
End Class
