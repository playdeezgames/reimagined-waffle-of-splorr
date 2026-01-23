Public Interface IDirectionModel
    ReadOnly Property Id As Guid
    Property Name As String
    ReadOnly Property Model As IWorldModel
End Interface
