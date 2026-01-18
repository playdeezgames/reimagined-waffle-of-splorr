Imports RWOS.Model
Imports TGGD.UI

Public Class NumberEditUI
    Inherits BaseMenuUI
    Private value As Integer
    Private ReadOnly confirm As Func(Of Integer, IUI(Of CGAHue))

    Private Sub New(
                    controls As IHostControls,
                    model As IWorldModel, title As String,
                    hue As CGAHue,
                    value As Integer,
                    confirm As Func(Of Integer, IUI(Of CGAHue)),
                    cancel As Func(Of IUI(Of CGAHue)))
        MyBase.New(controls, model, title, hue, New PickerMenu(cancel))
        Me.value = value
        Me.confirm = confirm
        _menu.AddChoice("Cancel", cancel)
        _menu.AddChoice("Confirm", AddressOf ConfirmValue)
        _menu.AddChoice("Clear", AddressOf ClearValue)
        For Each digit In Enumerable.Range(0, 10)
            _menu.AddChoice($"{digit}", AddDigit(digit))
        Next
    End Sub

    Private Function ConfirmValue() As IUI(Of CGAHue)
        Return confirm(value)
    End Function

    Private Function AddDigit(digit As Integer) As Func(Of IUI(Of CGAHue))
        Return Function()
                   value = value * 10 + digit
                   Return Me
               End Function
    End Function

    Private Function ClearValue() As IUI(Of CGAHue)
        value = 0
        Return Me
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        MyBase.Update(pixelSink, elapsedTime)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, font.Height * 2), $"{value}", CGAHue.MAGENTA)
    End Sub

    Friend Shared Function Launch(
                                 controls As IHostControls,
                                 model As IWorldModel, title As String,
                                 hue As CGAHue,
                                 value As Integer,
                                 confirm As Func(Of Integer, IUI(Of CGAHue)),
                                 cancel As Func(Of IUI(Of CGAHue))) As Func(Of IUI(Of CGAHue))
        Return Function() New NumberEditUI(controls, model, title, hue, value, confirm, cancel)
    End Function
End Class
