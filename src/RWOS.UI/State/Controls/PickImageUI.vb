Imports RWOS.Model
Imports TGGD.UI

Public Class PickImageUI
    Inherits BaseMenuUI

    Private ReadOnly confirm As Func(Of String, IUI(Of CGAHue))

    Private Sub New(
                    controls As IHostControls,
                    model As IWorldModel,
                    title As String,
                    hue As CGAHue,
                    confirm As Func(Of String, IUI(Of CGAHue)),
                    cancel As Func(Of IUI(Of CGAHue)))
        MyBase.New(controls, model, title, hue, New PickerMenu(cancel))
        Me.confirm = confirm
        _menu.AddChoice("Cancel", cancel)
        For Each imageName In model.Images.Names
            _menu.AddChoice(imageName, PickImage(imageName))
        Next
    End Sub

    Private Function PickImage(imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return confirm(imageName)
               End Function
    End Function

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
                                 confirm As Func(Of String, IUI(Of CGAHue)),
                                 cancel As Func(Of IUI(Of CGAHue))) As Func(Of IUI(Of CGAHue))
        Return Function() New PickImageUI(controls, model, title, hue, confirm, cancel)
    End Function

End Class
