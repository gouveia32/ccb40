Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class FluxoCaixaDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As FluxoCaixa)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@data", modelo.data))
                p.Add(New MySqlParametro("@ativo", modelo.ativo))
                p.Add(New MySqlParametro("@data_real", modelo.data_real))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@credito", modelo.credito))
                p.Add(New MySqlParametro("@debito", modelo.debito))
                p.Add(New MySqlParametro("@tipo_pagamento", modelo.tipo_pagamento))

                sql = "INSERT INTO fluxo_caixa (data,ativo,data_real,descricao,credito,debito,tipo_pagamento) " _
                    & "VALUES (@data,@ativo,@data_real,@descricao,@credito,@debito,@tipo_pagamento)"
                modelo.id = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "FluxoCaixa", "Cadastrado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "FluxoCaixa", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As FluxoCaixa)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@data", modelo.data))
                p.Add(New MySqlParametro("@ativo", modelo.ativo))
                p.Add(New MySqlParametro("@data_real", modelo.data_real))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@credito", modelo.credito))
                p.Add(New MySqlParametro("@debito", modelo.debito))
                p.Add(New MySqlParametro("@tipo_pagamento", modelo.tipo_pagamento))

                sql = "UPDATE fluxo_caixa SET data=@data,ativo=@ativo,data_real=@data_real,descricao=@descricao, " _
                    & "credito=@credito,debito=@debito,tipo_pagamento=@tipo_pagamento " _
                    & "WHERE id=@id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "FluxoCaixa", "Alterado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "FluxoCaixa", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM fluxo_caixa WHERE id=@id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "FluxoCaixa", "Excluído", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "FluxoCaixa", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As FluxoCaixa
            Dim modelo As New FluxoCaixa()
            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.id = Convert.ToInt32(registro("id"))
            modelo.data = Convert.ToDateTime(registro("data"))
            modelo.ativo = Convert.ToBoolean(registro("ativo"))
            modelo.data_real = Convert.ToDateTime(registro("data_real"))
            modelo.descricao = Convert.ToString(registro("descricao"))
            modelo.credito = Convert.ToDecimal(registro("credito"))
            modelo.debito = Convert.ToDecimal(registro("debito"))
            modelo.tipo_pagamento = Convert.ToInt32(registro("tipo_pagamento"))
            Return modelo
        End Function

        Public Function CarregaModeloFluxoCaixa(id As Integer) As FluxoCaixa
            Dim modelo As New FluxoCaixa()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM fluxo_caixa WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function CarregaPorData(ByVal DataCaixa As Date) As DataTable
            Dim tabela As New DataTable()

            sql = String.Format("SELECT L.id, L.data, L.ativo, L.descricao, P.descricao AS tipo_pagamento, L.credito, L.debito, S.Soma AS saldo FROM fluxo_caixa AS L INNER JOIN (SELECT L2.Id, SUM(L1.credito - L1.debito) As Soma FROM fluxo_caixa As L1  INNER JOIN fluxo_caixa As L2 ON (L1.Id<=L2.Id  AND L1.DATA = L2.DATA) GROUP BY L2.Id) AS S ON L.Id = S.Id LEFT JOIN tipo_pagamento AS P ON L.tipo_pagamento = P.id WHERE data='{0:yyyy-MM-dd}' ORDER BY L.Id;", DataCaixa)
            Return bd.exePesquisa(sql, Nothing)
        End Function

    End Class

End Namespace