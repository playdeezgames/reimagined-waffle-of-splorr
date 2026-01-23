Imports RWOS.Model
Imports RWOS.UI
Imports TGGD.Presentation

Module Program
    Sub Main(args As String())
        Host.Run(New MainMenu(New External, New WorldModel(New RWOS.Data.WorldData)))
    End Sub
End Module
