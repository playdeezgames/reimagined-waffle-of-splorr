Imports Microsoft.Xna.Framework.Graphics
Imports RWOS.UI
Imports TGGD.Presentation
Imports TGGD.UI

Friend Class RWOSHost
    Inherits Host(Of CGAHue)

    Protected Overrides ReadOnly Property ScreenWidth As Integer
        Get
            Return 1280
        End Get
    End Property

    Protected Overrides ReadOnly Property ScreenHeight As Integer
        Get
            Return 800
        End Get
    End Property

    Protected Overrides ReadOnly Property FullScreen As Boolean
        Get
            Return False
        End Get
    End Property

    Protected Overrides ReadOnly Property ViewWidth As Integer
        Get
            Return 320
        End Get
    End Property

    Protected Overrides ReadOnly Property ViewHeight As Integer
        Get
            Return 200
        End Get
    End Property

    Protected Overrides Sub Refresh(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        'TODO: move to UI context
    End Sub

    Protected Overrides Function CreateDisplayBuffer(texture As Texture2D) As IPixelSink(Of CGAHue)
        Return New DisplayBuffer(texture)
    End Function
End Class
