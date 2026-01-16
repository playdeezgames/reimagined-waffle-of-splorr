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

    Public Overrides Function HandleCommand(cmd As String) As IUI(Of CGAHue)
        Select Case cmd
            Case "KeyUp", "ButtonDPadUp"
                Return If(menu.HandleCommand(MenuCommand.PreviousItem), Me)
            Case "KeyDown", "ButtonDPadDown"
                Return If(menu.HandleCommand(MenuCommand.NextItem), Me)
            Case "ButtonA", "KeySpace"
                Return If(menu.HandleCommand(MenuCommand.Choose), Me)
            Case "ButtonB", "KeyEscape"
                Return If(menu.HandleCommand(MenuCommand.Cancel), Me)
        End Select
        Return Me
    End Function
End Class
