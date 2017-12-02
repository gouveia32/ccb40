Imports ccb.BLL
Imports ccb40.BLL
Imports MySql.Data.MySqlClient

Public Class frmLinha
    Dim dt1, dt2 As DataTable
    Dim DataId As Integer
    Private loc As New fnLocalizar()
    Public UltimaSituacao As Integer = 1

    Dim modeloL As New Linha()
    Dim modeloLH As New LinhaHistorico()

    Private Sub Filtrar(Optional Posicionar_id As Integer = 0)
        Dim bll As New LinhaBLL()
        'Dim filtro As String = MontaFiltro()

        Dim sWhere As String = ""
        Dim filtro As String = txtFiltrar.Text

        Dim currentCursor As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor

        If IsNumeric(filtro) Then
            sWhere = "codigo=" & filtro.Trim
            filtro = ""
        End If

        If sWhere <> "" Then
            dgRegistros.DataSource = bll.Filtrar(filtro, sWhere)
        Else
            dgRegistros.DataSource = bll.Filtrar(filtro)
        End If

        If Posicionar_id > 0 Then
            loc.Localizar(gvRegistros, String.Format("codigo={0}", Posicionar_id), 0, True)
        Else
            If gvRegistros.RowCount > 0 Then
                CarregaLinha(Convert.ToString(gvRegistros.GetDataRow(0).ItemArray(0)))
            End If
        End If
        If txtFiltrar.Text = "" Then
            btnX.Visible = False
        Else
            btnX.Visible = True
        End If
        If gvRegistros.RowCount < 1 Then
            LimpaTela()
        End If
        Cursor.Current = currentCursor
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Filtrar()
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        txtFiltrar.Text = ""
        Filtrar()
        btnX.Visible = False
    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Select Case e.KeyCode
            Case 13 ' Enter
                Filtrar()
            Case 27 'Esc
                btnX_Click(sender, e)
            Case 40 'Seta para baiixo
                gvRegistros.Focus()
        End Select
    End Sub

    Private Sub CarregaLinha(ByVal codigo As String)
        If codigo = "" Then Exit Sub

        Dim modelo As Linha = New Linha()
        If codigo <> "" Then
            Dim BLL As LinhaBLL = New LinhaBLL()
            modelo = BLL.CarregaLinha(codigo)
            ModeloParaTela(modelo)

        End If
        'Carrega Historico
        Dim bllLH As LinhaHistoricoBLL = New LinhaHistoricoBLL()
        dgLog.DataSource = bllLH.Filtrar("", String.Format("linha_id={0} AND data >= '{1:yyyy-MM-dd}'",
                    modelo.codigo,
                    deDataInicial.EditValue))

        chartLinhaHistorico.DataSource = dgLog.DataSource
        'ccHistorico.Series(0).DataSource = dgLog.DataSource
        chartLinhaHistorico.Series(0).ArgumentDataMember = "mes"
        chartLinhaHistorico.Series(0).ValueDataMembers(0) = "compra"

        chartLinhaHistorico.Series(1).ArgumentDataMember = "mes"
        chartLinhaHistorico.Series(1).ValueDataMembers(0) = "uso"
    End Sub

    Private Sub gvRegistros_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvRegistros.FocusedRowChanged
        If e.FocusedRowHandle >= 0 Then
            CarregaLinha(Convert.ToString(gvRegistros.GetDataRow(e.FocusedRowHandle).ItemArray(0)))
        End If
    End Sub

    Private Sub LimpaTela()


        txtCodigo_c.Text = ""
        txtNome.Text = ""
        txtMaterial_Nome.Text = ""
        txtMaterial_Fabricante.Text = ""
        txtMaterial_Tipo.Text = ""
        txtEstoque_1.Text = ""
        txtEstoque_2.Text = ""
        txtMinimo.Text = ""
        txtPedido.Text = ""
    End Sub

    Private Sub TelaParaModelo(modelo As Linha)
        modelo.codigo = txtCodigo_c.Text
        modelo.nome = txtNome.Text
        modelo.material_nome = txtMaterial_Nome.Text
        modelo.material_fabricante = txtMaterial_Fabricante.Text
        modelo.material_tipo = txtMaterial_Tipo.Text
        modelo.cor = ceCor.Color.ToArgb()
        modelo.estoque_1 = Convert.ToInt32(txtEstoque_1.Text)
        modelo.estoque_2 = Convert.ToInt32(txtEstoque_2.Text)
        modelo.minimo = Convert.ToInt32(txtMinimo.Text)
        modelo.pedido = Convert.ToInt32(txtPedido.Text)
    End Sub


    Private Sub frmEmpregados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.WindowState <> FormWindowState.Maximized Then Me.WindowState = FormWindowState.Maximized

        Filtrar()
        gvRegistros.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        gvRegistros.Columns(0).Width = 50
        gvRegistros.Columns(1).Width = 120
        gvRegistros.Columns(2).Width = 60
        gvRegistros.Columns(3).Width = 60
        gvRegistros.Columns(4).Width = 150
        gvRegistros.Columns("Codigo").Summary.Add(DevExpress.Data.SummaryItemType.Count, "Codigo", "{0}")
        gvRegistros.Columns("Estoque_1").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Estoque_1", "{0}")
        txtFiltrar.Focus()

    End Sub

    Private Sub frmEmpregados_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        'frmPrincipal.lblMensRegistros.Text = gdRegistros.RowCount & " linhas no cadastro"
    End Sub

    Private Sub frmEmpregados_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'frmPrincipal.lblMensRegistros.Text = ""
    End Sub

    Private Sub btnExcluir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            Dim d As DialogResult = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If d.ToString() = "Yes" Then
                Dim bll As New ClienteBLL()
                bll.Exclui(Convert.ToInt32(txtCodigo_c.Text))
                LimpaTela()
                Filtrar()
            End If
        Catch erro As Exception
            MessageBox.Show("Impossível excluir o registro. " & vbLf & " O registro está sendo utilizado em outro local.")
        End Try
    End Sub

    Private Sub deDataInicial_EditValueChanged(sender As Object, e As EventArgs) Handles deDataInicial.EditValueChanged
        If gvRegistros.FocusedRowHandle >= 0 Then CarregaLinha(Convert.ToString(gvRegistros.GetDataRow(gvRegistros.FocusedRowHandle).ItemArray(0)))
    End Sub

    Private Sub tbEst1_Quantidade_b_TextChanged(sender As Object, e As EventArgs)
        tbEst1_Final_b.EditValue = tbEst1_Atual_b.EditValue - tbEst1_Quantidade_b.EditValue
    End Sub

    Private Sub tbEst2_Quantidade_b_TextChanged(sender As Object, e As EventArgs)
        tbEst2_Final_b.EditValue = tbEst2_Atual_b.EditValue - tbEst2_Quantidade_b.EditValue
    End Sub

    Private Sub btnEst1_e_Click(sender As Object, e As EventArgs) Handles btnEst1_e.Click
        If MsgBox(String.Format("Confirma a Entrada no estoque_1 de {0} linhas: ",
                                tbEst1_Quantidade_e.Text),
                                MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        'Carrega dados dalinha no modelo
        TelaParaModelo(modeloL)

        modeloLH.acao = "Entrada"
        modeloLH.data = String.Format("{0:yyyy-MM-dd hh:mm:ss}", Now)
        modeloLH.linha_id = modeloL.codigo
        modeloLH.est1_anterior = modeloL.estoque_1 'valor atual
        modeloLH.est1_atual = tbEst1_Final_e.Text  'novo valor
        modeloLH.est2_anterior = modeloL.estoque_2 'mantem valores atuais
        modeloLH.est2_atual = modeloL.estoque_2    'mantem valores atuais

        modeloL.estoque_1 = tbEst1_Final_e.Text

        'objeto para gravar os dados no bd
        Dim bllL As New LinhaBLL()
        Dim bllLH As New LinhaHistoricoBLL()

        bllL.Altera(modeloL) 'Atualiza Linha
        bllLH.Incluir(modeloLH) 'Insere Histórico

        MessageBox.Show("Entrada realizada com sucesso!")
        Filtrar(modeloL.codigo)

    End Sub

    Private Sub btnEst2_e_Click(sender As Object, e As EventArgs) Handles btnEst2_e.Click
        If tbEst2_Quantidade_b.EditValue > 0 Then
            If tbEst2_Quantidade_b.EditValue > modeloL.estoque_2 Then
                MsgBox(String.Format("A quantidade ({0}) maior do que o Estoque 2 ({1}). ",
                                     tbEst2_Quantidade_b.EditValue, modeloL.estoque_2),
                                     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox(String.Format("Confirma a Entrada no estoque_2 de {0} linhas: ",
                        tbEst2_Quantidade_e.Text),
                        MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            'Carrega dados dalinha no modelo
            TelaParaModelo(modeloL)

            modeloLH.acao = "Entrada"
            modeloLH.data = String.Format("{0:yyyy-MM-dd hh:mm:ss}", Now)
            modeloLH.linha_id = modeloL.codigo
            modeloLH.est2_anterior = modeloL.estoque_2 'valor atual
            modeloLH.est2_atual = tbEst1_Final_e.Text  'novo valor
            modeloLH.est1_anterior = modeloL.estoque_1 'mantem valores atuais
            modeloLH.est1_atual = modeloL.estoque_1    'mantem valores atuais

            modeloL.estoque_2 = tbEst2_Final_e.Text

            'objeto para gravar os dados no bd
            Dim bllL As New LinhaBLL()
            Dim bllLH As New LinhaHistoricoBLL()

            bllL.Altera(modeloL) 'Atualiza Linha
            bllLH.Incluir(modeloLH) 'Insere Histórico

            MessageBox.Show("Entrada realizada com sucesso!")
            Filtrar(modeloL.codigo)

        End If
    End Sub

    Private Sub btnEst1_b_Click(sender As Object, e As EventArgs) Handles btnEst1_b.Click
        If tbEst1_Quantidade_b.EditValue > 0 Then
            'Carrega dados dalinha no modelo
            TelaParaModelo(modeloL)
            If tbEst1_Quantidade_b.EditValue > modeloL.estoque_1 Then
                MsgBox(String.Format("A quantidade ({0}) maior do que o Estoque 1 ({1}). ",
                                     tbEst1_Quantidade_b.EditValue, modeloL.estoque_1),
                                     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox(String.Format("Confirma a Baixa no estoque_1 de {0} linhas: ",
                                  tbEst1_Quantidade_b.Text),
                                  MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If


            modeloLH.acao = "Baixa"
            modeloLH.data = String.Format("{0:yyyy-MM-dd hh:mm:ss}", Now)
            modeloLH.linha_id = modeloL.codigo
            modeloLH.est1_anterior = modeloL.estoque_1 'valor atual
            modeloLH.est1_atual = tbEst1_Final_b.Text  'novo valor
            modeloLH.est2_anterior = modeloL.estoque_2 'mantem valores atuais
            modeloLH.est2_atual = modeloL.estoque_2    'mantem valores atuais

            modeloL.estoque_1 = tbEst1_Final_b.Text

            'objeto para gravar os dados no bd
            Dim bllL As New LinhaBLL()
            Dim bllLH As New LinhaHistoricoBLL()

            bllL.Altera(modeloL) 'Atualiza Linha
            bllLH.Incluir(modeloLH) 'Insere Histórico

            MessageBox.Show("Baixa realizada com sucesso!")
            Filtrar(modeloL.codigo)

        End If
    End Sub

    Private Sub btnEst2_b_Click(sender As Object, e As EventArgs) Handles btnEst2_b.Click
        If tbEst2_Quantidade_b.EditValue > 0 Then
            'Carrega dados dalinha no modelo
            TelaParaModelo(modeloL)
            If tbEst2_Quantidade_b.EditValue > modeloL.estoque_2 Then
                MsgBox(String.Format("A quantidade ({0}) maior do que o Estoque 2 ({1}). ",
                                     tbEst2_Quantidade_b.EditValue, modeloL.estoque_2),
                                     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox(String.Format("Confirma a Baixa no estoque_2 de {0} linhas: ",
                                  tbEst2_Quantidade_b.Text),
                                  MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If


            modeloLH.acao = "Baixa"
            modeloLH.data = String.Format("{0:yyyy-MM-dd hh:mm:ss}", Now)
            modeloLH.linha_id = modeloL.codigo
            modeloLH.est2_anterior = modeloL.estoque_2 'valor atual
            modeloLH.est2_atual = tbEst1_Final_b.Text  'novo valor
            modeloLH.est1_anterior = modeloL.estoque_1 'mantem valores atuais
            modeloLH.est1_atual = modeloL.estoque_1    'mantem valores atuais

            modeloL.estoque_2 = tbEst2_Final_b.Text

            'objeto para gravar os dados no bd
            Dim bllL As New LinhaBLL()
            Dim bllLH As New LinhaHistoricoBLL()

            bllL.Altera(modeloL) 'Atualiza Linha
            bllLH.Incluir(modeloLH) 'Insere Histórico

            MessageBox.Show("Baixa realizada com sucesso!")
            Filtrar(modeloL.codigo)

        End If
    End Sub
    Private Sub txtCodigo_c_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo_c.KeyPress
        If e.KeyChar = vbCr Then
            txtFiltrar.Text = txtCodigo_c.Text
            Filtrar()

            tabEntraSaida.Enabled = True
            txtCodigo_c.Focus()
        End If
    End Sub

    Private Sub txtCodigo_e_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo_e.KeyPress
        If e.KeyChar = vbCr Then
            txtFiltrar.Text = txtCodigo_e.Text
            Filtrar()

            tabEntraSaida.Enabled = True
            txtCodigo_e.Focus()
        End If
    End Sub

    Private Sub txtCodigo_b_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo_b.KeyPress
        If e.KeyChar = vbCr Then
            txtFiltrar.Text = txtCodigo_b.Text
            Filtrar()

            tabEntraSaida.Enabled = True
            txtCodigo_b.Focus()
        End If
    End Sub

    Private Sub txtCodigo_m_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo_m.KeyPress
        If e.KeyChar = vbCr Then
            txtFiltrar.Text = txtCodigo_m.Text
            Filtrar()

            tabEntraSaida.Enabled = True
            txtCodigo_m.Focus()
        End If
    End Sub

    Private Sub btnEst1_para_Est2_Click(sender As Object, e As EventArgs) Handles btnEst1_para_Est2.Click
        If tbQuantidade_m.EditValue > 0 Then
            'Carrega dados dalinha no modelo
            TelaParaModelo(modeloL)
            If tbQuantidade_m.EditValue > modeloL.estoque_1 Then
                MsgBox(String.Format("A quantidade ({0}) maior do que o Estoque 1 ({1}). ",
                                     tbQuantidade_m.EditValue, modeloL.estoque_1),
                                     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox(String.Format("Confirma o Movimento de {0} linha(s) do Estoque 1 para o Estoque 2? ",
                                  tbQuantidade_m.EditValue),
                                  MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            modeloLH.acao = "Movimento"
            modeloLH.data = String.Format("{0:yyyy-MM-dd hh:mm:ss}", Now)
            modeloLH.linha_id = modeloL.codigo
            modeloLH.est1_anterior = modeloL.estoque_1 'valor atual
            modeloLH.est1_atual = modeloL.estoque_1 - tbQuantidade_m.EditValue   'novo valor
            modeloLH.est2_anterior = modeloL.estoque_2 'mantem valores atuais
            modeloLH.est2_atual = modeloL.estoque_2 + tbQuantidade_m.EditValue   'mantem valores atuais

            modeloL.estoque_1 = modeloLH.est1_atual
            modeloL.estoque_2 = modeloLH.est2_atual

            'objeto para gravar os dados no bd
            Dim bllL As New LinhaBLL()
            Dim bllLH As New LinhaHistoricoBLL()

            bllL.Altera(modeloL) 'Atualiza Linha
            bllLH.Incluir(modeloLH) 'Insere Histórico

            MessageBox.Show("Movimento realizado com sucesso!")
            Filtrar(modeloL.codigo)

        End If
    End Sub

    Private Sub btnEst2_para_Est1_Click(sender As Object, e As EventArgs) Handles btnEst2_para_Est1.Click
        If tbQuantidade_m.EditValue > 0 Then
            'Carrega dados dalinha no modelo
            TelaParaModelo(modeloL)
            If tbQuantidade_m.EditValue > modeloL.estoque_2 Then
                MsgBox(String.Format("A quantidade ({0}) maior do que o Estoque 2 ({1}). ",
                                     tbQuantidade_m.EditValue, modeloL.estoque_2),
                                     MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox(String.Format("Confirma o Movimento de {0} linha(s) do Estoque 2 para o Estoque 1? ",
                                  tbQuantidade_m.EditValue),
                                  MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            modeloLH.acao = "Movimento"
            modeloLH.data = String.Format("{0:yyyy-MM-dd hh:mm:ss}", Now)
            modeloLH.linha_id = modeloL.codigo
            modeloLH.est1_anterior = modeloL.estoque_1 'valor atual
            modeloLH.est1_atual = modeloL.estoque_1 + tbQuantidade_m.EditValue   'novo valor
            modeloLH.est2_anterior = modeloL.estoque_2 'mantem valores atuais
            modeloLH.est2_atual = modeloL.estoque_2 - tbQuantidade_m.EditValue   'mantem valores atuais

            modeloL.estoque_1 = modeloLH.est1_atual
            modeloL.estoque_2 = modeloLH.est2_atual

            'objeto para gravar os dados no bd
            Dim bllL As New LinhaBLL()
            Dim bllLH As New LinhaHistoricoBLL()

            bllL.Altera(modeloL) 'Atualiza Linha
            bllLH.Incluir(modeloLH) 'Insere Histórico

            MessageBox.Show("Movimento realizado com sucesso!")
            Filtrar(modeloL.codigo)

        End If
    End Sub

    Private Sub tbEst2_Quantidade_b_EditValueChanged(sender As Object, e As EventArgs) Handles tbEst2_Quantidade_b.EditValueChanged
        tbEst2_Final_b.Text = Val(tbEst2_Atual_b.Text) - tbEst2_Quantidade_b.EditValue
    End Sub

    Private Sub tbEst1_Quantidade_b_EditValueChanged(sender As Object, e As EventArgs) Handles tbEst1_Quantidade_b.EditValueChanged
        tbEst1_Final_b.Text = Val(tbEst1_Atual_b.Text) - tbEst1_Quantidade_b.Text
    End Sub

    Private Sub tbEst1_Quantidade_e_EditValueChanged(sender As Object, e As EventArgs) Handles tbEst1_Quantidade_e.EditValueChanged
        tbEst1_Final_e.EditValue = tbEst1_Atual_e.EditValue + tbEst1_Quantidade_e.EditValue
    End Sub

    Private Sub tbEst2_Quantidade_e_EditValueChanged(sender As Object, e As EventArgs) Handles tbEst2_Quantidade_e.EditValueChanged
        tbEst2_Final_e.EditValue = tbEst2_Atual_e.EditValue + tbEst2_Quantidade_e.EditValue
    End Sub

    Private Sub ModeloParaTela(modelo As Linha)
        If modelo.codigo Is Nothing Then Exit Sub
        txtCodigo_c.Text = modelo.codigo
        txtCodigo_e.Text = modelo.codigo
        txtCodigo_b.Text = modelo.codigo
        txtCodigo_m.Text = modelo.codigo

        txtNome.Text = modelo.nome
        tbNomeCor_e.Text = modelo.nome
        tbNomeCor_b.Text = modelo.nome
        tbNomeCor_m.Text = modelo.nome

        txtMaterial_Nome.Text = modelo.material_nome
        txtMaterial_Fabricante.Text = modelo.material_fabricante
        txtMaterial_Tipo.Text = modelo.material_tipo
        ceCor.EditValue = modelo.cor
        txtEstoque_1.Text = Convert.ToString(modelo.estoque_1)
        tbEst1_Atual_e.EditValue = modelo.estoque_1
        tbEst1_Atual_b.EditValue = modelo.estoque_1
        tbEst1_Atual_m.EditValue = modelo.estoque_1
        tbEst1_Final_e.EditValue = modelo.estoque_1
        tbEst1_Final_b.EditValue = modelo.estoque_1

        tbEst1_Quantidade_e.EditValue = 0
        tbEst2_Quantidade_e.EditValue = 0
        tbEst1_Quantidade_b.EditValue = 0
        tbEst2_Quantidade_b.EditValue = 0
        tbQuantidade_m.EditValue = 0

        txtEstoque_2.Text = Convert.ToString(modelo.estoque_2)
        tbEst2_Atual_e.EditValue = modelo.estoque_2
        tbEst2_Atual_b.EditValue = modelo.estoque_2
        tbEst2_Atual_m.EditValue = modelo.estoque_2
        tbEst2_Final_e.EditValue = modelo.estoque_2
        tbEst2_Final_b.EditValue = modelo.estoque_2

        txtMinimo.Text = Convert.ToString(modelo.minimo)
        txtPedido.Text = Convert.ToString(modelo.pedido)

        imb_c.BackColor = ceCor.Color

    End Sub

End Class