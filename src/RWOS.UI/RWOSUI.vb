Imports TGGD.UI

Public Class RWOSUI
    Inherits BaseUI(Of CGAHue)

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        For Each row In Enumerable.Range(0, pixelSink.Rows)
            pixelSink.Fill(row, row, 1, 1, CGAHue.CYAN)
            pixelSink.Fill(row, pixelSink.Rows - 1 - row, 1, 1, CGAHue.MAGENTA)
        Next
    End Sub
End Class
