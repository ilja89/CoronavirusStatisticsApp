Imports System.Math
Public Class loadingProcess
    Public Property BackgroundTransparence As Integer
        Get
            Return (255 - Me.BackColor.A) / 2.55
        End Get
        Set(value As Integer)
            Dim argb As Map.CArgb
            With Me.BackColor
                argb = New Map.CArgb(.A, .R, .G, .B)
            End With
            value = Max(Min(value, 100), 0)
            Me.BackColor = Color.FromArgb(255 - value * 2.55, argb.red, argb.green, argb.blue)
        End Set
    End Property

    Private Declare Function GetTickCount64 Lib "kernel32" () As Long
    ''' <summary>
    ''' Waits for <paramref name="delayms"/> milliseconds.
    ''' </summary>
    ''' <param name="delayms">Delay in milliseconds</param>
    Private Sub Sleep(delayms As Integer)
        Dim startTime As Long = GetTickCount64
        Dim stopTime As Long = startTime + delayms
        Dim now As Long = startTime
        While (now < stopTime)
            now = GetTickCount64
        End While
    End Sub

End Class
