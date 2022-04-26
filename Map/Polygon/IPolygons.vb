Public Interface IPolygons
    Property Element(index As Integer) As CPolygon

    ReadOnly Property Count As Integer

    Property DefBgGradient As CGradient

    Sub Add(newPolygon As CPolygon)

    Function GetPolygonWhereName(aimName As String) As CPolygon

    Sub SetGradientWhereName(aimName As String, gradient As CGradient)

    Sub SetGradientWhereKey(aimKey As String, gradient As CGradient)

    Sub DrawAll(pb As PictureBox,
                       Optional fill As Boolean = False,
                       Optional newCenterColor As Color = Nothing,
                       Optional newSideColor As Color = Nothing,
                       Optional textFont As Font = Nothing,
                       Optional withNames As Boolean = True,
                       Optional simplePolygonsDraw As Boolean = False,
                       Optional simpleDefaultBackgroundDraw As Boolean = False,
                       Optional baseImage As Image = Nothing)


End Interface
