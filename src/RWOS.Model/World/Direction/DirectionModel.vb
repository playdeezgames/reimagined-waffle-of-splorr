Imports RWOS.Data

Friend Class DirectionModel
    Implements IDirectionModel

    Private data As WorldData
    Private ReadOnly Property directionData As DirectionData
        Get
            Return data.Directions(Id)
        End Get
    End Property


    Public Sub New(data As WorldData, id As Guid)
        Me.data = data
        Me.id = id
    End Sub

    Public ReadOnly Property Id As Guid Implements IDirectionModel.Id

    Public Property Name As String Implements IDirectionModel.Name
        Get
            Return directionData.Name
        End Get
        Set(value As String)
            directionData.Name = value
        End Set
    End Property

    Public ReadOnly Property Model As IWorldModel Implements IDirectionModel.Model
        Get
            Return New WorldModel(data)
        End Get
    End Property
End Class
