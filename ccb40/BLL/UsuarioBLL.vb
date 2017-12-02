Imports ccb40.DAL

Namespace BLL
    Public Class UsuarioBLL
        Private DALobj As UsuarioDAL

        Public Sub New()


            DALobj = New UsuarioDAL()
        End Sub

        Public Sub Incluir(user As Usuario)

            If user.login.Trim().Length = 0 AndAlso user.senha.Trim().Length = 0 Then
                Throw New Exception("O login e senha obrigatórios")
            End If

            If DALobj.verifica(user) <> 0 Then
                Throw New Exception("Usuário já existe!")
            End If

            DALobj.Insere(user)

        End Sub

        Public Sub Altera(user As Usuario)

            If user.login.Trim().Length = 0 AndAlso user.senha.Trim().Length = 0 Then
                Throw New Exception("O login e senha obrigatórios")
            End If

            If DALobj.verifica(user) <> 0 Then
                Throw New Exception("Usuário já existe!")
            End If

            DALobj.Altera(user)

        End Sub

        Public Sub Exclui(codigo As Integer)
            DALobj.Exclui(codigo)
        End Sub

        Public Function Localiza(valor As String) As DataTable
            Return DALobj.Pesquisa(valor)
        End Function

        Public Function CarregaUsuario(login As String, senha As String) As Usuario
            Return DALobj.CarregaUsuario(login, senha)
        End Function

        Public Function CarregaUsuarioPorId(id As Integer) As Usuario
            Return DALobj.CarregaUsuarioPorId(id)
        End Function

        Public Sub AcessoSistema(user As Usuario)
            If DALobj.verifica(user) <> 1 Then
                Throw New Exception("Usuário/senha inválido(s)")
            End If
        End Sub

        Public Function Usuarios() As DataTable
            Return DALobj.Usuarios()
        End Function
    End Class
End Namespace