<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCadastroCliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroCliente))
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtContato_Nome = New System.Windows.Forms.TextBox()
        Me.MaterialNomeLabel = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.CorNomeLabel = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtContato_Funcao = New System.Windows.Forms.TextBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.txtInscr_Estadual = New System.Windows.Forms.TextBox()
        Me.MaterialTipoLabel = New System.Windows.Forms.Label()
        Me.txtCgc_Cpf = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MaterialFabricanteLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCEP = New System.Windows.Forms.TextBox()
        Me.txtTelefone3 = New System.Windows.Forms.TextBox()
        Me.txtTelefone2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.txtTelefone1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnGravar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.btnFechar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNovoCliente = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFiltrar = New DevExpress.XtraBars.BarButtonItem()
        Me.barManager1 = New DevExpress.XtraBars.BarManager()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.cbUF = New System.Windows.Forms.ComboBox()
        CType(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.label1.Location = New System.Drawing.Point(9, 82)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(69, 19)
        Me.label1.TabIndex = 121
        Me.label1.Text = "Código:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(54, 188)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 131
        Me.Label10.Text = "Nome:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(43, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Função:"
        '
        'txtContato_Nome
        '
        Me.txtContato_Nome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContato_Nome.Location = New System.Drawing.Point(92, 184)
        Me.txtContato_Nome.Name = "txtContato_Nome"
        Me.txtContato_Nome.Size = New System.Drawing.Size(463, 20)
        Me.txtContato_Nome.TabIndex = 125
        '
        'MaterialNomeLabel
        '
        Me.MaterialNomeLabel.AutoSize = True
        Me.MaterialNomeLabel.Location = New System.Drawing.Point(88, 143)
        Me.MaterialNomeLabel.Name = "MaterialNomeLabel"
        Me.MaterialNomeLabel.Size = New System.Drawing.Size(47, 13)
        Me.MaterialNomeLabel.TabIndex = 128
        Me.MaterialNomeLabel.Text = "Contato:"
        '
        'txtNome
        '
        Me.txtNome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNome.Location = New System.Drawing.Point(200, 80)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(354, 20)
        Me.txtNome.TabIndex = 1
        '
        'CorNomeLabel
        '
        Me.CorNomeLabel.AutoSize = True
        Me.CorNomeLabel.Location = New System.Drawing.Point(156, 83)
        Me.CorNomeLabel.Name = "CorNomeLabel"
        Me.CorNomeLabel.Size = New System.Drawing.Size(38, 13)
        Me.CorNomeLabel.TabIndex = 127
        Me.CorNomeLabel.Text = "Nome:"
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtId.Location = New System.Drawing.Point(79, 74)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(56, 29)
        Me.txtId.TabIndex = 0
        Me.txtId.TabStop = False
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtContato_Funcao
        '
        Me.txtContato_Funcao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContato_Funcao.Location = New System.Drawing.Point(92, 158)
        Me.txtContato_Funcao.Name = "txtContato_Funcao"
        Me.txtContato_Funcao.Size = New System.Drawing.Size(287, 20)
        Me.txtContato_Funcao.TabIndex = 2
        '
        'txtObs
        '
        Me.txtObs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObs.Location = New System.Drawing.Point(92, 332)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(465, 63)
        Me.txtObs.TabIndex = 151
        '
        'txtInscr_Estadual
        '
        Me.txtInscr_Estadual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInscr_Estadual.Location = New System.Drawing.Point(370, 214)
        Me.txtInscr_Estadual.Name = "txtInscr_Estadual"
        Me.txtInscr_Estadual.Size = New System.Drawing.Size(185, 20)
        Me.txtInscr_Estadual.TabIndex = 133
        '
        'MaterialTipoLabel
        '
        Me.MaterialTipoLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaterialTipoLabel.AutoSize = True
        Me.MaterialTipoLabel.Location = New System.Drawing.Point(286, 217)
        Me.MaterialTipoLabel.Name = "MaterialTipoLabel"
        Me.MaterialTipoLabel.Size = New System.Drawing.Size(77, 13)
        Me.MaterialTipoLabel.TabIndex = 136
        Me.MaterialTipoLabel.Text = "Inscr Estadual:"
        '
        'txtCgc_Cpf
        '
        Me.txtCgc_Cpf.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCgc_Cpf.Location = New System.Drawing.Point(92, 214)
        Me.txtCgc_Cpf.Name = "txtCgc_Cpf"
        Me.txtCgc_Cpf.Size = New System.Drawing.Size(164, 20)
        Me.txtCgc_Cpf.TabIndex = 132
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 335)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Obs:"
        '
        'MaterialFabricanteLabel
        '
        Me.MaterialFabricanteLabel.AutoSize = True
        Me.MaterialFabricanteLabel.Location = New System.Drawing.Point(34, 217)
        Me.MaterialFabricanteLabel.Name = "MaterialFabricanteLabel"
        Me.MaterialFabricanteLabel.Size = New System.Drawing.Size(57, 13)
        Me.MaterialFabricanteLabel.TabIndex = 135
        Me.MaterialFabricanteLabel.Text = "CGC/CPF:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(57, 309)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "email:"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Location = New System.Drawing.Point(92, 306)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(465, 20)
        Me.txtEmail.TabIndex = 149
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(450, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "CEP:"
        '
        'txtCEP
        '
        Me.txtCEP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCEP.Location = New System.Drawing.Point(489, 269)
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.Size = New System.Drawing.Size(68, 20)
        Me.txtCEP.TabIndex = 143
        '
        'txtTelefone3
        '
        Me.txtTelefone3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefone3.Location = New System.Drawing.Point(441, 106)
        Me.txtTelefone3.MaxLength = 15
        Me.txtTelefone3.Name = "txtTelefone3"
        Me.txtTelefone3.Size = New System.Drawing.Size(115, 20)
        Me.txtTelefone3.TabIndex = 4
        '
        'txtTelefone2
        '
        Me.txtTelefone2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefone2.Location = New System.Drawing.Point(321, 106)
        Me.txtTelefone2.MaxLength = 15
        Me.txtTelefone2.Name = "txtTelefone2"
        Me.txtTelefone2.Size = New System.Drawing.Size(115, 20)
        Me.txtTelefone2.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Telefone:"
        '
        'txtEndereco
        '
        Me.txtEndereco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEndereco.Location = New System.Drawing.Point(92, 244)
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.Size = New System.Drawing.Size(465, 20)
        Me.txtEndereco.TabIndex = 134
        '
        'txtTelefone1
        '
        Me.txtTelefone1.Location = New System.Drawing.Point(200, 106)
        Me.txtTelefone1.MaxLength = 15
        Me.txtTelefone1.Name = "txtTelefone1"
        Me.txtTelefone1.Size = New System.Drawing.Size(115, 20)
        Me.txtTelefone1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Endereço:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(334, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "UF:"
        '
        'txtCidade
        '
        Me.txtCidade.Location = New System.Drawing.Point(92, 269)
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(227, 20)
        Me.txtCidade.TabIndex = 139
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(49, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Cidade:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnGravar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.btnFechar)})
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Opções"
        '
        'btnGravar
        '
        Me.btnGravar.Caption = "Gravar"
        Me.btnGravar.Glyph = Global.ccb40.My.Resources.Resources.Minus_24
        Me.btnGravar.Id = 4
        Me.btnGravar.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete))
        Me.btnGravar.Name = "btnGravar"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "                                                                                 " &
    "         "
        Me.BarStaticItem1.Id = 17
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'btnFechar
        '
        Me.btnFechar.Caption = "Fechar"
        Me.btnFechar.Glyph = Global.ccb40.My.Resources.Resources.Minus_24
        Me.btnFechar.Id = 15
        Me.btnFechar.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Escape))
        Me.btnFechar.Name = "btnFechar"
        '
        'btnNovoCliente
        '
        Me.btnNovoCliente.Caption = "Novo Cliente"
        Me.btnNovoCliente.Glyph = Global.ccb40.My.Resources.Resources.Minus_24
        Me.btnNovoCliente.Id = 1
        Me.btnNovoCliente.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Insert))
        Me.btnNovoCliente.Name = "btnNovoCliente"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Caption = "Filtrar"
        Me.btnFiltrar.Glyph = CType(resources.GetObject("btnFiltrar.Glyph"), System.Drawing.Image)
        Me.btnFiltrar.Id = 16
        Me.btnFiltrar.Name = "btnFiltrar"
        '
        'barManager1
        '
        Me.barManager1.AllowQuickCustomization = False
        Me.barManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.barManager1.CloseButtonAffectAllTabs = False
        Me.barManager1.DockControls.Add(Me.barDockControlTop)
        Me.barManager1.DockControls.Add(Me.barDockControlBottom)
        Me.barManager1.DockControls.Add(Me.barDockControlLeft)
        Me.barManager1.DockControls.Add(Me.barDockControlRight)
        Me.barManager1.Form = Me
        Me.barManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnNovoCliente, Me.btnGravar, Me.btnFechar, Me.btnFiltrar, Me.BarStaticItem1})
        Me.barManager1.MainMenu = Me.Bar1
        Me.barManager1.MaxItemId = 18
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(563, 40)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 414)
        Me.barDockControlBottom.Size = New System.Drawing.Size(563, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 40)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 374)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(563, 40)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 374)
        '
        'cbUF
        '
        Me.cbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUF.FormattingEnabled = True
        Me.cbUF.ItemHeight = 13
        Me.cbUF.Items.AddRange(New Object() {"AC", "AL", "AP ", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"})
        Me.cbUF.Location = New System.Drawing.Point(362, 267)
        Me.cbUF.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbUF.Name = "cbUF"
        Me.cbUF.Size = New System.Drawing.Size(44, 21)
        Me.cbUF.TabIndex = 156
        '
        'frmCadastroCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 414)
        Me.Controls.Add(Me.cbUF)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.txtInscr_Estadual)
        Me.Controls.Add(Me.MaterialTipoLabel)
        Me.Controls.Add(Me.txtCgc_Cpf)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.MaterialFabricanteLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.txtTelefone3)
        Me.Controls.Add(Me.txtTelefone2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.txtTelefone1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtContato_Nome)
        Me.Controls.Add(Me.MaterialNomeLabel)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.CorNomeLabel)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.txtContato_Funcao)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCadastroCliente"
        Me.ShowInTaskbar = False
        Me.Text = "Cadastro Cliente"
        CType(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtContato_Nome As TextBox
    Friend WithEvents MaterialNomeLabel As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents CorNomeLabel As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtContato_Funcao As TextBox
    Friend WithEvents txtObs As TextBox
    Friend WithEvents txtInscr_Estadual As TextBox
    Friend WithEvents MaterialTipoLabel As Label
    Friend WithEvents txtCgc_Cpf As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents MaterialFabricanteLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCEP As TextBox
    Friend WithEvents txtTelefone3 As TextBox
    Friend WithEvents txtTelefone2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEndereco As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCidade As TextBox
    Friend WithEvents Label11 As Label
    Public WithEvents txtTelefone1 As TextBox
    Public WithEvents Bar1 As DevExpress.XtraBars.Bar
    Public WithEvents btnNovoCliente As DevExpress.XtraBars.BarButtonItem
    Public WithEvents btnGravar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnFiltrar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFechar As DevExpress.XtraBars.BarButtonItem
    Public WithEvents barManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Private WithEvents cbUF As ComboBox
End Class
