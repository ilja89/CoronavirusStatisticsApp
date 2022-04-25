<Serializable>
Public Class AppSettingsSerializable
    Private _CSVExporterDelimiter As String = AppSettings.CSVExporterDelimiter
    Private _CSVExporterTextQualifier As String = AppSettings.CSVExporterTextQualifier
    Private _CachePath As String = AppSettings.CachePath
    Public Sub UpdateAppSettings()
        AppSettings.CachePath = _CachePath
        AppSettings.CSVExporterDelimiter = _CSVExporterDelimiter
        AppSettings.CSVExporterTextQualifier = _CSVExporterTextQualifier
    End Sub
End Class
