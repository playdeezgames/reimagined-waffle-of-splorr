Imports RWOS.Model
Imports TGGD.UI

Friend Class EditLocationTypesUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Location Types", CGAHue.CYAN, New PickerMenu(EditorMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditorMenuUI.Launch(controls, model))
        _menu.AddChoice("New Location Type", CreateLocationTypeUI.Launch(controls, model))
        '_menu.AddChoice("Import Single Location Type...", ImportSingleLocationType(controls, model, Me))
        '_menu.AddChoice("Export All...", ExportAllLocationTypes(controls, model, Me))
        '_menu.AddChoice("Import All...", ImportAllLocationTypes(controls, model, Me))
        'For Each locationTypeName In model.LocationTypes.Names
        '    _menu.AddChoice(locationTypeName, EditLocationType(locationTypeName))
        'Next
    End Sub

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditLocationTypesUI(controls, model)
    End Function

End Class
