Imports RWOS.Data

Friend Class DirectionsModel
    Implements IDirectionsModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IDirectionModel) Implements IDirectionsModel.All
        Get
            Return Enumerable.Range(0, data.Directions.Count).Select(Function(x) New DirectionModel(data, x))
        End Get
    End Property

    Public Function Create(name As String) As IDirectionModel Implements IDirectionsModel.Create
        Dim directionId = data.Directions.Count
        data.Directions.Add(New DirectionData With {.Name = name})
        Return New DirectionModel(data, directionId)
    End Function
End Class
