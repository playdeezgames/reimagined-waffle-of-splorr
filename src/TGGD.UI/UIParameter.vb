Public Class UIParameter
    Implements IUIParameter
    Sub New(identifier As String, labelText As String, defaultValue As String)
        Me.Identifier = identifier
        Me.LabelText = labelText
        Me.Value = defaultValue
    End Sub

    Public ReadOnly Property LabelText As String Implements IUIParameter.LabelText

    Public ReadOnly Property Identifier As String Implements IUIParameter.Identifier

    Public Property Value As String Implements IUIParameter.Value
End Class
