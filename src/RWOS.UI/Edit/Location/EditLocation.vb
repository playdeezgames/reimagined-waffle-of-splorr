Imports RWOS.Model
Imports TGGD.UI

Friend Class EditLocation
    Inherits UIBase

    Private ReadOnly location As ILocationModel
    Const LOCATION_NAME = "LocationName"

    Public Sub New(external As IExternal, location As ILocationModel)
        MyBase.New(external, location.Model, {New UIParameter(LOCATION_NAME, "Location Name:", location.Name)})
        Me.location = location
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return $"Edit '{location.Name}'"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Dim result As New List(Of IUIChoice) From {
                New UIChoice("Apply", Function()
                                          location.Name = GetParameter(LOCATION_NAME).Value
                                          Return New EditLocations(External, Model)
                                      End Function),
                New UIChoice("Cancel", Function() New EditLocations(External, Model))
                }
            If location.CanDelete Then
                result.Add(New UIChoice("Delete", Function()
                                                      location.Delete()
                                                      Return New EditLocations(External, Model)
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
