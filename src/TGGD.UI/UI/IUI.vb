Public Interface IUI(Of THue)
    Sub Update(
              pixelSink As IPixelSink(Of THue),
              elapsedTime As TimeSpan)
    Function HandleCommand(cmd As String) As IUI(Of THue)
    ReadOnly Property ViewWidth As Integer
    ReadOnly Property ViewHeight As Integer
End Interface
