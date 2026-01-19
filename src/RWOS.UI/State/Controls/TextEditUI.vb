Imports System.Text
Imports RWOS.Model
Imports TGGD.UI

Public Class TextEditUI
    Inherits BaseRWOSUI
    Private value As String
    Private ReadOnly confirm As Func(Of String, IUI(Of CGAHue))
    Private ReadOnly cancel As Func(Of IUI(Of CGAHue))
    Private column As Integer
    Private row As Integer
    Private ReadOnly title As String
    Private ReadOnly hue As CGAHue
    Const COLUMNS = 17
    Const ROWS = 6
    Const BACKSPACE_TEXT = "<-"
    Const ENTER_TEXT = "Enter"
    Const CANCEL_TEXT = "Cancel"
    Const EMPTY_TEXT = ""
    Const CLEAR_TEXT = "Clear"
    Private Shared ReadOnly grid As String(,) =
        {
            {
                Chr(32),
                Chr(33),
                Chr(34),
                Chr(35),
                Chr(36),
                Chr(37),
                Chr(38),
                Chr(39),
                Chr(40),
                Chr(41),
                Chr(42),
                Chr(43),
                Chr(44),
                Chr(45),
                Chr(46),
                Chr(47),
                BACKSPACE_TEXT
            },
            {
                Chr(48),
                Chr(49),
                Chr(50),
                Chr(51),
                Chr(52),
                Chr(53),
                Chr(54),
                Chr(55),
                Chr(56),
                Chr(57),
                Chr(58),
                Chr(59),
                Chr(60),
                Chr(61),
                Chr(62),
                Chr(63),
                CLEAR_TEXT
            },
            {
                Chr(64),
                Chr(65),
                Chr(66),
                Chr(67),
                Chr(68),
                Chr(69),
                Chr(70),
                Chr(71),
                Chr(72),
                Chr(73),
                Chr(74),
                Chr(75),
                Chr(76),
                Chr(77),
                Chr(78),
                Chr(79),
                EMPTY_TEXT
            },
            {
                Chr(80),
                Chr(81),
                Chr(82),
                Chr(83),
                Chr(84),
                Chr(85),
                Chr(86),
                Chr(87),
                Chr(88),
                Chr(89),
                Chr(90),
                Chr(91),
                Chr(92),
                Chr(93),
                Chr(94),
                Chr(95),
                EMPTY_TEXT
            },
            {
                Chr(96),
                Chr(97),
                Chr(98),
                Chr(99),
                Chr(100),
                Chr(101),
                Chr(102),
                Chr(103),
                Chr(104),
                Chr(105),
                Chr(106),
                Chr(107),
                Chr(108),
                Chr(109),
                Chr(110),
                Chr(111),
                CANCEL_TEXT
            },
            {
                Chr(112),
                Chr(113),
                Chr(114),
                Chr(115),
                Chr(116),
                Chr(117),
                Chr(118),
                Chr(119),
                Chr(120),
                Chr(121),
                Chr(122),
                Chr(123),
                Chr(124),
                Chr(125),
                Chr(126),
                Chr(127),
                ENTER_TEXT
            }
        }


    Private Sub New(
                    controls As IHostControls,
                    model As IWorldModel,
                    title As String,
                    hue As CGAHue,
                    value As String,
                    confirm As Func(Of String, IUI(Of CGAHue)),
                    cancel As Func(Of IUI(Of CGAHue)))
        MyBase.New(controls, model)
        Me.value = value
        Me.confirm = confirm
        Me.cancel = cancel
        Me.column = 0
        Me.row = 0
        Me.title = title
        Me.hue = hue
    End Sub


    Public Overrides Sub Update(pixelSink As IPixelSink(Of CGAHue), elapsedTime As TimeSpan)
        pixelSink.Fill(0, 0, pixelSink.Columns, pixelSink.Rows, CGAHue.BLACK)
        Dim font = Controls.GetFont(Fonts.RomFont5x7)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, 0), title, hue)
        font.WriteCenteredText(pixelSink, (pixelSink.Columns \ 2, font.Height * 2), value, CGAHue.MAGENTA)
        Dim position = ((pixelSink.Columns - font.GetTextWidth(" ") * COLUMNS * 2) \ 2, (pixelSink.Rows - font.Height * ROWS) \ 2)
        For Each r In Enumerable.Range(0, ROWS)
            Dim sb As New StringBuilder
            For Each c In Enumerable.Range(0, COLUMNS)
                sb.Append(If(r = row AndAlso c = column, "[", If(r = row AndAlso c = column + 1, "]", " ")))
                sb.Append(grid(r, c))
            Next
            sb.Append(If(r = row AndAlso column = COLUMNS - 1, "]", " "))
            font.WriteText(pixelSink, position, sb.ToString, CGAHue.WHITE)
            position = (position.Item1, position.Item2 + font.Height)
        Next
    End Sub

    Protected Overrides Function HandleUICommand(cmd As UICommand) As IUI(Of CGAHue)
        Select Case cmd
            Case UICommand.RED
                Return cancel()
            Case UICommand.GREEN
                Return HandleInput()
            Case UICommand.DOWN
                row = (row + 1) Mod ROWS
            Case UICommand.LEFT
                column = (column + COLUMNS - 1) Mod COLUMNS
            Case UICommand.RIGHT
                column = (column + 1) Mod COLUMNS
            Case UICommand.UP
                row = (row + ROWS - 1) Mod ROWS
        End Select
        Return Me
    End Function

    Private Function HandleInput() As IUI(Of CGAHue)
        Dim character = grid(row, column)
        Select Case character
            Case ENTER_TEXT
                Return confirm(value)
            Case CLEAR_TEXT
                value = ""
            Case CANCEL_TEXT
                Return cancel()
            Case BACKSPACE_TEXT
                If value.Length > 0 Then
                    value = value.Substring(0, value.Length - 1)
                End If
            Case Else
                value &= character
        End Select
        Return Me
    End Function

    Friend Shared Function Launch(
                                 controls As IHostControls,
                                 model As IWorldModel,
                                 title As String,
                                 hue As CGAHue,
                                 value As String,
                                 confirm As Func(Of String, IUI(Of CGAHue)),
                                 cancel As Func(Of IUI(Of CGAHue))) As Func(Of IUI(Of CGAHue))
        Return Function() New TextEditUI(controls, model, title, hue, value, confirm, cancel)
    End Function
End Class
