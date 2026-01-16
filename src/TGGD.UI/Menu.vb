Public MustInherit Class Menu(Of THue)
    Implements IMenu(Of THue)

    Private ReadOnly _choices As New List(Of (Text As String, Choose As Func(Of IUI(Of THue))))
    Private _choiceIndex As Integer = 0
    Private ReadOnly _cancel As Func(Of IUI(Of THue))
    Protected ReadOnly Property ChoiceIndex As Integer
        Get
            Return _choiceIndex
        End Get
    End Property

    Protected ReadOnly Property ChoiceTexts As IEnumerable(Of String)
        Get
            Return _choices.Select(Function(x) x.Text)
        End Get
    End Property

    Sub New(cancel As Func(Of IUI(Of THue)))
        Me._cancel = cancel
    End Sub


    Public Sub AddChoice(text As String, choose As Func(Of IUI(Of THue))) Implements IMenu(Of THue).AddChoice
        _choices.Add((text, choose))
    End Sub

    Public MustOverride Sub Draw(font As IFont, pixelSink As IPixelSink(Of THue)) Implements IMenu(Of THue).Draw

    Public Function HandleMenuCommand(command As MenuCommand) As IUI(Of THue) Implements IMenu(Of THue).HandleMenuCommand
        Select Case command
            Case MenuCommand.NextItem
                _choiceIndex = (_choiceIndex + 1) Mod _choices.Count
            Case MenuCommand.PreviousItem
                _choiceIndex = (_choiceIndex + _choices.Count - 1) Mod _choices.Count
            Case MenuCommand.Choose
                Return _choices(_choiceIndex).Choose.Invoke()
            Case MenuCommand.Cancel
                Return _cancel?.Invoke()
        End Select
        Return Nothing
    End Function
End Class
