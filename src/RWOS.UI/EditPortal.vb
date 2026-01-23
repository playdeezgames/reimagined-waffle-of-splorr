Imports RWOS.Model
Imports TGGD.UI

Friend Class EditPortal
    Inherits UIBase

    Private ReadOnly portal As IPortalModel
    Const PORTAL_NAME = "PortalName"

    Public Sub New(external As IExternal, portal As IPortalModel)
        MyBase.New(external, portal.Model)
        Me.portal = portal
        Me.Parameters = {New UIParameter(PORTAL_NAME, "Portal Name:", portal.Name)}
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return $"Edit '{portal.Name}'"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("Apply", Function()
                                          portal.Name = Parameters.Single(Function(x) x.Identifier = PORTAL_NAME).Value
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
