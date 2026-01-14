Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports RWOS.UI
Imports TGGD.UI

Friend Class DisplayBuffer
    Implements IPixelSink(Of CGAHue)
    Private ReadOnly texture As Texture2D
    Private ReadOnly buffer As Color()
    Private Shared ReadOnly hueTable As IReadOnlyDictionary(Of CGAHue, Color) =
        New Dictionary(Of CGAHue, Color) From
        {
            {CGAHue.BLACK, Color.Black},
            {CGAHue.CYAN, Color.Cyan},
            {CGAHue.MAGENTA, Color.Magenta},
            {CGAHue.WHITE, Color.White}
        }
    Friend Sub New(texture As Texture2D)
        Me.texture = texture
        Columns = texture.Width
        Rows = texture.Height
        buffer = Enumerable.Repeat(Color.Black, Columns * Rows).ToArray
    End Sub

    Public ReadOnly Property Columns As Integer Implements IPixelSink(Of CGAHue).Columns

    Public ReadOnly Property Rows As Integer Implements IPixelSink(Of CGAHue).Rows

    Public Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As CGAHue) Implements IPixelSink(Of CGAHue).Fill
        For Each r In Enumerable.Range(row, rows)
            If r >= 0 AndAlso r < Me.Rows Then
                For Each c In Enumerable.Range(column, columns)
                    If c >= 0 AndAlso c < Me.Columns Then
                        buffer(c + r * Me.Columns) = hueTable(hue)
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub Commit() Implements IPixelSink(Of CGAHue).Commit
        texture.SetData(Of Color)(buffer)
    End Sub
End Class
