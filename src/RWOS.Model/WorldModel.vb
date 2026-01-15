Public Class WorldModel
    Implements IWorldModel
    Const CELL_COLUMNS = 40
    Const CELL_ROWS = 25

    Private player_column As Integer = CELL_COLUMNS \ 2
    Private player_row As Integer = CELL_ROWS \ 2
    Private ReadOnly grid As List(Of CellType) = Enumerable.Repeat(CellType.FLOOR, CELL_COLUMNS * CELL_ROWS).ToList()

    Public ReadOnly Property CellColumns As Integer Implements IWorldModel.CellColumns
        Get
            Return CELL_COLUMNS
        End Get
    End Property

    Public ReadOnly Property CellRows As Integer Implements IWorldModel.CellRows
        Get
            Return CELL_ROWS
        End Get
    End Property

    Private Sub New()
        For Each column In Enumerable.Range(0, CELL_COLUMNS)
            SetCell(column, 0, CellType.WALL)
            SetCell(column, CELL_ROWS - 1, CellType.WALL)
        Next
        For Each row In Enumerable.Range(1, CELL_ROWS - 2)
            SetCell(0, row, CellType.WALL)
            SetCell(CELL_COLUMNS - 1, row, CellType.WALL)
        Next
        SetCell(player_column, player_row, CellType.N00B)
    End Sub

    Private Sub SetCell(column As Integer, row As Integer, cellType As CellType)
        grid(column + row * CELL_COLUMNS) = cellType
    End Sub

    Public Shared Function Create() As IWorldModel
        Return New WorldModel
    End Function

    Public Function GetCell(column As Integer, row As Integer) As CellType Implements IWorldModel.GetCell
        Return grid(column + row * CELL_COLUMNS)
    End Function

    Public Sub Move(direction As Direction) Implements IWorldModel.Move
        SetCell(player_column, player_row, CellType.FLOOR)
        Dim next_column = player_column
        Dim next_row = player_row
        Select Case direction
            Case Direction.North
                next_row -= 1
            Case Direction.East
                next_column += 1
            Case Direction.South
                next_row += 1
            Case Direction.West
                next_column -= 1
        End Select
        If GetCell(next_column, next_row) = CellType.FLOOR Then
            player_column = next_column
            player_row = next_row
            'Controls.PlaySfx(Sfx.PlayerStep)
        Else
            'Controls.PlaySfx(Sfx.HitWall)
        End If
        SetCell(player_column, player_row, CellType.N00B)
    End Sub
End Class
