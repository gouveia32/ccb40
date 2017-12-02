Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class AgendaCriacaoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As AgendaCriacao)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", modelo.pedido_id))
                p.Add(New MySqlParametro("@subject", modelo.subject))
                p.Add(New MySqlParametro("@description", modelo.description))
                p.Add(New MySqlParametro("@location", modelo.location))
                p.Add(New MySqlParametro("@label", modelo.label))
                p.Add(New MySqlParametro("@status", modelo.status))
                p.Add(New MySqlParametro("@start", modelo.start))

                sql = "INSERT INTO agenda_criacao(pedido_id,subject,description,location,label,cor,@start) " _
                    & "VALUES (@pedido_id,@subject,@description,@location,@label,@cor,@status,@start)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "AgendaCriacao", "Cadastrada", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaCriacao", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As AgendaCriacao)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@pedido_id", modelo.pedido_id))
                p.Add(New MySqlParametro("@subject", modelo.subject))
                p.Add(New MySqlParametro("@description", modelo.description))
                p.Add(New MySqlParametro("@location", modelo.location))
                p.Add(New MySqlParametro("@label", modelo.label))
                p.Add(New MySqlParametro("@status", modelo.status))
                p.Add(New MySqlParametro("@start", modelo.start))

                sql = "UPDATE agenda_criacao SET pedido_id=@pedido_id,subject=@subject,description=@description," _
                    & "location=@location,label=@label,status=@status,start=@start WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "AgendaCriacao", "Alterada", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaCriacao", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM agenda_criacao WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "AgendaCriacao", "Excluída", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaCriacao", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor.Contains("|") Then
                mValor = valor.Split("|"c)
                sWhere = "WHERE subject LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%' OR description LIKE '%")) & s) + "%' OR subject LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 15)
            ElseIf valor.Contains("&") Then
                mValor = valor.Split("&"c)
                sWhere = "WHERE (subject LIKE '%"
                For Each s As String In mValor
                    sWhere += (Convert.ToString(s & Convert.ToString("%' OR description LIKE '%")) & s) + "%') AND (subject LIKE '%"
                Next
                'retura o último o´perador
                sWhere = sWhere.Substring(0, sWhere.Length - 17)
            ElseIf valor.Contains("=") Then
                'Campo:conteudo
                mValor = valor.Split("=")

                sWhere = "WHERE " & mValor(0) & "='" & mValor(1) & "'"
            Else
                sWhere = String.Format("WHERE subject LIKE '%{0:s}%' OR description LIKE '%{0:s}%'", valor)
            End If

            sql = "SELECT id, subject, description FROM agenda_pedido " & sWhere & " ORDER BY start"
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Public Function UltimoDoDia(ByVal dia As Date) As DateTime
            Dim m As DateTime = CDate(String.Format("{0:yyyy-MM-dd} 07:50", dia))
            Dim dt As DataTable

            dt = MySQL_Select(Conn, "SELECT * FROM agenda_criacao WHERE DATE(START) = '" & String.Format("{0:yyyy-MM-dd}", dia) & "' AND status > 0 ORDER BY id DESC LIMIT 1")
            If dt.Rows.Count = 1 Then
                m = dt.Rows(0).Item("start")
            End If

            Return m.AddMinutes(10)

        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As AgendaCriacao
            Dim modelo As New AgendaCriacao()
            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.id = Convert.ToInt32(registro("id"))
            modelo.pedido_id = Convert.ToInt32(registro("pedido_id"))
            modelo.subject = Convert.ToString(registro("subject"))
            modelo.description = Convert.ToString(registro("description"))
            modelo.location = Convert.ToString(registro("location"))
            modelo.label = Convert.ToString(registro("label"))
            modelo.status = Convert.ToString(registro("status"))
            modelo.start = Convert.ToDateTime(registro("start"))

            Return modelo
        End Function

        Public Function CarregaModeloAgendaCriacao(id As Integer) As AgendaCriacao
            Dim modelo As New AgendaCriacao()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM agenda_criacao WHERE id = @id"
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
