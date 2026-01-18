Imports RWOS.Model
Imports TGGD.UI

Public Class ImageEditListUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Image Editor", CGAHue.CYAN, New PickerMenu(EditorMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditorMenuUI.Launch(controls, model))
        _menu.AddChoice("New Image", NewImageUI.Launch(controls, model))
        For Each imageName In model.ImageNames
            _menu.AddChoice(imageName, EditImage(imageName))
        Next
    End Sub

    Private Function EditImage(imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function() EditImageUI.Launch(Controls, Model, imageName).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New ImageEditListUI(controls, model)
    End Function
End Class
