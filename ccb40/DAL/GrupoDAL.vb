Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class GrupoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Grupo)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@grupo", modelo.local))
                sql = "INSERT INTO grupos(grupo) VALUES (@grupo)"
                modelo.id = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Grupo", "Cadastrado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Grupo", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Grupo)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@grupo", modelo.local))

                sql = "UPDATE grupos SET grupo = @grupo WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Grupo", "Alterado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Grupo", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM grupos WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Grupo", "Excluído", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Grupo", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor.Contains("|") Then
                mValor = valor.Split("|"c)
                sWhere = "WHERE grupo LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%'")) & s) + "%' OR grupo LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 15)
            ElseIf valor.Contains("&") Then
                mValor = valor.Split("&"c)
                sWhere = "WHERE (grupo LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%'")) & s) + "%') AND (grupo LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 17)
            Else
                sWhere = String.Format("WHERE grupo LIKE '%{0:s}%'", valor)
            End If

            sql = Convert.ToString("SELECT id, grupo FROM grupos ") & sWhere
            Return bd.exePesquisa(sql, p)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Grupo
            Dim modelo As New Grupo()

            modelo.id = Convert.ToInt32(registro("id").ToString())
            modelo.local = Convert.ToString(registro("grupo"))

            Return modelo
        End Function

        Public Function CarregaModeloGrupo(id As Integer) As Grupo
            Dim modelo As New Grupo()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM grupos WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este

                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function TodosGrupos(Optional item As String = "") As DataTable
            Dim tabela As New DataTable()
            p = New List(Of MySqlParametro)()
            If item = "" Then
                sql = "SELECT id,grupo FROM grupos;"
            Else
                sql = (Convert.ToString("SELECT 0 AS id,'") & item) + "' AS grupo UNION SELECT id,grupo FROM grupos;"
            End If
            Return bd.exePesquisa(sql, p)
        End Function

    End Class
End Namespace

