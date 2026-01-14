Public Interface IPixelSink(Of THue)
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As THue)
    Sub Commit()
End Interface
