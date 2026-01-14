Public Interface IHostSettingSource
    ReadOnly Property ScaleX As Integer
    ReadOnly Property ScaleY As Integer
    ReadOnly Property FullScreen As Boolean
    Event OnCommit()
End Interface
