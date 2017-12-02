
Imports ccb40.DAL

Namespace BLL
    Public Class LocalBLL
        Private DALobj As LocalDAL

        Public Sub New()
            DALobj = New LocalDAL()
        End Sub

        Public Sub Incluir(modelo As Local)
            If modelo.local.Trim().Length = 0 Then
                Throw New Exception("O local é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Alterar(modelo As Local)
            If modelo.id <= 0 Then
                Throw New Exception("O id do local é obrigatório!")
            End If
            If modelo.local.Trim().Length = 0 Then
                Throw New Exception("O Local é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Excluir(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaModeloLog(id As Integer) As Local
            Return DALobj.CarregaModeloLog(id)
        End Function

    End Class
End Namespace

