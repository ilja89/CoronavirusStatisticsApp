Public Class telegramSettings
    Public ReadOnly FormName As String = "Telegram"
    Private ReadOnly _onButtonText As String = "ON"
    Private ReadOnly _offButtonText As String = "OFF"
    Private Sub WhenLoaded() Handles Me.Load
        AddHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
        ColorSettingsAppliedHandler()
        botTokenTextBox.Text = AppSettings.TelegramBotToken
        botChatIDTextBox.Text = AppSettings.TelegramBotChatID
        If (AppSettings.TelegramBotEnabled) Then
            onOffButton.Text = _onButtonText
        Else
            onOffButton.Text = _offButtonText
        End If

        AddHandler botTokenTextBox.TextChanged, AddressOf botTokenTextBox_TextChanged
        AddHandler botChatIDTextBox.TextChanged, AddressOf botChatIDTextBox_TextChanged

        checkIfBotCanBeActivated()
    End Sub
    Private Sub MeClosingHandler() Handles Me.Closing
        RemoveHandler AppSettings.NewColorSettingsApplied, AddressOf ColorSettingsAppliedHandler
    End Sub
    Private Sub ColorSettingsAppliedHandler()
        Me.BackColor = AppSettings.MainColor
        botTokenLabel.BackColor = AppSettings.SecondaryColor
        botChatIDLabel.BackColor = AppSettings.SecondaryColor
    End Sub

    Private Sub EnableTelegramBot()
        AppSettings.TelegramBotEnabled = True
    End Sub

    Private Sub DisableTelegramBot()
        AppSettings.TelegramBotEnabled = False
    End Sub

    Private Sub checkIfBotCanBeActivated()
        If (botChatIDTextBox.Text <> Nothing AndAlso botTokenTextBox.Text <> Nothing) Then
            onOffButton.Enabled = True
        Else
            onOffButton.Enabled = False
            onOffButton.Text = _offButtonText
            DisableTelegramBot()
        End If
    End Sub

    Private Sub botTokenTextBox_TextChanged(sender As TextBox, e As EventArgs)
        Dim k = AppSettings.TelegramBotEnabled
        AppSettings.TelegramBotToken = sender.Text
        checkIfBotCanBeActivated()
    End Sub

    Private Sub botChatIDTextBox_TextChanged(sender As TextBox, e As EventArgs)
        AppSettings.TelegramBotChatID = sender.Text
        checkIfBotCanBeActivated()
    End Sub

    Private Sub onOffButton_Click(sender As Object, e As EventArgs) Handles onOffButton.Click
        If (onOffButton.Text = _offButtonText) Then
            onOffButton.Text = _onButtonText
            EnableTelegramBot()
        ElseIf (onOffButton.Text = _onButtonText) Then
            onOffButton.Text = _offButtonText
            DisableTelegramBot()
        Else
            Throw New Exception("Wrong text on telegram bot state button")
        End If
    End Sub

    Private Sub helpTokenButton_Click(sender As Object, e As EventArgs) Handles helpTokenButton.Click
        Dim newHelpForm As New helpForm
        newHelpForm.Init($"Uue boti loomiseks ja selle märgi hankimiseks tehke järgmist:
1. Avage Telegram ja tippige otsingusse: ""@BotFather"".
2. Tekib BotFatheri botikonto. Klõpsake sellel.
3. Uue roboti loomise alustamiseks tippige ""/start"".
4. Tippige ""/newbot"".
5. Sisestage uue boti õige nimi.
6. Pärast boti loomist kopeerige boti tunnus pärast BotFatheri teksti ""Use this token to access the HTTP API:"".")
        newHelpForm.Show()
    End Sub

    Private Sub helpChatIdButton_Click(sender As Object, e As EventArgs) Handles helpChatIdButton.Click
        Dim newHelpForm As New helpForm
        newHelpForm.Init($"Vestluse ID hankimiseks tehke järgmist:
1. Avage Telegram ja tippige otsingusse: ""@getmyid_bot"".
2. Seal on roboti konto ""Get My ID"". Klõpsake sellel.
3. Vestluses loodud robotiga kirjutage suvaline sõnum ja saatke see.
4. Edastage saadetud sõnum, et vestelda robotiga ""Get My ID"".
5. Saate sõnumi oma kasutajatunnuse, praeguse vestluse ID ja ""Forwarded from:"". Kopeerige number pärast ""Forwarded from:"" See on teie boti vestluse ID.")
        newHelpForm.Show()
    End Sub
End Class