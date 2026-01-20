Imports System.Text.Json
Imports RWOS.Data
Imports TGGD.Data

Friend Class ImagesModel
    Implements IImagesModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property Names As IEnumerable(Of String) Implements IImagesModel.Names
        Get
            Return data.Images.Keys
        End Get
    End Property

    Public Sub Delete(imageName As String) Implements IImagesModel.Delete
        data.Images.Remove(imageName)
    End Sub

    Public Sub Import(data As String) Implements IImagesModel.Import
        Me.data.Images = JsonSerializer.Deserialize(Of Dictionary(Of String, ImageData))(data)
    End Sub

    Public Function Create(name As String, columns As Integer, rows As Integer) As IImageModel Implements IImagesModel.Create
        data.Images(name) = New ImageData With
        {
            .Columns = columns,
            .Rows = rows,
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

    Public Function Export() As String Implements IImagesModel.Export
        Return JsonSerializer.Serialize(data.Images)
    End Function

    Public Function Exists(imageName As String) As Boolean Implements IImagesModel.Exists
        Return data.Images.ContainsKey(imageName)
    End Function
End Class
