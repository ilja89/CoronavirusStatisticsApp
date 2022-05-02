' FILENAME: PopupWin.vb
' AUTOR: El Plan - Alexandr Ivantsov
' CREATED: 14.04.2022
' CHANGED: 18.05.2022
'
' DESCRIPTION: See below
'
' PRECONDITIONS: ...
' SUBSEQUENT CONDITIONS: ...
' RELATED COMPONENTS: ...
Imports System.Runtime.InteropServices
Imports StatisticsObject
Imports CoronaStatisticsGetter

''' <summary>
''' Popup windows for some information showing
''' </summary>
Public Class popupWin
    Private _county As KeyValuePair(Of String, String)
    Private _covidTestStat As IStatList
    Private _covidSickStat As IStatList
    Private _covidVactStat As IStatList
    Private _request As IRequest = New CRequest(AppSettings.CachePath)
    Public Sub popupWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
    End Sub


    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal Iparam As Integer)
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Visible = False
        Me.Dispose()
    End Sub

    Private Sub openTestBtn_Click(sender As Object, e As EventArgs) Handles openTestBtn.Click
        Dim moreStatCountyForm As New moreStatCounty
        moreStatCountyForm.Init("Testid", _request.GetTestStatCounty, "DailyTests", {_county.Key})
        moreStatCountyForm.Show()
    End Sub

    Private Sub openSickBtn_Click(sender As Object, e As EventArgs) Handles openSickBtn.Click
        Dim moreStatCountyForm As New moreStatCounty
        moreStatCountyForm.Init("Haiged", _request.GetSickCounty, "Sick", {_county.Key})
        moreStatCountyForm.Show()
    End Sub

    Private Sub openVactBtn_Click(sender As Object, e As EventArgs) Handles openVactBtn.Click
        Dim moreStatCountyForm As New moreStatCounty
        moreStatCountyForm.Init("Vaktsineerimine", _request.GetVaccinationStatByCounty, "DailyCount", {_county.Key})
        moreStatCountyForm.Show()
    End Sub

    Public Sub Init(NewTestStat As IStatList, NewSickStat As IStatList, NewVactStat As IStatList, county As KeyValuePair(Of String, String))
        _covidTestStat = NewTestStat
        _covidSickStat = NewSickStat
        _covidVactStat = NewVactStat
        _county = county
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        Panel2.BackColor = PopupColorMain
        Panel1.BackColor = PopupColorSecondary
    End Sub
End Class
