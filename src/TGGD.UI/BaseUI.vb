Public MustInherit Class BaseUI(Of THue)
    Implements IUI(Of THue)
    Protected ReadOnly Controls As IHostControls

    Public Sub New(controls As IHostControls)
        Me.Controls = controls
    End Sub

    Public MustOverride ReadOnly Property ViewWidth As Integer Implements IUI(Of THue).ViewWidth

    Public MustOverride ReadOnly Property ViewHeight As Integer Implements IUI(Of THue).ViewHeight

    Public MustOverride Sub Update(
                                  pixelSink As IPixelSink(Of THue),
                                  elapsedTime As TimeSpan) Implements IUI(Of THue).Update
    Public MustOverride Function HandleCommand(cmd As String) As IUI(Of THue) Implements IUI(Of THue).HandleCommand
End Class
