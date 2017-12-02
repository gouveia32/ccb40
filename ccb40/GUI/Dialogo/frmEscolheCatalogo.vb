Public Class frmEscolheCatalogo
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEscolheCatalogo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim dt As DataTable
        Dim r As Integer

        'Carrega Catalogos
        dt = MySQL_Select(Conn, "SELECT nome, count(*) as qtde FROM catalogos GROUP BY nome")
        If dt.Rows.Count > 0 Then
            cbCatalogo.Items.Clear()
            For r = 0 To dt.Rows.Count - 1
                cbCatalogo.Items.Add(String.Format("{0} ({1})", dt.Rows(r).Item("nome"), dt.Rows(r).Item("qtde")))
            Next
        End If
        cbCatalogo.SelectedIndex = 0

        'Carrega Grupos
        dt = MySQL_Select(Conn, "SELECT 0 AS id, 'Todos' AS grupo UNION SELECT grupos.id, grupo FROM bordados JOIN grupos ON grupos.id=bordados.grupo_id GROUP BY grupo_id")
        If dt.Rows.Count > 0 Then
            cbGrupo.Items.Clear()
            For r = 0 To dt.Rows.Count - 1
                Me.cbGrupo.Items.Add(New ValorDescricao(dt.Rows(r).Item("id"), dt.Rows(r).Item("grupo")))
            Next
        End If

        cbGrupo.Text = "Todos"

    End Sub
End Class