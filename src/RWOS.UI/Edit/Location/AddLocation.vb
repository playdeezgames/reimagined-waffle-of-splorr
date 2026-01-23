Imports RWOS.Model
Imports TGGD.UI

Friend Class AddLocation
    Inherits UIBase

    Private Const LOCATION_NAME As String = "LocationName"

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model, {
                New UIParameter(LOCATION_NAME, "Location Name:", "New Location")
                })
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "New Location"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("Confirm", Function()
                                            Dim location = Model.Locations.Create(GetParameter(LOCATION_NAME).Value)
                                            Return New EditLocation(External, location)
                                        End Function),
                New UIChoice("Cancel", Function() New EditLocations(External, Model))
                }
        End Get
    End Property

    Public Overrides ReadOnly Property Lines As IEnumerable(Of String)
        Get
            Return Array.Empty(Of String)
        End Get
    End Property
End Class
