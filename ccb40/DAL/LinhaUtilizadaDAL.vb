Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports ccb40.BLL

Namespace DAL
    Public Class LinhaUtilizadaDAL
        Private bd As ClassBD
        Private sql As String
        Private p As List(Of MySqlParametro)
        Private bllLog As New LogBLL()

        Public Sub New()
            bd = ClassBD.create()
        End Sub

        Public Sub Insere(modelo As LinhaUtilizada)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", modelo.bordado_id))
                p.Add(New MySqlParametro("@seq", modelo.seq))
                p.Add(New MySqlParametro("@codigo", modelo.codigo))
                p.Add(New MySqlParametro("@metragem", modelo.metragem))
                p.Add(New MySqlParametro("@pontos", modelo.pontos))

                sql = "INSERT INTO linhas_utilizadas (bordado_id,seq,linha_id,metragem,pontos) " _
                    & "VALUES (@bordado_id,@seq,@codigo,@metragem,@pontos)"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "LinhaUtilizada", "Cadastrada", String.Format("{0}/{1}/{2}", modelo.bordado_id, modelo.seq, modelo.codigo))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "LinhaUtilizada", "Erro ao Cadastrar", String.Format("{0}/{1}/{2}", modelo.bordado_id, modelo.seq, modelo.codigo))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Altera(modelo As LinhaUtilizada)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", modelo.bordado_id))
                p.Add(New MySqlParametro("@seq", modelo.seq))
                p.Add(New MySqlParametro("@codigo", modelo.codigo))
                p.Add(New MySqlParametro("@metragem", modelo.metragem))
                p.Add(New MySqlParametro("@pontos", modelo.pontos))

                sql = "UPDATE linhas_utilizadas SET metragem@metragem,pontos=@pontos " _
                    & "WHERE bordado_id=@bordado_id AND seq=@seq AND linha_id = @codigo"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "LinhaUtilizada", "Alterar", String.Format("{0}/{1}/{2}", modelo.bordado_id, modelo.seq, modelo.codigo))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "LinhaUtilizada", "Erro ao Alterar", String.Format("{0}/{1}/{2}", modelo.bordado_id, modelo.seq, modelo.codigo))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub Exclui(bordado_id As Integer, seq As Integer, codigo As String)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", bordado_id))
                p.Add(New MySqlParametro("@seq", seq))
                p.Add(New MySqlParametro("@codigo", codigo))

                sql = "DELETE FROM linhas_utilizadas WHERE bordado_id=@bordado_id AND seq=@seq AND linha_id = @codigo"
                bd.exeNonQuery(sql, p)
                bllLog.GravaLog("Cadastro", "LinhaUtilizada", "Excluída", String.Format("{0}/{1}/{2}", bordado_id, seq, codigo))
            Catch erro As Exception
                bllLog.GravaLog("Cadastro", "LinhaUtilizada", "Erro ao Excluir", String.Format("{0}/{1}/{2}", bordado_id, seq, codigo))
                Throw New Exception(erro.Message)
            End Try
        End Sub

        Public Sub ExcluiTodasDoBordado(bordado_id As Integer)
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", bordado_id))

                sql = "DELETE FROM linhas_utilizadas WHERE bordado_id=@bordado_id"
                bd.exeNonQuery(sql, p)
            Catch erro As Exception
                Throw New Exception(erro.Message)
            End Try
        End Sub


        Private Function BancoParaModelo(registro As MySqlDataReader) As LinhaUtilizada
            Dim modelo As New LinhaUtilizada()
            If Not registro.HasRows Then
                Return modelo
            End If
            modelo.bordado_id = Convert.ToInt32(registro("bordado_id"))
            modelo.seq = Convert.ToString(registro("seq"))
            modelo.codigo = Convert.ToString(registro("codigo").ToString())
            modelo.cor = Convert.ToInt32(registro("cor"))
            modelo.nome = Convert.ToString(registro("nome").ToString())
            modelo.pontos = Convert.ToInt32(registro("pontos"))
            modelo.metragem = Convert.ToInt32(registro("metragem"))

            Return modelo
        End Function

        Public Function CarregaModeloLinha(linha_id As Integer) As LinhaUtilizada
            Dim modelo As New LinhaUtilizada()

            Dim registro As MySqlDataReader = Nothing
            Try
                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@linha_id", linha_id))
                sql = "SELECT * FROM linhas_utilizadas WHERE linha_id = @linha_id"
                registro = bd.Reader(sql, p)

                registro.Read()
                'Le o primeiro registro, como é chave única só existe este
                modelo = BancoParaModelo(registro)
            Finally
                bd.FecharReader(registro)
            End Try
            Return modelo
        End Function

        Public Function CarregaLinhasDoBordado(bordado_id As Integer) As List(Of LinhaUtilizada)
            Dim modeloLU As New LinhaUtilizada()
            Dim ret As List(Of LinhaUtilizada) = New List(Of LinhaUtilizada)()

            Dim registro As MySqlDataReader = Nothing
            Try

                p = New List(Of MySqlParametro)()
                p.Add(New MySqlParametro("@bordado_id", bordado_id))
                sql = "SELECT bordado_id, seq, linha_id as codigo, linhas.cor, linhas.nome, pontos, metragem FROM linhas_utilizadas LEFT JOIN linhas ON linhas.codigo=linhas_utilizadas.linha_id " _
                    & "WHERE bordado_id = @bordado_id"
                registro = bd.Reader(sql, p)
                While registro.Read()
                    modeloLU = BancoParaModelo(registro)
                    ret.Add(modeloLU)
                End While
            Catch ex As Exception
            Finally
                bd.FecharReader(registro)
            End Try

            Return ret
        End Function

    End Class

End Namespace