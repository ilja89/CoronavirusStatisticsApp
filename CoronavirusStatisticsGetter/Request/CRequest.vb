' FILENAME: CRequest.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 02.03.2022
' CHANGED: 20.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CStatList, CStatObject, CDataDownload

Imports System.Net
Imports System.Math
Imports Newtonsoft.Json.Linq
''' <summary>
''' Class used to process received information about coronavirus statistics from <see href="https://opendata.digilugu.ee/"/>
''' and other sources.
''' </summary>
Public Class CRequest
    Implements IRequest

    Dim cachePath As String = ""
    Dim saveLoad As New CStatSaveLoad
    ''' <summary>
    ''' Get Covid-19 vaccination statistics grouped by county.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"County" - county of entry<br/></item>
    ''' <item>"VaccinationSeries"<br/></item>
    ''' <item>"Type" - type of entry<br/></item>
    ''' <item>"LocationPopulation" - popilation of county<br/></item>
    ''' <item>"DailyCount" - number of vaccinated per day<br/></item>
    ''' <item>"TotalCount" - numeber of vaccinated per all time</item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetVaccinationStatByCounty() As CStatList Implements IRequest.GetVaccinationStatByCounty
        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "VaccinationStatByCountyRaw")
        Return data.Where("VaccinationSeries", "1").WhereNot("County", "null").WhereNot("County", "")
    End Function
    ''' <summary>
    ''' Get Covid-19 vaccination statistics by age group.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - day of entry<br/></item>
    ''' <item>"VaccinationSeries"<br/></item>
    ''' <item>"Type" - type of entry<br/></item>
    ''' <item>"GroupSize" - size of age group<br/></item>
    ''' <item>"DailyCount" - number of daily vaccinations in this group<br/></item>
    ''' <item>"TotalCount" - total number of vaccinations in this group<br/></item>
    ''' <item>"PopulationCoverage" - vaccination coverage of group<br/></item>
    ''' <item>"AgeGroup"</item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetVaccinationStatByAgeGroup() As CStatList _
        Implements IRequest.GetVaccinationStatByAgeGroup

        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "VaccinationStatByAgeGroupRaw")
        Return data.Where("VaccinationSeries", "1").WhereNot("AgeGroup", "null")
    End Function
    ''' <summary>
    ''' Get national statistics on vaccination against Covid-19.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"VaccinationSeries"<br/></item>
    ''' <item>"Type" - entry type<br/></item>
    ''' <item>"DailyCount" - number of vaccinations this day<br/></item>
    ''' <item>"TotalCount" - total number of vaccinations<br/></item>
    ''' <item>"PopulationCoverage"<br/></item>
    ''' <item>"UnvaccinatedCount"<br/></item>
    ''' <item>"UnvaccinatedPercentage"<br/></item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetVaccinationStatGeneral() As CStatList _
        Implements IRequest.GetVaccinationStatGeneral

        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "VaccinationStatGeneralRaw")
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
    ''' Total number of positive COVID-19 cases and positive cases in last 14 
    ''' days and same as ratio per 100k.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - entry date<br/></item>
    ''' <item>"DailyCases" - daily tests<br/></item>
    ''' <item>"TotalCases" - total number of tests<br/></item>
    ''' <item>"Per100k" - coverage of population, ratio per 100k<br/></item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetTestStatPositiveGeneral() As CStatList Implements IRequest.GetTestStatPositiveGeneral
        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "TestStatPositiveGeneralRaw")
        Return data
    End Function
    ''' <summary>
    ''' The data show the number of first tests (cases) as well as the total number of 
    ''' tests with repeat tests.<br/>
    ''' A case is considered to be a first positive or first negative test per person, ie. repeat tests are not considered.<br/>
    ''' Thus, there can be a maximum of 2 cases per person - one positive, one negative. <br/>
    ''' The ranges of both positive and negative cases at the county level are published.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"County"<br/></item>
    ''' <item>"Result" - result of test "P" or "N"<br/></item>
    ''' <item>"TotalTests" - total number of tests<br/></item>
    ''' <item>"DailyTests" - daily number of tests<br/></item>
    ''' </list></summary>
    ''' <param name="countyName">Name of county to filter by. If not "all", will return 
    ''' info about exact county</param>
    ''' <param name="positiveOnly">If True, returns only positive results</param>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetTestStatCounty(Optional countyName As String = "all", Optional positiveOnly As _
                                      Boolean = True) As CStatList Implements IRequest.GetTestStatCounty

        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "TestStatCountyRaw")
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
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"Gender" - group gender<br/></item>
    ''' <item>"Result" - result of test<br/></item>
    ''' <item>"AverageAge" - average age of this group<br/></item>
    ''' </list></summary>
    ''' <param name="positiveOnly">If True, returns only positive results</param>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetTestStatByAverageAge(Optional positiveOnly As Boolean = True) _
        As CStatList Implements IRequest.GetTestStatByAverageAge

        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "TestStatByAverageAgeRaw")

        If (positiveOnly) Then
            data.Where("Result", "P")
        End If
        Return data
    End Function
    ''' <summary>
    ''' The average age and average age grouped by genders of hospitalized patients diagnosed with Covid-19. <br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Gender" - gender of group, gender of "" or null means what this is average value 
    ''' between male and female groups<br/></item>
    ''' <item>"AverageAge" - average age of group<br/></item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetHospitalizationAveragePatientAgeCurrent() As CStatList Implements _
        IRequest.GetHospitalizationAveragePatientAgeCurrent

        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "HospitalizationAveragePatientAgeCurrentRaw")
        Return data
    End Function
    ''' <summary>
    ''' Total number of patients per gender and age group hospitalized<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Gender" - patient gender<br/></item>
    ''' <item>"AgeGroup" - patient age group<br/></item>
    ''' <item>"PatientCount" - number of patients<br/></item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetHospitalizationPatientInfoCurrent() As CStatList _
        Implements IRequest.GetHospitalizationPatientInfoCurrent

        Dim data As CStatList = saveLoad.LoadFrom(cachePath,
                                                  "HospitalizationPatientInfoCurrentRaw")
        Return data
    End Function
    ''' <summary>
    ''' A time series is issued for the average number of days a patient is hospitalized.<br/>
    ''' The average number of days is based on the number of cases that ended, 
    ''' and the average duration of illness in patients on a specific date is calculated.<br/>
    ''' Timeline may not have data for every date if the patients' medical 
    ''' records on that date have not yet been completed.
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - entry date<br/></item>
    ''' <item>"AverageDays"<br/></item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetAverageHospitalizationTime() As CStatList Implements IRequest.GetAverageHospitalizationTime
        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "AverageHospitalizationTimeRaw")
        For i As Integer = 0 To data.Count - 1
            data.SetField() = data.GetField(i, "Date").Split("T")(0)
        Next
        Return data
    End Function
    ''' <summary>
    ''' A statistical timeline for hospitalizations diagnosed with Covid-19 is issued.<br/>
    ''' A distinction is made between patients and cases.<br/>
    ''' A case is considered to be a hospitalization of a patient with a diagnosis 
    ''' of Covid-19, which may involve movement between hospitals.<br/>
    ''' The case ends with discharge from the hospital.<br/>
    ''' Several cases can also be counted per patient if the patient is re-admitted 
    ''' to the hospital after the completed case.<br/>
    ''' For technical and methodological reasons, timeline may show minor 
    ''' statistical deviations from previously published statistics.<br/>
    ''' This is due to the time recording of the timeline and the receipt of 
    ''' data or corrections for the current day.<br/>
    ''' The open data shall reflect the most recent state of knowledge, 
    ''' including revisions and data quality improvements.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"Hospitalised" - patients hospitalized<br/></item>
    ''' <item>"ActivelyHospitalised" - patients really hospitalized and not 
    ''' discharged<br/></item>
    ''' <item>"OnVentilation"<br/></item>
    ''' <item>"InIntensive"<br/></item>
    ''' <item>"Discharged" - patients who left the hospital<br/></item>
    ''' <item>"NewCases"<br/></item>
    ''' <item>"TotalCases"<br/></item>
    ''' <item>"TotalCasesDischarged"<br/></item>
    ''' <item>"NewPatients"<br/></item>
    ''' <item>"TotalPatients"<br/></item>
    ''' <item>"TotalPatientsDischarged"<br/></item>
    ''' </list></summary>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetHospitalizationPatients() As CStatList Implements IRequest.GetHospitalizationPatients
        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "HospitalizationPatientsRaw")
        For i As Integer = 0 To data.Count - 1
            data.SetField() = data.GetField(i, "Date").Split("T")(0)
        Next
        Return data
    End Function
    ''' <summary>
    ''' Deceased number this day<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date<br/></item>
    ''' <item>"Deceased" - number of people died<br/></item>
    ''' </list></summary>
    ''' <param name="accumulative">Should list be accumulative 
    ''' (each next by date entry is a sum of all deceased happened
    ''' in preious day)</param>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetDeceased(Optional accumulative As Boolean = False) As _
        CStatList Implements IRequest.GetDeceased

        Dim list As CStatList = saveLoad.LoadFrom(cachePath, "DeceasedRaw")
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
    ''' Get number of people currently sick at selected date. <br/>
    ''' Calculated as total number of positive cases in last <paramref name="period"/> days.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date"<br/></item>
    ''' <item>"Sick" - number of people currently sick at selected date.</item>
    ''' </list></summary>
    ''' <param name="period">Period during what people are counted "sick". Since there are no info about
    ''' currently sick people, it is calculated sum of peoples sick at certain date, with period equal to average
    ''' sickness period.</param>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
    Public Function GetSick(Optional period As Integer = 14) As CStatList Implements IRequest.GetSick
        period = Max(0, period - 1)
        Dim data As CStatList = saveLoad.LoadFrom(cachePath, "SickRaw")
        Dim sickFieldNumber = data.FindFieldIndex("Sick")
        Dim dailyFieldNumber = data.FindFieldIndex("DailyCases")
        Dim i = 0
        data(i)(sickFieldNumber) = 0
        If (i < period) Then
            For c As Integer = 0 To period
                If (i - c < 0) Then
                    Exit For
                End If
                data(i)(sickFieldNumber) = CInt(data(i)(sickFieldNumber)) +
                    CInt(data(i - c)(dailyFieldNumber))
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
    ''' Get number of people currently sick at selected date by county. <br/>
    ''' Calculated as total number of positive cases in last <paramref name="period"/> days.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date"<br/></item>
    ''' <item>"Sick" - number of people currently sick at selected date.<br/></item>
    ''' <item>"County"</item>
    ''' </list></summary>
    ''' <param name="period">Period during what people are counted "sick". Since there are no info about
    ''' currently sick people, it is calculated sum of peoples sick at certain date, with period equal to average
    ''' sickness period.</param>
    ''' <param name="aimCounty">Aim county to filter with. If not Nothing, will return info about exact county</param>
    ''' <returns></returns>
    Public Function GetSickCounty(Optional period As Integer = 14, Optional aimCounty As String = Nothing) _
        As CStatList Implements IRequest.GetSickCounty

        period = Max(0, period - 1)
        Dim list As CStatList = Me.GetTestStatCounty()
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
                        county(i)(sickFieldNumber) = CInt(county(i)(sickFieldNumber)) +
                            CInt(county(i - c)(dailyFieldNumber))
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
    ''' <summary>
    ''' Parses raw CSV statistics file received in <see cref="String"/> form into instance of <see cref="CStatList"/>
    ''' </summary>
    ''' <param name="rawCSV">Raw CSV file in <see cref="String"/> format</param>
    ''' <param name="fields">Headers what must be parsed from CSV statistics file</param>
    ''' <returns>Instance of <see cref="CStatList"/></returns>
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

    ''' <summary>
    ''' Create new instance of CRequest
    ''' </summary>
    ''' <param name="newCachePath">Path to folder where statistics raw object saved</param>
    Public Sub New(newCachePath As String)
        cachePath = newCachePath
    End Sub

    ' Obsolete but potentially useful
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
