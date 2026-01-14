Imports Microsoft.Xna.Framework.Audio
Imports RWOS.UI
Imports TGGD.UI

Friend Class RWOSHostControls
    Implements IHostControls
    Private ReadOnly sfxFilenames As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {Sfx.HitWall, "Content/Audio/Sfx/HitWall.wav"},
            {Sfx.PlayerStep, "Content/Audio/Sfx/PlayerStep.wav"}
        }
    Private sfxTable As New Dictionary(Of String, SoundEffect)

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
End Class
