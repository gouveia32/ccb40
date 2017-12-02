Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class LogDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub GravaLog(ByVal grupo As String, ByVal sub_grupo As String, ByVal descricao As String, ByVal objeto As String)
            Dim modelo As New Log()
            Dim bll As New LogBLL()

            modelo.usuario_id = My.Settings.usuarioId
            modelo.data = Now
            modelo.grupo = grupo
            modelo.sub_grupo = sub_grupo
            modelo.descricao = descricao
            modelo.objeto = objeto
            modelo.grupo = grupo

            bll.Incluir(modelo)
        End Sub

        Public Sub Insere(modelo As Log)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@usuario_id", modelo.usuario_id))
                p.Add(New MySqlParametro("@data", modelo.data))
                p.Add(New MySqlParametro("@grupo", modelo.grupo))
                p.Add(New MySqlParametro("@sub_grupo", modelo.sub_grupo))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@objeto", modelo.objeto))
                sql = "INSERT INTO log (usuario_id,data,grupo,sub_grupo,descricao,objeto) VALUES (@usuario_id,@data,@grupo,@sub_grupo,@descricao,@objeto)"
                modelo.id = bd.exeNonQuery(sql, p)

            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Log)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@usuario_id", modelo.usuario_id))
                p.Add(New MySqlParametro("@data", modelo.data))
                p.Add(New MySqlParametro("@grupo", modelo.grupo))
                p.Add(New MySqlParametro("@sub_grupo", modelo.sub_grupo))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@objeto", modelo.objeto))

                sql = "UPDATE log SET usuario_id=@usuario_id,data=@data,grupo=@grupo,sub_grupo=@sub_grupo,objeto=@objeto,descricao=@descricao WHERE id=@id"
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM log WHERE id = @id"
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Filtrar(valor As [String], Optional where As String = "") As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor <> "" Then
                If valor.Contains("|") Then
                    mValor = valor.Split("|"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(grupo LIKE '%" & s & "%' OR sub_grupo LIKE '%" & s & "%' OR descricao LIKE '%" & s & "%') OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(grupo LIKE '%" & s & "%' OR sub_grupo LIKE '%" & s & "%' OR descricao LIKE '%" & s & "%') AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (grupo LIKE '%{0:s}%' OR sub_grupo LIKE '%{0:s}%' OR descricao LIKE '%{0:s}%'", valor)
                End If
            End If

            If sWhere <> "" Then
                If where <> "" Then
                    If sWhere <> "" Then
                        sWhere &= ") AND " & where
                    Else
                        sWhere = "WHERE " & where
                    End If
                Else
                    sWhere &= ")"
                End If
            Else
                If where <> "" Then
                    If sWhere <> "" Then
                        sWhere = where
                    Else
                        sWhere = "WHERE " & where
                    End If
                End If
            End If

            sql = "SELECT log.id, usuarios.login, data, grupo, sub_grupo,descricao,objeto FROM log " _
                & "LEFT JOIN usuarios ON usuarios.id = log.usuario_id " & sWhere & " ORDER BY id DESC"
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Log
            Dim modelo As New Log()

            modelo.id = Convert.ToInt32(registro("id").ToString())
            modelo.usuario_id = Convert.ToInt32(registro("usuario_id").ToString())
            modelo.data = Convert.ToDateTime(registro("data"))
            modelo.grupo = Convert.ToString(registro("grupo"))
            modelo.sub_grupo = Convert.ToString(registro("sub_grupo"))
            modelo.descricao = Convert.ToString(registro("descricao"))
            modelo.objeto = Convert.ToString(registro("objeto"))

            Return modelo
        End Function

        Public Function CarregaModeloLog(id As Integer) As Log
            Dim modelo As New Log()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM log WHERE id = @id"
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

