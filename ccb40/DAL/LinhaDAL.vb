Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class LinhaDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Linha)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@codigo", modelo.codigo))
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@material_nome", modelo.material_nome))
                p.Add(New MySqlParametro("@material_fabricante", modelo.material_fabricante))
                p.Add(New MySqlParametro("@material_tipo", modelo.material_tipo))
                p.Add(New MySqlParametro("@cor", modelo.cor))
                p.Add(New MySqlParametro("@estoque_1", modelo.estoque_1))
                p.Add(New MySqlParametro("@estoque_2", modelo.estoque_2))
                p.Add(New MySqlParametro("@minimo", modelo.minimo))
                p.Add(New MySqlParametro("@pedido", modelo.pedido))

                sql = "INSERT INTO linhas(codigo,nome,material_nome,material_fabricante,material_tipo,cor,@estoque_1,estoque_2,minimo,pedido) " _
                    & "VALUES (@codigo,@nome,@material_nome,@material_fabricante,@material_tipo,@cor,@estoque_1,@estoque_2,@minimo,@pedido)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Linha", "Cadastrado", modelo.codigo)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Linha", "Erro ao Cadastrar", modelo.codigo)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Linha)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@codigo", modelo.codigo))
                p.Add(New MySqlParametro("@nome", modelo.nome))
                p.Add(New MySqlParametro("@material_nome", modelo.material_nome))
                p.Add(New MySqlParametro("@material_fabricante", modelo.material_fabricante))
                p.Add(New MySqlParametro("@material_tipo", modelo.material_tipo))
                p.Add(New MySqlParametro("@cor", modelo.cor))
                p.Add(New MySqlParametro("@estoque_1", modelo.estoque_1))
                p.Add(New MySqlParametro("@estoque_2", modelo.estoque_2))
                p.Add(New MySqlParametro("@minimo", modelo.minimo))
                p.Add(New MySqlParametro("@pedido", modelo.pedido))

                sql = "UPDATE linhas SET nome=@nome,material_nome=@material_nome,material_fabricante=@material_fabricante," _
                    & "material_tipo=@material_tipo,cor=@cor,estoque_1=@estoque_1,estoque_2=@estoque_2,minimo=@minimo,pedido=@pedido WHERE codigo = @codigo"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Linha", "Cadastrado", modelo.codigo)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Linha", "Erro ao Alterar", modelo.codigo)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(codigo As String)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@codigo", codigo))

                sql = "DELETE FROM linhas WHERE id = @codigo"
                bllLog.GravaLog("Cadastro", "Linha", "Excluída", codigo)
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Linha", "Erro ao Excluir", codigo)
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
                        sWhere &= "(nome LIKE '%" & s & "%' OR codigo LIKE '%" & s & "%') OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(nome LIKE '%" & s & "%' OR codigo LIKE '%" & s & "%') AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (nome LIKE '%{0:s}%' OR codigo LIKE '%{0:s}%'", valor)
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
            sql = Convert.ToString("SELECT Codigo, Nome, Estoque_1, Estoque_2, Minimo, Cor FROM linhas ") & sWhere
            Return bd.exePesquisa(sql, Nothing)
        End Function


        Private Function BancoParaModelo(registro As MySqlDataReader) As Linha
            Dim modelo As New Linha()
            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.codigo = Convert.ToString(registro("codigo"))
            modelo.nome = Convert.ToString(registro("nome"))
            modelo.material_nome = Convert.ToString(registro("material_nome"))
            modelo.material_fabricante = Convert.ToString(registro("material_fabricante"))
            modelo.material_tipo = Convert.ToString(registro("material_tipo"))
            modelo.cor = Convert.ToInt32(registro("cor"))
            modelo.estoque_1 = Convert.ToInt32(registro("estoque_1"))
            modelo.estoque_2 = Convert.ToInt32(registro("estoque_2"))
            modelo.minimo = Convert.ToInt32(registro("minimo"))
            modelo.pedido = Convert.ToInt32(registro("pedido"))

            Return modelo
        End Function

        Public Function CarregaModeloLinha(codigo As String) As Linha
            Dim modelo As New Linha()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@codigo", codigo))
                sql = "SELECT * FROM linhas WHERE codigo = @codigo"
                registro = bd.Reader(sql, p)

                If registro.HasRows Then
                    registro.Read()

                    'Le o primeiro registro, como é chave única só existe este
                    modelo = BancoParaModelo(registro)
                End If

            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function LinhasNoBordado(bordado_id As Integer) As DataTable
            Dim tabela As New DataTable()
            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@bordado_id", bordado_id))
            sql = "SELECT seq, linhas.codigo, cor, linhas.nome, pontos, metragem FROM linhas_utilizadas LEFT JOIN linhas ON linhas.codigo = linhas_utilizadas.linha_id WHERE bordado_id = @bordado_id"
            Return bd.exePesquisa(sql, p)
        End Function

    End Class
End Namespace
