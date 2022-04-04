Imports FontAwesome.Sharp
Imports CoronaStatisticsGetter

Public Class statWin
    Dim request As New CRequest
    Dim covidTestPos As CStatList
    Dim covidVact As CStatList
    Dim covidSick As CStatList

    Private Sub statGraphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        covidTestPos = Main.covidTest
        covidVact = Await request.GetVaccinationStatGeneral
        covidSick = Await request.GetSick()
        totalPositive.Value = covidTestPos.GetField(covidTestPos.Count - 1, "TotalTests")
        totalVact.Value = covidVact.GetField(covidVact.Count - 1, "Total Count")
        totalSick.Value = covidSick.GetField(covidSick.Count - 1, "Sick")
    End Sub
End Class
