Imports System.Text.Json
Imports RWOS.Data
Imports TGGD.Data

Public MustInherit Class WorldModel
    Implements IWorldModel
    ReadOnly data As WorldData
    Sub New()
        data = New WorldData
    End Sub

    Public ReadOnly Property Images As IImagesModel Implements IWorldModel.Images
        Get
            Return New ImagesModel(data)
        End Get
    End Property

    Protected MustOverride Sub HandleCue(cue As Cues)

    Public Function Export() As String Implements IWorldModel.Export
        Return JsonSerializer.Serialize(data)
    End Function
End Class
