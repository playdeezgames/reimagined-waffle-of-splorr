Imports RWOS.Model
Imports TGGD.UI

Public Class EditImagesUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Image Editor", CGAHue.CYAN, New PickerMenu(EditorMenuUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditorMenuUI.Launch(controls, model))
        _menu.AddChoice("New Image", CreateImageUI.Launch(controls, model))
        _menu.AddChoice("Import Single Image...", ImportSingleImage(controls, model, Me))
        _menu.AddChoice("Export All...", ExportAllImages(controls, model, Me))
        _menu.AddChoice("Import All...", ImportAllImages(controls, model, Me))
        For Each imageName In model.Images.Names
            _menu.AddChoice(imageName, EditImage(imageName))
        Next
    End Sub

    Private Function ImportAllImages(controls As IHostControls, model As IWorldModel, ui As EditImagesUI) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(controls, model, "Import All Images From...", CGAHue.CYAN, String.Empty, HandleImportAll(controls, model), Function() ui).Invoke
               End Function
    End Function

    Private Function HandleImportAll(controls As IHostControls, model As IWorldModel) As Func(Of String, IUI(Of CGAHue))
        Return Function(filename)
                   model.Images.Import(controls.Load(filename))
                   Return EditImagesUI.Launch(controls, model).Invoke
               End Function
    End Function

    Private Function ExportAllImages(controls As IHostControls, model As IWorldModel, ui As IUI(Of CGAHue)) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(controls, model, "Export All Images To...", CGAHue.CYAN, String.Empty, HandleExportAll(controls, model), Function() ui).Invoke
               End Function
    End Function

    Private Function HandleExportAll(controls As IHostControls, model As IWorldModel) As Func(Of String, IUI(Of CGAHue))
        Return Function(filename)
                   controls.Save(filename, model.Images.Export())
                   Return EditImagesUI.Launch(controls, model).Invoke
               End Function
    End Function

    Private Shared Function ImportSingleImage(controls As IHostControls, model As IWorldModel, ui As IUI(Of CGAHue)) As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(controls, model, "Import Image From...", CGAHue.CYAN, String.Empty, HandleImport(controls, model, ui), Function() ui).Invoke
               End Function
    End Function

    Private Shared Function HandleImport(controls As IHostControls, model As IWorldModel, ui As IUI(Of CGAHue)) As Func(Of String, IUI(Of CGAHue))
        Return Function(filename)
                   Return TextEditUI.Launch(controls, model, "Imported Image Name...", CGAHue.CYAN, String.Empty, HandleImport2(controls, model, filename), Function() ui).Invoke
               End Function
    End Function

    Private Shared Function HandleImport2(controls As IHostControls, model As IWorldModel, filename As String) As Func(Of String, IUI(Of CGAHue))
        Return Function(imageName)
                   model.Images.ImportImage(imageName, controls.Load(filename))
                   Return EditImageUI.Launch(controls, model, imageName).Invoke
               End Function
    End Function

    Private Function EditImage(imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function() EditImageUI.Launch(Controls, Model, imageName).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New EditImagesUI(controls, model)
    End Function
End Class
