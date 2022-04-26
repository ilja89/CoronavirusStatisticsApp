Module AppSettings
    Public Event NewColorSettingsApplied()

    Public ReadOnly AppSettingsCachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Settings\"
    Public ReadOnly AppSettingsCacheName As String = "AppSettings"
    Public ReadOnly DefaultCachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Public ReadOnly DefaultMainColor As Color = Color.Gray
    Public ReadOnly DefaultSecondaryColor As Color = Color.DarkGray
    Public ReadOnly DefaultButtonColorMap As Color = Color.LawnGreen
    Public ReadOnly DefaultButtonColorStatistics As Color = Color.Cyan
    Public ReadOnly DefaultButtonColorTelegram As Color = Color.MediumVioletRed
    Public ReadOnly DefaultButtonColorSettings As Color = Color.FromArgb(205, 205, 13)
    Public ReadOnly DefaultButtonColorExit As Color = Color.Pink

    Private _CSVExporterDelimiter As String = ":"
    Private _CSVExporterTextQualifier As String = ""
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Private _mainColor As Color = Color.Gray
    Private _secondaryColor As Color = Color.DarkGray
    Private _buttonColorMap As Color = Color.LawnGreen
    Private _buttonColorStatistics As Color = Color.Cyan
    Private _buttonColorTelegram As Color = Color.MediumVioletRed
    Private _buttonColorSettings As Color = Color.FromArgb(205, 205, 13)
    Private _buttonColorExit As Color = Color.Pink

    Public Property CSVExporterDelimiter As String
        Get
            Return _CSVExporterDelimiter
        End Get
        Set(value As String)
            _CSVExporterDelimiter = value
        End Set
    End Property
    Public Property CSVExporterTextQualifier As String
        Get
            Return _CSVExporterTextQualifier
        End Get
        Set(value As String)
            _CSVExporterTextQualifier = value
        End Set
    End Property
    Public Property CachePath As String
        Get
            Return _cachePath
        End Get
        Set(value As String)
            _cachePath = value
        End Set
    End Property
    Public Property MainColor As Color
        Get
            Return _mainColor
        End Get
        Set(value As Color)
            _mainColor = value
        End Set
    End Property
    Public Property SecondaryColor As Color
        Get
            Return _secondaryColor
        End Get
        Set(value As Color)
            _secondaryColor = value
        End Set
    End Property
    Public Property ButtonColorMap As Color
        Get
            Return _buttonColorMap
        End Get
        Set(value As Color)
            _buttonColorMap = value
        End Set
    End Property
    Public Property ButtonColorStatistics As Color
        Get
            Return _buttonColorStatistics
        End Get
        Set(value As Color)
            _buttonColorStatistics = value
        End Set
    End Property
    Public Property ButtonColorTelegram As Color
        Get
            Return _buttonColorTelegram
        End Get
        Set(value As Color)
            _buttonColorTelegram = value
        End Set
    End Property
    Public Property ButtonColorSettings As Color
        Get
            Return _buttonColorSettings
        End Get
        Set(value As Color)
            _buttonColorSettings = value
        End Set
    End Property
    Public Property ButtonColorExit As Color
        Get
            Return _buttonColorExit
        End Get
        Set(value As Color)
            _buttonColorExit = value
        End Set
    End Property
    Public Sub RaiseEventNewColorSettingsApplied()
        RaiseEvent NewColorSettingsApplied()
    End Sub
    Public Sub ResetToDefault()
        MainColor = DefaultMainColor
        SecondaryColor = DefaultSecondaryColor
        ButtonColorExit = DefaultButtonColorExit
        ButtonColorMap = DefaultButtonColorMap
        ButtonColorSettings = DefaultButtonColorSettings
        ButtonColorStatistics = DefaultButtonColorStatistics
        ButtonColorTelegram = DefaultButtonColorTelegram
    End Sub
End Module
