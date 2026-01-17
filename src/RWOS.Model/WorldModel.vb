Imports System.IO
Imports System.Text.Json
Imports RWOS.Data

Public MustInherit Class WorldModel
    Implements IWorldModel
    ReadOnly data As WorldData
    Sub New()
        data = New WorldData
    End Sub

    Public Sub Save(filename As String) Implements IWorldModel.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(data))
    End Sub

    Protected MustOverride Sub HandleCue(cue As Cues)
End Class
