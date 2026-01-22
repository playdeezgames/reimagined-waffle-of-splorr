Public Interface IPortalModel
    ReadOnly Property UniqueName As String
    ReadOnly Property CanDelete As Boolean
    Property Name As String
    Sub Delete()
End Interface
