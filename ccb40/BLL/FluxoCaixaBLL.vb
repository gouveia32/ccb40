Imports System.Collections.Generic
Imports ccb40.DAL

Namespace BLL
    Public Class FluxoCaixaBLL
        Private ra As New fnRetiraAcento()
        Private DALobj As FluxoCaixaDAL

        Public Sub New()
            DALobj = New FluxoCaixaDAL()
        End Sub

        Public Sub Incluir(modelo As FluxoCaixa)
            If modelo.descricao.Trim.Length = 0 Then
                Throw New Exception("A descricao é obrigatória!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As FluxoCaixa)
            If modelo.id = 0 Then
                Throw New Exception("O id é obrigatório!")
            End If
            If modelo.descricao.Trim.Length = 0 Then
                Throw New Exception("A descricao é obrigatória!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function CarregaModeloFluxoCaixa(id As Integer) As FluxoCaixa
            Return DALobj.CarregaModeloFluxoCaixa(id)
        End Function

        Public Function CarregaPorData(ByVal DataCaixa As Date) As DataTable
            Return DALobj.CarregaPorData(DataCaixa)
        End Function

    End Class
End Namespace
