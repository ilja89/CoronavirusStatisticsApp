Imports System.Net
Public Class HelperWebClient

    Public Async Function DownloadDataAsync(urls As List(Of String)) As Task(Of List(Of DownloadedData))
        Dim allTasks As List(Of Task) = New List(Of Task)
        Dim downloadedDataList As List(Of DownloadedData) = New List(Of DownloadedData)

        For i As Integer = 0 To urls.Count - 1
            'set value
            Dim url As String = urls(i)
            Debug.WriteLine(String.Format("[{0}]: Adding {1}", i, url))

            Dim t = Task.Run(Async Function()
                                 'create new instance
                                 Dim wc As WebClient = New WebClient()

                                 'await download
                                 Dim result = Await wc.DownloadStringTaskAsync(url)
                                 Debug.WriteLine(url & " download complete")

                                 'ToDo: add desired code
                                 'add
                                 downloadedDataList.Add(New DownloadedData() With {.Url = url, .Data = result})
                             End Function)
            'add
            allTasks.Add(t)
        Next

        For i As Integer = 0 To allTasks.Count - 1
            'wait for a task to complete
            Dim t = Await Task.WhenAny(allTasks)

            'remove from List
            allTasks.Remove(t)

            'write data to file
            'Note: The following is only for testing.
            'The index in urls won't necessarily correspond to the filename below
            Dim filename As String = System.IO.Path.Combine("C:\Temp", String.Format("CoronavirusData_{0:00}.txt", i))
            System.IO.File.WriteAllText(filename, downloadedDataList(i).Data)

            Debug.WriteLine($"[{i}]: Filename: {filename}")
        Next

        Debug.WriteLine("all tasks complete")

        Return downloadedDataList
    End Function
End Class
Public Class DownloadedData
    Public Property Data As String
    Public Property Url As String
End Class