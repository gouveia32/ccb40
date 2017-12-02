Imports ccb40.DAL

Namespace BLL
    Public Class ParametroBLL
        Private DALobj As ParametroDAL

        Public Sub New()
            DALobj = New ParametroDAL()
        End Sub

        Public Function CarregaParametros(id As Integer) As Parametro
            Return DALobj.CarregaParametros(id)
        End Function

        Public Sub GravaParametros(modelo As Parametro)
            DALobj.GravaParametros(modelo)
        End Sub

    End Class
End Namespace

