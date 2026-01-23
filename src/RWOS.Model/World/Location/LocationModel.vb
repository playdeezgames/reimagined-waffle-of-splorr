Imports RWOS.Data

Friend Class LocationModel
    Implements ILocationModel
    Private ReadOnly data As WorldData
    Private ReadOnly Property locationData As LocationData
        Get
            Return data.Locations(Id)
        End Get
    End Property

    Public Sub New(data As WorldData, id As Guid)
        Me.Id = id
        Me.data = data
    End Sub

    Public Sub Delete() Implements ILocationModel.Delete
        data.Locations.Remove(Id)
    End Sub

    Public ReadOnly Property Id As Guid Implements ILocationModel.Id

    Public Property Name As String Implements ILocationModel.Name
        Get
            Return locationData.Name
        End Get
        Set(value As String)
            locationData.Name = value
        End Set
    End Property

    Public ReadOnly Property Model As IWorldModel Implements ILocationModel.Model
        Get
            Return New WorldModel(data)
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements ILocationModel.CanDelete
        Get
            Return True
        End Get
    End Property
End Class
