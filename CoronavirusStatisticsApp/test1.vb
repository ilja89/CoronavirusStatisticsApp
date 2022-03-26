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
        MapControl1._DrawLevelGradient({
                    New KeyValuePair(Of String, Integer)("Hiiumaa", 0),
                    New KeyValuePair(Of String, Integer)("Saaremaa", 100),
                    New KeyValuePair(Of String, Integer)("Laenemaa", 50),
                    New KeyValuePair(Of String, Integer)("Harjumaa", 50),
                    New KeyValuePair(Of String, Integer)("Raplamaa", 0),
                    New KeyValuePair(Of String, Integer)("Parnumaa", 25),
                    New KeyValuePair(Of String, Integer)("Viljandimaa", 25),
                    New KeyValuePair(Of String, Integer)("Tartumaa", 75),
                    New KeyValuePair(Of String, Integer)("Valgamaa", 75),
                    New KeyValuePair(Of String, Integer)("Polvamaa", 0),
                    New KeyValuePair(Of String, Integer)("Vorumaa", 45),
                    New KeyValuePair(Of String, Integer)("Jogevamaa", 20),
                    New KeyValuePair(Of String, Integer)("Jarvamaa", 80),
                    New KeyValuePair(Of String, Integer)("Laene-Virumaa", 60),
                    New KeyValuePair(Of String, Integer)("Ida-Virumaa", 55)
                    },
                    (New Gradient).Green,
                    (New Gradient).Yellow,
                    (New Gradient).Red,
                    (New Gradient).Gray)
        'MapControl1.polygons.GetPolygonWhereName(TextBox1.Text).NamePoint = New Point(clickPosition.X, clickPosition.Y)
        'MapControl1.polygons.DrawAll(MapControl1.mapPictureBox, True)
    End Sub

    Private Sub MapControl1_Load(sender As Object, e As EventArgs)

    End Sub
End Class