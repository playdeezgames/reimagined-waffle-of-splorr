Imports RWOS.Model
Imports RWOS.UI
Imports TGGD.UI

Friend Class RWOSWorldModel
    Inherits WorldModel

    Private ReadOnly controls As IHostControls

    Public Sub New(controls As IHostControls)
        Me.controls = controls
    End Sub

    Protected Overrides Sub HandleCue(cue As Cues)
        controls.PlaySfx(cue.ToString)
    End Sub
End Class
