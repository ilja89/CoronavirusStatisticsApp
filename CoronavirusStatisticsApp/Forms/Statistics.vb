Imports CoronaStatisticsGetter

Public Class Statistics

    Dim request As New CRequest
    Dim covidTestGeneral As CStatList
    Dim covidVactGeneral As CStatList
    Dim covidSickGeneral As CStatList
    Dim covidHospCurrent As CStatList

    Private Sub Total_infected_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles Total_infected.ChildChanged


    End Sub

    Private Async Sub Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Total_Vaccinated.Size = New Size(320, 300)
        Total_infected.Size = New Size(320, 300)
        Total_Vaccinated.Location = New Point(493, 300)
        Total_infected.Location = New Point(493, 10)
        Total_infected.To = 1331000
        Total_Vaccinated.To = 1331000
        Label2.Size = New Size(176, 20)
        Label5.Size = New Size(176, 20)
        Label2.Location = New Point(493, 300)
        Label5.Location = New Point(493, 580)
        Label5.BringToFront()
        Label2.BringToFront()
        covidTestGeneral = Await request.GetTestStatPositiveGeneral()
        covidVactGeneral = Await request.GetVaccinationStatGeneral()
        covidSickGeneral = Await request.GetSick()
        'covidHospCurrent = Await request.GetHospitalizationPatientInfoCurrent()


        Total_infected.Value = covidTestGeneral.GetField(covidTestGeneral.Count - 1, "TotalCases")
        '  popup.allSick.Text = CovidSickEdited.GetField(CovidSickEdited.Count - 1, "Sick")
        Total_Vaccinated.Value = covidVactGeneral.GetField(covidVactGeneral.Count - 1, "TotalCoun")


    End Sub
End Class
