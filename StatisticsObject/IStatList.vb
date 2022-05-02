Public Interface IStatList

    Default Property Element(Index As Integer) As String()

    Default Property Element(index As Integer, fieldName As String) As String

    Default Property Element(index As Integer, fieldIndex As Integer) As String

    ReadOnly Property Fields As String()

    ReadOnly Property FieldsNumber As Integer

    ReadOnly Property Count As Integer

    ReadOnly Property CanAddFreely As Boolean

    WriteOnly Property SetField(index As Integer, field As String) As String

    WriteOnly Property SetField(index As Integer, fieldIndex As Integer) As String

    WriteOnly Property SetField() As String

    ReadOnly Property GetField(index As Integer, field As String) As String

    ReadOnly Property GetField(index As Integer, fieldIndex As Integer) As String

    ReadOnly Property GetField() As String

    ReadOnly Property LastItemAccessedIndex() As Integer

    ReadOnly Property LastItemFieldAccessedIndex As Integer

    Function GetFieldsSum(fieldName As String, Optional firstItemIndex _
                          As Integer = 0, Optional itemsNumber As Integer = -1) As Integer

    Function GetFieldsSumForPeriod(fromDate As String, fieldName As String,
                                          Optional days As Integer = 7,
                                          Optional dateFieldName As String = "Date") As Integer

    Function GetFieldsAverage(fieldName As String, Optional firstItemIndex As Integer = 0,
                              Optional itemsNumber As Integer = -1) As Integer

    Function GetFieldsAverageForPeriod(fromDate As String, fieldName As String,
                                          Optional days As Integer = 7,
                                          Optional dateFieldName As String = "Date") As Integer

    Function GetItemCopy(index As Integer) As String()

    Function GetFields(field As String, Optional indexFrom As Integer = 0,
                       Optional numberOfItems As Integer = -1) As String()

    Function GetFields(fieldIndex As Integer, Optional indexFrom As Integer = 0,
                       Optional numberOfItems As Integer = -1) As String()

    Function GetIndexOfFirstItemWhere(field As String, fieldAimValue As String) As Integer

    Function GetIndexOfFirstItemWhere(field As String, fieldAimValues() As String) As Integer

    Function DeleteFieldFromList(fieldName As String) As CStatList

    Function RenameField(fieldName As String, newFieldName As String) As CStatList

    Function AddField(fieldName As String, Optional defaultValue As String = Nothing) As CStatList

    Function GetIndexOfFirstItemWhereDate(dateValue As String,
                                          Optional condition As String = "=",
                                          Optional delimiter As String = "-",
                                          Optional dateFieldName As String = "Date") As Integer

    Function Add(newItemStrings() As String, Optional delimiter As String = ",") As CStatList

    Function AddItemDirectly(newItem As String()) As CStatList

    Function AddItemsDirectly(newItems As List(Of String())) As CStatList

    Function GetItemsDirectly() As List(Of String())

    Function GetItemsDirectly(indexFrom As Integer, Optional itemsNumber As Integer = 0) _
        As List(Of String())

    Function Remove(index As Integer) As CStatList

    Function WhereDate(dateValue As String, Optional condition As String = "=",
                       Optional delimiter As String = "-",
                       Optional dateEntryName As String = "Date") As CStatList

    Function Where(header As String, keyValue As String) As CStatList

    Function Where(header As String, keyValues() As String) As CStatList

    Function WhereNot(header As String, keyValue As String) As CStatList

    Function WhereNot(header As String, keyValues() As String) As CStatList

    Function FindFieldIndex(objectKey As String) As Integer

    Function DateCmp(date1 As String, date2 As String) As Integer

    Function AsNew() As CStatList

End Interface
