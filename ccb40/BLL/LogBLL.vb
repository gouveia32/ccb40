
Imports ccb40.DAL

Namespace BLL
    Public Class LogBLL
        Private DALobj As LogDAL

        Public Sub New()
            DALobj = New LogDAL()
        End Sub

        Public Sub Incluir(modelo As Log)
            If modelo.objeto.Trim().Length = 0 Then
                Throw New Exception("O objeto é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Alterar(modelo As Log)
            If modelo.id <= 0 Then
                Throw New Exception("O id da categoria é obrigatório!")
            End If
            If modelo.objeto.Trim().Length = 0 Then
                Throw New Exception("O objeto é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Excluir(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaModeloLog(id As Integer) As Log
            Return DALobj.CarregaModeloLog(id)
        End Function

        Public Sub GravaLog(ByVal grupo As String, ByVal sub_grupo As String, ByVal descricao As String, ByVal objeto As String)
            DALobj.GravaLog(grupo, sub_grupo, descricao, objeto)
        End Sub

    End Class
End Namespace

