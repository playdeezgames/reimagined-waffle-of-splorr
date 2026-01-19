Imports System.Text.Json
Imports RWOS.Data
Imports TGGD.Data

Friend Class ImagesModel
    Implements IImagesModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property ImageNames As IEnumerable(Of String) Implements IImagesModel.ImageNames
        Get
            Return data.Images.Keys
        End Get
    End Property

    Public Sub DeleteImage(imageName As String) Implements IImagesModel.DeleteImage
        data.Images.Remove(imageName)
    End Sub

    Public Function CreateImage(name As String, columns As Integer, rows As Integer) As IImageModel Implements IImagesModel.CreateImage
        data.Images(name) = New ImageData With
        {
            .columns = columns,
            .rows = rows,
            .Pixels = Enumerable.Repeat(0, columns * rows).ToArray
        }
        Return GetImage(name)
    End Function

    Public Function GetImage(imageName As String) As IImageModel Implements IImagesModel.GetImage
        Return New ImageModel(data, imageName)
    End Function

    Public Function ImportImage(imageName As String, imageData As String) As IImageModel Implements IImagesModel.ImportImage
        data.Images(imageName) = JsonSerializer.Deserialize(Of ImageData)(imageData)
        Return GetImage(imageName)
    End Function

    Public Function ExportImages() As String Implements IImagesModel.ExportImages
        Return JsonSerializer.Serialize(data.Images)
    End Function
End Class
