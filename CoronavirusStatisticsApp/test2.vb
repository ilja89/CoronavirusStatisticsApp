Imports TelegramBotLib
Imports TelegramBotLib.CMarkup
Imports TelegramBotLib.CCommandObject
Imports TelegramBotLib.CCommandObjectCollection
Imports cbBtn = TelegramBotLib.CInlineKeyboardButtonBuilder
Imports cBtn = TelegramBotLib.CInlineKeyboardButton
Public Class test2
    Private telecom As New CTelegramBot
    Private objCol As New CCommandObjectCollection
    Private interactionModule As New CTelegramInteractionModule
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Send.Click
        RichTextBox1.Text = telecom.SendTelegramMessage(RichTextBoxInput.Text).Text
    End Sub

    Private Sub GetUpdates_Click(sender As Object, e As EventArgs) Handles GetUpdates.Click
        Dim response As CTelegramResponse = telecom.GetUpdate()
        If (response.IsCommand) Then
            interactionModule.handleCommand(response.Command, {response.CommandText})
        End If
        RichTextBox1.Text = response.Text
    End Sub

    Private Sub GetRawUpdates_Click(sender As Object, e As EventArgs) Handles GetRawUpdates.Click
        RichTextBox1.Text = telecom.GetRawUpdate()
    End Sub

    Private Sub SendKeyboardButton_Click(sender As Object, e As EventArgs) Handles SendKeyboardButton.Click
        Dim keyboard As New cbBtn({
                                    New cBtn("Help list", 1, "/help list"),
                                    New cBtn("Help short", 2, "/help short"), New cBtn("Help full", 2, "/help full"),
                                    New cBtn("Example Button", 3, "/help")})
        RichTextBox1.Text = telecom.sendTelegramInlineKeyboard(keyboard, RichTextBox1.Text.Replace("%newline", "".newline)).Text
    End Sub
End Class
