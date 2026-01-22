Public Class UIChoice
    Implements IUIChoice

    Private ReadOnly thingie As Func(Of IUI)

    Sub New(text As String, thingie As Func(Of IUI))
        Me.text = text
        Me.thingie = thingie
    End Sub

    Public ReadOnly Property Text As String Implements IUIChoice.Text

    Public Function Choose() As IUI Implements IUIChoice.Choose
        Return thingie.Invoke
    End Function
End Class
