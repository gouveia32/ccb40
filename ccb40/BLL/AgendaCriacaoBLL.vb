Imports ccb40.DAL

Namespace BLL
    Public Class AgendaCriacaoBLL

        Private DALobj As AgendaCriacaoDAL

        Public Sub New()
            DALobj = New AgendaCriacaoDAL()
        End Sub

        Public Sub Incluir(modelo As AgendaCriacao)
            If modelo.subject.Trim().Length = 0 Then
                Throw New Exception("O subject é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As AgendaCriacao)
            If modelo.id <= 0 Then
                Throw New Exception("O id da agenda é obrigatório!")
            End If
            If modelo.subject.Trim().Length = 0 Then
                Throw New Exception("O subject é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Return DALobj.Filtrar(valor)
        End Function

        Public Function CarregaModeloAgendaCriacao(id As Integer) As AgendaCriacao
            Return DALobj.CarregaModeloAgendaCriacao(id)
        End Function

        Public Function UltimoDoDia(ByVal dia As Date) As DateTime
            Return DALobj.UltimoDoDia(dia)
        End Function
    End Class
End Namespace
