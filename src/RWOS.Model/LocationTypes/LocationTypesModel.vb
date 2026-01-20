Imports RWOS.Data

Friend Class LocationTypesModel
    Implements ILocationTypesModel

    Private ReadOnly data As WorldData

    Public Sub New(data As WorldData)
        Me.data = data
    End Sub
End Class
