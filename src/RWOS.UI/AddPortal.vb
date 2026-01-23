Imports RWOS.Model
Imports TGGD.UI

Friend Class AddPortal
    Inherits UIBase

    Private Const PORTAL_NAME As String = "PortalName"

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model)
        Parameters = {
                New UIParameter(PORTAL_NAME, "Portal Name:", "New Portal")
                }
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "New Portal"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("Confirm", Function()
                                            Dim portal = Model.Portals.Create(Parameters.Single(Function(x) x.Identifier = PORTAL_NAME).Value)
                                            Return New EditPortals(External, Model)
                                        End Function),
                New UIChoice("Cancel", Function() New EditPortals(External, Model))
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
