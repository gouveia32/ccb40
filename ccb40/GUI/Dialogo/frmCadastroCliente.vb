Imports ccb40.BLL
Imports MySql.Data.MySqlClient

Public Class frmCadastroCliente
    Public UltimoCodigoClienteCadastradoId As Integer
    Public UltimoCodigoClienteCadastradoNome As String
    Public UltimoCodigoClienteCadastradoContato As String
    'Public telefone1 As Integer
    Public cliente_id As Integer = 0

    Dim dt1, dt2 As DataTable
    Dim DataId As Integer
    Private loc As New fnLocalizar()
    Public UltimaSituacao As Integer = 1

    Private Sub LimpaTela()
        If btnGravar.Enabled Then
            If MsgBox("O registro atual foi alterado. Quer descartá-la?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        txtId.Text = ""
        txtNome.Text = ""
        txtContato_Funcao.Text = ""
        txtContato_Nome.Text = ""
        txtTelefone1.Text = ""
        txtTelefone2.Text = ""
        txtTelefone3.Text = ""
        txtEmail.Text = ""
        txtCgc_Cpf.Text = ""
        txtInscr_Estadual.Text = ""
        txtEndereco.Text = ""
        txtCidade.Text = ""
        cbUF.Text = ""
        txtCEP.Text = ""
        txtObs.Text = ""
    End Sub

    Private Sub TelaParaModelo(modelo As Cliente)
        modelo.nome = txtNome.Text
        modelo.contato_funcao = txtContato_Funcao.Text
        modelo.contato_nome = txtContato_Nome.Text
        modelo.cgc_cpf = txtCgc_Cpf.Text
        modelo.inscr_estadual = txtInscr_Estadual.Text
        modelo.endereco = txtEndereco.Text
        modelo.cidade = txtCidade.Text
        modelo.estado = cbUF.Text
        modelo.cep = txtCEP.Text
        modelo.telefone1 = txtTelefone1.Text
        modelo.telefone2 = txtTelefone2.Text
        modelo.telefone3 = txtTelefone3.Text
        modelo.email = txtEmail.Text
        modelo.obs = txtObs.Text
    End Sub

    Private Sub ModeloParaTela(modelo As Cliente)
        txtId.Text = modelo.ID.ToString()
        txtNome.Text = modelo.nome
        txtContato_Funcao.Text = modelo.contato_funcao
        txtContato_Nome.Text = modelo.contato_nome
        txtCgc_Cpf.Text = modelo.cgc_cpf
        txtInscr_Estadual.Text = modelo.inscr_estadual
        txtEndereco.Text = modelo.endereco
        txtCidade.Text = modelo.cidade
        cbUF.Text = modelo.estado
        txtCEP.Text = modelo.cep
        txtTelefone1.Text = modelo.telefone1
        txtTelefone2.Text = modelo.telefone2
        txtTelefone3.Text = modelo.telefone3
        txtEmail.Text = modelo.email
        txtObs.Text = modelo.obs
    End Sub


    Private Sub frmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cliente_id <> 0 Then
            CarregaCliente(cliente_id)
        Else
            LimpaTela()
        End If
        btnGravar.Enabled = False
    End Sub

    Private Sub GravarRegistro()
        Dim idAtual As Integer = Val(txtId.Text)

        Try
            'leitura dos dados
            Dim modelo As New Cliente()
            TelaParaModelo(modelo)

            'objeto para gravar os dados no bd
            Dim bll As New ClienteBLL()

            If idAtual = 0 Then     'Novo
                'cadastrar novo grupo
                bll.Incluir(modelo)
                UltimoCodigoClienteCadastradoId = modelo.ID
                UltimoCodigoClienteCadastradoNome = modelo.nome
                UltimoCodigoClienteCadastradoContato = modelo.telefone1

                btnGravar.Enabled = False
            Else
                'alerar um cliente
                idAtual = Convert.ToInt32(txtId.Text)
                modelo.ID = Convert.ToInt32(txtId.Text)
                bll.Altera(modelo)
                MessageBox.Show("Cliente alterado!")
                btnGravar.Enabled = False
            End If

        Catch erro As Exception
            MessageBox.Show(erro.Message)
        End Try

    End Sub
    Private Sub _TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObs.TextChanged, txtNome.TextChanged, txtInscr_Estadual.TextChanged, txtEndereco.TextChanged, txtEmail.TextChanged, txtContato_Nome.TextChanged, txtContato_Funcao.TextChanged, txtCidade.TextChanged, txtCgc_Cpf.TextChanged, cbUF.TextChanged, txtTelefone3.TextChanged, txtTelefone2.TextChanged, txtTelefone1.TextChanged, txtCEP.TextChanged
        btnGravar.Enabled = True
    End Sub

    Private Sub CarregaCliente(ByVal id As Integer)
        If btnGravar.Enabled Then
            If MsgBox("O registro atual foi alterado. Quer descartá-la?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If id >= 0 Then
            Dim BLL As ClienteBLL = New ClienteBLL()
            Dim modelo As Cliente = BLL.CarregaCliente(id)
            ModeloParaTela(modelo)
            btnGravar.Enabled = False
        End If
    End Sub

    Private Sub btnFechar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFechar.ItemClick
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGravar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGravar.ItemClick
        GravarRegistro()
        'Me.RefreshList()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class