Public Class Empregado
    Public Property ID() As Integer
    Public Property nome() As String
    Public Property funcao() As String
    Public Property nascimento() As Nullable(Of DateTime)
    Public Property admissao() As Nullable(Of DateTime)
    Public Property demissao() As Nullable(Of DateTime)
    Public Property endereco() As String
    Public Property cidade() As String
    Public Property uf() As String
    Public Property cep() As String
    Public Property telefone1() As String
    Public Property telefone2() As String
    Public Property telefone3() As String
    Public Property email() As String
    Public Property obs() As String
    Public Property status() As Boolean
End Class