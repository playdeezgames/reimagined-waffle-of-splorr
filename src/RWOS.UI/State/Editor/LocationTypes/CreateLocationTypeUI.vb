Imports RWOS.Model
Imports TGGD.UI

Friend Class CreateLocationTypeUI
    Inherits BaseMenuUI
    Private Shared Property LocationTypeName As String = String.Empty
    Private Shared Property ImageName As String = String.Empty
    Private Shared Function CanCreateLocationType(model As IWorldModel) As Boolean
        Return Not String.IsNullOrWhiteSpace(LocationTypeName) AndAlso model.Images.Exists(ImageName)
    End Function


    Private Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model, "Create Location Type", CGAHue.CYAN, New PickerMenu(EditLocationTypesUI.Launch(controls, model)))
        _menu.AddChoice("Go Back", EditLocationTypesUI.Launch(controls, model))
        If CanCreateLocationType(model) Then
            _menu.AddChoice($"Create!", AddressOf CreateLocationType)
        End If
        _menu.AddChoice($"Name: {LocationTypeName}", AddressOf ChangeName)
        _menu.AddChoice($"Image: {ImageName}", AddressOf ChangeImage)
    End Sub

    Private Function CreateLocationType() As IUI(Of CGAHue)
        Model.LocationTypes.Create(LocationTypeName, ImageName)
        Return EditLocationTypeUI.Launch(Controls, Model, LocationTypeName).Invoke
    End Function

    Private Function ChangeImage() As IUI(Of CGAHue)
        Return PickImageUI.Launch(
            Controls,
            Model,
            "Select Image",
            CGAHue.CYAN,
            AddressOf ConfirmImageChange,
            Function() Me).Invoke
    End Function

    Private Function ConfirmImageChange(imageName As String) As IUI(Of CGAHue)
        CreateLocationTypeUI.ImageName = imageName
        Return Launch(Controls, Model).Invoke
    End Function

    Private Function ChangeName() As IUI(Of CGAHue)
        Return TextEditUI.Launch(
            Controls,
            Model,
            "New Value For Name",
            CGAHue.CYAN,
            LocationTypeName,
            AddressOf ConfirmNameChange,
            Function() Me).Invoke
    End Function

    Private Function ConfirmNameChange(newLocationTypeName As String) As IUI(Of CGAHue)
        CreateLocationTypeUI.LocationTypeName = newLocationTypeName
        Return Launch(Controls, Model).Invoke
    End Function

    Protected Overrides ReadOnly Property font As IFont
        Get
            Return Controls.GetFont(Fonts.RomFont5x7)
        End Get
    End Property

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel) As Func(Of IUI(Of CGAHue))
        Return Function() New CreateLocationTypeUI(controls, model)
    End Function
End Class
