' FILENAME: CArgb.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 28.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: MapControl

''' <summary>
''' Used to somehow save ARGB color values separately.
''' </summary>
Public Class CArgb
    Public alpha As Integer
    Public red As Integer
    Public green As Integer
    Public blue As Integer
    Public Sub New(newAlpha As Integer,
                   newRed As Integer,
                   newGreen As Integer,
                   newBlue As Integer)
        alpha = newAlpha
        red = newRed
        green = newGreen
        blue = newBlue
    End Sub
End Class
