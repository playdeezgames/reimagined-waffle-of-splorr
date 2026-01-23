Imports RWOS.Model
Imports TGGD.UI

Friend Class EditLocations
    Inherits UIBase

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model, Array.Empty(Of IUIParameter))
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "Edit Locations"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Dim result As New List(Of IUIChoice) From
                {
                    New UIChoice("Done", Function() New EditWorld(External, Model)),
                    New UIChoice("Create...", Function() New AddLocation(External, Model))
                }
            result.AddRange(
                Model.Locations.All.Select(
                    Function(x) New UIChoice(
                        x.Name,
                        Function() New EditLocation(External, x))))
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
End Class
