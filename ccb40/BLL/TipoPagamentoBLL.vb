
Imports ccb40.DAL

Namespace BLL
    Public Class TipoPagamentoBLL
        Private DALobj As TipoPagamentoDAL

        Public Sub New()
            DALobj = New TipoPagamentoDAL()
        End Sub

        Public Sub Incluir(modelo As TipoPagamento)
            If modelo.codigo.Trim().Length = 0 Then
                Throw New Exception("O codigo é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Alterar(modelo As TipoPagamento)
            If modelo.id <= 0 Then
                Throw New Exception("O id é obrigatório!")
            End If
            If modelo.codigo.Trim().Length = 0 Then
                Throw New Exception("O codigo é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Excluir(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function CarregaTipoPagamento(id As Integer) As TipoPagamento
            Return DALobj.CarregaTipoPagamento(id)
        End Function

        Public Function TodosTiposPagamento() As DataTable
            Return DALobj.TiposPagamento()
        End Function

    End Class
End Namespace

