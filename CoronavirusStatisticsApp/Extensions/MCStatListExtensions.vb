Imports System.Runtime.CompilerServices
Public Module MCStatListExtensions
    <Extension>
    Public Function ToCSVStrings(list As CoronaStatisticsGetter.IStatList, delimiter As String, textQualifier As String) As String()
        Dim data(list.Count) As String
        Dim raw As List(Of String()) = list.GetItemsDirectly
        Dim j As Integer = 0
        data(0) = UniteWithDelimiterAndQualifier(list.Fields, delimiter, textQualifier)
        For i As Integer = 1 To data.Length - 1
            data(i) = UniteWithDelimiterAndQualifier(raw(j), delimiter, textQualifier)
            j = i
        Next
        Return data
    End Function
    Private Function UniteWithDelimiterAndQualifier(strings() As String, delimiter As String, textQualifier As String) As String
        For Each item As String In strings
            item = textQualifier + item + textQualifier
        Next
        Return String.Join(delimiter, strings)
    End Function
End Module
