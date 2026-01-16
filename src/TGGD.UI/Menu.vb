Public Class Menu(Of THue)
    Implements IMenu(Of THue)

    Private ReadOnly choices As New List(Of (Text As String, Choose As Func(Of IUI(Of THue))))
    Private choiceIndex As Integer = 0
    Private ReadOnly cancel As Func(Of IUI(Of THue))
    Private ReadOnly position As (Column As Integer, Row As Integer)
    Private ReadOnly foreground As THue
    Private ReadOnly background As THue

    Sub New(foreground As THue, background As THue, cancel As Func(Of IUI(Of THue)))
        Me.cancel = cancel
        Me.foreground = foreground
        Me.background = background
    End Sub


    Public Sub AddChoice(text As String, choose As Func(Of IUI(Of THue))) Implements IMenu(Of THue).AddChoice
        choices.Add((text, choose))
    End Sub

    Public Sub Draw(font As IFont, pixelSink As IPixelSink(Of THue)) Implements IMenu(Of THue).Draw
        Dim drawIndex = 0
        Dim height = font.Height
        For Each choice In choices
            Dim fg = If(drawIndex = choiceIndex, background, foreground)
            Dim bg = If(drawIndex = choiceIndex, foreground, background)
            Dim width = font.GetTextWidth(choice.Text)
            pixelSink.Fill(position.Column, position.Row + height * drawIndex, width, height, bg)
            font.WriteText(pixelSink, (position.Column, position.Row + height * drawIndex), choice.Text, fg)
            drawIndex += 1
        Next
    End Sub

    Public Function HandleCommand(command As MenuCommand) As IUI(Of THue) Implements IMenu(Of THue).HandleCommand
        Select Case command
            Case MenuCommand.NextItem
                choiceIndex = (choiceIndex + 1) Mod choices.Count
            Case MenuCommand.PreviousItem
                choiceIndex = (choiceIndex + choices.Count - 1) Mod choices.Count
            Case MenuCommand.Choose
                Return choices(choiceIndex).Choose.Invoke()
            Case MenuCommand.Cancel
                Return cancel?.Invoke()
        End Select
        Return Nothing
    End Function
End Class
