Imports System
Imports System.Drawing
Imports System.IO

Module Program
    Const CELL_COLUMNS = 16
    Const CELL_ROWS = 16
    Const PIXEL_WIDTH = 4
    Const PIXEL_HEIGHT = 4
    Const PIXEL_COLUMNS = 4
    Const CELL_WIDTH = PIXEL_WIDTH * PIXEL_COLUMNS
    Const CELL_HEIGHT = PIXEL_HEIGHT
    Const OUTPUT_FILENAME = "output.png"
    Const OUTPUT_TEXT_FILENAME = "output.txt"
    ReadOnly palette As Color() = {Color.Black, Color.Cyan, Color.Magenta, Color.White}
    Sub Main(args As String())
        Using bitmap = New Bitmap(CELL_COLUMNS * CELL_WIDTH, CELL_ROWS * CELL_HEIGHT)
            For Each column In Enumerable.Range(0, CELL_COLUMNS)
                For Each row In Enumerable.Range(0, CELL_ROWS)
                    Dim index = column + row * CELL_COLUMNS
                    For Each pixelIndex In Enumerable.Range(0, PIXEL_COLUMNS)
                        Dim color = palette(index Mod 4)
                        index \= 4
                        For Each x In Enumerable.Range(0, PIXEL_WIDTH)
                            For Each y In Enumerable.Range(0, PIXEL_HEIGHT)
                                bitmap.SetPixel(x + column * CELL_WIDTH + pixelIndex * PIXEL_WIDTH, y + row * CELL_HEIGHT, color)
                            Next
                        Next
                    Next
                Next
            Next
            bitmap.Save(OUTPUT_FILENAME)
            Dim allBytes = File.ReadAllBytes(OUTPUT_FILENAME)
            Dim base64 = Convert.ToBase64String(allBytes)
            File.WriteAllText(OUTPUT_TEXT_FILENAME, $"data:image/png;base64,{base64}")
        End Using
    End Sub
End Module
