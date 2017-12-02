Imports ccb40.DAL

Namespace BLL
    Public Class LinhaHistoricoBLL
        Private ra As New fnRetiraAcento()
        Private DALobj As LinhaHistoricoDAL

        Public Sub New()
            DALobj = New LinhaHistoricoDAL()
        End Sub

        Public Sub Incluir(modelo As LinhaHistorico)
            If modelo.linha_id = 0 Then
                Throw New Exception("O linha_id é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As LinhaHistorico)
            If modelo.linha_id = 0 Then
                Throw New Exception("O linha_id do log é obrigatório!")
            End If
            If modelo.acao.Trim().Length = 0 Then
                Throw New Exception("O acao é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(linha_id As Integer)
            DALobj.Exclui(linha_id)
        End Sub

        Public Function Filtrar(valor As String, where As String) As DataTable
            Return DALobj.Filtrar(ra.RetiraAcento(valor), where)
        End Function

        Public Function CarregaLinhaHistorico(linha_id As Integer) As LinhaHistorico
            Return DALobj.CarregaLinhaHistorico(linha_id)
        End Function
    End Class
End Namespace
