Public Interface IWorldModel
    ReadOnly Property CellColumns As Integer
    ReadOnly Property CellRows As Integer
    Function GetCell(column As Integer, row As Integer) As CellType
    Sub Move(direction As Direction)
End Interface
