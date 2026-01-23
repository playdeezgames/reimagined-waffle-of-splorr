Imports System.Text.Json
Imports RWOS.Data

Public Class WorldModel
    Implements IWorldModel
    Private data As WorldData
    Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property Directions As IDirectionsModel Implements IWorldModel.Directions
        Get
            Return New DirectionsModel(data)
        End Get
    End Property

    Public ReadOnly Property Portals As IPortalsModel Implements IWorldModel.Portals
        Get
            Return New PortalsModel(data)
        End Get
    End Property

    Public ReadOnly Property Locations As ILocationsModel Implements IWorldModel.Locations
        Get
            Return New LocationsModel(data)
        End Get
    End Property

    Public Sub Import(data As String) Implements IWorldModel.Import
        Me.data = JsonSerializer.Deserialize(Of WorldData)(data)
    End Sub

    Public Function Export() As String Implements IWorldModel.Export
        Return JsonSerializer.Serialize(data)
    End Function
End Class
