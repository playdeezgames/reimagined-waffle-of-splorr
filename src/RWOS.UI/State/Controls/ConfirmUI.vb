Imports RWOS.Model
Imports TGGD.UI

Public Class ConfirmUI
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
    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(
                                 controls As IHostControls,
                                 model As IWorldModel,
                                 title As String,
                                 hue As CGAHue,
                                 confirm As Func(Of IUI(Of CGAHue)),
                                 cancel As Func(Of IUI(Of CGAHue))) As Func(Of IUI(Of CGAHue))
        Return Function() New ConfirmUI(controls, model, title, hue, confirm, cancel)
    End Function
End Class
