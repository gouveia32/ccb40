Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class LocalDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Local)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@local", modelo.local))

                sql = "INSERT INTO log (local) VALUES (@local)"
                modelo.id = bd.exeNonQuery(sql, p)

            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Local)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@local", modelo.local))

                sql = "UPDATE locais SET local=@local WHERE id=@id"
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM locais WHERE id = @id"
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As Local
            Dim modelo As New Local()

            modelo.id = Convert.ToInt32(registro("id").ToString())
            modelo.local = Convert.ToInt32(registro("local").ToString())

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
                        sWhere &= "(local LIKE '%" & s & "%' OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(local LIKE '%" & s & "%' AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (local LIKE '%{0:s}%'", valor)
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

            sql = "SELECT * FROM locais " & sWhere
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Public Function CarregaModeloLog(id As Integer) As Local
            Dim modelo As New Local()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM locais WHERE id = @id"
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

