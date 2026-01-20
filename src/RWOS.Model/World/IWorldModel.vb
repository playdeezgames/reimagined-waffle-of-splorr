Public Interface IWorldModel
    ReadOnly Property Images As IImagesModel
    ReadOnly Property LocationTypes As ILocationTypesModel
    Function Export() As String
    Sub Import(data As String)
End Interface
