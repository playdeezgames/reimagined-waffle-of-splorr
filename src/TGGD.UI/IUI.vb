Public Interface IUI(Of THue)
    Sub Update(pixelSink As IPixelSink(Of THue), elapsedTime As TimeSpan)
    ReadOnly Property ViewWidth As Integer
    ReadOnly Property ViewHeight As Integer
End Interface
