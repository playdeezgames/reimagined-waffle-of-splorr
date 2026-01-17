Imports TGGD.UI

Friend Class PickerMenu
    Inherits Menu(Of CGAHue)

    Private ReadOnly foreground As CGAHue = CGAHue.WHITE
    Private ReadOnly background As CGAHue = CGAHue.BLACK

    Public Sub New(cancel As Func(Of IUI(Of CGAHue)))
        MyBase.New(cancel)
    End Sub

    Public Overrides Sub Draw(font As IFont, pixelSink As IPixelSink(Of CGAHue))
        Dim drawIndex = 0
        Dim height = font.Height
        Dim y = pixelSink.Rows \ 2 - height * ChoiceIndex - height \ 2
        pixelSink.Fill(0, pixelSink.Rows \ 2 - height \ 2, pixelSink.Columns, height, foreground)
        For Each choice In ChoiceTexts
            font.WriteText(pixelSink, (pixelSink.Columns \ 2 - font.GetTextWidth(choice) \ 2, y), choice, If(drawIndex = choiceIndex, background, foreground))
            drawIndex += 1
            y += height
        Next
    End Sub
End Class
