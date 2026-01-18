Imports System.IO
Imports System.Text.Json
Imports RWOS.Data

Public MustInherit Class WorldModel
    Implements IWorldModel
    ReadOnly data As WorldData
    Sub New()
        data = New WorldData
    End Sub

    Public ReadOnly Property ImageFilename As String Implements IWorldModel.ImageFilename
        Get
            Return data.ImageFilename
        End Get
    End Property

    Public Property ImageColumns As Integer Implements IWorldModel.ImageColumns
        Get
            Return data.ImageColumns
        End Get
        Set(value As Integer)
            data.ImageColumns = Math.Max(0, value)
        End Set
    End Property

    Public Property ImageRows As Integer Implements IWorldModel.ImageRows
        Get
            Return data.ImageRows
        End Get
        Set(value As Integer)
            data.ImageRows = Math.Max(0, value)
        End Set
    End Property

    Public ReadOnly Property CanCreateImage As Boolean Implements IWorldModel.CanCreateImage
        Get
            Return Not String.IsNullOrWhiteSpace(ImageFilename) AndAlso ImageColumns > 0 AndAlso ImageRows > 0
        End Get
    End Property

    Public Sub Save(filename As String) Implements IWorldModel.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(data))
    End Sub

    Protected MustOverride Sub HandleCue(cue As Cues)
End Class
