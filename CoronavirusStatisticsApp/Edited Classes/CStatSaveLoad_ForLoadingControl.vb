﻿Imports CoronaStatisticsGetter
Public Class CStatSaveLoad_ForLoadingControl
    Inherits CStatSaveLoad
    Implements IStatSavedLoad_ForLoadingControl

    Public Shadows Async Function UpdateData(path As String,
                                             progressValueUpdate As Action(Of Integer)) As Task(Of Boolean) Implements IStatSavedLoad_ForLoadingControl.UpdateData

        Dim saveLoad As IStatSavedLoad_ForLoadingControl = New CStatSaveLoad_ForLoadingControl
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
        ' Load Settings
        If (IO.File.Exists(AppSettings.AppSettingsCachePath + AppSettings.AppSettingsCacheName + ".bin")) Then
            Dim newThread As New Threading.Thread(Sub() LoadAppSettings())
            newThread.IsBackground = True
            newThread.Start()
        End If

        ' Check path
        If (Not IO.Directory.Exists(path)) Then
            IO.Directory.CreateDirectory(path)
        End If
        saveLoad.SaveTo(DateTime.Now, path, "lastCheckDate")
        progressValueUpdate(25)

        ' Check Date
        If (Not IO.File.Exists(path + "lastCheckDate.bin") OrElse
            Not IsUpToDate(LoadFrom(path, "lastCheckDate"))) Then
            ' Delete all old data
            IO.File.Delete(path + "lastCheckDate.bin")
            For Each fileName In fileNames
                IO.File.Delete(path + fileName)
            Next
            progressValueUpdate(35)

            ' Update date
            saveLoad.SaveTo(DateTime.Now, path, "lastCheckDate")
        End If
        Dim statusValue As Integer = 35
        ' If there by some reason are no required data in cache, then download it.
        ' Other case, if all data was deleted in previous condition functions.
        For Each fileName In fileNames
            statusValue += 2
            If (Not IO.File.Exists(path + fileName + "Raw" + ".bin")) Then
                SaveTo(Await CallByName(newDataDownload, "get" + fileName + "Raw", vbMethod), path, fileName + "Raw")
            End If
            progressValueUpdate(statusValue)
        Next
        Return True
    End Function

    Public Sub SaveAppSettings() Implements IStatSavedLoad_ForLoadingControl.SaveAppSettings
        SaveTo(New AppSettingsSerializable, AppSettings.AppSettingsCachePath, AppSettings.AppSettingsCacheName)
    End Sub

    Public Sub LoadAppSettings() Implements IStatSavedLoad_ForLoadingControl.LoadAppSettings
        Dim newAppSettings As AppSettingsSerializable = LoadFrom(AppSettings.AppSettingsCachePath, AppSettings.AppSettingsCacheName)
        newAppSettings.UpdateAppSettings()
        AppSettings.RaiseEventNewColorSettingsApplied()
    End Sub
End Class