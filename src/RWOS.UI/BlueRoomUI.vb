Imports RWOS.Model
Imports TGGD.UI

Public Class BlueRoomUI
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

    Public Overrides Function HandleCommand(cmd As String) As IUI(Of CGAHue)
        Select Case cmd
            Case "KeyUp", "ButtonDPadUp"
                Model.Move(Direction.North)
            Case "KeyRight", "ButtonDPadRight"
                Model.Move(Direction.East)
            Case "KeyDown", "ButtonDPadDown"
                Model.Move(Direction.South)
            Case "KeyLeft", "ButtonDPadLeft"
                Model.Move(Direction.West)
            Case "ButtonA", "KeySpace"
            Case "ButtonB", "KeyEscape"
                Return New MainMenuUI(Controls, Model)
            Case "ButtonBack", "KeyTab"
            Case "ButtonStart", "KeyEnter"
        End Select
        Return Me
    End Function
End Class
