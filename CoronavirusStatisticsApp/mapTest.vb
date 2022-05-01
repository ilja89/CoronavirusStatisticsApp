Imports CoronaStatisticsGetter
Imports System.Net.WebClient
Imports System.Net
Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Math
Imports Map
Public Class mapTest
    Private Sub MapControl1_Click(clickPosition As Point, polygonName As String, polygonKey As String) Handles MapControl1.Clicked
        RichTextBox1.Text =
                "X: " + clickPosition.X.ToString + vbCrLf +
                "Y: " + clickPosition.Y.ToString + vbCrLf +
                "Polygon name: " + polygonName
        If (polygonName <> Nothing AndAlso colorComboBox.Text <> " ") Then
            Dim newGradient As New CGradient
            newGradient = CallByName(newGradient, colorComboBox.Text, vbMethod)
            MapControl1.Polygons.SetGradientWhereName(polygonName, newGradient)
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1.MapUpdatePolygonsWhereName(polygonName)
        End If
    End Sub

    Private Sub applyToAllButton_Click(sender As Object, e As EventArgs) Handles applyAllButton.Click
        If (colorComboBox.Text <> " ") Then
            Dim newGradient As New CGradient
            newGradient = CallByName(newGradient, colorComboBox.Text, vbMethod)
            MapControl1.DefGradient = newGradient
            MapControl1.MapSetAllPolygonsToDefault()
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1.MapUpdate()
        End If
    End Sub
    Private Sub simpleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles simpleCheckBox.CheckedChanged
        MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
        MapControl1.MapUpdate()
    End Sub

    Private Sub Gradient_Click(sender As Object, e As EventArgs) Handles gradientButton.Click
        Dim rand As New Random
        MapControl1.MapDrawLevelGradient({
                New KeyValuePair(Of String, Double)("Hiiu maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Saare maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Lääne maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Harju maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Rapla maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Pärnu maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Viljandi maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Tartu maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Valga maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Võru maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Järva maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Lääne-Viru maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Ida-Viru maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Jõgeva maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Double)("Põlva maakond", rand.Next(0, 1000))
                }, {
                CGradient.BrightBlue,
                CGradient.Green,
                CGradient.Yellow,
                CGradient.Orange,
                CGradient.Red
                }, CGradient.Gray)
    End Sub
    Private Sub borderColorButton_Click(sender As Object, e As EventArgs) Handles borderColorButton.Click
        If (colorComboBox.Text <> " ") Then
            Dim newGradient As New CGradient
            newGradient = CallByName(newGradient, colorComboBox.Text, vbMethod)
            MapControl1.DefBorderPen = New Pen(New SolidBrush(newGradient.CenterColor),
                                                   MapControl1.DefBorderPen.Width)
            MapControl1.MapSetAllPolygonsToDefault(True, False, False)
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1.MapUpdate()
        End If
    End Sub
    Private Sub borderWidthButton_Click(sender As Object, e As EventArgs) Handles borderWidthButton.Click
        If (Val(borderWidthTextBox.Text) > 0) Then
            MapControl1.DefBorderPen = New Pen(MapControl1.DefBorderPen.Brush,
                                                   CSng(Val(borderWidthTextBox.Text)))
            MapControl1.MapSetAllPolygonsToDefault(, False, False)
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1.MapUpdate()
        End If
    End Sub
    Private Sub fontButton_Click(sender As Object, e As EventArgs) Handles fontButton.Click
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            MapControl1.MapFont = FontDialog1.Font
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1.MapUpdate()
        End If
    End Sub
    Private Sub drawEmptyButton_Click(sender As Object, e As EventArgs) Handles drawEmptyButton.Click
        MapControl1.FillPolygons = False
        MapControl1.MapUpdate()
        MapControl1.FillPolygons = True
    End Sub

    Private Sub mapTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class