Public Interface IPixelBuffer
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Sub SetPixel(x As Integer, y As Integer, color As Integer)
End Interface
