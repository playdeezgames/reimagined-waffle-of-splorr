Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input
Imports TGGD.UI

Public MustInherit Class BaseHost(Of THue)
    Inherits Game
    Private ReadOnly _graphics As GraphicsDeviceManager
    Private _texture As Texture2D
    Private _spriteBatch As SpriteBatch
    Private _displayBuffer As IPixelSink(Of THue)
    Private ReadOnly _title As String
    Private ReadOnly _controls As IHostControls
    Private ReadOnly _ui As IUI(Of THue)
    Private ReadOnly Property ScreenWidth As Integer
        Get
            Return _ui.ViewWidth * _controls.ScaleX
        End Get
    End Property
    Private ReadOnly Property ScreenHeight As Integer
        Get
            Return _ui.ViewHeight * _controls.ScaleY
        End Get
    End Property
    Protected MustOverride Function CreateDisplayBuffer(texture As Texture2D) As IPixelSink(Of THue)

    Sub New(
           title As String,
           settings As IHostControls,
           ui As IUI(Of THue))
        _title = title
        _controls = settings
        _ui = ui
        _graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
        IsMouseVisible = False
    End Sub

    Private Sub ApplySettings()
        _graphics.PreferredBackBufferWidth = ScreenWidth
        _graphics.PreferredBackBufferHeight = ScreenHeight
        _graphics.IsFullScreen = _controls.FullScreen
        _graphics.ApplyChanges()
    End Sub

    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        Window.Title = _title
        AddHandler _controls.OnCommit, AddressOf ApplySettings
        ApplySettings()
    End Sub

    Protected Overrides Sub LoadContent()
        _spriteBatch = New SpriteBatch(GraphicsDevice)
        _texture = New Texture2D(GraphicsDevice, _ui.ViewWidth, _ui.ViewHeight)
        _displayBuffer = CreateDisplayBuffer(_texture)
    End Sub

    Protected Overrides Sub Update(gameTime As GameTime)
        MyBase.Update(gameTime)
        Dim keyboardState = Keyboard.GetState()
        Dim commands As New HashSet(Of String)
        For Each key In [Enum].GetValues(Of Keys)()
            CheckForCommands(commands, keyboardState.IsKeyDown(key), $"Key{key}")
        Next
        Dim gamepadState = GamePad.GetState(PlayerIndex.One)
        For Each button In [Enum].GetValues(Of Buttons)()
            CheckForCommands(commands, gamepadState.IsButtonDown(button), $"Button{button}")
        Next
        For Each cmd In commands
            _ui.HandleCommand(cmd)
        Next
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

    Private ReadOnly _nextCommandTimes As New Dictionary(Of String, DateTimeOffset)
    Private Sub CheckForCommands(commands As HashSet(Of String), isPressed As Boolean, command As String)
        If isPressed Then
            If _nextCommandTimes.ContainsKey(command) Then
                If DateTimeOffset.Now > _nextCommandTimes(command) Then
                    commands.Add(command)
                    _nextCommandTimes(command) = DateTimeOffset.Now.AddSeconds(0.3)
                End If
            Else
                commands.Add(command)
                _nextCommandTimes(command) = DateTimeOffset.Now.AddSeconds(1.0)
            End If
        Else
            _nextCommandTimes.Remove(command)
        End If
    End Sub
End Class
