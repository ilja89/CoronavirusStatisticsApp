Public Class CExporter
    Implements IExporter

    Private _delimiter As String = ":"
    Private _textQualifier As String = ""
    Private _path As String
    Private _fileName As String

    ''' <summary>
    ''' Delimiter for delimiting fields of CSV
    ''' </summary>
    ''' <returns></returns>
    Private Property Delimiter As String Implements IExporter.Delimiter
        Get
            Return _delimiter
        End Get
        Set(value As String)
            _delimiter = value
        End Set
    End Property

    ''' <summary>
    ''' Text qualifier for text in CSV
    ''' </summary>
    ''' <returns></returns>
    Private Property TextQualifier As String Implements IExporter.TextQualifier
        Get
            Return _textQualifier
        End Get
        Set(value As String)
            _textQualifier = value
        End Set
    End Property

    ''' <summary>
    ''' Interactive window where user can choose path for saving file
    ''' </summary>
    ''' <returns></returns>
    Private Function setFileToSave() As String Implements IExporter.setFileToSave
        Dim fileDialog As Windows.Forms.OpenFileDialog = New Windows.Forms.OpenFileDialog()
        Dim returnable As String = Nothing
        fileDialog.AddExtension = True
        fileDialog.CheckFileExists = False
        fileDialog.CheckPathExists = False
        fileDialog.DefaultExt = "csv"
        If (fileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            returnable = fileDialog.FileName
            _fileName = fileDialog.SafeFileName
            _path = returnable
        End If
        fileDialog.Dispose()
        Return returnable
    End Function

    ''' <summary>
    ''' Saves data to CSV file using path chosen in <see cref="setFileToSave"/>
    ''' </summary>
    ''' <returns></returns>
    Private Function saveDataToCSV(data() As String, Optional appendData As Boolean = False) _
        As Integer Implements IExporter.saveDataToCSV

        Dim directory As String = _path.Replace(_fileName, "")
        If (directory = Nothing) Then
            Throw New Exception("Empty folder path")
            Exit Function
        End If

        If (Not IO.Directory.Exists(directory)) Then
            IO.Directory.CreateDirectory(directory)
        End If
        Dim sw As New IO.StreamWriter(_path, appendData, New Text.UTF32Encoding)
        sw.Write(String.Join(vbCrLf, data))
        sw.Close()
        Return data.Length
    End Function

    Public Sub New(newDelimiter As String, newTextQualifier As String)
        _delimiter = newDelimiter
        _textQualifier = newTextQualifier
    End Sub
End Class
