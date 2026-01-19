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
    Function MapCommand(command As String) As String
    Sub Save(filename As String, data As String)
    Function Load(filename As String) As String
End Interface
