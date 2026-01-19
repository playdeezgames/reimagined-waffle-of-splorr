Public Interface IImagesModel
    Function Create(name As String, columns As Integer, rows As Integer) As IImageModel
    Function GetImage(imageName As String) As IImageModel
    ReadOnly Property Names As IEnumerable(Of String)
    Sub Delete(imageName As String)
    Function ImportImage(imageName As String, imageData As String) As IImageModel
    Function Export() As String
End Interface
