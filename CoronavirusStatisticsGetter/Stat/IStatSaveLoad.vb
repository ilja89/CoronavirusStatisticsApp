Public Interface IStatSaveLoad
    Sub SaveTo(aimObject As Object, path As String, fileName As String)

    Function LoadFrom(path As String, name As String) As Object

    Function IsUpToDate(lastUpdateDate As DateTime)

    Function UpdateData(path As String) As Task(Of Boolean)
End Interface
