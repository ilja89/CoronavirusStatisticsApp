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

''' <summary>
''' Shows global country statistics
''' </summary>
Public Class statGraphs
    Public ReadOnly FormName As String = "Statistika"
    Public covidTestPosGen As CStatList
    Public covidVactGen As CStatList
    Public covidSickGen As CStatList
    Public covidHospitalizedGen As CStatList
    Public covidHospitalizedCurrentGen As CStatList
    Public covidDeceasedGen As CStatList
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Public request As New CRequest(_cachePath)

    Private Sub statGraphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        totalSick.To = AppConstants.ESTONIA_POPULATION
        totalVact.To = AppConstants.ESTONIA_POPULATION
        totalPos.To = AppConstants.ESTONIA_POPULATION
        totalHospitalized.To = AppConstants.ESTONIA_POPULATION
        hospitalizedCurrent.To = AppConstants.ESTONIA_POPULATION
        totalDied.To = AppConstants.ESTONIA_POPULATION
        covidTestPosGen = request.GetTestStatPositiveGeneral()
        covidVactGen = request.GetVaccinationStatGeneral()
        covidSickGen = request.GetSick()
        covidHospitalizedGen = request.GetHospitalizationPatients()
        covidHospitalizedCurrentGen = request.GetHospitalizationPatientInfoCurrent()
        covidDeceasedGen = request.GetDeceased(True)

        totalSick.Value = covidSickGen.GetField(covidSickGen.Count - 1, "Sick")
        totalVact.Value = covidVactGen.GetField(covidVactGen.Count - 1, "TotalCount")
        totalPos.Value = covidTestPosGen.GetField(covidTestPosGen.Count - 1, "TotalCases")
        totalHospitalized.Value = covidHospitalizedGen.GetField(covidHospitalizedGen.Count - 1, "TotalCases")
        hospitalizedCurrent.Value = covidHospitalizedCurrentGen.GetField(covidHospitalizedCurrentGen.Count - 1, "PatientCount")
        totalDied.Value = covidDeceasedGen.GetField(0, "Deceased")
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
    End Sub

    Private Sub totalDeceased_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles totalHospitalized.ChildChanged

    End Sub
    Private Sub ColorSettingsAppliedHandler()
        Panel1.BackColor = MainColor
    End Sub
End Class