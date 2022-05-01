' FILENAME: CStatSaveLoad.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 06.04.2022
' CHANGED: 07.04.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: StatisticsObject
Imports System.Math
Imports DataDownload
''' <summary>
''' Used to save and load data from / to binary files on disk and update outdated or absent info.
''' </summary>
Public Class CStatSaveLoad
    Implements IStatSaveLoad
    ''' <summary>
    ''' Used to save object into binary file.
    ''' </summary>
    ''' <param name="aimObject">An object to save</param>
    ''' <param name="path">Path to folder where this object will be saved</param>
    ''' <param name="fileName">New file name</param>
    Public Sub SaveTo(aimObject As Object, path As String, fileName As String) Implements IStatSaveLoad.SaveTo
        Dim formatter As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim stream As IO.Stream
        Dim fullPath As String = ""
        If (Not IO.Directory.Exists(path)) Then
            IO.Directory.CreateDirectory(path)
        End If
        formatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        If (path.Chars(path.Length - 1) = "\" Or path.Chars(path.Length - 1) = "/") Then
            fullPath = path + fileName + ".bin"
        Else
            fullPath = path + "\" + fileName + ".bin"
        End If
        stream = New IO.FileStream(fullPath, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
        formatter.Serialize(stream, aimObject)
        stream.Close()
    End Sub
    ''' <summary>
    ''' Used to load object from binary file saved on disk.
    ''' </summary>
    ''' <param name="path">Path to folder where aim object is saved</param>
    ''' <param name="name">Name of aim object file</param>
    ''' <returns>Loaded object</returns>
    Public Function LoadFrom(path As String, name As String) As Object Implements IStatSaveLoad.LoadFrom
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
    ''' <summary>
    ''' Checks if all information related to statistics is up to date. Digilugu updates 
    ''' info every day at ~9.00-12.00
    ''' </summary>
    ''' <param name="lastUpdateDate">DateTime object what shows date of last 
    ''' update made</param>
    ''' <returns>True if object is up to date, false if not</returns>
    Protected Function IsUpToDate(lastUpdateDate As DateTime) Implements IStatSaveLoad.IsUpToDate
        Dim now As DateTime = DateTime.Now
        If (DateTime.Compare(lastUpdateDate, now.AddDays(-1)) < 0 Or
            (lastUpdateDate.Day = now.Day And lastUpdateDate.Hour < 13 And now.Hour >= 13) Or
            (lastUpdateDate.Day = now.AddDays(-1).Day And now.Hour >= 13)) Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Updates statistics raw data, saved in cache.
    ''' </summary>
    ''' <param name="path">Path to folder where cached statistics files are saved</param>
    ''' <returns>Returns True when finished</returns>
    Public Overridable Async Function UpdateData(path As String) As Task(Of Boolean) _
        Implements IStatSaveLoad.UpdateData

        Dim saveLoad As New CStatSaveLoad
        Dim newDataDownload As New CDataDownload
        Dim fileNames() As String = {
            "VaccinationStatByCounty",
            "VaccinationStatByAgeGroup",
            "VaccinationStatGeneral",
            "TestStatPositiveGeneral",
            "TestStatCounty",
            "TestStatByAverageAge",
            "HospitalizationAveragePatientAgeCurrent",
            "HospitalizationPatientInfoCurrent",
            "AverageHospitalizationTime",
            "HospitalizationPatients",
            "Deceased",
            "Sick"}
        ' Check path
        If (Not IO.Directory.Exists(path)) Then
            IO.Directory.CreateDirectory(path)
        End If
        saveLoad.SaveTo(DateTime.Now, path, "lastCheckDate")

        ' Check Date
        If (Not IO.File.Exists(path + "lastCheckDate.bin") OrElse
            Not IsUpToDate(LoadFrom(path, "lastCheckDate"))) Then
            ' Delete all old data
            IO.File.Delete(path + "lastCheckDate.bin")
            For Each fileName In fileNames
                IO.File.Delete(path + fileName)
            Next

            ' Update date
            saveLoad.SaveTo(DateTime.Now, path, "lastCheckDate")
        End If
        ' If there by some reason are no required data in cache, then download it.
        ' Other case, if all data was deleted in previous condition functions.
        For Each fileName In fileNames
            If (Not IO.File.Exists(path + fileName + "Raw")) Then
                SaveTo(Await CallByName(newDataDownload, "get" + fileName + "Raw", vbMethod), path, fileName + "Raw")
            End If
        Next

        Return True
    End Function
End Class
