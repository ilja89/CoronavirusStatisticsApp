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
            MapControl1.MapPolygons.SetGradientWhereName(polygonName, newGradient)
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1._UpdatePolygonsWhereName(polygonName)
        End If
    End Sub

    Private Sub applyToAllButton_Click(sender As Object, e As EventArgs) Handles applyAllButton.Click
        If (colorComboBox.Text <> " ") Then
            Dim newGradient As New CGradient
            newGradient = CallByName(newGradient, colorComboBox.Text, vbMethod)
            MapControl1.DefGradient = newGradient
            MapControl1._SetAllPolygonsToDefault()
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1._Update()
        End If
    End Sub
    Private Sub simpleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles simpleCheckBox.CheckedChanged
        MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
        MapControl1._Update()
    End Sub

    Private Sub Gradient_Click(sender As Object, e As EventArgs) Handles gradientButton.Click
        Dim rand As New Random
        MapControl1._DrawLevelGradient({
                New KeyValuePair(Of String, Integer)("Hiiu maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Saare maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Lääne maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Harju maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Rapla maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Pärnu maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Viljandi maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Tartu maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Valga maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Võru maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Järva maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Lääne-Viru maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Ida-Viru maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Jõgeva maakond", rand.Next(0, 1000)),
                New KeyValuePair(Of String, Integer)("Põlva maakond", rand.Next(0, 1000))
                }, {
                (New CGradient).BrightBlue,
                (New CGradient).Green,
                (New CGradient).Yellow,
                (New CGradient).Orange,
                (New CGradient).Red
                }, (New CGradient).Gray)
    End Sub
    Private Sub borderColorButton_Click(sender As Object, e As EventArgs) Handles borderColorButton.Click
        If (colorComboBox.Text <> " ") Then
            Dim newGradient As New CGradient
            newGradient = CallByName(newGradient, colorComboBox.Text, vbMethod)
            MapControl1.DefBorderPen = New Pen(New SolidBrush(newGradient.CenterColor),
                                                   MapControl1.DefBorderPen.Width)
            MapControl1._SetAllPolygonsToDefault(True, False, False)
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1._Update()
        End If
    End Sub
    Private Sub borderWidthButton_Click(sender As Object, e As EventArgs) Handles borderWidthButton.Click
        If (Val(borderWidthTextBox.Text) > 0) Then
            MapControl1.DefBorderPen = New Pen(MapControl1.DefBorderPen.Brush,
                                                   CSng(Val(borderWidthTextBox.Text)))
            MapControl1._SetAllPolygonsToDefault(, False, False)
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1._Update()
        End If
    End Sub
    Private Sub fontButton_Click(sender As Object, e As EventArgs) Handles fontButton.Click
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            MapControl1.MapFont = FontDialog1.Font
            MapControl1.SimplePolygonsDraw = simpleCheckBox.Checked
            MapControl1._Update()
        End If
    End Sub
    Private Sub drawEmptyButton_Click(sender As Object, e As EventArgs) Handles drawEmptyButton.Click
        MapControl1.FillPolygons = False
        MapControl1._Update()
        MapControl1.FillPolygons = True
    End Sub

    Private Sub mapTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class