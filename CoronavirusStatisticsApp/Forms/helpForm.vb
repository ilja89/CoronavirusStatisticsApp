Public Class helpForm
    Public Sub Init(newText As String)
        RichTextBox1.Text = newText
    End Sub

    Public Sub WhenLoaded() Handles Me.Load
        Dim pic As Bitmap = Bitmap.FromFile(AppSettings.ResourcesPath + "icon.ico")
        Me.Icon = System.Drawing.Icon.FromHandle(pic.GetHicon)
    End Sub
End Class