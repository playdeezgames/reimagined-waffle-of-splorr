Imports Microsoft.Xna.Framework.Graphics
Imports RWOS.UI
Imports TGGD.Presentation
Imports TGGD.UI

Friend Class RWOSHost
    Inherits BaseHost(Of CGAHue)

    Public Sub New()
        MyBase.New(New RWOSUI)
    End Sub

    Protected Overrides ReadOnly Property FullScreen As Boolean
        Get
            Return False
        End Get
    End Property

    Protected Overrides ReadOnly Property ScaleX As Integer
        Get
            Return 4
        End Get
    End Property

    Protected Overrides ReadOnly Property ScaleY As Integer
        Get
            Return 4
        End Get
    End Property

    Protected Overrides Function CreateDisplayBuffer(texture As Texture2D) As IPixelSink(Of CGAHue)
        Return New DisplayBuffer(texture)
    End Function
End Class
