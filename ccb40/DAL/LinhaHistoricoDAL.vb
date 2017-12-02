Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class LinhaHistoricoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As LinhaHistorico)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@linha_id", modelo.linha_id))
                p.Add(New MySqlParametro("@data", modelo.data))
                p.Add(New MySqlParametro("@acao", modelo.acao))
                p.Add(New MySqlParametro("@est1_anterior", modelo.est1_anterior))
                p.Add(New MySqlParametro("@est1_atual", modelo.est1_atual))
                p.Add(New MySqlParametro("@est2_anterior", modelo.est2_anterior))
                p.Add(New MySqlParametro("@est2_atual", modelo.est2_atual))

                sql = "INSERT INTO linhas_historico (linha_id,data,acao,est1_anterior,est1_atual,est2_anterior,est2_atual) " _
                    & "VALUES (@linha_id,@data,@acao,@est1_anterior,@est1_atual,@est2_anterior,@est2_atual)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "LinhaHistorico", "Cadastrada", modelo.linha_id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "LinhaHistorico", "Erro ao Cadastrar", modelo.linha_id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As LinhaHistorico)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@linha_id", modelo.linha_id))
                p.Add(New MySqlParametro("@data", modelo.data))
                p.Add(New MySqlParametro("@acao", modelo.acao))
                p.Add(New MySqlParametro("@est1_anterior", modelo.est1_anterior))
                p.Add(New MySqlParametro("@est1_atual", modelo.est1_atual))
                p.Add(New MySqlParametro("@est2_anterior", modelo.est2_anterior))
                p.Add(New MySqlParametro("@est2_atual", modelo.est2_atual))

                sql = "UPDATE linhas SET data=@data,acao=@acao,est1_anterior=@est1_anterior," _
                    & "est1_atual=@est1_atual,est2_anterior=@est2_anterior,est2_atual=@est2_atual WHERE linha_id = @linha_id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "LinhaHistorico", "Alterada", modelo.linha_id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "LinhaHistorico", "Erro ao Alterar", modelo.linha_id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(linha_id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@linha_id", linha_id))

                sql = "DELETE FROM linhas_historico WHERE linha_id = @linha_id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "LinhaHistorico", "Excluída", linha_id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "LinhaHistorico", "Erro ao Excluir", linha_id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Filtrar(valor As [String], Optional where As [String] = "") As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor.Contains("|") Then
                mValor = valor.Split("|"c)
                sWhere = "WHERE data LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%'")) & s) + "%' OR acao LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 15)
            ElseIf valor.Contains("&") Then
                mValor = valor.Split("&"c)
                sWhere = "WHERE (data LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%'")) & s) + "%') AND (acao LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 17)
            Else
                sWhere = String.Format("WHERE acao LIKE '%{0:s}%'", valor)
            End If
            If where <> "" Then
                sWhere += " And " + where
            Else
                sWhere += ";"
            End If

            sql = (Convert.ToString("SELECT linha_id,DATE_FORMAT(data,'%Y_%m') AS mes, " + "SUM(IF(acao='Baixa',(Est1_Anterior-Est1_Atual),0))+SUM(IF(acao='Baixa',(Est2_Anterior-Est2_Atual),0)) AS uso, " + "SUM(IF(acao='Entrada',(Est1_Atual-Est1_Anterior),0))+SUM(IF(acao='Entrada',(Est2_Atual-Est2_Anterior),0)) AS compra " + "FROM linhas_historico ") & sWhere) + " GROUP BY mes;"
            Return bd.exePesquisa(sql, p)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As LinhaHistorico
            Dim modelo As New LinhaHistorico()
            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.linha_id = Convert.ToString(registro("linha_id").ToString())
            modelo.data = Convert.ToDateTime(registro("data"))
            modelo.acao = Convert.ToString(registro("acao"))
            modelo.est1_anterior = Convert.ToInt32(registro("est1_anterior"))
            modelo.est1_atual = Convert.ToInt32(registro("est1_atual"))
            modelo.est2_anterior = Convert.ToInt32(registro("est2_anterior"))
            modelo.est2_atual = Convert.ToInt32(registro("est2_atual"))

            Return modelo
        End Function

        Public Function CarregaModeloLinha(linha_id As Integer) As LinhaHistorico
            Dim modelo As New LinhaHistorico()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@linha_id", linha_id))
                sql = "SELECT * FROM linhas_historico WHERE linha_id = @linha_id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function CarregaLinhaHistorico(linha_id As Integer) As LinhaHistorico
            Dim modelo As New LinhaHistorico()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@linha_id", linha_id))
                sql = "SELECT DATE_FORMAT(data,'%Y_%m') AS mes,  " + "SUM(IF(acao='Entrada',(Est1_Atual-Est1_Anterior),0))+SUM(IF(acao='Entrada',(Est2_Atual-Est2_Anterior),0)) AS compra, " + "SUM(IF(acao='Baixa',(Est1_Anterior-Est1_Atual),0))+SUM(IF(acao='Baixa',(Est2_Anterior-Est2_Atual),0)) AS uso " + "FROM linhas_historico " + "WHERE linha_id = @linha_id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este

                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function
    End Class

End Namespace