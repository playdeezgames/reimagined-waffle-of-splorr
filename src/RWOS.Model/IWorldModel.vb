Public Interface IWorldModel
    Sub Save(filename As String)
    Function CreateImage() As IImageModel
    Function GetImage(imageName As String) As IImageModel
    ReadOnly Property ImageNames As IEnumerable(Of String)
    Property ImageName As String
    Property ImageColumns As Integer
    Property ImageRows As Integer
    ReadOnly Property CanCreateImage As Boolean
End Interface
