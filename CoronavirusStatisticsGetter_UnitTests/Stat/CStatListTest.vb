Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CStatListTest

    <TestMethod()> Public Sub New_Test()
        Dim list As New CoronaStatisticsGetter.CStatList({{"Name", "NametosaveWith", "0"},
                                                         {"Name2", "NametosaveWith2", "1"}})
        Dim resultFields As String() = list.Fields
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
        list.Add({"field1Value,notUsedValue,field2Value"})
        Dim item1 = list(0)
        Assert.AreEqual({"field1Value", "field2Value"}(0), item1(0))
        Assert.AreEqual({"field1Value", "field2Value"}(1), item1(1))
        list(0) = {"newField1Value", "newField2Value"}
        Assert.AreEqual("newField1Value", list(0)(0))
        Assert.AreEqual("newField2Value", list(0)(1))
    End Sub
    <TestMethod> Public Sub FieldsNumberProperty_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"Field1", "Field1ToSaveAs", 0},
                                                         {"Field2", "Field2ToSaveAs", 2}})
        list.Add({"field1Value,notUsedValue,field2Value"})
        Assert.AreEqual(2, list.FieldsNumber)
    End Sub

    <TestMethod> Public Sub SetField_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"Field1", "Field1ToSaveAs", 0},
                                                         {"Field2", "Field2ToSaveAs", 2}})
        list.Add({"field1Value,notUsedValue,field2Value"})
        list.SetField(0, "Field2ToSaveAs") = "newField2Value"
        list.SetField(0, 0) = "newField1Value"
        Assert.AreEqual(list.GetField(0, "Field2ToSaveAs"), "newField2Value")
        Assert.AreEqual(list.GetField(0, "Field1ToSaveAs"), "newField1Value")
        list.SetField() = "AnotherNewField1Value"
        Assert.AreEqual(list.GetField(0, "Field1ToSaveAs"), "AnotherNewField1Value")
    End Sub

    <TestMethod> Public Sub GetField_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"Field1", "Field1ToSaveAs", 0},
                                                         {"Field2", "Field2ToSaveAs", 2}})
        Dim result1 As String = list.GetField(0, "Field2ToSaveAs")
        Dim result2 As String = list.GetField
        list.Add({"field1Value,notUsedValue,field2Value"})
        Dim result3 As String = list.GetField(0, "Field2ToSaveAs")
        Dim result4 As String = list.GetField
        Dim result5 As String = list.GetField(0, 0)
        Assert.AreEqual(Nothing, result1)
        Assert.AreEqual(Nothing, result2)
        Assert.AreEqual("field2Value", result3)
        Assert.AreEqual("field2Value", result4)
        Assert.AreEqual("field1Value", result5)
    End Sub

    <TestMethod> Public Sub GetFields_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 2},
                                                         {"DirectionField", "Direction", 3}})
        list.Add({"2020-02-02,unused,red,right", "2021-01-01,unused,blue,left", "2022-02-02,unused,red,left"})
        Dim result1 = list.GetFields("Date")
        Dim result2 = list.GetFields("Color", 1)
        Dim result3 = list.GetFields("Direction",, 2)
        Dim result4 = list.GetFields("Date", 999)
        Dim result5 = list.GetFields(0)
        Dim result6 = list.GetFields(1, 1)
        Dim result7 = list.GetFields(2,, 2)
        Dim result8 = list.GetFields(0, 999)
        For i As Integer = 0 To 2
            Assert.AreEqual({"2020-02-02", "2021-01-01", "2022-02-02"}(i), result1(i))
            Assert.AreEqual({"2020-02-02", "2021-01-01", "2022-02-02"}(i), result5(i))
        Next
        For i As Integer = 0 To 1
            Assert.AreEqual({"blue", "red"}(i), result2(i))
            Assert.AreEqual({"right", "left"}(i), result3(i))
            Assert.AreEqual({"blue", "red"}(i), result6(i))
            Assert.AreEqual({"right", "left"}(i), result7(i))
        Next
        Assert.AreEqual(Nothing, result4)
        Assert.AreEqual(Nothing, result8)
    End Sub

    <TestMethod> Public Sub GetIndexOfFirstItemWhere_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        Dim result1 = list.GetIndexOfFirstItemWhere("Color", "yellow")
        Dim result2 = list.GetIndexOfFirstItemWhere("Direction", "left")
        Dim result3 = list.GetIndexOfFirstItemWhereDate("2022-02-02", "=")
        Dim result4 = list.GetIndexOfFirstItemWhereDate("2022-02-03", "<")
        Dim result5 = list.GetIndexOfFirstItemWhereDate("2022-02-04", "<=")
        Dim result6 = list.GetIndexOfFirstItemWhereDate("2022-02-03", ">")
        Dim result7 = list.GetIndexOfFirstItemWhereDate("2022-02-03", ">=")
        Dim result8 = list.GetIndexOfFirstItemWhereDate("2022-02-02", "<>")
        Dim result9 = list.GetIndexOfFirstItemWhereDate("2022-02-02", "<!!!>")
        Dim result10 = list.GetIndexOfFirstItemWhere("Direction", "05.123\\\/")

        Assert.AreEqual(2, result1)
        Assert.AreEqual(2, result2)
        Assert.AreEqual(0, result3)
        Assert.AreEqual(0, result4)
        Assert.AreEqual(0, result5)
        Assert.AreEqual(2, result6)
        Assert.AreEqual(1, result7)
        Assert.AreEqual(1, result8)
        Assert.AreEqual(Nothing, result9)
        Assert.AreEqual(-1, result10)
    End Sub

    <TestMethod> Public Sub Remove_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        list.Remove(2)
        Dim result1 = list.GetFields("Color")
        Assert.AreEqual("red", result1(0))
        Assert.AreEqual("blue", result1(1))
        Assert.AreEqual("green", result1(2))
    End Sub
    <TestMethod> Public Sub WhereDate_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        Dim result1 = list.AsNew().WhereDate("2022-02-02", "=").GetFields("Color")(0)
        Dim result2 = list.AsNew().WhereDate("2022-02-03", "<").GetFields("Color")(0)
        Dim result3 = list.AsNew().WhereDate("2022-02-03", "<=").GetFields("Color")(0)
        Dim result4 = list.AsNew().WhereDate("2022-02-03", ">").GetFields("Color")(0)
        Dim result5 = list.AsNew().WhereDate("2022-02-04", ">=").GetFields("Color")(0)
        Dim result6 = list.AsNew().WhereDate("2022-02-02", "<>").GetFields("Color")(0)
        Dim result7 = list.AsNew().WhereDate("2022-02-02", "<!!!>")
        Assert.AreEqual("red", result1)
        Assert.AreEqual("red", result2)
        Assert.AreEqual("red", result3)
        Assert.AreEqual("yellow", result4)
        Assert.AreEqual("yellow", result5)
        Assert.AreEqual("blue", result6)
        Assert.AreEqual(Nothing, result7)
    End Sub
    <TestMethod> Public Sub Where_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        Dim result1 = list.AsNew.Where("Date", "2022-02-03")
        Dim result2 = list.AsNew.Where("Color", "yellow")
        Dim result3 = list.AsNew.Where("Direction", "right")
        Dim result4 = list.AsNew.Where("Direction", "left")
        Assert.AreEqual("blue", result1.GetField(0, "Color"))
        Assert.AreEqual("2022-02-04", result2.GetField(0, "Date"))
        Assert.AreEqual("blue", result3.GetField(1, "Color"))
        Assert.AreEqual("yellow", result4.GetField(0, "Color"))
    End Sub
    <TestMethod> Public Sub WhereNot_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        Dim result1 = list.WhereNot("Direction", "right")
        Dim result2 = list.WhereNot("Color", "red")
        Assert.AreEqual("2022-02-05", result1.GetField(1, "Date"))
        Assert.AreEqual("left", result1.GetField(1, "Direction"))
    End Sub
    <TestMethod> Public Sub DeleteFieldFromList_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        list.DeleteFieldFromList("Color")
        Assert.AreEqual("right", list(0)(1))
    End Sub
    <TestMethod> Public Sub RenameField_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        list.RenameField("Color", "ColorField")
        Assert.AreEqual("red", list.GetField(0, "ColorField"))
    End Sub
    <TestMethod> Public Sub AddField_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        list.AddField("NewField", "12345")
        Assert.AreEqual("12345", list.GetField(2, "NewField"))
    End Sub
    <TestMethod> Public Sub AddItemDirectly_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        list.AddItemDirectly({"2022-02-06", "purple", "right"})
        Assert.AreEqual({"2022-02-06", "purple", "right"}(0), list.GetField(list.Count - 1, 0))
        Assert.AreEqual({"2022-02-06", "purple", "right"}(1), list.GetField(list.Count - 1, 1))
        Assert.AreEqual({"2022-02-06", "purple", "right"}(2), list.GetField(list.Count - 1, 2))
    End Sub
    <TestMethod> Public Sub AddItemsDirectly_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        Dim newItems As New List(Of String())
        newItems.Add({"2022-02-06", "purple", "right"})
        newItems.Add({"2022-02-07", "black", "left"})
        list.AddItemsDirectly(newItems)
        Assert.AreEqual({"2022-02-06", "purple", "right"}(0), list.GetField(list.Count - 2, 0))
        Assert.AreEqual({"2022-02-06", "purple", "right"}(1), list.GetField(list.Count - 2, 1))
        Assert.AreEqual({"2022-02-06", "purple", "right"}(2), list.GetField(list.Count - 2, 2))
        Assert.AreEqual({"2022-02-07", "black", "left"}(0), list.GetField(list.Count - 1, 0))
        Assert.AreEqual({"2022-02-07", "black", "left"}(1), list.GetField(list.Count - 1, 1))
        Assert.AreEqual({"2022-02-07", "black", "left"}(2), list.GetField(list.Count - 1, 2))
    End Sub
    <TestMethod> Public Sub GetItemsDirectly_Test()
        Dim list = New CoronaStatisticsGetter.CStatList({{"DateField", "Date", 0},
                                                         {"ColorField", "Color", 1},
                                                         {"DirectionField", "Direction", 2}})
        list.Add({"2022-02-02,red,right",
                 "2022-02-03,blue,right",
                 "2022-02-04,yellow,left",
                 "2022-02-05,green,left"})
        Dim result1 As String() = list.GetItemsDirectly()(0)
        Dim result2 As String() = list.GetItemsDirectly(1)(0)
        Dim result3 As String() = list.GetItemsDirectly(2, 1)(0)
        Assert.AreEqual("2022-02-02", result1(0))
        Assert.AreEqual("blue", result2(1))
        Assert.AreEqual("left", result3(2))
    End Sub
End Class