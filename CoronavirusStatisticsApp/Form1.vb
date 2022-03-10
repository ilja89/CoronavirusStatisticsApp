Imports CoronaStatisticsGetter
Imports System.Net.WebClient
Imports System.Net
Imports System
Imports System.Runtime.InteropServices
Public Class Form1
    Private request As New CRequest
    Private result As CStatList
    Private Async Sub test2() Handles Me.Load
        Dim a = request.GetAverageHospitalizationTime
    End Sub
End Class
