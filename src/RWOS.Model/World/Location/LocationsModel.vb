Imports RWOS.Data

Friend Class LocationsModel
    Implements ILocationsModel

    Private data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property All As IEnumerable(Of ILocationModel) Implements ILocationsModel.All
        Get
            Return data.Locations.Keys.Select(Function(x) New LocationModel(data, x))
        End Get
    End Property

    Public Function Create(name As String) As ILocationModel Implements ILocationsModel.Create
        Dim id As Guid = Guid.NewGuid
        data.Locations(id) = New LocationData With {
            .Name = name
            }
        Return New LocationModel(data, id)
    End Function
End Class
