Imports System.IO
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

    Public Sub Save(filename As String) Implements IWorldModel.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(data))
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
End Class
