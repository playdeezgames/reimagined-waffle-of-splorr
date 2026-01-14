Public MustInherit Class BaseUI(Of THue)
    Implements IUI(Of THue)

    Public MustOverride Sub Update(
                                  pixelSink As IPixelSink(Of THue),
                                  elapsedTime As TimeSpan) Implements IUI(Of THue).Update
End Class
