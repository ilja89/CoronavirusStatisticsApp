Imports StatisticsObject
Imports CoronaStatisticsGetter
Imports CSVExporterDNF
Public Class statSave
    Public ReadOnly FormName As String = "Statistika"

    Private _exporter As IExporter = New CExporter(AppSettings.CSVExporterDelimiter, AppSettings.CSVExporterTextQualifier)
    Private _statList As IStatList
    Private _request As IRequest = New CRequest(AppSettings.CachePath)
    Private _byCounty As Boolean = False
    Private _append As Boolean = False
    Private _delegate() As Action = {Sub() SickGlobal(), Sub() SickLocal(), Sub() TestGlobal(), Sub() TestLocal(),
        Sub() VactGlobal(), Sub() VactLocal(), Sub() DeceasedGlobal(), Sub() HospitalizedPatients()}
    Private Sub WhenLoaded() Handles Me.Load
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
        dateTo.MaxDate = DateTime.Now.AddDays(-2)
        dateFrom.MaxDate = DateTime.Now.AddDays(-2)
        dateFrom.Value = dateFrom.MinDate
        infoLabel.Hide()
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        BackColor = AppSettings.MainColor
    End Sub

    Private Sub SickGlobal()
        _byCounty = False
        countyComboBox.Hide()
        _statList = _request.GetSick
    End Sub

    Private Sub SickLocal()
        _byCounty = True
        countyComboBox.Show()
        _statList = _request.GetSickCounty()
    End Sub

    Private Sub TestGlobal()
        _byCounty = False
        countyComboBox.Hide()
        _statList = _request.GetTestStatPositiveGeneral
    End Sub

    Private Sub TestLocal()
        _byCounty = True
        countyComboBox.Show()
        _statList = _request.GetTestStatCounty()
    End Sub

    Private Sub VactGlobal()
        _byCounty = False
        countyComboBox.Hide()
        _statList = _request.GetVaccinationStatGeneral
    End Sub

    Private Sub VactLocal()
        _byCounty = True
        countyComboBox.Show()
        _statList = _request.GetVaccinationStatByCounty
    End Sub

    Private Sub DeceasedGlobal()
        _byCounty = False
        countyComboBox.Hide()
        _statList = _request.GetDeceased()
    End Sub

    Private Sub HospitalizedPatients()
        _byCounty = False
        countyComboBox.Hide()
        _statList = _request.GetHospitalizationPatients
    End Sub

    Private Sub statTypeCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statTypeCombobox.SelectedIndexChanged
        _delegate(statTypeCombobox.SelectedIndex)()
    End Sub

    Private Function DateTimeToString(dateTimeObject As DateTime)
        Return String.Join("-", dateTimeObject.ToString.Split(" ")(0).Split(".").Reverse)
    End Function

    Private Sub dateFrom_CloseUp(sender As Object, e As EventArgs) Handles dateFrom.CloseUp
        If (dateFrom.Value > dateTo.Value) Then
            dateTo.Value = dateFrom.Value
        End If
    End Sub

    Private Sub dateTo_CloseUp(sender As Object, e As EventArgs) Handles dateTo.CloseUp
        If (dateFrom.Value > dateTo.Value) Then
            dateFrom.Value = dateTo.Value
        End If
    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        If (_statList Is Nothing) Then
            infoLabel.Show()
            infoLabel.Text = "Empty combobox"
            Exit Sub
        End If

        Dim data As IStatList = _statList.AsNew
        data.WhereDate(DateTimeToString(dateFrom.Value), ">=").
            WhereDate(DateTimeToString(dateTo.Value), "<=")
        If (_byCounty = True) Then
            data.Where("County", countyComboBox.Text)
        End If
        If (data.Count > 0) Then
            _exporter.setFileToSave()
            _exporter.saveDataToCSV(data.ToCSVStrings(AppSettings.CSVExporterDelimiter, AppSettings.CSVExporterTextQualifier), _append)
            infoLabel.Hide()
        Else
            infoLabel.Show()
            infoLabel.Text = "No data for selected date"
        End If
    End Sub

    Private Sub appendCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles appendCheckBox.CheckedChanged
        _append = appendCheckBox.Checked
    End Sub
End Class