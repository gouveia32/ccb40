
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports ccb40.DAL

Namespace BLL
    Public Class ClienteBLL

        Private DALobj As ClienteDAL

        Public Sub New()
            DALobj = New ClienteDAL()
        End Sub

        Public Sub Incluir(modelo As Cliente)
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do cliente é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Cliente)
            If modelo.ID <= 0 Then
                Throw New Exception("O id da cliente é obrigatório!")
            End If
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do cliente é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaCliente(id As Integer) As Cliente
            Return DALobj.CarregaCliente(id)
        End Function

        Public Function CarregaTodos() As DataTable
            Return DALobj.CarregaTodos()
        End Function
    End Class
End Namespace
