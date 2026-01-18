Imports System.IO
Imports System.Text.Json
Imports RWOS.Data

Public MustInherit Class WorldModel
    Implements IWorldModel
    ReadOnly data As WorldData
    Sub New()
        data = New WorldData
        ImageName = String.Empty
    End Sub

    Public Property ImageName As String Implements IWorldModel.ImageName
    Private _imageColumns As Integer = 0
    Private _imageRows As Integer = 0
    Public Property ImageColumns As Integer Implements IWorldModel.ImageColumns
        Get
            Return _imageColumns
        End Get
        Set(value As Integer)
            _imageColumns = Math.Max(0, value)
        End Set
    End Property

    Public Property ImageRows As Integer Implements IWorldModel.ImageRows
        Get
            Return _imageRows
        End Get
        Set(value As Integer)
            _imageRows = Math.Max(0, value)
        End Set
    End Property

    Public ReadOnly Property CanCreateImage As Boolean Implements IWorldModel.CanCreateImage
        Get
            Return Not String.IsNullOrWhiteSpace(ImageName) AndAlso ImageColumns > 0 AndAlso ImageRows > 0
        End Get
    End Property

    Public Sub Save(filename As String) Implements IWorldModel.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(data))
    End Sub

    Protected MustOverride Sub HandleCue(cue As Cues)
End Class
