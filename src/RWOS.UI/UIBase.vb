Imports RWOS.Model
Imports TGGD.UI

Public MustInherit Class UIBase
    Implements IUI
    Protected ReadOnly Property External As IExternal
    Protected ReadOnly Property Model As IWorldModel
    Public MustOverride ReadOnly Property Title As String Implements IUI.Title
    Public MustOverride ReadOnly Property Choices As IEnumerable(Of IUIChoice) Implements IUI.Choices
    Public MustOverride ReadOnly Property Lines As IEnumerable(Of String) Implements IUI.Lines
    Public ReadOnly Property Parameters As IEnumerable(Of IUIParameter) Implements IUI.Parameters
    Protected Function GetParameter(identifier As String) As IUIParameter
        Return Parameters.SingleOrDefault(Function(x) x.Identifier = identifier)
    End Function

    Sub New(external As IExternal, model As IWorldModel, parameters As IEnumerable(Of IUIParameter))
        Me.External = external
        Me.Model = model
        Me.Parameters = parameters
    End Sub
End Class
