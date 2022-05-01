' FILENAME: settings.vb
' AUTOR: El Plan - Ilja Kuznetsov
' CREATED: 25.04.2022
' CHANGED: 01.05.2022
'
' DESCRIPTION: See below
'
' RELATED COMPONENTS: ...
''' <summary>
''' Form for application settings editing
''' </summary>
Public Class settings
    Public ReadOnly FormName As String = "Seaded"
    Private _listBoxElementRelatedSetting() As Action(Of Color) = {
        Sub(val As Color) AppSettings.MainColor = val, Sub(val As Color) AppSettings.SecondaryColor = val,
        Sub(val As Color) AppSettings.ButtonColorMap = val, Sub(val As Color) AppSettings.ButtonColorStatistics = val,
        Sub(val As Color) AppSettings.ButtonColorTelegram = val, Sub(val As Color) AppSettings.ButtonColorSettings = val,
        Sub(val As Color) AppSettings.ButtonColorExit = val, Sub(val As Color) AppSettings.PopupColorMain = val,
        Sub(val As Color) AppSettings.PopupColorSecondary = val}
    Private _listBoxLastSelected As Integer = 0
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textBoxDelimiter.Text = AppSettings.CSVExporterDelimiter
        textBoxTextQualifier.Text = AppSettings.CSVExporterTextQualifier
        richTextBoxCachePath.Text = AppSettings.CachePath
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
    End Sub

    Private Sub textBoxDelimiter_TextChanged(sender As TextBox, e As EventArgs) Handles textBoxDelimiter.TextChanged
        AppSettings.CSVExporterDelimiter = sender.Text
    End Sub

    Private Sub textBoxTextQualifier_TextChanged(sender As Object, e As EventArgs) Handles textBoxTextQualifier.TextChanged
        AppSettings.CSVExporterTextQualifier = sender.Text
    End Sub

    Private Sub buttonCachePathChange_Click(sender As Object, e As EventArgs) Handles buttonCachePathChange.Click
        If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then
            AppSettings.CachePath = folderBrowserDialog.SelectedPath
            richTextBoxCachePath.Text = AppSettings.CachePath
        End If
    End Sub

    Private Sub buttonCachePathReset_Click(sender As Object, e As EventArgs) Handles buttonCachePathReset.Click
        AppSettings.CachePath = AppSettings.DefaultCachePath
        richTextBoxCachePath.Text = AppSettings.CachePath
    End Sub
    Private Sub buttonChangeApplicationColors_Click(sender As Object, e As EventArgs) Handles buttonChangeApplicationColors.Click
        If (colorDialog1.ShowDialog = DialogResult.OK) Then
            _listBoxElementRelatedSetting(_listBoxLastSelected)(colorDialog1.Color)
            AppSettings.RaiseEventNewColorSettingsApplied()
        End If
    End Sub
    Private Sub listBoxApplicationElement_SelectedIndexChanged(sender As ListBox, e As EventArgs) Handles listBoxApplicationElement.SelectedIndexChanged
        _listBoxLastSelected = listBoxApplicationElement.SelectedIndex
    End Sub

    Private Sub buttonResetApplicationColors_Click(sender As Object, e As EventArgs) Handles buttonResetApplicationColors.Click
        AppSettings.ResetToDefault()
        AppSettings.RaiseEventNewColorSettingsApplied()
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        BackColor = AppSettings.MainColor
        For Each control As Control In Me.Controls
            If (TypeOf control Is Label) Then
                control.BackColor = AppSettings.SecondaryColor
            End If
        Next
    End Sub
End Class