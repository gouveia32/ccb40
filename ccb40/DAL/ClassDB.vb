Imports System.Collections.Generic
Imports MySql.Data.MySqlClient

Namespace DAL
    Public Class ClassBD
        Private conn As MySqlConnection
        Private comando As MySqlCommand
        Private comandoTemp As MySqlCommand
        Private adap As MySqlDataAdapter
        Private strConn As String

        Public Shared servidor As [String] = "localhost"
        Public Shared banco As [String] = "ccb"
        Public Shared usuario As [String] = "root"
        Public Shared senha As [String] = "123456"
        Public Shared StringDeConexao As [String]


        Public Sub New()
            Me.strConn = StringDeConexao

        End Sub

        Public Shared Function create() As ClassBD
            Return New ClassBD()
        End Function

        Public Function exePesquisa(query As String, Optional Param As List(Of MySqlParametro) = Nothing) As DataTable
            Dim dados As New DataTable()

            'executa a query
            Try
                Me.adap = New MySqlDataAdapter(query, Me.strConn)

                'insere os parametros na query
                If Param IsNot Nothing Then
                    For Each p As MySqlParametro In Param
                        Me.adap.SelectCommand.Parameters.AddWithValue(p.Parametro, p.Valor)
                    Next
                End If

                Me.adap.Fill(dados)
            Catch erro As Exception
                MessageBox.Show("ERRO: " & erro.ToString)
            End Try

            Me.adap.Dispose()

            Return dados
        End Function

        Public Function exeNonQuery(query As String, Optional param As List(Of MySqlParametro) = Nothing) As Integer
            Dim id As Integer = 0
            Try
                Me.conn = New MySqlConnection(Me.strConn)
                Me.conn.Open()

                Me.comando = New MySqlCommand(query, Me.conn)
                'adiciona parametros
                If param IsNot Nothing Then
                    For Each p As MySqlParametro In param
                        Me.comando.Parameters.AddWithValue(p.Parametro, p.Valor)
                    Next
                End If
                'executa a query
                Me.comando.ExecuteNonQuery()
                'Retorna o novo Id
                id = Convert.ToInt32(comando.LastInsertedId)
            Catch erro As Exception
                Throw New Exception("ERRO: " + erro.Message)
            End Try
            Me.comando.Dispose()
            Me.conn.Dispose()
            Return id
        End Function

        Public Function exeScalar(query As String, Optional param As List(Of MySqlParametro) = Nothing) As Integer
            Dim resultado As Integer = 0

            Try
                Me.conn = New MySqlConnection(Me.strConn)
                Me.conn.Open()

                Me.comando = New MySqlCommand(query, Me.conn)
                'adiciona parametros
                If param IsNot Nothing Then
                    For Each p As MySqlParametro In param
                        Me.comando.Parameters.AddWithValue(p.Parametro, p.Valor)
                    Next
                End If
                'executa a query
                Dim result As Object = comando.ExecuteScalar()
                If result IsNot Nothing Then
                    resultado = Convert.ToInt32(result)
                End If
            Catch erro As Exception
                Throw New Exception("ERRO: " + erro.Message)
            End Try

            Me.comando.Dispose()
            Me.conn.Dispose()
            Return resultado
        End Function

        Public Function Reader(query As String, Optional param As List(Of MySqlParametro) = Nothing) As MySqlDataReader
            Dim registro As MySqlDataReader = Nothing

            Try
                Me.conn = New MySqlConnection(strConn)
                Me.conn.Open()

                Me.comandoTemp = New MySqlCommand(query, conn)

                If param IsNot Nothing Then
                    For Each p As MySqlParametro In param
                        comandoTemp.Parameters.AddWithValue(p.Parametro, p.Valor)
                    Next
                End If
                registro = comandoTemp.ExecuteReader()
            Catch erro As Exception
                Throw New Exception("ERRO: " + erro.Message)
            End Try
            Return registro
        End Function

        Public Function Fill(query As String, Optional Param As List(Of MySqlParametro) = Nothing) As MySqlDataAdapter
            Dim dados As New DataTable()

            'executa a query
            Try
                Me.adap = New MySqlDataAdapter(query, Me.strConn)

                'insere os parametros na query
                If Param IsNot Nothing Then
                    For Each p As MySqlParametro In Param
                        Me.adap.SelectCommand.Parameters.AddWithValue(p.Parametro, p.Valor)
                    Next
                End If
            Catch erro As Exception
                Throw New Exception("ERRO: " & erro.ToString)
            End Try

            ' this.adap.Dispose();

            Return adap
        End Function

        Public Function TestarConexao() As Boolean
            Try
                Me.conn = New MySqlConnection(Me.strConn)
                Me.conn.Open()
                Return True
            Catch erro As Exception
                Throw New Exception("Falha na conexão com o BD!")
            End Try

            Me.comando.Dispose()
            Me.conn.Dispose()
        End Function


        Public Sub FecharReader(r As MySqlDataReader)
            r.Close()
            Me.comandoTemp.Dispose()
            Me.conn.Dispose()
        End Sub
    End Class
End Namespace