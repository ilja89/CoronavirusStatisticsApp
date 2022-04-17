﻿' FILENAME: CDataDownload.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 06.04.2022
' CHANGED: 07.04.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: CStatList, CStatObject

Imports System.Net
Imports CoronaStatisticsGetter.CRequest
Imports Newtonsoft.Json.Linq
Imports System.Math
''' <summary>
''' This class is used to download raw data from <strong>Digilugu</strong> <see href="https://opendata.digilugu.ee/"></see> servers and other sources.
''' It doesn't execute deep processing of data.
''' </summary>
Public Class CDataDownload
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
    Public Async Function GetVaccinationStatByCountyRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_location_county.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "LocationCounty||County", "VaccinationSeries", "MeasurementType||Type", "LocationPopulation",
            "DailyCount", "TotalCount"})
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
    Public Async Function GetVaccinationStatByAgeGroupRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_agegroup.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type", "LocationPopulation||GroupSize",
            "DailyCount", "TotalCount", "PopulationCoverage", "AgeGroup"})
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
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
    Public Async Function GetVaccinationStatGeneralRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_total.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type", "DailyCount", "TotalCount", "PopulationCoverage||VaccinatedPercentage", "LocationPopulation||EstoniaPopulation"})
        data.Where("VaccinationSeries", "1")
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
    Public Async Function GetTestStatPositiveGeneralRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
        Return ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCases", "PerPopulation||Per100k"})
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
    Public Async Function GetTestStatCountyRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_test_county_all.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "County", "ResultValue||Result", "TotalTests", "DailyTests"})
        data.WhereNot("County", "")
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' Average age of people tested this day.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"Gender" - group gender<br/></item>
    ''' <item>"Result" - result of test<br/></item>
    ''' <item>"AverageAge" - average age of this group<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetTestStatByAverageAgeRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_avg_age_by_result.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"ResultDate||Date", "Gender", "ResultValue||Result", "AverageAge"})
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' The average age and average age grouped by genders of hospitalized patients diagnosed with Covid-19. <br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Gender" - gender of group, gender of "" or null means what this is average value between 
    ''' male and female groups<br/></item>
    ''' <item>"AverageAge" - average age of group<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetHospitalizationAveragePatientAgeCurrentRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_age.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"Gender", "AverageAge"})
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' Total number of patients per gender and age group hospitalized<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Gender" - patient gender<br/></item>
    ''' <item>"AgeGroup" - patient age group<br/></item>
    ''' <item>"PatientCount" - number of patients<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetHospitalizationPatientInfoCurrentRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_profile.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"Gender", "AgeGroup", "PatientCount"})
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' A time series is issued for the average number of days a patient is hospitalized.<br/>
    ''' The average number of days is based on the number of cases that ended, and the average duration of illness in patients on a specific date is calculated.<br/>
    ''' Timeline may not have data for every date if the patients' medical records on that date have not yet been completed.
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - entry date<br/></item>
    ''' <item>"AverageDays"<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetAverageHospitalizationTimeRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_days.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "AverageDays"})
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' A statistical timeline for hospitalizations diagnosed with Covid-19 is issued.<br/>
    ''' A distinction is made between patients and cases.<br/>
    ''' A case is considered to be a hospitalization of a patient with a diagnosis of Covid-19, which may involve movement between hospitals.<br/>
    ''' The case ends with discharge from the hospital.<br/>
    ''' Several cases can also be counted per patient if the patient is re-admitted to the hospital after the completed case.<br/>
    ''' For technical and methodological reasons, timeline may show minor statistical deviations from previously published statistics.<br/>
    ''' This is due to the time recording of the timeline and the receipt of data or corrections for the current day.<br/>
    ''' The open data shall reflect the most recent state of knowledge, including revisions and data quality improvements.<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date of entry<br/></item>
    ''' <item>"Hospitalised" - patients hospitalized<br/></item>
    ''' <item>"ActivelyHospitalised" - patients really hospitalized and not discharged<br/></item>
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
    Public Async Function GetHospitalizationPatientsRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_timeline.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "Hospitalised", "ActivelyHospitalised",
            "IsOnVentilation||OnVentilation", "IsInIntensive||InIntensive", "Discharged",
            "NewCases", "TotalCases", "TotalCasesDischarged", "NewPatients",
            "TotalPatients", "TotalPatientsDischarged"})
        Return data
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' Deceased number this day<br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date" - date<br/></item>
    ''' <item>"Deceased" - number of people died<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetDeceasedRaw() As Task(Of CStatList)
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
        Return list
    End Function
    ''' <summary>
    ''' <strong>IMPORTANT! Raw info, to get prepared info load required data into cache folder and then use CRequest.</strong><br/>
    ''' Get number of people currently sick at selected date. <br/>
    ''' (Not processed, no real info, only usable after processed with CRequest) <br/>
    ''' Fields:<br/><list type="bullet">
    ''' <item>"Date"<br/></item>
    ''' </list></summary>
    ''' <returns><see cref="Task"/> returning instance of <see cref="CStatList"/></returns>
    Public Async Function GetSickRaw() As Task(Of CStatList)
        Dim csv As String = Await (New WebClient).DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCasesLast14D||Sick"})
        Return data
    End Function
End Class