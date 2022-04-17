Imports TelegramBotLib
Public Class CTelegramInteractionModule
    Public objCol As New CCommandObjectCollection
    Public telecom As New CTelegramBot

    Public Sub handleCommand(commandName As String, commandParameters As String())
        objCol.Item(commandName).CallCommand(commandParameters)
    End Sub
    Public Sub help(Optional descriptionType As String = "full")
        Dim send As String = "List of commands:".bold.italic
        Dim i As Integer = 1
        If (descriptionType = "full" Or descriptionType = "") Then
            While (i <= objCol.Count)
                send = send.newline + objCol.Item(i).FullDescription
                i = i + 1
            End While
        ElseIf (descriptionType = "short") Then
            While (i <= objCol.Count)
                send = send.newline + objCol.Item(i).ShortDescription
                i = i + 1
            End While
        ElseIf (descriptionType = "list") Then
            While (i <= objCol.Count)
                send = send.newline + "/" + objCol.Item(i).Command
                i = i + 1
            End While
        End If
        telecom.SendTelegramMessage(send)
    End Sub
    Public Sub getChart(statType As String, period As String)

    End Sub
    Public Sub New()
        objCol.Add(New CCommandObject("help", Me, "help", vbMethod,
                                      "/help - used to receive list of commands",
                                      "/help - used to receive list of commands.".
                                      newline + "Syntax:".
                                      newline.tab + "/help or /help full - full list of commands".
                                      newline.tab + "/help short - short list of commands"))
        objCol.Add(New CCommandObject("getchart", Me, "getChart", vbMethod,
                                      "/getchart - get optional chart",
                                      "/getchart - get optional chart".
                                      newline + "Syntax:".
                                      newline.tab + "/getchart [stattype] [period]".
                                      newline + "Possible stattype:".
                                      newline.tab + "vac".bold + " - vaccinated".
                                      newline.tab + "dec".bold + " - deceased".
                                      newline.tab + "test".bold + " - positive results".
                                      newline.tab + "sick".bold + " - sick".
                                      newline + "Possible period:".
                                      newline.tab + "Integer, example:".
                                      newline.tab.tab + "7".bold + " - will lead to statistics per 7 days".
                                      newline.tab + "Date period, example:".
                                      newline.tab.tab + "10.04.2022-17.04.2022".bold + " - will give statistics per 7 days from
                                      10.04.2022 to 17.04.2022"))
    End Sub
End Class
