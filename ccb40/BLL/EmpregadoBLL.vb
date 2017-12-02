Imports ccb40.DAL

Namespace BLL
    Public Class EmpregadoBLL

        Private DALobj As EmpregadoDAL

        Public Sub New()
            DALobj = New EmpregadoDAL()
        End Sub

        Public Sub Incluir(modelo As Empregado)
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do empregado é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Empregado)
            If modelo.ID <= 0 Then
                Throw New Exception("O id da empregado é obrigatório!")
            End If
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do empregado é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaEmpregado(id As Integer) As Empregado
            Return DALobj.CarregaEmpregado(id)
        End Function

        Public Function EmpregadosAtivos() As DataTable
            Return DALobj.EmpregadosAtivos()
        End Function
    End Class
End Namespace
