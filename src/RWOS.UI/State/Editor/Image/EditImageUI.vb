Imports RWOS.Model
Imports TGGD.UI

Public Class EditImageUI
    Inherits BaseRWOSUI

    Private ReadOnly imageName As String

    Private Sub New(controls As IHostControls, model As IWorldModel, imageName As String)
        MyBase.New(controls, model)
        Me.imageName = imageName
    End Sub

    Private ReadOnly Property Image As IImageModel
        Get
            Return Model.GetImage(imageName)
        End Get
    End Property

    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        Dim font = Controls.GetFont(Fonts.RomFont5x7)
        font.WriteText(pixelSink, (0, 0), $"Name: {Image.ImageName}", CGAHue.WHITE)
        font.WriteText(pixelSink, (0, font.Height), $"Columns: {Image.Columns}", CGAHue.WHITE)
        font.WriteText(pixelSink, (0, font.Height * 2), $"Rows: {Image.Rows}", CGAHue.WHITE)
    End Sub

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Return ImageEditorUI.Launch(Controls, Model).Invoke()
    End Function


    Friend Shared Function Launch(controls As IHostControls, model As IWorldModel, imageName As String) As Func(Of IUI(Of CGAHue))
        Return Function() New EditImageUI(controls, model, imageName)
    End Function
End Class
