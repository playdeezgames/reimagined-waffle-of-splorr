Imports RWOS.Model
Imports TGGD.UI

Public Class EditLocationTypeUI
    Inherits BaseRWOSUI

    Private ReadOnly locationTypeName As String

    Public Sub New(controls As IHostControls, model As IWorldModel, locationTypeName As String)
        MyBase.New(controls, model)
        Me.locationTypeName = locationTypeName
    End Sub

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        Controls.GetFont(Fonts.RomFont5x7).WriteText(pixelSink, (0, 0), $"TODO: Edit Location Type '{locationTypeName}'", CGAHue.CYAN)
    End Sub

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, locationTypeName As String) As Func(Of IUI(Of CGAHue))
        Return Function() New EditLocationTypeUI(controls, model, locationTypeName)
    End Function

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Return EditLocationTypesUI.Launch(Controls, Model).Invoke
    End Function
End Class
