Imports RWOS.Model
Imports TGGD.UI

Friend Class EditPortalMenuUI
    Inherits BaseMenuUI

    Public Sub New(controls As IHostControls, model As IWorldModel, portal As IPortalModel)
        MyBase.New(controls, model, $"Edit {portal.UniqueName}", CGAHue.CYAN, New PickerMenu(EditPortalsMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditPortalsMenuUI.Launch(controls, model))
        _menu.AddChoice("Rename...", RenamePortal(portal))
        If portal.CanDelete Then
            _menu.AddChoice("Delete", DeletePortal(portal))
        End If
    End Sub

    Private Function DeletePortal(portal As IPortalModel) As Func(Of IUI(Of CGAHue))
        Return Function()
                   portal.Delete()
                   Return EditPortalsMenuUI.Launch(Controls, Model).Invoke
               End Function
    End Function

    Private Function RenamePortal(portal As IPortalModel) As Func(Of IUI(Of CGAHue))
        Return TextEditUI.Launch(Controls, Model, "New portal name?", CGAHue.CYAN, portal.Name, DoRenamePortal(portal), Function() Me)
    End Function

    Private Function DoRenamePortal(portal As IPortalModel) As Func(Of String, IUI(Of CGAHue))
        Return Function(name)
                   portal.Name = name
                   Return Launch(Controls, Model, portal).Invoke
               End Function
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, portal As IPortalModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditPortalMenuUI(controls, model, portal)
    End Function
End Class
