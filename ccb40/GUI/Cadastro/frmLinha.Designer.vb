<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLinha
    'Inherits DevComponents.DotNetBar.OfficeForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLinha))
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Me.cor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemColorPickEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit()
        Me.dgRegistros = New DevExpress.XtraGrid.GridControl()
        Me.gvRegistros = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.codigo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.nome = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.estoque_1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.minimo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.btnFiltrar = New DevExpress.XtraEditors.DropDownButton()
        Me.txtPreco_Base = New System.Windows.Forms.MaskedTextBox()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.scc1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.pnlPesquisa = New DevExpress.XtraEditors.PanelControl()
        Me.btnX = New DevExpress.XtraEditors.DropDownButton()
        Me.txtFiltrar = New DevExpress.XtraEditors.TextEdit()
        Me.pnlDados = New DevExpress.XtraEditors.PanelControl()
        Me.deDataInicial = New DevExpress.XtraEditors.DateEdit()
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.imb_c = New DevExpress.XtraEditors.ImageListBoxControl()
        Me.dgLog = New DevExpress.XtraGrid.GridControl()
        Me.gvLog = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.compra = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.uso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repositoryItemColorEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemColorEdit()
        Me.chartLinhaHistorico = New DevExpress.XtraCharts.ChartControl()
        Me.tabEntraSaida = New DevExpress.XtraTab.XtraTabControl()
        Me.xtbpCadastro = New DevExpress.XtraTab.XtraTabPage()
        Me.txtEstoque_2 = New System.Windows.Forms.TextBox()
        Me.ceCor = New DevExpress.XtraEditors.ColorEdit()
        Me.txtEstoque_1 = New System.Windows.Forms.TextBox()
        Me.txtCodigo_c = New System.Windows.Forms.TextBox()
        Me.txtMinimo = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.PedidoLabel = New System.Windows.Forms.Label()
        Me.LinhaIdLabel = New System.Windows.Forms.Label()
        Me.EstoqueQuantidadeLabel = New System.Windows.Forms.Label()
        Me.MaterialNomeLabel = New System.Windows.Forms.Label()
        Me.EstoqueMinimoLabel = New System.Windows.Forms.Label()
        Me.txtMaterial_Fabricante = New System.Windows.Forms.TextBox()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.MaterialFabricanteLabel = New System.Windows.Forms.Label()
        Me.txtMaterial_Nome = New System.Windows.Forms.TextBox()
        Me.MaterialTipoLabel = New System.Windows.Forms.Label()
        Me.txtMaterial_Tipo = New System.Windows.Forms.TextBox()
        Me.xtbpEntrada = New DevExpress.XtraTab.XtraTabPage()
        Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.tbEst2_Quantidade_e = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst2_Final_e = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst2_Atual_e = New DevExpress.XtraEditors.TextEdit()
        Me.btnEst2_e = New DevExpress.XtraEditors.SimpleButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.labelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.pnlEst1_e = New DevExpress.XtraEditors.PanelControl()
        Me.tbEst1_Final_e = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst1_Atual_e = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst1_Quantidade_e = New DevExpress.XtraEditors.TextEdit()
        Me.btnEst1_e = New DevExpress.XtraEditors.SimpleButton()
        Me.label30 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbNomeCor_e = New System.Windows.Forms.TextBox()
        Me.txtCodigo_e = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.xtbpBaixa = New DevExpress.XtraTab.XtraTabPage()
        Me.labelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.tbEst2_Quantidade_b = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst2_Final_b = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst2_Atual_b = New DevExpress.XtraEditors.TextEdit()
        Me.btnEst2_b = New DevExpress.XtraEditors.SimpleButton()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label17 = New System.Windows.Forms.Label()
        Me.labelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.tbEst1_Final_b = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst1_Atual_b = New DevExpress.XtraEditors.TextEdit()
        Me.tbEst1_Quantidade_b = New DevExpress.XtraEditors.TextEdit()
        Me.btnEst1_b = New DevExpress.XtraEditors.SimpleButton()
        Me.label18 = New System.Windows.Forms.Label()
        Me.label19 = New System.Windows.Forms.Label()
        Me.label20 = New System.Windows.Forms.Label()
        Me.label21 = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.tbNomeCor_b = New System.Windows.Forms.TextBox()
        Me.txtCodigo_b = New System.Windows.Forms.TextBox()
        Me.label23 = New System.Windows.Forms.Label()
        Me.label46 = New System.Windows.Forms.Label()
        Me.dtpData_Execucao = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnExecutarItem = New DevComponents.DotNetBar.ButtonX()
        Me.xtbpMovimento = New DevExpress.XtraTab.XtraTabPage()
        Me.btnEst2_para_Est1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEst1_para_Est2 = New DevExpress.XtraEditors.SimpleButton()
        Me.label34 = New System.Windows.Forms.Label()
        Me.panelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.tbEst2_Atual_m = New DevExpress.XtraEditors.TextEdit()
        Me.labelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.panelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.tbEst1_Atual_m = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tbNomeCor_m = New System.Windows.Forms.TextBox()
        Me.txtCodigo_m = New System.Windows.Forms.TextBox()
        Me.label35 = New System.Windows.Forms.Label()
        Me.tbQuantidade_m = New DevExpress.XtraEditors.TextEdit()
        CType(Me.RepositoryItemColorPickEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scc1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scc1.SuspendLayout()
        CType(Me.pnlPesquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPesquisa.SuspendLayout()
        CType(Me.txtFiltrar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDados.SuspendLayout()
        CType(Me.deDataInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDataInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imb_c, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repositoryItemColorEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartLinhaHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabEntraSaida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEntraSaida.SuspendLayout()
        Me.xtbpCadastro.SuspendLayout()
        CType(Me.ceCor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtbpEntrada.SuspendLayout()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl1.SuspendLayout()
        CType(Me.tbEst2_Quantidade_e.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst2_Final_e.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst2_Atual_e.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlEst1_e, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEst1_e.SuspendLayout()
        CType(Me.tbEst1_Final_e.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst1_Atual_e.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst1_Quantidade_e.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtbpBaixa.SuspendLayout()
        CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl2.SuspendLayout()
        CType(Me.tbEst2_Quantidade_b.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst2_Final_b.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst2_Atual_b.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl3.SuspendLayout()
        CType(Me.tbEst1_Final_b.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst1_Atual_b.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEst1_Quantidade_b.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpData_Execucao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtbpMovimento.SuspendLayout()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl4.SuspendLayout()
        CType(Me.tbEst2_Atual_m.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelControl5.SuspendLayout()
        CType(Me.tbEst1_Atual_m.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbQuantidade_m.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cor
        '
        Me.cor.Caption = "cor"
        Me.cor.ColumnEdit = Me.RepositoryItemColorPickEdit1
        Me.cor.FieldName = "Cor"
        Me.cor.Name = "cor"
        Me.cor.Visible = True
        Me.cor.VisibleIndex = 4
        Me.cor.Width = 70
        '
        'RepositoryItemColorPickEdit1
        '
        Me.RepositoryItemColorPickEdit1.AutoHeight = False
        Me.RepositoryItemColorPickEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemColorPickEdit1.Name = "RepositoryItemColorPickEdit1"
        '
        'dgRegistros
        '
        Me.dgRegistros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRegistros.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        GridLevelNode1.RelationName = "Level1"
        Me.dgRegistros.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.dgRegistros.Location = New System.Drawing.Point(-3, 36)
        Me.dgRegistros.MainView = Me.gvRegistros
        Me.dgRegistros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgRegistros.Name = "dgRegistros"
        Me.dgRegistros.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemColorPickEdit1})
        Me.dgRegistros.Size = New System.Drawing.Size(470, 706)
        Me.dgRegistros.TabIndex = 52
        Me.dgRegistros.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvRegistros})
        '
        'gvRegistros
        '
        Me.gvRegistros.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.codigo, Me.nome, Me.estoque_1, Me.minimo, Me.cor})
        Me.gvRegistros.DetailHeight = 100
        Me.gvRegistros.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.Column = Me.cor
        GridFormatRule1.Name = "Format0"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.gvRegistros.FormatRules.Add(GridFormatRule1)
        Me.gvRegistros.GridControl = Me.dgRegistros
        Me.gvRegistros.Name = "gvRegistros"
        Me.gvRegistros.OptionsBehavior.Editable = False
        Me.gvRegistros.OptionsBehavior.SmartVertScrollBar = False
        Me.gvRegistros.OptionsCustomization.AllowColumnMoving = False
        Me.gvRegistros.OptionsCustomization.AllowColumnResizing = False
        Me.gvRegistros.OptionsCustomization.AllowFilter = False
        Me.gvRegistros.OptionsCustomization.AllowGroup = False
        Me.gvRegistros.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvRegistros.OptionsCustomization.AllowSort = False
        Me.gvRegistros.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.[Nothing]
        Me.gvRegistros.OptionsFilter.AllowColumnMRUFilterList = False
        Me.gvRegistros.OptionsFilter.AllowFilterEditor = False
        Me.gvRegistros.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.gvRegistros.OptionsFilter.AllowMRUFilterList = False
        Me.gvRegistros.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = False
        Me.gvRegistros.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = False
        Me.gvRegistros.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvRegistros.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.gvRegistros.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gvRegistros.OptionsView.AllowHtmlDrawGroups = False
        Me.gvRegistros.OptionsView.ShowFooter = True
        Me.gvRegistros.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.gvRegistros.OptionsView.ShowGroupPanel = False
        '
        'codigo
        '
        Me.codigo.Caption = "código"
        Me.codigo.FieldName = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.Visible = True
        Me.codigo.VisibleIndex = 0
        Me.codigo.Width = 49
        '
        'nome
        '
        Me.nome.Caption = "nome"
        Me.nome.FieldName = "Nome"
        Me.nome.Name = "nome"
        Me.nome.Visible = True
        Me.nome.VisibleIndex = 1
        Me.nome.Width = 174
        '
        'estoque_1
        '
        Me.estoque_1.Caption = "estoque"
        Me.estoque_1.FieldName = "Estoque_1"
        Me.estoque_1.Name = "estoque_1"
        Me.estoque_1.Visible = True
        Me.estoque_1.VisibleIndex = 2
        Me.estoque_1.Width = 74
        '
        'minimo
        '
        Me.minimo.Caption = "mínimo"
        Me.minimo.FieldName = "Minimo"
        Me.minimo.Name = "minimo"
        Me.minimo.Visible = True
        Me.minimo.VisibleIndex = 3
        Me.minimo.Width = 55
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Cliente_Id"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Nome"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Contato_Funcao"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Contato_Nome"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Cgc_Cpf"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Incr_Estadual"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "Endereco"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "Cidade"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "Estado"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "CEP"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "email"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "Obs"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide
        Me.btnFiltrar.Location = New System.Drawing.Point(346, 6)
        Me.btnFiltrar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(45, 30)
        Me.btnFiltrar.TabIndex = 61
        Me.btnFiltrar.Text = "Filtrar"
        '
        'txtPreco_Base
        '
        Me.txtPreco_Base.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPreco_Base.Location = New System.Drawing.Point(1155, 134)
        Me.txtPreco_Base.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPreco_Base.Mask = "#,##"
        Me.txtPreco_Base.Name = "txtPreco_Base"
        Me.txtPreco_Base.Size = New System.Drawing.Size(52, 23)
        Me.txtPreco_Base.TabIndex = 13
        Me.txtPreco_Base.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl8.Location = New System.Drawing.Point(1029, 130)
        Me.LabelControl8.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(120, 28)
        Me.LabelControl8.TabIndex = 119
        Me.LabelControl8.Text = "Preço Base:"
        '
        'scc1
        '
        Me.scc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.scc1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1
        Me.scc1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scc1.Location = New System.Drawing.Point(0, 0)
        Me.scc1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.scc1.Name = "scc1"
        Me.scc1.Panel1.Controls.Add(Me.pnlPesquisa)
        Me.scc1.Panel1.Controls.Add(Me.dgRegistros)
        Me.scc1.Panel1.Text = "Esquerdo"
        Me.scc1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.scc1.Panel2.Controls.Add(Me.pnlDados)
        Me.scc1.Size = New System.Drawing.Size(1188, 750)
        Me.scc1.SplitterPosition = 400
        Me.scc1.TabIndex = 58
        Me.scc1.Text = "scc1"
        '
        'pnlPesquisa
        '
        Me.pnlPesquisa.Controls.Add(Me.btnFiltrar)
        Me.pnlPesquisa.Controls.Add(Me.btnX)
        Me.pnlPesquisa.Controls.Add(Me.txtFiltrar)
        Me.pnlPesquisa.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPesquisa.Location = New System.Drawing.Point(0, 0)
        Me.pnlPesquisa.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlPesquisa.Name = "pnlPesquisa"
        Me.pnlPesquisa.Size = New System.Drawing.Size(400, 41)
        Me.pnlPesquisa.TabIndex = 120
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide
        Me.btnX.Image = CType(resources.GetObject("btnX.Image"), System.Drawing.Image)
        Me.btnX.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnX.Location = New System.Drawing.Point(321, 6)
        Me.btnX.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(24, 28)
        Me.btnX.TabIndex = 57
        Me.btnX.ToolTip = "Limpar Filtro"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Location = New System.Drawing.Point(2, 9)
        Me.txtFiltrar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtFiltrar.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.txtFiltrar.Size = New System.Drawing.Size(343, 22)
        Me.txtFiltrar.TabIndex = 1
        '
        'pnlDados
        '
        Me.pnlDados.Controls.Add(Me.deDataInicial)
        Me.pnlDados.Controls.Add(Me.labelControl2)
        Me.pnlDados.Controls.Add(Me.imb_c)
        Me.pnlDados.Controls.Add(Me.dgLog)
        Me.pnlDados.Controls.Add(Me.chartLinhaHistorico)
        Me.pnlDados.Controls.Add(Me.tabEntraSaida)
        Me.pnlDados.Controls.Add(Me.txtPreco_Base)
        Me.pnlDados.Controls.Add(Me.LabelControl8)
        Me.pnlDados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDados.Location = New System.Drawing.Point(0, 0)
        Me.pnlDados.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlDados.Name = "pnlDados"
        Me.pnlDados.Size = New System.Drawing.Size(774, 742)
        Me.pnlDados.TabIndex = 120
        '
        'deDataInicial
        '
        Me.deDataInicial.EditValue = Nothing
        Me.deDataInicial.Location = New System.Drawing.Point(28, 474)
        Me.deDataInicial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deDataInicial.Name = "deDataInicial"
        Me.deDataInicial.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deDataInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDataInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDataInicial.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.deDataInicial.Properties.DisplayFormat.FormatString = "MM-yyyy"
        Me.deDataInicial.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.deDataInicial.Properties.EditFormat.FormatString = "MM-yyyy"
        Me.deDataInicial.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.deDataInicial.Properties.Mask.EditMask = "MM-yyyy"
        Me.deDataInicial.Properties.ShowMonthHeaders = False
        Me.deDataInicial.Properties.ShowToday = False
        Me.deDataInicial.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        Me.deDataInicial.Properties.VistaCalendarViewStyle = CType((DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView Or DevExpress.XtraEditors.VistaCalendarViewStyle.YearView), DevExpress.XtraEditors.VistaCalendarViewStyle)
        Me.deDataInicial.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.deDataInicial.Size = New System.Drawing.Size(90, 22)
        Me.deDataInicial.TabIndex = 174
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(43, 438)
        Me.labelControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(66, 16)
        Me.labelControl2.TabIndex = 173
        Me.labelControl2.Text = "A partir de:"
        '
        'imb_c
        '
        Me.imb_c.Dock = System.Windows.Forms.DockStyle.Left
        Me.imb_c.Location = New System.Drawing.Point(2, 2)
        Me.imb_c.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.imb_c.Name = "imb_c"
        Me.imb_c.Size = New System.Drawing.Size(20, 738)
        Me.imb_c.TabIndex = 172
        '
        'dgLog
        '
        Me.dgLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLog.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.dgLog.Location = New System.Drawing.Point(586, 4)
        Me.dgLog.MainView = Me.gvLog
        Me.dgLog.Margin = New System.Windows.Forms.Padding(2)
        Me.dgLog.Name = "dgLog"
        Me.dgLog.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemColorEdit2})
        Me.dgLog.Size = New System.Drawing.Size(181, 396)
        Me.dgLog.TabIndex = 171
        Me.dgLog.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvLog})
        '
        'gvLog
        '
        Me.gvLog.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvLog.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.gvLog.Appearance.EvenRow.Options.UseFont = True
        Me.gvLog.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvLog.Appearance.FocusedRow.Options.UseFont = True
        Me.gvLog.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvLog.Appearance.GroupFooter.Options.UseFont = True
        Me.gvLog.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvLog.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvLog.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.gvLog.Appearance.OddRow.Options.UseFont = True
        Me.gvLog.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvLog.Appearance.Row.Options.UseFont = True
        Me.gvLog.Appearance.Row.Options.UseTextOptions = True
        Me.gvLog.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gvLog.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.mes, Me.compra, Me.uso})
        Me.gvLog.FixedLineWidth = 1
        Me.gvLog.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gvLog.FooterPanelHeight = 10
        GridFormatRule2.Name = "Format0"
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Expression = "Sim"
        FormatConditionRuleValue2.PredefinedName = "Red Fill, Red Text"
        FormatConditionRuleValue2.Value1 = "Sim"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.gvLog.FormatRules.Add(GridFormatRule2)
        Me.gvLog.GridControl = Me.dgLog
        Me.gvLog.GroupFormat = "{0}: [#imagem]{1} {2}"
        Me.gvLog.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.gvLog.Name = "gvLog"
        Me.gvLog.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvLog.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvLog.OptionsBehavior.AllowIncrementalSearch = True
        Me.gvLog.OptionsBehavior.AutoPopulateColumns = False
        Me.gvLog.OptionsBehavior.AutoSelectAllInEditor = False
        Me.gvLog.OptionsBehavior.Editable = False
        Me.gvLog.OptionsBehavior.ReadOnly = True
        Me.gvLog.OptionsCustomization.AllowColumnMoving = False
        Me.gvLog.OptionsCustomization.AllowColumnResizing = False
        Me.gvLog.OptionsCustomization.AllowFilter = False
        Me.gvLog.OptionsCustomization.AllowGroup = False
        Me.gvLog.OptionsDetail.SmartDetailHeight = True
        Me.gvLog.OptionsMenu.EnableColumnMenu = False
        Me.gvLog.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvLog.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.gvLog.OptionsSelection.MultiSelect = True
        Me.gvLog.OptionsSelection.UseIndicatorForSelection = False
        Me.gvLog.OptionsView.ColumnAutoWidth = False
        Me.gvLog.OptionsView.ShowFooter = True
        Me.gvLog.OptionsView.ShowGroupPanel = False
        Me.gvLog.RowHeight = 23
        '
        'mes
        '
        Me.mes.Caption = "mês"
        Me.mes.FieldName = "mes"
        Me.mes.Name = "mes"
        Me.mes.Visible = True
        Me.mes.VisibleIndex = 0
        Me.mes.Width = 69
        '
        'compra
        '
        Me.compra.Caption = "compra"
        Me.compra.FieldName = "compra"
        Me.compra.Name = "compra"
        Me.compra.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "compra", "{0:0.##}")})
        Me.compra.Visible = True
        Me.compra.VisibleIndex = 1
        Me.compra.Width = 61
        '
        'uso
        '
        Me.uso.Caption = "uso"
        Me.uso.FieldName = "uso"
        Me.uso.Name = "uso"
        Me.uso.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "uso", "{0:0.##}")})
        Me.uso.Visible = True
        Me.uso.VisibleIndex = 2
        Me.uso.Width = 64
        '
        'repositoryItemColorEdit2
        '
        Me.repositoryItemColorEdit2.AutoHeight = False
        Me.repositoryItemColorEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repositoryItemColorEdit2.ColorText = DevExpress.XtraEditors.Controls.ColorText.[Integer]
        Me.repositoryItemColorEdit2.Name = "repositoryItemColorEdit2"
        '
        'chartLinhaHistorico
        '
        Me.chartLinhaHistorico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.chartLinhaHistorico.Diagram = XyDiagram1
        Me.chartLinhaHistorico.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.LeftOutside
        Me.chartLinhaHistorico.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Bottom
        Me.chartLinhaHistorico.Legend.Name = "Default Legend"
        Me.chartLinhaHistorico.Location = New System.Drawing.Point(22, 409)
        Me.chartLinhaHistorico.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chartLinhaHistorico.Name = "chartLinhaHistorico"
        Series1.Name = "compra"
        Series2.Name = "uso"
        Me.chartLinhaHistorico.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
        Me.chartLinhaHistorico.Size = New System.Drawing.Size(743, 325)
        Me.chartLinhaHistorico.TabIndex = 170
        '
        'tabEntraSaida
        '
        Me.tabEntraSaida.Location = New System.Drawing.Point(21, 6)
        Me.tabEntraSaida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabEntraSaida.Name = "tabEntraSaida"
        Me.tabEntraSaida.SelectedTabPage = Me.xtbpCadastro
        Me.tabEntraSaida.Size = New System.Drawing.Size(560, 405)
        Me.tabEntraSaida.TabIndex = 168
        Me.tabEntraSaida.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtbpCadastro, Me.xtbpEntrada, Me.xtbpBaixa, Me.xtbpMovimento})
        '
        'xtbpCadastro
        '
        Me.xtbpCadastro.Controls.Add(Me.txtEstoque_2)
        Me.xtbpCadastro.Controls.Add(Me.ceCor)
        Me.xtbpCadastro.Controls.Add(Me.txtEstoque_1)
        Me.xtbpCadastro.Controls.Add(Me.txtCodigo_c)
        Me.xtbpCadastro.Controls.Add(Me.txtMinimo)
        Me.xtbpCadastro.Controls.Add(Me.label2)
        Me.xtbpCadastro.Controls.Add(Me.Label4)
        Me.xtbpCadastro.Controls.Add(Me.txtNome)
        Me.xtbpCadastro.Controls.Add(Me.PedidoLabel)
        Me.xtbpCadastro.Controls.Add(Me.LinhaIdLabel)
        Me.xtbpCadastro.Controls.Add(Me.EstoqueQuantidadeLabel)
        Me.xtbpCadastro.Controls.Add(Me.MaterialNomeLabel)
        Me.xtbpCadastro.Controls.Add(Me.EstoqueMinimoLabel)
        Me.xtbpCadastro.Controls.Add(Me.txtMaterial_Fabricante)
        Me.xtbpCadastro.Controls.Add(Me.txtPedido)
        Me.xtbpCadastro.Controls.Add(Me.MaterialFabricanteLabel)
        Me.xtbpCadastro.Controls.Add(Me.txtMaterial_Nome)
        Me.xtbpCadastro.Controls.Add(Me.MaterialTipoLabel)
        Me.xtbpCadastro.Controls.Add(Me.txtMaterial_Tipo)
        Me.xtbpCadastro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.xtbpCadastro.Name = "xtbpCadastro"
        Me.xtbpCadastro.Size = New System.Drawing.Size(553, 371)
        Me.xtbpCadastro.Text = "Cadastro"
        '
        'txtEstoque_2
        '
        Me.txtEstoque_2.Location = New System.Drawing.Point(360, 251)
        Me.txtEstoque_2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEstoque_2.Name = "txtEstoque_2"
        Me.txtEstoque_2.Size = New System.Drawing.Size(74, 23)
        Me.txtEstoque_2.TabIndex = 20
        Me.txtEstoque_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ceCor
        '
        Me.ceCor.EditValue = System.Drawing.Color.Empty
        Me.ceCor.Location = New System.Drawing.Point(308, 16)
        Me.ceCor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ceCor.Name = "ceCor"
        Me.ceCor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ceCor.Size = New System.Drawing.Size(140, 22)
        Me.ceCor.TabIndex = 41
        '
        'txtEstoque_1
        '
        Me.txtEstoque_1.Location = New System.Drawing.Point(113, 245)
        Me.txtEstoque_1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEstoque_1.Name = "txtEstoque_1"
        Me.txtEstoque_1.Size = New System.Drawing.Size(74, 23)
        Me.txtEstoque_1.TabIndex = 14
        Me.txtEstoque_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodigo_c
        '
        Me.txtCodigo_c.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo_c.Location = New System.Drawing.Point(110, 20)
        Me.txtCodigo_c.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodigo_c.Name = "txtCodigo_c"
        Me.txtCodigo_c.Size = New System.Drawing.Size(81, 36)
        Me.txtCodigo_c.TabIndex = 24
        '
        'txtMinimo
        '
        Me.txtMinimo.Location = New System.Drawing.Point(113, 294)
        Me.txtMinimo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Size = New System.Drawing.Size(74, 23)
        Me.txtMinimo.TabIndex = 16
        Me.txtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.label2.Location = New System.Drawing.Point(73, 81)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 17)
        Me.label2.TabIndex = 25
        Me.label2.Text = "Cor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(289, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Estoque 2"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(110, 78)
        Me.txtNome.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(338, 23)
        Me.txtNome.TabIndex = 26
        '
        'PedidoLabel
        '
        Me.PedidoLabel.AutoSize = True
        Me.PedidoLabel.BackColor = System.Drawing.Color.Transparent
        Me.PedidoLabel.Location = New System.Drawing.Point(304, 298)
        Me.PedidoLabel.Name = "PedidoLabel"
        Me.PedidoLabel.Size = New System.Drawing.Size(54, 17)
        Me.PedidoLabel.TabIndex = 17
        Me.PedidoLabel.Text = "pedido:"
        '
        'LinhaIdLabel
        '
        Me.LinhaIdLabel.AutoSize = True
        Me.LinhaIdLabel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.LinhaIdLabel.Location = New System.Drawing.Point(51, 36)
        Me.LinhaIdLabel.Name = "LinhaIdLabel"
        Me.LinhaIdLabel.Size = New System.Drawing.Size(56, 17)
        Me.LinhaIdLabel.TabIndex = 23
        Me.LinhaIdLabel.Text = "Código:"
        Me.LinhaIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EstoqueQuantidadeLabel
        '
        Me.EstoqueQuantidadeLabel.AutoSize = True
        Me.EstoqueQuantidadeLabel.BackColor = System.Drawing.Color.Transparent
        Me.EstoqueQuantidadeLabel.Location = New System.Drawing.Point(42, 250)
        Me.EstoqueQuantidadeLabel.Name = "EstoqueQuantidadeLabel"
        Me.EstoqueQuantidadeLabel.Size = New System.Drawing.Size(70, 17)
        Me.EstoqueQuantidadeLabel.TabIndex = 13
        Me.EstoqueQuantidadeLabel.Text = "Estoque 1"
        '
        'MaterialNomeLabel
        '
        Me.MaterialNomeLabel.AutoSize = True
        Me.MaterialNomeLabel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.MaterialNomeLabel.Location = New System.Drawing.Point(51, 137)
        Me.MaterialNomeLabel.Name = "MaterialNomeLabel"
        Me.MaterialNomeLabel.Size = New System.Drawing.Size(58, 17)
        Me.MaterialNomeLabel.TabIndex = 28
        Me.MaterialNomeLabel.Text = "Material:"
        '
        'EstoqueMinimoLabel
        '
        Me.EstoqueMinimoLabel.AutoSize = True
        Me.EstoqueMinimoLabel.BackColor = System.Drawing.Color.Transparent
        Me.EstoqueMinimoLabel.Location = New System.Drawing.Point(54, 298)
        Me.EstoqueMinimoLabel.Name = "EstoqueMinimoLabel"
        Me.EstoqueMinimoLabel.Size = New System.Drawing.Size(55, 17)
        Me.EstoqueMinimoLabel.TabIndex = 15
        Me.EstoqueMinimoLabel.Text = "Mínimo:"
        '
        'txtMaterial_Fabricante
        '
        Me.txtMaterial_Fabricante.Location = New System.Drawing.Point(113, 165)
        Me.txtMaterial_Fabricante.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMaterial_Fabricante.Name = "txtMaterial_Fabricante"
        Me.txtMaterial_Fabricante.Size = New System.Drawing.Size(334, 23)
        Me.txtMaterial_Fabricante.TabIndex = 31
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(360, 294)
        Me.txtPedido.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(73, 23)
        Me.txtPedido.TabIndex = 18
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MaterialFabricanteLabel
        '
        Me.MaterialFabricanteLabel.AutoSize = True
        Me.MaterialFabricanteLabel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.MaterialFabricanteLabel.Location = New System.Drawing.Point(37, 169)
        Me.MaterialFabricanteLabel.Name = "MaterialFabricanteLabel"
        Me.MaterialFabricanteLabel.Size = New System.Drawing.Size(76, 17)
        Me.MaterialFabricanteLabel.TabIndex = 30
        Me.MaterialFabricanteLabel.Text = "Fabricante:"
        '
        'txtMaterial_Nome
        '
        Me.txtMaterial_Nome.Location = New System.Drawing.Point(113, 133)
        Me.txtMaterial_Nome.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMaterial_Nome.Name = "txtMaterial_Nome"
        Me.txtMaterial_Nome.Size = New System.Drawing.Size(334, 23)
        Me.txtMaterial_Nome.TabIndex = 29
        '
        'MaterialTipoLabel
        '
        Me.MaterialTipoLabel.AutoSize = True
        Me.MaterialTipoLabel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.MaterialTipoLabel.Location = New System.Drawing.Point(70, 201)
        Me.MaterialTipoLabel.Name = "MaterialTipoLabel"
        Me.MaterialTipoLabel.Size = New System.Drawing.Size(39, 17)
        Me.MaterialTipoLabel.TabIndex = 32
        Me.MaterialTipoLabel.Text = "Tipo:"
        '
        'txtMaterial_Tipo
        '
        Me.txtMaterial_Tipo.Location = New System.Drawing.Point(113, 197)
        Me.txtMaterial_Tipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMaterial_Tipo.Name = "txtMaterial_Tipo"
        Me.txtMaterial_Tipo.Size = New System.Drawing.Size(334, 23)
        Me.txtMaterial_Tipo.TabIndex = 33
        '
        'xtbpEntrada
        '
        Me.xtbpEntrada.Controls.Add(Me.labelControl4)
        Me.xtbpEntrada.Controls.Add(Me.panelControl1)
        Me.xtbpEntrada.Controls.Add(Me.labelControl3)
        Me.xtbpEntrada.Controls.Add(Me.pnlEst1_e)
        Me.xtbpEntrada.Controls.Add(Me.tbNomeCor_e)
        Me.xtbpEntrada.Controls.Add(Me.txtCodigo_e)
        Me.xtbpEntrada.Controls.Add(Me.Label16)
        Me.xtbpEntrada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.xtbpEntrada.Name = "xtbpEntrada"
        Me.xtbpEntrada.PageVisible = False
        Me.xtbpEntrada.Size = New System.Drawing.Size(553, 371)
        Me.xtbpEntrada.Text = "Entrada"
        '
        'labelControl4
        '
        Me.labelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.labelControl4.Location = New System.Drawing.Point(248, 62)
        Me.labelControl4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl4.Name = "labelControl4"
        Me.labelControl4.Size = New System.Drawing.Size(81, 23)
        Me.labelControl4.TabIndex = 127
        Me.labelControl4.Text = " Estoque 2"
        '
        'panelControl1
        '
        Me.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelControl1.Controls.Add(Me.tbEst2_Quantidade_e)
        Me.panelControl1.Controls.Add(Me.tbEst2_Final_e)
        Me.panelControl1.Controls.Add(Me.tbEst2_Atual_e)
        Me.panelControl1.Controls.Add(Me.btnEst2_e)
        Me.panelControl1.Controls.Add(Me.Label11)
        Me.panelControl1.Controls.Add(Me.Label15)
        Me.panelControl1.Controls.Add(Me.Label14)
        Me.panelControl1.Controls.Add(Me.Label12)
        Me.panelControl1.Controls.Add(Me.Label13)
        Me.panelControl1.Location = New System.Drawing.Point(248, 81)
        Me.panelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelControl1.Name = "panelControl1"
        Me.panelControl1.Size = New System.Drawing.Size(210, 246)
        Me.panelControl1.TabIndex = 128
        '
        'tbEst2_Quantidade_e
        '
        Me.tbEst2_Quantidade_e.EditValue = "0"
        Me.tbEst2_Quantidade_e.Location = New System.Drawing.Point(107, 76)
        Me.tbEst2_Quantidade_e.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Quantidade_e.Name = "tbEst2_Quantidade_e"
        Me.tbEst2_Quantidade_e.Properties.Mask.EditMask = "d"
        Me.tbEst2_Quantidade_e.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Quantidade_e.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Quantidade_e.Size = New System.Drawing.Size(73, 22)
        Me.tbEst2_Quantidade_e.TabIndex = 138
        '
        'tbEst2_Final_e
        '
        Me.tbEst2_Final_e.EditValue = "0"
        Me.tbEst2_Final_e.Location = New System.Drawing.Point(105, 135)
        Me.tbEst2_Final_e.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Final_e.Name = "tbEst2_Final_e"
        Me.tbEst2_Final_e.Properties.Mask.EditMask = "d"
        Me.tbEst2_Final_e.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Final_e.Properties.ReadOnly = True
        Me.tbEst2_Final_e.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Final_e.Size = New System.Drawing.Size(77, 22)
        Me.tbEst2_Final_e.TabIndex = 137
        '
        'tbEst2_Atual_e
        '
        Me.tbEst2_Atual_e.EditValue = "0"
        Me.tbEst2_Atual_e.Location = New System.Drawing.Point(105, 12)
        Me.tbEst2_Atual_e.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Atual_e.Name = "tbEst2_Atual_e"
        Me.tbEst2_Atual_e.Properties.Mask.EditMask = "d"
        Me.tbEst2_Atual_e.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Atual_e.Properties.ReadOnly = True
        Me.tbEst2_Atual_e.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Atual_e.Size = New System.Drawing.Size(77, 22)
        Me.tbEst2_Atual_e.TabIndex = 137
        '
        'btnEst2_e
        '
        Me.btnEst2_e.Location = New System.Drawing.Point(9, 178)
        Me.btnEst2_e.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEst2_e.Name = "btnEst2_e"
        Me.btnEst2_e.Size = New System.Drawing.Size(191, 41)
        Me.btnEst2_e.TabIndex = 24
        Me.btnEst2_e.Text = "&Gravar Entrada"
        Me.btnEst2_e.ToolTipTitle = "Gravar"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(17, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 17)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Estoque Final"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(143, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 29)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "="
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(143, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 29)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "+"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(17, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 17)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Quantidade"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(5, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 17)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Estoque Atual"
        '
        'labelControl3
        '
        Me.labelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.labelControl3.Location = New System.Drawing.Point(31, 62)
        Me.labelControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl3.Name = "labelControl3"
        Me.labelControl3.Size = New System.Drawing.Size(81, 23)
        Me.labelControl3.TabIndex = 25
        Me.labelControl3.Text = " Estoque 1"
        '
        'pnlEst1_e
        '
        Me.pnlEst1_e.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlEst1_e.Controls.Add(Me.tbEst1_Final_e)
        Me.pnlEst1_e.Controls.Add(Me.tbEst1_Atual_e)
        Me.pnlEst1_e.Controls.Add(Me.tbEst1_Quantidade_e)
        Me.pnlEst1_e.Controls.Add(Me.btnEst1_e)
        Me.pnlEst1_e.Controls.Add(Me.label30)
        Me.pnlEst1_e.Controls.Add(Me.Label8)
        Me.pnlEst1_e.Controls.Add(Me.label10)
        Me.pnlEst1_e.Controls.Add(Me.label9)
        Me.pnlEst1_e.Controls.Add(Me.Label7)
        Me.pnlEst1_e.Location = New System.Drawing.Point(31, 81)
        Me.pnlEst1_e.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlEst1_e.Name = "pnlEst1_e"
        Me.pnlEst1_e.Size = New System.Drawing.Size(210, 246)
        Me.pnlEst1_e.TabIndex = 126
        '
        'tbEst1_Final_e
        '
        Me.tbEst1_Final_e.EditValue = "0"
        Me.tbEst1_Final_e.Location = New System.Drawing.Point(112, 137)
        Me.tbEst1_Final_e.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Final_e.Name = "tbEst1_Final_e"
        Me.tbEst1_Final_e.Properties.Mask.EditMask = "d"
        Me.tbEst1_Final_e.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Final_e.Properties.ReadOnly = True
        Me.tbEst1_Final_e.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Final_e.Size = New System.Drawing.Size(77, 22)
        Me.tbEst1_Final_e.TabIndex = 137
        '
        'tbEst1_Atual_e
        '
        Me.tbEst1_Atual_e.EditValue = "0"
        Me.tbEst1_Atual_e.Location = New System.Drawing.Point(112, 12)
        Me.tbEst1_Atual_e.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Atual_e.Name = "tbEst1_Atual_e"
        Me.tbEst1_Atual_e.Properties.Mask.EditMask = "d"
        Me.tbEst1_Atual_e.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Atual_e.Properties.ReadOnly = True
        Me.tbEst1_Atual_e.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Atual_e.Size = New System.Drawing.Size(77, 22)
        Me.tbEst1_Atual_e.TabIndex = 137
        '
        'tbEst1_Quantidade_e
        '
        Me.tbEst1_Quantidade_e.EditValue = "0"
        Me.tbEst1_Quantidade_e.Location = New System.Drawing.Point(114, 75)
        Me.tbEst1_Quantidade_e.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Quantidade_e.Name = "tbEst1_Quantidade_e"
        Me.tbEst1_Quantidade_e.Properties.Mask.EditMask = "d"
        Me.tbEst1_Quantidade_e.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Quantidade_e.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Quantidade_e.Size = New System.Drawing.Size(77, 22)
        Me.tbEst1_Quantidade_e.TabIndex = 137
        '
        'btnEst1_e
        '
        Me.btnEst1_e.Location = New System.Drawing.Point(9, 178)
        Me.btnEst1_e.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEst1_e.Name = "btnEst1_e"
        Me.btnEst1_e.Size = New System.Drawing.Size(191, 41)
        Me.btnEst1_e.TabIndex = 24
        Me.btnEst1_e.Text = "&Gravar Entrada"
        Me.btnEst1_e.ToolTipTitle = "Gravar"
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.BackColor = System.Drawing.Color.Transparent
        Me.label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label30.Location = New System.Drawing.Point(163, 103)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(28, 29)
        Me.label30.TabIndex = 23
        Me.label30.Text = "="
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(6, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Estoque Final"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.BackColor = System.Drawing.Color.Transparent
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(163, 42)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(28, 29)
        Me.label10.TabIndex = 21
        Me.label10.Text = "+"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.BackColor = System.Drawing.Color.Transparent
        Me.label9.Location = New System.Drawing.Point(10, 15)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(92, 17)
        Me.label9.TabIndex = 15
        Me.label9.Text = "Estoque Atual"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(30, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Quantidade"
        '
        'tbNomeCor_e
        '
        Me.tbNomeCor_e.Location = New System.Drawing.Point(175, 14)
        Me.tbNomeCor_e.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbNomeCor_e.Name = "tbNomeCor_e"
        Me.tbNomeCor_e.ReadOnly = True
        Me.tbNomeCor_e.Size = New System.Drawing.Size(308, 23)
        Me.tbNomeCor_e.TabIndex = 27
        '
        'txtCodigo_e
        '
        Me.txtCodigo_e.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo_e.Location = New System.Drawing.Point(71, 5)
        Me.txtCodigo_e.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodigo_e.Name = "txtCodigo_e"
        Me.txtCodigo_e.Size = New System.Drawing.Size(86, 35)
        Me.txtCodigo_e.TabIndex = 19
        Me.txtCodigo_e.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(13, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 17)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "Código:"
        '
        'xtbpBaixa
        '
        Me.xtbpBaixa.Controls.Add(Me.labelControl5)
        Me.xtbpBaixa.Controls.Add(Me.panelControl2)
        Me.xtbpBaixa.Controls.Add(Me.labelControl6)
        Me.xtbpBaixa.Controls.Add(Me.panelControl3)
        Me.xtbpBaixa.Controls.Add(Me.tbNomeCor_b)
        Me.xtbpBaixa.Controls.Add(Me.txtCodigo_b)
        Me.xtbpBaixa.Controls.Add(Me.label23)
        Me.xtbpBaixa.Controls.Add(Me.label46)
        Me.xtbpBaixa.Controls.Add(Me.dtpData_Execucao)
        Me.xtbpBaixa.Controls.Add(Me.btnExecutarItem)
        Me.xtbpBaixa.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.xtbpBaixa.Name = "xtbpBaixa"
        Me.xtbpBaixa.PageVisible = False
        Me.xtbpBaixa.Size = New System.Drawing.Size(553, 371)
        Me.xtbpBaixa.Text = "Baixa"
        '
        'labelControl5
        '
        Me.labelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.labelControl5.Location = New System.Drawing.Point(246, 64)
        Me.labelControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl5.Name = "labelControl5"
        Me.labelControl5.Size = New System.Drawing.Size(81, 23)
        Me.labelControl5.TabIndex = 134
        Me.labelControl5.Text = " Estoque 2"
        '
        'panelControl2
        '
        Me.panelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelControl2.Controls.Add(Me.tbEst2_Quantidade_b)
        Me.panelControl2.Controls.Add(Me.tbEst2_Final_b)
        Me.panelControl2.Controls.Add(Me.tbEst2_Atual_b)
        Me.panelControl2.Controls.Add(Me.btnEst2_b)
        Me.panelControl2.Controls.Add(Me.label1)
        Me.panelControl2.Controls.Add(Me.label3)
        Me.panelControl2.Controls.Add(Me.label5)
        Me.panelControl2.Controls.Add(Me.label6)
        Me.panelControl2.Controls.Add(Me.label17)
        Me.panelControl2.Location = New System.Drawing.Point(246, 84)
        Me.panelControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelControl2.Name = "panelControl2"
        Me.panelControl2.Size = New System.Drawing.Size(210, 246)
        Me.panelControl2.TabIndex = 135
        '
        'tbEst2_Quantidade_b
        '
        Me.tbEst2_Quantidade_b.EditValue = "0"
        Me.tbEst2_Quantidade_b.Location = New System.Drawing.Point(104, 78)
        Me.tbEst2_Quantidade_b.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Quantidade_b.Name = "tbEst2_Quantidade_b"
        Me.tbEst2_Quantidade_b.Properties.Mask.EditMask = "d"
        Me.tbEst2_Quantidade_b.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Quantidade_b.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Quantidade_b.Size = New System.Drawing.Size(77, 22)
        Me.tbEst2_Quantidade_b.TabIndex = 139
        '
        'tbEst2_Final_b
        '
        Me.tbEst2_Final_b.EditValue = "0"
        Me.tbEst2_Final_b.Location = New System.Drawing.Point(104, 135)
        Me.tbEst2_Final_b.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Final_b.Name = "tbEst2_Final_b"
        Me.tbEst2_Final_b.Properties.Mask.EditMask = "d"
        Me.tbEst2_Final_b.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Final_b.Properties.ReadOnly = True
        Me.tbEst2_Final_b.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Final_b.Size = New System.Drawing.Size(77, 22)
        Me.tbEst2_Final_b.TabIndex = 139
        '
        'tbEst2_Atual_b
        '
        Me.tbEst2_Atual_b.EditValue = "0"
        Me.tbEst2_Atual_b.Location = New System.Drawing.Point(104, 11)
        Me.tbEst2_Atual_b.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Atual_b.Name = "tbEst2_Atual_b"
        Me.tbEst2_Atual_b.Properties.Mask.EditMask = "d"
        Me.tbEst2_Atual_b.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Atual_b.Properties.ReadOnly = True
        Me.tbEst2_Atual_b.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Atual_b.Size = New System.Drawing.Size(77, 22)
        Me.tbEst2_Atual_b.TabIndex = 139
        '
        'btnEst2_b
        '
        Me.btnEst2_b.Location = New System.Drawing.Point(9, 178)
        Me.btnEst2_b.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEst2_b.Name = "btnEst2_b"
        Me.btnEst2_b.Size = New System.Drawing.Size(191, 41)
        Me.btnEst2_b.TabIndex = 24
        Me.btnEst2_b.Text = "&Gravar Entrada"
        Me.btnEst2_b.ToolTipTitle = "Gravar"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Location = New System.Drawing.Point(17, 139)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(88, 17)
        Me.label1.TabIndex = 19
        Me.label1.Text = "Estoque Final"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(143, 103)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(28, 29)
        Me.label3.TabIndex = 23
        Me.label3.Text = "="
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.Transparent
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(143, 42)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(22, 29)
        Me.label5.TabIndex = 21
        Me.label5.Text = "-"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Location = New System.Drawing.Point(17, 79)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(78, 17)
        Me.label6.TabIndex = 17
        Me.label6.Text = "Quantidade"
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.BackColor = System.Drawing.Color.Transparent
        Me.label17.Location = New System.Drawing.Point(5, 15)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(92, 17)
        Me.label17.TabIndex = 15
        Me.label17.Text = "Estoque Atual"
        '
        'labelControl6
        '
        Me.labelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.labelControl6.Location = New System.Drawing.Point(30, 64)
        Me.labelControl6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl6.Name = "labelControl6"
        Me.labelControl6.Size = New System.Drawing.Size(81, 23)
        Me.labelControl6.TabIndex = 131
        Me.labelControl6.Text = " Estoque 1"
        '
        'panelControl3
        '
        Me.panelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelControl3.Controls.Add(Me.tbEst1_Final_b)
        Me.panelControl3.Controls.Add(Me.tbEst1_Atual_b)
        Me.panelControl3.Controls.Add(Me.tbEst1_Quantidade_b)
        Me.panelControl3.Controls.Add(Me.btnEst1_b)
        Me.panelControl3.Controls.Add(Me.label18)
        Me.panelControl3.Controls.Add(Me.label19)
        Me.panelControl3.Controls.Add(Me.label20)
        Me.panelControl3.Controls.Add(Me.label21)
        Me.panelControl3.Controls.Add(Me.label22)
        Me.panelControl3.Location = New System.Drawing.Point(30, 84)
        Me.panelControl3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelControl3.Name = "panelControl3"
        Me.panelControl3.Size = New System.Drawing.Size(210, 246)
        Me.panelControl3.TabIndex = 133
        '
        'tbEst1_Final_b
        '
        Me.tbEst1_Final_b.EditValue = "0"
        Me.tbEst1_Final_b.Location = New System.Drawing.Point(111, 135)
        Me.tbEst1_Final_b.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Final_b.Name = "tbEst1_Final_b"
        Me.tbEst1_Final_b.Properties.Mask.EditMask = "d"
        Me.tbEst1_Final_b.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Final_b.Properties.ReadOnly = True
        Me.tbEst1_Final_b.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Final_b.Size = New System.Drawing.Size(77, 22)
        Me.tbEst1_Final_b.TabIndex = 139
        '
        'tbEst1_Atual_b
        '
        Me.tbEst1_Atual_b.EditValue = "0"
        Me.tbEst1_Atual_b.Location = New System.Drawing.Point(111, 11)
        Me.tbEst1_Atual_b.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Atual_b.Name = "tbEst1_Atual_b"
        Me.tbEst1_Atual_b.Properties.Mask.EditMask = "d"
        Me.tbEst1_Atual_b.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Atual_b.Properties.ReadOnly = True
        Me.tbEst1_Atual_b.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Atual_b.Size = New System.Drawing.Size(77, 22)
        Me.tbEst1_Atual_b.TabIndex = 139
        '
        'tbEst1_Quantidade_b
        '
        Me.tbEst1_Quantidade_b.EditValue = "0"
        Me.tbEst1_Quantidade_b.Location = New System.Drawing.Point(111, 76)
        Me.tbEst1_Quantidade_b.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Quantidade_b.Name = "tbEst1_Quantidade_b"
        Me.tbEst1_Quantidade_b.Properties.Mask.EditMask = "d"
        Me.tbEst1_Quantidade_b.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Quantidade_b.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Quantidade_b.Size = New System.Drawing.Size(77, 22)
        Me.tbEst1_Quantidade_b.TabIndex = 138
        '
        'btnEst1_b
        '
        Me.btnEst1_b.Location = New System.Drawing.Point(9, 178)
        Me.btnEst1_b.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEst1_b.Name = "btnEst1_b"
        Me.btnEst1_b.Size = New System.Drawing.Size(191, 41)
        Me.btnEst1_b.TabIndex = 24
        Me.btnEst1_b.Text = "&Gravar Entrada"
        Me.btnEst1_b.ToolTipTitle = "Gravar"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.BackColor = System.Drawing.Color.Transparent
        Me.label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.Location = New System.Drawing.Point(163, 103)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(28, 29)
        Me.label18.TabIndex = 23
        Me.label18.Text = "="
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.BackColor = System.Drawing.Color.Transparent
        Me.label19.Location = New System.Drawing.Point(6, 140)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(88, 17)
        Me.label19.TabIndex = 19
        Me.label19.Text = "Estoque Final"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.BackColor = System.Drawing.Color.Transparent
        Me.label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label20.Location = New System.Drawing.Point(163, 42)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(22, 29)
        Me.label20.TabIndex = 21
        Me.label20.Text = "-"
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.BackColor = System.Drawing.Color.Transparent
        Me.label21.Location = New System.Drawing.Point(10, 15)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(92, 17)
        Me.label21.TabIndex = 15
        Me.label21.Text = "Estoque Atual"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.BackColor = System.Drawing.Color.Transparent
        Me.label22.Location = New System.Drawing.Point(10, 79)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(78, 17)
        Me.label22.TabIndex = 17
        Me.label22.Text = "Quantidade"
        '
        'tbNomeCor_b
        '
        Me.tbNomeCor_b.Location = New System.Drawing.Point(181, 16)
        Me.tbNomeCor_b.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbNomeCor_b.Name = "tbNomeCor_b"
        Me.tbNomeCor_b.ReadOnly = True
        Me.tbNomeCor_b.Size = New System.Drawing.Size(317, 23)
        Me.tbNomeCor_b.TabIndex = 132
        '
        'txtCodigo_b
        '
        Me.txtCodigo_b.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo_b.Location = New System.Drawing.Point(71, 7)
        Me.txtCodigo_b.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodigo_b.Name = "txtCodigo_b"
        Me.txtCodigo_b.Size = New System.Drawing.Size(86, 35)
        Me.txtCodigo_b.TabIndex = 129
        Me.txtCodigo_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.BackColor = System.Drawing.Color.Transparent
        Me.label23.Location = New System.Drawing.Point(13, 20)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(56, 17)
        Me.label23.TabIndex = 130
        Me.label23.Text = "Código:"
        '
        'label46
        '
        Me.label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label46.BackColor = System.Drawing.Color.Transparent
        Me.label46.Location = New System.Drawing.Point(13366, 50)
        Me.label46.Name = "label46"
        Me.label46.Size = New System.Drawing.Size(92, 16)
        Me.label46.TabIndex = 89
        Me.label46.Text = "Execução:"
        Me.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpData_Execucao
        '
        Me.dtpData_Execucao.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.dtpData_Execucao.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpData_Execucao.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpData_Execucao.ButtonClear.Visible = True
        Me.dtpData_Execucao.ButtonDropDown.Visible = True
        Me.dtpData_Execucao.CustomFormat = "dd/MM/yyyy"
        Me.dtpData_Execucao.FocusHighlightEnabled = True
        Me.dtpData_Execucao.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpData_Execucao.IsPopupCalendarOpen = False
        Me.dtpData_Execucao.Location = New System.Drawing.Point(13468, 44)
        Me.dtpData_Execucao.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        '
        '
        '
        '
        '
        '
        Me.dtpData_Execucao.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpData_Execucao.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpData_Execucao.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpData_Execucao.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpData_Execucao.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dtpData_Execucao.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpData_Execucao.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpData_Execucao.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpData_Execucao.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpData_Execucao.MonthCalendar.TodayButtonVisible = True
        Me.dtpData_Execucao.Name = "dtpData_Execucao"
        Me.dtpData_Execucao.Size = New System.Drawing.Size(113, 23)
        Me.dtpData_Execucao.TabIndex = 90
        '
        'btnExecutarItem
        '
        Me.btnExecutarItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExecutarItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExecutarItem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExecutarItem.Location = New System.Drawing.Point(13597, 31)
        Me.btnExecutarItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExecutarItem.Name = "btnExecutarItem"
        Me.btnExecutarItem.Size = New System.Drawing.Size(107, 39)
        Me.btnExecutarItem.TabIndex = 100
        Me.btnExecutarItem.Text = "Executar o Ítem"
        '
        'xtbpMovimento
        '
        Me.xtbpMovimento.Controls.Add(Me.btnEst2_para_Est1)
        Me.xtbpMovimento.Controls.Add(Me.btnEst1_para_Est2)
        Me.xtbpMovimento.Controls.Add(Me.label34)
        Me.xtbpMovimento.Controls.Add(Me.panelControl4)
        Me.xtbpMovimento.Controls.Add(Me.panelControl5)
        Me.xtbpMovimento.Controls.Add(Me.tbNomeCor_m)
        Me.xtbpMovimento.Controls.Add(Me.txtCodigo_m)
        Me.xtbpMovimento.Controls.Add(Me.label35)
        Me.xtbpMovimento.Controls.Add(Me.tbQuantidade_m)
        Me.xtbpMovimento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.xtbpMovimento.Name = "xtbpMovimento"
        Me.xtbpMovimento.PageVisible = False
        Me.xtbpMovimento.Size = New System.Drawing.Size(553, 371)
        Me.xtbpMovimento.Text = "Movimento"
        '
        'btnEst2_para_Est1
        '
        Me.btnEst2_para_Est1.Location = New System.Drawing.Point(215, 210)
        Me.btnEst2_para_Est1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEst2_para_Est1.Name = "btnEst2_para_Est1"
        Me.btnEst2_para_Est1.Size = New System.Drawing.Size(59, 39)
        Me.btnEst2_para_Est1.TabIndex = 24
        Me.btnEst2_para_Est1.Text = "<"
        Me.btnEst2_para_Est1.ToolTip = "Move do Est2 para o Est1"
        Me.btnEst2_para_Est1.ToolTipTitle = "Gravar"
        '
        'btnEst1_para_Est2
        '
        Me.btnEst1_para_Est2.Location = New System.Drawing.Point(215, 159)
        Me.btnEst1_para_Est2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEst1_para_Est2.Name = "btnEst1_para_Est2"
        Me.btnEst1_para_Est2.Size = New System.Drawing.Size(59, 39)
        Me.btnEst1_para_Est2.TabIndex = 24
        Me.btnEst1_para_Est2.Text = ">"
        Me.btnEst1_para_Est2.ToolTip = "Move do Est1 para o Est2"
        Me.btnEst1_para_Est2.ToolTipTitle = "Gravar"
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.BackColor = System.Drawing.Color.Transparent
        Me.label34.Location = New System.Drawing.Point(197, 110)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(78, 17)
        Me.label34.TabIndex = 17
        Me.label34.Text = "Quantidade"
        '
        'panelControl4
        '
        Me.panelControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelControl4.Controls.Add(Me.tbEst2_Atual_m)
        Me.panelControl4.Controls.Add(Me.labelControl7)
        Me.panelControl4.Location = New System.Drawing.Point(290, 110)
        Me.panelControl4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelControl4.Name = "panelControl4"
        Me.panelControl4.Size = New System.Drawing.Size(189, 142)
        Me.panelControl4.TabIndex = 135
        '
        'tbEst2_Atual_m
        '
        Me.tbEst2_Atual_m.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.tbEst2_Atual_m.Location = New System.Drawing.Point(119, 66)
        Me.tbEst2_Atual_m.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst2_Atual_m.Name = "tbEst2_Atual_m"
        Me.tbEst2_Atual_m.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst2_Atual_m.Properties.ReadOnly = True
        Me.tbEst2_Atual_m.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst2_Atual_m.Size = New System.Drawing.Size(65, 22)
        Me.tbEst2_Atual_m.TabIndex = 136
        '
        'labelControl7
        '
        Me.labelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.labelControl7.Location = New System.Drawing.Point(5, 65)
        Me.labelControl7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.labelControl7.Name = "labelControl7"
        Me.labelControl7.Size = New System.Drawing.Size(81, 23)
        Me.labelControl7.TabIndex = 134
        Me.labelControl7.Text = " Estoque 2"
        '
        'panelControl5
        '
        Me.panelControl5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelControl5.Controls.Add(Me.tbEst1_Atual_m)
        Me.panelControl5.Controls.Add(Me.LabelControl1)
        Me.panelControl5.Location = New System.Drawing.Point(9, 110)
        Me.panelControl5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.panelControl5.Name = "panelControl5"
        Me.panelControl5.Size = New System.Drawing.Size(188, 142)
        Me.panelControl5.TabIndex = 133
        '
        'tbEst1_Atual_m
        '
        Me.tbEst1_Atual_m.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.tbEst1_Atual_m.Location = New System.Drawing.Point(118, 66)
        Me.tbEst1_Atual_m.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbEst1_Atual_m.Name = "tbEst1_Atual_m"
        Me.tbEst1_Atual_m.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbEst1_Atual_m.Properties.ReadOnly = True
        Me.tbEst1_Atual_m.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbEst1_Atual_m.Size = New System.Drawing.Size(65, 22)
        Me.tbEst1_Atual_m.TabIndex = 136
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LabelControl1.Location = New System.Drawing.Point(12, 65)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 23)
        Me.LabelControl1.TabIndex = 131
        Me.LabelControl1.Text = " Estoque 1"
        '
        'tbNomeCor_m
        '
        Me.tbNomeCor_m.Location = New System.Drawing.Point(244, 23)
        Me.tbNomeCor_m.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbNomeCor_m.Name = "tbNomeCor_m"
        Me.tbNomeCor_m.ReadOnly = True
        Me.tbNomeCor_m.Size = New System.Drawing.Size(217, 23)
        Me.tbNomeCor_m.TabIndex = 132
        '
        'txtCodigo_m
        '
        Me.txtCodigo_m.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo_m.Location = New System.Drawing.Point(149, 17)
        Me.txtCodigo_m.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodigo_m.Name = "txtCodigo_m"
        Me.txtCodigo_m.Size = New System.Drawing.Size(86, 35)
        Me.txtCodigo_m.TabIndex = 129
        Me.txtCodigo_m.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label35
        '
        Me.label35.AutoSize = True
        Me.label35.BackColor = System.Drawing.Color.Transparent
        Me.label35.Location = New System.Drawing.Point(45, 30)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(106, 17)
        Me.label35.TabIndex = 130
        Me.label35.Text = "Codigo da Linha"
        '
        'tbQuantidade_m
        '
        Me.tbQuantidade_m.EditValue = "0"
        Me.tbQuantidade_m.Location = New System.Drawing.Point(210, 130)
        Me.tbQuantidade_m.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbQuantidade_m.Name = "tbQuantidade_m"
        Me.tbQuantidade_m.Properties.Mask.EditMask = "d"
        Me.tbQuantidade_m.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbQuantidade_m.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbQuantidade_m.Size = New System.Drawing.Size(65, 22)
        Me.tbQuantidade_m.TabIndex = 136
        '
        'frmLinha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1188, 750)
        Me.Controls.Add(Me.scc1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLinha"
        Me.Text = "Linhas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemColorPickEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.scc1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scc1.ResumeLayout(False)
        CType(Me.pnlPesquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPesquisa.ResumeLayout(False)
        CType(Me.txtFiltrar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDados.ResumeLayout(False)
        Me.pnlDados.PerformLayout()
        CType(Me.deDataInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDataInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imb_c, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repositoryItemColorEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartLinhaHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabEntraSaida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEntraSaida.ResumeLayout(False)
        Me.xtbpCadastro.ResumeLayout(False)
        Me.xtbpCadastro.PerformLayout()
        CType(Me.ceCor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtbpEntrada.ResumeLayout(False)
        Me.xtbpEntrada.PerformLayout()
        CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl1.ResumeLayout(False)
        Me.panelControl1.PerformLayout()
        CType(Me.tbEst2_Quantidade_e.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst2_Final_e.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst2_Atual_e.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlEst1_e, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEst1_e.ResumeLayout(False)
        Me.pnlEst1_e.PerformLayout()
        CType(Me.tbEst1_Final_e.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst1_Atual_e.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst1_Quantidade_e.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtbpBaixa.ResumeLayout(False)
        Me.xtbpBaixa.PerformLayout()
        CType(Me.panelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl2.ResumeLayout(False)
        Me.panelControl2.PerformLayout()
        CType(Me.tbEst2_Quantidade_b.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst2_Final_b.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst2_Atual_b.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl3.ResumeLayout(False)
        Me.panelControl3.PerformLayout()
        CType(Me.tbEst1_Final_b.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst1_Atual_b.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEst1_Quantidade_b.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpData_Execucao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtbpMovimento.ResumeLayout(False)
        Me.xtbpMovimento.PerformLayout()
        CType(Me.panelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl4.ResumeLayout(False)
        Me.panelControl4.PerformLayout()
        CType(Me.tbEst2_Atual_m.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelControl5.ResumeLayout(False)
        Me.panelControl5.PerformLayout()
        CType(Me.tbEst1_Atual_m.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbQuantidade_m.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Private WithEvents dgRegistros As DevExpress.XtraGrid.GridControl
    Private WithEvents gvRegistros As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents btnFiltrar As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtPreco_Base As MaskedTextBox
    Public WithEvents scc1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents pnlDados As DevExpress.XtraEditors.PanelControl
    Private WithEvents pnlPesquisa As DevExpress.XtraEditors.PanelControl
    Private WithEvents btnX As DevExpress.XtraEditors.DropDownButton
    Private WithEvents txtFiltrar As DevExpress.XtraEditors.TextEdit
    Private WithEvents tabEntraSaida As DevExpress.XtraTab.XtraTabControl
    Private WithEvents xtbpCadastro As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtEstoque_2 As TextBox
    Private WithEvents ceCor As DevExpress.XtraEditors.ColorEdit
    Friend WithEvents txtEstoque_1 As TextBox
    Friend WithEvents txtCodigo_c As TextBox
    Friend WithEvents txtMinimo As TextBox
    Friend WithEvents label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents PedidoLabel As Label
    Friend WithEvents LinhaIdLabel As Label
    Friend WithEvents EstoqueQuantidadeLabel As Label
    Friend WithEvents MaterialNomeLabel As Label
    Friend WithEvents EstoqueMinimoLabel As Label
    Friend WithEvents txtMaterial_Fabricante As TextBox
    Friend WithEvents txtPedido As TextBox
    Friend WithEvents MaterialFabricanteLabel As Label
    Friend WithEvents txtMaterial_Nome As TextBox
    Friend WithEvents MaterialTipoLabel As Label
    Friend WithEvents txtMaterial_Tipo As TextBox
    Private WithEvents xtbpEntrada As DevExpress.XtraTab.XtraTabPage
    Private WithEvents labelControl4 As DevExpress.XtraEditors.LabelControl
    Private WithEvents panelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnEst2_e As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Private WithEvents labelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents pnlEst1_e As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnEst1_e As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents label30 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents label10 As Label
    Friend WithEvents label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tbNomeCor_e As TextBox
    Friend WithEvents txtCodigo_e As TextBox
    Friend WithEvents Label16 As Label
    Private WithEvents xtbpBaixa As DevExpress.XtraTab.XtraTabPage
    Private WithEvents labelControl5 As DevExpress.XtraEditors.LabelControl
    Private WithEvents panelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnEst2_b As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents label1 As Label
    Friend WithEvents label3 As Label
    Friend WithEvents label5 As Label
    Friend WithEvents label6 As Label
    Friend WithEvents label17 As Label
    Private WithEvents labelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents panelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnEst1_b As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents label18 As Label
    Friend WithEvents label19 As Label
    Friend WithEvents label20 As Label
    Friend WithEvents label21 As Label
    Friend WithEvents label22 As Label
    Friend WithEvents tbNomeCor_b As TextBox
    Friend WithEvents txtCodigo_b As TextBox
    Friend WithEvents label23 As Label
    Friend WithEvents label46 As Label
    Private WithEvents dtpData_Execucao As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents btnExecutarItem As DevComponents.DotNetBar.ButtonX
    Private WithEvents xtbpMovimento As DevExpress.XtraTab.XtraTabPage
    Private WithEvents labelControl7 As DevExpress.XtraEditors.LabelControl
    Private WithEvents panelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnEst2_para_Est1 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents panelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnEst1_para_Est2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents label34 As Label
    Friend WithEvents tbNomeCor_m As TextBox
    Friend WithEvents txtCodigo_m As TextBox
    Friend WithEvents label35 As Label
    Friend WithEvents chartLinhaHistorico As DevExpress.XtraCharts.ChartControl
    Friend WithEvents dgLog As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvLog As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents mes As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents compra As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents uso As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents repositoryItemColorEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemColorEdit
    Private WithEvents imb_c As DevExpress.XtraEditors.ImageListBoxControl
    Friend WithEvents codigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents nome As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents estoque_1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents minimo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemColorPickEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit
    Private WithEvents deDataInicial As DevExpress.XtraEditors.DateEdit
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbEst2_Atual_m As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Atual_m As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbQuantidade_m As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst2_Quantidade_e As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Quantidade_e As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst2_Quantidade_b As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Quantidade_b As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Atual_e As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst2_Final_e As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst2_Atual_e As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Final_e As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst2_Final_b As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst2_Atual_b As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Final_b As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbEst1_Atual_b As DevExpress.XtraEditors.TextEdit
End Class
