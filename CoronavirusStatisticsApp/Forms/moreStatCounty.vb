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

''' <summary>
''' Form, what shows advanced statistics for county
''' </summary>
Public Class moreStatCounty
    Private _limit As Integer
    Private _dateFrom As DateTime
    Private _dateTo As DateTime
    Private _statObject As CStatList
    Private _statObjectValueField As String

    Private Sub WhenLoaded() Handles Me.Load
        Chart1.Series(0).ChartType = SeriesChartType.Line
        Chart1.Series(0).BorderWidth = 3
        Chart1.Series(0).IsValueShownAsLabel = False
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
        statypeSelector.Visible = False
        countySelector.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        clearBtn.Visible = False

    End Sub
    Private Sub DatePicker_CloseUp(sender As Object, e As EventArgs)
        Dim newDateFrom As DateTime = fromDate.Value
        Dim newDateTo As DateTime = toDate.Value
        If (_dateFrom <> newDateFrom Or _dateTo <> newDateTo) Then
            _dateFrom = newDateFrom
            _dateTo = newDateTo
            Dim temp As CStatList = _statObject.AsNew.WhereDate(DateTimeToString(_dateFrom), ">=").
                WhereDate(DateTimeToString(_dateTo), "<=")
            If (temp.Count > 0) Then
                Dim XY As Array = StatListToXY(temp)
                Dim dateNow As DateTime = DateTime.Now
                Dim diff As Integer = (_dateTo - dateNow).Days

                Chart1.Series(0).Points.DataBindXY(XY(0), XY(1))

                If (diff > 0) Then
                    Dim forecast As CStatList = CStatFunctions.Forecast(temp, _statObjectValueField,, 14, diff)
                    forecast.WhereDate(DateTimeToString(dateNow), ">=")
                    Dim dateNowString = DateTimeToString(dateNow)
                    For i As Integer = 0 To forecast.Count - 1
                        If (forecast.GetField(i, _statObjectValueField) = 0) Then
                            For j As Integer = forecast.Count - 1 To i Step -1
                                forecast.Remove(j)
                            Next
                            Exit For
                        End If
                    Next
                    XY = StatListToXY(forecast)
                    If (Chart1.Series.IsUniqueName("Forecast") = True) Then
                        Dim newSeries As Series = New Series("Forecast")
                        newSeries.Points.DataBindXY(XY(0), XY(1))

                        newSeries.ChartType = SeriesChartType.Line
                        newSeries.BorderWidth = 3
                        Chart1.Series.Add(newSeries)
                    Else
                        Chart1.Series.FindByName("Forecast").Points.DataBindXY(XY(0), XY(1))
                    End If
                ElseIf (Not Chart1.Series.IsUniqueName("Forecast")) Then
                    Chart1.Series.Remove(Chart1.Series.FindByName("Forecast"))
                End If
                Chart1.Update()
            End If
        End If
    End Sub
    Public Sub Init(polygonKey As String, newStatObject As CStatList, statType As String, newStatObjectValueField As String)
        Chart1.Series(0).LegendText = statType
        Chart1.Series(0).ChartType = SeriesChartType.Line
        Chart1.Series(0).IsValueShownAsLabel = True
        maakondLabel.Text = polygonKey

        Dim keys() As String = {"Harju maakond", "Ida-Viru maakond", "Lääne-Viru maakond",
            "Järva maakond", "Jõgeva maakond", "Võru maakond",
            "Põlva maakond", "Valga maakond", "Tartu maakond", "Pärnu maakond",
            "Rapla maakond", "Lääne maakond", "Saare maakond", "Hiiu maakond",
           "Viljandi maakond"}

        Dim value() As Integer = {AppConstants.HARJU_POPULATION, AppConstants.IDA_VURU_POPULATION,
            AppConstants.LAANE_VURU_POPULATION, AppConstants.JARVA_POPULATION,
            AppConstants.JOGEVA_POPULATION, AppConstants.VORU_POPULATION, AppConstants.POLVA_POPULATION,
            AppConstants.VALGA_POPULATION, AppConstants.TARTU_POPULATION, AppConstants.PARNU_POPULATION,
            AppConstants.RAPLA_POPULATION, AppConstants.LAANE_POPULATION, AppConstants.SAARE_POPULATION,
            AppConstants.HIIU_POPULATION, AppConstants.VILJANDI_POPULATION}

        _statObject = newStatObject
        _statObjectValueField = newStatObjectValueField

        Me.Text = statType
        For i As Integer = 0 To keys.Length - 1
            If keys(i) = polygonKey Then
                '    _limit = value(i)
            End If
        Next
        AddHandler fromDate.CloseUp, AddressOf DatePicker_CloseUp
        AddHandler toDate.CloseUp, AddressOf DatePicker_CloseUp
        DatePicker_CloseUp(Nothing, Nothing)
    End Sub

    Private Function StatListToXY(stat As CStatList)
        Dim stringDate As String() = stat.GetFields("Date")
        Dim x(stringDate.Length - 1) As DateTime
        For i As Integer = 0 To stringDate.Length - 1
            Dim spl As String() = stringDate(i).Split("-")
            x(i) = New DateTime(spl(0), spl(1), spl(2))
        Next
        Dim y(stat.Count - 1) As Integer
        Dim arr = stat.GetFields(_statObjectValueField)
        For i As Integer = 0 To arr.Length - 1
            y(i) = CInt(arr(i))
        Next
        Return {x, y}
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
        maakondLabel.BackColor = SecondaryColor
    End Sub
    Private Sub MeClosingHandler() Handles Me.Closing
        RemoveHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
    End Sub
    Private Function DateTimeToString(dateTimeObject As DateTime)
        Return String.Join("-", dateTimeObject.ToString.Split(" ")(0).Split(".").Reverse)
    End Function

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs) Handles dropDownBtn.Click
        statypeSelector.Visible = True
        countySelector.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        clearBtn.Visible = True
    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        statypeSelector.Visible = False
        countySelector.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        clearBtn.Visible = False
    End Sub

    Private Sub dropDownCounty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statypeSelector.SelectedIndexChanged
        If statypeSelector.SelectedIndex = "Testid kokku" Then

        ElseIf statypeSelector.SelectedIndex = "Nakatanud kokkud" Then

        ElseIf statypeSelector.SelectedIndex = "Vaktsineeritud kokku" Then

        Else

        End If


    End Sub
End Class