
Imports ccb40.DAL

Namespace BLL
    Public Class GrupoBLL
        Private DALobj As GrupoDAL

        Public Sub New()
            DALobj = New GrupoDAL()
        End Sub

        Public Sub Incluir(modelo As Grupo)
            If modelo.local.Trim().Length = 0 Then
                Throw New Exception("O nome da categoria é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Alterar(modelo As Grupo)
            If modelo.id <= 0 Then
                Throw New Exception("O id da categoria é obrigatório!")
            End If
            If modelo.local.Trim().Length = 0 Then
                Throw New Exception("O nome da categoria é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Excluir(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Return DALobj.Filtrar(valor)
        End Function

        Public Function CarregaModeloGrupo(id As Integer) As Grupo
            Return DALobj.CarregaModeloGrupo(id)
        End Function

        Public Function TodosGrupos(Optional item As String = "") As DataTable
            Return DALobj.TodosGrupos(item)
        End Function
    End Class
End Namespace

