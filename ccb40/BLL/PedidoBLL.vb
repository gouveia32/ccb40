Imports System.Collections.Generic
Imports ccb40.DAL

Namespace BLL
    Public Class PedidoBLL
        Private ra As New fnRetiraAcento()
        Private DALobj As PedidoDAL

        Public Sub New()
            DALobj = New PedidoDAL()
        End Sub

        Public Sub Incluir(modelo As Pedido)
            If modelo.cliente.ID = 0 Then
                Throw New Exception("O cliente_id é obrigatório!")
            End If
            If modelo.usuario.id = 0 Then
                Throw New Exception("O usuario_id é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Pedido)
            If modelo.id = 0 Then
                Throw New Exception("O id é obrigatório!")
            End If
            If modelo.cliente.ID = 0 Then
                Throw New Exception("O cliente_id é obrigatório!")
            End If
            If modelo.usuario.id = 0 Then
                Throw New Exception("O usuario_id é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function CarregaModePedido(id As Integer) As Pedido
            Return DALobj.CarregaModePedido(id)
        End Function

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

    End Class
End Namespace
