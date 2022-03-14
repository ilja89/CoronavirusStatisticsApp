' FILENAME: CTelegramBot.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 02.03.2022
' CHANGED: 05.03.2022
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
    ''' <summary>
    ''' Get Covid-19 vaccination statistics grouped by county.<br/>
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
    Public Async Function GetVaccinationStatByCounty() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_location_county.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "LocationCounty||County", "VaccinationSeries", "MeasurementType||Type", "LocationPopulation",
            "DailyCount", "TotalCount"})
        Return data.Where("VaccinationSeries", "1").WhereNot("County", "null")
    End Function
    ''' <summary>
    ''' Get Covid-19 vaccination statistics by age group.<br/>
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
    Public Async Function GetVaccinationStatByAgeGroup() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_agegroup.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type", "LocationPopulation||GroupSize",
            "DailyCount", "TotalCount", "PopulationCoverage", "AgeGroup"})
        Return data.Where("VaccinationSeries", "1").WhereNot("AgeGroup", "null")
    End Function
    ''' <summary>
    ''' Get national statistics on vaccination against Covid-19.<br/>
    ''' Fields:<br/>
    ''' "Date" - date of entry<br/>
    ''' "VaccinationSeries"<br/>
    ''' "Type" - entry type<br/>
    ''' "DailyCount" - number of vaccinations this day<br/>
    ''' "TotalCount" - total number of vaccinations<br/>
    ''' "PopulationCoverage"<br/>
    ''' </summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Async Function GetVaccinationStatGeneral() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_total.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type", "DailyCount", "TotalCount", "PopulationCoverage"})
        Return data.Where("VaccinationSeries", "1")
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
    Public Async Function GetTestStatPositiveGeneral() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
        Return ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCases", "PerPopulation||Per100k"})
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
    Public Async Function GetTestStatCounty(Optional countyName As String = "all", Optional positiveOnly As Boolean = True) As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_test_county_all.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "County", "ResultValue||Result", "TotalTests", "DailyTests"})
        data.WhereNot("County", "")
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
    Public Async Function GetTestStatByAverageAge(Optional positiveOnly As Boolean = True) As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_avg_age_by_result.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"ResultDate||Date", "Gender", "ResultValue||Result", "AverageAge"})

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
    Public Async Function GetHospitalizationAveragePatientAgeCurrent() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_age.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"Gender", "AverageAge"})
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
    Public Async Function GetHospitalizationPatientInfoCurrent() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_profile.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"Gender", "AgeGroup", "PatientCount"})
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
    Public Async Function GetAverageHospitalizationTime() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_days.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "AverageDays"})
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
    Public Async Function GetHospitalizationPatients() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_timeline.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "Hospitalised", "ActivelyHospitalised",
            "IsOnVentilation||OnVentilation", "IsInIntensive||InIntensive", "Discharged",
            "NewCases", "TotalCases", "TotalCasesDischarged", "NewPatients",
            "TotalPatients", "TotalPatientsDischarged"})
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
    Public Async Function GetDeceased(Optional accumulative As Boolean = False) As Task(Of CStatList)
        Dim rawJson As String = Await (New WebClient).DownloadStringTaskAsync("https://koroonakaart.ee/data.json")
        Dim json As JObject = JObject.Parse(rawJson)
        Dim dates As JArray = json.Exists("dates2")
        Dim deceasedNumber As JArray = json.Exists("deceased")
        Dim list As New CStatList({{0, "Date", 0}, {0, "Deceased", 1}})
        Dim i As Integer = Min(dates.Count, deceasedNumber.Count) - 1
        While (i >= 0)
            list.AddItemDirectly({dates(i).Value(Of String), deceasedNumber(i).Value(Of String)})
            i -= 1
        End While
        If (accumulative <> True) Then
            i = 0
            While (i < list.Count - 1)
                list.SetField(i, 1) = Max(list.GetField(i, 1) - list.GetField(i + 1, 1), 0)
                i = i + 1
            End While
        End If
        Return list
    End Function

    Public Async Function GetSick(Optional period As Integer = 14) As Task(Of CStatList)
        period = Max(0, period - 1)
        Dim csv As String = Await (New WebClient).DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCasesLast14D||Sick"})
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
        data.DeleteFieldFromItems("DailyCases")
        Return data
    End Function

    Public Async Function GetSickCounty(Optional period As Integer = 14, Optional aimCounty As String = "all") As Task(Of CStatList)
        period = Max(0, period - 1)
        Dim list As CStatList = Await GetTestStatCounty()
        Dim counties As New List(Of CStatList)
        Dim sickFieldNumber, dailyFieldNumber As Integer
        list.Where("County", aimCounty)
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
        list.DeleteFieldFromItems("Result")
        list.DeleteFieldFromItems("DailyTests")
        Return list
    End Function
    Private Function ParseCSVToCStatList(rawCSV As String, fields As Array) As CStatList
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
