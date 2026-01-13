Imports TGGD.UI

Public Class UIContext
    Implements IUIContext
    Sub New(pixelBuffer As IPixelBuffer)
        Me.PixelBuffer = pixelBuffer
    End Sub

    Public ReadOnly Property PixelBuffer As IPixelBuffer Implements IUIContext.PixelBuffer

    Public Sub Refresh() Implements IUIContext.Refresh
        For Each x In Enumerable.Range(0, PixelBuffer.Columns)
            For Each y In Enumerable.Range(0, PixelBuffer.Rows)
                PixelBuffer.SetPixel(x, y, (x + y) Mod 4)
            Next
        Next
    End Sub
End Class
