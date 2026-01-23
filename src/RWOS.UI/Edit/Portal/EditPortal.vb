Imports RWOS.Model
Imports TGGD.UI

Friend Class EditPortal
    Inherits UIBase

    Private ReadOnly portal As IPortalModel
    Const PORTAL_NAME = "PortalName"

    Public Sub New(external As IExternal, portal As IPortalModel)
        MyBase.New(external, portal.Model, {New UIParameter(PORTAL_NAME, "Portal Name:", portal.Name)})
        Me.portal = portal
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return $"Edit '{portal.Name}'"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Dim result As New List(Of IUIChoice) From
                {
                    New UIChoice("Apply", Function()
                                              portal.Name = GetParameter(PORTAL_NAME).Value
                                              Return New EditPortals(External, Model)
                                          End Function),
                    New UIChoice("Cancel", Function() New EditPortals(External, Model))
                }
            If portal.CanDelete Then
                result.Add(New UIChoice("Delete", Function()
                                                      portal.Delete()
                                                      Return New EditPortals(External, Model)
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
