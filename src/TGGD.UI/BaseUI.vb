Public MustInherit Class BaseUI(Of THue)
    Implements IUI(Of THue)

    Public ReadOnly Property ViewWidth As Integer Implements IUI(Of THue).ViewWidth
        Get
            Return 320
        End Get
    End Property

    Public ReadOnly Property ViewHeight As Integer Implements IUI(Of THue).ViewHeight
        Get
            Return 200
        End Get
    End Property

    Public MustOverride Sub Update(
                                  pixelSink As IPixelSink(Of THue),
                                  elapsedTime As TimeSpan) Implements IUI(Of THue).Update
    Public MustOverride Sub HandleCommand(cmd As String) Implements IUI(Of THue).HandleCommand
End Class
