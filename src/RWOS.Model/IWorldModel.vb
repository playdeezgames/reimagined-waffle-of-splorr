Public Interface IWorldModel
    Sub Save(filename As String)
    ReadOnly Property ImageFilename As String
    Property ImageColumns As Integer
    Property ImageRows As Integer
    ReadOnly Property CanCreateImage As Boolean
End Interface
