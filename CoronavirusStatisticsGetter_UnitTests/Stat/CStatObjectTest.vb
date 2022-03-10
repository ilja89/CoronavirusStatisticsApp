Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CStatObjectTest

    <TestMethod()> Public Sub New_Test()
        Dim list As New CoronaStatisticsGetter.CStatList({{"Name", "NametosaveWith", "0"},
                                                         {"Name2", "NametosaveWith2", "1"}})
        Dim resultFields As String() = list.Headers
        Dim expectedResult As String() = {"NametosaveWith", "NametosaveWith2"}
        Assert.AreEqual(resultFields(0), expectedResult(0))
        Assert.AreEqual(resultFields(1), expectedResult(1))

        Dim resultCount = list.Count
        Assert.AreEqual(0, resultCount)
        Dim resultLastItemAccessedIndex As Integer = list.LastItemAccessedIndex
        Dim resultLastItemFieldAccessedIndex As Integer = list.LastItemFieldAccessedIndex
        Dim resultGetField = list.GetField
        Assert.AreEqual(0, resultLastItemAccessedIndex)
        Assert.AreEqual(0, resultLastItemFieldAccessedIndex)
        Assert.AreEqual(Nothing, resultGetField)
    End Sub
    <TestMethod> Public Sub ElementProperty_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"Field1", "Field1ToSaveAs", 0},
                                                         {"Field2", "Field2ToSaveAs", 2}})
        list.Add("field1Value,notUsedValue,field2Value".Split(","))
        Dim item1 = list(0)
        Assert.AreEqual({"field1Value", "field2Value"}(0), item1(0))
        Assert.AreEqual({"field1Value", "field2Value"}(1), item1(1))
    End Sub

    <TestMethod> Public Sub SetField_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"Field1", "Field1ToSaveAs", 0},
                                                         {"Field2", "Field2ToSaveAs", 2}})
        list.Add("field1Value,notUsedValue,field2Value".Split(","))
        list.SetField(0, "Field2ToSaveAs") = "newField2Value"
        Assert.AreEqual(list.GetField(0, "Field2ToSaveAs"), "newField2Value")
    End Sub

End Class