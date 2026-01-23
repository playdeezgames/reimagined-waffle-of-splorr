Public Interface IDirectionModel
    ReadOnly Property Id As Guid
    Property Name As String
    ReadOnly Property Model As IWorldModel
    ReadOnly Property CanDelete As Boolean
    Sub Delete()
End Interface
