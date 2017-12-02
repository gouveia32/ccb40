Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class ItemDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Item)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", modelo.pedido_id))
                p.Add(New MySqlParametro("@item", modelo.item))
                p.Add(New MySqlParametro("@bordado_id", modelo.bordado.id))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@data_entrega", modelo.data_entrega))
                p.Add(New MySqlParametro("@data_execucao", modelo.data_execucao))
                p.Add(New MySqlParametro("@pc_solicitadas", modelo.pc_solicitadas))
                p.Add(New MySqlParametro("@pc_entregues", modelo.pc_entregues))
                p.Add(New MySqlParametro("@pc_defeito", modelo.pc_defeito))
                p.Add(New MySqlParametro("@pc_nao_bordadas", modelo.pc_nao_bordadas))
                p.Add(New MySqlParametro("@pontos_extras", modelo.pontos_extras))
                p.Add(New MySqlParametro("@preco_por_peca", modelo.preco_por_peca))
                p.Add(New MySqlParametro("@material_id", modelo.material_id))
                p.Add(New MySqlParametro("@local_id", IIf(modelo.local_id = -1, DBNull.Value, modelo.local_id)))
                p.Add(New MySqlParametro("@lado", modelo.lado))
                p.Add(New MySqlParametro("@aplicacao", modelo.aplicacao))
                p.Add(New MySqlParametro("@cores", modelo.cores))
                p.Add(New MySqlParametro("@troca_rapida", modelo.troca_rapida))
                p.Add(New MySqlParametro("@obs", modelo.obs))
                p.Add(New MySqlParametro("@status", modelo.status))

                sql = "INSERT INTO itens (pedido_id,item,bordado_id,descricao,data_entrega,data_execucao,pc_solicitadas,pc_entregues," _
                                       & "pc_defeito,pc_nao_bordadas,pontos_extras,preco_por_peca,material_id,local_id,lado,aplicacao,cores,troca_rapida,obs,status) " _
                    & "VALUES (@pedido_id,@item,@bordado_id,@descricao,@data_entrega,@data_execucao,@pc_solicitadas,@pc_entregues," _
                                       & "@pc_defeito,@pc_nao_bordadas,@pontos_extras,@preco_por_peca,@material_id,@local_id,@lado,@aplicacao,@cores,@troca_rapida,@obs,@status)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Item", "Cadastrado", String.Format("{0}/{1}", modelo.pedido_id, modelo.item))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Item", "Erro ao Cadastrar", String.Format("{0}/{1}", modelo.pedido_id, modelo.item))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Item)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", modelo.pedido_id))
                p.Add(New MySqlParametro("@item", modelo.item))
                p.Add(New MySqlParametro("@bordado_id", modelo.bordado.id))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@data_entrega", modelo.data_entrega))
                p.Add(New MySqlParametro("@data_execucao", modelo.data_execucao))
                p.Add(New MySqlParametro("@pc_solicitadas", modelo.pc_solicitadas))
                p.Add(New MySqlParametro("@pc_entregues", modelo.pc_entregues))
                p.Add(New MySqlParametro("@pc_defeito", modelo.pc_defeito))
                p.Add(New MySqlParametro("@pc_nao_bordadas", modelo.pc_nao_bordadas))
                p.Add(New MySqlParametro("@pontos_extras", modelo.pontos_extras))
                p.Add(New MySqlParametro("@preco_por_peca", modelo.preco_por_peca))
                p.Add(New MySqlParametro("@material_id", modelo.material_id))
                p.Add(New MySqlParametro("@local_id", modelo.local_id))
                p.Add(New MySqlParametro("@lado", modelo.lado))
                p.Add(New MySqlParametro("@aplicacao", modelo.aplicacao))
                p.Add(New MySqlParametro("@cores", modelo.cores))
                p.Add(New MySqlParametro("@troca_rapida", modelo.troca_rapida))
                p.Add(New MySqlParametro("@obs", modelo.obs))
                p.Add(New MySqlParametro("@status", modelo.status))

                sql = "UPDATE itens SET bordado_id=@bordado_id,descricao=@descricao,data_entrega=@data_entrega,data_execucao=@data_execucao, " _
                    & "pc_solicitadas=@pc_solicitadas,pc_entregues=@pc_entregues,pc_defeito=@pc_defeito,pc_nao_bordadas=@pc_nao_bordadas," _
                    & "pontos_extras=@pontos_extras,preco_por_peca=@preco_por_peca,material_id=@material_id,local_id=@local_id,lado=@lado," _
                    & "aplicacao=@aplicacao,cores=@cores,troca_rapida=@troca_rapida,obs=@obs,status=@status " _
                    & "WHERE pedido_id=@pedido_id AND item=@item"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Item", "Alterado", String.Format("{0}/{1}", modelo.pedido_id, modelo.item))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Item", "Erro ao Alterar", String.Format("{0}/{1}", modelo.pedido_id, modelo.item))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(Pedido_id As Integer, item As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@Pedido_id", Pedido_id))
                p.Add(New MySqlParametro("@item", item))

                sql = "DELETE FROM itens WHERE Pedido_id=@Pedido_id AND item=@item"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Item", "Excluído", String.Format("{0}/{1}", Pedido_id, item))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Item", "Erro ao Excluir", String.Format("{0}/{1}", Pedido_id, item))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub ExcluiTodosDoPedido(Pedido_id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@Pedido_id", Pedido_id))

                sql = "DELETE FROM itens WHERE Pedido_id=@Pedido_id"
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As Item
            Dim modelo As New Item()
            Dim modeloB As New Bordado()
            Dim BLLb As New BordadoBLL()

            If Not registro.HasRows Then
                Return modelo
            End If

            modeloB = BLLb.CarregaBordado(Convert.ToInt32(registro("bordado_id")))
            modelo.bordado = modeloB


            modelo.pedido_id = Convert.ToInt32(registro("pedido_id"))
            modelo.item = Convert.ToInt32(registro("item"))
            'modelo.bordado.id = Convert.ToInt32(registro("bordado_id"))
            modelo.descricao = Convert.ToString(registro("descricao"))

            If registro("data_entrega") Is DBNull.Value Then
                modelo.data_entrega = Nothing
            Else
                modelo.data_entrega = Convert.ToDateTime(registro("data_entrega"))
            End If
            If registro("data_execucao") Is DBNull.Value Then
                modelo.data_execucao = Nothing
            Else
                modelo.data_execucao = Convert.ToDateTime(registro("data_execucao"))
            End If

            modelo.pc_solicitadas = Convert.ToInt32(registro("pc_solicitadas"))
            modelo.pc_entregues = Convert.ToInt32(registro("pc_entregues"))
            modelo.pc_nao_bordadas = Convert.ToInt32(registro("pc_nao_bordadas"))
            modelo.pc_defeito = Convert.ToInt32(registro("pc_defeito"))
            modelo.pontos_extras = Convert.ToInt32(registro("pontos_extras"))
            modelo.preco_por_peca = Convert.ToDecimal(registro("preco_por_peca"))
            modelo.material_id = Convert.ToInt32(registro("material_id"))

            Dim i As Integer

            If Integer.TryParse(registro("local_id").ToString(), i) Then
                modelo.local_id = i
            Else
                modelo.local_id = -1
            End If

            If Integer.TryParse(registro("lado").ToString(), i) Then
                modelo.lado = i
            Else
                modelo.lado = -1
            End If

            modelo.aplicacao = Convert.ToInt32(registro("aplicacao"))
            modelo.cores = Convert.ToInt32(registro("cores"))
            modelo.troca_rapida = Convert.ToInt32(registro("troca_rapida"))
            modelo.obs = Convert.ToString(registro("obs"))
            modelo.status = Convert.ToBoolean(registro("status"))

            Return modelo
        End Function

        Public Function CarregaModeloItem(pedido_id As Integer, item As Integer) As Item
            Dim modelo As New Item()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", pedido_id))
                p.Add(New MySqlParametro("@item", item))
                sql = "SELECT * FROM itens WHERE pedido_id = @pedido_id AND item=@item"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function CarregaItensDoPedido(pedido_id As Integer) As List(Of Item)
            Dim modeloI As New Item()
            Dim bllB As New BordadoBLL()

            Dim ret As List(Of Item) = New List(Of Item)()

            Dim registro As MySqlDataReader = Nothing
            Try

                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", pedido_id))
                sql = "SELECT * FROM itens " _
                    & "WHERE pedido_id = @pedido_id"
                registro = bd.Reader(sql, p)
                While registro.Read()

                    'Dim modeloB As New Bordado()
                    'modeloI.bordado = modeloB
                    modeloI = BancoParaModelo(registro)
                    'modeloI.bordado = bllB.CarregaBordado(modeloI.bordado.id)

                    ret.Add(modeloI)
                End While
            Catch ex As Exception
            Finally
                bd.FecharReader(registro)
            End Try

            Return ret
        End Function

        Public Function ItensDoPedido(pedido_id As Integer) As DataTable
            Dim tabela As New DataTable()
            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@pedido_id", pedido_id))
            sql = "SELECT item, " _
                               & "itens.descricao, " _
                               & "bordados.id as Bordado_Id, " _
                               & "bordados.Arquivo, " _
                               & "bordados.descricao as Bordado_Descricao, " _
                               & "bordados.imagem, " _
                               & "pc_entregues - pc_defeito - pc_nao_bordadas as qtde, " _
                               & "preco_por_peca, " _
                               & "pontos_extras, " _
                               & "pontos, " _
                               & "pc_solicitadas, " _
                               & "pc_entregues, " _
                               & "pc_defeito, " _
                               & "pc_nao_bordadas, " _
                               & "preco, " _
                               & "local_id, " _
                               & "lado, " _
                               & "data_entrega, " _
                               & "data_execucao, " _
                               & "obs, " _
                               & "(pc_entregues - pc_defeito - pc_nao_bordadas) * preco_por_peca as total " _
                               & "FROM itens LEFT JOIN bordados ON itens.bordado_id = bordados.id " _
                               & "WHERE pedido_id=@pedido_id" _
                               & " ORDER BY Item "
            Return bd.exePesquisa(sql, p)
        End Function
    End Class

End Namespace