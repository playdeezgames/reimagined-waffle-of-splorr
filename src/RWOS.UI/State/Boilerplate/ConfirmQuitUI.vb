Imports RWOS.Model
Imports TGGD.UI

Friend Class ConfirmQuitUI
    Inherits ConfirmUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Are you sure you want to quit?",
            CGAHue.MAGENTA,
            Function()
                controls.Quit()
                Return Nothing
            End Function,
            MainMenuUI.Launch(controls, model))
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
