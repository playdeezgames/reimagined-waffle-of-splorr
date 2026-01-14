Public Interface IHostControls
    Property ScaleX As Integer
    Property ScaleY As Integer
    Property FullScreen As Boolean
    Sub Commit()
    Event OnCommit()
    Sub PlaySfx(sfx As String)
End Interface
