Public Class homeForm
    Private Sub WhenLoaded() Handles Me.Load
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        BackColor = AppSettings.MainColor
    End Sub
End Class