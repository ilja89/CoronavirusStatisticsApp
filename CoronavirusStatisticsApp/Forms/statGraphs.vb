Imports CoronaStatisticsGetter
Public Class statGraphs
    Dim covidTestPosGen As CStatList
    Dim covidVactGen As CStatList
    Dim covidSickGen As CStatList
    Dim covidHospitalizedGen As CStatList
    Dim covidHospitalizedCurrentGen As CStatList
    Dim covidDeceasedGen As CStatList
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Dim request As New CRequest(_cachePath)
    Private Async Sub statGraphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        totalSick.To = 1331000
        totalVact.To = 1331000
        totalPos.To = 1331000
        totalHospitalized.To = 1331000
        hospitalizedCurrent.To = 1331000
        totalDied.To = 133100
        covidTestPosGen = request.GetTestStatPositiveGeneral()
        covidVactGen = request.GetVaccinationStatGeneral()
        covidSickGen = request.GetSick()
        covidHospitalizedGen = request.GetHospitalizationPatients()
        covidHospitalizedCurrentGen = request.GetHospitalizationPatientInfoCurrent()
        covidDeceasedGen = request.GetDeceased()



        totalSick.Value = covidSickGen.GetField(covidSickGen.Count - 1, "Sick")
        totalVact.Value = covidVactGen.GetField(covidVactGen.Count - 1, "TotalCount")
        totalPos.Value = covidTestPosGen.GetField(covidTestPosGen.Count - 1, "TotalCases")
        totalHospitalized.Value = covidHospitalizedGen.GetField(covidHospitalizedGen.Count - 1, "TotalCases")
        hospitalizedCurrent.Value = covidHospitalizedCurrentGen.GetField(covidHospitalizedCurrentGen.Count - 1, "PatientCount")
        totalDied.Value = covidDeceasedGen.GetField(covidDeceasedGen.Count - 1, "Deceased")


    End Sub

    Private Sub totalDeceased_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles totalHospitalized.ChildChanged

    End Sub
End Class