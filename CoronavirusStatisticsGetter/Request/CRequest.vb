' FILENAME: CRequest.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 02.03.2022
' CHANGED: 20.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CStatList, CStatObject

Imports System.Net
Imports System.Math
Imports Newtonsoft.Json.Linq
''' <summary>
''' Class used to receive information about coronavirus statistics from "https://opendata.digilugu.ee/"
''' </summary>
Public Class CRequest
    Dim cachePath As String = ""
    ''' <summary>
    ''' get  Covid-19 vaccination statistics grouped by county.<br/>
    ''' Fields:<br/>
    ''' "Date" - date of entry<br/>
    ''' "County" - county of entry<br/>
    ''' "VaccinationSeries"<br/>
    ''' "Type" - type of entry<br/>
    ''' "LocationPopulation" - popilation of county<br/>
    ''' "DailyCount" - number of vaccinated per day<br/>
    ''' "TotalCount" - numeber of vaccinated per all time
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getVaccinationStatByCounty() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "VaccinationStatByCountyRaw")
        Return data.Where("VaccinationSeries", "1").WhereNot("County", "null").WhereNot("County", "")
    End Function
    ''' <summary>
    ''' get Covid-19 vaccination statistics by age group.<br/>
    ''' Fields:<br/>
    ''' "Date" - day of entry<br/>
    ''' "VaccinationSeries"<br/>
    ''' "Type" - type of entry<br/>
    ''' "GroupSize" - size of age group<br/>
    ''' "DailyCount" - number of daily vaccinations in this group<br/>
    ''' "TotalCount" - total number of vaccinations in this group<br/>
    ''' "PopulationCoverage" - vaccination coverage of group<br/>
    ''' "AgeGroup"
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getVaccinationStatByAgeGroup() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "VaccinationStatByAgeGroupRaw")
        Return data.Where("VaccinationSeries", "1").WhereNot("AgeGroup", "null")
    End Function
    ''' <summary>
    ''' get national statistics on vaccination against Covid-19.<br/>
    ''' Fields:<br/>
    ''' "Date" - date of entry<br/>
    ''' "VaccinationSeries"<br/>
    ''' "Type" - entry type<br/>
    ''' "DailyCount" - number of vaccinations this day<br/>
    ''' "TotalCount" - total number of vaccinations<br/>
    ''' "PopulationCoverage"<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getVaccinationStatGeneral() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "VaccinationStatGeneralRaw")
        Dim vaccinatedPercentageIndex As Integer = data.FindFieldIndex("VaccinatedPercentage")
        Dim locationPopulationIndex As Integer = data.FindFieldIndex("EstoniaPopulation")
        Dim totalCountIndex As Integer = data.FindFieldIndex("TotalCount")
        For i As Integer = 0 To data.Count - 1
            If (data.GetField(i, vaccinatedPercentageIndex) = "") Then
                data.SetField(i, vaccinatedPercentageIndex) = (data.GetField(i, totalCountIndex) / data.GetField(i, locationPopulationIndex)) * 100
            End If
        Next
        data.AddField("UnvaccinatedCount")
        data.AddField("UnvaccinatedPercentage")
        Dim typeIndex As Integer = data.FindFieldIndex("Type")
        Dim unvaccinatedCountIndex As Integer = data.FindFieldIndex("UnvaccinatedCount")
        Dim unvaccinatedPercentageIndex As Integer = data.FindFieldIndex("UnvaccinatedPercentage")
        For i As Integer = 0 To data.Count - 1
            If (data(i)(typeIndex) <> "DosesAdministered") Then
                data(i)(unvaccinatedCountIndex) = data(i)(locationPopulationIndex) - data(i)(totalCountIndex)
                data(i)(unvaccinatedPercentageIndex) = 100 - Val(data(i)(vaccinatedPercentageIndex))
            End If
        Next
        Return data
    End Function
    ''' <summary>
    ''' Total number of positive COVID-19 cases and positive cases in last 14 days and same as ratio per 100k.<br/>
    ''' Fields:<br/>
    ''' "Date" - entry date<br/>
    ''' "DailyCases" - daily tests<br/>
    ''' "TotalCases" - total number of tests<br/>
    ''' "Per100k" - coverage of population, ratio per 100k<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getTestStatPositiveGeneral() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "TestStatPositiveGeneralRaw")
        Return data
    End Function
    ''' <summary>
    ''' The data show the number of first tests (cases) as well as the total number of tests with repeat tests.<br/>
    ''' A case is considered to be a first positive or first negative test per person, ie. repeat tests are not considered.<br/>
    ''' Thus, there can be a maximum of 2 cases per person - one positive, one negative. <br/>
    ''' The ranges of both positive and negative cases at the county level are published.<br/>
    ''' Fields:<br/>
    ''' "Date" - date of entry<br/>
    ''' "County"<br/>
    ''' "Result" - result of test "P" or "N"<br/>
    ''' "TotalTests" - total number of tests<br/>
    ''' "DailyTests" - daily number of tests<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getTestStatCounty(Optional countyName As String = "all", Optional positiveOnly As Boolean = True) As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "TestStatCountyRaw")
        If (positiveOnly) Then
            data.Where("Result", "P")
        End If
        If (countyName <> "all") Then
            data.Where("County", countyName)
        End If
        Return data
    End Function
    ''' <summary>
    ''' Average age of people tested this day.<br/>
    ''' Fields:<br/>
    ''' "Date" - date of entry<br/>
    ''' "Gender" - group gender<br/>
    ''' "Result" - result of test<br/>
    ''' "AverageAge" - average age of this group<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getTestStatByAverageAge(Optional positiveOnly As Boolean = True) As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "TestStatByAverageAgeRaw")

        If (positiveOnly) Then
            data.Where("Result", "P")
        End If
        Return data
    End Function
    ''' <summary>
    ''' The average age and average age grouped by genders of hospitalized patients diagnosed with Covid-19. <br/>
    ''' Fields:<br/>
    ''' "Gender" - gender of group, gender of "" or null means what this is average value between male and female groups<br/>
    ''' "AverageAge" - average age of group<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getHospitalizationAveragePatientAgeCurrent() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "HospitalizationAveragePatientAgeCurrentRaw")
        Return data
    End Function
    ''' <summary>
    ''' Total number of patients per gender and age group hospitalized<br/>
    ''' Fields:<br/>
    ''' "Gender" - patient gender<br/>
    ''' "AgeGroup" - patient age group<br/>
    ''' "PatientCount" - number of patients<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getHospitalizationPatientInfoCurrent() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "HospitalizationPatientInfoCurrentRaw")
        Return data
    End Function
    ''' <summary>
    ''' A time series is issued for the average number of days a patient is hospitalized.<br/>
    ''' The average number of days is based on the number of cases that ended, and the average duration of illness in patients on a specific date is calculated.<br/>
    ''' Timeline may not have data for every date if the patients' medical records on that date have not yet been completed.
    ''' Fields:<br/>
    ''' "Date" - entry date<br/>
    ''' "AverageDays"<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getAverageHospitalizationTime() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "AverageHospitalizationTimeRaw")
        For i As Integer = 0 To data.Count - 1
            data.SetField() = data.GetField(i, "Date").Split("T")(0)
        Next
        Return data
    End Function
    ''' <summary>
    ''' A statistical timeline for hospitalizations diagnosed with Covid-19 is issued.<br/>
    ''' A distinction is made between patients and cases.<br/>
    ''' A case is considered to be a hospitalization of a patient with a diagnosis of Covid-19, which may involve movement between hospitals.<br/>
    ''' The case ends with discharge from the hospital.<br/>
    ''' Several cases can also be counted per patient if the patient is re-admitted to the hospital after the completed case.<br/>
    ''' For technical and methodological reasons, timeline may show minor statistical deviations from previously published statistics.<br/>
    ''' This is due to the time recording of the timeline and the receipt of data or corrections for the current day.<br/>
    ''' The open data shall reflect the most recent state of knowledge, including revisions and data quality improvements.<br/>
    ''' Fields:<br/>
    ''' "Date" - date of entry<br/>
    ''' "Hospitalised" - patients hospitalized<br/>
    ''' "ActivelyHospitalised" - patients really hospitalized and not discharged<br/>
    ''' "OnVentilation"<br/>
    ''' "InIntensive"<br/>
    ''' "Discharged" - patients who left the hospital<br/>
    ''' "NewCases"<br/>
    ''' "TotalCases"<br/>
    ''' "TotalCasesDischarged"<br/>
    ''' "NewPatients"<br/>
    ''' "TotalPatients"<br/>
    ''' "TotalPatientsDischarged"<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function getHospitalizationPatients() As CStatList
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "HospitalizationPatientsRaw")
        For i As Integer = 0 To data.Count - 1
            data.SetField() = data.GetField(i, "Date").Split("T")(0)
        Next
        Return data
    End Function
    ''' <summary>
    ''' Deceased number this day<br/>
    ''' Fields:<br/>
    ''' - Date:     date<br/>
    ''' - Deceased: number of people died<br/>
    ''' </summary>
    ''' <param name="accumulative">Should list be accumulative (each next by date entry is a sum of all deceased happened
    ''' in preious day)</param>
    ''' <returns></returns>
    Public Function getDeceased(Optional accumulative As Boolean = False) As CStatList
        Dim list As CStatList = CStatSaveLoad.LoadFrom(cachePath, "DeceasedRaw")
        Dim i As Integer = 0
        If (accumulative <> True) Then
            While (i < list.Count - 1)
                list.SetField(i, 1) = Max(list.GetField(i, 1) - list.GetField(i + 1, 1), 0)
                i = i + 1
            End While
        End If
        Return list
    End Function

    ''' <summary>
    ''' get number of people currently sick at selected date. <br/>
    ''' Calculated as total number of positive cases in last <paramref name="period"/> days.<br/>
    ''' Fields:<br/>
    ''' "Date"<br/>
    ''' "Sick" - number of people currently sick at selected date.
    ''' </summary>
    ''' <param name="period"></param>
    ''' <returns></returns>
    Public Function getSick(Optional period As Integer = 14) As CStatList
        period = Max(0, period - 1)
        Dim data As CStatList = CStatSaveLoad.LoadFrom(cachePath, "SickRaw")
        Dim sickFieldNumber = data.FindFieldIndex("Sick")
        Dim dailyFieldNumber = data.FindFieldIndex("DailyCases")
        Dim i = 0
        data(i)(sickFieldNumber) = 0
        If (i < period) Then
            For c As Integer = 0 To period
                If (i - c < 0) Then
                    Exit For
                End If
                data(i)(sickFieldNumber) = CInt(data(i)(sickFieldNumber)) + CInt(data(i - c)(dailyFieldNumber))
            Next
        Else
            data(i)(sickFieldNumber) = CInt(data(i)(sickFieldNumber)) + CInt(data(i - 1)(sickFieldNumber))
            data(i)(sickFieldNumber) = CInt(data(i)(sickFieldNumber)) + CInt(data(i)(dailyFieldNumber))
            data(i)(sickFieldNumber) = CInt(data(i)(sickFieldNumber)) - CInt(data(i - period)(dailyFieldNumber))
        End If
        data.DeleteFieldFromList("DailyCases")
        Return data
    End Function
    ''' <summary>
    ''' get number of people currently sick at selected date by county. <br/>
    ''' Calculated as total number of positive cases in last <paramref name="period"/> days.<br/>
    ''' Fields:<br/>
    ''' "Date"<br/>
    ''' "Sick" - number of people currently sick at selected date.<br/>
    ''' "County"
    ''' </summary>
    ''' <param name="period"></param>
    ''' <param name="aimCounty"></param>
    ''' <returns></returns>
    Public Function getSickCounty(Optional period As Integer = 14, Optional aimCounty As String = Nothing) As CStatList
        period = Max(0, period - 1)
        Dim list As CStatList = Me.getTestStatCounty()
        Dim counties As New List(Of CStatList)
        Dim sickFieldNumber, dailyFieldNumber As Integer
        If (aimCounty IsNot Nothing) Then
            list.Where("County", aimCounty)
        End If
        list.RenameField("TotalTests", "Sick")
        While (list.Count > 0)
            ' Add all entries with this county as independent CStatList
            counties.Add(list.AsNew.Where("County", list.GetField(0, "County")))
            ' Remove entries with this county from list
            list.WhereNot("County", list.GetField(0, "County"))
        End While
        sickFieldNumber = list.FindFieldIndex("Sick")
        dailyFieldNumber = list.FindFieldIndex("DailyTests")
        For Each county In counties
            For i As Integer = 0 To county.Count - 1
                county(i)(sickFieldNumber) = 0
                If (i < period) Then
                    For c As Integer = 0 To period
                        If (i - c < 0) Then
                            Exit For
                        End If
                        county(i)(sickFieldNumber) = CInt(county(i)(sickFieldNumber)) + CInt(county(i - c)(dailyFieldNumber))
                    Next
                Else
                    county(i)(sickFieldNumber) = CInt(county(i)(sickFieldNumber)) + CInt(county(i - 1)(sickFieldNumber))
                    county(i)(sickFieldNumber) = CInt(county(i)(sickFieldNumber)) + CInt(county(i)(dailyFieldNumber))
                    county(i)(sickFieldNumber) = CInt(county(i)(sickFieldNumber)) - CInt(county(i - period)(dailyFieldNumber))
                End If
            Next
        Next
        For Each county In counties
            list.AddItemsDirectly(county.GetItemsDirectly)
        Next
        list.DeleteFieldFromList("Result")
        list.DeleteFieldFromList("DailyTests")
        Return list
    End Function
    Public Shared Function ParseCSVToCStatList(rawCSV As String, fields As Array) As CStatList
        Dim data As String() = rawCSV.Replace("""", "").Split(vbLf)
        Dim headers As String() = data(0).Split(",")
        Dim parsedFields(fields.Length - 1, 2) As String
        Dim i As Integer = 0
        Dim statList As CStatList
        ' Parse fields to divide aim input value and saveto value
        For Each field As String In fields
            If (field.Contains("||")) Then
                Dim splitted As String() = field.Split("||")
                parsedFields(i, 0) = splitted(0)
                parsedFields(i, 1) = splitted(2)
            Else
                parsedFields(i, 0) = field
                parsedFields(i, 1) = field
            End If
            i = i + 1
        Next
        i = 0
        ' Find input headers corresponding to parsed fields
        For Each header As String In headers
            For c As Integer = 0 To fields.Length - 1
                If (header = parsedFields(c, 0)) Then
                    parsedFields(c, 2) = i
                End If
            Next
            i = i + 1
        Next
        ' Initialize stat object
        data(0) = Nothing
        statList = New CStatList(parsedFields)
        statList.Add(data, ",")
        Return statList
    End Function

    Public Sub New(newCachePath As String)
        cachePath = newCachePath
    End Sub

    ' Obsolete
    'Private Function ParseCSVToCStatObject(rawCSV As String, fields As Array) As CStatObject
    'Dim data As String() = rawCSV.Replace("""", "").Split(vbLf)
    'Dim headers As String() = data(0).Split(",")
    'Dim i As Integer = 0
    'Dim objectsCollection As New CStatObject
    'Dim aimFields(fields.Length - 1) As Collection
    '
    ' Build key-value objects for each of aim fields
    'While (i < fields.Length)
    'Dim newAimField As New Collection
    'If (fields(i).Contains("||")) Then
    'Dim splitted = fields(i).Split("||")
    '            newAimField.Add(splitted(0), "aimName")
    '            newAimField.Add(splitted(2), "saveAs")
    '        Else
    '            newAimField.Add(fields(i), "aimName")
    '            newAimField.Add(fields(i), "saveAs")
    '        End If
    '        aimFields(i) = newAimField
    '        i = i + 1
    '    End While
    '    i = 0
    '
    '    ' Add aim headers indexes into correspondings aimFields
    '    While (i < headers.Length)
    'For Each aimField As Collection In aimFields
    'If (headers(i) = aimField.Item("aimName")) Then
    '                aimField.Add(i, "index")
    '                Exit For
    'End If
    'Next
    '        i = i + 1
    '    End While
    '    i = 1
    '
    '    While (i < data.Length - 1)
    'Dim newObject As New Collection
    'Dim objectData As String() = Data(i).Split(",")
    'For Each aimField As Collection In aimFields
    '            newObject.Add(objectData(aimField.Item("index")), aimField.Item("saveAs"))
    '        Next
    '        objectsCollection.Add(newObject)
    '        i = i + 1
    '    End While
    'Return objectsCollection
    'End Function
    '
    'Private Function ParseJSONToStatObject(rawJson As String, fields As Array) As CStatObject
    '    rawJson = "{""body"":" + rawJson + "}"
    '    Dim json As JArray = JObject.Parse(rawJson).Exists("body")
    '    Dim i = 0
    '    Dim objectCollection As New CStatObject
    '    While (i < json.Count)
    '        Dim newObject As New Collection
    '        Dim dontSave As Boolean = False
    '        For Each field As String In fields
    '            Dim saveAs As String
    '            Dim parameter As String
    '            If (field.Contains("||")) Then
    '                Dim splitted = field.Split("||")
    '                saveAs = splitted(2)
    '                parameter = json(i).Exists(splitted(0)).ToString
    '            Else
    '                saveAs = field
    '                parameter = json(i).Exists(field).ToString
    '            End If
    '            If (parameter IsNot Nothing) Then
    '                newObject.Add(parameter, saveAs)
    '            Else
    '                dontSave = True
    '            End If
    '        Next
    '        If (dontSave = False) Then
    '            objectCollection.Add(newObject)
    '        End If
    '        i = i + 1
    '    End While
    '    Return objectCollection
    'End Function
End Class
