Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class EmpregadoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Empregado)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@funcao", modelo.funcao))
                p.Add(New MySqlParametro("@nascimento", modelo.nascimento))
                p.Add(New MySqlParametro("@admissao", modelo.admissao))
                p.Add(New MySqlParametro("@demissao", modelo.demissao))
                p.Add(New MySqlParametro("@endereco", modelo.endereco))
                p.Add(New MySqlParametro("@cidade", modelo.cidade))
                p.Add(New MySqlParametro("@uf", modelo.uf))
                p.Add(New MySqlParametro("@cep", modelo.cep))
                p.Add(New MySqlParametro("@telefone1", modelo.telefone1))
                p.Add(New MySqlParametro("@telefone2", modelo.telefone2))
                p.Add(New MySqlParametro("@telefone3", modelo.telefone3))
                p.Add(New MySqlParametro("@email", modelo.email))
                p.Add(New MySqlParametro("@obs", modelo.obs))
                p.Add(New MySqlParametro("@status", modelo.status))

                sql = "INSERT INTO empregados(nome,funcao,nascimento,admissao,demissao,endereco,cidade,uf,cep,telefone1,telefone2,telefone3,email,obs,status)" + "VALUES (@nome,@funcao,@nascimento,@admissao,@demissao,@endereco,@cidade,@uf,@cep,@telefone1,@telefone2,@telefone3,@email,@obs,@status)"
                modelo.ID = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Empregado", "Cadastrado", modelo.ID)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Empregado", "Erro ao Cadastrar", modelo.ID)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Empregado)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@funcao", modelo.funcao))
                p.Add(New MySqlParametro("@nascimento", modelo.nascimento))
                p.Add(New MySqlParametro("@admissao", modelo.admissao))
                p.Add(New MySqlParametro("@demissao", modelo.demissao))
                p.Add(New MySqlParametro("@endereco", modelo.endereco))
                p.Add(New MySqlParametro("@cidade", modelo.cidade))
                p.Add(New MySqlParametro("@uf", modelo.uf))
                p.Add(New MySqlParametro("@cep", modelo.cep))
                p.Add(New MySqlParametro("@telefone1", modelo.telefone1))
                p.Add(New MySqlParametro("@telefone2", modelo.telefone2))
                p.Add(New MySqlParametro("@telefone3", modelo.telefone3))
                p.Add(New MySqlParametro("@email", modelo.email))
                p.Add(New MySqlParametro("@obs", modelo.obs))
                p.Add(New MySqlParametro("@id", Convert.ToInt32(modelo.ID)))
                p.Add(New MySqlParametro("@status", modelo.status))

                sql = "UPDATE empregados SET nome=@nome,funcao=@funcao,nascimento=@nascimento,admissao=@admissao,demissao=@demissao,endereco=@endereco,cidade=@cidade,uf=@uf,cep=@cep," + "telefone1=@telefone1,telefone2=@telefone2,telefone3=@telefone3,email=@email,obs=@obs,status=@status" + " WHERE id=@id;"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Empregado", "Alterado", modelo.ID)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Empregado", "Erro ao Alterar", modelo.ID)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM empregados WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Empregado", "Excluído", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Empregado", "Erro ao Excluir", id)
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
                        sWhere &= "(nome LIKE '%" & s & "%' OR funcao LIKE '%" & s & "%') OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(nome LIKE '%" & s & "%' OR funcao LIKE '%" & s & "%') AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (nome LIKE '%{0:s}%' OR funcao LIKE '%{0:s}%'", valor)
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

            sql = "SELECT id, nome, funcao FROM empregados " & sWhere & " ORDER BY nome"
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Public Function EmpregadosAtivos() As DataTable
            Dim tabela As New DataTable()
            sql = "SELECT id, nome FROM empregados WHERE status=1 ORDER BY nome"
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Empregado
            Dim modelo As New Empregado()

            If Not registro.HasRows Then Return modelo

            modelo.ID = Convert.ToInt32(registro("id").ToString())
            modelo.nome = Convert.ToString(registro("nome"))
            modelo.funcao = Convert.ToString(registro("funcao"))
            If registro("nascimento") Is DBNull.Value Then
                modelo.nascimento = Nothing
            Else
                modelo.nascimento = Convert.ToDateTime(registro("nascimento"))
            End If

            If registro("admissao") Is DBNull.Value Then
                modelo.admissao = Nothing
            Else
                modelo.admissao = Convert.ToDateTime(registro("admissao"))
            End If
            If registro("demissao") Is DBNull.Value Then
                modelo.demissao = Nothing
            Else
                modelo.demissao = Convert.ToDateTime(registro("demissao"))
            End If


            modelo.endereco = Convert.ToString(registro("endereco"))
            modelo.cidade = Convert.ToString(registro("cidade"))
            modelo.uf = Convert.ToString(registro("uf"))
            modelo.cep = Convert.ToString(registro("cep"))
            modelo.telefone1 = Convert.ToString(registro("telefone1"))
            modelo.telefone2 = Convert.ToString(registro("telefone2"))
            modelo.telefone3 = Convert.ToString(registro("telefone3"))
            modelo.email = Convert.ToString(registro("email"))
            modelo.obs = Convert.ToString(registro("obs"))
            modelo.status = Convert.ToBoolean(registro("status"))

            Return modelo
        End Function

        Public Function CarregaEmpregado(id As Integer) As Empregado
            Dim modelo As New Empregado()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM empregados WHERE id = @id"
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
