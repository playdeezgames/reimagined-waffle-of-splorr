Module Program
    Sub Main(args As String())
        Using host As New RWOSHost(New RWOSHostControls)
            host.Run()
        End Using
    End Sub
End Module
