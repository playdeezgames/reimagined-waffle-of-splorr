Imports TGGD.Presentation

Friend Class RWOSHostSettings
    Implements IHostSettings

    Public ReadOnly Property ScaleX As Integer Implements IHostSettings.ScaleX
        Get
            Return 4
        End Get
    End Property

    Public ReadOnly Property ScaleY As Integer Implements IHostSettings.ScaleY
        Get
            Return 4
        End Get
    End Property

    Public ReadOnly Property FullScreen As Boolean Implements IHostSettings.FullScreen
        Get
            Return False
        End Get
    End Property
End Class
