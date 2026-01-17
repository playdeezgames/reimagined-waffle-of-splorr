Imports RWOS.Model
Imports TGGD.UI

Public Class MainMenuUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Main Menu",
            CGAHue.CYAN,
            New PickerMenu(ConfirmQuitUI.Launch(controls, model)))
        _menu.AddChoice("Editor", EditorMenuUI.Launch(controls, model))
        _menu.AddChoice("Quit", ConfirmQuitUI.Launch(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Public Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New MainMenuUI(controls, model)
    End Function
End Class
