Imports RWOS.Model
Imports TGGD.UI

Friend Class EditDirectionsMenuUI
    Inherits BaseMenuUI

    Private Sub New(
                  controls As IHostControls,
                  model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Edit Directions",
            CGAHue.CYAN,
            New PickerMenu(EditWorldUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditWorldUI.Launch(controls, model))
        _menu.AddChoice("Create...", AddressOf CreateDirection)
        For Each direction In model.Directions.All
            _menu.AddChoice(direction.UniqueName, EditDirection(direction))
        Next
    End Sub

    Private Function EditDirection(direction As IDirectionModel) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return EditDirectionMenuUI.Launch(Controls, Model, direction).Invoke
               End Function
    End Function

    Private Function CreateDirection() As IUI(Of CGAHue)
        Return TextEditUI.Launch(
            Controls,
            Model,
            "New Direction Name?",
            CGAHue.CYAN,
            String.Empty,
            DoCreateDirection(),
            Function() Me).Invoke
    End Function

    Private Function DoCreateDirection() As Func(Of String, IUI(Of CGAHue))
        Return Function(name)
                   Model.Directions.Create(name)
                   Return EditDirectionsMenuUI.Launch(Controls, Model).Invoke
               End Function
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditDirectionsMenuUI(controls, model)
    End Function

End Class
