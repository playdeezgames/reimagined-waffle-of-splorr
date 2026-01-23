Imports RWOS.Model
Imports TGGD.UI

Friend Class EditWorld
    Inherits UIBase

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model, Array.Empty(Of IUIParameter))
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "World Editor"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                    New UIChoice("Done Editing", Function() New MainMenu(External, Model)),
                    New UIChoice("Directions...", Function() New EditDirections(External, Model)),
                    New UIChoice("Portals...", Function() New EditPortals(External, Model))
                }
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
