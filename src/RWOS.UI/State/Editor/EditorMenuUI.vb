Imports RWOS.Model
Imports TGGD.UI

Friend Class EditorMenuUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Editor", CGAHue.CYAN, New PickerMenu(MainMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", MainMenuUI.Launch(controls, model))
        _menu.AddChoice("Images...", ImageEditorUI.Launch(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditorMenuUI(controls, model)
    End Function
End Class
