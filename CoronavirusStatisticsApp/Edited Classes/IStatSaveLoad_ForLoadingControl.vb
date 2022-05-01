' FILENAME: IStatSaveLoad_ForLoadingControl.vb
' AUTOR: El Plan - Nikita Budovei
' CREATED: 29.04.2022
' CHANGED: 29.04.2022
'
' DESCRIPTION: Interface
'
' RELATED COMPONENTS: ...
Public Interface IStatSaveLoad_ForLoadingControl
    Inherits CoronaStatisticsGetter.IStatSaveLoad
    ''' <summary>
    ''' UpdateData to update data from database
    ''' </summary>
    ''' <returns></returns>
    ''' 
    Shadows Function UpdateData(path As String,
                                progressValueUpdate As Action(Of Integer)) As Task(Of Boolean)

    Sub SaveAppSettings()

    Sub LoadAppSettings()
End Interface
