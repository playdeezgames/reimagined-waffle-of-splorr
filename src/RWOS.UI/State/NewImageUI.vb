Imports RWOS.Model
Imports TGGD.UI

Public Class NewImageUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "New Image...",
            CGAHue.CYAN,
            New PickerMenu(ImageEditorUI.Launch(controls, model)))
        _menu.AddChoice("Cancel", ImageEditorUI.Launch(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New NewImageUI(controls, model)
    End Function
End Class
