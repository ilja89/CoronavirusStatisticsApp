' FILENAME: LoadingControl.vb
' AUTOR: El Plan - Nikita Budovei
' CREATED: 20.04.2022
' CHANGED: 25.04.2022
'
' DESCRIPTION: See below
'
' PRECONDITIONS: ...
' SUBSEQUENT CONDITIONS: ...
' RELATED COMPONENTS: ...

Imports System.Math
''' <summary>
''' Provides loading overlay control for application
''' </summary>
Public Class loadingControl
    Private _picture As Image = Nothing
    Private _bmp As Bitmap = Nothing
    Private _rotation As Boolean = False
    Private _statusTo As Integer = 0
    Private _timeLeft As Integer = 0

    Public Property Status As Integer
        Get
            Return progress.Value
        End Get
        Set(value As Integer)
            progress.Value = Min(Max(value, 0), 100)
        End Set
    End Property
    Public Property Picture As Image
        Get
            Return _picture
        End Get
        Set(value As Image)
            _picture = value.Clone
            picturePictureBox.Image = value.Clone
        End Set
    End Property

    Public Property PictureSize As Size
        Get
            Return picturePictureBox.Size
        End Get
        Set(value As Size)
            picturePictureBox.Size = Size
            AdjustComponentsLocation()
        End Set
    End Property
    Public Property BackgroundTransparence As Integer
        Get
            Return (255 - Me.BackColor.A) / 2.55
        End Get
        Set(value As Integer)
            Dim argb As Map.CArgb
            With Me.BackColor
                argb = New Map.CArgb(.A, .R, .G, .B)
            End With
            value = Max(Min(value, 100), 0)
            Me.BackColor = Color.FromArgb(255 - value * 2.55, argb.red, argb.green, argb.blue)
        End Set
    End Property

    Private Declare Function GetTickCount64 Lib "kernel32" () As Long

    Public Sub Init()
        If (picturePictureBox.Image Is Nothing) Then
            picturePictureBox.Image = _picture
        End If
        If (_picture IsNot Nothing) Then
            _bmp = New Bitmap(_picture)
            _bmp.MakeTransparent(Color.White)
        End If
        AdjustComponentsLocation()
    End Sub
    Private Sub WhenResized() Handles Me.Resize
        AdjustComponentsLocation()
    End Sub
    Private Sub AdjustComponentsLocation()
        picturePictureBox.Location = New Point(Size.Width / 2 - picturePictureBox.Size.Width / 2,
                                        Size.Height / 2 - picturePictureBox.Size.Height / 2)
        progress.Size = New Size(Me.Size.Width / 2, Me.Size.Height / 20)
        progress.Location = New Point(picturePictureBox.Location.X + picturePictureBox.Size.Width / 2 - progress.Size.Width / 2,
                                      picturePictureBox.Location.Y + picturePictureBox.Size.Height * 1.1)
    End Sub
    Public Sub StartRotation()
        _rotation = True
        Dim degrees As Integer = 0
        While (_rotation)
            RedrawPicture(degrees)
            degrees += 1
            Sleep(25)
        End While
    End Sub
    Public Sub StopRotation()
        _rotation = False
    End Sub
    Private Sub RedrawPicture(degrees As Integer)
        If _bmp Is Nothing Then Exit Sub
        Dim oldImage As Bitmap = picturePictureBox.Image
        Dim bmp As New Bitmap(CInt(_picture.Width * 1.4), CInt(_picture.Height * 1.4))
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim m As New System.Drawing.Drawing2D.Matrix
        m.RotateAt(degrees, New PointF(bmp.Width / 2, bmp.Height / 2))
        g.Transform = m

        g.DrawImage(_bmp, New PointF((bmp.Width - _picture.Width) / 2,
                                         (bmp.Height - _picture.Height) / 2))
        picturePictureBox.Image = bmp
        If oldImage IsNot Nothing Then oldImage.Dispose()
        m.Dispose()
        g.Dispose()
    End Sub

    ''' <summary>
    ''' Waits for <paramref name="delayms"/> milliseconds.
    ''' </summary>
    ''' <param name="delayms">Delay in milliseconds</param>
    Private Sub Sleep(delayms As Integer)
        Dim startTime As Long = GetTickCount64
        Dim stopTime As Long = startTime + delayms
        Dim now As Long = startTime
        While (now < stopTime)
            now = GetTickCount64
        End While
    End Sub

End Class
