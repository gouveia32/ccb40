Imports System.Collections.Generic
Imports ccb40.DAL

Namespace BLL
    Public Class ItemBLL
        Private ra As New fnRetiraAcento()
        Private DALobj As ItemDAL

        Public Sub New()
            DALobj = New ItemDAL()
        End Sub

        Public Sub Incluir(modelo As Item)
            If modelo.pedido_id = 0 Then
                Throw New Exception("O pedido_id é obrigatório!")
            End If
            If modelo.item = 0 Then
                Throw New Exception("O litem é obrigatório!")
            End If
            If modelo.bordado.id < 0 Then
                Throw New Exception("O bordado_id é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Item)
            If modelo.pedido_id = 0 Then
                Throw New Exception("O pedido_id é obrigatório!")
            End If
            If modelo.item = 0 Then
                Throw New Exception("O litem é obrigatório!")
            End If
            If modelo.bordado.id = 0 Then
                Throw New Exception("O bordado_id é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(Pedido_id As Integer, item As Integer)
            DALobj.Exclui(Pedido_id, item)
        End Sub

        Public Sub ExcluiTodosDoPedido(Pedido_id As Integer)
            DALobj.ExcluiTodosDoPedido(Pedido_id)
        End Sub

        Public Function CarregaModeloItem(pedido_id As Integer, item As Integer) As Item
            Return DALobj.CarregaModeloItem(pedido_id, item)
        End Function

        Public Function CarregaItensDoPedido(pedido_id As Integer) As List(Of Item)
            Return DALobj.CarregaItensDoPedido(pedido_id)
        End Function

        Public Function ItensDoPedido(pedido_id As Integer) As DataTable
            Return DALobj.ItensDoPedido(pedido_id)
        End Function

    End Class
End Namespace
