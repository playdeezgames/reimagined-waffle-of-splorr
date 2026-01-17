Imports RWOS.Model
Imports TGGD.UI

Public Class MainMenuUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Public Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Main Menu",
            CGAHue.CYAN,
            New PickerMenu(Function() New ConfirmQuitUI(controls, model)))
        _menu.AddChoice("Quit", Function() New ConfirmQuitUI(controls, model))
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property
End Class
