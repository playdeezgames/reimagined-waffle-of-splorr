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
        _menu.AddChoice("Done", ImageEditListUI.Launch(controls, model))
        _menu.AddChoice("Export...", ExportImage())
    End Sub

    Private Function ExportImage() As Func(Of IUI(Of CGAHue))
        Return Function()
                   Return TextEditUI.Launch(
                        Controls,
                        Model,
                        "Export Image As...",
                        CGAHue.CYAN,
                        EditImageMenuUI.Filename,
                        AddressOf HandleExport,
                        AddressOf CancelExport).Invoke
               End Function
    End Function

    Private Function CancelExport() As IUI(Of CGAHue)
        Return Me
    End Function

    Private Function HandleExport(filename As String) As IUI(Of CGAHue)
        EditImageMenuUI.Filename = filename
        Controls.Save(filename, Model.GetImage(imageName).Export())
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
