Public Class Font
    Implements IFont

    Private ReadOnly fontData As FontData

    Sub New(fontData As FontData)
        Me.fontData = fontData
    End Sub

    Public ReadOnly Property Height As Integer Implements IFont.Height
        Get
            Return fontData.Height
        End Get
    End Property

    Public Function WriteText(Of THue)(
                                      pixelSink As IPixelSink(Of THue),
                                      position As (Column As Integer, Row As Integer),
                                      text As String, hue As THue) As (Column As Integer, Row As Integer) Implements IFont.WriteText
        For Each glyph In text
            position = WriteGlyph(Of THue)(pixelSink, position, glyph, hue)
        Next
    End Function

    Public Function WriteCenteredText(Of THue)(pixelSink As IPixelSink(Of THue), position As (Column As Integer, Row As Integer), text As String, hue As THue) As (Column As Integer, Row As Integer) Implements IFont.WriteCenteredText
        Return WriteText(pixelSink, (position.Column - GetTextWidth(text) \ 2, position.Row), text, hue)
    End Function

    Public Function GetTextWidth(text As String) As Integer Implements IFont.GetTextWidth
        Dim result As Integer = 0
        For Each glyph In text
            result += GetGlyphWidth(glyph)
        Next
        Return result
    End Function

    Private Function GetGlyphWidth(glyph As Char) As Integer
        Dim glyphData As GlyphData = Nothing
        If fontData.Glyphs.TryGetValue(glyph, glyphData) Then
            Return glyphData.Width
        End If
        Return 0
    End Function

    Private Function WriteGlyph(Of THue)(
                                        pixelSink As IPixelSink(Of THue),
                                        position As (Column As Integer, Row As Integer),
                                        glyph As Char,
                                        hue As THue) As (Column As Integer, Row As Integer)
        Dim glyphData As GlyphData = Nothing
        If fontData.Glyphs.TryGetValue(glyph, glyphData) Then
            For Each row In glyphData.Lines
                For Each column In row.Value
                    pixelSink.Fill(column + position.Column, row.Key + position.Row, 1, 1, hue)
                Next
            Next
            position = (position.Column + glyphData.Width, position.Row)
        End If
        Return position
    End Function
End Class
