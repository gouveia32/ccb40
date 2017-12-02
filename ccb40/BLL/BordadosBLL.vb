
Imports ccb40.DAL

Namespace BLL
    Public Class BordadoBLL

        Private DALobj As BordadoDAL

        Public Sub New()
            DALobj = New BordadoDAL()
        End Sub

        Public Sub Incluir(modelo As Bordado)
            If modelo.descricao.Trim().Length = 0 Then
                Throw New Exception("O descricao do eordado é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Bordado)
            If modelo.id <= 0 Then
                Throw New Exception("O id da eordado é obrigatório!")
            End If
            If modelo.arquivo.Trim().Length = 0 Then
                Throw New Exception("O arquivo do eordado é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaBordado(id As Integer) As Bordado
            Return DALobj.CarregaBordado(id)
        End Function

        Public Function Todos() As DataTable
            Return DALobj.Todos()
        End Function
    End Class
End Namespace
