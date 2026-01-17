Public MustInherit Class BaseUI(Of THue, TModel)
    Implements IUI(Of THue)
    Protected ReadOnly Controls As IHostControls
    Protected ReadOnly Model As TModel

    Public Sub New(controls As IHostControls, model As TModel)
        Me.Controls = controls
        Me.Model = model
    End Sub

    Public MustOverride ReadOnly Property ViewWidth As Integer Implements IUI(Of THue).ViewWidth

    Public MustOverride ReadOnly Property ViewHeight As Integer Implements IUI(Of THue).ViewHeight

    Public MustOverride Sub Update(
                                  pixelSink As IPixelSink(Of THue),
                                  elapsedTime As TimeSpan) Implements IUI(Of THue).Update
    Public MustOverride Function HandleCommand(cmd As String) As IUI(Of THue) Implements IUI(Of THue).HandleCommand
End Class
