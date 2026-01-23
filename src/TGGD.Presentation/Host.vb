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
                    Dim x As Pos = 1
                    Dim y As Pos = 1
                    For Each line In ui.Lines
                        Dim label As New Label() With
                            {
                                .Text = line,
                                .X = x,
                                .Y = y
                            }
                        y = Pos.Bottom(label) + 1
                        window.Add(label)
                    Next
                    For Each parameter In ui.Parameters
                        Dim label As New Label() With
                            {
                                .Text = parameter.LabelText,
                                .X = x,
                                .Y = y
                            }
                        y = Pos.Bottom(label) + 1
                        Dim textField As New TextField() With
                            {
                                .X = Pos.Right(label) + 1,
                                .Y = Pos.Top(label),
                                .Width = [Dim].Fill,
                                .Text = parameter.Value
                            }
                        AddHandler textField.TextChanged, Sub(s, e)
                                                              parameter.Value = textField.Text
                                                          End Sub
                        window.Add(label, textField)
                    Next
                    For Each choice In ui.Choices
                        Dim button As New Button() With
                        {
                            .Text = choice.Text,
                            .X = x,
                            .Y = y
                        }
                        y = Pos.Bottom(button) + 1
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
