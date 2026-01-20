Imports RWOS.Data

Friend Class LocationTypeModel
    Implements ILocationTypeModel

    Private data As WorldData
    Private locationTypeName As String

    Public Sub New(data As WorldData, locationTypeName As String)
        Me.data = data
        Me.locationTypeName = locationTypeName
    End Sub
End Class
