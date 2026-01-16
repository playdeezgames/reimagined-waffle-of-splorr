Imports RWOS.Model
Imports TGGD.UI

Friend Class MainMenuUI
    Inherits BaseRWOSUI
    Implements IUI(Of CGAHue)
    Private ReadOnly menu As IMenu(Of CGAHue)

    Public Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model)
        menu = New Menu(Of CGAHue)(CGAHue.WHITE, CGAHue.BLACK, Nothing)
        menu.AddChoice("Quit", Function()
                                   controls.Quit()
                                   Return Nothing
                               End Function)
        menu.AddChoice("Also Quit", Function()
                                        controls.Quit()
                                        Return Nothing
                                    End Function)
        menu.AddChoice("Still Quit", Function()
                                         controls.Quit()
                                         Return Nothing
                                     End Function)
    End Sub

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        Dim font = Controls.GetFont(Fonts.RomFont5x7)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, 0), "Main Menu", CGAHue.WHITE)
        menu.Draw(font, pixelSink)
    End Sub

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Dim result As IUI(Of CGAHue) = Nothing
        Select Case cmd
            Case UICommand.DOWN
                result = menu.HandleMenuCommand(MenuCommand.NextItem)
            Case UICommand.UP
                result = menu.HandleMenuCommand(MenuCommand.PreviousItem)
            Case UICommand.GREEN, UICommand.START
                result = menu.HandleMenuCommand(MenuCommand.Choose)
            Case UICommand.RED
                result = menu.HandleMenuCommand(MenuCommand.Cancel)
        End Select
        Return If(result, Me)
    End Function
End Class
