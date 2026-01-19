Imports RWOS.Model
Imports TGGD.UI

Public Class CreateImageUI
    Inherits BaseMenuUI

    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(
            controls,
            model,
            "New Image...",
            CGAHue.CYAN,
            New PickerMenu(EditImagesUI.Launch(controls, model)))
        _menu.AddChoice("Cancel", EditImagesUI.Launch(controls, model))
        If CanCreateImage Then
            _menu.AddChoice($"Create!", AddressOf CreateImage)
        End If
        _menu.AddChoice($"Name: {ImageName}", AddressOf ChangeName)
        _menu.AddChoice($"Columns: {ImageColumns}", AddressOf ChangeColumns)
        _menu.AddChoice($"Rows: {ImageRows}", AddressOf ChangeRows)
    End Sub

    Private Function ChangeRows() As IUI(Of CGAHue)
        Return NumberEditUI.Launch(Controls, Model, "New Value For Image Rows", CGAHue.CYAN, ImageRows, AddressOf ConfirmRowChange, AddressOf CancelChange).Invoke
    End Function

    Private Function ChangeColumns() As IUI(Of CGAHue)
        Return NumberEditUI.Launch(Controls, Model, "New Value For Image Columns", CGAHue.CYAN, ImageColumns, AddressOf ConfirmColumnChange, AddressOf CancelChange).Invoke
    End Function

    Private Function CancelChange() As IUI(Of CGAHue)
        Return Me
    End Function

    Private Function ConfirmRowChange(newValue As Integer) As IUI(Of CGAHue)
        ImageRows = newValue
        Return New CreateImageUI(Controls, Model)
    End Function

    Private Function ConfirmColumnChange(newValue As Integer) As IUI(Of CGAHue)
        ImageColumns = newValue
        Return New CreateImageUI(Controls, Model)
    End Function

    Private Function ChangeName() As IUI(Of CGAHue)
        Return TextEditUI.Launch(Controls, Model, "New Value For Image Name", CGAHue.CYAN, ImageName, AddressOf ConfirmNameChange, AddressOf CancelChange).Invoke
    End Function

    Private Function ConfirmNameChange(newValue As String) As IUI(Of CGAHue)
        ImageName = newValue
        Return New CreateImageUI(Controls, Model)
    End Function

    Private Function CreateImage() As IUI(Of CGAHue)
        Model.Images.Create(ImageName, ImageColumns, ImageRows)
        Return EditImageUI.Launch(Controls, Model, ImageName).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New CreateImageUI(controls, model)
    End Function

    Private Shared Property ImageName As String = String.Empty
    Private Shared Property ImageColumns As Integer = 0
    Private Shared Property ImageRows As Integer = 0
    Private Shared ReadOnly Property CanCreateImage As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(ImageName) AndAlso ImageColumns > 0 AndAlso ImageRows > 0
        End Get
    End Property
End Class
