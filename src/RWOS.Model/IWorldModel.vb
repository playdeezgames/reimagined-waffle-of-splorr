Public Interface IWorldModel
    Function CreateImage(name As String, columns As Integer, rows As Integer) As IImageModel
    Function GetImage(imageName As String) As IImageModel
    ReadOnly Property ImageNames As IEnumerable(Of String)
    Function Export() As String
End Interface
