Imports RWOS.Data

Friend Class DirectionModel
    Implements IDirectionModel

    Private ReadOnly data As WorldData
    Private ReadOnly directionId As Integer
    Private ReadOnly Property directionData As DirectionData
        Get
            Return data.Directions(directionId)
        End Get
    End Property

    Public Sub New(data As WorldData, directionId As Integer)
        Me.data = data
        Me.directionId = directionId
    End Sub

    Public Sub Delete() Implements IDirectionModel.Delete
        data.Directions.RemoveAt(directionId)
    End Sub

    Public ReadOnly Property UniqueName As String Implements IDirectionModel.UniqueName
        Get
            Return $"{directionData.Name}(#{directionId})"
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IDirectionModel.CanDelete
        Get
            Return directionId = data.Directions.Count - 1
        End Get
    End Property

    Public Property Name As String Implements IDirectionModel.Name
        Get
            Return directionData.Name
        End Get
        Set(value As String)
            directionData.Name = value
        End Set
    End Property
End Class
