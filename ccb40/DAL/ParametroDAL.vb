Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class ParametroDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Private Function BancoParaModelo(registro As MySqlDataReader) As Parametro
            Dim modelo As New Parametro()

            modelo.ID = Convert.ToInt32(registro("id").ToString())
            modelo.caixa_aberto = Convert.ToBoolean(registro("caixa_aberto"))
            modelo.data_caixa_atual = Convert.ToDateTime(registro("data_caixa_atual"))
            modelo.data_saldo_caixa_fechado = Convert.ToDateTime(registro("data_saldo_caixa_fechado"))
            modelo.saldo_caixa = Convert.ToDecimal(registro("saldo_caixa"))
            modelo.SessaoTimeOut = Convert.ToInt32(registro("SessaoTimeOut"))
            modelo.TempoAtualizaPedidos = Convert.ToInt32(registro("TempoAtualizaPedidos"))
            modelo.NotificarEmail = Convert.ToBoolean(registro("NotificarEmail"))
            modelo.EmailNotificacao = Convert.ToString(registro("EmailNotificacao"))
            modelo.EmailOrigem = Convert.ToString(registro("EmailOrigem"))
            modelo.Senha = Convert.ToString(registro("Senha"))
            modelo.NomeEmpresa = Convert.ToString(registro("NomeEmpresa"))
            modelo.endereco = Convert.ToString(registro("endereco"))
            modelo.telefone = Convert.ToString(registro("telefone"))
            modelo.corPedidoNormal = Convert.ToInt32(registro("corPedidoNormal"))
            modelo.corPedidoMensal = Convert.ToInt32(registro("corPedidoMensal"))
            modelo.corCriacaoNormal = Convert.ToInt32(registro("corCriacaoNormal"))
            modelo.corCriacaoUrgente = Convert.ToInt32(registro("corCriacaoUrgente"))
            modelo.corTarefaSelecionada = Convert.ToInt32(registro("corTarefaSelecionada"))

            Return modelo
        End Function

        Public Function CarregaParametros(id As Integer) As Parametro
            Dim modelo As New Parametro()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@id", id))
                sql = "SELECT * FROM parametros WHERE id = @id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Sub GravaParametros(modelo As Parametro)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@caixa_aberto", modelo.caixa_aberto))
                p.Add(New MySqlParametro("@data_caixa_atual", modelo.data_caixa_atual))
                p.Add(New MySqlParametro("@data_saldo_caixa_fechado", modelo.data_saldo_caixa_fechado))
                p.Add(New MySqlParametro("@saldo_caixa", modelo.saldo_caixa))
                p.Add(New MySqlParametro("@SessaoTimeOut", modelo.SessaoTimeOut))
                p.Add(New MySqlParametro("@TempoAtualizaPedidos", modelo.TempoAtualizaPedidos))
                p.Add(New MySqlParametro("@NotificarEmail", modelo.NotificarEmail))
                p.Add(New MySqlParametro("@EmailNotificacao", modelo.EmailNotificacao))
                p.Add(New MySqlParametro("@EmailOrigem", modelo.EmailOrigem))
                p.Add(New MySqlParametro("@Senha", modelo.Senha))
                p.Add(New MySqlParametro("@NomeEmpresa", modelo.NomeEmpresa))
                p.Add(New MySqlParametro("@endereco", modelo.endereco))
                p.Add(New MySqlParametro("@telefone", modelo.telefone))
                p.Add(New MySqlParametro("@corPedidoNormal", modelo.corPedidoNormal))
                p.Add(New MySqlParametro("@corPedidoMensal", modelo.corPedidoMensal))
                p.Add(New MySqlParametro("@corCriacaoNormal", modelo.corCriacaoNormal))
                p.Add(New MySqlParametro("@corCriacaoUrgente", modelo.corCriacaoUrgente))
                p.Add(New MySqlParametro("@corTarefaSelecionada", modelo.corTarefaSelecionada))
                p.Add(New MySqlParametro("@id", Convert.ToInt32(modelo.ID)))

                sql = "UPDATE parametros SET caixa_aberto=@caixa_aberto,data_caixa_atual=@data_caixa_atual," _
                    & "data_saldo_caixa_fechado=@data_saldo_caixa_fechado,saldo_caixa=@saldo_caixa," _
                    & "NomeEmpresa=@NomeEmpresa,SessaoTimeOut=@SessaoTimeOut,TempoAtualizaPedidos=@TempoAtualizaPedidos," _
                    & "NomeEmpresa=@NomeEmpresa,NotificarEmail=@NotificarEmail,EmailNotificacao=@EmailNotificacao," _
                    & "EmailOrigem=@EmailOrigem,Senha=@Senha,endereco=@endereco,telefone=@telefone," _
                    & "corPedidoNormal=@corPedidoNormal,corPedidoMensal=@corPedidoMensal,corCriacaoNormal=@corCriacaoNormal," _
                    & "corCriacaoUrgente=@corCriacaoUrgente,corTarefaSelecionada=@corTarefaSelecionada WHERE id=@id;"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "Parametro", "Gravado", modelo.ID)
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "Parametro", "Erro ao Gravar", modelo.ID)
                Throw New Exception(erro.Message)
            End Try
        End Sub
    End Class
End Namespace
