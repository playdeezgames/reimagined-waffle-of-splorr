Imports RWOS.Model
Imports TGGD.UI

Public MustInherit Class BaseRWOSUI
    Inherits BaseUI(Of CGAHue, IWorldModel)

    Public Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model)
    End Sub

    Public Overrides ReadOnly Property ViewWidth As Integer
        Get
            Return 320
        End Get
    End Property

    Public Overrides ReadOnly Property ViewHeight As Integer
        Get
            Return 200
        End Get
    End Property

    Protected MustOverride Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)

    Public Overrides Function HandleCommand(cmd As String) As IUI(Of CGAHue)
        Dim result As IUI(Of CGAHue) = Nothing
        Dim uiCommand As UICommand
        If [Enum].TryParse(Of UICommand)(Controls.MapCommand(cmd), uiCommand) Then
            result = HandleUICommand(uiCommand)
        End If
        Return If(result, Me)
    End Function
End Class
