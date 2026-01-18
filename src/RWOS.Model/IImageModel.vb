Public Interface IImageModel
    ReadOnly Property ImageName As String
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Sub SetPixel(column As Integer, row As Integer, hue As Integer)
    Function GetPixel(column As Integer, row As Integer) As Integer
End Interface
