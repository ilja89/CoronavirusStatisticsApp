Public Interface IStatSavedLoad_ForLoadingControl

    ''' <summary>
    ''' UpdateData to update data from database
    ''' </summary>
    ''' <returns></returns>
    ''' 
    Function UpdateData(path As String, progressValueUpdate _
                        As Action(Of Integer)) As Task(Of Boolean)

End Interface
