Imports RWOS.Model
Imports RWOS.UI
Imports TGGD.UI

Friend Class RWOSWorldModel
    Inherits WorldModel

    Private ReadOnly controls As IHostControls

    Public Sub New(controls As IHostControls)
        Me.controls = controls
    End Sub
End Class
