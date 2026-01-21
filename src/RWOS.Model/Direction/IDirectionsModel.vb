Public Interface IDirectionsModel
    Function Create(name As String) As IDirectionModel
    ReadOnly Property All As IEnumerable(Of IDirectionModel)
End Interface
