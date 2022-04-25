Public Class settings
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textBoxDelimiter.Text = AppSettings.CSVExporterDelimiter
        textBoxTextQualifier.Text = AppSettings.CSVExporterTextQualifier
        richTextBoxCachePath.Text = AppSettings.CachePath
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
        AppSettings.CachePath = AppSettings.AppCacheDefaultPath
        richTextBoxCachePath.Text = AppSettings.CachePath
    End Sub
End Class