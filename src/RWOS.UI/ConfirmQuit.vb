Imports RWOS.Model
Imports TGGD.UI

Friend Class ConfirmQuit
    Inherits UIBase

    Public Sub New(external As IExternal, model As IWorldModel)
        MyBase.New(external, model)
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "Confirm Quit"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("No", Function() New MainMenu(External, Model)),
                New UIChoice("Yes", Function() Nothing)
                }
        End Get
    End Property

    Public Overrides ReadOnly Property Lines As IEnumerable(Of String)
        Get
            Return {"Are you sure you want to quit?"}
        End Get
    End Property

    Public Overrides ReadOnly Property Parameters As IEnumerable(Of IUIParameter)
        Get
            Return Array.Empty(Of IUIParameter)
        End Get
    End Property
End Class
