Public Interface ILocationTypesModel
    Function Create(locationTypeName As String, imageName As String) As ILocationTypeModel
    Function GetLocationType(locationTypeName As String) As ILocationTypeModel
    ReadOnly Property Names As IEnumerable(Of String)
    Function ImportLocationType(locationTypeName As String, data As String) As ILocationTypeModel
    Sub Import(data As String)
    Function Export() As String
End Interface
