Imports System.IO
Imports System.Text.Json
Imports Microsoft.Xna.Framework.Audio
Imports RWOS.UI
Imports TGGD.Data
Imports TGGD.UI

Friend Class RWOSHostControls
    Implements IHostControls
    Const SfxFilename = "Content/sfx.json"
    Const FontsFilename = "Content/fonts.json"
    Private ReadOnly sfxFilenames As IReadOnlyDictionary(Of String, String)
    Private ReadOnly sfxTable As New Dictionary(Of String, SoundEffect)
    'TODO: fonts into a config file!
    Private ReadOnly fontFileNames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {Fonts.RomFont8x8, "Content/Fonts/CyFont8x8.json"},
            {Fonts.RomFont5x7, "Content/Fonts/CyFont5x7.json"},
            {Fonts.RomFont4x6, "Content/Fonts/CyFont4x6.json"},
            {Fonts.RomFont3x5, "Content/Fonts/CyFont3x5.json"}
        }
    Private ReadOnly fontTable As New Dictionary(Of String, IFont)

    'TODO: scale and full screen settings into config file
    Sub New()
        ScaleX = 4
        ScaleY = 4
        FullScreen = False
        sfxFilenames = JsonSerializer.Deserialize(Of Dictionary(Of String, String))(File.ReadAllText(SfxFilename))
    End Sub
    Public Property FullScreen As Boolean Implements IHostControls.FullScreen

    Public Property ScaleX As Integer Implements IHostControls.ScaleX

    Public Property ScaleY As Integer Implements IHostControls.ScaleY
    Public Event OnCommit() Implements IHostControls.OnCommit
    Public Event OnQuit() Implements IHostControls.OnQuit

    Public Sub Commit() Implements IHostControls.Commit
        RaiseEvent OnCommit()
    End Sub

    Public Sub PlaySfx(sfx As String) Implements IHostControls.PlaySfx
        Dim effect As SoundEffect = Nothing
        If Not sfxTable.TryGetValue(sfx, effect) Then
            Dim filename As String = Nothing
            If sfxFilenames.TryGetValue(sfx, filename) Then
                effect = SoundEffect.FromFile(filename)
                sfxTable(sfx) = effect
            End If
        End If
        effect?.Play()
    End Sub

    Public Sub Quit() Implements IHostControls.Quit
        RaiseEvent OnQuit()
    End Sub

    Public Sub Save(filename As String, data As String) Implements IHostControls.Save
        File.WriteAllText(filename, data)
    End Sub

    Public Function GetFont(fontName As String) As IFont Implements IHostControls.GetFont
        Dim font As IFont = Nothing
        If Not fontTable.TryGetValue(fontName, font) Then
            Dim filename As String = Nothing
            If fontFileNames.TryGetValue(fontName, filename) Then
                font = New Font(JsonSerializer.Deserialize(Of FontData)(File.ReadAllText(filename)))
                fontTable(fontName) = font
            End If
        End If
        Return font
    End Function

    Public Function MapCommand(command As String) As String Implements IHostControls.MapCommand
        Select Case command
            Case "KeyUp", "ButtonDPadUp"
                Return "UP"
            Case "KeyRight", "ButtonDPadRight"
                Return "RIGHT"
            Case "KeyDown", "ButtonDPadDown"
                Return "DOWN"
            Case "KeyLeft", "ButtonDPadLeft"
                Return "LEFT"
            Case "ButtonA", "KeySpace"
                Return "GREEN"
            Case "ButtonB", "KeyEscape"
                Return "RED"
            Case "ButtonBack", "KeyTab"
                Return "BACK"
            Case "ButtonStart", "KeyEnter"
                Return "START"
        End Select
        Return Nothing
    End Function
End Class
