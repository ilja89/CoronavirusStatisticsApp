Public Class CStatFunctions
    Public Function Forecast(list As CStatList, fieldName As String, Optional sampleSize As Integer = 7, Optional outPointsNumber As Integer = 7) As CStatList
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
            For i As Integer = 1 To sampleSize
                temp += list.GetField(list.Count - i, fieldName)
            Next
            avgPoint = CDbl(temp) / sampleSize
            diff = list.GetField(list.Count - 1, fieldName) - avgPoint

            For i As Integer = 0 To outPointsNumber

            Next

            Return list
        Else
            Return Nothing
        End If
    End Function
End Class
