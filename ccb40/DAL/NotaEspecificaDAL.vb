Imports System.Collections.Generic
Imports ccb40.BLL
Imports MySql.Data.MySqlClient

Namespace DAL
    Public Class NotaEspecificaDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As NotaEspecifica)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@bordado_id", modelo.bordado_id))
                p.Add(New MySqlParametro("@cliente_id", modelo.cliente_id))
                p.Add(New MySqlParametro("@valor", modelo.valor))
                p.Add(New MySqlParametro("@data_atualizacao", modelo.data_atualizacao))
                p.Add(New MySqlParametro("@obs", modelo.obs))

                sql = "INSERT INTO notas_especificas(bordado_id,cliente_id,valor,data_atualizacao,obs) VALUES (@bordado_id,@cliente_id,@valor,@data_atualizacao,@obs)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "NotaEspecifica", "Cadastrada", String.Format("{0}/{1}", modelo.bordado_id, modelo.bordado_id))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "NotaEspecifica", "Erro ao Cadastrar", String.Format("{0}/{1}", modelo.bordado_id, modelo.bordado_id))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As NotaEspecifica)
            Try
                p = New List(Of MySqlParametro)()

                p.Add(New MySqlParametro("@bordado_id", modelo.bordado_id))
                p.Add(New MySqlParametro("@cliente_id", modelo.cliente_id))
                p.Add(New MySqlParametro("@valor", modelo.valor))
                p.Add(New MySqlParametro("@data_atualizacao", modelo.data_atualizacao))
                p.Add(New MySqlParametro("@obs", modelo.obs))

                sql = "UPDATE notas_especificas SET valor=@valor, data_atualizacao=@data_atualizacao, obs=@obs " + "WHERE bordado_id=@bordado_id AND cliente_id=@cliente_id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "NotaEspecifica", "Alterada", String.Format("{0}/{1}", modelo.bordado_id, modelo.bordado_id))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "NotaEspecifica", "Erro ao Alterar", String.Format("{0}/{1}", modelo.bordado_id, modelo.bordado_id))
                Throw New Exception(erro.Message)
            End Try
        End Sub


        Public Sub Exclui(bordado_id As Integer, cliente_id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", bordado_id))
                p.Add(New MySqlParametro("@cliente_id", cliente_id))

                sql = "DELETE FROM notas_especificas WHERE bordado_id=@bordado_id AND cliente_id=@cliente_id"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "NotaEspecifica", "Excluída", String.Format("{0}/{1}", bordado_id, bordado_id))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "NotaEspecifica", "Erro ao Excluir", String.Format("{0}/{1}", bordado_id, bordado_id))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As NotaEspecifica
            Dim modelo As New NotaEspecifica()

            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.bordado_id = Convert.ToInt32(registro("bordado_id"))
            modelo.cliente_id = Convert.ToInt32(registro("cliente_id"))

            modelo.valor = Convert.ToDecimal(registro("valor"))
            If registro("data_atualizacao") Is DBNull.Value Then
                modelo.data_atualizacao = Nothing
            Else
                modelo.data_atualizacao = Convert.ToDateTime(registro("data_atualizacao"))
            End If
            modelo.obs = Convert.ToString(registro("obs"))

            Return modelo
        End Function

        Public Function NotasDoBordado(bordado_id As Integer) As DataTable
            Dim tabela As New DataTable()

            p = New List(Of MySqlParametro)()
            p.Add(New MySqlParametro("@bordado_id", bordado_id))
            sql = "SELECT notas_especificas.cliente_id as id, clientes.nome as cliente, " + "notas_especificas.valor as valor, notas_especificas.obs as obs," + "notas_especificas.data_atualizacao as data_atualizacao FROM notas_especificas left Join clientes On " + "notas_especificas.cliente_id = clientes.id WHERE notas_especificas.bordado_id=@bordado_id"
            Return bd.exePesquisa(sql, p)
        End Function

        Public Function ListaNotasDoBordado(bordado_id As Integer) As List(Of NotaEspecifica)
            Dim modeloNE As New NotaEspecifica()
            Dim ret As List(Of NotaEspecifica) = New List(Of NotaEspecifica)()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", bordado_id))
                sql = "SELECT * FROM notas_especificas WHERE bordado_id = @bordado_id"
                registro = bd.Reader(sql, p)
                While registro.Read()
                    modeloNE = BancoParaModelo(registro)
                    ret.Add(modeloNE)
                End While
            Catch ex As Exception
            Finally
                bd.FecharReader(registro)
            End Try
            Return ret
        End Function

    End Class
End Namespace

