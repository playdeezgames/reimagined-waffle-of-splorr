Imports System.Diagnostics.Contracts
Imports RWOS.Model
Imports TGGD.UI

Public Class EditImageUI
    Inherits BaseRWOSUI

    'TODO: make this static?
    Private ReadOnly imageName As String

    Private Sub New(controls As IHostControls, model As IWorldModel, imageName As String)
        MyBase.New(controls, model)
        Me.imageName = imageName
    End Sub

    Private ReadOnly Property Image As IImageModel
        Get
            Return Model.Images.GetImage(imageName)
        End Get
    End Property

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        Column = Column Mod Image.Columns
        Row = Row Mod Image.Rows
        ShowImage(pixelSink)
        ShowCursor(pixelSink)
        ShowStats(pixelSink)
    End Sub

    Private Sub ShowCursor(pixelSink As IPixelSink(Of CGAHue))
        Dim x = (pixelSink.Columns - Zoom) \ 2
        Dim y = (pixelSink.Rows - Zoom) \ 2
        pixelSink.Fill(x, y, Zoom, 1, palette(ColorIndex))
        pixelSink.Fill(x, y + Zoom - 1, Zoom, 1, palette(ColorIndex))
        pixelSink.Fill(x, y + 1, 1, Zoom - 2, palette(ColorIndex))
        pixelSink.Fill(x + Zoom - 1, y + 1, 1, Zoom - 2, palette(ColorIndex))
    End Sub

    Private Sub ShowImage(pixelSink As IPixelSink(Of CGAHue))
        For Each c In Enumerable.Range(0, Image.Columns)
            Dim x = (pixelSink.Columns - Zoom) \ 2 + (c - Column) * Zoom
            For Each r In Enumerable.Range(0, Image.Rows)
                Dim y = (pixelSink.Rows - Zoom) \ 2 + (r - Row) * Zoom
                pixelSink.Fill(x, y, Zoom, Zoom, palette(Image.GetPixel(c, r)))
            Next
        Next
    End Sub

    Private Sub ShowStats(pixelSink As IPixelSink(Of CGAHue))
        ShowStats(pixelSink, (1, 1), CGAHue.BLACK)
        ShowStats(pixelSink, (0, 0), CGAHue.WHITE)
    End Sub

    Private Sub ShowStats(pixelSink As IPixelSink(Of CGAHue), position As (Column As Integer, Row As Integer), hue As CGAHue)
        If Not ShouldShowStats Then Return
        Dim font = Controls.GetFont(Fonts.RomFont5x7)
        font.WriteText(pixelSink, (position.Column, position.Row), $"Name: {Image.ImageName}", hue)
        font.WriteText(pixelSink, (position.Column, position.Row + font.Height), $"Columns: {Image.Columns}", hue)
        font.WriteText(pixelSink, (position.Column, position.Row + font.Height * 2), $"Rows: {Image.Rows}", hue)
        font.WriteText(pixelSink, (position.Column, position.Row + font.Height * 3), $"Column: {Column}", hue)
        font.WriteText(pixelSink, (position.Column, position.Row + font.Height * 4), $"Row: {Row}", hue)
        font.WriteText(pixelSink, (position.Column, position.Row + font.Height * 5), $"Color: {ColorIndex}", hue)
    End Sub

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Select Case cmd
            Case UICommand.UP
                Row = (Row + Image.Rows - 1) Mod Image.Rows
            Case UICommand.RIGHT
                Column = (Column + 1) Mod Image.Columns
            Case UICommand.DOWN
                Row = (Row + 1) Mod Image.Rows
            Case UICommand.LEFT
                Column = (Column + Image.Columns - 1) Mod Image.Columns
            Case UICommand.BACK
                ColorIndex = (ColorIndex + 1) Mod palette.Count
            Case UICommand.START
                ShouldShowStats = Not ShouldShowStats
            Case UICommand.GREEN
                Image.SetPixel(Column, Row, ColorIndex)
            Case UICommand.RED
                Return EditImageMenuUI.Launch(Controls, Model, imageName).Invoke()
        End Select
        Return Me
    End Function


    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function() New EditImageUI(controls, model, imageName)
    End Function

    Private Shared Property ShouldShowStats As Boolean = True
    Private Shared Property Column As Integer = 0
    Private Shared Property Row As Integer = 0
    Private Shared ReadOnly palette As IReadOnlyList(Of CGAHue) =
        [Enum].GetValues(Of CGAHue).ToList
    Private Shared Property ColorIndex As Integer = palette.Count - 1
    Private Shared Property Zoom As Integer = 8
End Class
