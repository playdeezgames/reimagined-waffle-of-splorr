Imports RWOS.Model
Imports TGGD.UI

Friend Class BlueRoomUI
    Inherits BaseRWOSUI
    Const CELL_WIDTH = 8
    Const CELL_HEIGHT = 8

    Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model)
    End Sub

    Private ReadOnly cellTable As IReadOnlyDictionary(Of CellType, CGAHue) =
        New Dictionary(Of CellType, CGAHue) From
        {
            {CellType.FLOOR, CGAHue.BLACK},
            {CellType.WALL, CGAHue.CYAN},
            {CellType.N00B, CGAHue.MAGENTA}
        }

    Public Overrides Sub Update(
                               pixelSink As IPixelSink(Of CGAHue),
                               elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        For Each column In Enumerable.Range(0, Model.CellColumns)
            For Each row In Enumerable.Range(0, Model.CellRows)
                pixelSink.Fill(column * CELL_WIDTH, row * CELL_HEIGHT, CELL_WIDTH, CELL_HEIGHT, cellTable(Model.GetCell(column, row)))
            Next
        Next
    End Sub

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Select Case cmd
            Case UICommand.UP
                Model.Move(Direction.North)
            Case UICommand.RIGHT
                Model.Move(Direction.East)
            Case UICommand.DOWN
                Model.Move(Direction.South)
            Case UICommand.LEFT
                Model.Move(Direction.West)
            Case UICommand.RED, UICommand.BACK
                Return New MainMenuUI(Controls, Model)
        End Select
        Return Me
    End Function
End Class
