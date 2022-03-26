Imports CoronaStatisticsGetter
Imports System.Net.WebClient
Imports System.Net
Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Math
Imports Map
Public Class test1
    Private request As New CRequest
    Private result As CStatList

    Private Sub MapControl1_Click(clickPosition As Point, polygonName As String) Handles MapControl1.Clicked
        RichTextBox1.Text =
            "X: " + clickPosition.X.ToString + vbCrLf +
            "Y: " + clickPosition.Y.ToString + vbCrLf +
            "Polygon name: " + polygonName
        'MapControl1.polygons.GetPolygonWhereName(TextBox1.Text).NamePoint = New Point(clickPosition.X, clickPosition.Y)
        'MapControl1.polygons.DrawAll(MapControl1.mapPictureBox, True)
    End Sub

    Private Sub MapControl1_Load(sender As Object, e As EventArgs)

    End Sub
End Class