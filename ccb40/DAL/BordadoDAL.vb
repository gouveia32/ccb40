Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class BordadoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As Bordado)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@arquivo", modelo.arquivo))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@caminho", modelo.caminho))
                p.Add(New MySqlParametro("@disquete", modelo.disquete))
                p.Add(New MySqlParametro("@bastidor", modelo.bastidor))
                p.Add(New MySqlParametro("@grupo_id", modelo.grupo_id))
                p.Add(New MySqlParametro("@preco", modelo.preco))
                p.Add(New MySqlParametro("@pontos", modelo.pontos))
                p.Add(New MySqlParametro("@cores", modelo.cores))
                p.Add(New MySqlParametro("@largura", modelo.largura))
                p.Add(New MySqlParametro("@altura", modelo.altura))
                p.Add(New MySqlParametro("@aprovado", modelo.aprovado))
                p.Add(New MySqlParametro("@metragem", modelo.metragem))
                p.Add(New MySqlParametro("@imagem", modelo.imagem))
                p.Add(New MySqlParametro("@obs_publica", modelo.obs_publica))
                p.Add(New MySqlParametro("@obs_Restrita", modelo.obs_Restrita))

                sql = "INSERT INTO bordados(arquivo,descricao,caminho,disquete,bastidor,grupo_id,preco,pontos,cores,largura,altura,aprovado,metragem,imagem,obs_publica,obs_Restrita)" _
                    & "VALUES (@arquivo,@descricao,@caminho,@disquete,@bastidor,@grupo_id,@preco,@pontos,@cores,@largura,@altura,@aprovado,@metragem,@imagem,@obs_publica,@obs_Restrita)"
                modelo.id = bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Bordado", "Cadastrado", modelo.id)
                'Inclui as  LinhasUtilizadas
                Dim BLLlu As New LinhaUtilizadaBLL
                For Each lu As LinhaUtilizada In modelo.LinhasUtilizadas
                    lu.bordado_id = modelo.id 'Atualiza com o novo bordado cadastrado
                    BLLlu.Incluir(lu)
                Next
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Bordado", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As Bordado)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@arquivo", modelo.arquivo))
                p.Add(New MySqlParametro("@descricao", modelo.descricao))
                p.Add(New MySqlParametro("@caminho", modelo.caminho))
                p.Add(New MySqlParametro("@disquete", modelo.disquete))
                p.Add(New MySqlParametro("@bastidor", modelo.bastidor))
                p.Add(New MySqlParametro("@grupo_id", modelo.grupo_id))
                p.Add(New MySqlParametro("@preco", modelo.preco))
                p.Add(New MySqlParametro("@pontos", modelo.pontos))
                p.Add(New MySqlParametro("@cores", modelo.cores))
                p.Add(New MySqlParametro("@largura", modelo.largura))
                p.Add(New MySqlParametro("@altura", modelo.altura))
                p.Add(New MySqlParametro("@aprovado", modelo.aprovado))
                p.Add(New MySqlParametro("@metragem", modelo.metragem))
                p.Add(New MySqlParametro("@imagem", modelo.imagem))
                p.Add(New MySqlParametro("@obs_publica", modelo.obs_publica))
                p.Add(New MySqlParametro("@obs_Restrita", modelo.obs_Restrita))
                sql = "UPDATE bordados SET arquivo=@arquivo,descricao=@descricao,caminho=@caminho,disquete=@disquete,bastidor=@bastidor,grupo_id=@grupo_id,preco=@preco,pontos=@pontos,cores=@cores," _
                   & "largura=@largura,altura=@altura,aprovado=@aprovado,metragem=@metragem,imagem=@imagem,obs_publica=@obs_publica,obs_Restrita=@obs_Restrita" + " WHERE id=@id;"

                'sql = "UPDATE bordados SET arquivo=@arquivo,descricao=@descricao,caminho=@caminho,disquete=@disquete,bastidor=@bastidor,grupo_id=@grupo_id,preco=@preco,pontos=@pontos,cores=@cores," _
                '   & "largura=@largura,altura=@altura,aprovado=@aprovado,metragem=@metragem,obs_publica=@obs_publica,obs_Restrita=@obs_Restrita" + " WHERE id=@id;"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Bordado", "Alterado", modelo.id)
                'Atualiza LinhasUtilizadas
                Dim BLLlu As New LinhaUtilizadaBLL
                BLLlu.ExcluiTodasDoBordado(modelo.id) 'Apaga inicialmente todas linhas do bordado
                For Each lu As LinhaUtilizada In modelo.LinhasUtilizadas
                    BLLlu.Incluir(lu)
                Next
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Bordado", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM bordados WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Bordado", "Excluído", id)
                'Exclui LinhasUtilizadas
                Dim BLLlu As New LinhaUtilizadaBLL
                BLLlu.ExcluiTodasDoBordado(id) 'Apaga todas linhas do bordado
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Bordado", "Erro ao Excluir", id)
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
                        sWhere &= "(descricao LIKE '%" & s & "%' OR arquivo LIKE '%" & s & "%' OR obs_publica LIKE '%" & s & "%') OR "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 4)
                ElseIf valor.Contains("&") Then
                    mValor = valor.Split("&"c)
                    sWhere = "WHERE ("
                    For Each s As String In mValor
                        sWhere &= "(descricao LIKE '%" & s & "%' OR arquivo LIKE '%" & s & "%' OR obs_publica LIKE '%" & s & "%') AND "
                    Next
                    'retura o último o´perador
                    sWhere = sWhere.Substring(0, sWhere.Length - 5)
                ElseIf valor.Contains("=") Then
                    'Campo:conteudo
                    mValor = valor.Split("=")

                    sWhere = "WHERE (" & mValor(0) & "='" & mValor(1) & "'"
                Else
                    sWhere = String.Format("WHERE (descricao LIKE '%{0:s}%' OR arquivo LIKE '%{0:s}%' OR obs_publica LIKE '%{0:s}%'", valor)
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

            If sWhere.Contains("catalogos") > -1 Then
                sql = "SELECT id, descricao, arquivo, obs_publica, '' AS catalogo FROM bordados " & sWhere & " ORDER BY id"
            Else
                sql = "SELECT bordados.id AS id, descricao, arquivo, obs_publica, catalogos.nome AS catalogo FROM bordados " _
                    & "LEFT JOIN catalogos ON catalogos.bordado_id = bordados.id " & sWhere & " ORDER BY id"
            End If
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As Bordado
            Dim modelo As New Bordado()

            If Not registro.HasRows Then Return modelo

            modelo.id = Convert.ToInt32(registro("id").ToString())
            modelo.descricao = Convert.ToString(registro("descricao"))
            modelo.arquivo = Convert.ToString(registro("arquivo"))
            modelo.caminho = Convert.ToString(registro("caminho"))
            modelo.disquete = Convert.ToString(registro("disquete"))
            modelo.bastidor = Convert.ToString(registro("bastidor"))
            modelo.grupo_id = Convert.ToInt32(registro("grupo_id"))
            modelo.preco = Convert.ToDecimal(registro("preco"))
            modelo.pontos = Convert.ToInt32(registro("pontos"))
            modelo.cores = Convert.ToInt32(registro("cores"))
            modelo.largura = Convert.ToInt32(registro("largura"))
            modelo.altura = Convert.ToInt32(registro("altura"))
            modelo.aprovado = Convert.ToBoolean(registro("aprovado"))
            If registro("metragem").ToString = "" Then
                modelo.metragem = 0
            Else
                'modelo.metragem = Convert.ToInt32(registro("metragem").ToString)
            End If

            Try
                modelo.imagem = DirectCast(registro("imagem"), Byte())
            Catch
            End Try

            modelo.obs_publica = Convert.ToString(registro("obs_publica"))
            modelo.obs_Restrita = Convert.ToString(registro("obs_Restrita"))

            Return modelo
        End Function

        Public Function CarregaBordado(id As Integer) As Bordado
            Dim modeloB As New Bordado()
            'Dim modeloLU As List(Of LinhaUtilizada) = New List(Of LinhaUtilizada)()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM bordados WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modeloB = BancoParaModelo(registro)
                'Carregar as Linhas Utilizadas
                Dim BLLlu As New LinhaUtilizadaBLL()
                modeloB.LinhasUtilizadas = BLLlu.CarregaLinhasDoBordado(modeloB.id)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modeloB
        End Function

        Public Function Todos() As DataTable
            sql = "SELECT id as Codigo, Arquivo, Descricao, preco FROM bordados order by Arquivo;"
            Return bd.exePesquisa(sql, p)
        End Function

    End Class
End Namespace
