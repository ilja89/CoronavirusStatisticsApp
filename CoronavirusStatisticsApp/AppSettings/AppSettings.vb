' FILENAME: AppSettings.vb
' AUTOR: El Plan - Ilja Kuznetsov
' CREATED: 25.04.2022
' CHANGED: 02.05.2022
'
' DESCRIPTION: See below
'
' PRECONDITIONS: ...
' SUBSEQUENT CONDITIONS: ...
' RELATED COMPONENTS: ...
''' <summary>
''' Provides static object what stores all applications settings
''' </summary>
Module AppSettings
    Public Event NewColorSettingsApplied()

    Public ReadOnly AppSettingsCachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Settings\"
    Public ReadOnly AppSettingsCacheName As String = "AppSettings"
    Public ReadOnly DefaultCSVExporterDelimiter As String = ":"
    Public ReadOnly DefaultCSVExporterTextQualifier As String = ""
    Public ReadOnly DefaultCachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Public ReadOnly DefaultMainColor As Color = Color.Gray
    Public ReadOnly DefaultSecondaryColor As Color = Color.DarkGray
    Public ReadOnly DefaultButtonColorMap As Color = Color.LawnGreen
    Public ReadOnly DefaultButtonColorStatistics As Color = Color.Cyan
    Public ReadOnly DefaultButtonColorTelegram As Color = Color.MediumVioletRed
    Public ReadOnly DefaultButtonColorSettings As Color = Color.FromArgb(205, 205, 13)
    Public ReadOnly DefaultButtonColorExit As Color = Color.Pink
    Public ReadOnly DefaultPopupColorMain As Color = Color.Silver
    Public ReadOnly DefaultPopupColorSecondary As Color = Color.DimGray
    Public ReadOnly DefaultTelegramBotEnabled As Boolean = False

    Private _CSVExporterDelimiter As String
    Private _CSVExporterTextQualifier As String
    Private _cachePath As String
    Private _mainColor As Color
    Private _secondaryColor As Color
    Private _buttonColorMap As Color
    Private _buttonColorStatistics As Color
    Private _buttonColorTelegram As Color
    Private _buttonColorSettings As Color
    Private _buttonColorExit As Color
    Private _popupColorMain As Color
    Private _popupColorSecondary As Color
    Private _telegramBotToken As String
    Private _telegramBotChatID As String
    Private _telegramBotEnabled As Boolean

    Public Property CSVExporterDelimiter As String
        Get
            If (_CSVExporterDelimiter <> Nothing) Then
                Return _CSVExporterDelimiter
            Else
                _CSVExporterDelimiter = DefaultCSVExporterDelimiter
                Return DefaultCSVExporterDelimiter
            End If
        End Get
        Set(value As String)
            _CSVExporterDelimiter = value
        End Set
    End Property
    Public Property CSVExporterTextQualifier As String
        Get
            If (_CSVExporterTextQualifier = Nothing) Then
                _CSVExporterTextQualifier = DefaultCSVExporterTextQualifier
            End If
            Return _CSVExporterTextQualifier
        End Get
        Set(value As String)
            _CSVExporterTextQualifier = value
        End Set
    End Property
    Public Property CachePath As String
        Get
            If (_cachePath = Nothing) Then
                _cachePath = DefaultCachePath
            End If
            Return _cachePath
        End Get
        Set(value As String)
            _cachePath = value
        End Set
    End Property
    Public Property MainColor As Color
        Get
            If (_mainColor = Nothing) Then
                _mainColor = DefaultMainColor
            End If
            Return _mainColor
        End Get
        Set(value As Color)
            _mainColor = value
        End Set
    End Property
    Public Property SecondaryColor As Color
        Get
            If (_secondaryColor = Nothing) Then
                _secondaryColor = DefaultSecondaryColor
            End If
            Return _secondaryColor
        End Get
        Set(value As Color)
            _secondaryColor = value
        End Set
    End Property
    Public Property ButtonColorMap As Color
        Get
            If (_buttonColorMap = Nothing) Then
                _buttonColorMap = ButtonColorMap
            End If
            Return _buttonColorMap
        End Get
        Set(value As Color)
            _buttonColorMap = value
        End Set
    End Property
    Public Property ButtonColorStatistics As Color
        Get
            If (_buttonColorStatistics = Nothing) Then
                _buttonColorStatistics = ButtonColorStatistics
            End If
            Return _buttonColorStatistics
        End Get
        Set(value As Color)
            _buttonColorStatistics = value
        End Set
    End Property
    Public Property ButtonColorTelegram As Color
        Get
            If (_buttonColorTelegram = Nothing) Then
                _buttonColorTelegram = ButtonColorTelegram
            End If
            Return _buttonColorTelegram
        End Get
        Set(value As Color)
            _buttonColorTelegram = value
        End Set
    End Property
    Public Property ButtonColorSettings As Color
        Get
            If (_buttonColorSettings = Nothing) Then
                _buttonColorSettings = ButtonColorSettings
            End If
            Return _buttonColorSettings
        End Get
        Set(value As Color)
            _buttonColorSettings = value
        End Set
    End Property
    Public Property ButtonColorExit As Color
        Get
            If (_buttonColorExit = Nothing) Then
                _buttonColorExit = ButtonColorExit
            End If
            Return _buttonColorExit
        End Get
        Set(value As Color)
            _buttonColorExit = value
        End Set
    End Property
    Public Property PopupColorMain As Color
        Get
            If (_popupColorMain = Nothing) Then
                _popupColorMain = DefaultPopupColorMain
            End If
            Return _popupColorMain
        End Get
        Set(value As Color)
            _popupColorMain = value
        End Set
    End Property
    Public Property PopupColorSecondary As Color
        Get
            If (_popupColorSecondary = Nothing) Then
                _popupColorSecondary = DefaultPopupColorSecondary
            End If
            Return _popupColorSecondary
        End Get
        Set(value As Color)
            _popupColorSecondary = value
        End Set
    End Property

    Public Property TelegramBotToken As String
        Get
            Return _telegramBotToken
        End Get
        Set(value As String)
            _telegramBotToken = value
        End Set
    End Property

    Public Property TelegramBotChatID As String
        Get
            Return _telegramBotChatID
        End Get
        Set(value As String)
            _telegramBotChatID = value
        End Set
    End Property

    Public Property TelegramBotEnabled As Boolean
        Get
            Return _telegramBotEnabled
        End Get
        Set(value As Boolean)
            _telegramBotEnabled = value
        End Set
    End Property

    Public Sub RaiseEventNewColorSettingsApplied()
        RaiseEvent NewColorSettingsApplied()
    End Sub

    Public Sub ResetToDefault()
        CSVExporterDelimiter = DefaultCSVExporterDelimiter
        CSVExporterTextQualifier = DefaultCSVExporterTextQualifier
        MainColor = DefaultMainColor
        SecondaryColor = DefaultSecondaryColor
        ButtonColorExit = DefaultButtonColorExit
        ButtonColorMap = DefaultButtonColorMap
        ButtonColorSettings = DefaultButtonColorSettings
        ButtonColorStatistics = DefaultButtonColorStatistics
        ButtonColorTelegram = DefaultButtonColorTelegram
        PopupColorMain = DefaultPopupColorMain
        PopupColorSecondary = DefaultPopupColorSecondary
        TelegramBotEnabled = DefaultTelegramBotEnabled
    End Sub
End Module
