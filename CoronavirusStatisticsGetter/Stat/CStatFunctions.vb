Imports System.Runtime
Public Class CStatFunctions
    ''' <summary>
    ''' Extends existing list with linear trend prediction based on sample of last entries in list
    ''' </summary>
    ''' <param name="listOriginal">Instance of <see cref="CStatList"/> with all statistics</param>
    ''' <param name="fieldName">Name of field what must be extended (numbers only!)</param>
    ''' <param name="dateFieldName">Name of "Date" field</param>
    ''' <param name="sampleSize">Number of previous entries what must be taken in calculations to find futurous approximate points</param>
    ''' <param name="outPointsNumber">Number of predicted points</param>
    ''' <returns></returns>
    Public Function Forecast(listOriginal As CStatList, fieldName As String, Optional dateFieldName As String = "Date", Optional sampleSize As Integer = 7, Optional outPointsNumber As Integer = 7) As CStatList
        Dim list As CStatList = listOriginal.AsNew
        If (list.Count >= 2) Then
            If (sampleSize > list.Count) Then
                sampleSize = list.Count
            ElseIf (sampleSize <= 0) Then
                sampleSize = 2
            End If
            If (outPointsNumber <= 0) Then
                outPointsNumber = 1
            End If
            Dim temp As Integer = 0
            Dim avgPoint As Double
            Dim diff As Double
            Dim lastPointDate As DateTime = DateTime.Parse(list.GetField(list.Count - 1, dateFieldName))
            Dim lastRealItemIndex As Integer = list.Count - 1
            For i As Integer = 1 To sampleSize
                temp += list.GetField(list.Count - i, fieldName)
            Next
            avgPoint = CDbl(temp) / sampleSize
            diff = (list.GetField(list.Count - 1, fieldName) - avgPoint) / sampleSize

            For i As Integer = 1 To outPointsNumber
                Dim newItem() As String = list.GetItemCopy(lastRealItemIndex)
                temp = CInt(list.GetField(list.Count - 1, fieldName) + diff)
                If (temp <= 0) Then
                    newItem(list.FindFieldIndex(fieldName)) = 0
                Else
                    newItem(list.FindFieldIndex(fieldName)) = temp
                End If
                lastPointDate = lastPointDate.AddDays(1)
                newItem(list.FindFieldIndex(dateFieldName)) = lastPointDate.ToString("yyyy-MM-dd")
                list.AddItemDirectly(newItem)
            Next

            Return list
        Else
            Return Nothing
        End If
    End Function
End Class
