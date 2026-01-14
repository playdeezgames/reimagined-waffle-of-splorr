Imports TGGD.UI

Public Class RWOSUI
    Inherits BaseUI(Of CGAHue)
    Const CELL_COLUMNS = 40
    Const CELL_ROWS = 25
    Const CELL_WIDTH = 8
    Const CELL_HEIGHT = 8

    Private player_column As Integer = CELL_COLUMNS \ 2
    Private player_row As Integer = CELL_ROWS \ 2
    Private ReadOnly grid As List(Of CGAHue) = Enumerable.Repeat(CGAHue.BLACK, CELL_COLUMNS * CELL_ROWS).ToList()
    Private ReadOnly _settings As IHostSettings
    Sub New(settings As IHostSettings)
        Me._settings = settings
        For Each column In Enumerable.Range(0, CELL_COLUMNS)
            SetCell(column, 0, CGAHue.CYAN)
            SetCell(column, CELL_ROWS - 1, CGAHue.CYAN)
        Next
        For Each row In Enumerable.Range(1, CELL_ROWS - 2)
            SetCell(0, row, CGAHue.CYAN)
            SetCell(CELL_COLUMNS - 1, row, CGAHue.CYAN)
        Next
        SetCell(player_column, player_row, CGAHue.MAGENTA)
    End Sub

    Private Sub SetCell(column As Integer, row As Integer, hue As CGAHue)
        grid(column + row * CELL_COLUMNS) = hue
    End Sub

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        For Each column In Enumerable.Range(0, CELL_COLUMNS)
            For Each row In Enumerable.Range(0, CELL_ROWS)
                pixelSink.Fill(column * CELL_WIDTH, row * CELL_HEIGHT, CELL_WIDTH, CELL_HEIGHT, GetCell(column, row))
            Next
        Next
    End Sub

    Private Function GetCell(column As Integer, row As Integer) As CGAHue
        Return grid(column + row * CELL_COLUMNS)
    End Function

    Public Overrides Sub HandleCommand(cmd As String)
        SetCell(player_column, player_row, CGAHue.BLACK)
        Dim next_column = player_column
        Dim next_row = player_row
        Select Case cmd
            Case "KeyUp", "ButtonDPadUp"
                next_row -= 1
            Case "KeyRight", "ButtonDPadRight"
                next_column += 1
            Case "KeyDown", "ButtonDPadDown"
                next_row += 1
            Case "KeyLeft", "ButtonDPadLeft"
                next_column -= 1
        End Select
        If GetCell(next_column, next_row) = CGAHue.BLACK Then
            player_column = next_column
            player_row = next_row
        End If
        SetCell(player_column, player_row, CGAHue.MAGENTA)
    End Sub
End Class
