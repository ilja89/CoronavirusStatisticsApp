' FILENAME: moreStatCounty.vb
' AUTOR: El Plan - Ilja Kuznetsov, Alexandr Ivantsov
' CREATED: 10.04.2022
' CHANGED: 01.05.2022
'
' DESCRIPTION: See below
'
' RELATED COMPONENTS: ...
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Math
Imports StatisticsObject
Imports StatisticsFunctions
Imports CoronaStatisticsGetter
Imports CSVExporterDNF

''' <summary>
''' Form, what shows advanced statistics for county
''' </summary>
Public Class moreStatCounty
    Private _CSVExporter As IExporter = New CExporter(AppSettings.CSVExporterDelimiter, AppSettings.CSVExporterTextQualifier)
    Private _dateFrom As DateTime = New DateTime(2020, 1, 1)
    Private _dateTo As DateTime = DateTime.Now.AddDays(-2)
    Private _statObject As CStatList
    Private _statObjectValueField As String
    Private _seriesStatList As New List(Of KeyValuePair(Of String, IStatList))
    Private _curSeriesStatList As New List(Of KeyValuePair(Of String, IStatList))

    Private Sub WhenLoaded() Handles Me.Load
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
        fromDate.MaxDate = DateTime.Now.AddDays(-2)
        toDate.MaxDate = DateTime.Now.AddDays(-2)
    End Sub

    Public Sub Init(newFormName As String, statistics As IStatList, valueField As String, countyKey() As String)
        Me.Text = newFormName
        _statObject = statistics
        For Each county As String In countyKey
            AddSeries(county)
        Next
        _statObjectValueField = valueField
        UpdateChart()
    End Sub

    Public Sub AddSeries(countyKey As String)
        If (Not Chart1.Series.IsUniqueName(countyKey)) Then
            Exit Sub
        End If
        _seriesStatList.Add(New KeyValuePair(Of String, IStatList)(countyKey, _statObject.AsNew.Where("County", countyKey)))
        _curSeriesStatList.Add(New KeyValuePair(Of String, IStatList)(countyKey, _statObject.AsNew.Where("County", countyKey)))
        Dim newSeries As Series = New Series(countyKey)
        newSeries.ChartType = SeriesChartType.Line
        newSeries.BorderWidth = 3
        Chart1.Series.Add(newSeries)
        selectedCountyListBox.Items.Add(countyKey)
        addCountyCombobox.Items.Remove(countyKey)
    End Sub
    Public Sub DeleteSeries(countyKey As String)
        Dim i As Integer = 0
        selectedCountyListBox.Items.Remove(countyKey)
        addCountyCombobox.Items.Add(countyKey)
        Chart1.Series.Remove(Chart1.Series.FindByName(countyKey))
        While (i < _seriesStatList.Count - 1)
            If (_seriesStatList(i).Key = countyKey) Then
                _seriesStatList.RemoveAt(i)
                _curSeriesStatList.RemoveAt(i)
            End If
            i += 1
        End While
    End Sub

    Private Sub UpdateChart()
        Dim series As SeriesCollection = Chart1.Series
        Dim fromDate As String = DateTimeToString(_dateFrom)
        Dim toDate As String = DateTimeToString(_dateTo)
        For i As Integer = 0 To series.Count - 1
            For itemIndex As Integer = 0 To _seriesStatList.Count - 1
                If (_seriesStatList(itemIndex).Key = series(i).Name) Then
                    _curSeriesStatList(itemIndex) = New KeyValuePair(Of String, IStatList) _
                    (_seriesStatList(itemIndex).Key, _seriesStatList(itemIndex).Value.AsNew.WhereDate(fromDate, ">=").WhereDate(toDate, "<="))
                    Dim XY As Array = StatListToXY(_curSeriesStatList(itemIndex).Value, AppConstants.GetPopulationByCountyName(series(i).Name))
                    If (XY IsNot Nothing) Then
                        series(i).Points.DataBindXY(XY(0), XY(1))
                    End If
                    Exit For
                End If
            Next

        Next
    End Sub

    Private Function DateTimeToString(dateTimeObject As DateTime)
        Return String.Join("-", dateTimeObject.ToString.Split(" ")(0).Split(".").Reverse)
    End Function

    Private Function StatListToXY(stat As IStatList, countyPopulation As Integer)
        If (stat.Count > 0) Then
            Dim stringDate As String() = stat.GetFields("Date")
            Dim x(stringDate.Length - 1) As DateTime
            For i As Integer = 0 To stringDate.Length - 1
                Dim spl As String() = stringDate(i).Split("-")
                x(i) = New DateTime(spl(0), spl(1), spl(2))
            Next
            Dim y(stat.Count - 1) As Double
            Dim arr = stat.GetFields(_statObjectValueField)
            If (absoluteValueCheckBox.Checked) Then
                For i As Integer = 0 To arr.Length - 1
                    y(i) = CInt(arr(i))
                Next
            Else
                For i As Integer = 0 To arr.Length - 1
                    y(i) = 100 * (arr(i) / countyPopulation)
                Next
            End If
            Return {x, y}
        End If
        Return Nothing
    End Function
    Private Function DateCmp(date1 As String, date2 As String) As Integer
        For c As Integer = 0 To Min(date1.Length, date2.Length) - 1
            If (date1.Chars(c) > date2.Chars(c)) Then
                Return 1
            ElseIf (date1.Chars(c) < date2.Chars(c)) Then
                Return -1
            End If
        Next
        Return 0
    End Function
    Private Sub ColorSettingsAppliedHandler()
        Panel1.BackColor = MainColor
        Chart1.BackColor = SecondaryColor
        absoluteValueCheckBox.BackColor = SecondaryColor
        addCountyCombobox.BackColor = SecondaryColor
        addCountyLabel.BackColor = SecondaryColor
        countyActionsLabel.BackColor = SecondaryColor
        appendCheckBox.BackColor = SecondaryColor
    End Sub
    Private Sub MeClosingHandler() Handles Me.Closing
        RemoveHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
    End Sub

    Private Sub addCountyCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles addCountyCombobox.SelectedIndexChanged
        AddSeries(addCountyCombobox.SelectedItem)
        UpdateChart()
    End Sub

    Private Sub removeCountyButton_Click(sender As Object, e As EventArgs) Handles removeCountyButton.Click
        If (selectedCountyListBox.SelectedItem <> Nothing) Then
            DeleteSeries(selectedCountyListBox.SelectedItem)
        End If
    End Sub
    Private Sub saveStatButton_Click(sender As Object, e As EventArgs) Handles saveStatButton.Click
        If (selectedCountyListBox.SelectedItem = Nothing) Then
            Exit Sub
        End If

        _CSVExporter.setFileToSave
        For Each item As KeyValuePair(Of String, IStatList) In _curSeriesStatList
            If (item.Key = selectedCountyListBox.SelectedItem) Then
                _CSVExporter.saveDataToCSV(item.Value.ToCSVStrings(CSVExporterDelimiter, CSVExporterTextQualifier), appendCheckBox.Checked)
                Exit For
            End If
        Next
    End Sub

    Private Sub fromDate_CloseUp(sender As Object, e As EventArgs) Handles fromDate.CloseUp
        If (fromDate.Value > toDate.Value) Then
            toDate.Value = fromDate.Value
        End If
        _dateFrom = fromDate.Value
        UpdateChart()
    End Sub

    Private Sub toDate_CloseUp(sender As Object, e As EventArgs) Handles toDate.CloseUp
        If (toDate.Value < fromDate.Value) Then
            fromDate.Value = fromDate.Value
        End If
        _dateTo = toDate.Value
        UpdateChart()
    End Sub

    Private Sub absoluteValueCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles absoluteValueCheckBox.CheckedChanged
        UpdateChart()
    End Sub
End Class