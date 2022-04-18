Imports CoronaStatisticsGetter
Imports System.Windows.Forms.DataVisualization.Charting
Public Class moreStatCounty
    Private _limit As Integer
    Private _dateFrom As String = ""
    Private _dateTo As String = ""
    Private _statObject As CStatList

    Private Sub WhenLoaded() Handles Me.Load
        DatePicker_ValueChanged(Nothing, Nothing)
        Chart1.Series(0).LegendText = "Vaccinations"
        Chart1.Series(0).ChartType = SeriesChartType.Line
        Chart1.Series(0).IsValueShownAsLabel = True
    End Sub
    Private Sub DatePicker_ValueChanged(sender As Object, e As EventArgs) Handles toDate.ValueChanged, fromDate.ValueChanged
        _dateFrom = String.Join(".", fromDate.Value.ToString.Split(" ")(0).Split(".").Reverse)
        _dateTo = String.Join(".", toDate.Value.ToString.Split(" ")(0).Split(".").Reverse)
        Dim x() As String = {"data1", "data2", "data3"}
        Dim y() As Integer = {10, 20, 5}
        Chart1.Series(0).Points.DataBindXY(x, y)
    End Sub
    Public Sub Init(polygonKey As String, newStatObject As CStatList, statType As String)
        Dim keys() As String = {""}
        Dim value() As Integer = {}
        _statObject = newStatObject
        Me.Text = statType
        For i As Integer = 0 To keys.Length - 1
            If keys(i) = polygonKey Then
                _limit = value(i)
            End If
        Next

        If (polygonKey = "Harju maakond") Then
            _limit = 621281

        ElseIf (polygonKey = "Ida-Viru maakond") Then
            _limit = 131913

        ElseIf (polygonKey = "Ida-Viru maakond") Then
            _limit = 58402

        ElseIf (polygonKey = "Järva maakond") Then
            _limit = 29817

        ElseIf (polygonKey = "Jõgeva maakond") Then
            _limit = 13262

        ElseIf (polygonKey = "Võru maakond") Then
            _limit = 34898

        ElseIf (polygonKey = "Põlva maakond") Then
            _limit = 24473

        ElseIf (polygonKey = "Valga maakond") Then
            _limit = 11792

        ElseIf (polygonKey = "Tartu maakond") Then
            _limit = 95430

        ElseIf (polygonKey = "Pärnu maakond") Then
            _limit = 50639

        ElseIf (polygonKey = "Rapla maakond") Then
            _limit = 33116

        ElseIf (polygonKey = "Lääne maakond") Then
            _limit = 24301

        ElseIf (polygonKey = "Saare maakond") Then
            _limit = 30973

        ElseIf (polygonKey = "Hiiu maakond") Then
            _limit = 9381

        ElseIf (polygonKey = "Viljandi maakond") Then
            _limit = 45877
        End If

    End Sub
End Class