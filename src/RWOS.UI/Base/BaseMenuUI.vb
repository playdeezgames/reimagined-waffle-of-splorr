Imports RWOS.Model
Imports TGGD.UI

Public MustInherit Class BaseMenuUI
    Inherits BaseRWOSUI
    Protected ReadOnly _menu As IMenu(Of CGAHue)
    Private ReadOnly _title As String
    Private ReadOnly _hue As CGAHue
    Protected MustOverride ReadOnly Property font As IFont

    Protected Sub New(
                     controls As IHostControls,
                     model As IWorldModel,
                     title As String,
                     hue As CGAHue,
                     menu As IMenu(Of CGAHue))
        MyBase.New(controls, model)
        Me._menu = menu
        Me._title = title
        Me._hue = hue
    End Sub

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, 0), _title, _hue)
        _menu.Draw(font, pixelSink)
    End Sub


    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Dim result As IUI(Of CGAHue) = Nothing
        Select Case cmd
            Case UICommand.DOWN
                result = _menu.HandleMenuCommand(MenuCommand.NextItem)
            Case UICommand.UP
                result = _menu.HandleMenuCommand(MenuCommand.PreviousItem)
            Case UICommand.GREEN, UICommand.START
                result = _menu.HandleMenuCommand(MenuCommand.Choose)
            Case UICommand.RED
                result = _menu.HandleMenuCommand(MenuCommand.Cancel)
        End Select
        Return If(result, Me)
    End Function
End Class
