Public Class Gradient
    Private _centerColor As Color
    Private _sideColor As Color
    Public Property CenterColor() As Color
        Get
            Return _centerColor
        End Get
        Set(value As Color)
            _centerColor = value
        End Set
    End Property
    Public Property SideColor() As Color
        Get
            Return _sideColor
        End Get
        Set(value As Color)
            _sideColor = value
        End Set
    End Property
    Public Function Green()
        _centerColor = Color.Green
        _sideColor = Color.DarkGreen
        Return Me
    End Function
    Public Function BrightGreen()
        _centerColor = Color.GreenYellow
        _sideColor = Color.ForestGreen
        Return Me
    End Function
    Public Function Yellow()
        _centerColor = Color.Yellow
        _sideColor = Color.FromArgb(255, 153, 148, 0)
        Return Me
    End Function
    Public Function Red()
        _centerColor = Color.Red
        _sideColor = Color.FromArgb(100, Color.DarkRed)
        Return Me
    End Function
    Public Function Gray()
        _centerColor = Color.Gray
        _sideColor = Color.DarkGray
        Return Me
    End Function
    Public Function Blue()
        _centerColor = Color.FromArgb(255, 100, 100, 200)
        _sideColor = Color.FromArgb(255, 75, 75, 150)
        Return Me
    End Function
    Public Function BrightBlue()
        _centerColor = Color.FromArgb(255, 150, 150, 250)
        _sideColor = Color.FromArgb(255, 100, 100, 180)
        Return Me
    End Function
    Public Function Black()
        _centerColor = Color.FromArgb(255, 0, 0, 0)
        _sideColor = Color.FromArgb(255, 15, 15, 15)
        Return Me
    End Function
    Public Function Orange()
        _centerColor = Color.Orange
        _sideColor = Color.FromArgb(255, 160, 90, 0)
        Return Me
    End Function

    Public Function Purple()
        _centerColor = Color.Purple
        _sideColor = Color.FromArgb(255, 88, 19, 89)
        Return Me
    End Function
    Public Function White()
        _centerColor = Color.White
        _sideColor = Color.FromArgb(255, 180, 180, 180)
        Return Me
    End Function

    Public Function FromARGB(centerARGB As Argb, sideARGB As Argb)
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
        Return Me
    End Function
End Class
