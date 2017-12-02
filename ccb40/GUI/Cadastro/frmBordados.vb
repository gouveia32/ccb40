Imports System.IO
Imports System.Drawing.Drawing2D
Imports ccb40.BLL
Imports System.Globalization
Imports System.Collections.Generic
Imports ccb40.DAL

Public Class frmBordados
    Dim dt1, dt2, dt3, dt4, dtPreco, dtCol As DataTable
    Dim dtLU As New DataTable()

    Dim DataId As Integer
    Dim TabCores() As Integer = {5208, 5311, 5151, 5075, 5310, 5158, 5045, 5058, 5208, 5311, 5151, 5075, 5310, 5158, 5045, 5058, 5208, 5311, 5151, 5075, 5310, 5158, 5045, 5058, 5208, 5311, 5151, 5075, 5310, 5158, 5045, 5058}
    Dim flagNotasespecialNova As Boolean = False

    Private loc As New fnLocalizar()
    Public UltimaSituacao As Integer = 1

    Public Sub AlteraBotoes(op As Integer)
        UltimaSituacao = op
        Select Case op
            Case 1            'Mostrar sem alteração
                btnNovo.Enabled = True
                btnGravar.Enabled = False
                btnDesfazer.Enabled = False
                btnExcluir.Enabled = True
                btnImprimir.Enabled = True
                pnlDados.Enabled = True
            Case 2            'Alterar: sem modificacao
                btnNovo.Enabled = True
                btnGravar.Enabled = False
                btnDesfazer.Enabled = False
                btnExcluir.Enabled = True
                btnImprimir.Enabled = True
                pnlDados.Enabled = True
            Case 3            'Alterar: com modificacao
                btnNovo.Enabled = False
                btnGravar.Enabled = True
                btnDesfazer.Enabled = True
                btnExcluir.Enabled = True
                btnImprimir.Enabled = True
                pnlDados.Enabled = True
            Case 4            'Novo sem alteração
                btnNovo.Enabled = False
                btnGravar.Enabled = False
                btnDesfazer.Enabled = False
                btnExcluir.Enabled = False
                btnImprimir.Enabled = False
                pnlDados.Enabled = True
            Case 5            'Novo com alteração
                btnNovo.Enabled = False
                btnGravar.Enabled = True
                btnDesfazer.Enabled = True
                btnImprimir.Enabled = False
                pnlDados.Enabled = True

        End Select
        btnEditar.Down = True

    End Sub
    Private Sub Filtrar(Optional Posicionar_id As Integer = 0)
        Dim bll As New BordadoBLL()
        Dim sWhere As String = ""
        Dim filtro As String = txtFiltrar.Text

        Dim currentCursor As Cursor = Cursor.Current
        Cursor.Current = Cursors.WaitCursor

        If IsNumeric(filtro) Then
            sWhere = "id=" & filtro.Trim
            filtro = ""
        Else
            If cbCatalogos.Text <> "Todos" Then
                sWhere = "catalogos.nome='" & Convert.ToString(cbCatalogos.Text) & "'"
            End If
            If cbFiltroGrupo.EditValue <> Nothing Then
                If sWhere = "" Then
                    sWhere = "grupo_id=" & Convert.ToInt32(cbFiltroGrupo.EditValue)
                Else
                    sWhere = " AND grupo_id=" & Convert.ToInt32(cbFiltroGrupo.EditValue)
                End If
            End If
        End If

        If sWhere <> "" Then
            dgRegistros.DataSource = bll.Filtrar(filtro, sWhere)
        Else
            dgRegistros.DataSource = bll.Filtrar(filtro)
        End If

        If Posicionar_id > 0 Then
            loc.Localizar(gvRegistros, String.Format("id={0}", Posicionar_id), 0, True)
        Else
            If gvRegistros.RowCount > 0 Then
                CarregaBordado(Convert.ToString(gvRegistros.GetDataRow(0).ItemArray(0)))
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

    Private Sub CarregaBordado(ByVal id As Integer, Optional AtualizaBotoes As Boolean = True)
        If id < 0 Then Exit Sub
        If btnGravar.Enabled Then
            If MsgBox("O registro atual foi alterado. Quer descartá-la?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Dim modeloB As Bordado = New Bordado()
        Dim modeloLU As List(Of LinhaUtilizada) = New List(Of LinhaUtilizada)()
        Dim BLL As BordadoBLL = New BordadoBLL()

        modeloB.LinhasUtilizadas = modeloLU
        modeloB = BLL.CarregaBordado(id)
        ModeloParaTela(modeloB)
        If AtualizaBotoes Then AlteraBotoes(1)
    End Sub

    Private Sub LimpaTela()
        Dim bit As Bitmap = New Bitmap(400, 400)
        Dim g As Graphics = Graphics.FromImage(bit)

        If btnGravar.Enabled And txtId.Text <> "" Then
            If MsgBox("O registro atual foi alterado. Quer descartá-la?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        txtId.Text = ""
        txtArquivo.Text = ""
        txtDescricao.Text = ""
        txtCaminho.Text = ""
        txtDisquete.Text = ""
        txtBastidor.Text = ""
        cbGrupo.Text = ""
        txtObs_Publica.Text = ""
        txtObs_Restrita.Text = ""
        txtCores.Text = ""
        txtPontos.Text = ""
        txtLargura.Text = ""
        txtAltura.Text = ""
        dtLU.Clear()
        dgLinhas_Utilizadas.DataSource = dtLU
        dgNotas.DataSource = Nothing
        g.Clear(peImagem.BackColor) ' limpa com a cor de fundo
        'peImagem.Image = bit
    End Sub

    Private Sub ModeloParaTela(modelo As Bordado)
        Try
            'gvNotas.Columns[2].Visible = False
            txtObs_Restrita.Visible = False
            txtId.Text = modelo.id.ToString()
            txtArquivo.Text = modelo.arquivo

            cbGrupo.SelectedValue = modelo.grupo_id

            txtDescricao.Text = modelo.descricao
            txtCaminho.Text = modelo.caminho
            txtLargura.Text = modelo.largura.ToString()
            txtAltura.Text = modelo.altura.ToString()
            txtCores.Text = modelo.cores.ToString()
            txtPontos.Text = modelo.pontos.ToString()
            txtDisquete.Text = modelo.disquete
            txtBastidor.Text = modelo.bastidor
            txtObs_Publica.Text = modelo.obs_publica
            txtObs_Restrita.Text = modelo.obs_Restrita
            'txtPreco.Text = modelo.preco.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"))
        Catch ex As Exception

        End Try
        'Carrega a Imagem
        Dim img As Byte() = DirectCast(modelo.imagem, Byte())

        If img IsNot Nothing Then
            If img.Length > 0 Then
                Dim ms As New MemoryStream(img)
                'picBordado.Image = Image.FromStream(ms)
                peImagem.Image = Image.FromStream(ms)
                ms.Dispose()
            Else
                peImagem.Image = Nothing
            End If
        Else
            peImagem.Image = Nothing
        End If

        'carrega Linhas do bordado
        dtLU.Rows.Clear()
        Dim i As Integer

        For i = 0 To modelo.LinhasUtilizadas.Count - 1
            dtLU.Rows.Add(modelo.LinhasUtilizadas(i).bordado_id,
                          modelo.LinhasUtilizadas(i).seq,
                          modelo.LinhasUtilizadas(i).codigo,
                          modelo.LinhasUtilizadas(i).cor,
                          modelo.LinhasUtilizadas(i).nome,
                          modelo.LinhasUtilizadas(i).pontos,
                          modelo.LinhasUtilizadas(i).metragem)
        Next

        dgLinhas_Utilizadas.DataSource = dtLU

        'carrega Notas Específicas, se tiver
        Dim bllNota As New NotaEspecificaBLL()
        'DataTable tabelaNota = new DataTable();
        dgNotas.DataSource = bllNota.NotasDoBordado(modelo.id)

        'Carrega catalogos
        Dim bllCat As New CatalogoBLL()
        dgCatalogos.DataSource = bllCat.CarregaCatalogosDoBordado(modelo.id)

    End Sub

    Private Sub TelaParaModelo(modelo As Bordado)
        Dim ms As MemoryStream = New MemoryStream
        Dim bAlterarImagem As Boolean = True

        If Not Me.peImagem.Image Is Nothing Then
            Try
                peImagem.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Catch
                Try
                    Dim bitmap As New Bitmap(peImagem.Image.Width, peImagem.Image.Height, peImagem.Image.PixelFormat)
                    Dim g As Graphics = Graphics.FromImage(bitmap)
                    g.DrawImage(peImagem.Image, New Point(0, 0))
                    g.Dispose()
                    peImagem.Image.Dispose()
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
                    ' preserve clone        
                    peImagem.Image = bitmap
                Catch
                    bAlterarImagem = False
                End Try
            End Try
        Else
            bAlterarImagem = False
        End If

        Dim bytBLOBData(ms.Length - 1) As Byte
        ms.Position = 0
        ms.Read(bytBLOBData, 0, ms.Length)

        modelo.id = Val(txtId.Text)
        modelo.arquivo = txtArquivo.Text
        modelo.grupo_id = Convert.ToInt32(cbGrupo.SelectedValue)
        modelo.descricao = txtDescricao.Text
        modelo.caminho = txtCaminho.Text
        modelo.largura = Convert.ToInt32(txtLargura.Text)
        modelo.altura = Convert.ToInt32(txtAltura.Text)
        modelo.cores = Convert.ToInt32(txtCores.Text)
        modelo.pontos = Convert.ToInt32(txtPontos.Text)
        modelo.disquete = txtDisquete.Text
        modelo.bastidor = txtBastidor.Text
        If bAlterarImagem Then
            modelo.imagem = bytBLOBData
        End If

        modelo.obs_publica = txtObs_Publica.Text
        modelo.obs_Restrita = txtObs_Restrita.Text
        'modelo.preco = txtPreco.Value
        'Linhas Utilizadas

        For r As Integer = 0 To gvLinhas_Utilizadas.RowCount - 1
            modelo.LinhasUtilizadas.Add(New LinhaUtilizada)
            modelo.LinhasUtilizadas(r).bordado_id = modelo.id
            modelo.LinhasUtilizadas(r).seq = r + 1
            modelo.LinhasUtilizadas(r).codigo = Convert.ToString(gvLinhas_Utilizadas.GetDataRow(r).Item("codigo"))
            modelo.LinhasUtilizadas(r).cor = Convert.ToInt32(gvLinhas_Utilizadas.GetDataRow(r).Item("cor"))
            modelo.LinhasUtilizadas(r).nome = Convert.ToString(gvLinhas_Utilizadas.GetDataRow(r).Item("nome"))
            modelo.LinhasUtilizadas(r).pontos = Convert.ToInt32(gvLinhas_Utilizadas.GetDataRow(r).Item("pontos"))
            modelo.LinhasUtilizadas(r).metragem = Convert.ToInt32(gvLinhas_Utilizadas.GetDataRow(r).Item("metragem"))
        Next r

    End Sub

    Private Sub GravarRegistro()
        Dim idAtual As Integer = Val(txtId.Text)

        If txtArquivo.Text = "" Then
            MsgBox("Selecione primeiro um arquivo no formato Tajima (dst)", vbOK)
            btnBrowse_Click(Nothing, Nothing)
            Exit Sub
        End If

        Try
            'leitura dos dados
            Dim modeloB As New Bordado()
            Dim modelLU As New List(Of LinhaUtilizada)
            modeloB.LinhasUtilizadas = modelLU
            TelaParaModelo(modeloB)

            'objeto para gravar os dados no bd
            Dim bll As New BordadoBLL()

            If idAtual = 0 Then     'Novo
                'cadastrar novo bordado
                bll.Incluir(modeloB)
                idAtual = modeloB.id
                MessageBox.Show("Bordado Inserido. Id=" + modeloB.id.ToString())
                AlteraBotoes(2)
                Filtrar(idAtual)
                GravaLog(Conn, "Bordados", "Bordados", txtId.Text, "Bordado Cadastrado.")
            Else
                'alerar um cliente
                idAtual = Convert.ToInt32(txtId.Text)
                modeloB.id = Convert.ToInt32(txtId.Text)
                bll.Altera(modeloB)
                MessageBox.Show("Bordado alterado!")
                AlteraBotoes(2)
                Filtrar(idAtual)
                'GravaLog(Conn, "Cadastros", "Empregados", txtId.Text, "Empregado Alterado.")
            End If

        Catch erro As Exception
            MessageBox.Show(erro.Message)
        End Try

    End Sub

    Private Sub _TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArquivo.TextChanged, txtObs_Publica.TextChanged, txtDescricao.TextChanged, txtCaminho.TextChanged, chkAprovado.CheckedChanged, cbGrupo.TextChanged, txtObs_Restrita.TextChanged, txtPontos.TextChanged, txtLargura.TextChanged, txtDisquete.TextChanged, txtCores.TextChanged, txtBastidor.TextChanged, txtAltura.TextChanged
        Select Case UltimaSituacao
            Case 4, 5 'Novo sem alt
                AlteraBotoes(5) 'Novo com alt
            Case 2, 3 'Alterar: com mod
                AlteraBotoes(3) 'Alterar: sem alter
        End Select
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim p As Integer

        dlgFileOpen.Filter = "Arquivos Tajima (*.dst)|*.dst"
        dlgFileOpen.InitialDirectory = "c:\BORDADOS"
        dlgFileOpen.ShowDialog()
        p = dlgFileOpen.FileName.LastIndexOf("\")
        txtArquivo.Text = dlgFileOpen.FileName.Substring(p + 1)
        txtCaminho.Text = dlgFileOpen.FileName.Substring(0, p + 1)
        txtArquivo.SelectionStart = txtArquivo.Text.Length 'to show the last portion of text
        If Trim(txtArquivo.Text) <> "" Then
            If LerDST(txtCaminho.Text & txtArquivo.Text) Then
                MsgBox("DST carregado", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Function CarregaLinha(ByVal codigo As String, ByVal seq As Integer) As DataRow
        Dim LinhaModelo As New Linha()
        Dim LinhaBLL As New LinhaBLL()
        Dim dr As DataRow = dtLU.NewRow

        LinhaModelo = LinhaBLL.CarregaLinha(codigo)

        dr.Item("seq") = seq + 1
        dr.Item("codigo") = LinhaModelo.codigo
        dr.Item("cor") = LinhaModelo.cor
        dr.Item("nome") = LinhaModelo.nome
        Return dr

    End Function

    Private Function LerDST(ByVal NomeArqEnt As String) As Boolean
        Dim DstHdr(512) As String
        Dim Reg(3) As Byte
        Dim Comprimento(32) As Integer
        Dim Pontos(32) As Integer
        Dim zoom, idxLoop As Integer
        Dim P, X0, Y0, X, Y, mCor, NrPontos, Xmais, Xmenos, Ymais, Ymenos, Largura, Altura, Cores As Integer

        If Not System.IO.File.Exists(NomeArqEnt) Then
            MsgBox("O arquivo [" & NomeArqEnt & "] não foi encontrado!", MsgBoxStyle.Exclamation)
            Return False
        End If

        Dim bit As Bitmap

        If peImagem.Image Is Nothing Then
            bit = New Bitmap(400, 400)
            'g.Clear(peImagem.BackColor) ' limpa com a cor de fundo
            peImagem.Image = bit
        Else
            bit = New Bitmap(peImagem.Image.Width, peImagem.Image.Height)
        End If

        Dim g As Graphics = Graphics.FromImage(bit)
        Dim linGrBrush As LinearGradientBrush = New LinearGradientBrush(
                New Point(0, 0),
                New Point(200, 100),
                Color.FromArgb(255, 0, 0, 255),   ' opaque blue
                Color.FromArgb(255, 0, 255, 0))   ' opaque green

        Dim myPen As Pen = New Pen(linGrBrush, 1.6)
        Dim salto As Boolean

        Dim arquivo As New StreamReader(NomeArqEnt, System.Text.Encoding.Default)
        If arquivo Is Nothing Then Return False
        Dim conteudo As String = arquivo.ReadToEnd()
        arquivo.Close()

        Xmais = Val(conteudo.Substring(42, 5))
        Xmenos = Val(conteudo.Substring(51, 5))
        Ymais = Val(conteudo.Substring(60, 5))
        Ymenos = Val(conteudo.Substring(69, 5))
        Largura = Xmais + Xmenos
        Altura = Ymais + Ymenos
        Cores = Val(conteudo.Substring(35, 3)) + 1

        NrPontos = Val(conteudo.Substring(24, 7))
        X0 = Largura / 2
        Y0 = Altura / 2
        X = X0
        Y = Y0
        If (Largura > Altura) And (Largura <> 0) Then
            zoom = (peImagem.Image.Width * 100) / Largura
        ElseIf Altura <> 0 Then
            zoom = (peImagem.Image.Height * 100) / Altura
        Else
            zoom = 1
        End If
        'picBordado.BackColor = Color.FromArgb(TabCores(0))
        g.Clear(peImagem.BackColor) ' limpa com a cor de fundo
        Comprimento(0) = 0
        mCor = dtLU.Rows.Count   ' uso mCor temporariamente
        If mCor > Cores Then 'Ajusta para nova quantidade de linhas : removendo
            For P = mCor - 1 To Cores Step -1
                'dgLinhas_Utilizadas.Rows.Remove(dgLinhas_Utilizadas.Rows(P))
                dtLU.Rows(P).Delete()
            Next
        Else
            If mCor < Cores Then  'Ajusta para nova quantidade de linhas : adicionando
                For P = mCor To Cores - 1

                    dtLU.Rows.Add(CarregaLinha(TabCores(P), P))
                Next
                dgLinhas_Utilizadas.DataSource = dtLU
            End If
        End If

        mCor = 0

        linGrBrush.LinearColors(0) = Color.FromArgb(dtLU.Rows(mCor).Item("cor"))
        linGrBrush.LinearColors(1) = Color.FromArgb(dtLU.Rows(mCor).Item("cor") + 5)

        myPen.Color = Color.FromArgb(dtLU.Rows(mCor).Item("cor"))
        P = 0

        For idxLoop = 512 To conteudo.Length - 3 Step 3
            Reg(1) = Asc(conteudo(idxLoop))
            Reg(2) = Asc(conteudo(idxLoop + 1))
            Reg(3) = Asc(conteudo(idxLoop + 2))

            If (Reg(3) And 64) <> 0 Then ' Troca de cor
                Pontos(mCor) = P
                mCor += 1

                If mCor < dtLU.Rows.Count Then
                    'dtLU.Rows(mCor - 1).Item("pontos") = Pontos(mCor - 1)
                    'dtLU.Rows(mCor - 1).Item("metragem") = Comprimento(mCor - 1)

                    linGrBrush = New LinearGradientBrush(
                                        New Point(0, 0),
                                        New Point(200, 100),
                                        Color.FromArgb(dtLU.Rows(mCor).Item("cor")),   ' opaque blue
                                        Color.FromArgb(dtLU.Rows(mCor).Item("cor")))   ' opaque green

                    myPen = New Pen(linGrBrush, 1)

                End If
                P = 0
                Comprimento(mCor) = 0
                Pontos(mCor) = P

                'Image1.Canvas.Pen.Color = TabCores(I)
            End If
            salto = False
            If (Reg(3) And 128) <> 0 Then
                P = P - 1 ' Salto
                salto = True
            End If
            If (Reg(3) And 4) <> 0 Then X = X + 81
            If (Reg(3) And 8) <> 0 Then X = X - 81
            If (Reg(3) And 16) <> 0 Then Y = Y + 81
            If (Reg(3) And 32) <> 0 Then Y = Y - 81

            If (Reg(2) And 1) <> 0 Then X = X + 3
            If (Reg(2) And 2) <> 0 Then X = X - 3
            If (Reg(2) And 4) <> 0 Then X = X + 27
            If (Reg(2) And 8) <> 0 Then X = X - 27
            If (Reg(2) And 16) <> 0 Then Y = Y + 27
            If (Reg(2) And 32) <> 0 Then Y = Y - 27
            If (Reg(2) And 64) <> 0 Then Y = Y + 3
            If (Reg(2) And 128) <> 0 Then Y = Y - 3

            If (Reg(1) And 1) <> 0 Then X = X + 1
            If (Reg(1) And 2) <> 0 Then X = X - 1
            If (Reg(1) And 4) <> 0 Then X = X + 9
            If (Reg(1) And 8) <> 0 Then X = X - 9
            If (Reg(1) And 16) <> 0 Then Y = Y + 9
            If (Reg(1) And 32) <> 0 Then Y = Y - 9
            If (Reg(1) And 64) <> 0 Then Y = Y + 1
            If (Reg(1) And 128) <> 0 Then Y = Y - 1

            Dim XX0, YY0, XX, YY As Integer
            XX0 = X0 * zoom / 100
            YY0 = Y0 * zoom / 100
            XX = X * zoom / 100
            YY = Y * zoom / 100
            If (XX - XX0 > 64) Or (YY - YY0 > 64) Then salto = True 'Elimina pontos longos
            If salto = False Then g.DrawLine(myPen, XX0, YY0, XX, YY)
            Comprimento(mCor) = Comprimento(mCor) + Math.Abs(X - X0) + Math.Abs(Y - Y0)
            P = P + 1
            X0 = X
            Y0 = Y
        Next idxLoop
        peImagem.Image = bit

        txtCores.Text = Cores
        txtPontos.Text = NrPontos
        txtLargura.Text = Largura
        txtAltura.Text = Altura
        For idxLoop = 0 To Cores - 1 'Atualiza metragem
            dtLU.Rows(idxLoop).Item("metragem") = Comprimento(idxLoop) \ 13
            dtLU.Rows(idxLoop).Item("pontos") = Pontos(idxLoop)
        Next

        btnGravar.Enabled = True
        Return True
    End Function

    Private Sub RestritoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestritoToolStripMenuItem.Click
        If My.Settings.Nivel < 4 Then Exit Sub 'Só pode habilitar usuário nível 5
        txtObs_Restrita.Visible = Not txtObs_Restrita.Visible
        'txtPreco.Visible = txtObs_Restrita.Visible
        valor.Visible = txtObs_Restrita.Visible
        frmNotas.diValor.Visible = txtObs_Restrita.Visible
    End Sub

    Private Sub frmBordados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.WindowState <> FormWindowState.Maximized Then Me.WindowState = FormWindowState.Maximized




        'Prepara DataTable para LinhaUtilizada
        With dtLU
            .Columns.Add("bordado_id")
            .Columns.Add("seq")
            .Columns.Add("codigo")
            .Columns.Add("cor")
            .Columns.Add("nome")
            .Columns.Add("pontos")
            .Columns.Add("metragem")
        End With

        AlteraBotoes(1)
        Filtrar()
        If gvRegistros.Columns.Count > 0 Then
            gvRegistros.Columns("id").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            gvRegistros.Columns("id").Width = 70
            gvRegistros.Columns("descricao").Width = 200
            gvRegistros.Columns("arquivo").Width = 120
            gvRegistros.Columns("obs_publica").Visible = False
            gvRegistros.Columns("catalogo").Visible = False
            gvRegistros.Columns("id").Summary.Add(DevExpress.Data.SummaryItemType.Count, "id", "{0}")
        End If

        'Filtro Catalogo
        Dim c As New CatalogoBLL()
        With cbCatalogos.Properties
            .DataSource = c.TodosCatalogos("Todos")
            .DisplayMember = "nome"
            .ValueMember = "nome"
            '.PopulateColumns()
            '.Columns(0).Width = 60
        End With
        cbCatalogos.Text = "Todos"

        'CarregaCombo Grupo_id
        Dim g As New GrupoBLL()
        cbGrupo.DataSource = g.TodosGrupos("Todos")
        cbGrupo.DisplayMember = "grupo"
        cbGrupo.ValueMember = "id"
        cbGrupo.TabIndex = 0

        'Filtro Grupo
        With cbFiltroGrupo.Properties
            .DataSource = g.TodosGrupos("Todos")
            .DisplayMember = "grupo"
            .ValueMember = "id"
            '.PopulateColumns()
            '.Columns(0).Width = 60
        End With

        cbFiltroGrupo.Text = "Todos"

        '' gvNotas.Columns("valor").Visible = False

    End Sub

    Private Sub btncadastroCliente_Click(sender As Object, e As EventArgs)
        frmCadastroCliente.ShowDialog()
    End Sub

    Private Sub GravaNota()
        Dim bll As New NotaEspecificaBLL()
        Dim modelo As New NotaEspecifica()
        modelo.bordado_id = Convert.ToInt32(txtId.Text)
        modelo.cliente_id = frmNotas.cliente_id
        modelo.data_atualizacao = DateTime.Now
        modelo.valor = Convert.ToDecimal(frmNotas.diValor.Text)
        modelo.obs = frmNotas.txtObsEspecifica.Text
        If modelo.cliente_id < 1 Then Exit Sub

        If flagNotasespecialNova Then
            bll.Insere(modelo)
        Else
            bll.Altera(modelo)
        End If

        CarregaBordado(Convert.ToInt32(txtId.Text))
        'atualiza tela com informaçoes dos bordado selecionado
    End Sub

    Private Sub btnDesmarcarTodos_Click(sender As Object, e As EventArgs)
        Dim r As Integer
        For r = 0 To gvRegistros.RowCount - 1
            gvRegistros.GetDataRow(r).Item(0).Value = False
            GravarRegistro()
        Next
    End Sub

    Private Sub GravarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GravarToolStripMenuItem.Click
        GravarRegistro()
    End Sub

    Private Sub btnNovo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNovo.ItemClick
        txtFiltrar.Text = ""
        cbCatalogos.Text = "Todos"
        cbFiltroGrupo.Text = "Todos"
        Filtrar()
        LimpaTela()
        AlteraBotoes(4)
        txtDescricao.Focus()
    End Sub

    Private Sub btnGravar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGravar.ItemClick
        GravarRegistro()
    End Sub

    Private Sub btnExcluir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExcluir.ItemClick
        Try
            Dim d As DialogResult = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If d.ToString() = "Yes" Then
                Dim bll As New BordadoBLL()
                bll.Exclui(Convert.ToInt32(txtId.Text))
                LimpaTela()
                Filtrar()
            End If
        Catch erro As Exception
            MessageBox.Show("Impossível excluir o registro. " & vbLf & " O registro está sendo utilizado em outro local.")
        End Try
    End Sub

    Private Sub btnImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImprimir.ItemClick
        ''frmMenuImpressao.ImprimirColecaoBordados()
    End Sub

    Private Sub AtualizaImagem(Optional EscolheFundo As Boolean = True)
        ColorDialog1.Color = peImagem.BackColor
        peImagem.Visible = True
        If EscolheFundo Then
            If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                peImagem.Visible = False
                Exit Sub
            End If
        End If
        peImagem.BackColor = ColorDialog1.Color
        'picBordado.BackColor = ColorDialog1.Color
        LerDST(txtCaminho.Text & txtArquivo.Text)
    End Sub

    Private Sub btnAlteraImagem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAlteraImagem.ItemClick
        AtualizaImagem()
    End Sub

    Private Sub gvRegistros_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvRegistros.FocusedRowChanged
        If e.FocusedRowHandle >= 0 Then
            CarregaBordado(Convert.ToInt32(gvRegistros.GetDataRow(e.FocusedRowHandle).ItemArray(0)))
            gvNotas.Columns("valor").Visible = False
        End If
    End Sub

    Private Sub gvRegistros_DoubleClick(sender As Object, e As EventArgs) Handles gvRegistros.DoubleClick
        AlteraBotoes(2)
    End Sub

    Private Sub btnEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick
        pnlDados.Enabled = btnEditar.Down
        Select Case UltimaSituacao
            Case 1 'Navegando
                AlteraBotoes(2) 'Alterar
        End Select
        If pnlDados.Enabled Then
            txtArquivo.Focus()
        End If
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

    Private Sub cbCatalogos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Filtrar()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Filtrar()
    End Sub

    Private Sub cbFiltroGrupo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Filtrar()
    End Sub

    Private Sub cbFiltroGrupo_EditValueChanged(sender As Object, e As EventArgs)
        Filtrar()
    End Sub

    Private Sub gvLinhas_Utilizadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gvLinhas_Utilizadas.KeyPress
        Dim LinhaAtual, r As Integer

        If e.KeyChar = Chr(&H4) Then  'ctrl+d
            LinhaAtual = gvLinhas_Utilizadas.FocusedRowHandle
            Dim dr As DataRow = dtLU.Rows(LinhaAtual)

            dtLU.Rows.Remove(dr)
            For r = LinhaAtual To dtLU.Rows.Count - 1
                dtLU.Rows(r).Item("seq") = r + 1
            Next

        End If
        If e.KeyChar = vbCr Then 'Enter
            LerDST(txtArquivo.Text)
        End If

    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click

        flagNotasespecialNova = True

        'frmNotas.cliente_id = 0

        frmNotas.CarregaComboClientes()
        frmNotas.cbCliente.EditValue = DBNull.Value
        'frmNotas.cbCliente.Text = ""
        'frmNotas.diValor.Value = txtPreco.Text
        frmNotas.txtObsEspecifica.Text = ""

        frmNotas.cbCliente.Enabled = True
        frmNotas.cbCliente.Focus()
        If frmNotas.ShowDialog() = DialogResult.OK Then
            For r As Integer = 0 To gvNotas.RowCount - 1
                If gvNotas.GetDataRow(r).Item(0) = frmNotas.cbCliente.EditValue Then
                    MsgBox(String.Format("Já existe nota para este cliente ({0})!", frmNotas.cbCliente.Text), vbCritical)
                    Exit Sub
                End If
            Next
            GravaNota()
        End If

    End Sub

    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click

        If gvNotas.FocusedRowHandle < 0 Then Exit Sub
        Dim BLLn As New NotaEspecificaBLL()
        BLLn.Exclui(txtId.Text, gvNotas.GetDataRow(gvNotas.FocusedRowHandle).Item(0))
        CarregaBordado(Convert.ToInt32(txtId.Text))
    End Sub

    Private Sub AlteraNota()
        flagNotasespecialNova = False

        'frmNotas.cliente_id = gvNotas.GetDataRow(gvNotas.FocusedRowHandle).Item("id")
        frmNotas.cbCliente.EditValue = gvNotas.GetDataRow(gvNotas.FocusedRowHandle).Item("id")
        frmNotas.cbCliente.Text = gvNotas.GetDataRow(gvNotas.FocusedRowHandle).Item("cliente")
        frmNotas.diValor.Value = gvNotas.GetDataRow(gvNotas.FocusedRowHandle).Item("valor")
        frmNotas.txtObsEspecifica.Text = gvNotas.GetDataRow(gvNotas.FocusedRowHandle).Item("obs")
        frmNotas.CarregaComboClientes()
        'frmNotas.SelecionaClienteNoCombo(id)
        frmNotas.cbCliente.Enabled = False
        If frmNotas.ShowDialog() = DialogResult.OK Then
            GravaNota()
        End If
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        AlteraNota()
    End Sub

    Private Sub cbFiltroGrupo_EditValueChanged_1(sender As Object, e As EventArgs) Handles cbFiltroGrupo.EditValueChanged
        Filtrar()
    End Sub

    Private Sub cbCatalogos_EditValueChanged_1(sender As Object, e As EventArgs) Handles cbCatalogos.EditValueChanged
        Filtrar()
    End Sub

    Private Sub gvNotas_DoubleClick(sender As Object, e As EventArgs) Handles gvNotas.DoubleClick
        AlteraNota()
    End Sub

    Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
        txtFiltrar.Text = ""
        cbCatalogos.Text = "Todos"
        cbFiltroGrupo.Text = "Todos"
        Filtrar()
    End Sub

    Private Sub gvRegistros_KeyDown(sender As Object, e As KeyEventArgs) Handles gvRegistros.KeyDown
        If e.KeyCode = 13 Then
            AlteraBotoes(2)
        End If
    End Sub

    Private Sub gvLinhas_Utilizadas_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvLinhas_Utilizadas.CellValueChanged
        If e.Column.Name <> "codigo" Then Exit Sub

        Dim dr As DataRow = dtLU.NewRow

        dr = CarregaLinha(e.Value, 1)
        gvLinhas_Utilizadas.SetRowCellValue(gvLinhas_Utilizadas.FocusedRowHandle, "cor", dr("cor"))
        gvLinhas_Utilizadas.SetRowCellValue(gvLinhas_Utilizadas.FocusedRowHandle, "nome", dr("nome"))
        AtualizaImagem(False)
        _TextChanged(sender, e)
    End Sub

    Private Sub dgLinhas_Utilizadas_KeyUp(sender As Object, e As KeyEventArgs) Handles dgLinhas_Utilizadas.KeyUp
        If e.KeyValue = 13 Then
            gvLinhas_Utilizadas.MoveNext()
        End If
    End Sub

    Private Sub btnDesfazer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDesfazer.ItemClick
        Try
            If MessageBox.Show("Desfazer as alterações?", "Aviso",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                If txtId.Text <> "" Then
                    Dim bll As New BordadoBLL()
                    Dim modelo As Bordado = bll.CarregaBordado(Convert.ToInt32(txtId.Text))
                    AlteraBotoes(2)
                    ModeloParaTela(modelo)
                    AlteraBotoes(2)

                Else
                    AlteraBotoes(4)
                    LimpaTela()
                    AlteraBotoes(4)
                End If
            End If
        Catch erro As Exception
            MessageBox.Show("Falha ao carregar o registro.")
        End Try
    End Sub

    Private Sub cbCatalogos_EditValueChanged(sender As Object, e As EventArgs)
        Filtrar()
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        txtFiltrar.Text = ""
        Filtrar()
        btnX.Visible = False
    End Sub

    Private Sub btnNovoCatalogo_Click(sender As Object, e As EventArgs) Handles btnNovoCatalogo.Click
        Dim cat As String

        cat = InputBox("Nome do Novo Catálogo?")
        If cat = "" Then Exit Sub

        Dim bllC As New CatalogoBLL()
        Dim modeloC As New Catalogo()

        If bllC.ExisteCatalogo(cat) Then 'checa se o nome do catalogo já existe
            If MsgBox(String.Format("O catálogo ({0}) já existe, Posso Seleciná-lo?", cat), vbYesNo) <> vbYes Then
                Exit Sub
            End If
        End If

        modeloC.bordado_id = txtId.Text
        modeloC.nome = cat
        bllC.Incluir(modeloC)
        CarregaBordado(modeloC.bordado_id, False)

    End Sub

    Private Sub btnRemoverCatalogo_Click(sender As Object, e As EventArgs) Handles btnRemoverCatalogo.Click
        Dim cat As String

        If dgCatalogos.CurrentCell Is Nothing Then Exit Sub

        cat = dgCatalogos.CurrentCell.Value
        Dim bllC As New CatalogoBLL()

        bllC.Excluir(cat, txtId.Text)

        CarregaBordado(txtId.Text, False)

    End Sub

    Private Sub btnSelecionarCatalogo_Click(sender As Object, e As EventArgs) Handles btnSelecionarCatalogo.Click
        If frmEscolheCatalogo.ShowDialog() = DialogResult.OK Then
            Dim cat As String

            If frmEscolheCatalogo.cbCatalogo.Text <> "" Then
                cat = frmEscolheCatalogo.cbCatalogo.Text.Substring(0, frmEscolheCatalogo.cbCatalogo.Text.IndexOf("(") - 1)

                Dim bllC As New CatalogoBLL()

                If bllC.ExisteCatalogo(cat, txtId.Text) Then
                    Exit Sub 'Já existe
                End If

                Dim modeloC As New Catalogo()
                modeloC.bordado_id = txtId.Text
                modeloC.nome = cat
                bllC.Incluir(modeloC)

                If frmEscolheCatalogo.cbGrupo.Text <> "Todos" Then
                    GravarRegistro() 'atualiza o bordado
                End If
                CarregaBordado(modeloC.bordado_id, False)
            End If
        End If

    End Sub


End Class