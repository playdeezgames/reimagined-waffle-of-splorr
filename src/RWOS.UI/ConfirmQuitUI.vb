Imports RWOS.Model
Imports TGGD.UI

Friend Class ConfirmQuitUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Public Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            New Menu(Of CGAHue)(CGAHue.WHITE, CGAHue.BLACK, Function() New MainMenuUI(controls, model)))
        menu.AddChoice("No", Function() New MainMenuUI(controls, model))
        menu.AddChoice("Yes", Function()
                                  controls.Quit()
                                  Return Nothing
                              End Function)
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property
End Class
