Imports System.Text.Json
Imports RWOS.Data
Imports TGGD.Data

Public MustInherit Class WorldModel
    Implements IWorldModel
    Private data As WorldData
    Sub New()
        data = New WorldData
    End Sub

    Public ReadOnly Property Directions As IDirectionsModel Implements IWorldModel.Directions
        Get
            Return New DirectionsModel(data)
        End Get
    End Property

    Public Sub Import(data As String) Implements IWorldModel.Import
        Me.data = JsonSerializer.Deserialize(Of WorldData)(data)
    End Sub

    Public Function Export() As String Implements IWorldModel.Export
        Return JsonSerializer.Serialize(data)
    End Function
End Class
