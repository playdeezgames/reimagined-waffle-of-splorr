Imports System.Text.Json
Imports RWOS.Data

Public Class WorldModel
    Implements IWorldModel
    Private data As WorldData
    Sub New()
        data = New WorldData
    End Sub

    Public ReadOnly Property Images As IImagesModel Implements IWorldModel.Images
        Get
            Return New ImagesModel(data)
        End Get
    End Property

    Public ReadOnly Property LocationTypes As ILocationTypesModel Implements IWorldModel.LocationTypes
        Get
            Return New LocationTypesModel(data)
        End Get
    End Property

    Public Sub Import(data As String) Implements IWorldModel.Import
        Me.data = JsonSerializer.Deserialize(Of WorldData)(data)
    End Sub

    Public Function Export() As String Implements IWorldModel.Export
        Return JsonSerializer.Serialize(data)
    End Function
End Class
