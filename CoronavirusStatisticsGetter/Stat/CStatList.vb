Imports System.Math
''' <summary>
''' Class used to comfortably work with statistics data, received from network in CSV format.
''' </summary>
Public Class CStatList
    Private _items As New List(Of String())             ' List of items
    Private _fields As String()                         ' Headers of these items fields
    Private _fieldsNumber As Integer                    ' Number of these headers
    Private _inputIndex As Integer()                    ' Indexes of these headers in raw splitted input string
    Private _inputIndexMax As Integer                   ' Maximal raw splitted input string index
    Private _lastItemAccessedIndex As Integer = 0       ' Index of last item accessed
    Private _lastItemFieldAccessedIndex As Integer = 0  ' Index of last field accessed of last item acessed
    Private _canAddFreely As Boolean = True
    ''' <summary>
    ''' Get <see cref="CStatList"/> item by index
    ''' </summary>
    ''' <param name="index"></param>
    ''' <returns>String()</returns>
    Default Public Property Element(index As Integer) As String()
        Get
            _lastItemAccessedIndex = index
            Return _items(index)
        End Get
        Set(value As String())
            _lastItemAccessedIndex = index
            _items(index) = value
        End Set
    End Property
    ''' <summary>
    ''' Get <see cref="CStatList"/> headers as array of strings
    ''' </summary>
    ''' <returns>String()</returns>
    Public ReadOnly Property Fields As String()
        Get
            Return _fields
        End Get
    End Property
    Public ReadOnly Property FieldsNumber As Integer
        Get
            Return _fields.Length
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
    Public ReadOnly Property CanAddFreely As Boolean
        Get
            Return _canAddFreely
        End Get
    End Property
    ''' <summary>
    ''' Used to set value of any field <paramref name="field"/> of element of <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="field"></param>
    Public WriteOnly Property SetField(index As Integer, field As String) As String
        Set(value As String)
            If (index <= _items.Count - 1) Then
                _lastItemAccessedIndex = index
                _lastItemFieldAccessedIndex = FindFieldIndex(field)
                _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex) = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' Used to set value of field with index of <paramref name="fieldIndex"/> of element of <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="fieldIndex"></param>
    Public WriteOnly Property SetField(index As Integer, fieldIndex As Integer) As String
        Set(value As String)
            If (index <= _items.Count - 1) Then
                _lastItemAccessedIndex = index
                _lastItemFieldAccessedIndex = fieldIndex
                _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex) = value
            End If
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
            If (_items.Count >= 1) Then
                _lastItemAccessedIndex = index
                _lastItemFieldAccessedIndex = FindFieldIndex(field)
                Return _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property
    ''' <summary>
    ''' Used to get value of field with index of <paramref name="fieldIndex"/> of element of <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="fieldIndex"></param>
    ''' <returns>Field as <see cref="String"/></returns>
    Public ReadOnly Property GetField(index As Integer, fieldIndex As Integer) As String
        Get
            If (_items.Count >= 1) Then
                _lastItemAccessedIndex = index
                _lastItemFieldAccessedIndex = fieldIndex
                Return _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property
    ''' <summary>
    ''' Used to get value of last accessed field of last accessed element of <see cref="CStatList"/>
    ''' </summary>
    ''' <returns>Field as <see cref="String"/></returns>
    Public ReadOnly Property GetField() As String
        Get
            If (_items.Count >= 1) Then
                Return _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex)
            Else
                Return Nothing
            End If
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
    ''' Used to get multiple items fields as array of strings.
    ''' </summary>
    ''' <param name="field"></param>
    ''' <param name="indexFrom"></param>
    ''' <param name="numberOfItems"></param>
    ''' <returns>Array of <see cref="String"/></returns>
    Public Function GetFields(field As String, Optional indexFrom As Integer = 0, Optional numberOfItems As Integer = -1) As String()
        Dim fieldIndex As Integer = FindFieldIndex(field)
        If (fieldIndex < 0 Or fieldIndex >= _fieldsNumber Or indexFrom < 0 Or indexFrom >= _items.Count) Then
            Return Nothing
        End If
        If (numberOfItems = -1) Then
            Dim result(_items.Count - 1 - indexFrom) As String
            Dim c As Integer = 0
            For i As Integer = indexFrom To _items.Count - 1
                result(c) = _items(i)(fieldIndex)
                c += 1
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
    Public Function GetFields(fieldIndex As Integer, Optional indexFrom As Integer = 0, Optional numberOfItems As Integer = -1) As String()
        If (fieldIndex < 0 Or fieldIndex >= _fieldsNumber Or indexFrom < 0 Or indexFrom >= _items.Count) Then
            Return Nothing
        End If
        If (numberOfItems = -1) Then
            Dim result(_items.Count - 1 - indexFrom) As String
            Dim c As Integer = 0
            For i As Integer = indexFrom To _items.Count - 1
                result(c) = _items(i)(fieldIndex)
                c += 1
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
    Public Function GetIndexOfFirstItemWhere(field As String, fieldAimValue As String) As Integer
        Dim fieldIndex = FindFieldIndex(field)
        For i As Integer = 0 To _items.Count - 1
            If (_items(i)(fieldIndex) = fieldAimValue) Then
                Return i
            End If
        Next
        Return -1
    End Function
    ''' <summary>
    ''' Delete field from instance of <see cref="CStatList"/><br/>
    ''' Deleted this field from header and from all items
    ''' </summary>
    ''' <param name="fieldName">Name of field what have to be deleted</param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function DeleteFieldFromList(fieldName As String) As CStatList
        Dim fieldIndex = FindFieldIndex(fieldName)
        Dim newFieldsNumber = _fieldsNumber - 1
        Dim newFields(_fieldsNumber - 2) As String
        Dim newInputIndex(_fieldsNumber - 2) As Integer
        Dim newInputIndexMax As Integer = 0
        Dim i = 0
        Dim c = 0

        While (i < _fieldsNumber)
            If (i <> fieldIndex) Then
                newFields(c) = _fields(i)
                newInputIndex(c) = _inputIndex(i)
                If (newInputIndex(c) > newInputIndexMax) Then
                    newInputIndexMax = newInputIndex(c)
                End If
                c += 1
            End If
            i += 1
        End While
        _fields = newFields
        _inputIndex = newInputIndex
        _inputIndexMax = newInputIndexMax

        For itemNumber As Integer = 0 To _items.Count - 1
            Dim newItem(_fieldsNumber - 2) As String
            i = 0
            c = 0
            While (i < _fieldsNumber)
                If (i <> fieldIndex) Then
                    newItem(c) = _items(itemNumber)(i)
                    c += 1
                End If
                i += 1
            End While
            _items(itemNumber) = newItem
        Next

        _fieldsNumber = _fieldsNumber - 1
        Return Me
    End Function
    ''' <summary>
    ''' Renames field with original name of <paramref name="fieldName"/><br/>
    ''' Blocks possibility to add new items in this <see cref="CStatList"/> using unparsed strings
    ''' </summary>
    ''' <param name="fieldName">Original field name</param>
    ''' <param name="newFieldName">New field name</param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function RenameField(fieldName As String, newFieldName As String) As CStatList
        _canAddFreely = False
        _inputIndex = Nothing
        _inputIndexMax = Nothing
        _fields(FindFieldIndex(fieldName)) = newFieldName
        Return Me
    End Function
    ''' <summary>
    ''' Adds new field into this <see cref="CStatList"/><br/>
    ''' Blocks possibility to add new items in this <see cref="CStatList"/> using unparsed strings
    ''' </summary>
    ''' <param name="fieldName">Name of new field</param>
    ''' <param name="defaultValue">Default value for this field in items</param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function AddField(fieldName As String, Optional defaultValue As String = Nothing) As CStatList
        _canAddFreely = False
        Dim newFieldsNumber = _fieldsNumber + 1
        Dim newFields(_fieldsNumber) As String
        Dim newInputIndex(_fieldsNumber) As Integer
        Dim i = 0

        While (i < _fieldsNumber)
            newFields(i) = _fields(i)
            i += 1
        End While
        newFields(i) = fieldName
        _fields = newFields
        _inputIndex = Nothing
        _inputIndexMax = Nothing

        For itemNumber As Integer = 0 To _items.Count - 1
            Dim newItem(_fieldsNumber) As String
            For c As Integer = 0 To _items(itemNumber).Length - 1
                newItem(c) = _items(itemNumber)(c)
            Next
            newItem(_fieldsNumber) = defaultValue
            _items(itemNumber) = newItem
        Next

        _fieldsNumber = _fieldsNumber + 1
        Return Me
    End Function
    ''' <summary>
    ''' Get index of first item where date fulfil condition
    ''' </summary>
    ''' <param name="dateValue">Value of date field. For example "2022-02-02"</param>
    ''' <param name="condition">Condition: &lt;,&lt;=,&gt;,&gt;=,=,&lt;&gt;</param>
    ''' <param name="delimiter">Delimiter inside date string.</param>
    ''' <param name="dateFieldName">Name of Date field. If field name is not "Date"</param>
    ''' <returns></returns>
    Public Function GetIndexOfFirstItemWhereDate(dateValue As String, Optional condition As String = "=", Optional delimiter As String = "-", Optional dateFieldName As String = "Date") As Integer
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
    ''' Used to add new items in <see cref="CStatList"/> using multiple strings array as input
    ''' </summary>
    ''' <param name="newItemStrings"></param>
    ''' <param name="delimiter"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Add(newItemStrings() As String, Optional delimiter As String = ",") As CStatList
        If (CanAddFreely) Then
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
        End If
        Return Me
    End Function

    Public Function AddItemDirectly(newItem As String()) As CStatList
        _items.Add(newItem)
        Return Me
    End Function
    Public Function AddItemsDirectly(newItems As List(Of String())) As CStatList
        For Each newItem In newItems
            _items.Add(newItem)
        Next
        Return Me
    End Function
    Public Function GetItemsDirectly() As List(Of String())
        Return _items
    End Function
    Public Function GetItemsDirectly(indexFrom As Integer, Optional itemsNumber As Integer = 0) As List(Of String())
        Dim returnableItems As New List(Of String())
        If (_items.Count > 0) Then
            If (itemsNumber > 0) Then
                For i As Integer = indexFrom To Min(indexFrom + itemsNumber - 1, _items.Count - 1)
                    returnableItems.Add(_items(i))
                Next
            Else
                For i As Integer = indexFrom To _items.Count - 1
                    returnableItems.Add(_items(i))
                Next
            End If
        End If
        Return returnableItems
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
            Return Nothing
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
            If (_items(i)(keyIndex) = keyValue) Then
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
    ''' Function used to create new instance of <see cref="CStatList"/> with headers passed inside in form of array:<br/>
    ''' {{RealName,NameToSaveWith,IndexInRawSplittedInput},...}
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
        Dim newFields(headersNumber - 1) As String
        headers.CopyTo(newFields, 0)
        _fields = newFields
        _fieldsNumber = headersNumber
        Dim newInputIndex(headersNumber - 1) As Integer
        inputIndex.CopyTo(newInputIndex, 0)
        _inputIndex = newInputIndex
        _inputIndexMax = inputIndexMax
        Dim newItems As New List(Of String())
        For Each item In items
            Dim temp(headersNumber - 1) As String
            item.CopyTo(temp, 0)
            newItems.Add(temp)
        Next
        _items = newItems
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
