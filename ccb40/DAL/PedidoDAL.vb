Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class PedidoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Pedido)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@empregado_id", modelo.usuario.id))
                p.Add(New MySqlParametro("@cliente_id", modelo.cliente.ID))
                p.Add(New MySqlParametro("@data_abertura", modelo.data_abertura))
                p.Add(New MySqlParametro("@data_fechamento", modelo.data_fechamento))
                p.Add(New MySqlParametro("@data_pagamento", modelo.data_pagamento))
                p.Add(New MySqlParametro("@adicional", modelo.adicional))
                p.Add(New MySqlParametro("@desconto", modelo.desconto))
                p.Add(New MySqlParametro("@pago", modelo.pago))
                p.Add(New MySqlParametro("@valor", modelo.valor))
                p.Add(New MySqlParametro("@quitado", modelo.quitado))
                p.Add(New MySqlParametro("@mensal", modelo.mensal))
                p.Add(New MySqlParametro("@executado", modelo.executado))
                p.Add(New MySqlParametro("@pago_antecipado", modelo.pago_antecipado))
                p.Add(New MySqlParametro("@obs_pedido", modelo.obs_pedido))
                p.Add(New MySqlParametro("@obs_pagamento", modelo.obs_pagamento))

                sql = "INSERT INTO pedidos (empregado_id,cliente_id,data_abertura,data_fechamento,data_pagamento,adicional,desconto,pago," _
                                       & "valor,quitado,mensal,executado,pago_antecipado,obs_pedido,obs_pagamento) " _
                    & "VALUES (@empregado_id,@cliente_id,@data_abertura,@data_fechamento,@data_pagamento,@adicional,@desconto,@pago," _
                                       & "@valor,@quitado,@mensal,@executado,@pago_antecipado,@obs_pedido,@obs_pagamento)"
                modelo.id = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Pedido", "Cadastrado", modelo.id)
                'Inclui os itens
                Dim bllI As New ItemBLL()
                For Each item As Item In modelo.itens
                    item.pedido_id = modelo.id 'Atualiza com o novo pedido cadastrado
                    bllI.Incluir(item)
                Next
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Pedido", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Pedido)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@empregado_id", modelo.usuario.id))
                p.Add(New MySqlParametro("@cliente_id", modelo.cliente.ID))
                p.Add(New MySqlParametro("@data_abertura", modelo.data_abertura))
                p.Add(New MySqlParametro("@data_fechamento", modelo.data_fechamento))
                p.Add(New MySqlParametro("@data_pagamento", modelo.data_pagamento))
                p.Add(New MySqlParametro("@adicional", modelo.adicional))
                p.Add(New MySqlParametro("@desconto", modelo.desconto))
                p.Add(New MySqlParametro("@pago", modelo.pago))
                p.Add(New MySqlParametro("@valor", modelo.valor))
                p.Add(New MySqlParametro("@quitado", modelo.quitado))
                p.Add(New MySqlParametro("@mensal", modelo.mensal))
                p.Add(New MySqlParametro("@executado", modelo.executado))
                p.Add(New MySqlParametro("@pago_antecipado", modelo.pago_antecipado))
                p.Add(New MySqlParametro("@obs_pedido", modelo.obs_pedido))
                p.Add(New MySqlParametro("@obs_pagamento", modelo.obs_pagamento))

                sql = "UPDATE pedidos SET empregado_id=@empregado_id,cliente_id=@cliente_id,data_abertura=@data_abertura,data_fechamento=@data_fechamento, " _
                    & "data_pagamento=@data_pagamento,adicional=@adicional,desconto=@desconto,pago=@pago," _
                    & "valor=@valor,quitado=@quitado,mensal=@mensal,executado=@executado,pago_antecipado=@pago_antecipado," _
                    & "obs_pedido=@obs_pedido,obs_pagamento=@obs_pagamento " _
                    & "WHERE id=@id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Pedido", "Alterado", modelo.id)

                'Atualiza itens
                Dim bllI As New ItemBLL()
                bllI.ExcluiTodosDoPedido(modelo.id) 'Apaga inicialmente todos itens do pedido
                For Each item As Item In modelo.itens
                    bllI.Incluir(item)
                Next
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Pedido", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM pedidos WHERE id=@id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Pedido", "Excluído", id)
                'Exclui os itens
                Dim bllI As New ItemBLL()
                bllI.ExcluiTodosDoPedido(id) 'Apaga todas itens do pedido
                'Exclui os as agendas de pedido
                Dim bllAP As New AgendaPedidoBLL()
                bllAP.ExcluiPorPedido(id) 'Apaga agendas do pedido
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Pedido", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As Pedido
            Dim modelo As New Pedido()
            Dim modeloU As New Usuario()
            Dim modeloC As New Cliente()

            modelo.usuario = modeloU
            modelo.cliente = modeloC
            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.id = Convert.ToInt32(registro("id"))

            If registro("data_abertura") Is DBNull.Value Then
                modelo.data_abertura = Nothing
            Else
                modelo.data_abertura = Convert.ToDateTime(registro("data_abertura"))
            End If
            If registro("data_fechamento") Is DBNull.Value Then
                modelo.data_fechamento = Nothing
            Else
                modelo.data_fechamento = Convert.ToDateTime(registro("data_fechamento"))
            End If
            If registro("data_pagamento") Is DBNull.Value Then
                modelo.data_pagamento = Nothing
            Else
                modelo.data_pagamento = Convert.ToDateTime(registro("data_pagamento"))
            End If
            modelo.adicional = Convert.ToDecimal(registro("adicional"))
            modelo.desconto = Convert.ToDecimal(registro("desconto"))
            modelo.pago = Convert.ToDecimal(registro("pago"))
            modelo.valor = Convert.ToDecimal(registro("valor"))
            modelo.quitado = Convert.ToBoolean(registro("quitado"))
            modelo.mensal = Convert.ToBoolean(registro("mensal"))
            modelo.executado = Convert.ToBoolean(registro("executado"))
            modelo.pago_antecipado = Convert.ToBoolean(registro("pago_antecipado"))

            modelo.obs_pedido = Convert.ToString(registro("obs_pedido"))
            modelo.obs_pagamento = Convert.ToString(registro("obs_pagamento"))

            modelo.usuario.id = Convert.ToInt32(registro("empregado_id"))
            modelo.cliente.ID = Convert.ToInt32(registro("cliente_id"))

            Return modelo
        End Function

        Public Function CarregaModePedido(id As Integer) As Pedido
            Dim modelo As New Pedido()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM pedidos WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
                'Carrega demias dados do usuario
                Dim bllU As New UsuarioBLL()
                modelo.usuario = bllU.CarregaUsuarioPorId(modelo.usuario.id)
                'Carrega demias dados do cliente
                Dim bllC As New ClienteBLL()
                modelo.cliente = bllC.CarregaCliente(modelo.cliente.ID)
                'Carrega os intens
                Dim bllI As New ItemBLL()
                modelo.itens = bllI.CarregaItensDoPedido(modelo.id)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function Filtrar(valor As [String], Optional where As String = "") As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor <> "" Then
                If valor.Contains("|") Then
                    mValor = valor.Split("|"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(clientes.nome LIKE '%" & s & "%' OR itens.descricao LIKE '%" & s & "%') OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE  (itens.item = 1 OR itens.item IS NULL) AND ("
                    For Each s As String In mValor
                        sWhere &= "(clientes.nome LIKE '%" & s & "%' OR itens.descricao LIKE '%" & s & "%') AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (itens.item = 1 OR itens.item IS NULL) AND (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (itens.item = 1 OR itens.item IS NULL) AND (clientes.nome LIKE '%{0:s}%' OR itens.descricao LIKE '%{0:s}%'", valor)
                End If
            End If

            If sWhere <> "" Then
                If where <> "" Then
                    If sWhere <> "" Then
                        sWhere &= ") AND " & where
                    Else
                        sWhere = "WHERE (itens.item = 1 OR itens.item IS NULL) " & where
                    End If
                Else
                    sWhere &= ")"
                End If
            Else
                If where <> "" Then
                    If sWhere <> "" Then
                        sWhere = where
                    Else
                        sWhere = "WHERE  (itens.item = 1 OR itens.item IS NULL) AND " & where
                    End If
                End If
            End If

            If sWhere.Contains("catalogos") > -1 Then
                sql = "SELECT pedidos.id as Pedido, clientes.nome as Cliente, DATE(Data_Entrega) as Entrega, " _
                    & "DATE(Data_Abertura) as Abertura, Executado, Quitado, Mensal, obs_pedido, itens.descricao as item1, valor, pago " _
                    & " FROM pedidos LEFT JOIN clientes on pedidos.cliente_id = clientes.id LEFT JOIN itens ON " _
                    & "itens.pedido_id = pedidos.id " & sWhere & " ORDER BY Pedido DESC"
            Else
                sql = "SELECT pedidos.id as Pedido, clientes.nome as Cliente, DATE(Data_Entrega) as Entrega, " _
                    & "DATE(Data_Abertura) as Abertura, Executado, Quitado, Mensal, obs_pedido, itens.descricao as item1, valor, pago " _
                    & " FROM pedidos LEFT JOIN clientes on pedidos.cliente_id = clientes.id LEFT JOIN itens ON " _
                    & "itens.pedido_id = pedidos.id " & sWhere & " ORDER BY Pedido DESC"
            End If
            Return bd.exePesquisa(sql, Nothing)
        End Function



    End Class

End Namespace