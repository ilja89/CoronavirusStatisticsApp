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
    Public Function Yellow()
        _centerColor = Color.Yellow
        _sideColor = Color.LightGoldenrodYellow
        Return Me
    End Function
    Public Function Red()
        _centerColor = Color.Red
        _sideColor = Color.FromArgb(100, Color.DarkRed)
        Return Me
    End Function
    Public Function Gray()
        _centerColor = Color.Gray
        _sideColor = Color.FromArgb(100, Color.Gray)
        Return Me
    End Function
End Class
