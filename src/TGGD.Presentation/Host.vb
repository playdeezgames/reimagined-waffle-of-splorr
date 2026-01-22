Imports Terminal.Gui
Imports Terminal.Gui.App
Imports Terminal.Gui.Configuration
Imports Terminal.Gui.ViewBase
Imports Terminal.Gui.Views
Imports TGGD.UI

Public Module Host
    Public Sub Run(ui As IUI)
        ConfigurationManager.RuntimeConfig = "{ ""Theme"": ""Green Phosphor"" }"
        ConfigurationManager.Enable(ConfigLocations.All)
        Using app As IApplication = Application.Create()
            app.Init()
            While ui IsNot Nothing
                Using window = New Window With {.Title = ui.Title}
                    Dim previousView As View = Nothing
                    For Each line In ui.Lines
                        Dim label As New Label() With
                            {
                                .Text = line
                            }
                        If previousView IsNot Nothing Then
                            label.X = Pos.Left(previousView)
                            label.Y = Pos.Bottom(previousView) + 1
                        Else
                            label.X = 1
                            label.Y = 1
                        End If
                        previousView = label
                        window.Add(label)
                    Next
                    For Each choice In ui.Choices
                        Dim button As New Button() With
                        {
                            .Text = choice.Text
                        }
                        If previousView IsNot Nothing Then
                            button.X = Pos.Left(previousView)
                            button.Y = Pos.Bottom(previousView) + 1
                        Else
                            button.X = 1
                            button.Y = 1
                        End If
                        previousView = button
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
