Imports RWOS.Model
Imports TGGD.UI

Friend Class MainMenuUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Public Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            New Menu(Of CGAHue)(CGAHue.WHITE, CGAHue.BLACK, Function() New BlueRoomUI(controls, model)))
        menu.AddChoice("Quit", Function()
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
