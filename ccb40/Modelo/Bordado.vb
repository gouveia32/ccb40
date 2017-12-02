Imports System.Collections.Generic

Public Class Bordado
    Public Property id() As Integer
    Public Property arquivo() As String
    Public Property descricao() As String
    Public Property caminho() As String
    Public Property disquete() As String
    Public Property bastidor() As String
    Public Property grupo_id() As Integer
    Public Property preco() As Double
    Public Property pontos() As Integer
    Public Property cores() As Integer
    Public Property largura() As Integer
    Public Property altura() As Integer
    Public Property aprovado() As Boolean
    Public Property metragem() As Integer
    Public Property imagem() As Byte()
    Public Property obs_publica() As String
    Public Property obs_Restrita() As String
    Public Property LinhasUtilizadas() As List(Of LinhaUtilizada)
End Class