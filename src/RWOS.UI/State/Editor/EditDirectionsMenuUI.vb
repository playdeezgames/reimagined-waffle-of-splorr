Imports RWOS.Model
Imports TGGD.UI

Friend Class EditDirectionsMenuUI
    Inherits BaseMenuUI

    Friend Sub New(
                  controls As IHostControls,
                  model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Edit Directions",
            CGAHue.CYAN,
            New PickerMenu(EditWorldUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditWorldUI.Launch(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditDirectionsMenuUI(controls, model)
    End Function

End Class
