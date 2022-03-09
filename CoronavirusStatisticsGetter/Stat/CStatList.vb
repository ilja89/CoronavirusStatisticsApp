Imports System.Math
''' <summary>
''' Class used to comfortably work with statistics data, received from network in CSV format.
''' </summary>
Public Class CStatList
    Private _items As New List(Of String())
    Private _fields As String()
    Private _fieldsNumber As Integer
    Private _inputIndex As Integer()
    Private _inputIndexMax As Integer
    Private _lastItemAccessedIndex As Integer = 0
    Private _lastItemFieldAccessedIndex As Integer = 0
    ''' <summary>
    ''' Get <see cref="CStatList"/> item by index
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns>String()</returns>
    Default Public ReadOnly Property Element(index As Integer) As String()
        Get
            _lastItemAccessedIndex = index
            Return _items(index)
        End Get
    End Property
    ''' <summary>
    ''' Get <see cref="CStatList"/> headers as array of strings
    ''' </summary>
    ''' <returns>String()</returns>
    Public ReadOnly Property Headers As String()
        Get
            Return _fields
        End Get
    End Property
    ''' <summary>
    ''' Get <see cref="CStatList"/> items number
    ''' </summary>
    ''' <returns><see cref="Integer"/></returns>
    Public ReadOnly Property Count As Integer
        Get
            Return _items.Count
        End Get
    End Property
    ''' <summary>
    ''' Used to set value of any field <paramref name="field"/> of element of <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="field"></param>
    Public WriteOnly Property SetField(index As Integer, field As String) As String
        Set(value As String)
            _lastItemAccessedIndex = index
            _lastItemFieldAccessedIndex = FindFieldIndex(field)
            _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex) = value
        End Set
    End Property
    ''' <summary>
    ''' Used to set value of last accessed field of last accessed item
    ''' </summary>
    Public WriteOnly Property SetField() As String
        Set(value As String)
            _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex) = value
        End Set
    End Property
    ''' <summary>
    ''' Used to get value of any field <paramref name="field"/> of element of <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="field"></param>
    ''' <returns>Field as <see cref="String"/></returns>
    Public ReadOnly Property GetField(index As Integer, field As String) As String
        Get
            _lastItemAccessedIndex = index
            _lastItemFieldAccessedIndex = FindFieldIndex(field)
            Return _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex)
        End Get
    End Property
    ''' <summary>
    ''' Used to get value of last accessed field of last accessed element of <see cref="CStatList"/>
    ''' </summary>
    ''' <returns>Field as <see cref="String"/></returns>
    Public ReadOnly Property GetField() As String
        Get
            Return _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex)
        End Get
    End Property
    ''' <summary>
    ''' Used to get index of last accessed item
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LastItemAccessedIndex() As Integer
        Get
            Return _lastItemAccessedIndex
        End Get
    End Property
    ''' <summary>
    ''' Used to get last accessed field index of last accessed item
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LastItemFieldAccessedIndex As Integer
        Get
            Return _lastItemFieldAccessedIndex
        End Get
    End Property
    ''' <summary>
    ''' Used to get myltiple items fields as array of strings.
    ''' </summary>
    ''' <param name="field"></param>
    ''' <param name="indexFrom"></param>
    ''' <param name="numberOfItems"></param>
    ''' <returns>Array of <see cref="String"/></returns>
    Public Function GetFields(field As String, indexFrom As Integer, Optional numberOfItems As Integer = -1)
        Dim fieldIndex As Integer = FindFieldIndex(field)
        If (fieldIndex < 0 Or fieldIndex >= _fieldsNumber Or indexFrom < 0 Or indexFrom >= _fieldsNumber) Then
            Return Nothing
        End If
        If (numberOfItems = -1) Then
            Dim result(_items.Count - 1) As String
            For i As Integer = indexFrom To _items.Count - 1
                result(i) = _items(i)(fieldIndex)
            Next
            Return result
        Else
            Dim result(numberOfItems - 1) As String
            Dim c As Integer = 0
            For i As Integer = indexFrom To Min(_items.Count, indexFrom + numberOfItems) - 1
                result(c) = _items(i)(fieldIndex)
                c = c + 1
            Next
            Return result
        End If
    End Function
    ''' <summary>
    ''' Used to get myltiple items fields as array of strings.
    ''' </summary>
    ''' <param name="fieldIndex"></param>
    ''' <param name="indexFrom"></param>
    ''' <param name="numberOfItems"></param>
    ''' <returns>Array of <see cref="String"/></returns>
    Public Function GetFields(fieldIndex As Integer, indexFrom As Integer, Optional numberOfItems As Integer = -1)
        If (fieldIndex < 0 Or fieldIndex >= _fieldsNumber Or indexFrom < 0 Or indexFrom >= _fieldsNumber) Then
            Return Nothing
        End If
        If (numberOfItems = -1) Then
            Dim result(_items.Count - 1) As String
            For i As Integer = indexFrom To _items.Count - 1
                result(i) = _items(i)(fieldIndex)
            Next
            Return result
        Else
            Dim result(numberOfItems - 1) As String
            Dim c As Integer = 0
            For i As Integer = indexFrom To Min(_items.Count, indexFrom + numberOfItems) - 1
                result(c) = _items(i)(fieldIndex)
                c = c + 1
            Next
            Return result
        End If
    End Function
    ''' <summary>
    ''' Find index of first item in <see cref="CStatList"/> where <paramref name="field"/> has value <paramref name="fieldAimValue"/> 
    ''' </summary>
    ''' <param name="field"></param>
    ''' <param name="fieldAimValue"></param>
    ''' <returns></returns>
    Public Function GetIndexOfFirstItemWhere(field As String, fieldAimValue As String)
        Dim fieldIndex = FindFieldIndex(field)
        For i As Integer = 0 To _items.Count - 1
            If (_items(i)(fieldIndex) = fieldAimValue) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Function GetIndexOfFirstItemWhereDate(dateValue As String, Optional condition As String = "=", Optional delimiter As String = "-", Optional dateFieldName As String = "Date")
        Dim fieldIndex As Integer = FindFieldIndex(dateFieldName)
        If (condition = "=") Then
            For i As Integer = 0 To _items.Count
                If (DateCmp(_items(i)(fieldIndex), dateValue) = 0) Then
                    Return i
                End If
            Next

        ElseIf (condition = "<") Then
            For i As Integer = 0 To _items.Count
                If (DateCmp(_items(i)(fieldIndex), dateValue) < 0) Then
                    Return i
                End If
            Next

        ElseIf (condition = "<=") Then
            For i As Integer = 0 To _items.Count
                If (DateCmp(_items(i)(fieldIndex), dateValue) <= 0) Then
                    Return i
                End If
            Next

        ElseIf (condition = ">") Then
            For i As Integer = 0 To _items.Count
                If (DateCmp(_items(i)(fieldIndex), dateValue) > 0) Then
                    Return i
                End If
            Next

        ElseIf (condition = ">=") Then
            For i As Integer = 0 To _items.Count
                If (DateCmp(_items(i)(fieldIndex), dateValue) >= 0) Then
                    Return i
                End If
            Next

        ElseIf (condition = "<>") Then
            For i As Integer = 0 To _items.Count
                If (DateCmp(_items(i)(fieldIndex), dateValue) <> 0) Then
                    Return i
                End If
            Next
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Used to add new item in <see cref="CStatList"/> using single string as input
    ''' </summary>
    ''' <param name="newItemString"></param>
    ''' <param name="delimiter"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Add(newItemString As String, delimiter As String) As CStatList
        Dim splitted As String() = newItemString.Split(delimiter)
        Dim newItem(_fieldsNumber - 1) As String
        Dim i As Integer = 0
        For Each index As Integer In _inputIndex
            newItem(i) = splitted(index)
            i = i + 1
        Next
        _items.Add(newItem)
        Return Me
    End Function
    ''' <summary>
    ''' Used to add new item in <see cref="CStatList"/> using single string array as input
    ''' </summary>
    ''' <param name="newItemArray"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Add(newItemArray() As String) As CStatList
        Dim newItem(_fieldsNumber - 1) As String
        Dim i As Integer = 0
        For Each index As Integer In _inputIndex
            newItem(i) = newItemArray(index)
            i = i + 1
        Next
        _items.Add(newItem)
        Return Me
    End Function
    ''' <summary>
    ''' Used to add new items in <see cref="CStatList"/> using multiple strings array as input
    ''' </summary>
    ''' <param name="newItemStrings"></param>
    ''' <param name="delimiter"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Add(newItemStrings() As String, delimiter As String) As CStatList
        Dim l As Integer = _fieldsNumber - 1
        Dim splitted As String()
        Dim i As Integer = 0
        For Each newItemString As String In newItemStrings
            If (newItemString IsNot Nothing) Then
                splitted = newItemString.Split(delimiter)
                If (splitted.Length > _inputIndexMax) Then
                    i = 0
                    Dim newItem(l) As String
                    For Each index As Integer In _inputIndex
                        newItem(i) = splitted(index)
                        i = i + 1
                    Next
                    _items.Add(newItem)
                End If
            End If
        Next
        Return Me
    End Function
    ''' <summary>
    ''' Used to add new items in <see cref="CStatList"/> using array of multiple arrays of strings as input
    ''' </summary>
    ''' <param name="newItemsArray"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Add(newItemsArray(,) As String) As CStatList
        Dim l As Integer = _fieldsNumber - 1
        Dim i As Integer = 0
        For Each newItemArray As String In newItemsArray
            If (newItemArray IsNot Nothing) Then
                If (newItemArray.Length > _inputIndexMax) Then
                    i = 0
                    Dim newItem(l) As String
                    For Each index As Integer In _inputIndex
                        newItem(i) = newItemArray(index)
                        i = i + 1
                    Next
                    _items.Add(newItem)
                End If
            End If
        Next
        Return Me
    End Function
    ''' <summary>
    ''' Used to remove item from <see cref="CStatList"/> using its index
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Remove(index As Integer) As CStatList
        _items.RemoveAt(index)
        Return Me
    End Function
    ''' <summary>
    ''' Used to filter items in <see cref="CStatList"/> by date (of course if you have a corresponding header) <br/>
    ''' After use, only items what meet condition will remain
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <param name="condition"></param>
    ''' <param name="delimiter"></param>
    ''' <param name="dateEntryName"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function WhereDate(dateValue As String, Optional condition As String = "=", Optional delimiter As String = "-", Optional dateEntryName As String = "Date") As CStatList
        Dim keyIndex As Integer = FindFieldIndex(dateEntryName)
        Dim newItemsList As New List(Of String())
        If (condition = "=") Then
            For Each item As String() In _items
                If (DateCmp(item(keyIndex), dateValue) = 0) Then
                    newItemsList.Add(item)
                End If
            Next

        ElseIf (condition = "<") Then
            For Each item As String() In _items
                If (DateCmp(item(keyIndex), dateValue) < 0) Then
                    newItemsList.Add(item)
                End If
            Next

        ElseIf (condition = "<=") Then
            For Each item As String() In _items
                If (DateCmp(item(keyIndex), dateValue) <= 0) Then
                    newItemsList.Add(item)
                End If
            Next

        ElseIf (condition = ">") Then
            For Each item As String() In _items
                If (DateCmp(item(keyIndex), dateValue) > 0) Then
                    newItemsList.Add(item)
                End If
            Next

        ElseIf (condition = ">=") Then
            For Each item As String() In _items
                If (DateCmp(item(keyIndex), dateValue) >= 0) Then
                    newItemsList.Add(item)
                End If
            Next

        ElseIf (condition = "<>") Then
            For Each item As String() In _items
                If (DateCmp(item(keyIndex), dateValue) <> 0) Then
                    newItemsList.Add(item)
                End If
            Next
        End If
        If (newItemsList.Count > 0) Then
            _items = newItemsList
        Else
            _items = Nothing
        End If
        Return Me
    End Function
    ''' <summary>
    ''' Used to filter items in <see cref="CStatList"/> by their fields. Only items what have same <paramref name="keyValue"/> of
    ''' <paramref name="header"/> will remain.
    ''' </summary>
    ''' <param name="header"></param>
    ''' <param name="keyValue"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Where(header As String, keyValue As String) As CStatList
        Dim keyIndex As Integer = FindFieldIndex(header)
        Dim newItemsList As New List(Of String())
        For i As Integer = 0 To Count - 1
            Dim thisItem = _items(i).GetValue(keyIndex)
            If (_items(i).GetValue(keyIndex) = keyValue) Then
                newItemsList.Add(_items(i))
            End If
        Next
        _items = newItemsList
        Return Me
    End Function
    ''' <summary>
    ''' Used to filter items in <see cref="CStatList"/> by their fields. Only items what have not same <paramref name="keyValue"/> of
    ''' <paramref name="header"/> will remain.
    ''' </summary>
    ''' <param name="header"></param>
    ''' <param name="keyValue"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function WhereNot(header As String, keyValue As String) As CStatList
        Dim keyIndex As Integer = FindFieldIndex(header)
        Dim newItemsList As New List(Of String())
        For i As Integer = 0 To Count - 1
            Dim thisItem = _items(i).GetValue(keyIndex)
            If (_items(i).GetValue(keyIndex) <> keyValue) Then
                newItemsList.Add(_items(i))
            End If
        Next
        _items = newItemsList
        Return Me
    End Function
    ''' <summary>
    ''' Function used to create new instance of <see cref="CStatList"/> <br/>
    ''' </summary>
    ''' <param name="parsedFields"></param>
    Public Sub New(parsedFields As String(,))
        _fieldsNumber = parsedFields.Length \ 3
        Dim newHeaders(_fieldsNumber - 1) As String
        Dim newInputIndex(_fieldsNumber - 1) As Integer
        For i As Integer = 0 To _fieldsNumber - 1
            newHeaders(i) = parsedFields(i, 1)
            newInputIndex(i) = parsedFields(i, 2)
        Next
        _fields = newHeaders
        _inputIndex = newInputIndex
        Dim max As Integer = 0
        For Each index As Integer In _inputIndex
            If (index > _inputIndexMax) Then
                _inputIndexMax = index
            End If
        Next
    End Sub
    ''' <summary>
    ''' Function used to create new instance of <see cref="CStatList"/> <br/>
    ''' </summary>
    ''' <param name="headers"></param>
    ''' <param name="headersNumber"></param>
    Private Sub New(headers As String(), headersNumber As Integer,
        inputIndex As Integer(), inputIndexMax As Integer)
        _fields = headers
        _fieldsNumber = headersNumber
        _inputIndex = inputIndex
        _inputIndexMax = inputIndexMax
    End Sub
    ''' <summary>
    ''' Function used to create new instance of <see cref="CStatList"/> <br/>
    ''' </summary>
    Private Sub New(headers As String(), headersNumber As Integer,
        inputIndex As Integer(), inputIndexMax As Integer, items As List(Of String()))
        _fields = headers
        _fieldsNumber = headersNumber
        _inputIndex = inputIndex
        _inputIndexMax = inputIndexMax
        _items = items
    End Sub
    Public Function FindFieldIndex(objectKey As String) As Integer
        For i As Integer = 0 To _fieldsNumber - 1
            If (_fields(i) = objectKey) Then
                Return i
            End If
        Next
        Return -1
    End Function
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
    ''' <summary>
    ''' Function used to create copy of <see cref="CStatList"/> instance
    ''' </summary>
    ''' <returns>New instance of <see cref="CStatList"/></returns>
    Public Function AsNew() As CStatList
        Return New CStatList(_fields, _fieldsNumber, _inputIndex, _inputIndexMax, _items)
    End Function
End Class
