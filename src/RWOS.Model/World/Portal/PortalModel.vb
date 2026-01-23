Imports RWOS.Data

Friend Class PortalModel
    Implements IPortalModel

    Public Sub New(data As WorldData, id As Guid)
        Me.data = data
        Me.Id = id
    End Sub

    Private ReadOnly data As WorldData
    Public ReadOnly Property Id As Guid Implements IPortalModel.Id
    Private ReadOnly Property portalData As PortalData
        Get
            Return data.Portals(Id)
        End Get
    End Property

    Public Property Name As String Implements IPortalModel.Name
        Get
            Return portalData.Name
        End Get
        Set(value As String)
            portalData.Name = value
        End Set
    End Property

    Public ReadOnly Property Model As IWorldModel Implements IPortalModel.Model
        Get
            Return New WorldModel(data)
        End Get
    End Property
End Class
