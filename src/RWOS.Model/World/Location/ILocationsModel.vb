Public Interface ILocationsModel
    ReadOnly Property All As IEnumerable(Of ILocationModel)
    Function Create(name As String) As ILocationModel
End Interface
