Public Interface IWorldModel
    ReadOnly Property Directions As IDirectionsModel
    Function Export() As String
    Sub Import(data As String)
End Interface
