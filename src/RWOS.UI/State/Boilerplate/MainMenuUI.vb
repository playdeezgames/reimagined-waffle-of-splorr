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
            New PickerMenu(ConfirmQuitUI.Launch(controls, model)))
        _menu.AddChoice("Edit...", EditorMenuUI.Launch(controls, model))
        _menu.AddChoice("Save...", SaveModel())
        _menu.AddChoice("Quit", ConfirmQuitUI.Launch(controls, model))
    End Sub

    Private Function SaveModel() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(Controls, Model, "Save World As...", CGAHue.CYAN, MainMenuUI.Filename, AddressOf ConfirmSave, AddressOf CancelSave).Invoke
               End Function
    End Function

    Private Function CancelSave() As IUI(Of CGAHue)
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
