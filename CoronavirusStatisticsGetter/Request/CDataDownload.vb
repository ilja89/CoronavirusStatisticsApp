Imports System.Net
Imports CoronaStatisticsGetter.CRequest
Imports Newtonsoft.Json.Linq
Imports System.Math
Public Class CDataDownload
    Public Async Function getVaccinationStatByCountyRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_location_county.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "LocationCounty||County", "VaccinationSeries", "MeasurementType||Type", "LocationPopulation",
            "DailyCount", "TotalCount"})
        Return data
    End Function
    Public Async Function getVaccinationStatByAgeGroupRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_agegroup.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type", "LocationPopulation||GroupSize",
            "DailyCount", "TotalCount", "PopulationCoverage", "AgeGroup"})
        Return data
    End Function
    Public Async Function getVaccinationStatGeneralRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/covid19/vaccination/v3/opendata_covid19_vaccination_total.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "VaccinationSeries", "MeasurementType||Type", "DailyCount", "TotalCount", "PopulationCoverage||VaccinatedPercentage", "LocationPopulation||EstoniaPopulation"})
        data.Where("VaccinationSeries", "1")
        Return data
    End Function
    Public Async Function getTestStatPositiveGeneralRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
        Return ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCases", "PerPopulation||Per100k"})
    End Function
    Public Async Function getTestStatCountyRaw(Optional countyName As String = "all", Optional positiveOnly As Boolean = True) As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_test_county_all.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "County", "ResultValue||Result", "TotalTests", "DailyTests"})
        data.WhereNot("County", "")
        Return data
    End Function
    Public Async Function getTestStatByAverageAgeRaw(Optional positiveOnly As Boolean = True) As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_avg_age_by_result.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"ResultDate||Date", "Gender", "ResultValue||Result", "AverageAge"})
        Return data
    End Function
    Public Async Function getHospitalizationAveragePatientAgeCurrentRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_age.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"Gender", "AverageAge"})
        Return data
    End Function
    Public Async Function getHospitalizationPatientInfoCurrentRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_profile.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"Gender", "AgeGroup", "PatientCount"})
        Return data
    End Function
    Public Async Function getAverageHospitalizationTimeRaw() As Task(Of CStatList)
        Dim client As New WebClient
        Dim csv As String = Await client.DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_hospitalization_avg_days.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "AverageDays"})
        Return data
    End Function
    Public Async Function getHospitalizationPatientsRaw() As Task(Of CStatList)
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
    Public Async Function getDeceasedRaw() As Task(Of CStatList)
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
    Public Async Function getSickRaw() As Task(Of CStatList)
        Dim csv As String = Await (New WebClient).DownloadStringTaskAsync("https://opendata.digilugu.ee/opendata_covid19_tests_total.csv")
        Dim data As CStatList = ParseCSVToCStatList(
            csv,
            {"StatisticsDate||Date", "DailyCases", "TotalCasesLast14D||Sick"})
        Return data
    End Function
End Class
