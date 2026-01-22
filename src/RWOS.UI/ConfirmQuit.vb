Imports TGGD.UI

Friend Class ConfirmQuit
    Inherits UIBase

    Public Sub New(external As IExternal)
        MyBase.New(external)
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "Are you sure you want to quit?"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                New UIChoice("No", Function() New MainMenu(External)),
                New UIChoice("Yes", Function() Nothing)
                }
        End Get
    End Property
End Class
