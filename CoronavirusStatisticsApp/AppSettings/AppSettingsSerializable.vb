' FILENAME: AppSettingsSerializable.vb
' AUTOR: El Plan - Ilja Kuznetsov
' CREATED: 25.04.2022
' CHANGED: 02.05.2022
'
' DESCRIPTION: See below
'
' PRECONDITIONS: AppSettings.vb exists and has required properties
' SUBSEQUENT CONDITIONS: ...
' RELATED COMPONENTS: ...

''' <summary>
''' Used to save AppSettings.vb information in serializable form
''' </summary>
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
    Private _telegramBotToken As String = AppSettings.TelegramBotToken
    Private _telegramBotChatID As String = AppSettings.TelegramBotChatID
    Private _telegramBotEnabled As Boolean = AppSettings.TelegramBotEnabled
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
        AppSettings.TelegramBotToken = _telegramBotToken
        AppSettings.TelegramBotChatID = _telegramBotChatID
        AppSettings.TelegramBotEnabled = _telegramBotEnabled
    End Sub
End Class
