Imports ccb40.DAL

Namespace BLL
    Public Class AgendaPedidoBLL

        Private DALobj As AgendaPedidoDAL

        Public Sub New()
            DALobj = New AgendaPedidoDAL()
        End Sub

        Public Sub Incluir(modelo As AgendaPedido)
            If modelo.subject.Trim().Length = 0 Then
                Throw New Exception("O subject é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As AgendaPedido)
            If modelo.id <= 0 Then
                Throw New Exception("O id da agenda é obrigatório!")
            End If
            If modelo.subject.Trim().Length = 0 Then
                Throw New Exception("O subject é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Sub ExcluiPorPedido(id As Integer)
            DALobj.ExcluiPorPedido(id)
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Return DALobj.Filtrar(valor)
        End Function

        Public Function CarregaModeloAgendaPedido(id As Integer) As AgendaPedido
            Return DALobj.CarregaModeloAgendaPedido(id)
        End Function

        Public Function CarregaModeloAgendaPedidoPorPedido(pedido_id As Integer) As AgendaPedido
            Return DALobj.CarregaModeloAgendaPedidoPorPedido(pedido_id)
        End Function

        Public Function UltimoDoDia(ByVal dia As Date, Optional pedido_id As Integer = 0) As DateTime
            Return DALobj.UltimoDoDia(dia, pedido_id)
        End Function

        Public Sub MudaStatus(pedido_id As Integer, status As Integer)
            DALobj.MudaStatus(pedido_id, status)
        End Sub
    End Class

End Namespace
