Imports System.Runtime.InteropServices
Imports CoronaStatisticsGetter

Public Class popupWin
    Public isClosed As Boolean = False
    Private _covidTestStat As CStatList
    Private _covidSickStat As CStatList
    Private _covidVactStat As CStatList
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles countyName.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub openTestBtn_Click(sender As Object, e As EventArgs) Handles openTestBtn.Click
        Dim moreStatCountyForm As New moreStatCounty
        moreStatCountyForm.Init(Me.Name, _covidTestStat, "Covid Tests", "DailyTests")
        moreStatCountyForm.Show()
    End Sub

    Private Sub openSickBtn_Click(sender As Object, e As EventArgs) Handles openSickBtn.Click
        Dim moreStatCountyForm As New moreStatCounty
        moreStatCountyForm.Init(Me.Name, _covidSickStat, "Covid sick", "Sick")
        moreStatCountyForm.Show()
    End Sub

    Private Sub openVactBtn_Click(sender As Object, e As EventArgs) Handles openVactBtn.Click
        Dim moreStatCountyForm As New moreStatCounty
        moreStatCountyForm.Init(Me.Name, _covidVactStat, "Vaccinations", "DailyCount")
        moreStatCountyForm.Show()
    End Sub

    Public Sub Init(NewTestStat As CStatList, NewSickStat As CStatList, NewVactStat As CStatList)
        _covidTestStat = NewTestStat
        _covidSickStat = NewSickStat
        _covidVactStat = NewVactStat
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        Panel2.BackColor = PopupColorMain
        Panel1.BackColor = PopupColorSecondary
    End Sub
End Class
