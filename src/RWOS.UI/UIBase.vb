Imports TGGD.UI

Public MustInherit Class UIBase
    Implements IUI
    Protected ReadOnly Property External As IExternal
    Public MustOverride ReadOnly Property Title As String Implements IUI.Title
    Public MustOverride ReadOnly Property Choices As IEnumerable(Of IUIChoice) Implements IUI.Choices

    Sub New(external As IExternal)
        Me.External = external
    End Sub
End Class
