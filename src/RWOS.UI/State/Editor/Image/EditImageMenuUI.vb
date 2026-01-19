Imports RWOS.Model
Imports TGGD.UI

Public Class EditImageMenuUI
    Inherits BaseMenuUI

    Private ReadOnly imageName As String
    Private Shared Property Filename As String = "export.json"

    Private Sub New(controls As IHostControls, model As IWorldModel, imageName As String)
        MyBase.New(
            controls,
            model,
            $"Image: {imageName}",
            CGAHue.CYAN,
            New PickerMenu(EditImageUI.Launch(controls, model, imageName)))
        Me.imageName = imageName
        _menu.AddChoice("Done", EditImagesUI.Launch(controls, model))
        _menu.AddChoice("Export...", ExportImage())
        _menu.AddChoice("Duplicate...", DuplicateImage())
        _menu.AddChoice("Delete", ConfirmDeleteImage())
    End Sub

    Private Function ConfirmDeleteImage() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return ConfirmUI.Launch(Controls, Model, "Are you sure you want to delete?", CGAHue.MAGENTA, AddressOf HandleDelete, AddressOf CancelOperation).Invoke
               End Function
    End Function

    Private Function HandleDelete() As IUI(Of CGAHue)
        Model.Images.Delete(imageName)
        Return EditImagesUI.Launch(Controls, Model).Invoke
    End Function

    Private Function DuplicateImage() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(
                        Controls,
                        Model,
                        "Duplicate Image As...",
                        CGAHue.CYAN,
                        imageName,
                        AddressOf HandleDuplicate,
                        AddressOf CancelOperation).Invoke
               End Function
    End Function

    Private Function HandleDuplicate(newImageName As String) As IUI(Of CGAHue)
        Dim imageModel = Model.Images.GetImage(imageName)
        Dim duplicateModel = Model.Images.Create(newImageName, imageModel.Columns, imageModel.Rows)
        For Each x In Enumerable.Range(0, imageModel.Columns)
            For Each y In Enumerable.Range(0, imageModel.Rows)
                duplicateModel.SetPixel(x, y, imageModel.GetPixel(x, y))
            Next
        Next
        Return MessageUI.Launch(Controls, Model, $"Duplicated to '{newImageName}'", Function() Me).Invoke
    End Function

    Private Function ExportImage() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(
                        Controls,
                        Model,
                        "Export Image As...",
                        CGAHue.CYAN,
                        EditImageMenuUI.Filename,
                        AddressOf HandleExport,
                        AddressOf CancelOperation).Invoke
               End Function
    End Function

    Private Function CancelOperation() As IUI(Of CGAHue)
        Return Me
    End Function

    Private Function HandleExport(filename As String) As IUI(Of CGAHue)
        EditImageMenuUI.Filename = filename
        Controls.Save(filename, Model.Images.GetImage(imageName).Export())
        Return MessageUI.Launch(Controls, Model, $"Saved to '{filename}'", Function() Me).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function() New EditImageMenuUI(controls, model, imageName)
    End Function
End Class
