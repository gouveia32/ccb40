Imports System.Collections.Generic
Public Class Pedido
    Public Property id() As Integer
    Public Property usuario() As Usuario
    Public Property cliente() As Cliente
    Public Property data_abertura() As Nullable(Of DateTime)
    Public Property data_fechamento() As Nullable(Of DateTime)
    Public Property data_pagamento() As Nullable(Of DateTime)
    Public Property adicional() As Decimal
    Public Property desconto() As Decimal
    Public Property pago() As Decimal
    Public Property valor() As Decimal
    Public Property quitado() As Boolean
    Public Property mensal() As Boolean
    Public Property executado() As Boolean
    Public Property pago_antecipado() As Boolean
    Public Property obs_pedido() As String
    Public Property obs_pagamento() As String
    Public Property itens() As List(Of Item)
End Class