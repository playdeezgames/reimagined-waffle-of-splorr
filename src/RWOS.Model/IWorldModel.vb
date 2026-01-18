Public Interface IWorldModel
    Sub Save(filename As String)
    Property ImageName As String
    Property ImageColumns As Integer
    Property ImageRows As Integer
    ReadOnly Property CanCreateImage As Boolean
End Interface
