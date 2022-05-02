' FILENAME: CStatList.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 02.03.2022
' CHANGED: 20.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: ...
Imports System.Math
''' <summary>
''' Class used to comfortably work with statistics data, received from network in CSV format.
''' </summary>
<Serializable()> Public Class CStatList

    Implements IStatList

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
    Default Public Property Element(index As Integer) As String() _
        Implements IStatList.Element

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
    ''' Get <see cref="CStatList"/> item field by item index and field name
    ''' </summary>
    ''' <param name="index">Index of item in CStatList</param>
    ''' <param name="fieldName">Name of field, value of what will be returned</param>
    ''' <returns>Item field</returns>
    Default Public Property Element(index As Integer, fieldName As String) _
        As String Implements IStatList.Element

        Get
            _lastItemAccessedIndex = index
            Return GetField(index, fieldName)
        End Get
        Set(value As String)
            _lastItemAccessedIndex = index
            SetField(index, fieldName) = value
        End Set
    End Property
    ''' <summary>
    ''' Get <see cref="CStatList"/> item field by item index and field index
    ''' </summary>
    ''' <param name="index">Index of item in CStatList</param>
    ''' <param name="fieldIndex">Index of field, value of what will be returned</param>
    ''' <returns>Item field</returns>
    Default Public Property Element(index As Integer, fieldIndex As Integer) _
        As String Implements IStatList.Element

        Get
            _lastItemAccessedIndex = index
            Return GetField(index, fieldIndex)
        End Get
        Set(value As String)
            _lastItemAccessedIndex = index
            SetField(index, fieldIndex) = value
        End Set
    End Property

    ''' <summary>
    ''' Get <see cref="CStatList"/> headers as array of strings
    ''' </summary>
    ''' <returns>String()</returns>
    Public ReadOnly Property Fields As String() Implements IStatList.Fields
        Get
            Return _fields
        End Get
    End Property
    Public ReadOnly Property FieldsNumber As Integer Implements IStatList.FieldsNumber
        Get
            Return _fields.Length
        End Get
    End Property
    ''' <summary>
    ''' Get <see cref="CStatList"/> items number
    ''' </summary>
    ''' <returns><see cref="Integer"/></returns>
    Public ReadOnly Property Count As Integer Implements IStatList.Count
        Get
            Return _items.Count
        End Get
    End Property
    Public ReadOnly Property CanAddFreely As Boolean Implements IStatList.CanAddFreely
        Get
            Return _canAddFreely
        End Get
    End Property
    ''' <summary>
    ''' Used to set value of any field <paramref name="field"/> of element of 
    ''' <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="field"></param>
    Public WriteOnly Property SetField(index As Integer, field As String) As _
        String Implements IStatList.SetField

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
    Public WriteOnly Property SetField(index As Integer, fieldIndex As Integer) _
        As String Implements IStatList.SetField

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
    Public WriteOnly Property SetField() As String Implements IStatList.SetField

        Set(value As String)
            _items(_lastItemAccessedIndex)(_lastItemFieldAccessedIndex) = value
        End Set
    End Property
    ''' <summary>
    ''' Used to get value of any field <paramref name="field"/> of element of 
    ''' <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="field"></param>
    ''' <returns>Field as <see cref="String"/></returns>
    Public ReadOnly Property GetField(index As Integer, field As String) As _
        String Implements IStatList.GetField

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
    ''' Used to get value of field with index of <paramref name="fieldIndex"/> of 
    ''' element of <see cref="CStatList"/> with index <paramref name="index"/>
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="fieldIndex"></param>
    ''' <returns>Field as <see cref="String"/></returns>
    Public ReadOnly Property GetField(index As Integer, fieldIndex As Integer) As _
        String Implements IStatList.GetField

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
    Public ReadOnly Property GetField() As String Implements IStatList.GetField
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
    Public ReadOnly Property LastItemAccessedIndex() As Integer _
        Implements IStatList.LastItemAccessedIndex

        Get
            Return _lastItemAccessedIndex
        End Get
    End Property
    ''' <summary>
    ''' Used to get last accessed field index of last accessed item
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LastItemFieldAccessedIndex As Integer _
        Implements IStatList.LastItemFieldAccessedIndex

        Get
            Return _lastItemFieldAccessedIndex
        End Get
    End Property
    ''' <summary>
    ''' Get sum of field values of multiple items
    ''' </summary>
    ''' <param name="firstItemIndex">Index of first item from what to start</param>
    ''' <param name="itemsNumber">Amount of items what must be summed from <paramref name="firstItemIndex"/></param>
    ''' <param name="fieldName">Name of field value inside what must be summed</param>
    ''' <returns>Sum of field <paramref name="fieldName"/> values of items from <paramref name="firstItemIndex"/> to <paramref name="firstItemIndex"/> + <paramref name="itemsNumber"/></returns>
    Public Function GetFieldsSum(fieldName As String, Optional firstItemIndex As _
                                 Integer = 0, Optional itemsNumber As Integer = -1) As _
                                 Integer Implements IStatList.GetFieldsSum

        Dim result As Integer = 0
        Dim fieldIndex = FindFieldIndex(fieldName)
        If (fieldIndex <> -1) Then
            If (itemsNumber <> -1) Then
                For i As Integer = 0 To itemsNumber - 1
                    result += GetField(firstItemIndex + i, fieldIndex)
                Next
            Else
                For i As Integer = 0 To Count - 1
                    result += GetField(firstItemIndex + i, fieldIndex)
                Next
            End If
        Else
            result = 0
        End If
        Return result
    End Function
    ''' <summary>
    ''' Get sum of field <paramref name="fieldName"/> for all items from 
    ''' <paramref name="fromDate"/> to
    ''' <paramref name="fromDate"/> + <paramref name="days"/><br/><br/>
    ''' For example, to get sum for a week after <paramref name="fromDate"/>, 
    ''' use <paramref name="days"/> = 7.<br/>
    ''' For a week before <paramref name="fromDate"/>, use <paramref name="days"/> = -7 etc.
    ''' </summary>
    ''' <param name="fromDate">Date point from what date period will be counted</param>
    ''' <param name="fieldName">Name of field what have to be summed</param>
    ''' <param name="days">Number of days to sum for. To sum up week after 
    ''' <paramref name="fromDate"/> use days = 7,
    ''' for week before use days = -7 etc.</param>
    ''' <param name="dateFieldName">Name of date field. "Date" by default.</param>
    ''' <returns></returns>
    Public Function GetFieldsSumForPeriod(fromDate As String, fieldName As String,
                                          Optional days As Integer = 7,
                                          Optional dateFieldName As String = "Date") As _
                                          Integer Implements IStatList.GetFieldsSumForPeriod
        Dim result As Integer
        Dim fieldIndex = FindFieldIndex(fieldName)
        If (fieldIndex <> -1) Then
            Dim list As IStatList = AsNew()
            If (days < 0) Then
                result = list.WhereDate(fromDate, "<",, dateFieldName).
                    WhereDate(DateTime.Parse(fromDate).AddDays(days).ToString("yyyy-MM-dd"), ">=",, dateFieldName).
                    GetFieldsSum(fieldName)
            Else
                result = list.WhereDate(fromDate, ">",, dateFieldName).
                    WhereDate(DateTime.Parse(fromDate).AddDays(days).ToString("yyyy-MM-dd"), "<=",, dateFieldName).
                    GetFieldsSum(fieldName)
            End If
        Else
            result = -1
        End If
        Return result
    End Function
    ''' <summary>
    ''' Get average value of field values of multiple items
    ''' </summary>
    ''' <param name="firstItemIndex">Index of first item from what to start</param>
    ''' <param name="itemsNumber">Amount of items for what average must be calculated,
    ''' from <paramref name="firstItemIndex"/></param>
    ''' <param name="fieldName">Name of field values of items inside what must be averaged</param>
    ''' <returns>Average value of field values of multiple items</returns>
    Public Function GetFieldsAverage(fieldName As String,
                                     Optional firstItemIndex As Integer = 0,
                                     Optional itemsNumber As Integer = -1) As Integer _
                                     Implements IStatList.GetFieldsAverage

        Return GetFieldsSum(fieldName, firstItemIndex, itemsNumber) / itemsNumber
    End Function
    ''' <summary>
    ''' Get average of field <paramref name="fieldName"/> for all items from <paramref name="fromDate"/> to
    ''' <paramref name="fromDate"/> + <paramref name="days"/><br/><br/>
    ''' For example, to get average for a week after <paramref name="fromDate"/>, use <paramref name="days"/> = 7.<br/>
    ''' For a week before <paramref name="fromDate"/>, use <paramref name="days"/> = -7 etc.
    ''' </summary>
    ''' <param name="fromDate">Date point from what date period will be counted</param>
    ''' <param name="fieldName">Name of field what have to be averaged</param>
    ''' <param name="days">Number of days to calculate average for. To get average of week after <paramref name="fromDate"/>
    ''' use days = 7, for week before use days = -7 etc.</param>
    ''' <param name="dateFieldName">Name of date field. "Date" by default.</param>
    ''' <returns></returns>
    Public Function GetFieldsAverageForPeriod(fromDate As String, fieldName As String,
                                          Optional days As Integer = 7,
                                          Optional dateFieldName As String = "Date") As _
                                          Integer Implements IStatList.GetFieldsAverageForPeriod

        Return GetFieldsSumForPeriod(fromDate, fieldName, days, dateFieldName) / Abs(days)
    End Function
    ''' <summary>
    ''' Makes copy of existing item
    ''' </summary>
    ''' <param name="index">Index of existing item in list</param>
    ''' <returns>Copy of original item</returns>
    Public Function GetItemCopy(index As Integer) As String() Implements IStatList.GetItemCopy
        Dim itemCopy(FieldsNumber - 1) As String
        For i As Integer = 0 To FieldsNumber - 1
            itemCopy(i) = _items(index)(i)
        Next
        Return itemCopy
    End Function
    ''' <summary>
    ''' Used to get multiple items fields as array of strings.
    ''' </summary>
    ''' <param name="field"></param>
    ''' <param name="indexFrom"></param>
    ''' <param name="numberOfItems"></param>
    ''' <returns>Array of <see cref="String"/></returns>
    Public Function GetFields(field As String, Optional indexFrom As Integer = 0,
                              Optional numberOfItems As Integer = -1) As String() _
                              Implements IStatList.GetFields

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
    Public Function GetFields(fieldIndex As Integer, Optional indexFrom As Integer = 0,
                              Optional numberOfItems As Integer = -1) As String() Implements IStatList.GetFields

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
    Public Function GetIndexOfFirstItemWhere(field As String, fieldAimValue As String) As _
        Integer Implements IStatList.GetIndexOfFirstItemWhere

        Dim fieldIndex = FindFieldIndex(field)
        For i As Integer = 0 To _items.Count - 1
            If (_items(i)(fieldIndex) = fieldAimValue) Then
                Return i
            End If
        Next
        Return -1
    End Function
    ''' <summary>
    ''' Find index of first item in <see cref="CStatList"/> where <paramref name="field"/> has any value of <paramref name="fieldAimValues"/> 
    ''' </summary>
    ''' <param name="field"></param>
    ''' <param name="fieldAimValues"></param>
    ''' <returns></returns>
    Public Function GetIndexOfFirstItemWhere(field As String, fieldAimValues() As String) _
        As Integer Implements IStatList.GetIndexOfFirstItemWhere

        Dim fieldIndex = FindFieldIndex(field)
        For i As Integer = 0 To _items.Count - 1
            For j As Integer = 0 To fieldAimValues.Length - 1
                If (_items(i)(fieldIndex) = fieldAimValues(j)) Then
                    Return i
                End If
            Next
        Next
        Return -1
    End Function
    ''' <summary>
    ''' Delete field from instance of <see cref="CStatList"/><br/>
    ''' Deleted this field from header and from all items
    ''' </summary>
    ''' <param name="fieldName">Name of field what have to be deleted</param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function DeleteFieldFromList(fieldName As String) As CStatList _
        Implements IStatList.DeleteFieldFromList

        _canAddFreely = False
        _inputIndex = Nothing
        _inputIndexMax = Nothing
        Dim fieldIndex = FindFieldIndex(fieldName)
        If (fieldIndex <> -1) Then
            Dim newFieldsNumber = _fieldsNumber - 1
            Dim newFields(_fieldsNumber - 2) As String
            Dim newInputIndexMax As Integer = 0
            Dim i = 0
            Dim c = 0

            While (i < _fieldsNumber)
                If (i <> fieldIndex) Then
                    newFields(c) = _fields(i)
                    c += 1
                End If
                i += 1
            End While
            _fields = newFields

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
        End If
        Return Me
    End Function
    ''' <summary>
    ''' Renames field with original name of <paramref name="fieldName"/><br/>
    ''' Blocks possibility to add new items in this <see cref="CStatList"/> using unparsed strings
    ''' </summary>
    ''' <param name="fieldName">Original field name</param>
    ''' <param name="newFieldName">New field name</param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    ''' 
    ''' TODO
    Public Function RenameField(fieldName As String, newFieldName As String) As _
        CStatList Implements IStatList.RenameField

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
    Public Function AddField(fieldName As String, Optional defaultValue As String = Nothing) _
        As CStatList Implements IStatList.AddField

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
    Public Function GetIndexOfFirstItemWhereDate(dateValue As String,
                                                 Optional condition As String = "=",
                                                 Optional delimiter As String = "-",
                                                 Optional dateFieldName As String = "Date") _
                                                 As Integer Implements IStatList.GetIndexOfFirstItemWhereDate

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
    Public Function Add(newItemStrings() As String, Optional delimiter As String = ",") _
        As CStatList Implements IStatList.Add

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

    Public Function AddItemDirectly(newItem As String()) As CStatList Implements IStatList.AddItemDirectly
        _items.Add(newItem)
        Return Me
    End Function
    Public Function AddItemsDirectly(newItems As List(Of String())) As CStatList Implements IStatList.AddItemsDirectly
        For Each newItem In newItems
            _items.Add(newItem)
        Next
        Return Me
    End Function
    Public Function GetItemsDirectly() As List(Of String()) Implements IStatList.GetItemsDirectly
        Return _items
    End Function
    Public Function GetItemsDirectly(indexFrom As Integer, Optional itemsNumber As Integer = 0) _
        As List(Of String()) Implements IStatList.GetItemsDirectly

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
    Public Function Remove(index As Integer) As CStatList Implements IStatList.Remove
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
    Public Function WhereDate(dateValue As String, Optional condition As String = "=",
                              Optional delimiter As String = "-",
                              Optional dateEntryName As String = "Date") As CStatList Implements IStatList.WhereDate
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
        _items = newItemsList
        Return Me
    End Function
    ''' <summary>
    ''' Used to filter items in <see cref="CStatList"/> by their fields. Only items what have same <paramref name="keyValue"/> of
    ''' <paramref name="header"/> will remain.
    ''' </summary>
    ''' <param name="header"></param>
    ''' <param name="keyValue"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Where(header As String, keyValue As String) As CStatList Implements IStatList.Where
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
    ''' Used to filter items in <see cref="CStatList"/> by their fields. Only items what have any of <paramref name="keyValues"/> in
    ''' <paramref name="header"/> will remain.
    ''' </summary>
    ''' <param name="header"></param>
    ''' <param name="keyValues"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function Where(header As String, keyValues() As String) As CStatList Implements IStatList.Where
        If (keyValues.Length <> 0) Then
            Dim keyIndex As Integer = FindFieldIndex(header)
            Dim newItemsList As New List(Of String())
            For i As Integer = 0 To Count - 1
                For j As Integer = 0 To keyValues.Length - 1
                    If (_items(i)(keyIndex) = keyValues(j)) Then
                        newItemsList.Add(_items(i))
                        Exit For
                    End If
                Next
            Next
            _items = newItemsList
        End If
        Return Me
    End Function
    ''' <summary>
    ''' Used to filter items in <see cref="CStatList"/> by their fields. Only items what have not same <paramref name="keyValue"/> of
    ''' <paramref name="header"/> will remain.
    ''' </summary>
    ''' <param name="header"></param>
    ''' <param name="keyValue"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function WhereNot(header As String, keyValue As String) As CStatList Implements IStatList.WhereNot
        Dim keyIndex As Integer = FindFieldIndex(header)
        Dim newItemsList As New List(Of String())
        For i As Integer = 0 To Count - 1
            If (_items(i).GetValue(keyIndex) <> keyValue) Then
                newItemsList.Add(_items(i))
            End If
        Next
        _items = newItemsList
        Return Me
    End Function
    ''' <summary>
    ''' Used to filter items in <see cref="CStatList"/> by their fields. Only items what do not have any of <paramref name="keyValues"/> in
    ''' <paramref name="header"/> will remain.
    ''' </summary>
    ''' <param name="header"></param>
    ''' <param name="keyValues"></param>
    ''' <returns>Edited instance of this <see cref="CStatList"/></returns>
    Public Function WhereNot(header As String, keyValues() As String) As CStatList Implements IStatList.WhereNot
        If (keyValues.Length <> 0) Then
            Dim keyIndex As Integer = FindFieldIndex(header)
            Dim newItemsList As New List(Of String())
            Dim notInArray As Boolean = True
            For i As Integer = 0 To Count - 1
                notInArray = True
                For j As Integer = 0 To keyValues.Length - 1
                    If (_items(i)(keyIndex) = keyValues(j)) Then
                        notInArray = False
                        Exit For
                    End If
                Next
                If (notInArray) Then
                    newItemsList.Add(_items(i))
                End If
            Next
            _items = newItemsList
        End If
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
        If (inputIndex IsNot Nothing) Then
            inputIndex.CopyTo(newInputIndex, 0)
            _inputIndex = newInputIndex
        End If
        If (inputIndexMax <> Nothing) Then
            _inputIndexMax = inputIndexMax
        End If
        Dim newItems As New List(Of String())
        For Each item In items
            Dim temp(headersNumber - 1) As String
            item.CopyTo(temp, 0)
            newItems.Add(temp)
        Next
        _items = newItems
    End Sub
    Public Function FindFieldIndex(objectKey As String) As Integer Implements IStatList.FindFieldIndex
        For i As Integer = 0 To _fieldsNumber - 1
            If (_fields(i) = objectKey) Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function DateCmp(date1 As String, date2 As String) As Integer Implements IStatList.DateCmp
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
    Public Function AsNew() As CStatList Implements IStatList.AsNew
        Return New CStatList(_fields, _fieldsNumber, _inputIndex, _inputIndexMax, _items)
    End Function
End Class
