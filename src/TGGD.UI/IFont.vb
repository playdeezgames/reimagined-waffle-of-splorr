Public Interface IFont
    Function WriteText(Of THue)(pixelSink As IPixelSink(Of THue), position As (Column As Integer, Row As Integer), text As String, hue As THue) As (Column As Integer, Row As Integer)
    Function WriteCenteredText(Of THue)(pixelSink As IPixelSink(Of THue), position As (Column As Integer, Row As Integer), text As String, hue As THue) As (Column As Integer, Row As Integer)
    Function GetTextWidth(text As String) As Integer
End Interface
