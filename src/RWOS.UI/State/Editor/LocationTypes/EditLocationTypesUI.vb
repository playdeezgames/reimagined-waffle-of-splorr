Imports RWOS.Model
Imports TGGD.UI

Friend Class EditLocationTypesUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Location Types", CGAHue.CYAN, New PickerMenu(EditorMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditorMenuUI.Launch(controls, model))
        _menu.AddChoice("New Location Type", CreateLocationTypeUI.Launch(controls, model))
        _menu.AddChoice("Import Single Location Type...", ImportSingleLocationType(controls, model, Me))
        _menu.AddChoice("Export All...", ExportAllLocationTypes(controls, model, Me))
        _menu.AddChoice("Import All...", ImportAllLocationTypes(controls, model, Me))
        For Each locationTypeName In model.LocationTypes.Names
            _menu.AddChoice(locationTypeName, EditLocationType(locationTypeName))
        Next
    End Sub

    Private Function ImportAllLocationTypes(controls As IHostControls, model As IWorldModel, ui As EditLocationTypesUI) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(controls, model, "Import All Location Types From...", CGAHue.CYAN, String.Empty, HandleImportAll(controls, model), Function() ui).Invoke
               End Function
    End Function

    Private Function HandleImportAll(controls As IHostControls, model As IWorldModel) As Func(Of String, IUI(Of CGAHue))
        Return Function(filename)
                   model.LocationTypes.Import(controls.Load(filename))
                   Return EditLocationTypesUI.Launch(controls, model).Invoke
               End Function
    End Function

    Private Function ExportAllLocationTypes(controls As IHostControls, model As IWorldModel, ui As EditLocationTypesUI) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(controls, model, "Export All Location Types To...", CGAHue.CYAN, String.Empty, HandleExportAll(controls, model), Function() ui).Invoke
               End Function
    End Function

    Private Function HandleExportAll(controls As IHostControls, model As IWorldModel) As Func(Of String, IUI(Of CGAHue))
        Return Function(filename)
                   controls.Save(filename, model.LocationTypes.Export())
                   Return EditLocationTypesUI.Launch(controls, model).Invoke
               End Function
    End Function

    Private Shared Function ImportSingleLocationType(controls As IHostControls, model As IWorldModel, ui As IUI(Of CGAHue)) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(controls, model, "Import Location Type From...", CGAHue.CYAN, String.Empty, HandleImport(controls, model, ui), Function() ui).Invoke
               End Function
    End Function

    Private Shared Function HandleImport(controls As IHostControls, model As IWorldModel, ui As IUI(Of CGAHue)) As Func(Of String, IUI(Of CGAHue))
        Return Function(filename)
                   Return TextEditUI.Launch(controls, model, "Imported Location Type Name...", CGAHue.CYAN, String.Empty, HandleImport2(controls, model, filename), Function() ui).Invoke
               End Function
    End Function

    Private Shared Function HandleImport2(controls As IHostControls, model As IWorldModel, filename As String) As Func(Of String, IUI(Of CGAHue))
        Return Function(locationTypeName)
                   model.LocationTypes.ImportLocationType(locationTypeName, controls.Load(filename))
                   Return EditLocationTypeUI.Launch(controls, model, locationTypeName).Invoke
               End Function
    End Function

    Private Function EditLocationType(locationTypeName As String) As Func(Of IUI(Of CGAHue))
        Return Function() EditLocationTypeUI.Launch(Controls, Model, locationTypeName).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditLocationTypesUI(controls, model)
    End Function

End Class
