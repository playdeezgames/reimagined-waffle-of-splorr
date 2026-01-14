Imports RWOS.UI
Imports TGGD.Presentation

Friend Class RWOSHostSettings
    Implements IHostSettings, IHostSettingSource

    Sub New()
        ScaleX = 4
        ScaleY = 4
        FullScreen = False
    End Sub
    Public Property FullScreen As Boolean Implements IHostSettings.FullScreen

    Public Property ScaleX As Integer Implements IHostSettings.ScaleX

    Public Property ScaleY As Integer Implements IHostSettings.ScaleY

    Private ReadOnly Property IHostSettingSource_FullScreen As Boolean Implements IHostSettingSource.FullScreen
        Get
            Return FullScreen
        End Get
    End Property

    Private ReadOnly Property IHostSettingSource_ScaleX As Integer Implements IHostSettingSource.ScaleX
        Get
            Return ScaleX
        End Get
    End Property

    Private ReadOnly Property IHostSettingSource_ScaleY As Integer Implements IHostSettingSource.ScaleY
        Get
            Return ScaleY
        End Get
    End Property

    Public Event OnCommit() Implements IHostSettingSource.OnCommit

    Public Sub Commit() Implements IHostSettings.Commit
        RaiseEvent OnCommit()
    End Sub
End Class
