Imports CoronaStatisticsGetter
Public Class statGraphs
    Dim covidTestPosGen As CStatList
    Dim covidVactGen As CStatList
    Dim covidSickGen As CStatList
    Private _cachePath As String = My.Application.Info.DirectoryPath.Replace("CoronavirusStatisticsApp\bin\Debug", "") + "Cache\"
    Dim request As New CRequest(_cachePath)
    Private Async Sub statGraphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        totalSick.To = 1331000
        totalVact.To = 1331000
        totalPos.To = 1331000
        covidTestPosGen = request.getTestStatPositiveGeneral()
        covidVactGen = request.getVaccinationStatGeneral()
        covidSickGen = request.getSick()

        totalSick.Value = covidSickGen.GetField(covidSickGen.Count - 1, "Sick")
        totalVact.Value = covidVactGen.GetField(covidVactGen.Count - 1, "TotalCount")
        totalPos.Value = covidTestPosGen.GetField(covidTestPosGen.Count - 1, "TotalCases")

    End Sub
End Class