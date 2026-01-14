Imports TGGD.UI

Public MustInherit Class BaseRWOSUI
    Inherits BaseUI(Of CGAHue)

    Public Sub New(controls As IHostControls)
        MyBase.New(controls)
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
End Class
