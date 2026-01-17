Imports RWOS.Model
Imports TGGD.UI

Friend Class ConfirmQuitUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Are you sure you want to quit?",
            CGAHue.MAGENTA,
            New PickerMenu(MainMenuUI.Launch(controls, model)))
        _menu.AddChoice("No", MainMenuUI.Launch(controls, model))
        _menu.AddChoice("Yes", Function()
                                   controls.Quit()
                                   Return Nothing
                               End Function)
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New ConfirmQuitUI(controls, model)
    End Function
End Class
