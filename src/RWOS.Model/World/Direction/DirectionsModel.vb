Imports RWOS.Data

Friend Class DirectionsModel
    Implements IDirectionsModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IDirectionModel) Implements IDirectionsModel.All
        Get
            Return data.Directions.Select(Function(x) New DirectionModel(data, x.Key))
        End Get
    End Property

    Public Function Create(value As String) As IDirectionModel Implements IDirectionsModel.Create
        Dim id = Guid.NewGuid
        data.Directions(id) = New DirectionData With
            {
                .Name = value
            }
        Return New DirectionModel(data, id)
    End Function
End Class
