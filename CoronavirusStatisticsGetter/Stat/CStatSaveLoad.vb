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

    Public Shared Function LoadFrom(path As String, name As String) As Object
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim stream As IO.Stream
        Dim fullPath As String = ""
        If (path.Chars(path.Length - 1) = "\" Or path.Chars(path.Length - 1) = "/") Then
            fullPath = path + "\" + name + ".bin"
        Else
            fullPath = path + name + ".bin"
        End If
        stream = New IO.FileStream(fullPath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
        Dim returnable As Object = formatter.Deserialize(stream)
        stream.Close()
        Return returnable
    End Function

    Private Shared Function IsUpToDate(lastUpdateDate As DateTime)
        Dim now As DateTime = DateTime.Now
        If (DateTime.Compare(lastUpdateDate, now.AddDays(-1)) < 0 Or
            (lastUpdateDate.Day = now.Day And lastUpdateDate.Hour < 13 And now.Hour >= 13) Or
            (lastUpdateDate.Day = now.AddDays(-1).Day And now.Hour >= 13)) Then
            Return False
        End If
        Return False
    End Function

    Public Shared Async Function UpdateData(path As String) As Task(Of Boolean)
        Dim r As New CRequest
        ' Check Date
        If (IO.File.Exists(path + "lastCheckDate.bin") = False OrElse
            Not IsUpToDate(DirectCast(CStatSaveLoad.LoadFrom(path, "lastCheckDate"), DateTime))) Then
            ' Delete all old data
            IO.File.Delete(path + "lastCheckDate.bin")
            IO.File.Delete(path + "VaccinationStatByCounty.bin")
            IO.File.Delete(path + "VaccinationStatByAgeGroup.bin")
            IO.File.Delete(path + "VaccinationStatGeneral.bin")
            IO.File.Delete(path + "TestStatPositiveGeneral.bin")
            IO.File.Delete(path + "TestStatCounty.bin")
            IO.File.Delete(path + "TestStatByAverageAge.bin")
            IO.File.Delete(path + "HospitalizationAveragePatientAgeCurrent.bin")
            IO.File.Delete(path + "HospitalizationPatientInfoCurrent.bin")
            IO.File.Delete(path + "AverageHospitalizationTime.bin")
            IO.File.Delete(path + "HospitalizationPatients.bin")
            IO.File.Delete(path + "Deceased.bin")
            IO.File.Delete(path + "Sick.bin")
            IO.File.Delete(path + "SickCounty.bin")

            ' Update date
            CStatSaveLoad.SaveTo(DateTime.Now, path, "lastCheckDate")

            ' Update data
            SaveTo(Await r.getVaccinationStatByCounty, path, "VaccinationStatByCounty")
            SaveTo(Await r.getVaccinationStatByAgeGroup, path, "VaccinationStatByAgeGroup")
            SaveTo(Await r.getVaccinationStatGeneral, path, "VaccinationStatGeneral")
            SaveTo(Await r.getTestStatPositiveGeneral, path, "TestStatPositiveGeneral")
            SaveTo(Await r.getTestStatCounty, path, "TestStatCounty")
            SaveTo(Await r.getTestStatByAverageAge, path, "TestStatByAverageAge")
            SaveTo(Await r.getHospitalizationAveragePatientAgeCurrent, path, "HospitalizationAveragePatientAgeCurrent")
            SaveTo(Await r.getAverageHospitalizationTime, path, "AverageHospitalizationTime")
            SaveTo(Await r.getHospitalizationPatients, path, "HospitalizationPatients")
            SaveTo(Await r.getHospitalizationPatientInfoCurrent, path, "HospitalizationPatientInfoCurrent")
            SaveTo(Await r.getDeceased, path, "Deceased")
            SaveTo(Await r.getSick, path, "Sick")
            SaveTo(Await r.getSickCounty, path, "SickCounty")
        End If
        Return True
    End Function
End Class
