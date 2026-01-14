Public Interface IUI(Of THue)
    Sub Update(pixelSink As IPixelSink(Of THue), elapsedTime As TimeSpan)
End Interface
