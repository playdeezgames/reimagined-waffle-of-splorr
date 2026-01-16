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
        'TODO: move mapping of key and button commands to host controls
        Select Case cmd
            Case "KeyUp", "ButtonDPadUp"
                result = HandleUICommand(UICommand.UP)
            Case "KeyRight", "ButtonDPadRight"
                result = HandleUICommand(UICommand.RIGHT)
            Case "KeyDown", "ButtonDPadDown"
                result = HandleUICommand(UICommand.DOWN)
            Case "KeyLeft", "ButtonDPadLeft"
                result = HandleUICommand(UICommand.LEFT)
            Case "ButtonA", "KeySpace"
                result = HandleUICommand(UICommand.GREEN)
            Case "ButtonB", "KeyEscape"
                result = HandleUICommand(UICommand.RED)
            Case "ButtonBack", "KeyTab"
                result = HandleUICommand(UICommand.BACK)
            Case "ButtonStart", "KeyEnter"
                result = HandleUICommand(UICommand.START)
        End Select
        Return If(result, Me)
    End Function
End Class
