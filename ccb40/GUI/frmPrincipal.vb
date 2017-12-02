
Imports ccb40.BLL
Imports ccb40.DAL
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors.ColorWheel
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen

Public Class frmPrincipal

    Private Sub RibbonButtonsInitialize()
        ribbon.Toolbar.ItemLinks.Add(rgbiSkins)
    End Sub

    Private Sub InitEditors()
        riicStyle.Items.Add(New ImageComboBoxItem("Office 2007", RibbonControlStyle.Office2007, -1))
        riicStyle.Items.Add(New ImageComboBoxItem("Office 2010", RibbonControlStyle.Office2010, -1))
        riicStyle.Items.Add(New ImageComboBoxItem("Office 2013", RibbonControlStyle.Office2013, -1))
        riicStyle.Items.Add(New ImageComboBoxItem("MacOffice", RibbonControlStyle.MacOffice, -1))
        riicStyle.Items.Add(New ImageComboBoxItem("TabletOffice", RibbonControlStyle.TabletOffice, -1))
        riicStyle.Items.Add(New ImageComboBoxItem("OfficeUniversal", RibbonControlStyle.OfficeUniversal, -1))
        biStyle.EditValue = ribbon.RibbonStyle
    End Sub

    Private Sub SelecionaTab(tab As [String])
        For Each pag As DevExpress.XtraTabbedMdi.XtraMdiTabPage In xtraTabbedMdiManager1.Pages
            If pag.Text = tab Then
                xtraTabbedMdiManager1.SelectedPage = pag
            End If
        Next
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
    End Sub

    Private Sub InitSchemeCombo()
        For Each obj As Object In [Enum].GetValues(GetType(RibbonControlColorScheme))
            repositoryItemComboBox1.Items.Add(obj)
        Next

    End Sub
    Public Sub MostraAgaurde(caption As String, description As String)
        SplashScreenManager.ShowDefaultWaitForm(caption, description)
    End Sub

    Public Sub OcultaAguarde()
        Try
            SplashScreenManager.CloseForm()
        Catch
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()

        ribbon.ForceInitialize()
        Dim skins As New GalleryDropDown()
        skins.Ribbon = ribbon
        DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins)

        DevExpress.UserSkins.BonusSkins.Register()

        SkinHelper.InitSkinGallery(rgbiSkins)

        RibbonButtonsInitialize()

        'CreateColorPopup(popupControlContainer1)
        InitEditors()
        Try
            Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\ccb")
            defaultLookAndFeel1.LookAndFeel.SkinName = regKey.GetValue("Skin").ToString()

            Dim cor As Color
            cor = Color.FromArgb(regKey.GetValue("SkinMaskColor"))

            If cor.Name <> "0" Then
                defaultLookAndFeel1.LookAndFeel.SkinMaskColor = cor
            End If

            cor = Color.FromArgb(regKey.GetValue("SkinMaskColor2"))
            If cor.Name <> "0" Then
                defaultLookAndFeel1.LookAndFeel.SkinMaskColor = cor
            End If

        Catch
            UserLookAndFeel.Default.SetSkinStyle("Office 2013")
            defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        End Try
        ClassBD.StringDeConexao = String.Format("server={0:s};user id={1:s};password={2:s};database={3:s};port=3306;default command timeout=600;", "localhost", "root", "ebtaju", "ccb")

        'testar a conexao
        Dim db As New ClassBD()
        db.TestarConexao()
        Dim bllUsuario As New UsuarioBLL()

        Dim us As Usuario = bllUsuario.CarregaUsuario("visitante", "")

        Try
            bllUsuario.AcessoSistema(us)
            'MessageBox.Show("Acesso válido");
            My.Settings.usuarioId = us.id
            My.Settings.usuarioNome = us.login
            My.Settings.Nivel = us.nivel
            My.Settings.Conectado = True
            Me.DialogResult = DialogResult.OK

        Catch erro As Exception
            MessageBox.Show(erro.Message)
        End Try

        btnBordado_ItemClick(Nothing, Nothing)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Guarda no registro
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\ccb")

        key.SetValue("Style", defaultLookAndFeel1.LookAndFeel.ActiveStyle.GetHashCode)
        key.SetValue("Skin", defaultLookAndFeel1.LookAndFeel.SkinName)
        key.SetValue("SkinMaskColor", defaultLookAndFeel1.LookAndFeel.SkinMaskColor.ToArgb())
        key.SetValue("SkinMaskColor2", defaultLookAndFeel1.LookAndFeel.SkinMaskColor2.ToArgb())
    End Sub

    Private Sub biStyle_EditValueChanged(sender As Object, e As EventArgs) Handles biStyle.EditValueChanged
        Dim style As RibbonControlStyle = DirectCast(biStyle.EditValue, RibbonControlStyle)
        ribbon.RibbonStyle = style
        'ribbon.ApplicationButtonDropDownControl = this.backstageViewControl1;
        If style = RibbonControlStyle.Office2010 OrElse style = RibbonControlStyle.MacOffice OrElse style = RibbonControlStyle.Office2013 OrElse style = RibbonControlStyle.TabletOffice OrElse style = RibbonControlStyle.OfficeUniversal Then
            'Else
            'ribbon.ApplicationButtonDropDownControl = pmAppMain
        End If
        'reset de ajuste de cores
        defaultLookAndFeel1.LookAndFeel.SkinMaskColor = Nothing
        defaultLookAndFeel1.LookAndFeel.SkinMaskColor2 = Nothing

        UpdateLookAndFeel()
    End Sub

    Private Sub UpdateLookAndFeel()
        Dim skinName As String
        Dim style As RibbonControlStyle = ribbon.RibbonStyle
        Select Case style
            Case RibbonControlStyle.[Default],
                 RibbonControlStyle.Office2007
                skinName = "Office 2007 Blue"
            Case RibbonControlStyle.Office2013,
                 RibbonControlStyle.TabletOffice,
                 RibbonControlStyle.OfficeUniversal
                skinName = "Office 2013"
            Case RibbonControlStyle.Office2010,
                 RibbonControlStyle.MacOffice
                skinName = "Office 2010 Blue"
            Case Else
                skinName = "Office 2010 Blue"
        End Select
        UserLookAndFeel.[Default].SetSkinStyle(skinName)
    End Sub

    Private Sub btnBordado_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnBordado.ItemClick
        MostraAgaurde("Aguarde", "Abrindo o form (Bordado) ...")
        My.Forms.frmBordados.MdiParent = Me
        My.Forms.frmBordados.Show()
        My.Forms.frmBordados.Activate()
        My.Forms.frmBordados.WindowState = FormWindowState.Maximized
        OcultaAguarde()
    End Sub

    Private Sub bbColorMix_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbColorMix.ItemClick
        Dim form As New ColorWheelForm()
        form.StartPosition = FormStartPosition.CenterParent
        form.SkinMaskColor = UserLookAndFeel.[Default].SkinMaskColor
        form.SkinMaskColor2 = UserLookAndFeel.[Default].SkinMaskColor2
        form.ShowDialog(Me)
    End Sub

    Private Sub btnLinha_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnLinha.ItemClick
        MostraAgaurde("Aguarde", "Abrindo o form (Bordado) ...")
        My.Forms.frmLinha.MdiParent = Me
        My.Forms.frmLinha.Show()
        My.Forms.frmLinha.Activate()
        My.Forms.frmLinha.WindowState = FormWindowState.Maximized
        OcultaAguarde()
    End Sub
End Class