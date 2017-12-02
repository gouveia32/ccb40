Public Class Parametro
    Public Property ID() As Integer
    Public Property caixa_aberto() As Boolean
    Public Property data_caixa_atual() As DateTime
    Public Property data_saldo_caixa_fechado() As DateTime
    Public Property saldo_caixa() As Decimal
    Public Property SessaoTimeOut() As Integer
    Public Property TempoAtualizaPedidos() As Integer
    Public Property NotificarEmail() As Boolean
    Public Property EmailNotificacao() As String
    Public Property EmailOrigem() As String
    Public Property Senha() As String
    Public Property NomeEmpresa() As String
    Public Property endereco() As String
    Public Property telefone() As String
    Public Property corPedidoNormal() As Integer
    Public Property corPedidoMensal() As Integer
    Public Property corCriacaoNormal() As Integer
    Public Property corCriacaoUrgente() As Integer
    Public Property corTarefaSelecionada() As Integer
End Class
