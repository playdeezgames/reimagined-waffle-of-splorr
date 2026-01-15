Imports System.IO
Imports System.Text.Json
Imports Microsoft.Xna.Framework.Audio
Imports RWOS.Model
Imports RWOS.UI
Imports TGGD.UI

Friend Class RWOSHostControls
    Implements IHostControls
    Private ReadOnly sfxFilenames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {Cues.HitWall.ToString, "Content/Audio/Sfx/HitWall.wav"},
            {Cues.PlayerStep.ToString, "Content/Audio/Sfx/PlayerStep.wav"}
        }
    Private ReadOnly sfxTable As New Dictionary(Of String, SoundEffect)
    Private ReadOnly fontFileNames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {Fonts.RomFont8x8, "Content/Fonts/CyFont8x8.json"}
        }
    Private ReadOnly fontTable As New Dictionary(Of String, IFont)

    Sub New()
        ScaleX = 4
        ScaleY = 4
        FullScreen = False
    End Sub
    Public Property FullScreen As Boolean Implements IHostControls.FullScreen

    Public Property ScaleX As Integer Implements IHostControls.ScaleX

    Public Property ScaleY As Integer Implements IHostControls.ScaleY
    Public Event OnCommit() Implements IHostControls.OnCommit

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
End Class
