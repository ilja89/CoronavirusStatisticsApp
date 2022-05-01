' FILENAME: homeForm.vb
' AUTOR: El Plan - Ilja Kuznetsov
' CREATED: 20.04.2022
' CHANGED: 20.04.2022
'
' DESCRIPTION: See below
'
' RELATED COMPONENTS: ...
''' <summary>
''' Home form
''' </summary>
Public Class homeForm
    Private Sub WhenLoaded() Handles Me.Load
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        BackColor = AppSettings.MainColor
    End Sub
End Class