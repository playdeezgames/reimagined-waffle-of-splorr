Public Interface IUI
    ReadOnly Property Title As String
    ReadOnly Property Choices As IEnumerable(Of IUIChoice)
End Interface
