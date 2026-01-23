Public Interface IPortalModel
    ReadOnly Property Id As Guid
    Property Name As String
    ReadOnly Property Model As IWorldModel
    Sub Delete()
    ReadOnly Property CanDelete As Boolean
End Interface
