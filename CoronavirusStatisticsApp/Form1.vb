﻿Imports CoronaStatisticsGetter
Imports System.Net.WebClient
Imports System.Net
Imports System
Imports System.Runtime.InteropServices
Public Class Form1
    Private request As New CRequest
    Private result As CStatList
    Private Async Sub test2() Handles Me.Load
        Dim d1 As Task(Of CStatList) = (New CRequest).GetHospitalizationPatients
        Dim d2 As Task(Of CStatList) = (New CRequest).GetHospitalizationPatientInfoCurrent
        Dim d3 As Task(Of CStatList) = (New CRequest).GetAverageHospitalizationTime
        Dim d4 As Task(Of CStatList) = (New CRequest).GetHospitalizationAveragePatientAgeCurrent
        Dim i1 As CStatList = Await d1
        Dim i2 As CStatList = Await d2
        Dim i3 As CStatList = Await d3
        Dim i4 As CStatList = Await d4
        Dim result As Array = {i1, i2, i3, i4}
        Dim aimIndex As Integer = i3.GetIndexOfFirstItemWhereDate("2020-06-09", ">")
    End Sub
End Class