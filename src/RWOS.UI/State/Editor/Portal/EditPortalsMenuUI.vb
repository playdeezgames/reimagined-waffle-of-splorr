Imports RWOS.Model
Imports TGGD.UI

Friend Class EditPortalsMenuUI
    Inherits BaseMenuUI

    Private Sub New(
                  controls As IHostControls,
                  model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "Edit Portals",
            CGAHue.CYAN,
            New PickerMenu(EditWorldUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditWorldUI.Launch(controls, model))
        _menu.AddChoice("Create...", AddressOf CreatePortal)
        For Each portal In model.Portals.All
            _menu.AddChoice(portal.UniqueName, EditPortal(portal))
        Next
    End Sub

    Private Function EditPortal(portal As IPortalModel) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return EditPortalMenuUI.Launch(Controls, Model, portal).Invoke
               End Function
    End Function

    Private Function CreatePortal() As IUI(Of CGAHue)
        Return TextEditUI.Launch(
            Controls,
            Model,
            "New Portal Name?",
            CGAHue.CYAN,
            String.Empty,
            DoCreatePortal(),
            Function() Me).Invoke
    End Function

    Private Function DoCreatePortal() As Func(Of String, IUI(Of CGAHue))
        Return Function(name)
                   Model.Portals.Create(name)
                   Return EditPortalsMenuUI.Launch(Controls, Model).Invoke
               End Function
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditPortalsMenuUI(controls, model)
    End Function

End Class
