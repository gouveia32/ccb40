Imports System.Collections.Generic
Imports ccb40.DAL

Namespace BLL
    Public Class LinhaUtilizadaBLL
        Private ra As New fnRetiraAcento()
        Private DALobj As LinhaUtilizadaDAL

        Public Sub New()
            DALobj = New LinhaUtilizadaDAL()
        End Sub

        Public Sub Incluir(modelo As LinhaUtilizada)
            If modelo.bordado_id = 0 Then
                Throw New Exception("O bordado_id do log é obrigatório!")
            End If
            If modelo.seq = 0 Then
                Throw New Exception("A seq é obrigatório!")
            End If
            If modelo.codigo.Trim.Length = 0 Then
                Throw New Exception("O linha_id do log é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As LinhaUtilizada)
            If modelo.bordado_id = 0 Then
                Throw New Exception("O bordado_id do log é obrigatório!")
            End If
            If modelo.seq = 0 Then
                Throw New Exception("A seq é obrigatório!")
            End If
            If modelo.codigo.Trim.Length = 0 Then
                Throw New Exception("O linha_id do log é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(bordado_id As Integer, seq As Integer, linha_id As String)
            DALobj.Exclui(bordado_id, seq, linha_id)
        End Sub

        Public Function CarregaLinhasDoBordado(bordado_id As Integer) As List(Of LinhaUtilizada)
            Return DALobj.CarregaLinhasDoBordado(bordado_id)
        End Function

        Public Sub ExcluiTodasDoBordado(bordado_id As Integer)
            DALobj.ExcluiTodasDoBordado(bordado_id)
        End Sub
    End Class
End Namespace
