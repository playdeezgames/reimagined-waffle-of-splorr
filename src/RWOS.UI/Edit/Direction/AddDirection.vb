Imports RWOS.Model
Imports TGGD.UI

Friend Class AddDirection
    Inherits UIBase

    Private Const DIRECTION_NAME As String = "DirectionName"

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model, {
                New UIParameter(DIRECTION_NAME, "Direction Name:", "New Direction")
                })
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "New Direction"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("Confirm", Function()
                                            Dim direction = Model.Directions.Create(GetParameter(DIRECTION_NAME).Value)
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
End Class
