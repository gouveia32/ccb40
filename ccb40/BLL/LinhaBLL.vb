Imports ccb40.DAL

Namespace BLL
    Public Class LinhaBLL

        Private DALobj As LinhaDAL

        Public Sub New()
            DALobj = New LinhaDAL()
        End Sub

        Public Sub Incluir(modelo As Linha)
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do linha é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Linha)
            If modelo.codigo.Trim().Length = 0 Then
                Throw New Exception("O codigo da linha é obrigatório!")
            End If
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do linha é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(codigo As String)
            DALobj.Exclui(codigo)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaLinha(codigo As String) As Linha
            Return DALobj.CarregaModeloLinha(codigo)
        End Function
        Public Function LinhasNoBordado(bordado_id As Integer) As DataTable
            Return DALobj.LinhasNoBordado(bordado_id)
        End Function
    End Class
End Namespace
