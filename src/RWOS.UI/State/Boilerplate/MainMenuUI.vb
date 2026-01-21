Imports RWOS.Model
Imports TGGD.UI

Public Class MainMenuUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)
    Private Shared Property Filename As String = "output.json"

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Main Menu",
            CGAHue.CYAN,
            New PickerMenu(ConfirmQuit(controls, model)))
        _menu.AddChoice("Edit...", EditWorldUI.Launch(controls, model))
        _menu.AddChoice("Save...", SaveModel())
        _menu.AddChoice("Load...", LoadModel())
        _menu.AddChoice("Quit", ConfirmQuit(controls, model))
    End Sub

    Private Function LoadModel() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(
                        Controls,
                        Model,
                        "Load World From...",
                        CGAHue.CYAN,
                        MainMenuUI.Filename,
                        AddressOf ConfirmLoad,
                        AddressOf CancelOperation).Invoke
               End Function
    End Function

    Private Function ConfirmLoad(filename As String) As IUI(Of CGAHue)
        MainMenuUI.Filename = filename
        Model.Import(Controls.Load(filename))
        Return MessageUI.Launch(Controls, Model, $"Loaded from '{filename}'", Function() Me).Invoke
    End Function

    Private Shared Function ConfirmQuit(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return ConfirmUI.Launch(controls,
            model,
            "Are you sure you want to quit?",
            CGAHue.MAGENTA,
            Function()
                controls.Quit()
                Return Nothing
            End Function,
            MainMenuUI.Launch(controls, model))
    End Function

    Private Function SaveModel() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(Controls, Model, "Save World As...", CGAHue.CYAN, MainMenuUI.Filename, AddressOf ConfirmSave, AddressOf CancelOperation).Invoke
               End Function
    End Function

    Private Function CancelOperation() As IUI(Of CGAHue)
        Return Me
    End Function

    Private Function ConfirmSave(filename As String) As IUI(Of CGAHue)
        MainMenuUI.Filename = filename
        Controls.Save(filename, Model.Export())
        Return MessageUI.Launch(Controls, Model, $"Saved to '{filename}'", Function() Me).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Public Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New MainMenuUI(controls, model)
    End Function
End Class
