Imports RWOS.Data

Friend Class PortalsModel
    Implements IPortalsModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IPortalModel) Implements IPortalsModel.All
        Get
            Return data.Portals.Select(Function(x) New PortalModel(data, x.Key))
        End Get
    End Property

    Public Function Create(name As String) As IPortalModel Implements IPortalsModel.Create
        Dim id As Guid = Guid.NewGuid
        data.Portals(id) = New PortalData With
            {
                .Name = name
            }
        Return New PortalModel(data, id)
    End Function
End Class
