Imports TGGD.UI

Public Class MainMenu
    Inherits UIBase

    Public Sub New(external As IExternal)
        MyBase.New(external)
    End Sub

    Public Overrides ReadOnly Property Title As String
        Get
            Return "Main Menu"
        End Get
    End Property

    Public Overrides ReadOnly Property Choices As IEnumerable(Of IUIChoice)
        Get
            Return {
                    New UIChoice("Quit", Function() New ConfirmQuit(External))
                }
        End Get
    End Property
End Class
