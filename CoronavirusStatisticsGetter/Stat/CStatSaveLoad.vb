Imports System.Math
Public Class CStatSaveLoad
    Public Shared Sub SaveTo(aimObject As Object, path As String, name As String)
        Dim formatter As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim stream As IO.Stream
        Dim fullPath As String = ""
        formatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        If (path.Chars(path.Length - 1) = "\" Or path.Chars(path.Length - 1) = "/") Then
            fullPath = path + name + ".bin"
        Else
            fullPath = path + "\" + name + ".bin"
        End If
        stream = New IO.FileStream(fullPath, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
        formatter.Serialize(stream, aimObject)
        stream.Close()
    End Sub

    Public Shared Function LoadFrom(path As String, name As String)
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim stream As IO.Stream
        Dim fullPath As String = ""
        If (path.Chars(path.Length - 1) = "\" Or path.Chars(path.Length - 1) = "/") Then
            fullPath = path + "\" + name + ".bin"
        Else
            fullPath = path + name + ".bin"
        End If
        stream = New IO.FileStream(fullPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
        Dim returnable As CStatList = DirectCast(formatter.Deserialize(stream), CStatList)
        stream.Close()
        Return returnable
    End Function

    Public Shared Function IsUpToDate(lastUpdateDate As DateTime)
        Dim now As DateTime = DateTime.Now
        If (DateTime.Compare(lastUpdateDate, now.AddDays(-1)) < 0 Or
            (lastUpdateDate.Day = now.Day And lastUpdateDate.Hour < 13 And now.Hour >= 13) Or
            (lastUpdateDate.Day = now.AddDays(-1).Day And now.Hour >= 13)) Then
            Return False
        End If
        Return False
    End Function
End Class
