
Imports ccb40.DAL

Namespace BLL
    Public Class CatalogoBLL
        Private DALobj As CatalogoDAL

        Public Sub New()
            DALobj = New CatalogoDAL()
        End Sub

        Public Sub Incluir(modelo As Catalogo)
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome da categoria é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Alterar(modelo As Catalogo)
            If modelo.id <= 0 Then
                Throw New Exception("O id da categoria é obrigatório!")
            End If
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome da categoria é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Excluir(nome As String, Optional bordado_id As Integer = 0)
            DALobj.Excluir(nome, bordado_id)
        End Sub

        Public Function Filtrar(valor As [String]) As DataTable
            Return DALobj.Filtrar(valor)
        End Function

        Public Function CarregaModeloCatalogo(id As Integer) As Catalogo
            Return DALobj.CarregaModeloCatalogo(id)
        End Function

        Public Function CarregaCatalogosDoBordado(bordado_id As Integer) As DataTable
            Return DALobj.CarregaCatalogosDoBordado(bordado_id)
        End Function

        Public Function TodosCatalogos(Optional item As String = "") As DataTable
            Return DALobj.TodosCatalogos(item)
        End Function

        Public Function ExisteCatalogo(ByVal cat As String, Optional bordado_id As Integer = 0) As Boolean
            Return DALobj.ExisteCatalogo(cat, bordado_id)
        End Function

    End Class
End Namespace

