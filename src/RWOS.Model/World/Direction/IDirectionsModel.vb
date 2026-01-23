Public Interface IDirectionsModel
    Function Create(value As String) As IDirectionModel
    ReadOnly Property All As IEnumerable(Of IDirectionModel)
End Interface
