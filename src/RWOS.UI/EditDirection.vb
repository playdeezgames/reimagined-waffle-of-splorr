Imports RWOS.Model
Imports TGGD.UI

Friend Class EditDirection
    Inherits UIBase

    Private ReadOnly direction As IDirectionModel
    Const DIRECTION_NAME = "DirectionName"

    Public Sub New(external As IExternal, direction As IDirectionModel)
        MyBase.New(external, direction.Model)
        Me.direction = direction
        Me.Parameters = {New UIParameter(DIRECTION_NAME, "Direction Name:", direction.Name)}
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return $"Edit '{direction.Name}'"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("Apply", Function()
                                          direction.Name = Parameters.Single(Function(x) x.Identifier = DIRECTION_NAME).Value
                                          Return New EditDirections(External, Model)
                                      End Function),
                New UIChoice("Cancel", Function() New EditDirections(External, Model))
                }
        End Get
    End Property

    Public Overrides ReadOnly Property Lines As IEnumerable(Of String)
        Get
            Return Array.Empty(Of String)
        End Get
    End Property

    Public Overrides ReadOnly Property Parameters As IEnumerable(Of IUIParameter)
End Class
