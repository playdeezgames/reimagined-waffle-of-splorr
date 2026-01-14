Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports TGGD.UI

Public MustInherit Class BaseHost(Of THue)
    Inherits Game
    Private ReadOnly _graphics As GraphicsDeviceManager
    Private _texture As Texture2D
    Private _spriteBatch As SpriteBatch
    Private _displayBuffer As IPixelSink(Of THue)
    Private ReadOnly _settings As IHostSettingSource
    Private ReadOnly _ui As IUI(Of THue)
    Private ReadOnly Property ScreenWidth As Integer
        Get
            Return _ui.ViewWidth * _settings.ScaleX
        End Get
    End Property
    Private ReadOnly Property ScreenHeight As Integer
        Get
            Return _ui.ViewHeight * _settings.ScaleY
        End Get
    End Property
    Protected MustOverride Function CreateDisplayBuffer(texture As Texture2D) As IPixelSink(Of THue)

    Sub New(settings As IHostSettingSource, ui As IUI(Of THue))
        _settings = settings
        _ui = ui
        _graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
        IsMouseVisible = False
    End Sub

    Private Sub UpdateDisplay()
        _graphics.PreferredBackBufferWidth = ScreenWidth
        _graphics.PreferredBackBufferHeight = ScreenHeight
        _graphics.IsFullScreen = _settings.FullScreen
        _graphics.ApplyChanges()
    End Sub

    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        UpdateDisplay()
    End Sub

    Protected Overrides Sub LoadContent()
        _spriteBatch = New SpriteBatch(GraphicsDevice)
        _texture = New Texture2D(GraphicsDevice, _ui.ViewWidth, _ui.ViewHeight)
        _displayBuffer = CreateDisplayBuffer(_texture)
    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
        _ui.Update(_displayBuffer, gameTime.ElapsedGameTime)
        _displayBuffer.Commit()
    End Sub

    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.Black)
        _spriteBatch.Begin(samplerState:=SamplerState.PointClamp)
        _spriteBatch.Draw(_texture, New Rectangle(0, 0, 1280, 800), Nothing, Color.White)
        _spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub
End Class
