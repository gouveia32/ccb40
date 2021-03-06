﻿
Imports ccb40.DAL

Namespace BLL
    Public Class FornecedorBLL

        Private DALobj As FornecedorDAL

        Public Sub New()
            DALobj = New FornecedorDAL()
        End Sub

        Public Sub Incluir(modelo As Fornecedor)
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do fornecedor é obrigatório!")
            End If
            DALobj.Insere(modelo)
        End Sub

        Public Sub Altera(modelo As Fornecedor)
            If modelo.ID <= 0 Then
                Throw New Exception("O id da fornecedor é obrigatório!")
            End If
            If modelo.nome.Trim().Length = 0 Then
                Throw New Exception("O nome do fornecedor é obrigatório!")
            End If
            DALobj.Altera(modelo)
        End Sub

        Public Sub Exclui(id As Integer)
            DALobj.Exclui(id)
        End Sub

        Public Function Filtrar(valor As [String], Optional sWhere As String = "") As DataTable
            Return DALobj.Filtrar(valor, sWhere)
        End Function

        Public Function CarregaFornecedor(id As Integer) As Fornecedor
            Return DALobj.CarregaFornecedor(id)
        End Function
    End Class
End Namespace
