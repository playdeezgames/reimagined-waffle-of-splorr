Imports RWOS.Model
Imports TGGD.UI

Friend Class MainMenuUI
    Inherits BaseRWOSUI
    Implements IUI(Of CGAHue)

    Public Sub New(controls As IHostControls, model As IWorldModel)
        MyBase.New(controls, model)
    End Sub

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
    End Sub

    Public Overrides Function HandleCommand(cmd As String) As IUI(Of CGAHue)
        Return New BlueRoomUI(Controls, Model)
    End Function
End Class
