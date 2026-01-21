Imports System.Text.Json
Imports RWOS.Data

Friend Class LocationTypesModel
    Implements ILocationTypesModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property Names As IEnumerable(Of String) Implements ILocationTypesModel.Names
        Get
            Return data.LocationTypes.Keys
        End Get
    End Property

    Public Sub Import(data As String) Implements ILocationTypesModel.Import
        Me.data.LocationTypes = JsonSerializer.Deserialize(Of Dictionary(Of String, LocationTypeData))(data)
    End Sub

    Public Function Create(locationTypeName As String, imageName As String) As ILocationTypeModel Implements ILocationTypesModel.Create
        data.LocationTypes(locationTypeName) = New LocationTypeData With {.ImageName = imageName}
        Return GetLocationType(locationTypeName)
    End Function

    Public Function GetLocationType(locationTypeName As String) As ILocationTypeModel Implements ILocationTypesModel.GetLocationType
        Return New LocationTypeModel(data, locationTypeName)
    End Function

    Public Function ImportLocationType(locationTypeName As String, data As String) As ILocationTypeModel Implements ILocationTypesModel.ImportLocationType
        Me.data.LocationTypes(locationTypeName) = JsonSerializer.Deserialize(Of LocationTypeData)(data)
        Return GetLocationType(locationTypeName)
    End Function

    Public Function Export() As String Implements ILocationTypesModel.Export
        Return JsonSerializer.Serialize(data.LocationTypes)
    End Function
End Class
