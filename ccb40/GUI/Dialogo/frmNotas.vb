Imports System.Windows.Forms
Imports ccb.BLL
Imports ccb40.BLL

Public Class frmNotas
    Public flagComboClienteCarregado As Boolean = False
    Public cliente_id As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        cliente_id = cbCliente.EditValue
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = frmBordados.dgLinhas_Utilizadas.Top
        If diValor.Enabled Then
            diValor.Focus()
        Else
            txtObsEspecifica.Focus()
        End If

    End Sub

    Public Sub CarregaComboClientes()

        Dim BLLc As New ClienteBLL()
        With cbCliente.Properties
            .DataSource = BLLc.CarregaTodos()
            .ValueMember = "id"
            .DisplayMember = "nome"
            .Columns(0).Width = 60
        End With
        flagComboClienteCarregado = True

    End Sub

    Private Sub frmNotas_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Not flagComboClienteCarregado Then
            CarregaComboClientes()
        End If
        If cbCliente.Enabled Then
            cbCliente.Focus()
        ElseIf diValor.Visible Then
            diValor.Focus()
        Else
            txtObsEspecifica.Focus()

        End If
    End Sub

    Private Sub RestritoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestritoToolStripMenuItem.Click
        If My.Settings.Nivel < 4 Then Exit Sub 'Só pode habilitar usuário nível 5
        diValor.Visible = Not diValor.Visible
        frmBordados.txtObs_Restrita.Visible = diValor.Visible
        'frmBordados.txtPreco.Visible = diValor.Visible
        ''frmBordados.Valor.Visible = diValor.Visible
    End Sub

    Private Sub btncadastroCliente_Click(sender As Object, e As EventArgs) Handles btncadastroCliente.Click
        If frmCadastroCliente.ShowDialog() = DialogResult.OK Then
            CarregaComboClientes()
        End If
    End Sub
End Class
