Imports RWOS.Data
Imports TGGD.Data

Friend Class ImageModel
    Implements IImageModel

    Private ReadOnly data As WorldData
    Private ReadOnly Property imageData As ImageData
        Get
            Return data.Images(ImageName)
        End Get
    End Property

    Sub New(data As WorldData, imageName As String)
        Me.data = data
        Me.ImageName = imageName
    End Sub

    Public ReadOnly Property ImageName As String Implements IImageModel.ImageName

    Public ReadOnly Property Columns As Integer Implements IImageModel.Columns
        Get
            Return imageData.Columns
        End Get
    End Property

    Public ReadOnly Property Rows As Integer Implements IImageModel.Rows
        Get
            Return imageData.Rows
        End Get
    End Property
End Class
