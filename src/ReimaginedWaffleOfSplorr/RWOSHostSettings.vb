Imports TGGD.Presentation

Friend Class RWOSHostSettings
    Implements IHostSettingSource

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

    Public ReadOnly Property FullScreen As Boolean Implements IHostSettingSource.FullScreen
        Get
            Return False
        End Get
    End Property
End Class
