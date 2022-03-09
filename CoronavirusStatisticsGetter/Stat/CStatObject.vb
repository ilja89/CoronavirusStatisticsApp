Imports System.Math
Public Class CStatObject
    Private objCol As New Collection
    Default Public ReadOnly Property Element(index As Integer) As Collection
        Get
            If (objCol.Count >= index And index > 0) Then
                Return objCol(index)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Function Count() As Integer
        Return objCol.Count
    End Function
    Public Function Add(item As Collection) As CStatObject
        objCol.Add(item)
        Return Me
    End Function

    Public Function Remove(index As Integer) As CStatObject
        If (objCol.Count <= index & objCol.Count > 0) Then
            objCol.Remove(index)
        End If
        Return Me
    End Function
    Public Function Where(objectKey As String, keyValue As String) As CStatObject
        Dim i As Integer = 1
        While (i <= objCol.Count)
            If (objCol(i).Item(objectKey) <> keyValue) Then
                objCol.Remove(i)
            Else
                i = i + 1
            End If
        End While
        Return Me
    End Function
    Public Function WhereNot(objectKey As String, keyValue As String) As CStatObject
        Dim i As Integer = 1
        While (i <= objCol.Count)
            If (objCol(i).Item(objectKey) = keyValue) Then
                objCol.Remove(i)
            Else
                i = i + 1
            End If
        End While
        Return Me
    End Function
    Public Function WhereDate(dateValue As String, Optional condition As String = "=", Optional delimiter As String = "-", Optional dateEntryName As String = "Date") As CStatObject
        Dim newCollection As New Collection

        If (condition = "=") Then
            For Each item As Collection In objCol
                If (DateCmp(item.Item(dateEntryName), dateValue) = 0) Then
                    newCollection.Add(item)
                End If
            Next

        ElseIf (condition = "<") Then
            For Each item As Collection In objCol
                If (DateCmp(item.Item(dateEntryName), dateValue) < 0) Then
                    newCollection.Add(item)
                End If
            Next

        ElseIf (condition = "<=") Then
            For Each item As Collection In objCol
                If (DateCmp(item.Item(dateEntryName), dateValue) <= 0) Then
                    newCollection.Add(item)
                End If
            Next

        ElseIf (condition = ">") Then
            For Each item As Collection In objCol
                If (DateCmp(item.Item(dateEntryName), dateValue) > 0) Then
                    newCollection.Add(item)
                End If
            Next

        ElseIf (condition = ">=") Then
            For Each item As Collection In objCol
                If (DateCmp(item.Item(dateEntryName), dateValue) >= 0) Then
                    newCollection.Add(item)
                End If
            Next

        ElseIf (condition = "<>") Then
            For Each item As Collection In objCol
                If (DateCmp(item.Item(dateEntryName), dateValue) <> 0) Then
                    newCollection.Add(item)
                End If
            Next
        End If
        objCol = newCollection
        Return Me
    End Function
    Public Function AsNew()
        Return New CStatObject(objCol)
    End Function
    Public Sub New()

    End Sub
    Private Sub New(newObjCol As Collection)
        objCol = newObjCol
    End Sub
    Private Function DateCmp(date1 As String, date2 As String) As Integer
        For c As Integer = 0 To Min(date1.Length, date2.Length) - 1
            If (date1.Chars(c) > date2.Chars(c)) Then
                Return 1
            ElseIf (date1.Chars(c) < date2.Chars(c)) Then
                Return -1
            End If
        Next
        Return 0
    End Function
End Class
