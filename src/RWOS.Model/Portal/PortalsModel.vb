Imports RWOS.Data

Friend Class PortalsModel
    Implements IPortalsModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IPortalModel) Implements IPortalsModel.All
        Get
            Return Enumerable.Range(0, data.Portals.Count).Select(Function(x) New PortalModel(data, x))
        End Get
    End Property

    Public Function Create(name As String) As IPortalModel Implements IPortalsModel.Create
        Dim portalId = data.Portals.Count
        data.Portals.Add(New PortalData With {.name = name})
        Return New PortalModel(data, directionId)
    End Function
End Class
