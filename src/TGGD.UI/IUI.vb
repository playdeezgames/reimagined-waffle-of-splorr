Public Interface IUI
    ReadOnly Property Title As String
    ReadOnly Property Choices As IEnumerable(Of IUIChoice)
    ReadOnly Property Lines As IEnumerable(Of String)
End Interface
