Public Interface IHostControls
    Property ScaleX As Integer
    Property ScaleY As Integer
    Property FullScreen As Boolean
    Sub Commit()
    Sub Quit()
    Event OnCommit()
    Event OnQuit()
    Sub PlaySfx(sfx As String)
    Function GetFont(fontName As String) As IFont
End Interface
