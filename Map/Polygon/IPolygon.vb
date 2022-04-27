Public Interface IPolygon

    ReadOnly Property MinY As Integer

    ReadOnly Property MaxX As Integer

    ReadOnly Property MaxY As Integer

    Property BorderPen As Pen

    Property Name As String

    Property NamePoint As PointF

    ReadOnly Property Key As String

    Property DrawName As Boolean

    Property GradientBrushCenterColor As Color

    Property GradientBrushSideColor As Color

    ReadOnly Property Points As Point()

    Function IsPointInside(point As Point)

    Sub Draw(pb As PictureBox,
                    Optional fill As Boolean = False,
                    Optional drawBorderPen As Pen = Nothing,
                    Optional withCenterColor As Color = Nothing,
                    Optional withSideColor As Color = Nothing,
                    Optional simpleDraw As Boolean = False)

    Sub DrawPolygonName(pb As PictureBox, textFont As Font)
End Interface
