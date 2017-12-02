Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class AgendaPedidoDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As AgendaPedido)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", modelo.pedido_id))
                p.Add(New MySqlParametro("@subject", modelo.subject))
                p.Add(New MySqlParametro("@description", modelo.description))
                p.Add(New MySqlParametro("@location", modelo.location))
                p.Add(New MySqlParametro("@label", modelo.label))
                p.Add(New MySqlParametro("@status", modelo.status))
                p.Add(New MySqlParametro("@start", modelo.inicio))
                p.Add(New MySqlParametro("@end", modelo.fim))

                sql = "INSERT INTO agenda_pedido (pedido_id,subject,description,location,label,status,start,end) " _
                    & "VALUES (@pedido_id,@subject,@description,@location,@label,@status,@start,@end)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Cadastrada", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Erro ao Cadastrar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As AgendaPedido)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", modelo.id))
                p.Add(New MySqlParametro("@pedido_id", modelo.pedido_id))
                p.Add(New MySqlParametro("@subject", modelo.subject))
                p.Add(New MySqlParametro("@description", modelo.description))
                p.Add(New MySqlParametro("@location", modelo.location))
                p.Add(New MySqlParametro("@label", modelo.label))
                p.Add(New MySqlParametro("@status", modelo.status))
                p.Add(New MySqlParametro("@start", modelo.inicio))
                p.Add(New MySqlParametro("@end", modelo.fim))

                sql = "UPDATE agenda_pedido SET pedido_id=@pedido_id,subject=@subject,description=@description," _
                    & "location=@location,label=@label,status=@status,start=@start,end=@end WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Alterada", modelo.id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Erro ao Alterar", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub MudaStatus(pedido_id As Integer, status As Integer)
            Dim modelo As AgendaPedido
            Dim bll As New AgendaPedidoBLL()
            Try
                'Verifica se o pedido tem agenda
                modelo = bll.CarregaModeloAgendaPedidoPorPedido(pedido_id)
                If modelo.pedido_id = pedido_id Then
                    p = New List(Of MySqlParametro)()
                    p.Add(New MySqlParametro("@pedido_id", pedido_id))
                    p.Add(New MySqlParametro("@status", status))

                    sql = "UPDATE agenda_pedido SET status=@status WHERE pedido_id = @pedido_id"
                    bd.exeNonQuery(sql, p)
                    bllLog.GravaLog("Cadastro", "AgendaPedido", String.Format("Alterado status: de {0} para {1} : Pedido:{2}", modelo.status, status, pedido_id), modelo.id)
                End If
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Erro ao Mudar o status", modelo.id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))

                sql = "DELETE FROM agenda_pedido WHERE id = @id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Excluída", id)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "AgendaPedido", "Erro ao Excluir", id)
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub ExcluiPorPedido(pedido_id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", pedido_id))

                sql = "DELETE FROM agenda_pedido WHERE pedido_id = @pedido_id;"
                bd.exeNonQuery(sql, p)

            Catch erro As Exception

                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Dim tabela As New DataTable()
            Dim mValor As String()
            Dim sWhere As String = ""

            If valor.Contains("|") Then
                mValor = valor.Split("|"c)
                sWhere = "WHERE subject Like '%"
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

            sql = "SELECT id, subject, description, start FROM agenda_pedido " & sWhere & " ORDER BY start DESC"
            Return bd.exePesquisa(sql, Nothing)
        End Function

        Private Function BancoParaModelo(registro As MySqlDataReader) As AgendaPedido
            Dim modelo As New AgendaPedido()
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
            modelo.inicio = Convert.ToDateTime(registro("start"))
            modelo.fim = Convert.ToDateTime(registro("end"))

            Return modelo
        End Function

        Public Function CarregaModeloAgendaPedido(id As Integer) As AgendaPedido
            Dim modelo As New AgendaPedido()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM agenda_pedido WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function CarregaModeloAgendaPedidoPorPedido(pedido_id As Integer) As AgendaPedido
            Dim modelo As New AgendaPedido()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@pedido_id", pedido_id))
                sql = "SELECT * FROM agenda_pedido WHERE pedido_id = @pedido_id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function UltimoDoDia(ByVal dia As Date, Optional pedido_id As Integer = 0) As DateTime
            Dim m As DateTime = CDate(String.Format("{0:yyyy-MM-dd} 07:50", dia))
            Dim tabela As New DataTable()

            If pedido_id <> 0 Then
                ExcluiPorPedido(pedido_id)
            End If
            Try
                tabela = Filtrar(String.Format("DATE(start)={0:yyyy-MM-dd}", dia))
                If tabela.Rows.Count > 0 Then
                    m = tabela.Rows(0).Item("start")
                End If

            Catch ex As Exception

            End Try

            Return m.AddMinutes(10)
        End Function

    End Class
End Namespace
