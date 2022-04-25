Class AppSettings
    Public Shared ReadOnly AppSettingsCachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Settings\"
    Public Shared ReadOnly AppSettingsCacheName As String = "AppSettings"
    Public Shared ReadOnly AppCacheDefaultPath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Private Shared _CSVExporterDelimiter As String = ":"
    Private Shared _CSVExporterTextQualifier As String = ""
    Private Shared _CachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"

    Public Shared Property CSVExporterDelimiter As String
        Get
            Return _CSVExporterDelimiter
        End Get
        Set(value As String)
            _CSVExporterDelimiter = value
        End Set
    End Property
    Public Shared Property CSVExporterTextQualifier As String
        Get
            Return _CSVExporterTextQualifier
        End Get
        Set(value As String)
            _CSVExporterTextQualifier = value
        End Set
    End Property
    Public Shared Property CachePath As String
        Get
            Return _CachePath
        End Get
        Set(value As String)
            _CachePath = value
        End Set
    End Property
End Class
