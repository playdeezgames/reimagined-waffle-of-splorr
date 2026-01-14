Imports RWOS.UI
Imports TGGD.Presentation

Friend Class RWOSHostSettings
    Implements IHostSettings, IHostSettingSource
    Public Property FullScreen As Boolean Implements IHostSettings.FullScreen

    Public ReadOnly Property ScaleX As Integer Implements IHostSettingSource.ScaleX
        Get
            Return 4
        End Get
    End Property

    Public ReadOnly Property ScaleY As Integer Implements IHostSettingSource.ScaleY
        Get
            Return 4
        End Get
    End Property

    Private ReadOnly Property IHostSettingSource_FullScreen As Boolean Implements IHostSettingSource.FullScreen
        Get
            Return FullScreen
        End Get
    End Property

    Public Event OnCommit() Implements IHostSettingSource.OnCommit

    Public Sub Commit() Implements IHostSettings.Commit
        RaiseEvent OnCommit()
    End Sub
End Class
