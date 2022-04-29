<Serializable>
Public Class AppSettingsSerializable
    Private _CSVExporterDelimiter As String = AppSettings.CSVExporterDelimiter
    Private _CSVExporterTextQualifier As String = AppSettings.CSVExporterTextQualifier
    Private _CachePath As String = AppSettings.CachePath
    Private _mainColor As Color = AppSettings.MainColor
    Private _secondaryColor As Color = AppSettings.SecondaryColor
    Private _buttonColorMap As Color = AppSettings.ButtonColorMap
    Private _buttonColorStatistics As Color = AppSettings.ButtonColorStatistics
    Private _buttonColorTelegram As Color = AppSettings.ButtonColorTelegram
    Private _buttonColorSettings As Color = AppSettings.ButtonColorTelegram
    Private _buttonColorExit As Color = AppSettings.ButtonColorExit
    Private _popupColorMain As Color = AppSettings.PopupColorMain
    Private _popupColorSecondary As Color = AppSettings.PopupColorSecondary
    Public Sub UpdateAppSettings()
        AppSettings.CachePath = _CachePath
        AppSettings.CSVExporterDelimiter = _CSVExporterDelimiter
        AppSettings.CSVExporterTextQualifier = _CSVExporterTextQualifier
        AppSettings.MainColor = _mainColor
        AppSettings.SecondaryColor = _secondaryColor
        AppSettings.ButtonColorMap = _buttonColorMap
        AppSettings.ButtonColorStatistics = _buttonColorStatistics
        AppSettings.ButtonColorTelegram = _buttonColorTelegram
        AppSettings.ButtonColorSettings = _buttonColorSettings
        AppSettings.ButtonColorExit = _buttonColorExit
        AppSettings.PopupColorMain = _popupColorMain
        AppSettings.PopupColorSecondary = _popupColorSecondary
    End Sub
End Class
