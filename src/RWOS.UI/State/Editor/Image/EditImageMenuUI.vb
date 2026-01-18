Imports RWOS.Model
Imports TGGD.UI

Public Class EditImageMenuUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel, imageName As String)
        MyBase.New(
            controls,
            model,
            $"Image: {imageName}",
            CGAHue.CYAN,
            New PickerMenu(EditImageUI.Launch(controls, model, imageName)))
        _menu.AddChoice("Done", ImageEditListUI.Launch(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function() New EditImageMenuUI(controls, model, imageName)
    End Function
End Class
