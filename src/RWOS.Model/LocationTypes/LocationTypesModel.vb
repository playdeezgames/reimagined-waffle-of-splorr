Imports RWOS.Data

Friend Class LocationTypesModel
    Implements ILocationTypesModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public Function Create(locationTypeName As String, imageName As String) As ILocationTypeModel Implements ILocationTypesModel.Create
        data.LocationTypes(locationTypeName) = New LocationTypeData With {.imageName = imageName}
        Return GetLocationType(locationTypeName)
    End Function

    Public Function GetLocationType(locationTypeName As String) As ILocationTypeModel Implements ILocationTypesModel.GetLocationType
        Return New LocationTypeModel(data, locationTypeName)
    End Function
End Class
