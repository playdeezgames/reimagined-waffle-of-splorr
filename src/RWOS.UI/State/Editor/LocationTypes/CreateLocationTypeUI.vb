Imports RWOS.Model
Imports TGGD.UI

Friend Class CreateLocationTypeUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Create Location Type", CGAHue.CYAN, New PickerMenu(EditLocationTypesUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditLocationTypesUI.Launch(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New CreateLocationTypeUI(controls, model)
    End Function

End Class
