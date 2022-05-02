' FILENAME: statGraphs.vb
' AUTOR: El Plan - Nikita Budovei
' CREATED: 10.04.2022
' CHANGED: 01.05.2022
'
' DESCRIPTION: See below
'
' RELATED COMPONENTS: ...
Imports CoronaStatisticsGetter
Imports StatisticsObject
Imports Math

''' <summary>
''' Shows global country statistics
''' </summary>
Public Class statGraphs
    Public ReadOnly FormName As String = "Statistika"
    Public covidTestPosGen As IStatList
    Public covidVactGen As IStatList
    Public covidSickGen As IStatList
    Public covidHospitalizedGen As IStatList
    Public covidHospitalizedCurrentGen As IStatList
    Public covidDeceasedGen As IStatList
    Public covidHospitalized As IStatList
    Public covidHospitalizedWeek As IStatList
    Public request As IRequest = New CRequest(AppSettings.CachePath)

    Private Sub statGraphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Week As DateTime = Today.AddDays(-7)
        Dim stringWeekAgo As String = DateTimeToString(Week)
        Dim stringToday As String = DateTimeToString(Today)
        covidTestPosGen = request.GetTestStatPositiveGeneral()
        covidVactGen = request.GetVaccinationStatGeneral()
        covidSickGen = request.GetSick()
        covidHospitalizedGen = request.GetHospitalizationPatients()
        covidHospitalizedCurrentGen = request.GetHospitalizationPatientInfoCurrent()
        covidDeceasedGen = request.GetDeceased(True)
        covidHospitalizedWeek = request.GetHospitalizationPatients()

        totalSick.Value = covidSickGen.GetField(covidSickGen.Count - 1, "Sick")
        totalSick.To = GetRand(totalSick.Value * 1.5, totalSick.Value * 5)
        totalVact.Value = covidVactGen.GetField(covidVactGen.Count - 1, "TotalCount")
        totalVact.To = GetRand(totalVact.Value * 1.5, totalVact.Value * 5)
        totalPos.Value = covidTestPosGen.GetField(covidTestPosGen.Count - 1, "TotalCases")
        totalPos.To = GetRand(totalPos.Value * 1.5, totalPos.Value * 5)
        totalHospitalized.Value = covidHospitalizedGen.GetField(covidHospitalizedGen.Count - 1, "TotalCases")
        totalHospitalized.To = GetRand(totalHospitalized.Value * 1.5, totalHospitalized.Value * 5)
        hospitalizedCurrent.Value = covidHospitalizedCurrentGen.GetField(covidHospitalizedCurrentGen.Count - 1, "PatientCount")
        hospitalizedCurrent.To = GetRand(hospitalizedCurrent.Value * 1.5, hospitalizedCurrent.Value * 5)
        totalDied.Value = covidDeceasedGen.GetField(0, "Deceased")
        totalDied.To = GetRand(totalDied.Value * 1.5, totalDied.Value * 5)
        totalPer100K.Value = Math.Round(totalSick.Value / AppConstants.ESTONIA_POPULATION * 100000)
        totalPer100K.To = 100000
        todayHospitalized.Value = covidHospitalizedGen.GetField(covidHospitalizedGen.Count - 1, "NewCases")
        todayHospitalized.To = GetRand(todayHospitalized.Value * 1.5, todayHospitalized.Value * 5)
        weekHospitalized.Value = covidHospitalizedWeek.GetFieldsAverageForPeriod(stringWeekAgo, "Hospitalised")
        weekHospitalized.To = GetRand(weekHospitalized.Value * 1.5, weekHospitalized.Value * 5)

        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
    End Sub

    Private Function GetRand(low As Integer, high As Integer)
        Randomize()
        Return CInt(Int(high * Rnd() + low))
    End Function

    Private Function DateTimeToString(dateTimeObject As DateTime)
        Return String.Join("-", dateTimeObject.ToString.Split(" ")(0).Split(".").Reverse)
    End Function

    Private Sub totalDeceased_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles totalHospitalized.ChildChanged

    End Sub
    Private Sub ColorSettingsAppliedHandler()
        Panel1.BackColor = MainColor
        Label1.BackColor = SecondaryColor
        Label2.BackColor = SecondaryColor
        Label3.BackColor = SecondaryColor
        Label4.BackColor = SecondaryColor
        Label5.BackColor = SecondaryColor
        Label6.BackColor = SecondaryColor
        Label7.BackColor = SecondaryColor
        Label8.BackColor = SecondaryColor
        Label9.BackColor = SecondaryColor
        Label10.BackColor = SecondaryColor
        Label11.BackColor = SecondaryColor
        Label12.BackColor = SecondaryColor
        Label13.BackColor = SecondaryColor
    End Sub

    Private Sub vactBtn_Click(sender As Object, e As EventArgs) Handles vactBtn.Click
        Dim newStat As New moreStatGeneral
        newStat.Init("Vaktsinatsioonid", covidVactGen, "DailyCount")
        newStat.Show()
    End Sub

    Private Sub testBtn_Click(sender As Object, e As EventArgs) Handles testBtn.Click
        Dim newStat1 As New moreStatGeneral
        newStat1.Init("Testid", covidTestPosGen, "DailyCases")
        newStat1.Show()
    End Sub

    Private Sub sickBtn_Click(sender As Object, e As EventArgs) Handles sickBtn.Click
        Dim newStat2 As New moreStatGeneral
        newStat2.Init("Haigestunud", covidSickGen, "Sick")
        newStat2.Show()
    End Sub

    Private Sub hospitalBtn_Click(sender As Object, e As EventArgs) Handles hospitalBtn.Click
        Dim newStat3 As New moreStatGeneral
        newStat3.Init("Hospitaliseeritud", covidHospitalized, "NewCases")
        newStat3.Show()
    End Sub

    Private Sub saveStatBtn_Click(sender As Object, e As EventArgs)

    End Sub
End Class