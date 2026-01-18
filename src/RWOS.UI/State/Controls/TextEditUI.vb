Imports RWOS.Model
Imports TGGD.UI

Public Class TextEditUI
    Inherits BaseMenuUI
    Private value As String
    Private ReadOnly confirm As Func(Of String, IUI(Of CGAHue))

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Private Sub New(
                    controls As IHostControls,
                    model As IWorldModel, title As String,
                    hue As CGAHue,
                    value As String,
                    confirm As Func(Of String, IUI(Of CGAHue)),
                    cancel As Func(Of IUI(Of CGAHue)))
        MyBase.New(controls, model, title, hue, New PickerMenu(cancel))
        Me.value = value
        Me.confirm = confirm
        _menu.AddChoice("Cancel", cancel)
        _menu.AddChoice("Confirm", AddressOf ConfirmValue)
        _menu.AddChoice("Clear", AddressOf ClearValue)
        For Each character In Enumerable.Range(32, 96)
            _menu.AddChoice(Chr(character), AddCharacter(character))
        Next
    End Sub

    Private Function AddCharacter(character As Integer) As Func(Of IUI(Of CGAHue))
        Return Function()
                   value &= Chr(character)
                   Return Me
               End Function
    End Function

    Private Function ClearValue() As IUI(Of CGAHue)
        value = String.Empty
        Return Me
    End Function

    Private Function ConfirmValue() As IUI(Of CGAHue)
        Return confirm(value)
    End Function
    Friend Shared Function Launch(
                                 controls As IHostControls,
                                 model As IWorldModel, title As String,
                                 hue As CGAHue,
                                 value As String,
                                 confirm As Func(Of String, IUI(Of CGAHue)),
                                 cancel As Func(Of IUI(Of CGAHue))) As Func(Of IUI(Of CGAHue))
        Return Function() New TextEditUI(controls, model, title, hue, value, confirm, cancel)
    End Function


    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        MyBase.Update(pixelSink, elapsedTime)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, font.Height * 2), value, CGAHue.MAGENTA)
    End Sub
End Class
