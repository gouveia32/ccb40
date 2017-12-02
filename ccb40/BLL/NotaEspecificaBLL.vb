
Imports System.Collections.Generic
Imports ccb40.DAL

Namespace BLL
    Public Class NotaEspecificaBLL
        Private DALobj As NotaEspecificaDAL

        Public Sub New()
            DALobj = New NotaEspecificaDAL()
        End Sub

        Public Sub Insere(modelo As NotaEspecifica)
            If modelo.bordado_id = 0 Then
                Throw New Exception("O bordado_id é obrigatório!")
            End If
            If modelo.cliente_id = 0 Then
                Throw New Exception("O cliente_id é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As NotaEspecifica)
            If modelo.bordado_id = 0 Then
                Throw New Exception("O bordado_id é obrigatório!")
            End If
            If modelo.cliente_id = 0 Then
                Throw New Exception("O cliente_id é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(bordado_id As Integer, cliente_id As Integer)
            DALobj.Exclui(bordado_id, cliente_id)
        End Sub

        Public Function NotasDoBordado(bordado_id As Integer) As DataTable
            Return DALobj.NotasDoBordado(bordado_id)
        End Function

        Public Function ListaNotasDoBordado(bordado_id As Integer) As List(Of NotaEspecifica)
            Return DALobj.ListaNotasDoBordado(bordado_id)
        End Function

    End Class
End Namespace

