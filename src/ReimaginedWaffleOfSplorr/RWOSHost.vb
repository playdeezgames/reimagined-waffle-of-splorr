Imports Microsoft.Xna.Framework.Graphics
Imports RWOS.UI
Imports TGGD.Presentation
Imports TGGD.UI

Friend Class RWOSHost
    Inherits BaseHost(Of CGAHue)

    Public Sub New(settings As RWOSHostControls)
        MyBase.New(settings, New RWOSUI(settings))
    End Sub

    Protected Overrides Function CreateDisplayBuffer(texture As Texture2D) As IPixelSink(Of CGAHue)
        Return New DisplayBuffer(texture)
    End Function
End Class
