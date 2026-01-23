Public Interface IWorldModel
    ReadOnly Property Directions As IDirectionsModel
    ReadOnly Property Portals As IPortalsModel
    ReadOnly Property Locations As ILocationsModel
    Function Export() As String
    Sub Import(data As String)
End Interface
