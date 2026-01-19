Imports RWOS.Model
Imports TGGD.UI

Public MustInherit Class ConfirmUI
    Inherits BaseMenuUI
    Implements IUI(Of CGAHue)

    Protected Sub New(
                     controls As IHostControls,
                     model As IWorldModel,
                     title As String,
                     hue As CGAHue,
                     confirm As Func(Of IUI(Of CGAHue)),
                     cancel As Func(Of IUI(Of CGAHue)))
        MyBase.New(
            controls,
            model,
            title,
            hue,
            New PickerMenu(cancel))
        _menu.AddChoice("No", cancel)
        _menu.AddChoice("Yes", confirm)
    End Sub
End Class
