Imports RWOS.Data

Friend Class PortalModel
    Implements IPortalModel
    Private data As WorldData
    Private portalId As Integer
    Private ReadOnly Property portalData As PortalData
        Get
            Return data.Portals(portalId)
        End Get
    End Property

    Public Sub New(data As WorldData, portalId As Integer)
        Me.data = data
        Me.portalId = portalId
    End Sub

    Public ReadOnly Property UniqueName As String Implements IPortalModel.UniqueName
        Get
            Return $"{Name}(#{portalId})"
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IPortalModel.CanDelete
        Get
            Return portalId = data.Portals.Count - 1
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

    Public Sub Delete() Implements IPortalModel.Delete
        Throw New NotImplementedException()
    End Sub
End Class
