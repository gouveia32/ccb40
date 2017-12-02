
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class FornecedorDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Fornecedor)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@contato_funcao", modelo.contato_funcao))
                p.Add(New MySqlParametro("@contato_nome", modelo.contato_nome))
                p.Add(New MySqlParametro("@cgc_cpf", modelo.cgc_cpf))
                p.Add(New MySqlParametro("@inscr_estadual", modelo.inscr_estadual))
                p.Add(New MySqlParametro("@endereco", modelo.endereco))
                p.Add(New MySqlParametro("@cidade", modelo.cidade))
                p.Add(New MySqlParametro("@estado", modelo.estado))
                p.Add(New MySqlParametro("@cep", modelo.cep))
                p.Add(New MySqlParametro("@telefone1", modelo.telefone1))
                p.Add(New MySqlParametro("@telefone2", modelo.telefone2))
                p.Add(New MySqlParametro("@telefone3", modelo.telefone3))
                p.Add(New MySqlParametro("@email", modelo.email))
                p.Add(New MySqlParametro("@obs", modelo.obs))

                sql = "INSERT INTO fornecedores(nome,contato_funcao,contato_nome,cgc_cpf,inscr_estadual,endereco,cidade,estado,cep,telefone1,telefone2,telefone3,email,obs)" + "VALUES (@nome,@contato_funcao,@contato_nome,@cgc_cpf,@inscr_estadual,@endereco,@cidade,@estado,@cep,@telefone1,@telefone2,@telefone3,@email,@obs)"
                modelo.ID = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Fornecedor", "Cadastrado", modelo.ID)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Fornecedor", "Erro ao Cadastrar", modelo.ID)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Fornecedor)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@contato_funcao", modelo.contato_funcao))
                p.Add(New MySqlParametro("@contato_nome", modelo.contato_nome))
                p.Add(New MySqlParametro("@cgc_cpf", modelo.cgc_cpf))
                p.Add(New MySqlParametro("@inscr_estadual", modelo.inscr_estadual))
                p.Add(New MySqlParametro("@endereco", modelo.endereco))
                p.Add(New MySqlParametro("@cidade", modelo.cidade))
                p.Add(New MySqlParametro("@estado", modelo.estado))
                p.Add(New MySqlParametro("@cep", modelo.cep))
                p.Add(New MySqlParametro("@telefone1", modelo.telefone1))
                p.Add(New MySqlParametro("@telefone2", modelo.telefone2))
                p.Add(New MySqlParametro("@telefone3", modelo.telefone3))
                p.Add(New MySqlParametro("@email", modelo.email))
                p.Add(New MySqlParametro("@obs", modelo.obs))
                p.Add(New MySqlParametro("@id", Convert.ToInt32(modelo.ID)))

                sql = "UPDATE fornecedores SET nome=@nome,contato_funcao=@contato_funcao,contato_nome=@contato_nome," + "cgc_cpf=@cgc_cpf,inscr_estadual=@inscr_estadual,endereco=@endereco,cidade=@cidade,estado=@estado,cep=@cep," + "telefone1=@telefone1,telefone2=@telefone2,telefone3=@telefone3,email=@email,obs=@obs" + " WHERE id=@id;"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Fornecedor", "Alterado", modelo.ID)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Fornecedor", "Erro ao Alterar", modelo.ID)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM fornecedores WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Fornecedor", "Excluído", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Fornecedor", "Erro ao Excluir", id)
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
                        sWhere &= "(nome LIKE '%" & s & "%' OR contato_nome LIKE '%" & s & "%') OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(nome LIKE '%" & s & "%' OR contato_nome LIKE '%" & s & "%') AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (nome LIKE '%{0:s}%' OR contato_nome LIKE '%{0:s}%'", valor)
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

            sql = "SELECT id, nome, contato_nome, telefone1 FROM fornecedores " & sWhere & " ORDER BY nome"
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Fornecedor
            Dim modelo As New Fornecedor()

            If Not registro.HasRows Then Return modelo

            modelo.ID = Convert.ToInt32(registro("id").ToString())
            modelo.nome = Convert.ToString(registro("nome"))
            modelo.contato_funcao = Convert.ToString(registro("contato_funcao"))
            modelo.contato_nome = Convert.ToString(registro("contato_nome"))
            modelo.inscr_estadual = Convert.ToString(registro("inscr_estadual"))
            modelo.cgc_cpf = Convert.ToString(registro("cgc_cpf"))
            modelo.endereco = Convert.ToString(registro("endereco"))
            modelo.cidade = Convert.ToString(registro("cidade"))
            modelo.estado = Convert.ToString(registro("estado"))
            modelo.cep = Convert.ToString(registro("cep"))
            modelo.telefone1 = Convert.ToString(registro("telefone1"))
            modelo.telefone2 = Convert.ToString(registro("telefone2"))
            modelo.telefone3 = Convert.ToString(registro("telefone3"))
            modelo.email = Convert.ToString(registro("email"))
            modelo.obs = Convert.ToString(registro("obs"))

            Return modelo
        End Function

        Public Function CarregaFornecedor(id As Integer) As Fornecedor
            Dim modelo As New Fornecedor()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM fornecedores WHERE id = @id"
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
