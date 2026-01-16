Public Interface IMenu(Of THue)
    Sub AddChoice(text As String, choose As Func(Of IUI(Of THue)))
    Function HandleMenuCommand(command As MenuCommand) As IUI(Of THue)
    Sub Draw(font As IFont, pixelSink As IPixelSink(Of THue))
End Interface
