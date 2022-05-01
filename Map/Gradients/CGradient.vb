' FILENAME: CGradient.vb
' AUTHOR: El Plan : Ilja Kuznetsov.
' CREATED: 25.03.2022
' CHANGED: 29.03.2022
'
' DESCRIPTION: See below↓↓↓

' Related components: ...
''' <summary>
''' Used to save gradient colors.
''' </summary>
Public Class CGradient
    Implements IGradient

    Private _centerColor As Color
    Private _sideColor As Color
    Public Property CenterColor() As Color Implements IGradient.CenterColor
        Get
            Return _centerColor
        End Get
        Set(value As Color)
            _centerColor = value
        End Set
    End Property
    Public Property SideColor() As Color Implements IGradient.SideColor
        Get
            Return _sideColor
        End Get
        Set(value As Color)
            _sideColor = value
        End Set
    End Property
    Public Shared Function Green()
        Return New CGradient(Color.Green, Color.DarkGreen)
    End Function
    Public Shared Function BrightGreen()
        Return New CGradient(Color.GreenYellow, Color.ForestGreen)
    End Function
    Public Shared Function Yellow()
        Return New CGradient(Color.Yellow, Color.FromArgb(255, 153, 148, 0))
    End Function
    Public Shared Function Red()
        Return New CGradient(Color.Red, Color.FromArgb(100, Color.DarkRed))
    End Function
    Public Shared Function Gray()
        Return New CGradient(Color.Gray, Color.DarkGray)
    End Function
    Public Shared Function Blue()
        Return New CGradient(Color.FromArgb(255, 100, 100, 200), Color.FromArgb(255, 75, 75, 150))
    End Function
    Public Shared Function BrightBlue()
        Return New CGradient(Color.FromArgb(255, 150, 150, 250), Color.FromArgb(255, 100, 100, 180))
    End Function
    Public Shared Function Black()
        Return New CGradient(Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 15, 15, 15))
    End Function
    Public Shared Function Orange()
        Return New CGradient(Color.Orange, Color.FromArgb(255, 160, 90, 0))
    End Function

    Public Shared Function Purple()
        Return New CGradient(Color.Purple, Color.FromArgb(255, 88, 19, 89))
    End Function
    Public Shared Function White()
        Return New CGradient(Color.White, Color.FromArgb(255, 180, 180, 180))
    End Function

    Public Sub New(centerARGB As CArgb, sideARGB As CArgb)
        _centerColor = Color.FromArgb(
            centerARGB.alpha,
            centerARGB.red,
            centerARGB.green,
            centerARGB.blue)
        _sideColor = Color.FromArgb(
            sideARGB.alpha,
            sideARGB.red,
            sideARGB.green,
            sideARGB.blue)
    End Sub
    Public Sub New(centerColor As Color, sideColor As Color)
        _centerColor = centerColor
        _sideColor = sideColor
    End Sub
    Public Sub New()

    End Sub
End Class
