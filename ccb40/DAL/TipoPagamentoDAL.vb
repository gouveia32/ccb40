Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class TipoPagamentoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As TipoPagamento
            Dim modelo As New TipoPagamento()

            modelo.id = Convert.ToInt32(registro("id").ToString())
            modelo.codigo = Convert.ToString(registro("codigo"))
            modelo.descricao = Convert.ToString(registro("descricao"))

            Return modelo
        End Function

        Public Sub Insere(modelo As TipoPagamento)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@codigo", modelo.codigo))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                sql = "INSERT INTO tipo_pagamento (codigo,data,descricao) VALUES (@codigo,@descricao)"
                modelo.id = bd.exeNonQuery(sql, p)

                bllLog.GravaLog("Tabela", "TipoPagamento", "Gravado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Tabela", "TipoPagamento", "Erro ao Gravar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As TipoPagamento)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@codigo", modelo.codigo))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))

                sql = "UPDATE tipo_pagamento SET codigo=@codigo,descricao=@descricao WHERE id=@id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Tabela", "TipoPagamento", "Alterado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Tabela", "TipoPagamento", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM tipo_pagamento WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Tabela", "TipoPagamento", "Excluído", id)
            Catch erro As Exception
                bllLog.GravaLog("Tabela", "TipoPagamento", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function CarregaTipoPagamento(id As Integer) As TipoPagamento
            Dim modelo As New TipoPagamento()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM tipo_pagamento WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function TiposPagamento() As DataTable
            Dim tabela As New DataTable()

            p = New List(Of MySqlParametro)()
            sql = "SELECT * FROM tipo_pagamento"
            Return bd.exePesquisa(sql, Nothing)
        End Function


    End Class
End Namespace
