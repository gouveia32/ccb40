
Imports System.Collections.Generic
Imports ccb40.BLL
Imports MySql.Data.MySqlClient

Namespace DAL
    Public Class UsuarioDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Usuario)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@login", modelo.login))
                p.Add(New MySqlParametro("@senha", modelo.senha))

                sql = "INSERT INTO usuarios(login, senha) VALUES(@nome, @senha)"
                modelo.id = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Usuario", "Cadastrado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Usuario", "Erro ao cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Usuario)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@nome", modelo.login))
                p.Add(New MySqlParametro("@senha", modelo.senha))

                sql = "UPDATE usuarios SET login = @login, senha = @senha WHERE id = @id"
                bllLog.GravaLog("Cadastro", "Usuario", "Alterado", modelo.id)
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Usuario", "Erro ao Alterar", modelo.id)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM usuarios WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Usuario", "Excluído", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Usuario", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Pesquisa(valor As String) As DataTable
            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@pesquisa", (Convert.ToString("%") & valor) + "%"))
            sql = "SELECT * FROM usuarios WHERE login LIKE @pesquisa"

            Return bd.exePesquisa(sql, p)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Usuario
            Dim modelo As New Usuario()

            If Not registro.HasRows Then Return modelo
            modelo.id = Convert.ToInt32(registro("id"))
            modelo.email = Convert.ToString(registro("email"))
            modelo.login = Convert.ToString(registro("login"))
            modelo.senha = Convert.ToString(registro("senha"))
            modelo.nome = Convert.ToString(registro("nome"))
            modelo.nivel = Convert.ToInt32(registro("nivel").ToString)
            modelo.form_inicial = Convert.ToString(registro("form_inicial"))
            Return modelo

        End Function

        Public Function CarregaUsuarioPorId(id As Integer) As Usuario
            Dim modelo As New Usuario()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM usuarios WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try

            Return modelo
        End Function

        Public Function CarregaUsuario(login As String, senha As String) As Usuario
            Dim modelo As New Usuario()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@login", login))
                p.Add(New MySqlParametro("@senha", senha))
                sql = "SELECT * FROM usuarios WHERE login = @login AND senha = @senha"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try

            Return modelo
        End Function

        Public Function verifica(us As Usuario) As Integer
            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@login", us.login))
            p.Add(New MySqlParametro("@senha", us.senha))

            sql = "SELECT COUNT(id) FROM usuarios WHERE login = @login AND senha = @senha"

            Return bd.exeScalar(sql, p)
        End Function

        Public Function Usuarios() As DataTable
            Dim tabela As New DataTable()
            sql = "SELECT id, login FROM usuarios ORDER BY login"
            Return bd.exePesquisa(sql, Nothing)
        End Function

    End Class
End Namespace
