Module Program
    Sub Main(args As String())
        Using host As New RWOSHost(New RWOSHostSettings)
            host.Run()
        End Using
    End Sub
End Module
