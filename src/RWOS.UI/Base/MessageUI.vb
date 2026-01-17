Imports RWOS.Model
Imports TGGD.UI

Public Class MessageUI
    Inherits BaseRWOSUI

    Private _message As String
    Private _launcher As Func(Of IUI(Of CGAHue))

    Public Sub New(
                  controls As IHostControls,
                  model As IWorldModel,
                  message As String,
                  launcher As Func(Of IUI(Of CGAHue)))
        MyBase.New(controls, model)
        Me._message = message
        Me._launcher = launcher
    End Sub

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        Dim font = Controls.GetFont(Fonts.RomFont5x7)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, pixelSink.Rows \ 2 - font.Height \ 2), _message, CGAHue.WHITE)
    End Sub

    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, message As String, launcher As Func(Of IUI(Of CGAHue))) As Func(Of IUI(Of CGAHue))
        Return Function() New MessageUI(controls, model, message, launcher)
    End Function

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Return _launcher.Invoke
    End Function
End Class
