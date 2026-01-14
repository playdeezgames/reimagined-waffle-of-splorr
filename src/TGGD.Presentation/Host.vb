Imports System.ComponentModel
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports TGGD.UI

Public MustInherit Class Host(Of THue)
    Inherits Game
    Private ReadOnly _graphics As GraphicsDeviceManager
    Private _texture As Texture2D
    Private _spriteBatch As SpriteBatch
    Private _displayBuffer As IPixelSink(Of THue)
    Protected MustOverride ReadOnly Property ScreenWidth As Integer
    Protected MustOverride ReadOnly Property ScreenHeight As Integer
    Protected MustOverride ReadOnly Property ViewWidth As Integer
    Protected MustOverride ReadOnly Property ViewHeight As Integer
    Protected MustOverride ReadOnly Property FullScreen As Boolean
    Protected MustOverride Function CreateDisplayBuffer(texture As Texture2D) As IPixelSink(Of THue)

    Sub New()
        _graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
        IsMouseVisible = False
    End Sub

    Private Sub UpdateDisplay()
        _graphics.PreferredBackBufferWidth = ScreenWidth
        _graphics.PreferredBackBufferHeight = ScreenHeight
        _graphics.IsFullScreen = FullScreen
        _graphics.ApplyChanges()
    End Sub

    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        UpdateDisplay()
    End Sub

    Protected Overrides Sub LoadContent()
        _spriteBatch = New SpriteBatch(GraphicsDevice)
        _texture = New Texture2D(GraphicsDevice, ViewWidth, ViewHeight)
        _displayBuffer = CreateDisplayBuffer(_texture)
    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
        Refresh(_displayBuffer, gameTime.ElapsedGameTime)
        _displayBuffer.Commit()
    End Sub

    Protected MustOverride Sub Refresh(pixelSink As IPixelSink(Of THue), elapsedTime As TimeSpan)

    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.Black)
        _spriteBatch.Begin(samplerState:=SamplerState.PointClamp)
        _spriteBatch.Draw(_texture, New Rectangle(0, 0, 1280, 800), Nothing, Color.White)
        _spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub
End Class
