Public Interface IPortalsModel
    ReadOnly Property All As IEnumerable(Of IPortalModel)
    Function Create(name As String) As IPortalModel
End Interface
