Imports RWOS.Model
Imports TGGD.UI

Friend Class EditPortals
    Inherits UIBase

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model, Array.Empty(Of IUIParameter))
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "Edit Portals"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Dim result As New List(Of IUIChoice) From
                {
                    New UIChoice("Done", Function() New EditWorld(External, Model)),
                    New UIChoice("Create...", Function() New AddPortal(External, Model))
                }
            result.AddRange(
                Model.Portals.All.Select(
                    Function(x) New UIChoice(
                        x.Name,
                        Function() New EditPortal(External, x))))
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
