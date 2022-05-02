' FILENAME: CDataDownload.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 06.04.2022
' CHANGED: 07.04.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: StatisticsObject, Newtonsoft.Json

Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.Math
Imports System.Reflection.MethodInfo
Imports StatisticsObject
''' <summary>
''' This class is used to download raw data from <strong>Digilugu</strong> 
''' <see href="https://opendata.digilugu.ee/"></see> servers and other sources.
''' It doesn't execute deep processing of data.
''' </summary>
Public Class CDataDownload
    Implements IDataDowload

    Private Declare Function GetTickCount64 Lib "kernel32" () As Long
    ''' <summary>
    ''' Waits for <paramref name="delayms"/> milliseconds.
    ''' </summary>
    ''' <param name="delayms">Delay in milliseconds</param>
    Private Sub Sleep(delayms As Integer)
        Dim startTime As Long = GetTickCount64
        Dim stopTime As Long = startTime + delayms
        Dim now As Long = startTime
        While (now < stopTime)
            now = GetTickCount64
        End While
    End Sub

    ''' <summary>
    ''' Handles exceptions what can appear
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <param name="tries"></param>
    ''' <param name="methodName"></param>
    Private Sub HandleException(ex As Exception, ByRef tries As Integer,
                                methodName As String)

        If (ex.GetType.Name = "WebException" And tries < 3) Then
            Console.WriteLine(ex.ToString)
            Sleep(1000)
        Else
            Throw New Exception(ex.Message + "in" + methodName, ex)
        End If
        tries += 1
    End Sub
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
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
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetVaccinationStatByCountyRaw() As _
        Task(Of CStatList) Implements IDataDowload.GetVaccinationStatByCountyRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name

        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_location_county.csv")
                data = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "LocationCounty||County", "VaccinationSeries",
            "MeasurementType||Type", "LocationPopulation",
            "DailyCount", "TotalCount"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function

    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
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
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetVaccinationStatByAgeGroupRaw() As _
        Task(Of CStatList) Implements IDataDowload.GetVaccinationStatByAgeGroupRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name

        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_agegroup.csv")
                data = ParseCSVToCStatList(
                    csv,
                    {"StatisticsDate||Date", "VaccinationSeries",
                    "MeasurementType||Type", "LocationPopulation||GroupSize",
                    "DailyCount", "TotalCount", "PopulationCoverage", "AgeGroup"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data 
    ''' into cache folder and then use CRequest.</strong><br/>
    ''' Get national statistics on vaccination against Covid-19.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"VaccinationSeries"<br/></item>
    ''' <item>"Type" - entry type<br/></item>
    ''' <item>"DailyCount" - number of vaccinations this day<br/></item>
    ''' <item>"TotalCount" - total number of vaccinations<br/></item>
    ''' <item>"PopulationCoverage"<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetVaccinationStatGeneralRaw() As _
        Task(Of CStatList) Implements IDataDowload.GetVaccinationStatGeneralRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_total.csv")
                data = ParseCSVToCStatList(
                    csv,
                    {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type",
                    "DailyCount", "TotalCount", "PopulationCoverage||VaccinatedPercentage",
                    "LocationPopulation||EstoniaPopulation"})
                data.Where("VaccinationSeries", "1")
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' Total number of positive COVID-19 cases and positive cases in last 14 days and same as ratio per 100k.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - entry date<br/></item>
    ''' <item>"DailyCases" - daily tests<br/></item>
    ''' <item>"TotalCases" - total number of tests<br/></item>
    ''' <item>"Per100k" - coverage of population, ratio per 100k<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetTestStatPositiveGeneralRaw() As Task(Of CStatList) _
        Implements IDataDowload.GetTestStatPositiveGeneralRaw

        Dim client As New WebClient
        Dim data As CStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
                data = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCases", "PerPopulation||Per100k"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' The data show the number of first tests (cases) as well as the total number of tests with repeat tests.<br/>
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
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetTestStatCountyRaw() As Task(Of CStatList) _
        Implements IDataDowload.GetTestStatCountyRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_test_county_all.csv")
                data = ParseCSVToCStatList(
                    csv,
                    {"StatisticsDate||Date", "County", "ResultValue||Result",
                    "TotalTests", "DailyTests"})
                data.WhereNot("County", "")
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data 
    ''' into cache folder and then use CRequest.</strong><br/>
    ''' Average age of people tested this day.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"Gender" - group gender<br/></item>
    ''' <item>"Result" - result of test<br/></item>
    ''' <item>"AverageAge" - average age of this group<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetTestStatByAverageAgeRaw() As Task(Of CStatList) _
        Implements IDataDowload.GetTestStatByAverageAgeRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_avg_age_by_result.csv")
                data = ParseCSVToCStatList(
                    csv,
                    {"ResultDate||Date", "Gender", "ResultValue||Result", "AverageAge"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into 
    ''' cache folder and then use CRequest.</strong><br/>
    ''' The average age and average age grouped by genders of hospitalized 
    ''' patients diagnosed with Covid-19. <br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Gender" - gender of group, gender of "" or null means what 
    ''' this is average value between 
    ''' male and female groups<br/></item>
    ''' <item>"AverageAge" - average age of group<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetHospitalizationAveragePatientAgeCurrentRaw() As _
        Task(Of CStatList) Implements IDataDowload.GetHospitalizationAveragePatientAgeCurrentRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_age.csv")
                data = ParseCSVToCStatList(
            csv,
            {"Gender", "AverageAge"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data 
    ''' into cache folder and then use CRequest.</strong><br/>
    ''' Total number of patients per gender and age group hospitalized<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Gender" - patient gender<br/></item>
    ''' <item>"AgeGroup" - patient age group<br/></item>
    ''' <item>"PatientCount" - number of patients<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetHospitalizationPatientInfoCurrentRaw() As _
        Task(Of CStatList) Implements IDataDowload.GetHospitalizationPatientInfoCurrentRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_profile.csv")
                data = ParseCSVToCStatList(
                    csv,
                    {"Gender", "AgeGroup", "PatientCount"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into 
    ''' cache folder and then use CRequest.</strong><br/>
    ''' A time series is issued for the average number of days a patient is hospitalized.<br/>
    ''' The average number of days is based on the number of cases that ended, 
    ''' and the average duration of illness in patients on a specific date is calculated.<br/>
    ''' Timeline may not have data for every date if the patients' medical 
    ''' records on that date have not yet been completed.
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - entry date<br/></item>
    ''' <item>"AverageDays"<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetAverageHospitalizationTimeRaw() As Task(Of CStatList) _
        Implements IDataDowload.GetAverageHospitalizationTimeRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_days.csv")
                data = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "AverageDays"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data 
    ''' into cache folder and then use CRequest.</strong><br/>
    ''' A statistical timeline for hospitalizations diagnosed with Covid-19 is issued.<br/>
    ''' A distinction is made between patients and cases.<br/>
    ''' A case is considered to be a hospitalization of a patient with 
    ''' a diagnosis of Covid-19, which may involve movement between hospitals.<br/>
    ''' The case ends with discharge from the hospital.<br/>
    ''' Several cases can also be counted per patient if the patient is re-admitted to 
    ''' the hospital after the completed case.<br/>
    ''' For technical and methodological reasons, timeline may show minor statistical 
    ''' deviations from previously published statistics.<br/>
    ''' This is due to the time recording of the timeline and the receipt of data or 
    ''' corrections for the current day.<br/>
    ''' The open data shall reflect the most recent state of knowledge, including revisions and 
    ''' data quality improvements.<br/>
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
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetHospitalizationPatientsRaw() As Task(Of CStatList) _
        Implements IDataDowload.GetHospitalizationPatientsRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_timeline.csv")
                data = ParseCSVToCStatList(
                    csv,
                    {"StatisticsDate||Date", "Hospitalised", "ActivelyHospitalised",
                    "IsOnVentilation||OnVentilation", "IsInIntensive||InIntensive", "Discharged",
                    "NewCases", "TotalCases", "TotalCasesDischarged", "NewPatients",
                    "TotalPatients", "TotalPatientsDischarged"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into 
    ''' cache folder and then use CRequest.</strong><br/>
    ''' Deceased number this day<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date<br/></item>
    ''' <item>"Deceased" - number of people died<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetDeceasedRaw() As Task(Of CStatList) _
        Implements IDataDowload.GetDeceasedRaw

        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim rawJson As String = Await client.DownloadStringTaskAsync("https://koroonakaart.ee/data.json")
                Dim json As JObject = JObject.Parse(rawJson)
                Dim dates As JArray = json.Exists("dates2")
                Dim deceasedNumber As JArray = json.Exists("deceased")
                data = New CStatList({{0, "Date", 0}, {0, "Deceased", 1}})
                Dim i As Integer = Min(dates.Count, deceasedNumber.Count) - 1
                While (i >= 0)
                    data.AddItemDirectly({dates(i).Value(Of String),
                                         deceasedNumber(i).Value(Of String)})
                    i -= 1
                End While
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data 
    ''' into cache folder and then use CRequest.</strong><br/>
    ''' Get number of people currently sick at selected date. <br/>
    ''' (Not processed, no real info, only usable after processed with CRequest) <br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date"<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetSickRaw() As Task(Of CStatList) Implements IDataDowload.GetSickRaw
        Dim client As New WebClient
        Dim data As IStatList = Nothing
        Dim tries As Integer = 0
        Dim methodName As String = GetCurrentMethod().DeclaringType.Name
        While (data Is Nothing)
            Try
                Dim csv As String = Await (New WebClient).DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
                data = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCasesLast14D||Sick"})
            Catch ex As Exception
                HandleException(ex, tries, methodName)
            End Try
        End While
        Return data
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
        Dim statList As IStatList
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
End Class
