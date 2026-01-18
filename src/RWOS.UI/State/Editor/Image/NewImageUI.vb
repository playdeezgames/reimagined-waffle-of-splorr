Imports RWOS.Model
Imports TGGD.UI

Public Class NewImageUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "New Image...",
            CGAHue.CYAN,
            New PickerMenu(ImageEditorUI.Launch(controls, model)))
        _menu.AddChoice("Cancel", ImageEditorUI.Launch(controls, model))
        If model.CanCreateImage Then
            _menu.AddChoice($"Create!", AddressOf CreateImage)
        End If
        _menu.AddChoice($"Name: {model.ImageName}", AddressOf ChangeName)
        _menu.AddChoice($"Columns: {model.ImageColumns}", AddressOf ChangeColumns)
        _menu.AddChoice($"Rows: {model.ImageRows}", AddressOf ChangeRows)
    End Sub

    Private Function ChangeRows() As IUI(Of CGAHue)
        Return NumberEditUI.Launch(Controls, Model, "New Value For Image Rows", CGAHue.CYAN, Model.ImageRows, AddressOf ConfirmRowChange, AddressOf CancelChange).Invoke
    End Function

    Private Function ChangeColumns() As IUI(Of CGAHue)
        Return NumberEditUI.Launch(Controls, Model, "New Value For Image Columns", CGAHue.CYAN, Model.ImageColumns, AddressOf ConfirmColumnChange, AddressOf CancelChange).Invoke
    End Function

    Private Function CancelChange() As IUI(Of CGAHue)
        Return Me
    End Function

    Private Function ConfirmRowChange(newValue As Integer) As IUI(Of CGAHue)
        Model.ImageRows = newValue
        Return New NewImageUI(Controls, Model)
    End Function

    Private Function ConfirmColumnChange(newValue As Integer) As IUI(Of CGAHue)
        Model.ImageColumns = newValue
        Return New NewImageUI(Controls, Model)
    End Function

    Private Function ChangeName() As IUI(Of CGAHue)
        Return TextEditUI.Launch(Controls, Model, "New Value For Image Name", CGAHue.CYAN, Model.ImageName, AddressOf ConfirmNameChange, AddressOf CancelChange).Invoke
    End Function

    Private Function ConfirmNameChange(newValue As String) As IUI(Of CGAHue)
        Model.ImageName = newValue
        Return New NewImageUI(Controls, Model)
    End Function

    Private Function CreateImage() As IUI(Of CGAHue)
        Model.CreateImage()
        Return EditImageUI.Launch(Controls, Model, Model.ImageName).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New NewImageUI(controls, model)
    End Function
End Class
