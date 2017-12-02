
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class CatalogoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub


        Public Sub Insere(modelo As Catalogo)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@bordado_id", modelo.bordado_id))
                sql = "INSERT INTO catalogos(nome,bordado_id) VALUES (@nome,@bordado_id)"
                modelo.id = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Catalogo", "Cadastrado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Catalogo", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Catalogo)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@bordado_id", modelo.bordado_id))

                sql = "UPDATE catalogos SET nome=@nome,bordado_id=@bordado_id WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Catalogo", "Alterado", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Catalogo", "Erro Ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Excluir(nome As String, Optional bordado_id As Integer = 0)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@nome", nome))
                p.Add(New MySqlParametro("@bordado_id", bordado_id))

                If bordado_id = 0 Then
                    sql = "DELETE FROM catalogos WHERE nome=@nome"
                Else
                    sql = "DELETE FROM catalogos WHERE nome=@nome AND bordado_id=@bordado_id"
                End If

                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Catalogo", "Excluído", String.Format("{0} ({1})", nome, bordado_id))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Catalogo", "Erro ao Excluir", String.Format("{0} ({1})", nome, bordado_id))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor.Contains("|") Then
                mValor = valor.Split("|"c)
                sWhere = "WHERE nome LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%'")) & s) + "%' OR nome LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 15)
            ElseIf valor.Contains("&") Then
                mValor = valor.Split("&"c)
                sWhere = "WHERE (nome LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%'")) & s) + "%') AND (grupo LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 17)
            Else
                sWhere = String.Format("WHERE nome LIKE '%{0:s}%'", valor)
            End If

            sql = Convert.ToString("SELECT id, nome, bordado_id FROM catalogos ") & sWhere
            Return bd.exePesquisa(sql, p)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Catalogo
            Dim modelo As New Catalogo()

            modelo.id = Convert.ToInt32(registro("id").ToString())
            modelo.nome = Convert.ToString(registro("nome"))
            modelo.bordado_id = Convert.ToInt32(registro("bordado_id"))

            Return modelo
        End Function

        ''' <Carrega um Grupo >
        ''' 
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function CarregaModeloCatalogo(id As Integer) As Catalogo
            Dim modelo As New Catalogo()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM catalogos WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="bordado_id"></param>
        ''' <returns></returns>
        Public Function CarregaCatalogosDoBordado(bordado_id As Integer) As DataTable
            Dim tabela As New DataTable()
            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@bordado_id", bordado_id))
            sql = "SELECT nome FROM catalogos WHERE bordado_id = @bordado_id"
            Return bd.exePesquisa(sql, p)
        End Function

        Public Function TodosCatalogos(Optional item As String = "") As DataTable
            Dim tabela As New DataTable()
            p = New List(Of MySqlParametro)()
            If item = "" Then
                sql = "SELECT nome  FROM catalogos GROUP BY nome;"
            Else
                sql = "SELECT '" & item & "' AS nome UNION SELECT nome FROM catalogos GROUP BY nome;"
            End If
            Return bd.exePesquisa(sql, p)
        End Function

        Public Function ExisteCatalogo(ByVal cat As String, Optional bordado_id As Integer = 0) As Boolean
            Dim registro As MySqlDataReader = Nothing

            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@bordado_id", bordado_id))
            p.Add(New MySqlParametro("@nome", cat))

            If bordado_id = 0 Then
                sql = "SELECT id FROM catalogos WHERE nome=@nome;"
            Else
                sql = "SELECT id FROM catalogos WHERE bordado_id=@bordado_id AND nome=@nome;"
            End If

            registro = bd.Reader(sql, p)

            Return registro.HasRows

        End Function
    End Class
End Namespace
