Public Interface IWorldModel
    ReadOnly Property Images As IImagesModel
    Function Export() As String
    Sub Import(data As String)
End Interface
