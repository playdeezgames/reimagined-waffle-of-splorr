Imports Terminal.Gui
Imports Terminal.Gui.App
Imports Terminal.Gui.ViewBase
Imports Terminal.Gui.Views
Imports TGGD.UI

Public Module Host
    Public Sub Run(ui As IUI)
        Using app As IApplication = Application.Create()
            app.Init()
            While ui IsNot Nothing
                Using window = New Window With {.Title = ui.Title}
                    Dim previousButton As Button = Nothing
                    For Each choice In ui.Choices
                        Dim button As New Button() With
                        {
                            .Text = choice.Text
                        }
                        If previousButton IsNot Nothing Then
                            button.X = Pos.Right(previousButton)
                        End If
                        previousButton = button
                        AddHandler button.Accepting, Sub(s, e)
                                                         ui = choice.Choose()
                                                         app.RequestStop()
                                                         e.Handled = True
                                                     End Sub
                        window.Add(button)
                    Next
                    app.Run(window)
                End Using
            End While
        End Using
    End Sub
End Module
