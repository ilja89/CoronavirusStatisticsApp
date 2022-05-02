Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Math
Imports StatisticsObject
Imports StatisticsFunctions
Imports CoronaStatisticsGetter
Imports CSVExporterDNF

Public Class moreStatGeneral
    Private _CSVExporter As IExporter = New CExporter(AppSettings.CSVExporterDelimiter, AppSettings.CSVExporterTextQualifier)
    Private _dateFrom As DateTime = New DateTime(2020, 1, 1)
    Private _dateTo As DateTime = DateTime.Now.AddDays(-2)
    Private _statObject As IStatList
    Private _statObjectValueField As String
    Private _curSeriesStatList As IStatList
    Private _lineWidth As Integer = 2

    Private Sub WhenLoaded() Handles Me.Load
        Dim pic As Bitmap = Bitmap.FromFile(AppSettings.ResourcesPath + "icon.ico")
        Me.Icon = System.Drawing.Icon.FromHandle(pic.GetHicon)
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
        fromDate.MaxDate = DateTime.Now.AddDays(-2)
        toDate.MaxDate = DateTime.Now.AddDays(-2)
        Chart1.AntiAliasing = True
    End Sub

    Public Sub Init(newFormName As String, statistics As IStatList, valueField As String)
        Me.Text = newFormName
        _statObject = statistics
        _statObjectValueField = valueField
        Dim newSeries As Series = New Series(newFormName)
        newSeries.ChartType = SeriesChartType.Line
        newSeries.BorderWidth = _lineWidth
        Chart1.Series.Add(newSeries)
        UpdateChart()
    End Sub

    Public Sub AddSeries(countyKey As String)

        Dim newSeries As Series = New Series()
        newSeries.ChartType = SeriesChartType.Line
        newSeries.BorderWidth = _lineWidth
        Chart1.Series.Add(newSeries)
    End Sub

    Private Sub UpdateChart()
        Dim series As SeriesCollection = Chart1.Series
        Dim fromDate As String = DateTimeToString(_dateFrom)
        Dim toDate As String = DateTimeToString(_dateTo)
        _curSeriesStatList = _statObject.AsNew.WhereDate(fromDate, ">=").WhereDate(toDate, "<=")
        Dim XY As Array = StatListToXY(_curSeriesStatList)
        If (XY IsNot Nothing) Then
            series(0).Points.DataBindXY(XY(0), XY(1))
        End If
    End Sub

    Private Function DateTimeToString(dateTimeObject As DateTime)
        Return String.Join("-", dateTimeObject.ToString.Split(" ")(0).Split(".").Reverse)
    End Function

    Private Function StatListToXY(stat As IStatList)
        If (stat.Count > 0) Then
            Dim stringDate As String() = stat.GetFields("Date")
            Dim x(stringDate.Length - 1) As DateTime
            For i As Integer = 0 To stringDate.Length - 1
                Dim spl As String() = stringDate(i).Split("-")
                x(i) = New DateTime(spl(0), spl(1), spl(2))
            Next
            Dim y(stat.Count - 1) As Double
            Dim arr = stat.GetFields(_statObjectValueField)
            For i As Integer = 0 To arr.Length - 1
                y(i) = CInt(arr(i))
            Next
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
        Me.BackColor = AppSettings.MainColor
        Chart1.BackColor = SecondaryColor
    End Sub
    Private Sub MeClosingHandler() Handles Me.Closing
        RemoveHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
    End Sub
    Private Sub saveStatBtn_Click(sender As Object, e As EventArgs) Handles saveStatBtn.Click
        _CSVExporter.setFileToSave()
        _CSVExporter.saveDataToCSV(_curSeriesStatList.ToCSVStrings(CSVExporterDelimiter, CSVExporterTextQualifier), CheckBox1.Checked)
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


End Class