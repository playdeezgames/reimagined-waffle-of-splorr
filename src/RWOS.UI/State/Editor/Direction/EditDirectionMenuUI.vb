Imports RWOS.Model
Imports TGGD.UI

Friend Class EditDirectionMenuUI
    Inherits BaseMenuUI

    Public Sub New(controls As IHostControls, model As IWorldModel, direction As IDirectionModel)
        MyBase.New(controls, model, $"Edit {direction.UniqueName}", CGAHue.CYAN, New PickerMenu(EditDirectionsMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditDirectionsMenuUI.Launch(controls, model))
        _menu.AddChoice("Rename...", RenameDirection(direction))
        If direction.CanDelete Then
            _menu.AddChoice("Delete", DeleteDirection(direction))
        End If
    End Sub

    Private Function DeleteDirection(direction As IDirectionModel) As Func(Of IUI(Of CGAHue))
        Return Function()
                   direction.Delete()
                   Return EditDirectionsMenuUI.Launch(Controls, Model).Invoke
               End Function
    End Function

    Private Function RenameDirection(direction As IDirectionModel) As Func(Of IUI(Of CGAHue))
        Return TextEditUI.Launch(Controls, Model, "New direction name?", CGAHue.CYAN, direction.Name, DoRenameDirection(direction), Function() Me)
    End Function

    Private Function DoRenameDirection(direction As IDirectionModel) As Func(Of String, IUI(Of CGAHue))
        Return Function(name)
                   direction.Name = name
                   Return Launch(Controls, Model, direction).Invoke
               End Function
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, direction As IDirectionModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditDirectionMenuUI(controls, model, direction)
    End Function
End Class
