Imports RWOS.Model
Imports TGGD.UI

Friend Class EditDirection
    Inherits UIBase

    Private ReadOnly direction As IDirectionModel
    Const DIRECTION_NAME = "DirectionName"

    Public Sub New(external As IExternal, direction As IDirectionModel)
        MyBase.New(external, direction.Model, {New UIParameter(DIRECTION_NAME, "Direction Name:", direction.Name)})
        Me.direction = direction
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return $"Edit '{direction.Name}'"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Dim result As New List(Of IUIChoice) From {
                New UIChoice("Apply", Function()
                                          direction.Name = GetParameter(DIRECTION_NAME).Value
                                          Return New EditDirections(External, Model)
                                      End Function),
                New UIChoice("Cancel", Function() New EditDirections(External, Model))
                }
            If direction.CanDelete Then
                result.Add(New UIChoice("Delete", Function()
                                                      direction.Delete()
                                                      Return New EditDirections(External, Model)
                                                  End Function))
            End If
            Return result
        End Get
    End Property

    Public Overrides ReadOnly Property Lines As IEnumerable(Of String)
        Get
            Return Array.Empty(Of String)
        End Get
    End Property
End Class
