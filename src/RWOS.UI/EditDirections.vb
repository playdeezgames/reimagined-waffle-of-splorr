Imports RWOS.Model
Imports TGGD.UI

Friend Class EditDirections
    Inherits UIBase

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model)
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "Edit Directions"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Dim result As New List(Of IUIChoice) From
                {
                    New UIChoice("Done", Function() New EditWorld(External, Model)),
                    New UIChoice("Create...", Function() New AddDirection(External, Model))
                }
            result.AddRange(
                Model.Directions.All.Select(
                    Function(x) New UIChoice(
                        x.Name,
                        Function() New EditDirection(External, x))))
            Return result
        End Get
    End Property

    Public Overrides ReadOnly Property Lines As IEnumerable(Of String)
        Get
            Return {
                "Now What?"
                }
        End Get
    End Property

    Public Overrides ReadOnly Property Parameters As IEnumerable(Of IUIParameter)
        Get
            Return Array.Empty(Of IUIParameter)
        End Get
    End Property
End Class
