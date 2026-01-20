Public Interface ILocationTypesModel
    Function Create(locationTypeName As String, imageName As String) As ILocationTypeModel
    Function GetLocationType(locationTypeName As String) As ILocationTypeModel
End Interface
