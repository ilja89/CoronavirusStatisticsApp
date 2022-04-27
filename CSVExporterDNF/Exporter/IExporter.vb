Public Interface IExporter
    ''' <summary>
    ''' Delimiter for delimiting fields of CSV
    ''' </summary>
    ''' <returns></returns>
    Property Delimiter As String
    ''' <summary>
    ''' Text qualifier for text in CSV
    ''' </summary>
    ''' <returns></returns>
    Property TextQualifier As String
    ''' <summary>
    ''' Interactive window where user can choose path for saving file
    ''' </summary>
    ''' <returns></returns>
    Function setFileToSave() As String
    ''' <summary>
    ''' Saves data to CSV file using path chosen in <see cref="setFileToSave"/>
    ''' </summary>
    ''' <returns></returns>
    Function saveDataToCSV(data() As String, Optional appendData _
                           As Boolean = False) As Integer
End Interface
