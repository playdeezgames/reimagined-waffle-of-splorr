Imports System.Text.Json
Imports RWOS.Data
Imports TGGD.Data

Public MustInherit Class WorldModel
    Implements IWorldModel
    ReadOnly data As WorldData
    Sub New()
        data = New WorldData
    End Sub

    Public ReadOnly Property ImageNames As IEnumerable(Of String) Implements IWorldModel.ImageNames
        Get
            Return data.Images.Keys
        End Get
    End Property

    Public Sub DeleteImage(imageName As String) Implements IWorldModel.DeleteImage
        data.Images.Remove(imageName)
    End Sub

    Protected MustOverride Sub HandleCue(cue As Cues)

    Public Function CreateImage(name As String, columns As Integer, rows As Integer) As IImageModel Implements IWorldModel.CreateImage
        data.Images(name) = New ImageData With
        {
            .Columns = columns,
            .Rows = rows,
            .Pixels = Enumerable.Repeat(0, columns * rows).ToArray
        }
        Return GetImage(name)
    End Function

    Public Function GetImage(imageName As String) As IImageModel Implements IWorldModel.GetImage
        Return New ImageModel(data, imageName)
    End Function

    Public Function Export() As String Implements IWorldModel.Export
        Return JsonSerializer.Serialize(data)
    End Function

    Public Function ImportImage(imageName As String, imageData As String) As IImageModel Implements IWorldModel.ImportImage
        data.Images(imageName) = JsonSerializer.Deserialize(Of ImageData)(imageData)
        Return GetImage(imageName)
    End Function
End Class
