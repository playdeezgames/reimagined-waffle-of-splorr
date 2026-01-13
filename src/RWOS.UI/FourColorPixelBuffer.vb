Imports TGGD.UI

Public Class FourColorPixelBuffer
    Implements IPixelBuffer

    Private ReadOnly FrameBuffer As Byte()
    Private ReadOnly ClearMask As IReadOnlyList(Of Byte) = New List(Of Byte) From {&HFC, &HF3, &HCF, &H3F}
    Private ReadOnly AndMask As IReadOnlyList(Of Byte) = New List(Of Byte) From {&H3, &HC, &H30, &HC0}
    Private ReadOnly OrMask As IReadOnlyList(Of Byte) = New List(Of Byte) From {&H0, &H55, &HAA, &HFF}
    Sub New(frameBuffer As Byte(), columns As Integer, rows As Integer)
        Me.FrameBuffer = frameBuffer
        Me.Columns = columns
        Me.Rows = rows
    End Sub

    Public ReadOnly Property Columns As Integer Implements IPixelBuffer.Columns

    Public ReadOnly Property Rows As Integer Implements IPixelBuffer.Rows

    Public Sub SetPixel(x As Integer, y As Integer, color As Integer) Implements IPixelBuffer.SetPixel
        If x >= 0 AndAlso x < Columns AndAlso y >= 0 AndAlso y < Rows Then
            Dim index = y * Columns + x
            Dim bufferIndex = index \ 4
            Dim pixelIndex = index Mod 4
            FrameBuffer(bufferIndex) = FrameBuffer(bufferIndex) And ClearMask(pixelIndex) Or (AndMask(pixelIndex) And OrMask(color))
        End If
    End Sub
End Class
