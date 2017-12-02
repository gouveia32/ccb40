Public Class Item
    Public Property pedido_id() As Integer
    Public Property item() As Integer
    Public Property bordado() As Bordado
    Public Property descricao() As String
    Public Property data_entrega() As Nullable(Of DateTime)
    Public Property data_execucao() As Nullable(Of DateTime)
    Public Property pc_solicitadas() As Integer
    Public Property pc_entregues() As Integer
    Public Property pc_defeito() As Integer
    Public Property pc_nao_bordadas() As Integer
    Public Property pontos_extras() As Integer
    Public Property preco_por_peca() As Decimal
    Public Property material_id() As Integer
    Public Property local_id() As Integer
    Public Property lado() As Integer
    Public Property aplicacao() As Boolean
    Public Property status() As Boolean
    Public Property cores() As Boolean
    Public Property troca_rapida() As Boolean
    Public Property obs() As String
End Class